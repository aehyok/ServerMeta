using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;

namespace SinoSZMetaDataManager
{
        class SinoSZCheckBoxList : CheckedListBoxControl
        {
                public SinoSZCheckBoxList()
                {
                        this.Enter += new EventHandler(SinoSZCheckBoxList_Enter);
                        this.Leave += new EventHandler(SinoSZCheckBoxList_Leave);
                }

                void SinoSZCheckBoxList_Leave(object sender, EventArgs e)
                {
                        this.BackColor = Color.White;
                        this.ForeColor = Color.Black;
                }

                void SinoSZCheckBoxList_Enter(object sender, EventArgs e)
                {
                        this.BackColor = Color.LightCyan;
                        this.ForeColor = Color.Blue;
                }
        }
}
