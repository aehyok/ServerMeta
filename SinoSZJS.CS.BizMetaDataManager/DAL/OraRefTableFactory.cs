using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using SinoSZJS.Base.RefCode;
using SinoSZJS.DataAccess;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
        public class OraRefTableFactory : ICS_RefCode
        {
                #region ICS_RefCode Members

                public RefCodeTablePropertie GetRefCodePropertie(string _refCodeName)
                {
                        OracleParameter[] _param;
                        string[] _ctNames = _refCodeName.Split('.');

                        RefCodeTablePropertie _ret = new RefCodeTablePropertie();
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("select REFTABLENAME,DESCRIPTION,REFTABLEMODE,DOWNLOADMODE,REFTABLELEVELFORMAT,HIDECODE ");
                        _sb.Append(" from md_reftablelist where REFTABLENAME = :TNAME");
                        if (_ctNames.Length > 1)
                        {
                                _sb.Append(" and NAMESPACE=:NAMESPACE ");

                                _param = new OracleParameter[] {
                                                new OracleParameter(":TNAME",OracleDbType.Varchar2,50),
                                                new OracleParameter(":NAMESPACE",OracleDbType.Varchar2,50) };
                                _param[0].Value = _ctNames[1];
                                _param[1].Value = _ctNames[0];
                        }
                        else
                        {
                                _param = new OracleParameter[] {
                                                new OracleParameter(":TNAME",OracleDbType.Varchar2,50)};
                                _param[0].Value = _ctNames[0];
                        }


                        OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

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
                        OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql);

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

                        OracleParameter[] _param = new OracleParameter[] {
                                                new OracleParameter(":FCODE",OracleDbType.Varchar2,50)};
                        _param[0].Value = _fatherCode;

                        OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

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


                        OracleParameter[] _param = new OracleParameter[] {
                                                new OracleParameter(":CODE",OracleDbType.Varchar2,50)};
                        _param[0].Value = _value;

                        OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

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
