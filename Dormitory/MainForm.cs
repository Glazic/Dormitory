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

		//public void LoadTabs()
		//{
		//	//dataAdapter = new SqlDataAdapter("SELECT * FROM ORGANIZATIONS", sqlConnection);
		//	//dataTable = new DataTable();
		//	//dataAdapter.Fill(dataTable);
		//	//organizationsDataGridView.DataSource = dataTable;

		//	string sqlExpression = "SELECT * FROM Sections";
		//	try
		//	{
		//		sqlConnection.Open();
		//		SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
		//		SqlDataReader reader = command.ExecuteReader();
		//		if (reader.HasRows) // если есть данные
		//		{
		//			// выводим названия столбцов
		//			//Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
		//			while (reader.Read()) // построчно считываем данные
		//			{
		//				object sectionId = reader.GetValue(0);
		//				Int32.TryParse(reader.GetValue(1).ToString(), out int number);
		//				Int32.TryParse(reader.GetValue(2).ToString(), out int numberOfRooms);					
		//				//string title = "TabPage " + (sectionsTabControl.TabCount + 1).ToString();
		//				TabPage myTabPage = new TabPage(number.ToString());

		//				TableLayoutPanel sectionPanel = new TableLayoutPanel();
		//				//sectionPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
		//				sectionPanel.ColumnCount = 3;
		//				sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
		//				sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
		//				sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
		//				sectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
		//				sectionPanel.Controls.Add(new Label() { Text = "Комната" }, 0, 0);
		//				sectionPanel.Controls.Add(new Label() { Text = "Житель" }, 1, 0);
		//				sectionPanel.Controls.Add(new Label() { Text = "Организация" }, 2, 0);
		//				for (int i = 1; i <= numberOfRooms; i++)
		//				{
		//					sectionPanel.Controls.Add(new Label() { Text = i.ToString() }, 0, i);
		//					TableLayoutPanel roomPanel = new TableLayoutPanel();
		//					roomPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
		//					sectionPanel.Controls.Add(roomPanel, 1, i);
		//					sectionPanel.SetColumnSpan(roomPanel, 2);
		//					sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		//					sectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		//					sectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
		//				}

		//				sectionPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

		//				sectionPanel.Name = "sectionPanel" + number.ToString();
		//				sectionPanel.RowCount = numberOfRooms;
		//				sectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		//				sectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		//				sectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		//				sectionPanel.Size = new System.Drawing.Size(600, 400);
		//				myTabPage.Controls.Add(sectionPanel);


		//				sectionsTabControl.TabPages.Add(myTabPage);


		//				//MessageBox.Show(sectionId.ToString() + " " + number.ToString() + " " + numberOfRooms.ToString());
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//	}
		//	finally
		//	{
		//		sqlConnection.Close();
		//	}

		//}


	}
}
