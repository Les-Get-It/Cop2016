using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmTableEditLookup : Telerik.WinControls.UI.RadForm
    {
        public string rdcLookupListTable = "tbl_setup_miscLookupList";


        public frmTableEditLookup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void frmTableEditLookup_Load(object sender, EventArgs e)
        {
            frmLookupSetup frmLookupSetupCopy = new frmLookupSetup();

            this.CenterToParent();

            try
            {
                if (frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows.Count > 0)
                {
                    if (!Information.IsDBNull(frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["Id"]))
                    {
                        txtID.Text = frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["Id"].ToString();
                    }

                    if (!Information.IsDBNull(frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["FIELDVALUE"]))
                    {
                        txtLookupValue.Text = frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["FIELDVALUE"].ToString();
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            frmLookupSetup frmLookupSetupCopy = new frmLookupSetup();
            string gv_Command = null;

            try
            {
                if (string.IsNullOrEmpty(txtID.Text) | Information.IsDBNull(txtID.Text))
                {
                    RadMessageBox.Show("ID cannot be blank");
                    return;
                }


                gv_Command = "Update tbl_Setup_miscLookupList set ";

                gv_Command = gv_Command + " ID = '" + txtID.Text + "',";

                gv_Command = gv_Command + " FieldValue = '" + txtLookupValue.Text + "'";

                gv_Command = gv_Command + " Where lookupid = " + frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"];

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, gv_Command);


                modGlobal.gv_sql = " update tbl_setup_savedadhocreportcriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"];
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " update tbl_setup_submitcleanuprecord ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"];
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " update tbl_setup_submitcriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"];
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " update tbl_setup_tablevalidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"];
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
