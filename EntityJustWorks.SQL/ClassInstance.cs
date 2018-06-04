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
using System.Linq;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace EntityJustWorks.SQL
{
	/// <summary>
	/// Convert to and from a CLR class instance
	/// </summary>
    public static class ClassInstance
	{
		/// <summary> 
		/// Generates the C# class code from a DataTable.
		/// </summary>
		/// <returns>The C# class code as a string.</returns>
		public static FileInfo ToCSharpCode<T>(string customSavePath = "{Namespace}.{Class}.cs") where T : class
		{
			DataTable classTable = Table.FromClassType<T>();
			return Table.ToCSharpCode(classTable, customSavePath);
		}

		/// <summary> 
		/// Emits a C# Assembly with classes whos public properties match the columns of the DataTable.
		/// </summary>
		/// <returns>The C# Type for the emitted class</returns>
		public static Type ToAssembly<T>() where T : class
		{
			DataTable classTable = Table.FromClassType<T>();
			return Table.ToAssembly(classTable);
		}

		/// <summary>
		/// Creates a DataTable from a class type's public properties and adds a new DataRow to the table for each class passed as a parameter.
		/// The DataColumns of the table will match the name and type of the public properties.
		/// </summary>
		/// <param name="classInstanceCollection">A class or array of class to fill the DataTable with.</param>
		/// <returns>A DataTable who's DataColumns match the name and type of each class T's public properties.</returns>
		public static DataTable ToDataTable<T>(params T[] classInstanceCollection) where T : class
		{
			return Table.FromClassInstanceCollection<T>(classInstanceCollection);
		}

		/// <summary>
		/// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
		/// </summary>
		/// <typeparam name="T">The type of the class to create a DataTable from.</typeparam>
		/// <returns>A DataTable who's DataColumns match the name and type of each class T's public properties.</returns>
		public static DataTable ToDataTable<T>() where T : class
		{
			return Table.FromClassType<T>();
		}

		/// <summary>
		/// Executes an SQL query and returns the results as a DataTable.
		/// </summary>
		/// <param name="connectionString">The SQL connection string.</param>
		/// <param name="formatString_Query">A SQL command that will be passed to string.Format().</param>
		/// <param name="formatString_Parameters">The parameters for string.Format().</param>
		/// <returns>The results of the query as a DataTable.</returns>
		public static IList<T> FromQuery<T>(string connectionString, string formatString_Query, params object[] formatString_Parameters) where T : class, new()
		{
			return DatabaseQuery.ToClass<T>(connectionString, formatString_Query, formatString_Parameters);
		}

		/// <summary>
		/// Fills properties of a class from a row of a DataTable where the name of the property matches the column name from that DataTable.
		/// It does this for each row in the DataTable, returning a List of classes.
		/// </summary>
		/// <typeparam name="T">The class type that is to be returned.</typeparam>
		/// <param name="Table">DataTable to fill from.</param>
		/// <returns>A list of ClassType with its properties set to the data from the matching columns from the DataTable.</returns>
		public static IList<T> FromDataTable<T>(DataTable dataTable) where T : class, new()
		{
			return Table.ToClassInstanceCollection<T>(dataTable);
		}
    }
}
