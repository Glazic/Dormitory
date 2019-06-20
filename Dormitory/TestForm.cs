using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Dormitory
{
	public partial class TestForm : Form
	{
		//private SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		//DataContext db;
		//private string connectionString;
		//private string fileName = "test.sdf";
		//private string password = "test";
		SqlDataAdapter dataAdapter;
		SqlConnection sqlConnection = new SqlConnection($"Data Source=WATCH1\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		DataTable dataTable = new DataTable();

		public TestForm()
		{
			InitializeComponent();
		//	db = new DataContext(sqlConnection);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadDataGrid();
			//SqlCeEngine en = new SqlCeEngine(connectionString);
			//en.CreateDatabase();
		}

		public void LoadDataGrid()
		{
			try
			{
				// sqlConnection.ConnectionString = $"Data Source=WATCH1\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True";
				// sqlConnection.ConnectionString = $"Data Source={textBox1.Text};Initial Catalog=Dormitory;User ID=zaq;Password=zaq";
					sqlConnection.ConnectionString = $"Data Source=WATCH2\\SQLEXPRESS;Initial Catalog=Dormitory;User ID=zaq;Password=zaq";
				sqlConnection.Open();
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlConnection.Close();

			}
			//dataAdapter = databaseController.SelectAllOrganizations();
		
		}
	}
}
