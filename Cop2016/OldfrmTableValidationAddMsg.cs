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
	internal partial class OldfrmTableValidationAddMsg : System.Windows.Forms.Form
	{

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			object newmsgid = null;
			object NewValID = null;
			if (string.IsNullOrEmpty(txtMessage.Text)) {
				Interaction.MsgBox("Please define a validation message.");
				return;
			}

			if (opt1Save.Checked == false & opt2Delete.Checked == false & lstFieldstoValidate.Items.Count == 0) {
				Interaction.MsgBox("Please define when this validation should occur.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewValID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewValID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableValidationMessage", ref "TableValidationMessageID");

			modGlobal.gv_sql = "Insert into tbl_Setup_TableValidationMessage(TableValidationMessageID, BaseTableid, Message, MessageType, UserAction, State, RecordStatus)";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewValID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values ( " + NewValID + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmTableValidationSetup.cboTableList, My.MyProject.Forms.frmTableValidationSetup.cboTableList.SelectedIndex) + ",";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.ConvertApastroph(ref txtMessage) + "',";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_Action + "',";
			if (opt1Save.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Saving Record', ";
			} else if (opt2Delete.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Deleting Record', ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(modGlobal.gv_State)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_State + "', ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " null ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			if (lstFieldstoValidate.Items.Count > 0) {
				modGlobal.gv_sql = "Select max(tablevalidationmessageid) as newid ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_tablevalidationmessage ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object newmsgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newmsgid = modGlobal.gv_rs.rdoColumns["newid"].Value;
				for (i = 1; i <= lstFieldstoValidate.Items.Count; i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object NewValID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewValID = modDBSetup.FindMaxRecID(ref "tbl_setup_tablevalidationAfterFieldUpdate", ref "tablevalidationAfterFieldUpdateID");

					modGlobal.gv_sql = "insert into tbl_setup_tablevalidationAfterFieldUpdate ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (tablevalidationAfterFieldUpdateID, tablevalidationmessageid, ddid)";
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object newmsgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object NewValID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NewValID + ", " + newmsgid + ", " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldstoValidate, i - 1) + ")";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";
			this.Close();
		}

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

		private void frmTableValidationAddMsg_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			RefreshFieldList();

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
