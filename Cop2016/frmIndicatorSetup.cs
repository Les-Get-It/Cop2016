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
    public partial class frmIndicatorSetup : Telerik.WinControls.UI.RadForm
    {

        public frmIndicatorSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void RefreshIndicatorDep()
        {
            string IndDesc = null;
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {

                modGlobal.gv_sql = "Select tbl_setup_Indicator.Description, tbl_setup_IndicatorDep.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator, tbl_setup_IndicatorDep ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_Indicator.IndicatorID = tbl_setup_IndicatorDep.IndicatorID ";
                if (lstIndicators.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_IndicatorDep.IndicatorParentID = " +
                        Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_IndicatorDep.IndicatorParentID = -1 ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lstRequiredIndicator.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    if (Information.IsDBNull(myRow1.Field<string>("EffDate")))
                    {
                        IndDesc = myRow1.Field<string>("Description");
                    }
                    else
                    {
                        IndDesc = string.Format("{0} (Eff. as of: {1})", myRow1.Field<string>("Description"), myRow1.Field<string>("EffDate"));
                    }
                    lstRequiredIndicator.Items.Add(new ListBoxItem(IndDesc, myRow1.Field<int>("IndicatorDepID")).ToString());
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

        public void RefreshIndicatorSet()
        {
            string setDesc = null;
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {

                modGlobal.gv_sql = "Select * from tbl_setup_IndicatorSet ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by IndicatorsetDesc ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboIndicatorSet.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    if (Information.IsDBNull(myRow2.Field<string>("EffDate")))
                    {
                        setDesc = myRow2.Field<string>("IndicatorSetDesc");
                    }
                    else
                    {
                        setDesc = string.Format("{0} ({1})", myRow2.Field<string>("IndicatorSetDesc"), myRow2.Field<string>("EffDate"));
                    }
                    cboIndicatorSet.Items.Add(new ListBoxItem(setDesc, myRow2.Field<int>("IndicatorSetID")).ToString());
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

        public void RefreshIndicator()
        {
            string JCAHOID = null;
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {
                //retrieve the list of Indicators
                modGlobal.gv_sql = "Select * from tbl_setup_Indicator ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                lstIndicators.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    JCAHOID = "";
                    if (!Information.IsDBNull(myRow3.Field<int>("JCAHOID")))
                    {
                        JCAHOID = myRow3.Field<int>("JCAHOID") + " - ";
                    }
                    if (Information.IsDBNull(myRow3.Field<string>("lastupdatedate")))
                    {
                        lstIndicators.Items.Add(JCAHOID + myRow3.Field<string>("Description"));
                    }
                    else
                    {
                        lstIndicators.Items.Add(string.Format("{0}{1} ({2})", JCAHOID, myRow3.Field<string>("Description"), myRow3.Field<string>("lastupdatedate")));
                    }

                    Support.SetItemData(lstIndicators, lstIndicators.Items.Count - 1, myRow3.Field<int>("IndicatorID"));
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

        private void cboIndicatorSet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshIndicatorSetField();
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

        private void cmdAddDepIndicator_Click(object sender, EventArgs e)
        {
            frmIndicatorAddDep frmIndicatorAddDepCopy = new frmIndicatorAddDep();
            frmIndicatorAddDepCopy.ShowDialog();
        }

        private void cmdAddIndicatorToSet_Click(object sender, EventArgs e)
        {
            frmIndicatorAddToSet frmIndicatorAddToSetCopy = new frmIndicatorAddToSet();
            frmIndicatorAddToSetCopy.ShowDialog();
        }

        private void cmdAddSet_Click(object sender, EventArgs e)
        {
            var i = 0;
            string NewSet = null;


            try
            {
                int NewIndSID = modDBSetup.FindMaxRecID("tbl_Setup_IndicatorSet", "IndicatorSetID");


                NewSet = RadInputBox.Show("Please enter the description of the new Indicator Set:", "Add New Set", "");

                if (string.IsNullOrEmpty(NewSet))
                {
                    return;
                }

                modGlobal.gv_sql = "Insert into  tbl_setup_IndicatorSet (IndicatorSetID, IndicatorSetDesc, State, RecordStatus) ";
                modGlobal.gv_sql = string.Format("{0} Values ({1},'{2}',", modGlobal.gv_sql, NewIndSID, NewSet);
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

                RefreshIndicatorSet();
                cboIndicatorSet.Text = NewSet;

                //set the selected list item to the new one
                for (i = 0; i <= cboIndicatorSet.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(cboIndicatorSet, i) == NewIndSID)
                    {
                        cboIndicatorSet.SelectedIndex = i;
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

        private void cmdChangeStatus_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            string MoveToModule = null;

            try
            {


                if (lstIndicators.SelectedIndex < 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this indicator to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }


                modGlobal.gv_sql = "Update tbl_Setup_Indicator ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where IndicatorID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicator();
                RefreshIndicatorSet();
                RefreshIndicatorDep();
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

        private void cmdChangeStatusForset_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            string MoveToModule = null;

            try
            {

                if (cboIndicatorSet.SelectedIndex < 0)
                {
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this indicator set to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_Indicatorset ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where IndicatorsetID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicatorSet();
                RefreshIndicatorSetField();
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

        private void cmdDeleteIndicator_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstIndicators.SelectedIndex < -1)
                {
                    return;
                }

                modGlobal.gv_sql = "delete tbl_setup_datareq ";
                modGlobal.gv_sql = string.Format("{0} where indicatorid = {1}", modGlobal.gv_sql, Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "delete tbl_setup_indicator ";
                modGlobal.gv_sql = string.Format("{0} where indicatorid = {1}", modGlobal.gv_sql, Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicator();
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

        private void cmdDeleteSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIndicatorSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_Setup_IndicatorSetField ";
                modGlobal.gv_sql = string.Format("{0}  where IndicatorSetID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_IndicatorSet ";
                modGlobal.gv_sql = string.Format("{0}  where IndicatorsetID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex));

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicatorSet();
                cboIndicatorSet.SelectedIndex = -1;
                RefreshIndicatorSetField();
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

        private void cmdEditIndicator_Click(object sender, EventArgs e)
        {
            frmIndicatorEdit frmIndicatorEditCopy = new frmIndicatorEdit();
            string lstindicator = null;
            string EditIndicator = null;

            try
            {

                if (string.IsNullOrEmpty(lstIndicators.Text))
                {
                    RadMessageBox.Show("Please select an indicator from the list.");
                    return;
                }

                modGlobal.gv_Action = "None";
                frmIndicatorEditCopy.ShowDialog();
                if (modGlobal.gv_Action == "Update")
                {
                    RefreshIndicator();
                    lstindicator = EditIndicator;
                }

                //EditIndicator = InputBox("Edit the indicator description.", "Edit Indicator", lstIndicators)
                //If EditIndicator <> "" Then
                //    gv_sql = "Update tbl_Setup_Indicator set Description = '" & EditIndicator & "'"
                //    gv_sql = gv_sql & " where IndicatorID = " & lstIndicators.ItemData(lstIndicators.ListIndex)
                //    gv_cn.Execute gv_sql
                //    RefreshIndicator
                //    lstindicator = EditIndicator
                //End If
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

        private void cmdEditSet_Click(object sender, EventArgs e)
        {
            var i = 0;
            string EditSet = null;
            int ThisSID;

            try
            {


                if (string.IsNullOrEmpty(cboIndicatorSet.Text))
                {
                    RadMessageBox.Show("Please select a set from the list.");
                    return;
                }

                ThisSID = Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex);
                EditSet = RadInputBox.Show("Edit the Set Description.", "Edit Set", cboIndicatorSet.Text);
                if (!string.IsNullOrEmpty(EditSet))
                {
                    modGlobal.gv_sql = string.Format("Update tbl_Setup_IndicatorSet set IndicatorSetDesc = '{0}'", EditSet);
                    modGlobal.gv_sql = string.Format("{0} where IndicatorSetID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshIndicatorSet();
                    cboIndicatorSet.Text = EditSet;
                    //set the selected list item to the new one
                    for (i = 0; i <= cboIndicatorSet.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(cboIndicatorSet, i) == ThisSID)
                        {
                            cboIndicatorSet.SelectedIndex = i;
                            break; // TODO: might not be correct. Was : Exit For
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

        private void cmdEffDate_Click(object sender, EventArgs e)
        {
            string EditEffDate = null;

            try
            {

                if (lstRequiredIndicator.SelectedIndex < 0)
                {
                    return;
                }

                EditEffDate = RadInputBox.Show("Please type the EFFECTIVE DATE for this requirement.", "Edit Effective Date",
                    Support.Format(DateAndTime.Now, "mm/dd/yyyy"));
                if (!string.IsNullOrEmpty(EditEffDate))
                {
                    if (!Information.IsDate(EditEffDate))
                    {
                        RadMessageBox.Show("Invalid Date Format.");
                        return;
                    }
                    modGlobal.gv_sql = string.Format("Update tbl_Setup_IndicatorDep set EffDate = '{0}'", EditEffDate);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorDepID = " + Support.GetItemData(lstRequiredIndicator,
                        lstRequiredIndicator.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshIndicatorDep();
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

        private void cmdNewIndicator_Click(object sender, EventArgs e)
        {
            int NewIndID = modDBSetup.FindMaxRecID("tbl_Setup_Indicator", "IndicatorID");
            string NewIndicator = null;

            try
            {

                NewIndicator = RadInputBox.Show("Please enter the description of the new indicator:", "Add New Indicator", "");
                if (string.IsNullOrEmpty(NewIndicator))
                {
                    return;
                }

                modGlobal.gv_sql = "Insert into tbl_setup_Indicator (IndicatorID, Description, State, RecordStatus) ";
                modGlobal.gv_sql = string.Format("{0} Values ({1},'{2}',", modGlobal.gv_sql, NewIndID, NewIndicator);
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
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicator();

                lstIndicators.Text = NewIndicator;
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

        private void cmdRemoveDepIndicator_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRequiredIndicator.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_Setup_IndicatorDep ";
                modGlobal.gv_sql = string.Format("{0} where IndicatorDepID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstRequiredIndicator, lstRequiredIndicator.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicatorDep();
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

        private void cmdRemoveEffDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRequiredIndicator.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_IndicatorDep set EffDate =  null ";
                modGlobal.gv_sql = string.Format("{0} where IndicatorDepID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstRequiredIndicator, lstRequiredIndicator.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                RefreshIndicatorDep();
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

        private void cmdRemoveIndicatorFromSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstIndicatorSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_setup_IndicatorSetField ";
                modGlobal.gv_sql = string.Format("{0} Where IndlinkID =  {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstIndicatorSet, lstIndicatorSet.SelectedIndex));

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicatorSetField();
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

        public void RefreshIndicatorSetField()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {

                modGlobal.gv_sql = "Select tbl_setup_indicator.Description, tbl_setup_indicatorSetField.*  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_indicator, tbl_setup_indicatorSetField ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_indicator.IndicatorID = tbl_setup_indicatorSetField.IndicatorID ";
                if (cboIndicatorSet.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_indicatorSetField.IndicatorSetID  = 0 ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_indicatorSetField.IndicatorSetID  = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboIndicatorSet, cboIndicatorSet.SelectedIndex));
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                lstIndicatorSet.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    lstIndicatorSet.Items.Add(new ListBoxItem(myRow9.Field<string>("Description"), myRow9.Field<int>("IndLinkID")).ToString());
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

        private void frmIndicatorSetup_Load(object sender, EventArgs e)
        {
            //LDW sstabIndicatorList.TabIndex = 0;
            sstabIndicatorList.ActiveWindow = sstabIndicatorListIndicators;
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

                if (modGlobal.gv_status == "TEST")
                {
                    cmdChangeStatusForset.Text = "Move to Active";
                }
                else
                {
                    cmdChangeStatusForset.Text = "Move to Test";
                }


                RefreshIndicator();
                RefreshIndicatorSet();
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

        private void lstIndicators_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshIndicatorDep();
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
