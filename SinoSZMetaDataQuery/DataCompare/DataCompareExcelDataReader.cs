using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using SinoSZJS.Base.Excel;

namespace SinoSZMetaDataQuery.DataCompare
{
	public class DataCompareExcelDataReader
	{
		private string ExcelFileName = "";
		private string ConnectString = "";
		private string TableName = "";
		private List<ExcelColumnAlias> Columns = null;
		public DataCompareExcelDataReader() { }
		public DataCompareExcelDataReader(string FileName)
		{
			ExcelFileName = FileName;
			ConnectString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\";Data Source={0};", FileName);

		}

		public DataTable GetData()
		{
			DataTable _ret = new DataTable();
			using (OleDbConnection conn = new OleDbConnection(ConnectString))
			{
				try
				{
					conn.Open();
					StringBuilder _sb = new StringBuilder();
					_sb.Append(" select ");
					string _fg = "";
					foreach (ExcelColumnAlias _col in Columns)
					{
						_sb.Append(string.Format("{0}[{1}] {2}", _fg, _col.ColumnName, _col.Alias));
						_fg = ",";
					}
					_sb.Append(string.Format(" from [{0}] ", TableName));
					string _sql = string.Format("select * from [{0}] ", TableName);
					OleDbDataAdapter _da = new OleDbDataAdapter(_sql, conn);
					_da.Fill(_ret);
					conn.Close();
				}
				catch (Exception ex)
				{
					XtraMessageBox.Show(string.Format("读取EXCEL表数据错误!{0} \n 可能解决方法：请用EXCEL打开此文档，并以 Microsoft Office Excel 格式另存为其它文档进行比对。", ex.Message), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
			}
			_ret.Columns.Add("XH", typeof(decimal));
			decimal i = 2;
			foreach (DataRow _dr in _ret.Rows)
			{
				_dr["XH"] = i;
				i++;
			}
			_ret.AcceptChanges();
			return _ret;
		}

		public List<ExcelColumnAlias> GetColumns()
		{
			if (Columns == null)
			{
				if (ExcelFileName == "") return new List<ExcelColumnAlias>();
				using (OleDbConnection conn = new OleDbConnection(ConnectString))
				{
					try
					{
						conn.Open();
						DataTable _sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
						if (_sheets.Rows.Count < 1)
						{
							XtraMessageBox.Show("您选择的EXCEL表没有Sheet!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else if (_sheets.Rows.Count == 1)
						{
							TableName = _sheets.Rows[0]["TABLE_NAME"].ToString();
							Columns = GetTableColumns(conn);
						}
						else
						{
							List<string> _tnames = new List<string>();
							foreach (DataRow _dr in _sheets.Rows)
							{
								_tnames.Add(_dr["TABLE_NAME"].ToString());
							}
							Dialog_SelectExcelSheet _f = new Dialog_SelectExcelSheet(_tnames);
							_f.ShowDialog();
							TableName = _f.SelectTableName;
							Columns = GetTableColumns(conn);
						}
					}
					catch (Exception ex)
					{
						throw;
					}
					conn.Close();
				}
			}
			return Columns;
		}

		private List<ExcelColumnAlias> GetTableColumns(OleDbConnection conn)
		{
			List<ExcelColumnAlias> _ret = new List<ExcelColumnAlias>();
			DataTable _columnTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, TableName, null });
			int i = 1;
			foreach (DataRow _dr in _columnTable.Rows)
			{
				string _colName = _dr["COLUMN_NAME"].ToString();
				if (_colName.Contains("\"") || _colName.Length > 15)
				{
					throw new Exception(string.Format("字段名称字符大于15或包含引号！ Column={0}", _colName));
				}
				ExcelColumnAlias _col = new ExcelColumnAlias();
				_col.Alias = string.Format("C{0}", i.ToString("D2"));
				i++;
				_col.ColumnName = _colName;
				_ret.Add(_col);
			}
			return _ret;
		}



		public Dictionary<string, string> CreateColumnDictionary()
		{
			Dictionary<string, string> _ret = new Dictionary<string, string>();
			foreach (ExcelColumnAlias _ec in this.Columns)
			{
				_ret.Add(_ec.Alias, _ec.ColumnName);
			}
			return _ret;
		}
	}
}
