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
	internal partial class OldfrmHospStatSetup : System.Windows.Forms.Form
	{
		object basetableid;

		public void RefreshGroupIndicator()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			if (lstHospStatGroup.SelectedIndex < 0) {
				lstFieldIndicator.Items.Clear();
				return;
			}

			modGlobal.gv_sql = "Select  tbl_setup_hospstatgroupIndicator.*, tbl_setup_Indicator.Description as Indicator  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_hospstatgroupIndicator, tbl_setup_Indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_hospstatgroupIndicator.IndicatorID = tbl_setup_Indicator.IndicatorID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_hospstatgroupIndicator.HospStatGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstFieldIndicator.Items.Clear();
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

				lstFieldIndicator.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Indicator"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}
		public void RefreshHospStatAllFields()
		{
			object dbgHospStatFields = null;

			//retrieve the list of patient fields for the selected Section
			modGlobal.gv_sql = "Select  hsf.HospStatGroupid, dd.DDID, dd.Fieldname, FieldOrder";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_Setup_DataDef as dd ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroupFields as hsf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = hsf.ddid) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
			if (cboIndicatorGroup.SelectedIndex < 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID =  -1 ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by hsf.FieldOrder, dd.FieldName ";

			//resp = InputBox("", "", gv_sql)
			rdcHospStatFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcHospStatFields.CtlRefresh();
			//resp = InputBox("", "", gv_sql) 'rdcPatientFields.Resultset.RowCount
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgHospStatFields.Refresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgHospStatFields.Refresh();
			//RefreshFieldIndicator

		}

		public void RefreshIndicatorSet()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			//retrieve the list of Indicator Groups

			modGlobal.gv_sql = "Select tbl_setup_IndicatorGroup.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorGroup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + basetableid;
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by displayorder, GroupDescription ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboIndicatorGroup.Items.Clear();
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

				cboIndicatorGroup.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupDescription"].Value, modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			if (cboIndicatorGroup.Items.Count == 0) {
				sstabGroupDetails.Enabled = false;
			}

		}


//UPGRADE_WARNING: Event cboIndicatorGroup.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
//UPGRADE_WARNING: ComboBox event cboIndicatorGroup.Change was upgraded to cboIndicatorGroup.TextChanged which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		private void cboIndicatorGroup_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboIndicatorGroup.SelectedIndex > -1) {
				sstabMainTab.Enabled = true;
			} else {
				sstabMainTab.Enabled = false;
			}
		}

