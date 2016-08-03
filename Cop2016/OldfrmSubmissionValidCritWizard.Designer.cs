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
	partial class OldfrmSubmissionValidCritWizard
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSubmissionValidCritWizard() : base()
		{
			Load += frmSubmissionValidCritWizard_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdOpt1AddCriteria;
		public System.Windows.Forms.Button cmdOpt1AddCriteria {
			get { return withEventsField_cmdOpt1AddCriteria; }
			set {
				if (withEventsField_cmdOpt1AddCriteria != null) {
					withEventsField_cmdOpt1AddCriteria.Click -= cmdOpt1AddCriteria_Click;
				}
				withEventsField_cmdOpt1AddCriteria = value;
				if (withEventsField_cmdOpt1AddCriteria != null) {
					withEventsField_cmdOpt1AddCriteria.Click += cmdOpt1AddCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDeleteFromGroup1;
		public System.Windows.Forms.Button cmdDeleteFromGroup1 {
			get { return withEventsField_cmdDeleteFromGroup1; }
			set {
				if (withEventsField_cmdDeleteFromGroup1 != null) {
					withEventsField_cmdDeleteFromGroup1.Click -= cmdDeleteFromGroup1_Click;
				}
				withEventsField_cmdDeleteFromGroup1 = value;
				if (withEventsField_cmdDeleteFromGroup1 != null) {
					withEventsField_cmdDeleteFromGroup1.Click += cmdDeleteFromGroup1_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstGroup1SelectedFieldsTable;
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
		public System.Windows.Forms.ListBox lstGroup1SelectedFields;
		private System.Windows.Forms.Button withEventsField_cmdGroup1AddField;
		public System.Windows.Forms.Button cmdGroup1AddField {
			get { return withEventsField_cmdGroup1AddField; }
			set {
				if (withEventsField_cmdGroup1AddField != null) {
					withEventsField_cmdGroup1AddField.Click -= cmdGroup1AddField_Click;
				}
				withEventsField_cmdGroup1AddField = value;
				if (withEventsField_cmdGroup1AddField != null) {
					withEventsField_cmdGroup1AddField.Click += cmdGroup1AddField_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboGroup1Fields;
		private System.Windows.Forms.ComboBox withEventsField_cboGroup1SumTable;
		public System.Windows.Forms.ComboBox cboGroup1SumTable {
			get { return withEventsField_cboGroup1SumTable; }
			set {
				if (withEventsField_cboGroup1SumTable != null) {
					withEventsField_cboGroup1SumTable.SelectedIndexChanged -= cboGroup1SumTable_SelectedIndexChanged;
				}
				withEventsField_cboGroup1SumTable = value;
				if (withEventsField_cboGroup1SumTable != null) {
					withEventsField_cboGroup1SumTable.SelectedIndexChanged += cboGroup1SumTable_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboGroup1SumOp;
		private System.Windows.Forms.Button withEventsField_cmdDeleteFromGroup2Opt1;
		public System.Windows.Forms.Button cmdDeleteFromGroup2Opt1 {
			get { return withEventsField_cmdDeleteFromGroup2Opt1; }
			set {
				if (withEventsField_cmdDeleteFromGroup2Opt1 != null) {
					withEventsField_cmdDeleteFromGroup2Opt1.Click -= cmdDeleteFromGroup2Opt1_Click;
				}
				withEventsField_cmdDeleteFromGroup2Opt1 = value;
				if (withEventsField_cmdDeleteFromGroup2Opt1 != null) {
					withEventsField_cmdDeleteFromGroup2Opt1.Click += cmdDeleteFromGroup2Opt1_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstGroup2Opt1SelectedFieldsTable;
		public System.Windows.Forms.ComboBox cboOpt1FieldOp;
		public System.Windows.Forms.ListBox lstGroup2Opt1SelectedFields;
		private System.Windows.Forms.Button withEventsField_cmdGroup2Opt1AddField;
		public System.Windows.Forms.Button cmdGroup2Opt1AddField {
			get { return withEventsField_cmdGroup2Opt1AddField; }
			set {
				if (withEventsField_cmdGroup2Opt1AddField != null) {
					withEventsField_cmdGroup2Opt1AddField.Click -= cmdGroup2Opt1AddField_Click;
				}
				withEventsField_cmdGroup2Opt1AddField = value;
				if (withEventsField_cmdGroup2Opt1AddField != null) {
					withEventsField_cmdGroup2Opt1AddField.Click += cmdGroup2Opt1AddField_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboGroup2Opt1SumOp;
		public System.Windows.Forms.ComboBox cboGroup2Opt1Fields;
		private System.Windows.Forms.ComboBox withEventsField_cboGroup2Opt1SumTable;
		public System.Windows.Forms.ComboBox cboGroup2Opt1SumTable {
			get { return withEventsField_cboGroup2Opt1SumTable; }
			set {
				if (withEventsField_cboGroup2Opt1SumTable != null) {
					withEventsField_cboGroup2Opt1SumTable.SelectedIndexChanged -= cboGroup2Opt1SumTable_SelectedIndexChanged;
				}
				withEventsField_cboGroup2Opt1SumTable = value;
				if (withEventsField_cboGroup2Opt1SumTable != null) {
					withEventsField_cboGroup2Opt1SumTable.SelectedIndexChanged += cboGroup2Opt1SumTable_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdDeleteFromGroup2Opt2;
		public System.Windows.Forms.Button cmdDeleteFromGroup2Opt2 {
			get { return withEventsField_cmdDeleteFromGroup2Opt2; }
			set {
				if (withEventsField_cmdDeleteFromGroup2Opt2 != null) {
					withEventsField_cmdDeleteFromGroup2Opt2.Click -= cmdDeleteFromGroup2Opt2_Click;
				}
				withEventsField_cmdDeleteFromGroup2Opt2 = value;
				if (withEventsField_cmdDeleteFromGroup2Opt2 != null) {
					withEventsField_cmdDeleteFromGroup2Opt2.Click += cmdDeleteFromGroup2Opt2_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboOpt2FieldOp;
		public System.Windows.Forms.ListBox lstGroup2Opt2SelectedFieldsTable;
		public System.Windows.Forms.TextBox txtOpt2Value;
		public System.Windows.Forms.ComboBox cboOpt2ValueOp;
		public System.Windows.Forms.ListBox lstGroup2Opt2SelectedFields;
		private System.Windows.Forms.Button withEventsField_cmdGroup2Opt2AddField;
		public System.Windows.Forms.Button cmdGroup2Opt2AddField {
			get { return withEventsField_cmdGroup2Opt2AddField; }
			set {
				if (withEventsField_cmdGroup2Opt2AddField != null) {
					withEventsField_cmdGroup2Opt2AddField.Click -= cmdGroup2Opt2AddField_Click;
				}
				withEventsField_cmdGroup2Opt2AddField = value;
				if (withEventsField_cmdGroup2Opt2AddField != null) {
					withEventsField_cmdGroup2Opt2AddField.Click += cmdGroup2Opt2AddField_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboGroup2Opt2SumOp;
		public System.Windows.Forms.ComboBox cboGroup2Opt2Fields;
		private System.Windows.Forms.ComboBox withEventsField_cboGroup2Opt2SumTable;
		public System.Windows.Forms.ComboBox cboGroup2Opt2SumTable {
			get { return withEventsField_cboGroup2Opt2SumTable; }
			set {
				if (withEventsField_cboGroup2Opt2SumTable != null) {
					withEventsField_cboGroup2Opt2SumTable.SelectedIndexChanged -= cboGroup2Opt2SumTable_SelectedIndexChanged;
				}
				withEventsField_cboGroup2Opt2SumTable = value;
				if (withEventsField_cboGroup2Opt2SumTable != null) {
					withEventsField_cboGroup2Opt2SumTable.SelectedIndexChanged += cboGroup2Opt2SumTable_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage1;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.ComboBox cboOpt3ValueOp;
		public System.Windows.Forms.TextBox txtOpt3Value;
		public System.Windows.Forms.TabPage _sstabOptions_TabPage2;
		public System.Windows.Forms.TabControl sstabOptions;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox fraSetup;
		private System.Windows.Forms.RadioButton withEventsField_Opt3Method;
		public System.Windows.Forms.RadioButton Opt3Method {
			get { return withEventsField_Opt3Method; }
			set {
				if (withEventsField_Opt3Method != null) {
					withEventsField_Opt3Method.CheckedChanged -= Opt3Method_CheckedChanged;
				}
				withEventsField_Opt3Method = value;
				if (withEventsField_Opt3Method != null) {
					withEventsField_Opt3Method.CheckedChanged += Opt3Method_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt2Method;
		public System.Windows.Forms.RadioButton Opt2Method {
			get { return withEventsField_Opt2Method; }
			set {
				if (withEventsField_Opt2Method != null) {
					withEventsField_Opt2Method.CheckedChanged -= Opt2Method_CheckedChanged;
				}
				withEventsField_Opt2Method = value;
				if (withEventsField_Opt2Method != null) {
					withEventsField_Opt2Method.CheckedChanged += Opt2Method_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton withEventsField_Opt1Method;
		public System.Windows.Forms.RadioButton Opt1Method {
			get { return withEventsField_Opt1Method; }
			set {
				if (withEventsField_Opt1Method != null) {
					withEventsField_Opt1Method.CheckedChanged -= Opt1Method_CheckedChanged;
				}
				withEventsField_Opt1Method = value;
				if (withEventsField_Opt1Method != null) {
					withEventsField_Opt1Method.CheckedChanged += Opt1Method_CheckedChanged;
				}
			}
		}
		public System.Windows.Forms.GroupBox fraCriteriaMethod;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSubmissionValidCritWizard));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.fraSetup = new System.Windows.Forms.GroupBox();
			this.cmdOpt1AddCriteria = new System.Windows.Forms.Button();
			this.cmdDeleteFromGroup1 = new System.Windows.Forms.Button();
			this.lstGroup1SelectedFieldsTable = new System.Windows.Forms.ListBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.lstGroup1SelectedFields = new System.Windows.Forms.ListBox();
			this.cmdGroup1AddField = new System.Windows.Forms.Button();
			this.cboGroup1Fields = new System.Windows.Forms.ComboBox();
			this.cboGroup1SumTable = new System.Windows.Forms.ComboBox();
			this.cboGroup1SumOp = new System.Windows.Forms.ComboBox();
			this.sstabOptions = new System.Windows.Forms.TabControl();
			this._sstabOptions_TabPage0 = new System.Windows.Forms.TabPage();
			this.cmdDeleteFromGroup2Opt1 = new System.Windows.Forms.Button();
			this.lstGroup2Opt1SelectedFieldsTable = new System.Windows.Forms.ListBox();
			this.cboOpt1FieldOp = new System.Windows.Forms.ComboBox();
			this.lstGroup2Opt1SelectedFields = new System.Windows.Forms.ListBox();
			this.cmdGroup2Opt1AddField = new System.Windows.Forms.Button();
			this.cboGroup2Opt1SumOp = new System.Windows.Forms.ComboBox();
			this.cboGroup2Opt1Fields = new System.Windows.Forms.ComboBox();
			this.cboGroup2Opt1SumTable = new System.Windows.Forms.ComboBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage1 = new System.Windows.Forms.TabPage();
			this.cmdDeleteFromGroup2Opt2 = new System.Windows.Forms.Button();
			this.cboOpt2FieldOp = new System.Windows.Forms.ComboBox();
			this.lstGroup2Opt2SelectedFieldsTable = new System.Windows.Forms.ListBox();
			this.txtOpt2Value = new System.Windows.Forms.TextBox();
			this.cboOpt2ValueOp = new System.Windows.Forms.ComboBox();
			this.lstGroup2Opt2SelectedFields = new System.Windows.Forms.ListBox();
			this.cmdGroup2Opt2AddField = new System.Windows.Forms.Button();
			this.cboGroup2Opt2SumOp = new System.Windows.Forms.ComboBox();
			this.cboGroup2Opt2Fields = new System.Windows.Forms.ComboBox();
			this.cboGroup2Opt2SumTable = new System.Windows.Forms.ComboBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this._sstabOptions_TabPage2 = new System.Windows.Forms.TabPage();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this.cboOpt3ValueOp = new System.Windows.Forms.ComboBox();
			this.txtOpt3Value = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.fraCriteriaMethod = new System.Windows.Forms.GroupBox();
			this.Opt3Method = new System.Windows.Forms.RadioButton();
			this.Opt2Method = new System.Windows.Forms.RadioButton();
			this.Opt1Method = new System.Windows.Forms.RadioButton();
			this.fraSetup.SuspendLayout();
			this.sstabOptions.SuspendLayout();
			this._sstabOptions_TabPage0.SuspendLayout();
			this._sstabOptions_TabPage1.SuspendLayout();
			this._sstabOptions_TabPage2.SuspendLayout();
			this.fraCriteriaMethod.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			this.Text = "Submission Validation Criteria Wizard";
			this.ClientSize = new System.Drawing.Size(1303, 827);
			this.Location = new System.Drawing.Point(5, 29);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
			this.Name = "frmSubmissionValidCritWizard";
			this.fraSetup.Text = "Setup Criteria";
			this.fraSetup.Enabled = false;
			this.fraSetup.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fraSetup.ForeColor = System.Drawing.Color.Blue;
			this.fraSetup.Size = new System.Drawing.Size(1298, 708);
			this.fraSetup.Location = new System.Drawing.Point(4, 108);
			this.fraSetup.TabIndex = 4;
			this.fraSetup.BackColor = System.Drawing.SystemColors.Control;
			this.fraSetup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraSetup.Visible = true;
			this.fraSetup.Padding = new System.Windows.Forms.Padding(0);
			this.fraSetup.Name = "fraSetup";
			this.cmdOpt1AddCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdOpt1AddCriteria.Text = "Add Criteria";
			this.cmdOpt1AddCriteria.Size = new System.Drawing.Size(187, 27);
			this.cmdOpt1AddCriteria.Location = new System.Drawing.Point(799, 675);
			this.cmdOpt1AddCriteria.TabIndex = 49;
			this.cmdOpt1AddCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdOpt1AddCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOpt1AddCriteria.CausesValidation = true;
			this.cmdOpt1AddCriteria.Enabled = true;
			this.cmdOpt1AddCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOpt1AddCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdOpt1AddCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOpt1AddCriteria.TabStop = true;
			this.cmdOpt1AddCriteria.Name = "cmdOpt1AddCriteria";
			this.cmdDeleteFromGroup1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteFromGroup1.Text = "Delete from Group1";
			this.cmdDeleteFromGroup1.Size = new System.Drawing.Size(302, 25);
			this.cmdDeleteFromGroup1.Location = new System.Drawing.Point(12, 317);
			this.cmdDeleteFromGroup1.TabIndex = 47;
			this.cmdDeleteFromGroup1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteFromGroup1.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteFromGroup1.CausesValidation = true;
			this.cmdDeleteFromGroup1.Enabled = true;
			this.cmdDeleteFromGroup1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteFromGroup1.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteFromGroup1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteFromGroup1.TabStop = true;
			this.cmdDeleteFromGroup1.Name = "cmdDeleteFromGroup1";
			this.lstGroup1SelectedFieldsTable.Size = new System.Drawing.Size(67, 25);
			this.lstGroup1SelectedFieldsTable.Location = new System.Drawing.Point(240, 120);
			this.lstGroup1SelectedFieldsTable.TabIndex = 36;
			this.lstGroup1SelectedFieldsTable.Visible = false;
			this.lstGroup1SelectedFieldsTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroup1SelectedFieldsTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroup1SelectedFieldsTable.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroup1SelectedFieldsTable.CausesValidation = true;
			this.lstGroup1SelectedFieldsTable.Enabled = true;
			this.lstGroup1SelectedFieldsTable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroup1SelectedFieldsTable.IntegralHeight = true;
			this.lstGroup1SelectedFieldsTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroup1SelectedFieldsTable.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroup1SelectedFieldsTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroup1SelectedFieldsTable.Sorted = false;
			this.lstGroup1SelectedFieldsTable.TabStop = true;
			this.lstGroup1SelectedFieldsTable.MultiColumn = false;
			this.lstGroup1SelectedFieldsTable.Name = "lstGroup1SelectedFieldsTable";
			this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Size = new System.Drawing.Size(160, 25);
			this.cmdCancel.Location = new System.Drawing.Point(1129, 677);
			this.cmdCancel.TabIndex = 35;
			this.cmdCancel.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.CausesValidation = true;
			this.cmdCancel.Enabled = true;
			this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancel.TabStop = true;
			this.cmdCancel.Name = "cmdCancel";
			this.lstGroup1SelectedFields.Size = new System.Drawing.Size(644, 172);
			this.lstGroup1SelectedFields.Location = new System.Drawing.Point(8, 142);
			this.lstGroup1SelectedFields.TabIndex = 12;
			this.lstGroup1SelectedFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroup1SelectedFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroup1SelectedFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroup1SelectedFields.CausesValidation = true;
			this.lstGroup1SelectedFields.Enabled = true;
			this.lstGroup1SelectedFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroup1SelectedFields.IntegralHeight = true;
			this.lstGroup1SelectedFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroup1SelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroup1SelectedFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroup1SelectedFields.Sorted = false;
			this.lstGroup1SelectedFields.TabStop = true;
			this.lstGroup1SelectedFields.Visible = true;
			this.lstGroup1SelectedFields.MultiColumn = false;
			this.lstGroup1SelectedFields.Name = "lstGroup1SelectedFields";
			this.cmdGroup1AddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGroup1AddField.Text = "Add to Group1";
			this.cmdGroup1AddField.Size = new System.Drawing.Size(133, 24);
			this.cmdGroup1AddField.Location = new System.Drawing.Point(178, 92);
			this.cmdGroup1AddField.TabIndex = 11;
			this.cmdGroup1AddField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdGroup1AddField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup1AddField.CausesValidation = true;
			this.cmdGroup1AddField.Enabled = true;
			this.cmdGroup1AddField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup1AddField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup1AddField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup1AddField.TabStop = true;
			this.cmdGroup1AddField.Name = "cmdGroup1AddField";
			this.cboGroup1Fields.Size = new System.Drawing.Size(592, 27);
			this.cboGroup1Fields.Location = new System.Drawing.Point(63, 60);
			this.cboGroup1Fields.TabIndex = 9;
			this.cboGroup1Fields.Text = "cboGroup1Fields";
			this.cboGroup1Fields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup1Fields.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup1Fields.CausesValidation = true;
			this.cboGroup1Fields.Enabled = true;
			this.cboGroup1Fields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup1Fields.IntegralHeight = true;
			this.cboGroup1Fields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup1Fields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup1Fields.Sorted = false;
			this.cboGroup1Fields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup1Fields.TabStop = true;
			this.cboGroup1Fields.Visible = true;
			this.cboGroup1Fields.Name = "cboGroup1Fields";
			this.cboGroup1SumTable.Size = new System.Drawing.Size(592, 27);
			this.cboGroup1SumTable.Location = new System.Drawing.Point(63, 29);
			this.cboGroup1SumTable.Items.AddRange(new object[] {
				"PATIENT SUMMARY",
				"HOSPITAL STATISTICS"
			});
			this.cboGroup1SumTable.TabIndex = 6;
			this.cboGroup1SumTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup1SumTable.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup1SumTable.CausesValidation = true;
			this.cboGroup1SumTable.Enabled = true;
			this.cboGroup1SumTable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup1SumTable.IntegralHeight = true;
			this.cboGroup1SumTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup1SumTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup1SumTable.Sorted = false;
			this.cboGroup1SumTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup1SumTable.TabStop = true;
			this.cboGroup1SumTable.Visible = true;
			this.cboGroup1SumTable.Name = "cboGroup1SumTable";
			this.cboGroup1SumOp.Size = new System.Drawing.Size(57, 27);
			this.cboGroup1SumOp.Location = new System.Drawing.Point(63, 90);
			this.cboGroup1SumOp.Items.AddRange(new object[] {
				"+",
				"-"
			});
			this.cboGroup1SumOp.TabIndex = 5;
			this.cboGroup1SumOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup1SumOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup1SumOp.CausesValidation = true;
			this.cboGroup1SumOp.Enabled = true;
			this.cboGroup1SumOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup1SumOp.IntegralHeight = true;
			this.cboGroup1SumOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup1SumOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup1SumOp.Sorted = false;
			this.cboGroup1SumOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup1SumOp.TabStop = true;
			this.cboGroup1SumOp.Visible = true;
			this.cboGroup1SumOp.Name = "cboGroup1SumOp";
			this.sstabOptions.Size = new System.Drawing.Size(624, 659);
			this.sstabOptions.Location = new System.Drawing.Point(660, 10);
			this.sstabOptions.TabIndex = 14;
			this.sstabOptions.SelectedIndex = 2;
			this.sstabOptions.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabOptions.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabOptions.Name = "sstabOptions";
			this._sstabOptions_TabPage0.Text = "Method 1";
			this.cmdDeleteFromGroup2Opt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteFromGroup2Opt1.Text = "Delete from Group2";
			this.cmdDeleteFromGroup2Opt1.Size = new System.Drawing.Size(382, 25);
			this.cmdDeleteFromGroup2Opt1.Location = new System.Drawing.Point(99, 294);
			this.cmdDeleteFromGroup2Opt1.TabIndex = 48;
			this.cmdDeleteFromGroup2Opt1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteFromGroup2Opt1.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteFromGroup2Opt1.CausesValidation = true;
			this.cmdDeleteFromGroup2Opt1.Enabled = true;
			this.cmdDeleteFromGroup2Opt1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteFromGroup2Opt1.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteFromGroup2Opt1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteFromGroup2Opt1.TabStop = true;
			this.cmdDeleteFromGroup2Opt1.Name = "cmdDeleteFromGroup2Opt1";
			this.lstGroup2Opt1SelectedFieldsTable.Size = new System.Drawing.Size(67, 25);
			this.lstGroup2Opt1SelectedFieldsTable.Location = new System.Drawing.Point(94, 114);
			this.lstGroup2Opt1SelectedFieldsTable.TabIndex = 37;
			this.lstGroup2Opt1SelectedFieldsTable.Visible = false;
			this.lstGroup2Opt1SelectedFieldsTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroup2Opt1SelectedFieldsTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroup2Opt1SelectedFieldsTable.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroup2Opt1SelectedFieldsTable.CausesValidation = true;
			this.lstGroup2Opt1SelectedFieldsTable.Enabled = true;
			this.lstGroup2Opt1SelectedFieldsTable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroup2Opt1SelectedFieldsTable.IntegralHeight = true;
			this.lstGroup2Opt1SelectedFieldsTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroup2Opt1SelectedFieldsTable.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroup2Opt1SelectedFieldsTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroup2Opt1SelectedFieldsTable.Sorted = false;
			this.lstGroup2Opt1SelectedFieldsTable.TabStop = true;
			this.lstGroup2Opt1SelectedFieldsTable.MultiColumn = false;
			this.lstGroup2Opt1SelectedFieldsTable.Name = "lstGroup2Opt1SelectedFieldsTable";
			this.cboOpt1FieldOp.Size = new System.Drawing.Size(67, 27);
			this.cboOpt1FieldOp.Location = new System.Drawing.Point(17, 142);
			this.cboOpt1FieldOp.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt1FieldOp.TabIndex = 20;
			this.cboOpt1FieldOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt1FieldOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt1FieldOp.CausesValidation = true;
			this.cboOpt1FieldOp.Enabled = true;
			this.cboOpt1FieldOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt1FieldOp.IntegralHeight = true;
			this.cboOpt1FieldOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt1FieldOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt1FieldOp.Sorted = false;
			this.cboOpt1FieldOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt1FieldOp.TabStop = true;
			this.cboOpt1FieldOp.Visible = true;
			this.cboOpt1FieldOp.Name = "cboOpt1FieldOp";
			this.lstGroup2Opt1SelectedFields.Size = new System.Drawing.Size(515, 155);
			this.lstGroup2Opt1SelectedFields.Location = new System.Drawing.Point(94, 142);
			this.lstGroup2Opt1SelectedFields.TabIndex = 19;
			this.lstGroup2Opt1SelectedFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroup2Opt1SelectedFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroup2Opt1SelectedFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroup2Opt1SelectedFields.CausesValidation = true;
			this.lstGroup2Opt1SelectedFields.Enabled = true;
			this.lstGroup2Opt1SelectedFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroup2Opt1SelectedFields.IntegralHeight = true;
			this.lstGroup2Opt1SelectedFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroup2Opt1SelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroup2Opt1SelectedFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroup2Opt1SelectedFields.Sorted = false;
			this.lstGroup2Opt1SelectedFields.TabStop = true;
			this.lstGroup2Opt1SelectedFields.Visible = true;
			this.lstGroup2Opt1SelectedFields.MultiColumn = false;
			this.lstGroup2Opt1SelectedFields.Name = "lstGroup2Opt1SelectedFields";
			this.cmdGroup2Opt1AddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGroup2Opt1AddField.Text = "Add to Group2";
			this.cmdGroup2Opt1AddField.Size = new System.Drawing.Size(133, 24);
			this.cmdGroup2Opt1AddField.Location = new System.Drawing.Point(344, 114);
			this.cmdGroup2Opt1AddField.TabIndex = 18;
			this.cmdGroup2Opt1AddField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdGroup2Opt1AddField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup2Opt1AddField.CausesValidation = true;
			this.cmdGroup2Opt1AddField.Enabled = true;
			this.cmdGroup2Opt1AddField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup2Opt1AddField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup2Opt1AddField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup2Opt1AddField.TabStop = true;
			this.cmdGroup2Opt1AddField.Name = "cmdGroup2Opt1AddField";
			this.cboGroup2Opt1SumOp.Size = new System.Drawing.Size(59, 27);
			this.cboGroup2Opt1SumOp.Location = new System.Drawing.Point(283, 113);
			this.cboGroup2Opt1SumOp.Items.AddRange(new object[] {
				"+",
				"-"
			});
			this.cboGroup2Opt1SumOp.TabIndex = 17;
			this.cboGroup2Opt1SumOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup2Opt1SumOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup2Opt1SumOp.CausesValidation = true;
			this.cboGroup2Opt1SumOp.Enabled = true;
			this.cboGroup2Opt1SumOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup2Opt1SumOp.IntegralHeight = true;
			this.cboGroup2Opt1SumOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup2Opt1SumOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup2Opt1SumOp.Sorted = false;
			this.cboGroup2Opt1SumOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup2Opt1SumOp.TabStop = true;
			this.cboGroup2Opt1SumOp.Visible = true;
			this.cboGroup2Opt1SumOp.Name = "cboGroup2Opt1SumOp";
			this.cboGroup2Opt1Fields.Size = new System.Drawing.Size(523, 27);
			this.cboGroup2Opt1Fields.Location = new System.Drawing.Point(92, 82);
			this.cboGroup2Opt1Fields.TabIndex = 16;
			this.cboGroup2Opt1Fields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup2Opt1Fields.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup2Opt1Fields.CausesValidation = true;
			this.cboGroup2Opt1Fields.Enabled = true;
			this.cboGroup2Opt1Fields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup2Opt1Fields.IntegralHeight = true;
			this.cboGroup2Opt1Fields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup2Opt1Fields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup2Opt1Fields.Sorted = false;
			this.cboGroup2Opt1Fields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup2Opt1Fields.TabStop = true;
			this.cboGroup2Opt1Fields.Visible = true;
			this.cboGroup2Opt1Fields.Name = "cboGroup2Opt1Fields";
			this.cboGroup2Opt1SumTable.Size = new System.Drawing.Size(523, 27);
			this.cboGroup2Opt1SumTable.Location = new System.Drawing.Point(92, 52);
			this.cboGroup2Opt1SumTable.Items.AddRange(new object[] {
				"PATIENT SUMMARY",
				"HOSPITAL STATISTICS"
			});
			this.cboGroup2Opt1SumTable.TabIndex = 15;
			this.cboGroup2Opt1SumTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup2Opt1SumTable.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup2Opt1SumTable.CausesValidation = true;
			this.cboGroup2Opt1SumTable.Enabled = true;
			this.cboGroup2Opt1SumTable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup2Opt1SumTable.IntegralHeight = true;
			this.cboGroup2Opt1SumTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup2Opt1SumTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup2Opt1SumTable.Sorted = false;
			this.cboGroup2Opt1SumTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup2Opt1SumTable.TabStop = true;
			this.cboGroup2Opt1SumTable.Visible = true;
			this.cboGroup2Opt1SumTable.Name = "cboGroup2Opt1SumTable";
			this.Label11.Text = "Comp. Op.";
			this.Label11.Size = new System.Drawing.Size(72, 20);
			this.Label11.Location = new System.Drawing.Point(18, 117);
			this.Label11.TabIndex = 38;
			this.Label11.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label11.BackColor = System.Drawing.SystemColors.Control;
			this.Label11.Enabled = true;
			this.Label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label11.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label11.UseMnemonic = true;
			this.Label11.Visible = true;
			this.Label11.AutoSize = false;
			this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label11.Name = "Label11";
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label7.Text = "Sum. Op.";
			this.Label7.Size = new System.Drawing.Size(58, 19);
			this.Label7.Location = new System.Drawing.Point(220, 117);
			this.Label7.TabIndex = 32;
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
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label6.Text = "Fields:";
			this.Label6.Size = new System.Drawing.Size(40, 17);
			this.Label6.Location = new System.Drawing.Point(48, 87);
			this.Label6.TabIndex = 31;
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
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label5.Text = "Summary Table:";
			this.Label5.Size = new System.Drawing.Size(62, 33);
			this.Label5.Location = new System.Drawing.Point(22, 43);
			this.Label5.TabIndex = 30;
			this.Label5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this._sstabOptions_TabPage1.Text = "Method 2";
			this.cmdDeleteFromGroup2Opt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteFromGroup2Opt2.Text = "Delete from Group2";
			this.cmdDeleteFromGroup2Opt2.Size = new System.Drawing.Size(382, 25);
			this.cmdDeleteFromGroup2Opt2.Location = new System.Drawing.Point(100, 247);
			this.cmdDeleteFromGroup2Opt2.TabIndex = 50;
			this.cmdDeleteFromGroup2Opt2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteFromGroup2Opt2.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteFromGroup2Opt2.CausesValidation = true;
			this.cmdDeleteFromGroup2Opt2.Enabled = true;
			this.cmdDeleteFromGroup2Opt2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteFromGroup2Opt2.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteFromGroup2Opt2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteFromGroup2Opt2.TabStop = true;
			this.cmdDeleteFromGroup2Opt2.Name = "cmdDeleteFromGroup2Opt2";
			this.cboOpt2FieldOp.Size = new System.Drawing.Size(57, 27);
			this.cboOpt2FieldOp.Location = new System.Drawing.Point(18, 142);
			this.cboOpt2FieldOp.Items.AddRange(new object[] {
				"+",
				"-"
			});
			this.cboOpt2FieldOp.TabIndex = 46;
			this.cboOpt2FieldOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt2FieldOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt2FieldOp.CausesValidation = true;
			this.cboOpt2FieldOp.Enabled = true;
			this.cboOpt2FieldOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt2FieldOp.IntegralHeight = true;
			this.cboOpt2FieldOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt2FieldOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt2FieldOp.Sorted = false;
			this.cboOpt2FieldOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt2FieldOp.TabStop = true;
			this.cboOpt2FieldOp.Visible = true;
			this.cboOpt2FieldOp.Name = "cboOpt2FieldOp";
			this.lstGroup2Opt2SelectedFieldsTable.Size = new System.Drawing.Size(67, 25);
			this.lstGroup2Opt2SelectedFieldsTable.Location = new System.Drawing.Point(97, 117);
			this.lstGroup2Opt2SelectedFieldsTable.TabIndex = 44;
			this.lstGroup2Opt2SelectedFieldsTable.Visible = false;
			this.lstGroup2Opt2SelectedFieldsTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroup2Opt2SelectedFieldsTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroup2Opt2SelectedFieldsTable.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroup2Opt2SelectedFieldsTable.CausesValidation = true;
			this.lstGroup2Opt2SelectedFieldsTable.Enabled = true;
			this.lstGroup2Opt2SelectedFieldsTable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroup2Opt2SelectedFieldsTable.IntegralHeight = true;
			this.lstGroup2Opt2SelectedFieldsTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroup2Opt2SelectedFieldsTable.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroup2Opt2SelectedFieldsTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroup2Opt2SelectedFieldsTable.Sorted = false;
			this.lstGroup2Opt2SelectedFieldsTable.TabStop = true;
			this.lstGroup2Opt2SelectedFieldsTable.MultiColumn = false;
			this.lstGroup2Opt2SelectedFieldsTable.Name = "lstGroup2Opt2SelectedFieldsTable";
			this.txtOpt2Value.AutoSize = false;
			this.txtOpt2Value.Size = new System.Drawing.Size(50, 25);
			this.txtOpt2Value.Location = new System.Drawing.Point(284, 294);
			this.txtOpt2Value.TabIndex = 27;
			this.txtOpt2Value.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtOpt2Value.AcceptsReturn = true;
			this.txtOpt2Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtOpt2Value.BackColor = System.Drawing.SystemColors.Window;
			this.txtOpt2Value.CausesValidation = true;
			this.txtOpt2Value.Enabled = true;
			this.txtOpt2Value.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOpt2Value.HideSelection = true;
			this.txtOpt2Value.ReadOnly = false;
			this.txtOpt2Value.MaxLength = 0;
			this.txtOpt2Value.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOpt2Value.Multiline = false;
			this.txtOpt2Value.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtOpt2Value.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOpt2Value.TabStop = true;
			this.txtOpt2Value.Visible = true;
			this.txtOpt2Value.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtOpt2Value.Name = "txtOpt2Value";
			this.cboOpt2ValueOp.Size = new System.Drawing.Size(54, 27);
			this.cboOpt2ValueOp.Location = new System.Drawing.Point(215, 294);
			this.cboOpt2ValueOp.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt2ValueOp.TabIndex = 26;
			this.cboOpt2ValueOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt2ValueOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt2ValueOp.CausesValidation = true;
			this.cboOpt2ValueOp.Enabled = true;
			this.cboOpt2ValueOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt2ValueOp.IntegralHeight = true;
			this.cboOpt2ValueOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt2ValueOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt2ValueOp.Sorted = false;
			this.cboOpt2ValueOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt2ValueOp.TabStop = true;
			this.cboOpt2ValueOp.Visible = true;
			this.cboOpt2ValueOp.Name = "cboOpt2ValueOp";
			this.lstGroup2Opt2SelectedFields.Size = new System.Drawing.Size(523, 107);
			this.lstGroup2Opt2SelectedFields.Location = new System.Drawing.Point(94, 142);
			this.lstGroup2Opt2SelectedFields.TabIndex = 25;
			this.lstGroup2Opt2SelectedFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstGroup2Opt2SelectedFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstGroup2Opt2SelectedFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstGroup2Opt2SelectedFields.CausesValidation = true;
			this.lstGroup2Opt2SelectedFields.Enabled = true;
			this.lstGroup2Opt2SelectedFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstGroup2Opt2SelectedFields.IntegralHeight = true;
			this.lstGroup2Opt2SelectedFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstGroup2Opt2SelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstGroup2Opt2SelectedFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstGroup2Opt2SelectedFields.Sorted = false;
			this.lstGroup2Opt2SelectedFields.TabStop = true;
			this.lstGroup2Opt2SelectedFields.Visible = true;
			this.lstGroup2Opt2SelectedFields.MultiColumn = false;
			this.lstGroup2Opt2SelectedFields.Name = "lstGroup2Opt2SelectedFields";
			this.cmdGroup2Opt2AddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGroup2Opt2AddField.Text = "Add to Group2";
			this.cmdGroup2Opt2AddField.Size = new System.Drawing.Size(133, 24);
			this.cmdGroup2Opt2AddField.Location = new System.Drawing.Point(354, 112);
			this.cmdGroup2Opt2AddField.TabIndex = 24;
			this.cmdGroup2Opt2AddField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdGroup2Opt2AddField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroup2Opt2AddField.CausesValidation = true;
			this.cmdGroup2Opt2AddField.Enabled = true;
			this.cmdGroup2Opt2AddField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroup2Opt2AddField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroup2Opt2AddField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroup2Opt2AddField.TabStop = true;
			this.cmdGroup2Opt2AddField.Name = "cmdGroup2Opt2AddField";
			this.cboGroup2Opt2SumOp.Size = new System.Drawing.Size(63, 27);
			this.cboGroup2Opt2SumOp.Location = new System.Drawing.Point(287, 112);
			this.cboGroup2Opt2SumOp.Items.AddRange(new object[] {
				"+",
				"-"
			});
			this.cboGroup2Opt2SumOp.TabIndex = 23;
			this.cboGroup2Opt2SumOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup2Opt2SumOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup2Opt2SumOp.CausesValidation = true;
			this.cboGroup2Opt2SumOp.Enabled = true;
			this.cboGroup2Opt2SumOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup2Opt2SumOp.IntegralHeight = true;
			this.cboGroup2Opt2SumOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup2Opt2SumOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup2Opt2SumOp.Sorted = false;
			this.cboGroup2Opt2SumOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup2Opt2SumOp.TabStop = true;
			this.cboGroup2Opt2SumOp.Visible = true;
			this.cboGroup2Opt2SumOp.Name = "cboGroup2Opt2SumOp";
			this.cboGroup2Opt2Fields.Size = new System.Drawing.Size(525, 27);
			this.cboGroup2Opt2Fields.Location = new System.Drawing.Point(92, 80);
			this.cboGroup2Opt2Fields.TabIndex = 22;
			this.cboGroup2Opt2Fields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup2Opt2Fields.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup2Opt2Fields.CausesValidation = true;
			this.cboGroup2Opt2Fields.Enabled = true;
			this.cboGroup2Opt2Fields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup2Opt2Fields.IntegralHeight = true;
			this.cboGroup2Opt2Fields.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup2Opt2Fields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup2Opt2Fields.Sorted = false;
			this.cboGroup2Opt2Fields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup2Opt2Fields.TabStop = true;
			this.cboGroup2Opt2Fields.Visible = true;
			this.cboGroup2Opt2Fields.Name = "cboGroup2Opt2Fields";
			this.cboGroup2Opt2SumTable.Size = new System.Drawing.Size(525, 27);
			this.cboGroup2Opt2SumTable.Location = new System.Drawing.Point(92, 49);
			this.cboGroup2Opt2SumTable.Items.AddRange(new object[] {
				"PATIENT SUMMARY",
				"HOSPITAL STATISTICS"
			});
			this.cboGroup2Opt2SumTable.TabIndex = 21;
			this.cboGroup2Opt2SumTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboGroup2Opt2SumTable.BackColor = System.Drawing.SystemColors.Window;
			this.cboGroup2Opt2SumTable.CausesValidation = true;
			this.cboGroup2Opt2SumTable.Enabled = true;
			this.cboGroup2Opt2SumTable.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboGroup2Opt2SumTable.IntegralHeight = true;
			this.cboGroup2Opt2SumTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboGroup2Opt2SumTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboGroup2Opt2SumTable.Sorted = false;
			this.cboGroup2Opt2SumTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboGroup2Opt2SumTable.TabStop = true;
			this.cboGroup2Opt2SumTable.Visible = true;
			this.cboGroup2Opt2SumTable.Name = "cboGroup2Opt2SumTable";
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label9.Text = "Fields:";
			this.Label9.Size = new System.Drawing.Size(40, 17);
			this.Label9.Location = new System.Drawing.Point(48, 87);
			this.Label9.TabIndex = 45;
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
			this.Label14.Text = "Result";
			this.Label14.Size = new System.Drawing.Size(57, 15);
			this.Label14.Location = new System.Drawing.Point(287, 275);
			this.Label14.TabIndex = 41;
			this.Label14.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label14.BackColor = System.Drawing.SystemColors.Control;
			this.Label14.Enabled = true;
			this.Label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label14.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label14.UseMnemonic = true;
			this.Label14.Visible = true;
			this.Label14.AutoSize = false;
			this.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label14.Name = "Label14";
			this.Label13.Text = "Result Op.";
			this.Label13.Size = new System.Drawing.Size(78, 19);
			this.Label13.Location = new System.Drawing.Point(208, 274);
			this.Label13.TabIndex = 40;
			this.Label13.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label13.BackColor = System.Drawing.SystemColors.Control;
			this.Label13.Enabled = true;
			this.Label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label13.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label13.UseMnemonic = true;
			this.Label13.Visible = true;
			this.Label13.AutoSize = false;
			this.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label13.Name = "Label13";
			this.Label12.Text = "Group Op.";
			this.Label12.Size = new System.Drawing.Size(67, 20);
			this.Label12.Location = new System.Drawing.Point(17, 120);
			this.Label12.TabIndex = 39;
			this.Label12.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label12.BackColor = System.Drawing.SystemColors.Control;
			this.Label12.Enabled = true;
			this.Label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label12.UseMnemonic = true;
			this.Label12.Visible = true;
			this.Label12.AutoSize = false;
			this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label12.Name = "Label12";
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label10.Text = "Sum Op.";
			this.Label10.Size = new System.Drawing.Size(62, 19);
			this.Label10.Location = new System.Drawing.Point(219, 115);
			this.Label10.TabIndex = 34;
			this.Label10.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label10.BackColor = System.Drawing.SystemColors.Control;
			this.Label10.Enabled = true;
			this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.UseMnemonic = true;
			this.Label10.Visible = true;
			this.Label10.AutoSize = false;
			this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label10.Name = "Label10";
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label8.Text = "Summary Table:";
			this.Label8.Size = new System.Drawing.Size(62, 37);
			this.Label8.Location = new System.Drawing.Point(22, 43);
			this.Label8.TabIndex = 33;
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
			this._sstabOptions_TabPage2.Text = "Method 3";
			this.Label15.Text = "Result Op.";
			this.Label15.Size = new System.Drawing.Size(78, 20);
			this.Label15.Location = new System.Drawing.Point(172, 115);
			this.Label15.TabIndex = 42;
			this.Label15.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label15.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label15.BackColor = System.Drawing.SystemColors.Control;
			this.Label15.Enabled = true;
			this.Label15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label15.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label15.UseMnemonic = true;
			this.Label15.Visible = true;
			this.Label15.AutoSize = false;
			this.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label15.Name = "Label15";
			this.Label16.Text = "Result";
			this.Label16.Size = new System.Drawing.Size(57, 15);
			this.Label16.Location = new System.Drawing.Point(250, 117);
			this.Label16.TabIndex = 43;
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
			this.cboOpt3ValueOp.Size = new System.Drawing.Size(62, 27);
			this.cboOpt3ValueOp.Location = new System.Drawing.Point(182, 137);
			this.cboOpt3ValueOp.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOpt3ValueOp.TabIndex = 28;
			this.cboOpt3ValueOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOpt3ValueOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboOpt3ValueOp.CausesValidation = true;
			this.cboOpt3ValueOp.Enabled = true;
			this.cboOpt3ValueOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOpt3ValueOp.IntegralHeight = true;
			this.cboOpt3ValueOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOpt3ValueOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOpt3ValueOp.Sorted = false;
			this.cboOpt3ValueOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOpt3ValueOp.TabStop = true;
			this.cboOpt3ValueOp.Visible = true;
			this.cboOpt3ValueOp.Name = "cboOpt3ValueOp";
			this.txtOpt3Value.AutoSize = false;
			this.txtOpt3Value.Size = new System.Drawing.Size(65, 24);
			this.txtOpt3Value.Location = new System.Drawing.Point(248, 139);
			this.txtOpt3Value.TabIndex = 29;
			this.txtOpt3Value.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtOpt3Value.AcceptsReturn = true;
			this.txtOpt3Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtOpt3Value.BackColor = System.Drawing.SystemColors.Window;
			this.txtOpt3Value.CausesValidation = true;
			this.txtOpt3Value.Enabled = true;
			this.txtOpt3Value.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtOpt3Value.HideSelection = true;
			this.txtOpt3Value.ReadOnly = false;
			this.txtOpt3Value.MaxLength = 0;
			this.txtOpt3Value.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtOpt3Value.Multiline = false;
			this.txtOpt3Value.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtOpt3Value.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtOpt3Value.TabStop = true;
			this.txtOpt3Value.Visible = true;
			this.txtOpt3Value.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtOpt3Value.Name = "txtOpt3Value";
			this.Label4.Text = "Group1 Fields";
			this.Label4.Size = new System.Drawing.Size(140, 18);
			this.Label4.Location = new System.Drawing.Point(7, 123);
			this.Label4.TabIndex = 13;
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
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label3.Text = "Sum Op.";
			this.Label3.Size = new System.Drawing.Size(55, 22);
			this.Label3.Location = new System.Drawing.Point(4, 93);
			this.Label3.TabIndex = 10;
			this.Label3.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label2.Text = "Fields:";
			this.Label2.Size = new System.Drawing.Size(52, 17);
			this.Label2.Location = new System.Drawing.Point(8, 65);
			this.Label2.TabIndex = 8;
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
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label1.Text = "Summary Table:";
			this.Label1.Size = new System.Drawing.Size(59, 38);
			this.Label1.Location = new System.Drawing.Point(3, 27);
			this.Label1.TabIndex = 7;
			this.Label1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.fraCriteriaMethod.Text = "Select the criteria method";
			this.fraCriteriaMethod.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fraCriteriaMethod.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.fraCriteriaMethod.Size = new System.Drawing.Size(1298, 103);
			this.fraCriteriaMethod.Location = new System.Drawing.Point(4, 0);
			this.fraCriteriaMethod.TabIndex = 0;
			this.fraCriteriaMethod.BackColor = System.Drawing.SystemColors.Control;
			this.fraCriteriaMethod.Enabled = true;
			this.fraCriteriaMethod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraCriteriaMethod.Visible = true;
			this.fraCriteriaMethod.Padding = new System.Windows.Forms.Padding(0);
			this.fraCriteriaMethod.Name = "fraCriteriaMethod";
			this.Opt3Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3Method.Text = "Compare Group1 fields to a fix value.";
			this.Opt3Method.Size = new System.Drawing.Size(762, 24);
			this.Opt3Method.Location = new System.Drawing.Point(12, 70);
			this.Opt3Method.TabIndex = 3;
			this.Opt3Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt3Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt3Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt3Method.CausesValidation = true;
			this.Opt3Method.Enabled = true;
			this.Opt3Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt3Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt3Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt3Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt3Method.TabStop = true;
			this.Opt3Method.Checked = false;
			this.Opt3Method.Visible = true;
			this.Opt3Method.Name = "Opt3Method";
			this.Opt2Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt2Method.Text = "Add or subtract Group1 fields to/from Group2 fields, and compare the result to a fix value";
			this.Opt2Method.Size = new System.Drawing.Size(762, 29);
			this.Opt2Method.Location = new System.Drawing.Point(12, 44);
			this.Opt2Method.TabIndex = 2;
			this.Opt2Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt2Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt2Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt2Method.CausesValidation = true;
			this.Opt2Method.Enabled = true;
			this.Opt2Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt2Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt2Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt2Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt2Method.TabStop = true;
			this.Opt2Method.Checked = false;
			this.Opt2Method.Visible = true;
			this.Opt2Method.Name = "Opt2Method";
			this.Opt1Method.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt1Method.Text = "Compare Group1 fields to Group2 Fields";
			this.Opt1Method.Size = new System.Drawing.Size(762, 25);
			this.Opt1Method.Location = new System.Drawing.Point(12, 20);
			this.Opt1Method.TabIndex = 1;
			this.Opt1Method.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Opt1Method.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Opt1Method.BackColor = System.Drawing.SystemColors.Control;
			this.Opt1Method.CausesValidation = true;
			this.Opt1Method.Enabled = true;
			this.Opt1Method.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Opt1Method.Cursor = System.Windows.Forms.Cursors.Default;
			this.Opt1Method.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Opt1Method.Appearance = System.Windows.Forms.Appearance.Normal;
			this.Opt1Method.TabStop = true;
			this.Opt1Method.Checked = false;
			this.Opt1Method.Visible = true;
			this.Opt1Method.Name = "Opt1Method";
			this.Controls.Add(fraSetup);
			this.Controls.Add(fraCriteriaMethod);
			this.fraSetup.Controls.Add(cmdOpt1AddCriteria);
			this.fraSetup.Controls.Add(cmdDeleteFromGroup1);
			this.fraSetup.Controls.Add(lstGroup1SelectedFieldsTable);
			this.fraSetup.Controls.Add(cmdCancel);
			this.fraSetup.Controls.Add(lstGroup1SelectedFields);
			this.fraSetup.Controls.Add(cmdGroup1AddField);
			this.fraSetup.Controls.Add(cboGroup1Fields);
			this.fraSetup.Controls.Add(cboGroup1SumTable);
			this.fraSetup.Controls.Add(cboGroup1SumOp);
			this.fraSetup.Controls.Add(sstabOptions);
			this.fraSetup.Controls.Add(Label4);
			this.fraSetup.Controls.Add(Label3);
			this.fraSetup.Controls.Add(Label2);
			this.fraSetup.Controls.Add(Label1);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage0);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage1);
			this.sstabOptions.Controls.Add(_sstabOptions_TabPage2);
			this._sstabOptions_TabPage0.Controls.Add(cmdDeleteFromGroup2Opt1);
			this._sstabOptions_TabPage0.Controls.Add(lstGroup2Opt1SelectedFieldsTable);
			this._sstabOptions_TabPage0.Controls.Add(cboOpt1FieldOp);
			this._sstabOptions_TabPage0.Controls.Add(lstGroup2Opt1SelectedFields);
			this._sstabOptions_TabPage0.Controls.Add(cmdGroup2Opt1AddField);
			this._sstabOptions_TabPage0.Controls.Add(cboGroup2Opt1SumOp);
			this._sstabOptions_TabPage0.Controls.Add(cboGroup2Opt1Fields);
			this._sstabOptions_TabPage0.Controls.Add(cboGroup2Opt1SumTable);
			this._sstabOptions_TabPage0.Controls.Add(Label11);
			this._sstabOptions_TabPage0.Controls.Add(Label7);
			this._sstabOptions_TabPage0.Controls.Add(Label6);
			this._sstabOptions_TabPage0.Controls.Add(Label5);
			this._sstabOptions_TabPage1.Controls.Add(cmdDeleteFromGroup2Opt2);
			this._sstabOptions_TabPage1.Controls.Add(cboOpt2FieldOp);
			this._sstabOptions_TabPage1.Controls.Add(lstGroup2Opt2SelectedFieldsTable);
			this._sstabOptions_TabPage1.Controls.Add(txtOpt2Value);
			this._sstabOptions_TabPage1.Controls.Add(cboOpt2ValueOp);
			this._sstabOptions_TabPage1.Controls.Add(lstGroup2Opt2SelectedFields);
			this._sstabOptions_TabPage1.Controls.Add(cmdGroup2Opt2AddField);
			this._sstabOptions_TabPage1.Controls.Add(cboGroup2Opt2SumOp);
			this._sstabOptions_TabPage1.Controls.Add(cboGroup2Opt2Fields);
			this._sstabOptions_TabPage1.Controls.Add(cboGroup2Opt2SumTable);
			this._sstabOptions_TabPage1.Controls.Add(Label9);
			this._sstabOptions_TabPage1.Controls.Add(Label14);
			this._sstabOptions_TabPage1.Controls.Add(Label13);
			this._sstabOptions_TabPage1.Controls.Add(Label12);
			this._sstabOptions_TabPage1.Controls.Add(Label10);
			this._sstabOptions_TabPage1.Controls.Add(Label8);
			this._sstabOptions_TabPage2.Controls.Add(Label15);
			this._sstabOptions_TabPage2.Controls.Add(Label16);
			this._sstabOptions_TabPage2.Controls.Add(cboOpt3ValueOp);
			this._sstabOptions_TabPage2.Controls.Add(txtOpt3Value);
			this.fraCriteriaMethod.Controls.Add(Opt3Method);
			this.fraCriteriaMethod.Controls.Add(Opt2Method);
			this.fraCriteriaMethod.Controls.Add(Opt1Method);
			this.fraSetup.ResumeLayout(false);
			this.sstabOptions.ResumeLayout(false);
			this._sstabOptions_TabPage0.ResumeLayout(false);
			this._sstabOptions_TabPage1.ResumeLayout(false);
			this._sstabOptions_TabPage2.ResumeLayout(false);
			this.fraCriteriaMethod.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
