using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityJustworksGUI
{
	public class FuzzyMerge
	{
		private void DataMappingExample()
		{
			// Create a connection object
			string ConnectionString = "ConnectionStrings_Northwind";
			SqlConnection conn = new SqlConnection(ConnectionString);

			// open the Connection
			conn.Open();


			List<DataColumnMapping> mappings = new List<DataColumnMapping>();
			
			mappings.Add(new DataColumnMapping("FirstName", "FirstName"));
			mappings.Add(new DataColumnMapping("firstname", "FirstName"));
			mappings.Add(new DataColumnMapping("first name", "FirstName"));
			mappings.Add(new DataColumnMapping("first", "FirstName"));
			mappings.Add(new DataColumnMapping("name", "FirstName"));
			mappings.Add(new DataColumnMapping("fn", "FirstName"));

			mappings.Add(new DataColumnMapping("lastname", "LastName"));
			mappings.Add(new DataColumnMapping("last name", "LastName"));
			mappings.Add(new DataColumnMapping("last", "LastName"));
			mappings.Add(new DataColumnMapping("surname", "LastName"));

			mappings.Add(new DataColumnMapping("middlename", "MiddleName"));
			mappings.Add(new DataColumnMapping("middle name", "MiddleName"));
			mappings.Add(new DataColumnMapping("middle", "MiddleName"));
			mappings.Add(new DataColumnMapping("middle initial", "MiddleName"));
			mappings.Add(new DataColumnMapping("mi", "MiddleName"));
			
			mappings.Add(new DataColumnMapping("gender", "Gender"));
			mappings.Add(new DataColumnMapping("sex", "Gender"));
			
			mappings.Add(new DataColumnMapping("dateofbirth", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("date of birth", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("birthdate", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("birth date", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("DOB", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("birthday", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("birth day", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("birth", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("born", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("bday", "DateOfBirth"));
			mappings.Add(new DataColumnMapping("D.O.B.", "DateOfBirth"));
									

			// Create a DataTableMapping object
			DataTableMapping mapping001 = new DataTableMapping("Table", "Destination", mappings.ToArray());
			

			SqlDataAdapter adapter = new SqlDataAdapter("Select * From Orders", conn);

			// Call DataAdapter's TableMapping.Add method
			adapter.TableMappings.Add(mapping001);

			// Create a DataSet object and call DataAdapter's Fill method
			// Make sure you use new name od DataTableMapping i.e., MayOrders
			DataSet ds = new DataSet();
			adapter.Fill(ds);
			Console.WriteLine(ds.Tables["Orders"].Rows[0]["mapID"].ToString());
			//dataGrid1.DataSource = ds.DefaultViewManager;
		}
	}
}
