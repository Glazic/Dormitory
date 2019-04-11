using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;

namespace Dormitory
{
	public partial class OrganizationsForm : Form
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		SqlCommand cmd;
		SqlDataAdapter dataAdapter;
		DataTable dataTable;
		int residentId = 0;

		public OrganizationsForm()
		{
			InitializeComponent();
		}

		public OrganizationsForm(int residentId)
		{
			InitializeComponent();
			this.residentId = residentId;
		}

		public static string ShowDialog(int residentId)
		{
			OrganizationsForm residentForm = new OrganizationsForm(residentId);
			//	this.Show();
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.organizationIdLabel.Text : null;
		}

		private void OrganizationsForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "dormitoryDataSet.Organizations". При необходимости она может быть перемещена или удалена.
			//this.organizationsTableAdapter.Fill(this.dormitoryDataSet.Organizations);
			LoadDataGrid();
		}

		public void LoadDataGrid()
		{
			dataAdapter = new SqlDataAdapter("SELECT * FROM Organizations", sqlConnection);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			organizationsDataGridView.DataSource = dataTable;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			string name = nameTextBox.Text;
			string address = addressTextBox.Text;
			string requisites = requisitesTextBox.Text;

			string sqlExpression = "sp_InsertOrganization";

			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
				command.CommandType = CommandType.StoredProcedure;

				SqlParameter nameParam = new SqlParameter
				{
					ParameterName = "@Name",
					Value = name
				};
				command.Parameters.Add(nameParam);

				SqlParameter addressParam = new SqlParameter
				{
					ParameterName = "@Address",
					Value = address
				};
				command.Parameters.Add(addressParam);

				SqlParameter requisitesParam = new SqlParameter
				{
					ParameterName = "@Requisites",
					Value = requisites
				};
				command.Parameters.Add(requisitesParam);
				command.ExecuteNonQuery();
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				sqlConnection.Close();
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		private void organizationsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTable] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				organizationIdLabel.Text = dataRow[0].ToString();
				nameTextBox.Text = dataRow[1].ToString();
				addressTextBox.Text = dataRow[2].ToString();
				requisitesTextBox.Text = dataRow[3].ToString();
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			Int32.TryParse(idTextBox.Text, out int id);
			string name = nameTextBox.Text;
			string address = addressTextBox.Text;
			string requisites = requisitesTextBox.Text;

			string sqlExpression = "sp_UpdateOrganization";
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
				command.CommandType = CommandType.StoredProcedure;

				SqlParameter idParam = new SqlParameter
				{
					ParameterName = "@Id",
					Value = id
				};
				command.Parameters.Add(idParam);

				SqlParameter nameParam = new SqlParameter
				{
					ParameterName = "@Name",
					Value = name
				};
				command.Parameters.Add(nameParam);

				SqlParameter addressParam = new SqlParameter
				{
					ParameterName = "@Address",
					Value = address
				};
				command.Parameters.Add(addressParam);

				SqlParameter requisitesParam = new SqlParameter
				{
					ParameterName = "@Requisites",
					Value = requisites
				};
				command.Parameters.Add(requisitesParam);

				command.ExecuteNonQuery();
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				sqlConnection.Close();
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			Int32.TryParse(idTextBox.Text, out int id);
			string sqlExpression = "sp_DeleteOrganization";
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
				command.CommandType = CommandType.StoredProcedure;

				SqlParameter IdParam = new SqlParameter
				{
					ParameterName = "@Id",
					Value = id
				};
				command.Parameters.Add(IdParam);
				command.ExecuteNonQuery();
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				sqlConnection.Close();
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
