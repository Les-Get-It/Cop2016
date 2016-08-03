using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;

namespace COP2001
{
    public partial class frmTableFieldAdd : Telerik.WinControls.UI.RadForm
    {
        DataSet rdcLookupTableList = new DataSet();
        string rdcLookupTableListTable = null;


        public frmTableFieldAdd()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cbo_LookupTbls_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cbo_LookupTbls.SelectedIndex > -1)
                {
                    chkMultipleSel.Enabled = true;
                }
                else
                {
                    chkMultipleSel.Enabled = false;
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

        private void cboFieldType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Number" | cboFieldType.Text == "Date/Time")
                {
                    chkUTD.Visible = true;
                }
                else
                {
                    chkUTD.Visible = false;
                    chkUTD.CheckState = CheckState.Unchecked;
                }

                if (cboFieldType.Text == "Text")
                {
                    txtFieldSize.Visible = true;
                    lblFieldSize.Visible = true;
                    cbo_LookupTbls.Visible = true;
                    lblLookupTable.Visible = true;
                    txtFieldSize.Focus();
                }
                else
                {
                    txtFieldSize.Visible = false;
                    lblFieldSize.Visible = false;
                    cbo_LookupTbls.Visible = false;
                    lblLookupTable.Visible = false;
                }

                if (cboFieldType.Text == "Time")
                {
                    cboDateFields.Visible = true;
                    lblDateFields.Visible = true;
                }
                else
                {
                    cboDateFields.Visible = false;
                    lblDateFields.Visible = false;
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

        private void chkMultipleSel_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkMultipleSel.CheckState == CheckState.Checked)
                {
                    txtMaxSel.Enabled = true;
                    lblMaxSel.Enabled = true;
                }
                else
                {
                    txtMaxSel.Enabled = false;
                    lblMaxSel.Enabled = false;
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmTableSetup frmTableSetupCopy = new frmTableSetup();
            string FieldSize = null;

            try
            {

                if (cboFieldType.Text != "Text")
                {
                    FieldSize = "Null";
                }
                else
                {
                    if (string.IsNullOrEmpty(txtFieldSize.Text))
                    {
                        lblFieldSize.Visible = true;
                        txtFieldSize.Visible = true;
                        //LDW RadMessageBox.Show("Please define the field size.");

                        DialogResult ds1 = RadMessageBox.Show(this, "Please define the field size.", "Add Field Size", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds1.ToString();
                        return;
                    }
                    else
                    {
                        FieldSize = txtFieldSize.Text;
                    }
                }

                if (cboFieldType.Text == "Time" & cboDateFields.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("There has to be a date field associated with this time field. Please define...");

                    DialogResult ds2 = RadMessageBox.Show(this, "There has to be a date field associated with this time field. Please define...", "Add Date Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                    return;
                }

                if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & (string.IsNullOrEmpty(txtMaxSel.Text) | Information.IsNumeric(txtMaxSel.Text) == false))
                {
                    //LDW RadMessageBox.Show("There has to be a max number of selections associated with this field. Please define...");

                    DialogResult ds3 = RadMessageBox.Show(this, "There has to be a date field associated with this time field. Please define...", "Add Date Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                    return;
                }


                int li_MaxSel = 0;
                int li_cnt = 1;
                int ParentDDID = 0;
                int NextNewID = 0;


                if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & Information.IsNumeric(txtMaxSel.Text) == true)
                {
                    li_MaxSel = Convert.ToInt32(txtMaxSel.Text);
                }
                else
                {
                    li_MaxSel = 1;
                }

                while (li_cnt <= li_MaxSel)
                {
                    modGlobal.gv_Action = "Add";

                    NextNewID = modDBSetup.FindMaxRecID("tbl_setup_datadef", "DDID");
                    if (ParentDDID == 0)
                    {
                        ParentDDID = NextNewID;
                    }

                    modGlobal.gv_sql = "Insert into tbl_setup_DataDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (DDID, BaseTableID, FieldName, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldType, FieldSize, Lookuptableid, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Help,  FieldCategory, State, RecordStatus,  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateFieldDDID, Inactive ";
                    modGlobal.gv_sql = modGlobal.gv_sql + (li_MaxSel > 1 ? ", ParentDDID" : "");
                    modGlobal.gv_sql = modGlobal.gv_sql + ", AllowUTD, IsPhysician)";

                    modGlobal.gv_sql = string.Format("{0} values ({1},{2},", modGlobal.gv_sql, NextNewID, Support.GetItemData(frmTableSetupCopy.cboTableList, frmTableSetupCopy.cboTableList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}'{1}{2}', ", modGlobal.gv_sql, txtFieldName.Text, li_MaxSel > 1 & li_cnt > 1 ? "-" + Convert.ToString(li_cnt) : "");
                    modGlobal.gv_sql = string.Format("{0}'{1}',{2},", modGlobal.gv_sql, cboFieldType.Text, FieldSize);
                    if (cboFieldType.Text != "Text" | string.IsNullOrEmpty(cbo_LookupTbls.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                    }
                    else if (cbo_LookupTbls.SelectedIndex > -1)
                    {
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cbo_LookupTbls, cbo_LookupTbls.SelectedIndex));
                    }
                    modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, txtHelp.Text);

                    //'Dynamic',"

                    modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, Convert.ToBoolean(chkDynamic.CheckState) ? "Dynamic" : "Fix");

                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, modGlobal.gv_State);
                    }
                    if (string.IsNullOrEmpty(modGlobal.gv_status))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, modGlobal.gv_status);
                    }
                    if (cboDateFields.SelectedIndex > -1 & cboDateFields.Visible == true)
                    {
                        modGlobal.gv_sql = string.Format("{0}{1} ", modGlobal.gv_sql, Support.GetItemData(cboDateFields, cboDateFields.SelectedIndex));
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + ", ";
                    if (chkInactive.CheckState == 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " 'I' ";
                    }

                    modGlobal.gv_sql = modGlobal.gv_sql + (li_MaxSel > 1 ? ", " + Convert.ToString(ParentDDID) : "");
                    modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, chkUTD.Visible == false ? "NULL" : chkUTD.CheckState.ToString());
                    //gv_sql = gv_sql & ")"
                    modGlobal.gv_sql = string.Format("{0}, {1})", modGlobal.gv_sql, chkPhysician.CheckState);

                    Debug.Print(modGlobal.gv_sql);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    li_cnt = li_cnt + 1;
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
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            modGlobal.gv_Action = "Cancel";
            this.Close();
        }

        private void RefreshLookupTablesList()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;


            try
            {

                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '{1}' or State is null)", modGlobal.gv_sql, modGlobal.gv_State);
                }
                //If gv_status = "" Then
                //    gv_sql = gv_sql & " and (RecordStatus = '' or RecordStatus is null) "
                //Else
                //    gv_sql = gv_sql & " and RecordStatus = '" & gv_status & "'"
                //End If
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW rdcLookupTableList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcLookupTableListTable = "tbl_Setup_TableDef";
                rdcLookupTableList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcLookupTableListTable, rdcLookupTableList);
                rdcLookupTableList.AcceptChanges();

                cbo_LookupTbls.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!rdcLookupTableList.Resultset.EOF)
                foreach (DataRow myRow1 in rdcLookupTableList.Tables[rdcLookupTableListTable].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    cbo_LookupTbls.Items.Add(string.Format("{0} {1}", myRow1.Field<string>("BaseTable"), myRow1.Field<int>("basetableid")));
                    //LDW rdcLookupTableList.Resultset.MoveNext();
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

        private void frmTableFieldAdd_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshLookupTablesList();
                RefreshDateFieldList();
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

        public void RefreshDateFieldList()
        {
            frmTableSetup frmTableSetupCopy = new frmTableSetup();
            var LIndex = 0;


            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID =  {1}", modGlobal.gv_sql, frmTableSetupCopy.cboTableList.SelectedItem.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + " and fieldtype = 'Date' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '{1}')", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                modGlobal.gv_rs.AcceptChanges();
                modGlobal.gv_rs.GetChanges();
                //Display the list of fields
                cboDateFields.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    //LDW cboDateFields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                    cboDateFields.Items.Add(string.Format("{0} {1}", myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")));
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
