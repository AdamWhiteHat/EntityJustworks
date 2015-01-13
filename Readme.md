<pre><code>
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
/// &lt;summary&gt;
/// EntityJustWorks - Entity/data mapper
/// EntityJustWorks.SQL Provides entity/object to data mapping functions for SQL repositories.
/// &lt;/summary&gt;
namespace EntityJustWorks.SQL
{
	/// &lt;summary&gt; Convert from class to SQL table or from SQL Table to C# class code file &lt;/summary&gt;
	public static class Convert
	{
		/// &lt;summary&gt; 
		/// Generates a C# class code file from a Database given an SQL connection string and table name.
		/// &lt;/summary&gt;
		public static string SQLToCSharp(string ConnectionString, string TableName)

		/// &lt;summary&gt;
		/// Creates an SQL table from a class object.
		/// &lt;/summary&gt;
		public static bool ClassToSQL&lt;T&gt;(string ConnectionString, params T[] ClassCollection) where T : class
	}
	
	
	/// &lt;summary&gt; SQL Script Generation Class &lt;/summary&gt;
	public static class Script
	{
		/// &lt;summary&gt;
		/// Creates a SQL script that inserts the values of the specified classes' public properties into a table.
		/// &lt;/summary&gt;
		public static string InsertInto&lt;T&gt;(params T[] ClassObjects) where T : class

		/// &lt;summary&gt;
		/// Creates a SQL script that inserts the cell values of a DataTable's DataRows into a table.
		/// &lt;/summary&gt;
		public static string InsertInto(DataTable Table)

		/// &lt;summary&gt;
		/// Creates a SQL script that creates a table where the column names match the specified class's public properties.
		/// &lt;/summary&gt;
		public static string CreateTable&lt;T&gt;(params T[] ClassObjects) where T : class

		/// &lt;summary&gt;
		/// Creates a SQL script that creates a table where the columns matches that of the specified DataTable.
		/// &lt;/summary&gt;
		public static string CreateTable(DataTable Table)
	}
	
	
	/// &lt;summary&gt; DataTable/Class Mapping Class &lt;/summary&gt;
	public static class Map
	{
		//// &lt;summary&gt;
		/// Fills properties of a class from a row of a DataTable where the name of the property matches the column name from that DataTable.
		/// It does this for each row in the DataTable, returning a List of classes.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The class type that is to be returned.&lt;/typeparam&gt;
		/// &lt;param name="Table"&gt;DataTable to fill from.&lt;/param&gt;
		/// &lt;returns&gt;A list of ClassType with its properties set to the data from the matching columns from the DataTable.&lt;/returns&gt;
		public static IList&lt;T&gt; DatatableToClass&lt;T&gt;(DataTable Table) where T : class, new()

		/// &lt;summary&gt;
		/// Creates a DataTable from a class type's public properties and adds a new DataRow to the table for each class passed as a parameter.
		/// The DataColumns of the table will match the name and type of the public properties.
		/// &lt;/summary&gt;
		/// &lt;param name="ClassCollection"&gt;A class or array of class to fill the DataTable with.&lt;/param&gt;
		/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
		public static DataTable ClassToDatatable&lt;T&gt;(params T[] ClassCollection) where T : class

		/// &lt;summary&gt;
		/// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The type of the class to create a DataTable from.&lt;/typeparam&gt;
		/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
		public static DataTable ClassToDatatable&lt;T&gt;() where T : class
	}
	
	
	/// &lt;summary&gt; SQL Query Helper Class &lt;/summary&gt;
	public static class Query
	{
		/// &lt;summary&gt;
		/// Runs a SQL query and returns the results as a List of the specified class
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The type the result will be returned as.&lt;/typeparam&gt;
		/// &lt;param name="ConnectionString"&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="FormatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
		/// &lt;param name="FormatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
		/// &lt;returns&gt;A List of classes that represent the records returned.&lt;/returns&gt;
		public static IList&lt;T&gt; QueryToClass&lt;T&gt;(string ConnectionString, string FormatString_Query, params object[] FormatString_Parameters) where T : class, new()

