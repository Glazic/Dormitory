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
using static System.Windows.Forms.LinkLabel;

namespace Dormitory
{
	public partial class TestForm : Form
	{
		private SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		private DataTable moviesParticipantsDataTable;
		private DataTable employeesDataTable;
		DataContext db;
		
		
		public TestForm()
		{
			InitializeComponent();
			db = new DataContext(sqlConnection);
		}

		

		public void LoadTabs()
		{
			//dataGridView.Columns.Clear();
			//dataGridView.Rows.Clear();
			//dataAdapter = new SqlDataAdapter("SELECT * FROM ORGANIZATIONS", sqlConnection);
			//dataTable = new DataTable();
			//dataAdapter.Fill(dataTable);
			//organizationsDataGridView.DataSource = dataTable;
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
					//dataGridView.Location = new System.Drawing.Point(32, 285);
					dataGridView.Name = "dataGridView1";
					dataGridView.ReadOnly = true;
					dataGridView.Size = new System.Drawing.Size(700, 400);
					//dataGridView.TabIndex = 1;
					dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
					DataGridViewColumn Column1 = new DataGridViewColumn
					{
						HeaderText = "#",
						Name = "Column1",
						ReadOnly = true,
						CellTemplate = new DataGridViewTextBoxCell()
					};
					DataGridViewLinkColumn Column2 = new DataGridViewLinkColumn
					{
						HeaderText = "FIO",
						Name = "Column1",
					//	ReadOnly = true,
						AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
						UseColumnTextForLinkValue = true,
					//	ActiveLinkColor = Color.White,
					//	LinkBehavior = LinkBehavior.SystemDefault,
						LinkColor = Color.Blue,
					//	TrackVisitedState = true,
						VisitedLinkColor = Color.Blue,
						CellTemplate = new DataGridViewLinkCell()
					};
					DataGridViewColumn Column3 = new DataGridViewColumn
					{
						HeaderText = "Org",
						Name = "Column1",
						ReadOnly = true,
						AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
						CellTemplate = new DataGridViewTextBoxCell()
					};
					dataGridView.Columns.Add(Column1);
					//	dataGridView1.Columns.Add("sa", "das");
					dataGridView.Columns.Add(Column2);
					dataGridView.Columns.Add(Column3);
					int k = 0;
					//foreach (var section in sections)
					//{
					int row = 0;
					foreach (var room in section.Rooms)
					{
						dataGridView.Rows.Add(room.Seats);
						for (int i = 0; i < room.Seats; i++)
						{
							Resident resident = room.Residents.ElementAtOrDefault(i);
							dynamic kek = new System.Dynamic.ExpandoObject();
							if (resident != null)
							{
								string fullName = resident.Surname.ToString() + " " + resident.Name.ToString() + " " + resident.Patronymic.ToString();
								//linkLabel.Text = fullName;
								//linkLabel.residentId = resident.ResidentId;
								kek.residentId = resident.ResidentId;
								kek.roomId = 0;
								string organizationName = resident.Organization.Name.ToString();
								dataGridView.Rows[row + i].Cells[1].Value = fullName;
								dataGridView.Rows[row + i].Cells[1].Tag = kek;
								dataGridView.Rows[row + i].Cells[2].Value = organizationName;
								//sectionPanel.Controls.Add(linkLabel, 1, row + i);
								//sectionPanel.Controls.Add(new Label() { Text = organizationName + (i + 1).ToString() }, 2, row + i);
							}
							else
							{
								kek.residentId = 0;
								kek.roomId = room.RoomId;
								dataGridView.Rows[row + i].Cells[1].Value = "Добавить";
								dataGridView.Rows[row + i].Cells[1].Tag = kek;
								dataGridView.Rows[row + i].Cells[2].Value = "Пусто";
								//	linkLabel.roomId = room.RoomId;
								//sectionPanel.Controls.Add(linkLabel, 1, row + i);
								//sectionPanel.Controls.Add(new Label() { Text = "Пусто" + (i + 1).ToString() }, 2, row + i);
							}
							dataGridView.Rows[row].Cells[0].Value = room.Number;
							
						}						
						k++;
						row += room.Seats;
					}
					myTabPage.Controls.Add(dataGridView);
					tabControl1.TabPages.Add(myTabPage);
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

		private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int residentId;// = ((DataGridView)sender).residentId;
			DataGridView dataGridView = (DataGridView)sender;
			DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			dynamic kek = cell.Tag;
			if (kek.residentId != 0)
			{
				
				MessageBox.Show("residentId:" + kek.residentId.ToString());
			}
			else if (kek.roomId != 0)
			{
				MessageBox.Show("roomId:" + kek.roomId.ToString());
			}
			//if (e.ColumnIndex == 0)
			//{
			//	residentId = ((DataGridViewCell)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
			//MessageBox.Show("residentId:" + residentId);
			//}
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string residentId = ((LinkLabel)sender).Text;

			MessageBox.Show("residentId:" + residentId);

		}

		private void button2_Click(object sender, EventArgs e)
		{
			LoadTabs();
		}
	}
}
