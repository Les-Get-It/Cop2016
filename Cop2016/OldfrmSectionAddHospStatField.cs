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
	internal partial class OldfrmSectionAddHospStatField : System.Windows.Forms.Form
	{

		private void cboPatientFields_Click()
		{
			RefreshIndicators();
		}

//UPGRADE_WARNING: Event cboTableFields.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboTableFields_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshIndicators();
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdSelect_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newid = null;
			var i = 0;
			object MaxOrder = null;
			if (string.IsNullOrEmpty(cboTableFields.Text)) {
				Interaction.MsgBox("Please select a field from the list.");
				return;
			}

			modGlobal.gv_sql = "Select max(tbl_setup_DataDef.FieldOrder) as MaxOrder ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef inner join tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where upper(substring(tbl_Setup_TableDef.BaseTable,1,13)) = 'HOSPITAL STAT' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_DataDef.FieldCategory <> 'Fix' ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object MaxOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MaxOrder = modGlobal.gv_rs.rdoColumns["MaxOrder"].Value + 1;

			modGlobal.gv_sql = "update tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set IndicatorGroupID = " + Support.GetItemData(My.MyProject.Forms.frmHospStatSetup.cboIndicatorGroup, My.MyProject.Forms.frmHospStatSetup.cboIndicatorGroup.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object MaxOrder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + ", FieldOrder = " + MaxOrder;
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(cboTableFields, cboTableFields.SelectedIndex);

			 DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
           

            for (i = 0; i <= lstIndicators.Items.Count - 1; i++) {
				if (lstIndicators.GetSelected(i)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					newid = modDBSetup.FindMaxRecID("tbl_Setup_DataReq", "IndicatorDDID");

					modGlobal.gv_sql = "Insert into tbl_setup_DataReq (IndicatorDDID, IndicatorID, DDID)";
					//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + newid;
					modGlobal.gv_sql = modGlobal.gv_sql + "," + Support.GetItemData(lstIndicators, i);
					modGlobal.gv_sql = modGlobal.gv_sql + "," + Support.GetItemData(cboTableFields, cboTableFields.SelectedIndex) + ")";

					 DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				}
			}

			this.Close();

		}

		private void frmSectionAddHospStatField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));

			RefreshTableField();

		}

		public void RefreshTableField()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;

			//retrieve the list of Patient Fields
			modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef inner join tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_setup_DataDef.BaseTableID = tbl_Setup_TableDef.BaseTableID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where upper(substring(tbl_Setup_TableDef.BaseTable,1,13)) = 'HOSPITAL STAT' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_DataDef.FieldCategory <> 'Fix' ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_Setup_DataDef.IndicatorGroupID is null ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_DataDef.State = '' or tbl_setup_DataDef.State is null or tbl_setup_DataDef.State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_Setup_DataDef.FieldName ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboTableFields.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LIndex = LIndex + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Table_ListIndex = LIndex;

				cboTableFields.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}

		}

		public void RefreshIndicators()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			//retrieve the list of indicators
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where IndicatorID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select IndicatorID from tbl_setup_DataReq ";
			if (cboTableFields.SelectedIndex > -1) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + Support.GetItemData(cboTableFields, cboTableFields.SelectedIndex) + ")";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = 0 ) ";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstIndicators.Items.Clear();
			//UPGRADE_WARNING: Couldn't resolve default property of object Table_ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Table_ListIndex = -1;
			//UPGRADE_WARNING: Couldn't resolve default property of object LIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LIndex = -1;
			while (!modGlobal.gv_rs.EOF) {
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
