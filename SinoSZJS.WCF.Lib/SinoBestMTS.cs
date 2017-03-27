using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.CS.BizMetaDataManager.MTS;
using SinoSZJS.Base.SinoBestMTS;

namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“SinoBestMTS”。
    public class SinoBestMTS : ISinoBestMTS
    {

        public string Echo(string input)
        {
            return "SinoBest_MTS_ECHO_TRUE";
        }

        public string Handle(string MessageData)
        {
            MTSResultMessage _s;
            MTSMessage _msg = new CS.BizMetaDataManager.MTS.MTSMessage(MessageData);
            //先落地保存
            bool _ret = SinoBestMTSWriter.SaveBufferData(_msg.PKGuid, _msg.DEPLOYID_TX, _msg.DEPLOYID_RX, "RX接收成功", "", 0, _msg.DataPKG, _msg.PROCMETHOD);
            if (!_ret)
            {
                _s = new MTSResultMessage();
                _s.PKGuid = _msg.PKGuid;
                _s.ResultType = "1";
                _s.ResultMethod = "";
                _s.ResultBody = "数据存入接收缓存区时失败！";
            }
            else
            {
                //反射类处理
                ISinoBestMTSAdatper _adapter = AdapterLib.GetAdapter(_msg.PROCMETHOD);
                string _excuteRet = _adapter.Excute(_msg.PKGuid);
                if (_excuteRet == null || _excuteRet == "")
                {
                    _s = new MTSResultMessage();
                    _s.PKGuid = _msg.PKGuid;
                    _s.ResultType = "0";
                    _s.ResultMethod = "";
                    _s.ResultBody = "处理成功！";
                    SinoBestMTSWriter.ChangeStatus("RX处理成功", _msg.PKGuid,"");
                }
                else
                {
                    _s = new MTSResultMessage();
                    _s.PKGuid = _msg.PKGuid;
                    _s.ResultType = "1";
                    _s.ResultMethod = "";
                    _s.ResultBody = _excuteRet;
                    SinoBestMTSWriter.ChangeStatus("RX处理失败", _msg.PKGuid,_excuteRet);
                }
            }
            return _s.CreateMsg();
        }
    }
}
