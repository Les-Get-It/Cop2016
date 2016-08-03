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
    internal partial class OldfrmReportCopySumCriteria : System.Windows.Forms.Form
    {

        //UPGRADE_WARNING: Event cboSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshSetDef();
        }

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdCopy_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            object NewCritID = null;
            if (cboSet.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
            {
                Interaction.MsgBox("Define the definition of the new criteria.");
            }
            else
            {
                //copy the criteria
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_Action = "Add";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_SavedAdhocReportSumCriteria", ref "CriteriaID");

                modGlobal.gv_sql = " insert into tbl_Setup_SavedAdhocReportSumCriteria (";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Report_ID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Criteriaset ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " MeasureID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "', ";
                modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmReportSetupCopy.lstSelectedSumCriteria, frmReportSetupCopy.lstSelectedSumCriteria.SelectedIndex);

                modGlobal.gv_cn.Execute(modGlobal.gv_sql);

                this.Close();
            }

        }

        private void frmReportCopySumCriteria_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

            RefreshSetList();

            modGlobal.gv_sql = "Select CriteriaTitle from tbl_setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where criteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmReportSetupCopy.lstSelectedSumCriteria, frmReportSetupCopy.lstSelectedSumCriteria.SelectedIndex);

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lblCopyFrom.Text = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;

        }
        public void RefreshSetDef()
        {
            if (cboSet.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex);
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
            modGlobal.gv_rs.Close();
        }

        public void RefreshSetList()
        {
            object SetIndex = null;

            cboSet.Items.Clear();

            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_id = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of criteria
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetIndex = 1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cboSet.Items.Add("Set " + SetIndex);
                //UPGRADE_ISSUE: ComboBox property cboSet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboSet, cboSet.NewIndex, SetIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex + 1;
                modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Close();

            //always add a new one to the list in addition to the previous ones
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + SetIndex, SetIndex));

        }
    }
}
