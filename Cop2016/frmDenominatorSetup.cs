using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmDenominatorSetup : Telerik.WinControls.UI.RadForm
    {
        public int openning = 0;


        public frmDenominatorSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void RefreshSummaryFields()
        {
            frmIndicatorReportSetup frmIndicatorReportSetupCopy = new frmIndicatorReportSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;
            DataSet rsSelected = new DataSet();
            List<Item> itemslstSummaryFields = new List<Item>();

            try
            {
                /*LDW if (frmIndicatorReportSetup.lstHeading.SelectedIndex == -1)
                {
                    goto DoneRefreshSummaryFields;
                }*/
                if (frmIndicatorReportSetupCopy.lstHeading.SelectedIndex != -1)

                    //
                    //retrieve the list of Indicators
                    //
                    modGlobal.gv_sql = "Select * from vuSummaryFieldNames order by fieldname";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "vuSummaryFieldNames";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                //
                //
                //
                modGlobal.gv_sql = "select * from vuDenominatorSummaryFields where SubGroupID = " +
                    Support.GetItemData(frmIndicatorReportSetupCopy.lstHeading, frmIndicatorReportSetupCopy.lstHeading.SelectedIndex);
                //LDW rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "vuDenominatorSummaryFields";
                rsSelected = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, rsSelected);

                //
                //fill the list box
                //
                lstSummaryFields.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemslstSummaryFields.Add(new Item(myRow1.Field<int>("SubGroupID"), myRow1.Field<string>("FieldName") + " (" + myRow1.Field<int>("SubGroupID") + ")"));

                    //lstSummaryFields.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName") +  " (" + myRow1.Field<int>("SubGroupID") + ")", myRow1.Field<int>("SubGroupID")));

                    if (rsSelected.Tables[sqlTableName2].Rows.Count > 0)
                    {
                        //LDW rsSelected.MoveFirst();
                        //LDW while (!rsSelected.EOF)
                        foreach (DataRow myRow2 in rsSelected.Tables[sqlTableName2].Rows)
                        {
                            if (Strings.Trim(myRow2.Field<string>("FieldName")) == Strings.Trim(myRow1.Field<string>("FieldName")))
                            {
                                //LDW lstSummaryFields.SetItemChecked(lstSummaryFields.NewIndex, true);
                                lstSummaryFields.SelectedIndex = lstSummaryFields.Items.Count - 1;
                                lstSummaryFields.SelectedItem.Enabled = true;
                            }
                            //LDW rsSelected.MoveNext();
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstSummaryFields.DataSource = itemslstSummaryFields;
                this.lstSummaryFields.DisplayMember = "Description";
                this.lstSummaryFields.ValueMember = "Id";

                rsSelected.Dispose();
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
            // 	DoneRefreshSummaryFields:
        }

        public void RefreshUtilizationFields()
        {
            frmIndicatorReportSetup frmIndicatorReportSetupCopy = new frmIndicatorReportSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;
            DataSet rsSelected = new DataSet();


            try
            {
                //
                //retrieve the list of Indicators
                //
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = 2 ORDER BY FieldName";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);
                //
                //
                //
                modGlobal.gv_sql = "select * from vuDenominatorUtilizationStat where SubGroupID = " +
                    Support.GetItemData(frmIndicatorReportSetupCopy.lstHeading, frmIndicatorReportSetupCopy.lstHeading.SelectedIndex) + " order by fieldName";
                //LDW rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "vuDenominatorUtilizationStat";
                rsSelected = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, rsSelected);
                //
                //fill the list box
                //
                lstUtilizationFields.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    lstUtilizationFields.Items.Add(string.Format("{0} ({1})", myRow3.Field<string>("FieldName"), myRow3.Field<int>("DDID")));

                    Support.SetItemData(lstUtilizationFields, lstUtilizationFields.Items.Count - 1, myRow3.Field<int>("DDID"));
                    if (rsSelected.Tables[sqlTableName4].Rows.Count > 0)
                    {
                        //LDW rsSelected.MoveFirst();
                        //LDW while (!rsSelected.EOF)
                        foreach (DataRow myRow4 in rsSelected.Tables[sqlTableName4].Rows)
                        {
                            if (Strings.Trim(myRow4.Field<string>("FieldName")) == Strings.Trim(myRow3.Field<string>("FieldName")))
                            {
                                //LDW lstUtilizationFields.SetItemChecked(lstUtilizationFields.NewIndex, true);
                                lstUtilizationFields.SelectedIndex = lstSummaryFields.Items.Count - 1;
                                lstUtilizationFields.SelectedItem.Enabled = true;
                            }
                            //LDW rsSelected.MoveNext();
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                rsSelected.Dispose();
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
            //	RefreshUtilizationFieldsDone
        }

        private void frmDenominatorSetup_Load(object sender, EventArgs e)
        {
            try
            {
                //
                //
                //
                openning = 1;
                //
                //
                //
                RefreshSummaryFields();
                //
                //
                //
                RefreshUtilizationFields();
                //
                //
                //
                //RefreshNumberCasesFields

                openning = 0;
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

        private void frmDenominatorSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmIndicatorReportSetup frmIndicatorReportSetupCopy = new frmIndicatorReportSetup();
            //
            //
            //
            try
            {
                frmIndicatorReportSetupCopy.refreshPage();
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

        private void lstSummaryFields_ItemCheckedChanged(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            frmIndicatorReportSetup frmIndicatorReportSetupCopy = new frmIndicatorReportSetup();
            int sid ;
            int fid = 0;

            try
            {
                if (openning == 0)
                {
                    fid = Support.GetItemData(lstSummaryFields, lstSummaryFields.SelectedIndex);
                    sid = Support.GetItemData(frmIndicatorReportSetupCopy.lstHeading, frmIndicatorReportSetupCopy.lstHeading.SelectedIndex);

                    //LDW if (lstSummaryFields.GetItemChecked(eventArgs.Index) == true)
                    if (Convert.ToBoolean(e.Item.CheckState) == true)
                    {
                        modGlobal.gv_sql = "INSERT into tbl_Setup_IndicatorReportDenominators (SubGroupID, tName, FieldID, OpChar)";
                        modGlobal.gv_sql = string.Format("{0} values ({1},'Summary',{2} , 1)", modGlobal.gv_sql, sid, fid);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    else
                    {
                        modGlobal.gv_sql = "delete from tbl_Setup_IndicatorReportDenominators ";
                        modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1} and  tName = 'Summary' and FieldID ={2}", modGlobal.gv_sql, sid, fid);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        private void lstUtilizationFields_ItemCheckedChanged(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            frmIndicatorReportSetup frmIndicatorReportSetupCopy = new frmIndicatorReportSetup();
            int sid ;
            int fid = 0;

            try
            {
                if (openning == 0)
                {
                    sid = Support.GetItemData(frmIndicatorReportSetupCopy.lstHeading, frmIndicatorReportSetupCopy.lstHeading.SelectedIndex);
                    fid = Support.GetItemData(lstUtilizationFields, lstUtilizationFields.SelectedIndex);
                    //LDW if (lstUtilizationFields.GetItemChecked(eventArgs.Index) == true)
                    if (Convert.ToBoolean(e.Item.CheckState) == true)
                    {
                        modGlobal.gv_sql = "INSERT into tbl_Setup_IndicatorReportDenominators (SubGroupID, tName, FieldID, OpChar)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (" + sid + ",'Utilization'," +
                            Support.GetItemData(lstUtilizationFields, lstUtilizationFields.SelectedIndex) + " , 1)";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    else
                    {
                        modGlobal.gv_sql = "delete from tbl_Setup_IndicatorReportDenominators ";
                        modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1} and  tName = 'Utilization' and FieldID ={2}", modGlobal.gv_sql, sid, fid);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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
