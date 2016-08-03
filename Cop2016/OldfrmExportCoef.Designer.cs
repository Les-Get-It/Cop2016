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
	partial class OldfrmExportCoef
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmExportCoef() : base()
		{
			Load += frmExportCoef_Load;
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
		public System.Windows.Forms.ListBox lstPeriods;
		public System.Windows.Forms.TextBox txtMemoField;
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
		private System.Windows.Forms.Button withEventsField_cmdExport;
		public System.Windows.Forms.Button cmdExport {
			get { return withEventsField_cmdExport; }
			set {
				if (withEventsField_cmdExport != null) {
					withEventsField_cmdExport.Click -= cmdExport_Click;
				}
				withEventsField_cmdExport = value;
				if (withEventsField_cmdExport != null) {
					withEventsField_cmdExport.Click += cmdExport_Click;
				}
			}
		}
		public System.Windows.Forms.PictureBox dbgMemoField;
		public System.Windows.Forms.PictureBox rdcMemoField;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmExportCoef));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstPeriods = new System.Windows.Forms.ListBox();
			this.txtMemoField = new System.Windows.Forms.TextBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdExport = new System.Windows.Forms.Button();
			this.dbgMemoField = new System.Windows.Forms.PictureBox();
			this.rdcMemoField = new System.Windows.Forms.PictureBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Create Risk Adjusment Coefficient Update for Home";
			this.ClientSize = new System.Drawing.Size(502, 184);
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
			this.Name = "frmExportCoef";
			this.lstPeriods.Size = new System.Drawing.Size(262, 90);
			this.lstPeriods.Location = new System.Drawing.Point(40, 40);
			this.lstPeriods.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstPeriods.TabIndex = 5;
			this.lstPeriods.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstPeriods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstPeriods.BackColor = System.Drawing.SystemColors.Window;
			this.lstPeriods.CausesValidation = true;
			this.lstPeriods.Enabled = true;
			this.lstPeriods.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstPeriods.IntegralHeight = true;
			this.lstPeriods.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstPeriods.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstPeriods.Sorted = false;
			this.lstPeriods.TabStop = true;
			this.lstPeriods.Visible = true;
			this.lstPeriods.MultiColumn = false;
			this.lstPeriods.Name = "lstPeriods";
			this.txtMemoField.AutoSize = false;
			this.txtMemoField.Size = new System.Drawing.Size(53, 23);
			this.txtMemoField.Location = new System.Drawing.Point(282, 513);
			this.txtMemoField.TabIndex = 3;
			this.txtMemoField.Visible = false;
			this.txtMemoField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtMemoField.AcceptsReturn = true;
			this.txtMemoField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtMemoField.BackColor = System.Drawing.SystemColors.Window;
			this.txtMemoField.CausesValidation = true;
			this.txtMemoField.Enabled = true;
			this.txtMemoField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMemoField.HideSelection = true;
			this.txtMemoField.ReadOnly = false;
			this.txtMemoField.MaxLength = 0;
			this.txtMemoField.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMemoField.Multiline = false;
			this.txtMemoField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMemoField.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMemoField.TabStop = true;
			this.txtMemoField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMemoField.Name = "txtMemoField";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(104, 27);
			this.cmdCancel.Location = new System.Drawing.Point(190, 140);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExport.Text = "Export Setup";
			this.cmdExport.Size = new System.Drawing.Size(108, 27);
			this.cmdExport.Location = new System.Drawing.Point(40, 140);
			this.cmdExport.TabIndex = 0;
			this.cmdExport.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdExport.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExport.CausesValidation = true;
			this.cmdExport.Enabled = true;
			this.cmdExport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExport.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExport.TabStop = true;
			this.cmdExport.Name = "cmdExport";
			this.dbgMemoField.Size = new System.Drawing.Size(227, 80);
			this.dbgMemoField.Location = new System.Drawing.Point(349, 473);
			this.dbgMemoField.TabIndex = 2;
			this.dbgMemoField.Visible = false;
			this.dbgMemoField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.dbgMemoField.Dock = System.Windows.Forms.DockStyle.None;
			this.dbgMemoField.BackColor = System.Drawing.SystemColors.Control;
			this.dbgMemoField.CausesValidation = true;
			this.dbgMemoField.Enabled = true;
			this.dbgMemoField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dbgMemoField.Cursor = System.Windows.Forms.Cursors.Default;
			this.dbgMemoField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dbgMemoField.TabStop = true;
			this.dbgMemoField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.dbgMemoField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dbgMemoField.Name = "dbgMemoField";
			this.rdcMemoField.BackColor = System.Drawing.SystemColors.Window;
			this.rdcMemoField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rdcMemoField.Size = new System.Drawing.Size(237, 28);
			this.rdcMemoField.Location = new System.Drawing.Point(40, 512);
			this.rdcMemoField.TabIndex = 4;
			this.rdcMemoField.Visible = false;
			this.rdcMemoField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.rdcMemoField.Dock = System.Windows.Forms.DockStyle.None;
			this.rdcMemoField.CausesValidation = true;
			this.rdcMemoField.Enabled = true;
			this.rdcMemoField.Cursor = System.Windows.Forms.Cursors.Default;
			this.rdcMemoField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.rdcMemoField.TabStop = true;
			this.rdcMemoField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.rdcMemoField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.rdcMemoField.Name = "rdcMemoField";
			this.Label1.Text = "All these Periods will be exported to the file";
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(422, 22);
			this.Label1.Location = new System.Drawing.Point(20, 10);
			this.Label1.TabIndex = 6;
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
			this.Controls.Add(lstPeriods);
			this.Controls.Add(txtMemoField);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdExport);
			this.Controls.Add(dbgMemoField);
			this.Controls.Add(rdcMemoField);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
