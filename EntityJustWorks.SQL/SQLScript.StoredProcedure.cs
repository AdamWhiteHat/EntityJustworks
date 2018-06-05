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
using System.Text;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

// EntityJustWorks.SQL - Provides entity/object to data mapping functions for SQL repositories.
namespace EntityJustWorks.SQL
{
	public static partial class SQLScript
	{
		public static class StoredProcedure
        {
			/// <summary>
			/// Returns an SQL script that creates an INSERT INTO stored procedure from a DataTable, with the parameter names matching the ColumnNames 
			/// </summary>
            public static string Insert(DataTable Table)
            {
                return GenerateStoredProcedure(Table, GenerateInsertInto(Table));
            }

			/// <summary>
			/// /// Returns an SQL script that creates an UPDATE stored procedure from a DataTable, with the parameter names matching the ColumnNames 
			/// </summary>
            public static string Update(DataTable Table, string WhereClause)
            {
				DataRowToSqlParameters(Table.Rows[0]);
                return GenerateStoredProcedure(Table, GenerateUpdate(Table, WhereClause));
            }

			/// <summary>
			/// <para>Generates a List&lt;SqlParameter from a DataRow</para>
			/// <para>The quantity, type and name of the parameters will exactly match that of the Columns collection of the DataTable that the DataRow belongs to.</para>
			/// <para>If the DataRow does not belong to a DataTable, the return value will be an empty List.</para>
			/// </summary>
			/// <param name="Row">The DataRow to make the SqlParameters for.</param>
			public static List<SqlParameter> DataRowToSqlParameters(DataRow Row)
			{
				List<SqlParameter> result = new List<SqlParameter>();

				if (Row == null || Row.ItemArray.Length < 1)
				{
					return result;
				}

				foreach (DataColumn column in Row.Table.Columns)
				{
					SqlParameter param = new SqlParameter();
					param.ParameterName = string.Format("@{0}", column.ColumnName);
					param.SqlDbType = SQLScript.GetSqlDbType(column.DataType);
					param.Value = Row[column];
					result.Add(param);
				}

				return result;
			}

			private static string GenerateStoredProcedure(DataTable Table, string Body)
			{
				StringBuilder result = new StringBuilder();

				result.AppendLine("USE [{DatabaseName}]");
				result.AppendLine("GO");
				result.AppendLine();
				result.AppendLine("CREATE PROCEDURE [dbo].[{StoredProcedureName}]");
				result.AppendLine("(");
				result.AppendLine( string.Concat("\t", GenerateParameterList(Table)) );
				result.AppendLine(")");
				result.AppendLine("AS");
				result.AppendLine("BEGIN");
				result.AppendLine(Body);
				result.AppendLine("END");

				return result.ToString();
			}

			private static string GenerateParameterList(DataTable Table)
            {
                if (!Helper.IsValidDatatable(Table))
                    return string.Empty;

                StringBuilder result = new StringBuilder();
                foreach (DataColumn column in Table.Columns)
                {
                    if (result.Length != 0)
                        result.Append("\n,");	// Add CR, TAB, COMMA

                    result.AppendFormat("@{0} {1}", column.ColumnName, GetSQLTypeAsString(column.DataType));
                    result.AppendLine();
                }
				
                return result.ToString();
            }

            private static string GenerateInsertInto(DataTable Table)
            {
                IEnumerable<object> columnNames = Table.Columns.OfType<DataColumn>().Select(col => col.ColumnName);
                IEnumerable<object> parameters = columnNames.Select(col => (object)string.Format("@{0}", col));

                DataTable procedureTable = new DataTable(Table.TableName);
                foreach (string name in columnNames)
                {
                    procedureTable.Columns.Add(name, typeof(string));
                }

                DataRow parameterRow = procedureTable.NewRow();
                parameterRow.ItemArray = parameters.ToArray();

                procedureTable.Rows.Add(parameterRow);

                string body = InsertInto(procedureTable);
                body = body.Replace("'", "");

                return body;
            }

            private static string GenerateUpdate(DataTable Table, string WhereClause)
            {
                if (!Helper.IsValidDatatable(Table))
                    return string.Empty;

                IEnumerable<string> columns = Table.Columns.OfType<DataColumn>().Select(col => col.ColumnName);

                StringBuilder result = new StringBuilder();

                foreach (string column in columns)
                {
                    if (result.Length != 0)
                        result.Append("\t,");

                    result.AppendLine(string.Format("[{0}] = @{1}", column, column));
                }

                result.Insert(0, "\t");
                result.Insert(0, Environment.NewLine);
                result.Insert(0, "SET");
                result.Insert(0, Environment.NewLine);
                result.Insert(0, string.Format("UPDATE [{0}]", Table.TableName));

                result.AppendLine("WHERE");
                result.AppendLine(string.Format("\t{0}", WhereClause));

                return result.ToString();
            }

        } // END StoredProcedure
	}
}