//UPGRADE_WARNING: Event cboIndicatorGroup.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboIndicatorGroup_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboIndicatorGroup.SelectedIndex > -1) {
				sstabMainTab.Enabled = true;
			} else {
				sstabMainTab.Enabled = false;
			}

			RefreshHospStatGroups();
			RefreshHospStatGroupFields();
			RefreshGroupIndicator();
			RefreshHospStatAllFields();
			RefreshHospStatGroupForVal();
		}



		private void cmdAddFieldToGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstHospStatGroup.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a Group.");
				return;
			}

			frmHospStatEditGroupField.ShowDialog();
			RefreshHospStatGroupFields();
		}

		private void cmdAddValErr_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			AddValidation( "Error");
		}

		private void cmdAddValWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			AddValidation( "Warning");
		}

		private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			object MoveToModule = null;
			if (cboIndicatorGroup.SelectedIndex < 0) {
				RadMessageBox.Show("Select a section.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want this section to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshBaseTableID();
			RefreshIndicatorSet();
			RefreshHospStatGroups();
			RefreshHospStatAllFields();
			RefreshHospStatGroupFields();
			RefreshGroupIndicator();
			RefreshHospStatGroupForVal();
			RefreshHospStatValidation();

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (cboIndicatorGroup.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID in  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select HospStatGroupID from tbl_Setup_HospStatGroup ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) + ")";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupIndicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID in  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select HospStatGroupID from tbl_Setup_HospStatGroup ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) + ")";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroup ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID in  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select HospStatGroupID from tbl_Setup_HospStatGroup ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) + ")";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_Setup_IndicatorGroup ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			cboIndicatorGroup.SelectedIndex = -1;
			RefreshIndicatorSet();
			RefreshHospStatGroups();
			RefreshHospStatGroupFields();
			RefreshGroupIndicator();




		}

		private void cmdDelGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			if (lstHospStatGroup.SelectedIndex < 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to delete this group?", MessageBoxButtons.YesNo);
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupIndicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroup ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_Setup_HospStatVal ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  where HOSPSTATGROUPID1 = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + "  or HOSPSTATGROUPID2 = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


			RefreshHospStatGroups();
			lstHospStatGroup.SelectedIndex = -1;
			RefreshHospStatGroupFields();
			if (lstHospStatGroup.Items.Count == 0) {
				sstabGroupDetails.Enabled = false;
			}


		}

		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object EditSection = null;
			object ThisGID = null;
			if (string.IsNullOrEmpty(cboIndicatorGroup.Text)) {
				RadMessageBox.Show("Please select Section from the list.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object ThisGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisGID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			EditSection = RadInputBox.Show("Edit the Section description.", "Edit Section", cboIndicatorGroup.Text);
			//UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(EditSection)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup set GroupDescription = '" + EditSection + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshIndicatorSet();
				//UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboIndicatorGroup.Text = EditSection;
				//set the selected list item to the new one
				for (i = 0; i <= cboIndicatorGroup.Items.Count - 1; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ThisGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, i) == ThisGID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						cboIndicatorGroup.SelectedIndex = i;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

		}

		private void cmdEditGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object EditGroup = null;
			object ThisGID = null;
			if (lstHospStatGroup.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a Group from the list.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object ThisGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisGID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object EditGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			EditGroup = RadInputBox.Show("Edit the Group description.", "Edit Group", lstHospStatGroup.Text);
			//UPGRADE_WARNING: Couldn't resolve default property of object EditGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(EditGroup)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object EditGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_Setup_HospStatGroup set GroupDescription = '" + EditGroup + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where HospStatGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshHospStatGroups();
				//UPGRADE_WARNING: Couldn't resolve default property of object EditGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lstHospStatGroup.Text = EditGroup;
				//set the selected list item to the new one
				for (i = 0; i <= lstHospStatGroup.Items.Count - 1; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object ThisGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, i) == ThisGID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstHospStatGroup.SelectedIndex = i;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

		}


		private void cmdLinkIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstHospStatGroup.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a Group.");
				return;
			}


			frmHospStatEditIndicator.ShowDialog();
			RefreshGroupIndicator();

		}

		private void cmdMoveDown_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object ThisFieldID = null;
			object CurrOrderNum = null;
			object FCount = null;
			object TotalFields = null;
			if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count < 0) {
				return;
			}

			//retrieve the list of  fields for the selected Section
			modGlobal.gv_sql = "Select  hsf.ddid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by hsf.fieldorder ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//LDW modGlobal.gv_rs.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalFields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalFields = modGlobal.gv_rs.RowCount;
			//LDW modGlobal.gv_rs.MoveFirst();

			//first we make sure every field in this list has a number
			//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FCount = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = FCount + 1;
				modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_setup_HospStatGroupFields.FieldOrder = " + FCount;
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.DDID = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"] == modGlobal.gv_rs.rdoColumns["DDID"].Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrOrderNum = FCount;
				}
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisFieldID = rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"];
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalFields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (CurrOrderNum < TotalFields) {
				//update order number of the field after to this one
				modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_setup_HospStatGroupFields.FieldOrder = " + CurrOrderNum;
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and FieldOrder = " + CurrOrderNum + 1;

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				//update order number of this field
				modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_setup_HospStatGroupFields.FieldOrder = " + CurrOrderNum + 1;
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.DDID = " + rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"];

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				RefreshHospStatAllFields();
				//find the right field
				for (i = 1; i <= rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count; i++) {
					if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"] == ThisFieldID) {
						break; // TODO: might not be correct. Was : Exit For
					}
					rdcHospStatFields.Resultset.MoveNext();
				}

			}


		}

		private void cmdMoveSectionDown_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object ThisFieldID = null;
			object MaxOrderNum = null;
			object CurrOrderNum = null;
			object FCount = null;
			if (string.IsNullOrEmpty(cboIndicatorGroup.Text)) {
				RadMessageBox.Show("Please select Section from the list.");
				return;
			}
			//retrieve the list of patient fields for the selected Section
			modGlobal.gv_sql = "Select  * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

			//first we make sure every field in this list has a number
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FCount = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = FCount + 1;
				modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + FCount;
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) == modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrOrderNum = FCount;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MaxOrderNum = FCount;
				modGlobal.gv_rs.MoveNext();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisFieldID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);

			//UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			System.Data.DataSet  rs2 = null;
			if (CurrOrderNum < MaxOrderNum) {
				//update order number of the field prior to this one
				modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder =  " + CurrOrderNum;
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_status)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and DisplayOrder = " + CurrOrderNum + 1;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				//update order number of this field
				modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + CurrOrderNum + 1;
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				RefreshIndicatorSet();
				//find the right field
				modGlobal.gv_sql = "Select  * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_status)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";
				rs2 = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = 0;
				while (!rs2.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FCount = FCount + 1;
					if (rs2.rdoColumns["indicatorgroupid"].Value == ThisFieldID) {
						cboIndicatorGroup.SelectedText = rs2.rdoColumns["GroupDescription"].Value;
						//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						cboIndicatorGroup.SelectedIndex = FCount - 1;
					}
					rs2.MoveNext();
				}
				rs2.Close();

			}

		}



		private void cmdMoveSecUp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object ThisFieldID = null;
			object CurrOrderNum = null;
			object FCount = null;

			if (string.IsNullOrEmpty(cboIndicatorGroup.Text)) {
				RadMessageBox.Show("Please select Section from the list.");
				return;
			}

			//retrieve the list of sections
			modGlobal.gv_sql = "Select  * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + basetableid;
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

			//first we make sure every field in this list has a number
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FCount = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = FCount + 1;
				modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup";
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + FCount;
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) == modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrOrderNum = FCount;
				}
				modGlobal.gv_rs.MoveNext();
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisFieldID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			System.Data.DataSet  rs2 = null;
			if (CurrOrderNum - 1 > 0) {
				//update order number of the field prior to this one
				modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder =  " + CurrOrderNum;
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and DisplayOrder = " + CurrOrderNum - 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_status)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
				}
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				//update order number of this field
				modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + CurrOrderNum - 1;
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				RefreshIndicatorSet();
				//find the right field
				//find the right field
				modGlobal.gv_sql = "Select  * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
				//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_status)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";
				rs2 = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = 0;
				while (!rs2.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FCount = FCount + 1;
					if (rs2.rdoColumns["indicatorgroupid"].Value == ThisFieldID) {
						cboIndicatorGroup.SelectedText = rs2.rdoColumns["GroupDescription"].Value;
						//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						cboIndicatorGroup.SelectedIndex = FCount - 1;
					}
					rs2.MoveNext();
				}
				rs2.Close();
			}

		}

		private void cmdMoveToAbsPosition_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object abspos = null;
			var i = 0;
			object NewPos = null;
			object ThisFieldOrder = null;
			object TotalFields = null;
			object StartOrder = null;

			if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count < 0) {
				return;
			}

			//first we make sure that every field has an order number
			modGlobal.gv_sql = "update tbl_setup_HospStatGroupFields   ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set fieldorder = 1 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where fieldorder is null  ";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Select hsf.*  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by fieldorder ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object StartOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			StartOrder = modGlobal.gv_rs.rdoColumns["fieldorder"].Value;
			//LDW modGlobal.gv_rs.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalFields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalFields = modGlobal.gv_rs.RowCount;
			//LDW modGlobal.gv_rs.MoveFirst();

			//update the selected one
			modGlobal.gv_sql = " select * from  tbl_setup_HospStatGroupFields   ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"];
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisFieldOrder = modGlobal.gv_rs.rdoColumns["fieldorder"].Value;

			//UPGRADE_WARNING: Couldn't resolve default property of object TotalFields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewPos = RadInputBox.Show("Type in the order number for this field (should be between 1 and " + TotalFields + ")", "Move Field Position", Convert.ToString(1));
			if (!Information.IsNumeric(NewPos)) {
				RadMessageBox.Show("Numeric values only.");
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object TotalFields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Convert.ToInt16(NewPos) < 1 | Convert.ToInt16(NewPos) > TotalFields) {
				RadMessageBox.Show("Invalid position.");
				return;
			}

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			//update all the fields except the selected one
			modGlobal.gv_sql = "Select hsf.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and hsf.ddid <> " + rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"];
			modGlobal.gv_sql = modGlobal.gv_sql + " order by fieldorder ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object StartOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			i = StartOrder - 1;
			//UPGRADE_WARNING: Couldn't resolve default property of object abspos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			abspos = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				i = i + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object abspos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				abspos = abspos + 1;

				//UPGRADE_WARNING: Couldn't resolve default property of object NewPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object abspos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (abspos == Convert.ToInt16(NewPos)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					i = i + 1;
				}

				modGlobal.gv_sql = " update tbl_setup_HospStatGroupFields   ";
				//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set fieldorder = " + i;
				modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


				modGlobal.gv_rs.MoveNext();

			}

			//update the selected one
			modGlobal.gv_sql = " update tbl_setup_HospStatGroupFields   ";
			//UPGRADE_WARNING: Couldn't resolve default property of object StartOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " set fieldorder = " + Convert.ToInt16(NewPos) + StartOrder - 1;
			modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"];
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshHospStatAllFields();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

		}

		private void cmdMoveUp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object ThisFieldID = null;
			object CurrOrderNum = null;
			object FCount = null;
			if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count < 0) {
				return;
			}

			//retrieve the list of  fields for the selected Section
			modGlobal.gv_sql = "Select  hsf.ddid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by hsf.fieldorder ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//first we make sure every field in this list has a number
			//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FCount = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = FCount + 1;
				modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_setup_HospStatGroupFields.FieldOrder = " + FCount;
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.DDID = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"] == modGlobal.gv_rs.rdoColumns["DDID"].Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrOrderNum = FCount;
				}
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisFieldID = rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"];
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (CurrOrderNum - 1 > 0) {
				//update order number of the field prior to this one
				modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_setup_HospStatGroupFields.FieldOrder = " + CurrOrderNum;
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and FieldOrder = " + CurrOrderNum - 1;

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				//update order number of this field
				modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_setup_HospStatGroupFields.FieldOrder = " + CurrOrderNum - 1;
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
				modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.DDID = " + rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"];

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				RefreshHospStatAllFields();
				//find the right field
				for (i = 1; i <= rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count; i++) {
					if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Columns["DDID"] == ThisFieldID) {
						break; // TODO: might not be correct. Was : Exit For
					}
					rdcHospStatFields.Resultset.MoveNext();
				}

			}


		}

		private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object NewIndGID = null;
			object NewGroup = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewGroup = RadInputBox.Show("Please enter the description of the new section:", "Add New Section", "");
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(NewGroup)) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewIndGID = modDBSetup.FindMaxRecID(ref "tbl_Setup_IndicatorGroup", ref "IndicatorGroupID");
			modGlobal.gv_sql = "Insert into tbl_setup_IndicatorGroup (IndicatorGroupID, GroupDescription, BaseTableID, State, RecordStatus) ";
			//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewIndGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + NewIndGID + ",'" + NewGroup + "'," + basetableid + ",";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
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
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboIndicatorGroup.Text = NewGroup;

			//set the selected list item to the new one
			for (i = 0; i <= cboIndicatorGroup.Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object NewIndGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, i) == NewIndGID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					cboIndicatorGroup.SelectedIndex = i;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			sstabMainTab.Enabled = true;

			RefreshHospStatGroups();
			RefreshHospStatGroupFields();
			RefreshGroupIndicator();
			RefreshHospStatAllFields();

		}
		public void RefreshBaseTableID()
		{
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
			modGlobal.gv_sql = modGlobal.gv_sql + " upper(substring(BaseTable,1,13)) = 'HOSPITAL STAT' ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
		}

		private void cmdNewGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object NewGID = null;
			object NewGroup = null;
			if (cboIndicatorGroup.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a section.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewGroup = RadInputBox.Show("Please enter the description of the new group:", "Add New Group", "");
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(NewGroup)) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewGID = modDBSetup.FindMaxRecID(ref "tbl_Setup_HospStatGroup", ref "HospStatGroupID");
			modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroup (HospStatGroupID, GroupDescription, IndicatorGroupID) ";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + NewGID + ",'" + NewGroup + "'," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshHospStatGroups();
			//UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lstHospStatGroup.Text = NewGroup;

			//set the selected list item to the new one
			for (i = 0; i <= lstHospStatGroup.Items.Count - 1; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object NewGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, i) == NewGID) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstHospStatGroup.SelectedIndex = i;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			sstabGroupDetails.Enabled = true;

			RefreshHospStatGroupFields();

		}


		private void cmdRemoveFieldFromGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstHospStatGroupFields.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_setup_HospStatGroupFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroupFields, lstHospStatGroupFields.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and HospStatGroupID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			RefreshHospStatGroupFields();

		}

		private void cmdRemoveFieldIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstFieldIndicator.SelectedIndex > -1) {
				modGlobal.gv_sql = "Delete tbl_setup_HospStatGroupIndicator ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldIndicator, lstFieldIndicator.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and hospstatgroupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			}
			RefreshGroupIndicator();

		}

		private void cmdRemoveValidation_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcHospStatValid.Resultset.RowCount > 0) {
				modGlobal.gv_sql = "Delete tbl_Setup_HospStatval where HospStatvalidid = " + rdcHospStatValid.Resultset.rdoColumns["HospStatValidID"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshHospStatValidation();
			}

		}

		private void frmHospStatSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			sstabMainTab.SelectedIndex = 0;
			sstabGroupDetails.SelectedIndex = 0;
			sstabMainTab.Enabled = false;
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_status == "TEST") {
				cmdChangeStatus.Text = "Move to Active";
			} else {
				cmdChangeStatus.Text = "Move to Test";
			}

			RefreshBaseTableID();
			RefreshIndicatorSet();
			RefreshHospStatGroups();
			RefreshHospStatAllFields();
		}

