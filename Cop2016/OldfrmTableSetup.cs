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
	internal partial class OldfrmTableSetup : System.Windows.Forms.Form
	{

		public void RefreshDataTableList()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			//retrieve the list of batch types
			modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where TableType is null or TableType = 'DATA' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcTableList.CtlRefresh();
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
//UPGRADE_WARNING: Event cboTableList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboTableList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshFieldList();
		}

		private void cmdAddField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object FoundIt = null;
			object NewDDID = null;

			if (string.IsNullOrEmpty(cboTableList.Text)) {
				Interaction.MsgBox("Please select a table from the list");
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "";
			My.MyProject.Forms.frmTableFieldAdd.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "Add") {
				RefreshFieldList();
				modGlobal.gv_sql = "Select max(DDID) as NewDDID from tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object NewDDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NewDDID = modGlobal.gv_rs.rdoColumns["NewDDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FoundIt = false;
				//UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				while ((!rdcFieldList.Resultset.EOF) & FoundIt == false) {
					if (rdcFieldList.Resultset.rdoColumns["DDID"].Value == NewDDID) {
						//UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						FoundIt = true;
					} else {
						rdcFieldList.Resultset.MoveNext();
					}
				}
			}

			//rdcFieldList.Resultset.Bookmark = bk

		}

		private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			object MoveToModule = null;

			if (rdcFieldList.Resultset.RowCount == 0) {
				return;
			}

			if (rdcFieldList.Resultset.rdoColumns["FieldCategory"].Value == "Fix") {
				Interaction.MsgBox("Cannot move this field, because this is a fix field.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = Interaction.MsgBox("Are you sure you want this field to the " + MoveToModule + " Module?", MsgBoxStyle.YesNo);
			if (resp == MsgBoxResult.No) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_DataDef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			RefreshFieldList();
		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object Delfield = null;
			object msg = null;
			object hasvalidation = null;

			if (rdcFieldList.Resultset.RowCount > 0) {
				if (rdcFieldList.Resultset.rdoColumns["FieldCategory"].Value == "Fix") {
					Interaction.MsgBox("Cannot delete this field, because this is a fix field.");
					return;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object hasvalidation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				hasvalidation = false;
				modGlobal.gv_sql = "Select * from tbl_setup_TableValidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where SourceDDID1 = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " or SourceDDID2 = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " or DestDDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.RowCount > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object hasvalidation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					hasvalidation = true;
				}
				modGlobal.gv_sql = "Select * from tbl_setup_TableValidationAction ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.RowCount > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object hasvalidation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					hasvalidation = true;
				}

				modGlobal.gv_sql = "Select * from tbl_setup_TableValidationAfterFieldupdate ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.RowCount > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object hasvalidation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					hasvalidation = true;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object hasvalidation. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (hasvalidation == true) {
					Interaction.MsgBox("This field has been used in the validation setup. Remove the related validation before deleting the field.");
					return;
				}

				modGlobal.gv_sql = "Select * from tbl_setup_submitsubgroupfields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where aggregatefieldid = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.RowCount > 0) {
					Interaction.MsgBox("This field has been used in the summarization process. Update the related summarization before deleting the field.");
					return;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (string.IsNullOrEmpty(rdcFieldList.Resultset.rdoColumns["OldFieldName"].Value) | Information.IsDBNull(rdcFieldList.Resultset.rdoColumns["OldFieldName"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msg = " Are you sure that you want to delete this field?";
					//UPGRADE_WARNING: Couldn't resolve default property of object Delfield. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Delfield = Interaction.MsgBox(msg, MsgBoxStyle.YesNo, "Delete Field");
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msg = "This field has been mapped to a field in the older version." + Strings.Chr(10) + Strings.Chr(13);
					//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msg = msg + " Are you sure you want to delete this field?";
					//UPGRADE_WARNING: Couldn't resolve default property of object Delfield. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Delfield = Interaction.MsgBox(msg, MsgBoxStyle.YesNo, "Delete Field");
				}
				if (Delfield == MsgBoxResult.Yes) {



					modGlobal.gv_sql = "Delete tbl_setup_DataReq ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "Delete tbl_setup_HospStatGroupFields ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "Delete tbl_setup_IndicatorGroupSet ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "delete tbl_setup_Importvalidation ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "delete tbl_setup_Importvalidation ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where msgid in  ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (select ivm.msgid ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Importvalidationmessage as ivm ";
					modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_importfields as imf ";
					modGlobal.gv_sql = modGlobal.gv_sql + " on ivm.importfieldid = imf.importfieldid ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where imf.DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value + ")";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "delete tbl_setup_Importvalidationmessage ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where importfieldid in  ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_importfields ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value + ")";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "delete tbl_setup_ImportFields ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "delete tbl_setup_submitcleanupcrit ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;

					modGlobal.gv_sql = "delete tbl_setup_submitcleanupcrit ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where submitcleanupid in ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (select submitcleanupid from tbl_setup_submitcleanupitems ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value + ")";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "delete tbl_setup_submitcriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID1 = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + " or DDID2 = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);


					modGlobal.gv_sql = "delete tbl_setup_savedadhocreportcriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where SourceDDID1 = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + " or SourceDDID2 = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + " or DestDDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "delete tbl_setup_savedadhocreportfields ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "Delete tbl_setup_DataDef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					modGlobal.gv_sql = "Delete tbl_setup_DataDefActions ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

					RefreshFieldList();

				}
			}

		}

		private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object bk = null;
			if (rdcFieldList.Resultset.RowCount > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object rdcFieldList.Resultset.Bookmark. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object bk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				bk = rdcFieldList.Resultset.Bookmark;
				My.MyProject.Forms.frmTableEditField.ShowDialog();
				this.RefreshFieldList();
				//UPGRADE_WARNING: Couldn't resolve default property of object bk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				rdcFieldList.Resultset.Bookmark = bk;
			}

		}

		private void cmdMoveDown_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object ThisFieldID = null;
			object CurrOrderNum = null;
			object FCount = null;
			if (rdcFieldList.Resultset.RowCount < 0) {
				return;
			}

			//retrieve the list of  fields for the selected Section
			modGlobal.gv_sql = "Select  ddid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//first we make sure every field in this list has a number
			//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FCount = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = FCount + 1;
				modGlobal.gv_sql = "Update tbl_setup_DataDef ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + FCount;
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				if (rdcFieldList.Resultset.rdoColumns["DDID"].Value == modGlobal.gv_rs.rdoColumns["DDID"].Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrOrderNum = FCount;
				}
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisFieldID = rdcFieldList.Resultset.rdoColumns["DDID"].Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (CurrOrderNum + 1 > 0) {
				//update order number of the field after to this one
				modGlobal.gv_sql = "Update tbl_setup_Datadef ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + CurrOrderNum;
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and SortOrder = " + CurrOrderNum + 1;

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//update order number of this field
				modGlobal.gv_sql = "Update tbl_setup_datadef ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set sortOrder = " + CurrOrderNum + 1;
				modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + ThisFieldID;

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshFieldList();

				//find the right field
				for (i = 1; i <= rdcFieldList.Resultset.RowCount; i++) {
					if (rdcFieldList.Resultset.rdoColumns["DDID"].Value == ThisFieldID) {
						break; // TODO: might not be correct. Was : Exit For
					}
					rdcFieldList.Resultset.MoveNext();
				}

			}

		}

		private void cmdMoveUp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object ThisFieldID = null;
			object CurrOrderNum = null;
			object FCount = null;
			if (rdcFieldList.Resultset.RowCount < 0) {
				return;
			}

			//retrieve the list of  fields for the selected Section
			modGlobal.gv_sql = "Select  ddid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//first we make sure every field in this list has a number
			//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FCount = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FCount = FCount + 1;
				modGlobal.gv_sql = "Update tbl_setup_DataDef ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + FCount;
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				if (rdcFieldList.Resultset.rdoColumns["DDID"].Value == modGlobal.gv_rs.rdoColumns["DDID"].Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrOrderNum = FCount;
				}
				modGlobal.gv_rs.MoveNext();
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ThisFieldID = rdcFieldList.Resultset.rdoColumns["DDID"].Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (CurrOrderNum - 1 > 0) {
				//update order number of the field prior to this one
				modGlobal.gv_sql = "Update tbl_setup_Datadef ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + CurrOrderNum;
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and SortOrder = " + CurrOrderNum - 1;

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//update order number of this field
				modGlobal.gv_sql = "Update tbl_setup_datadef ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set sortOrder = " + CurrOrderNum - 1;
				modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + ThisFieldID;

				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				RefreshFieldList();

				//find the right field
				for (i = 1; i <= rdcFieldList.Resultset.RowCount; i++) {
					if (rdcFieldList.Resultset.rdoColumns["DDID"].Value == ThisFieldID) {
						break; // TODO: might not be correct. Was : Exit For
					}
					rdcFieldList.Resultset.MoveNext();
				}

			}
		}

		private void cmdUpdateDEA_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcFieldList.Resultset.RowCount == 0) {
				return;
			}

			My.MyProject.Forms.frmTableActionSetup.ShowDialog();

		}

		private void frmTableSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_status == "TEST") {
				cmdChangeStatus.Text = "Move to Active";
			} else {
				cmdChangeStatus.Text = "Move to Test";
			}

			RefreshDataTableList();
			RefreshFieldList();


		}

		public void RefreshFieldList()
		{
			string ls_FieldList = null;


			 // ERROR: Not supported in C#: OnErrorStatement


			ls_FieldList = "[DDID] ,[BaseTableID], [FieldName],convert(varchar(255), [Help]) as Help,[FieldType],[LookupTableID] ,[FieldSize] ,[FieldOrderold]  ,[OldFieldName] ,[Required] ,[Required_EffDate] ,[FieldCategory] ,[State] ,[RecordStatus],[SortOrder],[DateFieldDDID],[CMSFieldCode],[JCFieldCode],[Inactive],[ParentDDID],[AllowUTD],[IsPhysician]";

			if (cboTableList.SelectedIndex > -1) {
				//clean up possible lookup table definition for fields that are date type
				modGlobal.gv_sql = " update tbl_setup_datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set lookuptableid = null";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and upper(fieldtype) = 'DATE'";
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//retrieve the list of table fields
				modGlobal.gv_sql = "Select " + ls_FieldList + ", Category = ";
				modGlobal.gv_sql = modGlobal.gv_sql + " case when FieldCategory = 'Fix' then";
				modGlobal.gv_sql = modGlobal.gv_sql + "  'Fix' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " else 'Dyn' ";
				modGlobal.gv_sql = modGlobal.gv_sql + "  end, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " AI = case when InActive is Null then";
				modGlobal.gv_sql = modGlobal.gv_sql + "  'A' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " else 'I' ";
				modGlobal.gv_sql = modGlobal.gv_sql + "  end ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (ParentDDID IS NULL OR ParentDDID = DDID) ";

				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and State = '" + modGlobal.gv_State + "'";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_status)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
				}
				if (cboTableList.Text == "HOSPITAL DEMOGRAPHICS") {
					modGlobal.gv_sql = modGlobal.gv_sql + " order by SORTorder ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldCategory desc, FieldName asc ";
				}
			} else {
				modGlobal.gv_sql = "Select " + ls_FieldList + ", Category = ";
				modGlobal.gv_sql = modGlobal.gv_sql + " case when FieldCategory = 'Fix' then";
				modGlobal.gv_sql = modGlobal.gv_sql + "  'Fix' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " else 'Dyn' ";
				modGlobal.gv_sql = modGlobal.gv_sql + "  end ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = 0 ";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and State = '" + modGlobal.gv_State + "'";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_status)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
				}
				if (cboTableList.Text == "HOSPITAL DEMOGRAPHICS") {
					modGlobal.gv_sql = modGlobal.gv_sql + " order by SORTorder ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldCategory desc , FieldName asc";
				}
			}

			rdcFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcFieldList.CtlRefresh();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgFieldList.CtlRefresh();

			if (cboTableList.Text == "HOSPITAL DEMOGRAPHICS") {
				cmdMoveUp.Visible = true;
				cmdMoveDown.Visible = true;
			} else {
				cmdMoveUp.Visible = false;
				cmdMoveDown.Visible = false;
			}

			//End If
			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}
	}
}
