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
        public static IList<T> ToClass<T>(DataTable Table) where T : class, new()
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
                        if (!IsValidObjectData(property, columnNames, row))
                            continue;

                        object propertyValue = System.Convert.ChangeType(
                                row[property.Name],
                                property.PropertyType
                            );

                        property.SetValue(classObject, propertyValue, null);
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
        public static DataTable FromClass<T>(params T[] ClassCollection) where T : class
        {
            DataTable result = FromClass<T>();

            if (!Helper.IsValidDatatable(result, true))
                return new DataTable();

            if (Helper.IsCollectionEmpty(ClassCollection))
                return result;	 // Returns and empty DataTable with columns defined (table schema)

            foreach (T classObject in ClassCollection)
            {
                FromClass(result, classObject);
            }

            return result;
        }

        /// <summary>
        /// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
        /// </summary>
        /// <typeparam name="T">The type of the class to create a DataTable from.</typeparam>
        /// <returns>A DataTable who's DataColumns match the name and type of each class T's public properties.</returns>
        public static DataTable FromClass<T>() where T : class
        {
            Type classType = typeof(T);
            string tableName = classType.Name ?? classType.UnderlyingSystemType.Name ?? "UnknownRefType";
            DataTable result = new DataTable(tableName);

            foreach (PropertyInfo property in classType.GetProperties())
            {
                DataColumn column = new DataColumn();
                column.ColumnName = property.Name;

                if (Helper.IsNullableType(column.DataType))
                {
                    if (column.DataType.IsGenericType)
                    {
                        // If Nullable<> and Generic, this is how we get the underlying Type...
                        column.DataType = column.DataType.GenericTypeArguments.FirstOrDefault();
                    }
                    else
                    {
                        column.DataType = column.DataType.UnderlyingSystemType;
                    }
                    
                    column.AllowDBNull = true;
                }
                else
                {	// True by default, so set it false
                    column.DataType = property.PropertyType;
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
        private static void FromClass<T>(DataTable Table, T ClassObject) where T : class
        {
            DataRow row = Table.NewRow();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!IsValidTableData(Table, property))
                    continue;

                object value = property.GetValue(ClassObject, null);

                if (value == null)
                    row[property.Name] = DBNull.Value;
                else
                    row[property.Name] = value;
            }
            Table.Rows.Add(row);
        }

        private static bool IsValidTableData(DataTable Table, PropertyInfo Property)
        {
            if (!Table.Columns.Contains(Property.Name))
            {
                return false;
            }

            if (Table.Columns[Property.Name] == null)
            {
                return false;
            }

            return true;
        }

        private static bool IsValidObjectData(PropertyInfo Property, List<string> ColumnNames, DataRow Row)
        {
            if (Property == null || !Property.CanWrite)   // Make sure property isn't read only
            {
                return false;
            }

            if (!ColumnNames.Contains(Property.Name))  // If property is a column name
            {
                return false;
            }

            if (Row[Property.Name] == System.DBNull.Value)   // Don't copy over DBNull
            {
                return false;
            }

            return true;
        }
    }
}
