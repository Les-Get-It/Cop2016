using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Compatibility.VB6;
// ERROR: Not supported in C#: OptionDeclaration

namespace COP2001
{
    internal partial class OldfrmMeasureAddCritSubmitSubsSetup : System.Windows.Forms.Form
    {

        private string is_Measure;
        private object ii_MeasureID;
        private int ii_MeasureSetID;
        private string is_CritType;
        private string is_RowCount;
        private modGlobal.SelectedMeasureField[] is_Selected;
        object MeasureStepID;

        public void setRowCount(ref string RowCount)
        {
            is_RowCount = RowCount;
        }

        public void setCritType(ref string CritType)
        {
            //Reg for regular flowchart criteria
            //Filter for filter criteria
            //Risk for risk criteria
            is_CritType = CritType;
        }

        public void setMeasure(ref string Measure)
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
        public void setMeasureStepID(ref object MSID)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object MSID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MeasureStepID = MSID;
            RefreshSetList();
        }

        //UPGRADE_WARNING: Event cboDestField.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboDestField_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (cboDestField.SelectedIndex > -1)
            {
                txtOpt1TypeinValue.Text = "";
                chkBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;
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

            if (chkBlank.CheckState == CheckState.Checked)
            {
                txtOpt1TypeinValue.Text = "";
                cboDestField.SelectedIndex = -1;
            }

        }


        private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //On Error GoTo ErrHandler

