using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZServerBase;
using SinoSZJS.Base.Misc;
using System.Data;
using System.Web.Script.Serialization;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;


namespace SinoSZJS.CS.Tasks.HP.Inspection
{
    public class Task_Inspection : Task_Base
    {
        private string _wsUrl="";

        /// <summary>
        /// 设置任务参数
        /// </summary>
        /// <param name="rwid">任务ID</param>
        /// <param name="param">参数</param>
        public Task_Inspection(string rwid, string param)
        {
            _Rwid = rwid;
            string stepstr = StrUtils.GetMetaByName("STEP", param);	//STEP: 任务时间间隔

            try
            {
                _TimeStep = int.Parse(stepstr);
            }
            catch
            {
                _TimeStep = 1;
            }

            string wsUrl = StrUtils.GetMetaByName("WSURL", param); //WSURL：WebService服务地址

            _wsUrl = wsUrl;
        }
        /// <summary>
        /// 主程序
        /// </summary>
        public override void ThreadProc()
        {
            int ret = 0;
            WriteRWState();
            _startTime = DateTime.Now;

            //取所有未发送记录
            DataTable dt = GetRecord();
            //取出所有待发送的记录
            foreach (DataRow dr in dt.Rows)
            {
                string errormsg = "";
                string casenum = dr["DB_TASK_TITLE"].ToString();

                #region 发送
                int i = 0;
                //重复发送3次直至成功或最终失败
                while (i++ < 3)
                {
                    //推送记录到对方接口
                    ret = SendTo(casenum, ref  errormsg);
                    if (ret == 0)
                    {
                        UpdateStatue(casenum, "已发送","");//改成已发送
                        break;
                    }
                    else
                    {
                        UpdateStatue(casenum, "发送失败",errormsg);//改成发送失败
                    }
                }
                #endregion
                //有且仅有ret为3，即对方接口不通时，整个任务设置为失败，否则，只要收到对方反馈信息即为任务成功
                if (ret == 3)
                {
                    //写任务失败结果
                    WriteErrorResult(errormsg);
                    break;
                }
            }

            //写任务成功结果
            if (ret != 3)
                WriteResult();
        }
        /// <summary>
        /// 更新单条记录发送状态
        /// </summary>
        /// <param name="casenum">案件编号</param>
        /// <param name="FSZT">发送状态</param>
        /// <param name="Msg">异常信息</param>
        private void UpdateStatue(string casenum, string FSZT,string Msg)
        {
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand cmd = new OracleCommand
                    {
                        Connection = cn,
                        CommandType = CommandType.Text,
                        CommandText = " Update YW_QD_DBSX set  FSZT=:FSZT,YCQK=:YCQK where DB_TASK_TITLE=:casenum "
                    };
                    cmd.Parameters.Add(":FSZT", FSZT);
                    cmd.Parameters.Add(":YCQK",Msg);
                    cmd.Parameters.Add(":casenum", casenum);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                string log = string.Format("更新黄埔发送案件状态出错：{0}", e.Message);
                WriteTaskLog(9, log);
            }
        }

        /// <summary>
        /// 获取所有待发送的记录
        /// </summary>
        /// <returns>记录集</returns>
        private DataTable GetRecord()
        {
            DataTable datatable = new DataTable();
           //获取待发送记录
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand cmd = new OracleCommand
                    {
                        Connection = cn,
                        CommandType = CommandType.Text,
                        CommandText =
                            " Select  * from YW_QD_DBSX where DB_APPLICATION_NAME = 'HPCYApp' and  FSZT not in '已发送'"
                    };
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(datatable);
                    }
                    return datatable;
                }
            }
            catch (Exception e)
            {
                string log = string.Format("查询黄埔待发送案件信息出错：{0}", e.Message);
                WriteTaskLog(9, log);
                return null;
            }
        }
        /// <summary>
        /// 推送记录至对方接口
        /// </summary>
        /// <param name="caseNum">案件编号</param>
        /// <param name="errorMsg">反馈的信息</param>
        /// <returns>0成功，1失败，2通过该案件号没有找到相关信息，3接口不通</returns>
        private int SendTo(string caseNum, ref string errorMsg)
        {
            int ret = 0;
            string retmsg;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var jser = new JavaScriptSerializer();
            HPHGCtaService.HPHGCtaService svc = new HPHGCtaService.HPHGCtaService {Url = _wsUrl};
            try
            {
#if DEBUG
                retmsg = "{\"code\":\"103\",\"msg\":\"通过该案件号没有找到相关信息\"}";
#else
                retmsg  = svc.UpdateEntryHeadStatus(caseNum);
#endif
                //解析反馈的json信息
                dic = (Dictionary<string, object>)jser.DeserializeObject(retmsg);
                string code = dic["code"].ToString();
                string msg = dic["msg"].ToString() + "，案件编号为：" + caseNum;
                errorMsg = string.Format("{0},案件编号为：{1}",msg,caseNum);
                //根据不通的反馈信息设置返回值，并写日志
                switch(code) 
                {
                    case "101":
                        WriteTaskLog(0, errorMsg);
                        ret = 0;
                        break;
                    case "102":
                        WriteTaskLog(9, errorMsg);
                        ret = 1;
                        break;
                    case "103":
                        WriteTaskLog(9, errorMsg);
                        ret = 2;
                        break;
                }
            }
            catch (Exception ex)
            {
                ret = 3;
                errorMsg = string.Format("{0},发送到黄埔接口时出错：{1}", errorMsg,ex.Message);
                WriteTaskLog(9, errorMsg);
            }

            return ret;
        }
    }
}
