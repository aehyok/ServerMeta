using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Expression
{
        /// <summary>
        /// 节点类
        /// </summary>
        public class ExpressionToken
        {
                private TokenType type;

                /// <summary>
                /// 节点类型
                /// </summary>
                public TokenType Type
                {
                        get { return type; }
                        set { type = value; }
                }
                private object data;

                /// <summary>
                /// 节点数据
                /// </summary>
                public object Data
                {
                        get { return data; }
                        set { data = value; }
                }

                /// <summary>
                /// 构造函数
                /// </summary>
                /// <param name="type">节点类型</param>
                /// <param name="data">节点数据</param>
                public ExpressionToken(TokenType type, object data)
                {
                        this.type = type;
                        this.data = data;
                }
        }

        /// <summary>
        /// 节点类型
        /// </summary>
        public enum TokenType
        {
                /// <summary>
                /// 操作数
                /// </summary>
                Numeric,
                /// <summary>
                /// 操作符
                /// </summary>
                Operator
        }
}
