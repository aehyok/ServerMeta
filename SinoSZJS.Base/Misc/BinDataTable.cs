//	BinDataTable.cs
//
//	.NET Framework类库中的DataTable序列化效率太低，因此重新定义一个
//
//	作者:		黄晓东(2003.6 --- 2003.11.28)
//	
//	描述:
//
//	设计思路:
//
//	版本特性:
//		1. 增加了TableName的序列化(2003.11.26)
//
//	遗留问题:
//		1. 没有将所有信息进行序列化, 包括数据行版本等等!!!!


using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace System.Data
{
	public class BinDataTable : DataTable, ISerializable
	{
		public BinDataTable() : base()
		{
		}

		public BinDataTable(string name) : base(name)
		{
		}
		
		protected BinDataTable(SerializationInfo si, StreamingContext context) 
		{
			// DO NOT call the base ctor otherwise an exception will be thrown

			// Extract from the serialization info
			this.TableName		= si.GetString("TableName");
			ArrayList colNames	= (ArrayList) si.GetValue("ColNames", typeof(ArrayList));
			ArrayList colTypes	= (ArrayList) si.GetValue("ColTypes", typeof(ArrayList)); 
			ArrayList dataRows	= (ArrayList) si.GetValue("DataRows", typeof(ArrayList)); 

			// Add columns
			for(int i=0; i<colNames.Count; i++)
				{
				DataColumn col = new DataColumn(colNames[i].ToString(), 
					Type.GetType(colTypes[i].ToString() )); 	
				this.Columns.Add(col);
				}

			// Add rows
			foreach (object[] dataRow in dataRows)
				{
				DataRow row = this.NewRow();
				row.ItemArray = dataRow;
				this.Rows.Add(row);
				}

			this.AcceptChanges();
		}

		void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo si, StreamingContext context)
		{
			// DO NOT call the base method otherwise XML will slip into the data
			//base.GetObjectData(si, context);

			// Add arrays
			ArrayList colNames = new ArrayList();
			ArrayList colTypes = new ArrayList();
			ArrayList dataRows = new ArrayList();

			// Insert column information (names and types) into worker arrays
			foreach(DataColumn col in this.Columns)
				{
				colNames.Add(col.ColumnName); 
				colTypes.Add(col.DataType.FullName);   
				}

			// Insert rows information into a worker array
			foreach(DataRow row in this.Rows)
				dataRows.Add(row.ItemArray);

			// Add arrays to the serialization info structure
			si.AddValue("TableName", this.TableName);
			si.AddValue("ColNames", colNames);
			si.AddValue("ColTypes", colTypes);
			si.AddValue("DataRows", dataRows);
		}
	}
}