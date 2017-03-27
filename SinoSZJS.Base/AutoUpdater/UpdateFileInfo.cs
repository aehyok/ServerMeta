using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.AutoUpdater
{
        public class UpdateFileInfo
        {
                private string _fileName = "";
                private string _AvailableVersion = "";
                private string _AppFileURL = "";

                public string FileName
                {
                        get { return _fileName; }
                        set { _fileName = value; }
                }

                public string AvailableVersion
                {
                        get { return _AvailableVersion; }
                        set { _AvailableVersion = value; }
                }

                public string AppFileURL
                {
                        get { return _AppFileURL; }
                        set { _AppFileURL = value; }
                }

                public UpdateFileInfo(string _fname, string _version, string _fileURL)
                {
                        this._fileName = _fname;
                        this._AvailableVersion = _version;
                        this._AppFileURL = _fileURL;
                }


        }
}
