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
	public partial class SettingsForm : Form
	{
		private SqlConnection sqlConnection = new SqlConnection();
		private SqlCommand command;
		private SqlDataReader reader;
		SqlDataAdapter dataAdapter;
		DataTable dataTable = new DataTable();
		string sql = "";
		string connectionString = "";

		public SettingsForm()
		{
			InitializeComponent();
		}

		public SettingsForm(SqlConnection sqlConnection) : this()
		{
			this.sqlConnection = sqlConnection;
		}
		
		private void backupButton_Click(object sender, EventArgs e)
		{
			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				sql = "BACKUP DATABASE " + userServerDatabaseTextBox.Text + " TO DISK = '" + backupsFolderPathTextBox.Text + "\\"
					+ userServerDatabaseTextBox.Text + "-" + DateTime.Now.ToString("dd-MM-yyyy-hh/mm/ss") + ".bak'";
				command = new SqlCommand(sql, sqlConnection);
				command.ExecuteNonQuery();
				sqlConnection.Close();
				sqlConnection.Dispose();
				MessageBox.Show("successfull");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void browseBackupButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				backupsFolderPathTextBox.Text = dlg.SelectedPath;
			}
		}

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

		private void restoreButton_Click(object sender, EventArgs e)
		{
			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				sql = "use master " +
					" ALTER DATABASE " + userServerDatabaseTextBox.Text + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
				sql += "RESTORE DATABASE " + userServerDatabaseTextBox.Text + " FROM DISK = '" + restoreFilePathTextBox.Text + "' WITH REPLACE;";
				command = new SqlCommand(sql, sqlConnection);
				command.ExecuteNonQuery();
				sqlConnection.Close();
				sqlConnection.Dispose();
				MessageBox.Show("successfull");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		//private void browseSqlScriptButton_Click(object sender, EventArgs e)
		//{
		//	OpenFileDialog dlg = new OpenFileDialog();
		//	dlg.Filter = "Sql скрипт(*.sql)|*.sql|Все файлы(*.*)|*.*";
		//	dlg.FilterIndex = 0;
		//	if (dlg.ShowDialog() == DialogResult.OK)
		//	{
		//		sqlScriptFileTextBox.Text = dlg.FileName;
		//	}
		//}

		//private void runSqlScriptButton_Click(object sender, EventArgs e)
		//{
		//	SqlConnection myConn = new SqlConnection("Data Source =.\\SQLEXPRESS; Integrated Security = True");
		//	string script = File.ReadAllText(sqlScriptFileTextBox.Text);
		//	System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
		//	IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
		//	try
		//	{
		//		myConn.Open();
		//		foreach (string commandString in commandStrings)
		//		{
		//			if (commandString.Trim() != "")
		//			{
		//				using (var command = new SqlCommand(commandString, myConn))
		//				{
		//					command.ExecuteNonQuery();
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//	}
		//	finally
		//	{
		//		myConn.Close();
		//		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		//	}
		//	MessageBox.Show("loaded");
		//}

		//private void connectBut_Click(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		// sqlConnection.ConnectionString = $"Data Source=WATCH1\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True";
		//		// sqlConnection.ConnectionString = $"Data Source={textBox1.Text};Initial Catalog=Dormitory;User ID=zaq;Password=zaq";
		//		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
		//		sqlConnection.ConnectionString = $"Data Source={textBox1.Text}\\SQLEXPRESS;Initial Catalog=DormitoryAdmin;User ID=igor;Password=igor";
		//		sqlConnection.Open();
		//		dataAdapter = new SqlDataAdapter("SELECT OrganizationId as [ИД], " +
		//	"Name as [Название], PhysicAddress as [Адрес] " +
		//	"FROM Organizations", sqlConnection);
		//		dataTable.Clear();
		//		dataAdapter.Fill(dataTable);
		//		organizationsDataGridView.DataSource = dataTable;
		//		organizationsDataGridView.Columns[0].Width = 50;
		//		organizationsDataGridView.Columns[1].Width = 200;
		//		organizationsDataGridView.Columns[2].Width = 200;
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//	}
		//	finally
		//	{
		//		sqlConnection.Close();
		//		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		//	}
		//}

		private void saveSettingsButton_Click(object sender, EventArgs e)
		{
			try
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				Properties.Settings.Default.userServerName = userServerNameTextBox.Text;
				Properties.Settings.Default.userServerDatabase = userServerDatabaseTextBox.Text;
				Properties.Settings.Default.adminServerName = adminServerNameTextBox.Text;
				Properties.Settings.Default.adminServerDatabase = adminServerDatabaseTextBox.Text;
				Properties.Settings.Default.backupsFolderPath = backupsFolderPathTextBox.Text;
				Properties.Settings.Default.restoreFilePath = restoreFilePathTextBox.Text;
				Properties.Settings.Default.savesIntervalHours = Convert.ToInt32(savesIntervalHoursNumericUpDown.Value);
				Properties.Settings.Default.savesDurationHours = Convert.ToInt32(savesDurationHoursNumericUpDown.Value);
				Properties.Settings.Default.Save();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		private void BackupForm_Load(object sender, EventArgs e)
		{
			userServerNameTextBox.Text = Properties.Settings.Default.userServerName;
			userServerDatabaseTextBox.Text = Properties.Settings.Default.userServerDatabase;
			adminServerNameTextBox.Text = Properties.Settings.Default.adminServerName;
			adminServerDatabaseTextBox.Text = Properties.Settings.Default.adminServerDatabase;
			backupsFolderPathTextBox.Text = Properties.Settings.Default.backupsFolderPath;
			restoreFilePathTextBox.Text = Properties.Settings.Default.restoreFilePath;
			savesIntervalHoursNumericUpDown.Value = Properties.Settings.Default.savesIntervalHours;
			savesDurationHoursNumericUpDown.Value = Properties.Settings.Default.savesDurationHours;
		}

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
				MessageBox.Show("Не удалось подключиться. Ошибка:\n" + ex.Message);
			}
			finally
			{
				testConnection.Close();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		private void checkUserServerConnectionButton_Click(object sender, EventArgs e)
		{
			SqlConnection testConnection = new SqlConnection();
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
				MessageBox.Show("Не удалось подключиться. Ошибка:\n" + ex.Message);
			}
			finally
			{
				testConnection.Close();
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
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

		private void browseSqlScriptButton_Click(object sender, EventArgs e)
		{

		}

		private void runSqlScriptButton_Click(object sender, EventArgs e)
		{

		}

		private void connectBut_Click(object sender, EventArgs e)
		{

		}
	}
}