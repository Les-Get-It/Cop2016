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
	internal partial class OldfrmSetupStateVersion : System.Windows.Forms.Form
	{
		private void cmdReset_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object resp = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = Interaction.MsgBox("This feature will remove the version history from the system. Are you sure you want to continue?", MsgBoxStyle.YesNo, "Reset Version");
			if (resp == MsgBoxResult.Yes) {
				modGlobal.gv_sql = "Delete tbl_setup_Stateversion ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Where StateVersion <> 0 ";
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				refreshVersionHistory();
			}

		}

		private void frmSetupStateVersion_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			this.Text = "Setup Version History for the State of " + modGlobal.gv_State;
			refreshVersionHistory();
		}

		public void refreshVersionHistory()
		{
			modGlobal.gv_sql = "Select  *  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_StateVersion ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " Where State = '" + modGlobal.gv_State + "'";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by StateVersion desc ";

			rdcVersionHistory.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcVersionHistory.CtlRefresh();
			//resp = InputBox("", "", gv_sql) 'rdcPatientFields.Resultset.RowCount
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgVersionHistory.CtlRefresh();

		}
	}
}
