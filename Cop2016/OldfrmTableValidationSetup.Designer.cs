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
	partial class OldfrmTableValidationSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmTableValidationSetup() : base()
		{
			Load += frmTableValidationSetup_Load;
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
		private System.Windows.Forms.Button withEventsField_cmdExportValidation;
		public System.Windows.Forms.Button cmdExportValidation {
			get { return withEventsField_cmdExportValidation; }
			set {
				if (withEventsField_cmdExportValidation != null) {
					withEventsField_cmdExportValidation.Click -= cmdExportValidation_Click;
				}
				withEventsField_cmdExportValidation = value;
				if (withEventsField_cmdExportValidation != null) {
					withEventsField_cmdExportValidation.Click += cmdExportValidation_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboTableList;
		public System.Windows.Forms.ComboBox cboTableList {
			get { return withEventsField_cboTableList; }
			set {
				if (withEventsField_cboTableList != null) {
					withEventsField_cboTableList.SelectedIndexChanged -= cboTableList_SelectedIndexChanged;
				}
				withEventsField_cboTableList = value;
				if (withEventsField_cboTableList != null) {
					withEventsField_cboTableList.SelectedIndexChanged += cboTableList_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcTableList;
		public AxMSRDC.AxMSRDC rdcValidationWarnings;
		public AxMSRDC.AxMSRDC rdcValidationErrorCriteria;
		public AxMSRDC.AxMSRDC rdcValidationWarningCriteria;
		public AxMSRDC.AxMSRDC rdcValidationErrors;
		private System.Windows.Forms.Button withEventsField_cmdErrorCopySet;
		public System.Windows.Forms.Button cmdErrorCopySet {
			get { return withEventsField_cmdErrorCopySet; }
			set {
				if (withEventsField_cmdErrorCopySet != null) {
					withEventsField_cmdErrorCopySet.Click -= cmdErrorCopySet_Click;
				}
				withEventsField_cmdErrorCopySet = value;
				if (withEventsField_cmdErrorCopySet != null) {
					withEventsField_cmdErrorCopySet.Click += cmdErrorCopySet_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRightLookup;
		public System.Windows.Forms.Button cmdRightLookup {
			get { return withEventsField_cmdRightLookup; }
			set {
				if (withEventsField_cmdRightLookup != null) {
					withEventsField_cmdRightLookup.Click -= cmdRightLookup_Click;
				}
				withEventsField_cmdRightLookup = value;
				if (withEventsField_cmdRightLookup != null) {
					withEventsField_cmdRightLookup.Click += cmdRightLookup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDupWarn;
		public System.Windows.Forms.Button cmdDupWarn {
			get { return withEventsField_cmdDupWarn; }
			set {
				if (withEventsField_cmdDupWarn != null) {
					withEventsField_cmdDupWarn.Click -= cmdDupWarn_Click;
				}
				withEventsField_cmdDupWarn = value;
				if (withEventsField_cmdDupWarn != null) {
					withEventsField_cmdDupWarn.Click += cmdDupWarn_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDupError;
		public System.Windows.Forms.Button cmdDupError {
			get { return withEventsField_cmdDupError; }
			set {
				if (withEventsField_cmdDupError != null) {
					withEventsField_cmdDupError.Click -= cmdDupError_Click;
				}
				withEventsField_cmdDupError = value;
				if (withEventsField_cmdDupError != null) {
					withEventsField_cmdDupError.Click += cmdDupError_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidErrorEditLeft;
		public System.Windows.Forms.Button cmdValidErrorEditLeft {
			get { return withEventsField_cmdValidErrorEditLeft; }
			set {
				if (withEventsField_cmdValidErrorEditLeft != null) {
					withEventsField_cmdValidErrorEditLeft.Click -= cmdValidErrorEditLeft_Click;
				}
				withEventsField_cmdValidErrorEditLeft = value;
				if (withEventsField_cmdValidErrorEditLeft != null) {
					withEventsField_cmdValidErrorEditLeft.Click += cmdValidErrorEditLeft_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidErrorChangemainjoinop;
		public System.Windows.Forms.Button cmdValidErrorChangemainjoinop {
			get { return withEventsField_cmdValidErrorChangemainjoinop; }
			set {
				if (withEventsField_cmdValidErrorChangemainjoinop != null) {
					withEventsField_cmdValidErrorChangemainjoinop.Click -= cmdValidErrorChangemainjoinop_Click;
				}
				withEventsField_cmdValidErrorChangemainjoinop = value;
				if (withEventsField_cmdValidErrorChangemainjoinop != null) {
					withEventsField_cmdValidErrorChangemainjoinop.Click += cmdValidErrorChangemainjoinop_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeErrorStatus;
		public System.Windows.Forms.Button cmdChangeErrorStatus {
			get { return withEventsField_cmdChangeErrorStatus; }
			set {
				if (withEventsField_cmdChangeErrorStatus != null) {
					withEventsField_cmdChangeErrorStatus.Click -= cmdChangeErrorStatus_Click;
				}
				withEventsField_cmdChangeErrorStatus = value;
				if (withEventsField_cmdChangeErrorStatus != null) {
					withEventsField_cmdChangeErrorStatus.Click += cmdChangeErrorStatus_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstErrorCriteriaSet;
		private System.Windows.Forms.Button withEventsField_cmdDeleteErrorAction;
		public System.Windows.Forms.Button cmdDeleteErrorAction {
			get { return withEventsField_cmdDeleteErrorAction; }
			set {
				if (withEventsField_cmdDeleteErrorAction != null) {
					withEventsField_cmdDeleteErrorAction.Click -= cmdDeleteErrorAction_Click;
				}
				withEventsField_cmdDeleteErrorAction = value;
				if (withEventsField_cmdDeleteErrorAction != null) {
					withEventsField_cmdDeleteErrorAction.Click += cmdDeleteErrorAction_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddErroraction;
		public System.Windows.Forms.Button cmdAddErroraction {
			get { return withEventsField_cmdAddErroraction; }
			set {
				if (withEventsField_cmdAddErroraction != null) {
					withEventsField_cmdAddErroraction.Click -= cmdAddErroraction_Click;
				}
				withEventsField_cmdAddErroraction = value;
				if (withEventsField_cmdAddErroraction != null) {
					withEventsField_cmdAddErroraction.Click += cmdAddErroraction_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeToWarning;
		public System.Windows.Forms.Button cmdChangeToWarning {
			get { return withEventsField_cmdChangeToWarning; }
			set {
				if (withEventsField_cmdChangeToWarning != null) {
					withEventsField_cmdChangeToWarning.Click -= cmdChangeToWarning_Click;
				}
				withEventsField_cmdChangeToWarning = value;
				if (withEventsField_cmdChangeToWarning != null) {
					withEventsField_cmdChangeToWarning.Click += cmdChangeToWarning_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidErrorAddCritOr;
		public System.Windows.Forms.Button cmdValidErrorAddCritOr {
			get { return withEventsField_cmdValidErrorAddCritOr; }
			set {
				if (withEventsField_cmdValidErrorAddCritOr != null) {
					withEventsField_cmdValidErrorAddCritOr.Click -= cmdValidErrorAddCritOr_Click;
				}
				withEventsField_cmdValidErrorAddCritOr = value;
				if (withEventsField_cmdValidErrorAddCritOr != null) {
					withEventsField_cmdValidErrorAddCritOr.Click += cmdValidErrorAddCritOr_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidErrorAddCritAnd;
		public System.Windows.Forms.Button cmdValidErrorAddCritAnd {
			get { return withEventsField_cmdValidErrorAddCritAnd; }
			set {
				if (withEventsField_cmdValidErrorAddCritAnd != null) {
					withEventsField_cmdValidErrorAddCritAnd.Click -= cmdValidErrorAddCritAnd_Click;
				}
				withEventsField_cmdValidErrorAddCritAnd = value;
				if (withEventsField_cmdValidErrorAddCritAnd != null) {
					withEventsField_cmdValidErrorAddCritAnd.Click += cmdValidErrorAddCritAnd_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidErrorDeleteCrit;
		public System.Windows.Forms.Button cmdValidErrorDeleteCrit {
			get { return withEventsField_cmdValidErrorDeleteCrit; }
			set {
				if (withEventsField_cmdValidErrorDeleteCrit != null) {
					withEventsField_cmdValidErrorDeleteCrit.Click -= cmdValidErrorDeleteCrit_Click;
				}
				withEventsField_cmdValidErrorDeleteCrit = value;
				if (withEventsField_cmdValidErrorDeleteCrit != null) {
					withEventsField_cmdValidErrorDeleteCrit.Click += cmdValidErrorDeleteCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidErrorAddCrit;
		public System.Windows.Forms.Button cmdValidErrorAddCrit {
			get { return withEventsField_cmdValidErrorAddCrit; }
			set {
				if (withEventsField_cmdValidErrorAddCrit != null) {
					withEventsField_cmdValidErrorAddCrit.Click -= cmdValidErrorAddCrit_Click;
				}
				withEventsField_cmdValidErrorAddCrit = value;
				if (withEventsField_cmdValidErrorAddCrit != null) {
					withEventsField_cmdValidErrorAddCrit.Click += cmdValidErrorAddCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdUpdateError;
		public System.Windows.Forms.Button cmdUpdateError {
			get { return withEventsField_cmdUpdateError; }
			set {
				if (withEventsField_cmdUpdateError != null) {
					withEventsField_cmdUpdateError.Click -= cmdUpdateError_Click;
				}
				withEventsField_cmdUpdateError = value;
				if (withEventsField_cmdUpdateError != null) {
					withEventsField_cmdUpdateError.Click += cmdUpdateError_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelError;
		public System.Windows.Forms.Button cmdDelError {
			get { return withEventsField_cmdDelError; }
			set {
				if (withEventsField_cmdDelError != null) {
					withEventsField_cmdDelError.Click -= cmdDelError_Click;
				}
				withEventsField_cmdDelError = value;
				if (withEventsField_cmdDelError != null) {
					withEventsField_cmdDelError.Click += cmdDelError_Click;
				}
			}
		}
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
		public AxMSDBGrid.AxDBGrid dbgSubmitErrors;
		public AxMSDBGrid.AxDBGrid dbgValidationErrorAction;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.TabPage _sstabValidation_TabPage0;
		public System.Windows.Forms.Label Label2;
		public AxMSDBGrid.AxDBGrid dbgSubmitWarnings;
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
		private System.Windows.Forms.Button withEventsField_cmdDeleteWarning;
		public System.Windows.Forms.Button cmdDeleteWarning {
			get { return withEventsField_cmdDeleteWarning; }
			set {
				if (withEventsField_cmdDeleteWarning != null) {
					withEventsField_cmdDeleteWarning.Click -= cmdDeleteWarning_Click;
				}
				withEventsField_cmdDeleteWarning = value;
				if (withEventsField_cmdDeleteWarning != null) {
					withEventsField_cmdDeleteWarning.Click += cmdDeleteWarning_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdUpdateWarning;
		public System.Windows.Forms.Button cmdUpdateWarning {
			get { return withEventsField_cmdUpdateWarning; }
			set {
				if (withEventsField_cmdUpdateWarning != null) {
					withEventsField_cmdUpdateWarning.Click -= cmdUpdateWarning_Click;
				}
				withEventsField_cmdUpdateWarning = value;
				if (withEventsField_cmdUpdateWarning != null) {
					withEventsField_cmdUpdateWarning.Click += cmdUpdateWarning_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidWarningAddCrit;
		public System.Windows.Forms.Button cmdValidWarningAddCrit {
			get { return withEventsField_cmdValidWarningAddCrit; }
			set {
				if (withEventsField_cmdValidWarningAddCrit != null) {
					withEventsField_cmdValidWarningAddCrit.Click -= cmdValidWarningAddCrit_Click;
				}
				withEventsField_cmdValidWarningAddCrit = value;
				if (withEventsField_cmdValidWarningAddCrit != null) {
					withEventsField_cmdValidWarningAddCrit.Click += cmdValidWarningAddCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidWarningAddCritAnd;
		public System.Windows.Forms.Button cmdValidWarningAddCritAnd {
			get { return withEventsField_cmdValidWarningAddCritAnd; }
			set {
				if (withEventsField_cmdValidWarningAddCritAnd != null) {
					withEventsField_cmdValidWarningAddCritAnd.Click -= cmdValidWarningAddCritAnd_Click;
				}
				withEventsField_cmdValidWarningAddCritAnd = value;
				if (withEventsField_cmdValidWarningAddCritAnd != null) {
					withEventsField_cmdValidWarningAddCritAnd.Click += cmdValidWarningAddCritAnd_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidWarningAddCritOr;
		public System.Windows.Forms.Button cmdValidWarningAddCritOr {
			get { return withEventsField_cmdValidWarningAddCritOr; }
			set {
				if (withEventsField_cmdValidWarningAddCritOr != null) {
					withEventsField_cmdValidWarningAddCritOr.Click -= cmdValidWarningAddCritOr_Click;
				}
				withEventsField_cmdValidWarningAddCritOr = value;
				if (withEventsField_cmdValidWarningAddCritOr != null) {
					withEventsField_cmdValidWarningAddCritOr.Click += cmdValidWarningAddCritOr_Click;
				}
			}
		}
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
		public AxMSDBGrid.AxDBGrid dbgValidationWarningAction;
		private System.Windows.Forms.Button withEventsField_cmdAddWarningAction;
		public System.Windows.Forms.Button cmdAddWarningAction {
			get { return withEventsField_cmdAddWarningAction; }
			set {
				if (withEventsField_cmdAddWarningAction != null) {
					withEventsField_cmdAddWarningAction.Click -= cmdAddWarningAction_Click;
				}
				withEventsField_cmdAddWarningAction = value;
				if (withEventsField_cmdAddWarningAction != null) {
					withEventsField_cmdAddWarningAction.Click += cmdAddWarningAction_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDeleteWarningAction;
		public System.Windows.Forms.Button cmdDeleteWarningAction {
			get { return withEventsField_cmdDeleteWarningAction; }
			set {
				if (withEventsField_cmdDeleteWarningAction != null) {
					withEventsField_cmdDeleteWarningAction.Click -= cmdDeleteWarningAction_Click;
				}
				withEventsField_cmdDeleteWarningAction = value;
				if (withEventsField_cmdDeleteWarningAction != null) {
					withEventsField_cmdDeleteWarningAction.Click += cmdDeleteWarningAction_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstWarningCriteriaSet;
		private System.Windows.Forms.Button withEventsField_cmdChangeWarningStatus;
		public System.Windows.Forms.Button cmdChangeWarningStatus {
			get { return withEventsField_cmdChangeWarningStatus; }
			set {
				if (withEventsField_cmdChangeWarningStatus != null) {
					withEventsField_cmdChangeWarningStatus.Click -= cmdChangeWarningStatus_Click;
				}
				withEventsField_cmdChangeWarningStatus = value;
				if (withEventsField_cmdChangeWarningStatus != null) {
					withEventsField_cmdChangeWarningStatus.Click += cmdChangeWarningStatus_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidWarningChangemainjoinop;
		public System.Windows.Forms.Button cmdValidWarningChangemainjoinop {
			get { return withEventsField_cmdValidWarningChangemainjoinop; }
			set {
				if (withEventsField_cmdValidWarningChangemainjoinop != null) {
					withEventsField_cmdValidWarningChangemainjoinop.Click -= cmdValidWarningChangemainjoinop_Click;
				}
				withEventsField_cmdValidWarningChangemainjoinop = value;
				if (withEventsField_cmdValidWarningChangemainjoinop != null) {
					withEventsField_cmdValidWarningChangemainjoinop.Click += cmdValidWarningChangemainjoinop_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidWarningDeleteCrit;
		public System.Windows.Forms.Button cmdValidWarningDeleteCrit {
			get { return withEventsField_cmdValidWarningDeleteCrit; }
			set {
				if (withEventsField_cmdValidWarningDeleteCrit != null) {
					withEventsField_cmdValidWarningDeleteCrit.Click -= cmdValidWarningDeleteCrit_Click;
				}
				withEventsField_cmdValidWarningDeleteCrit = value;
				if (withEventsField_cmdValidWarningDeleteCrit != null) {
					withEventsField_cmdValidWarningDeleteCrit.Click += cmdValidWarningDeleteCrit_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdWarningDupWarning;
		public System.Windows.Forms.Button cmdWarningDupWarning {
			get { return withEventsField_cmdWarningDupWarning; }
			set {
				if (withEventsField_cmdWarningDupWarning != null) {
					withEventsField_cmdWarningDupWarning.Click -= cmdWarningDupWarning_Click;
				}
				withEventsField_cmdWarningDupWarning = value;
				if (withEventsField_cmdWarningDupWarning != null) {
					withEventsField_cmdWarningDupWarning.Click += cmdWarningDupWarning_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdWarningDupError;
		public System.Windows.Forms.Button cmdWarningDupError {
			get { return withEventsField_cmdWarningDupError; }
			set {
				if (withEventsField_cmdWarningDupError != null) {
					withEventsField_cmdWarningDupError.Click -= cmdWarningDupError_Click;
				}
				withEventsField_cmdWarningDupError = value;
				if (withEventsField_cmdWarningDupError != null) {
					withEventsField_cmdWarningDupError.Click += cmdWarningDupError_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdValidWarningEditLeft;
		public System.Windows.Forms.Button cmdValidWarningEditLeft {
			get { return withEventsField_cmdValidWarningEditLeft; }
			set {
				if (withEventsField_cmdValidWarningEditLeft != null) {
					withEventsField_cmdValidWarningEditLeft.Click -= cmdValidWarningEditLeft_Click;
				}
				withEventsField_cmdValidWarningEditLeft = value;
				if (withEventsField_cmdValidWarningEditLeft != null) {
					withEventsField_cmdValidWarningEditLeft.Click += cmdValidWarningEditLeft_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_CmdWarningRight;
		public System.Windows.Forms.Button CmdWarningRight {
			get { return withEventsField_CmdWarningRight; }
			set {
				if (withEventsField_CmdWarningRight != null) {
					withEventsField_CmdWarningRight.Click -= CmdWarningRight_Click;
				}
				withEventsField_CmdWarningRight = value;
				if (withEventsField_CmdWarningRight != null) {
					withEventsField_CmdWarningRight.Click += CmdWarningRight_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdWarnCopySet;
		public System.Windows.Forms.Button cmdWarnCopySet {
			get { return withEventsField_cmdWarnCopySet; }
			set {
				if (withEventsField_cmdWarnCopySet != null) {
					withEventsField_cmdWarnCopySet.Click -= cmdWarnCopySet_Click;
				}
				withEventsField_cmdWarnCopySet = value;
				if (withEventsField_cmdWarnCopySet != null) {
					withEventsField_cmdWarnCopySet.Click += cmdWarnCopySet_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _sstabValidation_TabPage1;
		public System.Windows.Forms.TabControl sstabValidation;
		public AxMSRDC.AxMSRDC rdcValidationErrorAction;
		public AxMSRDC.AxMSRDC rdcValidationWarningAction;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmTableValidationSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.Command1 = new System.Windows.Forms.Button();
			this.cmdExportValidation = new System.Windows.Forms.Button();
			this.cboTableList = new System.Windows.Forms.ComboBox();
			this.rdcTableList = new AxMSRDC.AxMSRDC();
			this.rdcValidationWarnings = new AxMSRDC.AxMSRDC();
			this.rdcValidationErrorCriteria = new AxMSRDC.AxMSRDC();
			this.rdcValidationWarningCriteria = new AxMSRDC.AxMSRDC();
			this.rdcValidationErrors = new AxMSRDC.AxMSRDC();
			this.sstabValidation = new System.Windows.Forms.TabControl();
			this._sstabValidation_TabPage0 = new System.Windows.Forms.TabPage();
			this.cmdErrorCopySet = new System.Windows.Forms.Button();
			this.cmdRightLookup = new System.Windows.Forms.Button();
			this.cmdDupWarn = new System.Windows.Forms.Button();
			this.cmdDupError = new System.Windows.Forms.Button();
			this.cmdValidErrorEditLeft = new System.Windows.Forms.Button();
			this.cmdValidErrorChangemainjoinop = new System.Windows.Forms.Button();
			this.cmdChangeErrorStatus = new System.Windows.Forms.Button();
			this.lstErrorCriteriaSet = new System.Windows.Forms.ListBox();
			this.cmdDeleteErrorAction = new System.Windows.Forms.Button();
			this.cmdAddErroraction = new System.Windows.Forms.Button();
			this.cmdChangeToWarning = new System.Windows.Forms.Button();
			this.cmdValidErrorAddCritOr = new System.Windows.Forms.Button();
			this.cmdValidErrorAddCritAnd = new System.Windows.Forms.Button();
			this.cmdValidErrorDeleteCrit = new System.Windows.Forms.Button();
			this.cmdValidErrorAddCrit = new System.Windows.Forms.Button();
			this.cmdUpdateError = new System.Windows.Forms.Button();
			this.cmdDelError = new System.Windows.Forms.Button();
			this.cmdAddError = new System.Windows.Forms.Button();
			this.dbgSubmitErrors = new AxMSDBGrid.AxDBGrid();
			this.dbgValidationErrorAction = new AxMSDBGrid.AxDBGrid();
			this.Label3 = new System.Windows.Forms.Label();
			this._sstabValidation_TabPage1 = new System.Windows.Forms.TabPage();
			this.Label2 = new System.Windows.Forms.Label();
			this.dbgSubmitWarnings = new AxMSDBGrid.AxDBGrid();
			this.cmdAddWarning = new System.Windows.Forms.Button();
			this.cmdDeleteWarning = new System.Windows.Forms.Button();
			this.cmdUpdateWarning = new System.Windows.Forms.Button();
			this.cmdValidWarningAddCrit = new System.Windows.Forms.Button();
			this.cmdValidWarningAddCritAnd = new System.Windows.Forms.Button();
			this.cmdValidWarningAddCritOr = new System.Windows.Forms.Button();
			this.cmdChangeToError = new System.Windows.Forms.Button();
			this.dbgValidationWarningAction = new AxMSDBGrid.AxDBGrid();
			this.cmdAddWarningAction = new System.Windows.Forms.Button();
			this.cmdDeleteWarningAction = new System.Windows.Forms.Button();
			this.lstWarningCriteriaSet = new System.Windows.Forms.ListBox();
			this.cmdChangeWarningStatus = new System.Windows.Forms.Button();
			this.cmdValidWarningChangemainjoinop = new System.Windows.Forms.Button();
			this.cmdValidWarningDeleteCrit = new System.Windows.Forms.Button();
			this.cmdWarningDupWarning = new System.Windows.Forms.Button();
			this.cmdWarningDupError = new System.Windows.Forms.Button();
			this.cmdValidWarningEditLeft = new System.Windows.Forms.Button();
			this.CmdWarningRight = new System.Windows.Forms.Button();
			this.cmdWarnCopySet = new System.Windows.Forms.Button();
			this.rdcValidationErrorAction = new AxMSRDC.AxMSRDC();
			this.rdcValidationWarningAction = new AxMSRDC.AxMSRDC();
			this.Label1 = new System.Windows.Forms.Label();
			this.sstabValidation.SuspendLayout();
			this._sstabValidation_TabPage0.SuspendLayout();
			this._sstabValidation_TabPage1.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.rdcTableList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarnings).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrorCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarningCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrors).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitErrors).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationErrorAction).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitWarnings).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationWarningAction).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrorAction).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarningAction).BeginInit();
			this.Text = "Table Validation Setup";
			this.ClientSize = new System.Drawing.Size(1092, 1030);
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
			this.Name = "frmTableValidationSetup";
			this.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Command1.Text = "Print Criteria Window";
			this.Command1.Size = new System.Drawing.Size(135, 42);
			this.Command1.Location = new System.Drawing.Point(650, 970);
			this.Command1.TabIndex = 46;
			this.Command1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Command1.BackColor = System.Drawing.SystemColors.Control;
			this.Command1.CausesValidation = true;
			this.Command1.Enabled = true;
			this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Command1.TabStop = true;
			this.Command1.Name = "Command1";
			this.cmdExportValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdExportValidation.Text = "Export Validation To Text File";
			this.cmdExportValidation.Size = new System.Drawing.Size(240, 42);
			this.cmdExportValidation.Location = new System.Drawing.Point(30, 980);
			this.cmdExportValidation.TabIndex = 34;
			this.cmdExportValidation.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdExportValidation.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExportValidation.CausesValidation = true;
			this.cmdExportValidation.Enabled = true;
			this.cmdExportValidation.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExportValidation.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExportValidation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExportValidation.TabStop = true;
			this.cmdExportValidation.Name = "cmdExportValidation";
			this.cboTableList.Size = new System.Drawing.Size(415, 27);
			this.cboTableList.Location = new System.Drawing.Point(173, 7);
			this.cboTableList.TabIndex = 0;
			this.cboTableList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboTableList.BackColor = System.Drawing.SystemColors.Window;
			this.cboTableList.CausesValidation = true;
			this.cboTableList.Enabled = true;
			this.cboTableList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboTableList.IntegralHeight = true;
			this.cboTableList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboTableList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboTableList.Sorted = false;
			this.cboTableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboTableList.TabStop = true;
			this.cboTableList.Visible = true;
			this.cboTableList.Name = "cboTableList";
			rdcTableList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcTableList.OcxState");
			this.rdcTableList.Size = new System.Drawing.Size(197, 28);
			this.rdcTableList.Location = new System.Drawing.Point(27, 1030);
			this.rdcTableList.Visible = false;
			this.rdcTableList.Name = "rdcTableList";
			rdcValidationWarnings.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationWarnings.OcxState");
			this.rdcValidationWarnings.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationWarnings.Location = new System.Drawing.Point(434, 1029);
			this.rdcValidationWarnings.Visible = false;
			this.rdcValidationWarnings.Name = "rdcValidationWarnings";
			rdcValidationErrorCriteria.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationErrorCriteria.OcxState");
			this.rdcValidationErrorCriteria.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationErrorCriteria.Location = new System.Drawing.Point(230, 1053);
			this.rdcValidationErrorCriteria.Visible = false;
			this.rdcValidationErrorCriteria.Name = "rdcValidationErrorCriteria";
			rdcValidationWarningCriteria.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationWarningCriteria.OcxState");
			this.rdcValidationWarningCriteria.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationWarningCriteria.Location = new System.Drawing.Point(434, 1058);
			this.rdcValidationWarningCriteria.Visible = false;
			this.rdcValidationWarningCriteria.Name = "rdcValidationWarningCriteria";
			rdcValidationErrors.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationErrors.OcxState");
			this.rdcValidationErrors.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationErrors.Location = new System.Drawing.Point(230, 1028);
			this.rdcValidationErrors.Visible = false;
			this.rdcValidationErrors.Name = "rdcValidationErrors";
			this.sstabValidation.Size = new System.Drawing.Size(1048, 917);
			this.sstabValidation.Location = new System.Drawing.Point(30, 45);
			this.sstabValidation.TabIndex = 2;
			this.sstabValidation.SelectedIndex = 1;
			this.sstabValidation.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabValidation.ForeColor = System.Drawing.Color.Blue;
			this.sstabValidation.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabValidation.Name = "sstabValidation";
			this._sstabValidation_TabPage0.Text = "Errors";
			this.cmdErrorCopySet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdErrorCopySet.Text = "Copy Set";
			this.cmdErrorCopySet.Size = new System.Drawing.Size(112, 32);
			this.cmdErrorCopySet.Location = new System.Drawing.Point(95, 750);
			this.cmdErrorCopySet.TabIndex = 44;
			this.cmdErrorCopySet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdErrorCopySet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdErrorCopySet.CausesValidation = true;
			this.cmdErrorCopySet.Enabled = true;
			this.cmdErrorCopySet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdErrorCopySet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdErrorCopySet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdErrorCopySet.TabStop = true;
			this.cmdErrorCopySet.Name = "cmdErrorCopySet";
			this.cmdRightLookup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRightLookup.Text = "Edit Right Lookup Val";
			this.cmdRightLookup.Size = new System.Drawing.Size(115, 50);
			this.cmdRightLookup.Location = new System.Drawing.Point(465, 712);
			this.cmdRightLookup.TabIndex = 43;
			this.cmdRightLookup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRightLookup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRightLookup.CausesValidation = true;
			this.cmdRightLookup.Enabled = true;
			this.cmdRightLookup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRightLookup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRightLookup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRightLookup.TabStop = true;
			this.cmdRightLookup.Name = "cmdRightLookup";
			this.cmdDupWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDupWarn.Text = "Dup As Warning";
			this.cmdDupWarn.Size = new System.Drawing.Size(117, 42);
			this.cmdDupWarn.Location = new System.Drawing.Point(230, 490);
			this.cmdDupWarn.TabIndex = 38;
			this.cmdDupWarn.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDupWarn.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDupWarn.CausesValidation = true;
			this.cmdDupWarn.Enabled = true;
			this.cmdDupWarn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDupWarn.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDupWarn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDupWarn.TabStop = true;
			this.cmdDupWarn.Name = "cmdDupWarn";
			this.cmdDupError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDupError.Text = "Dup As Error";
			this.cmdDupError.Size = new System.Drawing.Size(117, 33);
			this.cmdDupError.Location = new System.Drawing.Point(230, 448);
			this.cmdDupError.TabIndex = 37;
			this.cmdDupError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDupError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDupError.CausesValidation = true;
			this.cmdDupError.Enabled = true;
			this.cmdDupError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDupError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDupError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDupError.TabStop = true;
			this.cmdDupError.Name = "cmdDupError";
			this.cmdValidErrorEditLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidErrorEditLeft.Text = "Edit Left Field";
			this.cmdValidErrorEditLeft.Size = new System.Drawing.Size(115, 32);
			this.cmdValidErrorEditLeft.Location = new System.Drawing.Point(345, 712);
			this.cmdValidErrorEditLeft.TabIndex = 35;
			this.cmdValidErrorEditLeft.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidErrorEditLeft.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidErrorEditLeft.CausesValidation = true;
			this.cmdValidErrorEditLeft.Enabled = true;
			this.cmdValidErrorEditLeft.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidErrorEditLeft.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidErrorEditLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidErrorEditLeft.TabStop = true;
			this.cmdValidErrorEditLeft.Name = "cmdValidErrorEditLeft";
			this.cmdValidErrorChangemainjoinop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidErrorChangemainjoinop.Text = "Change to And/Or between sets";
			this.cmdValidErrorChangemainjoinop.Enabled = false;
			this.cmdValidErrorChangemainjoinop.Size = new System.Drawing.Size(83, 70);
			this.cmdValidErrorChangemainjoinop.Location = new System.Drawing.Point(675, 712);
			this.cmdValidErrorChangemainjoinop.Image = (System.Drawing.Image)resources.GetObject("cmdValidErrorChangemainjoinop.Image");
			this.cmdValidErrorChangemainjoinop.TabIndex = 32;
			this.cmdValidErrorChangemainjoinop.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidErrorChangemainjoinop.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidErrorChangemainjoinop.CausesValidation = true;
			this.cmdValidErrorChangemainjoinop.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidErrorChangemainjoinop.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidErrorChangemainjoinop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidErrorChangemainjoinop.TabStop = true;
			this.cmdValidErrorChangemainjoinop.Name = "cmdValidErrorChangemainjoinop";
			this.cmdChangeErrorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeErrorStatus.Text = "Change Status";
			this.cmdChangeErrorStatus.Size = new System.Drawing.Size(104, 33);
			this.cmdChangeErrorStatus.Location = new System.Drawing.Point(510, 448);
			this.cmdChangeErrorStatus.TabIndex = 30;
			this.cmdChangeErrorStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeErrorStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeErrorStatus.CausesValidation = true;
			this.cmdChangeErrorStatus.Enabled = true;
			this.cmdChangeErrorStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeErrorStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeErrorStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeErrorStatus.TabStop = true;
			this.cmdChangeErrorStatus.Name = "cmdChangeErrorStatus";
			this.lstErrorCriteriaSet.Size = new System.Drawing.Size(1015, 155);
			this.lstErrorCriteriaSet.Location = new System.Drawing.Point(20, 550);
			this.lstErrorCriteriaSet.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstErrorCriteriaSet.TabIndex = 27;
			this.lstErrorCriteriaSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstErrorCriteriaSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstErrorCriteriaSet.BackColor = System.Drawing.SystemColors.Window;
			this.lstErrorCriteriaSet.CausesValidation = true;
			this.lstErrorCriteriaSet.Enabled = true;
			this.lstErrorCriteriaSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstErrorCriteriaSet.IntegralHeight = true;
			this.lstErrorCriteriaSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstErrorCriteriaSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstErrorCriteriaSet.Sorted = false;
			this.lstErrorCriteriaSet.TabStop = true;
			this.lstErrorCriteriaSet.Visible = true;
			this.lstErrorCriteriaSet.MultiColumn = false;
			this.lstErrorCriteriaSet.Name = "lstErrorCriteriaSet";
			this.cmdDeleteErrorAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteErrorAction.Text = "Delete Action";
			this.cmdDeleteErrorAction.Size = new System.Drawing.Size(103, 35);
			this.cmdDeleteErrorAction.Location = new System.Drawing.Point(145, 874);
			this.cmdDeleteErrorAction.TabIndex = 23;
			this.cmdDeleteErrorAction.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteErrorAction.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteErrorAction.CausesValidation = true;
			this.cmdDeleteErrorAction.Enabled = true;
			this.cmdDeleteErrorAction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteErrorAction.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteErrorAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteErrorAction.TabStop = true;
			this.cmdDeleteErrorAction.Name = "cmdDeleteErrorAction";
			this.cmdAddErroraction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddErroraction.Text = "Add Action";
			this.cmdAddErroraction.Size = new System.Drawing.Size(103, 35);
			this.cmdAddErroraction.Location = new System.Drawing.Point(19, 874);
			this.cmdAddErroraction.TabIndex = 22;
			this.cmdAddErroraction.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddErroraction.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddErroraction.CausesValidation = true;
			this.cmdAddErroraction.Enabled = true;
			this.cmdAddErroraction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddErroraction.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddErroraction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddErroraction.TabStop = true;
			this.cmdAddErroraction.Name = "cmdAddErroraction";
			this.cmdChangeToWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeToWarning.Text = "Change to Warning";
			this.cmdChangeToWarning.Size = new System.Drawing.Size(128, 34);
			this.cmdChangeToWarning.Location = new System.Drawing.Point(622, 447);
			this.cmdChangeToWarning.TabIndex = 16;
			this.cmdChangeToWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeToWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeToWarning.CausesValidation = true;
			this.cmdChangeToWarning.Enabled = true;
			this.cmdChangeToWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeToWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeToWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeToWarning.TabStop = true;
			this.cmdChangeToWarning.Name = "cmdChangeToWarning";
			this.cmdValidErrorAddCritOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidErrorAddCritOr.Text = "Or";
			this.cmdValidErrorAddCritOr.Enabled = false;
			this.cmdValidErrorAddCritOr.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidErrorAddCritOr.Size = new System.Drawing.Size(30, 32);
			this.cmdValidErrorAddCritOr.Location = new System.Drawing.Point(63, 712);
			this.cmdValidErrorAddCritOr.Image = (System.Drawing.Image)resources.GetObject("cmdValidErrorAddCritOr.Image");
			this.cmdValidErrorAddCritOr.TabIndex = 13;
			this.cmdValidErrorAddCritOr.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidErrorAddCritOr.CausesValidation = true;
			this.cmdValidErrorAddCritOr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidErrorAddCritOr.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidErrorAddCritOr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidErrorAddCritOr.TabStop = true;
			this.cmdValidErrorAddCritOr.Name = "cmdValidErrorAddCritOr";
			this.cmdValidErrorAddCritAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidErrorAddCritAnd.Text = "And";
			this.cmdValidErrorAddCritAnd.Enabled = false;
			this.cmdValidErrorAddCritAnd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidErrorAddCritAnd.Size = new System.Drawing.Size(42, 32);
			this.cmdValidErrorAddCritAnd.Location = new System.Drawing.Point(18, 712);
			this.cmdValidErrorAddCritAnd.Image = (System.Drawing.Image)resources.GetObject("cmdValidErrorAddCritAnd.Image");
			this.cmdValidErrorAddCritAnd.TabIndex = 12;
			this.cmdValidErrorAddCritAnd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidErrorAddCritAnd.CausesValidation = true;
			this.cmdValidErrorAddCritAnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidErrorAddCritAnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidErrorAddCritAnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidErrorAddCritAnd.TabStop = true;
			this.cmdValidErrorAddCritAnd.Name = "cmdValidErrorAddCritAnd";
			this.cmdValidErrorDeleteCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidErrorDeleteCrit.Text = "Delete Criteria";
			this.cmdValidErrorDeleteCrit.Size = new System.Drawing.Size(125, 32);
			this.cmdValidErrorDeleteCrit.Location = new System.Drawing.Point(214, 712);
			this.cmdValidErrorDeleteCrit.TabIndex = 10;
			this.cmdValidErrorDeleteCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidErrorDeleteCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidErrorDeleteCrit.CausesValidation = true;
			this.cmdValidErrorDeleteCrit.Enabled = true;
			this.cmdValidErrorDeleteCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidErrorDeleteCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidErrorDeleteCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidErrorDeleteCrit.TabStop = true;
			this.cmdValidErrorDeleteCrit.Name = "cmdValidErrorDeleteCrit";
			this.cmdValidErrorAddCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidErrorAddCrit.Text = "Add Criteria";
			this.cmdValidErrorAddCrit.Size = new System.Drawing.Size(112, 32);
			this.cmdValidErrorAddCrit.Location = new System.Drawing.Point(99, 712);
			this.cmdValidErrorAddCrit.TabIndex = 9;
			this.cmdValidErrorAddCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidErrorAddCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidErrorAddCrit.CausesValidation = true;
			this.cmdValidErrorAddCrit.Enabled = true;
			this.cmdValidErrorAddCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidErrorAddCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidErrorAddCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidErrorAddCrit.TabStop = true;
			this.cmdValidErrorAddCrit.Name = "cmdValidErrorAddCrit";
			this.cmdUpdateError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdateError.Text = "Update Error";
			this.cmdUpdateError.Size = new System.Drawing.Size(107, 33);
			this.cmdUpdateError.Location = new System.Drawing.Point(110, 448);
			this.cmdUpdateError.TabIndex = 5;
			this.cmdUpdateError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdateError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdateError.CausesValidation = true;
			this.cmdUpdateError.Enabled = true;
			this.cmdUpdateError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdateError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdateError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdateError.TabStop = true;
			this.cmdUpdateError.Name = "cmdUpdateError";
			this.cmdDelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelError.Text = "Delete Error";
			this.cmdDelError.Size = new System.Drawing.Size(82, 33);
			this.cmdDelError.Location = new System.Drawing.Point(420, 448);
			this.cmdDelError.TabIndex = 4;
			this.cmdDelError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelError.CausesValidation = true;
			this.cmdDelError.Enabled = true;
			this.cmdDelError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelError.TabStop = true;
			this.cmdDelError.Name = "cmdDelError";
			this.cmdAddError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddError.Text = "Add Error";
			this.cmdAddError.Size = new System.Drawing.Size(73, 33);
			this.cmdAddError.Location = new System.Drawing.Point(24, 448);
			this.cmdAddError.TabIndex = 3;
			this.cmdAddError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddError.CausesValidation = true;
			this.cmdAddError.Enabled = true;
			this.cmdAddError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddError.TabStop = true;
			this.cmdAddError.Name = "cmdAddError";
			dbgSubmitErrors.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgSubmitErrors.OcxState");
			this.dbgSubmitErrors.Size = new System.Drawing.Size(1008, 390);
			this.dbgSubmitErrors.Location = new System.Drawing.Point(22, 44);
			this.dbgSubmitErrors.TabIndex = 18;
			this.dbgSubmitErrors.Name = "dbgSubmitErrors";
			dbgValidationErrorAction.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgValidationErrorAction.OcxState");
			this.dbgValidationErrorAction.Size = new System.Drawing.Size(1014, 83);
			this.dbgValidationErrorAction.Location = new System.Drawing.Point(20, 789);
			this.dbgValidationErrorAction.TabIndex = 21;
			this.dbgValidationErrorAction.Name = "dbgValidationErrorAction";
			this.Label3.Text = "If the following conditions apply:";
			this.Label3.Size = new System.Drawing.Size(279, 20);
			this.Label3.Location = new System.Drawing.Point(10, 520);
			this.Label3.TabIndex = 29;
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
			this._sstabValidation_TabPage1.Text = "Warnings";
			this.Label2.Text = "If the following conditions apply:";
			this.Label2.Size = new System.Drawing.Size(279, 20);
			this.Label2.Location = new System.Drawing.Point(20, 560);
			this.Label2.TabIndex = 28;
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
			dbgSubmitWarnings.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgSubmitWarnings.OcxState");
			this.dbgSubmitWarnings.Size = new System.Drawing.Size(998, 444);
			this.dbgSubmitWarnings.Location = new System.Drawing.Point(23, 45);
			this.dbgSubmitWarnings.TabIndex = 19;
			this.dbgSubmitWarnings.Name = "dbgSubmitWarnings";
			this.cmdAddWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddWarning.Text = "Add Warning";
			this.cmdAddWarning.Size = new System.Drawing.Size(117, 33);
			this.cmdAddWarning.Location = new System.Drawing.Point(15, 494);
			this.cmdAddWarning.TabIndex = 6;
			this.cmdAddWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddWarning.CausesValidation = true;
			this.cmdAddWarning.Enabled = true;
			this.cmdAddWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddWarning.TabStop = true;
			this.cmdAddWarning.Name = "cmdAddWarning";
			this.cmdDeleteWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteWarning.Text = "Delete Warning";
			this.cmdDeleteWarning.Size = new System.Drawing.Size(103, 33);
			this.cmdDeleteWarning.Location = new System.Drawing.Point(400, 494);
			this.cmdDeleteWarning.TabIndex = 7;
			this.cmdDeleteWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteWarning.CausesValidation = true;
			this.cmdDeleteWarning.Enabled = true;
			this.cmdDeleteWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteWarning.TabStop = true;
			this.cmdDeleteWarning.Name = "cmdDeleteWarning";
			this.cmdUpdateWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdUpdateWarning.Text = "Update Warning";
			this.cmdUpdateWarning.Size = new System.Drawing.Size(133, 33);
			this.cmdUpdateWarning.Location = new System.Drawing.Point(134, 494);
			this.cmdUpdateWarning.TabIndex = 8;
			this.cmdUpdateWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdUpdateWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdateWarning.CausesValidation = true;
			this.cmdUpdateWarning.Enabled = true;
			this.cmdUpdateWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdateWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdateWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdateWarning.TabStop = true;
			this.cmdUpdateWarning.Name = "cmdUpdateWarning";
			this.cmdValidWarningAddCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningAddCrit.Text = "Add Criteria";
			this.cmdValidWarningAddCrit.Size = new System.Drawing.Size(108, 32);
			this.cmdValidWarningAddCrit.Location = new System.Drawing.Point(95, 695);
			this.cmdValidWarningAddCrit.TabIndex = 11;
			this.cmdValidWarningAddCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningAddCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningAddCrit.CausesValidation = true;
			this.cmdValidWarningAddCrit.Enabled = true;
			this.cmdValidWarningAddCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningAddCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningAddCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningAddCrit.TabStop = true;
			this.cmdValidWarningAddCrit.Name = "cmdValidWarningAddCrit";
			this.cmdValidWarningAddCritAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningAddCritAnd.Text = "And";
			this.cmdValidWarningAddCritAnd.Enabled = false;
			this.cmdValidWarningAddCritAnd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningAddCritAnd.Size = new System.Drawing.Size(42, 32);
			this.cmdValidWarningAddCritAnd.Location = new System.Drawing.Point(15, 695);
			this.cmdValidWarningAddCritAnd.Image = (System.Drawing.Image)resources.GetObject("cmdValidWarningAddCritAnd.Image");
			this.cmdValidWarningAddCritAnd.TabIndex = 14;
			this.cmdValidWarningAddCritAnd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningAddCritAnd.CausesValidation = true;
			this.cmdValidWarningAddCritAnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningAddCritAnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningAddCritAnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningAddCritAnd.TabStop = true;
			this.cmdValidWarningAddCritAnd.Name = "cmdValidWarningAddCritAnd";
			this.cmdValidWarningAddCritOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningAddCritOr.Text = "Or";
			this.cmdValidWarningAddCritOr.Enabled = false;
			this.cmdValidWarningAddCritOr.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningAddCritOr.Size = new System.Drawing.Size(30, 32);
			this.cmdValidWarningAddCritOr.Location = new System.Drawing.Point(60, 695);
			this.cmdValidWarningAddCritOr.Image = (System.Drawing.Image)resources.GetObject("cmdValidWarningAddCritOr.Image");
			this.cmdValidWarningAddCritOr.TabIndex = 15;
			this.cmdValidWarningAddCritOr.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningAddCritOr.CausesValidation = true;
			this.cmdValidWarningAddCritOr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningAddCritOr.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningAddCritOr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningAddCritOr.TabStop = true;
			this.cmdValidWarningAddCritOr.Name = "cmdValidWarningAddCritOr";
			this.cmdChangeToError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeToError.Text = "Change to Error";
			this.cmdChangeToError.Size = new System.Drawing.Size(118, 33);
			this.cmdChangeToError.Location = new System.Drawing.Point(625, 494);
			this.cmdChangeToError.TabIndex = 17;
			this.cmdChangeToError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeToError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeToError.CausesValidation = true;
			this.cmdChangeToError.Enabled = true;
			this.cmdChangeToError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeToError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeToError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeToError.TabStop = true;
			this.cmdChangeToError.Name = "cmdChangeToError";
			dbgValidationWarningAction.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgValidationWarningAction.OcxState");
			this.dbgValidationWarningAction.Size = new System.Drawing.Size(999, 85);
			this.dbgValidationWarningAction.Location = new System.Drawing.Point(19, 783);
			this.dbgValidationWarningAction.TabIndex = 20;
			this.dbgValidationWarningAction.Name = "dbgValidationWarningAction";
			this.cmdAddWarningAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddWarningAction.Text = "Add Action";
			this.cmdAddWarningAction.Size = new System.Drawing.Size(103, 35);
			this.cmdAddWarningAction.Location = new System.Drawing.Point(10, 870);
			this.cmdAddWarningAction.TabIndex = 24;
			this.cmdAddWarningAction.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddWarningAction.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddWarningAction.CausesValidation = true;
			this.cmdAddWarningAction.Enabled = true;
			this.cmdAddWarningAction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddWarningAction.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddWarningAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddWarningAction.TabStop = true;
			this.cmdAddWarningAction.Name = "cmdAddWarningAction";
			this.cmdDeleteWarningAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDeleteWarningAction.Text = "Delete Action";
			this.cmdDeleteWarningAction.Size = new System.Drawing.Size(103, 35);
			this.cmdDeleteWarningAction.Location = new System.Drawing.Point(122, 870);
			this.cmdDeleteWarningAction.TabIndex = 25;
			this.cmdDeleteWarningAction.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDeleteWarningAction.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDeleteWarningAction.CausesValidation = true;
			this.cmdDeleteWarningAction.Enabled = true;
			this.cmdDeleteWarningAction.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDeleteWarningAction.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDeleteWarningAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDeleteWarningAction.TabStop = true;
			this.cmdDeleteWarningAction.Name = "cmdDeleteWarningAction";
			this.lstWarningCriteriaSet.Size = new System.Drawing.Size(999, 107);
			this.lstWarningCriteriaSet.Location = new System.Drawing.Point(20, 580);
			this.lstWarningCriteriaSet.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstWarningCriteriaSet.TabIndex = 26;
			this.lstWarningCriteriaSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstWarningCriteriaSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstWarningCriteriaSet.BackColor = System.Drawing.SystemColors.Window;
			this.lstWarningCriteriaSet.CausesValidation = true;
			this.lstWarningCriteriaSet.Enabled = true;
			this.lstWarningCriteriaSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstWarningCriteriaSet.IntegralHeight = true;
			this.lstWarningCriteriaSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstWarningCriteriaSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstWarningCriteriaSet.Sorted = false;
			this.lstWarningCriteriaSet.TabStop = true;
			this.lstWarningCriteriaSet.Visible = true;
			this.lstWarningCriteriaSet.MultiColumn = false;
			this.lstWarningCriteriaSet.Name = "lstWarningCriteriaSet";
			this.cmdChangeWarningStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeWarningStatus.Text = "Change Status";
			this.cmdChangeWarningStatus.Size = new System.Drawing.Size(103, 33);
			this.cmdChangeWarningStatus.Location = new System.Drawing.Point(510, 494);
			this.cmdChangeWarningStatus.TabIndex = 31;
			this.cmdChangeWarningStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeWarningStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeWarningStatus.CausesValidation = true;
			this.cmdChangeWarningStatus.Enabled = true;
			this.cmdChangeWarningStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeWarningStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeWarningStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeWarningStatus.TabStop = true;
			this.cmdChangeWarningStatus.Name = "cmdChangeWarningStatus";
			this.cmdValidWarningChangemainjoinop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningChangemainjoinop.Text = "Change to And/Or between sets";
			this.cmdValidWarningChangemainjoinop.Enabled = false;
			this.cmdValidWarningChangemainjoinop.Size = new System.Drawing.Size(82, 82);
			this.cmdValidWarningChangemainjoinop.Location = new System.Drawing.Point(670, 695);
			this.cmdValidWarningChangemainjoinop.Image = (System.Drawing.Image)resources.GetObject("cmdValidWarningChangemainjoinop.Image");
			this.cmdValidWarningChangemainjoinop.TabIndex = 33;
			this.cmdValidWarningChangemainjoinop.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningChangemainjoinop.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningChangemainjoinop.CausesValidation = true;
			this.cmdValidWarningChangemainjoinop.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningChangemainjoinop.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningChangemainjoinop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningChangemainjoinop.TabStop = true;
			this.cmdValidWarningChangemainjoinop.Name = "cmdValidWarningChangemainjoinop";
			this.cmdValidWarningDeleteCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningDeleteCrit.Text = "Delete Criteria";
			this.cmdValidWarningDeleteCrit.Size = new System.Drawing.Size(114, 32);
			this.cmdValidWarningDeleteCrit.Location = new System.Drawing.Point(208, 695);
			this.cmdValidWarningDeleteCrit.TabIndex = 36;
			this.cmdValidWarningDeleteCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningDeleteCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningDeleteCrit.CausesValidation = true;
			this.cmdValidWarningDeleteCrit.Enabled = true;
			this.cmdValidWarningDeleteCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningDeleteCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningDeleteCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningDeleteCrit.TabStop = true;
			this.cmdValidWarningDeleteCrit.Name = "cmdValidWarningDeleteCrit";
			this.cmdWarningDupWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdWarningDupWarning.Text = "Dup As Warning";
			this.cmdWarningDupWarning.Size = new System.Drawing.Size(117, 33);
			this.cmdWarningDupWarning.Location = new System.Drawing.Point(280, 533);
			this.cmdWarningDupWarning.TabIndex = 39;
			this.cmdWarningDupWarning.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdWarningDupWarning.BackColor = System.Drawing.SystemColors.Control;
			this.cmdWarningDupWarning.CausesValidation = true;
			this.cmdWarningDupWarning.Enabled = true;
			this.cmdWarningDupWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdWarningDupWarning.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdWarningDupWarning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdWarningDupWarning.TabStop = true;
			this.cmdWarningDupWarning.Name = "cmdWarningDupWarning";
			this.cmdWarningDupError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdWarningDupError.Text = "Dup As Error";
			this.cmdWarningDupError.Size = new System.Drawing.Size(117, 33);
			this.cmdWarningDupError.Location = new System.Drawing.Point(280, 494);
			this.cmdWarningDupError.TabIndex = 40;
			this.cmdWarningDupError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdWarningDupError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdWarningDupError.CausesValidation = true;
			this.cmdWarningDupError.Enabled = true;
			this.cmdWarningDupError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdWarningDupError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdWarningDupError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdWarningDupError.TabStop = true;
			this.cmdWarningDupError.Name = "cmdWarningDupError";
			this.cmdValidWarningEditLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningEditLeft.Text = "Edit Left Field";
			this.cmdValidWarningEditLeft.Size = new System.Drawing.Size(115, 32);
			this.cmdValidWarningEditLeft.Location = new System.Drawing.Point(330, 695);
			this.cmdValidWarningEditLeft.TabIndex = 41;
			this.cmdValidWarningEditLeft.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningEditLeft.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningEditLeft.CausesValidation = true;
			this.cmdValidWarningEditLeft.Enabled = true;
			this.cmdValidWarningEditLeft.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningEditLeft.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningEditLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningEditLeft.TabStop = true;
			this.cmdValidWarningEditLeft.Name = "cmdValidWarningEditLeft";
			this.CmdWarningRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CmdWarningRight.Text = "Edit Right Lookup Val";
			this.CmdWarningRight.Size = new System.Drawing.Size(115, 42);
			this.CmdWarningRight.Location = new System.Drawing.Point(460, 695);
			this.CmdWarningRight.TabIndex = 42;
			this.CmdWarningRight.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CmdWarningRight.BackColor = System.Drawing.SystemColors.Control;
			this.CmdWarningRight.CausesValidation = true;
			this.CmdWarningRight.Enabled = true;
			this.CmdWarningRight.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CmdWarningRight.Cursor = System.Windows.Forms.Cursors.Default;
			this.CmdWarningRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CmdWarningRight.TabStop = true;
			this.CmdWarningRight.Name = "CmdWarningRight";
			this.cmdWarnCopySet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdWarnCopySet.Text = "Copy Set";
			this.cmdWarnCopySet.Size = new System.Drawing.Size(112, 32);
			this.cmdWarnCopySet.Location = new System.Drawing.Point(90, 740);
			this.cmdWarnCopySet.TabIndex = 45;
			this.cmdWarnCopySet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdWarnCopySet.BackColor = System.Drawing.SystemColors.Control;
			this.cmdWarnCopySet.CausesValidation = true;
			this.cmdWarnCopySet.Enabled = true;
			this.cmdWarnCopySet.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdWarnCopySet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdWarnCopySet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdWarnCopySet.TabStop = true;
			this.cmdWarnCopySet.Name = "cmdWarnCopySet";
			rdcValidationErrorAction.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationErrorAction.OcxState");
			this.rdcValidationErrorAction.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationErrorAction.Location = new System.Drawing.Point(230, 1084);
			this.rdcValidationErrorAction.Visible = false;
			this.rdcValidationErrorAction.Name = "rdcValidationErrorAction";
			rdcValidationWarningAction.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationWarningAction.OcxState");
			this.rdcValidationWarningAction.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationWarningAction.Location = new System.Drawing.Point(434, 1087);
			this.rdcValidationWarningAction.Visible = false;
			this.rdcValidationWarningAction.Name = "rdcValidationWarningAction";
			this.Label1.Text = "Tables:";
			this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label1.Size = new System.Drawing.Size(80, 19);
			this.Label1.Location = new System.Drawing.Point(88, 10);
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
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarningAction).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrorAction).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationWarningAction).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitWarnings).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationErrorAction).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitErrors).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrors).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarningCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrorCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarnings).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcTableList).EndInit();
			this.Controls.Add(Command1);
			this.Controls.Add(cmdExportValidation);
			this.Controls.Add(cboTableList);
			this.Controls.Add(rdcTableList);
			this.Controls.Add(rdcValidationWarnings);
			this.Controls.Add(rdcValidationErrorCriteria);
			this.Controls.Add(rdcValidationWarningCriteria);
			this.Controls.Add(rdcValidationErrors);
			this.Controls.Add(sstabValidation);
			this.Controls.Add(rdcValidationErrorAction);
			this.Controls.Add(rdcValidationWarningAction);
			this.Controls.Add(Label1);
			this.sstabValidation.Controls.Add(_sstabValidation_TabPage0);
			this.sstabValidation.Controls.Add(_sstabValidation_TabPage1);
			this._sstabValidation_TabPage0.Controls.Add(cmdErrorCopySet);
			this._sstabValidation_TabPage0.Controls.Add(cmdRightLookup);
			this._sstabValidation_TabPage0.Controls.Add(cmdDupWarn);
			this._sstabValidation_TabPage0.Controls.Add(cmdDupError);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorEditLeft);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorChangemainjoinop);
			this._sstabValidation_TabPage0.Controls.Add(cmdChangeErrorStatus);
			this._sstabValidation_TabPage0.Controls.Add(lstErrorCriteriaSet);
			this._sstabValidation_TabPage0.Controls.Add(cmdDeleteErrorAction);
			this._sstabValidation_TabPage0.Controls.Add(cmdAddErroraction);
			this._sstabValidation_TabPage0.Controls.Add(cmdChangeToWarning);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorAddCritOr);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorAddCritAnd);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorDeleteCrit);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorAddCrit);
			this._sstabValidation_TabPage0.Controls.Add(cmdUpdateError);
			this._sstabValidation_TabPage0.Controls.Add(cmdDelError);
			this._sstabValidation_TabPage0.Controls.Add(cmdAddError);
			this._sstabValidation_TabPage0.Controls.Add(dbgSubmitErrors);
			this._sstabValidation_TabPage0.Controls.Add(dbgValidationErrorAction);
			this._sstabValidation_TabPage0.Controls.Add(Label3);
			this._sstabValidation_TabPage1.Controls.Add(Label2);
			this._sstabValidation_TabPage1.Controls.Add(dbgSubmitWarnings);
			this._sstabValidation_TabPage1.Controls.Add(cmdAddWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdDeleteWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdUpdateWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningAddCrit);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningAddCritAnd);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningAddCritOr);
			this._sstabValidation_TabPage1.Controls.Add(cmdChangeToError);
			this._sstabValidation_TabPage1.Controls.Add(dbgValidationWarningAction);
			this._sstabValidation_TabPage1.Controls.Add(cmdAddWarningAction);
			this._sstabValidation_TabPage1.Controls.Add(cmdDeleteWarningAction);
			this._sstabValidation_TabPage1.Controls.Add(lstWarningCriteriaSet);
			this._sstabValidation_TabPage1.Controls.Add(cmdChangeWarningStatus);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningChangemainjoinop);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningDeleteCrit);
			this._sstabValidation_TabPage1.Controls.Add(cmdWarningDupWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdWarningDupError);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningEditLeft);
			this._sstabValidation_TabPage1.Controls.Add(CmdWarningRight);
			this._sstabValidation_TabPage1.Controls.Add(cmdWarnCopySet);
			this.sstabValidation.ResumeLayout(false);
			this._sstabValidation_TabPage0.ResumeLayout(false);
			this._sstabValidation_TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
