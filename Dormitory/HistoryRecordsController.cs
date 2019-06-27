using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
	public static class HistoryRecordsController
	{
		public static SqlConnection sqlConnection { get; set; }
		public static DataContext db { get; set; }
		public static string UserName { get; set; }

		static HistoryRecordsController()
		{
			SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
			{
				DataSource = Properties.Settings.Default.userServerName,
				InitialCatalog = Properties.Settings.Default.userServerDatabase,
				IntegratedSecurity = true
			};
			sqlConnection = new SqlConnection(sConnB.ConnectionString);
			db = new DataContext(HistoryRecordsController.sqlConnection);
		}

		public static void ChangeSqlConnection(string ConnectionString)
		{
			HistoryRecordsController.sqlConnection.ConnectionString = ConnectionString;
			db = new DataContext(HistoryRecordsController.sqlConnection);
		}

		public static void ChangeUser(string UserName)
		{
			HistoryRecordsController.UserName = UserName;
		}

		public static void WriteAboutAuthorization(bool isSuccessfull)
		{
			string action = isSuccessfull ? "Успешный вход" : "Ошибка входа";
			try
			{
				HistoryRecord historyRecord = new HistoryRecord
				{
					UserName = HistoryRecordsController.UserName,
					Action =  action,
					DateOfAction = DateTime.Now
				};
				db.GetTable<HistoryRecord>().InsertOnSubmit(historyRecord);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка ведения истории!\n" + ex.Message);
			}
		}
	}
}
