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
	internal partial class OldfrmCMSParentAddCrit : Form
	{
		object thismessageid;
		private int il_CMSParentID;

        //UPGRADE_WARNING: Event cboDestFieldList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboDestFieldList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            object cboOpt1Unit = null;
            if (cboDestFieldList.SelectedIndex > 0)
            {
                chkBlank.CheckState = CheckState.Unchecked;
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

			if (chkBlank.CheckState == CheckState.IsChecked) {
				txtOpt1TypeinValue.Text = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object cboOpt1Unit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboOpt1Unit = "";
				cboDestFieldList.SelectedIndex = -1;
			}

		}

		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled == false & sstabOptions4.Enabled == false & !sstabOptions5.Enabled) {
				RadMessageBox.Show("Please select a method.");
				return;
			}

			if (lstField1List.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a field from the list");
				return;
			}

			if (cboSet.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the Criteria Set.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			if (sstabOptions1.Enabled == true) {
				modGlobal.gv_sql = "Select LookupTableID  ";
				modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_DataDef  ";
				modGlobal.gv_sql = modGlobal.gv_sql + "Where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & !Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {
					RadMessageBox.Show("This field is linked to a lookup table. Select Method 2 to compare it against a lookup value.");
					return;
				}
				AddCriteriaWithMethod1();
			} else if (sstabOptions2.Enabled == true) {
				AddCriteriaWithMethod2();
			} else if (sstabOptions3.Enabled == true) {
				AddCriteriaWithMethod3();
			} else if (sstabOptions4.Enabled == true) {
				AddCriteriaWithMethod4();
			} else if (sstabOptions5.Enabled) {
				AddCriteriaWithMethod5();
			}

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void RefreshDestFieldList()
		{
			var LIndex = 0;
			object Field_ListIndex = null;

			modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = (Select BaseTableID From tbl_Setup_TableDef where BaseTable = 'PATIENT')";
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

				//LDW modGlobal.gv_rs.MoveNext();
			}

		}


		public void SetCMSParentID( int ParentID)
		{
			il_CMSParentID = ParentID;
		}


        private void frmCMSParentAddCrit_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            object thismessage = null;
            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.WaitCursor;

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            this.Text = "Add Parent " + modGlobal.gv_Action + " Criteria";
            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

            //UPGRADE_WARNING: Couldn't resolve default property of object thismessage. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lblMessage.Text = "Setup criteria for Parent " + modGlobal.gv_Action + " Criteria: " + thismessage;

            sstabOptions.SelectedIndex = 0;
            sstabOptions1.Enabled = false;
            sstabOptions2.Enabled = false;
            sstabOptions3.Enabled = false;
            Opt1Method.IsChecked = false;
            Opt2Method.IsChecked = false;
            Opt3Method.IsChecked = false;

            RefreshFieldsList();
            RefreshDestFieldList();
            //RefreshLookupList
            RefreshSetList();
            RefreshLookupTables();

            //UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            Cursor.Current = Cursors.Default;

        }
        private void RefreshLookupTables()
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
				//LDW modGlobal.gv_rs.MoveNext();
			}


		}

		private void AddCriteriaWithMethod1()
		{
			string CritTitle = null;
			object DestFieldType = null;
			string field1type = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt1ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the field operation from the list");
				return;
			}

			if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboDestFieldList.SelectedIndex < 0 & chkBlank.CheckState == 0) {
				RadMessageBox.Show("Either select a field, or check the blank, or type in a a value.");
				return;
			}

			//find the field type
			modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Dispose();

			if (cboDestFieldList.SelectedIndex > -1) {
				//find the Dest field type
				modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//UPGRADE_WARNING: Couldn't resolve default property of object DestFieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DestFieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
				modGlobal.gv_rs.Dispose();

				//UPGRADE_WARNING: Couldn't resolve default property of object DestFieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (field1type != DestFieldType) {
					RadMessageBox.Show("The data types of the selected fields don't match. Please re-Specify...");
					return;
				}
			}


			//make sure that the typed value is of the same type as the field type
			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text)) {
					RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text)) {
					RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5)) {
					RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1))))) {
					RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
					return;
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59)) {
					RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
					return;
				}

			}

			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CritTitle = lstField1List.Text + " " + cboOpt1ValueOperator.Text;

			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CritTitle = CritTitle + " " + txtOpt1TypeinValue.Text;
			}
			if (cboDestFieldList.SelectedIndex > -1) {
				//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CritTitle = CritTitle + " " + cboDestFieldList.Text;
			}
			if (chkBlank.CheckState == CheckState.IsChecked) {
				//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CritTitle = CritTitle + " Blank ";
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DestDDID, ValueOperator, FieldValue, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, JoinOperator, ";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet) ";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet) ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (";
			modGlobal.gv_sql = modGlobal.gv_sql + il_CMSParentID + ", ";
			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
			if (cboDestFieldList.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex) + ", ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt1ValueOperator.Text + "', ";
			if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt1TypeinValue.Text + "',";
			} else if (chkBlank.CheckState == CheckState.IsChecked) {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " null,";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " null,";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void AddCriteriaWithMethod2()
		{
			string CritTitle = null;
			string field1type = null;
			int IDFromLookup;
			int fieldLookupTableID;
			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt2ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the field operation from the list");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object fieldLookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			fieldLookupTableID = " Null ";
			if (cboLookupValues.SelectedIndex < 0) {
				RadMessageBox.Show("Select lookup value from list.");
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
				RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			//find the field type
			modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Dispose();

			//make sure that the field type is not a date field
			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Mid(field1type, 1, 3) == "Dat") {
				RadMessageBox.Show("You cannot compare this field to a lookup value, because the selected field is a date field. Please re-Specify...");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CritTitle = lstField1List.Text + " " + cboOpt2ValueOperator.Text + " " + cboLookupValues.Text;
			//Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (";

			modGlobal.gv_sql = modGlobal.gv_sql + il_CMSParentID + ", ";
			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt2ValueOperator.Text + "', ";
			//UPGRADE_WARNING: Couldn't resolve default property of object IDFromLookup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + IDFromLookup + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex) + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}
		private void AddCriteriaWithMethod3()
		{
			string CritTitle = null;
			string field1type = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpLkTable.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the operator from the list.");
				return;
			}

			if (cboLookupTables.SelectedIndex < 0) {
				RadMessageBox.Show("Please select a Lookup Table from the list.");
				return;
			}

			//find the field type
			modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Dispose();

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(Strings.Mid(field1type, 1, 3)) == "DAT" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "TIM" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "NUM") {
				RadMessageBox.Show("A date, time or numeric field can not be compared to a lookup table. Please re-Specify...");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CritTitle = lstField1List.Text + " " + cboOpLkTable.Text + " [" + cboLookupTables.Text + "] Lookup Table ";
			//Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Fieldoperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + il_CMSParentID + ", ";
			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex) + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpLkTable.Text + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + " null,";
			modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:


			modGlobal.CheckForErrors();
		}

		private void AddCriteriaWithMethod4()
		{
			string CritTitle = null;
			string Field2Type = null;
			string field1type = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboFieldOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the Add/Subtract operation from the list.");
				return;
			}

			if (cboField2List.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the second Field from the list.");
				return;
			}

			if (cboOpt3ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the field operation from the list.");
				return;
			}

			if (string.IsNullOrEmpty(txtOpt3TypeinValue.Text)) {
				RadMessageBox.Show("A value should be typed in.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			//find the field type
			modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			modGlobal.gv_rs.Dispose();

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.UCase(Strings.Mid(field1type, 1, 3)) != "DAT" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "TIM" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "NUM") {
				RadMessageBox.Show("Only a date, time or numeric field can be selected for this method. Please re-Specify...");
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
				modGlobal.gv_rs.Dispose();
				//UPGRADE_WARNING: Couldn't resolve default property of object Field2Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (field1type != Field2Type) {
					RadMessageBox.Show("The 2 fields that you have selected are not of the same type. Please re-specify...");
					return;
				}
			}


			//make sure that the typed value is numeric
			if (!Information.IsNumeric(txtOpt3TypeinValue.Text)) {
				RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type == "Date" & cboFieldOperator.Text != "-") {
				RadMessageBox.Show("Date fields can only be subtracted from eachother.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type == "Date" & string.IsNullOrEmpty(cboOpt3Unit.Text)) {
				RadMessageBox.Show("Please define the date unit associated with the value");
				return;
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CritTitle = lstField1List.Text;
			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CritTitle = CritTitle + " " + cboFieldOperator.Text + " " + cboField2List.Text;
			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CritTitle = CritTitle + " " + cboOpt3ValueOperator.Text;
			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CritTitle = CritTitle + " " + txtOpt3TypeinValue.Text;
			//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (field1type == "Date") {
				//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CritTitle = CritTitle + " " + cboOpt3Unit.Text;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, FieldValue, ";
			modGlobal.gv_sql = modGlobal.gv_sql + "  Fieldoperator, DateUnit, JoinOperator, ";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + il_CMSParentID + ", ";
			//UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
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
				}
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " null,";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}
		private void RefreshSetDef()
		{

			if (cboSet.SelectedIndex < 0) {
				return;
			}

			modGlobal.gv_sql = "Select JoinOperator from ";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_CMSParentAnswerCriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where CMSParentCDID = " + il_CMSParentID;
				modGlobal.gv_sql = modGlobal.gv_sql + " and CMSParentAnswerCriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_CMSFieldMeasureCriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CMSFieldMeasureID = " + il_CMSParentID;
				modGlobal.gv_sql = modGlobal.gv_sql + " and CMSFieldMeasureCriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				cboJoinOperator.Text = "";
				cboJoinOperator.Enabled = true;
			} else {
				cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				cboJoinOperator.Enabled = false;
			}
			modGlobal.gv_rs.Dispose();

		}

		private void RefreshSetList()
		{
			short li_LastIndex = 0;

			cboSet.Items.Clear();

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = "Select DISTINCT CMSParentAnswerCriteriaSet as CriteriaSet from tbl_Setup_CMSParentAnswerCriteriaSet WHERE CMSParentCDID = " + il_CMSParentID + " ORDER BY CMSParentAnswerCriteriaSet ";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = "Select DISTINCT CMSFieldMeasureCriteriaSet as CriteriaSet from tbl_Setup_CMSFieldMeasureCriteriaSet WHERE CMSFieldMeasureID = " + il_CMSParentID + " ORDER BY CMSFieldMeasureCriteriaSet ";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of criteria
			while (!modGlobal.gv_rs.EOF) {
				cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value, modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value));
				li_LastIndex = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

			if (li_LastIndex == 0) {
				cboJoinOperator.Enabled = true;
			} else {
				cboJoinOperator.Enabled = false;
			}

			//always add a new one to the list in addition to the previous ones
			cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + li_LastIndex + 1, li_LastIndex + 1));

		}

        //Private Sub RefreshLookupList()
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

        private void RefreshAnswerCodes()
        {
            object lstAvailable = null;
            object lstChildren = null;
            DataSet rsAnswerCD = null;
            int li_cnt = 0;

            modGlobal.gv_sql = "Select cms.FieldMeasureID, cms.measurecode, df.ddid, df.fieldname, df.cmsfieldcode ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as df ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_cmsFieldMeasures as cms ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";

            //UPGRADE_WARNING: Couldn't resolve default property of object lstChildren.ListCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (lstChildren.ListCount > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE cms.FieldMeasureID NOT IN (";

                //UPGRADE_WARNING: Couldn't resolve default property of object lstChildren.ListCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                for (li_cnt = 0; li_cnt <= lstChildren.ListCount - 1; li_cnt++)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object lstChildren.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + lstChildren.ItemData(li_cnt) + ",";
                }

                modGlobal.gv_sql = Strings.Mid(modGlobal.gv_sql, 1, Strings.Len(modGlobal.gv_sql) - 1) + ")";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " order by cmsfieldcode, df.FieldName, MeasureCode ";

            rsAnswerCD = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object lstAvailable.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lstAvailable.Clear();

            while (!rsAnswerCD.EOF)
            {
                lstAvailable.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rsAnswerCD.rdoColumns["measurecode"].Value + " - " + rsAnswerCD.rdoColumns["FieldName"].Value + " **** " + rsAnswerCD.rdoColumns["cmsfieldcode"].Value, rsAnswerCD.rdoColumns["fieldmeasureid"].Value));

                rsAnswerCD.MoveNext();
            }

            rsAnswerCD.Close();
            //UPGRADE_NOTE: Object rsAnswerCD may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            rsAnswerCD = null;


        }

        private void RefreshFieldsList()
		{
			var LIndex = 0;

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = (SELECT BaseTableID FROM tbl_Setup_TableDef where basetable = 'PATIENT')";
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
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();


		}

