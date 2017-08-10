using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SinoSZJS.Base.Misc;
using System.IO;
using System.Threading;
using System.Diagnostics;
using SinoSZJS.DataAccess;
//using Excel;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using DataTable = System.Data.DataTable;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizReport
{
    public class ProcessExcelReport
    {
        #region �����Ա����
        // Private data
        private static int tempIndex = 0;
        //private static Application pExcelApp = null;
        private static int UseCount = 0;
        private volatile static bool isBusy = false;
        private static DateTime beforeTime = DateTime.Now;
        private static DateTime afterTime = DateTime.Now;
        //
        //private Application m_oExcelApp;
        private static ExcelPackage package;
        //
        //private Workbooks workbooks;
        private ExcelWorkbook workbook;
        //
        //private _Workbook workbook;
        //
        //private _Worksheet worksheet;
        private ExcelWorksheet worksheet;
        //
        //private Sheets oSheets;
        //private Range oCells;
        private object m_oMissing;
        private string m_sReportTemplate;
        private int m_nReportIndex;
        private string m_sDataTemplate;
        private string m_sExportFormat;
        private string m_sOutputCache;

        private string _reportTitle;

        private int BaseRow = 1;
        private int BaseCol = 1;
        // Set properties

        public static string Report_WebAppAddress = "";
        #endregion

        #region �޸ĳ�Ա�����Ĺ�������
        public string ReportTemplate
        {
            get { return m_sReportTemplate; }
            set { m_sReportTemplate = value; }
        }

        public string DataTemplate
        {
            get { return m_sDataTemplate; }
            set { m_sDataTemplate = value; }
        }

        public int ReportIndex
        {
            get { return m_nReportIndex; }
            set { m_nReportIndex = value; }
        }

        public string ExportFormat
        {
            get { return m_sExportFormat; }
            set { m_sExportFormat = value; }
        }

        public string OutputCache
        {
            get { return m_sOutputCache; }
            set { m_sOutputCache = value; }
        }

        public string ReportTitle
        {
            get { return _reportTitle; }
            set { _reportTitle = value; }
        }
        #endregion

        #region ��ʼ��
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public ProcessExcelReport()
        {
            //m_oExcelApp = null;
            //workbooks = null;
            //workbook = null;
            //worksheet = null;
            package = null;
            workbook = null;
            worksheet = null;
            m_oMissing = System.Reflection.Missing.Value;
            ReportIndex = 1;
        }
        #endregion

        #region ������
        /// <summary>
        /// ��䱨������
        /// </summary>
        /// <param name="rData">������</param>
        /// <param name="hmcData">����������</param>
        private void FillReportData(DataTable rData, DataSet hmcData)
        {
            //Range range1 = null;
            //Range range2 = null;
            ExcelRange range1 = null;
            ExcelRange range2 = null;
            try
            {
                //	2.�б���,��д������
                int linenum = BaseRow;
                //����ĳ�ʼ����ҪΪ��ֹ����δ��ʼ�����󣬲���һ����Ҫ����Ϊlinenum
                range1 = worksheet.Cells[String.Format("{0}:{1}", linenum, linenum)];
                range2 = worksheet.Cells[String.Format("{0}:{1}", linenum, linenum)];

                string oldLineType = "";
                DataTable rownameDt = hmcData.Tables["ROW_DEFINE"];
                try
                {
                    foreach (DataRow dr in rownameDt.Rows)
                    {
                        if (!dr.IsNull("HBSFZ"))
                        {
                            string fl = dr["HBSFZ"].ToString();
                            int thishx = int.Parse(dr["HX"].ToString()) + BaseRow;
                            if (thishx > linenum + 1) linenum = thishx - 1;

                            if (oldLineType == fl)
                            {
                                //����һ��
                                //range1 = (Range)worksheet.Rows[linenum - 1, m_oMissing];
                                //range1.Insert(XlDirection.xlDown, m_oMissing);//range2 = (Range)worksheet.Rows[linenum - 1, m_oMissing];
                                //range1.Copy(range2);

                                //edit by Ly 2015.06.17
                                try
                                {
                                    worksheet.InsertRow(linenum - 1, 1);
                                    range1.Address = String.Format("{0}:{1}", linenum - 1, linenum - 1);
                                    range2.Address = String.Format("{0}:{1}", linenum, linenum);
                                    range2.Copy(range1);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(String.Format("����һ��ʱ����{0}",ex.Message));
                                }
                                //System.Runtime.InteropServices.Marshal.ReleaseComObject (range1);
                                //System.Runtime.InteropServices.Marshal.ReleaseComObject(range2);
                            }
                            else
                            {
                                oldLineType = fl;
                            }
                            try
                            {
                                PutValueToCell(linenum, BaseCol, dr["HMC"]);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(
                                    String.Format("PutValueToCellʱ����{0},hx={1},lx={2},BaseRow={3},BaseCol={4}",
                                        ex.Message, linenum, BaseCol - 1, BaseRow, BaseCol));
                            }
                        }
                        linenum++;
                    }
                }
                catch (Exception ex)
                {
                    LogWriter.WriteSystemLog(string.Format("����������ʱ����{0}", ex.Message), "ERROR");
                }

                //��2.�б�������д����
                linenum = BaseRow;
                DataTable colnameDt = hmcData.Tables["COL_DEFINE"];
                int colCount = colnameDt.Rows.Count;
                int i = 0;
                double lastHx = 0;
                foreach (DataRow rowdr in rData.Rows)
                {
                    for (int colnum = 0; colnum < colCount; colnum++)
                    {
                        if (Double.Parse(rowdr["HX"].ToString()) > lastHx)
                        {
                            i++;
                        }
                        lastHx = Double.Parse(rowdr["HX"].ToString());
                        int thishx = BaseRow + i;
                        string lx = string.Format("L{0}", colnum + 1);
                        try
                        {
                            PutValueToCell(thishx - 1, colnum + BaseCol+1, rowdr[lx]);//rowdr[lx]
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("PutValueToCell����{0},hx={1},lx={2},BaseRow={3},BaseCol={4}", ex.Message,
                                thishx - 1, colnum + BaseCol, BaseRow, BaseCol));
                        }
                    }
                    linenum++;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteSystemLog(string.Format("��������ʱ����{0}", ex.Message), "ERROR");
            }
            finally
            {
                if (range1 != null)
                {
                    range1 = null;
                }

                if (range2 != null)
                {
                    range2 = null;
                }
                GC.Collect();
                //				GC.WaitForPendingFinalizers();
                //				GC.Collect();
                //				GC.WaitForPendingFinalizers();
            }
        }

        /// <summary>
        /// ��䳬����
        /// </summary>
        /// <param name="bbid"></param>
        /// <param name="mxData"></param>
        /// <param name="cellData"></param>
        /// <param name="hmcData"></param>
        private void FillHyperLinks(string bbid, DataTable mxData, DataTable cellData, DataSet hmcData)
        {
            int lfw = hmcData.Tables["COL_DEFINE"].Rows.Count;
            int hfw = hmcData.Tables["ROW_DEFINE"].Rows.Count;

            string url = Report_WebAppAddress + "/Dialog/ShowReportDetial.aspx";
            try
            {
                //�������б�
                foreach (DataRow dr in mxData.Rows)
                {
                    int hx = int.Parse(dr["HX"].ToString());
                    int lx = int.Parse(dr["LX"].ToString());
                    if (hx > 0 && hx <= hfw && lx > 0 && lx <= lfw)
                    {
                        string url2 = string.Format(@"{0}?HLX={1},{2}&REPORTID={3}", url, hx, lx, bbid);
                        //Hyperlink link = (Excel.Hyperlink)worksheet.Hyperlinks.Add(worksheet.Cells[hx + BaseRow - 1, lx + BaseCol], url2, m_oMissing, m_oMissing, m_oMissing);
                        try
                        {
                            worksheet.Cells[hx + BaseRow - 1, lx + BaseCol].Hyperlink = new Uri(url2);
                            //System.Runtime.InteropServices.Marshal.ReleaseComObject(link);????????????????????????????????????????????????????????????
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(String.Format("�������б�ʱ����{0},hx={1},lx={2},BaseRow={3},BaseCol={4}",
                                ex.Message, hx + BaseRow - 1, lx + BaseCol, BaseRow, BaseCol));
                        }
                    }
                }

                //�����ر�CELL��
                foreach (DataRow dr in cellData.Rows)
                {
                    int rownum = int.Parse(dr["RPHX"].ToString());
                    int colnum = int.Parse(dr["RPLX"].ToString());

                    int linkrownum = int.Parse(dr["BBHX"].ToString());
                    int linkcolnum = int.Parse(dr["BBLX"].ToString());

                    string sfmx = dr.IsNull("HASMX") ? "0" : dr["HASMX"].ToString();
                    if (sfmx == "1")
                    {
                        string url2 = string.Format(@"{0}?HLX={1},{2}&REPORTID={3}", url, linkrownum, linkcolnum, bbid);
                        //worksheet.Hyperlinks.Add(worksheet.Cells[rownum, colnum], url2, m_oMissing, m_oMissing, m_oMissing);
                        try
                        {
                            worksheet.Cells[rownum, colnum].Hyperlink = new Uri(url2);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(String.Format("�����ر�CELL��ʱ����{0},hx={1},lx={2},BaseRow={3},BaseCol={4}",
                                ex.Message, rownum, colnum, BaseRow, BaseCol));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter.WriteSystemLog(string.Format("��䳬����ʱ����{0}", ex.Message), "ERROR");
            }
        }

        /// <summary>
        /// ���������ļ���������
        /// </summary>
        /// <param name="bbid"></param>
        /// <param name="rData"></param>
        /// <param name="cellData"></param>
        /// <param name="mxData"></param>
        /// <param name="hmcData"></param>
        /// <param name="execelFile">���ɵ�Excel·��</param>
        /// <param name="htmFile">������</param>
        /// <param name="sMessage"></param>
        /// <returns></returns>
        public bool CreateReportFiles(string bbid, DataTable rData, DataTable cellData, DataTable mxData, DataSet hmcData, out string execelFile, out string htmFile, out string sMessage)
        {
            execelFile = "";
            htmFile = "";
            sMessage = "";
            string sDeleteFile = null;
            try
            {
                DataRow dr = hmcData.Tables["REPORT_DEFINE"].Rows[0]; string rdMeta = dr["BBMETA"].ToString();
                string brow = StrUtils.GetMetaByName("��׼��", rdMeta);
                string bcol = StrUtils.GetMetaByName("��׼��", rdMeta);

                if (brow != "") BaseRow = int.Parse(brow);
                if (bcol != "") BaseCol = int.Parse(bcol);

                //  temporary file name
                execelFile = Utils.ExeDir + string.Format(@"OutputCache\{0}.xlsx", _reportTitle);

                File.Copy(m_sReportTemplate, execelFile, true);
                m_sReportTemplate = execelFile;

                // Get valid report tempate
                OpenReportTempalte();

                //������
                FillReportData(rData, hmcData);

                //��CELL����
                FillSpecialCessData(cellData);

                //package = new ExcelPackage(new FileInfo(m_sReportTemplate));
                FillHyperLinks(bbid, mxData, cellData, hmcData);

                //����EXCEL�ļ�
                package.Save();

                //����ΪHTML�ļ�
                // get file name with out path
                //FileInfo oFInfo = new FileInfo(execelFile);
                //htmFile = oFInfo.Name.Replace(".xlsx", ".mht");
                //string sReportFileLocal = m_sOutputCache + Path.DirectorySeparatorChar + htmFile;
                //htmFile = sReportFileLocal;
                //// Delete if html file already exists
                //oFInfo = new FileInfo(sReportFileLocal);
                //if (oFInfo.Exists)
                //    File.Delete(sReportFileLocal);

                // Export to HTML format
                //package.SaveAs(sReportFileLocal, XlFileFormat.xlWebArchive, m_oMissing, m_oMissing, m_oMissing, m_oMissing,
                //               XlSaveAsAccessMode.xlNoChange, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing);

                // Done
                //package.SaveAs(oFInfo);

                LogWriter.WriteSystemLog(String.Format("�ļ����ɳɹ���"), "INFO");
                return true;
            }
            catch (Exception exp)
            {
                sMessage = exp.Message;
                string eStr = string.Format(" ϵͳ�����ݱ���ģ�����ɱ���ʱ��������\n  Error Message:{0}", exp.Message);
                LogWriter.WriteSystemLog(eStr, "ERROR");
                return false;
            }
            finally
            {
                CloseReportTemplate();
                if (sDeleteFile != null)
                    File.Delete(sDeleteFile);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="celldata">����</param>
        private void FillSpecialCessData(DataTable celldata)
        {
            //	��.����CELLDATA��
            foreach (DataRow dr in celldata.Rows)
            {
                int rownum = int.Parse(dr["RPHX"].ToString());
                int colnum = int.Parse(dr["RPLX"].ToString());

                PutValueToCell(rownum, colnum, dr["ZLX"].ToString() == "C" ? dr["Z_C"] : dr["Z_N"]);
            }

        }

        /// <summary>
        /// �������ֵ������ı����
        /// </summary>
        /// <param name="rownum">������</param>
        /// <param name="colnum">������</param>
        /// <param name="value">ֵ</param>
        private void PutValueToCell(int rownum, int colnum, object value)
        {
            if (value == DBNull.Value)
            {
                ExcelRange range2 = worksheet.Cells[rownum, colnum];

                if (range2.Formula.Length < 1)
                {
                    worksheet.Cells[rownum, colnum].Value = "-";
                }
            }
            else
            {
                worksheet.Cells[rownum, colnum].Value = value;
            }

        }

        /// <summary>
        /// ��Package����ʼ��WorkBook��WorkSheet
        /// </summary>
        public void OpenReportTempalte()
        {
            if (package != null)
                CloseReportTemplate();

            // Create an instance of Microsoft Excel, make it visible,
            // and open Book1.xls.
            //m_oExcelApp = new Excel.ApplicationClass();
            //m_oExcelApp = GetExcelApplication();
            //workbooks = m_oExcelApp.Workbooks;

            //edit by Ly 2015.06.17
            GetExcelPackage();
            workbook = package.Workbook;
            worksheet = workbook.Worksheets[m_nReportIndex];
            //m_oExcelApp.AskToUpdateLinks = false;

            // IMPORTANT: IF YOU ARE USING EXCEL Version >= 10.0 Use function 
            // prototype in "EXCEL VERSION 10.0" section. 
            // For Excel Version 9.0 use default "EXCEL VERSION = 9.0". 
            // This application is not tested with versions lower than Excel 9.0
            // Or greater than 10.0

            // EXCEL VERSION 10.0
            //workbook = workbooks.Open(m_sReportTemplate, m_oMissing, m_oMissing,
            //                        m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing,
            //                        m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing);
            // END EXCEL VERSION 10.0

            // EXCEL VERSION 9.0
            //workbook = workbooks.Open(m_sReportTemplate, m_oMissing, m_oMissing,
            //	m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing, 
            //	m_oMissing, m_oMissing, m_oMissing, m_oMissing,m_oMissing,m_oMissing);
            // END EXCEL VERSION 9.0
            //worksheet = (_Worksheet)workbook.Worksheets[m_nReportIndex];
        }

        /// <summary>
        /// ��ָ��·����Excel
        /// </summary>
        private void GetExcelPackage()
        {
            int times = 0;
            while (isBusy && times < 6000)
            {
                Thread.Sleep(100);
                times++;
            }
            isBusy = true;
            if (times > 5999)
            {
                LogWriter.WriteSystemLog("Excel ����æ��", "ERROR");
            }

            if (UseCount > 10)
            {
                //ClearExcelApp();
                KillExcelThread();
                UseCount = 0;
            }
            UseCount++;
            if (package == null)
            {
                beforeTime = DateTime.Now;
                //pExcelApp = new Application();
                //pExcelApp.Visible = false;
                //pExcelApp.DisplayAlerts = false;]
                try
                {
                    package = new ExcelPackage(new FileInfo(m_sReportTemplate));
                }
                catch (Exception ex)
                {
                    LogWriter.WriteSystemLog(String.Format("��ExcelPackageʱ����{0},�ļ���ַ��{1}", ex.Message,m_sReportTemplate),"ERROR");
                }
                afterTime = DateTime.Now;
            }
        }

        /// <summary>
        /// ��ֹ����
        /// </summary>
        private static void KillExcelThread()
        {
            DateTime startTime;
            Process[] myProcesses = Process.GetProcessesByName("Excel");

            //�ò���Excel����ID����ʱֻ���жϽ�������ʱ��
            foreach (Process myProcess in myProcesses)
            {
                startTime = myProcess.StartTime;

                if (startTime > beforeTime && startTime < afterTime)
                {
                    myProcess.Kill();
                }
            }

        }

        /// <summary>
        /// �ر�Package,WorkBook,WorkSheet
        /// </summary>
        private void CloseReportTemplate()
        {
            int ret = -1;
            //try
            //{
                //if (workbook != null)//workbook.Close(true, m_sReportTemplate, m_oMissing);

                    //if (package != null)
                    //{
                    //    LogWriter.WriteSystemLog(string.Format("ִ�йر�package��ret = {0}", ret), "INFO");
                    //}
                //m_oExcelApp = null;
                package = null;
                //workbooks = null;
                workbook = null;
                //oSheets = null;
                worksheet = null;
                //oCells = null;

                //LogWriter.WriteSystemLog("��ɹر�EXCEL���̣�", "INFO");
                //GC.Collect();
                isBusy = false;
                //				GC.WaitForPendingFinalizers();
                //				GC.Collect();
                //				GC.WaitForPendingFinalizers();

            //}
            //catch (Exception e)
            //{
            //    LogWriter.WriteSystemLog(string.Format("�ر�EXCEL����ʱ����{0}", e.Message), "ERROR");
            //}
            //finally
            //{
            //    GC.Collect();
            //    //				GC.WaitForPendingFinalizers();
            //    //				GC.Collect();
            //    //				GC.WaitForPendingFinalizers();

            //}
        }
        #endregion

        #region �ɷ����������ã�
        public bool GetTestReport(out string sReportFile, out string sMessage)
        {
            sReportFile = null;
            sMessage = "";
            string sDeleteFile = null;
            try
            {
                // Get temporary file name
                sReportFile = Path.GetTempFileName();
                File.Copy(m_sReportTemplate, sReportFile, true);
                m_sReportTemplate = sReportFile;

                // Get valid report tempate
                OpenReportTempalte();

                // Get employee data
                DataSet oRptData = new DataSet();
                oRptData.ReadXml(m_sDataTemplate);

                // Write employee data to spreadsheet (Excel)
                int nRow = 2;
                foreach (DataRow oRow in oRptData.Tables["Group"].Rows)
                {
                    worksheet.Cells[nRow, 1].Value = oRow["Name"];
                    worksheet.Cells[nRow, 2].Value = oRow["TestA"];
                    worksheet.Cells[nRow, 3].Value = oRow["TestB"];
                    worksheet.Cells[nRow, 4].Value = oRow["TestC"];

                    nRow++;
                }

                // Save data to temorary (sReportFile)
                if (m_sExportFormat.ToUpper().CompareTo("HTML") == 0)
                {
                    // get file name with out path
                    FileInfo oFInfo = new FileInfo(sReportFile);

                    // set delete file to orginal file
                    sDeleteFile = sReportFile;
                    sReportFile = oFInfo.Name.Replace(".", "") + "_Export.htm";
                    string sReportFileLocal = m_sOutputCache + Path.DirectorySeparatorChar.ToString() + sReportFile;

                    // Delete if html file already exists
                    oFInfo = new FileInfo(sReportFileLocal);
                    if (oFInfo.Exists)
                        File.Delete(sReportFileLocal);

                    // Export to HTML format
                    //workbook.SaveAs(sReportFileLocal, XlFileFormat.xlHtml, m_oMissing, m_oMissing, m_oMissing, m_oMissing,
                    //               XlSaveAsAccessMode.xlNoChange, m_oMissing, m_oMissing, m_oMissing, m_oMissing, m_oMissing);

                }
                else
                    package.Save();
                CloseReportTemplate();
                // Done
                return true;
            }
            catch (Exception exp)
            {
                sMessage = exp.Message;
                return false;
            }
            finally
            {
                CloseReportTemplate();
                if (sDeleteFile != null)
                    File.Delete(sDeleteFile);
            }
        }

        //private static Application GetExcelApplication()
        //{
        //    int times = 0;
        //    while (isBusy && times < 6000)
        //    {
        //        Thread.Sleep(100);
        //        times++;
        //    };
        //    isBusy = true;
        //    if (times > 5999)
        //    {
        //        LogWriter.WriteSystemLog("Excel ����æ��", "ERROR");
        //        return null;
        //    }

        //    if (UseCount > 10)
        //    {
        //        ClearExcelApp();
        //        KillExcelThread();
        //        UseCount = 0;
        //    }
        //    UseCount++;
        //    if (pExcelApp == null)
        //    {
        //        beforeTime = DateTime.Now;
        //        pExcelApp = new Application();
        //        pExcelApp.Visible = false;
        //        pExcelApp.DisplayAlerts = false;
        //        afterTime = DateTime.Now;
        //    }

        //    return pExcelApp;
        //}

        public static void ClearExcelApp()
        {
            int _ret = -1;
            try
            {

                if (package != null)
                {
                    //package.Quit();
                    ReleaseAllRef(package);
                    //_ret = System.Runtime.InteropServices.Marshal.ReleaseComObject(package);
                    //LogWriter.WriteSystemLog(string.Format("ִ�йر�package��ret = {0}", _ret), "INFO");
                    package = null;
                    GC.GetGeneration(package);

                }
                package = null;
                LogWriter.WriteSystemLog("��ɹر�EXCEL���̣�", "INFO");
                GC.Collect();
                //				GC.WaitForPendingFinalizers();
                //				GC.Collect();
                //				GC.WaitForPendingFinalizers();

            }
            catch (Exception e)
            {
                LogWriter.WriteSystemLog(string.Format("�ر�EXCEL����ʱ����{0}", e.Message), "ERROR");
            }
            finally
            {
                GC.Collect();
                //				GC.WaitForPendingFinalizers();
                //				GC.Collect();
                //				GC.WaitForPendingFinalizers();

            }
        }

        private static void ReleaseAllRef(Object obj)
        {
            try
            {
                //while (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 1) ;
            }

            finally
            {
                obj = null;
            }

        }
        #endregion
    }
}
