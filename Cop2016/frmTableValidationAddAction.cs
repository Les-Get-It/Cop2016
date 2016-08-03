using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Drawing;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmTableValidationAddAction : Telerik.WinControls.UI.RadForm
    {
        const string rdcValidationErrorsTable = "tbl_setup_TableValidationMessage";
        const string rdcValidationWarningsTable = "tbl_setup_TableValidationMessage";


        public frmTableValidationAddAction()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            string DestFieldType = null;

            try
            {

                int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_TableValidationAction", "TableValidationActionID");

                if (lstFieldList.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Select a field from the list.");

                    DialogResult ds1 = RadMessageBox.Show(this, "Select a field from the list.", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }

                if (optBlank.IsChecked == false & optZero.IsChecked == false)
                {
                    //LDW RadMessageBox.Show("Select either Blank or Zero from the options.");

                    DialogResult ds2 = RadMessageBox.Show(this, "Select either Blank or Zero from the options.", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                    return;
                }

                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                DestFieldType = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (Strings.UCase(Strings.Mid(DestFieldType, 1, 3)) != "NUM" & optZero.IsChecked == true)
                {
                    //LDW RadMessageBox.Show("This field cannot be set to zero, because it is not a numeric field.");

                    DialogResult ds3 = RadMessageBox.Show(this, "This field cannot be set to zero, because it is not a numeric field.", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                    return;
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_TableValidationAction ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (TableValidationActionID, TableValidationMessageID, ddid, setvalue) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                }
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                if (optZero.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " '0'";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Null'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTableValidationAddAction_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshFieldList();
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

            try
            {

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID =  {1}", modGlobal.gv_sql, Support.GetItemData
                    (frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex));

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (state = '' or State is null or state = '{1}')", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //Display the list of fields
                lstFieldList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    //LDW lstFieldList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                    lstFieldList.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"), myRow1.Field<int>("DDID")).ToString());
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
