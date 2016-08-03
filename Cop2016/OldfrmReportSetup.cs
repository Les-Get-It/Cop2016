using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmReportSetup : System.Windows.Forms.Form
    {

        private void cboCriteriaSet_Click()
        {
            RefreshSetDef();
        }

        //UPGRADE_WARNING: Event cboReportList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboReportList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshReportTable();
            //RefreshTableFields
            //RefreshTableFieldsForCriteria
            RefreshSelectedFields();
            RefreshCriteriaList();
            RefreshSumCriteriaList();
            RefreshCriteriaSetList();

            if (cboReportList.SelectedIndex >= 0)
            {
                sstabReportSpec.Enabled = true;
                cboTableList.Enabled = true;
            }

        }

        //UPGRADE_WARNING: Event cboTableList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboTableList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshTableFields();
            //RefreshTableFieldsForCriteria
            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReports ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set BaseTableID = " + Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
        }

        private void cmdAddCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

           frmReportAddCritCopy.ShowDialog();
            RefreshCriteriaList();

        }
        private void cmdAddSumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

           frmReportAddSumCriteriaCopy.ShowDialog();
            RefreshSumCriteriaList();

        }

        private void cmdAddField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string FieldCaption = null;
            int NextOrderID;
            if (lstAvailableFieldList.SelectedIndex > -1)
            {
                //no more than 10 fields can be selected
                modGlobal.gv_sql = "select count(*) as TotalFields from  tbl_Setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (modGlobal.gv_rs.rdoColumns["TotalFields"].Value >= 10)
                {
                    RadMessageBox.Show("No more than 10 fields for a report can be selected.");
                    return;
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object NextOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NextOrderID = GetNextFieldOrderID( Support.GetItemData(cboReportList, cboReportList.SelectedIndex));

                //UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FieldCaption = RadInputBox.Show("If you need to change the field title, type the new name here:", "Add Field", lstAvailableFieldList.Text);

                modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReportFields (Report_ID, DDID, FieldCaption, OrderID)";
                modGlobal.gv_sql = modGlobal.gv_sql + " values(" + Support.GetItemData(cboReportList, cboReportList.SelectedIndex) + "," + Support.GetItemData(lstAvailableFieldList, lstAvailableFieldList.SelectedIndex) + ", ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NextOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + FieldCaption + "', " + NextOrderID + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshSelectedFields();
                RefreshTableFields();
            }
        }
        private void cmdCancel_Click()
        {
            InitCriteria();
        }

        private void cmdChangeOrAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string CSet = null;
            string newjoinop = null;
            if (lstSelectedCriteria.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to Change the join operator?", MessageBoxButtons.YesNo, "Change And/Or of the set"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.No))
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            newjoinop = "And";

            modGlobal.gv_sql = " select CriteriaSEt, JoinOperator from tbl_setup_savedAdhocReportCriteria  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaID = " + Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
            {
                modGlobal.gv_sql = " select JoinOperator from tbl_setup_savedAdhocReports  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "And")
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "OR";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "And";
                }
            }
            else
            {
                if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "And")
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "OR";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "And";
                }
            }

            modGlobal.gv_sql = " Update tbl_setup_savedAdhocReportCriteria  ";
            //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + newjoinop + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + CSet;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshCriteriaList();

        }
        private void cmdChangeOrAndSumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string CSet = null;
            string newjoinop = null;
            if (lstSelectedSumCriteria.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to Change the join operator?", MessageBoxButtons.YesNo, "Change And/Or of the set"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.No))
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            newjoinop = "And";

            modGlobal.gv_sql = " select CriteriaSEt, JoinOperator from tbl_setup_savedAdhocReportSumCriteria  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaID = " + Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
            {
                modGlobal.gv_sql = " select JoinOperator from tbl_setup_savedAdhocReports  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "And")
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "OR";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "And";
                }
            }
            else
            {
                if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "And")
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "OR";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newjoinop = "And";
                }
            }

            modGlobal.gv_sql = " Update tbl_setup_savedAdhocReportSumCriteria  ";
            //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + newjoinop + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + CSet;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshSumCriteriaList();

        }


        private void cmdChangeReportAndOr_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            if (cboReportList.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to change the join operator between all sets?", MessageBoxButtons.YesNo, "Change Join Operator Between All Sets");
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount > 0)
            {
                modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                }
                else if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "OR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'AND'";
                }
                else if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "AND")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }
            RefreshCriteriaList();

        }
        private void cmdChangeReportAndOrSumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            if (cboReportList.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to change the join operator between all sets?", MessageBoxButtons.YesNo, "Change Join Operator Between All Sets");
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount > 0)
            {
                modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                }
                else if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "OR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'AND'";
                }
                else if (modGlobal.gv_rs.rdoColumns["JoinOperator"].Value == "AND")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }
            RefreshSumCriteriaList();

        }

        private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            string MoveToModule = null;

            if (cboReportList.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want this report to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Update tbl_Setup_SavedAdhocReports ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshReportList();
            RefreshTableList();
            RefreshReportTable();
            RefreshTableFields();
            RefreshSelectedFields();
            RefreshCriteriaList();
            RefreshSumCriteriaList();
            ResetCriteriaSetOrderForAllReports();

            sstabReportSpec.SelectedIndex = 0;
            sstabReportSpec.Enabled = false;

        }

        private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdCopyCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstSelectedCriteria.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Not Defind";

           frmReportCopyCriteriaCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshCriteriaList();
            }


        }
        private void cmdCopySumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstSelectedSumCriteria.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Not Defind";

           frmReportCopySumCriteriaCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshSumCriteriaList();
            }
        }

        private void cmdDeleteReport_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            if (cboReportList.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to delete this report?", MessageBoxButtons.YesNo, "Delete Report");
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReportFields ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReportCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "delete tbl_Setup_SavedAdhocReports ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshReportList();
            RefreshTableList();
            RefreshReportTable();
            RefreshTableFields();
            //RefreshTableFieldsForCriteria
            RefreshSelectedFields();
            RefreshCriteriaList();
            RefreshSumCriteriaList();

            if (cboReportList.SelectedIndex >= 0)
            {
                sstabReportSpec.Enabled = true;
                cboTableList.Enabled = true;
            }
            else
            {
                sstabReportSpec.Enabled = false;
                cboTableList.Enabled = false;
            }

            sstabReportSpec.SelectedIndex = 0;
        }

        private void cmdDup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int cnt ;
            int ReportID ;
            string newname = null;
            if (cboReportList.SelectedIndex < 0)
            {
                return;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            newname = RadInputBox.Show("Enter the new name for the report:", "Duplicate Report", cboReportList.Text);
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
            {
                return;
            }

            while (Strings.Len(newname) > 200)
            {
                RadMessageBox.Show("Please enter a name that is less than 200 characters long.");

                //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                newname = RadInputBox.Show("Enter the new name for the report:", "Duplicate Report", cboReportList.Text);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
                {
                    return;
                }
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "EXEC DuplicateAdhocReport " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex) + ", '" + newname + "'";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ReportID = modGlobal.gv_rs.rdoColumns["ReportID"].Value;

            modGlobal.gv_rs.Dispose();

            RefreshReportList();

            //find listindex with itemdata = gv_rs!ReportID
            //cboReportList.ItemData(cboReportList.ListIndex)
            //UPGRADE_WARNING: Couldn't resolve default property of object cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cnt = 0;
            //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (Support.GetItemData(cboReportList, cnt) != ReportID)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cnt = cnt + 1;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (Support.GetItemData(cboReportList, cnt) == ReportID)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cboReportList.SelectedIndex = cnt;
            }

        }

        private void cmdDuplCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int NewCritID;
            string NewCSet = null;
            string CSet = null;
            DialogResult resp;
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
            if (lstSelectedCriteria.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a criteria set to copy.");
                return;
            }

            if (Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex) <= 0)
            {
                RadMessageBox.Show("Select a criteria set to copy.");
                return;
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to create a new set as a copy of the selected set?", MessageBoxButtons.YesNo, "Duplicate Criteria Set");

            DataSet thisrs = null;
            if (resp == DialogResult.Yes)
            {
                modGlobal.gv_sql = "Select criteriaset from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where criteriaid = " + Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

                modGlobal.gv_sql = "Select max(criteriaset) + 1 as newcset  from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewCSet = modGlobal.gv_rs.rdoColumns["NewCSet"].Value;

                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and criteriaset = " + CSet;
                thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!thisrs.EOF)
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    NewCritID = modDBSetup.FindMaxRecID(ref "tbl_setup_SavedAdhocReportCriteria", ref "CriteriaID");

                    modGlobal.gv_sql = "insert into tbl_setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, Report_id, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, ValueOperator, Value, DestDDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, CriteriaSet)  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", report_id, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, ValueOperator, Value, DestDDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, " + NewCSet;
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaID = " + thisrs.rdoColumns["criteriaID"].Value;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    thisrs.MoveNext();
                }

                RefreshCriteriaList();

            }

        }
        private void cmdDuplSumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int NewCritID;
            string NewCSet = null;
            string CSet = null;
            DialogResult resp;
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
            if (lstSelectedSumCriteria.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a criteria set to copy.");
                return;
            }

            if (Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex) <= 0)
            {
                RadMessageBox.Show("Select a criteria set to copy.");
                return;
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to create a new set as a copy of the selected set?", MessageBoxButtons.YesNo, "Duplicate Criteria Set");

            DataSet thisrs = null;
            if (resp == DialogResult.Yes)
            {
                modGlobal.gv_sql = "Select criteriaset from tbl_setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where criteriaid = " + Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

                modGlobal.gv_sql = "Select max(criteriaset) + 1 as newcset  from tbl_setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewCSet = modGlobal.gv_rs.rdoColumns["NewCSet"].Value;

                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and criteriaset = " + CSet;
                thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!thisrs.EOF)
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    NewCritID = modDBSetup.FindMaxRecID(ref "tbl_setup_SavedAdhocReportSumCriteria", ref "CriteriaID");

                    modGlobal.gv_sql = "insert into tbl_setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, Report_id, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, Operator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " MeasureID, CriteriaSet)  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", report_id, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, Operator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " MeasureID, " + NewCSet;
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaID = " + thisrs.rdoColumns["criteriaID"].Value;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    thisrs.MoveNext();
                }

                RefreshSumCriteriaList();

            }

        }
        private void cmdHelp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string msg = null;
            string lkvalue = null;
            string FieldTypeSize = null;
            RadListControl lstFieldListForCriteria = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldListForCriteria.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (lstFieldListForCriteria.ListIndex < 0)
            {
                return;
            }

            txtHelp.Text = "";
            //UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            FieldTypeSize = "";

            modGlobal.gv_sql = "Select DDID, LookupTableID, help, FieldType, FieldSize from tbl_Setup_DataDef ";
            //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldListForCriteria.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldListForCriteria.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + lstFieldListForCriteria.ItemData(lstFieldListForCriteria.ListIndex);
            rdcHelp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcHelp.CtlRefresh();
            txtHelp.Text = rdcHelp.Resultset.rdoColumns["help"].Value;

            //UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            FieldTypeSize = "Field Type: " + rdcHelp.Resultset.rdoColumns["FieldType"].Value;
            if (rdcHelp.Resultset.rdoColumns["FieldType"].Value == "Text")
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FieldTypeSize = FieldTypeSize + Strings.Chr(10) + Strings.Chr(13) + "Field Size: " + rdcHelp.Resultset.rdoColumns["FieldSize"].Value + Strings.Chr(10) + Strings.Chr(13) + Strings.Chr(10) + Strings.Chr(13);
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FieldTypeSize = FieldTypeSize + Strings.Chr(10) + Strings.Chr(13) + Strings.Chr(10) + Strings.Chr(13);
            }
            //Dim wrkODBC As Workspace
            //Dim conpubs As Connection
            //Dim dtHelp As Data
            //Set wrkODBC = CreateWorkspace("NewODBCWorkspace", "", "", dbUseODBC)
            //Set conpubs = wrkODBC.OpenConnection("Connection1", , , "ODBC;DATABASE=COP2001;UID=sa;PWD=;DSN=COP2001")
            //Set dtHelp.Recordset = conpubs.OpenRecordset(gv_sql, 2)


            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            DataSet rdclk = null;
            if (!Information.IsDBNull(rdcHelp.Resultset.rdoColumns["LookupTableID"].Value))
            {
                modGlobal.gv_sql = "Select * from tbl_Setup_misclookuplist ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + rdcHelp.Resultset.rdoColumns["LookupTableID"].Value;
                rdclk = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lkvalue = "";
                while (!rdclk.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (string.IsNullOrEmpty(lkvalue))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lkvalue = rdclk.rdoColumns["Id"].Value + ". " + rdclk.rdoColumns["FIELDVALUE"].Value;
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lkvalue = lkvalue + Strings.Chr(13) + Strings.Chr(10) + rdclk.rdoColumns["Id"].Value + ". " + rdclk.rdoColumns["FIELDVALUE"].Value;
                    }
                    rdclk.MoveNext();
                }
                rdclk.Close();
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            msg = "";
            //UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(txtHelp.Text) & string.IsNullOrEmpty(lkvalue))
            {
                RadMessageBox.Show(FieldTypeSize);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtHelp.Text))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    msg = FieldTypeSize + txtHelp.Text;
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (!string.IsNullOrEmpty(lkvalue))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (string.IsNullOrEmpty(msg))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object lkvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object FieldTypeSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        msg = FieldTypeSize + "Valid values: " + Strings.Chr(10) + Strings.Chr(13) + lkvalue;
                        //Else
                        //    msg = msg & Chr(10) & Chr(13) & "Valid values: " & Chr(10) & Chr(13) & lkvalue
                    }
                }
                RadMessageBox.Show(msg);
            }


        }


        private void cmdMoveFieldDown_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string CurrentField = null;
            int CurrentOrderID;
            if (lstSelectedFieldList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "Select OrderID from tbl_Setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderID"].Value))
                {
                    //reorganize the fields
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurrentOrderID = modGlobal.gv_rs.rdoColumns["OrderID"].Value;
                    modGlobal.gv_sql = "select max(OrderId) as maxorderid from tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    if (modGlobal.gv_rs.rdoColumns["MaxOrderId"].Value > CurrentOrderID)
                    {
                        //update the field that is one order higher than this one
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderID = " + CurrentOrderID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " and OrderID = " + CurrentOrderID + 1;
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //update this field
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentOrderID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderID = " + CurrentOrderID + 1;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //set focus on the same field after refresh
                        modGlobal.gv_sql = "select * from tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CurrentField = modGlobal.gv_rs.rdoColumns["OrderID"].Value + ". " + modGlobal.gv_rs.rdoColumns["FieldCaption"].Value;
                        //MsgBox CurrentField
                        RefreshSelectedFields();
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedFieldList.Text = CurrentField;
                    }
                }

            }
        }

        private void cmdMoveFieldup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string CurrentField = null;

            if (lstSelectedFieldList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "Select OrderID from tbl_Setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderID"].Value))
                {
                    //reorganize the fields
                }
                else
                {
                    if (modGlobal.gv_rs.rdoColumns["OrderID"].Value > 1)
                    {
                        //update the field that is one order higher than this one
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderID = " + modGlobal.gv_rs.rdoColumns["OrderID"].Value;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and OrderID = " + modGlobal.gv_rs.rdoColumns["OrderID"].Value - 1;
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //update this field
                        modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderID = " + modGlobal.gv_rs.rdoColumns["OrderID"].Value - 1;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        modGlobal.gv_sql = "select * from tbl_Setup_SavedAdhocReportFields ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                        //set focus on the same field after refresh
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CurrentField = modGlobal.gv_rs.rdoColumns["OrderID"].Value + ". " + modGlobal.gv_rs.rdoColumns["FieldCaption"].Value;
                        //MsgBox CurrentField
                        RefreshSelectedFields();
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedFieldList.Text = CurrentField;

                    }
                }

            }

        }

        private void cmdNewReport_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int FCount ;
            int NewRecID;
            string ReportName = null;
            //get the report name
            //UPGRADE_WARNING: Couldn't resolve default property of object ReportName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ReportName = RadInputBox.Show("New Report Name:", "Add New Report", "");

            //UPGRADE_WARNING: Couldn't resolve default property of object ReportName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            DataSet reprs = null;
            if (!string.IsNullOrEmpty(ReportName))
            {
                //make sure it is not a duplicate
                modGlobal.gv_sql = "select *   ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReports  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where report_Name = '" + ReportName + "'";
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " and State = '" + modGlobal.gv_State + "'";
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
                }


                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (modGlobal.gv_rs.RowCount > 0)
                {
                    RadMessageBox.Show("This Report Name Already Exists.");
                    return;
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object NewRecID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewRecID = modDBSetup.FindMaxRecID(ref "tbl_setup_SavedAdhocReports", ref "Report_ID");
                //add the report
                modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReports (Report_ID, Report_Name, State, RecordStatus)";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object NewRecID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " values(" + NewRecID + ",'" + ReportName + "',";
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_State + "',";
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //refresh report list
                RefreshReportList();

                //find and display it on the form
                modGlobal.gv_sql = "select tbl_Setup_SavedAdhocReports.*   ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReports  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where state = '" + modGlobal.gv_State + "'";
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by Report_Name  ";

                reprs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FCount = 0;
                while (!reprs.EOF)
                {
                    if (reprs.rdoColumns["Report_name"].Value == ReportName)
                    {
                        cboReportList.SelectedText = reprs.rdoColumns["Report_name"].Value;
                        //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        cboReportList.SelectedIndex = FCount;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    FCount = FCount + 1;
                    reprs.MoveNext();
                }
                reprs.Close();

                RefreshTableList();
                RefreshReportTable();
                RefreshTableFields();
                //RefreshTableFieldsForCriteria
                RefreshSelectedFields();
                RefreshCriteriaList();
                RefreshSumCriteriaList();

            }
        }

        public void RefreshReportList()
        {
            var LIndex = 0;
            int this_ListIndex;

            modGlobal.gv_sql = "select * from tbl_Setup_SavedAdhocReports ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " Where state = '" + modGlobal.gv_State + "'";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " order by Report_Name ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);


            cboReportList.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            this_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                this_ListIndex = LIndex;

                cboReportList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Report_name"].Value, modGlobal.gv_rs.rdoColumns["Report_ID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }


        }

        public void RefreshTableList()
        {
            var LIndex = 0;
            int this_ListIndex;

            //retrieve the list of tables
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where tabletype <> 'LOOKUP' ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboTableList.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            this_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                this_ListIndex = LIndex;

                cboTableList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }


        }

        public void RefreshTableFields()
        {
            var LIndex = 0;
            int this_ListIndex;
            int BTableID;

            if (cboTableList.SelectedIndex > -1)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object BTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                BTableID = Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object BTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                BTableID = -1;
            }

            modGlobal.gv_sql = "select * from tbl_setup_DataDef ";
            //UPGRADE_WARNING: Couldn't resolve default property of object BTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + BTableID;
            modGlobal.gv_sql = modGlobal.gv_sql + " and DDID not in ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (Select DDID from tbl_Setup_SavedAdhocReportFields ";
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex) + ")";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1) ";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstAvailableFieldList.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            this_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                this_ListIndex = LIndex;

                lstAvailableFieldList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

        }

        public void RefreshSelectedFields()
        {
            var LIndex = 0;
            int this_ListIndex;

            modGlobal.gv_sql = "select tbl_Setup_SavedAdhocReportFields.*  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SavedAdhocReportFields ";
            //gv_sql = gv_sql & " from tbl_Setup_SavedAdhocReportFields, tbl_Setup_DataDef "
            //gv_sql = gv_sql & " Where tbl_Setup_SavedAdhocReportFields.DDID =  tbl_Setup_DataDef.DDID "
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_SavedAdhocReportFields.Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_SavedAdhocReportFields.Report_ID = -1 ";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_Setup_SavedAdhocReportFields.OrderID ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstSelectedFieldList.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            this_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                this_ListIndex = LIndex;

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderID"].Value))
                {
                    lstSelectedFieldList.Items.Add(modGlobal.gv_rs.rdoColumns["OrderID"].Value + ". " + modGlobal.gv_rs.rdoColumns["FieldCaption"].Value);
                }
                else
                {
                    lstSelectedFieldList.Items.Add(modGlobal.gv_rs.rdoColumns["FieldCaption"].Value);
                }
                //UPGRADE_ISSUE: ListBox property lstSelectedFieldList.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Support.SetItemData(lstSelectedFieldList, lstSelectedFieldList.Items.Count-1, modGlobal.gv_rs.rdoColumns["DDID"].Value);
                //LDW modGlobal.gv_rs.MoveNext();
            }
        }

        public void RefreshReportTable()
        {
            int FCount ;
            int BTableID;
            int ReportID ;

            cboTableList.SelectedText = "";
            cboTableList.SelectedIndex = -1;

            if (cboReportList.SelectedIndex > -1)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ReportID = Support.GetItemData(cboReportList, cboReportList.SelectedIndex);

                modGlobal.gv_sql = "select BaseTableID   ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReports  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["basetableid"].Value))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object BTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    BTableID = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
                    modGlobal.gv_sql = "select  tbl_Setup_TableDef.*   ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where TableType <> 'LOOKUP'  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by BaseTable  ";

                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    FCount = 0;
                    while (!modGlobal.gv_rs.EOF)
                    {
                        if (modGlobal.gv_rs.rdoColumns["basetableid"].Value == BTableID)
                        {
                            cboTableList.SelectedText = modGlobal.gv_rs.rdoColumns["BaseTable"].Value;
                            //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            cboTableList.SelectedIndex = FCount;
                            return;
                        }
                        //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        FCount = FCount + 1;
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                }

            }

        }



        private void cmdRemove_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int li_cnt;
            if (lstSelectedCriteria.SelectedIndex < 0)
            {
                return;
            }

            if (lstSelectedCriteria.SelectedItems.Count > 0 & Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex) > -1)
            {
                if (RadMessageBox.Show("Are you sure you want to delete this criteria?", MessageBoxButtons.YesNo, "Delete Criteria") == DialogResult.No)
                {
                    return;
                }

                //allow delete of multiple criteria
                for (li_cnt = 0; li_cnt <= lstSelectedCriteria.Items.Count - 1; li_cnt++)
                {
                    if (lstSelectedCriteria.GetSelected(li_cnt) & Support.GetItemData(lstSelectedCriteria, li_cnt) > 0)
                    {
                        if (Support.GetItemData(lstSelectedCriteria, lstSelectedCriteria.SelectedIndex) == 0)
                            return;

                        modGlobal.gv_sql = "Delete tbl_Setup_SavedAdhocReportcriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where criteriaID = " + Support.GetItemData(lstSelectedCriteria, li_cnt);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        lstSelectedCriteria.SetSelected(li_cnt, false);

                    }
                }

                ResetCriteriaSetOrder();
                RefreshCriteriaList();

            }
            else
            {
                RadMessageBox.Show("Select criteria to delete", MessageBoxButtons.Critical, "No Criteria Selected");
            }


            //gv_resp = MsgBox("Are you sure you want to delete this criteria?", vbYesNo, "Delete Criteria")
            //If gv_resp = vbYes Then
            //
            //     gv_sql = "Delete tbl_Setup_SavedAdhocReportcriteria "
            //     gv_sql = gv_sql & " where criteriaID = " & lstSelectedCriteria.ItemData(lstSelectedCriteria.ListIndex)
            //     gv_cn.Execute gv_sql
            //
            //     ResetCriteriaSetOrder
            //     RefreshCriteriaList
            //     'RefreshCriteriaSetList
            // End If

        }
        private void cmdRemoveSumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstSelectedSumCriteria.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                modGlobal.gv_sql = "Delete tbl_Setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where criteriaID = " + Support.GetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                ResetSumCriteriaSetOrder();
                RefreshSumCriteriaList();
                //RefreshCriteriaSetList
            }

        }

        private void cmdRemoveField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int CurrentFieldOrder;
            if (lstSelectedFieldList.SelectedIndex > -1)
            {

                //remember the order number before deleting it
                modGlobal.gv_sql = "Select OrderID from  tbl_Setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CurrentFieldOrder = modGlobal.gv_rs.rdoColumns["OrderID"].Value;

                //now delete the field
                modGlobal.gv_sql = "Delete tbl_Setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //reorganize the fields based on the order number
                modGlobal.gv_sql = "Select * from  tbl_Setup_SavedAdhocReportFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and OrderID > " + CurrentFieldOrder;
                modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderID ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!modGlobal.gv_rs.EOF)
                {
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set OrderID = " + CurrentFieldOrder;
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurrentFieldOrder = CurrentFieldOrder + 1;
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                RefreshSelectedFields();
                RefreshTableFields();
            }
        }

        private void cmdRenameField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string CurrentField = null;
            string FieldCaption = null;

            if (lstSelectedFieldList.SelectedIndex > -1)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FieldCaption = RadInputBox.Show("Type the new name here:", "Rename Field", lstSelectedFieldList.Text);
                //UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (!string.IsNullOrEmpty(FieldCaption))
                {
                    //update this field
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportFields ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set FieldCaption = '" + FieldCaption + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    modGlobal.gv_sql = "Select OrderID from  tbl_Setup_SavedAdhocReportFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + Support.GetItemData(lstSelectedFieldList, lstSelectedFieldList.SelectedIndex);
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //UPGRADE_WARNING: Couldn't resolve default property of object FieldCaption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurrentField = modGlobal.gv_rs.rdoColumns["OrderID"].Value + ". " + FieldCaption;
                    RefreshSelectedFields();
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSelectedFieldList.Text = CurrentField;
                }
            }

        }

        private void cmdSubmit_Click()
        {

            //    MsgBox "is this obsolete?"

            //    If cboCriteriaSet.ListIndex < 0 Then
            //        MsgBox "Please define the Criteria Set from the drop-down list."
            //        Exit Sub
            //    End If
            //
            //    If cboJoinOp = "" Then
            //        MsgBox "Please define the Join Operator from the drop-down list."
            //        Exit Sub
            //    End If
            //
            //    If lstFieldListForCriteria.ListIndex < 0 Or cboOperator.ListIndex < 0 Or txtCriteria = "" Then
            //        MsgBox "Please select a field, and an operator, and type in a criteria."
            //        Exit Sub
            //    End If
            //
            //
            //    NewRecID = FindMaxRecID("tbl_setup_SavedAdhocReportCriteria", "CriteriaID")
            //
            //    gv_sql = " Select * from tbl_Setup_DataDef  "
            //    gv_sql = gv_sql & " where DDID = " & lstFieldListForCriteria.ItemData(lstFieldListForCriteria.ListIndex)
            //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
            //    FieldType = gv_rs!FieldType
            //
            //    If UCase(FieldType) = "DATE" And Not IsDate(txtCriteria) Then
            //        MsgBox "Please enter a valid date value for this field."
            //        Exit Sub
            //    ElseIf UCase(FieldType) = "NUMBER" And Not IsNumeric(txtCriteria) Then
            //        MsgBox "Please enter a valid numeric value for this field."
            //        Exit Sub
            //
            //    End If
            //
            //    'If lstSelectedCriteria.ListCount = 0 Then
            //    '    JoinOperator = "NULL"
            //    'Else
            //    '    JoinOperator = "'" & txtJoinOperator & "'"
            //    'End If
            //
            //    'If cboJoinOp.Visible = True And cboJoinOp.Text <> "" Then
            //    '    gv_sql = " Update tbl_setup_savedAdhocReportCriteria  "
            //    '    gv_sql = gv_sql & " set JoinOperator = '" & cboJoinOp.Text & "'"
            //    '    gv_sql = gv_sql & " where Report_ID = " & cboReportList.ItemData(cboReportList.ListIndex)
            //    '    gv_sql = gv_sql & " and JoinOperator = Null "
            //    '    gv_cn.Execute gv_sql
            //    'End If
            //
            //
            //    gv_sql = " Insert into tbl_setup_savedAdhocReportCriteria  "
            //    gv_sql = gv_sql & " (CriteriaID, Report_ID, DDID, CriteriaOperator, "
            //    gv_sql = gv_sql & " Criteria, FieldType, CriteriaCaption, JoinOperator, CriteriaSet) "
            //    gv_sql = gv_sql & " values (" & NewRecID & "," & cboReportList.ItemData(cboReportList.ListIndex) & ","
            //    gv_sql = gv_sql & lstFieldListForCriteria.ItemData(lstFieldListForCriteria.ListIndex) & ","
            //    gv_sql = gv_sql & "'" & cboOperator.List(cboOperator.ListIndex) & "',"
            //    gv_sql = gv_sql & "'" & txtCriteria & "',"
            //    gv_sql = gv_sql & "'" & FieldType & "',"
            //    gv_sql = gv_sql & "'" & lstFieldListForCriteria.List(lstFieldListForCriteria.ListIndex) & " " & cboOperator.List(cboOperator.ListIndex) & " " & txtCriteria & "', "
            //    'If cboJoinOp.Text = "" Then
            //    '    gv_sql = gv_sql & " Null "
            //    'Else
            //        gv_sql = gv_sql & " '" & cboJoinOp.Text & "',"
            //    'End If
            //    gv_sql = gv_sql & cboCriteriaSet.ItemData(cboCriteriaSet.ListIndex)
            //    gv_sql = gv_sql & ")"
            //
            //    'resp = InputBox("", "", gv_sql)
            //    gv_cn.Execute gv_sql
            //
            //    InitCriteria
            //    ResetCriteriaSetOrder
            //    RefreshCriteriaList
            //    'RefreshCriteriaSetList

        }

        private void cmdRenameReport_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int thisindex;
            string newname = null;
            if (cboReportList.SelectedIndex < 0)
            {
                return;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            newname = RadInputBox.Show("Enter the new name for the report:", "Rename Report", cboReportList.Text);
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
            {
                return;
            }

            while (Strings.Len(newname) > 200)
            {
                RadMessageBox.Show("Please enter a name that is less than 200 characters long.");

                //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                newname = RadInputBox.Show("Enter the new name for the report:", "Rename Report", cboReportList.Text);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (string.IsNullOrEmpty(newname) | Information.IsDBNull(newname))
                {
                    return;
                }
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            thisindex = cboReportList.SelectedIndex;

            modGlobal.gv_sql = "update tbl_setup_savedadhocreports ";
            //UPGRADE_WARNING: Couldn't resolve default property of object newname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " set Report_Name = '" + newname + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshReportList();

            //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboReportList.SelectedIndex = thisindex;



        }

        private void frmReportSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_status == "TEST")
            {
                cmdChangeStatus.Text = "Move to Active";
            }
            else
            {
                cmdChangeStatus.Text = "Move to Test";
            }


            //ResetCriteriaSetOrderForAllReports
            RefreshReportList();
            RefreshTableList();

            sstabReportSpec.SelectedIndex = 0;
        }
        public void RefreshSetDef()
        {

            //    MsgBox "is this obsolete?"

            //    If cboCriteriaSet.ListIndex < 0 Then
            //        Exit Sub
            //    End If
            //
            //    gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReportCriteria "
            //    gv_sql = gv_sql & " where Report_ID = " & cboReportList.ItemData(cboReportList.ListIndex)
            //    gv_sql = gv_sql & " and CriteriaSet = " & cboCriteriaSet.ItemData(cboCriteriaSet.ListIndex)
            //
            //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
            //
            //    If gv_rs.RowCount = 0 Then
            //        cboJoinOp = ""
            //        cboJoinOp.Enabled = True
            //    Else
            //        cboJoinOp = gv_rs!JoinOperator
            //        cboJoinOp.Enabled = False
            //    End If
            //    gv_rs.Close

        }
        public int GetNextFieldOrderID(int ReportID)
        {
            int MaxOrderId;

            modGlobal.gv_sql = "select max(OrderID) as MaxOrderID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportFields ";
            //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MaxOrderId"].Value))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MaxOrderId = 0;
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MaxOrderId = modGlobal.gv_rs.rdoColumns["MaxOrderId"].Value;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderId. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            return MaxOrderId + 1;

        }

        public void RefreshTableFieldsForCriteria()
        {
            var LIndex = 0;
            int this_ListIndex;
            RadListControl lstFieldListForCriteria = null;
            int BTableID;
            if (cboTableList.SelectedIndex > -1)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object BTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                BTableID = Support.GetItemData(cboTableList, cboTableList.SelectedIndex);
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object BTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                BTableID = -1;
            }

            modGlobal.gv_sql = "select * from tbl_setup_DataDef ";
            //UPGRADE_WARNING: Couldn't resolve default property of object BTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + BTableID;
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldListForCriteria.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lstFieldListForCriteria.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            this_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object this_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                this_ListIndex = LIndex;

                lstFieldListForCriteria.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
        }
        public void RefreshCriteriaList()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount;
            int SetIndex;
            int TotalSetRec;
            string mainJoinOperator = null;
            DataSet rs_critSet = null;

            lstSelectedCriteria.Items.Clear();

            //find the operator (AND or OR) joining the sets
            //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mainJoinOperator = "AND";
            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
            }
            //g = InputBox("", "", gv_sql)
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
                {
                    modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + mainJoinOperator + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mainJoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                }
            }



            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportCriteria ";
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

            rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (rs_critSet.RowCount > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
               //LDW  rs_critSet.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalSetRec = rs_critSet.RowCount;
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveFirst();
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalSetRec = 0;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetIndex = 0;
            //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetCount = 0;
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!rs_critSet.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex - 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetCount = SetCount + 1;

                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet!CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + rs_critSet["CriteriaSet"];
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //LDW modGlobal.gv_rs.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalRec = modGlobal.gv_rs.RowCount;
                //LDW modGlobal.gv_rs.MoveFirst();
                //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Cindex = 0;
                //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CSuff = "";
                //UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CPref = "Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value + ": (";

                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Cindex = Cindex + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Cindex == TotalRec)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (TotalRec == 1)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            CSuff = " (" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + ") )";
                        }
                        else
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            CSuff = ")";
                        }
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CSuff = " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Cindex == 1)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedCriteria.Items.Add(CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedCriteria.Items.Add("          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    //UPGRADE_ISSUE: ListBox property lstSelectedCriteria.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    Support.SetItemData(lstSelectedCriteria, lstSelectedCriteria.Items.Count-1, modGlobal.gv_rs.rdoColumns["criteriaID"].Value);
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (SetCount == TotalSetRec)
                {
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSelectedCriteria.Items.Add(new ListBoxItem(mainJoinOperator, SetIndex));
                }


                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveNext();

            }


        }
        public void RefreshSumCriteriaList()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount;
            int SetIndex;
            int TotalSetRec;
            string mainJoinOperator = null;
            DataSet rs_critSet = null;

            lstSelectedSumCriteria.Items.Clear();

            //find the operator (AND or OR) joining the sets
            //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mainJoinOperator = "AND";
            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SavedAdhocReports ";
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
            }
            //g = InputBox("", "", gv_sql)
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
                {
                    modGlobal.gv_sql = "update tbl_setup_SavedAdhocReports ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + mainJoinOperator + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mainJoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                }
            }



            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportSumCriteria ";
            if (cboReportList.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = -1 ";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

            rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (rs_critSet.RowCount > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
               //LDW  rs_critSet.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalSetRec = rs_critSet.RowCount;
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveFirst();
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalSetRec = 0;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetIndex = 0;
            //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetCount = 0;
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!rs_critSet.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex - 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetCount = SetCount + 1;

                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet!CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + rs_critSet["CriteriaSet"];
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //LDW modGlobal.gv_rs.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalRec = modGlobal.gv_rs.RowCount;
                //LDW modGlobal.gv_rs.MoveFirst();
                //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Cindex = 0;
                //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CSuff = "";
                //UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CPref = "Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value + ": (";

                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Cindex = Cindex + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Cindex == TotalRec)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (TotalRec == 1)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            CSuff = " (" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + ") )";
                        }
                        else
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            CSuff = ")";
                        }
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CSuff = " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Cindex == 1)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedSumCriteria.Items.Add(CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedSumCriteria.Items.Add("          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    //UPGRADE_ISSUE: ListBox property lstSelectedSumCriteria.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    Support.SetItemData(lstSelectedSumCriteria, lstSelectedSumCriteria.Items.Count-1, modGlobal.gv_rs.rdoColumns["criteriaID"].Value);
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (SetCount == TotalSetRec)
                {
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object mainJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSelectedSumCriteria.Items.Add(new ListBoxItem(mainJoinOperator, SetIndex));
                }


                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveNext();

            }


        }
        public void RefreshCriteriaListold()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount;
            int SetIndex;
            int TotalSetRec;

            lstSelectedCriteria.Items.Clear();
            if (cboReportList.SelectedIndex < 0)
            {
                return;
            }

            DataSet rs_critSet = null;
            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

            rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (rs_critSet.RowCount == 0)
            {
                //set all of them to 1, if any criteria exists
                modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = 1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (rs_critSet.RowCount == 0)
                {
                    return;
                }
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
           //LDW  rs_critSet.MoveLast();
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TotalSetRec = rs_critSet.RowCount;
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //LDW rs_critSet.MoveFirst();

            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetIndex = 0;
            //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SetCount = 0;
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!rs_critSet.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex - 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetCount = SetCount + 1;

                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet!CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + rs_critSet["CriteriaSet"];
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //LDW modGlobal.gv_rs.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalRec = modGlobal.gv_rs.RowCount;
                //LDW modGlobal.gv_rs.MoveFirst();
                //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Cindex = 0;
                //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CSuff = "";
                //UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CPref = "Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value + ": (";

                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Cindex = Cindex + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Cindex == TotalRec)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (TotalRec == 1)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            CSuff = " (" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + ") )";
                        }
                        else
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            CSuff = ")";
                        }
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CSuff = " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object Cindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Cindex == 1)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object CPref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedCriteria.Items.Add(CPref + modGlobal.gv_rs.rdoColumns["CriteriaCaption"].Value + CSuff);
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSelectedCriteria.Items.Add("          " + modGlobal.gv_rs.rdoColumns["CriteriaCaption"].Value + CSuff);
                    }
                    //UPGRADE_ISSUE: ListBox property lstSelectedCriteria.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    Support.SetItemData(lstSelectedCriteria, lstSelectedCriteria.Items.Count-1, modGlobal.gv_rs.rdoColumns["criteriaID"].Value);


                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (SetCount == TotalSetRec)
                {
                }
                else
                {
                    lstSelectedCriteria.Items.Add(new ListBoxItem("And", SetIndex));
                }


                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveNext();

            }


        }

        public void InitCriteria()
        {
            //RefreshTableFieldsForCriteria

            //cboOperator.ListIndex = -1
            //txtCriteria = ""
            //cboJoinOp.Text = ""

        }

        private void lstFieldListForCriteria_Click()
        {
            RadTextBox txtCriteria = null;
            RadDropDownList cboOperator = null;
            //txtOperator = ""
            //UPGRADE_WARNING: Couldn't resolve default property of object cboOperator.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboOperator.ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object txtCriteria. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            txtCriteria = "";
        }

        public void RefreshCriteriaSetList()
        {

            //    MsgBox "is this obsolete?"

            //    If cboReportList.ListIndex < 0 Then
            //        Exit Sub
            //    End If
            //    gv_sql = "Select CriteriaSet "
            //    gv_sql = gv_sql & " from tbl_Setup_SavedAdhocReportCriteria "
            //    gv_sql = gv_sql & " where Report_ID = " & cboReportList.ItemData(cboReportList.ListIndex)
            //    gv_sql = gv_sql & " and CriteriaSet is not null "
            //    gv_sql = gv_sql & " group by  CriteriaSet "
            //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
            //    If gv_rs.RowCount > 0 Then
            //        gv_rs.MoveLast
            //        TotalSet = gv_rs.RowCount
            //        gv_rs.MoveFirst
            //    End If
            //
            //    cboCriteriaSet.Clear
            //    SetIndex = 1
            //    While Not gv_rs.EOF
            //        cboCriteriaSet.AddItem "Set " & SetIndex
            //        cboCriteriaSet.ItemData(cboCriteriaSet.Items.Count-1) = SetIndex
            //        SetIndex = SetIndex + 1
            //
            //        gv_rs.MoveNext
            //    Wend
            //
            //    cboCriteriaSet.AddItem "Set " & SetIndex
            //    cboCriteriaSet.ItemData(cboCriteriaSet.Items.Count-1) = SetIndex

        }

        public void ResetCriteriaSetOrder()
        {
            int j;
            var i = 0;
            int MaxSet;

            //update null join operators
            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //update the set order
            modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MaxSet = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (MaxSet > 0)
            {

                //give the max number to the null criteria set
                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //adjust the order of the set
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                for (i = 1; i <= MaxSet; i++)
                {
                    modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    if (modGlobal.gv_rs.RowCount == 0)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        for (j = i; j <= MaxSet; j++)
                        {
                            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                            //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + j - 1;
                            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                            //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        }

                    }
                }
            }

        }
        public void ResetSumCriteriaSetOrder()
        {
            int j;
            var i = 0;
            int MaxSet;

            //update null join operators
            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //update the set order
            modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportSumCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MaxSet = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (MaxSet > 0)
            {

                //give the max number to the null criteria set
                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //adjust the order of the set
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                for (i = 1; i <= MaxSet; i++)
                {
                    modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportSumCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    if (modGlobal.gv_rs.RowCount == 0)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        for (j = i; j <= MaxSet; j++)
                        {
                            modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                            //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + j - 1;
                            modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + Support.GetItemData(cboReportList, cboReportList.SelectedIndex);
                            //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        }

                    }
                }
            }

        }
        public void ResetCriteriaSetOrderForAllReports()
        {
            int j;
            var i = 0;
            int MaxSet;
            int SetNum;
            DataSet rs_critSet = null;
            int ReportID ;
            DataSet rs_reports = null;

            modGlobal.gv_sql = "Select Report_ID from tbl_Setup_SavedAdhocReports ";
            rs_reports = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            while (!rs_reports.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ReportID = rs_reports.rdoColumns["Report_ID"].Value;

                //update null join operators
                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update any null criteria set
                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";

                rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (rs_critSet.RowCount == 0)
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SetNum = 1;
                    //set all of them to a set number, if any criteria exists
                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";

                    rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (rs_critSet.RowCount > 0)
                    {
                        modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                        //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SetNum = SetNum + 1;
                    }

                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";

                    rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (rs_critSet.RowCount > 0)
                    {
                        modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                        //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }

                }



                //update the set order
                modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                //gv_sql = gv_sql & " and CriteriaSet is not null "
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MaxSet = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (MaxSet > 0)
                {

                    //give the max number to the null criteria set
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    //adjust the order of the set
                    //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    for (i = 1; i <= MaxSet; i++)
                    {
                        modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        if (modGlobal.gv_rs.RowCount == 0)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            for (j = i; j <= MaxSet; j++)
                            {
                                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportCriteria ";
                                //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + j - 1;
                                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                                //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            }

                        }
                    }
                }

                //LDW rs_reports.MoveNext();
            }

            ResetSumCriteriaSetOrderForAllReports();

        }
        public void ResetSumCriteriaSetOrderForAllReports()
        {
            int j;
            var i = 0;
            int MaxSet;
            int SetNum;
            DataSet rs_critSet = null;
            int ReportID ;
            DataSet rs_reports = null;

            modGlobal.gv_sql = "Select Report_ID from tbl_Setup_SavedAdhocReports ";
            rs_reports = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            while (!rs_reports.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ReportID = rs_reports.rdoColumns["Report_ID"].Value;

                //update null join operators
                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update any null criteria set
                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SavedAdhocReportSumCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";

                rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (rs_critSet.RowCount == 0)
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SetNum = 1;
                    //set all of them to a set number, if any criteria exists
                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";

                    rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (rs_critSet.RowCount > 0)
                    {
                        modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportSumCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                        //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SetNum = SetNum + 1;
                    }

                    modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReportSumCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";

                    rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (rs_critSet.RowCount > 0)
                    {
                        modGlobal.gv_sql = "update tbl_setup_SavedAdhocReportSumCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                        //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID =  " + ReportID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }

                }



                //update the set order
                modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SavedAdhocReportSumCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                //gv_sql = gv_sql & " and CriteriaSet is not null "
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MaxSet = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (MaxSet > 0)
                {

                    //give the max number to the null criteria set
                    modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    //adjust the order of the set
                    //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    for (i = 1; i <= MaxSet; i++)
                    {
                        modGlobal.gv_sql = "Select * from tbl_Setup_SavedAdhocReportSumCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        if (modGlobal.gv_rs.RowCount == 0)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            for (j = i; j <= MaxSet; j++)
                            {
                                modGlobal.gv_sql = "update tbl_Setup_SavedAdhocReportSumCriteria ";
                                //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + j - 1;
                                //UPGRADE_WARNING: Couldn't resolve default property of object ReportID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " where Report_ID = " + ReportID;
                                //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            }

                        }
                    }
                }

                //LDW rs_reports.MoveNext();
            }

        }
    }
}
