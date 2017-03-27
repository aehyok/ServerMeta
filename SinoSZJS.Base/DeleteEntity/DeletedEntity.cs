using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.DeleteEntity
{
	public class DeletedEntity
	{
		protected object structDefine = null;
		protected object deletedData = null;

		public DeletedEntity(object _define, object _data)
		{
			structDefine = _define;
			deletedData = _data;
		}

		public object StructDefine
		{
			get { return structDefine; }
			set { structDefine = value; }
		}

		public object DeletedData
		{
			get { return deletedData; }
			set { deletedData = value; }
		}

	}
}
