using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZPluginFramework;

namespace SinoSZClientBase.PortalItem
{
        public partial class SinoSZUC_PortalItemBase : UserControl
        {

                public SinoSZUC_PortalItemBase()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// 标题
                /// </summary>
                protected string Title
                {
                        get
                        {
                                return this.groupControl1.Text;
                        }
                        set
                        {
                                this.groupControl1.Text = value;
                        }
                }

                #region 虚方法
                /// <summary>
                /// 点击详细
                /// </summary>
                virtual public void ClickMore()
                {

                }
                /// <summary>
                /// 取菜单
                /// </summary>
                virtual public FrmMenuGroup GetMenuGroup()
                {
                        return null;
                }
                /// <summary>
                /// 执行菜单命令
                /// </summary>
                /// <param name="_commandName"></param>
                /// <returns></returns>
                virtual public bool ExcuteCommand(string _commandName)
                {
                        return false;
                }
                #endregion

                private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        ClickMore();
                }



        }
}
