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
	internal partial class OlddlgMeasureOccurGroupLogic : System.Windows.Forms.Form
	{



//UPGRADE_WARNING: Event cboOpt1ValueOperator.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboOpt1ValueOperator_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboOpt1ValueOperator.Text == "Is Between") {
				lblOpt1IsBetweenMax.Enabled = true;
				txtOpt1IsBetweenMax.Enabled = true;
				//    cboJoinOperator = "AND"
			} else {
				lblOpt1IsBetweenMax.Enabled = false;
				txtOpt1IsBetweenMax.Enabled = false;

			}
		}

//UPGRADE_WARNING: Event cboOpt3ValueOperator.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboOpt3ValueOperator_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cboOpt3ValueOperator.Text == "Is Between") {
				lblOpt4IsBetweenMax.Enabled = true;
				txtOpt4IsBetweenMax.Enabled = true;

				// cboJoinOperator = "AND"
			} else {
				lblOpt4IsBetweenMax.Enabled = false;
				txtOpt4IsBetweenMax.Enabled = false;
			}
		}

		private void cmdAdd6_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string ls_add = null;
			EditCat:

			ls_add = Interaction.InputBox("Enter a valid value.", "Add Values", "");

			if (Strings.Len(ls_add) == 0)
				return;

			lst6Range.Items.Add(ls_add);

		}

		private void cmdAddVal_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string ls_add = null;
			System.Data.DataSet  rsIsValid = null;
			EditCat:

			ls_add = Interaction.InputBox("Enter a valid month value.", "Add Values", "");

			if (Strings.Len(ls_add) == 0)
				return;

			 // ERROR: Not supported in C#: OnErrorStatement

			modGlobal.gv_sql = "SELECT MONTH('" + ls_add + "/1/2000')";
			rsIsValid = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (rsIsValid.EOF) {
				Interaction.MsgBox("Please Enter A Valid Month", MsgBoxStyle.Critical, "Invalid Month");
				goto EditCat;
			} else {
				lstRange.Items.Add(ls_add);
			}
			rsIsValid.Close();

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdDel6_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lst6Range.SelectedIndex < 0) {
				return;
			}

			lst6Range.Items.RemoveAt((lst6Range.SelectedIndex));

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstRange.SelectedIndex < 0) {
				return;
			}

			lstRange.Items.RemoveAt((lstRange.SelectedIndex));
		}

		private void cmdSave_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			if (sstabOptions.TabPages[0].Enabled == false & sstabOptions.TabPages[1].Enabled == false & sstabOptions.TabPages[2].Enabled == false & sstabOptions.TabPages[3].Enabled == false & sstabOptions.TabPages[4].Enabled == false & sstabOptions.TabPages[5].Enabled == false & sstabOptions.TabPages[6].Enabled == false) {
				Interaction.MsgBox("Please select a method.");
				return;
			}


			if (string.IsNullOrEmpty(Strings.Trim(cboJoinOperator.Text))) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to compare the Group Fields to each other.");
				return;
			}


			if (TabFirstField.SelectedIndex == 1) {
				if (lstGroupList.SelectedIndex < 0) {
					Interaction.MsgBox("Please select a group from the list");
					return;
				}
			} else if (TabFirstField.SelectedIndex == 0) {
				if (lstFieldList.SelectedIndex < 0) {
					Interaction.MsgBox("Please select field(s) from the list");
					return;
				}
			}

			if (sstabOptions.TabPages[0].Enabled == true) {
				AddCriteriaWithMethod1();
			} else if (sstabOptions.TabPages[1].Enabled == true) {
				AddCriteriaWithMethod2();
			} else if (sstabOptions.TabPages[2].Enabled == true) {
				AddCriteriaWithMethod3();
			} else if (sstabOptions.TabPages[3].Enabled == true) {
				AddCriteriaWithMethod4();
			} else if (sstabOptions.TabPages[4].Enabled == true) {
				AddCriteriaWithMethod5();
			} else if (sstabOptions.TabPages[5].Enabled == true) {
				AddCriteriaWithMethod6();
			} else if (sstabOptions.TabPages[6].Enabled == true) {
				AddCriteriaWithMethod7();
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}



		private void Command1_Click()
		{

		}

		private void dlgMeasureOccurGroupLogic_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshMultipleGroupList();

			sstabOptions.SelectedIndex = 0;
			sstabOptions.TabPages[0].Enabled = false;
			sstabOptions.TabPages[1].Enabled = false;
			sstabOptions.TabPages[2].Enabled = false;
			sstabOptions.TabPages[3].Enabled = false;
			sstabOptions.TabPages[4].Enabled = false;

			Opt1Method.Checked = false;
			Opt2Method.Checked = false;
			Opt3Method.Checked = false;
			Opt4Method.Checked = false;
			Opt5Method.Checked = false;

			RefreshFieldsList();
			RefreshLookupTables();

		}

		private void RefreshMultipleGroupList()
		{
			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_FieldGroup";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			lstGroupList.Items.Clear();
			cboField2GroupList.Items.Clear();
			cboDestGroupField.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				lstGroupList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FIELDGROUPNAME"].Value, modGlobal.gv_rs.rdoColumns["FIELDGroupID"].Value));

				cboField2GroupList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FIELDGROUPNAME"].Value, modGlobal.gv_rs.rdoColumns["FIELDGroupID"].Value));

				cboDestGroupField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FIELDGROUPNAME"].Value, modGlobal.gv_rs.rdoColumns["FIELDGroupID"].Value));

				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();

		}


