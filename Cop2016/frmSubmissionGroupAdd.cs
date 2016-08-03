using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSubmissionGroupAdd : Telerik.WinControls.UI.RadForm
    {
        public frmSubmissionGroupAdd()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAddSubmissionGroup_Click(object sender, EventArgs e)
        {
            int NextGroupID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitGroup", "GroupID");
            int NextOrderNumber;


            try
            {
                if (string.IsNullOrEmpty(txtGroupName.Text))
                {
                    RadMessageBox.Show("Please define the Group Name.");
                    return;
                }

                modGlobal.gv_Action = "Add";

                //find the next ordernumber
                modGlobal.gv_sql = " Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitGroup ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)
                {
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["maxordnum"]))
                    {
                        NextOrderNumber = 1;
                    }
                    else
                    {
                        NextOrderNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["maxordnum"]) + 1;
                    }
                }
                else
                {
                    NextOrderNumber = 1;
                }
                modGlobal.gv_rs.Dispose();

                //add the group
                modGlobal.gv_sql = "Insert into tbl_Setup_SubmitGroup";
                modGlobal.gv_sql = modGlobal.gv_sql + " (GroupID, GroupName, ShowGroupHeader, ShowOnReport, ShowTotal, OrderNumber, State, RecordStatus) ";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}',", modGlobal.gv_sql, NextGroupID, txtGroupName.Text);
                if (chkDisplayGroupTitle.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }

                if (chkIncludeGroup.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }
                if (chkShowTotal.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }

                modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, NextOrderNumber);
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

                modGlobal.gv_sql = modGlobal.gv_sql + ") ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshGroupList();
                txtGroupName.Text = "";
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

        private void cmdChangeStatus_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            string MoveToModule = null;


            try
            {
                if (lstGroups.SelectedIndex < 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this group to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_submitGroup ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where groupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstGroups, lstGroups.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                sstabGroup.ActiveWindow = sstabGroup0;
                RefreshGroupList();
                RefreshGroupToUpdate();

                modGlobal.gv_Action = "Update";
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

        private void cmdDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGroups.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete '" + Support.GetItemString(lstGroups, lstGroups.SelectedIndex) +
                    "'?", "Delete Group", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_Action = "Delete";

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubGroupID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitSubGroup, tbl_setup_SubmitGroupRow ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_SubmitSubGroup.GroupRowID = tbl_setup_SubmitGroupRow.GroupRowID  ";
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_SubmitGroupRow.GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstGroups, lstGroups.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where GrouprowID in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (Select GroupRowID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                    modGlobal.gv_sql = string.Format("{0} GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstGroups, lstGroups.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitGroupRow ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                    modGlobal.gv_sql = string.Format("{0} GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstGroups, lstGroups.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                    modGlobal.gv_sql = string.Format("{0} GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstGroups, lstGroups.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshGroupList();
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

        private void cmdMoveDown_Click(object sender, EventArgs e)
        {
            int thisindex;
            int maxordnum = 0;
            int CurrOrderNum; ;
            int ThisFieldID;

            try
            {
                if (lstGroups.SelectedIndex < 0)
                {
                    return;
                }

                ThisFieldID = Support.GetItemData(lstGroups, lstGroups.SelectedIndex);

                modGlobal.gv_sql = "Select ordernumber ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";
                modGlobal.gv_sql = string.Format("{0}  where groupID = {1}", modGlobal.gv_sql, ThisFieldID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_Submitgroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                CurrOrderNum = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["OrderNumber"]);

                modGlobal.gv_sql = "Select max(ordernumber) as maxordnum ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_Submitgroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);
                if (!string.IsNullOrEmpty(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["maxordnum"].ToString()))
                {
                    maxordnum = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["maxordnum"]);
                }

                if (CurrOrderNum < maxordnum)
                {
                    thisindex = lstGroups.SelectedIndex + 1;

                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                    modGlobal.gv_sql = string.Format("{0} set ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  ordernumber = " + CurrOrderNum + 1;

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum + 1;
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = string.Format("{0}  groupID = {1}", modGlobal.gv_sql, ThisFieldID);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshGroupList();

                    lstGroups.SelectedIndex = thisindex;
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

        private void cmdMoveUp_Click(object sender, EventArgs e)
        {
            int thisindex;
            int CurrOrderNum; ;
            int ThisFieldID;

            try
            {
                if (lstGroups.SelectedIndex < 0)
                {
                    return;
                }

                ThisFieldID = Support.GetItemData(lstGroups, lstGroups.SelectedIndex);

                modGlobal.gv_sql = "Select ordernumber ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";
                modGlobal.gv_sql = string.Format("{0} where groupID = {1}", modGlobal.gv_sql, ThisFieldID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_Submitgroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                CurrOrderNum = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["OrderNumber"]);

                if ((CurrOrderNum - 1) > 0)
                {
                    thisindex = lstGroups.SelectedIndex - 1;

                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                    modGlobal.gv_sql = string.Format("{0} set ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = string.Format("{0}  ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum - 1);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                    modGlobal.gv_sql = string.Format("{0} set ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum - 1);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = string.Format("{0}  groupID = {1}", modGlobal.gv_sql, ThisFieldID);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshGroupList();

                    lstGroups.SelectedIndex = thisindex;
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGroups.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a group from the list to update");
                    return;
                }

                modGlobal.gv_Action = "Update";

                modGlobal.gv_sql = "update tbl_Setup_SubmitGroup ";
                modGlobal.gv_sql = string.Format("{0} set GroupName = '{1}',", modGlobal.gv_sql, txtGroupNameToUpdate.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + " ShowGroupHeader = ";
                if (chkDisplayGroupTitleToUpdate.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y', ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " ShowOnReport = ";
                if (chkIncludeGroupToUpdate.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y' ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ShowTotal = ";
                if (chkShowTotalToUpdate.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y' ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
                }

                modGlobal.gv_sql = string.Format("{0} Where GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstGroups, lstGroups.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_SubmitGroupID = Support.GetItemData(lstGroups, lstGroups.SelectedIndex).ToString();

                RefreshGroupList();
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

        private void frmSubmissionGroupAdd_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            int OrdNum = 0;

            try
            {
                modGlobal.gv_Action = "NotDefined";

                if (modGlobal.gv_status == "TEST")
                {
                    cmdChangeStatus.Text = "Move to Active";
                }
                else
                {
                    cmdChangeStatus.Text = "Move to Test";
                }

                sstabGroup.ActiveWindow = sstabGroup0;

                //Re-order every set
                DataSet rs_group = new DataSet();

                modGlobal.gv_sql = "Select GroupID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by ordernumber ";

                //LDW rs_group = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_Submitgroup";
                rs_group = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, rs_group);

                //LDW while (!rs_group.EOF)
                foreach (DataRow myRow5 in rs_group.Tables[sqlTableName5].Rows)
                {
                    OrdNum = OrdNum + 1;

                    modGlobal.gv_sql = "Update tbl_setup_SubmitGroup ";
                    modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, OrdNum);
                    modGlobal.gv_sql = string.Format("{0} where groupid = {1}", modGlobal.gv_sql, rs_group.Tables[sqlTableName5].Rows[0]["groupid"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //LDW rs_group.MoveNext();
                }

                RefreshGroupList();
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

        public void RefreshGroupList()
        {
            try
            {
                modGlobal.gv_sql = "Select *  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by Ordernumber, GroupName";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //Display the list of fields
                lstGroups.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    lstGroups.Items.Add(new ListBoxItem(myRow8.Field<string>("GroupName"), myRow8.Field<int>("groupid")).ToString());
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

        private void lstGroups_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (lstGroups.Items.Count == 0)
                {
                    return;
                }
                RefreshGroupToUpdate();
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

        public void RefreshGroupToUpdate()
        {
            try
            {
                modGlobal.gv_sql = "Select *  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup ";
                if (lstGroups.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstGroups, lstGroups.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where GroupID = -1 ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName9].Rows.Count > 0)
                {
                    txtGroupNameToUpdate.Text = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["GroupName"].ToString();
                    chkDisplayGroupTitleToUpdate.CheckState = CheckState.Unchecked;
                    chkIncludeGroupToUpdate.CheckState = CheckState.Unchecked;
                    chkShowTotalToUpdate.CheckState = CheckState.Unchecked;

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["ShowGroupHeader"]))
                    {
                        if (modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["ShowGroupHeader"].ToString() == "Y")
                        {
                            chkDisplayGroupTitleToUpdate.CheckState = CheckState.Checked;
                        }
                    }

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["ShowOnReport"]))
                    {
                        if (modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["ShowOnReport"].ToString() == "Y")
                        {
                            chkIncludeGroupToUpdate.CheckState = CheckState.Checked;
                        }
                    }

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["ShowTotal"]))
                    {
                        if (modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["ShowTotal"].ToString() == "Y")
                        {
                            chkShowTotalToUpdate.CheckState = CheckState.Checked;
                        }
                    }

                    modGlobal.gv_rs.Dispose();
                }
                else
                {
                    txtGroupNameToUpdate.Text = "";
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
