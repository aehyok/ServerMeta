using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse.TokenRecord
{


        public abstract class TokenRecord
        {
                #region 属性和字段

                //属性
                protected TokenProperty m_Property;



                private int m_Index=0;
                /// <summary>
                /// 列序号
                /// </summary>
                public int Index
                {
                        get
                        {
                                return m_Index;
                        }
                }


                /// <summary>
                /// 优先级
                /// </summary>
                /// <returns></returns>
                public int Priority
                {
                        get
                        {
                                return m_Property.Priority;
                        }
                }

                private int m_Length=0;
                /// <summary>
                /// 操作符长度
                /// </summary>
                public int Length
                {
                        get { return m_Length; }
                }



                /// <summary>
                /// 记号值类型
                /// </summary>
                virtual public TokenValueTypeEnum TokenValueType
                {
                        get { return m_Property.TokenValueType; }
                        set { m_Property.TokenValueType = value; }
                }

                private object m_TokenValue;
                /// <summary>
                /// 记号值
                /// </summary>
                public object TokenValue
                {
                        get { return m_TokenValue; }
                        set { m_TokenValue = value; }
                }


                private List<TokenRecord> m_ChildList = new List<TokenRecord>();
                /// <summary>
                /// 下级列表
                /// </summary>
                public List<TokenRecord> ChildList
                {
                        get
                        {
                                return m_ChildList;
                        }
                        set
                        {
                                m_ChildList = value;
                        }
                }


                public List<TokenValueTypeEnum> ChildNeedValueType
                {
                        get
                        {
                                return m_Property.ChildNeedValueType;
                        }
                }
                #endregion


                public TokenRecord() { }
                public TokenRecord(int Index, int Length)
                {
                        m_Property = new TokenProperty();
                        SetChildCount();
                        SetPriority();
                }

                public TokenRecord(int Index, int Length, TokenProperty _property)
                {
                        SetChildCount();
                        SetPriority();
                        m_Property = _property;
                }
                #region 方法

                /// <summary>
                /// 重写ToString方法
                /// </summary>
                /// <returns></returns>
                public override string ToString()
                {
                        return this.GetType().Name + "_" + GetValueString() + "_" + TokenValueType.ToString();
                }

                /// <summary>
                /// 获取值的字符串表示
                /// </summary>
                /// <returns></returns>
                public string GetValueString()
                {
                        return this.TokenValue.ToString();
                }

                /// <summary>
                /// 检查下级数量，必要时可以重写，因为有些Token的下级数量可以是一个区间
                /// </summary>
                /// <param name="ErrorInformation">下级数量不符时显示的错误信息</param>
                internal bool CheckChildCount(ref string ErrorInformation)
                {
                        
                        return true;
                }


                #region 必须重写的方法

                /// <summary>
                /// 设置下级数量
                /// </summary>
                protected abstract void SetChildCount();

                /// <summary>
                /// 设置优先级
                /// </summary>
                protected abstract void SetPriority();


                #endregion

                #endregion


        }
}
