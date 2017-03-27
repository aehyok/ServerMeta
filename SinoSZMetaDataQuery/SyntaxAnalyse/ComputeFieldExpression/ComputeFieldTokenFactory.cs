using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SyntaxAnalyse.TokenRecord;
using SinoSZJS.Base.SyntaxAnalyse;

namespace SinoSZMetaDataQuery.SyntaxAnalyse.ComputeFieldExpression
{
        public class ComputeFieldTokenFactory
        {
                internal static void LexicalAnalysis(List<TokenRecord> TokenList, string Code, ref int Index)
                {
                        char chrTemp;//临时字符

                        for (int intIndex = 0; intIndex < Code.Length; intIndex++)
                        {
                                chrTemp = Code[intIndex];//获取当前字符

                                //关键字分析
                                if (char.IsLetter(chrTemp))//如果当前字符为字母，进行关键字处理
                                {
                                        //CFTokenKeywordFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if ( chrTemp.Equals('\''))//如果是字符串分隔符，进行字符串处理
                                {
                                        //CFTokenStringFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if (char.IsDigit(chrTemp))//数值处理
                                {
                                        CFTokeyNumberFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if (CFTokenSymbolFactory.GetSymbolDictionary().ContainsKey(chrTemp.ToString()))//运算符处理
                                {
                                    //有些运算符为双字符，但这里所有的双字符运算符的前一个字符都有对应的单字符运算符，可以只考虑一个字符
                                    CFTokenSymbolFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if (chrTemp.Equals(' '))
                                {
                                        //如果是空格，则忽略不处理
                                }
                                else//错误处理
                                {
                                        //抛出错误
                                        throw new SyntaxException(intIndex, 1, "包含不合法字符：" + chrTemp.ToString());
                                }
                        }

                }
        }
}
