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
	internal partial class OldfrmMeasureModifyOperator : System.Windows.Forms.Form
	{
		object mcid;

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (cmbOperators.SelectedIndex < 0) {
				Interaction.MsgBox("Please select an operator");
				return;
			}

			modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set valueoperator = '" + cmbOperators.Text + "' ";
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			modGlobal.UpdateVerificationCriteriaTitle(ref mcid);

			this.Close();


		}

		private void frmMeasureModifyOperator_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

		}

		public void SetMeasureCriteriaID(ref object MeasureCriteriaID)
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mcid = MeasureCriteriaID;
			RefreshOperatorList();

		}

		public void RefreshOperatorList()
		{

			cmbOperators.Items.Clear();

			modGlobal.gv_sql = "select * from tbl_Setup_MeasureCriteria ";
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.rdoColumns["valueoperator"].Value == "In" | modGlobal.gv_rs.rdoColumns["valueoperator"].Value == "Not In") {

				cmbOperators.Items.Add("In");
				cmbOperators.Items.Add("Not In");

			} else {

				cmbOperators.Items.Add("=");
				cmbOperators.Items.Add("<>");
				cmbOperators.Items.Add(">");
				cmbOperators.Items.Add("<");
				cmbOperators.Items.Add(">=");
				cmbOperators.Items.Add("<=");

			}
			modGlobal.gv_rs.Close();

		}
	}
}
