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
using System.Transactions;
using System.Windows.Forms;

namespace Dormitory
{
	// Отвечает за окно жителя
	public partial class ResidentForm : Form
	{
		SqlConnectionStringBuilder sqlConnectionString;
		DataContext db;
		SqlDataAdapter dataAdapter;
		DataTable dataTable;
		int residentId = 0;
		int roomId = 0;

		public ResidentForm(SqlConnectionStringBuilder sqlConnectionString)
		{
			InitializeComponent();
			saveButton.Enabled = false;
			evictButton.Enabled = false;
			this.sqlConnectionString = sqlConnectionString;
			db = new DataContext(this.sqlConnectionString.ConnectionString);
		}

		public ResidentForm(SqlConnectionStringBuilder sqlConnectionString, int residentId) : this(sqlConnectionString)
		{
			addButton.Enabled = false;
			saveButton.Enabled = true;
			evictButton.Enabled = false;
			residentIdLabel.Text = residentId.ToString();
			this.residentId = residentId;
			LoadData();
			LoadDataGrid();
		}

		public ResidentForm(SqlConnectionStringBuilder sqlConnectionString, int residentId, int roomId) : this(sqlConnectionString)
		{
			addButton.Enabled = false;
			saveButton.Enabled = true;
			evictButton.Enabled = true;
			residentIdLabel.Text = residentId.ToString();
			roomIdLabel.Text = roomId.ToString();
			this.residentId = residentId;
			this.roomId = roomId;
			LoadData();
			LoadDataGrid();
		}

		/// <summary>
		/// Открывает окно с информацией о выбранном жителе
		/// </summary>
		/// <param name="sqlConnection">Подключение пользователя</param>
		/// <param name="residentId">Идентификатор жителя</param>
		/// <returns></returns>
		public static string ShowDialog(SqlConnectionStringBuilder sqlConnectionString, int residentId)
		{
			ResidentForm residentForm = new ResidentForm(sqlConnectionString, residentId);
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.nameLabel.Text : "";
		}

		/// <summary>
		/// Открывает окно с информацией о выбранном жителе с возможностью выселить из комнаты
		/// </summary>
		/// <param name="sqlConnection">Подключение пользователя</param>
		/// <param name="residentId">Идентификатор жителя</param>
		/// <param name="roomId">Идентификатор коматы</param>
		/// <returns></returns>
		public static string ShowDialogForOldResident(SqlConnectionStringBuilder sqlConnectionString, int residentId, int roomId)
		{
			ResidentForm residentForm = new ResidentForm(sqlConnectionString, residentId, roomId);
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.nameLabel.Text : "";
		}

		/// <summary>
		/// Загружает всю информацию о жителе в таблицы
		/// </summary>
		public void LoadDataGrid()
		{
			LoadLivingDataGridView();
			LoadRentDataGridView();
			LoadRentThings();
		}

		/// <summary>
		/// Загружает информацию о проживании
		/// </summary>
		private void LoadLivingDataGridView()
		{
			dataAdapter = new SqlDataAdapter("SELECT SectionNumber AS [Секция], " +
				"Number AS [Комната], CashPayment as [Оплата], BedClothes as [Постельное], " +
				"SettlementDate as [Заселение], DateOfEviction as [Выселение]" +
				"FROM View_ResidentRooms " +
				$"WHERE ResidentId = {residentId}", sqlConnectionString.ConnectionString);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			livingDataGridView.DataSource = dataTable;
			livingDataGridView.Columns[0].Width = 55;
			livingDataGridView.Columns[1].Width = 65;
			livingDataGridView.Columns[2].Width = 95;
			livingDataGridView.Columns[3].Width = 95;
			livingDataGridView.Columns[4].Width = 160;
			livingDataGridView.Columns[5].Width = 160;
		}

		/// <summary>
		/// Загружает информацию о прокате вещей
		/// </summary>
		private void LoadRentDataGridView()
		{
			dataAdapter = new SqlDataAdapter("SELECT RentThings.Name AS [Прокат], " +
				"StartRentDate AS [Начало проката], EndRentDate AS [Конец проката] " +
				"FROM ResidentRoomsRentThings " +
				"LEFT JOIN ResidentRooms " +
					"ON ResidentRoomsRentThings.ResidentRoomsId = ResidentRooms.ResidentRoomsId " +
				"LEFT JOIN RentThings " +
					"ON ResidentRoomsRentThings.RentThingId = RentThings.RentThingId " +
				$"WHERE ResidentId = {residentId}", sqlConnectionString.ConnectionString);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			rentDataGridView.DataSource = dataTable;
			rentDataGridView.Columns[0].Width = 210;
			rentDataGridView.Columns[1].Width = 200;
			rentDataGridView.Columns[2].Width = 200;
		}

