using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemInterface
{
        public class SystemICS_SJJH_DataTable
        {
                private string logonName = "";
                private string tableName = "";
                private string condition = "";
                private string secretFun = "";
                private string displayName = "";
                private List<SystemICS_SJJH_TableColumn> columns = new List<SystemICS_SJJH_TableColumn>();



                public SystemICS_SJJH_DataTable(string _logonName ,string _tableName,string _condition,string _secret,string _display)
                {
                        logonName = _logonName;
                        tableName = _tableName;
                        condition = _condition;
                        secretFun = _secret;
                        displayName = _display;
                }

                public List<SystemICS_SJJH_TableColumn> Columns
                {
                        get { return columns;}
                        set { columns = value;}
                }

                public string DisplayName {
                        get { return displayName;}
                        set { displayName= value;}
                }

                public string LogonName
                {
                        get { return logonName;}
                        set { logonName = value;}
                }

                public string TableName
                {
                        get { return tableName;}
                        set { tableName = value;}
                }

                public string Condtion
                {
                        get { return condition;}
                        set { condition = value;}
                }

                public string SecretFun
                {
                        get { return secretFun;}
                        set { secretFun = value;}
                }


        }
}
