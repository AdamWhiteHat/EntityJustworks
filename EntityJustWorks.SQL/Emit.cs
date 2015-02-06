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
using System.Reflection;
using System.Reflection.Emit;

namespace EntityJustWorks.SQL
{
	/// <summary>
	/// Class assembly emit class
	/// </summary>
	public static class EmitClass
	{
		public static Type DatatableToAssembly(DataTable Table)
		{
			string typeName = Table.TableName;
			string moduleName = string.Format("{0}Module", typeName);
			string assemblyName = string.Format("{0}Assembly", typeName);			

			AssemblyName asmName = new AssemblyName(assemblyName);
			AssemblyBuilderAccess accessModes = AssemblyBuilderAccess.RunAndSave;
			AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, accessModes);

			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(moduleName, string.Format("{0}.mod", moduleName), true);
			TypeAttributes typeAttributes = TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.AutoClass;

			TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, typeAttributes);

			foreach (DataColumn column in Table.Columns)
			{
				string propertyName = column.ColumnName;
				Type propertyType = column.DataType;

				PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(
														propertyName,
														System.Reflection.PropertyAttributes.HasDefault,
														propertyType,
														null
													);

				// This is the private backing member for the property
				FieldBuilder fieldPropBacker = typeBuilder.DefineField(
													"_" + propertyName.ToLower(),
													propertyType,
													FieldAttributes.Private
												);	

				// The property set and property get methods require a special set of attributes.
				MethodAttributes accessorAttributes =	MethodAttributes.Public |
														MethodAttributes.SpecialName |
														MethodAttributes.HideBySig;	// 2182

				int attrVal = (int)accessorAttributes; // 2182

				// Define the get accessor method
				MethodBuilder getAccessor = typeBuilder.DefineMethod(
												"get_" + propertyName,
												accessorAttributes,
												propertyType,
												Type.EmptyTypes
											);

				ILGenerator getIL = getAccessor.GetILGenerator();
				getIL.Emit(OpCodes.Ldarg_0);
				getIL.Emit(OpCodes.Ldfld, fieldPropBacker);
				getIL.Emit(OpCodes.Ret);

				// Define the set accessor method
				MethodBuilder setAccessor = typeBuilder.DefineMethod(
												"set_" + propertyName,
												accessorAttributes,
												null,
												new Type[] { propertyType }
											);

				ILGenerator setIL = setAccessor.GetILGenerator();
				setIL.Emit(OpCodes.Ldarg_0);
				setIL.Emit(OpCodes.Ldarg_1);
				setIL.Emit(OpCodes.Stfld, fieldPropBacker);
				setIL.Emit(OpCodes.Ret);

				// Set the getter and the setter
				propertyBuilder.SetGetMethod(getAccessor);
				propertyBuilder.SetSetMethod(setAccessor);
			}

			Type result = typeBuilder.CreateType();
			
			// Save the assembly
			assemblyBuilder.Save(assemblyName + ".dll");

			return result;
		}
	}
}
