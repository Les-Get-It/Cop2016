using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmPatientFieldsExportFormat : Telerik.WinControls.UI.RadForm
    {
        public DataSet rdcTemp = new DataSet();
        public string rdcTempTable = null;
        public DataSet rdcFieldList = new DataSet();
        public string rdcFieldListTable = null;


        public frmPatientFieldsExportFormat()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdLinkToMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMeasureList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "Insert into tbl_setup_CMSfieldmeasures (ddid, indicatorid, MeasureCode) ";
                    modGlobal.gv_sql = string.Format("{0} values ({1}, ", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(lstMeasureList, lstMeasureList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, lstMeasureList.Text);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshMeasureList();
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

        private void cmdMeasureFieldDetails_Click(object sender, EventArgs e)
        {
            frmPatientFieldsExportLinks frmPatientFieldsExportLinksCopy = new frmPatientFieldsExportLinks();

            try
            {

                if (lstFieldList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "update tbl_setup_DataDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CMSFieldCode =  ";
                    if (string.IsNullOrEmpty(txtCMSFieldCode.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, txtCMSFieldCode.Text);
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JCFieldCode =  ";
                    if (string.IsNullOrEmpty(txtJCFieldCode.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, txtJCFieldCode.Text);
                    }
                    modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
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

            frmPatientFieldsExportLinksCopy.ShowDialog();
        }

        private void cmdRemoveFromMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelectedMeasures.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "delete tbl_setup_CMSfieldmeasures ";
                    modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} and MeasureCode = '{1}'", modGlobal.gv_sql, lstSelectedMeasures.Text);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    RefreshMeasureList();
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFieldList.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "update tbl_setup_DataDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CMSFieldCode =  ";
                    if (string.IsNullOrEmpty(txtCMSFieldCode.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, txtCMSFieldCode.Text);
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + ", ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JCFieldCode =  ";
                    if (string.IsNullOrEmpty(txtJCFieldCode.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, txtJCFieldCode.Text);
                    }
                    modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
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

        private void frmPatientFieldsExportFormat_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                txtJCFieldCode.Enabled = false;
                txtCMSFieldCode.Enabled = false;
                lstMeasureList.Enabled = false;
                lstSelectedMeasures.Enabled = false;
                cmdLinkToMeasure.Enabled = false;
                cmdRemoveFromMeasure.Enabled = false;

                //retrieve the list of table fields
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select basetableid from tbl_setup_tableDef where BaseTable = 'PATIENT' )";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW rdcFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcFieldListTable = "tbl_setup_DataDef";
                rdcFieldList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcFieldListTable, rdcFieldList);
                rdcFieldList.AcceptChanges();

                lstFieldList.Items.Clear();
                //LDW while (!rdcFieldList.Resultset.EOF)
                foreach (DataRow myRow1 in rdcFieldList.Tables[rdcFieldListTable].Rows)
                {
                    lstFieldList.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"), myRow1.Field<int>("DDID")).ToString());
                    //LDW rdcFieldList.Resultset.MoveNext();
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

        public void RefreshMeasureList()
        {
            try
            {
                lstMeasureList.Items.Clear();

                //get the list of jccodes
                modGlobal.gv_sql = "Select indicatorid, jccode from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where JCCode is not null ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and JCCode not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCode from tbl_setup_CMSfieldmeasures ";
                modGlobal.gv_sql = string.Format("{0} where ddid = {1})", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by JCCode ";
                //LDW rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcTempTable = "tbl_setup_Indicator";
                rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTempTable, rdcTemp);
                rdcTemp.AcceptChanges();

                //LDW while (!rdcTemp.Resultset.EOF)
                foreach (DataRow myRow2 in rdcTemp.Tables[rdcTempTable].Rows)
                {
                    lstMeasureList.Items.Add(new ListBoxItem(myRow2.Field<string>("JCCode"), myRow2.Field<int>("IndicatorID")).ToString());
                    //LDW rdcTemp.Resultset.MoveNext();
                }
                rdcTemp.Dispose();

                //add the list of CMScodes
                modGlobal.gv_sql = "Select indicatorid, CMScode from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where CMSCode is not null and IsNull(JCCode,'') <> CMSCode ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and CMSCode not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCode from tbl_setup_CMSfieldmeasures ";
                modGlobal.gv_sql = string.Format("{0} where ddid = {1})", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CMSCode ";
                rdcTempTable = "tbl_setup_Indicator";
                rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTempTable, rdcTemp);
                rdcTemp.AcceptChanges();

                //LDW while (!rdcTemp.Resultset.EOF)
                foreach (DataRow myRow3 in rdcTemp.Tables[rdcTempTable].Rows)
                {
                    lstMeasureList.Items.Add(new ListBoxItem(myRow3.Field<string>("CMSCode"), myRow3.Field<int>("IndicatorID")).ToString());
                    //LDW rdcTemp.Resultset.MoveNext();
                }
                rdcTemp.Dispose();

                lstSelectedMeasures.Items.Clear();

                modGlobal.gv_sql = "Select ddid, MeasureCode from tbl_setup_CMSfieldmeasures ";
                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureCode ";
                rdcTempTable = "tbl_setup_CMSfieldmeasures";
                rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTempTable, rdcTemp);
                rdcTemp.AcceptChanges();

                //LDW while (!rdcTemp.Resultset.EOF)
                foreach (DataRow myRow4 in rdcTemp.Tables[rdcTempTable].Rows)
                {
                    lstSelectedMeasures.Items.Add(new ListBoxItem(myRow4.Field<string>("measurecode"), myRow4.Field<int>("DDID")).ToString());
                    //LDW rdcTemp.Resultset.MoveNext();
                }
                rdcTemp.Dispose();
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

        private void lstFieldList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                txtJCFieldCode.Text = "";
                txtCMSFieldCode.Text = "";

                if (lstFieldList.SelectedIndex > -1)
                {
                    txtJCFieldCode.Enabled = true;
                    txtCMSFieldCode.Enabled = true;
                    lstMeasureList.Enabled = true;
                    lstSelectedMeasures.Enabled = true;
                    cmdLinkToMeasure.Enabled = true;
                    cmdRemoveFromMeasure.Enabled = true;

                    modGlobal.gv_sql = "Select * from tbl_setup_datadef ";
                    modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex));
                    rdcTempTable = "tbl_setup_datadef";
                    rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTempTable, rdcTemp);
                    rdcTemp.AcceptChanges();

                    if (!Information.IsDBNull(rdcTemp.Tables[rdcTempTable].Rows[0]["JCFieldCode"]))
                    {
                        txtJCFieldCode.Text = rdcTemp.Tables[rdcTempTable].Rows[0]["JCFieldCode"].ToString();
                    }

                    if (!Information.IsDBNull(rdcTemp.Tables[rdcTempTable].Rows[0]["cmsfieldcode"]))
                    {
                        txtCMSFieldCode.Text = rdcTemp.Tables[rdcTempTable].Rows[0]["cmsfieldcode"].ToString();
                    }
                    rdcTemp.Dispose();
                }

                RefreshMeasureList();
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
