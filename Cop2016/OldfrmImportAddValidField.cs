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
	internal partial class OldfrmImportAddValidField : System.Windows.Forms.Form
	{
		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newmsgid = null;
			object thisimportfieldid = null;
			if (cboImportFields.SelectedIndex < 0 | string.IsNullOrEmpty(txtMessage.Text)) {
				RadMessageBox.Show("Field and Message are both required to complete this action.");
				return;
			}

			modGlobal.gv_sql = "select importfieldid ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_ImportFields  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and importsetupid = " + modGlobal.gv_importsetupid;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object thisimportfieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			thisimportfieldid = modGlobal.gv_rs.rdoColumns["ImportFieldID"].Value;

			if (frmImportSetup.txtAction.Text == "Add Error") {

				//UPGRADE_WARNING: Couldn't resolve default property of object newmsgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newmsgid = modDBSetup.FindMaxRecID(ref "tbl_setup_ImportValidationMessage", ref "MSGID");

				modGlobal.gv_sql = "Insert into tbl_setup_ImportValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " (importfieldid, MSGID, DDID, ValidationType, Message)";
				//UPGRADE_WARNING: Couldn't resolve default property of object newmsgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object thisimportfieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + thisimportfieldid + "," + newmsgid + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex) + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + " 'ERROR', '" + modGlobal.ConvertApastroph( txtMessage) + "')";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				this.Close();

			} else if (frmImportSetup.txtAction.Text == "Edit Error") {
				modGlobal.gv_sql = "update tbl_setup_ImportValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + ", Message = '" + modGlobal.ConvertApastroph( txtMessage) + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + frmImportSetup.rdcImportValError.Resultset.rdoColumns["msgid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				this.Close();

			} else if (frmImportSetup.txtAction.Text == "Add Warning") {
				//UPGRADE_WARNING: Couldn't resolve default property of object newmsgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newmsgid = modDBSetup.FindMaxRecID(ref "tbl_setup_ImportValidationMessage", ref "MSGID");

				modGlobal.gv_sql = "Insert into tbl_setup_ImportValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " (importfieldid, MSGID, DDID, ValidationType, Message)";
				//UPGRADE_WARNING: Couldn't resolve default property of object newmsgid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object thisimportfieldid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + thisimportfieldid + "," + newmsgid + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex) + ",";
				modGlobal.gv_sql = modGlobal.gv_sql + " 'WARNING', '" + modGlobal.ConvertApastroph( txtMessage) + "')";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				this.Close();

			} else if (frmImportSetup.txtAction.Text == "Edit Warning") {
				modGlobal.gv_sql = "update tbl_setup_ImportValidationMessage ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + ", Message = '" + modGlobal.ConvertApastroph( txtMessage) + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + frmImportSetup.rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				this.Close();

			}

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void frmImportAddValidField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			int thisindex ;
			//UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			System.Windows.Forms.Label dtText = null;
			cboImportFields.Items.Clear();

			modGlobal.gv_sql = "select tbl_setup_DataDef.* , tbl_setup_ImportFields.OrderNumber  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportFields  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_importsetupid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.importsetupid = " + modGlobal.gv_importsetupid;
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_ImportFields.OrderNumber ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			thisindex = 0;
			while (!modGlobal.gv_rs.EOF) {
				cboImportFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				if (frmImportSetup.txtAction.Text == "Edit Error") {
					if (modGlobal.gv_rs.rdoColumns["DDID"].Value == frmImportSetup.rdcImportValError.Resultset.rdoColumns["DDID"].Value) {
						//UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						cboImportFields.SelectedIndex = thisindex;
					}
				} else if (frmImportSetup.txtAction.Text == "Edit Warning") {
					if (modGlobal.gv_rs.rdoColumns["DDID"].Value == frmImportSetup.rdcImportValWarning.Resultset.rdoColumns["DDID"].Value) {
						//UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						cboImportFields.SelectedIndex = thisindex;
					}
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thisindex = thisindex + 1;
				modGlobal.gv_rs.MoveNext();
			}


			if (frmImportSetup.txtAction.Text == "Add Error") {
			} else if (frmImportSetup.txtAction.Text == "Edit Error") {
				txtMessage.Text = frmImportSetup.rdcImportValError.Resultset.rdoColumns["Message"].Value;
				//gv_sql = "Select Message from tbl_setup_ImportValidationMessage  "
				//gv_sql = gv_sql & " where msgID = " & frmImportSetup.rdcImportValError.Resultset!msgid
				//Set dtText.Recordset = gv_cn.OpenResultset(gv_sql, dbOpenSnapshot)
				//txtMessage = dtText.Recordset!Message
			} else if (frmImportSetup.txtAction.Text == "Add Warning") {
			} else if (frmImportSetup.txtAction.Text == "Edit Warning") {
				txtMessage.Text = frmImportSetup.rdcImportValWarning.Resultset.rdoColumns["Message"].Value;
			}

		}
	}
}
