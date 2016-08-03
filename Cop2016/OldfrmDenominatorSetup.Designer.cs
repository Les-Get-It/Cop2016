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
	partial class OldfrmDenominatorSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmDenominatorSetup() : base()
		{
			FormClosed += frmDenominatorSetup_FormClosed;
			Load += frmDenominatorSetup_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = My.MyProject.Forms.frmMasterForm;
			My.MyProject.Forms.frmMasterForm.Show();
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
		private System.Windows.Forms.CheckedListBox withEventsField_lstSummaryFields;
		public System.Windows.Forms.CheckedListBox lstSummaryFields {
			get { return withEventsField_lstSummaryFields; }
			set {
				if (withEventsField_lstSummaryFields != null) {
					withEventsField_lstSummaryFields.ItemCheck -= lstSummaryFields_ItemCheck;
				}
				withEventsField_lstSummaryFields = value;
				if (withEventsField_lstSummaryFields != null) {
					withEventsField_lstSummaryFields.ItemCheck += lstSummaryFields_ItemCheck;
				}
			}
		}
		public System.Windows.Forms.TabPage _SSTab1_TabPage0;
		private System.Windows.Forms.CheckedListBox withEventsField_lstUtilizationFields;
		public System.Windows.Forms.CheckedListBox lstUtilizationFields {
			get { return withEventsField_lstUtilizationFields; }
			set {
				if (withEventsField_lstUtilizationFields != null) {
					withEventsField_lstUtilizationFields.ItemCheck -= lstUtilizationFields_ItemCheck;
				}
				withEventsField_lstUtilizationFields = value;
				if (withEventsField_lstUtilizationFields != null) {
					withEventsField_lstUtilizationFields.ItemCheck += lstUtilizationFields_ItemCheck;
				}
			}
		}
		public System.Windows.Forms.TabPage _SSTab1_TabPage1;
		public System.Windows.Forms.TabControl SSTab1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmDenominatorSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.SSTab1 = new System.Windows.Forms.TabControl();
			this._SSTab1_TabPage0 = new System.Windows.Forms.TabPage();
			this.lstSummaryFields = new System.Windows.Forms.CheckedListBox();
			this._SSTab1_TabPage1 = new System.Windows.Forms.TabPage();
			this.lstUtilizationFields = new System.Windows.Forms.CheckedListBox();
			this.SSTab1.SuspendLayout();
			this._SSTab1_TabPage0.SuspendLayout();
			this._SSTab1_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Denominator Setup";
			this.ClientSize = new System.Drawing.Size(695, 310);
			this.Location = new System.Drawing.Point(3, 28);
			this.MaximizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmDenominatorSetup";
			this.SSTab1.Size = new System.Drawing.Size(662, 292);
			this.SSTab1.Location = new System.Drawing.Point(10, 10);
			this.SSTab1.TabIndex = 0;
			this.SSTab1.ItemSize = new System.Drawing.Size(42, 22);
			this.SSTab1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.SSTab1.Name = "SSTab1";
			this._SSTab1_TabPage0.Text = "Summaries";
			this.lstSummaryFields.Size = new System.Drawing.Size(642, 230);
			this.lstSummaryFields.Location = new System.Drawing.Point(10, 40);
			this.lstSummaryFields.TabIndex = 1;
			this.lstSummaryFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSummaryFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSummaryFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstSummaryFields.CausesValidation = true;
			this.lstSummaryFields.Enabled = true;
			this.lstSummaryFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSummaryFields.IntegralHeight = true;
			this.lstSummaryFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSummaryFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSummaryFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSummaryFields.Sorted = false;
			this.lstSummaryFields.TabStop = true;
			this.lstSummaryFields.Visible = true;
			this.lstSummaryFields.MultiColumn = false;
			this.lstSummaryFields.Name = "lstSummaryFields";
			this._SSTab1_TabPage1.Text = "Utilization";
			this.lstUtilizationFields.Size = new System.Drawing.Size(642, 230);
			this.lstUtilizationFields.Location = new System.Drawing.Point(10, 50);
			this.lstUtilizationFields.TabIndex = 2;
			this.lstUtilizationFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstUtilizationFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstUtilizationFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstUtilizationFields.CausesValidation = true;
			this.lstUtilizationFields.Enabled = true;
			this.lstUtilizationFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstUtilizationFields.IntegralHeight = true;
			this.lstUtilizationFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstUtilizationFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstUtilizationFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstUtilizationFields.Sorted = false;
			this.lstUtilizationFields.TabStop = true;
			this.lstUtilizationFields.Visible = true;
			this.lstUtilizationFields.MultiColumn = false;
			this.lstUtilizationFields.Name = "lstUtilizationFields";
			this.Controls.Add(SSTab1);
			this.SSTab1.Controls.Add(_SSTab1_TabPage0);
			this.SSTab1.Controls.Add(_SSTab1_TabPage1);
			this._SSTab1_TabPage0.Controls.Add(lstSummaryFields);
			this._SSTab1_TabPage1.Controls.Add(lstUtilizationFields);
			this.SSTab1.ResumeLayout(false);
			this._SSTab1_TabPage0.ResumeLayout(false);
			this._SSTab1_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
