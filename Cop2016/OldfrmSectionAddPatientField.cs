using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Compatibility.VB6;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmSectionAddPatientField : System.Windows.Forms.Form
    {

        //UPGRADE_WARNING: Event cboPatientFields.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void cboPatientFields_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            refreshIndicators();
        }

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdSelect_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            var i = 0;
            int newid;
            int maxorder;
            if (string.IsNullOrEmpty(cboPatientFields.Text))
            {
                RadMessageBox.Show("Please select a field from the list.");
                return;
            }

            modGlobal.gv_sql = "Select max(tbl_setup_indicatorgroupset.FieldOrder) as MaxOrder ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_indicatorgroupset ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_indicatorgroupset.ddid = tbl_setup_DataDef.ddid) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " WHERE tbl_Setup_TableDef.BaseTable = 'PATIENT' ";
            modGlobal.gv_sql = modGlobal.gv_sql + " AND IndicatorGroupID = " + Support.GetItemData(frmPatientSetup.cboIndicatorGroup, frmPatientSetup.cboIndicatorGroup.SelectedIndex);
            //gv_sql = gv_sql & " and tbl_Setup_DataDef.FieldCategory <> 'Fix' "

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            //UPGRADE_WARNING: Couldn't resolve default property of object maxorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            maxorder = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["maxorder"].Value) ? 0 : modGlobal.gv_rs.rdoColumns["maxorder"].Value) + 1;

            //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            newid = modDBSetup.FindMaxRecID("tbl_Setup_Indicatorgroupset", "Indicatorgroupsetid");

            modGlobal.gv_sql = "insert into tbl_setup_indicatorgroupset ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (indicatorgroupsetid, IndicatorGroupID, ddid, fieldorder) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " values ( ";
            //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + newid + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(frmPatientSetup.cboIndicatorGroup, frmPatientSetup.cboIndicatorGroup.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex) + ", ";
            //UPGRADE_WARNING: Couldn't resolve default property of object maxorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + maxorder + ") ";
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            

            for (i = 0; i <= lstIndicators.Items.Count - 1; i++)
            {
                if (lstIndicators.GetSelected(i))
                {

                    //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    newid = modDBSetup.FindMaxRecID("tbl_setup_DataReq", "Indicatorddid");

                    modGlobal.gv_sql = "Insert into tbl_setup_DataReq ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (IndicatorDDID, IndicatorID, DDID)";
                    //UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + newid;
                    modGlobal.gv_sql = modGlobal.gv_sql + "," + Support.GetItemData(lstIndicators, i);
                    modGlobal.gv_sql = modGlobal.gv_sql + "," + Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex) + ")";

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
            }

            this.Close();
        }

        private void frmSectionAddPatientField_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

            RefreshPatientField();

        }

        public void RefreshPatientField()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;

            //retrieve the list of Patient Fields
            modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef inner join tbl_Setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_Setup_TableDef.BaseTable = 'PATIENT' ";
            //gv_sql = gv_sql & " and tbl_Setup_DataDef.FieldCategory <> 'Fix' "
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
            modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid not in ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (Select ddid from tbl_setup_indicatorgroupset where indicatorgroupid = " + Support.GetItemData(frmPatientSetup.cboIndicatorGroup, frmPatientSetup.cboIndicatorGroup.SelectedIndex) + ")";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_Setup_DataDef.FieldName ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboPatientFields.Items.Clear();
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

                cboPatientFields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

        }

        public void refreshIndicators()
        {
            var LIndex = 0;
            var Table_ListIndex = 0;
            //retrieve the list of indicators
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where IndicatorID not in ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (select IndicatorID from tbl_setup_DataReq ";
            if (cboPatientFields.SelectedIndex > -1)
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex) + " )";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = 0 ) ";
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " and 1 = (SELECT CASE WHEN FieldCategory = 'Dynamic' THEN 1 ELSE 0 END FROM tbl_Setup_DataDef WHERE DDID = " + Support.GetItemData(cboPatientFields, cboPatientFields.SelectedIndex) + " )";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstIndicators.Items.Clear();
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

                lstIndicators.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

        }
    }
}
