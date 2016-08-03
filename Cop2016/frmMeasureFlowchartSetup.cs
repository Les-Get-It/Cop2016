using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmMeasureAddCritSetup : Telerik.WinControls.UI.RadForm
    {
        private string is_Measure;
        private int ii_MeasureID = 0;
        private int ii_MeasureSetID = 0;
        private string is_CritType;
        private string is_RowCount;
        private modGlobal.SelectedMeasureField[] is_Selected;


        public frmMeasureAddCritSetup()
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

        private void cboStep_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (is_CritType == "Reg" | is_CritType == "Risk")
                {
                    RefreshSetList();
                    RefreshCat();
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
            int indexInChildren = Array.IndexOf(TabFirstField.MdiChildren, TabFirstField.ActiveWindow);
            //LDW if (TabFirstField.SelectedIndex == 0)

            try
            {
                if (indexInChildren == 0)
                {
                    if (sstabOptions1.Enabled == false & sstabOptions2.Enabled == false & sstabOptions3.Enabled == false & sstabOptions4.Enabled
                        == false & sstabOptions5.Enabled == false & sstabOptions6.Enabled == false)
                    {
                        RadMessageBox.Show("Please select a method.");
                        return;
                    }

                    if (lstFieldList.SelectedIndex < 0)
                    {
                        RadMessageBox.Show("Please select field(s) from the list");
                        return;
                    }
                }

                if (string.IsNullOrEmpty(cboCat.Text) & string.IsNullOrEmpty(txtGoToStep.Text) & (is_CritType == "Reg" | is_CritType == "Risk"))
                {
                    RadMessageBox.Show("Please select a Category to Assign to this set, or define a step that it will jump to.");
                    return;
                }

                if (string.IsNullOrEmpty(cboStep.Text))
                {
                    RadMessageBox.Show("Please select the Criteria Set.");
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

                if (indexInChildren == 1)
                {
                    if (lstGroupList.SelectedIndex < 0)
                    {
                        RadMessageBox.Show("Please select a group from the list");
                        return;
                    }
                    AddCriteriaWithGroupLogic();
                }
                else
                {

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
                    var myRow = (DataRow)rsIsValid.Tables[sqlTableName1].Rows[itr];
                    int rowIndex = rsIsValid.Tables[sqlTableName1].Rows.IndexOf(myRow);
                    if (rowIndex == rsIsValid.Tables[sqlTableName1].Rows.Count - 1)
                    {
                        RadMessageBox.Show("Please Enter A Valid Month", "Invalid Month", MessageBoxButtons.OK, RadMessageIcon.Error);
                        //goto EditCat;
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

        private void frmMeasureAddCritSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                //LDW sstabOptions.SelectedIndex = 0;
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
                RefreshMeasureGroupLogic();
                RefreshLookupTables();

                if (is_CritType == "Reg" | is_CritType == "Risk")
                    RefreshCatList();
                RefreshStepList();

                if (is_CritType == "Filter")
                {
                    cboSet.Visible = false;
                    lblSet.Visible = false;
                    lblCat.Visible = false;
                    txtGoToStep.Visible = false;
                    cboCat.Visible = false;
                }
                else if (is_CritType == "Reg")
                {
                    cboSet.Visible = true;
                    lblSet.Visible = true;
                    lblCat.Visible = true;
                    txtGoToStep.Visible = true;
                    cboCat.Visible = true;
                }
                else if (is_CritType == "Risk")
                {
                    cboSet.Visible = true;
                    lblSet.Visible = true;
                    lblCat.Visible = true;
                    txtGoToStep.Visible = true;
                    cboCat.Visible = true;
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

        private void RefreshCatList(string CatID = "")
        {
            int li_SELcatID = -1;

            try
            {
                // ERROR: Not supported in C#: OnErrorStatement
                modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT ";

                if (is_CritType == "Reg")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'CI'";
                }
                else if (is_CritType == "Risk")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'RA' ";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY CAT";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_MEASURE_CAT";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                cboCat.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    cboCat.Items.Add(new ListBoxItem(myRow2.Field<string>("CAT"), myRow2.Field<int>("measure_catid")).ToString());
                    if (!string.IsNullOrEmpty(CatID))
                        if (myRow2.Field<int>("measure_catid") == Convert.ToInt32(CatID))
                        {
                            li_SELcatID = cboCat.Items.Count - 1;
                        }
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                cboCat.SelectedIndex = li_SELcatID;

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

        private void RefreshFieldsList()
        {
            //retrieve the list of table fields
            //fields are setup in the map measures form - tbl_setup_FieldMeasureSet

            try
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef dd ";
                //" WHERE dd.DDID = fm.DDID AND fm.MeasureSetID = " & ii_MeasureSetID
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE (ParentDDID IS NULL OR ParentDDID = DDID)";

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
                const string sqlTableName3 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                //Display the list of fields
                lstFieldList.Items.Clear();
                cboField2List.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    lstFieldList.Items.Add(new ListBoxItem(myRow3.Field<string>("FieldName"), myRow3.Field<int>("DDID")).ToString());
                    cboField2List.Items.Add(new ListBoxItem(myRow3.Field<string>("FieldName"), myRow3.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
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
                const string sqlTableName4 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);
                cboLookupTables.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    cboLookupTables.Items.Add(new ListBoxItem(myRow4.Field<string>("BaseTable"), myRow4.Field<int>("basetableid")).ToString());

                    //LDW modGlobal.gv_rs.MoveNext();
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

        private void RefreshStepList()
        {
            int li_step = 0;

            try
            {
                cboStep.Items.Clear();

                if (is_CritType == "Reg" | is_CritType == "Risk")
                {
                    //LDW cboStep.Locked = false;
                    cboStep.DropDownStyle = RadDropDownStyle.DropDown;
                    modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep " + " FROM tbl_setup_MeasureStep ms left join tbl_MEASURE_CAT mc" +
                        " on mc.MEASURE_CATID = ms.MEASURE_CATID  WHERE  0 = 0 ";

                    if (Convert.ToInt16(is_RowCount) == 0 | Information.IsDBNull(ii_MeasureID))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureID = -1";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} AND MeasureID = {1}", modGlobal.gv_sql, ii_MeasureID);
                    }

                    if (is_CritType == "Reg")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'CI' or CAT_TYPE is null)";
                    }
                    else if (is_CritType == "Risk")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
                    }

                    modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100";

                    modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep";

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_setup_MeasureStep";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                    //Display the list of criteria
                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                    {
                        li_step = myRow5.Field<int>("measurestep");
                        cboStep.Items.Add(new ListBoxItem("Step " + li_step, li_step).ToString());
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    modGlobal.gv_rs.Dispose();

                    //always add a new one to the list in addition to the previous ones
                    cboStep.Items.Add(new ListBoxItem("Step " + li_step + 1, li_step + 1).ToString());
                }
                else if (is_CritType == "Filter")
                {
                    cboStep.Items.Add("Filter");
                    //filter is step -100
                    Support.SetItemData(cboStep, cboStep.Items.Count - 1, -100);
                    cboStep.SelectedIndex = 0;
                    //LDW cboStep.Locked = true;
                    cboStep.DropDownStyle = RadDropDownStyle.DropDownList;
                }

                RefreshSetList();

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
                cboSet.Items.Clear();

                if (is_CritType == "Reg" | is_CritType == "Risk")
                {
                    //LDW cboSet.Locked = false;
                    cboSet.DropDownStyle = RadDropDownStyle.DropDown;

                    if (cboStep.SelectedIndex > -1)
                    {
                        modGlobal.gv_sql = string.Format("SELECT DISTINCT mcs.MeasureCriteriaSet  FROM tbl_setup_MeasureCriteriaSet mcs inner join " +
                            "tbl_Setup_MeasureStep ms on  mcs.MeasureStepID = ms.MeasureStepID  left join tbl_MEASURE_CAT mc on mc.MEASURE_CATID = ms.MEASURE_CATID " +
                            "Where ms.MeasureStep = {0} and MeasureStep <> -100", Support.GetItemData(cboStep, cboStep.SelectedIndex));
                        if (Convert.ToInt16(is_RowCount) == 0 | Information.IsDBNull(ii_MeasureID))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureID = -1";
                        }
                        else
                        {
                            modGlobal.gv_sql = string.Format("{0} AND ms.MeasureID = {1}", modGlobal.gv_sql, ii_MeasureID);
                        }

                        if (is_CritType == "Reg")
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'CI' or CAT_TYPE is null)";
                        }
                        else if (is_CritType == "Risk")
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
                        }

                        modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureCriteriaSet";

                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName6 = "tbl_setup_MeasureCriteriaSet";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                        li_Sets = modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count;
                        modGlobal.gv_rs.Dispose();
                    }
                }
                else if (is_CritType == "Filter")
                {
                    //LDW cboSet.Locked = true;
                    cboSet.DropDownStyle = RadDropDownStyle.DropDownList;
                }

                //Display the list of criteria
                for (li_cnt = 1; li_cnt <= li_Sets + 1; li_cnt++)
                {
                    cboSet.Items.Add(new ListBoxItem("Set " + li_cnt, li_cnt).ToString());
                }

                if (is_CritType == "Filter")
                {
                    cboSet.SelectedIndex = 0;
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
                else if (cboStep.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please Choose a Step #");
                }

                //get join operator for criteria (if avail)
                modGlobal.gv_sql = string.Format("Select mc.JoinOperator from tbl_setup_MeasureCriteriaSet mcs,  tbl_Setup_MeasureStep ms, tbl_Setup_MeasureCriteria mc WHERE " +
                    "ms.MeasureStepID = mcs.MeasureStepID  AND mc.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID  AND ms.MeasureStep = {0} AND ms.MeasureID = {1} AND " +
                    "mcs.MeasureCriteriaSet = {2}", Support.GetItemData(cboStep, cboStep.SelectedIndex), ii_MeasureID, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                if (is_CritType == "Reg")
                {
                    modGlobal.gv_sql = string.Format("{0} AND ms.Measure_CATID in (SELECT MEASURE_CATID FROM  tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')", modGlobal.gv_sql);
                }
                else if (is_CritType == "Risk")
                {
                    modGlobal.gv_sql = string.Format("{0} AND (ms.Measure_CATID in (SELECT MEASURE_CATID FROM  tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA') OR IsRisk = 1)", modGlobal.gv_sql);
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName7].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["JoinOperator"].ToString();
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
                const string sqlTableName8 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count > 0)
                {
                    LookupTableID = modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["LookupTableID"].ToString();

                    modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                    modGlobal.gv_sql = string.Format("{0} where basetableid = {1}", modGlobal.gv_sql, LookupTableID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName9 = "tbl_setup_misclookuplist";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                    {
                        cboLookupValues.Items.Add(new ListBoxItem("(" + myRow9.Field<string>("Id") + ") " + myRow9.Field<string>("FIELDVALUE"), myRow9.Field<int>("LookupID")).ToString());
                        //LDW modGlobal.gv_rs.MoveNext();
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
            int ParentDDID = 0;

            try
            {
                //find the field type
                modGlobal.gv_sql = "Select FieldType, ParentDDID from tbl_setup_Datadef ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_Datadef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                field1type = modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["FieldType"].ToString();
                frmMultSel.Visible = (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["ParentDDID"]) ? false :
                    (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["ParentDDID"]) > 0 ? true : false));

                modGlobal.gv_rs.Dispose();

                if (field1type == "Date/Time" | field1type == "Time")
                {
                    field1type = "Date/Time' OR tbl_setup_Datadef.fieldtype = 'Time";
                }

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
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '{1}')",
                        modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and (tbl_setup_DataDef.fieldtype = '{1}' ) ", modGlobal.gv_sql, field1type);
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_DataDef.ddid <> {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName11 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                //Display the list of fields
                cboField2List.Items.Clear();
                cboDestField.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                {
                    cboField2List.Items.Add(new ListBoxItem(myRow11.Field<string>("FieldName"), myRow11.Field<int>("DDID")).ToString());

                    cboDestField.Items.Add(new ListBoxItem(myRow11.Field<string>("FieldName"), myRow11.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
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

                        CritTitle = (frmMultSel.Visible ? string.Format("({0}) ", OptMultAny.IsChecked ? "ANY" : "ALL") : "");

                        CritTitle = string.Format("{0}{1} {2}", CritTitle, Support.GetItemString(lstFieldList, li_cnt), cboOpt1ValueOperator.Text);
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
                        modGlobal.gv_sql = string.Format("{0}{1} )", modGlobal.gv_sql, frmMultSel.Visible ? (OptMultAny.IsChecked ? true : false).ToString() : "NULL");

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
            int lL_LookupVal = 0;
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

                    modGlobal.gv_sql = "SELECT CompareToDesc from tbl_Setup_TableDef WHERE BaseTableID = " + modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["basetableid"];
                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName14 = "tbl_Setup_TableDef";
                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, rs_Temp);

                    if (Information.IsDBNull(rs_Temp.Tables[sqlTableName14].Rows[0]["CompareToDesc"]))
                    {
                        IDFromLookup = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["Id"].ToString();
                    }
                    else
                    {
                        IDFromLookup = modGlobal.gv_rs.Tables[sqlTableName13].Rows[0]["FIELDVALUE"].ToString();
                    }

                    rs_Temp.Dispose();
                    rs_Temp = null;

                    modGlobal.gv_rs.Dispose();
                }

                if (string.IsNullOrEmpty(cboJoinOperator.Text))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                    return;
                }

                ls_LookupTxt = cboLookupValues.Text;
                lL_LookupVal = Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);

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

                        CritTitle = (frmMultSel.Visible ? string.Format("({0}) ", OptMultAny.IsChecked ? "ANY" : "ALL") : "");

                        CritTitle = string.Format("{0}{1} {2} {3}", CritTitle, Support.GetItemString(lstFieldList, li_cnt), cboOpt2ValueOperator.Text, ls_LookupTxt);

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MultSelAny)";

                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt2ValueOperator.Text);
                        modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, IDFromLookup);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, lL_LookupVal);
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                        modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                        modGlobal.gv_sql = string.Format("{0}{1} )", modGlobal.gv_sql, frmMultSel.Visible ? (OptMultAny.IsChecked ? true : false).ToString() : "NULL");

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


            // ERROR: Not supported in C#: OnErrorStatement

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

                        if (field1type == "Date" | field1type == "Time" | field1type == "Date/Time")
                        {
                            CritTitle = string.Format("{0} {1}", CritTitle, cboOpt3Unit.Text);
                        }

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, CriteriaTitle,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, FieldOperator, DateUnit, JoinOperator)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpt3ValueOperator.Text);
                        modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, txtOpt3TypeinValue.Text);
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboField2List, cboField2List.SelectedIndex));
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


            // ERROR: Not supported in C#: OnErrorStatement

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

                //if the criteria is really long, trim it so it can fit in the 200 char field
                if (Strings.Len(CritTitle) > 190)
                    CritTitle = Strings.Mid(CritTitle, 1, 190);

                CritTitle = string.Format("{0}) {1} BLANK", CritTitle, cboOpt6ValueOperator.Text);

                if (Information.UBound(GroupIDs) < 1)
                {
                    RadMessageBox.Show("You must select more than one field to determine the earliest.");
                    return;
                }
                //Debug.Print CritTitle

                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, CriteriaTitle,";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ValueOperator, FieldValue, FieldOperator, DateUnit, JoinOperator)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = modGlobal.gv_sql + "Null, ";
                modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, cboOpt6ValueOperator.Text);
                modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Strings.Join(GroupIDs, ","));
                modGlobal.gv_sql = modGlobal.gv_sql + "NULL, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, cboJoinOperator.Text);
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
                //LDW if (eventSender.IsChecked)
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

                        CritTitle = (frmMultSel.Visible ? string.Format("({0}) ", OptMultAny.IsChecked ? "ANY" : "ALL") : "");
                        CritTitle = string.Format("{0}{1} {2} [{3}] Lookup Table ", CritTitle, Support.GetItemString(lstFieldList, li_cnt), cboOpLkTable.Text, ls_LookupTxt);

                        li_CriteriaSetID = InsertStepandSetRecords();

                        modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureCriteriaSetID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MultSelAny)";

                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";

                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, li_cnt));
                        modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboOpLkTable.Text);
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_LookupVal);
                        modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, cboJoinOperator.Text);
                        modGlobal.gv_sql = string.Format("{0}{1} )", modGlobal.gv_sql, frmMultSel.Visible ? (OptMultAny.IsChecked ? true : false).ToString() : "NULL");

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
            int li_StepID = 0;
            int li_SetID = 0;
            string ls_DefJoin = null;

            try
            {
                modGlobal.gv_sql = "SELECT * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID ";
                modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql, ii_MeasureID);
                modGlobal.gv_sql = string.Format("{0} AND MeasureStep = {1}", modGlobal.gv_sql, Support.GetItemData(cboStep, cboStep.SelectedIndex));
                if (is_CritType == "Reg")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE is null or CAT_TYPE = 'CI') ";
                }
                else if (is_CritType == "Risk")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName21 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);


                //gv_sql = "SELECT * FROM tbl_Setup_MeasureStep WHERE MeasureID = " & _
                //'    ii_MeasureID & " AND MeasureStep = " & cboStep.ItemData(cboStep.ListIndex)
                //
                //If is_CritType = "Risk" Then
                //    gv_sql = gv_sql & " AND Measure_CATID in (SELECT MEASURE_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')"
                //ElseIf is_CritType = "Reg" Then
                //    gv_sql = gv_sql & " AND Measure_CATID in (SELECT MEASURE_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')"
                //End If


                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName21].Rows.Count; itr++)
                {
                    var myRow21 = (DataRow)modGlobal.gv_rs.Tables[sqlTableName21].Rows[itr];
                    int rowIndex21 = modGlobal.gv_rs.Tables[sqlTableName21].Rows.IndexOf(myRow21);

                    if (rowIndex21 == modGlobal.gv_rs.Tables[sqlTableName21].Rows.Count - 1)
                    {
                        modGlobal.gv_sql = "SELECT * ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep  ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                        const string sqlTableName22 = "tbl_Setup_MeasureStep";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                        //LDW modGlobal.gv_rs.AddNew();
                        //LDW create new datatable row
                        DataRow newRow = modGlobal.gv_rs.Tables[sqlTableName22].NewRow();

                        newRow["MeasureID"] = ii_MeasureID;
                        newRow["measurestep"] = Support.GetItemData(cboStep, cboStep.SelectedIndex);

                        //Add new datatable row
                        modGlobal.gv_rs.Tables[sqlTableName22].Rows.Add(newRow);

                        //Filters do not get assigned to a category
                        //is_CritType = "Reg" Or is_CritType = "Risk" Then
                        foreach (DataRow myRow22 in modGlobal.gv_rs.Tables[sqlTableName22].Rows)
                        {
                            if (cboCat.SelectedIndex > -1 & string.IsNullOrEmpty(txtGoToStep.Text))
                            {
                                myRow22.SetField("measure_catid", Support.GetItemData(cboCat, cboCat.SelectedIndex));
                            }

                            if (!string.IsNullOrEmpty(txtGoToStep.Text))
                            {
                                myRow22.SetField("GoToStep", txtGoToStep.Text);
                            }

                            if (is_CritType == "Risk")
                            {
                                myRow22.SetField("isrisk", 1);
                            }
                            else
                            {
                                myRow22.SetField("isrisk", 0);
                            }
                        }

                        modGlobal.gv_rs.AcceptChanges();
                        modGlobal.gv_rs.Dispose();

                        li_StepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");
                    }
                    else
                    {
                        li_StepID = myRow21.Field<int>("MeasureStepID");
                        modGlobal.gv_rs.Dispose();
                    }
                }

                modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureCriteriaSet  WHERE MeasureStepID = {0} AND MeasureCriteriaSet = {1}",
                    li_StepID, Support.GetItemData(cboSet, cboSet.SelectedIndex) - 1);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22a = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22a, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName22a].Rows.Count; itr++)
                {
                    var myRow22 = (DataRow)modGlobal.gv_rs.Tables[sqlTableName22a].Rows[itr];
                    int rowIndex22 = modGlobal.gv_rs.Tables[sqlTableName22a].Rows.IndexOf(myRow22);

                    if (rowIndex22 != modGlobal.gv_rs.Tables[sqlTableName22a].Rows.Count - 1)
                    {
                        ls_DefJoin = myRow22.Field<string>("JoinOperator");
                    }
                    else
                    {
                        ls_DefJoin = "AND";
                    }
                }
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureCriteriaSet  WHERE MeasureStepID = {0} AND MeasureCriteriaSet = {1}",
                    li_StepID, Support.GetItemData(cboSet, cboSet.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName23 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName23].Rows.Count; itr++)
                {
                    var myRow23 = (DataRow)modGlobal.gv_rs.Tables[sqlTableName23].Rows[itr];
                    int rowIndex23 = modGlobal.gv_rs.Tables[sqlTableName23].Rows.IndexOf(myRow23);

                    if (rowIndex23 == modGlobal.gv_rs.Tables[sqlTableName23].Rows.Count - 1)
                    {
                        //default join to AND
                        //LDW modGlobal.gv_rs.AddNew();
                        //LDW create new datatable row
                        DataRow newRow = modGlobal.gv_rs.Tables[sqlTableName23].NewRow();

                        newRow["MeasureCriteriaSet"] = Support.GetItemData(cboSet, cboSet.SelectedIndex);
                        newRow["MeasureStepID"] = li_StepID;
                        newRow["JoinOperator"] = ls_DefJoin;

                        //LDW Add new datatable row
                        modGlobal.gv_rs.Tables[sqlTableName23].Rows.Add(newRow);
                        modGlobal.gv_rs.AcceptChanges();
                        modGlobal.gv_rs.Dispose();

                        li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSet");
                    }
                    else
                    {
                        li_SetID = myRow23.Field<int>("MeasureCriteriaSetID");
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

        private void RefreshCat()
        {
            string ls_catID = null;

            try
            {
                modGlobal.gv_sql = "Select ms.Measure_CatID, ms.GotoStep ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureStep as ms left join tbl_MEASURE_CAT as mc  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID  WHERE  0 = 0 ";

                if (Convert.ToInt16(is_RowCount) == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureID = -1";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} AND ms.MeasureID = {1}", modGlobal.gv_sql, ii_MeasureID);
                }

                if (cboStep.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("{0} and ms.MeasureStep = {1}", modGlobal.gv_sql, Support.GetItemData(cboStep, cboStep.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and ms.MeasureStep = -1";
                }

                if (is_CritType == "Reg")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (mc.CAT_TYPE = 'CI' or mc.CAT_Type is null)";
                }
                else if (is_CritType == "Risk")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
                }
                //gv_g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName25 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName25].Rows.Count == 0)
                {
                    //if the gotostep is assigned, there won't be any category assigend
                    //gv_sql = "Select GotoStep from tbl_Setup_MeasureStep "
                    //If CInt(is_RowCount) = 0 Then
                    //    gv_sql = gv_sql & " WHERE MeasureID = -1"
                    //Else
                    //    gv_sql = gv_sql & " WHERE MeasureID = " & ii_MeasureID
                    //End If
                    //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                    //If gv_rs.RowCount = 0 Then
                    txtGoToStep.Text = "";
                    txtGoToStep.Enabled = true;
                    cboCat.Enabled = true;
                    cboCat.SelectedIndex = -1;

                    //Else
                    //            If IsNull(gv_rs!GoToStep) Then 'it means that this is a new step without any category or gotostep assignment
                    //                cboCat.Enabled = True
                    //                txtGoToStep.Enabled = True
                    //                txtGoToStep = ""
                    //                cboCat.ListIndex = -1
                    //                RefreshCatList
                    //            Else
                    //                txtGoToStep = gv_rs!GoToStep
                    //                txtGoToStep.Enabled = False
                    //                cboCat.Enabled = False
                    //                cboCat.ListIndex = -1
                    //
                    //            End If
                    //        End If
                }
                else
                {
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["measure_catid"]))
                    {
                        ls_catID = modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["measure_catid"].ToString();
                        cboCat.Enabled = false;
                        RefreshCatList((ls_catID));
                        txtGoToStep.Enabled = false;
                        txtGoToStep.Text = "";
                    }
                    else if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["GoToStep"]))
                    {
                        txtGoToStep.Text = modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["GoToStep"].ToString();
                        txtGoToStep.Enabled = false;
                        cboCat.Enabled = false;
                        cboCat.SelectedIndex = -1;
                        //it means that this is a new step without any category or gotostep assignment
                    }
                    else
                    {
                        cboCat.Enabled = true;
                        txtGoToStep.Enabled = true;
                        txtGoToStep.Text = "";
                        cboCat.SelectedIndex = -1;
                        RefreshCatList();
                    }

                    //txtGoToStep.Enabled = False
                    //txtGoToStep = ""
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
                                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
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

        private void AddCriteriaWithGroupLogic()
        {
            int li_cnt = lstGroupList.SelectedIndex;
            string CritTitle = null;
            int li_CriteriaSetID = InsertStepandSetRecords();

            try
            {
                modGlobal.gv_Action = "Add";

                modGlobal.gv_sql = "SELECT CriteriaTitle FROM tbl_Setup_MeasureFieldGroupLogic WHERE MeasureFieldGroupLogicID = " + Support.GetItemData(lstGroupList, li_cnt);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName28 = "tbl_Setup_MeasureFieldGroupLogic";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);

                CritTitle = modGlobal.gv_rs.Tables[sqlTableName28].Rows[0]["CriteriaTitle"].ToString();
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "Insert into tbl_Setup_MeasureCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(MeasureCriteriaSetID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, MeasureFieldGroupLogicID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_CriteriaSetID);
                modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CritTitle);
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstGroupList, li_cnt));
                modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, cboJoinOperator.Text);

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

        private void RefreshMeasureGroupLogic()
        {
            try
            {
                lstGroupList.Items.Clear();

                modGlobal.gv_sql = "SELECT CriteriaTitle, MeasureFieldGroupLogicID FROM tbl_Setup_MeasureFieldGroupLogic ORDER BY CriteriaTitle";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName29 = "tbl_Setup_MeasureFieldGroupLogic";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow29 in modGlobal.gv_rs.Tables[sqlTableName29].Rows)
                {
                    lstGroupList.Items.Add(new ListBoxItem(myRow29.Field<string>("CriteriaTitle"), myRow29.Field<int>("measurefieldgrouplogicid")).ToString());

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
