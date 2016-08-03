using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static COP2001.RadDropBinder;

namespace COP2001
{
    public partial class frmTableSetup : RadForm
    {
        public static DataSet rdcFieldList = new DataSet();
        public string rdcFieldListTable = "tempTable1";


        public frmTableSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
           
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void RefreshDataTableList()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            var rdcTableList = new DataSet();
            List<Item> items = new List<Item>();

            try
            {
                //retrieve the list of batch types
                modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where TableType is null or TableType = 'DATA' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

                //LDW rdcTableList = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_TableDef";
                rdcTableList.Reset();
                rdcTableList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, rdcTableList);

                cboTableList.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!rdcTableList.Resultset.EOF)
                foreach (DataRow myRow1 in rdcTableList.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;


                    items.Add(new Item(myRow1.Field<int>("basetableid"), myRow1.Field<string>("BaseTable")));


                    //LDW rdcTableList.Resultset.MoveNext();
                }
                //LDW cboTableList.Items.Add(new ListBoxItem(rdcTableList.Resultset.rdoColumns["BaseTable"].Value, rdcTableList.Resultset.rdoColumns["basetableid"].Value));
                this.cboTableList.DataSource = items;
                this.cboTableList.DisplayMember = "Description";
                this.cboTableList.ValueMember = "Id";
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

        private void cboTableList_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                RefreshFieldList();
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

