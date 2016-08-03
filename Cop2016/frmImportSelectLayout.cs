using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmImportSelectLayout : Telerik.WinControls.UI.RadForm
    {
        public DataSet rdcImportLayout = new DataSet();
        public string rdcImportLayoutTable = null;


        public frmImportSelectLayout()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            int newid = modDBSetup.FindMaxRecID("tbl_setup_Importsetup", "importsetupid");

            try
            {

                if (string.IsNullOrEmpty(txtNewImportLayout.Text))
                {
                    RadMessageBox.Show("Please enter a description for the new layout.");
                    return;
                }
                modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
                modGlobal.gv_sql = string.Format("{0} where upper(description) = '{1}'", modGlobal.gv_sql, Strings.UCase(txtNewImportLayout.Text));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_ImportSetup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)
                {
                    RadMessageBox.Show("There is a layout with the same description.");
                    return;
                }

                modGlobal.gv_sql = "Insert into tbl_setup_ImportSetup  (importsetupid, description, state, recordstatus)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, newid);
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtNewImportLayout.Text);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshImportLayout();

                txtNewImportLayout.Text = "";
                cmdSelect.Enabled = true;
                cmdDelete.Enabled = true;
                cmdUpdate.Enabled = true;
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

        private void cmdChangeStatus_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            string MoveToModule = null;

            try
            {
                if (rdcImportLayout.Tables[rdcImportLayoutTable].Rows.Count == 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this import layout to the " + MoveToModule + " Module?",
                    "Layout Import", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_ImportSetup ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where ImportSetupID = {1}", modGlobal.gv_sql, rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["ImportSetupID"]);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshImportLayout();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to delete this layout? All the associated fields will be deleted too.",
                    "Delete ImportLayout", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = " delete tbl_setup_ImportValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where msgid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select msgid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_importvalidationmessage  as msg ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join tbl_setup_importfields as impf ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  on msg.importfieldid = impf.importfieldid ";
                modGlobal.gv_sql = string.Format("{0} where impf.importsetupid = {1}", modGlobal.gv_sql, rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["ImportSetupID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = " delete tbl_setup_ImportValidationMessage ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where importfieldid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_importfields as impf ";
                modGlobal.gv_sql = string.Format("{0} where impf.importsetupid = {1}", modGlobal.gv_sql, rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["ImportSetupID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = " delete tbl_setup_ImportFields ";
                modGlobal.gv_sql = string.Format("{0} where importsetupid = {1}", modGlobal.gv_sql, rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["ImportSetupID"]);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " delete tbl_setup_ImportSetup ";
                modGlobal.gv_sql = string.Format("{0} where importsetupid = {1}", modGlobal.gv_sql, rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["ImportSetupID"]);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshImportLayout();
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

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            frmImportSetup frmImportSetupCopy = new frmImportSetup();

            try
            {

                if (rdcImportLayout.Tables[rdcImportLayoutTable].Rows.Count == 0)
                {
                    return;
                }
                modGlobal.gv_importsetupid = rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["ImportSetupID"].ToString();
                frmImportSetupCopy.Show();
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
            this.Close();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            string thislayoutdesc = null;

            try
            {

                if (rdcImportLayout.Tables[rdcImportLayoutTable].Rows.Count == 0)
                {
                    return;
                }

                thislayoutdesc = RadInputBox.Show("Layout Description:", "Update Description", rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["Description"].ToString());
                if (!string.IsNullOrEmpty(thislayoutdesc))
                {
                    modGlobal.gv_sql = "update tbl_setup_ImportSetup ";
                    modGlobal.gv_sql = string.Format("{0} set description = '{1}'", modGlobal.gv_sql, thislayoutdesc);
                    modGlobal.gv_sql = string.Format("{0} where importsetupid = {1}", modGlobal.gv_sql, rdcImportLayout.Tables[rdcImportLayoutTable].Rows[0]["ImportSetupID"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshImportLayout();
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

        private void frmImportSelectLayout_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {

                if (modGlobal.gv_status == "TEST")
                {
                    cmdChangeStatus.Text = "Move to Active";
                }
                else
                {
                    cmdChangeStatus.Text = "Move to Test";
                }

                RefreshImportLayout();
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

        public void RefreshImportLayout()
        {
            try
            {
                modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by methodnumber ";

                //LDW rdcImportLayout.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcImportLayoutTable = "tbl_setup_ImportSetup";
                rdcImportLayout = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcImportLayoutTable, rdcImportLayout);
                rdcImportLayout.AcceptChanges();
                dbgImportLayout.Refresh();

                if (rdcImportLayout.Tables[rdcImportLayoutTable].Rows.Count == 0)
                {
                    cmdSelect.Enabled = false;
                    cmdDelete.Enabled = false;
                    cmdUpdate.Enabled = false;
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
