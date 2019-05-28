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
		//private SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");
		//DataContext db;
		//private string connectionString;
		//private string fileName = "test.sdf";
		//private string password = "test";


		public TestForm()
		{
			InitializeComponent();
		//	db = new DataContext(sqlConnection);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//SqlCeEngine en = new SqlCeEngine(connectionString);
			//en.CreateDatabase();
		}
	}
}
