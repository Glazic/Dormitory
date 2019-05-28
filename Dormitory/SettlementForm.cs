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
	public partial class SettlementForm : Form
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		DataContext db;
		int roomId;

		public SettlementForm()
		{
			InitializeComponent();
			db = new DataContext(sqlConnection);
		}

		private void residentsForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "dormitoryDataSet.Organizations". При необходимости она может быть перемещена или удалена.
			//this.organizationsTableAdapter.Fill(this.dormitoryDataSet.Organizations);
			//LoadDataGrid();
		}

		public SettlementForm(int roomId) : this()
		{
			this.roomId = roomId;
		}

		public static string ShowDialogForNewSettlement(int roomId)
		{
			SettlementForm settlementForm = new SettlementForm(roomId);
			//	this.Show();
			return settlementForm.ShowDialog() == DialogResult.OK ? settlementForm.residentIdLabel.Text : null;
		}

		private void residentButton_Click(object sender, EventArgs e)
		{
			//	ResidentForm.ShowDialogForOldResident(tagObject.residentId, tagObject.roomId);
			string value = ResidentsForm.ShowDialogForNewResident(roomId);
			//	string value = OrganizationsForm.ShowDialog(residentId);
			if (value != null)
			{
				Int32.TryParse(value, out int residentId);
				Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
				residentIdLabel.Text = resident.ResidentId.ToString();
				surnameTextBox.Text = resident.Surname;
				nameTextBox.Text = resident.Name;
				patronymicTextBox.Text = resident.Patronymic;
				//resident.PhoneNumber = phoneNumberTextBox.Text; DateOfEviction
				//resident.Birthday = birthdayDateTimePicker.Value.Date;
				//resident.Note = noteTextBox.Text;
				//resident.OrganizationId = Int32.Parse(organizationIdLabel.Text);
				Organization organization = db.GetTable<Organization>().SingleOrDefault(o => o.OrganizationId == resident.OrganizationId);
				organizationTextBox.Text = organization.Name;
			}
		}

		private void settleButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите заселить данного жителя?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					Int32.TryParse(residentIdLabel.Text, out int residentId);
					Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);

					var exist = db.GetTable<RoomResidents>().Any(r => r.ResidentId == resident.ResidentId);
					if (exist)
					{
						MessageBox.Show("Данный житель уже живет в другой комнате");
					}
					else
					{
						RoomResidents roomResidents = new RoomResidents
						{
							RoomId = roomId,
							ResidentId = resident.ResidentId
						};
						db.GetTable<RoomResidents>().InsertOnSubmit(roomResidents);

						bool isCash = cashRadioButton.Checked ? true : false;
						ResidentRooms residentRooms = new ResidentRooms
						{
							ResidentId = resident.ResidentId,
							RoomId = roomId,
							CashPayment = isCash,
							BedClothes = bedClothesCheckBox.Checked,
							SettlementDate = settlementDateTimePicker.Value
						};
						db.GetTable<ResidentRooms>().InsertOnSubmit(residentRooms);
						db.SubmitChanges();

						if (isRentCheckBox.Checked)
						{
							RentThing rentThing = db.GetTable<RentThing>().SingleOrDefault(r => r.Name == "Телевизор");
							ResidentRoomsRentThing residentRoomsRentThing = new ResidentRoomsRentThing
							{
								ResidentRoomsId = residentRooms.ResidentRoomsId,
								RentThingId = rentThing.RentThingId,
								StartRentDate = startRentDateTimePicker.Value.Date,
								EndRentDate = endRentDateTimePicker.Value.Date
							};
						}
						db.SubmitChanges();

						DialogResult = DialogResult.OK;
						Close();
					}
					//db.GetTable<Resident>().InsertOnSubmit(resident);
					//db.SubmitChanges();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void isRentCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (isRentCheckBox.Checked == true)
			{
				startRentDateTimePicker.Enabled = true;
				endRentDateTimePicker.Enabled = true;
			}
			else
			{
				startRentDateTimePicker.Enabled = false;
				endRentDateTimePicker.Enabled = false;
			}
		}

	}
}
