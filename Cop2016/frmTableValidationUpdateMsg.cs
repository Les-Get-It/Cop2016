using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmTableValidationUpdateMsg : Telerik.WinControls.UI.RadForm
    {
        const string rdcValidationErrorsTable = "tbl_setup_TableValidationMessage";
        const string rdcValidationWarningsTable = "tbl_setup_TableValidationMessage";

        public frmTableValidationUpdateMsg()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAddfield_Click(object sender, EventArgs e)
        {
            var LIndex = 0;

            try
            {
                if (cboFieldList.SelectedIndex > -1)
                {
                    LIndex = lstFieldstoValidate.Items.Count;
                    lstFieldstoValidate.Items.Add(new ListBoxItem(cboFieldList.Text, Support.GetItemData(cboFieldList, cboFieldList.SelectedIndex)).ToString());
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRemoveField_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFieldstoValidate.SelectedIndex > -1)
                {
                    lstFieldstoValidate.Items.RemoveAt((lstFieldstoValidate.SelectedIndex));
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            int NewValID = 0;
            var i = 0;
            int msgid = 0;

            try
            {

                if (string.IsNullOrEmpty(txtMessage.Text))
                {
                    //LDW RadMessageBox.Show("Please define a validation message.");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please define a validation message.", "Update", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }

                if (opt1Save.IsChecked == false & opt2Delete.IsChecked == false & lstFieldstoValidate.Items.Count == 0)
                {
                    //LDW RadMessageBox.Show("Please define when this validation should occur.");

                    DialogResult ds2 = RadMessageBox.Show(this, "Please define when this validation should occur.", "Update", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                    return;
                }

                string refTxtMessage = txtMessage.Text;
                modGlobal.gv_sql = "Update tbl_setup_TableValidationMessage ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set ";
                modGlobal.gv_sql = string.Format("{0} Message = '{1}',", modGlobal.gv_sql, modGlobal.ConvertApastroph(refTxtMessage));
                modGlobal.gv_sql = modGlobal.gv_sql + " UserAction = ";
                if (opt1Save.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Saving Record' ";
                }
                else if (opt2Delete.IsChecked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Deleting Record' ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                if (Strings.UCase(modGlobal.gv_Action) == "ERROR")
                {
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageID = {1}", modGlobal.gv_sql,
                        frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageID  = {1}", modGlobal.gv_sql,
                        frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = "Delete tbl_setup_TableValidationAfterFieldUpdate ";
                if (Strings.UCase(modGlobal.gv_Action) == "ERROR")
                {
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageID = {1}", modGlobal.gv_sql,
                        frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where TableValidationMessageID  = {1}", modGlobal.gv_sql,
                        frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                }
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                if (opt3UpdateField.IsChecked)
                {
                    if (lstFieldstoValidate.Items.Count > 0)
                    {
                        if (Strings.UCase(modGlobal.gv_Action) == "ERROR")
                        {
                            msgid = Convert.ToInt32(frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                        }
                        else
                        {
                            msgid = Convert.ToInt32(frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                        }

                        for (i = 1; i <= lstFieldstoValidate.Items.Count; i++)
                        {
                            NewValID = modDBSetup.FindMaxRecID("tbl_setup_tablevalidationAfterFieldUpdate", "tablevalidationAfterFieldUpdateID");

                            modGlobal.gv_sql = "insert into tbl_setup_tablevalidationAfterFieldUpdate ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " (tablevalidationAfterFieldUpdateID, tablevalidationmessageid, ddid)";
                            modGlobal.gv_sql = string.Format("{0} values ({1}, {2}, {3})", modGlobal.gv_sql, NewValID, msgid, Support.GetItemData(lstFieldstoValidate, i - 1));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }
                }
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

        public void RefreshFieldList()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            var LIndex = 0;
            int Field_ListIndex = -1;


            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '{1}')", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";


                //retrieve the list of dynamic fields
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                cboFieldList.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Field_ListIndex = LIndex;

                    cboFieldList.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"), myRow1.Field<int>("DDID")).ToString());

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

        //Updated method to take in the table name of the data set
        public void RefreshSelectedFields(string sqlTableName)
        {
            var LIndex = 0;
            string sqlTableName1 = sqlTableName;


            try
            {
                //Display the list of fields
                lstFieldstoValidate.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    lstFieldstoValidate.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());
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

        private void frmTableValidationUpdateMsg_Load(object sender, EventArgs e)
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();

            this.CenterToParent();

            try
            {
                RefreshFieldList();
                cboFieldList.Enabled = false;
                lstFieldstoValidate.Enabled = false;

                if (Strings.UCase(modGlobal.gv_Action) == "ERROR")
                {
                    txtMessage.Text = frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["Message"].ToString();
                    if (frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["UserAction"].ToString() == "Saving Record")
                    {
                        opt1Save.IsChecked = true;
                    }
                    else if (frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["UserAction"].ToString() == "Deleting Record")
                    {
                        opt2Delete.IsChecked = true;
                    }
                    else
                    {
                        opt3UpdateField.IsChecked = true;
                        cboFieldList.Enabled = true;
                        lstFieldstoValidate.Enabled = true;
                        modGlobal.gv_sql = "Select tv.*, dd.fieldname from ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_TableValidationAfterFieldUpdate as tv ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " on tv.ddid = dd.ddid ";
                        modGlobal.gv_sql = string.Format("{0} where tv.TableValidationMessageID = {1}", modGlobal.gv_sql,
                            frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName2 = "tbl_setup_TableValidationAfterFieldUpdate";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                        RefreshSelectedFields(sqlTableName2);
                    }
                }
                else
                {
                    txtMessage.Text = frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["Message"].ToString();
                    if (frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["UserAction"].ToString() == "Saving Record")
                    {
                        opt1Save.IsChecked = true;
                    }
                    else if (frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["UserAction"].ToString() == "Deleting Record")
                    {
                        opt2Delete.IsChecked = true;
                    }
                    else
                    {
                        opt3UpdateField.IsChecked = true;
                        cboFieldList.Enabled = true;
                        lstFieldstoValidate.Enabled = true;
                        modGlobal.gv_sql = "Select tv.*, dd.fieldname from ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_TableValidationAfterFieldUpdate as tv ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " on tv.ddid = dd.ddid ";
                        modGlobal.gv_sql = string.Format("{0} where tv.TableValidationMessageID = {1}", modGlobal.gv_sql,
                            frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName3 = "tbl_setup_TableValidationAfterFieldUpdate";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);
                        RefreshSelectedFields(sqlTableName3);
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

        private void opt1Save_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(opt1Save.IsChecked))
                {
                    cboFieldList.Enabled = false;
                    cboFieldList.Text = "";
                    lstFieldstoValidate.Enabled = false;
                    lstFieldstoValidate.Items.Clear();
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

        private void opt2Delete_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(opt2Delete.IsChecked))
                {
                    cboFieldList.Enabled = false;
                    cboFieldList.Text = "";
                    lstFieldstoValidate.Enabled = false;
                    lstFieldstoValidate.Items.Clear();
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

        private void opt3UpdateField_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(opt3UpdateField.IsChecked))
                {
                    cboFieldList.Enabled = true;
                    lstFieldstoValidate.Enabled = true;
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
