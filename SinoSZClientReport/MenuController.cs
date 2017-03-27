using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework;
using SinoSZClientReport.ReportGuideLine;
using SinoSZPluginFramework.ClientPlugin;
using SinoSZJS.Base.Misc;
using SinoSZClientReport.DataCheck.Board;
using SinoSZClientReport.DataCheck;

namespace SinoSZClientReport
{
        /// <summary>
        /// 菜单控制类
        /// </summary>
        public class MenuController
        {
                static public bool DoCommand(string _menuID,string _commandName, string _commandTitle, string _param, IApplication _application)
                {
                        switch (_commandName)
                        {
                                case "CreateReport":  //报表生成                                       
                                        frmCreateReport _form = new frmCreateReport(_commandTitle,_param);
                                        _application.AddForm(Guid.NewGuid().ToString(), _form);
                                        break;
                                case "BrowseReport": //报表浏览
                                        frmBrowseReport _bf = new frmBrowseReport(_commandTitle, _param);
                                        _application.AddForm(Guid.NewGuid().ToString(), _bf);
                                        break;
                               
                                case "ReportGuideLineQuery":
                                        string _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmReportGuideLineQuery _frm = MenuFunctions.AddPage<frmReportGuideLineQuery>(_title, _application);
                                        if (_frm != null)
                                        {
                                                _frm.Init(_title, "报表指标查询", _param);
                                        }
                                   
                                        break;
                                case "DataCheck":  //数据审核
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmCheckSearch _frm_DataCheck = MenuFunctions.AddPage<frmCheckSearch>(_title, _application);
                                        if (_frm_DataCheck != null)
                                        {
                                            _frm_DataCheck.Init(_title, "数据审核", _param);
                                        }
                                        break;
                                case "DataCheckBoard"://审核公告
                                        _title = StrUtils.GetMetaByName2("标题", _param);
                                        frmDataCheckBoard _frmBoard = MenuFunctions.AddPage<frmDataCheckBoard>(_title, _application);
                                        if (_frmBoard != null)
                                        {
                                            _frmBoard.Init(_title, "审核公告", _param);
                                        }
                                        break;
                        }
                        return true;
                }
        }
}
