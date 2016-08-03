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
	internal partial class OldfrmLookupSetup : System.Windows.Forms.Form
	{

//UPGRADE_WARNING: Event cboLookupTableList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboLookupTableList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			RefreshLookupList();
			if (cboLookupTableList.SelectedIndex > -1) {
				fraLk.Enabled = true;
			}

		}

		private void chkMultipleSel_Click()
		{
			object chkMultipleSel = null;
			object lblMaxSel = null;
			object txtMaxSel = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object chkMultipleSel.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (chkMultipleSel.Value == 1) {
				//UPGRADE_WARNING: Couldn't resolve default property of object txtMaxSel.Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtMaxSel.Enabled = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object lblMaxSel.Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblMaxSel.Enabled = true;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object txtMaxSel.Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtMaxSel.Enabled = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object lblMaxSel.Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblMaxSel.Enabled = false;
			}
		}

		private void cmdAddLookupTable_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			int NewlkupID;
			string Newlkup = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object Newlkup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Newlkup = RadInputBox.Show("Please enter the name of the new lookup table:", "Add New Lookup Table", "");
			//UPGRADE_WARNING: Couldn't resolve default property of object Newlkup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(Newlkup)) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewlkupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewlkupID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableDef", ref "BaseTableID");

			modGlobal.gv_sql = "Insert into tbl_setup_TableDef (BaseTableID, BaseTable, TableType) ";
			//UPGRADE_WARNING: Couldn't resolve default property of object Newlkup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewlkupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + NewlkupID + ",'" + Newlkup + "','LOOKUP'";
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshLookupTableList();
			//UPGRADE_WARNING: Couldn't resolve default property of object Newlkup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboLookupTableList.Text = Newlkup;

			//set the selected list item to the new one
			for (i = 0; i <= cboLookupTableList.Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object NewlkupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, i) == NewlkupID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					cboLookupTableList.SelectedIndex = i;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			fraLk.Enabled = true;
			optID.IsChecked = true;

		}

		private void cmdAddLookupValue_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int Nextsortorder;
			int NextNewID;

			if (cboLookupTableList.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a lookup table first.");
				return;
			}

			if ((string.IsNullOrEmpty(txtID.Text) | string.IsNullOrEmpty(txtLookupValue.Text)) & optID.IsChecked == true) {
				RadMessageBox.Show("Please enter both the ID and the lookup value.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref "tbl_setup_miscLookupList", ref "LookupID");
			//UPGRADE_WARNING: Couldn't resolve default property of object Nextsortorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Nextsortorder = modDBSetup.FindMaxRecID(ref "tbl_setup_miscLookupList", ref "sortorder");

			modGlobal.gv_sql = "insert into tbl_setup_miscLookupList ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (LookupID, BaseTableID, ID, FieldValue, sortorder)";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex) + ",";
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (optID.IsChecked == true | (!string.IsNullOrEmpty(txtID.Text) & !Information.IsDBNull(txtID.Text))) {
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtID.Text + "',";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " null,";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtLookupValue.Text + "',";
			//UPGRADE_WARNING: Couldn't resolve default property of object Nextsortorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + Nextsortorder;
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshLookupList();
			txtID.Text = "";
			txtLookupValue.Text = "";


		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			DialogResult resp ;
			if (cboLookupTableList.SelectedIndex < 0) {
				return;
			}

			//make sure this table will not be deleted if it has been used for any field
			modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookuptableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined for a field");
				return;
			}

			//make sure this table will not be deleted if it has been used for any cleanupitem
			modGlobal.gv_sql = "Select * from tbl_setup_submitcleanupcrit ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookuptableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in the Summarization process (Cleanup item).");
				return;
			}

			//make sure this table will not be deleted if it has been used for any field in the import layout
			modGlobal.gv_sql = "Select * from tbl_setup_importvalidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookuptableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in the Import process (Validation).");
				return;
			}

			//make sure this table will not be deleted if it has been used for any field in the adhocreport
			modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where Basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_savedadhocreportcriteria )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in an Adhoc Report Criteria.");
				return;
			}

			//make sure this table will not be deleted if it has been used for any field in the table validation
			modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where Basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_TableValidation )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a table validation.");
				return;
			}

			//make sure this table will not be deleted if it has been used for any field in the submission criteria
			modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where Basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_SubmitCriteria )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a submission criteria.");
				return;
			}

			//make sure this table will not be deleted if it has been used for any field in the record cleanup criteria for submission
			modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where Basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_SubmitCleanupRecord )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a submission criteria (record cleanup).");
				return;
			}

			//make sure this table will not be deleted if it has been used for any field in the Report criteria
			modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookuptableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a Report criteria.");
				return;
			}

			//make sure this table will not be deleted if it has been used for any field in the submission criteria
			modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookuptableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a submission criteria.");
				return;
			}

			//make sure the tables imported from the old system, will not be deleted
			modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (((!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OldTableName"].Value)) & !string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["OldTableName"].Value)) | modGlobal.gv_rs.rdoColumns["SystemSetup"].Value == "Y") {
				RadMessageBox.Show("Cannot Delete This Table. The table definition is required in this system.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to delete this lookup table?", MessageBoxButtons.YesNo, "Delete Lookup Table");
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "update tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set LookupTableID = null ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where LookupTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshLookupTableList();
			RefreshLookupList();

		}

		private void cmdDelLookup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int FCount ;
			object gv_Command = null;
			DialogResult resp ;
			if (rdcLookupList.Resultset.RowCount == 0) {
				return;
			}

			//make sure this value will not be deleted if it has been used for any related table

			modGlobal.gv_sql = "Select * from tbl_setup_TableValidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookupID = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Table Validation Process");
				return;
			}

			modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookupID = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Summarization Process");
				return;
			}

			modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookupID = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Adhoc Reports Criteria");
				return;
			}

			modGlobal.gv_sql = "Select * from tbl_setup_submitcleanuprecord ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where lookupID = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Summarization process (Record Cleanup Criteria)");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to delete this lookup value?", MessageBoxButtons.YesNo, "Delete Lookup Value");
			if (resp == DialogResult.No) {
				return;
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			gv_Command = "Delete tbl_Setup_miscLookupList ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			gv_Command = gv_Command + " where lookupID = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			//retrieve the list of  fields for the selected lookup to reorganize the list
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by SortOrder ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//first we make sure every field in this list has a number
			//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FCount = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = FCount + 1;
				modGlobal.gv_sql = "Update tbl_setup_misclookuplist ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + FCount;
				modGlobal.gv_sql = modGlobal.gv_sql + " where lookupid = " + modGlobal.gv_rs.rdoColumns["LookupID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				//LDW modGlobal.gv_rs.MoveNext();
			}

			RefreshLookupList();

		}

		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object thisindex = null;
			DialogResult resp ;
			//If rdcFieldList.Resultset.RowCount > 0 Then
			//    frmTableEditField.Show 1
			//End If

			if (cboLookupTableList.SelectedIndex < 0) {
				return;
			}

			//make sure the tables imported from the old system, will not be deleted
			modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (((!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OldTableName"].Value)) & !string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["OldTableName"].Value)) | modGlobal.gv_rs.rdoColumns["SystemSetup"].Value == "Y") {
				RadMessageBox.Show("Cannot Edit This Table. This lookup table is defined as a system lookup, and the table name has been used in the Member database internally.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadInputBox.Show("Type in the new title:", "Edit Lookup Title", cboLookupTableList.Text);
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(resp.ToString())) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			thisindex = cboLookupTableList.SelectedIndex;

			modGlobal.gv_sql = "update tbl_setup_TableDef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " set BaseTable = '" + resp + "'";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshLookupTableList();

			//UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboLookupTableList.SelectedIndex = thisindex;

		}

		private void cmdEditLookup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcLookupList.Resultset.RowCount == 0) {
				return;
			}

			frmTableEditLookup.ShowDialog();
			RefreshLookupList();
		}

		private void cmdImport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (cboLookupTableList.SelectedIndex >= 0) {
				if (RadMessageBox.Show("Are you sure you want to import the values into the table " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(cboLookupTableList, cboLookupTableList.SelectedIndex) + "?", MessageBoxButtons.YesNo, "Verify Lookup Table") == DialogResult.Yes) {
					dlgImportLookupValues.SetBaseTableID(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
					dlgImportLookupValues.ShowDialog();
					RefreshLookupList();
					this.Refresh();
					System.Windows.Forms.Application.DoEvents();
				}
			} else {
				RadMessageBox.Show("Please choose a lookup table to import values into.", RadMessageIcon.Information, "No Lookup Table Selected");
			}
		}

		private void cmdMoveDown_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			int TotalRec;
			int thisValue ;
			int CurrentSortOrder ;
			int FCount ;
			if (rdcLookupList.Resultset.RowCount > 0) {

				//retrieve the list of  fields for the selected Section
				modGlobal.gv_sql = "Select * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " order by SortOrder ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//first we make sure every field in this list has a number
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = 0;
				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FCount = FCount + 1;
					modGlobal.gv_sql = "Update tbl_setup_misclookuplist ";
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + FCount;
					modGlobal.gv_sql = modGlobal.gv_sql + " where lookupid = " + modGlobal.gv_rs.rdoColumns["LookupID"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					//LDW modGlobal.gv_rs.MoveNext();
				}

				modGlobal.gv_sql = "Select SortOrder from tbl_Setup_MiscLookupList ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where LookupID = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SortOrder"].Value)) {
					//reorganize the fields
				} else {
					if (modGlobal.gv_rs.rdoColumns["SortOrder"].Value > 1) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CurrentSortOrder = modGlobal.gv_rs.rdoColumns["SortOrder"].Value;
						//update the field that is one order higher than this one
						modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + CurrentSortOrder;
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " where SortOrder = " + CurrentSortOrder + 1;
						modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						//update this field
						modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + CurrentSortOrder + 1;
						modGlobal.gv_sql = modGlobal.gv_sql + " where lookupid = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
						modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						//UPGRADE_WARNING: Couldn't resolve default property of object thisValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thisValue = rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
						RefreshLookupList();

						rdcLookupList.Resultset.MoveLast();
						//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						TotalRec = rdcLookupList.Resultset.RowCount;
						rdcLookupList.Resultset.MoveFirst();

						//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						for (i = 1; i <= TotalRec - 1; i++) {
							if (thisValue == rdcLookupList.Resultset.rdoColumns["LookupID"].Value) {
								break; // TODO: might not be correct. Was : Exit For
							}
							rdcLookupList.Resultset.MoveNext();
						}

					}
				}

			}
		}

		private void cmdMoveUp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			int TotalRec ;
			int thisValue ;
			int CurrentSortOrder ;
			int FCount ;

			if (rdcLookupList.Resultset.RowCount > 0) {

				//retrieve the list of  fields for the selected Section
				modGlobal.gv_sql = "Select * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " order by SortOrder ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//first we make sure every field in this list has a number
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = 0;
				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FCount = FCount + 1;
					modGlobal.gv_sql = "Update tbl_setup_misclookuplist ";
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + FCount;
					modGlobal.gv_sql = modGlobal.gv_sql + " where lookupid = " + modGlobal.gv_rs.rdoColumns["LookupID"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					//LDW modGlobal.gv_rs.MoveNext();
				}


				modGlobal.gv_sql = "Select SortOrder from tbl_Setup_MiscLookupList ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where LookupID = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SortOrder"].Value)) {
					//reorganize the fields
				} else {
					if (modGlobal.gv_rs.rdoColumns["SortOrder"].Value > 1) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CurrentSortOrder = modGlobal.gv_rs.rdoColumns["SortOrder"].Value;
						//update the field that is one order higher than this one
						modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + CurrentSortOrder;
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " where SortOrder = " + (CurrentSortOrder - 1);
						modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						//update this field
						modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentSortOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + (CurrentSortOrder - 1);
						modGlobal.gv_sql = modGlobal.gv_sql + " where lookupid = " + rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
						modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						//UPGRADE_WARNING: Couldn't resolve default property of object thisValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						thisValue = rdcLookupList.Resultset.rdoColumns["LookupID"].Value;
						RefreshLookupList();

						rdcLookupList.Resultset.MoveLast();
						//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						TotalRec = rdcLookupList.Resultset.RowCount;
						rdcLookupList.Resultset.MoveFirst();

						//UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						for (i = 1; i <= TotalRec - 1; i++) {
							if (thisValue == rdcLookupList.Resultset.rdoColumns["LookupID"].Value) {
								break; // TODO: might not be correct. Was : Exit For
							}
							rdcLookupList.Resultset.MoveNext();
						}


					}
				}

			}

		}

		private void Command1_Click()
		{

		}

		private void frmLookupSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));
			RefreshLookupTableList();
			RefreshLookupList();
		}


		public void RefreshLookupTableList()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			//retrieve the list of batch types
			modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where TableType = 'LOOKUP' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "' or State is null)";
			}
			//If gv_status = "" Then
			//    gv_sql = gv_sql & " and (RecordStatus = '' or RecordStatus is null) "
			//Else
			//    gv_sql = gv_sql & " and RecordStatus = '" & gv_status & "'"
			//End If

			modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcLookupTableList.CtlRefresh();
			rdcLookupTableList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcLookupTableList.CtlRefresh();

			cboLookupTableList.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!rdcLookupTableList.Resultset.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Table_ListIndex = LIndex;

				cboLookupTableList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcLookupTableList.Resultset.rdoColumns["BaseTable"].Value, rdcLookupTableList.Resultset.rdoColumns["basetableid"].Value));
				rdcLookupTableList.Resultset.MoveNext();
			}

		}

		public void RefreshLookupList()
		{
			if (cboLookupTableList.SelectedIndex > -1) {

				modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["CompareToDesc"].Value)) {
					optID.IsChecked = true;
				} else {
					OptLKValue.IsChecked = true;
				}

				//retrieve the list of Lookup table values
				modGlobal.gv_sql = "Select * from tbl_setup_miscLookupList ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder, FieldValue ";
			} else {
				//retrieve the list of Lookup table values
				modGlobal.gv_sql = "Select * from tbl_setup_miscLookupList ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = 0 ";
				modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder, FieldValue ";
			}

			rdcLookupList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcLookupList.CtlRefresh();
			//dbgLookupList.Refresh



		}

		private void Frame2_DragDrop(ref System.Windows.Forms.Control Source, ref float X, ref float Y)
		{

		}

//UPGRADE_WARNING: Event optID.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void optID_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {

				modGlobal.gv_sql = "update tbl_setup_TableDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set CompareToDesc = null ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			}
		}

//UPGRADE_WARNING: Event OptLKValue.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void OptLKValue_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {

				modGlobal.gv_sql = "update tbl_setup_TableDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set CompareToDesc = 'Yes' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			}
		}

		private void txtMaxSel_Change()
		{
			object txtMaxSel = null;

			modGlobal.gv_sql = "update tbl_setup_TableDef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object txtMaxSel.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " set MaxSelection = " + Convert.ToInt16(txtMaxSel.Text);
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
		}
	}
}
