using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.OrganizeExt
{
        public class OrgExtFieldDefine
        {
                private string fieldName = "";
                private string displayTitle = "";
                private string fieldType = "";

                public OrgExtFieldDefine() { }
                public OrgExtFieldDefine(string _fieldName, string _title, string _type)
                {
                        fieldType = _type;
                        fieldName = _fieldName;
                        displayTitle = _title;
                }

                public string FieldName
                {
                        get { return fieldName; }
                        set { fieldName = value; }
                }

                public string DisplayTitle
                {
                        get { return displayTitle; }
                        set { displayTitle = value; }
                }

                public string FieldType
                {
                        get { return fieldType; }
                        set { fieldType = value; }
                }


        }
}
