using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace COP2001
{
	internal partial class OldfrmMeasureAddCritSetup : Form
	{

		private string is_Measure;
		private object ii_MeasureID;
		private int ii_MeasureSetID;
		private string is_CritType;
		private string is_RowCount;
		private modGlobal.SelectedMeasureField[] is_Selected;

		public void setRowCount(string RowCount)
		{
			is_RowCount = RowCount;
		}

		public void setCritType(string CritType)
		{
			//Reg for regular flowchart criteria
			//Filter for filter criteria
			//Risk for risk criteria
			is_CritType = CritType;
		}

		public void setMeasure(string Measure)
		{
			is_Measure = Measure;
		}

		public void SetMeasureID(ref int MeasureID)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object ii_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ii_MeasureID = MeasureID;
		}

		public void setMeasureSetID(ref int MeasureSetID)
		{
			ii_MeasureSetID = MeasureSetID;
		}

		private void cboOpt1ValueList_Click()
		{
			txtOpt1TypeinValue.Text = "";
		}
        //UPGRADE_WARNING: Event cboDestField.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboDestField_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (cboDestField.SelectedIndex > -1)
            {
                txtOpt1TypeinValue.Text = "";
                chkBlank.CheckState = CheckState.Unchecked;
            }
        }

        //UPGRADE_WARNING: Event cboSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshSetDef();
		}

//UPGRADE_WARNING: Event cboStep.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboStep_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (is_CritType == "Reg" | is_CritType == "Risk") {
				RefreshSetList();
				RefreshCat();
			}
		}

