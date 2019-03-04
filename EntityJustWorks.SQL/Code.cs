/* 
 * EntityJustWorks.SQL - C# class object to/from SQL database
 * 
 * 
 *  Full code and more available @
 *    https://csharpcodewhisperer.blogspot.com
 *    
 *  Or check for updates @
 *    https://github.com/AdamWhiteHat/EntityJustworks
 * 
 */
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.CodeDom;
using Microsoft.CSharp;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace EntityJustWorks.SQL
{
	/// <summary>
	/// C# Code Generation Class
	/// </summary>
	public static class Code
	{
		private static string invalidNameCharacters = "(){}[]<>|,./\\\"?;:'~`!@#$%^&*-=+";
		private static char[] characterArray;

		static Code()
		{
			characterArray = invalidNameCharacters.ToCharArray();
		}

		private static string SanitizeString(string input)
		{
			return new string(input.Where(c => !characterArray.Contains(c)).ToArray());
		}

		public static FileInfo CreateCode(DataTable dataTable, string filename = null)
		{
			// CodeGeneratorOptions so the output is clean and easy to read
			CodeGeneratorOptions codeOptions = CreateGeneratorOptions();

			string result = string.Empty;

			CodeNamespace codeNamespace = Code.CreateCodeNamespace(dataTable);

			var utf8Encoding = new UTF8Encoding(false, true);

			using (MemoryStream memoryStream = new MemoryStream())
			using (TextWriter textWriter = new StreamWriter(memoryStream, utf8Encoding))
			using (CSharpCodeProvider codeProvider = new CSharpCodeProvider())
			{
				codeProvider.GenerateCodeFromNamespace(codeNamespace, textWriter, codeOptions);
				textWriter.Flush();
				memoryStream.Position = 0;

				using (StreamReader streamReader = new StreamReader(memoryStream, utf8Encoding))
				{
					result = streamReader.ReadToEnd();
				}
			}
			
			// Correct our little auto-property 'hack'
			result = result.Replace("//;", "");

			if (string.IsNullOrWhiteSpace(filename))
			{
				filename = Path.GetRandomFileName();
			}

			// Save file (if appropriate)
			File.WriteAllText(filename, result);

			return new FileInfo(filename);
		}

		private static CodeNamespace CreateCodeNamespace(DataTable dataTable)
		{
			string className = SanitizeString(dataTable.TableName);
			CodeTypeDeclaration classDeclaration = CreateClass(className);

			foreach (DataColumn column in dataTable.Columns)
			{
				classDeclaration.Members.Add(CreateProperty(SanitizeString(column.ColumnName), column.DataType));
			}

			string namespaceName = new StackFrame(2).GetMethod().DeclaringType.Namespace;

			CodeNamespace codeNamespace = new CodeNamespace(namespaceName);
			codeNamespace.Types.Add(classDeclaration);

			return codeNamespace;
		}

		private static CodeTypeDeclaration CreateClass(string className)
		{
			CodeTypeDeclaration result = new CodeTypeDeclaration(className);
			result.Attributes = MemberAttributes.Public;
			result.Members.Add(CreateConstructor(className)); // Add class constructor
			return result;
		}

		private static CodeConstructor CreateConstructor(string className)
		{
			CodeConstructor result = new CodeConstructor();
			result.Attributes = MemberAttributes.Public;
			result.Name = className;
			return result;
		}

		private static CodeMemberField CreateProperty(string fieldName, Type propertyType)
		{
			// This is a little hack. Since you cant create auto properties in CodeDOM,
			//  we make the getter and setter part of the member name.
			// This leaves behind a trailing semicolon that we comment out.
			// Later, after code generation, we remove the commented out semicolons for aesthetics.
			string memberName = fieldName + "\t{ get; set; }//";

			CodeMemberField result = new CodeMemberField(propertyType, memberName);
			result.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			return result;
		}

		private static CodeGeneratorOptions CreateGeneratorOptions()
		{
			CodeGeneratorOptions codeOptions = new CodeGeneratorOptions();
			codeOptions.BlankLinesBetweenMembers = false;
			codeOptions.VerbatimOrder = true;
			codeOptions.BracingStyle = "C";
			codeOptions.IndentString = "\t";
			return codeOptions;
		}
	}
}
