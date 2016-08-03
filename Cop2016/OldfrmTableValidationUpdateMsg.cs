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
	internal partial class OldfrmTableValidationUpdateMsg : System.Windows.Forms.Form
	{

		private void cmdAddField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var LIndex = 0;

			if (cboFieldList.SelectedIndex > -1) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = lstFieldstoValidate.Items.Count;
				lstFieldstoValidate.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(cboFieldList.Text, Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboFieldList, cboFieldList.SelectedIndex)));
			}

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdRemoveField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstFieldstoValidate.SelectedIndex > -1) {
				lstFieldstoValidate.Items.RemoveAt((lstFieldstoValidate.SelectedIndex));
			}

		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object NewValID = null;
			var i = 0;
			object msgid = null;

			if (string.IsNullOrEmpty(txtMessage.Text)) {
				Interaction.MsgBox("Please define a validation message.");
				return;
			}

			if (opt1Save.Checked == false & opt2Delete.Checked == false & lstFieldstoValidate.Items.Count == 0) {
				Interaction.MsgBox("Please define when this validation should occur.");
				return;
			}


			modGlobal.gv_sql = "Update tbl_setup_TableValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Message = '" + modGlobal.ConvertApastroph(ref txtMessage) + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + " UserAction = ";
			if (opt1Save.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Saving Record' ";
			} else if (opt2Delete.Checked) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Deleting Record' ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " null ";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(modGlobal.gv_Action) == "ERROR") {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageID = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageID  = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			}
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);


			modGlobal.gv_sql = "Delete tbl_setup_TableValidationAfterFieldUpdate ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(modGlobal.gv_Action) == "ERROR") {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageID = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where TableValidationMessageID  = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			}
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			if (opt3UpdateField.Checked) {
				if (lstFieldstoValidate.Items.Count > 0) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.UCase(modGlobal.gv_Action) == "ERROR") {
						//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						msgid = My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						msgid = My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
					}

					for (i = 1; i <= lstFieldstoValidate.Items.Count; i++) {
						//UPGRADE_WARNING: Couldn't resolve default property of object NewValID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						NewValID = modDBSetup.FindMaxRecID("tbl_setup_tablevalidationAfterFieldUpdate", "tablevalidationAfterFieldUpdateID");

						modGlobal.gv_sql = "insert into tbl_setup_tablevalidationAfterFieldUpdate ";
						modGlobal.gv_sql = modGlobal.gv_sql + " (tablevalidationAfterFieldUpdateID, tablevalidationmessageid, ddid)";
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object msgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object NewValID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NewValID + ", " + msgid + ", " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldstoValidate, i - 1) + ")";
						modGlobal.gv_cn.Execute(modGlobal.gv_sql);
					}
				}
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Update";
			this.Close();
		}
		public void RefreshFieldList()
		{
			var LIndex = 0;
			object Field_ListIndex = null;
			modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmTableValidationSetup.cboTableList, My.MyProject.Forms.frmTableValidationSetup.cboTableList.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";


			//retrieve the list of dynamic fields

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboFieldList.Items.Clear();

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

				cboFieldList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				modGlobal.gv_rs.MoveNext();
			}

		}

		public void RefreshSelectedFields()
		{
			var LIndex = 0;

			//Display the list of fields
			lstFieldstoValidate.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				lstFieldstoValidate.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();


		}
		private void frmTableValidationUpdateMsg_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

            this.CenterToParent();
			RefreshFieldList();
			cboFieldList.Enabled = false;
			lstFieldstoValidate.Enabled = false;


			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(modGlobal.gv_Action) == "ERROR") {
				txtMessage.Text = My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["Message"].Value;
				if (My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["UserAction"].Value == "Saving Record") {
					opt1Save.Checked = true;
				} else if (My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["UserAction"].Value == "Deleting Record") {
					opt2Delete.Checked = true;
				} else {
					opt3UpdateField.Checked = true;
					cboFieldList.Enabled = true;
					lstFieldstoValidate.Enabled = true;
					modGlobal.gv_sql = "Select tv.*, dd.fieldname from ";
					modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_TableValidationAfterFieldUpdate as tv ";
					modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd  ";
					modGlobal.gv_sql = modGlobal.gv_sql + " on tv.ddid = dd.ddid ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where tv.TableValidationMessageID = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					RefreshSelectedFields();

				}

			} else {
				txtMessage.Text = My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["Message"].Value;
				if (My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["UserAction"].Value == "Saving Record") {
					opt1Save.Checked = true;
				} else if (My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["UserAction"].Value == "Deleting Record") {
					opt2Delete.Checked = true;
				} else {
					opt3UpdateField.Checked = true;
					cboFieldList.Enabled = true;
					lstFieldstoValidate.Enabled = true;
					modGlobal.gv_sql = "Select tv.*, dd.fieldname from ";
					modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_TableValidationAfterFieldUpdate as tv ";
					modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd  ";
					modGlobal.gv_sql = modGlobal.gv_sql + " on tv.ddid = dd.ddid ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where tv.TableValidationMessageID = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					RefreshSelectedFields();
				}
			}


		}

//UPGRADE_WARNING: Event opt1Save.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void opt1Save_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {

				cboFieldList.Enabled = false;
				cboFieldList.Text = "";
				lstFieldstoValidate.Enabled = false;
				lstFieldstoValidate.Items.Clear();

			}
		}

//UPGRADE_WARNING: Event opt2Delete.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void opt2Delete_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				cboFieldList.Enabled = false;
				cboFieldList.Text = "";
				lstFieldstoValidate.Enabled = false;
				lstFieldstoValidate.Items.Clear();


			}
		}

//UPGRADE_WARNING: Event opt3UpdateField.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void opt3UpdateField_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				cboFieldList.Enabled = true;
				lstFieldstoValidate.Enabled = true;

			}
		}
	}
}
