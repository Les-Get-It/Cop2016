using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmSubmissionValidCritWizard : Telerik.WinControls.UI.RadForm
    {
        public string rdcValidationErrorsTable = "tbl_setup_submitValidation";
        public string rdcValidationWarningsTable = "tbl_setup_submitValidation";


        public frmSubmissionValidCritWizard()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboGroup1SumTable_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshGroup1Fields(Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex));
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

        private void cboGroup2Opt1SumTable_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshGroup2FieldsOpt1(Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex));
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

        private void cboGroup2Opt2SumTable_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshGroup2FieldsOpt2(Support.GetItemString(cboGroup2Opt2SumTable, cboGroup2Opt2SumTable.SelectedIndex));
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
            modGlobal.gv_Action = "Cancel";
            this.Close();
        }

        private void cmdDeleteFromGroup1_Click(object sender, EventArgs e)
        {
            var i = 0;

            try
            {
                if (lstGroup1SelectedFields.SelectedIndex < 0)
                {
                    return;
                }

                i = lstGroup1SelectedFields.SelectedIndex;
                lstGroup1SelectedFields.Items.RemoveAt((i));
                lstGroup1SelectedFieldsTable.Items.RemoveAt((i));

                if (lstGroup1SelectedFields.Items.Count <= 1)
                {
                    cboGroup1SumOp.Enabled = true;
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

        private void cmdDeleteFromGroup2Opt1_Click(object sender, EventArgs e)
        {
            var i = 0;


            try
            {
                if (lstGroup2Opt1SelectedFields.SelectedIndex < 0)
                {
                    return;
                }

                i = lstGroup2Opt1SelectedFields.SelectedIndex;
                lstGroup2Opt1SelectedFields.Items.RemoveAt((i));
                lstGroup2Opt1SelectedFieldsTable.Items.RemoveAt((i));

                if (lstGroup2Opt1SelectedFields.Items.Count <= 1)
                {
                    cboGroup2Opt1SumOp.Enabled = true;
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

        private void cmdDeleteFromGroup2Opt2_Click(object sender, EventArgs e)
        {
            var i = 0;

            try
            {
                if (lstGroup2Opt2SelectedFields.SelectedIndex < 0)
                {
                    return;
                }

                i = lstGroup2Opt2SelectedFields.SelectedIndex;
                lstGroup2Opt2SelectedFields.Items.RemoveAt((i));
                lstGroup2Opt2SelectedFieldsTable.Items.RemoveAt((i));

                if (lstGroup2Opt2SelectedFields.Items.Count <= 1)
                {
                    cboGroup2Opt2SumOp.Enabled = true;
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

        private void cmdGroup1AddField_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboGroup1SumTable.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a summary table.");
                    return;
                }
                if (cboGroup1Fields.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a field.");
                    return;
                }
                if (lstGroup1SelectedFields.Items.Count > 0)
                {
                    if (cboGroup1SumOp.SelectedIndex < 0)
                    {
                        RadMessageBox.Show("Please select the field summary operation (+ or -)");
                        return;
                    }

                    cboGroup1SumOp.Enabled = false;

                    lstGroup1SelectedFields.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) +
                        " (" + Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex) + " / " +
                        Support.GetItemString(cboGroup1Fields, cboGroup1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup1Fields, cboGroup1Fields.SelectedIndex)).ToString());
                }
                else
                {
                    lstGroup1SelectedFields.Items.Add(new ListBoxItem("(" + Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex) +
                        " / " + Support.GetItemString(cboGroup1Fields, cboGroup1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup1Fields, cboGroup1Fields.SelectedIndex)).ToString());
                }

                lstGroup1SelectedFieldsTable.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex),
                    Support.GetItemData(cboGroup1Fields, cboGroup1Fields.SelectedIndex)).ToString());
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

        private void cmdGroup2Opt1AddField_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboGroup2Opt1SumTable.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a summary table.");
                    return;
                }
                if (cboGroup2Opt1Fields.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a field.");
                    return;
                }
                if (lstGroup2Opt1SelectedFields.Items.Count > 0)
                {
                    if (cboGroup2Opt1SumOp.SelectedIndex < 0)
                    {
                        RadMessageBox.Show("Please select the field summary operation (+ or -)");
                        return;
                    }

                    cboGroup2Opt1SumOp.Enabled = false;

                    lstGroup2Opt1SelectedFields.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt1SumOp, cboGroup2Opt1SumOp.SelectedIndex) +
                        " (" + Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex) + "/" +
                        Support.GetItemString(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex)).ToString());
                }
                else
                {
                    lstGroup2Opt1SelectedFields.Items.Add(new ListBoxItem("(" + Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex) +
                        "/" + Support.GetItemString(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex)).ToString());
                }

                lstGroup2Opt1SelectedFieldsTable.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex),
                    Support.GetItemData(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex)).ToString());
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

        private void cmdGroup2Opt2AddField_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboGroup2Opt2SumTable.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a summary table.");
                    return;
                }
                if (cboGroup2Opt2Fields.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a field.");
                    return;
                }
                if (lstGroup2Opt2SelectedFields.Items.Count > 0)
                {
                    if (cboGroup2Opt2SumOp.SelectedIndex < 0)
                    {
                        RadMessageBox.Show("Please select the field summary operation (+ or -)");
                        return;
                    }

                    cboGroup2Opt2SumOp.Enabled = false;

                    lstGroup2Opt2SelectedFields.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt2SumOp, cboGroup2Opt2SumOp.SelectedIndex) +
                        " (" + Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt2SumTable.SelectedIndex) + "/" +
                        Support.GetItemString(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex)).ToString());
                }
                else
                {
                    lstGroup2Opt2SelectedFields.Items.Add(new ListBoxItem("(" + Support.GetItemString(cboGroup2Opt2SumTable, cboGroup2Opt2SumTable.SelectedIndex) +
                        "/" + Support.GetItemString(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex)).ToString());
                }

                lstGroup2Opt2SelectedFieldsTable.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt2SumTable, cboGroup2Opt2SumTable.SelectedIndex),
                    Support.GetItemData(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex)).ToString());
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

        private void cmdOpt1AddCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                if (sstabOptions1.Enabled == true)
                {
                    AddCriteriaWithMethod1();
                }
                else if (sstabOptions2.Enabled == true)
                {
                    AddCriteriaWithMethod2();
                }
                else if (sstabOptions3.Enabled == true)
                {
                    AddCriteriaWithMethod3();
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

        private void frmSubmissionValidCritWizard_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                sstabOptions.ActiveWindow = sstabOptions1;
                sstabOptions1.Enabled = false;
                sstabOptions2.Enabled = false;
                sstabOptions3.Enabled = false;
                Opt1Method.IsChecked = false;
                Opt2Method.IsChecked = false;
                Opt3Method.IsChecked = false;
                RefreshGroup1Fields("NotDefined");
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

        private void Opt1Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt1Method.IsChecked))
                {
                    if (Opt1Method.IsChecked == true)
                    {
                        sstabOptions1.Enabled = true;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = false;
                        sstabOptions.ActiveWindow = sstabOptions1;
                        fraSetup.Enabled = true;
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

        private void Opt2Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt2Method.IsChecked))
                {
                    if (Opt2Method.IsChecked == true)
                    {
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = true;
                        sstabOptions3.Enabled = false;
                        sstabOptions.ActiveWindow = sstabOptions2;
                        fraSetup.Enabled = true;
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

        private void Opt3Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt3Method.IsChecked))
                {
                    if (Opt3Method.IsChecked == true)
                    {
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = true;
                        sstabOptions.ActiveWindow = sstabOptions3;
                        fraSetup.Enabled = true;
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

        public void RefreshGroup1Fields(string SummaryTable)
        {
            try
            {
                switch (SummaryTable)
                {
                    case "PATIENT SUMMARY":
                        //gv_sql = "Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, "
                        //gv_sql = gv_sql & " tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname "
                        //gv_sql = gv_sql & " from tbl_Setup_SubmitSubGroup, tbl_Setup_SubmitGroupRow "
                        //gv_sql = gv_sql & " where tbl_Setup_SubmitSubGroup.GroupRowID =  tbl_Setup_SubmitGroupRow.GroupRowID "
                        //gv_sql = gv_sql & " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title "
                        modGlobal.gv_sql = " Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " dbo.tbl_Setup_SubmitGroup.GroupName + '/' + tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_SubmitSubGroup, tbl_setup_submitGroupRow, dbo.tbl_Setup_SubmitGroup ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "  Where tbl_Setup_SubmitSubGroup.GroupRowID = tbl_setup_submitGroupRow.GroupRowID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and dbo.tbl_Setup_SubmitGroup.GroupID = tbl_Setup_SubmitGroupRow.GroupID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title ";
                        break;

                    case "HOSPITAL STATISTICS":
                        modGlobal.gv_sql = "Select tbl_Setup_DataDef.DDID as FieldID, tbl_Setup_DataDef.FieldName ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_Setup_TableDef ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_TableDef.BaseTable = 'HOSPITAL STATISTICS' ";
                        if (string.IsNullOrEmpty(modGlobal.gv_State))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
                        }
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
                        break;

                    default:
                        modGlobal.gv_sql = "Select DDID as FieldID, FieldName ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef where BaseTableID = -1";
                        break;
                }

                //g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                cboGroup1Fields.Items.Clear();
                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)
                {
                    //Display the list of fields to cleanup
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                    {
                        cboGroup1Fields.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"), myRow1.Field<int>("fieldid")).ToString());
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    //LDW modGlobal.gv_rs.Close();
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

        public void RefreshGroup2FieldsOpt1(string SummaryTable)
        {
            try
            {
                switch (SummaryTable)
                {
                    case "PATIENT SUMMARY":
                        //gv_sql = "Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, "
                        //gv_sql = gv_sql & " tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname "
                        //gv_sql = gv_sql & " from tbl_Setup_SubmitSubGroup, tbl_Setup_SubmitGroupRow "
                        //gv_sql = gv_sql & " where tbl_Setup_SubmitSubGroup.GroupRowID =  tbl_Setup_SubmitGroupRow.GroupRowID "
                        //gv_sql = gv_sql & " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title "
                        modGlobal.gv_sql = " Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " dbo.tbl_Setup_SubmitGroup.GroupName + '/' + tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_SubmitSubGroup, tbl_setup_submitGroupRow, dbo.tbl_Setup_SubmitGroup ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "  Where tbl_Setup_SubmitSubGroup.GroupRowID = tbl_setup_submitGroupRow.GroupRowID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and dbo.tbl_Setup_SubmitGroup.GroupID = tbl_Setup_SubmitGroupRow.GroupID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title ";
                        break;


                    case "HOSPITAL STATISTICS":
                        modGlobal.gv_sql = "Select tbl_Setup_DataDef.DDID as FieldID, tbl_Setup_DataDef.FieldName ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_Setup_TableDef ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_TableDef.BaseTable = 'HOSPITAL STATISTICS' ";
                        if (string.IsNullOrEmpty(modGlobal.gv_State))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
                        }
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
                        break;

                    default:
                        modGlobal.gv_sql = "Select DDID as FieldID, FieldName ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef where BaseTableID = -1";
                        break;
                }

                //g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboGroup2Opt1Fields.Items.Clear();
                if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count > 0)
                {
                    //Display the list of fields to cleanup
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                    {
                        cboGroup2Opt1Fields.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("fieldid")).ToString());
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    //LDW modGlobal.gv_rs.Close();
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

        public void RefreshGroup2FieldsOpt2(string SummaryTable)
        {
            try
            {
                switch (SummaryTable)
                {
                    case "PATIENT SUMMARY":
                        //gv_sql = "Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, "
                        //gv_sql = gv_sql & " tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname "
                        //gv_sql = gv_sql & " from tbl_Setup_SubmitSubGroup, tbl_Setup_SubmitGroupRow "
                        //gv_sql = gv_sql & " where tbl_Setup_SubmitSubGroup.GroupRowID =  tbl_Setup_SubmitGroupRow.GroupRowID "
                        //gv_sql = gv_sql & " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title "
                        modGlobal.gv_sql = " Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " dbo.tbl_Setup_SubmitGroup.GroupName + '/' + tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_SubmitSubGroup, tbl_setup_submitGroupRow, dbo.tbl_Setup_SubmitGroup ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "  Where tbl_Setup_SubmitSubGroup.GroupRowID = tbl_setup_submitGroupRow.GroupRowID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and dbo.tbl_Setup_SubmitGroup.GroupID = tbl_Setup_SubmitGroupRow.GroupID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title ";
                        break;


                    case "HOSPITAL STATISTICS":
                        modGlobal.gv_sql = "Select tbl_Setup_DataDef.DDID as FieldID, tbl_Setup_DataDef.FieldName ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_Setup_TableDef ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_TableDef.BaseTable = 'HOSPITAL STATISTICS' ";
                        if (string.IsNullOrEmpty(modGlobal.gv_State))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
                        }
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
                        break;

                    default:
                        modGlobal.gv_sql = "Select DDID as FieldID, FieldName ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef where BaseTableID = -1";
                        break;
                }

                //g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                cboGroup2Opt2Fields.Items.Clear();
                if (modGlobal.gv_rs.Tables[sqlTableName3].Rows.Count > 0)
                {
                    //Display the list of fields to cleanup
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                    {
                        cboGroup2Opt2Fields.Items.Add(new ListBoxItem(myRow3.Field<string>("FieldName"), myRow3.Field<int>("fieldid")).ToString());
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    //LDW modGlobal.gv_rs.Close();
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

        public void AddCriteriaWithMethod1()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int NewValG2ID;
            int NewValG1ID;
            int NewSetID;
            int NewValSetID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSet", "SubmitValSetID");
            var i = 0;
            string Desc = null;


            try
            {
                if (lstGroup1SelectedFields.Items.Count <= 0)
                {
                    RadMessageBox.Show("You need to define at least one field in Group 1.");
                    return;
                }
                if (lstGroup2Opt1SelectedFields.Items.Count <= 0)
                {
                    RadMessageBox.Show("You need to define at least one field in Group 2.");
                    return;
                }
                if (cboOpt1FieldOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("You need to define the comparison operator between the 2 field groups.");
                    return;
                }

                //build the description of the criteria

                Desc = "";
                for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
                {

                    if (i == 0)
                    {

                        Desc = Desc + "(";
                    }


                    Desc = Desc + Support.GetItemString(lstGroup1SelectedFields, i);


                    if (i == lstGroup1SelectedFields.Items.Count - 1)
                    {

                        Desc = Desc + ")";
                    }
                }


                Desc = string.Format("{0} {1}", Desc, Support.GetItemString(cboOpt1FieldOp, cboOpt1FieldOp.SelectedIndex));

                for (i = 0; i <= lstGroup2Opt1SelectedFields.Items.Count - 1; i++)
                {

                    if (i == 0)
                    {

                        Desc = Desc + "(";
                    }


                    Desc = Desc + Support.GetItemString(lstGroup2Opt1SelectedFields, i);


                    if (i == lstGroup2Opt1SelectedFields.Items.Count - 1)
                    {

                        Desc = Desc + ")";
                    }
                }

                //add the set
                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetID, SubmitValID, Description, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Group1Op, Group2Op, GroupsOp, Value, ValueOperator) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                modGlobal.gv_sql = modGlobal.gv_sql + NewValSetID + ", ";

                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"] + ", ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"] + ", ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Desc + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup2Opt1SumOp, cboGroup2Opt1SumOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt1FieldOp, cboOpt1FieldOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " Null, Null) ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Select max(SubmitValSetID) as newSetID from tbl_Setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_Setup_SubmitValSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                NewSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["NewSetID"]);

                //add fields of group 1
                for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
                {
                    NewValG1ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup1", "SubmitValSetG1ID");

                    modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG1ID, SubmitValSetID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewValG1ID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup1SelectedFields, i) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup1SelectedFieldsTable, i) + "') ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                //add fields of group 2
                for (i = 0; i <= lstGroup2Opt1SelectedFields.Items.Count - 1; i++)
                {
                    NewValG2ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup2", "SubmitValSetG2ID");

                    modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup2 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG2ID, SubmitValSetID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewValG2ID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup2Opt1SelectedFields, i) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup2Opt1SelectedFieldsTable, i) + "') ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }

                //update join operator if any
                if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
                {
                    modGlobal.gv_sql = "Update tbl_Setup_SubmitValidation ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + modGlobal.gv_ANDOR + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

                    if (modGlobal.gv_Action == "ERROR")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    }
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                modGlobal.gv_Action = "Add";
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

        public void AddCriteriaWithMethod2()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int NewValG2ID;
            int NewValG1ID;
            int NewSetID;
            int NewValSetID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSet", "SubmitValSetID");
            var i = 0;
            string Desc = null;

            try
            {
                if (lstGroup1SelectedFields.Items.Count <= 0)
                {
                    RadMessageBox.Show("You need to define at least one field in Group 1.");
                    return;
                }
                if (lstGroup2Opt2SelectedFields.Items.Count <= 0)
                {
                    RadMessageBox.Show("You need to define at least one field in Group 2.");
                    return;
                }
                if (cboOpt2FieldOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("You need to define the comparison operator between the 2 field groups.");
                    return;
                }
                if (cboOpt2ValueOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("You need to define the Result operator. ");
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt2Value.Text))
                {
                    RadMessageBox.Show("You need to define Result value.");
                    return;
                }

                //build the description of the criteria

                Desc = "";
                for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
                {

                    if (i == 0)
                    {

                        Desc = Desc + "(";
                    }


                    Desc = Desc + Support.GetItemString(lstGroup1SelectedFields, i);


                    if (i == lstGroup1SelectedFields.Items.Count - 1)
                    {

                        Desc = Desc + ")";
                    }
                }


                Desc = string.Format("{0} {1}", Desc, Support.GetItemString(cboOpt2FieldOp, cboOpt2FieldOp.SelectedIndex));

                for (i = 0; i <= lstGroup2Opt2SelectedFields.Items.Count - 1; i++)
                {

                    if (i == 0)
                    {

                        Desc = Desc + "(";
                    }


                    Desc = Desc + Support.GetItemString(lstGroup2Opt2SelectedFields, i);


                    if (i == lstGroup2Opt2SelectedFields.Items.Count - 1)
                    {

                        Desc = Desc + ")";
                    }
                }


                Desc = string.Format("{0} {1} {2}", Desc, Support.GetItemString(cboOpt2ValueOp, cboOpt2ValueOp.SelectedIndex), txtOpt2Value.Text);


                //add the set
                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetID, SubmitValID, Description, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Group1Op, Group2Op, GroupsOp, ValueOperator, Value) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                modGlobal.gv_sql = modGlobal.gv_sql + NewValSetID + ", ";

                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"] + ", ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"] + ", ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Desc + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup2Opt1SumOp, cboGroup2Opt2SumOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt2FieldOp, cboOpt2FieldOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt2ValueOp, cboOpt2ValueOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt2Value.Text + "')";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Select max(SubmitValSetID) as newSetID from tbl_Setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_Setup_SubmitValSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                NewSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["NewSetID"]);

                //add fields of group 1
                for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
                {
                    NewValG1ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup1", "SubmitValSetG1ID");

                    modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG1ID, SubmitValSetID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewValG1ID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup1SelectedFields, i) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup1SelectedFieldsTable, i) + "') ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }

                //add fields of group 2
                for (i = 0; i <= lstGroup2Opt2SelectedFields.Items.Count - 1; i++)
                {
                    NewValG2ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup2", "SubmitValSetG2ID");

                    modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup2 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG2ID, SubmitValSetID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewValG2ID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup2Opt2SelectedFields, i) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup2Opt2SelectedFieldsTable, i) + "') ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                //update join operator if any
                if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
                {
                    modGlobal.gv_sql = "Update tbl_Setup_SubmitValidation ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + modGlobal.gv_ANDOR + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

                    if (modGlobal.gv_Action == "ERROR")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    }
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }


                modGlobal.gv_Action = "Add";
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

        public void AddCriteriaWithMethod3()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int NewValG1ID;
            int NewSetID;
            int NewValSetID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSet", "SubmitValSetID");
            var i = 0;
            string Desc = null;


            try
            {
                if (cboOpt3ValueOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("You need to define the Result operator. ");
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt3Value.Text))
                {
                    RadMessageBox.Show("You need to define Result value.");
                    return;
                }

                //build the description of the criteria

                Desc = "";
                for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
                {

                    if (i == 0)
                    {

                        Desc = Desc + "(";
                    }


                    Desc = Desc + Support.GetItemString(lstGroup1SelectedFields, i);


                    if (i == lstGroup1SelectedFields.Items.Count - 1)
                    {

                        Desc = Desc + ")";
                    }
                }


                Desc = Desc + " " + Support.GetItemString(cboOpt3ValueOp, cboOpt3ValueOp.SelectedIndex) + " " + txtOpt3Value.Text;

                //add the set
                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetID, SubmitValID, Description, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Group1Op, Group2Op, GroupsOp,  ValueOperator, Value) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                modGlobal.gv_sql = modGlobal.gv_sql + NewValSetID + ", ";

                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"] + ", ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"] + ", ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Desc + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt3ValueOp, cboOpt3ValueOp.SelectedIndex) + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3Value.Text + "')";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Select max(SubmitValSetID) as newSetID from tbl_Setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_Setup_SubmitValSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                NewSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["NewSetID"]);

                //add fields of group 1
                for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
                {
                    NewValG1ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup1", "SubmitValSetG1ID");

                    modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG1ID, SubmitValSetID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewValG1ID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup1SelectedFields, i) + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup1SelectedFieldsTable, i) + "') ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                //update join operator if any
                if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
                {
                    modGlobal.gv_sql = "Update tbl_Setup_SubmitValidation ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + modGlobal.gv_ANDOR + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

                    if (modGlobal.gv_Action == "ERROR")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["submitvalid"];
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["submitvalid"];
                    }
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }


                modGlobal.gv_Action = "Add";
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
    }
}
