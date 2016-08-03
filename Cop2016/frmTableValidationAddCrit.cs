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
    public partial class frmTableValidationAddCrit : Telerik.WinControls.UI.RadForm
    {
        int thismessageid;
        const string rdcValidationErrorsTable = "tbl_setup_TableValidationMessage";
        const string rdcValidationWarningsTable = "tbl_setup_TableValidationMessage";



        public frmTableValidationAddCrit()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboDestFieldList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string cboOpt1Unit = null;

            try
            {
                if (cboDestFieldList.SelectedIndex > 0)
                {
                    chkBlank.CheckState = CheckState.Unchecked;
                    txtOpt1TypeinValue.Text = "";
                    cboOpt1Unit = "";
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

        private void cboSet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshSetDef();
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

        private void chkBlank_CheckStateChanged(object sender, EventArgs e)
        {
            string cboOpt1Unit = null;

            try
            {
                if (chkBlank.CheckState == CheckState.Checked)
                {
                    txtOpt1TypeinValue.Text = "";
                    cboOpt1Unit = "";
                    cboDestFieldList.SelectedIndex = -1;
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
            try
            {
                //LDW if (sstabOptions.TabPages[0].Enabled == false & sstabOptions.TabPages[1].Enabled == false & sstabOptions.TabPages[2].Enabled == false & sstabOptions.TabPages[3].Enabled == false & !sstabOptions.TabPages[4].Enabled)
                if (sstabOptions.Enabled == false)
                {
                    //LDW RadMessageBox.Show("Please select a method.");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please select a method.", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }

                if (lstField1List.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select a field from the list");

                    DialogResult ds2 = RadMessageBox.Show(this, "Please select a field from the list", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                    return;
                }

                if (cboSet.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the Criteria Set.");

                    DialogResult ds3 = RadMessageBox.Show(this, "Please select the Criteria Set.", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");

                    DialogResult ds4 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the existing ones.", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds4.ToString();
                    return;
                }

                //LDW if (sstabOptions.TabPages[0].Enabled == true)
                if (sstabOptions.DocumentManager.ActiveDocument == sstabOptionsMethod1)
                {
                    modGlobal.gv_sql = "Select LookupTableID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_DataDef  ";
                    modGlobal.gv_sql = string.Format("{0}Where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                    if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & !Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["LookupTableID"]))
                    {
                        //LDW RadMessageBox.Show("This field is linked to a lookup table. Select Method 2 to compare it against a lookup value.");

                        DialogResult ds5 = RadMessageBox.Show(this, "This field is linked to a lookup table. Select Method 2 to compare it against a lookup value.", "Add", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds5.ToString();
                        return;
                    }
                    AddCriteriaWithMethod1();
                }
                //LDW else if (sstabOptions.TabPages[1].Enabled == true)
                else if (sstabOptions.DocumentManager.ActiveDocument == sstabOptionsMethod2)
                {
                    AddCriteriaWithMethod2();
                }
                //LDW else if (sstabOptions.TabPages[2].Enabled == true)
                else if (sstabOptions.DocumentManager.ActiveDocument == sstabOptionsMethod3)
                {
                    AddCriteriaWithMethod3();
                }
                //LDW else if (sstabOptions.TabPages[3].Enabled == true)
                else if (sstabOptions.DocumentManager.ActiveDocument == sstabOptionsMethod4)
                {
                    AddCriteriaWithMethod4();
                }
                else if (sstabOptions.DocumentManager.ActiveDocument == sstabOptionsMethod5)
                {
                    AddCriteriaWithMethod5();
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

        private void cmdAddVal_Click(object sender, EventArgs e)
        {
            string ls_add = null;
            var rsIsValid = new DataSet();
            //LDW EditCat:


            try
            {
                //LDW ls_add = RadInputBox.Show("Enter a valid month value.", "Add Values", "");
                ls_add = RadInputBox.Show("Enter a valid month value.", "Add Values", "");

                if (Strings.Len(ls_add) == 0)
                    return;

                modGlobal.gv_sql = string.Format("SELECT MONTH('{0}/1/2000')", ls_add);
                //LDW rsIsValid = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "Temp1";
                rsIsValid = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, rsIsValid);

                int rsIsValidCount = rsIsValid.Tables[sqlTableName2].Rows.Count;
                for (int i = 0; i < rsIsValidCount; i++)
                {
                    DataRow myRow = rsIsValid.Tables[sqlTableName2].Rows[i];

                    //LDW if (rsIsValid.EOF)
                    if (i == rsIsValidCount - 1)
                    {
                        //LDW RadMessageBox.Show("Please Enter A Valid Month", MsgBoxStyle.Critical, "Invalid Month");

                        DialogResult ds6 = RadMessageBox.Show(this, "Please Enter A Valid Month", "Add Values", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds6.ToString();
                        //LDW goto EditCat;
                    }
                    else
                    {
                        lstRange.Items.Add(ls_add);
                    }
                }
                rsIsValid.Dispose();
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

        public void RefreshDestFieldList()
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
                const string sqlTableName3 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                cboDestFieldList.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    LIndex = LIndex + 1;
                    Field_ListIndex = LIndex;

                    cboDestFieldList.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());

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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRange.SelectedIndex < 0)
                {
                    return;
                }
                lstRange.Items.RemoveAt((lstRange.SelectedIndex));
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

        private void frmTableValidationAddCrit_Load(object sender, EventArgs e)
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            string thismessage = null;

            this.CenterToParent();

            try
            {
                if (Strings.UCase(modGlobal.gv_Action) == "ERROR")
                {
                    thismessage = frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["Message"].ToString();
                    thismessageid = Convert.ToInt32(frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                else
                {
                    thismessage = frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["Message"].ToString();
                    thismessageid = Convert.ToInt32(frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                }

                lblMessage.Text = string.Format("Setup criteria for this {0} Message: {1}", modGlobal.gv_Action, thismessage);

                //LDW sstabOptions.SelectedIndex = 0;
                sstabOptions.ActiveWindow.DockTabStrip.SelectedIndex = 0;
                //LDW sstabOptions.TabPages[0].Enabled = false;
                sstabOptionsMethod1.ActiveControl.Enabled = false;
                // LDW sstabOptions.TabPages[1].Enabled = false;
                sstabOptionsMethod2.ActiveControl.Enabled = false;
                //LDW sstabOptions.TabPages[2].Enabled = false;
                sstabOptionsMethod3.ActiveControl.Enabled = false;
                Opt1Method.IsChecked = false;
                Opt2Method.IsChecked = false;
                Opt3Method.IsChecked = false;
                Opt4Method.IsChecked = false;
                Opt5Method.IsChecked = false;

                if (Strings.UCase(modGlobal.gv_Action) == "ERROR" & frmTableValidationSetupCopy.lstErrorCriteriaSet.Items.Count > 0)
                {
                    lblJoinOperator.Visible = true;
                    cboJoinOperator.Visible = true;
                }
                else if (Strings.UCase(modGlobal.gv_Action) == "WARNING" & frmTableValidationSetupCopy.lstWarningCriteriaSet.Items.Count > 0)
                {
                    lblJoinOperator.Visible = true;
                    cboJoinOperator.Visible = true;
                }

                RefreshFieldsList();
                RefreshDestFieldList();
                //    RefreshLookupList
                RefreshSetList();
                RefreshLookupTables();
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


            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_TableDef";
                cboLookupTables.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    cboLookupTables.Items.Add(new ListBoxItem(myRow4.Field<string>("BaseTable"), myRow4.Field<int>("basetableid")).ToString());
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

        public void AddCriteriaWithMethod1()
        {
            string CritTitle = null;
            int NewCritID = 0;
            string DestFieldType = null;
            string field1type = null;

            try
            {
                if (cboOpt1ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list");

                    DialogResult ds8 = RadMessageBox.Show(this, "Please select the field operation from the list", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds8.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboDestFieldList.SelectedIndex < 0 & chkBlank.CheckState == 0 & chkMidnight.CheckState == 0)
                {
                    //LDW RadMessageBox.Show("Either select a field, or check the blank, or type in a a value.");

                    DialogResult ds9 = RadMessageBox.Show(this, "Either select a field, or check the blank, or type in a a value.", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds9.ToString();
                    return;
                }


                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");

                    DialogResult ds9 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the existing ones.", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds9.ToString();
                    return;
                }
                short li_cnt = 0;

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                {
                    //LDW if (lstField1List.GetSelected(li_cnt))
                    if (lstField1List.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName5 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        if (chkMidnight.Checked & field1type != "Date/Time")
                        {
                            //LDW RadMessageBox.Show("If 00:00 is selected then it can only be compared to a Date/Time field.");

                            DialogResult ds10 = RadMessageBox.Show(this, "If 00:00 is selected then it can only be compared to a Date/Time field.", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds10.ToString();
                            return;
                        }

                        if (cboDestFieldList.SelectedIndex > -1)
                        {
                            //find the Dest field type
                            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                            modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex));
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName6 = "tbl_setup_Datadef";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                            DestFieldType = modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["FieldType"].ToString();
                            modGlobal.gv_rs.Dispose();

                            if (field1type != DestFieldType)
                            {
                                //LDW RadMessageBox.Show("The data types of the selected fields don't match. Please re-Specify...");

                                DialogResult ds10 = RadMessageBox.Show(this, "The data types of the selected fields don't match. Please re-Specify...", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                                this.Text = ds10.ToString();
                                return;
                            }
                        }


                        //make sure that the typed value is of the same type as the field type
                        if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                        {
                            //If mid(field1type, 1, 3) = "Num" And Not IsNumeric(txtOpt1TypeinValue) Then
                            if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD")
                            {
                                //LDW RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");

                                DialogResult ds11 = RadMessageBox.Show(this, "The selected field is a numeric field, but the value is not a number. Please re-Specify...", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                                this.Text = ds11.ToString();
                                return;
                            }

                            if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) == "UTD")
                            {
                                //this is OK
                            }
                            else
                            {
                                if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text))
                                {
                                    //LDW RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");

                                    DialogResult ds12 = RadMessageBox.Show(this, "The selected field is a date field, but the value is not a date. Please re-Specify...", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                                    this.Text = ds12.ToString();
                                    return;
                                }
                                if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5))
                                {
                                    //LDW RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");

                                    DialogResult ds13 = RadMessageBox.Show(this, "The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                                    this.Text = ds13.ToString();
                                    return;
                                }
                                if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1)))))
                                {
                                    //LDW RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");

                                    DialogResult ds14 = RadMessageBox.Show(this, "The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                                    this.Text = ds14.ToString();
                                    return;
                                }
                                if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59))
                                {
                                    //LDW RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");

                                    DialogResult ds15 = RadMessageBox.Show(this, "The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...", "Method 1 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                                    this.Text = ds15.ToString();
                                    return;
                                }
                            }
                        }



                        NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_TableValidation", "TableValidationID");

                        CritTitle = string.Format("{0} {1}", Support.GetItemString(lstField1List, li_cnt), cboOpt1ValueOperator.Text);

                        if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                        {
                            CritTitle = string.Format("{0} {1}", CritTitle, txtOpt1TypeinValue.Text);
                        }
                        if (cboDestFieldList.SelectedIndex > -1)
                        {
                            CritTitle = string.Format("{0} {1}", CritTitle, cboDestFieldList.Text);
                        }
                        if (chkBlank.CheckState == CheckState.Checked)
                        {
                            CritTitle = CritTitle + " Blank ";
                        }
                        if (chkMidnight.Checked)
                        {
                            CritTitle = CritTitle + " 00:00";
                        }

                        modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, DestDDID, ValueOperator, Value, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, JoinOperator,CriteriaSet)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, thismessageid);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        if (cboDestFieldList.SelectedIndex > -1)
                        {
                            modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex));
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                        }
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt1ValueOperator.Text);
                        if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                        {
                            modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt1TypeinValue.Text);
                        }
                        else if (chkBlank.CheckState == CheckState.Checked)
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
                        }
                        else if (chkMidnight.Checked)
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " '00:00', ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                        }

                        if (chkMidnight.Checked)
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'Hour',";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                        }
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + ")";

                        //g = InputBox("", "", gv_sql)
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    }
                }
                UpdateMainJoinOp();
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
            string CritTitle = null;
            int NewCritID = 0;
            string field1type = null;
            int li_cnt = 0;
            string IDFromLookup = null;
            string fieldLookupTableID = " Null ";

            try
            {
                if (cboOpt2ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list");

                    DialogResult ds16 = RadMessageBox.Show(this, "Please select the field operation from the list", "Method 2 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds16.ToString();
                    return;
                }
                if (cboLookupValues.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Select lookup value from list.");

                    DialogResult ds17 = RadMessageBox.Show(this, "Select lookup value from list.", "Method 2 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds17.ToString();
                    return;
                }
                else
                {
                    modGlobal.gv_sql = "Select *   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                    modGlobal.gv_sql = string.Format("{0} Where lookupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_setup_Misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    IDFromLookup = modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["Id"].ToString();
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");

                    DialogResult ds18 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the existing ones.", "Method 2 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds18.ToString();
                    return;
                }

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                {
                    if (lstField1List.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName8 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        //make sure that the field type is not a date field
                        if (Strings.Mid(field1type, 1, 3) == "Dat")
                        {
                            //LDW RadMessageBox.Show("You cannot compare this field to a lookup value, because the selected field is a date field. Please re-Specify...");

                            DialogResult ds19 = RadMessageBox.Show(this, "You cannot compare this field to a lookup value, because the selected field is a date field. Please re-Specify...", "Method 2 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds19.ToString();
                            return;
                        }

                        NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_TableValidation", "TableValidationID");

                        CritTitle = string.Format("{0} {1} {2}", Support.GetItemString(lstField1List, li_cnt), cboOpt2ValueOperator.Text, cboLookupValues.Text);
                        //Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

                        modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " TableValidationMessageID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";

                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, thismessageid);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt2ValueOperator.Text);
                        modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, IDFromLookup);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + ")";

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }

                UpdateMainJoinOp();
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
            string CritTitle = null;
            int NewCritID = 0;
            string field1type = null;
            int li_cnt = 0;

            try
            {

                if (cboOpLkTable.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the operator from the list.");

                    DialogResult ds20 = RadMessageBox.Show(this, "Please select the operator from the list.", "Method 3 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds20.ToString();
                    return;
                }

                if (cboLookupTables.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select a Lookup Table from the list.");

                    DialogResult ds21 = RadMessageBox.Show(this, "Please select a Lookup Table from the list.", "Method 3 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds21.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");

                    DialogResult ds22 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the existing ones.", "Method 3 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds22.ToString();
                    return;
                }


                for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                {
                    if (lstField1List.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName9 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        if (Strings.UCase(Strings.Mid(field1type, 1, 3)) == "DAT" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "TIM" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "NUM")
                        {
                            //LDW RadMessageBox.Show("A date, time or numeric field can not be compared to a lookup table. Please re-Specify...");

                            DialogResult ds23 = RadMessageBox.Show(this, "A date, time or numeric field can not be compared to a lookup table. Please re-Specify...", "Method 3 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds23.ToString();
                            return;
                        }

                        NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_TableValidation", "TableValidationID");

                        CritTitle = string.Format("{0} {1} [{2}] Lookup Table ", Support.GetItemString(lstField1List, li_cnt), cboOpLkTable.Text, cboLookupTables.Text);
                        //Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

                        modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Fieldoperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, thismessageid);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpLkTable.Text);
                        modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + ")";

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }
                UpdateMainJoinOp();
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

        public void AddCriteriaWithMethod4()
        {
            string CritTitle = null;
            int NewCritID = 0;
            string Field2Type = null;
            string field1type = null;
            int li_cnt = 0;

            try
            {

                if (cboFieldOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the Add/Subtract operation from the list.");

                    DialogResult ds24 = RadMessageBox.Show(this, "Please select the Add/Subtract operation from the list.", "Method 4 Criteria",
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds24.ToString();
                    return;
                }

                if (cboField2List.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the second Field from the list.");

                    DialogResult ds25 = RadMessageBox.Show(this, "Please select the second Field from the list.", "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds25.ToString();
                    return;
                }

                if (cboOpt3ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list.");

                    DialogResult ds26 = RadMessageBox.Show(this, "Please select the field operation from the list.", "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds26.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt3TypeinValue.Text))
                {
                    //LDW RadMessageBox.Show("A value should be typed in.");

                    DialogResult ds27 = RadMessageBox.Show(this, "A value should be typed in.", "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds27.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");

                    DialogResult ds28 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the existing ones.",
                        "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds28.ToString();
                    return;
                }

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                {
                    if (lstField1List.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName10 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        if (Strings.UCase(Strings.Mid(field1type, 1, 3)) != "DAT" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "TIM" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "NUM")
                        {
                            //LDW RadMessageBox.Show("Only a date, time or numeric field can be selected for this method. Please re-Specify...");

                            DialogResult ds29 = RadMessageBox.Show(this, "Only a date, time or numeric field can be selected for this method. Please re-Specify...",
                                "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds29.ToString();
                            return;
                        }

                        //make sure that the 2 selected fields are of the same type
                        if (!string.IsNullOrEmpty(cboField2List.Text))
                        {
                            //find the field type
                            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                            modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName11 = "tbl_setup_Datadef";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                            Field2Type = modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["FieldType"].ToString();
                            modGlobal.gv_rs.Dispose();
                            if (field1type != Field2Type & Field2Type != "Date/Time")
                            {
                                //LDW RadMessageBox.Show("The 2 fields that you have selected are not of the same type. Please re-specify...");

                                DialogResult ds30 = RadMessageBox.Show(this, "A value should be typed in.", "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                                this.Text = ds30.ToString();
                                return;
                            }
                        }

                        //make sure that the typed value is numeric
                        if (!Information.IsNumeric(txtOpt3TypeinValue.Text))
                        {
                            //LDW RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");

                            DialogResult ds31 = RadMessageBox.Show(this, "The typed value has to be a numeric value. Please re-Specify...", "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds31.ToString();
                            return;
                        }

                        if (field1type == "Date" & cboFieldOperator.Text != "-")
                        {
                            //LDW RadMessageBox.Show("Date fields can only be subtracted from eachother.");

                            DialogResult ds32 = RadMessageBox.Show(this, "Date fields can only be subtracted from eachother.", "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds32.ToString();
                            return;
                        }

                        if (field1type == "Date" & string.IsNullOrEmpty(cboOpt3Unit.Text))
                        {
                            //LDW RadMessageBox.Show("Please define the date unit associated with the value");

                            DialogResult ds33 = RadMessageBox.Show(this, "Please define the date unit associated with the value", "Method 4 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds33.ToString();
                            return;
                        }

                        NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_TableValidation", "TableValidationID");

                        CritTitle = Support.GetItemString(lstField1List, li_cnt);
                        CritTitle = string.Format("{0} {1} {2}", CritTitle, cboFieldOperator.Text, cboField2List.Text);
                        CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3ValueOperator.Text);
                        CritTitle = string.Format("{0} {1}", CritTitle, txtOpt3TypeinValue.Text);
                        if (field1type == "Date" | field1type == "Time" | field1type == "Date/Time")
                        {
                            CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3Unit.Text);
                        }

                        modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, ValueOperator, Value, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "  Fieldoperator, DateUnit, JoinOperator, CriteriaSet)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, thismessageid);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt3ValueOperator.Text);
                        modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt3TypeinValue.Text);
                        modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, cboFieldOperator.Text);
                        if (!string.IsNullOrEmpty(cboOpt3Unit.Text))
                        {
                            switch (cboOpt3Unit.Text)
                            {
                                case "Years":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'YYYY',";
                                    break;
                                case "Months":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
                                    break;
                                case "Days":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'd',";
                                    break;
                                case "Minutes":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'n',";
                                    break;
                            }
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                        }
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + ")";

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }

                UpdateMainJoinOp();
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

        private void AddCriteriaWithMethod5()
        {
            int NewCritID = 0;
            string field1type = null;
            string Field2Type = null;
            string CritTitle = null;
            //Dim li_order AS Long
            int li_CriteriaSetID = 0;
            int li_cnt = 0;
            int li_cnt2 = 0;
            string[] ls_months = null;

            //3.17.2005 - added method 5

            try
            {
                if (cboOpt5ValueOperator.SelectedIndex < 0)
                {
                    //LDW RadMessageBox.Show("Please select the field operation from the list.");

                    DialogResult ds34 = RadMessageBox.Show(this, "Please select the field operation from the list.", "Method 5 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds34.ToString();
                    return;
                }

                if (lstRange.Items.Count == 0)
                {
                    //LDW RadMessageBox.Show("Value(s) should be typed in.");

                    DialogResult ds35 = RadMessageBox.Show(this, "Value(s) should be typed in.", "Method 5 Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds35.ToString();
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    //LDW RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the existing ones.");

                    DialogResult ds36 = RadMessageBox.Show(this, "Please select the Join Type; the option that defines how to add this criteria to the existing ones.", "Method 5 Criteria",
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds36.ToString();
                    return;
                }


                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                {
                    if (lstField1List.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName12 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName12].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();
                        if (field1type != "Date")
                        {
                            //LDW RadMessageBox.Show("This method is only valid with date fields", MsgBoxStyle.Critical, "Field is not a date");

                            DialogResult ds37 = RadMessageBox.Show(this, "This method is only valid with date fields", "Field is not a date", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds37.ToString();
                            return;
                        }

                        for (li_cnt2 = 0; li_cnt2 <= lstRange.Items.Count - 1; li_cnt2++)
                        {
                            Array.Resize(ref ls_months, li_cnt2 + 1);
                            ls_months[li_cnt2] = Support.GetItemString(lstRange, li_cnt2);
                        }

                        modGlobal.gv_Action = "Add";

                        CritTitle = Support.GetItemString(lstField1List, li_cnt);
                        CritTitle = string.Format("{0} Month {1}", CritTitle, cboOpt5ValueOperator.Text);
                        CritTitle = string.Format("{0} ({1})", CritTitle, Strings.Join(ls_months, ","));
                        NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_TableValidation", "TableValidationID");

                        modGlobal.gv_sql = "Insert into tbl_Setup_Tablevalidation ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (TablevalidationID, TableValidationMessageID, CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, ValueOperator, Value, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "  DateUnit, JoinOperator, CriteriaSet)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, thismessageid);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt5ValueOperator.Text);
                        modGlobal.gv_sql = string.Format("{0} '({1})',", modGlobal.gv_sql, Strings.Join(ls_months, ","));
                        modGlobal.gv_sql = modGlobal.gv_sql + "'m', ";
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + ")";

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        try
                        {
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                        catch (Exception ex)
                        {
                            DialogResult ds38 = RadMessageBox.Show(this, "Opps something went wrong: " + ex.Message, "Field is not a date", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds38.ToString();
                        }
                    }
                }

                UpdateMainJoinOp();
                modGlobal.gv_Action = "Add";
                this.Close();
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        public void RefreshSetDef()
        {
            try
            {
                if (cboSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_TableValidation ";
                modGlobal.gv_sql = string.Format("{0} where TableValidationMessageID = {1}", modGlobal.gv_sql, thismessageid);
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_TableValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["JoinOperator"].ToString();
                    cboJoinOperator.Enabled = false;
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

        public void RefreshSetList()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            int SetIndex = 1;

            try
            {
                cboSet.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_tablevalidation ";
                if (Strings.UCase(modGlobal.gv_Action) == "ERROR")
                {
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql,
                        frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"]);
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql,
                        frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"]);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_setup_tablevalidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                //Display the list of criteria
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName14].Rows)
                {
                    cboSet.Items.Add("Set " + SetIndex);

                    //LDW Support.SetItemData(cboSet, cboSet.NewIndex, SetIndex);
                    Support.SetItemData(cboSet, cboSet.Items.Count - 1, SetIndex);
                    SetIndex = SetIndex + 1;
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                //always add a new one to the list in addition to the previous ones
                cboSet.Items.Add(new ListBoxItem("Set " + SetIndex, SetIndex).ToString());
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

        //Public Sub RefreshLookupList()
        //
        //    gv_sql = "Select tbl_Setup_TableDef.BaseTable, tbl_Setup_misclookuplist.*  "
        //    gv_sql = gv_sql & " From tbl_Setup_TableDef, tbl_Setup_misclookuplist  "
        //    gv_sql = gv_sql & "Where tbl_Setup_TableDef.BaseTableID = tbl_Setup_misclookuplist.BaseTableID "
        //    gv_sql = gv_sql & "Order By tbl_Setup_TableDef.BaseTable, tbl_Setup_misclookuplist.sortorder, tbl_Setup_misclookuplist.FieldValue"
        //
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //    cboLookupValues.Clear
        //    While Not gv_rs.EOF
        //        cboLookupValues.AddItem gv_rs!BaseTable & " - (" & gv_rs!Id & ") " & gv_rs!FIELDVALUE
        //        cboLookupValues.ItemData(cboLookupValues.NewIndex) = gv_rs!LookupID
        //        gv_rs.MoveNext
        //    Wend
        //
        //End Sub

        public void RefreshFieldsList()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            var LIndex = 0;

            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID =  {1}", modGlobal.gv_sql,
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

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName16 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                //Display the list of fields
                lstField1List.Items.Clear();
                cboField2List.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName16].Rows)
                {
                    LIndex = LIndex + 1;
                    lstField1List.Items.Add(new ListBoxItem(myRow7.Field<string>("FieldName"), myRow7.Field<int>("DDID")).ToString());
                    cboField2List.Items.Add(new ListBoxItem(myRow7.Field<string>("FieldName"), myRow7.Field<int>("DDID")).ToString());
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

        private void lstField1List_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshLookupListForThisField();
                RefreshCriteriaFieldList();
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
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = true;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptions.ActiveWindow.DockTabStrip.SelectedIndex = 0;
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
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = true;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptions.ActiveWindow.DockTabStrip.SelectedIndex = 1;
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
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = true;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptions.ActiveWindow.DockTabStrip.SelectedIndex = 2;
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

        private void Opt4Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt4Method.IsChecked))
                {
                    if (Opt4Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = true;
                        sstabOptionsMethod5.ActiveControl.Enabled = false;
                        sstabOptions.ActiveWindow.DockTabStrip.SelectedIndex = 3;
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

        private void Opt5Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt5Method.IsChecked))
                {
                    if (Opt5Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptionsMethod1.ActiveControl.Enabled = false;
                        sstabOptionsMethod2.ActiveControl.Enabled = false;
                        sstabOptionsMethod3.ActiveControl.Enabled = false;
                        sstabOptionsMethod4.ActiveControl.Enabled = false;
                        sstabOptionsMethod5.ActiveControl.Enabled = true;
                        sstabOptions.ActiveWindow.DockTabStrip.SelectedIndex = 4;
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

        private void txtOpt1TypeinValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    chkBlank.CheckState = CheckState.Unchecked;
                    cboDestFieldList.SelectedIndex = -1;
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

        public void UpdateMainJoinOp()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();


            try
            {
                //update join operator if any
                if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
                {
                    modGlobal.gv_sql = "Update tbl_Setup_TableValidationMessage ";
                    modGlobal.gv_sql = string.Format("{0} set JoinOperator = '{1}'", modGlobal.gv_sql, modGlobal.gv_ANDOR);
                    modGlobal.gv_sql = modGlobal.gv_sql + " where TableValidationMessageID = ";
                    if (Strings.UCase(modGlobal.gv_Action) == "ERROR")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmTableValidationSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows[0]["TableValidationMessageID"];
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + frmTableValidationSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows[0]["TableValidationMessageID"];
                    }
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        public void RefreshLookupListForThisField()
        {
            var LIndex = 0;
            int Field_ListIndex = 0;
            int LookupTableID = 0;


            try
            {
                modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName17].Rows.Count > 0)
                {
                    LookupTableID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["LookupTableID"]);
                    //Opt2Method.Value = True
                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName18 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                    cboLookupValues.Items.Clear();

                    Field_ListIndex = -1;
                    LIndex = -1;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName18].Rows)
                    {
                        LIndex = LIndex + 1;
                        Field_ListIndex = LIndex;

                        cboLookupValues.Items.Add(new ListBoxItem(string.Format("({0}) {1}",
                            myRow8.Field<int>("Id"), myRow8.Field<string>("FIELDVALUE")), myRow8.Field<int>("LookupID")).ToString());

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else if (Opt2Method.IsChecked == true)
                {
                    Opt1Method.IsChecked = true;
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

        public void RefreshCriteriaFieldList()
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            var LIndex = 0;
            string thisfieldtype = null;

            try
            {
                //find the field type of the selected field
                modGlobal.gv_sql = "Select fieldtype ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where DDID =  {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName19 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);
                thisfieldtype = modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["FieldType"].ToString();

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where BaseTableID =  {1}", modGlobal.gv_sql, Support.GetItemData(frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " and ";
                modGlobal.gv_sql = string.Format("{0} ( fieldtype = '{1}'", modGlobal.gv_sql, thisfieldtype);

                if (thisfieldtype == "Time")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " OR fieldtype = 'Date/Time'";
                }

                modGlobal.gv_sql = string.Format("{0} ) and DDID <>  {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                //Display the list of fields
                cboDestFieldList.Items.Clear();
                cboField2List.Items.Clear();
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName20].Rows)
                {
                    LIndex = LIndex + 1;
                    cboDestFieldList.Items.Add(new ListBoxItem(myRow10.Field<string>("FieldName"), myRow10.Field<int>("DDID")).ToString());
                    cboField2List.Items.Add(new ListBoxItem(myRow10.Field<string>("FieldName"), myRow10.Field<int>("DDID")).ToString());
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
