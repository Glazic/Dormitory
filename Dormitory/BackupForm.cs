using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
	public partial class BackupForm : Form
	{
		private SqlConnection conn;
		private SqlCommand command;
		private SqlDataReader reader;
		string sql = "";
		string connectionString = "";

		public BackupForm()
		{
			InitializeComponent();
		}

		private void connectButton_Click(object sender, EventArgs e)
		{
			try
			{
	//	($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");

		connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True";
	//	connectionString = "Data Source = " + dataSourceTextBox.Text + "; User Id=" + loginTextBox.Text + "; Password=" + passwordTextBox.Text + "";
				conn = new SqlConnection(connectionString);
				conn.Open();
				//sql = "EXEC sp_databases";
				sql = "SELECT * FROM sys.databases d WHERE d.database_id>4";
				command = new SqlCommand(sql, conn);
				reader = command.ExecuteReader();
				databasesComboBox.Items.Clear();
				while (reader.Read())
				{
					databasesComboBox.Items.Add(reader[0].ToString());
				}
				conn.Close();
				conn.Dispose();

				dataSourceTextBox.Enabled = false;
				loginTextBox.Enabled = false;
				passwordTextBox.Enabled = false;
				connectButton.Enabled = false;
				disconnectButton.Enabled = true;

				backupButton.Enabled = true;
				restoreButton.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void backupButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (databasesComboBox.Text.CompareTo("") == 0)
				{
					MessageBox.Show("Select db");
				}
				conn = new SqlConnection(connectionString);
				conn.Open();
				sql = "BACKUP DATABASE " + databasesComboBox.Text + " TO DISK = '" + backupFileTextBox.Text + "\\" 
					+ databasesComboBox.Text + "-" + DateTime.Now.ToString("dd-MM-yyyy-hh/mm/ss") + ".bak'";
				command = new SqlCommand(sql, conn);
				command.ExecuteNonQuery();
				conn.Close();
				conn.Dispose();
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
				backupFileTextBox.Text = dlg.SelectedPath;
			}
		}

		private void browseRestoreButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.*";
			dlg.FilterIndex = 0;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				restoreFileTextBox.Text = dlg.FileName;
			}
		}

		private void restoreButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (databasesComboBox.Text.CompareTo("") == 0)
				{
					MessageBox.Show("Select db");
				}
				conn = new SqlConnection(connectionString);
				conn.Open();
				sql = "use master " +
					" ALTER DATABASE " + databasesComboBox.Text + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
				sql += "RESTORE DATABASE " + databasesComboBox.Text + " FROM DISK = '" + restoreFileTextBox.Text + "' WITH REPLACE;";
				command = new SqlCommand(sql, conn);
				command.ExecuteNonQuery();
				conn.Close();
				conn.Dispose();
				MessageBox.Show("successfull");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
