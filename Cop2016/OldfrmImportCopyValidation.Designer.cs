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
	partial class OldfrmImportCopyValidation
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmImportCopyValidation() : base()
		{
			Load += frmImportCopyValidation_Load;
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
		public System.Windows.Forms.Button Command2;
		private System.Windows.Forms.Button withEventsField_cmdCopy;
		public System.Windows.Forms.Button cmdCopy {
			get { return withEventsField_cmdCopy; }
			set {
				if (withEventsField_cmdCopy != null) {
					withEventsField_cmdCopy.Click -= cmdCopy_Click;
				}
				withEventsField_cmdCopy = value;
				if (withEventsField_cmdCopy != null) {
					withEventsField_cmdCopy.Click += cmdCopy_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstImportLayout;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmImportCopyValidation));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Command2 = new System.Windows.Forms.Button();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.lstImportLayout = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Copy Validation Errors and Warnings";
			this.ClientSize = new System.Drawing.Size(390, 180);
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
			this.Name = "frmImportCopyValidation";
			this.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command2.Text = "Cancel";
			this.Command2.Size = new System.Drawing.Size(84, 27);
			this.Command2.Location = new System.Drawing.Point(279, 142);
			this.Command2.TabIndex = 3;
			this.Command2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Command2.BackColor = System.Drawing.SystemColors.Control;
			this.Command2.CausesValidation = true;
			this.Command2.Enabled = true;
			this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command2.TabStop = true;
			this.Command2.Name = "Command2";
			this.cmdCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopy.Text = "Copy Validation Messages";
			this.cmdCopy.Size = new System.Drawing.Size(245, 27);
			this.cmdCopy.Location = new System.Drawing.Point(10, 142);
			this.cmdCopy.TabIndex = 2;
			this.cmdCopy.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopy.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopy.CausesValidation = true;
			this.cmdCopy.Enabled = true;
			this.cmdCopy.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopy.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopy.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopy.TabStop = true;
			this.cmdCopy.Name = "cmdCopy";
			this.lstImportLayout.Size = new System.Drawing.Size(355, 90);
			this.lstImportLayout.Location = new System.Drawing.Point(10, 47);
			this.lstImportLayout.TabIndex = 0;
			this.lstImportLayout.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstImportLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstImportLayout.BackColor = System.Drawing.SystemColors.Window;
			this.lstImportLayout.CausesValidation = true;
			this.lstImportLayout.Enabled = true;
			this.lstImportLayout.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstImportLayout.IntegralHeight = true;
			this.lstImportLayout.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstImportLayout.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstImportLayout.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstImportLayout.Sorted = false;
			this.lstImportLayout.TabStop = true;
			this.lstImportLayout.Visible = true;
			this.lstImportLayout.MultiColumn = false;
			this.lstImportLayout.Name = "lstImportLayout";
			this.Label1.Text = "Select the layout that you want to copy the validation messages from:";
			this.Label1.Size = new System.Drawing.Size(334, 35);
			this.Label1.Location = new System.Drawing.Point(8, 5);
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
			this.Controls.Add(Command2);
			this.Controls.Add(cmdCopy);
			this.Controls.Add(lstImportLayout);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
