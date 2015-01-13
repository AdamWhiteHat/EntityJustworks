<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/1999/REC-html401-19991224/strict.dtd">
<html>
<head>
<META http-equiv=Content-Type content="text/html; charset=UTF-8">
<title>Exported from Notepad++</title>
<style type="text/css">
span {
	font-family: 'Courier New';
	font-size: 10pt;
	color: #000000;
}
.sc0 {
}
.sc2 {
	color: #008000;
}
.sc5 {
	font-weight: bold;
	color: #0000FF;
}
.sc10 {
	font-weight: bold;
	color: #000080;
}
.sc11 {
}
.sc15 {
	color: #008080;
}
.sc16 {
	color: #8000FF;
}
</style>
</head>
<body>
<div style="float: left; white-space: pre; line-height: 1; background: #FFFFFF; "><span class="sc15">/// &lt;summary&gt;
/// EntityJustWorks - Entity/data mapper
/// EntityJustWorks.SQL - Provides entity/object/class mapping to SQL repositories and back again. Uses reflection and System.Data.DataTable.
/// &lt;/summary&gt;
</span><span class="sc5">namespace</span><span class="sc0"> </span><span class="sc11">EntityJustWorks</span><span class="sc10">.</span><span class="sc11">SQL</span><span class="sc0">
</span><span class="sc10">{</span><span class="sc0">
    </span><span class="sc15">/// &lt;summary&gt; Convert from class to SQL table or from SQL Table to C# class code file &lt;/summary&gt;
</span><span class="sc0">    </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0"> </span><span class="sc11">Convert</span><span class="sc0">
    </span><span class="sc10">{</span><span class="sc0">
        </span><span class="sc15">/// &lt;summary&gt; 
</span><span class="sc0">        </span><span class="sc15">/// Generates a C# class code file from a Database given an SQL connection string and table name.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">SQLToCSharp</span><span class="sc10">(</span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">ConnectionString</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">TableName</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Creates an SQL table from a class object.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">bool</span><span class="sc0"> </span><span class="sc11">ClassToSQL</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">ConnectionString</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc5">params</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">ClassCollection</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc11">where</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc10">:</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0">
    </span><span class="sc10">}</span><span class="sc0">
    
    
    </span><span class="sc15">/// &lt;summary&gt; SQL Script Generation Class &lt;/summary&gt;
</span><span class="sc0">    </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0"> </span><span class="sc11">Script</span><span class="sc0">
    </span><span class="sc10">{</span><span class="sc0">
        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Creates a SQL script that inserts the values of the specified classes' public properties into a table.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">InsertInto</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc5">params</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">ClassObjects</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc11">where</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc10">:</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Creates a SQL script that inserts the cell values of a DataTable's DataRows into a table.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">InsertInto</span><span class="sc10">(</span><span class="sc11">DataTable</span><span class="sc0"> </span><span class="sc11">Table</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Creates a SQL script that creates a table where the column names match the specified class's public properties.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">CreateTable</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc5">params</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">ClassObjects</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc11">where</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc10">:</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Creates a SQL script that creates a table where the columns matches that of the specified DataTable.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">CreateTable</span><span class="sc10">(</span><span class="sc11">DataTable</span><span class="sc0"> </span><span class="sc11">Table</span><span class="sc10">)</span><span class="sc0">
    </span><span class="sc10">}</span><span class="sc0">
    
    
    </span><span class="sc15">/// &lt;summary&gt; DataTable/Class Mapping Class &lt;/summary&gt;
</span><span class="sc0">    </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0"> </span><span class="sc11">Map</span><span class="sc0">
    </span><span class="sc10">{</span><span class="sc0">
        </span><span class="sc2">//// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Fills properties of a class from a row of a DataTable where the name of the property matches the column name from that DataTable.
</span><span class="sc0">        </span><span class="sc15">/// It does this for each row in the DataTable, returning a List of classes.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;typeparam name="T"&gt;The class type that is to be returned.&lt;/typeparam&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="Table"&gt;DataTable to fill from.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;A list of ClassType with its properties set to the data from the matching columns from the DataTable.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc11">IList</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;</span><span class="sc0"> </span><span class="sc11">DatatableToClass</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc11">DataTable</span><span class="sc0"> </span><span class="sc11">Table</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc11">where</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc10">:</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc10">()</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Creates a DataTable from a class type's public properties and adds a new DataRow to the table for each class passed as a parameter.
</span><span class="sc0">        </span><span class="sc15">/// The DataColumns of the table will match the name and type of the public properties.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="ClassCollection"&gt;A class or array of class to fill the DataTable with.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc11">DataTable</span><span class="sc0"> </span><span class="sc11">ClassToDatatable</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc5">params</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">ClassCollection</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc11">where</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc10">:</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Creates a DataTable from a class type's public properties. The DataColumns of the table will match the name and type of the public properties.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;typeparam name="T"&gt;The type of the class to create a DataTable from.&lt;/typeparam&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;A DataTable who's DataColumns match the name and type of each class T's public properties.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc11">DataTable</span><span class="sc0"> </span><span class="sc11">ClassToDatatable</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;()</span><span class="sc0"> </span><span class="sc11">where</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc10">:</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0">
    </span><span class="sc10">}</span><span class="sc0">
    
    
    </span><span class="sc15">/// &lt;summary&gt; SQL Query Helper Class &lt;/summary&gt;
</span><span class="sc0">    </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0"> </span><span class="sc11">Query</span><span class="sc0">
    </span><span class="sc10">{</span><span class="sc0">
        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Runs a SQL query and returns the results as a List of the specified class
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;typeparam name="T"&gt;The type the result will be returned as.&lt;/typeparam&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="ConnectionString"&gt;The SQL connection string.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;A List of classes that represent the records returned.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc11">IList</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;</span><span class="sc0"> </span><span class="sc11">QueryToClass</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">ConnectionString</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">FormatString_Query</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc5">params</span><span class="sc0"> </span><span class="sc5">object</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">FormatString_Parameters</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc11">where</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc10">:</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc10">()</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Executes an SQL query and returns the results as a DataTable.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="ConnectionString"&gt;The SQL connection string.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Query"&gt;A SQL command that will be passed to string.Format().&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Parameters"&gt;The parameters for string.Format().&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;The results of the query as a DataTable.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc11">DataTable</span><span class="sc0"> </span><span class="sc11">QueryToDataTable</span><span class="sc10">(</span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">ConnectionString</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">FormatString_Query</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc5">params</span><span class="sc0"> </span><span class="sc5">object</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">FormatString_Parameters</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Executes a query, and returns the first column of the first row in the result set returned by the query.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;typeparam name="T"&gt;The type the result will be returned as.&lt;/typeparam&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="ConnectionString"&gt;&gt;The SQL connection string.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Query"&gt;The SQL query as string.Format string.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Parameters"&gt;The string.Format parameters.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;The  first column of the first row in the result, converted and casted to type T.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc11">T</span><span class="sc0"> </span><span class="sc11">QueryToScalarType</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">ConnectionString</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">FormatString_Query</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc5">params</span><span class="sc0"> </span><span class="sc5">object</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">FormatString_Parameters</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Executes a non-query SQL command, such as INSERT or DELETE
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="ConnectionString"&gt;The connection string.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Command"&gt;The SQL command, as a format string.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="FormatString_Parameters"&gt;The parameters for the format string.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;The number of rows affected, or -1 on errors.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">int</span><span class="sc0"> </span><span class="sc11">ExecuteNonQuery</span><span class="sc10">(</span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">ConnectionString</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">FormatString_Command</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc5">params</span><span class="sc0"> </span><span class="sc5">object</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">FormatString_Parameters</span><span class="sc10">)</span><span class="sc0">
    </span><span class="sc10">}</span><span class="sc0">
    
    
    </span><span class="sc15">/// &lt;summary&gt; Helper Functions. Conversion, Validation &lt;/summary&gt;
</span><span class="sc0">    </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0"> </span><span class="sc11">Helper</span><span class="sc0">
    </span><span class="sc10">{</span><span class="sc0">
        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Indicates whether a specified DataTable is null, has zero columns, or (optionally) zero rows.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="Table"&gt;DataTable to check.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="IgnoreRows"&gt;When set to true, the function will return true even if the table's row count is equal to zero.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;False if the specified DataTable null, has zero columns, or zero rows, otherwise true.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">bool</span><span class="sc0"> </span><span class="sc11">IsValidDatatable</span><span class="sc10">(</span><span class="sc11">DataTable</span><span class="sc0"> </span><span class="sc11">Table</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc16">bool</span><span class="sc0"> </span><span class="sc11">IgnoreRows</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">false</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Indicates whether a specified Enumerable collection is null or an empty collection.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;typeparam name="T"&gt;The specified type contained in the collection.&lt;/typeparam&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="Input"&gt;An Enumerator to the collection to check.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;True if the specified Enumerable collection is null or empty, otherwise false.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">bool</span><span class="sc0"> </span><span class="sc11">IsCollectionEmpty</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;(</span><span class="sc11">IEnumerable</span><span class="sc10">&lt;</span><span class="sc11">T</span><span class="sc10">&gt;</span><span class="sc0"> </span><span class="sc11">Input</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">///  Indicates whether a specified Type can be assigned null.
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;param name="Input"&gt;The Type to check for nullable property.&lt;/param&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;True if the specified Type can be assigned null, otherwise false.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">bool</span><span class="sc0"> </span><span class="sc11">IsNullableType</span><span class="sc10">(</span><span class="sc11">Type</span><span class="sc0"> </span><span class="sc11">Input</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Returns all the column names of the specified DataRow in a string delimited like and SQL INSERT INTO statement.
</span><span class="sc0">        </span><span class="sc15">/// Example: ([FullName], [Gender], [BirthDate])
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;A string formatted like the columns specified in an SQL 'INSERT INTO' statement.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">RowToColumnString</span><span class="sc10">(</span><span class="sc11">DataRow</span><span class="sc0"> </span><span class="sc11">Row</span><span class="sc10">)</span><span class="sc0">

        </span><span class="sc15">/// &lt;summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// Returns all the values the specified DataRow in as a string delimited like and SQL INSERT INTO statement.
</span><span class="sc0">        </span><span class="sc15">/// Example: ('John Doe', 'M', '10/3/1981'')
</span><span class="sc0">        </span><span class="sc15">/// &lt;/summary&gt;
</span><span class="sc0">        </span><span class="sc15">/// &lt;returns&gt;A string formatted like the values specified in an SQL 'INSERT INTO' statement.&lt;/returns&gt;
</span><span class="sc0">        </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">string</span><span class="sc0"> </span><span class="sc11">RowToValueString</span><span class="sc10">(</span><span class="sc11">DataRow</span><span class="sc0"> </span><span class="sc11">Row</span><span class="sc10">)</span><span class="sc0">
    </span><span class="sc10">}</span><span class="sc0">
</span><span class="sc10">}</span><span class="sc0">
</span></div></body>
</html>
