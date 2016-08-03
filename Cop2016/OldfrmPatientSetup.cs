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
    internal partial class OldfrmPatientSetup : System.Windows.Forms.Form
    {
        object basetableid;

        public void RefreshIndicatorDep()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            object lstRequiredIndicator = null;
            object lstIndicators = null;

            modGlobal.gv_sql = "Select tbl_setup_Indicator.Description, tbl_setup_IndicatorDep.* ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator, tbl_setup_IndicatorDep ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_Indicator.IndicatorID = tbl_setup_IndicatorDep.IndicatorID ";
            //UPGRADE_WARNING: Couldn't resolve default property of object lstIndicators.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object lstIndicators.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_IndicatorDep.IndicatorParentID = " + lstIndicators.ItemData(lstIndicators.ListIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object lstRequiredIndicator.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lstRequiredIndicator.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Table_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Table_ListIndex = LIndex;

                lstRequiredIndicator.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorDepID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
        }
        //UPGRADE_WARNING: Event cboIndicatorGroup.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboIndicatorGroup_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshPatientFields();

        }




        private void cmdAddPatientField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (cboIndicatorGroup.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a Section.");
                return;
            }

            frmSectionAddPatientFieldCopy.ShowDialog();
            RefreshPatientFields();
        }


        private void cmdChangeStatus_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            object MoveToModule = null;
            if (cboIndicatorGroup.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MoveToModule = (modGlobal.gv_status == "TEST" ? "Active" : "Test");
            //UPGRADE_WARNING: Couldn't resolve default property of object MoveToModule. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want this section to the " + MoveToModule + " Module?", MessageBoxButtons.YesNo);
            if (resp == DialogResult.No)
            {
                return;
            }

            modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + "  Set RecordStatus =  " + (modGlobal.gv_status == "TEST" ? "Null" : "'TEST'");
            modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshBaseTableID();
            RefreshIndicatorSet();
            RefreshSectionList();
            RefreshPatientFields();

        }

        private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
           DataSet thisrs = null;
            if (cboIndicatorGroup.SelectedIndex < 0)
            {
                return;
            }

            //Delete the relationship between field and indicator,
            // only if the fields in this group have not been selected for any other group
            modGlobal.gv_sql = "Select * from tbl_Setup_IndicatorGroupSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            while (!thisrs.EOF)
            {
                modGlobal.gv_sql = "Select * from tbl_Setup_IndicatorGroupSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + thisrs.rdoColumns["DDID"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " and IndicatorGroupID <> " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                if (modGlobal.gv_rs.RowCount == 0)
                {
                    modGlobal.gv_sql = "Delete tbl_setup_DataReq ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + thisrs.rdoColumns["DDID"].Value;
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                thisrs.MoveNext();
            }

            modGlobal.gv_sql = "Delete tbl_Setup_IndicatorGroupSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + "  where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "Delete tbl_Setup_IndicatorGroup ";
            modGlobal.gv_sql = modGlobal.gv_sql + "  where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshIndicatorSet();
            cboIndicatorGroup.SelectedIndex = -1;
            RefreshPatientFields();
            RefreshFieldIndicator();

        }


        private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            object EditSection = null;
            object ThisGID = null;
            if (string.IsNullOrEmpty(cboIndicatorGroup.Text))
            {
                RadMessageBox.Show("Please select Section from the list.");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object ThisGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisGID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            //UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            EditSection = Interaction.InputBox("Edit the Section description.", "Edit Section", cboIndicatorGroup.Text);
            //UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (!string.IsNullOrEmpty(EditSection))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup set GroupDescription = '" + EditSection + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                RefreshIndicatorSet();
                //UPGRADE_WARNING: Couldn't resolve default property of object EditSection. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cboIndicatorGroup.Text = EditSection;
                //set the selected list item to the new one
                for (i = 0; i <= cboIndicatorGroup.Items.Count - 1; i++)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object ThisGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, i) == ThisGID)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        cboIndicatorGroup.SelectedIndex = i;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
        }


        private void cmdEditPatientField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (cboIndicatorGroup.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a Section.");
                return;
            }
            if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
            {
                RadMessageBox.Show("Please select a field.");
                return;
            }

            frmSectionEditPatientFieldCopy.ShowDialog();
            RefreshPatientFields();
        }


        private void cmdMoveDown_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            int ThisFieldID;
            int MaxOrderNum = 0;
            int CurrOrderNum = 0;
            int FCount = 0;
            if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
            {
                return;
            }

            //retrieve the list of patient fields for the selected Section
            modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where igs.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder, dd.FieldName ";


            //first we make sure every field in this list has a number
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            FCount = 0;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FCount = FCount + 1;
                modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder = " + FCount;
                modGlobal.gv_sql = modGlobal.gv_sql + " where indicatorgroupsetid = " + modGlobal.gv_rs.rdoColumns["IndicatorGroupsetID"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                if (rdcPatientFields.Resultset.rdoColumns["IndicatorGroupsetID"].Value == modGlobal.gv_rs.rdoColumns["IndicatorGroupsetID"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurrOrderNum = FCount;
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MaxOrderNum = FCount;
                //LDW modGlobal.gv_rs.MoveNext();
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisFieldID = rdcPatientFields.Resultset.rdoColumns["DDID"].Value;

            //UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (CurrOrderNum < MaxOrderNum)
            {
                //update order number of the field prior to this one
                modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder =  " + CurrOrderNum;
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and FieldOrder = " + CurrOrderNum + 1;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "update tbl_setup_indicatorgroupset  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder = " + CurrOrderNum + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " and indicatorgroupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                RefreshPatientFields();
                //find the right field
                for (i = 1; i <= rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count; i++)
                {
                    if (rdcPatientFields.Resultset.rdoColumns["DDID"].Value == ThisFieldID)
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    rdcPatientFields.Resultset.MoveNext();
                }
            }


        }

        private void cmdMoveSectionDown_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            int ThisFieldID;
            int MaxOrderNum = 0;
            int CurrOrderNum = 0;
            int FCount = 0;

            //'--added move to section 2/14/2010
            if (rdcSections.Resultset.RowCount < 0)
            {
                return;
            }

            //retrieve the list of patient fields for the selected Section
            modGlobal.gv_sql = "Select  * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
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
            modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

            //first we make sure every field in this list has a number
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            FCount = 0;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FCount = FCount + 1;
                modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup ";
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + FCount;
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                if (rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value == modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurrOrderNum = FCount;
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MaxOrderNum = FCount;
                //LDW modGlobal.gv_rs.MoveNext();
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisFieldID = rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value;

            //UPGRADE_WARNING: Couldn't resolve default property of object MaxOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (CurrOrderNum < MaxOrderNum)
            {
                //update order number of the field prior to this one
                modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder =  " + CurrOrderNum;
                //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and DisplayOrder = " + CurrOrderNum + 1;
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
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + CurrOrderNum + 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshSectionList();
                //find the right field
                for (i = 1; i <= rdcSections.Resultset.RowCount; i++)
                {
                    if (rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value == ThisFieldID)
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    rdcSections.Resultset.MoveNext();
                }

            }

        }

        private void cmdMoveSectionUp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            int ThisFieldID;
            int CurrOrderNum = 0;
            int FCount = 0;
            if (rdcSections.Resultset.RowCount < 0)
            {
                return;
            }

            //retrieve the list of sections
            modGlobal.gv_sql = "Select  * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorGroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + basetableid;
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
            modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

            //first we make sure every field in this list has a number
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            FCount = 0;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FCount = FCount + 1;
                modGlobal.gv_sql = "Update tbl_Setup_IndicatorGroup";
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + FCount;
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                if (rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value == modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurrOrderNum = FCount;
                }
                //LDW modGlobal.gv_rs.MoveNext();
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisFieldID = rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (CurrOrderNum - 1 > 0)
            {
                //update order number of the field prior to this one
                modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder =  " + CurrOrderNum;
                //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + basetableid;
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
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and DisplayOrder = " + CurrOrderNum - 1;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "update tbl_Setup_IndicatorGroup  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set DisplayOrder = " + CurrOrderNum - 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshSectionList();
                //find the right field
                for (i = 1; i <= rdcSections.Resultset.RowCount; i++)
                {
                    if (rdcSections.Resultset.rdoColumns["indicatorgroupid"].Value == ThisFieldID)
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    rdcSections.Resultset.MoveNext();
                }
            }
        }

        private void cmdMoveToAbsPosition_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            object abspos = null;
            var i = 0;

            short StartOrder = 0;
            short TotalFields = 0;
            short ThisFieldID = 0;
            short ThisFieldOrder = 0;
            short NewPos = 0;


            if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
            {
                return;
            }

            //first we make sure every field in this list has a number
            modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
            modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder = 1 ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where fieldorder is null and indicatorgroupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


            //retrieve the list of patient fields for the selected Section
            modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where igs.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder, dd.FieldName ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            StartOrder = modGlobal.gv_rs.rdoColumns["fieldorder"].Value;
            modGlobal.gv_rs.MoveLast();
            TotalFields = modGlobal.gv_rs.RowCount;
            modGlobal.gv_rs.MoveFirst();

            ThisFieldID = rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
            ThisFieldOrder = rdcPatientFields.Resultset.rdoColumns["fieldorder"].Value;


            NewPos = Convert.ToInt16(Interaction.InputBox("Type in the order number for this field (should be between 1 and " + TotalFields + ")", "Move Field Position", Convert.ToString(1)));
            if (!Information.IsNumeric(NewPos))
            {
                RadMessageBox.Show("Numeric values only.");
                return;
            }
            if (Convert.ToInt16(NewPos) < 1 | Convert.ToInt16(NewPos) > TotalFields)
            {
                RadMessageBox.Show("Invalid position.");
                return;
            }

            //update all the fields except the selected one
            modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where igs.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " and igs.ddid <> " + rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            i = StartOrder - 1;
            //UPGRADE_WARNING: Couldn't resolve default property of object abspos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            abspos = 0;

            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                i = i + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object abspos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                abspos = abspos + 1;

                //UPGRADE_WARNING: Couldn't resolve default property of object abspos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (abspos == Convert.ToInt16(NewPos))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    i = i + 1;
                }


                //update order number of the field prior to this one
                modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
                //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder =  " + i;
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and DDID = " + modGlobal.gv_rs.rdoColumns["DDID"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //LDW modGlobal.gv_rs.MoveNext();

            }

            //update order number of this field
            modGlobal.gv_sql = "update tbl_setup_indicatorgroupset  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder = " + Convert.ToInt16(NewPos) + StartOrder - 1;
            modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " and indicatorgroupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


            RefreshPatientFields();

        }


        private void cmdMoveUp_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            int ThisFieldID;
            int CurrOrderNum = 0;
            int FCount = 0;
            if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
            {
                return;
            }

            //retrieve the list of patient fields for the selected Section
            modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where igs.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder, dd.FieldName ";

            //first we make sure every field in this list has a number
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            FCount = 0;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FCount = FCount + 1;
                modGlobal.gv_sql = "Update tbl_setup_indicatorgroupset";
                //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder = " + FCount;
                modGlobal.gv_sql = modGlobal.gv_sql + " where indicatorgroupsetid = " + modGlobal.gv_rs.rdoColumns["IndicatorGroupsetID"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                if (rdcPatientFields.Resultset.rdoColumns["IndicatorGroupsetID"].Value == modGlobal.gv_rs.rdoColumns["IndicatorGroupsetID"].Value)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object FCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    CurrOrderNum = FCount;
                }
                //LDW modGlobal.gv_rs.MoveNext();
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object ThisFieldID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ThisFieldID = rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
            //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (CurrOrderNum - 1 > 0)
            {
                //update order number of the field prior to this one
                modGlobal.gv_sql = "update tbl_setup_indicatorgroupset  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder =  " + CurrOrderNum;
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and FieldOrder = " + CurrOrderNum - 1;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //update order number of this field
                modGlobal.gv_sql = "update tbl_setup_indicatorgroupset  ";
                //UPGRADE_WARNING: Couldn't resolve default property of object CurrOrderNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set FieldOrder = " + CurrOrderNum - 1;
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
                modGlobal.gv_sql = modGlobal.gv_sql + " and indicatorgroupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshPatientFields();
                //find the right field
                for (i = 1; i <= rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count; i++)
                {
                    if (rdcPatientFields.Resultset.rdoColumns["DDID"].Value == ThisFieldID)
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    rdcPatientFields.Resultset.MoveNext();
                }

            }




        }

        private void cmdNew_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            object NewIndGID = null;
            object NewGroup = null;
            //UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewGroup = Interaction.InputBox("Please enter the description of the new group:", "Add New Group", "");
            //UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(NewGroup))
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object NewIndGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewIndGID = modDBSetup.FindMaxRecID(ref "tbl_Setup_IndicatorGroup", ref "IndicatorGroupID");
            modGlobal.gv_sql = "Insert into  tbl_setup_IndicatorGroup (IndicatorGroupID, GroupDescription, BaseTableID, State, RecordStatus) ";
            //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object NewIndGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + NewIndGID + ",'" + NewGroup + "'," + basetableid + ",";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
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

            RefreshIndicatorSet();
            //UPGRADE_WARNING: Couldn't resolve default property of object NewGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboIndicatorGroup.Text = NewGroup;

            //set the selected list item to the new one
            for (i = 0; i <= cboIndicatorGroup.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewIndGID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, i) == NewIndGID)
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cboIndicatorGroup.SelectedIndex = i;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

        }


        private void cmdRemoveFieldIndicator_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (lstFieldIndicator.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "Delete tbl_setup_DataReq ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where IndicatorDDID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldIndicator, lstFieldIndicator.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }
            RefreshFieldIndicator();

        }


        private void cmdRemovePatientField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;

            if (string.IsNullOrEmpty(cboIndicatorGroup.Text))
            {
                return;
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("Are you sure you want to remove this field from the list?", MessageBoxButtons.YesNo, "Remove Patient Field From Section");
            if (resp == DialogResult.No)
            {
                return;
            }
            modGlobal.gv_sql = "Delete tbl_setup_IndicatorGroupset ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where IndicatorGroupsetID =  " + rdcPatientFields.Resultset.rdoColumns["IndicatorGroupsetID"].Value;
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            //remove the link between field and indicator
            //only if this field has not been selected for any other section
            modGlobal.gv_sql = "select * from tbl_setup_IndicatorGroupset ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID =  " + rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            if (modGlobal.gv_rs.RowCount == 0)
            {
                modGlobal.gv_sql = "delete tbl_setup_DataReq ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where DDID =  " + rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }

            RefreshPatientFields();

        }

        private void frmPatientSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_status == "TEST")
            {
                cmdChangeStatus.Text = "Move to Active";
            }
            else
            {
                cmdChangeStatus.Text = "Move to Test";
            }


            sstabpatientSetup.SelectedIndex = 0;
            //sstSectionIndicator.Tab = 0
            //sstabIndicatorList.Tab = 0
            //RefreshIndicatorGroup
            //RefreshIndicator
            RefreshBaseTableID();
            RefreshIndicatorSet();
            RefreshSectionList();
            RefreshPatientFields();


        }


        public void RefreshPatientFields()
        {

            //retrieve the list of patient fields for the selected Section
            modGlobal.gv_sql = "Select igs.indicatorgroupsetid, dd.DDID, dd.Fieldname, igs.FieldOrder ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef as dd ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroupset as igs ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = igs.ddid ";
            if (cboIndicatorGroup.SelectedIndex < 0)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where igs.IndicatorGroupID = 0 ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where igs.IndicatorGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicatorGroup, cboIndicatorGroup.SelectedIndex);
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by igs.FieldOrder, dd.FieldName ";

            //retrieve the list of patient fields for the selected Section
            //gv_sql = "Select  DDID, Fieldname, FieldOrder "
            //gv_sql = gv_sql & " from tbl_Setup_DataDef "
            //gv_sql = gv_sql & " order by FieldOrder, FieldName "

            //resp = InputBox("", "", gv_sql)
            rdcPatientFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcPatientFields.CtlRefresh();

            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dbgPatientFields.CtlRefresh();
            RefreshFieldIndicator();

        }


        private void rdcPatientFields_Reposition()
        {

            RefreshFieldIndicator();

        }


        public void RefreshFieldIndicator()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            if (rdcPatientFields.Tables[rdcPatientFieldsTable].Rows.Count == 0)
            {
                lstFieldIndicator.Items.Clear();
                return;
            }

            modGlobal.gv_sql = "Select tbl_Setup_DataReq.*, tbl_setup_Indicator.Description as Indicator  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataReq, tbl_setup_Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataReq.IndicatorID = tbl_setup_Indicator.IndicatorID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_DataReq.ddid = " + rdcPatientFields.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_Indicator.Description ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstFieldIndicator.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Table_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Table_ListIndex = LIndex;

                lstFieldIndicator.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Indicator"].Value, modGlobal.gv_rs.rdoColumns["IndicatorDDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

        }

        public void RefreshIndicatorSet()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            //retrieve the list of Indicator Groups
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorGroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + basetableid;
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
            modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder, GroupDescription ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboIndicatorGroup.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Table_ListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LIndex = -1;
            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LIndex = LIndex + 1;
                //UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Table_ListIndex = LIndex;

                cboIndicatorGroup.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupDescription"].Value, modGlobal.gv_rs.rdoColumns["indicatorgroupid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
        }



        public void RefreshBaseTableID()
        {
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " upper(substring(BaseTable,1,7)) = 'PATIENT' ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
        }

        public void RefreshSectionList()
        {
            //retrieve the list of sections
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorGroup ";
            //UPGRADE_WARNING: Couldn't resolve default property of object basetableid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableID = " + basetableid;
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
            modGlobal.gv_sql = modGlobal.gv_sql + " order by DisplayOrder ";

            rdcSections.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcSections.CtlRefresh();

            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dbgSections.CtlRefresh();

        }

        private void SSTab1_DblClick()
        {

        }
        readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();

        short static_sstabpatientSetup_SelectedIndexChanged_PreviousTab;
        private void sstabpatientSetup_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            lock (static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init)
            {
                try
                {
                    if (InitStaticVariableHelper(static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init))
                    {
                        static_sstabpatientSetup_SelectedIndexChanged_PreviousTab = sstabpatientSetup.SelectedIndex();
                    }
                }
                finally
                {
                    static_sstabpatientSetup_SelectedIndexChanged_PreviousTab_Init.State = 1;
                }
            }
            if (sstabpatientSetup.SelectedIndex == 1)
            {
                RefreshSectionList();
            }
            static_sstabpatientSetup_SelectedIndexChanged_PreviousTab = sstabpatientSetup.SelectedIndex();
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
