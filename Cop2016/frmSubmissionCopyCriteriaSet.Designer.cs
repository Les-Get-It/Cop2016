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
	partial class Form1
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public Form1() : base()
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
		public System.Windows.Forms.ComboBox cboColumns;
		public System.Windows.Forms.ComboBox cboSet;
		public System.Windows.Forms.Button cmdCopy;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.ComboBox cboJoinOperator;
		public System.Windows.Forms.ListBox lstSummaryDef;
		public System.Windows.Forms.Label Label2;
		public Microsoft.VisualBasic.PowerPacks.RectangleShape Shape1;
		public System.Windows.Forms.Label Label1;
		public Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.cboColumns = new System.Windows.Forms.ComboBox();
			this.cboSet = new System.Windows.Forms.ComboBox();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cboJoinOperator = new System.Windows.Forms.ComboBox();
			this.lstSummaryDef = new System.Windows.Forms.ListBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Shape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Form1";
			this.ClientSize = new System.Drawing.Size(705, 348);
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
			this.Name = "Form1";
			this.cboColumns.Size = new System.Drawing.Size(514, 27);
			this.cboColumns.Location = new System.Drawing.Point(139, 154);
			this.cboColumns.TabIndex = 6;
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
			this.cboSet.Size = new System.Drawing.Size(67, 27);
			this.cboSet.Location = new System.Drawing.Point(139, 185);
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
			this.cmdCopy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopy.Text = "Copy";
			this.cmdCopy.Size = new System.Drawing.Size(80, 28);
			this.cmdCopy.Location = new System.Drawing.Point(268, 237);
			this.cmdCopy.TabIndex = 4;
			this.cmdCopy.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopy.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopy.CausesValidation = true;
			this.cmdCopy.Enabled = true;
			this.cmdCopy.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopy.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopy.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopy.TabStop = true;
			this.cmdCopy.Name = "cmdCopy";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 28);
			this.cmdCancel.Location = new System.Drawing.Point(358, 237);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.cboJoinOperator.Size = new System.Drawing.Size(67, 27);
			this.cboJoinOperator.Location = new System.Drawing.Point(373, 185);
			this.cboJoinOperator.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboJoinOperator.TabIndex = 2;
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
			this.lstSummaryDef.Size = new System.Drawing.Size(688, 90);
			this.lstSummaryDef.Location = new System.Drawing.Point(10, 30);
			this.lstSummaryDef.TabIndex = 0;
			this.lstSummaryDef.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSummaryDef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSummaryDef.BackColor = System.Drawing.SystemColors.Window;
			this.lstSummaryDef.CausesValidation = true;
			this.lstSummaryDef.Enabled = true;
			this.lstSummaryDef.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSummaryDef.IntegralHeight = true;
			this.lstSummaryDef.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSummaryDef.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSummaryDef.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSummaryDef.Sorted = false;
			this.lstSummaryDef.TabStop = true;
			this.lstSummaryDef.Visible = true;
			this.lstSummaryDef.MultiColumn = false;
			this.lstSummaryDef.Name = "lstSummaryDef";
			this.Label2.Text = "To:";
			this.Label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.Color.Red;
			this.Label2.Size = new System.Drawing.Size(37, 24);
			this.Label2.Location = new System.Drawing.Point(20, 149);
			this.Label2.TabIndex = 7;
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
			this.Shape1.Size = new System.Drawing.Size(599, 88);
			this.Shape1.Location = new System.Drawing.Point(70, 140);
			this.Shape1.BackColor = System.Drawing.SystemColors.Window;
			this.Shape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent;
			this.Shape1.BorderColor = System.Drawing.SystemColors.WindowText;
			this.Shape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.Shape1.BorderWidth = 1;
			this.Shape1.FillColor = System.Drawing.Color.Black;
			this.Shape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent;
			this.Shape1.Visible = true;
			this.Shape1.Name = "Shape1";
			this.Label1.Text = "Selected Criteria Sets to Copy:";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.Color.Red;
			this.Label1.Size = new System.Drawing.Size(262, 22);
			this.Label1.Location = new System.Drawing.Point(10, 10);
			this.Label1.TabIndex = 1;
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
			this.Controls.Add(cboColumns);
			this.Controls.Add(cboSet);
			this.Controls.Add(cmdCopy);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cboJoinOperator);
			this.Controls.Add(lstSummaryDef);
			this.Controls.Add(Label2);
			this.ShapeContainer1.Shapes.Add(Shape1);
			this.Controls.Add(Label1);
			this.Controls.Add(ShapeContainer1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