//UPGRADE_WARNING: Event chkBlank.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkBlank_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (chkBlank.CheckState == CheckState.IsChecked) {
				txtOpt1TypeinValue.Text = "";
				cboDestField.SelectedIndex = -1;
			}

		}


		private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			if (TabFirstField.SelectedIndex == 0) {
				if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled == false & sstabOptions4.Enabled == false & sstabOptions5.Enabled == false & sstabOptions6.Enabled == false) {
					RadMessageBox.Show("Please select a method.");
					return;
				}

				if (lstFieldList.SelectedIndex < 0) {
					RadMessageBox.Show("Please select field(s) from the list");
					return;
				}
			}

			if (string.IsNullOrEmpty(cboCat.Text) & string.IsNullOrEmpty(txtGoToStep.Text) & (is_CritType == "Reg" | is_CritType == "Risk")) {
				RadMessageBox.Show("Please select a Category to Assign to this set, or define a step that it will jump to.");
				return;
			}

			if (string.IsNullOrEmpty(cboStep.Text)) {
				RadMessageBox.Show("Please select the Criteria Set.");
				return;
			}

			if (string.IsNullOrEmpty(cboSet.Text)) {
				RadMessageBox.Show("Please select the Criteria Set.");
				return;
			}

			if (string.IsNullOrEmpty(Strings.Trim(cboJoinOperator.Text))) {
				RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			if (TabFirstField.SelectedIndex == 1) {
				if (lstGroupList.SelectedIndex < 0) {
					RadMessageBox.Show("Please select a group from the list");
					return;
				}
				AddCriteriaWithGroupLogic();
			} else {

				if (sstabOptions1.Enabled == true) {
					AddCriteriaWithMethod1();
				} else if (sstabOptions2.Enabled == true) {
					AddCriteriaWithMethod2();
				} else if (sstabOptions3.Enabled == true) {
					AddCriteriaWithMethod3();
				} else if (sstabOptions4.Enabled == true) {
					AddCriteriaWithMethod4();
				} else if (sstabOptions5.Enabled == true) {
					AddCriteriaWithMethod5();
				} else if (sstabOptions6.Enabled == true) {
					AddCriteriaWithMethod6();
				}
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		private void cmdAddVal_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string ls_add = null;
			DataSet  rsIsValid = null;
			EditCat:

			ls_add = RadInputBox.Show("Enter a valid month value.", "Add Values", "");

			if (Strings.Len(ls_add) == 0)
				return;

			 // ERROR: Not supported in C#: OnErrorStatement

			modGlobal.gv_sql = "SELECT MONTH('" + ls_add + "/1/2000')";
			rsIsValid = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (rsIsValid.EOF) {
				RadMessageBox.Show("Please Enter A Valid Month", MsgBoxStyle.Critical, "Invalid Month");
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

		private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstRange.SelectedIndex < 0) {
				return;
			}

			lstRange.Items.RemoveAt((lstRange.SelectedIndex));
		}

		private void frmMeasureAddCritSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
            this.CenterToParent();

			sstabOptions.SelectedIndex = 0;
			sstabOptions1.Enabled = false;
			sstabOptions2.Enabled = false;
			sstabOptions3.Enabled = false;
			sstabOptions4.Enabled = false;
			Opt1Method.IsChecked = false;
			Opt2Method.IsChecked = false;
			Opt3Method.IsChecked = false;
			Opt4Method.IsChecked = false;

			lblColName.Text = "Setting up criteria for " + is_Measure;

			is_Selected = new SelectedMeasureField[1];

			RefreshFieldsList();
			RefreshMeasureGroupLogic();

			RefreshLookupTables();
			if (is_CritType == "Reg" | is_CritType == "Risk")
				RefreshCatList();
			RefreshStepList();

			if (is_CritType == "Filter") {
				cboSet.Visible = false;
				lblSet.Visible = false;
				lblCat.Visible = false;
				txtGoToStep.Visible = false;
				cboCat.Visible = false;
			} else if (is_CritType == "Reg") {
				cboSet.Visible = true;
				lblSet.Visible = true;
				lblCat.Visible = true;
				txtGoToStep.Visible = true;
				cboCat.Visible = true;
			} else if (is_CritType == "Risk") {
				cboSet.Visible = true;
				lblSet.Visible = true;
				lblCat.Visible = true;
				txtGoToStep.Visible = true;
				cboCat.Visible = true;
			}
		}

		private void RefreshCatList(string CatID = "")
		{
			int li_SELcatID = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			li_SELcatID = -1;
			modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT ";

			if (is_CritType == "Reg") {
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'CI'";
			} else if (is_CritType == "Risk") {
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'RA' ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY CAT";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboCat.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboCat.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["CAT"].Value, modGlobal.gv_rs.rdoColumns["measure_catid"].Value));
				if (!string.IsNullOrEmpty(CatID))
					if (modGlobal.gv_rs.rdoColumns["measure_catid"].Value == Convert.ToInt16(CatID)) {
						//UPGRADE_ISSUE: ComboBox property cboCat.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
						li_SELcatID = cboCat.Items.Count-1;
					}
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

			cboCat.SelectedIndex = li_SELcatID;

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
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE (ParentDDID IS NULL OR ParentDDID = DDID)";

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
			while (!modGlobal.gv_rs.EOF) {
				lstFieldList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

			return;
			ErrHandler:
			modGlobal.CheckForErrors();

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
//
//    While Not gv_rs.EOF
//        cboLookupValues.AddItem gv_rs!BaseTable & " - (" & gv_rs!Id & ") " & gv_rs!FIELDVALUE
//        cboLookupValues.ItemData(cboLookupValues.NewIndex) = gv_rs!LookupID
//        gv_rs.MoveNext
//    Wend
//    gv_rs.Close
//
//Exit Sub
//ErrHandler:
//    CheckForErrors
//End Sub

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

				//LDW modGlobal.gv_rs.MoveNext();
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}


		private void RefreshStepList()
		{
			int li_step = 0;

			 // ERROR: Not supported in C#: OnErrorStatement

			cboStep.Items.Clear();

			if (is_CritType == "Reg" | is_CritType == "Risk") {
				//UPGRADE_ISSUE: ComboBox property cboStep.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				cboStep.Locked = false;
				modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep " + " FROM tbl_setup_MeasureStep ms left join tbl_MEASURE_CAT mc" + " on mc.MEASURE_CATID = ms.MEASURE_CATID  WHERE  0 = 0 ";

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Convert.ToInt16(is_RowCount) == 0 | Information.IsDBNull(ii_MeasureID)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureID = -1";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object ii_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureID = " + ii_MeasureID;
				}

				if (is_CritType == "Reg") {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'CI' or CAT_TYPE is null)";
				} else if (is_CritType == "Risk") {
					modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
				}

				modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100";

				modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep";

				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				//Display the list of criteria
				while (!modGlobal.gv_rs.EOF) {
					li_step = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
					cboStep.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Step " + li_step, li_step));
					//LDW modGlobal.gv_rs.MoveNext();
				}
				modGlobal.gv_rs.Dispose();

				//always add a new one to the list in addition to the previous ones
				cboStep.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Step " + li_step + 1, li_step + 1));
			} else if (is_CritType == "Filter") {
				cboStep.Items.Add("Filter");
				//filter is step -100
				//UPGRADE_ISSUE: ComboBox property cboStep.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboStep, cboStep.Items.Count-1, -100);
				cboStep.SelectedIndex = 0;
				//UPGRADE_ISSUE: ComboBox property cboStep.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				cboStep.Locked = true;
			}

			RefreshSetList();

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}


		private void RefreshSetList()
		{
			object li_cnt = null;
			int li_Sets = 0;

			 // ERROR: Not supported in C#: OnErrorStatement

			cboSet.Items.Clear();

			if (is_CritType == "Reg" | is_CritType == "Risk") {
				//UPGRADE_ISSUE: ComboBox property cboSet.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				cboSet.Locked = false;

				if (cboStep.SelectedIndex > -1) {
					modGlobal.gv_sql = "SELECT DISTINCT mcs.MeasureCriteriaSet " + " FROM tbl_setup_MeasureCriteriaSet mcs inner join  tbl_Setup_MeasureStep ms" + " on  mcs.MeasureStepID = ms.MeasureStepID " + " left join tbl_MEASURE_CAT mc" + " on mc.MEASURE_CATID = ms.MEASURE_CATID  " + " Where ms.MeasureStep = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex) + " and MeasureStep <> -100";

					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Convert.ToInt16(is_RowCount) == 0 | Information.IsDBNull(ii_MeasureID)) {
						modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureID = -1";
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object ii_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureID = " + ii_MeasureID;
					}

					if (is_CritType == "Reg") {
						modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'CI' or CAT_TYPE is null)";
					} else if (is_CritType == "Risk") {
						modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
					}

					modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureCriteriaSet";

					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					li_Sets = modGlobal.gv_rs.RowCount;
					modGlobal.gv_rs.Dispose();
				}
			} else if (is_CritType == "Filter") {
				//UPGRADE_ISSUE: ComboBox property cboSet.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				cboSet.Locked = true;
			}

			//Display the list of criteria
			for (li_cnt = 1; li_cnt <= li_Sets + 1; li_cnt++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + li_cnt, li_cnt));
			}

			if (is_CritType == "Filter") {
				cboSet.SelectedIndex = 0;
			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

		private void RefreshSetDef()
		{
			 // ERROR: Not supported in C#: OnErrorStatement



			if (cboSet.SelectedIndex < 0) {
				return;
			} else if (cboStep.SelectedIndex < 0) {
				RadMessageBox.Show("Please Choose a Step #");
			}

			//get join operator for criteria (if avail)
			//UPGRADE_WARNING: Couldn't resolve default property of object ii_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "Select mc.JoinOperator from tbl_setup_MeasureCriteriaSet mcs, " + " tbl_Setup_MeasureStep ms, tbl_Setup_MeasureCriteria mc WHERE " + " ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID " + " AND ms.MeasureStep = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex) + " AND ms.MeasureID = " + ii_MeasureID + " AND mcs.MeasureCriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);

			if (is_CritType == "Reg") {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.Measure_CATID in (SELECT MEASURE_CATID FROM " + " tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')";
			} else if (is_CritType == "Risk") {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (ms.Measure_CATID in (SELECT MEASURE_CATID FROM " + " tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA') OR IsRisk = 1)";
			}

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				cboJoinOperator.Text = "";
				cboJoinOperator.Enabled = true;
			} else {
				cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				cboJoinOperator.Enabled = false;
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
					//LDW modGlobal.gv_rs.MoveNext();
				}
			} else if (Opt2Method.IsChecked == true) {
				Opt1Method.IsChecked = true;
			}
			modGlobal.gv_rs.Dispose();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}




		private void RefreshCriteriaFieldList()
		{
			string field1type = null;
			int ParentDDID = 0;


			 // ERROR: Not supported in C#: OnErrorStatement


			//find the field type
			modGlobal.gv_sql = "Select FieldType, ParentDDID from tbl_setup_Datadef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			frmMultSel.Visible = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ParentDDID"].Value) ? false : (modGlobal.gv_rs.rdoColumns["ParentDDID"].Value > 0 ? true : false));

			modGlobal.gv_rs.Dispose();

			if (field1type == "Date/Time" | field1type == "Time") {
				field1type = "Date/Time' OR tbl_setup_Datadef.fieldtype = 'Time";
			}

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
			modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.fieldtype = '" + field1type + "' ) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid <> " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboField2List.Items.Clear();
			cboDestField.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

				cboDestField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}


		private void AddCriteriaWithMethod1()
		{
			string field1type = null;
			string CritTitle = null;
			//Dim li_order As Long
			int li_CriteriaSetID = 0;
			int li_cnt = 0;
			string ls_Dest = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt1ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the field operation from the list");
				return;
			}

			if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & chkBlank.CheckState == 0 & cboDestField.SelectedIndex < 0) {
				RadMessageBox.Show("Define a value, blank, or another field for this criteria type.");
				return;
			}

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++) {
				if (lstFieldList.GetSelected(li_cnt)) {

					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Dispose();

					//make sure that the typed value is of the same type as the field type
					if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {


						//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD") {
							RadMessageBox.Show(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " is a numeric field, but the value is not a number. Please re-Specify...");
							return;
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD") {
							//this is OK
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text)) {
								RadMessageBox.Show(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " is a date field, but the value is not a date. Please re-Specify...");
								return;
							}
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5)) {
								RadMessageBox.Show(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
								return;
							}
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1))))) {
								RadMessageBox.Show(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
								return;
							}
							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59)) {
								RadMessageBox.Show(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
								return;
							}
						}
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_Action = "Add";

					CritTitle = (frmMultSel.Visible ? "(" + (OptMultAny.IsChecked ? "ANY" : "ALL") + ") " : "");

					CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " " + cboOpt1ValueOperator.Text;
					if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
						CritTitle = CritTitle + " " + txtOpt1TypeinValue.Text;
					}
					if (chkBlank.CheckState == CheckState.IsChecked) {
						CritTitle = CritTitle + " " + "Blank";
					}

					if (string.IsNullOrEmpty(ls_Dest)) {
						ls_Dest = cboDestField.Text;
					}
					if (Strings.Len(ls_Dest) > 0) {
						CritTitle = CritTitle + " " + ls_Dest;
					}

					li_CriteriaSetID = InsertStepandSetRecords();

					modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + "(MeasureCriteriaSetID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MultSelAny) ";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";

					if (cboDestField.SelectedIndex > -1) {
						modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestField, cboDestField.SelectedIndex) + ", ";
					} else {
						modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
					}

					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt1ValueOperator.Text + "', ";

					if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text)) {
						modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt1TypeinValue.Text + "',";
					} else if (cboDestField.SelectedIndex > -1) {
						modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
					} else {
						modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
					}

					modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";

					modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + (frmMultSel.Visible ? (OptMultAny.IsChecked ? 1 : 0) : "NULL") + " )";

					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					lstFieldList.SetSelected(li_cnt, false);
				}
			}
			//end loop

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
			//Dim li_order As Long
			object li_CriteriaSetID = null;
			int li_cnt = 0;
			int lL_LookupVal = 0;
			string ls_LookupTxt = null;
			short Index = 0;

			DataSet  rs_Temp = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			Index = 0;


			if (cboOpt2ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the field operation from the list");
				return;
			}

			fieldLookupTableID = " Null ";
			if (cboLookupValues.SelectedIndex < 0) {
				RadMessageBox.Show("Select lookup value from list.");
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

				modGlobal.gv_rs.Dispose();
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			ls_LookupTxt = cboLookupValues.Text;
			lL_LookupVal = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++) {
				if (lstFieldList.GetSelected(li_cnt)) {

					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Dispose();

					//make sure that the field type is not a date field
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(field1type, 1, 3) == "Dat") {
						RadMessageBox.Show("You cannot compare this field to a lookup value, because " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " is a date field. Please re-Specify...");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_Action = "Add";

					CritTitle = (frmMultSel.Visible ? "(" + (OptMultAny.IsChecked ? "ANY" : "ALL") + ") " : "");

					CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " " + cboOpt2ValueOperator.Text + " " + ls_LookupTxt;

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CriteriaSetID = InsertStepandSetRecords();

					modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MultSelAny)";

					modGlobal.gv_sql = modGlobal.gv_sql + " values (";

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt2ValueOperator.Text + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + IDFromLookup + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + lL_LookupVal + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
					modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
					modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + (frmMultSel.Visible ? (OptMultAny.IsChecked ? 1 : 0) : "NULL") + " )";

					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					lstFieldList.SetSelected(li_cnt, false);
				}
			}

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
			//Dim li_order As Long
			object li_CriteriaSetID = null;
			int li_cnt = 0;


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


			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++) {
				if (lstFieldList.GetSelected(li_cnt)) {
					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Dispose();

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

							//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (field1type != "Date/Time" & field1type != "Time") {
								RadMessageBox.Show("The 2 fields that you have selected are not of the same type. Please re-specify...");
								return;
							}

						}
					}


					//make sure that the typed value is numeric
					if (!Information.IsNumeric(txtOpt3TypeinValue.Text)) {
						RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type == "Date") {
						if (string.IsNullOrEmpty(cboOpt3Unit.Text)) {
							RadMessageBox.Show("Please define a date unit associated with the value");
							return;
						} else if (cboOpt3Unit.Text != "Years" & cboOpt3Unit.Text != "Months" & cboOpt3Unit.Text != "Days") {
							RadMessageBox.Show("Please define the appropriate date unit associated with the value");
							return;
						}

					}

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type == "Time") {
						if (string.IsNullOrEmpty(cboOpt3Unit.Text)) {
							RadMessageBox.Show("Please define a time unit associated with the value");
							return;
						} else if (cboOpt3Unit.Text != "Hours" & cboOpt3Unit.Text != "Minutes" & cboOpt3Unit.Text != "Seconds") {
							RadMessageBox.Show("Please define the appropriate time unit associated with the value");
							return;
						}
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type == "Time" & !Information.IsNumeric(txtOpt3TypeinValue.Text)) {
						RadMessageBox.Show("Please define a numeric value for this Time difference. Duration will be in minutes  ");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_Action = "Add";



					CritTitle = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt);
					CritTitle = CritTitle + " " + cboFieldOperator.Text + " " + cboField2List.Text;
					CritTitle = CritTitle + " " + cboOpt3ValueOperator.Text;
					CritTitle = CritTitle + " " + txtOpt3TypeinValue.Text;
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type == "Date" | field1type == "Time" | field1type == "Date/Time") {
						CritTitle = CritTitle + " " + cboOpt3Unit.Text;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CriteriaSetID = InsertStepandSetRecords();

					modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, LookupID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, FieldOperator, DateUnit, JoinOperator)";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt3ValueOperator.Text + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3TypeinValue.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2List, cboField2List.SelectedIndex) + ", ";
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
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "')";

					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					//lstFieldList.Selected(li_cnt) = False
				}
			}

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
			//Dim li_order As Long
			object li_CriteriaSetID = null;
			object li_cnt = null;
			int li_cnt2 = 0;
			string[] ls_months = null;


			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpt5ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the field operation from the list.");
				return;
			}

			if (lstRange.Items.Count == 0) {
				RadMessageBox.Show("Value(s) should be typed in.");
				return;
			}

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++) {
				if (lstFieldList.GetSelected(li_cnt)) {
					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Dispose();
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (field1type != "Date") {
						RadMessageBox.Show("This method is only valid with date fields", MsgBoxStyle.Critical, "Field is not a date");
						return;
					}

					for (li_cnt2 = 0; li_cnt2 <= lstRange.Items.Count - 1; li_cnt2++) {
						Array.Resize(ref ls_months, li_cnt2 + 1);
						ls_months[li_cnt2] = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstRange, li_cnt2);
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_Action = "Add";

					CritTitle = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt);
					CritTitle = CritTitle + " Month " + cboOpt5ValueOperator.Text;
					CritTitle = CritTitle + " (" + Strings.Join(ls_months, ",") + ")";

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CriteriaSetID = InsertStepandSetRecords();

					modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, CriteriaTitle,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, DateUnit, JoinOperator)";
					modGlobal.gv_sql = modGlobal.gv_sql + " values (";
					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt5ValueOperator.Text + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '(" + Strings.Join(ls_months, ",") + ")',";
					modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "')";

					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					lstFieldList.SetSelected(li_cnt, false);
				}
			}

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}


		private void AddCriteriaWithMethod6()
		{
			object field1type = null;
			object Field2Type = null;
			string CritTitle = null;
			//Dim li_order As Long
			object li_CriteriaSetID = null;
			int li_cnt = 0;
			string[] GroupIDs = null;
			int li_group = 0;

			 // ERROR: Not supported in C#: OnErrorStatement



			if (chkBlank6.CheckState == CheckState.IsChecked & cboOpt6ValueOperator.SelectedIndex < 0) {
				RadMessageBox.Show("Please choose an operator for Blank Comparison");
				return;
			}

			li_group = 0;
			GroupIDs = new string[li_group + 1];

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++) {
				if (lstFieldList.GetSelected(li_cnt)) {
					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
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

					//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_Action = "Add";

					CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + ",";

					Array.Resize(ref GroupIDs, li_group + 1);
					GroupIDs[li_group] = Convert.ToString(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt));
					li_group = li_group + 1;
				}
			}

			CritTitle = Strings.Mid(CritTitle, 1, Strings.Len(CritTitle) - 1);

			//if the criteria is really long, trim it so it can fit in the 200 char field
			if (Strings.Len(CritTitle) > 190)
				CritTitle = Strings.Mid(CritTitle, 1, 190);

			CritTitle = CritTitle + ") " + cboOpt6ValueOperator.Text + " BLANK";

			if (Information.UBound(GroupIDs) < 1) {
				RadMessageBox.Show("You must select more than one field to determine the earliest.");
				return;
			}
			//Debug.Print CritTitle

			//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_CriteriaSetID = InsertStepandSetRecords();

			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, CriteriaTitle,";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, FieldOperator, DateUnit, JoinOperator)";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Null, ";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboOpt6ValueOperator.Text + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + Strings.Join(GroupIDs, ",") + "',";
			modGlobal.gv_sql = modGlobal.gv_sql + "NULL, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " null,";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "')";
			//Debug.Print gv_sql

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}

