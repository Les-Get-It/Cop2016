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
	partial class OldfrmSetupVersion
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSetupVersion() : base()
		{
			Load += frmSetupVersion_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdDelete;
		public System.Windows.Forms.Button cmdDelete {
			get { return withEventsField_cmdDelete; }
			set {
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmdDelete = value;
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click += cmdDelete_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Button withEventsField_cmdEdit;
		public System.Windows.Forms.Button cmdEdit {
			get { return withEventsField_cmdEdit; }
			set {
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click -= cmdEdit_Click;
				}
				withEventsField_cmdEdit = value;
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click += cmdEdit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdReset;
		public System.Windows.Forms.Button cmdReset {
			get { return withEventsField_cmdReset; }
			set {
				if (withEventsField_cmdReset != null) {
					withEventsField_cmdReset.Click -= cmdReset_Click;
				}
				withEventsField_cmdReset = value;
				if (withEventsField_cmdReset != null) {
					withEventsField_cmdReset.Click += cmdReset_Click;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcVersionHistory;
		public AxMSDBGrid.AxDBGrid dbgVersionHistory;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSetupVersion));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdDelete = new System.Windows.Forms.Button();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdReset = new System.Windows.Forms.Button();
			this.rdcVersionHistory = new AxMSRDC.AxMSRDC();
			this.dbgVersionHistory = new AxMSDBGrid.AxDBGrid();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcVersionHistory).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgVersionHistory).BeginInit();
			this.Text = "Setup Version History";
			this.ClientSize = new System.Drawing.Size(695, 272);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
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
			this.Name = "frmSetupVersion";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete";
			this.cmdDelete.Size = new System.Drawing.Size(110, 28);
			this.cmdDelete.Location = new System.Drawing.Point(250, 240);
			this.cmdDelete.TabIndex = 4;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.txtNotes.AutoSize = false;
			this.txtNotes.Size = new System.Drawing.Size(50, 32);
			this.txtNotes.Location = new System.Drawing.Point(469, 238);
			this.txtNotes.TabIndex = 3;
			this.txtNotes.Visible = false;
			this.txtNotes.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtNotes.AcceptsReturn = true;
			this.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNotes.BackColor = System.Drawing.SystemColors.Window;
			this.txtNotes.CausesValidation = true;
			this.txtNotes.Enabled = true;
			this.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNotes.HideSelection = true;
			this.txtNotes.ReadOnly = false;
			this.txtNotes.MaxLength = 0;
			this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNotes.Multiline = false;
			this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNotes.TabStop = true;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNotes.Name = "txtNotes";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "Edit";
			this.cmdEdit.Size = new System.Drawing.Size(110, 28);
			this.cmdEdit.Location = new System.Drawing.Point(129, 240);
			this.cmdEdit.TabIndex = 2;
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdReset.Text = "Reset";
			this.cmdReset.Size = new System.Drawing.Size(110, 28);
			this.cmdReset.Location = new System.Drawing.Point(8, 240);
			this.cmdReset.TabIndex = 1;
			this.cmdReset.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdReset.BackColor = System.Drawing.SystemColors.Control;
			this.cmdReset.CausesValidation = true;
			this.cmdReset.Enabled = true;
			this.cmdReset.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdReset.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdReset.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdReset.TabStop = true;
			this.cmdReset.Name = "cmdReset";
			rdcVersionHistory.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcVersionHistory.OcxState");
			this.rdcVersionHistory.Size = new System.Drawing.Size(140, 30);
			this.rdcVersionHistory.Location = new System.Drawing.Point(538, 239);
			this.rdcVersionHistory.Visible = false;
			this.rdcVersionHistory.Name = "rdcVersionHistory";
			dbgVersionHistory.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgVersionHistory.OcxState");
			this.dbgVersionHistory.Size = new System.Drawing.Size(675, 224);
			this.dbgVersionHistory.Location = new System.Drawing.Point(9, 8);
			this.dbgVersionHistory.TabIndex = 0;
			this.dbgVersionHistory.Name = "dbgVersionHistory";
			((System.ComponentModel.ISupportInitialize)this.dbgVersionHistory).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcVersionHistory).EndInit();
			this.Controls.Add(cmdDelete);
			this.Controls.Add(txtNotes);
			this.Controls.Add(cmdEdit);
			this.Controls.Add(cmdReset);
			this.Controls.Add(rdcVersionHistory);
			this.Controls.Add(dbgVersionHistory);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
