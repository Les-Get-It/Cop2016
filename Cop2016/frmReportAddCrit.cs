using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;



namespace COP2001
{
    public partial class frmReportAddCrit : RadForm
    {
        int thismessageid = 0;


        public frmReportAddCrit()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboDestFieldList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            var cboOpt1Unit = new RadDropDownList();

            try
            {
                if (cboDestFieldList.SelectedIndex > 0)
                {
                    chkBlank.CheckState = CheckState.Unchecked;
                    txtOpt1TypeinValue.Text = "";
                    cboOpt1Unit.Text = "";
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

        private void chkBlank_CheckStateChanged(object sender, EventArgs e)
        {
            var cboOpt1Unit = new RadDropDownList();

            try
            {
                if (chkBlank.CheckState == CheckState.Checked)
                {
                    txtOpt1TypeinValue.Text = "";
                    cboOpt1Unit.Text = "";
                    cboDestFieldList.SelectedIndex = -1;
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled == false)
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
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SavedAdhocReportCriteria", "CriteriaID");
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
                const string sqlTableName1 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["FieldType"].ToString();
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

                modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Report_ID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableid, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpLkTable.Text);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex));
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshDestFieldList()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            var LIndex = 0;
            int Field_ListIndex = -1;

            try
            {

                modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboTableList, frmReportSetupCopy.cboTableList.SelectedIndex));

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";


                //retrieve the list of dynamic fields

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboDestFieldList.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Field_ListIndex = LIndex;

                    cboDestFieldList.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());

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

        private void frmReportAddCrit_Load(object sender, EventArgs e)
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();

            this.CenterToScreen();

