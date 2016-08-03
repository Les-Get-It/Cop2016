using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmTableEditField : Telerik.WinControls.UI.RadForm
    {

        const string sqlTableName0 = "tempTable1";
        public frmTableEditField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }


        private void cbo_LookupTbls_SelectedIndexChange(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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

                if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Number" | cboFieldType.Text == "Date/Time")
                {
                    chkUTD.Visible = true;
                }
                else
                {
                    chkUTD.Visible = false;
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpdateField_Click(object sender, EventArgs e)
        {
            int ParentDDID = 0;
            var rsMaxBefore = new DataSet();

            try
            {
                if (string.IsNullOrEmpty(txtFieldName.Text) | string.IsNullOrEmpty(cboFieldType.Text))
                {
                    //LDW RadMessageBox.Show("Please define both name and type of the field");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please define both name and type of the field.", "Update Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }
                if (cboFieldType.Text == "Text")
                {
                    if (string.IsNullOrEmpty(txtFieldSize.Text))
                    {
                        //LDW RadMessageBox.Show("Please define the field size.");

                        DialogResult ds2 = RadMessageBox.Show(this, "Please define the field size.", "Update Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds2.ToString();
                        return;
                    }
                    if (Convert.ToInt16(txtFieldSize.Text) > 50)
                    {
                        //LDW RadMessageBox.Show("The size of a text field cannot be more than 50. Please correct it.");

                        DialogResult ds3 = RadMessageBox.Show(this, "The size of a text field cannot be more than 50. Please correct it.", "Update Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds3.ToString();
                        return;
                    }
                }
                else
                {
                    txtFieldSize.Text = "";
                }

                if (cboFieldType.Text == "Time" & string.IsNullOrEmpty(cboDateFields.Text))
                {
                    //LDW RadMessageBox.Show("There has to be a date field associated with this time field. Please define...");

                    DialogResult ds4 = RadMessageBox.Show(this, "There has to be a date field associated with this time field. Please define...", "Update Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds4.ToString();
                    return;
                }

                if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & (string.IsNullOrEmpty(txtMaxSel.Text) | Information.IsNumeric(txtMaxSel.Text) == false))
                {
                    //LDW RadMessageBox.Show("There has to be a max number of selections associated with this field. Please define...");

                    DialogResult ds5 = RadMessageBox.Show(this, "There has to be a max number of selections associated with this field. Please define...", "Update Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds5.ToString();
                    return;
                }


                if (chkMultipleSel.CheckState == 0)
                {
                    //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_Setup_DataDef WHERE ParentDDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value);
                    string tempSql1 = "DELETE FROM tbl_Setup_DataDef WHERE ParentDDID = " + Convert.ToInt32(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, tempSql1);
                }
                else
                {
                    modGlobal.gv_sql = "SELECT Count(DDID) as MaxBefore FROM tbl_Setup_DataDef WHERE ParentDDID = " + Convert.ToInt32(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]);
                    //LDW rsMaxBefore = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "";
                    rsMaxBefore = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, rsMaxBefore);

                    //check to see if there's a change in the number of multiple occurence fields
                    //LDW if (rsMaxBefore["MaxBefore"] != Convert.ToInt16(txtMaxSel.Text))
                    if (Convert.ToInt16(rsMaxBefore.Tables[sqlTableName1].Rows[0]["MaxBefore"]) != Convert.ToInt16(txtMaxSel.Text))
                    {
                        //call stored proc to update
                        modGlobal.gv_sql = string.Format("EXEC ChangeMultipleOccurenceMax {0}, {1}", Convert.ToInt32(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]), txtMaxSel.Text);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    rsMaxBefore.Dispose();
                    rsMaxBefore = null;
                }

                ParentDDID = Convert.ToInt32(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]);
                modGlobal.gv_sql = "update tbl_setup_DataDef SET ";

                if (chkMultipleSel.CheckState == 0)
                {
                    string reftxtFieldName = txtFieldName.Text;
                    modGlobal.gv_sql = string.Format("{0} FieldName = '{1}',", modGlobal.gv_sql, modGlobal.ConvertApastroph(reftxtFieldName));
                }

                modGlobal.gv_sql = string.Format("{0} FieldType =  '{1}',", modGlobal.gv_sql, cboFieldType.Text);
                if (chkInactive.CheckState == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Inactive = null,";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Inactive = 'I',";
                }
                if (string.IsNullOrEmpty(txtFieldSize.Text) | txtFieldSize.Text == "0")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldSize = null,";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} FieldSize = '{1}',", modGlobal.gv_sql, txtFieldSize.Text);
                }
                if (cboFieldType.Text != "Text" | string.IsNullOrEmpty(cbo_LookupTbls.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Lookuptableid = null, ";
                }
                else if (cbo_LookupTbls.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} Lookuptableid = {1}, ", modGlobal.gv_sql, Support.GetItemData(cbo_LookupTbls, cbo_LookupTbls.SelectedIndex));
                }

                if (chkMultipleSel.CheckState == 0)
                {
                    //remove any potential parentddid for the ddid
                    modGlobal.gv_sql = modGlobal.gv_sql + " ParentDDID = NULL, ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} ParentDDID = {1},", modGlobal.gv_sql, ParentDDID);
                }

                string refTxtHelp = txtHelp.Text;
                modGlobal.gv_sql = string.Format("{0} Help = '{1}',", modGlobal.gv_sql, modGlobal.ConvertApastroph(refTxtHelp));
                if (cboDateFields.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateFieldDDID = Null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} DateFieldDDID = {1} ", modGlobal.gv_sql, Support.GetItemData(cboDateFields, cboDateFields.SelectedIndex));
                }
                if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Date/Time" | cboFieldType.Text == "Number")
                {
                    modGlobal.gv_sql = string.Format("{0}, AllowUTD = {1}", modGlobal.gv_sql, chkUTD.CheckState);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + ", AllowUTD = NULL";
                }

                modGlobal.gv_sql = string.Format("{0}, IsPhysician = {1}", modGlobal.gv_sql, chkPhysician.CheckState);
                modGlobal.gv_sql = string.Format("{0}, FieldCategory= '{1}'", modGlobal.gv_sql, Convert.ToBoolean(chkDynamic.CheckState) ? "Dynamic" : "Fix");


                if (cbo_LookupTbls.SelectedIndex > -1 & chkMultipleSel.CheckState == CheckState.Checked & Information.IsNumeric(txtMaxSel.Text) == true)
                {
                    modGlobal.gv_sql = string.Format("{0} where ParentDDID = {1}", modGlobal.gv_sql, Convert.ToInt32(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]));
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Convert.ToInt32(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]));
                }

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //Debug.Print gv_sql
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

        private void RefreshLookupTablesList()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            DataSet rdcLookupTableList = new DataSet();


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
                const string sqlTableName4 = "tbl_Setup_TableDef";
                rdcLookupTableList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, rdcLookupTableList);

                cbo_LookupTbls.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!rdcLookupTableList.Resultset.EOF)
                foreach (DataRow myRow6 in rdcLookupTableList.Tables[sqlTableName4].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    //LDW cbo_LookupTbls.Items.Add(new ListBoxItem(rdcLookupTableList.Resultset.rdoColumns["BaseTable"].Value, rdcLookupTableList.Resultset.rdoColumns["basetableid"].Value));
                    cbo_LookupTbls.Items.Add(string.Format("{0} {1}", myRow6.Field<string>("BaseTable"), myRow6.Field<string>("basetableid")));
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

        private void frmTableEditField_Load(object sender, EventArgs e)
        {
            var rsTemp = new DataSet();
            var rs_Help = new DataSet();
            //LDW object rdUseclient = null;

            this.CenterToParent();
            //If Not IsNull(frmTableSetup.rdcFieldList.Resultset!FieldOrder) Then
            //    txtFieldOrder = frmTableSetup.rdcFieldList.Resultset!FieldOrder
            //End If

            try
            {
                txtFieldName.Text = frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["FieldName"].ToString();
                if (frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["Inactive"].ToString() == "I")
                {
                    chkInactive.CheckState = CheckState.Checked;
                }
                else
                {
                    chkInactive.CheckState = CheckState.Unchecked;
                }

                if (!Information.IsDBNull(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["FieldType"]))
                {
                    cboFieldType.Text = frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["FieldType"].ToString();
                    if (cboFieldType.Text == "Text")
                    {
                        if (!Information.IsDBNull(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["FieldSize"]))
                        {
                            txtFieldSize.Text = frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["FieldSize"].ToString();
                        }
                        txtFieldSize.Visible = true;
                        lblFieldSize.Visible = true;
                    }
                }

                //LDW RDO.CursorDriverConstants ld_Restore = default(RDO.CursorDriverConstants);

                if (!Information.IsDBNull(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["help"]))
                {
                    //txtHelp.Text = frmTableSetup.dbgFieldList.Columns(5)

                    //LDW ld_Restore = RDOrdoEngine_definst.rdoDefaultCursorDriver;
                    //LDW RDOrdoEngine_definst.rdoDefaultCursorDriver = rdUseclient;

                    modGlobal.gv_sql = "SELECT Help FROM tbl_Setup_DataDef where DDID = " + Convert.ToInt32(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]);
                    //LDW rs_Help = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_Setup_DataDef";
                    rs_Help = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, rs_Help);

                    //LDW txtHelp.Text = rs_Help.rdoColumns["help"].Value + "";
                    txtHelp.Text = rs_Help.Tables[sqlTableName7].Rows[0]["help"].ToString();
                    rs_Help.Dispose();
                    rs_Help = null;
                    //LDW RDOrdoEngine_definst.rdoDefaultCursorDriver = ld_Restore;
                }

                if (frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["FieldCategory"].ToString() == "Fix")
                {
                    //txtFieldOrder.Enabled = False
                    txtFieldName.Enabled = false;
                    cboFieldType.Enabled = false;
                    txtFieldSize.Enabled = false;
                    //txtHelp.Enabled = False
                }
                else
                {
                    chkDynamic.CheckState = CheckState.Checked;
                }

                RefreshLookupTablesList();
                if (cboFieldType.Text == "Text")
                {
                    RefreshLookupTable();
                    cbo_LookupTbls.Visible = true;
                    lblLookupTable.Visible = true;
                }
                else
                {
                    cbo_LookupTbls.Visible = false;
                    lblLookupTable.Visible = false;
                }

                RefreshDateFieldList();
                if (cboFieldType.Text == "Time")
                {
                    RefreshDateField();
                    cboDateFields.Visible = true;
                    lblDateFields.Visible = true;
                }
                else
                {
                    cboDateFields.Visible = false;
                    lblDateFields.Visible = false;
                }

                if (!Information.IsDBNull(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["ParentDDID"]))
                {
                    chkMultipleSel.Enabled = true;
                    chkMultipleSel.CheckState = CheckState.Checked;
                    txtMaxSel.Enabled = true;

                    //LDW rsTemp = modGlobal.gv_cn.OpenResultset("SELECT COUNT(*) maxcnt FROM tbl_Setup_DataDef WHERE ParentDDID = " + My.MyProject.Forms.frmTableSetup.rdcFieldList.Resultset.rdoColumns["DDID"].Value, RDO.ResultsetTypeConstants.rdOpenStatic);
                    string tempSql3 = "SELECT COUNT(*) maxcnt FROM tbl_Setup_DataDef WHERE ParentDDID = " + frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"];
                    rsTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, tempSql3, rsTemp);
                    //LDW txtMaxSel.Text = Convert.ToString(rsTemp["maxcnt"]);
                    txtMaxSel.Text = rsTemp.Tables[tempSql3].Rows[0]["maxcnt"].ToString();

                    rsTemp.Dispose();
                    rsTemp = null;
                }

                if (cboFieldType.Text == "Time" | cboFieldType.Text == "Date" | cboFieldType.Text == "Number" | cboFieldType.Text == "Date/Time")
                {
                    chkUTD.Visible = true;
                    chkUTD.Checked = (Information.IsDBNull(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["AllowUTD"]) ? false :
                        (Convert.ToBoolean(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["AllowUTD"])) == true ? true : false);
                }
                else
                {
                    chkUTD.Visible = false;
                }

                if (!Information.IsDBNull(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["IsPhysician"]))
                {
                    chkPhysician.Checked = (Convert.ToBoolean(frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["IsPhysician"]) ? true : false);
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

        public void RefreshDateFieldList()
        {
            frmTableSetup frmTableSetupCopy = new frmTableSetup();
            var LIndex = 0;


            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID =  {1}", modGlobal.gv_sql, Support.GetItemData(frmTableSetupCopy.cboTableList, frmTableSetupCopy.cboTableList.SelectedIndex));
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
                const string sqlTableName8 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //Display the list of fields
                cboDateFields.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    LIndex = LIndex + 1;
                    cboDateFields.Items.Add(myRow8.Field<string>("FieldName"));
                    cboDateFields.Items.Add(myRow8.Field<string>("DDID"));
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

        private void RefreshLookupTable()
        {
            var i = 0;

            try
            {
                modGlobal.gv_sql = "Select LookupTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.RowCount == 0)
                if (modGlobal.gv_rs.Tables[sqlTableName9].Rows.Count == 0)
                {
                    cbo_LookupTbls.Text = "";
                    cbo_LookupTbls.SelectedIndex = -1;
                }
                else
                {
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["LookupTableID"]))
                    {

                        for (i = 0; i <= cbo_LookupTbls.Items.Count - 1; i++)
                        {
                            if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["LookupTableID"]) == Support.GetItemData(cbo_LookupTbls, i))
                            {
                                cbo_LookupTbls.SelectedIndex = i;
                            }
                        }
                    }
                    else
                    {
                        cbo_LookupTbls.Text = "";
                        cbo_LookupTbls.SelectedIndex = -1;
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

        public void RefreshDateField()
        {
            var i = 0;

            try
            {
                modGlobal.gv_sql = "Select DateFieldDDID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, frmTableSetup.rdcFieldList.Tables[sqlTableName0].Rows[0]["DDID"]);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count == 0)
                {
                    cboDateFields.Text = "";
                    cboDateFields.SelectedIndex = -1;
                }
                else
                {
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["DateFieldDDID"]))
                    {
                        for (i = 0; i <= cboDateFields.Items.Count - 1; i++)
                        {
                            if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["DateFieldDDID"]) == Support.GetItemData(cboDateFields, i))
                            {
                                cboDateFields.SelectedIndex = i;
                            }
                        }
                    }
                    else
                    {
                        cboDateFields.Text = "";
                        cboDateFields.SelectedIndex = -1;
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
    }
}
