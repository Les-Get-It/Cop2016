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
	partial class OldfrmMeasureModifyValue
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureModifyValue() : base()
		{
			Load += frmMeasureModifyValue_Load;
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
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label4;
		private System.Windows.Forms.TextBox withEventsField_txtTypeinValue;
		public System.Windows.Forms.TextBox txtTypeinValue {
			get { return withEventsField_txtTypeinValue; }
			set {
				if (withEventsField_txtTypeinValue != null) {
					withEventsField_txtTypeinValue.TextChanged -= txtTypeinValue_TextChanged;
				}
				withEventsField_txtTypeinValue = value;
				if (withEventsField_txtTypeinValue != null) {
					withEventsField_txtTypeinValue.TextChanged += txtTypeinValue_TextChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboDateUnit;
		private System.Windows.Forms.CheckBox withEventsField_chkBlank;
		public System.Windows.Forms.CheckBox chkBlank {
			get { return withEventsField_chkBlank; }
			set {
				if (withEventsField_chkBlank != null) {
					withEventsField_chkBlank.CheckStateChanged -= chkBlank_CheckStateChanged;
				}
				withEventsField_chkBlank = value;
				if (withEventsField_chkBlank != null) {
					withEventsField_chkBlank.CheckStateChanged += chkBlank_CheckStateChanged;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstMethods_TabPage0;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.ComboBox cboDestField;
		public System.Windows.Forms.TabPage _sstMethods_TabPage1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.ComboBox cboLookupValues;
		public System.Windows.Forms.TabPage _sstMethods_TabPage2;
		public System.Windows.Forms.ComboBox cboLookupTables;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.TabPage _sstMethods_TabPage3;
		public System.Windows.Forms.TabControl sstMethods;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureModifyValue));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.sstMethods = new System.Windows.Forms.TabControl();
			this._sstMethods_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtTypeinValue = new System.Windows.Forms.TextBox();
			this.cboDateUnit = new System.Windows.Forms.ComboBox();
			this.chkBlank = new System.Windows.Forms.CheckBox();
			this._sstMethods_TabPage1 = new System.Windows.Forms.TabPage();
			this.Label8 = new System.Windows.Forms.Label();
			this.cboDestField = new System.Windows.Forms.ComboBox();
			this._sstMethods_TabPage2 = new System.Windows.Forms.TabPage();
			this.Label2 = new System.Windows.Forms.Label();
			this.cboLookupValues = new System.Windows.Forms.ComboBox();
			this._sstMethods_TabPage3 = new System.Windows.Forms.TabPage();
			this.cboLookupTables = new System.Windows.Forms.ComboBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.sstMethods.SuspendLayout();
			this._sstMethods_TabPage0.SuspendLayout();
			this._sstMethods_TabPage1.SuspendLayout();
			this._sstMethods_TabPage2.SuspendLayout();
			this._sstMethods_TabPage3.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Modify right side of criteria";
			this.ClientSize = new System.Drawing.Size(583, 280);
			this.Location = new System.Drawing.Point(5, 38);
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
			this.Name = "frmMeasureModifyValue";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(128, 27);
			this.cmdUpdate.Location = new System.Drawing.Point(157, 227);
			this.cmdUpdate.TabIndex = 10;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(120, 27);
			this.cmdCancel.Location = new System.Drawing.Point(302, 227);
			this.cmdCancel.TabIndex = 9;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.sstMethods.Size = new System.Drawing.Size(544, 194);
			this.sstMethods.Location = new System.Drawing.Point(15, 18);
			this.sstMethods.TabIndex = 0;
			this.sstMethods.ItemSize = new System.Drawing.Size(42, 22);
			this.sstMethods.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstMethods.Name = "sstMethods";
			this._sstMethods_TabPage0.Text = "Value";
			this.Label1.Text = "Value:";
			this.Label1.Size = new System.Drawing.Size(54, 23);
			this.Label1.Location = new System.Drawing.Point(107, 85);
			this.Label1.TabIndex = 2;
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
			this.Label11.Text = "Date/Time Unit (if the field is a date or time field)?";
			this.Label11.Size = new System.Drawing.Size(188, 32);
			this.Label11.Location = new System.Drawing.Point(290, 52);
			this.Label11.TabIndex = 12;
			this.Label11.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label11.BackColor = System.Drawing.SystemColors.Control;
			this.Label11.Enabled = true;
			this.Label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label11.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label11.UseMnemonic = true;
			this.Label11.Visible = true;
			this.Label11.AutoSize = false;
			this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label11.Name = "Label11";
			this.Label4.Text = "OR";
			this.Label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.Size = new System.Drawing.Size(28, 23);
			this.Label4.Location = new System.Drawing.Point(162, 118);
			this.Label4.TabIndex = 14;
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
			this.txtTypeinValue.AutoSize = false;
			this.txtTypeinValue.Size = new System.Drawing.Size(100, 24);
			this.txtTypeinValue.Location = new System.Drawing.Point(163, 85);
			this.txtTypeinValue.TabIndex = 1;
			this.txtTypeinValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtTypeinValue.AcceptsReturn = true;
			this.txtTypeinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtTypeinValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtTypeinValue.CausesValidation = true;
			this.txtTypeinValue.Enabled = true;
			this.txtTypeinValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTypeinValue.HideSelection = true;
			this.txtTypeinValue.ReadOnly = false;
			this.txtTypeinValue.MaxLength = 0;
			this.txtTypeinValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTypeinValue.Multiline = false;
			this.txtTypeinValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtTypeinValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTypeinValue.TabStop = true;
			this.txtTypeinValue.Visible = true;
			this.txtTypeinValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtTypeinValue.Name = "txtTypeinValue";
			this.cboDateUnit.Size = new System.Drawing.Size(68, 27);
			this.cboDateUnit.Location = new System.Drawing.Point(290, 83);
			this.cboDateUnit.Items.AddRange(new object[] {
				"Years",
				"Months",
				"Days",
				"Hours",
				"Minutes",
				"Seconds"
			});
			this.cboDateUnit.TabIndex = 11;
			this.cboDateUnit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboDateUnit.BackColor = System.Drawing.SystemColors.Window;
			this.cboDateUnit.CausesValidation = true;
			this.cboDateUnit.Enabled = true;
			this.cboDateUnit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboDateUnit.IntegralHeight = true;
			this.cboDateUnit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboDateUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboDateUnit.Sorted = false;
			this.cboDateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboDateUnit.TabStop = true;
			this.cboDateUnit.Visible = true;
			this.cboDateUnit.Name = "cboDateUnit";
			this.chkBlank.Text = " Blank";
			this.chkBlank.Size = new System.Drawing.Size(232, 29);
			this.chkBlank.Location = new System.Drawing.Point(164, 134);
			this.chkBlank.TabIndex = 13;
			this.chkBlank.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkBlank.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkBlank.BackColor = System.Drawing.SystemColors.Control;
			this.chkBlank.CausesValidation = true;
			this.chkBlank.Enabled = true;
			this.chkBlank.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkBlank.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkBlank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkBlank.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkBlank.TabStop = true;
			this.chkBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkBlank.Visible = true;
			this.chkBlank.Name = "chkBlank";
			this._sstMethods_TabPage1.Text = "Field";
			this.Label8.Text = "Field:";
			this.Label8.Size = new System.Drawing.Size(74, 18);
			this.Label8.Location = new System.Drawing.Point(69, 93);
			this.Label8.TabIndex = 4;
			this.Label8.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.cboDestField.Size = new System.Drawing.Size(309, 27);
			this.cboDestField.Location = new System.Drawing.Point(157, 89);
			this.cboDestField.TabIndex = 3;
			this.cboDestField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboDestField.BackColor = System.Drawing.SystemColors.Window;
			this.cboDestField.CausesValidation = true;
			this.cboDestField.Enabled = true;
			this.cboDestField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboDestField.IntegralHeight = true;
			this.cboDestField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboDestField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboDestField.Sorted = false;
			this.cboDestField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboDestField.TabStop = true;
			this.cboDestField.Visible = true;
			this.cboDestField.Name = "cboDestField";
			this._sstMethods_TabPage2.Text = "Lookup Value";
			this.Label2.Text = "Lookup Value:";
			this.Label2.Size = new System.Drawing.Size(94, 19);
			this.Label2.Location = new System.Drawing.Point(27, 95);
			this.Label2.TabIndex = 6;
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
			this.cboLookupValues.Size = new System.Drawing.Size(393, 27);
			this.cboLookupValues.Location = new System.Drawing.Point(132, 94);
			this.cboLookupValues.TabIndex = 5;
			this.cboLookupValues.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupValues.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupValues.CausesValidation = true;
			this.cboLookupValues.Enabled = true;
			this.cboLookupValues.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupValues.IntegralHeight = true;
			this.cboLookupValues.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupValues.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupValues.Sorted = false;
			this.cboLookupValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupValues.TabStop = true;
			this.cboLookupValues.Visible = true;
			this.cboLookupValues.Name = "cboLookupValues";
			this._sstMethods_TabPage3.Text = "Lookup Table";
			this.cboLookupTables.Size = new System.Drawing.Size(364, 27);
			this.cboLookupTables.Location = new System.Drawing.Point(139, 88);
			this.cboLookupTables.TabIndex = 7;
			this.cboLookupTables.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupTables.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupTables.CausesValidation = true;
			this.cboLookupTables.Enabled = true;
			this.cboLookupTables.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupTables.IntegralHeight = true;
			this.cboLookupTables.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupTables.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupTables.Sorted = false;
			this.cboLookupTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupTables.TabStop = true;
			this.cboLookupTables.Visible = true;
			this.cboLookupTables.Name = "cboLookupTables";
			this.Label16.Text = "Lookup Table";
			this.Label16.Size = new System.Drawing.Size(103, 20);
			this.Label16.Location = new System.Drawing.Point(32, 93);
			this.Label16.TabIndex = 8;
			this.Label16.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label16.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label16.BackColor = System.Drawing.SystemColors.Control;
			this.Label16.Enabled = true;
			this.Label16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label16.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label16.UseMnemonic = true;
			this.Label16.Visible = true;
			this.Label16.AutoSize = false;
			this.Label16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label16.Name = "Label16";
			this.Controls.Add(cmdUpdate);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(sstMethods);
			this.sstMethods.Controls.Add(_sstMethods_TabPage0);
			this.sstMethods.Controls.Add(_sstMethods_TabPage1);
			this.sstMethods.Controls.Add(_sstMethods_TabPage2);
			this.sstMethods.Controls.Add(_sstMethods_TabPage3);
			this._sstMethods_TabPage0.Controls.Add(Label1);
			this._sstMethods_TabPage0.Controls.Add(Label11);
			this._sstMethods_TabPage0.Controls.Add(Label4);
			this._sstMethods_TabPage0.Controls.Add(txtTypeinValue);
			this._sstMethods_TabPage0.Controls.Add(cboDateUnit);
			this._sstMethods_TabPage0.Controls.Add(chkBlank);
			this._sstMethods_TabPage1.Controls.Add(Label8);
			this._sstMethods_TabPage1.Controls.Add(cboDestField);
			this._sstMethods_TabPage2.Controls.Add(Label2);
			this._sstMethods_TabPage2.Controls.Add(cboLookupValues);
			this._sstMethods_TabPage3.Controls.Add(cboLookupTables);
			this._sstMethods_TabPage3.Controls.Add(Label16);
			this.sstMethods.ResumeLayout(false);
			this._sstMethods_TabPage0.ResumeLayout(false);
			this._sstMethods_TabPage1.ResumeLayout(false);
			this._sstMethods_TabPage2.ResumeLayout(false);
			this._sstMethods_TabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
