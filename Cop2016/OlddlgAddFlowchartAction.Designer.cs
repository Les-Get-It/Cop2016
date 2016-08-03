using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace COP2001
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class OlddlgAddFlowchartAction
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OlddlgAddFlowchartAction() : base()
		{
			Load += dlgAddFlowchartAction_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool Disposing)
		{
			if (Disposing) {
				if ((components != null)) {
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}
//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.TextBox txtStep;
		public System.Windows.Forms.ComboBox cboAction;
		private System.Windows.Forms.Button withEventsField_CancelButton;
        public new System.Windows.Forms.Button CancelButton
        {
            get { return withEventsField_CancelButton; }
            set
            {
                if (withEventsField_CancelButton != null)
                {
                    withEventsField_CancelButton.Click -= CancelButton_Click;
                }
                withEventsField_CancelButton = value;
                if (withEventsField_CancelButton != null)
                {
                    withEventsField_CancelButton.Click += CancelButton_Click;
                }
            }
        }
        private System.Windows.Forms.Button withEventsField_OKButton;
		public System.Windows.Forms.Button OkButton {
			get { return withEventsField_OKButton; }
			set {
				if (withEventsField_OKButton != null) {
					withEventsField_OKButton.Click -= OkButton_Click;
				}
				withEventsField_OKButton = value;
				if (withEventsField_OKButton != null) {
					withEventsField_OKButton.Click += OkButton_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtStep = new System.Windows.Forms.TextBox();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStep
            // 
            this.txtStep.AcceptsReturn = true;
            this.txtStep.BackColor = System.Drawing.SystemColors.Window;
            this.txtStep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStep.Enabled = false;
            this.txtStep.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStep.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStep.Location = new System.Drawing.Point(50, 10);
            this.txtStep.MaxLength = 0;
            this.txtStep.Multiline = true;
            this.txtStep.Name = "txtStep";
            this.txtStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStep.Size = new System.Drawing.Size(62, 24);
            this.txtStep.TabIndex = 4;
            this.txtStep.Text = "Text1";
            // 
            // cboAction
            // 
            this.cboAction.BackColor = System.Drawing.SystemColors.Window;
            this.cboAction.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboAction.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAction.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboAction.Location = new System.Drawing.Point(10, 80);
            this.cboAction.Name = "cboAction";
            this.cboAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboAction.Size = new System.Drawing.Size(332, 26);
            this.cboAction.TabIndex = 2;
            this.cboAction.Text = "Combo1";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(10, 10);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(42, 22);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Step";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(10, 60);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(312, 22);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Temporary Action To Take Before Step";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(13, 135);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "button1";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // dlgAddFlowchartAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(355, 170);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.txtStep);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(230, 313);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddFlowchartAction";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Data Action to Flowchart";
            this.ResumeLayout(false);

		}
        #endregion

        private Button CancelButton;
    }
}
