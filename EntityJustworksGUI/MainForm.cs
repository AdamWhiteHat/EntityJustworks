using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
//
using System.Reflection;
using System.Reflection.Emit;
using System.Linq.Expressions;
//
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Serialization;
//
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Linq.SqlClient;
//
using Microsoft.SqlServer;
using Microsoft.SqlServer.Server;
using System.Data.SqlServerCe;

using EntityJustWorks.SQL;


namespace EntityJustworksGUI
{
    public partial class MainForm : Form
    {
        public static string ConnectionString_Format = "Server={0};Database={1};User ID={2};Password={3};";
		public static string ConnectionString_CsvFile = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\\TEMP\\database_orders.csv;Extended Properties=\"Text;HDR=YES;FMT=Delimited\"";
        public static string ConnectionString_DBIntoInterLink = ConfigurationManager.AppSettings["ConnectionString_DBIntoInterlink"].ToString();
        public static string ConnectionString_DBIMPORTFILES = ConfigurationManager.AppSettings["ConnectionString_DBIMPORTFILES"].ToString();

        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                //OnConnectionChanged();
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

        public SqlConnectionStringBuilder ConnectionString { get; set; }

        public DataTable Datatable
        {
            get { return _table; }
            set
            {
                _table = value;
                //IsConnected = Helper.IsValidDatatable(value, true);
            }
        }
        private DataTable _table;

        public FileInfo OutputFile
        {
            get { return new FileInfo(tbOutputFilename.Text); }
            set { tbOutputFilename.Text = value.FullName; }
        }

        public MainForm()
        {
            InitializeComponent();

            _table = new DataTable();
            IsConnected = false;
            //groupBox.Enabled = false;

            ConnectionStringText = ConnectionString_DBIntoInterLink;
            SelectCommand = "SELECT TOP 1 * FROM [{0}] WHERE 1=1";
            TableName = "client_info";
            OutputFile = new FileInfo("Output.txt");
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

            groupBox.Enabled = IsConnected;
            btnSQLConnect.Text = ConnectButtonText;
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
            //jsonWriter.WriteArray("","DataRow","",
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
            string scriptText = SQLScript.StoredProcedure.Update(Datatable,"{WhereClause}");
            scriptText = scriptText.Replace("{DatabaseName}", ConnectionString.InitialCatalog);
            scriptText = scriptText.Replace("{StoredProcedureName}", string.Format("sp_{0}_InsertInto", Datatable.TableName.Replace("_","")));

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

        private void decode_Click(object sender, EventArgs e)
        {
            string output = string.Empty;
            string source = tbEncodeSource.Text;

            Button src = (Button)sender;
            switch (src.Text)
            {

                case "Base64":
                    output = Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
                    break;
                case "DeBase64":
                    byte[] bites = Convert.FromBase64String(source);
                    output = Encoding.UTF8.GetString(bites);
                    break;
                case "ArrayStr":
                   string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
                    byte[] byt = Convert.FromBase64String(base64); 
                    output = string.Join(", ", byt.Select(b => b.ToString()));
                    output = output.Insert(0, "byte[] buytes = new byte[] { ") + " };";                    
                    break;
                case "DeArrayStr":
                          tbOutput.Text += Encoding.UTF8.GetString(new byte[]{82,77,67,65,68,64,100,109,120,45,100,105,114,101,99,116,46,99,111,109});
                          tbOutput.Text += Environment.NewLine;
                          tbOutput.Text += Encoding.UTF8.GetString(new byte[]{82,77,67,65,68,101,98,50,33});
                    break;
            }

            tbEncodeOutput.Text = output;
        }

		private void btnScript_InsertIntoParameterized_Click(object sender, EventArgs e)
		{
			DataTable table = TestObjectsFactory.BuildDatatable();

			string insertIntoScript = SQLScript.InsertInto(table);

			tbOutput.Text = insertIntoScript;

			//SqlConnectionStringBuilder connstrBuilder = new SqlConnectionStringBuilder();
			//connstrBuilder.AttachDBFilename = "Database001.mdf";
			//connstrBuilder.InitialCatalog = "master";//"MyData";
			
			//SqlCeConnection connection = new SqlCeConnection(/*@"Data Source=C:\Users\Adam\Documents\Visual Studio 2015\Projects\EntityWorks GUI\EntityJustworksGUI\Database001.mdf;"*/connstrBuilder.ConnectionString);
			//connection.Open();

			//SqlCeCommand command = new SqlCeCommand("CREATE DATABASE MyData", connection);
			
			//List<DataRow> failedRows = Table.ToSqlTable("whatever", table);
		}

		#endregion

	}
}
