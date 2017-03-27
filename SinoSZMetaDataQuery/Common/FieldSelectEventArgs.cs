using System;
using System.Collections.Generic;
using System.Text;


using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.Common
{
        public class FieldSelectEventArgs : EventArgs
        {
                private MDModel_Table_Column _fieldItem = null;

                public MDModel_Table_Column FieldItem
                {
                        get { return _fieldItem; }
                        set { _fieldItem = value; }
                }

                public FieldSelectEventArgs(MDModel_Table_Column _item)
                {
                        this._fieldItem = _item;
                }
        }
}
