using System;
using System.Collections.Generic;
using System.Text;

using SinoSZJS.Base.SyntaxAnalyse.TokenRecord;
using SinoSZJS.Base.SyntaxAnalyse;
using SinoSZJS.Base.MetaData.QueryModel;


namespace SinoSZMetaDataQuery.SyntaxAnalyse.ComputeFieldExpression
{
        public class ComputeFieldSyntaxAnalyse
        {

                /// <summary>
                /// 构造函数
                /// </summary>
                /// <remarks>Author:Alex Leo; Date:2007-8-2</remarks>
                /// 

                public ComputeFieldSyntaxAnalyse()
                {

                }


                public void InitVarDefine(List<MDModel_Table> _tables)
                {

                }

                public void InitMethodDefine()
                {

                }

                /// <summary>
                /// 分析语句并返回记号记录对象
                /// </summary>
                /// <param name="Code">运算表达式</param>
                /// <returns>顶级TokenRecord对象</returns>
                public TokenRecord Analyse(string Code)
                {
                        if (Code.Trim().Equals(string.Empty))
                        {
                                return null;
                        }

                        List<TokenRecord> ListToken = new List<TokenRecord>();//TokenRecord列表

                        int intIndex = 0;
                        //词法分析，将代码转换为TokenRecord列表
                        ComputeFieldTokenFactory.LexicalAnalysis(ListToken, Code, ref intIndex);

                        //语法树分析，将Token列表按优先级转换为树
                        TokenRecord TokenTop = SyntaxTreeAnalyse.SyntaxTreeGetTopTokenAnalyse(ListToken, 0, ListToken.Count - 1);
                        return TokenTop;
                        
                }
        }
}
