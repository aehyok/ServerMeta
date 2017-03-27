using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SinoSZClientSysManager.TaskManager
{
        public partial class TaskParameterInput : UserControl
        {

                protected TaskParameter CurrentParam;
                public TaskParameterInput()
                {
                        InitializeComponent();
                }

                public TaskParameterInput(TaskParameter param)
                {
                        InitializeComponent();
                        CurrentParam = param;
                        this.LB_TITLE.Text = param.DisplayTitle;
                        this.TE_VALUE.EditValue = param.ParamValue;
                }


                public event EventHandler<EventArgs> ParamValueChanged;
                virtual public void RaiseParamValueChanged(EventArgs e)
                {
                        if (ParamValueChanged != null)
                        {
                                ParamValueChanged(this, e);
                        }
                }

                public TaskParameter GetParamValue()
                {
                        CurrentParam.ParamValue = (this.TE_VALUE.EditValue == null) ? "" : this.TE_VALUE.EditValue.ToString();
                        return CurrentParam;
                }

                private void TE_VALUE_EditValueChanged(object sender, EventArgs e)
                {
                        RaiseParamValueChanged(e);
                }
        }
}