//UPGRADE_WARNING: Event lstField1List.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstField1List_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshLookupListForThisField();
			RefreshCriteriaFieldList();
		}

        private void lstField1List_MouseDown(System.Object eventSender, MouseEventArgs eventArgs)
        {
            int Button = Convert.ToInt32(e.Button) / 0x100000;
            int Shift = Convert.ToInt32(Control.ModifierKeys) / 0x10000;
            float X = Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(e.X);
            float Y = Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(e.Y);
            int li_cnt = 0;

            //disable the multiselect manually (this property is read-only at run-time)
            if (lstField1List.SelectedItems.Count > 1 & !Opt5Method.IsChecked)
            {
                lstField1List.SetSelected(lstField1List.SelectedIndex, true);
                Application.DoEvents();

                if (lstField1List.SelectedItems.Count > 1)
                {
                    for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                    {
                        if (lstField1List.SelectedIndex != li_cnt)
                        {
                            lstField1List.SetSelected(li_cnt, false);
                        }
                    }
                }
            }
        }

        //UPGRADE_WARNING: Event Opt1Method.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt1Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {
				if (Opt1Method.IsChecked == true) {
					sstabOptions.Enabled = true;
					sstabOptions1.Enabled = true;
					sstabOptions2.Enabled = false;
					sstabOptions3.Enabled = false;
					sstabOptions4.Enabled = false;
					sstabOptions5.Enabled = false;


					sstabOptions.SelectedIndex = 0;
				}

			}
		}

