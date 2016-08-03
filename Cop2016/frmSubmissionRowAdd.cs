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
    public partial class frmSubmissionRowAdd : Telerik.WinControls.UI.RadForm
    {
        public frmSubmissionRowAdd()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAddSubmissionGroup_Click(object sender, EventArgs e)
        {
            int NextRowID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitGroupRow", "GroupRowID");
            int NextOrderNumber;

            try
            {
                if (cboGroupList.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please Select a Group From the List.");
                    return;
                }

                if (string.IsNullOrEmpty(txtRowName.Text))
                {
                    RadMessageBox.Show("Please define the Row Name.");
                    return;
                }


                modGlobal.gv_Action = "Add";

                //check for duplicates
                modGlobal.gv_sql = "Select g.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup as g left join tbl_Setup_SubmitGroupRow as r";
                modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID  ";
                modGlobal.gv_sql = string.Format("{0} Where g.GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and r.Title = '{1}'", modGlobal.gv_sql, txtRowName.Text);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)
                {
                    RadMessageBox.Show("This row for the selected group already exists.");
                    return;
                }

                //find the next ordernumber
                modGlobal.gv_sql = " Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitGroupRow ";
                modGlobal.gv_sql = string.Format("{0} Where GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_SubmitGroupRow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count > 0)
                {
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["maxordnum"]))
                    {
                        NextOrderNumber = 1;
                    }
                    else
                    {
                        NextOrderNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["maxordnum"]) + 1;
                    }
                }
                else
                {
                    NextOrderNumber = 1;
                }
                modGlobal.gv_rs.Dispose();

                //add the group
                modGlobal.gv_sql = "Insert into tbl_Setup_SubmitGroupRow";
                modGlobal.gv_sql = modGlobal.gv_sql + " (GroupRowID, GroupID, Title, ShowOnReport,  OrderNumber) ";
                modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, NextRowID);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex);
                modGlobal.gv_sql = string.Format("{0},'{1}',", modGlobal.gv_sql, txtRowName.Text);
                if (chkIncludeRow.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }
                modGlobal.gv_sql = string.Format("{0}{1}) ", modGlobal.gv_sql, NextOrderNumber);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                txtRowName.Text = "";
                RefreshRowList();
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

        private void cmdDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRows.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(string.Format("Are you sure you want to delete '{0}'?",
                    Support.GetItemString(lstRows, lstRows.SelectedIndex)), "Delete Row", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {

                    modGlobal.gv_Action = "Delete";

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID in  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubGroupID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitSubGroup ";
                    modGlobal.gv_sql = string.Format("{0} Where tbl_setup_SubmitSubGroup.GroupRowID = {1}", modGlobal.gv_sql, Support.GetItemData(lstRows, lstRows.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroup ";
                    modGlobal.gv_sql = string.Format("{0} Where GroupRowID = {1}", modGlobal.gv_sql, Support.GetItemData(lstRows, lstRows.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitGroupRow ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                    modGlobal.gv_sql = string.Format("{0} GroupRowID = {1}", modGlobal.gv_sql, Support.GetItemData(lstRows, lstRows.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshRowList();
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
            int CurrOrderNum;
            int ThisFieldID;

            try
            {
                if (lstRows.SelectedIndex < 0)
                {
                    return;
                }

                ThisFieldID = Support.GetItemData(lstRows, lstRows.SelectedIndex);

                //retrieve the current order
                modGlobal.gv_sql = "Select ordernumber ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                modGlobal.gv_sql = string.Format("{0} where grouprowid = {1}", modGlobal.gv_sql, Support.GetItemData(lstRows, lstRows.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_submitgrouprow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                CurrOrderNum = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["OrderNumber"]);

                if (CurrOrderNum != lstRows.Items.Count)
                {
                    thisindex = lstRows.SelectedIndex + 1;

                    modGlobal.gv_sql = "Select Groupid ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                    modGlobal.gv_sql = string.Format("{0} where grouprowid = {1}", modGlobal.gv_sql, ThisFieldID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_submitgrouprow";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                    modGlobal.gv_sql = string.Format("{0} set ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  ordernumber = " + CurrOrderNum + 1;
                    modGlobal.gv_sql = string.Format("{0}  and groupID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["groupid"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum + 1;
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = string.Format("{0}  grouprowID = {1}", modGlobal.gv_sql, ThisFieldID);
                    modGlobal.gv_sql = string.Format("{0}  and groupID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["groupid"]);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshRowList();

                    lstRows.SelectedIndex = thisindex;
                    //find the right field
                    //For i = 1 To rdcFieldList.Resultset.RowCount
                    //    If rdcFieldList.Resultset!DDID = ThisFieldID Then
                    //        Exit For
                    //    End If
                    //    rdcFieldList.Resultset.MoveNext
                    //Next i
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
            int CurrOrderNum;
            int ThisFieldID;

            try
            {
                if (lstRows.SelectedIndex < 0)
                {
                    return;
                }

                ThisFieldID = Support.GetItemData(lstRows, lstRows.SelectedIndex);

                //retrieve the current order
                modGlobal.gv_sql = "Select ordernumber ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                modGlobal.gv_sql = string.Format("{0} where grouprowid = {1}", modGlobal.gv_sql, Support.GetItemData(lstRows, lstRows.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_setup_submitgrouprow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                CurrOrderNum = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["OrderNumber"]);

                if (CurrOrderNum - 1 > 0)
                {
                    thisindex = lstRows.SelectedIndex - 1;

                    modGlobal.gv_sql = "Select Groupid ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                    modGlobal.gv_sql = string.Format("{0} where grouprowid = {1}", modGlobal.gv_sql, ThisFieldID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_setup_submitgrouprow";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                    modGlobal.gv_sql = string.Format("{0} set ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = string.Format("{0}  ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum - 1);
                    modGlobal.gv_sql = string.Format("{0}  and groupID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["groupid"]);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                    modGlobal.gv_sql = string.Format("{0} set ordernumber = {1}", modGlobal.gv_sql, CurrOrderNum - 1);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = string.Format("{0}  grouprowID = {1}", modGlobal.gv_sql, ThisFieldID);
                    modGlobal.gv_sql = string.Format("{0}  and groupID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["groupid"]);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshRowList();

                    lstRows.SelectedIndex = thisindex;
                    //find the right field
                    //For i = 1 To rdcFieldList.Resultset.RowCount
                    //    If rdcFieldList.Resultset!DDID = ThisFieldID Then
                    //        Exit For
                    //    End If
                    //    rdcFieldList.Resultset.MoveNext
                    //Next i
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
                if (lstRows.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a row to update.");
                    return;
                }
                if (cboGroupListToUpdate.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a Group for the row before updating.");
                    return;
                }

                if (!string.IsNullOrEmpty(txtRowNameToUpdate.Text))
                {
                    modGlobal.gv_Action = "Update";
                    modGlobal.gv_sql = "update tbl_Setup_SubmitGroupRow ";
                    modGlobal.gv_sql = string.Format("{0} set Title = '{1}',", modGlobal.gv_sql, txtRowNameToUpdate.Text);
                    modGlobal.gv_sql = string.Format("{0} GroupID = {1},", modGlobal.gv_sql, Support.GetItemData(cboGroupListToUpdate, cboGroupListToUpdate.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " ShowOnReport = ";
                    if (chkIncludeRowToUpdate.CheckState == CheckState.Checked)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " 'Y' ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
                    }
                    modGlobal.gv_sql = string.Format("{0} Where GroupRowID = {1}", modGlobal.gv_sql, Support.GetItemData(lstRows, lstRows.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_SubmitRowID = Support.GetItemData(lstRows, lstRows.SelectedIndex).ToString();

                    RefreshRowList();
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

        private void frmSubmissionRowAdd_Load(object sender, EventArgs e)
        {
            var LIndex = 0;
            int FCount;
            DataSet thisrs = new DataSet();

            this.CenterToParent();


            try
            {
                modGlobal.gv_Action = "NotDefined";
                sstabRow.ActiveWindow = sstabRow0;

                //re-order the rows

                modGlobal.gv_sql = "Select Groupid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgroup ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_submitgroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    modGlobal.gv_sql = "Select * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                    modGlobal.gv_sql = string.Format("{0} where groupid = {1}", modGlobal.gv_sql, myRow9.Field<int>("groupid"));
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by ordernumber ";

                    //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName10 = "tbl_setup_submitgrouprow";
                    thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, thisrs);

                    FCount = 0;

                    //LDW  while (!thisrs.EOF)
                    foreach (DataRow myRow10 in thisrs.Tables[sqlTableName10].Rows)
                    {
                        //first we make sure every field in this list has a number
                        FCount = FCount + 1;
                        modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + FCount;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where grouprowID = " + myRow10.Field<int>("grouprowID");
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW thisrs.MoveNext();
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                RefreshRowList();

                //Refresh the group list
                modGlobal.gv_sql = "Select * ";
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
                modGlobal.gv_sql = modGlobal.gv_sql + " order by GroupName";

                //rdcFieldList.Refresh
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                cboGroupList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                {
                    LIndex = LIndex + 1;

                    cboGroupList.Items.Add(new ListBoxItem(myRow11.Field<string>("GroupName"), myRow11.Field<int>("groupid")).ToString());

                    cboGroupListToUpdate.Items.Add(myRow11.Field<string>("GroupName"));
                    Support.SetItemData(cboGroupListToUpdate, cboGroupList.Items.Count - 1, myRow11.Field<int>("groupid"));

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

        public void RefreshRowList()
        {
            try
            {
                modGlobal.gv_sql = "Select g.*, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
                modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID  ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '" + modGlobal.gv_State + "')";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and g.RecordStatus = '" + modGlobal.gv_status + "'";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by g.Ordernumber, g.GroupName, r.OrderNumber, r.Title ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                //Display the list of fields
                lstRows.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                {
                    lstRows.Items.Add(new ListBoxItem(myRow12.Field<string>("GroupName") + " / " + myRow12.Field<string>("GroupRow"), myRow12.Field<int>("grouprowID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                cboGroupListToUpdate.SelectedIndex = -1;
                cboGroupListToUpdate.Text = "";
                txtRowNameToUpdate.Text = "";
                chkIncludeRowToUpdate.CheckState = CheckState.Unchecked;
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

        private void lstRows_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (lstRows.Items.Count == 0)
                {
                    return;
                }
                RefreshRowToUpdate();
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

        public void RefreshRowToUpdate()
        {
            var i = 0;

            try
            {
                modGlobal.gv_sql = "Select tbl_setup_SubmitGroupRow.*, tbl_Setup_SubmitGroup.GroupName  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow, tbl_Setup_SubmitGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_SubmitGroupRow.GroupID =  tbl_Setup_SubmitGroup.GroupID ";
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_SubmitGroupRow.GroupRowID = {1}", modGlobal.gv_sql, Support.GetItemData(lstRows, lstRows.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_SubmitGroupRow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                for (i = 0; i <= cboGroupListToUpdate.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(cboGroupListToUpdate, i) == Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["groupid"]))
                    {
                        cboGroupListToUpdate.SelectedIndex = i;
                        cboGroupListToUpdate.Text = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["GroupName"].ToString();
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
                txtRowNameToUpdate.Text = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["Title"].ToString();

                chkIncludeRowToUpdate.CheckState = CheckState.Unchecked;

                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["ShowOnReport"]))
                {
                    if (modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["ShowOnReport"].ToString() == "Y")
                    {
                        chkIncludeRowToUpdate.CheckState = CheckState.Checked;
                    }
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

    }
}
