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
			db = new DataContext(sqlConnection); ;
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

					TableLayoutPanel sectionPanel = new TableLayoutPanel();
					//sectionPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
					sectionPanel.ColumnCount = 3;
					sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
					sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
					sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
					sectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
					sectionPanel.Controls.Add(new Label() { Text = "Комната" }, 0, 0);
					sectionPanel.Controls.Add(new Label() { Text = "Житель" }, 1, 0);
					sectionPanel.Controls.Add(new Label() { Text = "Организация" }, 2, 0);
					int row = 1;
					foreach (var room in section.Rooms)
					{
						Label label = new Label() { Text = room.Number.ToString() };
						
						for (int i = 0; i < room.Seats; i++)
						{
							sectionPanel.Controls.Add(label, 0, row+i);
							Resident resident = room.Residents.ElementAtOrDefault(i);

							LinkLabelModified linkLabel = new LinkLabelModified();
							linkLabel.AutoSize = true;
							linkLabel.Name = "linkLabel";
							linkLabel.Size = new System.Drawing.Size(55, 13);
							linkLabel.TabIndex = 3;
							linkLabel.TabStop = true;
							linkLabel.Text = "Пусто";
							linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
							if (resident != null)
							{
								string fullName = resident.Surname.ToString() + " " + resident.Name.ToString() + " " + resident.Patronymic.ToString();
								linkLabel.Text = fullName;
								linkLabel.residentId = resident.ResidentId;
								string organizationName = resident.Organization.Name.ToString();
								sectionPanel.Controls.Add(linkLabel, 1, row + i);
								sectionPanel.Controls.Add(new Label() { Text = organizationName + (i + 1).ToString() }, 2, row + i);
							}
							else
							{
								linkLabel.roomId = room.RoomId;
								sectionPanel.Controls.Add(linkLabel, 1, row + i);
								sectionPanel.Controls.Add(new Label() { Text = "Пусто" + (i + 1).ToString() }, 2, row + i);
							}
						}
						//sectionPanel.SetRowSpan(label, room.Seats);
						row += room.Seats;
					}
					
					sectionPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;

					sectionPanel.Name = "sectionPanel" + section.Number.ToString();
					//sectionPanel.RowCount = section.NumberOfRooms;
					sectionPanel.Size = new System.Drawing.Size(600, 400);
					myTabPage.Controls.Add(sectionPanel);
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

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			int residentId = ((LinkLabelModified)sender).residentId;
			int roomId = ((LinkLabelModified)sender).roomId;
			if (residentId != 0)
			{
				ResidentForm.ShowDialog(residentId);
				//MessageBox.Show("residentId:" + residentId.ToString());
			}
			else if (roomId != 0)
			{
				//MessageBox.Show("roomId:" + roomId.ToString());
			}
		}

	}
}
