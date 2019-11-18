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
	public partial class HistoryRecordsForm : Form
	{
		SqlDataAdapter dataAdapter;
		DataTable dataTable = new DataTable("History");

		public HistoryRecordsForm()
		{
			InitializeComponent();
		}

		private void HistoryRecordsForm_Load(object sender, EventArgs e)
		{
			LoadDataGrid();
		}
		// Загрузка таблицы с записями действий пользователей
		public void LoadDataGrid()
		{
			dataAdapter = new SqlDataAdapter("SELECT HistoryRecordId as [ИД], " +
				"UserName as [Пользователь], Action as [Действие], DateOfAction as [Время] " +
				"FROM HistoryRecords", HistoryRecordsController.sqlConnection);
			dataTable.Clear();
			dataAdapter.Fill(dataTable);
			historyDataGridView.DataSource = dataTable;
			historyDataGridView.Columns[0].Width = 50;
			historyDataGridView.Columns[1].Width = 100;
			historyDataGridView.Columns[2].Width = 480;
			historyDataGridView.Columns[3].Width = 200;
			historyDataGridView.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
			historyDataGridView.ClearSelection();
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
		// Удаление истории действий пользователя
		private void clearButton_Click(object sender, EventArgs e)
		{
			DateTime dateTime = DateTime.Now.AddSeconds(-15);

			string sqlClear = "DELETE FROM HistoryRecords " +
				$"WHERE [DateOfAction] <= '{dateTime}' ";
			try
			{
				SqlCommand cmd = new SqlCommand(sqlClear, HistoryRecordsController.sqlConnection);
				HistoryRecordsController.sqlConnection.Open();
				cmd.ExecuteNonQuery();
				LoadDataGrid();
			}
			catch (Exception ex)
			{
				SystemSounds.Exclamation.Play();
				MessageBox.Show("Ошибка удаления. \n" + ex.Message);
			}
			finally
			{
				HistoryRecordsController.sqlConnection.Close();
			}
		}
		// Обработка нажатия ячейки таблцы для идентификации записи
		private void historyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView dataRow = (this.BindingContext[dataTable] as CurrencyManager).Current as DataRowView;
			if (dataRow != null)
			{
				actionTextBox.Text = dataRow[2].ToString();
			}
		}
	}
}
