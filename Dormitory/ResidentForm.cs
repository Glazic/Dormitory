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
		}

		public ResidentForm(int roomId, int residentId) : this()
		{
			this.roomId = roomId;
		}

		public static string ShowDialog(int residentId)
		{
			ResidentForm residentForm = new ResidentForm(residentId);
			//	this.Show();
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.nameLabel.Text : "";
		}

		public static string ShowDialog(int roomId, int residentId = 0)
		{
			ResidentForm residentForm = new ResidentForm(roomId, residentId);
			//	this.Show();
			return residentForm.ShowDialog() == DialogResult.OK ? residentForm.nameLabel.Text : "";
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

			Int32.TryParse(passportIdLabel.Text, out int passportId);
			Passport passport = db.GetTable<Passport>().SingleOrDefault(p => p.PassportId == passportId);
			passportNumberTextBox.Text = passport.Number;
			passportSeriesTextBox.Text = passport.Series;
			passportRegistrationTextBox.Text = passport.Registration;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void addButton_Click(object sender, EventArgs e)
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
			Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
			resident.Surname = surnameTextBox.Text;
			resident.Name = nameTextBox.Text;
			resident.Patronymic = patronymicTextBox.Text;
			resident.PhoneNumber = phoneNumberTextBox.Text;
			resident.Birthday = birthdayDateTimePicker.Value.Date;
			resident.Note = noteTextBox.Text;

			Passport passport = db.GetTable<Passport>().SingleOrDefault(p => p.PassportId == resident.PassportId);
			passport.Number = passportNumberTextBox.Text;
			passport.Series = passportSeriesTextBox.Text;
			passport.Registration = passportRegistrationTextBox.Text;

			db.SubmitChanges();
		}

		private void organizationButton_Click(object sender, EventArgs e)
		{
			string value = OrganizationsForm.ShowDialog(residentId);
			Int32.TryParse(value, out int organizationId);
			Organization organization = db.GetTable<Organization>().SingleOrDefault(o => o.OrganizationId == organizationId);
			organizationIdLabel.Text = organizationId.ToString();
			organizationTextBox.Text = organization.Name;
		}

		private void settleButton_Click(object sender, EventArgs e)
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

			//string surname = "ss";
			//string name = "sds";
			//string patronymic = "sds";
			//string phoneNumber = "fff";
			//string passportSeries = "ddddd";
			//string passportNumber = "ddssddd";
			//string passportRegistration = "dsd";
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
	}
}
