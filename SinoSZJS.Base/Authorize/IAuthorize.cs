using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Config;

namespace SinoSZJS.Base.Authorize
{
    public interface IAuthorize
    {
        SinoUser LoginSys(string _sysid, string _name, string _pass,string CheckType);
        bool CheckPassword(string _uname, string old_pass,string CheckType);
        bool ChangePassWord(string uname, string old_pass, string new_pass);
        List<SinoOrganize> GetRootDwList(string _rootDwid, decimal _levelNum);
        List<SinoOrganize> GetRootDwListEx(string _rootDwid, decimal _levelNum, string _type);
        ServerConfig GetServerConfig();
        /// <summary>
        /// 通过DWDM取单位ID
        /// </summary>
        /// <param name="_dwdm"></param>
        /// <returns></returns>
        decimal GetDWIDByDWDM(string _dwdm);

        void WriteExportLog(int _exportRowCount, string ExportDataMsg);
    }
}
