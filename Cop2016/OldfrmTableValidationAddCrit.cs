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
	internal partial class OldfrmTableValidationAddCrit : System.Windows.Forms.Form
	{
		object thismessageid;

//UPGRADE_WARNING: Event cboDestFieldList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboDestFieldList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			object cboOpt1Unit = null;
			if (cboDestFieldList.SelectedIndex > 0) {
				chkBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;
				txtOpt1TypeinValue.Text = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object cboOpt1Unit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboOpt1Unit = "";
			}

		}

//UPGRADE_WARNING: Event cboSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshSetDef();
		}

//UPGRADE_WARNING: Event chkBlank.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkBlank_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			object cboOpt1Unit = null;

			if (chkBlank.CheckState == CheckState.Checked) {
				txtOpt1TypeinValue.Text = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object cboOpt1Unit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboOpt1Unit = "";
				cboDestFieldList.SelectedIndex = -1;
			}

		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (sstabOptions.TabPages[0].Enabled == false & sstabOptions.TabPages[1].Enabled == false & sstabOptions.TabPages[2].Enabled == false & sstabOptions.TabPages[3].Enabled == false & !sstabOptions.TabPages[4].Enabled) {
				Interaction.MsgBox("Please select a method.");
				return;
			}

			if (lstField1List.SelectedIndex < 0) {
				Interaction.MsgBox("Please select a field from the list");
				return;
			}

			if (cboSet.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the Criteria Set.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");
				return;
			}


			if (sstabOptions.TabPages[0].Enabled == true) {
				modGlobal.gv_sql = "Select LookupTableID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_DataDef  ";
				modGlobal.gv_sql = modGlobal.gv_sql + "Where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & !Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					Interaction.MsgBox("This field is linked to a lookup table. Select Method 2 to compare it against a lookup value.");
					return;
				}
				AddCriteriaWithMethod1();
			} else if (sstabOptions.TabPages[1].Enabled == true) {
				AddCriteriaWithMethod2();
			} else if (sstabOptions.TabPages[2].Enabled == true) {
				AddCriteriaWithMethod3();
			} else if (sstabOptions.TabPages[3].Enabled == true) {
				AddCriteriaWithMethod4();
			} else if (sstabOptions.TabPages[4].Enabled) {
				AddCriteriaWithMethod5();
			}

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

		public void RefreshDestFieldList()
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

			cboDestFieldList.Items.Clear();

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

				cboDestFieldList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				modGlobal.gv_rs.MoveNext();
			}

		}

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstRange.SelectedIndex < 0) {
				return;
			}

			lstRange.Items.RemoveAt((lstRange.SelectedIndex));
		}

		private void frmTableValidationAddCrit_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			object thismessage = null;
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(modGlobal.gv_Action) == "ERROR") {
				//UPGRADE_WARNING: Couldn't resolve default property of object thismessage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thismessage = My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["Message"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thismessageid = My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object thismessage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thismessage = My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["Message"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				thismessageid = My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object thismessage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblMessage.Text = "Setup criteria for this " + modGlobal.gv_Action + " Message: " + thismessage;

			sstabOptions.SelectedIndex = 0;
			sstabOptions.TabPages[0].Enabled = false;
			sstabOptions.TabPages[1].Enabled = false;
			sstabOptions.TabPages[2].Enabled = false;
			Opt1Method.Checked = false;
			Opt2Method.Checked = false;
			Opt3Method.Checked = false;
			Opt4Method.Checked = false;
			Opt5Method.Checked = false;

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(modGlobal.gv_Action) == "ERROR" & My.MyProject.Forms.frmTableValidationSetup.lstErrorCriteriaSet.Items.Count > 0) {
				lblJoinOperator.Visible = true;
				cboJoinOperator.Visible = true;
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (Strings.UCase(modGlobal.gv_Action) == "WARNING" & My.MyProject.Forms.frmTableValidationSetup.lstWarningCriteriaSet.Items.Count > 0) {
				lblJoinOperator.Visible = true;
				cboJoinOperator.Visible = true;
			}

			RefreshFieldsList();
			RefreshDestFieldList();
			//    RefreshLookupList
			RefreshSetList();
			RefreshLookupTables();

		}
		public void RefreshLookupTables()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboLookupTables.Items.Clear();
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
				cboLookupTables.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));
				modGlobal.gv_rs.MoveNext();
			}


		}

		public void AddCriteriaWithMethod1()
		{
			object CritTitle = null;
			object NewCritID = null;
			object DestFieldType = null;
			string field1type = null;


			if (cboOpt1ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list");
				return;
			}

			if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboDestFieldList.SelectedIndex < 0 & chkBlank.CheckState == 0 & chkMidnight.CheckState == false) {
				Interaction.MsgBox("Either select a field, or check the blank, or type in a a value.");
				return;
			}


			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");
				return;
			}

			short li_cnt = 0;


			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++) {
				if (lstField1List.GetSelected(li_cnt)) {

					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Close();

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (chkMidnight.CheckState & field1type != "Date/Time") {
						Interaction.MsgBox("If 00:00 is selected then it can only be compared to a Date/Time field.");
						return;
					}

					if (cboDestFieldList.SelectedIndex > -1) {
						//find the Dest field type
						modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
						modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex);
						modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

						//UPGRADE_WARNING: Couldn't resolve default property of object DestFieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						DestFieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
						modGlobal.gv_rs.Close();

						//UPGRADE_WARNING: Couldn't resolve default property of object DestFieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (field1type != DestFieldType) {
							Interaction.MsgBox("The data types of the selected fields don't match. Please re-Specify...");
							return;
						}
					}


					//make sure that the typed value is of the same type as the field type
					if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
						//If mid(field1type, 1, 3) = "Num" And Not IsNumeric(txtOpt1TypeinValue) Then
						//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD") {
							Interaction.MsgBox("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
							return;
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD") {
							//this is OK
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text)) {
								Interaction.MsgBox("The selected field is a date field, but the value is not a date. Please re-Specify...");
								return;
							}
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5)) {
								Interaction.MsgBox("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
								return;
							}
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1))))) {
								Interaction.MsgBox("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
								return;
							}
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59)) {
								Interaction.MsgBox("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
								return;
							}
						}
					}



					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableValidation", ref "TableValidationID");

					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CritTitle = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstField1List, li_cnt) + " " + cboOpt1ValueOperator.Text;

					if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CritTitle = CritTitle + " " + txtOpt1TypeinValue.Text;
					}
					if (cboDestFieldList.SelectedIndex > -1) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CritTitle = CritTitle + " " + cboDestFieldList.Text;
					}
					if (chkBlank.CheckState == CheckState.Checked) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CritTitle = CritTitle + " Blank ";
					}
					if (chkMidnight.CheckState) {
						//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CritTitle = CritTitle + " 00:00";
					}

					modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, DestDDID, ValueOperator, Value, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, JoinOperator,CriteriaSet)";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + thismessageid + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt) + ", ";
					if (cboDestFieldList.SelectedIndex > -1) {
						modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex) + ", ";
					} else {
						modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt1ValueOperator.Text + "', ";
					if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
						modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt1TypeinValue.Text + "',";
					} else if (chkBlank.CheckState == CheckState.Checked) {
						modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
					} else if (chkMidnight.CheckState) {
						modGlobal.gv_sql = modGlobal.gv_sql + " '00:00', ";
					} else {
						modGlobal.gv_sql = modGlobal.gv_sql + " null,";
					}

					if (chkMidnight.CheckState) {
						modGlobal.gv_sql = modGlobal.gv_sql + " 'Hour',";
					} else {
						modGlobal.gv_sql = modGlobal.gv_sql + " null,";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
					modGlobal.gv_sql = modGlobal.gv_sql + ")";

					//g = InputBox("", "", gv_sql)
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				}
			}

			UpdateMainJoinOp();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			this.Close();
		}

		public void AddCriteriaWithMethod2()
		{
			object CritTitle = null;
			object NewCritID = null;
			object field1type = null;
			object li_cnt = null;
			object IDFromLookup = null;
			object fieldLookupTableID = null;

			if (cboOpt2ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object fieldLookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			fieldLookupTableID = " Null ";
			if (cboLookupValues.SelectedIndex < 0) {
				Interaction.MsgBox("Select lookup value from list.");
				return;
			} else {

				modGlobal.gv_sql = "Select *   ";
				modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Couldn't resolve default property of object IDFromLookup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IDFromLookup = modGlobal.gv_rs.rdoColumns["Id"].Value;

			}



			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");
				return;
			}

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++) {
				if (lstField1List.GetSelected(li_cnt)) {


					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Close();

					//make sure that the field type is not a date field
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(field1type, 1, 3) == "Dat") {
						Interaction.MsgBox("You cannot compare this field to a lookup value, because the selected field is a date field. Please re-Specify...");
						return;
					}



					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableValidation", ref "TableValidationID");

					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CritTitle = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstField1List, li_cnt) + " " + cboOpt2ValueOperator.Text + " " + cboLookupValues.Text;
					//Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

					modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " TableValidationMessageID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";

					modGlobal.gv_sql = modGlobal.gv_sql + " values (";

					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + thismessageid + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt2ValueOperator.Text + "', ";
					//UPGRADE_WARNING: Couldn't resolve default property of object IDFromLookup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + IDFromLookup + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
					modGlobal.gv_sql = modGlobal.gv_sql + ")";

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}

			}

			UpdateMainJoinOp();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			this.Close();

		}
		public void AddCriteriaWithMethod3()
		{
			object CritTitle = null;
			object NewCritID = null;
			object field1type = null;
			object li_cnt = null;

			if (cboOpLkTable.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the operator from the list.");
				return;
			}

			if (cboLookupTables.SelectedIndex < 0) {
				Interaction.MsgBox("Please select a Lookup Table from the list.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");
				return;
			}


			for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++) {
				if (lstField1List.GetSelected(li_cnt)) {

					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Close();

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.UCase(Strings.Mid(field1type, 1, 3)) == "DAT" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "TIM" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "NUM") {
						Interaction.MsgBox("A date, time or numeric field can not be compared to a lookup table. Please re-Specify...");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableValidation", ref "TableValidationID");

					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CritTitle = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstField1List, li_cnt) + " " + cboOpLkTable.Text + " [" + cboLookupTables.Text + "] Lookup Table ";
					//Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

					modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Fieldoperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + thismessageid + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpLkTable.Text + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + " null,";
					modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
					modGlobal.gv_sql = modGlobal.gv_sql + ")";

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				}
			}

			UpdateMainJoinOp();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			this.Close();

		}

		public void AddCriteriaWithMethod4()
		{
			object CritTitle = null;
			object NewCritID = null;
			object Field2Type = null;
			object field1type = null;
			object li_cnt = null;

			if (cboFieldOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the Add/Subtract operation from the list.");
				return;
			}

			if (cboField2List.SelectedIndex < 0) {
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

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");
				return;
			}

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++) {
				if (lstField1List.GetSelected(li_cnt)) {

					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Close();

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.UCase(Strings.Mid(field1type, 1, 3)) != "DAT" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "TIM" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "NUM") {
						Interaction.MsgBox("Only a date, time or numeric field can be selected for this method. Please re-Specify...");
						return;
					}

					//make sure that the 2 selected fields are of the same type
					if (!string.IsNullOrEmpty(cboField2List.Text)) {
						//find the field type
						modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
						modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2List, cboField2List.SelectedIndex);
						modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

						//UPGRADE_WARNING: Couldn't resolve default property of object Field2Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Field2Type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
						modGlobal.gv_rs.Close();
						//UPGRADE_WARNING: Couldn't resolve default property of object Field2Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (field1type != Field2Type & Field2Type != "Date/Time") {
							Interaction.MsgBox("The 2 fields that you have selected are not of the same type. Please re-specify...");
							return;
						}
					}


					//make sure that the typed value is numeric
					if (!Information.IsNumeric(txtOpt3TypeinValue.Text)) {
						Interaction.MsgBox("The typed value has to be a numeric value. Please re-Specify...");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type == "Date" & cboFieldOperator.Text != "-") {
						Interaction.MsgBox("Date fields can only be subtracted from eachother.");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type == "Date" & string.IsNullOrEmpty(cboOpt3Unit.Text)) {
						Interaction.MsgBox("Please define the date unit associated with the value");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableValidation", ref "TableValidationID");

					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CritTitle = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstField1List, li_cnt);
					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CritTitle = CritTitle + " " + cboFieldOperator.Text + " " + cboField2List.Text;
					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CritTitle = CritTitle + " " + cboOpt3ValueOperator.Text;
					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CritTitle = CritTitle + " " + txtOpt3TypeinValue.Text;
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type == "Date" | field1type == "Time" | field1type == "Date/Time") {
						//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CritTitle = CritTitle + " " + cboOpt3Unit.Text;
					}

					modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, ValueOperator, Value, ";
					modGlobal.gv_sql = modGlobal.gv_sql + "  Fieldoperator, DateUnit, JoinOperator, CriteriaSet)";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + thismessageid + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2List, cboField2List.SelectedIndex) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt3ValueOperator.Text + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3TypeinValue.Text + "',";
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
							case "Minutes":
								modGlobal.gv_sql = modGlobal.gv_sql + " 'n',";
								break;
						}
					} else {
						modGlobal.gv_sql = modGlobal.gv_sql + " null,";
					}
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
					modGlobal.gv_sql = modGlobal.gv_sql + ")";

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				}

			}

			UpdateMainJoinOp();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			this.Close();

		}


		private void AddCriteriaWithMethod5()
		{
			object NewCritID = null;
			object field1type = null;
			object Field2Type = null;
			string CritTitle = null;
			//Dim li_order AS Long
			object li_CriteriaSetID = null;
			object li_cnt = null;
			int li_cnt2 = 0;
			string[] ls_months = null;

			//3.17.2005 - added method 5
			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt5ValueOperator.SelectedIndex < 0) {
				Interaction.MsgBox("Please select the field operation from the list.");
				return;
			}

			if (lstRange.Items.Count == 0) {
				Interaction.MsgBox("Value(s) should be typed in.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				Interaction.MsgBox("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");
				return;
			}


			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++) {
				if (lstField1List.GetSelected(li_cnt)) {
					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt);
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

					CritTitle = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstField1List, li_cnt);
					CritTitle = CritTitle + " Month " + cboOpt5ValueOperator.Text;
					CritTitle = CritTitle + " (" + Strings.Join(ls_months, ",") + ")";



					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_TableValidation", ref "TableValidationID");

					modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ValueOperator, Value, ";
					modGlobal.gv_sql = modGlobal.gv_sql + "  DateUnit, JoinOperator, CriteriaSet)";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
					//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + thismessageid + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt5ValueOperator.Text + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '(" + Strings.Join(ls_months, ",") + ")',";
					modGlobal.gv_sql = modGlobal.gv_sql + "'m', ";
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
					modGlobal.gv_sql = modGlobal.gv_sql + ")";

					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}
			}

			UpdateMainJoinOp();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			this.Close();

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		public void RefreshSetDef()
		{

			if (cboSet.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Select JoinOperator from tbl_setup_TableValidation ";
			//UPGRADE_WARNING: Couldn't resolve default property of object thismessageid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID = " + thismessageid;
			modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				cboJoinOperator.Text = "";
				cboJoinOperator.Enabled = true;
			} else {
				cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				cboJoinOperator.Enabled = false;
			}
			modGlobal.gv_rs.Close();

		}

		public void RefreshSetList()
		{
			object SetIndex = null;
			cboSet.Items.Clear();

			modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_tablevalidation ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(modGlobal.gv_Action) == "ERROR") {
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = " + My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of criteria
			//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetIndex = 1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboSet.Items.Add("Set " + SetIndex);
				//UPGRADE_ISSUE: ComboBox property cboSet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboSet, cboSet.NewIndex, SetIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SetIndex = SetIndex + 1;
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//always add a new one to the list in addition to the previous ones
			//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + SetIndex, SetIndex));

		}

