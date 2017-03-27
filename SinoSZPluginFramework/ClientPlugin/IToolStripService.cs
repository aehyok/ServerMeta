using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SinoSZPluginFramework
{
    public interface IToolStripService
    {
        void AddToolStrip(String toolStripName,ToolStrip toolStrip);
        void AddToolStrip(String toolStripName, ToolStrip toolStrip, ToolStripDockState dockState);
        void RemoveToolStrip(String toolStripName);
        ToolStrip GetToolStrip(String toolStripName);
        void ShowToolStrip(String toolStripName, Boolean visible);
    }
}
