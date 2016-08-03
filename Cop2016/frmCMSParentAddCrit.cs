using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Telerik.WinControls.UI;
using System.Drawing;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmCMSParentAddCrit : RadForm
    {
        int thismessageid;
        private int il_CMSParentID;


        public frmCMSParentAddCrit()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboDestFieldList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RadDropDownList cboOpt1Unit = new RadDropDownList();

            try
            {

                if (cboDestFieldList.SelectedIndex > 0)
                {
                    chkBlank.CheckState = CheckState.Unchecked;
                    txtOpt1TypeinValue.Text = "";
                    cboOpt1Unit.Text = "";
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
            RadDropDownList cboOpt1Unit = new RadDropDownList();

            try
            {

                if (chkBlank.CheckState == CheckState.Checked)
                {
                    txtOpt1TypeinValue.Text = "";
                    cboOpt1Unit.Text = "";
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
                if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled ==
                    false & sstabOptions4.Enabled == false & !sstabOptions5.Enabled)
                {
                    RadMessageBox.Show("Please select a method.");
                    return;
                }

                if (lstField1List.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a field from the list");
                    return;
                }

                if (cboSet.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the Criteria Set.");
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                if (sstabOptions1.Enabled == true)
                {
                    modGlobal.gv_sql = "Select LookupTableID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_DataDef  ";
                    modGlobal.gv_sql = string.Format("{0}Where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_DataDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                    if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & !Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["LookupTableID"]))
                    {
                        RadMessageBox.Show("This field is linked to a lookup table. Select Method 2 to compare it against a lookup value.");
                        return;
                    }
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
                else if (sstabOptions4.Enabled == true)
                {
                    AddCriteriaWithMethod4();
                }
                else if (sstabOptions5.Enabled)
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshDestFieldList()
        {
            var LIndex = 0;
            int Field_ListIndex = -1;
            List<Item> itemscboDestFieldList = new List<Item>();

            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = (Select BaseTableID From tbl_Setup_TableDef where BaseTable = 'PATIENT')";
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

                cboDestFieldList.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Field_ListIndex = LIndex;

                    itemscboDestFieldList.Add(new Item(myRow2.Field<int>("DDID"), myRow2.Field<string>("FieldName")));

                    //cboDestFieldList.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboDestFieldList.DataSource = itemscboDestFieldList;
                this.cboDestFieldList.DisplayMember = "Description";
                this.cboDestFieldList.ValueMember = "Id";
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

        public void SetCMSParentID(int ParentID)
        {
            il_CMSParentID = ParentID;
        }

        private void frmCMSParentAddCrit_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            string thismessage = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.Text = string.Format("Add Parent {0} Criteria", modGlobal.gv_Action);
                lblMessage.Text = string.Format("Setup criteria for Parent {0} Criteria: {1}", modGlobal.gv_Action, thismessage);

                sstabOptions.ActiveWindow = sstabOptions1;
                sstabOptions1.Enabled = false;
                sstabOptions2.Enabled = false;
                sstabOptions3.Enabled = false;
                Opt1Method.IsChecked = false;
                Opt2Method.IsChecked = false;
                Opt3Method.IsChecked = false;

                RefreshFieldsList();
                RefreshDestFieldList();
                //RefreshLookupList
                RefreshSetList();
                RefreshLookupTables();

                Cursor.Current = Cursors.Default;
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

        private void RefreshLookupTables()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemscboLookupTables = new List<Item>();


            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                cboLookupTables.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemscboLookupTables.Add(new Item(myRow3.Field<int>("basetableid"), myRow3.Field<string>("BaseTable")));

                    //cboLookupTables.Items.Add(new ListBoxItem(myRow3.Field<string>("BaseTable"), myRow3.Field<int>("basetableid")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboLookupTables.DataSource = itemscboLookupTables;
                this.cboLookupTables.DisplayMember = "Description";
                this.cboLookupTables.ValueMember = "Id";
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

        private void AddCriteriaWithMethod1()
        {
            string CritTitle = null;
            string DestFieldType = null;
            string field1type = null;

            // ERROR: Not supported in C#: OnErrorStatement


            try
            {
                if (cboOpt1ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list");
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & cboDestFieldList.SelectedIndex < 0 & chkBlank.CheckState == 0)
                {
                    RadMessageBox.Show("Either select a field, or check the blank, or type in a a value.");
                    return;
                }

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (cboDestFieldList.SelectedIndex > -1)
                {
                    //find the Dest field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboDestFieldList, cboDestFieldList.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_Datadef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    DestFieldType = modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["FieldType"].ToString();
                    modGlobal.gv_rs.Dispose();

                    if (field1type != DestFieldType)
                    {
                        RadMessageBox.Show("The data types of the selected fields don't match. Please re-Specify...");
                        return;
                    }
                }


                //make sure that the typed value is of the same type as the field type
                if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                {
                    if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text))
                    {
                        RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
                        return;
                    }
                    if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtOpt1TypeinValue.Text))
                    {
                        RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                        return;
                    }
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) |
                        (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") |
                        (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1)))))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                }

                CritTitle = string.Format("{0} {1}", lstField1List.Text, cboOpt1ValueOperator.Text);

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

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DestDDID, ValueOperator, FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, JoinOperator, ";

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet) ";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet) ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, il_CMSParentID);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
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
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod2()
        {
            string CritTitle = null;
            string field1type = null;
            int IDFromLookup;
            string fieldLookupTableID = null;


            try
            {
                if (cboOpt2ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list");
                    return;
                }

                fieldLookupTableID = " Null ";
                if (cboLookupValues.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select lookup value from list.");
                    return;
                }
                else
                {
                    modGlobal.gv_sql = "Select *   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                    modGlobal.gv_sql = string.Format("{0} Where lookupid = {1}", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName6 = "tbl_setup_Misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                    IDFromLookup = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["Id"]);
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //make sure that the field type is not a date field
                if (Strings.Mid(field1type, 1, 3) == "Dat")
                {
                    RadMessageBox.Show("You cannot compare this field to a lookup value, because the selected field is a date field. Please re-Specify...");
                    return;
                }

                CritTitle = string.Format("{0} {1} {2}", lstField1List.Text, cboOpt2ValueOperator.Text, cboLookupValues.Text);
                //Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (";

                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, il_CMSParentID);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt2ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, IDFromLookup);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod3()
        {
            string CritTitle = null;
            string field1type = null;

            try
            {
                if (cboOpLkTable.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the operator from the list.");
                    return;
                }

                if (cboLookupTables.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a Lookup Table from the list.");
                    return;
                }

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (Strings.UCase(Strings.Mid(field1type, 1, 3)) == "DAT" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "TIM" | Strings.UCase(Strings.Mid(field1type, 1, 3)) == "NUM")
                {
                    RadMessageBox.Show("A date, time or numeric field can not be compared to a lookup table. Please re-Specify...");
                    return;
                }

                CritTitle = string.Format("{0} {1} [{2}] Lookup Table ", lstField1List.Text, cboOpLkTable.Text, cboLookupTables.Text);
                //Mid(cboLookupValues.Text, InStr(1, cboLookupValues.Text, "-") + 1)

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Fieldoperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, il_CMSParentID);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpLkTable.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

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
            //LDW ErrHandler:


            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod4()
        {
            string CritTitle = null;
            string Field2Type = null;
            string field1type = null;



            try
            {
                if (cboFieldOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the Add/Subtract operation from the list.");
                    return;
                }

                if (cboField2List.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the second Field from the list.");
                    return;
                }

                if (cboOpt3ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list.");
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt3TypeinValue.Text))
                {
                    RadMessageBox.Show("A value should be typed in.");
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                if (Strings.UCase(Strings.Mid(field1type, 1, 3)) != "DAT" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "TIM" & Strings.UCase(Strings.Mid(field1type, 1, 3)) != "NUM")
                {
                    RadMessageBox.Show("Only a date, time or numeric field can be selected for this method. Please re-Specify...");
                    return;
                }

                //make sure that the 2 selected fields are of the same type
                if (!string.IsNullOrEmpty(cboField2List.Text))
                {
                    //find the field type
                    modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName10 = "tbl_setup_Datadef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                    Field2Type = modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["FieldType"].ToString();
                    modGlobal.gv_rs.Dispose();
                    if (field1type != Field2Type)
                    {
                        RadMessageBox.Show("The 2 fields that you have selected are not of the same type. Please re-specify...");
                        return;
                    }
                }


                //make sure that the typed value is numeric
                if (!Information.IsNumeric(txtOpt3TypeinValue.Text))
                {
                    RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");
                    return;
                }

                if (field1type == "Date" & cboFieldOperator.Text != "-")
                {
                    RadMessageBox.Show("Date fields can only be subtracted from eachother.");
                    return;
                }

                if (field1type == "Date" & string.IsNullOrEmpty(cboOpt3Unit.Text))
                {
                    RadMessageBox.Show("Please define the date unit associated with the value");
                    return;
                }


                CritTitle = lstField1List.Text;
                CritTitle = string.Format("{0} {1} {2}", CritTitle, cboFieldOperator.Text, cboField2List.Text);
                CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3ValueOperator.Text);
                CritTitle = string.Format("{0} {1}", CritTitle, txtOpt3TypeinValue.Text);
                if (field1type == "Date")
                {
                    CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3Unit.Text);
                }

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  Fieldoperator, DateUnit, JoinOperator, ";

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, il_CMSParentID);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
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
                    }
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                }
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }

        private void AddCriteriaWithMethod5()
        {
            string field1type = null;
            string Field2Type = null;
            string CritTitle = null;
            //Dim li_order as long
            int li_CriteriaSetID;
            int li_cnt = 0;
            string[] GroupIDs = null;
            int li_group = 0;


            try
            {
                if (chkBlank5.CheckState == CheckState.Checked & cboOpt5ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please choose an operator for Blank Comparison");
                    return;
                }
                GroupIDs = new string[li_group + 1];

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                {
                    if (lstField1List.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName23 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName23].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        if (field1type != "Date" & field1type != "Time")
                        {
                            RadMessageBox.Show("The selected fields are not date or time fields");
                            return;
                        }

                        if (string.IsNullOrEmpty(CritTitle))
                        {
                            CritTitle = "EARLIEST(";
                        }

                        CritTitle = string.Format("{0}{1},", CritTitle, Support.GetItemString(lstField1List, li_cnt));

                        Array.Resize(ref GroupIDs, li_group + 1);
                        GroupIDs[li_group] = Convert.ToString(Support.GetItemData(lstField1List, li_cnt));
                        li_group = li_group + 1;
                    }
                }

                CritTitle = Strings.Mid(CritTitle, 1, Strings.Len(CritTitle) - 1);
                CritTitle = string.Format("{0}) {1} BLANK", CritTitle, cboOpt5ValueOperator.Text);

                if (Information.UBound(GroupIDs) < 1)
                {
                    RadMessageBox.Show("You must select more than one field to determine the earliest.");
                    return;
                }

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = "Insert into tbl_Setup_CMSParentAnswerCriteria (CMSParentCDID,";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSFieldMeasureCriteria (CMSFieldMeasureID, ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + "CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, FieldValue, JoinOperator, ";

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSParentAnswerCriteriaSet)";
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " CMSFieldMeasureCriteriaSet)";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, il_CMSParentID);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboOpt5ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Strings.Join(GroupIDs, ","));
                modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, cboJoinOperator.Text);
                modGlobal.gv_sql = string.Format("{0}{1})", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //InputBox "", "", gv_sql

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }


        private void RefreshSetDef()
        {
            try
            {

                if (cboSet.SelectedIndex < 0)
                {
                    return;
                }

                modGlobal.gv_sql = "Select JoinOperator from ";

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_CMSParentAnswerCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where CMSParentCDID = {1}", modGlobal.gv_sql, il_CMSParentID);
                    modGlobal.gv_sql = string.Format("{0} and CMSParentAnswerCriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_CMSFieldMeasureCriteria ";
                    modGlobal.gv_sql = string.Format("{0} WHERE CMSFieldMeasureID = {1}", modGlobal.gv_sql, il_CMSParentID);
                    modGlobal.gv_sql = string.Format("{0} and CMSFieldMeasureCriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_Setup_CMSParentAnswerCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName11].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["JoinOperator"].ToString();
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

        private void RefreshSetList()
        {
            int li_LastIndex = 0;
            List<Item> itemscboSet = new List<Item>();

            try
            {
                cboSet.Items.Clear();

                if (modGlobal.gv_Action == "ANSWER")
                {
                    modGlobal.gv_sql = string.Format("Select DISTINCT CMSParentAnswerCriteriaSet as CriteriaSet from " +
                        "tbl_Setup_CMSParentAnswerCriteriaSet WHERE CMSParentCDID = {0} ORDER BY CMSParentAnswerCriteriaSet ", il_CMSParentID);
                }
                else if (modGlobal.gv_Action == "FIELD")
                {
                    modGlobal.gv_sql = string.Format("Select DISTINCT CMSFieldMeasureCriteriaSet as CriteriaSet from " +
                        "tbl_Setup_CMSFieldMeasureCriteriaSet WHERE CMSFieldMeasureID = {0} ORDER BY CMSFieldMeasureCriteriaSet ", il_CMSParentID);
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_Setup_CMSParentAnswerCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                //Display the list of criteria
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                {
                    itemscboSet.Add(new Item(myRow12.Field<int>("CriteriaSet"), "Set " + myRow12.Field<string>("CriteriaSet")));


                    //cboSet.Items.Add(new ListBoxItem("Set " + myRow12.Field<string>("CriteriaSet"), myRow12.Field<int>("CriteriaSet")).ToString());
                    li_LastIndex = myRow12.Field<int>("CriteriaSet");
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboSet.DataSource = itemscboSet;
                this.cboSet.DisplayMember = "Description";
                this.cboSet.ValueMember = "Id";

                modGlobal.gv_rs.Dispose();

                if (li_LastIndex == 0)
                {
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Enabled = false;
                }

                //always add a new one to the list in addition to the previous ones
                //LDW cboSet.Items.Add(new ListBoxItem("Set " + (li_LastIndex + 1), li_LastIndex + 1).ToString());
                itemscboSet.Add(new Item(li_LastIndex + 1, "Set " + (li_LastIndex + 1)));
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


        private void RefreshFieldsList()
        {
            var LIndex = 0;
            List<Item> itemslstField1List = new List<Item>();
            List<Item> itemscboField2List = new List<Item>();

            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = (SELECT BaseTableID FROM tbl_Setup_TableDef where basetable = 'PATIENT')";
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
                const string sqlTableName15 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                //Display the list of fields
                lstField1List.Items.Clear();
                cboField2List.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow15 in modGlobal.gv_rs.Tables[sqlTableName15].Rows)
                {
                    LIndex = LIndex + 1;

                    itemslstField1List.Add(new Item(myRow15.Field<int>("DDID"), myRow15.Field<string>("FieldName")));
                    itemscboField2List.Add(new Item(myRow15.Field<int>("DDID"), myRow15.Field<string>("FieldName")));

                    //lstField1List.Items.Add(new ListBoxItem(myRow15.Field<string>("FieldName"), myRow15.Field<int>("DDID")).ToString());
                    //cboField2List.Items.Add(new ListBoxItem(myRow15.Field<string>("FieldName"), myRow15.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstField1List.DataSource = itemslstField1List;
                this.lstField1List.DisplayMember = "Description";
                this.lstField1List.ValueMember = "Id";

                this.cboField2List.DataSource = itemscboField2List;
                this.cboField2List.DisplayMember = "Description";
                this.cboField2List.ValueMember = "Id";


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
            RefreshLookupListForThisField();
            RefreshCriteriaFieldList();
        }

        private void lstField1List_MouseDown(object sender, MouseEventArgs e)
        {
            int Button = Convert.ToInt32(e.Button) / 0x100000;
            int Shift = Convert.ToInt32(Control.ModifierKeys) / 0x10000;
            float X = Convert.ToInt64(Support.PixelsToTwipsX(e.X));
            float Y = Convert.ToInt64(Support.PixelsToTwipsY(e.Y));
            int li_cnt = 0;

            try
            {
                //disable the multiselect manually (this property is read-only at run-time)
                if (lstField1List.SelectedItems.Count > 1 & !Opt5Method.IsChecked)
                {
                    //LDW lstField1List.SetSelected(lstField1List.SelectedIndex, true);
                    lstField1List.SelectedIndex = lstField1List.SelectedIndex;
                    lstField1List.SelectedItem.Active = true;
                    Application.DoEvents();

                    if (lstField1List.SelectedItems.Count > 1)
                    {
                        for (li_cnt = 0; li_cnt <= lstField1List.Items.Count - 1; li_cnt++)
                        {
                            if (lstField1List.SelectedIndex != li_cnt)
                            {
                                //LDW lstField1List.SetSelected(li_cnt, false);
                                lstField1List.SelectedIndex = li_cnt;
                                lstField1List.SelectedItem.Active = true;
                            }
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

        private void Opt1Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt1Method.IsChecked))
                {
                    if (Opt1Method.IsChecked == true)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptions1.Enabled = true;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = false;
                        sstabOptions5.Enabled = false;
                        sstabOptions.ActiveWindow = sstabOptions1;
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
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = true;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = false;
                        sstabOptions5.Enabled = false;


                        sstabOptions.ActiveWindow = sstabOptions2;
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
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = true;
                        sstabOptions4.Enabled = false;
                        sstabOptions5.Enabled = false;


                        sstabOptions.ActiveWindow = sstabOptions3;
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
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = true;
                        sstabOptions5.Enabled = false;

                        sstabOptions.ActiveWindow = sstabOptions4;
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
                    if (Opt5Method.IsChecked)
                    {
                        sstabOptions.Enabled = true;
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = false;
                        sstabOptions5.Enabled = true;

                        sstabOptions.ActiveWindow = sstabOptions5;
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

        private void RefreshLookupListForThisField()
        {
            var LIndex = 0;
            int Field_ListIndex;
            int LookupTableID;
            List<Item> itemscboLookupValues = new List<Item>();


            try
            {
                modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName18 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName18].Rows.Count > 0)
                {
                    LookupTableID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName18].Rows[0]["LookupTableID"]);

                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName19 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                    cboLookupValues.Items.Clear();

                    Field_ListIndex = -1;
                    LIndex = -1;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow19 in modGlobal.gv_rs.Tables[sqlTableName19].Rows)
                    {
                        LIndex = LIndex + 1;
                        Field_ListIndex = LIndex;

                        itemscboLookupValues.Add(new Item(myRow19.Field<int>("LookupID"), "(" + myRow19.Field<string>("Id") + ") " + myRow19.Field<string>("FIELDVALUE")));

                        //cboLookupValues.Items.Add(new ListBoxItem("(" + myRow19.Field<string>("Id") + ") " + myRow19.Field<string>("FIELDVALUE"), myRow19.Field<int>("LookupID")).ToString());

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    this.cboLookupValues.DataSource = itemscboLookupValues;
                    this.cboLookupValues.DisplayMember = "Description";
                    this.cboLookupValues.ValueMember = "Id";
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

        private void RefreshCriteriaFieldList()
        {
            var LIndex = 0;
            string thisfieldtype = null;
            List<Item> itemscboDestFieldList = new List<Item>();
            List<Item> itemscboField2List = new List<Item>();


            try
            {
                //find the field type of the selected field
                modGlobal.gv_sql = "Select fieldtype ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} Where DDID =  {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);
                thisfieldtype = modGlobal.gv_rs.Tables[sqlTableName20].Rows[0]["FieldType"].ToString();

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID =  (SELECT BasetableID FROM tbl_Setup_TableDef WHERE BaseTable = 'PATIENT')";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and fieldtype = '{1}'", modGlobal.gv_sql, thisfieldtype);
                modGlobal.gv_sql = string.Format("{0} and DDID <>  {1}", modGlobal.gv_sql, Support.GetItemData(lstField1List, lstField1List.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName21 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);

                //Display the list of fields
                cboDestFieldList.Items.Clear();
                cboField2List.Items.Clear();
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow21 in modGlobal.gv_rs.Tables[sqlTableName21].Rows)
                {
                    LIndex = LIndex + 1;

                    itemscboDestFieldList.Add(new Item(myRow21.Field<int>("DDID"), myRow21.Field<string>("FieldName")));
                    itemscboField2List.Add(new Item(myRow21.Field<int>("DDID"), myRow21.Field<string>("FieldName")));

                    //cboDestFieldList.Items.Add(new ListBoxItem(myRow21.Field<string>("FieldName"), myRow21.Field<int>("DDID")).ToString());
                    //cboField2List.Items.Add(new ListBoxItem(myRow21.Field<string>("FieldName"), myRow21.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboDestFieldList.DataSource = itemscboDestFieldList;
                this.cboDestFieldList.DisplayMember = "Description";
                this.cboDestFieldList.ValueMember = "Id";

                this.cboField2List.DataSource = itemscboField2List;
                this.cboField2List.DisplayMember = "Description";
                this.cboField2List.ValueMember = "Id";

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

        /*LDW Not used
         
                 private void RefreshAnswerCodes()
        {
            RadListControl lstAvailable = null;
            RadListControl lstChildren = null;
            
            DataSet rsAnswerCD = new DataSet();
            int li_cnt = 0;

            modGlobal.gv_sql = "Select cms.FieldMeasureID, cms.measurecode, df.ddid, df.fieldname, df.cmsfieldcode ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as df ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_cmsFieldMeasures as cms ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";

            if (lstChildren.Items.Count > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE cms.FieldMeasureID NOT IN (";

                for (li_cnt = 0; li_cnt <= lstChildren.Items.Count - 1; li_cnt++)
                {
                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + lstChildren.ItemData(li_cnt) + ",";
                    lstChildren.SelectedIndex = li_cnt;
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, lstChildren.SelectedItem);
                }

                modGlobal.gv_sql = Strings.Mid(modGlobal.gv_sql, 1, Strings.Len(modGlobal.gv_sql) - 1) + ")";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " order by cmsfieldcode, df.FieldName, MeasureCode ";

            //LDW rsAnswerCD = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            const string sqlTableName14 = "tbl_setup_DataDef";
            rsAnswerCD = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, rsAnswerCD);
            lstAvailable.Items.Clear();

            //LDW while (!rsAnswerCD.EOF)
            foreach (DataRow myRow14 in rsAnswerCD.Tables[sqlTableName14].Rows)
            {
                lstAvailable.Items.Add(new ListBoxItem(string.Format("{0} - {1} **** {2}", myRow14.Field<string>("measurecode"), 
                    myRow14.Field<string>("FieldName"), myRow14.Field<string>("cmsfieldcode")), myRow14.Field<int>("fieldmeasureid")).ToString());

                //LDW rsAnswerCD.MoveNext();
            }

            rsAnswerCD.Dispose();
            rsAnswerCD = null;
        }
*/
    }
}
