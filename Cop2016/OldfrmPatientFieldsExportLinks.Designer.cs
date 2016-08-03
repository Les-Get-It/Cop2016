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
	partial class OldfrmPatientFieldsExportLinks
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmPatientFieldsExportLinks() : base()
		{
			Load += frmPatientFieldsExportLinks_Load;
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
		public System.Windows.Forms.ListBox lstFieldCriteria;
		private System.Windows.Forms.Button withEventsField_cmdAddFIeldCrit;
		public System.Windows.Forms.Button cmdAddFIeldCrit {
			get { return withEventsField_cmdAddFIeldCrit; }
			set {
				if (withEventsField_cmdAddFIeldCrit != null) {
					withEventsField_cmdAddFIeldCrit.Click -= cmdAddFIeldCrit_Click;
				}
				withEventsField_cmdAddFIeldCrit = value;
				if (withEventsField_cmdAddFIeldCrit != null) {
					withEventsField_cmdAddFIeldCrit.Click += cmdAddFIeldCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelFieldCrit;
		public System.Windows.Forms.Button cmdDelFieldCrit {
			get { return withEventsField_cmdDelFieldCrit; }
			set {
				if (withEventsField_cmdDelFieldCrit != null) {
					withEventsField_cmdDelFieldCrit.Click -= cmdDelFieldCrit_Click;
				}
				withEventsField_cmdDelFieldCrit = value;
				if (withEventsField_cmdDelFieldCrit != null) {
					withEventsField_cmdDelFieldCrit.Click += cmdDelFieldCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeFieldJoin;
		public System.Windows.Forms.Button cmdChangeFieldJoin {
			get { return withEventsField_cmdChangeFieldJoin; }
			set {
				if (withEventsField_cmdChangeFieldJoin != null) {
					withEventsField_cmdChangeFieldJoin.Click -= cmdChangeFieldJoin_Click;
				}
				withEventsField_cmdChangeFieldJoin = value;
				if (withEventsField_cmdChangeFieldJoin != null) {
					withEventsField_cmdChangeFieldJoin.Click += cmdChangeFieldJoin_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdVirtual;
		public System.Windows.Forms.Button cmdVirtual {
			get { return withEventsField_cmdVirtual; }
			set {
				if (withEventsField_cmdVirtual != null) {
					withEventsField_cmdVirtual.Click -= cmdVirtual_Click;
				}
				withEventsField_cmdVirtual = value;
				if (withEventsField_cmdVirtual != null) {
					withEventsField_cmdVirtual.Click += cmdVirtual_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboParentField;
		public System.Windows.Forms.ComboBox cboFieldEdit;
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
		public System.Windows.Forms.ComboBox cboLookupTbls;
		public System.Windows.Forms.ComboBox cboOutputFormat;
		private System.Windows.Forms.ListBox withEventsField_lstFieldsInMeasure;
		public System.Windows.Forms.ListBox lstFieldsInMeasure {
			get { return withEventsField_lstFieldsInMeasure; }
			set {
				if (withEventsField_lstFieldsInMeasure != null) {
					withEventsField_lstFieldsInMeasure.SelectedIndexChanged -= lstFieldsInMeasure_SelectedIndexChanged;
				}
				withEventsField_lstFieldsInMeasure = value;
				if (withEventsField_lstFieldsInMeasure != null) {
					withEventsField_lstFieldsInMeasure.SelectedIndexChanged += lstFieldsInMeasure_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeToHeaderField;
		public System.Windows.Forms.Button cmdChangeToHeaderField {
			get { return withEventsField_cmdChangeToHeaderField; }
			set {
				if (withEventsField_cmdChangeToHeaderField != null) {
					withEventsField_cmdChangeToHeaderField.Click -= cmdChangeToHeaderField_Click;
				}
				withEventsField_cmdChangeToHeaderField = value;
				if (withEventsField_cmdChangeToHeaderField != null) {
					withEventsField_cmdChangeToHeaderField.Click += cmdChangeToHeaderField_Click;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcTemp;
		public AxMSRDC.AxMSRDC rdcFieldList;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label2;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmPatientFieldsExportLinks));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.lstFieldCriteria = new System.Windows.Forms.ListBox();
			this.cmdAddFIeldCrit = new System.Windows.Forms.Button();
			this.cmdDelFieldCrit = new System.Windows.Forms.Button();
			this.cmdChangeFieldJoin = new System.Windows.Forms.Button();
			this.cmdVirtual = new System.Windows.Forms.Button();
			this.cboParentField = new System.Windows.Forms.ComboBox();
			this.cboFieldEdit = new System.Windows.Forms.ComboBox();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.cboLookupTbls = new System.Windows.Forms.ComboBox();
			this.cboOutputFormat = new System.Windows.Forms.ComboBox();
			this.lstFieldsInMeasure = new System.Windows.Forms.ListBox();
			this.cmdChangeToHeaderField = new System.Windows.Forms.Button();
			this.rdcTemp = new AxMSRDC.AxMSRDC();
			this.rdcFieldList = new AxMSRDC.AxMSRDC();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcTemp).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcFieldList).BeginInit();
			this.Text = "CMS Question Codes";
			this.ClientSize = new System.Drawing.Size(1035, 459);
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
			this.Name = "frmPatientFieldsExportLinks";
			this.lstFieldCriteria.Size = new System.Drawing.Size(722, 123);
			this.lstFieldCriteria.Location = new System.Drawing.Point(10, 280);
			this.lstFieldCriteria.TabIndex = 16;
			this.lstFieldCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldCriteria.CausesValidation = true;
			this.lstFieldCriteria.Enabled = true;
			this.lstFieldCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldCriteria.IntegralHeight = true;
			this.lstFieldCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldCriteria.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFieldCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldCriteria.Sorted = false;
			this.lstFieldCriteria.TabStop = true;
			this.lstFieldCriteria.Visible = true;
			this.lstFieldCriteria.MultiColumn = false;
			this.lstFieldCriteria.Name = "lstFieldCriteria";
			this.cmdAddFIeldCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddFIeldCrit.Text = "Add Criteria";
			this.cmdAddFIeldCrit.Size = new System.Drawing.Size(122, 42);
			this.cmdAddFIeldCrit.Location = new System.Drawing.Point(50, 410);
			this.cmdAddFIeldCrit.TabIndex = 15;
			this.cmdAddFIeldCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddFIeldCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddFIeldCrit.CausesValidation = true;
			this.cmdAddFIeldCrit.Enabled = true;
			this.cmdAddFIeldCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddFIeldCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddFIeldCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddFIeldCrit.TabStop = true;
			this.cmdAddFIeldCrit.Name = "cmdAddFIeldCrit";
			this.cmdDelFieldCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelFieldCrit.Text = "Delete Criteria";
			this.cmdDelFieldCrit.Size = new System.Drawing.Size(122, 42);
			this.cmdDelFieldCrit.Location = new System.Drawing.Point(290, 410);
			this.cmdDelFieldCrit.TabIndex = 14;
			this.cmdDelFieldCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelFieldCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelFieldCrit.CausesValidation = true;
			this.cmdDelFieldCrit.Enabled = true;
			this.cmdDelFieldCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelFieldCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelFieldCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelFieldCrit.TabStop = true;
			this.cmdDelFieldCrit.Name = "cmdDelFieldCrit";
			this.cmdChangeFieldJoin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeFieldJoin.Text = "Change Join Operator between Sets";
			this.cmdChangeFieldJoin.Size = new System.Drawing.Size(152, 42);
			this.cmdChangeFieldJoin.Location = new System.Drawing.Point(520, 410);
			this.cmdChangeFieldJoin.TabIndex = 13;
			this.cmdChangeFieldJoin.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeFieldJoin.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeFieldJoin.CausesValidation = true;
			this.cmdChangeFieldJoin.Enabled = true;
			this.cmdChangeFieldJoin.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeFieldJoin.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeFieldJoin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeFieldJoin.TabStop = true;
			this.cmdChangeFieldJoin.Name = "cmdChangeFieldJoin";
			this.cmdVirtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdVirtual.Text = "Edit/Add Parent Fields";
			this.cmdVirtual.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdVirtual.Size = new System.Drawing.Size(212, 32);
			this.cmdVirtual.Location = new System.Drawing.Point(720, 170);
			this.cmdVirtual.TabIndex = 12;
			this.cmdVirtual.BackColor = System.Drawing.SystemColors.Control;
			this.cmdVirtual.CausesValidation = true;
			this.cmdVirtual.Enabled = true;
			this.cmdVirtual.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdVirtual.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdVirtual.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdVirtual.TabStop = true;
			this.cmdVirtual.Name = "cmdVirtual";
			this.cboParentField.Enabled = false;
			this.cboParentField.Size = new System.Drawing.Size(222, 27);
			this.cboParentField.Location = new System.Drawing.Point(720, 130);
			this.cboParentField.TabIndex = 11;
			this.cboParentField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboParentField.BackColor = System.Drawing.SystemColors.Window;
			this.cboParentField.CausesValidation = true;
			this.cboParentField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboParentField.IntegralHeight = true;
			this.cboParentField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboParentField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboParentField.Sorted = false;
			this.cboParentField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboParentField.TabStop = true;
			this.cboParentField.Visible = true;
			this.cboParentField.Name = "cboParentField";
			this.cboFieldEdit.Size = new System.Drawing.Size(222, 27);
			this.cboFieldEdit.Location = new System.Drawing.Point(720, 92);
			this.cboFieldEdit.Items.AddRange(new object[] {
				"",
				"DATE",
				"TIME",
				"DATE/TIME"
			});
			this.cboFieldEdit.TabIndex = 10;
			this.cboFieldEdit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboFieldEdit.BackColor = System.Drawing.SystemColors.Window;
			this.cboFieldEdit.CausesValidation = true;
			this.cboFieldEdit.Enabled = true;
			this.cboFieldEdit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboFieldEdit.IntegralHeight = true;
			this.cboFieldEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboFieldEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboFieldEdit.Sorted = false;
			this.cboFieldEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboFieldEdit.TabStop = true;
			this.cboFieldEdit.Visible = true;
			this.cboFieldEdit.Name = "cboFieldEdit";
			this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Size = new System.Drawing.Size(174, 39);
			this.cmdUpdate.Location = new System.Drawing.Point(790, 360);
			this.cmdUpdate.TabIndex = 9;
			this.cmdUpdate.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.CausesValidation = true;
			this.cmdUpdate.Enabled = true;
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.TabStop = true;
			this.cmdUpdate.Name = "cmdUpdate";
			this.cboLookupTbls.Enabled = false;
			this.cboLookupTbls.Size = new System.Drawing.Size(229, 27);
			this.cboLookupTbls.Location = new System.Drawing.Point(720, 10);
			this.cboLookupTbls.TabIndex = 4;
			this.cboLookupTbls.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupTbls.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupTbls.CausesValidation = true;
			this.cboLookupTbls.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupTbls.IntegralHeight = true;
			this.cboLookupTbls.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupTbls.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupTbls.Sorted = false;
			this.cboLookupTbls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupTbls.TabStop = true;
			this.cboLookupTbls.Visible = true;
			this.cboLookupTbls.Name = "cboLookupTbls";
			this.cboOutputFormat.Size = new System.Drawing.Size(229, 27);
			this.cboOutputFormat.Location = new System.Drawing.Point(720, 50);
			this.cboOutputFormat.Items.AddRange(new object[] {
				"DX",
				"PX"
			});
			this.cboOutputFormat.TabIndex = 1;
			this.cboOutputFormat.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOutputFormat.BackColor = System.Drawing.SystemColors.Window;
			this.cboOutputFormat.CausesValidation = true;
			this.cboOutputFormat.Enabled = true;
			this.cboOutputFormat.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOutputFormat.IntegralHeight = true;
			this.cboOutputFormat.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOutputFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOutputFormat.Sorted = false;
			this.cboOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOutputFormat.TabStop = true;
			this.cboOutputFormat.Visible = true;
			this.cboOutputFormat.Name = "cboOutputFormat";
			this.lstFieldsInMeasure.Size = new System.Drawing.Size(508, 204);
			this.lstFieldsInMeasure.Location = new System.Drawing.Point(4, 34);
			this.lstFieldsInMeasure.TabIndex = 0;
			this.lstFieldsInMeasure.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldsInMeasure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldsInMeasure.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldsInMeasure.CausesValidation = true;
			this.lstFieldsInMeasure.Enabled = true;
			this.lstFieldsInMeasure.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldsInMeasure.IntegralHeight = true;
			this.lstFieldsInMeasure.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldsInMeasure.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFieldsInMeasure.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldsInMeasure.Sorted = false;
			this.lstFieldsInMeasure.TabStop = true;
			this.lstFieldsInMeasure.Visible = true;
			this.lstFieldsInMeasure.MultiColumn = false;
			this.lstFieldsInMeasure.Name = "lstFieldsInMeasure";
			this.cmdChangeToHeaderField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeToHeaderField.Text = "Switch to Header Field";
			this.cmdChangeToHeaderField.Size = new System.Drawing.Size(87, 55);
			this.cmdChangeToHeaderField.Location = new System.Drawing.Point(560, 510);
			this.cmdChangeToHeaderField.TabIndex = 2;
			this.cmdChangeToHeaderField.Visible = false;
			this.cmdChangeToHeaderField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeToHeaderField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeToHeaderField.CausesValidation = true;
			this.cmdChangeToHeaderField.Enabled = true;
			this.cmdChangeToHeaderField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeToHeaderField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeToHeaderField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeToHeaderField.TabStop = true;
			this.cmdChangeToHeaderField.Name = "cmdChangeToHeaderField";
			rdcTemp.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcTemp.OcxState");
			this.rdcTemp.Size = new System.Drawing.Size(195, 28);
			this.rdcTemp.Location = new System.Drawing.Point(18, 508);
			this.rdcTemp.Visible = false;
			this.rdcTemp.Name = "rdcTemp";
			rdcFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcFieldList.OcxState");
			this.rdcFieldList.Size = new System.Drawing.Size(195, 28);
			this.rdcFieldList.Location = new System.Drawing.Point(230, 510);
			this.rdcFieldList.Visible = false;
			this.rdcFieldList.Name = "rdcFieldList";
			this.Label3.Text = "Criteria for Display";
			this.Label3.Size = new System.Drawing.Size(242, 22);
			this.Label3.Location = new System.Drawing.Point(10, 250);
			this.Label3.TabIndex = 17;
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
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label6.Text = "Parent Question Code:";
			this.Label6.Size = new System.Drawing.Size(142, 19);
			this.Label6.Location = new System.Drawing.Point(577, 140);
			this.Label6.TabIndex = 8;
			this.Label6.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.BackColor = System.Drawing.SystemColors.Control;
			this.Label6.Enabled = true;
			this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.UseMnemonic = true;
			this.Label6.Visible = true;
			this.Label6.AutoSize = false;
			this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label6.Name = "Label6";
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label7.Text = "Answer Code Date/Time Format:";
			this.Label7.Size = new System.Drawing.Size(199, 20);
			this.Label7.Location = new System.Drawing.Point(519, 100);
			this.Label7.TabIndex = 7;
			this.Label7.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.BackColor = System.Drawing.SystemColors.Control;
			this.Label7.Enabled = true;
			this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.UseMnemonic = true;
			this.Label7.Visible = true;
			this.Label7.AutoSize = false;
			this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label7.Name = "Label7";
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label8.Text = "Valid Answer Codes from Lookup Table:";
			this.Label8.Size = new System.Drawing.Size(202, 39);
			this.Label8.Location = new System.Drawing.Point(510, 10);
			this.Label8.TabIndex = 6;
			this.Label8.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label9.Text = "Answer Code Decimal Format:";
			this.Label9.Size = new System.Drawing.Size(195, 29);
			this.Label9.Location = new System.Drawing.Point(520, 60);
			this.Label9.TabIndex = 5;
			this.Label9.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label9.BackColor = System.Drawing.SystemColors.Control;
			this.Label9.Enabled = true;
			this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.UseMnemonic = true;
			this.Label9.Visible = true;
			this.Label9.AutoSize = false;
			this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label9.Name = "Label9";
			this.Label2.Text = "CMS Question Codes by Measure";
			this.Label2.Size = new System.Drawing.Size(215, 15);
			this.Label2.Location = new System.Drawing.Point(3, 14);
			this.Label2.TabIndex = 3;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Controls.Add(lstFieldCriteria);
			this.Controls.Add(cmdAddFIeldCrit);
			this.Controls.Add(cmdDelFieldCrit);
			this.Controls.Add(cmdChangeFieldJoin);
			this.Controls.Add(cmdVirtual);
			this.Controls.Add(cboParentField);
			this.Controls.Add(cboFieldEdit);
			this.Controls.Add(cmdUpdate);
			this.Controls.Add(cboLookupTbls);
			this.Controls.Add(cboOutputFormat);
			this.Controls.Add(lstFieldsInMeasure);
			this.Controls.Add(cmdChangeToHeaderField);
			this.Controls.Add(rdcTemp);
			this.Controls.Add(rdcFieldList);
			this.Controls.Add(Label3);
			this.Controls.Add(Label6);
			this.Controls.Add(Label7);
			this.Controls.Add(Label8);
			this.Controls.Add(Label9);
			this.Controls.Add(Label2);
			((System.ComponentModel.ISupportInitialize)this.rdcFieldList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcTemp).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