		/// &lt;summary&gt;
		/// Executes an SQL query and returns the results as a DataTable.
		/// &lt;/summary&gt;
		/// &lt;param name="ConnectionString"&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="FormatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
		/// &lt;param name="FormatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
		/// &lt;returns&gt;The results of the query as a DataTable.&lt;/returns&gt;
		public static DataTable QueryToDataTable(string ConnectionString, string FormatString_Query, params object[] FormatString_Parameters)

		/// &lt;summary&gt;
		/// Executes a query, and returns the first column of the first row in the result set returned by the query.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The type the result will be returned as.&lt;/typeparam&gt;
		/// &lt;param name="ConnectionString"&gt;&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="FormatString_Query"&gt;The SQL query as string.Format string.&lt;/param&gt;
		/// &lt;param name="FormatString_Parameters"&gt;The string.Format parameters.&lt;/param&gt;
		/// &lt;returns&gt;The  first column of the first row in the result, converted and casted to type T.&lt;/returns&gt;
		public static T QueryToScalarType&lt;T&gt;(string ConnectionString, string FormatString_Query, params object[] FormatString_Parameters)

		/// &lt;summary&gt;
		/// Executes a non-query SQL command, such as INSERT or DELETE
		/// &lt;/summary&gt;
		/// &lt;param name="ConnectionString"&gt;The connection string.&lt;/param&gt;
		/// &lt;param name="FormatString_Command"&gt;The SQL command, as a format string.&lt;/param&gt;
		/// &lt;param name="FormatString_Parameters"&gt;The parameters for the format string.&lt;/param&gt;
		/// &lt;returns&gt;The number of rows affected, or -1 on errors.&lt;/returns&gt;
		public static int ExecuteNonQuery(string ConnectionString, string FormatString_Command, params object[] FormatString_Parameters)
	}
	
	
	/// &lt;summary&gt; Helper Functions. Conversion, Validation &lt;/summary&gt;
	public static class Helper
	{
		/// &lt;summary&gt;
		/// Indicates whether a specified DataTable is null, has zero columns, or (optionally) zero rows.
		/// &lt;/summary&gt;
		/// &lt;param name="Table"&gt;DataTable to check.&lt;/param&gt;
		/// &lt;param name="IgnoreRows"&gt;When set to true, the function will return true even if the table's row count is equal to zero.&lt;/param&gt;
		/// &lt;returns&gt;False if the specified DataTable null, has zero columns, or zero rows, otherwise true.&lt;/returns&gt;
		public static bool IsValidDatatable(DataTable Table, bool IgnoreRows = false)

		/// &lt;summary&gt;
		/// Indicates whether a specified Enumerable collection is null or an empty collection.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The specified type contained in the collection.&lt;/typeparam&gt;
		/// &lt;param name="Input"&gt;An Enumerator to the collection to check.&lt;/param&gt;
		/// &lt;returns&gt;True if the specified Enumerable collection is null or empty, otherwise false.&lt;/returns&gt;
		public static bool IsCollectionEmpty&lt;T&gt;(IEnumerable&lt;T&gt; Input)

		/// &lt;summary&gt;
		///  Indicates whether a specified Type can be assigned null.
		/// &lt;/summary&gt;
		/// &lt;param name="Input"&gt;The Type to check for nullable property.&lt;/param&gt;
		/// &lt;returns&gt;True if the specified Type can be assigned null, otherwise false.&lt;/returns&gt;
		public static bool IsNullableType(Type Input)

		/// &lt;summary&gt;
		/// Returns all the column names of the specified DataRow in a string delimited like and SQL INSERT INTO statement.
		/// Example: ([FullName], [Gender], [BirthDate])
		/// &lt;/summary&gt;
		/// &lt;returns&gt;A string formatted like the columns specified in an SQL 'INSERT INTO' statement.&lt;/returns&gt;
		public static string RowToColumnString(DataRow Row)

		/// &lt;summary&gt;
		/// Returns all the values the specified DataRow in as a string delimited like and SQL INSERT INTO statement.
		/// Example: ('John Doe', 'M', '10/3/1981'')
		/// &lt;/summary&gt;
		/// &lt;returns&gt;A string formatted like the values specified in an SQL 'INSERT INTO' statement.&lt;/returns&gt;
		public static string RowToValueString(DataRow Row)
	}
}
</code></pre>