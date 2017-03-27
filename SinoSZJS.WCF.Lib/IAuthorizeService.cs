using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.Authorize;


namespace SinoSZJS.WCF.Lib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAuthorizeService”。
    /// <summary>
    /// 身份验证服务
    /// </summary>
    [ServiceContract]
    public interface IAuthorizeService
    {
        [OperationContract]
        bool HeartBeat();
        [OperationContract]
        SinoUser LoginSys(string SystemID, string UserName, string Password,string CheckType);
        [OperationContract]
        bool CheckPassword(string UserName, string Password,string CheckTypte);
        [OperationContract]
        bool ChangePassWord(string UserName, string OldPass, string NewPass);

    }
}
