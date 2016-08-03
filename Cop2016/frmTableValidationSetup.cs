using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmTableValidationSetup : Telerik.WinControls.UI.RadForm
    {
        object thismsgtype;
        object printval = new object();
        public DataSet rdcValidationErrors = new DataSet();
        string rdcValidationErrorsTable = null;
        public DataSet rdcValidationWarnings = new DataSet();
        string rdcValidationWarningsTable = null;
        public DataSet rdcValidationErrorAction = new DataSet();
        string rdcValidationErrorActionTable = null;
        public DataSet rdcValidationWarningAction = new DataSet();
        string rdcValidationWarningActionTable = null;
        public DataSet rdcTableList = new DataSet();
        string rdcTableListTable = null;
        public DataSet rdcValidationWarningCriteria = new DataSet();
        string rdcValidationWarningCriteriaTable = null;



        public frmTableValidationSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboTableList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int inc = 0;


            try
            {

                RefreshValidationMessages();

                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count > 0)
                {
                    //LDW rdcValidationErrors.Resultset.MoveFirst();
                    //maxRows = rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count;
                    //if (inc != maxRows - 1)
                    //{
                    //    inc++;
                    //    dRow = rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[inc];
                    //}
                }
                else
                {
                    RefreshErrorCriteriaSet();
                    RefreshErrorAction();
                }



                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count > 0)
                {
                    ////LDW rdcValidationWarnings.Resultset.MoveFirst();
                    //maxRows2 = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count;
                    //if (inc2 != maxRows2 - 1)
                    //{
                    //    inc2++;
                    //    dRow2 = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[inc2];
                    //}
                }
                else
                {
                    RefreshWarningCriteriaSet();
                    RefreshWarningAction();
                }

                sstabValidation.Enabled = true;
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
            frmTableValidationAddMsg frmTableValidationAddMsgCopy = new frmTableValidationAddMsg();

            try
            {

                modGlobal.gv_Action = "ERROR";
                frmTableValidationAddMsgCopy.ShowDialog();

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

        private void cmdAddErroraction_Click(object sender, EventArgs e)
        {
            frmTableValidationAddAction frmTableValidationAddActionCopy = new frmTableValidationAddAction();

            try
            {

                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count == 0)
                {
                    return;
                }

                modGlobal.gv_Action = "ERROR";
                frmTableValidationAddActionCopy.ShowDialog();

                if (modGlobal.gv_Action == "Update")
                {
                    RefreshErrorAction();
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
            frmTableValidationAddMsg frmTableValidationAddMsgCopy = new frmTableValidationAddMsg();

            try
            {

                modGlobal.gv_Action = "WARNING";
                frmTableValidationAddMsgCopy.ShowDialog();

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

        private void cmdAddWarningAction_Click(object sender, EventArgs e)
        {
            frmTableValidationAddAction frmTableValidationAddActionCopy = new frmTableValidationAddAction();

            try
            {

                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count == 0)
                {
                    return;
                }
                modGlobal.gv_Action = "WARNING";
                frmTableValidationAddActionCopy.ShowDialog();

                if (modGlobal.gv_Action == "Update")
                {
                    RefreshWarningAction();
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
                //LDW resp = RadMessageBox.Show("Are you sure you want this Error to the " + MoveToModule + " Module?", MsgBoxStyle.YesNo);
                resp = RadMessageBox.Show(this, string.Format("Are you sure you want this Error to the {0} Module?", MoveToModule), "Change Error Status", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_TablevalidationMessage ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where TableValidationMessageID = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshValidationMessages();
                RefreshErrorCriteria();
                RefreshErrorCriteriaSet();
                RefreshErrorAction();
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

                //LDW modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Warning to an Error?", MsgBoxStyle.YesNo, "Delete Criteria"));

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(this, "Are you sure you want to change this Warning to an Error?", "Delete Criteria",
                    MessageBoxButtons.YesNo, RadMessageIcon.Question));

                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set MessageType = 'ERROR' ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageID = {1}", modGlobal.gv_sql,
                        rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshValidationMessages();
                    RefreshWarningCriteria();
                    RefreshWarningAction();
                    RefreshErrorCriteria();
                    RefreshErrorAction();
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

                //LDW modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Error to an Warning?", MsgBoxStyle.YesNo, "Delete Criteria"));

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(this, "Are you sure you want to change this Error to an Warning?", "Delete Criteria",
                    MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set MessageType = 'WARNING' ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshValidationMessages();
                    RefreshWarningCriteria();
                    RefreshWarningAction();
                    RefreshErrorCriteria();
                    RefreshErrorAction();
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
                //LDW resp = RadMessageBox.Show("Are you sure you want this Warning to the " + MoveToModule + " Module?", MsgBoxStyle.YesNo);

                resp = RadMessageBox.Show(this, string.Format("Are you sure you want this Warning to the {0} Module?", MoveToModule),
                    "Change Warning Status", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_TablevalidationMessage ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where TableValidationMessageid = {1}", modGlobal.gv_sql, rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshValidationMessages();
                RefreshWarningCriteria();
                RefreshWarningCriteriaSet();
                RefreshWarningAction();
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

                //LDW modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this error?", MsgBoxStyle.YesNo, "Delete Error"));

                modGlobal.gv_resp = RadMessageBox.Show(this, "Are you sure you want to delete this error?", "Delete Error", MessageBoxButtons.YesNo, RadMessageIcon.Question).ToString();

                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {

                    modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid =  {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //gv_sql = "Delete tbl_setup_TableValidationAfterFieldUpdate "
                    //gv_sql = gv_sql & " Where TableValidationMessageid =  " & rdcValidationErrors.Resultset!TableValidationMessageID
                    //gv_cn.Execute gv_sql

                    modGlobal.gv_sql = "Delete tbl_setup_TableValidationMessage ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid =  {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_TableValidationAction ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid =  {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshValidationMessages();
                    RefreshErrorCriteria();
                    RefreshErrorCriteriaSet();
                    RefreshErrorAction();
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

        private void cmdDeleteErrorAction_Click(object sender, EventArgs e)
        {
            try
            {

                if (rdcValidationErrorAction.Tables[rdcValidationErrorActionTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this action?", "Delete Action", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes))
                {
                    modGlobal.gv_sql = "Delete tbl_setup_TableValidationAction ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationActionid =  {1}", modGlobal.gv_sql,
                        rdcValidationErrorAction.Tables[rdcValidationErrorActionTable].Rows[0]["TableValidationActionID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshErrorAction();
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


                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(this, "Are you sure you want to delete this warning?", "Delete Warning", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid =  {1}", modGlobal.gv_sql,
                        rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_TableValidationAfterFieldUpdate ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid =  {1}", modGlobal.gv_sql,
                        rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    modGlobal.gv_sql = "Delete tbl_setup_TableValidationMessage ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid =  {1}", modGlobal.gv_sql,
                        rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_TableValidationAction ";
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageid =  {1}", modGlobal.gv_sql,
                        rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshValidationMessages();
                    RefreshWarningCriteria();
                    RefreshWarningCriteriaSet();
                    RefreshWarningAction();
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
        //Not used
        /*private void cmdPrintVal_Click()
        {
            PrintValidation();
        }*/

        private void cmdDupError_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count <= 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria set to copy.");

                    DialogResult ds = RadMessageBox.Show(this, "Select one criteria set to copy.", "Dup Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds.ToString();
                    return;
                }
                DuplicateMessage(Convert.ToInt32(this.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]), "ERROR");
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


        private void DuplicateMessage(int TableValidationMessageID, string MessageType)
        {
            SqlCommand ps = new SqlCommand();

            //LDW if (RadMessageBox.Show("Are you sure you want to duplicate?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)

            try
            {
                if (RadMessageBox.Show(this, "Are you sure you want to duplicate?", "Duplicate Message", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    /*LDW modGlobal.gv_sql = "{ ? = call COPYTableValidationToError(?,?) }";
                    ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                    ps(0).Direction = RDO.DirectionConstants.rdParamReturnValue;
                    ps(1).Direction = RDO.DirectionConstants.rdParamInput;
                    ps.rdoParameters(1) = TableValidationMessageID;
                    ps.rdoParameters(2) = MessageType;
                    ps.Execute();
                    ps.Close();*/
                    ps.Connection = modGlobal.gv_cn;
                    ps.CommandType = CommandType.StoredProcedure;
                    ps.CommandText = "COPYTableValidationToError";
                    var inParam1 = new SqlParameter("@TableValidationMessageID", TableValidationMessageID);
                    inParam1.Direction = ParameterDirection.Input;
                    inParam1.DbType = DbType.Int32;
                    ps.Parameters.Add(inParam1);
                    var inParam2 = new SqlParameter("@MessageType", MessageType);
                    inParam2.Direction = ParameterDirection.Input;
                    inParam2.DbType = DbType.String;
                    ps.Parameters.Add(inParam2);
                    SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                    retParam1.Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        ps.Connection.Open();
                        ps.ExecuteNonQuery();
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Error while opening connection: " + exx.Message);
                    }
                    finally
                    {
                        ps.Dispose();
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

        private void cmdDupWarn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count <= 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria set to copy.");

                    DialogResult ds2 = RadMessageBox.Show(this, "Select one criteria set to copy.", "Dup Warn", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Text = ds2.ToString();
                    return;
                }
                DuplicateMessage(Convert.ToInt32(this.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]), "WARNING");

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

        private void cmdErrorCopySet_Click(object sender, EventArgs e)
        {
            frmValidationCopyCriteriaSet frmValidationCopyCriteriaSetCopy = new frmValidationCopyCriteriaSet();

            try
            {

                if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to copy");

                    DialogResult ds10 = RadMessageBox.Show(this, "Please choose 1 criteria to copy", "Error Copy Set", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds10.ToString();
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to COPY this criteria?", "COPY Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    var refItem = Support.GetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex);
                    frmValidationCopyCriteriaSetCopy.SetTableValidationID(refItem);
                    frmValidationCopyCriteriaSetCopy.ShowDialog();
                    RefreshErrorCriteriaSet();
                }
                return;
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

        private void cmdExportValidation_Click(object sender, EventArgs e)
        {
            frmValidationCopyCriteriaSet frmValidationCopyCriteriaSetCopy = new frmValidationCopyCriteriaSet();

            try
            {

                if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to copy");

                    DialogResult ds11 = RadMessageBox.Show(this, "Please choose 1 criteria to copy", "Error Copy Set", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds11.ToString();
                    return;
                }

                //LDW modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to COPY this criteria?", MsgBoxStyle.YesNo, "COPY Criteria"));

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(this, "Are you sure you want to COPY this criteria?", "Export Validation", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    int refItem2 = Support.GetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex);
                    frmValidationCopyCriteriaSetCopy.SetTableValidationID(refItem2);
                    frmValidationCopyCriteriaSetCopy.ShowDialog();

                    RefreshErrorCriteriaSet();
                }
                return;
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

        private void cmdRightLookup_Click(object sender, EventArgs e)
        {
            dlgValidationRightField dlgValidationRightFieldCopy = new dlgValidationRightField();

            try
            {

                if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to modify");

                    DialogResult ds12 = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Right Lookup", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds12.ToString();
                    return;
                }

                var refItem3 = Support.GetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex);
                dlgValidationRightFieldCopy.SetTableValidationID(refItem3);
                dlgValidationRightFieldCopy.ShowDialog();


                //RefreshMeasureCriteria
                RefreshErrorCriteriaSet();
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
            frmTableValidationUpdateMsg frmTableValidationUpdateMsgCopy = new frmTableValidationUpdateMsg();

            try
            {

                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_Action = "WARNING";
                frmTableValidationUpdateMsgCopy.ShowDialog();

                if (modGlobal.gv_Action == "Update")
                {
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

        private void cmdUpdateError_Click(object sender, EventArgs e)
        {
            frmTableValidationUpdateMsg frmTableValidationUpdateMsgCopy = new frmTableValidationUpdateMsg();

            try
            {

                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_Action = "ERROR";
                frmTableValidationUpdateMsgCopy.ShowDialog();

                if (modGlobal.gv_Action == "Update")
                {
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

        private void cmdValidErrorAddCrit_Click(object sender, EventArgs e)
        {

            frmTableValidationAddCrit frmTableValidationAddCritCopy = new frmTableValidationAddCrit();

            try
            {

                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count == 0)
                {
                    return;
                }
                modGlobal.gv_Action = "Error";
                frmTableValidationAddCritCopy.ShowDialog();
                RefreshErrorCriteriaSet();
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
            frmTableValidationAddCrit frmTableValidationAddCritCopy = new frmTableValidationAddCrit();

            try
            {

                modGlobal.gv_Action = "ERROR";
                modGlobal.gv_ANDOR = "AND";
                frmTableValidationAddCritCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshErrorCriteriaSet();
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
            frmTableValidationAddCrit frmTableValidationAddCritCopy = new frmTableValidationAddCrit();

            try
            {

                modGlobal.gv_Action = "ERROR";
                modGlobal.gv_ANDOR = "OR";
                frmTableValidationAddCritCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshErrorCriteriaSet();
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

        private void cmdValidErrorChangemainjoinop_Click(object sender, EventArgs e)
        {
            string newjoinop = null;
            string mainjoinop = null;

            try
            {

                if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to modify");

                    DialogResult ds13 = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Error Change mainjoinop", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds13.ToString();
                    return;
                }


                modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
                modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName15 = "tbl_setup_tablevalidationmessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName15].Rows[0]["JoinOperator"]))
                {
                    return;
                }
                else
                {
                    mainjoinop = modGlobal.gv_rs.Tables[sqlTableName15].Rows[0]["JoinOperator"].ToString();
                }

                if (mainjoinop == "OR")
                {
                    newjoinop = "AND";
                }
                else
                {
                    newjoinop = "OR";
                }


                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(string.Format("Are you sure you want to change the Join Operator from {0} to {1}?",
                    mainjoinop, newjoinop), "Change to And/Or between sets", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
                    modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, newjoinop);
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageID = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshErrorCriteriaSet();
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
            int li_cnt = 0;

            try
            {

                if (lstErrorCriteriaSet.SelectedItems.Count == 0)
                {
                    return;
                }

                //LDW modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", MsgBoxStyle.YesNo, "Delete Criteria"));

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(this, "Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    //loop through all selected criteria
                    for (li_cnt = 0; li_cnt <= lstErrorCriteriaSet.Items.Count - 1; li_cnt++)
                    {
                        //LDW if (lstErrorCriteriaSet.GetSelected(li_cnt))
                        if (lstErrorCriteriaSet.SelectedIndex == li_cnt)
                        {
                            modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
                            modGlobal.gv_sql = string.Format("{0} Where TableValidationID = {1}", modGlobal.gv_sql, Support.GetItemData(lstErrorCriteriaSet, li_cnt));

                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }
                    RefreshErrorCriteriaSet();
                }
                return;
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

            //    If rdcValidationErrorCriteria.Resultset.RowCount <= 0 Then
            //        Exit Sub
            //    End If
            //
            //    gv_resp = MsgBox("Are you sure you want to delete this criteria?", vbYesNo, "Delete Criteria")
            //    If gv_resp = vbYes Then
            //        gv_sql = "Delete tbl_setup_TableValidation "
            //        gv_sql = gv_sql & " Where TableValidationID = " & rdcValidationErrorCriteria.Resultset!TableValidationID
            //
            //        gv_cn.Execute gv_sql
            //
            //        RefreshErrorCriteriaSet
            //    End If
        }

        private void cmdValidErrorEditLeft_Click(object sender, EventArgs e)
        {
            dlgValidationField dlgValidationFieldCopy = new dlgValidationField();

            try
            {

                if (lstErrorCriteriaSet.SelectedIndex < 0 | lstErrorCriteriaSet.SelectedItems.Count > 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to modify");

                    DialogResult ds14 = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Left Edit Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds14.ToString();
                    return;
                }

                var refItem6 = Support.GetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex);
                dlgValidationFieldCopy.SetTableValidationID(refItem6);
                dlgValidationFieldCopy.ShowDialog();

                //RefreshMeasureCriteria

                RefreshErrorCriteriaSet();
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
            frmTableValidationAddCrit frmTableValidationAddCritCopy = new frmTableValidationAddCrit();

            try
            {

                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count == 0)
                {
                    return;
                }
                modGlobal.gv_Action = "Warning";
                frmTableValidationAddCritCopy.ShowDialog();
                RefreshWarningCriteriaSet();
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
            frmTableValidationAddCrit frmTableValidationAddCritCopy = new frmTableValidationAddCrit();

            try
            {

                modGlobal.gv_Action = "WARNING";
                modGlobal.gv_ANDOR = "AND";
                frmTableValidationAddCritCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshWarningCriteriaSet();
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
            frmTableValidationAddCrit frmTableValidationAddCritCopy = new frmTableValidationAddCrit();

            try
            {

                modGlobal.gv_Action = "WARNING";
                modGlobal.gv_ANDOR = "OR";
                frmTableValidationAddCritCopy.ShowDialog();
                if (modGlobal.gv_Action == "Add")
                {
                    RefreshWarningCriteriaSet();
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

        private void cmdValidWarningChangemainjoinop_Click(object sender, EventArgs e)
        {
            string newjoinop = null;
            string mainjoinop = null;

            try
            {

                if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to modify");

                    DialogResult ds15 = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Warning Change mainjoinop", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds15.ToString();
                    return;
                }

                modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
                modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "tbl_setup_tablevalidationmessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["JoinOperator"]))
                {
                    return;
                }
                else
                {
                    mainjoinop = modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["JoinOperator"].ToString();
                }

                if (mainjoinop == "OR")
                {
                    newjoinop = "AND";
                }
                else
                {
                    newjoinop = "OR";
                }

                //LDW modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change the Join Operator from " + mainjoinop + " to " 
                //+ newjoinop + "?", MsgBoxStyle.YesNo, "Change to And/Or between sets"));

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(this, string.Format("Are you sure you want to change the Join Operator from {0} to {1}?",
                    mainjoinop, newjoinop), "Change to And/Or between sets", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(MsgBoxResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_TableValidationMessage ";
                    modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, newjoinop);
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageID = {1}", modGlobal.gv_sql,
                        rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshWarningCriteriaSet();
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
            int li_cnt = 0;

            try
            {

                if (lstWarningCriteriaSet.SelectedItems.Count == 0)
                {
                    return;
                }

                //LDW modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", MsgBoxStyle.YesNo, "Delete Criteria"));
                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(this, "Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    //loop through all selected criteria
                    for (li_cnt = 0; li_cnt <= lstWarningCriteriaSet.Items.Count - 1; li_cnt++)
                    {
                        if (lstWarningCriteriaSet.SelectedIndex == li_cnt)
                        {
                            modGlobal.gv_sql = "Delete tbl_setup_TableValidation ";
                            modGlobal.gv_sql = string.Format("{0} Where TableValidationID = {1}", modGlobal.gv_sql, Support.GetItemData(lstWarningCriteriaSet, li_cnt));

                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }
                    RefreshWarningCriteriaSet();
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

        private void cmdValidWarningEditLeft_Click(object sender, EventArgs e)
        {
            dlgValidationField dlgValidationFieldCopy = new dlgValidationField();

            try
            {

                if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1)
                {
                    RadMessageBox.Show("Please choose 1 criteria to modify");
                    return;
                }

                var refItem8 = Support.GetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex);
                dlgValidationFieldCopy.SetTableValidationID(refItem8);
                dlgValidationFieldCopy.ShowDialog();

                //RefreshMeasureCriteria

                RefreshErrorCriteriaSet();
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

        private void cmdWarnCopySet_Click(object sender, EventArgs e)
        {
            frmValidationCopyCriteriaSet frmValidationCopyCriteriaSetCopy = new frmValidationCopyCriteriaSet();

            try
            {

                if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1)
                {
                    DialogResult ds15 = RadMessageBox.Show(this, "Please choose 1 criteria to copy", "Warning Copy Set", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds15.ToString();
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to COPY this criteria?", "COPY Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    int refItem6 = Support.GetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex);
                    frmValidationCopyCriteriaSetCopy.SetTableValidationID(refItem6);
                    frmValidationCopyCriteriaSetCopy.ShowDialog();

                    RefreshWarningCriteriaSet();
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

        private void CmdWarningRight_Click(object sender, EventArgs e)
        {
            dlgValidationRightField dlgValidationRightFieldCopy = new dlgValidationRightField();

            try
            {

                if (lstWarningCriteriaSet.SelectedIndex < 0 | lstWarningCriteriaSet.SelectedItems.Count > 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to modify");

                    DialogResult ds16 = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Warning Right", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds16.ToString();
                    return;
                }
                var refItem7 = Support.GetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex);
                dlgValidationRightFieldCopy.SetTableValidationID(refItem7);
                dlgValidationRightFieldCopy.ShowDialog();

                //RefreshMeasureCriteria

                RefreshErrorCriteriaSet();
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

        private void cmdWarningDupError_Click(object sender, EventArgs e)
        {

            try
            {
                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count <= 0)
                {
                    //LDW RadMessageBox.Show("Select one Message to copy.");

                    DialogResult ds17 = RadMessageBox.Show(this, "Select one Message to copy.", "Warning Dup Error", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Text = ds17.ToString();

                    return;
                }

                DuplicateMessage(Convert.ToInt32(rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]), "ERROR");

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

        private void cmdWarningDupWarning_Click(object sender, EventArgs e)
        {

            try
            {
                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count <= 0)
                {
                    //LDW RadMessageBox.Show("Select one Message to copy.");

                    DialogResult ds18 = RadMessageBox.Show(this, "Select one Message to copy.", "Warning Dup Warning", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Text = ds18.ToString();

                    return;
                }

                DuplicateMessage(Convert.ToInt32(rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]), "WARNING");

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

        private void Command1_Click(object sender, EventArgs e)
        {
            Printer Printer = new Printer();
            int Index = 0;
            int li_cnt = 0;

            try
            {

                //LDW if (sstabValidation.SelectedIndex == 0)
                if (sstabValidationErrors.Focused)
                {
                    //Printer.Print rdcValidationErrors.Resultset!Message
                    //LDW Printer.Print(dbgSubmitErrors.get_Columns(1).Text);
                    Printer.Print(dbgSubmitErrors.Columns[1].ToString());

                    for (li_cnt = 0; li_cnt <= lstErrorCriteriaSet.Items.Count - 1; li_cnt++)
                    {
                        Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstErrorCriteriaSet, li_cnt));
                    }
                }
                else
                {
                    //Printer.Print rdcValidationWarnings.Resultset!Message
                    Printer.Print(dbgSubmitWarnings.Columns[1].ToString());

                    for (li_cnt = 0; li_cnt <= lstWarningCriteriaSet.Items.Count - 1; li_cnt++)
                    {
                        Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstWarningCriteriaSet, li_cnt));
                    }
                }

                Printer.Print("End of Validation");
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

        private void frmTableValidationSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            //LDW sstabValidation.SelectedIndex = 0;


            try
            {
                sstabValidation.ActiveWindow.DockTabStrip.SelectedIndex = 0;
                printval = "";

                if (modGlobal.gv_status == "TEST")
                {
                    cmdChangeWarningStatus.Text = "Move to Active";
                    cmdChangeErrorStatus.Text = "Move to Active";
                }
                else
                {
                    cmdChangeWarningStatus.Text = "Move to Test";
                    cmdChangeErrorStatus.Text = "Move to Test";
                }

                RefreshDataTableList();
                sstabValidation.Enabled = false;
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
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidation ";
                //LDW if (rdcValidationWarnings.Resultset.AbsolutePosition > 0)
                for (int i = 0; i < rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count; i++)
                {
                    var dRow5 = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[i];
                    int rowIndex = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.IndexOf(dRow5);
                    if (rowIndex > 0)
                    {
                        modGlobal.gv_sql = string.Format("{0} where TableValidationMessageID =  {1}", modGlobal.gv_sql,
                            rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID =  -1";
                    }
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_TableValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName20].Rows.Count > 0)
                {
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName20].Rows.Count;
                }
                modGlobal.gv_rs.Dispose();

                dbgSubmitWarnings.Refresh();
                //LDW rdcValidationWarningCriteria.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationWarningCriteria = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationWarningCriteriaTable, rdcValidationWarningCriteria);

                //LDW rdcValidationWarningCriteria.CtlRefresh();

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

        public void RefreshValidationMessages()
        {

            try
            {
                //retrieve the list of Validation Error messages
                modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'ERROR' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
                // 3.17.2005 - order by message

                //LDW rdcValidationErrors = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationErrorsTable = "tbl_setup_TableValidationMessage";
                rdcValidationErrors = DALcop.DalConnectDataSet(modGlobal.gv_sql, modGlobal.gv_sql, rdcValidationErrorsTable, rdcValidationErrors);
                //LDW rdcValidationErrors.CtlRefresh();

                //retrieve the list of Validation Warning messages
                modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'WARNING' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
                //3.17.2005 = order by message

                //LDW rdcValidationWarnings.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationWarningsTable = "tbl_setup_TableValidationMessage";
                rdcValidationWarnings = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationWarningsTable, rdcValidationWarnings);
                //LDW rdcValidationWarnings.CtlRefresh();
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
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidation ";
                //LDW if (rdcValidationErrors.Resultset.AbsolutePosition > 0)
                for (int i = 0; i < rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count; i++)
                {
                    var dRow4 = rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[i];
                    int rowIndex = rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.IndexOf(dRow4);
                    if (rowIndex > 0)
                    {
                        modGlobal.gv_sql = string.Format("{0} where TableValidationMessageID =  {1}", modGlobal.gv_sql,
                            rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID =  -1";
                    }
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_TableValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName11].Rows.Count > 0)
                {
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName11].Rows.Count;
                    //modGlobal.gv_rs.MoveLast();
                }
                modGlobal.gv_rs.Dispose();



                //dbgValidationErrorCriteria.Refresh
                //Set rdcValidationErrorCriteria.Resultset = gv_cn.OpenResultset(gv_sql, rdOpenStatic)

                //when there is only one criteria the next choice should be
                //defined by selecting AND or OR buttons
                //otherwise the join operator has already been defined from the previous selection
                if (TotalRec == 1)
                {
                    cmdValidErrorAddCritAnd.Enabled = true;
                    cmdValidErrorAddCritOr.Enabled = true;
                    cmdValidErrorAddCrit.Enabled = false;
                    cmdValidErrorChangemainjoinop.Enabled = false;
                }
                else
                {
                    cmdValidErrorAddCritAnd.Enabled = false;
                    cmdValidErrorAddCritOr.Enabled = false;
                    cmdValidErrorAddCrit.Enabled = true;
                    cmdValidErrorChangemainjoinop.Enabled = true;
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

        public void RefreshDataTableList()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {

                //retrieve the list of batch types
                modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where TableType is null or TableType = 'DATA' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

                //rdcTableList.Refresh
                //LDW rdcTableList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcTableListTable = "tbl_setup_TableDef";
                rdcTableList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTableListTable, rdcTableList);
                //rdcTableList.CtlRefresh();

                cboTableList.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!rdcTableList.Resultset.EOF)
                foreach (DataRow myRow8 in rdcTableList.Tables[rdcTableListTable].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    cboTableList.Items.Add(myRow8.Field<string>("BaseTable"));
                    cboTableList.Items.Add(myRow8.Field<string>("basetableid"));
                    //LDW rdcTableList.Resultset.MoveNext();
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

        //I don't think this is need since moving from MSRDC to data sets
        private void rdcValidationErrors_Reposition()
        {
            RefreshErrorCriteriaSet();
            RefreshErrorAction();
        }

        //I don't think this is need since moving from MSRDC to data sets
        private void rdcValidationWarnings_Reposition()
        {
            RefreshWarningCriteriaSet();
            RefreshWarningAction();
        }

        public void RefreshWarningAction()
        {
            int TotalRec = 0;


            try
            {

                modGlobal.gv_sql = "Select tv.*, dd.fieldname + ' = ' + tv.setvalue as TakeAction ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationAction as tv,  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_DataDef as dd  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tv.ddid = dd.ddid ";

                //LDW if (rdcValidationWarnings.Resultset.AbsolutePosition > 0)
                for (int i = 0; i < rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count; i++)
                {
                    var dRow3 = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[i];
                    int rowIndex = rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.IndexOf(dRow3);
                    if (rowIndex > 0)
                    {
                        modGlobal.gv_sql = string.Format("{0} and tv.TableValidationMessageID =  {1}", modGlobal.gv_sql,
                            rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and tv.TableValidationMessageID =  -1";
                    }
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_TableValidationAction";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                //LDW if (modGlobal.gv_rs.RowCount > 0)
                if (modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count > 0)
                {
                    //modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count;
                }
                modGlobal.gv_rs.Dispose();

                //LDW rdcValidationWarningAction.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationWarningActionTable = "tbl_setup_TableValidationAction";
                rdcValidationWarningAction = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationWarningActionTable, rdcValidationWarningAction);
                //LDW rdcValidationWarningAction.CtlRefresh();
                dbgValidationWarningAction.Refresh();
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


        public void RefreshErrorAction()
        {
            int TotalRec = 0;

            try
            {

                modGlobal.gv_sql = "Select tv.*, dd.fieldname + ' = ' + tv.setvalue as TakeAction ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationAction as tv,  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_DataDef as dd  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tv.ddid = dd.ddid ";
                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count > 0)
                {
                    modGlobal.gv_sql = string.Format("{0} and tv.TableValidationMessageID =  {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tv.TableValidationMessageID =  -1";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_TableValidationAction";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)
                {
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count;
                }
                modGlobal.gv_rs.Dispose();


                //LDW rdcValidationErrorAction.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcValidationErrorActionTable = "tbl_setup_TableValidationAction";
                rdcValidationErrorAction = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcValidationErrorActionTable, rdcValidationErrorAction);

                rdcValidationErrorAction.AcceptChanges();
                dbgValidationErrorAction.Refresh();
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

        public void RefreshErrorCriteriaSet()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex = 0;
            int TotalRec = 0;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec = 0;
            string mainjoinop = null;
            var rs_critSet = new DataSet();


            try
            {

                lstErrorCriteriaSet.Items.Clear();

                mainjoinop = "";

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_TableValidation ";
                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = -1";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_TableValidation";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, rs_critSet);

                if (rs_critSet.Tables[sqlTableName2].Rows.Count == 0)
                {
                    cmdValidErrorAddCritAnd.Enabled = false;
                    cmdValidErrorAddCritOr.Enabled = false;
                    cmdValidErrorAddCrit.Enabled = true;
                    cmdValidErrorChangemainjoinop.Enabled = true;
                    return;
                }


                if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count > 0)
                {
                    modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName3 = "tbl_setup_tablevalidationmessage";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["JoinOperator"]))
                    {
                        mainjoinop = modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["JoinOperator"].ToString();
                    }
                }

                //LDW rs_critSet.MoveLast();
                TotalSetRec = rs_critSet.Tables[sqlTableName2].Rows.Count;
                //LDW rs_critSet.MoveFirst();

                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow1 in rs_critSet.Tables[sqlTableName2].Rows)
                {
                    SetIndex = SetIndex - 1;
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_tablevalidation ";
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                    modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, myRow1.Field<string>("CriteriaSet"));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName4 = "tbl_setup_tablevalidation";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    Cindex = 0;
                    CSuff = "";
                    CPref = string.Format("Set {0}: (", modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["CriteriaSet"]);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                    {
                        Cindex = Cindex + 1;
                        if (Cindex == TotalRec)
                        {
                            if (TotalRec == 1)
                            {
                                CSuff = string.Format(" ({0}) )", myRow2.Field<string>("JoinOperator"));
                            }
                            else
                            {
                                CSuff = ")";
                            }
                        }
                        else
                        {
                            CSuff = " " + myRow2.Field<string>("JoinOperator");
                        }
                        if (Cindex == 1)
                        {
                            lstErrorCriteriaSet.Items.Add(CPref + myRow2.Field<string>("CriteriaTitle") + CSuff);
                        }
                        else
                        {
                            lstErrorCriteriaSet.Items.Add(string.Format("          {0}{1}", myRow2.Field<string>("CriteriaTitle"), CSuff));
                        }
                        Support.SetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex - 1, myRow2.Field<int>("TableValidationID"));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    //LDW if (SetCount == TotalSetRec)
                    if (SetCount != TotalSetRec)
                    {
                        lstErrorCriteriaSet.Items.Add(mainjoinop);
                        //"And"
                        //Not sure if this line is needed
                        Support.SetItemData(lstErrorCriteriaSet, lstErrorCriteriaSet.SelectedIndex - 1, SetIndex);
                    }
                    //LDW rs_critSet.MoveNext();
                }

                //when there is only one criteria the next choice should be
                //defined by selecting AND or OR buttons
                //otherwise the join operator has already been defined from the previous selection
                if (lstErrorCriteriaSet.Items.Count == 1)
                {
                    cmdValidErrorAddCritAnd.Enabled = true;
                    cmdValidErrorAddCritOr.Enabled = true;
                    cmdValidErrorAddCrit.Enabled = false;
                    cmdValidErrorChangemainjoinop.Enabled = false;
                }
                else
                {
                    cmdValidErrorAddCritAnd.Enabled = false;
                    cmdValidErrorAddCritOr.Enabled = false;
                    cmdValidErrorAddCrit.Enabled = true;
                    cmdValidErrorChangemainjoinop.Enabled = true;
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

        public void RefreshWarningCriteriaSet()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex = 0;
            int TotalRec = 0;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec = 0;
            string mainjoinop = "";
            var rs_critSet = new DataSet();

            try
            {

                lstWarningCriteriaSet.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_TableValidation ";

                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tablevalidationmessageid = -1";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_TableValidation";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, rs_critSet);

                if (rs_critSet.Tables[sqlTableName5].Rows.Count == 0)
                {
                    cmdValidWarningAddCritAnd.Enabled = false;
                    cmdValidWarningAddCritOr.Enabled = false;
                    cmdValidWarningAddCrit.Enabled = true;
                    cmdValidWarningChangemainjoinop.Enabled = false;
                    return;
                }

                if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count > 0)
                {
                    modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName6 = "tbl_setup_tablevalidationmessage";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["JoinOperator"]))
                    {
                        mainjoinop = modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["JoinOperator"].ToString();
                    }
                }

                //LDW rs_critSet.MoveLast();
                TotalSetRec = rs_critSet.Tables[sqlTableName5].Rows.Count;
                //LDW rs_critSet.MoveFirst();

                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow4 in rs_critSet.Tables[sqlTableName5].Rows)
                {
                    SetIndex = SetIndex - 1;
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_tablevalidation ";
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                    modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, myRow4.Field<string>("CriteriaSet"));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName6 = "tbl_setup_tablevalidation";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    Cindex = 0;
                    CSuff = "";
                    CPref = string.Format("Set {0}: (", modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["CriteriaSet"]);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                    {
                        Cindex = Cindex + 1;
                        if (Cindex == TotalRec)
                        {
                            if (TotalRec == 1)
                            {
                                CSuff = string.Format(" ({0}) )", myRow5.Field<string>("JoinOperator"));
                            }
                            else
                            {
                                CSuff = ")";
                            }
                        }
                        else
                        {
                            CSuff = " " + myRow5.Field<string>("JoinOperator");
                        }
                        if (Cindex == 1)
                        {
                            lstWarningCriteriaSet.Items.Add(CPref + myRow5.Field<string>("CriteriaTitle") + CSuff);
                        }
                        else
                        {
                            lstWarningCriteriaSet.Items.Add(string.Format("          {0}{1}", myRow5.Field<string>("CriteriaTitle"), CSuff));
                        }
                        Support.SetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex - 1, myRow5.Field<int>("TableValidationID"));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (SetCount != TotalSetRec)
                    {
                        lstWarningCriteriaSet.Items.Add(mainjoinop);
                        //"And"
                        Support.SetItemData(lstWarningCriteriaSet, lstWarningCriteriaSet.SelectedIndex - 1, SetIndex);
                    }
                    //LDW rs_critSet.MoveNext();
                }

                //when there is only one criteria the next choice should be
                //defined by selecting AND or OR buttons
                //otherwise the join operator has already been defined from the previous selection
                if (lstWarningCriteriaSet.Items.Count == 1)
                {
                    cmdValidWarningAddCritAnd.Enabled = true;
                    cmdValidWarningAddCritOr.Enabled = true;
                    cmdValidWarningAddCrit.Enabled = false;
                    cmdValidWarningChangemainjoinop.Enabled = false;
                }
                else
                {
                    cmdValidWarningAddCritAnd.Enabled = false;
                    cmdValidWarningAddCritOr.Enabled = false;
                    cmdValidWarningAddCrit.Enabled = true;
                    cmdValidWarningChangemainjoinop.Enabled = true;
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

        public void PrintValidation()
        {
            int thismessageid = 0;
            string vmessage = null;
            string validatewhen = null;
            string valFile = null;
            var vrs = new DataSet();
            var vcrs = new DataSet();

            try
            {

                valFile = "c:\\iha\\valid.txt";
                FileSystem.FileOpen(1, valFile, OpenMode.Output);

                //retrieve the list of Validation Error messages
                modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'ERROR' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tablevalidationmessageid ";

                //LDW vrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_TableValidationMessage";
                vrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, vrs);

                //LDW while (!vrs.EOF)
                foreach (DataRow myRow6 in vrs.Tables[sqlTableName7].Rows)
                {
                    validatewhen = myRow6.Field<string>("validatewhen");
                    vmessage = myRow6.Field<string>("Message");
                    FileSystem.PrintLine(1, "******************************************************************");
                    FileSystem.PrintLine(1, myRow6.Field<int>("TableValidationMessageID"));
                    FileSystem.PrintLine(1, vmessage);
                    FileSystem.PrintLine(1, "");
                    thismessageid = myRow6.Field<int>("TableValidationMessageID");
                    printvalcrit(thismessageid);

                    FileSystem.PrintLine(1, "");

                    //LDW vrs.MoveNext();
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

        public void printvalcrit(int thismessageid)
        {
            string CPref = null;
            string CSuff = null;
            int Cindex = 0;
            int TotalRec = 0;
            int SetCount = 0;
            int TotalSetRec = 0;
            string mainjoinop = "";
            var rs_critSet = new DataSet();


            try
            {

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_TableValidation ";
                modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, thismessageid);
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_TableValidation";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, rs_critSet);

                //LDW rs_critSet.MoveLast();
                TotalSetRec = rs_critSet.Tables[sqlTableName8].Rows.Count;
                //LDW rs_critSet.MoveFirst();

                if (rs_critSet.Tables[sqlTableName8].Rows.Count > 0)
                {
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, thismessageid);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName9 = "tbl_setup_tablevalidationmessage";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"]))
                    {
                        mainjoinop = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"].ToString();
                    }

                    //LDW while (!rs_critSet.EOF)
                    foreach (DataRow myRow7 in rs_critSet.Tables[sqlTableName8].Rows)
                    {

                        modGlobal.gv_sql = "Select * from tbl_setup_tablevalidation ";
                        modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, thismessageid);
                        modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, myRow7.Field<string>("CriteriaSet"));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName10 = "tbl_setup_tablevalidation";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                        //LDW modGlobal.gv_rs.MoveLast();
                        TotalRec = modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count;
                        //LDW modGlobal.gv_rs.MoveFirst();

                        Cindex = 0;
                        CSuff = "";
                        CPref = string.Format("Set {0}: (", modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["CriteriaSet"]);

                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                        {
                            Cindex = Cindex + 1;
                            if (Cindex == TotalRec)
                            {
                                if (TotalRec == 1)
                                {
                                    CSuff = string.Format(" ({0}) )", myRow8.Field<string>("JoinOperator"));
                                }
                                else
                                {
                                    CSuff = ")";
                                }
                            }
                            else
                            {
                                CSuff = " " + myRow8.Field<string>("JoinOperator");
                            }
                            if (Cindex == 1)
                            {
                                FileSystem.PrintLine(1, CPref + myRow8.Field<string>("CriteriaTitle") + CSuff);
                            }
                            else
                            {
                                FileSystem.PrintLine(1, string.Format("          {0}{1}", myRow8.Field<string>("CriteriaTitle"), CSuff));
                            }
                            //LDW modGlobal.gv_rs.MoveNext();
                        }

                        //If SetCount >= TotalSetRec Then
                        //    Print #1, ")"
                        //End If
                        if (SetCount < TotalSetRec)
                        {
                            FileSystem.PrintLine(1, Strings.Chr(13));
                            FileSystem.PrintLine(1, mainjoinop);
                        }
                        //LDW rs_critSet.MoveNext();
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
    }
}
