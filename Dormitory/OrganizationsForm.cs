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
	// Отвечает за окно организаций
	public partial class OrganizationsForm : Form
	{
		SqlConnectionStringBuilder sqlConnectionString;
		DataContext db;
		SqlDataAdapter dataAdapter;
		DataTable dataTable = new DataTable("Organizations");
		int residentId = 0;

		public OrganizationsForm(SqlConnectionStringBuilder sqlConnectionString)
		{
			InitializeComponent();
			this.sqlConnectionString = sqlConnectionString;
			db = new DataContext(this.sqlConnectionString.ConnectionString);
		}

		public OrganizationsForm(SqlConnectionStringBuilder sqlConnectionString, int residentId) : this(sqlConnectionString)
		{
			this.residentId = residentId;
		}
		/// <summary>
		/// Открытие окна организаций для выбора
		/// </summary>
		/// <param name="sqlConnection">Подключение пользователя</param>
		/// <param name="residentId">Идентификатор пользователя</param>
		/// <returns></returns>
		public static string ShowDialog(SqlConnectionStringBuilder sqlConnectionString, int residentId)
		{
			OrganizationsForm residentForm = new OrganizationsForm(sqlConnectionString, residentId);
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.organizationIdLabel.Text : null;
		}
		
		private void OrganizationsForm_Load(object sender, EventArgs e)
		{
			LoadDataGrid();
		}
		/// <summary>
		/// Загрузка таблицы организаций
		/// </summary>
		public void LoadDataGrid()
		{
			dataAdapter = new SqlDataAdapter("SELECT OrganizationId as [ИД], " +
				"Name as [Название], Address as [Адрес] " +
				"FROM Organizations", sqlConnectionString.ConnectionString);
			dataTable.Clear();
			dataAdapter.Fill(dataTable);
			organizationsDataGridView.DataSource = dataTable;
			organizationsDataGridView.Columns[0].Width = 50;
			organizationsDataGridView.Columns[1].Width = 440;
			organizationsDataGridView.Columns[2].Width = 280;
			organizationsDataGridView.ClearSelection();
		}

		// Обработка нажатия ячейки таблицы для идентификатора организации
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

		// Обновить список организаций, загрузив с сервера администратора
		private void updateOrganizations(string userServerConnectionString)
		{
			using (SqlConnection adminConnection = new SqlConnection())
			{
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

						using (SqlConnection sqlConnection = new SqlConnection(userServerConnectionString))
						{
							try
							{
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
										HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка копирования данных во временную таблицу #Organizations.");
										MessageBox.Show("Ошибка копирования данных во временную таблицу #Organizations.\nВызвано исключение:" + ex.Message);
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
							}
							catch (Exception ex)
							{
								SystemSounds.Exclamation.Play();
								HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка объединения данных организаций из двух таблиц.");
								MessageBox.Show("Ошибка объединения данных организаций из двух таблиц.\nВызвано исключение: " + ex.Message);
							}
							finally
							{
								sqlConnection.Close();
							}
						}
					}
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка обновления данных организаций в updateOrganizations.");
					MessageBox.Show("Ошибка обновления данных организаций в updateOrganizations.\nВызвано исключение:" + ex.Message);
				}
				finally
				{
					adminConnection.Close();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			try
			{
				SqlConnectionStringBuilder sConnBForOtherServer = new SqlConnectionStringBuilder()
				{
					DataSource = Properties.Settings.Default.userServer2Name,
					InitialCatalog = Properties.Settings.Default.userServer2Database,
					UserID = sqlConnectionString.UserID,
					Password = sqlConnectionString.Password,
				};
				updateOrganizations(sConnBForOtherServer.ConnectionString);
				updateOrganizations(sqlConnectionString.ConnectionString);
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка обновления данных организаций в updateButton_Click.");
				MessageBox.Show("Ошибка объединения данных организаций в updateButton_Click.\nВызвано исключение:" + ex.Message);
			}
		}

		// Закрытие окна с помощью клавиши Esc
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		// Поиск организации по названию
		private void searchButton_Click(object sender, EventArgs e)
		{
			try
			{
				dataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Название", nameFilterTextBox.Text);
				organizationsDataGridView.ClearSelection();
			}
			catch (Exception ex)
			{
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при поиске организации в searchButton_Click.");
				MessageBox.Show("Ошибка при поиске организации в searchButton_Click.\nВызвано исключение:" + ex.Message);
			}
		}
	}
}
