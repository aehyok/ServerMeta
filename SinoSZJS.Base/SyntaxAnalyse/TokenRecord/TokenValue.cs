using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse.TokenRecord
{
        public class TokenValue: TokenRecord
        {
                public TokenValue(int Index, int Length)
                        : base(Index, Length)
                { }

                protected override void SetPriority()
                {
                        this.m_Property.Priority = 6;//值的优先级仅低于括号
                }

                protected override void SetChildCount()
                {
                        this.m_Property.ChildCount = 0;
                }
        }
}
