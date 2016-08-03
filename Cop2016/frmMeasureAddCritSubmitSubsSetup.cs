using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Diagnostics;
using System.Drawing;

namespace COP2001
{
    public partial class frmMeasureAddCritSubmitSubsSetup : Telerik.WinControls.UI.RadForm
    {
        private string is_Measure;
        private int ii_MeasureID;
        private int ii_MeasureSetID;
        private string is_CritType;
        private string is_RowCount;
        private modGlobal.SelectedMeasureField[] is_Selected;
        int MeasureStepID;


        public frmMeasureAddCritSubmitSubsSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void setRowCount(string RowCount)
        {
            is_RowCount = RowCount;
        }

        public void setCritType(string CritType)
        {
            //Reg for regular flowchart criteria
            //Filter for filter criteria
            //Risk for risk criteria
            is_CritType = CritType;
        }

        public void setMeasure(string Measure)
        {
            is_Measure = Measure;
        }

        public void SetMeasureID(int MeasureID)
        {
            ii_MeasureID = MeasureID;
        }

        public void setMeasureSetID(int MeasureSetID)
        {
            ii_MeasureSetID = MeasureSetID;
        }

        public void setMeasureStepID(int MSID)
        {
            try
            {
                MeasureStepID = MSID;
                RefreshSetList();
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

        private void cboDestField_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboDestField.SelectedIndex > -1)
                {
                    txtOpt1TypeinValue.Text = "";
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
            try
            {
                if (chkBlank.CheckState == CheckState.Checked)
                {
                    txtOpt1TypeinValue.Text = "";
                    cboDestField.SelectedIndex = -1;
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
                if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled == false & sstabOptions4.Enabled == false &
                    sstabOptions5.Enabled == false & sstabOptions6.Enabled == false)
                {
                    RadMessageBox.Show("Please select a method.");
                    return;
                }

                if (lstFieldList.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select field(s) from the list");
                    return;
                }

                if (string.IsNullOrEmpty(cboSet.Text))
                {
                    RadMessageBox.Show("Please select the Criteria Set.");
                    return;
                }

                if (string.IsNullOrEmpty(Strings.Trim(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                if (sstabOptions1.Enabled == true)
                {
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
                else if (sstabOptions5.Enabled == true)
                {
                    AddCriteriaWithMethod5();
                }
                else if (sstabOptions6.Enabled == true)
                {
                    AddCriteriaWithMethod6();
                }

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

        private void cmdAddVal_Click(object sender, EventArgs e)
        {
            string ls_add = null;
            var rsIsValid = new DataSet();


            //EditCat:

            try
            {
                ls_add = RadInputBox.Show("Enter a valid month value.", "Add Values", "");

                if (Strings.Len(ls_add) == 0)
                    return;

                // ERROR: Not supported in C#: OnErrorStatement

                modGlobal.gv_sql = string.Format("SELECT MONTH('{0}/1/2000')", ls_add);
                //LDW rsIsValid = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "MONTH";
                rsIsValid = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, rsIsValid);

                //LDW if (rsIsValid.EOF)
                for (int itr = 0; itr < rsIsValid.Tables[sqlTableName1].Rows.Count; itr++)
                {
                    var myRow = rsIsValid.Tables[sqlTableName1].Rows[itr];
                    int rowIndex = rsIsValid.Tables[sqlTableName1].Rows.IndexOf(myRow);
                    if (rowIndex == rsIsValid.Tables[sqlTableName1].Rows.Count - 1)
                    {
                        RadMessageBox.Show("Please Enter A Valid Month", "Invalid Month", MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void frmMeasureAddCritSubmitSubsSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();


            try
            {
                sstabOptions.ActiveWindow = sstabOptions1;
                sstabOptions1.Enabled = false;
                sstabOptions2.Enabled = false;
                sstabOptions3.Enabled = false;
                sstabOptions4.Enabled = false;
                Opt1Method.IsChecked = false;
                Opt2Method.IsChecked = false;
                Opt3Method.IsChecked = false;
                Opt4Method.IsChecked = false;

                lblColName.Text = "Setting up criteria for " + is_Measure;

                is_Selected = new modGlobal.SelectedMeasureField[1];

                RefreshFieldsList();
                RefreshLookupTables();
                //If is_CritType = "Reg" Or is_CritType = "Risk" Then RefreshCatList
                //RefreshStepList

                //If is_CritType = "Filter" Then
                //    cboSet.Visible = False
                //    lblSet.Visible = False
                //    lblCat.Visible = False
                //    cboCat.Visible = False
                //ElseIf is_CritType = "Reg" Then
                cboSet.Visible = true;
                lblSet.Visible = true;
                //     lblCat.Visible = True
                //     cboCat.Visible = True
                //ElseIf is_CritType = "Risk" Then
                //    cboSet.Visible = True
                //    lblSet.Visible = True
                //    lblCat.Visible = True
                //    cboCat.Visible = True
                //End If
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
            try
            {
                //retrieve the list of table fields
                //fields are setup in the map measures form - tbl_setup_FieldMeasureSet

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef dd ";
                //" WHERE dd.DDID = fm.DDID AND fm.MeasureSetID = " & ii_MeasureSetID
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE (ParentDDID IS NULL OR ParentDDID = DDID) ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (dd.State = '' or dd.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} AND (dd.State = '' or dd.State is null or dd.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //Display the list of fields
                lstFieldList.Items.Clear();
                cboField2List.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    lstFieldList.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());
                    cboField2List.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());
                    // LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

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

        private void RefreshLookupTables()
        {
            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);
                cboLookupTables.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    cboLookupTables.Items.Add(new ListBoxItem(myRow3.Field<string>("BaseTable"), myRow3.Field<int>("basetableid")).ToString());

                    // LDW modGlobal.gv_rs.MoveNext();
                }

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

        private void RefreshSetList()
        {
            int li_cnt;
            int li_Sets = 0;

            try
            {
                //On Error GoTo ErrHandler
                cboSet.Items.Clear();

                //LDW cboSet.Locked = false;
                cboSet.DropDownStyle = RadDropDownStyle.DropDown;

                modGlobal.gv_sql = string.Format("SELECT DISTINCT mcs.MeasureCriteriaSet  FROM tbl_setup_MeasureCriteriaSetSubmitSubs mcs, " +
                    "tbl_Setup_MeasureStepSubmitSubs ms WHERE mcs.MeasureStepSubmitSubsID = ms.MeasureStepsubmitSubsID  AND ms.MeasureStepID = {0}", MeasureStepID);
                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureCriteriaSet";
                //gv_g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_MeasureCriteriaSetSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);
                li_Sets = modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count;
                modGlobal.gv_rs.Dispose();


                //Display the list of criteria
                for (li_cnt = 1; li_cnt <= li_Sets + 1; li_cnt++)
                {
                    cboSet.Items.Add(new ListBoxItem("Set " + li_cnt, li_cnt).ToString());
                }


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

                //get join operator for criteria (if avail)
                modGlobal.gv_sql = string.Format("Select mc.JoinOperator from tbl_setup_MeasureCriteriaSetSubmitSubs mcs,  tbl_Setup_MeasureStepSubmitSubs ms, " +
                    "tbl_Setup_MeasureCriteriaSubmitSubs mc WHERE  ms.MeasureStepSubmitSubsID = mcs.MeasureStepSubmitSubsID  AND mc.MeasureCriteriaSetSubmitSubsID = " +
                    "mcs.MeasureCriteriaSetSubmitSubsID  AND ms.MeasureStepID = {0} AND mcs.MeasureCriteriaSet = {1}", MeasureStepID, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_MeasureCriteriaSetSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName5].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["JoinOperator"].ToString();
                    cboJoinOperator.Enabled = false;
                }

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

        private void RefreshLookupListForThisField()
        {
            string LookupTableID = null;

            try
            {

                cboLookupValues.Items.Clear();

                modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

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
                        cboLookupValues.Items.Add(new ListBoxItem(string.Format("({0}) {1}", myRow7.Field<string>("Id"), myRow7.Field<string>("FIELDVALUE")), myRow7.Field<int>("LookupID")).ToString());
                        // LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else if (Opt2Method.IsChecked == true)
                {
                    Opt1Method.IsChecked = true;
                }
                modGlobal.gv_rs.Dispose();
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

        private void RefreshCriteriaFieldList()
        {
            string field1type = null;

            try
            {
                //find the field type
                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["FieldType"].ToString();
                modGlobal.gv_rs.Dispose();

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT'";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_DataDef.fieldtype = '{1}'", modGlobal.gv_sql, field1type);
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_DataDef.ddid <> {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                //Display the list of fields
                cboField2List.Items.Clear();
                cboDestField.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    cboField2List.Items.Add(new ListBoxItem(myRow9.Field<string>("FieldName"), myRow9.Field<int>("DDID")).ToString());

                    cboDestField.Items.Add(new ListBoxItem(myRow9.Field<string>("FieldName"), myRow9.Field<int>("DDID")).ToString());
                    // LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();
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

        private void AddCriteriaWithMethod1()
        {
            string field1type = null;
            string CritTitle = null;
            //Dim li_order As Long
            int li_CriteriaSetID = 0;
            int li_cnt = 0;
            string ls_Dest = null;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (cboOpt1ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list");
                    return;
                }

                if (string.IsNullOrEmpty(txtOpt1TypeinValue.Text) & chkBlank.CheckState == 0 & cboDestField.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Define a value, blank, or another field for this criteria type.");
                    return;
                }

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                {
                    if (lstFieldList.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName12 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName12].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        //make sure that the typed value is of the same type as the field type
                        if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                        {
                            if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtOpt1TypeinValue.Text) & Strings.UCase(Strings.Trim(txtOpt1TypeinValue.Text)) != "UTD")
                            {
                                RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a numeric field, but the value is not a number. Please re-Specify...");
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
                                    RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a date field, but the value is not a date. Please re-Specify...");
                                    return;
                                }
                                if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtOpt1TypeinValue.Text) != 5))
                                {
                                    RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in " +
                                        "the appropriate format (HH:MM military). Please re-Specify...");
                                    return;
                                }
                                if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 1, 1))) |
                                    (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 2, 1))) | (Strings.Mid(txtOpt1TypeinValue.Text, 3, 1) != ":") |
                                    (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtOpt1TypeinValue.Text, 5, 1)))))
                                {
                                    RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not " +
                                        "in the appropriate format (HH:MM military). Please re-Specify...");
                                    return;
                                }
                                if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 1, 2)) > 23 |
                                    Convert.ToDouble(Strings.Mid(txtOpt1TypeinValue.Text, 4, 2)) > 59))
                                {
                                    RadMessageBox.Show(Support.GetItemString(lstFieldList, li_cnt) + " is a Time field, but the value is not in " +
                                        "the appropriate format (HH:MM military). Please re-Specify...");
                                    return;
                                }
                            }
                        }

                        modGlobal.gv_Action = "Add";

                        CritTitle = string.Format("{0} {1}", Support.GetItemString(lstFieldList, li_cnt), cboOpt1ValueOperator.Text);

                        if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                        {
                            CritTitle = string.Format("{0} {1}", CritTitle, txtOpt1TypeinValue.Text);
                        }
                        if (chkBlank.CheckState == CheckState.Checked)
                        {
                            CritTitle = string.Format("{0} Blank", CritTitle);
                        }

                        if (string.IsNullOrEmpty(ls_Dest))
                        {
                            ls_Dest = cboDestField.Text;
                        }
                        if (Strings.Len(ls_Dest) > 0)
                        {
                            CritTitle = string.Format("{0} {1}", CritTitle, ls_Dest);
                        }

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "(MeasureCriteriaSetID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MultSelAny) ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";

                        if (cboDestField.SelectedIndex > -1)
                        {
                            modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboDestField, cboDestField.SelectedIndex));
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        }

                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt1ValueOperator.Text);

                        if (!string.IsNullOrEmpty(txtOpt1TypeinValue.Text))
                        {
                            modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt1TypeinValue.Text);
                        }
                        else if (cboDestField.SelectedIndex > -1)
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
                        }

                        modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";

                        modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboJoinOperator.Text);

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW lstFieldList.SetSelected(li_cnt, false);
                        lstFieldList.SelectedIndex = li_cnt;
                        lstFieldList.SelectedItem.Active = false;
                    }
                }
                //end loop

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
            string fieldLookupTableID = null;
            string IDFromLookup = null;
            string field1type = null;
            string CritTitle = null;
            //Dim li_order As Long
            int li_CriteriaSetID;
            int li_cnt = 0;
            int li_LookupVal = 0;
            string ls_LookupTxt = null;
            int Index = 0;
            var rs_Temp = new DataSet();

            // ERROR: Not supported in C#: OnErrorStatement
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
                    const string sqlTableName13 = "tbl_setup_Misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);
                    IDFromLookup = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["Id"].ToString();

                    modGlobal.gv_rs.Dispose();
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                ls_LookupTxt = cboLookupValues.Text;
                li_LookupVal = Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                {
                    if (lstFieldList.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName15 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName15].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        //make sure that the field type is not a date field
                        if (Strings.Mid(field1type, 1, 3) == "Dat")
                        {
                            RadMessageBox.Show(string.Format("You cannot compare this field to a lookup value, because {0} is a date field. Please re-Specify...",
                                Support.GetItemString(lstFieldList, li_cnt)));
                            return;
                        }

                        modGlobal.gv_Action = "Add";

                        CritTitle = string.Format("{0} {1} {2}", Support.GetItemString(lstFieldList, li_cnt), cboOpt2ValueOperator.Text, ls_LookupTxt);

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator)";

                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt2ValueOperator.Text);
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, IDFromLookup);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_LookupVal);
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        modGlobal.gv_sql = string.Format("{0} '{1}')", modGlobal.gv_sql, cboJoinOperator.Text);

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW lstFieldList.SetSelected(li_cnt, false);
                        lstFieldList.SelectedIndex = li_cnt;
                        lstFieldList.SelectedItem.Active = false;
                    }
                }

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
            string field1type = null;
            string Field2Type = null;
            string CritTitle = null;
            //Dim li_order As Long
            int li_CriteriaSetID;
            int li_cnt = 0;


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

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                {
                    if (lstFieldList.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName16 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName16].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        //make sure that the 2 selected fields are of the same type
                        if (!string.IsNullOrEmpty(cboField2List.Text))
                        {
                            //find the field type
                            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                            modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName17 = "tbl_setup_Datadef";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                            Field2Type = modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["FieldType"].ToString();
                            modGlobal.gv_rs.Dispose();
                            if (field1type != Field2Type)
                            {
                                if (field1type != "Date/Time" & field1type != "Time")
                                {
                                    RadMessageBox.Show("The 2 fields that you have selected are not of the same type. Please re-specify...");
                                    return;
                                }
                            }
                        }

                        //make sure that the typed value is numeric
                        if (!Information.IsNumeric(txtOpt3TypeinValue.Text))
                        {
                            RadMessageBox.Show("The typed value has to be a numeric value. Please re-Specify...");
                            return;
                        }

                        if (field1type == "Date")
                        {
                            if (string.IsNullOrEmpty(cboOpt3Unit.Text))
                            {
                                RadMessageBox.Show("Please define a date unit associated with the value");
                                return;
                            }
                            else if (cboOpt3Unit.Text != "Years" & cboOpt3Unit.Text != "Months" & cboOpt3Unit.Text != "Days")
                            {
                                RadMessageBox.Show("Please define the appropriate date unit associated with the value");
                                return;
                            }
                        }

                        if (field1type == "Time")
                        {
                            if (string.IsNullOrEmpty(cboOpt3Unit.Text))
                            {
                                RadMessageBox.Show("Please define a time unit associated with the value");
                                return;
                            }
                            else if (cboOpt3Unit.Text != "Hours" & cboOpt3Unit.Text != "Minutes" & cboOpt3Unit.Text != "Seconds")
                            {
                                RadMessageBox.Show("Please define the appropriate time unit associated with the value");
                                return;
                            }
                        }

                        if (field1type == "Time" & !Information.IsNumeric(txtOpt3TypeinValue.Text))
                        {
                            RadMessageBox.Show("Please define a numeric value for this Time difference. Duration will be in minutes  ");
                            return;
                        }

                        modGlobal.gv_Action = "Add";


                        CritTitle = Support.GetItemString(lstFieldList, li_cnt);
                        CritTitle = string.Format("{0} {1} {2}", CritTitle, cboFieldOperator.Text, cboField2List.Text);
                        CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3ValueOperator.Text);
                        CritTitle = string.Format("{0} {1}", CritTitle, txtOpt3TypeinValue.Text);
                        if (field1type == "Date" | field1type == "Time")
                        {
                            CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3Unit.Text);
                        }

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, FieldOperator, DateUnit, JoinOperator)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstFieldList, li_cnt) + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpt3ValueOperator.Text + "', ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3TypeinValue.Text + "',";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboField2List, cboField2List.SelectedIndex) + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboFieldOperator.Text + "', ";

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
                                case "Hours":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'h',";
                                    break;
                                case "Minutes":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 'n',";
                                    break;
                                case "Seconds":
                                    modGlobal.gv_sql = modGlobal.gv_sql + " 's',";
                                    break;
                            }
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                        }
                        modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, cboJoinOperator.Text);

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //lstFieldList.Selected(li_cnt) = False
                        lstFieldList.SelectedIndex = li_cnt;
                        lstFieldList.SelectedItem.Active = false;
                    }
                }

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
            //Dim li_order As Long
            int li_CriteriaSetID;
            int li_cnt;
            int li_cnt2 = 0;
            string[] ls_months = null;

            try
            {
                if (cboOpt5ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list.");
                    return;
                }

                if (lstRange.Items.Count == 0)
                {
                    RadMessageBox.Show("Value(s) should be typed in.");
                    return;
                }

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                {
                    if (lstFieldList.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName19 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        if (field1type != "Date")
                        {
                            RadMessageBox.Show("This method is only valid with date fields", "Field is not a date", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                        }

                        for (li_cnt2 = 0; li_cnt2 <= lstRange.Items.Count - 1; li_cnt2++)
                        {
                            Array.Resize(ref ls_months, li_cnt2 + 1);
                            ls_months[li_cnt2] = Support.GetItemString(lstRange, li_cnt2);
                        }

                        modGlobal.gv_Action = "Add";

                        CritTitle = Support.GetItemString(lstFieldList, li_cnt);
                        CritTitle = string.Format("{0} Month {1}", CritTitle, cboOpt5ValueOperator.Text);
                        CritTitle = string.Format("{0} ({1})", CritTitle, Strings.Join(ls_months, ","));

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, DateUnit, JoinOperator)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt5ValueOperator.Text);
                        modGlobal.gv_sql = string.Format("{0} '({1})',", modGlobal.gv_sql, Strings.Join(ls_months, ","));
                        modGlobal.gv_sql = modGlobal.gv_sql + " 'm',";
                        modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, cboJoinOperator.Text);

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW lstFieldList.SetSelected(li_cnt, false);
                        lstFieldList.SelectedIndex = li_cnt;
                        lstFieldList.SelectedItem.Active = false;
                    }
                }

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

        private void AddCriteriaWithMethod6()
        {
            string field1type = null;
            string Field2Type = null;
            string CritTitle = null;
            //Dim li_order As Long
            int li_CriteriaSetID = InsertStepandSetRecords();
            int li_cnt = 0;
            string[] GroupIDs = null;
            int li_group = 0;


            try
            {
                if (chkBlank6.CheckState == CheckState.Checked & cboOpt6ValueOperator.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please choose an operator for Blank Comparison");
                    return;
                }
                GroupIDs = new string[li_group + 1];

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                {
                    if (lstFieldList.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName19 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName19].Rows[0]["FieldType"].ToString();
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

                        modGlobal.gv_Action = "Add";

                        CritTitle = string.Format("{0}{1},", CritTitle, Support.GetItemString(lstFieldList, li_cnt));

                        Array.Resize(ref GroupIDs, li_group + 1);
                        GroupIDs[li_group] = Convert.ToString(Support.GetItemData(lstFieldList, li_cnt));
                        li_group = li_group + 1;
                    }
                }

                CritTitle = Strings.Mid(CritTitle, 1, Strings.Len(CritTitle) - 1);
                CritTitle = string.Format("{0}) {1} BLANK", CritTitle, cboOpt6ValueOperator.Text);

                if (Information.UBound(GroupIDs) < 1)
                {
                    RadMessageBox.Show("You must select more than one field to determine the earliest.");
                    return;
                }
                Debug.Print(CritTitle);

                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, FieldOperator, DateUnit, JoinOperator)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Null, ";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboOpt6ValueOperator.Text + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + Strings.Join(GroupIDs, ",") + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + "NULL, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "')";
                //Debug.Print gv_sql

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

        private void lstFieldList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshLookupListForThisField();
                RefreshCriteriaFieldList();
                RefreshSelectedField();
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
            //CompareSelectedFields
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
                        sstabOptions6.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 0;
                        //sstabOptions1.DockTabStrip.SelectedIndex = 0;
                        sstabOptions.ActiveWindow = sstabOptions1;
                        ChangeNote(true);
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

        private void ChangeNote(bool Normal)
        {
            try
            {
                if (Normal)
                {
                    lblNote.Text = "Note: If you are defining the interval between 2 date fields, select the earliest date field from the above list";
                }
                else
                {
                    lblNote.Text = "Note:  Please select the grouped dates/times from the field list.  Also, remember to use a time field in the same set as the next criteria entered.";
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
                        sstabOptions6.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 1;
                        sstabOptions.ActiveWindow = sstabOptions2;
                        ChangeNote(true);
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
                        sstabOptions6.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 2;
                        sstabOptions.ActiveWindow = sstabOptions3;
                        ChangeNote(true);
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
                        sstabOptions6.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 3;
                        sstabOptions.ActiveWindow = sstabOptions4;
                        ChangeNote(true);
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
                        sstabOptions1.Enabled = false;
                        sstabOptions2.Enabled = false;
                        sstabOptions3.Enabled = false;
                        sstabOptions4.Enabled = false;
                        sstabOptions5.Enabled = true;
                        sstabOptions6.Enabled = false;
                        //LDW sstabOptions.SelectedIndex = 4;
                        sstabOptions.ActiveWindow = sstabOptions5;
                        ChangeNote(true);
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

        private void Opt6Method_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(Opt6Method.IsChecked))
                {
                    sstabOptions.Enabled = true;
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = false;
                    sstabOptions4.Enabled = false;
                    sstabOptions5.Enabled = false;
                    sstabOptions6.Enabled = true;
                    //LDW sstabOptions.SelectedIndex = 5;
                    sstabOptions.ActiveWindow = sstabOptions6;
                    cboOpt6ValueOperator.SelectedIndex = 0;
                    ChangeNote(false);
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
                    cboDestField.SelectedIndex = -1;
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

        private void AddCriteriaWithMethod3()
        {
            string field1type = null;
            string CritTitle = null;
            int li_CriteriaSetID;
            int li_cnt = 0;
            string ls_LookupTxt = null;
            int li_LookupVal = 0;

            try
            {

                if (cboOpLkTable.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field operation from the list");
                    return;
                }

                if (cboLookupTables.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select lookup table from list.");
                    return;
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                ls_LookupTxt = cboLookupTables.Text;
                li_LookupVal = Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex);

                //Loop for each selected field
                for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                {
                    if (lstFieldList.SelectedIndex == li_cnt)
                    {
                        //find the field type
                        modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName20 = "tbl_setup_Datadef";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                        field1type = modGlobal.gv_rs.Tables[sqlTableName20].Rows[0]["FieldType"].ToString();
                        modGlobal.gv_rs.Dispose();

                        //make sure that the field type is not a date field
                        if (Strings.Mid(field1type, 1, 3) == "Dat")
                        {
                            RadMessageBox.Show(string.Format("You cannot compare {0} to a lookup table, because the selected field is a date field. Please re-Specify...",
                                Support.GetItemString(lstFieldList, li_cnt)));
                            return;
                        }

                        modGlobal.gv_Action = "Add";

                        CritTitle = string.Format("{0} {1} [{2}] Lookup Table ", Support.GetItemString(lstFieldList, li_cnt), cboOpLkTable.Text, ls_LookupTxt);

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSubmitSubs ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetSubmitSubsID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator)";

                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                        modGlobal.gv_sql = modGlobal.gv_sql + li_CriteriaSetID + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstFieldList, li_cnt) + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOpLkTable.Text + "', ";
                        modGlobal.gv_sql = modGlobal.gv_sql + li_LookupVal + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "')";

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //LDW lstFieldList.SetSelected(li_cnt, false);
                        lstFieldList.SelectedIndex = li_cnt;
                        lstFieldList.SelectedItem.Active = false;
                    }
                }

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

        private int InsertStepandSetRecords()
        {
            int functionReturnValue = 0;
            int li_StepID;
            int li_SetID = 0;
            string ls_DefJoin = null;


            try
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepSubmitSubs WHERE MeasureStepID = " + MeasureStepID;
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName1n = "tbl_Setup_MeasureStepSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1n, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName1n].Rows.Count == 0)
                {
                    modGlobal.gv_sql = "insert into tbl_Setup_MeasureStepSubmitSubs (MeasureStepID) ";
                    modGlobal.gv_sql = string.Format("{0} values ({1}) ", modGlobal.gv_sql, MeasureStepID);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepSubmitSubs WHERE MeasureStepID = " + MeasureStepID;
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1n, modGlobal.gv_rs);
                }
                li_StepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1n].Rows[0]["MeasureStepSubmitSubsID"]);
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureCriteriaSetSubmitSubs  WHERE MeasureStepSubmitSubsID = {0} AND MeasureCriteriaSet = {1}",
                     li_StepID, Support.GetItemData(cboSet, cboSet.SelectedIndex) - 1);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2n = "sqlTableName1n";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2n, modGlobal.gv_rs);
                //LDW if (!modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName2n].Rows.Count; itr++)
                {
                    var myRow2n = (DataRow)modGlobal.gv_rs.Tables[sqlTableName2n].Rows[itr];
                    int rowIndex2n = modGlobal.gv_rs.Tables[sqlTableName2n].Rows.IndexOf(myRow2n);
                    if (rowIndex2n != modGlobal.gv_rs.Tables[sqlTableName2n].Rows.Count - 1)
                    {
                        ls_DefJoin = myRow2n.Field<string>("JoinOperator");
                    }
                    else
                    {
                        ls_DefJoin = "AND";
                    }
                }
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSetSubmitSubs " + " WHERE MeasureStepSubmitSubsID = " + li_StepID +
                    " AND MeasureCriteriaSet = " + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName3n = "tbl_Setup_MeasureCriteriaSetSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3n, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName3n].Rows.Count; itr++)
                {
                    var myRow3n = (DataRow)modGlobal.gv_rs.Tables[sqlTableName3n].Rows[itr];
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName3n].Rows.IndexOf(myRow3n);
                    if (rowIndex == modGlobal.gv_rs.Tables[sqlTableName3n].Rows.Count - 1)
                    {
                        //default join to AND
                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteriaSetSubmitSubs (";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureStepSubmitSubsID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator) ";
                        modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, li_StepID);
                        modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, ls_DefJoin);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSetSubmitSubs");
                    }
                    else
                    {
                        li_SetID = myRow3n.Field<int>("measureCriteriaSetSubmitSubsID");
                        modGlobal.gv_rs.Dispose();
                    }
                }

                functionReturnValue = li_SetID;
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
            return functionReturnValue;

            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
            //return functionReturnValue;
        }

        private void RefreshSelectedField()
        {
            string ls_FieldType = null;
            int li_SelCount = 0;
            bool lb_CanSave = false;
            int li_found = 0;
            int li_cnt = 0;
            int li_cnt2 = 0;

            try
            {
                if (lstFieldList.SelectedItems.Count == 0)
                {
                    is_Selected = new modGlobal.SelectedMeasureField[1];
                }
                else
                {
                    if (lstFieldList.SelectedItems.Count == 1 & (Information.UBound(is_Selected) == 1 | Information.UBound(is_Selected) > 1))
                    {
                        is_Selected = new modGlobal.SelectedMeasureField[1];
                    }

                    for (li_cnt = 0; li_cnt <= lstFieldList.Items.Count - 1; li_cnt++)
                    {
                        if (lstFieldList.SelectedIndex == li_cnt)
                        {
                            li_found = 0;
                            li_SelCount = Information.UBound(is_Selected);

                            if (li_SelCount != 0)
                            {
                                for (li_cnt2 = 1; li_cnt2 <= Information.UBound(is_Selected); li_cnt2++)
                                {
                                    if (is_Selected[li_cnt2].DDID == Support.GetItemData(lstFieldList, li_cnt))
                                    {
                                        li_found = 1;
                                        break; // TODO: might not be correct. Was : Exit For
                                    }
                                }
                            }

                            if (li_found == 0)
                            {
                                //get the field types
                                modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
                                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                                const string sqlTableName27 = "tbl_setup_Datadef";
                                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);
                                ls_FieldType = modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["FieldType"].ToString();
                                modGlobal.gv_rs.Dispose();

                                if (li_SelCount > 0)
                                {
                                    if (is_Selected[li_SelCount].FieldType != ls_FieldType)
                                    {
                                        RadMessageBox.Show(string.Format("The data type of {0} and {1} are not the same.", Support.GetItemString(lstFieldList, li_cnt),
                                            is_Selected[li_SelCount].Description), "Cannot Compare Different Data Types", MessageBoxButtons.OK, RadMessageIcon.Error);
                                        //LDW lstFieldList.SetSelected(li_cnt, false);
                                        lstFieldList.SelectedIndex = li_cnt;
                                        lstFieldList.SelectedItem.Active = false;

                                        lb_CanSave = false;
                                    }
                                    else
                                    {
                                        lb_CanSave = true;
                                    }
                                }
                                else
                                {
                                    lb_CanSave = true;
                                }

                                if (lb_CanSave)
                                {
                                    Array.Resize(ref is_Selected, li_SelCount + 2);
                                    is_Selected[li_SelCount + 1].DDID = Support.GetItemData(lstFieldList, li_cnt);
                                    is_Selected[li_SelCount + 1].Description = Support.GetItemString(lstFieldList, li_cnt);
                                    is_Selected[li_SelCount + 1].FieldType = ls_FieldType;
                                }
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
    }
}
