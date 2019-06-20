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

namespace Dormitory
{
	public partial class ResidentForm : Form
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		DataContext db;
		SqlDataAdapter dataAdapter;
		DataTable dataTable;
		int residentId = 0;
		int roomId = 0;

		public ResidentForm()
		{
			InitializeComponent();
			db = new DataContext(sqlConnection);
		}

		public ResidentForm(int residentId) : this()
		{
			residentIdLabel.Text = residentId.ToString();
			this.residentId = residentId;
			LoadData();
			LoadDataGrid();
		}

		public ResidentForm(int residentId, int roomId) : this()
		{
			settleButton.Enabled = false;
			addButton.Enabled = false;
			residentIdLabel.Text = residentId.ToString();
			roomIdLabel.Text = roomId.ToString();
			this.residentId = residentId;
			this.roomId = roomId;
			LoadData();
			LoadDataGrid();
		}

		public static string ShowDialog(int residentId)
		{
			ResidentForm residentForm = new ResidentForm(residentId);
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.nameLabel.Text : "";
		}

		public static string ShowDialogForOldResident(int residentId, int roomId = 0)
		{
			ResidentForm residentForm = new ResidentForm(residentId, roomId);
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.nameLabel.Text : "";
		}

		public void LoadDataGrid()
		{
			LoadLivingDataGridView();
			LoadRentDataGridView();
			LoadRentThings();
		}

		private void LoadLivingDataGridView()
		{
			dataAdapter = new SqlDataAdapter("SELECT SectionNumber AS [Секция], " +
				"Number AS [Комната], CashPayment as [Оплата], " +
				"SettlementDate as [Заселение], DateOfEviction as [Выселение]" +
				"FROM View_ResidentRooms " +
				$"WHERE ResidentId = {residentId}", sqlConnection);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			livingDataGridView.DataSource = dataTable;
			livingDataGridView.Columns[0].Width = 80;
			livingDataGridView.Columns[1].Width = 90;
			livingDataGridView.Columns[2].Width = 140;
			livingDataGridView.Columns[3].Width = 160;
			livingDataGridView.Columns[4].Width = 160;
		}

		private void LoadRentDataGridView()
		{
			dataAdapter = new SqlDataAdapter("SELECT RentThings.Name AS [Прокат], " +
				"StartRentDate AS [Начало проката], EndRentDate AS [Конец проката] " +
				"FROM ResidentRoomsRentThings " +
				"LEFT JOIN ResidentRooms " +
					"ON ResidentRoomsRentThings.ResidentRoomsId = ResidentRooms.ResidentRoomsId " +
				"LEFT JOIN RentThings " +
					"ON ResidentRoomsRentThings.RentThingId = RentThings.RentThingId " +
				$"WHERE ResidentId = {residentId}", sqlConnection);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			rentDataGridView.DataSource = dataTable;
			rentDataGridView.Columns[0].Width = 210;
			rentDataGridView.Columns[1].Width = 200;
			rentDataGridView.Columns[2].Width = 200;
		}

