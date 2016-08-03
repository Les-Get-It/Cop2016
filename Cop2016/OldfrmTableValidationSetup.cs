using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
 // ERROR: Not supported in C#: OptionDeclaration
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
namespace COP2001
{
	internal partial class OldfrmTableValidationSetup : System.Windows.Forms.Form
	{
		object thismsgtype;
		object printval;
//UPGRADE_WARNING: Event cboTableList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboTableList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			RefreshValidationMessages();

			if (rdcValidationErrors.Resultset.RowCount > 0) {
				rdcValidationErrors.Resultset.MoveFirst();
			} else {
				RefreshErrorCriteriaSet();
				RefreshErrorAction();
			}
			if (rdcValidationWarnings.Resultset.RowCount > 0) {
				rdcValidationWarnings.Resultset.MoveFirst();
			} else {
				RefreshWarningCriteriaSet();
				RefreshWarningAction();
			}

			sstabValidation.Enabled = true;

		}

		private void cmdAddError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "ERROR";
			My.MyProject.Forms.frmTableValidationAddMsg.ShowDialog();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Add") {
				RefreshValidationMessages();
			}
		}

		private void cmdAddErroraction_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (rdcValidationErrors.Resultset.RowCount == 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "ERROR";
			My.MyProject.Forms.frmTableValidationAddAction.ShowDialog();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Update") {
				RefreshErrorAction();
			}
		}

		private void cmdAddWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "WARNING";
			My.MyProject.Forms.frmTableValidationAddMsg.ShowDialog();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Add") {
				RefreshValidationMessages();
			}
		}

		private void cmdAddWarningAction_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationWarnings.Resultset.RowCount == 0) {
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "WARNING";
			My.MyProject.Forms.frmTableValidationAddAction.ShowDialog();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Update") {
				RefreshWarningAction();
			}
		}

		private void cmdChangeErrorStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			object MoveToModule = null;
			if (rdcValidationErrors.Resultset.RowCount == 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = Interaction.MsgBox("Are you sure you want this Error to the " + MoveToModule + " Module?", MsgBoxStyle.YesNo);
			if (resp == MsgBoxResult.No) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_TablevalidationMessage ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
			modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID = " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			RefreshValidationMessages();
			RefreshErrorCriteria();
			RefreshErrorCriteriaSet();
			RefreshErrorAction();

		}

		private void cmdChangemainjoinop_Click()
		{
		}

		private void cmdChangeToError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationWarnings.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to change this Warning to an Error?", MsgBoxStyle.YesNo, "Delete Criteria"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {
				modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set MessageType = 'ERROR' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageID = " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshValidationMessages();
				RefreshWarningCriteria();
				RefreshWarningAction();
				RefreshErrorCriteria();
				RefreshErrorAction();
			}
		}

		private void cmdChangeToWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationErrors.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to change this Error to an Warning?", MsgBoxStyle.YesNo, "Delete Criteria"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {
				modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set MessageType = 'WARNING' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid = " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshValidationMessages();
				RefreshWarningCriteria();
				RefreshWarningAction();
				RefreshErrorCriteria();
				RefreshErrorAction();
			}
		}

		private void cmdChangeWarningStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			object MoveToModule = null;
			if (rdcValidationWarnings.Resultset.RowCount == 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = Interaction.MsgBox("Are you sure you want this Warning to the " + MoveToModule + " Module?", MsgBoxStyle.YesNo);
			if (resp == MsgBoxResult.No) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_TablevalidationMessage ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
			modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageid = " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			RefreshValidationMessages();
			RefreshWarningCriteria();
			RefreshWarningCriteriaSet();
			RefreshWarningAction();

		}

		private void cmdDelError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationErrors.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to delete this error?", MsgBoxStyle.YesNo, "Delete Error"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {

				modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid =  " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//gv_sql = "Delete tbl_setup_TableValidationAfterFieldUpdate "
				//gv_sql = gv_sql & " Where TableValidationMessageid =  " & rdcValidationErrors.Resultset!TableValidationMessageID
				//gv_cn.Execute gv_sql

				modGlobal.gv_sql = "Delete tbl_setup_TableValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid =  " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				modGlobal.gv_sql = "Delete tbl_setup_TableValidationAction ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid =  " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshValidationMessages();
				RefreshErrorCriteria();
				RefreshErrorCriteriaSet();
				RefreshErrorAction();
			}
		}

		private void cmdDeleteAction_Click()
		{

		}

		private void cmdDeleteErrorAction_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationErrorAction.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to delete this action?", MsgBoxStyle.YesNo, "Delete Action"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {

				modGlobal.gv_sql = "Delete tbl_setup_TableValidationAction ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationActionid =  " + rdcValidationErrorAction.Resultset.rdoColumns["TableValidationActionID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshErrorAction();
			}
		}

		private void cmdDeleteWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationWarnings.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to delete this warning?", MsgBoxStyle.YesNo, "Delete Warning"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {

				modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid =  " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				modGlobal.gv_sql = "Delete tbl_setup_TableValidationAfterFieldUpdate ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid =  " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);


				modGlobal.gv_sql = "Delete tbl_setup_TableValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid =  " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				modGlobal.gv_sql = "Delete tbl_setup_TableValidationAction ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageid =  " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshValidationMessages();
				RefreshWarningCriteria();
				RefreshWarningCriteriaSet();
				RefreshWarningAction();

			}
		}

		private void cmdDeleteWarningAction_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationWarningAction.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to delete this action?", MsgBoxStyle.YesNo, "Warning Action"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {

				modGlobal.gv_sql = "Delete tbl_setup_TableValidationAction ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationActionid =  " + rdcValidationWarningAction.Resultset.rdoColumns["TableValidationActionID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshWarningAction();
			}
		}

		private void cmdPrintVal_Click()
		{
			PrintValidation();
		}

		private void cmdDupError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationErrors.Resultset.RowCount <= 0) {
				Interaction.MsgBox("Select one criteria set to copy.");
				return;
			}


			DuplicateMessage(ref this.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value, ref "ERROR");

			RefreshValidationMessages();
			RefreshErrorCriteria();


		}

		private void DuplicateMessage(ref short TableValidationMessageID, ref string MessageType)
		{
			object ps = null;

			if (Interaction.MsgBox("Are you sure you want to duplicate?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {

				modGlobal.gv_sql = "{ ? = call COPYTableValidationToError(?,?) }";
				ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps(0).Direction = RDO.DirectionConstants.rdParamReturnValue;
				//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps(1).Direction = RDO.DirectionConstants.rdParamInput;
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.rdoParameters. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.rdoParameters(1) = TableValidationMessageID;
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.rdoParameters. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.rdoParameters(2) = MessageType;
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.Execute();
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.Close();

			}

		}

		private void cmdDupWarn_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationErrors.Resultset.RowCount <= 0) {
				Interaction.MsgBox("Select one criteria set to copy.");
				return;
			}

			DuplicateMessage(ref this.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value, ref "WARNING");

			RefreshValidationMessages();
			RefreshWarningCriteria();
		}

		private void cmdErrorCopySet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to copy");
				return;
			}


			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to COPY this criteria?", MsgBoxStyle.YesNo, "COPY Criteria"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {
				My.MyProject.Forms.frmValidationCopyCriteriaSet.SetTableValidationID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex));
				My.MyProject.Forms.frmValidationCopyCriteriaSet.ShowDialog();


				RefreshErrorCriteriaSet();
			}
			return;
		}

		private void cmdExportValidation_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboTableList.SelectedIndex < 0) {
				return;
			}
			modDocumentation.PrintTableValidation(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
		}


		private void cmdRightLookup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}


			My.MyProject.Forms.dlgValidationRightField.SetTableValidationID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex));
			My.MyProject.Forms.dlgValidationRightField.ShowDialog();

			//RefreshMeasureCriteria

			RefreshErrorCriteriaSet();
		}

		private void cmdUpdateError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationErrors.Resultset.RowCount <= 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "ERROR";
			My.MyProject.Forms.frmTableValidationUpdateMsg.ShowDialog();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Update") {
				RefreshValidationMessages();
				RefreshErrorCriteria();
			}
		}

		private void cmdUpdateWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationWarnings.Resultset.RowCount <= 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "WARNING";
			My.MyProject.Forms.frmTableValidationUpdateMsg.ShowDialog();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Update") {
				RefreshValidationMessages();
				RefreshWarningCriteria();
			}
		}

		private void cmdValidErrorAddCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationErrors.Resultset.RowCount == 0) {
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Error";
			My.MyProject.Forms.frmTableValidationAddCrit.ShowDialog();
			RefreshErrorCriteriaSet();
		}

		private void cmdValidErrorAddCritAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "ERROR";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_ANDOR = "AND";
			My.MyProject.Forms.frmTableValidationAddCrit.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Add") {
				RefreshErrorCriteriaSet();
			}
		}

		private void cmdValidErrorAddCritOr_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "ERROR";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_ANDOR = "OR";
			My.MyProject.Forms.frmTableValidationAddCrit.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Add") {
				RefreshErrorCriteriaSet();
			}

		}

		private void cmdValidErrorChangemainjoinop_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newjoinop = null;
			object mainjoinop = null;

			if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}


			modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
				return;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mainjoinop = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (mainjoinop == "OR") {
				//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newjoinop = "AND";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newjoinop = "OR";
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to change the Join Operator from " + mainjoinop + " to " + newjoinop + "?", MsgBoxStyle.YesNo, "Change to And/Or between sets"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {
				modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
				//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + newjoinop + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageID = " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				RefreshErrorCriteriaSet();
			}



		}

		private void cmdValidErrorDeleteCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short li_cnt = 0;

			if (lstErrorCriteriaSet.SelectedItems.Count == 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to delete this criteria?", MsgBoxStyle.YesNo, "Delete Criteria"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {

				//loop through all selected criteria
				for (li_cnt = 0; li_cnt <= lstErrorCriteriaSet.Items.Count - 1; li_cnt++) {

					if (lstErrorCriteriaSet.GetSelected(li_cnt)) {
						modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
						modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstErrorCriteriaSet, li_cnt);

						modGlobal.gv_cn.Execute(modGlobal.gv_sql);


					}

				}

				RefreshErrorCriteriaSet();

			}
			return;

			//    If rdcValidationErrorCriteria.Resultset.RowCount <= 0 Then
			//        Exit Sub
			//    End If
			//
			//    gv_resp = MsgBox("Are you sure you want to delete this criteria?", vbYesNo, "Delete Criteria")
			//    If gv_resp = vbYes Then
			//        gv_sql = "Delete tbl_setup_TableValidation "
			//        gv_sql = gv_sql & " Where TableValidationID = " & rdcValidationErrorCriteria.Resultset!TableValidationID
			//
			//        gv_cn.Execute gv_sql
			//
			//        RefreshErrorCriteriaSet
			//    End If


		}

		private void cmdValidErrorEditLeft_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}

			My.MyProject.Forms.dlgValidationField.SetTableValidationID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex));
			My.MyProject.Forms.dlgValidationField.ShowDialog();

			//RefreshMeasureCriteria

			RefreshErrorCriteriaSet();

		}

		private void cmdValidWarningAddCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcValidationWarnings.Resultset.RowCount == 0) {
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Warning";
			My.MyProject.Forms.frmTableValidationAddCrit.ShowDialog();
			RefreshWarningCriteriaSet();

		}

		private void cmdValidWarningAddCritAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "WARNING";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_ANDOR = "AND";
			My.MyProject.Forms.frmTableValidationAddCrit.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Add") {
				RefreshWarningCriteriaSet();
			}

		}

		private void cmdValidWarningAddCritOr_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "WARNING";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_ANDOR = "OR";
			My.MyProject.Forms.frmTableValidationAddCrit.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Add") {
				RefreshWarningCriteriaSet();
			}

		}

		private void cmdValidWarningChangemainjoinop_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newjoinop = null;
			object mainjoinop = null;
			if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}

			modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
				return;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mainjoinop = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (mainjoinop == "OR") {
				//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newjoinop = "AND";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newjoinop = "OR";
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to change the Join Operator from " + mainjoinop + " to " + newjoinop + "?", MsgBoxStyle.YesNo, "Change to And/Or between sets"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {
				modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
				//UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + newjoinop + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageID = " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				RefreshWarningCriteriaSet();
			}


		}

		private void cmdValidWarningDeleteCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object li_cnt = null;
			if (lstWarningCriteriaSet.SelectedItems.Count == 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to delete this criteria?", MsgBoxStyle.YesNo, "Delete Criteria"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {

				//loop through all selected criteria
				for (li_cnt = 0; li_cnt <= lstWarningCriteriaSet.Items.Count - 1; li_cnt++) {

					if (lstWarningCriteriaSet.GetSelected(li_cnt)) {
						modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
						modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstWarningCriteriaSet, li_cnt);

						modGlobal.gv_cn.Execute(modGlobal.gv_sql);
					}
				}

				RefreshWarningCriteriaSet();
			}

		}

		private void cmdValidWarningEditLeft_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}

			My.MyProject.Forms.dlgValidationField.SetTableValidationID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex));
			My.MyProject.Forms.dlgValidationField.ShowDialog();

			//RefreshMeasureCriteria

			RefreshErrorCriteriaSet();
		}

		private void cmdWarnCopySet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to copy");
				return;
			}

			modGlobal.gv_resp = Convert.ToString(Interaction.MsgBox("Are you sure you want to COPY this criteria?", MsgBoxStyle.YesNo, "COPY Criteria"));
			if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes)) {
				My.MyProject.Forms.frmValidationCopyCriteriaSet.SetTableValidationID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex));
				My.MyProject.Forms.frmValidationCopyCriteriaSet.ShowDialog();


				RefreshWarningCriteriaSet();
			}

		}

		private void CmdWarningRight_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}

			My.MyProject.Forms.dlgValidationRightField.SetTableValidationID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex));
			My.MyProject.Forms.dlgValidationRightField.ShowDialog();

			//RefreshMeasureCriteria

			RefreshErrorCriteriaSet();
		}

		private void cmdWarningDupError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (rdcValidationWarnings.Resultset.RowCount <= 0) {
				Interaction.MsgBox("Select one Message to copy.");
				return;
			}

			DuplicateMessage(ref rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value, ref "ERROR");

			RefreshValidationMessages();
			RefreshErrorCriteria();
		}

		private void cmdWarningDupWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (rdcValidationWarnings.Resultset.RowCount <= 0) {
				Interaction.MsgBox("Select one Message to copy.");
				return;
			}

			DuplicateMessage(ref rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value, ref "WARNING");

			RefreshValidationMessages();
			RefreshWarningCriteria();
		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Printer Printer = new Printer();
			short Index = 0;
			int li_cnt = 0;

			if (sstabValidation.SelectedIndex == 0) {
				//Printer.Print rdcValidationErrors.Resultset!Message
				//UPGRADE_WARNING: Couldn't resolve default property of object dbgSubmitErrors.Columns().Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Printer.Print(dbgSubmitErrors.get_Columns(1).Text);

				for (li_cnt = 0; li_cnt <= lstErrorCriteriaSet.Items.Count - 1; li_cnt++) {
					Printer.Print(FileSystem.TAB(15), Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstErrorCriteriaSet, li_cnt));
				}
			} else {
				//Printer.Print rdcValidationWarnings.Resultset!Message
				//UPGRADE_WARNING: Couldn't resolve default property of object dbgSubmitWarnings.Columns().Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Printer.Print(dbgSubmitWarnings.get_Columns(1).Text);

				for (li_cnt = 0; li_cnt <= lstWarningCriteriaSet.Items.Count - 1; li_cnt++) {
					Printer.Print(FileSystem.TAB(15), Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstWarningCriteriaSet, li_cnt));
				}
			}


			Printer.Print("End of Validation");
			Printer.EndDoc();
		}

		private void frmTableValidationSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			sstabValidation.SelectedIndex = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object printval. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			printval = "";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_status == "TEST") {
				cmdChangeWarningStatus.Text = "Move to Active";
				cmdChangeErrorStatus.Text = "Move to Active";
			} else {
				cmdChangeWarningStatus.Text = "Move to Test";
				cmdChangeErrorStatus.Text = "Move to Test";
			}

			RefreshDataTableList();
			sstabValidation.Enabled = false;
		}
		public void RefreshWarningCriteria()
		{
			object TotalRec = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalRec = 0;

			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidation ";
			if (rdcValidationWarnings.Resultset.AbsolutePosition > 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID =  " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID =  -1";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				modGlobal.gv_rs.MoveLast();
				//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TotalRec = modGlobal.gv_rs.RowCount;
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgSubmitWarnings.CtlRefresh();
			rdcValidationWarningCriteria.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcValidationWarningCriteria.CtlRefresh();

			//when there is only one criteria the next choice should be
			//defined by selecting AND or OR buttons
			//otherwise the join operator has already been defined from the previous selection
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (TotalRec == 1) {
				cmdValidWarningAddCritAnd.Enabled = true;
				cmdValidWarningAddCritOr.Enabled = true;
				cmdValidWarningAddCrit.Enabled = false;
			} else {
				cmdValidWarningAddCritAnd.Enabled = false;
				cmdValidWarningAddCritOr.Enabled = false;
				cmdValidWarningAddCrit.Enabled = true;
			}




		}
		public void RefreshValidationMessages()
		{

			//retrieve the list of Validation Error messages
			modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and state = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'ERROR' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
			// 3.17.2005 - order by message

			rdcValidationErrors.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcValidationErrors.CtlRefresh();


			//retrieve the list of Validation Warning messages
			modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and state = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'WARNING' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
			//3.17.2005 = order by message

			rdcValidationWarnings.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcValidationWarnings.CtlRefresh();

		}

		public void RefreshErrorCriteria()
		{
			object TotalRec = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalRec = 0;

			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidation ";
			if (rdcValidationErrors.Resultset.AbsolutePosition > 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID =  " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID =  -1";
			}
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				modGlobal.gv_rs.MoveLast();
				//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TotalRec = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveLast();
			}
			modGlobal.gv_rs.Close();



			//dbgValidationErrorCriteria.Refresh
			//Set rdcValidationErrorCriteria.Resultset = gv_cn.OpenResultset(gv_sql, rdOpenStatic)

			//when there is only one criteria the next choice should be
			//defined by selecting AND or OR buttons
			//otherwise the join operator has already been defined from the previous selection
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (TotalRec == 1) {
				cmdValidErrorAddCritAnd.Enabled = true;
				cmdValidErrorAddCritOr.Enabled = true;
				cmdValidErrorAddCrit.Enabled = false;
				cmdValidErrorChangemainjoinop.Enabled = false;
			} else {
				cmdValidErrorAddCritAnd.Enabled = false;
				cmdValidErrorAddCritOr.Enabled = false;
				cmdValidErrorAddCrit.Enabled = true;
				cmdValidErrorChangemainjoinop.Enabled = true;
			}



		}

		public void RefreshDataTableList()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			//retrieve the list of batch types
			modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where TableType is null or TableType = 'DATA' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

			//rdcTableList.Refresh
			rdcTableList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcTableList.CtlRefresh();

			cboTableList.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!rdcTableList.Resultset.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Table_ListIndex = LIndex;

				cboTableList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcTableList.Resultset.rdoColumns["BaseTable"].Value, rdcTableList.Resultset.rdoColumns["basetableid"].Value));
				rdcTableList.Resultset.MoveNext();
			}

		}

		private void rdcValidationErrors_Reposition()
		{
			RefreshErrorCriteriaSet();
			RefreshErrorAction();
		}

		private void rdcValidationWarnings_Reposition()
		{
			RefreshWarningCriteriaSet();
			RefreshWarningAction();
		}

		private void SSTab1_DblClick()
		{

		}

		public void RefreshWarningAction()
		{
			object TotalRec = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalRec = 0;

			modGlobal.gv_sql = "Select tv.*, dd.fieldname + ' = ' + tv.setvalue as TakeAction ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationAction as tv,  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_DataDef as dd  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tv.ddid = dd.ddid ";
			if (rdcValidationWarnings.Resultset.AbsolutePosition > 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tv.TableValidationMessageID =  " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tv.TableValidationMessageID =  -1";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				modGlobal.gv_rs.MoveLast();
				//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TotalRec = modGlobal.gv_rs.RowCount;
			}
			modGlobal.gv_rs.Close();


			rdcValidationWarningAction.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcValidationWarningAction.CtlRefresh();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgValidationWarningAction.CtlRefresh();

		}

		public void RefreshErrorAction()
		{
			object TotalRec = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalRec = 0;

			modGlobal.gv_sql = "Select tv.*, dd.fieldname + ' = ' + tv.setvalue as TakeAction ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationAction as tv,  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_DataDef as dd  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tv.ddid = dd.ddid ";
			if (rdcValidationErrors.Resultset.AbsolutePosition > 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tv.TableValidationMessageID =  " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tv.TableValidationMessageID =  -1";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				modGlobal.gv_rs.MoveLast();
				//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TotalRec = modGlobal.gv_rs.RowCount;
			}
			modGlobal.gv_rs.Close();


			rdcValidationErrorAction.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcValidationErrorAction.CtlRefresh();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgValidationErrorAction.CtlRefresh();

		}

		public void RefreshErrorCriteriaSet()
		{
			object CPref = null;
			object CSuff = null;
			object Cindex = null;
			object TotalRec = null;
			object SetCount = null;
			object SetIndex = null;
			object TotalSetRec = null;
			object mainjoinop = null;
			lstErrorCriteriaSet.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mainjoinop = "";
			object rs_critSet = null;
			modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_TableValidation ";
			if (rdcValidationErrors.Resultset.RowCount == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = -1";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;

			}
			modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

			rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (rs_critSet.RowCount == 0) {
				cmdValidErrorAddCritAnd.Enabled = false;
				cmdValidErrorAddCritOr.Enabled = false;
				cmdValidErrorAddCrit.Enabled = true;
				cmdValidErrorChangemainjoinop.Enabled = true;
				return;
			}


			if (rdcValidationErrors.Resultset.RowCount > 0) {
				modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					mainjoinop = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs_critSet.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalSetRec = rs_critSet.RowCount;
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs_critSet.MoveFirst();

			//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetIndex = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetCount = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			while (!rs_critSet.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SetIndex = SetIndex - 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SetCount = SetCount + 1;

				modGlobal.gv_sql = "Select * from tbl_setup_tablevalidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet!CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + rs_critSet["CriteriaSet"];
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				modGlobal.gv_rs.MoveLast();
				//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TotalRec = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveFirst();
				//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Cindex = 0;
				//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CSuff = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CPref = "Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value + ": (";

				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Cindex = Cindex + 1;
					//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Cindex == TotalRec) {
						//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (TotalRec == 1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							CSuff = " (" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + ") )";
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							CSuff = ")";
						}
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CSuff = " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Cindex == 1) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstErrorCriteriaSet.Items.Add(CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstErrorCriteriaSet.Items.Add("          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
					}
					//UPGRADE_ISSUE: ListBox property lstErrorCriteriaSet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.NewIndex, modGlobal.gv_rs.rdoColumns["TableValidationID"].Value);


					modGlobal.gv_rs.MoveNext();
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (SetCount == TotalSetRec) {
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstErrorCriteriaSet.Items.Add(mainjoinop);
					//"And"
					//UPGRADE_ISSUE: ListBox property lstErrorCriteriaSet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.NewIndex, SetIndex);
				}


				//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs_critSet.MoveNext();

			}


			//when there is only one criteria the next choice should be
			//defined by selecting AND or OR buttons
			//otherwise the join operator has already been defined from the previous selection
			if (lstErrorCriteriaSet.Items.Count == 1) {
				cmdValidErrorAddCritAnd.Enabled = true;
				cmdValidErrorAddCritOr.Enabled = true;
				cmdValidErrorAddCrit.Enabled = false;
				cmdValidErrorChangemainjoinop.Enabled = false;
			} else {
				cmdValidErrorAddCritAnd.Enabled = false;
				cmdValidErrorAddCritOr.Enabled = false;
				cmdValidErrorAddCrit.Enabled = true;
				cmdValidErrorChangemainjoinop.Enabled = true;
			}


		}

		public void RefreshWarningCriteriaSet()
		{
			object CPref = null;
			object CSuff = null;
			object Cindex = null;
			object TotalRec = null;
			object SetCount = null;
			object SetIndex = null;
			object TotalSetRec = null;
			object mainjoinop = null;
			lstWarningCriteriaSet.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mainjoinop = "";
			object rs_critSet = null;
			modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_TableValidation ";
			if (rdcValidationWarnings.Resultset.RowCount == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = -1";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

			rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (rs_critSet.RowCount == 0) {
				cmdValidWarningAddCritAnd.Enabled = false;
				cmdValidWarningAddCritOr.Enabled = false;
				cmdValidWarningAddCrit.Enabled = true;
				cmdValidWarningChangemainjoinop.Enabled = false;
				return;
			}

			if (rdcValidationWarnings.Resultset.RowCount > 0) {
				modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					mainjoinop = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs_critSet.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalSetRec = rs_critSet.RowCount;
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs_critSet.MoveFirst();

			//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetIndex = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetCount = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			while (!rs_critSet.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SetIndex = SetIndex - 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SetCount = SetCount + 1;

				modGlobal.gv_sql = "Select * from tbl_setup_tablevalidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet!CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + rs_critSet["CriteriaSet"];
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				modGlobal.gv_rs.MoveLast();
				//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TotalRec = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveFirst();
				//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Cindex = 0;
				//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CSuff = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CPref = "Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value + ": (";

				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Cindex = Cindex + 1;
					//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Cindex == TotalRec) {
						//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (TotalRec == 1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							CSuff = " (" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + ") )";
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							CSuff = ")";
						}
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CSuff = " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Cindex == 1) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstWarningCriteriaSet.Items.Add(CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstWarningCriteriaSet.Items.Add("          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
					}
					//UPGRADE_ISSUE: ListBox property lstWarningCriteriaSet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.NewIndex, modGlobal.gv_rs.rdoColumns["TableValidationID"].Value);


					modGlobal.gv_rs.MoveNext();
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (SetCount == TotalSetRec) {
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstWarningCriteriaSet.Items.Add(mainjoinop);
					//"And"
					//UPGRADE_ISSUE: ListBox property lstWarningCriteriaSet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.NewIndex, SetIndex);
				}


				//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rs_critSet.MoveNext();

			}

			//when there is only one criteria the next choice should be
			//defined by selecting AND or OR buttons
			//otherwise the join operator has already been defined from the previous selection
			if (lstWarningCriteriaSet.Items.Count == 1) {
				cmdValidWarningAddCritAnd.Enabled = true;
				cmdValidWarningAddCritOr.Enabled = true;
				cmdValidWarningAddCrit.Enabled = false;
				cmdValidWarningChangemainjoinop.Enabled = false;
			} else {
				cmdValidWarningAddCritAnd.Enabled = false;
				cmdValidWarningAddCritOr.Enabled = false;
				cmdValidWarningAddCrit.Enabled = true;
				cmdValidWarningChangemainjoinop.Enabled = true;
			}
		}

		public void PrintValidation()
		{
			object thismessageid = null;
			object vmessage = null;
			object validatewhen = null;
			object valFile = null;
			System.Data.DataSet  vrs = null;
			System.Data.DataSet  vcrs = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object valFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			valFile = "c:\\iha\\valid.txt";
			//UPGRADE_WARNING: Couldn't resolve default property of object valFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileOpen(1, valFile, OpenMode.Output);

			//retrieve the list of Validation Error messages
			modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and state = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'ERROR' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tablevalidationmessageid ";

			vrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			while (!vrs.EOF) {

				//UPGRADE_WARNING: Couldn't resolve default property of object validatewhen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				validatewhen = vrs.rdoColumns["validatewhen"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object vmessage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				vmessage = vrs.rdoColumns["Message"].Value;
				FileSystem.PrintLine(1, "******************************************************************");
				FileSystem.PrintLine(1, vrs.rdoColumns["TableValidationMessageID"].Value);
				FileSystem.PrintLine(1, vmessage);
				FileSystem.PrintLine(1, "");
				//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thismessageid = vrs.rdoColumns["TableValidationMessageID"].Value;
				printvalcrit(ref thismessageid);

				FileSystem.PrintLine(1, "");

				vrs.MoveNext();
			}

		}

		public void printvalcrit(ref object thismessageid)
		{
			object CPref = null;
			object CSuff = null;
			object Cindex = null;
			object TotalRec = null;
			object SetCount = null;
			object TotalSetRec = null;
			object mainjoinop = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mainjoinop = "";
			object rs_critSet = null;
			modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_TableValidation ";
			//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + thismessageid;
			modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

			rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs_critSet.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalSetRec = rs_critSet.RowCount;
			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			rs_critSet.MoveFirst();

			//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetCount = 0;

			//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (rs_critSet.RowCount > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SetCount = SetCount + 1;

				modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
				//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + thismessageid;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object mainjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					mainjoinop = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				while (!rs_critSet.EOF) {

					modGlobal.gv_sql = "Select * from tbl_setup_tablevalidation ";
					//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + thismessageid;
					//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet!CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + rs_critSet["CriteriaSet"];
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					modGlobal.gv_rs.MoveLast();
					//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					TotalRec = modGlobal.gv_rs.RowCount;
					modGlobal.gv_rs.MoveFirst();

					//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Cindex = 0;
					//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CSuff = "";
					//UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CPref = "Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value + ": (";

					while (!modGlobal.gv_rs.EOF) {
						//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Cindex = Cindex + 1;
						//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Cindex == TotalRec) {
							//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (TotalRec == 1) {
								//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								CSuff = " (" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + ") )";
							} else {
								//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								CSuff = ")";
							}
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							CSuff = " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Cindex == 1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							FileSystem.PrintLine(1, CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							FileSystem.PrintLine(1, "          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
						}

						modGlobal.gv_rs.MoveNext();
					}

					//If SetCount >= TotalSetRec Then
					//    Print #1, ")"
					//End If
					//UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (SetCount < TotalSetRec) {
						FileSystem.PrintLine(1, Strings.Chr(13));
						FileSystem.PrintLine(1, mainjoinop);
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					rs_critSet.MoveNext();

				}
			}


		}
	}
}
