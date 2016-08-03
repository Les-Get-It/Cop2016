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
	partial class OldLogin
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldLogin() : base()
		{
			Load += Login_Load;
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
		private System.Windows.Forms.TextBox withEventsField_txtPassword;
		public System.Windows.Forms.TextBox txtPassword {
			get { return withEventsField_txtPassword; }
			set {
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.KeyDown -= txtPassword_KeyDown;
				}
				withEventsField_txtPassword = value;
				if (withEventsField_txtPassword != null) {
					withEventsField_txtPassword.KeyDown += txtPassword_KeyDown;
				}
			}
		}
		public System.Windows.Forms.TextBox txtUserName;
		public System.Windows.Forms.Label lblPassword;
		public System.Windows.Forms.Label lblUserName;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldLogin));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblUserName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Login -  COP Home 2002";
			this.ClientSize = new System.Drawing.Size(262, 119);
			this.Location = new System.Drawing.Point(157, 125);
			this.Icon = (System.Drawing.Icon)resources.GetObject("Login.Icon");
			this.MaximizeBox = false;
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
			this.Name = "Login";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(102, 32);
			this.cmdCancel.Location = new System.Drawing.Point(140, 80);
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
			this.cmdOk.Text = "&Ok";
			this.cmdOk.Size = new System.Drawing.Size(102, 32);
			this.cmdOk.Location = new System.Drawing.Point(20, 80);
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
			this.txtPassword.AutoSize = false;
			this.txtPassword.Size = new System.Drawing.Size(142, 24);
			this.txtPassword.HideSelection = false;
			this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtPassword.Location = new System.Drawing.Point(100, 40);
			this.txtPassword.PasswordChar = Strings.ChrW(42);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtPassword.AcceptsReturn = true;
			this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
			this.txtPassword.CausesValidation = true;
			this.txtPassword.Enabled = true;
			this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPassword.ReadOnly = false;
			this.txtPassword.MaxLength = 0;
			this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPassword.Multiline = false;
			this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPassword.TabStop = true;
			this.txtPassword.Visible = true;
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPassword.Name = "txtPassword";
			this.txtUserName.AutoSize = false;
			this.txtUserName.Size = new System.Drawing.Size(142, 24);
			this.txtUserName.HideSelection = false;
			this.txtUserName.Location = new System.Drawing.Point(100, 8);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtUserName.AcceptsReturn = true;
			this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
			this.txtUserName.CausesValidation = true;
			this.txtUserName.Enabled = true;
			this.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUserName.ReadOnly = false;
			this.txtUserName.MaxLength = 0;
			this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtUserName.Multiline = false;
			this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtUserName.TabStop = true;
			this.txtUserName.Visible = true;
			this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtUserName.Name = "txtUserName";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblPassword.Text = "&Password";
			this.lblPassword.Size = new System.Drawing.Size(72, 22);
			this.lblPassword.Location = new System.Drawing.Point(10, 40);
			this.lblPassword.TabIndex = 5;
			this.lblPassword.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblPassword.BackColor = System.Drawing.SystemColors.Control;
			this.lblPassword.Enabled = true;
			this.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblPassword.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPassword.UseMnemonic = true;
			this.lblPassword.Visible = true;
			this.lblPassword.AutoSize = false;
			this.lblPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblPassword.Name = "lblPassword";
			this.lblUserName.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblUserName.Text = "&User Name";
			this.lblUserName.Size = new System.Drawing.Size(72, 22);
			this.lblUserName.Location = new System.Drawing.Point(10, 10);
			this.lblUserName.TabIndex = 0;
			this.lblUserName.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblUserName.BackColor = System.Drawing.SystemColors.Control;
			this.lblUserName.Enabled = true;
			this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblUserName.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblUserName.UseMnemonic = true;
			this.lblUserName.Visible = true;
			this.lblUserName.AutoSize = false;
			this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblUserName.Name = "lblUserName";
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdOk);
			this.Controls.Add(txtPassword);
			this.Controls.Add(txtUserName);
			this.Controls.Add(lblPassword);
			this.Controls.Add(lblUserName);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
