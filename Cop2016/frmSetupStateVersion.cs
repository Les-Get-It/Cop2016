using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSetupStateVersion : Telerik.WinControls.UI.RadForm
    {
        public DataSet rdcVersionHistory = new DataSet();
        public string rdcVersionHistoryTable = null;


        public frmSetupStateVersion()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("This feature will remove the version history from the system. Are you sure you want to continue?",
                    "Reset Version", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "Delete tbl_setup_Stateversion ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where StateVersion <> 0 ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    refreshVersionHistory();
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

        private void frmSetupStateVersion_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                this.Text = "Setup Version History for the State of " + modGlobal.gv_State;
                refreshVersionHistory();
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

        public void refreshVersionHistory()
        {
            try
            {
                modGlobal.gv_sql = "Select  *  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_StateVersion ";
                modGlobal.gv_sql = string.Format("{0} Where State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by StateVersion desc ";

                //LDW rdcVersionHistory.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string rdcVersionHistoryTable = "tbl_Setup_StateVersion";
                rdcVersionHistory = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcVersionHistoryTable, rdcVersionHistory);
                rdcVersionHistory.AcceptChanges();
                //resp = InputBox("", "", gv_sql) 'rdcPatientFields.Resultset.RowCount
                dbgVersionHistory.Refresh();
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
