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
	partial class OlddlgImportLookupValues
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OlddlgImportLookupValues() : base()
		{
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
		public System.Windows.Forms.CheckBox chkStripDecimal;
		public System.Windows.Forms.GroupBox Frame2;
		public System.Windows.Forms.RadioButton OptInsert;
		public System.Windows.Forms.RadioButton OptDelete;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.RadioButton optID;
		public System.Windows.Forms.RadioButton OptValue;
		public System.Windows.Forms.GroupBox fraLk;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OlddlgImportLookupValues));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.chkStripDecimal = new System.Windows.Forms.CheckBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.OptInsert = new System.Windows.Forms.RadioButton();
			this.OptDelete = new System.Windows.Forms.RadioButton();
			this.fraLk = new System.Windows.Forms.GroupBox();
			this.optID = new System.Windows.Forms.RadioButton();
			this.OptValue = new System.Windows.Forms.RadioButton();
			this.CancelButton_Renamed = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.Frame2.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.fraLk.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Text = "Import Lookup Values";
			this.ClientSize = new System.Drawing.Size(660, 218);
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
			this.Name = "dlgImportLookupValues";
			this.Frame2.Text = "Strip";
			this.Frame2.Size = new System.Drawing.Size(502, 72);
			this.Frame2.Location = new System.Drawing.Point(10, 110);
			this.Frame2.TabIndex = 8;
			this.Frame2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.chkStripDecimal.Text = "Decimal Values";
			this.chkStripDecimal.Size = new System.Drawing.Size(422, 32);
			this.chkStripDecimal.Location = new System.Drawing.Point(30, 20);
			this.chkStripDecimal.TabIndex = 9;
			this.chkStripDecimal.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkStripDecimal.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkStripDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkStripDecimal.BackColor = System.Drawing.SystemColors.Control;
			this.chkStripDecimal.CausesValidation = true;
			this.chkStripDecimal.Enabled = true;
			this.chkStripDecimal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkStripDecimal.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkStripDecimal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkStripDecimal.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkStripDecimal.TabStop = true;
			this.chkStripDecimal.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkStripDecimal.Visible = true;
			this.chkStripDecimal.Name = "chkStripDecimal";
			this.Frame1.Text = "Overwrite Previous Values or Add";
			this.Frame1.Size = new System.Drawing.Size(324, 94);
			this.Frame1.Location = new System.Drawing.Point(10, 10);
			this.Frame1.TabIndex = 5;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.OptInsert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptInsert.Text = "Add Values in Addition to Existing Values";
			this.OptInsert.Size = new System.Drawing.Size(302, 19);
			this.OptInsert.Location = new System.Drawing.Point(17, 50);
			this.OptInsert.TabIndex = 7;
			this.OptInsert.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptInsert.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptInsert.BackColor = System.Drawing.SystemColors.Control;
			this.OptInsert.CausesValidation = true;
			this.OptInsert.Enabled = true;
			this.OptInsert.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptInsert.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptInsert.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptInsert.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptInsert.TabStop = true;
			this.OptInsert.Checked = false;
			this.OptInsert.Visible = true;
			this.OptInsert.Name = "OptInsert";
			this.OptDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptDelete.Text = "Overwrite (Deleta All old Values)";
			this.OptDelete.Size = new System.Drawing.Size(222, 19);
			this.OptDelete.Location = new System.Drawing.Point(17, 20);
			this.OptDelete.TabIndex = 6;
			this.OptDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptDelete.BackColor = System.Drawing.SystemColors.Control;
			this.OptDelete.CausesValidation = true;
			this.OptDelete.Enabled = true;
			this.OptDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptDelete.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptDelete.TabStop = true;
			this.OptDelete.Checked = false;
			this.OptDelete.Visible = true;
			this.OptDelete.Name = "OptDelete";
			this.fraLk.Text = "First Value in List are:";
			this.fraLk.Size = new System.Drawing.Size(154, 94);
			this.fraLk.Location = new System.Drawing.Point(360, 10);
			this.fraLk.TabIndex = 2;
			this.fraLk.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fraLk.BackColor = System.Drawing.SystemColors.Control;
			this.fraLk.Enabled = true;
			this.fraLk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraLk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraLk.Visible = true;
			this.fraLk.Padding = new System.Windows.Forms.Padding(0);
			this.fraLk.Name = "fraLk";
			this.optID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optID.Text = "ID";
			this.optID.Size = new System.Drawing.Size(122, 19);
			this.optID.Location = new System.Drawing.Point(17, 30);
			this.optID.TabIndex = 4;
			this.optID.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optID.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optID.BackColor = System.Drawing.SystemColors.Control;
			this.optID.CausesValidation = true;
			this.optID.Enabled = true;
			this.optID.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optID.Cursor = System.Windows.Forms.Cursors.Default;
			this.optID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optID.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optID.TabStop = true;
			this.optID.Checked = false;
			this.optID.Visible = true;
			this.optID.Name = "optID";
			this.OptValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptValue.Text = "Lookup Value";
			this.OptValue.Size = new System.Drawing.Size(122, 19);
			this.OptValue.Location = new System.Drawing.Point(17, 60);
			this.OptValue.TabIndex = 3;
			this.OptValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.OptValue.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OptValue.BackColor = System.Drawing.SystemColors.Control;
			this.OptValue.CausesValidation = true;
			this.OptValue.Enabled = true;
			this.OptValue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OptValue.Cursor = System.Windows.Forms.Cursors.Default;
			this.OptValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OptValue.Appearance = System.Windows.Forms.Appearance.Normal;
			this.OptValue.TabStop = true;
			this.OptValue.Checked = false;
			this.OptValue.Visible = true;
			this.OptValue.Name = "OptValue";
			this.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CancelButton_Renamed.Text = "Cancel";
			this.CancelButton_Renamed.Size = new System.Drawing.Size(102, 32);
			this.CancelButton_Renamed.Location = new System.Drawing.Point(540, 50);
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
			this.OKButton.Size = new System.Drawing.Size(102, 32);
			this.OKButton.Location = new System.Drawing.Point(540, 10);
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
			this.Controls.Add(Frame2);
			this.Controls.Add(Frame1);
			this.Controls.Add(fraLk);
			this.Controls.Add(CancelButton_Renamed);
			this.Controls.Add(OKButton);
			this.Frame2.Controls.Add(chkStripDecimal);
			this.Frame1.Controls.Add(OptInsert);
			this.Frame1.Controls.Add(OptDelete);
			this.fraLk.Controls.Add(optID);
			this.fraLk.Controls.Add(OptValue);
			this.Frame2.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.fraLk.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
