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
	public partial class LoginForm : Form
	{
		public static string UserName { get; set; }
		public static string Password { get; set; }
		private SqlConnection sqlConnection;

		public LoginForm()
		{
			InitializeComponent();
		}

		private void enterButton_Click(object sender, EventArgs e)
		{
			SqlConnection sqlConnection = new SqlConnection();
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
				HistoryRecordsController.WriteAboutAuthorization(true);
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				MainForm mainForm = new MainForm(this, sqlConnection);
				mainForm.Show();
				this.Hide();
				LoginForm.UserName = userName;
				LoginForm.Password = password;
			}
			catch (SqlException)
			{
				HistoryRecordsController.ChangeUser(userName);
				HistoryRecordsController.WriteAboutAuthorization(false);
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Не удалось выполнить вход.\nУбедитесь, что введены правильные логин и(или) пароль", "Ошибка");
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

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
			catch (SqlException ex)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Не удалось подключиться к базе данных. Ошибка:\n" + ex.Message, "Ошибка");
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
				catch (SqlException sqlEx)
				{
					SystemSounds.Exclamation.Play();
					MessageBox.Show("Ошибка подключения:\n" + sqlEx.Message);
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

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void settingsButton_Click(object sender, EventArgs e)
		{
			SettingsForm settingsForm = new SettingsForm(sqlConnection);
			settingsForm.ShowDialog();
		}
	}
}
