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
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EntityJustWorks.SQL
{
	/// <summary>
	/// Conversion, validation, sanitization helper functions.
	/// </summary>
	public static class Helper
	{
		/// <summary>
		/// Indicates whether a specified DataTable is null, has zero columns, or (optionally) zero rows.
		/// </summary>
		/// <param name="dataTable">DataTable to check.</param>
		/// <param name="ignoreZeroRows">When set to true, the function will return true even if the table's row count is equal to zero.</param>
		/// <returns>False if the specified DataTable null, has zero columns, or zero rows, otherwise true.</returns>
		public static bool IsValidDatatable(DataTable dataTable, bool ignoreZeroRows = false)
		{
			if (dataTable == null)
				return false;
			if (dataTable.Columns == null ||dataTable.Columns.Count == 0)
				return false;
			if (ignoreZeroRows)
				return true;
			if (dataTable.Rows == null || dataTable.Rows.Count == 0)
				return false;

			return true;
		}

		public static List<SqlParameter> DataRowToSqlParameters(DataRow Row)
		{
			return SQLScript.StoredProcedure.DataRowToSqlParameters(Row);
		}

		/// <summary>
		/// Returns all the column names of the specified DataRow in a string delimited like and SQL INSERT INTO statement.
		/// Example: ([FullName], [Gender], [BirthDate])
		/// </summary>
		/// <returns>A string formatted like the columns specified in an SQL 'INSERT INTO' statement.</returns>
        public static string TableToColumnsString(DataTable Table)
		{
            if (!IsValidDatatable(Table))
				return string.Empty;

            IEnumerable<string> collection = Table.Columns.OfType<DataColumn>().Select(col => col.ColumnName);
			return ListToDelimitedString(collection, "([", "], [", "])");
		}

		/// <summary>
		/// Returns all the values the specified DataRow in as a string delimited like and SQL INSERT INTO statement.
		/// Example: ('John Doe', 'M', '10/3/1981'')
		/// </summary>
		/// <returns>A string formatted like the values specified in an SQL 'INSERT INTO' statement.</returns>
		public static string RowToValueString(DataRow dataRow)
		{
			IEnumerable<string> collection = dataRow.ItemArray.Select(item => Convert.ToString(item));				
			return ListToDelimitedString(collection, "('", "', '", "')");
		}

		/// <summary>
		/// Enumerates a collection as delimited collection of strings.
		/// </summary>
		/// <typeparam name="T">The Type of the collection.</typeparam>
		/// <param name="collection">An Enumerator to a collection to populate the string.</param>
		/// <param name="prefix">The string to prefix the result.</param>
		/// <param name="delimiter">The string that will appear between each item in the specified collection.</param>
		/// <param name="postFix">The string to postfix the result.</param>			
		public static string ListToDelimitedString<T>(IEnumerable<T> collection, string prefix, string delimiter, string postFix)
		{
			if (IsCollectionEmpty<T>(collection)) return string.Empty;

			StringBuilder result = new StringBuilder();
			foreach (T item in collection)
			{
				if (result.Length != 0)
					result.Append(delimiter);	// Add comma

				result.Append(EscapeSingleQuotes(item as String));
			}
			if (result.Length < 1) return string.Empty;

			result.Insert(0, prefix);
			result.Append(postFix);

			return result.ToString();
		}

		/// <summary>
		/// Returns a new string in which all occurrences of the single quote character in the current instance are replaced with a back-tick character.
		/// </summary>
		public static string EscapeSingleQuotes(string dirtyString)
		{
			return dirtyString.Replace('\'', '`'); // Replace with back-tick
		}

		/// <summary>
		/// Indicates whether a specified Enumerable collection is null or an empty collection.
		/// </summary>
		/// <typeparam name="T">The specified type contained in the collection.</typeparam>
		/// <param name="iInput">An Enumerator to the collection to check.</param>
		/// <returns>True if the specified Enumerable collection is null or empty, otherwise false.</returns>
		public static bool IsCollectionEmpty<T>(IEnumerable<T> iInput)
		{
			return (iInput == null || iInput.Count() < 1) ? true : false;
		}

		/// <summary>
        ///  Indicates whether a specified Type can be assigned null.
		/// </summary>
		/// <param name="input">The Type to check for nullable property.</param>
		/// <returns>True if the specified Type can be assigned null, otherwise false.</returns>
		public static bool IsNullableType(Type input)
		{
			if (!input.IsValueType) return true; // Reference Type
			if (Nullable.GetUnderlyingType(input) != null) return true;	// Nullable<T>
			return false;	// Value Type
		}
	}
}
