using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmTableValidationAddMsg : Telerik.WinControls.UI.RadForm
    {

        public frmTableValidationAddMsg()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            var i = 0;
            int newmsgid = 0;


            try
            {
                int NewValID = modDBSetup.FindMaxRecID("tbl_Setup_TableValidationMessage", "TableValidationMessageID");


                if (string.IsNullOrEmpty(txtMessage.Text))
                {
                    RadMessageBox.Show("Please define a validation message.");
                    return;
                }

                if (opt1Save.IsChecked == false & opt2Delete.IsChecked == false & lstFieldstoValidate.Items.Count == 0)
                {
                    //LDW RadMessageBox.Show("Please define when this validation should occur.");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please define when this validation should occur.", "Add Message Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_TableValidationMessage(TableValidationMessageID, BaseTableid, Message, MessageType, UserAction, State, RecordStatus)";
                modGlobal.gv_sql = string.Format("{0} values ( {1}, ", modGlobal.gv_sql, NewValID);
                modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, Support.GetItemData(frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex));
                string refTxtMessage = txtMessage.Text;
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, modGlobal.ConvertApastroph(refTxtMessage));
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, modGlobal.gv_Action);
                if (opt1Save.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Saving Record', ";
                }
                else if (opt2Delete.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Deleting Record', ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                }
                if (!string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, modGlobal.gv_State);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                if (lstFieldstoValidate.Items.Count > 0)
                {
                    modGlobal.gv_sql = "Select max(tablevalidationmessageid) as newid ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_tablevalidationmessage ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_tablevalidationmessage";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                    newmsgid = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["newid"]);
                    for (i = 1; i <= lstFieldstoValidate.Items.Count; i++)
                    {
                        NewValID = modDBSetup.FindMaxRecID("tbl_setup_tablevalidationAfterFieldUpdate", "tablevalidationAfterFieldUpdateID");

                        modGlobal.gv_sql = "insert into tbl_setup_tablevalidationAfterFieldUpdate ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (tablevalidationAfterFieldUpdateID, tablevalidationmessageid, ddid)";
                        modGlobal.gv_sql = string.Format("{0} values ({1}, {2}, {3})", modGlobal.gv_sql, NewValID, newmsgid,
                            Support.GetItemData(lstFieldstoValidate, i - 1));
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
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

        private void cmdAddfield_Click(object sender, EventArgs e)
        {
            var LIndex = 0;

            try
            {
                if (cboFieldList.SelectedIndex > -1)
                {
                    LIndex = lstFieldstoValidate.Items.Count;
                    /*LDW lstFieldstoValidate.Items.Add(new ListBoxItem(cboFieldList.Text,
                        Support.GetItemData(cboFieldList, cboFieldList.SelectedIndex)));*/
                    lstFieldstoValidate.Items.Add(cboFieldList.Text);
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

        private void frmTableValidationAddMsg_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            RefreshFieldList();
        }

        public void RefreshFieldList()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            var LIndex = 0;
            int Field_ListIndex = -1;


            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where BaseTableID = {1}", modGlobal.gv_sql, Support.GetItemData(frmTableValidationSetupCopy.cboTableList,
                    frmTableValidationSetupCopy.cboTableList.SelectedIndex));
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
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboFieldList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Field_ListIndex = LIndex;

                    //LDW cboFieldList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                    cboFieldList.Items.Add(string.Format("{0} {1}", myRow1.Field<string>("FieldName"), myRow1.Field<string>("DDID")));
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

        private void opt1Save_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(opt1Save.IsChecked) == true)
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
                if (sender.Equals(opt1Save.IsChecked) == true)
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
                if (sender.Equals(opt1Save.IsChecked) == true)
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
