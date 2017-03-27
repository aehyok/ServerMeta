using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base
{
    public class PagingParas
    {
        public string GridViewName { set; get; }
        public decimal PageSize { set; get; }
        public decimal RecordCount { set; get; }
        public decimal PageCount { set; get; }
        public decimal PageIndex { set; get; }
        public string SortBy { set; get; }
        public string SortDirection { set; get; }
        public PagingParas()
        {
            PageIndex = 1;
            PageSize = 15;
        }
    }
}
