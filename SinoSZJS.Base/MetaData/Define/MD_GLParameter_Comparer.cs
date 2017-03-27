using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.MetaData.Define
{
        public class MD_GLParameter_Comparer : IComparer<MD_GuideLineParameter>
        {
                #region IComparer<MD_GuideLineParameter> Members

                public int Compare(MD_GuideLineParameter x, MD_GuideLineParameter y)
                {
                        return x.DisplayOrder - y.DisplayOrder;
                }

                #endregion
        }
}
