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
	internal partial class OldfrmImportSetup : System.Windows.Forms.Form
	{

//UPGRADE_WARNING: Event cboLookupList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboLookupList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtCriteria.Text = "";
			OptCritLKUp[4].Checked = true;
		}

//UPGRADE_WARNING: Event cboLookupValues.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboLookupValues_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			optCritValue[1].Checked = true;
		}

		private void cmdAddError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtAction.Text = "Add Error";
			frmImportAddValidFieldCopy.cmdAdd.Text = "Add Error Message";
			frmImportAddValidFieldCopy.ShowDialog();
			RefreshErrorMessages();
			rdcImportValError.Resultset.MoveLast();

		}

		private void cmdAddField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newid = null;
			object NextOrderID = null;
			if (lstAvailableFields.SelectedIndex > -1) {

				//UPGRADE_WARNING: Couldn't resolve default property of object NextOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NextOrderID = GetNextFieldOrderID();
				//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newid = modDBSetup.FindMaxRecID(ref "tbl_Setup_ImportFields", ref "ImportFieldID");

				modGlobal.gv_sql = "Insert into tbl_Setup_ImportFields (Importfieldid, importsetupid, DDID, OrderNumber)";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " values(" + newid + "," + modGlobal.gv_importsetupid + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstAvailableFields, lstAvailableFields.SelectedIndex) + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object NextOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + NextOrderID;
				modGlobal.gv_sql = modGlobal.gv_sql + ")";

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				RefreshSelectedFields();
				RefreshAvailableFields();
			}
		}

		private void cmdAddWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtAction.Text = "Add Warning";
			frmImportAddValidFieldCopy.cmdAdd.Text = "Add Warning";
			frmImportAddValidFieldCopy.ShowDialog();
			RefreshWarningMessages();
			rdcImportValWarning.Resultset.MoveLast();

		}

		private void cmdAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object msgid = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msgid = 0;
			if (sstabValidation.TabIndex == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			}

			//update the join operator in the report definition table
			modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set joinOperator = 'AND' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + msgid;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


			if (sstabValidation.SelectedIndex == 0) {
				//rdcImportValError.Resultset.Requery
				RefreshECriteriaList();
			} else {
				//rdcImportValWarning.Resultset.Requery
				RefreshWCriteriaList();
			}


			RefreshCriteriaButtons();

		}

		private void cmdCancel_Click()
		{
			InitCriteria();
		}

		private void cmdChangeToError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcImportValWarning.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Warning to an Error?", MessageBoxButtons.YesNo, "Change status"));
			if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes)) {
				modGlobal.gv_sql = "update tbl_setup_importValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set ValidationType = 'ERROR' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where MsgID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				RefreshErrorMessages();
				RefreshWarningMessages();
				RefreshCriteriaButtons();
			}

		}

		private void cmdChangeToWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (rdcImportValError.Resultset.RowCount <= 0) {
				return;
			}

			modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Error to a Warning?", MessageBoxButtons.YesNo, "Change Status"));
			if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes)) {
				modGlobal.gv_sql = "update tbl_setup_importValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set ValidationType = 'WARNING' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where MsgID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				RefreshErrorMessages();
				RefreshWarningMessages();
				RefreshCriteriaButtons();
			}
		}

		private void cmdCopyValidation_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			frmImportCopyValidationCopy.ShowDialog();

			RefreshErrorMessages();
			RefreshWarningMessages();
			RefreshCriteriaButtons();

		}

		private void cmdEditError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtAction.Text = "Edit Error";
			frmImportAddValidFieldCopy.cmdAdd.Text = "Update Error";
			frmImportAddValidFieldCopy.Show();

		}

		private void cmdEditWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			txtAction.Text = "Edit Warning";
			frmImportAddValidFieldCopy.cmdAdd.Text = "Update Warning";
			frmImportAddValidFieldCopy.Show();

		}

		private void cmdHelp_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object msg = null;
			object lkvalue = null;
			object lstFieldListForCriteria = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object lstFieldListForCriteria.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (lstFieldListForCriteria.ListIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Select DDID, LookupTableID, help, FieldType from tbl_Setup_DataDef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object lstFieldListForCriteria.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lstFieldListForCriteria.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + lstFieldListForCriteria.ItemData(lstFieldListForCriteria.ListIndex);

			DAO.Workspace wrkODBC = null;
			DAO.Connection conpubs = null;
			//Dim dtHelp As Data
			wrkODBC = DAODBEngine_definst.CreateWorkspace("NewODBCWorkspace", "", "", DAO.WorkspaceTypeEnum.dbUseODBC);
			conpubs = wrkODBC.OpenConnection("Connection1", , , "ODBC;DATABASE=COP2001;UID=sa;PWD=;DSN=COP2001");
			//UPGRADE_ISSUE: Data property dtHelp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			dtHelp.Recordset = conpubs.OpenRecordset(modGlobal.gv_sql, 2);


			//UPGRADE_ISSUE: Data property dtHelp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			System.Data.DataSet  lkrs = null;
			if (!Information.IsDBNull(dtHelp.Recordset.Fields("LookupTableID").Value)) {
				modGlobal.gv_sql = "Select * from tbl_Setup_misclookuplist ";
				//UPGRADE_ISSUE: Data property dtHelp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + dtHelp.Recordset.Fields("LookupTableID").Value;
				lkrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lkvalue = "";
				while (!lkrs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(lkvalue)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lkvalue = lkrs.rdoColumns["Id"].Value + ". " + lkrs.rdoColumns["FIELDVALUE"].Value;
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lkvalue = lkvalue + Strings.Chr(13) + Strings.Chr(10) + lkrs.rdoColumns["Id"].Value + ". " + lkrs.rdoColumns["FIELDVALUE"].Value;
					}
					lkrs.MoveNext();
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msg = "";
			//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_ISSUE: Data property dtHelp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if ((string.IsNullOrEmpty(dtHelp.Recordset.Fields("help").Value) | Information.IsDBNull(dtHelp.Recordset.Fields("help").Value)) & string.IsNullOrEmpty(lkvalue)) {
				//UPGRADE_ISSUE: Data property dtHelp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				RadMessageBox.Show("Field Type: " + dtHelp.Recordset.Fields("FieldType").Value);
			} else {
				//UPGRADE_ISSUE: Data property dtHelp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(dtHelp.Recordset.Fields("help").Value)) {
					//UPGRADE_ISSUE: Data property dtHelp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msg = dtHelp.Recordset.Fields("help").Value;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (!string.IsNullOrEmpty(lkvalue)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(msg)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						msg = "Valid values: " + Strings.Chr(10) + Strings.Chr(13) + lkvalue;
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						msg = msg + Strings.Chr(10) + Strings.Chr(13) + "Valid values: " + Strings.Chr(10) + Strings.Chr(13) + lkvalue;
					}
				}
				RadMessageBox.Show(msg);
			}

			conpubs.Close();
		}

		private void cmdMoveToAbsPosition_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			int CurrentOrderNumber = 0;
			int NewPos = 0;
			int TotalFields = 0;


			if (lstSelectedFields.SelectedIndex > -1) {
				//TotalFields = lstSelectedFields.ItemData(lstSelectedFields.ListIndex)
				TotalFields = lstSelectedFields.Items.Count + 1;

				NewPos = Convert.ToInt16(Interaction.InputBox("Type in the order number for this field (should be between 2 and " + TotalFields + ")", "Move Field Position", Convert.ToString(1)));
				if (!Information.IsNumeric(NewPos)) {
					RadMessageBox.Show("Numeric values only.");
					return;
				}
				if (Convert.ToInt16(NewPos) < 2 | Convert.ToInt16(NewPos) > TotalFields) {
					RadMessageBox.Show("Invalid position.");
					return;
				}

				modGlobal.gv_sql = "Select OrderNumber from tbl_Setup_ImportFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and ImportSetupID = " + modGlobal.gv_importsetupid;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value)) {
					//reorganize the fields
				} else {

					CurrentOrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;

					//if moving the field down
					if (NewPos > CurrentOrderNumber) {
						//update all orders before the value to - 1, except the value >= currentordernumber
						modGlobal.gv_sql = "UPDATE tbl_setup_ImportFields SET OrderNumber = OrderNumber - 1";
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ImportSetupID = " + modGlobal.gv_importsetupid;
						modGlobal.gv_sql = modGlobal.gv_sql + " AND OrderNumber > " + CurrentOrderNumber + " AND OrderNumber <= " + NewPos;
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

					//if moving the field up
					} else if (NewPos < CurrentOrderNumber) {
						//update all orders after the value to + 1, except the value >= currentordernumber
						modGlobal.gv_sql = "UPDATE tbl_setup_ImportFields SET OrderNumber = OrderNumber + 1";
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ImportSetupID = " + modGlobal.gv_importsetupid;
						modGlobal.gv_sql = modGlobal.gv_sql + " AND OrderNumber >= " + NewPos + " AND OrderNumber < " + CurrentOrderNumber;
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					}


					//set to the new order number
					modGlobal.gv_sql = "UPDATE tbl_setup_ImportFields SET OrderNumber = " + NewPos;
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ImportSetupID = " + modGlobal.gv_importsetupid;
					modGlobal.gv_sql = modGlobal.gv_sql + " AND DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				}

				RefreshSelectedFields();

			}

		}


		private void cmdMoveFieldDown_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object CurrentField = null;
			object CurrentOrderNumber = null;

			System.Data.DataSet  thisrs = null;
			if (lstSelectedFields.SelectedIndex > -1) {
				modGlobal.gv_sql = "Select OrderNumber from tbl_Setup_ImportFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and ImportSetupID = " + modGlobal.gv_importsetupid;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value)) {
					//reorganize the fields
				} else {

					//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrentOrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
					modGlobal.gv_sql = "select *  ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_ImportFields ";
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where OrderNumber > " + CurrentOrderNumber;
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and ImportSetupID = " + modGlobal.gv_importsetupid;
					modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ORDERNUMBER";
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (modGlobal.gv_rs.RowCount > 0) {

						//update the field that is one order higher than this one
						modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + CurrentOrderNumber;
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " where OrderNumber = " + CurrentOrderNumber + 1;
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and ImportSetupID = " + modGlobal.gv_importsetupid;

						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						//update this field
						modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + CurrentOrderNumber + 1;
						modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and ImportSetupID = " + modGlobal.gv_importsetupid;

						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						//set focus on the same field after refresh
						modGlobal.gv_sql = "select tbl_setup_ImportFields.*, tbl_Setup_DataDef.Fieldname ";
						modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_setup_ImportFields ";
						modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.OrderNumber = " + CurrentOrderNumber + 1;
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.ImportSetupID = " + modGlobal.gv_importsetupid;

						thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

						//MsgBox CurrentField
						RefreshSelectedFields();

						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CurrentField = thisrs.rdoColumns["OrderNumber"].Value + ". " + thisrs.rdoColumns["FieldName"].Value;

						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstSelectedFields.Text = CurrentField;
					}
				}

			}
		}

		private void cmdMoveFieldup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object CurrentField = null;
			object CurrentOrderNumber = null;

			System.Data.DataSet  thisrs = null;
			if (lstSelectedFields.SelectedIndex > -1) {
				modGlobal.gv_sql = "Select OrderNumber from tbl_Setup_ImportFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
				modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ORDERNUMBER";

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value)) {
					//reorganize the fields
				} else {
					if (modGlobal.gv_rs.rdoColumns["OrderNumber"].Value > 1) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CurrentOrderNumber = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
						//update the field that is one order higher than this one
						modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + CurrentOrderNumber;
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " where OrderNumber = " + CurrentOrderNumber - 1;
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						//update this field
						modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + CurrentOrderNumber - 1;
						modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;

						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

						modGlobal.gv_sql = "select tbl_setup_ImportFields.*, tbl_Setup_DataDef.Fieldname ";
						modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_setup_ImportFields ";
						modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.OrderNumber = " + CurrentOrderNumber - 1;
						//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
						modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ORDERNUMBER";
						thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

						//MsgBox CurrentField
						RefreshSelectedFields();
						//set focus on the same field after refresh
						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CurrentField = thisrs.rdoColumns["OrderNumber"].Value + ". " + thisrs.rdoColumns["FieldName"].Value;

						//UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstSelectedFields.Text = CurrentField;

					}
				}

			}

		}


		public void RefreshTableList()
		{
			var LIndex = 0;
			object this_ListIndex = null;
			object cboTableList = null;

			//retrieve the list of tables
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tabletype <> 'LOOKUP' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object cboTableList.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboTableList.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			this_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				this_ListIndex = LIndex;

				cboTableList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));
				modGlobal.gv_rs.MoveNext();
			}


		}


		public void RefreshSelectedFields()
		{
			object OrderNumber = null;

			//remove any field that was not deleted from this list when it was deleted from the data definition
			modGlobal.gv_sql = "delete tbl_setup_ImportFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + "where ddid not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select ddid from  tbl_setup_DataDef";
			modGlobal.gv_sql = modGlobal.gv_sql + ") ";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			//    ' add dicharge date if it doesn't exist or update its order number to be the first one
			//    gv_sql = "select tbl_setup_DataDef.* , tbl_setup_ImportFields.OrderNumber  "
			//    gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_ImportFields  "
			//    gv_sql = gv_sql & " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID "
			//    gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
			//    gv_sql = gv_sql & " and tbl_setup_ImportFields.importsetupid = " & gv_importsetupid
			//
			//    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//    If gv_rs.RowCount = 0 Then
			//        'add discharge date
			//        gv_sql = "select tbl_setup_DataDef.DDID "
			//        gv_sql = gv_sql & " from tbl_setup_DataDef "
			//        gv_sql = gv_sql & " where "
			//        gv_sql = gv_sql & " tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
			//        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
			//        If gv_rs.RowCount > 0 Then
			//            DischDDID = gv_rs!DDID
			//            OrderNumber = 2
			//            newid = FindMaxRecID("tbl_Setup_ImportFields", "ImportFieldID")
			//            gv_sql = "Insert into tbl_Setup_ImportFields(importfieldid, importsetupid, DDID, OrderNumber) "
			//            gv_sql = gv_sql & " values (" & newid & "," & gv_importsetupid & "," & DischDDID & "," & OrderNumber
			//            gv_sql = gv_sql & ")"
			//            gv_cn.Execute gv_sql
			//        End If
			//    End If

			//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OrderNumber = 1;
			modGlobal.gv_sql = "Select * from tbl_Setup_ImportFields ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
			modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderNumber ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OrderNumber = OrderNumber + 1;
				modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object OrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + OrderNumber;
				modGlobal.gv_sql = modGlobal.gv_sql + " Where importfieldid = " + modGlobal.gv_rs.rdoColumns["ImportFieldID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				modGlobal.gv_rs.MoveNext();
			}


			//refresh the list
			lstSelectedFields.Items.Clear();
			lstImportFields.Items.Clear();

			modGlobal.gv_sql = "select tbl_setup_DataDef.* , tbl_setup_ImportFields.OrderNumber  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportFields  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_ImportFields.OrderNumber ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				lstSelectedFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value + ". " + modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				lstImportFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value + ". " + modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}

		public void RefreshAvailableFields()
		{
			lstAvailableFields.Items.Clear();

			modGlobal.gv_sql = "select tbl_setup_DataDef.*   ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_tabledef  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.BaseTableID = tbl_setup_tabledef.BaseTableID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_tabledef.BaseTable = 'PATIENT' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_datadef.DDID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select DDID from tbl_setup_importFields ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				lstAvailableFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();
		}



		private void cmdOr_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object msgid = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msgid = 0;
			if (sstabValidation.TabIndex == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			}

			//update the join operator in the report definition table
			modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set joinOperator = 'OR' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + msgid;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			if (sstabValidation.TabIndex == 0) {
				//rdcImportValError.Resultset.Requery
				RefreshECriteriaList();
			} else {
				//rdcImportValWarning.Resultset.Requery
				RefreshWCriteriaList();
			}

			RefreshCriteriaButtons();


		}


		private void cmdRemoveCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object RemoveJoinOperator = null;
			object resp = null;
			if (lstCriteria.SelectedIndex < 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to remove this criteria?", MessageBoxButtons.YesNo, "Remove Validation Criteria");
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_setup_importvalidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ValidID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstCriteria, lstCriteria.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RemoveJoinOperator = false;
			//remove the join operator if only one criteria is left
			modGlobal.gv_sql = "Select * from tbl_setup_importvalidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RemoveJoinOperator = true;
			} else {
				modGlobal.gv_rs.MoveLast();
				if (modGlobal.gv_rs.RowCount == 1) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RemoveJoinOperator = true;
				}
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (RemoveJoinOperator == true) {
				modGlobal.gv_sql = "Update tbl_setup_importvalidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = null ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where msgID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			}

			RefreshECriteriaList();
			RefreshCriteriaButtons();


		}

		private void cmdRemoveError_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			if (rdcImportValError.Resultset.RowCount <= 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to remove this error message?", MessageBoxButtons.YesNo, "Remove Error Validation");
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_setup_importvalidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_setup_importvalidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshErrorMessages();
			RefreshECriteriaList();
			RefreshCriteriaButtons();
		}

		private void cmdRemoveField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object CurrentFieldOrder = null;
			object resp = null;
			if (lstSelectedFields.SelectedIndex > -1) {

				modGlobal.gv_sql = " select tbl_setup_ImportFields.DDID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportFields  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' ";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
				modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderNumber ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				resp = RadMessageBox.Show("Are you sure you want to remove this field from the list.", MessageBoxButtons.YesNo, "Remove Field");
				if (resp == DialogResult.No) {
					return;
				}

				//keep the order of this field for reorganizing purposes'
				modGlobal.gv_sql = "Select OrderNumber from  tbl_Setup_ImportFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and importsetupid = " + modGlobal.gv_importsetupid;

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CurrentFieldOrder = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;

				//now delete the field
				modGlobal.gv_sql = "Delete tbl_Setup_importFields ";
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where OrderNumber = " + CurrentFieldOrder;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and importsetupid = " + modGlobal.gv_importsetupid;

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);



				//reorganize the field order
				modGlobal.gv_sql = "UPDATE tbl_Setup_importFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " SET OrderNumber = OrderNumber - 1";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE importsetupid = " + modGlobal.gv_importsetupid;
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " AND OrderNumber > " + CurrentFieldOrder;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


				//        'reorganize the field order
				//        gv_sql = "Select * from  tbl_Setup_ImportFields "
				//        gv_sql = gv_sql & " where OrderNumber > " & CurrentFieldOrder
				//        gv_sql = gv_sql & " and importsetupid = " & gv_importsetupid
				//
				//        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
				//
				//        While Not gv_rs.EOF
				//            gv_sql = "update tbl_Setup_importFields "
				//            gv_sql = gv_sql & " set OrderNumber = " & CurrentFieldOrder
				//            gv_sql = gv_sql & " where DDID = " & gv_rs!DDID
				//            gv_sql = gv_sql & " and importsetupid = " & gv_importsetupid
				//
				//            gv_cn.Execute gv_sql
				//
				//            CurrentFieldOrder = CurrentFieldOrder + 1
				//            gv_rs.MoveNext
				//        Wend


				RefreshSelectedFields();
				RefreshAvailableFields();
			}
		}


		private void cmdRemoveWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			if (rdcImportValWarning.Resultset.RowCount <= 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to remove this warning message?", MessageBoxButtons.YesNo, "Remove Warning Validation");
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Delete tbl_setup_Importvalidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "Delete tbl_setup_importvalidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshWarningMessages();
			RefreshWCriteriaList();
			RefreshCriteriaButtons();

		}

		private void cmdRemoveWCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			bool RemoveJoinOperator;
			object resp = null;
			if (lstWCriteria.SelectedIndex < 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to remove this criteria?", MessageBoxButtons.YesNo, "Remove Validation Criteria");
			if (resp == DialogResult.No) {
				return;
			}


			modGlobal.gv_sql = "Delete tbl_setup_importvalidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ValidID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstWCriteria, lstWCriteria.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RemoveJoinOperator = false;
			//remove the join operator if only one criteria is left
			modGlobal.gv_sql = "Select * from tbl_setup_importvalidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				RemoveJoinOperator = true;
			} else {
				modGlobal.gv_rs.MoveLast();
				if (modGlobal.gv_rs.RowCount == 1) {
					//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RemoveJoinOperator = true;
				}
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object RemoveJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (RemoveJoinOperator == true) {
				modGlobal.gv_sql = "Update tbl_setup_importvalidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = null ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where msgID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			}


			RefreshWCriteriaList();
			RefreshCriteriaButtons();


		}

		private void cmdSubmit_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object NewValidID = null;
			object thislookupvalue = null;
			object FieldName = null;
			object FieldType = null;
			object msgid = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msgid = 0;
			if (sstabValidation.TabIndex == 0)
            {
				if (rdcImportValError.Resultset.AbsolutePosition < 0)
                {
					RadMessageBox.Show("Please select an error validation.");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			}
            else
            {
				if (rdcImportValWarning.Resultset.AbsolutePosition < 0)
                {
					RadMessageBox.Show("Please select a warning validation.");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msgid = rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			}


			if (lstImportFields.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a field for criteria.");
				return;
			}


			modGlobal.gv_sql = "Select FieldType, FieldName from tbl_setup_datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FieldName = modGlobal.gv_rs.rdoColumns["FieldName"].Value;

			if (optCritValue[1].Checked == true) {
				if (string.IsNullOrEmpty(txtCriteria.Text) & cboLookupValues.SelectedIndex < 0) {
					RadMessageBox.Show("Please enter (or select) a value.");
					return;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.UCase(FieldType) == "DATE") {
					if (!Information.IsDate(txtCriteria.Text)) {
						RadMessageBox.Show("Please enter a valid date value.");
						return;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				} else if (Strings.UCase(FieldType) == "NUMBER") {
					if (!Information.IsNumeric(txtCriteria.Text)) {
						RadMessageBox.Show("Please enter a valid numeric value.");
						return;
					}
				}

				if (cboLookupValues.Visible == true) {
					modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where LookupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					//UPGRADE_WARNING: Couldn't resolve default property of object thislookupvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					thislookupvalue = modGlobal.gv_rs.rdoColumns["Id"].Value;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object NewValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NewValidID = modDBSetup.FindMaxRecID(ref "tbl_setup_ImportValidation", ref "ValidID");
				modGlobal.gv_sql = "Insert into tbl_setup_ImportValidation(";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValidID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " MSGID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldType, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValidationTitle) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Values( ";
				//UPGRADE_WARNING: Couldn't resolve default property of object NewValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + NewValidID + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex) + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + msgid + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboOperation.Text + "','";
				if (txtCriteria.Visible == true) {
					modGlobal.gv_sql = modGlobal.gv_sql + txtCriteria.Text + "','";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object thislookupvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + thislookupvalue + "','";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + FieldType + "',";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + FieldName + " " + cboOperation.Text + " ";
				if (txtCriteria.Visible == true) {
					modGlobal.gv_sql = modGlobal.gv_sql + txtCriteria.Text;
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + cboLookupValues.Text;
				}
				modGlobal.gv_sql = modGlobal.gv_sql + "')";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				if (sstabValidation.TabIndex == 0) {
					RefreshECriteriaList();
				} else {
					RefreshWCriteriaList();
				}



			} else if (OptCritBlank[2].Checked == true) {
				if (cboOperation.Text != "=" & cboOperation.Text != "<>") {
					RadMessageBox.Show("Only '=' and '<>' are valid selections for Blank option.");
					return;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object NewValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NewValidID = modDBSetup.FindMaxRecID(ref "tbl_setup_ImportValidation", ref "ValidID");
				modGlobal.gv_sql = "Insert into tbl_setup_ImportValidation(";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValidID, DDID, MSGID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Operator, FieldValue, FieldType, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValidationTitle) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Values( ";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object NewValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + NewValidID + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex) + "," + msgid + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboOperation.Text + "',  'NULL' ,'" + FieldType + "',";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + FieldName + " " + cboOperation.Text + " Blank ')";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				if (sstabValidation.SelectedIndex == 0) {
					RefreshECriteriaList();
				} else {
					RefreshWCriteriaList();
				}


				//ElseIf OptCritType(3).Value = True Then
				//    If cboFieldType.ListIndex < 0 Then
				//        MsgBox "Please select a field type from the drop-down box."
				//        Exit Sub
				//    End If
				//    If cboOperation.Text <> "=" And cboOperation.Text <> "<>" Then
				//        MsgBox "Only '=' and '<>' are valid selections for Field Type option."
				//        Exit Sub
				//    End If
				//
				//    NewValidID = FindMaxRecID("tbl_setup_ImportValidation", "ValidID")
				//    gv_sql = "Insert into tbl_setup_ImportValidation("
				//    gv_sql = gv_sql & " ValidID, DDID, MSGID, "
				//    gv_sql = gv_sql & " Operator, FieldType,  "
				//    gv_sql = gv_sql & " FieldTypeVal, ValidationTitle) "
				//    gv_sql = gv_sql & " Values( "
				//    gv_sql = gv_sql & NewValidID & "," & lstImportFields.ItemData(lstImportFields.ListIndex) & "," & MsgId & ","
				//    gv_sql = gv_sql & "'" & cboOperation & "', '" & FieldType & "',"
				//    gv_sql = gv_sql & "'" & cboFieldType & "', "
				//    gv_sql = gv_sql & "'" & FieldName
				//    If cboOperation = "=" Then
				//        gv_sql = gv_sql & " is a "
				//    Else
				//        gv_sql = gv_sql & " is not a "
				//
				//    End If
				//    gv_sql = gv_sql & cboFieldType & " value')"
				//    gv_cn.Execute gv_sql
				//    If sstabValidation.Tab = 0 Then
				//        RefreshECriteriaList
				//    Else
				//        RefreshWCriteriaList
				//    End If


			} else if (OptCritLKUp[4].Checked == true) {
				if (cboLookupList.SelectedIndex < 0) {
					RadMessageBox.Show("Please select a lookup table from the drop-down box.");
					return;
				}
				if (cboOperation.Text != "=" & cboOperation.Text != "<>") {
					RadMessageBox.Show("Only '=' and '<>' are valid selections for Lookup Table option.");
					return;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object NewValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NewValidID = modDBSetup.FindMaxRecID(ref "tbl_setup_ImportValidation", ref "ValidID");
				modGlobal.gv_sql = "Insert into tbl_setup_ImportValidation(";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValidID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " MSGID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldType,  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValidationTitle) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Values( ";
				//UPGRADE_WARNING: Couldn't resolve default property of object NewValidID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + NewValidID + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex) + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + msgid + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboOperation.Text + "', '";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + FieldType + "',";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupList, cboLookupList.SelectedIndex) + ", ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + FieldName;
				if (cboOperation.Text == "=") {
					modGlobal.gv_sql = modGlobal.gv_sql + " is in ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + " is not in ";

				}
				modGlobal.gv_sql = modGlobal.gv_sql + cboLookupList.Text + "')";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				if (sstabValidation.TabIndex == 0) {
					RefreshECriteriaList();
				} else {
					RefreshWCriteriaList();
				}
			}

			RefreshCriteriaButtons();


		}

		private void frmImportSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.gv_sql = "select * from  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_ImportSetup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid = " + modGlobal.gv_importsetupid;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			lblThisSetup.Text = "Import Layout: " + modGlobal.gv_rs.rdoColumns["Description"].Value;

			RefreshSelectedFields();
			RefreshAvailableFields();
			RefreshErrorMessages();
			RefreshWarningMessages();
			RefreshCriteriaButtons();
			RefreshLookupTables();
			sstabValidation.TabIndex = 0;
			sstabImport.TabIndex = 0;

		}

		public int GetNextFieldOrderID()
		{
			int MaxOrderId;

			modGlobal.gv_sql = "select max(OrderNumber) as MaxOrderID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_ImportFields ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid = " + modGlobal.gv_importsetupid;

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MaxOrderId"].Value)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MaxOrderId = 0;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MaxOrderId = modGlobal.gv_rs.rdoColumns["MaxOrderId"].Value;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			return MaxOrderId + 1;

		}

		public void RefreshECriteriaList()
		{
			object this_ListIndex = null;
			var LIndex = 0;
			object JoinOperator = null;

			lstCriteria.Items.Clear();

			//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			JoinOperator = "";

			if (rdcImportValError.Resultset.RowCount <= 0) {
				return;
			}


			//find the join operator in the table for the message
			modGlobal.gv_sql = "Select JoinOperator from tbl_Setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
			}

			modGlobal.gv_sql = "select * from tbl_Setup_importValidation  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				this_ListIndex = LIndex;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (modGlobal.gv_rs.RowCount == LIndex) {
					lstCriteria.Items.Add(modGlobal.gv_rs.rdoColumns["ValidationTitle"].Value);
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstCriteria.Items.Add(modGlobal.gv_rs.rdoColumns["ValidationTitle"].Value + " " + JoinOperator);
				}
				//UPGRADE_ISSUE: ListBox property lstCriteria.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstCriteria, lstCriteria.NewIndex, modGlobal.gv_rs.rdoColumns["ValidID"].Value);
				modGlobal.gv_rs.MoveNext();
			}


		}

		public void InitCriteria()
		{
			object txtOperator = null;
			//RefreshTableFieldsForCriteria
			//UPGRADE_WARNING: Couldn't resolve default property of object txtOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtOperator = "";
			txtCriteria.Text = "";
		}

		private void lstFieldListForCriteria_Click()
		{
			object txtOperator = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object txtOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtOperator = "";
			txtCriteria.Text = "";
		}

		public void RefreshErrorMessages()
		{
			object dbgImportValError = null;

			modGlobal.gv_sql = "select tbl_setup_DataDef.FieldName, tbl_setup_ImportValidationMessage.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportValidationMessage.DDID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.ValidationType = 'ERROR' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.importfieldid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid from tbl_setup_importfields ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid  = " + modGlobal.gv_importsetupid;
			modGlobal.gv_sql = modGlobal.gv_sql + ") ORDER BY tbl_setup_DataDef.FieldName";


			rdcImportValError.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcImportValError.CtlRefresh();
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgImportValError.Refresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgImportValError.Refresh();

			RefreshECriteriaList();

		}

		public void RefreshLookupTables()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboLookupList.Items.Clear();
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
				cboLookupList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}