//UPGRADE_WARNING: Event lstFieldList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstFieldList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshLookupListForThisField();

		}

//UPGRADE_WARNING: Event lstGroupList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstGroupList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshLookupListForThisField();
			RefreshCriteriaFieldList();

		}

//UPGRADE_WARNING: Event Opt1Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt1Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (Opt1Method.Checked == true) {
					sstabOptions.Enabled = true;
					sstabOptions.TabPages[0].Enabled = true;
					sstabOptions.TabPages[1].Enabled = false;
					sstabOptions.TabPages[2].Enabled = false;
					sstabOptions.TabPages[3].Enabled = false;
					sstabOptions.TabPages[4].Enabled = false;
					sstabOptions.TabPages[5].Enabled = false;
					sstabOptions.TabPages[6].Enabled = false;

					sstabOptions.SelectedIndex = 0;

				}
			}
		}

//UPGRADE_WARNING: Event Opt2Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt2Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (Opt2Method.Checked == true) {
					sstabOptions.Enabled = true;
					sstabOptions.TabPages[0].Enabled = false;
					sstabOptions.TabPages[1].Enabled = true;
					sstabOptions.TabPages[2].Enabled = false;
					sstabOptions.TabPages[3].Enabled = false;
					sstabOptions.TabPages[4].Enabled = false;
					sstabOptions.TabPages[5].Enabled = false;
					sstabOptions.TabPages[6].Enabled = false;

					sstabOptions.SelectedIndex = 1;


				}
			}
		}

//UPGRADE_WARNING: Event Opt3Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt3Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (Opt3Method.Checked == true) {
					sstabOptions.Enabled = true;
					sstabOptions.TabPages[0].Enabled = false;
					sstabOptions.TabPages[1].Enabled = false;
					sstabOptions.TabPages[2].Enabled = true;
					sstabOptions.TabPages[3].Enabled = false;
					sstabOptions.TabPages[4].Enabled = false;
					sstabOptions.TabPages[5].Enabled = false;
					sstabOptions.TabPages[6].Enabled = false;

					sstabOptions.SelectedIndex = 2;


				}
			}
		}

//UPGRADE_WARNING: Event Opt4Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt4Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (Opt4Method.Checked == true) {
					sstabOptions.Enabled = true;
					sstabOptions.TabPages[0].Enabled = false;
					sstabOptions.TabPages[1].Enabled = false;
					sstabOptions.TabPages[2].Enabled = false;
					sstabOptions.TabPages[3].Enabled = true;
					sstabOptions.TabPages[4].Enabled = false;
					sstabOptions.TabPages[5].Enabled = false;
					sstabOptions.TabPages[6].Enabled = false;

					sstabOptions.SelectedIndex = 3;


				}

			}
		}

