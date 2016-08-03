using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmMeasureMoveStepTo : Telerik.WinControls.UI.RadForm
    {
        string MeasureCategory;
        int IndicatorID = 0;
        int MeasureCriteriaID = 0;
        string SelectedStep;


        public frmMeasureMoveStepTo()
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
        {  try
            {
                MoveToSelectedStep();
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
            this.Close();
        }

        private void frmMeasureMoveStepTo_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshSteps();
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

        public void SetMeasureCriteriaID(int IID, int mcid, string mcat)
        {
            MeasureCriteriaID = mcid;
            MeasureCategory = mcat;
            IndicatorID = IID;

            try
            {
                modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, mc.Cat_Type ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureStep ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID   ";
                modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql, IndicatorID);
                if (MeasureCategory == "CI")
                {
                    modGlobal.gv_sql = string.Format("{0} and ((mc.CAT_TYPE is null or mc.CAT_TYPE = '{1}') And IsRisk = 0)", modGlobal.gv_sql, MeasureCategory);
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (mc.CAT_TYPE = '{1}')", modGlobal.gv_sql, MeasureCategory);
                    if (MeasureCategory == "RA")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (IsRisk = 1) ";
                    }
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureStep <> -100 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and ms.MeasureStepID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select ms.MeasureStepID from tbl_setup_MeasureCriteriaSet as ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_MeasureCriteria as mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mc.measurecriteriasetid = ms.MeasurecriteriasetID  ";
                modGlobal.gv_sql = string.Format("{0} WHERE mc.MeasureCriteriaID = {1})", modGlobal.gv_sql, MeasureCriteriaID);


                //gv_sql = "SELECT ms.MeasureStep, mcat.Cat_Type "
                //gv_sql = gv_sql & " FROM tbl_setup_MeasureStep ms "
                //gv_sql = gv_sql & " inner join tbl_Measure_Cat mcat "
                //gv_sql = gv_sql & " on ms.Measure_CATID = mcat.Measure_CATID "
                //gv_sql = gv_sql & " Where mcat.CAT_TYPE = '" & MeasureCategory & "'"
                //gv_sql = gv_sql & " and ms.MeasureStepID in  "
                //gv_sql = gv_sql & " (select ms.MeasureStepID from tbl_setup_MeasureCriteriaSet as ms "
                //gv_sql = gv_sql & " inner join tbl_setup_MeasureCriteria as mc "
                //gv_sql = gv_sql & " on mc.measurecriteriasetid = ms.MeasurecriteriasetID  "
                //gv_sql = gv_sql & " WHERE mc.MeasureCriteriaID = " & MeasureCriteriaID & ")"

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName1 = "tbl_setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                SelectedStep = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MeasureStep"].ToString();
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

        public void RefreshSteps()
        {
            //gv_sql = "SELECT ms.MeasureStep, ms.MeasureStepID  "
            //gv_sql = gv_sql & " FROM tbl_setup_MeasureStep ms "
            //gv_sql = gv_sql & " inner join tbl_Measure_Cat mcat "
            //gv_sql = gv_sql & " on ms.Measure_CATID = mcat.Measure_CATID "
            //gv_sql = gv_sql & " Where mcat.CAT_TYPE = '" & MeasureCategory & "'"
            //gv_sql = gv_sql & " and ms.MeasureID = " & IndicatorID
            //gv_sql = gv_sql & " order by ms.MeasureStep "
            //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
            try
            {
                modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureStep ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID   ";
                modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql, IndicatorID);
                //gv_sql = gv_sql & " and (mc.CAT_TYPE is null or mc.CAT_TYPE = '" & MeasureCategory & "')"

                if (MeasureCategory == "CI")
                {
                    modGlobal.gv_sql = string.Format("{0} and ((mc.CAT_TYPE is null or mc.CAT_TYPE = '{1}') And IsRisk = 0)", modGlobal.gv_sql, MeasureCategory);
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (mc.CAT_TYPE = '{1}')", modGlobal.gv_sql, MeasureCategory);
                    if (MeasureCategory == "RA")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (IsRisk = 1) ";
                    }
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureStep <> -100 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ms.MeasureStep ";
                //gv_g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName2 = "tbl_setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //Display the list of fields
                cboSteps.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    cboSteps.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(myRow2.Field<string>("MeasureStep"), myRow2.Field<int>("MeasureStepID")).ToString());
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

        public void MoveToSelectedStep()
        {
            var i = 0;

            try
            {
                //On Error GoTo ErrHandler
                if (cboSteps.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Select a Step before updating the record.");
                    return;
                }


                //gv_sql = "SELECT ms.MeasureStepID, ms.MeasureStep  "
                //gv_sql = gv_sql & " FROM tbl_setup_MeasureStep ms "
                //gv_sql = gv_sql & " inner join tbl_Measure_Cat mcat "
                //gv_sql = gv_sql & " on ms.Measure_CATID = mcat.Measure_CATID "
                //gv_sql = gv_sql & " Where mcat.CAT_TYPE = '" & MeasureCategory & "'"
                //gv_sql = gv_sql & " and ms.MeasureID = " & IndicatorID
                //gv_sql = gv_sql & " order by ms.MeasureStep "

                modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureStep ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID   ";
                modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql, IndicatorID);
                if (MeasureCategory == "CI")
                {
                    modGlobal.gv_sql = string.Format("{0} and ((mc.CAT_TYPE is null or mc.CAT_TYPE = '{1}') And IsRisk = 0)", modGlobal.gv_sql, MeasureCategory);
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (mc.CAT_TYPE = '{1}')", modGlobal.gv_sql, MeasureCategory);
                    if (MeasureCategory == "RA")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (IsRisk = 1) ";
                    }
                }
                //gv_sql = gv_sql & " and (mc.CAT_TYPE is null or mc.CAT_TYPE = '" & MeasureCategory & "')"
                modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureStep <> -100 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ms.MeasureStep ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                i = 0;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    //If gv_rs!MeasureStep = cboSteps.Text Then
                    //    i = gv_rs!MeasureStep
                    //End If

                    if (myRow3.Field<string>("MeasureStep") == SelectedStep)
                    {
                        //update the selected step
                        modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = {0} Where MeasureStepID = {1}", cboSteps.Text, myRow3.Field<string>("MeasureStepID"));
                        //i = cboStep.Text
                    }
                    else
                    {
                        //update other steps
                        i = i + 1;
                        if (i == Convert.ToInt32(cboSteps.Text))
                        {
                            //skip this by one
                            i = i + 1;
                        }
                        modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = {0} Where MeasureStepID = {1}", i, myRow3.Field<string>("MeasureStepID"));
                    }
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

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

    }
}
