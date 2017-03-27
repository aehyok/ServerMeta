using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.MetaData.QueryModel
{
        public class MDModel_ColumnComparer : IComparer<MDModel_Table_Column>
        {
                #region IComparer<MDModel_Table_Column> Members

            public int Compare(MDModel_Table_Column x, MDModel_Table_Column y)
                {
                        return x.ColumnDefine.DisplayOrder - y.ColumnDefine.DisplayOrder;
                }

                #endregion
        }
}
