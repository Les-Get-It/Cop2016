using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmReportSetup : RadForm
    {
        public DataSet rdcHelp = new DataSet();
        public string rdcHelpTable = null;


        public frmReportSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboReportList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshReportTable();
                //RefreshTableFields
                //RefreshTableFieldsForCriteria
                RefreshSelectedFields();
                RefreshCriteriaList();
                RefreshSumCriteriaList();
                //LDWRefreshCriteriaSetList();- Method not implemented.

                if (cboReportList.SelectedIndex >= 0)
                {
                    sstabReportSpec.Enabled = true;
                    cboTableList.Enabled = true;
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



        private void cboTableList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshTableFields();
                //RefreshTableFieldsForCriteria
                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReports ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set BaseTableID = " + Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
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

        private void cmdAddCriteria_Click(object sender, EventArgs e)
        {
            frmReportAddCrit frmReportAddCritCopy = new frmReportAddCrit();

            try
            {
                frmReportAddCritCopy.ShowDialog();
                RefreshCriteriaList();
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
            frmReportAddSumCriteria frmReportAddSumCriteriaCopy = new frmReportAddSumCriteria();

            try
            {
                frmReportAddSumCriteriaCopy.ShowDialog();
                RefreshSumCriteriaList();
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

        private void cmdAddField_Click(object sender, EventArgs e)
        {
            string FieldCaption = null;
            int NextOrderID;

            try
            {

                if (lstAvailableFieldList.SelectedIndex > -1)
                {
                    //no more than 10 fields can be selected
                    modGlobal.gv_sql = "select count(*) as TotalFields from  tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_SavedAdhocReportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                    if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["TotalFields"]) >= 10)
                    {
                        RadMessageBox.Show("No more than 10 fields for a report can be selected.");
                        return;
                    }

                    NextOrderID = GetNextFieldOrderID(Support.GetItemData(cboReportList, cboReportList.SelectedIndex));

                    FieldCaption = RadInputBox.Show("If you need to change the field title, type the new name here:", "Add Field", lstAvailableFieldList.Text);

                    modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReportFields (Report_ID, DDID, FieldCaption, OrderID)";
                    modGlobal.gv_sql = string.Format("{0} values({1},{2}, ", modGlobal.gv_sql, Support.GetItemData(cboReportList,
                        cboReportList.SelectedIndex), Support.GetItemData(lstAvailableFieldList, lstAvailableFieldList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} '{1}', {2})", modGlobal.gv_sql, FieldCaption, NextOrderID);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshSelectedFields();
                    RefreshTableFields();
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

        private void cmdChangeOrAnd_Click(object sender, EventArgs e)
        {
            string CSet = null;
            string newjoinop = null;

            try
            {

                if (lstSelectedCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to Change the join operator?", "Change And/Or of the set", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.No))
                {
                    return;
                }

                newjoinop = "And";

                modGlobal.gv_sql = " select CriteriaSEt, JoinOperator from tbl_setup_savedAdhocReportCriteria  ";
                modGlobal.gv_sql = string.Format("{0} where CriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_savedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                CSet = modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["CriteriaSet"].ToString();

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["JoinOperator"]))
                {
                    modGlobal.gv_sql = " select JoinOperator from tbl_setup_savedAdhocReports  ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName3 = "tbl_setup_savedAdhocReports";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["JoinOperator"].ToString() == "And")
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
                    if (modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["JoinOperator"].ToString() == "And")
                    {
                        newjoinop = "OR";
                    }
                    else
                    {
                        newjoinop = "And";
                    }
                }

                modGlobal.gv_sql = " Update tbl_setup_savedAdhocReportCriteria  ";
                modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, newjoinop);
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, CSet);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshCriteriaList();
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

        private void cmdChangeOrAndSumCriteria_Click(object sender, EventArgs e)
        {
            string CSet = null;
            string newjoinop = null;

            try
            {

                if (lstSelectedSumCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to Change the join operator?", "Change And/Or of the set", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.No))
                {
                    return;
                }

                newjoinop = "And";

                modGlobal.gv_sql = " select CriteriaSEt, JoinOperator from tbl_setup_savedAdhocReportSumCriteria  ";
                modGlobal.gv_sql = string.Format("{0} where CriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_savedAdhocReportSumCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                CSet = modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["CriteriaSet"].ToString();

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["JoinOperator"]))
                {
                    modGlobal.gv_sql = " select JoinOperator from tbl_setup_savedAdhocReports  ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_savedAdhocReports";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["JoinOperator"].ToString() == "And")
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
                    if (modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["JoinOperator"].ToString() == "And")
                    {
                        newjoinop = "OR";
                    }
                    else
                    {
                        newjoinop = "And";
                    }
                }

                modGlobal.gv_sql = " Update tbl_setup_savedAdhocReportSumCriteria  ";
                modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, newjoinop);
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, CSet);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshSumCriteriaList();
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

        private void cmdChangeReportAndOr_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to change the join operator between all sets?",
                    "Change Join Operator Between All Sets", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (cboReportList.SelectedIndex < 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_setup_SavedAdhocReports";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count > 0)
                {
                    modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["JoinOperator"]) | string.IsNullOrEmpty(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["JoinOperator"].ToString()))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                    }
                    else if (modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["JoinOperator"].ToString() == "OR")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'AND'";
                    }
                    else if (modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["JoinOperator"].ToString() == "AND")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                    }
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }
                RefreshCriteriaList();
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

        private void cmdChangeReportAndOrSumCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to change the join operator between all sets?",
                    "Change Join Operator Between All Sets", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (cboReportList.SelectedIndex < 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_SavedAdhocReports";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName7].Rows.Count > 0)
                {
                    modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["JoinOperator"]) | string.IsNullOrEmpty(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["JoinOperator"].ToString()))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                    }
                    else if (modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["JoinOperator"].ToString() == "OR")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'AND'";
                    }
                    else if (modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["JoinOperator"].ToString() == "AND")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                    }
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }
                RefreshSumCriteriaList();
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
            try
            {
                DialogResult resp;
                string MoveToModule = null;

                if (cboReportList.SelectedIndex < 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this report to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_SavedAdhocReports ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshReportList();
                RefreshTableList();
                RefreshReportTable();
                RefreshTableFields();
                RefreshSelectedFields();
                RefreshCriteriaList();
                RefreshSumCriteriaList();
                ResetCriteriaSetOrderForAllReports();

                //LDW sstabReportSpec.SelectedIndex = 0;
                sstabReportSpec.ActiveWindow = sstabReportSpec0;
                sstabReportSpec.Enabled = false;
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

        private void cmdCopyCriteria_Click(object sender, EventArgs e)
        {
            frmReportCopyCriteria frmReportCopyCriteriaCopy = new frmReportCopyCriteria();

            try
            {

                if (lstSelectedCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_Action = "Not Defind";

                frmReportCopyCriteriaCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add")
                {
                    RefreshCriteriaList();
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

        private void cmdCopySumCriteria_Click(object sender, EventArgs e)
        {
            frmReportCopySumCriteria frmReportCopySumCriteriaCopy = new frmReportCopySumCriteria();

            try
            {

                if (lstSelectedSumCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_Action = "Not Defind";

                frmReportCopySumCriteriaCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add")
                {
                    RefreshSumCriteriaList();
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

        private void cmdDeleteReport_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to delete this report?", "Delete Report", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (cboReportList.SelectedIndex < 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReports ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshReportList();
                RefreshTableList();
                RefreshReportTable();
                RefreshTableFields();
                //RefreshTableFieldsForCriteria
                RefreshSelectedFields();
                RefreshCriteriaList();
                RefreshSumCriteriaList();

                if (cboReportList.SelectedIndex >= 0)
                {
                    sstabReportSpec.Enabled = true;
                    cboTableList.Enabled = true;
                }
                else
                {
                    sstabReportSpec.Enabled = false;
                    cboTableList.Enabled = false;
                }

                sstabReportSpec.ActiveWindow = sstabReportSpec0;
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

        private void cmdDup_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            int ReportID;
            string newname = null;

            try
            {
                if (cboReportList.SelectedIndex < 0)
                {
                    return;
                }
                newname = RadInputBox.Show("Enter the new name for the report:", "Duplicate Report", cboReportList.Text);
                if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
                {
                    return;
                }

                while (Strings.Len(newname) > 200)
                {
                    RadMessageBox.Show("Please enter a name that is less than 200 characters long.");

                    newname = RadInputBox.Show("Enter the new name for the report:", "Duplicate Report", cboReportList.Text);
                    if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
                    {
                        return;
                    }
                }


                modGlobal.gv_sql = string.Format("EXEC DuplicateAdhocReport {0}, '{1}'", Support.GetItemData(cboReportList, cboReportList.SelectedIndex), newname);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "DuplicateAdhocReport";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                ReportID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["ReportID"]);

                modGlobal.gv_rs.Dispose();

                RefreshReportList();

                //find listindex with itemdata = gv_rs!ReportID
                //cboReportList.ItemData(cboReportList.ListIndex)
                while (Support.GetItemData(cboReportList, cnt) != ReportID)
                {
                    cnt = cnt + 1;
                }

                if (Support.GetItemData(cboReportList, cnt) == ReportID)
                {
                    cboReportList.SelectedIndex = cnt;
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

        private void cmdDuplCriteria_Click(object sender, EventArgs e)
        {
            int NewCritID;
            string NewCSet = null;
            string CSet = null;
            DialogResult resp;
            DataSet thisrs = new DataSet();


            try
            {
                modGlobal.gv_Action = "NotDefined";
                if (lstSelectedCriteria.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a criteria set to copy.");
                    return;
                }

                if (Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex) <= 0)
                {
                    RadMessageBox.Show("Select a criteria set to copy.");
                    return;
                }

                resp = RadMessageBox.Show("Are you sure you want to create a new set as a copy of the selected set?", "Duplicate Criteria Set", MessageBoxButtons.YesNo, RadMessageIcon.Question);



                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "Select criteriaset from tbl_setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where criteriaid = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName9 = "tbl_setup_SavedAdhocReportCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);
                    CSet = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["CriteriaSet"].ToString();

                    modGlobal.gv_sql = "Select max(criteriaset) + 1 as newcset  from tbl_setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName10 = "tbl_setup_SavedAdhocReportCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                    NewCSet = modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["NewCSet"].ToString();

                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and criteriaset = {1}", modGlobal.gv_sql, CSet);
                    //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName11 = "tbl_setup_SavedAdhocReportCriteria";
                    thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, thisrs);


                    //LDW while (!thisrs.EOF)
                    foreach (DataRow myRow11 in thisrs.Tables[sqlTableName11].Rows)
                    {
                        NewCritID = modDBSetup.FindMaxRecID("tbl_setup_SavedAdhocReportCriteria", "CriteriaID");

                        modGlobal.gv_sql = "insert into tbl_setup_SavedAdhocReportCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, Report_id, CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, ValueOperator, Value, DestDDID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, CriteriaSet)  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
                        modGlobal.gv_sql = string.Format("{0}{1}, report_id, CriteriaTitle, ", modGlobal.gv_sql, NewCritID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, ValueOperator, Value, DestDDID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                        modGlobal.gv_sql = string.Format("{0} LookupTableID, {1}", modGlobal.gv_sql, NewCSet);
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where CriteriaID = {1}", modGlobal.gv_sql, myRow11.Field<int>("criteriaID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //LDW thisrs.MoveNext();
                    }

                    RefreshCriteriaList();
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

        private void cmdDuplSumCriteria_Click(object sender, EventArgs e)
        {
            int NewCritID;
            string NewCSet = null;
            string CSet = null;
            DialogResult resp;
            DataSet thisrs = new DataSet();


            try
            {

                modGlobal.gv_Action = "NotDefined";
                if (lstSelectedSumCriteria.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a criteria set to copy.");
                    return;
                }

                if (Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex) <= 0)
                {
                    RadMessageBox.Show("Select a criteria set to copy.");
                    return;
                }


                resp = RadMessageBox.Show("Are you sure you want to create a new set as a copy of the selected set?", "Duplicate Criteria Set", MessageBoxButtons.YesNo, RadMessageIcon.Question);


                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "Select criteriaset from tbl_setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where criteriaid = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName12 = "tbl_setup_SavedAdhocReportSumCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);
                    CSet = modGlobal.gv_rs.Tables[sqlTableName12].Rows[0]["CriteriaSet"].ToString();

                    modGlobal.gv_sql = "Select max(criteriaset) + 1 as newcset  from tbl_setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName13 = "tbl_setup_SavedAdhocReportSumCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);
                    NewCSet = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["NewCSet"].ToString();

                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and criteriaset = {1}", modGlobal.gv_sql, CSet);
                    //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName14 = "tbl_setup_SavedAdhocReportSumCriteria";
                    thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, thisrs);

                    //LDW while (!thisrs.EOF)
                    foreach (DataRow myRow14 in thisrs.Tables[sqlTableName14].Rows)
                    {
                        NewCritID = modDBSetup.FindMaxRecID("tbl_setup_SavedAdhocReportSumCriteria", "CriteriaID");

                        modGlobal.gv_sql = "insert into tbl_setup_SavedAdhocReportSumCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, Report_id, CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, Operator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureID, CriteriaSet)  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
                        modGlobal.gv_sql = string.Format("{0}{1}, report_id, CriteriaTitle, ", modGlobal.gv_sql, NewCritID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, Operator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                        modGlobal.gv_sql = string.Format("{0} MeasureID, {1}", modGlobal.gv_sql, NewCSet);
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportSumCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where CriteriaID = {1}", modGlobal.gv_sql, myRow14.Field<int>("criteriaID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //LDW thisrs.MoveNext();
                    }

                    RefreshSumCriteriaList();
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

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            string msg = null;
            string lkvalue = null;
            string FieldTypeSize = null;
            RadListControl lstFieldListForCriteria = new RadListControl();
            DataSet rdclk = new DataSet();

            try
            {

                if (lstFieldListForCriteria.SelectedIndex < 0)
                {
                    return;
                }

                txtHelp.Text = "";
                FieldTypeSize = "";

                modGlobal.gv_sql = "Select DDID, LookupTableID, help, FieldType, FieldSize from tbl_Setup_DataDef ";
                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + lstFieldListForCriteria.ItemData(lstFieldListForCriteria.ListIndex);
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldListForCriteria, lstFieldListForCriteria.SelectedIndex));

                //LDW rdcHelp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcHelpTable = "tbl_Setup_DataDef";
                rdcHelp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcHelpTable, rdcHelp);

                rdcHelp.AcceptChanges();

                txtHelp.Text = rdcHelp.Tables[rdcHelpTable].Rows[0]["help"].ToString();

                FieldTypeSize = "Field Type: " + rdcHelp.Tables[rdcHelpTable].Rows[0]["FieldType"];
                if (rdcHelp.Tables[rdcHelpTable].Rows[0]["FieldType"].ToString() == "Text")
                {
                    FieldTypeSize = FieldTypeSize + Strings.Chr(10) + Strings.Chr(13) + "Field Size: " + rdcHelp.Tables[rdcHelpTable].Rows[0]["FieldSize"]
                        + Strings.Chr(10) + Strings.Chr(13) + Strings.Chr(10) + Strings.Chr(13);
                }
                else
                {
                    FieldTypeSize = FieldTypeSize + Strings.Chr(10) + Strings.Chr(13) + Strings.Chr(10) + Strings.Chr(13);
                }
                //Dim wrkODBC As Workspace
                //Dim conpubs As Connection
                //Dim dtHelp As Data
                //Set wrkODBC = CreateWorkspace("NewODBCWorkspace", "", "", dbUseODBC)
                //Set conpubs = wrkODBC.OpenConnection("Connection1", , , "ODBC;DATABASE=COP2001;UID=sa;PWD=;DSN=COP2001")
                //Set dtHelp.Recordset = conpubs.OpenRecordset(gv_sql, 2)



                if (!Information.IsDBNull(rdcHelp.Tables[rdcHelpTable].Rows[0]["LookupTableID"]))
                {
                    modGlobal.gv_sql = "Select * from tbl_Setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, rdcHelp.Tables[rdcHelpTable].Rows[0]["LookupTableID"]);
                    //LDW rdclk = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName15 = "tbl_Setup_misclookuplist";
                    rdclk = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, rdclk);
                    lkvalue = "";

                    //LDW while (!rdclk.EOF)
                    foreach (DataRow myRow15 in rdclk.Tables[sqlTableName15].Rows)
                    {
                        if (string.IsNullOrEmpty(lkvalue))
                        {
                            lkvalue = string.Format("{0}. {1}", myRow15.Field<string>("Id"), myRow15.Field<string>("FIELDVALUE"));
                        }
                        else
                        {
                            lkvalue = string.Format("{0}{1}{2}{3}. {4}", lkvalue, Strings.Chr(13), Strings.Chr(10), myRow15.Field<int>("Id"), myRow15.Field<string>("FIELDVALUE"));
                        }
                        //LDW rdclk.MoveNext();
                    }
                    rdclk.Dispose();
                }

                msg = "";
                if (string.IsNullOrEmpty(txtHelp.Text) & string.IsNullOrEmpty(lkvalue))
                {
                    RadMessageBox.Show(FieldTypeSize);
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

        private void cmdMoveFieldDown_Click(object sender, EventArgs e)
        {
            string CurrentField = null;
            int CurrentOrderID;


            try
            {
                if (lstSelectedFieldList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select OrderID from tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName16 = "tbl_Setup_SavedAdhocReportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName16].Rows[0]["OrderID"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        CurrentOrderID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName16].Rows[0]["OrderID"]);
                        modGlobal.gv_sql = "select max(OrderId) as maxorderid from tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName17 = "tbl_Setup_SavedAdhocReportFields";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);
                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["MaxOrderId"]) > CurrentOrderID)
                        {
                            //update the field that is one order higher than this one
                            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                            modGlobal.gv_sql = string.Format("{0} set OrderID = {1}", modGlobal.gv_sql, CurrentOrderID);
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                            modGlobal.gv_sql = modGlobal.gv_sql + " and OrderID = " + CurrentOrderID + 1;
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " set OrderID = " + CurrentOrderID + 1;
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                            modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //set focus on the same field after refresh
                            modGlobal.gv_sql = "select * from tbl_Setup_SavedAdhocReportFields ";
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                            modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName18 = "tbl_Setup_SavedAdhocReportFields";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                            CurrentField = string.Format("{0}. {1}", modGlobal.gv_rs.Tables[sqlTableName18].Rows[0]["OrderID"], modGlobal.gv_rs.Tables[sqlTableName18].Rows[0]["FieldCaption"]);
                            //MsgBox CurrentField
                            RefreshSelectedFields();
                            lstSelectedFieldList.Text = CurrentField;
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

        private void cmdMoveFieldup_Click(object sender, EventArgs e)
        {
            string CurrentField = null;

            try
            {

                if (lstSelectedFieldList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select OrderID from tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName19 = "tbl_Setup_SavedAdhocReportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["OrderID"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["OrderID"]) > 1)
                        {
                            //update the field that is one order higher than this one
                            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                            modGlobal.gv_sql = string.Format("{0} set OrderID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["OrderID"]);
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                            modGlobal.gv_sql = string.Format("{0} and OrderID = {1}", modGlobal.gv_sql, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["OrderID"]) - 1);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                            modGlobal.gv_sql = string.Format("{0} set OrderID = {1}", modGlobal.gv_sql, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["OrderID"]) - 1);
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                            modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            modGlobal.gv_sql = "select * from tbl_Setup_SavedAdhocReportFields ";
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                            modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName20 = "tbl_Setup_SavedAdhocReportFields";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                            //set focus on the same field after refresh
                            CurrentField = string.Format("{0}. {1}", modGlobal.gv_rs.Tables[sqlTableName20].Rows[0]["OrderID"], modGlobal.gv_rs.Tables[sqlTableName20].Rows[0]["FieldCaption"]);
                            //MsgBox CurrentField
                            RefreshSelectedFields();
                            lstSelectedFieldList.Text = CurrentField;
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

        private void cmdNewReport_Click(object sender, EventArgs e)
        {
            int FCount;
            int NewRecID;
            string ReportName = null;
            DataSet reprs = new DataSet();


            try
            {
                //get the report name
                ReportName = RadInputBox.Show("New Report Name:", "Add New Report", "");


                if (!string.IsNullOrEmpty(ReportName))
                {
                    //make sure it is not a duplicate
                    modGlobal.gv_sql = "select *   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReports  ";
                    modGlobal.gv_sql = string.Format("{0} where report_Name = '{1}'", modGlobal.gv_sql, ReportName);
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
                    const string sqlTableName21 = "tbl_Setup_SavedAdhocReports";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);
                    if (modGlobal.gv_rs.Tables[sqlTableName21].Rows.Count > 0)
                    {
                        RadMessageBox.Show("This Report Name Already Exists.");
                        return;
                    }

                    NewRecID = modDBSetup.FindMaxRecID("tbl_setup_SavedAdhocReports", "Report_ID");
                    //add the report
                    modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReports (Report_ID, Report_Name, State, RecordStatus)";
                    modGlobal.gv_sql = string.Format("{0} values({1},'{2}',", modGlobal.gv_sql, NewRecID, ReportName);
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
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
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //refresh report list
                    RefreshReportList();

                    //find and display it on the form
                    modGlobal.gv_sql = "select tbl_Setup_SavedAdhocReports.*   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReports  ";
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} Where state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                    }
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }

                    modGlobal.gv_sql = modGlobal.gv_sql + " order by Report_Name  ";

                    //LDW reprs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName22 = "tbl_Setup_SavedAdhocReports";
                    reprs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, reprs);
                    FCount = 0;

                    //LDW while (!reprs.EOF)
                    foreach (DataRow myRow22 in reprs.Tables[sqlTableName22].Rows)
                    {
                        if (myRow22.Field<string>("Report_name") == ReportName)
                        {
                            cboReportList.SelectedText = myRow22.Field<string>("Report_name");
                            cboReportList.SelectedIndex = FCount;
                        }
                        FCount = FCount + 1;
                        //LDW reprs.MoveNext();
                    }
                    reprs.Dispose();

                    RefreshTableList();
                    RefreshReportTable();
                    RefreshTableFields();
                    //RefreshTableFieldsForCriteria
                    RefreshSelectedFields();
                    RefreshCriteriaList();
                    RefreshSumCriteriaList();
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

        public void RefreshReportList()
        {
            var LIndex = 0;
            int this_ListIndex = -1;

            try
            {

                modGlobal.gv_sql = "select * from tbl_Setup_SavedAdhocReports ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by Report_Name ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName23 = "tbl_Setup_SavedAdhocReports";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);


                cboReportList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow23 in modGlobal.gv_rs.Tables[sqlTableName23].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;

                    cboReportList.Items.Add(new ListBoxItem(myRow23.Field<string>("Report_name"), myRow23.Field<int>("Report_ID")).ToString());
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

        public void RefreshTableList()
        {
            var LIndex = 0;
            int this_ListIndex = -1;

            try
            {

                //retrieve the list of tables
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tabletype <> 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName24 = "tbl_setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                cboTableList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow24 in modGlobal.gv_rs.Tables[sqlTableName24].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;

                    cboTableList.Items.Add(new ListBoxItem(myRow24.Field<string>("BaseTable"), myRow24.Field<int>("basetableid")).ToString());
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

        public void RefreshTableFields()
        {
            var LIndex = 0;
            int this_ListIndex = -1;
            int BTableID;

            try
            {

                if (cboTableList.SelectedIndex > -1)
                {
                    BTableID = Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
                }
                else
                {
                    BTableID = -1;
                }

                modGlobal.gv_sql = "select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql, BTableID);
                modGlobal.gv_sql = modGlobal.gv_sql + " and DDID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select DDID from tbl_Setup_SavedAdhocReportFields ";
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1})", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1) ";
                }
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName25 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);

                lstAvailableFieldList.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow25 in modGlobal.gv_rs.Tables[sqlTableName25].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;

                    lstAvailableFieldList.Items.Add(new ListBoxItem(myRow25.Field<string>("FieldName"), myRow25.Field<int>("DDID")).ToString());
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

        public void RefreshSelectedFields()
        {
            var LIndex = 0;
            int this_ListIndex = -1;

            try
            {

                modGlobal.gv_sql = "select tbl_Setup_SavedAdhocReportFields.*  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReportFields ";
                //gv_sql = gv_sql & " from tbl_Setup_SavedAdhocReportFields, tbl_Setup_DataDef "
                //gv_sql = gv_sql & " Where tbl_Setup_SavedAdhocReportFields.DDID =  tbl_Setup_DataDef.DDID "
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where tbl_Setup_SavedAdhocReportFields.Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_SavedAdhocReportFields.Report_ID = -1 ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_Setup_SavedAdhocReportFields.OrderID ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName26 = "tbl_Setup_SavedAdhocReportFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, modGlobal.gv_rs);

                lstSelectedFieldList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow26 in modGlobal.gv_rs.Tables[sqlTableName26].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;

                    if (!Information.IsDBNull(myRow26.Field<string>("OrderID")))
                    {
                        lstSelectedFieldList.Items.Add(myRow26.Field<string>("OrderID") + ". " + myRow26.Field<string>("FieldCaption"));
                    }
                    else
                    {
                        lstSelectedFieldList.Items.Add(myRow26.Field<string>("FieldCaption"));
                    }
                    Support.SetItemData(lstSelectedFieldList, lstSelectedFieldList.Items.Count - 1, myRow26.Field<int>("DDID"));
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

        public void RefreshReportTable()
        {
            int FCount;
            int BTableID;
            int ReportID;

            try
            {

                cboTableList.SelectedText = "";
                cboTableList.SelectedIndex = -1;

                if (cboReportList.SelectedIndex > -1)
                {
                    ReportID = Support.GetItemData(cboReportList, cboReportList.SelectedIndex);

                    modGlobal.gv_sql = "select BaseTableID   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReports  ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName27 = "tbl_setup_SavedAdhocReports";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["basetableid"]))
                    {
                        BTableID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["basetableid"]);
                        modGlobal.gv_sql = "select  tbl_Setup_TableDef.*   ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where TableType <> 'LOOKUP'  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable  ";

                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName28 = "tbl_Setup_TableDef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);
                        FCount = 0;
                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow28 in modGlobal.gv_rs.Tables[sqlTableName28].Rows)
                        {
                            if (myRow28.Field<int>("basetableid") == BTableID)
                            {
                                cboTableList.SelectedText = myRow28.Field<string>("BaseTable");
                                cboTableList.SelectedIndex = FCount;
                                return;
                            }
                            FCount = FCount + 1;
                            //LDW modGlobal.gv_rs.MoveNext();
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

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            int li_cnt;

            try
            {
                if (lstSelectedCriteria.SelectedIndex < 0)
                {
                    return;
                }

                if (lstSelectedCriteria.SelectedItems.Count > 0 & Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex) > -1)
                {
                    if (RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    //allow delete of multiple criteria
                    for (li_cnt = 0; li_cnt <= lstSelectedCriteria.Items.Count - 1; li_cnt++)
                    {
                        if (lstSelectedCriteria.SelectedIndex == li_cnt & Support.GetItemData(lstSelectedCriteria, li_cnt) > 0)
                        {
                            if (Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex) == 0)
                                return;

                            modGlobal.gv_sql = "Delete tbl_Setup_SavedAdhocReportcriteria ";
                            modGlobal.gv_sql = string.Format("{0} where criteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedCriteria, li_cnt));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //LDW lstSelectedCriteria.SetSelected(li_cnt, false);
                            lstSelectedCriteria.SelectedIndex = li_cnt;
                            lstSelectedCriteria.SelectedItem.Active = false;
                        }
                    }

                    ResetCriteriaSetOrder();
                    RefreshCriteriaList();
                }
                else
                {
                    RadMessageBox.Show("Select criteria to delete", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
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

            //gv_resp = MsgBox("Are you sure you want to delete this criteria?", vbYesNo, "Delete Criteria")
            //If gv_resp = vbYes Then
            //
            //     gv_sql = "Delete tbl_Setup_SavedAdhocReportcriteria "
            //     gv_sql = gv_sql & " where criteriaID = " & lstSelectedCriteria.ItemData(lstSelectedCriteria.ListIndex)
            //     gv_cn.Execute gv_sql
            //
            //     ResetCriteriaSetOrder
            //     RefreshCriteriaList
            //     'RefreshCriteriaSetList
            // End If
        }

        private void cmdRemoveSumCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelectedSumCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "Delete tbl_Setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where criteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    ResetSumCriteriaSetOrder();
                    RefreshSumCriteriaList();
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

        private void cmdRemoveField_Click(object sender, EventArgs e)
        {
            int CurrentFieldOrder;

            try
            {
                if (lstSelectedFieldList.SelectedIndex > -1)
                {
                    //remember the order number before deleting it
                    modGlobal.gv_sql = "Select OrderID from  tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName29 = "tbl_Setup_SavedAdhocReportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, modGlobal.gv_rs);
                    CurrentFieldOrder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName29].Rows[0]["OrderID"]);

                    //now delete the field
                    modGlobal.gv_sql = "Delete tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //reorganize the fields based on the order number
                    modGlobal.gv_sql = "Select * from  tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and OrderID > {1}", modGlobal.gv_sql, CurrentFieldOrder);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderID ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName30 = "tbl_Setup_SavedAdhocReportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName30, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow30 in modGlobal.gv_rs.Tables[sqlTableName30].Rows)
                    {
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = string.Format("{0} set OrderID = {1}", modGlobal.gv_sql, CurrentFieldOrder);
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, myRow30.Field<int>("DDID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        CurrentFieldOrder = CurrentFieldOrder + 1;
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    RefreshSelectedFields();
                    RefreshTableFields();
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

        private void cmdRenameField_Click(object sender, EventArgs e)
        {
            string CurrentField = null;
            string FieldCaption = null;

            try
            {

                if (lstSelectedFieldList.SelectedIndex > -1)
                {
                    FieldCaption = RadInputBox.Show("Type the new name here:", "Rename Field", lstSelectedFieldList.Text);
                    if (!string.IsNullOrEmpty(FieldCaption))
                    {
                        //update this field
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = string.Format("{0} set FieldCaption = '{1}'", modGlobal.gv_sql, FieldCaption);
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        modGlobal.gv_sql = "Select OrderID from  tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName31 = "tbl_Setup_SavedAdhocReportFields";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName31, modGlobal.gv_rs);

                        CurrentField = string.Format("{0}. {1}", modGlobal.gv_rs.Tables[sqlTableName31].Rows[0]["OrderID"], FieldCaption);
                        RefreshSelectedFields();
                        lstSelectedFieldList.Text = CurrentField;
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

        private void cmdRenameReport_Click(object sender, EventArgs e)
        {
            int thisindex;
            string newname = null;

            try
            {
                if (cboReportList.SelectedIndex < 0)
                {
                    return;
                }
                newname = RadInputBox.Show("Enter the new name for the report:", "Rename Report", cboReportList.Text);
                if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
                {
                    return;
                }

                while (Strings.Len(newname) > 200)
                {
                    RadMessageBox.Show("Please enter a name that is less than 200 characters long.");

                    newname = RadInputBox.Show("Enter the new name for the report:", "Rename Report", cboReportList.Text);
                    if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
                    {
                        return;
                    }
                }

                thisindex = cboReportList.SelectedIndex;

                modGlobal.gv_sql = "update tbl_setup_savedadhocreports ";
                modGlobal.gv_sql = string.Format("{0} set Report_Name = '{1}'", modGlobal.gv_sql, newname);
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshReportList();

                cboReportList.SelectedIndex = thisindex;
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

        private void frmReportSetup_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

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


                //ResetCriteriaSetOrderForAllReports
                RefreshReportList();
                RefreshTableList();

                sstabReportSpec.ActiveWindow = sstabReportSpec0;
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

        public int GetNextFieldOrderID(int ReportID)
        {
            int MaxOrderId = 0;

            try
            {
                modGlobal.gv_sql = "select max(OrderID) as MaxOrderID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName32 = "tbl_setup_SavedAdhocReportFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName32, modGlobal.gv_rs);

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName32].Rows[0]["MaxOrderId"]))
                {
                    MaxOrderId = 0;
                }
                else
                {
                    MaxOrderId = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName32].Rows[0]["MaxOrderId"]);
                }

                //return MaxOrderId + 1;
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
            return MaxOrderId + 1;
        }

        public void RefreshTableFieldsForCriteria()
        {
            var LIndex = 0;
            int this_ListIndex = -1;
            RadListControl lstFieldListForCriteria = new RadListControl();
            int BTableID;

            try
            {

                if (cboTableList.SelectedIndex > -1)
                {
                    BTableID = Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
                }
                else
                {
                    BTableID = -1;
                }

                modGlobal.gv_sql = "select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql, BTableID);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName32 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName32, modGlobal.gv_rs);

                lstFieldListForCriteria.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow32 in modGlobal.gv_rs.Tables[sqlTableName32].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;

                    lstFieldListForCriteria.Items.Add(new ListBoxItem(myRow32.Field<string>("FieldName"), myRow32.Field<int>("DDID")).ToString());
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

        public void RefreshCriteriaList()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec;
            string mainJoinOperator = null;
            DataSet rs_critSet = new DataSet();

            try
            {

                lstSelectedCriteria.Items.Clear();

                //find the operator (AND or OR) joining the sets
                mainJoinOperator = "AND";
                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
                }
                //g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName33 = "tbl_setup_SavedAdhocReports";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName33, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName33].Rows.Count > 0)
                {
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName33].Rows[0]["JoinOperator"]) | string.IsNullOrEmpty(modGlobal.gv_rs.Tables[sqlTableName33].Rows[0]["JoinOperator"].ToString()))
                    {
                        modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                        modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, mainJoinOperator);
                        modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    else
                    {
                        mainJoinOperator = modGlobal.gv_rs.Tables[sqlTableName33].Rows[0]["JoinOperator"].ToString();
                    }
                }



                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportCriteria ";
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName34 = "tbl_setup_SavedAdhocReportCriteria";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName34, rs_critSet);

                if (rs_critSet.Tables[sqlTableName34].Rows.Count > 0)
                {
                    //LDW  rs_critSet.MoveLast();
                    TotalSetRec = rs_critSet.Tables[sqlTableName34].Rows.Count;
                    //LDW rs_critSet.MoveFirst();
                }
                else
                {
                    TotalSetRec = 0;
                }

                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow34 in rs_critSet.Tables[sqlTableName34].Rows)
                {
                    SetIndex = SetIndex - 1;
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, myRow34.Field<string>("CriteriaSet"));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName35 = "tbl_setup_SavedAdhocReportCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName35, modGlobal.gv_rs);
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName35].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    Cindex = 0;
                    CSuff = "";
                    CPref = string.Format("Set {0}: (", modGlobal.gv_rs.Tables[sqlTableName35].Rows[0]["CriteriaSet"]);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow35 in modGlobal.gv_rs.Tables[sqlTableName35].Rows)
                    {
                        Cindex = Cindex + 1;
                        if (Cindex == TotalRec)
                        {
                            if (TotalRec == 1)
                            {
                                CSuff = " (" + myRow35.Field<string>("JoinOperator") + ") )";
                            }
                            else
                            {
                                CSuff = ")";
                            }
                        }
                        else
                        {
                            CSuff = " " + myRow35.Field<string>("JoinOperator");
                        }
                        if (Cindex == 1)
                        {
                            lstSelectedCriteria.Items.Add(CPref + myRow35.Field<string>("CriteriaTitle") + CSuff);
                        }
                        else
                        {
                            lstSelectedCriteria.Items.Add("          " + myRow35.Field<string>("CriteriaTitle") + CSuff);
                        }
                        Support.SetItemData(lstSelectedCriteria, lstSelectedCriteria.Items.Count - 1, myRow35.Field<int>("criteriaID"));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (SetCount == TotalSetRec)
                    {
                    }
                    else
                    {
                        lstSelectedCriteria.Items.Add(new ListBoxItem(mainJoinOperator, SetIndex).ToString());
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

        public void RefreshSumCriteriaList()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec;
            string mainJoinOperator = null;
            DataSet rs_critSet = new DataSet();

            try
            {

                lstSelectedSumCriteria.Items.Clear();

                //find the operator (AND or OR) joining the sets
                mainJoinOperator = "AND";
                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
                }
                //g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName37 = "tbl_setup_SavedAdhocReports";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName37, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName37].Rows.Count > 0)
                {
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName37].Rows[0]["JoinOperator"]) | string.IsNullOrEmpty(modGlobal.gv_rs.Tables[sqlTableName37].Rows[0]["JoinOperator"].ToString()))
                    {
                        modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                        modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, mainJoinOperator);
                        modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    else
                    {
                        mainJoinOperator = modGlobal.gv_rs.Tables[sqlTableName37].Rows[0]["JoinOperator"].ToString();
                    }
                }



                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportSumCriteria ";
                if (cboReportList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName38 = "tbl_setup_SavedAdhocReportSumCriteria";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName38, rs_critSet);

                if (rs_critSet.Tables[sqlTableName38].Rows.Count > 0)
                {
                    //LDW  rs_critSet.MoveLast();
                    TotalSetRec = rs_critSet.Tables[sqlTableName38].Rows.Count;
                    //LDW rs_critSet.MoveFirst();
                }
                else
                {
                    TotalSetRec = 0;
                }

                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow38 in rs_critSet.Tables[sqlTableName38].Rows)
                {
                    SetIndex = SetIndex - 1;
                    SetCount = SetCount + 1;

                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, myRow38.Field<string>("CriteriaSet"));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName39 = "tbl_setup_SavedAdhocReportSumCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName39, modGlobal.gv_rs);
                    //LDW modGlobal.gv_rs.MoveLast();
                    TotalRec = modGlobal.gv_rs.Tables[sqlTableName39].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    Cindex = 0;
                    CSuff = "";
                    CPref = string.Format("Set {0}: (", modGlobal.gv_rs.Tables[sqlTableName39].Rows[0]["CriteriaSet"]);

                    //LDW while (!modGlobal.gv_rs.EOF)

                    {
                        Cindex = Cindex + 1;
                        if (Cindex == TotalRec)
                        {
                            if (TotalRec == 1)
                            {
                                CSuff = string.Format(" ({0}) )", modGlobal.gv_rs.Tables[sqlTableName39].Rows[0]["JoinOperator"]);
                            }
                            else
                            {
                                CSuff = ")";
                            }
                        }
                        else
                        {
                            CSuff = " " + modGlobal.gv_rs.Tables[sqlTableName39].Rows[0]["JoinOperator"];
                        }
                        if (Cindex == 1)
                        {
                            lstSelectedSumCriteria.Items.Add(CPref + modGlobal.gv_rs.Tables[sqlTableName39].Rows[0]["CriteriaTitle"] + CSuff);
                        }
                        else
                        {
                            lstSelectedSumCriteria.Items.Add("          " + modGlobal.gv_rs.Tables[sqlTableName39].Rows[0]["CriteriaTitle"] + CSuff);
                        }
                        Support.SetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.Items.Count - 1, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName39].Rows[0]["criteriaID"]));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (SetCount == TotalSetRec)
                    {
                    }
                    else
                    {
                        lstSelectedSumCriteria.Items.Add(new ListBoxItem(mainJoinOperator, SetIndex).ToString());
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

        public void ResetCriteriaSetOrder()
        {
            int j;
            var i = 0;
            int MaxSet;

            try
            {

                //update null join operators
                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName40 = "tbl_Setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName40, modGlobal.gv_rs);

                //update the set order
                modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName42 = "tbl_Setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName42, modGlobal.gv_rs);
                MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName42].Rows[0]["MaxSet"]);
                if (MaxSet > 0)
                {
                    //give the max number to the null criteria set
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName43 = "tbl_Setup_SavedAdhocReportCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName43, modGlobal.gv_rs);

                    //adjust the order of the set
                    for (i = 1; i <= MaxSet; i++)
                    {
                        modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, i);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName44 = "tbl_Setup_SavedAdhocReportCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName44, modGlobal.gv_rs);
                        if (modGlobal.gv_rs.Tables[sqlTableName44].Rows.Count == 0)
                        {
                            for (j = i; j <= MaxSet; j++)
                            {
                                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                                modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, j - 1);
                                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, j);
                                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName45 = "tbl_Setup_SavedAdhocReportCriteria";
                                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName45, modGlobal.gv_rs);
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

        public void ResetSumCriteriaSetOrder()
        {
            int j;
            var i = 0;
            int MaxSet = 0;

            try
            {
                //update null join operators
                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName46 = "tbl_Setup_SavedAdhocReportSumCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName46, modGlobal.gv_rs);

                //update the set order
                modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName47 = "tbl_Setup_SavedAdhocReportSumCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName47, modGlobal.gv_rs);
                MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName47].Rows[0]["MaxSet"]);
                if (MaxSet > 0)
                {
                    //give the max number to the null criteria set
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName48 = "tbl_Setup_SavedAdhocReportSumCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName48, modGlobal.gv_rs);

                    //adjust the order of the set
                    for (i = 1; i <= MaxSet; i++)
                    {
                        modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportSumCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, i);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName49 = "tbl_Setup_SavedAdhocReportSumCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName49, modGlobal.gv_rs);
                        if (modGlobal.gv_rs.Tables[sqlTableName49].Rows.Count == 0)
                        {
                            for (j = i; j <= MaxSet; j++)
                            {
                                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                                modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, j - 1);
                                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(cboReportList, cboReportList.SelectedIndex));
                                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, j);
                                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName50 = "tbl_Setup_SavedAdhocReportSumCriteria";
                                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName50, modGlobal.gv_rs);
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

        public void ResetCriteriaSetOrderForAllReports()
        {
            int j;
            var i = 0;
            int MaxSet;
            int SetNum;
            DataSet rs_critSet = new DataSet();
            int ReportID;
            DataSet rs_reports = new DataSet();

            try
            {
                modGlobal.gv_sql = "Select Report_ID from tbl_Setup_SavedAdhocReports ";
                //LDW rs_reports = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName51 = "tbl_Setup_SavedAdhocReports";
                rs_reports = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName51, rs_reports);

                //LDW while (!rs_reports.EOF)
                foreach (DataRow myRow51 in rs_reports.Tables[sqlTableName51].Rows)
                {
                    ReportID = myRow51.Field<int>("Report_ID");

                    //update null join operators
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update any null criteria set
                    modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";

                    //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName52 = "tbl_setup_SavedAdhocReportCriteria";
                    rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName52, rs_critSet);

                    if (rs_critSet.Tables[sqlTableName52].Rows.Count == 0)
                    {
                        SetNum = 1;
                        //set all of them to a set number, if any criteria exists
                        modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";

                        //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName53 = "tbl_setup_SavedAdhocReportCriteria";
                        rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName53, rs_critSet);
                        if (rs_critSet.Tables[sqlTableName53].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportCriteria ";
                            modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, SetNum);
                            modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            SetNum = SetNum + 1;
                        }

                        modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";

                        //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName54 = "tbl_setup_SavedAdhocReportCriteria";
                        rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName54, rs_critSet);
                        if (rs_critSet.Tables[sqlTableName54].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportCriteria ";
                            modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, SetNum);
                            modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }

                    //update the set order
                    modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                    //gv_sql = gv_sql & " and CriteriaSet is not null "
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName55 = "tbl_Setup_SavedAdhocReportCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName55, modGlobal.gv_rs);
                    MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName55].Rows[0]["MaxSet"]);
                    if (MaxSet > 0)
                    {
                        //give the max number to the null criteria set
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                        //adjust the order of the set
                        for (i = 1; i <= MaxSet; i++)
                        {
                            modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportCriteria ";
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                            modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, i);
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName56 = "tbl_Setup_SavedAdhocReportCriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName56, modGlobal.gv_rs);
                            if (modGlobal.gv_rs.Tables[sqlTableName56].Rows.Count == 0)
                            {
                                for (j = i; j <= MaxSet; j++)
                                {
                                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                                    modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, j - 1);
                                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                                    modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, j);
                                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName57 = "tbl_Setup_SavedAdhocReportCriteria";
                                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName57, modGlobal.gv_rs);
                                }
                            }
                        }
                    }

                    //LDW rs_reports.MoveNext();
                }

                ResetSumCriteriaSetOrderForAllReports();
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

        public void ResetSumCriteriaSetOrderForAllReports()
        {
            int j;
            var i = 0;
            int MaxSet;
            int SetNum;
            DataSet rs_critSet = new DataSet();
            int ReportID;
            DataSet rs_reports = new DataSet();

            try
            {

                modGlobal.gv_sql = "Select Report_ID from tbl_Setup_SavedAdhocReports ";
                //LDW rs_reports = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName58 = "tbl_Setup_SavedAdhocReports";
                rs_reports = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName58, rs_reports);

                //LDW while (!rs_reports.EOF)
                foreach (DataRow myRow58 in modGlobal.gv_rs.Tables[sqlTableName58].Rows)
                {
                    ReportID = myRow58.Field<int>("Report_ID");

                    //update null join operators
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update any null criteria set
                    modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";

                    //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName59 = "tbl_setup_SavedAdhocReportSumCriteria";
                    rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName59, rs_critSet);

                    if (rs_critSet.Tables[sqlTableName59].Rows.Count == 0)
                    {
                        SetNum = 1;
                        //set all of them to a set number, if any criteria exists
                        modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";

                        //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName60 = "tbl_setup_SavedAdhocReportSumCriteria";
                        rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName60, rs_critSet);
                        if (rs_critSet.Tables[sqlTableName60].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportSumCriteria ";
                            modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, SetNum);
                            modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            SetNum = SetNum + 1;
                        }

                        modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";

                        //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName61 = "tbl_setup_SavedAdhocReportSumCriteria";
                        rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName61, rs_critSet);
                        if (rs_critSet.Tables[sqlTableName61].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportSumCriteria ";
                            modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, SetNum);
                            modGlobal.gv_sql = string.Format("{0} where Report_ID =  {1}", modGlobal.gv_sql, ReportID);
                            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }

                    //update the set order
                    modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                    //gv_sql = gv_sql & " and CriteriaSet is not null "
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName62 = "tbl_Setup_SavedAdhocReportSumCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName62, modGlobal.gv_rs);
                    MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName62].Rows[0]["MaxSet"]);
                    if (MaxSet > 0)
                    {

                        //give the max number to the null criteria set
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                        modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                        //adjust the order of the set
                        for (i = 1; i <= MaxSet; i++)
                        {
                            modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportSumCriteria ";
                            modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                            modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, i);
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName63 = "tbl_Setup_SavedAdhocReportSumCriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName63, modGlobal.gv_rs);
                            if (modGlobal.gv_rs.Tables[sqlTableName63].Rows.Count == 0)
                            {
                                for (j = i; j <= MaxSet; j++)
                                {
                                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                                    modGlobal.gv_sql = string.Format("{0} set CriteriaSet = {1}", modGlobal.gv_sql, j - 1);
                                    modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, ReportID);
                                    modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, j);
                                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName64 = "tbl_Setup_SavedAdhocReportSumCriteria";
                                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName64, modGlobal.gv_rs);
                                }
                            }
                        }
                    }

                    //LDW rs_reports.MoveNext();
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

        /*LDW not used
        public void RefreshCriteriaSetList()
        {
            //    MsgBox "is this obsolete?"

            //    If cboReportList.ListIndex < 0 Then
            //        Exit Sub
            //    End If
            //    gv_sql = "Select CriteriaSet "
            //    gv_sql = gv_sql & " from tbl_Setup_SavedAdhocReportCriteria "
            //    gv_sql = gv_sql & " where Report_ID = " & cboReportList.ItemData(cboReportList.ListIndex)
            //    gv_sql = gv_sql & " and CriteriaSet is not null "
            //    gv_sql = gv_sql & " group by  CriteriaSet "
            //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
            //    If gv_rs.RowCount > 0 Then
            //        gv_rs.MoveLast
            //        TotalSet = gv_rs.RowCount
            //        gv_rs.MoveFirst
            //    End If
            //
            //    cboCriteriaSet.Clear
            //    SetIndex = 1
            //    While Not gv_rs.EOF
            //        cboCriteriaSet.AddItem "Set " & SetIndex
            //        cboCriteriaSet.ItemData(cboCriteriaSet.Items.Count-1) = SetIndex
            //        SetIndex = SetIndex + 1
            //
            //        gv_rs.MoveNext
            //    Wend
            //
            //    cboCriteriaSet.AddItem "Set " & SetIndex
            //    cboCriteriaSet.ItemData(cboCriteriaSet.Items.Count-1) = SetIndex
        } */

    }
}
