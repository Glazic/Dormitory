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
		private string userName;
		private string password;
		private SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		private DataTable moviesParticipantsDataTable;
		private DataTable employeesDataTable;
		DataContext db;

		public MainForm()
		{
			InitializeComponent();
			InitializeModels();
			db = new DataContext(sqlConnection);
			LoadTabs();		
		}

		public MainForm(LoginForm loginForm, string userName, string password)
		{
			InitializeComponent();
			this.loginForm = loginForm;
			this.userName = userName;
			this.password = password;
			this.moviesParticipantsDataTable = new DataTable();
			this.employeesDataTable = new DataTable();
			this.sqlConnection = new SqlConnection($"Data Source=ANTON\\SQLEXPRESS;Initial Catalog=MoviesShop;User ID={userName};Password={password}");
		}

		public void InitializeModels()
		{

		}

		public void LoadSections()
		{
			//string sqlExpression = "SELECT * FROM Sections";
			//try
			//{
			//	sqlConnection.Open();
			//	SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
			//	SqlDataReader reader = command.ExecuteReader();
			//	if (reader.HasRows) // если есть данные
			//	{
			//		while (reader.Read()) // построчно считываем данные
			//		{
			//			object sectionId = reader.GetValue(0);
			//			Int32.TryParse(reader.GetValue(1).ToString(), out int number);
			//			Int32.TryParse(reader.GetValue(2).ToString(), out int numberOfRooms);
			//			//string title = "TabPage " + (sectionsTabControl.TabCount + 1).ToString();
			//			TabPage myTabPage = new TabPage(number.ToString());

			//			TableLayoutPanel sectionPanel = new TableLayoutPanel();
			//			//sectionPanel.Anchor = System.Windows.Forms.AnchorStyles.None;

			//		}
			//	}
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message);
			//}
			//finally
			//{
			//	sqlConnection.Close();
			//}

		}

		public void LoadTabs()
		{
			sectionsTabControl.TabPages.Clear();
			try
			{
				Table<Section> sections = db.GetTable<Section>();

				foreach (var section in sections)
				{
					TabPage myTabPage = new TabPage(section.Number.ToString());
					DataGridView dataGridView = new DataGridView();
					dataGridView.MultiSelect = false;
					//dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
					dataGridView.AllowUserToAddRows = false;
					dataGridView.AllowUserToDeleteRows = false;
					dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
					dataGridView.Name = "dataGridView1";
					dataGridView.ReadOnly = true;
					dataGridView.Size = new System.Drawing.Size(700, 400);
					dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
					DataGridViewColumn Column1 = new DataGridViewColumn
					{
						HeaderText = "#",
						Name = "Column1",
						ReadOnly = true,
						CellTemplate = new DataGridViewTextBoxCell()
					};
					DataGridViewLinkColumn Column2 = new DataGridViewLinkColumn
					{
						HeaderText = "ФИО",
						Name = "Column1",
						AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
						UseColumnTextForLinkValue = true,
						LinkColor = Color.Blue,
						VisitedLinkColor = Color.Blue,
						CellTemplate = new DataGridViewLinkCell()
					};
					DataGridViewColumn Column3 = new DataGridViewColumn
					{
						HeaderText = "Организация",
						Name = "Column1",
						ReadOnly = true,
						AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
						CellTemplate = new DataGridViewTextBoxCell()
					};
					dataGridView.Columns.Add(Column1);
					dataGridView.Columns.Add(Column2);
					dataGridView.Columns.Add(Column3);
					int row = 0;

					foreach (var room in section.Rooms)
					{

					//	List<ResidentsRooms> residentsRooms = db.GetTable<ResidentsRooms>().Where(r => r.RoomId == room.RoomId).ToList();
						dataGridView.Rows.Add(room.Seats);
						for (int i = 0; i < room.Seats; i++)
						{
							dataGridView.Rows[row].Cells[0].Value = room.Number + "/ " + room.RoomId;
							//		Resident resident = residentsRooms.Residents.ElementAtOrDefault(i);
							//Room resident = room.RoomResidents.ElementAtOrDefault(i);
							RoomResidents roomResidents = room.RoomResidents.ElementAtOrDefault(i);
							Resident resident = null;
							if (roomResidents != null)
							{
								resident = db.GetTable<Resident>().Single(r => r.ResidentId == roomResidents.ResidentId);
							}
							//	Resident resident = db.GetTable<Resident>().Single(r => r.ResidentId ==  room.Residents.ElementAtOrDefault(i);
							dynamic tagObject = new System.Dynamic.ExpandoObject();
							if (resident != null)
							{
								string fullName = resident.Surname.ToString() + " " + resident.Name.ToString() + " " + resident.Patronymic.ToString() + " " + room.RoomId.ToString();
								tagObject.residentId = resident.ResidentId;
								tagObject.roomId = 0;
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
					myTabPage.Controls.Add(dataGridView);
					sectionsTabControl.TabPages.Add(myTabPage);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlConnection.Close();
			}

		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
		//	loginForm.Show();
		}

		private void OrganizationsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OrganizationsForm organizationsForm = new OrganizationsForm();
			organizationsForm.Show();
		}

		private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (e.ColumnIndex == 1)
			{
				DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
				dynamic tagObject = cell.Tag;
				if (tagObject.residentId != 0)
				{
					ResidentForm.ShowDialog(tagObject.residentId);
				}
				else if (tagObject.roomId != 0)
				{
					ResidentForm.ShowDialog(tagObject.roomId, 0);
				}
			}
		}
	}
}
