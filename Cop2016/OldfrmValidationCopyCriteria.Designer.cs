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
	partial class OldfrmValidationCopyCriteria
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmValidationCopyCriteria() : base()
		{
			Load += frmValidationCopyCriteria_Load;
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
		public System.Windows.Forms.Button cmdCopySetp;
		public System.Windows.Forms.ComboBox cboWarning;
		public System.Windows.Forms.RadioButton _rboError_0;
		public System.Windows.Forms.RadioButton rboWarning;
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
		public System.Windows.Forms.ComboBox cboError;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblCopyFrom;
		public Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray rboError;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmValidationCopyCriteria));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cmdCopySetp = new System.Windows.Forms.Button();
			this.cboWarning = new System.Windows.Forms.ComboBox();
			this._rboError_0 = new System.Windows.Forms.RadioButton();
			this.rboWarning = new System.Windows.Forms.RadioButton();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cboError = new System.Windows.Forms.ComboBox();
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblCopyFrom = new System.Windows.Forms.Label();
			this.rboError = new Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components);
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rboError).BeginInit();
			this.Text = "Copy Measure Criteria";
			this.ClientSize = new System.Drawing.Size(764, 225);
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
			this.Name = "frmValidationCopyCriteria";
			this.cmdCopySetp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopySetp.Text = "Copy Entire Message";
			this.cmdCopySetp.Size = new System.Drawing.Size(138, 28);
			this.cmdCopySetp.Location = new System.Drawing.Point(280, 180);
			this.cmdCopySetp.TabIndex = 8;
			this.cmdCopySetp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopySetp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopySetp.CausesValidation = true;
			this.cmdCopySetp.Enabled = true;
			this.cmdCopySetp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopySetp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopySetp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopySetp.TabStop = true;
			this.cmdCopySetp.Name = "cmdCopySetp";
			this.cboWarning.Size = new System.Drawing.Size(532, 27);
			this.cboWarning.Location = new System.Drawing.Point(210, 100);
			this.cboWarning.TabIndex = 3;
			this.cboWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboWarning.BackColor = System.Drawing.SystemColors.Window;
			this.cboWarning.CausesValidation = true;
			this.cboWarning.Enabled = true;
			this.cboWarning.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboWarning.IntegralHeight = true;
			this.cboWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboWarning.Sorted = false;
			this.cboWarning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboWarning.TabStop = true;
			this.cboWarning.Visible = true;
			this.cboWarning.Name = "cboWarning";
			this._rboError_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._rboError_0.Text = "Error";
			this._rboError_0.ForeColor = System.Drawing.Color.Blue;
			this._rboError_0.Size = new System.Drawing.Size(112, 32);
			this._rboError_0.Location = new System.Drawing.Point(90, 60);
			this._rboError_0.TabIndex = 7;
			this._rboError_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._rboError_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._rboError_0.BackColor = System.Drawing.SystemColors.Control;
			this._rboError_0.CausesValidation = true;
			this._rboError_0.Enabled = true;
			this._rboError_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._rboError_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._rboError_0.Appearance = System.Windows.Forms.Appearance.Normal;
			this._rboError_0.TabStop = true;
			this._rboError_0.Checked = false;
			this._rboError_0.Visible = true;
			this._rboError_0.Name = "_rboError_0";
			this.rboWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rboWarning.Text = "Warning";
			this.rboWarning.ForeColor = System.Drawing.Color.Blue;
			this.rboWarning.Size = new System.Drawing.Size(122, 32);
			this.rboWarning.Location = new System.Drawing.Point(90, 100);
			this.rboWarning.TabIndex = 2;
			this.rboWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.rboWarning.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rboWarning.BackColor = System.Drawing.SystemColors.Control;
			this.rboWarning.CausesValidation = true;
			this.rboWarning.Enabled = true;
			this.rboWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.rboWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.rboWarning.Appearance = System.Windows.Forms.Appearance.Normal;
			this.rboWarning.TabStop = true;
			this.rboWarning.Checked = false;
			this.rboWarning.Visible = true;
			this.rboWarning.Name = "rboWarning";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 28);
			this.cmdCancel.Location = new System.Drawing.Point(470, 180);
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
			this.cboError.Size = new System.Drawing.Size(534, 27);
			this.cboError.Location = new System.Drawing.Point(210, 60);
			this.cboError.TabIndex = 1;
			this.cboError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboError.BackColor = System.Drawing.SystemColors.Window;
			this.cboError.CausesValidation = true;
			this.cboError.Enabled = true;
			this.cboError.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboError.IntegralHeight = true;
			this.cboError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboError.Sorted = false;
			this.cboError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboError.TabStop = true;
			this.cboError.Visible = true;
			this.cboError.Name = "cboError";
			this.Shape1.Size = new System.Drawing.Size(689, 97);
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
			this.Controls.Add(cmdCopySetp);
			this.Controls.Add(cboWarning);
			this.Controls.Add(_rboError_0);
			this.Controls.Add(rboWarning);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cboError);
			this.ShapeContainer1.Shapes.Add(Shape1);
			this.Controls.Add(Label1);
			this.Controls.Add(Label2);
			this.Controls.Add(lblCopyFrom);
			this.Controls.Add(ShapeContainer1);
			this.rboError.SetIndex(_rboError_0, Convert.ToInt16(0));
			((System.ComponentModel.ISupportInitialize)this.rboError).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
