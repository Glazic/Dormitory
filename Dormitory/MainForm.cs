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
	public partial class MainForm : Form
	{
		private LoginForm loginForm;
		private SqlConnection sqlConnection = new SqlConnection();
		DataContext db;

		public MainForm(SqlConnection sqlConnection)
		{
			this.sqlConnection = sqlConnection;
			InitializeComponent();
			db = new DataContext(sqlConnection);
			LoadTabs();		
		}

		public MainForm(LoginForm loginForm, SqlConnection sqlConnection) : this(sqlConnection)
		{
			this.loginForm = loginForm;
		}

		#region LoadTabs
		private void LoadTabs()
		{
			sectionsTabControl.TabPages.Clear();
			try
			{
				db = new DataContext(sqlConnection);
				Table<Section> sections = db.GetTable<Section>();

				foreach (var section in sections)
				{
					LoadSection(section);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void LoadSection(Section section)
		{
			TabPage myTabPage = new TabPage(section.Number.ToString());
			DataGridView dataGridView = new DataGridView();
			dataGridView.MultiSelect = false;
			dataGridView.Dock = DockStyle.Fill;
			//dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Name = "dataGridView1";
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
			loginForm.Show();
		}

		private void OrganizationsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OrganizationsForm organizationsForm = new OrganizationsForm();
			organizationsForm.ShowDialog();
			LoadTabs();
		}

		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (e.ColumnIndex == 1 && e.RowIndex != -1)
			{
				DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
				dynamic tagObject = cell.Tag;
				if (tagObject.residentId != 0 && tagObject.roomId != 0)
				{
					ResidentForm.ShowDialogForOldResident(tagObject.residentId, tagObject.roomId);
					LoadTabs();
				}
				else if (tagObject.roomId != 0)
				{
					string result = SettlementForm.ShowDialogForNewSettlement(tagObject.roomId);
					Int32.TryParse(result, out int residentId);
					if (residentId != 0)
					{
						MessageBox.Show("Успешно добавлено!");
						LoadTabs();
				//		SettleResident(tagObject.roomId, residentId);
					}
					//	ResidentForm.ShowDialog(tagObject.roomId, 0);
				}
			}
		}

		private void SettleResident(int roomId, int residentId)
		{
			Resident resident = db.GetTable<Resident>().SingleOrDefault(r => r.ResidentId == residentId);
			var exist = db.GetTable<RoomResidents>().Any(r => r.ResidentId == residentId);
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

				ResidentRooms residentRooms = new ResidentRooms
				{
					ResidentId = resident.ResidentId,
					RoomId = roomId,
					SettlementDate = DateTime.Now
				};
				db.GetTable<ResidentRooms>().InsertOnSubmit(residentRooms);
				db.SubmitChanges();
				LoadTabs();
			}
		}

		private void residentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResidentsForm residentsForm = new ResidentsForm(sqlConnection);
			residentsForm.ShowDialog();
			LoadTabs();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadTabs();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsForm settingsForm = new SettingsForm(sqlConnection);
			settingsForm.ShowDialog();
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