		/// <summary>
		/// Загружает список вещей для проката
		/// </summary>
		private void LoadRentThings()
		{
			Table<RentThing> rentThings = db.GetTable<RentThing>();
			foreach (var thing in rentThings)
			{
				rentThingsComboBox.Items.Add(thing.Name);
			}
		}
	
		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Добавление нового жителя
		private void addButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите добавить данного жителя?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				if (isAllFieldsValid() == false)
				{
					return;
				}
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					// Для сброса контекста, если была попытка ввода нового значения
					db = new DataContext(sqlConnectionString.ConnectionString);

					string surname = surnameTextBox.Text;
					string name = nameTextBox.Text;
					string patronymic = patronymicTextBox.Text;
					string phoneNumber = phoneNumberTextBox.Text;
					DateTime? birthday = birthdayDateTimePicker.NullableValue();
					string passportSeries = passportSeriesTextBox.Text;
					string passportNumber = passportNumberTextBox.Text;
					string passportRegistration = passportRegistrationTextBox.Text;
					string note = noteTextBox.Text;
					DateTime passportDateOfIssue = passportDateOfIssueDateTimePicker.Value.Date;
					string passportAuthority = passportAuthorityTextBox.Text;

					int organizationId = Int32.Parse(organizationIdLabel.Text);
					Organization organization = db.GetTable<Organization>().SingleOrDefault(r => r.OrganizationId == organizationId);

					Passport passport = new Passport
					{
						Series = passportSeries,
						Number = passportNumber,
						Registration = passportRegistration,
						DateOfIssue = passportDateOfIssue,
						Authority = passportAuthority
					};
					db.GetTable<Passport>().InsertOnSubmit(passport);

					Resident resident = new Resident
					{
						Surname = surname,
						Name = name,
						Patronymic = patronymic,
						PhoneNumber = phoneNumber,
						Birthday = birthday,
						Note = note,
						Passport = passport,
						Organization = organization,
					};
					db.GetTable<Resident>().InsertOnSubmit(resident);


					SqlConnectionStringBuilder sConnBForOtherServer = new SqlConnectionStringBuilder()
					{
						DataSource = Properties.Settings.Default.userServer2Name,
						InitialCatalog = Properties.Settings.Default.userServer2Database,
						UserID = sqlConnectionString.UserID,
						Password = sqlConnectionString.Password,
					};
					DataContext dbFromOtherServer = new DataContext(sConnBForOtherServer.ConnectionString);
					Organization organization2 = dbFromOtherServer.GetTable<Organization>().SingleOrDefault(r => r.OrganizationId == organizationId);

					Passport passport2 = new Passport
					{
						Series = passportSeries,
						Number = passportNumber,
						Registration = passportRegistration,
						DateOfIssue = passportDateOfIssue,
						Authority = passportAuthority
					};
					dbFromOtherServer.GetTable<Passport>().InsertOnSubmit(passport2);

					Resident resident2 = new Resident
					{
						Surname = surname,
						Name = name,
						Patronymic = patronymic,
						PhoneNumber = phoneNumber,
						Birthday = birthday,
						Note = note,
						Passport = passport2,
						Organization = organization2,
					};
					dbFromOtherServer.GetTable<Resident>().InsertOnSubmit(resident2);
					dbFromOtherServer.SubmitChanges();

