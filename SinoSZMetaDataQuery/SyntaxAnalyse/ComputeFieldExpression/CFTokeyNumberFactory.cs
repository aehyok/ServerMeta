using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SyntaxAnalyse.TokenRecord;
using SinoSZJS.Base.SyntaxAnalyse;

namespace SinoSZMetaDataQuery.SyntaxAnalyse.ComputeFieldExpression
{
        public class CFTokeyNumberFactory : ComputeFieldTokenFactory
        {
                public new static void LexicalAnalysis(List<TokenRecord> TokenList, string Code, ref int Index)
                {
                        int intIndexCurrent = Index;//ָ���һ���ַ�
                        bool blnContinue = true;
                        char chrTemp;
                        string strTempWord;

                        while (blnContinue && intIndexCurrent < Code.Length)
                        {
                                chrTemp = Code[intIndexCurrent];
                                if (char.IsDigit(chrTemp) || chrTemp.Equals('.'))
                                {
                                        intIndexCurrent += 1;
                                }
                                else
                                {
                                        blnContinue = false;
                                }
                        }//while

                        strTempWord = Code.Substring(Index, intIndexCurrent - Index);//ȡ����ʱ�ַ���
                        TokenRecord Token = ProduceToken(strTempWord, Index);
                        TokenList.Add(Token);

                        Index = intIndexCurrent - 1;//ָ���Ƶ���ǰָ���ǰһλ��Ȼ��ֵ��ѭ��ָ��
                }

                /// <summary>
                /// �����ǺŶ���
                /// </summary>
                /// <param name="TokenWord">�����õ��ĵ���</param>
                /// <param name="Index">��ǰ���</param>
                /// <returns>�ǺŶ���</returns>
                /// <remarks>Author:Alex Leo</remarks>
                public new static TokenRecord ProduceToken(string TokenWord, int Index)
                {
                        TokenRecord Token = new TokenValue(Index + 1, TokenWord.Length);
                        Token.TokenValueType = TokenValueTypeEnum.Number;
                        double dblValue;

                        if (double.TryParse(TokenWord, out dblValue))
                        {
                                Token.TokenValue = dblValue;
                        }
                        else
                        {
                                throw new SyntaxException(Index, TokenWord.Length, "���ʽ " + TokenWord + " �޷�ת������ֵ��");
                        }

                        return Token;
                }
        }
}
