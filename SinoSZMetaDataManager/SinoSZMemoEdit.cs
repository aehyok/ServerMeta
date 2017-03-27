using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;

namespace SinoSZMetaDataManager
{
        class SinoSZMemoEdit :MemoEdit
        {
                public SinoSZMemoEdit()
                {
                        this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                        this.Properties.AppearanceFocused.BackColor = Color.LightCyan;
                        this.Properties.AppearanceFocused.ForeColor = Color.Blue;
                        this.Properties.Appearance.ForeColor = Color.Blue;
                        this.Properties.AppearanceReadOnly.BackColor = Color.White;
                        this.Properties.AppearanceReadOnly.ForeColor = Color.Black;
                }
        }
}
