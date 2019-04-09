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
			//string userName = loginTextBox.Text;
			//string password = passwordTextBox.Text;

			//if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
			//{
			//	MessageBox.Show("Введите логин и пароль!");
			//	return;
			//}
			try
			{
				sqlConnection.ConnectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True";
				//sqlConnection.ConnectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;User ID={userName};Password={password}";
				sqlConnection.Open();
				//MainForm mainForm = new MainForm(this, userName, password);
				MainForm mainForm = new MainForm(this, "zaq", "zaq");
				//MainForm mainForm = new MainForm();

				mainForm.Show();
				this.Hide();
			}
			catch (SqlException)
			{
				MessageBox.Show("Не удалось выполнить вход", "Ошибка");
			}
			finally
			{
				sqlConnection.Close();
			}

		}
	}
}
