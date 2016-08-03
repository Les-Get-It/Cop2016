using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmSectionEditPatientField : Telerik.WinControls.UI.RadForm
    {
        public string rdcPatientFieldsTable = "tbl_Setup_DataDef";

        public frmSectionEditPatientField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            frmPatientSetup frmPatientSetupCopy = new frmPatientSetup();
            int newid;
            var i = 0;

            try
            {
                for (i = 0; i <= lstIndicators.Items.Count - 1; i++)
                {
                    if (lstIndicators.SelectedIndex == i)
                    {
                        newid = modDBSetup.FindMaxRecID("tbl_Setup_DataReq", "IndicatorDDID");


                        modGlobal.gv_sql = "Insert into tbl_setup_DataReq (IndicatorDDID, IndicatorID, DDID)";
                        modGlobal.gv_sql = string.Format("{0} Values ({1}", modGlobal.gv_sql, newid);
                        modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, Support.GetItemData(lstIndicators, i));
                        modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, frmPatientSetupCopy.rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);

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

        private void frmSectionEditPatientField_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
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
            //txtDisplayOrder = frmSectionIndicator.rdcPatientFields.Resultset!DisplayOrder
        }

        public void refreshIndicators()
        {
            frmPatientSetup frmPatientSetupCopy = new frmPatientSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;


            try
            {
                //retrieve the list of indicators
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where IndicatorID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select IndicatorID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataReq ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1})", modGlobal.gv_sql, frmPatientSetupCopy.rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and 1 = (SELECT CASE WHEN FieldCategory = 'Dynamic' THEN 1 ELSE 0 END FROM tbl_Setup_DataDef WHERE DDID = {1} )",
                    modGlobal.gv_sql, frmPatientSetupCopy.rdcPatientFields.Tables[rdcPatientFieldsTable].Rows[0]["DDID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lstIndicators.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    lstIndicators.Items.Add(new ListBoxItem(myRow1.Field<string>("Description"), myRow1.Field<int>("IndicatorID")).ToString());
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
