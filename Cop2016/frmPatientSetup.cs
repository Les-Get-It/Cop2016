using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmPatientSetup : RadForm
    {
        int basetableid;
        const string sqlTableName1 = "tbl_setup_Indicator";
        public DataSet rdcPatientFields = new DataSet();
        public string rdcPatientFieldsTable = null;
        public DataSet rdcSections = new DataSet();
        public string rdcSectionsTable = null;
        readonly StaticLocalInitFlag static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init = new StaticLocalInitFlag();
        int static_sstabpatientSetup_SelectedIndexChanged_PreviousTab;



        public frmPatientSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void RefreshIndicatorDep()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            RadListControl lstRequiredIndicator = new RadListControl();
            RadListControl lstIndicators = new RadListControl();

            try
            {

                modGlobal.gv_sql = "Select tbl_setup_Indicator.Description, tbl_setup_IndicatorDep.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator, tbl_setup_IndicatorDep ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_Indicator.IndicatorID = tbl_setup_IndicatorDep.IndicatorID ";
                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_IndicatorDep.IndicatorParentID = " + lstIndicators.ItemData(lstIndicators.ListIndex);
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_IndicatorDep.IndicatorParentID = {1}", modGlobal.gv_sql, Support.GetItemData(lstIndicators, lstIndicators.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lstRequiredIndicator.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    lstRequiredIndicator.Items.Add(new ListBoxItem(myRow1.Field<string>("Description"), myRow1.Field<int>("IndicatorDepID")).ToString());
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

        private void cboIndicatorGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshPatientFields();
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

        private void cmdAddPatientField_Click(object sender, EventArgs e)
        {
            frmSectionAddPatientField frmSectionAddPatientFieldCopy = new frmSectionAddPatientField();

            try
            {

                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Section.");
                    return;
                }

                frmSectionAddPatientFieldCopy.ShowDialog();
                RefreshPatientFields();
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
                modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshBaseTableID();
                RefreshIndicatorSet();
                RefreshSectionList();
                RefreshPatientFields();
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
            DataSet thisrs = new DataSet();


            try
            {
                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    return;
                }

                //Delete the relationship between field and indicator,
                // only if the fields in this group have not been selected for any other group
                modGlobal.gv_sql = "Select * from tbl_Setup_IndicatorGroupSet ";
                modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));

                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_IndicatorGroupSet";
                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, thisrs);
                //LDW while (!thisrs.EOF)
                foreach (DataRow myRow2 in thisrs.Tables[sqlTableName2].Rows)
                {
                    modGlobal.gv_sql = "Select * from tbl_Setup_IndicatorGroupSet ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, myRow2.Field<string>("DDID"));
                    modGlobal.gv_sql = string.Format("{0} and IndicatorGroupID <> {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                    if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count == 0)
                    {
                        modGlobal.gv_sql = "Delete tbl_setup_DataReq ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, myRow2.Field<string>("DDID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    //LDW thisrs.MoveNext();
                }

                modGlobal.gv_sql = "Delete tbl_Setup_IndicatorGroupSet ";
                modGlobal.gv_sql = string.Format("{0}  where IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_Setup_IndicatorGroup ";
                modGlobal.gv_sql = string.Format("{0}  where IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshIndicatorSet();
                cboIndicatorGroup.SelectedIndex = -1;
                RefreshPatientFields();
                RefreshFieldIndicator();
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
                    modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
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

        private void cmdEditPatientField_Click(object sender, EventArgs e)
        {
            frmSectionEditPatientField frmSectionEditPatientFieldCopy = new frmSectionEditPatientField();

            try
            {

                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Section.");
                    return;
                }
                if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
                {
                    RadMessageBox.Show("Please select a field.");
                    return;
                }

                frmSectionEditPatientFieldCopy.ShowDialog();
                RefreshPatientFields();
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
            int ThisFieldID;
            int MaxOrderNum = 0;
            int CurrOrderNum = 0;
            int FCount = 0;

            try
            {

                if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
                {
                    return;
                }

                //retrieve the list of patient fields for the selected Section
                modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
                modGlobal.gv_sql = string.Format("{0} where igs.IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder, dd.FieldName ";


                //first we make sure every field in this list has a number
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
                    modGlobal.gv_sql = string.Format("{0} set FieldOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = string.Format("{0} where indicatorgroupsetid = {1}", modGlobal.gv_sql, myRow3.Field<int>("IndicatorGroupsetID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    if (Convert.ToInt32(rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["IndicatorGroupsetID"]) == myRow3.Field<int>("IndicatorGroupsetID"))
                    {
                        CurrOrderNum = FCount;
                    }
                    MaxOrderNum = FCount;
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                ThisFieldID = Convert.ToInt32(rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);

                if (CurrOrderNum < MaxOrderNum)
                {
                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
                    modGlobal.gv_sql = string.Format("{0} set FieldOrder =  {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " and FieldOrder = " + CurrOrderNum + 1;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "update tbl_setup_indicatorgroupset  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder = " + CurrOrderNum + 1;
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);
                    modGlobal.gv_sql = string.Format("{0} and indicatorgroupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    RefreshPatientFields();
                    //find the right field
                    for (i = 1; i <= rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]) == ThisFieldID)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        //LDW rdcPatientFields.Resultset.MoveNext();
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
            int ThisFieldID;
            int CurrOrderNum = 0;
            int FCount = 0;

            try
            {

                if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
                {
                    return;
                }

                //retrieve the list of patient fields for the selected Section
                modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
                modGlobal.gv_sql = string.Format("{0} where igs.IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder, dd.FieldName ";

                //first we make sure every field in this list has a number
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
                    modGlobal.gv_sql = string.Format("{0} set FieldOrder = {1}", modGlobal.gv_sql, FCount);
                    modGlobal.gv_sql = string.Format("{0} where indicatorgroupsetid = {1}", modGlobal.gv_sql, myRow5.Field<string>("IndicatorGroupsetID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (Convert.ToInt32(rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["IndicatorGroupsetID"]) == myRow5.Field<int>("IndicatorGroupsetID"))
                    {
                        CurrOrderNum = FCount;
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                ThisFieldID = Convert.ToInt32(rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);
                if ((CurrOrderNum - 1) > 0)
                {
                    //update order number of the field prior to this one
                    modGlobal.gv_sql = "update tbl_setup_indicatorgroupset  ";
                    modGlobal.gv_sql = string.Format("{0} set FieldOrder =  {1}", modGlobal.gv_sql, CurrOrderNum);
                    modGlobal.gv_sql = string.Format("{0} where IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and FieldOrder = {1}", modGlobal.gv_sql, CurrOrderNum - 1);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //update order number of this field
                    modGlobal.gv_sql = "update tbl_setup_indicatorgroupset  ";
                    modGlobal.gv_sql = string.Format("{0} set FieldOrder = {1}", modGlobal.gv_sql, CurrOrderNum - 1);
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);
                    modGlobal.gv_sql = string.Format("{0} and indicatorgroupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshPatientFields();
                    //find the right field
                    for (i = 1; i <= rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]) == ThisFieldID)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        //LDW rdcPatientFields.Resultset.MoveNext();
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
                NewGroup = RadInputBox.Show("Please enter the description of the new group:", "Add New Group", "");

                if (string.IsNullOrEmpty(NewGroup))
                {
                    return;
                }

                modGlobal.gv_sql = "Insert into  tbl_setup_IndicatorGroup (IndicatorGroupID, GroupDescription, BaseTableID, State, RecordStatus) ";
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
                    modGlobal.gv_sql = "Delete tbl_setup_DataReq ";
                    modGlobal.gv_sql = string.Format("{0} where IndicatorDDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldIndicator, lstFieldIndicator.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                RefreshFieldIndicator();
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

        private void cmdRemovePatientField_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to remove this field from the list?", "Remove Patient Field From Section", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (string.IsNullOrEmpty(cboIndicatorGroup.Text))
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }
                modGlobal.gv_sql = "Delete tbl_setup_IndicatorGroupset ";
                modGlobal.gv_sql = string.Format("{0} Where IndicatorGroupsetID =  {1}", modGlobal.gv_sql, rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["IndicatorGroupsetID"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //remove the link between field and indicator
                //only if this field has not been selected for any other section
                modGlobal.gv_sql = "select * from tbl_setup_IndicatorGroupset ";
                modGlobal.gv_sql = string.Format("{0} Where DDID =  {1}", modGlobal.gv_sql, rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_setup_IndicatorGroupset";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count == 0)
                {
                    modGlobal.gv_sql = "delete tbl_setup_DataReq ";
                    modGlobal.gv_sql = string.Format("{0} Where DDID =  {1}", modGlobal.gv_sql, rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                RefreshPatientFields();
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

        private void frmPatientSetup_Load(object sender, EventArgs e)
        {
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


                //LDW sstabpatientSetup.SelectedIndex = 0;
                sstabpatientSetup.ActiveWindow = sstabpatientSetup0;
                //sstSectionIndicator.Tab = 0
                //sstabIndicatorList.Tab = 0
                //RefreshIndicatorGroup
                //RefreshIndicator
                RefreshBaseTableID();
                RefreshIndicatorSet();
                RefreshSectionList();
                RefreshPatientFields();
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

        public void RefreshPatientFields()
        {
            try
            {
                //retrieve the list of patient fields for the selected Section
                modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
                if (cboIndicatorGroup.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where igs.IndicatorGroupID = 0 ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where igs.IndicatorGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex));
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder, dd.FieldName ";

                //retrieve the list of patient fields for the selected Section
                //gv_sql = "Select  DDID, Fieldname, FieldOrder "
                //gv_sql = gv_sql & " from tbl_Setup_DataDef "
                //gv_sql = gv_sql & " order by FieldOrder, FieldName "

                //resp = InputBox("", "", gv_sql)
                //LDW rdcPatientFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcPatientFieldsTable = "tbl_Setup_DataDef";
                rdcPatientFields = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcPatientFieldsTable, rdcPatientFields);
                rdcPatientFields.AcceptChanges();

                dbgPatientFields.Refresh();
                RefreshFieldIndicator();
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

        public void RefreshFieldIndicator()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {


                if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
                {
                    lstFieldIndicator.Items.Clear();
                    return;
                }

                modGlobal.gv_sql = "Select tbl_Setup_DataReq.*, tbl_setup_Indicator.Description as Indicator  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataReq, tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataReq.IndicatorID = tbl_setup_Indicator.IndicatorID ";
                modGlobal.gv_sql = string.Format("{0} and tbl_Setup_DataReq.ddid = {1}", modGlobal.gv_sql, rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_Setup_DataReq";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                lstFieldIndicator.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    lstFieldIndicator.Items.Add(new ListBoxItem(myRow8.Field<string>("Indicator"), myRow8.Field<int>("IndicatorDDID")).ToString());
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
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {

                //retrieve the list of Indicator Groups
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorGroup ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
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
                modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder, GroupDescription ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_IndicatorGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                cboIndicatorGroup.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    cboIndicatorGroup.Items.Add(new ListBoxItem(myRow9.Field<string>("GroupDescription"), myRow9.Field<int>("indicatorgroupid")).ToString());
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

        public void RefreshBaseTableID()
        {
            try
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " upper(substring(BaseTable,1,7)) = 'PATIENT' ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                basetableid = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["basetableid"]);
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

        public void RefreshSectionList()
        {
            try
            {
                //retrieve the list of sections
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorGroup ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID = {1}", modGlobal.gv_sql, basetableid);
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
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
                modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

                //LDW rdcSections.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcSectionsTable = "tbl_setup_IndicatorGroup";
                rdcSections = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcSectionsTable, rdcSections);
                rdcSections.AcceptChanges();

                dbgSections.Refresh();
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



        private void sstabpatientSetup_SelectedTabChanged(object sender, Telerik.WinControls.UI.Docking.SelectedTabChangedEventArgs e)
        {
            try
            {
                lock (static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init)
                {
                    try
                    {
                        if (InitStaticVariableHelper(static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init))
                        {
                            static_sstabpatientSetup_SelectedIndexChanged_PreviousTab = documentTabStrip1.SelectedIndex;
                        }
                    }
                    finally
                    {
                        static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init.State = 1;
                    }
                }
                if (documentTabStrip1.SelectedIndex == 1)
                {
                    RefreshSectionList();
                }
                static_sstabpatientSetup_SelectedIndexChanged_PreviousTab = documentTabStrip1.SelectedIndex;
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



        /*LDW Not used

        private void rdcPatientFields_Reposition()
        {

            RefreshFieldIndicator();

        }


         */
    }
}
