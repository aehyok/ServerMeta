using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.JSGDS;
using SinoSZJS.Base.Misc;

namespace SinoSZClientSysManager.GDSManager
{
    public partial class UC_GDSTokenSet : UserControl
    {
        public string CommandName { get; set; }
        private bool DataLoadFinished = false;
        private List<GDSTokenRecord> TokenRecords = null;
        public UC_GDSTokenSet()
        {
            InitializeComponent();
        }

        public void Load()
        {
            if (!DataLoadFinished)
            {
                using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                {
                    TokenRecords = _csc.GetTokenRecord(CommandName).ToList();
                    this.gridControl1.DataSource = TokenRecords;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Dialog_TokenSet _dialog = new Dialog_TokenSet();
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                GDSTokenRecord _newRec = new GDSTokenRecord();
                _newRec.ID = Guid.NewGuid().ToString();
                _newRec.RemoteIP = _dialog.TokenIP;
                _newRec.TokenData = MD5Base64.Encode(_dialog.TokenString);
                _newRec.CommandName = this.CommandName;

                using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                {
                    bool _ret = _csc.InsertTokenRecord(_newRec);
                    if (_ret)
                    {
                        this.gridView1.BeginUpdate();
                        TokenRecords.Add(_newRec);
                        this.gridView1.EndUpdate();
                        this.gridView1.RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("添加失败！", "系统提示", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                GDSTokenRecord _g = gridView1.GetRow(this.gridView1.FocusedRowHandle) as GDSTokenRecord;
                Dialog_TokenSet _dialog = new Dialog_TokenSet(_g);
                if (_dialog.ShowDialog() == DialogResult.OK)
                {
                    using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                    {
                        GDSTokenRecord _newRec = new GDSTokenRecord();
                        _newRec.ID = _g.ID;
                        _newRec.RemoteIP = _g.RemoteIP;
                        _newRec.TokenData = MD5Base64.Encode(_dialog.TokenString);
                        _newRec.CommandName = _g.CommandName;

                        bool _ret = _csc.UpdateTokenRecord(_newRec);
                        if (_ret)
                        {
                            this.gridView1.BeginUpdate();
                            _g.TokenData = _newRec.TokenData;
                            this.gridView1.EndUpdate();
                            this.gridView1.RefreshData();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！", "系统提示", MessageBoxButtons.OK);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("请选择一个要重设令牌的记录！", "系统提示", MessageBoxButtons.OK);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                GDSTokenRecord _g = gridView1.GetRow(this.gridView1.FocusedRowHandle) as GDSTokenRecord;
                DialogResult _qr = MessageBox.Show(string.Format("是否确认要删除IP[{0}]的访问令牌？", _g.RemoteIP), "系统提示", MessageBoxButtons.YesNo);
                if (_qr == DialogResult.Yes)
                {
                    using (SinoSZClientBase.CommonService.CommonServiceClient _csc = new SinoSZClientBase.CommonService.CommonServiceClient())
                    {

                        bool _ret = _csc.DelICSTokenRecord(_g.ID);
                        if (_ret)
                        {
                            this.gridView1.BeginUpdate();
                            TokenRecords.Remove(_g);

                            this.gridView1.EndUpdate();
                            this.gridView1.RefreshData();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！", "系统提示", MessageBoxButtons.OK);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("请选择一个要删除令牌的记录！", "系统提示", MessageBoxButtons.OK);
            }
        }
    }
}