//Public Sub RefreshLookupList()
//
//    gv_sql = "Select tbl_Setup_TableDef.BaseTable, tbl_Setup_misclookuplist.*  "
//    gv_sql = gv_sql & " From tbl_Setup_TableDef, tbl_Setup_misclookuplist  "
//    gv_sql = gv_sql & "Where tbl_Setup_TableDef.BaseTableID = tbl_Setup_misclookuplist.BaseTableID "
//    gv_sql = gv_sql & "Order By tbl_Setup_TableDef.BaseTable, tbl_Setup_misclookuplist.sortorder, tbl_Setup_misclookuplist.FieldValue"
//
//    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
//    cboLookupValues.Clear
//    While Not gv_rs.EOF
//        cboLookupValues.AddItem gv_rs!BaseTable & " - (" & gv_rs!Id & ") " & gv_rs!FIELDVALUE
//        cboLookupValues.ItemData(cboLookupValues.NewIndex) = gv_rs!LookupID
//        gv_rs.MoveNext
//    Wend
//
//End Sub

		public void RefreshFieldsList()
		{
			var LIndex = 0;

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmTableValidationSetup.cboTableList, My.MyProject.Forms.frmTableValidationSetup.cboTableList.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			lstField1List.Items.Clear();
			cboField2List.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				lstField1List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();


		}

