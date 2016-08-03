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
	internal partial class OldfrmImportSelectLayout : System.Windows.Forms.Form
	{

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newid = null;
			if (string.IsNullOrEmpty(txtNewImportLayout.Text)) {
				RadMessageBox.Show("Please enter a description for the new layout.");
				return;
			}
			modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where upper(description) = '" + Strings.UCase(txtNewImportLayout.Text) + "'";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				RadMessageBox.Show("There is a layout with the same description.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			newid = modDBSetup.FindMaxRecID(ref "tbl_setup_Importsetup", ref "importsetupid");

			modGlobal.gv_sql = "Insert into tbl_setup_ImportSetup  (importsetupid, description, state, recordstatus)";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + newid + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtNewImportLayout.Text + "',";
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

			RefreshImportLayout();

			txtNewImportLayout.Text = "";
			cmdSelect.Enabled = true;
			cmdDelete.Enabled = true;
			cmdUpdate.Enabled = true;


		}

		private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			DialogResult resp ;
			object MoveToModule = null;
			if (rdcImportLayout.Resultset.RowCount == 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
			//UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want this import layout to the " + MoveToModule + " Module?", MsgBoxStyle.YesNo);
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "Update tbl_Setup_ImportSetup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
			modGlobal.gv_sql = modGlobal.gv_sql + " where ImportSetupID = " + rdcImportLayout.Resultset.rdoColumns["ImportSetupID"].Value;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshImportLayout();

		}

		private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			DialogResult resp ;
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to delete this layout? All the associated fields will be deleted too.", MsgBoxStyle.YesNo, "Delete ImportLayout");
			if (resp == DialogResult.No) {
				return;
			}



			modGlobal.gv_sql = " delete tbl_setup_ImportValidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where msgid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select msgid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_importvalidationmessage  as msg ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  inner join tbl_setup_importfields as impf ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  on msg.importfieldid = impf.importfieldid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where impf.importsetupid = " + rdcImportLayout.Resultset.rdoColumns["ImportSetupID"].Value;
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


			modGlobal.gv_sql = " delete tbl_setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where importfieldid in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_importfields as impf ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where impf.importsetupid = " + rdcImportLayout.Resultset.rdoColumns["ImportSetupID"].Value;
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


			modGlobal.gv_sql = " delete tbl_setup_ImportFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid = " + rdcImportLayout.Resultset.rdoColumns["ImportSetupID"].Value;

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = " delete tbl_setup_ImportSetup ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid = " + rdcImportLayout.Resultset.rdoColumns["ImportSetupID"].Value;

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshImportLayout();

		}

		private void cmdSelect_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (rdcImportLayout.Resultset.RowCount == 0) {
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_importsetupid = rdcImportLayout.Resultset.rdoColumns["ImportSetupID"].Value;
			OldfrmImportSetup.Show();
			this.Close();

		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object thislayoutdesc = null;
			if (rdcImportLayout.Resultset.RowCount == 0) {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object thislayoutdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			thislayoutdesc = Interaction.InputBox("Layout Description:", "Update Description", rdcImportLayout.Resultset.rdoColumns["Description"].Value);
			//UPGRADE_WARNING: Couldn't resolve default property of object thislayoutdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(thislayoutdesc)) {
				modGlobal.gv_sql = "update tbl_setup_ImportSetup ";
				//UPGRADE_WARNING: Couldn't resolve default property of object thislayoutdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set description = '" + thislayoutdesc + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where importsetupid = " + rdcImportLayout.Resultset.rdoColumns["ImportSetupID"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshImportLayout();
			}

		}

		private void frmImportSelectLayout_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_status == "TEST") {
				cmdChangeStatus.Text = "Move to Active";
			} else {
				cmdChangeStatus.Text = "Move to Test";
			}

			RefreshImportLayout();
		}

		public void RefreshImportLayout()
		{
			modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by methodnumber ";

			rdcImportLayout.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcImportLayout.CtlRefresh();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgImportLayout.CtlRefresh();

			if (rdcImportLayout.Resultset.RowCount == 0) {
				cmdSelect.Enabled = false;
				cmdDelete.Enabled = false;
				cmdUpdate.Enabled = false;
			}
		}
	}
}
