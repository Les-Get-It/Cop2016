using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSubmissionCopyCriteria : Telerik.WinControls.UI.RadForm
    {
        public string rdcSubmissionFieldListTable = "tbl_setup_SubmitGroup";


        public frmSubmissionCopyCriteria()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboColumns_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int NewCritID;

            try
            {
                if (cboSet.SelectedIndex < 0 | cboColumns.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Define the definition of the new criteria.");
                }
                else
                {
                    //copy the criteria
                    modGlobal.gv_Action = "Add";
                    NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
                    modGlobal.gv_sql = " insert into tbl_Setup_SubmitCriteria (";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SubmitCriteriaID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
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
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboColumns, cboColumns.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboJoinOperator.Text);
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where SubmitCriteriaID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(frmSubmissionSetupCopy.lstSummaryDef, frmSubmissionSetupCopy.lstSummaryDef.SelectedIndex));

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

        private void frmSubmissionCopyCriteria_Load(object sender, EventArgs e)
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();

            this.CenterToParent();

            try
            {
                RefreshColumnList();
                RefreshSetList();

                modGlobal.gv_sql = "Select CriteriaTitle from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = string.Format("{0} where submitcriteriaid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(frmSubmissionSetupCopy.lstSummaryDef, frmSubmissionSetupCopy.lstSummaryDef.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_SubmitCriteria";
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
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();


            try
            {
                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["subgroupid"]);
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_SubmitCriteria";
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
            int SetIndex = 1;

            try
            {
                cboSet.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
                if (cboColumns.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboColumns, cboColumns.SelectedIndex));
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_SubmitCriteria";
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

        public void RefreshColumnList()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int thisSubGroup = 0;
            var i = 0;


            try
            {
                modGlobal.gv_sql = "Select g.*, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.showonreport as showcolonreport ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
                modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where g.state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and g.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by g.ordernumber, r.ordernumber, c.ordernumber ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                //Display the list of fields
                i = -1;
                cboColumns.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    i = i + 1;
                    cboColumns.Items.Add(new ListBoxItem(myRow4.Field<string>("GroupName") + " / " + myRow4.Field<int>("GroupRow")
                        + " / " + myRow4.Field<string>("GroupCol"), myRow4.Field<int>("subgroupid")).ToString());
                    if (myRow4.Field<int>("subgroupid") == Convert.ToInt32(frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["subgroupid"]))
                    {
                        thisSubGroup = i;
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();

                cboColumns.SelectedIndex = thisSubGroup;
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
