using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityJustWorks.SQL
{
	public partial class DatabaseQuery
	{
		public class StoredProcedure
		{
			public static DataTable QueryToDataTable(string ConnectionString, string StoredProcedureName, params SqlParameter[] SQLParameters)
			{
				try
				{
					DataTable result = new DataTable();

					using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
					{
						using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(StoredProcedureName, sqlConnection))
						{
							sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
							if (SQLParameters != null && SQLParameters.Length > 0)
							{
								sqlAdapter.SelectCommand.Parameters.AddRange(SQLParameters);
							}

							int rowsAdded = sqlAdapter.Fill(result);
							if (rowsAdded > 0 && Helper.IsValidDatatable(result))
							{
								return result;
							}
						}
					}
				}
				catch
				{
				}

				return new DataTable();
			}

			public static int NonQuery(string ConnectionString, string StoredProcedureName, List<SqlParameter> SqlParameters)
			{
				try
				{
					using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
						{
							sqlCommand.CommandType = CommandType.StoredProcedure;
							sqlCommand.CommandText = StoredProcedureName;

							if (SqlParameters != null && SqlParameters.Count > 0)
							{
								sqlCommand.Parameters.AddRange(SqlParameters.ToArray());
							}

							return sqlCommand.ExecuteNonQuery();
						}
					}
				}
				catch
				{
					return -1;
				}
			}

		} // END StoredProcedure
	}
}
