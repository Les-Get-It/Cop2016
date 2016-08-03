using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmMeasureModifyOperator : Telerik.WinControls.UI.RadForm
    {
        int mcid;

        public frmMeasureModifyOperator()
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbOperators.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select an operator");
                    return;
                }

                modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} set valueoperator = '{1}' ", modGlobal.gv_sql, cmbOperators.Text);
                modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.UpdateVerificationCriteriaTitle(mcid);

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

        private void frmMeasureModifyOperator_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        public void SetMeasureCriteriaID(int MeasureCriteriaID)
        {
            mcid = MeasureCriteriaID;
            try
            {
                RefreshOperatorList();
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

        public void RefreshOperatorList()
        {
            try
            {
                cmbOperators.Items.Clear();

                modGlobal.gv_sql = "select * from tbl_Setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["valueoperator"].ToString() == "In" | modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["valueoperator"].ToString() == "Not In")
                {
                    cmbOperators.Items.Add("In");
                    cmbOperators.Items.Add("Not In");
                }
                else
                {
                    cmbOperators.Items.Add("=");
                    cmbOperators.Items.Add("<>");
                    cmbOperators.Items.Add(">");
                    cmbOperators.Items.Add("<");
                    cmbOperators.Items.Add(">=");
                    cmbOperators.Items.Add("<=");
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