//UPGRADE_WARNING: Event Opt5Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt5Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (Opt5Method.Checked == true) {
					sstabOptions.Enabled = true;
					sstabOptions.TabPages[0].Enabled = false;
					sstabOptions.TabPages[1].Enabled = false;
					sstabOptions.TabPages[2].Enabled = false;
					sstabOptions.TabPages[3].Enabled = false;
					sstabOptions.TabPages[4].Enabled = true;
					sstabOptions.TabPages[5].Enabled = false;
					sstabOptions.TabPages[6].Enabled = false;

					sstabOptions.SelectedIndex = 4;


				}
			}
		}

		private void AddCriteriaWithMethod1()
		{
			object field1type = null;
			string CritTitle = null;
			//Dim li_order as long

			int li_cnt = 0;
			string ls_Dest = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt1ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list");
				return;
			}

			if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & chkBlank.CheckState == 0 & cboDestField.SelectedIndex < 0 & cboDestGroupField.SelectedIndex < 0) {
				Interaction.MsgBox("Define a value, blank, or another field for this criteria type.");
				return;
			}

			if (TabFirstField.SelectedIndex == 1) {
				li_cnt = lstGroupList.SelectedIndex;

				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ")";

			} else if (TabFirstField.SelectedIndex == 0) {
				li_cnt = lstFieldList.SelectedIndex;

				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);

			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			if (cboOpt1ValueOperator.Text == "Is Between" & (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) | string.IsNullOrEmpty(txtOpt1IsBetweenMax.Text))) {
				Interaction.MsgBox("Please enter a min and max for the between logic", MsgBoxStyle.Critical);
				return;
			}

			//make sure that the typed value is of the same type as the field type
			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboOpt1ValueOperator.Text != "Is Between") {
				//If mid(field1type, 1, 3) = "Num" And Not IsNumeric(txtOpt1TypeinValue) Then
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD") {
					Interaction.MsgBox((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a numeric field, but the value is not a number. Please re-Specify...");
					return;
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD") {
					//this is OK
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text)) {
						Interaction.MsgBox((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a date field, but the value is not a date. Please re-Specify...");
						return;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5)) {
						Interaction.MsgBox((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
						return;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1))))) {
						Interaction.MsgBox((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
						return;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59)) {
						Interaction.MsgBox((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
						return;
					}
				}
			}

			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboOpt1ValueOperator.Text == "Is Between") {
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) != "Num") {
					Interaction.MsgBox((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is NOT a numeric field, but Between is specified. Please re-Specify...");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) == "Num" & (!Information.IsNumeric(txtOpt1TypeinValue.Text) | !Information.IsNumeric(txtOpt1IsBetweenMax.Text))) {
					Interaction.MsgBox((lstGroupList.SelectedIndex > -1 ? lstGroupList.Text : lstFieldList.Text) + " is a numeric field, but the value is not a number. Please re-Specify...");
					return;
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			CritTitle = (ChkProceed.CheckState ? "Only Proceed with Related Fields for " : "");

			if (TabFirstField.SelectedIndex == 0) {
				CritTitle = CritTitle + lstFieldList.Text + " " + cboOpt1ValueOperator.Text;
			} else if (TabFirstField.SelectedIndex == 1) {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) + " (" + cboJoinOperator.Text + ") " + cboOpt1ValueOperator.Text;
			}

			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
				CritTitle = CritTitle + " (" + txtOpt1TypeinValue.Text;
				if (!string.IsNullOrEmpty(txtOpt1IsBetweenMax.Text)) {
					CritTitle = CritTitle + " AND " + txtOpt1IsBetweenMax.Text;
				}
				CritTitle = CritTitle + ") ";
			}

			if (chkBlank.CheckState == CheckState.Checked) {

				CritTitle = CritTitle + " " + (chkUTD.CheckState == CheckState.Checked ? "(" : "") + "Blank";
				if (chkUTD.CheckState == CheckState.Checked) {
					CritTitle = CritTitle + " OR UTD) ";
				}
			}

			ls_Dest = (cboDestField.SelectedIndex > -1 ? cboDestField.Text : (cboDestField.SelectedIndex > -1 ? cboDestGroupField.Text + " (" + cboJoinOperator.Text + ") " : ""));

			if (Strings.Len(ls_Dest) > 0) {
				CritTitle = CritTitle + " " + ls_Dest;
			}

			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID, DestDDIDIsGroup, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, FieldValueMax, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, OnlyProceedWithRelatedFieldGroup) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";

			if (TabFirstField.SelectedIndex == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", 0,";
			} else if (TabFirstField.SelectedIndex == 1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", 1,";
			}

			if (cboDestField.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestField, cboDestField.SelectedIndex) + ", 0,";
			} else if (cboDestGroupField.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestGroupField, cboDestGroupField.SelectedIndex) + ", 1,";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,0,";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt1ValueOperator.Text + "', ";

			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt1TypeinValue.Text + "',";
			} else if (cboDestField.SelectedIndex > -1 | cboDestGroupField.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Null&UTD',";
			}

			if (cboOpt1ValueOperator.Text == "Is Between") {
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt1IsBetweenMax.Text + "', ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}


			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "'," + (ChkProceed.CheckState ? 1 : 0) + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}

		private void AddCriteriaWithMethod2()
		{
			string fieldLookupTableID = null;
			string IDFromLookup = null;
			object field1type = null;
			string CritTitle = null;
			int li_cnt = 0;
			int lL_LookupVal = 0;
			string ls_LookupTxt = null;
			short Index = 0;

			System.Data.DataSet  rs_Temp = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			Index = 0;


			if (cboOpt2ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list");
				return;
			}

			fieldLookupTableID = " Null ";
			if (cboLookupValues.SelectedIndex < 0) {
				Interaction.MsgBox("Select lookup value from list.");
				return;
			} else {
				modGlobal.gv_sql = "Select *   ";
				modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				modGlobal.gv_sql = "SELECT CompareToDesc from tbl_Setup_TableDef WHERE BaseTableID = " + modGlobal.gv_rs.rdoColumns["basetableid"].Value;
				rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(rs_Temp.rdoColumns["CompareToDesc"].Value)) {
					IDFromLookup = modGlobal.gv_rs.rdoColumns["Id"].Value;
				} else {
					IDFromLookup = modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value;
				}

				rs_Temp.Close();
				//UPGRADE_NOTE: Object rs_Temp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rs_Temp = null;

				modGlobal.gv_rs.Close();
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			ls_LookupTxt = cboLookupValues.Text;
			lL_LookupVal = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);

			//Loop for each selected field
			// For li_cnt = 0 To lstGroupList.ListCount - 1
			//      If lstGroupList.Selected(li_cnt) Then

			if (TabFirstField.SelectedIndex == 1) {
				li_cnt = lstGroupList.SelectedIndex;

				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ")";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			} else if (TabFirstField.SelectedIndex == 0) {
				li_cnt = lstFieldList.SelectedIndex;

				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			//make sure that the field type is not a date field
			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Mid(field1type, 1, 3) == "Dat") {
				Interaction.MsgBox("You cannot compare this field to a lookup value, because " + (TabFirstField.SelectedIndex == 1 ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) : Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt)) + " is a date field. Please re-Specify...");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			CritTitle = (ChkProceed.CheckState ? "Only Proceed with Related Fields for " : "");

			if (TabFirstField.SelectedIndex == 1) {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) + " (" + cboJoinOperator.Text + ") " + cboOpt2ValueOperator.Text + " " + ls_LookupTxt;
			} else {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " " + cboOpt2ValueOperator.Text + " " + ls_LookupTxt;
			}

			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, OnlyProceedWithRelatedFieldGroup)";

			modGlobal.gv_sql = modGlobal.gv_sql + " values (";

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";

			if (TabFirstField.SelectedIndex == 1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", 1,";
			} else if (TabFirstField.SelectedIndex == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", 0,";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt2ValueOperator.Text + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + IDFromLookup + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + lL_LookupVal + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "'," + (ChkProceed.CheckState ? 1 : 0) + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);
			//        lstGroupList.Selected(li_cnt) = False
			//    End If
			//Next

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		private void AddCriteriaWithMethod4()
		{
			object field1type = null;
			object Field2Type = null;
			string CritTitle = null;
			//Dim li_order as long
			object li_CriteriaSetID = null;
			int li_cnt = 0;


			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboFieldOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the Add/Subtract operation from the list.");
				return;
			}

			if (cboField2List.SelectedIndex < 0 & cboField2GroupList.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the second Field from the list.");
				return;
			}

			if (cboOpt3ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list.");
				return;
			}

			if (string.IsNullOrEmpty(txtOpt3TypeinValue.Text)) {
				Interaction.MsgBox("A value should be typed in.");
				return;
			}

			if (cboOpt3ValueOperator.Text == "Is Between" & string.IsNullOrEmpty(txtOpt4IsBetweenMax.Text)) {
				Interaction.MsgBox("A value should be typed into the max field.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			if (TabFirstField.SelectedIndex == 1) {
				li_cnt = lstGroupList.SelectedIndex;

				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ")";

			} else {
				li_cnt = lstFieldList.SelectedIndex;

				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
			}

			//Loop for each selected field
			// For li_cnt = 0 To lstGroupList.ListCount - 1
			//      If lstGroupList.Selected(li_cnt) Then

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			//make sure that the 2 selected fields are of the same type
			if (!string.IsNullOrEmpty(cboField2List.Text)) {
				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2List, cboField2List.SelectedIndex);

			} else if (!string.IsNullOrEmpty(cboField2GroupList.Text)) {
				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2GroupList, cboField2GroupList.SelectedIndex) + ")";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object Field2Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Field2Type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();
			//UPGRADE_WARNING: Couldn't resolve default property of object Field2Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type != Field2Type) {
				Interaction.MsgBox("The 2 fields that you have selected are not of the same type. Please re-specify...");
				return;
			}

			//make sure that the typed value is numeric
			if (!Information.IsNumeric(txtOpt3TypeinValue.Text)) {
				Interaction.MsgBox("The typed value has to be a numeric value. Please re-Specify...");
				return;
			}

			if (cboOpt3ValueOperator.Text == "Is Between" & !Information.IsNumeric(txtOpt4IsBetweenMax.Text)) {
				Interaction.MsgBox("The max value has to be a numeric value. Please re-Specify...");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type == "Date") {
				if (string.IsNullOrEmpty(cboOpt3Unit.Text)) {
					Interaction.MsgBox("Please define a date unit associated with the value");
					return;
				} else if (cboOpt3Unit.Text != "Years" & cboOpt3Unit.Text != "Months" & cboOpt3Unit.Text != "Days") {
					Interaction.MsgBox("Please define the appropriate date unit associated with the value");
					return;
				}

			}

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type == "Time") {
				if (string.IsNullOrEmpty(cboOpt3Unit.Text)) {
					Interaction.MsgBox("Please define a time unit associated with the value");
					return;
				} else if (cboOpt3Unit.Text != "Hours" & cboOpt3Unit.Text != "Minutes" & cboOpt3Unit.Text != "Seconds") {
					Interaction.MsgBox("Please define the appropriate time unit associated with the value");
					return;
				}
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type == "Time" & !Information.IsNumeric(txtOpt3TypeinValue.Text)) {
				Interaction.MsgBox("Please define a numeric value for this Time difference. Duration will be in minutes  ");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			CritTitle = (ChkProceed.CheckState ? "Only Proceed with Related Fields for " : "");

			if (TabFirstField.SelectedIndex == 1) {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) + " (" + cboJoinOperator.Text + ") ";
			} else if (TabFirstField.SelectedIndex == 0) {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt);
			}

			CritTitle = CritTitle + " " + cboFieldOperator.Text + " ";
			CritTitle = CritTitle + (cboField2List.SelectedIndex > -1 ? cboField2List.Text : cboField2GroupList.Text + " (" + cboJoinOperator.Text + ") ");
			CritTitle = CritTitle + " " + cboOpt3ValueOperator.Text;

			if (cboOpt3ValueOperator.Text == "Is Between") {
				CritTitle = CritTitle + " (" + txtOpt3TypeinValue.Text + " AND " + txtOpt4IsBetweenMax.Text + ") ";
			} else {
				CritTitle = CritTitle + " " + txtOpt3TypeinValue.Text;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type == "Date" | field1type == "Time") {
				CritTitle = CritTitle + " " + cboOpt3Unit.Text;
			}

			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ValueOperator, FieldValue, FieldValueMax, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID2, FieldID2IsGroup, FieldOperator, DateUnit, JoinOperator,OnlyProceedWithRelatedFieldGroup)";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";

			if (TabFirstField.SelectedIndex == 1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", 1, ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", 0, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt3ValueOperator.Text + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3TypeinValue.Text + "',";

			if (cboOpt3ValueOperator.Text == "Is Between") {
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt4IsBetweenMax.Text + "',";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}

			if (cboField2List.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2List, cboField2List.SelectedIndex) + ",0, ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2GroupList, cboField2GroupList.SelectedIndex) + ",1, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboFieldOperator.Text + "', ";
			if (!string.IsNullOrEmpty(cboOpt3Unit.Text)) {
				switch (cboOpt3Unit.Text) {
					case "Years":
						modGlobal.gv_sql = modGlobal.gv_sql + " 'YYYY',";
						break;
					case "Months":
						modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
						break;
					case "Days":
						modGlobal.gv_sql = modGlobal.gv_sql + " 'd',";
						break;
					case "Hours":
						modGlobal.gv_sql = modGlobal.gv_sql + " 'h',";
						break;
					case "Minutes":
						modGlobal.gv_sql = modGlobal.gv_sql + " 'n',";
						break;
					case "Seconds":
						modGlobal.gv_sql = modGlobal.gv_sql + " 's',";
						break;
				}
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " null,";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "'," + (ChkProceed.CheckState ? 1 : 0) + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//    End If
			//Next

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}


		private void AddCriteriaWithMethod3()
		{
			string field1type = null;
			string CritTitle = null;
			object li_CriteriaSetID = null;
			int li_cnt = 0;
			string ls_LookupTxt = null;
			int li_LookupVal = 0;


			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpLkTable.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list");
				return;
			}

			if (cboLookupTables.SelectedIndex < 0) {
				Interaction.MsgBox("Select lookup table from list.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			ls_LookupTxt = cboLookupTables.Text;
			li_LookupVal = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex);

			//Loop for each selected field
			//For li_cnt = 0 To lstGroupList.ListCount - 1
			//     If lstGroupList.Selected(li_cnt) Then

			if (TabFirstField.SelectedIndex == 1) {
				li_cnt = lstGroupList.SelectedIndex;

				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ")";
			} else {
				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			//make sure that the field type is not a date field
			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Mid(field1type, 1, 3) == "Dat") {
				Interaction.MsgBox("You cannot compare " + (TabFirstField.SelectedIndex == 1 ? Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) : Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt)) + " to a lookup table, because the selected field is a date field. Please re-Specify...");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			CritTitle = (ChkProceed.CheckState ? "Only Proceed with Related Fields for " : "");

			if (TabFirstField.SelectedIndex == 1) {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) + " (" + cboJoinOperator.Text + ") " + " " + cboOpLkTable.Text + " [" + ls_LookupTxt + "] Lookup Table ";

			} else {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " " + cboOpLkTable.Text + " [" + ls_LookupTxt + "] Lookup Table ";
			}

			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,OnlyProceedWithRelatedFieldGroup)";

			modGlobal.gv_sql = modGlobal.gv_sql + " values (";

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";

			if (TabFirstField.SelectedIndex == 1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", 1, ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", 0, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpLkTable.Text + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + li_LookupVal + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "'," + (ChkProceed.CheckState ? 1 : 0) + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);



			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}


		private void AddCriteriaWithMethod5()
		{
			object field1type = null;
			object Field2Type = null;
			string CritTitle = null;
			//Dim li_order as long
			object li_CriteriaSetID = null;
			object li_cnt = null;
			int li_cnt2 = 0;
			string[] ls_months = null;


			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt5ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list.");
				return;
			}

			if (lstRange.Items.Count == 0) {
				Interaction.MsgBox("Value(s) should be typed in.");
				return;
			}


			//Loop for each selected field
			if (TabFirstField.SelectedIndex == 1) {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_cnt = lstGroupList.SelectedIndex;
				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ")";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_cnt = lstFieldList.SelectedIndex;

				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);

			}
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);


			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type != "Date") {
				Interaction.MsgBox("This method is only valid with date fields", MsgBoxStyle.Critical, "Field is not a date");
				return;
			}

			for (li_cnt2 = 0; li_cnt2 <= lstRange.Items.Count - 1; li_cnt2++) {
				Array.Resize(ref ls_months, li_cnt2 + 1);
				ls_months[li_cnt2] = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstRange, li_cnt2);
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			CritTitle = (ChkProceed.CheckState ? "Only Proceed with Related Fields for " : "");


			if (TabFirstField.SelectedIndex == 1) {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) + " (" + cboJoinOperator.Text + ") ";
			} else {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " (" + cboJoinOperator.Text + ") ";
			}

			CritTitle = CritTitle + " Month " + cboOpt5ValueOperator.Text;
			CritTitle = CritTitle + " (" + Strings.Join(ls_months, ",") + ")";


			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ValueOperator, FieldValue, DateUnit, JoinOperator, OnlyProceedWithRelatedFieldGroup)";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";

			if (TabFirstField.SelectedIndex == 1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", 1, ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", 0, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt5ValueOperator.Text + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '(" + Strings.Join(ls_months, ",") + ")',";
			modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "'," + (ChkProceed.CheckState ? 1 : 0) + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);


			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}



		private void RefreshLookupTables()
		{

			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboLookupTables.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboLookupTables.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));

				modGlobal.gv_rs.MoveNext();
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		private void RefreshLookupListForThisField()
		{
			string LookupTableID = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			cboLookupValues.Items.Clear();

			if (TabFirstField.SelectedIndex == 1) {

				if (lstGroupList.SelectedItems.Count == 0)
					return;

				modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, lstGroupList.SelectedIndex) + ")";
				modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				if (modGlobal.gv_rs.RowCount > 0) {
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;

					modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + LookupTableID;
					modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					while (!modGlobal.gv_rs.EOF) {
						cboLookupValues.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));
						modGlobal.gv_rs.MoveNext();
					}
				} else if (Opt2Method.Checked == true) {
					Opt1Method.Checked = true;
				}
				modGlobal.gv_rs.Close();
			} else if (TabFirstField.SelectedIndex == 0) {
				modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				if (modGlobal.gv_rs.RowCount > 0) {
					LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;

					modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + LookupTableID;
					modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					while (!modGlobal.gv_rs.EOF) {
						cboLookupValues.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));
						modGlobal.gv_rs.MoveNext();
					}
				} else if (Opt2Method.Checked == true) {
					Opt1Method.Checked = true;
				}
				modGlobal.gv_rs.Close();
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}

		private void RefreshCriteriaFieldList()
		{
			string field1type = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (lstGroupList.SelectedItems.Count == 0)
				return;

			//find the field type
			modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, lstGroupList.SelectedIndex) + ")";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT'";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.fieldtype = '" + field1type + "'";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid <> " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, lstGroupList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " AND (ParentDDID IS NULL OR ParentDDID = DDID) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboField2List.Items.Clear();
			cboDestField.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				cboDestField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		private void RefreshFieldsList()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			//retrieve the list of table fields
			//fields are setup in the map measures form - tbl_setup_FieldMeasureSet

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef dd ";
			//" WHERE dd.DDID = fm.DDID AND fm.MeasureSetID = " & ii_MeasureSetID
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE (ParentDDID IS NULL OR ParentDDID = DDID) ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (dd.State = '' or dd.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			lstFieldList.Items.Clear();
			cboField2List.Items.Clear();
			cboDestField.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				lstFieldList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				cboDestField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}

