/* 
 * EntityJustWorks.SQL - C# class object to/from SQL database
 * 
 * 
 *  Full code and more available @
 *    https://csharpcodewhisperer.blogspot.com
 *    
 *  Or check for updates @
 *    https://github.com/AdamRakaska/EntityJustworks
 * 
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EntityJustWorks.SQL
{
	public partial class DatabaseQuery
	{
		public class StoredProcedure
		{
			public static DataTable QueryToDataTable(string connectionString, string storedProcedureName, params SqlParameter[] sqlParameters)
			{
				try
				{
					DataTable result = new DataTable();

					using (SqlConnection sqlConnection = new SqlConnection(connectionString))
					{
						using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(storedProcedureName, sqlConnection))
						{
							sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
							if (sqlParameters != null && sqlParameters.Length > 0)
							{
								sqlAdapter.SelectCommand.Parameters.AddRange(sqlParameters);
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

			public static int NonQuery(string connectionString, string storedProcedureName, List<SqlParameter> sqlParameters)
			{
				try
				{
					using (SqlConnection sqlConnection = new SqlConnection(connectionString))
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
						{
							sqlCommand.CommandType = CommandType.StoredProcedure;
							sqlCommand.CommandText = storedProcedureName;

							if (sqlParameters != null && sqlParameters.Count > 0)
							{
								sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
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
