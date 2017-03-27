using System;
using System.Collections.Generic;
using System.Text;

using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.FixQuery
{
        public class FixChildItem
        {
                private string displayName = "";
                private MDModel_Table tableDefine = null;

                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }

                public MDModel_Table TableDefine
                {
                        get { return tableDefine; }
                        set { tableDefine = value; }
                }

                public FixChildItem(string _displayName, MDModel_Table _table)
                {
                        displayName = _displayName;
                        tableDefine = _table;
                }

                public override string ToString()
                {
                        return displayName;
                }


        }
}