            try
            {

                lblMessage.Text = "Setup criteria for this report: " + frmReportSetupCopy.cboReportList.Text;

                sstabOptions.ActiveWindow = sstabOptions1;
                sstabOptions1.Enabled = false;
                sstabOptions2.Enabled = false;
                Opt1Method.IsChecked = false;
                Opt2Method.IsChecked = false;

                //If frmTableValidationSetup.lstErrorCriteriaSet.ListCount > 0 Then
                //    lblJoinOperator.Visible = True
                //    cboJoinOperator.Visible = True
                //End If
                RefreshFieldsList();
                RefreshDestFieldList();
                //RefreshLookupList
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

        public void AddCriteriaWithMethod1()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            int IDFromLookup = 0;
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SavedAdhocReportcriteria", "CriteriaID");
            string DestFieldType = null;
            string field1type = null;


            try
            {

                if (cboOpt1ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list");
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboDestFieldList.SelectedIndex < 0 & chkBlank.CheckState == 0 & cboLookupValues.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Either select a field, or check the blank, or define a value.");
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

                if (cboDestFieldList.SelectedIndex > -1)
                {
                    //find the Dest field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName4 = "tbl_setup_Datadef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                    DestFieldType = modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["FieldType"].ToString();
                    modGlobal.gv_rs.Dispose();

                    if (field1type != DestFieldType)
                    {
                        RadMessageBox.Show("The data types of the selected fields don't match. Please re-Specify...");
                        return;
                    }
                }

                //make sure that the typed value is of the same type as the field type
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & txtOpt1TypeinValue.Visible == true)
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
                        if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text))
                        {
                            RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                            return;
                        }
                    }
                }

                CritTitle = string.Format("{0} {1}", lstField1List.Text, cboOpt1ValueOperator.Text);

                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, txtOpt1TypeinValue.Text);
                }

                if (cboLookupValues.SelectedIndex > -1 & cboLookupValues.Visible == true)
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, cboLookupValues.Text);

                    modGlobal.gv_sql = "Select *   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                    modGlobal.gv_sql = string.Format("{0} Where lookupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_Misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    IDFromLookup = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["Id"]);
                }

                if (cboDestFieldList.SelectedIndex > -1)
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, cboDestFieldList.Text);
                }
                if (chkBlank.CheckState == CheckState.Checked)
                {
                    CritTitle = CritTitle + " Blank ";
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_savedadhocreportcriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Report_Id, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Lookupid, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";

                modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                if (cboDestFieldList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                }
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt1ValueOperator.Text);
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & txtOpt1TypeinValue.Visible == true)
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt1TypeinValue.Text);
                }
                else if (chkBlank.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
                }
                else if (cboLookupValues.SelectedIndex > -1 & cboLookupValues.Visible == true)
                {
                    modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, IDFromLookup);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                }
                if (cboLookupValues.SelectedIndex > -1 & cboLookupValues.Visible == true)
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                UpdateMainJoinOp();

                modGlobal.gv_Action = "Add";

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
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SavedAdhocReportCriteria", "CriteriaID");
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
                const string sqlTableName6 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (Strings.UCase(Strings.Mid(field1type, 1, 3)) != "DAT" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "TIM" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "NUM")
                {
                    RadMessageBox.Show("Only a date, time or numeric field can be selected for this method. Please re-Specify...");
                    return;
                }

                //make sure that the 2 selected fields are of the same type
                //    If cboField2List <> "" Then
                //        'find the field type
                //        gv_sql = "Select FieldType from tbl_setup_Datadef "
                //        gv_sql = gv_sql & " where DDID = " & cboField2List.ItemData(cboField2List.ListIndex)
                //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //
                //        Field2Type = gv_rs!FieldType
                //        gv_rs.Close
                //        If field1type <> Field2Type Then
                //            MsgBox "The 2 fields that you have selected are not of the same type. Please re-specify..."
                //            Exit Sub
                //        End If
                //    End If


                //make sure that the typed value is numeric
                if (!Information.IsNumeric(txtOpt3TypeinValue.Text))
                {
                    RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");
                    return;
                }

                if (field1type == "Date" & cboFieldOperator.Text != "-")
                {
                    RadMessageBox.Show("Date fields can only be subtracted from eachother.");
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

                CritTitle = lstField1List.Text;
                CritTitle = string.Format("{0} {1} {2}", CritTitle, cboFieldOperator.Text, cboField2List.Text);
                CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3ValueOperator.Text);
                CritTitle = string.Format("{0} {1}", CritTitle, txtOpt3TypeinValue.Text);

                if (field1type == "Date" | field1type == "Time")
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3Unit.Text);
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, Report_ID, CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, ValueOperator, Value, ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  Fieldoperator, DateUnit, JoinOperator, CriteriaSet)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt3ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt3TypeinValue.Text);
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

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                UpdateMainJoinOp();

                modGlobal.gv_Action = "Add";

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

        public void RefreshSetDef()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();

            try
            {

                if (cboSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_SavedAdhocReportCriteria";
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

        public void RefreshSetList()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            int SetIndex = 1;


            try
            {
                cboSet.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_id = {1}", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //Display the list of criteria
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
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

        public void RefreshFieldsList()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            var LIndex = 0;

            try
            {

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID =  {1}", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboTableList, frmReportSetupCopy.cboTableList.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                //Display the list of fields
                lstField1List.Items.Clear();
                cboField2List.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    LIndex = LIndex + 1;
                    lstField1List.Items.Add(new ListBoxItem(myRow9.Field<string>("FieldName"), myRow9.Field<int>("DDID")).ToString());
                    cboField2List.Items.Add(new ListBoxItem(myRow9.Field<string>("FieldName"), myRow9.Field<int>("DDID")).ToString());
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
                const string sqlTableName10 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                cboLookupTables.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    cboLookupTables.Items.Add(new ListBoxItem(myRow10.Field<string>("BaseTable"), myRow10.Field<int>("basetableid")).ToString());
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

        private void lstField1List_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshValueOrLookupList();
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
                        sstabOptions.ActiveWindow = sstabOptions1;
                        RefreshValueOrLookupList();
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
                        sstabOptions.ActiveWindow = sstabOptions2;
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

        private void txtOpt1TypeinValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    chkBlank.CheckState = CheckState.Unchecked;
                    cboDestFieldList.SelectedIndex = -1;
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

        public void UpdateMainJoinOp()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();

            try
            {
                //update join operator if any
                if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
                {
                    modGlobal.gv_sql = "Update tbl_Setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, modGlobal.gv_ANDOR);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        public void RefreshValueOrLookupList()
        {
            var LIndex = 0;
            int Field_ListIndex;
            int LookupTableID;

            try
            {
                if (lstField1List.SelectedIndex < 0)
                {
                    cboLookupValues.Visible = false;
                    cboLookupValues.SelectedIndex = -1;
                    txtOpt1TypeinValue.Visible = true;
                    txtOpt1TypeinValue.Text = "";
                    return;
                }
                //after selecting each field,
                // if the field value is based on a lookup table
                //   display the drop down box with the related values
                // otherwise
                //   display the text box to type the value in

                modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName11].Rows.Count > 0)
                {
                    LookupTableID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["LookupTableID"]);
                    cboLookupValues.Visible = true;
                    txtOpt1TypeinValue.Visible = false;
                    cboLookupValues.Left = txtOpt1TypeinValue.Left;
                    cboLookupValues.Top = txtOpt1TypeinValue.Top;

                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by id";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName12 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                    cboLookupValues.Items.Clear();

                    Field_ListIndex = -1;
                    LIndex = -1;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                    {
                        LIndex = LIndex + 1;
                        Field_ListIndex = LIndex;

                        cboLookupValues.Items.Add(new ListBoxItem(myRow12.Field<int>("Id") +
                            ". " + myRow12.Field<string>("FIELDVALUE"), myRow12.Field<int>("LookupID")).ToString());

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else
                {
                    cboLookupValues.Visible = false;
                    cboLookupValues.SelectedIndex = -1;
                    txtOpt1TypeinValue.Visible = true;
                    txtOpt1TypeinValue.Text = "";
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
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            var LIndex = 0;
            string thisfieldtype = null;

            try
            {
                //find the field type of the selected field
                modGlobal.gv_sql = "Select fieldtype ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID =  " + Support.GetItemData(lstField1List, lstField1List.SelectedIndex);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);
                thisfieldtype = "'" + modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["FieldType"].ToString() + "'";

                if (thisfieldtype == "'Date/Time'" | thisfieldtype == "'Time'")
                {
                    thisfieldtype = "'Date/Time' OR fieldtype = 'Time'";
                }

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select DISTINCT FieldName, DDID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID =  " + Support.GetItemData(frmReportSetupCopy.cboTableList, frmReportSetupCopy.cboTableList.SelectedIndex);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and (fieldtype = " + thisfieldtype + ")";
                modGlobal.gv_sql = modGlobal.gv_sql + " and DDID <>  " + Support.GetItemData(lstField1List, lstField1List.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                //Display the list of fields
                cboDestFieldList.Items.Clear();
                cboField2List.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow14 in modGlobal.gv_rs.Tables[sqlTableName14].Rows)
                {
                    LIndex = LIndex + 1;
                    cboDestFieldList.Items.Add(new ListBoxItem(myRow14.Field<string>("FieldName"), myRow14.Field<int>("DDID")).ToString());
                    cboField2List.Items.Add(new ListBoxItem(myRow14.Field<string>("FieldName"), myRow14.Field<int>("DDID")).ToString());
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
    }
}