//UPGRADE_WARNING: Event lstField1List.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstField1List_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
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
					sstabOptions.SelectedIndex = 4;
				}
			}
		}

//UPGRADE_WARNING: Event txtOpt1TypeinValue.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtOpt1TypeinValue_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
				chkBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;
				cboDestFieldList.SelectedIndex = -1;
			}

		}

		public void UpdateMainJoinOp()
		{
			//update join operator if any
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR") {
				modGlobal.gv_sql = "Update tbl_Setup_TableValidationMessage ";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + modGlobal.gv_ANDOR + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID = ";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.UCase(modGlobal.gv_Action) == "ERROR") {
					modGlobal.gv_sql = modGlobal.gv_sql + My.MyProject.Forms.frmTableValidationSetup.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + My.MyProject.Forms.frmTableValidationSetup.rdcValidationWarnings.Resultset.rdoColumns["TableValidationMessageID"].Value;
				}
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
			}

		}

		public void RefreshLookupListForThisField()
		{
			var LIndex = 0;
			object Field_ListIndex = null;
			object LookupTableID = null;
			modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
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
			} else if (Opt2Method.Checked == true) {
				Opt1Method.Checked = true;
			}

		}

		public void RefreshCriteriaFieldList()
		{
			var LIndex = 0;
			object thisfieldtype = null;

			//find the field type of the selected field
			modGlobal.gv_sql = "Select fieldtype ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object thisfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			thisfieldtype = modGlobal.gv_rs.rdoColumns["FieldType"].Value;

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID =  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmTableValidationSetup.cboTableList, My.MyProject.Forms.frmTableValidationSetup.cboTableList.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " and ";
			//UPGRADE_WARNING: Couldn't resolve default property of object thisfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " ( fieldtype = '" + thisfieldtype + "'";

			//UPGRADE_WARNING: Couldn't resolve default property of object thisfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (thisfieldtype == "Time") {
				modGlobal.gv_sql = modGlobal.gv_sql + " OR fieldtype = 'Date/Time'";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " ) and DDID <>  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboDestFieldList.Items.Clear();
			cboField2List.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				cboDestFieldList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

		}
	}
}
