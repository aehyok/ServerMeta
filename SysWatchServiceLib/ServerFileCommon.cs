using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.Common;
using SinoSZJS.Base.Misc;
using System.IO;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.Define;

namespace SysWatchServiceLib
{
    public class ServerFileCommon
    {
        public static string UpLoad(UpLoadFileInfo _uploadFileInfo)
        {
            try
            {
                string _fullpath = Utils.ExeDir + _uploadFileInfo.SavePath.Replace("..", "");
                if (!Directory.Exists(_fullpath))
                {
                    Directory.CreateDirectory(_fullpath);
                }
                string _fullFile = _fullpath + _uploadFileInfo.FileName.Replace("..", "").Replace('/', ' ');
                if (File.Exists(_fullFile))
                {
                    File.Delete(_fullFile);
                }

                using (FileStream fs = new FileStream(_fullFile, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(_uploadFileInfo.FileData, 0, _uploadFileInfo.FileData.Length);
                    fs.Close();
                }

                ServerPluginService.AddPluginDescript(_uploadFileInfo.PluginInfo);

                return "TRUE";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string MovePluginFileToRunPath(AppPluginInfo _api)
        {
            try
            {
                string _fullFile = Utils.ExeDir + "Plugin\\" + _api.AssemblyVersion + "\\" + _api.FileName;
                string _desFile = Utils.ExeDir + _api.FileName;
                _fullFile = _fullFile.Replace("..", "");
                _desFile = _desFile.Replace("..", "");
                File.Copy(_fullFile, _desFile, true);
                return "TRUE";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetAppPluginList()
        {
            List<AppPluginInfo> _ret = new List<AppPluginInfo>();
            try
            {
                string _basePath = Utils.ExeDir + "Plugin\\";
                DirectoryInfo _fdi = new DirectoryInfo(_basePath);
                DirectoryInfo[] subDirectories = _fdi.GetDirectories();
                foreach (DirectoryInfo _sdi in subDirectories)
                {
                    FileInfo[] _fs = _sdi.GetFiles();
                    foreach (FileInfo _f in _fs)
                    {
                        AppPluginInfo _api = new AppPluginInfo();
                        _api.FileName = _f.Name;
                        _api.AssemblyVersion = _sdi.Name;

                        AppPluginInfo _des = ServerPluginService.GetDescrip(_api.FileName);
                        if (_des != null)
                        {
                            _api.Name = _des.Name;
                            _api.Descript = _des.Descript;
                            _api.PluginType = _des.PluginType;
                        }

                        _ret.Add(_api);
                    }
                }
                string _retstr = SerializeHelper.JsonSerialize<List<AppPluginInfo>>(_ret);
                return _retstr;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
