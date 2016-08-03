using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
// ERROR: Not supported in C#: OptionDeclaration

namespace COP2001
{
    internal partial class OldfrmMeasureCopyCriteria : System.Windows.Forms.Form
    {
        private string[] is_MeasureCriteriaIDs;
        //M' - measure
        //S' - submit
        private string is_CopyType;
        private string[] is_SubmitCriteriaIDs;
        private string is_MeasureID;
        private string is_SubGroupID;

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
            is_MeasureCriteriaIDs = Microsoft.VisualBasic.Compatibility.VB6.Support.CopyArray(MeasureCriteriaID);
        }

        public void SetSubmitCriteriaID(string[] SubmitCriteriaID)
        {
            is_SubmitCriteriaIDs = Microsoft.VisualBasic.Compatibility.VB6.Support.CopyArray(SubmitCriteriaID);
        }

        public void SetCopyType(string CopyType)
        {
            is_CopyType = CopyType;
        }

        //UPGRADE_WARNING: Event cboMeasures.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboMeasures_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshMeasureSteps();
        }

        //UPGRADE_WARNING: Event cboStep.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboStep_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshMeasureStepSets();
        }

        private void cmdCopy_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string is_subgroup = null;

            if (rboCopyTo1.Checked)
            {
                //submission
                if (is_CopyType == "M" & string.IsNullOrEmpty(is_MeasureID))
                {
                    CopyFromMeasureToSubmit();
                }
                else if (is_CopyType == "S" & string.IsNullOrEmpty(is_SubGroupID))
                {
                    CopyFromSubmitToSubmit();
                    //UPGRADE_WARNING: Couldn't resolve default property of object is_subgroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                }
                else if (!string.IsNullOrEmpty(is_subgroup) | !string.IsNullOrEmpty(is_MeasureID))
                {
                    RadMessageBox.Show("This ability is not implemented yet");
                }

            }
            else if (rboCopyTo2.Checked)
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

        private void cmdCopySetp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rboCopyTo1.Checked)
            {
                RadMessageBox.Show("With this feature, you can only copy the entire step from one measure to another measure.");
                return;
            }
            else if (rboCopyTo2.Checked)
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
            int li_GoToStep;
            int li_MeasureStep;
            int NewSetID;
            System.Data.DataSet rs_critSet = null;

            // ERROR: Not supported in C#: OnErrorStatement


            modGlobal.gv_sql = "SELECT ms.MeasureID, ms.MeasureStep, ms.MeasureStepID, ms.Measure_CATID, ms.gotostep FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID in (" + Strings.Join(is_MeasureCriteriaIDs, ", ") + ")";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            li_MeasureID = modGlobal.gv_rs.rdoColumns["MeasureID"].Value;

            li_CatID = 0;
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["measure_catid"].Value))
            {
                li_CatID = modGlobal.gv_rs.rdoColumns["measure_catid"].Value;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            li_GoToStep = 0;
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["GoToStep"].Value))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                li_GoToStep = modGlobal.gv_rs.rdoColumns["GoToStep"].Value;
            }

            li_MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            li_MeasureStep = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);
            modGlobal.gv_rs.Dispose();

            //step should only be copied into a blank one
            modGlobal.gv_sql = "Select * from tbl_Setup_MeasureCriteriaSet mcs inner join tbl_setup_MeasureStep ms ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on mcs.measurestepid = ms.measurestepid";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
            //UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " and ms.MeasureStep = " + li_MeasureStep;
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                RadMessageBox.Show("The step can be copied only to another step that does not have any sets.");
                return;
            }

            //insert new step record
            modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureID, MeasureStep, Measure_CATID, GoToStep ) VALUES ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (" + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex) + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object li_MeasureStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + li_MeasureStep + ", ";
            if (li_CatID > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + li_CatID + ",";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " null,";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (li_GoToStep > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object li_GoToStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + li_GoToStep;
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " null";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + ")";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            //UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            li_NewStepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

            //insert new set record
            modGlobal.gv_sql = "SELECT * FROM  tbl_setup_measurecriteriaset ";
            modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + li_MeasureStepID;

            rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            while (!rs_critSet.EOF)
            {

                modGlobal.gv_sql = "INSERT INTO tbl_Setup_measureCriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (MeasureCriteriaSet, MeasureStepID, JoinOperator) ";
                //UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  SELECT MeasureCriteriaSet, " + li_NewStepID;
                modGlobal.gv_sql = modGlobal.gv_sql + ", JoinOperator ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureCriteriaSetID = " + rs_critSet.rdoColumns["MeasureCriteriaSetID"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "SELECT max(MeasureCriteriaSetID) as newsetID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_measurecriteriaset ";
                //UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + li_NewStepID;
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewSetID = modGlobal.gv_rs.rdoColumns["NewSetID"].Value;

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
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
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
                modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetID = " + rs_critSet.rdoColumns["MeasureCriteriaSetID"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object li_NewStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " SELECT " + li_NewStepID + ", " + NewSetID;
                modGlobal.gv_sql = modGlobal.gv_sql + ", MeasureStepGroup, JoinOperator ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  From tbl_Setup_MeasureStepGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     WHERE MeasureCriteriaSetID = " + rs_critSet.rdoColumns["MeasureCriteriaSetID"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                rs_critSet.MoveNext();
            }

            rs_critSet.Close();
            this.Close();

            return;
            ErrHandler:

            modGlobal.CheckForErrors();

        }

        private void frmMeasureCopyCriteria_Load(System.Object eventSender, System.EventArgs eventArgs)
        {

            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

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
                    modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID in (" + Strings.Join(is_MeasureCriteriaIDs, ",") + ")";
                }
            }
            else if (is_CopyType == "S")
            {
                if (!string.IsNullOrEmpty(is_SubGroupID))
                {
                    modGlobal.gv_sql = "select GroupName + ' / ' + sgr.Title + ' / ' + sg.Title as CriteriaTitle" + " from tbl_setup_submitsubgroup sg, tbl_setup_submitgroup g, tbl_setup_submitgrouprow sgr " + " Where sg.GroupRowID = sgr.GroupRowID And g.GroupID = sgr.GroupID AND sg.SubGroupID = " + is_SubGroupID;
                }
                else
                {
                    modGlobal.gv_sql = "Select CriteriaTitle from tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where submitcriteriaid in (" + Strings.Join(is_SubmitCriteriaIDs, ",") + ")";
                }
            }

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            lblCopyFrom.Text = "";
            while (!modGlobal.gv_rs.EOF)
            {
                lblCopyFrom.Text = lblCopyFrom.Text + ", " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;
                modGlobal.gv_rs.MoveNext();
            }

        }

        //UPGRADE_WARNING: Event cboColumns.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboColumns_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshSubmitSetList();
        }

        //UPGRADE_WARNING: Event cboSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
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

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private bool CopyStepandSetRecords()
        {
            bool functionReturnValue = false;
            object li_StepID = null;
            int li_SetID = 0;
            object rs_MeasSet = null;
            object rs_Crit = null;
            System.Data.DataSet rs_Step = null;
            int li_MaxStep = 0;
            int li_cnt = 0;
            int li_StepCnt = 0;

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

            modGlobal.gv_sql = "SELECT max(MeasureStep) as MaxStep " + " FROM tbl_Setup_MeasureStep WHERE  " + " MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //nz was replaced
            //li_MaxStep = Nz(gv_rs!MaxStep, 0)
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MaxStep"].Value))
            {
                li_MaxStep = 0;
            }
            else
            {
                li_MaxStep = modGlobal.gv_rs.rdoColumns["MaxStep"].Value;
            }

            if (li_MaxStep != 0)
            {
                if (li_MaxStep >= Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex))
                {
                    RadMessageBox.Show("You must select a new step to start copying to");
                    functionReturnValue = false;
                    return functionReturnValue;
                }
            }

            //If Not gv_rs.EOF Then
            //    MsgBox "Please choose a new measure", vbCritical, "Only Copy to Measure without Flowchart!"
            //    CopyStepandSetRecords = False
            //    Exit Function
            //End If

            modGlobal.gv_rs.Dispose();

            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStep WHERE MeasureID = " + is_MeasureID + " ORDER BY MeasureStep";

            rs_Step = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            li_cnt = 1;
            li_StepCnt = 1;

            while (!rs_Step.EOF)
            {
                modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (MeasureStep, MeasureID, Measure_CATID, GoToStep,IsRisk ) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " VALUES (";
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                modGlobal.gv_sql = modGlobal.gv_sql + (Information.IsDBNull(rs_Step.rdoColumns["measure_catid"].Value) & Information.IsDBNull(rs_Step.rdoColumns["GoToStep"].Value) ? -100 : li_MaxStep + li_StepCnt);
                modGlobal.gv_sql = modGlobal.gv_sql + ", " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                modGlobal.gv_sql = modGlobal.gv_sql + ", " + (Information.IsDBNull(rs_Step.rdoColumns["measure_catid"].Value) ? "NULL" : rs_Step.rdoColumns["measure_catid"].Value);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                modGlobal.gv_sql = modGlobal.gv_sql + ", " + (Information.IsDBNull(rs_Step.rdoColumns["GoToStep"].Value) ? "NULL" : rs_Step.rdoColumns["GoToStep"].Value) + ", " + (rs_Step.rdoColumns["isrisk"].Value ? "1" : "0");
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                li_StepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE MeasureStepID = " + rs_Step.rdoColumns["MeasureStepID"].Value;
                rs_MeasSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                while (!rs_MeasSet.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet!JoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet!MeasureCriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaSet (MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES " + "(" + rs_MeasSet["MeasureCriteriaSet"] + ", " + li_StepID + ", '" + rs_MeasSet["JoinOperator"] + "')";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSet");
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet!MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteria (MeasureCriteriaSetID, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, " + " LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, State, RecordStatus, MeasureFieldGroupLogicID, MultSelAny) " + " SELECT " + li_SetID + ", CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, " + " LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, State, RecordStatus, MeasureFieldGroupLogicID, MultSelAny " + " FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + rs_MeasSet["MeasureCriteriaSetID"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet!MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet!MeasureCriteriaSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStepGroup (MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) " + " SELECT " + li_StepID + ", " + li_SetID + ", MeasureStepGroup, JoinOperator FROM tbl_Setup_measureStepGroup WHERE " + " MeasureCriteriaSetID = " + rs_MeasSet["MeasureCriteriaSetID"] + " AND MeasureStepID = " + rs_MeasSet["MeasureStepID"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    rs_MeasSet.MoveNext();
                    li_cnt = li_cnt + 1;
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_MeasSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                rs_MeasSet.Close();

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if ((!Information.IsDBNull(rs_Step.rdoColumns["measure_catid"].Value)) | (!Information.IsDBNull(rs_Step.rdoColumns["GoToStep"].Value)))
                {
                    li_StepCnt = li_StepCnt + 1;
                }

                rs_Step.MoveNext();
            }
            rs_Step.Close();

            functionReturnValue = true;
            return functionReturnValue;
            ErrHandler:


            modGlobal.CheckForErrors();
            functionReturnValue = false;
            return functionReturnValue;
        }

        private int InsertStepandSetRecords()
        {
            int functionReturnValue = 0;
            int li_StepID;
            int li_SetID = 0;
            int li_OldStep = 0;
            string ls_DefJoin = null;

            li_SetID = -1;

            // ERROR: Not supported in C#: OnErrorStatement

            li_OldStep = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);

            modGlobal.gv_sql = "SELECT ms.* FROM tbl_Setup_MeasureStep as ms ";
            modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT as mc ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.measure_CATID = mc.Measure_CATID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ms.MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureStep = " + li_OldStep;

            if (Strings.InStr(cboStep.Text, "Risk") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND mc.CAT_TYPE = 'RA'";
            }
            else if (Strings.InStr(cboStep.Text, "Flow") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (mc.CAT_TYPE is null or mc.CAT_TYPE = 'CI')";
            }

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

            System.Data.DataSet rs_catid = null;
            if (modGlobal.gv_rs.EOF)
            {

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStep ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep = " + li_OldStep;
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

                modGlobal.gv_rs.AddNew();
                modGlobal.gv_rs.rdoColumns["MeasureID"].Value = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
                modGlobal.gv_rs.rdoColumns["measurestep"].Value = li_OldStep;


                //Filters do not get assigned to a category
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Strings.InStr(cboStep.Text, "Flow") > 0 & !Information.IsDBNull(modGlobal.gv_rs.rdoColumns["measure_catid"].Value))
                {
                    rs_catid = modGlobal.gv_cn.OpenResultset("SELECT MEASURE_CATID FROM tbl_Measure_Cat " + " WHERE CAT_TYPE = 'CI'");
                    if (!rs_catid.EOF)
                    {
                        modGlobal.gv_rs.rdoColumns["measure_catid"].Value = rs_catid.rdoColumns["measure_catid"].Value;
                    }
                    rs_catid.Close();

                }
                else if (Strings.InStr(cboStep.Text, "Risk") > 0)
                {
                    rs_catid = modGlobal.gv_cn.OpenResultset("SELECT MEASURE_CATID FROM tbl_Measure_Cat " + " WHERE CAT_TYPE = 'RA'");
                    if (!rs_catid.EOF)
                    {
                        modGlobal.gv_rs.rdoColumns["measure_catid"].Value = rs_catid.rdoColumns["measure_catid"].Value;
                    }
                    rs_catid.Close();

                }

                modGlobal.gv_rs.Update();
                modGlobal.gv_rs.Dispose();

                //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                li_StepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                li_StepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
                modGlobal.gv_rs.Dispose();
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet " + " WHERE MeasureStepID = " + li_StepID + " AND MeasureCriteriaSet = " + (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex) - 1);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (!modGlobal.gv_rs.EOF)
            {
                ls_DefJoin = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
            }
            else
            {
                ls_DefJoin = "AND";
            }
            modGlobal.gv_rs.Dispose();

            //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet " + " WHERE MeasureStepID = " + li_StepID + " AND MeasureCriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

            if (modGlobal.gv_rs.EOF)
            {
                //default join to AND
                modGlobal.gv_rs.AddNew();
                modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value = li_StepID;
                modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = ls_DefJoin;
                modGlobal.gv_rs.Update();
                modGlobal.gv_rs.Dispose();

                li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSet");
            }
            else
            {
                li_SetID = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
                modGlobal.gv_rs.Dispose();
            }

            functionReturnValue = li_SetID;
            return functionReturnValue;
            ErrHandler:

            modGlobal.CheckForErrors();
            return functionReturnValue;
        }

        private void CopyFromMeasureToMeasure()
        {
            int li_SetID = 0;

            //On Error GoTo ErrHandler

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
                        modGlobal.gv_sql = modGlobal.gv_sql + li_SetID + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "', MeasureFieldGroupLogicID, MultSelAny ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID in (" + Strings.Join(is_MeasureCriteriaIDs, ", ") + ")";

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        this.Close();
                    }
                }
            }
            else
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStep WHERE  " + " MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (modGlobal.gv_rs.RowCount > 0)
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
            ErrHandler:

            modGlobal.CheckForErrors();

        }

        private void CopyFromSubmitToMeasure()
        {
            int li_SetID;
            int li_MeasureCriteriaSetID = 0;

            // ERROR: Not supported in C#: OnErrorStatement


            if (string.IsNullOrEmpty(is_SubGroupID))
            {
                if (cboStep.SelectedIndex < 0 | cboSet.SelectedIndex < 0 | cboMeasures.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Define the definition of the new criteria.");
                }
                else
                {
                    //copy the criteria
                    //UPGRADE_WARNING: Couldn't resolve default property of object li_SetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    li_SetID = InsertStepandSetRecords();

                    //UPGRADE_WARNING: Couldn't resolve default property of object li_SetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
                        //UPGRADE_WARNING: Couldn't resolve default property of object li_SetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + li_SetID + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "'";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCriteriaID in (" + Strings.Join(is_SubmitCriteriaIDs, ",") + ")";

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
            ErrHandler:

            modGlobal.CheckForErrors();

        }

        private bool CopySubmitTOMeasure()
        {
            bool functionReturnValue = false;
            object li_StepID = null;
            int li_SetID = 0;
            System.Data.DataSet rs_Set = null;

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

            modGlobal.gv_sql = "SELECT * " + " FROM tbl_Setup_MeasureStep WHERE" + " MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex) + " AND MeasureStep = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);

            if (Strings.InStr(cboStep.Text, "Risk") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')";
            }
            else if (Strings.InStr(cboStep.Text, "Flow") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')";
            }

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (!modGlobal.gv_rs.EOF)
            {
                RadMessageBox.Show("Please choose a new step", MsgBoxStyle.Critical, "Only Copy to Measure Step without Criteria!");
                functionReturnValue = false;
                return functionReturnValue;
            }
            modGlobal.gv_rs.Dispose();

            if (Strings.InStr(cboStep.Text, "Risk") > 0)
            {
                modGlobal.gv_sql = "SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA'";
            }
            else if (Strings.InStr(cboStep.Text, "Flow") > 0)
            {
                modGlobal.gv_sql = "SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI'";
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureStep (MeasureStep, MeasureID, Measure_CATID) VALUES (" + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex) + " , " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex) + ", " + modGlobal.gv_rs.rdoColumns["measure_catid"].Value + ")";
            modGlobal.gv_rs.Dispose();

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            li_StepID = modGlobal.GetLastID("tbl_Setup_MeasureStep");

            modGlobal.gv_sql = "SELECT CriteriaSet FROM tbl_Setup_SubmitCriteria " + " WHERE subgroupid = " + is_SubGroupID + " GROUP BY CriteriaSet ORDER BY CriteriaSet";
            rs_Set = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            while (!rs_Set.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object li_StepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteriaSet (MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES " + "(" + rs_Set.rdoColumns["CriteriaSet"].Value + ", " + li_StepID + ", 'AND')";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                li_SetID = modGlobal.GetLastID("tbl_Setup_MeasureCriteriaSet");

                modGlobal.gv_sql = "INSERT INTO tbl_Setup_MeasureCriteria (MeasureCriteriaSetID, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, " + " LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID) " + " SELECT " + li_SetID + ", CriteriaTitle, DDID1, DDID2, ValueOperator, [Value], DestDDID, " + " LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID " + " from tbl_setup_SubmitCriteria where subgroupid = " + is_SubGroupID + " AND CriteriaSet = " + rs_Set.rdoColumns["CriteriaSet"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                rs_Set.MoveNext();
            }
            rs_Set.Close();

            functionReturnValue = true;
            return functionReturnValue;
            ErrHandler:


            modGlobal.CheckForErrors();
            functionReturnValue = false;
            return functionReturnValue;
        }

        private void CopyFromSubmitToSubmit()
        {
            object NewCritID = null;
            if (cboSet.SelectedIndex < 0 | cboColumns.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
            {
                RadMessageBox.Show("Define the definition of the new criteria.");
            }
            else
            {
                //copy the criteria
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_Action = "Add";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_SubmitCriteria", ref "SubmitCriteriaID");
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
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboColumns, cboColumns.SelectedIndex) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "', ";
                modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCriteriaID in (" + Strings.Join(is_SubmitCriteriaIDs, ",") + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
            }
        }

        private void CopyFromMeasureToSubmit()
        {
            object NewCritID = null;
            if (cboSet.SelectedIndex < 0 | cboColumns.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
            {
                RadMessageBox.Show("Define the definition of the new criteria.");
            }
            else
            {
                //copy the criteria
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_Action = "Add";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_SubmitCriteria", ref "SubmitCriteriaID");
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
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboColumns, cboColumns.SelectedIndex) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "', ";
                modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID in (" + Strings.Join(is_MeasureCriteriaIDs, ", ") + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                this.Close();
            }

        }

        private void RefreshSubmitSetDef()
        {

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboColumns, cboColumns.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount == 0)
            {
                cboJoinOperator.Text = "";
                cboJoinOperator.Enabled = true;
            }
            else
            {
                cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                cboJoinOperator.Enabled = false;
            }
            modGlobal.gv_rs.Dispose();

        }

        private void RefreshSubmitSetList()
        {
            int SetIndex;
            cboSet.Items.Clear();

            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
            if (cboColumns.SelectedIndex < 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboColumns, cboColumns.SelectedIndex);
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of criteria
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetIndex = 1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cboSet.Items.Add("Set " + SetIndex);
                //UPGRADE_ISSUE: ComboBox property cboSet.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboSet, cboSet.Items.Count - 1, SetIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex + 1;
                modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            //always add a new one to the list in addition to the previous ones
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + SetIndex, SetIndex));

        }

        private void RefreshSubmitColumnList()
        {
            int thisSubGroup = 0;
            var i = 0;

            modGlobal.gv_sql = "Select g.*, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.showonreport as showcolonreport ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
            modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " Where g.state = '" + modGlobal.gv_State + "'";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and g.RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by g.ordernumber, r.ordernumber, c.ordernumber ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            i = -1;
            cboColumns.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                i = i + 1;
                cboColumns.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupRow"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupCol"].Value, modGlobal.gv_rs.rdoColumns["SubGroupID"].Value));
                if (is_CopyType == "S")
                {
                    if (modGlobal.gv_rs.rdoColumns["SubGroupID"].Value == My.MyProject.Forms.frmSubmissionSetup.rdcSubmissionFieldList.Resultset.rdoColumns["SubGroupID"].Value)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object thisSubGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        thisSubGroup = i;
                    }
                }
                modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();

            //UPGRADE_WARNING: Couldn't resolve default property of object thisSubGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboColumns.SelectedIndex = thisSubGroup;
        }

        private void RefreshMeasuresList()
        {
            modGlobal.gv_sql = "Select ms.MeasureSetDesc, i.JCAHOID, i.Description, i.IndicatorID, ms.MeasureSetID" + " from tbl_setup_indicator i, tbl_setup_MeasureSetMapMeas isf, tbl_setup_MeasureSet ms" + " Where i.IndicatorID = isf.IndicatorID " + " and isf.MeasureSetID = ms.MeasureSetID ";

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (i.state = '' or i.state is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " AND i.state = '" + modGlobal.gv_State + "'";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.RecordStatus is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and i.RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by ms.MeasureSetDesc, i.JCAHOID, i.Description";

            cboMeasures.Items.Clear();

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            while (!modGlobal.gv_rs.EOF)
            {
                cboMeasures.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["JCAHOID"].Value + " - " + modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
                modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();
        }

        private void RefreshMeasureSteps()
        {
            int li_MaxCI;
            int li_MaxRA = 0;

            cboStep.Items.Clear();

            if (cboMeasures.SelectedIndex < 0)
                return;

            modGlobal.gv_sql = "SELECT MeasureStep, MeasureStepID, CAT_TYPE ";
            modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms ";
            modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT c ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on ms.MEASURE_CATID = c.MEASURE_CATID";
            modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " AND measurestep <> -100 and (CAT_TYPE is null or CAT_TYPE = 'CI') ORDER BY MeasureStep ASC";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            while (!modGlobal.gv_rs.EOF)
            {
                cboStep.Items.Add(modGlobal.gv_rs.rdoColumns["measurestep"].Value + " (Flow)");
                //UPGRADE_WARNING: Couldn't resolve default property of object li_MaxCI. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                li_MaxCI = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
                //UPGRADE_ISSUE: ComboBox property cboStep.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboStep, cboStep.Items.Count - 1, modGlobal.gv_rs.rdoColumns["measurestep"].Value);
                modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            //UPGRADE_WARNING: Couldn't resolve default property of object li_MaxCI. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboStep.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(li_MaxCI + 1 + " (Flow)", li_MaxCI + 1));

            modGlobal.gv_sql = "SELECT RiskAdjusted FROM tbl_Setup_Indicator WHERE IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.rdoColumns["RiskAdjusted"].Value == 1)
            {
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "SELECT MeasureStep, MeasureStepID  " + " FROM tbl_Setup_MeasureStep ms , tbl_MEASURE_CAT c " + " WHERE ms.MEASURE_CATID = c.MEASURE_CATID " + " AND ms.MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex) + " AND c.CAT_TYPE = 'RA' ORDER BY ms.MeasureStep ASC";

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                while (!modGlobal.gv_rs.EOF)
                {
                    cboStep.Items.Add(modGlobal.gv_rs.rdoColumns["measurestep"].Value + " (Risk)");
                    li_MaxRA = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
                    //UPGRADE_ISSUE: ComboBox property cboStep.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboStep, cboStep.Items.Count - 1, modGlobal.gv_rs.rdoColumns["measurestep"].Value);
                    modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                cboStep.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(li_MaxRA + 1 + " (Risk)", li_MaxRA + 1));
            }

            modGlobal.gv_sql = "SELECT MeasureStep, MeasureStepID " + " FROM tbl_Setup_MeasureStep WHERE MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex) + " AND MeasureStep = -100 ORDER BY MeasureStep ASC";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (!modGlobal.gv_rs.EOF)
            {
                cboStep.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Filter", modGlobal.gv_rs.rdoColumns["measurestep"].Value));
            }
            else
            {
                cboStep.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Filter", -100));
            }
            modGlobal.gv_rs.Dispose();

            RefreshMeasureStepSets();
        }

        private void RefreshMeasureStepSets()
        {
            int li_MaxSet = 0;

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
            modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureStep = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + "  AND ms.MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex);

            if (Strings.InStr(cboStep.Text, "Risk") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND CAT_TYPE = 'RA'";
            }
            else if (Strings.InStr(cboStep.Text, "Flow") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (Cat_Type is null or CAT_TYPE = 'CI')";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureCriteriaSet ASC";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            while (!modGlobal.gv_rs.EOF)
            {

                cboSet.Items.Add(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value);
                li_MaxSet = modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value;
                //UPGRADE_ISSUE: ComboBox property cboSet.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboSet, cboSet.Items.Count - 1, modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value);
                modGlobal.gv_rs.MoveNext();
            }

            cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(Convert.ToString(li_MaxSet + 1), li_MaxSet + 1));

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

        private void RefreshMeasureSetDef()
        {

            if (cboStep.SelectedIndex == -1 | cboSet.SelectedIndex == -1)
                return;

            modGlobal.gv_sql = "select JoinOperator FROM " + " tbl_setup_measurecriteriaset where " + " MeasureCriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex) + " AND MeasureStepID in (SELECT MeasureStepID FROM tbl_Setup_MeasureStep WHERE MeasureID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasures, cboMeasures.SelectedIndex) + " AND MeasureStep = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboStep, cboStep.SelectedIndex);

            if (Strings.InStr(cboStep.Text, "Risk") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')";
            }
            else if (Strings.InStr(cboStep.Text, "Flow") > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " AND Measure_CATID in (SELECT Measure_CATID FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + ")";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount == 0)
            {
                cboJoinOperator.Text = "";
                cboJoinOperator.Enabled = true;
            }
            else
            {
                cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                cboJoinOperator.Enabled = false;
            }
            modGlobal.gv_rs.Dispose();

        }

        private void frmMeasureCopyCriteria_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
        {
            is_CopyType = "";
            is_SubmitCriteriaIDs = new string[1];
            is_MeasureID = "";
            is_SubGroupID = "";
        }

        //UPGRADE_WARNING: Event rboCopyTo.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void rboCopyTo_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                short Index = rboCopyTo.GetIndex(eventSender);
                if (Index == 0)
                {
                    cboMeasures.Enabled = false;
                    cboColumns.Enabled = true;
                    cboStep.Enabled = false;
                }
                else
                {
                    cboMeasures.Enabled = true;
                    cboColumns.Enabled = false;
                    cboStep.Enabled = true;
                }
            }
        }
    }
}