//UPGRADE_WARNING: Event lstHospStatGroup.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstHospStatGroup_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshHospStatGroupFields();
			RefreshGroupIndicator();
			RefreshHospStatGroupForVal();
			RefreshHospStatValidation();



		}

		public void RefreshHospStatGroups()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			//retrieve the list of Hosp. Stat. Groups
			modGlobal.gv_sql = "Select tbl_setup_HospStatGroup.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup ";
			if (cboIndicatorGroup.SelectedIndex < 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID =  -1 ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by GroupDescription ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstHospStatGroup.Items.Clear();
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

				lstHospStatGroup.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupDescription"].Value, modGlobal.gv_rs.rdoColumns["HospStatGroupID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}

		public void RefreshHospStatGroupFields()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			if (lstHospStatGroup.SelectedIndex < 0) {
				//retrieve the list of Hosp. Stat. fields for the selected Group
				modGlobal.gv_sql = "Select tbl_setup_HospStatGroupFields.*, tbl_setup_datadef.FieldName  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields, tbl_setup_datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroupFields.DDID =  tbl_setup_datadef.DDID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.HospStatGroupID = -1 ";
				modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_HospStatGroupFields.fieldorder, tbl_setup_datadef.FieldName ";
			} else {
				//retrieve the list of Hosp. Stat. fields for the selected Group
				modGlobal.gv_sql = "Select tbl_setup_HospStatGroupFields.*, tbl_setup_datadef.FieldName  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields, tbl_setup_datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroupFields.DDID =  tbl_setup_datadef.DDID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.HospStatGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_HospStatGroupFields.fieldorder, tbl_setup_datadef.FieldName ";
			}


			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstHospStatGroupFields.Items.Clear();
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

				lstHospStatGroupFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}
		readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();

		short static_sstabMainTab_SelectedIndexChanged_PreviousTab;

		private void sstabMainTab_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			lock (static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init) {
				try {
					if (InitStaticVariableHelper(static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init)) {
						static_sstabMainTab_SelectedIndexChanged_PreviousTab = sstabMainTab.SelectedIndex();
					}
				} finally {
					static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init.State = 1;
				}
			}
			if (sstabMainTab.SelectedIndex == 1) {
				RefreshHospStatAllFields();
			}

			static_sstabMainTab_SelectedIndexChanged_PreviousTab = sstabMainTab.SelectedIndex();
		}


		public void RefreshHospStatGroupForVal()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			//retrieve the list of Hosp. Stat. Groups
			modGlobal.gv_sql = "Select tbl_setup_HospStatGroup.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ";
			if (lstHospStatGroup.SelectedIndex >= 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " HospStatGroupID <>  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex) + " and ";
			}
			if (cboIndicatorGroup.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorGroupID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorGroupID =  -1 ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by GroupDescription ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//If gv_rs.RowCount = 0 Then
			//    sstabGroupDetails.TabEnabled(2) = False
			//Else
			//    sstabGroupDetails.TabEnabled(2) = True
			//End If

			cboGroupList.Items.Clear();
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

				cboGroupList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupDescription"].Value, modGlobal.gv_rs.rdoColumns["HospStatGroupID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
		}

		public void AddValidation( object ValType)
		{
			object NextNewID = null;
			object ValDisplay = null;
			object TempTable = null;
			if (lstHospStatGroup.SelectedIndex == -1) {
				RadMessageBox.Show("Please select a group from the above list.");
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object TempTable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TempTable = "tbl_tempdetaildata";

			if (string.IsNullOrEmpty(cboOperator.Text)) {
				RadMessageBox.Show("Please define the operator.");
				return;
			}

			if (string.IsNullOrEmpty(cboGroupList.Text)) {
				RadMessageBox.Show("Please define the Group for comparison.");
				return;
			}


			if (string.IsNullOrEmpty(txtMessage.Text)) {
				RadMessageBox.Show("Please define the validation message.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object ValDisplay. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ValDisplay = lstHospStatGroup.Text + " " + cboOperator.Text + " " + cboGroupList.Text;
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref "tbl_setup_HospStatVal", ref "HospStatValidID");

			modGlobal.gv_sql = "insert into tbl_setup_HospStatVal (HospStatVALIDID, HospStatGroupID1, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " HospStatGroupID2, Display, Operator, Message, Type, EffDate)";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " ," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex) + ",";
			//UPGRADE_WARNING: Couldn't resolve default property of object ValDisplay. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + ValDisplay + "','" + cboOperator.Text + "','" + modGlobal.ConvertApastroph( txtMessage) + "',";
			//UPGRADE_WARNING: Couldn't resolve default property of object ValType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + ValType + "',";
			if (string.IsNullOrEmpty(txtValEffDate.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtValEffDate.Text + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshHospStatValidation();
			cboOperator.Text = "";
			cboGroupList.Text = "";
			txtMessage.Text = "";
			txtValEffDate.Text = "";

		}

		public void RefreshHospStatValidation()
		{
			if (lstHospStatGroup.SelectedIndex < 0) {
				//retrieve the list of validation for the selected group
				modGlobal.gv_sql = "Select  * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_HospStatVal ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where HospStatValidID  = -1 ";
			} else {
				//retrieve the list of validation for the selected group
				modGlobal.gv_sql = "Select  * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_HospStatVal ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where HospStatGroupID1  = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
			}


			rdcHospStatValid.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//resp = InputBox("", "", gv_sql) 'rdcPatientFields.Resultset.RowCount
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcHospStatValid.CtlRefresh();
			//RefreshFieldIndicator

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
