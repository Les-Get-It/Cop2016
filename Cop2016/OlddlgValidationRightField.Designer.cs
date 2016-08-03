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
	partial class OlddlgValidationRightField
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OlddlgValidationRightField() : base()
		{
			Load += dlgValidationRightField_Load;
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
		public System.Windows.Forms.ComboBox cboField;
		public System.Windows.Forms.TextBox txtPreviousField;
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
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OlddlgValidationRightField));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cboField = new System.Windows.Forms.ComboBox();
			this.txtPreviousField = new System.Windows.Forms.TextBox();
			this.CancelButton_Renamed = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Change Field";
			this.ClientSize = new System.Drawing.Size(503, 88);
			this.Location = new System.Drawing.Point(230, 313);
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
			this.Name = "dlgValidationRightField";
			this.cboField.Size = new System.Drawing.Size(362, 27);
			this.cboField.Location = new System.Drawing.Point(40, 40);
			this.cboField.TabIndex = 4;
			this.cboField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboField.BackColor = System.Drawing.SystemColors.Window;
			this.cboField.CausesValidation = true;
			this.cboField.Enabled = true;
			this.cboField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboField.IntegralHeight = true;
			this.cboField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboField.Sorted = false;
			this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboField.TabStop = true;
			this.cboField.Visible = true;
			this.cboField.Name = "cboField";
			this.txtPreviousField.AutoSize = false;
			this.txtPreviousField.Enabled = false;
			this.txtPreviousField.Size = new System.Drawing.Size(362, 24);
			this.txtPreviousField.Location = new System.Drawing.Point(40, 10);
			this.txtPreviousField.TabIndex = 2;
			this.txtPreviousField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtPreviousField.AcceptsReturn = true;
			this.txtPreviousField.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtPreviousField.BackColor = System.Drawing.SystemColors.Window;
			this.txtPreviousField.CausesValidation = true;
			this.txtPreviousField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPreviousField.HideSelection = true;
			this.txtPreviousField.ReadOnly = false;
			this.txtPreviousField.MaxLength = 0;
			this.txtPreviousField.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtPreviousField.Multiline = false;
			this.txtPreviousField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtPreviousField.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPreviousField.TabStop = true;
			this.txtPreviousField.Visible = true;
			this.txtPreviousField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPreviousField.Name = "txtPreviousField";
			this.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton_Renamed.Text = "Cancel";
			this.CancelButton_Renamed.Size = new System.Drawing.Size(72, 32);
			this.CancelButton_Renamed.Location = new System.Drawing.Point(420, 50);
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
			this.OKButton.Size = new System.Drawing.Size(72, 32);
			this.OKButton.Location = new System.Drawing.Point(420, 10);
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
			this.Label2.Text = "To";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.Size = new System.Drawing.Size(62, 22);
			this.Label2.Location = new System.Drawing.Point(0, 40);
			this.Label2.TabIndex = 5;
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
			this.Label1.Text = "From";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(62, 22);
			this.Label1.Location = new System.Drawing.Point(0, 10);
			this.Label1.TabIndex = 3;
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
			this.Controls.Add(cboField);
			this.Controls.Add(txtPreviousField);
			this.Controls.Add(CancelButton_Renamed);
			this.Controls.Add(OKButton);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
