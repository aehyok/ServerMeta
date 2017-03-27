using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.Misc;
using SinoSZPluginFramework;


namespace SinoSZClientSysManager.FsAlertMailSet
{
	public partial class frmFsAlertMainSet : frmBase
	{

		private string Param = "";
		public frmFsAlertMainSet()
		{
			InitializeComponent();
		}

		public override void Init(string _title, string _menuName, object _param)
		{
			this.Text = _title;
			this._menuPageName = _menuName;
			Param = _param as string;
			string[] _lxstrs = StrUtils.GetMetaByName2("����", Param).Split(',');
			this.comboBoxEdit1.Properties.Items.Clear();
			foreach (string _s in _lxstrs)
			{
				this.comboBoxEdit1.Properties.Items.Add(_s);
			}
			this._initFinished = true;
			if (this.comboBoxEdit1.Properties.Items.Count > 0)
			{
				this.comboBoxEdit1.SelectedIndex = 0;
				ShowSelectedProjectData();
			}

		}




		#region ���ػ���ķ���

		protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
		{
			IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

			FrmMenuGroup _thisGroup = new FrmMenuGroup("���ݼ�����ʾ�ʼ�����");
			_thisGroup.MenuItems = new List<FrmMenuItem>();
			FrmMenuItem _item = new FrmMenuItem("���", "���", global::SinoSZClientSysManager.Properties.Resources.e5, true);
			_thisGroup.MenuItems.Add(_item);
			bool _showChengedMenu = (this.listBoxControl1.SelectedItem != null);
			_item = new FrmMenuItem("ɾ��", "ɾ��", global::SinoSZClientSysManager.Properties.Resources.e6, _showChengedMenu);
			_thisGroup.MenuItems.Add(_item);
			_item = new FrmMenuItem("�޸�", "�޸�", global::SinoSZClientSysManager.Properties.Resources.e7, _showChengedMenu);
			_thisGroup.MenuItems.Add(_item);

			_ret.Add(_thisGroup);

			return _ret;
		}

		protected override bool ExcuteCommand(string _cmdName)
		{
			switch (_cmdName)
			{
				case "���":
					AddNew();
					break;
				case "ɾ��":
					DeleteReciever();
					break;
				case "�޸�":
					Modify();
					break;
			}
			return true;
		}

		private void DeleteReciever()
		{
            //if (this.listBoxControl1.SelectedItem != null)
            //{
            //    AlertMailReceiverItem _item = this.listBoxControl1.SelectedItem as AlertMailReceiverItem;
            //    SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient();
            //    if (_csc.DelFsDataLoadAlertReceiver(_item.ID))
            //    {
            //        ShowSelectedProjectData();
            //    }
            //}
		}

		private void Modify()
		{
            //if (this.listBoxControl1.SelectedItem != null)
            //{
            //    AlertMailReceiverItem _item = this.listBoxControl1.SelectedItem as AlertMailReceiverItem;
            //    Dialog_ModifyReciver _f = new Dialog_ModifyReciver(_item.Receiver);
            //    if (_f.ShowDialog() == DialogResult.OK)
            //    {
            //        SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient();
            //        if (_csc.ModifyFsDataLoadAlertReceiver(_item.ID, _f.EmailAddr))
            //        {
            //            ShowSelectedProjectData();
            //        }
            //    }
            //}
		}

		private void AddNew()
		{
            //Dialog_ModifyReciver _f = new Dialog_ModifyReciver();
            //if (_f.ShowDialog() == DialogResult.OK)
            //{
            //    string _selectedStr = this.comboBoxEdit1.SelectedItem.ToString();
            //    if (SinoSZSysManagerDC.SysManagerFactroy.AddFsDataLoadAlertReceiver(_selectedStr, _f.EmailAddr))
            //    {
            //        ShowSelectedProjectData();
            //    }
            //}
		}

		#endregion


		private void ShowSelectedProjectData()
		{
            //if (this.comboBoxEdit1.SelectedItem != null)
            //{
            //    string _selectedStr = this.comboBoxEdit1.SelectedItem.ToString();
            //    DataTable _dt = SinoSZSysManagerDC.SysManagerFactroy.GetFsDataLoadAlertMailReceiver(_selectedStr);
            //    List<AlertMailReceiverItem> _list = new List<AlertMailReceiverItem>();
            //    foreach (DataRow _dr in _dt.Rows)
            //    {
            //        AlertMailReceiverItem _item = new AlertMailReceiverItem(_dr["ID"].ToString(), _dr["LX"].ToString(), _dr["JSR"].ToString());
            //        _list.Add(_item);
            //    }
            //    this.listBoxControl1.DataSource = _list;
            //}
            //else
            //{
            //    this.listBoxControl1.DataSource = null;
            //}
            //RaiseMenuChanged();
		}

		private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowSelectedProjectData();

		}

		private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			RaiseMenuChanged();
		}


	}
}