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
	internal partial class OldfrmSectionEditPatientField : System.Windows.Forms.Form
	{

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdSelect_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newid = null;
			var i = 0;

			for (i = 0; i <= lstIndicators.Items.Count - 1; i++) {
				if (lstIndicators.GetSelected(i)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					newid = modDBSetup.FindMaxRecID("tbl_Setup_DataReq", "IndicatorDDID");


					modGlobal.gv_sql = "Insert into tbl_setup_DataReq (IndicatorDDID, IndicatorID, DDID)";
					//UPGRADE_WARNING: Couldn't resolve default property of object newid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " Values (" + newid;
					modGlobal.gv_sql = modGlobal.gv_sql + "," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstIndicators, i);
					modGlobal.gv_sql = modGlobal.gv_sql + "," + frmPatientSetupCopy.rdcPatientFields.Tables[rdcPatientFieldsTable].Columns["DDID"] + ")";

					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }
			}

			this.Close();

		}

		private void frmSectionEditPatientField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			refreshIndicators();
			//txtDisplayOrder = frmSectionIndicator.rdcPatientFields.Resultset!DisplayOrder

		}

		public void refreshIndicators()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			//retrieve the list of indicators
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Where IndicatorID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Select IndicatorID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DataReq ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where DDID = " + frmPatientSetupCopy.rdcPatientFields.Tables[rdcPatientFieldsTable].Columns["DDID"] + ")";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is Null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null or State = '" + modGlobal.gv_State + "')";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " and 1 = (SELECT CASE WHEN FieldCategory = 'Dynamic' THEN 1 ELSE 0 END FROM tbl_Setup_DataDef WHERE DDID = " + frmPatientSetupCopy.rdcPatientFields.Tables[rdcPatientFieldsTable].Columns["DDID"] + " )";
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

				lstIndicators.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
				modGlobal.gv_rs.MoveNext();
			}


		}
	}
}
