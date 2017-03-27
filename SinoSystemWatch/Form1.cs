using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Define;
using System.Runtime.Serialization.Json;
using System.IO;
using SinoSystemWatch.Base.Define;
using System.Linq;
using SinoSystemWatch.ServerNode;
using SinoSystemWatch.Base.WCF;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.Common;
using SinoSZJS.Base.Misc;


namespace SinoSystemWatch
{
    public partial class Form1 : Form
    {
        private List<SystemStateItem> SystemItems = new List<SystemStateItem>();
        private C_SystemInfo CurrentInfo = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = SystemItems;
            RefreshData();

        }

        private void RefreshData()
        {
            this.panelWait.Visible = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private List<SystemStateItem> GetSystemList()
        {
            string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "GetSystemList", "", null);
            if (_ret == "")
            {
                //��ʾ�����д��󣬼���־

                return null;
            }
            else
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, SystemStateItem>));
                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_ret.ToCharArray()));
                Dictionary<string, SystemStateItem> obj = (Dictionary<string, SystemStateItem>)serializer.ReadObject(ms);
                ms.Close();

                WatchSystemLib.SystemLib = obj;
                List<SystemStateItem> _retList = new List<SystemStateItem>();
                foreach (SystemStateItem _item in WatchSystemLib.SystemLib.Values)
                {
                    _retList.Add(_item);
                }
                return _retList;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<SystemStateItem> _states = GetSystemList();
            e.Result = _states;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<SystemStateItem> _states = e.Result as List<SystemStateItem>;
            this.gridView1.BeginDataUpdate();
            foreach (SystemStateItem _item in _states)
            {
                var _v = from _c in SystemItems
                         where _c.SystemName == _item.SystemName
                         select _c;
                SystemStateItem _citem = _v.FirstOrDefault();
                if (_citem == null)
                {
                    SystemItems.Add(_item);
                }
                else
                {
                    _citem.NodeState = _item.NodeState;
                    _citem.Connected = _item.Connected;
                    _citem.ConnectErrorMsg = _item.ConnectErrorMsg;
                    _citem.DBState = _item.DBState;
                }
            }
            this.gridView1.EndDataUpdate();
            this.panelWait.Visible = false;
            this.timer1.Enabled = true;
            if (CurrentInfo != null) CurrentInfo.RefreshData();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            RefreshData();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                SystemStateItem _item = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as SystemStateItem;
                C_SystemInfo _c = new C_SystemInfo(_item);
                _c.Dock = DockStyle.Fill;
                CurrentInfo = _c;
                this.panelData.Visible = false;
                this.panelData.Controls.Clear();
                this.panelData.Controls.Add(_c);
                this.panelData.Visible = true;
            }
        }

        private void bt_AddSys_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ӷ�����
            Dialog_AddNode _f = new Dialog_AddNode();
            if (_f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SystemStateItem _item = _f.GetSystemStateItem();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SystemStateItem));
                MemoryStream stream = new MemoryStream();
                serializer.WriteObject(stream, _item);
                stream.Position = 0;

                StreamReader sr = new StreamReader(stream);
                string resultStr = sr.ReadToEnd();
                sr.Close();
                stream.Close();

                byte[] _callbytes = WcfDataCompressControl.Compress(resultStr);
                string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "AddWatchNode", "", _callbytes);

                if (_ret == "TRUE")
                {
                    MessageBox.Show("��ӳɹ���" + _ret, "ϵͳ��ʾ");
                }
                else
                {
                    MessageBox.Show("���ʧ�ܣ�" + _ret, "ϵͳ��ʾ");
                }
            }
        }

        private void bt_DelSys_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ɾ��������
            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("��ѡ��һ��Ҫɾ���ķ�������¼!", "ϵͳ��ʾ");
            }
            else
            {
                SystemStateItem _item = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as SystemStateItem;
                if (MessageBox.Show(string.Format("��ȷ��Ҫɾ����ط�����[{0}]��", _item.SystemName), "ϵͳ��ʾ", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string _delNodeName = _item.SystemName;
                    byte[] _callbytes = WcfDataCompressControl.Compress(_delNodeName);
                    string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "DelWatchNode", "", _callbytes);

                    if (_ret == "TRUE")
                    {
                        this.gridView1.BeginDataUpdate();
                        SystemItems.Remove(_item);
                        this.gridView1.EndDataUpdate();
                        MessageBox.Show("ɾ���ɹ���" + _ret, "ϵͳ��ʾ");

                    }
                    else
                    {
                        MessageBox.Show("ɾ��ʧ�ܣ�" + _ret, "ϵͳ��ʾ");
                    }
                }
            }
        }

        private void tb_SysDetial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("��ѡ��һ��Ҫɾ���ķ�������¼!", "ϵͳ��ʾ");
            }
            else
            {
                SystemStateItem _item = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as SystemStateItem;
                FrmServerNodeDetail _f = new FrmServerNodeDetail(_item);
                _f.ShowDialog();
            }
        }

        private void tb_ModiSys_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //�޸ķ�����
            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("��ѡ��һ����������¼!", "ϵͳ��ʾ");
            }
            else
            {
                SystemStateItem _citem = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as SystemStateItem;
                Dialog_AddNode _f = new Dialog_AddNode(_citem);
                if (_f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SystemStateItem _item = _f.GetSystemStateItem();

                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SystemStateItem));
                    MemoryStream stream = new MemoryStream();
                    serializer.WriteObject(stream, _item);
                    stream.Position = 0;

                    StreamReader sr = new StreamReader(stream);
                    string resultStr = sr.ReadToEnd();
                    sr.Close();
                    stream.Close();

                    byte[] _callbytes = WcfDataCompressControl.Compress(resultStr);
                    string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "ModifyWatchNode", "", _callbytes);

                    if (_ret == "TRUE")
                    {
                        this.gridView1.BeginDataUpdate();
                        SystemItems.Remove(_citem);
                        this.gridView1.EndDataUpdate();
                        MessageBox.Show("�޸ĳɹ���" + _ret, "ϵͳ��ʾ");
                    }
                    else
                    {
                        MessageBox.Show("�޸�ʧ�ܣ�" + _ret, "ϵͳ��ʾ");
                    }
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentInfo != null)
            {
                List<AppPluginInfo> _caps = CurrentInfo.CurrentPluginList();

                Dialog_AddPlugin _f = new Dialog_AddPlugin(_caps);
                if (_f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //�ϴ��ļ�
                    AppPluginInfo _newinfo = _f.GetInputPluginInfo();
                    UpLoadFileInfo _upfiledata = new UpLoadFileInfo();
                    _upfiledata.PluginInfo = _newinfo;
                    _upfiledata.FileName = _newinfo.FileName;
                    _upfiledata.SavePath = string.Format("Plugin\\{0}\\", _newinfo.AssemblyVersion);
                    _upfiledata.FileData = _f.GetFileBytes();
                    string _upret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "UpLoadFilePlugin", this.CurrentInfo.CurrentItem.SystemName, _upfiledata);
                    if (_upret == "TRUE")
                    {
                        MessageBox.Show("�ϴ�����ɹ�!", "ϵͳ��ʾ");
                    }
                    else
                    {
                        MessageBox.Show("�ϴ����ʧ��!" + _upret, "ϵͳ��ʾ");
                    }
                    return;
                }
            }
            MessageBox.Show("��ѡ��һ��Ҫ�ϴ��Ĳ��!", "ϵͳ��ʾ");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string _allPluginList = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "GetAppPluginList", this.CurrentInfo.CurrentItem.SystemName, null);
            if (_allPluginList.StartsWith("��������"))
            {
                MessageBox.Show(_allPluginList, "ϵͳ��ʾ");
            }
            else
            {
                List<AppPluginInfo> _pluginDict = SerializeHelper.JsonDeserialize<List<AppPluginInfo>>(_allPluginList);

                Dialog_SelectPlugin _f = new Dialog_SelectPlugin(_pluginDict);
                if (_f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AppPluginInfo _newinfo = _f.SelectedPlugin;
                    //���ز��
                    string _retload = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "LoadAppPlugin", this.CurrentInfo.CurrentItem.SystemName, _newinfo);
                    if (_retload == "TRUE")
                    {
                        MessageBox.Show("������³ɹ�!", "ϵͳ��ʾ");
                    }
                    else
                    {
                        MessageBox.Show("�������ʧ��!", "ϵͳ��ʾ");
                    }
                }
            }

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentInfo != null)
            {
                AppPluginInfo _cap = CurrentInfo.CurrentPlugin();
                if (_cap != null)
                {
                    if (MessageBox.Show(string.Format("�����Ҫж�ز��[{0}]��", _cap.FileName), "ϵͳ��ʾ", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //ж�ز����ת�Ƶ����Ŀ¼
                        string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "RemoveAppPlugin", this.CurrentInfo.CurrentItem.SystemName, _cap);
                        if (_ret == "TRUE")
                        {
                            MessageBox.Show("���ж�سɹ�!", "ϵͳ��ʾ");
                        }
                        else
                        {
                            MessageBox.Show("���ж��ʧ��!" + _ret, "ϵͳ��ʾ");
                        }
                    }
                    return;
                }
            }
            MessageBox.Show("��ѡ��һ��Ҫ���µĲ��!", "ϵͳ��ʾ");
        }


    }

}