using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmTableActionSetup : Telerik.WinControls.UI.RadForm
    {
        public string rdcFieldListTable = "tbl_setup_datadef";



        public frmTableActionSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAddAction_Click(object sender, EventArgs e)
        {
            int NextID = modDBSetup.FindMaxRecID("tbl_setup_datadefactions", "datadefactionid");


            try
            { 
            if (lstAvailableActions.SelectedIndex < 0)
            {
                return;
            }

                modGlobal.gv_sql = "insert into tbl_setup_datadefactions (datadefactionid, dataentryactionid, ddid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values ( ";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NextID);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstAvailableActions, lstAvailableActions.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + frmTableSetup.rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"];
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshAvailableActions();
                RefreshAppliedActions();
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

        private void cmdRemoveAction_Click(object sender, EventArgs e)
        {
            try
            { 
            if (lstAppliedActions.SelectedIndex < 0)
            {
                return;
            }

                modGlobal.gv_sql = "Delete tbl_setup_datadefactions  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where datadefactionid = ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstAppliedActions, lstAppliedActions.SelectedIndex);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshAvailableActions();
                RefreshAppliedActions();
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

        private void frmTableActionSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {

                RefreshAvailableActions();
                RefreshAppliedActions();
                lblFieldName.Text = frmTableSetup.rdcFieldList.Tables[rdcFieldListTable].Rows[0]["FieldName"].ToString();
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

        public void RefreshAvailableActions()
        {

            try
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_Dataentryactions ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where dataentryactionid not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select dataentryactionid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Datadefactions  ";
                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, frmTableSetup.rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_Dataentryactions";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lstAvailableActions.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    lstAvailableActions.Items.Add(new ListBoxItem(myRow1.Field<string>("ActionDesc"), myRow1.Field<int>("Dataentryactionid")).ToString());
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

        public void RefreshAppliedActions()
        {
            try
            {
                modGlobal.gv_sql = "Select dda.*, dea.actiondesc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Datadefactions as dda  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Dataentryactions as dea  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dea.Dataentryactionid = dda.Dataentryactionid  ";
                modGlobal.gv_sql = string.Format("{0} where dda.ddid = {1}", modGlobal.gv_sql, frmTableSetup.rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_Datadefactions";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                lstAppliedActions.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    lstAppliedActions.Items.Add(new ListBoxItem(myRow2.Field<string>("ActionDesc"), myRow2.Field<int>("Datadefactionid")).ToString());
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
    }
}
