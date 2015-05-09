/* 
 * EntityJustWorks.SQL - C# class object to/from SQL database
 * 
 * 
 *  Full code and more available @
 *    http://www.csharpprogramming.tips
 * 
 * 
 */
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EntityJustWorks.SQL
{
	/// <summary>
	/// SQL Query Helper Class
	/// </summary>
	public static class DatabaseQuery
	{
		/// <summary>
		/// Runs a SQL query and returns the results as a List of the specified class
		/// </summary>
		/// <typeparam name="T">The type the result will be returned as.</typeparam>
		/// <param name="connectionString">The SQL connection string.</param>
		/// <param name="formatString_Query">A SQL command that will be passed to string.Format().</param>
		/// <param name="formatString_Parameters">The parameters for string.Format().</param>
		/// <returns>A List of classes that represent the records returned.</returns>
		public static IList<T> ToClass<T>(string connectionString, string formatString_Query, params object[] formatString_Parameters) where T : class, new()
		{
			IList<T> result = new List<T>();
			DataTable tableQueryResult = ToDataTable(connectionString, string.Format(formatString_Query, formatString_Parameters));
			if (Helper.IsValidDatatable(tableQueryResult))
			{
				result = ClassInstance.FromDataTable<T>(tableQueryResult);
			}
			return result;
		}

		/// <summary>
		/// Executes an SQL query and returns the results as a DataTable.
		/// </summary>
		/// <param name="connectionString">The SQL connection string.</param>
		/// <param name="formatString_Query">A SQL command that will be passed to string.Format().</param>
		/// <param name="formatString_Parameters">The parameters for string.Format().</param>
		/// <returns>The results of the query as a DataTable.</returns>
		public static DataTable ToDataTable(string connectionString, string formatString_Query, params object[] formatString_Parameters)
		{
			try
			{
				DataTable result = new DataTable();

				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
					{
						sqlCommand.CommandText = string.Format(formatString_Query, formatString_Parameters);
						sqlCommand.CommandType = CommandType.Text;

						SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
						sqlAdapter.Fill(result);
					}
				}
				return result;
			}
			catch
			{
				return new DataTable();
			}
		}

		/// <summary>
		/// Executes a non-query SQL command, such as INSERT or DELETE
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="FormatString_Command">The SQL command, as a format string.</param>
		/// <param name="formatString_Parameters">The parameters for the format string.</param>
		/// <returns>The number of rows affected, or -1 on errors.</returns>
		public static int NonQueryCommand(string connectionString, string FormatString_Command, params object[] formatString_Parameters)
		{
			try
			{
				int rowsAffected = 0;

				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
					{
						string commandText = string.Format(FormatString_Command, formatString_Parameters);

						sqlCommand.CommandText = commandText;
						sqlCommand.CommandType = CommandType.Text;
						rowsAffected = sqlCommand.ExecuteNonQuery();
					}
				}

				return rowsAffected;
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// Executes a query, and returns the first column of the first row in the result set returned by the query.
		/// </summary>
		/// <typeparam name="T">The type the result will be returned as.</typeparam>
		/// <param name="connectionString">>The SQL connection string.</param>
		/// <param name="formatString_Query">The SQL query as string.Format string.</param>
		/// <param name="formatString_Parameters">The string.Format parameters.</param>
		/// <returns>The  first column of the first row in the result, converted and casted to type T.</returns>
		public static T ToScalarValue<T>(string connectionString, string formatString_Query, params object[] formatString_Parameters)
		{
			try
			{
				object result = new object();
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
					{
						sqlCommand.CommandText = string.Format(formatString_Query, formatString_Parameters);
						sqlCommand.CommandType = CommandType.Text;

						result = System.Convert.ChangeType(sqlCommand.ExecuteScalar(), typeof(T));
					}
				}
				return (T)result;
			}
			catch
			{
				return (T)new object();
			}
		}
	}
}
