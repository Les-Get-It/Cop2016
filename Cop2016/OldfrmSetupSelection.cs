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
	internal partial class OldfrmSetupSelection : System.Windows.Forms.Form
	{

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_NOTE: Object gv_cn may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_cn = null;
			//UPGRADE_NOTE: Object gv_en may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_en = null;

			this.Close();
			System.Environment.Exit(0);
		}

		private void cmdMoveAllToActive_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object statespec = null;
			object recstatus = null;
			object resp = null;
			object thismodule = null;
			if (optExistingState.Checked == false & optNewState.Checked == false & optJC.Checked == false) {
				Interaction.MsgBox("Please select a setup to update.");
				return;
			}


			if (optExistingState.Checked == true) {
				if (string.IsNullOrEmpty(cboExistingState.Text)) {
					Interaction.MsgBox("Select a state from the list.");
					return;
				}
			}
			if (optNewState.Checked == true) {
				Interaction.MsgBox("You are about to add a module for a new state. No Test setup has been defined yet to move to active.");
				return;
			}

			if (optExistingState.Checked == true) {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_State = cboExistingState.Text;
			}

			if (optJC.Checked == true) {
				//UPGRADE_WARNING: Couldn't resolve default property of object thismodule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thismodule = "Joint Commission";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object thismodule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thismodule = cboExistingState.Text;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object thismodule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = Interaction.MsgBox("Are you sure you want to move the entire Test module for " + thismodule + " setup to Active?", MsgBoxStyle.YesNo, "Move Test to Active");
			if (resp == MsgBoxResult.Yes) {

				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

				//these lines are added to every query
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				recstatus = " set RecordStatus = Null ";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (string.IsNullOrEmpty(modGlobal.gv_State)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					statespec = " where State is null or state = ''";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					statespec = " where State = '" + modGlobal.gv_State + "'";
				}

				//update tables with RecordStatus field
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_indicator " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_indicatorset " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_datadef " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_tabledef " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_indicatorgroup " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_tablevalidationmessage " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_submitgroup " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_submitvalidation " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_submitcleanupitems " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_submitcleanuprecord " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_savedadhocreports " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object statespec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object recstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "Update tbl_setup_importsetup " + recstatus + statespec;
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				Interaction.MsgBox("Conversion is complete.");
			}
		}

		private void cmdOK_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object gv_selecteddatabse = null;
			object FormTitle = null;
			object CurrentVersionNumber = null;
			if (optExistingState.Checked == false & optNewState.Checked == false & optJC.Checked == false & modGlobal.gv_selecteddatabase != "COPWebSetup") {
				Interaction.MsgBox("Please select a setup to update.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CurrentVersionNumber = "";
			modGlobal.gv_sql = "select max(versionnumber) as cver from tbl_setup_version ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount > 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CurrentVersionNumber = modGlobal.gv_rs.rdoColumns["cver"].Value;
			}


			if (optExistingState.Checked == true) {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_State = cboExistingState.Text;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FormTitle = modGlobal.gv_State + " Setup";
			}
			if (optNewState.Checked == true) {
				//NewID = FindMaxRecID("tbl_Setup_StateVersion", "StateVersionID")
				modGlobal.gv_sql = "Insert into tbl_Setup_StateVersion (StateVersion, State) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " values (0, '" + txtNewState.Text + "')";
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_State = txtNewState.Text;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FormTitle = modGlobal.gv_State + " Setup";
			}

			if (modGlobal.gv_selecteddatabase == "Archive") {
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FormTitle = "********** ARCHIVE - Version: " + CurrentVersionNumber + "**********  ";
				if (optJC.Checked == true) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_State = "";
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FormTitle = "********** ARCHIVE (JC Setup) - Version: " + CurrentVersionNumber + "**********  ";
				}

			} else if (modGlobal.gv_selecteddatabase == "Current") {
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FormTitle = "********** CURRENT - To process hospital data - Version: " + CurrentVersionNumber + " **********  ";
				if (optJC.Checked == true) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_State = "";
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FormTitle = "********** CURRENT (JC Setup) - To process hospital data - Version: " + CurrentVersionNumber + " **********  ";

				}

				//UPGRADE_WARNING: Couldn't resolve default property of object gv_selecteddatabse. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (gv_selecteddatabse == "IHHA") {
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FormTitle = "********** IHHA - To accept new changes - Version: " + CurrentVersionNumber + " **********  ";
				if (optJC.Checked == true) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_State = "";
					//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FormTitle = "********** IHHA (JC Setup) - To accept new changes - Version: " + CurrentVersionNumber + " **********  ";
				}

				// If gv_selecteddatabase = "IHHA" Then
				if (optTest.Checked == false & optActive.Checked == false) {
					Interaction.MsgBox("Please select a module to update.");
					return;
				}
				if (optTest.Checked == true) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_status = "TEST";
					//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FormTitle = FormTitle + " | Test Module";
				}

				if (optActive.Checked == true) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_status = "";
					//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FormTitle = FormTitle + " | Active Module";
				}
			} else if (modGlobal.gv_selecteddatabase == "COPWebSetup") {
				//UPGRADE_WARNING: Couldn't resolve default property of object CurrentVersionNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FormTitle = "********** COPWebSetup - To create web test - Version: " + CurrentVersionNumber + " **********  ";

				if (optActive.Checked == true) {
					//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_status = "";
					//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FormTitle = FormTitle + " | Active Module";
				}
			}

			if (optExistingState.Checked == true) {
				if (string.IsNullOrEmpty(cboExistingState.Text)) {
					Interaction.MsgBox("Select a state from the list.");
					return;
				}
			}
			if (optNewState.Checked == true) {
				if (string.IsNullOrEmpty(txtNewState.Text)) {
					Interaction.MsgBox("Type in a state name.");
					return;
				}
			}



			//UPGRADE_WARNING: Couldn't resolve default property of object FormTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			My.MyProject.Forms.frmMasterForm.Text = FormTitle;

			this.Close();
			My.MyProject.Forms.frmMainMenu.Show();

		}

		private void frmSetupSelection_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			object ListIndex = null;
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			//frmSelectDatabase.Show 1
			//
			// If gv_connectionstatus = "fail" Then
			//     Unload Me
			//     Exit Sub
			// End If

			if (modGlobal.gv_selecteddatabasename == "COP2001Current" | modGlobal.gv_selecteddatabasename == "COP2001Archive") {
				this.Text = "Select Setup";
				fraSelectedModule.Visible = false;
				cmdMoveAllToActive.Visible = false;
				//        If gv_selecteddatabasename = "COPWebSetup" Then
				//            Frame1.Visible = False
				//        End If
			} else {
				this.Text = "Select Setup/Module";
			}

			modGlobal.gv_sql = "Select State from tbl_Setup_StateVersion";
			modGlobal.gv_sql = modGlobal.gv_sql + " Group by State ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboExistingState.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ListIndex = 0;
			while (!modGlobal.gv_rs.EOF) {

				cboExistingState.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["state"].Value, ListIndex));
				//UPGRADE_WARNING: Couldn't resolve default property of object ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ListIndex = ListIndex + 1;
				modGlobal.gv_rs.MoveNext();
			}

		}
	}
}
