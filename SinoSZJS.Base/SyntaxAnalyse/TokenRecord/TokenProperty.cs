using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse.TokenRecord
{
        /// <summary>
        /// 记号值类型枚举
        /// </summary>
        /// <remarks>Author:Alex Leo;</remarks>
        public enum TokenValueTypeEnum
        {
                /// <summary>
                /// 未知
                /// </summary>
                Unknow,
                /// <summary>
                /// 字符串值类型
                /// </summary>
                String,
                /// <summary>
                /// 数字值类型
                /// </summary>
                Number,
                /// <summary>
                /// 日期
                /// </summary>
                Date
        }

        /// <summary>
        /// 操作记号类型枚举
        /// </summary>
        /// <remarks>Author:Alex Leo;</remarks>
        public enum OperateTokenTypeEnum
        {
                /// <summary>
                /// 关键字
                /// </summary>
                TokenKeyword,
                /// <summary>
                /// 符号
                /// </summary>
                TokenSymbol,
                /// <summary>
                /// 变量
                /// </summary>
                TokenVariable
        }

        /// <summary>
        /// 记号属性
        /// </summary>
        public class TokenProperty
        {
                #region 属性和字段

                //下级个数
                protected int m_ChildCount;
                public int ChildCount
                {
                        get { return m_ChildCount; }
                        set { m_ChildCount = value; }
                }

                /// <summary>
                /// 优先级，必须赋值
                /// </summary>
                protected int m_Priority;
                /// <summary>
                /// 优先级
                /// </summary>
                /// <returns></returns>
                public int Priority
                {
                        get
                        {
                                return m_Priority;
                        }
                        set
                        {
                                m_Priority = value;
                        }
                }


                protected TokenValueTypeEnum m_TokenValueType;
                /// <summary>
                /// 记号值类型
                /// </summary>
                public TokenValueTypeEnum TokenValueType
                {
                        get { return m_TokenValueType; }
                        set { m_TokenValueType = value; }
                }

                protected List<TokenValueTypeEnum> m_ChildNeedValueType;
                /// <summary>
                /// 下级需要的字段类型
                /// </summary>
                public List<TokenValueTypeEnum> ChildNeedValueType
                {
                        get
                        {
                                return m_ChildNeedValueType;
                        }
                        set
                        {
                                m_ChildNeedValueType = value;
                        }
                }

                #endregion

                public TokenProperty() { }

                public TokenProperty(int _priority, int _childCount, TokenValueTypeEnum _valueType)
                {
                        this.m_Priority = _priority;
                        this.m_ChildCount = _childCount;
                        this.m_TokenValueType = _valueType;
                }
        }
}
