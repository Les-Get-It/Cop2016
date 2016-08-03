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
	internal partial class OldfrmIndicatorSetup : System.Windows.Forms.Form
	{

		public void RefreshIndicatorDep()
		{
			object IndDesc = null;
			var LIndex = 0;
			var Table_ListIndex = 0;

			modGlobal.gv_sql = "Select tbl_setup_Indicator.Description, tbl_setup_IndicatorDep.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator, tbl_setup_IndicatorDep ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
			modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_Indicator.IndicatorID = tbl_setup_IndicatorDep.IndicatorID ";
			if (lstIndicators.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_IndicatorDep.IndicatorParentID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_IndicatorDep.IndicatorParentID = -1 ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstRequiredIndicator.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Table_ListIndex = LIndex;

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EffDate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object IndDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					IndDesc = modGlobal.gv_rs.rdoColumns["Description"].Value;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object IndDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					IndDesc = modGlobal.gv_rs.rdoColumns["Description"].Value + " (Eff. as of: " + modGlobal.gv_rs.rdoColumns["EffDate"].Value + ")";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object IndDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lstRequiredIndicator.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(IndDesc, modGlobal.gv_rs.rdoColumns["IndicatorDepID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}

		}



		public void RefreshIndicatorSet()
		{
			string setDesc = null;
			var LIndex = 0;
			var Table_ListIndex = 0;
			modGlobal.gv_sql = "Select * from tbl_setup_IndicatorSet ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " Where State = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by IndicatorsetDesc ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboIndicatorSet.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Table_ListIndex = LIndex;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EffDate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object setDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					setDesc = modGlobal.gv_rs.rdoColumns["IndicatorSetDesc"].Value;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object setDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					setDesc = modGlobal.gv_rs.rdoColumns["IndicatorSetDesc"].Value + " (" + modGlobal.gv_rs.rdoColumns["EffDate"].Value + ")";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object setDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboIndicatorSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(setDesc, modGlobal.gv_rs.rdoColumns["IndicatorSetID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}

		}

		public void RefreshIndicator()
		{
			string JCAHOID = null;
			var LIndex = 0;
			var Table_ListIndex = 0;

			//retrieve the list of Indicators
			modGlobal.gv_sql = "Select * from tbl_setup_Indicator ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " Where State = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstIndicators.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Table_ListIndex = LIndex;
				//UPGRADE_WARNING: Couldn't resolve default property of object JCAHOID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JCAHOID = "";
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JCAHOID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JCAHOID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JCAHOID = modGlobal.gv_rs.rdoColumns["JCAHOID"].Value + " - ";
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["lastupdatedate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JCAHOID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstIndicators.Items.Add(JCAHOID + modGlobal.gv_rs.rdoColumns["Description"].Value);
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object JCAHOID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstIndicators.Items.Add(JCAHOID + modGlobal.gv_rs.rdoColumns["Description"].Value + " (" + modGlobal.gv_rs.rdoColumns["lastupdatedate"].Value + ")");
				}

				//UPGRADE_ISSUE: ListBox property lstIndicators.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstIndicators, lstIndicators.NewIndex, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value);
				//LDW modGlobal.gv_rs.MoveNext();
			}


		}

//UPGRADE_WARNING: Event cboIndicatorSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboIndicatorSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshIndicatorSetField();
		}

		private void cmdAddDepIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmIndicatorAddDep.Show();
		}

		private void cmdAddIndicatorToSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmIndicatorAddToSet.Show();
		}

		private void cmdAddSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			int NewIndSID = null;
			string NewSet = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object NewSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewSet = Interaction.InputBox("Please enter the description of the new Indicator Set:", "Add New Set", "");
			//UPGRADE_WARNING: Couldn't resolve default property of object NewSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(NewSet)) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewIndSID = modDBSetup.FindMaxRecID(ref "tbl_Setup_IndicatorSet", ref "IndicatorSetID");

			modGlobal.gv_sql = "Insert into  tbl_setup_IndicatorSet (IndicatorSetID, IndicatorSetDesc, State, RecordStatus) ";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + NewIndSID + ",'" + NewSet + "',";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_State + "',";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " null ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicatorSet();
			//UPGRADE_WARNING: Couldn't resolve default property of object NewSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboIndicatorSet.Text = NewSet;

			//set the selected list item to the new one
			for (i = 0; i <= cboIndicatorSet.Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object NewIndSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, i) == NewIndSID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					cboIndicatorSet.SelectedIndex = i;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
		}

		private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			DialogResult resp;
			object MoveToModule = null;
			if (lstIndicators.SelectedIndex < 0) {
				return;
			}
                         

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want this indicator to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo);
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_Indicator ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicator();
			RefreshIndicatorSet();
			RefreshIndicatorDep();

		}

		private void cmdChangeStatusForset_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			DialogResult resp;
			object MoveToModule = null;

			if (cboIndicatorSet.SelectedIndex < 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp =  RadMessagebox.Show("Are you sure you want this indicator set to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_Indicatorset ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorsetID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicatorSet();
			RefreshIndicatorSetField();


		}

		private void cmdDeleteIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstIndicators.SelectedIndex < -1) {
				return;
			}

			modGlobal.gv_sql = "delete tbl_setup_datareq ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where indicatorid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "delete tbl_setup_indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where indicatorid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicator();

		}

		private void cmdDeleteSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboIndicatorSet.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_Setup_IndicatorSetField ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where IndicatorSetID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_Setup_IndicatorSet ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where IndicatorsetID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex);

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicatorSet();
			cboIndicatorSet.SelectedIndex = -1;
			RefreshIndicatorSetField();

		}

		private void cmdEditIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string lstindicator = null;
			string EditIndicator = null;
			if (string.IsNullOrEmpty(lstIndicators.Text)) {
				RadMessageBox.Show("Please select an indicator from the list.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "None";
			frmIndicatorEdit.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Update") {
				RefreshIndicator();
				//UPGRADE_WARNING: Couldn't resolve default property of object EditIndicator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object lstindicator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lstindicator = EditIndicator;
			}

			//EditIndicator = InputBox("Edit the indicator description.", "Edit Indicator", lstIndicators)
			//If EditIndicator <> "" Then
			//    gv_sql = "Update tbl_Setup_Indicator set Description = '" & EditIndicator & "'"
			//    gv_sql = gv_sql & " where IndicatorID = " & lstIndicators.ItemData(lstIndicators.ListIndex)
			//    gv_cn.Execute gv_sql
			//    RefreshIndicator
			//    lstindicator = EditIndicator
			//End If

		}

		private void cmdEditSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			string EditSet = null;
			int ThisSID;
			if (string.IsNullOrEmpty(cboIndicatorSet.Text)) {
				RadMessageBox.Show("Please select a set from the list.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object ThisSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisSID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object EditSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			EditSet = Interaction.InputBox("Edit the Set Description.", "Edit Set", cboIndicatorSet.Text);
			//UPGRADE_WARNING: Couldn't resolve default property of object EditSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(EditSet)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object EditSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_Setup_IndicatorSet set IndicatorSetDesc = '" + EditSet + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorSetID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshIndicatorSet();
				//UPGRADE_WARNING: Couldn't resolve default property of object EditSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboIndicatorSet.Text = EditSet;
				//set the selected list item to the new one
				for (i = 0; i <= cboIndicatorSet.Items.Count - 1; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ThisSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, i) == ThisSID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						cboIndicatorSet.SelectedIndex = i;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}
		}

		private void cmdEffDate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object EditEffDate = null;
			if (lstRequiredIndicator.SelectedIndex < 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object EditEffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			EditEffDate = Interaction.InputBox("Please type the EFFECTIVE DATE for this requirement.", "Edit Effective Date", Microsoft.VisualBasic.Compatibility.VB6.Support.Format(DateAndTime.Now, "mm/dd/yyyy"));
			//UPGRADE_WARNING: Couldn't resolve default property of object EditEffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(EditEffDate)) {
				if (!Information.IsDate(EditEffDate)) {
					RadMessageBox.Show("Invalid Date Format.");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object EditEffDate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_Setup_IndicatorDep set EffDate = '" + EditEffDate + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorDepID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstRequiredIndicator, lstRequiredIndicator.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshIndicatorDep();
			}

		}

		private void cmdNewIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int NewIndID;
			string NewIndicator = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndicator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewIndicator = Interaction.InputBox("Please enter the description of the new indicator:", "Add New Indicator", "");
			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndicator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(NewIndicator)) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewIndID = modDBSetup.FindMaxRecID("tbl_Setup_Indicator", "IndicatorID");

			modGlobal.gv_sql = "Insert into tbl_setup_Indicator (IndicatorID, Description, State, RecordStatus) ";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndicator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + NewIndID + ",'" + NewIndicator + "',";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_State + "',";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " null ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicator();

			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndicator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lstIndicators.Text = NewIndicator;

		}

		private void cmdRemoveDepIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstRequiredIndicator.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_Setup_IndicatorDep ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorDepID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstRequiredIndicator, lstRequiredIndicator.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicatorDep();

		}

		private void cmdRemoveEffDate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstRequiredIndicator.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_IndicatorDep set EffDate =  null ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorDepID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstRequiredIndicator, lstRequiredIndicator.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			RefreshIndicatorDep();


		}

		private void cmdRemoveIndicatorFromSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstIndicatorSet.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_setup_IndicatorSetField ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where IndlinkID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstIndicatorSet, lstIndicatorSet.SelectedIndex);

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshIndicatorSetField();

		}
		public void RefreshIndicatorSetField()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			modGlobal.gv_sql = "Select tbl_setup_indicator.Description, tbl_setup_indicatorSetField.*  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_indicator, tbl_setup_indicatorSetField ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_indicator.IndicatorID = tbl_setup_indicatorSetField.IndicatorID ";
			if (cboIndicatorSet.SelectedIndex < 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_indicatorSetField.IndicatorSetID  = 0 ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_indicatorSetField.IndicatorSetID  = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex);
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstIndicatorSet.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Table_ListIndex = LIndex;

				lstIndicatorSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndLinkID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}

		}
		private void frmIndicatorSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			sstabIndicatorList.SelectedIndex = 0;

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_status == "TEST") {
				cmdChangeStatus.Text = "Move to Active";
			} else {
				cmdChangeStatus.Text = "Move to Test";
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_status == "TEST") {
				cmdChangeStatusForset.Text = "Move to Active";
			} else {
				cmdChangeStatusForset.Text = "Move to Test";
			}


			RefreshIndicator();
			RefreshIndicatorSet();

		}

//UPGRADE_WARNING: Event lstIndicators.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstIndicators_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshIndicatorDep();
		}
	}
}
