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
				"Name as [Название], Address as [Адрес] " +
				"FROM Organizations", sqlConnection);
			dataTable.Clear();
			dataAdapter.Fill(dataTable);
			organizationsDataGridView.DataSource = dataTable;
			organizationsDataGridView.Columns[0].Width = 50;
			organizationsDataGridView.Columns[1].Width = 230;
			organizationsDataGridView.Columns[2].Width = 350;
			organizationsDataGridView.ClearSelection();
		}

		private void organizationsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTable] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				organizationIdLabel.Text = dataRow[0].ToString();
				nameTextBox.Text = dataRow[1].ToString();
				//addressTextBox.Text = dataRow[2].ToString();
			}
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			SqlConnection testConnection = new SqlConnection();
			try
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
				{
					DataSource = Properties.Settings.Default.adminServerName,
					InitialCatalog = Properties.Settings.Default.adminServerDatabase,
					UserID = LoginForm.UserName,
					Password = LoginForm.Password
				};
				testConnection.ConnectionString = sConnB.ConnectionString;
				testConnection.Open();
				if (testConnection.State == ConnectionState.Open)
				{
					dataAdapter = new SqlDataAdapter("SELECT OrganizationId as [ИД], " +
						"Name as [Название], PhysicAddress as [Адрес] " +
						"FROM Organizations", testConnection);
					dataTable.Clear();
					dataAdapter.Fill(dataTable);
					organizationsDataGridView.DataSource = dataTable;
					organizationsDataGridView.Columns[0].Width = 50;
					organizationsDataGridView.Columns[1].Width = 200;
					organizationsDataGridView.Columns[2].Width = 200;
					organizationsDataGridView.ClearSelection();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
	}
}
