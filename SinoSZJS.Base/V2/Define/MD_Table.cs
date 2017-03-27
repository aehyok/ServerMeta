using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
namespace SinoSZJS.Base.V2.MetaData.Define
{
	[DataContract]
	public class MD_Table
	{
		public MD_Table(string id, string ns, string tname, string ttype, string des, string title, string mkey,
		string dw, string sfun, string extfun)
		{
			TID = id;
			NamespaceName = ns;
			TableName = tname;
			TableType = ttype;
			Description = des;
			DisplayTitle = title;
			MainKey = mkey;
			DWDM = dw;
			SecretFun = sfun;
			ExtSecret = extfun;
		}

		public MD_Table(string id, string ns, string tname, string ttype, string des, string title, string mkey,
		string dw, string sfun, string extfun, string resType)
		{
			TID = id;
			NamespaceName = ns;
			TableName = tname;
			TableType = ttype;
			Description = des;
			DisplayTitle = title;
			MainKey = mkey;
			DWDM = dw;
			SecretFun = sfun;
			ExtSecret = extfun;
			if (resType != null)
			{
				ResourceType = resType.Split(',').ToList<string>();
			}
			else
			{
				ResourceType = new List<string>();
			}
		}

		[DataMember]
		public List<string> ResourceType { get; set; }

		/// <summary>
		/// �����ռ�
		/// </summary>
		[DataMember]
		public string NamespaceName { get; set; }

		/// <summary>
		/// ���ID
		/// </summary>
		[DataMember]
		public string TID { get; set; }

		/// <summary>
		/// ������
		/// </summary>
		[DataMember]
		public virtual string TableName { get; set; }

		/// <summary>
		/// ������
		/// </summary>
		[DataMember]
		public string TableType { get; set; }

		/// <summary>
		/// �������
		/// </summary>
		[DataMember]
		public string Description { get; set; }

		/// <summary>
		/// �����ʾ����
		/// </summary>
		[DataMember]
		public string DisplayTitle { get; set; }

		/// <summary>
		/// ��������ֶ�����
		/// </summary>
		[DataMember]
		public string MainKey { get; set; }

		/// <summary>
		/// �ڵ���
		/// </summary>
		[DataMember]
		public string DWDM { get; set; }

		/// <summary>
		/// ��ȫ����
		/// </summary>
		[DataMember]
		public string SecretFun { get; set; }

		/// <summary>
		/// ��չ��ȫ����
		/// </summary>
		[DataMember]
		public string ExtSecret { get; set; }

		/// <summary>
		/// ������ֶ��б�
		/// </summary>
		[DataMember]
		public IList<MD_TableColumn> Columns { get; set; }

		/// <summary>
		/// ����������ֶ�
		/// </summary>
		[DataMember]
		public MD_TableColumn MainKeyColumn { get; set; }

		public override string ToString()
		{
			return DisplayTitle;
		}
	}
}
