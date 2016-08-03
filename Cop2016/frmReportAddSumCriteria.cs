using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmReportAddSumCriteria : Telerik.WinControls.UI.RadForm
    {

        public frmReportAddSumCriteria()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void frmReportAddSumCriteria_Load(object sender, EventArgs e)
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            this.CenterToParent();

            try
            {
                lblMessage.Text = "Setup Summarization Criteria for this report: " + frmReportSetupCopy.cboReportList.Text;

                RefreshIndicatorList();
                RefreshCategoryList();
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

        public void RefreshIndicatorList()
        {
            var LIndex = 0;

            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ((recordstatus is NULL) or ((recordstatus is not NULL) and (recordstatus = ''))) and ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                //Display the list of fields
                lstIndicatorList.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    lstIndicatorList.Items.Add(new ListBoxItem(myRow1.Field<string>("Description"), myRow1.Field<int>("IndicatorID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

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
            //errorhandler:


            //LDW modGlobal.CheckForErrors();
        }

        public void RefreshCategoryList()
        {
            var LIndex = 0;

            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_measure_cat ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by cat ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_measure_cat";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //Display the list of fields
                cboCategory.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    cboCategory.Items.Add(new ListBoxItem(myRow2.Field<string>("CAT") + " - " + myRow2.Field<string>("CAT_DESC"), myRow2.Field<int>("measure_catid")).ToString());
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstIndicatorList.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select an indicator from the list");
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

                AddSumCriteria();
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

        public void AddSumCriteria()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SavedAdhocReportSumCriteria", "CriteriaID");



            try
            {
                if (cboEqual.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the operator.");
                    return;
                }

                if (cboCategory.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the Measure Category.");
                    return;
                }

                modGlobal.gv_Action = "Add";

                CritTitle = string.Format("{0} {1} {2}", lstIndicatorList.Text, cboEqual.Text, Strings.Left(cboCategory.Text, 2));

                modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Report_ID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstIndicatorList, lstIndicatorList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboEqual.Text);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboCategory, cboCategory.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

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

        public void RefreshSetDef()
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();


            try
            {
                if (cboSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_ID = {1}", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_SavedAdhocReportSumCriteria";
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

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = string.Format("{0} where Report_id = {1}", modGlobal.gv_sql, Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_SavedAdhocReportSumCriteria";
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
    }
}
