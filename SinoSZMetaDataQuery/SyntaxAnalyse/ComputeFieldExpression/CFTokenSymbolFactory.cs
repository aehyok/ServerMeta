using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SyntaxAnalyse.TokenRecord;
using SinoSZJS.Base.SyntaxAnalyse;

namespace SinoSZMetaDataQuery.SyntaxAnalyse.ComputeFieldExpression
{
        public class CFTokenSymbolFactory : ComputeFieldTokenFactory
        {
                private static Dictionary<string, string> symbolDict = null;
                internal static Dictionary<string, string> GetSymbolDictionary()
                {
                        if (symbolDict == null)
                        {
                                InitSymbolDictionary();
                        }
                        return symbolDict;
                }

                private static void InitSymbolDictionary()
                {
                        symbolDict = new Dictionary<string, string>();
                        symbolDict.Add("+", "SinoSZMetaDataQuery.SyntaxAnalyse.ComputeFieldExpression.SymbolToken.TokenPlus");
                        symbolDict.Add("-", "-");
                        symbolDict.Add("*", "*");
                        symbolDict.Add("/", "/");
                }

                public new static void LexicalAnalysis(List<TokenRecord> TokenList, string Code, ref int Index)
                {
                        string strTempWord;

                        strTempWord = Code.Substring(Index, 1);

                        TokenRecord Token = ProduceToken(strTempWord, Index);
                        TokenList.Add(Token);


                }

                /// <summary>
                /// �����ǺŶ���
                /// </summary>
                /// <param name="TokenWord">�����õ��ĵ���</param>
                /// <param name="Index">��ǰ���</param>
                /// <returns>�ǺŶ���</returns>
                /// <remarks>Author:Alex Leo</remarks>
                protected new static TokenRecord ProduceToken(string TokenWord, int Index)
                {
                        TokenRecord Token;

                        if (GetSymbolDictionary().ContainsKey(TokenWord.ToLower()))
                        {
                                string strFullClassName = GetSymbolDictionary()[TokenWord.ToLower()];
                                Type TokenType = Type.GetType(strFullClassName);
                                Token = (TokenRecord)Activator.CreateInstance(TokenType, new object[] { Index, TokenWord.Length });
                        }
                        else
                        {
                                //�����ַ������׳������﷨����
                                throw new SyntaxException(Index, TokenWord.Length, "δ֪���ʽ��" + TokenWord);
                        }

                        return Token;
                }//ProduceToken
        }
}
