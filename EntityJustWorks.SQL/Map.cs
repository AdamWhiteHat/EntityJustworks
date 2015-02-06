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

namespace EntityJustWorks.SQL
{

	/// <summary>
	/// DataTable/Class Mapping Class
	/// </summary>
	public static class Map
	{
		/// <summary>
		/// Fills properties of a class from a row of a DataTable where the name of the property matches the column name from that DataTable.
		/// It does this for each row in the DataTable, returning a List of classes.
		/// </summary>
		/// <typeparam name="T">The class type that is to be returned.</typeparam>
		/// <param name="Table">DataTable to fill from.</param>
		/// <returns>A list of ClassType with its properties set to the data from the matching columns from the DataTable.</returns>
		public static IList<T> DatatableToClass<T>(DataTable Table) where T : class, new()
		{
			if (!Helper.IsValidDatatable(Table))
				return new List<T>();

			Type classType = typeof(T);
			IList<PropertyInfo> propertyList = classType.GetProperties();

			// Parameter class has no public properties.
			if (propertyList.Count == 0)
				return new List<T>();

			List<string> columnNames = Table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

			List<T> result = new List<T>();
			try
			{
				foreach (DataRow row in Table.Rows)
				{
					T classObject = new T();
					foreach (PropertyInfo property in propertyList)
					{
						if (property != null && property.CanWrite)	 // Make sure property isn't read only
						{
							if (columnNames.Contains(property.Name))  // If property is a column name
							{
								if (row[property.Name] != System.DBNull.Value)	 // Don't copy over DBNull
								{
									object propertyValue = System.Convert.ChangeType(
											row[property.Name],
											property.PropertyType
										);
									property.SetValue(classObject, propertyValue, null);
								}
							}
						}
					}
					result.Add(classObject);
				}
				return result;
			}
			catch
			{
				return new List<T>();
			}
		}

		/// <summary>
		/// Creates a DataTable from a class type's public properties and adds a new DataRow to the table for each class passed as a parameter.
		/// The DataColumns of the table will match the name and type of the public properties.
		/// </summary>
		/// <param name="ClassCollection">A class or array of class to fill the DataTable with.</param>
		/// <returns>A DataTable who's DataColumns match the name and type of each class T's public properties.</returns>
		public static DataTable ClassToDatatable<T>(params T[] ClassCollection) where T : class
		{
			DataTable result = ClassToDatatable<T>();

			if (Helper.IsValidDatatable(result, IgnoreRows: true))
				return new DataTable();
			if (Helper.IsCollectionEmpty(ClassCollection))
				return result;	 // Returns and empty DataTable with columns defined (table schema)

			foreach (T classObject in ClassCollection)
			{
				ClassToDataRow(ref result, classObject);
			}

			return result;
		}

		/// <summary>
		/// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
		/// </summary>
		/// <typeparam name="T">The type of the class to create a DataTable from.</typeparam>
		/// <returns>A DataTable who's DataColumns match the name and type of each class T's public properties.</returns>
		public static DataTable ClassToDatatable<T>() where T : class
		{
			Type classType = typeof(T);
			DataTable result = new DataTable(classType.UnderlyingSystemType.Name);

			foreach (PropertyInfo property in classType.GetProperties())
			{
				DataColumn column = new DataColumn();
				column.ColumnName = property.Name;
				column.DataType = property.PropertyType;

				if (Helper.IsNullableType(column.DataType) && column.DataType.IsGenericType)
				{	// If Nullable<>, this is how we get the underlying Type...
					column.DataType = column.DataType.GenericTypeArguments.FirstOrDefault();
				}
				else
				{	// True by default, so set it false
					column.AllowDBNull = false;
				}

				// Add column
				result.Columns.Add(column);
			}
			return result;
		}

		/// <summary>
		/// Adds a DataRow to a DataTable from the public properties of a class.
		/// </summary>
		/// <param name="Table">A reference to the DataTable to insert the DataRow into.</param>
		/// <param name="ClassObject">The class containing the data to fill the DataRow from.</param>
		private static void ClassToDataRow<T>(ref DataTable Table, T ClassObject) where T : class
		{
			DataRow row = Table.NewRow();
			foreach (PropertyInfo property in typeof(T).GetProperties())
			{
				if (Table.Columns.Contains(property.Name))
				{
					if (Table.Columns[property.Name] != null)
					{
						row[property.Name] = property.GetValue(ClassObject, null);
					}
				}
			}
			Table.Rows.Add(row);
		}
	}
}
