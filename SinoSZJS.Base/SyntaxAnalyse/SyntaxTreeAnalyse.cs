using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse
{
        /// <summary>
        /// �﷨������
        /// </summary>
        /// <remarks>Author:Alex Leo</remarks>
        public class SyntaxTreeAnalyse
        {
                /// <summary>
                /// �ǺŶ���ȡ����ȡ���������Ǻŵ�Hash
                /// </summary>
                /// <param name="IndexStart">��ʼ���</param>
                /// <param name="IndexEnd">�������</param>
                /// <returns>����ǺŶεĶ��������Ǻż�¼�����Hash</returns>
                /// <remarks>Author:Alex Leo</remarks>
                public static TokenRecord.TokenRecord SyntaxTreeGetTopTokenAnalyse(List<TokenRecord.TokenRecord> TokenList, int IndexStart, int IndexEnd)
                {
                        int intIndexCurrent = IndexStart;//��ǰ�������
                        int intIndexSubStart = IndexStart;//�ӼǺŶε���ʼ���
                        TokenRecord.TokenRecord Token;//��ȡ��ǰToken
                        Stack<TokenRecord.TokenRecord> StackCompart = new Stack<TokenRecord.TokenRecord>();//���Ŷ�ջ
                        Stack<TokenRecord.TokenRecord> StackOperate = new Stack<TokenRecord.TokenRecord>();//�����ǺŶ�ջ

                        for (int intIndex = IndexStart; intIndex <= IndexEnd; intIndex++)
                        {
                                Token = TokenList[intIndex];
                                intIndexCurrent = intIndex;

                                SyntaxTreeStackAnalyse(StackOperate, Token);

                        }
                        return SyntaxTreeStackGetTopToken(StackOperate);//���ض����Ǻ�Hash
                }



                /// <summary>
                /// �﷨����ջ���������ڼǺŵ����ȼ�
                /// </summary>
                /// <param name="SyntaxTreeStack">�﷨����ջ</param>
                /// <param name="NewToken">�¼Ǻ�</param>
                /// <remarks>Author:Alex Leo</remarks>
                private static void SyntaxTreeStackAnalyse(Stack<TokenRecord.TokenRecord> SyntaxTreeStack, TokenRecord.TokenRecord NewToken)
                {
                        if (SyntaxTreeStack.Count == 0)//����﷨����ջ�в����ڼǺţ���ֱ��ѹջ
                        {
                                SyntaxTreeStack.Push(NewToken);
                        }
                        else//���򣬱Ƚ����ȼ�����ջ����
                        {
                                //�Ƚ����ȼ��������Token���ȼ��ߣ���ѹջ��
                                //�����Token���ȼ��ͣ���ջ���ѵ�����Token����Ϊ��Token���¼���������Tokenѹջ��
                                //��ͬ���ȼ�Ҳ��ջ��������Tokenѹջ
                                //if (this.m_DicTokenTypePriority[SyntaxTreeStack.Peek().TokenType] < this.m_DicTokenTypePriority[NewToken.TokenType])//�ͽ�
                                if (SyntaxTreeStack.Peek().Priority < NewToken.Priority)//�ͽ�
                                {
                                        SyntaxTreeStack.Push(NewToken);//�ͽ�
                                }
                                else
                                {
                                        TokenRecord.TokenRecord TempToken = null;
                                        //�����ջ���мǺţ�����ջ���ļǺ����ȼ����ڵ����¼Ǻŵ����ȼ����������ջ
                                        while (SyntaxTreeStack.Count > 0 && (SyntaxTreeStack.Peek().Priority >= NewToken.Priority))
                                        {
                                                TempToken = SyntaxTreeStack.Pop();
                                                if (SyntaxTreeStack.Count > 0)//���ջ���Ƿ����Ϊ�գ����Ϊ�����˳�
                                                {
                                                        if (SyntaxTreeStack.Peek().Priority >= NewToken.Priority)
                                                        {
                                                                SyntaxTreeStack.Peek().ChildList.Add(TempToken);
                                                        }
                                                        else
                                                        {
                                                                NewToken.ChildList.Add(TempToken);
                                                        }
                                                }
                                                else
                                                {
                                                        NewToken.ChildList.Add(TempToken);
                                                }
                                        }
                                        SyntaxTreeStack.Push(NewToken);//ѹջ
                                }
                        }
                }


                /// <summary>
                /// ��ȡ�﷨����ջ�Ķ����Ǻ�
                /// </summary>
                /// <param name="SyntaxTreeStack">�﷨����ջ</param>
                /// <returns>�����Ǻ�Hash</returns>
                /// <remarks>Author:Alex Leo</remarks>
                private static TokenRecord.TokenRecord SyntaxTreeStackGetTopToken(Stack<TokenRecord.TokenRecord> SyntaxTreeStack)
                {
                        TokenRecord.TokenRecord TempToken = null;
                        if (SyntaxTreeStack.Count > 0)
                        {
                                TempToken = SyntaxTreeStack.Pop();
                                while (SyntaxTreeStack.Count > 0)
                                {
                                        SyntaxTreeStack.Peek().ChildList.Add(TempToken);
                                        TempToken = SyntaxTreeStack.Pop();
                                }
                        }
                        return TempToken;
                }

        }
}
