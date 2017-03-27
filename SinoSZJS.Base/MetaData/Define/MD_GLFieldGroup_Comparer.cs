using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.MetaData.Define
{
        public class MD_GLFieldGroup_Comparer : IComparer<MD_GuideLineFieldGroup>
        {


                public int Compare(MD_GuideLineFieldGroup x, MD_GuideLineFieldGroup y)
                {
                        return x.DisplayOrder - y.DisplayOrder;

                }

        }
}
