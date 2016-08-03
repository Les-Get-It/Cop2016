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
	internal partial class OlddlgValidationField : System.Windows.Forms.Form
	{

		object ii_TableValidationID;
		string is_PreviousDataType;
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

		private void dlgValidationField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object ii_TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "select SourceDDID1, FieldName, FieldType, CriteriaTitle from tbl_setup_TableValidation, tbl_setup_DataDef " + " Where tbl_setup_DataDef.DDID = tbl_setup_TableValidation.SourceDDID1 AND TableValidationID = " + ii_TableValidationID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["SourceDDID1"].Value)) {
					txtPreviousField.Text = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
					is_PreviousDataType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
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
					is_CriteriaTitle = Strings.Replace(is_CriteriaTitle, txtPreviousField.Text, Strings.Trim(cboField.Text));

					//UPGRADE_WARNING: Couldn't resolve default property of object ii_TableValidationID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "UPDATE tbl_setup_TableValidation SET SourceDDID1 = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField, cboField.SelectedIndex) + ", CriteriaTitle = '" + is_CriteriaTitle + "'  WHERE TableValidationID = " + ii_TableValidationID;
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
			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef WHERE FieldType = '" + is_PreviousDataType + "' AND (ParentDDID IS NULL OR ParentDDID = DDID) ORDER BY FIELDNAME";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboField.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cboField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}
	}
}
