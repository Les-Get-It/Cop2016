using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmMeasureCriteriaSetup : Telerik.WinControls.UI.RadForm
    {
        int i;
        int selectedRow;
        int selectedMeasureCriteriaID;
        public DataSet rdcMeasureList = new DataSet();
        public string rdcMeasureListTable = null;
        readonly StaticLocalInitFlag static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init = new StaticLocalInitFlag();

        int static_SSTabCriteria_SelectedIndexChanged_PreviousTab;


        public frmMeasureCriteriaSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAddCriteria0_Click(object sender, EventArgs e)
        {
            frmMeasureAddCritSetup frmMeasureAddCritSetupCopy = new frmMeasureAddCritSetup();

            try
            {
                //LDW short Index = cmdAddCriteria.GetIndex(eventSender);
                const string ls_CritType = "Reg";

                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count != 0)
                {
                    frmMeasureAddCritSetupCopy.setMeasure(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetDesc"] + " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["JCAHOID"] +
                        " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);
                    frmMeasureAddCritSetupCopy.SetMeasureID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]));
                    /*LDW switch (Index)
                    {
                        case 0:
                            ls_CritType = "Reg";
                            break;
                        case 1:
                            ls_CritType = "Filter";
                            break;
                        case 2:
                            ls_CritType = "Risk";
                            break;*/

                    frmMeasureAddCritSetupCopy.setCritType(ls_CritType);
                    frmMeasureAddCritSetupCopy.setRowCount(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count));
                    frmMeasureAddCritSetupCopy.setMeasureSetID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetID"]));
                    frmMeasureAddCritSetupCopy.ShowDialog();

                    RefreshMeasureCriteria();

                    //find the most recent criteria and goto that step
                    modGlobal.gv_sql = "Select max(measurecriteriaid) as maxcriteriaid from tbl_setup_MeasureCriteria ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_setup_MeasureCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    //LDW selectedMeasureCriteriaID = modGlobal.gv_rs.rdoColumns["MaxCriteriaID"].Value;
                    selectedMeasureCriteriaID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MaxCriteriaID"]);

                    //go back to the same step
                    for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                        {
                            selectedRow = i;
                        }
                    }
                    //LDW lstMeasureDef[Index].SetSelected(selectedRow, true);
                    lstMeasureDef0.SelectedIndex = selectedRow;
                    lstMeasureDef0.SelectedItem.Active = true;
                }
                else
                {
                    //LDW RadMessageBox.Show("Please select a measure to setup.", MsgBoxStyle.Information, "No Measure Selected");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please select a measure to setup.", "No Measure Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
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

        private void cmdAddCriteria1_Click(object sender, EventArgs e)
        {
            frmMeasureAddCritSetup frmMeasureAddCritSetupCopy = new frmMeasureAddCritSetup();

            try
            {
                //LDW short Index = cmdAddCriteria.GetIndex(eventSender);
                const string ls_CritType = "Filter";

                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count != 0)
                {
                    frmMeasureAddCritSetupCopy.setMeasure(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetDesc"] + " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["JCAHOID"] +
                        " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);
                    frmMeasureAddCritSetupCopy.SetMeasureID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]));
                    /*LDW switch (Index)
                    {
                        case 0:
                            ls_CritType = "Reg";
                            break;
                        case 1:
                            ls_CritType = "Filter";
                            break;
                        case 2:
                            ls_CritType = "Risk";
                            break;*/

                    frmMeasureAddCritSetupCopy.setCritType(ls_CritType);
                    frmMeasureAddCritSetupCopy.setRowCount(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count));
                    frmMeasureAddCritSetupCopy.setMeasureSetID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetID"]));
                    frmMeasureAddCritSetupCopy.ShowDialog();

                    RefreshMeasureCriteria();

                    //find the most recent criteria and goto that step
                    modGlobal.gv_sql = "Select max(measurecriteriaid) as maxcriteriaid from tbl_setup_MeasureCriteria ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_setup_MeasureCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    //LDW selectedMeasureCriteriaID = modGlobal.gv_rs.rdoColumns["MaxCriteriaID"].Value;
                    selectedMeasureCriteriaID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MaxCriteriaID"]);

                    //go back to the same step
                    for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                        {
                            selectedRow = i;
                        }
                    }
                    //LDW lstMeasureDef[Index].SetSelected(selectedRow, true);
                    lstMeasureDef1.SelectedIndex = selectedRow;
                    lstMeasureDef1.SelectedItem.Active = true;
                }
                else
                {
                    //LDW RadMessageBox.Show("Please select a measure to setup.", MsgBoxStyle.Information, "No Measure Selected");

                    DialogResult ds2 = RadMessageBox.Show(this, "Please select a measure to setup.", "No Measure Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
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

        private void cmdAddCriteria2_Click(object sender, EventArgs e)
        {
            frmMeasureAddCritSetup frmMeasureAddCritSetupCopy = new frmMeasureAddCritSetup();

            try
            {
                //LDW short Index = cmdAddCriteria.GetIndex(eventSender);
                const string ls_CritType = "Risk";

                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count != 0)
                {
                    frmMeasureAddCritSetupCopy.setMeasure(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetDesc"] + " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["JCAHOID"] +
                        " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);
                    frmMeasureAddCritSetupCopy.SetMeasureID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]));
                    /*LDW switch (Index)
                    {
                        case 0:
                            ls_CritType = "Reg";
                            break;
                        case 1:
                            ls_CritType = "Filter";
                            break;
                        case 2:
                            ls_CritType = "Risk";
                            break;*/

                    frmMeasureAddCritSetupCopy.setCritType(ls_CritType);
                    frmMeasureAddCritSetupCopy.setRowCount(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count));
                    frmMeasureAddCritSetupCopy.setMeasureSetID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetID"]));
                    frmMeasureAddCritSetupCopy.ShowDialog();

                    RefreshMeasureCriteria();

                    //find the most recent criteria and goto that step
                    modGlobal.gv_sql = "Select max(measurecriteriaid) as maxcriteriaid from tbl_setup_MeasureCriteria ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_setup_MeasureCriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    //LDW selectedMeasureCriteriaID = modGlobal.gv_rs.rdoColumns["MaxCriteriaID"].Value;
                    selectedMeasureCriteriaID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["MaxCriteriaID"]);

                    //go back to the same step
                    for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                        {
                            selectedRow = i;
                        }
                    }
                    //LDW lstMeasureDef[Index].SetSelected(selectedRow, true);
                    lstMeasureDef0.SelectedIndex = selectedRow;
                    lstMeasureDef0.SelectedItem.Active = true;
                }
                else
                {
                    //LDW RadMessageBox.Show("Please select a measure to setup.", MsgBoxStyle.Information, "No Measure Selected");

                    DialogResult ds3 = RadMessageBox.Show(this, "Please select a measure to setup.", "No Measure Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
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

        private void cmdChangeAddOrBetweenSets_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdChangeAddOrBetweenSets.GetIndex(eventSender);
            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef0.SelectedIndex == 0)
                {
                    return;
                }


                DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to change the join operator between all sets in this step?",
                    "Change Join Operator Between All Sets", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.No)
                {
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);


                modGlobal.gv_sql = "SELECT * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureCriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = (SELECT ms.MeasureStepID FROM tbl_Setup_MeasureStep ms, " + " tbl_Setup_MeasureCriteriaSet mcs, tbl_Setup_MeasureCriteria mc " +
                    " WHERE mc.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID AND mcs.MeasureStepID = ms.MeasureStepID AND " + " mc.MeasureCriteriaID = " +
                    Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) + ")";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName2 = "tbl_setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    //LDW modGlobal.gv_rs.Edit();
                    if (Information.IsDBNull(Strings.Trim(myRow1.Field<string>("JoinOperator"))) | Strings.Len(Strings.Trim(myRow1.Field<string>("JoinOperator"))) == 0)
                    {
                        //LDW modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = "OR";
                        myRow1.SetField("JoinOperator", "OR");
                    }
                    else
                    {
                        //LDW modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == "AND" ? "OR" : "AND");
                        myRow1.SetField("JoinOperator", (Strings.UCase(Strings.Trim(myRow1.Field<string>("JoinOperator"))) == "AND" ? "OR" : "AND"));
                    }
                    //LDW modGlobal.gv_rs.Update();
                    modGlobal.gv_rs.AcceptChanges();
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                RefreshMeasureCriteria();
                //go back to the same step
                for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef[Index].SetSelected(selectedRow, true);
                lstMeasureDef0.SelectedIndex = selectedRow;
                lstMeasureDef0.SelectedItem.Active = true;

                return;
                //LDW ErrHandler:

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

        private void cmdChangeAddOrBetweenSets1_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdChangeAddOrBetweenSets.GetIndex(eventSender);
            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef2.SelectedIndex == 0)
                {
                    return;
                }


                DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to change the join operator between all sets in this step?",
                    "Change Join Operator Between All Sets", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.No)
                {
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);


                modGlobal.gv_sql = "SELECT * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureCriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = (SELECT ms.MeasureStepID FROM tbl_Setup_MeasureStep ms, " + " tbl_Setup_MeasureCriteriaSet mcs, tbl_Setup_MeasureCriteria mc " +
                    " WHERE mc.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID AND mcs.MeasureStepID = ms.MeasureStepID AND " + " mc.MeasureCriteriaID = " +
                    Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) + ")";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName2 = "tbl_setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    //LDW modGlobal.gv_rs.Edit();
                    if (Information.IsDBNull(Strings.Trim(myRow1.Field<string>("JoinOperator"))) | Strings.Len(Strings.Trim(myRow1.Field<string>("JoinOperator"))) == 0)
                    {
                        //LDW modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = "OR";
                        myRow1.SetField("JoinOperator", "OR");
                    }
                    else
                    {
                        //LDW modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == "AND" ? "OR" : "AND");
                        myRow1.SetField("JoinOperator", (Strings.UCase(Strings.Trim(myRow1.Field<string>("JoinOperator"))) == "AND" ? "OR" : "AND"));
                    }
                    //LDW modGlobal.gv_rs.Update();
                    modGlobal.gv_rs.AcceptChanges();
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                RefreshMeasureCriteria();
                //go back to the same step
                for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef[Index].SetSelected(selectedRow, true);
                lstMeasureDef2.SelectedIndex = selectedRow;
                lstMeasureDef2.SelectedItem.Active = true;

                return;
                //LDW ErrHandler:

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

        private void cmdChangeAndBetweenGroup_Click(object sender, EventArgs e)
        {
            //LDW int Index = 0;
            string JoinOperator = null;

            try
            {
                // ERROR: Not supported in C#: OnErrorStatement


                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef0.SelectedIndex < 0)
                {
                    return;
                }

                if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) < 0)
                {
                    return;
                }

                if (lstMeasureDef0.SelectedItems.Count != 1)
                {
                    //LDW RadMessageBox.Show("Please choose 1 criteria to modify");

                    DialogResult ds4 = RadMessageBox.Show(this, "Please choose 1 criteria to modify.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds4.ToString();
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                //the join operator has to be updated for the entire set
                modGlobal.gv_sql = "Select msg.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureStepGroup  msg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join vuMeasureCriteriaSetStep as mcss ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on msg.MeasureCriteriaSetID = mcss.MeasureCriteriaSetID ";
                modGlobal.gv_sql = string.Format("{0} Where mcss.MeasureCriteriaID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName5 = "tbl_Setup_MeasureStepGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);
                JoinOperator = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["JoinOperator"].ToString())) == "AND" ? "OR" : "AND");

                modGlobal.gv_sql = " update  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureStepGroup ";
                modGlobal.gv_sql = string.Format("{0} set joinoperator = '{1}'", modGlobal.gv_sql, JoinOperator);
                modGlobal.gv_sql = string.Format("{0} Where MeasureStepID = {1}", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName5].Rows[0]["MeasureStepID"]);

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                lstMeasureDef0.SelectedIndex = selectedRow;
                lstMeasureDef0.SelectedItem.Active = true;

                return;
                //LDW ErrHandler:

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

        private void cmdChangeCategoryofSet_Click(object sender, EventArgs e)
        {
            frmMeasureModifyCategory frmMeasureModifyCategoryCopy = new frmMeasureModifyCategory();

            try
            {
                //LDW short Index = cmdChangeCategoryofSet.GetIndex(eventSender);
                //LDW string ls_CAT = null;
                //LDW string ls_EditCAT = null;
                //LDW int li_MeasureStepID = 0;
                //LDW DataSet rsIsValid = new DataSet();

                // ERROR: Not supported in C#: OnErrorStatement


                if (lstMeasureDef0.SelectedItems.Count > 1 | Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) < 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria step to change the category.");

                    DialogResult ds5 = RadMessageBox.Show(this, "Select one criteria step to change the category.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds5.ToString();
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                modGlobal.gv_sql = "SELECT ms.MeasureStepID, CAT, ms.Measure_CATID FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms , tbl_MEASURE_CAT cat" +
                    " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " +
                    Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) + " AND ms.Measure_CATID = cat.MEASURE_CATID";

                EditCat:

                //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
                //ls_CAT = gv_rs!CAT


                frmMeasureModifyCategoryCopy.ShowDialog();


                //ls_EditCAT = InputBox("Edit the Set Category.", "Edit Category", ls_CAT)
                //
                // If Len(ls_EditCAT) = 0 Then Exit Sub
                //
                // gv_sql = "SELECT MEASURE_CATID FROM tbl_Measure_CAT WHERE CAT = '" & ls_EditCAT & "'"
                // If Index = 0 Then
                //     gv_sql = gv_sql & " AND CAT_TYPE = 'CI'"
                // ElseIf Index = 2 Then
                //     gv_sql = gv_sql & " AND CAT_TYPE = 'RA'"
                // End If
                //
                // Set rsIsValid = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //
                // If rsIsValid.EOF Then
                //     MsgBox "Please Enter A Valid Category", vbCritical, "Invalid Category"
                //     GoTo EditCat
                // Else
                //     gv_rs.Edit
                //     gv_rs!Measure_CATID = rsIsValid!Measure_CATID
                //     gv_rs.Update
                // End If
                //
                // gv_rs.Close
                // rsIsValid.Close

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                lstMeasureDef0.SelectedIndex = selectedRow;
                lstMeasureDef0.SelectedItem.Active = true;

                return;
                //LDW ErrHandler:

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

        private void cmdChangeCategoryofSet1_Click(object sender, EventArgs e)
        {
            frmMeasureModifyCategory frmMeasureModifyCategoryCopy = new frmMeasureModifyCategory();

            try
            {
                //LDW short Index = cmdChangeCategoryofSet.GetIndex(eventSender);
                //LDW string ls_CAT = null;
                //LDW string ls_EditCAT = null;
                //LDW int li_MeasureStepID = 0;
                //LDW DataSet rsIsValid = new DataSet();

                // ERROR: Not supported in C#: OnErrorStatement


                if (lstMeasureDef2.SelectedItems.Count > 1 | Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) < 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria step to change the category.");

                    DialogResult ds6 = RadMessageBox.Show(this, "Select one criteria step to change the category.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds6.ToString();
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                modGlobal.gv_sql = "SELECT ms.MeasureStepID, CAT, ms.Measure_CATID FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs," +
                    " tbl_setup_MeasureStep ms , tbl_MEASURE_CAT cat" + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " +
                    " AND mc.MeasureCriteriaID = " + Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) +
                    " AND ms.Measure_CATID = cat.MEASURE_CATID";

                //EditCat:

                //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
                //ls_CAT = gv_rs!CAT


                frmMeasureModifyCategoryCopy.ShowDialog();


                //ls_EditCAT = InputBox("Edit the Set Category.", "Edit Category", ls_CAT)
                //
                // If Len(ls_EditCAT) = 0 Then Exit Sub
                //
                // gv_sql = "SELECT MEASURE_CATID FROM tbl_Measure_CAT WHERE CAT = '" & ls_EditCAT & "'"
                // If Index = 0 Then
                //     gv_sql = gv_sql & " AND CAT_TYPE = 'CI'"
                // ElseIf Index = 2 Then
                //     gv_sql = gv_sql & " AND CAT_TYPE = 'RA'"
                // End If
                //
                // Set rsIsValid = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //
                // If rsIsValid.EOF Then
                //     MsgBox "Please Enter A Valid Category", vbCritical, "Invalid Category"
                //     GoTo EditCat
                // Else
                //     gv_rs.Edit
                //     gv_rs!Measure_CATID = rsIsValid!Measure_CATID
                //     gv_rs.Update
                // End If
                //
                // gv_rs.Close
                // rsIsValid.Close

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                lstMeasureDef2.SelectedIndex = selectedRow;
                lstMeasureDef2.SelectedItem.Active = true;

                return;
                //LDW ErrHandler:

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

        private void cmdCopyCriteria0_Click(object sender, EventArgs e)
        {
            frmMeasureCopyCriteria frmMeasureCopyCriteriaCopy = new frmMeasureCopyCriteria();
            //LDW short Index = cmdCopyCriteria.GetIndex(eventSender);
            string[] MeasCritIDs = null;
            int li_cnt = 0;
            int li_IDCnt = 0;

            try
            {

                if (lstMeasureDef0.SelectedItems.Count > 0)
                {
                    if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                    {
                        //LDW RadMessageBox.Show("Select one criteria set to copy.");

                        DialogResult ds7 = RadMessageBox.Show(this, "Select one criteria set to copy.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds7.ToString();
                        return;
                    }

                    li_IDCnt = 0;
                    MeasCritIDs = new string[li_IDCnt + 1];

                    selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                    for (li_cnt = 0; li_cnt <= lstMeasureDef0.Items.Count - 1; li_cnt++)
                    {
                        //LDW if (lstMeasureDef0.GetSelected(li_cnt))
                        if (lstMeasureDef0.SelectedIndex == li_cnt)
                        {
                            Array.Resize(ref MeasCritIDs, li_IDCnt + 1);
                            MeasCritIDs[li_IDCnt] = Convert.ToString(Support.GetItemData(lstMeasureDef0, li_cnt));
                            li_IDCnt = li_IDCnt + 1;
                        }
                    }

                    frmMeasureCopyCriteriaCopy.SetCopyType("M");
                    frmMeasureCopyCriteriaCopy.SetMeasureCriteriaID(MeasCritIDs);
                    frmMeasureCopyCriteriaCopy.ShowDialog();

                    //selectedMeasureCriteriaID = lstMeasureDef(Index).ItemData(lstMeasureDef(Index).ListIndex)

                    RefreshMeasureCriteria();

                    //go back to the same step
                    for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                        {
                            selectedRow = i;
                        }
                    }
                    //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                    lstMeasureDef0.SelectedIndex = selectedRow;
                    lstMeasureDef0.SelectedItem.Active = true;
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

        private void cmdCopyCriteria1_Click(object sender, EventArgs e)
        {
            frmMeasureCopyCriteria frmMeasureCopyCriteriaCopy = new frmMeasureCopyCriteria();
            //LDW short Index = cmdCopyCriteria.GetIndex(eventSender);
            string[] MeasCritIDs = null;
            int li_cnt = 0;
            int li_IDCnt = 0;

            try
            {

                if (lstMeasureDef1.SelectedItems.Count > 0)
                {
                    if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                    {
                        //LDW RadMessageBox.Show("Select one criteria set to copy.");

                        DialogResult ds8 = RadMessageBox.Show(this, "Select one criteria set to copy.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds8.ToString();
                        return;
                    }

                    li_IDCnt = 0;
                    MeasCritIDs = new string[li_IDCnt + 1];

                    selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);

                    for (li_cnt = 0; li_cnt <= lstMeasureDef1.Items.Count - 1; li_cnt++)
                    {
                        //LDW if (lstMeasureDef1.GetSelected(li_cnt))
                        if (lstMeasureDef1.SelectedIndex == li_cnt)
                        {
                            Array.Resize(ref MeasCritIDs, li_IDCnt + 1);
                            MeasCritIDs[li_IDCnt] = Convert.ToString(Support.GetItemData(lstMeasureDef1, li_cnt));
                            li_IDCnt = li_IDCnt + 1;
                        }
                    }

                    frmMeasureCopyCriteriaCopy.SetCopyType("M");
                    frmMeasureCopyCriteriaCopy.SetMeasureCriteriaID(MeasCritIDs);
                    frmMeasureCopyCriteriaCopy.ShowDialog();

                    //selectedMeasureCriteriaID = lstMeasureDef(Index).ItemData(lstMeasureDef(Index).ListIndex)

                    RefreshMeasureCriteria();

                    //go back to the same step
                    for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                        {
                            selectedRow = i;
                        }
                    }
                    //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                    lstMeasureDef1.SelectedIndex = selectedRow;
                    lstMeasureDef1.SelectedItem.Active = true;
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

        private void cmdCopyCriteria2_Click(object sender, EventArgs e)
        {
            frmMeasureCopyCriteria frmMeasureCopyCriteriaCopy = new frmMeasureCopyCriteria();
            //LDW short Index = cmdCopyCriteria.GetIndex(eventSender);
            string[] MeasCritIDs = null;
            int li_cnt = 0;
            int li_IDCnt = 0;


            try
            {
                if (lstMeasureDef2.SelectedItems.Count > 0)
                {
                    if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                    {
                        //LDW RadMessageBox.Show("Select one criteria set to copy.");

                        DialogResult ds8 = RadMessageBox.Show(this, "Select one criteria set to copy.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds8.ToString();
                        return;
                    }

                    li_IDCnt = 0;
                    MeasCritIDs = new string[li_IDCnt + 1];

                    selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                    for (li_cnt = 0; li_cnt <= lstMeasureDef2.Items.Count - 1; li_cnt++)
                    {
                        //LDW if (lstMeasureDef2.GetSelected(li_cnt))
                        if (lstMeasureDef2.SelectedIndex == li_cnt)
                        {
                            Array.Resize(ref MeasCritIDs, li_IDCnt + 1);
                            MeasCritIDs[li_IDCnt] = Convert.ToString(Support.GetItemData(lstMeasureDef2, li_cnt));
                            li_IDCnt = li_IDCnt + 1;
                        }
                    }

                    frmMeasureCopyCriteriaCopy.SetCopyType("M");
                    frmMeasureCopyCriteriaCopy.SetMeasureCriteriaID(MeasCritIDs);
                    frmMeasureCopyCriteriaCopy.ShowDialog();

                    //selectedMeasureCriteriaID = lstMeasureDef(Index).ItemData(lstMeasureDef(Index).ListIndex)

                    RefreshMeasureCriteria();

                    //go back to the same step
                    for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                        {
                            selectedRow = i;
                        }
                    }
                    //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                    lstMeasureDef2.SelectedIndex = selectedRow;
                    lstMeasureDef2.SelectedItem.Active = true;
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

        private void cmdCopyCriteriaSets_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdCopyCriteriaSets.GetIndex(eventSender);
            int li_MeasureStepID;
            int li_MeasureCriteriaSetID;
            int li_MaxSet;
            int li_NewCriteriaSetID = 0;
            string ls_JoinOp = null;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (lstMeasureDef0.SelectedItems.Count > 1 | Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) < 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria set to copy.");

                    DialogResult ds9 = RadMessageBox.Show(this, "Select one criteria set to copy.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds9.ToString();
                    return;
                }


                DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to create a new set as a copy of the selected set?",
                    "Duplicate Criteria Set", MessageBoxButtons.YesNo, RadMessageIcon.Question);


                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "select mcs.MeasureStepID, mcs.MeasureCriteriaSetID from " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs " +
                        " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND mc.MeasureCriteriaID = " +
                        Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_setup_measurecriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["MeasureStepID"]);
                    li_MeasureCriteriaSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["MeasureCriteriaSetID"]);
                    modGlobal.gv_rs.Dispose();

                    modGlobal.gv_sql = string.Format("select max(measurecriteriaset) as MaxSet from tbl_Setup_measurecriteriaset  where measurestepid = {0}", li_MeasureStepID);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName8 = "tbl_Setup_measurecriteriaset";
                    li_MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["MaxSet"]);
                    modGlobal.gv_rs.Dispose();

                    //SH - added 7.28.04 to get first join operator and base all successive ones off that one
                    // was just putting 'AND' in
                    if (li_MaxSet > 0)
                    {
                        modGlobal.gv_sql = string.Format("SELECT JoinOperator FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = {0} AND MeasureCriteriaSet = 1", li_MeasureStepID);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName9 = "tbl_Setup_MeasureCriteriaSet";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);
                        ls_JoinOp = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"].ToString();
                        modGlobal.gv_rs.Dispose();
                    }
                    else
                    {
                        ls_JoinOp = "AND   ";
                    }

                    //insert new set record
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaSet " + " (MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES (" +
                        li_MaxSet + 1 + ", " + li_MeasureStepID + ", '" + ls_JoinOp + "')";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    const string refTbl1 = "tbl_Setup_MeasureCriteriaSet";
                    li_NewCriteriaSetID = modGlobal.GetLastID(refTbl1);

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
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_NewCriteriaSetID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaSetID = {1}", modGlobal.gv_sql, li_MeasureCriteriaSetID);

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " + " SELECT " +
                        li_MeasureStepID + ", " + li_NewCriteriaSetID + ", MeasureStepGroup, JoinOperator FROM " + " tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + li_MeasureCriteriaSetID;
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                RefreshMeasureCriteria();

                //find the most recent criteria and goto that step
                modGlobal.gv_sql = "Select max(measurecriteriaid) as maxcriteriaid from tbl_setup_MeasureCriteria ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                selectedMeasureCriteriaID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["MaxCriteriaID"]);

                //go back to the same step
                for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                lstMeasureDef0.SelectedIndex = selectedRow;
                lstMeasureDef0.SelectedItem.Active = true;

                return;
                //LDW ErrHandler:

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

        private void cmdCopyCriteriaSets1_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdCopyCriteriaSets.GetIndex(eventSender);
            int li_MeasureStepID;
            int li_MeasureCriteriaSetID;
            int li_MaxSet;
            int li_NewCriteriaSetID = 0;
            string ls_JoinOp = null;

            // ERROR: Not supported in C#: OnErrorStatement


            try
            {
                if (lstMeasureDef2.SelectedItems.Count > 1 | Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) < 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria set to copy.");

                    DialogResult ds10 = RadMessageBox.Show(this, "Select one criteria set to copy.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds10.ToString();
                    return;
                }


                DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to create a new set as a copy of the selected set?",
                    "Duplicate Criteria Set", MessageBoxButtons.YesNo, RadMessageIcon.Question);


                if (resp == DialogResult.Yes)
                {
                    modGlobal.gv_sql = "select mcs.MeasureStepID, mcs.MeasureCriteriaSetID from " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs " +
                        " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND mc.MeasureCriteriaID = " +
                        Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName7 = "tbl_setup_measurecriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                    li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["MeasureStepID"]);
                    li_MeasureCriteriaSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName7].Rows[0]["MeasureCriteriaSetID"]);
                    modGlobal.gv_rs.Dispose();

                    modGlobal.gv_sql = string.Format("select max(measurecriteriaset) as MaxSet from tbl_Setup_measurecriteriaset  where measurestepid = {0}", li_MeasureStepID);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName8 = "tbl_Setup_measurecriteriaset";
                    li_MaxSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName8].Rows[0]["MaxSet"]);
                    modGlobal.gv_rs.Dispose();

                    //SH - added 7.28.04 to get first join operator and base all successive ones off that one
                    // was just putting 'AND' in
                    if (li_MaxSet > 0)
                    {
                        modGlobal.gv_sql = string.Format("SELECT JoinOperator FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = {0} AND MeasureCriteriaSet = 1", li_MeasureStepID);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName9 = "tbl_Setup_MeasureCriteriaSet";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);
                        ls_JoinOp = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"].ToString();
                        modGlobal.gv_rs.Dispose();
                    }
                    else
                    {
                        ls_JoinOp = "AND   ";
                    }

                    //insert new set record
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaSet " + " (MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES (" +
                        li_MaxSet + 1 + ", " + li_MeasureStepID + ", '" + ls_JoinOp + "')";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    const string refTbl1 = "tbl_Setup_MeasureCriteriaSet";
                    li_NewCriteriaSetID = modGlobal.GetLastID(refTbl1);

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
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                    modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, li_NewCriteriaSetID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                    modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaSetID = {1}", modGlobal.gv_sql, li_MeasureCriteriaSetID);

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " + " SELECT " +
                        li_MeasureStepID + ", " + li_NewCriteriaSetID + ", MeasureStepGroup, JoinOperator FROM " + " tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + li_MeasureCriteriaSetID;
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                RefreshMeasureCriteria();

                //find the most recent criteria and goto that step
                modGlobal.gv_sql = "Select max(measurecriteriaid) as maxcriteriaid from tbl_setup_MeasureCriteria ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                selectedMeasureCriteriaID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["MaxCriteriaID"]);

                //go back to the same step
                for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                lstMeasureDef2.SelectedIndex = selectedRow;
                lstMeasureDef2.SelectedItem.Active = true;

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

        private void cmdCopyCriteriaSteps_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdCopyCriteriaSteps.GetIndex(eventSender);
            int li_NewCriteriaSetID;
            int li_MeasureID;
            int li_MaxStep;
            int li_NewStepID;
            int li_CatID = 0;
            int li_MeasureStepID = 0;
            int li_GoToStep;
            int li_IsRisk = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (lstMeasureDef0.SelectedItems.Count > 1 | Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) < 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria step to copy.");

                    DialogResult ds11 = RadMessageBox.Show(this, "Select one criteria step to copy.", "No Criteria Step Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds11.ToString();
                    return;
                }


                DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to create a new step as a copy of the selected step?",
                    "Duplicate Criteria Step", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                    modGlobal.gv_sql = "SELECT ms.MeasureID, ms.MeasureStepID, ms.Measure_CATID, ms.gotostep, ms.IsRisk FROM " +
                        " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " +
                        " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " +
                        Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName11 = "tbl_setup_measurecriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                    li_MeasureID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["MeasureID"]);

                    li_CatID = 0;
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["measure_catid"]))
                    {
                        li_CatID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["measure_catid"]);
                    }

                    li_GoToStep = 0;
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["GoToStep"]))
                    {
                        li_GoToStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["GoToStep"]);
                    }

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["isrisk"]))
                    {
                        li_IsRisk = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["isrisk"]);
                    }


                    li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["MeasureStepID"]);
                    modGlobal.gv_rs.Dispose();

                    modGlobal.gv_sql = "select max(MeasureStep) as MaxStep from tbl_Setup_MeasureStep as ms ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT as mc ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MEASURE_CATID = mc.MEASURE_CATID ";
                    modGlobal.gv_sql = string.Format("{0} where MeasureStep <> -100 and MeasureID = {1}", modGlobal.gv_sql, li_MeasureID);

                    //If Index = 0 Then
                    //    gv_sql = gv_sql & " and (Cat_Type is null or CAT_TYPE = 'CI')"
                    //ElseIf Index = 2 Then
                    //    gv_sql = gv_sql & " AND CAT_TYPE = 'RA'"
                    //End If

                    /*LDW if (Index == 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0)";
                    }
                    else if (Index == 2)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' or IsRisk = 1)";
                    } */
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0)";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName12 = "tbl_Setup_MeasureStep";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                    li_MaxStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName12].Rows[0]["MaxStep"]);
                    modGlobal.gv_rs.Dispose();

                    //insert new step record
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureID, MeasureStep, Measure_CATID, GoToStep, IsRisk ) VALUES ";
                    modGlobal.gv_sql = string.Format("{0} ({1}, ", modGlobal.gv_sql, li_MeasureID);
                    modGlobal.gv_sql = modGlobal.gv_sql + li_MaxStep + 1 + ", ";
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

                    modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, li_IsRisk);

                    modGlobal.gv_sql = modGlobal.gv_sql + ")";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    li_NewStepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

                    //insert new set record
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_measureCriteriaSet (MeasureCriteriaSet, MeasureStepID, JoinOperator) ";
                    modGlobal.gv_sql = string.Format("{0}  SELECT MeasureCriteriaSet, {1}", modGlobal.gv_sql, li_NewStepID);
                    modGlobal.gv_sql = modGlobal.gv_sql + "  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + ", JoinOperator ";
                    modGlobal.gv_sql = string.Format("{0}  FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = {1}", modGlobal.gv_sql, li_MeasureStepID);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureCriteriaSet  WHERE MeasureStepID = {0}", li_NewStepID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTalbeName13 = "tbl_Setup_MeasureCriteriaSet";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTalbeName13, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTalbeName13].Rows)
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
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, myRow2.Field<int>("MeasureCriteriaSetID"));
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
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetID = (SELECT MeasureCriteriaSetID " + " FROM tbl_setup_MeasureCriteriaSet WHERE MeasureStepID = " +
                            li_MeasureStepID + " AND MeasureCriteriaSet = " + myRow2.Field<string>("MeasureCriteriaSet") + ")";
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " + " SELECT " + li_NewStepID +
                            ", " + myRow2.Field<int>("MeasureCriteriaSetID") + ", MeasureStepGroup, JoinOperator FROM " +
                            " tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = (SELECT MeasureCriteriaSetID " + " FROM tbl_setup_MeasureCriteriaSet WHERE MeasureStepID = " +
                            li_MeasureStepID + " AND MeasureCriteriaSet = " + myRow2.Field<string>("MeasureCriteriaSet") + ")";
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                modGlobal.gv_rs.Dispose();

                //selectedMeasureCriteriaID = lstMeasureDef(Index).ItemData(lstMeasureDef(Index).ListIndex)

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                lstMeasureDef0.SelectedIndex = selectedRow;
                lstMeasureDef0.SelectedItem.Active = true;

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

        private void cmdCopyCriteriaSteps1_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdCopyCriteriaSteps.GetIndex(eventSender);
            int li_NewCriteriaSetID;
            int li_MeasureID;
            int li_MaxStep;
            int li_NewStepID;
            int li_CatID = 0;
            int li_MeasureStepID = 0;
            int li_GoToStep;
            int li_IsRisk = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (lstMeasureDef2.SelectedItems.Count > 1 | Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) < 0)
                {
                    //LDW RadMessageBox.Show("Select one criteria step to copy.");

                    DialogResult ds12 = RadMessageBox.Show(this, "Select one criteria step to copy.", "No Criteria Step Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds12.ToString();
                    return;
                }


                DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to create a new step as a copy of the selected step?",
                    "Duplicate Criteria Step", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                    modGlobal.gv_sql = "SELECT ms.MeasureID, ms.MeasureStepID, ms.Measure_CATID, ms.gotostep, ms.IsRisk FROM " +
                        " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " +
                        " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " +
                        Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName11 = "tbl_setup_measurecriteria";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);
                    li_MeasureID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["MeasureID"]);

                    li_CatID = 0;
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["measure_catid"]))
                    {
                        li_CatID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["measure_catid"]);
                    }

                    li_GoToStep = 0;
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["GoToStep"]))
                    {
                        li_GoToStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["GoToStep"]);
                    }

                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["isrisk"]))
                    {
                        li_IsRisk = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["isrisk"]);
                    }


                    li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["MeasureStepID"]);
                    modGlobal.gv_rs.Dispose();

                    modGlobal.gv_sql = "select max(MeasureStep) as MaxStep from tbl_Setup_MeasureStep as ms ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT as mc ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MEASURE_CATID = mc.MEASURE_CATID ";
                    modGlobal.gv_sql = string.Format("{0} where MeasureStep <> -100 and MeasureID = {1}", modGlobal.gv_sql, li_MeasureID);

                    //If Index = 0 Then
                    //    gv_sql = gv_sql & " and (Cat_Type is null or CAT_TYPE = 'CI')"
                    //ElseIf Index = 2 Then
                    //    gv_sql = gv_sql & " AND CAT_TYPE = 'RA'"
                    //End If

                    /*LDW if (Index == 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0)";
                    }
                    else if (Index == 2)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' or IsRisk = 1)";
                    } */
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' or IsRisk = 1)";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName12 = "tbl_Setup_MeasureStep";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                    li_MaxStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName12].Rows[0]["MaxStep"]);
                    modGlobal.gv_rs.Dispose();

                    //insert new step record
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureID, MeasureStep, Measure_CATID, GoToStep, IsRisk ) VALUES ";
                    modGlobal.gv_sql = string.Format("{0} ({1}, ", modGlobal.gv_sql, li_MeasureID);
                    modGlobal.gv_sql = modGlobal.gv_sql + li_MaxStep + 1 + ", ";
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

                    modGlobal.gv_sql = string.Format("{0},{1}", modGlobal.gv_sql, li_IsRisk);

                    modGlobal.gv_sql = modGlobal.gv_sql + ")";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    li_NewStepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

                    //insert new set record
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_measureCriteriaSet (MeasureCriteriaSet, MeasureStepID, JoinOperator) ";
                    modGlobal.gv_sql = string.Format("{0}  SELECT MeasureCriteriaSet, {1}", modGlobal.gv_sql, li_NewStepID);
                    modGlobal.gv_sql = modGlobal.gv_sql + "  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + ", JoinOperator ";
                    modGlobal.gv_sql = string.Format("{0}  FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = {1}", modGlobal.gv_sql, li_MeasureStepID);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureCriteriaSet  WHERE MeasureStepID = {0}", li_NewStepID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTalbeName13 = "tbl_Setup_MeasureCriteriaSet";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTalbeName13, modGlobal.gv_rs);

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTalbeName13].Rows)
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
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, myRow2.Field<int>("MeasureCriteriaSetID"));
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
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetID = (SELECT MeasureCriteriaSetID " +
                            " FROM tbl_setup_MeasureCriteriaSet WHERE MeasureStepID = " +
                            li_MeasureStepID + " AND MeasureCriteriaSet = " + myRow2.Field<string>("MeasureCriteriaSet") + ")";
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " +
                            " SELECT " + li_NewStepID + ", " + myRow2.Field<int>("MeasureCriteriaSetID") + ", MeasureStepGroup, JoinOperator FROM " +
                            " tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = (SELECT MeasureCriteriaSetID " + " FROM tbl_setup_MeasureCriteriaSet WHERE MeasureStepID = " +
                            li_MeasureStepID + " AND MeasureCriteriaSet = " + myRow2.Field<string>("MeasureCriteriaSet") + ")";
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }
                modGlobal.gv_rs.Dispose();

                //selectedMeasureCriteriaID = lstMeasureDef(Index).ItemData(lstMeasureDef(Index).ListIndex)

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                lstMeasureDef2.SelectedIndex = selectedRow;
                lstMeasureDef2.SelectedItem.Active = true;

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

        private void cmdDelCriteria0_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdDelCriteria.GetIndex(eventSender);
            int li_MeasureCriteriaSetID;
            int li_MeasureStepID = 0;
            int li_MeasureSet;
            int li_MeasureStep;
            int li_cnt = 0;


            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef0.SelectedItems.Count > 0 & Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) > -1)
                {

                    DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to delete this criteria?",
                   "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (resp == DialogResult.No)
                    {
                        return;
                    }

                    //allow delete of multiple criteria
                    for (li_cnt = 0; li_cnt <= lstMeasureDef0.Items.Count - 1; li_cnt++)
                    {
                        if (lstMeasureDef0.SelectedIndex == li_cnt & Support.GetItemData(lstMeasureDef0, li_cnt) > 0)
                        {
                            if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == 0)
                                return;

                            modGlobal.gv_sql = "select mcs.MeasureCriteriaSetID , mcs.MeasureStepID, mcs.MeasureCriteriaSet, ms.MeasureStep from " +
                                " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_Setup_MeasureStep ms where " +
                                " mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " +
                                " AND mc.MeasureCriteriaID  = " + Support.GetItemData(lstMeasureDef0, li_cnt);

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName14 = "tbl_setup_measurecriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                            li_MeasureCriteriaSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureCriteriaSetID"]);
                            li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureStepID"]);
                            li_MeasureSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureCriteriaSet"]);
                            li_MeasureStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["measurestep"]);
                            modGlobal.gv_rs.Dispose();

                            modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteria ";
                            modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef0, li_cnt));
                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            ResetMeasureStepOrder(li_MeasureCriteriaSetID.ToString(), Convert.ToString(li_MeasureStepID), li_MeasureSet.ToString(), li_MeasureStep.ToString());
                            //LDW lstMeasureDef0.SetSelected(li_cnt, false);
                            lstMeasureDef0.SelectedIndex = selectedRow;
                            lstMeasureDef0.SelectedItem.Active = true;
                        }
                    }
                }
                else
                {
                    //LDW RadMessageBox.Show("Select criteria to delete", MsgBoxStyle.Critical, "No Criteria Selected");

                    DialogResult ds13 = RadMessageBox.Show(this, "Select criteria to delete.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds13.ToString();
                }

                RefreshMeasureCriteria();
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

        private void cmdDelCriteria1_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdDelCriteria.GetIndex(eventSender);
            int li_MeasureCriteriaSetID;
            int li_MeasureStepID = 0;
            int li_MeasureSet;
            int li_MeasureStep;
            int li_cnt = 0;


            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef1.SelectedItems.Count > 0 & Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) > -1)
                {

                    DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to delete this criteria?",
                   "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                    if (resp == DialogResult.No)
                    {
                        return;
                    }

                    //allow delete of multiple criteria
                    for (li_cnt = 0; li_cnt <= lstMeasureDef1.Items.Count - 1; li_cnt++)
                    {
                        if (lstMeasureDef1.SelectedIndex == li_cnt & Support.GetItemData(lstMeasureDef1, li_cnt) > 0)
                        {
                            if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == 0)
                                return;

                            modGlobal.gv_sql = "select mcs.MeasureCriteriaSetID , mcs.MeasureStepID, mcs.MeasureCriteriaSet, ms.MeasureStep from " +
                                " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_Setup_MeasureStep ms where " +
                                " mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " +
                                " AND mc.MeasureCriteriaID  = " + Support.GetItemData(lstMeasureDef1, li_cnt);

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName14 = "tbl_setup_measurecriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                            li_MeasureCriteriaSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureCriteriaSetID"]);
                            li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureStepID"]);
                            li_MeasureSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureCriteriaSet"]);
                            li_MeasureStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["measurestep"]);
                            modGlobal.gv_rs.Dispose();

                            modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteria ";
                            modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef1, li_cnt));
                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            ResetMeasureStepOrder(li_MeasureCriteriaSetID.ToString(), Convert.ToString(li_MeasureStepID), li_MeasureSet.ToString(), li_MeasureStep.ToString());
                            //LDW lstMeasureDef1.SetSelected(li_cnt, false);
                            lstMeasureDef1.SelectedIndex = selectedRow;
                            lstMeasureDef1.SelectedItem.Active = true;
                        }
                    }
                }
                else
                {
                    //LDW RadMessageBox.Show("Select criteria to delete", MsgBoxStyle.Critical, "No Criteria Selected");
                    DialogResult ds13 = RadMessageBox.Show(this, "Select criteria to delete.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds13.ToString();
                }

                RefreshMeasureCriteria();
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

        private void cmdDelCriteria2_Click(object sender, EventArgs e)
        {
            //LDW short Index = cmdDelCriteria.GetIndex(eventSender);
            int li_MeasureCriteriaSetID;
            int li_MeasureStepID = 0;
            int li_MeasureSet;
            int li_MeasureStep;
            int li_cnt = 0;


            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef2.SelectedItems.Count > 0 & Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) > -1)
                {
                    DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to delete this criteria?",
                   "Delete Criteria", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (resp == DialogResult.No)
                    {
                        return;
                    }

                    //allow delete of multiple criteria
                    for (li_cnt = 0; li_cnt <= lstMeasureDef2.Items.Count - 1; li_cnt++)
                    {
                        if (lstMeasureDef2.SelectedIndex == li_cnt & Support.GetItemData(lstMeasureDef2, li_cnt) > 0)
                        {
                            if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == 0)
                                return;

                            modGlobal.gv_sql = "select mcs.MeasureCriteriaSetID , mcs.MeasureStepID, mcs.MeasureCriteriaSet, ms.MeasureStep from " +
                                " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_Setup_MeasureStep ms where " +
                                " mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " +
                                " AND mc.MeasureCriteriaID  = " + Support.GetItemData(lstMeasureDef2, li_cnt);

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName14 = "tbl_setup_measurecriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                            li_MeasureCriteriaSetID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureCriteriaSetID"]);
                            li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureStepID"]);
                            li_MeasureSet = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["MeasureCriteriaSet"]);
                            li_MeasureStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName14].Rows[0]["measurestep"]);
                            modGlobal.gv_rs.Dispose();

                            modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteria ";
                            modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef2, li_cnt));
                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            ResetMeasureStepOrder(li_MeasureCriteriaSetID.ToString(), Convert.ToString(li_MeasureStepID), li_MeasureSet.ToString(), li_MeasureStep.ToString());
                            //LDW lstMeasureDef2.SetSelected(li_cnt, false);
                            lstMeasureDef2.SelectedIndex = selectedRow;
                            lstMeasureDef2.SelectedItem.Active = true;
                        }
                    }
                }
                else
                {
                    //LDW RadMessageBox.Show("Select criteria to delete", MsgBoxStyle.Critical, "No Criteria Selected");

                    DialogResult ds14 = RadMessageBox.Show(this, "Select criteria to delete.", "No Criteria Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds14.ToString();
                }

                RefreshMeasureCriteria();
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

        private void cmdDupMeasure_Click(object sender, EventArgs e)
        {
            frmMeasureCopyCriteria frmMeasureCopyCriteriaCopy = new frmMeasureCopyCriteria();
            //LDW int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;

            try
            {
                //If lstMeasureDef(Index).SelCount > 0 Then

                frmMeasureCopyCriteriaCopy.SetCopyType("M");
                frmMeasureCopyCriteriaCopy.SetMeasureID(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"].ToString());
                frmMeasureCopyCriteriaCopy.ShowDialog();
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

        private void cmdGoToStep_Click(object sender, EventArgs e)
        {
            string GoToThisStep = null;
            int selectedRow = 1;
            var i = 0;
            //LDW int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;


            try
            {
                switch (Index)
                {
                    case 1:
                        if (lstMeasureDef1.Items.Count == 0)
                        {
                            return;
                        }

                        //LDW GoToThisStep = RadInputBox.Show("Type in the step you want to highlight:", "Go To...", "");
                        GoToThisStep = RadInputBox.Show("Type in the step you want to highlight:", "Go To...", "");
                        if (string.IsNullOrEmpty(GoToThisStep) | Information.IsDBNull(GoToThisStep))
                        {
                            return;
                        }

                        for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                        {
                            if (Strings.Mid(Support.GetItemString(lstMeasureDef1, i), 1, 5 + Strings.Len(GoToThisStep)) == "Step " + GoToThisStep)
                            {
                                selectedRow = i;
                            }
                        }

                        //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                        lstMeasureDef1.SelectedIndex = selectedRow;
                        lstMeasureDef1.SelectedItem.Active = true;

                        break;

                    case 2:
                        if (lstMeasureDef2.Items.Count == 0)
                        {
                            return;
                        }

                        //LDW GoToThisStep = RadInputBox.Show("Type in the step you want to highlight:", "Go To...", "");
                        GoToThisStep = RadInputBox.Show("Type in the step you want to highlight:", "Go To...", "");

                        if (string.IsNullOrEmpty(GoToThisStep) | Information.IsDBNull(GoToThisStep))
                        {
                            return;
                        }

                        for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                        {
                            if (Strings.Mid(Support.GetItemString(lstMeasureDef2, i), 1, 5 +
                                Strings.Len(GoToThisStep)) == "Step " + GoToThisStep)
                            {
                                selectedRow = i;
                            }
                        }

                        //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                        lstMeasureDef2.SelectedIndex = selectedRow;
                        lstMeasureDef2.SelectedItem.Active = true;

                        break;

                    default:
                        if (lstMeasureDef0.Items.Count == 0)
                        {
                            return;
                        }

                        //LDW GoToThisStep = RadInputBox.Show("Type in the step you want to highlight:", "Go To...", "");
                        GoToThisStep = RadInputBox.Show("Type in the step you want to highlight:", "Go To...", "");

                        if (string.IsNullOrEmpty(GoToThisStep) | Information.IsDBNull(GoToThisStep))
                        {
                            return;
                        }

                        for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                        {
                            if (Strings.Mid(Support.GetItemString(lstMeasureDef0, i), 1, 5 +
                                Strings.Len(GoToThisStep)) == "Step " + GoToThisStep)
                            {
                                selectedRow = i;
                            }
                        }

                        //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                        lstMeasureDef0.SelectedIndex = selectedRow;
                        lstMeasureDef0.SelectedItem.Active = true;

                        break;
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

        private void cmdGroupStep_Click(object sender, EventArgs e)
        {
            frmMeasureAddCritGroup frmMeasureAddCritGroupCopy = new frmMeasureAddCritGroup();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;


            try
            {
                switch (Index)
                {
                    case 1:
                        if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) < 0 | lstMeasureDef1.SelectedItems.Count > 1)
                        {

                            DialogResult dsa = RadMessageBox.Show(this, "Select one criteria in step to group step.",
                                "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsa.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);

                        frmMeasureAddCritGroupCopy.SetDescription(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetDesc"] + " / " +
                            rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["JCAHOID"] + " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);
                        frmMeasureAddCritGroupCopy.SetMeasureCriteriaID((Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex)));
                        frmMeasureAddCritGroupCopy.ShowDialog();

                        RefreshMeasureCriteria();


                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                        lstMeasureDef1.SelectedIndex = selectedRow;
                        lstMeasureDef1.SelectedItem.Active = true;

                        break;

                    case 2:
                        if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) < 0 | lstMeasureDef2.SelectedItems.Count > 1)
                        {

                            DialogResult dsb = RadMessageBox.Show(this, "Select one criteria in step to group step.",
                                "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsb.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                        frmMeasureAddCritGroupCopy.SetDescription(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetDesc"] + " / " +
                            rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["JCAHOID"] + " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);
                        frmMeasureAddCritGroupCopy.SetMeasureCriteriaID((Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex)));
                        frmMeasureAddCritGroupCopy.ShowDialog();

                        RefreshMeasureCriteria();


                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                        lstMeasureDef2.SelectedIndex = selectedRow;
                        lstMeasureDef2.SelectedItem.Active = true;

                        break;

                    default:
                        if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) < 0 | lstMeasureDef0.SelectedItems.Count > 1)
                        {

                            DialogResult dsc = RadMessageBox.Show(this, "Select one criteria in step to group step.",
                                "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsc.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                        frmMeasureAddCritGroupCopy.SetDescription(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetDesc"] + " / " +
                            rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["JCAHOID"] + " / " + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);
                        frmMeasureAddCritGroupCopy.SetMeasureCriteriaID((Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex)));
                        frmMeasureAddCritGroupCopy.ShowDialog();

                        RefreshMeasureCriteria();


                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                        lstMeasureDef0.SelectedIndex = selectedRow;
                        lstMeasureDef0.SelectedItem.Active = true;

                        break;
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

        private void cmdModifyCriteriaField_Click(object sender, EventArgs e)
        {
            dlgField dlgFieldCopy = new dlgField();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;


            try
            {
                switch (Index)
                {
                    case 1:
                        if (lstMeasureDef1.SelectedItems.Count != 1)
                        {
                            DialogResult dsd = RadMessageBox.Show(this, "Please choose 1 criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsd.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                        {
                            DialogResult dse = RadMessageBox.Show(this, "Please choose a criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dse.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);

                        dlgFieldCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                        dlgFieldCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                        lstMeasureDef1.SelectedIndex = selectedRow;
                        lstMeasureDef1.SelectedItem.Active = true;

                        break;

                    case 2:
                        if (lstMeasureDef2.SelectedItems.Count != 1)
                        {
                            DialogResult dsf = RadMessageBox.Show(this, "Please choose 1 criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsf.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                        {
                            DialogResult dsg = RadMessageBox.Show(this, "Please choose a criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsg.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                        dlgFieldCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));
                        dlgFieldCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                        lstMeasureDef2.SelectedIndex = selectedRow;
                        lstMeasureDef2.SelectedItem.Active = true;

                        break;

                    default:
                        if (lstMeasureDef0.SelectedItems.Count != 1)
                        {
                            DialogResult dsh = RadMessageBox.Show(this, "Please choose 1 criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsh.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                        {
                            DialogResult dsi = RadMessageBox.Show(this, "Please choose a criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsi.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                        dlgFieldCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));
                        dlgFieldCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                        lstMeasureDef0.SelectedIndex = selectedRow;
                        lstMeasureDef0.SelectedItem.Active = true;

                        break;
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

        private void cmdModifyCriteriaOperator_Click(object sender, EventArgs e)
        {
            frmMeasureModifyOperator frmMeasureModifyOperatorCopy = new frmMeasureModifyOperator();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int selectedMeasureCriteriaID;

            try
            {
                switch (Index)
                {
                    case 1:
                        if (lstMeasureDef1.SelectedItems.Count != 1)
                        {
                            DialogResult dsj = RadMessageBox.Show(this, "Please choose 1 criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsj.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                        {
                            DialogResult dsk = RadMessageBox.Show(this, "Please choose a criteria to modify.", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsk.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);

                        modGlobal.gv_sql = "select * from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql,
                            Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName16 = "tbl_Setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                        if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName16].Rows[0]["ValueOperator"]))
                        {
                            DialogResult dsl = RadMessageBox.Show(this, "The operator for this type of criteria cannot be modified.",
                                "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsl.ToString();
                            return;
                        }

                        frmMeasureModifyOperatorCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                        frmMeasureModifyOperatorCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                        lstMeasureDef1.SelectedIndex = selectedRow;
                        lstMeasureDef1.SelectedItem.Active = true;

                        break;

                    case 2:
                        if (lstMeasureDef2.SelectedItems.Count != 1)
                        {
                            DialogResult dsm = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsm.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                        {
                            DialogResult dsn = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsn.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                        modGlobal.gv_sql = "select * from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName17 = "tbl_Setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                        if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName17].Rows[0]["ValueOperator"]))
                        {
                            RadInputBox.Show("The operator for this type of criteria cannot be modified", "", "");

                            DialogResult dso = RadMessageBox.Show(this, "The operator for this type of criteria cannot be modified", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dso.ToString();
                            return;
                        }

                        frmMeasureModifyOperatorCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));
                        frmMeasureModifyOperatorCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                        lstMeasureDef2.SelectedIndex = selectedRow;
                        lstMeasureDef2.SelectedItem.Active = true;

                        break;

                    default:
                        if (lstMeasureDef1.SelectedItems.Count != 1)
                        {
                            RadInputBox.Show("Please choose 1 criteria to modify", "Criteria Selection", "");

                            DialogResult dsp = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsp.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                        {
                            DialogResult dsq = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsq.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);

                        modGlobal.gv_sql = "select * from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName18 = "tbl_Setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                        if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName18].Rows[0]["ValueOperator"]))
                        {
                            RadInputBox.Show("The operator for this type of criteria cannot be modified", "", "");

                            DialogResult dsr = RadMessageBox.Show(this, "The operator for this type of criteria cannot be modified", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsr.ToString();
                            return;
                        }
                        frmMeasureModifyOperatorCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                        frmMeasureModifyOperatorCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                        lstMeasureDef1.SelectedIndex = selectedRow;
                        lstMeasureDef1.SelectedItem.Active = true;

                        break;
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

        private void cmdModifyCriteriaSecondField_Click(object sender, EventArgs e)
        {
            frmMeasureModifySecondField frmMeasureModifySecondFieldCopy = new frmMeasureModifySecondField();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;


            try
            {
                switch (Index)
                {
                    case 1:
                        if (lstMeasureDef1.SelectedItems.Count != 1)
                        {
                            DialogResult dst = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dst.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                        {
                            DialogResult dsu = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsu.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);

                        modGlobal.gv_sql = "Select * from tbl_setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID = {1}", modGlobal.gv_sql, selectedMeasureCriteriaID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and DDID2 is not null ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName19 = "tbl_setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                        if (modGlobal.gv_rs.Tables[sqlTableName19].Rows.Count == 0)
                        {
                            DialogResult dsv = RadMessageBox.Show(this, "This feature does not apply to the selected criteria.",
                                "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsv.ToString();
                            return;
                        }

                        frmMeasureModifySecondFieldCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                        frmMeasureModifySecondFieldCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                        lstMeasureDef1.SelectedIndex = selectedRow;
                        lstMeasureDef1.SelectedItem.Active = true;

                        break;

                    case 2:
                        if (lstMeasureDef2.SelectedItems.Count != 1)
                        {
                            DialogResult dst = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dst.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                        {
                            DialogResult dsu = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsu.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                        modGlobal.gv_sql = "Select * from tbl_setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID = {1}", modGlobal.gv_sql, selectedMeasureCriteriaID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and DDID2 is not null ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName20 = "tbl_setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                        if (modGlobal.gv_rs.Tables[sqlTableName20].Rows.Count == 0)
                        {
                            DialogResult dsv = RadMessageBox.Show(this, "This feature does not apply to the selected criteria.",
                                "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsv.ToString();
                            return;
                        }

                        frmMeasureModifySecondFieldCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));
                        frmMeasureModifySecondFieldCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                        lstMeasureDef2.SelectedIndex = selectedRow;
                        lstMeasureDef2.SelectedItem.Active = true;

                        break;

                    default:
                        if (lstMeasureDef0.SelectedItems.Count != 1)
                        {
                            DialogResult ds1t = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds1t.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                        {
                            DialogResult ds1u = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds1u.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                        modGlobal.gv_sql = "Select * from tbl_setup_MeasureCriteria ";
                        modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID = {1}", modGlobal.gv_sql, selectedMeasureCriteriaID);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and DDID2 is not null ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName21 = "tbl_setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);

                        if (modGlobal.gv_rs.Tables[sqlTableName21].Rows.Count == 0)
                        {
                            DialogResult ds1v = RadMessageBox.Show(this, "This feature does not apply to the selected criteria.",
                                "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = ds1v.ToString();
                            return;
                        }

                        frmMeasureModifySecondFieldCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));
                        frmMeasureModifySecondFieldCopy.ShowDialog();

                        RefreshMeasureCriteria();

                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                        lstMeasureDef0.SelectedIndex = selectedRow;
                        lstMeasureDef0.SelectedItem.Active = true;

                        break;
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

        private void cmdModifyCriteriaValue_Click(object sender, EventArgs e)
        {
            frmMeasureModifyValue frmMeasureModifyValueCopy = new frmMeasureModifyValue();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int selectedMeasureCriteriaID;


            try
            {
                switch (Index)
                {
                    case 1:
                        if (lstMeasureDef1.SelectedItems.Count != 1)
                        {
                            DialogResult dsw = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsw.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                        {
                            DialogResult dsx = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsx.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);
                        modGlobal.gv_sql = "SELECT DDID1 FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaID = " + selectedMeasureCriteriaID;
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName22 = "tbl_Setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                        if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName22].Rows[0]["DDID1"]))
                        {
                            DialogResult dsy = RadMessageBox.Show(this, "You cannot modify the right side (BLANK) in the Earliest Method",
                                "Earliest Can Not be Modified this way", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsy.ToString();
                        }
                        else
                        {
                            frmMeasureModifyValueCopy.setMeasureCriteriaID(Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                            frmMeasureModifyValueCopy.ShowDialog();

                            RefreshMeasureCriteria();

                            //go back to the same step
                            for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                            {
                                if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                                {
                                    selectedRow = i;
                                }
                            }
                            //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                            lstMeasureDef1.SelectedIndex = selectedRow;
                            lstMeasureDef1.SelectedItem.Active = true;
                        }
                        break;

                    case 2:
                        if (lstMeasureDef2.SelectedItems.Count != 1)
                        {
                            DialogResult dsz = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsz.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                        {
                            DialogResult dsaa = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsaa.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);
                        modGlobal.gv_sql = "SELECT DDID1 FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaID = " + selectedMeasureCriteriaID;
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName23 = "tbl_Setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                        if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName23].Rows[0]["DDID1"]))
                        {
                            DialogResult dsbb = RadMessageBox.Show(this, "You cannot modify the right side (BLANK) in the Earliest Method",
                                "Earliest Can Not be Modified this way", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsbb.ToString();
                        }
                        else
                        {
                            frmMeasureModifyValueCopy.setMeasureCriteriaID(Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));
                            frmMeasureModifyValueCopy.ShowDialog();

                            RefreshMeasureCriteria();

                            //go back to the same step
                            for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                            {
                                if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                                {
                                    selectedRow = i;
                                }
                            }
                            //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                            lstMeasureDef2.SelectedIndex = selectedRow;
                            lstMeasureDef2.SelectedItem.Active = true;
                        }
                        break;

                    default:
                        if (lstMeasureDef0.SelectedItems.Count != 1)
                        {
                            DialogResult dscc = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dscc.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                        {
                            DialogResult dsdd = RadMessageBox.Show(this, "Please choose a criteria to modify", "Criteria Selection", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsdd.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);
                        modGlobal.gv_sql = "SELECT DDID1 FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaID = " + selectedMeasureCriteriaID;
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName24 = "tbl_Setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                        if (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName24].Rows[0]["DDID1"]))
                        {

                            DialogResult dsee = RadMessageBox.Show(this, "You cannot modify the right side (BLANK) in the Earliest Method",
                                "Earliest Can Not be Modified this way", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsee.ToString();
                        }
                        else
                        {
                            frmMeasureModifyValueCopy.setMeasureCriteriaID(Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));
                            frmMeasureModifyValueCopy.ShowDialog();

                            RefreshMeasureCriteria();

                            //go back to the same step
                            for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                            {
                                if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                                {
                                    selectedRow = i;
                                }
                            }
                            //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                            lstMeasureDef0.SelectedIndex = selectedRow;
                            lstMeasureDef0.SelectedItem.Active = true;
                        }
                        break;
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

        private void cmdMoveStepTo_Click(object sender, EventArgs e)
        {
            frmMeasureMoveStepTo frmMeasureMoveStepToCopy = new frmMeasureMoveStepTo();
            string mcat = null;
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;


            try
            {
                switch (Index)
                {
                    case 2:
                        if (lstMeasureDef2.SelectedItems.Count != 1)
                        {
                            DialogResult dsff = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsff.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                        {
                            DialogResult dsgg = RadMessageBox.Show(this, "Please choose a criteria to modify", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsgg.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);


                        if (Index == 0)
                        {
                            mcat = "CI";
                        }
                        else if (Index == 2)
                        {
                            mcat = "RA";
                        }

                        frmMeasureMoveStepToCopy.SetMeasureCriteriaID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]),
                            Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex), mcat);

                        frmMeasureMoveStepToCopy.ShowDialog();

                        RefreshMeasureCriteria();
                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                        lstMeasureDef2.SelectedIndex = selectedRow;
                        lstMeasureDef2.SelectedItem.Active = true;

                        break;

                    default:
                        if (lstMeasureDef0.SelectedItems.Count != 1)
                        {
                            DialogResult dshh = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dshh.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                        {
                            DialogResult dsii = RadMessageBox.Show(this, "Please choose a criteria to modify", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsii.ToString();
                            return;
                        }

                        selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);


                        if (Index == 0)
                        {
                            mcat = "CI";
                        }
                        else if (Index == 2)
                        {
                            mcat = "RA";
                        }

                        frmMeasureMoveStepToCopy.SetMeasureCriteriaID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]),
                            Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex), mcat);

                        frmMeasureMoveStepToCopy.ShowDialog();

                        RefreshMeasureCriteria();
                        //go back to the same step
                        for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                        {
                            if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                            {
                                selectedRow = i;
                            }
                        }
                        //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                        lstMeasureDef0.SelectedIndex = selectedRow;
                        lstMeasureDef0.SelectedItem.Active = true;

                        break;
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

        private void cmdPrint0_Click(object sender, EventArgs e)
        {
            Printer Printer = new Printer();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int li_cnt = 0;

            try
            {
                if (lstMeasureDef0.SelectedItems.Count >= 1)
                {
                    DialogResult resp = RadMessageBox.Show(this, "Continue with Printing Just the Selected Text?",
                        "Continue with Selection?", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                    if (resp == DialogResult.Yes)
                    {
                        Printer.Print(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);

                        for (li_cnt = 0; li_cnt <= lstMeasureDef0.Items.Count - 1; li_cnt++)
                        {
                            //LDW if (lstMeasureDef0.GetSelected(li_cnt))
                            if (lstMeasureDef0.SelectedIndex == li_cnt)
                            {
                                Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstMeasureDef0, li_cnt));
                            }
                        }

                        Printer.EndDoc();
                    }
                }
                else
                {
                    Printer.Print(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);

                    for (li_cnt = 0; li_cnt <= lstMeasureDef0.Items.Count - 1; li_cnt++)
                    {
                        Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstMeasureDef0, li_cnt));
                        //Printer.Print Tab(10); li_cnt
                    }

                    Printer.Print("End of Flowchart");
                    Printer.EndDoc();
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

        private void cmdPrint1_Click(object sender, EventArgs e)
        {
            Printer Printer = new Printer();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int li_cnt = 0;

            try
            {
                if (lstMeasureDef1.SelectedItems.Count >= 1)
                {
                    DialogResult resp = RadMessageBox.Show(this, "Continue with Printing Just the Selected Text?",
                        "Continue with Selection?", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                    if (resp == DialogResult.Yes)
                    {
                        Printer.Print(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);

                        for (li_cnt = 0; li_cnt <= lstMeasureDef1.Items.Count - 1; li_cnt++)
                        {
                            //LDW if (lstMeasureDef1.GetSelected(li_cnt))
                            if (lstMeasureDef1.SelectedIndex == li_cnt)
                            {
                                Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstMeasureDef1, li_cnt));
                            }
                        }

                        Printer.EndDoc();
                    }
                }
                else
                {
                    Printer.Print(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);

                    for (li_cnt = 0; li_cnt <= lstMeasureDef1.Items.Count - 1; li_cnt++)
                    {
                        Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstMeasureDef1, li_cnt));
                        //Printer.Print Tab(10); li_cnt
                    }

                    Printer.Print("End of Flowchart");
                    Printer.EndDoc();
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

        private void cmdPrint2_Click(object sender, EventArgs e)
        {
            Printer Printer = new Printer();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int li_cnt = 0;

            try
            {
                if (lstMeasureDef2.SelectedItems.Count >= 1)
                {
                    DialogResult resp = RadMessageBox.Show(this, "Continue with Printing Just the Selected Text?",
                        "Continue with Selection?", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                    if (resp == DialogResult.Yes)
                    {
                        Printer.Print(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);

                        for (li_cnt = 0; li_cnt <= lstMeasureDef2.Items.Count - 1; li_cnt++)
                        {
                            //LDW if (lstMeasureDef2.GetSelected(li_cnt))
                            if (lstMeasureDef2.SelectedIndex == li_cnt)
                            {
                                Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstMeasureDef2, li_cnt));
                            }
                        }

                        Printer.EndDoc();
                    }
                }
                else
                {
                    Printer.Print(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"]);

                    for (li_cnt = 0; li_cnt <= lstMeasureDef2.Items.Count - 1; li_cnt++)
                    {
                        Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstMeasureDef2, li_cnt));
                        //Printer.Print Tab(10); li_cnt
                    }

                    Printer.Print("End of Flowchart");
                    Printer.EndDoc();
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

        private void cmdDown_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            try
            {
                MoveStep(Up: false);
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

        private void cmdDown1_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            try
            {
                MoveStep(Up: false);
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

        private void cmdSubstituteStepForSummarization_Click(object sender, EventArgs e)
        {
            frmMeasureCriteriaSubmitSubs frmMeasureCriteriaSubmitSubsCopy = new frmMeasureCriteriaSubmitSubs();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int selectedMeasureCriteriaID = 0;

            try
            {
                if (Index != 0)
                {
                    DialogResult dsjj = RadMessageBox.Show(this, "Substitution can only be done for the flowchart steps", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsjj.ToString();

                    return;
                }

                if (lstMeasureDef0.SelectedItems.Count != 1)
                {
                    DialogResult dsjk = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsjk.ToString();
                    return;
                }
                else if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                {
                    DialogResult dsjl = RadMessageBox.Show(this, "Please choose a criteria to modify", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsjl.ToString();

                    return;
                }
                if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                {
                    selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);
                }

                frmMeasureCriteriaSubmitSubsCopy.SetupMeasureID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]),
                    rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["MeasureSetDesc"] + "-" + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["JCAHOID"] +
                    "-" + rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"], Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));
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

            frmMeasureCriteriaSubmitSubsCopy.Show();
            this.Close();
            //RefreshMeasureCriteria
            //
            // 'go back to the same step
            // For i = 0 To lstMeasureDef(Index).ListCount - 1
            //     If lstMeasureDef(Index).ItemData(i) = selectedMeasureCriteriaID Then
            //         selectedRow = i
            //     End If
            // Next i
            //
            // lstMeasureDef(Index).Selected(selectedRow) = True
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            try
            {
                MoveStep(Up: true);
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

        private void cmdUp1_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            try
            {
                MoveStep(Up: true);
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

        private void MoveStep(bool Up)
        {
            int li_MeasureStep;
            int li_MeasureStepID;
            int li_MeasureID;
            int li_MaxStep = 0;
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int selectedRow = 0;
            int selectedMeasureCriteriaID;
            var i = 0;
            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                switch (Index)
                {
                    case 2:
                        if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) < 0 | lstMeasureDef2.SelectedItems.Count > 1)
                        {
                            DialogResult dsjm = RadMessageBox.Show(this, "Select one criteria in step to move.", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjm.ToString();
                            return;
                        }


                        DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to move this step?", "Move Step", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (resp == DialogResult.Yes)
                        {
                            //keep the reference to the step so we can go back to that
                            selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                            modGlobal.gv_sql = "SELECT ms.MeasureStepID, ms.MeasureStep, ms.MeasureID FROM " +
                                " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " +
                                " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " +
                                Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName25 = "tbl_setup_measurecriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);

                            li_MeasureID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["MeasureID"]);
                            li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["MeasureStepID"]);
                            li_MeasureStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["measurestep"]);
                            modGlobal.gv_rs.Dispose();

                            modGlobal.gv_sql = "SELECT Max(MeasureStep) as MaxStep FROM " + " tbl_setup_MeasureStep left join tbl_MEASURE_CAT " +
                                " on tbl_setup_MeasureStep.Measure_CatID = tbl_MEASURE_CAT.Measure_CatID " + " WHERE MeasureID = " + li_MeasureID;

                            if (Index == 0)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 and ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0)";
                            }
                            else if (Index == 2)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 and (CAT_TYPE = 'RA' or IsRisk = 1)";
                            }

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName26 = "tbl_setup_MeasureStep";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, modGlobal.gv_rs);

                            li_MaxStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName26].Rows[0]["MaxStep"]);
                            modGlobal.gv_rs.Dispose();

                            if (Up)
                            {
                                if (li_MeasureStep == 1)
                                    return;

                                //move previous step down
                                modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = {0} WHERE MeasureID = {1} AND MeasureStep = {2}",
                                    li_MeasureStep, li_MeasureID, li_MeasureStep - 1);

                                if (Index == 0)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND (Measure_CATID is null or Measure_CATID in (SELECT MEASURE_CATID FROM " +
                                        "tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')) AND IsRisk = 0 ", modGlobal.gv_sql);
                                }
                                else if (Index == 2)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND (Measure_CATID in (SELECT MEASURE_CATID FROM  tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA') OR IsRisk = 1)",
                                        modGlobal.gv_sql);
                                }

                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                //move all steps up
                                modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = MeasureStep - 1 WHERE MeasureStepID = {0}", li_MeasureStepID);
                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            }
                            else
                            {
                                if (li_MeasureStep == li_MaxStep)
                                    return;

                                //move next step up
                                modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = " + li_MeasureStep + " WHERE MeasureID = " +
                                    li_MeasureID + " AND MeasureStep = " + li_MeasureStep + 1;

                                if (Index == 0)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND MeasureStep <> -100 AND ((Measure_CATID is null or Measure_CATID in" +
                                        " (SELECT MEASURE_CATID FROM  tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')) AND IsRisk = 0)", modGlobal.gv_sql);
                                }
                                else if (Index == 2)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND MeasureStep <> -100 AND (Measure_CATID in (SELECT MEASURE_CATID FROM " +
                                        "tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')" + " OR IsRisk = 1) ", modGlobal.gv_sql);
                                }

                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = MeasureStep + 1 WHERE MeasureStepID = {0}", li_MeasureStepID);
                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            }
                            RefreshMeasureCriteria();

                            //go back to the same step
                            for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                            {
                                if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                                {
                                    selectedRow = i;
                                }
                            }
                            //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                            lstMeasureDef2.SelectedIndex = selectedRow;
                            lstMeasureDef2.SelectedItem.Active = true;
                        }
                        //return;
                        //LDW ErrHandler:

                        //LDW modGlobal.CheckForErrors();

                        break;

                    default:
                        if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) < 0 | lstMeasureDef0.SelectedItems.Count > 1)
                        {
                            DialogResult dsjm = RadMessageBox.Show(this, "Select one criteria in step to move.", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjm.ToString();
                            return;
                        }


                        DialogResult resp1 = RadMessageBox.Show(this, "Are you sure you want to move this step?", "Move Step", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (resp1 == DialogResult.Yes)
                        {
                            //keep the reference to the step so we can go back to that
                            selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                            modGlobal.gv_sql = "SELECT ms.MeasureStepID, ms.MeasureStep, ms.MeasureID FROM " +
                                " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " +
                                " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " +
                                Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName25 = "tbl_setup_measurecriteria";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);

                            li_MeasureID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["MeasureID"]);
                            li_MeasureStepID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["MeasureStepID"]);
                            li_MeasureStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName25].Rows[0]["measurestep"]);
                            modGlobal.gv_rs.Dispose();

                            modGlobal.gv_sql = "SELECT Max(MeasureStep) as MaxStep FROM " + " tbl_setup_MeasureStep left join tbl_MEASURE_CAT " +
                                " on tbl_setup_MeasureStep.Measure_CatID = tbl_MEASURE_CAT.Measure_CatID " + " WHERE MeasureID = " + li_MeasureID;

                            if (Index == 0)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 and ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0)";
                            }
                            else if (Index == 2)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 and (CAT_TYPE = 'RA' or IsRisk = 1)";
                            }

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName26 = "tbl_setup_MeasureStep";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, modGlobal.gv_rs);

                            li_MaxStep = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName26].Rows[0]["MaxStep"]);
                            modGlobal.gv_rs.Dispose();

                            if (Up)
                            {
                                if (li_MeasureStep == 1)
                                    return;

                                //move previous step down
                                modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = {0} WHERE MeasureID = {1} AND MeasureStep = {2}",
                                    li_MeasureStep, li_MeasureID, li_MeasureStep - 1);

                                if (Index == 0)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND (Measure_CATID is null or Measure_CATID in (SELECT MEASURE_CATID FROM" +
                                        " tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')) AND IsRisk = 0 ", modGlobal.gv_sql);
                                }
                                else if (Index == 2)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND (Measure_CATID in (SELECT MEASURE_CATID FROM " +
                                        "tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA') OR IsRisk = 1)", modGlobal.gv_sql);
                                }

                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                //move all steps up
                                modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = MeasureStep - 1 WHERE MeasureStepID = {0}", li_MeasureStepID);
                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            }
                            else
                            {
                                if (li_MeasureStep == li_MaxStep)
                                    return;

                                //move next step up
                                modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = " + li_MeasureStep + " WHERE MeasureID = " +
                                    li_MeasureID + " AND MeasureStep = " + li_MeasureStep + 1;

                                if (Index == 0)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND MeasureStep <> -100 AND ((Measure_CATID is null or Measure_CATID in" +
                                        " (SELECT MEASURE_CATID FROM  tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')) AND IsRisk = 0)", modGlobal.gv_sql);
                                }
                                else if (Index == 2)
                                {
                                    modGlobal.gv_sql = string.Format("{0} AND MeasureStep <> -100 AND (Measure_CATID in (SELECT MEASURE_CATID FROM " +
                                        "tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')" + " OR IsRisk = 1) ", modGlobal.gv_sql);
                                }

                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep  SET MeasureStep = MeasureStep + 1 WHERE MeasureStepID = {0}", li_MeasureStepID);
                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            }
                            RefreshMeasureCriteria();

                            //go back to the same step
                            for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                            {
                                if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                                {
                                    selectedRow = i;
                                }
                            }
                            //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                            lstMeasureDef0.SelectedIndex = selectedRow;
                            lstMeasureDef0.SelectedItem.Active = true;
                        }
                        //return;
                        

                        //LDW modGlobal.CheckForErrors();

                        break;
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

        private void cmdView_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;

            try
            {
                switch (Index)
                {
                    case 0:
                        if (lstMeasureDef0.SelectedIndex > -1)
                        {
                            DialogResult dsjn = RadMessageBox.Show(this, lstMeasureDef0.Text, "View Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjn.ToString();
                        }
                        break;
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

        private void dbgMeasureList_CurrentCellChanged(object sender, Telerik.WinControls.UI.CurrentCellChangedEventArgs e)
        {
            try
            {
                //LDW if (!string.IsNullOrEmpty(rdcMeasureList.SQL))
                if (!string.IsNullOrEmpty(rdcMeasureList.DefaultViewManager.DataViewSettingCollectionString))
                {
                    RefreshMeasureCriteria();
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

        private void frmMeasureCriteriaSetup_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
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

        public void RefreshMeasureList()
        {
            // ERROR: Not supported in C#: OnErrorStatement


            try
            {
                modGlobal.gv_sql = "Select ms.MeasureSetDesc, i.JCAHOID, i.Description, i.IndicatorID, ms.MeasureSetID, i.RiskAdjusted" +
                    " from tbl_setup_indicator i, tbl_setup_MeasureSetMapMeas isf, tbl_setup_MeasureSet ms" +
                    " Where i.IndicatorID = isf.IndicatorID " + " and isf.MeasureSetID = ms.MeasureSetID ";

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

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcMeasureListTable = "tbl_setup_indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMeasureListTable, modGlobal.gv_rs);
                if (modGlobal.gv_rs.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    //LDW RadMessageBox.Show("Please Create measures before using this form", MsgBoxStyle.Information, "No Measures Exist");
                    DialogResult ds1v = RadMessageBox.Show(this, "Please Create measures before using this form", "No Measures Exist", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1v.ToString();
                    SSTabCriteria.Enabled = false;

                    return;
                }
                else
                {
                    rdcMeasureList = modGlobal.gv_rs;
                    rdcMeasureList.AcceptChanges();
                    dbgMeasureList.Refresh();

                    RefreshMeasureCriteria();
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

        private void cmdChangeAndOrCond_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int li_cnt = 0;
            string JoinOperator = null;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef0.SelectedIndex < 0)
                {
                    return;
                }

                if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) < 0)
                {
                    return;
                }

                if (lstMeasureDef0.SelectedItems.Count != 1)
                {
                    DialogResult dsjn = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsjn.ToString();
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);

                //the join operator has to be updated for the entire set
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} Where MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName27 = "tbl_setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);

                JoinOperator = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["JoinOperator"].ToString())) == "AND" ? "OR" : "AND");

                modGlobal.gv_sql = " update  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} set joinoperator = '{1}'", modGlobal.gv_sql, JoinOperator);
                modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureCriteriaSetID = ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select MeasureCriteriaSetID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} Where MeasureCriteriaID = {1})", modGlobal.gv_sql,
                    Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //For li_cnt = 0 To lstMeasureDef(Index).ListCount - 1
                //    If lstMeasureDef(Index).Selected(li_cnt) Then
                //        gv_sql = "Select * "
                //        gv_sql = gv_sql & " from tbl_setup_MeasureCriteria "
                //        gv_sql = gv_sql & " Where MeasureCriteriaID = " & lstMeasureDef(Index).ItemData(li_cnt)
                //
                //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
                //        Do While Not gv_rs.EOF
                //            gv_rs.Edit
                //            gv_rs!JoinOperator = IIf(UCase(Trim(gv_rs!JoinOperator)) = "AND", "OR", "AND")
                //            gv_rs.Update
                //            gv_rs.MoveNext
                //        Loop
                //        gv_rs.Close
                //    End If
                //Next

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef0.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef0, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef0.SetSelected(selectedRow, true);
                lstMeasureDef0.SelectedIndex = selectedRow;
                lstMeasureDef0.SelectedItem.Active = true;

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

        private void cmdChangeAndOrCond1_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int li_cnt = 0;
            string JoinOperator = null;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef1.SelectedIndex < 0)
                {
                    return;
                }

                if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) < 0)
                {
                    return;
                }

                if (lstMeasureDef1.SelectedItems.Count != 1)
                {
                    DialogResult dsjo = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsjo.ToString();
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);

                //the join operator has to be updated for the entire set
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} Where MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName28 = "tbl_setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);

                JoinOperator = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.Tables[sqlTableName28].Rows[0]["JoinOperator"].ToString())) == "AND" ? "OR" : "AND");

                modGlobal.gv_sql = " update  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} set joinoperator = '{1}'", modGlobal.gv_sql, JoinOperator);
                modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureCriteriaSetID = ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select MeasureCriteriaSetID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} Where MeasureCriteriaID = {1})", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //For li_cnt = 0 To lstMeasureDef(Index).ListCount - 1
                //    If lstMeasureDef(Index).Selected(li_cnt) Then
                //        gv_sql = "Select * "
                //        gv_sql = gv_sql & " from tbl_setup_MeasureCriteria "
                //        gv_sql = gv_sql & " Where MeasureCriteriaID = " & lstMeasureDef(Index).ItemData(li_cnt)
                //
                //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
                //        Do While Not gv_rs.EOF
                //            gv_rs.Edit
                //            gv_rs!JoinOperator = IIf(UCase(Trim(gv_rs!JoinOperator)) = "AND", "OR", "AND")
                //            gv_rs.Update
                //            gv_rs.MoveNext
                //        Loop
                //        gv_rs.Close
                //    End If
                //Next

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef1.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef1, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef1.SetSelected(selectedRow, true);
                lstMeasureDef1.SelectedIndex = selectedRow;
                lstMeasureDef1.SelectedItem.Active = true;

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

        private void cmdChangeAndOrCond2_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int li_cnt = 0;
            string JoinOperator = null;

            // ERROR: Not supported in C#: OnErrorStatement


            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    return;
                }

                if (lstMeasureDef2.SelectedIndex < 0)
                {
                    return;
                }

                if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) < 0)
                {
                    return;
                }

                if (lstMeasureDef2.SelectedItems.Count != 1)
                {
                    DialogResult dsjp = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsjp.ToString();
                    return;
                }

                selectedMeasureCriteriaID = Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);

                //the join operator has to be updated for the entire set
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} Where MeasureCriteriaID = {1}", modGlobal.gv_sql, Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                const string sqlTableName29 = "tbl_setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, modGlobal.gv_rs);

                JoinOperator = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.Tables[sqlTableName29].Rows[0]["JoinOperator"].ToString())) == "AND" ? "OR" : "AND");

                modGlobal.gv_sql = " update  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} set joinoperator = '{1}'", modGlobal.gv_sql, JoinOperator);
                modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureCriteriaSetID = ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select MeasureCriteriaSetID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} Where MeasureCriteriaID = {1})", modGlobal.gv_sql,
                    Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));

                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //For li_cnt = 0 To lstMeasureDef(Index).ListCount - 1
                //    If lstMeasureDef(Index).Selected(li_cnt) Then
                //        gv_sql = "Select * "
                //        gv_sql = gv_sql & " from tbl_setup_MeasureCriteria "
                //        gv_sql = gv_sql & " Where MeasureCriteriaID = " & lstMeasureDef(Index).ItemData(li_cnt)
                //
                //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
                //        Do While Not gv_rs.EOF
                //            gv_rs.Edit
                //            gv_rs!JoinOperator = IIf(UCase(Trim(gv_rs!JoinOperator)) = "AND", "OR", "AND")
                //            gv_rs.Update
                //            gv_rs.MoveNext
                //        Loop
                //        gv_rs.Close
                //    End If
                //Next

                RefreshMeasureCriteria();

                //go back to the same step
                for (i = 0; i <= lstMeasureDef2.Items.Count - 1; i++)
                {
                    if (Support.GetItemData(lstMeasureDef2, i) == selectedMeasureCriteriaID)
                    {
                        selectedRow = i;
                    }
                }
                //LDW lstMeasureDef2.SetSelected(selectedRow, true);
                lstMeasureDef2.SelectedIndex = selectedRow;
                lstMeasureDef2.SelectedItem.Active = true;

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

        private void mnuDeleteFlowchartAction_Click(object sender, EventArgs e)
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;

            try
            {
                switch (Index)
                {
                    case 1:
                        if (lstMeasureDef1.SelectedItems.Count != 1)
                        {
                            DialogResult dsjq = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjq.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                        {
                            DialogResult dsjr = RadMessageBox.Show(this, "Please choose a criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjr.ToString();
                            return;
                        }


                        DialogResult resp = RadMessageBox.Show(this, "Are you sure you wish to remove the action from this step?", "Remove Action", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (resp == DialogResult.Yes)
                        {
                            modGlobal.gv_sql = "select * from vuMeasureFlowchartLogic WHERE MeasureCriteriaID = " +
                                Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex);
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName29 = "vuMeasureFlowchartLogic";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, modGlobal.gv_rs);

                            modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep Set FlowchartActionID = NULL WHERE MeasureStepID = " +
                                modGlobal.gv_rs.Tables[sqlTableName29].Rows[0]["MeasureStepID"];
                            modGlobal.gv_rs.Dispose();
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            //LDW RadMessageBox.Show("Successfully Deleted");
                            DialogResult dsjs = RadMessageBox.Show(this, "Successfully Deleted", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjs.ToString();
                            RefreshMeasureCriteria();
                        }

                        break;

                    case 2:
                        if (lstMeasureDef2.SelectedItems.Count != 1)
                        {
                            DialogResult dsjq = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjq.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                        {
                            DialogResult dsjr = RadMessageBox.Show(this, "Please choose a criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjr.ToString();
                            return;
                        }


                        DialogResult resp1 = RadMessageBox.Show(this, "Are you sure you wish to remove the action from this step?", "Remove Action", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (resp1 == DialogResult.Yes)
                        {
                            modGlobal.gv_sql = "select * from vuMeasureFlowchartLogic WHERE MeasureCriteriaID = " + Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex);
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName30 = "vuMeasureFlowchartLogic";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName30, modGlobal.gv_rs);

                            modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep Set FlowchartActionID = NULL WHERE MeasureStepID = " + modGlobal.gv_rs.Tables[sqlTableName30].Rows[0]["MeasureStepID"];
                            modGlobal.gv_rs.Dispose();
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            //LDW RadMessageBox.Show("Successfully Deleted");
                            DialogResult dsjs = RadMessageBox.Show(this, "Successfully Deleted", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjs.ToString();
                            RefreshMeasureCriteria();
                        }

                        break;

                    default:
                        if (lstMeasureDef0.SelectedItems.Count != 1)
                        {
                            DialogResult dsjt = RadMessageBox.Show(this, "Please choose 1 criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsjt.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                        {
                            DialogResult dsju = RadMessageBox.Show(this, "Please choose a criteria to modify", "Modify Criteria", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dsju.ToString();
                            return;
                        }


                        DialogResult resp2 = RadMessageBox.Show(this, "Are you sure you wish to remove the action from this step?", "Remove Action", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (resp2 == DialogResult.Yes)
                        {
                            modGlobal.gv_sql = "select * from vuMeasureFlowchartLogic WHERE MeasureCriteriaID = " + Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex);
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName31 = "vuMeasureFlowchartLogic";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName31, modGlobal.gv_rs);

                            modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep Set FlowchartActionID = NULL WHERE MeasureStepID = " + modGlobal.gv_rs.Tables[sqlTableName31].Rows[0]["MeasureStepID"];
                            modGlobal.gv_rs.Dispose();
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            //LDW RadMessageBox.Show("Successfully Deleted");
                            DialogResult dsjv = RadMessageBox.Show(this, "Successfully Deleted", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            this.Text = dsjv.ToString();
                            RefreshMeasureCriteria();
                        }

                        break;
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

        private void mnuDeleteMeasureFlowchartLogic_Click(object sender, EventArgs e)
        {
            string ls_CurrentDB = null;
            int li_MeasureID = 0;

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0)
                {
                    DialogResult ds1jw = RadMessageBox.Show(this, "Please select a measure to sync.", "No Measure Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1jw.ToString();

                    return;
                }

                li_MeasureID = Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]);

                if (Strings.InStr(modGlobal.gv_cn.ConnectionString, "COP2001Current") > 0)
                {
                    ls_CurrentDB = "COP2001Current";
                }
                else if (Strings.InStr(modGlobal.gv_cn.ConnectionString, "COP2001Archive") > 0)
                {
                    ls_CurrentDB = "COP2001Archive";
                }
                else
                {
                    ls_CurrentDB = "COP2001";
                }
                Cursor.Current = Cursors.WaitCursor;

                //measurecriteriasubmitsubs
                modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteriaSubmitSubs] WHERE MeasureCriteriaSetSubmitSubsID in " +
                    "(SELECT MeasureCriteriaSetSubmitSubsID FROM tbl_Setup_MeasureCriteriaSetSubmitSubs mcss, tbl_Setup_MeasureStepSubmitSubs mess, tbl_Setup_MeasureStep ms " +
                    " WHERE mess.MeasureStepSubmitSubsID = mcss.MeasureStepSubmitSubsID and ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " + li_MeasureID + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //measurecriteria
                modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteria] WHERE MeasureCriteriaSetID in " +
                    "(SELECT MeasureCriteriaSetID FROM tbl_Setup_MeasureCriteriaSet mcss, tbl_Setup_MeasureStep mess " +
                    " WHERE mess.MeasureStepID = mcss.MeasureStepID and mess.MeasureID = " + li_MeasureID + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //measurecriteriasetsubmitsub
                modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] WHERE MeasureStepSubmitSubsID in " +
                    "(SELECT MeasureStepSubmitSubsID FROM tbl_Setup_MeasureStepSubmitSubs mess, tbl_Setup_MeasureStep ms " +
                    " WHERE ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " + li_MeasureID + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //measurecriteriaset
                modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureCriteriaSet] WHERE MeasureStepID in " +
                    "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep mess " + " WHERE mess.MeasureID = " + li_MeasureID + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //measurestepsubmitsubs
                modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] WHERE MeasureStepID in " +
                    "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " + li_MeasureID + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //measurestepgroup
                modGlobal.gv_sql = "DELETE FROM [" + ls_CurrentDB + "].[dbo].[tbl_Setup_MeasureStepGroup] WHERE MeasureStepID in " +
                    "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " + li_MeasureID + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //measurestep
                modGlobal.gv_sql = string.Format("DELETE FROM [{0}].[dbo].[tbl_Setup_MeasureStep] WHERE MeasureID = {1}", ls_CurrentDB, li_MeasureID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshMeasureCriteria();

                Cursor.Current = Cursors.Default;


                DialogResult dsjw = RadMessageBox.Show(this, "Success!", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.Text = dsjw.ToString();
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

        private void mnuFlowchartAction_Click(object sender, EventArgs e)
        {
            dlgAddFlowchartAction dlgAddFlowchartActionCopy = new dlgAddFlowchartAction();
            frmMasterForm frmMasterFormCopy = new frmMasterForm();
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;


            try
            {
                switch (Index)
                {
                    case 1:
                        if (lstMeasureDef1.SelectedItems.Count != 1)
                        {
                            DialogResult dsjx = RadMessageBox.Show(this, "Please choose 1 criteria to modify!", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            this.Text = dsjx.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex) == -1)
                        {
                            DialogResult dsjy = RadMessageBox.Show(this, "Please choose a criteria to modify!", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            this.Text = dsjy.ToString();
                            return;
                        }

                        dlgAddFlowchartActionCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef1, lstMeasureDef1.SelectedIndex));
                        dlgAddFlowchartActionCopy.Show();
                        RefreshMeasureCriteria();

                        break;

                    case 2:
                        if (lstMeasureDef2.SelectedItems.Count != 1)
                        {
                            DialogResult dsjz = RadMessageBox.Show(this, "Please choose 1 criteria to modify!", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            this.Text = dsjz.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex) == -1)
                        {
                            DialogResult dsa1 = RadMessageBox.Show(this, "Please choose a criteria to modify!", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            this.Text = dsa1.ToString();
                            return;
                        }

                        dlgAddFlowchartActionCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef2, lstMeasureDef2.SelectedIndex));
                        dlgAddFlowchartActionCopy.Show();
                        RefreshMeasureCriteria();

                        break;

                    default:
                        if (lstMeasureDef0.SelectedItems.Count != 1)
                        {
                            DialogResult dsjz = RadMessageBox.Show(this, "Please choose 1 criteria to modify!", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            this.Text = dsjz.ToString();
                            return;
                        }
                        else if (Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex) == -1)
                        {
                            DialogResult dsa1 = RadMessageBox.Show(this, "Please choose a criteria to modify!", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                            this.Text = dsa1.ToString();
                            return;
                        }

                        dlgAddFlowchartActionCopy.SetMeasureCriteriaID(Support.GetItemData(lstMeasureDef0, lstMeasureDef0.SelectedIndex));
                        dlgAddFlowchartActionCopy.Show();
                        RefreshMeasureCriteria();

                        break;
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

        private void mnuShowGroupLogic_Click(object sender, EventArgs e)
        {
            frmMeasureFieldGroups frmMeasureFieldGroupsCopy = new frmMeasureFieldGroups();
            frmMeasureFieldGroupsCopy.Show();
        }

        private void mnuSyncMeasure_Click(object sender, EventArgs e)
        {
            dlgSyncMeasure dlgSyncMeasureCopy = new dlgSyncMeasure();

            try
            {
                if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count != 0)
                {
                    dlgSyncMeasureCopy.SetMeasureID(Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]));
                    dlgSyncMeasureCopy.Text = rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["Description"].ToString();
                    dlgSyncMeasureCopy.ShowDialog();
                }
                else
                {
                    DialogResult dsa2 = RadMessageBox.Show(this, "Please select a measure to sync.", "No Measure Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dsa2.ToString();
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
        

        private void SSTabCriteria_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lock (static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init)
                {
                    try
                    {
                        if (InitStaticVariableHelper(static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init))
                        {
                            static_SSTabCriteria_SelectedIndexChanged_PreviousTab = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
                        }
                    }
                    finally
                    {
                        static_SSTabCriteria_SelectedIndexChanged_PreviousTab_Init.State = 1;
                    }
                }
                if (Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["RiskAdjusted"]) == 0)
                {
                    if (SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex == 2)
                    {
                        SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex = static_SSTabCriteria_SelectedIndexChanged_PreviousTab;

                        DialogResult dsa3 = RadMessageBox.Show(this, "You can not assign risk criteria to an indicator that is not Risk Adjusted.",
                            "Not Defined as Risk Adjusted", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = dsa3.ToString();
                        return;
                    }
                }

                RefreshMeasureCriteria();
                static_SSTabCriteria_SelectedIndexChanged_PreviousTab = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
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

        public void ResetMeasureStepOrder(string SetID, string StepID, string SetNum, string StepNum)
        {
            int li_SetCount;
            int li_CritCount;
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            int li_MaxStep = 0;
            DataSet rs_JoinOp = new DataSet();
            string ls_JoinOp = null;


            try
            {
                //get the # of criteria left for the set
                modGlobal.gv_sql = string.Format("Select count(*) as NumCriteria from tbl_Setup_MeasureCriteria  where MeasureCriteriaSetID = {0}", SetID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName30 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName30, modGlobal.gv_rs);
                li_CritCount = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName30].Rows[0]["NumCriteria"]);
                modGlobal.gv_rs.Dispose();

                if (li_CritCount == 0)
                {
                    //delete the the set
                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + SetID;
                    //LDW rs_JoinOp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                    const string sqlTableName31 = "tbl_Setup_MeasureCriteriaSet";
                    rs_JoinOp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName31, modGlobal.gv_rs);

                    //LDW rs_JoinOp.Edit();
                    ls_JoinOp = rs_JoinOp.Tables[sqlTableName31].Rows[0]["JoinOperator"].ToString();
                    //LDW rs_JoinOp.Delete();
                    rs_JoinOp.Reset();
                    rs_JoinOp.Dispose();

                    //delete any groupings related to the step
                    modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + SetID;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + StepID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureCriteriaSet = " + Convert.ToDouble(SetNum) + 1;

                    //LDW rs_JoinOp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                    const string sqlTableName32 = "tbl_Setup_MeasureCriteriaSet";
                    rs_JoinOp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName32, modGlobal.gv_rs);

                    //LDW if (!rs_JoinOp.EOF)
                    foreach (DataRow myRowX in rs_JoinOp.Tables[sqlTableName32].Rows)
                    {
                        //LDW rs_JoinOp.Edit();
                        //LDW rs_JoinOp.rdoColumns["JoinOperator"].Value = ls_JoinOp;
                        myRowX.SetField<string>("JoinOperator", ls_JoinOp);
                        rs_JoinOp.AcceptChanges();
                    }
                    rs_JoinOp.Dispose();
                }

                modGlobal.gv_sql = string.Format("Select count(MeasureCriteriaSet) as MaxSet from tbl_Setup_MeasureCriteriaSet  where MeasureStepID = {0}", StepID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName33 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName33, modGlobal.gv_rs);

                li_SetCount = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName33].Rows[0]["MaxSet"]);
                modGlobal.gv_rs.Dispose();

                if (li_SetCount == 0)
                {
                    //delete any groupings related to the step
                    modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + StepID;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureStep WHERE MeasureStepID = " + StepID;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //only update other step #s for regular delete (filter only has 1 step)
                    if (Index == 0 | Index == 2)
                    {
                        modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep SET MeasureStep = (MeasureStep -1) ";
                        modGlobal.gv_sql = string.Format("{0}  WHERE MeasureID = {1}", modGlobal.gv_sql, rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]);
                        modGlobal.gv_sql = string.Format("{0}  AND MeasureStep > {1}", modGlobal.gv_sql, StepNum);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureStepID in ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " (SELECT ms.MeasureStepID  ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStep <> -100 ";
                        if (Index == 0)
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'CI'or CAT_Type is null ";
                        }
                        else if (Index == 2)
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'RA'";
                        }
                        modGlobal.gv_sql = string.Format("{0}  and ms.MeasureID = {1}", modGlobal.gv_sql, rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]);
                        modGlobal.gv_sql = modGlobal.gv_sql + " )";

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }
                //ContUpdate:


                //only update other set #s for regular delete (filter only has 1 set)
                if (li_CritCount == 0 & (Index == 0 | Index == 2))
                {
                    modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureCriteriaSet SET MeasureCriteriaSet = (MeasureCriteriaSet -1) ";
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1} AND MeasureCriteriaSet > {2}", modGlobal.gv_sql, StepID, SetNum);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureStepID in ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (SELECT ms.MeasureStepID  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStep <> -100 ";
                    if (Index == 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'CI'or CAT_Type is null ";
                    }
                    else if (Index == 2)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CAT_TYPE = 'RA'";
                    }
                    modGlobal.gv_sql = string.Format("{0}  and ms.MeasureStepID = {1}", modGlobal.gv_sql, StepID);
                    modGlobal.gv_sql = modGlobal.gv_sql + " )";

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

        public void RefreshMeasureCriteria()
        {
            int Index = SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex;
            string StepLabel = null;
            string ls_Suffix = null;
            string ls_Prefix = null;
            string ls_MainOp = null;
            string ls_PrevSet = null;
            int li_TotCriteriaInSet;
            int li_StepCount ;
            int li_CritCount ;
            int li_SetCount ;
            int li_TotStep ;
            int li_TotSetInStep = 0;
            DataSet rs_TotCrit = new DataSet();
            int rs_TotSetInStep ;
            DataSet rs_Crit = new DataSet();
            string SubmitSubs = null;
            DataSet rs_MeasGroup = new DataSet();
            int li_MeasGroup = 0;
            string ls_MeasGroup = null;
            DataSet rs_MeasStepGroup = new DataSet();
            string SingleIndent = null;
            string MeasGroup = null;
            string GroupIndent = null;
            string SetIndent = null;
            string CritIndent = null;
            int li_GroupSets = 0;
            int GroupSetsCount = 0;
            string GroupJoinOp = null;
            DataSet rs_Temp = new DataSet();
            int CurrentVersion = 0;


            try
            {
                SingleIndent = "      ";
                // ERROR: Not supported in C#: OnErrorStatement


                RefreshRiskAdjusted();

                switch (Index)
                {
                    case 1:
                        lstMeasureDef1.Items.Clear();


                        CurrentVersion = modGlobal.GetCurrentVersion();

                        //Dim rs_MeasStep As System.Data.DataSet 
                        DataSet rs_MeasStep = new DataSet();


                        //MeasureStep = -100 means that it is the filter criteria
                        if (Index == 1)
                        {
                            modGlobal.gv_sql = "SELECT DISTINCT MeasureStep, MeasureStepID " + " FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " +
                                rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"] + " AND MeasureStep = -100 ";
                        }
                        else if (Index == 0 | Index == 2)
                        {
                            modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID, ms.GoToStep, m.CAT, ms.FlowchartActionID ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID ";
                            modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql, rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]);
                            modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 ";

                            if (Index == 0)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0) ";
                            }
                            else if (Index == 2)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
                            }

                        }

                        modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC";

                        //LDW rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName36 = "tbl_Setup_MeasureStep";
                        rs_MeasStep = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName36, rs_MeasStep);

                        /*LDW if (rs_MeasStep.EOF)
                            return;*/

                        int rsRecCount = rs_MeasStep.Tables[sqlTableName36].Rows.Count;
                        for (int i = 0; i < rsRecCount; i++)
                        {
                            DataRow myRowY = rs_MeasStep.Tables[sqlTableName36].Rows[i];
                            int rowIndex = rs_MeasStep.Tables[sqlTableName36].Rows.IndexOf(myRowY);
                            if (rowIndex == rsRecCount - 1)
                            {
                                return;
                            }
                        }


                        //LDW rs_MeasStep.MoveLast();
                        li_TotStep = rs_MeasStep.Tables[sqlTableName36].Rows.Count;
                        //LDW rs_MeasStep.MoveFirst();
                        li_StepCount = 0;

                        //STEP LOOP
                        //LDW while (!rs_MeasStep.EOF)
                        foreach (DataRow myRow5 in rs_MeasStep.Tables[sqlTableName36].Rows)
                        {
                            li_StepCount = li_StepCount + 1;
                            ls_Suffix = "";

                            if (Index == 0 | Index == 2)
                            {
                                //show a signal if there is a substitute submission step
                                SubmitSubs = "";
                                modGlobal.gv_sql = " select * from tbl_setup_MeasureStepSubmitSubs where MeasureStepID = " + myRow5.Field<int>("MeasureStepID");

                                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName37 = "tbl_setup_MeasureStepSubmitSubs";
                                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName37, modGlobal.gv_rs);
                                if (modGlobal.gv_rs.Tables[sqlTableName37].Rows.Count > 0)
                                {
                                    SubmitSubs = " (With Submission Substitution) ";
                                }
                                modGlobal.gv_rs.Dispose();


                                StepLabel = string.Format("Step {0}{1}: = ", myRow5.Field<int>("measurestep"), SubmitSubs);
                                if (Information.IsDBNull(myRow5.Field<string>("CAT")))
                                {
                                    StepLabel = string.Format("{0}Go To Step {1}", StepLabel, Convert.ToString(myRow5.Field<int>("GoToStep")));
                                }
                                else
                                {
                                    StepLabel = StepLabel + myRow5.Field<string>("CAT");
                                }

                                //If InStr(1, "75,94,95,96,97,98,99,100,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 45 Then
                                if (((CurrentVersion <= 36 & myRow5.Field<int>("measurestep") == 43) | (CurrentVersion >= 37 & (myRow5.Field<int>("measurestep") == 44)) &
                                    (Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 75 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 94 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 95 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 96 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 97 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 98 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 99 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 100)))
                                {
                                    StepLabel = StepLabel + " *IMPUTED* ";
                                    //ElseIf InStr(1, "84,85,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 1 Then
                                }
                                else if ((myRow5.Field<int>("measurestep") == 1) &
                                    (Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 84 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 85))
                                {

                                    StepLabel = StepLabel + " *IMPUTED* ";
                                }

                                if (!Information.IsDBNull(myRow5.Field<int>("flowchartactionid")))
                                {
                                    modGlobal.gv_sql = "SELECT ActionDescription FROM tbl_Setup_MeasureFlowchartAction WHERE FlowchartActionID = " + myRow5.Field<int>("flowchartactionid");
                                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName38 = "tbl_Setup_MeasureFlowchartAction";
                                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName38, rs_Temp);

                                    StepLabel = string.Format("{0} (Action: {1})", StepLabel, myRow5.Field<string>("actionDescription"));
                                    rs_Temp.Dispose();
                                    rs_Temp = null;
                                }


                                lstMeasureDef1.Items.Add(StepLabel);
                                Support.SetItemData(lstMeasureDef1, lstMeasureDef1.Items.Count - 1, -1);
                            }

                            //SET QUERY
                            modGlobal.gv_sql = "SELECT * FROM ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureCriteriaSet mcs inner join  tbl_Setup_MeasureStep ms ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MeasureStepID = mcs.MeasureStepID ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_Setup_MeasureStepGroup as msg ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on mcs.measureCriteriaSetid = msg.measureCriteriaSetid ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ms.MeasureStepID = ";

                            if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0 | Information.IsDBNull(myRow5.Field<int>("MeasureStepID")))
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " (-1)";
                            }
                            else
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + myRow5.Field<int>("MeasureStepID");
                            }
                            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY msg.MeasureStepGroup, mcs.MeasureCriteriaSet ASC";
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName39 = "tbl_Setup_MeasureCriteriaSet";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName39, modGlobal.gv_rs);

                            //LDW if (modGlobal.gv_rs.EOF)
                            int moRecCount = modGlobal.gv_rs.Tables[sqlTableName39].Rows.Count;
                            for (int i = 0; i < moRecCount; i++)
                            {
                                DataRow myRowXer = modGlobal.gv_rs.Tables[sqlTableName39].Rows[i];
                                int rowIndex = modGlobal.gv_rs.Tables[sqlTableName39].Rows.IndexOf(myRowXer);

                                if (rowIndex == moRecCount - 1)
                                {
                                    return;
                                }
                            }

                            //LDW modGlobal.gv_rs.MoveLast();
                            li_TotSetInStep = modGlobal.gv_rs.Tables[sqlTableName39].Rows.Count;
                            //LDW modGlobal.gv_rs.MoveFirst();
                            li_SetCount = 0;
                            ls_MeasGroup = "";

                            // loop thru sets
                            //LDW while (!modGlobal.gv_rs.EOF)
                            foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName39].Rows)
                            {
                                li_SetCount = li_SetCount + 1;

                                //show signal if there is a grouping
                                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + myRow6.Field<int>("MeasureCriteriaSetID");
                                //LDW rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName40 = "tbl_Setup_MeasureStepGroup";
                                rs_MeasGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName40, rs_MeasGroup);

                                if (rs_MeasGroup.Tables[sqlTableName40].Rows.Count == 0)
                                {
                                    MeasGroup = "";
                                    GroupIndent = "";
                                    SetIndent = SingleIndent;
                                    GroupSetsCount = 0;
                                }
                                else
                                {
                                    //find how many sets belong to this group
                                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup ";
                                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql, rs_MeasGroup.Tables[sqlTableName40].Rows[0]["MeasureStepID"]);
                                    modGlobal.gv_sql = string.Format("{0} and MeasureStepGroup = {1}",
                                        modGlobal.gv_sql, rs_MeasGroup.Tables[sqlTableName40].Rows[0]["MeasureStepGroup"]);
                                    //LDW rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName41 = "tbl_Setup_MeasureStepGroup";
                                    rs_MeasGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName41, rs_MeasGroup);

                                    //LDW rs_MeasGroup.MoveLast();
                                    li_GroupSets = rs_MeasGroup.Tables[sqlTableName41].Rows.Count;
                                    //LDW rs_MeasGroup.MoveFirst();
                                    GroupJoinOp = rs_MeasGroup.Tables[sqlTableName41].Rows[0]["JoinOperator"].ToString();

                                    GroupIndent = SingleIndent;
                                    SetIndent = GroupIndent + SingleIndent;

                                    if (MeasGroup != rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"].ToString())
                                    {
                                        GroupSetsCount = 0;
                                        lstMeasureDef1.Items.Add(string.Format("{0}GROUP {1}:", GroupIndent, rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"]));
                                        Support.SetItemData(lstMeasureDef1, lstMeasureDef1.Items.Count - 1, -1);
                                    }
                                    GroupSetsCount = GroupSetsCount + 1;
                                    MeasGroup = rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"].ToString();
                                }

                                lstMeasureDef1.Items.Add(string.Format("{0}Set {1}:", SetIndent, myRow6.Field<int>("MeasureCriteriaSet")));
                                Support.SetItemData(lstMeasureDef1, lstMeasureDef1.Items.Count - 1, -1);


                                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + myRow6.Field<int>("MeasureCriteriaSetID");
                                //LDW rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName42 = "tbl_Setup_MeasureCriteria";
                                rs_Crit = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName42, rs_Crit);

                                int rsCritRecCount = rs_Crit.Tables[sqlTableName42].Rows.Count;

                                //LDW if (rs_Crit.EOF)
                                for (int i = 0; i < rsCritRecCount; i++)
                                {
                                    DataRow myRowN = rs_Crit.Tables[sqlTableName42].Rows[i];
                                    int rowIndex = rs_Crit.Tables[sqlTableName42].Rows.IndexOf(myRowN);
                                    if (rowIndex == rsCritRecCount - 1)
                                    {
                                        return;
                                    }
                                }

                                //LDW rs_Crit.MoveLast();
                                li_TotCriteriaInSet = rs_Crit.Tables[sqlTableName42].Rows.Count;
                                //LDW rs_Crit.MoveFirst();

                                li_CritCount = 0;
                                //CRITERIA LOOP
                                //LDW while (!rs_Crit.EOF)
                                foreach (DataRow myRow7 in rs_Crit.Tables[sqlTableName42].Rows)
                                {
                                    li_CritCount = li_CritCount + 1;

                                    CritIndent = SetIndent + SingleIndent;

                                    if (li_TotCriteriaInSet == 1 | (li_TotCriteriaInSet > 1 & li_CritCount != li_TotCriteriaInSet))
                                    {
                                        lstMeasureDef1.Items.Add(string.Format("{0}{1} ({2})", CritIndent, myRow7.Field<string>("CriteriaTitle"),
                                            myRow7.Field<string>("JoinOperator")));
                                    }
                                    else
                                    {
                                        lstMeasureDef1.Items.Add(CritIndent + myRow7.Field<string>("CriteriaTitle"));
                                    }

                                    Support.SetItemData(lstMeasureDef1, lstMeasureDef1.Items.Count - 1, myRow7.Field<int>("measureCriteriaID"));


                                    //LDW rs_Crit.MoveNext();
                                    //go to the next criteria
                                }

                                if (li_TotSetInStep == li_SetCount)
                                {
                                    lstMeasureDef1.Items.Add(SetIndent + "-----------------");
                                }
                                else
                                {
                                    if (GroupSetsCount > 0 & GroupSetsCount == li_GroupSets)
                                    {
                                        lstMeasureDef1.Items.Add(GroupIndent + GroupJoinOp);
                                        GroupSetsCount = 0;
                                    }
                                    else
                                    {
                                        lstMeasureDef1.Items.Add(SetIndent + myRow6.Field<string>("JoinOperator"));
                                    }
                                }
                                Support.SetItemData(lstMeasureDef1, lstMeasureDef1.Items.Count - 1, -1);

                                //LDW modGlobal.gv_rs.MoveNext();
                                //go to the next set
                            }
                            modGlobal.gv_rs.Dispose();
                            //LDW rs_MeasStep.MoveNext();
                        }

                        rs_MeasStep.Dispose();

                        //return;
                        //LDW ErrHandler:
                        //LDW modGlobal.CheckForErrors();


                        break;

                    case 2:
                        lstMeasureDef2.Items.Clear();


                        CurrentVersion = modGlobal.GetCurrentVersion();

                        //Dim rs_MeasStep As System.Data.DataSet 
                        rs_MeasStep = null;


                        //MeasureStep = -100 means that it is the filter criteria
                        if (Index == 1)
                        {
                            modGlobal.gv_sql = "SELECT DISTINCT MeasureStep, MeasureStepID " + " FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " +
                                rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"] + " AND MeasureStep = -100 ";
                        }
                        else if (Index == 0 | Index == 2)
                        {
                            modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID, ms.GoToStep, m.CAT, ms.FlowchartActionID ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID ";
                            modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql, rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]);
                            modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 ";

                            if (Index == 0)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0) ";
                            }
                            else if (Index == 2)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
                            }
                        }

                        modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC";

                        //LDW rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName36a = "tbl_Setup_MeasureStep";
                        rs_MeasStep = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName36a, rs_MeasStep);

                        /*LDW if (rs_MeasStep.EOF)
                            return;*/

                        rsRecCount = rs_MeasStep.Tables[sqlTableName36a].Rows.Count;
                        for (int i = 0; i < rsRecCount; i++)
                        {
                            DataRow myRowY = rs_MeasStep.Tables[sqlTableName36a].Rows[i];
                            int rowIndex = rs_MeasStep.Tables[sqlTableName36a].Rows.IndexOf(myRowY);

                            if (rowIndex == rsRecCount - 1)
                            {
                                return;
                            }
                        }

                        //LDW rs_MeasStep.MoveLast();
                        li_TotStep = rs_MeasStep.Tables[sqlTableName36a].Rows.Count;
                        //LDW rs_MeasStep.MoveFirst();
                        li_StepCount = 0;

                        //STEP LOOP
                        //LDW while (!rs_MeasStep.EOF)
                        foreach (DataRow myRow5 in rs_MeasStep.Tables[sqlTableName36a].Rows)
                        {
                            li_StepCount = li_StepCount + 1;
                            ls_Suffix = "";

                            if (Index == 0 | Index == 2)
                            {
                                //show a signal if there is a substitute submission step
                                SubmitSubs = "";
                                modGlobal.gv_sql = " select * from tbl_setup_MeasureStepSubmitSubs where MeasureStepID = " + myRow5.Field<int>("MeasureStepID");

                                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName37 = "tbl_setup_MeasureStepSubmitSubs";
                                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName37, modGlobal.gv_rs);

                                if (modGlobal.gv_rs.Tables[sqlTableName37].Rows.Count > 0)
                                {
                                    SubmitSubs = " (With Submission Substitution) ";
                                }
                                modGlobal.gv_rs.Dispose();


                                StepLabel = string.Format("Step {0}{1}: = ", myRow5.Field<int>("measurestep"), SubmitSubs);

                                if (Information.IsDBNull(myRow5.Field<string>("CAT")))
                                {
                                    StepLabel = string.Format("{0}Go To Step {1}", StepLabel, Convert.ToString(myRow5.Field<int>("GoToStep")));
                                }
                                else
                                {
                                    StepLabel = StepLabel + myRow5.Field<string>("CAT");
                                }

                                //If InStr(1, "75,94,95,96,97,98,99,100,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 45 Then
                                if (((CurrentVersion <= 36 & myRow5.Field<int>("measurestep") == 43) | (CurrentVersion >= 37 & (myRow5.Field<int>("measurestep") == 44)) &
                                    (Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 75 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 94 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 95 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 96 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 97 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 98 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 99 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 100)))
                                {
                                    StepLabel = StepLabel + " *IMPUTED* ";
                                    //ElseIf InStr(1, "84,85,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 1 Then
                                }
                                else if ((myRow5.Field<int>("measurestep") == 1) &
                                    (Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 84 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 85))
                                {
                                    StepLabel = StepLabel + " *IMPUTED* ";
                                }

                                if (!Information.IsDBNull(myRow5.Field<int>("flowchartactionid")))
                                {
                                    modGlobal.gv_sql = "SELECT ActionDescription FROM tbl_Setup_MeasureFlowchartAction WHERE FlowchartActionID = " + myRow5.Field<int>("flowchartactionid");
                                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName38 = "tbl_Setup_MeasureFlowchartAction";
                                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName38, rs_Temp);

                                    StepLabel = string.Format("{0} (Action: {1})", StepLabel, myRow5.Field<string>("actionDescription"));
                                    rs_Temp.Dispose();
                                    rs_Temp = null;
                                }

                                lstMeasureDef2.Items.Add(StepLabel);
                                Support.SetItemData(lstMeasureDef2, lstMeasureDef2.Items.Count - 1, -1);
                            }

                            //SET QUERY
                            modGlobal.gv_sql = "SELECT * FROM ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureCriteriaSet mcs inner join  tbl_Setup_MeasureStep ms ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MeasureStepID = mcs.MeasureStepID ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_Setup_MeasureStepGroup as msg ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on mcs.measureCriteriaSetid = msg.measureCriteriaSetid ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ms.MeasureStepID = ";

                            if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0 | Information.IsDBNull(myRow5.Field<int>("MeasureStepID")))
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " (-1)";
                            }
                            else
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + myRow5.Field<int>("MeasureStepID");
                            }

                            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY msg.MeasureStepGroup, mcs.MeasureCriteriaSet ASC";
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName39 = "tbl_Setup_MeasureCriteriaSet";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName39, modGlobal.gv_rs);

                            //LDW if (modGlobal.gv_rs.EOF)
                            int moRecCount = modGlobal.gv_rs.Tables[sqlTableName39].Rows.Count;
                            for (int i = 0; i < moRecCount; i++)
                            {
                                DataRow myRowXer = modGlobal.gv_rs.Tables[sqlTableName39].Rows[i];
                                int rowIndex = modGlobal.gv_rs.Tables[sqlTableName39].Rows.IndexOf(myRowXer);

                                if (rowIndex == moRecCount - 1)
                                {
                                    return;
                                }
                            }

                            //LDW modGlobal.gv_rs.MoveLast();
                            li_TotSetInStep = modGlobal.gv_rs.Tables[sqlTableName39].Rows.Count;
                            //LDW modGlobal.gv_rs.MoveFirst();
                            li_SetCount = 0;
                            ls_MeasGroup = "";

                            // loop thru sets
                            //LDW while (!modGlobal.gv_rs.EOF)
                            foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName39].Rows)
                            {
                                li_SetCount = li_SetCount + 1;

                                //show signal if there is a grouping
                                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + myRow6.Field<int>("MeasureCriteriaSetID");
                                //LDW rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName40 = "tbl_Setup_MeasureStepGroup";
                                rs_MeasGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName40, rs_MeasGroup);

                                if (rs_MeasGroup.Tables[sqlTableName40].Rows.Count == 0)
                                {
                                    MeasGroup = "";
                                    GroupIndent = "";
                                    SetIndent = SingleIndent;
                                    GroupSetsCount = 0;
                                }
                                else
                                {
                                    //find how many sets belong to this group
                                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup ";
                                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}", modGlobal.gv_sql,
                                        rs_MeasGroup.Tables[sqlTableName40].Rows[0]["MeasureStepID"]);
                                    modGlobal.gv_sql = string.Format("{0} and MeasureStepGroup = {1}", modGlobal.gv_sql,
                                        rs_MeasGroup.Tables[sqlTableName40].Rows[0]["MeasureStepGroup"]);
                                    //LDW rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName41 = "tbl_Setup_MeasureStepGroup";
                                    rs_MeasGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName41, rs_MeasGroup);

                                    //LDW rs_MeasGroup.MoveLast();
                                    li_GroupSets = rs_MeasGroup.Tables[sqlTableName41].Rows.Count;
                                    //LDW rs_MeasGroup.MoveFirst();
                                    GroupJoinOp = rs_MeasGroup.Tables[sqlTableName41].Rows[0]["JoinOperator"].ToString();

                                    GroupIndent = SingleIndent;
                                    SetIndent = GroupIndent + SingleIndent;

                                    if (MeasGroup != rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"].ToString())
                                    {
                                        GroupSetsCount = 0;
                                        lstMeasureDef2.Items.Add(string.Format("{0}GROUP {1}:", GroupIndent, rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"]));
                                        Support.SetItemData(lstMeasureDef2, lstMeasureDef2.Items.Count - 1, -1);
                                    }
                                    GroupSetsCount = GroupSetsCount + 1;
                                    MeasGroup = rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"].ToString();
                                }

                                lstMeasureDef2.Items.Add(string.Format("{0}Set {1}:", SetIndent, myRow6.Field<int>("MeasureCriteriaSet")));
                                Support.SetItemData(lstMeasureDef2, lstMeasureDef2.Items.Count - 1, -1);


                                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + myRow6.Field<int>("MeasureCriteriaSetID");
                                //LDW rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName42 = "tbl_Setup_MeasureCriteria";
                                rs_Crit = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName42, rs_Crit);

                                int rsCritRecCount = rs_Crit.Tables[sqlTableName42].Rows.Count;

                                //LDW if (rs_Crit.EOF)
                                for (int i = 0; i < rsCritRecCount; i++)
                                {
                                    DataRow myRowN = rs_Crit.Tables[sqlTableName42].Rows[i];
                                    int rowIndex = rs_Crit.Tables[sqlTableName42].Rows.IndexOf(myRowN);
                                    if (rowIndex == rsCritRecCount - 1)
                                    {
                                        return;
                                    }
                                }

                                //LDW rs_Crit.MoveLast();
                                li_TotCriteriaInSet = rs_Crit.Tables[sqlTableName42].Rows.Count;
                                //LDW rs_Crit.MoveFirst();

                                li_CritCount = 0;
                                //CRITERIA LOOP
                                //LDW while (!rs_Crit.EOF)
                                foreach (DataRow myRow7 in rs_Crit.Tables[sqlTableName42].Rows)
                                {
                                    li_CritCount = li_CritCount + 1;

                                    CritIndent = SetIndent + SingleIndent;

                                    if (li_TotCriteriaInSet == 1 | (li_TotCriteriaInSet > 1 & li_CritCount != li_TotCriteriaInSet))
                                    {
                                        lstMeasureDef2.Items.Add(string.Format("{0}{1} ({2})", CritIndent,
                                            myRow7.Field<string>("CriteriaTitle"), myRow7.Field<string>("JoinOperator")));
                                    }
                                    else
                                    {
                                        lstMeasureDef2.Items.Add(CritIndent + myRow7.Field<string>("CriteriaTitle"));
                                    }

                                    Support.SetItemData(lstMeasureDef2, lstMeasureDef2.Items.Count - 1, myRow7.Field<int>("measureCriteriaID"));


                                    //LDW rs_Crit.MoveNext();
                                    //go to the next criteria
                                }

                                if (li_TotSetInStep == li_SetCount)
                                {
                                    lstMeasureDef2.Items.Add(SetIndent + "-----------------");
                                }
                                else
                                {
                                    if (GroupSetsCount > 0 & GroupSetsCount == li_GroupSets)
                                    {
                                        lstMeasureDef2.Items.Add(GroupIndent + GroupJoinOp);
                                        GroupSetsCount = 0;
                                    }
                                    else
                                    {
                                        lstMeasureDef2.Items.Add(SetIndent + myRow6.Field<string>("JoinOperator"));
                                    }
                                }
                                Support.SetItemData(lstMeasureDef2, lstMeasureDef2.Items.Count - 1, -1);

                                //LDW modGlobal.gv_rs.MoveNext();
                                //go to the next set
                            }
                            modGlobal.gv_rs.Dispose();
                            //LDW rs_MeasStep.MoveNext();
                        }

                        rs_MeasStep.Dispose();

                        //return;
                        //ErrHandler1:
                        //LDW modGlobal.CheckForErrors();

                        break;

                    default:
                        lstMeasureDef0.Items.Clear();


                        CurrentVersion = modGlobal.GetCurrentVersion();

                        //Dim rs_MeasStep As System.Data.DataSet 
                        rs_MeasStep = null;


                        //MeasureStep = -100 means that it is the filter criteria
                        if (Index == 1)
                        {
                            modGlobal.gv_sql = "SELECT DISTINCT MeasureStep, MeasureStepID " + " FROM tbl_Setup_MeasureStep ms " + " WHERE ms.MeasureID = " +
                                rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"] + " AND MeasureStep = -100 ";
                        }
                        else if (Index == 0 | Index == 2)
                        {
                            modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID, ms.GoToStep, m.CAT, ms.FlowchartActionID ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms left join tbl_MEASURE_CAT m ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.Measure_CATID = m.MEASURE_CATID ";
                            modGlobal.gv_sql = string.Format("{0} where ms.MeasureID = {1}", modGlobal.gv_sql, rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"]);
                            modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 ";

                            if (Index == 0)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND ((CAT_TYPE is null or CAT_TYPE = 'CI') AND IsRisk = 0) ";
                            }
                            else if (Index == 2)
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " AND (CAT_TYPE = 'RA' Or IsRisk = 1) ";
                            }

                        }

                        modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC";

                        //LDW rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName36b = "tbl_Setup_MeasureStep";
                        rs_MeasStep = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName36b, rs_MeasStep);

                        /*LDW if (rs_MeasStep.EOF)
                            return;*/

                        rsRecCount = rs_MeasStep.Tables[sqlTableName36b].Rows.Count;
                        for (int i = 0; i < rsRecCount; i++)
                        {
                            DataRow myRowY = rs_MeasStep.Tables[sqlTableName36b].Rows[i];
                            int rowIndex = rs_MeasStep.Tables[sqlTableName36b].Rows.IndexOf(myRowY);
                            if (rowIndex == rsRecCount - 1)
                            {
                                return;
                            }
                        }


                        //LDW rs_MeasStep.MoveLast();
                        li_TotStep = rs_MeasStep.Tables[sqlTableName36b].Rows.Count;
                        //LDW rs_MeasStep.MoveFirst();
                        li_StepCount = 0;

                        //STEP LOOP
                        //LDW while (!rs_MeasStep.EOF)
                        foreach (DataRow myRow5 in rs_MeasStep.Tables[sqlTableName36b].Rows)
                        {
                            li_StepCount = li_StepCount + 1;
                            ls_Suffix = "";

                            if (Index == 0 | Index == 2)
                            {
                                //show a signal if there is a substitute submission step
                                SubmitSubs = "";
                                modGlobal.gv_sql = " select * from tbl_setup_MeasureStepSubmitSubs where MeasureStepID = " + myRow5.Field<int>("MeasureStepID");

                                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName37 = "tbl_setup_MeasureStepSubmitSubs";
                                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName37, modGlobal.gv_rs);
                                if (modGlobal.gv_rs.Tables[sqlTableName37].Rows.Count > 0)
                                {
                                    SubmitSubs = " (With Submission Substitution) ";
                                }
                                modGlobal.gv_rs.Dispose();


                                StepLabel = string.Format("Step {0}{1}: = ", myRow5.Field<int>("measurestep"), SubmitSubs);
                                if (Information.IsDBNull(myRow5.Field<string>("CAT")))
                                {
                                    StepLabel = string.Format("{0}Go To Step {1}", StepLabel, Convert.ToString(myRow5.Field<int>("GoToStep")));
                                }
                                else
                                {
                                    StepLabel = StepLabel + myRow5.Field<string>("CAT");
                                }

                                //If InStr(1, "75,94,95,96,97,98,99,100,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 45 Then
                                if (((CurrentVersion <= 36 & myRow5.Field<int>("measurestep") == 43) | (CurrentVersion >= 37 & (myRow5.Field<int>("measurestep") == 44)) &
                                    (Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 75 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 94 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 95 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 96 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 97 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 98 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 99 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 100)))
                                {
                                    StepLabel = StepLabel + " *IMPUTED* ";
                                    //ElseIf InStr(1, "84,85,", CStr(rdcMeasureList.Resultset!IndicatorID) & ",") > 0 And rs_MeasStep!measurestep = 1 Then
                                }
                                else if ((myRow5.Field<int>("measurestep") == 1) &
                                    (Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 84 |
                                    Convert.ToDouble(Convert.ToString(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["IndicatorID"])) == 85))
                                {
                                    StepLabel = StepLabel + " *IMPUTED* ";
                                }

                                if (!Information.IsDBNull(myRow5.Field<int>("flowchartactionid")))
                                {
                                    modGlobal.gv_sql = "SELECT ActionDescription FROM tbl_Setup_MeasureFlowchartAction WHERE FlowchartActionID = " + myRow5.Field<int>("flowchartactionid");
                                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName38 = "tbl_Setup_MeasureFlowchartAction";
                                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName38, rs_Temp);


                                    StepLabel = string.Format("{0} (Action: {1})", StepLabel, myRow5.Field<string>("actionDescription"));
                                    rs_Temp.Dispose();
                                    rs_Temp = null;
                                }

                                lstMeasureDef0.Items.Add(StepLabel);
                                Support.SetItemData(lstMeasureDef0, lstMeasureDef0.Items.Count - 1, -1);
                            }

                            //SET QUERY
                            modGlobal.gv_sql = "SELECT * FROM ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureCriteriaSet mcs inner join  tbl_Setup_MeasureStep ms ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MeasureStepID = mcs.MeasureStepID ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_Setup_MeasureStepGroup as msg ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " on mcs.measureCriteriaSetid = msg.measureCriteriaSetid ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ms.MeasureStepID = ";

                            if (rdcMeasureList.Tables[rdcMeasureListTable].Rows.Count == 0 | Information.IsDBNull(myRow5.Field<int>("MeasureStepID")))
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + " (-1)";
                            }
                            else
                            {
                                modGlobal.gv_sql = modGlobal.gv_sql + myRow5.Field<int>("MeasureStepID");
                            }
                            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY msg.MeasureStepGroup, mcs.MeasureCriteriaSet ASC";
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName39 = "tbl_Setup_MeasureCriteriaSet";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName39, modGlobal.gv_rs);

                            //LDW if (modGlobal.gv_rs.EOF)
                            int moRecCount = modGlobal.gv_rs.Tables[sqlTableName39].Rows.Count;
                            for (int i = 0; i < moRecCount; i++)
                            {
                                DataRow myRowXer = modGlobal.gv_rs.Tables[sqlTableName39].Rows[i];
                                int rowIndex = modGlobal.gv_rs.Tables[sqlTableName39].Rows.IndexOf(myRowXer);

                                if (rowIndex == moRecCount - 1)
                                {
                                    return;
                                }
                            }

                            //LDW modGlobal.gv_rs.MoveLast();
                            li_TotSetInStep = modGlobal.gv_rs.Tables[sqlTableName39].Rows.Count;
                            //LDW modGlobal.gv_rs.MoveFirst();
                            li_SetCount = 0;
                            ls_MeasGroup = "";

                            // loop thru sets
                            //LDW while (!modGlobal.gv_rs.EOF)
                            foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName39].Rows)
                            {
                                li_SetCount = li_SetCount + 1;

                                //show signal if there is a grouping
                                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureCriteriaSetID = " + myRow6.Field<int>("MeasureCriteriaSetID");
                                //LDW rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName40 = "tbl_Setup_MeasureStepGroup";
                                rs_MeasGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName40, rs_MeasGroup);

                                if (rs_MeasGroup.Tables[sqlTableName40].Rows.Count == 0)
                                {
                                    MeasGroup = "";
                                    GroupIndent = "";
                                    SetIndent = SingleIndent;
                                    GroupSetsCount = 0;
                                }
                                else
                                {
                                    //find how many sets belong to this group
                                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup ";
                                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureStepID = {1}",
                                        modGlobal.gv_sql, rs_MeasGroup.Tables[sqlTableName40].Rows[0]["MeasureStepID"]);
                                    modGlobal.gv_sql = string.Format("{0} and MeasureStepGroup = {1}",
                                        modGlobal.gv_sql, rs_MeasGroup.Tables[sqlTableName40].Rows[0]["MeasureStepGroup"]);
                                    //LDW rs_MeasGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    const string sqlTableName41 = "tbl_Setup_MeasureStepGroup";
                                    rs_MeasGroup = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName41, rs_MeasGroup);

                                    //LDW rs_MeasGroup.MoveLast();
                                    li_GroupSets = rs_MeasGroup.Tables[sqlTableName41].Rows.Count;
                                    //LDW rs_MeasGroup.MoveFirst();
                                    GroupJoinOp = rs_MeasGroup.Tables[sqlTableName41].Rows[0]["JoinOperator"].ToString();

                                    GroupIndent = SingleIndent;
                                    SetIndent = GroupIndent + SingleIndent;

                                    if (MeasGroup != rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"].ToString())
                                    {
                                        GroupSetsCount = 0;
                                        lstMeasureDef0.Items.Add(string.Format("{0}GROUP {1}:", GroupIndent, rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"]));
                                        Support.SetItemData(lstMeasureDef0, lstMeasureDef0.Items.Count - 1, -1);
                                    }
                                    GroupSetsCount = GroupSetsCount + 1;
                                    MeasGroup = rs_MeasGroup.Tables[sqlTableName41].Rows[0]["MeasureStepGroup"].ToString();
                                }

                                lstMeasureDef0.Items.Add(string.Format("{0}Set {1}:", SetIndent, myRow6.Field<int>("MeasureCriteriaSet")));
                                Support.SetItemData(lstMeasureDef0, lstMeasureDef0.Items.Count - 1, -1);


                                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + myRow6.Field<int>("MeasureCriteriaSetID");
                                //LDW rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName42 = "tbl_Setup_MeasureCriteria";
                                rs_Crit = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName42, rs_Crit);

                                int rsCritRecCount = rs_Crit.Tables[sqlTableName42].Rows.Count;

                                //LDW if (rs_Crit.EOF)
                                for (int i = 0; i < rsCritRecCount; i++)
                                {
                                    DataRow myRowN = rs_Crit.Tables[sqlTableName42].Rows[i];
                                    int rowIndex = rs_Crit.Tables[sqlTableName42].Rows.IndexOf(myRowN);

                                    if (rowIndex == rsCritRecCount - 1)
                                    {
                                        return;
                                    }
                                }

                                //LDW rs_Crit.MoveLast();
                                li_TotCriteriaInSet = rs_Crit.Tables[sqlTableName42].Rows.Count;
                                //LDW rs_Crit.MoveFirst();

                                li_CritCount = 0;
                                //CRITERIA LOOP
                                //LDW while (!rs_Crit.EOF)
                                foreach (DataRow myRow7 in rs_Crit.Tables[sqlTableName42].Rows)
                                {
                                    li_CritCount = li_CritCount + 1;

                                    CritIndent = SetIndent + SingleIndent;

                                    if (li_TotCriteriaInSet == 1 | (li_TotCriteriaInSet > 1 & li_CritCount != li_TotCriteriaInSet))
                                    {
                                        lstMeasureDef0.Items.Add(string.Format("{0}{1} ({2})", CritIndent, myRow7.Field<string>("CriteriaTitle"),
                                            myRow7.Field<string>("JoinOperator")));
                                    }
                                    else
                                    {
                                        lstMeasureDef0.Items.Add(CritIndent + myRow7.Field<string>("CriteriaTitle"));
                                    }

                                    Support.SetItemData(lstMeasureDef0, lstMeasureDef0.Items.Count - 1, myRow7.Field<int>("measureCriteriaID"));


                                    //LDW rs_Crit.MoveNext();
                                    //go to the next criteria
                                }
                                if (li_TotSetInStep == li_SetCount)
                                {
                                    lstMeasureDef0.Items.Add(SetIndent + "-----------------");
                                }
                                else
                                {
                                    if (GroupSetsCount > 0 & GroupSetsCount == li_GroupSets)
                                    {
                                        lstMeasureDef0.Items.Add(GroupIndent + GroupJoinOp);
                                        GroupSetsCount = 0;
                                    }
                                    else
                                    {
                                        lstMeasureDef0.Items.Add(SetIndent + myRow6.Field<string>("JoinOperator"));
                                    }
                                }
                                Support.SetItemData(lstMeasureDef0, lstMeasureDef0.Items.Count - 1, -1);

                                //LDW modGlobal.gv_rs.MoveNext();
                                //go to the next set
                            }
                            modGlobal.gv_rs.Dispose();
                            //LDW rs_MeasStep.MoveNext();
                        }

                        rs_MeasStep.Dispose();

                        //return;
                        //ErrHandler2:
                        //LDW modGlobal.CheckForErrors();

                        break;
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

        private void RefreshRiskAdjusted()
        {
            try
            {
                if (Convert.ToInt32(rdcMeasureList.Tables[rdcMeasureListTable].Rows[0]["RiskAdjusted"]) == 0)
                {
                    if (SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex == 2)
                    {
                        SSTabCriteria.ActiveWindow.DockTabStrip.SelectedIndex = 0;

                        DialogResult ds = RadMessageBox.Show(this, "You can not assign risk criteria to an indicator that is not Risk Adjusted",
                            "Not Defined as Risk Adjusted", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds.ToString();
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

        static bool InitStaticVariableHelper(StaticLocalInitFlag flag)
        {
            if (flag.State == 0)
            {
                flag.State = 2;
                return true;
            }
            else if (flag.State == 2)
            {
                throw new IncompleteInitialization();
            }
            else
            {
                return false;
            }
        }
        //Not used
        /*LDW private void cmdCopyMeasureSteps_Click()
        {
            object CSet = null;
            string NewCSet = null;

            modGlobal.gv_Action = "NotDefined";

            if (lstMeasureDef[0].SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a criteria step to copy.");
                return;
            }

            if (Support.GetItemData(lstMeasureDef[0], lstMeasureDef[0].SelectedIndex) < 0)
            {
                RadMessageBox.Show("Select a criteria set to copy.");
                return;
            }

            System.Data.DataSet thisrs = new DataSet();
            if (RadMessageBox.Show("Are you sure you want to create a new step as a copy of the selected step?", MsgBoxStyle.YesNo, "Duplicate Criteria Set") == MsgBoxResult.Yes)
            {
                modGlobal.gv_sql = "Select MeasureStep from tbl_setup_measurecriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where measurecriteriaid = " + Support.GetItemData(lstMeasureDef[0], lstMeasureDef[0].SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CSet = modGlobal.gv_rs.rdoColumns["measurestep"].Value;

                modGlobal.gv_sql = "Select max(MeasureStep) + 1 as newcset  from tbl_setup_measurecriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Measureid = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                NewCSet = modGlobal.gv_rs.rdoColumns["NewCSet"].Value;
                modGlobal.gv_rs.Close();

                modGlobal.gv_sql = "Select * from tbl_setup_measurecriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Measureid = " + rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value;
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureStep = " + CSet;
                thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!thisrs.EOF)
                {
                    modGlobal.gv_sql = "insert into tbl_setup_measurecriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureID, Measure_CatID, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, FieldValue, DestDDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, MeasureStep)  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "MeasureID, Measure_CatID, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, FieldValue, DestDDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, " + NewCSet;
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_measurecriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where measurecriteriaID = " + thisrs.rdoColumns["measureCriteriaID"].Value;
                    modGlobal.gv_cn.Execute(modGlobal.gv_sql);

                    thisrs.MoveNext();
                }
                thisrs.Close();

                RefreshMeasureCriteria();

            }
        }   
        
         		private void cmdDupSetLogic_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;
			Index = SSTabCriteria.SelectedIndex;

			if (lstMeasureDef[Index].SelectedItems.Count > 1 | Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex) < 0) {
				RadMessageBox.Show("Select one criteria set to copy.");
				return;
			}

			modGlobal.gv_sql = "select mcs.MeasureCriteriaSetID from " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND mc.MeasureCriteriaID = " + Support.GetItemData(lstMeasureDef[Index], lstMeasureDef[Index].SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			My.MyProject.Forms.dlgMeasureCreateSetLogic.il_MeasureCriteriaSetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
			modGlobal.gv_rs.Close();

			My.MyProject.Forms.dlgMeasureCreateSetLogic.ShowDialog();

		}

        		public void mnuDuplicateMeasure_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = 0;

			Index = SSTabCriteria.SelectedIndex;

			//If lstMeasureDef(Index).SelCount > 0 Then

			My.MyProject.Forms.frmMeasureCopyCriteria.SetCopyType(ref "M");
			My.MyProject.Forms.frmMeasureCopyCriteria.SetMeasureID(ref rdcMeasureList.Resultset.rdoColumns["IndicatorID"].Value);
			My.MyProject.Forms.frmMeasureCopyCriteria.ShowDialog();
			//End If
		}

*/

    }
}
