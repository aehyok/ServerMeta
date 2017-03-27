using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.SyntaxAnalyse.TokenRecord;

namespace SinoSZMetaDataQuery.SyntaxAnalyse.ComputeFieldExpression.SymbolToken
{
        public class TokenPlus : TokenRecord
        {
                public TokenPlus(int Index, int Length)
                        : base(Index, Length)
                {
                }

                protected override void SetPriority()
                {
                        this.m_Property.Priority = 2;
                }

                protected override void SetChildCount()
                {
                        this.m_Property.ChildCount = 2;
                }

                public override TokenValueTypeEnum TokenValueType
                {
                        get
                        {
                                if (this.ChildList.Count == 0)
                                {
                                        return TokenValueTypeEnum.Unknow;
                                }
                                else
                                {
                                        return this.ChildList[1].TokenValueType;
                                }
                        }
                        set
                        {
                                
                        }
                }

                
        }
}
