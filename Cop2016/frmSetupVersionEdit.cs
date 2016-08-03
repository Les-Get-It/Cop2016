using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSetupVersionEdit : Telerik.WinControls.UI.RadForm
    {
        const string rdcVersionHistoryTable = "tbl_Setup_Version";


        public frmSetupVersionEdit()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            frmSetupVersion frmSetupVersionCopy = new frmSetupVersion();

            try
            {
                modGlobal.gv_Action = "update";

                modGlobal.gv_sql = "update tbl_Setup_Version ";
                modGlobal.gv_sql = string.Format("{0} set Notes = '{1}',", modGlobal.gv_sql, txtNotes.Text);
                if (string.IsNullOrEmpty(txtVersionEndDate.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " VersionEndDate = null";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} VersionEnddate = '{1}'", modGlobal.gv_sql, txtVersionEndDate.Text);
                }

                modGlobal.gv_sql = string.Format("{0} Where versionid = {1}", modGlobal.gv_sql, frmSetupVersionCopy.rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[0]["versionid"]);
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

        private void frmSetupVersionEdit_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            frmSetupVersion frmSetupVersionCopy = new frmSetupVersion();

            try
            {
                if (!Information.IsDBNull(frmSetupVersionCopy.txtNotes.Text))
                {
                    txtNotes.Text = frmSetupVersionCopy.txtNotes.Text;
                }
                if (!Information.IsDBNull(frmSetupVersionCopy.rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[0]["VersionEndDate"]))
                {
                    txtVersionEndDate.Text = frmSetupVersionCopy.rdcVersionHistory.Tables[rdcVersionHistoryTable].Rows[0]["VersionEndDate"].ToString();
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