//UPGRADE_WARNING: Event lstFieldList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstFieldList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshLookupListForThisField();
			RefreshCriteriaFieldList();
			RefreshSelectedField();

			//CompareSelectedFields
		}


//UPGRADE_WARNING: Event Opt1Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
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
					sstabOptions6.Enabled = false;
					sstabOptions.SelectedIndex = 0;
					ChangeNote(true);
				}
			}
		}

		private void ChangeNote(ref bool Normal)
		{

			if (Normal) {
				lblNote.Text = "Note: If you are defining the interval between 2 date fields, select the earliest date field from the above list";
			} else {
				lblNote.Text = "Note:  Please select the grouped dates/times from the field list.  Also, remember to use a time field in the same set as the next criteria entered.";
			}

		}

//UPGRADE_WARNING: Event Opt2Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
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
					sstabOptions6.Enabled = false;
					sstabOptions.SelectedIndex = 1;
					ChangeNote(true);

				}
			}
		}

//UPGRADE_WARNING: Event Opt3Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
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
					sstabOptions6.Enabled = false;
					sstabOptions.SelectedIndex = 2;
					ChangeNote(true);

				}
			}
		}

//UPGRADE_WARNING: Event Opt4Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
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
					sstabOptions6.Enabled = false;
					sstabOptions.SelectedIndex = 3;
					ChangeNote(true);

				}

			}
		}

