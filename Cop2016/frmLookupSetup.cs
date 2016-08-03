using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmLookupSetup : Telerik.WinControls.UI.RadForm
    {
        public DataSet rdcLookupList = new DataSet();
        public string rdcLookupListTable = null;
        public DataSet rdcLookupTableList = new DataSet();
        public string rdcLookupTableListTable = null;


        public frmLookupSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboLookupTableList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshLookupList();
                if (cboLookupTableList.SelectedIndex > -1)
                {
                    fraLk.Enabled = true;
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

        private void cmdAddLookupTable_Click(object sender, EventArgs e)
        {
            var i = 0;
            int NewlkupID = modDBSetup.FindMaxRecID("tbl_Setup_TableDef", "BaseTableID");
            string Newlkup = null;

            try
            {
                Newlkup = RadInputBox.Show("Please enter the name of the new lookup table:", "Add New Lookup Table", "");
                if (string.IsNullOrEmpty(Newlkup))
                {
                    return;
                }

                modGlobal.gv_sql = "Insert into tbl_setup_TableDef (BaseTableID, BaseTable, TableType) ";
                modGlobal.gv_sql = string.Format("{0} Values ({1},'{2}','LOOKUP'", modGlobal.gv_sql, NewlkupID, Newlkup);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshLookupTableList();
                cboLookupTableList.Text = Newlkup;

                //set the selected list item to the new one
                for (i = 0; i <= cboLookupTableList.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(cboLookupTableList, i) == NewlkupID)
                    {
                        cboLookupTableList.SelectedIndex = i;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                fraLk.Enabled = true;
                optID.IsChecked = true;
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

        private void cmdAddLookupValue_Click(object sender, EventArgs e)
        {
            int Nextsortorder;
            int NextNewID = modDBSetup.FindMaxRecID("tbl_setup_miscLookupList", "LookupID");

            try
            {
                if (cboLookupTableList.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a lookup table first.");
                    return;
                }

                if ((string.IsNullOrEmpty(txtID.Text) | string.IsNullOrEmpty(txtLookupValue.Text)) & optID.IsChecked == true)
                {
                    RadMessageBox.Show("Please enter both the ID and the lookup value.");
                    return;
                }

                Nextsortorder = modDBSetup.FindMaxRecID("tbl_setup_miscLookupList", "sortorder");

                modGlobal.gv_sql = "insert into tbl_setup_miscLookupList ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (LookupID, BaseTableID, ID, FieldValue, sortorder)";
                modGlobal.gv_sql = string.Format("{0} values ({1},{2},", modGlobal.gv_sql, NextNewID,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                if (optID.IsChecked == true | (!string.IsNullOrEmpty(txtID.Text) & !Information.IsDBNull(txtID.Text)))
                {
                    modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, txtID.Text);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                }
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, txtLookupValue.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Nextsortorder;
                modGlobal.gv_sql = modGlobal.gv_sql + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshLookupList();
                txtID.Text = "";
                txtLookupValue.Text = "";
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
            DialogResult resp;

            try
            {
                if (cboLookupTableList.SelectedIndex < 0)
                {
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where lookuptableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined for a field");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any cleanupitem
                modGlobal.gv_sql = "Select * from tbl_setup_submitcleanupcrit ";
                modGlobal.gv_sql = string.Format("{0} where lookuptableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_submitcleanupcrit";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName11].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in the Summarization process (Cleanup item).");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field in the import layout
                modGlobal.gv_sql = "Select * from tbl_setup_importvalidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where lookuptableid = " +
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_setup_importvalidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName12].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in the Import process (Validation).");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field in the adhocreport
                modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Basetableid = " +
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_savedadhocreportcriteria )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_misclookuplist";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in an Adhoc Report Criteria.");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field in the table validation
                modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                modGlobal.gv_sql = string.Format("{0} where Basetableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_TableValidation )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_setup_misclookuplist";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName14].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a table validation.");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field in the submission criteria
                modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                modGlobal.gv_sql = string.Format("{0} where Basetableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_SubmitCriteria )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName15 = "tbl_setup_misclookuplist";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName15].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a submission criteria.");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field in the record cleanup criteria for submission
                modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                modGlobal.gv_sql = string.Format("{0} where Basetableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and LookupID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select lookupid from tbl_setup_SubmitCleanupRecord )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName16 = "tbl_setup_misclookuplist";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName16].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a submission criteria (record cleanup).");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field in the Report criteria
                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = string.Format("{0} where lookuptableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "tbl_setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName17].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a Report criteria.");
                    return;
                }

                //make sure this table will not be deleted if it has been used for any field in the submission criteria
                modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = string.Format("{0} where lookuptableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName18 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName18].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Table. This lookup table has been defined in a submission criteria.");
                    return;
                }

                //make sure the tables imported from the old system, will not be deleted
                modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName19 = "tbl_setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                if (((!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["OldTableName"])) & !string.IsNullOrEmpty
                    (modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["OldTableName"].ToString())) | modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["SystemSetup"].ToString() == "Y")
                {
                    RadMessageBox.Show("Cannot Delete This Table. The table definition is required in this system.");
                    return;
                }

                resp = RadMessageBox.Show("Are you sure you want to delete this lookup table?", "Delete Lookup Table", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "update tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set LookupTableID = null ";
                modGlobal.gv_sql = string.Format("{0} where LookupTableID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_TableDef ";
                modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshLookupTableList();
                RefreshLookupList();
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

        private void cmdDelLookup_Click(object sender, EventArgs e)
        {
            int FCount = 0;
            string gv_Command = null;
            DialogResult resp;

            try
            {
                if (rdcLookupList.Tables[rdcLookupListTable].Rows.Count == 0)
                {
                    return;
                }

                //make sure this value will not be deleted if it has been used for any related table

                modGlobal.gv_sql = "Select * from tbl_setup_TableValidation ";
                modGlobal.gv_sql = string.Format("{0} where lookupID = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_TableValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName20].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Table Validation Process");
                    return;
                }

                modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = string.Format("{0} where lookupID = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName21 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName21].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Summarization Process");
                    return;
                }

                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = string.Format("{0} where lookupID = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName22].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Adhoc Reports Criteria");
                    return;
                }

                modGlobal.gv_sql = "Select * from tbl_setup_submitcleanuprecord ";
                modGlobal.gv_sql = string.Format("{0} where lookupID = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName23 = "tbl_setup_submitcleanuprecord";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName23].Rows.Count > 0)
                {
                    RadMessageBox.Show("Cannot Delete This Value. This lookup value has been selected in the Summarization process (Record Cleanup Criteria)");
                    return;
                }

                resp = RadMessageBox.Show("Are you sure you want to delete this lookup value?", "Delete Lookup Value", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }


                gv_Command = "Delete tbl_Setup_miscLookupList ";
                gv_Command = string.Format("{0} where lookupID = {1}", gv_Command, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //retrieve the list of  fields for the selected lookup to reorganize the list
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by SortOrder ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName24 = "tbl_setup_misclookuplist";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                //first we make sure every field in this list has a number
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow24 in modGlobal.gv_rs.Tables[sqlTableName24].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = string.Format("{0} where lookupid = {1}", modGlobal.gv_sql, myRow24.Field<int>("LookupID"));
                    modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                RefreshLookupList();
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            int thisindex;
            string resp;


            //If rdcFieldList.Resultset.RowCount > 0 Then
            //    frmTableEditField.Show 1
            //End If

            try
            {
                if (cboLookupTableList.SelectedIndex < 0)
                {
                    return;
                }

                //make sure the tables imported from the old system, will not be deleted
                modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}",
                    modGlobal.gv_sql, Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName25 = "tbl_setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);
                if (((!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["OldTableName"])) & !string.IsNullOrEmpty(
                    modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["OldTableName"].ToString())) | modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["SystemSetup"].ToString() == "Y")
                {
                    RadMessageBox.Show("Cannot Edit This Table. This lookup table is defined as a system lookup, and the table name has been used in the Member database internally.");
                    return;
                }

                resp = RadInputBox.Show("Type in the new title:", "Edit Lookup Title", cboLookupTableList.Text);

                if (string.IsNullOrEmpty(resp))
                {
                    return;
                }

                thisindex = cboLookupTableList.SelectedIndex;

                modGlobal.gv_sql = "update tbl_setup_TableDef ";
                modGlobal.gv_sql = string.Format("{0} set BaseTable = '{1}'", modGlobal.gv_sql, resp);
                modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " +
                    Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshLookupTableList();

                cboLookupTableList.SelectedIndex = thisindex;
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

        private void cmdEditLookup_Click(object sender, EventArgs e)
        {
            frmTableEditLookup frmTableEditLookupCopy = new frmTableEditLookup();


            try
            {
                if (rdcLookupList.Tables[rdcLookupListTable].Rows.Count == 0)
                {
                    return;
                }

                frmTableEditLookupCopy.ShowDialog();
                RefreshLookupList();
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

        private void cmdImport_Click(object sender, EventArgs e)
        {
            dlgImportLookupValues dlgImportLookupValuesCopy = new dlgImportLookupValues();

            try
            {

                if (cboLookupTableList.SelectedIndex >= 0)
                {
                    if (RadMessageBox.Show(string.Format("Are you sure you want to import the values into the table {0}?",
                        Support.GetItemString(cboLookupTableList, cboLookupTableList.SelectedIndex)),
                        "Verify Lookup Table", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                    {
                        dlgImportLookupValuesCopy.SetBaseTableID(Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                        dlgImportLookupValuesCopy.ShowDialog();
                        RefreshLookupList();
                        this.Refresh();
                        Application.DoEvents();
                    }
                }
                else
                {
                    RadMessageBox.Show("Please choose a lookup table to import values into.", "No Lookup Table Selected", MessageBoxButtons.OK, RadMessageIcon.Info);
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
            var i = 0;
            int TotalRec;
            int thisValue;
            int CurrentSortOrder;
            int FCount;

            try
            {
                if (rdcLookupList.Tables[rdcLookupListTable].Rows.Count > 0)
                {
                    //retrieve the list of  fields for the selected Section
                    modGlobal.gv_sql = "Select * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by SortOrder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName26 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, modGlobal.gv_rs);

                    //first we make sure every field in this list has a number
                    FCount = 0;
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow26 in modGlobal.gv_rs.Tables[sqlTableName26].Rows)
                    {
                        FCount = FCount + 1;
                        modGlobal.gv_sql = "Update tbl_setup_misclookuplist ";
                        modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, FCount);
                        modGlobal.gv_sql = string.Format("{0} where lookupid = {1}", modGlobal.gv_sql, myRow26.Field<int>("LookupID"));
                        modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                            Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    modGlobal.gv_sql = "Select SortOrder from tbl_Setup_MiscLookupList ";
                    modGlobal.gv_sql = string.Format("{0} where LookupID = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                    modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName27 = "tbl_Setup_MiscLookupList";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["SortOrder"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["SortOrder"]) > 1)
                        {
                            CurrentSortOrder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["SortOrder"]);
                            //update the field that is one order higher than this one
                            modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
                            modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, CurrentSortOrder);
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SortOrder = " + CurrentSortOrder + 1;
                            modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                                Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " set SortOrder = " + CurrentSortOrder + 1;
                            modGlobal.gv_sql = string.Format("{0} where lookupid = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                            modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                                Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            thisValue = Convert.ToInt32(rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                            RefreshLookupList();

                            //LDW rdcLookupList.Resultset.MoveLast();
                            TotalRec = rdcLookupList.Tables[rdcLookupListTable].Rows.Count;
                            //LDW rdcLookupList.Resultset.MoveFirst();

                            for (i = 1; i <= TotalRec - 1; i++)
                            {
                                if (thisValue == Convert.ToInt32(rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]))
                                {
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                //LDW rdcLookupList.Resultset.MoveNext();
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
            var i = 0;
            int TotalRec;
            int thisValue;
            int CurrentSortOrder;
            int FCount;

            try
            {

                if (rdcLookupList.Tables[rdcLookupListTable].Rows.Count > 0)
                {
                    //retrieve the list of  fields for the selected Section
                    modGlobal.gv_sql = "Select * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by SortOrder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName28 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);

                    //first we make sure every field in this list has a number
                    FCount = 0;
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow28 in modGlobal.gv_rs.Tables[sqlTableName28].Rows)
                    {
                        FCount = FCount + 1;
                        modGlobal.gv_sql = "Update tbl_setup_misclookuplist ";
                        modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, FCount);
                        modGlobal.gv_sql = string.Format("{0} where lookupid = {1}", modGlobal.gv_sql, myRow28.Field<int>("LookupID"));
                        modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                            Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW modGlobal.gv_rs.MoveNext();
                    }


                    modGlobal.gv_sql = "Select SortOrder from tbl_Setup_MiscLookupList ";
                    modGlobal.gv_sql = string.Format("{0} where LookupID = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                    modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName29 = "tbl_Setup_MiscLookupList";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, modGlobal.gv_rs);
                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName29].Rows[0]["SortOrder"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName29].Rows[0]["SortOrder"]) > 1)
                        {
                            CurrentSortOrder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName29].Rows[0]["SortOrder"]);
                            //update the field that is one order higher than this one
                            modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
                            modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, CurrentSortOrder);
                            modGlobal.gv_sql = string.Format("{0} where SortOrder = {1}", modGlobal.gv_sql, CurrentSortOrder - 1);
                            modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                                Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_MiscLookupList ";
                            modGlobal.gv_sql = string.Format("{0} set SortOrder = {1}", modGlobal.gv_sql, CurrentSortOrder - 1);
                            modGlobal.gv_sql = string.Format("{0} where lookupid = {1}", modGlobal.gv_sql, rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                            modGlobal.gv_sql = string.Format("{0} and BaseTableID = {1}", modGlobal.gv_sql,
                                Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            thisValue = Convert.ToInt32(rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]);
                            RefreshLookupList();

                            //LDW rdcLookupList.Resultset.MoveLast();
                            TotalRec = Convert.ToInt32(rdcLookupList.Tables[rdcLookupListTable].Rows.Count);
                            //LDW rdcLookupList.Resultset.MoveFirst();

                            for (i = 1; i <= TotalRec - 1; i++)
                            {
                                if (thisValue == Convert.ToInt32(rdcLookupList.Tables[rdcLookupListTable].Rows[0]["LookupID"]))
                                {
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                //LDW rdcLookupList.Resultset.MoveNext();
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

        private void frmLookupSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshLookupTableList();
                RefreshLookupList();
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

        public void RefreshLookupTableList()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {
                //retrieve the list of batch types
                modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where TableType = 'LOOKUP' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '{1}' or State is null)", modGlobal.gv_sql, modGlobal.gv_State);
                }
                //If gv_status = "" Then
                //    gv_sql = gv_sql & " and (RecordStatus = '' or RecordStatus is null) "
                //Else
                //    gv_sql = gv_sql & " and RecordStatus = '" & gv_status & "'"
                //End If

                modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

                rdcLookupTableList.AcceptChanges();
                //LDW rdcLookupTableList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcLookupTableListTable = "tbl_setup_TableDef";
                rdcLookupTableList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcLookupTableListTable, modGlobal.gv_rs);
                rdcLookupTableList.AcceptChanges();

                cboLookupTableList.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!rdcLookupTableList.Resultset.EOF)
                foreach (DataRow myRowR in rdcLookupTableList.Tables[rdcLookupTableListTable].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    cboLookupTableList.Items.Add(new ListBoxItem(myRowR.Field<string>("BaseTable"), myRowR.Field<int>("basetableid")).ToString());
                    //LDW rdcLookupTableList.Resultset.MoveNext();
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

        public void RefreshLookupList()
        {
            try
            {
                if (cboLookupTableList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName29 = "tbl_setup_TableDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, modGlobal.gv_rs);

                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName29].Rows[0]["CompareToDesc"]))
                    {
                        optID.IsChecked = true;
                    }
                    else
                    {
                        OptLKValue.IsChecked = true;
                    }

                    //retrieve the list of Lookup table values
                    modGlobal.gv_sql = "Select * from tbl_setup_miscLookupList ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder, FieldValue ";
                }
                else
                {
                    //retrieve the list of Lookup table values
                    modGlobal.gv_sql = "Select * from tbl_setup_miscLookupList ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = 0 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder, FieldValue ";
                }

                //LDW rdcLookupList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcLookupListTable = "tbl_setup_miscLookupList";
                rdcLookupList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcLookupListTable, modGlobal.gv_rs);
                rdcLookupList.AcceptChanges();
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
            //dbgLookupList.Refresh
        }

        private void optID_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(optID.IsChecked))
                {
                    modGlobal.gv_sql = "update tbl_setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CompareToDesc = null ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        private void OptLKValue_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(OptLKValue.IsChecked))
                {
                    modGlobal.gv_sql = "update tbl_setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CompareToDesc = 'Yes' ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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
        private void chkMultipleSel_Click()
		{
			object chkMultipleSel = null;
			object lblMaxSel = null;
			object txtMaxSel = null;
			if (chkMultipleSel.Value == 1) {
				txtMaxSel.Enabled = true;
				lblMaxSel.Enabled = true;
			} else {
				txtMaxSel.Enabled = false;
				lblMaxSel.Enabled = false;
			}
		}

        private void txtMaxSel_Change()
		{
			object txtMaxSel = null;

			modGlobal.gv_sql = "update tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set MaxSelection = " + Convert.ToInt16(txtMaxSel.Text);
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + Support.GetItemData(cboLookupTableList, cboLookupTableList.SelectedIndex);
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
		}
        */
    }
}
