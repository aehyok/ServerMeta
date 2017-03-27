using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.RefCode
{
	public class RefCodeTable
	{
		#region Properties
		//代码表名
		private RefCodeTablePropertie _properties = new RefCodeTablePropertie();        //代码表属性
		protected List<RefCodeData> _codeData = null;                                   //代码记录内容
		protected Dictionary<string, List<RefCodeData>> _levelCodeData = new Dictionary<string, List<RefCodeData>>();
		public string Name
		{
			get
			{

				return _properties.Name;
			}
		}                                    //代码表名
		public int Count
		{
			get
			{
				if (_codeData == null) return 0;
				return _codeData.Count;
			}
		}                            //代码条数
		public List<RefCodeData> CodeData                                               //代码记录内容
		{
			get { return _codeData; }
			set { _codeData = value; }
		}
		public RefCodeTablePropertie Properties                                         //代码表属性
		{
			get { return _properties; }
			set { _properties = value; }
		}

		public Dictionary<string, List<RefCodeData>> LevelCodeData
		{
			get { return _levelCodeData; }
			set { _levelCodeData = value; }
		}

		public List<RefCodeData> GetChildRefCodes(string _fatherCode)
		{
			if (_levelCodeData.ContainsKey(_fatherCode))
			{
				return _levelCodeData[_fatherCode];
			}
			else
			{
				List<RefCodeData> _ret = new List<RefCodeData>();
				foreach (RefCodeData _data in _codeData)
				{
					if (_data.FatherCode == _fatherCode)
					{
						_ret.Add(_data);
					}
				}
				_levelCodeData.Add(_fatherCode, _ret);
				return _ret;
			}
		}
		#endregion
	}
}
