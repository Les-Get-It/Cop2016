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
	partial class OldfrmTableActionSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmTableActionSetup() : base()
		{
			Load += frmTableActionSetup_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdClose;
		public System.Windows.Forms.Button cmdClose {
			get { return withEventsField_cmdClose; }
			set {
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click -= cmdClose_Click;
				}
				withEventsField_cmdClose = value;
				if (withEventsField_cmdClose != null) {
					withEventsField_cmdClose.Click += cmdClose_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveAction;
		public System.Windows.Forms.Button cmdRemoveAction {
			get { return withEventsField_cmdRemoveAction; }
			set {
				if (withEventsField_cmdRemoveAction != null) {
					withEventsField_cmdRemoveAction.Click -= cmdRemoveAction_Click;
				}
				withEventsField_cmdRemoveAction = value;
				if (withEventsField_cmdRemoveAction != null) {
					withEventsField_cmdRemoveAction.Click += cmdRemoveAction_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddAction;
		public System.Windows.Forms.Button cmdAddAction {
			get { return withEventsField_cmdAddAction; }
			set {
				if (withEventsField_cmdAddAction != null) {
					withEventsField_cmdAddAction.Click -= cmdAddAction_Click;
				}
				withEventsField_cmdAddAction = value;
				if (withEventsField_cmdAddAction != null) {
					withEventsField_cmdAddAction.Click += cmdAddAction_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstAvailableActions;
		public System.Windows.Forms.ListBox lstAppliedActions;
		public System.Windows.Forms.Label lblFieldName;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmTableActionSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdRemoveAction = new System.Windows.Forms.Button();
			this.cmdAddAction = new System.Windows.Forms.Button();
			this.lstAvailableActions = new System.Windows.Forms.ListBox();
			this.lstAppliedActions = new System.Windows.Forms.ListBox();
			this.lblFieldName = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Data Entry Actions";
			this.ClientSize = new System.Drawing.Size(718, 300);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmTableActionSetup";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdClose.Text = "Close";
			this.cmdClose.Size = new System.Drawing.Size(142, 24);
			this.cmdClose.Location = new System.Drawing.Point(288, 270);
			this.cmdClose.TabIndex = 6;
			this.cmdClose.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdClose.BackColor = System.Drawing.SystemColors.Control;
			this.cmdClose.CausesValidation = true;
			this.cmdClose.Enabled = true;
			this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdClose.TabStop = true;
			this.cmdClose.Name = "cmdClose";
			this.cmdRemoveAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveAction.Text = "<<==";
			this.cmdRemoveAction.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveAction.Size = new System.Drawing.Size(57, 30);
			this.cmdRemoveAction.Location = new System.Drawing.Point(334, 168);
			this.cmdRemoveAction.TabIndex = 5;
			this.cmdRemoveAction.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveAction.CausesValidation = true;
			this.cmdRemoveAction.Enabled = true;
			this.cmdRemoveAction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveAction.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveAction.TabStop = true;
			this.cmdRemoveAction.Name = "cmdRemoveAction";
			this.cmdAddAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddAction.Text = "==>>";
			this.cmdAddAction.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddAction.Size = new System.Drawing.Size(58, 30);
			this.cmdAddAction.Location = new System.Drawing.Point(334, 130);
			this.cmdAddAction.TabIndex = 4;
			this.cmdAddAction.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddAction.CausesValidation = true;
			this.cmdAddAction.Enabled = true;
			this.cmdAddAction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddAction.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddAction.TabStop = true;
			this.cmdAddAction.Name = "cmdAddAction";
			this.lstAvailableActions.Size = new System.Drawing.Size(312, 204);
			this.lstAvailableActions.Location = new System.Drawing.Point(15, 63);
			this.lstAvailableActions.TabIndex = 2;
			this.lstAvailableActions.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAvailableActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAvailableActions.BackColor = System.Drawing.SystemColors.Window;
			this.lstAvailableActions.CausesValidation = true;
			this.lstAvailableActions.Enabled = true;
			this.lstAvailableActions.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAvailableActions.IntegralHeight = true;
			this.lstAvailableActions.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAvailableActions.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstAvailableActions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAvailableActions.Sorted = false;
			this.lstAvailableActions.TabStop = true;
			this.lstAvailableActions.Visible = true;
			this.lstAvailableActions.MultiColumn = false;
			this.lstAvailableActions.Name = "lstAvailableActions";
			this.lstAppliedActions.Size = new System.Drawing.Size(312, 204);
			this.lstAppliedActions.Location = new System.Drawing.Point(400, 63);
			this.lstAppliedActions.TabIndex = 0;
			this.lstAppliedActions.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAppliedActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAppliedActions.BackColor = System.Drawing.SystemColors.Window;
			this.lstAppliedActions.CausesValidation = true;
			this.lstAppliedActions.Enabled = true;
			this.lstAppliedActions.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAppliedActions.IntegralHeight = true;
			this.lstAppliedActions.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAppliedActions.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstAppliedActions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAppliedActions.Sorted = false;
			this.lstAppliedActions.TabStop = true;
			this.lstAppliedActions.Visible = true;
			this.lstAppliedActions.MultiColumn = false;
			this.lstAppliedActions.Name = "lstAppliedActions";
			this.lblFieldName.Text = "Field Name";
			this.lblFieldName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblFieldName.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblFieldName.Size = new System.Drawing.Size(583, 27);
			this.lblFieldName.Location = new System.Drawing.Point(22, 7);
			this.lblFieldName.TabIndex = 7;
			this.lblFieldName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFieldName.BackColor = System.Drawing.SystemColors.Control;
			this.lblFieldName.Enabled = true;
			this.lblFieldName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFieldName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFieldName.UseMnemonic = true;
			this.lblFieldName.Visible = true;
			this.lblFieldName.AutoSize = false;
			this.lblFieldName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblFieldName.Name = "lblFieldName";
			this.Label2.Text = "Available  Actions";
			this.Label2.Size = new System.Drawing.Size(167, 25);
			this.Label2.Location = new System.Drawing.Point(15, 42);
			this.Label2.TabIndex = 3;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.Label1.Text = "Applied Actions";
			this.Label1.Size = new System.Drawing.Size(167, 25);
			this.Label1.Location = new System.Drawing.Point(399, 42);
			this.Label1.TabIndex = 1;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Controls.Add(cmdClose);
			this.Controls.Add(cmdRemoveAction);
			this.Controls.Add(cmdAddAction);
			this.Controls.Add(lstAvailableActions);
			this.Controls.Add(lstAppliedActions);
			this.Controls.Add(lblFieldName);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
