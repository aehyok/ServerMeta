using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Report.ReportGuideLine
{
        public class MD_RGL_FieldDefine
        {
                private string fieldName = "";
                private string displayName = "";
                private int displayOrder = 0;
                private int displayWidth = 100;

                public MD_RGL_FieldDefine(string _fieldName, string _displayName, int _order, int _width)
                {
                        fieldName = _fieldName;
                        displayName = _displayName;
                        displayOrder = _order;
                        displayWidth = _width;
                }

                public string FieldName
                {
                        get { return fieldName; }
                        set { fieldName = value; }
                }

                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }

                public int DisplayOrder
                {
                        get { return displayOrder; }
                        set { displayOrder = value; }
                }

                public int DisplayWidth
                {
                        get { return displayWidth; }
                        set { displayWidth = value; }
                }






        }
}
