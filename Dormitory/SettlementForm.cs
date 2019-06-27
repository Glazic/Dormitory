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
	public partial class SettlementForm : Form
	{
		SqlConnection sqlConnection;
		DataContext db;
		int roomId;

		public SettlementForm(SqlConnection sqlConnection)
		{
			InitializeComponent();
			this.sqlConnection = sqlConnection;
			db = new DataContext(this.sqlConnection);
		}

		private void residentsForm_Load(object sender, EventArgs e)
		{

		}

		public SettlementForm(SqlConnection sqlConnection, int roomId) : this(sqlConnection)
		{
			this.roomId = roomId;
		}

		public static string ShowDialogForNewSettlement(SqlConnection sqlConnection, int roomId)
		{
			SettlementForm settlementForm = new SettlementForm(sqlConnection, roomId);
			return settlementForm.ShowDialog() == DialogResult.OK ? settlementForm.residentIdLabel.Text : null;
		}

		private void residentButton_Click(object sender, EventArgs e)
		{
			string value = ResidentsForm.ShowDialogForNewResident(sqlConnection);
			if (value != null)
			{
				Int32.TryParse(value, out int residentId);
				Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
				residentIdLabel.Text = resident.ResidentId.ToString();
				surnameTextBox.Text = resident.Surname;
				nameTextBox.Text = resident.Name;
				patronymicTextBox.Text = resident.Patronymic;
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
						SystemSounds.Exclamation.Play();
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
							db.GetTable<ResidentRoomsRentThing>().InsertOnSubmit(residentRoomsRentThing);
						}
						db.SubmitChanges();

						DialogResult = DialogResult.OK;
						Close();
					}
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void isRentCheckBox_CheckedChanged(object sender, EventArgs e)
		{			
			if (isRentCheckBox.Checked == true)
			{
				LoadRentThings();
				rentThingsComboBox.Enabled = true;
				startRentDateTimePicker.Enabled = true;
				endRentDateTimePicker.Enabled = true;
			}
			else
			{
				rentThingsComboBox.Enabled = false;
				startRentDateTimePicker.Enabled = false;
				endRentDateTimePicker.Enabled = false;
			}
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
