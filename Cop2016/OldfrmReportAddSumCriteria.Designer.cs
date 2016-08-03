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
	partial class OldfrmReportAddSumCriteria
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmReportAddSumCriteria() : base()
		{
			Load += frmReportAddSumCriteria_Load;
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
		public System.Windows.Forms.ComboBox cboCategory;
		public System.Windows.Forms.ComboBox cboEqual;
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
		public System.Windows.Forms.ComboBox cboJoinOperator;
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
		public System.Windows.Forms.ListBox lstIndicatorList;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label lblJoinOperator;
		public System.Windows.Forms.Label lblMessage;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmReportAddSumCriteria));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.cboEqual = new System.Windows.Forms.ComboBox();
			this.cboSet = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cboJoinOperator = new System.Windows.Forms.ComboBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.lstIndicatorList = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label17 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.lblJoinOperator = new System.Windows.Forms.Label();
			this.lblMessage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Add Summarization Criteria";
			this.ClientSize = new System.Drawing.Size(843, 395);
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
			this.Name = "frmReportAddSumCriteria";
			this.cboCategory.Size = new System.Drawing.Size(364, 27);
			this.cboCategory.Location = new System.Drawing.Point(453, 225);
			this.cboCategory.TabIndex = 9;
			this.cboCategory.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCategory.BackColor = System.Drawing.SystemColors.Window;
			this.cboCategory.CausesValidation = true;
			this.cboCategory.Enabled = true;
			this.cboCategory.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCategory.IntegralHeight = true;
			this.cboCategory.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCategory.Sorted = false;
			this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCategory.TabStop = true;
			this.cboCategory.Visible = true;
			this.cboCategory.Name = "cboCategory";
			this.cboEqual.Size = new System.Drawing.Size(84, 27);
			this.cboEqual.Location = new System.Drawing.Point(370, 225);
			this.cboEqual.Items.AddRange(new object[] {
				"=",
				"<>"
			});
			this.cboEqual.TabIndex = 8;
			this.cboEqual.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboEqual.BackColor = System.Drawing.SystemColors.Window;
			this.cboEqual.CausesValidation = true;
			this.cboEqual.Enabled = true;
			this.cboEqual.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboEqual.IntegralHeight = true;
			this.cboEqual.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboEqual.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboEqual.Sorted = false;
			this.cboEqual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboEqual.TabStop = true;
			this.cboEqual.Visible = true;
			this.cboEqual.Name = "cboEqual";
			this.cboSet.Size = new System.Drawing.Size(67, 27);
			this.cboSet.Location = new System.Drawing.Point(169, 75);
			this.cboSet.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboSet.TabIndex = 4;
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
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.Location = new System.Drawing.Point(627, 362);
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
			this.cboJoinOperator.Location = new System.Drawing.Point(407, 77);
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
			this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.Size = new System.Drawing.Size(80, 24);
			this.cmdAdd.Location = new System.Drawing.Point(537, 362);
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
			this.lstIndicatorList.Size = new System.Drawing.Size(317, 253);
			this.lstIndicatorList.Location = new System.Drawing.Point(13, 113);
			this.lstIndicatorList.TabIndex = 0;
			this.lstIndicatorList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstIndicatorList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstIndicatorList.BackColor = System.Drawing.SystemColors.Window;
			this.lstIndicatorList.CausesValidation = true;
			this.lstIndicatorList.Enabled = true;
			this.lstIndicatorList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstIndicatorList.IntegralHeight = true;
			this.lstIndicatorList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstIndicatorList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstIndicatorList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstIndicatorList.Sorted = false;
			this.lstIndicatorList.TabStop = true;
			this.lstIndicatorList.Visible = true;
			this.lstIndicatorList.MultiColumn = false;
			this.lstIndicatorList.Name = "lstIndicatorList";
			this.Label1.Text = "Compare an indicator to a measure category";
			this.Label1.Size = new System.Drawing.Size(482, 22);
			this.Label1.Location = new System.Drawing.Point(10, 40);
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
			this.Label16.Text = "Measure Category";
			this.Label16.Size = new System.Drawing.Size(157, 20);
			this.Label16.Location = new System.Drawing.Point(453, 200);
			this.Label16.TabIndex = 11;
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
			this.Label17.Text = "Op.";
			this.Label17.Size = new System.Drawing.Size(35, 18);
			this.Label17.Location = new System.Drawing.Point(373, 202);
			this.Label17.TabIndex = 10;
			this.Label17.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label17.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label17.BackColor = System.Drawing.SystemColors.Control;
			this.Label17.Enabled = true;
			this.Label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label17.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label17.UseMnemonic = true;
			this.Label17.Visible = true;
			this.Label17.AutoSize = false;
			this.Label17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label17.Name = "Label17";
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label12.Text = "Select Criteria Set #:";
			this.Label12.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.ForeColor = System.Drawing.Color.Blue;
			this.Label12.Size = new System.Drawing.Size(153, 18);
			this.Label12.Location = new System.Drawing.Point(12, 77);
			this.Label12.TabIndex = 7;
			this.Label12.BackColor = System.Drawing.SystemColors.Control;
			this.Label12.Enabled = true;
			this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label12.UseMnemonic = true;
			this.Label12.Visible = true;
			this.Label12.AutoSize = false;
			this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label12.Name = "Label12";
			this.lblJoinOperator.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblJoinOperator.Text = "Join type in this Set:";
			this.lblJoinOperator.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblJoinOperator.ForeColor = System.Drawing.Color.Blue;
			this.lblJoinOperator.Size = new System.Drawing.Size(157, 18);
			this.lblJoinOperator.Location = new System.Drawing.Point(245, 79);
			this.lblJoinOperator.TabIndex = 6;
			this.lblJoinOperator.BackColor = System.Drawing.SystemColors.Control;
			this.lblJoinOperator.Enabled = true;
			this.lblJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblJoinOperator.UseMnemonic = true;
			this.lblJoinOperator.Visible = true;
			this.lblJoinOperator.AutoSize = false;
			this.lblJoinOperator.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblJoinOperator.Name = "lblJoinOperator";
			this.lblMessage.Text = "Setting up Summarization Criteria ";
			this.lblMessage.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblMessage.Size = new System.Drawing.Size(797, 20);
			this.lblMessage.Location = new System.Drawing.Point(0, 0);
			this.lblMessage.TabIndex = 5;
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
			this.lblMessage.Enabled = true;
			this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMessage.UseMnemonic = true;
			this.lblMessage.Visible = true;
			this.lblMessage.AutoSize = false;
			this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMessage.Name = "lblMessage";
			this.Controls.Add(cboCategory);
			this.Controls.Add(cboEqual);
			this.Controls.Add(cboSet);
			this.Controls.Add(cmdCancel);
			this.Controls.Add(cboJoinOperator);
			this.Controls.Add(cmdAdd);
			this.Controls.Add(lstIndicatorList);
			this.Controls.Add(Label1);
			this.Controls.Add(Label16);
			this.Controls.Add(Label17);
			this.Controls.Add(Label12);
			this.Controls.Add(lblJoinOperator);
			this.Controls.Add(lblMessage);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
