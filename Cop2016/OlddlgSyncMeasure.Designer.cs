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
	partial class OlddlgSyncMeasure
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OlddlgSyncMeasure() : base()
		{
			Load += dlgSyncMeasure_Load;
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
		public System.Windows.Forms.RadioButton OptArchive;
		public System.Windows.Forms.RadioButton OptCurrent;
		public System.Windows.Forms.RadioButton OptIHHA;
		public System.Windows.Forms.GroupBox Frame1;
		private System.Windows.Forms.Button withEventsField_CancelButton_Renamed;
		public System.Windows.Forms.Button CancelButton_Renamed {
			get { return withEventsField_CancelButton_Renamed; }
			set {
				if (withEventsField_CancelButton_Renamed != null) {
					withEventsField_CancelButton_Renamed.Click -= CancelButton_Renamed_Click;
				}
				withEventsField_CancelButton_Renamed = value;
				if (withEventsField_CancelButton_Renamed != null) {
					withEventsField_CancelButton_Renamed.Click += CancelButton_Renamed_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_OKButton;
		public System.Windows.Forms.Button OKButton {
			get { return withEventsField_OKButton; }
			set {
				if (withEventsField_OKButton != null) {
					withEventsField_OKButton.Click -= OKButton_Click;
				}
				withEventsField_OKButton = value;
				if (withEventsField_OKButton != null) {
					withEventsField_OKButton.Click += OKButton_Click;
				}
			}
		}
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OlddlgSyncMeasure));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.OptArchive = new System.Windows.Forms.RadioButton();
			this.OptCurrent = new System.Windows.Forms.RadioButton();
			this.OptIHHA = new System.Windows.Forms.RadioButton();
			this.CancelButton_Renamed = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Dialog Caption";
			this.ClientSize = new System.Drawing.Size(503, 144);
			this.Location = new System.Drawing.Point(230, 313);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
			this.Name = "dlgSyncMeasure";
			this.Frame1.Text = "COP Setup Databases";
			this.Frame1.Size = new System.Drawing.Size(282, 122);
			this.Frame1.Location = new System.Drawing.Point(10, 10);
			this.Frame1.TabIndex = 2;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.OptArchive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptArchive.Text = "Archive";
			this.OptArchive.Size = new System.Drawing.Size(162, 32);
			this.OptArchive.Location = new System.Drawing.Point(30, 80);
			this.OptArchive.TabIndex = 5;
			this.OptArchive.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptArchive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptArchive.BackColor = System.Drawing.SystemColors.Control;
			this.OptArchive.CausesValidation = true;
			this.OptArchive.Enabled = true;
			this.OptArchive.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptArchive.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptArchive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptArchive.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptArchive.TabStop = true;
			this.OptArchive.Checked = false;
			this.OptArchive.Visible = true;
			this.OptArchive.Name = "OptArchive";
			this.OptCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptCurrent.Text = "Current";
			this.OptCurrent.Size = new System.Drawing.Size(242, 32);
			this.OptCurrent.Location = new System.Drawing.Point(30, 50);
			this.OptCurrent.TabIndex = 4;
			this.OptCurrent.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptCurrent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptCurrent.BackColor = System.Drawing.SystemColors.Control;
			this.OptCurrent.CausesValidation = true;
			this.OptCurrent.Enabled = true;
			this.OptCurrent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptCurrent.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptCurrent.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptCurrent.TabStop = true;
			this.OptCurrent.Checked = false;
			this.OptCurrent.Visible = true;
			this.OptCurrent.Name = "OptCurrent";
			this.OptIHHA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptIHHA.Text = "IHHA";
			this.OptIHHA.Size = new System.Drawing.Size(202, 32);
			this.OptIHHA.Location = new System.Drawing.Point(30, 20);
			this.OptIHHA.TabIndex = 3;
			this.OptIHHA.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptIHHA.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptIHHA.BackColor = System.Drawing.SystemColors.Control;
			this.OptIHHA.CausesValidation = true;
			this.OptIHHA.Enabled = true;
			this.OptIHHA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptIHHA.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptIHHA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptIHHA.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptIHHA.TabStop = true;
			this.OptIHHA.Checked = false;
			this.OptIHHA.Visible = true;
			this.OptIHHA.Name = "OptIHHA";
			this.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton = this.CancelButton_Renamed;
			this.CancelButton_Renamed.Text = "Cancel";
			this.CancelButton_Renamed.Size = new System.Drawing.Size(102, 32);
			this.CancelButton_Renamed.Location = new System.Drawing.Point(390, 50);
			this.CancelButton_Renamed.TabIndex = 1;
			this.CancelButton_Renamed.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton_Renamed.CausesValidation = true;
			this.CancelButton_Renamed.Enabled = true;
			this.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default;
			this.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CancelButton_Renamed.TabStop = true;
			this.CancelButton_Renamed.Name = "CancelButton_Renamed";
			this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.OKButton.Text = "OK";
			this.AcceptButton = this.OKButton;
			this.OKButton.Size = new System.Drawing.Size(102, 32);
			this.OKButton.Location = new System.Drawing.Point(390, 10);
			this.OKButton.TabIndex = 0;
			this.OKButton.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OKButton.BackColor = System.Drawing.SystemColors.Control;
			this.OKButton.CausesValidation = true;
			this.OKButton.Enabled = true;
			this.OKButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OKButton.Cursor = System.Windows.Forms.Cursors.Default;
			this.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OKButton.TabStop = true;
			this.OKButton.Name = "OKButton";
			this.Controls.Add(Frame1);
			this.Controls.Add(CancelButton_Renamed);
			this.Controls.Add(OKButton);
			this.Frame1.Controls.Add(OptArchive);
			this.Frame1.Controls.Add(OptCurrent);
			this.Frame1.Controls.Add(OptIHHA);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
