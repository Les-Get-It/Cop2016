using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmSubmissionGroupAdd : System.Windows.Forms.Form
    {

        private void cmdAddSubmissionGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int NextGroupID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitGroup", "GroupID");
            int NextOrderNumber;

            if (string.IsNullOrEmpty(txtGroupName.Text))
            {
                RadMessageBox.Show("Please define the Group Name.");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Add";

            //find the next ordernumber
            modGlobal.gv_sql = " Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitGroup ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["maxordnum"].Value))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object NextOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    NextOrderNumber = 1;
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object NextOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    NextOrderNumber = modGlobal.gv_rs.rdoColumns["maxordnum"].Value + 1;
                }
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NextOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NextOrderNumber = 1;
            }
            modGlobal.gv_rs.Dispose();

            //add the group
            //UPGRADE_WARNING: Couldn't resolve default property of object NextGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitGroup";
            modGlobal.gv_sql = modGlobal.gv_sql + " (GroupID, GroupName, ShowGroupHeader, ShowOnReport, ShowTotal, OrderNumber, State, RecordStatus) ";
            //UPGRADE_WARNING: Couldn't resolve default property of object NextGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextGroupID + ",'" + txtGroupName.Text + "',";
            if (chkDisplayGroupTitle.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            }

            if (chkIncludeGroup.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            }
            if (chkShowTotal.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object NextOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NextOrderNumber + ",";
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

            modGlobal.gv_sql = modGlobal.gv_sql + ") ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


            RefreshGroupList();
            txtGroupName.Text = "";


        }

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();

        }

        private void cmdSubmissionGroupSetup_Click()
        {
        }

        private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            string MoveToModule = null;

            if (lstGroups.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want this group to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Update tbl_Setup_submitGroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
            modGlobal.gv_sql = modGlobal.gv_sql + " where groupID = " + Support.GetItemData(lstGroups, lstGroups.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            sstabGroup.SelectedIndex = 0;
            RefreshGroupList();
            RefreshGroupToUpdate();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Update";


        }

        private void cmdDeleteGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstGroups.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete '" + Support.GetItemString(lstGroups, lstGroups.SelectedIndex) + "'?", MessageBoxButtons.YesNo, "Delete Group"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_Action = "Delete";

                modGlobal.gv_sql = "Delete tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubGroupID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitSubGroup, tbl_setup_SubmitGroupRow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_SubmitSubGroup.GroupRowID = tbl_setup_SubmitGroupRow.GroupRowID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitGroupRow.GroupID = " + Support.GetItemData(lstGroups, lstGroups.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where GrouprowID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select GroupRowID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " GroupID = " + Support.GetItemData(lstGroups, lstGroups.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitGroupRow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " GroupID = " + Support.GetItemData(lstGroups, lstGroups.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " GroupID = " + Support.GetItemData(lstGroups, lstGroups.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshGroupList();
            }


        }

        private void cmdMoveDown_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int thisindex;
            int maxordnum;
            int CurrOrderNum; ;
            int ThisFieldID;

            if (lstGroups.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisFieldID = Support.GetItemData(lstGroups, lstGroups.SelectedIndex);

            modGlobal.gv_sql = "Select ordernumber ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + "  where groupID = " + ThisFieldID;
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CurrOrderNum = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;

            modGlobal.gv_sql = "Select max(ordernumber) as maxordnum ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object maxordnum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            maxordnum = 0;
            if (!string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["maxordnum"].Value))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object maxordnum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                maxordnum = modGlobal.gv_rs.rdoColumns["maxordnum"].Value;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object maxordnum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (CurrOrderNum < maxordnum)
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisindex = lstGroups.SelectedIndex + 1;

                //update order number of the field prior to this one
                modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum;
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  ordernumber = " + CurrOrderNum + 1;

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  groupID = " + ThisFieldID;

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshGroupList();

                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lstGroups.SelectedIndex = thisindex;

            }
        }

        private void cmdMoveUp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int thisindex;
            int CurrOrderNum; ;
            int ThisFieldID;
            if (lstGroups.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisFieldID = Support.GetItemData(lstGroups, lstGroups.SelectedIndex);

            modGlobal.gv_sql = "Select ordernumber ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " where groupID = " + ThisFieldID;
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CurrOrderNum = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;

            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if ((CurrOrderNum - 1) > 0)
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisindex = lstGroups.SelectedIndex - 1;

                //update order number of the field prior to this one
                modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum;
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  ordernumber = " + (CurrOrderNum - 1);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "Update tbl_setup_submitgroup ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + (CurrOrderNum - 1);
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  groupID = " + ThisFieldID;

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshGroupList();

                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lstGroups.SelectedIndex = thisindex;

            }
        }

        private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstGroups.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a group from the list to update");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Update";

            modGlobal.gv_sql = "update tbl_Setup_SubmitGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set GroupName = '" + txtGroupNameToUpdate.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " ShowGroupHeader = ";
            if (chkDisplayGroupTitleToUpdate.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y', ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " ShowOnReport = ";
            if (chkIncludeGroupToUpdate.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y' ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " ShowTotal = ";
            if (chkShowTotalToUpdate.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y' ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " Where GroupID = " + Support.GetItemData(lstGroups, lstGroups.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_SubmitGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_SubmitGroupID = Support.GetItemData(lstGroups, lstGroups.SelectedIndex).ToString();

            RefreshGroupList();

        }

        private void frmSubmissionGroupAdd_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            int OrdNum;
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_status == "TEST")
            {
                cmdChangeStatus.Text = "Move to Active";
            }
            else
            {
                cmdChangeStatus.Text = "Move to Test";
            }

            sstabGroup.SelectedIndex = 0;

            //Re-order every set
            System.Data.DataSet rs_group = null;

            modGlobal.gv_sql = "Select GroupID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitgroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by ordernumber ";
            rs_group = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object OrdNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OrdNum = 0;
            while (!rs_group.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object OrdNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                OrdNum = OrdNum + 1;

                modGlobal.gv_sql = "Update tbl_setup_SubmitGroup ";
                //UPGRADE_WARNING: Couldn't resolve default property of object OrdNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + OrdNum;
                modGlobal.gv_sql = modGlobal.gv_sql + " where groupid = " + rs_group.rdoColumns["groupid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //LDW rs_group.MoveNext();
            }

            RefreshGroupList();

        }

        public void RefreshGroupList()
        {
            modGlobal.gv_sql = "Select *  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '" + modGlobal.gv_State + "')";
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
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Ordernumber, GroupName";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            lstGroups.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstGroups.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value, modGlobal.gv_rs.rdoColumns["groupid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();
        }

        //UPGRADE_WARNING: Event lstGroups.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void lstGroups_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstGroups.Items.Count == 0)
            {
                return;
            }
            RefreshGroupToUpdate();

        }

        public void RefreshGroupToUpdate()
        {
            modGlobal.gv_sql = "Select *  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup ";
            if (lstGroups.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where GroupID = " + Support.GetItemData(lstGroups, lstGroups.SelectedIndex);
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where GroupID = -1 ";
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount > 0)
            {
                txtGroupNameToUpdate.Text = modGlobal.gv_rs.rdoColumns["GroupName"].Value;
                chkDisplayGroupTitleToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;
                chkIncludeGroupToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;
                chkShowTotalToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowGroupHeader"].Value))
                {
                    if (modGlobal.gv_rs.rdoColumns["ShowGroupHeader"].Value == "Y")
                    {
                        chkDisplayGroupTitleToUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
                    }
                }
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value))
                {
                    if (modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value == "Y")
                    {
                        chkIncludeGroupToUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
                    }
                }
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowTotal"].Value))
                {
                    if (modGlobal.gv_rs.rdoColumns["ShowTotal"].Value == "Y")
                    {
                        chkShowTotalToUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
                    }
                }

                modGlobal.gv_rs.Dispose();
            }
            else
            {
                txtGroupNameToUpdate.Text = "";
            }


        }

        private void SSTab1_DblClick()
        {

        }
    }
}
