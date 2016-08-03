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
	internal partial class OlddlgValidationRightField : System.Windows.Forms.Form
	{

		object ii_TableValidationID;
		short ii_BaseTableID;
		string is_CriteriaTitle;

		public void SetTableValidationID(ref object TableValidationID)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object ii_TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ii_TableValidationID = TableValidationID;
		}

		private void CancelButton_Renamed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void dlgValidationRightField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object ii_TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "select BaseTableID, CriteriaTitle, tbl_setup_miscLookupList.FieldValue, tbl_setup_miscLookupList.ID from tbl_setup_TableValidation, tbl_setup_MiscLookupList " + " Where tbl_setup_misclookuplist.LookupID = tbl_setup_TableValidation.LookupID And TableValidationID = " + ii_TableValidationID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["basetableid"].Value)) {
					txtPreviousField.Text = "(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
					ii_BaseTableID = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
					is_CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
					RefreshFields();
					OKButton.Enabled = true;
				} else {
					Interaction.MsgBox("This criteria can not be modified");
					OKButton.Enabled = false;

				}
			} else {
				Interaction.MsgBox("This criteria can not be modified");
				OKButton.Enabled = false;
			}

		}

		private void OKButton_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboField.SelectedIndex > -1) {
				if (!string.IsNullOrEmpty(txtPreviousField.Text)) {
					is_CriteriaTitle = Strings.Replace(is_CriteriaTitle, Strings.Trim(txtPreviousField.Text), Strings.Trim(cboField.Text));

					//UPGRADE_WARNING: Couldn't resolve default property of object ii_TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "UPDATE tbl_setup_TableValidation SET LookupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField, cboField.SelectedIndex) + ", CriteriaTitle = '" + is_CriteriaTitle + "', Value = '" + Strings.Trim(Strings.Mid(cboField.Text, Strings.InStr(1, cboField.Text, "(") + 1, Strings.InStr(1, cboField.Text, ")") - Strings.InStr(1, cboField.Text, "(") - 1)) + "'  WHERE TableValidationID = " + ii_TableValidationID;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				} else {
					Interaction.MsgBox("This can not be saved");
				}

				this.Close();
			} else {
				Interaction.MsgBox("Please select a field to modify to");
			}
			return;
			ErrHandler:


			modGlobal.CheckForErrors();
		}

		private void RefreshFields()
		{
			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MiscLookupList WHERE BaseTableID = " + ii_BaseTableID + " ORDER BY FieldValue";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboField.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cboField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));

				modGlobal.gv_rs.MoveNext();
			}

		}
	}
}
