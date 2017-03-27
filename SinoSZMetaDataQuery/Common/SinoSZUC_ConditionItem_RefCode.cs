using System;
using System.Collections.Generic;
using System.Text;

using SinoSZClientBase.RefCode;
using System.Windows.Forms;
using System.Drawing;

using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataQuery.Common
{
    class SinoSZUC_ConditionItem_RefCode : SinoSZUC_ConditionItem
    {
        public SinoSZUC_ConditionItem_RefCode()
            : base()
        { }

        public SinoSZUC_ConditionItem_RefCode(MDModel_Table_Column _column)
            : base(_column)
        { }



        private RefCodeBox refCodeBox1 = null;


        protected override void InitControls()
        {
           
                base.InitControls();
                this.te_Value.Visible = false;
                refCodeBox1 = new SinoSZClientBase.RefCode.RefCodeBox();
                refCodeBox1.ForeColor = Color.Blue;
                refCodeBox1.CanEdit = true;
                refCodeBox1.CanMultiSelect = false;
                refCodeBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                refCodeBox1.Location = new System.Drawing.Point(0, 1);
                refCodeBox1.Name = "refCodeBox1";
                refCodeBox1.Properties.AutoHeight = false;
                refCodeBox1.Properties.AllowFocused = false;            
                //refCodeBox1.Properties.Appearance.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
                refCodeBox1.Properties.Appearance.Options.UseFont = true;
                refCodeBox1.Properties.Appearance.Options.UseTextOptions = true;
                refCodeBox1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                refCodeBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});

                refCodeBox1.ReadOnly = false;
                refCodeBox1.RefTableName = this.ColumnDefine.ColumnDefine.TableColumn.RefDMB;
                refCodeBox1.Size = new System.Drawing.Size(450, 20);
                refCodeBox1.TabIndex = 13;
                refCodeBox1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                this.Controls.Add(refCodeBox1);
                refCodeBox1.BringToFront();
          

        }

        protected override void initOperator()
        {
            this.teOption.Properties.Items.Add(" 等于 ");
            this.teOption.Properties.Items.Add(" 不等于 ");
            this.teOption.Properties.Items.Add(" 属于 ");
            this.teOption.Properties.Items.Add(" 集合 ");
            this.teOption.Properties.Items.Add(" 为空值");
            this.teOption.Properties.Items.Add(" 为非空值");
            this.teOption.SelectedIndex = 0;
        }

        protected override void SinoSZUC_ConditionItem_Enter(object sender, EventArgs e)
        {
            base.SinoSZUC_ConditionItem_Enter(sender, e);
            refCodeBox1.BackColor = this.te_xh.BackColor;
        }

        protected override void SinoSZUC_ConditionItem_Leave(object sender, EventArgs e)
        {
            base.SinoSZUC_ConditionItem_Leave(sender, e);
            refCodeBox1.BackColor = this.te_xh.BackColor;
        }

        protected override void OptionChanged(string _selectOption)
        {
            switch (_selectOption)
            {
                case "为空值":
                case "为非空值":
                    this.refCodeBox1.CanMultiSelect = false;
                    this.refCodeBox1.Enabled = false;
                    break;

                case "属于":
                    this.refCodeBox1.Enabled = true;
                    this.refCodeBox1.CanMultiSelect = false;
                    break;
                case "集合":
                    this.refCodeBox1.Enabled = true;
                    this.refCodeBox1.CanMultiSelect = true;
                    break;

                default:
                    this.refCodeBox1.Enabled = true;
                    this.refCodeBox1.CanMultiSelect = false;
                    break;
            }
            base.OptionChanged(_selectOption);
        }

        protected override void ClearValue()
        {
            this.refCodeBox1.ClearValue();
        }

        public override bool CheckInput(ref string _errorMsg)
        {
            string _selectOption = GetOperator();
            if (_selectOption == string.Empty)
            {
                _errorMsg = string.Format("用户未选择{0}字段的条件运算符！", this.ColumnDefine.ColumnTitle);
                return false;
            }
            else
            {
                switch (_selectOption)
                {
                    case "为空值":
                    case "为非空值":
                        _errorMsg = "";
                        return true;

                    default:
                        if (this.refCodeBox1.DisplayText == string.Empty)
                        {
                            _errorMsg = string.Format("用户未输入[{0}]字段的值！", this.ColumnDefine.ColumnTitle);
                            return false;
                        }
                        break;
                }
            }

            return true;
        }

        public override bool HaveInputData()
        {
            if (this.refCodeBox1.DisplayText != string.Empty)
            {
                return true;
            }
            else
            {
                string _selectOption = GetOperator();
                switch (_selectOption)
                {
                    case "为空值":
                    case "为非空值":
                        return true;
                    default:
                        return false;
                }
            }
        }
        public override void SetInputValue(MDQuery_ConditionItem _columnCodition)
        {
            this.teOption.EditValue = _columnCodition.Operator;
            this.CaseSensitive = _columnCodition.CaseSensitive;
            this.te_xh.Text = _columnCodition.ColumnIndex;
            refCodeBox1.SetValues(_columnCodition.Values);
        }

        public override List<string> GetConditionValues()
        {
            string _msg = "";
            if (!CheckInput(ref _msg)) return null;
            return this.refCodeBox1.GetValues();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.teOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_xh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // teOption
            // 
            this.teOption.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.teOption.Properties.Appearance.Options.UseForeColor = true;
            this.teOption.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // teColName
            // 
            this.teColName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.teColName.Properties.Appearance.Options.UseBackColor = true;
            this.teColName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // te_Value
            // 
            this.te_Value.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Value.Properties.Appearance.Options.UseForeColor = true;
            this.te_Value.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // te_xh
            // 
            this.te_xh.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.te_xh.Properties.Appearance.Options.UseBackColor = true;
            this.te_xh.Properties.Appearance.Options.UseTextOptions = true;
            this.te_xh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.te_xh.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // SinoSZUC_ConditionItem_RefCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "SinoSZUC_ConditionItem_RefCode";
            ((System.ComponentModel.ISupportInitialize)(this.teOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Value.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_xh.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
