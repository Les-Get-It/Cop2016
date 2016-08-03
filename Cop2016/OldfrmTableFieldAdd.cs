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
	internal partial class OldfrmTableFieldAdd : System.Windows.Forms.Form
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
			if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Number" | cboFieldType.Text == "Date/Time") {
				chkUTD.Visible = true;
			} else {
				chkUTD.Visible = false;
				chkUTD.CheckState = false;
			}

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
		}

		private void cboFieldType_Leave(System.Object eventSender, System.EventArgs eventArgs)
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

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object FieldSize = null;

			if (cboFieldType.Text != "Text") {
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FieldSize = "Null";

			} else {
				if (string.IsNullOrEmpty(txtFieldSize.Text)) {
					lblFieldSize.Visible = true;
					txtFieldSize.Visible = true;
					Interaction.MsgBox("Please define the field size.");
					return;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FieldSize = txtFieldSize.Text;
				}
			}

			if (cboFieldType.Text == "Time" & cboDateFields.SelectedIndex < 0) {
				Interaction.MsgBox("There has to be a date field associated with this time field. Please define...");
				return;
			}

			if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & (string.IsNullOrEmpty(txtMaxSel.Text) | Information.IsNumeric(txtMaxSel.Text) == false)) {
				Interaction.MsgBox("There has to be a max number of selections associated with this field. Please define...");
				return;
			}


			int li_MaxSel = 0;
			int li_cnt = 0;
			int ParentDDID = 0;
			int NextNewID = 0;


			if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & Information.IsNumeric(txtMaxSel.Text) == true) {
				li_MaxSel = Convert.ToInt16(txtMaxSel.Text);
			} else {
				li_MaxSel = 1;
			}

			li_cnt = 1;
			ParentDDID = 0;

			while (li_cnt <= li_MaxSel) {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_Action = "Add";

				NextNewID = modDBSetup.FindMaxRecID(ref "tbl_setup_datadef", ref "DDID");
				if (ParentDDID == 0) {
					ParentDDID = NextNewID;
				}


				modGlobal.gv_sql = "Insert into tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " (DDID, BaseTableID, FieldName, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldType, FieldSize, Lookuptableid, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Help,  FieldCategory, State, RecordStatus,  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DateFieldDDID, Inactive ";
				modGlobal.gv_sql = modGlobal.gv_sql + (li_MaxSel > 1 ? ", ParentDDID" : "");
				modGlobal.gv_sql = modGlobal.gv_sql + ", AllowUTD, IsPhysician)";

				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmTableSetup.cboTableList, My.MyProject.Forms.frmTableSetup.cboTableList.SelectedIndex) + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtFieldName.Text + (li_MaxSel > 1 & li_cnt > 1 ? "-" + Convert.ToString(li_cnt) : "") + "', ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboFieldType.Text + "'," + FieldSize + ",";
				if (cboFieldType.Text != "Text" | string.IsNullOrEmpty(cbo_LookupTbls.Text)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
				} else if (cbo_LookupTbls.SelectedIndex > -1) {
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cbo_LookupTbls, cbo_LookupTbls.SelectedIndex) + ", ";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtHelp.Text + "', ";

				//'Dynamic',"

				modGlobal.gv_sql = modGlobal.gv_sql + "'" + (chkDynamic.CheckState ? "Dynamic" : "Fix") + "',";

				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_State + "', ";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_status)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "',";
				}
				if (cboDateFields.SelectedIndex > -1 & cboDateFields.Visible == true) {
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDateFields, cboDateFields.SelectedIndex) + " ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " null ";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + ", ";
				if (chkInactive.CheckState == 0) {
					modGlobal.gv_sql = modGlobal.gv_sql + " null";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " 'I' ";
				}


				modGlobal.gv_sql = modGlobal.gv_sql + (li_MaxSel > 1 ? ", " + Convert.ToString(ParentDDID) : "");
				modGlobal.gv_sql = modGlobal.gv_sql + "," + (chkUTD.Visible == false ? "NULL" : chkUTD.CheckState);

				//gv_sql = gv_sql & ")"

				modGlobal.gv_sql = modGlobal.gv_sql + ", " + chkPhysician.CheckState + ")";



				Debug.Print(modGlobal.gv_sql);
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);



				li_cnt = li_cnt + 1;
			}


			this.Close();
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Cancel";
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

		private void frmTableFieldAdd_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			//retrieve the order number
			//gv_sql = "Select max(FieldOrder) as MaxOrderNum from tbl_setup_DataDef "
			//gv_sql = gv_sql & " where BaseTableID = " & frmTableSetup.cboTableList.ItemData(frmTableSetup.cboTableList.ListIndex)
			//Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//If IsNull(gv_rs!MaxOrderNum) Then
			//    txtFieldOrder = 1
			//Else
			//    txtFieldOrder = gv_rs!MaxOrderNum + 1
			//End If

			RefreshLookupTablesList();
			RefreshDateFieldList();

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
	}
}
