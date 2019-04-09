using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;

namespace Dormitory
{
	public partial class OrganizationsForm : Form
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		SqlCommand cmd;
		SqlDataAdapter dataAdapter;
		DataTable dataTable;
		public OrganizationsForm()
		{
			InitializeComponent();
		}

		//public void Load()
		//{
		//	SqlDataAdapter adapter = new SqlDataAdapter(
		//			 "SELECT * FROM Sections; SELECT * FROM Rooms", sqlConnection);
		//	adapter.TableMappings.Add("Table", "Section");
		//	adapter.TableMappings.Add("Table1", "Room");

		//	adapter.Fill(ds);
		//}

		private void OrganizationsForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "dormitoryDataSet.Organizations". При необходимости она может быть перемещена или удалена.
			//this.organizationsTableAdapter.Fill(this.dormitoryDataSet.Organizations);
			LoadDataGrid();
		}

		public void LoadDataGrid()
		{
			dataAdapter = new SqlDataAdapter("SELECT * FROM Organizations", sqlConnection);
			dataTable = new DataTable();
			dataAdapter.Fill(dataTable);
			organizationsDataGridView.DataSource = dataTable;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			string name = nameTextBox.Text;
			string address = addressTextBox.Text;
			string requisites = requisitesTextBox.Text;

			string sqlExpression = "sp_InsertOrganization";

			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
				command.CommandType = CommandType.StoredProcedure;

				SqlParameter nameParam = new SqlParameter
				{
					ParameterName = "@Name",
					Value = name
				};
				command.Parameters.Add(nameParam);

				SqlParameter addressParam = new SqlParameter
				{
					ParameterName = "@Address",
					Value = address
				};
				command.Parameters.Add(addressParam);

				SqlParameter requisitesParam = new SqlParameter
				{
					ParameterName = "@Requisites",
					Value = requisites
				};
				command.Parameters.Add(requisitesParam);
				command.ExecuteNonQuery();
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				sqlConnection.Close();
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		private void organizationsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTable] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				idTextBox.Text = dataRow[0].ToString();
				nameTextBox.Text = dataRow[1].ToString();
				addressTextBox.Text = dataRow[2].ToString();
				requisitesTextBox.Text = dataRow[3].ToString();
			}
			try
			{	
				//string movieId = moviesTextBoxId.Text;
				//moviesParticipantsTextBoxId.Text = "";
				//moviesParticipantsTextBoxParticipantId.Text = "";
				//moviesParticipantsTextBoxActivityId.Text = "";
				//moviesParticipantsTextBoxRoleId.Text = "";

				//string query = $"SELECT [Genre] FROM View_MoviesGenres WHERE [id movie] = {movieId}";
				//SqlCommand cmd = new SqlCommand(query, sqlConnection);
				//sqlConnection.Open();
				//moviesGenresListView.Clear();
				//SqlDataReader dr = cmd.ExecuteReader();
				//while (dr.Read())
				//{
				//	ListViewItem item = new ListViewItem(dr.GetValue(0).ToString());
				//	moviesGenresListView.Items.Add(item);
				//}
				//dr.Close();

				//string query2 = $"SELECT [Name] FROM Genres WHERE [id] " +
				//	$"NOT IN (SELECT[id genre] FROM View_MoviesGenres WHERE [id movie] = {movieId})";
				//SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
				//moviesComboBoxGenres.Items.Clear();
				//SqlDataReader dr2 = cmd2.ExecuteReader();
				//while (dr2.Read())
				//{
				//	moviesComboBoxGenres.Items.Add(dr2.GetValue(0).ToString());
				//}
				//dr2.Close();

				//string query3 = $"SELECT [Language] FROM View_MoviesLanguages WHERE [id movie] = {movieId}";
				//SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
				//moviesLanguagesListView.Clear();
				//SqlDataReader dr3 = cmd3.ExecuteReader();
				//while (dr3.Read())
				//{
				//	ListViewItem item = new ListViewItem(dr3.GetValue(0).ToString());
				//	moviesLanguagesListView.Items.Add(item);
				//}
				//dr3.Close();

				//string query4 = $"SELECT [Name] FROM Languages WHERE [id] " +
				//	$"NOT IN (SELECT[id language] FROM View_MoviesLanguages WHERE [id movie] = {movieId})";
				//SqlCommand cmd4 = new SqlCommand(query4, sqlConnection);
				//moviesComboBoxLanguages.Items.Clear();
				//SqlDataReader dr4 = cmd4.ExecuteReader();
				//while (dr4.Read())
				//{
				//	moviesComboBoxLanguages.Items.Add(dr4.GetValue(0).ToString());
				//}
				//dr4.Close();

				//moviesParticipantsTextBoxMovieId.Text = movieId.ToString();
				//updateMoviesParticipantsDataGridView(Int32.Parse(movieId));
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

		private void saveButton_Click(object sender, EventArgs e)
		{
			Int32.TryParse(idTextBox.Text, out int id);
			string name = nameTextBox.Text;
			string address = addressTextBox.Text;
			string requisites = requisitesTextBox.Text;

			string sqlExpression = "sp_UpdateOrganization";
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
				command.CommandType = CommandType.StoredProcedure;

				SqlParameter idParam = new SqlParameter
				{
					ParameterName = "@Id",
					Value = id
				};
				command.Parameters.Add(idParam);

				SqlParameter nameParam = new SqlParameter
				{
					ParameterName = "@Name",
					Value = name
				};
				command.Parameters.Add(nameParam);

				SqlParameter addressParam = new SqlParameter
				{
					ParameterName = "@Address",
					Value = address
				};
				command.Parameters.Add(addressParam);

				SqlParameter requisitesParam = new SqlParameter
				{
					ParameterName = "@Requisites",
					Value = requisites
				};
				command.Parameters.Add(requisitesParam);

				command.ExecuteNonQuery();
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				sqlConnection.Close();
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			Int32.TryParse(idTextBox.Text, out int id);
			string sqlExpression = "sp_DeleteOrganization";
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
				command.CommandType = CommandType.StoredProcedure;

				SqlParameter IdParam = new SqlParameter
				{
					ParameterName = "@Id",
					Value = id
				};
				command.Parameters.Add(IdParam);
				command.ExecuteNonQuery();
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				sqlConnection.Close();
			}
			finally
			{
				sqlConnection.Close();
			}
		}
	}
}
