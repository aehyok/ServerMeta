using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SinoSystemWatch.Base.WatchNode;
using System.Web.Script.Serialization;
using SinoSystemWatch.Base.WebApp;
using System.Drawing;
using System.Dynamic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using SinoSystemWatch.Base.Define;
using SinoSZJS.Base.Misc;
using System.IO;
using System.IO.Compression;
using SinoSystemWatch.Base.WCF;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShow_IISLogCheck : IInfoShow
    {
        public bool Show(FlowLayoutPanel panel, CheckInfoResult InfoResult)
        {
            var jser = new JavaScriptSerializer();
            List<IISLogRecordItem> _status = jser.Deserialize<List<IISLogRecordItem>>(InfoResult.CheckResult);


            foreach (IISLogRecordItem _ws in _status)
            {
                if (_ws.ReturnType == 0)
                {
                    FlowLayoutPanel p1 = new FlowLayoutPanel();
                    p1.AutoScroll = false;
                    p1.AutoSize = true;
                    p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    p1.FlowDirection = FlowDirection.LeftToRight;

                    AddStatusPicture(p1, 100);
                    AddLable(p1, "状态", "近两日内无Web访问记录", 300);

                    panel.Controls.Add(p1);
                }
                else
                {
                    FlowLayoutPanel p1 = new FlowLayoutPanel();
                    p1.AutoScroll = false;
                    p1.AutoSize = true;
                    p1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    p1.FlowDirection = FlowDirection.LeftToRight;

                    AddStatusPicture(p1, _ws.ReturnType);
                    AddLable(p1, "类型", _ws.ReturnType.ToString(), 200);
                    AddLable(p1, "记录数", _ws.RecordNum.ToString(), 200);
                    AddLable(p1, "说明", GetDescript(_ws.ReturnType), 200);
                    panel.Controls.Add(p1);
                }



            }
            return true;
        }

        private string GetDescript(int p)
        {
            switch (p)
            {
                case 100:
                    return "客户端应当继续发送请求";
                case 101:
                    return "服务器通知客户端采用不同的协议来完成请求";
                case 102:
                    return "处理将被继续执行";
                case 200:
                    return "请求已成功，请求所希望的响应头或数据体将随此响应返回";
                case 201:
                    return "请求已经被实现，一个新的资源已经依据请求的需要而建立";
                case 202:
                    return "服务器已接受请求，但尚未处理";
                case 203:
                    return "服务器已成功处理了请求，但返回的是来自本地或者第三方的拷贝";
                case 204:
                    return "服务器成功处理了请求，但不需要返回任何实体内容";
                case 205:
                    return "服务器成功处理了请求，且没有返回任何内容";
                case 206:
                    return "服务器已经成功处理了部分 GET 请求";
                case 207:
                    return "由WebDAV(RFC 2518)扩展的状态码，代表之后的消息体将是一个XML消息";
                case 300:
                    return "被请求的资源有一系列可供选择的回馈信息，浏览器能够自行选择一个首选的地址进行重定向";
                case 301:
                    return "被请求的资源已永久移动到新位置";
                case 302:
                    return "请求的资源现在临时从不同的 URI 响应请求";
                case 303:
                    return "对应当前请求的响应可以在另一个 URI 上被找到";
                case 304:
                    return "如果客户端发送了一个带条件的 GET 请求且该请求已被允许";
                case 305:
                    return "被请求的资源必须通过指定的代理才能被访问";
                case 307:
                    return "请求的资源现在临时从不同的URI 响应请求";
                case 400:
                    return "语义有误，当前请求无法被服务器理解";
                case 401:
                    return "未授权,当前请求需要用户验证";
                case 403:
                    return "Forbidden,拒绝执行";
                case 404:
                    return "Not Found,请求失败";
                case 405:
                    return "Method Not Allowed,方法未允许";
                case 406:
                    return "Not Acceptable,无法访问";
                case 407:
                    return "客户端必须在代理服务器上进行身份验证";
                case 408:
                    return "Request Timeout,请求超时";
                case 409:
                    return "被请求的资源的当前状态之间存在冲突";
                case 410:
                    return "被请求的资源在服务器上已经不再可用";
                case 411:
                    return "Length Required,需要数据长度";
                case 412:
                    return "Precondition Failed,先决条件错误";
                case 413:
                    return "Request Entity Too Large,请求实体过大";
                case 414:
                    return "Request URI Too Long,请求URI过长";
                case 415:
                    return "Unsupported Media Type,不支持的媒体格式";
                case 416:
                    return "Requested Range Not Satisfiable/请求范围无法满足";
                case 417:
                    return "Expectation Failed/期望失败";
                case 421:
                    return "连接数超过了服务器许可的最大范围";
                case 422:
                    return "语义错误，无法响应";
                case 424:
                    return "由于之前的某个请求发生的错误，导致当前请求失败";
                case 449:
                    return "请求应当在执行完适当的操作后进行重试";
                case 500:
                    return "Internal Server Error/内部服务器错误";
                case 501:
                    return "Not Implemented/未实现";
                case 502:
                    return "Bad Gateway/错误的网关";
                case 503:
                    return "Service Unavailable/服务无法获得";
                case 504:
                    return "Gateway Timeout/网关超时";
                case 505:
                    return "不支持的 HTTP 版本";
                case 506:
                    return "服务器存在内部配置错误";
                case 507:
                    return "服务器无法存储完成请求所必须的内容";
                case 509:
                    return "服务器达到带宽限制";
                case 510:
                    return "获取资源所需要的策略并没有没满足";
                default:
                    return "";
            }


        }

        private void AddStatusPicture(FlowLayoutPanel p1, int ReturnType)
        {
            PictureBox pb = new PictureBox();
            pb.BackgroundImageLayout = ImageLayout.Center;
            pb.Width = 16;
            pb.Size = new Size(16, 16);
            if (ReturnType < 300)
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094520511;
            }
            else if (ReturnType < 400)
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094530743;
            }
            else
            {
                pb.BackgroundImage = SinoSystemWatch.Properties.Resources._20061208094345476;
            }

            p1.Controls.Add(pb);
        }

        private string GetFlag(int ReturnType)
        {
            if (ReturnType < 300)
            {
                return "1";
            }
            else if (ReturnType < 400)
            {
                return "2";
            }
            else
            {
                return "3";
            }
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
            List<IISLogRecordItem> _status = jser.Deserialize<List<IISLogRecordItem>>(InfoResult.CheckResult);
            List<ExpandoObject> _ShowData = new List<ExpandoObject>();
            foreach (IISLogRecordItem _ws in _status)
            {
                dynamic o = new ExpandoObject();
                o.Flag = GetFlag(_ws.ReturnType);
                o.ReturnType = _ws.ReturnType.ToString();
                o.RecordNum = _ws.RecordNum;
                o.Descript = GetDescript(_ws.ReturnType);
                _ShowData.Add(o);
            }


            #region 展示
            GridColumn _gc = gridView.Columns.Add();
            _gc.Caption = "返回码";
            _gc.FieldName = "ReturnType";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true;
            _gc.Width = 160;

            _gc = gridView.Columns.Add();
            _gc.Caption = "记录数";
            _gc.FieldName = "RecordNum";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = true; ;
            _gc.Width = 160;

            _gc = gridView.Columns.Add();
            _gc.Caption = "说明";
            _gc.FieldName = "Descript";
            _gc.VisibleIndex = 100;
            _gc.OptionsColumn.ReadOnly = true;
            _gc.OptionsColumn.FixedWidth = false; ;
            _gc.Width = 160;

            gridView.OptionsView.ColumnAutoWidth = true;
            gridView.GridControl.DataSource = _ShowData;
            #endregion

            return true;
        }




        public bool ShowConsole(Panel MainPanel, CheckInfoResult _r)
        {
            return true;
        }


        public bool GetMenuGroup(RibbonPage MainPage)
        {
            List<RibbonPageGroup> _ret = new List<DevExpress.XtraBars.Ribbon.RibbonPageGroup>();

            RibbonPageGroup _group = new RibbonPageGroup();
            _group.Text = "IIS监控";

            BarButtonItem _bt = new BarButtonItem();
            _bt.Caption = "导出全部日志";
            _bt.Name = "IIS_Export_all";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);


            _bt = new BarButtonItem();
            _bt.Caption = "导出警告和错误日志";
            _bt.Name = "IIS_Export_Warning";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);


            _bt = new BarButtonItem();
            _bt.Caption = "仅导出错误日志";
            _bt.Name = "IIS_Export_Error";
            _bt.Glyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.LargeGlyph = global::SinoSystemWatch.Properties.Resources.pro2;
            _bt.Tag = this;
            MainPage.Ribbon.Items.Add(_bt);
            _group.ItemLinks.Add(_bt);
            _ret.Add(_group);

            _bt = new BarButtonItem();
            _bt.Caption = "修改过滤列表";
            _bt.Name = "ModifyBlockedList";
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
                case "IIS_Export_all":
                    DoExport("ALL", StateItem);
                    break;

                case "IIS_Export_Warning":
                    DoExport("WARNING", StateItem);
                    break;

                case "IIS_Export_Error":
                    DoExport("ERROR", StateItem);
                    break;
                case "ModifyBlockedList":
                    DoModify(StateItem);
                    break;

                default:
                    MessageBox.Show(CommandName, "提示");
                    break;
            }
        }

        private void DoModify(SystemStateItem StateItem)
        {
            string _ret = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "ExcuteNodeCommand.WatchApplicationServerPlugin.IIS_GetBlockedList", StateItem.SystemName, null);
            if (_ret != null)
            {
                Dialog_IIS_BlockedList _f = new Dialog_IIS_BlockedList(_ret);
                if (_f.ShowDialog() == DialogResult.OK)
                {
                    string _saveresult = SinoCommandExcute.Do(SessionCache.CurrentTokenString, "ExcuteNodeCommand.WatchApplicationServerPlugin.IIS_SaveBlockedList", StateItem.SystemName, _f.BlockedList);
                    if (_saveresult == "TRUE")
                    {
                        MessageBox.Show("保存IIS日志过滤列表成功！", "系统提示");
                    }
                }
            }
        }

        private void DoExport(string _type, SystemStateItem StateItem)
        {
            SaveFileDialog _dialog = new SaveFileDialog();
            _dialog.Filter = "日志格式(*.log)|*.log";
            _dialog.InitialDirectory = Utils.ExeDir;
            _dialog.FileName = "IIS_Logs.log";
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                byte[] _ret = SinoCommandExcute.DoNoCompressed(SessionCache.CurrentTokenString, "ExcuteNodeCommandWithByte.WatchApplicationServerPlugin.IIS_Export", StateItem.SystemName, _type);
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
