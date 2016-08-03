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
	partial class OldfrmSectionAddPatientField
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSectionAddPatientField() : base()
		{
			Load += frmSectionAddPatientField_Load;
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
		public System.Windows.Forms.ListBox lstIndicators;
		private System.Windows.Forms.ComboBox withEventsField_cboPatientFields;
		public System.Windows.Forms.ComboBox cboPatientFields {
			get { return withEventsField_cboPatientFields; }
			set {
				if (withEventsField_cboPatientFields != null) {
					withEventsField_cboPatientFields.SelectedIndexChanged -= cboPatientFields_SelectedIndexChanged;
				}
				withEventsField_cboPatientFields = value;
				if (withEventsField_cboPatientFields != null) {
					withEventsField_cboPatientFields.SelectedIndexChanged += cboPatientFields_SelectedIndexChanged;
				}
			}
		}
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
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSectionAddPatientField));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstIndicators = new System.Windows.Forms.ListBox();
			this.cboPatientFields = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdSelect = new System.Windows.Forms.Button();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Add a patient field to the selected indicator";
			this.ClientSize = new System.Drawing.Size(532, 307);
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
			this.Name = "frmSectionAddPatientField";
			this.lstIndicators.Size = new System.Drawing.Size(329, 107);
			this.lstIndicators.Location = new System.Drawing.Point(122, 49);
			this.lstIndicators.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstIndicators.TabIndex = 5;
			this.lstIndicators.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstIndicators.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstIndicators.BackColor = System.Drawing.SystemColors.Window;
			this.lstIndicators.CausesValidation = true;
			this.lstIndicators.Enabled = true;
			this.lstIndicators.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstIndicators.IntegralHeight = true;
			this.lstIndicators.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstIndicators.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstIndicators.Sorted = false;
			this.lstIndicators.TabStop = true;
			this.lstIndicators.Visible = true;
			this.lstIndicators.MultiColumn = false;
			this.lstIndicators.Name = "lstIndicators";
			this.cboPatientFields.Size = new System.Drawing.Size(335, 27);
			this.cboPatientFields.Location = new System.Drawing.Point(118, 9);
			this.cboPatientFields.TabIndex = 3;
			this.cboPatientFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboPatientFields.BackColor = System.Drawing.SystemColors.Window;
			this.cboPatientFields.CausesValidation = true;
			this.cboPatientFields.Enabled = true;
			this.cboPatientFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboPatientFields.IntegralHeight = true;
			this.cboPatientFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboPatientFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboPatientFields.Sorted = false;
			this.cboPatientFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboPatientFields.TabStop = true;
			this.cboPatientFields.Visible = true;
			this.cboPatientFields.Name = "cboPatientFields";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(92, 27);
			this.cmdCancel.Location = new System.Drawing.Point(258, 180);
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
			this.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelect.Text = "Select";
			this.cmdSelect.Size = new System.Drawing.Size(100, 27);
			this.cmdSelect.Location = new System.Drawing.Point(149, 180);
			this.cmdSelect.TabIndex = 1;
			this.cmdSelect.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSelect.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelect.CausesValidation = true;
			this.cmdSelect.Enabled = true;
			this.cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelect.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelect.TabStop = true;
			this.cmdSelect.Name = "cmdSelect";
			this.Label4.Text = "Note:  Fixed Fields Cannot be tied to Indicators";
			this.Label4.Size = new System.Drawing.Size(502, 22);
			this.Label4.Location = new System.Drawing.Point(20, 270);
			this.Label4.TabIndex = 7;
			this.Label4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label3.Text = "Hold down the Shift key to make multiple selections";
			this.Label3.Size = new System.Drawing.Size(325, 23);
			this.Label3.Location = new System.Drawing.Point(120, 153);
			this.Label3.TabIndex = 6;
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
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = "Indicator:";
			this.Label2.Size = new System.Drawing.Size(92, 24);
			this.Label2.Location = new System.Drawing.Point(18, 49);
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
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Patient Fields";
			this.Label1.Size = new System.Drawing.Size(105, 20);
			this.Label1.Location = new System.Drawing.Point(5, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Controls.Add(lstIndicators);
			this.Controls.Add(cboPatientFields);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdSelect);
			this.Controls.Add(Label4);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
