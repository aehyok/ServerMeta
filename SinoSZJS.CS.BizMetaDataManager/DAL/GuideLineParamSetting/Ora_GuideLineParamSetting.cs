using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.CS.BizMetaDataManager.DAL.GuideLineParamSetting
{
        public class Ora_GuideLineParamSetting
        {
              
                public static MD_GuideLine_ParamSetting GetCurrentPostRecord(string _guideLineID, OracleConnection cn)
                {
                        MD_GuideLine_ParamSetting _ret = null;
                        string _sql = "select CSID,ZBID,DWID,CS from tj_zdyzbdyb_cs where zbid =:ZBID and dwid=:DWID ";
                        OracleCommand _cmd = new OracleCommand(_sql, cn);
                        _cmd.Parameters.Add(":ZBID", decimal.Parse(_guideLineID));
                        _cmd.Parameters.Add(":DWID", decimal.Parse(SinoUserCtx.CurUser.CurrentPost.PostDwID));
                        using (OracleDataReader _dr = _cmd.ExecuteReader())
                        {
                            while (_dr.Read())
                            {
                                string _csid = _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString();
                                string _zbid = _dr.IsDBNull(1) ? "" : _dr.GetDecimal(1).ToString();
                                string _dwid = _dr.IsDBNull(2) ? "" : _dr.GetDecimal(2).ToString();
                                string _cs = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                                _ret = new MD_GuideLine_ParamSetting(_csid, _zbid, _dwid, _cs);

                            }
                        }
                        return _ret;
                }

                public static MD_GuideLine_ParamSetting GetDefaultRecord(string _guideLineID, OracleConnection cn)
                {
                        MD_GuideLine_ParamSetting _ret = null;
                        string _sql = "select SEQUENCES_META.nextval from dual ";
                        OracleCommand _cmd = new OracleCommand(_sql, cn);
                        decimal _csid = (decimal)_cmd.ExecuteScalar();
                        string _zbid = _guideLineID;
                        string _dwid = SinoUserCtx.CurUser.CurrentPost.PostDwID;
                        _ret = new MD_GuideLine_ParamSetting(_csid.ToString(), _zbid, _dwid, "");

                        return _ret;
                }

                public const string ChangeSetting = @"update tj_zdyzbdyb_cs set cs=:CS,querysql =:QUERYSQL 
                                        where zbid=:ZBID and dwid=:DWID ";
                public static void SaveCurrentPostRecord(MD_GuideLine_ParamSetting SavedSetting, string _queryStr, OracleConnection cn)
                {
                        OracleCommand _cmd = new OracleCommand(ChangeSetting, cn);
                        _cmd.Parameters.Add(":CS", SavedSetting.ParamMeta);
                        _cmd.Parameters.Add(":QUERYSQL", _queryStr);
                        _cmd.Parameters.Add(":ZBID", decimal.Parse(SavedSetting.GuideLineID));
                        _cmd.Parameters.Add(":DWID", SinoUserCtx.CurUser.CurrentPost.PostDwID);
                        _cmd.ExecuteNonQuery();

                }
                public const string InsertSetting = @"insert into tj_zdyzbdyb_cs (csid,zbid,dwid,cs,querysql)
                                        values  (:CSID,:ZBID,:DWID,:CS,:QUERYSQL) ";
                internal static void InsertCurrentPostRecord(MD_GuideLine_ParamSetting SavedSetting, string _queryStr, OracleConnection cn)
                {
                        OracleCommand _cmd = new OracleCommand(InsertSetting, cn);
                        _cmd.Parameters.Add(":CS", decimal.Parse(SavedSetting.CSID));
                        _cmd.Parameters.Add(":ZBID", decimal.Parse(SavedSetting.GuideLineID));
                        _cmd.Parameters.Add(":DWID", SinoUserCtx.CurUser.CurrentPost.PostDwID);
                        _cmd.Parameters.Add(":CS", SavedSetting.ParamMeta);
                        _cmd.Parameters.Add(":QUERYSQL", _queryStr);
                        _cmd.ExecuteNonQuery();
                }
        }
}
