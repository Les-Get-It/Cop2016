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
	partial class OldfrmIndicatorReportSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmIndicatorReportSetup() : base()
		{
			Load += frmIndicatorReportSetup_Load;
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = My.MyProject.Forms.frmMasterForm;
			My.MyProject.Forms.frmMasterForm.Show();
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
		public AxMSRDC.AxMSRDC rdcDenominatorFields;
		private System.Windows.Forms.Button withEventsField_Command2;
		public System.Windows.Forms.Button Command2 {
			get { return withEventsField_Command2; }
			set {
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click -= Command2_Click;
				}
				withEventsField_Command2 = value;
				if (withEventsField_Command2 != null) {
					withEventsField_Command2.Click += Command2_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_Command1;
		public System.Windows.Forms.Button Command1 {
			get { return withEventsField_Command1; }
			set {
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click -= Command1_Click;
				}
				withEventsField_Command1 = value;
				if (withEventsField_Command1 != null) {
					withEventsField_Command1.Click += Command1_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdReportUpdateDenominatorField;
		public System.Windows.Forms.Button cmdReportUpdateDenominatorField {
			get { return withEventsField_cmdReportUpdateDenominatorField; }
			set {
				if (withEventsField_cmdReportUpdateDenominatorField != null) {
					withEventsField_cmdReportUpdateDenominatorField.Click -= cmdReportUpdateDenominatorField_Click;
				}
				withEventsField_cmdReportUpdateDenominatorField = value;
				if (withEventsField_cmdReportUpdateDenominatorField != null) {
					withEventsField_cmdReportUpdateDenominatorField.Click += cmdReportUpdateDenominatorField_Click;
				}
			}
		}
		private AxMSDBGrid.AxDBGrid withEventsField_dbgDenominatorFields;
		public AxMSDBGrid.AxDBGrid dbgDenominatorFields {
			get { return withEventsField_dbgDenominatorFields; }
			set {
				if (withEventsField_dbgDenominatorFields != null) {
					withEventsField_dbgDenominatorFields.DblClick -= dbgDenominatorFields_DblClick;
				}
				withEventsField_dbgDenominatorFields = value;
				if (withEventsField_dbgDenominatorFields != null) {
					withEventsField_dbgDenominatorFields.DblClick += dbgDenominatorFields_DblClick;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame5;
		private System.Windows.Forms.CheckedListBox withEventsField_lstHeading;
		public System.Windows.Forms.CheckedListBox lstHeading {
			get { return withEventsField_lstHeading; }
			set {
				if (withEventsField_lstHeading != null) {
					withEventsField_lstHeading.SelectedIndexChanged -= lstHeading_SelectedIndexChanged;
					withEventsField_lstHeading.ItemCheck -= lstHeading_ItemCheck;
				}
				withEventsField_lstHeading = value;
				if (withEventsField_lstHeading != null) {
					withEventsField_lstHeading.SelectedIndexChanged += lstHeading_SelectedIndexChanged;
					withEventsField_lstHeading.ItemCheck += lstHeading_ItemCheck;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.ComboBox withEventsField_cmbIndicators;
		public System.Windows.Forms.ComboBox cmbIndicators {
			get { return withEventsField_cmbIndicators; }
			set {
				if (withEventsField_cmbIndicators != null) {
					withEventsField_cmbIndicators.SelectedIndexChanged -= cmbIndicators_SelectedIndexChanged;
				}
				withEventsField_cmbIndicators = value;
				if (withEventsField_cmbIndicators != null) {
					withEventsField_cmbIndicators.SelectedIndexChanged += cmbIndicators_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.GroupBox Frame1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmIndicatorReportSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.rdcDenominatorFields = new AxMSRDC.AxMSRDC();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.Command2 = new System.Windows.Forms.Button();
			this.Command1 = new System.Windows.Forms.Button();
			this.Frame5 = new System.Windows.Forms.GroupBox();
			this.cmdReportUpdateDenominatorField = new System.Windows.Forms.Button();
			this.dbgDenominatorFields = new AxMSDBGrid.AxDBGrid();
			this.lstHeading = new System.Windows.Forms.CheckedListBox();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.cmbIndicators = new System.Windows.Forms.ComboBox();
			this.Frame2.SuspendLayout();
			this.Frame5.SuspendLayout();
			this.Frame1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcDenominatorFields).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgDenominatorFields).BeginInit();
			this.Text = "Indicator Report Setup";
			this.ClientSize = new System.Drawing.Size(650, 357);
			this.Location = new System.Drawing.Point(29, 54);
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
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
			this.Name = "frmIndicatorReportSetup";
			rdcDenominatorFields.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcDenominatorFields.OcxState");
			this.rdcDenominatorFields.Size = new System.Drawing.Size(302, 32);
			this.rdcDenominatorFields.Location = new System.Drawing.Point(160, 370);
			this.rdcDenominatorFields.Visible = false;
			this.rdcDenominatorFields.Name = "rdcDenominatorFields";
			this.Frame2.Text = "Numerator Setup";
			this.Frame2.Size = new System.Drawing.Size(632, 272);
			this.Frame2.Location = new System.Drawing.Point(10, 80);
			this.Frame2.TabIndex = 2;
			this.Frame2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command2.Text = "Move Down";
			this.Command2.Size = new System.Drawing.Size(84, 32);
			this.Command2.Location = new System.Drawing.Point(130, 210);
			this.Command2.TabIndex = 8;
			this.Command2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Command2.BackColor = System.Drawing.SystemColors.Control;
			this.Command2.CausesValidation = true;
			this.Command2.Enabled = true;
			this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command2.TabStop = true;
			this.Command2.Name = "Command2";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Move Up";
			this.Command1.Size = new System.Drawing.Size(84, 32);
			this.Command1.Location = new System.Drawing.Point(10, 210);
			this.Command1.TabIndex = 7;
			this.Command1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.Frame5.Text = "Denominator Setup";
			this.Frame5.Size = new System.Drawing.Size(402, 222);
			this.Frame5.Location = new System.Drawing.Point(220, 30);
			this.Frame5.TabIndex = 4;
			this.Frame5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame5.BackColor = System.Drawing.SystemColors.Control;
			this.Frame5.Enabled = true;
			this.Frame5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame5.Visible = true;
			this.Frame5.Padding = new System.Windows.Forms.Padding(0);
			this.Frame5.Name = "Frame5";
			this.cmdReportUpdateDenominatorField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdReportUpdateDenominatorField.Text = "&Update List";
			this.cmdReportUpdateDenominatorField.Enabled = false;
			this.cmdReportUpdateDenominatorField.Size = new System.Drawing.Size(152, 31);
			this.cmdReportUpdateDenominatorField.Location = new System.Drawing.Point(130, 180);
			this.cmdReportUpdateDenominatorField.TabIndex = 6;
			this.cmdReportUpdateDenominatorField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdReportUpdateDenominatorField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdReportUpdateDenominatorField.CausesValidation = true;
			this.cmdReportUpdateDenominatorField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdReportUpdateDenominatorField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdReportUpdateDenominatorField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdReportUpdateDenominatorField.TabStop = true;
			this.cmdReportUpdateDenominatorField.Name = "cmdReportUpdateDenominatorField";
			dbgDenominatorFields.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgDenominatorFields.OcxState");
			this.dbgDenominatorFields.Size = new System.Drawing.Size(382, 152);
			this.dbgDenominatorFields.Location = new System.Drawing.Point(10, 20);
			this.dbgDenominatorFields.TabIndex = 5;
			this.dbgDenominatorFields.Name = "dbgDenominatorFields";
			this.lstHeading.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.lstHeading.ForeColor = System.Drawing.Color.Blue;
			this.lstHeading.Size = new System.Drawing.Size(202, 174);
			this.lstHeading.Location = new System.Drawing.Point(10, 20);
			this.lstHeading.TabIndex = 3;
			this.lstHeading.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstHeading.CausesValidation = true;
			this.lstHeading.Enabled = true;
			this.lstHeading.IntegralHeight = true;
			this.lstHeading.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstHeading.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstHeading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstHeading.Sorted = false;
			this.lstHeading.TabStop = true;
			this.lstHeading.Visible = true;
			this.lstHeading.MultiColumn = false;
			this.lstHeading.Name = "lstHeading";
			this.Frame1.Text = "Select Indicator";
			this.Frame1.Size = new System.Drawing.Size(632, 72);
			this.Frame1.Location = new System.Drawing.Point(10, 10);
			this.Frame1.TabIndex = 0;
			this.Frame1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.cmbIndicators.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
			this.cmbIndicators.ForeColor = System.Drawing.Color.Blue;
			this.cmbIndicators.Size = new System.Drawing.Size(612, 27);
			this.cmbIndicators.Location = new System.Drawing.Point(10, 30);
			this.cmbIndicators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIndicators.TabIndex = 1;
			this.cmbIndicators.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmbIndicators.CausesValidation = true;
			this.cmbIndicators.Enabled = true;
			this.cmbIndicators.IntegralHeight = true;
			this.cmbIndicators.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmbIndicators.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbIndicators.Sorted = false;
			this.cmbIndicators.TabStop = true;
			this.cmbIndicators.Visible = true;
			this.cmbIndicators.Name = "cmbIndicators";
			((System.ComponentModel.ISupportInitialize)this.dbgDenominatorFields).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcDenominatorFields).EndInit();
			this.Controls.Add(rdcDenominatorFields);
			this.Controls.Add(Frame2);
			this.Controls.Add(Frame1);
			this.Frame2.Controls.Add(Command2);
			this.Frame2.Controls.Add(Command1);
			this.Frame2.Controls.Add(Frame5);
			this.Frame2.Controls.Add(lstHeading);
			this.Frame5.Controls.Add(cmdReportUpdateDenominatorField);
			this.Frame5.Controls.Add(dbgDenominatorFields);
			this.Frame1.Controls.Add(cmbIndicators);
			this.Frame2.ResumeLayout(false);
			this.Frame5.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