//UPGRADE_WARNING: Event Opt6Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt6Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {
				if (Opt6Method.Checked == true) {
					sstabOptions.Enabled = true;
					sstabOptions.TabPages[0].Enabled = false;
					sstabOptions.TabPages[1].Enabled = false;
					sstabOptions.TabPages[2].Enabled = false;
					sstabOptions.TabPages[3].Enabled = false;
					sstabOptions.TabPages[4].Enabled = false;
					sstabOptions.TabPages[5].Enabled = true;
					sstabOptions.TabPages[6].Enabled = false;

					sstabOptions.SelectedIndex = 5;

				}
			}
		}

		private void AddCriteriaWithMethod6()
		{
			object field1type = null;
			object Field2Type = null;
			string CritTitle = null;
			//Dim li_order as long
			object li_CriteriaSetID = null;
			object li_cnt = null;
			int li_cnt2 = 0;
			string[] ls_Value = null;


			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt6ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list.");
				return;
			}

			if (lst6Range.Items.Count == 0) {
				Interaction.MsgBox("Value(s) should be typed in.");
				return;
			}


			//Loop for each selected field
			if (TabFirstField.SelectedIndex == 1) {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_cnt = lstGroupList.SelectedIndex;
				//find the field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ")";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_cnt = lstFieldList.SelectedIndex;

				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);

			}
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);


			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type != "Number" & field1type != "Text") {
				Interaction.MsgBox("This method is only valid with number or text fields", MsgBoxStyle.Critical, "Field is not a number or text");
				return;
			}

			for (li_cnt2 = 0; li_cnt2 <= lst6Range.Items.Count - 1; li_cnt2++) {
				Array.Resize(ref ls_Value, li_cnt2 + 1);

				ls_Value[li_cnt2] = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lst6Range, li_cnt2);
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			CritTitle = (ChkProceed.CheckState ? "Only Proceed with Related Fields for " : "");


			if (TabFirstField.SelectedIndex == 1) {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) + " (" + cboJoinOperator.Text + ") ";
			} else {
				CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " (" + cboJoinOperator.Text + ") ";
			}

			CritTitle = CritTitle + " " + cboOpt6ValueOperator.Text;

			CritTitle = CritTitle + " (" + Strings.Join(ls_Value, ",") + ")";


			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID1, FieldID1IsGroup, ValueOperator, FieldValue, JoinOperator, OnlyProceedWithRelatedFieldGroup)";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";

			if (TabFirstField.SelectedIndex == 1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", 1, ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", 0, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt6ValueOperator.Text + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '(" + Strings.Join(ls_Value, ",") + ")',";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "'," + (ChkProceed.CheckState ? 1 : 0) + ")";

			//   Debug.Print gv_sql

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);


			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

