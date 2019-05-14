using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Dormitory
{
	public partial class LoginForm : Form
	{
		private SqlConnection sqlConnection;

		public LoginForm()
		{
			InitializeComponent();
		}

		private void enterButton_Click(object sender, EventArgs e)
		{
			SqlConnection sqlConnection = new SqlConnection();
			string login = loginTextBox.Text;
			string password = passwordTextBox.Text;

			if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Введите логин и пароль!");
				return;
			}
			try
			{
				sqlConnection.ConnectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True";
				//sqlConnection.ConnectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;User ID={userName};Password={password}";

				//SqlConnection sqlConnection = new SqlConnection();
				string query = "SELECT COUNT(*) AS cnt FROM Users " +
					$"WHERE Login = '{login}' AND Password = '{password}'";
				SqlCommand cmd = new SqlCommand(query, sqlConnection);
				cmd.Parameters.Clear();
				sqlConnection.Open();

				if (cmd.ExecuteScalar().ToString() == "1")
				{
					MessageBox.Show("YOU ARE GRANTED WITH ACCESS");
					MainForm mainForm = new MainForm();
					mainForm.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Неверный логин и/или пароль");
					loginTextBox.Clear();
					passwordTextBox.Clear();
				}
				sqlConnection.Close();


				//MainForm mainForm = new MainForm(this, userName, password);
				////	MainForm mainForm = new MainForm(this, "zaq", "zaq");
				//MainForm mainForm = new MainForm();
				//		mainForm.Show();
				//		this.Hide();
			}
			catch (SqlException)
			{
				MessageBox.Show("Не удалось выполнить вход", "Ошибка");
			}
			finally
			{
				//sqlConnection.Close();
			}

		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			try
			{
				sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
				sqlConnection.Open();
			}
			catch (SqlException)
			{
				MessageBox.Show("Не удалось подключиться к базе данных", "Ошибка");

				OpenFileDialog dlg = new OpenFileDialog();
				string filePath = "";
				dlg.Filter = "Sql scripts(*.sql)|*.sql|All Files(*.*)|*.*";
				dlg.FilterIndex = 0;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					filePath = dlg.FileName;
				}

				SqlConnection myConn = new SqlConnection("Data Source =.\\SQLEXPRESS; Integrated Security = True");

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
					MessageBox.Show("База данных создана");
				}
				catch (SqlException)
				{
					MessageBox.Show("Ошибка");
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

	}
}
