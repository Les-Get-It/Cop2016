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
	partial class OldfrmImportAddValidField
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmImportAddValidField() : base()
		{
			Load += frmImportAddValidField_Load;
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
		public System.Windows.Forms.TextBox txtMessage;
		public System.Windows.Forms.ComboBox cboImportFields;
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
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmImportAddValidField));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.cboImportFields = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Select a field for a new validation";
			this.ClientSize = new System.Drawing.Size(483, 269);
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
			this.Name = "frmImportAddValidField";
			this.txtMessage.AutoSize = false;
			this.txtMessage.Size = new System.Drawing.Size(429, 117);
			this.txtMessage.Location = new System.Drawing.Point(20, 104);
			this.txtMessage.Multiline = true;
			this.txtMessage.TabIndex = 4;
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
			this.cboImportFields.Size = new System.Drawing.Size(433, 27);
			this.cboImportFields.Location = new System.Drawing.Point(17, 39);
			this.cboImportFields.TabIndex = 3;
			this.cboImportFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboImportFields.BackColor = System.Drawing.SystemColors.Window;
			this.cboImportFields.CausesValidation = true;
			this.cboImportFields.Enabled = true;
			this.cboImportFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboImportFields.IntegralHeight = true;
			this.cboImportFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboImportFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboImportFields.Sorted = false;
			this.cboImportFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboImportFields.TabStop = true;
			this.cboImportFields.Visible = true;
			this.cboImportFields.Name = "cboImportFields";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(118, 25);
			this.cmdCancel.Location = new System.Drawing.Point(233, 227);
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
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(144, 25);
			this.cmdAdd.Location = new System.Drawing.Point(68, 227);
			this.cmdAdd.TabIndex = 1;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.Label2.Text = "Message";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.Size = new System.Drawing.Size(184, 19);
			this.Label2.Location = new System.Drawing.Point(22, 79);
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
			this.Label1.Text = "Field List";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(227, 22);
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
			this.Controls.Add(txtMessage);
			this.Controls.Add(cboImportFields);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
