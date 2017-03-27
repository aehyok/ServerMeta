using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Report.ReportGuideLine
{
        public class Comparer_RGL_FieldDefine : IComparer<MD_RGL_FieldDefine>
        {
                #region IComparer<MD_RGL_FieldDefine> Members

                public int Compare(MD_RGL_FieldDefine x, MD_RGL_FieldDefine y)
                {
                        return x.DisplayOrder - y.DisplayOrder;
                }

                #endregion
        }
}
