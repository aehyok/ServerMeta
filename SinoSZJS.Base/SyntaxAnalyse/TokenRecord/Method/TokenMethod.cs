using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SyntaxAnalyse.TokenRecord.Method
{
        public class TokenMethod : TokenRecord
        {
                public TokenMethod(int Index, int Length)
                        : base(Index, Length)
                {
                        this.TokenValueType = TokenValueTypeEnum.Number;
                }

                protected override void SetChildCount()
                {
                      
                }

                protected override void SetPriority()
                {
                        
                }
        }
}