//UPGRADE_WARNING: Event lstImportFields.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstImportFields_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstImportFields.SelectedIndex < 0) {
				return;
			}
			RefreshLookupListForThisField();

		}
		public void RefreshLookupListForThisField()
		{
			var LIndex = 0;
			object Field_ListIndex = null;
			object LookupTableID = null;
			modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
				//Opt2Method.Value = True
				modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + LookupTableID;
				modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				cboLookupValues.Items.Clear();

				//UPGRADE_WARNING: Couldn't resolve default property of object Field_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Field_ListIndex = -1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = -1;
				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LIndex = LIndex + 1;
					//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object Field_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Field_ListIndex = LIndex;

					cboLookupValues.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));

					modGlobal.gv_rs.MoveNext();
				}
				cboLookupValues.Visible = true;
				cboLookupValues.Top = txtCriteria.Top;
				cboLookupValues.Enabled = true;
				txtCriteria.Text = "";
				txtCriteria.Visible = false;
				txtCriteria.Enabled = false;
			} else {
				cboLookupValues.Items.Clear();
				cboLookupValues.Visible = false;
				cboLookupValues.Top = txtCriteria.Top;
				txtCriteria.Visible = true;
				txtCriteria.Enabled = true;
			}

		}

		private void rdcImportValError_Reposition()
		{

			if (rdcImportValError.Resultset.RowCount > 0) {
				//set join operator to null if there are fewer than 2 criteria for this message
				modGlobal.gv_sql = "Select count(*) as totalcrit from tbl_Setup_ImportValidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				if (modGlobal.gv_rs.rdoColumns["totalcrit"].Value < 2) {
					modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
					modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = null ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				}
			}
			RefreshECriteriaList();
			RefreshCriteriaButtons();
		}

		private void rdcImportValWarning_Reposition()
		{

			if (rdcImportValWarning.Resultset.RowCount > 0) {
				//set join operator to null if there are fewer than 2 criteria for this message
				modGlobal.gv_sql = "Select count(*) as totalcrit from tbl_Setup_ImportValidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				if (modGlobal.gv_rs.rdoColumns["totalcrit"].Value < 2) {
					modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
					modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = null ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				}
			}

			RefreshWCriteriaList();
			RefreshCriteriaButtons();
		}
		readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_sstabValidation_SelectedIndexChanged_PreviousTab_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();

		int static_sstabValidation_SelectedIndexChanged_PreviousTab;
		private void sstabValidation_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			lock (static_sstabValidation_SelectedIndexChanged_PreviousTab_Init) {
				try {
					if (InitStaticVariableHelper(static_sstabValidation_SelectedIndexChanged_PreviousTab_Init)) {
						static_sstabValidation_SelectedIndexChanged_PreviousTab = sstabValidation.TabIndex();
					}
				} finally {
					static_sstabValidation_SelectedIndexChanged_PreviousTab_Init.State = 1;
				}
			}
			object cboFieldType = null;

			optCritValue[1].Checked = false;
			OptCritBlank[2].Checked = false;
			//OptCritType(3).Value = False
			OptCritLKUp[4].Checked = false;
			txtCriteria.Text = "";
			//UPGRADE_WARNING: Couldn't resolve default property of object cboFieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboFieldType = "";
			cboLookupList.Text = "";
			RefreshCriteriaButtons();

			static_sstabValidation_SelectedIndexChanged_PreviousTab = sstabValidation.TabIndex();
		}

