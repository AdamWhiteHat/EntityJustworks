EntityJustworks
====== 
  _A compact but powerful data-first or code-first ORM. Specializes in dynamically generating SQL scripts, such as a CREATE TABLE script from the public properties of a C# class, or a script that creates a stored procedure that parameterizes an INSERT INTO, given a System.Data.DataTable class._
<br />
<br />
<br />
   
   
## Security Warning:
  _This library generates dynamic SQL, and has functions that generate SQL and then immediately executes it. While it its true that all strings funnel through the function `Helper.EscapeSingleQuotes`, this can be defeated in various ways and only parameterized SQL should be considered SAFE. If you have no need for them, I recommend stripping semicolons `;` and dashes_ `--`. _Also there are some Unicode characters that can be interpreted as a single quote or may be converted to one when changing encodings. Additionally, there are Unicode characters that can crash .NET code, but mainly controls (think TextBox). You almost certainly should impose a white list:_ `string clean = new string(dirty.Where(c => "abcdefghijklmnopqrstuvwxyz0123456789.,\"_ !@".Contains(c)).ToArray());`  
 ***_PLEASE USE the_ [SQLScript.StoredProcedure](https://github.com/AdamWhiteHat/EntityJustworks/blob/Development/EntityJustWorks.SQL/SQLScript.StoredProcedure.cs) _and_ [DatabaseQuery.StoredProcedure](https://github.com/AdamWhiteHat/EntityJustworks/blob/Development/EntityJustWorks.SQL/DatabaseQuery.StoredProcedure.cs) classes*** _to generate SQL for you, as the scripts it produces is parameterized. All of the functions can be altered to generate parameterized instead of sanitized scripts. Ever since people have started using this, I have been maintaining backwards compatibility. However, I may break this in the future, as I do not wish to teach one who is learning dangerous/bad habits. This project is a few years old, and its already showing its age. What is probably needed here is a total re-write, deprecating this version while keep it available for legacy users after slapping big warnings all over the place. This project was designed to generate the SQL scripts for standing up a database for a project, using only MY input as data. This project was never designed to process a USER'S input.! Even if the data isn't coming from an adversary, client/user/manually entered data is notoriously inconsistent. Please do not use this code on any input that did not come from you, without first implementing parameterization. Again, please see the_ [SQLScript.StoredProcedure](https://github.com/AdamWhiteHat/EntityJustworks/blob/Development/EntityJustWorks.SQL/SQLScript.StoredProcedure.cs) _class for inspiration on how to do that._
<br />
<br />
<br />



Usage examples:
===
DataTable from class type (using generics):
```csharp
DataTable dataTable = Table.FromClass<PurchaseOrder>();
string createTableFromTable = SQLScript.CreateTable(dataTable);
```

Generate scripts to create stored procedures:
```csharp
File.WriteAllText("sp_InsertRow.sql", StoredProcedure.Insert(dataTable);
File.WriteAllText("sp_ActivateAccount.sql", StoredProcedure.Update, "Active = 0");
``` 

Instance of class to an INSERT INTO script:
```csharp
PurchaseOrder classInstance = new PurchaseOrder();
string insertIntoFromClass = SQLScript.InsertInto(classInstance);
``` 

Populate a List&lt;foo&gt; of your data class from a DataTable using reflection, populating public properties with names identical to the column names:
```csharp
IList<PurchaseOrder> orderList = Table.ToClassInstanceCollection<PurchaseOrder>(tableWithManyRecords);
``` 

Write out SQL script to a file:
```csharp
File.WriteAllText("create_table.sql",SQLScript.CreateTable(dataTable));
```

Or use it directly in a NonQueryCommand:
```csharp
DatabaseQuery.NonQueryCommand(ConnectionString, insertIntoFromClass);
``` 

DataTable from a query:
```csharp
DataTable queryTable = DatabaseQuery.ToDataTable(ConnectionString, "SELECT TOP 1 * FROM [{0}]", TableName);
```

Check that our DataTable is valid: 
```csharp
if (!Helper.IsValidDatatable(dataTable))
	return;
if (!Helper.IsValidDatatable(queryTable))
	return;
``` 

Emit a dynamic assembly, using Reflection.Emit, where the class's public properties' names match the DataTable's ColumnNames:
```csharp
Type datatableAssembly = Table.ToAssembly(dataTable);
``` 

Generate the C# class as C# code using code DOM:
```csharp
FileInfo csCodeFile = Table.ToCSharpCode(queryTable);
``` 
<br />
<br />
<br />





Class Hierarchy and Their Methods
===
```csharp
namespace EntityJustWorks.SQL
{
	public static class Table
	{
		FromClass<T>();
		FromClassInstance<T>(System.Data.DataTable, T);
		FromClassInstanceCollection<T>(T[]);
		FromQuery(string, string, object[]);
		ToAssembly(System.Data.DataTable);
		ToClassInstanceCollection<T>(System.Data.DataTable);
		ToCSharpCode(System.Data.DataTable, string);
	}

	public static class ClassInstance
	{
		FromQuery<T>(string, string, object[]);
		FromDataTable<T>(System.Data.DataTable);
		ToDataTable<T>();
		ToDataTable<T>(T[]);
		ToCSharpCode<T>(string);
		ToAssembly<T>();	
	}

	public static class SQLScript
	{
		CreateTable<T>(T[]);
		CreateTable(System.Data.DataTable);
		InsertInto<T>(T[]);
		InsertInto(System.Data.DataRow);
	}

	public static class SQLScript.StoredProcedure
	{
		Insert(System.Data.DataTable);
		Update(System.Data.DataTable, string);
		GenerateParameterList(System.Data.DataTable);
	}
	
	public static class DatabaseQuery
	{
		ToClass<T>(string, string, object[]);
		ToDataTable(string, string, object[]);
		NonQueryCommand(string, string, object[]);
		ToScalarValue<T>(string, string, object[]);
	}

	public static class Code
	{
		CreateClass(string);
		CreateCode(System.Data.DataTable, string);
		CreateCodeNamespace(System.Data.DataTable);
		CreateConstructor(string);
		CreateGeneratorOptions();
		CreateProperty(string, System.Type);	
	}
	
	public static class Helper
	{
		EscapeSingleQuotes(string);
		ListToDelimitedString<T>(System.Collections.Generic.IEnumerable<T>, string, string, string);
		RowToValueString(System.Data.DataRow);
		TableToColumnsString(System.Data.DataTable);
		IsValidDatatable(System.Data.DataTable, bool);
		IsCollectionEmpty<T>(System.Collections.Generic.IEnumerable<T>);
		IsNullableType(System.Type);
	}
}
```
<br />
<br />
<br />




Links
===
   * https://csharpcodewhisperer.blogspot.com - My C# programming blog
   * https://entityjustworks.codeplex.com - EntityJustworks on CodePlex
   * https://github.com/AdamWhiteHat - My GitHub
<br />
<br />
<br />

