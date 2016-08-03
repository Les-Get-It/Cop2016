using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSubmissionUpdateValidation : Telerik.WinControls.UI.RadForm
    {
        public string rdcValidationErrorsTable = "tbl_setup_submitValidation";
        public string rdcValidationWarningsTable = "tbl_setup_submitValidation";



        public frmSubmissionUpdateValidation()
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
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();

            try
            {

                if (cboIndicators.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select an indicator.");
                    return;
                }
                if (string.IsNullOrEmpty(txtMessage.Text))
                {
                    RadMessageBox.Show("Please define a validation message for the report.");
                    return;
                }

                modGlobal.gv_sql = "Update tbl_setup_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set IndicatorID = " + Support.GetItemData(cboIndicators, cboIndicators.SelectedIndex) + ",";
                modGlobal.gv_sql = modGlobal.gv_sql + " Message = '" + modGlobal.ConvertApastroph(txtMessage.Text) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValType = '" + modGlobal.gv_Action + "' ";
                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID  = " + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["SubmitValID"];
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID  = " + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["SubmitValID"];
                }
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_Action = "Update";
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

        private void frmSubmissionUpdateValidation_Load(object sender, EventArgs e)
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int IndicatorListIndex = 0;
            var i = 0;


            this.CenterToParent();

            try
            {

                //populate the indicator drop down box
                cboIndicators.Items.Clear();

                modGlobal.gv_sql = "select tbl_setup_Indicator.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator  ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (state = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (state = '' or State is null or state = '" + modGlobal.gv_status + "')";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                i = -1;
                IndicatorListIndex = i;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    i = i + 1;
                    cboIndicators.Items.Add(new ListBoxItem(myRow1.Field<string>("Description"), myRow1.Field<int>("IndicatorID")).ToString());
                    if (modGlobal.gv_Action == "ERROR")
                    {
                        if (myRow1.Field<int>("IndicatorID") == Convert.ToInt32(frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["IndicatorID"]))
                        {
                            IndicatorListIndex = i;
                        }
                    }
                    else if (modGlobal.gv_Action == "WARNING")
                    {
                        if (myRow1.Field<int>("IndicatorID") == Convert.ToInt32(frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["IndicatorID"]))
                        {
                            IndicatorListIndex = i;
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                cboIndicators.SelectedIndex = IndicatorListIndex;

                if (modGlobal.gv_Action == "ERROR")
                {
                    txtMessage.Text = frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["Message"].ToString();
                }
                else
                {
                    txtMessage.Text = frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["Message"].ToString();
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
