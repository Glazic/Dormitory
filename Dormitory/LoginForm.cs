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
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void enterButton_Click(object sender, EventArgs e)
		{
			SqlConnection sqlConnection = new SqlConnection();
			string login = loginTextBox.Text;
			string password = passwordTextBox.Text;

			//if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
			//{
			//	MessageBox.Show("Введите логин и пароль!");
			//	return;
			//}
			try
			{
				sqlConnection.ConnectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True";
				//sqlConnection.ConnectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;User ID={userName};Password={password}";

				//SqlConnection sqlConnection = new SqlConnection();
				string query = "SELECT COUNT(*) AS cnt FROM Users " +
					$"WHERE Login = '{login}' AND Password = '{password}'";
				SqlCommand cmd = new SqlCommand(query, sqlConnection);
				cmd.Parameters.Clear();

				//SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
				//DataTable dtbl = new DataTable();
				//sda.Fill(dtbl);
				//if (dtbl.Rows.Count == 1)
				//{
				//	MessageBox.Show("YOU ARE GRANTED WITH ACCESS");

				//}
				//else
				//{
				//	MessageBox.Show("YOU ARE NOT GRANTED WITH ACCESS");
				//	loginTextBox.Clear();
				//	passwordTextBox.Clear();
				//}

				sqlConnection.Open();

				if (cmd.ExecuteScalar().ToString() == "1")
				{
					MessageBox.Show("YOU ARE GRANTED WITH ACCESS");
				}
				else
				{
					MessageBox.Show("YOU ARE NOT GRANTED WITH ACCESS");
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
	}
}
