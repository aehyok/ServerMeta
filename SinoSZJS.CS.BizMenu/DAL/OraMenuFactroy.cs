using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SinoSZJS.Base.MenuType;
using SinoSZJS.Base.Misc;
using SinoSZJS.DataAccess.Sql;
using System.Data.SqlClient;

namespace SinoSZJS.CS.BizMenu.DAL
{
        public class OraMenuFactory : ISinoMenu
        {
        #region ISinoMenu Members
        /// <summary>
        /// 取所有指定岗位下的菜单
        /// </summary>
        /// <param name="_postID">岗位ID</param>
        /// <returns></returns>
        private const string yhmenu_systemId = @"select yhmenu.*,level from 
                                                 (
                                                 select men2.*,1 canuse from md_mainmenu men2
                                                /*  where men2.systemid=strSYSTEMID*/
                                                   ) yhmenu
                                              start with yhmenu.fatherid=0
                                              connect by prior yhmenu.id=yhmenu.fatherid";
                public List<SinoMenuItem> GetAllMenus(string _postID)
                {
                        SqlDataReader dr;
                        List<SinoMenuItem> _ret = new List<SinoMenuItem>();
                        if (_postID != "0")
                        {
                                //string _sql = "zhtj_zzjg2.get_yhmenu_systemid";
                                string _sql = "zhtj_zzjg2.Get_GWMENU";
                                SqlParameter[] _param = {
                                        new SqlParameter("nGWID", SqlDbType.Decimal),
                                        new SqlParameter("nhavemeta",SqlDbType.Decimal),                            
                                        //new SqlParameter("curMENU",SqlDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                  };
                                _param[0].Value = decimal.Parse(_postID);
                                _param[1].Value = (decimal)1;

                                dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                                                                _sql, _param);
                        }
                        else
                        {
                                string _sql = "zhtj_zzjg2.get_yhmenu_systemid";
                                SqlParameter[] _param = {
                                        new SqlParameter("nyhid", SqlDbType.Decimal),
                                        new SqlParameter("nhavemeta",SqlDbType.Decimal),
                                        new SqlParameter("strsystemid",SqlDbType.VarChar,12),
                                        //new SqlParameter("curMENU",SqlDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                };
                                _param[0].Value = (decimal)0;
                                _param[1].Value = (decimal)1;
                                _param[2].Value = ConfigFile.SystemID;


                //dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                //                                _sql, _param);
                dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, yhmenu_systemId, null);
                        }

                        while (dr.Read())
                        {
                                SinoMenuItem _mitem = new SinoMenuItem(
                                        dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                                        dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDecimal(4)),
                                        dr.IsDBNull(5) ? "0" : dr.GetDecimal(5).ToString(),
                                        dr.IsDBNull(11) ? false : (dr.GetDecimal(11) > 0),
                                        dr.IsDBNull(12) ? 0 : Convert.ToInt32(dr.GetDecimal(12)),
                                        dr.IsDBNull(7) ? "-1" : dr.GetDecimal(7).ToString(),
                                        dr.IsDBNull(10) ? "" : dr.GetString(10)
                                );
                                _ret.Add(_mitem);
                        }
                        dr.Close();
                        return _ret;
                }




                public List<firstPageItem> GetfirstPage()
                {
                        List<firstPageItem> _ret = new List<firstPageItem>();
                        SqlDataReader dr;
                        string _sql = "select \"ID\",\"TYPE\",\"CS\",\"CAPTION\" from md_firstpage t order by xh";

                        dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql);
                        while (dr.Read())
                        {
                                firstPageItem _mitem = new firstPageItem(
                                        dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                                        dr.IsDBNull(3) ? "" : dr.GetString(3)
                                );
                                _ret.Add(_mitem);
                        }
                        dr.Close();
                        return _ret;
                }

             


               
                #endregion
        }
}
