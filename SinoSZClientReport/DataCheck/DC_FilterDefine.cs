using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZClientReport.DataCheck
{
        [Serializable]
        public class DC_FilterDefine
        {
                private decimal sh_zj = -1;
                private decimal sh_zsj = -1;
                private decimal sh_fj = -1;

                private decimal sh_jg = -1;
                private decimal sh_bg = -1;
                private decimal sh_rk = -1;

                public DC_FilterDefine() { }
                
                /// <summary>
                /// 审核结果
                /// </summary>                
                public decimal SH_JG
                {
                        get { return sh_jg; }
                        set { sh_jg = value; }
                }

                /// <summary>
                /// 记录变更
                /// </summary>
                public decimal SH_BG
                {
                        get { return sh_bg; }
                        set { sh_bg = value; }
                }

                /// <summary>
                /// 入库情况
                /// </summary>
                public decimal SH_RK
                {
                        get { return sh_rk; }
                        set { sh_rk = value; }
                }
                /// <summary>
                /// 总局审核结果
                /// </summary>
                public decimal SH_ZJ
                {
                        get { return sh_zj; }
                        set { sh_zj = value; }
                }
                /// <summary>
                /// 直属局审核结果
                /// </summary>
                public decimal SH_ZSJ
                {
                        get { return sh_zsj; }
                        set { sh_zsj = value; }
                }

                /// <summary>
                /// 分局审核结果
                /// </summary>
                public decimal SH_FJ
                {
                        get { return sh_fj; }
                        set { sh_fj = value; }
                }
        }
}
