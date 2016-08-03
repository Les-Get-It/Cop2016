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
	partial class OldfrmHospStatEditGroupField
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmHospStatEditGroupField() : base()
		{
			Load += frmHospStatEditGroupField_Load;
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
		public System.Windows.Forms.ListBox lstHospStatFields;
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
		private System.Windows.Forms.Button withEventsField_cmdSelect;
		public System.Windows.Forms.Button cmdSelect {
			get { return withEventsField_cmdSelect; }
			set {
				if (withEventsField_cmdSelect != null) {
					withEventsField_cmdSelect.Click -= cmdSelect_Click;
				}
				withEventsField_cmdSelect = value;
				if (withEventsField_cmdSelect != null) {
					withEventsField_cmdSelect.Click += cmdSelect_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label3;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmHospStatEditGroupField));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstHospStatFields = new System.Windows.Forms.ListBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdSelect = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Add selected fields to the group";
			this.ClientSize = new System.Drawing.Size(499, 187);
			this.Location = new System.Drawing.Point(4, 28);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ControlBox = true;
			this.Enabled = true;
			this.KeyPreview = false;
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.HelpButton = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.Name = "frmHospStatEditGroupField";
			this.lstHospStatFields.Size = new System.Drawing.Size(329, 107);
			this.lstHospStatFields.Location = new System.Drawing.Point(142, 10);
			this.lstHospStatFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstHospStatFields.TabIndex = 2;
			this.lstHospStatFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstHospStatFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstHospStatFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstHospStatFields.CausesValidation = true;
			this.lstHospStatFields.Enabled = true;
			this.lstHospStatFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstHospStatFields.IntegralHeight = true;
			this.lstHospStatFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstHospStatFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstHospStatFields.Sorted = false;
			this.lstHospStatFields.TabStop = true;
			this.lstHospStatFields.Visible = true;
			this.lstHospStatFields.MultiColumn = false;
			this.lstHospStatFields.Name = "lstHospStatFields";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(92, 27);
			this.cmdCancel.Location = new System.Drawing.Point(314, 149);
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
			this.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelect.Text = "Select";
			this.cmdSelect.Size = new System.Drawing.Size(100, 27);
			this.cmdSelect.Location = new System.Drawing.Point(207, 149);
			this.cmdSelect.TabIndex = 0;
			this.cmdSelect.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSelect.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelect.CausesValidation = true;
			this.cmdSelect.Enabled = true;
			this.cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelect.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelect.TabStop = true;
			this.cmdSelect.Name = "cmdSelect";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = "Hosp. Stat. Fields";
			this.Label2.Size = new System.Drawing.Size(130, 24);
			this.Label2.Location = new System.Drawing.Point(2, 13);
			this.Label2.TabIndex = 4;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label3.Text = "Hold down the Shift key to make multiple selections";
			this.Label3.Size = new System.Drawing.Size(325, 23);
			this.Label3.Location = new System.Drawing.Point(144, 120);
			this.Label3.TabIndex = 3;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Controls.Add(lstHospStatFields);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdSelect);
			this.Controls.Add(Label2);
			this.Controls.Add(Label3);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