        private void cmdAddField_Click(Object eventSender, EventArgs eventArgs)
        {
            frmTableFieldAdd frmTableFieldAddCopy = new frmTableFieldAdd();
            bool FoundIt;
            int NewDDID = 0;

            try
            {
                if (string.IsNullOrEmpty(cboTableList.Text))
                {
                    //LDW RadMessageBox.Show("Please select a table from the list");

                    RadMessageBox.Show(this, "Please select a table from the list", "Add Field", MessageBoxButtons.OK, RadMessageIcon.Info);

                    return;
                }

                modGlobal.gv_Action = "";
                frmTableFieldAddCopy.ShowDialog();

                if (modGlobal.gv_Action == "Add")
                {
                    RefreshFieldList();
                    modGlobal.gv_sql = "Select max(DDID) as NewDDID from tbl_setup_DataDef ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                    //LDW NewDDID = modGlobal.gv_rs.rdoColumns["NewDDID"].Value;
                    NewDDID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["NewDDID"]);
                    FoundIt = false;

                    //LDW while ((!rdcFieldList.Resultset.EOF) & FoundIt == false)
                    foreach (DataRow myRow2 in rdcFieldList.Tables[rdcFieldListTable].Rows)
                    {
                        while (FoundIt == false)
                        {
                            //LDW if (rdcFieldList.Resultset.rdoColumns["DDID"].Value == NewDDID)
                            if (myRow2.Field<int>("DDID") == NewDDID)
                            {
                                FoundIt = true;
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

            //rdcFieldList.Resultset.Bookmark = bk
        }

        private void cmdChangeStatus_Click(Object eventSender, EventArgs eventArgs)
        {
            DialogResult resp;
            string MoveToModule = "";

            try
            {
                if (rdcFieldList.Tables[rdcFieldListTable].Rows.Count == 0)
                {
                    return;
                }

                //LDW if (rdcFieldList.Resultset.rdoColumns["FieldCategory"].Value == "Fix")
                if (rdcFieldList.Tables[rdcFieldListTable].Rows[0]["FieldCategory"].ToString() == "Fix")
                {
                    //LDW RadMessageBox.Show("Cannot move this field, because this is a fix field.");

                    RadMessageBox.Show(this, "Cannot move this field, because this is a fix field.", "Change Status", MessageBoxButtons.OK, RadMessageIcon.Error);

                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                //LDW resp = RadMessageBox.Show("Are you sure you want this field to the " + MoveToModule + " Module?", MsgBoxStyle.YesNo);

                resp = RadMessageBox.Show(this, string.Format("Are you sure you want this field to the {0} Module?", MoveToModule), "Change Status", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshFieldList();
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

        private void cmdClose_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdDelete_Click(Object eventSender, EventArgs eventArgs)
        {
            DialogResult Delfield;
            string msg = null;
            bool hasvalidation;


            try
            {

                if (rdcFieldList.Tables[rdcFieldListTable].Rows.Count > 0)
                {
                    //LDW if (rdcFieldList.Resultset.rdoColumns["FieldCategory"].Value == "Fix")
                    if (rdcFieldList.Tables[rdcFieldListTable].Rows[0]["FieldCategory"].ToString() == "Fix")
                    {
                        //LDW RadMessageBox.Show("Cannot delete this field, because this is a fix field.");

                        DialogResult ds3 = RadMessageBox.Show(this, "Cannot delete this field, because this is a fix field.", "Delete Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds3.ToString();
                        return;
                    }

                    hasvalidation = false;
                    modGlobal.gv_sql = "Select * from tbl_setup_TableValidation ";
                    modGlobal.gv_sql = string.Format("{0} where SourceDDID1 = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                    modGlobal.gv_sql = string.Format("{0} or SourceDDID2 = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                    modGlobal.gv_sql = string.Format("{0} or DestDDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName3 = "tbl_setup_TableValidation";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                    //LDW if (modGlobal.gv_rs.RowCount > 0)
                    if (modGlobal.gv_rs.Tables[sqlTableName3].Rows.Count > 0)
                    {
                        hasvalidation = true;
                    }
                    modGlobal.gv_sql = "Select * from tbl_setup_TableValidationAction ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName4 = "tbl_setup_TableValidationAction";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count > 0)
                    {
                        hasvalidation = true;
                    }

                    modGlobal.gv_sql = "Select * from tbl_setup_TableValidationAfterFieldupdate ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_TableValidationAfterFieldupdate";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName5].Rows.Count > 0)
                    {
                        hasvalidation = true;
                    }

                    if (hasvalidation == true)
                    {
                        //LDW RadMessageBox.Show("This field has been used in the validation setup. Remove the related validation before deleting the field.");

                        DialogResult ds4 = RadMessageBox.Show(this, "This field has been used in the validation setup. Remove the related validation before deleting the field.",
                            "Delete Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds4.ToString();
                        return;
                    }

                    modGlobal.gv_sql = "Select * from tbl_setup_submitsubgroupfields ";
                    modGlobal.gv_sql = string.Format("{0} where aggregatefieldid = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName6 = "tbl_setup_submitsubgroupfields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count > 0)
                    {
                        //LDW RadMessageBox.Show("This field has been used in the summarization process. Update the related summarization before deleting the field.");

                        DialogResult ds5 = RadMessageBox.Show(this, "This field has been used in the summarization process. Update the related summarization before deleting the field.",
                            "Delete Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds5.ToString();
                        return;
                    }

                    if (string.IsNullOrEmpty(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["OldFieldName"].ToString()) | Information.IsDBNull(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["OldFieldName"]))
                    {
                        msg = " Are you sure that you want to delete this field?";
                        //LDW Delfield = RadMessageBox.Show(msg, MsgBoxStyle.YesNo, "Delete Field");

                        Delfield = RadMessageBox.Show(this, msg, "Delete Field", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    }
                    else
                    {
                        msg = string.Format("This field has been mapped to a field in the older version.{0}{1}", Strings.Chr(10), Strings.Chr(13));
                        msg = msg + " Are you sure you want to delete this field?";
                        Delfield = RadMessageBox.Show(this, msg, "Delete Field", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    }
                    if (Delfield == DialogResult.Yes)
                    {
                        modGlobal.gv_sql = "Delete tbl_setup_DataReq ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "Delete tbl_setup_HospStatGroupFields ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "Delete tbl_setup_IndicatorGroupSet ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_Importvalidation ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_Importvalidation ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Where msgid in  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (select ivm.msgid ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Importvalidationmessage as ivm ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_importfields as imf ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " on ivm.importfieldid = imf.importfieldid ";
                        modGlobal.gv_sql = string.Format("{0} Where imf.DDID = {1})", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_Importvalidationmessage ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Where importfieldid in  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_importfields ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1})", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_ImportFields ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_submitcleanupcrit ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //was missing call to the execute command
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_submitcleanupcrit ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where submitcleanupid in ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (select submitcleanupid from tbl_setup_submitcleanupitems ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1})", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_submitcriteria ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID1 = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        modGlobal.gv_sql = string.Format("{0} or DDID2 = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_savedadhocreportcriteria ";
                        modGlobal.gv_sql = string.Format("{0} Where SourceDDID1 = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        modGlobal.gv_sql = string.Format("{0} or SourceDDID2 = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        modGlobal.gv_sql = string.Format("{0} or DestDDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "delete tbl_setup_savedadhocreportfields ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "Delete tbl_setup_DataDef ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //
                        modGlobal.gv_sql = "Delete tbl_setup_DataDefActions ";
                        modGlobal.gv_sql = string.Format("{0} Where DDID = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshFieldList();
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

        private void cmdEdit_Click(Object eventSender, EventArgs eventArgs)
        {
            frmTableEditField frmTableEditFieldCopy = new frmTableEditField();
            int bk = 0;


            try
            {

                if (rdcFieldList.Tables[rdcFieldListTable].Rows.Count > 0)
                {
                    for (int itr = 0; itr < rdcFieldList.Tables[rdcFieldListTable].Rows.Count; itr++)
                    {
                        var myRow3 = (DataRow)rdcFieldList.Tables[rdcFieldListTable].Rows[itr];
                        int rowIndex = rdcFieldList.Tables[rdcFieldListTable].Rows.IndexOf(myRow3);
                        bk = rowIndex;
                        frmTableEditFieldCopy.ShowDialog();
                        this.RefreshFieldList();
                        itr = bk;
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

        private void cmdMoveDown_Click(Object eventSender, EventArgs eventArgs)
        {
            var i = 0;
            int ThisFieldID = 0;
            int CurrOrderNum = 0;
            int FCount = 0;


            try
            {

                if (rdcFieldList.Tables[rdcFieldListTable].Rows.Count < 0)
                {
                    return;
                }

                //retrieve the list of  fields for the selected Section
                modGlobal.gv_sql = "Select  ddid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                //first we make sure every field in this list has a number
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_DataDef ";
                    modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, myRow3.Field<int>("DDID"));
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (Convert.ToInt32(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]) == myRow3.Field<int>("DDID"))
                    {
                        CurrOrderNum = FCount;
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                ThisFieldID = Convert.ToInt32(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                if (CurrOrderNum + 1 > 0)
                {
                    //update order number of the field after to this one
                    modGlobal.gv_sql = "Update tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " and SortOrder = " + CurrOrderNum + 1;

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_datadef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set sortOrder = " + CurrOrderNum + 1;
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, ThisFieldID);

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshFieldList();

                    //find the right field
                    for (i = 1; i <= rdcFieldList.Tables[rdcFieldListTable].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]) == ThisFieldID)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        //LDW rdcFieldList.Resultset.MoveNext();
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

        private void cmdMoveUp_Click(Object eventSender, EventArgs eventArgs)
        {
            var i = 0;
            int ThisFieldID = 0;
            int CurrOrderNum = 0;
            int FCount = 0;


            try
            {

                if (rdcFieldList.Tables[rdcFieldListTable].Rows.Count < 0)
                {
                    return;
                }

                //retrieve the list of  fields for the selected Section
                modGlobal.gv_sql = "Select  ddid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //first we make sure every field in this list has a number
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_DataDef ";
                    modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, myRow4.Field<int>("DDID"));
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (Convert.ToInt32(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]) == myRow4.Field<int>("DDID"))
                    {
                        CurrOrderNum = FCount;
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                ThisFieldID = Convert.ToInt32(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                if (CurrOrderNum - 1 > 0)
                {
                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "Update tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and SortOrder = {1}", modGlobal.gv_sql, CurrOrderNum - 1);

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_datadef ";
                    modGlobal.gv_sql = string.Format("{0} set sortOrder = {1}", modGlobal.gv_sql, CurrOrderNum - 1);
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and DDID = {1}", modGlobal.gv_sql, ThisFieldID);

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshFieldList();

                    //find the right field
                    for (i = 1; i <= rdcFieldList.Tables[rdcFieldListTable].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]) == ThisFieldID)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        //LDW rdcFieldList.Resultset.MoveNext();
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

        private void cmdUpdateDEA_Click(Object eventSender, EventArgs eventArgs)
        {
            frmTableActionSetup frmTableActionSetupCopy = new frmTableActionSetup();


            try
            {

                if (rdcFieldList.Tables[rdcFieldListTable].Rows.Count == 0)
                {
                    return;
                }
                frmTableActionSetupCopy.ShowDialog();
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

        private void frmTableSetup_Load(object sender, EventArgs e)
        {
            /*LDW this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));*/
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
                RefreshDataTableList();
                RefreshFieldList();
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

        public void RefreshFieldList()
        {
            string ls_FieldList = "[DDID] ,[BaseTableID], [FieldName],convert(varchar(255), [Help]) as Help,[FieldType],[LookupTableID] ,[FieldSize] ,[FieldOrderold]  ,[OldFieldName] ,[Required]" +
                " ,[Required_EffDate] ,[FieldCategory] ,[State] ,[RecordStatus],[SortOrder],[DateFieldDDID],[CMSFieldCode],[JCFieldCode],[Inactive],[ParentDDID],[AllowUTD],[IsPhysician]";
            try
            {
                if (cboTableList.SelectedIndex > -1)
                {
                    //clean up possible lookup table definition for fields that are date type
                    modGlobal.gv_sql = " update tbl_setup_datadef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set lookuptableid = null";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " and upper(fieldtype) = 'DATE'";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //retrieve the list of table fields
                    modGlobal.gv_sql = string.Format("Select {0}, Category = ", ls_FieldList);
                    modGlobal.gv_sql = modGlobal.gv_sql + " case when FieldCategory = 'Fix' then";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  'Fix' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " else 'Dyn' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  end, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " AI = case when InActive is Null then";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  'A' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " else 'I' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  end ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableList, cboTableList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (ParentDDID IS NULL OR ParentDDID = DDID) ";

                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                    }
                    //
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }
                    //
                    if (cboTableList.Text == "HOSPITAL DEMOGRAPHICS")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by SORTorder ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldCategory desc, FieldName asc ";
                    }
                }
                else
                {
                    modGlobal.gv_sql = string.Format("Select {0}, Category = ", ls_FieldList);
                    modGlobal.gv_sql = modGlobal.gv_sql + " case when FieldCategory = 'Fix' then";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  'Fix' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " else 'Dyn' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  end ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = 0 ";
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
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
                    if (cboTableList.Text == "HOSPITAL DEMOGRAPHICS")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by SORTorder ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldCategory desc , FieldName asc";
                    }
                }

                //LDW rdcFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //clear current entries
                rdcFieldList.Reset();
                //Load new entries
                rdcFieldListTable = "tbl_setup_datadef";
                rdcFieldList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcFieldListTable, rdcFieldList);
                //refresh radgridview with new entries
                dbgFieldList.Refresh();

                if (cboTableList.Text == "HOSPITAL DEMOGRAPHICS")
                {
                    cmdMoveUp.Visible = true;
                    cmdMoveDown.Visible = true;
                }
                else
                {
                    cmdMoveUp.Visible = false;
                    cmdMoveDown.Visible = false;
                }

                //End If
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
        }
    }
}