//UPGRADE_WARNING: Event txtCriteria.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtCriteria_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			optCritValue[1].Checked = true;

		}

		public void RefreshWarningMessages()
		{
			object dbgImportValWarning = null;

			modGlobal.gv_sql = "select tbl_setup_DataDef.FieldName, tbl_setup_ImportValidationMessage.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportValidationMessage.DDID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.ValidationType = 'WARNING' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.importfieldid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid from tbl_setup_importfields ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid  = " + modGlobal.gv_importsetupid;
			modGlobal.gv_sql = modGlobal.gv_sql + ") ORDER BY tbl_setup_DataDef.FieldName";
			rdcImportValWarning.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcImportValWarning.CtlRefresh();
			//UPGRADE_WARNING: Couldn't resolve default property of object dbgImportValWarning.Refresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dbgImportValWarning.Refresh();

			RefreshWCriteriaList();

		}

		public void RefreshCriteriaButtons()
		{
			object msgid = null;
			object JoinOperator = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			JoinOperator = "";
			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msgid = 0;
			if (sstabValidation.TabIndex == 0) {
				if (rdcImportValError.Resultset.RowCount > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msgid = rdcImportValError.Resultset.rdoColumns["msgid"].Value;
				}
			} else {
				if (rdcImportValWarning.Resultset.RowCount > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					msgid = rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
				}
			}

			modGlobal.gv_sql = "Select joinoperator from tbl_setup_ImportValidationMessage ";
			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgID  = " + msgid;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount > 0) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (msgid == 0) {
				cmdAnd.Enabled = false;
				cmdOr.Enabled = false;
				cmdSubmit.Enabled = false;

			} else {
				cmdAnd.Enabled = false;
				cmdOr.Enabled = false;
				cmdSubmit.Enabled = true;

				modGlobal.gv_sql = "Select * from tbl_setup_ImportValidation ";
				//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where msgID  = " + msgid;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.RowCount > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (string.IsNullOrEmpty(JoinOperator)) {
						cmdAnd.Enabled = true;
						cmdOr.Enabled = true;
						cmdSubmit.Enabled = false;
					}
				}
			}

		}

		public void RefreshWCriteriaList()
		{
			object this_ListIndex = null;
			var LIndex = 0;
			object JoinOperator = null;

			lstWCriteria.Items.Clear();

			//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			JoinOperator = "";

			if (rdcImportValWarning.Resultset.RowCount <= 0) {
				return;
			}


			//find the join operator in the table for the message
			modGlobal.gv_sql = "Select JoinOperator from tbl_Setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				JoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
			}


			modGlobal.gv_sql = "select * from tbl_Setup_importValidation  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = 0;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				this_ListIndex = LIndex;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (modGlobal.gv_rs.RowCount == LIndex) {
					lstWCriteria.Items.Add(modGlobal.gv_rs.rdoColumns["ValidationTitle"].Value);
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstWCriteria.Items.Add(modGlobal.gv_rs.rdoColumns["ValidationTitle"].Value + " " + JoinOperator);
				}
				//UPGRADE_ISSUE: ListBox property lstWCriteria.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstWCriteria, lstWCriteria.NewIndex, modGlobal.gv_rs.rdoColumns["ValidID"].Value);
				modGlobal.gv_rs.MoveNext();
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
