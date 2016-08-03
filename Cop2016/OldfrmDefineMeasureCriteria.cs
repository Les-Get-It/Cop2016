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
	internal partial class OldfrmMeasureCriteriaSetup : System.Windows.Forms.Form
	{
		object i;
		object selectedRow;
		object selectedMeasureCriteriaID;
		private void cmdAddCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdAddCriteria.GetIndex(eventSender);
			string ls_CritType = null;

			if (rdcMeasureList.Resultset.RowCount != 0) {
				My.MyProject.Forms.frmMeasureAddCritSetup.setMeasure(ref rdcMeasureList.Resultset.rdoColumns["MeasureSetDesc"].Value + " / " + rdcMeasureList.Resultset.rdoColumns["JCAHOID"].Value + " / " + rdcMeasureList.Resultset.rdoColumns["Description"].Value);
				My.MyProject.Forms.frmMeasureAddCritSetup.SetMeasureID(ref rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value);
				switch (Index) {
					case 0:
						ls_CritType = "Reg";
						break;
					case 1:
						ls_CritType = "Filter";
						break;
					case 2:
						ls_CritType = "Risk";
						break;
				}
				My.MyProject.Forms.frmMeasureAddCritSetup.setCritType(ref ls_CritType);
				My.MyProject.Forms.frmMeasureAddCritSetup.setRowCount(ref Convert.ToString(rdcMeasureList.Resultset.RowCount));
				My.MyProject.Forms.frmMeasureAddCritSetup.setMeasureSetID(ref rdcMeasureList.Resultset.rdoColumns["MeasureSetID"].Value);
				My.MyProject.Forms.frmMeasureAddCritSetup.ShowDialog();

				RefreshMeasureCriteria();

				//find the most recent criteria and goto that step
				modGlobal.gv_sql = "Select max(measurecriteriaid) as maxcriteriaid from tbl_setup_MeasureCriteria ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				selectedMeasureCriteriaID = modGlobal.gv_rs.rdoColumns["MaxCriteriaID"].Value;



				//go back to the same step
				for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						selectedRow = i;
					}
				}
				lstMeasureDef[Index].SetSelected(selectedRow, true);

			} else {
				Interaction.MsgBox("Please select a measure to setup.", MsgBoxStyle.Information, "No Measure Selected");
			}
		}

		private void cmdCopyMeasureSteps_Click()
		{
			object CSet = null;
			string NewCSet = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "NotDefined";

			if (lstMeasureDef[0].SelectedIndex < 0) {
				Interaction.MsgBox("Select a criteria step to copy.");
				return;
			}

			if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[0], lstMeasureDef[0].SelectedIndex) < 0) {
				Interaction.MsgBox("Select a criteria set to copy.");
				return;
			}

			System.Data.DataSet  thisrs = null;
			if (Interaction.MsgBox("Are you sure you want to create a new step as a copy of the selected step?", MsgBoxStyle.YesNo, "Duplicate Criteria Set") == MsgBoxResult.Yes) {
				modGlobal.gv_sql = "Select MeasureStep from tbl_setup_measurecriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where measurecriteriaid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[0], lstMeasureDef[0].SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CSet = modGlobal.gv_rs.rdoColumns["measurestep"].Value;

				modGlobal.gv_sql = "Select max(MeasureStep) + 1 as newcset  from tbl_setup_measurecriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where Measureid = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				NewCSet = modGlobal.gv_rs.rdoColumns["NewCSet"].Value;
				modGlobal.gv_rs.Close();

				modGlobal.gv_sql = "Select * from tbl_setup_measurecriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where Measureid = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureStep = " + CSet;
				thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				while (!thisrs.EOF) {
					modGlobal.gv_sql = "insert into tbl_setup_measurecriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureID, Measure_CatID, CriteriaTitle, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, FieldValue, DestDDID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, MeasureStep)  ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
					modGlobal.gv_sql = modGlobal.gv_sql + "MeasureID, Measure_CatID, CriteriaTitle, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, FieldValue, DestDDID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, " + NewCSet;
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_measurecriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where measurecriteriaID = " + thisrs.rdoColumns["measureCriteriaID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					thisrs.MoveNext();
				}
				thisrs.Close();

				RefreshMeasureCriteria();

			}
		}

		private void cmdChangeAddOrBetweenSets_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdChangeAddOrBetweenSets.GetIndex(eventSender);
			 // ERROR: Not supported in C#: OnErrorStatement


			if (rdcMeasureList.Resultset.RowCount == 0) {
				return;
			}

			if (lstMeasureDef[Index].SelectedIndex == 0) {
				return;
			}

			if (Interaction.MsgBox("Are you sure you want to change the join operator between all sets in this step?", MsgBoxStyle.YesNo, "Change Join Operator Between All Sets") == MsgBoxResult.No) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);


			modGlobal.gv_sql = "SELECT * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureCriteriaSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = (SELECT ms.MeasureStepID FROM tbl_Setup_MeasureStep ms, " + " tbl_Setup_MeasureCriteriaSet mcs, tbl_Setup_MeasureCriteria mc " + " WHERE mc.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID AND mcs.MeasureStepID = ms.MeasureStepID AND " + " mc.MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) + ")";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

			while (!modGlobal.gv_rs.EOF) {
				modGlobal.gv_rs.Edit();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) | Strings.Len(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == 0) {
					modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = "OR";
				} else {
					modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == "AND" ? "OR" : "AND");
				}
				modGlobal.gv_rs.Update();
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			RefreshMeasureCriteria();
			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void cmdChangeAndBetweenGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			short Index = 0;
			object JoinOperator = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (rdcMeasureList.Resultset.RowCount == 0) {
				return;
			}

			if (lstMeasureDef[Index].SelectedIndex < 0) {
				return;
			}

			if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0) {
				return;
			}

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			//the join operator has to be updated for the entire set
			modGlobal.gv_sql = "Select msg.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureStepGroup  msg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join vuMeasureCriteriaSetStep as mcss ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on msg.MeasureCriteriaSetID = mcss.MeasureCriteriaSetID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where mcss.MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);
			//
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
			//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			JoinOperator = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == "AND" ? "OR" : "AND");

			modGlobal.gv_sql = " update  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureStepGroup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " set joinoperator = '" + JoinOperator + "'";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureStepID = " + modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			RefreshMeasureCriteria();

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);
			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}

		private void cmdChangeCategoryofSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdChangeCategoryofSet.GetIndex(eventSender);
			object ls_CAT = null;
			string ls_EditCAT = null;
			int li_MeasureStepID = 0;
			System.Data.DataSet  rsIsValid = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (lstMeasureDef[Index].SelectedItems.Count > 1 | Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0) {
				Interaction.MsgBox("Select one criteria step to change the category.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			modGlobal.gv_sql = "SELECT ms.MeasureStepID, CAT, ms.Measure_CATID FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms , tbl_MEASURE_CAT cat" + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) + " AND ms.Measure_CATID = cat.MEASURE_CATID";
			EditCat:

			//Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
			//ls_CAT = gv_rs!CAT


			My.MyProject.Forms.frmMeasureModifyCategory.ShowDialog();


			//ls_EditCAT = InputBox("Edit the Set Category.", "Edit Category", ls_CAT)
			//
			// If Len(ls_EditCAT) = 0 Then Exit Sub
			//
			// gv_sql = "SELECT MEASURE_CATID FROM tbl_Measure_CAT WHERE CAT = '" & ls_EditCAT & "'"
			// If Index = 0 Then
			//     gv_sql = gv_sql & " AND CAT_TYPE = 'CI'"
			// ElseIf Index = 2 Then
			//     gv_sql = gv_sql & " AND CAT_TYPE = 'RA'"
			// End If
			//
			// Set rsIsValid = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//
			// If rsIsValid.EOF Then
			//     MsgBox "Please Enter A Valid Category", vbCritical, "Invalid Category"
			//     GoTo EditCat
			// Else
			//     gv_rs.Edit
			//     gv_rs!Measure_CATID = rsIsValid!Measure_CATID
			//     gv_rs.Update
			// End If
			//
			// gv_rs.Close
			// rsIsValid.Close

			RefreshMeasureCriteria();

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void cmdCopyCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdCopyCriteria.GetIndex(eventSender);
			string[] MeasCritIDs = null;
			int li_cnt = 0;
			int li_IDCnt = 0;

			if (lstMeasureDef[Index].SelectedItems.Count > 0) {

				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
					Interaction.MsgBox("Select one criteria set to copy.");
					return;
				}

				li_IDCnt = 0;
				MeasCritIDs = new string[li_IDCnt + 1];

				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

				for (li_cnt = 0; li_cnt <= lstMeasureDef[Index].Items.Count - 1; li_cnt++) {
					if (lstMeasureDef[Index].GetSelected(li_cnt)) {
						Array.Resize(ref MeasCritIDs, li_IDCnt + 1);
						MeasCritIDs[li_IDCnt] = Convert.ToString(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], li_cnt));
						li_IDCnt = li_IDCnt + 1;
					}
				}

				My.MyProject.Forms.frmMeasureCopyCriteria.SetCopyType(ref "M");
				My.MyProject.Forms.frmMeasureCopyCriteria.SetMeasureCriteriaID(ref MeasCritIDs);
				My.MyProject.Forms.frmMeasureCopyCriteria.ShowDialog();

				//selectedMeasureCriteriaID = lstMeasureDef(Index).ItemData(lstMeasureDef(Index).ListIndex)

				RefreshMeasureCriteria();

				//go back to the same step
				for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						selectedRow = i;
					}
				}
				lstMeasureDef[Index].SetSelected(selectedRow, true);
			}

		}

		private void cmdCopyCriteriaSets_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdCopyCriteriaSets.GetIndex(eventSender);
			object li_MeasureStepID = null;
			object li_MeasureCriteriaSetID = null;
			object li_MaxSet = null;
			int li_NewCriteriaSetID = 0;
			string ls_JoinOp = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (lstMeasureDef[Index].SelectedItems.Count > 1 | Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0) {
				Interaction.MsgBox("Select one criteria set to copy.");
				return;
			}

			if (Interaction.MsgBox("Are you sure you want to create a new set as a copy of the selected set?", MsgBoxStyle.YesNo, "Duplicate Criteria Set") == MsgBoxResult.Yes) {
				modGlobal.gv_sql = "select mcs.MeasureStepID, mcs.MeasureCriteriaSetID from " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND mc.MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
				modGlobal.gv_rs.Close();

				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "select max(measurecriteriaset) as MaxSet from tbl_Setup_measurecriteriaset " + " where measurestepid = " + li_MeasureStepID;

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MaxSet = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
				modGlobal.gv_rs.Close();

				//SH - added 7.28.04 to get first join operator and base all successive ones off that one
				// was just putting 'AND' in
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (li_MaxSet > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + li_MeasureStepID + " AND MeasureCriteriaSet = 1";
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					ls_JoinOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
					modGlobal.gv_rs.Close();
				} else {
					ls_JoinOp = "AND   ";
				}

				//insert new set record
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaSet " + " (MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES (" + li_MaxSet + 1 + ", " + li_MeasureStepID + ", '" + ls_JoinOp + "')";
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				li_NewCriteriaSetID = modGlobal.GetLastID(ref "tbl_Setup_MeasureCriteriaSet");

				//copy the criteria
				modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteria (";
				modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " select ";
				modGlobal.gv_sql = modGlobal.gv_sql + li_NewCriteriaSetID + ", ";
				modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetID = " + li_MeasureCriteriaSetID;

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " + " SELECT " + li_MeasureStepID + ", " + li_NewCriteriaSetID + ", MeasureStepGroup, JoinOperator FROM " + " tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + li_MeasureCriteriaSetID;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			}

			RefreshMeasureCriteria();

			//find the most recent criteria and goto that step
			modGlobal.gv_sql = "Select max(measurecriteriaid) as maxcriteriaid from tbl_setup_MeasureCriteria ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = modGlobal.gv_rs.rdoColumns["MaxCriteriaID"].Value;

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

			return;
			ErrHandler:

			modGlobal.CheckForErrors();


		}

		private void cmdCopyCriteriaSteps_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdCopyCriteriaSteps.GetIndex(eventSender);
			object li_NewCriteriaSetID = null;
			object li_MeasureID = null;
			object li_MaxStep = null;
			object li_NewStepID = null;
			int li_CatID = 0;
			int li_MeasureStepID = 0;
			object li_GoToStep = null;
			int li_IsRisk = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (lstMeasureDef[Index].SelectedItems.Count > 1 | Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0) {
				Interaction.MsgBox("Select one criteria step to copy.");
				return;
			}


			if (Interaction.MsgBox("Are you sure you want to create a new step as a copy of the selected step?", MsgBoxStyle.YesNo, "Duplicate Criteria Step") == MsgBoxResult.Yes) {

				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

				modGlobal.gv_sql = "SELECT ms.MeasureID, ms.MeasureStepID, ms.Measure_CATID, ms.gotostep, ms.IsRisk FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MeasureID = modGlobal.gv_rs.rdoColumns["MeasureID"].Value;

				li_CatID = 0;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["measure_catid"].Value)) {
					li_CatID = modGlobal.gv_rs.rdoColumns["measure_catid"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_GoToStep = 0;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["GoToStep"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_GoToStep = modGlobal.gv_rs.rdoColumns["GoToStep"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["isrisk"].Value)) {
					li_IsRisk = modGlobal.gv_rs.rdoColumns["isrisk"].Value;
				}


				li_MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				modGlobal.gv_rs.Close();

				modGlobal.gv_sql = "select max(MeasureStep) as MaxStep from tbl_Setup_MeasureStep as ms ";
				modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT as mc ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MEASURE_CATID = mc.MEASURE_CATID ";
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStep <> -100 and MeasureID = " + li_MeasureID;

				//If Index = 0 Then
				//    gv_sql = gv_sql & " and (Cat_Type is null or CAT_TYPE = 'CI')"
				//ElseIf Index = 2 Then
				//    gv_sql = gv_sql & " AND CAT_TYPE = 'RA'"
				//End If

				if (Index == 0) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0)";
				} else if (Index == 2) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' or IsRisk = 1)";
				}

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MaxStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MaxStep = modGlobal.gv_rs.rdoColumns["MaxStep"].Value;
				modGlobal.gv_rs.Close();

				//insert new step record
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep ";
				modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureID, MeasureStep, Measure_CATID, GoToStep, IsRisk ) VALUES ";
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " (" + li_MeasureID + ", ";
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MaxStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + li_MaxStep + 1 + ", ";
				if (li_CatID > 0) {
					modGlobal.gv_sql = modGlobal.gv_sql + li_CatID + ",";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " null,";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (li_GoToStep > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + li_GoToStep;
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " null";
				}

				modGlobal.gv_sql = modGlobal.gv_sql + "," + li_IsRisk;

				modGlobal.gv_sql = modGlobal.gv_sql + ")";
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_NewStepID = modGlobal.GetLastID(ref "tbl_Setup_MeasureStep");

				//insert new set record
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_measureCriteriaSet (MeasureCriteriaSet, MeasureStepID, JoinOperator) ";
				//UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + "  SELECT MeasureCriteriaSet, " + li_NewStepID;
				modGlobal.gv_sql = modGlobal.gv_sql + "  ";
				modGlobal.gv_sql = modGlobal.gv_sql + ", JoinOperator ";
				modGlobal.gv_sql = modGlobal.gv_sql + "  FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + li_MeasureStepID;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet " + " WHERE MeasureStepID = " + li_NewStepID;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				while (!modGlobal.gv_rs.EOF) {
					//copy the criteria
					modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteria (";
					modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
					modGlobal.gv_sql = modGlobal.gv_sql + " select ";
					modGlobal.gv_sql = modGlobal.gv_sql + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetID = (SELECT MeasureCriteriaSetID " + " FROM tbl_setup_MeasureCriteriaSet WHERE MeasureStepID = " + li_MeasureStepID + " AND MeasureCriteriaSet = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value + ")";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					//UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " + " SELECT " + li_NewStepID + ", " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value + ", MeasureStepGroup, JoinOperator FROM " + " tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = (SELECT MeasureCriteriaSetID " + " FROM tbl_setup_MeasureCriteriaSet WHERE MeasureStepID = " + li_MeasureStepID + " AND MeasureCriteriaSet = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value + ")";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_rs.MoveNext();
				}


			}
			modGlobal.gv_rs.Close();

			//selectedMeasureCriteriaID = lstMeasureDef(Index).ItemData(lstMeasureDef(Index).ListIndex)

			RefreshMeasureCriteria();

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);


			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}

		private void cmdDelCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdDelCriteria.GetIndex(eventSender);
			object li_MeasureCriteriaSetID = null;
			int li_MeasureStepID = 0;
			object li_MeasureSet = null;
			object li_MeasureStep = null;
			int li_cnt = 0;

			if (rdcMeasureList.Resultset.RowCount == 0) {
				return;
			}

			if (lstMeasureDef[Index].SelectedItems.Count > 0 & Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) > -1) {
				if (Interaction.MsgBox("Are you sure you want to delete this criteria?", MsgBoxStyle.YesNo, "Delete Criteria") == MsgBoxResult.No) {
					return;
				}

				//allow delete of multiple criteria
				for (li_cnt = 0; li_cnt <= lstMeasureDef[Index].Items.Count - 1; li_cnt++) {
					if (lstMeasureDef[Index].GetSelected(li_cnt) & Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], li_cnt) > 0) {
						if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == 0)
							return;

						modGlobal.gv_sql = "select mcs.MeasureCriteriaSetID , mcs.MeasureStepID, mcs.MeasureCriteriaSet, ms.MeasureStep from " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_Setup_MeasureStep ms where " + " mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID  = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], li_cnt);

						modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
						//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
						li_MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
						//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_MeasureSet = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value;
						//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_MeasureStep = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
						modGlobal.gv_rs.Close();

						modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteria ";
						modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], li_cnt);
						modGlobal.gv_cn.Execute(modGlobal.gv_sql);

						//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ResetMeasureStepOrder(li_MeasureCriteriaSetID, Convert.ToString(li_MeasureStepID), li_MeasureSet, li_MeasureStep);
						lstMeasureDef[Index].SetSelected(li_cnt, false);
					}
				}
			} else {
				Interaction.MsgBox("Select criteria to delete", MsgBoxStyle.Critical, "No Criteria Selected");
			}

			RefreshMeasureCriteria();
		}

		private void cmdDupMeasure_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;

			Index = SSTabCriteria.SelectedIndex;

			//If lstMeasureDef(Index).SelCount > 0 Then

			My.MyProject.Forms.frmMeasureCopyCriteria.SetCopyType(ref "M");
			My.MyProject.Forms.frmMeasureCopyCriteria.SetMeasureID(ref rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value);
			My.MyProject.Forms.frmMeasureCopyCriteria.ShowDialog();
			//End If
		}

		private void cmdDupSetLogic_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedItems.Count > 1 | Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0) {
				Interaction.MsgBox("Select one criteria set to copy.");
				return;
			}

			modGlobal.gv_sql = "select mcs.MeasureCriteriaSetID from " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND mc.MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			My.MyProject.Forms.dlgMeasureCreateSetLogic.il_MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
			modGlobal.gv_rs.Close();

			My.MyProject.Forms.dlgMeasureCreateSetLogic.ShowDialog();

		}

		private void cmdGoToStep_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object GoToThisStep = null;
			object selectedRow = null;
			var i = 0;
			object Index = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].Items.Count == 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object GoToThisStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			GoToThisStep = Interaction.InputBox("Type in the step you want to highlight:", "Go To...", "");
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			//UPGRADE_WARNING: Couldn't resolve default property of object GoToThisStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(GoToThisStep) | Information.IsDBNull(GoToThisStep)) {
				return;
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedRow = 1;
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object GoToThisStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstMeasureDef[Index], i), 1, 5 + Strings.Len(GoToThisStep)) == "Step " + GoToThisStep) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}

			lstMeasureDef[Index].SetSelected(selectedRow, true);

		}

		private void cmdGroupStep_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			Index = SSTabCriteria.SelectedIndex;

			if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0 | lstMeasureDef[Index].SelectedItems.Count > 1) {
				Interaction.MsgBox("Select one criteria in step to group step.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			My.MyProject.Forms.frmMeasureAddCritGroup.SetDescription(ref rdcMeasureList.Resultset.rdoColumns["MeasureSetDesc"].Value + " / " + rdcMeasureList.Resultset.rdoColumns["JCAHOID"].Value + " / " + rdcMeasureList.Resultset.rdoColumns["Description"].Value);
			My.MyProject.Forms.frmMeasureAddCritGroup.SetMeasureCriteriaID(ref (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex)));
			My.MyProject.Forms.frmMeasureAddCritGroup.ShowDialog();

			RefreshMeasureCriteria();


			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

		}

		private void cmdModifyCriteriaField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;

			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			My.MyProject.Forms.dlgField.SetMeasureCriteriaID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex));
			My.MyProject.Forms.dlgField.ShowDialog();

			RefreshMeasureCriteria();

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

		}

		private void cmdModifyCriteriaOperator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			object selectedMeasureCriteriaID = null;

			Index = SSTabCriteria.SelectedIndex;


			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			modGlobal.gv_sql = "select * from tbl_Setup_MeasureCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value)) {
				Interaction.MsgBox("The operator for this type of criteria cannot be modified");
				return;
			}
			My.MyProject.Forms.frmMeasureModifyOperator.SetMeasureCriteriaID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex));
			My.MyProject.Forms.frmMeasureModifyOperator.ShowDialog();

			RefreshMeasureCriteria();

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);


		}

		private void cmdModifyCriteriaSecondField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;

			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			modGlobal.gv_sql = "Select * from tbl_setup_MeasureCriteria ";
			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID = " + selectedMeasureCriteriaID;
			modGlobal.gv_sql = modGlobal.gv_sql + " and DDID2 is not null ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				Interaction.MsgBox("This feature does not apply to the selected criteria.");
				return;
			}

			My.MyProject.Forms.frmMeasureModifySecondField.SetMeasureCriteriaID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex));
			My.MyProject.Forms.frmMeasureModifySecondField.ShowDialog();

			RefreshMeasureCriteria();

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

		}

		private void cmdModifyCriteriaValue_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			object selectedMeasureCriteriaID = null;

			Index = SSTabCriteria.SelectedIndex;


			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "SELECT DDID1 FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaID = " + selectedMeasureCriteriaID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DDID1"].Value)) {
				Interaction.MsgBox("You cannot modify the right side (BLANK) in the Earliest Method", MsgBoxStyle.Critical, "Earliest Can Not be Modified this way");
			} else {
				My.MyProject.Forms.frmMeasureModifyValue.setMeasureCriteriaID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex));
				My.MyProject.Forms.frmMeasureModifyValue.ShowDialog();

				RefreshMeasureCriteria();

				//go back to the same step
				for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						selectedRow = i;
					}
				}
				lstMeasureDef[Index].SetSelected(selectedRow, true);
			}

		}

		private void cmdMoveStepTo_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object mcat = null;
			object Index = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);


			//UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Index == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object mcat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mcat = "CI";
				//UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (Index == 2) {
				//UPGRADE_WARNING: Couldn't resolve default property of object mcat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mcat = "RA";
			}

			My.MyProject.Forms.frmMeasureMoveStepTo.SetMeasureCriteriaID(ref rdcMeasureList.Resultset.rdoColumns["IndicatorID"], ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex), ref mcat);

			My.MyProject.Forms.frmMeasureMoveStepTo.ShowDialog();

			RefreshMeasureCriteria();
			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

		}

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Printer Printer = new Printer();
			short Index = 0;
			int li_cnt = 0;
			Index = SSTabCriteria.SelectedIndex;


			if (lstMeasureDef[Index].SelectedItems.Count >= 1) {
				if (Interaction.MsgBox("Continue with Printing Just the Selected Text?", MsgBoxStyle.YesNo, "Continue with Selection?") == MsgBoxResult.Yes) {
					Printer.Print(rdcMeasureList.Resultset.rdoColumns["Description"].Value);

					for (li_cnt = 0; li_cnt <= lstMeasureDef[Index].Items.Count - 1; li_cnt++) {
						if (lstMeasureDef[Index].GetSelected(li_cnt)) {
							Printer.Print(FileSystem.TAB(15), Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstMeasureDef[Index], li_cnt));
						}
					}

					Printer.EndDoc();
				}
			} else {
				Printer.Print(rdcMeasureList.Resultset.rdoColumns["Description"].Value);

				for (li_cnt = 0; li_cnt <= lstMeasureDef[Index].Items.Count - 1; li_cnt++) {
					Printer.Print(FileSystem.TAB(15), Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstMeasureDef[Index], li_cnt));
					//Printer.Print Tab(10); li_cnt
				}

				Printer.Print("End of Flowchart");
				Printer.EndDoc();
			}



		}

		private void cmdDown_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdDown.GetIndex(eventSender);
			MoveStep(ref false);
		}

		private void cmdSubstituteStepForSummarization_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			object selectedMeasureCriteriaID = null;


			Index = SSTabCriteria.SelectedIndex;

			if (Index != 0) {
				Interaction.MsgBox("Substitution can only be done for the flowchart steps");
				return;
			}

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = 0;
			if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);
			}

			My.MyProject.Forms.frmMeasureCriteriaSubmitSubs.SetupMeasureID(ref rdcMeasureList.Resultset.rdoColumns["IndicatorID"], ref rdcMeasureList.Resultset.rdoColumns["MeasureSetDesc"].Value + "-" + rdcMeasureList.Resultset.rdoColumns["JCAHOID"].Value + "-" + rdcMeasureList.Resultset.rdoColumns["Description"].Value, ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex));
			My.MyProject.Forms.frmMeasureCriteriaSubmitSubs.Show();
			this.Close();
			//RefreshMeasureCriteria
			//
			// 'go back to the same step
			// For i = 0 To lstMeasureDef(Index).ListCount - 1
			//     If lstMeasureDef(Index).ItemData(i) = selectedMeasureCriteriaID Then
			//         selectedRow = i
			//     End If
			// Next i
			//
			// lstMeasureDef(Index).Selected(selectedRow) = True

		}

		private void cmdUp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdUp.GetIndex(eventSender);
			MoveStep(ref true);
		}

		private void MoveStep(ref bool Up)
		{
			object li_MeasureStep = null;
			object li_MeasureStepID = null;
			object li_MeasureID = null;
			int li_MaxStep = 0;
			short Index = 0;
			object selectedRow = null;
			object selectedMeasureCriteriaID = null;
			var i = 0;

			Index = SSTabCriteria.SelectedIndex;
			 // ERROR: Not supported in C#: OnErrorStatement


			if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0 | lstMeasureDef[Index].SelectedItems.Count > 1) {
				Interaction.MsgBox("Select one criteria in step to move.");
				return;
			}

			if (Interaction.MsgBox("Are you sure you want to move this step?", MsgBoxStyle.YesNo, "Move Step") == MsgBoxResult.Yes) {

				//keep the reference to the step so we can go back to that
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

				modGlobal.gv_sql = "SELECT ms.MeasureStepID, ms.MeasureStep, ms.MeasureID FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MeasureID = modGlobal.gv_rs.rdoColumns["MeasureID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_MeasureStep = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
				modGlobal.gv_rs.Close();

				//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "SELECT Max(MeasureStep) as MaxStep FROM " + " tbl_setup_MeasureStep left join tbl_MEASURE_CAT " + " on tbl_setup_MeasureStep.Measure_CatID = tbl_MEASURE_CAT.Measure_CatID " + " WHERE MeasureID = " + li_MeasureID;

				if (Index == 0) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 and ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0)";
				} else if (Index == 2) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 and (CAT_TYPE = 'RA' or IsRisk = 1)";
				}

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				li_MaxStep = modGlobal.gv_rs.rdoColumns["MaxStep"].Value;
				modGlobal.gv_rs.Close();

				if (Up) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (li_MeasureStep == 1)
						return;

					//move previous step down
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = " + li_MeasureStep + " WHERE MeasureID = " + li_MeasureID + " AND MeasureStep = " + li_MeasureStep - 1;

					if (Index == 0) {
						modGlobal.gv_sql = modGlobal.gv_sql + " AND (Measure_CATID is null or Measure_CATID in (SELECT MEASURE_CATID FROM " + " tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')) AND IsRisk = 0 ";
					} else if (Index == 2) {
						modGlobal.gv_sql = modGlobal.gv_sql + " AND (Measure_CATID in (SELECT MEASURE_CATID FROM " + " tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA') OR IsRisk = 1)";
					}

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					//move all steps up
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = MeasureStep - 1 WHERE MeasureStepID = " + li_MeasureStepID;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (li_MeasureStep == li_MaxStep)
						return;

					//move next step up
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = " + li_MeasureStep + " WHERE MeasureID = " + li_MeasureID + " AND MeasureStep = " + li_MeasureStep + 1;

					if (Index == 0) {
						modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 AND ((Measure_CATID is null or Measure_CATID in (SELECT MEASURE_CATID FROM " + " tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')) AND IsRisk = 0)";
					} else if (Index == 2) {
						modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 AND (Measure_CATID in (SELECT MEASURE_CATID FROM " + " tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA') OR IsRisk = 1) ";
					}

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					//UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = MeasureStep + 1 WHERE MeasureStepID = " + li_MeasureStepID;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}

				RefreshMeasureCriteria();



				//go back to the same step
				for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						selectedRow = i;
					}
				}
				lstMeasureDef[Index].SetSelected(selectedRow, true);

			}
			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void Command1_Click()
		{

		}

		private void cmdView_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object Index = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedIndex > -1) {
				Interaction.MsgBox(lstMeasureDef[Index].Text);
			}


		}

		private void dbgMeasureList_RowColChange(System.Object eventSender, AxMSDBGrid.DBGridEvents_RowColChangeEvent eventArgs)
		{
			if (!string.IsNullOrEmpty(rdcMeasureList.SQL)) {
				RefreshMeasureCriteria();
			}
		}

		private void frmMeasureCriteriaSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			RefreshMeasureList();
		}

		public void RefreshMeasureList()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "Select ms.MeasureSetDesc, i.JCAHOID, i.Description, i.IndicatorID, ms.MeasureSetID, i.RiskAdjusted" + " from tbl_setup_indicator i, tbl_setup_MeasureSetMapMeas isf, tbl_setup_MeasureSet ms" + " Where i.IndicatorID = isf.IndicatorID " + " and isf.MeasureSetID = ms.MeasureSetID ";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (i.state = '' or i.state is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " AND i.state = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and i.RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by ms.MeasureSetDesc, i.JCAHOID, i.Description";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount == 0) {
				Interaction.MsgBox("Please Create measures before using this form", MsgBoxStyle.Information, "No Measures Exist");
				SSTabCriteria.Enabled = false;

				return;

			} else {
				rdcMeasureList.Resultset = modGlobal.gv_rs;
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcMeasureList.CtlRefresh();
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				dbgMeasureList.CtlRefresh();

				RefreshMeasureCriteria();
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		private void cmdChangeAndOrCond_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdChangeAndOrCond.GetIndex(eventSender);
			int li_cnt = 0;
			object JoinOperator = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (rdcMeasureList.Resultset.RowCount == 0) {
				return;
			}

			if (lstMeasureDef[Index].SelectedIndex < 0) {
				return;
			}

			if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0) {
				return;
			}

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedMeasureCriteriaID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			//the join operator has to be updated for the entire set
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);
			//
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
			//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			JoinOperator = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == "AND" ? "OR" : "AND");

			modGlobal.gv_sql = " update  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_MeasureCriteria ";
			//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " set joinoperator = '" + JoinOperator + "'";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureCriteriaSetID = ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select MeasureCriteriaSetID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//For li_cnt = 0 To lstMeasureDef(Index).ListCount - 1
			//    If lstMeasureDef(Index).Selected(li_cnt) Then
			//        gv_sql = "Select * "
			//        gv_sql = gv_sql & " from tbl_setup_MeasureCriteria "
			//        gv_sql = gv_sql & " Where MeasureCriteriaID = " & lstMeasureDef(Index).ItemData(li_cnt)
			//
			//        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
			//        Do While Not gv_rs.EOF
			//            gv_rs.Edit
			//            gv_rs!JoinOperator = IIf(UCase(Trim(gv_rs!JoinOperator)) = "AND", "OR", "AND")
			//            gv_rs.Update
			//            gv_rs.MoveNext
			//        Loop
			//        gv_rs.Close
			//    End If
			//Next

			RefreshMeasureCriteria();

			//go back to the same step
			for (i = 0; i <= lstMeasureDef[Index].Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object selectedMeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], i) == selectedMeasureCriteriaID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selectedRow = i;
				}
			}
			lstMeasureDef[Index].SetSelected(selectedRow, true);

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		public void mnuCreateGroupLogic_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Microsoft.VisualBasic.Compatibility.VB6.Support.ShowForm(dlgMeasureOccurGroupLogic, Microsoft.VisualBasic.Compatibility.VB6.FormShowConstants.Modal, frmMasterForm);
		}

		public void mnuDeleteFlowchartAction_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;


			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			if (Interaction.MsgBox("Are you sure you wish to remove the action from this step?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				modGlobal.gv_sql = "select * from vuMeasureFlowchartLogic WHERE MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep Set FlowchartActionID = NULL WHERE MeasureStepID = " + modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				modGlobal.gv_rs.Close();
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				Interaction.MsgBox("Successfully Deleted");
				RefreshMeasureCriteria();

			}

		}

		public void mnuDeleteMeasureFlowchartLogic_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string ls_CurrentDB = null;
			int li_MeasureID = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (rdcMeasureList.Resultset.RowCount == 0) {
				Interaction.MsgBox("Please select a measure to sync.", MsgBoxStyle.Information, "No Measure Selected");
				return;
			}

			li_MeasureID = rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;

			if (Strings.InStr(modGlobal.gv_cn.Connect, "COP2001Current") > 0) {
				ls_CurrentDB = "COP2001Current";
			} else if (Strings.InStr(modGlobal.gv_cn.Connect, "COP2001Archive") > 0) {
				ls_CurrentDB = "COP2001Archive";
			} else {
				ls_CurrentDB = "COP2001";
			}
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			//measurecriteriasubmitsubs
			modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteriaSubmitSubs] WHERE MeasureCriteriaSetSubmitSubsID in " + "(SELECT MeasureCriteriaSetSubmitSubsID FROM tbl_Setup_MeasureCriteriaSetSubmitSubs mcss, tbl_Setup_MeasureStepSubmitSubs mess, tbl_Setup_MeasureStep ms " + " WHERE mess.MeasureStepSubmitSubsID = mcss.MeasureStepSubmitSubsID and ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " + li_MeasureID + ")";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//measurecriteria
			modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteria] WHERE MeasureCriteriaSetID in " + "(SELECT MeasureCriteriaSetID FROM tbl_Setup_MeasureCriteriaSet mcss, tbl_Setup_MeasureStep mess " + " WHERE mess.MeasureStepID = mcss.MeasureStepID and mess.MeasureID = " + li_MeasureID + ")";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//measurecriteriasetsubmitsub
			modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] WHERE MeasureStepSubmitSubsID in " + "(SELECT MeasureStepSubmitSubsID FROM tbl_Setup_MeasureStepSubmitSubs mess, tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " + li_MeasureID + ")";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//measurecriteriaset
			modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteriaSet] WHERE MeasureStepID in " + "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep mess " + " WHERE mess.MeasureID = " + li_MeasureID + ")";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//measurestepsubmitsubs
			modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] WHERE MeasureStepID in " + "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " + li_MeasureID + ")";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//measurestepgroup
			modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureStepGroup] WHERE MeasureStepID in " + "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " + li_MeasureID + ")";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//measurestep
			modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureStep] WHERE MeasureID = " + li_MeasureID;
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			RefreshMeasureCriteria();

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			Interaction.MsgBox("Success!");
			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}


		public void mnuFlowchartAction_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;

			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedItems.Count != 1) {
				Interaction.MsgBox("Please choose 1 criteria to modify");
				return;
			} else if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) == -1) {
				Interaction.MsgBox("Please choose a criteria to modify");
				return;
			}

			My.MyProject.Forms.dlgAddFlowchartAction.SetMeasureCriteriaID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex));
			Microsoft.VisualBasic.Compatibility.VB6.Support.ShowForm(dlgAddFlowchartAction, Microsoft.VisualBasic.Compatibility.VB6.FormShowConstants.Modal, frmMasterForm);
			RefreshMeasureCriteria();

		}

		public void mnuShowGroupLogic_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmMeasureFieldGroups.Show();

		}

		public void mnuSyncMeasure_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			if (rdcMeasureList.Resultset.RowCount != 0) {

				My.MyProject.Forms.dlgSyncMeasure.SetMeasureID(ref rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value);
				My.MyProject.Forms.dlgSyncMeasure.Text = rdcMeasureList.Resultset.rdoColumns["Description"].Value;
				My.MyProject.Forms.dlgSyncMeasure.ShowDialog();

			} else {
				Interaction.MsgBox("Please select a measure to sync.", MsgBoxStyle.Information, "No Measure Selected");
			}
		}
		readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();

		short static_SSTabCriteria_SelectedIndexChanged_PreviousTab;
		private void SSTabCriteria_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			lock (static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init) {
				try {
					if (InitStaticVariableHelper(static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init)) {
						static_SSTabCriteria_SelectedIndexChanged_PreviousTab = SSTabCriteria.SelectedIndex();
					}
				} finally {
					static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init.State = 1;
				}
			}
			if (rdcMeasureList.Resultset.rdoColumns["RiskAdjusted"].Value == 0) {
				if (SSTabCriteria.SelectedIndex == 2) {
					SSTabCriteria.SelectedIndex = static_SSTabCriteria_SelectedIndexChanged_PreviousTab;
					Interaction.MsgBox("You can not assign risk criteria to an indicator that is not Risk Adjusted", MsgBoxStyle.Information, "Not Defined as Risk Adjusted");
					return;
				}
			}

			RefreshMeasureCriteria();
			static_SSTabCriteria_SelectedIndexChanged_PreviousTab = SSTabCriteria.SelectedIndex();
		}


		public void ResetMeasureStepOrder(string SetID, string StepID, string SetNum, string StepNum)
		{
			object li_SetCount = null;
			object li_CritCount = null;
			short Index = 0;
			int li_MaxStep = 0;
			System.Data.DataSet  rs_JoinOp = null;
			string ls_JoinOp = null;

			Index = SSTabCriteria.SelectedIndex;

			//get the # of criteria left for the set
			modGlobal.gv_sql = "Select count(*) as NumCriteria from tbl_Setup_MeasureCriteria " + " where MeasureCriteriaSetID = " + SetID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_CritCount = modGlobal.gv_rs.rdoColumns["NumCriteria"].Value;
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (li_CritCount == 0) {
				//delete the the set
				modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + SetID;
				rs_JoinOp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
				rs_JoinOp.Edit();
				ls_JoinOp = rs_JoinOp.rdoColumns["JoinOperator"].Value;
				rs_JoinOp.Delete();
				rs_JoinOp.Close();

				//delete any groupings related to the step
				modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + SetID;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + StepID;
				modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureCriteriaSet = " + Convert.ToDouble(SetNum) + 1;

				rs_JoinOp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
				if (!rs_JoinOp.EOF) {
					rs_JoinOp.Edit();
					rs_JoinOp.rdoColumns["JoinOperator"].Value = ls_JoinOp;
					rs_JoinOp.Update();
				}
				rs_JoinOp.Close();
			}

			modGlobal.gv_sql = "Select count(MeasureCriteriaSet) as MaxSet from tbl_Setup_MeasureCriteriaSet " + " where MeasureStepID = " + StepID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_SetCount = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (li_SetCount == 0) {
				//delete any groupings related to the step
				modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + StepID;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureStep WHERE MeasureStepID = " + StepID;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//only update other step #s for regular delete (filter only has 1 step)
				if (Index == 0 | Index == 2) {
					modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep SET MeasureStep = (MeasureStep -1) ";
					modGlobal.gv_sql = modGlobal.gv_sql + "  WHERE MeasureID = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + "  AND MeasureStep > " + StepNum;
					modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureStepID in ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (SELECT ms.MeasureStepID  ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
					modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStep <> -100 ";
					if (Index == 0) {
						modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'CI'or CAT_Type is null ";
					} else if (Index == 2) {
						modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'RA'";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + "  and ms.MeasureID = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + " )";


					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}
			}
			ContUpdate:


			//only update other set #s for regular delete (filter only has 1 set)
			//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (li_CritCount == 0 & (Index == 0 | Index == 2)) {
				modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureCriteriaSet SET MeasureCriteriaSet = (MeasureCriteriaSet -1) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + StepID + " AND MeasureCriteriaSet > " + SetNum;
				modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureStepID in ";
				modGlobal.gv_sql = modGlobal.gv_sql + " (SELECT ms.MeasureStepID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID";
				modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStep <> -100 ";
				if (Index == 0) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'CI'or CAT_Type is null ";
				} else if (Index == 2) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'RA'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + "  and ms.MeasureStepID = " + StepID;
				modGlobal.gv_sql = modGlobal.gv_sql + " )";

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
			}

		}

		public void RefreshMeasureCriteria()
		{
			short Index = 0;
			object StepLabel = null;
			object ls_Suffix = null;
			string ls_Prefix = null;
			object ls_MainOp = null;
			string ls_PrevSet = null;
			object li_TotCriteriaInSet = null;
			object li_StepCount = null;
			object li_CritCount = null;
			object li_SetCount = null;
			object li_TotStep = null;
			int li_TotSetInStep = 0;
			System.Data.DataSet  rs_TotCrit = null;
			object rs_TotSetInStep = null;
			System.Data.DataSet  rs_Crit = null;
			string SubmitSubs = null;
			System.Data.DataSet  rs_MeasGroup = null;
			int li_MeasGroup = 0;
			string ls_MeasGroup = null;
			System.Data.DataSet  rs_MeasStepGroup = null;
			object SingleIndent = null;
			object MeasGroup = null;
			object GroupIndent = null;
			object SetIndent = null;
			object CritIndent = null;
			object li_GroupSets = null;
			object GroupSetsCount = null;
			object GroupJoinOp = null;
			System.Data.DataSet  rs_Temp = null;
			short CurrentVersion = 0;

			//UPGRADE_WARNING: Couldn't resolve default property of object SingleIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SingleIndent = "      ";
			 // ERROR: Not supported in C#: OnErrorStatement


			RefreshRiskAdjusted();

			Index = SSTabCriteria.SelectedIndex;

			lstMeasureDef[Index].Items.Clear();


			CurrentVersion = GetCurrentVersion();

			//Dim rs_MeasStep As System.Data.DataSet 
			System.Data.DataSet  rs_MeasStep = null;


			//MeasureStep = -100 means that it is the filter criteria
			if (Index == 1) {
				modGlobal.gv_sql = "SELECT DISTINCT MeasureStep, MeasureStepID " + " FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value + " AND MeasureStep = -100 ";
			} else if (Index == 0 | Index == 2) {
				modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID, ms.GoToStep, m.CAT, ms.FlowchartActionID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureID = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 ";

				if (Index == 0) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0) ";
				} else if (Index == 2) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
				}

			}

			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC";

			rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (rs_MeasStep.EOF)
				return;

			rs_MeasStep.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_TotStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_TotStep = rs_MeasStep.RowCount;
			rs_MeasStep.MoveFirst();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_StepCount = 0;

			//STEP LOOP
			while (!rs_MeasStep.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_StepCount = li_StepCount + 1;

				//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ls_Suffix = "";


				if (Index == 0 | Index == 2) {

					//show a signal if there is a substitute submission step
					SubmitSubs = "";
					modGlobal.gv_sql = " select * from tbl_setup_MeasureStepSubmitSubs where MeasureStepID = " + rs_MeasStep.rdoColumns["MeasureStepID"].Value;
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (modGlobal.gv_rs.RowCount > 0) {
						SubmitSubs = " (With Submission Substitution) ";
					}
					modGlobal.gv_rs.Close();

					//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					StepLabel = "Step " + rs_MeasStep.rdoColumns["measurestep"].Value + SubmitSubs + ": = ";
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(rs_MeasStep.rdoColumns["CAT"].Value)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StepLabel = StepLabel + "Go To Step " + Convert.ToString(rs_MeasStep.rdoColumns["GoToStep"].Value);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StepLabel = StepLabel + rs_MeasStep.rdoColumns["CAT"].Value;
					}

					//If InStr(1, "75,94,95,96,97,98,99,100,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 45 Then
					if (((CurrentVersion <= 36 & rs_MeasStep.rdoColumns["measurestep"].Value == 43) | (CurrentVersion >= 37 & (rs_MeasStep.rdoColumns["measurestep"].Value == 44)) & (Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 75 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 94 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 95 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 96 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 97 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 98 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 99 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 100))) {
						//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StepLabel = StepLabel + " *IMPUTED* ";
						//ElseIf InStr(1, "84,85,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 1 Then
					} else if ((rs_MeasStep.rdoColumns["measurestep"].Value == 1) & (Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 84 | Convert.ToDouble(Convert.ToString(rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value)) == 85)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StepLabel = StepLabel + " *IMPUTED* ";
					}

					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (!Information.IsDBNull(rs_MeasStep.rdoColumns["flowchartactionid"].Value)) {
						modGlobal.gv_sql = "SELECT ActionDescription FROM tbl_Setup_MeasureFlowchartAction WHERE FlowchartActionID = " + rs_MeasStep.rdoColumns["flowchartactionid"].Value;
						rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

						//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StepLabel = StepLabel + " (Action: " + rs_Temp.rdoColumns["actionDescription"].Value + ")";
						rs_Temp.Close();
						//UPGRADE_NOTE: Object rs_Temp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						rs_Temp = null;

					}

					//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstMeasureDef[Index].Items.Add(StepLabel);
					//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, -1);
				}

				//SET QUERY
				modGlobal.gv_sql = "SELECT * FROM ";
				modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureCriteriaSet mcs inner join  tbl_Setup_MeasureStep ms ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MeasureStepID = mcs.MeasureStepID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_Setup_MeasureStepGroup as msg ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on mcs.measureCriteriaSetid = msg.measureCriteriaSetid ";
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ms.MeasureStepID = ";

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (rdcMeasureList.Resultset.RowCount == 0 | Information.IsDBNull(rs_MeasStep.rdoColumns["MeasureStepID"].Value)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " (-1)";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + rs_MeasStep.rdoColumns["MeasureStepID"].Value;
				}
				modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY msg.MeasureStepGroup, mcs.MeasureCriteriaSet ASC";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.EOF)
					return;

				modGlobal.gv_rs.MoveLast();
				li_TotSetInStep = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveFirst();
				//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_SetCount = 0;
				ls_MeasGroup = "";

				// loop thru sets
				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_SetCount = li_SetCount + 1;

					//show signal if there is a grouping
					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
					rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					if (rs_MeasGroup.RowCount == 0) {
						//UPGRADE_WARNING: Couldn't resolve default property of object MeasGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						MeasGroup = "";
						//UPGRADE_WARNING: Couldn't resolve default property of object GroupIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						GroupIndent = "";
						//UPGRADE_WARNING: Couldn't resolve default property of object SingleIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SetIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SetIndent = SingleIndent;
						//UPGRADE_WARNING: Couldn't resolve default property of object GroupSetsCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						GroupSetsCount = 0;
					} else {

						//find how many sets belong to this group
						modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup ";
						modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + rs_MeasGroup.rdoColumns["MeasureStepID"].Value;
						modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureStepGroup = " + rs_MeasGroup.rdoColumns["MeasureStepGroup"].Value;
						rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

						rs_MeasGroup.MoveLast();
						//UPGRADE_WARNING: Couldn't resolve default property of object li_GroupSets. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_GroupSets = rs_MeasGroup.RowCount;
						rs_MeasGroup.MoveFirst();
						//UPGRADE_WARNING: Couldn't resolve default property of object GroupJoinOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						GroupJoinOp = rs_MeasGroup.rdoColumns["JoinOperator"].Value;

						//UPGRADE_WARNING: Couldn't resolve default property of object SingleIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object GroupIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						GroupIndent = SingleIndent;
						//UPGRADE_WARNING: Couldn't resolve default property of object SingleIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object GroupIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SetIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SetIndent = GroupIndent + SingleIndent;

						if (MeasGroup != rs_MeasGroup.rdoColumns["MeasureStepGroup"].Value) {
							//UPGRADE_WARNING: Couldn't resolve default property of object GroupSetsCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							GroupSetsCount = 0;
							//UPGRADE_WARNING: Couldn't resolve default property of object GroupIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add(GroupIndent + "GROUP " + rs_MeasGroup.rdoColumns["MeasureStepGroup"].Value + ":");
							//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
							Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, -1);
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object GroupSetsCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						GroupSetsCount = GroupSetsCount + 1;
						//UPGRADE_WARNING: Couldn't resolve default property of object MeasGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						MeasGroup = rs_MeasGroup.rdoColumns["MeasureStepGroup"].Value;


					}

					//UPGRADE_WARNING: Couldn't resolve default property of object SetIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstMeasureDef[Index].Items.Add(SetIndent + "Set " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value + ":");
					//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, -1);


					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
					rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (rs_Crit.EOF)
						return;

					rs_Crit.MoveLast();
					//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_TotCriteriaInSet = rs_Crit.RowCount;
					rs_Crit.MoveFirst();

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CritCount = 0;
					//CRITERIA LOOP
					while (!rs_Crit.EOF) {
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_CritCount = li_CritCount + 1;

						//UPGRADE_WARNING: Couldn't resolve default property of object SingleIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SetIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object CritIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CritIndent = SetIndent + SingleIndent;

						//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_TotCriteriaInSet == 1 | (li_TotCriteriaInSet > 1 & li_CritCount != li_TotCriteriaInSet)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object CritIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add(CritIndent + rs_Crit.rdoColumns["CriteriaTitle"].Value + " (" + rs_Crit.rdoColumns["JoinOperator"].Value + ")");

						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object CritIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add(CritIndent + rs_Crit.rdoColumns["CriteriaTitle"].Value);
						}

						//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
						Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, rs_Crit.rdoColumns["measureCriteriaID"].Value);


						rs_Crit.MoveNext();
						//go to the next criteria
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (li_TotSetInStep == li_SetCount) {
						//UPGRADE_WARNING: Couldn't resolve default property of object SetIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstMeasureDef[Index].Items.Add(SetIndent + "-----------------");
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object li_GroupSets. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object GroupSetsCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (GroupSetsCount > 0 & GroupSetsCount == li_GroupSets) {
							//UPGRADE_WARNING: Couldn't resolve default property of object GroupJoinOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object GroupIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add(GroupIndent + GroupJoinOp);
							//UPGRADE_WARNING: Couldn't resolve default property of object GroupSetsCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							GroupSetsCount = 0;
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object SetIndent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add(SetIndent + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value);
						}
					}
					//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, -1);

					modGlobal.gv_rs.MoveNext();
					//go to the next set
				}


				modGlobal.gv_rs.Close();
				rs_MeasStep.MoveNext();

			}

			rs_MeasStep.Close();

			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}
		public void RefreshMeasureCriteriaOld()
		{
			short Index = 0;
			object StepLabel = null;
			object ls_Suffix = null;
			string ls_Prefix = null;
			object ls_MainOp = null;
			string ls_PrevSet = null;
			object li_TotCriteriaInSet = null;
			object li_StepCount = null;
			object li_CritCount = null;
			object li_SetCount = null;
			object li_TotStep = null;
			int li_TotSetInStep = 0;
			System.Data.DataSet  rs_TotCrit = null;
			object rs_TotSetInStep = null;
			System.Data.DataSet  rs_Crit = null;
			string SubmitSubs = null;
			System.Data.DataSet  rs_MeasGroup = null;
			int li_MeasGroup = 0;
			string ls_MeasGroup = null;
			System.Data.DataSet  rs_MeasStepGroup = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			RefreshRiskAdjusted();

			Index = SSTabCriteria.SelectedIndex;

			lstMeasureDef[Index].Items.Clear();

			//Dim rs_MeasStep As System.Data.DataSet 
			System.Data.DataSet  rs_MeasStep = null;


			//MeasureStep = -100 means that it is the filter criteria
			if (Index == 1) {
				modGlobal.gv_sql = "SELECT DISTINCT MeasureStep, MeasureStepID " + " FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value + " AND MeasureStep = -100 ";
			} else if (Index == 0 | Index == 2) {
				modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID, ms.GoToStep, m.CAT ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID";
				if (Index == 0) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND CAT_TYPE = 'CI'";
				} else if (Index == 2) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND CAT_TYPE = 'RA'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureID = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 ";

			}

			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC";

			rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (rs_MeasStep.EOF)
				return;

			rs_MeasStep.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_TotStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_TotStep = rs_MeasStep.RowCount;
			rs_MeasStep.MoveFirst();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_StepCount = 0;

			//STEP LOOP
			while (!rs_MeasStep.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_StepCount = li_StepCount + 1;

				//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ls_Suffix = "";


				if (Index == 0 | Index == 2) {
					//show signal if there is a grouping
					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + Convert.ToInt16(rs_MeasStep.rdoColumns["MeasureStepID"].Value);
					rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//show a signal if there is a substitute submission step
					SubmitSubs = "";
					modGlobal.gv_sql = " select * from tbl_setup_MeasureStepSubmitSubs where MeasureStepID = " + rs_MeasStep.rdoColumns["MeasureStepID"].Value;
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (modGlobal.gv_rs.RowCount > 0) {
						SubmitSubs = " (With Submission Substitution) ";
					}
					modGlobal.gv_rs.Close();

					//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					StepLabel = "Step " + rs_MeasStep.rdoColumns["measurestep"].Value + SubmitSubs + ": = ";
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(rs_MeasStep.rdoColumns["CAT"].Value)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StepLabel = StepLabel + "Go To Step " + Convert.ToString(rs_MeasStep.rdoColumns["GoToStep"].Value);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StepLabel = StepLabel + rs_MeasStep.rdoColumns["CAT"].Value;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					StepLabel = StepLabel + " (";

					//UPGRADE_WARNING: Couldn't resolve default property of object StepLabel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstMeasureDef[Index].Items.Add(StepLabel);
					//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
					Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, -1);
				}

				//SET QUERY
				modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet mcs, tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureStepID = mcs.MeasureStepID AND ms.MeasureStepID = ";

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (rdcMeasureList.Resultset.RowCount == 0 | Information.IsDBNull(rs_MeasStep.rdoColumns["MeasureStepID"].Value)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " (-1)";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + rs_MeasStep.rdoColumns["MeasureStepID"].Value;
				}
				modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY mcs.MeasureCriteriaSet ASC";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.EOF)
					return;

				modGlobal.gv_rs.MoveLast();
				li_TotSetInStep = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveFirst();
				//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_SetCount = 0;
				ls_MeasGroup = "";

				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_SetCount = li_SetCount + 1;

					//will display join operator for first measurecriteriaset
					if (Index == 0 | Index == 2) {
						//ls_MainOp = Nz(gv_rs!JoinOperator, "AND")
						//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ls_MainOp = "AND";
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ls_MainOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
						}

					}

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CritCount = 0;
					ls_PrevSet = "";

					if (Index == 0 | Index == 2) {
						//ls_MeasGroup = ""
						if (!rs_MeasGroup.EOF) {

							modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE " + " MeasureStepID = " + Convert.ToInt16(rs_MeasStep.rdoColumns["MeasureStepID"].Value) + " AND " + " MeasureCriteriaSetID = " + Convert.ToInt16(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value);
							rs_MeasStepGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
						}
					}

					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
					rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (rs_Crit.EOF)
						return;

					rs_Crit.MoveLast();
					//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_TotCriteriaInSet = rs_Crit.RowCount;
					rs_Crit.MoveFirst();

					//CRITERIA LOOP
					while (!rs_Crit.EOF) {
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_CritCount = li_CritCount + 1;

						if (Index == 0 | Index == 2) {
							ls_Prefix = "Set " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value + ": (";

							if (!rs_MeasGroup.EOF) {
								if (!rs_MeasStepGroup.EOF) {
									li_MeasGroup = Convert.ToInt16(rs_MeasStepGroup.rdoColumns["MeasureStepGroup"].Value);
									ls_MeasGroup = "     ";

									ls_Prefix = "GROUP " + li_MeasGroup + " [ " + ls_Prefix;
								}
							}
						} else {
							ls_Prefix = "( ";
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == li_TotCriteriaInSet) {
							//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (li_TotCriteriaInSet == 1) {
								//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								ls_Suffix = "     (" + rs_Crit.rdoColumns["JoinOperator"].Value + ") )";
							} else {
								//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								ls_Suffix = " )  ";
							}

							if (li_MeasGroup != 0) {
								//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								ls_Suffix = ls_Suffix + "  ]";
							}
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ls_Suffix = "   " + rs_Crit.rdoColumns["JoinOperator"].Value;
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == 1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add("     " + ls_Prefix + rs_Crit.rdoColumns["CriteriaTitle"].Value + ls_Suffix);
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add(ls_MeasGroup + "          " + rs_Crit.rdoColumns["CriteriaTitle"].Value + ls_Suffix);
						}
						//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
						Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, rs_Crit.rdoColumns["measureCriteriaID"].Value);

						//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == li_TotCriteriaInSet & li_SetCount < li_TotSetInStep) {
							//If Not rs_MeasStepGroup.EOF Then
							//    lstMeasureDef(index).AddItem ls_MeasGroup & "     " & rs_MeasStepGroup!JoinOperator
							//Else
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef[Index].Items.Add(ls_MeasGroup + "     " + ls_MainOp);
							//End If
							//UPGRADE_ISSUE: ListBox property lstMeasureDef.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
							Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstMeasureDef[Index], lstMeasureDef[Index].NewIndex, -1);
						}

						rs_Crit.MoveNext();
					}

					modGlobal.gv_rs.MoveNext();
				}

				if (Index == 0 | Index == 2) {
					lstMeasureDef[Index].Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(") ", -1));
				}

				modGlobal.gv_rs.Close();
				rs_MeasStep.MoveNext();

			}

			rs_MeasStep.Close();

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		private void RefreshRiskAdjusted()
		{
			if (rdcMeasureList.Resultset.rdoColumns["RiskAdjusted"].Value == 0) {
				if (SSTabCriteria.SelectedIndex == 2) {
					SSTabCriteria.SelectedIndex = 0;
					Interaction.MsgBox("You can not assign risk criteria to an indicator that is not Risk Adjusted", MsgBoxStyle.Information, "Not Defined as Risk Adjusted");
				}
			}
		}
		static bool InitStaticVariableHelper(Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag flag)
		{
			if (flag.State == 0) {
				flag.State = 2;
				return true;
			} else if (flag.State == 2) {
				throw new Microsoft.VisualBasic.CompilerServices.IncompleteInitialization();
			} else {
				return false;
			}
		}
	}
}
