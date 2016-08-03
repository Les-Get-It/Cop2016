using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmIndicatorAddToSet : Telerik.WinControls.UI.RadForm
    {
        public frmIndicatorAddToSet()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void frmIndicatorAddToSet_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
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
            //txtDisplayOrder = frmSectionIndicator.rdcPatientFields.Resultset!DisplayOrder
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();
            int newid;
            var i = 0;


            try
            {
                for (i = 0; i <= lstIndicators.Items.Count - 1; i++)
                {
                    if (lstIndicators.SelectedIndex == i)
                    {
                        newid = modDBSetup.FindMaxRecID("tbl_Setup_IndicatorsetField", "IndLinkID");

                        modGlobal.gv_sql = "Insert into tbl_setup_IndicatorsetField (IndLinkID, IndicatorSetID, IndicatorID)";
                        modGlobal.gv_sql = string.Format("{0} Values ({1}", modGlobal.gv_sql, newid);
                        modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql,
                            Support.GetItemData(frmIndicatorSetupCopy.cboIndicatorSet, frmIndicatorSetupCopy.cboIndicatorSet.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, Support.GetItemData(lstIndicators, i));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }
                frmIndicatorSetupCopy.RefreshIndicatorSetField();

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

        public void RefreshIndicators()
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;

            try
            {
                //retrieve the list of indicators
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select IndicatorID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorSetField ";
                modGlobal.gv_sql = string.Format("{0} where IndicatorSetID = {1})", modGlobal.gv_sql,
                    Support.GetItemData(frmIndicatorSetupCopy.cboIndicatorSet, frmIndicatorSetupCopy.cboIndicatorSet.SelectedIndex));
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
