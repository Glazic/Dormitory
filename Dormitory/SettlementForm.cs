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
	/// <summary>
	/// Отвечает за окно заселения жителей
	/// </summary>
	public partial class SettlementForm : Form
	{
		SqlConnectionStringBuilder sqlConnectionString;
		DataContext db;
		int roomId;

		public SettlementForm(SqlConnectionStringBuilder sqlConnectionString)
		{
			InitializeComponent();
			this.sqlConnectionString = sqlConnectionString;
			db = new DataContext(this.sqlConnectionString.ConnectionString);
		}

		private void residentsForm_Load(object sender, EventArgs e)
		{

		}

		public SettlementForm(SqlConnectionStringBuilder sqlConnectionString, int roomId) : this(sqlConnectionString)
		{
			this.roomId = roomId;
		}

		/// <summary>
		/// Открывает окно заселения в выбранную комнату. Возвращает идентификатор жителя.
		/// </summary>
		/// <param name="sqlConnection">Подключение пользователя</param>
		/// <param name="roomId">Идентификатор комнаты для заселения</param>
		/// <returns>Идентификатор жителя или null, если житель не был заселён</returns>
		public static string ShowDialogForNewSettlement(SqlConnectionStringBuilder sqlConnectionString, int roomId)
		{
			SettlementForm settlementForm = new SettlementForm(sqlConnectionString, roomId);
			return settlementForm.ShowDialog() == DialogResult.OK ? settlementForm.residentIdLabel.Text : null;
		}
		// Открывает окно жителей общежития для выбора и загружает информацию о выбранном жителе
		private void residentButton_Click(object sender, EventArgs e)
		{
			string value = ResidentsForm.ShowDialogForNewResident(sqlConnectionString);
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

		// Заселяет жителя
		private void settleButton_Click(object sender, EventArgs e)
		{
			if (startRentDateTimePicker.Value.Date > endRentDateTimePicker.Value.Date)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Нельзя добавить данный прокат. Дата начала проката должна быть раньше даты окончания.");
				return;
			}
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

						HistoryRecordsController.WriteAboutSettlement(residentRooms, true);
						DialogResult = DialogResult.OK;
						Close();
					}
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при заселении жителя в settleButton_Click.");
					MessageBox.Show("Ошибка при заселении жителя.\nВызвано исключение: " + ex.Message);
				}
			}
		}

		// Отвечает за доступ к элементам проката вещей
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

		// Загружает список вещей для проката
		private void LoadRentThings()
		{
			rentThingsComboBox.Items.Clear();
			Table<RentThing> rentThings = db.GetTable<RentThing>();
			foreach (var thing in rentThings)
			{
				rentThingsComboBox.Items.Add(thing.Name);
			}
			rentThingsComboBox.SelectedIndex = 0;
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
