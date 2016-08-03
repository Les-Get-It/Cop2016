using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using Telerik.WinControls.UI;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmIndicatorReportSetup : RadForm
    {
        private bool refreshingSection;
        public DataSet rdcDenominatorFields = new DataSet();
        public string rdcDenominatorFieldsTable = null;

        public frmIndicatorReportSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void moveHeading(int dir_Renamed)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;


            try
            {

                /*LDW  SQL = "{ ? = call swapIncludePositions(?,?,?) }";
                ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                ps(0).Direction = RDO.DirectionConstants.rdParamReturnValue;
                ps(1).Direction = RDO.DirectionConstants.rdParamInput;
                ps(2).Direction = RDO.DirectionConstants.rdParamInput;
                ps(3).Direction = RDO.DirectionConstants.rdParamInput;
                // set up the parameters to be passed
                ps.rdoParameters(1) = Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex);
                ps.rdoParameters(2) = Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
                ps.rdoParameters(3) = dir_Renamed;
                ps.Execute();
                ps.Close(); */
                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = "swapIncludePositions";
                var inParam1 = new SqlParameter("@indID", Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex));
                inParam1.Direction = ParameterDirection.Input;
                inParam1.DbType = DbType.Int32;
                ps.Parameters.Add(inParam1);
                var inParam2 = new SqlParameter("@grid", Support.GetItemData(lstHeading, lstHeading.SelectedIndex));
                inParam2.Direction = ParameterDirection.Input;
                inParam2.DbType = DbType.Int32;
                ps.Parameters.Add(inParam2);
                var inParam3 = new SqlParameter("@RightFactor", dir_Renamed);
                inParam3.Direction = ParameterDirection.Input;
                inParam3.DbType = DbType.String;
                ps.Parameters.Add(inParam3);
                SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam1.Direction = ParameterDirection.ReturnValue;
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                }
                catch (Exception exx)
                {
                    RadMessageBox.Show("Error while opening connection: " + exx.Message);
                }
                finally
                {
                    ps.Dispose();
                }
                RefreshSections();
                RefreshDenominatorGrid();
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

        private void updatetReportIncludes()
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;



            try
            {
                if (lstHeading.SelectedIndex > -1)
                {
                    //
                    // delete them first, keeps out dups...
                    //
                    SQL = "delete tbl_Setup_IndicatorReportIncludes where indicatorID = " + Support.GetItemData(cmbIndicators,
                        cmbIndicators.SelectedIndex) + " and subgroupID = " + Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
                    /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    ps.Execute();
                    ps.Close();*/
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                    //
                    // add it back if necessary....
                    //
                    //LDW if (lstHeading.GetItemChecked(lstHeading.SelectedIndex) == true)
                    if (Convert.ToBoolean(lstHeading.SelectedItem.CheckState) == true)
                    {
                        SQL = "insert into tbl_Setup_IndicatorReportIncludes (indicatorID, subgroupID) select " + Support.GetItemData(
                            cmbIndicators, cmbIndicators.SelectedIndex) + ", " + Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        ps.Execute();
                        ps.Close();*/
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                        SQL = "update tbl_Setup_IndicatorReportIncludes set sortorder = includeID where sortorder is null";
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        ps.Execute();
                        ps.Close(); */
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
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

        private void RefreshNumeratorFields()
        {
            RadDropDownList cmbNumerator = new RadDropDownList();
            // retrieve the list of Indicators


            try
            {
                modGlobal.gv_sql = string.Format("Select * from vuNumeratorFields where IndicatorID = {0} order by sortorder",
                    Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by title ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "vuNumeratorFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                cmbNumerator.Dispose();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    cmbNumerator.Items.Add(new ListBoxItem(myRow1.Field<string>("Title") + "(" +
                        myRow1.Field<string>("SubGroupID") + ")", myRow1.Field<int>("SubGroupID")).ToString());
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

        private void cmbIndicators_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            // when selected, find the new headings...
            RefreshSections();
        }

        private void cmdReportUpdateDenominatorField_Click(object sender, EventArgs e)
        {
            frmDenominatorSetup frmDenominatorSetupCopy = new frmDenominatorSetup();
            frmDenominatorSetupCopy.Show();
        }

        private void Command1_Click(object sender, EventArgs e)
        {
            try
            {
                moveHeading(1);
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

        private void Command2_Click(object sender, EventArgs e)
        {
            try
            {
                moveHeading(-1);
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

        private void dbgDenominatorFields_DoubleClick(object sender, EventArgs e)
        {
            //LDW object ps = null;
            string SQL = null;

            try
            {

                if (rdcDenominatorFields.Tables[rdcDenominatorFieldsTable].Rows.Count > 0)
                {
                    DialogResult resp = RadMessageBox.Show("Change Summary Operation?", "Operation Update", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                    if (resp == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(rdcDenominatorFields.Tables[rdcDenominatorFieldsTable].Rows[0]["OpChar"]) == 1)
                        {
                            SQL = "update tbl_Setup_IndicatorReportDenominators set opchar = -1 where denomfieldID = " +
                                rdcDenominatorFields.Tables[rdcDenominatorFieldsTable].Rows[0]["DenomFieldID"];
                        }
                        else
                        {
                            SQL = "update tbl_Setup_IndicatorReportDenominators set opchar = 1 where denomfieldID = " +
                                rdcDenominatorFields.Tables[rdcDenominatorFieldsTable].Rows[0]["DenomFieldID"];
                        }
                        //
                        //  run the update...
                        //
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        ps.Execute();
                        ps.Close();*/
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        //
                        //  now update the display...
                        //
                        RefreshDenominatorGrid();
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

        private void frmIndicatorReportSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                RefreshIndicator();
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

        public void refreshPage()
        {
            try
            {
                RefreshDenominatorGrid();
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

        public void RefreshDenominatorGrid()
        {
            int SubGroupID;

            try
            {

                if (lstHeading.SelectedIndex > -1)
                {
                    SubGroupID = Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
                }
                else
                {
                    SubGroupID = -1;
                }

                modGlobal.gv_sql = "select * from vuDenominatorUtilizationStat where SubGroupID =  " + SubGroupID +
                    " union select * from vuDenominatorSummaryFields where SubGroupID =  " + SubGroupID;

                //LDW rdcDenominatorFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcDenominatorFieldsTable = "vuDenominatorUtilizationStat";
                rdcDenominatorFields = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcDenominatorFieldsTable, rdcDenominatorFields);
                rdcDenominatorFields.AcceptChanges();

                dbgDenominatorFields.Refresh();
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

        public void RefreshSections()
        {
            int i = 0;

            try
            {
                //
                //
                //
                refreshingSection = true;
                //
                // retrieve the list of Grouped Fields
                //
                modGlobal.gv_sql = "Select * from vuNumeratorFields where IndicatorID = " + Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + " order by sortOrder";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "vuNumeratorFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);
                //
                // fill the list box
                //
                lstHeading.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    lstHeading.Items.Add(new ListBoxItem(myRow3.Field<string>("Title") + "  " +
                        myRow3.Field<string>("SortOrder"), myRow3.Field<int>("SubGroupID")));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //
                // check the ones that are selected...
                //
                modGlobal.gv_sql = "Select * from tbl_Setup_IndicatorReportIncludes where IndicatorID = " +
                    Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_IndicatorReportIncludes";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                //
                // fill the list box
                //
                //LDW if (!modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count; itr++)
                {
                    DataRow myRow = modGlobal.gv_rs.Tables[sqlTableName4].Rows[itr];
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName4].Rows.IndexOf(myRow);
                    int rowLast = modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count - 1;

                    if (rowIndex != rowLast)
                    {
                        for (i = 0; i <= lstHeading.Items.Count - 1; i++)
                        {
                            //LDW modGlobal.gv_rs.MoveFirst();
                            //LDW while (!modGlobal.gv_rs.EOF)
                            foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                            {
                                if (Support.GetItemData(lstHeading, i) == myRow4.Field<int>("SubGroupID"))
                                {
                                    //LDW lstHeading.SetItemChecked(i, true);
                                    lstHeading.SelectedIndex = i;
                                    lstHeading.CheckSelectedItems();
                                }
                                //LDW modGlobal.gv_rs.MoveNext();
                            }
                        }
                    }
                }
                //
                //
                //

                lstHeading_SelectedIndexChanged(lstHeading, new EventArgs());

                refreshingSection = false;
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

        public void RefreshIndicator()
        {
            try
            {
                //retrieve the list of Indicators
                modGlobal.gv_sql = "Select * from tbl_setup_Indicator";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);


                cmbIndicators.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    cmbIndicators.Items.Add(new ListBoxItem(myRow5.Field<string>("Description"), myRow5.Field<int>("IndicatorID")).ToString());
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

        private void lstHeading_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshDenominatorGrid();

                if (lstHeading.SelectedIndex == -1)
                {
                    cmdReportUpdateDenominatorField.Enabled = false;
                    dbgDenominatorFields.Enabled = false;
                }
                else
                {
                    cmdReportUpdateDenominatorField.Enabled = true;
                    dbgDenominatorFields.Enabled = true;
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

        private void lstHeading_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (refreshingSection == false)
                {
                    updatetReportIncludes();
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


        /*LDW not used
        //Private Sub cmdAddReportSection_Click()
        //    '
        //    '  prompt for new heading
        //    '
        //    newHeading = InputBox("Enter Name Of Report Section")
        //    If newHeading <> "" Then
        //        '
        //        ' make sure that this hasn't been used for this indicator
        //        '
        //        gv_sql = "Select * from tbl_Setup_IndicatorReportNumerators where IndicatorID = " & cmbIndicators.ItemData(cmbIndicators.ListIndex) & " and HeadingText = '" & newHeading & "'"
        //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //        '
        //        ' if new, add it to the list
        //        '
        //        If gv_rs.RowCount = 0 Then
        //            gv_sql = "INSERT into tbl_Setup_IndicatorReportNumerators (IndicatorID, HeadingText)"
        //            gv_sql = gv_sql & " values (" & cmbIndicators.ItemData(cmbIndicators.ListIndex) & ",'" & newHeading & "')"
        //            gv_cn.Execute gv_sql
        //            RefreshSections
        //        Else
        //            MsgBox "Heading Already Exists, Please Choose Another.", vbCritical, "Detail Error"
        //        End If
        //    End If
        //
        //End Sub
        //
        //
        //Private Sub cmdRemoveReportSection_Click()
        //    '
        //    '
        //    '
        //    If MsgBox("Delete " & Trim(lstHeading.Text) & " from Report?", vbOKCancel, "Verify Removal") = vbOK Then
        //            ' delete the numerator fields...
        //            gv_sql = "delete from tbl_Setup_IndicatorReportNumerators where NumeratorID = " & lstHeading.ItemData(lstHeading.ListIndex)
        //            gv_cn.Execute gv_sql
        //            RefreshSections
        //    End If
        //End Sub
         */
    }
}
