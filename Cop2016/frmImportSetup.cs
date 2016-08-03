using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Telerik.WinControls.UI;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.CompilerServices;
using static COP2001.RadDropBinder;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmImportSetup : RadForm
    {
        public DataSet rdcImportValError = new DataSet();
        public string rdcImportValErrorTable = null;
        public DataSet rdcImportValWarning = new DataSet();
        public string rdcImportValWarningTable = null;
        public DataSet dtHelp = new DataSet();
        public string dtHelpTable = null;
        readonly StaticLocalInitFlag static_sstabValidation_SelectedIndexChanged_PreviousTab_Init = new StaticLocalInitFlag();
        int static_sstabValidation_SelectedIndexChanged_PreviousTab;


        public frmImportSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboLookupList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            txtCriteria.Text = "";
            OptCritLKUp.IsChecked = true;
        }

        private void cboLookupValues_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            optCritValue.IsChecked = true;
        }

        private void cmdAddError_Click(object sender, EventArgs e)
        {
            frmImportAddValidField frmImportAddValidFieldCopy = new frmImportAddValidField();

            try
            {
                txtAction.Text = "Add Error";
                frmImportAddValidFieldCopy.cmdAdd.Text = "Add Error Message";
                frmImportAddValidFieldCopy.ShowDialog();
                RefreshErrorMessages();
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
            //LDW rdcImportValError.Resultset.MoveLast();
        }

        private void cmdAddField_Click(object sender, EventArgs e)
        {
            int newid;
            int NextOrderID;

            try
            {

                if (lstAvailableFields.SelectedIndex > -1)
                {
                    NextOrderID = GetNextFieldOrderID();
                    newid = modDBSetup.FindMaxRecID("tbl_Setup_ImportFields", "ImportFieldID");

                    modGlobal.gv_sql = "Insert into tbl_Setup_ImportFields (Importfieldid, importsetupid, DDID, OrderNumber)";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values(" + newid + "," + modGlobal.gv_importsetupid + "," +
                        Support.GetItemData(lstAvailableFields, lstAvailableFields.SelectedIndex) + ",";
                    modGlobal.gv_sql = modGlobal.gv_sql + NextOrderID;
                    modGlobal.gv_sql = modGlobal.gv_sql + ")";

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshSelectedFields();
                    RefreshAvailableFields();
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

        private void cmdAddWarning_Click(object sender, EventArgs e)
        {
            frmImportAddValidField frmImportAddValidFieldCopy = new frmImportAddValidField();

            try
            {
                txtAction.Text = "Add Warning";
                frmImportAddValidFieldCopy.cmdAdd.Text = "Add Warning";
                frmImportAddValidFieldCopy.ShowDialog();
                RefreshWarningMessages();
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
            //LDW rdcImportValWarning.Resultset.MoveLast();
        }

        private void cmdAnd_Click(object sender, EventArgs e)
        {
            int msgid = 0;

            try
            {

                //LDW if (sstabValidation.ActiveWindow == sstabValidationErrors)
                if (sstabValidation.ActiveWindow == sstabValidationErrors)
                {
                    msgid = Convert.ToInt32(rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                }
                else
                {
                    msgid = Convert.ToInt32(rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                }

                //update the join operator in the report definition table
                modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set joinOperator = 'AND' ";
                modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, msgid);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                if (sstabValidation.ActiveWindow == sstabValidationErrors)
                {
                    //rdcImportValError.Resultset.Requery
                    RefreshECriteriaList();
                }
                else
                {
                    //rdcImportValWarning.Resultset.Requery
                    RefreshWCriteriaList();
                }

                RefreshCriteriaButtons();
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

        private void cmdChangeToError_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcImportValWarning.Tables[rdcImportValWarningTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Warning to an Error?",
                    "Change status", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_importValidationMessage ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set ValidationType = 'ERROR' ";
                    modGlobal.gv_sql = string.Format("{0} Where MsgID = {1}", modGlobal.gv_sql, rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshErrorMessages();
                    RefreshWarningMessages();
                    RefreshCriteriaButtons();
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

        private void cmdChangetoWarning_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdcImportValError.Tables[rdcImportValErrorTable].Rows.Count <= 0)
                {
                    return;
                }

                modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Error to a Warning?",
                    "Change Status", MessageBoxButtons.YesNo, RadMessageIcon.Question));
                if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
                {
                    modGlobal.gv_sql = "update tbl_setup_importValidationMessage ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set ValidationType = 'WARNING' ";
                    modGlobal.gv_sql = string.Format("{0} Where MsgID = {1}", modGlobal.gv_sql, rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshErrorMessages();
                    RefreshWarningMessages();
                    RefreshCriteriaButtons();
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

        private void cmdCopyValidation_Click(object sender, EventArgs e)
        {
            frmImportCopyValidation frmImportCopyValidationCopy = new frmImportCopyValidation();

            frmImportCopyValidationCopy.ShowDialog();

            try
            {
                RefreshErrorMessages();
                RefreshWarningMessages();
                RefreshCriteriaButtons();
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

        private void cmdEditError_Click(object sender, EventArgs e)
        {
            frmImportAddValidField frmImportAddValidFieldCopy = new frmImportAddValidField();

            try
            {
                txtAction.Text = "Edit Error";
                frmImportAddValidFieldCopy.cmdAdd.Text = "Update Error";
                frmImportAddValidFieldCopy.Show();
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

        private void cmdEditWarning_Click(object sender, EventArgs e)
        {
            frmImportAddValidField frmImportAddValidFieldCopy = new frmImportAddValidField();

            try
            {
                txtAction.Text = "Edit Warning";
                frmImportAddValidFieldCopy.cmdAdd.Text = "Update Warning";
                frmImportAddValidFieldCopy.Show();
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

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            string msg = null;
            string lkvalue = null;
            RadListControl lstFieldListForCriteria = new RadListControl();

            try
            {

                if (lstFieldListForCriteria.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select DDID, LookupTableID, help, FieldType from tbl_Setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, lstFieldListForCriteria.SelectedValue);

                /*LDW Replaced this section with a dataset
                DAO.Workspace wrkODBC = null;
                DAO.Connection conpubs = null;
                //Dim dtHelp As Data
                wrkODBC = DAODBEngine_definst.CreateWorkspace("NewODBCWorkspace", "", "", DAO.WorkspaceTypeEnum.dbUseODBC);
                conpubs = wrkODBC.OpenConnection("Connection1", , , "ODBC;DATABASE=COP2001;UID=sa;PWD=;DSN=COP2001"); 
                dtHelp.Recordset = conpubs.OpenRecordset(modGlobal.gv_sql, 2);*/
                dtHelpTable = "tbl_Setup_DataDef";
                dtHelp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, dtHelpTable, dtHelp);

                DataSet lkrs = new DataSet();

                if (!Information.IsDBNull(dtHelp.Tables[dtHelpTable].Rows[0]["LookupTableID"]))
                {
                    modGlobal.gv_sql = "Select * from tbl_Setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, dtHelp.Tables[dtHelpTable].Rows[0]["LookupTableID"]);
                    //LDW lkrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_misclookuplist";
                    lkrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, lkrs);
                    lkvalue = "";

                    //LDW while (!lkrs.EOF)
                    foreach (DataRow myRow1 in lkrs.Tables[sqlTableName1].Rows)
                    {
                        if (string.IsNullOrEmpty(lkvalue))
                        {
                            lkvalue = string.Format("{0}. {1}", myRow1.Field<int>("Id"), myRow1.Field<int>("FIELDVALUE"));
                        }
                        else
                        {
                            lkvalue = string.Format("{0}{1}{2}{3}. {4}", lkvalue, Strings.Chr(13), Strings.Chr(10), myRow1.Field<int>("Id"), myRow1.Field<int>("FIELDVALUE"));
                        }
                        //LDW lkrs.MoveNext();
                    }
                }

                msg = "";

                if ((string.IsNullOrEmpty(dtHelp.Tables[dtHelpTable].Rows[0]["help"].ToString()) |
                    Information.IsDBNull(dtHelp.Tables[dtHelpTable].Rows[0]["help"])) & string.IsNullOrEmpty(lkvalue))
                {
                    RadMessageBox.Show("Field Type: " + dtHelp.Tables[dtHelpTable].Rows[0]["FieldType"]);
                }
                else
                {
                    if (!Information.IsDBNull(dtHelp.Tables[dtHelpTable].Rows[0]["help"]))
                    {
                        msg = dtHelp.Tables[dtHelpTable].Rows[0]["help"].ToString();
                    }
                    if (!string.IsNullOrEmpty(lkvalue))
                    {
                        if (string.IsNullOrEmpty(msg))
                        {
                            msg = string.Format("Valid values: {0}{1}{2}", Strings.Chr(10), Strings.Chr(13), lkvalue);
                        }
                        else
                        {
                            msg = string.Format("{0}{1}{2}Valid values: {3}{4}{5}", msg, Strings.Chr(10), Strings.Chr(13), Strings.Chr(10), Strings.Chr(13), lkvalue);
                        }
                    }
                    RadMessageBox.Show(msg);
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

            //LDW conpubs.Close();
        }

        private void cmdMoveToAbsPosition_Click(object sender, EventArgs e)
        {
            int CurrentOrderNumber = 0;
            int NewPos = 0;
            int TotalFields = 0;

            try
            {

                if (lstSelectedFields.SelectedIndex > -1)
                {
                    //TotalFields = lstSelectedFields.ItemData(lstSelectedFields.ListIndex)
                    TotalFields = lstSelectedFields.Items.Count + 1;

                    NewPos = Convert.ToInt16(RadInputBox.Show("Type in the order number for this field (should be between 2 and " + TotalFields + ")",
                        "Move Field Position", Convert.ToString(1)));
                    if (!Information.IsNumeric(NewPos))
                    {
                        RadMessageBox.Show("Numeric values only.");
                        return;
                    }
                    if (Convert.ToInt16(NewPos) < 2 | Convert.ToInt16(NewPos) > TotalFields)
                    {
                        RadMessageBox.Show("Invalid position.");
                        return;
                    }

                    modGlobal.gv_sql = "Select OrderNumber from tbl_Setup_ImportFields ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_Setup_ImportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["OrderNumber"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        CurrentOrderNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["OrderNumber"]);

                        //if moving the field down
                        if (NewPos > CurrentOrderNumber)
                        {
                            //update all orders before the value to - 1, except the value >= currentordernumber
                            modGlobal.gv_sql = "UPDATE tbl_setup_ImportFields SET OrderNumber = OrderNumber - 1";
                            modGlobal.gv_sql = string.Format("{0} WHERE ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                            modGlobal.gv_sql = string.Format("{0} AND OrderNumber > {1} AND OrderNumber <= {2}", modGlobal.gv_sql, CurrentOrderNumber, NewPos);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //if moving the field up
                        }
                        else if (NewPos < CurrentOrderNumber)
                        {
                            //update all orders after the value to + 1, except the value >= currentordernumber
                            modGlobal.gv_sql = "UPDATE tbl_setup_ImportFields SET OrderNumber = OrderNumber + 1";
                            modGlobal.gv_sql = string.Format("{0} WHERE ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                            modGlobal.gv_sql = string.Format("{0} AND OrderNumber >= {1} AND OrderNumber < {2}", modGlobal.gv_sql, NewPos, CurrentOrderNumber);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }


                        //set to the new order number
                        modGlobal.gv_sql = "UPDATE tbl_setup_ImportFields SET OrderNumber = " + NewPos;
                        modGlobal.gv_sql = string.Format("{0} WHERE ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                        modGlobal.gv_sql = string.Format("{0} AND DDID = {1}", modGlobal.gv_sql,
                            Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    RefreshSelectedFields();
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

        private void cmdMoveFieldDown_Click(object sender, EventArgs e)
        {
            string CurrentField = null;
            int CurrentOrderNumber;
            DataSet thisrs = new DataSet();

            try
            {

                if (lstSelectedFields.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select OrderNumber from tbl_Setup_ImportFields ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName3 = "tbl_Setup_ImportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["OrderNumber"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        CurrentOrderNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["OrderNumber"]);
                        modGlobal.gv_sql = "select *  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_ImportFields ";
                        modGlobal.gv_sql = string.Format("{0} where OrderNumber > {1}", modGlobal.gv_sql, CurrentOrderNumber);
                        modGlobal.gv_sql = string.Format("{0} and ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                        modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ORDERNUMBER";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName4 = "tbl_setup_ImportFields";
                        if (modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count > 0)
                        {
                            modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
                            modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, CurrentOrderNumber);
                            modGlobal.gv_sql = modGlobal.gv_sql + " where OrderNumber = " + CurrentOrderNumber + 1;
                            modGlobal.gv_sql = string.Format("{0} and ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + CurrentOrderNumber + 1;
                            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " +
                                Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex);
                            modGlobal.gv_sql = string.Format("{0} and ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //set focus on the same field after refresh
                            modGlobal.gv_sql = "select tbl_setup_ImportFields.*, tbl_Setup_DataDef.Fieldname ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_setup_ImportFields ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportFields.OrderNumber = " + CurrentOrderNumber + 1;
                            modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.ImportSetupID = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);

                            //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName5 = "tbl_Setup_DataDef";
                            thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, thisrs);

                            //MsgBox CurrentField
                            RefreshSelectedFields();

                            CurrentField = string.Format("{0}. {1}", thisrs.Tables[sqlTableName5].Rows[0]["OrderNumber"], thisrs.Tables[sqlTableName5].Rows[0]["FieldName"]);

                            lstSelectedFields.Text = CurrentField;
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

        private void cmdMoveFieldup_Click(object sender, EventArgs e)
        {
            string CurrentField = null;
            int CurrentOrderNumber;
            DataSet thisrs = new DataSet();

            try
            {

                if (lstSelectedFields.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select OrderNumber from tbl_Setup_ImportFields ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                    modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ORDERNUMBER";

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_Setup_ImportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]))
                    {
                        //reorganize the fields
                    }
                    else
                    {
                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]) > 1)
                        {
                            CurrentOrderNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["OrderNumber"]);
                            //update the field that is one order higher than this one
                            modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
                            modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, CurrentOrderNumber);
                            modGlobal.gv_sql = string.Format("{0} where OrderNumber = {1}", modGlobal.gv_sql, CurrentOrderNumber - 1);
                            modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //update this field
                            modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
                            modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, CurrentOrderNumber - 1);
                            modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql,
                                Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex));
                            modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            modGlobal.gv_sql = "select tbl_setup_ImportFields.*, tbl_Setup_DataDef.Fieldname ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_setup_ImportFields ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
                            modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.OrderNumber = {1}", modGlobal.gv_sql, CurrentOrderNumber - 1);
                            modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ORDERNUMBER";
                            //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName8 = "tbl_Setup_DataDef";
                            thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, thisrs);

                            //MsgBox CurrentField
                            RefreshSelectedFields();
                            //set focus on the same field after refresh
                            CurrentField = string.Format("{0}. {1}", thisrs.Tables[sqlTableName8].Rows[0]["OrderNumber"], thisrs.Tables[sqlTableName8].Rows[0]["FieldName"]);

                            lstSelectedFields.Text = CurrentField;
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

        public void RefreshTableList()
        {
            var LIndex = 0;
            int this_ListIndex = -1;
            //LDW object cboTableList = null;
            RadDropDownList cboTableList = new RadDropDownList();
            List<Item> itemscboTableList = new List<Item>();

            try
            {

                //retrieve the list of tables
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tabletype <> 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                cboTableList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;

                    itemscboTableList.Add(new Item(myRow4.Field<int>("basetableid"), myRow4.Field<string>("BaseTable")));

                    //cboTableList.Items.Add(new ListBoxItem(myRow4.Field<string>("BaseTable"), myRow4.Field<int>("basetableid")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                cboTableList.DataSource = itemscboTableList;
                cboTableList.DisplayMember = "Description";
                cboTableList.ValueMember = "Id";
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

        public void RefreshSelectedFields()
        {
            int OrderNumber = 1;
            List<Item> itemslstSelectedFields = new List<Item>();
            List<Item> itemslstImportFields = new List<Item>();

            try
            {

                //remove any field that was not deleted from this list when it was deleted from the data definition
                modGlobal.gv_sql = "delete tbl_setup_ImportFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + "where ddid not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select ddid from  tbl_setup_DataDef";
                modGlobal.gv_sql = modGlobal.gv_sql + ") ";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //    ' add dicharge date if it doesn't exist or update its order number to be the first one
                //    gv_sql = "select tbl_setup_DataDef.* , tbl_setup_ImportFields.OrderNumber  "
                //    gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_ImportFields  "
                //    gv_sql = gv_sql & " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID "
                //    gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
                //    gv_sql = gv_sql & " and tbl_setup_ImportFields.importsetupid = " & gv_importsetupid
                //
                //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //    If gv_rs.RowCount = 0 Then
                //        'add discharge date
                //        gv_sql = "select tbl_setup_DataDef.DDID "
                //        gv_sql = gv_sql & " from tbl_setup_DataDef "
                //        gv_sql = gv_sql & " where "
                //        gv_sql = gv_sql & " tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
                //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //        If gv_rs.RowCount > 0 Then
                //            DischDDID = gv_rs!DDID
                //            OrderNumber = 2
                //            newid = FindMaxRecID("tbl_Setup_ImportFields", "ImportFieldID")
                //            gv_sql = "Insert into tbl_Setup_ImportFields(importfieldid, importsetupid, DDID, OrderNumber) "
                //            gv_sql = gv_sql & " values (" & newid & "," & gv_importsetupid & "," & DischDDID & "," & OrderNumber
                //            gv_sql = gv_sql & ")"
                //            gv_cn.Execute gv_sql
                //        End If
                //    End If

                modGlobal.gv_sql = "Select * from tbl_Setup_ImportFields ";
                modGlobal.gv_sql = string.Format("{0} where tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderNumber ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_Setup_ImportFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                {
                    OrderNumber = OrderNumber + 1;
                    modGlobal.gv_sql = "update tbl_Setup_ImportFields ";
                    modGlobal.gv_sql = string.Format("{0} set OrderNumber = {1}", modGlobal.gv_sql, OrderNumber);
                    modGlobal.gv_sql = string.Format("{0} Where importfieldid = {1}", modGlobal.gv_sql, myRow10.Field<int>("ImportFieldID"));
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //refresh the list
                lstSelectedFields.Items.Clear();
                lstImportFields.Items.Clear();

                modGlobal.gv_sql = "select tbl_setup_DataDef.* , tbl_setup_ImportFields.OrderNumber  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportFields  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_ImportFields.OrderNumber ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                {
                    itemslstSelectedFields.Add(new Item(myRow11.Field<int>("DDID"), myRow11.Field<int>("OrderNumber") + ". " + myRow11.Field<string>("FieldName")));
                    itemslstImportFields.Add(new Item(myRow11.Field<int>("DDID"), myRow11.Field<int>("OrderNumber") + ". " + myRow11.Field<string>("FieldName")));

                    //lstSelectedFields.Items.Add(new ListBoxItem(myRow11.Field<int>("OrderNumber") + ". " + myRow11.Field<string>("FieldName"), myRow11.Field<int>("DDID")).ToString());
                    //lstImportFields.Items.Add(new ListBoxItem(myRow11.Field<int>("OrderNumber") +   ". " + myRow11.Field<string>("FieldName"), myRow11.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstSelectedFields.DataSource = itemslstSelectedFields;
                this.lstSelectedFields.DisplayMember = "Description";
                this.lstSelectedFields.ValueMember = "Id";

                this.lstImportFields.DataSource = itemslstImportFields;
                this.lstImportFields.DisplayMember = "Description";
                this.lstImportFields.ValueMember = "Id";
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

        public void RefreshAvailableFields()
        {
            List<Item> itemslstAvailableFields = new List<Item>();


            try
            {
                lstAvailableFields.Items.Clear();

                modGlobal.gv_sql = "select tbl_setup_DataDef.*   ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_tabledef  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.BaseTableID = tbl_setup_tabledef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_tabledef.BaseTable = 'PATIENT' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_datadef.DDID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select DDID from tbl_setup_importFields ";
                modGlobal.gv_sql = string.Format("{0} where tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')",
                        modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                {
                    itemslstAvailableFields.Add(new Item(myRow12.Field<int>("DDID"), myRow12.Field<string>("FieldName")));

                    //lstAvailableFields.Items.Add(new ListBoxItem(myRow12.Field<string>("FieldName"), myRow12.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstAvailableFields.DataSource = itemslstAvailableFields;
                this.lstAvailableFields.DisplayMember = "Description";
                this.lstAvailableFields.ValueMember = "Id";
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

        private void cmdOr_Click(object sender, EventArgs e)
        {
            int msgid = 0;


            try
            {
                if (sstabValidation.ActiveWindow == sstabValidationErrors)
                {
                    msgid = Convert.ToInt32(rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                }
                else
                {
                    msgid = Convert.ToInt32(rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                }

                //update the join operator in the report definition table
                modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set joinOperator = 'OR' ";
                modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, msgid);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                if (sstabValidation.ActiveWindow == sstabValidationErrors)
                {
                    //rdcImportValError.Resultset.Requery
                    RefreshECriteriaList();
                }
                else
                {
                    //rdcImportValWarning.Resultset.Requery
                    RefreshWCriteriaList();
                }

                RefreshCriteriaButtons();
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

        private void cmdRemoveCriteria_Click(object sender, EventArgs e)
        {
            bool RemoveJoinOperator = false;

            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to remove this criteria?", "Remove Validation Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question);


                if (lstCriteria.SelectedIndex < 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_setup_importvalidation ";
                modGlobal.gv_sql = string.Format("{0} where ValidID = {1}", modGlobal.gv_sql, Support.GetItemData(lstCriteria, lstCriteria.SelectedIndex));
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //remove the join operator if only one criteria is left
                modGlobal.gv_sql = "Select * from tbl_setup_importvalidation ";
                modGlobal.gv_sql = string.Format("{0} where msgid = {1}", modGlobal.gv_sql, rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_importvalidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count == 0)
                {
                    RemoveJoinOperator = true;
                }
                else
                {
                    //LDW modGlobal.gv_rs.MoveLast();
                    if (modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count == 1)
                    {
                        RemoveJoinOperator = true;
                    }
                }
                modGlobal.gv_rs.Dispose();

                if (RemoveJoinOperator == true)
                {
                    modGlobal.gv_sql = "Update tbl_setup_importvalidationMessage ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = null ";
                    modGlobal.gv_sql = string.Format("{0} where msgID = {1}", modGlobal.gv_sql, rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                RefreshECriteriaList();
                RefreshCriteriaButtons();
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

        private void cmdRemoveError_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to remove this error message?", "Remove Error Validation", MessageBoxButtons.YesNo, RadMessageIcon.Question);


                if (rdcImportValError.Tables[rdcImportValErrorTable].Rows.Count <= 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_setup_importvalidation ";
                modGlobal.gv_sql = string.Format("{0} where msgid = {1}", modGlobal.gv_sql, rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_importvalidationMessage ";
                modGlobal.gv_sql = string.Format("{0} where msgid = {1}", modGlobal.gv_sql, rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshErrorMessages();
                RefreshECriteriaList();
                RefreshCriteriaButtons();
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

        private void cmdRemoveField_Click(object sender, EventArgs e)
        {
            int CurrentFieldOrder;
            DialogResult resp;

            try
            {

                if (lstSelectedFields.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = " select tbl_setup_ImportFields.DDID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportFields  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' ";
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderNumber ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName15 = "tbl_setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                    resp = RadMessageBox.Show("Are you sure you want to remove this field from the list.", "Remove Field", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (resp == DialogResult.No)
                    {
                        return;
                    }

                    //keep the order of this field for reorganizing purposes'
                    modGlobal.gv_sql = "Select OrderNumber from  tbl_Setup_ImportFields ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSelectedFields, lstSelectedFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName16 = "tbl_Setup_ImportFields";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                    CurrentFieldOrder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName16].Rows[0]["OrderNumber"]);

                    //now delete the field
                    modGlobal.gv_sql = "Delete tbl_Setup_importFields ";
                    modGlobal.gv_sql = string.Format("{0} where OrderNumber = {1}", modGlobal.gv_sql, CurrentFieldOrder);
                    modGlobal.gv_sql = string.Format("{0} and importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);



                    //reorganize the field order
                    modGlobal.gv_sql = "UPDATE tbl_Setup_importFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SET OrderNumber = OrderNumber - 1";
                    modGlobal.gv_sql = string.Format("{0} WHERE importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                    modGlobal.gv_sql = string.Format("{0} AND OrderNumber > {1}", modGlobal.gv_sql, CurrentFieldOrder);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    //        'reorganize the field order
                    //        gv_sql = "Select * from  tbl_Setup_ImportFields "
                    //        gv_sql = gv_sql & " where OrderNumber > " & CurrentFieldOrder
                    //        gv_sql = gv_sql & " and importsetupid = " & gv_importsetupid
                    //
                    //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                    //
                    //        While Not gv_rs.EOF
                    //            gv_sql = "update tbl_Setup_importFields "
                    //            gv_sql = gv_sql & " set OrderNumber = " & CurrentFieldOrder
                    //            gv_sql = gv_sql & " where DDID = " & gv_rs!DDID
                    //            gv_sql = gv_sql & " and importsetupid = " & gv_importsetupid
                    //
                    //            gv_cn.Execute gv_sql
                    //
                    //            CurrentFieldOrder = CurrentFieldOrder + 1
                    //            gv_rs.MoveNext
                    //        Wend


                    RefreshSelectedFields();
                    RefreshAvailableFields();
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

        private void cmdRemoveWarning_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to remove this warning message?",
                    "Remove Warning Validation", MessageBoxButtons.YesNo, RadMessageIcon.Question);


                if (rdcImportValWarning.Tables[rdcImportValWarningTable].Rows.Count <= 0)
                {
                    return;
                }
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "Delete tbl_setup_Importvalidation ";
                modGlobal.gv_sql = string.Format("{0} where msgid = {1}", modGlobal.gv_sql, rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_importvalidationMessage ";
                modGlobal.gv_sql = string.Format("{0} where msgid = {1}", modGlobal.gv_sql, rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshWarningMessages();
                RefreshWCriteriaList();
                RefreshCriteriaButtons();
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

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            int NewValidID;
            int thislookupvalue = 0;
            string FieldName = null;
            string FieldType = null;
            int msgid = 0;

            try
            {

                if (sstabValidation.ActiveWindow == sstabValidationErrors)
                {
                    for (int i = 0; i < rdcImportValError.Tables[rdcImportValErrorTable].Rows.Count; i++)
                    {
                        DataRow dRow3 = rdcImportValError.Tables[rdcImportValErrorTable].Rows[i];
                        int rowIndex = rdcImportValError.Tables[rdcImportValErrorTable].Rows.IndexOf(dRow3);

                        if (rowIndex > 0)
                        {
                            RadMessageBox.Show("Please select an error validation.");
                            return;
                        }
                    }
                    msgid = Convert.ToInt32(rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                }
                else
                {
                    for (int i = 0; i < rdcImportValError.Tables[rdcImportValErrorTable].Rows.Count; i++)
                    {
                        DataRow dRow4 = rdcImportValError.Tables[rdcImportValErrorTable].Rows[i];
                        int rowIndex = rdcImportValError.Tables[rdcImportValErrorTable].Rows.IndexOf(dRow4);
                        if (rowIndex > 0)
                        {
                            RadMessageBox.Show("Please select an error validation.");
                            return;
                        }
                    }
                    msgid = Convert.ToInt32(rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                }


                if (lstImportFields.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a field for criteria.");
                    return;
                }


                modGlobal.gv_sql = "Select FieldType, FieldName from tbl_setup_datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "tbl_setup_datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);
                FieldType = modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["FieldType"].ToString();
                FieldName = modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["FieldName"].ToString();

                if (optCritValue.IsChecked == true)
                {
                    if (string.IsNullOrEmpty(txtCriteria.Text) & cboLookupValues.SelectedIndex < 0)
                    {
                        RadMessageBox.Show("Please enter (or select) a value.");
                        return;
                    }

                    if (Strings.UCase(FieldType) == "DATE")
                    {
                        if (!Information.IsDate(txtCriteria.Text))
                        {
                            RadMessageBox.Show("Please enter a valid date value.");
                            return;
                        }
                    }
                    else if (Strings.UCase(FieldType) == "NUMBER")
                    {
                        if (!Information.IsNumeric(txtCriteria.Text))
                        {
                            RadMessageBox.Show("Please enter a valid numeric value.");
                            return;
                        }
                    }

                    if (cboLookupValues.Visible == true)
                    {
                        modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                        modGlobal.gv_sql = string.Format("{0} where LookupID = {1}",
                            modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName18 = "tbl_setup_misclookuplist";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);
                        thislookupvalue = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName18].Rows[0]["Id"]);
                    }

                    NewValidID = modDBSetup.FindMaxRecID("tbl_setup_ImportValidation", "ValidID");
                    modGlobal.gv_sql = "Insert into tbl_setup_ImportValidation(";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValidID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " MSGID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldType, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValidationTitle) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Values( ";
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, NewValidID);
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql,
                        Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, msgid);
                    modGlobal.gv_sql = string.Format("{0}'{1}','", modGlobal.gv_sql, cboOperation.Text);
                    if (txtCriteria.Visible == true)
                    {
                        modGlobal.gv_sql = string.Format("{0}{1}','", modGlobal.gv_sql, txtCriteria.Text);
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0}{1}','", modGlobal.gv_sql, thislookupvalue);
                    }
                    modGlobal.gv_sql = string.Format("{0}{1}',", modGlobal.gv_sql, FieldType);
                    modGlobal.gv_sql = string.Format("{0}'{1} {2} ", modGlobal.gv_sql, FieldName, cboOperation.Text);
                    if (txtCriteria.Visible == true)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + txtCriteria.Text;
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + cboLookupValues.Text;
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + "')";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    if (sstabValidation.ActiveWindow == sstabValidationErrors)
                    {
                        RefreshECriteriaList();
                    }
                    else
                    {
                        RefreshWCriteriaList();
                    }
                }
                else if (OptCritBlank.IsChecked == true)
                {
                    if (cboOperation.Text != "=" & cboOperation.Text != "<>")
                    {
                        RadMessageBox.Show("Only '=' and '<>' are valid selections for Blank option.");
                        return;
                    }

                    NewValidID = modDBSetup.FindMaxRecID("tbl_setup_ImportValidation", "ValidID");
                    modGlobal.gv_sql = "Insert into tbl_setup_ImportValidation(";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValidID, DDID, MSGID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Operator, FieldValue, FieldType, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValidationTitle) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Values( ";
                    modGlobal.gv_sql = string.Format("{0}{1},{2},{3},", modGlobal.gv_sql, NewValidID,
                        Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex), msgid);
                    modGlobal.gv_sql = string.Format("{0}'{1}',  'NULL' ,'{2}',", modGlobal.gv_sql, cboOperation.Text, FieldType);
                    modGlobal.gv_sql = string.Format("{0}'{1} {2} Blank ')", modGlobal.gv_sql, FieldName, cboOperation.Text);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (sstabValidation.ActiveWindow == sstabValidationErrors)
                    {
                        RefreshECriteriaList();
                    }
                    else
                    {
                        RefreshWCriteriaList();
                    }


                    //ElseIf OptCritType(3).Value = True Then
                    //    If cboFieldType.ListIndex < 0 Then
                    //        MsgBox "Please select a field type from the drop-down box."
                    //        Exit Sub
                    //    End If
                    //    If cboOperation.Text <> "=" And cboOperation.Text <> "<>" Then
                    //        MsgBox "Only '=' and '<>' are valid selections for Field Type option."
                    //        Exit Sub
                    //    End If
                    //
                    //    NewValidID = FindMaxRecID("tbl_setup_ImportValidation", "ValidID")
                    //    gv_sql = "Insert into tbl_setup_ImportValidation("
                    //    gv_sql = gv_sql & " ValidID, DDID, MSGID, "
                    //    gv_sql = gv_sql & " Operator, FieldType,  "
                    //    gv_sql = gv_sql & " FieldTypeVal, ValidationTitle) "
                    //    gv_sql = gv_sql & " Values( "
                    //    gv_sql = gv_sql & NewValidID & "," & lstImportFields.ItemData(lstImportFields.ListIndex) & "," & MsgId & ","
                    //    gv_sql = gv_sql & "'" & cboOperation & "', '" & FieldType & "',"
                    //    gv_sql = gv_sql & "'" & cboFieldType & "', "
                    //    gv_sql = gv_sql & "'" & FieldName
                    //    If cboOperation = "=" Then
                    //        gv_sql = gv_sql & " is a "
                    //    Else
                    //        gv_sql = gv_sql & " is not a "
                    //
                    //    End If
                    //    gv_sql = gv_sql & cboFieldType & " value')"
                    //    gv_cn.Execute gv_sql
                    //    If sstabValidation.Tab = 0 Then
                    //        RefreshECriteriaList
                    //    Else
                    //        RefreshWCriteriaList
                    //    End If


                }
                else if (OptCritLKUp.IsChecked == true)
                {
                    if (cboLookupList.SelectedIndex < 0)
                    {
                        RadMessageBox.Show("Please select a lookup table from the drop-down box.");
                        return;
                    }
                    if (cboOperation.Text != "=" & cboOperation.Text != "<>")
                    {
                        RadMessageBox.Show("Only '=' and '<>' are valid selections for Lookup Table option.");
                        return;
                    }

                    NewValidID = modDBSetup.FindMaxRecID("tbl_setup_ImportValidation", "ValidID");
                    modGlobal.gv_sql = "Insert into tbl_setup_ImportValidation(";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValidID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " MSGID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldType,  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValidationTitle) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Values( ";
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, NewValidID);
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql,
                        Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, msgid);
                    modGlobal.gv_sql = string.Format("{0}'{1}', '", modGlobal.gv_sql, cboOperation.Text);
                    modGlobal.gv_sql = string.Format("{0}{1}',", modGlobal.gv_sql, FieldType);
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql,
                        Support.GetItemData(cboLookupList, cboLookupList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}'{1}", modGlobal.gv_sql, FieldName);
                    if (cboOperation.Text == "=")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " is in ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " is not in ";

                    }
                    modGlobal.gv_sql = string.Format("{0}{1}')", modGlobal.gv_sql, cboLookupList.Text);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    if (sstabValidation.ActiveWindow == sstabValidationErrors)
                    {
                        RefreshECriteriaList();
                    }
                    else
                    {
                        RefreshWCriteriaList();
                    }
                }

                RefreshCriteriaButtons();
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

        private void frmImportSetup_Load(object sender, EventArgs e)
        {
            try
            {
                modGlobal.gv_sql = "select * from  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_ImportSetup ";
                modGlobal.gv_sql = string.Format("{0} where importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName19 = "tbl_setup_ImportSetup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                lblThisSetup.Text = "Import Layout: " + modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["Description"];

                RefreshSelectedFields();
                RefreshAvailableFields();
                RefreshErrorMessages();
                RefreshWarningMessages();
                RefreshCriteriaButtons();
                RefreshLookupTables();
                sstabValidation.ActiveWindow = sstabValidationErrors;
                sstabImport.ActiveWindow = sstabImportField;
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

        public int GetNextFieldOrderID()
        {
            int MaxOrderId = 0;

            try
            {

                modGlobal.gv_sql = "select max(OrderNumber) as MaxOrderID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_ImportFields ";
                modGlobal.gv_sql = string.Format("{0} where importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTalbeName20 = "tbl_setup_ImportFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTalbeName20, modGlobal.gv_rs);

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTalbeName20].Rows[0]["MaxOrderId"]))
                {
                    MaxOrderId = 0;
                }
                else
                {
                    MaxOrderId = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTalbeName20].Rows[0]["MaxOrderId"]);
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
            return MaxOrderId + 1;
        }

        public void RefreshECriteriaList()
        {
            int this_ListIndex;
            var LIndex = 0;
            string JoinOperator = null;

            try
            {

                lstCriteria.Items.Clear();

                JoinOperator = "";

                if (rdcImportValError.Tables[rdcImportValErrorTable].Rows.Count <= 0)
                {
                    return;
                }


                //find the join operator in the table for the message
                modGlobal.gv_sql = "Select JoinOperator from tbl_Setup_ImportValidationMessage ";
                modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName21 = "tbl_Setup_ImportValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);

                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName21].Rows[0]["JoinOperator"]))
                {
                    JoinOperator = modGlobal.gv_rs.Tables[sqlTableName21].Rows[0]["JoinOperator"].ToString();
                }

                modGlobal.gv_sql = "select * from tbl_Setup_importValidation  ";
                modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_Setup_importValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                LIndex = 0;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow22 in modGlobal.gv_rs.Tables[sqlTableName22].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;
                    if (modGlobal.gv_rs.Tables[sqlTableName22].Rows.Count == LIndex)
                    {
                        lstCriteria.Items.Add(myRow22.Field<string>("ValidationTitle"));
                    }
                    else
                    {
                        lstCriteria.Items.Add(string.Format("{0} {1}", myRow22.Field<string>("ValidationTitle"), JoinOperator));
                    }
                    Support.SetItemData(lstCriteria, lstCriteria.Items.Count - 1, myRow22.Field<int>("ValidID"));
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

        public void InitCriteria()
        {
            try
            {
                string txtOperator = null;
                //RefreshTableFieldsForCriteria
                txtOperator = "";
                txtCriteria.Text = "";
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

        public void RefreshErrorMessages()
        {
            RadGridView dbgImportValError = new RadGridView();

            try
            {
                modGlobal.gv_sql = "select tbl_setup_DataDef.FieldName, tbl_setup_ImportValidationMessage.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportValidationMessage ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportValidationMessage.DDID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.ValidationType = 'ERROR' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.importfieldid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid from tbl_setup_importfields ";
                modGlobal.gv_sql = string.Format("{0} where importsetupid  = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                modGlobal.gv_sql = modGlobal.gv_sql + ") ORDER BY tbl_setup_DataDef.FieldName";

                //LDW rdcImportValError.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcImportValErrorTable = "tbl_setup_DataDef";
                rdcImportValError = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcImportValErrorTable, rdcImportValError);
                rdcImportValError.AcceptChanges();
                dbgImportValError.Refresh();

                RefreshECriteriaList();
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

        public void RefreshLookupTables()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemscboLookupList = new List<Item>();

            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);
                cboLookupList.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow22 in modGlobal.gv_rs.Tables[sqlTableName22].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemscboLookupList.Add(new Item(myRow22.Field<int>("basetableid"), myRow22.Field<string>("BaseTable")));

                    //cboLookupList.Items.Add(new ListBoxItem(myRow22.Field<string>("BaseTable"), myRow22.Field<int>("basetableid")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboLookupList.DataSource = itemscboLookupList;
                this.cboLookupList.DisplayMember = "Description";
                this.cboLookupList.ValueMember = "Id";
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

        private void lstImportFields_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (lstImportFields.SelectedIndex < 0)
                {
                    return;
                }
                RefreshLookupListForThisField();
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

        public void RefreshLookupListForThisField()
        {
            var LIndex = 0;
            int Field_ListIndex;
            int LookupTableID;
            List<Item> itemscboLookupValues = new List<Item>();


            try
            {
                modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstImportFields, lstImportFields.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName23 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName23].Rows.Count > 0)
                {
                    LookupTableID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName23].Rows[0]["LookupTableID"]);
                    //Opt2Method.Value = True
                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName24 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);
                    cboLookupValues.Items.Clear();

                    Field_ListIndex = -1;
                    LIndex = -1;
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow24 in modGlobal.gv_rs.Tables[sqlTableName24].Rows)
                    {
                        LIndex = LIndex + 1;
                        Field_ListIndex = LIndex;

                        itemscboLookupValues.Add(new Item(myRow24.Field<int>("LookupID"), string.Format("({0}) {1}", myRow24.Field<int>("Id"), myRow24.Field<string>("FIELDVALUE"))));

                        //cboLookupValues.Items.Add(new ListBoxItem(string.Format("({0}) {1}", myRow24.Field<int>("Id"), myRow24.Field<string>("FIELDVALUE")), myRow24.Field<int>("LookupID")).ToString());

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    this.cboLookupValues.DataSource = itemscboLookupValues;
                    this.cboLookupValues.DisplayMember = "Description";
                    this.cboLookupValues.ValueMember = "Id";

                    cboLookupValues.Visible = true;
                    cboLookupValues.Top = txtCriteria.Top;
                    cboLookupValues.Enabled = true;
                    txtCriteria.Text = "";
                    txtCriteria.Visible = false;
                    txtCriteria.Enabled = false;
                }
                else
                {
                    cboLookupValues.Items.Clear();
                    cboLookupValues.Visible = false;
                    cboLookupValues.Top = txtCriteria.Top;
                    txtCriteria.Visible = true;
                    txtCriteria.Enabled = true;
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



        private void sstabValidation_SelectedTabChanged(object sender, Telerik.WinControls.UI.Docking.SelectedTabChangedEventArgs e)
        {
            try
            {
                lock (static_sstabValidation_SelectedIndexChanged_PreviousTab_Init)
                {
                    try
                    {
                        if (InitStaticVariableHelper(static_sstabValidation_SelectedIndexChanged_PreviousTab_Init))
                        {
                            static_sstabValidation_SelectedIndexChanged_PreviousTab = sstabValidation.ActiveWindow.DockTabStrip.SelectedIndex;
                        }
                    }
                    finally
                    {
                        static_sstabValidation_SelectedIndexChanged_PreviousTab_Init.State = 1;
                    }
                }

                RadDropDownList cboFieldType = new RadDropDownList();


                optCritValue.IsChecked = false;
                OptCritBlank.IsChecked = false;
                //OptCritType(3).Value = False
                OptCritLKUp.IsChecked = false;
                txtCriteria.Text = "";
                cboFieldType.Text = "";
                cboLookupList.Text = "";
                RefreshCriteriaButtons();

                static_sstabValidation_SelectedIndexChanged_PreviousTab = sstabValidation.ActiveWindow.DockTabStrip.SelectedIndex;
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

        private void txtCriteria_TextChanged(object sender, EventArgs e)
        {
            optCritValue.IsChecked = true;
        }

        public void RefreshWarningMessages()
        {
            RadGridView dbgImportValWarning = new RadGridView();

            try
            {

                modGlobal.gv_sql = "select tbl_setup_DataDef.FieldName, tbl_setup_ImportValidationMessage.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportValidationMessage ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportValidationMessage.DDID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.ValidationType = 'WARNING' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_ImportValidationMessage.importfieldid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select importfieldid from tbl_setup_importfields ";
                modGlobal.gv_sql = string.Format("{0} where importsetupid  = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                modGlobal.gv_sql = modGlobal.gv_sql + ") ORDER BY tbl_setup_DataDef.FieldName";
                //LDW rdcImportValWarning.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcImportValWarningTable = "tbl_setup_DataDef";
                rdcImportValWarning = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcImportValWarningTable, rdcImportValWarning);
                rdcImportValWarning.AcceptChanges();
                dbgImportValWarning.Refresh();

                RefreshWCriteriaList();
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

        public void RefreshCriteriaButtons()
        {
            int msgid = 0;
            string JoinOperator = null;

            try
            {

                JoinOperator = "";

                if (sstabValidation.ActiveWindow == sstabValidationErrors)
                {
                    if (rdcImportValError.Tables[rdcImportValErrorTable].Rows.Count > 0)
                    {
                        msgid = Convert.ToInt32(rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"]);
                    }
                }
                else
                {
                    if (rdcImportValWarning.Tables[rdcImportValWarningTable].Rows.Count > 0)
                    {
                        msgid = Convert.ToInt32(rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                    }
                }

                modGlobal.gv_sql = "Select joinoperator from tbl_setup_ImportValidationMessage ";
                modGlobal.gv_sql = string.Format("{0} where msgID  = {1}", modGlobal.gv_sql, msgid);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName25 = "tbl_setup_ImportValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName25].Rows.Count > 0)
                {
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["JoinOperator"]))
                    {
                        JoinOperator = modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["JoinOperator"].ToString();
                    }
                }

                if (msgid == 0)
                {
                    cmdAnd.Enabled = false;
                    cmdOr.Enabled = false;
                    cmdSubmit.Enabled = false;
                }
                else
                {
                    cmdAnd.Enabled = false;
                    cmdOr.Enabled = false;
                    cmdSubmit.Enabled = true;

                    modGlobal.gv_sql = "Select * from tbl_setup_ImportValidation ";
                    modGlobal.gv_sql = string.Format("{0} where msgID  = {1}", modGlobal.gv_sql, msgid);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName26 = "tbl_setup_ImportValidation";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName26].Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(JoinOperator))
                        {
                            cmdAnd.Enabled = true;
                            cmdOr.Enabled = true;
                            cmdSubmit.Enabled = false;
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

        public void RefreshWCriteriaList()
        {
            int this_ListIndex;
            var LIndex = 0;
            string JoinOperator = null;

            try
            {

                lstWCriteria.Items.Clear();

                JoinOperator = "";

                if (rdcImportValWarning.Tables[rdcImportValWarningTable].Rows.Count <= 0)
                {
                    return;
                }


                //find the join operator in the table for the message
                modGlobal.gv_sql = "Select JoinOperator from tbl_Setup_ImportValidationMessage ";
                modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName27 = "tbl_Setup_ImportValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);

                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["JoinOperator"]))
                {
                    JoinOperator = modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["JoinOperator"].ToString();
                }


                modGlobal.gv_sql = "select * from tbl_Setup_importValidation  ";
                modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["msgid"]);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName28 = "tbl_Setup_importValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);

                LIndex = 0;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow28 in modGlobal.gv_rs.Tables[sqlTableName28].Rows)
                {
                    LIndex = LIndex + 1;
                    this_ListIndex = LIndex;
                    if (modGlobal.gv_rs.Tables[sqlTableName28].Rows.Count == LIndex)
                    {
                        lstWCriteria.Items.Add(myRow28.Field<string>("ValidationTitle"));
                    }
                    else
                    {
                        lstWCriteria.Items.Add(string.Format("{0} {1}", myRow28.Field<string>("ValidationTitle"), JoinOperator));
                    }
                    Support.SetItemData(lstWCriteria, lstWCriteria.Items.Count - 1, myRow28.Field<int>("ValidID"));
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
        private void cmdCancel_Click()
        {
            InitCriteria();
        }

        private void lstFieldListForCriteria_Click()
        {
            string txtOperator = null;
            txtOperator = "";
            txtCriteria.Text = "";
        }

        private void rdcImportValError_Reposition()
		{

			if (rdcImportValError.Resultset.RowCount > 0) {
				//set join operator to null if there are fewer than 2 criteria for this message
				modGlobal.gv_sql = "Select count(*) as totalcrit from tbl_Setup_ImportValidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				if (modGlobal.gv_rs.rdoColumns["totalcrit"].Value < 2) {
					modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
					modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = null ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValError.Resultset.rdoColumns["msgid"].Value;
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				}
			}
			RefreshECriteriaList();
			RefreshCriteriaButtons();
		}

		private void rdcImportValWarning_Reposition()
		{

			if (rdcImportValWarning.Resultset.RowCount > 0) {
				//set join operator to null if there are fewer than 2 criteria for this message
				modGlobal.gv_sql = "Select count(*) as totalcrit from tbl_Setup_ImportValidation ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				if (modGlobal.gv_rs.rdoColumns["totalcrit"].Value < 2) {
					modGlobal.gv_sql = "update tbl_Setup_ImportValidationMessage ";
					modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = null ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MSGID = " + rdcImportValWarning.Resultset.rdoColumns["msgid"].Value;
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				}
			}

			RefreshWCriteriaList();
			RefreshCriteriaButtons();
		}


        */

    }
}
