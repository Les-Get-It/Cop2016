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
	partial class OldfrmTableValidationAddMsg
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmTableValidationAddMsg() : base()
		{
			Load += frmTableValidationAddMsg_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdRemoveField;
		public System.Windows.Forms.Button cmdRemoveField {
			get { return withEventsField_cmdRemoveField; }
			set {
				if (withEventsField_cmdRemoveField != null) {
					withEventsField_cmdRemoveField.Click -= cmdRemoveField_Click;
				}
				withEventsField_cmdRemoveField = value;
				if (withEventsField_cmdRemoveField != null) {
					withEventsField_cmdRemoveField.Click += cmdRemoveField_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddfield;
		public System.Windows.Forms.Button cmdAddfield {
			get { return withEventsField_cmdAddfield; }
			set {
				if (withEventsField_cmdAddfield != null) {
					withEventsField_cmdAddfield.Click -= cmdAddField_Click;
				}
				withEventsField_cmdAddfield = value;
				if (withEventsField_cmdAddfield != null) {
					withEventsField_cmdAddfield.Click += cmdAddField_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstFieldstoValidate;
		public System.Windows.Forms.ComboBox cboFieldList;
		private System.Windows.Forms.RadioButton withEventsField_opt3UpdateField;
		public System.Windows.Forms.RadioButton opt3UpdateField {
			get { return withEventsField_opt3UpdateField; }
			set {
				if (withEventsField_opt3UpdateField != null) {
					withEventsField_opt3UpdateField.CheckedChanged -= opt3UpdateField_CheckedChanged;
				}
				withEventsField_opt3UpdateField = value;
				if (withEventsField_opt3UpdateField != null) {
					withEventsField_opt3UpdateField.CheckedChanged += opt3UpdateField_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_opt2Delete;
		public System.Windows.Forms.RadioButton opt2Delete {
			get { return withEventsField_opt2Delete; }
			set {
				if (withEventsField_opt2Delete != null) {
					withEventsField_opt2Delete.CheckedChanged -= opt2Delete_CheckedChanged;
				}
				withEventsField_opt2Delete = value;
				if (withEventsField_opt2Delete != null) {
					withEventsField_opt2Delete.CheckedChanged += opt2Delete_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_opt1Save;
		public System.Windows.Forms.RadioButton opt1Save {
			get { return withEventsField_opt1Save; }
			set {
				if (withEventsField_opt1Save != null) {
					withEventsField_opt1Save.CheckedChanged -= opt1Save_CheckedChanged;
				}
				withEventsField_opt1Save = value;
				if (withEventsField_opt1Save != null) {
					withEventsField_opt1Save.CheckedChanged += opt1Save_CheckedChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.TextBox txtMessage;
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
		private System.Windows.Forms.Button withEventsField_cmdAdd;
		public System.Windows.Forms.Button cmdAdd {
			get { return withEventsField_cmdAdd; }
			set {
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click -= cmdAdd_Click;
				}
				withEventsField_cmdAdd = value;
				if (withEventsField_cmdAdd != null) {
					withEventsField_cmdAdd.Click += cmdAdd_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label2;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmTableValidationAddMsg));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.cmdRemoveField = new System.Windows.Forms.Button();
			this.cmdAddfield = new System.Windows.Forms.Button();
			this.lstFieldstoValidate = new System.Windows.Forms.ListBox();
			this.cboFieldList = new System.Windows.Forms.ComboBox();
			this.opt3UpdateField = new System.Windows.Forms.RadioButton();
			this.opt2Delete = new System.Windows.Forms.RadioButton();
			this.opt1Save = new System.Windows.Forms.RadioButton();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Add Validation Message";
			this.ClientSize = new System.Drawing.Size(614, 495);
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
			this.Name = "frmTableValidationAddMsg";
			this.Frame1.Text = "When User Takes This Action";
			this.Frame1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.Size = new System.Drawing.Size(495, 308);
			this.Frame1.Location = new System.Drawing.Point(40, 128);
			this.Frame1.TabIndex = 6;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.cmdRemoveField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveField.Text = "Remove from List";
			this.cmdRemoveField.Size = new System.Drawing.Size(123, 30);
			this.cmdRemoveField.Location = new System.Drawing.Point(363, 169);
			this.cmdRemoveField.TabIndex = 11;
			this.cmdRemoveField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveField.CausesValidation = true;
			this.cmdRemoveField.Enabled = true;
			this.cmdRemoveField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveField.TabStop = true;
			this.cmdRemoveField.Name = "cmdRemoveField";
			this.cmdAddfield.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddfield.Text = "Add To List";
			this.cmdAddfield.Size = new System.Drawing.Size(120, 27);
			this.cmdAddfield.Location = new System.Drawing.Point(364, 117);
			this.cmdAddfield.TabIndex = 10;
			this.cmdAddfield.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddfield.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddfield.CausesValidation = true;
			this.cmdAddfield.Enabled = true;
			this.cmdAddfield.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddfield.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddfield.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddfield.TabStop = true;
			this.cmdAddfield.Name = "cmdAddfield";
			this.lstFieldstoValidate.Enabled = false;
			this.lstFieldstoValidate.Size = new System.Drawing.Size(327, 123);
			this.lstFieldstoValidate.Location = new System.Drawing.Point(33, 167);
			this.lstFieldstoValidate.TabIndex = 9;
			this.lstFieldstoValidate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldstoValidate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldstoValidate.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldstoValidate.CausesValidation = true;
			this.lstFieldstoValidate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldstoValidate.IntegralHeight = true;
			this.lstFieldstoValidate.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldstoValidate.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFieldstoValidate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldstoValidate.Sorted = false;
			this.lstFieldstoValidate.TabStop = true;
			this.lstFieldstoValidate.Visible = true;
			this.lstFieldstoValidate.MultiColumn = false;
			this.lstFieldstoValidate.Name = "lstFieldstoValidate";
			this.cboFieldList.Enabled = false;
			this.cboFieldList.Size = new System.Drawing.Size(330, 27);
			this.cboFieldList.Location = new System.Drawing.Point(32, 117);
			this.cboFieldList.TabIndex = 8;
			this.cboFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.cboFieldList.CausesValidation = true;
			this.cboFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFieldList.IntegralHeight = true;
			this.cboFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboFieldList.Sorted = false;
			this.cboFieldList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboFieldList.TabStop = true;
			this.cboFieldList.Visible = true;
			this.cboFieldList.Name = "cboFieldList";
			this.opt3UpdateField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.opt3UpdateField.Text = "Updating Field(s)";
			this.opt3UpdateField.Size = new System.Drawing.Size(194, 24);
			this.opt3UpdateField.Location = new System.Drawing.Point(8, 69);
			this.opt3UpdateField.TabIndex = 7;
			this.opt3UpdateField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.opt3UpdateField.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.opt3UpdateField.BackColor = System.Drawing.SystemColors.Control;
			this.opt3UpdateField.CausesValidation = true;
			this.opt3UpdateField.Enabled = true;
			this.opt3UpdateField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.opt3UpdateField.Cursor = System.Windows.Forms.Cursors.Default;
			this.opt3UpdateField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.opt3UpdateField.Appearance = System.Windows.Forms.Appearance.Normal;
			this.opt3UpdateField.TabStop = true;
			this.opt3UpdateField.Checked = false;
			this.opt3UpdateField.Visible = true;
			this.opt3UpdateField.Name = "opt3UpdateField";
			this.opt2Delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.opt2Delete.Text = "Deleting Record";
			this.opt2Delete.Size = new System.Drawing.Size(194, 24);
			this.opt2Delete.Location = new System.Drawing.Point(9, 45);
			this.opt2Delete.TabIndex = 2;
			this.opt2Delete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.opt2Delete.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.opt2Delete.BackColor = System.Drawing.SystemColors.Control;
			this.opt2Delete.CausesValidation = true;
			this.opt2Delete.Enabled = true;
			this.opt2Delete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.opt2Delete.Cursor = System.Windows.Forms.Cursors.Default;
			this.opt2Delete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.opt2Delete.Appearance = System.Windows.Forms.Appearance.Normal;
			this.opt2Delete.TabStop = true;
			this.opt2Delete.Checked = false;
			this.opt2Delete.Visible = true;
			this.opt2Delete.Name = "opt2Delete";
			this.opt1Save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.opt1Save.Text = "Saving Record";
			this.opt1Save.Size = new System.Drawing.Size(179, 20);
			this.opt1Save.Location = new System.Drawing.Point(9, 23);
			this.opt1Save.TabIndex = 1;
			this.opt1Save.Checked = true;
			this.opt1Save.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.opt1Save.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.opt1Save.BackColor = System.Drawing.SystemColors.Control;
			this.opt1Save.CausesValidation = true;
			this.opt1Save.Enabled = true;
			this.opt1Save.ForeColor = System.Drawing.SystemColors.ControlText;
			this.opt1Save.Cursor = System.Windows.Forms.Cursors.Default;
			this.opt1Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.opt1Save.Appearance = System.Windows.Forms.Appearance.Normal;
			this.opt1Save.TabStop = true;
			this.opt1Save.Visible = true;
			this.opt1Save.Name = "opt1Save";
			this.Label3.Text = "Selected fields:";
			this.Label3.Size = new System.Drawing.Size(162, 18);
			this.Label3.Location = new System.Drawing.Point(33, 145);
			this.Label3.TabIndex = 13;
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
			this.Label1.Text = "Select from this list";
			this.Label1.Size = new System.Drawing.Size(249, 19);
			this.Label1.Location = new System.Drawing.Point(32, 93);
			this.Label1.TabIndex = 12;
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
			this.txtMessage.AutoSize = false;
			this.txtMessage.Size = new System.Drawing.Size(495, 78);
			this.txtMessage.Location = new System.Drawing.Point(40, 42);
			this.txtMessage.Multiline = true;
			this.txtMessage.TabIndex = 0;
			this.txtMessage.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtMessage.AcceptsReturn = true;
			this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
			this.txtMessage.CausesValidation = true;
			this.txtMessage.Enabled = true;
			this.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMessage.HideSelection = true;
			this.txtMessage.ReadOnly = false;
			this.txtMessage.MaxLength = 0;
			this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtMessage.TabStop = true;
			this.txtMessage.Visible = true;
			this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMessage.Name = "txtMessage";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(118, 25);
			this.cmdCancel.Location = new System.Drawing.Point(295, 443);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(144, 25);
			this.cmdAdd.Location = new System.Drawing.Point(130, 443);
			this.cmdAdd.TabIndex = 3;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.Label2.Text = "Show This Message:";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.Size = new System.Drawing.Size(184, 19);
			this.Label2.Location = new System.Drawing.Point(43, 20);
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
			this.Controls.Add(Frame1);
			this.Controls.Add(txtMessage);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(Label2);
			this.Frame1.Controls.Add(cmdRemoveField);
			this.Frame1.Controls.Add(cmdAddfield);
			this.Frame1.Controls.Add(lstFieldstoValidate);
			this.Frame1.Controls.Add(cboFieldList);
			this.Frame1.Controls.Add(opt3UpdateField);
			this.Frame1.Controls.Add(opt2Delete);
			this.Frame1.Controls.Add(opt1Save);
			this.Frame1.Controls.Add(Label3);
			this.Frame1.Controls.Add(Label1);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
