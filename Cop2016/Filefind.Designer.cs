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
	partial class FileFind
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public FileFind() : base()
		{
			Load += FileFind_Load;
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
		private Microsoft.VisualBasic.Compatibility.VB6.DirListBox withEventsField_dirList;
		public Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirList {
			get { return withEventsField_dirList; }
			set {
				if (withEventsField_dirList != null) {
					withEventsField_dirList.Change -= dirList_Change;
				}
				withEventsField_dirList = value;
				if (withEventsField_dirList != null) {
					withEventsField_dirList.Change += dirList_Change;
				}
			}
		}
		public System.Windows.Forms.Label lblDirectories;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FileFind));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.dirList = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
			this.lblDirectories = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "File Search";
			this.ClientSize = new System.Drawing.Size(607, 484);
			this.Location = new System.Drawing.Point(235, 225);
			this.ControlBox = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "FileFind";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(82, 27);
			this.cmdCancel.Location = new System.Drawing.Point(490, 440);
			this.cmdCancel.TabIndex = 2;
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
			this.cmdOk.Text = "&OK";
			this.cmdOk.Size = new System.Drawing.Size(99, 27);
			this.cmdOk.Location = new System.Drawing.Point(10, 440);
			this.cmdOk.TabIndex = 1;
			this.cmdOk.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdOk.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOk.CausesValidation = true;
			this.cmdOk.Enabled = true;
			this.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOk.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOk.TabStop = true;
			this.cmdOk.Name = "cmdOk";
			this.dirList.Size = new System.Drawing.Size(560, 402);
			this.dirList.Location = new System.Drawing.Point(15, 30);
			this.dirList.TabIndex = 0;
			this.dirList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.dirList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dirList.BackColor = System.Drawing.SystemColors.Window;
			this.dirList.CausesValidation = true;
			this.dirList.Enabled = true;
			this.dirList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.dirList.Cursor = System.Windows.Forms.Cursors.Default;
			this.dirList.TabStop = true;
			this.dirList.Visible = true;
			this.dirList.Name = "dirList";
			this.lblDirectories.Text = "&Directories";
			this.lblDirectories.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblDirectories.Size = new System.Drawing.Size(230, 24);
			this.lblDirectories.Location = new System.Drawing.Point(25, 0);
			this.lblDirectories.TabIndex = 3;
			this.lblDirectories.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblDirectories.BackColor = System.Drawing.SystemColors.Control;
			this.lblDirectories.Enabled = true;
			this.lblDirectories.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDirectories.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblDirectories.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblDirectories.UseMnemonic = true;
			this.lblDirectories.Visible = true;
			this.lblDirectories.AutoSize = false;
			this.lblDirectories.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblDirectories.Name = "lblDirectories";
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdOk);
			this.Controls.Add(dirList);
			this.Controls.Add(lblDirectories);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
