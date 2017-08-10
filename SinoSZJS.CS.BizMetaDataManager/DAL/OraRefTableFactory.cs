using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SinoSZJS.Base.RefCode;
using SinoSZJS.DataAccess.Sql;
using System.Data.SqlClient;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
        public class OraRefTableFactory : ICS_RefCode
        {
                #region ICS_RefCode Members

                public RefCodeTablePropertie GetRefCodePropertie(string _refCodeName)
                {
                        SqlParameter[] _param;
                        string[] _ctNames = _refCodeName.Split('.');

                        RefCodeTablePropertie _ret = new RefCodeTablePropertie();
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("select REFTABLENAME,DESCRIPTION,REFTABLEMODE,DOWNLOADMODE,REFTABLELEVELFORMAT,HIDECODE ");
                        _sb.Append(" from md_reftablelist where REFTABLENAME = :TNAME");
                        if (_ctNames.Length > 1)
                        {
                                _sb.Append(" and NAMESPACE=:NAMESPACE ");

                                _param = new SqlParameter[] {
                                                new SqlParameter(":TNAME",SqlDbType.VarChar,50),
                                                new SqlParameter(":NAMESPACE",SqlDbType.VarChar,50) };
                                _param[0].Value = _ctNames[1];
                                _param[1].Value = _ctNames[0];
                        }
                        else
                        {
                                _param = new SqlParameter[] {
                                                new SqlParameter(":TNAME",SqlDbType.VarChar,50)};
                                _param[0].Value = _ctNames[0];
                        }


                        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

                        while (dr.Read())
                        {
                                _ret = new RefCodeTablePropertie(dr.GetString(0), dr.IsDBNull(1) ? dr.GetString(0) : dr.GetString(1),
                                        RefCodeType.Alpha, true, dr.IsDBNull(4) ? false : true,
                                        dr.IsDBNull(3) ? 1 : Convert.ToInt32(dr.GetDecimal(3)),
                                        dr.IsDBNull(2) ? 1 : Convert.ToInt32(dr.GetDecimal(2)),
                                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                                        dr.IsDBNull(5) ? false : (dr.GetDecimal(5) > 0));
                        }

                        dr.Close();

                        return _ret;
                }

                public List<RefCodeData> GetFullRefCodeData(string _refCodeName)
                {
                        List<RefCodeData> _ret = new List<RefCodeData>();
                        string[] _fnames = _refCodeName.Split('.');

                        string _sql = string.Format("select DM,MC,PYZT,PX,SFYX,BZ,FATHERCODE,SFXS,SFLR,SFYJD from JSODS.{0} order by PX,DM", _fnames[_fnames.Length - 1]);
                        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql);

                        while (dr.Read())
                        {
                                RefCodeData _rdata = new RefCodeData(
                                        dr.GetString(0),
                                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                                        dr.IsDBNull(3) ? 0 : Convert.ToInt32(dr.GetDecimal(3)),
                                        dr.IsDBNull(4) ? true : (dr.GetString(4) == "1"),
                                        dr.IsDBNull(5) ? "" : dr.GetString(5),
                                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                                        dr.IsDBNull(7) ? true : (dr.GetString(7) == "1"),
                                        dr.IsDBNull(8) ? true : (dr.GetString(8) == "1"),
                                        dr.IsDBNull(9) ? true : (dr.GetString(9) == "1"));
                                _ret.Add(_rdata);
                        }
			
                        dr.Close();
                        return _ret;
                }

                public List<RefCodeData> GetChildRefCodeData(string _refCodeName, string _fatherCode)
                {
                        List<RefCodeData> _ret = new List<RefCodeData>();
                        string[] _fnames = _refCodeName.Split('.');

                        string _sql = string.Format("select DM,MC,PYZT,PX,SFYX,BZ,FATHERCODE,SFXS,SFLR,SFYJD from JSODS.{0} ", _fnames[_fnames.Length - 1]);
                        if (_fatherCode == string.Empty)
                        {
                                _sql += "where FATHERCODE IS NULL order by PX,DM";
                        }
                        else
                        {
                                _sql += " where FATHERCODE = :FCODE order by PX,DM";
                        }

                        SqlParameter[] _param = new SqlParameter[] {
                                                new SqlParameter(":FCODE",SqlDbType.VarChar,50)};
                        _param[0].Value = _fatherCode;

                        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

                        while (dr.Read())
                        {
                                RefCodeData _rdata = new RefCodeData(
                                        dr.GetString(0),
                                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                                        dr.IsDBNull(3) ? 0 : Convert.ToInt32(dr.GetDecimal(3)),
                                        dr.IsDBNull(4) ? true : (dr.GetString(4) == "1"),
                                        dr.IsDBNull(5) ? "" : dr.GetString(5),
                                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                                        dr.IsDBNull(7) ? true : (dr.GetString(7) == "1"),
                                        dr.IsDBNull(8) ? true : (dr.GetString(8) == "1"),
                                        dr.IsDBNull(9) ? true : (dr.GetString(9) == "1"));
                                _ret.Add(_rdata);
                        }

                        dr.Close();
                        return _ret;
                }

                public RefCodeData GetRefCodeByCode(string _refCodeName, string _value)
                {
                        RefCodeData _ret = null;
                        string[] _fnames = _refCodeName.Split('.');

                        string _sql = string.Format("select DM,MC,PYZT,PX,SFYX,BZ,FATHERCODE,SFXS,SFLR,SFYJD from JSODS.{0} ", _fnames[_fnames.Length - 1]);
                        _sql += " where DM = :CODE order by PX,DM";


                        SqlParameter[] _param = new SqlParameter[] {
                                                new SqlParameter(":CODE",SqlDbType.VarChar,50)};
                        _param[0].Value = _value;

                        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

                        while (dr.Read())
                        {
                                _ret = new RefCodeData(
                                        dr.GetString(0),
                                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                                        dr.IsDBNull(3) ? 0 : Convert.ToInt32(dr.GetDecimal(3)),
                                        dr.IsDBNull(4) ? true : (dr.GetString(4) == "1"),
                                        dr.IsDBNull(5) ? "" : dr.GetString(5),
                                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                                        dr.IsDBNull(7) ? true : (dr.GetString(7) == "1"),
                                        dr.IsDBNull(8) ? true : (dr.GetString(8) == "1"),
                                        dr.IsDBNull(9) ? true : (dr.GetString(9) == "1"));

                        }

                        dr.Close();
                        return _ret;
                }

                #endregion

        }
}
