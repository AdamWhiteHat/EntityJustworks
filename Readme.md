

## Security Warning:
_This library generates dynamic SQL, and has functions that generate SQL and then immediately executes it. While it its true that all strings funnel through the function `Helper.EscapeSingleQuotes`, this can be defeted in various ways and only parameterized SQL should be considered SAFE. If you have no need for them, I recommend stripping semicolons `;` and dashes_ `--`. _Also there are some Unicode characters that can be interpreted as a single quote or may be converted to one when changing encodings. Additionally, there are Unicode characters that can crash .NET code, but mainly controls (think TextBox). You almost certainly should impose a white list:_ `string clean = new string(dirty.Where(c => "abcdefghijklmnopqrstuvwxyz0123456789.,\"_ !@".Contains(c)).ToArray());`

***PLEASE USE the [SQLScript.StoredProcedure](https://github.com/AdamRakaska/EntityJustworks/blob/Development/EntityJustWorks.SQL/SQLScript.StoredProcedure.cs) and [DatabaseQuery.StoredProcedure](https://github.com/AdamRakaska/EntityJustworks/blob/Development/EntityJustWorks.SQL/DatabaseQuery.StoredProcedure.cs) classes*** _to generate SQL for you, as the scripts it produces is parameterized. All of the functions can be altered to generate parameterized instead of sanitized scripts. Ever since people have started using this, I have been maintaining backwards compatibility. However, I may break this in the future, as I do not wish to teach one who is learning dangerous/bad habits. This project is a few years old, and its already showing its age. What is probably needed here is a total re-write, deprecating this version while keep it available for legacy users after slapping big warnings all over the place. This project was designed to generate the SQL scripts for standing up a database for a project, using only MY input as data. This project was never designed to process a USER'S input.! Even if the data isn't coming from an adversary, client/user/manually entered data is notoriously inconsistent. Please do not use this code on any input that did not come from you, without first implementing parameterization. Again, please see the [SQLScript.StoredProcedure](https://github.com/AdamRakaska/EntityJustworks/blob/Development/EntityJustWorks.SQL/SQLScript.StoredProcedure.cs) class for inspiration on how to do that.




Usage examples:
===


DataTable from class type (using generics):
<pre><code>
DataTable dataTable = Table.FromClass<PurchaseOrder>();
string createTableFromTable = SQLScript.CreateTable(dataTable);
</code></pre>
<br />

Generate scripts to create stored procedures:
<pre><code>
File.WriteAllText("sp_InsertRow.sql", StoredProcedure.Insert(dataTable);
File.WriteAllText("sp_ActivateAccount.sql", StoredProcedure.Update, "Active = 0");
</pre></code>
<br />

Instance of class to an INSERT INTO script:
<pre><code>
PurchaseOrder classInstance = new PurchaseOrder();
string insertIntoFromClass = SQLScript.InsertInto(classInstance);
</code></pre>
<br />

Populate a List<> of your data class from a DataTable using reflection, populating public properties with names identical to the column names:
<pre><code>IList<PurchaseOrder> orderList = Table.ToClassInstanceCollection<PurchaseOrder>(tableWithManyRecords);
</code></pre>
<br />

Write out SQL script to a file:
<pre><code>File.WriteAllText("create_table.sql",SQLScript.CreateTable(dataTable));
</code></pre>
<br />

Or use it directly in a NonQueryCommand:
<pre><code>DatabaseQuery.NonQueryCommand(ConnectionString, insertIntoFromClass);
</code></pre>
<br />

DataTable from a query:
<pre><code>DataTable queryTable = DatabaseQuery.ToDataTable(ConnectionString, "SELECT TOP 1 * FROM [{0}]", TableName);
</code></pre>
<br />

Check that our DataTable is valid: 
<pre><code>if (!Helper.IsValidDatatable(dataTable))
	return;
if (!Helper.IsValidDatatable(queryTable))
	return;
</code></pre>
<br />

Emit a dynamic assembly, using Reflection.Emit, where the class's public properties' names match the DataTable's ColumnNames:
<pre><code>Type datatableAssembly = Table.ToAssembly(dataTable);
</code></pre>
<br />

Generate the C# class as C# code using code DOM:
<pre><code>FileInfo csCodeFile = Table.ToCSharpCode(queryTable);
</code></pre>
<br />



Code XML Comments
===


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
