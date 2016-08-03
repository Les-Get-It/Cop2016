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
    internal partial class OldfrmSubmissionValidCritWizard : System.Windows.Forms.Form
    {


        private void cboGroup1SumTable_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            RefreshGroup1Fields(Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex));
        }


        private void cboGroup2Opt1SumTable_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {

            RefreshGroup2FieldsOpt1(Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex));

        }


        private void cboGroup2Opt2SumTable_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {

            RefreshGroup2FieldsOpt2(Support.GetItemString(cboGroup2Opt2SumTable, cboGroup2Opt2SumTable.SelectedIndex));


        }

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            modGlobal.gv_Action = "Cancel";
            this.Close();
        }

        private void cmdDeleteFromGroup1_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            if (lstGroup1SelectedFields.SelectedIndex < 0)
            {
                return;
            }

            i = lstGroup1SelectedFields.SelectedIndex;
            lstGroup1SelectedFields.Items.RemoveAt((i));
            lstGroup1SelectedFieldsTable.Items.RemoveAt((i));

            if (lstGroup1SelectedFields.Items.Count <= 1)
            {
                cboGroup1SumOp.Enabled = true;
            }


        }

        private void cmdDeleteFromGroup2Opt1_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;

            if (lstGroup2Opt1SelectedFields.SelectedIndex < 0)
            {
                return;
            }

            i = lstGroup2Opt1SelectedFields.SelectedIndex;
            lstGroup2Opt1SelectedFields.Items.RemoveAt((i));
            lstGroup2Opt1SelectedFieldsTable.Items.RemoveAt((i));

            if (lstGroup2Opt1SelectedFields.Items.Count <= 1)
            {
                cboGroup2Opt1SumOp.Enabled = true;
            }

        }

        private void cmdDeleteFromGroup2Opt2_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            if (lstGroup2Opt2SelectedFields.SelectedIndex < 0)
            {
                return;
            }

            i = lstGroup2Opt2SelectedFields.SelectedIndex;
            lstGroup2Opt2SelectedFields.Items.RemoveAt((i));
            lstGroup2Opt2SelectedFieldsTable.Items.RemoveAt((i));

            if (lstGroup2Opt2SelectedFields.Items.Count <= 1)
            {
                cboGroup2Opt2SumOp.Enabled = true;
            }
        }

        private void cmdGroup1AddField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (cboGroup1SumTable.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a summary table.");
                return;
            }
            if (cboGroup1Fields.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a field.");
                return;
            }
            if (lstGroup1SelectedFields.Items.Count > 0)
            {
                if (cboGroup1SumOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field summary operation (+ or -)");
                    return;
                }

                cboGroup1SumOp.Enabled = false;

                lstGroup1SelectedFields.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) + " (" + Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex) + " / " + Support.GetItemString(cboGroup1Fields, cboGroup1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup1Fields, cboGroup1Fields.SelectedIndex)));
            }
            else
            {
                lstGroup1SelectedFields.Items.Add(new ListBoxItem("(" + Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex) + " / " + Support.GetItemString(cboGroup1Fields, cboGroup1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup1Fields, cboGroup1Fields.SelectedIndex)));
            }

            lstGroup1SelectedFieldsTable.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup1SumTable, cboGroup1SumTable.SelectedIndex), Support.GetItemData(cboGroup1Fields, cboGroup1Fields.SelectedIndex)));



        }

        private void cmdGroup2Opt1AddField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (cboGroup2Opt1SumTable.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a summary table.");
                return;
            }
            if (cboGroup2Opt1Fields.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a field.");
                return;
            }
            if (lstGroup2Opt1SelectedFields.Items.Count > 0)
            {
                if (cboGroup2Opt1SumOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field summary operation (+ or -)");
                    return;
                }

                cboGroup2Opt1SumOp.Enabled = false;

                lstGroup2Opt1SelectedFields.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt1SumOp, cboGroup2Opt1SumOp.SelectedIndex) + " (" + Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex) + "/" + Support.GetItemString(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex)));
            }
            else
            {
                lstGroup2Opt1SelectedFields.Items.Add(new ListBoxItem("(" + Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex) + "/" + Support.GetItemString(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex)));
            }

            lstGroup2Opt1SelectedFieldsTable.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt1SumTable.SelectedIndex), Support.GetItemData(cboGroup2Opt1Fields, cboGroup2Opt1Fields.SelectedIndex)));

        }

        private void cmdGroup2Opt2AddField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (cboGroup2Opt2SumTable.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a summary table.");
                return;
            }
            if (cboGroup2Opt2Fields.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select a field.");
                return;
            }
            if (lstGroup2Opt2SelectedFields.Items.Count > 0)
            {
                if (cboGroup2Opt2SumOp.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select the field summary operation (+ or -)");
                    return;
                }

                cboGroup2Opt2SumOp.Enabled = false;

                lstGroup2Opt2SelectedFields.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt2SumOp, cboGroup2Opt2SumOp.SelectedIndex) + " (" + Support.GetItemString(cboGroup2Opt1SumTable, cboGroup2Opt2SumTable.SelectedIndex) + "/" + Support.GetItemString(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex)));
            }
            else
            {
                lstGroup2Opt2SelectedFields.Items.Add(new ListBoxItem("(" + Support.GetItemString(cboGroup2Opt2SumTable, cboGroup2Opt2SumTable.SelectedIndex) + "/" + Support.GetItemString(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex) + ")", Support.GetItemData(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex)));
            }

            lstGroup2Opt2SelectedFieldsTable.Items.Add(new ListBoxItem(Support.GetItemString(cboGroup2Opt2SumTable, cboGroup2Opt2SumTable.SelectedIndex), Support.GetItemData(cboGroup2Opt2Fields, cboGroup2Opt2Fields.SelectedIndex)));

        }

        private void cmdOpt1AddCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (sstabOptions1.Enabled == true)
            {
                AddCriteriaWithMethod1();
            }
            else if (sstabOptions2.Enabled == true)
            {
                AddCriteriaWithMethod2();
            }
            else if (sstabOptions3.Enabled == true)
            {
                AddCriteriaWithMethod3();
            }



        }

        private void cmdOpt2AddCriteria_Click()
        {



        }

        private void cmdOpt3AddCriteria_Click()
        {

        }

        private void Command1_Click()
        {

        }

        private void frmSubmissionValidCritWizard_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

            sstabOptions.SelectedIndex = 0;
            sstabOptions1.Enabled = false;
            sstabOptions2.Enabled = false;
            sstabOptions3.Enabled = false;
            Opt1Method.Checked = false;
            Opt2Method.Checked = false;
            Opt3Method.Checked = false;
            RefreshGroup1Fields("NotDefined");

        }

        //UPGRADE_WARNING: Event Opt1Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt1Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                if (Opt1Method.Checked == true)
                {
                    sstabOptions1.Enabled = true;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = false;
                    sstabOptions.SelectedIndex = 0;
                    fraSetup.Enabled = true;
                }
            }
        }

        //UPGRADE_WARNING: Event Opt2Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt2Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                if (Opt2Method.Checked == true)
                {
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = true;
                    sstabOptions3.Enabled = false;
                    sstabOptions.SelectedIndex = 1;
                    fraSetup.Enabled = true;
                }
            }
        }

        //UPGRADE_WARNING: Event Opt3Method.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void Opt3Method_CheckedChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (eventSender.Checked)
            {
                if (Opt3Method.Checked == true)
                {
                    sstabOptions1.Enabled = false;
                    sstabOptions2.Enabled = false;
                    sstabOptions3.Enabled = true;
                    sstabOptions.SelectedIndex = 2;
                    fraSetup.Enabled = true;
                }
            }
        }

        public void RefreshGroup1Fields(string SummaryTable)
        {
            switch (SummaryTable)
            {
                case "PATIENT SUMMARY":
                    //gv_sql = "Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, "
                    //gv_sql = gv_sql & " tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname "
                    //gv_sql = gv_sql & " from tbl_Setup_SubmitSubGroup, tbl_Setup_SubmitGroupRow "
                    //gv_sql = gv_sql & " where tbl_Setup_SubmitSubGroup.GroupRowID =  tbl_Setup_SubmitGroupRow.GroupRowID "
                    //gv_sql = gv_sql & " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title "
                    modGlobal.gv_sql = " Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " dbo.tbl_Setup_SubmitGroup.GroupName + '/' + tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_SubmitSubGroup, tbl_setup_submitGroupRow, dbo.tbl_Setup_SubmitGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  Where tbl_Setup_SubmitSubGroup.GroupRowID = tbl_setup_submitGroupRow.GroupRowID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and dbo.tbl_Setup_SubmitGroup.GroupID = tbl_Setup_SubmitGroupRow.GroupID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title ";
                    break;

                case "HOSPITAL STATISTICS":
                    modGlobal.gv_sql = "Select tbl_Setup_DataDef.DDID as FieldID, tbl_Setup_DataDef.FieldName ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_Setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_TableDef.BaseTable = 'HOSPITAL STATISTICS' ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
                    break;

                default:
                    modGlobal.gv_sql = "Select DDID as FieldID, FieldName ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef where BaseTableID = -1";
                    break;
            }

            //g = InputBox("", "", gv_sql)
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboGroup1Fields.Items.Clear();
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //Display the list of fields to cleanup
                while (!modGlobal.gv_rs.EOF)
                {
                    cboGroup1Fields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["fieldid"].Value));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW modGlobal.gv_rs.Close();
            }


        }

        public void RefreshGroup2FieldsOpt1(string SummaryTable)
        {

            switch (SummaryTable)
            {
                case "PATIENT SUMMARY":
                    //gv_sql = "Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, "
                    //gv_sql = gv_sql & " tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname "
                    //gv_sql = gv_sql & " from tbl_Setup_SubmitSubGroup, tbl_Setup_SubmitGroupRow "
                    //gv_sql = gv_sql & " where tbl_Setup_SubmitSubGroup.GroupRowID =  tbl_Setup_SubmitGroupRow.GroupRowID "
                    //gv_sql = gv_sql & " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title "
                    modGlobal.gv_sql = " Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " dbo.tbl_Setup_SubmitGroup.GroupName + '/' + tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_SubmitSubGroup, tbl_setup_submitGroupRow, dbo.tbl_Setup_SubmitGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  Where tbl_Setup_SubmitSubGroup.GroupRowID = tbl_setup_submitGroupRow.GroupRowID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and dbo.tbl_Setup_SubmitGroup.GroupID = tbl_Setup_SubmitGroupRow.GroupID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title ";
                    break;


                case "HOSPITAL STATISTICS":
                    modGlobal.gv_sql = "Select tbl_Setup_DataDef.DDID as FieldID, tbl_Setup_DataDef.FieldName ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_Setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_TableDef.BaseTable = 'HOSPITAL STATISTICS' ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
                    break;

                default:
                    modGlobal.gv_sql = "Select DDID as FieldID, FieldName ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef where BaseTableID = -1";
                    break;
            }

            //g = InputBox("", "", gv_sql)
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboGroup2Opt1Fields.Items.Clear();
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //Display the list of fields to cleanup
                while (!modGlobal.gv_rs.EOF)
                {
                    cboGroup2Opt1Fields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["fieldid"].Value));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW modGlobal.gv_rs.Close();
            }

        }

        public void RefreshGroup2FieldsOpt2(string SummaryTable)
        {

            switch (SummaryTable)
            {
                case "PATIENT SUMMARY":
                    //gv_sql = "Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, "
                    //gv_sql = gv_sql & " tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname "
                    //gv_sql = gv_sql & " from tbl_Setup_SubmitSubGroup, tbl_Setup_SubmitGroupRow "
                    //gv_sql = gv_sql & " where tbl_Setup_SubmitSubGroup.GroupRowID =  tbl_Setup_SubmitGroupRow.GroupRowID "
                    //gv_sql = gv_sql & " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title "
                    modGlobal.gv_sql = " Select tbl_Setup_SubmitSubGroup.SubGroupID as FieldID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " dbo.tbl_Setup_SubmitGroup.GroupName + '/' + tbl_Setup_SubmitGroupRow.Title + '/' + tbl_Setup_SubmitSubGroup.Title as Fieldname ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_SubmitSubGroup, tbl_setup_submitGroupRow, dbo.tbl_Setup_SubmitGroup ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "  Where tbl_Setup_SubmitSubGroup.GroupRowID = tbl_setup_submitGroupRow.GroupRowID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and dbo.tbl_Setup_SubmitGroup.GroupID = tbl_Setup_SubmitGroupRow.GroupID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_submitGroupRow.title, tbl_setup_submitSubGroup.Title ";
                    break;


                case "HOSPITAL STATISTICS":
                    modGlobal.gv_sql = "Select tbl_Setup_DataDef.DDID as FieldID, tbl_Setup_DataDef.FieldName ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef, tbl_Setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_TableDef.BaseTable = 'HOSPITAL STATISTICS' ";
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null) ";
                    }
                    else
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.state = '' or tbl_Setup_DataDef.State is null or tbl_Setup_DataDef.state = '" + modGlobal.gv_status + "')";
                    }
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";
                    break;

                default:
                    modGlobal.gv_sql = "Select DDID as FieldID, FieldName ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataDef where BaseTableID = -1";
                    break;
            }

            //g = InputBox("", "", gv_sql)
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboGroup2Opt2Fields.Items.Clear();
            if (modGlobal.gv_rs.RowCount > 0)
            {
                //Display the list of fields to cleanup
                while (!modGlobal.gv_rs.EOF)
                {
                    cboGroup2Opt2Fields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["fieldid"].Value));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW modGlobal.gv_rs.Close();
            }

        }


        public void AddCriteriaWithMethod1()
        {
            int NewValG2ID;
            int NewValG1ID;
            int NewSetID;
            int NewValSetID;
            var i = 0;
            string Desc = null;

            if (lstGroup1SelectedFields.Items.Count <= 0)
            {
                RadMessageBox.Show("You need to define at least one field in Group 1.");
                return;
            }
            if (lstGroup2Opt1SelectedFields.Items.Count <= 0)
            {
                RadMessageBox.Show("You need to define at least one field in Group 2.");
                return;
            }
            if (cboOpt1FieldOp.SelectedIndex < 0)
            {
                RadMessageBox.Show("You need to define the comparison operator between the 2 field groups.");
                return;
            }

            //build the description of the criteria

            Desc = "";
            for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
            {

                if (i == 0)
                {
        
                    Desc = Desc + "(";
                }

    
                Desc = Desc + Support.GetItemString(lstGroup1SelectedFields, i);


                if (i == lstGroup1SelectedFields.Items.Count - 1)
                {
        
                    Desc = Desc + ")";
                }
            }


            Desc = Desc + " " + Support.GetItemString(cboOpt1FieldOp, cboOpt1FieldOp.SelectedIndex);

            for (i = 0; i <= lstGroup2Opt1SelectedFields.Items.Count - 1; i++)
            {

                if (i == 0)
                {
        
                    Desc = Desc + "(";
                }

    
                Desc = Desc + Support.GetItemString(lstGroup2Opt1SelectedFields, i);


                if (i == lstGroup2Opt1SelectedFields.Items.Count - 1)
                {
        
                    Desc = Desc + ")";
                }
            }

            //add the set

            NewValSetID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSet", "SubmitValSetID");
            modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetID, SubmitValID, Description, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Group1Op, Group2Op, GroupsOp, Value, ValueOperator) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " values (";

            modGlobal.gv_sql = modGlobal.gv_sql + NewValSetID + ", ";

            if (modGlobal.gv_Action == "ERROR")
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value + ", ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value + ", ";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Desc + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup2Opt1SumOp, cboGroup2Opt1SumOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt1FieldOp, cboOpt1FieldOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null, Null) ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "Select max(SubmitValSetID) as newSetID from tbl_Setup_SubmitValSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

            if (modGlobal.gv_Action == "ERROR")
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value;
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value;
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewSetID = modGlobal.gv_rs.rdoColumns["NewSetID"].Value;

            //add fields of group 1
            for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewValG1ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup1", "SubmitValSetG1ID");

                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG1ID, SubmitValSetID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewValG1ID + ", ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup1SelectedFields, i) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup1SelectedFieldsTable, i) + "') ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }

            //add fields of group 2
            for (i = 0; i <= lstGroup2Opt1SelectedFields.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG2ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewValG2ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup2", "SubmitValSetG2ID");

                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG2ID, SubmitValSetID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG2ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewValG2ID + ", ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup2Opt1SelectedFields, i) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup2Opt1SelectedFieldsTable, i) + "') ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }

            //update join operator if any
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
            {
                modGlobal.gv_sql = "Update tbl_Setup_SubmitValidation ";
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + modGlobal.gv_ANDOR + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";
    
                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value;
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value;
                }
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }



            modGlobal.gv_Action = "Add";
            this.Close();

        }

        public void AddCriteriaWithMethod2()
        {
            int NewValG2ID;
            int NewValG1ID;
            int NewSetID;
            int NewValSetID;
            var i = 0;
            string Desc = null;
            if (lstGroup1SelectedFields.Items.Count <= 0)
            {
                RadMessageBox.Show("You need to define at least one field in Group 1.");
                return;
            }
            if (lstGroup2Opt2SelectedFields.Items.Count <= 0)
            {
                RadMessageBox.Show("You need to define at least one field in Group 2.");
                return;
            }
            if (cboOpt2FieldOp.SelectedIndex < 0)
            {
                RadMessageBox.Show("You need to define the comparison operator between the 2 field groups.");
                return;
            }
            if (cboOpt2ValueOp.SelectedIndex < 0)
            {
                RadMessageBox.Show("You need to define the Result operator. ");
                return;
            }

            if (string.IsNullOrEmpty(txtOpt2Value.Text))
            {
                RadMessageBox.Show("You need to define Result value.");
                return;
            }

            //build the description of the criteria

            Desc = "";
            for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
            {

                if (i == 0)
                {
        
                    Desc = Desc + "(";
                }

    
                Desc = Desc + Support.GetItemString(lstGroup1SelectedFields, i);


                if (i == lstGroup1SelectedFields.Items.Count - 1)
                {
        
                    Desc = Desc + ")";
                }
            }


            Desc = Desc + " " + Support.GetItemString(cboOpt2FieldOp, cboOpt2FieldOp.SelectedIndex);

            for (i = 0; i <= lstGroup2Opt2SelectedFields.Items.Count - 1; i++)
            {

                if (i == 0)
                {
        
                    Desc = Desc + "(";
                }

    
                Desc = Desc + Support.GetItemString(lstGroup2Opt2SelectedFields, i);


                if (i == lstGroup2Opt2SelectedFields.Items.Count - 1)
                {
        
                    Desc = Desc + ")";
                }
            }


            Desc = Desc + " " + Support.GetItemString(cboOpt2ValueOp, cboOpt2ValueOp.SelectedIndex) + " " + txtOpt2Value.Text;


            //add the set

            NewValSetID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSet", "SubmitValSetID");
            modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetID, SubmitValID, Description, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Group1Op, Group2Op, GroupsOp, ValueOperator, Value) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " values (";

            modGlobal.gv_sql = modGlobal.gv_sql + NewValSetID + ", ";

            if (modGlobal.gv_Action == "ERROR")
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value + ", ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value + ", ";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Desc + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup2Opt1SumOp, cboGroup2Opt2SumOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt2FieldOp, cboOpt2FieldOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt2ValueOp, cboOpt2ValueOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt2Value.Text + "')";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "Select max(SubmitValSetID) as newSetID from tbl_Setup_SubmitValSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

            if (modGlobal.gv_Action == "ERROR")
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value;
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value;
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewSetID = modGlobal.gv_rs.rdoColumns["NewSetID"].Value;

            //add fields of group 1
            for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewValG1ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup1", "SubmitValSetG1ID");

                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG1ID, SubmitValSetID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewValG1ID + ", ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup1SelectedFields, i) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup1SelectedFieldsTable, i) + "') ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }

            //add fields of group 2
            for (i = 0; i <= lstGroup2Opt2SelectedFields.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG2ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewValG2ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup2", "SubmitValSetG2ID");

                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG2ID, SubmitValSetID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG2ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewValG2ID + ", ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup2Opt2SelectedFields, i) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup2Opt2SelectedFieldsTable, i) + "') ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }

            //update join operator if any
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
            {
                modGlobal.gv_sql = "Update tbl_Setup_SubmitValidation ";
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + modGlobal.gv_ANDOR + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";
    
                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value;
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value;
                }
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }


            modGlobal.gv_Action = "Add";
            this.Close();
        }

        public void AddCriteriaWithMethod3()
        {
            int NewValG1ID;
            int NewSetID;
            int NewValSetID;
            var i = 0;
            string Desc = null;

            if (cboOpt3ValueOp.SelectedIndex < 0)
            {
                RadMessageBox.Show("You need to define the Result operator. ");
                return;
            }

            if (string.IsNullOrEmpty(txtOpt3Value.Text))
            {
                RadMessageBox.Show("You need to define Result value.");
                return;
            }

            //build the description of the criteria

            Desc = "";
            for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
            {

                if (i == 0)
                {
        
                    Desc = Desc + "(";
                }

    
                Desc = Desc + Support.GetItemString(lstGroup1SelectedFields, i);


                if (i == lstGroup1SelectedFields.Items.Count - 1)
                {
        
                    Desc = Desc + ")";
                }
            }


            Desc = Desc + " " + Support.GetItemString(cboOpt3ValueOp, cboOpt3ValueOp.SelectedIndex) + " " + txtOpt3Value.Text;

            //add the set

            NewValSetID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSet", "SubmitValSetID");
            modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetID, SubmitValID, Description, ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Group1Op, Group2Op, GroupsOp,  ValueOperator, Value) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " values (";

            modGlobal.gv_sql = modGlobal.gv_sql + NewValSetID + ", ";

            if (modGlobal.gv_Action == "ERROR")
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value + ", ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value + ", ";
            }

            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Desc + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboGroup1SumOp, cboGroup1SumOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + Support.GetItemString(cboOpt3ValueOp, cboOpt3ValueOp.SelectedIndex) + "',";
            modGlobal.gv_sql = modGlobal.gv_sql + " '" + txtOpt3Value.Text + "')";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = "Select max(SubmitValSetID) as newSetID from tbl_Setup_SubmitValSet ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";

            if (modGlobal.gv_Action == "ERROR")
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value;
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value;
            }
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            NewSetID = modGlobal.gv_rs.rdoColumns["NewSetID"].Value;

            //add fields of group 1
            for (i = 0; i <= lstGroup1SelectedFields.Items.Count - 1; i++)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                NewValG1ID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitValSetGroup1", "SubmitValSetG1ID");

                modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (SubmitValSetG1ID, SubmitValSetID, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable )";
                modGlobal.gv_sql = modGlobal.gv_sql + " values( ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewValG1ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewValG1ID + ", ";
                //UPGRADE_WARNING: Couldn't resolve default property of object NewSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + NewSetID + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstGroup1SelectedFields, i) + ", ";
                modGlobal.gv_sql = modGlobal.gv_sql + "'" + Support.GetItemString(lstGroup1SelectedFieldsTable, i) + "') ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }

            //update join operator if any
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_ANDOR == "AND" | modGlobal.gv_ANDOR == "OR")
            {
                modGlobal.gv_sql = "Update tbl_Setup_SubmitValidation ";
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_ANDOR. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set JoinOperator = '" + modGlobal.gv_ANDOR + "'";
                modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = ";
    
                if (modGlobal.gv_Action == "ERROR")
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationErrors.Tables[rdcValidationErrorsTable].Columns["submitvalid"].Value;
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + frmSubmissionSetupCopy.rdcValidationWarnings.Tables[rdcValidationWarningsTable].Columns["submitvalid"].Value;
                }
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            }


            modGlobal.gv_Action = "Add";
            this.Close();
        }
    }
}
