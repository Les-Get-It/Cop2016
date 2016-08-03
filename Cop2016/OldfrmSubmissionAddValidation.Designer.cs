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
	partial class OldfrmSubmissionAddValidation
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSubmissionAddValidation() : base()
		{
			Load += frmSubmissionAddValidation_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdAdd;
		public System.Windows.Forms.Button cmdAdd {
			get { return withEventsField_cmdAdd; }
			set {
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click -= cmdAdd_Click;
				}
				withEventsField_cmdAdd = value;
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click += cmdAdd_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCancel;
		public System.Windows.Forms.Button cmdCancel {
			get { return withEventsField_cmdCancel; }
			set {
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click -= cmdCancel_Click;
				}
				withEventsField_cmdCancel = value;
				if (withEventsField_cmdCancel != null) {
					withEventsField_cmdCancel.Click += cmdCancel_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboIndicators;
		public System.Windows.Forms.TextBox txtMessage;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSubmissionAddValidation));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cboIndicators = new System.Windows.Forms.ComboBox();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Add Validation Message";
			this.ClientSize = new System.Drawing.Size(447, 278);
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
			this.Name = "frmSubmissionAddValidation";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(144, 25);
			this.cmdAdd.Location = new System.Drawing.Point(85, 228);
			this.cmdAdd.TabIndex = 2;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(118, 25);
			this.cmdCancel.Location = new System.Drawing.Point(254, 227);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cboIndicators.Size = new System.Drawing.Size(433, 27);
			this.cboIndicators.Location = new System.Drawing.Point(7, 28);
			this.cboIndicators.TabIndex = 0;
			this.cboIndicators.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboIndicators.BackColor = System.Drawing.SystemColors.Window;
			this.cboIndicators.CausesValidation = true;
			this.cboIndicators.Enabled = true;
			this.cboIndicators.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboIndicators.IntegralHeight = true;
			this.cboIndicators.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboIndicators.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboIndicators.Sorted = false;
			this.cboIndicators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboIndicators.TabStop = true;
			this.cboIndicators.Visible = true;
			this.cboIndicators.Name = "cboIndicators";
			this.txtMessage.AutoSize = false;
			this.txtMessage.Size = new System.Drawing.Size(429, 117);
			this.txtMessage.Location = new System.Drawing.Point(10, 94);
			this.txtMessage.Multiline = true;
			this.txtMessage.TabIndex = 1;
			this.txtMessage.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtMessage.AcceptsReturn = true;
			this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
			this.txtMessage.CausesValidation = true;
			this.txtMessage.Enabled = true;
			this.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMessage.HideSelection = true;
			this.txtMessage.ReadOnly = false;
			this.txtMessage.MaxLength = 0;
			this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMessage.TabStop = true;
			this.txtMessage.Visible = true;
			this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMessage.Name = "txtMessage";
			this.Label1.Text = "Indicator List";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(227, 15);
			this.Label1.Location = new System.Drawing.Point(9, 7);
			this.Label1.TabIndex = 5;
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
			this.Label2.Text = "Message";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.Size = new System.Drawing.Size(184, 19);
			this.Label2.Location = new System.Drawing.Point(12, 73);
			this.Label2.TabIndex = 4;
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
			this.Controls.Add(cmdAdd);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cboIndicators);
			this.Controls.Add(txtMessage);
			this.Controls.Add(Label1);
			this.Controls.Add(Label2);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
