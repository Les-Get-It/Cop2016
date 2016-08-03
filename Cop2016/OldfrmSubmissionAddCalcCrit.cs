using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmSubmissionAddCalcCrit : Form
    {

        private void cboOpt1ValueList_Click()
        {
            txtOpt1TypeinValue.Text = "";
        }

        //UPGRADE_WARNING: Event cboDestField.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboDestField_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (cboDestField.SelectedIndex > -1)
            {
                txtOpt1TypeinValue.Text = "";
                chkBlank.CheckState = CheckState.Unchecked;
            }
        }

        //UPGRADE_WARNING: Event cboSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSet_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            RefreshSetDef();
        }

        //UPGRADE_WARNING: Event chkBlank.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void chkBlank_CheckStateChanged(System.Object sender, System.EventArgs eventArgs)
        {

            if (chkBlank.CheckState == CheckState.Checked)
            {
                txtOpt1TypeinValue.Text = "";
                cboDestField.SelectedIndex = -1;
            }

        }

        private void cmdAdd_Click(System.Object sender, System.EventArgs eventArgs)
        {

            if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled == false & sstabOptions4.Enabled == false)
            {
                RadMessageBox.Show("Please select a method.");
                return;
            }

            if (lstField1List.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a field from the list");
                return;
            }

            if (cboSet.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the Criteria Set.");
                return;
            }

            if (string.IsNullOrEmpty(cboJoinOperator.Text))
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

            //update the join operator if it is not defined
            //
            modGlobal.gv_sql = "Update tbl_setup_SubmitSubGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And' ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

        }

        private void cmdCancel_Click(System.Object sender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private void frmSubmissionAddCalcCrit_Load(System.Object sender, System.EventArgs eventArgs)
        {
            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));


            sstabOptions.SelectedIndex = 0;
            sstabOptions1.Enabled = false;
            sstabOptions2.Enabled = false;
            sstabOptions3.Enabled = false;
            sstabOptions4.Enabled = false;
            Opt1Method.Checked = false;
            Opt2Method.Checked = false;
            Opt3Method.Checked = false;
            Opt4Method.Checked = false;

            //RefreshGroup1Fields "NotDefined"
            lblColName.Text = "Setting up criteria for " + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["GroupName"].Value + "/" + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["GroupRow"].Value + "/" + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["GroupCol"].Value;
            if (frmSubmissionSetupCopy.lstSummaryDef.Items.Count > 0)
            {
                lblJoinOperator.Visible = true;
                cboJoinOperator.Visible = true;
            }
            RefreshFieldsList();
            RefreshLookupTables();

            RefreshSetList();
        }

        public void RefreshFieldsList()
        {
            var LIndex = 0;

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
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            lstField1List.Items.Clear();
            cboField2List.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                lstField1List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();


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
        //        cboLookupValues.ItemData(cboLookupValues.Items.Count-1) = gv_rs!LookupID
        //        gv_rs.MoveNext
        //    Wend
        //
        //End Sub

        private void txtValue_Change()
        {
            bool optTypeInValue = true;
            cboLookupValues.Text = "";
        }

        public void AddCriteriaWithMethod1()
        {
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
            string field1type = null;

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

            //find the field type
            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
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
                    RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
                    return;
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD")
                {
                    //this is OK
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text))
                    {
                        RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                        return;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1)))))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                }
                //make sure that the selected field is a numeric field if it is compared to a lookup value
                //ElseIf cboOpt1ValueList.ListIndex >= 0 Then
                //    If Mid(Field1Type, 1, 3) = "Num" And Not IsNumeric(cboOpt1ValueList.List(cboOpt1ValueList.ListIndex)) Then
                //        MsgBox "The selected field is not a numeric value."
                //        Exit Sub
                //    End If
                //    If Mid(Field1Type, 1, 3) = "Dat" Or Mid(Field1Type, 1, 3) = "Tim" Then
                //        MsgBox "The selected field is a date or time field, but a value from the list has been selected. Please re-Specify..."
                //        Exit Sub
                //    End If
            }

            //If Field1Type = "Date" And cboOpt1Unit.Text = "" Then
            //    MsgBox "Please define the date unit associated with the value"
            //    Exit Sub
            //End If

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Add";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = lstField1List.Text + " " + cboOpt1ValueOperator.Text;
            if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CritTitle = CritTitle + " " + txtOpt1TypeinValue.Text;
            }
            if (chkBlank.CheckState == CheckState.Checked)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CritTitle = CritTitle + " " + "Blank";
                // Mid(cboOpt1ValueList.Text, InStr(1, cboOpt1ValueList.Text, "-") + 1)
            }
            if (cboDestField.SelectedIndex > -1)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CritTitle = CritTitle + " " + cboDestField.Text;
            }
            //If Field1Type = "Date" Then
            //    CritTitle = CritTitle & " " & cboOpt1Unit.Text
            //End If

            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + "(";
            modGlobal.gv_sql = modGlobal.gv_sql + " SubmitCriteriaID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + ")";
            modGlobal.gv_sql = modGlobal.gv_sql + " values (";
            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";

            if (cboDestField.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestField, cboDestField.SelectedIndex) + ", ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt1ValueOperator.Text + "', ";

            if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt1TypeinValue.Text + "',";
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
            //If cboOpt1Unit.Text <> "" Then
            //    Select Case cboOpt1Unit.Text
            //        Case "Years":
            //            gv_sql = gv_sql & " 'YYYY',"
            //        Case "Months":
            //            gv_sql = gv_sql & " 'm',"
            //        Case "Days":
            //            gv_sql = gv_sql & " 'd',"
            //    End Select
            //Else
            modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
            //End If
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //g = InputBox("", "", gv_sql)
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            this.Close();

        }

        public void AddCriteriaWithMethod2()
        {
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
            string field1type = null;
            int IDFromLookup;
            string fieldLookupTableID;

            if (cboOpt2ValueOperator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the field operation from the list");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object fieldLookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
                modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Couldn't resolve default property of object IDFromLookup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                IDFromLookup = modGlobal.gv_rs.rdoColumns["Id"].Value;

            }

            if (string.IsNullOrEmpty(cboJoinOperator.Text))
            {
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
            if (Strings.Mid(field1type, 1, 3) == "Dat")
            {
                RadMessageBox.Show("You cannot compare this field to a lookup value, because the selected field is a date field. Please re-Specify...");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Add";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = lstField1List.Text + " " + cboOpt2ValueOperator.Text + " " + cboLookupValues.Text;
            //Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCriteriaID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";

            modGlobal.gv_sql = modGlobal.gv_sql + " values (";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt2ValueOperator.Text + "', ";
            //UPGRADE_WARNING: Couldn't resolve default property of object IDFromLookup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + IDFromLookup + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //g = InputBox("", "", gv_sql)
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            this.Close();
        }

        public void AddCriteriaWithMethod4()
        {
            string CritTitle = null;
            int NewCritID;
            string Field2Type = null;
            string field1type = null;

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

            //find the field type
            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
            modGlobal.gv_rs.Dispose();

            //make sure that the 2 selected fields are of the same type
            if (!string.IsNullOrEmpty(cboField2List.Text))
            {
                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2List, cboField2List.SelectedIndex);
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

            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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

            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (field1type == "Time" & !Information.IsNumeric(txtOpt3TypeinValue.Text))
            {
                RadMessageBox.Show("Please define a numeric value for this Time difference. Duration will be in minutes  ");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Add";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");

            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = lstField1List.Text;
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = CritTitle + " " + cboFieldOperator.Text + " " + cboField2List.Text;
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = CritTitle + " " + cboOpt3ValueOperator.Text;
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = CritTitle + " " + txtOpt3TypeinValue.Text;
            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (field1type == "Date" | field1type == "Time")
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CritTitle = CritTitle + " " + cboOpt3Unit.Text;
            }

            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCriteriaID, SubGroupID, CriteriaTitle,";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, Value, LookupID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, FieldOperator, DateUnit, JoinOperator, criteriaset)";
            modGlobal.gv_sql = modGlobal.gv_sql + " values (";
            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", " + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt3ValueOperator.Text + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3TypeinValue.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField2List, cboField2List.SelectedIndex) + ", ";
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
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //g = InputBox("", "", gv_sql)
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            this.Close();
        }

        //UPGRADE_WARNING: Event lstField1List.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void lstField1List_SelectedIndexChanged(System.Object sender, System.EventArgs eventArgs)
        {
            RefreshLookupListForThisField();
            RefreshCriteriaFieldList();
        }

        //UPGRADE_WARNING: Event Opt1Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt1Method_CheckedChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (sender.IsChecked)
            {
                if (Opt1Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = true;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = false;
                    sstabOptions.SelectedIndex = 0;
                }
            }
        }

        //UPGRADE_WARNING: Event Opt2Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt2Method_CheckedChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (sender.IsChecked)
            {
                if (Opt2Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = true;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = false;
                    sstabOptions.SelectedIndex = 1;
                    //RefreshLookupList
                }
            }
        }

        //UPGRADE_WARNING: Event Opt3Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt3Method_CheckedChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (sender.IsChecked)
            {
                if (Opt3Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = true;
                    sstabOptions4.Enabled = false;
                    sstabOptions.SelectedIndex = 2;
                }
            }
        }

        //UPGRADE_WARNING: Event Opt4Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt4Method_CheckedChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (sender.IsChecked)
            {
                if (Opt4Method.Checked == true)
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = true;
                    sstabOptions.SelectedIndex = 3;
                }
            }
        }

        //UPGRADE_WARNING: Event txtOpt1TypeinValue.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void txtOpt1TypeinValue_TextChanged(System.Object sender, System.EventArgs eventArgs)
        {
            if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
            {
                chkBlank.CheckState = CheckState.Unchecked;
                cboDestField.SelectedIndex = -1;
            }
        }

        public void RefreshSetList()
        {
            int SetIndex = 1;
            cboSet.Items.Clear();

            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
            if (frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.RowCount == 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
            }
            else
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value;
                }
            }
            //gv_sql = gv_sql & " and JoinOperator = '" & cboJoinOperator & "'"
            modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of criteria
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cboSet.Items.Add("Set " + SetIndex);
                //UPGRADE_ISSUE: ComboBox property cboSet.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboSet, cboSet.Items.Count-1, SetIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex + 1;
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            //always add a new one to the list in addition to the previous ones
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + SetIndex, SetIndex));

        }

        public void RefreshSetDef()
        {
            if (cboSet.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCriteria ";
            if (frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.RowCount == 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
            }
            else
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value;
                }
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);

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
            modGlobal.gv_rs.Dispose();


        }

        public void RefreshLookupListForThisField()
        {
            var LIndex = 0;
            int Field_ListIndex;
            int LookupTableID;
            cboLookupValues.Items.Clear();

            modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;

                modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                //UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + LookupTableID;
                modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);


                //UPGRADE_WARNING: Couldn't resolve default property of object Field_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Field_ListIndex = -1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = -1;
                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    LIndex = LIndex + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object Field_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Field_ListIndex = LIndex;

                    cboLookupValues.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));

                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }
            else if (Opt2Method.Checked == true)
            {
                Opt1Method.Checked = true;
            }
        }

        public void RefreshCriteriaFieldList()
        {
            var LIndex = 0;
            string field1type = null;

            //find the field type
            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.fieldtype = '" + field1type + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid <> " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            cboField2List.Items.Clear();
            cboDestField.Items.Clear();

            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;

                cboField2List.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

                cboDestField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));

                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();
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
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Table_ListIndex = LIndex;
                cboLookupTables.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
        }

        public void AddCriteriaWithMethod3()
        {
            string CritTitle = null;
            int NewCritID;
            string field1type = null;
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

            //find the field type
            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
            modGlobal.gv_rs.Dispose();

            //make sure that the field type is not a date field
            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (Strings.Mid(field1type, 1, 3) == "Dat")
            {
                RadMessageBox.Show("You cannot compare this field to a lookup table, because the selected field is a date field. Please re-Specify...");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Add";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");

            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = lstField1List.Text + " " + cboOpLkTable.Text + " [" + cboLookupTables.Text + "] Lookup Table ";
            //Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCriteriaID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";

            modGlobal.gv_sql = modGlobal.gv_sql + " values (";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstField1List, lstField1List.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpLkTable.Text + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //g = InputBox("", "", gv_sql)
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            this.Close();
        }
    }
}
