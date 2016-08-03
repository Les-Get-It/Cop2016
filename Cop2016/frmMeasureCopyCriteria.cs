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
    public partial class frmMeasureCopyCriteria : Telerik.WinControls.UI.RadForm
    {
        private string[] is_MeasureCriteriaIDs;
        //M' - measure
        //S' - submit
        private string is_CopyType;
        private string[] is_SubmitCriteriaIDs;
        private string is_MeasureID;
        private string is_SubGroupID;
        public string rdcSubmissionFieldListTable = "tbl_setup_SubmitGroup";



        public frmMeasureCopyCriteria()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void SetSubGroupID(string SubGroupID)
        {
            is_SubGroupID = SubGroupID;
        }

        public void SetMeasureID(string MeasureID)
        {
            is_MeasureID = MeasureID;
        }

        public void SetMeasureCriteriaID(string[] MeasureCriteriaID)
        {
            //LDW is_MeasureCriteriaIDs = (Support.CopyArray(MeasureCriteriaID));
            is_MeasureCriteriaIDs = MeasureCriteriaID;
        }

        public void SetSubmitCriteriaID(string[] SubmitCriteriaID)
        {
            is_SubmitCriteriaIDs = SubmitCriteriaID;
        }

        public void SetCopyType(string CopyType)
        {
            is_CopyType = CopyType;
        }

        private void cboMeasures_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshMeasureSteps();
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
                RefreshMeasureStepSets();
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

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            string is_subgroup = null;

            try
            {

                if (rboCopyTo1.IsChecked)
                {
                    //submission
                    if (is_CopyType == "M" & string.IsNullOrEmpty(is_MeasureID))
                    {
                        CopyFromMeasureToSubmit();
                    }
                    else if (is_CopyType == "S" & string.IsNullOrEmpty(is_SubGroupID))
                    {
                        CopyFromSubmitToSubmit();
                    }
                    else if (!string.IsNullOrEmpty(is_subgroup) | !string.IsNullOrEmpty(is_MeasureID))
                    {
                        RadMessageBox.Show("This ability is not implemented yet");
                    }

                }
                else if (rboCopyTo2.IsChecked)
                {
                    //measure
                    if (is_CopyType == "M")
                    {
                        CopyFromMeasureToMeasure();
                    }
                    else
                    {
                        CopyFromSubmitToMeasure();
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

        private void cmdCopySetp_Click(object sender, EventArgs e)
        {

            try
            {
                if (rboCopyTo1.IsChecked)
                {
                    RadMessageBox.Show("With this feature, you can only copy the entire step from one measure to another measure.");
                    return;
                }
                else if (rboCopyTo2.IsChecked)
                {
                    //measure
                    if (is_CopyType != "M")
                    {
                        RadMessageBox.Show("With this feature, you can only copy the entire step from one measure to another measure.");
                        return;
                    }
                }

                if (cboStep.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please specify what step you are copying to.");
                    return;
                }

                if (cboMeasures.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please specify what measure you are copying to.");
                    return;
                }



                int li_NewCriteriaSetID;
                int li_MeasureID;
                int li_MaxStep;
                int li_NewStepID;
                int li_CatID = 0;
                int li_MeasureStepID = 0;
                int li_GoToStep = 0;
                int li_MeasureStep = Support.GetItemData(cboStep, cboStep.SelectedIndex);
                int NewSetID;
                DataSet rs_critSet = new DataSet();


                // ERROR: Not supported in C#: OnErrorStatement


                modGlobal.gv_sql = string.Format("SELECT ms.MeasureID, ms.MeasureStep, ms.MeasureStepID, ms.Measure_CATID, ms.gotostep FROM  tbl_setup_measurecriteria mc, " +
                    "tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms  WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid  AND ms.MeasureStepID = mcs.MeasureStepID " +
                    "AND mc.MeasureCriteriaID in ({0})", Strings.Join(is_MeasureCriteriaIDs, ", "));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_measurecriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                li_MeasureID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MeasureID"]);
                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["measure_catid"]))
                {
                    li_CatID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["measure_catid"]);
                }
                if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["GoToStep"]))
                {
                    li_GoToStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["GoToStep"]);
                }

                li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MeasureID"]);
                modGlobal.gv_rs.Dispose();

                //step should only be copied into a blank one
                modGlobal.gv_sql = "Select * from tbl_Setup_MeasureCriteriaSet mcs inner join tbl_setup_MeasureStep ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mcs.measurestepid = ms.measurestepid";
                modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and ms.MeasureStep = {1}", modGlobal.gv_sql, li_MeasureStep);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count > 0)
                {
                    RadMessageBox.Show("The step can be copied only to another step that does not have any sets.");
                    return;
                }

                //insert new step record
                modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureID, MeasureStep, Measure_CATID, GoToStep ) VALUES ";
                modGlobal.gv_sql = string.Format("{0} ({1}, ", modGlobal.gv_sql, Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_MeasureStep);

                if (li_CatID > 0)
                {
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, li_CatID);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,";
                }
                if (li_GoToStep > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + li_GoToStep;
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                li_NewStepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

                //insert new set record
                modGlobal.gv_sql = "SELECT * FROM  tbl_setup_measurecriteriaset ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, li_MeasureStepID);

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_setup_measurecriteriaset";
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);
                //LDW while (!rs_critSet.EOF)
                foreach (DataRow myRow3 in rs_critSet.Tables[sqlTableName3].Rows)
                {
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_measureCriteriaSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  (MeasureCriteriaSet, MeasureStepID, JoinOperator) ";
                    modGlobal.gv_sql = string.Format("{0}  SELECT MeasureCriteriaSet, {1}", modGlobal.gv_sql, li_NewStepID);
                    modGlobal.gv_sql = modGlobal.gv_sql + ", JoinOperator ";
                    modGlobal.gv_sql = string.Format("{0}  FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = {1}", modGlobal.gv_sql, myRow3.Field<int>("MeasureCriteriaSetID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "SELECT max(MeasureCriteriaSetID) as newsetID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_measurecriteriaset ";
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, li_NewStepID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName4 = "tbl_setup_measurecriteriaset";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);
                    NewSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["NewSetID"]);

                    //copy the criteria
                    modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteria (";
                    modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID, MultSelAny ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewSetID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID, MultSelAny ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaSetID = {1}", modGlobal.gv_sql, myRow3.Field<int>("MeasureCriteriaSetID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) ";
                    modGlobal.gv_sql = string.Format("{0} SELECT {1}, {2}", modGlobal.gv_sql, li_NewStepID, NewSetID);
                    modGlobal.gv_sql = modGlobal.gv_sql + ", MeasureStepGroup, JoinOperator ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  From tbl_Setup_MeasureStepGroup ";
                    modGlobal.gv_sql = string.Format("{0}     WHERE MeasureCriteriaSetID = {1}", modGlobal.gv_sql, myRow3.Field<int>("MeasureCriteriaSetID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    //LDW rs_critSet.MoveNext();
                }

                rs_critSet.Dispose();
                this.Close();

                return;
                ////LDW ErrHandler:

                //LDW modGlobal.CheckForErrors();
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

        private void frmMeasureCopyCriteria_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {

                RefreshSubmitColumnList();
                RefreshSubmitSetList();

                RefreshMeasuresList();

                if (is_CopyType == "M")
                {
                    if (!string.IsNullOrEmpty(is_MeasureID))
                    {
                        modGlobal.gv_sql = "SELECT Description as CriteriaTitle FROM tbl_Setup_Indicator WHERE IndicatorID = " + is_MeasureID;
                    }
                    else
                    {
                        modGlobal.gv_sql = "Select CriteriaTitle from tbl_setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID in ({1})", modGlobal.gv_sql, Strings.Join(is_MeasureCriteriaIDs, ","));
                    }
                }
                else if (is_CopyType == "S")
                {
                    if (!string.IsNullOrEmpty(is_SubGroupID))
                    {
                        modGlobal.gv_sql = "select GroupName + ' / ' + sgr.Title + ' / ' + sg.Title as CriteriaTitle" +
                            " from tbl_setup_submitsubgroup sg, tbl_setup_submitgroup g, tbl_setup_submitgrouprow sgr " +
                            " Where sg.GroupRowID = sgr.GroupRowID And g.GroupID = sgr.GroupID AND sg.SubGroupID = " + is_SubGroupID;
                    }
                    else
                    {
                        modGlobal.gv_sql = "Select CriteriaTitle from tbl_setup_SubmitCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where submitcriteriaid in ({1})", modGlobal.gv_sql, Strings.Join(is_SubmitCriteriaIDs, ","));
                    }
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);
                lblCopyFrom.Text = "";

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    lblCopyFrom.Text = string.Format("{0}, {1}", lblCopyFrom.Text, myRow4.Field<string>("CriteriaTitle"));
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

        private void cboColumns_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshSubmitSetList();
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
                if (cboColumns.Enabled)
                {
                    RefreshSubmitSetDef();
                }
                else if (cboMeasures.Enabled)
                {
                    RefreshMeasureSetDef();
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

        private bool CopyStepandSetRecords()
        {
            bool functionReturnValue = false;
            int li_StepID;
            int li_SetID = 0;
            DataSet rs_MeasSet = new DataSet();
            DataSet rs_Crit = new DataSet();
            DataSet rs_Step = new DataSet();
            int li_MaxStep = 0;
            int li_cnt = 1;
            int li_StepCnt = 1;

            // ERROR: Not supported in C#: OnErrorStatement




            if (cboMeasures.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a measure to copy to");
                functionReturnValue = false;
                return functionReturnValue;
            }

            if (cboStep.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a step to copy to");
                functionReturnValue = false;
                return functionReturnValue;
            }


            try
            {
                modGlobal.gv_sql = string.Format("SELECT max(MeasureStep) as MaxStep  FROM tbl_Setup_MeasureStep WHERE   MeasureID = {0}", Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                //nz was replaced
                //li_MaxStep = Nz(gv_rs!MaxStep, 0)
                if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["MaxStep"]))
                {
                    li_MaxStep = 0;
                }
                else
                {
                    li_MaxStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["MaxStep"]);
                }

                if (li_MaxStep != 0)
                {
                    if (li_MaxStep >= Support.GetItemData(cboStep, cboStep.SelectedIndex))
                    {
                        RadMessageBox.Show("You must select a new step to start copying to");
                        functionReturnValue = false;
                        return functionReturnValue;
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

            //If Not gv_rs.EOF Then
            //    MsgBox "Please choose a new measure", vbCritical, "Only Copy to Measure without Flowchart!"
            //    CopyStepandSetRecords = False
            //    Exit Function
            //End If

            modGlobal.gv_rs.Dispose();

            try
            { 
            modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureStep WHERE MeasureID = {0} ORDER BY MeasureStep", is_MeasureID);

            //LDW rs_Step = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            const string sqlTableName6 = "tbl_Setup_MeasureStep";
            rs_Step = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                //LDW while (!rs_Step.EOF)
                foreach (DataRow myRow6 in rs_Step.Tables[sqlTableName6].Rows)
                {
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureStep, MeasureID, Measure_CATID, GoToStep,IsRisk ) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (";
                    modGlobal.gv_sql = modGlobal.gv_sql + (Information.IsDBNull(myRow6.Field<string>("measure_catid")) &
                        Information.IsDBNull(myRow6.Field<string>("GoToStep")) ? -100 : li_MaxStep + li_StepCnt);
                    modGlobal.gv_sql = string.Format("{0}, {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}, {1}", modGlobal.gv_sql, Information.IsDBNull(myRow6.Field<string>("measure_catid"))
                        ? "NULL" : myRow6.Field<string>("measure_catid"));
                    modGlobal.gv_sql = string.Format("{0}, {1}", modGlobal.gv_sql, Information.IsDBNull(myRow6.Field<string>("GoToStep"))
                        ? "NULL" : myRow6.Field<string>("GoToStep") + ", " + (myRow6.Field<bool>("isrisk") ? "1" : "0"));
                    modGlobal.gv_sql = modGlobal.gv_sql + ")";

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    li_StepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + myRow6.Field<string>("MeasureStepID");
                    //LDW rs_MeasSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_Setup_MeasureCriteriaSet";
                    rs_MeasSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);
                    //LDW while (!rs_MeasSet.EOF)
                    foreach (DataRow myRow7 in rs_MeasSet.Tables[sqlTableName7].Rows)
                    {
                        modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_MeasureCriteriaSet (MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES ({0}, {1}, '{2}')",
                            myRow7.Field<string>("MeasureCriteriaSet"), li_StepID, myRow7.Field<string>("JoinOperator"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSet");
                        modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_MeasureCriteria (MeasureCriteriaSetID, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, " +
                            "LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, State, RecordStatus, MeasureFieldGroupLogicID, MultSelAny)  SELECT {0}, CriteriaTitle, DDID1, " +
                            "DDID2, ValueOperator, FieldValue, DestDDID,  LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, State, RecordStatus, MeasureFieldGroupLogicID, " +
                            "MultSelAny  FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = {1}", li_SetID, myRow7.Field<string>("MeasureCriteriaSetID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " +
                            "SELECT {0}, {1}, MeasureStepGroup, JoinOperator FROM tbl_Setup_measureStepGroup WHERE  MeasureCriteriaSetID = {2} AND MeasureStepID = {3}"
                            , li_StepID, li_SetID, myRow7.Field<string>("MeasureCriteriaSetID"), myRow7.Field<string>("MeasureStepID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //LDW rs_MeasSet.MoveNext();
                        li_cnt = li_cnt + 1;
                    }
                    rs_MeasSet.Dispose();

                    if ((!Information.IsDBNull(myRow6.Field<string>("measure_catid")) | (!Information.IsDBNull(myRow6.Field<string>("GoToStep")))))
                    {
                        li_StepCnt = li_StepCnt + 1;
                    }

                    //LDW rs_Step.MoveNext();

                    rs_Step.Dispose();
                    functionReturnValue = true;
                    return functionReturnValue;
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
            ////LDW ErrHandler:


            //LDW modGlobal.CheckForErrors();
            functionReturnValue = false;
            return functionReturnValue;
        }

        private int InsertStepandSetRecords()
        {
            int functionReturnValue = 0;
            int li_StepID = 0;
            int li_SetID = -1;
            int li_OldStep = Support.GetItemData(cboStep, cboStep.SelectedIndex);
            string ls_DefJoin = null;
            DataSet rs_catid = new DataSet();

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                modGlobal.gv_sql = "SELECT ms.* FROM tbl_Setup_MeasureStep as ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT as mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ms.measure_CATID = mc.Measure_CATID ";
                modGlobal.gv_sql = string.Format("{0} WHERE ms.MeasureID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} AND ms.MeasureStep = {1}", modGlobal.gv_sql, li_OldStep);

                if (Strings.InStr(cboStep.Text, "Risk") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND mc.CAT_TYPE = 'RA'";
                }
                else if (Strings.InStr(cboStep.Text, "Flow") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (mc.CAT_TYPE is null or mc.CAT_TYPE = 'CI')";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName8 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);


                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count; itr++)
                {
                    var myRowA = modGlobal.gv_rs.Tables[sqlTableName8].Rows[itr];
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName8].Rows.IndexOf(myRowA);
                    int rowLast = modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count - 1;

                    if (itr == rowLast)
                    {
                        modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStep ";
                        modGlobal.gv_sql = string.Format("{0} WHERE MeasureID = {1}", modGlobal.gv_sql,
                            Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                        modGlobal.gv_sql = string.Format("{0} AND MeasureStep = {1}", modGlobal.gv_sql, li_OldStep);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                        const string sqlTableName9 = "tbl_Setup_MeasureStep";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                        //LDW modGlobal.gv_rs.AddNew();
                        DataRow newRow = modGlobal.gv_rs.Tables[sqlTableName8].NewRow();

                        newRow["MeasureID"] = Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
                        newRow["measurestep"] = li_OldStep;


                        //Filters do not get assigned to a category
                        if (Strings.InStr(cboStep.Text, "Flow") > 0 & !Information.IsDBNull(myRowA.Field<int>("measure_catid")))
                        {
                            //LDW rs_catid = modGlobal.gv_cn.OpenResultset("SELECT MEASURE_CATID FROM tbl_Measure_Cat " + " WHERE CAT_TYPE = 'CI'");
                            const string sqlTableName10 = "tbl_Measure_Cat";
                            rs_catid = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                            //LDW if (!rs_catid.EOF)
                            foreach (DataRow myRow10 in rs_catid.Tables[sqlTableName10].Rows)
                            {
                                newRow["measure_catid"] = myRow10.Field<int>("measure_catid");
                            }
                            rs_catid.Dispose();
                        }
                        else if (Strings.InStr(cboStep.Text, "Risk") > 0)
                        {
                            //LDW rs_catid = modGlobal.gv_cn.OpenResultset("SELECT MEASURE_CATID FROM tbl_Measure_Cat " + " WHERE CAT_TYPE = 'RA'");
                            const string sqlTableName11 = "tbl_Measure_Cat";
                            rs_catid = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                            //LDW if (!rs_catid.EOF)
                            foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName11].Rows)
                            {
                                newRow["measure_catid"] = myRow11.Field<int>("measure_catid");
                            }
                            rs_catid.Dispose();
                        }

                        modGlobal.gv_rs.Tables[sqlTableName8].Rows.Add(newRow);
                        modGlobal.gv_rs.AcceptChanges();
                        modGlobal.gv_rs.Dispose();

                        li_StepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");
                    }
                    else
                    {
                        li_StepID = myRowA.Field<int>("MeasureStepID");
                        modGlobal.gv_rs.Dispose();
                    }
                }

                modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureCriteriaSet  WHERE MeasureStepID = {0} AND MeasureCriteriaSet = {1}",
                    li_StepID, Support.GetItemData(cboSet, cboSet.SelectedIndex) - 1);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);
                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                {
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName12].Rows.IndexOf(myRow12);
                    int rowLast = modGlobal.gv_rs.Tables[sqlTableName12].Rows.Count - 1;
                    if (rowIndex != rowLast)
                    {
                        ls_DefJoin = myRow12.Field<string>("JoinOperator");
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
                const string sqlTableName13 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count; itr++)
                {
                    var myRowB = modGlobal.gv_rs.Tables[sqlTableName13].Rows[itr];
                    int rowIndexA = modGlobal.gv_rs.Tables[sqlTableName13].Rows.IndexOf(myRowB);
                    if (rowIndexA == modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count - 1)
                    {
                        //default join to AND
                        //LDW modGlobal.gv_rs.AddNew();
                        //LDW creat new datatable row
                        DataRow newRow = modGlobal.gv_rs.Tables[sqlTableName13].NewRow();

                        //Add row columns
                        newRow["MeasureCriteriaSet"] = Support.GetItemData(cboSet, cboSet.SelectedIndex);
                        newRow["MeasureStepID"] = li_StepID;
                        newRow["JoinOperator"] = ls_DefJoin;

                        modGlobal.gv_rs.Tables[sqlTableName13].Rows.Add(newRow);
                        modGlobal.gv_rs.AcceptChanges();
                        modGlobal.gv_rs.Dispose();

                        li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSet");
                    }
                    else
                    {
                        li_SetID = myRowB.Field<int>("MeasureCriteriaSetID");
                        modGlobal.gv_rs.Dispose();
                    }
                }

                functionReturnValue = li_SetID;
                return functionReturnValue;
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
            return functionReturnValue;
        }

        private void CopyFromMeasureToMeasure()
        {
            int li_SetID = 0;

            //On Error GoTo ErrHandler
            try
            {

                if (string.IsNullOrEmpty(is_MeasureID))
                {
                    if (cboStep.SelectedIndex < 0 | cboSet.SelectedIndex < 0 | cboMeasures.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                    {
                        RadMessageBox.Show("Define the definition of the new criteria.");
                    }
                    else
                    {
                        //copy the criteria
                        li_SetID = InsertStepandSetRecords();

                        if (li_SetID != -1)
                        {
                            modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteria (";
                            modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID, MultSelAny ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                            modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                            modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_SetID);
                            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                            modGlobal.gv_sql = string.Format("{0} '{1}', MeasureFieldGroupLogicID, MultSelAny ", modGlobal.gv_sql, cboJoinOperator.Text);
                            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                            modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID in ({1})", modGlobal.gv_sql, Strings.Join(is_MeasureCriteriaIDs, ", "));

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            this.Close();
                        }
                    }
                }
                else
                {
                    modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureStep WHERE   MeasureID = {0}",
                        Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName14 = "tbl_Setup_MeasureStep";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);
                    if (modGlobal.gv_rs.Tables[sqlTableName14].Rows.Count > 0)
                    {
                        RadMessageBox.Show("Cannot duplicate! The destination measure has some criteria in the flowchart that has to be removed first.");
                    }
                    else
                    {
                        if (CopyStepandSetRecords())
                            this.Close();
                    }
                }

                return;
                ////LDW ErrHandler:

                //LDW modGlobal.CheckForErrors();
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

        private void CopyFromSubmitToMeasure()
        {
            int li_SetID;
            int li_MeasureCriteriaSetID = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {

                if (string.IsNullOrEmpty(is_SubGroupID))
                {
                    if (cboStep.SelectedIndex < 0 | cboSet.SelectedIndex < 0 | cboMeasures.SelectedIndex < 0 |
                        (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                    {
                        RadMessageBox.Show("Define the definition of the new criteria.");
                    }
                    else
                    {
                        //copy the criteria
                        li_SetID = InsertStepandSetRecords();

                        if (li_SetID != -1)
                        {
                            //copy the criteria
                            modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteria (";
                            modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                            modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                            modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_SetID);
                            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                            modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, cboJoinOperator.Text);
                            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitCriteria ";
                            modGlobal.gv_sql = string.Format("{0} where SubmitCriteriaID in ({1})", modGlobal.gv_sql, Strings.Join(is_SubmitCriteriaIDs, ","));

                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            this.Close();
                        }
                    }
                }
                else
                {
                    if (CopySubmitTOMeasure())
                        this.Close();
                }

                return;
                ////LDW ErrHandler:

                //LDW modGlobal.CheckForErrors();
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

        private bool CopySubmitTOMeasure()
        {
            bool functionReturnValue = false;
            int li_StepID;
            int li_SetID = 0;
            DataSet rs_Set = new DataSet();

            // ERROR: Not supported in C#: OnErrorStatement

                                   

                if (cboStep.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please Select Step to Copy to");
                    functionReturnValue = false;
                    return functionReturnValue;
                }

                if (cboMeasures.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a measure to copy to");
                    functionReturnValue = false;
                    return functionReturnValue;
                }

            try
            {

                modGlobal.gv_sql = string.Format("SELECT *  FROM tbl_Setup_MeasureStep WHERE MeasureID = {0} AND MeasureStep = {1}",
                    Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex), Support.GetItemData(cboStep, cboStep.SelectedIndex));

                if (Strings.InStr(cboStep.Text, "Risk") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')";
                }
                else if (Strings.InStr(cboStep.Text, "Flow") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName15 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName15].Rows.Count; itr++)
                {
                    var myRowC = modGlobal.gv_rs.Tables[sqlTableName15].Rows[itr];
                    int rowIndexA = modGlobal.gv_rs.Tables[sqlTableName15].Rows.IndexOf(myRowC);
                    if (rowIndexA != modGlobal.gv_rs.Tables[sqlTableName15].Rows.Count - 1)
                    {
                        RadMessageBox.Show("Please choose a new step", "Only Copy to Measure Step without Criteria!", MessageBoxButtons.OK, RadMessageIcon.Error);
                        functionReturnValue = false;
                        return functionReturnValue;
                    }
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

            try
            {

                if (Strings.InStr(cboStep.Text, "Risk") > 0)
                {
                    modGlobal.gv_sql = "SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA'";
                }
                else if (Strings.InStr(cboStep.Text, "Flow") > 0)
                {
                    modGlobal.gv_sql = "SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI'";
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName16 = "tbl_MEASURE_CAT";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_MeasureStep (MeasureStep, MeasureID, Measure_CATID) VALUES ({0} , {1}, {2})",
                    Support.GetItemData(cboStep, cboStep.SelectedIndex),
                    Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex), modGlobal.gv_rs.Tables[sqlTableName16].Rows[0]["measure_catid"]);
                modGlobal.gv_rs.Dispose();

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                li_StepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

                modGlobal.gv_sql = string.Format("SELECT CriteriaSet FROM tbl_Setup_SubmitCriteria  WHERE subgroupid = {0} GROUP BY CriteriaSet ORDER BY CriteriaSet", is_SubGroupID);
                //LDW rs_Set = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "tbl_Setup_SubmitCriteria";
                rs_Set = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                //LDW while (!rs_Set.EOF)
                foreach (DataRow myRow17 in rs_Set.Tables[sqlTableName17].Rows)
                {
                    modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_MeasureCriteriaSet (MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES ({0}, {1}, 'AND')",
                        myRow17.Field<string>("CriteriaSet"), li_StepID);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSet");

                    modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_MeasureCriteria (MeasureCriteriaSetID, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, " +
                        "LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID)  SELECT {0}, CriteriaTitle, DDID1, DDID2, ValueOperator, [Value], DestDDID,  " +
                        "LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID  from tbl_setup_SubmitCriteria where subgroupid = {1} " +
                        " AND CriteriaSet = {2}", li_SetID, is_SubGroupID, myRow17.Field<string>("CriteriaSet"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //LDW rs_Set.MoveNext();
                }
                rs_Set.Dispose();

                functionReturnValue = true;
                return functionReturnValue;
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
            ////LDW ErrHandler:


                //LDW modGlobal.CheckForErrors();
                functionReturnValue = false;
                return functionReturnValue;
        }

        private void CopyFromSubmitToSubmit()
        {
            int NewCritID;

            try
            {
                if (cboSet.SelectedIndex < 0 | cboColumns.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Define the definition of the new criteria.");
                }
                else
                {
                    //copy the criteria
                    modGlobal.gv_Action = "Add";
                    NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
                    modGlobal.gv_sql = " insert into tbl_Setup_SubmitCriteria (";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SubmitCriteriaID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Criteriaset ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                    modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboColumns, cboColumns.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboJoinOperator.Text);
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where SubmitCriteriaID in ({1})", modGlobal.gv_sql, Strings.Join(is_SubmitCriteriaIDs, ","));

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    this.Close();
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

        private void CopyFromMeasureToSubmit()
        {
            int NewCritID;

            try
            {
                if (cboSet.SelectedIndex < 0 | cboColumns.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Define the definition of the new criteria.");
                }
                else
                {
                    //copy the criteria
                    modGlobal.gv_Action = "Add";
                    NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
                    modGlobal.gv_sql = " insert into tbl_Setup_SubmitCriteria (";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SubmitCriteriaID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Criteriaset ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                    modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, NewCritID);
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboColumns, cboColumns.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, cboJoinOperator.Text);
                    modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID in ({1})", modGlobal.gv_sql, Strings.Join(is_MeasureCriteriaIDs, ", "));

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    this.Close();
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

        private void RefreshSubmitSetDef()
        {

            try
            {
                modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboColumns, cboColumns.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, Support.GetItemData(cboSet, cboSet.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName18 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName18].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName18].Rows[0]["JoinOperator"].ToString();
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

        private void RefreshSubmitSetList()
        {
            int SetIndex = 1;


            try
            {
                cboSet.Items.Clear();

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
                if (cboColumns.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where SubGroupID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboColumns, cboColumns.SelectedIndex));
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName19 = "tbl_setup_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                //Display the list of criteria
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow19 in modGlobal.gv_rs.Tables[sqlTableName19].Rows)
                {
                    cboSet.Items.Add("Set " + SetIndex);
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

        private void RefreshSubmitColumnList()
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            int thisSubGroup = 0;
            var i = 0;

            try
            {

                modGlobal.gv_sql = "Select g.*, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.showonreport as showcolonreport ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
                modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where g.state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and g.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by g.ordernumber, r.ordernumber, c.ordernumber ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                //Display the list of fields
                i = -1;
                cboColumns.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow20 in modGlobal.gv_rs.Tables[sqlTableName20].Rows)
                {
                    i = i + 1;
                    cboColumns.Items.Add(new ListBoxItem(myRow20.Field<string>("GroupName") + " / " + myRow20.Field<string>("GroupRow") + " / " +
                        myRow20.Field<string>("GroupCol"), myRow20.Field<int>("SubGroupID")).ToString());

                    if (is_CopyType == "S")
                    {
                        if (myRow20.Field<int>("SubGroupID") == Convert.ToInt32(frmSubmissionSetupCopy.rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows[0]["SubGroupID"]))
                        {
                            thisSubGroup = i;
                        }
                    }
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();

                cboColumns.SelectedIndex = thisSubGroup;
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

        private void RefreshMeasuresList()
        {

            try
            {
                modGlobal.gv_sql = "Select ms.MeasureSetDesc, i.JCAHOID, i.Description, i.IndicatorID, ms.MeasureSetID from tbl_setup_indicator i " +
                    ", tbl_setup_MeasureSetMapMeas isf, tbl_setup_MeasureSet ms Where i.IndicatorID = isf.IndicatorID " + " and isf.MeasureSetID = ms.MeasureSetID ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (i.state = '' or i.state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} AND i.state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and i.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by ms.MeasureSetDesc, i.JCAHOID, i.Description";

                cboMeasures.Items.Clear();

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName21 = "tbl_setup_indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow21 in modGlobal.gv_rs.Tables[sqlTableName21].Rows)
                {
                    cboMeasures.Items.Add(new ListBoxItem(myRow21.Field<string>("JCAHOID") + " - " +
                        myRow21.Field<string>("Description"), myRow21.Field<int>("IndicatorID")).ToString());
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

        private void RefreshMeasureSteps()
        {
            int li_MaxCI = 0;
            int li_MaxRA = 0;

            try
            {

                cboStep.Items.Clear();

                if (cboMeasures.SelectedIndex < 0)
                    return;

                modGlobal.gv_sql = "SELECT MeasureStep, MeasureStepID, CAT_TYPE ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT c ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MEASURE_CATID = c.MEASURE_CATID";
                modGlobal.gv_sql = string.Format("{0} where MeasureID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                modGlobal.gv_sql = modGlobal.gv_sql + " AND measurestep <> -100 and (CAT_TYPE is null or CAT_TYPE = 'CI') ORDER BY MeasureStep ASC";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow22 in modGlobal.gv_rs.Tables[sqlTableName22].Rows)
                {
                    cboStep.Items.Add(myRow22.Field<string>("measurestep") + " (Flow)");
                    li_MaxCI = myRow22.Field<int>("measurestep");
                    Support.SetItemData(cboStep, (cboStep.Items.Count - 1), myRow22.Field<int>("measurestep"));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                cboStep.Items.Add(new ListBoxItem((li_MaxCI + 1) + " (Flow)", (li_MaxCI + 1)).ToString());

                modGlobal.gv_sql = "SELECT RiskAdjusted FROM tbl_Setup_Indicator WHERE IndicatorID = " +
                    Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName23 = "tbl_Setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName23].Rows[0]["RiskAdjusted"]) == 1)
                {
                    modGlobal.gv_rs.Dispose();

                    modGlobal.gv_sql = string.Format("SELECT MeasureStep, MeasureStepID   FROM tbl_Setup_MeasureStep ms , tbl_MEASURE_CAT c  WHERE ms.MEASURE_CATID = c.MEASURE_CATID " +
                        "AND ms.MeasureID = {0} AND c.CAT_TYPE = 'RA' ORDER BY ms.MeasureStep ASC",
                        Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName24 = "tbl_Setup_MeasureStep";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow24 in modGlobal.gv_rs.Tables[sqlTableName24].Rows)
                    {
                        cboStep.Items.Add(myRow24.Field<string>("measurestep") + " (Risk)");
                        li_MaxRA = myRow24.Field<int>("measurestep");
                        Support.SetItemData(cboStep, (cboStep.Items.Count - 1), myRow24.Field<int>("measurestep"));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    modGlobal.gv_rs.Dispose();

                    cboStep.Items.Add(new ListBoxItem(li_MaxRA + 1 + " (Risk)", li_MaxRA + 1).ToString());
                }

                modGlobal.gv_sql = string.Format("SELECT MeasureStep, MeasureStepID  FROM tbl_Setup_MeasureStep WHERE MeasureID = {0} AND MeasureStep = -100 ORDER BY MeasureStep ASC",
                    Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName25 = "tbl_Setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);
                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow25 in modGlobal.gv_rs.Tables[sqlTableName25].Rows)
                {
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName25].Rows.IndexOf(myRow25);
                    if (rowIndex != modGlobal.gv_rs.Tables[sqlTableName25].Rows.Count - 1)
                    {
                        cboStep.Items.Add(new ListBoxItem("Filter", myRow25.Field<int>("measurestep")).ToString());
                    }
                    else
                    {
                        cboStep.Items.Add(new ListBoxItem("Filter", -100).ToString());
                    }
                }
                modGlobal.gv_rs.Dispose();

                RefreshMeasureStepSets();
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

        private void RefreshMeasureStepSets()
        {
            int li_MaxSet = 0;

            try
            {

                cboSet.Items.Clear();
                cboJoinOperator.SelectedIndex = -1;

                if (cboStep.SelectedIndex < 0)
                    return;

                //get count of sets in step
                modGlobal.gv_sql = "SELECT mcs.MeasureCriteriaSet, mcs.MeasureCriteriaSetID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureCriteriaSet mcs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureStep ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mcs.MeasureStepID = ms.MeasureStepID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT as mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = mc.Measure_CATID ";
                modGlobal.gv_sql = string.Format("{0} where ms.MeasureStep = {1}", modGlobal.gv_sql, Support.GetItemData(cboStep, cboStep.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0}  AND ms.MeasureID = {1}", modGlobal.gv_sql, Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex));

                if (Strings.InStr(cboStep.Text, "Risk") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND CAT_TYPE = 'RA'";
                }
                else if (Strings.InStr(cboStep.Text, "Flow") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (Cat_Type is null or CAT_TYPE = 'CI')";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureCriteriaSet ASC";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName26 = "tbl_setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow26 in modGlobal.gv_rs.Tables[sqlTableName26].Rows)
                {
                    cboSet.Items.Add(myRow26.Field<string>("MeasureCriteriaSet"));
                    li_MaxSet = myRow26.Field<int>("MeasureCriteriaSet");
                    Support.SetItemData(cboSet, cboSet.Items.Count - 1, myRow26.Field<int>("MeasureCriteriaSet"));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                cboSet.Items.Add(new ListBoxItem(Convert.ToString(li_MaxSet + 1), li_MaxSet + 1).ToString());

                if (cboStep.Text == "Filter")
                {
                    cboSet.SelectedIndex = 0;
                    cboSet.Enabled = false;
                }
                else
                {
                    cboSet.Enabled = true;
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

        private void RefreshMeasureSetDef()
        {

            try
            {

                if (cboStep.SelectedIndex == -1 | cboSet.SelectedIndex == -1)
                    return;

                modGlobal.gv_sql = string.Format("select JoinOperator FROM  tbl_setup_measurecriteriaset where  MeasureCriteriaSet = {0} AND MeasureStepID in " +
                    "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep WHERE MeasureID = {1} AND MeasureStep = {2}",
                    Support.GetItemData(cboSet, cboSet.SelectedIndex), Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex), Support.GetItemData(cboStep, cboStep.SelectedIndex));

                if (Strings.InStr(cboStep.Text, "Risk") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')";
                }
                else if (Strings.InStr(cboStep.Text, "Flow") > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName27 = "tbl_setup_measurecriteriaset";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName27].Rows.Count == 0)
                {
                    cboJoinOperator.Text = "";
                    cboJoinOperator.Enabled = true;
                }
                else
                {
                    cboJoinOperator.Text = modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["JoinOperator"].ToString();
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

        private void frmMeasureCopyCriteria_FormClosing(object sender, FormClosingEventArgs e)
        {
            is_CopyType = "";
            is_SubmitCriteriaIDs = new string[1];
            is_MeasureID = "";
            is_SubGroupID = "";
        }

        //Split up the old control array
        private void rboCopyTo1_CheckStateChanged(object sender, EventArgs e)
        {
            //LDW if (eventSender.Checked)
            if (sender.Equals(rboCopyTo1.IsChecked))
            {
                cboMeasures.Enabled = false;
                cboColumns.Enabled = true;
                cboStep.Enabled = false;
            }
        }

        //Split up the old control array
        private void rboCopyTo2_CheckStateChanged(object sender, EventArgs e)
        {
            if (sender.Equals(rboCopyTo2.IsChecked))
            {
                cboMeasures.Enabled = true;
                cboColumns.Enabled = false;
                cboStep.Enabled = true;
            }
        }
    }
}