//UPGRADE_WARNING: Event Opt2Method.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt2Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {
				if (Opt2Method.IsChecked == true) {
					sstabOptions.Enabled = true;
					sstabOptions1.Enabled = false;
					sstabOptions2.Enabled = true;
					sstabOptions3.Enabled = false;
					sstabOptions4.Enabled = false;
					sstabOptions5.Enabled = false;


					sstabOptions.SelectedIndex = 1;
				}

			}
		}

//UPGRADE_WARNING: Event Opt3Method.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt3Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {

				if (Opt3Method.IsChecked == true) {
					sstabOptions.Enabled = true;
					sstabOptions1.Enabled = false;
					sstabOptions2.Enabled = false;
					sstabOptions3.Enabled = true;
					sstabOptions4.Enabled = false;
					sstabOptions5.Enabled = false;


					sstabOptions.SelectedIndex = 2;
				}


			}
		}

//UPGRADE_WARNING: Event Opt4Method.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt4Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {

				if (Opt4Method.IsChecked == true) {
					sstabOptions.Enabled = true;
					sstabOptions1.Enabled = false;
					sstabOptions2.Enabled = false;
					sstabOptions3.Enabled = false;
					sstabOptions4.Enabled = true;
					sstabOptions5.Enabled = false;

					sstabOptions.SelectedIndex = 3;
				}

			}
		}

