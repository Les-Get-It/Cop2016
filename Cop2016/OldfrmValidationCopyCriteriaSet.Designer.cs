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
	partial class OldfrmValidationCopyCriteriaSet
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmValidationCopyCriteriaSet() : base()
		{
			FormClosed += frmValidationCopyCriteriaSet_FormClosed;
			Load += frmValidationCopyCriteriaSet_Load;
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
		private System.Windows.Forms.ComboBox withEventsField_cboCopyTo;
		public System.Windows.Forms.ComboBox cboCopyTo {
			get { return withEventsField_cboCopyTo; }
			set {
				if (withEventsField_cboCopyTo != null) {
					withEventsField_cboCopyTo.SelectedIndexChanged -= cboCopyTo_SelectedIndexChanged;
				}
				withEventsField_cboCopyTo = value;
				if (withEventsField_cboCopyTo != null) {
					withEventsField_cboCopyTo.SelectedIndexChanged += cboCopyTo_SelectedIndexChanged;
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
		private System.Windows.Forms.Button withEventsField_cmdCopy;
		public System.Windows.Forms.Button cmdCopy {
			get { return withEventsField_cmdCopy; }
			set {
				if (withEventsField_cmdCopy != null) {
					withEventsField_cmdCopy.Click -= cmdCopy_Click;
				}
				withEventsField_cmdCopy = value;
				if (withEventsField_cmdCopy != null) {
					withEventsField_cmdCopy.Click += cmdCopy_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboSet;
		public System.Windows.Forms.Label Label12;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblCopyFrom;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmValidationCopyCriteriaSet));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cboCopyTo = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.cboSet = new System.Windows.Forms.ComboBox();
			this.Label12 = new System.Windows.Forms.Label();
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblCopyFrom = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Copy Measure Criteria";
			this.ClientSize = new System.Drawing.Size(764, 187);
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
			this.Name = "frmValidationCopyCriteriaSet";
			this.cboCopyTo.Size = new System.Drawing.Size(672, 27);
			this.cboCopyTo.Location = new System.Drawing.Point(70, 60);
			this.cboCopyTo.TabIndex = 1;
			this.cboCopyTo.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCopyTo.BackColor = System.Drawing.SystemColors.Window;
			this.cboCopyTo.CausesValidation = true;
			this.cboCopyTo.Enabled = true;
			this.cboCopyTo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCopyTo.IntegralHeight = true;
			this.cboCopyTo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCopyTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCopyTo.Sorted = false;
			this.cboCopyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCopyTo.TabStop = true;
			this.cboCopyTo.Visible = true;
			this.cboCopyTo.Name = "cboCopyTo";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 28);
			this.cmdCancel.Location = new System.Drawing.Point(479, 150);
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
			this.cmdCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopy.Text = "Copy";
			this.cmdCopy.Size = new System.Drawing.Size(80, 28);
			this.cmdCopy.Location = new System.Drawing.Point(260, 150);
			this.cmdCopy.TabIndex = 3;
			this.cmdCopy.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopy.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopy.CausesValidation = true;
			this.cmdCopy.Enabled = true;
			this.cmdCopy.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopy.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopy.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopy.TabStop = true;
			this.cmdCopy.Name = "cmdCopy";
			this.cboSet.Size = new System.Drawing.Size(67, 27);
			this.cboSet.Location = new System.Drawing.Point(130, 100);
			this.cboSet.TabIndex = 2;
			this.cboSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboSet.BackColor = System.Drawing.SystemColors.Window;
			this.cboSet.CausesValidation = true;
			this.cboSet.Enabled = true;
			this.cboSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboSet.IntegralHeight = true;
			this.cboSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboSet.Sorted = false;
			this.cboSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboSet.TabStop = true;
			this.cboSet.Visible = true;
			this.cboSet.Name = "cboSet";
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label12.Text = "Set #:";
			this.Label12.ForeColor = System.Drawing.Color.Blue;
			this.Label12.Size = new System.Drawing.Size(47, 18);
			this.Label12.Location = new System.Drawing.Point(80, 109);
			this.Label12.TabIndex = 7;
			this.Label12.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.BackColor = System.Drawing.SystemColors.Control;
			this.Label12.Enabled = true;
			this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label12.UseMnemonic = true;
			this.Label12.Visible = true;
			this.Label12.AutoSize = false;
			this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label12.Name = "Label12";
			this.Shape1.Size = new System.Drawing.Size(689, 87);
			this.Shape1.Location = new System.Drawing.Point(60, 50);
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			this.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Shape1.BorderWidth = 1;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this.Shape1.Visible = true;
			this.Shape1.Name = "Shape1";
			this.Label1.Text = "To:";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.Color.Red;
			this.Label1.Size = new System.Drawing.Size(37, 24);
			this.Label1.Location = new System.Drawing.Point(9, 64);
			this.Label1.TabIndex = 6;
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Enabled = true;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			this.Label1.AutoSize = false;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Name = "Label1";
			this.Label2.Text = "Copy:";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.Color.Red;
			this.Label2.Size = new System.Drawing.Size(53, 24);
			this.Label2.Location = new System.Drawing.Point(4, 5);
			this.Label2.TabIndex = 5;
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Enabled = true;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.AutoSize = false;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Name = "Label2";
			this.lblCopyFrom.BackColor = System.Drawing.Color.Transparent;
			this.lblCopyFrom.Text = "This criteria";
			this.lblCopyFrom.ForeColor = System.Drawing.Color.Blue;
			this.lblCopyFrom.Size = new System.Drawing.Size(687, 30);
			this.lblCopyFrom.Location = new System.Drawing.Point(59, 7);
			this.lblCopyFrom.TabIndex = 0;
			this.lblCopyFrom.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblCopyFrom.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblCopyFrom.Enabled = true;
			this.lblCopyFrom.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblCopyFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblCopyFrom.UseMnemonic = true;
			this.lblCopyFrom.Visible = true;
			this.lblCopyFrom.AutoSize = false;
			this.lblCopyFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblCopyFrom.Name = "lblCopyFrom";
			this.Controls.Add(cboCopyTo);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdCopy);
			this.Controls.Add(cboSet);
			this.Controls.Add(Label12);
			this.ShapeContainer1.Shapes.Add(Shape1);
			this.Controls.Add(Label1);
			this.Controls.Add(Label2);
			this.Controls.Add(lblCopyFrom);
			this.Controls.Add(ShapeContainer1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
