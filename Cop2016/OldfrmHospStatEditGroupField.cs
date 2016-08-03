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
	internal partial class OldfrmHospStatEditGroupField : System.Windows.Forms.Form
	{

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdSelect_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newfieldorder = null;
			var i = 0;

			for (i = 0; i <= lstHospStatFields.Items.Count - 1; i++) {
				if (lstHospStatFields.GetSelected(i)) {
					//NewID = FindMaxRecID("tbl_Setup_DataReq", "IndicatorDDID")

					modGlobal.gv_sql = "select max(fieldorder) as maxorder from tbl_setup_HospStatGroupFields ";
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object newfieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					newfieldorder = modGlobal.gv_rs.rdoColumns["maxorder"].Value + 1;

					modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroupFields (HospStatGroupID, DDID, fieldorder )";
					modGlobal.gv_sql = modGlobal.gv_sql + " Values (";
					modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmHospStatSetup.lstHospStatGroup, My.MyProject.Forms.frmHospStatSetup.lstHospStatGroup.SelectedIndex);
					//UPGRADE_WARNING: Couldn't resolve default property of object newfieldorder. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHospStatFields, i) + ", " + newfieldorder;
					modGlobal.gv_sql = modGlobal.gv_sql + ")";


					modGlobal.gv_cn.Execute(modGlobal.gv_sql);

				}
			}

			this.Close();

		}

		private void frmHospStatEditGroupField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			RefreshHospStatFields();
			//txtDisplayOrder = frmSectionIndicator.rdcPatientFields.Resultset!DisplayOrder

		}

		public void RefreshHospStatFields()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			//retrieve the list of Fields
			modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID = tbl_setup_TableDef.BaseTableID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and upper(substring(tbl_setup_TableDef.BaseTable,1,13)) = 'HOSPITAL STAT'  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select DDID from tbl_setup_HospStatGroupFields  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where hospstatgroupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmHospStatSetup.lstHospStatGroup, My.MyProject.Forms.frmHospStatSetup.lstHospStatGroup.SelectedIndex) + ")";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.State = '' or tbl_Setup_DataDef.State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.State = '' or tbl_Setup_DataDef.State is null or  tbl_Setup_DataDef.State = '" + modGlobal.gv_State + "') ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstHospStatFields.Items.Clear();
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

				lstHospStatFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["ddid"].Value));
				modGlobal.gv_rs.MoveNext();
			}


		}
	}
}
