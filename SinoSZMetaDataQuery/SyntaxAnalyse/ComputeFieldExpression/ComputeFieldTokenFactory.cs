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
                        char chrTemp;//��ʱ�ַ�

                        for (int intIndex = 0; intIndex < Code.Length; intIndex++)
                        {
                                chrTemp = Code[intIndex];//��ȡ��ǰ�ַ�

                                //�ؼ��ַ���
                                if (char.IsLetter(chrTemp))//�����ǰ�ַ�Ϊ��ĸ�����йؼ��ִ���
                                {
                                        //CFTokenKeywordFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if ( chrTemp.Equals('\''))//������ַ����ָ����������ַ�������
                                {
                                        //CFTokenStringFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if (char.IsDigit(chrTemp))//��ֵ����
                                {
                                        CFTokeyNumberFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if (CFTokenSymbolFactory.GetSymbolDictionary().ContainsKey(chrTemp.ToString()))//���������
                                {
                                    //��Щ�����Ϊ˫�ַ������������е�˫�ַ��������ǰһ���ַ����ж�Ӧ�ĵ��ַ������������ֻ����һ���ַ�
                                    CFTokenSymbolFactory.LexicalAnalysis(TokenList, Code, ref intIndex);
                                }
                                else if (chrTemp.Equals(' '))
                                {
                                        //����ǿո�����Բ�����
                                }
                                else//������
                                {
                                        //�׳�����
                                        throw new SyntaxException(intIndex, 1, "�������Ϸ��ַ���" + chrTemp.ToString());
                                }
                        }

                }
        }
}
