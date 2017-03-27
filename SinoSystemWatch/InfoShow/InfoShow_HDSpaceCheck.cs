using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.SystemCheck;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using System.Dynamic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using SinoSystemWatch.Base.Define;
using SinoSZJS.Base.Misc;
using System.IO;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShow_HDSpaceCheck : IInfoShow
    {
        private List<HardDiskPartition> _status;
        public bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult)
        {
            var jser = new JavaScriptSerializer();
            List<HardDiskPartition> _status = jser.Deserialize<List<HardDiskPartition>>(InfoResult.CheckResult);


            foreach (HardDiskPartition _ws in _status)
            {
                FlowLayoutPanel p1 = new FlowLayoutPanel();
                p1.AutoScroll = false;
                p1.AutoSize = true;
                p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                p1.FlowDirection = FlowDirection.LeftToRight;

                int _flag = AddStatusPicture(p1, _ws.FreeSpace);
                AddLable(p1, "磁盘", _ws.PartitionName, 80);
                AddLable(p1, "主分区", GetSF(_ws.IsPrimary), 60);
                AddColorLable(p1, "空间", string.Format("{0}G", _ws.FreeSpace), string.Format("{0}G", _ws.SumSpace), 50, _flag);

                panel.Controls.Add(p1);

            }
            return true;
        }



        private string GetSF(bool p)
        {
            if (p)
            {
                return "是";
            }
            else
            {
                return "否";
            }
        }

        private int AddStatusPicture(FlowLayoutPanel p1, double flag)
        {
            int _ret = 0;
            PictureBox pb = new PictureBox();
            pb.BackgroundImageLayout = ImageLayout.Center;
            pb.Width = 16;
            pb.Size = new Size(16, 16);
            if (flag > 1)
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094736649;
                _ret = 0;
            }
            else if (flag > 0.5)
            {

                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094530743;
                _ret = 1;
            }
            else
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094345476;
                _ret = 2;
            }

            p1.Controls.Add(pb);
            return _ret;
        }

        private void AddColorLable(FlowLayoutPanel p1, string Title, string FreeData, string SumData, int DataLength, int _flag)
        {
            Label TitleLable = new Label();
            TitleLable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            TitleLable.AutoSize = false;
            //TitleLable.BackColor = Color.LightCyan;
            TitleLable.Width = 50;
            TitleLable.Height = 20;
            TitleLable.Text = Title;
            TitleLable.Font = new System.Drawing.Font("微软雅黑", 9, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            TitleLable.ForeColor = Color.Black;
            p1.Controls.Add(TitleLable);

            Label DataLable = new Label();
            DataLable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            DataLable.Margin = new Padding(0);
            DataLable.Padding = new Padding(0);
            //DataLable.BackColor = Color.LightPink;
            DataLable.AutoSize = false;
            DataLable.Width = DataLength;
            TitleLable.Height = 20;
            DataLable.Text = FreeData;
            switch (_flag)
            {
                case 1:
                    DataLable.ForeColor = Color.DarkOrange;
                    DataLable.Font = new System.Drawing.Font("微软雅黑", 9, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 2:
                    DataLable.ForeColor = Color.Red;
                    DataLable.Font = new System.Drawing.Font("微软雅黑", 9, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                    break;
                default:
                    DataLable.ForeColor = Color.Blue;
                    DataLable.Font = new System.Drawing.Font("微软雅黑", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                    break;
            }
            p1.Controls.Add(DataLable);

            Label DataLable2 = new Label();
            DataLable2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DataLable2.Margin = new Padding(0);
            DataLable2.Padding = new Padding(0);
            //DataLable2.BackColor = Color.LightCyan;
            DataLable2.AutoSize = false;
            DataLable2.Width = DataLength + 10;
            DataLable2.Height = 20;
            DataLable2.Text = "/" + SumData;

            p1.Controls.Add(DataLable2);

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
            _status = jser.Deserialize<List<HardDiskPartition>>(InfoResult.CheckResult);
            List<ExpandoObject> _ShowData = new List<ExpandoObject>();
            foreach (HardDiskPartition _ws in _status)
            {
                dynamic o = new ExpandoObject();
                o.Flag = GetFlag(_ws.FreeSpace);
                o.PartitionName = _ws.PartitionName;
                o.IsPrimary = _ws.IsPrimary;
                o.FreeSpace = _ws.FreeSpace;
                o.SumSpace = _ws.SumSpace;

                _ShowData.Add(o);
            }


            #region 展示
            GridColumn _gc = gridView.Columns.Add();
            _gc.Caption = "盘符";
            _gc.FieldName = "PartitionName";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true;
            _gc.Width = 120;

            _gc = gridView.Columns.Add();
            _gc.Caption = "主分区";
            _gc.FieldName = "IsPrimary";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true;
            _gc.Width = 120;




            _gc = gridView.Columns.Add();
            _gc.Caption = "剩余空间(G)";
            _gc.FieldName = "FreeSpace";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = false;
            _gc.Width = 200;

            StyleFormatCondition styleFormatCondition1 = new StyleFormatCondition();
            styleFormatCondition1.Column = _gc;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.GreaterOrEqual;
            styleFormatCondition1.Value1 = 1;
            styleFormatCondition1.Appearance.ForeColor = Color.Blue;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;

            StyleFormatCondition styleFormatCondition2 = new StyleFormatCondition();
            styleFormatCondition2.Column = _gc;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Between;
            styleFormatCondition2.Value1 = 0.5;
            styleFormatCondition2.Value2 = 1;
            styleFormatCondition2.Appearance.ForeColor = Color.DarkOrange;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;

            StyleFormatCondition styleFormatCondition3 = new StyleFormatCondition();
            styleFormatCondition3.Column = _gc;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition3.Value1 = 0.5;
            styleFormatCondition3.Appearance.ForeColor = Color.Red;

            styleFormatCondition3.Appearance.Options.UseForeColor = true;

            gridView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,styleFormatCondition2,styleFormatCondition3});

            _gc = gridView.Columns.Add();
            _gc.Caption = "总空间(G)";
            _gc.FieldName = "SumSpace";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = false; ;
            _gc.Width = 200;

            gridView.GridControl.DataSource = _ShowData;
            #endregion

            return true;
        }

        private string GetFlag(double flag)
        {
            if (flag > 1)
            {
                return "1";
            }
            else if (flag > 0.5)
            {

                return "2";
            }
            else
            {
                return "3";
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
            _group.Text = "硬盘空间监控";

            BarButtonItem _bt = new BarButtonItem();
            _bt.Caption = "导出空间状态";
            _bt.Name = "HDSpace_Status";
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
                case "HDSpace_Status":
                    SaveFileDialog _dialog = new SaveFileDialog();
                    _dialog.Filter = "XML格式(*.xml)|*.xml";
                    _dialog.InitialDirectory = Utils.ExeDir;
                    _dialog.FileName = "ExportHDSpaceStatus.xml";
                    if (_dialog.ShowDialog() == DialogResult.OK)
                    {
                        string _s = DataConvert.Serializer(typeof(List<HardDiskPartition>), this._status);
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
