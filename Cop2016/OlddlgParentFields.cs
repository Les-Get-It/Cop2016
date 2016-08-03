using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
 // ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
	internal partial class OlddlgParentFields : System.Windows.Forms.Form
	{

//SH - 12.2004 - created to enter and edit virtual parent fields & their criteria & child criteria

		private void RefreshParentCDs()
		{

			//retrieve the list of Parent Fields
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_CMSParentCD ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by CMSParentCD ";

			rdcParentFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcParentFields.CtlRefresh();

			lstParents.Items.Clear();
			while (!rdcParentFields.Resultset.EOF) {
				lstParents.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcParentFields.Resultset.rdoColumns["CMSParentCD"].Value, rdcParentFields.Resultset.rdoColumns["CMSParentCDID"].Value));
				rdcParentFields.Resultset.MoveNext();
			}

		}

		private void CancelButton_Renamed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}


//UPGRADE_WARNING: Event cboFieldsToLink.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboFieldsToLink_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboFieldsToLink.SelectedIndex > -1) {
				SelectLookupTableForField(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboFieldsToLink, cboFieldsToLink.SelectedIndex));
			}
		}

		private void CmdAddParentCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "ANSWER";

			if (lstParents.SelectedIndex > -1) {
				My.MyProject.Forms.frmCMSParentAddCrit.SetCMSParentID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex));
				Microsoft.VisualBasic.Compatibility.VB6.Support.ShowForm(frmCMSParentAddCrit, Microsoft.VisualBasic.Compatibility.VB6.FormShowConstants.Modal, frmPatientFieldsExportLinks);

				RefreshParentCriteria();
			}


		}



		private void cmdChangeParentJoin_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string ls_JoinOp = null;
			int li_cnt = 0;
			System.Data.DataSet  rs_Temp = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (lstParents.SelectedIndex > -1) {
				modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_CMSParentAnswerCriteriaSet WHERE CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex);
				rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (!rs_Temp.EOF) {
					ls_JoinOp = rs_Temp.rdoColumns["JoinOperator"].Value;

					modGlobal.gv_sql = "UPDATE tbl_Setup_CMSParentAnswerCriteriaSet SET JoinOperator = " + (ls_JoinOp == "AND" ? "'OR'" : "'AND'") + " WHERE CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex);
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					RefreshParentCriteria();
				}
				rs_Temp.Close();

				//UPGRADE_NOTE: Object rs_Temp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rs_Temp = null;
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstParents.SelectedIndex >= 0) {

				if (Interaction.MsgBox("This can not be undone.", MsgBoxStyle.YesNo, "Are You Sure you want to Delete?") == MsgBoxResult.Yes) {
					modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSParentCD WHERE CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex);
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					//delete from criteria and sets are handled in the delete trigger

					RefreshParentCDs();
					lstParents.SelectedIndex = -1;
					OptAnswerCriteria.Checked = false;
					OptAnswerCD.Checked = false;

					Interaction.MsgBox("This parent was successfully deleted");

				}
			} else {
				Interaction.MsgBox("Please select a parent to delete", MsgBoxStyle.Critical, "No parent selected");
			}

		}

		private void cmdDelParentCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			if (lstParents.SelectedIndex > -1) {
				if (lstAnswerCriteria.SelectedIndex > -1) {

					//there are triggers on these tables to keep the set numbers and everything in order
					modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSParentAnswerCriteria WHERE  CMSParentAnswerCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstAnswerCriteria, lstAnswerCriteria.SelectedIndex);
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					RefreshParentCriteria();
				}
			}

			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void cmdLink_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short ll_curIndex = 0;

			if (lstParents.SelectedIndex > -1) {
				if (lstAvailable.SelectedIndex > -1) {

					ll_curIndex = lstAvailable.SelectedIndex;

					 // ERROR: Not supported in C#: OnErrorStatement


					modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSParentFieldMeasures (CMSParentCDID, FieldMeasureID) ";
					modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (" + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex) + ", " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstAvailable, lstAvailable.SelectedIndex) + ")";

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					RefreshLinkedChildren();

					lstAvailable.SelectedIndex = ll_curIndex - 1;
				}
			}

			return;
			ErrHandler:


			modGlobal.CheckForErrors();
		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{


			if (lstParents.SelectedIndex > -1)
				lstParents.SetSelected(lstParents.SelectedIndex, false);
			lstParents.SelectedIndex = -1;
			RefreshLookupTablesList();
			OptAnswerCriteria.Checked = false;
			OptAnswerCD.Checked = false;
			lstChildren.Items.Clear();

		}

		private void cmdUnlink_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstParents.SelectedIndex > -1) {
				if (lstChildren.SelectedIndex > -1) {
					modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSParentFieldMeasures WHERE FieldMeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstChildren, lstChildren.SelectedIndex);

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
					RefreshLinkedChildren();
				}
			}
		}

		private void dlgParentFields_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshParentCDs();
			RefreshAnswerCodes();
			RefreshLookupTablesList();
			lstParents.SelectedIndex = -1;
		}


