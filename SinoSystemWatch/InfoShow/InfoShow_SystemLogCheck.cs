using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.Application;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using System.Dynamic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using SinoSystemWatch.Base.Define;
using SinoSZJS.Base.Misc;
using System.IO;
using SinoSystemWatch.Base.WCF;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShow_SystemLogCheck : IInfoShow
    {
        private string CheckProjectName = "";
        public bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult)
        {
            var jser = new JavaScriptSerializer();
            List<SystemLogStatus> _status = jser.Deserialize<List<SystemLogStatus>>(InfoResult.CheckResult);


            foreach (SystemLogStatus _ws in _status)
            {

                FlowLayoutPanel p1 = new FlowLayoutPanel();
                p1.AutoScroll = false;
                p1.AutoSize = true;
                p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                p1.FlowDirection = FlowDirection.LeftToRight;

                AddStatusPicture(p1, _ws.ErrorNum);
                AddLable(p1, "名称", _ws.Name, 120);
                AddLable(p1, "描述", _ws.Description, 200);
                AddLable(p1, "错误数(7日内)", _ws.ErrorNum.ToString(), 120);
                AddLable(p1, "信息数(7日内)", _ws.InfoNum.ToString(), 120);

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
            if (flag > 0)
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094345476;
            }
            else
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094736649;
            }

            p1.Controls.Add(pb);
        }

        private void AddLable(FlowLayoutPanel p1, string Title, string Data, int DataLength)
        {
            Label TitleLable = new Label();
            TitleLable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            TitleLable.AutoSize = true;
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
            CheckProjectName = InfoResult.CheckProjectName;
            var jser = new JavaScriptSerializer();
            List<SystemLogStatus> _status = jser.Deserialize<List<SystemLogStatus>>(InfoResult.CheckResult);
            List<ExpandoObject> _ShowData = new List<ExpandoObject>();
            foreach (SystemLogStatus _ws in _status)
            {
                dynamic o = new ExpandoObject();
                o.Flag = GetFlag(_ws);
                o.Name = _ws.Name;
                o.ErrorNum = _ws.ErrorNum;
                o.InfoNum = _ws.InfoNum;
                _ShowData.Add(o);
            }


            #region 展示
            GridColumn _gc = gridView.Columns.Add();
            _gc.Caption = "日志分类名称";
            _gc.FieldName = "Name";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true;
            _gc.Width = 160;

            _gc = gridView.Columns.Add();
            _gc.Caption = "错误数(7日内)";
            _gc.FieldName = "ErrorNum";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true; ;
            _gc.Width = 160;

            _gc = gridView.Columns.Add();
            _gc.Caption = "信息数(7日内)";
            _gc.FieldName = "InfoNum";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true; ;
            _gc.Width = 160;

            gridView.GridControl.DataSource = _ShowData;
            #endregion

            return true;
        }

        private dynamic GetFlag(SystemLogStatus _ws)
        {
            if (_ws.ErrorNum > 0)
            {
                return "3";
            }

            return "1";
        }

        bool IInfoShow.ShowConsole(Panel MainPanel, CheckInfoResult _r)
        {
            return true;
        }


        public bool GetMenuGroup(RibbonPage MainPage)
        {
            List<RibbonPageGroup> _ret = new List<DevExpress.XtraBars.Ribbon.RibbonPageGroup>();

            RibbonPageGroup _group = new RibbonPageGroup();
            _group.Text = "硬盘空间监控";

            BarButtonItem _bt = new BarButtonItem();
            _bt.Caption = "导出全部日志";
            _bt.Name = "SystemLog_Export_ALL";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);


            _bt = new BarButtonItem();
            _bt.Caption = "仅导出错误日志";
            _bt.Name = "SystemLog_Export_ERROR";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);

            _ret.Add(_group);

            MainPage.Groups.Add(_group);
            return true;
        }

        public void DoCommand(string CommandName, SystemStateItem StateItem)
        {
            switch (CommandName)
            {
                case "SystemLog_Export_ALL":
                    DoExport("ALL", StateItem);
                    break;

                case "SystemLog_Export_ERROR":
                    DoExport("ERROR", StateItem);
                    break;

                default:
                    MessageBox.Show(CommandName, "提示");
                    break;
            }
        }

        private void DoExport(string _type, SystemStateItem StateItem)
        {
            SaveFileDialog _dialog = new SaveFileDialog();
            _dialog.Filter = "日志格式(*.log)|*.log";
            _dialog.InitialDirectory = Utils.ExeDir;
            _dialog.FileName = this.CheckProjectName+ ".log";
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                byte[] _ret = SinoCommandExcute.DoNoCompressed(SessionCache.CurrentTokenString, "ExcuteNodeCommandWithByte.WatchApplicationServerPlugin.Systemlog_Export", StateItem.SystemName, string.Format("{0}.{1}", this.CheckProjectName, _type));
                if (_ret != null)
                {
                    //解压缩
                    if (File.Exists(_dialog.FileName)) File.Delete(_dialog.FileName);
                    byte[] _filebytes = WcfDataCompressControl.UnCompressByts(_ret);
                    File.WriteAllBytes(_dialog.FileName, _filebytes);
                }
                else
                {
                    MessageBox.Show("导出失败！", "系统提示");
                }


            }
        }
    }
}
