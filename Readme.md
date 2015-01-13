/* 
 * EntityJustWorks.SQL - C# class object to/from SQL database
 *    by Adam Rakaska
 * 
 * 
 *   Full code and more available @
 *     http://www.csharpprogramming.tips
 * 
 * 
 */
/// <summary>
/// EntityJustWorks - Entity/data mapper
/// EntityJustWorks.SQL Provides entity/object to data mapping functions for SQL repositories.
/// </summary>
namespace EntityJustWorks.SQL
{
	/// <summary> Convert from class to SQL table or from SQL Table to C# class code file </summary>
	public static class Convert
	{
		/// <summary> 
		/// Generates a C# class code file from a Database given an SQL connection string and table name.
		/// </summary>
		public static string SQLToCSharp(string ConnectionString, string TableName)

		/// <summary>
		/// Creates an SQL table from a class object.
		/// </summary>
		public static bool ClassToSQL<T>(string ConnectionString, params T[] ClassCollection) where T : class
	}
	
	
	/// <summary> SQL Script Generation Class </summary>
	public static class Script
	{
		/// <summary>
		/// Creates a SQL script that inserts the values of the specified classes' public properties into a table.
		/// </summary>
		public static string InsertInto<T>(params T[] ClassObjects) where T : class

		/// <summary>
		/// Creates a SQL script that inserts the cell values of a DataTable's DataRows into a table.
		/// </summary>
		public static string InsertInto(DataTable Table)

		/// <summary>
		/// Creates a SQL script that creates a table where the column names match the specified class's public properties.
		/// </summary>
		public static string CreateTable<T>(params T[] ClassObjects) where T : class

		/// <summary>
		/// Creates a SQL script that creates a table where the columns matches that of the specified DataTable.
		/// </summary>
		public static string CreateTable(DataTable Table)
	}
	
	
	/// <summary> DataTable/Class Mapping Class </summary>
	public static class Map
	{
		//// <summary>
		/// Fills properties of a class from a row of a DataTable where the name of the property matches the column name from that DataTable.
		/// It does this for each row in the DataTable, returning a List of classes.
		/// </summary>
		/// <typeparam name="T">The class type that is to be returned.</typeparam>
		/// <param name="Table">DataTable to fill from.</param>
		/// <returns>A list of ClassType with its properties set to the data from the matching columns from the DataTable.</returns>
		public static IList<T> DatatableToClass<T>(DataTable Table) where T : class, new()

		/// <summary>
		/// Creates a DataTable from a class type's public properties and adds a new DataRow to the table for each class passed as a parameter.
		/// The DataColumns of the table will match the name and type of the public properties.
		/// </summary>
		/// <param name="ClassCollection">A class or array of class to fill the DataTable with.</param>
		/// <returns>A DataTable who's DataColumns match the name and type of each class T's public properties.</returns>
		public static DataTable ClassToDatatable<T>(params T[] ClassCollection) where T : class

		/// <summary>
		/// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
		/// </summary>
		/// <typeparam name="T">The type of the class to create a DataTable from.</typeparam>
		/// <returns>A DataTable who's DataColumns match the name and type of each class T's public properties.</returns>
		public static DataTable ClassToDatatable<T>() where T : class
	}
	
	
	/// <summary> SQL Query Helper Class </summary>
	public static class Query
	{
		/// <summary>
		/// Runs a SQL query and returns the results as a List of the specified class
		/// </summary>
		/// <typeparam name="T">The type the result will be returned as.</typeparam>
		/// <param name="ConnectionString">The SQL connection string.</param>
		/// <param name="FormatString_Query">A SQL command that will be passed to string.Format().</param>
		/// <param name="FormatString_Parameters">The parameters for string.Format().</param>
		/// <returns>A List of classes that represent the records returned.</returns>
		public static IList<T> QueryToClass<T>(string ConnectionString, string FormatString_Query, params object[] FormatString_Parameters) where T : class, new()

		/// <summary>
		/// Executes an SQL query and returns the results as a DataTable.
		/// </summary>
		/// <param name="ConnectionString">The SQL connection string.</param>
		/// <param name="FormatString_Query">A SQL command that will be passed to string.Format().</param>
		/// <param name="FormatString_Parameters">The parameters for string.Format().</param>
		/// <returns>The results of the query as a DataTable.</returns>
		public static DataTable QueryToDataTable(string ConnectionString, string FormatString_Query, params object[] FormatString_Parameters)

		/// <summary>
		/// Executes a query, and returns the first column of the first row in the result set returned by the query.
		/// </summary>
		/// <typeparam name="T">The type the result will be returned as.</typeparam>
		/// <param name="ConnectionString">>The SQL connection string.</param>
		/// <param name="FormatString_Query">The SQL query as string.Format string.</param>
		/// <param name="FormatString_Parameters">The string.Format parameters.</param>
		/// <returns>The  first column of the first row in the result, converted and casted to type T.</returns>
		public static T QueryToScalarType<T>(string ConnectionString, string FormatString_Query, params object[] FormatString_Parameters)

		/// <summary>
		/// Executes a non-query SQL command, such as INSERT or DELETE
		/// </summary>
		/// <param name="ConnectionString">The connection string.</param>
		/// <param name="FormatString_Command">The SQL command, as a format string.</param>
		/// <param name="FormatString_Parameters">The parameters for the format string.</param>
		/// <returns>The number of rows affected, or -1 on errors.</returns>
		public static int ExecuteNonQuery(string ConnectionString, string FormatString_Command, params object[] FormatString_Parameters)
	}
	
	
	/// <summary> Helper Functions. Conversion, Validation </summary>
	public static class Helper
	{
		/// <summary>
		/// Indicates whether a specified DataTable is null, has zero columns, or (optionally) zero rows.
		/// </summary>
		/// <param name="Table">DataTable to check.</param>
		/// <param name="IgnoreRows">When set to true, the function will return true even if the table's row count is equal to zero.</param>
		/// <returns>False if the specified DataTable null, has zero columns, or zero rows, otherwise true.</returns>
		public static bool IsValidDatatable(DataTable Table, bool IgnoreRows = false)

		/// <summary>
		/// Indicates whether a specified Enumerable collection is null or an empty collection.
		/// </summary>
		/// <typeparam name="T">The specified type contained in the collection.</typeparam>
		/// <param name="Input">An Enumerator to the collection to check.</param>
		/// <returns>True if the specified Enumerable collection is null or empty, otherwise false.</returns>
		public static bool IsCollectionEmpty<T>(IEnumerable<T> Input)

		/// <summary>
		///  Indicates whether a specified Type can be assigned null.
		/// </summary>
		/// <param name="Input">The Type to check for nullable property.</param>
		/// <returns>True if the specified Type can be assigned null, otherwise false.</returns>
		public static bool IsNullableType(Type Input)

		/// <summary>
		/// Returns all the column names of the specified DataRow in a string delimited like and SQL INSERT INTO statement.
		/// Example: ([FullName], [Gender], [BirthDate])
		/// </summary>
		/// <returns>A string formatted like the columns specified in an SQL 'INSERT INTO' statement.</returns>
		public static string RowToColumnString(DataRow Row)

		/// <summary>
		/// Returns all the values the specified DataRow in as a string delimited like and SQL INSERT INTO statement.
		/// Example: ('John Doe', 'M', '10/3/1981'')
		/// </summary>
		/// <returns>A string formatted like the values specified in an SQL 'INSERT INTO' statement.</returns>
		public static string RowToValueString(DataRow Row)
	}
}