//UPGRADE_WARNING: Event Opt5Method.IsCheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt5Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {
				if (Opt5Method.IsChecked) {
					sstabOptions.Enabled = true;
					sstabOptions1.Enabled = false;
					sstabOptions2.Enabled = false;
					sstabOptions3.Enabled = false;
					sstabOptions4.Enabled = false;
					sstabOptions5.Enabled = true;

					sstabOptions.SelectedIndex = 4;
				}
			}
		}

        //UPGRADE_WARNING: Event txtOpt1TypeinValue.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void txtOpt1TypeinValue_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
            {
                chkBlank.CheckState = CheckState.Unchecked;
                cboDestFieldList.SelectedIndex = -1;
            }

        }

        private void RefreshLookupListForThisField()
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

					//LDW modGlobal.gv_rs.MoveNext();
				}
			} else if (Opt2Method.IsChecked == true) {
				Opt1Method.IsChecked = true;
			}

		}

		private void RefreshCriteriaFieldList()
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
			modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID =  (SELECT BasetableID FROM tbl_Setup_TableDef WHERE BaseTable = 'PATIENT')";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object thisfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and fieldtype = '" + thisfieldtype + "'";
			modGlobal.gv_sql = modGlobal.gv_sql + " and DDID <>  " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
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
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

		}

		private void AddCriteriaWithMethod5()
		{
			string field1type = null;
			string Field2Type = null;
			string CritTitle = null;
			//Dim li_order as long
			int li_CriteriaSetID;
			int li_cnt = 0;
			string[] GroupIDs = null;
			int li_group = 0;

			//On Error GoTo ErrHandler


			if (chkBlank5.CheckState == CheckState.IsChecked & cboOpt5ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please choose an operator for Blank Comparison");
				return;
			}

			li_group = 0;
			GroupIDs = new string[li_group + 1];

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++) {
				if (lstField1List.GetSelected(li_cnt)) {
					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Dispose();

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type != "Date" & field1type != "Time") {
						RadMessageBox.Show("The selected fields are not date or time fields");
						return;
					}

					if (string.IsNullOrEmpty(CritTitle)) {
						CritTitle = "EARLIEST(";
					}

					CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstField1List, li_cnt) + ",";

					Array.Resize(ref GroupIDs, li_group + 1);
					GroupIDs[li_group] = Convert.ToString(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, li_cnt));
					li_group = li_group + 1;
				}
			}

			CritTitle = Strings.Mid(CritTitle, 1, Strings.Len(CritTitle) - 1);
			CritTitle = CritTitle + ") " + cboOpt5ValueOperator.Text + " BLANK";

			if (Information.UBound(GroupIDs) < 1) {
				RadMessageBox.Show("You must select more than one field to determine the earliest.");
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + "CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, FieldValue, JoinOperator, ";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_Action == "ANSWER") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (modGlobal.gv_Action == "FIELD") {
				modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + il_CMSParentID + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboOpt5ValueOperator.Text + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + Strings.Join(GroupIDs, ",") + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex) + ")";

			//InputBox "", "", gv_sql

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}
	}
}
