using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Collections.ObjectModel;
using SinoSZJS.Base.InputModel;

namespace SinoSZJS.Base.Misc
{
    public static class MDQueryResultConverter
    {
        public static IEnumerable ToDataSource(this MDQueryResult_Table table)
        {
           // return GenerateResultData(table.Rows).ToDataSource();
            return null;
        }

        public static IEnumerable<IDictionary> GenerateResultData(ObservableCollection<MDQueryResult_TableRow> data)
        {
            foreach (MDQueryResult_TableRow _row in data)
            {
                yield return _row.Values;
            }

        }

        public static IEnumerable<IDictionary> GenerateResultData(ObservableCollection<MD_InputEntity> data)
        {
            foreach (MD_InputEntity _row in data)
            {
                yield return _row.InputData;
            }

        }
    }
}
