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
    /// &lt;summary&gt;
	/// Convert to and from a CLR class instance
	/// &lt;/summary&gt;
    public static class ClassInstance
	{
		/// &lt;summary&gt; 
		/// Generates the C# class code from a DataTable.
		/// &lt;/summary&gt;
		/// &lt;returns&gt;The C# class code as a string.&lt;/returns&gt;
		public static FileInfo ToCSharpCode&lt;T&gt;(string customSavePath = "{Namespace}.{Class}.cs") where T : class
		
		/// &lt;summary&gt; 
		/// Emits a C# Assembly with classes whos public properties match the columns of the DataTable.
		/// &lt;/summary&gt;
		/// &lt;returns&gt;The C# Type for the emitted class&lt;/returns&gt;
		public static Type ToAssembly&lt;T&gt;() where T : class
		
		/// &lt;summary&gt;
		/// Creates a DataTable from a class type's public properties and adds a new DataRow to the table for each class passed as a parameter.
		/// The DataColumns of the table will match the name and type of the public properties.
		/// &lt;/summary&gt;
		/// &lt;param name="classInstanceCollection"&gt;A class or array of class to fill the DataTable with.&lt;/param&gt;
		/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
		public static DataTable ToDataTable&lt;T&gt;(params T[] classInstanceCollection) where T : class
	
	    /// &lt;summary&gt;
		/// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The type of the class to create a DataTable from.&lt;/typeparam&gt;
		/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
		public static DataTable ToDataTable&lt;T&gt;() where T : class
	
	    /// &lt;summary&gt;
		/// Executes an SQL query and returns the results as a DataTable.
		/// &lt;/summary&gt;
		/// &lt;param name="connectionString"&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="formatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
		/// &lt;param name="formatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
		/// &lt;returns&gt;The results of the query as a DataTable.&lt;/returns&gt;
		public static IList&lt;T&gt; FromQuery&lt;T&gt;(string connectionString, string formatString_Query, params object[] formatString_Parameters) where T : class, new()
		
		/// &lt;summary&gt;
		/// Fills properties of a class from a row of a DataTable where the name of the property matches the column name from that DataTable.
		/// It does this for each row in the DataTable, returning a List of classes.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The class type that is to be returned.&lt;/typeparam&gt;
		/// &lt;param name="Table"&gt;DataTable to fill from.&lt;/param&gt;
		/// &lt;returns&gt;A list of ClassType with its properties set to the data from the matching columns from the DataTable.&lt;/returns&gt;
		public static IList&lt;T&gt; FromDataTable&lt;T&gt;(DataTable dataTable) where T : class, new()
		{
			return Table.ToClassInstanceCollection&lt;T&gt;(dataTable);
		}
	}
	
		/// &lt;summary&gt;
	/// Convert to and from a System.Data.DataTable
	/// &lt;/summary&gt;
	public static class Table
	{
		/// &lt;summary&gt;
		/// Creates a DataTable from a class type's public properties and adds a new DataRow to the table for each class passed as a parameter.
		/// The DataColumns of the table will match the name and type of the public properties.
		/// &lt;/summary&gt;
		/// &lt;param name="classInstanceCollection"&gt;A class or array of class to fill the DataTable with.&lt;/param&gt;
		/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
		public static DataTable FromClassInstanceCollection&lt;T&gt;(params T[] classInstanceCollection) where T : class
		
		/// &lt;summary&gt;
		/// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The type of the class to create a DataTable from.&lt;/typeparam&gt;
		/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
		public static DataTable FromClass&lt;T&gt;() where T : class
		
		/// &lt;summary&gt;
		/// Adds a DataRow to a DataTable from the public properties of a class.
		/// &lt;/summary&gt;
		/// &lt;param name="dataTable"&gt;A reference to the DataTable to insert the DataRow into.&lt;/param&gt;
		/// &lt;param name="classObject"&gt;The class containing the data to fill the DataRow from.&lt;/param&gt;
		/// &lt;returns&gt;The DataTable in the parameters. This return instance is superflowous; &lt;/returns&gt;
		public static DataTable FromClassInstance&lt;T&gt;(DataTable dataTable, T classObject) where T : class
		
		/// &lt;summary&gt;
		/// Fills properties of a class from a row of a DataTable where the name of the property matches the column name from that DataTable.
		/// It does this for each row in the DataTable, returning a List of classes.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The class type that is to be returned.&lt;/typeparam&gt;
		/// &lt;param name="dataTable"&gt;DataTable to fill from.&lt;/param&gt;
		/// &lt;returns&gt;A list of ClassType with its properties set to the data from the matching columns from the DataTable.&lt;/returns&gt;
		public static IList&lt;T&gt; ToClassInstanceCollection&lt;T&gt;(DataTable dataTable) where T : class, new()
		
		/// &lt;summary&gt;
		/// Executes an SQL query and returns the results as a DataTable.
		/// &lt;/summary&gt;
		/// &lt;param name="connectionString"&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="formatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
		/// &lt;param name="formatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
		/// &lt;returns&gt;The results of the query as a DataTable.&lt;/returns&gt;
		public static DataTable FromQuery(string connectionString, string formatString_Query, params object[] formatString_Parameters)
		
		/// &lt;summary&gt; 
		/// Generates the C# class code from a DataTable.
		/// &lt;/summary&gt;
		/// &lt;returns&gt;The C# class code as a string.&lt;/returns&gt;
		public static FileInfo ToCSharpCode(DataTable dataTable, string customSavePath = "{Namespace}.{Class}.cs")
		
		/// &lt;summary&gt; 
		/// Emits a C# Assembly with classes whos public properties match the columns of the DataTable.
		/// &lt;/summary&gt;
		/// &lt;returns&gt;The C# Type for the emitted class&lt;/returns&gt;
		public static Type ToAssembly(DataTable dataTable)		
	}

	/// &lt;summary&gt;
	/// SQL Query Helper Class
	/// &lt;/summary&gt;
	public static class DatabaseQuery
	{
		/// &lt;summary&gt;
		/// Runs a SQL query and returns the results as a List of the specified class
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The type the result will be returned as.&lt;/typeparam&gt;
		/// &lt;param name="connectionString"&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="formatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
		/// &lt;param name="formatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
		/// &lt;returns&gt;A List of classes that represent the records returned.&lt;/returns&gt;
		public static IList&lt;T&gt; ToClass&lt;T&gt;(string connectionString, string formatString_Query, params object[] formatString_Parameters) where T : class, new()
		
		/// &lt;summary&gt;
		/// Executes an SQL query and returns the results as a DataTable.
		/// &lt;/summary&gt;
		/// &lt;param name="connectionString"&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="formatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
		/// &lt;param name="formatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
		/// &lt;returns&gt;The results of the query as a DataTable.&lt;/returns&gt;
		public static DataTable ToDataTable(string connectionString, string formatString_Query, params object[] formatString_Parameters)
		
		/// &lt;summary&gt;
		/// Executes a non-query SQL command, such as INSERT or DELETE
		/// &lt;/summary&gt;
		/// &lt;param name="connectionString"&gt;The connection string.&lt;/param&gt;
		/// &lt;param name="FormatString_Command"&gt;The SQL command, as a format string.&lt;/param&gt;
		/// &lt;param name="formatString_Parameters"&gt;The parameters for the format string.&lt;/param&gt;
		/// &lt;returns&gt;The number of rows affected, or -1 on errors.&lt;/returns&gt;
		public static int NonQueryCommand(string connectionString, string FormatString_Command, params object[] formatString_Parameters)
		
		/// &lt;summary&gt;
		/// Executes a query, and returns the first column of the first row in the result set returned by the query.
		/// &lt;/summary&gt;
		/// &lt;typeparam name="T"&gt;The type the result will be returned as.&lt;/typeparam&gt;
		/// &lt;param name="connectionString"&gt;&gt;The SQL connection string.&lt;/param&gt;
		/// &lt;param name="formatString_Query"&gt;The SQL query as string.Format string.&lt;/param&gt;
		/// &lt;param name="formatString_Parameters"&gt;The string.Format parameters.&lt;/param&gt;
		/// &lt;returns&gt;The  first column of the first row in the result, converted and casted to type T.&lt;/returns&gt;
		public static T ToScalarValue&lt;T&gt;(string connectionString, string formatString_Query, params object[] formatString_Parameters)
	}

    /// &lt;summary&gt;
	/// SQL Script Generation Class
	/// &lt;/summary&gt;
	public static class SQLScript
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
}
</code></pre>