//UPGRADE_WARNING: Event lstParents.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstParents_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			System.Data.DataSet  rsTemp = null;
			if (lstParents.SelectedIndex > -1 & lstParents.SelectedItems.Count > 0) {

				modGlobal.gv_sql = "Select * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_CMSParentCD ";
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex);

				rdcParentFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcParentFields.CtlRefresh();
				if (!rdcParentFields.Resultset.EOF) {
					txtParentField.Text = rdcParentFields.Resultset.rdoColumns["CMSParentCD"].Value;
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					cboAnswerFormat.Text = (!Information.IsDBNull(rdcParentFields.Resultset.rdoColumns["AnswerFormat"].Value) ? rdcParentFields.Resultset.rdoColumns["AnswerFormat"].Value : "");
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					txtDefaultValue.Text = (!Information.IsDBNull(rdcParentFields.Resultset.rdoColumns["DefaultValue"].Value) ? rdcParentFields.Resultset.rdoColumns["DefaultValue"].Value : "");
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if ((Information.IsDBNull(rdcParentFields.Resultset.rdoColumns["AnswerCDDDID"].Value) ? false : true)) {
						OptAnswerCD.Checked = true;
						SelectAnswerCD(ref rdcParentFields.Resultset.rdoColumns["AnswerCDDDID"].Value);
					} else {
						OptAnswerCriteria.Checked = true;
					}

				}

				RefreshLookupTablesList();
				RefreshLinkedChildren();
				//RefreshAnswerCodes
				cboLookup.Enabled = true;
				RefreshParentCriteria();
			} else {
				ClearForm();
			}
		}

		private void RefreshLinkedChildren()
		{
			lstChildren.Items.Clear();

			System.Data.DataSet  rsTemp = null;
			if (lstParents.SelectedIndex > -1) {

				modGlobal.gv_sql = "SELECT MeasureCode, FieldName, CMSFieldCode, cms.FieldMeasureID FROM tbl_Setup_CMSParentFieldMeasures pf, tbl_Setup_dataDef df, tbl_Setup_CMSFieldMeasures cms";
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE df.ddid = cms.ddid AND cms.FieldMeasureID = pf.FieldMeasureID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " AND CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " order by cmsfieldcode, df.FieldName, MeasureCode ";

				rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				while (!rsTemp.EOF) {
					lstChildren.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rsTemp.rdoColumns["measurecode"].Value + " - " + rsTemp.rdoColumns["FieldName"].Value + " **** " + rsTemp.rdoColumns["cmsfieldcode"].Value, rsTemp.rdoColumns["fieldmeasureid"].Value));

					rsTemp.MoveNext();
				}

				rsTemp.Close();
				//UPGRADE_NOTE: Object rsTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rsTemp = null;

				RefreshAnswerCodes();
			}
		}

		private void ClearForm()
		{

			txtParentField.Text = "";
			cboLookup.Text = "";
			cboAnswerFormat.Text = "";
			cboFieldsToLink.Items.Clear();
			lstAnswerCriteria.Items.Clear();

		}

		private void SelectLookupTableForField(ref int DDID)
		{
			System.Data.DataSet  rsTemp = null;
			int li_cnt = 0;

			cboLookup.Enabled = true;

			modGlobal.gv_sql = "Select LookupTableID From tbl_Setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Where DDID = " + DDID;
			rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (!rsTemp.EOF) {
				for (li_cnt = 0; li_cnt <= cboLookup.Items.Count - 1; li_cnt++) {
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookup, li_cnt) == rsTemp.rdoColumns["LookupTableID"].Value) {
						cboLookup.SelectedIndex = li_cnt;
						cboLookup.Enabled = false;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			rsTemp.Close();
			//UPGRADE_NOTE: Object rsTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rsTemp = null;

		}

		private void RefreshLookupTablesList()
		{
			System.Data.DataSet  rsTemp = null;
			short LookupIndex = 0;
			short thisListIndex = 0;

			modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "' or State is null)";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

			rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboLookup.Items.Clear();

			thisListIndex = -1;
			LookupIndex = -1;
			while (!rsTemp.EOF) {
				thisListIndex = thisListIndex + 1;
				cboLookup.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rsTemp.rdoColumns["BaseTable"].Value, rsTemp.rdoColumns["basetableid"].Value));

				if (!rdcParentFields.Resultset.EOF) {
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (!Information.IsDBNull(rdcParentFields.Resultset.rdoColumns["LookupTableID"].Value)) {
						if (rdcParentFields.Resultset.rdoColumns["LookupTableID"].Value == rsTemp.rdoColumns["basetableid"].Value) {
							LookupIndex = thisListIndex;
						}

					} else {

						//YES/NO Answer CD is DEFAULT for the CMS Output file
						//If rsTemp!BaseTable = "YES/NO" Then
						//    LookupIndex = thisListIndex
						//End If

					}
				}

				rsTemp.MoveNext();
			}

			rsTemp.Close();
			//UPGRADE_NOTE: Object rsTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rsTemp = null;

			if (LookupIndex > -1) {
				cboLookup.SelectedIndex = LookupIndex;
			}

		}

		private void RefreshAnswerCodes()
		{
			System.Data.DataSet  rsAnswerCD = null;
			int li_cnt = 0;

			modGlobal.gv_sql = "Select cms.FieldMeasureID, cms.measurecode, df.ddid, df.fieldname, df.cmsfieldcode ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as df ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_cmsFieldMeasures as cms ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";

			if (lstChildren.Items.Count > 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE cms.FieldMeasureID NOT IN (";

				for (li_cnt = 0; li_cnt <= lstChildren.Items.Count - 1; li_cnt++) {
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstChildren, li_cnt) + ",";
				}

				modGlobal.gv_sql = Strings.Mid(modGlobal.gv_sql, 1, Strings.Len(modGlobal.gv_sql) - 1) + ")";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " order by cmsfieldcode, df.FieldName, MeasureCode ";

			rsAnswerCD = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			lstAvailable.Items.Clear();

			while (!rsAnswerCD.EOF) {
				lstAvailable.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rsAnswerCD.rdoColumns["measurecode"].Value + " - " + rsAnswerCD.rdoColumns["FieldName"].Value + " **** " + rsAnswerCD.rdoColumns["cmsfieldcode"].Value, rsAnswerCD.rdoColumns["fieldmeasureid"].Value));

				rsAnswerCD.MoveNext();
			}

			rsAnswerCD.Close();
			//UPGRADE_NOTE: Object rsAnswerCD may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rsAnswerCD = null;


		}

		public void RefreshFieldsToLink()
		{
			System.Data.DataSet  rsTemp = null;

			//retrieve the list of table fields only if they are already a part of the cmsfieldmeasures
			modGlobal.gv_sql = " Select * from tbl_setup_DataDef, tbl_setup_tableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.BaseTableID = tbl_setup_tableDef.BaseTableID AND BaseTable = 'PATIENT' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

			rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboFieldsToLink.Items.Clear();

			while (!rsTemp.EOF) {
				cboFieldsToLink.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rsTemp.rdoColumns["FieldName"].Value, rsTemp.rdoColumns["DDID"].Value));
				rsTemp.MoveNext();
			}

			rsTemp.Close();
			//UPGRADE_NOTE: Object rsTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rsTemp = null;

		}


		private void OKButton_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement



			//If cboLookup.ListIndex = -1 Then
			//    MsgBox "Please choose the lookup table.", vbCritical, "Lookup Table not Chosen"
			//    Exit Sub
			//End If

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Strings.Len(txtParentField.Text) == 0 | Information.IsDBNull(txtParentField.Text)) {
				Interaction.MsgBox("Please enter the parent code name.", MsgBoxStyle.Critical, "Parent Code not entered");
				return;
			}

			string ls_ParentCD = null;

			if (lstParents.SelectedIndex > -1) {

				modGlobal.gv_sql = "UPDATE tbl_Setup_CMSParentCD ";
				modGlobal.gv_sql = modGlobal.gv_sql + " SET CMSParentCD = '" + txtParentField.Text + "'";
				if (OptAnswerCD.Checked & cboFieldsToLink.SelectedIndex > -1) {
					modGlobal.gv_sql = modGlobal.gv_sql + " , AnswerCDDDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboFieldsToLink, cboFieldsToLink.SelectedIndex);
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " , AnswerCDDDID = NULL ";
				}

				if (string.IsNullOrEmpty(cboLookup.Text)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " , LookupTableID = NULL ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " , LookupTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookup, cboLookup.SelectedIndex);
				}

				modGlobal.gv_sql = modGlobal.gv_sql + " , AnswerFormat = '" + cboAnswerFormat.Text + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " , DefaultValue = '" + txtDefaultValue.Text + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex);

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				ls_ParentCD = txtParentField.Text;

				RefreshParentCDs();

				Interaction.MsgBox("This parent field was sucessfully Updated", MsgBoxStyle.Information, "Successfully Updated Existing Field");

			} else {

				modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSParentCD " + " ([CMSParentCD], [AnswerCDDDID], [LookupTableID], [AnswerFormat], [DefaultValue]) " + " VALUES ('" + txtParentField.Text + "', ";
				if (OptAnswerCD.Checked & cboFieldsToLink.SelectedIndex > -1) {
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboFieldsToLink, cboFieldsToLink.SelectedIndex) + ", ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
				}

				if (!string.IsNullOrEmpty(cboLookup.Text)) {
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookup, cboLookup.SelectedIndex) + ", ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
				}

				modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboAnswerFormat.Text + "', '" + txtDefaultValue.Text + "')";

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				ls_ParentCD = txtParentField.Text;

				RefreshParentCDs();

				Interaction.MsgBox("This parent field was sucessfully Added", MsgBoxStyle.Information, "Successfully Added New Field");


			}

			rdcParentFields.Resultset.MoveFirst();
			int li_cnt = 0;
			li_cnt = -1;

			while (!rdcParentFields.Resultset.EOF) {
				li_cnt = li_cnt + 1;
				if (rdcParentFields.Resultset.rdoColumns["CMSParentCD"].Value == ls_ParentCD) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				rdcParentFields.Resultset.MoveNext();
			}

			lstParents.SetSelected(li_cnt, true);

			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

