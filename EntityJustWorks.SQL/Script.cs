using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Data;

// EntityJustWorks.SQL - Provides entity/object to data mapping functions for SQL repositories.
namespace EntityJustWorks.SQL
{
	/// <summary>
	/// SQL Script Generation Class
	/// </summary>
	public static class Script
	{
		/// <summary>
		/// Creates a SQL script that inserts the values of the specified classes' public properties into a table.
		/// </summary>
		public static string InsertInto<T>(params T[] ClassObjects) where T : class
		{
			DataTable table = Map.ClassToDatatable<T>(ClassObjects);
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

				result.AppendFormat("INSERT INTO [{0}] {1} VALUES {2}", Table.TableName, columns, values);
			}

			return result.ToString();
		}

		/// <summary>
		/// Creates a SQL script that creates a table where the column names match the specified class's public properties.
		/// </summary>
		public static string CreateTable<T>(params T[] ClassObjects) where T : class
		{
			DataTable table = Map.ClassToDatatable<T>(ClassObjects);
			return Script.CreateTable(table);
		}

		/// <summary>
		/// Creates a SQL script that creates a table where the columns matches that of the specified DataTable.
		/// </summary>
		public static string CreateTable(DataTable Table)
		{
			if (Helper.IsValidDatatable(Table, IgnoreRows: true))
				return string.Empty;

			StringBuilder result = new StringBuilder();
			result.AppendFormat("CREATE TABLE [{0}] ({1}", Table.TableName, Environment.NewLine);

			bool FirstTime = true;
			foreach (DataColumn column in Table.Columns.OfType<DataColumn>())
			{
				if (FirstTime) FirstTime = false;
				else
					result.Append(",");

				result.AppendFormat("[{0}] {1} {2}NULL{3}",
					column.ColumnName,
					GetDataTypeString(column.DataType),
					column.AllowDBNull ? "" : "NOT ",
					Environment.NewLine
				);
			}
			result.AppendFormat(") ON [PRIMARY]{0}GO", Environment.NewLine);

			return result.ToString();
		}

		/// <summary>
		/// Returns the SQL data type equivalent, as a string for use in SQL script generation methods.
		/// </summary>
		private static string GetDataTypeString(Type DataType)
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
