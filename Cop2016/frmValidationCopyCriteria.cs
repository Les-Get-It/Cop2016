using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace COP2001
{
    public partial class frmValidationCopyCriteria : RadForm
    {
        public string rdcValidationErrorsTable = "";
        private int ii_TableValidationID = 0;


        public frmValidationCopyCriteria()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void SetTableValidationMessageID()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            try
            {
                int ii_TableValidationMessageID = Convert.ToInt32(frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
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

        private void frmValidationCopyCriteria_Load(object sender, EventArgs e)
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            this.CenterToParent();


            try
            {
                SetTableValidationMessageID();

                //If frmTableValidationSetupCopy.rdcValidationErrors.Resultset!MessageType = "ERROR" Then
                RefreshErrorList();
                //Else
                RefreshWarningList();

                lblCopyFrom.Text = frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["Message"].ToString();
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

        private void CopyFromMeasureToMeasure()
        {
            string is_MeasureID = null;
            bool CopyStepandSetRecords = false;
            var cboMeasures = new RadDropDownList();
            var cboSet = new RadDropDownList();
            var cboStep = new RadDropDownList();
            string [] is_MeasureCriteriaIDs = null;
            var cboJoinOperator = new RadDropDownList();
            int InsertStepandSetRecords = 0;
            int li_SetID = 0;

            //On Error GoTo ErrHandler

            try
            {
                if (string.IsNullOrEmpty(is_MeasureID))
                {

                    if (cboStep.SelectedIndex < 0 | cboSet.SelectedIndex < 0 | cboMeasures.SelectedIndex < 0 |
                        (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                    {
                        RadMessageBox.Show("Define the definition of the new criteria.");
                    }
                    else
                    {
                        //copy the criteria
                        li_SetID = InsertStepandSetRecords;

                        if (li_SetID != -1)
                        {
                            modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteria (";
                            modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID, MultSelAny ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                            modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                            modGlobal.gv_sql = modGlobal.gv_sql + li_SetID + ", ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";

                            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "', MeasureFieldGroupLogicID, MultSelAny ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID in (" + Strings.Join(is_MeasureCriteriaIDs, ", ") + ")";

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                            this.Close();
                        }
                    }
                }
                else
                {
                    //LDW modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStep WHERE  " + " MeasureID = " +  cboMeasures.ItemData(cboMeasures.SelectedIndex);
                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStep WHERE  " + " MeasureID = " + Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_MeasureStep";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                    if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)
                    {
                        RadMessageBox.Show("Cannot duplicate! The destination measure has some criteria in the flowchart that has to be removed first.");
                    }
                    else
                    {
                        if (CopyStepandSetRecords)
                            this.Close();
                    }
                }

                return;
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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshWarningList()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();


            try
            {
                //retrieve the list of Validation Warning messages
                modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableid = {1}", modGlobal.gv_sql,
                    Support.GetItemData(frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and state = '" + modGlobal.gv_State + "'";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'WARNING' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
                //3.17.2005 = order by message


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_TableValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboError.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    cboError.Items.Add(new ListBoxItem((myRow2.Field<string>("Message")), myRow2.Field<int>("TableValidationMessageID")).ToString());
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

        private void RefreshErrorList()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();


            try
            {
                //retrieve the list of Validation Error messages
                modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableid = " + Support.GetItemData(frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex);

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and state = '" + modGlobal.gv_State + "'";
                }

                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'ERROR' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
                // 3.17.2005 - order by message

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_TableValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                cboError.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    cboError.Items.Add(new ListBoxItem((myRow3.Field<string>("Message")), myRow3.Field<int>("TableValidationMessageID")).ToString());
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
