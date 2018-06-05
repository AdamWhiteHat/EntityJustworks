namespace EntityJustworksGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tbConnectionString = new System.Windows.Forms.TextBox();
			this.tbSelectCommand = new System.Windows.Forms.TextBox();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSQLConnect = new System.Windows.Forms.Button();
			this.groupCode = new System.Windows.Forms.GroupBox();
			this.btnBuild_JSON = new System.Windows.Forms.Button();
			this.btnBuild_XML = new System.Windows.Forms.Button();
			this.btnBuild_Assembly = new System.Windows.Forms.Button();
			this.btnBuild_CSharpCode = new System.Windows.Forms.Button();
			this.groupScript = new System.Windows.Forms.GroupBox();
			this.btnScript_InsertIntoParameterized = new System.Windows.Forms.Button();
			this.btnScript_DataBase = new System.Windows.Forms.Button();
			this.btnScript_StoredProcedure = new System.Windows.Forms.Button();
			this.btnScript_CreateTable = new System.Windows.Forms.Button();
			this.btnScript_InsertInto = new System.Windows.Forms.Button();
			this.groupBoxCommands = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbOutputFilename = new System.Windows.Forms.TextBox();
			this.tbTableName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBoxConnect = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnGenerateSampleData = new System.Windows.Forms.Button();
			this.groupCode.SuspendLayout();
			this.groupScript.SuspendLayout();
			this.groupBoxCommands.SuspendLayout();
			this.groupBoxConnect.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbConnectionString
			// 
			this.tbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbConnectionString.Location = new System.Drawing.Point(10, 43);
			this.tbConnectionString.Name = "tbConnectionString";
			this.tbConnectionString.Size = new System.Drawing.Size(552, 20);
			this.tbConnectionString.TabIndex = 0;
			// 
			// tbSelectCommand
			// 
			this.tbSelectCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSelectCommand.Location = new System.Drawing.Point(10, 134);
			this.tbSelectCommand.Multiline = true;
			this.tbSelectCommand.Name = "tbSelectCommand";
			this.tbSelectCommand.Size = new System.Drawing.Size(552, 43);
			this.tbSelectCommand.TabIndex = 1;
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(4, 457);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(580, 152);
			this.tbOutput.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Connection string:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 118);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "SELECT command:";
			// 
			// btnSQLConnect
			// 
			this.btnSQLConnect.Location = new System.Drawing.Point(9, 183);
			this.btnSQLConnect.Name = "btnSQLConnect";
			this.btnSQLConnect.Size = new System.Drawing.Size(104, 23);
			this.btnSQLConnect.TabIndex = 5;
			this.btnSQLConnect.Text = "Connect...";
			this.btnSQLConnect.UseVisualStyleBackColor = true;
			this.btnSQLConnect.Click += new System.EventHandler(this.btnSQLConnect_Click);
			// 
			// groupCode
			// 
			this.groupCode.Controls.Add(this.btnBuild_JSON);
			this.groupCode.Controls.Add(this.btnBuild_XML);
			this.groupCode.Controls.Add(this.btnBuild_Assembly);
			this.groupCode.Controls.Add(this.btnBuild_CSharpCode);
			this.groupCode.Location = new System.Drawing.Point(20, 24);
			this.groupCode.Name = "groupCode";
			this.groupCode.Size = new System.Drawing.Size(200, 132);
			this.groupCode.TabIndex = 6;
			this.groupCode.TabStop = false;
			this.groupCode.Text = "Code Entity Builder:";
			// 
			// btnBuild_JSON
			// 
			this.btnBuild_JSON.Enabled = false;
			this.btnBuild_JSON.Location = new System.Drawing.Point(20, 96);
			this.btnBuild_JSON.Name = "btnBuild_JSON";
			this.btnBuild_JSON.Size = new System.Drawing.Size(160, 23);
			this.btnBuild_JSON.TabIndex = 3;
			this.btnBuild_JSON.Text = "JSON File (.json)";
			this.btnBuild_JSON.UseVisualStyleBackColor = true;
			this.btnBuild_JSON.Click += new System.EventHandler(this.btnBuild_JSON_Click);
			// 
			// btnBuild_XML
			// 
			this.btnBuild_XML.Enabled = false;
			this.btnBuild_XML.Location = new System.Drawing.Point(20, 72);
			this.btnBuild_XML.Name = "btnBuild_XML";
			this.btnBuild_XML.Size = new System.Drawing.Size(160, 23);
			this.btnBuild_XML.TabIndex = 2;
			this.btnBuild_XML.Text = "XML File (.xml)";
			this.btnBuild_XML.UseVisualStyleBackColor = true;
			this.btnBuild_XML.Click += new System.EventHandler(this.btnBuild_XML_Click);
			// 
			// btnBuild_Assembly
			// 
			this.btnBuild_Assembly.Location = new System.Drawing.Point(20, 48);
			this.btnBuild_Assembly.Name = "btnBuild_Assembly";
			this.btnBuild_Assembly.Size = new System.Drawing.Size(160, 23);
			this.btnBuild_Assembly.TabIndex = 1;
			this.btnBuild_Assembly.Text = "C# Assembly Library (.dll)";
			this.btnBuild_Assembly.UseVisualStyleBackColor = true;
			this.btnBuild_Assembly.Click += new System.EventHandler(this.btnBuild_Assembly_Click);
			// 
			// btnBuild_CSharpCode
			// 
			this.btnBuild_CSharpCode.Location = new System.Drawing.Point(20, 24);
			this.btnBuild_CSharpCode.Name = "btnBuild_CSharpCode";
			this.btnBuild_CSharpCode.Size = new System.Drawing.Size(160, 23);
			this.btnBuild_CSharpCode.TabIndex = 0;
			this.btnBuild_CSharpCode.Text = "C# Code File (.cs)";
			this.btnBuild_CSharpCode.UseVisualStyleBackColor = true;
			this.btnBuild_CSharpCode.Click += new System.EventHandler(this.btnBuild_CSharpCode_Click);
			// 
			// groupScript
			// 
			this.groupScript.Controls.Add(this.btnScript_InsertIntoParameterized);
			this.groupScript.Controls.Add(this.btnScript_DataBase);
			this.groupScript.Controls.Add(this.btnScript_StoredProcedure);
			this.groupScript.Controls.Add(this.btnScript_CreateTable);
			this.groupScript.Controls.Add(this.btnScript_InsertInto);
			this.groupScript.Location = new System.Drawing.Point(224, 24);
			this.groupScript.Name = "groupScript";
			this.groupScript.Size = new System.Drawing.Size(200, 132);
			this.groupScript.TabIndex = 2;
			this.groupScript.TabStop = false;
			this.groupScript.Text = "SQL Script Builder:";
			// 
			// btnScript_InsertIntoParameterized
			// 
			this.btnScript_InsertIntoParameterized.Location = new System.Drawing.Point(128, 48);
			this.btnScript_InsertIntoParameterized.Name = "btnScript_InsertIntoParameterized";
			this.btnScript_InsertIntoParameterized.Size = new System.Drawing.Size(52, 23);
			this.btnScript_InsertIntoParameterized.TabIndex = 7;
			this.btnScript_InsertIntoParameterized.Text = "PARM";
			this.btnScript_InsertIntoParameterized.UseVisualStyleBackColor = true;
			this.btnScript_InsertIntoParameterized.Click += new System.EventHandler(this.btnScript_InsertIntoParameterized_Click);
			// 
			// btnScript_DataBase
			// 
			this.btnScript_DataBase.Location = new System.Drawing.Point(20, 96);
			this.btnScript_DataBase.Name = "btnScript_DataBase";
			this.btnScript_DataBase.Size = new System.Drawing.Size(160, 23);
			this.btnScript_DataBase.TabIndex = 6;
			this.btnScript_DataBase.Text = "CREATE DATABASE [...]";
			this.btnScript_DataBase.UseVisualStyleBackColor = true;
			this.btnScript_DataBase.Click += new System.EventHandler(this.btnScript_DataBase_Click);
			// 
			// btnScript_StoredProcedure
			// 
			this.btnScript_StoredProcedure.Location = new System.Drawing.Point(20, 72);
			this.btnScript_StoredProcedure.Name = "btnScript_StoredProcedure";
			this.btnScript_StoredProcedure.Size = new System.Drawing.Size(160, 23);
			this.btnScript_StoredProcedure.TabIndex = 5;
			this.btnScript_StoredProcedure.Text = "STORED PROCEDURE [...]";
			this.btnScript_StoredProcedure.UseVisualStyleBackColor = true;
			this.btnScript_StoredProcedure.Click += new System.EventHandler(this.btnScript_StoredProcedure_Click);
			// 
			// btnScript_CreateTable
			// 
			this.btnScript_CreateTable.Location = new System.Drawing.Point(20, 24);
			this.btnScript_CreateTable.Name = "btnScript_CreateTable";
			this.btnScript_CreateTable.Size = new System.Drawing.Size(160, 23);
			this.btnScript_CreateTable.TabIndex = 3;
			this.btnScript_CreateTable.Text = "CREATE TABLE [...]";
			this.btnScript_CreateTable.UseVisualStyleBackColor = true;
			this.btnScript_CreateTable.Click += new System.EventHandler(this.btnScript_CreateTable_Click);
			// 
			// btnScript_InsertInto
			// 
			this.btnScript_InsertInto.Location = new System.Drawing.Point(20, 48);
			this.btnScript_InsertInto.Name = "btnScript_InsertInto";
			this.btnScript_InsertInto.Size = new System.Drawing.Size(102, 23);
			this.btnScript_InsertInto.TabIndex = 4;
			this.btnScript_InsertInto.Text = "INSERT INTO [...]";
			this.btnScript_InsertInto.UseVisualStyleBackColor = true;
			this.btnScript_InsertInto.Click += new System.EventHandler(this.btnScript_InsertInto_Click);
			// 
			// groupBoxCommands
			// 
			this.groupBoxCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxCommands.Controls.Add(this.label3);
			this.groupBoxCommands.Controls.Add(this.tbOutputFilename);
			this.groupBoxCommands.Controls.Add(this.groupCode);
			this.groupBoxCommands.Controls.Add(this.groupScript);
			this.groupBoxCommands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBoxCommands.Location = new System.Drawing.Point(12, 243);
			this.groupBoxCommands.Name = "groupBoxCommands";
			this.groupBoxCommands.Size = new System.Drawing.Size(568, 208);
			this.groupBoxCommands.TabIndex = 7;
			this.groupBoxCommands.TabStop = false;
			this.groupBoxCommands.Text = "2) Execute Commands";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 164);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Output filename:";
			// 
			// tbOutputFilename
			// 
			this.tbOutputFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputFilename.Location = new System.Drawing.Point(10, 180);
			this.tbOutputFilename.Name = "tbOutputFilename";
			this.tbOutputFilename.ReadOnly = true;
			this.tbOutputFilename.Size = new System.Drawing.Size(552, 20);
			this.tbOutputFilename.TabIndex = 8;
			// 
			// tbTableName
			// 
			this.tbTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTableName.Location = new System.Drawing.Point(10, 91);
			this.tbTableName.Name = "tbTableName";
			this.tbTableName.Size = new System.Drawing.Size(237, 20);
			this.tbTableName.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Table name:";
			// 
			// groupBoxConnect
			// 
			this.groupBoxConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxConnect.Controls.Add(this.label5);
			this.groupBoxConnect.Controls.Add(this.btnGenerateSampleData);
			this.groupBoxConnect.Controls.Add(this.label1);
			this.groupBoxConnect.Controls.Add(this.tbConnectionString);
			this.groupBoxConnect.Controls.Add(this.label4);
			this.groupBoxConnect.Controls.Add(this.tbTableName);
			this.groupBoxConnect.Controls.Add(this.tbSelectCommand);
			this.groupBoxConnect.Controls.Add(this.label2);
			this.groupBoxConnect.Controls.Add(this.btnSQLConnect);
			this.groupBoxConnect.Location = new System.Drawing.Point(12, 12);
			this.groupBoxConnect.Name = "groupBoxConnect";
			this.groupBoxConnect.Size = new System.Drawing.Size(568, 216);
			this.groupBoxConnect.TabIndex = 18;
			this.groupBoxConnect.TabStop = false;
			this.groupBoxConnect.Text = "1) Connect to Database";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(119, 188);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "- or -";
			// 
			// btnGenerateSampleData
			// 
			this.btnGenerateSampleData.Location = new System.Drawing.Point(153, 183);
			this.btnGenerateSampleData.Name = "btnGenerateSampleData";
			this.btnGenerateSampleData.Size = new System.Drawing.Size(214, 23);
			this.btnGenerateSampleData.TabIndex = 10;
			this.btnGenerateSampleData.Text = "Generate Sample DataTable Instead";
			this.btnGenerateSampleData.UseVisualStyleBackColor = true;
			this.btnGenerateSampleData.Click += new System.EventHandler(this.btnGenerateSampleData_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 612);
			this.Controls.Add(this.groupBoxConnect);
			this.Controls.Add(this.groupBoxCommands);
			this.Controls.Add(this.tbOutput);
			this.Name = "MainForm";
			this.Text = "EntityJustWorks GUI";
			this.groupCode.ResumeLayout(false);
			this.groupScript.ResumeLayout(false);
			this.groupBoxCommands.ResumeLayout(false);
			this.groupBoxCommands.PerformLayout();
			this.groupBoxConnect.ResumeLayout(false);
			this.groupBoxConnect.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.TextBox tbSelectCommand;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSQLConnect;
        private System.Windows.Forms.GroupBox groupCode;
        private System.Windows.Forms.Button btnBuild_JSON;
        private System.Windows.Forms.Button btnBuild_XML;
        private System.Windows.Forms.Button btnBuild_Assembly;
        private System.Windows.Forms.Button btnBuild_CSharpCode;
        private System.Windows.Forms.GroupBox groupScript;
        private System.Windows.Forms.Button btnScript_DataBase;
        private System.Windows.Forms.Button btnScript_StoredProcedure;
        private System.Windows.Forms.Button btnScript_CreateTable;
        private System.Windows.Forms.Button btnScript_InsertInto;
        private System.Windows.Forms.GroupBox groupBoxCommands;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOutputFilename;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnScript_InsertIntoParameterized;
		private System.Windows.Forms.GroupBox groupBoxConnect;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnGenerateSampleData;
	}
}

