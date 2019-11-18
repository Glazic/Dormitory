using Dormitory.Properties;
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
using Dormitory;

namespace Dormitory
{
	// Отвечает за окно авторизации
	public partial class LoginForm : Form
	{
		public static string UserName { get; set; }
		public static string Password { get; set; }
		private SqlConnection sqlConnection;
		private SqlConnectionStringBuilder sqlConnectionString;

		public LoginForm()
		{
			InitializeComponent();
		}
		// Попытка войти в систему
		private void enterButton_Click(object sender, EventArgs e)
		{
			using (SqlConnection sqlConnection = new SqlConnection())
			{
				string userName = userNameTextBox.Text;
				string password = passwordTextBox.Text;

				if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
				{
					SystemSounds.Exclamation.Play();
					MessageBox.Show("Введите логин и пароль!");
					return;
				}
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
					{
						DataSource = Properties.Settings.Default.userServerName,
						InitialCatalog = Properties.Settings.Default.userServerDatabase,
						UserID = userName,
						Password = password,
					};
					sqlConnection.ConnectionString = sConnB.ConnectionString;
					sqlConnection.Open();
					HistoryRecordsController.ChangeUser(userName);
					HistoryRecordsController.WriteAboutSystemEnter(true);
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
					MainForm mainForm = new MainForm(this, sConnB);
					mainForm.Show();
					this.Hide();
					LoginForm.UserName = userName;
					LoginForm.Password = password;
					userNameTextBox.Clear();
					passwordTextBox.Clear();
				}
				catch (SqlException sqlEx)
				{
					HistoryRecordsController.ChangeUser(userName);
					HistoryRecordsController.WriteAboutSystemEnter(false);
					HistoryRecordsController.WriteExceptionToLogFile(sqlEx, "Не удалось выполнить вход. Введены неверный логин и(или) пароль.");
					SystemSounds.Exclamation.Play();
					MessageBox.Show("Не удалось выполнить вход.\nУбедитесь, что введены правильные логин и(или) пароль.", "Ошибка");
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при входе.");
					MessageBox.Show(ex.Message);
				}
				finally
				{
					sqlConnection.Close();
				}
			}
		}
		// Проверка существования базы данных. Если бд не существует, открывается окно 
		// выбора sql-скрипта для создания новой базы данных.
		private void LoginForm_Load(object sender, EventArgs e)
		{
			try
			{
				SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
				{
					DataSource = Properties.Settings.Default.userServerName,
					InitialCatalog = Properties.Settings.Default.userServerDatabase,
					IntegratedSecurity = true
				};
				sqlConnection = new SqlConnection(sConnB.ConnectionString);
				sqlConnection.Open();
				HistoryRecordsController.ChangeSqlConnection(sConnB.ConnectionString);
			}
			catch (SqlException sqlEx)
			{
				SystemSounds.Exclamation.Play();
				HistoryRecordsController.WriteExceptionToLogFile(sqlEx, "Ошибка подключения к базе данных при запуске программы.");
				MessageBox.Show("Не удалось подключиться к базе данных. Ошибка:\n" + sqlEx.Message, "Ошибка");
				OpenFileDialog dlg = new OpenFileDialog();
				string filePath = "";
				dlg.Filter = "Sql scripts(*.sql)|*.sql|All Files(*.*)|*.*";
				dlg.FilterIndex = 0;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					filePath = dlg.FileName;
				}
				SqlConnectionStringBuilder sConnB2 = new SqlConnectionStringBuilder()
				{
					DataSource = Properties.Settings.Default.userServerName,
					IntegratedSecurity = true
				};
				SqlConnection myConn = new SqlConnection(sConnB2.ConnectionString);
				string script = File.ReadAllText(filePath);
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
					MessageBox.Show("База данных создана");
				}
				catch (SqlException ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка создания базы данных через sql-скрипт.");
					MessageBox.Show("Ошибка создания базы данных:\n" + sqlEx.Message);
				}
				finally
				{
					myConn.Close();
				}
			}
			finally
			{
				sqlConnection.Close();
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

		// Открытие окна настроек программы
		private void settingsButton_Click(object sender, EventArgs e)
		{

			LoginForm.UserName = userNameTextBox.Text;
			LoginForm.Password = passwordTextBox.Text;
			SettingsForm settingsForm = new SettingsForm(sqlConnectionString);
			settingsForm.ShowDialog();
		}
	}
}
