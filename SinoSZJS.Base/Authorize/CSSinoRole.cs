using System;

namespace SinoSZJS.Base.Authorize
{
	/// <summary>
	/// CSSinoRole ��ժҪ˵����
	/// ���ڿͻ��˵Ľ�ɫ�࣬�������SinoRole
	/// </summary>
	/// 
	[Serializable()]
	public class CSSinoRole:SinoRole
	{
		public CSSinoRole()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public override string ToString()
		{
			return string.Format("{0} [{1}]",RoleName,(RoleDwid == "")?"ͨ�ý�ɫ":"˽�н�ɫ");
		}

	}
}
