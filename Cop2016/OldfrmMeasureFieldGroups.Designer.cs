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
	partial class OldfrmMeasureFieldGroups
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureFieldGroups() : base()
		{
			Load += frmMeasureFieldGroups_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdPrint;
		public System.Windows.Forms.Button cmdPrint {
			get { return withEventsField_cmdPrint; }
			set {
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click -= cmdPrint_Click;
				}
				withEventsField_cmdPrint = value;
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click += cmdPrint_Click;
				}
			}
		}
		public AxMSRDC.AxMSRDC MSRDCGroups;
		private AxMSDBGrid.AxDBGrid withEventsField_dbgGroups;
		public AxMSDBGrid.AxDBGrid dbgGroups {
			get { return withEventsField_dbgGroups; }
			set {
				if (withEventsField_dbgGroups != null) {
					withEventsField_dbgGroups.KeyDownEvent -= dbgGroups_KeyDownEvent;
				}
				withEventsField_dbgGroups = value;
				if (withEventsField_dbgGroups != null) {
					withEventsField_dbgGroups.KeyDownEvent += dbgGroups_KeyDownEvent;
				}
			}
		}
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureFieldGroups));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdPrint = new System.Windows.Forms.Button();
			this.MSRDCGroups = new AxMSRDC.AxMSRDC();
			this.dbgGroups = new AxMSDBGrid.AxDBGrid();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.MSRDCGroups).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgGroups).BeginInit();
			this.Text = "Measure Field Group List";
			this.ClientSize = new System.Drawing.Size(810, 379);
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
			this.Name = "frmMeasureFieldGroups";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "Print";
			this.cmdPrint.Size = new System.Drawing.Size(82, 32);
			this.cmdPrint.Location = new System.Drawing.Point(570, 10);
			this.cmdPrint.TabIndex = 2;
			this.cmdPrint.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			MSRDCGroups.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("MSRDCGroups.OcxState");
			this.MSRDCGroups.Size = new System.Drawing.Size(282, 32);
			this.MSRDCGroups.Location = new System.Drawing.Point(30, 340);
			this.MSRDCGroups.Visible = false;
			this.MSRDCGroups.Name = "MSRDCGroups";
			dbgGroups.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgGroups.OcxState");
			this.dbgGroups.Size = new System.Drawing.Size(772, 302);
			this.dbgGroups.Location = new System.Drawing.Point(20, 50);
			this.dbgGroups.TabIndex = 1;
			this.dbgGroups.Name = "dbgGroups";
			this.Label1.Text = "Measure Field Group Logic";
			this.Label1.Font = new System.Drawing.Font("Arial", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(402, 32);
			this.Label1.Location = new System.Drawing.Point(20, 10);
			this.Label1.TabIndex = 0;
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
			this.Controls.Add(cmdPrint);
			this.Controls.Add(MSRDCGroups);
			this.Controls.Add(dbgGroups);
			this.Controls.Add(Label1);
			((System.ComponentModel.ISupportInitialize)this.dbgGroups).EndInit();
			((System.ComponentModel.ISupportInitialize)this.MSRDCGroups).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
