using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.Compatibility.VB6;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmRiskAdjustment : RadForm
    {
        private bool bPopulating1;
        private bool bPopulating2;
        private bool bPopulating3;



        public frmRiskAdjustment()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void refreshPatRecSelections()
        {
            var i = 0;


            try
            {
                bPopulating1 = true;

                if (cmbFactor.SelectedIndex >= 0)
                {
                    modGlobal.gv_sql = "select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 1 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                    {
                        for (i = 0; i <= lstPatRecFields.Items.Count - 1; i++)
                        {
                            if (myRow1.Field<int>("DDID") == Support.GetItemData(lstPatRecFields, i))
                            {
                                //LDW lstPatRecFields.SetItemChecked(i, true);
                                lstPatRecFields.SelectedIndex = i;
                                lstPatRecFields.CheckSelectedItems();
                            }
                        }
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else
                {
                    for (i = 0; i <= lstPatRecFields.Items.Count - 1; i++)
                    {
                        //LDW lstPatRecFields.SetItemChecked(i, false);
                        lstPatRecFields.SelectedIndex = i;
                    }
                }

                bPopulating1 = false;
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

        private void refreshPatRecSelections2()
        {
            var i = 0;

            try
            {
                bPopulating2 = true;

                if (cmbFactor.SelectedIndex >= 0)
                {
                    modGlobal.gv_sql = "select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 2 and coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                    {
                        for (i = 0; i <= lstPatRecFields2.Items.Count - 1; i++)
                        {
                            if (myRow2.Field<int>("DDID") == Support.GetItemData(lstPatRecFields2, i))
                            {
                                //LDW lstPatRecFields2.SetItemChecked(i, true);
                                lstPatRecFields2.SelectedIndex = i;
                                lstPatRecFields2.CheckSelectedItems();
                            }
                        }
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else
                {
                    for (i = 0; i <= lstPatRecFields2.Items.Count - 1; i++)
                    {
                        //LDW lstPatRecFields2.SetItemChecked(i, false);
                        lstPatRecFields2.SelectedIndex = i;
                    }
                }

                bPopulating2 = false;
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

        private void refreshPatRecSelections3()
        {
            var i = 0;

            try
            {
                bPopulating3 = true;

                if (cmbFactor.SelectedIndex >= 0)
                {
                    modGlobal.gv_sql = "select factorid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName3 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                    {
                        for (i = 0; i <= lstPatRecFields3.Items.Count - 1; i++)
                        {
                            if (myRow3.Field<int>("FactorID") == Support.GetItemData(lstPatRecFields3, i))
                            {
                                //LDW lstPatRecFields3.SetItemChecked(i, true);
                                lstPatRecFields3.SelectedIndex = i;
                                lstPatRecFields3.CheckSelectedItems();
                            }
                        }
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                else
                {
                    for (i = 0; i <= lstPatRecFields3.Items.Count - 1; i++)
                    {
                        //LDW lstPatRecFields3.SetItemChecked(i, false);
                        lstPatRecFields3.SelectedIndex = i;
                    }
                }

                bPopulating3 = false;
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

        private void refreshAllTriggerFields()
        {
            try
            {
                refreshTriggerFields();
                refreshTriggerFields2();
                refreshTriggerFields3();
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

        private void refreshTriggerFields()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbFactor.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "select triggerBy from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                }
                else
                {
                    modGlobal.gv_sql = "select triggerBy from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + -1;
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName4].Rows.Count > 0)
                {
                    cmbTrigger.Text = (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["TriggerBy"])
                        ? " " : modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["TriggerBy"].ToString());
                }
                else
                {
                    cmbTrigger.Text = " ";
                }
                Cursor.Current = Cursors.Arrow;
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

        private void refreshTriggerFields2()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbFactor.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "select triggerBy2 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                }
                else
                {
                    modGlobal.gv_sql = "select triggerBy2 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + -1;
                }

                //LDWmodGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName5].Rows.Count > 0)
                {
                    cmbTrigger2.Text = (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["TriggerBy2"])
                        ? " " : modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["TriggerBy2"].ToString());
                }
                else
                {
                    cmbTrigger2.Text = " ";
                }
                Cursor.Current = Cursors.Arrow;
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

        private void refreshTriggerFields3()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbFactor.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "select factorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = "
                        + Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex);
                }
                else
                {
                    modGlobal.gv_sql = "select factorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients where coefID = " + -1;
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName6].Rows.Count > 0)
                {
                    cmbTrigger3.Text = (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["factorOperator"])
                        ? " " : modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["factorOperator"].ToString());
                }
                else
                {
                    cmbTrigger3.Text = " ";
                }
                Cursor.Current = Cursors.Arrow;
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

        private void refreshAllPatRecFields()
        {
            try
            {
                refreshPatRecFields();
                refreshPatRecFields2();
                refreshPatRecFields3();
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

        private void refreshPatRecFields()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbFactor.SelectedIndex >= 0)
                {
                    if (optFields0.IsChecked == true)
                    {
                        modGlobal.gv_sql = string.Format("select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 and ddid in " +
                            "(select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 1 and coefID = {0}) order by fieldName",
                            Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    }
                    else
                    {
                        modGlobal.gv_sql = "select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 order by fieldName";
                    }

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_setup_datadef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    lstPatRecFields.Items.Clear();

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                    {
                        lstPatRecFields.Items.Add(new ListBoxItem(myRow7.Field<string>("FieldName"), myRow7.Field<int>("DDID")));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }

                refreshPatRecSelections();

                Cursor.Current = Cursors.Arrow;
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

        private void refreshPatRecFields2()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbFactor.SelectedIndex >= 0)
                {
                    if (optFieldsTwo0.IsChecked == true)
                    {
                        modGlobal.gv_sql = string.Format("select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 and ddid in " +
                            "(select ddid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 2 and coefID = {0}) order by fieldName", Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    }
                    else
                    {
                        modGlobal.gv_sql = "select ddid, fieldName from tbl_setup_datadef where baseTableID = 1 order by fieldName";
                    }

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName8 = "tbl_setup_datadef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                    lstPatRecFields2.Items.Clear();

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                    {
                        lstPatRecFields2.Items.Add(new ListBoxItem(myRow8.Field<string>("FieldName"), myRow8.Field<int>("DDID")));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }

                refreshPatRecSelections2();

                Cursor.Current = Cursors.Arrow;
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

        private void refreshPatRecFields3()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbFactor.SelectedIndex >= 0)
                {
                    if (optFieldsThree0.IsChecked == true)
                    {
                        modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Where measureID = (select jcahoID from tbl_Setup_Indicator ";
                        modGlobal.gv_sql = string.Format("{0}             where indicatorID = {1})", modGlobal.gv_sql, Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and Quarter = '{1}'", modGlobal.gv_sql, Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and coefID in (select factorid from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks where coefID = {1})",
                            modGlobal.gv_sql, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by Description, FactorID";
                    }
                    else
                    {
                        modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Where measureID = (select jcahoID from tbl_Setup_Indicator ";
                        modGlobal.gv_sql = string.Format("{0}             where indicatorID = {1})", modGlobal.gv_sql, Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} and Quarter = '{1}'", modGlobal.gv_sql, Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex));
                        modGlobal.gv_sql = modGlobal.gv_sql + " order by Description, FactorID";
                    }

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName9 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);
                    lstPatRecFields3.Items.Clear();

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                    {
                        lstPatRecFields3.Items.Add(new ListBoxItem("(" + myRow9.Field<string>("Description") + ") / " + myRow9.Field<int>("FactorID") +
                            ": " + myRow9.Field<string>("coefficient"), myRow9.Field<int>("coefID")));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }

                refreshPatRecSelections3();

                Cursor.Current = Cursors.Arrow;
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

        private void refreshIndicators()
        {
            try
            {
                //
                //retrieve the list of Indicators
                //
                modGlobal.gv_sql = "select * from tbl_setup_indicator Where RiskAdjusted > 0 order by Description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                cmbIndicators.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                {
                    cmbIndicators.Items.Add(new ListBoxItem(myRow10.Field<string>("Description"), myRow10.Field<int>("IndicatorID")).ToString());
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

        private void cmbFactor_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                refreshAllPatRecFields();
                //
                //
                //
                refreshAllTriggerFields();
                //
                //
                //
                refreshAllTriggerList();
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
            try
            {
                if (fraFactors.Enabled == true & lstPeriods.SelectedIndex > -1)
                {
                    RefreshRADetails();
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

        private void cmbTrigger_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            //
            //
            //
            try
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    SQL = string.Format("update tbl_Setup_IndicatorRiskAdjustmentCoefficients set triggerBy = '{0}' where coefID = {1}", cmbTrigger.Text, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    ps.Execute();
                    ps.Close(); */
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
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

        private void cmbTrigger2_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            //
            //
            //
            try
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    SQL = string.Format("update tbl_Setup_IndicatorRiskAdjustmentCoefficients set triggerBy2 = '{0}' where coefID = {1}", cmbTrigger2.Text, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    ps.Execute();
                    ps.Close(); */
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
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

        private void cmbTrigger3_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            //
            //
            //
            try
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    SQL = string.Format("update tbl_Setup_IndicatorRiskAdjustmentCoefficients set factorOperator = '{0}' where coefID = {1}",
                        cmbTrigger3.Text, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    ps.Execute();
                    ps.Close(); */
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
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

        private void refreshAllTriggerList()
        {
            try
            {
                refreshTriggerList();
                refreshTriggerList2();
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

        private void refreshTriggerList()
        {
            //
            //
            //sh changed order by trigger id for in between group logic
            try
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    modGlobal.gv_sql = string.Format("select * from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers Where tab = 1 and coefID = {0} order by triggerID",
                        Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName11 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                    //
                    //
                    //
                    lstTriggers.Items.Clear();
                    if (modGlobal.gv_rs.Tables[sqlTableName11].Rows.Count > 0)
                    {
                        //LDW modGlobal.gv_rs.MoveFirst();
                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                        {
                            lstTriggers.Items.Add(new ListBoxItem(myRow11.Field<string>("TriggerValue"), myRow11.Field<int>("triggerID")).ToString());
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                    }
                    Cursor.Current = Cursors.Arrow;
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

        private void refreshTriggerList2()
        {
            try
            {
                //sh changed order by trigger id for in between group logic
                if (cmbFactor.SelectedIndex >= 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    modGlobal.gv_sql = string.Format("select * from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers Where tab = 2 and coefID = {0} order by triggerID",
                        Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName12 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);
                    //
                    //
                    //
                    lstTriggers2.Items.Clear();
                    if (modGlobal.gv_rs.Tables[sqlTableName12].Rows.Count > 0)
                    {
                        //LDW modGlobal.gv_rs.MoveFirst();
                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                        {
                            lstTriggers2.Items.Add(new ListBoxItem(myRow12.Field<string>("TriggerValue"), myRow12.Field<int>("triggerID")).ToString());
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                    }
                    Cursor.Current = Cursors.Arrow;
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
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            string resp = null;
            //
            //
            //
            try
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    resp = RadInputBox.Show("Enter The New Trigger Value", "Pat Rec Value For Risk Adjustment");
                    if (!string.IsNullOrEmpty(resp))
                    {
                        SQL = string.Format("insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID,triggerValue,tab) values ({0}, '{1}',1)",
                            Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), resp);
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        ps.Execute();
                        ps.Close(); */
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        refreshTriggerList();
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

        private void cmdAdd2_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            string resp = null;
            //
            //
            //
            try
            {
                if (cmbFactor.SelectedIndex >= 0)
                {
                    resp = RadInputBox.Show("Enter The New Trigger Value", "Pat Rec Value For Risk Adjustment");
                    if (!string.IsNullOrEmpty(resp))
                    {
                        SQL = string.Format("insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID,triggerValue,tab) values ({0}, '{1}',2)",
                            Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), resp);
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        ps.Execute();
                        ps.Close(); */
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        refreshTriggerList2();
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadMessageBox.Show("Are you sure you want to delete this factor?", "Delete?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    DeleteFactor(Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));

                    RefreshRADetails();
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

        private void DeleteFactor(int coefID)
        {
            try
            {
                modGlobal.gv_sql = "DELETE from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                modGlobal.gv_sql = string.Format("{0} where coefID = {1}", modGlobal.gv_sql, coefID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = "DELETE from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                modGlobal.gv_sql = string.Format("{0} where coefID = {1}", modGlobal.gv_sql, coefID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "DELETE from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                modGlobal.gv_sql = string.Format("{0} where coefID = {1}", modGlobal.gv_sql, coefID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "delete from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                modGlobal.gv_sql = string.Format("{0} where coefid = {1}", modGlobal.gv_sql, coefID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        private void cmdDeletePeriod_Click(object sender, EventArgs e)
        {
            var rs_Temp = new DataSet();


            try
            {
                if (RadMessageBox.Show("Are you sure you want to delete data for the entire period?", "Delete Period?", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    modGlobal.gv_sql = "Select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                    modGlobal.gv_sql = string.Format("{0} where Quarter = '{1}'", modGlobal.gv_sql, Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex));

                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName13 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, rs_Temp);

                    //LDW while (!rs_Temp.EOF)
                    foreach (DataRow myRow13 in modGlobal.gv_rs.Tables[sqlTableName13].Rows)
                    {
                        DeleteFactor((myRow13.Field<int>("coefID")));
                        //LDW  rs_Temp.MoveNext();
                    }

                    rs_Temp.Dispose();
                    rs_Temp = null;

                    refreshIndicators();
                    RefreshPeriods();
                    Cursor.Current = Cursors.Default;
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            string resp;
            //
            //
            //
            try
            {
                if (lstTriggers.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select triggerValue from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                    modGlobal.gv_sql = string.Format("{0} where tab = 1 and coefID = {1}", modGlobal.gv_sql, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and triggerID = {1}", modGlobal.gv_sql, Support.GetItemData(lstTriggers, lstTriggers.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName14 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow14 in modGlobal.gv_rs.Tables[sqlTableName14].Rows)
                    {
                        resp = RadInputBox.Show("Edit The Trigger Value", "Pat Rec Value For Risk Adjustment", myRow14.Field<string>("TriggerValue"));
                        if (!string.IsNullOrEmpty(resp))
                        {
                            SQL = string.Format("update tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers set triggerValue = {0} where coefID = {1} and tab = 1 and triggerID = {2}",
                                resp, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), Support.GetItemData(lstTriggers, lstTriggers.SelectedIndex));
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close(); */
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            refreshTriggerList();
                        }
                    }
                }
                else
                {
                    RadMessageBox.Show("Please choose a trigger to edit", "", MessageBoxButtons.OK, RadMessageIcon.Info);
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

        private void cmdEdit2_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            string resp;
            //
            //
            //
            try
            {
                if (lstTriggers2.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Select triggerValue from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                    modGlobal.gv_sql = string.Format("{0} where tab = 2 and coefID = {1}", modGlobal.gv_sql, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and triggerID = {1}", modGlobal.gv_sql, Support.GetItemData(lstTriggers2, lstTriggers2.SelectedIndex));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName15 = "tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow15 in modGlobal.gv_rs.Tables[sqlTableName15].Rows)
                    {
                        resp = RadInputBox.Show("Edit The Trigger Value", "Pat Rec Value For Risk Adjustment", myRow15.Field<string>("TriggerValue"));
                        if (!string.IsNullOrEmpty(resp))
                        {
                            SQL = string.Format("update tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers set triggerValue = {0} where coefID = {1} and tab = 2 and triggerID = {2}",
                                resp, Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), Support.GetItemData(lstTriggers2, lstTriggers2.SelectedIndex));
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close(); */
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            refreshTriggerList2();
                        }
                    }
                }
                else
                {
                    RadMessageBox.Show("Please choose a trigger to edit", "", MessageBoxButtons.OK, RadMessageIcon.Info);
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

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            //
            //
            //
            try
            {
                if (lstTriggers.SelectedIndex > -1)
                {
                    if (RadMessageBox.Show("Delete " + lstTriggers.Text + " from trigger list?", "Confirm Trigger Removal", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                    {
                        SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers where tab = 1 and triggerID = " + Support.GetItemData(lstTriggers, lstTriggers.SelectedIndex);
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        ps.Execute();
                        ps.Close(); */
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        //
                        //
                        //
                        refreshTriggerList();
                    }
                }
                else
                {
                    RadMessageBox.Show("Please choose a trigger to delete", "", MessageBoxButtons.OK, RadMessageIcon.Info);
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

        private void cmdRemove2_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            //
            //
            //
            try
            {
                if (lstTriggers2.SelectedIndex > -1)
                {
                    if (RadMessageBox.Show("Delete " + lstTriggers2.Text + " from trigger list?", "Confirm Trigger Removal", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                    {
                        SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers where tab = 2 and triggerID = " + Support.GetItemData(lstTriggers2, lstTriggers2.SelectedIndex);
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                        ps.Execute();
                        ps.Close(); */
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        //
                        //
                        //
                        refreshTriggerList2();
                    }
                }
                else
                {
                    RadMessageBox.Show("Please choose a trigger to delete", "", MessageBoxButtons.OK, RadMessageIcon.Info);
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

        private void frmRiskAdjustment_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            try
            {
                refreshIndicators();
                //
                RefreshPeriods();
                //
                refreshAllPatRecFields();
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

        private void lstPatRecFields_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;
            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (!bPopulating1)
                {
                    if (cmbFactor.SelectedIndex >= 0)
                    {
                        if (lstPatRecFields.SelectedIndex == -1)
                        {
                            //
                            // just skip it
                            //
                        }
                        //LDW else if (lstPatRecFields.GetItemChecked(lstPatRecFields.SelectedIndex) == true)
                        else if ((lstPatRecFields.CheckedItems.IndexOf(lstPatRecFields.SelectedItem) == lstPatRecFields.SelectedIndex) == true)
                        {
                            SQL = string.Format("insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID,DDID,tab) values ({0}, {1},1)",
                                Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), Support.GetItemData(lstPatRecFields, lstPatRecFields.SelectedIndex));
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close(); */
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        }
                        else
                        {
                            SQL = string.Format("delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 1 and coefID = {0} and DDID = {1}",
                                Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), Support.GetItemData(lstPatRecFields, lstPatRecFields.SelectedIndex));
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close(); */
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        }
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

        private void lstPatRecFields2_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;

            try
            {
                if (!bPopulating2)
                {
                    if (cmbFactor.SelectedIndex >= 0)
                    {
                        if (lstPatRecFields2.SelectedIndex == -1)
                        {
                            //
                            // just skip it
                            //
                        }
                        //LDW else if (lstPatRecFields2.GetItemChecked(lstPatRecFields2.SelectedIndex) == true)
                        else if ((lstPatRecFields2.CheckedItems.IndexOf(lstPatRecFields2.SelectedItem) == lstPatRecFields2.SelectedIndex) == true)
                        {
                            SQL = string.Format("insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID,DDID,tab) values ({0}, {1},2)",
                                Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), Support.GetItemData(lstPatRecFields2, lstPatRecFields2.SelectedIndex));
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close(); */
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        }
                        else
                        {
                            SQL = string.Format("delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks where tab = 2 and coefID = {0} and DDID = {1}",
                                Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), Support.GetItemData(lstPatRecFields2, lstPatRecFields2.SelectedIndex));
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close(); */
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        }
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

        private void lstPatRecFields3_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            string SQL = null;

            try
            {
                if (!bPopulating3)
                {
                    if (cmbFactor.SelectedIndex >= 0)
                    {
                        if (lstPatRecFields3.SelectedIndex == -1)
                        {
                            //
                            // just skip it
                            //
                        }
                        //LDW else if (lstPatRecFields3.GetItemChecked(lstPatRecFields3.SelectedIndex) == true)
                        else if ((lstPatRecFields3.CheckedItems.IndexOf(lstPatRecFields3.SelectedItem) == lstPatRecFields3.SelectedIndex) == true)
                        {
                            //   get the factor text description
                            modGlobal.gv_sql = "Select factorid from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                            modGlobal.gv_sql = string.Format("{0} where coefid = {1}", modGlobal.gv_sql, Support.GetItemData(lstPatRecFields3, lstPatRecFields3.SelectedIndex));

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName17 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                            //LDW if (!modGlobal.gv_rs.EOF)
                            foreach (DataRow myRow17 in modGlobal.gv_rs.Tables[sqlTableName17].Rows)
                            {
                                SQL = string.Format("insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks (coefID,factorTxt,factorID) values ({0}, '{1}', {2})",
                                    Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), myRow17.Field<int>("FactorID"), Support.GetItemData(lstPatRecFields3, lstPatRecFields3.SelectedIndex));
                                /* LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                                ps.Execute();
                                ps.Close(); */
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            }
                        }
                        else
                        {
                            SQL = string.Format("delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks where coefID = {0} and factorid = {1}",
                                Support.GetItemData(cmbFactor, cmbFactor.SelectedIndex), Support.GetItemData(lstPatRecFields3, lstPatRecFields3.SelectedIndex));
                            /* LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close(); */
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        }
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

        private void lstPeriods_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cmbIndicators.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select an indicator");
                    return;
                }

                RefreshRADetails();
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

        private void optFields0_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(optFields0.IsChecked))
                {
                    //LDW int Index = optFields0.GetIndex(sender);
                    //
                    //
                    //
                    refreshPatRecFields();
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

        //LDW Added new control to replace the control array from vb6
        private void optFields1_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(optFields1.IsChecked))
                {
                    //LDW int Index = optFields1.GetIndex(sender);
                    //
                    //
                    //
                    refreshPatRecFields();
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

        private void optFieldsTwo0_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(optFieldsTwo0.IsChecked))
                {
                    //LDW int Index = optFieldsTwo.GetIndex(sender);

                    refreshPatRecFields2();
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

        //LDW Added new control to replace the control array from vb6
        private void optFieldsTwo1_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(optFieldsTwo1.IsChecked))
                {
                    //LDW int Index = optFieldsTwo.GetIndex(sender);

                    refreshPatRecFields2();
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

        private void optFieldsThree0_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(optFieldsThree0.IsChecked))
                {
                    //LDW int Index = optFieldsThree.GetIndex(sender);

                    refreshPatRecFields3();
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

        //LDW Added new control to replace the control array from vb6
        private void optFieldsThree1_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(optFieldsThree1.IsChecked))
                {
                    //LDW int Index = optFieldsThree.GetIndex(sender);

                    refreshPatRecFields3();
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

        public void RefreshPeriods()
        {
            try
            {
                //retrieve the list of periods
                modGlobal.gv_sql = "Select Quarter from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                modGlobal.gv_sql = modGlobal.gv_sql + " group by quarter";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by quarter ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName18 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                lstPeriods.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow18 in modGlobal.gv_rs.Tables[sqlTableName18].Rows)
                {
                    lstPeriods.Items.Add(new ListBoxItem(Strings.Mid(myRow18.Field<string>("Quarter"), 5, 2) + " - " + Strings.Mid(myRow18.Field<string>("Quarter"), 1, 4),
                        myRow18.Field<int>("Quarter")).ToString());
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

        public void RefreshRADetails()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where measureID = (select jcahoID from tbl_Setup_Indicator ";
                modGlobal.gv_sql = string.Format("{0}             where indicatorID = {1})", modGlobal.gv_sql, Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and Quarter = '{1}'", modGlobal.gv_sql, Support.GetItemData(lstPeriods, lstPeriods.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description, FactorID";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName19 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                cmbFactor.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow19 in modGlobal.gv_rs.Tables[sqlTableName19].Rows)
                {
                    cmbFactor.Items.Add(new ListBoxItem("(" + myRow19.Field<string>("Description") + ") / " + myRow19.Field<int>("FactorID") + ": " + myRow19.Field<string>("coefficient"), myRow19.Field<int>("coefID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                Cursor.Current = Cursors.Arrow;

                refreshAllTriggerFields();
                lstTriggers.Items.Clear();
                lstTriggers2.Items.Clear();
                lstPatRecFields.Items.Clear();
                lstPatRecFields2.Items.Clear();
                lstPatRecFields3.Items.Clear();
                refreshPatRecSelections();
                refreshPatRecSelections2();
                refreshPatRecSelections3();
                refreshAllPatRecFields();

                fraFactors.Enabled = true;
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