            if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled == false & sstabOptions4.Enabled == false & sstabOptions5.Enabled == false & sstabOptions6.Enabled == false)
            {
                RadMessageBox.Show("Please select a method.");
                return;
            }

            if (lstFieldList.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select field(s) from the list");
                return;
            }

            if (string.IsNullOrEmpty(cboSet.Text))
            {
                RadMessageBox.Show("Please select the Criteria Set.");
                return;
            }

            if (string.IsNullOrEmpty(Strings.Trim(cboJoinOperator.Text)))
            {
                RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                return;
            }

            if (sstabOptions1.Enabled == true)
            {
                AddCriteriaWithMethod1();
            }
            else if (sstabOptions2.Enabled == true)
            {
                AddCriteriaWithMethod2();
            }
            else if (sstabOptions3.Enabled == true)
            {
                AddCriteriaWithMethod3();
            }
            else if (sstabOptions4.Enabled == true)
            {
                AddCriteriaWithMethod4();
            }
            else if (sstabOptions5.Enabled == true)
            {
                AddCriteriaWithMethod5();
            }
            else if (sstabOptions6.Enabled == true)
            {
                AddCriteriaWithMethod6();
            }

            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void cmdAddVal_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string ls_add = null;
            DataSet rsIsValid = null;
            EditCat:

            ls_add = Interaction.InputBox("Enter a valid month value.", "Add Values", "");

            if (Strings.Len(ls_add) == 0)
                return;

            // ERROR: Not supported in C#: OnErrorStatement

            modGlobal.gv_sql = "SELECT MONTH('" + ls_add + "/1/2000')";
            rsIsValid = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (rsIsValid.EOF)
            {
                RadMessageBox.Show("Please Enter A Valid Month", MsgBoxStyle.Critical, "Invalid Month");
                goto EditCat;
            }
            else
            {
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
            if (lstRange.SelectedIndex < 0)
            {
                return;
            }

            lstRange.Items.RemoveAt((lstRange.SelectedIndex));
        }

        private void frmMeasureAddCritSubmitSubsSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));


            sstabOptions.ActiveWindow = sstabOptions1;
            sstabOptions1.Enabled = false;
            sstabOptions2.Enabled = false;
            sstabOptions3.Enabled = false;
            sstabOptions4.Enabled = false;
            Opt1Method.Checked = false;
            Opt2Method.Checked = false;
            Opt3Method.Checked = false;
            Opt4Method.Checked = false;

            lblColName.Text = "Setting up criteria for " + is_Measure;

            is_Selected = new modGlobal.SelectedMeasureField[1];

            RefreshFieldsList();
            RefreshLookupTables();
            //If is_CritType = "Reg" Or is_CritType = "Risk" Then RefreshCatList
            //RefreshStepList

            //If is_CritType = "Filter" Then
            //    cboSet.Visible = False
            //    lblSet.Visible = False
            //    lblCat.Visible = False
            //    cboCat.Visible = False
            //ElseIf is_CritType = "Reg" Then
            cboSet.Visible = true;
            lblSet.Visible = true;
            //     lblCat.Visible = True
            //     cboCat.Visible = True
            //ElseIf is_CritType = "Risk" Then
            //    cboSet.Visible = True
            //    lblSet.Visible = True
            //    lblCat.Visible = True
            //    cboCat.Visible = True
            //End If
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
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (dd.State = '' or dd.State is Null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            lstFieldList.Items.Clear();
            cboField2List.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstFieldList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                cboField2List.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                // LDW modGlobal.gv_rs.MoveNext();
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

            while (!modGlobal.gv_rs.EOF)
            {
                cboLookupTables.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));

                // LDW modGlobal.gv_rs.MoveNext();
            }

            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }



        private void RefreshSetList()
        {
            object li_cnt = null;
            int li_Sets = 0;

            //On Error GoTo ErrHandler
            cboSet.Items.Clear();

            //UPGRADE_ISSUE: ComboBox property cboSet.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            cboSet.Locked = false;

            //UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "SELECT DISTINCT mcs.MeasureCriteriaSet " + " FROM tbl_setup_MeasureCriteriaSetSubmitSubs mcs, tbl_Setup_MeasureStepSubmitSubs ms" + " WHERE mcs.MeasureStepSubmitSubsID = ms.MeasureStepsubmitSubsID " + " AND ms.MeasureStepID = " + MeasureStepID;
            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureCriteriaSet";
            //gv_g = InputBox("", "", gv_sql)
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            li_Sets = modGlobal.gv_rs.RowCount;
            modGlobal.gv_rs.Dispose();


            //Display the list of criteria
            for (li_cnt = 1; li_cnt <= li_Sets + 1; li_cnt++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cboSet.Items.Add(new ListBoxItem("Set " + li_cnt, li_cnt));
            }


            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }

        private void RefreshSetDef()
        {
            // ERROR: Not supported in C#: OnErrorStatement



            if (cboSet.SelectedIndex < 0)
            {
                return;
            }

            //get join operator for criteria (if avail)
            //UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "Select mc.JoinOperator from tbl_setup_MeasureCriteriaSetSubmitSubs mcs, " + " tbl_Setup_MeasureStepSubmitSubs ms, tbl_Setup_MeasureCriteriaSubmitSubs mc WHERE " + " ms.MeasureStepSubmitSubsID = mcs.MeasureStepSubmitSubsID " + " AND mc.MeasureCriteriaSetSubmitSubsID = mcs.MeasureCriteriaSetSubmitSubsID " + " AND ms.MeasureStepID = " + MeasureStepID + " AND mcs.MeasureCriteriaSet = " + Support.GetItemData(cboSet, cboSet.SelectedIndex);

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount == 0)
            {
                cboJoinOperator.Text = "";
                cboJoinOperator.Enabled = true;
            }
            else
            {
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
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount > 0)
            {
                LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;

                modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + LookupTableID;
                modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                while (!modGlobal.gv_rs.EOF)
                {
                    cboLookupValues.Items.Add(new ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));
                    // LDW modGlobal.gv_rs.MoveNext();
                }
            }
            else if (Opt2Method.Checked == true)
            {
                Opt1Method.Checked = true;
            }
            modGlobal.gv_rs.Dispose();
            return;
            ErrHandler:
            modGlobal.CheckForErrors();

        }

        private void RefreshCriteriaFieldList()
        {
            string field1type = null;

            // ERROR: Not supported in C#: OnErrorStatement


            //find the field type
            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
            modGlobal.gv_rs.Dispose();

            //retrieve the list of table fields
            modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT'";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.fieldtype = '" + field1type + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid <> " + Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            cboField2List.Items.Clear();
            cboDestField.Items.Clear();

            while (!modGlobal.gv_rs.EOF)
            {
                cboField2List.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

                cboDestField.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                // LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();
            return;
            ErrHandler:
            modGlobal.CheckForErrors();
        }


        private void AddCriteriaWithMethod1()
        {
            object field1type = null;
            string CritTitle = null;
            //Dim li_order As Long
            int li_CriteriaSetID = 0;
            int li_cnt = 0;
            string ls_Dest = null;

            //On Error GoTo ErrHandler

            if (cboOpt1ValueOperator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the field operation from the list");
                return;
            }

            if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & chkBlank.CheckState == 0 & cboDestField.SelectedIndex < 0)
            {
                RadMessageBox.Show("Define a value, blank, or another field for this criteria type.");
                return;
            }

            //Loop for each selected field
            for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
            {
                if (lstFieldList.SelectedIndex == li_cnt)
                {

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                    modGlobal.gv_rs.Dispose();

                    //make sure that the typed value is of the same type as the field type
                    if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD")
                        {
                            RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a numeric field, but the value is not a number. Please re-Specify...");
                            return;
                        }

                        //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD")
                        {
                            //this is OK 2.16.2007
                        }
                        else
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text))
                            {
                                RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a date field, but the value is not a date. Please re-Specify...");
                                return;
                            }
                            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5))
                            {
                                RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                                return;
                            }
                            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1)))))
                            {
                                RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                                return;
                            }
                            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59))
                            {
                                RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                                return;
                            }
                        }
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_Action = "Add";

                    CritTitle = Support.GetItemString(lstFieldList, li_cnt) + " " + cboOpt1ValueOperator.Text;
                    if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                    {
                        CritTitle = string.Format("{0} {1}", CritTitle, txtOpt1TypeinValue.Text);
                    }
                    if (chkBlank.CheckState == CheckState.Checked)
                    {
                        CritTitle = string.Format("{0} Blank", CritTitle);
                    }

                    if (string.IsNullOrEmpty(ls_Dest))
                    {
                        ls_Dest = cboDestField.Text;
                    }
                    if (Strings.Len(ls_Dest) > 0)
                    {
                        CritTitle = string.Format("{0} {1}", CritTitle, ls_Dest);
                    }

                    li_CriteriaSetID = InsertStepandSetRecords();

                    modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "(MeasureCriteriaSetSubmitSubsID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";

                    if (cboDestField.SelectedIndex > -1)
                    {
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboDestField, cboDestField.SelectedIndex));
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                    }

                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt1ValueOperator.Text);

                    if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                    {
                        modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt1TypeinValue.Text);
                    }
                    else if (cboDestField.SelectedIndex > -1)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
                    }

                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";

                    modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                    modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, cboJoinOperator.Text);

                    modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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
            int li_LookupVal = 0;
            string ls_LookupTxt = null;
            short Index = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            Index = 0;


            if (cboOpt2ValueOperator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the field operation from the list");
                return;
            }

            fieldLookupTableID = " Null ";
            if (cboLookupValues.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select lookup value from list.");
                return;
            }
            else
            {
                modGlobal.gv_sql = "Select *   ";
                modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                modGlobal.gv_sql = string.Format("{0} Where lookupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                IDFromLookup = modGlobal.gv_rs.rdoColumns["Id"].Value;
                modGlobal.gv_rs.Dispose();
            }

            if (string.IsNullOrEmpty(cboJoinOperator.Text))
            {
                RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                return;
            }

            ls_LookupTxt = cboLookupValues.Text;
            li_LookupVal = Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);

            //Loop for each selected field
            for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
            {
                if (lstFieldList.SelectedIndex == li_cnt)
                {

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                    modGlobal.gv_rs.Dispose();

                    //make sure that the field type is not a date field
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Dat")
                    {
                        RadMessageBox.Show(string.Format("You cannot compare this field to a lookup value, because {0} is a date field. Please re-Specify...", Support.GetItemString(lstFieldList, li_cnt)));
                        return;
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_Action = "Add";

                    CritTitle = string.Format("{0} {1} {2}", Support.GetItemString(lstFieldList, li_cnt), cboOpt2ValueOperator.Text, ls_LookupTxt);

                    //UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_CriteriaSetID = InsertStepandSetRecords();

                    modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator)";

                    modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                    //UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstFieldList, li_cnt) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt2ValueOperator.Text + "', ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + IDFromLookup + "',";
                    modGlobal.gv_sql = modGlobal.gv_sql + li_LookupVal + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "')";

                    modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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


            if (cboFieldOperator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the Add/Subtract operation from the list.");
                return;
            }

            if (cboField2List.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the second Field from the list.");
                return;
            }

            if (cboOpt3ValueOperator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the field operation from the list.");
                return;
            }

            if (string.IsNullOrEmpty(txtOpt3TypeinValue.Text))
            {
                RadMessageBox.Show("A value should be typed in.");
                return;
            }

            if (string.IsNullOrEmpty(cboJoinOperator.Text))
            {
                RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                return;
            }


            //Loop for each selected field
            for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
            {
                if (lstFieldList.SelectedIndex == li_cnt)
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                    modGlobal.gv_rs.Dispose();

                    //make sure that the 2 selected fields are of the same type
                    if (!string.IsNullOrEmpty(cboField2List.Text))
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                        //UPGRADE_WARNING: Couldn't resolve default property of object Field2Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Field2Type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                        modGlobal.gv_rs.Dispose();
                        //UPGRADE_WARNING: Couldn't resolve default property of object Field2Type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (field1type != Field2Type)
                        {
                            RadMessageBox.Show("The 2 fields that you have selected are not of the same type. Please re-specify...");
                            return;
                        }
                    }


                    //make sure that the typed value is numeric
                    if (!Information.IsNumeric(txtOpt3TypeinValue.Text))
                    {
                        RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");
                        return;
                    }

                    if (field1type == "Date")
                    {
                        if (string.IsNullOrEmpty(cboOpt3Unit.Text))
                        {
                            RadMessageBox.Show("Please define a date unit associated with the value");
                            return;
                        }
                        else if (cboOpt3Unit.Text != "Years" & cboOpt3Unit.Text != "Months" & cboOpt3Unit.Text != "Days")
                        {
                            RadMessageBox.Show("Please define the appropriate date unit associated with the value");
                            return;
                        }

                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (field1type == "Time")
                    {
                        if (string.IsNullOrEmpty(cboOpt3Unit.Text))
                        {
                            RadMessageBox.Show("Please define a time unit associated with the value");
                            return;
                        }
                        else if (cboOpt3Unit.Text != "Hours" & cboOpt3Unit.Text != "Minutes" & cboOpt3Unit.Text != "Seconds")
                        {
                            RadMessageBox.Show("Please define the appropriate time unit associated with the value");
                            return;
                        }
                    }

                    if (field1type == "Time" & !Information.IsNumeric(txtOpt3TypeinValue.Text))
                    {
                        RadMessageBox.Show("Please define a numeric value for this Time difference. Duration will be in minutes  ");
                        return;
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_Action = "Add";

                    CritTitle = Support.GetItemString(lstFieldList, li_cnt);
                    CritTitle = CritTitle + " " + cboFieldOperator.Text + " " + cboField2List.Text;
                    CritTitle = CritTitle + " " + cboOpt3ValueOperator.Text;
                    CritTitle = CritTitle + " " + txtOpt3TypeinValue.Text;
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (field1type == "Date" | field1type == "Time")
                    {
                        CritTitle = CritTitle + " " + cboOpt3Unit.Text;
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_CriteriaSetID = InsertStepandSetRecords();

                    modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, CriteriaTitle,";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, FieldOperator, DateUnit, JoinOperator)";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstFieldList, li_cnt) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt3ValueOperator.Text + "', ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3TypeinValue.Text + "',";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboField2List, cboField2List.SelectedIndex) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboFieldOperator.Text + "', ";
                    if (!string.IsNullOrEmpty(cboOpt3Unit.Text))
                    {
                        switch (cboOpt3Unit.Text)
                        {
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
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                    }
                    modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, cboJoinOperator.Text);

                    modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    lstFieldList.SetSelected(li_cnt, false);
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


            if (cboOpt5ValueOperator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the field operation from the list.");
                return;
            }

            if (lstRange.Items.Count == 0)
            {
                RadMessageBox.Show("Value(s) should be typed in.");
                return;
            }

            //Loop for each selected field
            for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
            {
                if (lstFieldList.SelectedIndex == li_cnt)
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                    modGlobal.gv_rs.Dispose();
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (field1type != "Date")
                    {
                        RadMessageBox.Show("This method is only valid with date fields", MsgBoxStyle.Critical, "Field is not a date");
                        return;
                    }

                    for (li_cnt2 = 0; li_cnt2 <= lstRange.Items.Count - 1; li_cnt2++)
                    {
                        Array.Resize(ref ls_months, li_cnt2 + 1);
                        ls_months[li_cnt2] = Support.GetItemString(lstRange, li_cnt2);
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_Action = "Add";

                    CritTitle = Support.GetItemString(lstFieldList, li_cnt);
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
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstFieldList, li_cnt) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt5ValueOperator.Text + "', ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '(" + Strings.Join(ls_months, ",") + ")',";
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "')";

                    modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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



            if (chkBlank6.CheckState == CheckState.Checked & cboOpt6ValueOperator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please choose an operator for Blank Comparison");
                return;
            }

            li_group = 0;
            GroupIDs = new string[li_group + 1];

            //Loop for each selected field
            for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
            {
                if (lstFieldList.SelectedIndex == li_cnt)
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                    modGlobal.gv_rs.Dispose();

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (field1type != "Date" & field1type != "Time")
                    {
                        RadMessageBox.Show("The selected fields are not date or time fields");
                        return;
                    }

                    if (string.IsNullOrEmpty(CritTitle))
                    {
                        CritTitle = "EARLIEST(";
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_Action = "Add";

                    CritTitle = string.Format("{0}{1},", CritTitle, Support.GetItemString(lstFieldList, li_cnt));

                    Array.Resize(ref GroupIDs, li_group + 1);
                    GroupIDs[li_group] = Convert.ToString(Support.GetItemData(lstFieldList, li_cnt));
                    li_group = li_group + 1;
                }
            }

            CritTitle = Strings.Mid(CritTitle, 1, Strings.Len(CritTitle) - 1);
            CritTitle = CritTitle + ") " + cboOpt6ValueOperator.Text + " BLANK";

            if (Information.UBound(GroupIDs) < 1)
            {
                RadMessageBox.Show("You must select more than one field to determine the earliest.");
                return;
            }
            Debug.Print(CritTitle);

            //UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            li_CriteriaSetID = InsertStepandSetRecords();

            modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, CriteriaTitle,";
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

            modGlobal.gv_cn.Execute(modGlobal.gv_sql);

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
            if (eventSender.Checked)
            {
                if (Opt1Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = true;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = false;
                    sstabOptions5.Enabled = false;
                    sstabOptions6.Enabled = false;
                    sstabOptions.ActiveWindow = sstabOptions1;
                    ChangeNote(ref true);
                }
            }
        }

        private void ChangeNote(ref bool Normal)
        {

            if (Normal)
            {
                lblNote.Text = "Note: If you are defining the interval between 2 date fields, select the earliest date field from the above list";
            }
            else
            {
                lblNote.Text = "Note:  Please select the grouped dates/times from the field list.  Also, remember to use a time field in the same set as the next criteria entered.";
            }

        }

        //UPGRADE_WARNING: Event Opt2Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt2Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                if (Opt2Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = true;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = false;
                    sstabOptions5.Enabled = false;
                    sstabOptions6.Enabled = false;
                    sstabOptions.SelectedIndex = 1;
                    ChangeNote(ref true);

                }
            }
        }

        //UPGRADE_WARNING: Event Opt3Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt3Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                if (Opt3Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = true;
                    sstabOptions4.Enabled = false;
                    sstabOptions5.Enabled = false;
                    sstabOptions6.Enabled = false;
                    sstabOptions.SelectedIndex = 2;
                    ChangeNote(ref true);

                }
            }
        }

        //UPGRADE_WARNING: Event Opt4Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt4Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                if (Opt4Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = true;
                    sstabOptions5.Enabled = false;
                    sstabOptions6.Enabled = false;
                    sstabOptions.SelectedIndex = 3;
                    ChangeNote(ref true);

                }

            }
        }

        //UPGRADE_WARNING: Event Opt5Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt5Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                if (Opt5Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = false;
                    sstabOptions5.Enabled = true;
                    sstabOptions6.Enabled = false;
                    sstabOptions.SelectedIndex = 4;
                    ChangeNote(ref true);

                }
            }
        }

        //UPGRADE_WARNING: Event Opt6Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt6Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
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
                chkBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;
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


            if (cboOpLkTable.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the field operation from the list");
                return;
            }

            if (cboLookupTables.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select lookup table from list.");
                return;
            }

            if (string.IsNullOrEmpty(cboJoinOperator.Text))
            {
                RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                return;
            }

            ls_LookupTxt = cboLookupTables.Text;
            li_LookupVal = Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex);

            //Loop for each selected field
            for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
            {
                if (lstFieldList.SelectedIndex == li_cnt)
                {

                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(lstFieldList, li_cnt);
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                    modGlobal.gv_rs.Dispose();

                    //make sure that the field type is not a date field
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Dat")
                    {
                        RadMessageBox.Show("You cannot compare " + Support.GetItemString(lstFieldList, li_cnt) + " to a lookup table, because the selected field is a date field. Please re-Specify...");
                        return;
                    }

                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_Action = "Add";

                    CritTitle = string.Format("{0} {1} [{2}] Lookup Table ", Support.GetItemString(lstFieldList, li_cnt), cboOpLkTable.Text, ls_LookupTxt);

                    //UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_CriteriaSetID = InsertStepandSetRecords();

                    modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator)";

                    modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                    //UPGRADE_WARNING: Couldn't resolve default property of object li_CriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstFieldList, li_cnt) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpLkTable.Text + "', ";
                    modGlobal.gv_sql = modGlobal.gv_sql + li_LookupVal + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "')";

                    modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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


            //UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepSubmitSubs WHERE MeasureStepID = " + MeasureStepID;
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

            if (modGlobal.gv_rs.RowCount == 0)
            {

                modGlobal.gv_sql = "insert into tbl_Setup_MeasureStepSubmitSubs (MeasureStepID) ";
                //UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " values (" + MeasureStepID + ") ";
                modGlobal.gv_cn.Execute(modGlobal.gv_sql);

                //UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepSubmitSubs WHERE MeasureStepID = " + MeasureStepID;
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            }
            //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            li_StepID = modGlobal.gv_rs.rdoColumns["MeasureStepSubmitSubsID"].Value;
            modGlobal.gv_rs.Dispose();

            //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSetSubmitSubs " + " WHERE MeasureStepSubmitSubsID = " + li_StepID + " AND MeasureCriteriaSet = " + (Support.GetItemData(cboSet, cboSet.SelectedIndex) - 1);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (!modGlobal.gv_rs.EOF)
            {
                ls_DefJoin = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
            }
            else
            {
                ls_DefJoin = "AND";
            }
            modGlobal.gv_rs.Dispose();

            //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSetSubmitSubs " + " WHERE MeasureStepSubmitSubsID = " + li_StepID + " AND MeasureCriteriaSet = " + Support.GetItemData(cboSet, cboSet.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

            if (modGlobal.gv_rs.EOF)
            {
                //default join to AND
                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSetSubmitSubs (";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureStepSubmitSubsID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator) ";
                //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " values (" + li_StepID + ",";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex) + ",";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + ls_DefJoin + "')";
                modGlobal.gv_cn.Execute(modGlobal.gv_sql);

                li_SetID = modGlobal.GetLastID(ref "tbl_Setup_MeasureCriteriaSetSubmitSubs");
            }
            else
            {
                li_SetID = modGlobal.gv_rs.rdoColumns["measureCriteriaSetSubmitSubsID"].Value;
                modGlobal.gv_rs.Dispose();
            }

            functionReturnValue = li_SetID;
            return functionReturnValue;
            ErrHandler:

            modGlobal.CheckForErrors();
            return functionReturnValue;
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
            if (lstFieldList.SelectedItems.Count == 0)
            {
                is_Selected = new SelectedMeasureField[1];
            }
            else
            {

                if (lstFieldList.SelectedItems.Count == 1 & (Information.UBound(is_Selected) == 1 | Information.UBound(is_Selected) > 1))
                {
                    is_Selected = new SelectedMeasureField[1];
                }

                for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                {
                    if (lstFieldList.SelectedIndex == li_cnt)
                    {
                        li_found = 0;
                        li_SelCount = Information.UBound(is_Selected);

                        if (li_SelCount != 0)
                        {
                            for (li_cnt2 = 1; li_cnt2 <= Information.UBound(is_Selected); li_cnt2++)
                            {
                                if (is_Selected[li_cnt2].DDID == Support.GetItemData(lstFieldList, li_cnt))
                                {
                                    li_found = 1;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                        }

                        if (li_found == 0)
                        {

                            //get the field types
                            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(lstFieldList, li_cnt);
                            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            ls_FieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                            modGlobal.gv_rs.Dispose();

                            if (li_SelCount > 0)
                            {
                                if (is_Selected[li_SelCount].FieldType != ls_FieldType)
                                {
                                    RadMessageBox.Show("The data type of " + Support.GetItemString(lstFieldList, li_cnt) + " and " + is_Selected[li_SelCount].Description + " are not the same.", MsgBoxStyle.Critical, "Cannot Compare Different Data Types");
                                    lstFieldList.SetSelected(li_cnt, false);

                                    lb_CanSave = false;
                                }
                                else
                                {
                                    lb_CanSave = true;
                                }
                            }
                            else
                            {
                                lb_CanSave = true;
                            }

                            if (lb_CanSave)
                            {
                                Array.Resize(ref is_Selected, li_SelCount + 2);
                                is_Selected[li_SelCount + 1].DDID = Support.GetItemData(lstFieldList, li_cnt);
                                is_Selected[li_SelCount + 1].Description = Support.GetItemString(lstFieldList, li_cnt);
                                is_Selected[li_SelCount + 1].FieldType = ls_FieldType;
                            }

                        }
                    }
                }
            }
        }
    }
}
