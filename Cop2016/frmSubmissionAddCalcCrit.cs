using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSubmissionAddCalcCrit : Telerik.WinControls.UI.RadForm
    {
        public string rdcSubmissionFieldListTable = "tbl_setup_SubmitGroup";


        public frmSubmissionAddCalcCrit()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboDestField_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboDestField.SelectedIndex > -1)
                {
                    txtOpt1TypeinValue.Text = "";
                    chkBlank.CheckState = CheckState.Unchecked;
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void cboSet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshSetDef();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void chkBlank_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBlank.CheckState == CheckState.Checked)
                {
                    txtOpt1TypeinValue.Text = "";
                    cboDestField.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();


            try
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
                modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql,
                    frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSubmissionAddCalcCrit_Load(object sender, EventArgs e)
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            this.CenterToParent();


            try
            {
                sstabOptions.ActiveWindow = sstabOptions1;
                sstabOptions1.Enabled = false;
                sstabOptions2.Enabled = false;
                sstabOptions3.Enabled = false;
                sstabOptions4.Enabled = false;
                Opt1Method.IsChecked = false;
                Opt2Method.IsChecked = false;
                Opt3Method.IsChecked = false;
                Opt4Method.IsChecked = false;

                //RefreshGroup1Fields "NotDefined"
                lblColName.Text = string.Format("Setting up criteria for {0}/{1}/{2}", frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["GroupName"],
                    frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["GroupRow"],
                    frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["GroupCol"]);
                if (frmSubmissionSetupCopy.lstSummaryDef.Items.Count > 0)
                {
                    lblJoinOperator.Visible = true;
                    cboJoinOperator.Visible = true;
                }
                RefreshFieldsList();
                RefreshLookupTables();
                RefreshSetList();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void RefreshFieldsList()
        {
            var LIndex = 0;

            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT'";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')",
                        modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);


                //Display the list of fields
                lstField1List.Items.Clear();
                cboField2List.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    lstField1List.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"), myRow1.Field<int>("DDID")).ToString());
                    cboField2List.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"), myRow1.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void AddCriteriaWithMethod1()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
            string field1type = null;


            try
            {
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
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();


                //make sure that the typed value is of the same type as the field type
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD")
                    {
                        RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
                        return;
                    }

                    if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD")
                    {
                        //this is OK
                    }
                    else
                    {
                        if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text))
                        {
                            RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                            return;
                        }
                        if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5))
                        {
                            RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                            return;
                        }
                        if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) |
                            (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") |
                            (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1)))))
                        {
                            RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                            return;
                        }
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

                modGlobal.gv_Action = "Add";


                CritTitle = string.Format("{0} {1}", lstField1List.Text, cboOpt1ValueOperator.Text);
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, txtOpt1TypeinValue.Text);
                }
                if (chkBlank.CheckState == CheckState.Checked)
                {
                    CritTitle = string.Format("{0} Blank", CritTitle);
                    // Mid(cboOpt1ValueList.Text, InStr(1, cboOpt1ValueList.Text, "-") + 1)
                }
                if (cboDestField.SelectedIndex > -1)
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, cboDestField.Text);
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
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
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
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                //g = InputBox("", "", gv_sql)
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void AddCriteriaWithMethod2()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
            string field1type = null;
            int IDFromLookup;
            string fieldLookupTableID = " Null ";

            try
            {
                if (cboOpt2ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list");
                    return;
                }
                if (cboLookupValues.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select lookup value from list.");
                    return;
                }
                else
                {
                    modGlobal.gv_sql = "Select *   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                    modGlobal.gv_sql = string.Format("{0} Where lookupid = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_setup_Misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                    IDFromLookup = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["Id"]);
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //make sure that the field type is not a date field
                if (Strings.Mid(field1type, 1, 3) == "Dat")
                {
                    RadMessageBox.Show("You cannot compare this field to a lookup value, because the selected field is a date field. Please re-Specify...");
                    return;
                }

                modGlobal.gv_Action = "Add";


                CritTitle = string.Format("{0} {1} {2}", lstField1List.Text, cboOpt2ValueOperator.Text, cboLookupValues.Text);
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

                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt2ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, IDFromLookup);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                //g = InputBox("", "", gv_sql)
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void AddCriteriaWithMethod4()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
            string Field2Type = null;
            string field1type = null;


            try
            {
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
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //make sure that the 2 selected fields are of the same type
                if (!string.IsNullOrEmpty(cboField2List.Text))
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_Datadef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    Field2Type = modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["FieldType"].ToString();
                    modGlobal.gv_rs.Dispose();
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

                modGlobal.gv_Action = "Add";

                CritTitle = lstField1List.Text;
                CritTitle = string.Format("{0} {1} {2}", CritTitle, cboFieldOperator.Text, cboField2List.Text);
                CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3ValueOperator.Text);
                CritTitle = string.Format("{0} {1}", CritTitle, txtOpt3TypeinValue.Text);
                if (field1type == "Date" | field1type == "Time")
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3Unit.Text);
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCriteriaID, SubGroupID, CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, Value, LookupID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, FieldOperator, DateUnit, JoinOperator, criteriaset)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, {2}, ", modGlobal.gv_sql, NewCritID, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt3ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt3TypeinValue.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, cboFieldOperator.Text);
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
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                //g = InputBox("", "", gv_sql)
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void lstField1List_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshLookupListForThisField();
                RefreshCriteriaFieldList();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void Opt1Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt1Method.IsChecked))
                {
                    if (Opt1Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptions1.Enabled = true;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 0;
                        sstabOptions.ActiveWindow = sstabOptions1;
                    }
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void Opt2Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt2Method.IsChecked))
                {
                    if (Opt2Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = true;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 1;
                        sstabOptions.ActiveWindow = sstabOptions2;
                        //RefreshLookupList
                    }
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void Opt3Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt3Method.IsChecked))
                {
                    if (Opt3Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = true;
                        sstabOptions4.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 2;
                        sstabOptions.ActiveWindow = sstabOptions3;
                    }
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void Opt4Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt4Method.IsChecked))
                {
                    if (Opt4Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = true;
                        //LDW sstabOptions.SelectedIndex = 3;
                        sstabOptions.ActiveWindow = sstabOptions4;
                    }
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void txtOpt1TypeinValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    chkBlank.CheckState = CheckState.Unchecked;
                    cboDestField.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void RefreshSetList()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int SetIndex = 1;


            try
            {
                cboSet.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
                if (frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    if (Information.IsDBNull(frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                    }
                }
                //gv_sql = gv_sql & " and JoinOperator = '" & cboJoinOperator & "'"
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                //Display the list of criteria
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    cboSet.Items.Add("Set " + SetIndex);
                    Support.SetItemData(cboSet, cboSet.Items.Count - 1, SetIndex);
                    SetIndex = SetIndex + 1;
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                //always add a new one to the list in addition to the previous ones
                cboSet.Items.Add(new ListBoxItem("Set " + SetIndex, SetIndex).ToString());
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void RefreshSetDef()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();


            try
            {
                if (cboSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCriteria ";
                if (frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    if (Information.IsDBNull(frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                    }
                }
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName7].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["JoinOperator"].ToString();
                    cboJoinOperator.Enabled = false;
                }
                modGlobal.gv_rs.Dispose();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void RefreshLookupListForThisField()
        {
            var LIndex = 0;
            int Field_ListIndex;
            int LookupTableID;


            try
            {
                cboLookupValues.Items.Clear();

                modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count > 0)
                {
                    LookupTableID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["LookupTableID"]);

                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName9 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);


                    Field_ListIndex = -1;
                    LIndex = -1;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                    {
                        LIndex = LIndex + 1;
                        Field_ListIndex = LIndex;

                        cboLookupValues.Items.Add(new ListBoxItem("(" + myRow9.Field<int>("Id") + ") " + myRow9.Field<string>("FIELDVALUE"), myRow9.Field<int>("LookupID")).ToString());

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else if (Opt2Method.IsChecked == true)
                {
                    Opt1Method.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void RefreshCriteriaFieldList()
        {
            var LIndex = 0;
            string field1type = null;


            try
            {
                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT'";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_DataDef.fieldtype = '{1}'", modGlobal.gv_sql, field1type);
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_DataDef.ddid <> {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                //Display the list of fields
                cboField2List.Items.Clear();
                cboDestField.Items.Clear();

                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                {
                    LIndex = LIndex + 1;

                    cboField2List.Items.Add(new ListBoxItem(myRow11.Field<string>("FieldName"), myRow11.Field<int>("DDID")).ToString());

                    cboDestField.Items.Add(new ListBoxItem(myRow11.Field<string>("FieldName"), myRow11.Field<int>("DDID")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void RefreshLookupTables()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;


            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                cboLookupTables.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    cboLookupTables.Items.Add(new ListBoxItem(myRow12.Field<string>("BaseTable"), myRow12.Field<int>("basetableid")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void AddCriteriaWithMethod3()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
            string field1type = null;


            try
            {
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
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //make sure that the field type is not a date field
                if (Strings.Mid(field1type, 1, 3) == "Dat")
                {
                    RadMessageBox.Show("You cannot compare this field to a lookup table, because the selected field is a date field. Please re-Specify...");
                    return;
                }

                modGlobal.gv_Action = "Add";

                CritTitle = string.Format("{0} {1} [{2}] Lookup Table ", lstField1List.Text, cboOpLkTable.Text, cboLookupTables.Text);
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

                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpLkTable.Text);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                //g = InputBox("", "", gv_sql)
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }
    }
}
