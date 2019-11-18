using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dormitory
{
	public static class BackupHelper
	{
		public static SqlConnectionStringBuilder sqlConnectionString { get; set; }
		public static SqlCommand command { get; set; }
		private static string sql = "";

		private static Task task;
		private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
		private static CancellationToken token = cancelTokenSource.Token;

		// Запуск фонового потока для резервной копии
		public static void StartThreadForBackup()
		{
			task = new Task(RunBackupTask);
			task.Start();
		}

		// Остановка фонового потока для резервной копии
		public static void StopThreadForBackup()
		{
			cancelTokenSource.Cancel();
		}

		static void RunBackupTask()
		{
			Thread.Sleep(10 * 1000);		

			int period = 10 * 60 * 60 * 1000;
			while (true)
			{				
				if (token.IsCancellationRequested)
				{
					//timer.Change(Timeout.Infinite, Timeout.Infinite);
					return;
				}
				BackupDatabase(Properties.Settings.Default.userServerDatabase, Properties.Settings.Default.backupsFolderPath);

				string path = Properties.Settings.Default.backupsFolderPath;
				foreach (string sFile in System.IO.Directory.GetFiles(Properties.Settings.Default.backupsFolderPath, "*.bak"))
				{
					DateTime creation = File.GetCreationTime(sFile);
					if (DateTime.Compare(creation, DateTime.Now.AddDays(-1)) < 0)
					{
						System.IO.File.Delete(sFile);
					}
				}
				Thread.Sleep(period);
			}
		}



		// Создание резервной копии базы данных
		public static void BackupDatabase(string databaseName, string folderPath)
		{
			using (SqlConnection sqlConnection = new SqlConnection("Data Source =.\\SQLEXPRESS; Integrated Security = True"))
			{
				try
				{
					sqlConnection.Open();
					sql = "BACKUP DATABASE " + databaseName + " TO DISK = '" + folderPath + "\\"
						+ databaseName + "-" + DateTime.Now.ToString("dd-MM-yyyy-hh/mm/ss") + ".bak'";
					command = new SqlCommand(sql, sqlConnection);
					command.ExecuteNonQuery();
					sqlConnection.Close();
					sqlConnection.Dispose();
					SystemSounds.Exclamation.Play();
				}
				catch (Exception ex)
				{
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при создании резервной копии базы данных в BackupHelper.backupDatabase.");
				}
				finally
				{
					sqlConnection.Close();
				}
			}
		}

		// Восстановление бд с резервной копии 
		public static void RestoreDatabase(string databaseName, string folderPath)
		{
			using (SqlConnection myConn = new SqlConnection("Data Source =.\\SQLEXPRESS; Integrated Security = True"))
			{
				try
				{
					myConn.Open();
					sql = "use master " +
						" ALTER DATABASE " + databaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
					sql += "RESTORE DATABASE " + databaseName + " FROM DISK = '" + folderPath + "' WITH REPLACE;";
					command = new SqlCommand(sql, myConn);
					command.ExecuteNonQuery();
					myConn.Close();
					myConn.Dispose();
					SystemSounds.Exclamation.Play();
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при восстановление базы данных с резервной копии в BackupHelper.restoreDatabase.");
				}
				finally
				{
					myConn.Close();
				}
			}
		}

	}
}
