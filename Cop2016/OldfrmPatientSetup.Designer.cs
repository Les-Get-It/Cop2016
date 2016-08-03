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
	partial class OldfrmPatientSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmPatientSetup() : base()
		{
			Load += frmPatientSetup_Load;
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
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label2;
		public AxMSDBGrid.AxDBGrid dbgPatientFields;
		private System.Windows.Forms.ComboBox withEventsField_cboIndicatorGroup;
		public System.Windows.Forms.ComboBox cboIndicatorGroup {
			get { return withEventsField_cboIndicatorGroup; }
			set {
				if (withEventsField_cboIndicatorGroup != null) {
					withEventsField_cboIndicatorGroup.SelectedIndexChanged -= cboIndicatorGroup_SelectedIndexChanged;
				}
				withEventsField_cboIndicatorGroup = value;
				if (withEventsField_cboIndicatorGroup != null) {
					withEventsField_cboIndicatorGroup.SelectedIndexChanged += cboIndicatorGroup_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelete;
		public System.Windows.Forms.Button cmdDelete {
			get { return withEventsField_cmdDelete; }
			set {
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click -= cmdDelete_Click;
				}
				withEventsField_cmdDelete = value;
				if (withEventsField_cmdDelete != null) {
					withEventsField_cmdDelete.Click += cmdDelete_Click;
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
		private System.Windows.Forms.Button withEventsField_cmdNew;
		public System.Windows.Forms.Button cmdNew {
			get { return withEventsField_cmdNew; }
			set {
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click -= cmdNew_Click;
				}
				withEventsField_cmdNew = value;
				if (withEventsField_cmdNew != null) {
					withEventsField_cmdNew.Click += cmdNew_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddPatientField;
		public System.Windows.Forms.Button cmdAddPatientField {
			get { return withEventsField_cmdAddPatientField; }
			set {
				if (withEventsField_cmdAddPatientField != null) {
					withEventsField_cmdAddPatientField.Click -= cmdAddPatientField_Click;
				}
				withEventsField_cmdAddPatientField = value;
				if (withEventsField_cmdAddPatientField != null) {
					withEventsField_cmdAddPatientField.Click += cmdAddPatientField_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemovePatientField;
		public System.Windows.Forms.Button cmdRemovePatientField {
			get { return withEventsField_cmdRemovePatientField; }
			set {
				if (withEventsField_cmdRemovePatientField != null) {
					withEventsField_cmdRemovePatientField.Click -= cmdRemovePatientField_Click;
				}
				withEventsField_cmdRemovePatientField = value;
				if (withEventsField_cmdRemovePatientField != null) {
					withEventsField_cmdRemovePatientField.Click += cmdRemovePatientField_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEditPatientField;
		public System.Windows.Forms.Button cmdEditPatientField {
			get { return withEventsField_cmdEditPatientField; }
			set {
				if (withEventsField_cmdEditPatientField != null) {
					withEventsField_cmdEditPatientField.Click -= cmdEditPatientField_Click;
				}
				withEventsField_cmdEditPatientField = value;
				if (withEventsField_cmdEditPatientField != null) {
					withEventsField_cmdEditPatientField.Click += cmdEditPatientField_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstFieldIndicator;
		private System.Windows.Forms.Button withEventsField_cmdMoveUp;
		public System.Windows.Forms.Button cmdMoveUp {
			get { return withEventsField_cmdMoveUp; }
			set {
				if (withEventsField_cmdMoveUp != null) {
					withEventsField_cmdMoveUp.Click -= cmdMoveUp_Click;
				}
				withEventsField_cmdMoveUp = value;
				if (withEventsField_cmdMoveUp != null) {
					withEventsField_cmdMoveUp.Click += cmdMoveUp_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveDown;
		public System.Windows.Forms.Button cmdMoveDown {
			get { return withEventsField_cmdMoveDown; }
			set {
				if (withEventsField_cmdMoveDown != null) {
					withEventsField_cmdMoveDown.Click -= cmdMoveDown_Click;
				}
				withEventsField_cmdMoveDown = value;
				if (withEventsField_cmdMoveDown != null) {
					withEventsField_cmdMoveDown.Click += cmdMoveDown_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveFieldIndicator;
		public System.Windows.Forms.Button cmdRemoveFieldIndicator {
			get { return withEventsField_cmdRemoveFieldIndicator; }
			set {
				if (withEventsField_cmdRemoveFieldIndicator != null) {
					withEventsField_cmdRemoveFieldIndicator.Click -= cmdRemoveFieldIndicator_Click;
				}
				withEventsField_cmdRemoveFieldIndicator = value;
				if (withEventsField_cmdRemoveFieldIndicator != null) {
					withEventsField_cmdRemoveFieldIndicator.Click += cmdRemoveFieldIndicator_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeStatus;
		public System.Windows.Forms.Button cmdChangeStatus {
			get { return withEventsField_cmdChangeStatus; }
			set {
				if (withEventsField_cmdChangeStatus != null) {
					withEventsField_cmdChangeStatus.Click -= cmdChangeStatus_Click;
				}
				withEventsField_cmdChangeStatus = value;
				if (withEventsField_cmdChangeStatus != null) {
					withEventsField_cmdChangeStatus.Click += cmdChangeStatus_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveToAbsPosition;
		public System.Windows.Forms.Button cmdMoveToAbsPosition {
			get { return withEventsField_cmdMoveToAbsPosition; }
			set {
				if (withEventsField_cmdMoveToAbsPosition != null) {
					withEventsField_cmdMoveToAbsPosition.Click -= cmdMoveToAbsPosition_Click;
				}
				withEventsField_cmdMoveToAbsPosition = value;
				if (withEventsField_cmdMoveToAbsPosition != null) {
					withEventsField_cmdMoveToAbsPosition.Click += cmdMoveToAbsPosition_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabpatientSetup_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdMoveSectionDown;
		public System.Windows.Forms.Button cmdMoveSectionDown {
			get { return withEventsField_cmdMoveSectionDown; }
			set {
				if (withEventsField_cmdMoveSectionDown != null) {
					withEventsField_cmdMoveSectionDown.Click -= cmdMoveSectionDown_Click;
				}
				withEventsField_cmdMoveSectionDown = value;
				if (withEventsField_cmdMoveSectionDown != null) {
					withEventsField_cmdMoveSectionDown.Click += cmdMoveSectionDown_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveSectionUp;
		public System.Windows.Forms.Button cmdMoveSectionUp {
			get { return withEventsField_cmdMoveSectionUp; }
			set {
				if (withEventsField_cmdMoveSectionUp != null) {
					withEventsField_cmdMoveSectionUp.Click -= cmdMoveSectionUp_Click;
				}
				withEventsField_cmdMoveSectionUp = value;
				if (withEventsField_cmdMoveSectionUp != null) {
					withEventsField_cmdMoveSectionUp.Click += cmdMoveSectionUp_Click;
				}
			}
		}
		public AxMSDBGrid.AxDBGrid dbgSections;
		public System.Windows.Forms.TabPage _sstabpatientSetup_TabPage1;
		private System.Windows.Forms.TabControl withEventsField_sstabpatientSetup;
		public System.Windows.Forms.TabControl sstabpatientSetup {
			get { return withEventsField_sstabpatientSetup; }
			set {
				if (withEventsField_sstabpatientSetup != null) {
					withEventsField_sstabpatientSetup.SelectedIndexChanged -= sstabpatientSetup_SelectedIndexChanged;
				}
				withEventsField_sstabpatientSetup = value;
				if (withEventsField_sstabpatientSetup != null) {
					withEventsField_sstabpatientSetup.SelectedIndexChanged += sstabpatientSetup_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcPatientFields;
		public AxMSRDC.AxMSRDC rdcSections;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmPatientSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.sstabpatientSetup = new System.Windows.Forms.TabControl();
			this._sstabpatientSetup_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.dbgPatientFields = new AxMSDBGrid.AxDBGrid();
			this.cboIndicatorGroup = new System.Windows.Forms.ComboBox();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdNew = new System.Windows.Forms.Button();
			this.cmdAddPatientField = new System.Windows.Forms.Button();
			this.cmdRemovePatientField = new System.Windows.Forms.Button();
			this.cmdEditPatientField = new System.Windows.Forms.Button();
			this.lstFieldIndicator = new System.Windows.Forms.ListBox();
			this.cmdMoveUp = new System.Windows.Forms.Button();
			this.cmdMoveDown = new System.Windows.Forms.Button();
			this.cmdRemoveFieldIndicator = new System.Windows.Forms.Button();
			this.cmdChangeStatus = new System.Windows.Forms.Button();
			this.cmdMoveToAbsPosition = new System.Windows.Forms.Button();
			this._sstabpatientSetup_TabPage1 = new System.Windows.Forms.TabPage();
			this.cmdMoveSectionDown = new System.Windows.Forms.Button();
			this.cmdMoveSectionUp = new System.Windows.Forms.Button();
			this.dbgSections = new AxMSDBGrid.AxDBGrid();
			this.rdcPatientFields = new AxMSRDC.AxMSRDC();
			this.rdcSections = new AxMSRDC.AxMSRDC();
			this.sstabpatientSetup.SuspendLayout();
			this._sstabpatientSetup_TabPage0.SuspendLayout();
			this._sstabpatientSetup_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgPatientFields).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSections).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcPatientFields).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcSections).BeginInit();
			this.Text = "Patient Form Setup";
			this.ClientSize = new System.Drawing.Size(895, 939);
			this.Location = new System.Drawing.Point(5, 29);
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
			this.Name = "frmPatientSetup";
			this.sstabpatientSetup.Size = new System.Drawing.Size(870, 924);
			this.sstabpatientSetup.Location = new System.Drawing.Point(19, 8);
			this.sstabpatientSetup.TabIndex = 0;
			this.sstabpatientSetup.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabpatientSetup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabpatientSetup.Name = "sstabpatientSetup";
			this._sstabpatientSetup_TabPage0.Text = "Patient Form Setup";
			this.Label3.Text = "Fields for the Section:";
			this.Label3.Size = new System.Drawing.Size(322, 22);
			this.Label3.Location = new System.Drawing.Point(23, 93);
			this.Label3.TabIndex = 13;
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
			this.Label1.Text = "Sections on Patient Form:";
			this.Label1.Size = new System.Drawing.Size(218, 19);
			this.Label1.Location = new System.Drawing.Point(23, 37);
			this.Label1.TabIndex = 14;
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
			this.Label4.Text = "Indicators selected for this field";
			this.Label4.Size = new System.Drawing.Size(197, 22);
			this.Label4.Location = new System.Drawing.Point(14, 312);
			this.Label4.TabIndex = 15;
			this.Label4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label2.Text = "(Relationship between field and indicator is independent from section)";
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label2.Size = new System.Drawing.Size(409, 23);
			this.Label2.Location = new System.Drawing.Point(205, 312);
			this.Label2.TabIndex = 19;
			this.Label2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			dbgPatientFields.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgPatientFields.OcxState");
			this.dbgPatientFields.Size = new System.Drawing.Size(714, 132);
			this.dbgPatientFields.Location = new System.Drawing.Point(23, 118);
			this.dbgPatientFields.TabIndex = 12;
			this.dbgPatientFields.Name = "dbgPatientFields";
			this.cboIndicatorGroup.Size = new System.Drawing.Size(584, 27);
			this.cboIndicatorGroup.Location = new System.Drawing.Point(24, 55);
			this.cboIndicatorGroup.TabIndex = 1;
			this.cboIndicatorGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboIndicatorGroup.BackColor = System.Drawing.SystemColors.Window;
			this.cboIndicatorGroup.CausesValidation = true;
			this.cboIndicatorGroup.Enabled = true;
			this.cboIndicatorGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboIndicatorGroup.IntegralHeight = true;
			this.cboIndicatorGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboIndicatorGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboIndicatorGroup.Sorted = false;
			this.cboIndicatorGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboIndicatorGroup.TabStop = true;
			this.cboIndicatorGroup.Visible = true;
			this.cboIndicatorGroup.Name = "cboIndicatorGroup";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelete.Text = "Delete";
			this.cmdDelete.Size = new System.Drawing.Size(60, 25);
			this.cmdDelete.Location = new System.Drawing.Point(757, 55);
			this.cmdDelete.TabIndex = 2;
			this.cmdDelete.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelete.CausesValidation = true;
			this.cmdDelete.Enabled = true;
			this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelete.TabStop = true;
			this.cmdDelete.Name = "cmdDelete";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEdit.Text = "Edit";
			this.cmdEdit.Size = new System.Drawing.Size(63, 25);
			this.cmdEdit.Location = new System.Drawing.Point(693, 55);
			this.cmdEdit.TabIndex = 3;
			this.cmdEdit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEdit.CausesValidation = true;
			this.cmdEdit.Enabled = true;
			this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEdit.TabStop = true;
			this.cmdEdit.Name = "cmdEdit";
			this.cmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdNew.Text = "New";
			this.cmdNew.Size = new System.Drawing.Size(64, 25);
			this.cmdNew.Location = new System.Drawing.Point(627, 55);
			this.cmdNew.TabIndex = 4;
			this.cmdNew.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
			this.cmdNew.CausesValidation = true;
			this.cmdNew.Enabled = true;
			this.cmdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdNew.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdNew.TabStop = true;
			this.cmdNew.Name = "cmdNew";
			this.cmdAddPatientField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddPatientField.Text = "Add Patient Field to Section";
			this.cmdAddPatientField.Size = new System.Drawing.Size(200, 25);
			this.cmdAddPatientField.Location = new System.Drawing.Point(23, 254);
			this.cmdAddPatientField.TabIndex = 5;
			this.cmdAddPatientField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddPatientField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddPatientField.CausesValidation = true;
			this.cmdAddPatientField.Enabled = true;
			this.cmdAddPatientField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddPatientField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddPatientField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddPatientField.TabStop = true;
			this.cmdAddPatientField.Name = "cmdAddPatientField";
			this.cmdRemovePatientField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemovePatientField.Text = "Remove Patient Field from Section";
			this.cmdRemovePatientField.Size = new System.Drawing.Size(232, 25);
			this.cmdRemovePatientField.Location = new System.Drawing.Point(227, 254);
			this.cmdRemovePatientField.TabIndex = 6;
			this.cmdRemovePatientField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemovePatientField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemovePatientField.CausesValidation = true;
			this.cmdRemovePatientField.Enabled = true;
			this.cmdRemovePatientField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemovePatientField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemovePatientField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemovePatientField.TabStop = true;
			this.cmdRemovePatientField.Name = "cmdRemovePatientField";
			this.cmdEditPatientField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditPatientField.Text = "Link Indicator To Field";
			this.cmdEditPatientField.Size = new System.Drawing.Size(163, 25);
			this.cmdEditPatientField.Location = new System.Drawing.Point(694, 323);
			this.cmdEditPatientField.TabIndex = 7;
			this.cmdEditPatientField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEditPatientField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditPatientField.CausesValidation = true;
			this.cmdEditPatientField.Enabled = true;
			this.cmdEditPatientField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditPatientField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditPatientField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditPatientField.TabStop = true;
			this.cmdEditPatientField.Name = "cmdEditPatientField";
			this.lstFieldIndicator.Size = new System.Drawing.Size(672, 578);
			this.lstFieldIndicator.Location = new System.Drawing.Point(15, 330);
			this.lstFieldIndicator.TabIndex = 8;
			this.lstFieldIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstFieldIndicator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstFieldIndicator.BackColor = System.Drawing.SystemColors.Window;
			this.lstFieldIndicator.CausesValidation = true;
			this.lstFieldIndicator.Enabled = true;
			this.lstFieldIndicator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstFieldIndicator.IntegralHeight = true;
			this.lstFieldIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstFieldIndicator.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstFieldIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstFieldIndicator.Sorted = false;
			this.lstFieldIndicator.TabStop = true;
			this.lstFieldIndicator.Visible = true;
			this.lstFieldIndicator.MultiColumn = false;
			this.lstFieldIndicator.Name = "lstFieldIndicator";
			this.cmdMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveUp.Text = "Move Up";
			this.cmdMoveUp.Size = new System.Drawing.Size(74, 37);
			this.cmdMoveUp.Location = new System.Drawing.Point(750, 118);
			this.cmdMoveUp.TabIndex = 9;
			this.cmdMoveUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveUp.CausesValidation = true;
			this.cmdMoveUp.Enabled = true;
			this.cmdMoveUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveUp.TabStop = true;
			this.cmdMoveUp.Name = "cmdMoveUp";
			this.cmdMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveDown.Text = "Move Down";
			this.cmdMoveDown.Size = new System.Drawing.Size(74, 38);
			this.cmdMoveDown.Location = new System.Drawing.Point(750, 155);
			this.cmdMoveDown.TabIndex = 10;
			this.cmdMoveDown.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveDown.CausesValidation = true;
			this.cmdMoveDown.Enabled = true;
			this.cmdMoveDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveDown.TabStop = true;
			this.cmdMoveDown.Name = "cmdMoveDown";
			this.cmdRemoveFieldIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveFieldIndicator.Text = "Unlink Indicator From Field";
			this.cmdRemoveFieldIndicator.Size = new System.Drawing.Size(160, 37);
			this.cmdRemoveFieldIndicator.Location = new System.Drawing.Point(695, 350);
			this.cmdRemoveFieldIndicator.TabIndex = 11;
			this.cmdRemoveFieldIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveFieldIndicator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveFieldIndicator.CausesValidation = true;
			this.cmdRemoveFieldIndicator.Enabled = true;
			this.cmdRemoveFieldIndicator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveFieldIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveFieldIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveFieldIndicator.TabStop = true;
			this.cmdRemoveFieldIndicator.Name = "cmdRemoveFieldIndicator";
			this.cmdChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeStatus.Text = "Change Status";
			this.cmdChangeStatus.Size = new System.Drawing.Size(192, 25);
			this.cmdChangeStatus.Location = new System.Drawing.Point(625, 85);
			this.cmdChangeStatus.TabIndex = 20;
			this.cmdChangeStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeStatus.CausesValidation = true;
			this.cmdChangeStatus.Enabled = true;
			this.cmdChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeStatus.TabStop = true;
			this.cmdChangeStatus.Name = "cmdChangeStatus";
			this.cmdMoveToAbsPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveToAbsPosition.Text = "Move To Position";
			this.cmdMoveToAbsPosition.Size = new System.Drawing.Size(74, 37);
			this.cmdMoveToAbsPosition.Location = new System.Drawing.Point(750, 210);
			this.cmdMoveToAbsPosition.TabIndex = 21;
			this.cmdMoveToAbsPosition.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveToAbsPosition.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveToAbsPosition.CausesValidation = true;
			this.cmdMoveToAbsPosition.Enabled = true;
			this.cmdMoveToAbsPosition.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveToAbsPosition.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveToAbsPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveToAbsPosition.TabStop = true;
			this.cmdMoveToAbsPosition.Name = "cmdMoveToAbsPosition";
			this._sstabpatientSetup_TabPage1.Text = "Sections Display Order";
			this.cmdMoveSectionDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveSectionDown.Text = "Move Down";
			this.cmdMoveSectionDown.Size = new System.Drawing.Size(74, 38);
			this.cmdMoveSectionDown.Location = new System.Drawing.Point(529, 133);
			this.cmdMoveSectionDown.TabIndex = 17;
			this.cmdMoveSectionDown.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveSectionDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveSectionDown.CausesValidation = true;
			this.cmdMoveSectionDown.Enabled = true;
			this.cmdMoveSectionDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveSectionDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveSectionDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveSectionDown.TabStop = true;
			this.cmdMoveSectionDown.Name = "cmdMoveSectionDown";
			this.cmdMoveSectionUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveSectionUp.Text = "Move Up";
			this.cmdMoveSectionUp.Size = new System.Drawing.Size(74, 37);
			this.cmdMoveSectionUp.Location = new System.Drawing.Point(529, 93);
			this.cmdMoveSectionUp.TabIndex = 16;
			this.cmdMoveSectionUp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveSectionUp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveSectionUp.CausesValidation = true;
			this.cmdMoveSectionUp.Enabled = true;
			this.cmdMoveSectionUp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveSectionUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveSectionUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveSectionUp.TabStop = true;
			this.cmdMoveSectionUp.Name = "cmdMoveSectionUp";
			dbgSections.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgSections.OcxState");
			this.dbgSections.Size = new System.Drawing.Size(510, 639);
			this.dbgSections.Location = new System.Drawing.Point(12, 42);
			this.dbgSections.TabIndex = 18;
			this.dbgSections.Name = "dbgSections";
			rdcPatientFields.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcPatientFields.OcxState");
			this.rdcPatientFields.Size = new System.Drawing.Size(249, 28);
			this.rdcPatientFields.Location = new System.Drawing.Point(52, 719);
			this.rdcPatientFields.Visible = false;
			this.rdcPatientFields.Name = "rdcPatientFields";
			rdcSections.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcSections.OcxState");
			this.rdcSections.Size = new System.Drawing.Size(249, 28);
			this.rdcSections.Location = new System.Drawing.Point(308, 720);
			this.rdcSections.Visible = false;
			this.rdcSections.Name = "rdcSections";
			((System.ComponentModel.ISupportInitialize)this.rdcSections).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcPatientFields).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSections).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgPatientFields).EndInit();
			this.Controls.Add(sstabpatientSetup);
			this.Controls.Add(rdcPatientFields);
			this.Controls.Add(rdcSections);
			this.sstabpatientSetup.Controls.Add(_sstabpatientSetup_TabPage0);
			this.sstabpatientSetup.Controls.Add(_sstabpatientSetup_TabPage1);
			this._sstabpatientSetup_TabPage0.Controls.Add(Label3);
			this._sstabpatientSetup_TabPage0.Controls.Add(Label1);
			this._sstabpatientSetup_TabPage0.Controls.Add(Label4);
			this._sstabpatientSetup_TabPage0.Controls.Add(Label2);
			this._sstabpatientSetup_TabPage0.Controls.Add(dbgPatientFields);
			this._sstabpatientSetup_TabPage0.Controls.Add(cboIndicatorGroup);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdDelete);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdEdit);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdNew);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdAddPatientField);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdRemovePatientField);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdEditPatientField);
			this._sstabpatientSetup_TabPage0.Controls.Add(lstFieldIndicator);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdMoveUp);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdMoveDown);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdRemoveFieldIndicator);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdChangeStatus);
			this._sstabpatientSetup_TabPage0.Controls.Add(cmdMoveToAbsPosition);
			this._sstabpatientSetup_TabPage1.Controls.Add(cmdMoveSectionDown);
			this._sstabpatientSetup_TabPage1.Controls.Add(cmdMoveSectionUp);
			this._sstabpatientSetup_TabPage1.Controls.Add(dbgSections);
			this.sstabpatientSetup.ResumeLayout(false);
			this._sstabpatientSetup_TabPage0.ResumeLayout(false);
			this._sstabpatientSetup_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
