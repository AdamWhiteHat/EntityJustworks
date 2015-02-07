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
using System.Data;

namespace EntityJustWorks.SQL
{
	public static class Entity
	{
        /// <summary> 
        /// Returns the C# class code as a string from a Database given an SQL connection string and table name. Also saves a copy in the assembly directory.
        /// </summary>
        /// 
        public static string DataFirstAsCode(string ConnectionString, string TableName)
        {
            DataTable table = Query.ToDataTable(ConnectionString, "SELECT TOP 1 * FROM [{0}]", TableName);
            return Entity.DataFirstAsCode(table);
        }

        public static string DataFirstAsCode(DataTable Table)
        {
            return Code.FromDatatable(Table);
        }

        public static Type DataFirstAsDynamicAssembly(string ConnectionString, string TableName)
        {
            DataTable table = Query.ToDataTable(ConnectionString, "SELECT TOP 1 * FROM [{0}]", TableName);
            return EmitClass.FromDatatable(table);
        }

        public static Type DataFirstAsDynamicAssembly(DataTable Table)
        {
            return EmitClass.FromDatatable(Table);
        }

        /// <summary>
        /// Creates an SQL table from a class object.
        /// </summary>
        public static bool CodeFirst<T>(string ConnectionString, params T[] ClassCollection) where T : class
        {
            string createTableScript = Script.CreateTable<T>(ClassCollection);
            return (Query.ExecuteStatement(ConnectionString, createTableScript) == -1);
        }
	}
}
