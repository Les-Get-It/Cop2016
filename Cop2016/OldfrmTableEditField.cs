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
	internal partial class OldfrmTableEditField : System.Windows.Forms.Form
	{

//UPGRADE_WARNING: Event cbo_LookupTbls.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cbo_LookupTbls_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cbo_LookupTbls.SelectedIndex > -1) {
				chkMultipleSel.Enabled = true;
			} else {
				chkMultipleSel.Enabled = false;
			}
		}

//UPGRADE_WARNING: Event cboFieldType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboFieldType_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboFieldType.Text == "Text") {
				txtFieldSize.Visible = true;
				lblFieldSize.Visible = true;
				cbo_LookupTbls.Visible = true;
				lblLookupTable.Visible = true;
				txtFieldSize.Focus();
			} else {
				txtFieldSize.Visible = false;
				lblFieldSize.Visible = false;
				cbo_LookupTbls.Visible = false;
				lblLookupTable.Visible = false;
			}

			if (cboFieldType.Text == "Time") {
				cboDateFields.Visible = true;
				lblDateFields.Visible = true;
			} else {
				cboDateFields.Visible = false;
				lblDateFields.Visible = false;
			}

			if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Number" | cboFieldType.Text == "Date/Time") {
				chkUTD.Visible = true;
			} else {
				chkUTD.Visible = false;
			}

		}

