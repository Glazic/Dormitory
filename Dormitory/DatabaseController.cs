using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
	class DatabaseController
	{
		SqlConnection sqlConnection = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True");

		#region organizations
		public SqlDataAdapter SelectAllOrganizations()
		{
			return new SqlDataAdapter("SELECT * FROM Organizations", sqlConnection);
		}

		public void InsertOrganization(string name, string address, string requisites)
		{
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

		public void UpdateOrganization(string name, string address, string requisites, int id)
		{
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

		public void DeleteOrganization(int id)
		{
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
		#endregion

	}
}
