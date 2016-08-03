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
	partial class OldfrmTableValidationAddAction
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmTableValidationAddAction() : base()
		{
			Load += frmTableValidationAddAction_Load;
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
		public System.Windows.Forms.RadioButton optZero;
		public System.Windows.Forms.RadioButton optBlank;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.ListBox lstFieldList;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmTableValidationAddAction));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.optZero = new System.Windows.Forms.RadioButton();
			this.optBlank = new System.Windows.Forms.RadioButton();
			this.lstFieldList = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Add Validation Action";
			this.ClientSize = new System.Drawing.Size(490, 293);
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
			this.Name = "frmTableValidationAddAction";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(107, 25);
			this.cmdCancel.Location = new System.Drawing.Point(349, 235);
			this.cmdCancel.TabIndex = 5;
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
			this.cmdAdd.Size = new System.Drawing.Size(107, 25);
			this.cmdAdd.Location = new System.Drawing.Point(234, 235);
			this.cmdAdd.TabIndex = 4;
			this.cmdAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAdd.CausesValidation = true;
			this.cmdAdd.Enabled = true;
			this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAdd.TabStop = true;
			this.cmdAdd.Name = "cmdAdd";
			this.Frame1.Text = "Set to:";
			this.Frame1.Size = new System.Drawing.Size(173, 53);
			this.Frame1.Location = new System.Drawing.Point(9, 229);
			this.Frame1.TabIndex = 1;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.optZero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optZero.Text = "Zero";
			this.optZero.Size = new System.Drawing.Size(79, 19);
			this.optZero.Location = new System.Drawing.Point(79, 23);
			this.optZero.TabIndex = 3;
			this.optZero.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optZero.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optZero.BackColor = System.Drawing.SystemColors.Control;
			this.optZero.CausesValidation = true;
			this.optZero.Enabled = true;
			this.optZero.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optZero.Cursor = System.Windows.Forms.Cursors.Default;
			this.optZero.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optZero.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optZero.TabStop = true;
			this.optZero.Checked = false;
			this.optZero.Visible = true;
			this.optZero.Name = "optZero";
			this.optBlank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optBlank.Text = "Blank";
			this.optBlank.Size = new System.Drawing.Size(62, 24);
			this.optBlank.Location = new System.Drawing.Point(10, 22);
			this.optBlank.TabIndex = 2;
			this.optBlank.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optBlank.BackColor = System.Drawing.SystemColors.Control;
			this.optBlank.CausesValidation = true;
			this.optBlank.Enabled = true;
			this.optBlank.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optBlank.Cursor = System.Windows.Forms.Cursors.Default;
			this.optBlank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optBlank.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optBlank.TabStop = true;
			this.optBlank.Checked = false;
			this.optBlank.Visible = true;
			this.optBlank.Name = "optBlank";
			this.lstFieldList.Size = new System.Drawing.Size(473, 204);
			this.lstFieldList.Location = new System.Drawing.Point(5, 22);
			this.lstFieldList.TabIndex = 0;
			this.lstFieldList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldList.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldList.CausesValidation = true;
			this.lstFieldList.Enabled = true;
			this.lstFieldList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldList.IntegralHeight = true;
			this.lstFieldList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFieldList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldList.Sorted = false;
			this.lstFieldList.TabStop = true;
			this.lstFieldList.Visible = true;
			this.lstFieldList.MultiColumn = false;
			this.lstFieldList.Name = "lstFieldList";
			this.Label1.Text = "Fields";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(132, 20);
			this.Label1.Location = new System.Drawing.Point(8, 3);
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
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(Frame1);
			this.Controls.Add(lstFieldList);
			this.Controls.Add(Label1);
			this.Frame1.Controls.Add(optZero);
			this.Frame1.Controls.Add(optBlank);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
