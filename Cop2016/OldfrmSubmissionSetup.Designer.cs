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
	partial class OldfrmSubmissionSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmSubmissionSetup() : base()
		{
			Load += frmSubmissionSetup_Load;
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
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.ListBox lstCategorySelectedList;
		private System.Windows.Forms.Button withEventsField_cmdRemoveCategory;
		public System.Windows.Forms.Button cmdRemoveCategory {
			get { return withEventsField_cmdRemoveCategory; }
			set {
				if (withEventsField_cmdRemoveCategory != null) {
					withEventsField_cmdRemoveCategory.Click -= cmdRemoveCategory_Click;
				}
				withEventsField_cmdRemoveCategory = value;
				if (withEventsField_cmdRemoveCategory != null) {
					withEventsField_cmdRemoveCategory.Click += cmdRemoveCategory_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSelectCategory;
		public System.Windows.Forms.Button cmdSelectCategory {
			get { return withEventsField_cmdSelectCategory; }
			set {
				if (withEventsField_cmdSelectCategory != null) {
					withEventsField_cmdSelectCategory.Click -= cmdSelectCategory_Click;
				}
				withEventsField_cmdSelectCategory = value;
				if (withEventsField_cmdSelectCategory != null) {
					withEventsField_cmdSelectCategory.Click += cmdSelectCategory_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstCategoryLookupList;
		public System.Windows.Forms.ListBox lstSumField;
		private System.Windows.Forms.ComboBox withEventsField_cboSumOp;
		public System.Windows.Forms.ComboBox cboSumOp {
			get { return withEventsField_cboSumOp; }
			set {
				if (withEventsField_cboSumOp != null) {
					withEventsField_cboSumOp.SelectedIndexChanged -= cboSumOp_SelectedIndexChanged;
				}
				withEventsField_cboSumOp = value;
				if (withEventsField_cboSumOp != null) {
					withEventsField_cboSumOp.SelectedIndexChanged += cboSumOp_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboIndicator;
		public System.Windows.Forms.Label Label19;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox Frame1;
		public AxMSDBGrid.AxDBGrid dbgSubmissionFieldList;
		private System.Windows.Forms.Button withEventsField_cmdAddGroup;
		public System.Windows.Forms.Button cmdAddGroup {
			get { return withEventsField_cmdAddGroup; }
			set {
				if (withEventsField_cmdAddGroup != null) {
					withEventsField_cmdAddGroup.Click -= cmdAddGroup_Click;
				}
				withEventsField_cmdAddGroup = value;
				if (withEventsField_cmdAddGroup != null) {
					withEventsField_cmdAddGroup.Click += cmdAddGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddRow;
		public System.Windows.Forms.Button cmdAddRow {
			get { return withEventsField_cmdAddRow; }
			set {
				if (withEventsField_cmdAddRow != null) {
					withEventsField_cmdAddRow.Click -= cmdAddRow_Click;
				}
				withEventsField_cmdAddRow = value;
				if (withEventsField_cmdAddRow != null) {
					withEventsField_cmdAddRow.Click += cmdAddRow_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddCol;
		public System.Windows.Forms.Button cmdAddCol {
			get { return withEventsField_cmdAddCol; }
			set {
				if (withEventsField_cmdAddCol != null) {
					withEventsField_cmdAddCol.Click -= cmdAddCol_Click;
				}
				withEventsField_cmdAddCol = value;
				if (withEventsField_cmdAddCol != null) {
					withEventsField_cmdAddCol.Click += cmdAddCol_Click;
				}
			}
		}
		public System.Windows.Forms.CheckBox chkIncludeGroup;
		public System.Windows.Forms.CheckBox chkDisplayGroupTitle;
		public System.Windows.Forms.CheckBox chkIncludeRow;
		public System.Windows.Forms.CheckBox chkIncludeCol;
		private System.Windows.Forms.Button withEventsField_cmdDelSumCriteria;
		public System.Windows.Forms.Button cmdDelSumCriteria {
			get { return withEventsField_cmdDelSumCriteria; }
			set {
				if (withEventsField_cmdDelSumCriteria != null) {
					withEventsField_cmdDelSumCriteria.Click -= cmdDelSumCriteria_Click;
				}
				withEventsField_cmdDelSumCriteria = value;
				if (withEventsField_cmdDelSumCriteria != null) {
					withEventsField_cmdDelSumCriteria.Click += cmdDelSumCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdAddSumCriteria;
		public System.Windows.Forms.Button cmdAddSumCriteria {
			get { return withEventsField_cmdAddSumCriteria; }
			set {
				if (withEventsField_cmdAddSumCriteria != null) {
					withEventsField_cmdAddSumCriteria.Click -= cmdAddSumCriteria_Click;
				}
				withEventsField_cmdAddSumCriteria = value;
				if (withEventsField_cmdAddSumCriteria != null) {
					withEventsField_cmdAddSumCriteria.Click += cmdAddSumCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeAndOrCond;
		public System.Windows.Forms.Button cmdChangeAndOrCond {
			get { return withEventsField_cmdChangeAndOrCond; }
			set {
				if (withEventsField_cmdChangeAndOrCond != null) {
					withEventsField_cmdChangeAndOrCond.Click -= cmdChangeAndOrCond_Click;
				}
				withEventsField_cmdChangeAndOrCond = value;
				if (withEventsField_cmdChangeAndOrCond != null) {
					withEventsField_cmdChangeAndOrCond.Click += cmdChangeAndOrCond_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCopyCriteria;
		public System.Windows.Forms.Button cmdCopyCriteria {
			get { return withEventsField_cmdCopyCriteria; }
			set {
				if (withEventsField_cmdCopyCriteria != null) {
					withEventsField_cmdCopyCriteria.Click -= cmdCopyCriteria_Click;
				}
				withEventsField_cmdCopyCriteria = value;
				if (withEventsField_cmdCopyCriteria != null) {
					withEventsField_cmdCopyCriteria.Click += cmdCopyCriteria_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCopyCriteriaSets;
		public System.Windows.Forms.Button cmdCopyCriteriaSets {
			get { return withEventsField_cmdCopyCriteriaSets; }
			set {
				if (withEventsField_cmdCopyCriteriaSets != null) {
					withEventsField_cmdCopyCriteriaSets.Click -= cmdCopyCriteriaSets_Click;
				}
				withEventsField_cmdCopyCriteriaSets = value;
				if (withEventsField_cmdCopyCriteriaSets != null) {
					withEventsField_cmdCopyCriteriaSets.Click += cmdCopyCriteriaSets_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeAddOrBetweenSets;
		public System.Windows.Forms.Button cmdChangeAddOrBetweenSets {
			get { return withEventsField_cmdChangeAddOrBetweenSets; }
			set {
				if (withEventsField_cmdChangeAddOrBetweenSets != null) {
					withEventsField_cmdChangeAddOrBetweenSets.Click -= cmdChangeAddOrBetweenSets_Click;
				}
				withEventsField_cmdChangeAddOrBetweenSets = value;
				if (withEventsField_cmdChangeAddOrBetweenSets != null) {
					withEventsField_cmdChangeAddOrBetweenSets.Click += cmdChangeAddOrBetweenSets_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDupSummarytoMeas;
		public System.Windows.Forms.Button cmdDupSummarytoMeas {
			get { return withEventsField_cmdDupSummarytoMeas; }
			set {
				if (withEventsField_cmdDupSummarytoMeas != null) {
					withEventsField_cmdDupSummarytoMeas.Click -= cmdDupSummarytoMeas_Click;
				}
				withEventsField_cmdDupSummarytoMeas = value;
				if (withEventsField_cmdDupSummarytoMeas != null) {
					withEventsField_cmdDupSummarytoMeas.Click += cmdDupSummarytoMeas_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstSummaryDef;
		private System.Windows.Forms.Button withEventsField_cmdSubmissionPrint;
		public System.Windows.Forms.Button cmdSubmissionPrint {
			get { return withEventsField_cmdSubmissionPrint; }
			set {
				if (withEventsField_cmdSubmissionPrint != null) {
					withEventsField_cmdSubmissionPrint.Click -= cmdSubmissionPrint_Click;
				}
				withEventsField_cmdSubmissionPrint = value;
				if (withEventsField_cmdSubmissionPrint != null) {
					withEventsField_cmdSubmissionPrint.Click += cmdSubmissionPrint_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _ssTabSubmission_TabPage0;
		private System.Windows.Forms.Button withEventsField_cmdChangeCleanupStatus;
		public System.Windows.Forms.Button cmdChangeCleanupStatus {
			get { return withEventsField_cmdChangeCleanupStatus; }
			set {
				if (withEventsField_cmdChangeCleanupStatus != null) {
					withEventsField_cmdChangeCleanupStatus.Click -= cmdChangeCleanupStatus_Click;
				}
				withEventsField_cmdChangeCleanupStatus = value;
				if (withEventsField_cmdChangeCleanupStatus != null) {
					withEventsField_cmdChangeCleanupStatus.Click += cmdChangeCleanupStatus_Click;
				}
			}
		}
		public System.Windows.Forms.TextBox txtJoinOperator;
		private System.Windows.Forms.Button withEventsField_cmdCleanupAddCrit;
		public System.Windows.Forms.Button cmdCleanupAddCrit {
			get { return withEventsField_cmdCleanupAddCrit; }
			set {
				if (withEventsField_cmdCleanupAddCrit != null) {
					withEventsField_cmdCleanupAddCrit.Click -= cmdCleanupAddCrit_Click;
				}
				withEventsField_cmdCleanupAddCrit = value;
				if (withEventsField_cmdCleanupAddCrit != null) {
					withEventsField_cmdCleanupAddCrit.Click += cmdCleanupAddCrit_Click;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboCleanupOperation;
		private System.Windows.Forms.ComboBox withEventsField_cboCleanUpFieldToAdd;
		public System.Windows.Forms.ComboBox cboCleanUpFieldToAdd {
			get { return withEventsField_cboCleanUpFieldToAdd; }
			set {
				if (withEventsField_cboCleanUpFieldToAdd != null) {
					withEventsField_cboCleanUpFieldToAdd.SelectedIndexChanged -= cboCleanUpFieldToAdd_SelectedIndexChanged;
				}
				withEventsField_cboCleanUpFieldToAdd = value;
				if (withEventsField_cboCleanUpFieldToAdd != null) {
					withEventsField_cboCleanUpFieldToAdd.SelectedIndexChanged += cboCleanUpFieldToAdd_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtTypeinValue;
		public System.Windows.Forms.TextBox txtTypeinValue {
			get { return withEventsField_txtTypeinValue; }
			set {
				if (withEventsField_txtTypeinValue != null) {
					withEventsField_txtTypeinValue.TextChanged -= txtTypeinValue_TextChanged;
				}
				withEventsField_txtTypeinValue = value;
				if (withEventsField_txtTypeinValue != null) {
					withEventsField_txtTypeinValue.TextChanged += txtTypeinValue_TextChanged;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboCleanupValueList;
		public System.Windows.Forms.ComboBox cboCleanupValueList {
			get { return withEventsField_cboCleanupValueList; }
			set {
				if (withEventsField_cboCleanupValueList != null) {
					withEventsField_cboCleanupValueList.SelectedIndexChanged -= cboCleanupValueList_SelectedIndexChanged;
				}
				withEventsField_cboCleanupValueList = value;
				if (withEventsField_cboCleanupValueList != null) {
					withEventsField_cboCleanupValueList.SelectedIndexChanged += cboCleanupValueList_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.RadioButton optCleanupValue;
		public System.Windows.Forms.RadioButton optCleanupLookupTable;
		private System.Windows.Forms.ComboBox withEventsField_cboCleanupLookupTables;
		public System.Windows.Forms.ComboBox cboCleanupLookupTables {
			get { return withEventsField_cboCleanupLookupTables; }
			set {
				if (withEventsField_cboCleanupLookupTables != null) {
					withEventsField_cboCleanupLookupTables.SelectedIndexChanged -= cboCleanupLookupTables_SelectedIndexChanged;
				}
				withEventsField_cboCleanupLookupTables = value;
				if (withEventsField_cboCleanupLookupTables != null) {
					withEventsField_cboCleanupLookupTables.SelectedIndexChanged += cboCleanupLookupTables_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.GroupBox Frame2;
		private System.Windows.Forms.Button withEventsField_cmdCleanupAnd;
		public System.Windows.Forms.Button cmdCleanupAnd {
			get { return withEventsField_cmdCleanupAnd; }
			set {
				if (withEventsField_cmdCleanupAnd != null) {
					withEventsField_cmdCleanupAnd.Click -= cmdCleanupAnd_Click;
				}
				withEventsField_cmdCleanupAnd = value;
				if (withEventsField_cmdCleanupAnd != null) {
					withEventsField_cmdCleanupAnd.Click += cmdCleanupAnd_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdCleanupOr;
		public System.Windows.Forms.Button cmdCleanupOr {
			get { return withEventsField_cmdCleanupOr; }
			set {
				if (withEventsField_cmdCleanupOr != null) {
					withEventsField_cmdCleanupOr.Click -= cmdCleanupOr_Click;
				}
				withEventsField_cmdCleanupOr = value;
				if (withEventsField_cmdCleanupOr != null) {
					withEventsField_cmdCleanupOr.Click += cmdCleanupOr_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.GroupBox Frame3;
		private System.Windows.Forms.Button withEventsField_cmdCleanupCriteria;
		public System.Windows.Forms.Button cmdCleanupCriteria {
			get { return withEventsField_cmdCleanupCriteria; }
			set {
				if (withEventsField_cmdCleanupCriteria != null) {
					withEventsField_cmdCleanupCriteria.Click -= cmdCleanupCriteria_Click;
				}
				withEventsField_cmdCleanupCriteria = value;
				if (withEventsField_cmdCleanupCriteria != null) {
					withEventsField_cmdCleanupCriteria.Click += cmdCleanupCriteria_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstCleanupCriteria;
		private System.Windows.Forms.ListBox withEventsField_lstCleanUpFields;
		public System.Windows.Forms.ListBox lstCleanUpFields {
			get { return withEventsField_lstCleanUpFields; }
			set {
				if (withEventsField_lstCleanUpFields != null) {
					withEventsField_lstCleanUpFields.SelectedIndexChanged -= lstCleanUpFields_SelectedIndexChanged;
				}
				withEventsField_lstCleanUpFields = value;
				if (withEventsField_lstCleanUpFields != null) {
					withEventsField_lstCleanUpFields.SelectedIndexChanged += lstCleanUpFields_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDelCleanUpField;
		public System.Windows.Forms.Button cmdDelCleanUpField {
			get { return withEventsField_cmdDelCleanUpField; }
			set {
				if (withEventsField_cmdDelCleanUpField != null) {
					withEventsField_cmdDelCleanUpField.Click -= cmdDelCleanUpField_Click;
				}
				withEventsField_cmdDelCleanUpField = value;
				if (withEventsField_cmdDelCleanUpField != null) {
					withEventsField_cmdDelCleanUpField.Click += cmdDelCleanUpField_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.TabPage _ssTabSubmission_TabPage1;
		private System.Windows.Forms.Button withEventsField_cmdPrintSummaryVal;
		public System.Windows.Forms.Button cmdPrintSummaryVal {
			get { return withEventsField_cmdPrintSummaryVal; }
			set {
				if (withEventsField_cmdPrintSummaryVal != null) {
					withEventsField_cmdPrintSummaryVal.Click -= cmdPrintSummaryVal_Click;
				}
				withEventsField_cmdPrintSummaryVal = value;
				if (withEventsField_cmdPrintSummaryVal != null) {
					withEventsField_cmdPrintSummaryVal.Click += cmdPrintSummaryVal_Click;
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
		public AxMSDBGrid.AxDBGrid dbgValidationErrorCriteria;
		public System.Windows.Forms.TabPage _sstabValidation_TabPage0;
		public AxMSDBGrid.AxDBGrid dbgValidationWarningCriteria;
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
		public System.Windows.Forms.TabPage _sstabValidation_TabPage1;
		public System.Windows.Forms.TabControl sstabValidation;
		public System.Windows.Forms.TabPage _ssTabSubmission_TabPage2;
		private System.Windows.Forms.Button withEventsField_cmdPrint;
		public System.Windows.Forms.Button cmdPrint {
			get { return withEventsField_cmdPrint; }
			set {
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click -= cmdPrint_Click;
				}
				withEventsField_cmdPrint = value;
				if (withEventsField_cmdPrint != null) {
					withEventsField_cmdPrint.Click += cmdPrint_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboRecordCleanupSet;
		public System.Windows.Forms.ComboBox cboRecordCleanupSet {
			get { return withEventsField_cboRecordCleanupSet; }
			set {
				if (withEventsField_cboRecordCleanupSet != null) {
					withEventsField_cboRecordCleanupSet.SelectedIndexChanged -= cboRecordCleanupSet_SelectedIndexChanged;
				}
				withEventsField_cboRecordCleanupSet = value;
				if (withEventsField_cboRecordCleanupSet != null) {
					withEventsField_cboRecordCleanupSet.SelectedIndexChanged += cboRecordCleanupSet_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboRecordCleanupJoinOperator;
		private System.Windows.Forms.CheckBox withEventsField_chkRecordCleanupBlank;
		public System.Windows.Forms.CheckBox chkRecordCleanupBlank {
			get { return withEventsField_chkRecordCleanupBlank; }
			set {
				if (withEventsField_chkRecordCleanupBlank != null) {
					withEventsField_chkRecordCleanupBlank.CheckStateChanged -= chkRecordCleanupBlank_CheckStateChanged;
				}
				withEventsField_chkRecordCleanupBlank = value;
				if (withEventsField_chkRecordCleanupBlank != null) {
					withEventsField_chkRecordCleanupBlank.CheckStateChanged += chkRecordCleanupBlank_CheckStateChanged;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cboRecordCleanupLookupList;
		public System.Windows.Forms.ComboBox cboRecordCleanupLookupList {
			get { return withEventsField_cboRecordCleanupLookupList; }
			set {
				if (withEventsField_cboRecordCleanupLookupList != null) {
					withEventsField_cboRecordCleanupLookupList.SelectedIndexChanged -= cboRecordCleanupLookupList_SelectedIndexChanged;
				}
				withEventsField_cboRecordCleanupLookupList = value;
				if (withEventsField_cboRecordCleanupLookupList != null) {
					withEventsField_cboRecordCleanupLookupList.SelectedIndexChanged += cboRecordCleanupLookupList_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_txtRecordCleanupValue;
		public System.Windows.Forms.TextBox txtRecordCleanupValue {
			get { return withEventsField_txtRecordCleanupValue; }
			set {
				if (withEventsField_txtRecordCleanupValue != null) {
					withEventsField_txtRecordCleanupValue.TextChanged -= txtRecordCleanupValue_TextChanged;
				}
				withEventsField_txtRecordCleanupValue = value;
				if (withEventsField_txtRecordCleanupValue != null) {
					withEventsField_txtRecordCleanupValue.TextChanged += txtRecordCleanupValue_TextChanged;
				}
			}
		}
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.GroupBox Frame5;
		private System.Windows.Forms.ComboBox withEventsField_cboRecordCleanupField;
		public System.Windows.Forms.ComboBox cboRecordCleanupField {
			get { return withEventsField_cboRecordCleanupField; }
			set {
				if (withEventsField_cboRecordCleanupField != null) {
					withEventsField_cboRecordCleanupField.SelectedIndexChanged -= cboRecordCleanupField_SelectedIndexChanged;
				}
				withEventsField_cboRecordCleanupField = value;
				if (withEventsField_cboRecordCleanupField != null) {
					withEventsField_cboRecordCleanupField.SelectedIndexChanged += cboRecordCleanupField_SelectedIndexChanged;
				}
			}
		}
		public System.Windows.Forms.ComboBox cboRecordCleanupOperator;
		private System.Windows.Forms.Button withEventsField_cmdRecordCleanupAdd;
		public System.Windows.Forms.Button cmdRecordCleanupAdd {
			get { return withEventsField_cmdRecordCleanupAdd; }
			set {
				if (withEventsField_cmdRecordCleanupAdd != null) {
					withEventsField_cmdRecordCleanupAdd.Click -= cmdRecordCleanupAdd_Click;
				}
				withEventsField_cmdRecordCleanupAdd = value;
				if (withEventsField_cmdRecordCleanupAdd != null) {
					withEventsField_cmdRecordCleanupAdd.Click += cmdRecordCleanupAdd_Click;
				}
			}
		}
		public System.Windows.Forms.Label Label18;
		public System.Windows.Forms.Label lblJoinOperator;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.GroupBox Frame4;
		private System.Windows.Forms.Button withEventsField_cmdRecordCleanupChangeOrAnd;
		public System.Windows.Forms.Button cmdRecordCleanupChangeOrAnd {
			get { return withEventsField_cmdRecordCleanupChangeOrAnd; }
			set {
				if (withEventsField_cmdRecordCleanupChangeOrAnd != null) {
					withEventsField_cmdRecordCleanupChangeOrAnd.Click -= cmdRecordCleanupChangeOrAnd_Click;
				}
				withEventsField_cmdRecordCleanupChangeOrAnd = value;
				if (withEventsField_cmdRecordCleanupChangeOrAnd != null) {
					withEventsField_cmdRecordCleanupChangeOrAnd.Click += cmdRecordCleanupChangeOrAnd_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdRecordCleanupRemove;
		public System.Windows.Forms.Button cmdRecordCleanupRemove {
			get { return withEventsField_cmdRecordCleanupRemove; }
			set {
				if (withEventsField_cmdRecordCleanupRemove != null) {
					withEventsField_cmdRecordCleanupRemove.Click -= cmdRecordCleanupRemove_Click;
				}
				withEventsField_cmdRecordCleanupRemove = value;
				if (withEventsField_cmdRecordCleanupRemove != null) {
					withEventsField_cmdRecordCleanupRemove.Click += cmdRecordCleanupRemove_Click;
				}
			}
		}
		public System.Windows.Forms.ListBox lstRecordCleanupCriteria;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.TabPage _ssTabSubmission_TabPage3;
		private System.Windows.Forms.TabControl withEventsField_ssTabSubmission;
		public System.Windows.Forms.TabControl ssTabSubmission {
			get { return withEventsField_ssTabSubmission; }
			set {
				if (withEventsField_ssTabSubmission != null) {
					withEventsField_ssTabSubmission.SelectedIndexChanged -= ssTabSubmission_SelectedIndexChanged;
				}
				withEventsField_ssTabSubmission = value;
				if (withEventsField_ssTabSubmission != null) {
					withEventsField_ssTabSubmission.SelectedIndexChanged += ssTabSubmission_SelectedIndexChanged;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcSubmissionFieldList;
		public AxMSRDC.AxMSRDC rdcSumFieldList;
		public AxMSRDC.AxMSRDC rdcIndicatorList;
		public AxMSRDC.AxMSRDC rdcValidationWarnings;
		public AxMSRDC.AxMSRDC rdcValidationErrorCriteria;
		public AxMSRDC.AxMSRDC rdcValidationWarningCriteria;
		public AxMSRDC.AxMSRDC rdcValidationErrors;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmSubmissionSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.ssTabSubmission = new System.Windows.Forms.TabControl();
			this._ssTabSubmission_TabPage0 = new System.Windows.Forms.TabPage();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Frame1 = new System.Windows.Forms.GroupBox();
			this.lstCategorySelectedList = new System.Windows.Forms.ListBox();
			this.cmdRemoveCategory = new System.Windows.Forms.Button();
			this.cmdSelectCategory = new System.Windows.Forms.Button();
			this.lstCategoryLookupList = new System.Windows.Forms.ListBox();
			this.lstSumField = new System.Windows.Forms.ListBox();
			this.cboSumOp = new System.Windows.Forms.ComboBox();
			this.cboIndicator = new System.Windows.Forms.ComboBox();
			this.Label19 = new System.Windows.Forms.Label();
			this.Label17 = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.dbgSubmissionFieldList = new AxMSDBGrid.AxDBGrid();
			this.cmdAddGroup = new System.Windows.Forms.Button();
			this.cmdAddRow = new System.Windows.Forms.Button();
			this.cmdAddCol = new System.Windows.Forms.Button();
			this.chkIncludeGroup = new System.Windows.Forms.CheckBox();
			this.chkDisplayGroupTitle = new System.Windows.Forms.CheckBox();
			this.chkIncludeRow = new System.Windows.Forms.CheckBox();
			this.chkIncludeCol = new System.Windows.Forms.CheckBox();
			this.cmdDelSumCriteria = new System.Windows.Forms.Button();
			this.cmdAddSumCriteria = new System.Windows.Forms.Button();
			this.cmdChangeAndOrCond = new System.Windows.Forms.Button();
			this.cmdCopyCriteria = new System.Windows.Forms.Button();
			this.cmdCopyCriteriaSets = new System.Windows.Forms.Button();
			this.cmdChangeAddOrBetweenSets = new System.Windows.Forms.Button();
			this.cmdDupSummarytoMeas = new System.Windows.Forms.Button();
			this.lstSummaryDef = new System.Windows.Forms.ListBox();
			this.cmdSubmissionPrint = new System.Windows.Forms.Button();
			this._ssTabSubmission_TabPage1 = new System.Windows.Forms.TabPage();
			this.cmdChangeCleanupStatus = new System.Windows.Forms.Button();
			this.Frame3 = new System.Windows.Forms.GroupBox();
			this.txtJoinOperator = new System.Windows.Forms.TextBox();
			this.cmdCleanupAddCrit = new System.Windows.Forms.Button();
			this.cboCleanupOperation = new System.Windows.Forms.ComboBox();
			this.cboCleanUpFieldToAdd = new System.Windows.Forms.ComboBox();
			this.Frame2 = new System.Windows.Forms.GroupBox();
			this.txtTypeinValue = new System.Windows.Forms.TextBox();
			this.cboCleanupValueList = new System.Windows.Forms.ComboBox();
			this.optCleanupValue = new System.Windows.Forms.RadioButton();
			this.optCleanupLookupTable = new System.Windows.Forms.RadioButton();
			this.cboCleanupLookupTables = new System.Windows.Forms.ComboBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.cmdCleanupAnd = new System.Windows.Forms.Button();
			this.cmdCleanupOr = new System.Windows.Forms.Button();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.cmdCleanupCriteria = new System.Windows.Forms.Button();
			this.lstCleanupCriteria = new System.Windows.Forms.ListBox();
			this.lstCleanUpFields = new System.Windows.Forms.ListBox();
			this.cmdDelCleanUpField = new System.Windows.Forms.Button();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this._ssTabSubmission_TabPage2 = new System.Windows.Forms.TabPage();
			this.cmdPrintSummaryVal = new System.Windows.Forms.Button();
			this.sstabValidation = new System.Windows.Forms.TabControl();
			this._sstabValidation_TabPage0 = new System.Windows.Forms.TabPage();
			this.cmdChangeErrorStatus = new System.Windows.Forms.Button();
			this.cmdChangeToWarning = new System.Windows.Forms.Button();
			this.cmdValidErrorAddCritOr = new System.Windows.Forms.Button();
			this.cmdValidErrorAddCritAnd = new System.Windows.Forms.Button();
			this.cmdValidErrorDeleteCrit = new System.Windows.Forms.Button();
			this.cmdValidErrorAddCrit = new System.Windows.Forms.Button();
			this.cmdUpdateError = new System.Windows.Forms.Button();
			this.cmdDelError = new System.Windows.Forms.Button();
			this.cmdAddError = new System.Windows.Forms.Button();
			this.dbgSubmitErrors = new AxMSDBGrid.AxDBGrid();
			this.dbgValidationErrorCriteria = new AxMSDBGrid.AxDBGrid();
			this._sstabValidation_TabPage1 = new System.Windows.Forms.TabPage();
			this.dbgValidationWarningCriteria = new AxMSDBGrid.AxDBGrid();
			this.dbgSubmitWarnings = new AxMSDBGrid.AxDBGrid();
			this.cmdAddWarning = new System.Windows.Forms.Button();
			this.cmdDeleteWarning = new System.Windows.Forms.Button();
			this.cmdUpdateWarning = new System.Windows.Forms.Button();
			this.cmdValidWarningAddCrit = new System.Windows.Forms.Button();
			this.cmdValidWarningDeleteCrit = new System.Windows.Forms.Button();
			this.cmdValidWarningAddCritAnd = new System.Windows.Forms.Button();
			this.cmdValidWarningAddCritOr = new System.Windows.Forms.Button();
			this.cmdChangeToError = new System.Windows.Forms.Button();
			this.cmdChangeWarningStatus = new System.Windows.Forms.Button();
			this._ssTabSubmission_TabPage3 = new System.Windows.Forms.TabPage();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.Frame4 = new System.Windows.Forms.GroupBox();
			this.cboRecordCleanupSet = new System.Windows.Forms.ComboBox();
			this.cboRecordCleanupJoinOperator = new System.Windows.Forms.ComboBox();
			this.Frame5 = new System.Windows.Forms.GroupBox();
			this.chkRecordCleanupBlank = new System.Windows.Forms.CheckBox();
			this.cboRecordCleanupLookupList = new System.Windows.Forms.ComboBox();
			this.txtRecordCleanupValue = new System.Windows.Forms.TextBox();
			this.Label13 = new System.Windows.Forms.Label();
			this.cboRecordCleanupField = new System.Windows.Forms.ComboBox();
			this.cboRecordCleanupOperator = new System.Windows.Forms.ComboBox();
			this.cmdRecordCleanupAdd = new System.Windows.Forms.Button();
			this.Label18 = new System.Windows.Forms.Label();
			this.lblJoinOperator = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this.cmdRecordCleanupChangeOrAnd = new System.Windows.Forms.Button();
			this.cmdRecordCleanupRemove = new System.Windows.Forms.Button();
			this.lstRecordCleanupCriteria = new System.Windows.Forms.ListBox();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.rdcSubmissionFieldList = new AxMSRDC.AxMSRDC();
			this.rdcSumFieldList = new AxMSRDC.AxMSRDC();
			this.rdcIndicatorList = new AxMSRDC.AxMSRDC();
			this.rdcValidationWarnings = new AxMSRDC.AxMSRDC();
			this.rdcValidationErrorCriteria = new AxMSRDC.AxMSRDC();
			this.rdcValidationWarningCriteria = new AxMSRDC.AxMSRDC();
			this.rdcValidationErrors = new AxMSRDC.AxMSRDC();
			this.ssTabSubmission.SuspendLayout();
			this._ssTabSubmission_TabPage0.SuspendLayout();
			this.Frame1.SuspendLayout();
			this._ssTabSubmission_TabPage1.SuspendLayout();
			this.Frame3.SuspendLayout();
			this.Frame2.SuspendLayout();
			this._ssTabSubmission_TabPage2.SuspendLayout();
			this.sstabValidation.SuspendLayout();
			this._sstabValidation_TabPage0.SuspendLayout();
			this._sstabValidation_TabPage1.SuspendLayout();
			this._ssTabSubmission_TabPage3.SuspendLayout();
			this.Frame4.SuspendLayout();
			this.Frame5.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgSubmissionFieldList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitErrors).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationErrorCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationWarningCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitWarnings).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcSubmissionFieldList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcSumFieldList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcIndicatorList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarnings).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrorCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarningCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrors).BeginInit();
			this.Text = "Data Submission Setup";
			this.ClientSize = new System.Drawing.Size(830, 609);
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
			this.Name = "frmSubmissionSetup";
			this.ssTabSubmission.Size = new System.Drawing.Size(812, 592);
			this.ssTabSubmission.Location = new System.Drawing.Point(10, 3);
			this.ssTabSubmission.TabIndex = 0;
			this.ssTabSubmission.ItemSize = new System.Drawing.Size(42, 22);
			this.ssTabSubmission.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.ssTabSubmission.Name = "ssTabSubmission";
			this._ssTabSubmission_TabPage0.Text = "Submission Setup";
			this.Label4.Text = "Summarization Criteria";
			this.Label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label4.ForeColor = System.Drawing.Color.Blue;
			this.Label4.Size = new System.Drawing.Size(268, 22);
			this.Label4.Location = new System.Drawing.Point(25, 335);
			this.Label4.TabIndex = 8;
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
			this.Label8.Text = "Warning: If you don't define any criteria for a column, the value will be calculated regardless of any conditions, for the records that their discharge date falls within the selected period.";
			this.Label8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label8.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label8.Size = new System.Drawing.Size(769, 38);
			this.Label8.Location = new System.Drawing.Point(23, 549);
			this.Label8.TabIndex = 83;
			this.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label8.BackColor = System.Drawing.SystemColors.Control;
			this.Label8.Enabled = true;
			this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label8.UseMnemonic = true;
			this.Label8.Visible = true;
			this.Label8.AutoSize = false;
			this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label8.Name = "Label8";
			this.Frame1.Text = "Column Specs";
			this.Frame1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame1.ForeColor = System.Drawing.Color.Blue;
			this.Frame1.Size = new System.Drawing.Size(524, 178);
			this.Frame1.Location = new System.Drawing.Point(259, 173);
			this.Frame1.TabIndex = 9;
			this.Frame1.BackColor = System.Drawing.SystemColors.Control;
			this.Frame1.Enabled = true;
			this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame1.Visible = true;
			this.Frame1.Padding = new System.Windows.Forms.Padding(0);
			this.Frame1.Name = "Frame1";
			this.lstCategorySelectedList.Size = new System.Drawing.Size(97, 42);
			this.lstCategorySelectedList.Location = new System.Drawing.Point(399, 132);
			this.lstCategorySelectedList.TabIndex = 99;
			this.lstCategorySelectedList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstCategorySelectedList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstCategorySelectedList.BackColor = System.Drawing.SystemColors.Window;
			this.lstCategorySelectedList.CausesValidation = true;
			this.lstCategorySelectedList.Enabled = true;
			this.lstCategorySelectedList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstCategorySelectedList.IntegralHeight = true;
			this.lstCategorySelectedList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstCategorySelectedList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstCategorySelectedList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstCategorySelectedList.Sorted = false;
			this.lstCategorySelectedList.TabStop = true;
			this.lstCategorySelectedList.Visible = true;
			this.lstCategorySelectedList.MultiColumn = false;
			this.lstCategorySelectedList.Name = "lstCategorySelectedList";
			this.cmdRemoveCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRemoveCategory.Text = "<<==";
			this.cmdRemoveCategory.Size = new System.Drawing.Size(47, 20);
			this.cmdRemoveCategory.Location = new System.Drawing.Point(343, 152);
			this.cmdRemoveCategory.TabIndex = 98;
			this.cmdRemoveCategory.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRemoveCategory.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRemoveCategory.CausesValidation = true;
			this.cmdRemoveCategory.Enabled = true;
			this.cmdRemoveCategory.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRemoveCategory.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRemoveCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRemoveCategory.TabStop = true;
			this.cmdRemoveCategory.Name = "cmdRemoveCategory";
			this.cmdSelectCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSelectCategory.Text = "==>>";
			this.cmdSelectCategory.Size = new System.Drawing.Size(47, 20);
			this.cmdSelectCategory.Location = new System.Drawing.Point(343, 129);
			this.cmdSelectCategory.TabIndex = 97;
			this.cmdSelectCategory.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSelectCategory.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSelectCategory.CausesValidation = true;
			this.cmdSelectCategory.Enabled = true;
			this.cmdSelectCategory.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSelectCategory.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSelectCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSelectCategory.TabStop = true;
			this.cmdSelectCategory.Name = "cmdSelectCategory";
			this.lstCategoryLookupList.Size = new System.Drawing.Size(89, 42);
			this.lstCategoryLookupList.Location = new System.Drawing.Point(247, 132);
			this.lstCategoryLookupList.TabIndex = 96;
			this.lstCategoryLookupList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstCategoryLookupList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstCategoryLookupList.BackColor = System.Drawing.SystemColors.Window;
			this.lstCategoryLookupList.CausesValidation = true;
			this.lstCategoryLookupList.Enabled = true;
			this.lstCategoryLookupList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstCategoryLookupList.IntegralHeight = true;
			this.lstCategoryLookupList.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstCategoryLookupList.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstCategoryLookupList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstCategoryLookupList.Sorted = false;
			this.lstCategoryLookupList.TabStop = true;
			this.lstCategoryLookupList.Visible = true;
			this.lstCategoryLookupList.MultiColumn = false;
			this.lstCategoryLookupList.Name = "lstCategoryLookupList";
			this.lstSumField.Size = new System.Drawing.Size(299, 42);
			this.lstSumField.Location = new System.Drawing.Point(212, 73);
			this.lstSumField.TabIndex = 58;
			this.lstSumField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstSumField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstSumField.BackColor = System.Drawing.SystemColors.Window;
			this.lstSumField.CausesValidation = true;
			this.lstSumField.Enabled = true;
			this.lstSumField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstSumField.IntegralHeight = true;
			this.lstSumField.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstSumField.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstSumField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstSumField.Sorted = false;
			this.lstSumField.TabStop = true;
			this.lstSumField.Visible = true;
			this.lstSumField.MultiColumn = false;
			this.lstSumField.Name = "lstSumField";
			this.cboSumOp.Enabled = false;
			this.cboSumOp.Size = new System.Drawing.Size(264, 27);
			this.cboSumOp.Location = new System.Drawing.Point(210, 44);
			this.cboSumOp.Items.AddRange(new object[] {
				"Count",
				"Sum"
			});
			this.cboSumOp.TabIndex = 11;
			this.cboSumOp.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboSumOp.BackColor = System.Drawing.SystemColors.Window;
			this.cboSumOp.CausesValidation = true;
			this.cboSumOp.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboSumOp.IntegralHeight = true;
			this.cboSumOp.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSumOp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboSumOp.Sorted = false;
			this.cboSumOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboSumOp.TabStop = true;
			this.cboSumOp.Visible = true;
			this.cboSumOp.Name = "cboSumOp";
			this.cboIndicator.Enabled = false;
			this.cboIndicator.Size = new System.Drawing.Size(304, 27);
			this.cboIndicator.Location = new System.Drawing.Point(210, 15);
			this.cboIndicator.TabIndex = 10;
			this.cboIndicator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboIndicator.BackColor = System.Drawing.SystemColors.Window;
			this.cboIndicator.CausesValidation = true;
			this.cboIndicator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboIndicator.IntegralHeight = true;
			this.cboIndicator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboIndicator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboIndicator.Sorted = false;
			this.cboIndicator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboIndicator.TabStop = true;
			this.cboIndicator.Visible = true;
			this.cboIndicator.Name = "cboIndicator";
			this.Label19.Text = "Lookup List";
			this.Label19.Size = new System.Drawing.Size(90, 18);
			this.Label19.Location = new System.Drawing.Point(254, 114);
			this.Label19.TabIndex = 95;
			this.Label19.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label19.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label19.BackColor = System.Drawing.SystemColors.Control;
			this.Label19.Enabled = true;
			this.Label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label19.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label19.UseMnemonic = true;
			this.Label19.Visible = true;
			this.Label19.AutoSize = false;
			this.Label19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label19.Name = "Label19";
			this.Label17.Text = "Selected List";
			this.Label17.Size = new System.Drawing.Size(109, 15);
			this.Label17.Location = new System.Drawing.Point(403, 115);
			this.Label17.TabIndex = 94;
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
			this.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label16.Text = "Verification Category:";
			this.Label16.Size = new System.Drawing.Size(129, 22);
			this.Label16.Location = new System.Drawing.Point(80, 108);
			this.Label16.TabIndex = 85;
			this.Label16.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
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
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label3.Text = "Summarized Field(s)";
			this.Label3.Size = new System.Drawing.Size(118, 22);
			this.Label3.Location = new System.Drawing.Point(83, 75);
			this.Label3.TabIndex = 14;
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
			this.Label2.Text = "Summary Operation";
			this.Label2.Size = new System.Drawing.Size(117, 20);
			this.Label2.Location = new System.Drawing.Point(82, 49);
			this.Label2.TabIndex = 13;
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
			this.Label1.Text = "Indicator:";
			this.Label1.Size = new System.Drawing.Size(62, 22);
			this.Label1.Location = new System.Drawing.Point(134, 18);
			this.Label1.TabIndex = 12;
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
			dbgSubmissionFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgSubmissionFieldList.OcxState");
			this.dbgSubmissionFieldList.Size = new System.Drawing.Size(660, 130);
			this.dbgSubmissionFieldList.Location = new System.Drawing.Point(24, 42);
			this.dbgSubmissionFieldList.TabIndex = 1;
			this.dbgSubmissionFieldList.Name = "dbgSubmissionFieldList";
			this.cmdAddGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddGroup.Text = "Update Group List";
			this.cmdAddGroup.Size = new System.Drawing.Size(112, 42);
			this.cmdAddGroup.Location = new System.Drawing.Point(692, 39);
			this.cmdAddGroup.TabIndex = 2;
			this.cmdAddGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddGroup.CausesValidation = true;
			this.cmdAddGroup.Enabled = true;
			this.cmdAddGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddGroup.TabStop = true;
			this.cmdAddGroup.Name = "cmdAddGroup";
			this.cmdAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddRow.Text = "Update Row List";
			this.cmdAddRow.Size = new System.Drawing.Size(112, 39);
			this.cmdAddRow.Location = new System.Drawing.Point(692, 85);
			this.cmdAddRow.TabIndex = 3;
			this.cmdAddRow.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddRow.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddRow.CausesValidation = true;
			this.cmdAddRow.Enabled = true;
			this.cmdAddRow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddRow.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddRow.TabStop = true;
			this.cmdAddRow.Name = "cmdAddRow";
			this.cmdAddCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddCol.Text = "Update Col. List";
			this.cmdAddCol.Size = new System.Drawing.Size(112, 35);
			this.cmdAddCol.Location = new System.Drawing.Point(692, 127);
			this.cmdAddCol.TabIndex = 4;
			this.cmdAddCol.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddCol.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddCol.CausesValidation = true;
			this.cmdAddCol.Enabled = true;
			this.cmdAddCol.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddCol.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddCol.TabStop = true;
			this.cmdAddCol.Name = "cmdAddCol";
			this.chkIncludeGroup.Text = "Include Group on the report";
			this.chkIncludeGroup.Enabled = false;
			this.chkIncludeGroup.Size = new System.Drawing.Size(202, 22);
			this.chkIncludeGroup.Location = new System.Drawing.Point(25, 185);
			this.chkIncludeGroup.TabIndex = 5;
			this.chkIncludeGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeGroup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeGroup.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeGroup.CausesValidation = true;
			this.chkIncludeGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeGroup.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeGroup.TabStop = true;
			this.chkIncludeGroup.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeGroup.Visible = true;
			this.chkIncludeGroup.Name = "chkIncludeGroup";
			this.chkDisplayGroupTitle.Text = "Display Group Title on the Report";
			this.chkDisplayGroupTitle.Enabled = false;
			this.chkDisplayGroupTitle.Size = new System.Drawing.Size(222, 22);
			this.chkDisplayGroupTitle.Location = new System.Drawing.Point(25, 209);
			this.chkDisplayGroupTitle.TabIndex = 6;
			this.chkDisplayGroupTitle.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkDisplayGroupTitle.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkDisplayGroupTitle.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkDisplayGroupTitle.BackColor = System.Drawing.SystemColors.Control;
			this.chkDisplayGroupTitle.CausesValidation = true;
			this.chkDisplayGroupTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkDisplayGroupTitle.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkDisplayGroupTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkDisplayGroupTitle.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkDisplayGroupTitle.TabStop = true;
			this.chkDisplayGroupTitle.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkDisplayGroupTitle.Visible = true;
			this.chkDisplayGroupTitle.Name = "chkDisplayGroupTitle";
			this.chkIncludeRow.Text = "Include Row on the Report";
			this.chkIncludeRow.Enabled = false;
			this.chkIncludeRow.Size = new System.Drawing.Size(202, 23);
			this.chkIncludeRow.Location = new System.Drawing.Point(25, 230);
			this.chkIncludeRow.TabIndex = 7;
			this.chkIncludeRow.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeRow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeRow.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeRow.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeRow.CausesValidation = true;
			this.chkIncludeRow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeRow.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeRow.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeRow.TabStop = true;
			this.chkIncludeRow.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeRow.Visible = true;
			this.chkIncludeRow.Name = "chkIncludeRow";
			this.chkIncludeCol.Text = "Include Column on the Report";
			this.chkIncludeCol.Enabled = false;
			this.chkIncludeCol.Size = new System.Drawing.Size(202, 23);
			this.chkIncludeCol.Location = new System.Drawing.Point(25, 252);
			this.chkIncludeCol.TabIndex = 59;
			this.chkIncludeCol.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkIncludeCol.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIncludeCol.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkIncludeCol.BackColor = System.Drawing.SystemColors.Control;
			this.chkIncludeCol.CausesValidation = true;
			this.chkIncludeCol.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkIncludeCol.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkIncludeCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkIncludeCol.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkIncludeCol.TabStop = true;
			this.chkIncludeCol.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkIncludeCol.Visible = true;
			this.chkIncludeCol.Name = "chkIncludeCol";
			this.cmdDelSumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelSumCriteria.Text = "Delete Criteria";
			this.cmdDelSumCriteria.Size = new System.Drawing.Size(112, 22);
			this.cmdDelSumCriteria.Location = new System.Drawing.Point(24, 523);
			this.cmdDelSumCriteria.TabIndex = 86;
			this.cmdDelSumCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelSumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelSumCriteria.CausesValidation = true;
			this.cmdDelSumCriteria.Enabled = true;
			this.cmdDelSumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelSumCriteria.TabStop = true;
			this.cmdDelSumCriteria.Name = "cmdDelSumCriteria";
			this.cmdAddSumCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddSumCriteria.Text = "Add Criteria";
			this.cmdAddSumCriteria.Size = new System.Drawing.Size(112, 24);
			this.cmdAddSumCriteria.Location = new System.Drawing.Point(24, 495);
			this.cmdAddSumCriteria.TabIndex = 87;
			this.cmdAddSumCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdAddSumCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAddSumCriteria.CausesValidation = true;
			this.cmdAddSumCriteria.Enabled = true;
			this.cmdAddSumCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAddSumCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAddSumCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAddSumCriteria.TabStop = true;
			this.cmdAddSumCriteria.Name = "cmdAddSumCriteria";
			this.cmdChangeAndOrCond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeAndOrCond.Text = "Change And/Or of the Criteria Set";
			this.cmdChangeAndOrCond.Size = new System.Drawing.Size(242, 22);
			this.cmdChangeAndOrCond.Location = new System.Drawing.Point(352, 522);
			this.cmdChangeAndOrCond.TabIndex = 88;
			this.cmdChangeAndOrCond.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeAndOrCond.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeAndOrCond.CausesValidation = true;
			this.cmdChangeAndOrCond.Enabled = true;
			this.cmdChangeAndOrCond.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeAndOrCond.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeAndOrCond.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeAndOrCond.TabStop = true;
			this.cmdChangeAndOrCond.Name = "cmdChangeAndOrCond";
			this.cmdCopyCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopyCriteria.Text = "Copy Criteria to another col.";
			this.cmdCopyCriteria.Size = new System.Drawing.Size(200, 23);
			this.cmdCopyCriteria.Location = new System.Drawing.Point(143, 495);
			this.cmdCopyCriteria.TabIndex = 89;
			this.cmdCopyCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopyCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopyCriteria.CausesValidation = true;
			this.cmdCopyCriteria.Enabled = true;
			this.cmdCopyCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopyCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopyCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopyCriteria.TabStop = true;
			this.cmdCopyCriteria.Name = "cmdCopyCriteria";
			this.cmdCopyCriteriaSets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCopyCriteriaSets.Text = "Duplicate Criteria Set";
			this.cmdCopyCriteriaSets.Size = new System.Drawing.Size(200, 23);
			this.cmdCopyCriteriaSets.Location = new System.Drawing.Point(143, 520);
			this.cmdCopyCriteriaSets.TabIndex = 90;
			this.cmdCopyCriteriaSets.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCopyCriteriaSets.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCopyCriteriaSets.CausesValidation = true;
			this.cmdCopyCriteriaSets.Enabled = true;
			this.cmdCopyCriteriaSets.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCopyCriteriaSets.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCopyCriteriaSets.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCopyCriteriaSets.TabStop = true;
			this.cmdCopyCriteriaSets.Name = "cmdCopyCriteriaSets";
			this.cmdChangeAddOrBetweenSets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeAddOrBetweenSets.Text = "Change And/Or Between All the Sets";
			this.cmdChangeAddOrBetweenSets.Size = new System.Drawing.Size(242, 24);
			this.cmdChangeAddOrBetweenSets.Location = new System.Drawing.Point(352, 495);
			this.cmdChangeAddOrBetweenSets.TabIndex = 91;
			this.cmdChangeAddOrBetweenSets.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeAddOrBetweenSets.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeAddOrBetweenSets.CausesValidation = true;
			this.cmdChangeAddOrBetweenSets.Enabled = true;
			this.cmdChangeAddOrBetweenSets.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeAddOrBetweenSets.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeAddOrBetweenSets.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeAddOrBetweenSets.TabStop = true;
			this.cmdChangeAddOrBetweenSets.Name = "cmdChangeAddOrBetweenSets";
			this.cmdDupSummarytoMeas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDupSummarytoMeas.Text = "Copy Summary to Measure";
			this.cmdDupSummarytoMeas.Size = new System.Drawing.Size(195, 24);
			this.cmdDupSummarytoMeas.Location = new System.Drawing.Point(599, 495);
			this.cmdDupSummarytoMeas.TabIndex = 92;
			this.cmdDupSummarytoMeas.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDupSummarytoMeas.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDupSummarytoMeas.CausesValidation = true;
			this.cmdDupSummarytoMeas.Enabled = true;
			this.cmdDupSummarytoMeas.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDupSummarytoMeas.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDupSummarytoMeas.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDupSummarytoMeas.TabStop = true;
			this.cmdDupSummarytoMeas.Name = "cmdDupSummarytoMeas";
			this.lstSummaryDef.Size = new System.Drawing.Size(758, 139);
			this.lstSummaryDef.Location = new System.Drawing.Point(25, 354);
			this.lstSummaryDef.TabIndex = 93;
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
			this.cmdSubmissionPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSubmissionPrint.Text = "PRINT";
			this.cmdSubmissionPrint.Size = new System.Drawing.Size(112, 24);
			this.cmdSubmissionPrint.Location = new System.Drawing.Point(660, 530);
			this.cmdSubmissionPrint.TabIndex = 101;
			this.cmdSubmissionPrint.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSubmissionPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubmissionPrint.CausesValidation = true;
			this.cmdSubmissionPrint.Enabled = true;
			this.cmdSubmissionPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubmissionPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSubmissionPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubmissionPrint.TabStop = true;
			this.cmdSubmissionPrint.Name = "cmdSubmissionPrint";
			this._ssTabSubmission_TabPage1.Text = "Data Cleanup Setup";
			this.cmdChangeCleanupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeCleanupStatus.Text = "Change Status";
			this.cmdChangeCleanupStatus.Size = new System.Drawing.Size(164, 25);
			this.cmdChangeCleanupStatus.Location = new System.Drawing.Point(604, 100);
			this.cmdChangeCleanupStatus.TabIndex = 60;
			this.cmdChangeCleanupStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeCleanupStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeCleanupStatus.CausesValidation = true;
			this.cmdChangeCleanupStatus.Enabled = true;
			this.cmdChangeCleanupStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeCleanupStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeCleanupStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeCleanupStatus.TabStop = true;
			this.cmdChangeCleanupStatus.Name = "cmdChangeCleanupStatus";
			this.Frame3.Text = "Add Field / Criteria";
			this.Frame3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame3.ForeColor = System.Drawing.Color.Blue;
			this.Frame3.Size = new System.Drawing.Size(748, 134);
			this.Frame3.Location = new System.Drawing.Point(30, 319);
			this.Frame3.TabIndex = 28;
			this.Frame3.BackColor = System.Drawing.SystemColors.Control;
			this.Frame3.Enabled = true;
			this.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame3.Visible = true;
			this.Frame3.Padding = new System.Windows.Forms.Padding(0);
			this.Frame3.Name = "Frame3";
			this.txtJoinOperator.AutoSize = false;
			this.txtJoinOperator.Size = new System.Drawing.Size(54, 24);
			this.txtJoinOperator.Location = new System.Drawing.Point(494, 97);
			this.txtJoinOperator.TabIndex = 34;
			this.txtJoinOperator.Visible = false;
			this.txtJoinOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtJoinOperator.AcceptsReturn = true;
			this.txtJoinOperator.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtJoinOperator.BackColor = System.Drawing.SystemColors.Window;
			this.txtJoinOperator.CausesValidation = true;
			this.txtJoinOperator.Enabled = true;
			this.txtJoinOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtJoinOperator.HideSelection = true;
			this.txtJoinOperator.ReadOnly = false;
			this.txtJoinOperator.MaxLength = 0;
			this.txtJoinOperator.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtJoinOperator.Multiline = false;
			this.txtJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtJoinOperator.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtJoinOperator.TabStop = true;
			this.txtJoinOperator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtJoinOperator.Name = "txtJoinOperator";
			this.cmdCleanupAddCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCleanupAddCrit.Text = "Add";
			this.cmdCleanupAddCrit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCleanupAddCrit.Size = new System.Drawing.Size(85, 25);
			this.cmdCleanupAddCrit.Location = new System.Drawing.Point(652, 95);
			this.cmdCleanupAddCrit.TabIndex = 25;
			this.cmdCleanupAddCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCleanupAddCrit.CausesValidation = true;
			this.cmdCleanupAddCrit.Enabled = true;
			this.cmdCleanupAddCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCleanupAddCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCleanupAddCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCleanupAddCrit.TabStop = true;
			this.cmdCleanupAddCrit.Name = "cmdCleanupAddCrit";
			this.cboCleanupOperation.Size = new System.Drawing.Size(50, 27);
			this.cboCleanupOperation.Location = new System.Drawing.Point(294, 33);
			this.cboCleanupOperation.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboCleanupOperation.TabIndex = 20;
			this.cboCleanupOperation.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCleanupOperation.BackColor = System.Drawing.SystemColors.Window;
			this.cboCleanupOperation.CausesValidation = true;
			this.cboCleanupOperation.Enabled = true;
			this.cboCleanupOperation.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCleanupOperation.IntegralHeight = true;
			this.cboCleanupOperation.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCleanupOperation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCleanupOperation.Sorted = false;
			this.cboCleanupOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCleanupOperation.TabStop = true;
			this.cboCleanupOperation.Visible = true;
			this.cboCleanupOperation.Name = "cboCleanupOperation";
			this.cboCleanUpFieldToAdd.Size = new System.Drawing.Size(275, 27);
			this.cboCleanUpFieldToAdd.Location = new System.Drawing.Point(12, 34);
			this.cboCleanUpFieldToAdd.TabIndex = 19;
			this.cboCleanUpFieldToAdd.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCleanUpFieldToAdd.BackColor = System.Drawing.SystemColors.Window;
			this.cboCleanUpFieldToAdd.CausesValidation = true;
			this.cboCleanUpFieldToAdd.Enabled = true;
			this.cboCleanUpFieldToAdd.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCleanUpFieldToAdd.IntegralHeight = true;
			this.cboCleanUpFieldToAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCleanUpFieldToAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCleanUpFieldToAdd.Sorted = false;
			this.cboCleanUpFieldToAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCleanUpFieldToAdd.TabStop = true;
			this.cboCleanUpFieldToAdd.Visible = true;
			this.cboCleanUpFieldToAdd.Name = "cboCleanUpFieldToAdd";
			this.Frame2.Text = "Result";
			this.Frame2.ForeColor = System.Drawing.Color.Black;
			this.Frame2.Size = new System.Drawing.Size(385, 80);
			this.Frame2.Location = new System.Drawing.Point(353, 10);
			this.Frame2.TabIndex = 29;
			this.Frame2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame2.BackColor = System.Drawing.SystemColors.Control;
			this.Frame2.Enabled = true;
			this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame2.Visible = true;
			this.Frame2.Padding = new System.Windows.Forms.Padding(0);
			this.Frame2.Name = "Frame2";
			this.txtTypeinValue.AutoSize = false;
			this.txtTypeinValue.Size = new System.Drawing.Size(105, 25);
			this.txtTypeinValue.Location = new System.Drawing.Point(265, 15);
			this.txtTypeinValue.TabIndex = 54;
			this.txtTypeinValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtTypeinValue.AcceptsReturn = true;
			this.txtTypeinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtTypeinValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtTypeinValue.CausesValidation = true;
			this.txtTypeinValue.Enabled = true;
			this.txtTypeinValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTypeinValue.HideSelection = true;
			this.txtTypeinValue.ReadOnly = false;
			this.txtTypeinValue.MaxLength = 0;
			this.txtTypeinValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTypeinValue.Multiline = false;
			this.txtTypeinValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtTypeinValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTypeinValue.TabStop = true;
			this.txtTypeinValue.Visible = true;
			this.txtTypeinValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtTypeinValue.Name = "txtTypeinValue";
			this.cboCleanupValueList.Size = new System.Drawing.Size(109, 27);
			this.cboCleanupValueList.Location = new System.Drawing.Point(130, 15);
			this.cboCleanupValueList.Items.AddRange(new object[] {
				"Y (Yes)",
				"N (No)"
			});
			this.cboCleanupValueList.TabIndex = 21;
			this.cboCleanupValueList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCleanupValueList.BackColor = System.Drawing.SystemColors.Window;
			this.cboCleanupValueList.CausesValidation = true;
			this.cboCleanupValueList.Enabled = true;
			this.cboCleanupValueList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCleanupValueList.IntegralHeight = true;
			this.cboCleanupValueList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCleanupValueList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCleanupValueList.Sorted = false;
			this.cboCleanupValueList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCleanupValueList.TabStop = true;
			this.cboCleanupValueList.Visible = true;
			this.cboCleanupValueList.Name = "cboCleanupValueList";
			this.optCleanupValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optCleanupValue.Text = "A value";
			this.optCleanupValue.Size = new System.Drawing.Size(127, 23);
			this.optCleanupValue.Location = new System.Drawing.Point(9, 17);
			this.optCleanupValue.TabIndex = 31;
			this.optCleanupValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optCleanupValue.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optCleanupValue.BackColor = System.Drawing.SystemColors.Control;
			this.optCleanupValue.CausesValidation = true;
			this.optCleanupValue.Enabled = true;
			this.optCleanupValue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optCleanupValue.Cursor = System.Windows.Forms.Cursors.Default;
			this.optCleanupValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optCleanupValue.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optCleanupValue.TabStop = true;
			this.optCleanupValue.Checked = false;
			this.optCleanupValue.Visible = true;
			this.optCleanupValue.Name = "optCleanupValue";
			this.optCleanupLookupTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optCleanupLookupTable.Text = "Lookup Table";
			this.optCleanupLookupTable.Size = new System.Drawing.Size(118, 23);
			this.optCleanupLookupTable.Location = new System.Drawing.Point(9, 43);
			this.optCleanupLookupTable.TabIndex = 30;
			this.optCleanupLookupTable.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.optCleanupLookupTable.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.optCleanupLookupTable.BackColor = System.Drawing.SystemColors.Control;
			this.optCleanupLookupTable.CausesValidation = true;
			this.optCleanupLookupTable.Enabled = true;
			this.optCleanupLookupTable.ForeColor = System.Drawing.SystemColors.ControlText;
			this.optCleanupLookupTable.Cursor = System.Windows.Forms.Cursors.Default;
			this.optCleanupLookupTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.optCleanupLookupTable.Appearance = System.Windows.Forms.Appearance.Normal;
			this.optCleanupLookupTable.TabStop = true;
			this.optCleanupLookupTable.Checked = false;
			this.optCleanupLookupTable.Visible = true;
			this.optCleanupLookupTable.Name = "optCleanupLookupTable";
			this.cboCleanupLookupTables.Size = new System.Drawing.Size(242, 27);
			this.cboCleanupLookupTables.Location = new System.Drawing.Point(132, 48);
			this.cboCleanupLookupTables.TabIndex = 22;
			this.cboCleanupLookupTables.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboCleanupLookupTables.BackColor = System.Drawing.SystemColors.Window;
			this.cboCleanupLookupTables.CausesValidation = true;
			this.cboCleanupLookupTables.Enabled = true;
			this.cboCleanupLookupTables.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboCleanupLookupTables.IntegralHeight = true;
			this.cboCleanupLookupTables.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboCleanupLookupTables.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboCleanupLookupTables.Sorted = false;
			this.cboCleanupLookupTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboCleanupLookupTables.TabStop = true;
			this.cboCleanupLookupTables.Visible = true;
			this.cboCleanupLookupTables.Name = "cboCleanupLookupTables";
			this.Label7.Text = "Or";
			this.Label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label7.Size = new System.Drawing.Size(28, 23);
			this.Label7.Location = new System.Drawing.Point(240, 22);
			this.Label7.TabIndex = 55;
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
			this.cmdCleanupAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCleanupAnd.Text = "And";
			this.cmdCleanupAnd.Enabled = false;
			this.cmdCleanupAnd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCleanupAnd.Size = new System.Drawing.Size(42, 25);
			this.cmdCleanupAnd.Location = new System.Drawing.Point(573, 95);
			this.cmdCleanupAnd.Image = (System.Drawing.Image)resources.GetObject("cmdCleanupAnd.Image");
			this.cmdCleanupAnd.TabIndex = 23;
			this.cmdCleanupAnd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCleanupAnd.CausesValidation = true;
			this.cmdCleanupAnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCleanupAnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCleanupAnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCleanupAnd.TabStop = true;
			this.cmdCleanupAnd.Name = "cmdCleanupAnd";
			this.cmdCleanupOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCleanupOr.Text = "Or";
			this.cmdCleanupOr.Enabled = false;
			this.cmdCleanupOr.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCleanupOr.Size = new System.Drawing.Size(30, 25);
			this.cmdCleanupOr.Location = new System.Drawing.Point(618, 95);
			this.cmdCleanupOr.Image = (System.Drawing.Image)resources.GetObject("cmdCleanupOr.Image");
			this.cmdCleanupOr.TabIndex = 24;
			this.cmdCleanupOr.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCleanupOr.CausesValidation = true;
			this.cmdCleanupOr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCleanupOr.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCleanupOr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCleanupOr.TabStop = true;
			this.cmdCleanupOr.Name = "cmdCleanupOr";
			this.Label11.Text = "Op.";
			this.Label11.ForeColor = System.Drawing.Color.Black;
			this.Label11.Size = new System.Drawing.Size(44, 17);
			this.Label11.Location = new System.Drawing.Point(295, 15);
			this.Label11.TabIndex = 33;
			this.Label11.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label11.BackColor = System.Drawing.SystemColors.Control;
			this.Label11.Enabled = true;
			this.Label11.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label11.UseMnemonic = true;
			this.Label11.Visible = true;
			this.Label11.AutoSize = false;
			this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label11.Name = "Label11";
			this.Label9.Text = "Field";
			this.Label9.ForeColor = System.Drawing.Color.Black;
			this.Label9.Size = new System.Drawing.Size(62, 17);
			this.Label9.Location = new System.Drawing.Point(10, 18);
			this.Label9.TabIndex = 32;
			this.Label9.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label9.BackColor = System.Drawing.SystemColors.Control;
			this.Label9.Enabled = true;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.UseMnemonic = true;
			this.Label9.Visible = true;
			this.Label9.AutoSize = false;
			this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label9.Name = "Label9";
			this.cmdCleanupCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCleanupCriteria.Text = "Delete Criteria";
			this.cmdCleanupCriteria.Size = new System.Drawing.Size(112, 23);
			this.cmdCleanupCriteria.Location = new System.Drawing.Point(652, 173);
			this.cmdCleanupCriteria.TabIndex = 27;
			this.cmdCleanupCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdCleanupCriteria.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCleanupCriteria.CausesValidation = true;
			this.cmdCleanupCriteria.Enabled = true;
			this.cmdCleanupCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCleanupCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCleanupCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCleanupCriteria.TabStop = true;
			this.cmdCleanupCriteria.Name = "cmdCleanupCriteria";
			this.lstCleanupCriteria.Size = new System.Drawing.Size(730, 107);
			this.lstCleanupCriteria.Location = new System.Drawing.Point(35, 202);
			this.lstCleanupCriteria.TabIndex = 18;
			this.lstCleanupCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstCleanupCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstCleanupCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstCleanupCriteria.CausesValidation = true;
			this.lstCleanupCriteria.Enabled = true;
			this.lstCleanupCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstCleanupCriteria.IntegralHeight = true;
			this.lstCleanupCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstCleanupCriteria.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstCleanupCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstCleanupCriteria.Sorted = false;
			this.lstCleanupCriteria.TabStop = true;
			this.lstCleanupCriteria.Visible = true;
			this.lstCleanupCriteria.MultiColumn = false;
			this.lstCleanupCriteria.Name = "lstCleanupCriteria";
			this.lstCleanUpFields.Size = new System.Drawing.Size(364, 123);
			this.lstCleanUpFields.Location = new System.Drawing.Point(234, 74);
			this.lstCleanUpFields.TabIndex = 17;
			this.lstCleanUpFields.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstCleanUpFields.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstCleanUpFields.BackColor = System.Drawing.SystemColors.Window;
			this.lstCleanUpFields.CausesValidation = true;
			this.lstCleanUpFields.Enabled = true;
			this.lstCleanUpFields.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstCleanUpFields.IntegralHeight = true;
			this.lstCleanUpFields.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstCleanUpFields.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstCleanUpFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstCleanUpFields.Sorted = false;
			this.lstCleanUpFields.TabStop = true;
			this.lstCleanUpFields.Visible = true;
			this.lstCleanUpFields.MultiColumn = false;
			this.lstCleanUpFields.Name = "lstCleanUpFields";
			this.cmdDelCleanUpField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDelCleanUpField.Text = "Delete Field";
			this.cmdDelCleanUpField.Size = new System.Drawing.Size(115, 25);
			this.cmdDelCleanUpField.Location = new System.Drawing.Point(604, 74);
			this.cmdDelCleanUpField.TabIndex = 16;
			this.cmdDelCleanUpField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDelCleanUpField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDelCleanUpField.CausesValidation = true;
			this.cmdDelCleanUpField.Enabled = true;
			this.cmdDelCleanUpField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDelCleanUpField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDelCleanUpField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDelCleanUpField.TabStop = true;
			this.cmdDelCleanUpField.Name = "cmdDelCleanUpField";
			this.Label6.Text = "Existing Criteria";
			this.Label6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label6.ForeColor = System.Drawing.Color.Blue;
			this.Label6.Size = new System.Drawing.Size(122, 20);
			this.Label6.Location = new System.Drawing.Point(38, 178);
			this.Label6.TabIndex = 26;
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
			this.Label5.Text = "The value of the following fields for each record will be removed during the submission process, if the defined criteria has been met.";
			this.Label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label5.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label5.Size = new System.Drawing.Size(738, 43);
			this.Label5.Location = new System.Drawing.Point(19, 53);
			this.Label5.TabIndex = 15;
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
			this._ssTabSubmission_TabPage2.Text = "Summary Validation";
			this.cmdPrintSummaryVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrintSummaryVal.Text = "Export Summary Validation to Text File";
			this.cmdPrintSummaryVal.Size = new System.Drawing.Size(277, 25);
			this.cmdPrintSummaryVal.Location = new System.Drawing.Point(20, 442);
			this.cmdPrintSummaryVal.TabIndex = 84;
			this.cmdPrintSummaryVal.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdPrintSummaryVal.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrintSummaryVal.CausesValidation = true;
			this.cmdPrintSummaryVal.Enabled = true;
			this.cmdPrintSummaryVal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrintSummaryVal.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrintSummaryVal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrintSummaryVal.TabStop = true;
			this.cmdPrintSummaryVal.Name = "cmdPrintSummaryVal";
			this.sstabValidation.Size = new System.Drawing.Size(768, 398);
			this.sstabValidation.Location = new System.Drawing.Point(19, 40);
			this.sstabValidation.TabIndex = 35;
			this.sstabValidation.SelectedIndex = 1;
			this.sstabValidation.ItemSize = new System.Drawing.Size(42, 22);
			this.sstabValidation.ForeColor = System.Drawing.Color.Blue;
			this.sstabValidation.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.sstabValidation.Name = "sstabValidation";
			this._sstabValidation_TabPage0.Text = "Errors";
			this.cmdChangeErrorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeErrorStatus.Text = "Change Status";
			this.cmdChangeErrorStatus.Size = new System.Drawing.Size(164, 23);
			this.cmdChangeErrorStatus.Location = new System.Drawing.Point(362, 167);
			this.cmdChangeErrorStatus.TabIndex = 61;
			this.cmdChangeErrorStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeErrorStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeErrorStatus.CausesValidation = true;
			this.cmdChangeErrorStatus.Enabled = true;
			this.cmdChangeErrorStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeErrorStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeErrorStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeErrorStatus.TabStop = true;
			this.cmdChangeErrorStatus.Name = "cmdChangeErrorStatus";
			this.cmdChangeToWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeToWarning.Text = "Change to Warning";
			this.cmdChangeToWarning.Size = new System.Drawing.Size(168, 24);
			this.cmdChangeToWarning.Location = new System.Drawing.Point(579, 168);
			this.cmdChangeToWarning.TabIndex = 56;
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
			this.cmdValidErrorAddCritOr.Size = new System.Drawing.Size(30, 22);
			this.cmdValidErrorAddCritOr.Location = new System.Drawing.Point(480, 372);
			this.cmdValidErrorAddCritOr.Image = (System.Drawing.Image)resources.GetObject("cmdValidErrorAddCritOr.Image");
			this.cmdValidErrorAddCritOr.TabIndex = 42;
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
			this.cmdValidErrorAddCritAnd.Size = new System.Drawing.Size(42, 22);
			this.cmdValidErrorAddCritAnd.Location = new System.Drawing.Point(435, 372);
			this.cmdValidErrorAddCritAnd.Image = (System.Drawing.Image)resources.GetObject("cmdValidErrorAddCritAnd.Image");
			this.cmdValidErrorAddCritAnd.TabIndex = 41;
			this.cmdValidErrorAddCritAnd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidErrorAddCritAnd.CausesValidation = true;
			this.cmdValidErrorAddCritAnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidErrorAddCritAnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidErrorAddCritAnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidErrorAddCritAnd.TabStop = true;
			this.cmdValidErrorAddCritAnd.Name = "cmdValidErrorAddCritAnd";
			this.cmdValidErrorDeleteCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidErrorDeleteCrit.Text = "Delete Criteria";
			this.cmdValidErrorDeleteCrit.Size = new System.Drawing.Size(125, 22);
			this.cmdValidErrorDeleteCrit.Location = new System.Drawing.Point(632, 372);
			this.cmdValidErrorDeleteCrit.TabIndex = 44;
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
			this.cmdValidErrorAddCrit.Size = new System.Drawing.Size(112, 22);
			this.cmdValidErrorAddCrit.Location = new System.Drawing.Point(517, 372);
			this.cmdValidErrorAddCrit.TabIndex = 43;
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
			this.cmdUpdateError.Size = new System.Drawing.Size(107, 23);
			this.cmdUpdateError.Location = new System.Drawing.Point(138, 167);
			this.cmdUpdateError.TabIndex = 38;
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
			this.cmdDelError.Size = new System.Drawing.Size(113, 23);
			this.cmdDelError.Location = new System.Drawing.Point(247, 167);
			this.cmdDelError.TabIndex = 39;
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
			this.cmdAddError.Size = new System.Drawing.Size(113, 23);
			this.cmdAddError.Location = new System.Drawing.Point(22, 167);
			this.cmdAddError.TabIndex = 37;
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
			this.dbgSubmitErrors.Size = new System.Drawing.Size(728, 119);
			this.dbgSubmitErrors.Location = new System.Drawing.Point(22, 44);
			this.dbgSubmitErrors.TabIndex = 36;
			this.dbgSubmitErrors.Name = "dbgSubmitErrors";
			dbgValidationErrorCriteria.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgValidationErrorCriteria.OcxState");
			this.dbgValidationErrorCriteria.Size = new System.Drawing.Size(729, 177);
			this.dbgValidationErrorCriteria.Location = new System.Drawing.Point(22, 193);
			this.dbgValidationErrorCriteria.TabIndex = 40;
			this.dbgValidationErrorCriteria.Name = "dbgValidationErrorCriteria";
			this._sstabValidation_TabPage1.Text = "Warnings";
			dbgValidationWarningCriteria.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgValidationWarningCriteria.OcxState");
			this.dbgValidationWarningCriteria.Size = new System.Drawing.Size(729, 178);
			this.dbgValidationWarningCriteria.Location = new System.Drawing.Point(23, 192);
			this.dbgValidationWarningCriteria.TabIndex = 53;
			this.dbgValidationWarningCriteria.Name = "dbgValidationWarningCriteria";
			dbgSubmitWarnings.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgSubmitWarnings.OcxState");
			this.dbgSubmitWarnings.Size = new System.Drawing.Size(728, 119);
			this.dbgSubmitWarnings.Location = new System.Drawing.Point(24, 45);
			this.dbgSubmitWarnings.TabIndex = 45;
			this.dbgSubmitWarnings.Name = "dbgSubmitWarnings";
			this.cmdAddWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAddWarning.Text = "Add Warning";
			this.cmdAddWarning.Size = new System.Drawing.Size(117, 23);
			this.cmdAddWarning.Location = new System.Drawing.Point(23, 167);
			this.cmdAddWarning.TabIndex = 46;
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
			this.cmdDeleteWarning.Size = new System.Drawing.Size(133, 23);
			this.cmdDeleteWarning.Location = new System.Drawing.Point(279, 167);
			this.cmdDeleteWarning.TabIndex = 48;
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
			this.cmdUpdateWarning.Size = new System.Drawing.Size(133, 23);
			this.cmdUpdateWarning.Location = new System.Drawing.Point(143, 167);
			this.cmdUpdateWarning.TabIndex = 47;
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
			this.cmdValidWarningAddCrit.Size = new System.Drawing.Size(108, 22);
			this.cmdValidWarningAddCrit.Location = new System.Drawing.Point(529, 372);
			this.cmdValidWarningAddCrit.TabIndex = 51;
			this.cmdValidWarningAddCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningAddCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningAddCrit.CausesValidation = true;
			this.cmdValidWarningAddCrit.Enabled = true;
			this.cmdValidWarningAddCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningAddCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningAddCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningAddCrit.TabStop = true;
			this.cmdValidWarningAddCrit.Name = "cmdValidWarningAddCrit";
			this.cmdValidWarningDeleteCrit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningDeleteCrit.Text = "Delete Criteria";
			this.cmdValidWarningDeleteCrit.Size = new System.Drawing.Size(114, 22);
			this.cmdValidWarningDeleteCrit.Location = new System.Drawing.Point(642, 372);
			this.cmdValidWarningDeleteCrit.TabIndex = 52;
			this.cmdValidWarningDeleteCrit.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningDeleteCrit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningDeleteCrit.CausesValidation = true;
			this.cmdValidWarningDeleteCrit.Enabled = true;
			this.cmdValidWarningDeleteCrit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningDeleteCrit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningDeleteCrit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningDeleteCrit.TabStop = true;
			this.cmdValidWarningDeleteCrit.Name = "cmdValidWarningDeleteCrit";
			this.cmdValidWarningAddCritAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdValidWarningAddCritAnd.Text = "And";
			this.cmdValidWarningAddCritAnd.Enabled = false;
			this.cmdValidWarningAddCritAnd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdValidWarningAddCritAnd.Size = new System.Drawing.Size(42, 22);
			this.cmdValidWarningAddCritAnd.Location = new System.Drawing.Point(449, 372);
			this.cmdValidWarningAddCritAnd.Image = (System.Drawing.Image)resources.GetObject("cmdValidWarningAddCritAnd.Image");
			this.cmdValidWarningAddCritAnd.TabIndex = 49;
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
			this.cmdValidWarningAddCritOr.Size = new System.Drawing.Size(30, 22);
			this.cmdValidWarningAddCritOr.Location = new System.Drawing.Point(494, 372);
			this.cmdValidWarningAddCritOr.Image = (System.Drawing.Image)resources.GetObject("cmdValidWarningAddCritOr.Image");
			this.cmdValidWarningAddCritOr.TabIndex = 50;
			this.cmdValidWarningAddCritOr.BackColor = System.Drawing.SystemColors.Control;
			this.cmdValidWarningAddCritOr.CausesValidation = true;
			this.cmdValidWarningAddCritOr.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdValidWarningAddCritOr.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdValidWarningAddCritOr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdValidWarningAddCritOr.TabStop = true;
			this.cmdValidWarningAddCritOr.Name = "cmdValidWarningAddCritOr";
			this.cmdChangeToError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeToError.Text = "Change to Error";
			this.cmdChangeToError.Size = new System.Drawing.Size(178, 23);
			this.cmdChangeToError.Location = new System.Drawing.Point(573, 167);
			this.cmdChangeToError.TabIndex = 57;
			this.cmdChangeToError.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeToError.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeToError.CausesValidation = true;
			this.cmdChangeToError.Enabled = true;
			this.cmdChangeToError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeToError.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeToError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeToError.TabStop = true;
			this.cmdChangeToError.Name = "cmdChangeToError";
			this.cmdChangeWarningStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeWarningStatus.Text = "Change Status";
			this.cmdChangeWarningStatus.Size = new System.Drawing.Size(153, 23);
			this.cmdChangeWarningStatus.Location = new System.Drawing.Point(415, 167);
			this.cmdChangeWarningStatus.TabIndex = 62;
			this.cmdChangeWarningStatus.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeWarningStatus.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeWarningStatus.CausesValidation = true;
			this.cmdChangeWarningStatus.Enabled = true;
			this.cmdChangeWarningStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeWarningStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeWarningStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeWarningStatus.TabStop = true;
			this.cmdChangeWarningStatus.Name = "cmdChangeWarningStatus";
			this._ssTabSubmission_TabPage3.Text = "Record Cleanup Setup";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "PRINT";
			this.cmdPrint.Size = new System.Drawing.Size(62, 22);
			this.cmdPrint.Location = new System.Drawing.Point(260, 80);
			this.cmdPrint.TabIndex = 100;
			this.cmdPrint.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.Frame4.Text = "Add Criteria";
			this.Frame4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame4.ForeColor = System.Drawing.Color.Blue;
			this.Frame4.Size = new System.Drawing.Size(778, 185);
			this.Frame4.Location = new System.Drawing.Point(19, 272);
			this.Frame4.TabIndex = 68;
			this.Frame4.BackColor = System.Drawing.SystemColors.Control;
			this.Frame4.Enabled = true;
			this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame4.Visible = true;
			this.Frame4.Padding = new System.Windows.Forms.Padding(0);
			this.Frame4.Name = "Frame4";
			this.cboRecordCleanupSet.Size = new System.Drawing.Size(67, 27);
			this.cboRecordCleanupSet.Location = new System.Drawing.Point(183, 18);
			this.cboRecordCleanupSet.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboRecordCleanupSet.TabIndex = 80;
			this.cboRecordCleanupSet.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboRecordCleanupSet.BackColor = System.Drawing.SystemColors.Window;
			this.cboRecordCleanupSet.CausesValidation = true;
			this.cboRecordCleanupSet.Enabled = true;
			this.cboRecordCleanupSet.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboRecordCleanupSet.IntegralHeight = true;
			this.cboRecordCleanupSet.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboRecordCleanupSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboRecordCleanupSet.Sorted = false;
			this.cboRecordCleanupSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboRecordCleanupSet.TabStop = true;
			this.cboRecordCleanupSet.Visible = true;
			this.cboRecordCleanupSet.Name = "cboRecordCleanupSet";
			this.cboRecordCleanupJoinOperator.Size = new System.Drawing.Size(67, 27);
			this.cboRecordCleanupJoinOperator.Location = new System.Drawing.Point(405, 20);
			this.cboRecordCleanupJoinOperator.Items.AddRange(new object[] {
				"And",
				"Or"
			});
			this.cboRecordCleanupJoinOperator.TabIndex = 79;
			this.cboRecordCleanupJoinOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboRecordCleanupJoinOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboRecordCleanupJoinOperator.CausesValidation = true;
			this.cboRecordCleanupJoinOperator.Enabled = true;
			this.cboRecordCleanupJoinOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboRecordCleanupJoinOperator.IntegralHeight = true;
			this.cboRecordCleanupJoinOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboRecordCleanupJoinOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboRecordCleanupJoinOperator.Sorted = false;
			this.cboRecordCleanupJoinOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboRecordCleanupJoinOperator.TabStop = true;
			this.cboRecordCleanupJoinOperator.Visible = true;
			this.cboRecordCleanupJoinOperator.Name = "cboRecordCleanupJoinOperator";
			this.Frame5.Text = "Result (Define one)";
			this.Frame5.ForeColor = System.Drawing.Color.Black;
			this.Frame5.Size = new System.Drawing.Size(360, 97);
			this.Frame5.Location = new System.Drawing.Point(407, 53);
			this.Frame5.TabIndex = 72;
			this.Frame5.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Frame5.BackColor = System.Drawing.SystemColors.Control;
			this.Frame5.Enabled = true;
			this.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Frame5.Visible = true;
			this.Frame5.Padding = new System.Windows.Forms.Padding(0);
			this.Frame5.Name = "Frame5";
			this.chkRecordCleanupBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkRecordCleanupBlank.Text = " Blank:";
			this.chkRecordCleanupBlank.Size = new System.Drawing.Size(78, 22);
			this.chkRecordCleanupBlank.Location = new System.Drawing.Point(47, 23);
			this.chkRecordCleanupBlank.TabIndex = 77;
			this.chkRecordCleanupBlank.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chkRecordCleanupBlank.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.chkRecordCleanupBlank.BackColor = System.Drawing.SystemColors.Control;
			this.chkRecordCleanupBlank.CausesValidation = true;
			this.chkRecordCleanupBlank.Enabled = true;
			this.chkRecordCleanupBlank.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkRecordCleanupBlank.Cursor = System.Windows.Forms.Cursors.Default;
			this.chkRecordCleanupBlank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chkRecordCleanupBlank.Appearance = System.Windows.Forms.Appearance.Normal;
			this.chkRecordCleanupBlank.TabStop = true;
			this.chkRecordCleanupBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;
			this.chkRecordCleanupBlank.Visible = true;
			this.chkRecordCleanupBlank.Name = "chkRecordCleanupBlank";
			this.cboRecordCleanupLookupList.Size = new System.Drawing.Size(242, 27);
			this.cboRecordCleanupLookupList.Location = new System.Drawing.Point(109, 60);
			this.cboRecordCleanupLookupList.TabIndex = 74;
			this.cboRecordCleanupLookupList.Visible = false;
			this.cboRecordCleanupLookupList.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboRecordCleanupLookupList.BackColor = System.Drawing.SystemColors.Window;
			this.cboRecordCleanupLookupList.CausesValidation = true;
			this.cboRecordCleanupLookupList.Enabled = true;
			this.cboRecordCleanupLookupList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboRecordCleanupLookupList.IntegralHeight = true;
			this.cboRecordCleanupLookupList.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboRecordCleanupLookupList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboRecordCleanupLookupList.Sorted = false;
			this.cboRecordCleanupLookupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboRecordCleanupLookupList.TabStop = true;
			this.cboRecordCleanupLookupList.Name = "cboRecordCleanupLookupList";
			this.txtRecordCleanupValue.AutoSize = false;
			this.txtRecordCleanupValue.Size = new System.Drawing.Size(105, 25);
			this.txtRecordCleanupValue.Location = new System.Drawing.Point(109, 49);
			this.txtRecordCleanupValue.TabIndex = 73;
			this.txtRecordCleanupValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.txtRecordCleanupValue.AcceptsReturn = true;
			this.txtRecordCleanupValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtRecordCleanupValue.BackColor = System.Drawing.SystemColors.Window;
			this.txtRecordCleanupValue.CausesValidation = true;
			this.txtRecordCleanupValue.Enabled = true;
			this.txtRecordCleanupValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtRecordCleanupValue.HideSelection = true;
			this.txtRecordCleanupValue.ReadOnly = false;
			this.txtRecordCleanupValue.MaxLength = 0;
			this.txtRecordCleanupValue.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtRecordCleanupValue.Multiline = false;
			this.txtRecordCleanupValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtRecordCleanupValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtRecordCleanupValue.TabStop = true;
			this.txtRecordCleanupValue.Visible = true;
			this.txtRecordCleanupValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtRecordCleanupValue.Name = "txtRecordCleanupValue";
			this.Label13.Text = "Value:";
			this.Label13.Size = new System.Drawing.Size(50, 18);
			this.Label13.Location = new System.Drawing.Point(52, 50);
			this.Label13.TabIndex = 78;
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
			this.cboRecordCleanupField.Size = new System.Drawing.Size(275, 27);
			this.cboRecordCleanupField.Location = new System.Drawing.Point(43, 87);
			this.cboRecordCleanupField.TabIndex = 71;
			this.cboRecordCleanupField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboRecordCleanupField.BackColor = System.Drawing.SystemColors.Window;
			this.cboRecordCleanupField.CausesValidation = true;
			this.cboRecordCleanupField.Enabled = true;
			this.cboRecordCleanupField.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboRecordCleanupField.IntegralHeight = true;
			this.cboRecordCleanupField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboRecordCleanupField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboRecordCleanupField.Sorted = false;
			this.cboRecordCleanupField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboRecordCleanupField.TabStop = true;
			this.cboRecordCleanupField.Visible = true;
			this.cboRecordCleanupField.Name = "cboRecordCleanupField";
			this.cboRecordCleanupOperator.Size = new System.Drawing.Size(50, 27);
			this.cboRecordCleanupOperator.Location = new System.Drawing.Point(349, 87);
			this.cboRecordCleanupOperator.Items.AddRange(new object[] {
				"=",
				"<>",
				">",
				"<",
				">=",
				"<="
			});
			this.cboRecordCleanupOperator.TabIndex = 70;
			this.cboRecordCleanupOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cboRecordCleanupOperator.BackColor = System.Drawing.SystemColors.Window;
			this.cboRecordCleanupOperator.CausesValidation = true;
			this.cboRecordCleanupOperator.Enabled = true;
			this.cboRecordCleanupOperator.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboRecordCleanupOperator.IntegralHeight = true;
			this.cboRecordCleanupOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboRecordCleanupOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cboRecordCleanupOperator.Sorted = false;
			this.cboRecordCleanupOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.cboRecordCleanupOperator.TabStop = true;
			this.cboRecordCleanupOperator.Visible = true;
			this.cboRecordCleanupOperator.Name = "cboRecordCleanupOperator";
			this.cmdRecordCleanupAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRecordCleanupAdd.Text = "Add";
			this.cmdRecordCleanupAdd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRecordCleanupAdd.Size = new System.Drawing.Size(134, 25);
			this.cmdRecordCleanupAdd.Location = new System.Drawing.Point(310, 153);
			this.cmdRecordCleanupAdd.TabIndex = 69;
			this.cmdRecordCleanupAdd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRecordCleanupAdd.CausesValidation = true;
			this.cmdRecordCleanupAdd.Enabled = true;
			this.cmdRecordCleanupAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRecordCleanupAdd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRecordCleanupAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRecordCleanupAdd.TabStop = true;
			this.cmdRecordCleanupAdd.Name = "cmdRecordCleanupAdd";
			this.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label18.Text = "Select Criteria Set #:";
			this.Label18.ForeColor = System.Drawing.Color.Black;
			this.Label18.Size = new System.Drawing.Size(157, 18);
			this.Label18.Location = new System.Drawing.Point(24, 22);
			this.Label18.TabIndex = 82;
			this.Label18.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label18.BackColor = System.Drawing.SystemColors.Control;
			this.Label18.Enabled = true;
			this.Label18.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label18.UseMnemonic = true;
			this.Label18.Visible = true;
			this.Label18.AutoSize = false;
			this.Label18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label18.Name = "Label18";
			this.lblJoinOperator.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblJoinOperator.Text = "Join type in this Set:";
			this.lblJoinOperator.ForeColor = System.Drawing.Color.Black;
			this.lblJoinOperator.Size = new System.Drawing.Size(132, 18);
			this.lblJoinOperator.Location = new System.Drawing.Point(270, 20);
			this.lblJoinOperator.TabIndex = 81;
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
			this.Label15.Text = "Field";
			this.Label15.ForeColor = System.Drawing.Color.Black;
			this.Label15.Size = new System.Drawing.Size(40, 17);
			this.Label15.Location = new System.Drawing.Point(9, 90);
			this.Label15.TabIndex = 76;
			this.Label15.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label15.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label15.BackColor = System.Drawing.SystemColors.Control;
			this.Label15.Enabled = true;
			this.Label15.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label15.UseMnemonic = true;
			this.Label15.Visible = true;
			this.Label15.AutoSize = false;
			this.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label15.Name = "Label15";
			this.Label14.Text = "Op.";
			this.Label14.ForeColor = System.Drawing.Color.Black;
			this.Label14.Size = new System.Drawing.Size(44, 17);
			this.Label14.Location = new System.Drawing.Point(323, 90);
			this.Label14.TabIndex = 75;
			this.Label14.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label14.BackColor = System.Drawing.SystemColors.Control;
			this.Label14.Enabled = true;
			this.Label14.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label14.UseMnemonic = true;
			this.Label14.Visible = true;
			this.Label14.AutoSize = false;
			this.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label14.Name = "Label14";
			this.cmdRecordCleanupChangeOrAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRecordCleanupChangeOrAnd.Text = "Change Or/And of the Criteria Set";
			this.cmdRecordCleanupChangeOrAnd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRecordCleanupChangeOrAnd.Size = new System.Drawing.Size(267, 24);
			this.cmdRecordCleanupChangeOrAnd.Location = new System.Drawing.Point(527, 75);
			this.cmdRecordCleanupChangeOrAnd.TabIndex = 66;
			this.cmdRecordCleanupChangeOrAnd.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRecordCleanupChangeOrAnd.CausesValidation = true;
			this.cmdRecordCleanupChangeOrAnd.Enabled = true;
			this.cmdRecordCleanupChangeOrAnd.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRecordCleanupChangeOrAnd.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRecordCleanupChangeOrAnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRecordCleanupChangeOrAnd.TabStop = true;
			this.cmdRecordCleanupChangeOrAnd.Name = "cmdRecordCleanupChangeOrAnd";
			this.cmdRecordCleanupRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdRecordCleanupRemove.Text = "Remove Criteria";
			this.cmdRecordCleanupRemove.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdRecordCleanupRemove.Size = new System.Drawing.Size(139, 24);
			this.cmdRecordCleanupRemove.Location = new System.Drawing.Point(384, 75);
			this.cmdRecordCleanupRemove.TabIndex = 65;
			this.cmdRecordCleanupRemove.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRecordCleanupRemove.CausesValidation = true;
			this.cmdRecordCleanupRemove.Enabled = true;
			this.cmdRecordCleanupRemove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRecordCleanupRemove.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRecordCleanupRemove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRecordCleanupRemove.TabStop = true;
			this.cmdRecordCleanupRemove.Name = "cmdRecordCleanupRemove";
			this.lstRecordCleanupCriteria.Size = new System.Drawing.Size(775, 172);
			this.lstRecordCleanupCriteria.Location = new System.Drawing.Point(22, 103);
			this.lstRecordCleanupCriteria.TabIndex = 63;
			this.lstRecordCleanupCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lstRecordCleanupCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstRecordCleanupCriteria.BackColor = System.Drawing.SystemColors.Window;
			this.lstRecordCleanupCriteria.CausesValidation = true;
			this.lstRecordCleanupCriteria.Enabled = true;
			this.lstRecordCleanupCriteria.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstRecordCleanupCriteria.IntegralHeight = true;
			this.lstRecordCleanupCriteria.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstRecordCleanupCriteria.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstRecordCleanupCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstRecordCleanupCriteria.Sorted = false;
			this.lstRecordCleanupCriteria.TabStop = true;
			this.lstRecordCleanupCriteria.Visible = true;
			this.lstRecordCleanupCriteria.MultiColumn = false;
			this.lstRecordCleanupCriteria.Name = "lstRecordCleanupCriteria";
			this.Label12.Text = "During the Disk Submission process, records that meet at least one of the following conditions will be summarized. The records without any of these conditions will be removed.";
			this.Label12.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label12.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.Label12.Size = new System.Drawing.Size(765, 37);
			this.Label12.Location = new System.Drawing.Point(27, 37);
			this.Label12.TabIndex = 67;
			this.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label12.BackColor = System.Drawing.SystemColors.Control;
			this.Label12.Enabled = true;
			this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label12.UseMnemonic = true;
			this.Label12.Visible = true;
			this.Label12.AutoSize = false;
			this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label12.Name = "Label12";
			this.Label10.Text = "Existing Criteria";
			this.Label10.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.Label10.ForeColor = System.Drawing.Color.Blue;
			this.Label10.Size = new System.Drawing.Size(122, 20);
			this.Label10.Location = new System.Drawing.Point(22, 83);
			this.Label10.TabIndex = 64;
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label10.BackColor = System.Drawing.SystemColors.Control;
			this.Label10.Enabled = true;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.UseMnemonic = true;
			this.Label10.Visible = true;
			this.Label10.AutoSize = false;
			this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label10.Name = "Label10";
			rdcSubmissionFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcSubmissionFieldList.OcxState");
			this.rdcSubmissionFieldList.Size = new System.Drawing.Size(197, 28);
			this.rdcSubmissionFieldList.Location = new System.Drawing.Point(25, 613);
			this.rdcSubmissionFieldList.Visible = false;
			this.rdcSubmissionFieldList.Name = "rdcSubmissionFieldList";
			rdcSumFieldList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcSumFieldList.OcxState");
			this.rdcSumFieldList.Size = new System.Drawing.Size(195, 28);
			this.rdcSumFieldList.Location = new System.Drawing.Point(225, 615);
			this.rdcSumFieldList.Visible = false;
			this.rdcSumFieldList.Name = "rdcSumFieldList";
			rdcIndicatorList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcIndicatorList.OcxState");
			this.rdcIndicatorList.Size = new System.Drawing.Size(178, 28);
			this.rdcIndicatorList.Location = new System.Drawing.Point(420, 615);
			this.rdcIndicatorList.Visible = false;
			this.rdcIndicatorList.Name = "rdcIndicatorList";
			rdcValidationWarnings.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationWarnings.OcxState");
			this.rdcValidationWarnings.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationWarnings.Location = new System.Drawing.Point(224, 643);
			this.rdcValidationWarnings.Visible = false;
			this.rdcValidationWarnings.Name = "rdcValidationWarnings";
			rdcValidationErrorCriteria.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationErrorCriteria.OcxState");
			this.rdcValidationErrorCriteria.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationErrorCriteria.Location = new System.Drawing.Point(17, 642);
			this.rdcValidationErrorCriteria.Visible = false;
			this.rdcValidationErrorCriteria.Name = "rdcValidationErrorCriteria";
			rdcValidationWarningCriteria.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationWarningCriteria.OcxState");
			this.rdcValidationWarningCriteria.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationWarningCriteria.Location = new System.Drawing.Point(224, 615);
			this.rdcValidationWarningCriteria.Visible = false;
			this.rdcValidationWarningCriteria.Name = "rdcValidationWarningCriteria";
			rdcValidationErrors.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcValidationErrors.OcxState");
			this.rdcValidationErrors.Size = new System.Drawing.Size(197, 28);
			this.rdcValidationErrors.Location = new System.Drawing.Point(23, 674);
			this.rdcValidationErrors.Visible = false;
			this.rdcValidationErrors.Name = "rdcValidationErrors";
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrors).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarningCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationErrorCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcValidationWarnings).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcIndicatorList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcSumFieldList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcSubmissionFieldList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitWarnings).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationWarningCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgValidationErrorCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmitErrors).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgSubmissionFieldList).EndInit();
			this.Controls.Add(ssTabSubmission);
			this.Controls.Add(rdcSubmissionFieldList);
			this.Controls.Add(rdcSumFieldList);
			this.Controls.Add(rdcIndicatorList);
			this.Controls.Add(rdcValidationWarnings);
			this.Controls.Add(rdcValidationErrorCriteria);
			this.Controls.Add(rdcValidationWarningCriteria);
			this.Controls.Add(rdcValidationErrors);
			this.ssTabSubmission.Controls.Add(_ssTabSubmission_TabPage0);
			this.ssTabSubmission.Controls.Add(_ssTabSubmission_TabPage1);
			this.ssTabSubmission.Controls.Add(_ssTabSubmission_TabPage2);
			this.ssTabSubmission.Controls.Add(_ssTabSubmission_TabPage3);
			this._ssTabSubmission_TabPage0.Controls.Add(Label4);
			this._ssTabSubmission_TabPage0.Controls.Add(Label8);
			this._ssTabSubmission_TabPage0.Controls.Add(Frame1);
			this._ssTabSubmission_TabPage0.Controls.Add(dbgSubmissionFieldList);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdAddGroup);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdAddRow);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdAddCol);
			this._ssTabSubmission_TabPage0.Controls.Add(chkIncludeGroup);
			this._ssTabSubmission_TabPage0.Controls.Add(chkDisplayGroupTitle);
			this._ssTabSubmission_TabPage0.Controls.Add(chkIncludeRow);
			this._ssTabSubmission_TabPage0.Controls.Add(chkIncludeCol);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdDelSumCriteria);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdAddSumCriteria);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdChangeAndOrCond);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdCopyCriteria);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdCopyCriteriaSets);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdChangeAddOrBetweenSets);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdDupSummarytoMeas);
			this._ssTabSubmission_TabPage0.Controls.Add(lstSummaryDef);
			this._ssTabSubmission_TabPage0.Controls.Add(cmdSubmissionPrint);
			this.Frame1.Controls.Add(lstCategorySelectedList);
			this.Frame1.Controls.Add(cmdRemoveCategory);
			this.Frame1.Controls.Add(cmdSelectCategory);
			this.Frame1.Controls.Add(lstCategoryLookupList);
			this.Frame1.Controls.Add(lstSumField);
			this.Frame1.Controls.Add(cboSumOp);
			this.Frame1.Controls.Add(cboIndicator);
			this.Frame1.Controls.Add(Label19);
			this.Frame1.Controls.Add(Label17);
			this.Frame1.Controls.Add(Label16);
			this.Frame1.Controls.Add(Label3);
			this.Frame1.Controls.Add(Label2);
			this.Frame1.Controls.Add(Label1);
			this._ssTabSubmission_TabPage1.Controls.Add(cmdChangeCleanupStatus);
			this._ssTabSubmission_TabPage1.Controls.Add(Frame3);
			this._ssTabSubmission_TabPage1.Controls.Add(cmdCleanupCriteria);
			this._ssTabSubmission_TabPage1.Controls.Add(lstCleanupCriteria);
			this._ssTabSubmission_TabPage1.Controls.Add(lstCleanUpFields);
			this._ssTabSubmission_TabPage1.Controls.Add(cmdDelCleanUpField);
			this._ssTabSubmission_TabPage1.Controls.Add(Label6);
			this._ssTabSubmission_TabPage1.Controls.Add(Label5);
			this.Frame3.Controls.Add(txtJoinOperator);
			this.Frame3.Controls.Add(cmdCleanupAddCrit);
			this.Frame3.Controls.Add(cboCleanupOperation);
			this.Frame3.Controls.Add(cboCleanUpFieldToAdd);
			this.Frame3.Controls.Add(Frame2);
			this.Frame3.Controls.Add(cmdCleanupAnd);
			this.Frame3.Controls.Add(cmdCleanupOr);
			this.Frame3.Controls.Add(Label11);
			this.Frame3.Controls.Add(Label9);
			this.Frame2.Controls.Add(txtTypeinValue);
			this.Frame2.Controls.Add(cboCleanupValueList);
			this.Frame2.Controls.Add(optCleanupValue);
			this.Frame2.Controls.Add(optCleanupLookupTable);
			this.Frame2.Controls.Add(cboCleanupLookupTables);
			this.Frame2.Controls.Add(Label7);
			this._ssTabSubmission_TabPage2.Controls.Add(cmdPrintSummaryVal);
			this._ssTabSubmission_TabPage2.Controls.Add(sstabValidation);
			this.sstabValidation.Controls.Add(_sstabValidation_TabPage0);
			this.sstabValidation.Controls.Add(_sstabValidation_TabPage1);
			this._sstabValidation_TabPage0.Controls.Add(cmdChangeErrorStatus);
			this._sstabValidation_TabPage0.Controls.Add(cmdChangeToWarning);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorAddCritOr);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorAddCritAnd);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorDeleteCrit);
			this._sstabValidation_TabPage0.Controls.Add(cmdValidErrorAddCrit);
			this._sstabValidation_TabPage0.Controls.Add(cmdUpdateError);
			this._sstabValidation_TabPage0.Controls.Add(cmdDelError);
			this._sstabValidation_TabPage0.Controls.Add(cmdAddError);
			this._sstabValidation_TabPage0.Controls.Add(dbgSubmitErrors);
			this._sstabValidation_TabPage0.Controls.Add(dbgValidationErrorCriteria);
			this._sstabValidation_TabPage1.Controls.Add(dbgValidationWarningCriteria);
			this._sstabValidation_TabPage1.Controls.Add(dbgSubmitWarnings);
			this._sstabValidation_TabPage1.Controls.Add(cmdAddWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdDeleteWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdUpdateWarning);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningAddCrit);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningDeleteCrit);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningAddCritAnd);
			this._sstabValidation_TabPage1.Controls.Add(cmdValidWarningAddCritOr);
			this._sstabValidation_TabPage1.Controls.Add(cmdChangeToError);
			this._sstabValidation_TabPage1.Controls.Add(cmdChangeWarningStatus);
			this._ssTabSubmission_TabPage3.Controls.Add(cmdPrint);
			this._ssTabSubmission_TabPage3.Controls.Add(Frame4);
			this._ssTabSubmission_TabPage3.Controls.Add(cmdRecordCleanupChangeOrAnd);
			this._ssTabSubmission_TabPage3.Controls.Add(cmdRecordCleanupRemove);
			this._ssTabSubmission_TabPage3.Controls.Add(lstRecordCleanupCriteria);
			this._ssTabSubmission_TabPage3.Controls.Add(Label12);
			this._ssTabSubmission_TabPage3.Controls.Add(Label10);
			this.Frame4.Controls.Add(cboRecordCleanupSet);
			this.Frame4.Controls.Add(cboRecordCleanupJoinOperator);
			this.Frame4.Controls.Add(Frame5);
			this.Frame4.Controls.Add(cboRecordCleanupField);
			this.Frame4.Controls.Add(cboRecordCleanupOperator);
			this.Frame4.Controls.Add(cmdRecordCleanupAdd);
			this.Frame4.Controls.Add(Label18);
			this.Frame4.Controls.Add(lblJoinOperator);
			this.Frame4.Controls.Add(Label15);
			this.Frame4.Controls.Add(Label14);
			this.Frame5.Controls.Add(chkRecordCleanupBlank);
			this.Frame5.Controls.Add(cboRecordCleanupLookupList);
			this.Frame5.Controls.Add(txtRecordCleanupValue);
			this.Frame5.Controls.Add(Label13);
			this.ssTabSubmission.ResumeLayout(false);
			this._ssTabSubmission_TabPage0.ResumeLayout(false);
			this.Frame1.ResumeLayout(false);
			this._ssTabSubmission_TabPage1.ResumeLayout(false);
			this.Frame3.ResumeLayout(false);
			this.Frame2.ResumeLayout(false);
			this._ssTabSubmission_TabPage2.ResumeLayout(false);
			this.sstabValidation.ResumeLayout(false);
			this._sstabValidation_TabPage0.ResumeLayout(false);
			this._sstabValidation_TabPage1.ResumeLayout(false);
			this._ssTabSubmission_TabPage3.ResumeLayout(false);
			this.Frame4.ResumeLayout(false);
			this.Frame5.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
