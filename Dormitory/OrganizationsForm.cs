using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace Dormitory
{
	public partial class OrganizationsForm : Form
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		DataContext db;
		//	DatabaseController databaseController;
		SqlDataAdapter dataAdapter;
		DataTable dataTable = new DataTable();
		int residentId = 0;

		public OrganizationsForm()
		{
			InitializeComponent();
			db = new DataContext(sqlConnection);
			//		databaseController = new DatabaseController();
		}

		public OrganizationsForm(int residentId) : this()
		{
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
			LoadDataGrid();
		}

		public void LoadDataGrid()
		{
			//dataAdapter = databaseController.SelectAllOrganizations();
			dataAdapter = new SqlDataAdapter("SELECT OrganizationId as [ИД], " +
				"Name as [Название], Address as [Адрес], Requisites as [Реквизиты] " +
				"FROM Organizations", sqlConnection);
			dataTable.Clear();
			dataAdapter.Fill(dataTable);
			organizationsDataGridView.DataSource = dataTable;
			organizationsDataGridView.Columns[0].Width = 50;
			organizationsDataGridView.Columns[1].Width = 200;
			organizationsDataGridView.Columns[2].Width = 200;
			organizationsDataGridView.Columns[3].Width = 200;
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

		private void addButton_Click(object sender, EventArgs e)
		{
			string name = nameTextBox.Text;
			string address = addressTextBox.Text;
			string requisites = requisitesTextBox.Text;

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(requisites))
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}

			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите добавить данную организацию?\n" +
				$"Название: {name}. \nАдрес: {address}. \nРеквезиты: {requisites}", "Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				Organization organization = new Organization
				{
					Name = name,
					Address = address,
					Requisites = requisites
				};

				try
				{
					db.GetTable<Organization>().InsertOnSubmit(organization);
					db.SubmitChanges();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					sqlConnection.Close();
				}
				//	databaseController.InsertOrganization(name, address, requisites);
				LoadDataGrid();
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			string name = nameTextBox.Text;
			string address = addressTextBox.Text;
			string requisites = requisitesTextBox.Text;

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(requisites))
			{
				MessageBox.Show("Заполните все поля!");
				return;
			}

			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите сохранить данные изменения?\n" +
				$"Название: {name}. \nАдрес: {address}. \nРеквезиты: {requisites}", "Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				Int32.TryParse(organizationIdLabel.Text, out int id);

				try
				{
					Organization organization = db.GetTable<Organization>().SingleOrDefault(o => o.OrganizationId == id);
					organization.Name = name;
					organization.Address = address;
					organization.Requisites = requisites;
					db.SubmitChanges();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					sqlConnection.Close();
				}
				//databaseController.UpdateOrganization(name, address, requisites, id);
				LoadDataGrid();
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, " +
				"что хотите удалить выбранную организацию?", "Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				Int32.TryParse(organizationIdLabel.Text, out int id);

				try
				{
					Organization organization = db.GetTable<Organization>().SingleOrDefault(o => o.OrganizationId == id);

					db.GetTable<Organization>().DeleteOnSubmit(organization);
					db.SubmitChanges();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					sqlConnection.Close();
				}
				//	databaseController.DeleteOrganization(id);
				LoadDataGrid();
			}
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
