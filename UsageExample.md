```csharp
string ConnectionString = "Data Source=DBSQLDEV;Initial Catalog=MyAwesomeDB;Integrated Security=True";

DataTable dataTable = Table.FromClass<Customer>(); // Creates an empty DataTable with Customer schema, that is a DataTable with column names matching the public properties of Customer
string createTableScript = SQLScript.CreateTable(dataTable); // Creates a CREATE TABLE script from a DataTable with schema
File.WriteAllText("CreateTable_Customers.sql", createTableScript); // Write script to script file
DatabaseQuery.NonQueryCommand(ConnectionString, createTableScript); // Execute CREATE TABLE script to create table in the data base

Customer classInstance = new Customer() { FirstName = "Bill" }; // Instantiate new Customer class

string insertIntoScript = SQLScript.InsertInto<Customer>(classInstance); // Create a INSERT INTO sql script
DatabaseQuery.NonQueryCommand(ConnectionString, insertIntoScript); // Insert Customer class instance into DB by executing above script
            
DataTable customerQueryRecords = DatabaseQuery.ToDataTable(ConnectionString, "SELECT * FROM [Customer] WHERE [FirstName] = 'Bill'"); // Select all customers named 'Bill'
IList<Customer> customerList = Table.ToClassInstanceCollection<Customer>(customerQueryRecords); // Populate Customer class's public properties with data from the matching DataTable

DataTable orderRecord = DatabaseQuery.ToDataTable(ConnectionString, "SELECT TOP 1 * FROM [Order]"); // Select a row from the Order table, for which we don't have a DAO object in code yet
FileInfo orderClass_CSharp = Code.CreateCode(orderRecord, "Order.cs"); // Create a C# class with public properties matching the DataTable columns, and save it to a .cs code file
Type orderClass_Assembly = Table.ToAssembly(orderRecord); // Or create the class as a .NET assembly, available as a Type for the code to use immediately
```