using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

using EntityJustWorks.SQL;

namespace EntityJustworksGUI
{
	public partial class MainForm : Form
	{
		public static string ConnectionString_Format = "Server={0};Database={1};User ID={2};Password={3};";
		public static string ConnectionString_CsvFile = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\\TEMP\\database_orders.csv;Extended Properties=\"Text;HDR=YES;FMT=Delimited\"";
		public static string ConnectionString_LocalDB = ConfigurationManager.AppSettings["ConnectionString_LocalDB"].ToString();

		public bool IsConnected
		{
			get { return _isConnected; }
			set
			{
				_isConnected = value;
				//OnConnectionChanged();
				groupBoxCommands.Enabled = _isConnected;
				btnSQLConnect.Text = ConnectButtonText;
			}
		}
		private bool _isConnected;

		public string ConnectButtonText
		{
			get { return IsConnected ? "Disconnect..." : "Connect..."; }
			//set { btnSQLConnect.Text = value; }
		}

		public string ConnectionStringText
		{
			get { return tbConnectionString.Text; }
			set { tbConnectionString.Text = value; }
		}

		public string SelectCommand
		{
			get { return tbSelectCommand.Text; }
			set { tbSelectCommand.Text = value; }
		}

		public string TableName
		{
			get { return tbTableName.Text; }
			set { tbTableName.Text = value; }
		}

		public DataTable Datatable
		{
			get { return _table; }
			set
			{
				_table = value;
			}
		}
		private DataTable _table;

		public FileInfo OutputFile
		{
			get { return new FileInfo(tbOutputFilename.Text); }
			set { tbOutputFilename.Text = value.FullName; }
		}

		public SqlConnectionStringBuilder ConnectionString { get; set; }

		public MainForm()
		{
			InitializeComponent();

			ConnectionStringText = ConnectionString_LocalDB;
			SelectCommand = "SELECT TOP 1 * FROM [{0}] WHERE 1=1";
			TableName = "Customers";
			OutputFile = new FileInfo("Output.txt");

			_table = new DataTable();
			IsConnected = false;
		}

		#region Button Events

		private void btnSQLConnect_Click(object sender, EventArgs e)
		{
			if (!IsConnected)
			{
				ConnectionString = new SqlConnectionStringBuilder(ConnectionStringText);

				Datatable = Table.FromQuery(ConnectionString.ConnectionString, SelectCommand, TableName);
				Datatable.TableName = TableName;
				IsConnected = Helper.IsValidDatatable(Datatable, true);

				btnScript_InsertInto.Enabled = (Datatable.Rows.Count > 0);

				IEnumerable<string> collumnNames = Datatable.Columns.OfType<DataColumn>().Select(col => col.ColumnName);
				tbOutput.Text = Helper.ListToDelimitedString(collumnNames, "\t @", ",\n\t@", "\n");
			}
			else
			{
				//if (ConnectionString != null) {
				ConnectionString.Clear();
				ConnectionString = new SqlConnectionStringBuilder();
				//} if (Datatable != null) {
				Datatable.Clear();
				Datatable = new DataTable();
				Datatable = TestObjectsFactory.BuildDatatable();
				//}

				IsConnected = false;
			}
		}

		private void btnBuild_CSharpCode_Click(object sender, EventArgs e)
		{
			OutputFile = Table.ToCSharpCode(Datatable, "DataTable.cs");
		}

		private void btnBuild_Assembly_Click(object sender, EventArgs e)
		{
			Type dataclassAssembly = Table.ToAssembly(Datatable);
		}

		private void btnBuild_XML_Click(object sender, EventArgs e)
		{
			XmlSerializerFactory xmlFactory = new XmlSerializerFactory();
			XmlSerializer datarowSerializer = xmlFactory.CreateSerializer(typeof(List<DataRow>));

			OutputFile = new FileInfo("DataTable.xml");

			XmlWriter xWriter = XmlWriter.Create(OutputFile.FullName);
			datarowSerializer.Serialize(xWriter, Datatable.Rows.Cast<DataRow>().ToList());
		}

		private void btnBuild_JSON_Click(object sender, EventArgs e)
		{
			OutputFile = new FileInfo("DataTable.json");
			Stream jsonStream = new FileStream(OutputFile.FullName, FileMode.CreateNew);
			XmlDictionaryWriter jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(jsonStream);
		}

		private void btnScript_CreateTable_Click(object sender, EventArgs e)
		{
			string scriptText = SQLScript.CreateTable(Datatable);
			tbOutput.Text = scriptText;

			OutputFile = new FileInfo(string.Format("{0}.CreateTable.sql", Datatable.TableName));
			File.WriteAllText(OutputFile.FullName, scriptText);
		}

		private void btnScript_InsertInto_Click(object sender, EventArgs e)
		{
			string scriptText = SQLScript.InsertInto(Datatable);
			tbOutput.Text = scriptText;

			OutputFile = new FileInfo(string.Format("{0}.InsertInto.sql", Datatable.TableName));
			File.WriteAllText(OutputFile.FullName, scriptText);

		}

		private void btnScript_StoredProcedure_Click(object sender, EventArgs e)
		{
			string scriptText = SQLScript.StoredProcedure.Update(Datatable, "{WhereClause}");
			scriptText = scriptText.Replace("{DatabaseName}", ConnectionString.InitialCatalog);
			scriptText = scriptText.Replace("{StoredProcedureName}", string.Format("sp_{0}_InsertInto", Datatable.TableName.Replace("_", "")));

			tbOutput.Text = scriptText;

			OutputFile = new FileInfo(string.Format("{0}.StoredProcedure.sql", Datatable.TableName));
			File.WriteAllText(OutputFile.FullName, scriptText);
		}

		private void btnScript_DataBase_Click(object sender, EventArgs e)
		{
			//string scriptText = SQLScript.DataBase(ConnectionStringText);
			//tbOutputText.Text = scriptText;
			//
			//OutputFile = new FileInfo(string.Format("DataBase.sql", Datatable.TableName));
			//File.WriteAllText(OutputFile.FullName, scriptText);
		}

		private void btnScript_InsertIntoParameterized_Click(object sender, EventArgs e)
		{
			DataTable table = TestObjectsFactory.BuildDatatable();

			string insertIntoScript = SQLScript.InsertInto(table);

			tbOutput.Text = insertIntoScript;
		}

		private void btnGenerateSampleData_Click(object sender, EventArgs e)
		{
			Datatable = TestObjectsFactory.BuildDatatable(6);
			TableName = Datatable.TableName;
			IsConnected = true;
		}

		#endregion
	}
}
