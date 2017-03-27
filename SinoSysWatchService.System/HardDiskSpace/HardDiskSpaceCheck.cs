using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.Base.SystemCheck;
using System.Management;
using System.IO;
using System.Web.Script.Serialization;

namespace SinoSysWatchService.System.HardDiskSpace
{
    public class HardDiskSpaceCheck : ICheckProject
    {
        public int Check(ref string json)
        {
            List<HardDiskPartition> DiskListInfo = GetDiskListInfo();
            int _ret = CheckError(DiskListInfo);
            var jser = new JavaScriptSerializer();
            //序列化
            json = jser.Serialize(DiskListInfo);

            //反序列化
            //EntryHeadExtend = jser.Deserialize<ICS_ENTRY_HEAD_EXTEND>(json);

            //判断处于错误状态还是警告状态

            return _ret;
        }

        private int CheckError(List<HardDiskPartition> DiskListInfo)
        {
            int _res = 1;
            foreach (HardDiskPartition _hd in DiskListInfo)
            {
                if (_hd.FreeSpace < 1)
                {
                    if (_hd.FreeSpace < 0.2)
                    {
                        _res = 3;
                    }
                    _res = Math.Max(_res, 2);
                }
            }
            return _res;
        }

        private List<HardDiskPartition> GetDiskListInfo()
        {
            List<HardDiskPartition> list = null;
            //指定分区的容量信息
            try
            {
                SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

                ManagementObjectCollection diskcollection = searcher.Get();
                if (diskcollection != null && diskcollection.Count > 0)
                {
                    list = new List<HardDiskPartition>();
                    HardDiskPartition harddisk = null;
                    foreach (ManagementObject disk in searcher.Get())
                    {
                        int nType = Convert.ToInt32(disk["DriveType"]);
                        if (nType != Convert.ToInt32(DriveType.Fixed))
                        {
                            continue;
                        }
                        else
                        {
                            harddisk = new HardDiskPartition();
                            harddisk.FreeSpace = Math.Round((Convert.ToDouble(disk["FreeSpace"]) / (1024 * 1024 * 1024)), 2);
                            harddisk.SumSpace = Math.Round((Convert.ToDouble(disk["Size"]) / (1024 * 1024 * 1024)), 2);
                            harddisk.PartitionName = disk["DeviceID"].ToString()+"盘";
                            harddisk.IsPrimary = IsThisPrimary(harddisk.PartitionName);
                            list.Add(harddisk);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

        private bool IsThisPrimary(string _partitonName)
        {
            if (Environment.GetEnvironmentVariable("windir").Remove(2) == _partitonName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
