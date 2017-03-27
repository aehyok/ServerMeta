using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SinoSZJS.Base.Expression
{
        public class Expression
        {
                //变量起始标记符
                const char VA_BEGIN = '{';
                const char VA_END = '}';
               

                string strExpression;
                public Expression(string exp)
                {
                        if (exp == null)
                                throw new ArgumentNullException();
                        strExpression = exp;
                }

                private object CalcInner()
                {
                        int index = 0;
                        //存放常数表
                        List<decimal?> digit = new List<decimal?>();
                        //备份表达式
                        List<ExpressionToken> polandCalc = new List<ExpressionToken>(rePoland.Count);
                        for (int i = 0; i < rePoland.Count; i++)
                        {
                                polandCalc.Add(rePoland[i]);
                        }
                        while (index < polandCalc.Count)
                        {
                                if (polandCalc.Count == 1 && polandCalc[0].Type == TokenType.Numeric)
                                        break;
                                ExpressionToken token = polandCalc[index];
                                switch (token.Type)
                                {
                                        case TokenType.Numeric:
                                                if (polandCalc[index].Data == DBNull.Value)
                                                        digit.Add(null);
                                                else
                                                        digit.Add(Convert.ToDecimal(polandCalc[index].Data));
                                                index++;
                                                break;
                                        //case TokenType.Variant:
                                        //    //将变量替换为常量
                                        //    polandCalc[index].Data = GetVariantValue(token);
                                        //    polandCalc[index].Type = TokenType.Numeric;
                                        //    break;
                                        case TokenType.Operator:
                                                int paramCount = 2; //一般是二元式，需要二个参数
                                                //函数
                                                if (IsFunc((OperatorType)token.Data))
                                                {
                                                        FunctionBase func = FuncFactory.GetFunc((int)(OperatorType)token.Data);
                                                        if (func == null)
                                                                throw new ExpressionException("不可识别的函数名.");
                                                        paramCount = func.ParamCount;
                                                }
                                                //计算前面两个数的值
                                                if (digit.Count < paramCount)
                                                {
                                                        throw new ExpressionException("缺少操作数", 1002);
                                                }
                                                //传入参数
                                                decimal?[] data = new decimal?[paramCount];
                                                for (int i = 0; i < paramCount; i++)
                                                {
                                                        data[i] = digit[index - paramCount + i];
                                                }
                                                polandCalc[index - paramCount].Data = CalcOperator((OperatorType)token.Data, data);
                                                //将参数从 repoland 中移除
                                                for (int i = 0; i < paramCount; i++)
                                                {
                                                        polandCalc.RemoveAt(index - i);
                                                        digit.RemoveAt(index - i - 1);
                                                }
                                                index -= paramCount;
                                                break;
                                        default:
                                                break;
                                }
                        }
                        if (polandCalc.Count == 1)
                        {
                                switch (polandCalc[0].Type)
                                {
                                        case TokenType.Numeric:
                                                return polandCalc[0].Data;
                                        default:
                                                throw new ExpressionException("缺少操作数", 1002);
                                }
                        }
                        else
                        {
                                throw new ExpressionException("缺少操作符或操作数", 1002);
                        }
                }

                object GetVariantValue(ExpressionToken token)
                {
                        if (lstVariant.Contains(token.Data))
                        {
                                if (lstVariant[token.Data] == DBNull.Value || lstVariant[token.Data] == null)
                                        return DBNull.Value;
                                else
                                {
                                        try
                                        {
                                                decimal data;
                                                if (decimal.TryParse(lstVariant[token.Data].ToString(), out data))
                                                {
                                                        return data;
                                                }
                                                else
                                                {
                                                        return DBNull.Value;
                                                }
                                        }
                                        catch (Exception)
                                        {
                                                return DBNull.Value;
                                        }
                                }
                        }
                        else
                                throw new ExpressionException("变量未定义值:" + Convert.ToString(token.Data));
                }

                public object Calc()
                {
                        return CalcInner();
                }

                /// <summary>
                /// 计算二元表达式的值
                /// </summary>
                public object CalcOperator(OperatorType op, decimal?[] data)
                {
                        if (IsBaseOperator(op))
                        {
                                decimal? d1 = data[0];
                                decimal? d2 = data[1];
                                if (d1 == null || d2 == null)
                                        return DBNull.Value;
                                switch (op)
                                {
                                        case OperatorType.Plus:
                                                return d1 + d2;
                                        case OperatorType.Subtract:
                                                return d1 - d2;
                                        case OperatorType.MultiPly:
                                                return d1 * d2;
                                        case OperatorType.Divide:
                                                if (d2 == 0)
                                                        throw new DivideByZeroException();
                                                return d1 / d2;
                                        case OperatorType.Power://幂运算
                                                return Math.Pow((double)d1, (double)d2);
                                }
                        }
                        else if (IsFunc(op))
                        {
                                FunctionBase func = FuncFactory.GetFunc((int)op);
                                if (func == null)
                                        throw new ExpressionException("不可识别的函数名.");
                                else
                                {
                                        func.Data = data;
                                        try
                                        {
                                                return func.Calc();
                                        }
                                        catch (Exception ex)
                                        {
                                                throw new ExpressionException("函数计算出错:" + ex.Message, 9000);
                                        }
                                }
                        }
                        return 0;
                }

                bool needOp = false;
                bool needParentheses = false;//前一个操作符是函数，所以下一个操作符必须是左括号
                bool needDigit = false; //前一个操作符是 -（负号），所以下一个操作符必须是数字
                OperatorType curOp = OperatorType.Plus;
                List<ExpressionToken> rePoland = new List<ExpressionToken>();
                //储存操作符
                Stack<OperatorType> stackOp = new Stack<OperatorType>();

                /// <summary>
                /// 将算术表达式转换为逆波兰表达式
                /// </summary>
                public void ConvertExpression()
                {
                        #region for

                        for (int i = 0; i < strExpression.Length; i++)
                        {
                                char c = strExpression[i];
                                if (needDigit && !char.IsDigit(c))
                                        throw new ExpressionException("一元操作符(+,-)后面必须紧跟数字");
                                if (char.IsWhiteSpace(c))
                                        continue;
                                //如果前一个操作符是函数，则此处必须为括号
                                if (needParentheses && c != '(')
                                        throw new ExpressionException("缺少函数的左括号", 1003);
                                switch (c)
                                {
                                        //+-即可为二元操作符，也可为一元操作符
                                        case '+':
                                                curOp = OperatorType.Plus;
                                                if (!needOp)
                                                {
                                                        needDigit = true;
                                                        stackOp.Push(curOp);
                                                        continue;
                                                }
                                                ProcOperator(i, curOp);
                                                break;
                                        case '-':
                                                curOp = OperatorType.Subtract;
                                                if (!needOp)
                                                {
                                                        needDigit = true;
                                                        stackOp.Push(curOp);
                                                        continue;
                                                }
                                                ProcOperator(i, curOp);
                                                break;
                                        case '*':
                                                curOp = OperatorType.MultiPly;
                                                ProcOperator(i, curOp);
                                                break;
                                        case '/':
                                                curOp = OperatorType.Divide;
                                                ProcOperator(i, curOp);
                                                break;
                                        case '^':
                                                curOp = OperatorType.Power;
                                                ProcOperator(i, curOp);
                                                break;
                                        case '(':
                                                curOp = OperatorType.L_Parentheses;
                                                ProcParentheses(i, curOp);
                                                break;
                                        case ')':
                                                curOp = OperatorType.R_Parentheses;
                                                ProcParentheses(i, curOp);
                                                break;
                                        case ',':
                                                ProcComma(i);
                                                break;
                                        case VA_BEGIN:
                                                curOp = OperatorType.VARIANT;
                                                i++;
                                                ProcVariant(ref i, ref strExpression);
                                                break;
                                        default:
                                                //数字
                                                if (char.IsDigit(c))
                                                {
                                                        ProcDigit(ref i, ref strExpression);
                                                }
                                                else //其它的字符全当成函数
                                                {
                                                        ProcFunc(ref i, ref strExpression);
                                                }
                                                break;
                                }
                        }
                        #endregion
                        if (!needOp)
                        {
                                //最后一个操作符必须是数字或变量
                                throw new ExpressionException("缺少操作数", 1002);
                        }
                        while (stackOp.Count > 0)
                        {
                                if (stackOp.Peek() == OperatorType.L_Parentheses)
                                        throw new ExpressionException("括号不匹配(缺少右括号)", 1004);
                                rePoland.Add(new ExpressionToken(TokenType.Operator, stackOp.Pop()));
                        }
                }


                /// <summary>
                /// 处理逗号
                /// </summary>
                /// <param name="i"></param>
                /// <param name="curOp"></param>
                private void ProcComma(int index)
                {
                        //逗号必须在函数体内
                        //往前回溯到有括号的地方，再判断是否是函数
                        Stack<OperatorType> stackBk = new Stack<OperatorType>();
                        bool find = false;
                        bool valid = false; //是否合法
                        OperatorType opBk;
                        while (stackOp.Count > 0)
                        {
                                opBk = stackOp.Pop();
                                stackBk.Push(opBk);
                                if (opBk == OperatorType.L_Parentheses)
                                {
                                        find = true;
                                        break;
                                }
                        }
                        if (find)
                        {
                                if (stackOp.Count > 0)
                                {
                                        //前一个是否为函数
                                        opBk = stackOp.Pop();
                                        stackBk.Push(opBk);
                                        if (IsFunc(opBk))
                                        {
                                                valid = true;
                                        }
                                }
                        }
                        //将栈还原
                        while (stackBk.Count > 0)
                        {
                                stackOp.Push(stackBk.Pop());
                        }

                        if (!valid)
                                throw new ExpressionException("逗号不允许出现在函数体外.", 2001);
                        else
                        {
                                needOp = false;
                                stackOp.Push(OperatorType.Comma);
                        }
                }

                /// <summary>
                /// 比较两个操作符的优先级
                /// </summary>
                public int PRI(OperatorType op1, OperatorType op2)
                {
                        return (int)op1 - (int)op2;
                }

                public void ProcOperator(int index, OperatorType op)
                {
                        if (!needOp)
                                throw new ExpressionException("缺少操作数", 1002);
                        if (stackOp.Count > 0)
                        {
                                while (stackOp.Count > 0)
                                {
                                        OperatorType opPrev = stackOp.Peek();
                                        if (!IsBaseOperator(opPrev) || PRI(opPrev, op) < 0)
                                                break;
                                        //计算前一个表达式
                                        rePoland.Add(new ExpressionToken(TokenType.Operator, opPrev));
                                        stackOp.Pop();
                                }
                                stackOp.Push(op);
                        }
                        else
                        {
                                stackOp.Push(op);
                        }
                        needOp = false;
                }

                private bool IsBaseOperator(OperatorType op)
                {
                        return (int)op < 5;
                }

                private bool IsFunc(OperatorType op)
                {
                        return (int)op > (int)OperatorType.VARIANT;
                }

                public void ProcParentheses(int index, OperatorType op)
                {
                        if (op == OperatorType.L_Parentheses) //左括号
                        {
                                needOp = false;
                                needParentheses = false;
                                stackOp.Push(op);
                        }
                        else if (op == OperatorType.R_Parentheses) //右括号
                        {
                                bool find = false;
                                //如果是函数，则此处为函数的参数个数
                                //通过统计逗号的个数得出参数的个数
                                int funcParam = 1;
                                while (stackOp.Count > 0)
                                {
                                        if (stackOp.Peek() != OperatorType.L_Parentheses)
                                        {
                                                OperatorType opPop = stackOp.Pop();
                                                if (opPop == OperatorType.Comma)
                                                {
                                                        funcParam++;
                                                }
                                                else
                                                        rePoland.Add(new ExpressionToken(TokenType.Operator, opPop));
                                        }
                                        else
                                        {
                                                stackOp.Pop();
                                                find = true;
                                                break;
                                        }
                                }
                                if (!find)
                                        throw new ExpressionException("括号不匹配.(缺少左括号)", 1003);
                                //如果再前一个是函数，也要加到 rePoland 中
                                if (stackOp.Count > 0)
                                {
                                        OperatorType opPrev = stackOp.Peek();
                                        if (IsFunc(opPrev))
                                        {
                                                //先判断函数的参数个数是否正确
                                                FunctionBase func = FuncFactory.GetFunc((int)opPrev);
                                                if (func.ParamCount != funcParam)
                                                        throw new ExpressionException("函数(" + func.Name + ")参数个数不正确\n"
                                                            + "应为" + func.ParamCount + "个,"
                                                            + "实为" + funcParam + "个");
                                                rePoland.Add(new ExpressionToken(TokenType.Operator, stackOp.Pop()));
                                        }
                                }
                        }
                }

                public void ProcDigit(ref int index, ref string expression)
                {
                        if (needOp)
                                throw new ExpressionException("缺少操作符", 1001);

                        StringBuilder str = new StringBuilder();
                        for (int i = index; i < expression.Length; i++)
                        {
                                char c = expression[i];
                                if (char.IsDigit(c) || c == '.')
                                        str.Append(c);
                                else
                                {
                                        break;
                                }
                                index = i;
                        }
                        needOp = true;
                        decimal data = Convert.ToDecimal(str.ToString());
                        //如果前一个是一元操作符(-) 负号，则须对数值进行处理
                        if (needDigit)
                        {
                                if (stackOp.Pop() == OperatorType.Subtract)
                                        data = -data;
                                needDigit = false;
                        }
                        rePoland.Add(new ExpressionToken(TokenType.Numeric
                            , data));
                }

                private void ProcFunc(ref int index, ref string expression)
                {
                        if (needOp)
                                throw new ExpressionException("缺少操作符", 1001);

                        StringBuilder str = new StringBuilder();
                        for (int i = index; i < expression.Length; i++)
                        {
                                char c = expression[i];
                                if (char.IsWhiteSpace(c) || c == '(')
                                {
                                        this.needParentheses = true;
                                        break;
                                }
                                else
                                {
                                        str.Append(c);
                                }
                                index = i;
                        }
                        string strFunc = str.ToString();
                        //函数是否正确
                        if (!FuncFactory.IsValidFunc(strFunc))
                                throw new ExpressionException("函数名无效:" + strFunc, 2001);
                        else
                                stackOp.Push((OperatorType)FuncFactory.GetFuncIndex(strFunc));
                }

                private void ProcVariant(ref int index, ref string expression)
                {
                        if (needOp)
                                throw new ExpressionException("缺少操作符", 1001);

                        StringBuilder str = new StringBuilder();
                        bool match = false; //括号是否匹配
                        for (int i = index; i < expression.Length; i++)
                        {
                                char c = expression[i];
                                if (c != VA_END)   //变量内只认 } 为结束符
                                        str.Append(c);
                                else
                                {
                                        match = true;
                                        break;
                                }
                                index = i;
                        }
                        if (!match)
                                throw new ExpressionException("变量括号不匹配(缺少终止符'}')", 2001);
                        index++;
                        needOp = true;
                        //rePoland.Add(new ExpressionToken(TokenType.Variant
                        //    , str.ToString()));
                }

                private Hashtable lstVariant = new Hashtable();

                /// <summary>
                /// 设置参数的值
                /// </summary>
                public void SetVariantValue(string key, object data)
                {
                        lstVariant[key] = data;
                }
        }
}
