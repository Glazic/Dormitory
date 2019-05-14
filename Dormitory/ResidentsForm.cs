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
	public partial class ResidentsForm : Form
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		SqlCommand cmd;
		SqlDataAdapter dataAdapter;
		DataTable dataTable;
		int roomId;

		public ResidentsForm()
		{
			InitializeComponent();
		}

		private void residentsForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "dormitoryDataSet.Organizations". При необходимости она может быть перемещена или удалена.
			//this.organizationsTableAdapter.Fill(this.dormitoryDataSet.Organizations);
			LoadDataGrid();
		}

		public ResidentsForm(int roomId) : this()
		{
			this.roomId = roomId;
		}

		public static string ShowDialogForNewResident(int roomId)
		{
			ResidentsForm residentsForm = new ResidentsForm(roomId);
			//	this.Show();
			return residentsForm.ShowDialog() == DialogResult.OK ? residentsForm.residentIdLabel.Text : null;
		}

		public void LoadDataGrid()
		{
			dataAdapter = new SqlDataAdapter("SELECT ResidentId as [ИД], Surname as [Фамилия], " +
				"Residents.Name as [Имя], Patronymic as [Отчество], PhoneNumber as [Телефон], " +
				"Birthday as [День рожд.], Organizations.Name as [Организация] " +
				"FROM Residents " +
				"LEFT JOIN Organizations ON Residents.ResidentId = Organizations.OrganizationId", sqlConnection);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			residentsDataGridView.DataSource = dataTable;
			residentsDataGridView.Columns[0].Width = 50;
			residentsDataGridView.Columns[1].Width = 120;
			residentsDataGridView.Columns[2].Width = 120;
			residentsDataGridView.Columns[3].Width = 120;
			residentsDataGridView.Columns[4].Width = 100;
			residentsDataGridView.Columns[5].Width = 80;
			residentsDataGridView.Columns[6].Width = 80;
			residentsDataGridView.ClearSelection();
		}

		private void residentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTable] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				residentIdLabel.Text = dataRow[0].ToString();
				//nameTextBox.Text = dataRow[1].ToString();
				//addressTextBox.Text = dataRow[2].ToString();
				//requisitesTextBox.Text = dataRow[3].ToString();
			}
		}

		private void settleButton_Click(object sender, EventArgs e)
		{

		}

		private void addButton_Click(object sender, EventArgs e)
		{
			ResidentForm residentForm = new ResidentForm();
			residentForm.ShowDialog();
			LoadDataGrid();
		}

		private void nameFilterTextBox_TextChanged(object sender, EventArgs e)
		{
			dataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Фамилия", nameFilterTextBox.Text);
			residentsDataGridView.ClearSelection();
		}

		private void organizationFilterTextBox_TextChanged(object sender, EventArgs e)
		{
			dataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Организация", organizationFilterTextBox.Text);
			residentsDataGridView.ClearSelection();
		}
	}
}
