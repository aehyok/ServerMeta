using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.SystemCheck;
using System.Drawing;
using System.Dynamic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using SinoSystemWatch.Base.Define;
using SinoSZJS.Base.Misc;
using System.IO;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShow_WinServiceCheck : IInfoShow
    {
        private List<WinServiceStatus> _status;
        private GridView CurrentGridView = null;
        public bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult)
        {
            var jser = new JavaScriptSerializer();
            _status = jser.Deserialize<List<WinServiceStatus>>(InfoResult.CheckResult);


            foreach (WinServiceStatus _ws in _status)
            {
                FlowLayoutPanel p1 = new FlowLayoutPanel();
                p1.AutoScroll = false;
                p1.AutoSize = true;
                p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                p1.FlowDirection = FlowDirection.LeftToRight;

                AddStatusPicture(p1, _ws.Flag);
                AddLable(p1, "服务名", _ws.ServiceName, 160);
                AddLable(p1, "状态", _ws.Status, 60);
                //AddLable(p1, "描述", _ws.Description, 300);

                panel.Controls.Add(p1);

            }
            return true;
        }

        private void AddStatusPicture(FlowLayoutPanel p1, int flag)
        {
            PictureBox pb = new PictureBox();
            pb.BackgroundImageLayout = ImageLayout.Center;
            pb.Width = 16;
            pb.Size = new Size(16, 16);
            switch (flag)
            {
                case 1:
                    pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094736649;
                    break;
                case 3:
                    pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094345476;
                    break;
                default:
                    pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094654784;
                    break;
            }

            p1.Controls.Add(pb);
        }

        private void AddLable(FlowLayoutPanel p1, string Title, string Data, int DataLength)
        {
            Label TitleLable = new Label();
            TitleLable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            TitleLable.AutoSize = false;
            TitleLable.Width = 40;
            TitleLable.Height = 20;
            TitleLable.Text = Title;
            TitleLable.Font = new System.Drawing.Font("微软雅黑", 9, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            TitleLable.ForeColor = Color.Black;
            p1.Controls.Add(TitleLable);

            Label DataLable = new Label();
            DataLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DataLable.AutoSize = true;
            DataLable.Width = DataLength;
            TitleLable.Height = 20;
            DataLable.Text = Data;
            DataLable.Font = new System.Drawing.Font("微软雅黑", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            DataLable.ForeColor = Color.Blue;
            p1.Controls.Add(DataLable);
        }



        public bool Show(GridView gridView, CheckInfoResult InfoResult)
        {

            var jser = new JavaScriptSerializer();
            _status = jser.Deserialize<List<WinServiceStatus>>(InfoResult.CheckResult);
            List<ExpandoObject> _ShowData = new List<ExpandoObject>();
            foreach (WinServiceStatus _ws in _status)
            {
                dynamic o = new ExpandoObject();
                o.Flag = GetFlag(_ws);
                o.Name = _ws.ServiceName;
                o.Description = _ws.Description;
                o.Status = _ws.Status;
                _ShowData.Add(o);
            }


            #region 展示
            GridColumn _gc = gridView.Columns.Add();
            _gc.Caption = "服务名";
            _gc.FieldName = "Name";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true;
            _gc.Width = 160;

            _gc = gridView.Columns.Add();
            _gc.Caption = "服务描述";
            _gc.FieldName = "Description";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = false; ;
            _gc.Width = 200;


            _gc = gridView.Columns.Add();
            _gc.Caption = "状态";
            _gc.FieldName = "Status";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = false;
            _gc.Width = 260;

            gridView.OptionsView.ColumnAutoWidth = true;
            gridView.GridControl.DataSource = _ShowData;
            #endregion

            CurrentGridView = gridView;
            return true;
        }

        private string GetFlag(WinServiceStatus _ws)
        {
            switch (_ws.Flag)
            {
                case 1:
                    return "1";
                case 3:
                    return "3";

                default:
                    return "0";
            }
        }


        public bool ShowConsole(Panel MainPanel, CheckInfoResult _r)
        {
            return true;
        }

        public bool GetMenuGroup(RibbonPage MainPage)
        {
            BarButtonItem _bt;
            RibbonPageGroup _group = new RibbonPageGroup();
            _group.Text = "Windows服务监控";

            _bt = new BarButtonItem();
            _bt.Caption = "导出服务状态";
            _bt.Name = "WinService_Status";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);


            _bt = new BarButtonItem();
            _bt.Caption = "添加监控服务";
            _bt.Name = "WinService_Add";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.db_add;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.db_add;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);

            _bt = new BarButtonItem();
            _bt.Caption = "删除监控服务";
            _bt.Name = "WinService_Del";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.db_remove;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.db_remove;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);

            MainPage.Groups.Add(_group);


            return true;
        }

        public void DoCommand(string CommandName, SystemStateItem StateItem)
        {
            switch (CommandName)
            {
                case "WinService_Add": //添加服务
                    Dialog_AddWinServiceCheck _f = new Dialog_AddWinServiceCheck();
                    if (_f.ShowDialog() == DialogResult.OK)
                    {
                        WinServiceStatus _wss = new WinServiceStatus();
                        _wss.ServiceName = _f.WinSvcName;
                        _wss.Description = _f.WinSvcDes;
                        string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "ExcuteNodeCommand.WatchSystemServerPlugin.WinService_Add", StateItem.SystemName, _wss);
                        if (_ret == "TRUE")
                        {
                            //CurrentGridView.DeleteRow(CurrentGridView.FocusedRowHandle);
                            MessageBox.Show(string.Format("添加服务[{0}]成功，但删除结果需要过几分钟后才能生效，请耐心等待一下。", _wss.ServiceName), "系统提示");
                        }
                    }
                    break;

                case "WinService_Del": //删除服务
                    if (CurrentGridView != null && CurrentGridView.FocusedRowHandle >= 0)
                    {
                        dynamic _ws = CurrentGridView.GetRow(CurrentGridView.FocusedRowHandle) as ExpandoObject;
                        if (_ws != null)
                        {
                            if (MessageBox.Show(string.Format("是否要移除监控Windows服务[{0}]({1})?", _ws.Name, _ws.Description), "系统提示", MessageBoxButtons.YesNo)
                                == DialogResult.Yes)
                            {
                                string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "ExcuteNodeCommand.WatchSystemServerPlugin.WinService_Del", StateItem.SystemName, _ws.Name);
                                if (_ret == "TRUE")
                                {
                                    //CurrentGridView.DeleteRow(CurrentGridView.FocusedRowHandle);
                                    MessageBox.Show(string.Format("删除服务[{0}]成功，但删除结果需要过几分钟后才能生效，请耐心等待一下。", _ws.Name), "系统提示");
                                }
                            }
                        }
                    }
                    break;

                case "WinService_Status":
                    SaveFileDialog _dialog = new SaveFileDialog();
                    _dialog.Filter = "XML格式(*.xml)|*.xml";
                    _dialog.InitialDirectory = Utils.ExeDir;
                    _dialog.FileName = "ExportWinServiceStatus.xml";
                    if (_dialog.ShowDialog() == DialogResult.OK)
                    {
                        string _s = SinoSZJS.Base.Misc.DataConvert.Serializer(typeof(List<WinServiceStatus>), this._status);
                        File.WriteAllText(_dialog.FileName, _s);
                    }
                    break;

                default:
                    MessageBox.Show(CommandName, "提示");
                    break;
            }
        }
    }
}