					db.SubmitChanges();
					SystemSounds.Beep.Play();
					MessageBox.Show("Успешно добавлен!");
					HistoryRecordsController.WriteAboutAddDeleteResident(resident, true);
					Close();
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при добавлении жителя.");
					MessageBox.Show("Ошибка при добавлении жителя.\nВызвано исключение: " + ex.Message);
				}
				finally
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}

		// Сохранение информации о жителе
		private void saveButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите сохранить изменения?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				if (isAllFieldsValid() == false)
				{
					return;
				}
				try
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					db = new DataContext(sqlConnectionString.ConnectionString);
					Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
					Resident oldResident = resident.ShallowCopy();
					int organizationId = Int32.Parse(organizationIdLabel.Text);
					resident.Surname = surnameTextBox.Text;
					resident.Name = nameTextBox.Text;
					resident.Patronymic = patronymicTextBox.Text;
					resident.PhoneNumber = phoneNumberTextBox.Text;
					resident.Birthday = birthdayDateTimePicker.NullableValue();
					resident.Note = noteTextBox.Text;
					resident.Organization = db.GetTable<Organization>().SingleOrDefault(r => r.OrganizationId == organizationId);

					Passport passport = db.GetTable<Passport>().SingleOrDefault(p => p.PassportId == resident.PassportId);
					oldResident.Passport = passport.ShallowCopy();
					passport.Number = passportNumberTextBox.Text;
					passport.Series = passportSeriesTextBox.Text;
					passport.Registration = passportRegistrationTextBox.Text;
					passport.DateOfIssue = passportDateOfIssueDateTimePicker.Value.Date;
					passport.Authority = passportAuthorityTextBox.Text;


					SqlConnectionStringBuilder sConnBForOtherServer = new SqlConnectionStringBuilder()
					{
						DataSource = Properties.Settings.Default.userServer2Name,
						InitialCatalog = Properties.Settings.Default.userServer2Database,
						UserID = sqlConnectionString.UserID,
						Password = sqlConnectionString.Password,
					};
					DataContext dbFromOtherServer = new DataContext(sConnBForOtherServer.ConnectionString);
					Resident resident2 = dbFromOtherServer.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
					resident2.Surname = surnameTextBox.Text;
					resident2.Name = nameTextBox.Text;
					resident2.Patronymic = patronymicTextBox.Text;
					resident2.PhoneNumber = phoneNumberTextBox.Text;
					resident2.Birthday = birthdayDateTimePicker.NullableValue();
					resident2.Note = noteTextBox.Text;
					resident2.Organization = dbFromOtherServer.GetTable<Organization>().SingleOrDefault(r => r.OrganizationId == organizationId);

					Passport passport2 = dbFromOtherServer.GetTable<Passport>().SingleOrDefault(p => p.PassportId == resident2.PassportId);
					passport2.Number = passportNumberTextBox.Text;
					passport2.Series = passportSeriesTextBox.Text;
					passport2.Registration = passportRegistrationTextBox.Text;
					passport2.DateOfIssue = passportDateOfIssueDateTimePicker.Value.Date;
					passport2.Authority = passportAuthorityTextBox.Text;
					dbFromOtherServer.SubmitChanges();

					db.SubmitChanges();
					SystemSounds.Beep.Play();
					MessageBox.Show("Успешно сохранено!");

					HistoryRecordsController.WriteAboutEditResident(oldResident, resident);
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при сохранении изменений жителя.");
					MessageBox.Show("Ошибка при сохранении изменений. \nВызвано исключение: " + ex.Message);
				}
				finally
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				}
			}
		}

		// Открытие окна оргранизаций для выбора организации
		private void organizationButton_Click(object sender, EventArgs e)
		{
			string value = OrganizationsForm.ShowDialog(sqlConnectionString, residentId);
			if (value != null)
			{
				Int32.TryParse(value, out int organizationId);
				Organization organization = db.GetTable<Organization>().SingleOrDefault(o => o.OrganizationId == organizationId);
				if (organization != null)
				{
					organizationIdLabel.Text = organizationId.ToString();
					organizationTextBox.Text = organization.Name;
				}
			}
		}

		// Выселение жителя
		private void evictButton_Click(object sender, EventArgs e)
		{
			EvictResident(roomId, residentId);
			LoadLivingDataGridView();
		}

		/// <summary>
		/// Отвечает за выселения жителя из комнаты
		/// </summary>
		/// <param name="roomId">Идентификатор комнаты</param>
		/// <param name="residentId">Идентификатор жителя</param>
		private void EvictResident(int roomId, int residentId)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите выселить данного жителя?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					Resident resident = db.GetTable<Resident>().FirstOrDefault(r => r.ResidentId == residentId);
					RoomResidents roomResidents = db.GetTable<RoomResidents>().FirstOrDefault(r => (r.ResidentId == residentId && r.RoomId == roomId));
					db.GetTable<RoomResidents>().DeleteOnSubmit(roomResidents);
					ResidentRooms residentRooms = db.GetTable<ResidentRooms>()
						.FirstOrDefault(r => (r.ResidentId == residentId && r.RoomId == roomId && r.DateOfEviction == null));
					residentRooms.DateOfEviction = DateTime.Now;
					db.SubmitChanges();
					SystemSounds.Beep.Play();
					MessageBox.Show("Житель успешно выселен!");

					HistoryRecordsController.WriteAboutSettlement(residentRooms, false);
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при выселении жителя.");
					MessageBox.Show("Ошибка выселения жителя. \nВызвано исключение: " + ex.Message);
				}
			}
		}

		/// <summary>
		/// Загружает информацию о жителе в поля ввода окна
		/// </summary>
		public void LoadData()
		{
			Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
			residentIdLabel.Text = resident.ResidentId.ToString();
			surnameTextBox.Text = resident.Surname;
			nameTextBox.Text = resident.Name;
			patronymicTextBox.Text = resident.Patronymic;
			phoneNumberTextBox.Text = resident.PhoneNumber;
			birthdayDateTimePicker.NullableValue(resident.Birthday);
			noteTextBox.Text = resident.Note;
			passportIdLabel.Text = resident.PassportId.ToString();
			organizationIdLabel.Text = resident.OrganizationId.ToString();

			Int32.TryParse(organizationIdLabel.Text, out int organizationId);
			Organization organization = db.GetTable<Organization>().SingleOrDefault(o => o.OrganizationId == organizationId);
			organizationTextBox.Text = organization.Name;

			Int32.TryParse(passportIdLabel.Text, out int passportId);
			Passport passport = db.GetTable<Passport>().SingleOrDefault(p => p.PassportId == passportId);
			passportNumberTextBox.Text = passport.Number;
			passportSeriesTextBox.Text = passport.Series;
			passportRegistrationTextBox.Text = passport.Registration;
			passportDateOfIssueDateTimePicker.Value = passport.DateOfIssue.Value;
			passportAuthorityTextBox.Text = passport.Authority;
		}

		/// <summary>
		/// Проверка на ввод данных
		/// </summary>
		/// <returns></returns>
		private bool isAllFieldsValid()
		{
			DateTime birthday = birthdayDateTimePicker.Value.Date;
			string note = noteTextBox.Text;

			if (birthdayDateTimePicker.Value.Date > DateTime.Now)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Дата рождения не может быть позже сегодня.");
				return false;
			}

			if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Введите фамилию!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(nameTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Введите имя!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(patronymicTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Введите отчество!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(organizationTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Выберите организацию!");
				return false;
			}

			if (string.IsNullOrWhiteSpace(passportSeriesTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Введите серию паспорта!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(passportNumberTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Введите номер паспорта!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(passportRegistrationTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Введите прописку!");
				return false;
			}
			if (passportDateOfIssueDateTimePicker is null)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Выберите дату выдачи паспорта!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(passportAuthorityTextBox.Text))
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Введите орган, который выдал паспорт!");
				return false;
			}
			return true;
		}

		// Нажатие кнопки проката
		private void rentButton_Click(object sender, EventArgs e)
		{
			if (startRentDateTimePicker.Value.Date > endRentDateTimePicker.Value.Date)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Нельзя добавить данный прокат. Дата начала проката должна быть раньше даты окончания.");
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите добавить данный прокат?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				RentThing();
			}
		}

		/// <summary>
		/// Добавление проката вещи
		/// </summary>
		private void RentThing()
		{
			try
			{
				ResidentRooms residentRooms = db.GetTable<ResidentRooms>()
					.FirstOrDefault(r => (r.ResidentId == residentId && r.DateOfEviction == null));
				string selectedRentName = rentThingsComboBox.SelectedItem.ToString();
				RentThing rentThing = db.GetTable<RentThing>().SingleOrDefault(r => r.Name == selectedRentName);
				ResidentRoomsRentThing residentRoomsRentThing = new ResidentRoomsRentThing
				{
					ResidentRoomsId = residentRooms.ResidentRoomsId,
					RentThingId = rentThing.RentThingId,
					StartRentDate = startRentDateTimePicker.Value.Date,
					EndRentDate = endRentDateTimePicker.Value.Date
				};
				db.GetTable<ResidentRoomsRentThing>().InsertOnSubmit(residentRoomsRentThing);
				db.SubmitChanges();
				LoadRentDataGridView();
				SystemSounds.Beep.Play();
				MessageBox.Show("Прокат успешно добавлен!");
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при добавлении проката вещей.");
				MessageBox.Show("Ошибка проката. Проверьте выбранные данные.\nВызвано исключение: " + ex.Message);
			}
		}

		// Открытие окна с возможностью изменить прокат и проживание
		private void residentLivingButton_Click(object sender, EventArgs e)
		{
			ResidentLivingForm residentLivingForm = new ResidentLivingForm(sqlConnectionString, residentId);
			residentLivingForm.ShowDialog();
			LoadDataGrid();
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
	}
}
