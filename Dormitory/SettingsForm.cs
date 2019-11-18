using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Dormitory
{
	// Отвечает за окно настроек программы
	public partial class SettingsForm : Form
	{
		private SqlConnectionStringBuilder sqlConnectionString;
		private SqlCommand command;
		DataTable dataTable = new DataTable();
		string sql = "";

		public SettingsForm()
		{
			InitializeComponent();
		}

		public SettingsForm(SqlConnectionStringBuilder sqlConnectionString) : this()
		{
			this.sqlConnectionString = sqlConnectionString;
		}
		// Создание резервной копии базы данных
		private void backupButton_Click(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				BackupHelper.BackupDatabase(userServerDatabaseTextBox.Text, backupsFolderPathTextBox.Text);
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Успешно сохранено!");
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при создании резервной копии базы данных в backupButton_Click.");
				MessageBox.Show("Ошибка при создании резервной копии базы данных.\nВызвано исключение: " + ex.Message);
			}
			finally
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		// выбор папки для сохранения копии бд
		private void browseBackupButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				backupsFolderPathTextBox.Text = dlg.SelectedPath;
			}
		}

		// Выбор файла резервной копии для восстановления бд
		private void browseRestoreButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Файлы восстановления(*.bak)|*.bak|Все файлы(*.*)|*.*";
			dlg.FilterIndex = 0;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				restoreFilePathTextBox.Text = dlg.FileName;
			}
		}

		// Восстановление бд с резервной копии
		private void restoreButton_Click(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				BackupHelper.RestoreDatabase(userServerDatabaseTextBox.Text, restoreFilePathTextBox.Text);
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Успешно восстановлено!");
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при восстановление базы данных с резервной копии в restoreButton_Click.");
				MessageBox.Show("Ошибка при восстановление базы данных с резервной копии.\nВызвано исключение: " + ex.Message);
			}
			finally
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		// Выбор файла sql-скрипта 
		private void browseSqlScriptButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Sql скрипт(*.sql)|*.sql|Все файлы(*.*)|*.*";
			dlg.FilterIndex = 0;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				sqlScriptFileTextBox.Text = dlg.FileName;
			}
		}

		// Запуск выбранного sql-скрипта
		private void runSqlScriptButton_Click(object sender, EventArgs e)
		{
			SqlConnection myConn = new SqlConnection("Data Source =.\\SQLEXPRESS; Integrated Security = True");
			string script = File.ReadAllText(sqlScriptFileTextBox.Text);
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
			try
			{
				myConn.Open();
				foreach (string commandString in commandStrings)
				{
					if (commandString.Trim() != "")
					{
						using (var command = new SqlCommand(commandString, myConn))
						{
							command.ExecuteNonQuery();
						}
					}
				}
				SystemSounds.Beep.Play();
				MessageBox.Show("Успешно выполено");

				SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
				{
					DataSource = Properties.Settings.Default.userServerName,
					InitialCatalog = Properties.Settings.Default.userServerDatabase,
					IntegratedSecurity = true
				};
				HistoryRecordsController.ChangeSqlConnection(sConnB.ConnectionString);
			}
			catch (Exception ex)
			{
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при запуске sql-скрипта в runSqlScriptButton_Click.");
				MessageBox.Show("Ошибка при запуске sql-скрипта.\nВызвано исключение: " + ex.Message);
			}
			finally
			{
				myConn.Close();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		// Сохранение настроек программы
		private void saveSettingsButton_Click(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				Properties.Settings.Default.userServerName = userServerNameTextBox.Text;
				Properties.Settings.Default.userServerDatabase = userServerDatabaseTextBox.Text;
				Properties.Settings.Default.userServer2Name = userServer2NameTextBox.Text;
				Properties.Settings.Default.userServer2Database = userServer2DatabaseTextBox.Text;
				Properties.Settings.Default.adminServerName = adminServerNameTextBox.Text;
				Properties.Settings.Default.adminServerDatabase = adminServerDatabaseTextBox.Text;
				Properties.Settings.Default.backupsFolderPath = backupsFolderPathTextBox.Text;
				Properties.Settings.Default.restoreFilePath = restoreFilePathTextBox.Text;
				Properties.Settings.Default.exceptionsLogFolderPath = exceptionsLogFolderPathTextBox.Text;
				Properties.Settings.Default.Save();

				SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
				{
					DataSource = Properties.Settings.Default.userServerName,
					InitialCatalog = Properties.Settings.Default.userServerDatabase,
					IntegratedSecurity = true
				};
				HistoryRecordsController.ChangeSqlConnection(sConnB.ConnectionString);

				SystemSounds.Exclamation.Play();
				MessageBox.Show("Настройки успешно сохранены!");
			}
			catch (Exception ex)
			{
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при сохранении настроек программы в saveSettingsButton_Click.");
				MessageBox.Show("Ошибка при сохранении настроек программы.\nВызвано исключение: " + ex.Message);
			}
			finally
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		// Загрузка настроек программы
		private void BackupForm_Load(object sender, EventArgs e)
		{
			userServerNameTextBox.Text = Properties.Settings.Default.userServerName;
			userServerDatabaseTextBox.Text = Properties.Settings.Default.userServerDatabase;
			userServer2NameTextBox.Text = Properties.Settings.Default.userServer2Name;
			userServer2DatabaseTextBox.Text = Properties.Settings.Default.userServer2Database;
			adminServerNameTextBox.Text = Properties.Settings.Default.adminServerName;
			adminServerDatabaseTextBox.Text = Properties.Settings.Default.adminServerDatabase;
			backupsFolderPathTextBox.Text = Properties.Settings.Default.backupsFolderPath;
			restoreFilePathTextBox.Text = Properties.Settings.Default.restoreFilePath;
			exceptionsLogFolderPathTextBox.Text = Properties.Settings.Default.exceptionsLogFolderPath;

		}

		// Проверка подключения к администраторскому серверу
		private void checkAdminServerConnectionButton_Click(object sender, EventArgs e)
		{
			SqlConnection testConnection = new SqlConnection();
			try
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
				{
					DataSource = adminServerNameTextBox.Text,
					InitialCatalog = adminServerDatabaseTextBox.Text,
					UserID = LoginForm.UserName,
					Password = LoginForm.Password
				};
				testConnection.ConnectionString = sConnB.ConnectionString;
				testConnection.Open();
				if (testConnection.State == ConnectionState.Open)
				{
					MessageBox.Show("Соединение успешно произошло");
				}
			}
			catch (Exception ex)
			{
				SystemSounds.Hand.Play();
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при проверке подключения к администраторскому серверу в checkAdminServerConnectionButton_Click.");
				MessageBox.Show("Ошибка при проверке подключения к администраторскому серверу.\nВызвано исключение: " + ex.Message);
			}
			finally
			{
				testConnection.Close();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		// Проверка подключения к пользовательскому серверу
		private void checkUserServerConnectionButton_Click(object sender, EventArgs e)
		{
			using (SqlConnection testConnection = new SqlConnection())
			{
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
					{
						DataSource = userServerNameTextBox.Text,
						InitialCatalog = userServerDatabaseTextBox.Text,
						UserID = LoginForm.UserName,
						Password = LoginForm.Password
					};
					testConnection.ConnectionString = sConnB.ConnectionString;
					testConnection.Open();
					if (testConnection.State == ConnectionState.Open)
					{
						MessageBox.Show("Соединение успешно произошло");
					}
				}
				catch (Exception ex)
				{
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при проверке подключения к пользовательскому серверу в checkUserServerConnectionButton_Click.");
					MessageBox.Show("Ошибка при проверке подключения к пользовательскому серверу.\nВызвано исключение: " + ex.Message);
				}
				finally
				{
					testConnection.Close();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}
		// Закрытие окна с помощью клавиши Esc
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void checkUserServer2ConnectionButton_Click(object sender, EventArgs e)
		{
			using (SqlConnection testConnection = new SqlConnection())
			{
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
					{
						DataSource = userServer2NameTextBox.Text,
						InitialCatalog = userServer2DatabaseTextBox.Text,
						UserID = LoginForm.UserName,
						Password = LoginForm.Password
					};
					testConnection.ConnectionString = sConnB.ConnectionString;
					testConnection.Open();
					if (testConnection.State == ConnectionState.Open)
					{
						MessageBox.Show("Соединение успешно произошло");
					}
				}
				catch (Exception ex)
				{
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при проверке подключения к второму пользовательскому серверу в checkUserServer2ConnectionButton_Click.");
					MessageBox.Show("Ошибка при проверке подключения к второму пользовательскому серверу.\nВызвано исключение: " + ex.Message);
				}
				finally
				{
					testConnection.Close();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}

		private void browseExceptionLogButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				exceptionsLogFolderPathTextBox.Text = dlg.SelectedPath;
			}
		}
	}
}