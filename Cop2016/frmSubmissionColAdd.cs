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
    public partial class frmSubmissionColAdd : Telerik.WinControls.UI.RadForm
    {
        public string rdcSubmissionFieldListTable = "tbl_setup_SubmitGroup";
        public DataSet rdcSumFieldList = new DataSet();
        public string rdcSumFieldListTable = null;



        public frmSubmissionColAdd()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboGroupList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboGroupList.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
                modGlobal.gv_sql = string.Format("{0} where GroupID =  {1}", modGlobal.gv_sql, Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Title ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_SubmitGroupRow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                cboRowList.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    cboRowList.Items.Add(new ListBoxItem(myRow1.Field<string>("Title"), myRow1.Field<int>("grouprowID")).ToString());
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

        private void cboSumOp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            var LIndex = 0;

            try
            {
                if (cboSumOp.Text == "Count")
                {
                    lstSumField.Items.Clear();
                    //change the field to Discharge Date
                    //retrieve the Discharge Date from the list of fields
                    //gv_sql = "Select tbl_setup_DataDef.* "
                    //gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_TableDef "
                    //gv_sql = gv_sql & " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID "
                    //gv_sql = gv_sql & " and tbl_setup_TableDef.BaseTable = 'PATIENT' "

                    //gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName in ('DISCHARGE_DATE', 'OUTPATIENT ENCOUNTER DATE') "
                    //gv_sql = gv_sql & " order by  tbl_setup_DataDef.FieldName "

                    modGlobal.gv_sql = "EXEC getDateForIndicator " + Support.GetItemData(cboIndicator, cboIndicator.SelectedIndex);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "getDateForIndicator";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                    LIndex = -1;
                    //LDW modGlobal.gv_rs.MoveFirst();

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                    {
                        LIndex = LIndex + 1;
                        lstSumField.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());
                        lstSumField.SelectedIndex = LIndex;
                        lstSumField.Text = myRow2.Field<string>("FieldName");
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    modGlobal.gv_rs.Dispose();
                    //lstSumField.Enabled = False

                }
                else
                {
                    //lstSumField.Enabled = True
                    RefreshSumFieldList();
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

            //If cboSumOp.Text = "Count" Then
            //    'retrieve the Discharge Date from the list of fields
            //    gv_sql = "Select tbl_setup_DataDef.* "
            //    gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_TableDef "
            //    gv_sql = gv_sql & " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID "
            //    gv_sql = gv_sql & " and tbl_setup_TableDef.BaseTable = 'PATIENT' "
            //    gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
            //    gv_sql = gv_sql & " order by  tbl_setup_DataDef.FieldName "
            //
            //     rdcSumFieldList.Refresh
            //     Set rdcSumFieldList.Resultset = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
            //
            //     cboSumField.Clear
            //     Table_ListIndex = -1
            //     LIndex = -1
            //     While Not rdcSumFieldList.Resultset.EOF
            //         LIndex = LIndex + 1
            //         Table_ListIndex = LIndex
            //
            //         cboSumField.AddItem rdcSumFieldList.Resultset!FieldName
            //         cboSumField.ItemData(cboSumField.NewIndex) = rdcSumFieldList.Resultset!DDID
            //         rdcSumFieldList.Resultset.MoveNext
            //     Wend
            //
            //End If
        }

        private void cmdAddField_Click(object sender, EventArgs e)
        {
            int NextsgfieldID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitSubGroupfields", "SubmitSubGroupfieldID");

            try
            {
                if (lstColumns.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a column to update.");
                    return;
                }

                if (cboAllFields.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a field to add to list.");
                    return;
                }

                if (cboSumOpToUpdate.Text == "Count" & lstSumFieldToUpdate.Items.Count > 0)
                {
                    RadMessageBox.Show("Only one field can be selected for a Count operation.");
                    return;
                }

                modGlobal.gv_Action = "Update";


                //add the field
                modGlobal.gv_sql = "Insert into tbl_Setup_SubmitSubGroupfields";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitSubGroupfieldid, SubGroupID, aggregatefieldid) ";
                modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, NextsgfieldID);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                modGlobal.gv_sql = string.Format("{0},{1}) ", modGlobal.gv_sql, Support.GetItemData(cboAllFields, cboAllFields.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                UpdateColDetails();

                RefreshFieldListToUpdate();
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

        private void cmdAddSubmissionGroup_Click(object sender, EventArgs e)
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int newid;
            int NextColID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitSubGroup", "SubGroupID");
            int NextOrderNumber;
            var i = 0;
            bool fieldselected = false;

            try
            {

                if (cboGroupList.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Group.");
                    return;
                }

                if (cboRowList.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Row.");
                    return;
                }

                if (cboIndicator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please define the indicator related to this column.");
                    return;
                }

                if (cboSumOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please define the Summary Operation for this column.");
                    return;
                }

                if (lstSumField.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please define at least one field that will be summarized for this column.");
                    return;
                }

                if (cboSumOp.Text == "Sum")
                {
                    for (i = 0; i <= lstSumField.Items.Count - 1; i++)
                    {
                        if (lstSumField.SelectedIndex == (i))
                        {
                            fieldselected = true;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    if (fieldselected == false)
                    {
                        RadMessageBox.Show("Please define at least one field that will be summarized for this column.");
                        return;
                    }
                }


                modGlobal.gv_Action = "Add";

                //find the next ordernumber
                modGlobal.gv_sql = " Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitSubGroup ";
                modGlobal.gv_sql = string.Format("{0} Where GroupRowID = {1}", modGlobal.gv_sql, frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["grouprowID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count > 0)
                {
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["maxordnum"]))
                    {
                        NextOrderNumber = 1;
                    }
                    else
                    {
                        NextOrderNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["maxordnum"]) + 1;
                    }
                }
                else
                {
                    NextOrderNumber = 1;
                }
                modGlobal.gv_rs.Dispose();

                //add the group
                modGlobal.gv_sql = "Insert into tbl_Setup_SubmitSubGroup";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubGroupID, GroupRowID, Title, IndicatorID, AggregateFunction,  ShowonReport, OrderNumber) ";
                modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, NextColID);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRowList, cboRowList.SelectedIndex);
                modGlobal.gv_sql = string.Format("{0},'{1}',", modGlobal.gv_sql, txtColName.Text);
                modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, Support.GetItemData(cboIndicator, cboIndicator.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboSumOp.Text);
                if (chkIncludeCol.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }
                modGlobal.gv_sql = string.Format("{0}{1}) ", modGlobal.gv_sql, NextOrderNumber);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                // SR - 4.25.2008 - commented out because regardless of what summary operation it should use ddid from selected fields...
                //    If cboSumOp.Text = "Count" Then
                //        newid = FindMaxRecID("tbl_Setup_Submitsubgroupfields", "SubmitsubgroupfieldID")
                //
                //'        gv_sql = "Select tbl_setup_DataDef.* "
                //'        gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_TableDef "
                //'        gv_sql = gv_sql & " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID "
                //'        gv_sql = gv_sql & " and tbl_setup_TableDef.BaseTable = 'PATIENT' "
                //'        gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
                //'        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //
                //        gv_sql = "Insert into tbl_Setup_Submitsubgroupfields (SubmitsubgroupfieldID, Subgroupid, AggregateFieldID)"
                //        gv_sql = gv_sql & " Values (" & newid
                //        gv_sql = gv_sql & "," & NextColID
                //        gv_sql = gv_sql & "," & lstSumField.ItemData(lstSumField.ListIndex) & ")"
                //        gv_cn.Execute gv_sql
                //
                //    Else
                //add the fields that will be summarized
                for (i = 0; i <= lstSumField.Items.Count - 1; i++)
                {
                    if (lstSumField.SelectedIndex == (i))
                    {
                        newid = modDBSetup.FindMaxRecID("tbl_Setup_Submitsubgroupfields", "SubmitsubgroupfieldID");

                        modGlobal.gv_sql = "Insert into tbl_Setup_Submitsubgroupfields (SubmitsubgroupfieldID, Subgroupid, AggregateFieldID)";
                        modGlobal.gv_sql = string.Format("{0} Values ({1}", modGlobal.gv_sql, newid);
                        modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, NextColID);
                        modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, Support.GetItemData(lstSumField, i));

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }
                //    End If
                cboGroupList.SelectedIndex = -1;
                cboGroupList.Text = "";
                cboRowList.SelectedIndex = -1;
                cboRowList.Text = "";
                txtColName.Text = "";
                cboIndicator.SelectedIndex = -1;
                cboIndicator.Text = "";
                cboSumOp.SelectedIndex = -1;
                cboSumOp.Text = "";
                lstSumField.SelectedIndex = -1;
                lstSumField.Text = "";

                RefreshColumnList();
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

        private void cmdDeleteColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstColumns.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete '" +
                    Support.GetItemString(lstColumns, lstColumns.SelectedIndex) + "'?", "Delete Column", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_Action = "Delete";

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = string.Format("{0} Where SubGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroupFields ";
                    modGlobal.gv_sql = string.Format("{0} Where SubGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroup ";
                    modGlobal.gv_sql = string.Format("{0} Where SubGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshColumnList();
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
            int CurrentFieldindex;
            string CurrentField = null;
            DataSet thisrs = new DataSet();
            DataSet rs = new DataSet();


            try
            {
                if (lstColumns.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select OrderNumber, GroupRowID  from tbl_Setup_SubmitSubGroup ";
                    modGlobal.gv_sql = string.Format("{0} where subgroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_Setup_SubmitSubGroup";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["OrderNumber"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        modGlobal.gv_sql = "Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitSubGroup ";
                        modGlobal.gv_sql = string.Format("{0} where GroupRowID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["grouprowID"]);
                        //LDW rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName6 = "tbl_Setup_SubmitSubGroup";
                        rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, rs);

                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["OrderNumber"]) < Convert.ToInt32(rs.Tables[sqlTableName6].Rows[0]["maxordnum"]))
                        {
                            CurrentField = Support.GetItemString(lstColumns, lstColumns.SelectedIndex);
                            CurrentFieldindex = lstColumns.SelectedIndex;
                            //update the field that is one order higher than this one
                            modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                            modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["OrderNumber"]);
                            modGlobal.gv_sql = string.Format("{0} where GroupRowID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["grouprowID"]);
                            modGlobal.gv_sql = string.Format("{0} and OrderNumber = {1}", modGlobal.gv_sql, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["OrderNumber"]) + 1);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                            modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["OrderNumber"]) + 1);
                            modGlobal.gv_sql = string.Format("{0} where subgroupid = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            RefreshColumnList();

                            //set focus on the same field after refresh
                            if (CurrentFieldindex < lstColumns.Items.Count)
                            {
                                lstColumns.SelectedIndex = CurrentFieldindex + 1;
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

        private void cmdMoveUp_Click(object sender, EventArgs e)
        {
            int CurrentFieldindex;
            string CurrentField = null;
            DataSet thisrs = new DataSet();


            try
            {
                if (lstColumns.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select OrderNumber, GroupRowID  from tbl_Setup_SubmitSubGroup ";
                    modGlobal.gv_sql = string.Format("{0} where subgroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_Setup_SubmitSubGroup";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]) > 1)
                        {
                            CurrentField = Support.GetItemString(lstColumns, lstColumns.SelectedIndex);
                            CurrentFieldindex = lstColumns.SelectedIndex;
                            //update the field that is one order higher than this one
                            modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                            modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]);
                            modGlobal.gv_sql = string.Format("{0} where GroupRowID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["grouprowID"]);
                            modGlobal.gv_sql = string.Format("{0} and OrderNumber = {1}", modGlobal.gv_sql, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]) - 1);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                            modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]) - 1);
                            modGlobal.gv_sql = string.Format("{0} where subgroupid = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            RefreshColumnList();

                            //set focus on the same field after refresh
                            if (CurrentFieldindex > 0)
                            {
                                lstColumns.SelectedIndex = CurrentFieldindex - 1;
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

        private void cmdRemoveField_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstColumns.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a column to update.");
                    return;
                }

                if (lstSumFieldToUpdate.Items.Count == 1)
                {
                    RadMessageBox.Show("At least one field is required in the selected summarized fields list. Please add a field to the list before removing the existing one.");
                    return;
                }

                if (lstSumFieldToUpdate.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select field to remove.");
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show(string.Format("Are you sure you want to delete '{0}' from the list of selected fields?",
                    Support.GetItemString(lstSumFieldToUpdate, lstSumFieldToUpdate.SelectedIndex)), "Delete Field", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.No))
                {
                    return;
                }

                modGlobal.gv_Action = "Update";


                modGlobal.gv_sql = "delete tbl_Setup_SubmitSubGroupfields ";
                modGlobal.gv_sql = string.Format("{0} Where SubmitSubGroupfieldID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSumFieldToUpdate, lstSumFieldToUpdate.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                UpdateColDetails();

                RefreshFieldListToUpdate();
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

        private void cmdUpdateColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstColumns.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a column to update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtColNameToUpdate.Text))
                {
                    RadMessageBox.Show("Please define the Column name.");
                    return;
                }
                if (cboIndicatorToUpdate.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please define the indicator associated with this column.");
                    return;
                }
                if (cboSumOpToUpdate.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please define the summarization type.");
                    return;
                }
                //If cboSumFieldToUpdate.ListIndex < 0 Then
                //    MsgBox "Please define the summarized field."
                //    Exit Sub
                //End If


                modGlobal.gv_Action = "Update";

                UpdateColDetails();

                modGlobal.gv_SubmitColID = Support.GetItemData(lstColumns, lstColumns.SelectedIndex).ToString();

                RefreshColumnList();
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

        private void frmSubmissionColAdd_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            int OrdNum;
            string txtGroupToUpdate = null;
            DataSet rs_row = new DataSet();
            DataSet rs_subg = new DataSet();


            try
            {
                sstabColumns.ActiveWindow = sstabColumns0;
                sstabUpdate.ActiveWindow = sstabUpdate0;

                modGlobal.gv_Action = "NotDefined";
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
                const string sqlTableName10 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                cboGroupList.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                {
                    cboGroupList.Items.Add(new ListBoxItem(myRow10.Field<string>("GroupName"), myRow10.Field<int>("groupid")).ToString());

                    txtGroupToUpdate = myRow10.Field<string>("GroupName");
                    //cboGroupListToUpdate.AddItem gv_rs!GroupName
                    //cboGroupListToUpdate.ItemData(cboGroupListToUpdate.NewIndex) = gv_rs!GroupID

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                //Refresh the row list
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where GroupID = -1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Title ";

                //rdcFieldList.Refresh
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_SubmitGroupRow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                cboRowList.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                {
                    cboRowList.Items.Add(new ListBoxItem(myRow11.Field<string>("Title"), myRow11.Field<int>("grouprowID")).ToString());

                    cboRowListToUpdate.Items.Add(new ListBoxItem(myRow11.Field<string>("Title"), myRow11.Field<int>("grouprowID")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                RefreshSumFieldList();
                RefreshIndicatorList();
                RefreshColumnList();

                //Re-order every set

                modGlobal.gv_sql = "Select GroupRowID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitsubgroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " group by GroupRowID ";
                //LDW rs_row = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_setup_Submitsubgroup";
                rs_row = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, rs_row);

                //LDW while (!rs_row.EOF)
                foreach (DataRow myRow11 in rs_row.Tables[sqlTableName11].Rows)
                {
                    modGlobal.gv_sql = "Select * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitsubgroup ";
                    modGlobal.gv_sql = string.Format("{0} where GroupRowID = {1}", modGlobal.gv_sql, myRow11.Field<int>("grouprowID"));
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderNumber ";
                    //LDW rs_subg = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName13 = "tbl_setup_Submitsubgroup";
                    rs_subg = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, rs_subg);
                    OrdNum = 0;
                    //LDW while (!rs_subg.EOF)
                    foreach (DataRow myRow13 in rs_subg.Tables[sqlTableName13].Rows)
                    {
                        OrdNum = OrdNum + 1;
                        modGlobal.gv_sql = "Update tbl_setup_SubmitSubGroup ";
                        modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, OrdNum);
                        modGlobal.gv_sql = string.Format("{0} where subgroupid = {1}", modGlobal.gv_sql, myRow13.Field<int>("SubGroupID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW rs_subg.MoveNext();
                    }
                    //LDW rs_row.MoveNext();
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

        public void RefreshIndicatorList()
        {
            try
            {
                //retrieve the list of Indicators
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                cboIndicator.Items.Clear();
                cboIndicatorToUpdate.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow14 in modGlobal.gv_rs.Tables[sqlTableName14].Rows)
                {
                    cboIndicator.Items.Add(new ListBoxItem(myRow14.Field<string>("Description"), myRow14.Field<int>("IndicatorID")).ToString());

                    cboIndicatorToUpdate.Items.Add(new ListBoxItem(myRow14.Field<string>("Description"), myRow14.Field<int>("IndicatorID")).ToString());

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

        public void RefreshSumFieldList()
        {
            try
            {
                //retrieve the list of Patient Table Fields (only discharge date or numeric fields)
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and (upper(tbl_setup_DataDef.fieldname) in ('DISCHARGE_DATE', 'OUTPATIENT ENCOUNTER DATE') ";
                modGlobal.gv_sql = modGlobal.gv_sql + " or tbl_setup_DataDef.fieldtype = 'Number') ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_DataDef.FieldName ";


                rdcSumFieldList.AcceptChanges();
                //LDW rdcSumFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcSumFieldListTable = "tbl_setup_DataDef";
                rdcSumFieldList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcSumFieldListTable, rdcSumFieldList);
                rdcSumFieldList.AcceptChanges();

                lstSumField.Items.Clear();
                cboAllFields.Items.Clear();

                //LDW while (!rdcSumFieldList.Resultset.EOF)
                foreach (DataRow myRow15 in rdcSumFieldList.Tables[rdcSumFieldListTable].Rows)
                {
                    lstSumField.Items.Add(new ListBoxItem(myRow15.Field<string>("FieldName"), myRow15.Field<int>("DDID")).ToString());

                    cboAllFields.Items.Add(new ListBoxItem(myRow15.Field<string>("FieldName"), myRow15.Field<int>("DDID")).ToString());

                    //LDW rdcSumFieldList.Resultset.MoveNext();
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

        public void RefreshColumnList()
        {
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
                const string sqlTableName16 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                //Display the list of fields
                lstColumns.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow16 in modGlobal.gv_rs.Tables[sqlTableName16].Rows)
                {
                    lstColumns.Items.Add(new ListBoxItem(string.Format("{0} / {1} / {2}", myRow16.Field<string>("GroupName"), myRow16.Field<string>("GroupRow"), myRow16.Field<string>("GroupCol")),
                        myRow16.Field<int>("SubGroupID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();

                lblGroupToUpdate.Text = "";
                cboRowListToUpdate.SelectedIndex = -1;
                txtColNameToUpdate.Text = "";
                cboIndicatorToUpdate.SelectedIndex = -1;
                cboSumOpToUpdate.SelectedIndex = -1;
                lstSumFieldToUpdate.Items.Clear();
                lstSumFieldToUpdate.SelectedIndex = -1;
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

        private void frmSubmissionColAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            string colnames = null;
            //let's make sure that for all columns with Sum operation
            // only numeric fields have been selected.

            try
            {
                modGlobal.gv_sql = "Select ";
                modGlobal.gv_sql = modGlobal.gv_sql + " g.GroupName + '/' + gr.Title + '/' +  sg.Title as cols ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (((tbl_setup_SubmitsubGroupfields as sgf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SubmitsubGroup as sg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sgf.subgroupid = sg.subgroupid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Submitgrouprow as gr ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on gr.grouprowid = sg.grouprowid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Submitgroup as g ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on gr.groupid = g.groupid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Datadef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sgf.aggregatefieldid = dd.ddid ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where (g.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and g.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and upper(sg.aggregatefunction) = 'SUM' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and upper(dd.Fieldtype) <> 'NUMBER' ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "tbl_setup_SubmitsubGroupfields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName17].Rows.Count > 0)
                {
                    colnames = "";
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow17 in modGlobal.gv_rs.Tables[sqlTableName17].Rows)
                    {
                        colnames = Strings.Chr(10) + Strings.Chr(13) + myRow17.Field<string>("cols");
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    RadMessageBox.Show(string.Format("At least one aggregate field defined for the following Column(s) with Sum operation, is not numeric. " +
                        "Please correct the field list before closing this form.{0}{1}{2}", Strings.Chr(10), Strings.Chr(13), colnames));
                    //LDW Cancel = true;
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

        private void lstColumns_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshColToUpdate();
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

        public void RefreshColToUpdate()
        {
            var i = 0;
            int thisGroupID;
            int thisRowID;

            try
            {
                modGlobal.gv_sql = "Select g.*, ";
                //i.Description as Indicator, "
                modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.ShowOnReport as ShowColonReport ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
                modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";
                modGlobal.gv_sql = string.Format("{0} where c.SubGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName19 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                lblGroupToUpdate.Text = modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["GroupName"].ToString();
                thisRowID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["grouprowID"]);
                thisGroupID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["groupid"]);


                for (i = 0; i <= cboRowListToUpdate.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(cboRowListToUpdate, i) == Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["grouprowID"]))
                    {
                        cboRowListToUpdate.SelectedIndex = i;
                        //cboRowListToUpdate.Text = gv_rs!GroupRow
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                txtColNameToUpdate.Text = modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["GroupCol"].ToString();

                for (i = 0; i <= cboIndicatorToUpdate.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(cboIndicatorToUpdate, i) == Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["groupid"]))
                    {
                        cboIndicatorToUpdate.SelectedIndex = i;
                        //cboIndicatorToUpdate.Text = gv_rs!AggregateFunction
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                for (i = 0; i <= cboSumOpToUpdate.Items.Count - 1; i++)
                {
                    if (Support.GetItemString(cboSumOpToUpdate, i) == modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["AggregateFunction"].ToString())
                    {
                        cboSumOpToUpdate.SelectedIndex = i;
                        //cboSumOpToUpdate.Text = gv_rs!AggregateFunction
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                // SR - 4.28.2008 - do not assume that all count are counting discharge date
                //    If cboSumOpToUpdate.Text = "Count" Then
                //        sstabUpdate.TabEnabled(1) = False
                //    Else
                //        sstabUpdate.TabEnabled(1) = True
                //    End If

                chkIncludeColToUpdate.CheckState = CheckState.Unchecked;

                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["ShowcolOnReport"]))
                {
                    if (modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["ShowcolOnReport"].ToString() == "Y")
                    {
                        chkIncludeColToUpdate.CheckState = CheckState.Checked;
                    }
                }

                modGlobal.gv_rs.Dispose();


                RefreshFieldListToUpdate();

                //For i = 0 To cboSumFieldToUpdate.ListCount - 1
                //    If cboSumFieldToUpdate.ItemData(i) = gv_rs!AggregateFieldID Then
                //        cboSumFieldToUpdate.ListIndex = i
                //        'cboSumFieldToUpdate.Text = gv_rs!AggregateFunction
                //        Exit For
                //    End If
                //Next i


                //Refresh the row list
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
                modGlobal.gv_sql = string.Format("{0} where GroupID = {1}", modGlobal.gv_sql, thisGroupID);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Title ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_SubmitGroupRow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                cboRowListToUpdate.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow20 in modGlobal.gv_rs.Tables[sqlTableName20].Rows)
                {
                    cboRowListToUpdate.Items.Add(new ListBoxItem(myRow20.Field<string>("Title"), myRow20.Field<int>("grouprowID")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                for (i = 0; i <= cboRowListToUpdate.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(cboRowListToUpdate, i) == thisRowID)
                    {
                        cboRowListToUpdate.SelectedIndex = i;
                        //cboSumFieldToUpdate.Text = gv_rs!AggregateFunction
                        break; // TODO: might not be correct. Was : Exit For
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

        public void RefreshFieldListToUpdate()
        {
            try
            {
                //Refresh the field list
                modGlobal.gv_sql = "Select sg.*, dd.fieldname ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitsubgroupfields as sg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sg.aggregatefieldid = dd.ddid ";
                modGlobal.gv_sql = string.Format("{0} where sg.subgroupid = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.fieldname ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName21 = "tbl_setup_Submitsubgroupfields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);

                lstSumFieldToUpdate.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow21 in modGlobal.gv_rs.Tables[sqlTableName21].Rows)
                {
                    lstSumFieldToUpdate.Items.Add(new ListBoxItem(myRow21.Field<string>("FieldName"), myRow21.Field<int>("submitSubgroupFieldID")).ToString());

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

        public void UpdateColDetails()
        {
            int newid;
            //This is called not only when the update button is clicked
            // but also when field list is updated,
            // just to make sure to save changes if user forgot to click on update
            //The validation messages only show up when user click on Update button,
            // but when this sub routine is called from other places, we just want to skip the update

            try
            {
                if (lstColumns.SelectedIndex < 0)
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtColNameToUpdate.Text))
                {
                    return;
                }
                if (cboIndicatorToUpdate.SelectedIndex < 0)
                {
                    return;
                }
                if (cboSumOpToUpdate.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                modGlobal.gv_sql = string.Format("{0} set Title = '{1}',", modGlobal.gv_sql, txtColNameToUpdate.Text);
                modGlobal.gv_sql = string.Format("{0} GroupRowID = {1},", modGlobal.gv_sql, Support.GetItemData(cboRowListToUpdate, cboRowListToUpdate.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID = ";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboIndicatorToUpdate, cboIndicatorToUpdate.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " AggregateFunction = ";
                modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, cboSumOpToUpdate.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + " ShowOnReport = ";

                if (chkIncludeColToUpdate.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y'";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null";
                }
                modGlobal.gv_sql = string.Format("{0} Where SubGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                // SR - 4.28.2008 - do not assume that all count operations are counting discharge date!!
                // ADDED BACK 4.12.2010 - the MUST be a aggregate field selected
                if (cboSumOpToUpdate.Text == "Count")
                {
                    if (lstSumFieldToUpdate.Items.Count == 0)
                    {
                        //        gv_sql = "Delete tbl_Setup_SubmitSubGroupFields "
                        //        gv_sql = gv_sql & " where subgroupid = " & lstColumns.ItemData(lstColumns.ListIndex)
                        //        gv_cn.Execute gv_sql

                        newid = modDBSetup.FindMaxRecID("tbl_Setup_Submitsubgroupfields", "SubmitsubgroupfieldID");


                        modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' ";

                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName22 = "tbl_setup_DataDef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                        if (modGlobal.gv_rs.Tables[sqlTableName22].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "Insert into tbl_Setup_Submitsubgroupfields (SubmitsubgroupfieldID, Subgroupid, AggregateFieldID)";
                            modGlobal.gv_sql = string.Format("{0} Values ({1}", modGlobal.gv_sql, newid);
                            modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, Support.GetItemData(lstColumns, lstColumns.SelectedIndex));
                            modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName22].Rows[0]["DDID"]));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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
    }
}
