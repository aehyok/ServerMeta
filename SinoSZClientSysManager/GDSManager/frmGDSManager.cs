using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZClientBase;
using SinoSZJS.Base.JSGDS;
using SinoSZPluginFramework;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientSysManager.GDSManager
{
    public partial class frmGDSManager : frmBase
    {

        private List<GDSCommanderDefine> GdsDefines = null;
        private UC_GDSDefine CurrentUC = null;
        private bool _haveChange = false;
        public frmGDSManager()
        {
            InitializeComponent();
        }

        public override void Init(string _title, string _menuName, object _param)
        {
            this.Text = _title;
            this._menuPageName = _menuName;
            this._initFinished = true;
            this.panelWait.Visible = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        #region 重载基类的方法
        protected override IList<FrmMenuGroup> GetMenuGroups(string _pagename)
        {
            IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

            FrmMenuGroup _thisGroup = new FrmMenuGroup("接口管理");
            _thisGroup.MenuItems = new List<FrmMenuItem>();
            FrmMenuItem _item = new FrmMenuItem("保存修改", "保存修改", global::SinoSZClientSysManager.Properties.Resources.xx, _haveChange);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("删除接口", "删除接口", global::SinoSZClientSysManager.Properties.Resources.x1, IsFocused);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("刷新", "刷新", global::SinoSZClientSysManager.Properties.Resources.e17, true);
            _thisGroup.MenuItems.Add(_item);

            _item = new FrmMenuItem("新建接口", "新建接口", global::SinoSZClientSysManager.Properties.Resources.u3, true);
            _thisGroup.MenuItems.Add(_item);

            _ret.Add(_thisGroup);

            return _ret;
        }

        protected override bool ExcuteCommand(string _cmdName)
        {
            switch (_cmdName)
            {
                case "保存修改":
                    SaveData();
                    break;
                case "删除接口":
                    if (IsFocused)
                    {
                        DeleteData();
                    }
                    break;
                case "新建接口":
                    CreateNewData();
                    break;
                case "刷新":
                    this.panelWait.Visible = true;
                    this.backgroundWorker1.RunWorkerAsync();
                    RaiseMenuChanged();
                    break;
            }
            return true;
        }





        #endregion

        private void frmGDSManager_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
            {
                GdsDefines = _csc.GetGDSList().ToList();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gridControl1.DataSource = GdsDefines;
            this.panelWait.Visible = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (_haveChange)
            {
                //保存
                DialogResult _res = XtraMessageBox.Show("是否保存数据修改?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                {
                    SaveData();
                }
                else
                {
                    //RefreshData();
                }
            }

            _haveChange = false;
            GDSCommanderDefine _crow = this.gridView1.GetFocusedRow() as GDSCommanderDefine;
            UC_GDSDefine _ucdefine = new UC_GDSDefine(_crow);
            _ucdefine.DataChanged += new EventHandler<EventArgs>(_ucdefine_DataChanged);
            _ucdefine.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(_ucdefine);
            CurrentUC = _ucdefine;
            RaiseMenuChanged();
        }

        void _ucdefine_DataChanged(object sender, EventArgs e)
        {
            this._haveChange = true;
            RaiseMenuChanged();
        }

        private void SaveData()
        {
            if (CurrentUC != null)
            {
                if (CurrentUC.SaveData())
                {
                    this._haveChange = false;
                    RaiseMenuChanged();
                }
            }
        }

        public bool IsFocused
        {
            get
            {
                return (this.gridView1.FocusedRowHandle >= 0);
            }
        }

        private void DeleteData()
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                GDSCommanderDefine _crow = this.gridView1.GetFocusedRow() as GDSCommanderDefine;
                DialogResult _result = MessageBox.Show(string.Format("您确定要删除[{0}]接口吗？", _crow.CommandName), "系统提示", MessageBoxButtons.YesNo);
                if (_result == System.Windows.Forms.DialogResult.Yes)
                {
                    using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                    {
                        bool _ret = _csc.DelGDSDefine(_crow.ID);
                        if (_ret)
                        {
                            MessageBox.Show("接口已经删除！", "系统提示", MessageBoxButtons.OK);
                            this.panel1.Controls.Clear();
                            this.gridView1.BeginUpdate();
                            GdsDefines.Remove(_crow);
                            this.gridView1.EndUpdate();
                        }
                        else
                        {
                            MessageBox.Show("删除接口失败！！！", "系统提示", MessageBoxButtons.OK);
                        }

                    }
                }

            }
            else
            {
                MessageBox.Show("请选择一条要删除的接口", "系统提示", MessageBoxButtons.OK);
            }
        }

        private void CreateNewData()
        {
            GDSCommanderDefine _gds = new GDSCommanderDefine();
            _gds.ID = Guid.NewGuid().ToString();
            _gds.CommandName = "NewCommand" + DateTime.Now.ToString("yyyyMMddHHmmss");
            _gds.IcsConfig = "";
            _gds.DWDM = "";
            _gds.CallParamDefine = "";
            _gds.Descript = "";
            _gds.IcsType = "";
            _gds.ReturnDefine = "";
            _gds.State = "0";
            _gds.TokenType = "";

            this.gridView1.BeginUpdate();
            GdsDefines.Add(_gds);
            this.gridView1.EndUpdate();
            this.gridView1.RefreshData();

        }

    }
}