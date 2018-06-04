using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityJustworksGUI
{
	public class TestObjectsFactory
	{
		public static string column1 = "RecordID";
		public static string column2 = "FirstName";
		public static string column3 = "LastName";
		public static string column4 = "Age";
		public static string column5 = "Email";

		private static Random rand;

		static TestObjectsFactory()
		{
			rand = new Random();

			int temp = 0;
			int counter = 100;
			while (counter-- > 0)
			{
				temp = rand.Next();
			}
		}

		public static DataTable BuildDatatable(int quantity = 6)
		{
			DataTable result = new DataTable("Customers");

			result.Columns.Add(column1);
			result.Columns.Add(column2);
			result.Columns.Add(column3);
			result.Columns.Add(column4);
			result.Columns.Add(column5);

			int counter = -1;

			while (++counter < quantity)
			{
				DataRow row = result.NewRow();
				row[column1] = counter;
				row[column2] = Path.GetRandomFileName();
				row[column3] = Path.GetRandomFileName();
				row[column4] = rand.Next(18, 81);
				row[column5] = Path.GetRandomFileName() + "@" + Path.GetRandomFileName() + ".com";
				result.Rows.Add(row);
			}
			return result;
		}
	}
}
