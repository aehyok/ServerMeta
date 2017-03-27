using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SinoSZPluginFramework
{
        public class ToolStripService : IToolStripService
        {
                private IApplication application = null;
                private Dictionary<String, ToolStrip> toolStrips = new Dictionary<string, ToolStrip>();

                public ToolStripService(IApplication application)
                {
                        this.application = application;
                }

                #region IToolStripService Members

                public System.Windows.Forms.ToolStrip GetToolStrip(string toolStripName)
                {
                        ToolStrip toolStrip = null;
                        if (toolStrips.ContainsKey(toolStripName))
                        {
                                toolStrip = toolStrips[toolStripName];
                        }
                        return toolStrip;
                }

                public void AddToolStrip(string toolStripName, System.Windows.Forms.ToolStrip toolStrip)
                {
                        if (toolStrips.ContainsKey(toolStripName))
                        {
                                MessageBox.Show("The tool strip name has existed!");
                        }
                        else
                        {
                                toolStrips[toolStripName] = toolStrip;
                                toolStrip.Visible = false;
                                //如果没有指定toolstrip在哪个面板,择默认加到顶部
                                //if (application.TopToolPanel != null)
                                //{
                                //    application.TopToolPanel.Controls.Add(toolStrip);
                                //}
                        }
                }

                public void AddToolStrip(string toolStripName, System.Windows.Forms.ToolStrip toolStrip, ToolStripDockState option)
                {
                        if (toolStrips.ContainsKey(toolStripName))
                        {
                                MessageBox.Show("The tool strip name has existed!");
                        }
                        else
                        {
                                toolStrips[toolStripName] = toolStrip;
                                toolStrip.Visible = false;
                                switch (option)
                                {
                                        case ToolStripDockState.Left:
                                                if (application.LeftToolPanel != null)
                                                {
                                                        application.LeftToolPanel.Controls.Add(toolStrip);
                                                }
                                                break;
                                        case ToolStripDockState.Right:
                                                if (application.RightToolPanel != null)
                                                {
                                                        application.RightToolPanel.Controls.Add(toolStrip);
                                                }
                                                break;

                                        case ToolStripDockState.Bottom:
                                                if (application.BottomToolPanel != null)
                                                {
                                                        application.BottomToolPanel.Controls.Add(toolStrip);
                                                }
                                                break;
                                }
                        }
                }

                public void RemoveToolStrip(string toolStripName)
                {
                        ToolStrip toolStrip = GetToolStrip(toolStripName);
                        if (toolStrip != null)
                        {
                                if (application.BottomToolPanel != null && application.BottomToolPanel.Controls.Contains(toolStrip))
                                {
                                        application.BottomToolPanel.Controls.Remove(toolStrip);
                                }
                                else if (application.LeftToolPanel != null && application.LeftToolPanel.Controls.Contains(toolStrip))
                                {
                                        application.LeftToolPanel.Controls.Remove(toolStrip);
                                }
                                else if (application.RightToolPanel != null && application.RightToolPanel.Controls.Contains(toolStrip))
                                {
                                        application.RightToolPanel.Controls.Remove(toolStrip);
                                }
                        }
                        toolStrips.Remove(toolStripName);
                }

                #endregion

                #region IToolStripService Members


                public void ShowToolStrip(string toolStripName, bool visible)
                {
                        if (toolStrips.ContainsKey(toolStripName))
                        {
                                ToolStrip strip = toolStrips[toolStripName];
                                strip.Visible = visible;
                        }
                }

                #endregion
        }
}
