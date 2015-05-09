/* 
 * EntityJustWorks.SQL - C# class object to/from SQL database
 * 
 * 
 *  Full code and more available @
 *    http://www.csharpprogramming.tips
 * 
 * 
 */
using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;

// EntityJustWorks.SQL - Provides entity/object to data mapping functions for SQL repositories.
namespace EntityJustWorks.SQL
{
	/// <summary>
	/// SQL Script Generation Class
	/// </summary>
	public static class SQLScript
	{
		/// <summary>
		/// Creates a SQL script that inserts the values of the specified classes' public properties into a table.
		/// </summary>
		public static string InsertInto<T>(params T[] ClassObjects) where T : class
		{
			DataTable table = Table.FromClassInstanceCollection<T>(ClassObjects);
			return InsertInto(table);   // We don't need to check IsValidDatatable() because InsertInto does
		}

		/// <summary>
		/// Creates a SQL script that inserts the cell values of a DataTable's DataRows into a table.
		/// </summary>
		public static string InsertInto(DataTable Table)
		{
			if (!Helper.IsValidDatatable(Table))
				return string.Empty;

			StringBuilder result = new StringBuilder();
			foreach (DataRow row in Table.Rows)
			{
				if (row == null || row.Table.Columns.Count < 1 || row.ItemArray.Length < 1)
					return string.Empty;

				string columns = Helper.RowToColumnString(row);
				string values = Helper.RowToValueString(row);

				if (string.IsNullOrWhiteSpace(columns) || string.IsNullOrWhiteSpace(values))
					return string.Empty;

				result.AppendLine(string.Format("INSERT INTO [{0}]", Table.TableName));
				result.AppendLine(string.Format("   {0}", columns));
				result.AppendLine("VALUES");
				result.AppendLine(string.Format("   {0}", values));
			}

			return result.ToString();
		}

		/// <summary>
		/// Creates a SQL script that creates a table where the column names match the specified class's public properties.
		/// </summary>
		public static string CreateTable<T>(params T[] ClassObjects) where T : class
		{
			DataTable table = Table.FromClassInstanceCollection<T>(ClassObjects);
			return SQLScript.CreateTable(table);
		}

		/// <summary>
		/// Creates a SQL script that creates a table where the columns matches that of the specified DataTable.
		/// </summary>
		public static string CreateTable(DataTable Table)
		{
			if (!Helper.IsValidDatatable(Table, ignoreZeroRows: true))
				return string.Empty;

			StringBuilder result = new StringBuilder();
			result.AppendLine(string.Format("CREATE TABLE [{0}] (", Table.TableName));
			result.Append("   ");

			bool FirstTime = true;
			foreach (DataColumn column in Table.Columns.OfType<DataColumn>())
			{
				if (FirstTime)
					FirstTime = false;
				else
					result.Append("   ,");

				result.AppendLine(string.Format("[{0}] {1} {2}",
					column.ColumnName, // 0
					GetSQLTypeAsString(column.DataType), // 1
					column.AllowDBNull ? "NULL" : "NOT NULL" // 2
				));
			}
			result.AppendLine(") ON [PRIMARY]");
			result.AppendLine("GO");

			// Build an ALTER TABLE script that adds keys to a table that already exists.
			if (Table.PrimaryKey.Length > 0)
				result.Append(BuildKeysScript(Table));

			return result.ToString();
		}

		/// <summary>
		/// Builds an ALTER TABLE script that adds a primary or composite key to a table that already exists.
		/// </summary>
		private static string BuildKeysScript(DataTable Table)
		{
			// Already checked by public method CreateTable. Un-comment if making the method public
			// if (Helper.IsValidDatatable(Table, IgnoreZeroRows: true)) return string.Empty;
			if (Table.PrimaryKey.Length < 1) 
				return string.Empty;

			StringBuilder result = new StringBuilder();

			if (Table.PrimaryKey.Length == 1)
			{
				result.AppendLine(string.Format("ALTER TABLE {0}", Table.TableName));
				result.AppendLine(string.Format("ADD PRIMARY KEY ({0})", Table.PrimaryKey[0].ColumnName));
			}
			else
			{
				List<string> compositeKeys = Table.PrimaryKey.OfType<DataColumn>().Select(dc => dc.ColumnName).ToList();
				string keyName = compositeKeys.Aggregate((a, b) => a + b);
				string keys = compositeKeys.Aggregate((a, b) => string.Format("{0}, {1}", a, b));
				result.AppendLine(string.Format("ALTER TABLE {0}", Table.TableName));
				result.AppendLine(string.Format("ADD CONSTRAINT pk_{0} PRIMARY KEY ({1})", keyName, keys));
			}
			result.AppendLine("GO");

			return result.ToString();
		}

		/// <summary>
		/// Returns the SQL data type equivalent, as a string for use in SQL script generation methods.
		/// </summary>
		private static string GetSQLTypeAsString(Type DataType)
		{
			switch (DataType.Name)
			{
				case "Boolean": return "[bit]";
				case "Char": return "[char]";
				case "SByte": return "[tinyint]";
				case "Int16": return "[smallint]";
				case "Int32": return "[int]";
				case "Int64": return "[bigint]";
				case "Byte": return "[tinyint] UNSIGNED";
				case "UInt16": return "[smallint] UNSIGNED";
				case "UInt32": return "[int] UNSIGNED";
				case "UInt64": return "[bigint] UNSIGNED";
				case "Single": return "[float]";
				case "Double": return "[double]";
				case "Decimal": return "[decimal]";
				case "DateTime": return "[datetime]";
				case "Guid": return "[uniqueidentifier]";
				case "Object": return "[variant]";
				case "String": return "[nvarchar](250)";
				default: return "[nvarchar](MAX)";
			}
		}
	}
}
