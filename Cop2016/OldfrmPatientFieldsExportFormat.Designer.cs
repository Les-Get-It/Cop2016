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
	partial class OldfrmPatientFieldsExportFormat
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmPatientFieldsExportFormat() : base()
		{
			Load += frmPatientFieldsExportFormat_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdMeasureFieldDetails;
		public System.Windows.Forms.Button cmdMeasureFieldDetails {
			get { return withEventsField_cmdMeasureFieldDetails; }
			set {
				if (withEventsField_cmdMeasureFieldDetails != null) {
					withEventsField_cmdMeasureFieldDetails.Click -= cmdMeasureFieldDetails_Click;
				}
				withEventsField_cmdMeasureFieldDetails = value;
				if (withEventsField_cmdMeasureFieldDetails != null) {
					withEventsField_cmdMeasureFieldDetails.Click += cmdMeasureFieldDetails_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveFromMeasure;
		public System.Windows.Forms.Button cmdRemoveFromMeasure {
			get { return withEventsField_cmdRemoveFromMeasure; }
			set {
				if (withEventsField_cmdRemoveFromMeasure != null) {
					withEventsField_cmdRemoveFromMeasure.Click -= cmdRemoveFromMeasure_Click;
				}
				withEventsField_cmdRemoveFromMeasure = value;
				if (withEventsField_cmdRemoveFromMeasure != null) {
					withEventsField_cmdRemoveFromMeasure.Click += cmdRemoveFromMeasure_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdLinkToMeasure;
		public System.Windows.Forms.Button cmdLinkToMeasure {
			get { return withEventsField_cmdLinkToMeasure; }
			set {
				if (withEventsField_cmdLinkToMeasure != null) {
					withEventsField_cmdLinkToMeasure.Click -= cmdLinkToMeasure_Click;
				}
				withEventsField_cmdLinkToMeasure = value;
				if (withEventsField_cmdLinkToMeasure != null) {
					withEventsField_cmdLinkToMeasure.Click += cmdLinkToMeasure_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstSelectedMeasures;
		public System.Windows.Forms.ListBox lstMeasureList;
		public System.Windows.Forms.TextBox txtJCFieldCode;
		public System.Windows.Forms.TextBox txtCMSFieldCode;
		private System.Windows.Forms.ListBox withEventsField_lstFieldList;
		public System.Windows.Forms.ListBox lstFieldList {
			get { return withEventsField_lstFieldList; }
			set {
				if (withEventsField_lstFieldList != null) {
					withEventsField_lstFieldList.SelectedIndexChanged -= lstFieldList_SelectedIndexChanged;
				}
				withEventsField_lstFieldList = value;
				if (withEventsField_lstFieldList != null) {
					withEventsField_lstFieldList.SelectedIndexChanged += lstFieldList_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcFieldList;
		public AxMSRDC.AxMSRDC rdcTemp;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmPatientFieldsExportFormat));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cmdMeasureFieldDetails = new System.Windows.Forms.Button();
			this.cmdRemoveFromMeasure = new System.Windows.Forms.Button();
			this.cmdLinkToMeasure = new System.Windows.Forms.Button();
			this.lstSelectedMeasures = new System.Windows.Forms.ListBox();
			this.lstMeasureList = new System.Windows.Forms.ListBox();
			this.txtJCFieldCode = new System.Windows.Forms.TextBox();
			this.txtCMSFieldCode = new System.Windows.Forms.TextBox();
			this.lstFieldList = new System.Windows.Forms.ListBox();
			this.rdcFieldList = new AxMSRDC.AxMSRDC();
			this.rdcTemp = new AxMSRDC.AxMSRDC();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcFieldList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcTemp).BeginInit();
			this.Text = "Patient Field Export Format";
			this.ClientSize = new System.Drawing.Size(1057, 339);
			this.Location = new System.Drawing.Point(5, 38);
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
			this.Name = "frmPatientFieldsExportFormat";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(125, 24);
			this.cmdUpdate.Location = new System.Drawing.Point(195, 292);
			this.cmdUpdate.TabIndex = 13;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdMeasureFieldDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMeasureFieldDetails.Text = "Measure Details ";
			this.cmdMeasureFieldDetails.Size = new System.Drawing.Size(254, 24);
			this.cmdMeasureFieldDetails.Location = new System.Drawing.Point(333, 292);
			this.cmdMeasureFieldDetails.TabIndex = 12;
			this.cmdMeasureFieldDetails.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMeasureFieldDetails.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMeasureFieldDetails.CausesValidation = true;
			this.cmdMeasureFieldDetails.Enabled = true;
			this.cmdMeasureFieldDetails.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMeasureFieldDetails.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMeasureFieldDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMeasureFieldDetails.TabStop = true;
			this.cmdMeasureFieldDetails.Name = "cmdMeasureFieldDetails";
			this.cmdRemoveFromMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveFromMeasure.Text = "<<==";
			this.cmdRemoveFromMeasure.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveFromMeasure.Size = new System.Drawing.Size(49, 20);
			this.cmdRemoveFromMeasure.Location = new System.Drawing.Point(780, 175);
			this.cmdRemoveFromMeasure.TabIndex = 9;
			this.cmdRemoveFromMeasure.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveFromMeasure.CausesValidation = true;
			this.cmdRemoveFromMeasure.Enabled = true;
			this.cmdRemoveFromMeasure.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveFromMeasure.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveFromMeasure.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveFromMeasure.TabStop = true;
			this.cmdRemoveFromMeasure.Name = "cmdRemoveFromMeasure";
			this.cmdLinkToMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdLinkToMeasure.Text = "==>>";
			this.cmdLinkToMeasure.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdLinkToMeasure.Size = new System.Drawing.Size(47, 20);
			this.cmdLinkToMeasure.Location = new System.Drawing.Point(780, 135);
			this.cmdLinkToMeasure.TabIndex = 8;
			this.cmdLinkToMeasure.BackColor = System.Drawing.SystemColors.Control;
			this.cmdLinkToMeasure.CausesValidation = true;
			this.cmdLinkToMeasure.Enabled = true;
			this.cmdLinkToMeasure.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdLinkToMeasure.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdLinkToMeasure.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdLinkToMeasure.TabStop = true;
			this.cmdLinkToMeasure.Name = "cmdLinkToMeasure";
			this.lstSelectedMeasures.Size = new System.Drawing.Size(212, 155);
			this.lstSelectedMeasures.Location = new System.Drawing.Point(840, 110);
			this.lstSelectedMeasures.TabIndex = 7;
			this.lstSelectedMeasures.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedMeasures.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedMeasures.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedMeasures.CausesValidation = true;
			this.lstSelectedMeasures.Enabled = true;
			this.lstSelectedMeasures.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedMeasures.IntegralHeight = true;
			this.lstSelectedMeasures.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedMeasures.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSelectedMeasures.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedMeasures.Sorted = false;
			this.lstSelectedMeasures.TabStop = true;
			this.lstSelectedMeasures.Visible = true;
			this.lstSelectedMeasures.MultiColumn = false;
			this.lstSelectedMeasures.Name = "lstSelectedMeasures";
			this.lstMeasureList.Size = new System.Drawing.Size(207, 155);
			this.lstMeasureList.Location = new System.Drawing.Point(560, 110);
			this.lstMeasureList.TabIndex = 6;
			this.lstMeasureList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstMeasureList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstMeasureList.BackColor = System.Drawing.SystemColors.Window;
			this.lstMeasureList.CausesValidation = true;
			this.lstMeasureList.Enabled = true;
			this.lstMeasureList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstMeasureList.IntegralHeight = true;
			this.lstMeasureList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstMeasureList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstMeasureList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstMeasureList.Sorted = false;
			this.lstMeasureList.TabStop = true;
			this.lstMeasureList.Visible = true;
			this.lstMeasureList.MultiColumn = false;
			this.lstMeasureList.Name = "lstMeasureList";
			this.txtJCFieldCode.AutoSize = false;
			this.txtJCFieldCode.Size = new System.Drawing.Size(388, 24);
			this.txtJCFieldCode.Location = new System.Drawing.Point(650, 29);
			this.txtJCFieldCode.TabIndex = 3;
			this.txtJCFieldCode.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtJCFieldCode.AcceptsReturn = true;
			this.txtJCFieldCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtJCFieldCode.BackColor = System.Drawing.SystemColors.Window;
			this.txtJCFieldCode.CausesValidation = true;
			this.txtJCFieldCode.Enabled = true;
			this.txtJCFieldCode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtJCFieldCode.HideSelection = true;
			this.txtJCFieldCode.ReadOnly = false;
			this.txtJCFieldCode.MaxLength = 0;
			this.txtJCFieldCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtJCFieldCode.Multiline = false;
			this.txtJCFieldCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtJCFieldCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtJCFieldCode.TabStop = true;
			this.txtJCFieldCode.Visible = true;
			this.txtJCFieldCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtJCFieldCode.Name = "txtJCFieldCode";
			this.txtCMSFieldCode.AutoSize = false;
			this.txtCMSFieldCode.Size = new System.Drawing.Size(388, 24);
			this.txtCMSFieldCode.Location = new System.Drawing.Point(650, 58);
			this.txtCMSFieldCode.TabIndex = 2;
			this.txtCMSFieldCode.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtCMSFieldCode.AcceptsReturn = true;
			this.txtCMSFieldCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtCMSFieldCode.BackColor = System.Drawing.SystemColors.Window;
			this.txtCMSFieldCode.CausesValidation = true;
			this.txtCMSFieldCode.Enabled = true;
			this.txtCMSFieldCode.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCMSFieldCode.HideSelection = true;
			this.txtCMSFieldCode.ReadOnly = false;
			this.txtCMSFieldCode.MaxLength = 0;
			this.txtCMSFieldCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCMSFieldCode.Multiline = false;
			this.txtCMSFieldCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCMSFieldCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCMSFieldCode.TabStop = true;
			this.txtCMSFieldCode.Visible = true;
			this.txtCMSFieldCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtCMSFieldCode.Name = "txtCMSFieldCode";
			this.lstFieldList.Size = new System.Drawing.Size(522, 253);
			this.lstFieldList.Location = new System.Drawing.Point(9, 32);
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
			rdcFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcFieldList.OcxState");
			this.rdcFieldList.Size = new System.Drawing.Size(195, 28);
			this.rdcFieldList.Location = new System.Drawing.Point(28, 328);
			this.rdcFieldList.Visible = false;
			this.rdcFieldList.Name = "rdcFieldList";
			rdcTemp.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcTemp.OcxState");
			this.rdcTemp.Size = new System.Drawing.Size(195, 28);
			this.rdcTemp.Location = new System.Drawing.Point(225, 327);
			this.rdcTemp.Visible = false;
			this.rdcTemp.Name = "rdcTemp";
			this.Label5.Text = "Linked to";
			this.Label5.Size = new System.Drawing.Size(92, 15);
			this.Label5.Location = new System.Drawing.Point(795, 90);
			this.Label5.TabIndex = 11;
			this.Label5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label5.BackColor = System.Drawing.SystemColors.Control;
			this.Label5.Enabled = true;
			this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.Label3.Text = "Measure List";
			this.Label3.Size = new System.Drawing.Size(93, 15);
			this.Label3.Location = new System.Drawing.Point(650, 89);
			this.Label3.TabIndex = 10;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label2.Text = "JC Field Code:";
			this.Label2.Size = new System.Drawing.Size(85, 20);
			this.Label2.Location = new System.Drawing.Point(563, 34);
			this.Label2.TabIndex = 5;
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
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label4.Text = "CMS Field Code:";
			this.Label4.Size = new System.Drawing.Size(99, 25);
			this.Label4.Location = new System.Drawing.Point(549, 59);
			this.Label4.TabIndex = 4;
			this.Label4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label1.Text = "Patient Fields";
			this.Label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.Size = new System.Drawing.Size(142, 20);
			this.Label1.Location = new System.Drawing.Point(12, 8);
			this.Label1.TabIndex = 1;
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
			((System.ComponentModel.ISupportInitialize)this.rdcTemp).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcFieldList).EndInit();
			this.Controls.Add(cmdUpdate);
			this.Controls.Add(cmdMeasureFieldDetails);
			this.Controls.Add(cmdRemoveFromMeasure);
			this.Controls.Add(cmdLinkToMeasure);
			this.Controls.Add(lstSelectedMeasures);
			this.Controls.Add(lstMeasureList);
			this.Controls.Add(txtJCFieldCode);
			this.Controls.Add(txtCMSFieldCode);
			this.Controls.Add(lstFieldList);
			this.Controls.Add(rdcFieldList);
			this.Controls.Add(rdcTemp);
			this.Controls.Add(Label5);
			this.Controls.Add(Label3);
			this.Controls.Add(Label2);
			this.Controls.Add(Label4);
			this.Controls.Add(Label1);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
