using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Expression
{
        /// <summary>
        /// 函数基类
        /// </summary>
        public abstract class FunctionBase
        {
                protected string name;
                /// <summary>
                /// 函数名称
                /// </summary>
                public string Name
                {
                        get { return name; }
                        set { name = value; }
                }
                protected decimal?[] data;
                /// <summary>
                /// 参数数组(储存传入的参数)
                /// </summary>
                public decimal?[] Data
                {
                        get { return data; }
                        set { data = value; }
                }
                protected int paramCount;
                /// <summary>
                /// 指明参数的个数
                /// </summary>
                public int ParamCount
                {
                        get { return paramCount; }
                }

                protected FunctionBase()
                {
                }

                /// <summary>
                /// 计算（定义为虚函数）
                /// </summary>
                /// <returns></returns>
                public abstract object Calc();

                /// <summary>
                /// 角度转弧度
                /// </summary>
                /// <param name="angle">角度</param>
                /// <returns></returns>
                protected double ConvertAngleToRad(double angle)
                {
                        return Math.PI * angle / 180d;
                }
        }
}
