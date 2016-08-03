using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmReportCopyCriteria : Telerik.WinControls.UI.RadForm
    {

        public frmReportCopyCriteria()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            int NewCritID;


            try
            {
                if (cboSet.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Define the definition of the new criteria.");
                }
                else
                {
                    //copy the criteria
                    modGlobal.gv_Action = "Add";
                    NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SavedAdhocReportCriteria", "CriteriaID");

                    modGlobal.gv_sql = " insert into tbl_Setup_SavedAdhocReportCriteria (";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Report_ID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Criteriaset ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                    modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboJoinOperator.Text);
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where CriteriaID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(frmReportSetupCopy.lstSelectedCriteria, frmReportSetupCopy.lstSelectedCriteria.SelectedIndex));

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    this.Close();
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
        

        private void frmReportCopyCriteria_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            frmReportSetup frmReportSetupCopy = new frmReportSetup();

            try
            {
                RefreshSetList();

                modGlobal.gv_sql = "Select CriteriaTitle from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = string.Format("{0} where criteriaID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(frmReportSetupCopy.lstSelectedCriteria, frmReportSetupCopy.lstSelectedCriteria.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lblCopyFrom.Text = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["CriteriaTitle"].ToString();
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
                const string sqlTableName2 = "tbl_setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["JoinOperator"].ToString();
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
                const string sqlTableName3 = "tbl_setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                //Display the list of criteria

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
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
    }
}
