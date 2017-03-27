using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse.TokenRecord
{
        /// <summary>
        /// �Ǻ�ֵ����ö��
        /// </summary>
        /// <remarks>Author:Alex Leo;</remarks>
        public enum TokenValueTypeEnum
        {
                /// <summary>
                /// δ֪
                /// </summary>
                Unknow,
                /// <summary>
                /// �ַ���ֵ����
                /// </summary>
                String,
                /// <summary>
                /// ����ֵ����
                /// </summary>
                Number,
                /// <summary>
                /// ����
                /// </summary>
                Date
        }

        /// <summary>
        /// �����Ǻ�����ö��
        /// </summary>
        /// <remarks>Author:Alex Leo;</remarks>
        public enum OperateTokenTypeEnum
        {
                /// <summary>
                /// �ؼ���
                /// </summary>
                TokenKeyword,
                /// <summary>
                /// ����
                /// </summary>
                TokenSymbol,
                /// <summary>
                /// ����
                /// </summary>
                TokenVariable
        }

        /// <summary>
        /// �Ǻ�����
        /// </summary>
        public class TokenProperty
        {
                #region ���Ժ��ֶ�

                //�¼�����
                protected int m_ChildCount;
                public int ChildCount
                {
                        get { return m_ChildCount; }
                        set { m_ChildCount = value; }
                }

                /// <summary>
                /// ���ȼ������븳ֵ
                /// </summary>
                protected int m_Priority;
                /// <summary>
                /// ���ȼ�
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
                /// �Ǻ�ֵ����
                /// </summary>
                public TokenValueTypeEnum TokenValueType
                {
                        get { return m_TokenValueType; }
                        set { m_TokenValueType = value; }
                }

                protected List<TokenValueTypeEnum> m_ChildNeedValueType;
                /// <summary>
                /// �¼���Ҫ���ֶ�����
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
