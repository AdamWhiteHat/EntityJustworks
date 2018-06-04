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
			this.btnScript_DataBase = new System.Windows.Forms.Button();
			this.btnScript_StoredProcedure = new System.Windows.Forms.Button();
			this.btnScript_CreateTable = new System.Windows.Forms.Button();
			this.btnScript_InsertInto = new System.Windows.Forms.Button();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbOutputFilename = new System.Windows.Forms.TextBox();
			this.tbTableName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbEncodeSource = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbEncodeOutput = new System.Windows.Forms.TextBox();
			this.btnEncode = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.btnScript_InsertIntoParameterized = new System.Windows.Forms.Button();
			this.groupCode.SuspendLayout();
			this.groupScript.SuspendLayout();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbConnectionString
			// 
			this.tbConnectionString.Location = new System.Drawing.Point(12, 28);
			this.tbConnectionString.Name = "tbConnectionString";
			this.tbConnectionString.Size = new System.Drawing.Size(522, 20);
			this.tbConnectionString.TabIndex = 0;
			this.tbConnectionString.Text = "Server=DMX-DT010;Database=DB_Into_Interlink;User ID=AppUser;Password=abc123;";
			// 
			// tbSelectCommand
			// 
			this.tbSelectCommand.Location = new System.Drawing.Point(540, 71);
			this.tbSelectCommand.Name = "tbSelectCommand";
			this.tbSelectCommand.Size = new System.Drawing.Size(275, 20);
			this.tbSelectCommand.TabIndex = 1;
			// 
			// tbOutputText
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(4, 268);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutputText";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(812, 192);
			this.tbOutput.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Connection string:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(536, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "SELECT command:";
			// 
			// btnSQLConnect
			// 
			this.btnSQLConnect.Location = new System.Drawing.Point(711, 26);
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
			// groupBox
			// 
			this.groupBox.Controls.Add(this.label3);
			this.groupBox.Controls.Add(this.tbOutputFilename);
			this.groupBox.Controls.Add(this.groupCode);
			this.groupBox.Controls.Add(this.groupScript);
			this.groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox.Location = new System.Drawing.Point(16, 56);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(444, 208);
			this.groupBox.TabIndex = 7;
			this.groupBox.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 164);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Output filename:";
			// 
			// tbOutputFilename
			// 
			this.tbOutputFilename.Location = new System.Drawing.Point(20, 180);
			this.tbOutputFilename.Name = "tbOutputFilename";
			this.tbOutputFilename.ReadOnly = true;
			this.tbOutputFilename.Size = new System.Drawing.Size(404, 20);
			this.tbOutputFilename.TabIndex = 8;
			// 
			// tbTableName
			// 
			this.tbTableName.Location = new System.Drawing.Point(540, 28);
			this.tbTableName.Name = "tbTableName";
			this.tbTableName.Size = new System.Drawing.Size(106, 20);
			this.tbTableName.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(536, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Table name:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(501, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "From";
			// 
			// tbEncodeSource
			// 
			this.tbEncodeSource.Location = new System.Drawing.Point(505, 152);
			this.tbEncodeSource.Name = "tbEncodeSource";
			this.tbEncodeSource.Size = new System.Drawing.Size(228, 20);
			this.tbEncodeSource.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(501, 179);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "To";
			// 
			// tbEncodeOutput
			// 
			this.tbEncodeOutput.Location = new System.Drawing.Point(505, 195);
			this.tbEncodeOutput.Name = "tbEncodeOutput";
			this.tbEncodeOutput.Size = new System.Drawing.Size(275, 20);
			this.tbEncodeOutput.TabIndex = 10;
			// 
			// btnEncode
			// 
			this.btnEncode.Location = new System.Drawing.Point(739, 136);
			this.btnEncode.Name = "btnEncode";
			this.btnEncode.Size = new System.Drawing.Size(67, 23);
			this.btnEncode.TabIndex = 14;
			this.btnEncode.Text = "Base64";
			this.btnEncode.UseVisualStyleBackColor = true;
			this.btnEncode.Click += new System.EventHandler(this.decode_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(529, 221);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(63, 23);
			this.button2.TabIndex = 15;
			this.button2.Text = "ArrayStr";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.decode_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(663, 221);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(63, 23);
			this.button3.TabIndex = 17;
			this.button3.Text = "DeArrayStr";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.decode_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(739, 165);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(67, 23);
			this.button4.TabIndex = 16;
			this.button4.Text = "DeBase64";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.decode_Click);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 463);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnEncode);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbEncodeSource);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbEncodeOutput);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbTableName);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.btnSQLConnect);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.tbSelectCommand);
			this.Controls.Add(this.tbConnectionString);
			this.Name = "MainForm";
			this.Text = "EntityJustWorks GUI";
			this.groupCode.ResumeLayout(false);
			this.groupScript.ResumeLayout(false);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOutputFilename;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEncodeSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEncodeOutput;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btnScript_InsertIntoParameterized;
    }
}

