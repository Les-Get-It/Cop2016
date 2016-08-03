using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Telerik.WinControls.UI;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmMeasureCriteriaSubmitSubs : RadForm
    {
        int MeasureID;
        int MeasureStepID;


        public frmMeasureCriteriaSubmitSubs()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void RefreshMeasureCriteria()
        {
            var lstMeasureDef = new RadListControl();
            int Index = 0;
            string ls_Suffix = null;
            string ls_Prefix = null;
            string ls_MainOp = null;
            string ls_PrevSet = null;
            int li_TotCriteriaInSet;
            int li_StepCount = 0;
            int li_CritCount;
            int li_SetCount;
            int li_TotStep;
            int li_TotSetInStep = 0;
            var rs_TotCrit = new DataSet();
            object rs_TotSetInStep = new object();
            var rs_Crit = new DataSet();
            var rs_MeasStep = new DataSet();


            //On Error GoTo ErrHandler

            try
            {
                lstMeasureDef.Items.Clear();


                modGlobal.gv_sql = "SELECT DISTINCT MeasureStep, MeasureStepID, CAT ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms, tbl_MEASURE_CAT m ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ms.Measure_CATID = m.MEASURE_CATID";
                modGlobal.gv_sql = string.Format("{0} AND ms.MeasureID = {1}", modGlobal.gv_sql, MeasureID);
                modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " AND CAT_TYPE = 'CI'";
                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC";

                //gv_g = InputBox("", "", gv_sql)
                //LDW rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_MeasureStep";
                rs_MeasStep = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, rs_MeasStep);

                //LDW if (rs_MeasStep.EOF)
                for (int itr = 0; itr < rs_MeasStep.Tables[sqlTableName1].Rows.Count; itr++)
                {
                    var myRowA = (DataRow)rs_MeasStep.Tables[sqlTableName1].Rows[itr];
                    int rowIndexA = rs_MeasStep.Tables[sqlTableName1].Rows.IndexOf(myRowA);
                    if (rowIndexA == rs_MeasStep.Tables[sqlTableName1].Rows.Count - 1)
                        return;
                }

                //LDW rs_MeasStep.MoveLast();
                li_TotStep = rs_MeasStep.Tables[sqlTableName1].Rows.Count;
                //LDW rs_MeasStep.MoveFirst();

                //STEP LOOP
                //LDW while (!rs_MeasStep.EOF)
                foreach (DataRow myRow1 in rs_MeasStep.Tables[sqlTableName1].Rows)
                {
                    li_StepCount = li_StepCount + 1;

                    ls_Suffix = "";

                    if (Index == 0 | Index == 2)
                    {
                        lstMeasureDef.Items.Add(new ListBoxItem("Step " + myRow1.Field<string>("measurestep") +
                            ": = " + myRow1.Field<string>("CAT") + " (", -1).ToString());
                    }

                    //SET QUERY
                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet mcs, tbl_Setup_MeasureStep ms ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  WHERE ms.MeasureStepID = mcs.MeasureStepID AND ms.MeasureStepID = ";
                    modGlobal.gv_sql = modGlobal.gv_sql + myRow1.Field<string>("MeasureStepID");
                    modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY mcs.MeasureCriteriaSet ASC";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_Setup_MeasureCriteriaSet";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                    //LDW if (modGlobal.gv_rs.EOF)
                    for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count; itr++)
                    {
                        var myRowB = (DataRow)modGlobal.gv_rs.Tables[sqlTableName2].Rows[itr];
                        int rowIndexB = modGlobal.gv_rs.Tables[sqlTableName2].Rows.IndexOf(myRowB);
                        if (rowIndexB == modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count - 1)
                            return;
                    }

                    //LDW modGlobal.gv_rs.MoveLast();
                    li_TotSetInStep = modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    li_SetCount = 0;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                    {
                        li_SetCount = li_SetCount + 1;

                        //will display join operator for first measurecriteriaset
                        if (Information.IsDBNull(myRow2.Field<string>("JoinOperator")) | string.IsNullOrEmpty(myRow2.Field<string>("JoinOperator")))
                        {
                            ls_MainOp = "AND";
                        }
                        else
                        {
                            ls_MainOp = myRow2.Field<string>("JoinOperator");
                        }

                        li_CritCount = 0;
                        ls_PrevSet = "";

                        modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + myRow2.Field<string>("MeasureCriteriaSetID");
                        //LDW rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName3 = "tbl_Setup_MeasureCriteria";
                        rs_Crit = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, rs_Crit);
                        //LDW if (rs_Crit.EOF)
                        for (int itr = 0; itr < rs_Crit.Tables[sqlTableName2].Rows.Count; itr++)
                        {
                            var myRowC = (DataRow)rs_Crit.Tables[sqlTableName2].Rows[itr];
                            int rowIndexC = rs_Crit.Tables[sqlTableName2].Rows.IndexOf(myRowC);
                            if (rowIndexC == rs_Crit.Tables[sqlTableName2].Rows.Count - 1)
                                return;
                        }
                        //LDW rs_Crit.MoveLast();
                        li_TotCriteriaInSet = rs_Crit.Tables[sqlTableName2].Rows.Count;
                        //LDW rs_Crit.MoveFirst();

                        //CRITERIA LOOP
                        //LDW while (!rs_Crit.EOF)
                        foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                        {
                            li_CritCount = li_CritCount + 1;

                            ls_Prefix = string.Format("Set {0}: (", myRow2.Field<string>("MeasureCriteriaSet"));

                            if (li_CritCount == li_TotCriteriaInSet)
                            {
                                if (li_TotCriteriaInSet == 1)
                                {
                                    ls_Suffix = string.Format("     ({0}) )", myRow3.Field<string>("JoinOperator"));
                                }
                                else
                                {
                                    ls_Suffix = " )  ";
                                }
                            }
                            else
                            {
                                ls_Suffix = "   " + myRow3.Field<string>("JoinOperator");
                            }

                            if (li_CritCount == 1)
                            {
                                lstMeasureDef.Items.Add(string.Format("     {0}{1}{2}", ls_Prefix, myRow3.Field<string>("CriteriaTitle"), ls_Suffix));
                            }
                            else
                            {
                                lstMeasureDef.Items.Add(string.Format("          {0}{1}", myRow3.Field<string>("CriteriaTitle"), ls_Suffix));
                            }
                            //LDW lstMeasureDef.ItemData(lstMeasureDef.Items.Count - 1) = myRow3.Field<string>("MeasureCriteriaID");
                            Support.SetItemData(lstMeasureDef, lstMeasureDef.Items.Count - 1, myRow3.Field<int>("MeasureCriteriaID"));
                            if (li_CritCount == li_TotCriteriaInSet & li_SetCount < li_TotSetInStep)
                            {
                                lstMeasureDef.Items.Add("     " + ls_MainOp);
                                //LDW lstMeasureDef.ItemData(lstMeasureDef.Items.Count - 1) = -1;
                                Support.SetItemData(lstMeasureDef, lstMeasureDef.Items.Count - 1, -1);
                            }

                            //LDW rs_Crit.MoveNext();
                        }

                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (Index == 0 | Index == 2)
                    {
                        lstMeasureDef.Items.Add(") ");
                        //LDW lstMeasureDef.ItemData(lstMeasureDef.Items.Count - 1) = -1;
                        Support.SetItemData(lstMeasureDef, lstMeasureDef.Items.Count - 1, -1);
                    }

                    modGlobal.gv_rs.Dispose();
                    //LDW rs_MeasStep.MoveNext();
                }

                rs_MeasStep.Dispose();


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

        public void RefreshMeasureCriteriaSubmitSubs()
        {
            int Index = 0;
            string ls_Suffix = null;
            string ls_Prefix = null;
            string ls_MainOp = null;
            string ls_PrevSet = null;
            int li_TotCriteriaInSet;
            int li_StepCount = 0;
            int li_CritCount;
            int li_SetCount;
            int li_TotStep;
            int li_TotSetInStep = 0;
            var rs_TotCrit = new DataSet();
            object rs_TotSetInStep = new object();
            var rs_Crit = new DataSet();

            //On Error GoTo ErrHandler

            //If lstMeasureDef.ListIndex < 0 Then
            //    MsgBox "Please select a step from verification process."
            //    Exit Sub
            //End If
            //If lstMeasureDef.ItemData(lstMeasureDef.ListIndex) = -1 Then
            //    Exit Sub
            //End If


            try
            {
                lstSubmissionDef.Items.Clear();

                DataSet rs_MeasStep = new DataSet();

                modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, msss.MeasureStepSubmitSubsID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStepSubmitSubs msss inner join tbl_Setup_MeasureStep as ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on msss.measureStepID = ms.MeasureStepID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ";
                modGlobal.gv_sql = string.Format("{0} ms.MeasureStepID =  {1}", modGlobal.gv_sql, MeasureStepID);


                //LDW rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_MeasureStepSubmitSubs";
                rs_MeasStep = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, rs_MeasStep);
                //LDW if (rs_MeasStep.EOF)
                for (int itr = 0; itr < rs_MeasStep.Tables[sqlTableName4].Rows.Count; itr++)
                {
                    var myRowD = (DataRow)rs_MeasStep.Tables[sqlTableName4].Rows[itr];
                    int rowIndexD = rs_MeasStep.Tables[sqlTableName4].Rows.IndexOf(myRowD);
                    if (rowIndexD == rs_MeasStep.Tables[sqlTableName4].Rows.Count - 1)
                        return;
                }

                //LDW rs_MeasStep.MoveLast();
                li_TotStep = rs_MeasStep.Tables[sqlTableName4].Rows.Count;
                //LDW rs_MeasStep.MoveFirst();

                //STEP LOOP
                //LDW while (!rs_MeasStep.EOF)
                foreach (DataRow myRow4 in rs_MeasStep.Tables[sqlTableName4].Rows)
                {
                    li_StepCount = li_StepCount + 1;

                    ls_Suffix = "";

                    if (Index == 0 | Index == 2)
                    {
                        lstSubmissionDef.Items.Add(new ListBoxItem("Step " + myRow4.Field<string>("measurestep") + " (", -1).ToString());
                    }

                    //SET QUERY
                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSetSubmitSubs mcs, tbl_Setup_MeasureStepSubmitSubs ms ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  WHERE ms.MeasureStepSubmitSubsID = mcs.MeasureStepSubmitSubsID AND ms.MeasureStepSubmitSubsID = ";
                    modGlobal.gv_sql = modGlobal.gv_sql + myRow4.Field<string>("MeasureStepSubmitSubsID");
                    modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY mcs.MeasureCriteriaSet ASC";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName5 = "tbl_Setup_MeasureCriteriaSetSubmitSubs";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);
                    //LDW if (modGlobal.gv_rs.EOF)
                    for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName5].Rows.Count; itr++)
                    {
                        var myRowE = (DataRow)modGlobal.gv_rs.Tables[sqlTableName5].Rows[itr];
                        int rowIndexE = modGlobal.gv_rs.Tables[sqlTableName5].Rows.IndexOf(myRowE);
                        if (rowIndexE == modGlobal.gv_rs.Tables[sqlTableName5].Rows.Count - 1)
                            return;
                    }

                    //LDW modGlobal.gv_rs.MoveLast();
                    li_TotSetInStep = modGlobal.gv_rs.Tables[sqlTableName5].Rows.Count;
                    //LDW modGlobal.gv_rs.MoveFirst();
                    li_SetCount = 0;

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                    {
                        li_SetCount = li_SetCount + 1;

                        //will display join operator for first measurecriteriaset
                        //ls_MainOp = Nz(gv_rs!JoinOperator, "AND")
                        if (Information.IsDBNull(myRow5.Field<string>("JoinOperator")) | string.IsNullOrEmpty(myRow5.Field<string>("JoinOperator")))
                        {
                            ls_MainOp = "AND";
                        }
                        else
                        {
                            ls_MainOp = myRow5.Field<string>("JoinOperator");
                        }

                        li_CritCount = 0;
                        ls_PrevSet = "";

                        modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSubmitSubs WHERE MeasureCriteriaSetSubmitSubsID = " + myRow5.Field<string>("measureCriteriaSetSubmitSubsID");
                        //LDW rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName6 = "tbl_Setup_MeasureCriteriaSubmitSubs";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                        //LDW if (rs_Crit.EOF)
                        for (int itr = 0; itr < rs_Crit.Tables[sqlTableName6].Rows.Count; itr++)
                        {
                            var myRowF = (DataRow)rs_Crit.Tables[sqlTableName6].Rows[itr];
                            int rowIndexF = rs_Crit.Tables[sqlTableName6].Rows.IndexOf(myRowF);
                            if (rowIndexF == rs_Crit.Tables[sqlTableName6].Rows.Count - 1)
                                return;
                        }
                        //LDW rs_Crit.MoveLast();
                        li_TotCriteriaInSet = rs_Crit.Tables[sqlTableName6].Rows.Count;
                        //LDW rs_Crit.MoveFirst();

                        //CRITERIA LOOP
                        //LDW while (!rs_Crit.EOF)
                        foreach (DataRow myRow6 in rs_Crit.Tables[sqlTableName6].Rows)
                        {
                            li_CritCount = li_CritCount + 1;

                            ls_Prefix = string.Format("Set {0}: (", myRow5.Field<string>("MeasureCriteriaSet"));

                            if (li_CritCount == li_TotCriteriaInSet)
                            {
                                if (li_TotCriteriaInSet == 1)
                                {
                                    ls_Suffix = string.Format("     ({0}) )", myRow6.Field<string>("JoinOperator"));
                                }
                                else
                                {
                                    ls_Suffix = " )  ";
                                }
                            }
                            else
                            {
                                ls_Suffix = "   " + myRow6.Field<string>("JoinOperator");
                            }

                            if (li_CritCount == 1)
                            {
                                lstSubmissionDef.Items.Add(string.Format("     {0}{1}{2}", ls_Prefix, myRow6.Field<string>("CriteriaTitle"), ls_Suffix));
                            }
                            else
                            {
                                lstSubmissionDef.Items.Add(string.Format("          {0}{1}", myRow6.Field<string>("CriteriaTitle"), ls_Suffix));
                            }
                            Support.SetItemData(lstSubmissionDef, lstSubmissionDef.Items.Count - 1, myRow6.Field<int>("measureCriteriaSubmitSubsID"));

                            if (li_CritCount == li_TotCriteriaInSet & li_SetCount < li_TotSetInStep)
                            {
                                lstSubmissionDef.Items.Add("     " + ls_MainOp);
                                Support.SetItemData(lstSubmissionDef, lstSubmissionDef.Items.Count - 1, -1);
                            }

                            //LDW rs_Crit.MoveNext();
                        }
                        rs_Crit.Dispose();
                        //LDW modGlobal.gv_rs.MoveNext();
                    }

                    if (Index == 0 | Index == 2)
                    {
                        lstSubmissionDef.Items.Add(new ListBoxItem(") ", -1).ToString());
                    }

                    modGlobal.gv_rs.Dispose();
                    //LDW rs_MeasStep.MoveNext();
                }

                rs_MeasStep.Dispose();


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

        public void SetupMeasureID(int mid_Renamed, string indicatordesc, int criteriaID)
        {
            int measurestep;

            try
            {

                MeasureID = mid_Renamed;
                lblIndicatorDesc.Text = indicatordesc;
                modGlobal.gv_sql = " select MeasureStepID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID , MeasureCriteriaID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStep ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureCriteriaID = {1}", modGlobal.gv_sql, criteriaID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "vuMeasureCriteriaSetStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);
                MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["MeasureStepID"]);
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = " select MeasureStep  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureStep ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, MeasureStepID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_MeasureStep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                measurestep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["measurestep"]);
                modGlobal.gv_rs.Dispose();

                lblMeasureStep.Text = " Replacement for Verification Step: " + measurestep;

                RefreshMeasureCriteriaSubmitSubs();
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

        private void cmdAddCriteria_Click(object sender, EventArgs e)
        {
            frmMeasureAddCritSubmitSubsSetup frmMeasureAddCritSubmitSubsSetupCopy = new frmMeasureAddCritSubmitSubsSetup();
            ///LDW int Index = cmdAddCriteria.GetIndex(eventSender);
            string ls_CritType = null;

            try
            {

                //frmMeasureAddCritSetup.setCritType ls_CritType
                //frmMeasureAddCritSetup.setRowCount rdcMeasureList.Resultset.RowCount
                frmMeasureAddCritSubmitSubsSetupCopy.setMeasureStepID(MeasureStepID);
                frmMeasureAddCritSubmitSubsSetupCopy.ShowDialog();
                RefreshMeasureCriteriaSubmitSubs();
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

        private void cmdChangeAddOrBetweenSets_Click(object sender, EventArgs e)
        {
            //LDW int Index = cmdChangeAddOrBetweenSets.GetIndex(eventSender);
            //On Error GoTo ErrHandler

            try
            {
                if (lstSubmissionDef.SelectedIndex == 0)
                {
                    return;
                }

                if (RadMessageBox.Show("Are you sure you want to change the join operator between all sets in this step?",
                    "Change Join Operator Between All Sets", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = "SELECT * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureCriteriaSetSubmitSubs ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepSubmitSubsID = (SELECT ms.MeasureStepSubmitSubsID FROM tbl_Setup_MeasureStepSubmitSubs ms, " +
                    "tbl_Setup_MeasureCriteriaSetSubmitSubs mcs, tbl_Setup_MeasureCriteriaSubmitSubs mc  WHERE mc.MeasureCriteriaSetSubmitSubsID = mcs.MeasureCriteriaSetSubmitSubsID " +
                    "AND mcs.MeasureStepSubmitSubsID = ms.MeasureStepSubmitSubsID AND  mc.MeasureCriteriaSubmitSubsID = {1})",
                    modGlobal.gv_sql, Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex));
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName8 = "tbl_setup_MeasureCriteriaSetSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    //LDW modGlobal.gv_rs.Edit();
                    modGlobal.gv_rs.AcceptChanges();
                    if (Information.IsDBNull(Strings.Trim(myRow8.Field<string>("JoinOperator"))) | Strings.Len(Strings.Trim(myRow8.Field<string>("JoinOperator"))) == 0)
                    {
                        //LDW modGlobal.gv_rs.rdoColumns("JoinOperator").Value = "OR";
                        myRow8.SetField("JoinOperator", "OR");
                    }
                    else
                    {
                        //LDW myRow8.Field<string>("JoinOperator") = (Strings.UCase(Strings.Trim(myRow8.Field<string>("JoinOperator"))) == "AND" ? "OR" : "AND");
                        myRow8.SetField("JoinOperator", (Strings.UCase(Strings.Trim(myRow8.Field<string>("JoinOperator"))) == "AND" ? "OR" : "AND"));
                    }
                    modGlobal.gv_rs.AcceptChanges();
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                RefreshMeasureCriteriaSubmitSubs();

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

        private void cmdChangeAndOrCond_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdChangeAndOrCond.GetIndex(eventSender);
            int li_cnt = 0;

            //On Error GoTo ErrHandler

            try
            {
                if (Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex) < 0)
                {
                    return;
                }

                for (li_cnt = 0; li_cnt <= lstSubmissionDef.Items.Count - 1; li_cnt++)
                {
                    if (lstSubmissionDef.SelectedIndex == li_cnt)
                    {
                        modGlobal.gv_sql = "Select * ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteriaSubmitSubs ";
                        modGlobal.gv_sql = string.Format("{0} Where MeasureCriteriaSubmitSubsID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSubmissionDef, li_cnt));

                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                        const string sqlTableName9 = "tbl_setup_MeasureCriteriaSubmitSubs";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);
                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                        {
                            modGlobal.gv_rs.AcceptChanges();
                            myRow9.SetField("JoinOperator", (Strings.UCase(Strings.Trim(myRow9.Field<string>("JoinOperator"))) == "AND" ? "OR" : "AND"));
                            modGlobal.gv_rs.AcceptChanges();
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                        modGlobal.gv_rs.Dispose();
                    }
                }

                RefreshMeasureCriteriaSubmitSubs();
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

        private void cmdDelCriteria_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdDelCriteria.GetIndex(eventSender);
            int li_cnt;


            try
            {
                if (lstSubmissionDef.SelectedIndex < 0)
                {
                    return;
                }

                if (lstSubmissionDef.SelectedItems.Count > 0 & Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex) > -1)
                {
                    if (RadMessageBox.Show("Are you sure you want to delete this criteria?", "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    //allow delete of multiple criteria
                    for (li_cnt = 0; li_cnt <= lstSubmissionDef.Items.Count - 1; li_cnt++)
                    {
                        if (lstSubmissionDef.SelectedIndex == li_cnt & Support.GetItemData(lstSubmissionDef, li_cnt) > 0)
                        {
                            if (Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex) == 0)
                                return;

                            //gv_sql = "select mcs.MeasureCriteriaSetSubmitSubsID , mcs.MeasureStepSubmitSubsID, mcs.MeasureCriteriaSet from " & _
                            //'        " tbl_setup_measurecriteriaSubmitSub mc, tbl_setup_measurecriteriasetSubmitSub mcs, tbl_Setup_MeasureStepSubmitSub ms where " & _
                            //'        " mc.measurecriteriasetSubmitSubsid = mcs.measurecriteriasetSubmitSubsid " & _
                            //'        " AND ms.MeasureStepSubmitSubsID = mcs.MeasureStepSubmitSubsID " & _
                            //'        " AND mc.MeasureCriteriaSubmitSubsID  = " & lstMeasureDef(Index).ItemData(li_cnt)
                            //
                            //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                            //li_MeasureCriteriaSetID = gv_rs!MeasureCriteriaSetSubmitSubsID
                            //li_MeasureStepID = gv_rs!MeasureStepSubmitSubsID
                            //li_MeasureSet = gv_rs!MeasureCriteriaSubmitSubsSet
                            //gv_rs.Close

                            modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteriaSubmitSubs ";
                            modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaSubmitSubsID = {1}", modGlobal.gv_sql, Support.GetItemData(lstSubmissionDef, li_cnt));
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                            //LDW lstSubmissionDef.SetSelected(li_cnt, false);
                            lstSubmissionDef.SelectedIndex = li_cnt;
                            lstSubmissionDef.SelectedItem.Active = false;
                        }
                    }
                }
                else
                {
                    RadMessageBox.Show("Select criteria to delete", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                }

                modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteriaSetSubmitSubs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetSubmitSubsID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCriteriaSetSubmitSubsID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs) ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " delete tbl_Setup_MeasureStepSubmitSubs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStepSubmitSubsID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureStepSubmitSubsID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteriaSetSubmitSubs) ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureCriteriaSubmitSubs();
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

        private void cmdRemoveSubmitSubsStep_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resp = RadMessageBox.Show("Are you sure you want to remove this substitution for the Verification Step in Summarization process?",
                    "Remove Substitution.", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                //LDW object vbyseno = null;
                if (resp == DialogResult.No)
                {
                    return;
                }

                modGlobal.gv_sql = " delete tbl_Setup_MeasureCriteriaSubmitSubs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetSubmitSubsID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCriteriaSetSubmitSubsID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1})", modGlobal.gv_sql, MeasureStepID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " delete tbl_Setup_MeasureCriteriaSetSubmitSubs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetSubmitSubsID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCriteriaSetSubmitSubsID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1})", modGlobal.gv_sql, MeasureStepID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "delete tbl_Setup_MeasureStepSubmitSubs ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, MeasureStepID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureCriteriaSubmitSubs();
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

        private void cmdSubmitSubsStep_Click(object sender, EventArgs e)
        {
            int newCritSetID;
            int MeasureStepSubmitSubsID;


            try
            {
                modGlobal.gv_sql = " select MeasureStepID, MeasureStepSubmitSubsID,";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetSubmitSubsID , MeasureCriteriaSubmitSubsID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
                modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, MeasureStepID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "vuMeasureCriteriaSetStepSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                //create a link to the step if it doesn't exist
                DataSet rs_critSet = new DataSet();

                if (modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count == 0)
                {
                    modGlobal.gv_sql = "insert into tbl_Setup_MeasureStepSubmitSubs (MeasureStepID) ";
                    modGlobal.gv_sql = string.Format("{0} values ({1})", modGlobal.gv_sql, MeasureStepID);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = " select MeasureStepID, MeasureStepSubmitSubsID,";
                    modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetSubmitSubsID , MeasureCriteriaSubmitSubsID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, MeasureStepID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName11 = "vuMeasureCriteriaSetStepSubmitSubs";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                    //gv_g = InputBox("", "", gv_sql)
                    MeasureStepSubmitSubsID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["MeasureStepSubmitSubsID"]);

                    //copy the sets and criteria for the subs step
                    modGlobal.gv_sql = " select MeasureCriteriaSetID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, MeasureStepID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName12 = "tbl_Setup_MeasureCriteriaSet";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                    {
                        //add the set
                        modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteriaSetSubmitSubs (";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureStepSubmitSubsID,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator) ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
                        modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, MeasureStepSubmitSubsID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaSetID = {1}", modGlobal.gv_sql, myRow12.Field<string>("MeasureCriteriaSetID"));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //find the new id
                        modGlobal.gv_sql = " select max(MeasureCriteriaSetSubmitSubsID) as newcid ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSetSubmitSubs ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureStepSubmitSubsID = {1}", modGlobal.gv_sql, MeasureStepSubmitSubsID);
                        //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName13 = "tbl_Setup_MeasureCriteriaSetSubmitSubs";
                        rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);
                        newCritSetID = Convert.ToInt32(rs_critSet.Tables[sqlTableName13].Rows[0]["newcid"]);

                        //add criteria per set
                        modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteriaSubmitSubs ( ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetSubmitSubsID ,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle ,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " State,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " RecordStatus) ";

                        modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                        modGlobal.gv_sql = string.Format("{0}{1} ,", modGlobal.gv_sql, newCritSetID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle ,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " State,";
                        modGlobal.gv_sql = modGlobal.gv_sql + " RecordStatus ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaSetID = {1}", modGlobal.gv_sql, myRow12.Field<string>("MeasureCriteriaSetID"));

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                    modGlobal.gv_rs.Dispose();

                    RefreshMeasureCriteriaSubmitSubs();
                }
                else
                {
                    RadMessageBox.Show("Substitution Step for Submission already exists for the verification step");
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

        private void frmMeasureCriteriaSubmitSubs_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMeasureCriteriaSetup frmMeasureCriteriaSetupCopy = new frmMeasureCriteriaSetup();
            frmMeasureCriteriaSetupCopy.Show();
        }

        /*LDW Not used
        private void lstMeasureDef_Click()
		{

			RefreshMeasureCriteriaSubmitSubs();

		}
        */
    }
}
