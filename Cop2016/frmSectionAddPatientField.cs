using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmSectionAddPatientField : Telerik.WinControls.UI.RadForm
    {

        public frmSectionAddPatientField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboPatientFields_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                refreshIndicators();
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

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            frmPatientSetup frmPatientSetupCopy = new frmPatientSetup();
            var i = 0;
            int newid = modDBSetup.FindMaxRecID("tbl_Setup_Indicatorgroupset", "Indicatorgroupsetid");
            int maxorder;


            try
            {
                if (string.IsNullOrEmpty(cboPatientFields.Text))
                {
                    RadMessageBox.Show("Please select a field from the list.");
                    return;
                }

                modGlobal.gv_sql = "Select max(tbl_setup_indicatorgroupset.FieldOrder) as MaxOrder ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_indicatorgroupset ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_indicatorgroupset.ddid = tbl_setup_DataDef.ddid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE tbl_Setup_TableDef.BaseTable = 'PATIENT' ";
                modGlobal.gv_sql = string.Format("{0} AND IndicatorGroupID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(frmPatientSetupCopy.cboIndicatorGroup, frmPatientSetupCopy.cboIndicatorGroup.SelectedIndex));
                //gv_sql = gv_sql & " and tbl_Setup_DataDef.FieldCategory <> 'Fix' "

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_indicatorgroupset";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                maxorder = (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["maxorder"]) ? 0 : Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["maxorder"])) + 1;

                modGlobal.gv_sql = "insert into tbl_setup_indicatorgroupset ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (indicatorgroupsetid, IndicatorGroupID, ddid, fieldorder) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values ( ";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, newid);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(frmPatientSetupCopy.cboIndicatorGroup, frmPatientSetupCopy.cboIndicatorGroup.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}{1}) ", modGlobal.gv_sql, maxorder);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                for (i = 0; i <= lstIndicators.Items.Count - 1; i++)
                {
                    if (lstIndicators.SelectedIndex == i)
                    {
                        newid = modDBSetup.FindMaxRecID("tbl_setup_DataReq", "Indicatorddid");

                        modGlobal.gv_sql = "Insert into tbl_setup_DataReq ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (IndicatorDDID, IndicatorID, DDID)";
                        modGlobal.gv_sql = string.Format("{0} Values ({1}", modGlobal.gv_sql, newid);
                        modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, Support.GetItemData(lstIndicators, i));
                        modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex));

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }

                this.Close();
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

        private void frmSectionAddPatientField_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshPatientField();
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

        public void RefreshPatientField()
        {
            frmPatientSetup frmPatientSetupCopy = new frmPatientSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;


            try
            {
                //retrieve the list of Patient Fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef inner join tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_TableDef.BaseTable = 'PATIENT' ";
                //gv_sql = gv_sql & " and tbl_Setup_DataDef.FieldCategory <> 'Fix' "
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid not in ";
                modGlobal.gv_sql = string.Format("{0} (Select ddid from tbl_setup_indicatorgroupset where indicatorgroupid = {1})",
                    modGlobal.gv_sql, Support.GetItemData(frmPatientSetupCopy.cboIndicatorGroup, frmPatientSetupCopy.cboIndicatorGroup.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_Setup_DataDef.FieldName ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboPatientFields.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    cboPatientFields.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());
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

        public void refreshIndicators()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {
                //retrieve the list of indicators
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where IndicatorID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select IndicatorID from tbl_setup_DataReq ";
                if (cboPatientFields.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1} )", modGlobal.gv_sql, Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = 0 ) ";
                }
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and 1 = (SELECT CASE WHEN FieldCategory = 'Dynamic' THEN 1 ELSE 0 END FROM tbl_Setup_DataDef WHERE DDID = {1} )",
                    modGlobal.gv_sql, Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex));
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

                    lstIndicators.Items.Add(new ListBoxItem(myRow3.Field<string>("Description"), myRow3.Field<int>("IndicatorID")).ToString());
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
    }
}
