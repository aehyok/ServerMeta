using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using ChinaCustoms.Frameworks.Cupaa.Libraries.Core.EnumsDefines;
using System.Data;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;
using SinoSZJS.Base.Misc;
using SinoSZJS.CS.BizAuthorize.OraSignOn;
using SinoSZJS.DataAccess;
using SinoSZJS.Base.Authorize.CUPPA;
using System.Globalization;
using SinoSZJS.DataAccess.Sql;
using System.Data.SqlClient;

namespace SinoSZJS.CS.BizAuthorize.Cuppa
{
    public class C_GetUserInfo_Cuppa
    {
        private const string SQL_GetYHIDByGUID = "select ZHTJ_ZZJG2.GetYHID_From_GUID(:GUID) from dual";
        static C_GetUserInfo_Cuppa()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //

        }

        public static string GetYHIDByName(string _name, string CheckType)
        {
            XmlElement result;
            string User_Guid = "";
            string objValues = "";
            if (CUPPAPassportConfig.DebugMode)
            {
                //User_Guid = GetUserGuidByJS(_name);
                #region ����XML�ı�ȡGUID
                string FilePath = CUPPAPassportConfig.CUPPA_Check_DebugDataPath;
                string filename = FilePath + string.Format("\\GetYHIDByName_{0}.XML", _name); ;

                System.IO.StreamReader sr = new System.IO.StreamReader(filename, System.Text.Encoding.UTF8);
                string _xmldata = sr.ReadToEnd();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(_xmldata);
                result = doc.DocumentElement;
                #endregion
            }
            else
            {
                try
                {
                    #region ͨ����ͳһ�ӿ�ȡ�û���GUID��Ϣ

                    OguReaderClient _orc = new OguReaderClient();
                    objValues = string.Format(CultureInfo.InvariantCulture, "{0}&{1}", _name, CheckType);

                    result = _orc.GetObjectsDetail(CUPPAPassportConfig.CheckViewName, ViewCategory.ViewCode, objValues, ObjectCategory.UserIdentity, "", OrganizationCategory.None, "");

                    if (CUPPAPassportConfig.CUPPA_Check_WriteLog)
                    {
                        string _error = string.Format("ͨ����ͳһ�ӿ�ȡ�û���GUID��Ϣ�ɹ��� CheckViewName={1}  objectValues={2}  ����:{0}", result.OuterXml, CUPPAPassportConfig.CheckViewName, objValues);
                        CUPPAPassportConfig.WriteCUPPALog(_error);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    string _error = string.Format("ͨ����ͳһ�ӿ�ȡ�û���GUID��Ϣʧ�ܣ�{0}  CheckViewName={2}  objectValues={3}  {1}", ex.Message, ex.StackTrace, CUPPAPassportConfig.CheckViewName, objValues);
                    if (CUPPAPassportConfig.CUPPA_Check_WriteLog) CUPPAPassportConfig.WriteCUPPALog(_error);
                    throw ex;
                }
            }

            try
            {
                if (result.ChildNodes.Count > 0)
                {
                    XmlNode node_diffgram = result.ChildNodes[1];
                    XmlNode node_DocumentElement = node_diffgram.ChildNodes[0];
                    XmlNode node_OBJECTSDETAIL = node_DocumentElement.ChildNodes[0];
                    foreach (XmlNode _node in node_OBJECTSDETAIL.ChildNodes)
                    {
                        if (_node.Name == "USER_GUID")
                        {
                            User_Guid = _node.InnerText;
                            if (CUPPAPassportConfig.CUPPA_Check_WriteLog)
                            {
                                string _error = string.Format("�û���GUID={0}", User_Guid);
                                CUPPAPassportConfig.WriteCUPPALog(_error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string _error = string.Format("����XML����ȡ�û�GUIDʧ�ܣ�{0} {1}", ex.Message, (result == null) ? "" : result.OuterXml);
                LogWriter.WriteSystemLog(_error, "ERROR");
                if (CUPPAPassportConfig.CUPPA_Check_WriteLog) CUPPAPassportConfig.WriteCUPPALog(_error);
                throw ex;
            }


            #region ͨ��USER_GUIDȡYHID
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(CUPPAPassportConfig.SQL_GetYHIDByGUID, cn);
                    _cmd.CommandType = CommandType.Text;
                    _cmd.Parameters.Add("GUID", User_Guid);
                    decimal _ret = (decimal)_cmd.ExecuteScalar();
                    if (CUPPAPassportConfig.CUPPA_Check_WriteLog) CUPPAPassportConfig.WriteCUPPALog(string.Format("ȡ�õ�YHID={0}", _ret));
                    return _ret.ToString();
                }
                catch (Exception ex)
                {
                    string _error = string.Format("ͨ��USER_GUID��{1}��ȡYHIDʧ�ܣ�{0}", ex.Message, User_Guid);
                    LogWriter.WriteSystemLog(_error, "ERROR");
                    if (CUPPAPassportConfig.CUPPA_Check_WriteLog) CUPPAPassportConfig.WriteCUPPALog(_error);
                    throw ex;
                }
            }
            #endregion
        }



        private const string SQL_GetUserGuidByJS = @"select t.yhguid from qx2_hgyh t where t.yhm=:YHM";
        private static string GetUserGuidByJS(string _name)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_GetUserGuidByJS, cn);
                    _cmd.Parameters.Add(":YHM", _name);
                    string ret = _cmd.ExecuteScalar().ToString();
                    return ret;
                }
                catch (Exception ex)
                {
                    LogWriter.WriteSystemLog(string.Format("ͨ����¼���ƴ����ݿ���ȡ�û�GUIDʧ�ܣ�{0} {1}", ex.Message, _name), "ERROR");
                    throw ex;
                }
            }
        }

    }
}
