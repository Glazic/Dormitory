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
	public partial class ResidentForm : Form
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");

		public ResidentForm()
		{
			InitializeComponent();
		}

		public ResidentForm(int residentId)
		{
			InitializeComponent();
			residentIdLabel.Text = residentId.ToString();
			LoadData();
		}

		public static string ShowDialog(int residentId)
		{
			ResidentForm residentForm = new ResidentForm(residentId);
			//	this.Show();
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.nameLabel.Text : "";
		}

		public void LoadData()
		{
			try
			{
				sqlConnection.Open();
				string sqlExpression = $"SELECT * FROM Residents WHERE ResidentId = {residentIdLabel.Text}";
				SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows) // если есть данные
				{
					// выводим названия столбцов
					
					while (reader.Read()) // построчно считываем данные
					{
						residentIdLabel.Text = reader.GetValue(0).ToString();
						surnameTextBox.Text = reader.GetValue(1).ToString();
						nameTextBox.Text = reader.GetValue(2).ToString();
						patronymicTextBox.Text = reader.GetValue(3).ToString();
						phoneNumberTextBox.Text = reader.GetValue(4).ToString();
						birthdayDateTimePicker.Text = reader.GetValue(5).ToString();
						passportIdTextBox.Text = reader.GetValue(6).ToString();
						organizationIdTextBox.Text = reader.GetValue(7).ToString();
						
					}
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				
				sqlConnection.Close();
			}
		}
		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
