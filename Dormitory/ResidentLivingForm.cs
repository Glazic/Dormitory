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
	// Отвечает за окно проживания и проката жителя
	public partial class ResidentLivingForm : Form
	{
		SqlConnectionStringBuilder sqlConnectionString;
		DataContext db;
		SqlDataAdapter dataAdapter;
		DataTable dataTableLiving, dateTableRent;
		int residentId = 0;

		public ResidentLivingForm(SqlConnectionStringBuilder sqlConnectionString, int residentId)
		{
			InitializeComponent();
			this.residentId = residentId;
			this.sqlConnectionString = sqlConnectionString;
			db = new DataContext(this.sqlConnectionString.ConnectionString);
		}

		private void ResidentLivingForm_Load(object sender, EventArgs e)
		{
			LoadDataGrid();
		}

		/// <summary>
		/// Загрузка всех данных окна
		/// </summary>
		public void LoadDataGrid()
		{
			LoadLivingDataGridView();
			LoadRentDataGridView();
			LoadRentThings();

			cashPaymentComboBox.Items.Add(new ComboBoxItem("Наличные", true));
			cashPaymentComboBox.Items.Add(new ComboBoxItem("Безналичные", false));

			bedClothesComboBox.Items.Add(new ComboBoxItem("Постельное", true));
			bedClothesComboBox.Items.Add(new ComboBoxItem("Без постельного", false));
		}

		/// <summary>
		/// Загрузка информации о проживании
		/// </summary>
		private void LoadLivingDataGridView()
		{
			dataAdapter = new SqlDataAdapter("SELECT ResidentRoomsId as [ИД], SectionNumber AS [Секция], " +
				"Number AS [Комната], CashPayment as [Оплата], BedClothes as [Постельное], " +
				"SettlementDate as [Заселение], DateOfEviction as [Выселение]" +
				"FROM View_ResidentRooms " +
				$"WHERE ResidentId = {residentId}", sqlConnectionString.ConnectionString);
			dataTableLiving = new DataTable();
			dataAdapter.Fill(dataTableLiving);
			livingDataGridView.DataSource = dataTableLiving;
			livingDataGridView.Columns[0].Width = 55;
			livingDataGridView.Columns[1].Width = 55;
			livingDataGridView.Columns[2].Width = 65;
			livingDataGridView.Columns[3].Width = 95;
			livingDataGridView.Columns[4].Width = 95;
			livingDataGridView.Columns[5].Width = 160;
			livingDataGridView.Columns[6].Width = 160;

			livingDataGridView.ClearSelection();
		}

		/// <summary>
		/// Загрузка информации о прокате вещей
		/// </summary>
		private void LoadRentDataGridView()
		{
			dataAdapter = new SqlDataAdapter("SELECT ResidentRoomsRentThingsId as [ИД], " +
				"RentThings.Name AS [Прокат], " +
				"StartRentDate AS [Начало проката], EndRentDate AS [Конец проката] " +
				"FROM ResidentRoomsRentThings " +
				"LEFT JOIN ResidentRooms " +
					"ON ResidentRoomsRentThings.ResidentRoomsId = ResidentRooms.ResidentRoomsId " +
				"LEFT JOIN RentThings " +
					"ON ResidentRoomsRentThings.RentThingId = RentThings.RentThingId " +
				$"WHERE ResidentId = {residentId}", sqlConnectionString.ConnectionString);
			dateTableRent = new DataTable();
			dataAdapter.Fill(dateTableRent);
			rentDataGridView.DataSource = dateTableRent;
			rentDataGridView.Columns[0].Width = 55;
			rentDataGridView.Columns[1].Width = 210;
			rentDataGridView.Columns[2].Width = 200;
			rentDataGridView.Columns[3].Width = 200;

			rentDataGridView.ClearSelection();
		}

		/// <summary>
		/// Загрузка списка вещей для проката
		/// </summary>
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

		// Обрабатывает нажатие ячейки таблицы проживания для идентификации записи
		private void livingDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTableLiving] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				residentRoomsIdLabel.Text = dataRow[0].ToString();
				sectionNumberTextBox.Text = dataRow[1].ToString();
				roomNumberTextBox.Text = dataRow[2].ToString();

				string cashPayment = dataRow[3].ToString();
				if (cashPayment == "Наличные")
				{
					cashPaymentComboBox.SelectedIndex = cashPaymentComboBox.FindStringExact("Наличные");
				}
				else
				{
					cashPaymentComboBox.SelectedIndex = cashPaymentComboBox.FindStringExact("Безналичные");
				}
				string bedClothes = dataRow[4].ToString();
				if (bedClothes == "Постельное")
				{
					bedClothesComboBox.SelectedIndex = bedClothesComboBox.FindStringExact("Постельное");
				}
				else
				{
					bedClothesComboBox.SelectedIndex = bedClothesComboBox.FindStringExact("Без постельного");
				}

				string settlementDate = dataRow[5].ToString();
				settlementDateDateTimePicker.NullableValue(string.IsNullOrEmpty(settlementDate) ? (DateTime?)null : DateTime.Parse(settlementDate));
				string dateOfEviction = dataRow[6].ToString();
				dateOfEvictionDateTimePicker.NullableValue(string.IsNullOrEmpty(dateOfEviction) ? (DateTime?)null : DateTime.Parse(dateOfEviction));
			}
		}

		// Сохраняет изменения о проживании
		private void saveLivingButton_Click(object sender, EventArgs e)
		{
			if (settlementDateDateTimePicker.Value.Date > dateOfEvictionDateTimePicker.NullableValue())
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Дата заселения должна быть раньше даты выселения.");
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите сохранить изменения?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					Int32.TryParse(residentRoomsIdLabel.Text, out int residentRoomsId);
					if (residentRoomsId == 0)
					{
						MessageBox.Show("Выберите запись для изменения.");
					}
					else
					{
						int sectonNumber = Int32.Parse(sectionNumberTextBox.Text);
						int roomNumber = Int32.Parse(roomNumberTextBox.Text);
						Room room = db.GetTable<Room>().SingleOrDefault(r => r.SectionNumber == sectonNumber && r.Number == roomNumber);
						if (room != null)
						{
							ResidentRooms residentRooms = db.GetTable<ResidentRooms>().SingleOrDefault(r => r.ResidentRoomsId == residentRoomsId);

							if (residentRooms.RoomId != room.RoomId)
							{
								RoomResidents roomResidents = db.GetTable<RoomResidents>().FirstOrDefault(r => (r.ResidentId == residentId && r.RoomId == residentRooms.RoomId));
								db.GetTable<RoomResidents>().DeleteOnSubmit(roomResidents);

								RoomResidents newRoomResidents = new RoomResidents
								{
									RoomId = room.RoomId,
									ResidentId = residentRooms.ResidentId
								};
								db.GetTable<RoomResidents>().InsertOnSubmit(newRoomResidents);
							}

							residentRooms.RoomId = room.RoomId;
							residentRooms.CashPayment = (bool)((ComboBoxItem)cashPaymentComboBox.SelectedItem).HiddenValue;
							residentRooms.BedClothes = (bool)((ComboBoxItem)bedClothesComboBox.SelectedItem).HiddenValue;
							residentRooms.SettlementDate = settlementDateDateTimePicker.Value;
							residentRooms.DateOfEviction = dateOfEvictionDateTimePicker.NullableValue();
							db.SubmitChanges();
							SystemSounds.Beep.Play();
							MessageBox.Show("Успешно сохранено!");
							LoadLivingDataGridView();
						}
						else
						{
							MessageBox.Show("Введённой комнаты не существует.");
						}
					}
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при сохранении изменений о проживании в saveLivingButton_Click.");
					MessageBox.Show("Ошибка при сохранении изменений.\nВызвано исключение:" + ex.Message);
				}
			}
		}

		// Обрабатывает нажатие ячейки таблицы проката для идентификации записи
		private void rentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dateTableRent] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				rentIdLabel.Text = dataRow[0].ToString();

				string rentThing = dataRow[1].ToString();
				rentThingsComboBox.SelectedIndex = rentThingsComboBox.FindStringExact(rentThing);

				string startRentDate = dataRow[2].ToString();
				startRentDateTimePicker.NullableValue(string.IsNullOrEmpty(startRentDate) ? (DateTime?)null : DateTime.Parse(startRentDate));
				string endRentDate = dataRow[3].ToString();
				endRentDateTimePicker.NullableValue(string.IsNullOrEmpty(endRentDate) ? (DateTime?)null : DateTime.Parse(endRentDate));
			}
		}

		// Сохраняет изменения о прокате вещи
		private void saveRentButton_Click(object sender, EventArgs e)
		{
			if (startRentDateTimePicker.Value.Date > endRentDateTimePicker.Value.Date)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Нельзя добавить данный прокат. Дата начала проката должна быть раньше даты окончания.");
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите сохранить изменения?\n",
			"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					Int32.TryParse(rentIdLabel.Text, out int rentId);
					if (rentId == 0)
					{
						MessageBox.Show("Выберите запись для изменения.");
					}
					else
					{
						ResidentRoomsRentThing residentRoomsRentThing = db.GetTable<ResidentRoomsRentThing>().SingleOrDefault(r => r.ResidentRoomsRentThingsId == rentId);

						string selectedRentName = rentThingsComboBox.SelectedItem.ToString();
						RentThing rentThing = db.GetTable<RentThing>().SingleOrDefault(r => r.Name == selectedRentName);

						residentRoomsRentThing.RentThingId = rentThing.RentThingId;
						residentRoomsRentThing.StartRentDate = startRentDateTimePicker.Value.Date;
						residentRoomsRentThing.EndRentDate = endRentDateTimePicker.Value.Date;

						db.SubmitChanges();
						SystemSounds.Beep.Play();
						MessageBox.Show("Успешно сохранено!");
						LoadRentDataGridView();
					}
				}
				catch (Exception ex)
				{
					SystemSounds.Exclamation.Play();
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при сохранении изменений о прокате вещей в saveRentButton_Click.");
					MessageBox.Show("Ошибка при сохранении изменений о прокате вещей.\nВызвано исключение:" + ex.Message);
				}
			}
		}

		// Удаляет запись о проживании
		private void deleteLivingButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?\n",
				"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					Int32.TryParse(residentRoomsIdLabel.Text, out int residentRoomsId);
					if (residentRoomsId == 0)
					{
						MessageBox.Show("Выберите запись для удаления.");
					}
					else
					{
						ResidentRooms residentRooms = db.GetTable<ResidentRooms>().SingleOrDefault(r => r.ResidentRoomsId == residentRoomsId);
						db.GetTable<ResidentRooms>().DeleteOnSubmit(residentRooms);

						RoomResidents roomResidents = db.GetTable<RoomResidents>().FirstOrDefault(r => (r.ResidentId == residentId && r.RoomId == residentRooms.RoomId));
						db.GetTable<RoomResidents>().DeleteOnSubmit(roomResidents);
						db.SubmitChanges();
						LoadLivingDataGridView();
					}
				}
				catch (Exception ex)
				{
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при удалении информации о проживании в deleteLivingButton_Click.");
					MessageBox.Show("Ошибка при удалении информации о проживании.\nВызвано исключение:" + ex.Message);
				}
			}
		}

		// Удаляет запись о прокате вещи
		private void deleteRentButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?\n",
			"Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				try
				{
					Int32.TryParse(rentIdLabel.Text, out int rentId);
					if (rentId == 0)
					{
						MessageBox.Show("Выберите запись для удаления.");
					}
					else
					{
						ResidentRoomsRentThing residentRoomsRentThing = db.GetTable<ResidentRoomsRentThing>().SingleOrDefault(r => r.ResidentRoomsRentThingsId == rentId);
						db.GetTable<ResidentRoomsRentThing>().DeleteOnSubmit(residentRoomsRentThing);

						db.SubmitChanges();
						LoadRentDataGridView();
					}
				}
				catch (Exception ex)
				{
					HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка при удалении информации о прокате вещей в deleteRentButton_Click.");
					MessageBox.Show("Ошибка при удалении информации о прокате вещей.\nВызвано исключение:" + ex.Message);
				}
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
	}
}
