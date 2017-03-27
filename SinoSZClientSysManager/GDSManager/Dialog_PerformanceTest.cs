using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.Misc;
using System.IO;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Threading;
using System.ServiceModel;

namespace SinoSZClientSysManager.GDSManager
{
    public partial class Dialog_PerformanceTest : DevExpress.XtraEditors.XtraForm
    {
        public string Token = "";
        public string URL = "";
        public string CommandName = "";
        public Dictionary<int, string> CSDataList = new Dictionary<int, string>();
        public List<TestIcsAsynReturn> AllReturnList = new List<TestIcsAsynReturn>();
        private volatile int RunTimes = 0;
        private volatile int AllTimes = 0;
        private volatile int CSCount = 0;
        public Dialog_PerformanceTest()
        {
            InitializeComponent();
        }

        public Dialog_PerformanceTest(string _url, string _token, string _commandName)
        {
            InitializeComponent();
            this.URL = _url;
            this.Token = _token;
            this.CommandName = _commandName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int TotalJCS = 0;
            string _strTimes = this.te_ZCS.Text.Trim();
            if (StrUtils.IsDigit(_strTimes))
            {
                RunTimes = int.Parse(_strTimes);
                AllTimes = RunTimes + 1;
            }
            else
            {
                MessageBox.Show("总执行次数不正确!", "系统提示");
            }

            string _strJCS = this.te_JCS.Text.Trim();
            if (StrUtils.IsDigit(_strJCS))
            {
                TotalJCS = int.Parse(_strJCS);
            }
            else
            {
                MessageBox.Show("并行线程数不正确!", "系统提示");
            }

            string _cslist = this.te_CSList.Text.Trim();
            if (_cslist == "")
            {
                MessageBox.Show("请录入测试参数列表!", "系统提示");
            }
            else
            {
                CSDataList.Clear();
                AllReturnList.Clear();
                this.te_Result.Text = "";
                int i = 0;
                foreach (string _line in this.te_CSList.Lines)
                {
                    string _s = _line.Trim();
                    if (_s != "")
                    {
                        CSDataList.Add(i++, _s);
                    }
                }
                if (i > 0)
                {
                    CSCount = CSDataList.Count();
                    for (int j = 0; j < TotalJCS; j++)
                    {
                        BackgroundWorker _w = new BackgroundWorker();
                        _w.WorkerReportsProgress = true;
                        _w.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_w_RunWorkerCompleted);
                        _w.DoWork += new DoWorkEventHandler(_w_DoWork);
                        _w.ProgressChanged += new ProgressChangedEventHandler(_w_ProgressChanged);
                        _w.RunWorkerAsync(j);
                    }
                }


            }
        }

        void _w_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TestIcsAsynReturn _data = e.UserState as TestIcsAsynReturn;
            AllReturnList.Add(_data);
            string _msg = string.Format("完成第{0}次测试，用时{1} ms", _data.Index, _data.UsedTimes);
            this.te_Result.AppendText(_msg + "\r\n");
        }

        void _w_DoWork(object sender, DoWorkEventArgs e)
        {
            int _threadIndex = (int)e.Argument;
            BackgroundWorker _worker = sender as BackgroundWorker;
            int _currentTimes = RunTimes--;
            while (_currentTimes > 0)
            {
                Random ran = new Random();
                int RandKey = ran.Next(0, CSCount);
                string _cs = CSDataList[RandKey];
                List<MD_GuideLineSimpleParam> _plist = new List<MD_GuideLineSimpleParam>();
                foreach (string _s in _cs.Split(','))
                {
                    string[] _s1 = _s.Split('=');
                    if (_s1.Count() > 1)
                    {
                        MD_GuideLineSimpleParam _p = new MD_GuideLineSimpleParam();
                        _p.ParameterName = _s1[0];
                        _p.ParameterValue = _s1[1];
                        _plist.Add(_p);
                    }
                }
                string _xmlData = DataConvert.Serializer(typeof(List<MD_GuideLineSimpleParam>), _plist);
                int _ctime = Environment.TickCount;
                string _ret = DoTestICS(_xmlData);
                int _useTime = Environment.TickCount - _ctime;

                TestIcsAsynReturn _r = new TestIcsAsynReturn();
                _r.Index = AllTimes - _currentTimes;
                _r.CallData = _cs;
                _r.ReturnData = _ret;
                _r.UsedTimes = _useTime;

                _worker.ReportProgress(0, _r);

                _currentTimes = RunTimes--;
            }
            e.Result = _threadIndex;
        }

        private string DoTestICS(string _xmlData)
        {
            JSGeneralDataService.JSGeneralDataServiceClient _jdsc = new JSGeneralDataService.JSGeneralDataServiceClient();
            _jdsc.Endpoint.Address = new EndpointAddress(new Uri(this.URL));
            
            try
            {
                string _msg = _jdsc.Do(this.Token, this.CommandName, _xmlData);
                return _msg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        void _w_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int _threadIndex = (int)e.Result;
            this.te_Result.AppendText(string.Format("线程{0}已经停止!\r\n", _threadIndex));
            this.gridView1.BeginDataUpdate();
            this.gridControl1.DataSource = AllReturnList;
            this.gridView1.EndDataUpdate();
        }
    }
}