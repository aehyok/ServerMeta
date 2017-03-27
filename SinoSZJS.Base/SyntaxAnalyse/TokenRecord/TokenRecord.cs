using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse.TokenRecord
{


        public abstract class TokenRecord
        {
                #region ���Ժ��ֶ�

                //����
                protected TokenProperty m_Property;



                private int m_Index=0;
                /// <summary>
                /// �����
                /// </summary>
                public int Index
                {
                        get
                        {
                                return m_Index;
                        }
                }


                /// <summary>
                /// ���ȼ�
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
                /// ����������
                /// </summary>
                public int Length
                {
                        get { return m_Length; }
                }



                /// <summary>
                /// �Ǻ�ֵ����
                /// </summary>
                virtual public TokenValueTypeEnum TokenValueType
                {
                        get { return m_Property.TokenValueType; }
                        set { m_Property.TokenValueType = value; }
                }

                private object m_TokenValue;
                /// <summary>
                /// �Ǻ�ֵ
                /// </summary>
                public object TokenValue
                {
                        get { return m_TokenValue; }
                        set { m_TokenValue = value; }
                }


                private List<TokenRecord> m_ChildList = new List<TokenRecord>();
                /// <summary>
                /// �¼��б�
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
                #region ����

                /// <summary>
                /// ��дToString����
                /// </summary>
                /// <returns></returns>
                public override string ToString()
                {
                        return this.GetType().Name + "_" + GetValueString() + "_" + TokenValueType.ToString();
                }

                /// <summary>
                /// ��ȡֵ���ַ�����ʾ
                /// </summary>
                /// <returns></returns>
                public string GetValueString()
                {
                        return this.TokenValue.ToString();
                }

                /// <summary>
                /// ����¼���������Ҫʱ������д����Ϊ��ЩToken���¼�����������һ������
                /// </summary>
                /// <param name="ErrorInformation">�¼���������ʱ��ʾ�Ĵ�����Ϣ</param>
                internal bool CheckChildCount(ref string ErrorInformation)
                {
                        
                        return true;
                }


                #region ������д�ķ���

                /// <summary>
                /// �����¼�����
                /// </summary>
                protected abstract void SetChildCount();

                /// <summary>
                /// �������ȼ�
                /// </summary>
                protected abstract void SetPriority();


                #endregion

                #endregion


        }
}
