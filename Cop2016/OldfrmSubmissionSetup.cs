using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
// ERROR: Not supported in C#: OptionDeclaration
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using Telerik.WinControls.UI;

namespace COP2001
{
    internal partial class OldfrmSubmissionSetup : Form
    {

        //UPGRADE_WARNING: Event cboCleanUpFieldToAdd.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboCleanUpFieldToAdd_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            DataSet gv_temp = null;
            bool FindField;
            //UPGRADE_WARNING: Couldn't resolve default property of object FindField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            FindField = false;
            if (lstCleanUpFields.SelectedIndex < 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FindField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FindField = true;
            }
            else if (cboCleanUpFieldToAdd.SelectedIndex > -1)
            {
                if (Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex) != Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object FindField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    FindField = true;
                }
                else
                {
                    lstCleanUpFields.SelectedIndex = -1;
                    RefreshCleanupFieldCriteria();
                }
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object FindField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (FindField == true)
            {
                modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupItems ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex);
    
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitCleanupItems.state = '' or tbl_setup_submitCleanupItems.state is null) ";
                }
                else
                {
        
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitCleanupItems.state = '" + modGlobal.gv_State + "'";
                }
    
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.RecordStatus = '' or tbl_setup_SubmitCleanupItems.RecordStatus is null) ";
                }
                else
                {
        
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitCleanupItems.RecordStatus = '" + modGlobal.gv_status + "'";
                }

                gv_temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_temp.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (gv_temp.RowCount > 0)
                {
                    for (i = 0; i <= lstCleanUpFields.Items.Count - 1; i++)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object gv_temp!SubmitCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (Support.GetItemData(lstCleanUpFields, i) == gv_temp["SubmitCleanupID"])
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            lstCleanUpFields.SelectedIndex = i;
                            //UPGRADE_WARNING: Couldn't resolve default property of object FindField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            FindField = false;
                        }
                    }
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_temp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gv_temp.Dispose();
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object FindField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (FindField == true)
            {
                lstCleanUpFields.SelectedIndex = -1;
                RefreshCleanupFieldCriteria();
            }

            //define how the buttons should be disabled
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCleanupCrit ";
            if (cboCleanUpFieldToAdd.SelectedIndex < 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where  DDID = -1 ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where  DDID = " + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex);
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cmdCleanupAnd.Enabled = false;
            cmdCleanupOr.Enabled = false;
            cmdCleanupAddCrit.Enabled = true;
            txtJoinOperator.Text = "";

            if (modGlobal.gv_rs.RowCount > 0)
            {
                //LDW modGlobal.gv_rs.MoveLast();
            }

            if (modGlobal.gv_rs.RowCount == 1)
            {
                cmdCleanupAnd.Enabled = true;
                cmdCleanupOr.Enabled = true;
                cmdCleanupAddCrit.Enabled = false;
            }
            else if (modGlobal.gv_rs.RowCount > 1)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
                {
                    txtJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                }
            }


        }

        //UPGRADE_WARNING: Event cboCleanupLookupTables.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboCleanupLookupTables_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            optCleanupLookupTable.Checked = true;
            cboCleanupValueList.SelectedIndex = -1;
        }

        //UPGRADE_WARNING: Event cboCleanupValueList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboCleanupValueList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            optCleanupValue.Checked = true;
            cboCleanupLookupTables.SelectedIndex = -1;
            txtTypeinValue.Text = "";
        }



        public void RefreshValueOrLookupList()
        {
            var LIndex = 0;
            int Field_ListIndex;
            int LookupTableID;
            if (cboRecordCleanupField.SelectedIndex < 0)
            {
                cboRecordCleanupLookupList.Visible = false;
                cboRecordCleanupLookupList.SelectedIndex = -1;
                txtRecordCleanupValue.Visible = true;
                txtRecordCleanupValue.Text = "";
                return;
            }
            //after selecting each field,
            // if the field value is based on a lookup table
            //   display the drop down box with the related values
            // otherwise
            //   display the text box to type the value in

            modGlobal.gv_sql = "Select Lookuptableid from tbl_setup_DataDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(cboRecordCleanupField, cboRecordCleanupField.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and Lookuptableid is not null ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;
                cboRecordCleanupLookupList.Visible = true;
                txtRecordCleanupValue.Visible = false;
                cboRecordCleanupLookupList.Left = txtRecordCleanupValue.Left;
                cboRecordCleanupLookupList.Top = txtRecordCleanupValue.Top;

                modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
                //UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + LookupTableID;
                modGlobal.gv_sql = modGlobal.gv_sql + " order by id";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                cboRecordCleanupLookupList.Items.Clear();

                //UPGRADE_WARNING: Couldn't resolve default property of object Field_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Field_ListIndex = -1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = -1;
                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    LIndex = LIndex + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object Field_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Field_ListIndex = LIndex;

                    cboRecordCleanupLookupList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Id"].Value + ". " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));

                    //LDW modGlobal.gv_rs.MoveNext();
                }

            }
            else
            {
                cboRecordCleanupLookupList.Visible = false;
                cboRecordCleanupLookupList.SelectedIndex = -1;
                txtRecordCleanupValue.Visible = true;
                txtRecordCleanupValue.Text = "";

            }

        }

        //UPGRADE_WARNING: Event cboRecordCleanupField.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboRecordCleanupField_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshValueOrLookupList();

        }

        //UPGRADE_WARNING: Event cboRecordCleanupLookupList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboRecordCleanupLookupList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (cboRecordCleanupLookupList.SelectedIndex > -1)
            {
                chkRecordCleanupBlank.CheckState = CheckState.Unchecked;
                txtRecordCleanupValue.Text = "";
            }

        }

        //UPGRADE_WARNING: Event cboRecordCleanupSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboRecordCleanupSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshRecordCleanupSetDef();
        }

        //UPGRADE_WARNING: Event cboSumOp.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboSumOp_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (cboSumOp.Text == "Count")
            {
                //change the field to Discharge Date
                //retrieve the Discharge Date from the list of fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.FieldName = 'DISCHARGE_DATE' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_DataDef.FieldName ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //LIndex = -1
                //rdcSumFieldList.Resultset.MoveFirst
                //While Not rdcSumFieldList.Resultset.EOF
                //    LIndex = LIndex + 1
                //    If gv_rs!DDID = rdcSumFieldList.Resultset!DDID Then
                //        lstSumField.ListIndex = LIndex
                //    End If
                //    rdcSumFieldList.Resultset.MoveNext
                //Wend
                //gv_rs.Close
            }
        }


        //UPGRADE_WARNING: Event chkRecordCleanupBlank.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void chkRecordCleanupBlank_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (chkRecordCleanupBlank.CheckState == CheckState.Checked)
            {
                cboRecordCleanupLookupList.SelectedIndex = -1;
                txtRecordCleanupValue.Text = "";
            }

        }

        private void cmdAddCol_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            bool FoundIt;
            int thisColID = 0;

            frmSubmissionColAddCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object thisColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add" | modGlobal.gv_Action == "Update" | modGlobal.gv_Action == "Delete")
            {
                RefreshSubmissionDefList();
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                modGlobal.gv_sql = "Select max(SubGroupID) as NewColID from tbl_setup_SubmitSubGroup ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object thisColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisColID = modGlobal.gv_rs.rdoColumns["NewColID"].Value;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Update")
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_SubmitColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object thisColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisColID = modGlobal.gv_SubmitColID;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object thisColID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (thisColID > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FoundIt = false;
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                while ((!rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count) & FoundIt == false)
                {
                    if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] == thisColID)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        FoundIt = true;
                    }
                    else
                    {
                        //LDW rdcSubmissionFieldList.Resultset.MoveNext();
                    }
                }
            }
        }

        private void cmdAddError_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "ERROR";
           frmSubmissionAddValidationCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshValidationMessages();
            }

        }

        private void cmdAddGroup_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            bool FoundIt;
            int thisGroupID = 0;
            frmSubmissionGroupAddCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object thisGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add" | modGlobal.gv_Action == "Update" | modGlobal.gv_Action == "Delete")
            {
                RefreshSubmissionDefList();
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                modGlobal.gv_sql = "Select max(GroupID) as NewGroupID from tbl_setup_SubmitGroup ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object thisGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisGroupID = modGlobal.gv_rs.rdoColumns["NewGroupID"].Value;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Update")
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_SubmitGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object thisGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisGroupID = modGlobal.gv_SubmitGroupID;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object thisGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (thisGroupID > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FoundIt = false;
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                while ((!rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count) & FoundIt == false)
                {
                    if (rdcSubmissionFieldList.Resultset.rdoColumns["groupid"].Value == thisGroupID)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        FoundIt = true;
                    }
                    else
                    {
                        //LDW rdcSubmissionFieldList.Resultset.MoveNext();
                    }
                }
            }
            RefreshColSummaryDef();

        }



        private void cmdAddRow_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            bool FoundIt;
            int thisRowID = 0;

            frmSubmissionRowAddCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object thisRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add" | modGlobal.gv_Action == "Update" | modGlobal.gv_Action == "Delete")
            {
                RefreshSubmissionDefList();
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                modGlobal.gv_sql = "Select max(GroupRowID) as NewRowID from tbl_setup_SubmitGroupRow ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object thisRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisRowID = modGlobal.gv_rs.rdoColumns["NewRowID"].Value;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Update")
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_SubmitRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object thisRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisRowID = Convert.ToInt32(modGlobal.gv_SubmitRowID);
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object thisRowID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (thisRowID > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FoundIt = false;
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                while ((!rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count) & FoundIt == false)
                {
                    if (rdcSubmissionFieldList.Resultset.rdoColumns["grouprowID"].Value == thisRowID)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        FoundIt = true;
                    }
                    else
                    {
                        //LDW rdcSubmissionFieldList.Resultset.MoveNext();
                    }
                }
            }
            RefreshColSummaryDef();

        }

        private void cmdAddSumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
            {
                return;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"]))
            {
                RadMessageBox.Show("A summarization criteria can only be defined for a column. Please select a column.");
                return;
            }
            //frmSubmissionAddSumDef.Show 1
           frmSubmissionAddCalcCritCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshColSummaryDef();
            }

        }




        private void cmdAddWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "WARNING";
           frmSubmissionAddValidationCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshValidationMessages();
            }
        }

        private void cmdChangeAddOrBetweenSets_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp = RadMessageBox.Show("Are you sure you want to change the join operator between all sets?", MessageBoxButtons.YesNo, "Change Join Operator Between All Sets");
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
            {
                return;
            }

            if (lstSummaryDef.Items.Count == 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitSubGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount > 0)
            {
                modGlobal.gv_sql = "update tbl_setup_SubmitSubGroup ";
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                }
                else if (Strings.UCase(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) == "OR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'AND'";
                }
                else if (Strings.UCase(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) == "AND")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'OR'";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                

            }
            RefreshColSummaryDef();

        }


        private void cmdChangeAndOrCond_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string NewOp = null;
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
            {
                return;
            }

            if (lstSummaryDef.SelectedIndex < 0)
            {
                return;
            }
            if (Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex) < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Select CriteriaSet, JoinOperator, SubGroupID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCriteriaID = " + Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (Strings.UCase(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) == "AND")
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewOp = "Or";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewOp = "And";
            }

            modGlobal.gv_sql = "update tbl_setup_SubmitCriteria ";
            //UPGRADE_WARNING: Couldn't resolve default property of object NewOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + NewOp + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where SubGroupID = " + modGlobal.gv_rs.rdoColumns["SubGroupID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshColSummaryDef();

        }

        private void cmdChangeCleanupStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            string MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");

            if (lstCleanUpFields.SelectedIndex < 0)
            {
                return;
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want this Data Clean-up item to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Update tbl_Setup_SubmitCleanupItems ";

            modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupid = " + Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshCleanupFields();
            RefreshCleanupFieldCriteria();

        }

        private void cmdChangeErrorStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            string MoveToModule = null;
            if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count == 0)
            {
                return;
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want this Error to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Update tbl_Setup_submitvalidation ";

            modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
            modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalid = " + rdcValidationErrors.Resultset.rdoColumns["submitvalid"].Value;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshValidationMessages();
            RefreshErrorCriteria();


        }

        private void cmdChangeToError_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count <= 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Warning to an Error?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {
                modGlobal.gv_sql = "update tbl_setup_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set ValType = 'ERROR' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Resultset.rdoColumns["submitvalid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshValidationMessages();
                RefreshWarningCriteria();
                RefreshErrorCriteria();
            }
        }

        private void cmdChangeToWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count <= 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to change this Error to a Warning?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {
                modGlobal.gv_sql = "update tbl_setup_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set ValType = 'WARNING' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Resultset.rdoColumns["submitvalid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshValidationMessages();
                RefreshWarningCriteria();
                RefreshErrorCriteria();
            }
        }

        private void cmdChangeWarningStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            string MoveToModule = null;
            if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count == 0)
            {
                return;
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want this Warning to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Update tbl_Setup_submitvalidation ";

            modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
            modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalid = " + rdcValidationWarnings.Resultset.rdoColumns["submitvalid"].Value;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshValidationMessages();
            RefreshWarningCriteria();
        }

        private void cmdCleanupAddCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            string CriteriaDesc = null;
            int NewSubmitCleanupCritID;
            int newCleanupID;
            int NewSubmitCleanupItemID;
            string thisfieldtype = null;


            modGlobal.gv_sql = "Select * from tbl_setup_Datadef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object thisfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            thisfieldtype = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
            modGlobal.gv_rs.Dispose();

            if (cboCleanUpFieldToAdd.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a field from the drop-down box.");
                return;
            }

            if (cboCleanupOperation.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please define the operation from the drop-down box.");
                return;
            }

            if (string.IsNullOrEmpty(txtTypeinValue.Text) & cboCleanupValueList.SelectedIndex < 0 & cboCleanupLookupTables.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please define a value or a lookup table.");
                return;
            }

            if (cboCleanupValueList.SelectedIndex > -1)
            {

                if (Strings.Mid(thisfieldtype, 1, 3) != "Tex")
                {
                    RadMessageBox.Show("A value from the list can only be selected for a text field.");
                    return;
                }
            }

            if (cboCleanupLookupTables.SelectedIndex >= 0)
            {

                if (Strings.Mid(thisfieldtype, 1, 3) != "Tex")
                {
                    RadMessageBox.Show("A lookup value can only be selected for a text field.");
                    return;
                }

                if (Support.GetItemString(cboCleanupOperation, cboCleanupOperation.SelectedIndex) != "<>")
                {
                    RadMessageBox.Show("You can only select '<>' with a lookup table option");
                    cboCleanupOperation.SelectedIndex = 1;
                    return;
                }

            }

            if (!string.IsNullOrEmpty(txtTypeinValue.Text))
            {

                if (Strings.Mid(thisfieldtype, 1, 3) == "Num" & !Information.IsNumeric(txtTypeinValue.Text))
                {
                    RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
                    return;
                }

                if (Strings.Mid(thisfieldtype, 1, 3) == "Dat" & !Information.IsDate(txtTypeinValue.Text))
                {
                    RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                    return;
                }

                if (Strings.Mid(thisfieldtype, 1, 3) == "Tim" & (Strings.Len(txtTypeinValue.Text) != 5))
                {
                    RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                    return;
                }

                if (Strings.Mid(thisfieldtype, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 2, 1))) | (Strings.Mid(txtTypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 5, 1)))))
                {
                    RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                    return;
                }

                if (Strings.Mid(thisfieldtype, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 4, 2)) > 59))
                {
                    RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                    return;
                }
            }

            modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupItems ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex);

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitCleanupItems.state = '' or tbl_setup_submitCleanupItems.state is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitCleanupItems.state = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.RecordStatus = '' or tbl_setup_SubmitCleanupItems.RecordStatus is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitCleanupItems.RecordStatus = '" + modGlobal.gv_status + "'";
            }

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount == 0)
            {
                NewSubmitCleanupItemID = modDBSetup.FindMaxRecID("tbl_setup_SubmitCleanupItems", "SubmitCleanupID");
                //add the field first and then the criteria
                modGlobal.gv_sql = "Insert into tbl_setup_submitCleanupitems (SubmitCleanupID, DDID, State, RecordStatus) ";

                modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NewSubmitCleanupItemID + ", " + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex) + ",";
    
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null,  ";
                }
                else
                {
        
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_State + "', ";
                }
    
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
        
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "' ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupItems ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex);
    
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
        
                    modGlobal.gv_sql = modGlobal.gv_sql + " and State = '" + modGlobal.gv_State + "'";
                }
    
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
        
                    modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
                }

                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object newCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            newCleanupID = modGlobal.gv_rs.rdoColumns["SubmitCleanupID"].Value;

            //UPGRADE_WARNING: Couldn't resolve default property of object NewSubmitCleanupCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewSubmitCleanupCritID = modDBSetup.FindMaxRecID("tbl_setup_SubmitCleanupCrit", "SubmitCleanupCritID");

            //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CriteriaDesc = cboCleanUpFieldToAdd.Text;
            if (cboCleanupValueList.SelectedIndex >= 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CriteriaDesc = CriteriaDesc + " " + cboCleanupOperation.Text;
                if (cboCleanupValueList.Text == "Y (Yes)")
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CriteriaDesc = CriteriaDesc + " ''Yes''";
                }
                else if (cboCleanupValueList.Text == "N (No)")
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CriteriaDesc = CriteriaDesc + " ''No''";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CriteriaDesc = CriteriaDesc + " " + cboCleanupValueList.Text;
                }
            }
            else if (cboCleanupLookupTables.SelectedIndex >= 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CriteriaDesc = CriteriaDesc + " is not in " + cboCleanupLookupTables.Text;
            }
            else if (!string.IsNullOrEmpty(txtTypeinValue.Text))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CriteriaDesc = CriteriaDesc + " " + cboCleanupOperation.Text;
                //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CriteriaDesc = CriteriaDesc + " " + txtTypeinValue.Text;
            }


            modGlobal.gv_sql = "Insert into tbl_setup_submitCleanupCrit ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCleanupCritID, SubmitCleanupID, DDID, FieldValue, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Operator, LookupTableID, CriteriaDesc) ";
            //UPGRADE_WARNING: Couldn't resolve default property of object NewSubmitCleanupCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NewSubmitCleanupCritID + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object newCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + newCleanupID + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboCleanUpFieldToAdd, cboCleanUpFieldToAdd.SelectedIndex) + ",";
            if (cboCleanupValueList.SelectedIndex < 0)
            {
                if (string.IsNullOrEmpty(txtTypeinValue.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtTypeinValue.Text + "',";
                }
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + Strings.Mid(cboCleanupValueList.Text, 1, 1) + "',";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboCleanupOperation.Text + "',";
            if (cboCleanupLookupTables.SelectedIndex < 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboCleanupLookupTables, cboCleanupLookupTables.SelectedIndex) + ",";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object CriteriaDesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + CriteriaDesc + "')";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            //update join operator for this set
            modGlobal.gv_sql = "Update tbl_setup_submitCleanupCrit ";
            modGlobal.gv_sql = modGlobal.gv_sql + "  set JoinOperator = ";
            if (string.IsNullOrEmpty(txtJoinOperator.Text))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtJoinOperator.Text + "'";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object newCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCleanupID = " + newCleanupID;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshCleanupFields();

            for (i = 0; i <= lstCleanUpFields.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object newCleanupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (Support.GetItemData(lstCleanUpFields, i) == newCleanupID)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstCleanUpFields.SelectedIndex = i;
                }
            }

            cboCleanUpFieldToAdd.SelectedIndex = -1;
            cboCleanupValueList.SelectedIndex = -1;
            cboCleanupOperation.SelectedIndex = -1;
            cboCleanupLookupTables.SelectedIndex = -1;
            txtTypeinValue.Text = "";

            cmdCleanupAnd.Enabled = true;
            cmdCleanupOr.Enabled = true;
            cmdCleanupAddCrit.Enabled = false;

        }

        private void cmdCleanupAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            cmdCleanupAnd.Enabled = false;
            cmdCleanupOr.Enabled = false;
            cmdCleanupAddCrit.Enabled = true;
            txtJoinOperator.Text = "AND";
        }

        private void cmdCleanupCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstCleanupCriteria.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {
                modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupCrit ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCleanupCritID = " + Support.GetItemData(lstCleanupCriteria, lstCleanupCriteria.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupItems where submitcleanupid not in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select submitcleanupid from tbl_setup_SubmitCleanupCrit )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshCleanupFieldCriteria();
            }
        }

        private void cmdCleanupOr_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            cmdCleanupAnd.Enabled = false;
            cmdCleanupOr.Enabled = false;
            cmdCleanupAddCrit.Enabled = true;
            txtJoinOperator.Text = "OR";

        }

        private void cmdCopyCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string[] SubCritIDs = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
            if (this.lstSummaryDef.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a criteria to copy.");
                return;
            }

            if (Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex) < 0)
            {
                RadMessageBox.Show("Select a criteria to copy.");
                return;
            }

            //frmSubmissionAddSumDef.Show 1
            //frmSubmissionCopyCriteria.Show 1

            SubCritIDs = new string[1];
            SubCritIDs[0] = Convert.ToString(Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex));

           frmMeasureCopyCriteriaCopy.SetCopyType("S");
           frmMeasureCopyCriteriaCopy.SetSubmitCriteriaID(SubCritIDs);
           frmMeasureCopyCriteriaCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshColSummaryDef();
            }

        }

        private void cmdCopyCriteriaSets_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int NewCritID;
            string NewCSet = null;
            string CSet = null;
            DialogResult resp;
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
            if (this.lstSummaryDef.SelectedIndex < 0)
            {
                RadMessageBox.Show("Select a criteria set to copy.");
                return;
            }

            if (Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex) < 0)
            {
                RadMessageBox.Show("Select a criteria set to copy.");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to create a new set as a copy of the selected set?", MessageBoxButtons.YesNo, "Duplicate Criteria Set");

            DataSet thisrs = null;
            if (resp == DialogResult.Yes)
            {
                modGlobal.gv_sql = "Select criteriaset from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where submitcriteriaid = " + Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

                modGlobal.gv_sql = "Select max(criteriaset) + 1 as newcset  from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object NewCSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewCSet = modGlobal.gv_rs.rdoColumns["NewCSet"].Value;

                modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and criteriaset = " + CSet;
                thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                while (!thisrs.EOF)
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");

                    modGlobal.gv_sql = "insert into tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCriteriaID, subgroupid, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, Value, DestDDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, CriteriaSet)  ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " Select ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", subgroupid, CriteriaTitle, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2, ValueOperator, Value, DestDDID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, FieldOperator, DateUnit, JoinOperator, ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object NewCSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, " + NewCSet;
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCriteriaID = " + thisrs.rdoColumns["SubmitCriteriaID"].Value;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //LDW thisrs.MoveNext();
                }

                RefreshColSummaryDef();

            }

        }


        private void cmdDelCleanUpField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstCleanUpFields.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this field from the list?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupCrit ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCleanupID = " + Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitCleanupItems ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitCleanupID = " + Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshCleanupFields();
            }
        }

        private void cmdDelError_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcValidationErrors.Tables[rdcValidationErrorsTable].Rows.Count <= 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this error?", MessageBoxButtons.YesNo, "Delete Error"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Resultset.rdoColumns["submitvalid"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Resultset.rdoColumns["submitvalid"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Resultset.rdoColumns["submitvalid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationErrors.Resultset.rdoColumns["submitvalid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshValidationMessages();
                RefreshErrorCriteria();
            }

        }

        private void cmdDeleteWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcValidationWarnings.Tables[rdcValidationWarningsTable].Rows.Count <= 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this warning?", MessageBoxButtons.YesNo, "Delete Warning"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Resultset.rdoColumns["submitvalid"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select SubmitValSetID from tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Resultset.rdoColumns["submitvalid"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Resultset.rdoColumns["submitvalid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID = " + rdcValidationWarnings.Resultset.rdoColumns["submitvalid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshValidationMessages();
                RefreshWarningCriteria();
            }

        }

        private void cmdDelSumCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to delete this criteria?", MessageBoxButtons.YesNo, "Delete Criteria");
            if (resp == DialogResult.No)
            {
                return;
            }

            if (lstSummaryDef.SelectedIndex >= 0)
            {
                modGlobal.gv_sql = "Delete tbl_Setup_SubmitCriteria ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCriteriaID = " + Support.GetItemData(lstSummaryDef, lstSummaryDef.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }



            ResetCriteriaSetOrder();
            RefreshColSummaryDef();

        }



        private void cmdDupSummarytoMeas_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "NotDefined";
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] < 0)
            {
                RadMessageBox.Show("Select a summary to copy.");
                return;
            }

           frmMeasureCopyCriteriaCopy.SetCopyType("S");
           frmMeasureCopyCriteriaCopy.SetSubGroupID(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"]);
           frmMeasureCopyCriteriaCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshColSummaryDef();
            }
        }


        private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            Printer Printer = new Printer();
            int li_cnt = 0;


            Printer.Print("Data Submission Cleanup");

            for (li_cnt = 0; li_cnt <= lstRecordCleanupCriteria.Items.Count - 1; li_cnt++)
            {
                Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstRecordCleanupCriteria, li_cnt));
                //Printer.Print Tab(10); li_cnt
            }

            Printer.Print("End of Data Submission Cleanup");
            Printer.EndDoc();


        }


        private void cmdPrintSummaryVal_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            modDocumentation.PrintSummaryValidation();
        }

        private void cmdRecordCleanupAdd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int IDFromLookup = 0;
            string fieldLookupTableID = null;
            string CritTitle = null;
            int NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCleanupRecord", "SubmitCleanupRecordID");
            string field1type = null;

            if (cboRecordCleanupSet.SelectedIndex < 0 | string.IsNullOrEmpty(cboRecordCleanupJoinOperator.Text) | cboRecordCleanupField.SelectedIndex < 0 | cboRecordCleanupOperator.SelectedIndex < 0 | (string.IsNullOrEmpty(txtRecordCleanupValue.Text) & chkRecordCleanupBlank.CheckState == 0 & cboRecordCleanupLookupList.SelectedIndex < 0))
            {
                RadMessageBox.Show("Please define every piece of criteria before adding it.");
                return;
            }

            //find the field type
            modGlobal.gv_sql = "Select FieldType from tbl_setup_Datadef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(cboRecordCleanupField, cboRecordCleanupField.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            field1type = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
            modGlobal.gv_rs.Dispose();


            //make sure that the typed value is of the same type as the field type
            if (!string.IsNullOrEmpty(txtRecordCleanupValue.Text) & txtRecordCleanupValue.Visible == true)
            {
                //If mid(field1type, 1, 3) = "Num" And Not IsNumeric(txtRecordCleanupValue) Then
                //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (Strings.Mid(field1type, 1, 3) == "Num" & !Information.IsNumeric(txtRecordCleanupValue.Text) & Strings.UCase(Strings.Trim(txtRecordCleanupValue.Text)) != "UTD")
                {
                    RadMessageBox.Show("The selected field is a numeric field, but the value is not a number. Please re-Specify...");
                    return;
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if ((Strings.Mid(field1type, 1, 3) == "Dat" | Strings.Mid(field1type, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtRecordCleanupValue.Text)) != "UTD")
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Dat" & !Information.IsDate(txtRecordCleanupValue.Text))
                    {
                        RadMessageBox.Show("The selected field is a date field, but the value is not a date. Please re-Specify...");
                        return;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & (Strings.Len(txtRecordCleanupValue.Text) != 5))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & ((!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 2, 1))) | (Strings.Mid(txtRecordCleanupValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtRecordCleanupValue.Text, 5, 1)))))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object field1type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Strings.Mid(field1type, 1, 3) == "Tim" & (Convert.ToDouble(Strings.Mid(txtRecordCleanupValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtRecordCleanupValue.Text, 4, 2)) > 59))
                    {
                        RadMessageBox.Show("The selected field is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
                        return;
                    }
                }
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CritTitle = string.Format("{0} {1}", cboRecordCleanupField.Text, cboRecordCleanupOperator.Text);

            if (!string.IsNullOrEmpty(txtRecordCleanupValue.Text))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CritTitle = string.Format("{0} {1}", CritTitle, txtRecordCleanupValue.Text);
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object fieldLookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            fieldLookupTableID = " Null ";
            if (cboRecordCleanupLookupList.SelectedIndex > -1)
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CritTitle = CritTitle + " " + cboRecordCleanupLookupList.Text;

                modGlobal.gv_sql = "Select *   ";
                modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_setup_Misclookuplist  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " + Support.GetItemData(cboRecordCleanupLookupList, cboRecordCleanupLookupList.SelectedIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Couldn't resolve default property of object IDFromLookup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                IDFromLookup = modGlobal.gv_rs.rdoColumns["Id"].Value;

            }

            if (chkRecordCleanupBlank.CheckState == CheckState.Checked)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CritTitle = CritTitle + " Blank ";
            }

            modGlobal.gv_sql = "Insert into tbl_Setup_SubmitCleanupRecord ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitCleanupRecordID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle,";
            modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Value, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Lookupid, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " State, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " RecordStatus ";
            modGlobal.gv_sql = modGlobal.gv_sql + " )";

            modGlobal.gv_sql = modGlobal.gv_sql + " values (";

            //UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object CritTitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + CritTitle + "', ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRecordCleanupField, cboRecordCleanupField.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboRecordCleanupOperator.Text + "', ";
            if (!string.IsNullOrEmpty(txtRecordCleanupValue.Text) & txtRecordCleanupValue.Visible == true)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtRecordCleanupValue.Text + "',";
            }
            else if (chkRecordCleanupBlank.CheckState == CheckState.Checked)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " 'Null',";
            }
            else if (cboRecordCleanupLookupList.SelectedIndex > -1 & cboRecordCleanupLookupList.Visible == true)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object IDFromLookup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + IDFromLookup + "',";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " null,";
            }
            if (cboRecordCleanupLookupList.SelectedIndex > -1 & cboRecordCleanupLookupList.Visible == true)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRecordCleanupLookupList, cboRecordCleanupLookupList.SelectedIndex) + ", ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + "'" + cboRecordCleanupJoinOperator.Text + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboRecordCleanupSet, cboRecordCleanupSet.SelectedIndex) + ", ";

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and  '" + modGlobal.gv_State + "',";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " null ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + ")";

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshRecordCleanupCriteriaList();

            cboRecordCleanupField.SelectedIndex = -1;

            cboRecordCleanupOperator.SelectedIndex = -1;
            cboRecordCleanupOperator.Text = "";

            cboRecordCleanupJoinOperator.SelectedIndex = -1;
            cboRecordCleanupJoinOperator.Text = "";

            cboRecordCleanupSet.SelectedIndex = -1;
            cboRecordCleanupSet.Text = "";
            cboRecordCleanupSet.Enabled = true;

            chkRecordCleanupBlank.CheckState = CheckState.Unchecked;
            txtRecordCleanupValue.Text = "";
            cboRecordCleanupLookupList.SelectedIndex = -1;

        }

        private void cmdRecordCleanupChangeOrAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string CSet = null;
            string newjoinop = null;
            if (lstRecordCleanupCriteria.SelectedIndex < 0)
            {
                return;
            }
            if (!(Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex) > 0))
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

            modGlobal.gv_sql = " select CriteriaSet, JoinOperator from tbl_setup_SubmitCleanupRecord  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupRecordID = " + Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex);
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CSet = modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
            {
                modGlobal.gv_sql = " select JoinOperator from tbl_setup_SubmitCleanupRecord  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupRecordID = " + Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex);
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

            modGlobal.gv_sql = " Update tbl_setup_SubmitCleanupRecord  ";
            //UPGRADE_WARNING: Couldn't resolve default property of object newjoinop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + newjoinop + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ";
            //UPGRADE_WARNING: Couldn't resolve default property of object CSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet = " + CSet;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshRecordCleanupCriteriaList();

        }

        private void cmdRecordCleanupRemove_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstRecordCleanupCriteria.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {

                modGlobal.gv_sql = "Delete tbl_Setup_SubmitCleanupRecord ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupRecordID = " + Support.GetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshRecordCleanupCriteriaList();
                //RefreshCriteriaSetList
            }


        }

        private void cmdRemoveCategory_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] <= 0)
            {
                return;
            }

            if (lstCategorySelectedList.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = " delete tbl_setup_submitSubGroupCategory ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " SubmitSubgroupCategoryid = " + Support.GetItemData(lstCategorySelectedList, lstCategorySelectedList.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshVerificationCategoriesSelected();
            RefreshVerificationCategories();

        }

        private void cmdSelectCategory_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] <= 0)
            {
                return;
            }

            if (lstCategoryLookupList.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = " insert into tbl_setup_submitSubGroupCategory (Subgroupid, Measure_CatID)";
            modGlobal.gv_sql = modGlobal.gv_sql + " values ( ";
            modGlobal.gv_sql = modGlobal.gv_sql + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] + ",  ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstCategoryLookupList, lstCategoryLookupList.SelectedIndex) + ") ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshVerificationCategoriesSelected();
            RefreshVerificationCategories();



        }

        private void cmdSubmissionPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            Printer Printer = new Printer();
            int li_cnt;
            //Printer.Print rdcSubmissionFieldList.Resultset!Description


            for (li_cnt = 0; li_cnt <= lstSummaryDef.Items.Count - 1; li_cnt++)
            {
                Printer.Print(FileSystem.TAB(15), Support.GetItemString(lstSummaryDef, li_cnt));
                //Printer.Print Tab(10); li_cnt
            }

            Printer.EndDoc();

        }

        private void cmdUpdateError_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "ERROR";
           frmSubmissionUpdateValidationCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Update")
            {
                RefreshValidationMessages();
            }


        }

        private void cmdUpdateWarning_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "WARNING";
           frmSubmissionUpdateValidationCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Update")
            {
                RefreshValidationMessages();
            }


        }

        private void cmdValidErrorAddCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "ERROR";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_ANDOR = "NotDefined";
           frmSubmissionValidCritWizardCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshErrorCriteria();
            }


        }

        private void cmdValidErrorAddCritAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "ERROR";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_ANDOR = "AND";
           frmSubmissionValidCritWizardCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshErrorCriteria();
            }
        }

        private void cmdValidErrorAddCritOr_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "ERROR";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_ANDOR = "OR";
           frmSubmissionValidCritWizardCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshErrorCriteria();
            }
        }

        private void cmdValidErrorDeleteCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (rdcValidationErrorCriteria.Tables[rdcValidationErrorCriteriaTable].Rows.Count <= 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {
                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationErrorCriteria.Resultset.rdoColumns["submitvalsetid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationErrorCriteria.Resultset.rdoColumns["submitvalsetid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationErrorCriteria.Resultset.rdoColumns["submitvalsetid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshErrorCriteria();
            }


        }

        private void cmdValidWarningAddCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "WARNING";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_ANDOR = "NotDefined";
           frmSubmissionValidCritWizardCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshWarningCriteria();
            }

        }

        private void cmdValidWarningAddCritAnd_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "WARNING";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_ANDOR = "AND";
           frmSubmissionValidCritWizardCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshWarningCriteria();
            }
        }

        private void cmdValidWarningAddCritOr_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "WARNING";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_ANDOR = "OR";
           frmSubmissionValidCritWizardCopy.ShowDialog();
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "Add")
            {
                RefreshWarningCriteria();
            }
        }

        private void cmdValidWarningDeleteCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (rdcValidationWarningCriteria.Tables[rdcValidationWarningCriteriaTable].Rows.Count <= 0)
            {
                return;
            }

            modGlobal.gv_resp = Convert.ToString(RadMessageBox.Show("Are you sure you want to delete this criteria?", MessageBoxButtons.YesNo, "Delete Criteria"));
            if (modGlobal.gv_resp == Convert.ToString(DialogResult.Yes))
            {
                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationWarningCriteria.Resultset.rdoColumns["submitvalsetid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSetGroup2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationWarningCriteria.Resultset.rdoColumns["submitvalsetid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = "Delete tbl_setup_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValSetID = " + rdcValidationWarningCriteria.Resultset.rdoColumns["submitvalsetid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshWarningCriteria();
            }

        }



        private void frmSubmissionSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            ssTabSubmission.ActiveWindow = sstabValidation0;
            


            if (modGlobal.gv_status == "TEST")
            {
                cmdChangeCleanupStatus.Text = "Move to Active";
                cmdChangeWarningStatus.Text = "Move to Active";
                cmdChangeErrorStatus.Text = "Move to Active";
            }
            else
            {
                cmdChangeCleanupStatus.Text = "Move to Test";
                cmdChangeWarningStatus.Text = "Move to Test";
                cmdChangeErrorStatus.Text = "Move to Test";
            }

            //update null Main join operators
            modGlobal.gv_sql = "update tbl_Setup_SubmitSubGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator is null ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            //update null join operators
            modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator is null ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            //update any null criteria set, if any null exists
            modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaSet is null ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                ResetCriteriaSetOrderForAll();
            }

            RefreshPatientFieldsList();
            RefreshSumFieldList();
            RefreshIndicatorList();
            RefreshSubmissionDefList();
            RefreshColSummaryDef();
            //RefreshColSummaryDefWithVerif
            RefreshCleanupFields();
            RefreshLookupTables();
            RefreshValidationMessages();
            RefreshErrorCriteria();
            RefreshWarningCriteria();
            RefreshVerificationCategories();
        }
        public void RefreshRecordCleanupSetDef()
        {
            if (cboRecordCleanupSet.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCleanupRecord ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaSet = " + Support.GetItemData(cboRecordCleanupSet, cboRecordCleanupSet.SelectedIndex);

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            if (modGlobal.gv_rs.RowCount == 0)
            {
                cboRecordCleanupJoinOperator.Text = "";
                cboRecordCleanupJoinOperator.Enabled = true;
            }
            else
            {
                cboRecordCleanupJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                cboRecordCleanupJoinOperator.Enabled = false;
            }
            modGlobal.gv_rs.Dispose();

        }

        public void RefreshRecordCleanupCriteriaList()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex = 0;
            int TotalRec = 0;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec = 0;
            DataSet rs_critSet = null;

            lstRecordCleanupCriteria.Items.Clear();

            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCleanupRecord ";

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where (State = '' or State is Null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " where  State = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

            rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (rs_critSet.RowCount > 0)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalSetRec = rs_critSet.RowCount;
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalSetRec = 0;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!rs_critSet.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex - 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetCount = SetCount + 1;

                modGlobal.gv_sql = "Select * from tbl_setup_submitCleanupRecord ";
                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet!CriteriaSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where CriteriaSet = " + rs_critSet["CriteriaSet"];
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
                        lstRecordCleanupCriteria.Items.Add(CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstRecordCleanupCriteria.Items.Add("          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    //UPGRADE_ISSUE: ListBox property lstRecordCleanupCriteria.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    Support.SetItemData(lstRecordCleanupCriteria, lstRecordCleanupCriteria.Items.Count-1, modGlobal.gv_rs.rdoColumns["SUBMITCLEANUPRECORDID"].Value);
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (SetCount == TotalSetRec)
                {
                }
                else
                {
                    lstRecordCleanupCriteria.Items.Add(new ListBoxItem("OR", SetIndex));
                }


                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveNext();

            }


            RefreshRecordCleanupSetList();

        }
        public void RefreshRecordCleanupSetList()
        {
            int oldindex = 0;
            int SetIndex = 0;
            DataSet thisrs = null;
            cboRecordCleanupSet.Items.Clear();

            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCleanupRecord ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of criteria
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!modGlobal.gv_rs.EOF)
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex + 1;

                modGlobal.gv_sql = "Select * from tbl_setup_SubmitCleanupRecord ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where criteriaSet = " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value;
                thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

    
                if (!string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    if (thisrs.rdoColumns["state"].Value == modGlobal.gv_State)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        oldindex = SetIndex;
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        oldindex = 0;
                    }
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    oldindex = SetIndex;
                }

    
                if (!string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    if (thisrs.rdoColumns["RecordStatus"].Value == modGlobal.gv_status)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        oldindex = SetIndex;
                        //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    }
                    else if (oldindex != 0)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        oldindex = 0;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                }
                else if (oldindex == 0)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    oldindex = SetIndex;
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object oldindex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (SetIndex == oldindex)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cboRecordCleanupSet.Items.Add("Set " + SetIndex);
                    //UPGRADE_ISSUE: ComboBox property cboRecordCleanupSet.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Support.SetItemData(cboRecordCleanupSet, cboRecordCleanupSet.Items.Count-1, SetIndex);
                }


                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            //always add a new one to the list in addition to the previous ones
            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboRecordCleanupSet.Items.Add(new ListBoxItem("Set " + SetIndex + 1, SetIndex + 1));

        }
        public void RefreshPatientFieldsList()
        {
            var LIndex = 0;

            //retrieve the list of table fields
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_tabledef as td ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on dd.BaseTableID =  td.BaseTableID  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where upper(td.BaseTable) = 'PATIENT' ";

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is Null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State = '' or dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //Display the list of fields
            cboRecordCleanupField.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                cboRecordCleanupField.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();


        }

        public void ResetCriteriaSetOrder()
        {
            int j = 0;
            var i = 0;
            int MaxSet;

            //update null join operators
            modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = 'And'";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
            modGlobal.gv_sql = modGlobal.gv_sql + " and JoinOperator is null ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //lstSummaryDef.ItemData(lstSummaryDef.ListIndex)
            //update the set order
            modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SubmitCriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MaxSet = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (MaxSet > 0)
            {

                //give the max number to the null criteria set
                modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //adjust the order of the set
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                for (i = 1; i <= MaxSet; i++)
                {
                    modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    if (modGlobal.gv_rs.RowCount == 0)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        for (j = i; j <= MaxSet; j++)
                        {
                            modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                            //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + j - 1;
                            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                            //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        }

                    }
                }
            }

        }

        public void ResetCriteriaSetOrderForAll()
        {
            int j;
            var i = 0;
            int MaxSet;
            int SetNum;
            DataSet rs_critSet = null;
            int SubGroupID;
            DataSet rs_SubGroup = null;


            modGlobal.gv_sql = "Select SubGroupID from tbl_Setup_SubmitSubGroup ";
            rs_SubGroup = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            while (!rs_SubGroup.EOF)
            {

                //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SubGroupID = rs_SubGroup.rdoColumns["SubGroupID"].Value;

                //update any null criteria set
                modGlobal.gv_sql = "Select CriteriaSet from tbl_Setup_SubmitCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is not null ";

                rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (rs_critSet.RowCount == 0)
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    SetNum = 1;
                    //set all of them to a set number, if any criteria exists
                    modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";

                    rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (rs_critSet.RowCount > 0)
                    {
                        modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                        //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'AND' ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        SetNum = SetNum + 1;
                    }

                    modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";

                    rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (rs_critSet.RowCount > 0)
                    {
                        modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object SetNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + SetNum;
                        //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID =  " + SubGroupID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and upper(JoinOperator) = 'OR' ";
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }

                }



                //update the set order
                modGlobal.gv_sql = "Select max(CriteriaSet) as MaxSet from tbl_Setup_SubmitCriteria ";
                //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                //gv_sql = gv_sql & " and CriteriaSet is not null "
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MaxSet = modGlobal.gv_rs.rdoColumns["MaxSet"].Value;
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (MaxSet > 0)
                {

                    //give the max number to the null criteria set
                    modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + MaxSet + 1;
                    //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                    modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet is null ";
                    modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                    //adjust the order of the set
                    //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    for (i = 1; i <= MaxSet; i++)
                    {
                        modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteria ";
                        //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + i;
                        modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        if (modGlobal.gv_rs.RowCount == 0)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object MaxSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            for (j = i; j <= MaxSet; j++)
                            {
                                modGlobal.gv_sql = "update tbl_Setup_SubmitCriteria ";
                                //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " set CriteriaSet = " + j - 1;
                                //UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + SubGroupID;
                                //UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + j;
                                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            }

                        }
                    }
                }

                //LDW rs_SubGroup.MoveNext();
            }

        }

        public void RefreshSubmissionDefList()
        {

            modGlobal.gv_sql = "Select g.*, c.showonreport as showcolonreport, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g left join tbl_Setup_SubmitGroupRow as r";
            modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_Setup_SubmitSubGroup as c ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.state = '' or g.state is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " Where g.state = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and g.RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by g.Ordernumber, g.GroupName, r.OrderNumber, r.Title, c.OrderNumber, c.Title ";
            //g = InputBox("", "", gv_sql)
            rdcSubmissionFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcSubmissionFieldList.CtlRefresh();

            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dbgSubmissionFieldList.CtlRefresh();


            RefreshSubmissionDetails();

        }

        //UPGRADE_WARNING: Event lstCleanUpFields.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void lstCleanUpFields_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (lstCleanUpFields.SelectedIndex > -1)
            {
                //gv_sql = "Select * from tbl_setup_submitCleanupItems "
                //gv_sql = gv_sql & " where SubmitCleanupID = " & lstCleanUpFields.ItemData(lstCleanUpFields.ListIndex)
                //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //txtCleanupDDID = gv_rs!DDID
            }
            RefreshCleanupFieldCriteria();

        }

        private void rdcSubmissionFieldList_Reposition()
        {

            RefreshSubmissionDetails();
            RefreshColSummaryDef();
            RefreshVerificationCategories();
            RefreshVerificationCategoriesSelected();


        }

        public void RefreshSumFieldList()
        {
            //retrieve the list of Patient Table Fields
            modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID =  tbl_setup_TableDef.BaseTableID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_TableDef.BaseTable = 'PATIENT' ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_DataDef.FieldName ";

            //rdcSumFieldList.Refresh
            rdcSumFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcSumFieldList.CtlRefresh();

            lstSumField.Items.Clear();
            cboCleanUpFieldToAdd.Items.Clear();
            while (!rdcSumFieldList.Resultset.EOF)
            {

                lstSumField.Items.Add(new ListBoxItem(rdcSumFieldList.Resultset.rdoColumns["FieldName"].Value, rdcSumFieldList.Resultset.rdoColumns["DDID"].Value));

                //also refresh the field list for clean up section
                cboCleanUpFieldToAdd.Items.Add(new ListBoxItem(rdcSumFieldList.Resultset.rdoColumns["FieldName"].Value, rdcSumFieldList.Resultset.rdoColumns["DDID"].Value));

                rdcSumFieldList.Resultset.MoveNext();
            }

        }

        public void RefreshIndicatorList()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            //retrieve the list of Indicators
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

            //rdcIndicatorList.Refresh
            rdcIndicatorList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcIndicatorList.CtlRefresh();

            cboIndicator.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Table_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!rdcIndicatorList.Resultset.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Table_ListIndex = LIndex;

                cboIndicator.Items.Add(new ListBoxItem(rdcIndicatorList.Resultset.rdoColumns["Description"].Value, rdcIndicatorList.Resultset.rdoColumns["IndicatorID"].Value));
                rdcIndicatorList.Resultset.MoveNext();
            }

        }

        public void RefreshSubmissionDetails()
        {
            var LIndex = 0;
            var i = 0;

            cboIndicator.SelectedIndex = -1;
            chkIncludeGroup.CheckState = CheckState.Unchecked;
            chkDisplayGroupTitle.CheckState = CheckState.Unchecked;
            chkIncludeRow.CheckState = CheckState.Unchecked;
            chkIncludeCol.CheckState = CheckState.Unchecked;
            lstSumField.Items.Clear();
            cboSumOp.SelectedIndex = -1;


            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(rdcSubmissionFieldList.Resultset.rdoColumns["IndicatorID"].Value))
                {
                    for (i = 0; i <= cboIndicator.Items.Count - 1; i++)
                    {
                        if (Support.GetItemData(cboIndicator, i) == rdcSubmissionFieldList.Resultset.rdoColumns["IndicatorID"].Value)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            cboIndicator.SelectedIndex = i;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(rdcSubmissionFieldList.Resultset.rdoColumns["ShowGroupHeader"].Value))
                {
                    if (rdcSubmissionFieldList.Resultset.rdoColumns["ShowGroupHeader"].Value == "Y")
                    {
                        chkDisplayGroupTitle.CheckState = CheckState.Checked;
                    }
                }
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(rdcSubmissionFieldList.Resultset.rdoColumns["ShowOnReport"].Value))
                {
                    if (rdcSubmissionFieldList.Resultset.rdoColumns["ShowOnReport"].Value == "Y")
                    {
                        chkIncludeGroup.CheckState = CheckState.Checked;
                    }
                }

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(rdcSubmissionFieldList.Resultset.rdoColumns["ShowRowOnReport"].Value))
                {
                    if (rdcSubmissionFieldList.Resultset.rdoColumns["ShowRowOnReport"].Value == "Y")
                    {
                        chkIncludeRow.CheckState = CheckState.Checked;
                    }
                }

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(rdcSubmissionFieldList.Resultset.rdoColumns["ShowcolOnReport"].Value))
                {
                    if (rdcSubmissionFieldList.Resultset.rdoColumns["ShowcolOnReport"].Value == "Y")
                    {
                        chkIncludeCol.CheckState = CheckState.Checked;
                    }
                }

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(rdcSubmissionFieldList.Resultset.rdoColumns["AggregateFunction"].Value))
                {
                    //cboSumOp.Text = rdcSubmissionFieldList.Resultset!AggregateFunction
                    for (i = 0; i <= cboSumOp.Items.Count - 1; i++)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        if (Support.GetItemString(cboSumOp, i) == rdcSubmissionFieldList.Resultset.rdoColumns["AggregateFunction"].Value)
                        {
                            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            cboSumOp.SelectedIndex = i;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                }

                modGlobal.gv_sql = "Select tbl_setup_SubmitSubGroupFields.*, tbl_setup_DataDef.FieldName ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitSubGroupFields inner join tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_SubmitSubGroupFields.aggregatefieldid =  tbl_setup_DataDef.ddid ";
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_SubmitSubGroupFields.SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_SubmitSubGroupFields.SubGroupID = -1 ";
                }
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = -1;
                while (!modGlobal.gv_rs.EOF)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    LIndex = LIndex + 1;
                    lstSumField.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["submitSubgroupFieldID"].Value));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                RefreshVerificationCategoriesSelected();

                //CatID = -1
                //For i = 0 To cboVerifCategory.ListCount - 1
                //    If cboVerifCategory.ItemData(i) = rdcSubmissionFieldList.Resultset!Measure_CATID Then
                //        CatID = i
                //    End If
                //Next i

                //cboVerifCategory.ListIndex = CatID

            }



        }

        public void RefreshColSummaryDefold()
        {
            var LIndex = 0;
            int TotalRec;
            modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
            }
            else
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"]))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                }
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by joinOperator ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstSummaryDef.Items.Clear();
            if (modGlobal.gv_rs.RowCount == 0)
            {
                return;
            }
            //LDW modGlobal.gv_rs.MoveLast();
            //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TotalRec = modGlobal.gv_rs.RowCount;
            //LDW modGlobal.gv_rs.MoveFirst();

            //Display the list of criteria

            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;

                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (LIndex + 1 == TotalRec)
                {
                    lstSummaryDef.Items.Add(modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value);
                    //don't show join operator for the last line
                }
                else
                {
                    lstSummaryDef.Items.Add(modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value);
                }
                //UPGRADE_ISSUE: ListBox property lstSummaryDef.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Support.SetItemData(lstSummaryDef, lstSummaryDef.Items.Count-1, modGlobal.gv_rs.rdoColumns["SubmitCriteriaID"].Value);
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }

        public void RefreshCleanupFields()
        {

            modGlobal.gv_sql = "Select tbl_setup_SubmitCleanupItems.* , tbl_setup_DataDef.FieldName ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitCleanupItems,tbl_setup_dataDef  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_SubmitCleanupItems.DDID = tbl_setup_dataDef.DDID  ";

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.state = '' or tbl_setup_SubmitCleanupItems.state is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitCleanupItems.state = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitCleanupItems.RecordStatus = '' or tbl_setup_SubmitCleanupItems.RecordStatus is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_SubmitCleanupItems.RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstCleanUpFields.Items.Clear();

            //Display the list of fields to cleanup
            while (!modGlobal.gv_rs.EOF)
            {
                lstCleanUpFields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["SubmitCleanupID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            RefreshCleanupFieldCriteria();

        }

        public void RefreshCleanupFieldCriteria()
        {
            var LIndex = 0;
            string CleanupJoinOperator = null;
            var TotalRec = 1;
            cmdCleanupAnd.Enabled = false;
            cmdCleanupOr.Enabled = false;
            cmdCleanupAddCrit.Enabled = true;
            txtJoinOperator.Text = "";

            modGlobal.gv_sql = "Select * from tbl_setup_SubmitCleanupCrit ";
            if (lstCleanUpFields.SelectedIndex < 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupID = -1";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupID = " + Support.GetItemData(lstCleanUpFields, lstCleanUpFields.SelectedIndex);
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by submitCleanupCritID ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstCleanupCriteria.Items.Clear();
            if (modGlobal.gv_rs.RowCount == 0)
            {
                return;
            }
            //LDW modGlobal.gv_rs.MoveLast();
            //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TotalRec = modGlobal.gv_rs.RowCount;
            //LDW modGlobal.gv_rs.MoveFirst();

            //Display the list of criteria
            //UPGRADE_WARNING: Couldn't resolve default property of object CleanupJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CleanupJoinOperator = "";
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;

                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (LIndex + 1 == TotalRec)
                {
                    lstCleanupCriteria.Items.Add(modGlobal.gv_rs.rdoColumns["CriteriaDesc"].Value);
                    //don't show join operator for the last line
                }
                else
                {
                    lstCleanupCriteria.Items.Add(modGlobal.gv_rs.rdoColumns["CriteriaDesc"].Value + " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value);
                }
                //UPGRADE_ISSUE: ListBox property lstCleanupCriteria.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                Support.SetItemData(lstCleanupCriteria, lstCleanupCriteria.Items.Count-1, modGlobal.gv_rs.rdoColumns["SubmitCleanupCritID"].Value);
                //UPGRADE_WARNING: Couldn't resolve default property of object CleanupJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                CleanupJoinOperator = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                //LDW modGlobal.gv_rs.MoveNext();
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (LIndex == 0)
            {
                cmdCleanupAnd.Enabled = true;
                cmdCleanupOr.Enabled = true;
                cmdCleanupAddCrit.Enabled = false;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            }
            else if (LIndex > 0)
            {

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(CleanupJoinOperator))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object CleanupJoinOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    txtJoinOperator.Text = CleanupJoinOperator;
                }
            }

            modGlobal.gv_rs.Dispose();

        }

        public void RefreshLookupTables()
        {

            modGlobal.gv_sql = "Select *  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where TableType = 'LOOKUP' ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            while (!modGlobal.gv_rs.EOF)
            {
                cboCleanupLookupTables.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }

        public void RefreshValidationMessages()
        {

            //retrieve the list of Validation Error messages
            modGlobal.gv_sql = "Select tbl_setup_submitValidation.*, tbl_setup_Indicator.Description as Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitValidation, tbl_setup_Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_submitValidation.IndicatorID = tbl_setup_Indicator.IndicatorID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.ValType = 'ERROR' ";

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.state = '' or tbl_setup_submitValidation.state is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.state = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.RecordStatus = '' or tbl_setup_submitValidation.RecordStatus is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.RecordStatus = '" + modGlobal.gv_status + "'";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_Indicator.Description ";

            rdcValidationErrors.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcValidationErrors.CtlRefresh();


            //retrieve the list of Validation Warning messages
            modGlobal.gv_sql = "Select tbl_setup_submitValidation.*, tbl_setup_Indicator.Description as Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitValidation, tbl_setup_Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_submitValidation.IndicatorID = tbl_setup_Indicator.IndicatorID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.ValType = 'WARNING' ";

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.state = '' or tbl_setup_submitValidation.state is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.state = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_submitValidation.RecordStatus = '' or tbl_setup_submitValidation.RecordStatus is null) ";
            }
            else
            {
    
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_submitValidation.RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by  tbl_setup_Indicator.Description ";

            rdcValidationWarnings.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcValidationWarnings.CtlRefresh();

        }

        private void rdcValidationErrors_Reposition()
        {
            RefreshErrorCriteria();
        }

        private void rdcValidationWarnings_Reposition()
        {
            RefreshWarningCriteria();
        }

        public void RefreshErrorCriteria()
        {
            int TotalRec;

            //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TotalRec = 0;

            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitValSet ";
            if (rdcValidationErrors.Resultset.AbsolutePosition > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  " + rdcValidationErrors.Resultset.rdoColumns["submitvalid"].Value;
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  -1";
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //LDW modGlobal.gv_rs.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalRec = modGlobal.gv_rs.RowCount;
            }
            modGlobal.gv_rs.Dispose();

            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dbgValidationErrorCriteria.CtlRefresh();
            rdcValidationErrorCriteria.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcValidationErrorCriteria.CtlRefresh();

            //when there is only one criteria the next choice should be
            //defined by selecting AND or OR buttons
            //otherwise the join operator has already been defined from the previous selection
            //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (TotalRec == 1)
            {
                cmdValidErrorAddCritAnd.Enabled = true;
                cmdValidErrorAddCritOr.Enabled = true;
                cmdValidErrorAddCrit.Enabled = false;
            }
            else
            {
                cmdValidErrorAddCritAnd.Enabled = false;
                cmdValidErrorAddCritOr.Enabled = false;
                cmdValidErrorAddCrit.Enabled = true;
            }



        }

        public void RefreshWarningCriteria()
        {
            int TotalRec;

            //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TotalRec = 0;

            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitValSet ";
            if (rdcValidationWarnings.Resultset.AbsolutePosition > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  " + rdcValidationWarnings.Resultset.rdoColumns["submitvalid"].Value;
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID =  -1";
            }

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //LDW modGlobal.gv_rs.MoveLast();
                //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                TotalRec = modGlobal.gv_rs.RowCount;
            }
            modGlobal.gv_rs.Dispose();

            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dbgValidationWarningCriteria.CtlRefresh();
            rdcValidationWarningCriteria.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcValidationWarningCriteria.CtlRefresh();

            //when there is only one criteria the next choice should be
            //defined by selecting AND or OR buttons
            //otherwise the join operator has already been defined from the previous selection
            //UPGRADE_WARNING: Couldn't resolve default property of object TotalRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (TotalRec == 1)
            {
                cmdValidWarningAddCritAnd.Enabled = true;
                cmdValidWarningAddCritOr.Enabled = true;
                cmdValidWarningAddCrit.Enabled = false;
            }
            else
            {
                cmdValidWarningAddCritAnd.Enabled = false;
                cmdValidWarningAddCritOr.Enabled = false;
                cmdValidWarningAddCrit.Enabled = true;
            }




        }
        readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();

        int static_ssTabSubmission_SelectedIndexChanged_PreviousTab;
        private void ssTabSubmission_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            lock (static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init)
            {
                try
                {
                    if (InitStaticVariableHelper(static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init))
                    {
                        static_ssTabSubmission_SelectedIndexChanged_PreviousTab = ssTabSubmission.SelectedIndex();
                    }
                }
                finally
                {
                    static_ssTabSubmission_SelectedIndexChanged_PreviousTab_Init.State = 1;
                }
            }
            if (ssTabSubmission.SelectedIndex == 3)
            {
                RefreshRecordCleanupCriteriaList();
            }
            static_ssTabSubmission_SelectedIndexChanged_PreviousTab = ssTabSubmission.SelectedIndex();
        }

        //UPGRADE_WARNING: Event txtRecordCleanupValue.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void txtRecordCleanupValue_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
        {

            chkRecordCleanupBlank.CheckState = CheckState.Unchecked;
            cboRecordCleanupLookupList.SelectedIndex = -1;

        }

        //UPGRADE_WARNING: Event txtTypeinValue.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void txtTypeinValue_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            cboCleanupValueList.SelectedIndex = -1;
            optCleanupValue.Checked = true;
            cboCleanupLookupTables.SelectedIndex = -1;

        }


        public void RefreshColSummaryDef()
        {
            string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec;
            string MainJOp = null;
            DataSet rs_critSet = null;

            lstSummaryDef.Items.Clear();

            
            modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
            }
            else
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"]))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                }
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

            rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (rs_critSet.RowCount == 0)
            {
                return;
            }

            //find the main join Operator
            //UPGRADE_WARNING: Couldn't resolve default property of object MainJOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MainJOp = "And";
            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitSubGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object MainJOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MainJOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //LDW rs_critSet.MoveLast();
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TotalSetRec = rs_critSet.RowCount;
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //LDW rs_critSet.MoveFirst();

            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!rs_critSet.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex - 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetCount = SetCount + 1;

                modGlobal.gv_sql = "Select * from tbl_setup_SubmitCriteria ";
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"]))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                    }
                }
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
                        lstSummaryDef.Items.Add(CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSummaryDef.Items.Add("          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    //UPGRADE_ISSUE: ListBox property lstSummaryDef.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    Support.SetItemData(lstSummaryDef, lstSummaryDef.Items.Count-1, modGlobal.gv_rs.rdoColumns["SubmitCriteriaID"].Value);


                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (SetCount == TotalSetRec)
                {
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object MainJOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSummaryDef.Items.Add(new ListBoxItem(MainJOp, SetIndex));
                }


                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveNext();

            }


        }
        public void RefreshColSummaryDefWithVerif()
        {
             string CPref = null;
            string CSuff = null;
            int Cindex;
            int TotalRec;
            int SetCount = 0;
            int SetIndex = 0;
            int TotalSetRec;
            string MainJOp = null;
            RadListControl lstSummaryDefWithVerif = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object lstSummaryDefWithVerif.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lstSummaryDefWithVerif.Items.Clear();

            DataSet rs_critSet = null;
            modGlobal.gv_sql = "Select CriteriaSet from tbl_Setup_SubmitCriteriaWithVerif ";
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
            }
            else
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"]))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                }
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

            rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (rs_critSet.RowCount == 0)
            {
                return;
            }

            //find the main join Operator
            //UPGRADE_WARNING: Couldn't resolve default property of object MainJOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MainJOp = "And";
            modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitSubGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object MainJOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MainJOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
            }


            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //LDW rs_critSet.MoveLast();
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.RowCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            TotalSetRec = rs_critSet.RowCount;
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //LDW rs_critSet.MoveFirst();

            //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            while (!rs_critSet.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetIndex = SetIndex - 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                SetCount = SetCount + 1;

                modGlobal.gv_sql = "Select * from tbl_Setup_SubmitCriteriaWithVerif ";
                if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Rows.Count == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
                }
                else
                {
                    //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (Information.IsDBNull(rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"]))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1 ";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
                    }
                }
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
                        //UPGRADE_WARNING: Couldn't resolve default property of object lstSummaryDefWithVerif.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSummaryDefWithVerif.AddItem(CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object CSuff. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object lstSummaryDefWithVerif.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lstSummaryDefWithVerif.AddItem("          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object lstSummaryDefWithVerif.Items.Count-1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object lstSummaryDefWithVerif.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSummaryDefWithVerif.ItemData(lstSummaryDefWithVerif.Items.Count-1) = modGlobal.gv_rs.rdoColumns["SubmitCriteriaID"].Value;


                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //UPGRADE_WARNING: Couldn't resolve default property of object TotalSetRec. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (SetCount == TotalSetRec)
                {
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object lstSummaryDefWithVerif.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSummaryDefWithVerif.AddItem(MainJOp);
                    //UPGRADE_ISSUE: ListBox property lstSummaryDef.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object lstSummaryDefWithVerif.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    lstSummaryDefWithVerif.ItemData(lstSummaryDef.Items.Count-1) = SetIndex;
                }


                //UPGRADE_WARNING: Couldn't resolve default property of object rs_critSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //LDW rs_critSet.MoveNext();

            }


        }
        public void RefreshVerificationCategories()
        {
            int li_SELcatID = -1;

            //On Error GoTo ErrHandler
            modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT ";
            modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'CI'";
            modGlobal.gv_sql = modGlobal.gv_sql + " and Measure_CatID not in ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (select Measure_CatID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_submitsubgroupcategory ";
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where subgroupid  = -1 ";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " )";
            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY CAT";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            lstCategoryLookupList.Items.Clear();

            while (!modGlobal.gv_rs.EOF)
            {
                lstCategoryLookupList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["CAT"].Value, modGlobal.gv_rs.rdoColumns["measure_catid"].Value));
                //If CatID <> "" Then If gv_rs!Measure_CATID = CInt(CatID) Then li_SELcatID = cboCat.Items.Count-1
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

            //cboCat.ListIndex = li_SELcatID

        }

        public void RefreshVerificationCategoriesSelected()
        {
            var LIndex = 0;

            modGlobal.gv_sql = "SELECT sgcat.submitsubgroupcategoryid, mcat.cat ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_MEASURE_CAT mcat inner join tbl_setup_submitSubGroupCategory sgcat";
            modGlobal.gv_sql = modGlobal.gv_sql + " on mcat.measure_catid = sgcat.measure_catid ";
            if (rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"] > 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE sgcat.subgroupid = " + rdcSubmissionFieldList.Tables[rdcSubmissionFieldListTable].Columns["SubGroupID"];
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where sgcat.subgroupid  = -1 ";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY CAT";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstCategorySelectedList.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                lstCategorySelectedList.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["CAT"].Value, modGlobal.gv_rs.rdoColumns["submitSubgroupCategoryID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }
        static bool InitStaticVariableHelper(Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag flag)
        {
            if (flag.State == 0)
            {
                flag.State = 2;
                return true;
            }
            else if (flag.State == 2)
            {
                throw new Microsoft.VisualBasic.CompilerServices.IncompleteInitialization();
            }
            else
            {
                return false;
            }
        }
    }
}
