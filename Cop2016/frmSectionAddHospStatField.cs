using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmSectionAddHospStatField : Telerik.WinControls.UI.RadForm
    {

        public frmSectionAddHospStatField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboTableFields_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshIndicators();
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
            frmHospStatSetup frmHospStatSetupCopy = new frmHospStatSetup();
            int newid;
            var i = 0;
            int MaxOrder;

            try
            {
                if (string.IsNullOrEmpty(cboTableFields.Text))
                {
                    RadMessageBox.Show("Please select a field from the list.");
                    return;
                }

                modGlobal.gv_sql = "Select max(tbl_setup_DataDef.FieldOrder) as MaxOrder ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef inner join tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where upper(substring(tbl_Setup_TableDef.BaseTable,1,13)) = 'HOSPITAL STAT' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_DataDef.FieldCategory <> 'Fix' ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                MaxOrder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MaxOrder"]) + 1;

                modGlobal.gv_sql = "update tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} set IndicatorGroupID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(frmHospStatSetupCopy.cboIndicatorGroup, frmHospStatSetupCopy.cboIndicatorGroup.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}, FieldOrder = {1}", modGlobal.gv_sql, MaxOrder);
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboTableFields, cboTableFields.SelectedIndex));

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                for (i = 0; i <= lstIndicators.Items.Count - 1; i++)
                {
                    if (lstIndicators.SelectedIndex == i)
                    {
                        newid = modDBSetup.FindMaxRecID("tbl_Setup_DataReq", "IndicatorDDID");

                        modGlobal.gv_sql = "Insert into tbl_setup_DataReq (IndicatorDDID, IndicatorID, DDID)";
                        modGlobal.gv_sql = string.Format("{0} Values ({1}", modGlobal.gv_sql, newid);
                        modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, Support.GetItemData(lstIndicators, i));
                        modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, Support.GetItemData(cboTableFields, cboTableFields.SelectedIndex));

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

        private void frmSectionAddHospStatField_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshTableField();
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

        public void RefreshTableField()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;


            try
            {
                //retrieve the list of Patient Fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef inner join tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where upper(substring(tbl_Setup_TableDef.BaseTable,1,13)) = 'HOSPITAL STAT' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_DataDef.FieldCategory <> 'Fix' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_DataDef.IndicatorGroupID is null ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_Setup_DataDef.FieldName ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboTableFields.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    cboTableFields.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());
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

        public void RefreshIndicators()
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
                if (cboTableFields.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1})", modGlobal.gv_sql, Support.GetItemData(cboTableFields, cboTableFields.SelectedIndex));
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
