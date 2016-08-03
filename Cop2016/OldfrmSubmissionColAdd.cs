using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using Microsoft.VisualBasic.Compatibility.VB6;
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
    internal partial class OldfrmSubmissionColAdd : System.Windows.Forms.Form
    {

        //UPGRADE_WARNING: Event cboGroupList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboGroupList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            //Refresh Row list based on the Group that the user has selected

            if (cboGroupList.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where GroupID =  " + Support.GetItemData(cboGroupList, cboGroupList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Title ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            cboRowList.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                cboRowList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Title"].Value, modGlobal.gv_rs.rdoColumns["grouprowID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }

        private void cboSumField_Change()
        {

        }



        //UPGRADE_WARNING: Event cboSumOp.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSumOp_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            var LIndex = 0;

            if (cboSumOp.Text == "Count")
            {
                lstSumField.Items.Clear();
                //change the field to Discharge Date
                //retrieve the Discharge Date from the list of fields
                //gv_sql = "Select tbl_setup_DataDef.* "
                //gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_TableDef "
                //gv_sql = gv_sql & " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID "
                //gv_sql = gv_sql & " and tbl_setup_TableDef.BaseTable = 'PATIENT' "

                //gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName in ('DISCHARGE_DATE', 'OUTPATIENT ENCOUNTER DATE') "
                //gv_sql = gv_sql & " order by  tbl_setup_DataDef.FieldName "

                modGlobal.gv_sql = "EXEC getDateForIndicator " + Support.GetItemData(cboIndicator, cboIndicator.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);


                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = -1;
                //LDW modGlobal.gv_rs.MoveFirst();
                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    LIndex = LIndex + 1;
                    lstSumField.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                    //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSumField.SelectedIndex = LIndex;
                    lstSumField.Text = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                modGlobal.gv_rs.Dispose();
                //lstSumField.Enabled = False

            }
            else
            {
                //lstSumField.Enabled = True
                RefreshSumFieldList();

            }

            //If cboSumOp.Text = "Count" Then
            //    'retrieve the Discharge Date from the list of fields
            //    gv_sql = "Select tbl_setup_DataDef.* "
            //    gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_TableDef "
            //    gv_sql = gv_sql & " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID "
            //    gv_sql = gv_sql & " and tbl_setup_TableDef.BaseTable = 'PATIENT' "
            //    gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
            //    gv_sql = gv_sql & " order by  tbl_setup_DataDef.FieldName "
            //
            //     rdcSumFieldList.Refresh
            //     Set rdcSumFieldList.Resultset = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
            //
            //     cboSumField.Clear
            //     Table_ListIndex = -1
            //     LIndex = -1
            //     While Not rdcSumFieldList.Resultset.EOF
            //         LIndex = LIndex + 1
            //         Table_ListIndex = LIndex
            //
            //         cboSumField.AddItem rdcSumFieldList.Resultset!FieldName
            //         cboSumField.ItemData(cboSumField.NewIndex) = rdcSumFieldList.Resultset!DDID
            //         rdcSumFieldList.Resultset.MoveNext
            //     Wend
            //
            //End If
        }

        //UPGRADE_WARNING: Event cboSumOpToUpdate.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSumOpToUpdate_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            // SR - 4.28.2008 - do not assume that all count are counting discharge date
            //If cboSumOpToUpdate.Text = "Count" Then
            //    sstabUpdate.TabEnabled(1) = False
            //Else
            //    sstabUpdate.TabEnabled(1) = True
            //End If
        }

        private void cmdAddField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int NextsgfieldID;
            if (lstColumns.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a column to update.");
                return;
            }

            if (cboAllFields.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a field to add to list.");
                return;
            }

            if (cboSumOpToUpdate.Text == "Count" & lstSumFieldToUpdate.Items.Count > 0)
            {
                RadMessageBox.Show("Only one field can be selected for a Count operation.");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Update";


            //add the field
            //UPGRADE_WARNING: Couldn't resolve default property of object NextsgfieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NextsgfieldID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitSubGroupfields", "SubmitSubGroupfieldID");
            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitSubGroupfields";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitSubGroupfieldid, SubGroupID, aggregatefieldid) ";
            //UPGRADE_WARNING: Couldn't resolve default property of object NextsgfieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextsgfieldID + ",";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + "," + Support.GetItemData(cboAllFields, cboAllFields.SelectedIndex) + ") ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
           

            UpdateColDetails();

            RefreshFieldListToUpdate();
        }

        private void cmdAddSubmissionGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int newid;
            int  NextColID;
            int NextOrderNumber;
            var i = 0;
            bool fieldselected;

            if (cboGroupList.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a Group.");
                return;
            }

            if (cboRowList.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a Row.");
                return;
            }

            if (cboIndicator.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please define the indicator related to this column.");
                return;
            }

            if (cboSumOp.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please define the Summary Operation for this column.");
                return;
            }

            if (lstSumField.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please define at least one field that will be summarized for this column.");
                return;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object fieldselected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            fieldselected = false;
            if (cboSumOp.Text == "Sum")
            {
                for (i = 0; i <= lstSumField.Items.Count - 1; i++)
                {
                    if (lstSumField.GetSelected(i))
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object fieldselected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        fieldselected = true;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object fieldselected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (fieldselected == false)
                {
                    RadMessageBox.Show("Please define at least one field that will be summarized for this column.");
                    return;
                }
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Add";

            //find the next ordernumber
            modGlobal.gv_sql = " Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitSubGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where GroupRowID = " + My.MyProject.Forms.frmSubmissionSetup.rdcSubmissionFieldList.Resultset.rdoColumns["grouprowID"].Value;
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
            //UPGRADE_WARNING: Couldn't resolve default property of object NextColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NextColID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitSubGroup", "SubGroupID");
            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitSubGroup";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubGroupID, GroupRowID, Title, IndicatorID, AggregateFunction,  ShowonReport, OrderNumber) ";
            //UPGRADE_WARNING: Couldn't resolve default property of object NextColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextColID + ",";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRowList, cboRowList.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + ",'" + txtColName.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " " + Support.GetItemData(cboIndicator, cboIndicator.SelectedIndex) + ",";
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboSumOp.Text + "',";
            if (chkIncludeCol.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y',";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object NextOrderNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NextOrderNumber + ") ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            // SR - 4.25.2008 - commented out because regardless of what summary operation it should use ddid from selected fields...
            //    If cboSumOp.Text = "Count" Then
            //        newid = FindMaxRecID("tbl_Setup_Submitsubgroupfields", "SubmitsubgroupfieldID")
            //
            //'        gv_sql = "Select tbl_setup_DataDef.* "
            //'        gv_sql = gv_sql & " from tbl_setup_DataDef, tbl_setup_TableDef "
            //'        gv_sql = gv_sql & " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID "
            //'        gv_sql = gv_sql & " and tbl_setup_TableDef.BaseTable = 'PATIENT' "
            //'        gv_sql = gv_sql & " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' "
            //'        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
            //
            //        gv_sql = "Insert into tbl_Setup_Submitsubgroupfields (SubmitsubgroupfieldID, Subgroupid, AggregateFieldID)"
            //        gv_sql = gv_sql & " Values (" & newid
            //        gv_sql = gv_sql & "," & NextColID
            //        gv_sql = gv_sql & "," & lstSumField.ItemData(lstSumField.ListIndex) & ")"
            //        gv_cn.Execute gv_sql
            //
            //    Else
            //add the fields that will be summarized
            for (i = 0; i <= lstSumField.Items.Count - 1; i++)
            {
                if (lstSumField.GetSelected(i))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newid = modDBSetup.FindMaxRecID("tbl_Setup_Submitsubgroupfields", "SubmitsubgroupfieldID");

                    modGlobal.gv_sql = "Insert into tbl_Setup_Submitsubgroupfields (SubmitsubgroupfieldID, Subgroupid, AggregateFieldID)";
                    //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + newid;
                    //UPGRADE_WARNING: Couldn't resolve default property of object NextColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + "," + NextColID;
                    modGlobal.gv_sql = modGlobal.gv_sql + "," + Support.GetItemData(lstSumField, i) + ")";

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }
            }
            //    End If
            cboGroupList.SelectedIndex = -1;
            cboGroupList.Text = "";
            cboRowList.SelectedIndex = -1;
            cboRowList.Text = "";
            txtColName.Text = "";
            cboIndicator.SelectedIndex = -1;
            cboIndicator.Text = "";
            cboSumOp.SelectedIndex = -1;
            cboSumOp.Text = "";
            lstSumField.SelectedIndex = -1;
            lstSumField.Text = "";

            RefreshColumnList();


        }

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();

        }

        private void cmdDeleteColumn_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstColumns.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete '" + Support.GetItemString(lstColumns, lstColumns.SelectedIndex) + "'?", MessageBoxButtons.YesNo, "Delete Column"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_Action = "Delete";

                modGlobal.gv_sql = "Delete tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroupFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshColumnList();

            }


        }

        private void cmdMoveDown_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int CurrentFieldindex;
            string CurrentField = null;
            DataSet thisrs = null;

            DataSet rs = null;
            if (lstColumns.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "Select OrderNumber, GroupRowID  from tbl_Setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupID = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value))
                {
                    //reorganize the fields
                }
                else
                {

                    modGlobal.gv_sql = "Select max(OrderNumber) as MaxOrdNum from tbl_Setup_SubmitSubGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where GroupRowID = " + modGlobal.gv_rs.rdoColumns["grouprowID"].Value;
                    rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    if (modGlobal.gv_rs.rdoColumns["OrderNumber"].Value < rs.rdoColumns["maxordnum"].Value)
                    {


                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CurrentField = Support.GetItemString(lstColumns, lstColumns.SelectedIndex);
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CurrentFieldindex = lstColumns.SelectedIndex;
                        //update the field that is one order higher than this one
                        modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where GroupRowID = " + modGlobal.gv_rs.rdoColumns["grouprowID"].Value;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and OrderNumber = " + modGlobal.gv_rs.rdoColumns["OrderNumber"].Value + 1;
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //update this field
                        modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + modGlobal.gv_rs.rdoColumns["OrderNumber"].Value + 1;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshColumnList();

                        //set focus on the same field after refresh
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (CurrentFieldindex < lstColumns.Items.Count)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            lstColumns.SelectedIndex = CurrentFieldindex + 1;
                        }

                    }
                }

            }
        }

        private void cmdMoveUp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
           int CurrentFieldindex;
            string CurrentField = null;
            DataSet thisrs = null;



            if (lstColumns.SelectedIndex > -1)
            {

                modGlobal.gv_sql = "Select OrderNumber, GroupRowID  from tbl_Setup_SubmitSubGroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupID = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OrderNumber"].Value))
                {
                    //reorganize the fields
                }
                else
                {
                    if (modGlobal.gv_rs.rdoColumns["OrderNumber"].Value > 1)
                    {

                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CurrentField = Support.GetItemString(lstColumns, lstColumns.SelectedIndex);
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        CurrentFieldindex = lstColumns.SelectedIndex;
                        //update the field that is one order higher than this one
                        modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + modGlobal.gv_rs.rdoColumns["OrderNumber"].Value;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where GroupRowID = " + modGlobal.gv_rs.rdoColumns["grouprowID"].Value;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and OrderNumber = " + modGlobal.gv_rs.rdoColumns["OrderNumber"].Value - 1;
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //update this field
                        modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + modGlobal.gv_rs.rdoColumns["OrderNumber"].Value - 1;
                        modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshColumnList();

                        //set focus on the same field after refresh
                        //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (CurrentFieldindex > 0)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object CurrentFieldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            lstColumns.SelectedIndex = CurrentFieldindex - 1;
                        }

                    }
                }

            }

        }

        private void cmdRemoveField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstColumns.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a column to update.");
                return;
            }

            if (lstSumFieldToUpdate.Items.Count == 1)
            {
                RadMessageBox.Show("At least one field is required in the selected summarized fields list. Please add a field to the list before removing the existing one.");
                return;
            }

            if (lstSumFieldToUpdate.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select field to remove.");
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete '" + Support.GetItemString(lstSumFieldToUpdate, lstSumFieldToUpdate.SelectedIndex) + "' from the list of selected fields?", MsgBoxStyle.YesNo, "Delete Field"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.No))
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Update";


            modGlobal.gv_sql = "delete tbl_Setup_SubmitSubGroupfields ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitSubGroupfieldID = " + Support.GetItemData(lstSumFieldToUpdate, lstSumFieldToUpdate.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            UpdateColDetails();

            RefreshFieldListToUpdate();

        }

        private void cmdUpdateColumn_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (lstColumns.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a column to update.");
                return;
            }
            if (string.IsNullOrEmpty(txtColNameToUpdate.Text))
            {
                RadMessageBox.Show("Please define the Column name.");
                return;
            }
            if (cboIndicatorToUpdate.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please define the indicator associated with this column.");
                return;
            }
            if (cboSumOpToUpdate.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please define the summarization type.");
                return;
            }
            //If cboSumFieldToUpdate.ListIndex < 0 Then
            //    MsgBox "Please define the summarized field."
            //    Exit Sub
            //End If


            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Update";

            UpdateColDetails();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_SubmitColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_SubmitColID = Support.GetItemData(lstColumns, lstColumns.SelectedIndex);

            RefreshColumnList();


        }

        private void Command1_Click()
        {

        }

        private void frmSubmissionColAdd_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            int OrdNum;
            RadTextBox txtGroupToUpdate = null;
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

            sstabColumns.SelectedIndex = 0;
            sstabUpdate.SelectedIndex = 0;

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
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
            while (!modGlobal.gv_rs.EOF)
            {
                cboGroupList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value, modGlobal.gv_rs.rdoColumns["groupid"].Value));

                //UPGRADE_WARNING: Couldn't resolve default property of object txtGroupToUpdate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                txtGroupToUpdate = modGlobal.gv_rs.rdoColumns["GroupName"].Value;
                //cboGroupListToUpdate.AddItem gv_rs!GroupName
                //cboGroupListToUpdate.ItemData(cboGroupListToUpdate.NewIndex) = gv_rs!GroupID

                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            //Refresh the row list
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where GroupID = -1 ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Title ";

            //rdcFieldList.Refresh
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            cboRowList.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                cboRowList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Title"].Value, modGlobal.gv_rs.rdoColumns["grouprowID"].Value));

                cboRowListToUpdate.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Title"].Value, modGlobal.gv_rs.rdoColumns["grouprowID"].Value));

                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            RefreshSumFieldList();
            RefreshIndicatorList();
            RefreshColumnList();

            //Re-order every set
            DataSet rs_row = null;
            DataSet rs_subg = null;
            modGlobal.gv_sql = "Select GroupRowID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitsubgroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " group by GroupRowID ";
            rs_row = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            while (!rs_row.EOF)
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitsubgroup ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where GroupRowID = " + rs_row.rdoColumns["grouprowID"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " order by OrderNumber ";
                rs_subg = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object OrdNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                OrdNum = 0;
                while (!rs_subg.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object OrdNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    OrdNum = OrdNum + 1;
                    modGlobal.gv_sql = "Update tbl_setup_SubmitSubGroup ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object OrdNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set OrderNumber = " + OrdNum;
                    modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid = " + rs_subg.rdoColumns["SubGroupID"].Value;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //LDW rs_subg.MoveNext();
                }
                //LDW rs_row.MoveNext();
            }

        }

        public void RefreshIndicatorList()
        {
            //retrieve the list of Indicators
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '' or State is Null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboIndicator.Items.Clear();
            cboIndicatorToUpdate.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                cboIndicator.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));

                cboIndicatorToUpdate.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));

                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }

        public void RefreshSumFieldList()
        {
            //retrieve the list of Patient Table Fields (only discharge date or numeric fields)
            modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and (upper(tbl_setup_DataDef.fieldname) in ('DISCHARGE_DATE', 'OUTPATIENT ENCOUNTER DATE') ";
            modGlobal.gv_sql = modGlobal.gv_sql + " or tbl_setup_DataDef.fieldtype = 'Number') ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_DataDef.FieldName ";


            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcSumFieldList.CtlRefresh();
            rdcSumFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcSumFieldList.CtlRefresh();

            lstSumField.Items.Clear();
            cboAllFields.Items.Clear();

            while (!rdcSumFieldList.Resultset.EOF)
            {
                lstSumField.Items.Add(new ListBoxItem(rdcSumFieldList.Resultset.rdoColumns["FieldName"].Value, rdcSumFieldList.Resultset.rdoColumns["DDID"].Value));

                cboAllFields.Items.Add(new ListBoxItem(rdcSumFieldList.Resultset.rdoColumns["FieldName"].Value, rdcSumFieldList.Resultset.rdoColumns["DDID"].Value));

                rdcSumFieldList.Resultset.MoveNext();
            }


        }
        public void RefreshColumnList()
        {

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
            lstColumns.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstColumns.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupRow"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupCol"].Value, modGlobal.gv_rs.rdoColumns["SubGroupID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();

            lblGroupToUpdate.Text = "";
            cboRowListToUpdate.SelectedIndex = -1;
            txtColNameToUpdate.Text = "";
            cboIndicatorToUpdate.SelectedIndex = -1;
            cboSumOpToUpdate.SelectedIndex = -1;
            lstSumFieldToUpdate.Items.Clear();
            lstSumFieldToUpdate.SelectedIndex = -1;
        }

        private void frmSubmissionColAdd_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
        {
            string colnames = null;
            //let's make sure that for all columns with Sum operation
            // only numeric fields have been selected.


            modGlobal.gv_sql = "Select ";
            modGlobal.gv_sql = modGlobal.gv_sql + " g.GroupName + '/' + gr.Title + '/' +  sg.Title as cols ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (((tbl_setup_SubmitsubGroupfields as sgf ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SubmitsubGroup as sg ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on sgf.subgroupid = sg.subgroupid) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Submitgrouprow as gr ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on gr.grouprowid = sg.grouprowid) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Submitgroup as g ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on gr.groupid = g.groupid) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Datadef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on sgf.aggregatefieldid = dd.ddid ";
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
            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(sg.aggregatefunction) = 'SUM' ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and upper(dd.Fieldtype) <> 'NUMBER' ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object colnames. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                colnames = "";
                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object colnames. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    colnames = Strings.Chr(10) + Strings.Chr(13) + modGlobal.gv_rs.rdoColumns["cols"].Value;
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object colnames. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                RadMessageBox.Show("At least one aggregate field defined for the following Column(s) with Sum operation, is not numeric. Please correct the field list before closing this form." + Strings.Chr(10) + Strings.Chr(13) + colnames);
                //UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
                Cancel = true;
                
            }

        }

        //UPGRADE_WARNING: Event lstColumns.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void lstColumns_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshColToUpdate();
        }

        public void RefreshColToUpdate()
        {
            var i = 0;
            int thisGroupID;
            int thisRowID;

            modGlobal.gv_sql = "Select g.*, ";
            //i.Description as Indicator, "
            modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.ShowOnReport as ShowColonReport ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
            modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where c.SubGroupID = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lblGroupToUpdate.Text = modGlobal.gv_rs.rdoColumns["GroupName"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object thisRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            thisRowID = modGlobal.gv_rs.rdoColumns["grouprowID"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object thisGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            thisGroupID = modGlobal.gv_rs.rdoColumns["groupid"].Value;


            for (i = 0; i <= cboRowListToUpdate.Items.Count - 1; i++)
            {
                if (Support.GetItemData(cboRowListToUpdate, i) == modGlobal.gv_rs.rdoColumns["grouprowID"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cboRowListToUpdate.SelectedIndex = i;
                    //cboRowListToUpdate.Text = gv_rs!GroupRow
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            txtColNameToUpdate.Text = modGlobal.gv_rs.rdoColumns["GroupCol"].Value;

            for (i = 0; i <= cboIndicatorToUpdate.Items.Count - 1; i++)
            {
                if (Support.GetItemData(cboIndicatorToUpdate, i) == modGlobal.gv_rs.rdoColumns["IndicatorID"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cboIndicatorToUpdate.SelectedIndex = i;
                    //cboIndicatorToUpdate.Text = gv_rs!AggregateFunction
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            for (i = 0; i <= cboSumOpToUpdate.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (Support.GetItemString(cboSumOpToUpdate, i) == modGlobal.gv_rs.rdoColumns["AggregateFunction"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cboSumOpToUpdate.SelectedIndex = i;
                    //cboSumOpToUpdate.Text = gv_rs!AggregateFunction
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            // SR - 4.28.2008 - do not assume that all count are counting discharge date
            //    If cboSumOpToUpdate.Text = "Count" Then
            //        sstabUpdate.TabEnabled(1) = False
            //    Else
            //        sstabUpdate.TabEnabled(1) = True
            //    End If

            chkIncludeColToUpdate.CheckState = System.Windows.Forms.CheckState.Unchecked;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ShowcolOnReport"].Value))
            {
                if (modGlobal.gv_rs.rdoColumns["ShowcolOnReport"].Value == "Y")
                {
                    chkIncludeColToUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
                }
            }

            modGlobal.gv_rs.Dispose();


            RefreshFieldListToUpdate();

            //For i = 0 To cboSumFieldToUpdate.ListCount - 1
            //    If cboSumFieldToUpdate.ItemData(i) = gv_rs!AggregateFieldID Then
            //        cboSumFieldToUpdate.ListIndex = i
            //        'cboSumFieldToUpdate.Text = gv_rs!AggregateFunction
            //        Exit For
            //    End If
            //Next i


            //Refresh the row list
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitGroupRow ";
            //UPGRADE_WARNING: Couldn't resolve default property of object thisGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " where GroupID = " + thisGroupID;
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Title ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboRowListToUpdate.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                cboRowListToUpdate.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Title"].Value, modGlobal.gv_rs.rdoColumns["grouprowID"].Value));

                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            for (i = 0; i <= cboRowListToUpdate.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object thisRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (Support.GetItemData(cboRowListToUpdate, i) == thisRowID)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cboRowListToUpdate.SelectedIndex = i;
                    //cboSumFieldToUpdate.Text = gv_rs!AggregateFunction
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

        }


        public void RefreshFieldListToUpdate()
        {
            //Refresh the field list
            modGlobal.gv_sql = "Select sg.*, dd.fieldname ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Submitsubgroupfields as sg ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on sg.aggregatefieldid = dd.ddid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where sg.subgroupid = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.fieldname ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstSumFieldToUpdate.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstSumFieldToUpdate.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["submitSubgroupFieldID"].Value));

                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }


        public void UpdateColDetails()
        {
            int newid;
            //This is called not only when the update button is clicked
            // but also when field list is updated,
            // just to make sure to save changes if user forgot to click on update
            //The validation messages only show up when user click on Update button,
            // but when this sub routine is called from other places, we just want to skip the update

            if (lstColumns.SelectedIndex < 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(txtColNameToUpdate.Text))
            {
                return;
            }
            if (cboIndicatorToUpdate.SelectedIndex < 0)
            {
                return;
            }
            if (cboSumOpToUpdate.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set Title = '" + txtColNameToUpdate.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " GroupRowID = " + Support.GetItemData(cboRowListToUpdate, cboRowListToUpdate.SelectedIndex) + ",";
            modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID = ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboIndicatorToUpdate, cboIndicatorToUpdate.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " AggregateFunction = ";
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboSumOpToUpdate.Text + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + " ShowOnReport = ";
            if (chkIncludeColToUpdate.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Y'";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID = " + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);



            // SR - 4.28.2008 - do not assume that all count operations are counting discharge date!!
            // ADDED BACK 4.12.2010 - the MUST be a aggregate field selected
            if (cboSumOpToUpdate.Text == "Count")
            {

                if (lstSumFieldToUpdate.Items.Count == 0)
                {

                    //        gv_sql = "Delete tbl_Setup_SubmitSubGroupFields "
                    //        gv_sql = gv_sql & " where subgroupid = " & lstColumns.ItemData(lstColumns.ListIndex)
                    //        gv_cn.Execute gv_sql

                    //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newid = modDBSetup.FindMaxRecID("tbl_Setup_Submitsubgroupfields", "SubmitsubgroupfieldID");


                    modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' ";
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    if (modGlobal.gv_rs.RowCount > 0)
                    {


                        modGlobal.gv_sql = "Insert into tbl_Setup_Submitsubgroupfields (SubmitsubgroupfieldID, Subgroupid, AggregateFieldID)";
                        //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + newid;
                        modGlobal.gv_sql = modGlobal.gv_sql + "," + Support.GetItemData(lstColumns, lstColumns.SelectedIndex);
                        modGlobal.gv_sql = modGlobal.gv_sql + "," + modGlobal.gv_rs.rdoColumns["DDID"].Value + ")";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }

                }

            }


        }
    }
}
