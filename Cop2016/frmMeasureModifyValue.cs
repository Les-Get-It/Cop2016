using Microsoft.VisualBasic;
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
    public partial class frmMeasureModifyValue : Telerik.WinControls.UI.RadForm
    {
        int mcid = 0;
        string selectedfieldtype;
        string selectedfieldname;
        string selectedcritfieldoperator;

        public frmMeasureModifyValue()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void chkBlank_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBlank.CheckState == CheckState.Checked)
                {
                    txtTypeinValue.Text = "";
                    cboDateUnit.Text = "";
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (sstMethods0.Enabled == true)
                {
                    if (string.IsNullOrEmpty(txtTypeinValue.Text) & chkBlank.CheckState == 0)
                    {
                        RadMessageBox.Show("Please define a value before updating the criteria");
                    }
                    else if (chkBlank.CheckState == CheckState.Checked)
                    {
                        modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set fieldvalue = 'Null' ";
                        modGlobal.gv_sql = modGlobal.gv_sql + ", dateunit = null ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    else
                    {
                        //If (mid(selectedfieldtype, 1, 3) = "Num" Or selectedcritfieldoperator <> "") And Not IsNumeric(txtTypeinValue) Then
                        if ((Strings.Mid(selectedfieldtype, 1, 3) == "Num" | !string.IsNullOrEmpty(selectedcritfieldoperator)) &
                            !Information.IsNumeric(txtTypeinValue.Text) & Strings.UCase(Strings.Trim(txtTypeinValue.Text)) != "UTD")
                        {
                            RadMessageBox.Show(selectedfieldname + " is a numeric field, but the value is not a number. Please re-Specify...");
                            return;
                        }

                        if ((Strings.Mid(selectedfieldtype, 1, 3) == "Dat" | Strings.Mid(selectedfieldtype, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtTypeinValue.Text)) == "UTD")
                        {
                            //this is OK
                        }
                        else
                        {
                            if (Strings.Mid(selectedfieldtype, 1, 3) == "Dat" & string.IsNullOrEmpty(selectedcritfieldoperator) & !Information.IsDate(txtTypeinValue.Text))
                            {
                                RadMessageBox.Show(selectedfieldname + " is a date field, but the value is not a date. Please re-Specify...");
                                return;
                            }
                            if (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" & string.IsNullOrEmpty(selectedcritfieldoperator) & (Strings.Len(txtTypeinValue.Text) != 5))
                            {
                                RadMessageBox.Show(selectedfieldname + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                                return;
                            }
                            if (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" & string.IsNullOrEmpty(selectedcritfieldoperator) & ((!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 1, 1))) |
                                (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 2, 1))) | (Strings.Mid(txtTypeinValue.Text, 3, 1) != ":") |
                                (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 5, 1)))))
                            {
                                RadMessageBox.Show(selectedfieldname + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                                return;
                            }
                            if (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" & string.IsNullOrEmpty(selectedcritfieldoperator) &
                                (Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 4, 2)) > 59))
                            {
                                RadMessageBox.Show(selectedfieldname + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                                return;
                            }
                        }

                        if ((!Information.IsDBNull(selectedcritfieldoperator) & !string.IsNullOrEmpty(selectedcritfieldoperator)) &
                            (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" | Strings.Mid(selectedfieldtype, 1, 3) == "Dat"))
                        {
                            if (string.IsNullOrEmpty(cboDateUnit.Text))
                            {
                                RadMessageBox.Show(selectedfieldname + " is a Date/Time field. Please select a date unit");
                                return;
                            }
                        }
                        else
                        {
                            cboDateUnit.Text = "";
                        }

                        modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} set fieldvalue = '{1}' ", modGlobal.gv_sql, txtTypeinValue.Text);
                        if (!string.IsNullOrEmpty(cboDateUnit.Text))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + ", dateunit = ";
                            switch (cboDateUnit.Text)
                            {
                                case "Years":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'YYYY' ";
                                    break;
                                case "Months":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'm' ";
                                    break;
                                case "Days":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'd' ";
                                    break;
                                case "Hours":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'h' ";
                                    break;
                                case "Minutes":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'n' ";
                                    break;
                                case "Seconds":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 's' ";
                                    break;
                            }
                        }
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }
                else if (sstMethods1.Enabled == true)
                {
                    modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
                    modGlobal.gv_sql = string.Format("{0} set destddid = {1}", modGlobal.gv_sql, Support.GetItemData(cboDestField, cboDestField.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }
                else if (sstMethods2.Enabled == true)
                {
                    modGlobal.gv_sql = "Select thislookupid = ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " case when td.comparetodesc = 'Yes' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " then  ml.fieldvalue ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " else ml.id ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " end ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ml ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_tabledef td on td.basetableid = ml.basetableid ";
                    modGlobal.gv_sql = string.Format("{0} where ml.lookupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
                    modGlobal.gv_sql = string.Format("{0} set fieldvalue = '{1}'", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["thislookupid"]);
                    modGlobal.gv_sql = string.Format("{0} , lookupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }
                else if (sstMethods3.Enabled == true)
                {
                    modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set ";
                    modGlobal.gv_sql = string.Format("{0}  lookupTableid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                modGlobal.UpdateVerificationCriteriaTitle(mcid);


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

        public void setMeasureCriteriaID(int measureCriteriaID)
        {
            mcid = measureCriteriaID;
            try
            {
                SelectTab();
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

        private void frmMeasureModifyValue_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        public void SelectTab()
        {
            int DestDDID = 0;

            try
            {
                sstMethods0.Enabled = false;
                sstMethods1.Enabled = false;
                sstMethods2.Enabled = false;
                sstMethods3.Enabled = false;
                cboDateUnit.Enabled = false;

                modGlobal.gv_sql = "select mc.*, dd.fieldname, dd.fieldtype from tbl_Setup_MeasureCriteria mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mc.ddid1 = dd.ddid ";
                modGlobal.gv_sql = string.Format("{0} where mc.MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                selectedfieldtype = modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["FieldType"].ToString();
                selectedfieldname = modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["FieldName"].ToString();
                selectedcritfieldoperator = modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["FieldOperator"].ToString();

                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["ddid2"]) & Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["DestDDID"]) &
                    Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["LookupID"]) & Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["LookupTableID"]))
                {
                    sstMethods0.Enabled = true;
                    sstMethods.ActiveWindow = sstMethods0;
                }
                else if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["FieldOperator"]))
                {
                    cboDateUnit.Enabled = true;
                    sstMethods0.Enabled = true;
                    sstMethods.ActiveWindow = sstMethods0;
                }
                else if ((!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["ddid2"]) & (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["DestDDID"]))))
                {
                    RefreshFieldList();
                    sstMethods1.Enabled = true;
                    sstMethods.ActiveWindow = sstMethods1;
                }
                else if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["LookupID"]))
                {
                    RefreshLookupList();
                    sstMethods2.Enabled = true;
                    sstMethods.ActiveWindow = sstMethods2;
                }
                else if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName3].Rows[0]["LookupTableID"]))
                {
                    RefreshLookupTableList();
                    sstMethods3.Enabled = true;
                    sstMethods.ActiveWindow = sstMethods3;
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

        public void RefreshFieldList()
        {
            try
            {
                modGlobal.gv_sql = "select dd.fieldtype from tbl_Setup_MeasureCriteria  mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef dd on mc.ddid1 = dd.ddid ";
                modGlobal.gv_sql = string.Format("{0} where mc.MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                modGlobal.gv_sql = string.Format("{0} and dd.fieldtype = '{1}'", modGlobal.gv_sql, selectedfieldtype);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);


                //retrieve the list of table fields

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef dd ";
                modGlobal.gv_sql = string.Format("{0} WHERE fieldtype = '{1}'", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["FieldType"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (ParentDDID IS NULL OR ParentDDID = DDID) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                //Display the list of fields
                cboDestField.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    cboDestField.Items.Add(new ListBoxItem(myRow5.Field<string>("FieldName"), myRow5.Field<int>("DDID")).ToString());
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

        public void RefreshLookupList()
        {
            string LookupTableID = null;


            try
            {
                cboLookupValues.Items.Clear();

                modGlobal.gv_sql = "Select dd.Lookuptableid from tbl_setup_DataDef dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureCriteria  mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = mc.ddid1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where dd.Lookuptableid is not null ";
                modGlobal.gv_sql = string.Format("{0} and mc.MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count > 0)
                {
                    LookupTableID = modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["LookupTableID"].ToString();

                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                    {
                        cboLookupValues.Items.Add(new ListBoxItem("(" + myRow7.Field<string>("Id") + ") " + myRow7.Field<string>("FIELDVALUE"), myRow7.Field<int>("LookupID")).ToString());
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
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

        public void RefreshLookupTableList()
        {
            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                cboLookupTables.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    cboLookupTables.Items.Add(new ListBoxItem(myRow8.Field<string>("BaseTable"), myRow8.Field<int>("basetableid")).ToString());

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

        private void txtTypeinValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTypeinValue.Text))
                {
                    chkBlank.CheckState = CheckState.Unchecked;
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