//UPGRADE_WARNING: Event chkMultipleSel.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkMultipleSel_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkMultipleSel.CheckState == CheckState.Checked) {
				txtMaxSel.Enabled = true;
				lblMaxSel.Enabled = true;
			} else {
				txtMaxSel.Enabled = false;
				lblMaxSel.Enabled = false;
			}
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdateField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object ParentDDID = null;
			object rsMaxBefore = null;

			if (string.IsNullOrEmpty(txtFieldName.Text) | string.IsNullOrEmpty(cboFieldType.Text)) {
				Interaction.MsgBox("Please define both name and type of the field");
				return;
			}
			if (cboFieldType.Text == "Text") {
				if (string.IsNullOrEmpty(txtFieldSize.Text)) {
					Interaction.MsgBox("Please define the field size.");
					return;
				}
				if (Convert.ToInt16(txtFieldSize.Text) > 50) {
					Interaction.MsgBox("The size of a text field cannot be more than 50. Please correct it.");
					return;
				}
			} else {
				txtFieldSize.Text = "";
			}

			if (cboFieldType.Text == "Time" & string.IsNullOrEmpty(cboDateFields.Text)) {
				Interaction.MsgBox("There has to be a date field associated with this time field. Please define...");
				return;
			}

			if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & (string.IsNullOrEmpty(txtMaxSel.Text) | Information.IsNumeric(txtMaxSel.Text) == false)) {
				Interaction.MsgBox("There has to be a max number of selections associated with this field. Please define...");
				return;
			}


			if (chkMultipleSel.CheckState == 0) {
				modGlobal.gv_cn.Execute("DELETE FROM tbl_Setup_DataDef WHERE ParentDDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value);
			} else {
				modGlobal.gv_sql = "SELECT Count(DDID) as MaxBefore FROM tbl_Setup_DataDef WHERE ParentDDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				rsMaxBefore = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//check to see if there's a change in the number of multiple occurence fields
				//UPGRADE_WARNING: Couldn't resolve default property of object rsMaxBefore!MaxBefore. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (rsMaxBefore["MaxBefore"] != Convert.ToInt16(txtMaxSel.Text)) {
					//call stored proc to update
					modGlobal.gv_sql = "EXEC ChangeMultipleOccurenceMax " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value + ", " + txtMaxSel.Text;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				}
				//UPGRADE_WARNING: Couldn't resolve default property of object rsMaxBefore.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rsMaxBefore.Close();
				//UPGRADE_NOTE: Object rsMaxBefore may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rsMaxBefore = null;

			}

			//UPGRADE_WARNING: Couldn't resolve default property of object ParentDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ParentDDID = My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value;


			modGlobal.gv_sql = "update tbl_setup_DataDef SET ";

			if (chkMultipleSel.CheckState == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldName = '" + modGlobal.ConvertApastroph(ref txtFieldName) + "',";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " FieldType =  '" + cboFieldType.Text + "',";
			if (chkInactive.CheckState == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Inactive = null,";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Inactive = 'I',";
			}
			if (string.IsNullOrEmpty(txtFieldSize.Text) | txtFieldSize.Text == "0") {
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldSize = null,";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldSize = '" + txtFieldSize.Text + "',";
			}
			if (cboFieldType.Text != "Text" | string.IsNullOrEmpty(cbo_LookupTbls.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Lookuptableid = null, ";
			} else if (cbo_LookupTbls.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Lookuptableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cbo_LookupTbls, cbo_LookupTbls.SelectedIndex) + ", ";
			}

			if (chkMultipleSel.CheckState == 0) {
				//remove any potential parentddid for the ddid
				modGlobal.gv_sql = modGlobal.gv_sql + " ParentDDID = NULL, ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object ParentDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " ParentDDID = " + ParentDDID + ",";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " Help = '" + modGlobal.ConvertApastroph(ref txtHelp) + "',";
			if (cboDateFields.SelectedIndex < 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " DateFieldDDID = Null ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " DateFieldDDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDateFields, cboDateFields.SelectedIndex) + " ";
			}
			if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Date/Time" | cboFieldType.Text == "Number") {
				modGlobal.gv_sql = modGlobal.gv_sql + ", AllowUTD = " + chkUTD.CheckState;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + ", AllowUTD = NULL";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + ", IsPhysician = " + chkPhysician.CheckState;
			modGlobal.gv_sql = modGlobal.gv_sql + ", FieldCategory= '" + (chkDynamic.CheckState ? "Dynamic" : "Fix") + "'";


			if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & Information.IsNumeric(txtMaxSel.Text) == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where ParentDDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value;
			}


			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//Debug.Print gv_sql

			this.Close();


		}

		private void RefreshLookupTablesList()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
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


			modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

			rdcLookupTableList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcLookupTableList.CtlRefresh();

			cbo_LookupTbls.Items.Clear();
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
				cbo_LookupTbls.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcLookupTableList.Resultset.rdoColumns["BaseTable"].Value, rdcLookupTableList.Resultset.rdoColumns["basetableid"].Value));
				rdcLookupTableList.Resultset.MoveNext();

			}

		}

		private void frmTableEditField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			object rsTemp = null;
			object rdUseclient = null;

            this.CenterToParent();
			//If Not IsNull(frmTableSetup.rdcFieldList.Resultset!FieldOrder) Then
			//    txtFieldOrder = frmTableSetup.rdcFieldList.Resultset!FieldOrder
			//End If
			txtFieldName.Text = My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["FieldName"].Value;
			if (My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["Inactive"].Value == "I") {
				chkInactive.CheckState = System.Windows.Forms.CheckState.Checked;
			} else {
				chkInactive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			}

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (!Information.IsDBNull(My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["FieldType"].Value)) {
				cboFieldType.Text = My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["FieldType"].Value;
				if (cboFieldType.Text == "Text") {
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (!Information.IsDBNull(My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["FieldSize"].Value)) {
						txtFieldSize.Text = My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["FieldSize"].Value;
					}
					txtFieldSize.Visible = true;
					lblFieldSize.Visible = true;
				}
			}

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			RDO.CursorDriverConstants ld_Restore = default(RDO.CursorDriverConstants);
			System.Data.DataSet  rs_Help = null;
			if (!Information.IsDBNull(My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["help"].Value)) {
				//txtHelp.Text = frmTableSetup.dbgFieldList.Columns(5)

				ld_Restore = RDOrdoEngine_definst.rdoDefaultCursorDriver;
				//UPGRADE_WARNING: Couldn't resolve default property of object rdUseclient. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RDOrdoEngine_definst.rdoDefaultCursorDriver = rdUseclient;

				modGlobal.gv_sql = "SELECT Help FROM tbl_Setup_DataDef where DDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				rs_Help = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				txtHelp.Text = rs_Help.rdoColumns["help"].Value + "";
				rs_Help.Close();
				//UPGRADE_NOTE: Object rs_Help may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rs_Help = null;
				RDOrdoEngine_definst.rdoDefaultCursorDriver = ld_Restore;

			}


			if (My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["FieldCategory"].Value == "Fix") {
				//txtFieldOrder.Enabled = False
				txtFieldName.Enabled = false;
				cboFieldType.Enabled = false;
				txtFieldSize.Enabled = false;
				//txtHelp.Enabled = False
			} else {
				chkDynamic.CheckState = System.Windows.Forms.CheckState.Checked;
			}

			RefreshLookupTablesList();
			if (cboFieldType.Text == "Text") {
				RefreshLookupTable();
				cbo_LookupTbls.Visible = true;
				lblLookupTable.Visible = true;
			} else {
				cbo_LookupTbls.Visible = false;
				lblLookupTable.Visible = false;
			}

			RefreshDateFieldList();
			if (cboFieldType.Text == "Time") {
				RefreshDateField();
				cboDateFields.Visible = true;
				lblDateFields.Visible = true;
			} else {
				cboDateFields.Visible = false;
				lblDateFields.Visible = false;
			}

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (!Information.IsDBNull(My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["ParentDDID"].Value)) {
				chkMultipleSel.Enabled = true;
				chkMultipleSel.CheckState = System.Windows.Forms.CheckState.Checked;
				txtMaxSel.Enabled = true;

				rsTemp = modGlobal.gv_cn.OpenResultset("SELECT COUNT(*) maxcnt FROM tbl_Setup_DataDef WHERE ParentDDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object rsTemp!maxcnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtMaxSel.Text = Convert.ToString(rsTemp["maxcnt"]);

				//UPGRADE_WARNING: Couldn't resolve default property of object rsTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rsTemp.Close();
				//UPGRADE_NOTE: Object rsTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rsTemp = null;
			}

			if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Number" | cboFieldType.Text == "Date/Time") {
				chkUTD.Visible = true;
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				chkUTD.CheckState = (Information.IsDBNull(My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["AllowUTD"].Value) ? 0 : (My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["AllowUTD"].Value == true ? 1 : 0));
			} else {
				chkUTD.Visible = false;
			}

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (!Information.IsDBNull(My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["IsPhysician"].Value)) {
				chkPhysician.CheckState = (My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["IsPhysician"].Value ? 1 : 0);
			}

		}
		public void RefreshDateFieldList()
		{
			var LIndex = 0;

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmTableSetup.cboTableList, My.MyProject.Forms.frmTableSetup.cboTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and fieldtype = 'Date' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboDateFields.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				cboDateFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();


		}

		private void RefreshLookupTable()
		{
			var i = 0;

			modGlobal.gv_sql = "Select LookupTableID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value;

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				cbo_LookupTbls.Text = "";
				cbo_LookupTbls.SelectedIndex = -1;
			} else {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {

					for (i = 0; i <= cbo_LookupTbls.Items.Count - 1; i++) {
						if (modGlobal.gv_rs.rdoColumns["LookupTableID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cbo_LookupTbls, i)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							cbo_LookupTbls.SelectedIndex = i;
						}
					}
				} else {
					cbo_LookupTbls.Text = "";
					cbo_LookupTbls.SelectedIndex = -1;
				}
			}

		}

		public void RefreshDateField()
		{
			var i = 0;
			modGlobal.gv_sql = "Select DateFieldDDID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value;

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				cboDateFields.Text = "";
				cboDateFields.SelectedIndex = -1;
			} else {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateFieldDDID"].Value)) {
					for (i = 0; i <= cboDateFields.Items.Count - 1; i++) {
						if (modGlobal.gv_rs.rdoColumns["DateFieldDDID"].Value == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDateFields, i)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							cboDateFields.SelectedIndex = i;
						}
					}

				} else {
					cboDateFields.Text = "";
					cboDateFields.SelectedIndex = -1;
				}
			}

		}
	}
}