		private void LoadRentThings()
		{
			Table<RentThing> rentThings = db.GetTable<RentThing>();
			foreach (var thing in rentThings)
			{
				rentThingsComboBox.Items.Add(thing.Name);
			}
			rentThingsComboBox.SelectedIndex = 0;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			if (isAllFieldsValid() == false)
			{
				return;
			}

			string surname = surnameTextBox.Text;
			string name = nameTextBox.Text;
			string patronymic = patronymicTextBox.Text;
			string phoneNumber = phoneNumberTextBox.Text;
			DateTime birthday = birthdayDateTimePicker.Value.Date;
			string passportSeries = passportSeriesTextBox.Text;
			string passportNumber = passportNumberTextBox.Text;
			string passportRegistration = passportRegistrationTextBox.Text;
			string note = noteTextBox.Text;

			Organization organization = db.GetTable<Organization>().FirstOrDefault();
			Passport passport = new Passport
			{
				Series = passportSeries,
				Number = passportNumber,
				Registration = passportRegistration
			};
			db.GetTable<Passport>().InsertOnSubmit(passport);
			db.SubmitChanges();

			Resident resident = new Resident
			{
				Surname = surname,
				Name = name,
				Patronymic = patronymic,
				PhoneNumber = phoneNumber,
				Birthday = birthday,
				Note = note,
				PassportId = passport.PassportId,
				OrganizationId = organization.OrganizationId
			};

			db.GetTable<Resident>().InsertOnSubmit(resident);
			db.SubmitChanges();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			try
			{
				Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
				resident.Surname = surnameTextBox.Text;
				resident.Name = nameTextBox.Text;
				resident.Patronymic = patronymicTextBox.Text;
				resident.PhoneNumber = phoneNumberTextBox.Text;
				resident.Birthday = birthdayDateTimePicker.Value.Date;
				resident.Note = noteTextBox.Text;
				resident.OrganizationId = Int32.Parse(organizationIdLabel.Text);

				Passport passport = db.GetTable<Passport>().SingleOrDefault(p => p.PassportId == resident.PassportId);
				passport.Number = passportNumberTextBox.Text;
				passport.Series = passportSeriesTextBox.Text;
				passport.Registration = passportRegistrationTextBox.Text;
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void organizationButton_Click(object sender, EventArgs e)
		{
			string value = OrganizationsForm.ShowDialog(residentId);
			if (value != null)
			{
				Int32.TryParse(value, out int organizationId);
				Organization organization = db.GetTable<Organization>().SingleOrDefault(o => o.OrganizationId == organizationId);
				organizationIdLabel.Text = organizationId.ToString();
				organizationTextBox.Text = organization.Name;
			}
		}

		private void settleButton_Click(object sender, EventArgs e)
		{
			try
			{
				string surname = surnameTextBox.Text;
				string name = nameTextBox.Text;
				string patronymic = patronymicTextBox.Text;
				string phoneNumber = phoneNumberTextBox.Text;
				DateTime birthday = birthdayDateTimePicker.Value.Date;
				string passportSeries = passportSeriesTextBox.Text;
				string passportNumber = passportNumberTextBox.Text;
				string passportRegistration = passportRegistrationTextBox.Text;
				string note = noteTextBox.Text;

				Int32.TryParse(organizationIdLabel.Text, out int organizationId);
				//	Organization organization = db.GetTable<Organization>().FirstOrDefault();
				Passport passport = new Passport
				{
					Series = passportSeries,
					Number = passportNumber,
					Registration = passportRegistration
				};
				db.GetTable<Passport>().InsertOnSubmit(passport);
				db.SubmitChanges();

				Resident resident = new Resident
				{
					Surname = surname,
					Name = name,
					Patronymic = patronymic,
					PhoneNumber = phoneNumber,
					Birthday = birthday,
					Note = note,
					PassportId = passport.PassportId,
					OrganizationId = organizationId
				};

				db.GetTable<Resident>().InsertOnSubmit(resident);
				db.SubmitChanges();

				RoomResidents roomResidents = new RoomResidents
				{
					RoomId = roomId,
					ResidentId = resident.ResidentId
				};
				db.GetTable<RoomResidents>().InsertOnSubmit(roomResidents);

				ResidentRooms residentRooms = new ResidentRooms
				{
					ResidentId = resident.ResidentId,
					RoomId = roomId,
					SettlementDate = DateTime.Now
				};
				db.GetTable<ResidentRooms>().InsertOnSubmit(residentRooms);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void evictButton_Click(object sender, EventArgs e)
		{
			EvictResident(roomId, residentId);
		}

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
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		public void LoadData()
		{
			Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
			residentIdLabel.Text = resident.ResidentId.ToString();
			surnameTextBox.Text = resident.Surname;
			nameTextBox.Text = resident.Name;
			patronymicTextBox.Text = resident.Patronymic;
			phoneNumberTextBox.Text = resident.PhoneNumber;
			birthdayDateTimePicker.Value = resident.Birthday.Value;
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

		private bool isAllFieldsValid()
		{
			DateTime birthday = birthdayDateTimePicker.Value.Date;
			string note = noteTextBox.Text;

			if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
			{
				MessageBox.Show("Введите фамилию!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(nameTextBox.Text))
			{
				MessageBox.Show("Введите имя!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(patronymicTextBox.Text))
			{
				MessageBox.Show("Введите отчество!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(phoneNumberTextBox.Text))
			{
				MessageBox.Show("Введите номер телефона!");
				return false;
			}

			if (string.IsNullOrWhiteSpace(passportSeriesTextBox.Text))
			{
				MessageBox.Show("Введите серию паспорта!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(passportNumberTextBox.Text))
			{
				MessageBox.Show("Введите номер паспорта!");
				return false;
			}
			if (string.IsNullOrWhiteSpace(passportRegistrationTextBox.Text))
			{
				MessageBox.Show("Введите прописку!");
				return false;
			}

			return true;

		}

		private void rentButton_Click(object sender, EventArgs e)
		{
			if (startRentDateTimePicker.Value.Date > endRentDateTimePicker.Value.Date)
			{
				MessageBox.Show("Нельзя добавить данный прокат. Дата начала проката должна быть раньше даты окончания.");
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите добавить данный прокат?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					ResidentRooms residentRooms = db.GetTable<ResidentRooms>()
						.FirstOrDefault(r => (r.ResidentId == residentId && r.DateOfEviction == null));

					RentThing rentThing = db.GetTable<RentThing>().SingleOrDefault(r => r.Name == "Телевизор");
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
					MessageBox.Show("Добавлено");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
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
