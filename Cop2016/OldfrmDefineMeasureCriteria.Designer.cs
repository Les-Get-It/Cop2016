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
	partial class OldfrmMeasureCriteriaSetup
	{
		#region "Windows Form Designer generated code "
		[System.Diagnostics.DebuggerNonUserCode()]
		public OldfrmMeasureCriteriaSetup() : base()
		{
			Load += frmMeasureCriteriaSetup_Load;
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
		public System.Windows.Forms.ToolStripMenuItem mnuCreateSubsitute;
		public System.Windows.Forms.ToolStripMenuItem mnuCreateDuplicate;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuCreateGroupLogic;
		public System.Windows.Forms.ToolStripMenuItem mnuCreateGroupLogic {
			get { return withEventsField_mnuCreateGroupLogic; }
			set {
				if (withEventsField_mnuCreateGroupLogic != null) {
					withEventsField_mnuCreateGroupLogic.Click -= mnuCreateGroupLogic_Click;
				}
				withEventsField_mnuCreateGroupLogic = value;
				if (withEventsField_mnuCreateGroupLogic != null) {
					withEventsField_mnuCreateGroupLogic.Click += mnuCreateGroupLogic_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuCreate;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuShowGroupLogic;
		public System.Windows.Forms.ToolStripMenuItem mnuShowGroupLogic {
			get { return withEventsField_mnuShowGroupLogic; }
			set {
				if (withEventsField_mnuShowGroupLogic != null) {
					withEventsField_mnuShowGroupLogic.Click -= mnuShowGroupLogic_Click;
				}
				withEventsField_mnuShowGroupLogic = value;
				if (withEventsField_mnuShowGroupLogic != null) {
					withEventsField_mnuShowGroupLogic.Click += mnuShowGroupLogic_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuShow;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuDuplicateMeasure;
		public System.Windows.Forms.ToolStripMenuItem mnuDuplicateMeasure {
			get { return withEventsField_mnuDuplicateMeasure; }
			set {
				if (withEventsField_mnuDuplicateMeasure != null) {
					withEventsField_mnuDuplicateMeasure.Click -= mnuDuplicateMeasure_Click;
				}
				withEventsField_mnuDuplicateMeasure = value;
				if (withEventsField_mnuDuplicateMeasure != null) {
					withEventsField_mnuDuplicateMeasure.Click += mnuDuplicateMeasure_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuDuplicateStep;
		public System.Windows.Forms.ToolStripMenuItem mnuDuplicateSet;
		public System.Windows.Forms.ToolStripMenuItem mnuCopyCriteria;
		public System.Windows.Forms.ToolStripMenuItem mnuDuplicate;
		public System.Windows.Forms.ToolStripMenuItem mnuModifyField;
		public System.Windows.Forms.ToolStripMenuItem mnuModify2ndField;
		public System.Windows.Forms.ToolStripMenuItem mnuModifyOperator;
		public System.Windows.Forms.ToolStripMenuItem mnuModifyValue;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuFlowchartAction;
		public System.Windows.Forms.ToolStripMenuItem mnuFlowchartAction {
			get { return withEventsField_mnuFlowchartAction; }
			set {
				if (withEventsField_mnuFlowchartAction != null) {
					withEventsField_mnuFlowchartAction.Click -= mnuFlowchartAction_Click;
				}
				withEventsField_mnuFlowchartAction = value;
				if (withEventsField_mnuFlowchartAction != null) {
					withEventsField_mnuFlowchartAction.Click += mnuFlowchartAction_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuModify;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeCategory;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeJoinOpGroup;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeJoinOpCriteria;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeJoinOpSet;
		public System.Windows.Forms.ToolStripMenuItem mnuChange;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuDeleteMeasureFlowchartLogic;
		public System.Windows.Forms.ToolStripMenuItem mnuDeleteMeasureFlowchartLogic {
			get { return withEventsField_mnuDeleteMeasureFlowchartLogic; }
			set {
				if (withEventsField_mnuDeleteMeasureFlowchartLogic != null) {
					withEventsField_mnuDeleteMeasureFlowchartLogic.Click -= mnuDeleteMeasureFlowchartLogic_Click;
				}
				withEventsField_mnuDeleteMeasureFlowchartLogic = value;
				if (withEventsField_mnuDeleteMeasureFlowchartLogic != null) {
					withEventsField_mnuDeleteMeasureFlowchartLogic.Click += mnuDeleteMeasureFlowchartLogic_Click;
				}
			}
		}
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuDeleteFlowchartAction;
		public System.Windows.Forms.ToolStripMenuItem mnuDeleteFlowchartAction {
			get { return withEventsField_mnuDeleteFlowchartAction; }
			set {
				if (withEventsField_mnuDeleteFlowchartAction != null) {
					withEventsField_mnuDeleteFlowchartAction.Click -= mnuDeleteFlowchartAction_Click;
				}
				withEventsField_mnuDeleteFlowchartAction = value;
				if (withEventsField_mnuDeleteFlowchartAction != null) {
					withEventsField_mnuDeleteFlowchartAction.Click += mnuDeleteFlowchartAction_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuDeleteCriteria;
		public System.Windows.Forms.ToolStripMenuItem mnuDelete;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_mnuSyncMeasure;
		public System.Windows.Forms.ToolStripMenuItem mnuSyncMeasure {
			get { return withEventsField_mnuSyncMeasure; }
			set {
				if (withEventsField_mnuSyncMeasure != null) {
					withEventsField_mnuSyncMeasure.Click -= mnuSyncMeasure_Click;
				}
				withEventsField_mnuSyncMeasure = value;
				if (withEventsField_mnuSyncMeasure != null) {
					withEventsField_mnuSyncMeasure.Click += mnuSyncMeasure_Click;
				}
			}
		}
		public System.Windows.Forms.ToolStripMenuItem mnuSync;
		public System.Windows.Forms.MenuStrip MainMenu1;
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
		public System.Windows.Forms.Label _Label4_0;
		public System.Windows.Forms.Button _cmdCopyCriteria_0;
		public System.Windows.Forms.Button _cmdCopyCriteriaSteps_0;
		public System.Windows.Forms.Button _cmdDelCriteria_0;
		public System.Windows.Forms.Button _cmdAddCriteria_0;
		public System.Windows.Forms.Button _cmdUp_0;
		public System.Windows.Forms.Button _cmdDown_0;
		public System.Windows.Forms.Button _cmdChangeAndOrCond_0;
		public System.Windows.Forms.Button _cmdChangeAddOrBetweenSets_0;
		public System.Windows.Forms.Button _cmdCopyCriteriaSets_0;
		public System.Windows.Forms.Button _cmdChangeCategoryofSet_0;
		public System.Windows.Forms.ListBox _lstMeasureDef_0;
		private System.Windows.Forms.Button withEventsField_cmdDupMeasure;
		public System.Windows.Forms.Button cmdDupMeasure {
			get { return withEventsField_cmdDupMeasure; }
			set {
				if (withEventsField_cmdDupMeasure != null) {
					withEventsField_cmdDupMeasure.Click -= cmdDupMeasure_Click;
				}
				withEventsField_cmdDupMeasure = value;
				if (withEventsField_cmdDupMeasure != null) {
					withEventsField_cmdDupMeasure.Click += cmdDupMeasure_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdModifyCriteriaField;
		public System.Windows.Forms.Button cmdModifyCriteriaField {
			get { return withEventsField_cmdModifyCriteriaField; }
			set {
				if (withEventsField_cmdModifyCriteriaField != null) {
					withEventsField_cmdModifyCriteriaField.Click -= cmdModifyCriteriaField_Click;
				}
				withEventsField_cmdModifyCriteriaField = value;
				if (withEventsField_cmdModifyCriteriaField != null) {
					withEventsField_cmdModifyCriteriaField.Click += cmdModifyCriteriaField_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdModifyCriteriaOperator;
		public System.Windows.Forms.Button cmdModifyCriteriaOperator {
			get { return withEventsField_cmdModifyCriteriaOperator; }
			set {
				if (withEventsField_cmdModifyCriteriaOperator != null) {
					withEventsField_cmdModifyCriteriaOperator.Click -= cmdModifyCriteriaOperator_Click;
				}
				withEventsField_cmdModifyCriteriaOperator = value;
				if (withEventsField_cmdModifyCriteriaOperator != null) {
					withEventsField_cmdModifyCriteriaOperator.Click += cmdModifyCriteriaOperator_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdModifyCriteriaValue;
		public System.Windows.Forms.Button cmdModifyCriteriaValue {
			get { return withEventsField_cmdModifyCriteriaValue; }
			set {
				if (withEventsField_cmdModifyCriteriaValue != null) {
					withEventsField_cmdModifyCriteriaValue.Click -= cmdModifyCriteriaValue_Click;
				}
				withEventsField_cmdModifyCriteriaValue = value;
				if (withEventsField_cmdModifyCriteriaValue != null) {
					withEventsField_cmdModifyCriteriaValue.Click += cmdModifyCriteriaValue_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdSubstituteStepForSummarization;
		public System.Windows.Forms.Button cmdSubstituteStepForSummarization {
			get { return withEventsField_cmdSubstituteStepForSummarization; }
			set {
				if (withEventsField_cmdSubstituteStepForSummarization != null) {
					withEventsField_cmdSubstituteStepForSummarization.Click -= cmdSubstituteStepForSummarization_Click;
				}
				withEventsField_cmdSubstituteStepForSummarization = value;
				if (withEventsField_cmdSubstituteStepForSummarization != null) {
					withEventsField_cmdSubstituteStepForSummarization.Click += cmdSubstituteStepForSummarization_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdMoveStepTo;
		public System.Windows.Forms.Button cmdMoveStepTo {
			get { return withEventsField_cmdMoveStepTo; }
			set {
				if (withEventsField_cmdMoveStepTo != null) {
					withEventsField_cmdMoveStepTo.Click -= cmdMoveStepTo_Click;
				}
				withEventsField_cmdMoveStepTo = value;
				if (withEventsField_cmdMoveStepTo != null) {
					withEventsField_cmdMoveStepTo.Click += cmdMoveStepTo_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdModifyCriteriaSecondField;
		public System.Windows.Forms.Button cmdModifyCriteriaSecondField {
			get { return withEventsField_cmdModifyCriteriaSecondField; }
			set {
				if (withEventsField_cmdModifyCriteriaSecondField != null) {
					withEventsField_cmdModifyCriteriaSecondField.Click -= cmdModifyCriteriaSecondField_Click;
				}
				withEventsField_cmdModifyCriteriaSecondField = value;
				if (withEventsField_cmdModifyCriteriaSecondField != null) {
					withEventsField_cmdModifyCriteriaSecondField.Click += cmdModifyCriteriaSecondField_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdGroupStep;
		public System.Windows.Forms.Button cmdGroupStep {
			get { return withEventsField_cmdGroupStep; }
			set {
				if (withEventsField_cmdGroupStep != null) {
					withEventsField_cmdGroupStep.Click -= cmdGroupStep_Click;
				}
				withEventsField_cmdGroupStep = value;
				if (withEventsField_cmdGroupStep != null) {
					withEventsField_cmdGroupStep.Click += cmdGroupStep_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdChangeAndBetweenGroup;
		public System.Windows.Forms.Button cmdChangeAndBetweenGroup {
			get { return withEventsField_cmdChangeAndBetweenGroup; }
			set {
				if (withEventsField_cmdChangeAndBetweenGroup != null) {
					withEventsField_cmdChangeAndBetweenGroup.Click -= cmdChangeAndBetweenGroup_Click;
				}
				withEventsField_cmdChangeAndBetweenGroup = value;
				if (withEventsField_cmdChangeAndBetweenGroup != null) {
					withEventsField_cmdChangeAndBetweenGroup.Click += cmdChangeAndBetweenGroup_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdGoToStep;
		public System.Windows.Forms.Button cmdGoToStep {
			get { return withEventsField_cmdGoToStep; }
			set {
				if (withEventsField_cmdGoToStep != null) {
					withEventsField_cmdGoToStep.Click -= cmdGoToStep_Click;
				}
				withEventsField_cmdGoToStep = value;
				if (withEventsField_cmdGoToStep != null) {
					withEventsField_cmdGoToStep.Click += cmdGoToStep_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdView;
		public System.Windows.Forms.Button cmdView {
			get { return withEventsField_cmdView; }
			set {
				if (withEventsField_cmdView != null) {
					withEventsField_cmdView.Click -= cmdView_Click;
				}
				withEventsField_cmdView = value;
				if (withEventsField_cmdView != null) {
					withEventsField_cmdView.Click += cmdView_Click;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_cmdDupSetLogic;
		public System.Windows.Forms.Button cmdDupSetLogic {
			get { return withEventsField_cmdDupSetLogic; }
			set {
				if (withEventsField_cmdDupSetLogic != null) {
					withEventsField_cmdDupSetLogic.Click -= cmdDupSetLogic_Click;
				}
				withEventsField_cmdDupSetLogic = value;
				if (withEventsField_cmdDupSetLogic != null) {
					withEventsField_cmdDupSetLogic.Click += cmdDupSetLogic_Click;
				}
			}
		}
		public System.Windows.Forms.TabPage _SSTabCriteria_TabPage0;
		public System.Windows.Forms.Button _cmdChangeAndOrCond_1;
		public System.Windows.Forms.Button _cmdCopyCriteria_1;
		public System.Windows.Forms.Button _cmdDelCriteria_1;
		public System.Windows.Forms.Button _cmdAddCriteria_1;
		public System.Windows.Forms.ListBox _lstMeasureDef_1;
		public System.Windows.Forms.Label _Label4_1;
		public System.Windows.Forms.TabPage _SSTabCriteria_TabPage1;
		public System.Windows.Forms.Button _cmdUp_1;
		public System.Windows.Forms.Button _cmdDown_1;
		public System.Windows.Forms.Button _cmdCopyCriteria_2;
		public System.Windows.Forms.Button _cmdCopyCriteriaSteps_2;
		public System.Windows.Forms.Button _cmdDelCriteria_2;
		public System.Windows.Forms.Button _cmdAddCriteria_2;
		public System.Windows.Forms.Button _cmdChangeAndOrCond_2;
		public System.Windows.Forms.Button _cmdChangeAddOrBetweenSets_2;
		public System.Windows.Forms.Button _cmdCopyCriteriaSets_2;
		public System.Windows.Forms.Button _cmdChangeCategoryofSet_2;
		public System.Windows.Forms.ListBox _lstMeasureDef_2;
		public System.Windows.Forms.Label _Label4_2;
		public System.Windows.Forms.TabPage _SSTabCriteria_TabPage2;
		private System.Windows.Forms.TabControl withEventsField_SSTabCriteria;
		public System.Windows.Forms.TabControl SSTabCriteria {
			get { return withEventsField_SSTabCriteria; }
			set {
				if (withEventsField_SSTabCriteria != null) {
					withEventsField_SSTabCriteria.SelectedIndexChanged -= SSTabCriteria_SelectedIndexChanged;
				}
				withEventsField_SSTabCriteria = value;
				if (withEventsField_SSTabCriteria != null) {
					withEventsField_SSTabCriteria.SelectedIndexChanged += SSTabCriteria_SelectedIndexChanged;
				}
			}
		}
		private AxMSDBGrid.AxDBGrid withEventsField_dbgMeasureList;
		public AxMSDBGrid.AxDBGrid dbgMeasureList {
			get { return withEventsField_dbgMeasureList; }
			set {
				if (withEventsField_dbgMeasureList != null) {
					withEventsField_dbgMeasureList.RowColChange -= dbgMeasureList_RowColChange;
				}
				withEventsField_dbgMeasureList = value;
				if (withEventsField_dbgMeasureList != null) {
					withEventsField_dbgMeasureList.RowColChange += dbgMeasureList_RowColChange;
				}
			}
		}
		public AxMSRDC.AxMSRDC rdcMeasureList;
		public Microsoft.VisualBasic.Compatibility.VB6.LabelArray Label4;
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdAddCriteria;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdAddCriteria {
			get { return withEventsField_cmdAddCriteria; }
			set {
				if (withEventsField_cmdAddCriteria != null) {
					withEventsField_cmdAddCriteria.Click -= cmdAddCriteria_Click;
				}
				withEventsField_cmdAddCriteria = value;
				if (withEventsField_cmdAddCriteria != null) {
					withEventsField_cmdAddCriteria.Click += cmdAddCriteria_Click;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdChangeAddOrBetweenSets;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdChangeAddOrBetweenSets {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdChangeAndOrCond;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdChangeAndOrCond {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdChangeCategoryofSet;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdChangeCategoryofSet {
			get { return withEventsField_cmdChangeCategoryofSet; }
			set {
				if (withEventsField_cmdChangeCategoryofSet != null) {
					withEventsField_cmdChangeCategoryofSet.Click -= cmdChangeCategoryofSet_Click;
				}
				withEventsField_cmdChangeCategoryofSet = value;
				if (withEventsField_cmdChangeCategoryofSet != null) {
					withEventsField_cmdChangeCategoryofSet.Click += cmdChangeCategoryofSet_Click;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdCopyCriteria;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdCopyCriteria {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdCopyCriteriaSets;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdCopyCriteriaSets {
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
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdCopyCriteriaSteps;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdCopyCriteriaSteps {
			get { return withEventsField_cmdCopyCriteriaSteps; }
			set {
				if (withEventsField_cmdCopyCriteriaSteps != null) {
					withEventsField_cmdCopyCriteriaSteps.Click -= cmdCopyCriteriaSteps_Click;
				}
				withEventsField_cmdCopyCriteriaSteps = value;
				if (withEventsField_cmdCopyCriteriaSteps != null) {
					withEventsField_cmdCopyCriteriaSteps.Click += cmdCopyCriteriaSteps_Click;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdDelCriteria;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdDelCriteria {
			get { return withEventsField_cmdDelCriteria; }
			set {
				if (withEventsField_cmdDelCriteria != null) {
					withEventsField_cmdDelCriteria.Click -= cmdDelCriteria_Click;
				}
				withEventsField_cmdDelCriteria = value;
				if (withEventsField_cmdDelCriteria != null) {
					withEventsField_cmdDelCriteria.Click += cmdDelCriteria_Click;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdDown;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdDown {
			get { return withEventsField_cmdDown; }
			set {
				if (withEventsField_cmdDown != null) {
					withEventsField_cmdDown.Click -= cmdDown_Click;
				}
				withEventsField_cmdDown = value;
				if (withEventsField_cmdDown != null) {
					withEventsField_cmdDown.Click += cmdDown_Click;
				}
			}
		}
		private Microsoft.VisualBasic.Compatibility.VB6.ButtonArray withEventsField_cmdUp;
		public Microsoft.VisualBasic.Compatibility.VB6.ButtonArray cmdUp {
			get { return withEventsField_cmdUp; }
			set {
				if (withEventsField_cmdUp != null) {
					withEventsField_cmdUp.Click -= cmdUp_Click;
				}
				withEventsField_cmdUp = value;
				if (withEventsField_cmdUp != null) {
					withEventsField_cmdUp.Click += cmdUp_Click;
				}
			}
		}
		public Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray lstMeasureDef;
//NOTE: The following procedure is required by the Windows Form Designer
//It can be modified using the Windows Form Designer.
//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OldfrmMeasureCriteriaSetup));
			this.components = new System.ComponentModel.Container();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(components);
			this.MainMenu1 = new System.Windows.Forms.MenuStrip();
			this.mnuCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCreateSubsitute = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCreateDuplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCreateGroupLogic = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuShowGroupLogic = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDuplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDuplicateMeasure = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDuplicateStep = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDuplicateSet = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCopyCriteria = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuModify = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuModifyField = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuModify2ndField = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuModifyOperator = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuModifyValue = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFlowchartAction = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuChange = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuChangeCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuChangeJoinOpGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuChangeJoinOpCriteria = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuChangeJoinOpSet = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDeleteMeasureFlowchartLogic = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDeleteFlowchartAction = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuDeleteCriteria = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSync = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSyncMeasure = new System.Windows.Forms.ToolStripMenuItem();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.SSTabCriteria = new System.Windows.Forms.TabControl();
			this._SSTabCriteria_TabPage0 = new System.Windows.Forms.TabPage();
			this._Label4_0 = new System.Windows.Forms.Label();
			this._cmdCopyCriteria_0 = new System.Windows.Forms.Button();
			this._cmdCopyCriteriaSteps_0 = new System.Windows.Forms.Button();
			this._cmdDelCriteria_0 = new System.Windows.Forms.Button();
			this._cmdAddCriteria_0 = new System.Windows.Forms.Button();
			this._cmdUp_0 = new System.Windows.Forms.Button();
			this._cmdDown_0 = new System.Windows.Forms.Button();
			this._cmdChangeAndOrCond_0 = new System.Windows.Forms.Button();
			this._cmdChangeAddOrBetweenSets_0 = new System.Windows.Forms.Button();
			this._cmdCopyCriteriaSets_0 = new System.Windows.Forms.Button();
			this._cmdChangeCategoryofSet_0 = new System.Windows.Forms.Button();
			this._lstMeasureDef_0 = new System.Windows.Forms.ListBox();
			this.cmdDupMeasure = new System.Windows.Forms.Button();
			this.cmdModifyCriteriaField = new System.Windows.Forms.Button();
			this.cmdModifyCriteriaOperator = new System.Windows.Forms.Button();
			this.cmdModifyCriteriaValue = new System.Windows.Forms.Button();
			this.cmdSubstituteStepForSummarization = new System.Windows.Forms.Button();
			this.cmdMoveStepTo = new System.Windows.Forms.Button();
			this.cmdModifyCriteriaSecondField = new System.Windows.Forms.Button();
			this.cmdGroupStep = new System.Windows.Forms.Button();
			this.cmdChangeAndBetweenGroup = new System.Windows.Forms.Button();
			this.cmdGoToStep = new System.Windows.Forms.Button();
			this.cmdView = new System.Windows.Forms.Button();
			this.cmdDupSetLogic = new System.Windows.Forms.Button();
			this._SSTabCriteria_TabPage1 = new System.Windows.Forms.TabPage();
			this._cmdChangeAndOrCond_1 = new System.Windows.Forms.Button();
			this._cmdCopyCriteria_1 = new System.Windows.Forms.Button();
			this._cmdDelCriteria_1 = new System.Windows.Forms.Button();
			this._cmdAddCriteria_1 = new System.Windows.Forms.Button();
			this._lstMeasureDef_1 = new System.Windows.Forms.ListBox();
			this._Label4_1 = new System.Windows.Forms.Label();
			this._SSTabCriteria_TabPage2 = new System.Windows.Forms.TabPage();
			this._cmdUp_1 = new System.Windows.Forms.Button();
			this._cmdDown_1 = new System.Windows.Forms.Button();
			this._cmdCopyCriteria_2 = new System.Windows.Forms.Button();
			this._cmdCopyCriteriaSteps_2 = new System.Windows.Forms.Button();
			this._cmdDelCriteria_2 = new System.Windows.Forms.Button();
			this._cmdAddCriteria_2 = new System.Windows.Forms.Button();
			this._cmdChangeAndOrCond_2 = new System.Windows.Forms.Button();
			this._cmdChangeAddOrBetweenSets_2 = new System.Windows.Forms.Button();
			this._cmdCopyCriteriaSets_2 = new System.Windows.Forms.Button();
			this._cmdChangeCategoryofSet_2 = new System.Windows.Forms.Button();
			this._lstMeasureDef_2 = new System.Windows.Forms.ListBox();
			this._Label4_2 = new System.Windows.Forms.Label();
			this.dbgMeasureList = new AxMSDBGrid.AxDBGrid();
			this.rdcMeasureList = new AxMSRDC.AxMSRDC();
			this.Label4 = new Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components);
			this.cmdAddCriteria = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdChangeAddOrBetweenSets = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdChangeAndOrCond = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdChangeCategoryofSet = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdCopyCriteria = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdCopyCriteriaSets = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdCopyCriteriaSteps = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdDelCriteria = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdDown = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.cmdUp = new Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components);
			this.lstMeasureDef = new Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray(components);
			this.MainMenu1.SuspendLayout();
			this.SSTabCriteria.SuspendLayout();
			this._SSTabCriteria_TabPage0.SuspendLayout();
			this._SSTabCriteria_TabPage1.SuspendLayout();
			this._SSTabCriteria_TabPage2.SuspendLayout();
			this.SuspendLayout();
			this.ToolTip1.Active = true;
			((System.ComponentModel.ISupportInitialize)this.dbgMeasureList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.rdcMeasureList).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.Label4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdAddCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAddOrBetweenSets).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAndOrCond).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeCategoryofSet).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdCopyCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdCopyCriteriaSets).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdCopyCriteriaSteps).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdDelCriteria).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdDown).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.cmdUp).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.lstMeasureDef).BeginInit();
			this.Text = "Measure Criteria for Flowcharts";
			this.ClientSize = new System.Drawing.Size(857, 846);
			this.Location = new System.Drawing.Point(14, 38);
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
			this.Name = "frmMeasureCriteriaSetup";
			this.mnuCreate.Name = "mnuCreate";
			this.mnuCreate.Text = "&Create";
			this.mnuCreate.Checked = false;
			this.mnuCreate.Enabled = true;
			this.mnuCreate.Visible = true;
			this.mnuCreateSubsitute.Name = "mnuCreateSubsitute";
			this.mnuCreateSubsitute.Text = "Subsitute Step for Summarization";
			this.mnuCreateSubsitute.Visible = false;
			this.mnuCreateSubsitute.Checked = false;
			this.mnuCreateSubsitute.Enabled = true;
			this.mnuCreateDuplicate.Name = "mnuCreateDuplicate";
			this.mnuCreateDuplicate.Text = "Duplicate Set Logic";
			this.mnuCreateDuplicate.Visible = false;
			this.mnuCreateDuplicate.Checked = false;
			this.mnuCreateDuplicate.Enabled = true;
			this.mnuCreateGroupLogic.Name = "mnuCreateGroupLogic";
			this.mnuCreateGroupLogic.Text = "Multiple Occurrence Group Logic";
			this.mnuCreateGroupLogic.Checked = false;
			this.mnuCreateGroupLogic.Enabled = true;
			this.mnuCreateGroupLogic.Visible = true;
			this.mnuShow.Name = "mnuShow";
			this.mnuShow.Text = "&Show";
			this.mnuShow.Checked = false;
			this.mnuShow.Enabled = true;
			this.mnuShow.Visible = true;
			this.mnuShowGroupLogic.Name = "mnuShowGroupLogic";
			this.mnuShowGroupLogic.Text = "Multiple Occurrence Groups";
			this.mnuShowGroupLogic.Checked = false;
			this.mnuShowGroupLogic.Enabled = true;
			this.mnuShowGroupLogic.Visible = true;
			this.mnuDuplicate.Name = "mnuDuplicate";
			this.mnuDuplicate.Text = "&Duplicate";
			this.mnuDuplicate.Visible = false;
			this.mnuDuplicate.Checked = false;
			this.mnuDuplicate.Enabled = true;
			this.mnuDuplicateMeasure.Name = "mnuDuplicateMeasure";
			this.mnuDuplicateMeasure.Text = "Meausre";
			this.mnuDuplicateMeasure.Checked = false;
			this.mnuDuplicateMeasure.Enabled = true;
			this.mnuDuplicateMeasure.Visible = true;
			this.mnuDuplicateStep.Name = "mnuDuplicateStep";
			this.mnuDuplicateStep.Text = "Criteria Step";
			this.mnuDuplicateStep.Checked = false;
			this.mnuDuplicateStep.Enabled = true;
			this.mnuDuplicateStep.Visible = true;
			this.mnuDuplicateSet.Name = "mnuDuplicateSet";
			this.mnuDuplicateSet.Text = "Criteria Set";
			this.mnuDuplicateSet.Checked = false;
			this.mnuDuplicateSet.Enabled = true;
			this.mnuDuplicateSet.Visible = true;
			this.mnuCopyCriteria.Name = "mnuCopyCriteria";
			this.mnuCopyCriteria.Text = "Criteria";
			this.mnuCopyCriteria.Checked = false;
			this.mnuCopyCriteria.Enabled = true;
			this.mnuCopyCriteria.Visible = true;
			this.mnuModify.Name = "mnuModify";
			this.mnuModify.Text = "&Modify";
			this.mnuModify.Checked = false;
			this.mnuModify.Enabled = true;
			this.mnuModify.Visible = true;
			this.mnuModifyField.Name = "mnuModifyField";
			this.mnuModifyField.Text = "Criteria Field";
			this.mnuModifyField.Visible = false;
			this.mnuModifyField.Checked = false;
			this.mnuModifyField.Enabled = true;
			this.mnuModify2ndField.Name = "mnuModify2ndField";
			this.mnuModify2ndField.Text = "Criteria Second Field";
			this.mnuModify2ndField.Visible = false;
			this.mnuModify2ndField.Checked = false;
			this.mnuModify2ndField.Enabled = true;
			this.mnuModifyOperator.Name = "mnuModifyOperator";
			this.mnuModifyOperator.Text = "Criteria Operator";
			this.mnuModifyOperator.Visible = false;
			this.mnuModifyOperator.Checked = false;
			this.mnuModifyOperator.Enabled = true;
			this.mnuModifyValue.Name = "mnuModifyValue";
			this.mnuModifyValue.Text = "Criteria Value";
			this.mnuModifyValue.Visible = false;
			this.mnuModifyValue.Checked = false;
			this.mnuModifyValue.Enabled = true;
			this.mnuFlowchartAction.Name = "mnuFlowchartAction";
			this.mnuFlowchartAction.Text = "Step Action to Take";
			this.mnuFlowchartAction.Checked = false;
			this.mnuFlowchartAction.Enabled = true;
			this.mnuFlowchartAction.Visible = true;
			this.mnuChange.Name = "mnuChange";
			this.mnuChange.Text = "C&hange";
			this.mnuChange.Visible = false;
			this.mnuChange.Checked = false;
			this.mnuChange.Enabled = true;
			this.mnuChangeCategory.Name = "mnuChangeCategory";
			this.mnuChangeCategory.Text = "Category of Step";
			this.mnuChangeCategory.Checked = false;
			this.mnuChangeCategory.Enabled = true;
			this.mnuChangeCategory.Visible = true;
			this.mnuChangeJoinOpGroup.Name = "mnuChangeJoinOpGroup";
			this.mnuChangeJoinOpGroup.Text = "And/Or of Groups";
			this.mnuChangeJoinOpGroup.Checked = false;
			this.mnuChangeJoinOpGroup.Enabled = true;
			this.mnuChangeJoinOpGroup.Visible = true;
			this.mnuChangeJoinOpCriteria.Name = "mnuChangeJoinOpCriteria";
			this.mnuChangeJoinOpCriteria.Text = "And/Or of Criteria ";
			this.mnuChangeJoinOpCriteria.Checked = false;
			this.mnuChangeJoinOpCriteria.Enabled = true;
			this.mnuChangeJoinOpCriteria.Visible = true;
			this.mnuChangeJoinOpSet.Name = "mnuChangeJoinOpSet";
			this.mnuChangeJoinOpSet.Text = "And/Or Between Set in Step";
			this.mnuChangeJoinOpSet.Checked = false;
			this.mnuChangeJoinOpSet.Enabled = true;
			this.mnuChangeJoinOpSet.Visible = true;
			this.mnuDelete.Name = "mnuDelete";
			this.mnuDelete.Text = "&Delete";
			this.mnuDelete.Checked = false;
			this.mnuDelete.Enabled = true;
			this.mnuDelete.Visible = true;
			this.mnuDeleteMeasureFlowchartLogic.Name = "mnuDeleteMeasureFlowchartLogic";
			this.mnuDeleteMeasureFlowchartLogic.Text = "Entire Measure Flowchart Logic";
			this.mnuDeleteMeasureFlowchartLogic.Checked = false;
			this.mnuDeleteMeasureFlowchartLogic.Enabled = true;
			this.mnuDeleteMeasureFlowchartLogic.Visible = true;
			this.mnuDeleteFlowchartAction.Name = "mnuDeleteFlowchartAction";
			this.mnuDeleteFlowchartAction.Text = "Step Action to Take";
			this.mnuDeleteFlowchartAction.Checked = false;
			this.mnuDeleteFlowchartAction.Enabled = true;
			this.mnuDeleteFlowchartAction.Visible = true;
			this.mnuDeleteCriteria.Name = "mnuDeleteCriteria";
			this.mnuDeleteCriteria.Text = "Criteria";
			this.mnuDeleteCriteria.Visible = false;
			this.mnuDeleteCriteria.Checked = false;
			this.mnuDeleteCriteria.Enabled = true;
			this.mnuSync.Name = "mnuSync";
			this.mnuSync.Text = "Synch";
			this.mnuSync.Checked = false;
			this.mnuSync.Enabled = true;
			this.mnuSync.Visible = true;
			this.mnuSyncMeasure.Name = "mnuSyncMeasure";
			this.mnuSyncMeasure.Text = "Synch Selected Measure";
			this.mnuSyncMeasure.Checked = false;
			this.mnuSyncMeasure.Enabled = true;
			this.mnuSyncMeasure.Visible = true;
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdPrint.Text = "PRINT";
			this.cmdPrint.Size = new System.Drawing.Size(62, 22);
			this.cmdPrint.Location = new System.Drawing.Point(730, 331);
			this.cmdPrint.TabIndex = 16;
			this.cmdPrint.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
			this.cmdPrint.CausesValidation = true;
			this.cmdPrint.Enabled = true;
			this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdPrint.TabStop = true;
			this.cmdPrint.Name = "cmdPrint";
			this.SSTabCriteria.Size = new System.Drawing.Size(852, 547);
			this.SSTabCriteria.Location = new System.Drawing.Point(0, 300);
			this.SSTabCriteria.TabIndex = 1;
			this.SSTabCriteria.ItemSize = new System.Drawing.Size(42, 22);
			this.SSTabCriteria.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.SSTabCriteria.Name = "SSTabCriteria";
			this._SSTabCriteria_TabPage0.Text = "Flowchart Criteria";
			this._Label4_0.Text = "Flowchart Criteria STEPS";
			this._Label4_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label4_0.ForeColor = System.Drawing.Color.Blue;
			this._Label4_0.Size = new System.Drawing.Size(268, 22);
			this._Label4_0.Location = new System.Drawing.Point(70, 40);
			this._Label4_0.TabIndex = 14;
			this._Label4_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label4_0.BackColor = System.Drawing.SystemColors.Control;
			this._Label4_0.Enabled = true;
			this._Label4_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label4_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label4_0.UseMnemonic = true;
			this._Label4_0.Visible = true;
			this._Label4_0.AutoSize = false;
			this._Label4_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label4_0.Name = "_Label4_0";
			this._cmdCopyCriteria_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdCopyCriteria_0.Text = "Copy Criteria";
			this._cmdCopyCriteria_0.Size = new System.Drawing.Size(222, 22);
			this._cmdCopyCriteria_0.Location = new System.Drawing.Point(58, 508);
			this._cmdCopyCriteria_0.TabIndex = 6;
			this._cmdCopyCriteria_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdCopyCriteria_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCopyCriteria_0.CausesValidation = true;
			this._cmdCopyCriteria_0.Enabled = true;
			this._cmdCopyCriteria_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCopyCriteria_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdCopyCriteria_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCopyCriteria_0.TabStop = true;
			this._cmdCopyCriteria_0.Name = "_cmdCopyCriteria_0";
			this._cmdCopyCriteriaSteps_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdCopyCriteriaSteps_0.Text = "Duplicate Criteria Step";
			this._cmdCopyCriteriaSteps_0.Size = new System.Drawing.Size(222, 22);
			this._cmdCopyCriteriaSteps_0.Location = new System.Drawing.Point(58, 454);
			this._cmdCopyCriteriaSteps_0.TabIndex = 5;
			this._cmdCopyCriteriaSteps_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdCopyCriteriaSteps_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCopyCriteriaSteps_0.CausesValidation = true;
			this._cmdCopyCriteriaSteps_0.Enabled = true;
			this._cmdCopyCriteriaSteps_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCopyCriteriaSteps_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdCopyCriteriaSteps_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCopyCriteriaSteps_0.TabStop = true;
			this._cmdCopyCriteriaSteps_0.Name = "_cmdCopyCriteriaSteps_0";
			this._cmdDelCriteria_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDelCriteria_0.Text = "Delete Criteria";
			this._cmdDelCriteria_0.Size = new System.Drawing.Size(102, 22);
			this._cmdDelCriteria_0.Location = new System.Drawing.Point(140, 403);
			this._cmdDelCriteria_0.TabIndex = 3;
			this._cmdDelCriteria_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDelCriteria_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDelCriteria_0.CausesValidation = true;
			this._cmdDelCriteria_0.Enabled = true;
			this._cmdDelCriteria_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDelCriteria_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDelCriteria_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDelCriteria_0.TabStop = true;
			this._cmdDelCriteria_0.Name = "_cmdDelCriteria_0";
			this._cmdAddCriteria_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdAddCriteria_0.Text = "Add Criteria";
			this._cmdAddCriteria_0.Size = new System.Drawing.Size(112, 22);
			this._cmdAddCriteria_0.Location = new System.Drawing.Point(20, 403);
			this._cmdAddCriteria_0.TabIndex = 2;
			this._cmdAddCriteria_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdAddCriteria_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdAddCriteria_0.CausesValidation = true;
			this._cmdAddCriteria_0.Enabled = true;
			this._cmdAddCriteria_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdAddCriteria_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdAddCriteria_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdAddCriteria_0.TabStop = true;
			this._cmdAddCriteria_0.Name = "_cmdAddCriteria_0";
			this._cmdUp_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdUp_0.Text = "Move Step Up";
			this._cmdUp_0.Size = new System.Drawing.Size(52, 54);
			this._cmdUp_0.Location = new System.Drawing.Point(12, 62);
			this._cmdUp_0.TabIndex = 8;
			this._cmdUp_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdUp_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdUp_0.CausesValidation = true;
			this._cmdUp_0.Enabled = true;
			this._cmdUp_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdUp_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdUp_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdUp_0.TabStop = true;
			this._cmdUp_0.Name = "_cmdUp_0";
			this._cmdDown_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDown_0.Text = "Move Step Down";
			this._cmdDown_0.Size = new System.Drawing.Size(52, 53);
			this._cmdDown_0.Location = new System.Drawing.Point(12, 118);
			this._cmdDown_0.TabIndex = 9;
			this._cmdDown_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDown_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDown_0.CausesValidation = true;
			this._cmdDown_0.Enabled = true;
			this._cmdDown_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDown_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDown_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDown_0.TabStop = true;
			this._cmdDown_0.Name = "_cmdDown_0";
			this._cmdChangeAndOrCond_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeAndOrCond_0.Text = "Change And/Or of the Criteria Set(s)";
			this._cmdChangeAndOrCond_0.Size = new System.Drawing.Size(247, 22);
			this._cmdChangeAndOrCond_0.Location = new System.Drawing.Point(562, 454);
			this._cmdChangeAndOrCond_0.TabIndex = 4;
			this._cmdChangeAndOrCond_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeAndOrCond_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeAndOrCond_0.CausesValidation = true;
			this._cmdChangeAndOrCond_0.Enabled = true;
			this._cmdChangeAndOrCond_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeAndOrCond_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeAndOrCond_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeAndOrCond_0.TabStop = true;
			this._cmdChangeAndOrCond_0.Name = "_cmdChangeAndOrCond_0";
			this._cmdChangeAddOrBetweenSets_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeAddOrBetweenSets_0.Text = "Change And/Or Between Sets in Step";
			this._cmdChangeAddOrBetweenSets_0.Size = new System.Drawing.Size(247, 24);
			this._cmdChangeAddOrBetweenSets_0.Location = new System.Drawing.Point(562, 479);
			this._cmdChangeAddOrBetweenSets_0.TabIndex = 7;
			this._cmdChangeAddOrBetweenSets_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeAddOrBetweenSets_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeAddOrBetweenSets_0.CausesValidation = true;
			this._cmdChangeAddOrBetweenSets_0.Enabled = true;
			this._cmdChangeAddOrBetweenSets_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeAddOrBetweenSets_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeAddOrBetweenSets_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeAddOrBetweenSets_0.TabStop = true;
			this._cmdChangeAddOrBetweenSets_0.Name = "_cmdChangeAddOrBetweenSets_0";
			this._cmdCopyCriteriaSets_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdCopyCriteriaSets_0.Text = "Duplicate Criteria Set";
			this._cmdCopyCriteriaSets_0.Size = new System.Drawing.Size(222, 22);
			this._cmdCopyCriteriaSets_0.Location = new System.Drawing.Point(58, 482);
			this._cmdCopyCriteriaSets_0.TabIndex = 17;
			this._cmdCopyCriteriaSets_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdCopyCriteriaSets_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCopyCriteriaSets_0.CausesValidation = true;
			this._cmdCopyCriteriaSets_0.Enabled = true;
			this._cmdCopyCriteriaSets_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCopyCriteriaSets_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdCopyCriteriaSets_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCopyCriteriaSets_0.TabStop = true;
			this._cmdCopyCriteriaSets_0.Name = "_cmdCopyCriteriaSets_0";
			this._cmdChangeCategoryofSet_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeCategoryofSet_0.Text = "Change Category of the Criteria Step";
			this._cmdChangeCategoryofSet_0.Size = new System.Drawing.Size(247, 24);
			this._cmdChangeCategoryofSet_0.Location = new System.Drawing.Point(562, 402);
			this._cmdChangeCategoryofSet_0.TabIndex = 18;
			this._cmdChangeCategoryofSet_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeCategoryofSet_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeCategoryofSet_0.CausesValidation = true;
			this._cmdChangeCategoryofSet_0.Enabled = true;
			this._cmdChangeCategoryofSet_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeCategoryofSet_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeCategoryofSet_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeCategoryofSet_0.TabStop = true;
			this._cmdChangeCategoryofSet_0.Name = "_cmdChangeCategoryofSet_0";
			this._lstMeasureDef_0.Size = new System.Drawing.Size(768, 302);
			this._lstMeasureDef_0.Location = new System.Drawing.Point(70, 60);
			this._lstMeasureDef_0.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this._lstMeasureDef_0.TabIndex = 19;
			this._lstMeasureDef_0.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._lstMeasureDef_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lstMeasureDef_0.BackColor = System.Drawing.SystemColors.Window;
			this._lstMeasureDef_0.CausesValidation = true;
			this._lstMeasureDef_0.Enabled = true;
			this._lstMeasureDef_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lstMeasureDef_0.IntegralHeight = true;
			this._lstMeasureDef_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lstMeasureDef_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lstMeasureDef_0.Sorted = false;
			this._lstMeasureDef_0.TabStop = true;
			this._lstMeasureDef_0.Visible = true;
			this._lstMeasureDef_0.MultiColumn = false;
			this._lstMeasureDef_0.Name = "_lstMeasureDef_0";
			this.cmdDupMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDupMeasure.Text = "Duplicate Measure";
			this.cmdDupMeasure.Size = new System.Drawing.Size(222, 22);
			this.cmdDupMeasure.Location = new System.Drawing.Point(58, 427);
			this.cmdDupMeasure.TabIndex = 33;
			this.cmdDupMeasure.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDupMeasure.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDupMeasure.CausesValidation = true;
			this.cmdDupMeasure.Enabled = true;
			this.cmdDupMeasure.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDupMeasure.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDupMeasure.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDupMeasure.TabStop = true;
			this.cmdDupMeasure.Name = "cmdDupMeasure";
			this.cmdModifyCriteriaField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdModifyCriteriaField.Text = "Modify Criteria Field";
			this.cmdModifyCriteriaField.Size = new System.Drawing.Size(247, 22);
			this.cmdModifyCriteriaField.Location = new System.Drawing.Point(298, 427);
			this.cmdModifyCriteriaField.TabIndex = 34;
			this.cmdModifyCriteriaField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdModifyCriteriaField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdModifyCriteriaField.CausesValidation = true;
			this.cmdModifyCriteriaField.Enabled = true;
			this.cmdModifyCriteriaField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdModifyCriteriaField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdModifyCriteriaField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdModifyCriteriaField.TabStop = true;
			this.cmdModifyCriteriaField.Name = "cmdModifyCriteriaField";
			this.cmdModifyCriteriaOperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdModifyCriteriaOperator.Text = "Modify Criteria Operator";
			this.cmdModifyCriteriaOperator.Size = new System.Drawing.Size(247, 24);
			this.cmdModifyCriteriaOperator.Location = new System.Drawing.Point(298, 479);
			this.cmdModifyCriteriaOperator.TabIndex = 35;
			this.cmdModifyCriteriaOperator.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdModifyCriteriaOperator.BackColor = System.Drawing.SystemColors.Control;
			this.cmdModifyCriteriaOperator.CausesValidation = true;
			this.cmdModifyCriteriaOperator.Enabled = true;
			this.cmdModifyCriteriaOperator.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdModifyCriteriaOperator.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdModifyCriteriaOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdModifyCriteriaOperator.TabStop = true;
			this.cmdModifyCriteriaOperator.Name = "cmdModifyCriteriaOperator";
			this.cmdModifyCriteriaValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdModifyCriteriaValue.Text = "Modify Criteria Value";
			this.cmdModifyCriteriaValue.Size = new System.Drawing.Size(247, 23);
			this.cmdModifyCriteriaValue.Location = new System.Drawing.Point(298, 507);
			this.cmdModifyCriteriaValue.TabIndex = 36;
			this.cmdModifyCriteriaValue.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdModifyCriteriaValue.BackColor = System.Drawing.SystemColors.Control;
			this.cmdModifyCriteriaValue.CausesValidation = true;
			this.cmdModifyCriteriaValue.Enabled = true;
			this.cmdModifyCriteriaValue.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdModifyCriteriaValue.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdModifyCriteriaValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdModifyCriteriaValue.TabStop = true;
			this.cmdModifyCriteriaValue.Name = "cmdModifyCriteriaValue";
			this.cmdSubstituteStepForSummarization.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSubstituteStepForSummarization.Text = "Substitute Step for Summarization";
			this.cmdSubstituteStepForSummarization.Size = new System.Drawing.Size(248, 23);
			this.cmdSubstituteStepForSummarization.Location = new System.Drawing.Point(560, 507);
			this.cmdSubstituteStepForSummarization.TabIndex = 37;
			this.cmdSubstituteStepForSummarization.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdSubstituteStepForSummarization.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSubstituteStepForSummarization.CausesValidation = true;
			this.cmdSubstituteStepForSummarization.Enabled = true;
			this.cmdSubstituteStepForSummarization.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSubstituteStepForSummarization.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSubstituteStepForSummarization.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSubstituteStepForSummarization.TabStop = true;
			this.cmdSubstituteStepForSummarization.Name = "cmdSubstituteStepForSummarization";
			this.cmdMoveStepTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdMoveStepTo.Text = "Move To...";
			this.cmdMoveStepTo.Size = new System.Drawing.Size(52, 47);
			this.cmdMoveStepTo.Location = new System.Drawing.Point(12, 177);
			this.cmdMoveStepTo.TabIndex = 38;
			this.cmdMoveStepTo.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdMoveStepTo.BackColor = System.Drawing.SystemColors.Control;
			this.cmdMoveStepTo.CausesValidation = true;
			this.cmdMoveStepTo.Enabled = true;
			this.cmdMoveStepTo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdMoveStepTo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdMoveStepTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdMoveStepTo.TabStop = true;
			this.cmdMoveStepTo.Name = "cmdMoveStepTo";
			this.cmdModifyCriteriaSecondField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdModifyCriteriaSecondField.Text = "Modify Criteria Second Field";
			this.cmdModifyCriteriaSecondField.Size = new System.Drawing.Size(247, 23);
			this.cmdModifyCriteriaSecondField.Location = new System.Drawing.Point(298, 453);
			this.cmdModifyCriteriaSecondField.TabIndex = 39;
			this.cmdModifyCriteriaSecondField.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdModifyCriteriaSecondField.BackColor = System.Drawing.SystemColors.Control;
			this.cmdModifyCriteriaSecondField.CausesValidation = true;
			this.cmdModifyCriteriaSecondField.Enabled = true;
			this.cmdModifyCriteriaSecondField.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdModifyCriteriaSecondField.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdModifyCriteriaSecondField.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdModifyCriteriaSecondField.TabStop = true;
			this.cmdModifyCriteriaSecondField.Name = "cmdModifyCriteriaSecondField";
			this.cmdGroupStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGroupStep.Text = "Add \\ Edit Group Sets";
			this.cmdGroupStep.Size = new System.Drawing.Size(245, 22);
			this.cmdGroupStep.Location = new System.Drawing.Point(299, 402);
			this.cmdGroupStep.TabIndex = 40;
			this.cmdGroupStep.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdGroupStep.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGroupStep.CausesValidation = true;
			this.cmdGroupStep.Enabled = true;
			this.cmdGroupStep.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGroupStep.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGroupStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGroupStep.TabStop = true;
			this.cmdGroupStep.Name = "cmdGroupStep";
			this.cmdChangeAndBetweenGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdChangeAndBetweenGroup.Text = "Change And/Or of the Groups";
			this.cmdChangeAndBetweenGroup.Size = new System.Drawing.Size(245, 22);
			this.cmdChangeAndBetweenGroup.Location = new System.Drawing.Point(562, 429);
			this.cmdChangeAndBetweenGroup.TabIndex = 41;
			this.cmdChangeAndBetweenGroup.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdChangeAndBetweenGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cmdChangeAndBetweenGroup.CausesValidation = true;
			this.cmdChangeAndBetweenGroup.Enabled = true;
			this.cmdChangeAndBetweenGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdChangeAndBetweenGroup.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdChangeAndBetweenGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdChangeAndBetweenGroup.TabStop = true;
			this.cmdChangeAndBetweenGroup.Name = "cmdChangeAndBetweenGroup";
			this.cmdGoToStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGoToStep.Text = "Go To...";
			this.cmdGoToStep.Size = new System.Drawing.Size(125, 27);
			this.cmdGoToStep.Location = new System.Drawing.Point(254, 32);
			this.cmdGoToStep.TabIndex = 42;
			this.cmdGoToStep.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdGoToStep.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGoToStep.CausesValidation = true;
			this.cmdGoToStep.Enabled = true;
			this.cmdGoToStep.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGoToStep.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGoToStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGoToStep.TabStop = true;
			this.cmdGoToStep.Name = "cmdGoToStep";
			this.cmdView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdView.Text = "View Criteria";
			this.cmdView.Size = new System.Drawing.Size(103, 23);
			this.cmdView.Location = new System.Drawing.Point(613, 32);
			this.cmdView.TabIndex = 43;
			this.cmdView.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdView.BackColor = System.Drawing.SystemColors.Control;
			this.cmdView.CausesValidation = true;
			this.cmdView.Enabled = true;
			this.cmdView.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdView.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdView.TabStop = true;
			this.cmdView.Name = "cmdView";
			this.cmdDupSetLogic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdDupSetLogic.Text = "Create Duplicated Set Logic";
			this.cmdDupSetLogic.Size = new System.Drawing.Size(242, 22);
			this.cmdDupSetLogic.Location = new System.Drawing.Point(550, 680);
			this.cmdDupSetLogic.TabIndex = 44;
			this.cmdDupSetLogic.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.cmdDupSetLogic.BackColor = System.Drawing.SystemColors.Control;
			this.cmdDupSetLogic.CausesValidation = true;
			this.cmdDupSetLogic.Enabled = true;
			this.cmdDupSetLogic.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdDupSetLogic.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdDupSetLogic.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdDupSetLogic.TabStop = true;
			this.cmdDupSetLogic.Name = "cmdDupSetLogic";
			this._SSTabCriteria_TabPage1.Text = "Filter Criteria";
			this._cmdChangeAndOrCond_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeAndOrCond_1.Text = "Change And/Or of the Criteria";
			this._cmdChangeAndOrCond_1.Size = new System.Drawing.Size(244, 22);
			this._cmdChangeAndOrCond_1.Location = new System.Drawing.Point(230, 220);
			this._cmdChangeAndOrCond_1.TabIndex = 32;
			this._cmdChangeAndOrCond_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeAndOrCond_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeAndOrCond_1.CausesValidation = true;
			this._cmdChangeAndOrCond_1.Enabled = true;
			this._cmdChangeAndOrCond_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeAndOrCond_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeAndOrCond_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeAndOrCond_1.TabStop = true;
			this._cmdChangeAndOrCond_1.Name = "_cmdChangeAndOrCond_1";
			this._cmdCopyCriteria_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdCopyCriteria_1.Text = "Copy Criteria";
			this._cmdCopyCriteria_1.Size = new System.Drawing.Size(207, 22);
			this._cmdCopyCriteria_1.Location = new System.Drawing.Point(10, 245);
			this._cmdCopyCriteria_1.TabIndex = 13;
			this._cmdCopyCriteria_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdCopyCriteria_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCopyCriteria_1.CausesValidation = true;
			this._cmdCopyCriteria_1.Enabled = true;
			this._cmdCopyCriteria_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCopyCriteria_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdCopyCriteria_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCopyCriteria_1.TabStop = true;
			this._cmdCopyCriteria_1.Name = "_cmdCopyCriteria_1";
			this._cmdDelCriteria_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDelCriteria_1.Text = "Delete Criteria";
			this._cmdDelCriteria_1.Size = new System.Drawing.Size(102, 22);
			this._cmdDelCriteria_1.Location = new System.Drawing.Point(115, 220);
			this._cmdDelCriteria_1.TabIndex = 12;
			this._cmdDelCriteria_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDelCriteria_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDelCriteria_1.CausesValidation = true;
			this._cmdDelCriteria_1.Enabled = true;
			this._cmdDelCriteria_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDelCriteria_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDelCriteria_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDelCriteria_1.TabStop = true;
			this._cmdDelCriteria_1.Name = "_cmdDelCriteria_1";
			this._cmdAddCriteria_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdAddCriteria_1.Text = "Add Criteria";
			this._cmdAddCriteria_1.Size = new System.Drawing.Size(92, 22);
			this._cmdAddCriteria_1.Location = new System.Drawing.Point(10, 220);
			this._cmdAddCriteria_1.TabIndex = 11;
			this._cmdAddCriteria_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdAddCriteria_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdAddCriteria_1.CausesValidation = true;
			this._cmdAddCriteria_1.Enabled = true;
			this._cmdAddCriteria_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdAddCriteria_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdAddCriteria_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdAddCriteria_1.TabStop = true;
			this._cmdAddCriteria_1.Name = "_cmdAddCriteria_1";
			this._lstMeasureDef_1.Size = new System.Drawing.Size(818, 155);
			this._lstMeasureDef_1.Location = new System.Drawing.Point(20, 60);
			this._lstMeasureDef_1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this._lstMeasureDef_1.TabIndex = 10;
			this._lstMeasureDef_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._lstMeasureDef_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lstMeasureDef_1.BackColor = System.Drawing.SystemColors.Window;
			this._lstMeasureDef_1.CausesValidation = true;
			this._lstMeasureDef_1.Enabled = true;
			this._lstMeasureDef_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lstMeasureDef_1.IntegralHeight = true;
			this._lstMeasureDef_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lstMeasureDef_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lstMeasureDef_1.Sorted = false;
			this._lstMeasureDef_1.TabStop = true;
			this._lstMeasureDef_1.Visible = true;
			this._lstMeasureDef_1.MultiColumn = false;
			this._lstMeasureDef_1.Name = "_lstMeasureDef_1";
			this._Label4_1.Text = "Filter Criteria";
			this._Label4_1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label4_1.ForeColor = System.Drawing.Color.Blue;
			this._Label4_1.Size = new System.Drawing.Size(268, 22);
			this._Label4_1.Location = new System.Drawing.Point(10, 40);
			this._Label4_1.TabIndex = 15;
			this._Label4_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label4_1.BackColor = System.Drawing.SystemColors.Control;
			this._Label4_1.Enabled = true;
			this._Label4_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label4_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label4_1.UseMnemonic = true;
			this._Label4_1.Visible = true;
			this._Label4_1.AutoSize = false;
			this._Label4_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label4_1.Name = "_Label4_1";
			this._SSTabCriteria_TabPage2.Text = "Risk Criteria";
			this._cmdUp_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdUp_1.Text = "Move Step Up";
			this._cmdUp_1.Size = new System.Drawing.Size(52, 62);
			this._cmdUp_1.Location = new System.Drawing.Point(10, 60);
			this._cmdUp_1.TabIndex = 31;
			this._cmdUp_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdUp_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdUp_1.CausesValidation = true;
			this._cmdUp_1.Enabled = true;
			this._cmdUp_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdUp_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdUp_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdUp_1.TabStop = true;
			this._cmdUp_1.Name = "_cmdUp_1";
			this._cmdDown_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDown_1.Text = "Move Step Down";
			this._cmdDown_1.Size = new System.Drawing.Size(52, 62);
			this._cmdDown_1.Location = new System.Drawing.Point(10, 140);
			this._cmdDown_1.TabIndex = 30;
			this._cmdDown_1.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDown_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDown_1.CausesValidation = true;
			this._cmdDown_1.Enabled = true;
			this._cmdDown_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDown_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDown_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDown_1.TabStop = true;
			this._cmdDown_1.Name = "_cmdDown_1";
			this._cmdCopyCriteria_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdCopyCriteria_2.Text = "Copy Criteria";
			this._cmdCopyCriteria_2.Size = new System.Drawing.Size(222, 22);
			this._cmdCopyCriteria_2.Location = new System.Drawing.Point(10, 245);
			this._cmdCopyCriteria_2.TabIndex = 29;
			this._cmdCopyCriteria_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdCopyCriteria_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCopyCriteria_2.CausesValidation = true;
			this._cmdCopyCriteria_2.Enabled = true;
			this._cmdCopyCriteria_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCopyCriteria_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdCopyCriteria_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCopyCriteria_2.TabStop = true;
			this._cmdCopyCriteria_2.Name = "_cmdCopyCriteria_2";
			this._cmdCopyCriteriaSteps_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdCopyCriteriaSteps_2.Text = "Duplicate Criteria Step";
			this._cmdCopyCriteriaSteps_2.Size = new System.Drawing.Size(152, 22);
			this._cmdCopyCriteriaSteps_2.Location = new System.Drawing.Point(497, 220);
			this._cmdCopyCriteriaSteps_2.TabIndex = 28;
			this._cmdCopyCriteriaSteps_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdCopyCriteriaSteps_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCopyCriteriaSteps_2.CausesValidation = true;
			this._cmdCopyCriteriaSteps_2.Enabled = true;
			this._cmdCopyCriteriaSteps_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCopyCriteriaSteps_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdCopyCriteriaSteps_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCopyCriteriaSteps_2.TabStop = true;
			this._cmdCopyCriteriaSteps_2.Name = "_cmdCopyCriteriaSteps_2";
			this._cmdDelCriteria_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdDelCriteria_2.Text = "Delete Criteria";
			this._cmdDelCriteria_2.Size = new System.Drawing.Size(102, 22);
			this._cmdDelCriteria_2.Location = new System.Drawing.Point(130, 220);
			this._cmdDelCriteria_2.TabIndex = 27;
			this._cmdDelCriteria_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdDelCriteria_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdDelCriteria_2.CausesValidation = true;
			this._cmdDelCriteria_2.Enabled = true;
			this._cmdDelCriteria_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdDelCriteria_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdDelCriteria_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdDelCriteria_2.TabStop = true;
			this._cmdDelCriteria_2.Name = "_cmdDelCriteria_2";
			this._cmdAddCriteria_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdAddCriteria_2.Text = "Add Criteria";
			this._cmdAddCriteria_2.Size = new System.Drawing.Size(112, 22);
			this._cmdAddCriteria_2.Location = new System.Drawing.Point(10, 220);
			this._cmdAddCriteria_2.TabIndex = 26;
			this._cmdAddCriteria_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdAddCriteria_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdAddCriteria_2.CausesValidation = true;
			this._cmdAddCriteria_2.Enabled = true;
			this._cmdAddCriteria_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdAddCriteria_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdAddCriteria_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdAddCriteria_2.TabStop = true;
			this._cmdAddCriteria_2.Name = "_cmdAddCriteria_2";
			this._cmdChangeAndOrCond_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeAndOrCond_2.Text = "Change And/Or of the Criteria Set(s)";
			this._cmdChangeAndOrCond_2.Size = new System.Drawing.Size(244, 22);
			this._cmdChangeAndOrCond_2.Location = new System.Drawing.Point(240, 220);
			this._cmdChangeAndOrCond_2.TabIndex = 25;
			this._cmdChangeAndOrCond_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeAndOrCond_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeAndOrCond_2.CausesValidation = true;
			this._cmdChangeAndOrCond_2.Enabled = true;
			this._cmdChangeAndOrCond_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeAndOrCond_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeAndOrCond_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeAndOrCond_2.TabStop = true;
			this._cmdChangeAndOrCond_2.Name = "_cmdChangeAndOrCond_2";
			this._cmdChangeAddOrBetweenSets_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeAddOrBetweenSets_2.Text = "Change And/Or Between All the Sets";
			this._cmdChangeAddOrBetweenSets_2.Size = new System.Drawing.Size(244, 22);
			this._cmdChangeAddOrBetweenSets_2.Location = new System.Drawing.Point(240, 244);
			this._cmdChangeAddOrBetweenSets_2.TabIndex = 24;
			this._cmdChangeAddOrBetweenSets_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeAddOrBetweenSets_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeAddOrBetweenSets_2.CausesValidation = true;
			this._cmdChangeAddOrBetweenSets_2.Enabled = true;
			this._cmdChangeAddOrBetweenSets_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeAddOrBetweenSets_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeAddOrBetweenSets_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeAddOrBetweenSets_2.TabStop = true;
			this._cmdChangeAddOrBetweenSets_2.Name = "_cmdChangeAddOrBetweenSets_2";
			this._cmdCopyCriteriaSets_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdCopyCriteriaSets_2.Text = "Duplicate Criteria Set";
			this._cmdCopyCriteriaSets_2.Size = new System.Drawing.Size(142, 22);
			this._cmdCopyCriteriaSets_2.Location = new System.Drawing.Point(657, 220);
			this._cmdCopyCriteriaSets_2.TabIndex = 23;
			this._cmdCopyCriteriaSets_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdCopyCriteriaSets_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdCopyCriteriaSets_2.CausesValidation = true;
			this._cmdCopyCriteriaSets_2.Enabled = true;
			this._cmdCopyCriteriaSets_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdCopyCriteriaSets_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdCopyCriteriaSets_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdCopyCriteriaSets_2.TabStop = true;
			this._cmdCopyCriteriaSets_2.Name = "_cmdCopyCriteriaSets_2";
			this._cmdChangeCategoryofSet_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdChangeCategoryofSet_2.Text = "Change Category of the Criteria Step";
			this._cmdChangeCategoryofSet_2.Size = new System.Drawing.Size(302, 22);
			this._cmdChangeCategoryofSet_2.Location = new System.Drawing.Point(497, 244);
			this._cmdChangeCategoryofSet_2.TabIndex = 22;
			this._cmdChangeCategoryofSet_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._cmdChangeCategoryofSet_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdChangeCategoryofSet_2.CausesValidation = true;
			this._cmdChangeCategoryofSet_2.Enabled = true;
			this._cmdChangeCategoryofSet_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdChangeCategoryofSet_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdChangeCategoryofSet_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdChangeCategoryofSet_2.TabStop = true;
			this._cmdChangeCategoryofSet_2.Name = "_cmdChangeCategoryofSet_2";
			this._lstMeasureDef_2.Size = new System.Drawing.Size(768, 155);
			this._lstMeasureDef_2.Location = new System.Drawing.Point(70, 60);
			this._lstMeasureDef_2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this._lstMeasureDef_2.TabIndex = 20;
			this._lstMeasureDef_2.Font = new System.Drawing.Font("Arial", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._lstMeasureDef_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._lstMeasureDef_2.BackColor = System.Drawing.SystemColors.Window;
			this._lstMeasureDef_2.CausesValidation = true;
			this._lstMeasureDef_2.Enabled = true;
			this._lstMeasureDef_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._lstMeasureDef_2.IntegralHeight = true;
			this._lstMeasureDef_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._lstMeasureDef_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lstMeasureDef_2.Sorted = false;
			this._lstMeasureDef_2.TabStop = true;
			this._lstMeasureDef_2.Visible = true;
			this._lstMeasureDef_2.MultiColumn = false;
			this._lstMeasureDef_2.Name = "_lstMeasureDef_2";
			this._Label4_2.Text = "Risk Criteria";
			this._Label4_2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this._Label4_2.ForeColor = System.Drawing.Color.Blue;
			this._Label4_2.Size = new System.Drawing.Size(268, 22);
			this._Label4_2.Location = new System.Drawing.Point(10, 40);
			this._Label4_2.TabIndex = 21;
			this._Label4_2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._Label4_2.BackColor = System.Drawing.SystemColors.Control;
			this._Label4_2.Enabled = true;
			this._Label4_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Label4_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Label4_2.UseMnemonic = true;
			this._Label4_2.Visible = true;
			this._Label4_2.AutoSize = false;
			this._Label4_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Label4_2.Name = "_Label4_2";
			dbgMeasureList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("dbgMeasureList.OcxState");
			this.dbgMeasureList.Size = new System.Drawing.Size(849, 260);
			this.dbgMeasureList.Location = new System.Drawing.Point(20, 32);
			this.dbgMeasureList.TabIndex = 0;
			this.dbgMeasureList.Name = "dbgMeasureList";
			rdcMeasureList.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("rdcMeasureList.OcxState");
			this.rdcMeasureList.Size = new System.Drawing.Size(197, 28);
			this.rdcMeasureList.Location = new System.Drawing.Point(0, 30);
			this.rdcMeasureList.Visible = false;
			this.rdcMeasureList.Name = "rdcMeasureList";
			this.Label4.SetIndex(_Label4_2, Convert.ToInt16(2));
			this.Label4.SetIndex(_Label4_1, Convert.ToInt16(1));
			this.Label4.SetIndex(_Label4_0, Convert.ToInt16(0));
			this.cmdAddCriteria.SetIndex(_cmdAddCriteria_2, Convert.ToInt16(2));
			this.cmdAddCriteria.SetIndex(_cmdAddCriteria_1, Convert.ToInt16(1));
			this.cmdAddCriteria.SetIndex(_cmdAddCriteria_0, Convert.ToInt16(0));
			this.cmdChangeAddOrBetweenSets.SetIndex(_cmdChangeAddOrBetweenSets_2, Convert.ToInt16(2));
			this.cmdChangeAddOrBetweenSets.SetIndex(_cmdChangeAddOrBetweenSets_0, Convert.ToInt16(0));
			this.cmdChangeAndOrCond.SetIndex(_cmdChangeAndOrCond_1, Convert.ToInt16(1));
			this.cmdChangeAndOrCond.SetIndex(_cmdChangeAndOrCond_2, Convert.ToInt16(2));
			this.cmdChangeAndOrCond.SetIndex(_cmdChangeAndOrCond_0, Convert.ToInt16(0));
			this.cmdChangeCategoryofSet.SetIndex(_cmdChangeCategoryofSet_2, Convert.ToInt16(2));
			this.cmdChangeCategoryofSet.SetIndex(_cmdChangeCategoryofSet_0, Convert.ToInt16(0));
			this.cmdCopyCriteria.SetIndex(_cmdCopyCriteria_2, Convert.ToInt16(2));
			this.cmdCopyCriteria.SetIndex(_cmdCopyCriteria_1, Convert.ToInt16(1));
			this.cmdCopyCriteria.SetIndex(_cmdCopyCriteria_0, Convert.ToInt16(0));
			this.cmdCopyCriteriaSets.SetIndex(_cmdCopyCriteriaSets_2, Convert.ToInt16(2));
			this.cmdCopyCriteriaSets.SetIndex(_cmdCopyCriteriaSets_0, Convert.ToInt16(0));
			this.cmdCopyCriteriaSteps.SetIndex(_cmdCopyCriteriaSteps_2, Convert.ToInt16(2));
			this.cmdCopyCriteriaSteps.SetIndex(_cmdCopyCriteriaSteps_0, Convert.ToInt16(0));
			this.cmdDelCriteria.SetIndex(_cmdDelCriteria_2, Convert.ToInt16(2));
			this.cmdDelCriteria.SetIndex(_cmdDelCriteria_1, Convert.ToInt16(1));
			this.cmdDelCriteria.SetIndex(_cmdDelCriteria_0, Convert.ToInt16(0));
			this.cmdDown.SetIndex(_cmdDown_1, Convert.ToInt16(1));
			this.cmdDown.SetIndex(_cmdDown_0, Convert.ToInt16(0));
			this.cmdUp.SetIndex(_cmdUp_1, Convert.ToInt16(1));
			this.cmdUp.SetIndex(_cmdUp_0, Convert.ToInt16(0));
			this.lstMeasureDef.SetIndex(_lstMeasureDef_2, Convert.ToInt16(2));
			this.lstMeasureDef.SetIndex(_lstMeasureDef_0, Convert.ToInt16(0));
			this.lstMeasureDef.SetIndex(_lstMeasureDef_1, Convert.ToInt16(1));
			((System.ComponentModel.ISupportInitialize)this.lstMeasureDef).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdUp).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdDown).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdDelCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdCopyCriteriaSteps).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdCopyCriteriaSets).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdCopyCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeCategoryofSet).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAndOrCond).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdChangeAddOrBetweenSets).EndInit();
			((System.ComponentModel.ISupportInitialize)this.cmdAddCriteria).EndInit();
			((System.ComponentModel.ISupportInitialize)this.Label4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.rdcMeasureList).EndInit();
			((System.ComponentModel.ISupportInitialize)this.dbgMeasureList).EndInit();
			this.Controls.Add(cmdPrint);
			this.Controls.Add(SSTabCriteria);
			this.Controls.Add(dbgMeasureList);
			this.Controls.Add(rdcMeasureList);
			this.SSTabCriteria.Controls.Add(_SSTabCriteria_TabPage0);
			this.SSTabCriteria.Controls.Add(_SSTabCriteria_TabPage1);
			this.SSTabCriteria.Controls.Add(_SSTabCriteria_TabPage2);
			this._SSTabCriteria_TabPage0.Controls.Add(_Label4_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdCopyCriteria_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdCopyCriteriaSteps_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdDelCriteria_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdAddCriteria_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdUp_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdDown_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdChangeAndOrCond_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdChangeAddOrBetweenSets_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdCopyCriteriaSets_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_cmdChangeCategoryofSet_0);
			this._SSTabCriteria_TabPage0.Controls.Add(_lstMeasureDef_0);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdDupMeasure);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdModifyCriteriaField);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdModifyCriteriaOperator);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdModifyCriteriaValue);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdSubstituteStepForSummarization);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdMoveStepTo);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdModifyCriteriaSecondField);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdGroupStep);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdChangeAndBetweenGroup);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdGoToStep);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdView);
			this._SSTabCriteria_TabPage0.Controls.Add(cmdDupSetLogic);
			this._SSTabCriteria_TabPage1.Controls.Add(_cmdChangeAndOrCond_1);
			this._SSTabCriteria_TabPage1.Controls.Add(_cmdCopyCriteria_1);
			this._SSTabCriteria_TabPage1.Controls.Add(_cmdDelCriteria_1);
			this._SSTabCriteria_TabPage1.Controls.Add(_cmdAddCriteria_1);
			this._SSTabCriteria_TabPage1.Controls.Add(_lstMeasureDef_1);
			this._SSTabCriteria_TabPage1.Controls.Add(_Label4_1);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdUp_1);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdDown_1);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdCopyCriteria_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdCopyCriteriaSteps_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdDelCriteria_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdAddCriteria_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdChangeAndOrCond_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdChangeAddOrBetweenSets_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdCopyCriteriaSets_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_cmdChangeCategoryofSet_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_lstMeasureDef_2);
			this._SSTabCriteria_TabPage2.Controls.Add(_Label4_2);
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuCreate,
				this.mnuShow,
				this.mnuDuplicate,
				this.mnuModify,
				this.mnuChange,
				this.mnuDelete,
				this.mnuSync
			});
			mnuCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuCreateSubsitute,
				this.mnuCreateDuplicate,
				this.mnuCreateGroupLogic
			});
			mnuShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuShowGroupLogic });
			mnuDuplicate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuDuplicateMeasure,
				this.mnuDuplicateStep,
				this.mnuDuplicateSet,
				this.mnuCopyCriteria
			});
			mnuModify.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuModifyField,
				this.mnuModify2ndField,
				this.mnuModifyOperator,
				this.mnuModifyValue,
				this.mnuFlowchartAction
			});
			mnuChange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuChangeCategory,
				this.mnuChangeJoinOpGroup,
				this.mnuChangeJoinOpCriteria,
				this.mnuChangeJoinOpSet
			});
			mnuDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.mnuDeleteMeasureFlowchartLogic,
				this.mnuDeleteFlowchartAction,
				this.mnuDeleteCriteria
			});
			mnuSync.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuSyncMeasure });
			this.Controls.Add(MainMenu1);
			this.MainMenu1.ResumeLayout(false);
			this.SSTabCriteria.ResumeLayout(false);
			this._SSTabCriteria_TabPage0.ResumeLayout(false);
			this._SSTabCriteria_TabPage1.ResumeLayout(false);
			this._SSTabCriteria_TabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
	}
}
