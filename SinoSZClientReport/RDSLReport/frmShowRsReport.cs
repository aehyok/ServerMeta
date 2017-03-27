using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZClientReport.RDSLReport
{
        public partial class frmShowRsReport : DevExpress.XtraEditors.XtraForm
        {
                public frmShowRsReport()
                {
                        InitializeComponent();
                }

                public frmShowRsReport(string _title)
                {
                        InitializeComponent();
                        this.Text = _title;
                }

                private void frmShowRsReport_Load(object sender, EventArgs e)
                {
                        //DataTable _dt = new DataTable();
                        //this.sinoUC_ShowRDSLReport1.ShowReport(_dt);
                }

                private void ShowreportEE()
                {
                        /*
                        
                        string UrlPath ="/海关总署缉私局/"+m_RParm.ReportName;
			//string UrlPath ="/海关总署缉私局/JS01";
			string format = "MHTML";
			try
			{
				Byte[] results = SessionClass.RemoteReportObj.GetReport(UrlPath,format,m_RParm);
				if (results == null)
				{
					XtraMessageBox.Show("报表服务器正忙，稍候请重试！","系统提示");
					this.Close();
					return ;
				}
				Random rdm1 = new Random(unchecked((int)DateTime.Now.Ticks)); 

				string fileName = Utils.ExeDir+string.Format("temp{0}a{1}.MHTML",rdm1.Next(1000000),s_NextNum.ToString());
				FileStream stream = File.OpenWrite(fileName);
				int _count = results.Length;
				stream.Write(results,0,_count);
				stream.Close();
				
				
				this.LoadUrl(fileName);
				_filename = fileName;
				
				panel6.Visible = false;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show("报表未生成！\n"+ex.Message,"发生错误");
			}
			//File.Delete(fileName);
                      
                         
                         */ 
                         
                }

                private void GetReport()
                {
                        /*
                        AuthorClass _cc;



                        rs = new ReportingService();


                        // Authenticate to the Web service using Windows credentials
                        // rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
                        lock (_up)
                        {
                                _cc = _RsAuthor[_up.value++];

                                if (_up.value >= _AuthorCount)
                                        _up.value = 0;
                        }
                        rs.Credentials = new System.Net.NetworkCredential(_cc._name, _cc._pass);
                        //rs.Credentials =  new System.Net.NetworkCredential(Config.Rs_UserName, Config.Rs_UserPass);
                        // Assign the URL of the Web service
                        rs.Url = Config.Rs_Url;


                        // Prepare Render arguments
                        string historyID = null;
                        string deviceInfo = null;

                        ParameterValue[] param = new ParameterValue[3];
                        param[0] = new ParameterValue();
                        param[0].Name = "Report_Parameter_Year";
                        param[0].Value = Parameters.ReportYear;
                        param[1] = new ParameterValue();
                        param[1].Name = "Report_Parameter_month";
                        param[1].Value = Parameters.ReportMonth;
                        param[2] = new ParameterValue();
                        param[2].Name = "Report_Parameter_Dw";
                        param[2].Value = Parameters.DwBm;

                        string showHide = null;

                        DataSourceCredentials[] credentials = null;
                        Byte[] results;
                        string encoding;
                        string mimeType;
                        Warning[] warnings = null;
                        ParameterValue[] reportHistoryParameters = null;
                        string[] streamIDs = null;
                        //Exectute the report and save it into a file.
                        try
                        {
                                results = rs.Render(ReportPath, Format, historyID, deviceInfo, param,
                                        credentials, showHide, out encoding, out mimeType,
                                        out reportHistoryParameters, out warnings, out streamIDs);
                                return results;
                        }
                        catch (Exception e)
                        {
                                Exception e1 = e;
                                if (!EventLog.SourceExists("ZHTJLog"))
                                {

                                        EventLog.CreateEventSource("ZHTJLog", "ZHTJLog");
                                }

                                // Create an EventLog instance and assign its source.
                                EventLog myLog = new EventLog();
                                myLog.Source = "ZHTJLog";

                                string _eStr = string.Format(" 系统在生成报表时发出错误！\n Report Name:{0} \n Report Date:{1} \n Report Dw:{2} \n Report Error:{3}",
                                        Parameters.ReportName, Parameters.ReportYear + Parameters.ReportMonth,
                                        string.Format("{0}[{1}]", Parameters.Dwmc, Parameters.DwBm), e.Message);
                                // Write an informational entry to the event log. 
                                myLog.WriteEntry(_eStr, EventLogEntryType.Error);
                                ServerCommon.WriteLog2DB(_eStr);
                                return null;
                        }
			*/
                }
        }
}