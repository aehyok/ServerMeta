using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Expression
{
        /*
        * ErrCode
        * 1001 : 缺少操作符
        * 1002 : 缺少操作数
        * 1003 : 缺少左括号
        * 1004 : 缺少右括号
        * 1999 : 缺少操作符或操作数（经计算后，逆波兰表达式的Token剩下不止1个)
        * 2001 : 函数名无效
        * 2002 : 逗号在函数体外
        * 3001 : 查询表达式里存在不允许的符号       
        */
        public class ExpressionException : Exception
        {
                private int errCode;

                public int ErrCode
                {
                        get { return errCode; }
                        set { errCode = value; }
                }

                public ExpressionException(string message, int errCode)
                        : base(message)
                {
                        this.errCode = errCode;
                }

                public ExpressionException(string message)
                        : base(message)
                {
                }

                public ExpressionException()
                        : base()
                {

                }
        }
}
