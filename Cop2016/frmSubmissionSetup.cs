using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
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
    public partial class frmSubmissionSetup : Telerik.WinControls.UI.RadForm
    {
        public DataSet rdcSubmissionFieldList = new DataSet();
        public string rdcSubmissionFieldListTable = null;
        public DataSet rdcValidationErrors = new DataSet();
        public string rdcValidationErrorsTable = null;
        public DataSet rdcValidationWarnings = new DataSet();
        public string rdcValidationWarningsTable = null;
        public DataSet rdcValidationErrorCriteria = new DataSet();
        public string rdcValidationErrorCriteriaTable = null;
        public DataSet rdcValidationWarningCriteria = new DataSet();
        public string rdcValidationWarningCriteriaTable = null;
        public DataSet rdcSumFieldList = new DataSet();
        public string rdcSumFieldListTable = null;
        public DataSet rdcIndicatorList = new DataSet();
        public string rdcIndicatorListTable = null;
        readonly StaticLocalInitFlag static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init = new StaticLocalInitFlag();
        int static_ssTabSubmission_SelectedIndexChanged_PreviousTab;




        public frmSubmissionSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboCleanUpFieldToAdd_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            var i = 0;
            DataSet gv_temp = new DataSet();
            bool FindField = false;

            try
            {

                if (lstCleanUpFields.SelectedIndex < 0)
                {
                    FindField = true;
                }
                else if (cboCleanUpFieldToAdd.SelectedIndex > -1)
                {
                    if (Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex) != Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex))
                    {
                        FindField = true;
                    }
                    else
                    {
                        lstCleanUpFields.SelectedIndex = -1;
                        RefreshCleanupFieldCriteria();
                    }
                }

                if (FindField == true)
                {
                    modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupItems ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex));

                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitCleanupItems.state = '' or tbl_setup_submitCleanupItems.state is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and tbl_setup_submitCleanupItems.state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                    }

                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.RecordStatus = '' or tbl_setup_SubmitCleanupItems.RecordStatus is null) ";
                    }
                    else
                    {

                        modGlobal.gv_sql = string.Format("{0} and tbl_setup_SubmitCleanupItems.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }

                    //LDW gv_temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_setup_submitCleanupItems";
                    gv_temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, gv_temp);

                    if (gv_temp.Tables[sqlTableName1].Rows.Count > 0)
                    {
                        for (i = 0; i <= lstCleanUpFields.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstCleanUpFields, i) == Convert.ToInt32(gv_temp.Tables[sqlTableName1].Rows[0]["SubmitCleanupID"]))
                            {
                                lstCleanUpFields.SelectedIndex = i;
                                FindField = false;
                            }
                        }
                    }
                    gv_temp.Dispose();
                }

                if (FindField == true)
                {
                    lstCleanUpFields.SelectedIndex = -1;
                    RefreshCleanupFieldCriteria();
                }

                //define how the buttons should be disabled
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCleanupCrit ";
                if (cboCleanUpFieldToAdd.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where  DDID = -1 ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where  DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex));
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_SubmitCleanupCrit";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cmdCleanupAnd.Enabled = false;
                cmdCleanupOr.Enabled = false;
                cmdCleanupAddCrit.Enabled = true;
                txtJoinOperator.Text = "";

                if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count > 0)
                {
                    //LDW modGlobal.gv_rs.MoveLast();
                }

                if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count == 1)
                {
                    cmdCleanupAnd.Enabled = true;
                    cmdCleanupOr.Enabled = true;
                    cmdCleanupAddCrit.Enabled = false;
                }
                else if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count > 1)
                {
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["JoinOperator"]))
                    {
                        txtJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["JoinOperator"].ToString();
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

        private void cboCleanupLookupTables_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                optCleanupLookupTable.IsChecked = true;
                cboCleanupValueList.SelectedIndex = -1;
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

        private void cboCleanupValueList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                optCleanupValue.IsChecked = true;
                cboCleanupLookupTables.SelectedIndex = -1;
                txtTypeinValue.Text = "";
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

                if (cboRecordCleanupField.SelectedIndex < 0)
                {
                    cboRecordCleanupLookupList.Visible = false;
                    cboRecordCleanupLookupList.SelectedIndex = -1;
                    txtRecordCleanupValue.Visible = true;
                    txtRecordCleanupValue.Text = "";
                    return;
                }

                //after selecting each field,
                // if the field value is based on a lookup table
                //   display the drop down box with the related values
                // otherwise
                //   display the text box to type the value in

                modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboRecordCleanupField, cboRecordCleanupField.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName3].Rows.Count > 0)
                {
                    LookupTableID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["LookupTableID"]);
                    cboRecordCleanupLookupList.Visible = true;
                    txtRecordCleanupValue.Visible = false;
                    cboRecordCleanupLookupList.Left = txtRecordCleanupValue.Left;
                    cboRecordCleanupLookupList.Top = txtRecordCleanupValue.Top;

                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by id";

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName4 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                    cboRecordCleanupLookupList.Items.Clear();

                    Field_ListIndex = -1;
                    LIndex = -1;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                    {
                        LIndex = LIndex + 1;
                        Field_ListIndex = LIndex;

                        cboRecordCleanupLookupList.Items.Add(new ListBoxItem(myRow4.Field<string>("Id") + ". " + myRow4.Field<string>("FIELDVALUE"), myRow4.Field<int>("LookupID")).ToString());

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else
                {
                    cboRecordCleanupLookupList.Visible = false;
                    cboRecordCleanupLookupList.SelectedIndex = -1;
                    txtRecordCleanupValue.Visible = true;
                    txtRecordCleanupValue.Text = "";
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

        private void cboRecordCleanupField_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshValueOrLookupList();
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

        private void cboRecordCleanupLookupList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboRecordCleanupLookupList.SelectedIndex > -1)
                {
                    chkRecordCleanupBlank.CheckState = CheckState.Unchecked;
                    txtRecordCleanupValue.Text = "";
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

        private void cboRecordCleanupSet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshRecordCleanupSetDef();
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

        private void cboSumOp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboSumOp.Text == "Count")
                {
                    //change the field to Discharge Date
                    //retrieve the Discharge Date from the list of fields
                    modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_DataDef.FieldName ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    //LIndex = -1
                    //rdcSumFieldList.Resultset.MoveFirst
                    //While Not rdcSumFieldList.Resultset.EOF
                    //    LIndex = LIndex + 1
                    //    If gv_rs!DDID = rdcSumFieldList.Resultset!DDID Then
                    //        lstSumField.ListIndex = LIndex
                    //    End If
                    //    rdcSumFieldList.Resultset.MoveNext
                    //Wend
                    //gv_rs.Close
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

        private void chkRecordCleanupBlank_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkRecordCleanupBlank.CheckState == CheckState.Checked)
                {
                    cboRecordCleanupLookupList.SelectedIndex = -1;
                    txtRecordCleanupValue.Text = "";
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

        private void cmdAddCol_Click(object sender, EventArgs e)
        {
            frmSubmissionColAdd frmSubmissionColAddCopy = new frmSubmissionColAdd();
            bool FoundIt;
            int thisColID = 0;

            try
            {

                frmSubmissionColAddCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add" | modGlobal.gv_Action == "Update" | modGlobal.gv_Action == "Delete")
                {
                    RefreshSubmissionDefList();
                }

                if (modGlobal.gv_Action == "Add")
                {
                    modGlobal.gv_sql = "Select max(SubGroupID) as NewColID from tbl_setup_SubmitSubGroup ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName6 = "tbl_setup_SubmitSubGroup";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                    thisColID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["NewColID"]);
                }
                if (modGlobal.gv_Action == "Update")
                {
                    thisColID = Convert.ToInt32(modGlobal.gv_SubmitColID);
                }

                if (thisColID > 0)
                {
                    FoundIt = false;

                    //LDW while ((!rdcSubmissionFieldList.Resultset.RowCount) & FoundIt == false)
                    for (int itr = 0; itr < rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count; itr++)
                    {
                        var myRow = (DataRow)rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[itr];
                        int rowIndex = rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.IndexOf(myRow);
                        int rowCount = rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count;

                        while ((rowIndex != rowCount) & FoundIt == false)
                        {
                            if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) == thisColID)
                            {
                                FoundIt = true;
                            }
                            else
                            {
                                //LDW rdcSubmissionFieldList.Resultset.MoveNext();
                                return;
                            }
                        }
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

        private void cmdAddError_Click(object sender, EventArgs e)
        {
            frmSubmissionAddValidation frmSubmissionAddValidationCopy = new frmSubmissionAddValidation();

            try
            {
                modGlobal.gv_Action = "ERROR";
                frmSubmissionAddValidationCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add")
                {
                    RefreshValidationMessages();
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

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            frmSubmissionGroupAdd frmSubmissionGroupAddCopy = new frmSubmissionGroupAdd();
            bool FoundIt;
            int thisGroupID = 0;

            try
            {

                frmSubmissionGroupAddCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add" | modGlobal.gv_Action == "Update" | modGlobal.gv_Action == "Delete")
                {
                    RefreshSubmissionDefList();
                }


                if (modGlobal.gv_Action == "Add")
                {
                    modGlobal.gv_sql = "Select max(GroupID) as NewGroupID from tbl_setup_SubmitGroup ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_setup_SubmitGroup";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);
                    thisGroupID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["NewGroupID"]);
                }

                if (modGlobal.gv_Action == "Update")
                {
                    thisGroupID = Convert.ToInt32(modGlobal.gv_SubmitGroupID);
                }

                if (thisGroupID > 0)
                {
                    FoundIt = false;

                    //LDW while ((!rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count) & FoundIt == false)
                    for (int i = 0; i < rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count; i++)
                    {
                        var myRow = (DataRow)rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[i];
                        int rowIndex = rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.IndexOf(myRow);
                        int rowCount = rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count;
                        while ((rowIndex != rowCount) & FoundIt == false)
                        {
                            if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["groupid"]) == thisGroupID)
                            {
                                FoundIt = true;
                            }
                            //LDW rdcSubmissionFieldList.Resultset.MoveNext();
                        }
                    }
                }
                RefreshColSummaryDef();
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

        private void cmdAddRow_Click(object sender, EventArgs e)
        {
            frmSubmissionRowAdd frmSubmissionRowAddCopy = new frmSubmissionRowAdd();
            bool FoundIt;
            int thisRowID = 0;

            try
            {

                frmSubmissionRowAddCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add" | modGlobal.gv_Action == "Update" | modGlobal.gv_Action == "Delete")
                {
                    RefreshSubmissionDefList();
                }

                if (modGlobal.gv_Action == "Add")
                {
                    modGlobal.gv_sql = "Select max(GroupRowID) as NewRowID from tbl_setup_SubmitGroupRow ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName8 = "tbl_setup_SubmitGroupRow";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                    thisRowID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["NewRowID"]);
                }

                if (modGlobal.gv_Action == "Update")
                {
                    thisRowID = Convert.ToInt32(modGlobal.gv_SubmitRowID);
                }

                if (thisRowID > 0)
                {
                    FoundIt = false;

                    //LDW while ((!rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count) & FoundIt == false)
                    for (int i = 0; i < rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count; i++)
                    {
                        var myRow = (DataRow)rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[i];
                        int rowIndex = rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.IndexOf(myRow);
                        int rowCount = rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count;
                        while ((rowIndex != rowCount) & FoundIt == false)
                        {
                            if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["grouprowID"]) == thisRowID)
                            {
                                FoundIt = true;
                            }
                            else
                            {
                                //LDW rdcSubmissionFieldList.Resultset.MoveNext();
                                return;
                            }
                        }
                    }
                }
                RefreshColSummaryDef();
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

        private void cmdAddSumCriteria_Click(object sender, EventArgs e)
        {
            frmSubmissionAddCalcCrit frmSubmissionAddCalcCritCopy = new frmSubmissionAddCalcCrit();

            try
            {

                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    return;
                }

                modGlobal.gv_Action = "NotDefined";

                if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                {
                    RadMessageBox.Show("A summarization criteria can only be defined for a column. Please select a column.");
                    return;
                }
                //frmSubmissionAddSumDef.Show 1
                frmSubmissionAddCalcCritCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshColSummaryDef();
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

        private void cmdAddWarning_Click(object sender, EventArgs e)
        {
            frmSubmissionAddValidation frmSubmissionAddValidationCopy = new frmSubmissionAddValidation();


            try
            {
                modGlobal.gv_Action = "WARNING";
                frmSubmissionAddValidationCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add")
                {
                    RefreshValidationMessages();
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

        private void cmdChangeAddOrBetweenSets_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to change the join operator between all sets?",
                    "Change Join Operator Between All Sets", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstSummaryDef.Items.Count == 0)
                {
                    return;
                }

                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitSubGroup ";
                modGlobal.gv_sql = string.Format("{0} where SubGroupID =  {1}", modGlobal.gv_sql, rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName9].Rows.Count > 0)
                {
                    modGlobal.gv_sql = "update tbl_setup_SubmitSubGroup ";
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"]) | string.IsNullOrEmpty(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"].ToString()))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                    }
                    else if (Strings.UCase(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"].ToString()) == "OR")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'AND'";
                    }
                    else if (Strings.UCase(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"].ToString()) == "AND")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                    }
                    modGlobal.gv_sql = string.Format("{0} where SubGroupID =  {1}", modGlobal.gv_sql, rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                RefreshColSummaryDef();
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

        private void cmdChangeAndOrCond_Click(object sender, EventArgs e)
        {
            string NewOp = null;

            try
            {
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstSummaryDef.SelectedIndex < 0)
                {
                    return;
                }
                if (Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex) < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select CriteriaSet, JoinOperator, SubGroupID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = string.Format("{0} Where SubmitCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                if (Strings.UCase(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["JoinOperator"].ToString()) == "AND")
                {
                    NewOp = "Or";
                }
                else
                {
                    NewOp = "And";
                }

                modGlobal.gv_sql = "update tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, NewOp);
                modGlobal.gv_sql = string.Format("{0} Where SubGroupID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["SubGroupID"]);
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["CriteriaSet"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshColSummaryDef();
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

        private void cmdChangeCleanupStatus_Click(object sender, EventArgs e)
        {
            DialogResult resp;

            try
            {
                string MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");


                if (lstCleanUpFields.SelectedIndex < 0)
                {
                    return;
                }


                resp = RadMessageBox.Show("Are you sure you want this Data Clean-up item to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_SubmitCleanupItems ";

                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where SubmitCleanupid = {1}", modGlobal.gv_sql, Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshCleanupFields();
                RefreshCleanupFieldCriteria();
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

        private void cmdChangeErrorStatus_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            string MoveToModule = null;

            try
            {
                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count == 0)
                {
                    return;
                }


                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this Error to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_submitvalidation ";

                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where submitvalid = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshValidationMessages();
                RefreshErrorCriteria();
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

        private void cmdChangeToError_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Warning to an Error?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_SubmitValidation ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set ValType = 'ERROR' ";
                    modGlobal.gv_sql = string.Format("{0} Where SubmitValID = {1}", modGlobal.gv_sql, rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshValidationMessages();
                    RefreshWarningCriteria();
                    RefreshErrorCriteria();
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

        private void cmdChangeToWarning_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Error to a Warning?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_SubmitValidation ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set ValType = 'WARNING' ";
                    modGlobal.gv_sql = string.Format("{0} Where SubmitValID = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshValidationMessages();
                    RefreshWarningCriteria();
                    RefreshErrorCriteria();
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

        private void cmdChangeWarningStatus_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            string MoveToModule = null;

            try
            {
                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count == 0)
                {
                    return;
                }


                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this Warning to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_submitvalidation ";

                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where submitvalid = {1}", modGlobal.gv_sql, rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshValidationMessages();
                RefreshWarningCriteria();
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

        private void cmdCleanupAddCrit_Click(object sender, EventArgs e)
        {
            var i = 0;
            string CriteriaDesc = null;
            int NewSubmitCleanupCritID;
            int newCleanupID;
            int NewSubmitCleanupItemID;
            string thisfieldtype = null;

            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);
                thisfieldtype = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (cboCleanUpFieldToAdd.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a field from the drop-down box.");
                    return;
                }

                if (cboCleanupOperation.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please define the operation from the drop-down box.");
                    return;
                }

                if (string.IsNullOrEmpty(txtTypeinValue.Text) & cboCleanupValueList.SelectedIndex < 0 & cboCleanupLookupTables.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please define a value or a lookup table.");
                    return;
                }

                if (cboCleanupValueList.SelectedIndex > -1)
                {

                    if (Strings.Mid(thisfieldtype, 1, 3) != "Tex")
                    {
                        RadMessageBox.Show("A value from the list can only be selected for a text field.");
                        return;
                    }
                }

                if (cboCleanupLookupTables.SelectedIndex >= 0)
                {

                    if (Strings.Mid(thisfieldtype, 1, 3) != "Tex")
                    {
                        RadMessageBox.Show("A lookup value can only be selected for a text field.");
                        return;
                    }

                    if (Support.GetItemString(cboCleanupOperation, cboCleanupOperation.SelectedIndex) != "<>")
                    {
                        RadMessageBox.Show("You can only select '<>' with a lookup table option");
                        cboCleanupOperation.SelectedIndex = 1;
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(txtTypeinValue.Text))
                {

                    if (Strings.Mid(thisfieldtype, 1, 3) == "Num" & !Information.IsNumeric(txtTypeinValue.Text))
                    {
                        RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
                        return;
                    }

                    if (Strings.Mid(thisfieldtype, 1, 3) == "Dat" & !Information.IsDate(txtTypeinValue.Text))
                    {
                        RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                        return;
                    }

                    if (Strings.Mid(thisfieldtype, 1, 3) == "Tim" & (Strings.Len(txtTypeinValue.Text) != 5))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }

                    if (Strings.Mid(thisfieldtype, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 2, 1))) | (Strings.Mid(txtTypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 5, 1)))))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }

                    if (Strings.Mid(thisfieldtype, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 4, 2)) > 59))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                }

                modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupItems ";
                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex));

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitCleanupItems.state = '' or tbl_setup_submitCleanupItems.state is null) ";
                }
                else
                {

                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_submitCleanupItems.state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.RecordStatus = '' or tbl_setup_SubmitCleanupItems.RecordStatus is null) ";
                }
                else
                {

                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_SubmitCleanupItems.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_setup_submitCleanupItems";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName14].Rows.Count == 0)
                {
                    NewSubmitCleanupItemID = modDBSetup.FindMaxRecID("tbl_setup_SubmitCleanupItems", "SubmitCleanupID");
                    //add the field first and then the criteria
                    modGlobal.gv_sql = "Insert into tbl_setup_submitCleanupitems (SubmitCleanupID, DDID, State, RecordStatus) ";

                    modGlobal.gv_sql = string.Format("{0} values ({1}, {2},", modGlobal.gv_sql, NewSubmitCleanupItemID, Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex));

                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null,  ";
                    }
                    else
                    {

                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, modGlobal.gv_State);
                    }

                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                    }
                    else
                    {

                        modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, modGlobal.gv_status);
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + ")";

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupItems ";
                    modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex));

                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                    }
                    else
                    {

                        modGlobal.gv_sql = string.Format("{0} and State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                    }

                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                    }
                    else
                    {

                        modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName15 = "tbl_setup_submitCleanupItems";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);
                }

                newCleanupID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["SubmitCleanupID"]);

                NewSubmitCleanupCritID = modDBSetup.FindMaxRecID("tbl_setup_SubmitCleanupCrit", "SubmitCleanupCritID");

                CriteriaDesc = cboCleanUpFieldToAdd.Text;
                if (cboCleanupValueList.SelectedIndex >= 0)
                {
                    CriteriaDesc = string.Format("{0} {1}", CriteriaDesc, cboCleanupOperation.Text);
                    if (cboCleanupValueList.Text == "Y (Yes)")
                    {
                        CriteriaDesc = CriteriaDesc + " ''Yes''";
                    }
                    else if (cboCleanupValueList.Text == "N (No)")
                    {
                        CriteriaDesc = CriteriaDesc + " ''No''";
                    }
                    else
                    {
                        CriteriaDesc = string.Format("{0} {1}", CriteriaDesc, cboCleanupValueList.Text);
                    }
                }
                else if (cboCleanupLookupTables.SelectedIndex >= 0)
                {
                    CriteriaDesc = string.Format("{0} is not in {1}", CriteriaDesc, cboCleanupLookupTables.Text);
                }
                else if (!string.IsNullOrEmpty(txtTypeinValue.Text))
                {
                    CriteriaDesc = CriteriaDesc + " " + cboCleanupOperation.Text;
                    CriteriaDesc = CriteriaDesc + " " + txtTypeinValue.Text;
                }


                modGlobal.gv_sql = "Insert into tbl_setup_submitCleanupCrit ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCleanupCritID, SubmitCleanupID, DDID, FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Operator, LookupTableID, CriteriaDesc) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NewSubmitCleanupCritID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + newCleanupID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex) + ",";
                if (cboCleanupValueList.SelectedIndex < 0)
                {
                    if (string.IsNullOrEmpty(txtTypeinValue.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtTypeinValue.Text + "',";
                    }
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + Strings.Mid(cboCleanupValueList.Text, 1, 1) + "',";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboCleanupOperation.Text + "',";
                if (cboCleanupLookupTables.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboCleanupLookupTables, cboCleanupLookupTables.SelectedIndex) + ",";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + CriteriaDesc + "')";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update join operator for this set
                modGlobal.gv_sql = "Update tbl_setup_submitCleanupCrit ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  set JoinOperator = ";
                if (string.IsNullOrEmpty(txtJoinOperator.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtJoinOperator.Text + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCleanupID = " + newCleanupID;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshCleanupFields();

                for (i = 0; i <= lstCleanUpFields.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstCleanUpFields, i) == newCleanupID)
                    {
                        lstCleanUpFields.SelectedIndex = i;
                    }
                }

                cboCleanUpFieldToAdd.SelectedIndex = -1;
                cboCleanupValueList.SelectedIndex = -1;
                cboCleanupOperation.SelectedIndex = -1;
                cboCleanupLookupTables.SelectedIndex = -1;
                txtTypeinValue.Text = "";

                cmdCleanupAnd.Enabled = true;
                cmdCleanupOr.Enabled = true;
                cmdCleanupAddCrit.Enabled = false;
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

        private void cmdCleanupAnd_Click(object sender, EventArgs e)
        {
            try
            {
                cmdCleanupAnd.Enabled = false;
                cmdCleanupOr.Enabled = false;
                cmdCleanupAddCrit.Enabled = true;
                txtJoinOperator.Text = "AND";
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

        private void cmdCleanupCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCleanupCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupCrit ";
                    modGlobal.gv_sql = string.Format("{0} Where SubmitCleanupCritID = {1}", modGlobal.gv_sql, Support.GetItemData(lstCleanupCriteria, lstCleanupCriteria.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupItems where submitcleanupid not in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (select submitcleanupid from tbl_setup_SubmitCleanupCrit )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshCleanupFieldCriteria();
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

        private void cmdCleanupOr_Click(object sender, EventArgs e)
        {
            try
            {
                cmdCleanupAnd.Enabled = false;
                cmdCleanupOr.Enabled = false;
                cmdCleanupAddCrit.Enabled = true;
                txtJoinOperator.Text = "OR";
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

        private void cmdCopyCriteria_Click(object sender, EventArgs e)
        {
            frmMeasureCopyCriteria frmMeasureCopyCriteriaCopy = new frmMeasureCopyCriteria();
            string[] SubCritIDs = null;

            try
            {

                modGlobal.gv_Action = "NotDefined";
                if (this.lstSummaryDef.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a criteria to copy.");
                    return;
                }

                if (Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex) < 0)
                {
                    RadMessageBox.Show("Select a criteria to copy.");
                    return;
                }

                //frmSubmissionAddSumDef.Show 1
                //frmSubmissionCopyCriteria.Show 1

                SubCritIDs = new string[1];
                SubCritIDs[0] = Convert.ToString(Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex));

                frmMeasureCopyCriteriaCopy.SetCopyType("S");
                frmMeasureCopyCriteriaCopy.SetSubmitCriteriaID(SubCritIDs);
                frmMeasureCopyCriteriaCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add")
                {
                    RefreshColSummaryDef();
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

        private void cmdCopyCriteriaSets_Click(object sender, EventArgs e)
        {
            int NewCritID;
            string NewCSet = null;
            string CSet = null;
            DialogResult resp;
            DataSet thisrs = new DataSet();

            try
            {

                modGlobal.gv_Action = "NotDefined";
                if (this.lstSummaryDef.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a criteria set to copy.");
                    return;
                }

                if (Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex) < 0)
                {
                    RadMessageBox.Show("Select a criteria set to copy.");
                    return;
                }

                resp = RadMessageBox.Show("Are you sure you want to create a new set as a copy of the selected set?", "Duplicate Criteria Set", MessageBoxButtons.YesNo, RadMessageIcon.Question);


                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "Select criteriaset from tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where submitcriteriaid = {1}", modGlobal.gv_sql, Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName17 = "tbl_setup_SubmitCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);
                    CSet = modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["CriteriaSet"].ToString();

                    modGlobal.gv_sql = "Select max(criteriaset) + 1 as newcset  from tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName18 = "tbl_setup_SubmitCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);
                    NewCSet = modGlobal.gv_rs.Tables[sqlTableName18].Rows[0]["NewCSet"].ToString();

                    modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                    modGlobal.gv_sql = modGlobal.gv_sql + " and criteriaset = " + CSet;
                    //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName19 = "";
                    thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, thisrs);

                    //LDW while (!thisrs.EOF)
                    foreach (DataRow myRow19 in thisrs.Tables[sqlTableName19].Rows)
                    {

                        NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");

                        modGlobal.gv_sql = "insert into tbl_setup_SubmitCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCriteriaID, subgroupid, CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, Value, DestDDID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, CriteriaSet)  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
                        modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", subgroupid, CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, Value, DestDDID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, " + NewCSet;
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCriteriaID = " + myRow19.Field<int>("SubmitCriteriaID");
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //LDW thisrs.MoveNext();
                    }

                    RefreshColSummaryDef();
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

        private void cmdDelCleanUpField_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCleanUpFields.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this field from the list?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupCrit ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCleanupID = " + Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupItems ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCleanupID = " + Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshCleanupFields();
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

        private void cmdDelError_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this error?", "Delete Error", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValidation ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    RefreshValidationMessages();
                    RefreshErrorCriteria();
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

        private void cmdDeleteWarning_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this warning?", "Delete Warning", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValidation ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    RefreshValidationMessages();
                    RefreshWarningCriteria();
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

        private void cmdDelSumCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                if (lstSummaryDef.SelectedIndex >= 0)
                {
                    modGlobal.gv_sql = "Delete tbl_Setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCriteriaID = " + Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                ResetCriteriaSetOrder();
                RefreshColSummaryDef();
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

        private void cmdDupSummarytoMeas_Click(object sender, EventArgs e)
        {
            frmMeasureCopyCriteria frmMeasureCopyCriteriaCopy = new frmMeasureCopyCriteria();

            try
            {
                modGlobal.gv_Action = "NotDefined";
                if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) < 0)
                {
                    RadMessageBox.Show("Select a summary to copy.");
                    return;
                }

                frmMeasureCopyCriteriaCopy.SetCopyType("S");
                frmMeasureCopyCriteriaCopy.SetSubGroupID(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"].ToString());
                frmMeasureCopyCriteriaCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add")
                {
                    RefreshColSummaryDef();
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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            Printer Printer = new Printer();
            int li_cnt = 0;

            try
            {
                Printer.Print("Data Submission Cleanup");

                for (li_cnt = 0; li_cnt <= lstRecordCleanupCriteria.Items.Count - 1; li_cnt++)
                {
                    Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstRecordCleanupCriteria, li_cnt));
                    //Printer.Print Tab(10); li_cnt
                }

                Printer.Print("End of Data Submission Cleanup");
                Printer.EndDoc();
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

        private void cmdPrintSummaryVal_Click(object sender, EventArgs e)
        {
            try
            {
                modDocumentation.PrintSummaryValidation();
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

        private void cmdRecordCleanupAdd_Click(object sender, EventArgs e)
        {
            int IDFromLookup = 0;
            string fieldLookupTableID = null;
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCleanupRecord", "SubmitCleanupRecordID");
            string field1type = null;


            try
            {
                if (cboRecordCleanupSet.SelectedIndex < 0 | string.IsNullOrEmpty(cboRecordCleanupJoinOperator.Text) | cboRecordCleanupField.SelectedIndex < 0 |
                    cboRecordCleanupOperator.SelectedIndex < 0 | (string.IsNullOrEmpty(txtRecordCleanupValue.Text) & chkRecordCleanupBlank.CheckState == 0 & cboRecordCleanupLookupList.SelectedIndex < 0))
                {
                    RadMessageBox.Show("Please define every piece of criteria before adding it.");
                    return;
                }

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(cboRecordCleanupField, cboRecordCleanupField.SelectedIndex);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName20].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();


                //make sure that the typed value is of the same type as the field type
                if (!string.IsNullOrEmpty(txtRecordCleanupValue.Text) & txtRecordCleanupValue.Visible == true)
                {
                    //If mid(field1type, 1, 3) = "Num" And Not IsNumeric(txtRecordCleanupValue) Then
                    if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtRecordCleanupValue.Text) & Strings.UCase(Strings.Trim(txtRecordCleanupValue.Text)) != "UTD")
                    {
                        RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
                        return;
                    }

                    if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtRecordCleanupValue.Text)) != "UTD")
                    {
                        if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtRecordCleanupValue.Text))
                        {
                            RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                            return;
                        }

                        if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtRecordCleanupValue.Text) != 5))
                        {
                            RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                            return;
                        }

                        if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 1, 1))) |
                            (!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 2, 1))) | (Strings.Mid(txtRecordCleanupValue.Text, 3, 1) != ":") |
                            (!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 5, 1)))))
                        {
                            RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                            return;
                        }

                        if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtRecordCleanupValue.Text, 1, 2)) > 23 |
                            Convert.ToDouble(Strings.Mid(txtRecordCleanupValue.Text, 4, 2)) > 59))
                        {
                            RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                            return;
                        }
                    }
                }


                CritTitle = string.Format("{0} {1}", cboRecordCleanupField.Text, cboRecordCleanupOperator.Text);

                if (!string.IsNullOrEmpty(txtRecordCleanupValue.Text))
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, txtRecordCleanupValue.Text);
                }

                fieldLookupTableID = " Null ";
                if (cboRecordCleanupLookupList.SelectedIndex > -1)
                {

                    CritTitle = CritTitle + " " + cboRecordCleanupLookupList.Text;

                    modGlobal.gv_sql = "Select *   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + Support.GetItemData(cboRecordCleanupLookupList, cboRecordCleanupLookupList.SelectedIndex);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName21 = "tbl_setup_Misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);

                    IDFromLookup = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName21].Rows[0]["Id"]);

                }

                if (chkRecordCleanupBlank.CheckState == CheckState.Checked)
                {
                    CritTitle = CritTitle + " Blank ";
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_SubmitCleanupRecord ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCleanupRecordID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Lookupid, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " State, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " RecordStatus ";
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRecordCleanupField, cboRecordCleanupField.SelectedIndex) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboRecordCleanupOperator.Text + "', ";
                if (!string.IsNullOrEmpty(txtRecordCleanupValue.Text) & txtRecordCleanupValue.Visible == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtRecordCleanupValue.Text + "',";
                }
                else if (chkRecordCleanupBlank.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
                }
                else if (cboRecordCleanupLookupList.SelectedIndex > -1 & cboRecordCleanupLookupList.Visible == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + IDFromLookup + "',";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                }
                if (cboRecordCleanupLookupList.SelectedIndex > -1 & cboRecordCleanupLookupList.Visible == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRecordCleanupLookupList, cboRecordCleanupLookupList.SelectedIndex) + ", ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboRecordCleanupJoinOperator.Text + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRecordCleanupSet, cboRecordCleanupSet.SelectedIndex) + ", ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and  '" + modGlobal.gv_State + "',";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshRecordCleanupCriteriaList();

                cboRecordCleanupField.SelectedIndex = -1;

                cboRecordCleanupOperator.SelectedIndex = -1;
                cboRecordCleanupOperator.Text = "";

                cboRecordCleanupJoinOperator.SelectedIndex = -1;
                cboRecordCleanupJoinOperator.Text = "";

                cboRecordCleanupSet.SelectedIndex = -1;
                cboRecordCleanupSet.Text = "";
                cboRecordCleanupSet.Enabled = true;

                chkRecordCleanupBlank.CheckState = CheckState.Unchecked;
                txtRecordCleanupValue.Text = "";
                cboRecordCleanupLookupList.SelectedIndex = -1;
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

        private void cmdRecordCleanupChangeOrAnd_Click(object sender, EventArgs e)
        {
            string CSet = null;
            string newjoinop = null;

            try
            {

                if (lstRecordCleanupCriteria.SelectedIndex < 0)
                {
                    return;
                }
                if (!(Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex) > 0))
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to Change the join operator?", "Change And/Or of the set", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.No))
                {
                    return;
                }

                newjoinop = "And";

                modGlobal.gv_sql = " select CriteriaSet, JoinOperator from tbl_setup_SubmitCleanupRecord  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupRecordID = " + Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_setup_SubmitCleanupRecord";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                CSet = modGlobal.gv_rs.Tables[sqlTableName22].Rows[0]["CriteriaSet"].ToString();

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName22].Rows[0]["JoinOperator"]))
                {
                    modGlobal.gv_sql = " select JoinOperator from tbl_setup_SubmitCleanupRecord  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupRecordID = " + Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName23 = "tbl_setup_SubmitCleanupRecord";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName23].Rows[0]["JoinOperator"].ToString() == "And")
                    {
                        newjoinop = "OR";
                    }
                    else
                    {
                        newjoinop = "And";
                    }
                }
                else
                {
                    if (modGlobal.gv_rs.Tables[sqlTableName22].Rows[0]["JoinOperator"].ToString() == "And")
                    {
                        newjoinop = "OR";
                    }
                    else
                    {
                        newjoinop = "And";
                    }
                }

                modGlobal.gv_sql = " Update tbl_setup_SubmitCleanupRecord  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + newjoinop + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet = " + CSet;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshRecordCleanupCriteriaList();
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

        private void cmdRecordCleanupRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRecordCleanupCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {

                    modGlobal.gv_sql = "Delete tbl_Setup_SubmitCleanupRecord ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupRecordID = " + Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshRecordCleanupCriteriaList();
                    //RefreshCriteriaSetList
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

        private void cmdRemoveCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) <= 0)
                {
                    return;
                }

                if (lstCategorySelectedList.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = " delete tbl_setup_submitSubGroupCategory ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " SubmitSubgroupCategoryid = " + Support.GetItemData(lstCategorySelectedList, lstCategorySelectedList.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshVerificationCategoriesSelected();
                RefreshVerificationCategories();
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

        private void cmdSelectCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) <= 0)
                {
                    return;
                }

                if (lstCategoryLookupList.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = " insert into tbl_setup_submitSubGroupCategory (Subgroupid, Measure_CatID)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values ( ";
                modGlobal.gv_sql = modGlobal.gv_sql + Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) + ",  ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstCategoryLookupList, lstCategoryLookupList.SelectedIndex) + ") ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshVerificationCategoriesSelected();
                RefreshVerificationCategories();
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

        private void cmdSubmissionPrint_Click(object sender, EventArgs e)
        {
            Printer Printer = new Printer();
            int li_cnt;
            //Printer.Print rdcSubmissionFieldList.Resultset!Description

            try
            {
                for (li_cnt = 0; li_cnt <= lstSummaryDef.Items.Count - 1; li_cnt++)
                {
                    Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstSummaryDef, li_cnt));
                    //Printer.Print Tab(10); li_cnt
                }

                Printer.EndDoc();
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

        private void cmdUpdateError_Click(object sender, EventArgs e)
        {
            frmSubmissionUpdateValidation frmSubmissionUpdateValidationCopy = new frmSubmissionUpdateValidation();


            try
            {
                modGlobal.gv_Action = "ERROR";
                frmSubmissionUpdateValidationCopy.ShowDialog();

                if (modGlobal.gv_Action == "Update")
                {
                    RefreshValidationMessages();
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

        private void cmdUpdateWarning_Click(object sender, EventArgs e)
        {
            frmSubmissionUpdateValidation frmSubmissionUpdateValidationCopy = new frmSubmissionUpdateValidation();

            try
            {
                modGlobal.gv_Action = "WARNING";
                frmSubmissionUpdateValidationCopy.ShowDialog();

                if (modGlobal.gv_Action == "Update")
                {
                    RefreshValidationMessages();
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

        private void cmdValidErrorAddCrit_Click(object sender, EventArgs e)
        {
            frmSubmissionValidCritWizard frmSubmissionValidCritWizardCopy = new frmSubmissionValidCritWizard();

            try
            {

                modGlobal.gv_Action = "ERROR";
                modGlobal.gv_ANDOR = "NotDefined";
                frmSubmissionValidCritWizardCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshErrorCriteria();
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

        private void cmdValidErrorAddCritAnd_Click(object sender, EventArgs e)
        {
            frmSubmissionValidCritWizard frmSubmissionValidCritWizardCopy = new frmSubmissionValidCritWizard();

            try
            {
                modGlobal.gv_Action = "ERROR";
                modGlobal.gv_ANDOR = "AND";
                frmSubmissionValidCritWizardCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshErrorCriteria();
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

        private void cmdValidErrorAddCritOr_Click(object sender, EventArgs e)
        {
            frmSubmissionValidCritWizard frmSubmissionValidCritWizardCopy = new frmSubmissionValidCritWizard();

            try
            {
                modGlobal.gv_Action = "ERROR";
                modGlobal.gv_ANDOR = "OR";
                frmSubmissionValidCritWizardCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshErrorCriteria();
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

        private void cmdValidErrorDeleteCrit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationErrorCriteria.Tables[rdcValidationErrorCriteriaTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationErrorCriteria.Tables[rdcValidationErrorCriteriaTable].Rows[0]["submitvalsetid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationErrorCriteria.Tables[rdcValidationErrorCriteriaTable].Rows[0]["submitvalsetid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationErrorCriteria.Tables[rdcValidationErrorCriteriaTable].Rows[0]["submitvalsetid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    RefreshErrorCriteria();
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

        private void cmdValidWarningAddCrit_Click(object sender, EventArgs e)
        {
            frmSubmissionValidCritWizard frmSubmissionValidCritWizardCopy = new frmSubmissionValidCritWizard();

            try
            {
                modGlobal.gv_Action = "WARNING";
                modGlobal.gv_ANDOR = "NotDefined";
                frmSubmissionValidCritWizardCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshWarningCriteria();
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

        private void cmdValidWarningAddCritAnd_Click(object sender, EventArgs e)
        {
            frmSubmissionValidCritWizard frmSubmissionValidCritWizardCopy = new frmSubmissionValidCritWizard();

            try
            {
                modGlobal.gv_Action = "WARNING";
                modGlobal.gv_ANDOR = "AND";
                frmSubmissionValidCritWizardCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshWarningCriteria();
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

        private void cmdValidWarningAddCritOr_Click(object sender, EventArgs e)
        {
            frmSubmissionValidCritWizard frmSubmissionValidCritWizardCopy = new frmSubmissionValidCritWizard();

            try
            {
                modGlobal.gv_Action = "WARNING";
                modGlobal.gv_ANDOR = "OR";
                frmSubmissionValidCritWizardCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshWarningCriteria();
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

        private void cmdValidWarningDeleteCrit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationWarningCriteria.Tables[rdcValidationWarningCriteriaTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationWarningCriteria.Tables[rdcValidationWarningCriteriaTable].Rows[0]["submitvalsetid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationWarningCriteria.Tables[rdcValidationWarningCriteriaTable].Rows[0]["submitvalsetid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationWarningCriteria.Tables[rdcValidationWarningCriteriaTable].Rows[0]["submitvalsetid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    RefreshWarningCriteria();
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

        private void frmSubmissionSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                ssTabSubmission.ActiveWindow = sstabValidation0;

                if (modGlobal.gv_status == "TEST")
                {
                    cmdChangeCleanupStatus.Text = "Move to Active";
                    cmdChangeWarningStatus.Text = "Move to Active";
                    cmdChangeErrorStatus.Text = "Move to Active";
                }
                else
                {
                    cmdChangeCleanupStatus.Text = "Move to Test";
                    cmdChangeWarningStatus.Text = "Move to Test";
                    cmdChangeErrorStatus.Text = "Move to Test";
                }

                //update null Main join operators
                modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator is null ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update null join operators
                modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator is null ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update any null criteria set, if any null exists
                modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet is null ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName24 = "tbl_Setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName24].Rows.Count > 0)
                {
                    ResetCriteriaSetOrderForAll();
                }

                RefreshPatientFieldsList();
                RefreshSumFieldList();
                RefreshIndicatorList();
                RefreshSubmissionDefList();
                RefreshColSummaryDef();
                //RefreshColSummaryDefWithVerif
                RefreshCleanupFields();
                RefreshLookupTables();
                RefreshValidationMessages();
                RefreshErrorCriteria();
                RefreshWarningCriteria();
                RefreshVerificationCategories();
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

        public void RefreshRecordCleanupSetDef()
        {
            try
            {
                if (cboRecordCleanupSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCleanupRecord ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaSet = " + Support.GetItemData(cboRecordCleanupSet, cboRecordCleanupSet.SelectedIndex);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName25 = "tbl_setup_SubmitCleanupRecord";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName25].Rows.Count == 0)
                {
                    cboRecordCleanupJoinOperator.Text = "";
                    cboRecordCleanupJoinOperator.Enabled = true;
                }
                else
                {
                    cboRecordCleanupJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["JoinOperator"].ToString();
                    cboRecordCleanupJoinOperator.Enabled = false;
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

        public void RefreshRecordCleanupCriteriaList()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex = 0;
            int TotalRec = 0;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec = 0;
            DataSet rs_critSet = new DataSet();

            try
            {

                lstRecordCleanupCriteria.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCleanupRecord ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '' or State is Null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " where  State = '" + modGlobal.gv_State + "'";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName26 = "tbl_setup_SubmitCleanupRecord";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, rs_critSet);

                if (rs_critSet.Tables[sqlTableName26].Rows.Count > 0)
                {
                    //LDW rs_critSet.MoveLast();
                    TotalSetRec = rs_critSet.Tables[sqlTableName26].Rows.Count;
                }
                else
                {
                    TotalSetRec = 0;
                }

                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow26 in rs_critSet.Tables[sqlTableName26].Rows)
                {
                    SetIndex = SetIndex - 1;
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupRecord ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaSet = " + myRow26.Field<string>("CriteriaSet");
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName27 = "tbl_setup_submitCleanupRecord";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName27].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    Cindex = 0;
                    CSuff = "";
                    CPref = "Set " + modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["CriteriaSet"] + ": (";

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow27 in modGlobal.gv_rs.Tables[sqlTableName27].Rows)
                    {
                        Cindex = Cindex + 1;
                        if (Cindex == TotalRec)
                        {
                            if (TotalRec == 1)
                            {
                                CSuff = " (" + myRow27.Field<string>("JoinOperator") + ") )";
                            }
                            else
                            {
                                CSuff = ")";
                            }
                        }
                        else
                        {
                            CSuff = " " + myRow27.Field<string>("JoinOperator");
                        }
                        if (Cindex == 1)
                        {
                            lstRecordCleanupCriteria.Items.Add(CPref + myRow27.Field<string>("CriteriaTitle") + CSuff);
                        }
                        else
                        {
                            lstRecordCleanupCriteria.Items.Add("          " + myRow27.Field<string>("CriteriaTitle") + CSuff);
                        }
                        Support.SetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.Items.Count - 1, myRow27.Field<int>("SUBMITCLEANUPRECORDID"));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (SetCount == TotalSetRec)
                    {
                    }
                    else
                    {
                        lstRecordCleanupCriteria.Items.Add(new ListBoxItem("OR", SetIndex).ToString());
                    }

                    //LDW rs_critSet.MoveNext();
                }


                RefreshRecordCleanupSetList();
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

        public void RefreshRecordCleanupSetList()
        {
            int oldindex = 0;
            int SetIndex = 0;
            DataSet thisrs = new DataSet();

            try
            {
                cboRecordCleanupSet.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCleanupRecord ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName28 = "tbl_setup_SubmitCleanupRecord";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);

                //Display the list of criteria
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow28 in modGlobal.gv_rs.Tables[sqlTableName28].Rows)
                {
                    SetIndex = SetIndex + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_SubmitCleanupRecord ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where criteriaSet = " + myRow28.Field<string>("CriteriaSet");
                    //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName29 = "tbl_setup_SubmitCleanupRecord";
                    thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, thisrs);


                    if (!string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        if (thisrs.Tables[sqlTableName29].Rows[0]["state"].ToString() == modGlobal.gv_State)
                        {
                            oldindex = SetIndex;
                        }
                        else
                        {
                            oldindex = 0;
                        }
                    }
                    else
                    {
                        oldindex = SetIndex;
                    }


                    if (!string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        if (thisrs.Tables[sqlTableName29].Rows[0]["RecordStatus"].ToString() == modGlobal.gv_status)
                        {
                            oldindex = SetIndex;
                        }
                        else if (oldindex != 0)
                        {
                            oldindex = 0;
                        }
                    }
                    else if (oldindex == 0)
                    {
                        oldindex = SetIndex;
                    }

                    if (SetIndex == oldindex)
                    {
                        cboRecordCleanupSet.Items.Add("Set " + SetIndex);
                        Support.SetItemData(cboRecordCleanupSet, cboRecordCleanupSet.Items.Count - 1, SetIndex);
                    }


                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                //always add a new one to the list in addition to the previous ones
                cboRecordCleanupSet.Items.Add(new ListBoxItem("Set " + SetIndex + 1, SetIndex + 1).ToString());
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

        public void RefreshPatientFieldsList()
        {
            var LIndex = 0;

            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_tabledef as td ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.BaseTableID =  td.BaseTableID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where upper(td.BaseTable) = 'PATIENT' ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName30 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName30, modGlobal.gv_rs);

                //Display the list of fields
                cboRecordCleanupField.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow30 in modGlobal.gv_rs.Tables[sqlTableName30].Rows)
                {
                    LIndex = LIndex + 1;
                    cboRecordCleanupField.Items.Add(new ListBoxItem(myRow30.Field<string>("FieldName"), myRow30.Field<int>("DDID")).ToString());
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

        public void ResetCriteriaSetOrder()
        {
            int j = 0;
            var i = 0;
            int MaxSet = 0;

            try
            {

                //update null join operators
                modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName31 = "tbl_Setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName31, modGlobal.gv_rs);
                //lstSummaryDef.ItemData(lstSummaryDef.ListIndex)
                //update the set order
                modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName32 = "tbl_Setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName32, modGlobal.gv_rs);
                MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName32].Rows[0]["MaxSet"]);
                if (MaxSet > 0)
                {
                    //give the max number to the null criteria set
                    modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName33 = "tbl_Setup_SubmitCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName33, modGlobal.gv_rs);

                    //adjust the order of the set
                    for (i = 1; i <= MaxSet; i++)
                    {
                        modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        if (modGlobal.gv_rs.Tables[sqlTableName33].Rows.Count == 0)
                        {
                            for (j = i; j <= MaxSet; j++)
                            {
                                modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + (j - 1);
                                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName34 = "tbl_Setup_SubmitCriteria";
                                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName34, modGlobal.gv_rs);
                            }
                        }
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

        public void ResetCriteriaSetOrderForAll()
        {
            int j;
            var i = 0;
            int MaxSet = 0;
            int SetNum = 0;
            DataSet rs_critSet = new DataSet();
            int SubGroupID = 0;
            DataSet rs_SubGroup = new DataSet();


            try
            {
                modGlobal.gv_sql = "Select SubGroupID from tbl_Setup_SubmitSubGroup ";
                //LDW rs_SubGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName35 = "tbl_Setup_SubmitSubGroup";
                rs_SubGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName35, rs_SubGroup);

                //LDW while (!rs_SubGroup.EOF)
                foreach (DataRow myRow35 in rs_SubGroup.Tables[sqlTableName35].Rows)
                {
                    SubGroupID = myRow35.Field<int>("SubGroupID");

                    //update any null criteria set
                    modGlobal.gv_sql = "Select CriteriaSet from tbl_Setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";

                    //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName36 = "tbl_Setup_SubmitCriteria";
                    rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName36, rs_critSet);

                    if (rs_critSet.Tables[sqlTableName36].Rows.Count == 0)
                    {
                        SetNum = 1;
                        //set all of them to a set number, if any criteria exists
                        modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";

                        //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName37 = "tbl_Setup_SubmitCriteria";
                        rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName37, rs_critSet);
                        if (rs_critSet.Tables[sqlTableName37].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            SetNum = SetNum + 1;
                        }

                        modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";

                        //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName38 = "tbl_Setup_SubmitCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName38, modGlobal.gv_rs);
                        if (rs_critSet.Tables[sqlTableName38].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }



                    //update the set order
                    modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                    //gv_sql = gv_sql & " and CriteriaSet is not null "
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName39 = "tbl_Setup_SubmitCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName39, modGlobal.gv_rs);
                    MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName39].Rows[0]["MaxSet"]);

                    if (MaxSet > 0)
                    {
                        //give the max number to the null criteria set
                        modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + (MaxSet + 1);
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName40 = "tbl_Setup_SubmitCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName40, modGlobal.gv_rs);

                        //adjust the order of the set
                        for (i = 1; i <= MaxSet; i++)
                        {
                            modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName41 = "tbl_Setup_SubmitCriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName41, modGlobal.gv_rs);

                            if (modGlobal.gv_rs.Tables[sqlTableName41].Rows.Count == 0)
                            {
                                for (j = i; j <= MaxSet; j++)
                                {
                                    modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                                    modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + (j - 1);
                                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName42 = "tbl_Setup_SubmitCriteria";
                                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName42, modGlobal.gv_rs);
                                }
                            }
                        }
                    }

                    //LDW rs_SubGroup.MoveNext();
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

        public void RefreshSubmissionDefList()
        {
            try
            {
                modGlobal.gv_sql = "Select g.*, c.showonreport as showcolonreport, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g left join tbl_Setup_SubmitGroupRow as r";
                modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_Setup_SubmitSubGroup as c ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.state = '' or g.state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where g.state = '" + modGlobal.gv_State + "'";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and g.RecordStatus = '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by g.Ordernumber, g.GroupName, r.OrderNumber, r.Title, c.OrderNumber, c.Title ";
                //g = InputBox("", "", gv_sql)
                //LDW rdcSubmissionFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcSubmissionFieldListTable = "tbl_setup_SubmitGroup";
                rdcSubmissionFieldList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcSubmissionFieldListTable, rdcSubmissionFieldList);
                rdcSubmissionFieldList.AcceptChanges();

                dbgSubmissionFieldList.Refresh();


                RefreshSubmissionDetails();
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

        private void lstCleanUpFields_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (lstCleanUpFields.SelectedIndex > -1)
                {
                    //gv_sql = "Select * from tbl_setup_submitCleanupItems "
                    //gv_sql = gv_sql & " where SubmitCleanupID = " & lstCleanUpFields.ItemData(lstCleanUpFields.ListIndex)
                    //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                    //txtCleanupDDID = gv_rs!DDID
                }
                RefreshCleanupFieldCriteria();
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

        public void RefreshSumFieldList()
        {

            try
            {
                //retrieve the list of Patient Table Fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_DataDef.FieldName ";

                //rdcSumFieldList.Refresh
                //LDW rdcSumFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcSumFieldListTable = "tbl_setup_DataDef";
                rdcSumFieldList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcSumFieldListTable, rdcSumFieldList);
                rdcSumFieldList.AcceptChanges();

                lstSumField.Items.Clear();
                cboCleanUpFieldToAdd.Items.Clear();

                //LDW while (!rdcSumFieldList.Resultset.EOF)
                foreach (DataRow myRow42 in rdcSumFieldList.Tables[rdcSumFieldListTable].Rows)
                {

                    lstSumField.Items.Add(new ListBoxItem(myRow42.Field<string>("FieldName"), myRow42.Field<int>("DDID")).ToString());

                    //also refresh the field list for clean up section
                    cboCleanUpFieldToAdd.Items.Add(new ListBoxItem(myRow42.Field<string>("FieldName"), myRow42.Field<int>("DDID")).ToString());

                    //LDW rdcSumFieldList.Resultset.MoveNext();
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

        public void RefreshIndicatorList()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {
                //retrieve the list of Indicators
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

                //rdcIndicatorList.Refresh
                //LDW rdcIndicatorList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcIndicatorListTable = "tbl_setup_Indicator";
                rdcIndicatorList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcIndicatorListTable, rdcIndicatorList);
                rdcIndicatorList.AcceptChanges();

                cboIndicator.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!rdcIndicatorList.Resultset.EOF)
                foreach (DataRow myRow43 in rdcIndicatorList.Tables[rdcIndicatorListTable].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    cboIndicator.Items.Add(new ListBoxItem(myRow43.Field<string>("Description"), myRow43.Field<int>("IndicatorID")).ToString());
                    //LDW rdcIndicatorList.Resultset.MoveNext();
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

        public void RefreshSubmissionDetails()
        {
            var LIndex = 0;
            var i = 0;


            try
            {
                cboIndicator.SelectedIndex = -1;
                chkIncludeGroup.CheckState = CheckState.Unchecked;
                chkDisplayGroupTitle.CheckState = CheckState.Unchecked;
                chkIncludeRow.CheckState = CheckState.Unchecked;
                chkIncludeCol.CheckState = CheckState.Unchecked;
                lstSumField.Items.Clear();
                cboSumOp.SelectedIndex = -1;


                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count > 0)
                {
                    if (!Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["IndicatorID"]))
                    {
                        for (i = 0; i <= cboIndicator.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(cboIndicator, i) == Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["IndicatorID"]))
                            {
                                cboIndicator.SelectedIndex = i;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }

                    if (!Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowGroupHeader"]))
                    {
                        if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowGroupHeader"].ToString() == "Y")
                        {
                            chkDisplayGroupTitle.CheckState = CheckState.Checked;
                        }
                    }

                    if (!Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowOnReport"]))
                    {
                        if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowOnReport"].ToString() == "Y")
                        {
                            chkIncludeGroup.CheckState = CheckState.Checked;
                        }
                    }

                    if (!Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowRowOnReport"]))
                    {
                        if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowRowOnReport"].ToString() == "Y")
                        {
                            chkIncludeRow.CheckState = CheckState.Checked;
                        }
                    }

                    if (!Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowcolOnReport"]))
                    {
                        if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["ShowcolOnReport"].ToString() == "Y")
                        {
                            chkIncludeCol.CheckState = CheckState.Checked;
                        }
                    }

                    if (!Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["AggregateFunction"]))
                    {
                        //cboSumOp.Text = rdcSubmissionFieldList.Resultset!AggregateFunction
                        for (i = 0; i <= cboSumOp.Items.Count - 1; i++)
                        {
                            if (Support.GetItemString(cboSumOp, i) == rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["AggregateFunction"].ToString())
                            {
                                cboSumOp.SelectedIndex = i;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }

                    modGlobal.gv_sql = "Select tbl_setup_SubmitSubGroupFields.*, tbl_setup_DataDef.FieldName ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitSubGroupFields inner join tbl_setup_DataDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_SubmitSubGroupFields.aggregatefieldid =  tbl_setup_DataDef.ddid ";
                    if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) > 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_SubmitSubGroupFields.SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_SubmitSubGroupFields.SubGroupID = -1 ";
                    }
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName44 = "tbl_setup_SubmitSubGroupFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName44, modGlobal.gv_rs);

                    LIndex = -1;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow44 in modGlobal.gv_rs.Tables[sqlTableName44].Rows)
                    {
                        LIndex = LIndex + 1;
                        lstSumField.Items.Add(new ListBoxItem(myRow44.Field<string>("FieldName"), myRow44.Field<int>("submitSubgroupFieldID")).ToString());
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    modGlobal.gv_rs.Dispose();

                    RefreshVerificationCategoriesSelected();

                    //CatID = -1
                    //For i = 0 To cboVerifCategory.ListCount - 1
                    //    If cboVerifCategory.ItemData(i) = rdcSubmissionFieldList.Resultset!Measure_CATID Then
                    //        CatID = i
                    //    End If
                    //Next i

                    //cboVerifCategory.ListIndex = CatID
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

        public void RefreshColSummaryDefold()
        {
            var LIndex = 0;
            int TotalRec;


            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                    }
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by joinOperator ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName45 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName45, modGlobal.gv_rs);

                lstSummaryDef.Items.Clear();

                if (modGlobal.gv_rs.Tables[sqlTableName45].Rows.Count == 0)
                {
                    return;
                }
                //LDW modGlobal.gv_rs.MoveLast();
                TotalRec = modGlobal.gv_rs.Tables[sqlTableName45].Rows.Count;
                //LDW modGlobal.gv_rs.MoveFirst();

                //Display the list of criteria

                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow45 in modGlobal.gv_rs.Tables[sqlTableName45].Rows)
                {
                    LIndex = LIndex + 1;

                    if (LIndex + 1 == TotalRec)
                    {
                        lstSummaryDef.Items.Add(myRow45.Field<string>("CriteriaTitle"));
                        //don't show join operator for the last line
                    }
                    else
                    {
                        lstSummaryDef.Items.Add(myRow45.Field<string>("CriteriaTitle") + " " + myRow45.Field<string>("JoinOperator"));
                    }
                    Support.SetItemData(lstSummaryDef, lstSummaryDef.Items.Count - 1, myRow45.Field<int>("SubmitCriteriaID"));
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

        public void RefreshCleanupFields()
        {
            try
            {
                modGlobal.gv_sql = "Select tbl_setup_SubmitCleanupItems.* , tbl_setup_DataDef.FieldName ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCleanupItems,tbl_setup_dataDef  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_SubmitCleanupItems.DDID = tbl_setup_dataDef.DDID  ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.state = '' or tbl_setup_SubmitCleanupItems.state is null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitCleanupItems.state = '" + modGlobal.gv_State + "'";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.RecordStatus = '' or tbl_setup_SubmitCleanupItems.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitCleanupItems.RecordStatus = '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName47 = "tbl_setup_SubmitCleanupItems";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName47, modGlobal.gv_rs);

                lstCleanUpFields.Items.Clear();

                //Display the list of fields to cleanup

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow47 in modGlobal.gv_rs.Tables[sqlTableName47].Rows)
                {
                    lstCleanUpFields.Items.Add(new ListBoxItem(myRow47.Field<string>("FieldName"), myRow47.Field<int>("SubmitCleanupID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                RefreshCleanupFieldCriteria();
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

        public void RefreshCleanupFieldCriteria()
        {
            var LIndex = 0;
            string CleanupJoinOperator = null;
            var TotalRec = 1;


            try
            {
                cmdCleanupAnd.Enabled = false;
                cmdCleanupOr.Enabled = false;
                cmdCleanupAddCrit.Enabled = true;
                txtJoinOperator.Text = "";

                modGlobal.gv_sql = "Select * from tbl_setup_SubmitCleanupCrit ";
                if (lstCleanUpFields.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupID = -1";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupID = " + Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by submitCleanupCritID ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName48 = "tbl_setup_SubmitCleanupCrit";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName48, modGlobal.gv_rs);

                lstCleanupCriteria.Items.Clear();
                if (modGlobal.gv_rs.Tables[sqlTableName48].Rows.Count == 0)
                {
                    return;
                }
                //LDW modGlobal.gv_rs.MoveLast();
                TotalRec = modGlobal.gv_rs.Tables[sqlTableName48].Rows.Count;
                //LDW modGlobal.gv_rs.MoveFirst();

                //Display the list of criteria
                CleanupJoinOperator = "";
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow48 in modGlobal.gv_rs.Tables[sqlTableName48].Rows)
                {
                    LIndex = LIndex + 1;

                    if (LIndex + 1 == TotalRec)
                    {
                        lstCleanupCriteria.Items.Add(myRow48.Field<string>("CriteriaDesc"));
                        //don't show join operator for the last line
                    }
                    else
                    {
                        lstCleanupCriteria.Items.Add(myRow48.Field<string>("CriteriaDesc") + " " + myRow48.Field<string>("JoinOperator"));
                    }
                    Support.SetItemData(lstCleanupCriteria, lstCleanupCriteria.Items.Count - 1, myRow48.Field<int>("SubmitCleanupCritID"));
                    CleanupJoinOperator = myRow48.Field<string>("JoinOperator");
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                if (LIndex == 0)
                {
                    cmdCleanupAnd.Enabled = true;
                    cmdCleanupOr.Enabled = true;
                    cmdCleanupAddCrit.Enabled = false;
                }
                else if (LIndex > 0)
                {
                    if (!Information.IsDBNull(CleanupJoinOperator))
                    {
                        txtJoinOperator.Text = CleanupJoinOperator;
                    }
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
            try
            {
                modGlobal.gv_sql = "Select *  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where TableType = 'LOOKUP' ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName49 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName49, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow49 in modGlobal.gv_rs.Tables[sqlTableName49].Rows)
                {
                    cboCleanupLookupTables.Items.Add(new ListBoxItem(myRow49.Field<string>("BaseTable"), myRow49.Field<int>("basetableid")).ToString());
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

        public void RefreshValidationMessages()
        {
            try
            {
                //retrieve the list of Validation Error messages
                modGlobal.gv_sql = "Select tbl_setup_submitValidation.*, tbl_setup_Indicator.Description as Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitValidation, tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_submitValidation.IndicatorID = tbl_setup_Indicator.IndicatorID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.ValType = 'ERROR' ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.state = '' or tbl_setup_submitValidation.state is null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.state = '" + modGlobal.gv_State + "'";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.RecordStatus = '' or tbl_setup_submitValidation.RecordStatus is null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.RecordStatus = '" + modGlobal.gv_status + "'";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_Indicator.Description ";

                //LDW rdcValidationErrors.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationErrorsTable = "tbl_setup_submitValidation";
                rdcValidationErrors = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationErrorsTable, rdcValidationErrors);
                rdcValidationErrors.AcceptChanges();


                //retrieve the list of Validation Warning messages
                modGlobal.gv_sql = "Select tbl_setup_submitValidation.*, tbl_setup_Indicator.Description as Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitValidation, tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_submitValidation.IndicatorID = tbl_setup_Indicator.IndicatorID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.ValType = 'WARNING' ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.state = '' or tbl_setup_submitValidation.state is null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.state = '" + modGlobal.gv_State + "'";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.RecordStatus = '' or tbl_setup_submitValidation.RecordStatus is null) ";
                }
                else
                {

                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.RecordStatus = '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_Indicator.Description ";

                //LDW rdcValidationWarnings.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationWarningsTable = "tbl_setup_submitValidation";
                rdcValidationWarnings = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationWarningsTable, rdcValidationWarnings);
                rdcValidationWarnings.AcceptChanges();
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

        public void RefreshErrorCriteria()
        {
            int TotalRec = 0;

            try
            {

                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitValSet ";
                //LDW if (rdcValidationErrors.Resultset.AbsolutePosition > 0)
                for (int i = 0; i < rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count; i++)
                {
                    DataRow dRow = rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[i];
                    int rowIndex = rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.IndexOf(dRow);

                    if (rowIndex > 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  " + rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  -1";
                    }
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName48 = "tbl_setup_SubmitValSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName48, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName48].Rows.Count > 0)
                {
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName48].Rows.Count;
                }
                modGlobal.gv_rs.Dispose();

                dbgValidationErrorCriteria.Refresh();
                //LDW rdcValidationErrorCriteria.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationErrorCriteriaTable = "tbl_setup_SubmitValSet";
                rdcValidationErrorCriteria = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationErrorCriteriaTable, rdcValidationErrorCriteria);
                rdcValidationErrorCriteria.AcceptChanges();

                //when there is only one criteria the next choice should be
                //defined by selecting AND or OR buttons
                //otherwise the join operator has already been defined from the previous selection
                if (TotalRec == 1)
                {
                    cmdValidErrorAddCritAnd.Enabled = true;
                    cmdValidErrorAddCritOr.Enabled = true;
                    cmdValidErrorAddCrit.Enabled = false;
                }
                else
                {
                    cmdValidErrorAddCritAnd.Enabled = false;
                    cmdValidErrorAddCritOr.Enabled = false;
                    cmdValidErrorAddCrit.Enabled = true;
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

        public void RefreshWarningCriteria()
        {
            int TotalRec = 0;

            try
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitValSet ";
                //LDW if (rdcValidationWarnings.Resultset.AbsolutePosition > 0)
                for (int i = 0; i < rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count; i++)
                {
                    DataRow dRow = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[i];
                    int rowIndex = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.IndexOf(dRow);

                    if (rowIndex > 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  " + rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  -1";
                    }
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName50 = "tbl_setup_SubmitValSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName50, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName50].Rows.Count > 0)
                {
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName50].Rows.Count;
                }
                modGlobal.gv_rs.Dispose();

                dbgValidationWarningCriteria.Refresh();

                //LDW rdcValidationWarningCriteria.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationWarningCriteriaTable = "tbl_setup_SubmitValSet";
                rdcValidationWarningCriteria = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationWarningCriteriaTable, rdcValidationWarningCriteria);
                rdcValidationWarningCriteria.AcceptChanges();

                //when there is only one criteria the next choice should be
                //defined by selecting AND or OR buttons
                //otherwise the join operator has already been defined from the previous selection

                if (TotalRec == 1)
                {
                    cmdValidWarningAddCritAnd.Enabled = true;
                    cmdValidWarningAddCritOr.Enabled = true;
                    cmdValidWarningAddCrit.Enabled = false;
                }
                else
                {
                    cmdValidWarningAddCritAnd.Enabled = false;
                    cmdValidWarningAddCritOr.Enabled = false;
                    cmdValidWarningAddCrit.Enabled = true;
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

        private void ssTabSubmission_SelectedTabChanged(object sender, Telerik.WinControls.UI.Docking.SelectedTabChangedEventArgs e)
        {
            try
            {
                lock (static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init)
                {
                    try
                    {
                        if (InitStaticVariableHelper(static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init))
                        {
                            //LDW static_ssTabSubmission_SelectedIndexChanged_PreviousTab = ssTabSubmission.SelectedIndex();
                            static_ssTabSubmission_SelectedIndexChanged_PreviousTab = ssTabSubmission.ActiveWindow.DockTabStrip.SelectedIndex;
                        }
                    }
                    finally
                    {
                        static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init.State = 1;
                    }
                }
                if (ssTabSubmission.ActiveWindow.DockTabStrip.SelectedIndex == 3)
                {
                    RefreshRecordCleanupCriteriaList();
                }
                static_ssTabSubmission_SelectedIndexChanged_PreviousTab = ssTabSubmission.ActiveWindow.DockTabStrip.SelectedIndex;
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

        private void txtRecordCleanupValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                chkRecordCleanupBlank.CheckState = CheckState.Unchecked;
                cboRecordCleanupLookupList.SelectedIndex = -1;
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

        private void txtTypeinValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cboCleanupValueList.SelectedIndex = -1;
                optCleanupValue.IsChecked = true;
                cboCleanupLookupTables.SelectedIndex = -1;
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

        public void RefreshColSummaryDef()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec;
            string MainJOp = null;
            DataSet rs_critSet = new DataSet();

            lstSummaryDef.Items.Clear();

            try
            {
                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                    }
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName51 = "tbl_setup_SubmitCriteria";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName51, rs_critSet);

                if (rs_critSet.Tables[sqlTableName51].Rows.Count == 0)
                {
                    return;
                }

                //find the main join Operator
                MainJOp = "And";
                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName52 = "tbl_setup_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName52, modGlobal.gv_rs);
                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName52].Rows[0]["JoinOperator"]))
                {
                    MainJOp = modGlobal.gv_rs.Tables[sqlTableName52].Rows[0]["JoinOperator"].ToString();
                }


                //LDW rs_critSet.MoveLast();
                TotalSetRec = rs_critSet.Tables[sqlTableName51].Rows.Count;
                //LDW rs_critSet.MoveFirst();

                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow51 in modGlobal.gv_rs.Tables[sqlTableName51].Rows)
                {
                    SetIndex = SetIndex - 1;
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
                    if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                    }
                    else
                    {
                        if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                        }
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + myRow51.Field<string>("CriteriaSet");

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName54 = "tbl_setup_SubmitCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName54, modGlobal.gv_rs);
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName54].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    Cindex = 0;
                    CSuff = "";
                    CPref = "Set " + modGlobal.gv_rs.Tables[sqlTableName54].Rows[0]["CriteriaSet"] + ": (";

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow54 in modGlobal.gv_rs.Tables[sqlTableName54].Rows)
                    {
                        Cindex = Cindex + 1;
                        if (Cindex == TotalRec)
                        {
                            if (TotalRec == 1)
                            {
                                CSuff = " (" + myRow54.Field<string>("JoinOperator") + ") )";
                            }
                            else
                            {
                                CSuff = ")";
                            }
                        }
                        else
                        {
                            CSuff = " " + myRow54.Field<string>("JoinOperator");
                        }
                        if (Cindex == 1)
                        {
                            lstSummaryDef.Items.Add(CPref + myRow54.Field<string>("CriteriaTitle") + CSuff);
                        }
                        else
                        {
                            lstSummaryDef.Items.Add("          " + myRow54.Field<string>("CriteriaTitle") + CSuff);
                        }
                        Support.SetItemData(lstSummaryDef, lstSummaryDef.Items.Count - 1, myRow54.Field<int>("SubmitCriteriaID"));


                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (SetCount == TotalSetRec)
                    {
                    }
                    else
                    {
                        lstSummaryDef.Items.Add(new ListBoxItem(MainJOp, SetIndex).ToString());
                    }


                    //LDW rs_critSet.MoveNext();
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

        public void RefreshColSummaryDefWithVerif()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec;
            string MainJOp = null;
            RadListControl lstSummaryDefWithVerif = new RadListControl();
            DataSet rs_critSet = new DataSet();


            try
            { 
                lstSummaryDefWithVerif.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_Setup_SubmitCriteriaWithVerif ";
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                    }
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName55 = "tbl_Setup_SubmitCriteriaWithVerif";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName55, rs_critSet);
                if (rs_critSet.Tables[sqlTableName55].Rows.Count == 0)
                {
                    return;
                }

                //find the main join Operator
                MainJOp = "And";
                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitSubGroup ";
                modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql, rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName56 = "tbl_setup_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName56, modGlobal.gv_rs);
                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName56].Rows[0]["JoinOperator"]))
                {
                    MainJOp = modGlobal.gv_rs.Tables[sqlTableName56].Rows[0]["JoinOperator"].ToString();
                }


                //LDW rs_critSet.MoveLast();
                TotalSetRec = rs_critSet.Tables[sqlTableName55].Rows.Count;
                //LDW rs_critSet.MoveFirst();

                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow55 in rs_critSet.Tables[sqlTableName55].Rows)
                {
                    SetIndex = SetIndex - 1;
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteriaWithVerif ";
                    if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                    }
                    else
                    {
                        if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                        }
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + myRow55.Field<string>("CriteriaSet");

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName57 = "tbl_Setup_SubmitCriteriaWithVerif";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName57, modGlobal.gv_rs);
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName57].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    Cindex = 0;
                    CSuff = "";
                    CPref = "Set " + modGlobal.gv_rs.Tables[sqlTableName57].Rows[0]["CriteriaSet"] + ": (";

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow57 in modGlobal.gv_rs.Tables[sqlTableName57].Rows)
                    {
                        Cindex = Cindex + 1;
                        if (Cindex == TotalRec)
                        {
                            if (TotalRec == 1)
                            {
                                CSuff = " (" + myRow57.Field<string>("JoinOperator") + ") )";
                            }
                            else
                            {
                                CSuff = ")";
                            }
                        }
                        else
                        {
                            CSuff = " " + myRow57.Field<string>("JoinOperator");
                        }
                        if (Cindex == 1)
                        {
                            lstSummaryDefWithVerif.Items.Add(CPref + myRow57.Field<string>("CriteriaTitle") + CSuff);
                        }
                        else
                        {
                            //LDW lstSummaryDefWithVerif.AddItem("          " + myRow58.Field<string>("CriteriaTitle") + CSuff);
                            lstSummaryDefWithVerif.Items.Add("          " + myRow57.Field<string>("CriteriaTitle") + CSuff);
                        }
                        //LDW lstSummaryDefWithVerif.ItemData(lstSummaryDefWithVerif.Items.Count - 1) = myRow57.Field<int>("SubmitCriteriaID");
                        Support.SetItemData(lstSummaryDefWithVerif, lstSummaryDefWithVerif.Items.Count - 1, myRow57.Field<int>("SubmitCriteriaID"));


                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (SetCount == TotalSetRec)
                    {
                    }
                    else
                    {
                        //LDW lstSummaryDefWithVerif.AddItem(MainJOp); 
                        lstSummaryDefWithVerif.Items.Add(MainJOp);
                        //LDW lstSummaryDefWithVerif.ItemData(lstSummaryDef.Items.Count - 1) = SetIndex;
                        Support.SetItemData(lstSummaryDefWithVerif, (lstSummaryDef.Items.Count - 1), SetIndex);
                    }


                    //LDW rs_critSet.MoveNext();
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

        public void RefreshVerificationCategories()
        {
            int li_SELcatID = -1;


            try
            {
                //On Error GoTo ErrHandler
                modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'CI'";
                modGlobal.gv_sql = modGlobal.gv_sql + " and Measure_CatID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select Measure_CatID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitsubgroupcategory ";
                if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid  = -1 ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY CAT";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName58 = "tbl_MEASURE_CAT";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName58, modGlobal.gv_rs);
                lstCategoryLookupList.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow58 in modGlobal.gv_rs.Tables[sqlTableName58].Rows)
                {
                    lstCategoryLookupList.Items.Add(new ListBoxItem(myRow58.Field<string>("CAT"), myRow58.Field<int>("measure_catid")).ToString());
                    //If CatID <> "" Then If gv_rs!Measure_CATID = CInt(CatID) Then li_SELcatID = cboCat.Items.Count-1
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

            //cboCat.ListIndex = li_SELcatID
        }

        public void RefreshVerificationCategoriesSelected()
        {
            var LIndex = 0;

            try
            {
                modGlobal.gv_sql = "SELECT sgcat.submitsubgroupcategoryid, mcat.cat ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_MEASURE_CAT mcat inner join tbl_setup_submitSubGroupCategory sgcat";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mcat.measure_catid = sgcat.measure_catid ";
                if (Convert.ToInt32(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]) > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE sgcat.subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"];
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where sgcat.subgroupid  = -1 ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY CAT";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName59 = "tbl_MEASURE_CAT";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName59, modGlobal.gv_rs);

                lstCategorySelectedList.Items.Clear();
                LIndex = -1;
                //LDW  while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow59 in modGlobal.gv_rs.Tables[sqlTableName59].Rows)
                {
                    LIndex = LIndex + 1;
                    lstCategorySelectedList.Items.Add(new ListBoxItem(myRow59.Field<string>("CAT"), myRow59.Field<int>("submitSubgroupCategoryID")).ToString());
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

        static bool InitStaticVariableHelper(StaticLocalInitFlag flag)
        {
             if (flag.State == 0)
                {
                    flag.State = 2;
                    return true;
                }
                else if (flag.State == 2)
                {
                    throw new IncompleteInitialization();
                }
                else
                {
                    return false;
                }
        }

    }
}
