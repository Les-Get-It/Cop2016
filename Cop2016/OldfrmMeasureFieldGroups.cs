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
namespace COP2001
{
	internal partial class OldfrmMeasureFieldGroups : System.Windows.Forms.Form
	{

		private void cmdPrint_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			Printer Printer = new Printer();
			short Index = 0;
			int li_cnt = 0;


			System.Data.DataSet  rsTemp = null;


			//  Printer.Print MSRDCGroups.Resultset!CriteriaTitle
			rsTemp = MSRDCGroups.Resultset;

			rsTemp.MoveFirst();

			while (!rsTemp.EOF) {
				Printer.Print(FileSystem.TAB(15), rsTemp.rdoColumns["CriteriaTitle"]);
				rsTemp.MoveNext();
			}

			Printer.Print("End of Saved Logic List");
			Printer.EndDoc();




		}


		private void dbgGroups_KeyDownEvent(System.Object eventSender, AxMSDBGrid.DBGridEvents_KeyDownEvent eventArgs)
		{
			object Cancel = null;
			if (eventArgs.keyCode == System.Windows.Forms.Keys.Delete) {
				if (dbgGroups.Row >= 0) {

					//UPGRADE_WARNING: Couldn't resolve default property of object dbgGroups.Columns!measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "SELECT Count(*) Used FROM tbl_Setup_MeasureCriteria WHERE MeasureFieldGroupLogicID = " + dbgGroups.get_Columns("measurefieldgrouplogicid");
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					if (modGlobal.gv_rs.rdoColumns["Used"].Value > 0) {
						Interaction.MsgBox("Can not delete this group it is used in criteria", MsgBoxStyle.Critical, "Can Not Delete");
					} else {
						if (Interaction.MsgBox("Are you sure you want to delete this Measure Field Group Logic?", MsgBoxStyle.YesNo, "Confirm Delete") == MsgBoxResult.Yes) {

							//UPGRADE_WARNING: Couldn't resolve default property of object dbgGroups.Columns!measurefieldgrouplogicid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureFieldGroupLogic WHERE MeasureFieldGroupLogicID = " + dbgGroups.get_Columns("measurefieldgrouplogicid");

							modGlobal.gv_cn.Execute(modGlobal.gv_sql);
							RefreshMeasureFieldGroupLogic();
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object Cancel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Cancel = true;
						}
					}
				}
			}

			System.Windows.Forms.Application.DoEvents();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgGroups.CtlRefresh();

		}





		private void frmMeasureFieldGroups_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshMeasureFieldGroupLogic();

		}

		private void RefreshMeasureFieldGroupLogic()
		{
			System.Data.DataSet  rs_Temp = null;
			string ls_Sql = null;

			ls_Sql = "SELECT CriteriaTitle, MeasureFieldGroupLogicID  FROM tbl_Setup_MeasureFieldGroupLogic ORDER BY CriteriaTitle";
			rs_Temp = modGlobal.gv_cn.OpenResultset(ls_Sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (!rs_Temp.EOF) {
				MSRDCGroups.Resultset = rs_Temp;
			} else {
				//UPGRADE_NOTE: Object MSRDCGroups.Resultset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				MSRDCGroups.Resultset = null;
			}
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			MSRDCGroups.CtlRefresh();
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgGroups.CtlRefresh();


		}
	}
}