//UPGRADE_WARNING: Event Opt7Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt7Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.Checked) {

				if (Opt7Method.Checked == true) {
					sstabOptions.Enabled = true;
					sstabOptions.TabPages[0].Enabled = false;
					sstabOptions.TabPages[1].Enabled = false;
					sstabOptions.TabPages[2].Enabled = false;
					sstabOptions.TabPages[3].Enabled = false;
					sstabOptions.TabPages[4].Enabled = false;
					sstabOptions.TabPages[5].Enabled = false;
					sstabOptions.TabPages[6].Enabled = true;

					sstabOptions.SelectedIndex = 6;
					TabFirstField.SelectedIndex = 1;

				}


			}
		}

		private void AddCriteriaWithMethod7()
		{
			object field1type = null;
			string CritTitle = null;
			//Dim li_order as long

			int li_cnt = 0;
			string ls_Dest = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt7ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list");
				return;
			}

			if (chkOpt7Blank.CheckState == 0 & chkMethod7UTD.CheckState == 0) {
				Interaction.MsgBox("Define a value, blank, UTD, or another field for this criteria type.");
				return;
			}

			li_cnt = lstGroupList.SelectedIndex;

			//find the field type
			modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = (SELECT TOP 1 DDID FROM tbl_Setup_DDIDFieldGroup WHERE FieldGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ")";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Close();


			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			CritTitle = "Earliest (" + (ChkProceed.CheckState ? "Only Proceed with Related Fields for " : "");
			CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstGroupList, li_cnt) + " (" + cboJoinOperator.Text + ")) " + cboOpt7ValueOperator.Text;

			if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == 0) {
				CritTitle = CritTitle + " Blank";
			} else if (chkOpt7Blank.CheckState == 0 & chkMethod7UTD.CheckState == CheckState.Checked) {
				CritTitle = CritTitle + " UTD";
			} else if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == CheckState.Checked) {
				CritTitle = CritTitle + " (Blank OR UTD)";
			}


			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureFieldGroupLogic ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID2, FieldID2IsGroup, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, OnlyProceedWithRelatedFieldGroup) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", 1,";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt7ValueOperator.Text + "', ";

			if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
			} else if (chkOpt7Blank.CheckState == 0 & chkMethod7UTD.CheckState == CheckState.Checked) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'UTD',";
			} else if (chkOpt7Blank.CheckState == CheckState.Checked & chkMethod7UTD.CheckState == CheckState.Checked) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Null&UTD',";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "'," + (ChkProceed.CheckState ? 1 : 0) + ")";

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}
	}
}
