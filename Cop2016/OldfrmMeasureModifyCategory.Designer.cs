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
	partial class OldfrmMeasureModifyCategory
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureModifyCategory() : base()
		{
			Load += frmMeasureModifyCategory_Load;
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
		public System.Windows.Forms.ComboBox cboCat;
		public System.Windows.Forms.TextBox txtGoToStep;
		public System.Windows.Forms.Label lblCat;
		public System.Windows.Forms.Label Label7;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureModifyCategory));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cboCat = new System.Windows.Forms.ComboBox();
			this.txtGoToStep = new System.Windows.Forms.TextBox();
			this.lblCat = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Modify Category/Go To Step Assignment";
			this.ClientSize = new System.Drawing.Size(390, 217);
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
			this.Name = "frmMeasureModifyCategory";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(120, 32);
			this.cmdCancel.Location = new System.Drawing.Point(209, 142);
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
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(120, 32);
			this.cmdUpdate.Location = new System.Drawing.Point(70, 140);
			this.cmdUpdate.TabIndex = 4;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cboCat.Size = new System.Drawing.Size(62, 27);
			this.cboCat.Location = new System.Drawing.Point(227, 40);
			this.cboCat.TabIndex = 1;
			this.cboCat.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCat.BackColor = System.Drawing.SystemColors.Window;
			this.cboCat.CausesValidation = true;
			this.cboCat.Enabled = true;
			this.cboCat.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCat.IntegralHeight = true;
			this.cboCat.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCat.Sorted = false;
			this.cboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCat.TabStop = true;
			this.cboCat.Visible = true;
			this.cboCat.Name = "cboCat";
			this.txtGoToStep.AutoSize = false;
			this.txtGoToStep.Size = new System.Drawing.Size(60, 24);
			this.txtGoToStep.Location = new System.Drawing.Point(227, 72);
			this.txtGoToStep.TabIndex = 0;
			this.txtGoToStep.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtGoToStep.AcceptsReturn = true;
			this.txtGoToStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtGoToStep.BackColor = System.Drawing.SystemColors.Window;
			this.txtGoToStep.CausesValidation = true;
			this.txtGoToStep.Enabled = true;
			this.txtGoToStep.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtGoToStep.HideSelection = true;
			this.txtGoToStep.ReadOnly = false;
			this.txtGoToStep.MaxLength = 0;
			this.txtGoToStep.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGoToStep.Multiline = false;
			this.txtGoToStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtGoToStep.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtGoToStep.TabStop = true;
			this.txtGoToStep.Visible = true;
			this.txtGoToStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtGoToStep.Name = "txtGoToStep";
			this.lblCat.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblCat.Text = "Modify Category:";
			this.lblCat.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblCat.ForeColor = System.Drawing.Color.Blue;
			this.lblCat.Size = new System.Drawing.Size(172, 22);
			this.lblCat.Location = new System.Drawing.Point(50, 40);
			this.lblCat.TabIndex = 3;
			this.lblCat.BackColor = System.Drawing.SystemColors.Control;
			this.lblCat.Enabled = true;
			this.lblCat.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCat.UseMnemonic = true;
			this.lblCat.Visible = true;
			this.lblCat.AutoSize = false;
			this.lblCat.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblCat.Name = "lblCat";
			this.Label7.Text = "[OR]  Define Go To Step:";
			this.Label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.ForeColor = System.Drawing.Color.Blue;
			this.Label7.Size = new System.Drawing.Size(183, 18);
			this.Label7.Location = new System.Drawing.Point(39, 72);
			this.Label7.TabIndex = 2;
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label7.BackColor = System.Drawing.SystemColors.Control;
			this.Label7.Enabled = true;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.UseMnemonic = true;
			this.Label7.Visible = true;
			this.Label7.AutoSize = false;
			this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label7.Name = "Label7";
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdUpdate);
			this.Controls.Add(cboCat);
			this.Controls.Add(txtGoToStep);
			this.Controls.Add(lblCat);
			this.Controls.Add(Label7);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
