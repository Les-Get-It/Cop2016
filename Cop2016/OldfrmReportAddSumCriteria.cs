using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
// ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
namespace COP2001
{
    internal partial class OldfrmReportAddSumCriteria : System.Windows.Forms.Form
    {
        private void frmReportAddSumCriteria_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

            lblMessage.Text = "Setup Summarization Criteria for this report: " + frmReportSetupCopy.cboReportList.Text;

            RefreshIndicatorList();
            RefreshCategoryList();
            RefreshSetList();

        }
        public void RefreshIndicatorList()
        {
            var LIndex = 0;

            // ERROR: Not supported in C#: OnErrorStatement


            //retrieve the list of table fields
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where ((recordstatus is NULL) or ((recordstatus is not NULL) and (recordstatus = ''))) and ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " (State = '' or State is Null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by description ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            lstIndicatorList.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                lstIndicatorList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            return;
            errorhandler:


            modGlobal.CheckForErrors();

        }
        public void RefreshCategoryList()
        {
            var LIndex = 0;

            //retrieve the list of table fields
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_measure_cat ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by cat ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            cboCategory.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                cboCategory.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["CAT"].Value + " - " + modGlobal.gv_rs.rdoColumns["CAT_DESC"].Value, modGlobal.gv_rs.rdoColumns["measure_catid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();


        }
        private void cmdAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (lstIndicatorList.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select an indicator from the list");
                return;
            }

            if (cboSet.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the Criteria Set.");
                return;
            }

            if (string.IsNullOrEmpty(cboJoinOperator.Text))
            {
                RadMessageBox.Show("Please select the Join Type; the option that defines how to add this criteria to the exisiting ones.");
                return;
            }

            AddSumCriteria();

        }
        public void AddSumCriteria()
        {
            object CritTitle = null;
            object NewCritID = null;

            if (cboEqual.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the operator.");
                return;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select the Measure Category.");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Add";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewCritID = modDBSetup.FindMaxRecID(ref "tbl_Setup_SavedAdhocReportSumCriteria", ref "CriteriaID");

            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = lstIndicatorList.Text + " " + cboEqual.Text + " " + Strings.Left(cboCategory.Text, 2);

            modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Report_ID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
            modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Operator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " MeasureID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet)";
            modGlobal.gv_sql = modGlobal.gv_sql + " values (";
            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex) + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstIndicatorList, lstIndicatorList.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboEqual.Text + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboCategory, cboCategory.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboJoinOperator.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboSet, cboSet.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + ")";

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            
            this.Close();

        }
        public void RefreshSetDef()
        {

            if (cboSet.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + Support.GetItemData(cboSet, cboSet.SelectedIndex);

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

        public void RefreshSetList()
        {
            object SetIndex = null;
            cboSet.Items.Clear();

            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_id = " + Support.GetItemData(frmReportSetupCopy.cboReportList, frmReportSetupCopy.cboReportList.SelectedIndex);
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
                Support.SetItemData(cboSet, cboSet.NewIndex, SetIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex + 1;
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            //always add a new one to the list in addition to the previous ones
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboSet.Items.Add(new ListBoxItem("Set " + SetIndex, SetIndex));

        }
        //UPGRADE_WARNING: Event cboSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshSetDef();
        }
        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }
    }
}
