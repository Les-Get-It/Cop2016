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
	partial class OldfrmSetupSelection
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSetupSelection() : base()
		{
			Load += frmSetupSelection_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdMoveAllToActive;
		public System.Windows.Forms.Button cmdMoveAllToActive {
			get { return withEventsField_cmdMoveAllToActive; }
			set {
				if (withEventsField_cmdMoveAllToActive != null) {
					withEventsField_cmdMoveAllToActive.Click -= cmdMoveAllToActive_Click;
				}
				withEventsField_cmdMoveAllToActive = value;
				if (withEventsField_cmdMoveAllToActive != null) {
					withEventsField_cmdMoveAllToActive.Click += cmdMoveAllToActive_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton optActive;
		public System.Windows.Forms.RadioButton optTest;
		public System.Windows.Forms.GroupBox fraSelectedModule;
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
		private System.Windows.Forms.Button withEventsField_cmdOk;
		public System.Windows.Forms.Button cmdOk {
			get { return withEventsField_cmdOk; }
			set {
				if (withEventsField_cmdOk != null) {
					withEventsField_cmdOk.Click -= cmdOK_Click;
				}
				withEventsField_cmdOk = value;
				if (withEventsField_cmdOk != null) {
					withEventsField_cmdOk.Click += cmdOK_Click;
				}
			}
		}
		public System.Windows.Forms.RadioButton optNewState;
		public System.Windows.Forms.TextBox txtNewState;
		public System.Windows.Forms.ComboBox cboExistingState;
		public System.Windows.Forms.RadioButton optExistingState;
		public System.Windows.Forms.RadioButton optJC;
		public System.Windows.Forms.GroupBox Frame1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSetupSelection));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdMoveAllToActive = new System.Windows.Forms.Button();
			this.fraSelectedModule = new System.Windows.Forms.GroupBox();
			this.optActive = new System.Windows.Forms.RadioButton();
			this.optTest = new System.Windows.Forms.RadioButton();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.optNewState = new System.Windows.Forms.RadioButton();
			this.txtNewState = new System.Windows.Forms.TextBox();
			this.cboExistingState = new System.Windows.Forms.ComboBox();
			this.optExistingState = new System.Windows.Forms.RadioButton();
			this.optJC = new System.Windows.Forms.RadioButton();
			this.fraSelectedModule.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Select the Setup/Module";
			this.ClientSize = new System.Drawing.Size(625, 188);
			this.Location = new System.Drawing.Point(4, 28);
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
			this.Name = "frmSetupSelection";
			this.cmdMoveAllToActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveAllToActive.Text = "Move Test Setup To Active";
			this.cmdMoveAllToActive.Size = new System.Drawing.Size(249, 27);
			this.cmdMoveAllToActive.Location = new System.Drawing.Point(203, 142);
			this.cmdMoveAllToActive.TabIndex = 11;
			this.cmdMoveAllToActive.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveAllToActive.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveAllToActive.CausesValidation = true;
			this.cmdMoveAllToActive.Enabled = true;
			this.cmdMoveAllToActive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveAllToActive.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveAllToActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveAllToActive.TabStop = true;
			this.cmdMoveAllToActive.Name = "cmdMoveAllToActive";
			this.fraSelectedModule.Text = "Select the module";
			this.fraSelectedModule.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fraSelectedModule.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.fraSelectedModule.Size = new System.Drawing.Size(248, 120);
			this.fraSelectedModule.Location = new System.Drawing.Point(372, 14);
			this.fraSelectedModule.TabIndex = 8;
			this.fraSelectedModule.BackColor = System.Drawing.SystemColors.Control;
			this.fraSelectedModule.Enabled = true;
			this.fraSelectedModule.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraSelectedModule.Visible = true;
			this.fraSelectedModule.Padding = new System.Windows.Forms.Padding(0);
			this.fraSelectedModule.Name = "fraSelectedModule";
			this.optActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optActive.Text = "Active Setup";
			this.optActive.Size = new System.Drawing.Size(174, 27);
			this.optActive.Location = new System.Drawing.Point(20, 65);
			this.optActive.TabIndex = 10;
			this.optActive.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optActive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optActive.BackColor = System.Drawing.SystemColors.Control;
			this.optActive.CausesValidation = true;
			this.optActive.Enabled = true;
			this.optActive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optActive.Cursor = System.Windows.Forms.Cursors.Default;
			this.optActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optActive.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optActive.TabStop = true;
			this.optActive.Checked = false;
			this.optActive.Visible = true;
			this.optActive.Name = "optActive";
			this.optTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optTest.Text = "Test Setup";
			this.optTest.Size = new System.Drawing.Size(155, 17);
			this.optTest.Location = new System.Drawing.Point(20, 37);
			this.optTest.TabIndex = 9;
			this.optTest.Checked = true;
			this.optTest.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optTest.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optTest.BackColor = System.Drawing.SystemColors.Control;
			this.optTest.CausesValidation = true;
			this.optTest.Enabled = true;
			this.optTest.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optTest.Cursor = System.Windows.Forms.Cursors.Default;
			this.optTest.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optTest.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optTest.TabStop = true;
			this.optTest.Visible = true;
			this.optTest.Name = "optTest";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Close";
			this.cmdCancel.Size = new System.Drawing.Size(114, 27);
			this.cmdCancel.Location = new System.Drawing.Point(505, 142);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdOk.Text = "Open the Setup";
			this.cmdOk.Size = new System.Drawing.Size(123, 27);
			this.cmdOk.Location = new System.Drawing.Point(20, 142);
			this.cmdOk.TabIndex = 3;
			this.cmdOk.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdOk.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOk.CausesValidation = true;
			this.cmdOk.Enabled = true;
			this.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOk.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOk.TabStop = true;
			this.cmdOk.Name = "cmdOk";
			this.Frame1.Text = "Select the setup ";
			this.Frame1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Frame1.Size = new System.Drawing.Size(344, 118);
			this.Frame1.Location = new System.Drawing.Point(22, 15);
			this.Frame1.TabIndex = 0;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.optNewState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optNewState.Text = "State Specific Setup (New)";
			this.optNewState.Size = new System.Drawing.Size(204, 17);
			this.optNewState.Location = new System.Drawing.Point(28, 84);
			this.optNewState.TabIndex = 7;
			this.optNewState.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optNewState.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optNewState.BackColor = System.Drawing.SystemColors.Control;
			this.optNewState.CausesValidation = true;
			this.optNewState.Enabled = true;
			this.optNewState.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optNewState.Cursor = System.Windows.Forms.Cursors.Default;
			this.optNewState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optNewState.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optNewState.TabStop = true;
			this.optNewState.Checked = false;
			this.optNewState.Visible = true;
			this.optNewState.Name = "optNewState";
			this.txtNewState.AutoSize = false;
			this.txtNewState.Size = new System.Drawing.Size(83, 24);
			this.txtNewState.Location = new System.Drawing.Point(239, 83);
			this.txtNewState.TabIndex = 6;
			this.txtNewState.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtNewState.AcceptsReturn = true;
			this.txtNewState.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNewState.BackColor = System.Drawing.SystemColors.Window;
			this.txtNewState.CausesValidation = true;
			this.txtNewState.Enabled = true;
			this.txtNewState.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNewState.HideSelection = true;
			this.txtNewState.ReadOnly = false;
			this.txtNewState.MaxLength = 0;
			this.txtNewState.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNewState.Multiline = false;
			this.txtNewState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNewState.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNewState.TabStop = true;
			this.txtNewState.Visible = true;
			this.txtNewState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNewState.Name = "txtNewState";
			this.cboExistingState.Size = new System.Drawing.Size(84, 27);
			this.cboExistingState.Location = new System.Drawing.Point(239, 52);
			this.cboExistingState.TabIndex = 5;
			this.cboExistingState.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboExistingState.BackColor = System.Drawing.SystemColors.Window;
			this.cboExistingState.CausesValidation = true;
			this.cboExistingState.Enabled = true;
			this.cboExistingState.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboExistingState.IntegralHeight = true;
			this.cboExistingState.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboExistingState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboExistingState.Sorted = false;
			this.cboExistingState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboExistingState.TabStop = true;
			this.cboExistingState.Visible = true;
			this.cboExistingState.Name = "cboExistingState";
			this.optExistingState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optExistingState.Text = "State Specific Setup (Existing)";
			this.optExistingState.Size = new System.Drawing.Size(215, 23);
			this.optExistingState.Location = new System.Drawing.Point(28, 53);
			this.optExistingState.TabIndex = 2;
			this.optExistingState.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optExistingState.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optExistingState.BackColor = System.Drawing.SystemColors.Control;
			this.optExistingState.CausesValidation = true;
			this.optExistingState.Enabled = true;
			this.optExistingState.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optExistingState.Cursor = System.Windows.Forms.Cursors.Default;
			this.optExistingState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optExistingState.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optExistingState.TabStop = true;
			this.optExistingState.Checked = false;
			this.optExistingState.Visible = true;
			this.optExistingState.Name = "optExistingState";
			this.optJC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optJC.Text = "Joint Commission Setup";
			this.optJC.Size = new System.Drawing.Size(218, 23);
			this.optJC.Location = new System.Drawing.Point(28, 28);
			this.optJC.TabIndex = 1;
			this.optJC.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optJC.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optJC.BackColor = System.Drawing.SystemColors.Control;
			this.optJC.CausesValidation = true;
			this.optJC.Enabled = true;
			this.optJC.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optJC.Cursor = System.Windows.Forms.Cursors.Default;
			this.optJC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optJC.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optJC.TabStop = true;
			this.optJC.Checked = false;
			this.optJC.Visible = true;
			this.optJC.Name = "optJC";
			this.Controls.Add(cmdMoveAllToActive);
			this.Controls.Add(fraSelectedModule);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdOk);
			this.Controls.Add(Frame1);
			this.fraSelectedModule.Controls.Add(optActive);
			this.fraSelectedModule.Controls.Add(optTest);
			this.Frame1.Controls.Add(optNewState);
			this.Frame1.Controls.Add(txtNewState);
			this.Frame1.Controls.Add(cboExistingState);
			this.Frame1.Controls.Add(optExistingState);
			this.Frame1.Controls.Add(optJC);
			this.fraSelectedModule.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
