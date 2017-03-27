using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Expression
{
        public enum OperatorType
        {
                Plus, //"+",
                Subtract,//  "-",
                MultiPly,//  "*",
                Divide, //"/",
                Power, //^
                L_Parentheses,// (
                R_Parentheses, // )
                Comma,  //逗号
                VARIANT,    //变量
                ABS,
                SQR,
                SQRT,
                ROUND,
                LOG,
                LN,
                EXP,
                SIN,
                COS,
                TAN,
                COT,
                ISNULL,
                NOT,
                AND,
                OR
        }
}
