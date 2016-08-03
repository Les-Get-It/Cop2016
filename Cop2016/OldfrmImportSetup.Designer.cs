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
	partial class OldfrmImportSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmImportSetup() : base()
		{
			Load += frmImportSetup_Load;
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
		public AxMSRDC.AxMSRDC rdcImportValError;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.ListBox lstSelectedFields;
		private System.Windows.Forms.Button withEventsField_cmdRemoveField;
		public System.Windows.Forms.Button cmdRemoveField {
			get { return withEventsField_cmdRemoveField; }
			set {
				if (withEventsField_cmdRemoveField != null) {
					withEventsField_cmdRemoveField.Click -= cmdRemoveField_Click;
				}
				withEventsField_cmdRemoveField = value;
				if (withEventsField_cmdRemoveField != null) {
					withEventsField_cmdRemoveField.Click += cmdRemoveField_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddField;
		public System.Windows.Forms.Button cmdAddField {
			get { return withEventsField_cmdAddField; }
			set {
				if (withEventsField_cmdAddField != null) {
					withEventsField_cmdAddField.Click -= cmdAddField_Click;
				}
				withEventsField_cmdAddField = value;
				if (withEventsField_cmdAddField != null) {
					withEventsField_cmdAddField.Click += cmdAddField_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstAvailableFields;
		private System.Windows.Forms.Button withEventsField_cmdMoveFieldup;
		public System.Windows.Forms.Button cmdMoveFieldup {
			get { return withEventsField_cmdMoveFieldup; }
			set {
				if (withEventsField_cmdMoveFieldup != null) {
					withEventsField_cmdMoveFieldup.Click -= cmdMoveFieldup_Click;
				}
				withEventsField_cmdMoveFieldup = value;
				if (withEventsField_cmdMoveFieldup != null) {
					withEventsField_cmdMoveFieldup.Click += cmdMoveFieldup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveFieldDown;
		public System.Windows.Forms.Button cmdMoveFieldDown {
			get { return withEventsField_cmdMoveFieldDown; }
			set {
				if (withEventsField_cmdMoveFieldDown != null) {
					withEventsField_cmdMoveFieldDown.Click -= cmdMoveFieldDown_Click;
				}
				withEventsField_cmdMoveFieldDown = value;
				if (withEventsField_cmdMoveFieldDown != null) {
					withEventsField_cmdMoveFieldDown.Click += cmdMoveFieldDown_Click;
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
		public System.Windows.Forms.TabPage _sstabImport_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdCopyValidation;
		public System.Windows.Forms.Button cmdCopyValidation {
			get { return withEventsField_cmdCopyValidation; }
			set {
				if (withEventsField_cmdCopyValidation != null) {
					withEventsField_cmdCopyValidation.Click -= cmdCopyValidation_Click;
				}
				withEventsField_cmdCopyValidation = value;
				if (withEventsField_cmdCopyValidation != null) {
					withEventsField_cmdCopyValidation.Click += cmdCopyValidation_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSubmit;
		public System.Windows.Forms.Button cmdSubmit {
			get { return withEventsField_cmdSubmit; }
			set {
				if (withEventsField_cmdSubmit != null) {
					withEventsField_cmdSubmit.Click -= cmdSubmit_Click;
				}
				withEventsField_cmdSubmit = value;
				if (withEventsField_cmdSubmit != null) {
					withEventsField_cmdSubmit.Click += cmdSubmit_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboLookupValues;
		public System.Windows.Forms.ComboBox cboLookupValues {
			get { return withEventsField_cboLookupValues; }
			set {
				if (withEventsField_cboLookupValues != null) {
					withEventsField_cboLookupValues.SelectedIndexChanged -= cboLookupValues_SelectedIndexChanged;
				}
				withEventsField_cboLookupValues = value;
				if (withEventsField_cboLookupValues != null) {
					withEventsField_cboLookupValues.SelectedIndexChanged += cboLookupValues_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtCriteria;
		public System.Windows.Forms.TextBox txtCriteria {
			get { return withEventsField_txtCriteria; }
			set {
				if (withEventsField_txtCriteria != null) {
					withEventsField_txtCriteria.TextChanged -= txtCriteria_TextChanged;
				}
				withEventsField_txtCriteria = value;
				if (withEventsField_txtCriteria != null) {
					withEventsField_txtCriteria.TextChanged += txtCriteria_TextChanged;
				}
			}
		}
		public System.Windows.Forms.RadioButton _optCritValue_1;
		public System.Windows.Forms.RadioButton _OptCritBlank_2;
		public System.Windows.Forms.RadioButton _OptCritLKUp_4;
		private System.Windows.Forms.ComboBox withEventsField_cboLookupList;
		public System.Windows.Forms.ComboBox cboLookupList {
			get { return withEventsField_cboLookupList; }
			set {
				if (withEventsField_cboLookupList != null) {
					withEventsField_cboLookupList.SelectedIndexChanged -= cboLookupList_SelectedIndexChanged;
				}
				withEventsField_cboLookupList = value;
				if (withEventsField_cboLookupList != null) {
					withEventsField_cboLookupList.SelectedIndexChanged += cboLookupList_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.GroupBox fraCriteria;
		public System.Windows.Forms.ComboBox cboOperation;
		private System.Windows.Forms.Button withEventsField_cmdOr;
		public System.Windows.Forms.Button cmdOr {
			get { return withEventsField_cmdOr; }
			set {
				if (withEventsField_cmdOr != null) {
					withEventsField_cmdOr.Click -= cmdOr_Click;
				}
				withEventsField_cmdOr = value;
				if (withEventsField_cmdOr != null) {
					withEventsField_cmdOr.Click += cmdOr_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAnd;
		public System.Windows.Forms.Button cmdAnd {
			get { return withEventsField_cmdAnd; }
			set {
				if (withEventsField_cmdAnd != null) {
					withEventsField_cmdAnd.Click -= cmdAnd_Click;
				}
				withEventsField_cmdAnd = value;
				if (withEventsField_cmdAnd != null) {
					withEventsField_cmdAnd.Click += cmdAnd_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdHelp;
		public System.Windows.Forms.Button cmdHelp {
			get { return withEventsField_cmdHelp; }
			set {
				if (withEventsField_cmdHelp != null) {
					withEventsField_cmdHelp.Click -= cmdHelp_Click;
				}
				withEventsField_cmdHelp = value;
				if (withEventsField_cmdHelp != null) {
					withEventsField_cmdHelp.Click += cmdHelp_Click;
				}
			}
		}
		public System.Windows.Forms.Label dtHelp;
		private System.Windows.Forms.ListBox withEventsField_lstImportFields;
		public System.Windows.Forms.ListBox lstImportFields {
			get { return withEventsField_lstImportFields; }
			set {
				if (withEventsField_lstImportFields != null) {
					withEventsField_lstImportFields.SelectedIndexChanged -= lstImportFields_SelectedIndexChanged;
				}
				withEventsField_lstImportFields = value;
				if (withEventsField_lstImportFields != null) {
					withEventsField_lstImportFields.SelectedIndexChanged += lstImportFields_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcReports;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button withEventsField_cmdAddError;
		public System.Windows.Forms.Button cmdAddError {
			get { return withEventsField_cmdAddError; }
			set {
				if (withEventsField_cmdAddError != null) {
					withEventsField_cmdAddError.Click -= cmdAddError_Click;
				}
				withEventsField_cmdAddError = value;
				if (withEventsField_cmdAddError != null) {
					withEventsField_cmdAddError.Click += cmdAddError_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveError;
		public System.Windows.Forms.Button cmdRemoveError {
			get { return withEventsField_cmdRemoveError; }
			set {
				if (withEventsField_cmdRemoveError != null) {
					withEventsField_cmdRemoveError.Click -= cmdRemoveError_Click;
				}
				withEventsField_cmdRemoveError = value;
				if (withEventsField_cmdRemoveError != null) {
					withEventsField_cmdRemoveError.Click += cmdRemoveError_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstCriteria;
		private System.Windows.Forms.Button withEventsField_cmdRemoveCriteria;
		public System.Windows.Forms.Button cmdRemoveCriteria {
			get { return withEventsField_cmdRemoveCriteria; }
			set {
				if (withEventsField_cmdRemoveCriteria != null) {
					withEventsField_cmdRemoveCriteria.Click -= cmdRemoveCriteria_Click;
				}
				withEventsField_cmdRemoveCriteria = value;
				if (withEventsField_cmdRemoveCriteria != null) {
					withEventsField_cmdRemoveCriteria.Click += cmdRemoveCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEditError;
		public System.Windows.Forms.Button cmdEditError {
			get { return withEventsField_cmdEditError; }
			set {
				if (withEventsField_cmdEditError != null) {
					withEventsField_cmdEditError.Click -= cmdEditError_Click;
				}
				withEventsField_cmdEditError = value;
				if (withEventsField_cmdEditError != null) {
					withEventsField_cmdEditError.Click += cmdEditError_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtAction;
		private System.Windows.Forms.Button withEventsField_cmdChangetoWarning;
		public System.Windows.Forms.Button cmdChangetoWarning {
			get { return withEventsField_cmdChangetoWarning; }
			set {
				if (withEventsField_cmdChangetoWarning != null) {
					withEventsField_cmdChangetoWarning.Click -= cmdChangeToWarning_Click;
				}
				withEventsField_cmdChangetoWarning = value;
				if (withEventsField_cmdChangetoWarning != null) {
					withEventsField_cmdChangetoWarning.Click += cmdChangeToWarning_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabValidation_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdChangeToError;
		public System.Windows.Forms.Button cmdChangeToError {
			get { return withEventsField_cmdChangeToError; }
			set {
				if (withEventsField_cmdChangeToError != null) {
					withEventsField_cmdChangeToError.Click -= cmdChangeToError_Click;
				}
				withEventsField_cmdChangeToError = value;
				if (withEventsField_cmdChangeToError != null) {
					withEventsField_cmdChangeToError.Click += cmdChangeToError_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdEditWarning;
		public System.Windows.Forms.Button cmdEditWarning {
			get { return withEventsField_cmdEditWarning; }
			set {
				if (withEventsField_cmdEditWarning != null) {
					withEventsField_cmdEditWarning.Click -= cmdEditWarning_Click;
				}
				withEventsField_cmdEditWarning = value;
				if (withEventsField_cmdEditWarning != null) {
					withEventsField_cmdEditWarning.Click += cmdEditWarning_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveWCriteria;
		public System.Windows.Forms.Button cmdRemoveWCriteria {
			get { return withEventsField_cmdRemoveWCriteria; }
			set {
				if (withEventsField_cmdRemoveWCriteria != null) {
					withEventsField_cmdRemoveWCriteria.Click -= cmdRemoveWCriteria_Click;
				}
				withEventsField_cmdRemoveWCriteria = value;
				if (withEventsField_cmdRemoveWCriteria != null) {
					withEventsField_cmdRemoveWCriteria.Click += cmdRemoveWCriteria_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstWCriteria;
		private System.Windows.Forms.Button withEventsField_cmdAddWarning;
		public System.Windows.Forms.Button cmdAddWarning {
			get { return withEventsField_cmdAddWarning; }
			set {
				if (withEventsField_cmdAddWarning != null) {
					withEventsField_cmdAddWarning.Click -= cmdAddWarning_Click;
				}
				withEventsField_cmdAddWarning = value;
				if (withEventsField_cmdAddWarning != null) {
					withEventsField_cmdAddWarning.Click += cmdAddWarning_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRemoveWarning;
		public System.Windows.Forms.Button cmdRemoveWarning {
			get { return withEventsField_cmdRemoveWarning; }
			set {
				if (withEventsField_cmdRemoveWarning != null) {
					withEventsField_cmdRemoveWarning.Click -= cmdRemoveWarning_Click;
				}
				withEventsField_cmdRemoveWarning = value;
				if (withEventsField_cmdRemoveWarning != null) {
					withEventsField_cmdRemoveWarning.Click += cmdRemoveWarning_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.TabPage _sstabValidation_TabPage1;
		private System.Windows.Forms.TabControl withEventsField_sstabValidation;
		public System.Windows.Forms.TabControl sstabValidation {
			get { return withEventsField_sstabValidation; }
			set {
				if (withEventsField_sstabValidation != null) {
					withEventsField_sstabValidation.SelectedIndexChanged -= sstabValidation_SelectedIndexChanged;
				}
				withEventsField_sstabValidation = value;
				if (withEventsField_sstabValidation != null) {
					withEventsField_sstabValidation.SelectedIndexChanged += sstabValidation_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.TabPage _sstabImport_TabPage1;
		public System.Windows.Forms.TabControl sstabImport;
		public AxMSRDC.AxMSRDC rdcImportValWarning;
		public System.Windows.Forms.Label lblThisSetup;
		public Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray OptCritBlank;
		public Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray OptCritLKUp;
		public Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray optCritValue;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmImportSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.rdcImportValError = new AxMSRDC.AxMSRDC();
			this.sstabImport = new System.Windows.Forms.TabControl();
			this._sstabImport_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.lstSelectedFields = new System.Windows.Forms.ListBox();
			this.cmdRemoveField = new System.Windows.Forms.Button();
			this.cmdAddField = new System.Windows.Forms.Button();
			this.lstAvailableFields = new System.Windows.Forms.ListBox();
			this.cmdMoveFieldup = new System.Windows.Forms.Button();
			this.cmdMoveFieldDown = new System.Windows.Forms.Button();
			this.cmdMoveToAbsPosition = new System.Windows.Forms.Button();
			this._sstabImport_TabPage1 = new System.Windows.Forms.TabPage();
			this.cmdCopyValidation = new System.Windows.Forms.Button();
			this.cmdSubmit = new System.Windows.Forms.Button();
			this.fraCriteria = new System.Windows.Forms.GroupBox();
			this.cboLookupValues = new System.Windows.Forms.ComboBox();
			this.txtCriteria = new System.Windows.Forms.TextBox();
			this._optCritValue_1 = new System.Windows.Forms.RadioButton();
			this._OptCritBlank_2 = new System.Windows.Forms.RadioButton();
			this._OptCritLKUp_4 = new System.Windows.Forms.RadioButton();
			this.cboLookupList = new System.Windows.Forms.ComboBox();
			this.cboOperation = new System.Windows.Forms.ComboBox();
			this.cmdOr = new System.Windows.Forms.Button();
			this.cmdAnd = new System.Windows.Forms.Button();
			this.cmdHelp = new System.Windows.Forms.Button();
			this.dtHelp = new System.Windows.Forms.Label();
			this.lstImportFields = new System.Windows.Forms.ListBox();
			this.rdcReports = new AxMSRDC.AxMSRDC();
			this.sstabValidation = new System.Windows.Forms.TabControl();
			this._sstabValidation_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmdAddError = new System.Windows.Forms.Button();
			this.cmdRemoveError = new System.Windows.Forms.Button();
			this.lstCriteria = new System.Windows.Forms.ListBox();
			this.cmdRemoveCriteria = new System.Windows.Forms.Button();
			this.cmdEditError = new System.Windows.Forms.Button();
			this.txtAction = new System.Windows.Forms.TextBox();
			this.cmdChangetoWarning = new System.Windows.Forms.Button();
			this._sstabValidation_TabPage1 = new System.Windows.Forms.TabPage();
			this.cmdChangeToError = new System.Windows.Forms.Button();
			this.cmdEditWarning = new System.Windows.Forms.Button();
			this.cmdRemoveWCriteria = new System.Windows.Forms.Button();
			this.lstWCriteria = new System.Windows.Forms.ListBox();
			this.cmdAddWarning = new System.Windows.Forms.Button();
			this.cmdRemoveWarning = new System.Windows.Forms.Button();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.rdcImportValWarning = new AxMSRDC.AxMSRDC();
			this.lblThisSetup = new System.Windows.Forms.Label();
			this.OptCritBlank = new Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components);
			this.OptCritLKUp = new Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components);
			this.optCritValue = new Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components);
			this.sstabImport.SuspendLayout();
			this._sstabImport_TabPage0.SuspendLayout();
			this._sstabImport_TabPage1.SuspendLayout();
			this.fraCriteria.SuspendLayout();
			this.sstabValidation.SuspendLayout();
			this._sstabValidation_TabPage0.SuspendLayout();
			this._sstabValidation_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcImportValError).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcReports).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcImportValWarning).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.OptCritBlank).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.OptCritLKUp).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.optCritValue).BeginInit();
			this.Text = " Import Setup Form";
			this.ClientSize = new System.Drawing.Size(953, 723);
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
			this.Name = "frmImportSetup";
			rdcImportValError.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcImportValError.OcxState");
			this.rdcImportValError.Size = new System.Drawing.Size(303, 28);
			this.rdcImportValError.Location = new System.Drawing.Point(0, 830);
			this.rdcImportValError.Visible = false;
			this.rdcImportValError.Name = "rdcImportValError";
			this.sstabImport.Size = new System.Drawing.Size(927, 790);
			this.sstabImport.Location = new System.Drawing.Point(12, 29);
			this.sstabImport.TabIndex = 0;
			this.sstabImport.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabImport.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabImport.Name = "sstabImport";
			this._sstabImport_TabPage0.Text = "Import Field List";
			this.Label1.Text = "Selected Field for Import";
			this.Label1.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label1.Size = new System.Drawing.Size(225, 22);
			this.Label1.Location = new System.Drawing.Point(464, 84);
			this.Label1.TabIndex = 25;
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
			this.Label5.Text = "Available Fields";
			this.Label5.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label5.Size = new System.Drawing.Size(268, 22);
			this.Label5.Location = new System.Drawing.Point(29, 97);
			this.Label5.TabIndex = 26;
			this.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label5.BackColor = System.Drawing.SystemColors.Control;
			this.Label5.Enabled = true;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.UseMnemonic = true;
			this.Label5.Visible = true;
			this.Label5.AutoSize = false;
			this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label5.Name = "Label5";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.Label3.Text = "Patient Record Number is always considered the first field in the list.";
			this.Label3.Font = new System.Drawing.Font("Arial", 9.6f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.Label3.Size = new System.Drawing.Size(664, 20);
			this.Label3.Location = new System.Drawing.Point(38, 43);
			this.Label3.TabIndex = 40;
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Enabled = true;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.UseMnemonic = true;
			this.Label3.Visible = true;
			this.Label3.AutoSize = false;
			this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label3.Name = "Label3";
			this.Label7.Text = "1. Patient Record Number";
			this.Label7.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.Size = new System.Drawing.Size(263, 18);
			this.Label7.Location = new System.Drawing.Point(473, 107);
			this.Label7.TabIndex = 41;
			this.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.Label8.Text = "Discharge Date is a required Field.";
			this.Label8.Font = new System.Drawing.Font("Arial", 9.6f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			this.Label8.Size = new System.Drawing.Size(664, 20);
			this.Label8.Location = new System.Drawing.Point(38, 67);
			this.Label8.TabIndex = 42;
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.lstSelectedFields.Size = new System.Drawing.Size(442, 568);
			this.lstSelectedFields.Location = new System.Drawing.Point(470, 130);
			this.lstSelectedFields.TabIndex = 15;
			this.lstSelectedFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSelectedFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSelectedFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstSelectedFields.CausesValidation = true;
			this.lstSelectedFields.Enabled = true;
			this.lstSelectedFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSelectedFields.IntegralHeight = true;
			this.lstSelectedFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSelectedFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSelectedFields.Sorted = false;
			this.lstSelectedFields.TabStop = true;
			this.lstSelectedFields.Visible = true;
			this.lstSelectedFields.MultiColumn = false;
			this.lstSelectedFields.Name = "lstSelectedFields";
			this.cmdRemoveField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveField.Text = "<<==";
			this.cmdRemoveField.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveField.Size = new System.Drawing.Size(57, 30);
			this.cmdRemoveField.Location = new System.Drawing.Point(410, 269);
			this.cmdRemoveField.TabIndex = 16;
			this.cmdRemoveField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveField.CausesValidation = true;
			this.cmdRemoveField.Enabled = true;
			this.cmdRemoveField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveField.TabStop = true;
			this.cmdRemoveField.Name = "cmdRemoveField";
			this.cmdAddField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddField.Text = "==>>";
			this.cmdAddField.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddField.Size = new System.Drawing.Size(58, 30);
			this.cmdAddField.Location = new System.Drawing.Point(409, 232);
			this.cmdAddField.TabIndex = 17;
			this.cmdAddField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddField.CausesValidation = true;
			this.cmdAddField.Enabled = true;
			this.cmdAddField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddField.TabStop = true;
			this.cmdAddField.Name = "cmdAddField";
			this.lstAvailableFields.Size = new System.Drawing.Size(388, 632);
			this.lstAvailableFields.Location = new System.Drawing.Point(19, 120);
			this.lstAvailableFields.TabIndex = 18;
			this.lstAvailableFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstAvailableFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstAvailableFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstAvailableFields.CausesValidation = true;
			this.lstAvailableFields.Enabled = true;
			this.lstAvailableFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstAvailableFields.IntegralHeight = true;
			this.lstAvailableFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstAvailableFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstAvailableFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstAvailableFields.Sorted = false;
			this.lstAvailableFields.TabStop = true;
			this.lstAvailableFields.Visible = true;
			this.lstAvailableFields.MultiColumn = false;
			this.lstAvailableFields.Name = "lstAvailableFields";
			this.cmdMoveFieldup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveFieldup.Text = "Move Up";
			this.cmdMoveFieldup.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveFieldup.Size = new System.Drawing.Size(80, 44);
			this.cmdMoveFieldup.Location = new System.Drawing.Point(477, 732);
			this.cmdMoveFieldup.TabIndex = 19;
			this.cmdMoveFieldup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveFieldup.CausesValidation = true;
			this.cmdMoveFieldup.Enabled = true;
			this.cmdMoveFieldup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveFieldup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveFieldup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveFieldup.TabStop = true;
			this.cmdMoveFieldup.Name = "cmdMoveFieldup";
			this.cmdMoveFieldDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveFieldDown.Text = "Move Down";
			this.cmdMoveFieldDown.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveFieldDown.Size = new System.Drawing.Size(90, 44);
			this.cmdMoveFieldDown.Location = new System.Drawing.Point(589, 732);
			this.cmdMoveFieldDown.TabIndex = 20;
			this.cmdMoveFieldDown.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveFieldDown.CausesValidation = true;
			this.cmdMoveFieldDown.Enabled = true;
			this.cmdMoveFieldDown.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveFieldDown.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveFieldDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveFieldDown.TabStop = true;
			this.cmdMoveFieldDown.Name = "cmdMoveFieldDown";
			this.cmdMoveToAbsPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveToAbsPosition.Text = "Move To";
			this.cmdMoveToAbsPosition.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveToAbsPosition.Size = new System.Drawing.Size(100, 44);
			this.cmdMoveToAbsPosition.Location = new System.Drawing.Point(700, 730);
			this.cmdMoveToAbsPosition.TabIndex = 22;
			this.cmdMoveToAbsPosition.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveToAbsPosition.CausesValidation = true;
			this.cmdMoveToAbsPosition.Enabled = true;
			this.cmdMoveToAbsPosition.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveToAbsPosition.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveToAbsPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveToAbsPosition.TabStop = true;
			this.cmdMoveToAbsPosition.Name = "cmdMoveToAbsPosition";
			this._sstabImport_TabPage1.Text = "Validation";
			this.cmdCopyValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopyValidation.Text = "Copy Validation Messages (for shared fields) from another layout";
			this.cmdCopyValidation.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopyValidation.Size = new System.Drawing.Size(689, 25);
			this.cmdCopyValidation.Location = new System.Drawing.Point(14, 35);
			this.cmdCopyValidation.TabIndex = 33;
			this.cmdCopyValidation.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopyValidation.CausesValidation = true;
			this.cmdCopyValidation.Enabled = true;
			this.cmdCopyValidation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopyValidation.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopyValidation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopyValidation.TabStop = true;
			this.cmdCopyValidation.Name = "cmdCopyValidation";
			this.cmdSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSubmit.Text = "Submit";
			this.cmdSubmit.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSubmit.Size = new System.Drawing.Size(159, 24);
			this.cmdSubmit.Location = new System.Drawing.Point(557, 480);
			this.cmdSubmit.Image = (System.Drawing.Image)resources.GetObject("cmdSubmit.Image");
			this.cmdSubmit.TabIndex = 29;
			this.cmdSubmit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmit.CausesValidation = true;
			this.cmdSubmit.Enabled = true;
			this.cmdSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSubmit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmit.TabStop = true;
			this.cmdSubmit.Name = "cmdSubmit";
			this.fraCriteria.Size = new System.Drawing.Size(259, 152);
			this.fraCriteria.Location = new System.Drawing.Point(458, 324);
			this.fraCriteria.TabIndex = 9;
			this.fraCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.fraCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.fraCriteria.Enabled = true;
			this.fraCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraCriteria.Visible = true;
			this.fraCriteria.Padding = new System.Windows.Forms.Padding(0);
			this.fraCriteria.Name = "fraCriteria";
			this.cboLookupValues.Enabled = false;
			this.cboLookupValues.Size = new System.Drawing.Size(170, 27);
			this.cboLookupValues.Location = new System.Drawing.Point(78, 27);
			this.cboLookupValues.TabIndex = 44;
			this.cboLookupValues.Visible = false;
			this.cboLookupValues.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupValues.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupValues.CausesValidation = true;
			this.cboLookupValues.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupValues.IntegralHeight = true;
			this.cboLookupValues.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupValues.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupValues.Sorted = false;
			this.cboLookupValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupValues.TabStop = true;
			this.cboLookupValues.Name = "cboLookupValues";
			this.txtCriteria.AutoSize = false;
			this.txtCriteria.Size = new System.Drawing.Size(142, 25);
			this.txtCriteria.Location = new System.Drawing.Point(78, 18);
			this.txtCriteria.TabIndex = 14;
			this.txtCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtCriteria.AcceptsReturn = true;
			this.txtCriteria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.txtCriteria.CausesValidation = true;
			this.txtCriteria.Enabled = true;
			this.txtCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtCriteria.HideSelection = true;
			this.txtCriteria.ReadOnly = false;
			this.txtCriteria.MaxLength = 0;
			this.txtCriteria.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtCriteria.Multiline = false;
			this.txtCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtCriteria.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtCriteria.TabStop = true;
			this.txtCriteria.Visible = true;
			this.txtCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtCriteria.Name = "txtCriteria";
			this._optCritValue_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCritValue_1.Text = "Value";
			this._optCritValue_1.Size = new System.Drawing.Size(60, 23);
			this._optCritValue_1.Location = new System.Drawing.Point(10, 20);
			this._optCritValue_1.TabIndex = 13;
			this._optCritValue_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._optCritValue_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._optCritValue_1.BackColor = System.Drawing.SystemColors.Control;
			this._optCritValue_1.CausesValidation = true;
			this._optCritValue_1.Enabled = true;
			this._optCritValue_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._optCritValue_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._optCritValue_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._optCritValue_1.Appearance = System.Windows.Forms.Appearance.Normal;
			this._optCritValue_1.TabStop = true;
			this._optCritValue_1.Checked = false;
			this._optCritValue_1.Visible = true;
			this._optCritValue_1.Name = "_optCritValue_1";
			this._OptCritBlank_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCritBlank_2.Text = "Blank";
			this._OptCritBlank_2.Size = new System.Drawing.Size(70, 22);
			this._OptCritBlank_2.Location = new System.Drawing.Point(10, 58);
			this._OptCritBlank_2.TabIndex = 12;
			this._OptCritBlank_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._OptCritBlank_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCritBlank_2.BackColor = System.Drawing.SystemColors.Control;
			this._OptCritBlank_2.CausesValidation = true;
			this._OptCritBlank_2.Enabled = true;
			this._OptCritBlank_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._OptCritBlank_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._OptCritBlank_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._OptCritBlank_2.Appearance = System.Windows.Forms.Appearance.Normal;
			this._OptCritBlank_2.TabStop = true;
			this._OptCritBlank_2.Checked = false;
			this._OptCritBlank_2.Visible = true;
			this._OptCritBlank_2.Name = "_OptCritBlank_2";
			this._OptCritLKUp_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCritLKUp_4.Text = "Lookup List";
			this._OptCritLKUp_4.Size = new System.Drawing.Size(107, 19);
			this._OptCritLKUp_4.Location = new System.Drawing.Point(10, 94);
			this._OptCritLKUp_4.TabIndex = 11;
			this._OptCritLKUp_4.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._OptCritLKUp_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._OptCritLKUp_4.BackColor = System.Drawing.SystemColors.Control;
			this._OptCritLKUp_4.CausesValidation = true;
			this._OptCritLKUp_4.Enabled = true;
			this._OptCritLKUp_4.ForeColor = System.Drawing.SystemColors.ControlText;
			this._OptCritLKUp_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._OptCritLKUp_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._OptCritLKUp_4.Appearance = System.Windows.Forms.Appearance.Normal;
			this._OptCritLKUp_4.TabStop = true;
			this._OptCritLKUp_4.Checked = false;
			this._OptCritLKUp_4.Visible = true;
			this._OptCritLKUp_4.Name = "_OptCritLKUp_4";
			this.cboLookupList.Size = new System.Drawing.Size(240, 27);
			this.cboLookupList.Location = new System.Drawing.Point(10, 117);
			this.cboLookupList.TabIndex = 10;
			this.cboLookupList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboLookupList.BackColor = System.Drawing.SystemColors.Window;
			this.cboLookupList.CausesValidation = true;
			this.cboLookupList.Enabled = true;
			this.cboLookupList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboLookupList.IntegralHeight = true;
			this.cboLookupList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboLookupList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboLookupList.Sorted = false;
			this.cboLookupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboLookupList.TabStop = true;
			this.cboLookupList.Visible = true;
			this.cboLookupList.Name = "cboLookupList";
			this.cboOperation.Size = new System.Drawing.Size(50, 27);
			this.cboOperation.Location = new System.Drawing.Point(398, 379);
			this.cboOperation.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboOperation.TabIndex = 8;
			this.cboOperation.Text = "<>";
			this.cboOperation.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboOperation.BackColor = System.Drawing.SystemColors.Window;
			this.cboOperation.CausesValidation = true;
			this.cboOperation.Enabled = true;
			this.cboOperation.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboOperation.IntegralHeight = true;
			this.cboOperation.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboOperation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboOperation.Sorted = false;
			this.cboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboOperation.TabStop = true;
			this.cboOperation.Visible = true;
			this.cboOperation.Name = "cboOperation";
			this.cmdOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdOr.Text = "Or";
			this.cmdOr.Enabled = false;
			this.cmdOr.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdOr.Size = new System.Drawing.Size(43, 24);
			this.cmdOr.Location = new System.Drawing.Point(508, 479);
			this.cmdOr.Image = (System.Drawing.Image)resources.GetObject("cmdOr.Image");
			this.cmdOr.TabIndex = 5;
			this.cmdOr.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOr.CausesValidation = true;
			this.cmdOr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdOr.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdOr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdOr.TabStop = true;
			this.cmdOr.Name = "cmdOr";
			this.cmdAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAnd.Text = "And";
			this.cmdAnd.Enabled = false;
			this.cmdAnd.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAnd.Size = new System.Drawing.Size(42, 24);
			this.cmdAnd.Location = new System.Drawing.Point(463, 479);
			this.cmdAnd.Image = (System.Drawing.Image)resources.GetObject("cmdAnd.Image");
			this.cmdAnd.TabIndex = 4;
			this.cmdAnd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAnd.CausesValidation = true;
			this.cmdAnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAnd.TabStop = true;
			this.cmdAnd.Name = "cmdAnd";
			this.cmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdHelp.Text = "? Help on Field";
			this.cmdHelp.Size = new System.Drawing.Size(357, 22);
			this.cmdHelp.Location = new System.Drawing.Point(25, 650);
			this.cmdHelp.TabIndex = 3;
			this.cmdHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdHelp.BackColor = System.Drawing.SystemColors.Control;
			this.cmdHelp.CausesValidation = true;
			this.cmdHelp.Enabled = true;
			this.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdHelp.TabStop = true;
			this.cmdHelp.Name = "cmdHelp";
			this.dtHelp.Text = "dtaHelp";
			this.dtHelp.Size = new System.Drawing.Size(310, 29);
			this.dtHelp.Location = new System.Drawing.Point(312, 679);
			this.dtHelp.Visible = false;
			this.dtHelp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.dtHelp.BackColor = System.Drawing.Color.Red;
			this.dtHelp.ForeColor = System.Drawing.Color.Black;
			this.dtHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dtHelp.Text = "dtHelp";
			this.dtHelp.Name = "dtHelp";
			this.lstImportFields.Size = new System.Drawing.Size(358, 296);
			this.lstImportFields.Location = new System.Drawing.Point(23, 333);
			this.lstImportFields.TabIndex = 1;
			this.lstImportFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstImportFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstImportFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstImportFields.CausesValidation = true;
			this.lstImportFields.Enabled = true;
			this.lstImportFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstImportFields.IntegralHeight = true;
			this.lstImportFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstImportFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstImportFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstImportFields.Sorted = false;
			this.lstImportFields.TabStop = true;
			this.lstImportFields.Visible = true;
			this.lstImportFields.MultiColumn = false;
			this.lstImportFields.Name = "lstImportFields";
			rdcReports.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcReports.OcxState");
			this.rdcReports.Size = new System.Drawing.Size(278, 28);
			this.rdcReports.Location = new System.Drawing.Point(29, 685);
			this.rdcReports.Visible = false;
			this.rdcReports.Name = "rdcReports";
			this.sstabValidation.Size = new System.Drawing.Size(895, 243);
			this.sstabValidation.Location = new System.Drawing.Point(17, 64);
			this.sstabValidation.TabIndex = 21;
			this.sstabValidation.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabValidation.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
			this.sstabValidation.ForeColor = System.Drawing.Color.Blue;
			this.sstabValidation.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabValidation.Name = "sstabValidation";
			this._sstabValidation_TabPage0.Text = "Errors";
			this.Label2.Text = "Selected Criteria";
			this.Label2.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.Color.Blue;
			this.Label2.Size = new System.Drawing.Size(137, 18);
			this.Label2.Location = new System.Drawing.Point(20, 160);
			this.Label2.TabIndex = 28;
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
			this.cmdAddError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddError.Text = "Add Error Valid.";
			this.cmdAddError.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddError.Size = new System.Drawing.Size(149, 23);
			this.cmdAddError.Location = new System.Drawing.Point(19, 35);
			this.cmdAddError.Image = (System.Drawing.Image)resources.GetObject("cmdAddError.Image");
			this.cmdAddError.TabIndex = 23;
			this.cmdAddError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddError.CausesValidation = true;
			this.cmdAddError.Enabled = true;
			this.cmdAddError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddError.TabStop = true;
			this.cmdAddError.Name = "cmdAddError";
			this.cmdRemoveError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveError.Text = "Remove Error Valid.";
			this.cmdRemoveError.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveError.Size = new System.Drawing.Size(168, 23);
			this.cmdRemoveError.Location = new System.Drawing.Point(314, 35);
			this.cmdRemoveError.TabIndex = 24;
			this.cmdRemoveError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveError.CausesValidation = true;
			this.cmdRemoveError.Enabled = true;
			this.cmdRemoveError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveError.TabStop = true;
			this.cmdRemoveError.Name = "cmdRemoveError";
			this.lstCriteria.Size = new System.Drawing.Size(850, 56);
			this.lstCriteria.Location = new System.Drawing.Point(22, 179);
			this.lstCriteria.TabIndex = 27;
			this.lstCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstCriteria.CausesValidation = true;
			this.lstCriteria.Enabled = true;
			this.lstCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstCriteria.IntegralHeight = true;
			this.lstCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstCriteria.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstCriteria.Sorted = false;
			this.lstCriteria.TabStop = true;
			this.lstCriteria.Visible = true;
			this.lstCriteria.MultiColumn = false;
			this.lstCriteria.Name = "lstCriteria";
			this.cmdRemoveCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveCriteria.Text = "Remove Criteria";
			this.cmdRemoveCriteria.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveCriteria.Size = new System.Drawing.Size(168, 24);
			this.cmdRemoveCriteria.Location = new System.Drawing.Point(515, 153);
			this.cmdRemoveCriteria.TabIndex = 30;
			this.cmdRemoveCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveCriteria.CausesValidation = true;
			this.cmdRemoveCriteria.Enabled = true;
			this.cmdRemoveCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveCriteria.TabStop = true;
			this.cmdRemoveCriteria.Name = "cmdRemoveCriteria";
			this.cmdEditError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditError.Text = "Edit Error Valid.";
			this.cmdEditError.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEditError.Size = new System.Drawing.Size(140, 23);
			this.cmdEditError.Location = new System.Drawing.Point(172, 35);
			this.cmdEditError.Image = (System.Drawing.Image)resources.GetObject("cmdEditError.Image");
			this.cmdEditError.TabIndex = 36;
			this.cmdEditError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditError.CausesValidation = true;
			this.cmdEditError.Enabled = true;
			this.cmdEditError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditError.TabStop = true;
			this.cmdEditError.Name = "cmdEditError";
			this.txtAction.AutoSize = false;
			this.txtAction.Size = new System.Drawing.Size(100, 24);
			this.txtAction.Location = new System.Drawing.Point(395, 153);
			this.txtAction.TabIndex = 37;
			this.txtAction.Text = "Action Type";
			this.txtAction.Visible = false;
			this.txtAction.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtAction.AcceptsReturn = true;
			this.txtAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtAction.BackColor = System.Drawing.SystemColors.Window;
			this.txtAction.CausesValidation = true;
			this.txtAction.Enabled = true;
			this.txtAction.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAction.HideSelection = true;
			this.txtAction.ReadOnly = false;
			this.txtAction.MaxLength = 0;
			this.txtAction.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtAction.Multiline = false;
			this.txtAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtAction.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtAction.TabStop = true;
			this.txtAction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtAction.Name = "txtAction";
			this.cmdChangetoWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangetoWarning.Text = "Change to Warning";
			this.cmdChangetoWarning.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangetoWarning.Size = new System.Drawing.Size(168, 23);
			this.cmdChangetoWarning.Location = new System.Drawing.Point(485, 35);
			this.cmdChangetoWarning.TabIndex = 45;
			this.cmdChangetoWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangetoWarning.CausesValidation = true;
			this.cmdChangetoWarning.Enabled = true;
			this.cmdChangetoWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangetoWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangetoWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangetoWarning.TabStop = true;
			this.cmdChangetoWarning.Name = "cmdChangetoWarning";
			this._sstabValidation_TabPage1.Text = "Warnings";
			this.cmdChangeToError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeToError.Text = "Change to Error";
			this.cmdChangeToError.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeToError.Size = new System.Drawing.Size(168, 23);
			this.cmdChangeToError.Location = new System.Drawing.Point(494, 35);
			this.cmdChangeToError.TabIndex = 46;
			this.cmdChangeToError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeToError.CausesValidation = true;
			this.cmdChangeToError.Enabled = true;
			this.cmdChangeToError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeToError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeToError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeToError.TabStop = true;
			this.cmdChangeToError.Name = "cmdChangeToError";
			this.cmdEditWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdEditWarning.Text = "Edit Error Valid.";
			this.cmdEditWarning.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdEditWarning.Size = new System.Drawing.Size(135, 23);
			this.cmdEditWarning.Location = new System.Drawing.Point(189, 35);
			this.cmdEditWarning.Image = (System.Drawing.Image)resources.GetObject("cmdEditWarning.Image");
			this.cmdEditWarning.TabIndex = 38;
			this.cmdEditWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEditWarning.CausesValidation = true;
			this.cmdEditWarning.Enabled = true;
			this.cmdEditWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEditWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEditWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEditWarning.TabStop = true;
			this.cmdEditWarning.Name = "cmdEditWarning";
			this.cmdRemoveWCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveWCriteria.Text = "Remove Criteria";
			this.cmdRemoveWCriteria.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveWCriteria.Size = new System.Drawing.Size(160, 24);
			this.cmdRemoveWCriteria.Location = new System.Drawing.Point(522, 154);
			this.cmdRemoveWCriteria.TabIndex = 35;
			this.cmdRemoveWCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveWCriteria.CausesValidation = true;
			this.cmdRemoveWCriteria.Enabled = true;
			this.cmdRemoveWCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveWCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveWCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveWCriteria.TabStop = true;
			this.cmdRemoveWCriteria.Name = "cmdRemoveWCriteria";
			this.lstWCriteria.Size = new System.Drawing.Size(862, 56);
			this.lstWCriteria.Location = new System.Drawing.Point(23, 180);
			this.lstWCriteria.TabIndex = 34;
			this.lstWCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstWCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstWCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstWCriteria.CausesValidation = true;
			this.lstWCriteria.Enabled = true;
			this.lstWCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstWCriteria.IntegralHeight = true;
			this.lstWCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstWCriteria.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstWCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstWCriteria.Sorted = false;
			this.lstWCriteria.TabStop = true;
			this.lstWCriteria.Visible = true;
			this.lstWCriteria.MultiColumn = false;
			this.lstWCriteria.Name = "lstWCriteria";
			this.cmdAddWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddWarning.Text = "Add Warning";
			this.cmdAddWarning.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddWarning.Size = new System.Drawing.Size(163, 23);
			this.cmdAddWarning.Location = new System.Drawing.Point(22, 35);
			this.cmdAddWarning.Image = (System.Drawing.Image)resources.GetObject("cmdAddWarning.Image");
			this.cmdAddWarning.TabIndex = 32;
			this.cmdAddWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddWarning.CausesValidation = true;
			this.cmdAddWarning.Enabled = true;
			this.cmdAddWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddWarning.TabStop = true;
			this.cmdAddWarning.Name = "cmdAddWarning";
			this.cmdRemoveWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveWarning.Text = "Remove Warnings";
			this.cmdRemoveWarning.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveWarning.Size = new System.Drawing.Size(160, 23);
			this.cmdRemoveWarning.Location = new System.Drawing.Point(329, 35);
			this.cmdRemoveWarning.TabIndex = 31;
			this.cmdRemoveWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveWarning.CausesValidation = true;
			this.cmdRemoveWarning.Enabled = true;
			this.cmdRemoveWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveWarning.TabStop = true;
			this.cmdRemoveWarning.Name = "cmdRemoveWarning";
			this.Label4.Text = "Selected Criteria";
			this.Label4.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.ForeColor = System.Drawing.Color.Blue;
			this.Label4.Size = new System.Drawing.Size(137, 18);
			this.Label4.Location = new System.Drawing.Point(22, 160);
			this.Label4.TabIndex = 39;
			this.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Enabled = true;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.UseMnemonic = true;
			this.Label4.Visible = true;
			this.Label4.AutoSize = false;
			this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label4.Name = "Label4";
			this.Label10.Text = "Select an Operator";
			this.Label10.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label10.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label10.Size = new System.Drawing.Size(72, 34);
			this.Label10.Location = new System.Drawing.Point(385, 334);
			this.Label10.TabIndex = 7;
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.Enabled = true;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.UseMnemonic = true;
			this.Label10.Visible = true;
			this.Label10.AutoSize = false;
			this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label10.Name = "Label10";
			this.Label11.Text = "Define Criteria";
			this.Label11.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label11.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label11.Size = new System.Drawing.Size(123, 15);
			this.Label11.Location = new System.Drawing.Point(465, 310);
			this.Label11.TabIndex = 6;
			this.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label11.BackColor = System.Drawing.Color.Transparent;
			this.Label11.Enabled = true;
			this.Label11.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label11.UseMnemonic = true;
			this.Label11.Visible = true;
			this.Label11.AutoSize = false;
			this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label11.Name = "Label11";
			this.Label6.Text = "Select a Field for Criteria";
			this.Label6.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.ForeColor = System.Drawing.Color.FromArgb(128, 0, 0);
			this.Label6.Size = new System.Drawing.Size(225, 22);
			this.Label6.Location = new System.Drawing.Point(25, 312);
			this.Label6.TabIndex = 2;
			this.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label6.BackColor = System.Drawing.SystemColors.Control;
			this.Label6.Enabled = true;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.UseMnemonic = true;
			this.Label6.Visible = true;
			this.Label6.AutoSize = false;
			this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label6.Name = "Label6";
			rdcImportValWarning.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcImportValWarning.OcxState");
			this.rdcImportValWarning.Size = new System.Drawing.Size(303, 28);
			this.rdcImportValWarning.Location = new System.Drawing.Point(320, 500);
			this.rdcImportValWarning.Visible = false;
			this.rdcImportValWarning.Name = "rdcImportValWarning";
			this.lblThisSetup.Text = "Label9";
			this.lblThisSetup.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblThisSetup.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.lblThisSetup.Size = new System.Drawing.Size(724, 28);
			this.lblThisSetup.Location = new System.Drawing.Point(18, 2);
			this.lblThisSetup.TabIndex = 43;
			this.lblThisSetup.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblThisSetup.BackColor = System.Drawing.SystemColors.Control;
			this.lblThisSetup.Enabled = true;
			this.lblThisSetup.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblThisSetup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblThisSetup.UseMnemonic = true;
			this.lblThisSetup.Visible = true;
			this.lblThisSetup.AutoSize = false;
			this.lblThisSetup.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblThisSetup.Name = "lblThisSetup";
			this.OptCritBlank.SetIndex(_OptCritBlank_2, Convert.ToInt16(2));
			this.OptCritLKUp.SetIndex(_OptCritLKUp_4, Convert.ToInt16(4));
			this.optCritValue.SetIndex(_optCritValue_1, Convert.ToInt16(1));
			((System.ComponentModel.ISupportInitialize)this.optCritValue).EndInit();
			((System.ComponentModel.ISupportInitialize)this.OptCritLKUp).EndInit();
			((System.ComponentModel.ISupportInitialize)this.OptCritBlank).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcImportValWarning).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcReports).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcImportValError).EndInit();
			this.Controls.Add(rdcImportValError);
			this.Controls.Add(sstabImport);
			this.Controls.Add(rdcImportValWarning);
			this.Controls.Add(lblThisSetup);
			this.sstabImport.Controls.Add(_sstabImport_TabPage0);
			this.sstabImport.Controls.Add(_sstabImport_TabPage1);
			this._sstabImport_TabPage0.Controls.Add(Label1);
			this._sstabImport_TabPage0.Controls.Add(Label5);
			this._sstabImport_TabPage0.Controls.Add(Label3);
			this._sstabImport_TabPage0.Controls.Add(Label7);
			this._sstabImport_TabPage0.Controls.Add(Label8);
			this._sstabImport_TabPage0.Controls.Add(lstSelectedFields);
			this._sstabImport_TabPage0.Controls.Add(cmdRemoveField);
			this._sstabImport_TabPage0.Controls.Add(cmdAddField);
			this._sstabImport_TabPage0.Controls.Add(lstAvailableFields);
			this._sstabImport_TabPage0.Controls.Add(cmdMoveFieldup);
			this._sstabImport_TabPage0.Controls.Add(cmdMoveFieldDown);
			this._sstabImport_TabPage0.Controls.Add(cmdMoveToAbsPosition);
			this._sstabImport_TabPage1.Controls.Add(cmdCopyValidation);
			this._sstabImport_TabPage1.Controls.Add(cmdSubmit);
			this._sstabImport_TabPage1.Controls.Add(fraCriteria);
			this._sstabImport_TabPage1.Controls.Add(cboOperation);
			this._sstabImport_TabPage1.Controls.Add(cmdOr);
			this._sstabImport_TabPage1.Controls.Add(cmdAnd);
			this._sstabImport_TabPage1.Controls.Add(cmdHelp);
			this._sstabImport_TabPage1.Controls.Add(dtHelp);
			this._sstabImport_TabPage1.Controls.Add(lstImportFields);
			this._sstabImport_TabPage1.Controls.Add(rdcReports);
			this._sstabImport_TabPage1.Controls.Add(sstabValidation);
			this._sstabImport_TabPage1.Controls.Add(Label10);
			this._sstabImport_TabPage1.Controls.Add(Label11);
			this._sstabImport_TabPage1.Controls.Add(Label6);
			this.fraCriteria.Controls.Add(cboLookupValues);
			this.fraCriteria.Controls.Add(txtCriteria);
			this.fraCriteria.Controls.Add(_optCritValue_1);
			this.fraCriteria.Controls.Add(_OptCritBlank_2);
			this.fraCriteria.Controls.Add(_OptCritLKUp_4);
			this.fraCriteria.Controls.Add(cboLookupList);
			this.sstabValidation.Controls.Add(_sstabValidation_TabPage0);
			this.sstabValidation.Controls.Add(_sstabValidation_TabPage1);
			this._sstabValidation_TabPage0.Controls.Add(Label2);
			this._sstabValidation_TabPage0.Controls.Add(cmdAddError);
			this._sstabValidation_TabPage0.Controls.Add(cmdRemoveError);
			this._sstabValidation_TabPage0.Controls.Add(lstCriteria);
			this._sstabValidation_TabPage0.Controls.Add(cmdRemoveCriteria);
			this._sstabValidation_TabPage0.Controls.Add(cmdEditError);
			this._sstabValidation_TabPage0.Controls.Add(txtAction);
			this._sstabValidation_TabPage0.Controls.Add(cmdChangetoWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdChangeToError);
			this._sstabValidation_TabPage1.Controls.Add(cmdEditWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdRemoveWCriteria);
			this._sstabValidation_TabPage1.Controls.Add(lstWCriteria);
			this._sstabValidation_TabPage1.Controls.Add(cmdAddWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdRemoveWarning);
			this._sstabValidation_TabPage1.Controls.Add(Label4);
			this.sstabImport.ResumeLayout(false);
			this._sstabImport_TabPage0.ResumeLayout(false);
			this._sstabImport_TabPage1.ResumeLayout(false);
			this.fraCriteria.ResumeLayout(false);
			this.sstabValidation.ResumeLayout(false);
			this._sstabValidation_TabPage0.ResumeLayout(false);
			this._sstabValidation_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
