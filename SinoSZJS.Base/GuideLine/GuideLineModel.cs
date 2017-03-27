using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.GuideLine
{
    /// <summary>
    /// 这是最新的指标定义
    /// </summary>
    public class GuideLineModel
    {
        /// <summary>
        /// 指标实体
        /// </summary>
        public GuideLineEntity GuideLine { set; get; }
        /// <summary>
        /// gridview样式定义
        /// </summary>
        public GridInfo GridViewInfo { set; get; }
    }
}
