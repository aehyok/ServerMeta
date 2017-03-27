using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZClientSysManager.FsAlertMailSet
{
	[Serializable]
	public class AlertMailReceiverItem
	{
		private string id = "";
		private string lx = "";
		private string receiver = "";

		public string ID
		{
			get { return id; }
			set { id = value; }
		}

		public string LX
		{
			get { return lx; }
			set { lx = value; }
		}

		public string Receiver
		{
			get { return receiver; }
			set { receiver = value; }
		}

		public AlertMailReceiverItem() { }
		public AlertMailReceiverItem(string _id, string _lx, string _receiver)
		{
			id = _id;
			lx = _lx;
			receiver = _receiver;
		}
		public override string ToString()
		{
			return this.receiver;
		}
	}
}
