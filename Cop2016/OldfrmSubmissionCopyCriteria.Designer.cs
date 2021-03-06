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
	partial class OldfrmSubmissionCopyCriteria
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSubmissionCopyCriteria() : base()
		{
			Load += frmSubmissionCopyCriteria_Load;
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
		public System.Windows.Forms.ComboBox cboJoinOperator;
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
		private System.Windows.Forms.ComboBox withEventsField_cboSet;
		public System.Windows.Forms.ComboBox cboSet {
			get { return withEventsField_cboSet; }
			set {
				if (withEventsField_cboSet != null) {
					withEventsField_cboSet.SelectedIndexChanged -= cboSet_SelectedIndexChanged;
				}
				withEventsField_cboSet = value;
				if (withEventsField_cboSet != null) {
					withEventsField_cboSet.SelectedIndexChanged += cboSet_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboColumns;
		public System.Windows.Forms.ComboBox cboColumns {
			get { return withEventsField_cboColumns; }
			set {
				if (withEventsField_cboColumns != null) {
					withEventsField_cboColumns.SelectedIndexChanged -= cboColumns_SelectedIndexChanged;
				}
				withEventsField_cboColumns = value;
				if (withEventsField_cboColumns != null) {
					withEventsField_cboColumns.SelectedIndexChanged += cboColumns_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label lblJoinOperator;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label3;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSubmissionCopyCriteria));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cboJoinOperator = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.cboSet = new System.Windows.Forms.ComboBox();
			this.cboColumns = new System.Windows.Forms.ComboBox();
			this.lblJoinOperator = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lblCopyFrom = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Copy Submission Criteria";
			this.ClientSize = new System.Drawing.Size(688, 190);
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
			this.Name = "frmSubmissionCopyCriteria";
			this.cboJoinOperator.Size = new System.Drawing.Size(67, 27);
			this.cboJoinOperator.Location = new System.Drawing.Point(362, 100);
			this.cboJoinOperator.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboJoinOperator.TabIndex = 9;
			this.cboJoinOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboJoinOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboJoinOperator.CausesValidation = true;
			this.cboJoinOperator.Enabled = true;
			this.cboJoinOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboJoinOperator.IntegralHeight = true;
			this.cboJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboJoinOperator.Sorted = false;
			this.cboJoinOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboJoinOperator.TabStop = true;
			this.cboJoinOperator.Visible = true;
			this.cboJoinOperator.Name = "cboJoinOperator";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 28);
			this.cmdCancel.Location = new System.Drawing.Point(347, 152);
			this.cmdCancel.TabIndex = 8;
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
			this.cmdCopy.Location = new System.Drawing.Point(257, 152);
			this.cmdCopy.TabIndex = 7;
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
			this.cboSet.Location = new System.Drawing.Point(128, 100);
			this.cboSet.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboSet.TabIndex = 5;
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
			this.cboColumns.Size = new System.Drawing.Size(514, 27);
			this.cboColumns.Location = new System.Drawing.Point(128, 69);
			this.cboColumns.TabIndex = 3;
			this.cboColumns.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboColumns.BackColor = System.Drawing.SystemColors.Window;
			this.cboColumns.CausesValidation = true;
			this.cboColumns.Enabled = true;
			this.cboColumns.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboColumns.IntegralHeight = true;
			this.cboColumns.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboColumns.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboColumns.Sorted = false;
			this.cboColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboColumns.TabStop = true;
			this.cboColumns.Visible = true;
			this.cboColumns.Name = "cboColumns";
			this.lblJoinOperator.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblJoinOperator.Text = "Join type in this Set:";
			this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
			this.lblJoinOperator.Size = new System.Drawing.Size(157, 18);
			this.lblJoinOperator.Location = new System.Drawing.Point(200, 103);
			this.lblJoinOperator.TabIndex = 10;
			this.lblJoinOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblJoinOperator.BackColor = System.Drawing.SystemColors.Control;
			this.lblJoinOperator.Enabled = true;
			this.lblJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblJoinOperator.UseMnemonic = true;
			this.lblJoinOperator.Visible = true;
			this.lblJoinOperator.AutoSize = false;
			this.lblJoinOperator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblJoinOperator.Name = "lblJoinOperator";
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label12.Text = "Set #:";
			this.Label12.ForeColor = System.Drawing.Color.Blue;
			this.Label12.Size = new System.Drawing.Size(57, 18);
			this.Label12.Location = new System.Drawing.Point(62, 102);
			this.Label12.TabIndex = 6;
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
			this.Label3.Text = "Column:";
			this.Label3.ForeColor = System.Drawing.Color.Blue;
			this.Label3.Size = new System.Drawing.Size(52, 30);
			this.Label3.Location = new System.Drawing.Point(70, 69);
			this.Label3.TabIndex = 4;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Shape1.Size = new System.Drawing.Size(599, 88);
			this.Shape1.Location = new System.Drawing.Point(59, 55);
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
			this.Label1.TabIndex = 2;
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
			this.Label2.TabIndex = 1;
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
			this.lblCopyFrom.Size = new System.Drawing.Size(607, 30);
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
			this.Controls.Add(cboJoinOperator);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cmdCopy);
			this.Controls.Add(cboSet);
			this.Controls.Add(cboColumns);
			this.Controls.Add(lblJoinOperator);
			this.Controls.Add(Label12);
			this.Controls.Add(Label3);
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
