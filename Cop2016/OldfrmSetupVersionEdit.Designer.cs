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
	partial class OldfrmSetupVersionEdit
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSetupVersionEdit() : base()
		{
			Load += frmSetupVersionEdit_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdUpdate;
		public System.Windows.Forms.Button cmdUpdate {
			get { return withEventsField_cmdUpdate; }
			set {
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click -= cmdUpdate_Click;
				}
				withEventsField_cmdUpdate = value;
				if (withEventsField_cmdUpdate != null) {
					withEventsField_cmdUpdate.Click += cmdUpdate_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtVersionEndDate;
		public System.Windows.Forms.TextBox txtNotes;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSetupVersionEdit));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.txtVersionEndDate = new System.Windows.Forms.TextBox();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Edit Version Information";
			this.ClientSize = new System.Drawing.Size(390, 197);
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
			this.Name = "frmSetupVersionEdit";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(104, 28);
			this.cmdCancel.Location = new System.Drawing.Point(234, 163);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(104, 28);
			this.cmdUpdate.Location = new System.Drawing.Point(98, 164);
			this.cmdUpdate.TabIndex = 4;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.txtVersionEndDate.AutoSize = false;
			this.txtVersionEndDate.Size = new System.Drawing.Size(110, 24);
			this.txtVersionEndDate.Location = new System.Drawing.Point(123, 125);
			this.txtVersionEndDate.TabIndex = 2;
			this.txtVersionEndDate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtVersionEndDate.AcceptsReturn = true;
			this.txtVersionEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtVersionEndDate.BackColor = System.Drawing.SystemColors.Window;
			this.txtVersionEndDate.CausesValidation = true;
			this.txtVersionEndDate.Enabled = true;
			this.txtVersionEndDate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtVersionEndDate.HideSelection = true;
			this.txtVersionEndDate.ReadOnly = false;
			this.txtVersionEndDate.MaxLength = 0;
			this.txtVersionEndDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtVersionEndDate.Multiline = false;
			this.txtVersionEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtVersionEndDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtVersionEndDate.TabStop = true;
			this.txtVersionEndDate.Visible = true;
			this.txtVersionEndDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtVersionEndDate.Name = "txtVersionEndDate";
			this.txtNotes.AutoSize = false;
			this.txtNotes.Size = new System.Drawing.Size(305, 82);
			this.txtNotes.Location = new System.Drawing.Point(50, 30);
			this.txtNotes.TabIndex = 0;
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
			this.txtNotes.Visible = true;
			this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNotes.Name = "txtNotes";
			this.Label2.Text = "Version End Date:";
			this.Label2.Size = new System.Drawing.Size(118, 23);
			this.Label2.Location = new System.Drawing.Point(0, 130);
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
			this.Label1.Text = "Notes";
			this.Label1.Size = new System.Drawing.Size(63, 25);
			this.Label1.Location = new System.Drawing.Point(14, 5);
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
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdUpdate);
			this.Controls.Add(txtVersionEndDate);
			this.Controls.Add(txtNotes);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
