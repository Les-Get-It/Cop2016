using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Telerik.WinControls.UI;
using static COP2001.RadDropBinder;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmHospStatSetup : Telerik.WinControls.UI.RadForm
    {
        int basetableid;
        public DataSet rdcHospStatFields = new DataSet();
        public string rdcHospStatFieldsTable = null;
        public DataSet rdcHospStatValid = new DataSet();
        public string rdcHospStatValidTable = null;
        readonly StaticLocalInitFlag static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init = new StaticLocalInitFlag();
        int static_sstabMainTab_SelectedIndexChanged_PreviousTab;

        public frmHospStatSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void RefreshGroupIndicator()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemslstFieldIndicator = new List<Item>();

            try
            {

                if (lstHospStatGroup.SelectedIndex < 0)
                {
                    lstFieldIndicator.Items.Clear();
                    return;
                }

                modGlobal.gv_sql = "Select  tbl_setup_hospstatgroupIndicator.*, tbl_setup_Indicator.Description as Indicator  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_hospstatgroupIndicator, tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_hospstatgroupIndicator.IndicatorID = tbl_setup_Indicator.IndicatorID ";
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_hospstatgroupIndicator.HospStatGroupID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_hospstatgroupIndicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lstFieldIndicator.Items.Clear();

                Table_ListIndex = -1;

                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemslstFieldIndicator.Add(new Item(myRow1.Field<int>("IndicatorID"), myRow1.Field<string>("Indicator")));

                    //lstFieldIndicator.Items.Add(new ListBoxItem(myRow1.Field<string>("Indicator"), myRow1.Field<int>("IndicatorID")).ToString());
                    //LDW //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstFieldIndicator.DataSource = itemslstFieldIndicator;
                this.lstFieldIndicator.DisplayMember = "Description";
                this.lstFieldIndicator.ValueMember = "Id";
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

        public void RefreshHospStatAllFields()
        {
            RadGridView dbgHospStatFields = new RadGridView();

            try
            {

                //retrieve the list of patient fields for the selected Section
                modGlobal.gv_sql = "Select  hsf.HospStatGroupid, dd.DDID, dd.Fieldname, FieldOrder";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_Setup_DataDef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroupFields as hsf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = hsf.ddid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID =  -1 ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where hsg.IndicatorGroupID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by hsf.FieldOrder, dd.FieldName ";

                //resp = InputBox("", "", gv_sql)
                //LDW rdcHospStatFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcHospStatFieldsTable = "tbl_Setup_DataDef";
                rdcHospStatFields = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcHospStatFieldsTable, rdcHospStatFields);
                rdcHospStatFields.AcceptChanges();
                //resp = InputBox("", "", gv_sql) 'rdcPatientFields.Resultset.RowCount
                dbgHospStatFields.Refresh();
                //RefreshFieldIndicator
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
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemscboIndicatorGroup = new List<Item>();

            try
            {

                //retrieve the list of Indicator Groups

                modGlobal.gv_sql = "Select tbl_setup_IndicatorGroup.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorGroup ";

                modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + basetableid;

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "')";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by displayorder, GroupDescription ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_IndicatorGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboIndicatorGroup.Items.Clear();

                Table_ListIndex = -1;

                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemscboIndicatorGroup.Add(new Item(myRow2.Field<int>("indicatorgroupid"), myRow2.Field<string>("GroupDescription")));

                    //cboIndicatorGroup.Items.Add(new ListBoxItem(myRow2.Field<string>("GroupDescription"), myRow2.Field<int>("indicatorgroupid")).ToString());
                    //LDW //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboIndicatorGroup.DataSource = itemscboIndicatorGroup;
                this.cboIndicatorGroup.DisplayMember = "Description";
                this.cboIndicatorGroup.ValueMember = "Id";

                if (cboIndicatorGroup.Items.Count == 0)
                {
                    sstabGroupDetails.Enabled = false;
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

        private void cboIndicatorGroup_TextChanged(object sender, EventArgs e)
        {
            if (cboIndicatorGroup.SelectedIndex > -1)
            {
                sstabMainTab.Enabled = true;
            }
            else
            {
                sstabMainTab.Enabled = false;
            }
        }

        private void cboIndicatorGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboIndicatorGroup.SelectedIndex > -1)
                {
                    sstabMainTab.Enabled = true;
                }
                else
                {
                    sstabMainTab.Enabled = false;
                }

                RefreshHospStatGroups();
                RefreshHospStatGroupFields();
                RefreshGroupIndicator();
                RefreshHospStatAllFields();
                RefreshHospStatGroupForVal();
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

        private void cmdAddFieldToGroup_Click(object sender, EventArgs e)
        {
            frmHospStatEditGroupField frmHospStatEditGroupFieldCopy = new frmHospStatEditGroupField();

            try
            {

                if (lstHospStatGroup.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Group.");
                    return;
                }

                frmHospStatEditGroupFieldCopy.ShowDialog();
                RefreshHospStatGroupFields();
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

        private void cmdAddValErr_Click(object sender, EventArgs e)
        {
            try
            {
                AddValidation("Error");
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

        private void cmdAddValWarning_Click(object sender, EventArgs e)
        {
            try
            {
                AddValidation("Warning");
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
                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a section.");
                    return;
                }

                MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
                resp = RadMessageBox.Show("Are you sure you want this section to the " + MoveToModule + " Module?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup ";
                modGlobal.gv_sql = string.Format("{0}  Set RecordStatus =  {1}", modGlobal.gv_sql, modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
                modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshBaseTableID();
                RefreshIndicatorSet();
                RefreshHospStatGroups();
                RefreshHospStatAllFields();
                RefreshHospStatGroupFields();
                RefreshGroupIndicator();
                RefreshHospStatGroupForVal();
                RefreshHospStatValidation();
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select HospStatGroupID from tbl_Setup_HospStatGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupIndicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select HospStatGroupID from tbl_Setup_HospStatGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select HospStatGroupID from tbl_Setup_HospStatGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_IndicatorGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                cboIndicatorGroup.SelectedIndex = -1;
                RefreshIndicatorSet();
                RefreshHospStatGroups();
                RefreshHospStatGroupFields();
                RefreshGroupIndicator();
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

        private void cmdDelGroup_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to delete this group?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (lstHospStatGroup.SelectedIndex < 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID = " +
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroupIndicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID = " +
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_HospStatGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where HospStatGroupID = " +
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_HospStatVal ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where HOSPSTATGROUPID1 = " +
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + "  or HOSPSTATGROUPID2 = " +
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshHospStatGroups();
                lstHospStatGroup.SelectedIndex = -1;
                RefreshHospStatGroupFields();
                if (lstHospStatGroup.Items.Count == 0)
                {
                    sstabGroupDetails.Enabled = false;
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            var i = 0;
            string EditSection = null;
            int ThisGID;

            try
            {
                if (string.IsNullOrEmpty(cboIndicatorGroup.Text))
                {
                    RadMessageBox.Show("Please select Section from the list.");
                    return;
                }

                ThisGID = Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                EditSection = RadInputBox.Show("Edit the Section description.", "Edit Section", cboIndicatorGroup.Text);
                if (!string.IsNullOrEmpty(EditSection))
                {
                    modGlobal.gv_sql = string.Format("Update tbl_Setup_IndicatorGroup set GroupDescription = '{0}'", EditSection);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshIndicatorSet();
                    cboIndicatorGroup.Text = EditSection;
                    //set the selected list item to the new one
                    for (i = 0; i <= cboIndicatorGroup.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(cboIndicatorGroup, i) == ThisGID)
                        {
                            cboIndicatorGroup.SelectedIndex = i;
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

        private void cmdEditGroup_Click(object sender, EventArgs e)
        {
            var i = 0;
            string EditGroup = null;
            int ThisGID;

            try
            {
                if (lstHospStatGroup.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Group from the list.");
                    return;
                }

                ThisGID = Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                EditGroup = RadInputBox.Show("Edit the Group description.", "Edit Group", lstHospStatGroup.Text);
                if (!string.IsNullOrEmpty(EditGroup))
                {
                    modGlobal.gv_sql = string.Format("Update tbl_Setup_HospStatGroup set GroupDescription = '{0}'", EditGroup);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where HospStatGroupID = " +
                        Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshHospStatGroups();
                    lstHospStatGroup.Text = EditGroup;
                    //set the selected list item to the new one
                    for (i = 0; i <= lstHospStatGroup.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(lstHospStatGroup, i) == ThisGID)
                        {
                            lstHospStatGroup.SelectedIndex = i;
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

        private void cmdLinkIndicator_Click(object sender, EventArgs e)
        {
            frmHospStatEditIndicator frmHospStatEditIndicatorCopy = new frmHospStatEditIndicator();

            try
            {
                if (lstHospStatGroup.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Group.");
                    return;
                }

                frmHospStatEditIndicatorCopy.ShowDialog();
                RefreshGroupIndicator();
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
            int ThisFieldID ;
            int CurrOrderNum = 0;
            int FCount = 0;
            int TotalFields ;

            try
            {
                if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count < 0)
                {
                    return;
                }

                //retrieve the list of  fields for the selected Section
                modGlobal.gv_sql = "Select  hsf.ddid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by hsf.fieldorder ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_HospStatGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                //LDW modGlobal.gv_rs.MoveLast();
                TotalFields = modGlobal.gv_rs.Tables[sqlTableName3].Rows.Count;
                //LDW modGlobal.gv_rs.MoveFirst();

                //first we make sure every field in this list has a number
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = string.Format("{0} set tbl_setup_HospStatGroupFields.FieldOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_HospStatGroupFields.DDID = {1}", modGlobal.gv_sql, myRow3.Field<int>("DDID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (Convert.ToInt32(rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]) == myRow3.Field<int>("DDID"))
                    {
                        CurrOrderNum = FCount;
                    }
                    //LDW //LDW modGlobal.gv_rs.MoveNext();
                }


                ThisFieldID = Convert.ToInt32(rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]);
                if (CurrOrderNum < TotalFields)
                {
                    //update order number of the field after to this one
                    modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = string.Format("{0} set tbl_setup_HospStatGroupFields.FieldOrder = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and FieldOrder = " + CurrOrderNum + 1;

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_setup_HospStatGroupFields.FieldOrder = " + CurrOrderNum + 1;
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_HospStatGroupFields.DDID = {1}", modGlobal.gv_sql, rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshHospStatAllFields();
                    //find the right field
                    for (i = 1; i <= rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]) == ThisFieldID)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        //LDW rdcHospStatFields.Resultset.MoveNext();
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

        private void cmdMoveSectionDown_Click(object sender, EventArgs e)
        {
            int ThisFieldID;
            int MaxOrderNum = 0;
            int CurrOrderNum = 0;
            int FCount = 0;


            try
            {
                if (string.IsNullOrEmpty(cboIndicatorGroup.Text))
                {
                    RadMessageBox.Show("Please select Section from the list.");
                    return;
                }
                //retrieve the list of patient fields for the selected Section
                modGlobal.gv_sql = "Select  * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
                modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

                //first we make sure every field in this list has a number
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_IndicatorGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup ";
                    modGlobal.gv_sql = string.Format("{0} set DisplayOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql, myRow4.Field<int>("indicatorgroupid"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) == myRow4.Field<int>("indicatorgroupid"))
                    {
                        CurrOrderNum = FCount;
                    }

                    MaxOrderNum = FCount;
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                ThisFieldID = Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);

                DataSet rs2 = new DataSet();
                if (CurrOrderNum < MaxOrderNum)
                {
                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                    modGlobal.gv_sql = string.Format("{0} set DisplayOrder =  {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                    }
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " and DisplayOrder = " + CurrOrderNum + 1;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + CurrOrderNum + 1;
                    modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshIndicatorSet();
                    //find the right field
                    modGlobal.gv_sql = "Select  * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                    }
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";
                    //LDW rs2 = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_Setup_IndicatorGroup";
                    rs2 = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, rs2);
                    FCount = 0;

                    //LDW while (!rs2.EOF)
                    foreach (DataRow myRow5 in rs2.Tables[sqlTableName5].Rows)
                    {
                        FCount = FCount + 1;
                        if (myRow5.Field<int>("indicatorgroupid") == ThisFieldID)
                        {
                            cboIndicatorGroup.SelectedText = myRow5.Field<string>("GroupDescription");
                            cboIndicatorGroup.SelectedIndex = FCount - 1;
                        }
                        //LDW rs2.MoveNext();
                    }
                    rs2.Dispose();
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

        private void cmdMoveSecUp_Click(object sender, EventArgs e)
        {
            int ThisFieldID;
            int CurrOrderNum = 0;
            int FCount = 0;

            try
            {

                if (string.IsNullOrEmpty(cboIndicatorGroup.Text))
                {
                    RadMessageBox.Show("Please select Section from the list.");
                    return;
                }

                //retrieve the list of sections
                modGlobal.gv_sql = "Select  * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

                //first we make sure every field in this list has a number
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_Setup_IndicatorGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup";
                    modGlobal.gv_sql = string.Format("{0} set DisplayOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql, myRow6.Field<int>("indicatorgroupid"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    if (Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex) == myRow6.Field<int>("indicatorgroupid"))
                    {
                        CurrOrderNum = FCount;
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                ThisFieldID = Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                DataSet rs2 = new DataSet();
                if (((CurrOrderNum - 1)) > 0)
                {
                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                    modGlobal.gv_sql = string.Format("{0} set DisplayOrder =  {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                    modGlobal.gv_sql = string.Format("{0} and DisplayOrder = {1}", modGlobal.gv_sql, (CurrOrderNum - 1));
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                    }
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                    modGlobal.gv_sql = string.Format("{0} set DisplayOrder = {1}", modGlobal.gv_sql, (CurrOrderNum - 1));
                    modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshIndicatorSet();
                    //find the right field
                    //find the right field
                    modGlobal.gv_sql = "Select  * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
                    modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and (State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                    }
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";
                    //LDW rs2 = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_Setup_IndicatorGroup";
                    rs2 = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, rs2);
                    FCount = 0;

                    //LDW while (!rs2.EOF)
                    foreach (DataRow myRow7 in rs2.Tables[sqlTableName7].Rows)
                    {
                        FCount = FCount + 1;
                        if (myRow7.Field<int>("indicatorgroupid") == ThisFieldID)
                        {
                            cboIndicatorGroup.SelectedText = myRow7.Field<string>("GroupDescription");
                            cboIndicatorGroup.SelectedIndex = FCount - 1;
                        }
                        //LDW rs2.MoveNext();
                    }
                    rs2.Dispose();
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

        private void cmdMoveToAbsPosition_Click(object sender, EventArgs e)
        {
            int abspos = 0;
            var i = 0;
            int NewPos;
            int ThisFieldOrder;
            int TotalFields;
            int StartOrder;

            try
            {

                if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count < 0)
                {
                    return;
                }

                //first we make sure that every field has an order number
                modGlobal.gv_sql = "update tbl_setup_HospStatGroupFields   ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set fieldorder = 1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where fieldorder is null  ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Select hsf.*  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by fieldorder ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_HospStatGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                StartOrder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["fieldorder"]);
                //LDW modGlobal.gv_rs.MoveLast();
                TotalFields = modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count;
                //LDW modGlobal.gv_rs.MoveFirst();

                //update the selected one
                modGlobal.gv_sql = " select * from  tbl_setup_HospStatGroupFields   ";
                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_HospStatGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                ThisFieldOrder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["fieldorder"]);

                NewPos = Convert.ToInt32(RadInputBox.Show("Type in the order number for this field (should be between 1 and " + TotalFields + ")", "Move Field Position", Convert.ToString(1)));
                if (!Information.IsNumeric(NewPos))
                {
                    RadMessageBox.Show("Numeric values only.");
                    return;
                }
                if (Convert.ToInt16(NewPos) < 1 | Convert.ToInt16(NewPos) > TotalFields)
                {
                    RadMessageBox.Show("Invalid position.");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                //update all the fields except the selected one
                modGlobal.gv_sql = "Select hsf.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                modGlobal.gv_sql = string.Format("{0} and hsf.ddid <> {1}", modGlobal.gv_sql, rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by fieldorder ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_HospStatGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                i = StartOrder - 1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                {
                    i = i + 1;
                    abspos = abspos + 1;

                    if (abspos == Convert.ToInt16(NewPos))
                    {
                        i = i + 1;
                    }

                    modGlobal.gv_sql = " update tbl_setup_HospStatGroupFields   ";
                    modGlobal.gv_sql = string.Format("{0} set fieldorder = {1}", modGlobal.gv_sql, i);
                    modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow10.Field<int>("DDID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //update the selected one
                modGlobal.gv_sql = " update tbl_setup_HospStatGroupFields   ";
                modGlobal.gv_sql = string.Format("{0} set fieldorder = {1}{2}", modGlobal.gv_sql, Convert.ToInt16(NewPos), StartOrder - 1);
                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshHospStatAllFields();
                Cursor.Current = Cursors.Default;
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
            int ThisFieldID ;
            int CurrOrderNum = 0;
            int FCount = 0;

            try
            {

                if (rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count < 0)
                {
                    return;
                }

                //retrieve the list of  fields for the selected Section
                modGlobal.gv_sql = "Select  hsf.ddid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields as hsf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup as hsg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsf.HospStatGroupID = hsg.HospStatGroupID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where hsg.IndicatorGroupID = " +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by hsf.fieldorder ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_HospStatGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                //first we make sure every field in this list has a number

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = string.Format("{0} set tbl_setup_HospStatGroupFields.FieldOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_HospStatGroupFields.DDID = {1}", modGlobal.gv_sql, myRow11.Field<int>("DDID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (Convert.ToInt32(rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]) == myRow11.Field<int>("DDID"))
                    {
                        CurrOrderNum = FCount;
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                ThisFieldID = Convert.ToInt32(rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]);
                if ((CurrOrderNum - 1) > 0)
                {
                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = string.Format("{0} set tbl_setup_HospStatGroupFields.FieldOrder = {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    modGlobal.gv_sql = string.Format("{0} and FieldOrder = {1}", modGlobal.gv_sql, CurrOrderNum - 1);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "Update tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = string.Format("{0} set tbl_setup_HospStatGroupFields.FieldOrder = {1}", modGlobal.gv_sql, CurrOrderNum - 1);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_HospStatGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_HospStatGroupFields.HospStatGroupID = tbl_setup_HospStatGroup.HospStatGroupID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroup.IndicatorGroupID = " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_HospStatGroupFields.DDID = {1}", modGlobal.gv_sql, rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshHospStatAllFields();
                    //find the right field
                    for (i = 1; i <= rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(rdcHospStatFields.Tables[rdcHospStatFieldsTable].Rows[0]["DDID"]) == ThisFieldID)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        //LDW rdcHospStatFields.Resultset.MoveNext();
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

        private void cmdNew_Click(object sender, EventArgs e)
        {
            var i = 0;
            int NewIndGID = modDBSetup.FindMaxRecID("tbl_Setup_IndicatorGroup", "IndicatorGroupID");
            string NewGroup = null;


            try
            {

                NewGroup = RadInputBox.Show("Please enter the description of the new section:", "Add New Section", "");
                if (string.IsNullOrEmpty(NewGroup))
                {
                    return;
                }
                modGlobal.gv_sql = "Insert into tbl_setup_IndicatorGroup (IndicatorGroupID, GroupDescription, BaseTableID, State, RecordStatus) ";
                modGlobal.gv_sql = string.Format("{0} Values ({1},'{2}',{3},", modGlobal.gv_sql, NewIndGID, NewGroup, basetableid);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
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
                cboIndicatorGroup.Text = NewGroup;

                //set the selected list item to the new one
                for (i = 0; i <= cboIndicatorGroup.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(cboIndicatorGroup, i) == NewIndGID)
                    {
                        cboIndicatorGroup.SelectedIndex = i;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                sstabMainTab.Enabled = true;

                RefreshHospStatGroups();
                RefreshHospStatGroupFields();
                RefreshGroupIndicator();
                RefreshHospStatAllFields();
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

        public void RefreshBaseTableID()
        {
            try
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " upper(substring(BaseTable,1,13)) = 'HOSPITAL STAT' ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);
                basetableid = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName12].Rows[0]["basetableid"]);
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

        private void cmdNewGroup_Click(object sender, EventArgs e)
        {
            var i = 0;
            int NewGID = modDBSetup.FindMaxRecID("tbl_Setup_HospStatGroup", "HospStatGroupID");
            string NewGroup = null;

            try
            {
                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a section.");
                    return;
                }

                NewGroup = RadInputBox.Show("Please enter the description of the new group:", "Add New Group", "");
                if (string.IsNullOrEmpty(NewGroup))
                {
                    return;
                }
                modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroup (HospStatGroupID, GroupDescription, IndicatorGroupID) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + NewGID + ",'" + NewGroup + "'," +
                    Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshHospStatGroups();
                lstHospStatGroup.Text = NewGroup;

                //set the selected list item to the new one
                for (i = 0; i <= lstHospStatGroup.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstHospStatGroup, i) == NewGID)
                    {
                        lstHospStatGroup.SelectedIndex = i;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                sstabGroupDetails.Enabled = true;

                RefreshHospStatGroupFields();
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

        private void cmdRemoveFieldFromGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstHospStatGroupFields.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_setup_HospStatGroupFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID = " +
                    Support.GetItemData(lstHospStatGroupFields, lstHospStatGroupFields.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and HospStatGroupID =  " +
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                RefreshHospStatGroupFields();
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

        private void cmdRemoveFieldIndicator_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFieldIndicator.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Delete tbl_setup_HospStatGroupIndicator ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorID = " +
                        Support.GetItemData(lstFieldIndicator, lstFieldIndicator.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and hospstatgroupid = " +
                        Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                RefreshGroupIndicator();
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

        private void cmdRemoveValidation_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcHospStatValid.Tables[rdcHospStatValidTable].Rows.Count > 0)
                {
                    modGlobal.gv_sql = "Delete tbl_Setup_HospStatval where HospStatvalidid = " + rdcHospStatValid.Tables[rdcHospStatValidTable].Rows[0]["HospStatValidID"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshHospStatValidation();
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



        public void RefreshHospStatValidation()
        {
            try
            {
                if (lstHospStatGroup.SelectedIndex < 0)
                {
                    //retrieve the list of validation for the selected group
                    modGlobal.gv_sql = "Select  * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_HospStatVal ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where HospStatValidID  = -1 ";
                }
                else
                {
                    //retrieve the list of validation for the selected group
                    modGlobal.gv_sql = "Select  * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_HospStatVal ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where HospStatGroupID1  = " +
                        Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                }

                //LDW rdcHospStatValid.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcHospStatValidTable = "tbl_Setup_HospStatVal";
                rdcHospStatValid = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcHospStatValidTable, rdcHospStatValid);

                //resp = InputBox("", "", gv_sql) 'rdcPatientFields.Resultset.RowCount
                rdcHospStatValid.AcceptChanges();
                //RefreshFieldIndicator
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

        private void frmHospStatSetup_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            //LDW sstabMainTab.TabIndex = 0;
            sstabMainTab.ActiveWindow = sstabMainTabGroup;
            //LDW sstabGroupDetails.TabIndex = 0;
            sstabGroupDetails.ActiveWindow = sstabGroupDetailsFields;

            sstabMainTab.Enabled = false;

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

                RefreshBaseTableID();
                RefreshIndicatorSet();
                RefreshHospStatGroups();
                RefreshHospStatAllFields();
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

        private void lstHospStatGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshHospStatGroupFields();
                RefreshGroupIndicator();
                RefreshHospStatGroupForVal();
                RefreshHospStatValidation();
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

        public void RefreshHospStatGroups()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemslstHospStatGroup = new List<Item>();


            try
            {
                //retrieve the list of Hosp. Stat. Groups
                modGlobal.gv_sql = "Select tbl_setup_HospStatGroup.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup ";
                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID =  -1 ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID =  " +
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by GroupDescription ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_HospStatGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                lstHospStatGroup.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow13 in modGlobal.gv_rs.Tables[sqlTableName13].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemslstHospStatGroup.Add(new Item(myRow13.Field<int>("HospStatGroupID"), myRow13.Field<string>("GroupDescription")));

                    //lstHospStatGroup.Items.Add(new ListBoxItem(myRow13.Field<string>("GroupDescription"), myRow13.Field<int>("HospStatGroupID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstHospStatGroup.DataSource = itemslstHospStatGroup;
                this.lstHospStatGroup.DisplayMember = "Description";
                this.lstHospStatGroup.ValueMember = "Id";
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

        public void RefreshHospStatGroupFields()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemslstHospStatGroupFields = new List<Item>();



            try
            {
                if (lstHospStatGroup.SelectedIndex < 0)
                {
                    //retrieve the list of Hosp. Stat. fields for the selected Group
                    modGlobal.gv_sql = "Select tbl_setup_HospStatGroupFields.*, tbl_setup_datadef.FieldName  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields, tbl_setup_datadef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroupFields.DDID =  tbl_setup_datadef.DDID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.HospStatGroupID = -1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_HospStatGroupFields.fieldorder, tbl_setup_datadef.FieldName ";
                }
                else
                {
                    //retrieve the list of Hosp. Stat. fields for the selected Group
                    modGlobal.gv_sql = "Select tbl_setup_HospStatGroupFields.*, tbl_setup_datadef.FieldName  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroupFields, tbl_setup_datadef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_HospStatGroupFields.DDID =  tbl_setup_datadef.DDID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_HospStatGroupFields.HospStatGroupID = " +
                        Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_HospStatGroupFields.fieldorder, tbl_setup_datadef.FieldName ";
                }


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_setup_HospStatGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);
                lstHospStatGroupFields.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow14 in modGlobal.gv_rs.Tables[sqlTableName14].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemslstHospStatGroupFields.Add(new Item(myRow14.Field<int>("DDID"), myRow14.Field<string>("FieldName")));

                    //lstHospStatGroupFields.Items.Add(new ListBoxItem(myRow14.Field<string>("FieldName"), myRow14.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstHospStatGroupFields.DataSource = itemslstHospStatGroupFields;
                this.lstHospStatGroupFields.DisplayMember = "Description";
                this.lstHospStatGroupFields.ValueMember = "Id";
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

       

        private void sstabMainTab_SelectedTabChanged(object sender, Telerik.WinControls.UI.Docking.SelectedTabChangedEventArgs e)
        {
            try
            {
                lock (static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init)
                {
                    try
                    {
                        if (InitStaticVariableHelper(static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init))
                        {
                            static_sstabMainTab_SelectedIndexChanged_PreviousTab = sstabMainTab.ActiveWindow.DockTabStrip.SelectedIndex;
                        }
                    }
                    finally
                    {
                        static_sstabMainTab_SelectedIndexChanged_PreviousTab_Init.State = 1;
                    }
                }
                if (sstabMainTab.ActiveWindow.DockTabStrip.SelectedIndex == 1)
                {
                    RefreshHospStatAllFields();
                }

                static_sstabMainTab_SelectedIndexChanged_PreviousTab = sstabMainTab.ActiveWindow.DockTabStrip.SelectedIndex;
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

        static bool InitStaticVariableHelper(StaticLocalInitFlag flag)
        {
            if (flag.State == 0)
            {
                flag.State = 2;
                return true;
            }
            else if (flag.State == 2)
            {
                throw new IncompleteInitialization();
            }
            else
            {
                return false;
            }
        }

        public void RefreshHospStatGroupForVal()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemscboGroupList = new List<Item>();


            try
            {
                //retrieve the list of Hosp. Stat. Groups
                modGlobal.gv_sql = "Select tbl_setup_HospStatGroup.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                if (lstHospStatGroup.SelectedIndex >= 0)
                {
                    modGlobal.gv_sql = string.Format("{0} HospStatGroupID <>  {1} and ", modGlobal.gv_sql,
                        Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex));
                }
                if (cboIndicatorGroup.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} IndicatorGroupID =  {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorGroupID =  -1 ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by GroupDescription ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTablename15 = "tbl_setup_HospStatGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTablename15, modGlobal.gv_rs);

                //If gv_rs.RowCount = 0 Then
                //    sstabGroupDetails.TabEnabled(2) = False
                //Else
                //    sstabGroupDetails.TabEnabled(2) = True
                //End If

                cboGroupList.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow15 in modGlobal.gv_rs.Tables[sqlTablename15].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    itemscboGroupList.Add(new Item(myRow15.Field<int>("HospStatGroupID"), myRow15.Field<string>("GroupDescription")));

                    //cboGroupList.Items.Add(new ListBoxItem(myRow15.Field<string>("GroupDescription"), myRow15.Field<int>("HospStatGroupID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboGroupList.DataSource = itemscboGroupList;
                this.cboGroupList.DisplayMember = "Description";
                this.cboGroupList.ValueMember = "Id";
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

        public void AddValidation(object ValType)
        {
            int NextNewID = modDBSetup.FindMaxRecID("tbl_setup_HospStatVal", "HospStatValidID");
            string ValDisplay = null;
            string TempTable = null;


            try
            {
                if (lstHospStatGroup.SelectedIndex == -1)
                {
                    RadMessageBox.Show("Please select a group from the above list.");
                    return;
                }
                TempTable = "tbl_tempdetaildata";

                if (string.IsNullOrEmpty(cboOperator.Text))
                {
                    RadMessageBox.Show("Please define the operator.");
                    return;
                }

                if (string.IsNullOrEmpty(cboGroupList.Text))
                {
                    RadMessageBox.Show("Please define the Group for comparison.");
                    return;
                }


                if (string.IsNullOrEmpty(txtMessage.Text))
                {
                    RadMessageBox.Show("Please define the validation message.");
                    return;
                }

                ValDisplay = string.Format("{0} {1} {2}", lstHospStatGroup.Text, cboOperator.Text, cboGroupList.Text);

                modGlobal.gv_sql = "insert into tbl_setup_HospStatVal (HospStatVALIDID, HospStatGroupID1, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " HospStatGroupID2, Display, Operator, Message, Type, EffDate)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," +
                    Support.GetItemData(lstHospStatGroup, lstHospStatGroup.SelectedIndex);
                modGlobal.gv_sql = string.Format("{0} ,{1},", modGlobal.gv_sql, Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}','{2}','{3}',", modGlobal.gv_sql, ValDisplay, cboOperator.Text, modGlobal.ConvertApastroph(txtMessage.Text));
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, ValType);
                if (string.IsNullOrEmpty(txtValEffDate.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, txtValEffDate.Text);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshHospStatValidation();
                cboOperator.Text = "";
                cboGroupList.Text = "";
                txtMessage.Text = "";
                txtValEffDate.Text = "";
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
