using System.Data;

namespace EntityJustWorks.SQL
{
	public static class Convert
	{
		/// <summary> 
		/// Generates a C# class code file from a Database given a connection string and table name.
		/// </summary>
		public static string SQLToCSharp(string ConnectionString, string TableName)
		{
			DataTable table = Query.QueryToDataTable(ConnectionString, "SELECT TOP 1 * FROM [{0}]", TableName);
			return Code.DatatableToCSharp(table);
		}

		/// <summary>
		/// Creates an SQL table from a class object.
		/// </summary>
		public static bool ClassToSQL<T>(string ConnectionString, params T[] ClassCollection) where T : class
		{
			string createTableScript = Script.CreateTable<T>(ClassCollection);
			return (Query.ExecuteNonQuery(ConnectionString, createTableScript) == -1);
		}
	}
}