//UPGRADE_WARNING: Event Opt5Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt5Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {
				if (Opt5Method.IsChecked == true) {
					sstabOptions.Enabled = true;
					sstabOptions1.Enabled = false;
					sstabOptions2.Enabled = false;
					sstabOptions3.Enabled = false;
					sstabOptions4.Enabled = false;
					sstabOptions5.Enabled = true;
					sstabOptions6.Enabled = false;
					sstabOptions.SelectedIndex = 4;
					ChangeNote(true);

				}
			}
		}

//UPGRADE_WARNING: Event Opt6Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void Opt6Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (eventSender.IsChecked) {
				sstabOptions.Enabled = true;
				sstabOptions1.Enabled = false;
				sstabOptions2.Enabled = false;
				sstabOptions3.Enabled = false;
				sstabOptions4.Enabled = false;
				sstabOptions5.Enabled = false;
				sstabOptions6.Enabled = true;
				sstabOptions.SelectedIndex = 5;
				cboOpt6ValueOperator.SelectedIndex = 0;
				ChangeNote(ref false);
			}
		}

        //UPGRADE_WARNING: Event txtOpt1TypeinValue.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void txtOpt1TypeinValue_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
            {
                chkBlank.CheckState = CheckState.Unchecked;
                cboDestField.SelectedIndex = -1;
            }
        }



        private void AddCriteriaWithMethod3()
		{
			object field1type = null;
			string CritTitle = null;
			object li_CriteriaSetID = null;
			int li_cnt = 0;
			string ls_LookupTxt = null;
			int li_LookupVal = 0;


			 // ERROR: Not supported in C#: OnErrorStatement


			if (cboOpLkTable.SelectedIndex < 0) {
				RadMessageBox.Show("Please select the field operation from the list");
				return;
			}

			if (cboLookupTables.SelectedIndex < 0) {
				RadMessageBox.Show("Select lookup table from list.");
				return;
			}

			if (string.IsNullOrEmpty(cboJoinOperator.Text)) {
				RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
				return;
			}

			ls_LookupTxt = cboLookupTables.Text;
			li_LookupVal = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex);

			//Loop for each selected field
			for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++) {
				if (lstFieldList.GetSelected(li_cnt)) {

					//find the field type
					modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
					modGlobal.gv_rs.Dispose();

					//make sure that the field type is not a date field
					//UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(field1type, 1, 3) == "Dat") {
						RadMessageBox.Show("You cannot compare " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " to a lookup table, because the selected field is a date field. Please re-Specify...");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_Action = "Add";

					CritTitle = (frmMultSel.Visible ? "(" + (OptMultAny.IsChecked ? "ANY" : "ALL") + ") " : "");
					CritTitle = CritTitle + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " " + cboOpLkTable.Text + " [" + ls_LookupTxt + "] Lookup Table ";

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CriteriaSetID = InsertStepandSetRecords();

					modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MultSelAny)";

					modGlobal.gv_sql = modGlobal.gv_sql + " values (";

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt) + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpLkTable.Text + "', ";
					modGlobal.gv_sql = modGlobal.gv_sql + li_LookupVal + ", ";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + (frmMultSel.Visible ? (OptMultAny.IsChecked ? 1 : 0) : "NULL") + " )";

					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
					lstFieldList.SetSelected(li_cnt, false);

				}
			}

			this.Close();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}


		private int InsertStepandSetRecords()
		{
			int functionReturnValue = 0;
			object li_StepID = null;
			int li_SetID = 0;
			string ls_DefJoin = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "SELECT * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object ii_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureID = " + ii_MeasureID;
			modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);
			if (is_CritType == "Reg") {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE is null or CAT_TYPE = 'CI') ";
			} else if (is_CritType == "Risk") {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
			}
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);


			//gv_sql = "SELECT * FROM tbl_Setup_MeasureStep WHERE MeasureID = " & _
			//'    ii_MeasureID & " AND MeasureStep = " & cboStep.ItemData(cboStep.ListIndex)
			//
			//If is_CritType = "Risk" Then
			//    gv_sql = gv_sql & " AND Measure_CATID in (SELECT MEASURE_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')"
			//ElseIf is_CritType = "Reg" Then
			//    gv_sql = gv_sql & " AND Measure_CATID in (SELECT MEASURE_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')"
			//End If


			if (modGlobal.gv_rs.EOF) {

				modGlobal.gv_sql = "SELECT * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep  ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

				modGlobal.gv_rs.AddNew();
				//UPGRADE_WARNING: Couldn't resolve default property of object ii_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_rs.rdoColumns["MeasureID"].Value = ii_MeasureID;
				modGlobal.gv_rs.rdoColumns["measurestep"].Value = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);

				//Filters do not get assigned to a category
				//is_CritType = "Reg" Or is_CritType = "Risk" Then
				if (cboCat.SelectedIndex > -1 & string.IsNullOrEmpty(txtGoToStep.Text)) {
					modGlobal.gv_rs.rdoColumns["measure_catid"].Value = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboCat, cboCat.SelectedIndex);
				}

				if (!string.IsNullOrEmpty(txtGoToStep.Text)) {
					modGlobal.gv_rs.rdoColumns["GoToStep"].Value = txtGoToStep.Text;
				}

				if (is_CritType == "Risk") {
					modGlobal.gv_rs.rdoColumns["isrisk"].Value = 1;
				} else {
					modGlobal.gv_rs.rdoColumns["isrisk"].Value = 0;
				}

				modGlobal.gv_rs.Update();
				modGlobal.gv_rs.Dispose();

				//UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_StepID = modGlobal.GetLastID(ref "tbl_Setup_MeasureStep");
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_StepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				modGlobal.gv_rs.Dispose();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet " + " WHERE MeasureStepID = " + li_StepID + " AND MeasureCriteriaSet = " + (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex) - 1);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (!modGlobal.gv_rs.EOF) {
				ls_DefJoin = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
			} else {
				ls_DefJoin = "AND";
			}
			modGlobal.gv_rs.Dispose();

			//UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet " + " WHERE MeasureStepID = " + li_StepID + " AND MeasureCriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

			if (modGlobal.gv_rs.EOF) {
				//default join to AND
				modGlobal.gv_rs.AddNew();
				modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value = li_StepID;
				modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = ls_DefJoin;
				modGlobal.gv_rs.Update();
				modGlobal.gv_rs.Dispose();

				li_SetID = modGlobal.GetLastID(ref "tbl_Setup_MeasureCriteriaSet");
			} else {
				li_SetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
				modGlobal.gv_rs.Dispose();
			}

			functionReturnValue = li_SetID;
			return functionReturnValue;
			ErrHandler:

			modGlobal.CheckForErrors();
			return functionReturnValue;
		}

		private void RefreshCat()
		{
			string ls_catID = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "Select ms.Measure_CatID, ms.GotoStep ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureStep as ms left join tbl_MEASURE_CAT as mc  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID  WHERE  0 = 0 ";

			if (Convert.ToInt16(is_RowCount) == 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureID = -1";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object ii_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureID = " + ii_MeasureID;
			}

			if (cboStep.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and ms.MeasureStep = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " and ms.MeasureStep = -1";
			}

			if (is_CritType == "Reg") {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (mc.CAT_TYPE = 'CI' or mc.CAT_Type is null)";
			} else if (is_CritType == "Risk") {
				modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
			}
			//gv_g = InputBox("", "", gv_sql)
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				//if the gotostep is assigned, there won't be any category assigend
				//gv_sql = "Select GotoStep from tbl_Setup_MeasureStep "
				//If CInt(is_RowCount) = 0 Then
				//    gv_sql = gv_sql & " WHERE MeasureID = -1"
				//Else
				//    gv_sql = gv_sql & " WHERE MeasureID = " & ii_MeasureID
				//End If
				//Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
				//If gv_rs.RowCount = 0 Then
				txtGoToStep.Text = "";
				txtGoToStep.Enabled = true;
				cboCat.Enabled = true;
				cboCat.SelectedIndex = -1;

				//Else
				//            If IsNull(gv_rs!GoToStep) Then 'it means that this is a new step without any category or gotostep assignment
				//                cboCat.Enabled = True
				//                txtGoToStep.Enabled = True
				//                txtGoToStep = ""
				//                cboCat.ListIndex = -1
				//                RefreshCatList
				//            Else
				//                txtGoToStep = gv_rs!GoToStep
				//                txtGoToStep.Enabled = False
				//                cboCat.Enabled = False
				//                cboCat.ListIndex = -1
				//
				//            End If
				//        End If
			} else {

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["measure_catid"].Value)) {
					ls_catID = modGlobal.gv_rs.rdoColumns["measure_catid"].Value;
					cboCat.Enabled = false;
					RefreshCatList(ref (ls_catID));
					txtGoToStep.Enabled = false;
					txtGoToStep.Text = "";


					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				} else if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["GoToStep"].Value)) {
					txtGoToStep.Text = modGlobal.gv_rs.rdoColumns["GoToStep"].Value;
					txtGoToStep.Enabled = false;
					cboCat.Enabled = false;
					cboCat.SelectedIndex = -1;


				//it means that this is a new step without any category or gotostep assignment
				} else {
					cboCat.Enabled = true;
					txtGoToStep.Enabled = true;
					txtGoToStep.Text = "";
					cboCat.SelectedIndex = -1;
					RefreshCatList();


				}

				//txtGoToStep.Enabled = False
				//txtGoToStep = ""


			}

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}




		private void RefreshSelectedField()
		{
			string ls_FieldType = null;
			int li_SelCount = 0;
			bool lb_CanSave = false;
			int li_found = 0;

			lb_CanSave = false;

			object li_cnt = null;
			int li_cnt2 = 0;
			if (lstFieldList.SelectedItems.Count == 0) {
				is_Selected = new SelectedMeasureField[1];
			} else {

				if (lstFieldList.SelectedItems.Count == 1 & (Information.UBound(is_Selected) == 1 | Information.UBound(is_Selected) > 1)) {
					is_Selected = new SelectedMeasureField[1];
				}

				for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++) {
					if (lstFieldList.GetSelected(li_cnt)) {
						li_found = 0;
						li_SelCount = Information.UBound(is_Selected);

						if (li_SelCount != 0) {
							for (li_cnt2 = 1; li_cnt2 <= Information.UBound(is_Selected); li_cnt2++) {
								if (is_Selected[li_cnt2].DDID == Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt)) {
									li_found = 1;
									break; // TODO: might not be correct. Was : Exit For
								}
							}
						}

						if (li_found == 0) {

							//get the field types
							modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
							modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
							modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
							ls_FieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
							modGlobal.gv_rs.Dispose();

							if (li_SelCount > 0) {
								if (is_Selected[li_SelCount].FieldType != ls_FieldType) {
									RadMessageBox.Show("The data type of " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt) + " and " + is_Selected[li_SelCount].Description + " are not the same.", MsgBoxStyle.Critical, "Cannot Compare Different Data Types");
									lstFieldList.SetSelected(li_cnt, false);

									lb_CanSave = false;
								} else {
									lb_CanSave = true;
								}
							} else {
								lb_CanSave = true;
							}

							if (lb_CanSave) {
								Array.Resize(ref is_Selected, li_SelCount + 2);
								is_Selected[li_SelCount + 1].DDID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, li_cnt);
								is_Selected[li_SelCount + 1].Description = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstFieldList, li_cnt);
								is_Selected[li_SelCount + 1].FieldType = ls_FieldType;
							}

						}
					}
				}
			}
		}

		private void AddCriteriaWithGroupLogic()
		{
			int li_cnt = 0;
			string CritTitle = null;
			int li_CriteriaSetID = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "Add";

			li_cnt = lstGroupList.SelectedIndex;

			modGlobal.gv_sql = "SELECT CriteriaTitle FROM tbl_Setup_MeasureFieldGroupLogic WHERE MeasureFieldGroupLogicID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			CritTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
			modGlobal.gv_rs.Dispose();

			li_CriteriaSetID = InsertStepandSetRecords();

			modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + "(MeasureCriteriaSetID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, MeasureFieldGroupLogicID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " values (";
			modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
			modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstGroupList, li_cnt) + ", ";
			modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "')";

			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			this.Close();

			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}

		private void RefreshMeasureGroupLogic()
		{
			lstGroupList.Items.Clear();

			modGlobal.gv_sql = "SELECT CriteriaTitle, MeasureFieldGroupLogicID FROM tbl_Setup_MeasureFieldGroupLogic ORDER BY CriteriaTitle";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				lstGroupList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value, modGlobal.gv_rs.rdoColumns["measurefieldgrouplogicid"].Value));

				//LDW modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Dispose();

		}
	}
}
