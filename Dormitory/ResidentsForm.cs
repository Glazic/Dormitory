using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
	// Отвечает за окно жителей
	public partial class ResidentsForm : Form
	{
		SqlConnectionStringBuilder sqlConnectionString;
		DataContext db;
		SqlDataAdapter dataAdapter;
		DataTable dataTable;

		public ResidentsForm(SqlConnectionStringBuilder sqlConnectionString)
		{
			this.sqlConnectionString = sqlConnectionString;
			InitializeComponent();
			db = new DataContext(sqlConnectionString.ConnectionString);
		}

		private void residentsForm_Load(object sender, EventArgs e)
		{
			LoadDataGrid();
		}

		/// <summary>
		/// Открывает окно жителей общежития для выбора. Возвращает идентификатор выбранного жителя.
		/// </summary>
		/// <param name="sqlConnection">Подключение пользователя</param>
		/// <returns>Идентификатор выбранного жителя</returns>
		public static string ShowDialogForNewResident(SqlConnectionStringBuilder sqlConnectionString)
		{
			ResidentsForm residentsForm = new ResidentsForm(sqlConnectionString);
			return residentsForm.ShowDialog() == DialogResult.OK ? residentsForm.residentIdLabel.Text : null;
		}

		/// <summary>
		/// Загружает таблицу жителей
		/// </summary>
		public void LoadDataGrid()
		{
			dataAdapter = new SqlDataAdapter("SELECT ResidentId as [ИД], Surname as [Фамилия], " +
				"Residents.Name as [Имя], Patronymic as [Отчество], PhoneNumber as [Телефон], " +
				"Birthday as [День рожд.], Organizations.Name as [Организация] " +
				"FROM Residents " +
				"LEFT JOIN Organizations ON Residents.OrganizationId = Organizations.OrganizationId", sqlConnectionString.ConnectionString);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			residentsDataGridView.RowTemplate.Height = 30;
			residentsDataGridView.DataSource = dataTable;	
			residentsDataGridView.Columns[0].Width = 50;
			residentsDataGridView.Columns[1].Width = 180;
			residentsDataGridView.Columns[2].Width = 180;
			residentsDataGridView.Columns[3].Width = 180;
			residentsDataGridView.Columns[4].Width = 150;
			residentsDataGridView.Columns[5].Width = 140;
			residentsDataGridView.Columns[6].Width = 150;
			residentsDataGridView.ClearSelection();
		}

		// Обрабатывает нажатие ячейки таблицы для записи идентификатора выбранного жителя
		private void residentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTable] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				residentIdLabel.Text = dataRow[0].ToString();
			}
		}

		// Открывает окно для добавления нового жителя
		private void addButton_Click(object sender, EventArgs e)
		{
			ResidentForm residentForm = new ResidentForm(sqlConnectionString);
			residentForm.ShowDialog();
			LoadDataGrid();
		}

		// Удаляет выбранного жителя
		private void deleteButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранного жителя?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					Int32.TryParse(residentIdLabel.Text, out int residentId);
					if (residentId == 0)
					{
						MessageBox.Show("Выберите жителя");
					}
					else
					{
						SqlConnectionStringBuilder sConnBForOtherServer = new SqlConnectionStringBuilder()
						{
							DataSource = Properties.Settings.Default.userServer2Name,
							InitialCatalog = Properties.Settings.Default.userServer2Database,
							UserID = sqlConnectionString.UserID,
							Password = sqlConnectionString.Password,
						};
						DataContext dbFromOtherServer = new DataContext(sConnBForOtherServer.ConnectionString);
						Resident resident2 = dbFromOtherServer.GetTable<Resident>().FirstOrDefault(r => r.ResidentId == residentId);
						if (resident2 != null)
						{
							dbFromOtherServer.GetTable<Resident>().DeleteOnSubmit(resident2);
						}

						Passport passport2 = dbFromOtherServer.GetTable<Passport>().FirstOrDefault(r => (r.PassportId == resident2.PassportId));
						if (passport2 != null)
						{
							resident2.Passport = passport2;
							dbFromOtherServer.GetTable<Passport>().DeleteOnSubmit(passport2);
						}

						RoomResidents roomResidents2 = dbFromOtherServer.GetTable<RoomResidents>().FirstOrDefault(r => (r.ResidentId == residentId));
						if (roomResidents2 != null)
						{
							dbFromOtherServer.GetTable<RoomResidents>().DeleteOnSubmit(roomResidents2);
						}

						ResidentRooms residentRooms2 = dbFromOtherServer.GetTable<ResidentRooms>()
							.FirstOrDefault(r => (r.ResidentId == residentId && r.DateOfEviction == null));
						if (residentRooms2 != null)
						{
							residentRooms2.DateOfEviction = DateTime.Now;
						}



						db = new DataContext(sqlConnectionString.ConnectionString);
						Resident resident = db.GetTable<Resident>().FirstOrDefault(r => r.ResidentId == residentId);
						if (resident != null)
						{
							db.GetTable<Resident>().DeleteOnSubmit(resident);
						}

						Passport passport = db.GetTable<Passport>().FirstOrDefault(r => (r.PassportId == resident.PassportId));
						if (passport != null)
						{
							resident.Passport = passport;
							db.GetTable<Passport>().DeleteOnSubmit(passport);
						}

						RoomResidents roomResidents = db.GetTable<RoomResidents>().FirstOrDefault(r => (r.ResidentId == residentId));
						if (roomResidents != null)
						{
							db.GetTable<RoomResidents>().DeleteOnSubmit(roomResidents);
						}

						ResidentRooms residentRooms = db.GetTable<ResidentRooms>()
							.FirstOrDefault(r => (r.ResidentId == residentId && r.DateOfEviction == null));
						if (residentRooms != null)
						{
							residentRooms.DateOfEviction = DateTime.Now;
						}

						dbFromOtherServer.SubmitChanges();
						db.SubmitChanges();
						LoadDataGrid();

						HistoryRecordsController.WriteAboutAddDeleteResident(resident, false);
					}
				}
				catch (Exception ex)
				{
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при удалении жителя в deleteButton_Click.");
					MessageBox.Show("Ошибка при удалении жителя.\nВызвано исключение: " + ex.Message);
				}
				finally
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}

		// Открывает окно для редактирования выбранного жителя
		private void changeButton_Click(object sender, EventArgs e)
		{
			Int32.TryParse(residentIdLabel.Text, out int residentId);
			if (residentId == 0)
			{
				MessageBox.Show("Выберите жителя");
			}
			else {
				ResidentForm.ShowDialog(sqlConnectionString, residentId);
				LoadDataGrid();
			}
		}

		// Поиск жителя по введенным в поля фамилии и организации
		private void searchButton_Click(object sender, EventArgs e)
		{
			try
			{
				dataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%' AND [{2}] LIKE '%{3}%'",
					"Фамилия", nameFilterTextBox.Text, "Организация", organizationFilterTextBox.Text);
				residentsDataGridView.ClearSelection();
			}
			catch (Exception ex)
			{
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при поиске жителя в searchButton_Click.");
				MessageBox.Show("Ошибка при поиске жителя.\nВызвано исключение: " + ex.Message);
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

		// Обновление списка жителей, загрузка с другой вахты
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
				updatePassports(sqlConnectionString.ConnectionString);
				updateResidents(sqlConnectionString.ConnectionString);
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка обновления данных организаций в updateButton_Click.");
				MessageBox.Show("Ошибка объединения данных организаций в updateButton_Click.\nВызвано исключение:" + ex.Message);
			}
		}

		// Обновить список жителей, загрузив с другого сервера
		private void updateResidents(string userServerConnectionString)
		{
			using (SqlConnection userServer2Connection = new SqlConnection())
			{
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					SqlConnectionStringBuilder userServer2ConnB = new SqlConnectionStringBuilder()
					{
						DataSource = Properties.Settings.Default.userServer2Name,
						InitialCatalog = Properties.Settings.Default.userServer2Database,
						UserID = LoginForm.UserName,
						Password = LoginForm.Password
					};
					userServer2Connection.ConnectionString = userServer2ConnB.ConnectionString;
					userServer2Connection.Open();
					if (userServer2Connection.State == ConnectionState.Open)
					{
						DataTable updateDataTable = new DataTable("UpdateResidents");
						SqlDataAdapter updateDataAdapter = new SqlDataAdapter("SELECT ResidentId, " +
							"Surname, Name, Patronymic, PhoneNumber, Birthday, Note, PassportId, OrganizationId " +
							"FROM Residents", userServer2Connection);
						updateDataAdapter.Fill(updateDataTable);

						using (SqlConnection sqlConnection = new SqlConnection(userServerConnectionString))
						{
							try
							{
								sqlConnection.Open();
								string tmpTable = "create table #Residents " +
									"(ResidentId int, Surname nvarchar(50), Name nvarchar(50), " +
									"Patronymic nvarchar(50), PhoneNumber nvarchar(50), Birthday datetime, " +
									"Note nvarchar(100), PassportId int, OrganizationId int)";
								SqlCommand cmd = new SqlCommand(tmpTable, sqlConnection);
								cmd.ExecuteNonQuery();
								using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection))
								{
									bulkCopy.ColumnMappings.Add("ResidentId", "ResidentId");
									bulkCopy.ColumnMappings.Add("Surname", "Surname");
									bulkCopy.ColumnMappings.Add("Name", "Name");
									bulkCopy.ColumnMappings.Add("Patronymic", "Patronymic");
									bulkCopy.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
									bulkCopy.ColumnMappings.Add("Birthday", "Birthday");
									bulkCopy.ColumnMappings.Add("Note", "Note");
									bulkCopy.ColumnMappings.Add("PassportId", "PassportId");
									bulkCopy.ColumnMappings.Add("OrganizationId", "OrganizationId");
									bulkCopy.DestinationTableName = "#Residents";
									try
									{
										bulkCopy.WriteToServer(updateDataTable);
									}
									catch (Exception ex)
									{
										SystemSounds.Exclamation.Play();
										HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка копирования данных во временную таблицу #Residents.");
										MessageBox.Show("Ошибка копирования данных во временную таблицу #Residents.\nВызвано исключение:" + ex.Message);
									}
								}
								cmd.CommandText = "SET IDENTITY_INSERT Residents ON";
								cmd.ExecuteNonQuery();

								string mergeSql = "merge into Residents as Target " +
									"using #Residents as Source " +
									"on " +
									"Target.ResidentId=Source.ResidentId " +
									"when matched then " +
										"update set Target.Surname=Source.Surname, Target.Name=Source.Name, " +
										"Target.Patronymic=Source.Patronymic, Target.PhoneNumber=Source.PhoneNumber, " +
										"Target.Birthday=Source.Birthday, Target.Note=Source.Note, " +
										"Target.PassportId=Source.PassportId, Target.OrganizationId=Source.OrganizationId " +
									"when not matched then " +
										"insert (ResidentId, Surname, Name, Patronymic, PhoneNumber, Birthday, Note, PassportId, OrganizationId) " +
										"values (Source.ResidentId, Source.Surname, Source.Name, Source.Patronymic, Source.PhoneNumber, Source.Birthday, Source.Note, Source.PassportId, Source.OrganizationId) " +
									"when not matched by Source then delete; ";
								cmd.CommandText = mergeSql;
								cmd.ExecuteNonQuery();

								cmd.CommandText = "SET IDENTITY_INSERT Residents OFF";
								cmd.ExecuteNonQuery();

								cmd.CommandText = "drop table #Residents";
								cmd.ExecuteNonQuery();
							}
							catch (Exception ex)
							{
								SystemSounds.Exclamation.Play();
								HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка объединения данных организаций из двух таблиц.");
								MessageBox.Show("Ошибка объединения данных жителей из двух таблиц.\nВызвано исключение: " + ex.Message);
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
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка обновления данных жителей в updateResidents.");
					MessageBox.Show("Ошибка обновления данных жителей в updateResidents.\nВызвано исключение:" + ex.Message);
				}
				finally
				{
					userServer2Connection.Close();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}

		// Обновить список паспортов, загрузив с другого сервера
		private void updatePassports(string userServerConnectionString)
		{
			using (SqlConnection userServer2Connection = new SqlConnection())
			{
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					SqlConnectionStringBuilder userServer2ConnB = new SqlConnectionStringBuilder()
					{
						DataSource = Properties.Settings.Default.userServer2Name,
						InitialCatalog = Properties.Settings.Default.userServer2Database,
						UserID = LoginForm.UserName,
						Password = LoginForm.Password
					};
					userServer2Connection.ConnectionString = userServer2ConnB.ConnectionString;
					userServer2Connection.Open();
					if (userServer2Connection.State == ConnectionState.Open)
					{
						DataTable updateDataTable = new DataTable("UpdatePassports");
						SqlDataAdapter updateDataAdapter = new SqlDataAdapter("SELECT PassportId, " +
							"Number, Series, Registration, DateOfIssue, Authority " +
							"FROM Passports", userServer2Connection);
						updateDataAdapter.Fill(updateDataTable);

						using (SqlConnection sqlConnection = new SqlConnection(userServerConnectionString))
						{
							try
							{
								sqlConnection.Open();
								string tmpTable = "create table #Passports " +
									"(PassportId int, Number nvarchar(20), Series nvarchar(20), " +
									"Registration nvarchar(100), DateOfIssue datetime, Authority nvarchar(100))";
								SqlCommand cmd = new SqlCommand(tmpTable, sqlConnection);
								cmd.ExecuteNonQuery();
								using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection))
								{
									bulkCopy.ColumnMappings.Add("PassportId", "PassportId");
									bulkCopy.ColumnMappings.Add("Number", "Number");
									bulkCopy.ColumnMappings.Add("Series", "Series");
									bulkCopy.ColumnMappings.Add("Registration", "Registration");
									bulkCopy.ColumnMappings.Add("DateOfIssue", "DateOfIssue");
									bulkCopy.ColumnMappings.Add("Authority", "Authority");
									bulkCopy.DestinationTableName = "#Passports";
									try
									{
										bulkCopy.WriteToServer(updateDataTable);
									}
									catch (Exception ex)
									{
										SystemSounds.Exclamation.Play();
										HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка копирования данных во временную таблицу #Residents.");
										MessageBox.Show("Ошибка копирования данных во временную таблицу #Residents.\nВызвано исключение:" + ex.Message);
									}
								}

								cmd.CommandText = "SET IDENTITY_INSERT Passports ON";
								cmd.ExecuteNonQuery();

								string mergeSql = "merge into Passports as Target " +
									"using #Passports as Source " +
									"on " +
									"Target.PassportId=Source.PassportId " +
									"when matched then " +
										"update set Target.Number=Source.Number, Target.Series=Source.Series, " +
										"Target.Registration=Source.Registration, Target.DateOfIssue=Source.DateOfIssue, " +
										"Target.Authority=Source.Authority " +
									"when not matched then " +
										"insert (PassportId, Number, Series, Registration, DateOfIssue, Authority) " +
										"values (Source.PassportId, Source.Number, Source.Series, Source.Registration, Source.DateOfIssue, Source.Authority) " +
									"when not matched by Source then delete; ";
								cmd.CommandText = mergeSql;
								cmd.ExecuteNonQuery();

								cmd.CommandText = "SET IDENTITY_INSERT Passports OFF;";
								cmd.ExecuteNonQuery();

								cmd.CommandText = "drop table #Passports";
								cmd.ExecuteNonQuery();
							}
							catch (Exception ex)
							{
								SystemSounds.Exclamation.Play();
								HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка объединения данных паспортов из двух таблиц.");
								MessageBox.Show("Ошибка объединения данных паспортов из двух таблиц.\nВызвано исключение: " + ex.Message);
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
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка обновления данных паспортов в updatePassports.");
					MessageBox.Show("Ошибка обновления данных паспортов в updatePassports.\nВызвано исключение:" + ex.Message);
				}
				finally
				{
					userServer2Connection.Close();
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}
	}
}
