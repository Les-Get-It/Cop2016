using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmMeasureModifyCategory : Telerik.WinControls.UI.RadForm
    {

        public frmMeasureModifyCategory()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            frmMeasureCriteriaSetup frmMeasureCriteriaSetupCopy = new frmMeasureCriteriaSetup();
            string ls_CritType = null;
            //LDW Index = frmMeasureCriteriaSetupCopy.SSTabCriteria.SelectedIndex;
            int Index = frmMeasureCriteriaSetupCopy.SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;

            try
            {
                switch (Index)
                {
                    case 0:
                        ls_CritType = "Reg";
                        break;
                    case 1:
                        ls_CritType = "Filter";
                        break;
                    case 2:
                        ls_CritType = "Risk";
                        break;
                }


                if (cboCat.SelectedIndex > -1 & !string.IsNullOrEmpty(txtGoToStep.Text))
                {
                    RadMessageBox.Show("Either category or the destination step has to be defined, but not both.");
                    return;
                }

                int MeasureStepID = 0;

                modGlobal.gv_sql = " select MeasureStepID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID , MeasureCriteriaID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStep ";

                if (Index == 0)
                {
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(frmMeasureCriteriaSetupCopy.lstMeasureDef0,
                        frmMeasureCriteriaSetupCopy.lstMeasureDef0.SelectedIndex));
                }
                else if (Index == 1)
                {
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(frmMeasureCriteriaSetupCopy.lstMeasureDef1,
                        frmMeasureCriteriaSetupCopy.lstMeasureDef1.SelectedIndex));
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(frmMeasureCriteriaSetupCopy.lstMeasureDef2,
                        frmMeasureCriteriaSetupCopy.lstMeasureDef2.SelectedIndex));
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "vuMeasureCriteriaSetStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MeasureStepID"]);
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "Update tbl_Setup_MeasureStep set ";
                if (cboCat.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Measure_CatID = null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Measure_CatID = {1}", modGlobal.gv_sql, Support.GetItemData(cboCat, cboCat.SelectedIndex));
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ",  ";
                if (string.IsNullOrEmpty(txtGoToStep.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " gotostep = null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} gotostep = {1}", modGlobal.gv_sql, txtGoToStep.Text);
                }
                if (ls_CritType == "Risk")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + ", IsRisk = 1";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + ", IsRisk = 0";
                }

                modGlobal.gv_sql = string.Format("{0} where MeasureStepID = {1}", modGlobal.gv_sql, MeasureStepID);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

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

        private void frmMeasureModifyCategory_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshCatList();
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

        public void RefreshCatList()
        {
            frmMeasureCriteriaSetup frmMeasureCriteriaSetupCopy = new frmMeasureCriteriaSetup();
            string CatID = null;
            string is_CritType = null;
            int li_SELcatID = -1;
            string ls_CritType = null;
            int Index = frmMeasureCriteriaSetupCopy.SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;


            try
            {
                switch (Index)
                {
                    case 0:
                        ls_CritType = "Reg";
                        break;
                    case 1:
                        ls_CritType = "Filter";
                        break;
                    case 2:
                        ls_CritType = "Risk";
                        break;
                }
                modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT ";

                if (is_CritType == "Reg")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'CI'";
                }
                else if (is_CritType == "Risk")
                {
                    //gv_sql = gv_sql & " WHERE CAT_TYPE = 'RA'"
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE (CAT_TYPE = 'RA' Or IsRisk = 1) ";
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
                        if (myRow2.Field<int>("measure_catid") == Convert.ToInt16(CatID))
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
    }
}
