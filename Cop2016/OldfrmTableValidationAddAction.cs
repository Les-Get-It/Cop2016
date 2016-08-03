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
	internal partial class OldfrmTableValidationAddAction : System.Windows.Forms.Form
	{
		private void Option2_Click()
		{

		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object NewCritID = null;
			object DestFieldType = null;
			if (lstFieldList.SelectedIndex < 0) {
				Interaction.MsgBox("Select a field from the list.");
				return;
			}

			if (optBlank.Checked == false & optZero.Checked == false) {
				Interaction.MsgBox("Select either Blank or Zero from the options.");
				return;
			}

			modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object DestFieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DestFieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object DestFieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(Strings.Mid(DestFieldType, 1, 3)) != "NUM" & optZero.Checked == true) {
				Interaction.MsgBox("This field cannot be set to zero, because it is not a numeric field.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableValidationAction", ref "TableValidationActionID");

			modGlobal.gv_sql = "Insert into tbl_Setup_TableValidationAction ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (TableValidationActionID, TableValidationMessageID, ddid, setvalue) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Values (";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ERROR") {
				modGlobal.gv_sql = modGlobal.gv_sql + My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value + ", ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value + ", ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex) + ", ";
			if (optZero.Checked == true) {
				modGlobal.gv_sql = modGlobal.gv_sql + " '0'";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Null'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Update";

			this.Close();




		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void frmTableValidationAddAction_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			RefreshFieldList();
		}

		public void RefreshFieldList()
		{
			var LIndex = 0;

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmTableValidationSetup.cboTableList, My.MyProject.Forms.frmTableValidationSetup.cboTableList.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or State is null or state = '" + modGlobal.gv_status + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			lstFieldList.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				lstFieldList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();


		}
	}
}
