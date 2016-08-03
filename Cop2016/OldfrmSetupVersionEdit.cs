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
	internal partial class OldfrmSetupVersionEdit : System.Windows.Forms.Form
	{

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Action = "update";

			modGlobal.gv_sql = "update tbl_Setup_Version ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set Notes = '" + txtNotes.Text + "',";
			if (string.IsNullOrEmpty(txtVersionEndDate.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " VersionEndDate = null";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " VersionEnddate = '" + txtVersionEndDate.Text + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " Where versionid = " + My.MyProject.Forms.frmSetupVersion.rdcVersionHistory.Resultset.rdoColumns["versionid"].Value;
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			this.Close();
		}

		private void frmSetupVersionEdit_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (!Information.IsDBNull(My.MyProject.Forms.frmSetupVersion.txtNotes.Text)) {
				txtNotes.Text = My.MyProject.Forms.frmSetupVersion.txtNotes.Text;
			}
			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (!Information.IsDBNull(My.MyProject.Forms.frmSetupVersion.rdcVersionHistory.Resultset.rdoColumns["VersionEndDate"].Value)) {
				txtVersionEndDate.Text = My.MyProject.Forms.frmSetupVersion.rdcVersionHistory.Resultset.rdoColumns["VersionEndDate"].Value;
			}
		}
	}
}
