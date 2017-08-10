using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.SinoBestMTS;
using SinoSZJS.DataAccess;
using SinoSZJS.Base.Misc;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizMetaDataManager.MTS
{
    public class AdapterLib
    {
        private static Dictionary<string, ISinoBestMTSAdatper> Adapters = new Dictionary<string, ISinoBestMTSAdatper>();
        public static ISinoBestMTSAdatper GetAdapter(string MethodName)
        {
            if (Adapters.ContainsKey(MethodName))
            {
                return Adapters[MethodName];
            }
            else
            {
                ISinoBestMTSAdatper _da = GetNewAdapter(MethodName);
                return _da;
            }
        }

        private const string SQL_GetAdapterDLLFile = @"SELECT CSDATA FROM ZHTJ_CSB WHERE CSNAME=:CSNAME ";
        private static ISinoBestMTSAdatper GetNewAdapter(string MethodName)
        {
            try
            {
                using (SqlConnection cn = SqlHelper.OpenConnection())
                {
                    SqlCommand _cmd = new SqlCommand(SQL_GetAdapterDLLFile, cn);
                    _cmd.Parameters.Add(":CSNAME", MethodName);
                    string _dllname = (string)_cmd.ExecuteScalar();
                    string AssmblyName = StrUtils.GetMetaByName2("Assembly", _dllname);
                    string AdapterType = StrUtils.GetMetaByName2("Type", _dllname);


                    String path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "";
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(path + "\\" + AssmblyName);
                        Type type = assembly.GetType(AdapterType);
                        ISinoBestMTSAdatper instance = (ISinoBestMTSAdatper)Activator.CreateInstance(type);
                        return instance;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("反射生成处理类时出错！Assmebly={0} Type={1}  {2}", AssmblyName, AdapterType, ex.Message));

                    }                    
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteSystemLog(string.Format("取消息报文接收处理器时出错！MethodName={0} {1}", MethodName, ex.Message), "ERROR");
                return null;
            }
        }
    }
}
