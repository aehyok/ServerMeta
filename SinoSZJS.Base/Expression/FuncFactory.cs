using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Expression
{
        public class FuncFactory
        {
                static string[] aryFunc = { "ABS", "SQR", "SQRT", "ROUND", "LOG", "LN", "EXP", "SIN", "COS", "TAN", "COT", "ISNULL" };

                public static FunctionBase GetFunc(string name)
                {
                        switch (name.ToUpper())
                        {
                                case "ABS":
                                        return new FuncABS();
                                case "SQR":
                                        return new FuncSQR();
                                case "SQRT":
                                        return new FuncSQRT();
                                case "ROUND":
                                        return new FuncRound();
                                case "LOG":
                                        return new FuncLog();
                                case "LN":
                                        return new FuncLn();
                                case "EXP":
                                        return new FuncExp();
                                case "SIN":
                                        return new FuncSin();
                                case "COS":
                                        return new FuncCos();
                                case "TAN":
                                        return new FuncTan();
                                case "COT":
                                        return new FuncCot();
                                case "ISNULL":
                                        return new FuncIsNull();
                                default:
                                        return null;
                        }
                }

                public static FunctionBase GetFunc(int index)
                {
                        index -= (int)OperatorType.VARIANT + 1;
                        if (index < 0 || index > aryFunc.Length - 1)
                                return null;
                        return GetFunc(aryFunc[index]);
                }

                public static bool IsValidFunc(string name)
                {
                        return GetFuncIndex(name) != -1;
                }

                public static bool IsValidFunc(int index)
                {
                        index -= (int)OperatorType.VARIANT + 1;
                        if (index < 0 || index > aryFunc.Length - 1)
                                return false;
                        return IsValidFunc(aryFunc[index]);
                }

                public static int GetFuncIndex(string name)
                {
                        int index = Array.IndexOf<string>(aryFunc, name.ToUpper());
                        if (index == -1)
                                return -1;
                        else
                                return index + (int)OperatorType.VARIANT + 1;
                }
        }
}
