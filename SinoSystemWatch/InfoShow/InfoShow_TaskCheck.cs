using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.TaskCheck;
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
    public class InfoShow_TaskCheck : IInfoShow
    {
        public bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult)
        {
            var jser = new JavaScriptSerializer();
            List<CheckTaskStatus> _status = jser.Deserialize<List<CheckTaskStatus>>(InfoResult.CheckResult);

            foreach (CheckTaskStatus _ws in _status)
            {
                FlowLayoutPanel p1 = new FlowLayoutPanel();
                p1.AutoScroll = false;
                p1.AutoSize = true;
                p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                p1.FlowDirection = FlowDirection.LeftToRight;

                AddStatusPicture(p1, _ws.LastRunFlag, _ws.RWZT);
                AddLable(p1, "任务名", _ws.Name, 160);
                AddLable(p1, "任务描述", _ws.Description, 200);
                AddLable(p1, "错误数(7日内)", _ws.ErrorNum.ToString(), 160);
                panel.Controls.Add(p1);
            }
            return true;
        }

        private void AddStatusPicture(FlowLayoutPanel p1, int flag, int zt)
        {
            PictureBox pb = new PictureBox();
            pb.BackgroundImageLayout = ImageLayout.Center;
            pb.Width = 16;
            pb.Size = new Size(16, 16);

            if (zt == 9)
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094738834;
            }
            else
            {
                switch (flag)
                {
                    case 0:
                        pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094736649;
                        break;
                    case 9:
                        pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094345476;
                        break;
                    default:
                        pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094530743;
                        break;
                }

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

            var jser = new JavaScriptSerializer();
            List<CheckTaskStatus> _status = jser.Deserialize<List<CheckTaskStatus>>(InfoResult.CheckResult);
            List<ExpandoObject> _ShowData = new List<ExpandoObject>();
            foreach (CheckTaskStatus _ws in _status)
            {
                dynamic o = new ExpandoObject();
                o.Flag = GetFlag(_ws);
                o.Name = _ws.Name;
                o.Description = _ws.Description;
                o.ErrorNum = _ws.ErrorNum;
                o.RWZT = GetZTString(_ws.RWZT);
                o.LastRunFlag = GetRunFlagString(_ws.LastRunFlag);
                _ShowData.Add(o);
            }


            #region 展示
            GridColumn _gc = gridView.Columns.Add();
            _gc.Caption = "任务名称";
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
            _gc.Caption = "任务状态";
            _gc.FieldName = "RWZT";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true; ;
            _gc.Width = 160;

            _gc = gridView.Columns.Add();
            _gc.Caption = "上次执行情况";
            _gc.FieldName = "LastRunFlag";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true; ;
            _gc.Width = 200;

            _gc = gridView.Columns.Add();
            _gc.Caption = "任务描述";
            _gc.FieldName = "Description";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = false; ;
            _gc.Width = 260;

            gridView.OptionsView.ColumnAutoWidth = true;
            gridView.GridControl.DataSource = _ShowData;
            #endregion

            return true;
        }

        private string GetRunFlagString(int p)
        {
            switch (p)
            {
                case 0:
                    return "成功";
                case 1:
                    return "警告";
                case 9:
                    return "失败";
                default:
                    return "未知";
            }
        }

        private string GetZTString(int p)
        {
          

            switch (p)
            {
                case 0:
                    return "空闲";
                case 1:
                    return "正在执行";
                case 9:
                    return "禁用";
                default:
                    return "未知";
            }
        }

        private string GetFlag(CheckTaskStatus _ws)
        {
            if (_ws.RWZT == 5) return "4";
            switch (_ws.LastRunFlag)
            {
                case 0:
                    return "1";

                case 9:
                    return "3";

                default:
                    return "2";
            }
        }


        public bool ShowConsole(Panel MainPanel, CheckInfoResult _r)
        {
            return true;
        }


        public bool GetMenuGroup(RibbonPage MainPage)
        {
            List<RibbonPageGroup> _ret = new List<DevExpress.XtraBars.Ribbon.RibbonPageGroup>();

            RibbonPageGroup _group = new RibbonPageGroup();
            _group.Text = "应用系统任务监控";

            BarButtonItem _bt = new BarButtonItem();
            _bt.Caption = "导出全部日志";
            _bt.Name = "TaskLog_Export_ALL";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);


            _bt = new BarButtonItem();
            _bt.Caption = "仅导出错误日志";
            _bt.Name = "TaskLog_Export_ERROR";
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
                case "TaskLog_Export_ALL":
                    DoExport("ALL", StateItem);
                    break;

                case "TaskLog_Export_ERROR":
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
            _dialog.FileName = "SystemTask.log";
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                byte[] _ret = SinoCommandExcute.DoNoCompressed(SessionCache.CurrentTokenString, "ExcuteNodeCommandWithByte.WatchTaskServerPlugin.Tasklog_Export", StateItem.SystemName, _type);
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
