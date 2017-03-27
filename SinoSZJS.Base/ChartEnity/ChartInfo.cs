using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZJS.Base.ChartEnity
{
    public class ChartInfo
    {
        /// <summary>
        /// Chart的名称
        /// </summary>
        public string ChartName { get; set; }
        /// <summary>
        /// 获取或设置数据字段的名称
        /// </summary>
        public string ArgumentDataMember { set; get; }
        /// <summary>
        /// 获取一个集合，包含数据字段的数据值。
        /// </summary>
        public string ValueDataMembers { set; get; }
        /// <summary>
        /// 获取或设置系列字段的名称
        /// </summary>
        public string SeriesDataMember { set; get; }
        public string Action { set; get; }
        public string Controller { set; get; }
        private DataTable resultTable = new DataTable();
        public DataTable ResultTable
        {
            set { resultTable = value; }
            get { return resultTable; }
        }
        public bool IsShowValues { set; get; }
        public int ChartWidth { set; get; }
    }
}
