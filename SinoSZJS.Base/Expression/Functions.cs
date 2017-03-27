using System;
using System.Collections.Generic;
using System.Text;


/*
 * 添加函数需要注意：
 * 1. 必须继承自 FunctionBase
 * 2. 参数个数须设置正确
 * 2. 函数工厂 FuncFactory 中修改 GetFunc函数和 aryFunc 数组
 * 3. 修改操作符枚举值 OperatorType
 * */


namespace SinoSZJS.Base.Expression
{
        /// <summary>
        /// 绝对值
        /// </summary>
        public class FuncABS : FunctionBase
        {
                public FuncABS()
                {
                        paramCount = 1;
                        name = "ABS";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return Math.Abs((decimal)data[0]);
                }
        }

        /// <summary>
        /// 平方
        /// </summary>
        public class FuncSQR : FunctionBase
        {
                public FuncSQR()
                {
                        paramCount = 1;
                        name = "SQR";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return data[0] * data[0];
                }
        }

        /// <summary>
        /// 开平方
        /// </summary>
        public class FuncSQRT : FunctionBase
        {
                public FuncSQRT()
                {
                        //参数名称和参数个数一定要设置正确
                        //否则在解析的时候会出错
                        paramCount = 1;
                        name = "SQRT";
                }
                /// <summary>
                /// 计算
                /// 函数类实现这一步就行了， 简单吧
                /// </summary>
                /// <returns></returns>
                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return Math.Sqrt((double)data[0]);
                }
        }

        /// <summary>
        /// 小数取整
        /// </summary>
        public class FuncRound : FunctionBase
        {
                public FuncRound()
                {
                        paramCount = 2;
                        name = "ROUND";
                }

                public override object Calc()
                {
                        if (data[0] == null || data[1] == null)
                                return DBNull.Value;
                        return Math.Round((double)data[0], (int)data[1]);
                }
        }

        /// <summary>
        /// 对数
        /// </summary>
        public class FuncLog : FunctionBase
        {
                public FuncLog()
                {
                        paramCount = 2;
                        name = "LOG";
                }

                public override object Calc()
                {
                        if (data[0] == null || data[1] == null)
                                return DBNull.Value;
                        return (decimal)Math.Log((double)data[0], (double)data[1]);
                }
        }

        /// <summary>
        /// 10为底的对数
        /// </summary>
        public class FuncLn : FunctionBase
        {
                public FuncLn()
                {
                        paramCount = 1;
                        name = "LN";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return (decimal)Math.Log((double)data[0]);
                }
        }

        /// <summary>
        /// 指数函数
        /// </summary>
        public class FuncExp : FunctionBase
        {
                public FuncExp()
                {
                        paramCount = 1;
                        name = "EXP";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return (decimal)Math.Exp((double)data[0]);
                }
        }

        /// <summary>
        /// 正弦
        /// </summary>
        public class FuncSin : FunctionBase
        {
                public FuncSin()
                {
                        paramCount = 1;
                        name = "EXP";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return (decimal)Math.Sin(ConvertAngleToRad((double)data[0]));
                }
        }

        /// <summary>
        /// 余弦
        /// </summary>
        public class FuncCos : FunctionBase
        {
                public FuncCos()
                {
                        paramCount = 1;
                        name = "COS";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return (decimal)Math.Cos(ConvertAngleToRad((double)data[0]));
                }
        }

        /// <summary>
        /// 正切
        /// </summary>
        public class FuncTan : FunctionBase
        {
                public FuncTan()
                {
                        paramCount = 1;
                        name = "TAN";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return (decimal)Math.Tan(ConvertAngleToRad((double)data[0]));
                }
        }

        /// <summary>
        /// 余切
        /// </summary>
        public class FuncCot : FunctionBase
        {
                public FuncCot()
                {
                        paramCount = 1;
                        name = "COT";
                }

                public override object Calc()
                {
                        if (data[0] == null)
                                return DBNull.Value;
                        return 1m / (decimal)Math.Tan(ConvertAngleToRad((double)data[0]));
                }
        }

        /// <summary>
        /// IsNull
        /// </summary>
        public class FuncIsNull : FunctionBase
        {
                public FuncIsNull()
                {
                        paramCount = 2;
                        name = "ISNULL";
                }

                public override object Calc()
                {
                        if (data[1] == null)
                                return DBNull.Value;
                        if (data[0] == null)
                                return data[1];
                        else
                                return data[0];
                }
        }
}
