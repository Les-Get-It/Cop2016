using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSetupVersion : Telerik.WinControls.UI.RadForm
    {
        public DataSet rdcVersionHistory = new DataSet();
        public string rdcVersionHistoryTable = null;


        public frmSetupVersion()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to delete the log for this version?", "Delete Log", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                //LDW if (rdcVersionHistory.Resultset.AbsolutePosition == 0)
                for (int i = 0; i < rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows.Count; i++)
                {
                    DataRow dRow1 = rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[i];
                    int rowIndex = rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows.IndexOf(dRow1);
                    if (rowIndex == 0)
                    {
                        return;
                    }
                }
                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "Delete tbl_setup_Version where versionid = " + rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[0]["versionid"];
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            frmSetupVersionEdit frmSetupVersionEditCopy = new frmSetupVersionEdit();
            bool FoundIt;
            int thisversion;


            try
            {
                //LDW if (rdcVersionHistory.Resultset.AbsolutePosition == 0)
                for (int i = 0; i < rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows.Count; i++)
                {
                    DataRow dRow2 = rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[i];
                    int rowIndex = rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows.IndexOf(dRow2);
                    if (rowIndex == 0)
                    {
                        return;
                    }
                }

                modGlobal.gv_Action = "";

                frmSetupVersionEditCopy.ShowDialog();

                if (modGlobal.gv_Action == "update")
                {
                    thisversion = Convert.ToInt32(rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[0]["versionid"]);
                    refreshVersionHistory();
                    FoundIt = false;

                    //LDW while ((!rdcVersionHistory.Resultset.RowCount) & FoundIt == false)
                    for (int itr = 0; itr < rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows.Count; itr++)
                    {
                        var myRow3 = (DataRow)rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[itr];
                        int rowIndex3 = rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows.IndexOf(myRow3);

                        while ((rowIndex3 == rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows.Count - 1) & FoundIt == false)
                        {
                            if (Convert.ToInt32(rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[0]["versionid"]) == thisversion)
                            {
                                FoundIt = true;
                            }
                            else
                            {
                                //LDW rdcVersionHistory.Resultset.MoveNext();
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("This feature will remove the version history from the system. Are you sure you want to continue?",
                    "Reset Version", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "Delete tbl_setup_version ";
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

        private void frmSetupVersion_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
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
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_Version ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by VersionNumber desc ";

                //LDW rdcVersionHistory.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcVersionHistoryTable = "tbl_Setup_Version";
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
