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
                /// ���캯��
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
                /// ������䲢���ؼǺż�¼����
                /// </summary>
                /// <param name="Code">������ʽ</param>
                /// <returns>����TokenRecord����</returns>
                public TokenRecord Analyse(string Code)
                {
                        if (Code.Trim().Equals(string.Empty))
                        {
                                return null;
                        }

                        List<TokenRecord> ListToken = new List<TokenRecord>();//TokenRecord�б�

                        int intIndex = 0;
                        //�ʷ�������������ת��ΪTokenRecord�б�
                        ComputeFieldTokenFactory.LexicalAnalysis(ListToken, Code, ref intIndex);

                        //�﷨����������Token�б����ȼ�ת��Ϊ��
                        TokenRecord TokenTop = SyntaxTreeAnalyse.SyntaxTreeGetTopTokenAnalyse(ListToken, 0, ListToken.Count - 1);
                        return TokenTop;
                        
                }
        }
}
