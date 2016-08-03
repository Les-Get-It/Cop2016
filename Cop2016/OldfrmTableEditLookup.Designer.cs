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
	partial class OldfrmTableEditLookup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmTableEditLookup() : base()
		{
			Load += frmTableEditLookup_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdEdit;
		public System.Windows.Forms.Button cmdEdit {
			get { return withEventsField_cmdEdit; }
			set {
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click -= cmdEdit_Click;
				}
				withEventsField_cmdEdit = value;
				if (withEventsField_cmdEdit != null) {
					withEventsField_cmdEdit.Click += cmdEdit_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtLookupValue;
		public System.Windows.Forms.TextBox txtID;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmTableEditLookup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.txtLookupValue = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Text = "Edit Lookup Value";
			this.ClientSize = new System.Drawing.Size(390, 144);
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
			this.Name = "frmTableEditLookup";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(113, 25);
			this.cmdCancel.Location = new System.Drawing.Point(209, 104);
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
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "Update";
			this.cmdEdit.Size = new System.Drawing.Size(109, 25);
			this.cmdEdit.Location = new System.Drawing.Point(94, 104);
			this.cmdEdit.TabIndex = 4;
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this.txtLookupValue.AutoSize = false;
			this.txtLookupValue.Size = new System.Drawing.Size(285, 27);
			this.txtLookupValue.Location = new System.Drawing.Point(98, 53);
			this.txtLookupValue.TabIndex = 1;
			this.txtLookupValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtLookupValue.AcceptsReturn = true;
			this.txtLookupValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtLookupValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtLookupValue.CausesValidation = true;
			this.txtLookupValue.Enabled = true;
			this.txtLookupValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtLookupValue.HideSelection = true;
			this.txtLookupValue.ReadOnly = false;
			this.txtLookupValue.MaxLength = 0;
			this.txtLookupValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtLookupValue.Multiline = false;
			this.txtLookupValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtLookupValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtLookupValue.TabStop = true;
			this.txtLookupValue.Visible = true;
			this.txtLookupValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtLookupValue.Name = "txtLookupValue";
			this.txtID.AutoSize = false;
			this.txtID.BackColor = System.Drawing.Color.White;
			this.txtID.Size = new System.Drawing.Size(40, 27);
			this.txtID.Location = new System.Drawing.Point(98, 19);
			this.txtID.TabIndex = 0;
			this.txtID.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtID.AcceptsReturn = true;
			this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtID.CausesValidation = true;
			this.txtID.Enabled = true;
			this.txtID.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtID.HideSelection = true;
			this.txtID.ReadOnly = false;
			this.txtID.MaxLength = 0;
			this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtID.Multiline = false;
			this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtID.TabStop = true;
			this.txtID.Visible = true;
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtID.Name = "txtID";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = "Lookup Value";
			this.Label2.Size = new System.Drawing.Size(85, 19);
			this.Label2.Location = new System.Drawing.Point(5, 55);
			this.Label2.TabIndex = 3;
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
			this.Label1.Text = "ID:";
			this.Label1.Size = new System.Drawing.Size(48, 19);
			this.Label1.Location = new System.Drawing.Point(43, 19);
			this.Label1.TabIndex = 2;
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
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdEdit);
			this.Controls.Add(txtLookupValue);
			this.Controls.Add(txtID);
			this.Controls.Add(Label2);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
