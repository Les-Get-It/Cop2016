using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Telerik.WinControls;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmSetupSelection : Telerik.WinControls.UI.RadForm
    {

        public frmSetupSelection()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                modGlobal.gv_cn = null;
                Environment.Exit(0);
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
            this.Close();
        }

        private void cmdMoveAllToActive_Click(object sender, EventArgs e)
        {
            string statespec = null;
            string recstatus = null;
            DialogResult resp;
            string thismodule = null;

            try
            {

                if (optExistingState.IsChecked == false & optNewState.IsChecked == false & optJC.IsChecked == false)
                {
                    //LDW RadMessageBox.Show("Please select a setup to update.");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please select a setup to update.", "Move All to Active", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();

                    return;
                }

                if (optExistingState.IsChecked == true)
                {
                    if (string.IsNullOrEmpty(cboExistingState.Text))
                    {
                        //LDW RadMessageBox.Show("Select a state from the list.");

                        DialogResult ds2 = RadMessageBox.Show(this, "Select a state from the list.", "Move All to Active", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds2.ToString();
                        return;
                    }
                }
                if (optNewState.IsChecked == true)
                {
                    //LDW RadMessageBox.Show("You are about to add a module for a new state. No Test setup has been defined yet to move to active.");

                    DialogResult ds3 = RadMessageBox.Show(this, "You are about to add a module for a new state. No Test setup has been defined yet to move to active.",
                        "Move All to Active", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                    return;
                }

                if (optExistingState.IsChecked == true)
                {
                    modGlobal.gv_State = cboExistingState.Text;
                }

                if (optJC.IsChecked == true)
                {
                    thismodule = "Joint Commission";
                }
                else
                {
                    thismodule = cboExistingState.Text;
                }

                //LDW resp = RadMessageBox.Show(string.Format("Are you sure you want to move the entire Test module for {0} setup to Active?", thismodule), MsgBoxStyle.YesNo, "Move Test to Active");

                resp = RadMessageBox.Show(this, string.Format("Are you sure you want to move the entire Test module for {0} setup to Active?",
                    thismodule), "Move Test to Active", MessageBoxButtons.YesNo, RadMessageIcon.Question); ;
                if (resp == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //these lines are added to every query
                    recstatus = " set RecordStatus = Null ";
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        statespec = " where State is null or state = ''";
                    }
                    else
                    {
                        statespec = string.Format(" where State = '{0}'", modGlobal.gv_State);
                    }

                    //update tables with RecordStatus field
                    modGlobal.gv_sql = string.Format("Update tbl_setup_indicator {0}{1}", recstatus, statespec);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_indicatorset {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_datadef {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_tabledef {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_indicatorgroup {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_tablevalidationmessage {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_submitgroup {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_submitvalidation {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_submitcleanupitems {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_submitcleanuprecord {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_savedadhocreports {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //
                    modGlobal.gv_sql = string.Format("Update tbl_setup_importsetup {0}{1}", recstatus, statespec);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    Cursor.Current = Cursors.Default;
                    //LDW RadMessageBox.Show("Conversion is complete.");

                    DialogResult ds4 = RadMessageBox.Show(this, "Conversion is complete.", "Move All to Active", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Text = ds4.ToString();
                }
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 10002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            frmMasterForm frmMasterFormCopy = new frmMasterForm();
            frmMainMenu frmMainMenuCopy = new frmMainMenu();
            string gv_selecteddatabse = null;
            string FormTitle = null;
            int CurrentVersionNumber = 0;

            try
            {

                if (optExistingState.IsChecked == false & optNewState.IsChecked == false & optJC.IsChecked == false & modGlobal.gv_selecteddatabase != "COPWebSetup")
                {
                    //LDW RadMessageBox.Show("Please select a setup to update.");

                    DialogResult ds5 = RadMessageBox.Show(this, "Please select a setup to update.", "Setup Update Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds5.ToString();
                    return;
                }
                modGlobal.gv_sql = "select max(versionnumber) as cver from tbl_setup_version ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_version";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                //LDW if (modGlobal.gv_rs.RowCount > 0)
                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)
                {
                    //LDW CurrentVersionNumber = modGlobal.gv_rs.rdoColumns["cver"].Value;
                    //CurrentVersionNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["cver"]);
                    CurrentVersionNumber = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["cver"]);
                }

                if (optExistingState.IsChecked == true)
                {
                    modGlobal.gv_State = cboExistingState.Text;
                    FormTitle = modGlobal.gv_State + " Setup";
                }
                if (optNewState.IsChecked == true)
                {
                    //NewID = FindMaxRecID("tbl_Setup_StateVersion", "StateVersionID")
                    modGlobal.gv_sql = "Insert into tbl_Setup_StateVersion (StateVersion, State) ";
                    modGlobal.gv_sql = string.Format("{0} values (0, '{1}')", modGlobal.gv_sql, txtNewState.Text);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    modGlobal.gv_State = txtNewState.Text;
                    FormTitle = modGlobal.gv_State + " Setup";
                }

                if (modGlobal.gv_selecteddatabase == "Archive")
                {
                    FormTitle = string.Format("********** ARCHIVE - Version: {0}**********  ", CurrentVersionNumber);
                    if (optJC.IsChecked == true)
                    {
                        modGlobal.gv_State = "";
                        FormTitle = string.Format("********** ARCHIVE (JC Setup) - Version: {0}**********  ", CurrentVersionNumber);
                    }

                }
                else if (modGlobal.gv_selecteddatabase == "Current")
                {
                    FormTitle = string.Format("********** CURRENT - To process hospital data - Version: {0} **********  ", CurrentVersionNumber);
                    if (optJC.IsChecked == true)
                    {
                        modGlobal.gv_State = "";
                        FormTitle = string.Format("********** CURRENT (JC Setup) - To process hospital data - Version: {0} **********  ", CurrentVersionNumber);

                    }
                }
                else if (gv_selecteddatabse == "IHHA")
                {
                    FormTitle = string.Format("********** IHHA - To accept new changes - Version: {0} **********  ", CurrentVersionNumber);
                    if (optJC.IsChecked == true)
                    {
                        modGlobal.gv_State = "";
                        FormTitle = string.Format("********** IHHA (JC Setup) - To accept new changes - Version: {0} **********  ", CurrentVersionNumber);
                    }

                    // If gv_selecteddatabase = "IHHA" Then
                    if (optTest.IsChecked == false & optActive.IsChecked == false)
                    {
                        //LDW RadMessageBox.Show("Please select a module to update.");

                        DialogResult ds6 = RadMessageBox.Show(this, "Please select a module to update.", "Module Update Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds6.ToString();
                        return;
                    }
                    if (optTest.IsChecked == true)
                    {
                        modGlobal.gv_status = "TEST";
                        FormTitle = FormTitle + " | Test Module";
                    }

                    if (optActive.IsChecked == true)
                    {
                        modGlobal.gv_status = "";
                        FormTitle = FormTitle + " | Active Module";
                    }
                }
                else if (modGlobal.gv_selecteddatabase == "COPWebSetup")
                {
                    FormTitle = string.Format("********** COPWebSetup - To create web test - Version: {0} **********  ", CurrentVersionNumber);

                    if (optActive.IsChecked == true)
                    {
                        modGlobal.gv_status = "";
                        FormTitle = FormTitle + " | Active Module";
                    }
                }

                if (optExistingState.IsChecked == true)
                {
                    if (string.IsNullOrEmpty(cboExistingState.Text))
                    {
                        //LDW RadMessageBox.Show("Select a state from the list.");

                        DialogResult ds7 = RadMessageBox.Show(this, "Select a state from the list.", "State Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds7.ToString();
                        return;
                    }
                }
                if (optNewState.IsChecked == true)
                {
                    if (string.IsNullOrEmpty(txtNewState.Text))
                    {
                        //LDW RadMessageBox.Show("Type in a state name.");

                        DialogResult ds8 = RadMessageBox.Show(this, "Type in a state name.", "State Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds8.ToString();
                        return;
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

            frmMasterFormCopy.Text = FormTitle;
            //
            this.Close();
            frmMainMenuCopy.Show();
        }



        private void frmSetupSelection_Load(object sender, EventArgs e)
        {
            int ListIndex = 0;
            /*LDW this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterFormCopy.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterFormCopy.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));*/
            this.CenterToParent();

            //frmSelectDatabase.Show 1
            //
            // If gv_connectionstatus = "fail" Then
            //     Unload Me
            //     Exit Sub
            // End If

            try
            {

                if (modGlobal.gv_selecteddatabasename == "COP2001Current" | modGlobal.gv_selecteddatabasename == "COP2001Archive")
                {
                    this.Text = "Select Setup";
                    fraSelectedModule.Visible = false;
                    cmdMoveAllToActive.Visible = false;
                    //        If gv_selecteddatabasename = "COPWebSetup" Then
                    //            Frame1.Visible = False
                    //        End If
                }
                else
                {
                    this.Text = "Select Setup/Module";
                }

                modGlobal.gv_sql = "Select State from tbl_Setup_StateVersion";
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by State ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_StateVersion";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //
                cboExistingState.Items.Clear();
                //
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    //LDW cboExistingState.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["state"].Value, ListIndex));
                    cboExistingState.Items.Add(myRow.Field<string>("state"));
                    cboExistingState.SelectedIndex = ListIndex;
                    ListIndex = ListIndex + 1;
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

