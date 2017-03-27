using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.DataBaseCheck;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Dynamic;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using SinoSystemWatch.Base.Define;
using DevExpress.XtraPrinting;
using SinoSZJS.Base.Misc;
using System.IO;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShow_DatabaseCheck : IInfoShow
    {
        List<DBConnectStatus> CurrentData = null;
        private GridView CurrentGridView = null;
        public bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult)
        {
            var jser = new JavaScriptSerializer();
            List<DBConnectStatus> _status = jser.Deserialize<List<DBConnectStatus>>(InfoResult.CheckResult);


            foreach (DBConnectStatus _ws in _status)
            {

                FlowLayoutPanel p1 = new FlowLayoutPanel();
                p1.AutoScroll = false;
                p1.AutoSize = true;
                p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                p1.FlowDirection = FlowDirection.LeftToRight;

                AddStatusPicture(p1, _ws.ConnectResult);
                AddLable(p1, "连接名", _ws.ConnectionName, 200);
                if (_ws.ConnectResult == 1)
                {
                    AddLable(p1, "状态", "连接成功！", 60);
                }
                else
                { AddLable(p1, "状态", _ws.ResultMessage, 60); }

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
            TitleLable.Width = 50;
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
            List<DBConnectStatus> _status = jser.Deserialize<List<DBConnectStatus>>(InfoResult.CheckResult);
            List<ExpandoObject> _ShowData = new List<ExpandoObject>();
            foreach (DBConnectStatus _ws in _status)
            {
                dynamic o = new ExpandoObject();
                o.Flag = _ws.ConnectResult.ToString();
                o.ConnectionName = _ws.ConnectionName;
                o.ResultMessage = _ws.ResultMessage;
                _ShowData.Add(o);
            }


            #region 展示
            GridColumn _gc = gridView.Columns.Add();
            _gc.Caption = "连接名称";
            _gc.FieldName = "ConnectionName";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true;
            _gc.Width = 160;

            _gc = gridView.Columns.Add();
            _gc.Caption = "详细信息";
            _gc.FieldName = "ResultMessage";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = false; ;
            _gc.Width = 160;

            gridView.OptionsView.ColumnAutoWidth = true;
            gridView.GridControl.DataSource = _ShowData;
            this.CurrentGridView = gridView;
            this.CurrentData = _status;
            #endregion

            return true;
        }


        public bool ShowConsole(Panel MainPanel, CheckInfoResult _r)
        {
            return true;
        }


        public bool GetMenuGroup(RibbonPage MainPage)
        {
            RibbonPageGroup _group = new RibbonPageGroup();
            _group.Text = "数据库监控";

            BarButtonItem _bt = new BarButtonItem();
            _bt.Caption = "导出数据连接状态";
            _bt.Name = "DATABASE_Status";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);

            _bt = new BarButtonItem();
            _bt.Caption = "添加数据库连接";
            _bt.Name = "DBConn_Add";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.db_add;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.db_add;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);

            _bt = new BarButtonItem();
            _bt.Caption = "删除数据库连接";
            _bt.Name = "DBConn_Del";
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
                case "DBConn_Add": //添加数据库连接
                    Dialog_AddDBConnection _f = new Dialog_AddDBConnection();
                    if (_f.ShowDialog() == DialogResult.OK)
                    {
                        //DBConnectSet _st = new DBConnectSet();
                        //_st.ConnectionName = _f.ConnectionName;
                        //_st.ConnectionString = _f.ConnectionString;
                        //_st.ConnectionType = _f.ConnectionType;

                        dynamic _st = new ExpandoObject();
                        _st.ConnectionName = _f.ConnectionName;
                        _st.ConnectionString = _f.ConnectionString;
                        _st.ConnectionType = _f.ConnectionType;
                        string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "ExcuteNodeCommand.WatchDataBaseServerPlugin.DBConn_Add", StateItem.SystemName, _st);
                        if (_ret == "TRUE")
                        {
                            MessageBox.Show(string.Format("添加数据库连[{0}]的监控成功，但添加结果需要过几分钟后才能生效，请耐心等待一下。", _st.ConnectionName), "系统提示");

                        }
                    }
                    break;
                case "DBConn_Del": //删除服务
                    if (CurrentGridView != null && CurrentGridView.FocusedRowHandle >= 0)
                    {
                        dynamic _ws = CurrentGridView.GetRow(CurrentGridView.FocusedRowHandle) as ExpandoObject;
                        if (_ws != null)
                        {
                            if (MessageBox.Show(string.Format("是否要移除监控数据库连接[{0}]?", _ws.ConnectionName), "系统提示", MessageBoxButtons.YesNo)
                                == DialogResult.Yes)
                            {
                                string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "ExcuteNodeCommand.WatchDataBaseServerPlugin.DBConn_Del", StateItem.SystemName, _ws.ConnectionName);
                                if (_ret == "TRUE")
                                {
                                    //CurrentGridView.DeleteRow(CurrentGridView.FocusedRowHandle);
                                    MessageBox.Show(string.Format("删除监控数据库连接[{0}]成功，但删除结果需要过几分钟后才能生效，请耐心等待一下。", _ws.ConnectionName), "系统提示");
                                }
                            }
                        }
                    }
                    break;
                case "DATABASE_Status":
                    SaveFileDialog _dialog = new SaveFileDialog();
                    _dialog.Filter = "XML格式(*.xml)|*.xml";
                    _dialog.InitialDirectory = Utils.ExeDir;
                    _dialog.FileName = "ExportDataBaseStatus.xml";
                    if (_dialog.ShowDialog() == DialogResult.OK)
                    {
                        string _s = DataConvert.Serializer(typeof(List<DBConnectStatus>), this.CurrentData);
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
