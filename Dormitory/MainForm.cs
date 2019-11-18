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
	/// Отвечает за главное окно программы, в котором находится основное меню программы 
	/// и таблица с комнатами
	/// </summary>
	public partial class MainForm : Form
	{
		private LoginForm loginForm;
		private SqlConnectionStringBuilder sqlConnectionString;
		//private SqlConnection sqlConnection;
		DataContext db;

		public MainForm(SqlConnectionStringBuilder sqlConnectionString)
		{
			this.sqlConnectionString = sqlConnectionString;
			//this.sqlConnection = sqlConnection;
			InitializeComponent();
			db = new DataContext(sqlConnectionString.ConnectionString);
			BackupHelper.StartThreadForBackup();
			LoadTabs();
		}

		public MainForm(LoginForm loginForm, SqlConnectionStringBuilder sqlConnectionString) : this(sqlConnectionString)
		{
			this.loginForm = loginForm;
		}

		#region LoadTabs
		/// <summary>
		/// Загружает информацию для вкладок элемента TabControl главного окна
		/// </summary>
		private void LoadTabs()
		{
			sectionsTabControl.TabPages.Clear();
			try
			{
			//	SqlConnection sqlConnection2 = new SqlConnection(sqlConnectionString);
				db = new DataContext(sqlConnectionString.ConnectionString);
				Table<Section> sections = db.GetTable<Section>();

				foreach (var section in sections)
				{
					LoadSection(section);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке секций. \nВызвано исключение: " + ex.Message);
				HistoryRecordsController.WriteExceptionToLogFile(ex, "Ошибка загрузки секций");
			}
		}

		/// <summary>
		/// Загружает информацию о секции в виде отдельной вкладки элемента TabControl
		/// </summary>
		/// <param name="section">Секция для загрузки</param>
		private void LoadSection(Section section)
		{
			TabPage myTabPage = new TabPage(section.Number.ToString());
			myTabPage.Name = section.Number.ToString();
			DataGridView dataGridView = new DataGridView();
			dataGridView.Name = section.Number.ToString();
			dataGridView.MultiSelect = false;
			dataGridView.Dock = DockStyle.Fill;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.ReadOnly = true;
			dataGridView.Size = new System.Drawing.Size(700, 400);
			dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
			DataGridViewColumn numberColumn = new DataGridViewColumn
			{
				HeaderText = "#",
				Name = "numberColumn",
				ReadOnly = true,
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 40
			};
			DataGridViewLinkColumn nameColumn = new DataGridViewLinkColumn
			{
				HeaderText = "ФИО",
				Name = "nameColumn",
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				UseColumnTextForLinkValue = true,
				LinkColor = Color.Blue,
				VisitedLinkColor = Color.Blue,
				CellTemplate = new DataGridViewLinkCell()
			};
			DataGridViewColumn organizationColumn = new DataGridViewColumn
			{
				HeaderText = "Организация",
				Name = "organizationColumn",
				ReadOnly = true,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
				CellTemplate = new DataGridViewTextBoxCell()
			};
			dataGridView.Columns.Add(numberColumn);
			dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView.Columns.Add(nameColumn);
			dataGridView.Columns.Add(organizationColumn);
			int row = 0;
			foreach (var room in section.Rooms)
			{
				LoadRoom(room, dataGridView, ref row);
			}
			myTabPage.Controls.Add(dataGridView);
			sectionsTabControl.TabPages.Add(myTabPage);
		}

		/// <summary>
		/// Загружает информацию о комнате в виде строк DataGridView
		/// </summary>
		/// <param name="room">Комната</param>
		/// <param name="dataGridView">К какому элементу добавляются строки</param>
		/// <param name="row">Номер первой для добавления строки для данной комнаты</param>
		private void LoadRoom(Room room, DataGridView dataGridView, ref int row)
		{
			dataGridView.Rows.Add(room.Seats);
			for (int i = 0; i < room.Seats; i++)
			{
				dataGridView.Rows[row + i].Height = 40;
				dataGridView.Rows[row].Cells[0].Value = room.Number;
				RoomResidents roomResidents = room.RoomResidents.ElementAtOrDefault(i);
				Resident resident = null;
				if (roomResidents != null)
				{
					resident = db.GetTable<Resident>().Single(r => r.ResidentId == roomResidents.ResidentId);
				}
				dynamic tagObject = new System.Dynamic.ExpandoObject();
				if (resident != null)
				{
					string fullName = resident.Surname.ToString() + " " + resident.Name.ToString() + " " + resident.Patronymic.ToString();
					tagObject.residentId = resident.ResidentId;
					tagObject.roomId = room.RoomId;
					string organizationName = resident.Organization.Name.ToString();
					dataGridView.Rows[row + i].Cells[1].Value = fullName;
					dataGridView.Rows[row + i].Cells[1].Tag = tagObject;
					dataGridView.Rows[row + i].Cells[2].Value = organizationName;
				}
				else
				{
					tagObject.residentId = 0;
					tagObject.roomId = room.RoomId;
					dataGridView.Rows[row + i].Cells[1].Value = "Добавить";
					dataGridView.Rows[row + i].Cells[1].Tag = tagObject;
					dataGridView.Rows[row + i].Cells[2].Value = "Пусто";
				}
			}
			row += room.Seats;
		}
		#endregion
		
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			HistoryRecordsController.WriteAboutSystemExit();
			BackupHelper.StopThreadForBackup();
			loginForm.Show();
		}

		private void OrganizationsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OrganizationsForm organizationsForm = new OrganizationsForm(sqlConnectionString);
			organizationsForm.ShowDialog();
			LoadTabs();
		}

		/// <summary>
		/// Обновление данных в элементе DataGridView о выбранной комнате
		/// </summary>
		/// <param name="dataGridView">Таблица для изменения</param>
		/// <param name="tagObject">Динамический объект, содержащий идентификатор пользователя (residentId) 
		/// и идентификатор комнаты (roomId)</param>
		/// <param name="rowIndex">Номер строки, с которой нужно начать обновлять данные</param>
		private void DataGridUpdateRoom(DataGridView dataGridView, dynamic tagObject, int rowIndex)
		{
			int residentId = tagObject.residentId;
			int roomId = tagObject.roomId;
			string fullName, organizationName;
			db = new DataContext(sqlConnectionString.ConnectionString);
			var exist = db.GetTable<RoomResidents>().Any(r => r.ResidentId == residentId && r.RoomId == roomId);
			if (exist)
			{
				Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
				if (resident != null)
				{
					fullName = resident.Surname.ToString() + " " + resident.Name.ToString() + " " + resident.Patronymic.ToString();
					organizationName = resident.Organization.Name.ToString();
				}
				else
				{
					fullName = "Добавить";
					organizationName = "Пусто";
					tagObject.residentId = 0;
				}
			}
			else
			{
				fullName = "Добавить";
				organizationName = "Пусто";
				tagObject.residentId = 0;
			}
			dataGridView.Rows[rowIndex].Cells[1].Value = fullName;
			dataGridView.Rows[rowIndex].Cells[1].Tag = tagObject;
			dataGridView.Rows[rowIndex].Cells[2].Value = organizationName;
		}

		// Обрабатывает нажатие ячейки таблцы. В каждой ячейке хранятся дополнительные данные в 
		// виде объекта dynamic, содержащего идентификатор пользователя (residentId) 
		// и идентификатор комнаты (roomId)
		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (e.ColumnIndex == 1 && e.RowIndex != -1)
			{
				DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
				dynamic tagObject = cell.Tag;
				if (tagObject.residentId != 0 && tagObject.roomId != 0)
				{
					ResidentForm.ShowDialogForOldResident(sqlConnectionString, tagObject.residentId, tagObject.roomId);
				//	DataGridUpdateRoom(dataGridView, tagObject, e.RowIndex);
					LoadTabs();
				}
				else if (tagObject.roomId != 0)
				{
					string result = SettlementForm.ShowDialogForNewSettlement(sqlConnectionString, tagObject.roomId);
					Int32.TryParse(result, out int residentId);
					if (residentId != 0)
					{
						MessageBox.Show("Успешно добавлено!");
						tagObject.residentId = residentId;
						DataGridUpdateRoom(dataGridView, tagObject, e.RowIndex);
					}
				}
			}
		}

		private void residentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResidentsForm residentsForm = new ResidentsForm(sqlConnectionString);
			residentsForm.ShowDialog();
			LoadTabs();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsForm settingsForm = new SettingsForm(sqlConnectionString);
			settingsForm.ShowDialog();
			LoadTabs();
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

		private void historyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HistoryRecordsForm historyRecordsForm = new HistoryRecordsForm();
			historyRecordsForm.ShowDialog();
		}
	}
}