//UPGRADE_WARNING: Event OptAnswerCriteria.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void OptAnswerCriteria_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (OptAnswerCriteria.Checked) {
					lstAnswerCriteria.Enabled = true;
					cboFieldsToLink.Enabled = false;
					cboFieldsToLink.Items.Clear();
				} else {
					lstAnswerCriteria.Items.Clear();
					lstAnswerCriteria.Enabled = false;
				}

				CmdAddParentCrit.Enabled = OptAnswerCriteria.Checked;
				cmdDelParentCrit.Enabled = OptAnswerCriteria.Checked;

			}
		}

//UPGRADE_WARNING: Event OptAnswerCD.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void OptAnswerCD_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (OptAnswerCD.Checked) {
					cboFieldsToLink.Enabled = true;
					lstAnswerCriteria.Items.Clear();
					RefreshFieldsToLink();
				} else {
					cboFieldsToLink.Enabled = false;
					cboFieldsToLink.Items.Clear();
				}
			}
		}

		private void SelectAnswerCD(ref int DDID)
		{
			int li_cnt = 0;

			for (li_cnt = 0; li_cnt <= cboFieldsToLink.Items.Count - 1; li_cnt++) {
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboFieldsToLink, li_cnt) == DDID) {
					cboFieldsToLink.SelectedIndex = li_cnt;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

		}

		private void RefreshParentCriteria()
		{
			string ls_display = null;
			System.Data.DataSet  rs_Criteria = null;
			int li_SetCnt = 0;
			short li_SetIndex = 0;
			string ls_SetJoinOp = null;
			int li_MaxSet = 0;

			lstAnswerCriteria.Items.Clear();

			modGlobal.gv_sql = "SELECT CMSParentAnswerCriteriaSet, JoinOperator FROM tbl_Setup_CMSParentAnswerCriteriaSet  " + " WHERE CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex) + " ORDER BY CMSParentAnswerCriteriaSet";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);

			if (!modGlobal.gv_rs.EOF) {

				modGlobal.gv_rs.MoveLast();
				li_MaxSet = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveFirst();

				while (!modGlobal.gv_rs.EOF) {

					ls_SetJoinOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;

					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentAnswerCriteria  " + " WHERE CMSParentCDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstParents, lstParents.SelectedIndex) + " AND  CMSParentAnswerCriteriaSet =  " + modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaSet"].Value + " ORDER BY CMSParentAnswerCriteriaSet, CMSParentAnswerCriteriaID";

					rs_Criteria = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
					rs_Criteria.MoveLast();
					li_SetCnt = rs_Criteria.RowCount;
					rs_Criteria.MoveFirst();

					li_SetIndex = 0;

					ls_display = "SET " + modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaSet"].Value + ": ( ";

					while (!rs_Criteria.EOF) {
						li_SetIndex = li_SetIndex + 1;

						ls_display = ls_display + "   " + rs_Criteria.rdoColumns["CriteriaTitle"].Value;

						if (li_SetCnt == li_SetIndex) {
							if (li_SetCnt == 1) {
								ls_display = ls_display + " (" + rs_Criteria.rdoColumns["JoinOperator"].Value + ") )";
							} else {
								ls_display = ls_display + " )";
							}
						} else {
							ls_display = ls_display + " " + rs_Criteria.rdoColumns["JoinOperator"].Value + " ";
						}

						lstAnswerCriteria.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(ls_display, rs_Criteria.rdoColumns["CMSParentAnswerCriteriaID"].Value));
						ls_display = "";

						rs_Criteria.MoveNext();
					}

					rs_Criteria.Close();

					if (modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaSet"].Value < li_MaxSet) {
						lstAnswerCriteria.Items.Add(ls_SetJoinOp);
					}

					modGlobal.gv_rs.MoveNext();

				}
			}

			modGlobal.gv_rs.Close();


		}
	}
}
