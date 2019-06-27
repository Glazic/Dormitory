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
using System.Media;

namespace Dormitory
{
	public partial class OrganizationsForm : Form
	{
		SqlConnection sqlConnection;
		DataContext db;
		SqlDataAdapter dataAdapter;
		DataTable dataTable = new DataTable("Organizations");
		int residentId = 0;

		public OrganizationsForm(SqlConnection sqlConnection)
		{
			InitializeComponent();
			this.sqlConnection = sqlConnection;
			db = new DataContext(this.sqlConnection);
		}

		public OrganizationsForm(SqlConnection sqlConnection, int residentId) : this(sqlConnection)
		{
			this.residentId = residentId;
		}

		public static string ShowDialog(SqlConnection sqlConnection, int residentId)
		{
			OrganizationsForm residentForm = new OrganizationsForm(sqlConnection, residentId);
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.organizationIdLabel.Text : null;
		}

		private void OrganizationsForm_Load(object sender, EventArgs e)
		{
			LoadDataGrid();
		}

		public void LoadDataGrid()
		{
			dataAdapter = new SqlDataAdapter("SELECT OrganizationId as [ИД], " +
				"Name as [Название], Address as [Адрес] " +
				"FROM Organizations", sqlConnection);
			dataTable.Clear();
			dataAdapter.Fill(dataTable);
			organizationsDataGridView.DataSource = dataTable;
			organizationsDataGridView.Columns[0].Width = 50;
			organizationsDataGridView.Columns[1].Width = 440;
			organizationsDataGridView.Columns[2].Width = 280;
			organizationsDataGridView.ClearSelection();
		}

		private void organizationsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTable] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				organizationIdLabel.Text = dataRow[0].ToString();
				nameTextBox.Text = dataRow[1].ToString();
				addressTextBox.Text = dataRow[2].ToString();
			}
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			SqlConnection adminConnection = new SqlConnection();
			try
			{
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SqlConnectionStringBuilder adminConnB = new SqlConnectionStringBuilder()
				{
					DataSource = Properties.Settings.Default.adminServerName,
					InitialCatalog = Properties.Settings.Default.adminServerDatabase,
					UserID = LoginForm.UserName,
					Password = LoginForm.Password
				};
				adminConnection.ConnectionString = adminConnB.ConnectionString;
				adminConnection.Open();
				if (adminConnection.State == ConnectionState.Open)
				{
					DataTable updateDataTable = new DataTable("UpdateOrganizations");
					SqlDataAdapter updateDataAdapter = new SqlDataAdapter("SELECT OrganizationId as [ИД], " +
						"Name as [Название], PhysicAddress as [Адрес] " +
						"FROM Organizations", adminConnection);
					updateDataAdapter.Fill(updateDataTable);

					sqlConnection.Open();
					string tmpTable = "create table #Organizations " +
						"(OrganizationId int, Name nvarchar(100), Address nvarchar(100))";
					SqlCommand cmd = new SqlCommand(tmpTable, sqlConnection);
					cmd.ExecuteNonQuery();
					using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection))
					{
						bulkCopy.ColumnMappings.Add("[ИД]", "OrganizationId");
						bulkCopy.ColumnMappings.Add("[Название]", "Name");
						bulkCopy.ColumnMappings.Add("[Адрес]", "Address");
						bulkCopy.DestinationTableName = "#Organizations";
						try
						{
							bulkCopy.WriteToServer(updateDataTable);
						}
						catch (Exception ex)
						{
							SystemSounds.Exclamation.Play();
							MessageBox.Show("Ошибка записи данных с сервера на сервер. \n" + ex.Message);
						}
					}
					string mergeSql = "merge into Organizations as Target " +
						"using #Organizations as Source " +
						"on " +
						"Target.OrganizationId=Source.OrganizationId " +
						"when matched then " +
							"update set Target.Name=Source.Name, Target.Address=Source.Address " +
						"when not matched then " +
							"insert (OrganizationId,Name,Address) values (Source.OrganizationId,Source.Name,Source.Address) " +
						"when not matched by Source then delete; ";
					cmd.CommandText = mergeSql;
					cmd.ExecuteNonQuery();

					cmd.CommandText = "drop table #Organizations";
					cmd.ExecuteNonQuery();

					organizationsDataGridView.DataSource = updateDataTable;
					organizationsDataGridView.ClearSelection();
				}
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Ошибка обновления данных организаций. \n" + ex.Message);
			}
			finally
			{
				adminConnection.Close();
				sqlConnection.Close();
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

		private void nameFilterTextBox_TextChanged(object sender, EventArgs e)
		{
			dataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Название", nameFilterTextBox.Text);
			organizationsDataGridView.ClearSelection();
		}
	}
}
