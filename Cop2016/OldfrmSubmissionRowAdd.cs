using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmSubmissionRowAdd : Form
    {

        private void cmdAddSubmissionGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int NextRowID;
            int NextOrderNumber;
            if (cboGroupList.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please Select a Group From the List.");
                return;
            }

            if (string.IsNullOrEmpty(txtRowName.Text))
            {
                RadMessageBox.Show("Please define the Row Name.");
                return;
            }


            modGlobal.gv_Action = "Add";

            //check for duplicates
            modGlobal.gv_sql = "Select g.* ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup as g left join tbl_Setup_SubmitGroupRow as r";
            modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID  ";
            modGlobal.gv_sql = string.Format("{0} Where g.GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex));
            modGlobal.gv_sql = string.Format("{0} and r.Title = '{1}'", modGlobal.gv_sql, txtRowName.Text);
            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            const string sqlTableName1 = "tbl_setup_SubmitGroup";
            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

            if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count > 0)   
            {
                RadMessageBox.Show("This row for the selected group already exists.");
                return;
            }

            //find the next ordernumber
            modGlobal.gv_sql = " Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitGroupRow ";
            modGlobal.gv_sql = string.Format("{0} Where GroupID = {1}", modGlobal.gv_sql, Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex));
            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            const string sqlTableName2 = "tbl_Setup_SubmitGroupRow";
            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
            if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count > 0)
            {
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["maxordnum"].Value))
                {
                    NextOrderNumber = 1;
                }
                else
                {
                    NextOrderNumber = modGlobal.gv_rs.rdoColumns["maxordnum"].Value + 1;
                }
            }
            else
            {
                NextOrderNumber = 1;
            }
            modGlobal.gv_rs.Dispose();

            //add the group
            NextRowID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitGroupRow", "GroupRowID");
            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitGroupRow";
            modGlobal.gv_sql = modGlobal.gv_sql + " (GroupRowID, GroupID, Title, ShowOnReport,  OrderNumber) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextRowID + ",";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + ",'" + txtRowName.Text + "',";
            if (chkIncludeRow.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + NextOrderNumber + ") ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            txtRowName.Text = "";
            RefreshRowList();
        }

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();

        }

        private void cmdSubmissionGroupSetup_Click()
        {
        }

        private void cmdDeleteRow_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstRows.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete '" + Support.GetItemString(lstRows, lstRows.SelectedIndex) + "'?", "Delete Row", MessageBoxButtons.YesNo, RadMessageIcon.Question));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_Action = "Delete";

                modGlobal.gv_sql = "Delete tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubGroupID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_SubmitSubGroup.GroupRowID = " + Support.GetItemData(lstRows, lstRows.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where GroupRowID = " + Support.GetItemData(lstRows, lstRows.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitGroupRow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " GroupRowID = " + Support.GetItemData(lstRows, lstRows.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshRowList();

            }



        }

        private void cmdMoveDown_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int thisindex;
            int CurrOrderNum;
            int ThisFieldID;

            if (lstRows.SelectedIndex < 0)
            {
                return;
            }

            ThisFieldID = Support.GetItemData(lstRows, lstRows.SelectedIndex);

            //retrieve the current order
            modGlobal.gv_sql = "Select ordernumber ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where grouprowid = " + Support.GetItemData(lstRows, lstRows.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CurrOrderNum = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;

            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (CurrOrderNum != lstRows.Items.Count)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisindex = lstRows.SelectedIndex + 1;

                modGlobal.gv_sql = "Select Groupid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where grouprowid = " + ThisFieldID;
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //update order number of the field prior to this one
                modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum;
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  ordernumber = " + CurrOrderNum + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + "  and groupID = " + modGlobal.gv_rs.rdoColumns["groupid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  grouprowID = " + ThisFieldID;
                modGlobal.gv_sql = modGlobal.gv_sql + "  and groupID = " + modGlobal.gv_rs.rdoColumns["groupid"].Value;

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshRowList();

                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lstRows.SelectedIndex = thisindex;
                //find the right field
                //For i = 1 To rdcFieldList.Resultset.RowCount
                //    If rdcFieldList.Resultset!DDID = ThisFieldID Then
                //        Exit For
                //    End If
                //    rdcFieldList.Resultset.MoveNext
                //Next i

            }

        }

        private void cmdMoveUp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int thisindex;
            int CurrOrderNum;
            int ThisFieldID;
            if (lstRows.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisFieldID = Support.GetItemData(lstRows, lstRows.SelectedIndex);

            //retrieve the current order
            modGlobal.gv_sql = "Select ordernumber ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where grouprowid = " + Support.GetItemData(lstRows, lstRows.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CurrOrderNum = modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;

            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (CurrOrderNum - 1 > 0)
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisindex = lstRows.SelectedIndex - 1;

                modGlobal.gv_sql = "Select Groupid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where grouprowid = " + ThisFieldID;
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //update order number of the field prior to this one
                modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum;
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  ordernumber = " + CurrOrderNum - 1;
                modGlobal.gv_sql = modGlobal.gv_sql + "  and groupID = " + modGlobal.gv_rs.rdoColumns["groupid"].Value;

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set ordernumber = " + CurrOrderNum - 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "  grouprowID = " + ThisFieldID;
                modGlobal.gv_sql = modGlobal.gv_sql + "  and groupID = " + modGlobal.gv_rs.rdoColumns["groupid"].Value;

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshRowList();

                //UPGRADE_WARNING: Couldn't resolve default property of object thisindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lstRows.SelectedIndex = thisindex;
                //find the right field
                //For i = 1 To rdcFieldList.Resultset.RowCount
                //    If rdcFieldList.Resultset!DDID = ThisFieldID Then
                //        Exit For
                //    End If
                //    rdcFieldList.Resultset.MoveNext
                //Next i

            }

        }

        private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstRows.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a row to update.");
                return;
            }
            if (cboGroupListToUpdate.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a Group for the row before updating.");
                return;
            }

            if (!string.IsNullOrEmpty(txtRowNameToUpdate.Text))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_Action = "Update";
                modGlobal.gv_sql = "update tbl_Setup_SubmitGroupRow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set Title = '" + txtRowNameToUpdate.Text + "',";
                modGlobal.gv_sql = modGlobal.gv_sql + " GroupID = " + Support.GetItemData(cboGroupListToUpdate, cboGroupListToUpdate.SelectedIndex) + ",";
                modGlobal.gv_sql = modGlobal.gv_sql + " ShowOnReport = ";
                if (chkIncludeRowToUpdate.CheckState == CheckState.Checked)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " 'Y' ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " Where GroupRowID = " + Support.GetItemData(lstRows, lstRows.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //UPGRADE_WARNING: Couldn't resolve default property of object gv_SubmitRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_SubmitRowID = Support.GetItemData(lstRows, lstRows.SelectedIndex).ToString();

                RefreshRowList();
            }
        }

        private void frmSubmissionRowAdd_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            var LIndex = 0;
            int FCount;
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
            sstabRow.SelectedIndex = 0;

            //re-order the rows
            System.Data.DataSet thisrs = null;
            modGlobal.gv_sql = "Select Groupid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgroup ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            while (!modGlobal.gv_rs.EOF)
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitgrouprow ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where groupid = " + modGlobal.gv_rs.rdoColumns["groupid"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " order by ordernumber ";
                thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FCount = 0;
                while (!thisrs.EOF)
                {
                    //first we make sure every field in this list has a number
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    FCount = FCount + 1;
                    modGlobal.gv_sql = "Update tbl_setup_submitgrouprow ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + FCount;
                    modGlobal.gv_sql = modGlobal.gv_sql + " where grouprowID = " + thisrs.rdoColumns["grouprowID"].Value;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //LDW thisrs.MoveNext();
                }
                //LDW modGlobal.gv_rs.MoveNext();
            }


            RefreshRowList();

            //Refresh the group list
            modGlobal.gv_sql = "Select * ";
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
            modGlobal.gv_sql = modGlobal.gv_sql + " order by GroupName";

            //rdcFieldList.Refresh
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            cboGroupList.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;

                cboGroupList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value, modGlobal.gv_rs.rdoColumns["groupid"].Value));

                cboGroupListToUpdate.Items.Add(modGlobal.gv_rs.rdoColumns["GroupName"].Value);
                //UPGRADE_ISSUE: ComboBox property cboGroupList.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Support.SetItemData(cboGroupListToUpdate, cboGroupList.NewIndex, modGlobal.gv_rs.rdoColumns["groupid"].Value);

                //LDW modGlobal.gv_rs.MoveNext();
            }


        }

        public void RefreshRowList()
        {

            modGlobal.gv_sql = "Select g.*, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
            modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID  ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '" + modGlobal.gv_State + "')";
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

            modGlobal.gv_sql = modGlobal.gv_sql + " order by g.Ordernumber, g.GroupName, r.OrderNumber, r.Title ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            lstRows.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstRows.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupRow"].Value, modGlobal.gv_rs.rdoColumns["grouprowID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            cboGroupListToUpdate.SelectedIndex = -1;
            cboGroupListToUpdate.Text = "";
            txtRowNameToUpdate.Text = "";
            chkIncludeRowToUpdate.CheckState = CheckState.Unchecked;

        }

        //UPGRADE_WARNING: Event lstRows.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void lstRows_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstRows.Items.Count == 0)
            {
                return;
            }
            RefreshRowToUpdate();
        }

        public void RefreshRowToUpdate()
        {
            var i = 0;
            modGlobal.gv_sql = "Select tbl_setup_SubmitGroupRow.*, tbl_Setup_SubmitGroup.GroupName  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow, tbl_Setup_SubmitGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_SubmitGroupRow.GroupID =  tbl_Setup_SubmitGroup.GroupID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitGroupRow.GroupRowID = " + Support.GetItemData(lstRows, lstRows.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            for (i = 0; i <= cboGroupListToUpdate.Items.Count - 1; i++)
            {
                if (Support.GetItemData(cboGroupListToUpdate, i) == modGlobal.gv_rs.rdoColumns["groupid"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cboGroupListToUpdate.SelectedIndex = i;
                    cboGroupListToUpdate.Text = modGlobal.gv_rs.rdoColumns["GroupName"].Value;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            txtRowNameToUpdate.Text = modGlobal.gv_rs.rdoColumns["Title"].Value;

            chkIncludeRowToUpdate.CheckState = CheckState.Unchecked;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value))
            {
                if (modGlobal.gv_rs.rdoColumns["ShowOnReport"].Value == "Y")
                {
                    chkIncludeRowToUpdate.CheckState = CheckState.Checked;
                }
            }

            modGlobal.gv_rs.Dispose();

        }
    }
}
