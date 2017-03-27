using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse
{
        /// <summary>
        /// 语法树分析
        /// </summary>
        /// <remarks>Author:Alex Leo</remarks>
        public class SyntaxTreeAnalyse
        {
                /// <summary>
                /// 记号段提取，提取顶级操作记号的Hash
                /// </summary>
                /// <param name="IndexStart">起始序号</param>
                /// <param name="IndexEnd">结束序号</param>
                /// <returns>传入记号段的顶级操作记号记录对象的Hash</returns>
                /// <remarks>Author:Alex Leo</remarks>
                public static TokenRecord.TokenRecord SyntaxTreeGetTopTokenAnalyse(List<TokenRecord.TokenRecord> TokenList, int IndexStart, int IndexEnd)
                {
                        int intIndexCurrent = IndexStart;//当前处理序号
                        int intIndexSubStart = IndexStart;//子记号段的起始序号
                        TokenRecord.TokenRecord Token;//获取当前Token
                        Stack<TokenRecord.TokenRecord> StackCompart = new Stack<TokenRecord.TokenRecord>();//括号堆栈
                        Stack<TokenRecord.TokenRecord> StackOperate = new Stack<TokenRecord.TokenRecord>();//操作记号堆栈

                        for (int intIndex = IndexStart; intIndex <= IndexEnd; intIndex++)
                        {
                                Token = TokenList[intIndex];
                                intIndexCurrent = intIndex;

                                SyntaxTreeStackAnalyse(StackOperate, Token);

                        }
                        return SyntaxTreeStackGetTopToken(StackOperate);//返回顶级记号Hash
                }



                /// <summary>
                /// 语法树堆栈分析，基于记号的优先级
                /// </summary>
                /// <param name="SyntaxTreeStack">语法树堆栈</param>
                /// <param name="NewToken">新记号</param>
                /// <remarks>Author:Alex Leo</remarks>
                private static void SyntaxTreeStackAnalyse(Stack<TokenRecord.TokenRecord> SyntaxTreeStack, TokenRecord.TokenRecord NewToken)
                {
                        if (SyntaxTreeStack.Count == 0)//如果语法树堆栈中不存在记号，则直接压栈
                        {
                                SyntaxTreeStack.Push(NewToken);
                        }
                        else//否则，比较优先级进行栈操作
                        {
                                //比较优先级，如果新Token优先级高，则压栈；
                                //如果新Token优先级低，则弹栈，把弹出的Token设置为新Token的下级，并把新Token压栈；
                                //相同优先级也弹栈，并将新Token压栈
                                //if (this.m_DicTokenTypePriority[SyntaxTreeStack.Peek().TokenType] < this.m_DicTokenTypePriority[NewToken.TokenType])//低进
                                if (SyntaxTreeStack.Peek().Priority < NewToken.Priority)//低进
                                {
                                        SyntaxTreeStack.Push(NewToken);//低进
                                }
                                else
                                {
                                        TokenRecord.TokenRecord TempToken = null;
                                        //如果堆栈中有记号，并且栈顶的记号优先级大于等于新记号的优先级，则继续弹栈
                                        while (SyntaxTreeStack.Count > 0 && (SyntaxTreeStack.Peek().Priority >= NewToken.Priority))
                                        {
                                                TempToken = SyntaxTreeStack.Pop();
                                                if (SyntaxTreeStack.Count > 0)//检测栈顶是否可能为空，如果为空则退出
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
                                        SyntaxTreeStack.Push(NewToken);//压栈
                                }
                        }
                }


                /// <summary>
                /// 获取语法树堆栈的顶级记号
                /// </summary>
                /// <param name="SyntaxTreeStack">语法树堆栈</param>
                /// <returns>顶级记号Hash</returns>
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
