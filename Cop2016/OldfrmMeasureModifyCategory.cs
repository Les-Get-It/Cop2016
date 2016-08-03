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
	internal partial class OldfrmMeasureModifyCategory : System.Windows.Forms.Form
	{
		private void Label1_Click()
		{

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object ls_CritType = null;
			short Index = 0;

			Index =frmMeasureCriteriaSetup.SSTabCriteria.SelectedIndex;
			switch (Index) {
				case 0:
					//UPGRADE_WARNING: Couldn't resolve default property of object ls_CritType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ls_CritType = "Reg";
					break;
				case 1:
					//UPGRADE_WARNING: Couldn't resolve default property of object ls_CritType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ls_CritType = "Filter";
					break;
				case 2:
					//UPGRADE_WARNING: Couldn't resolve default property of object ls_CritType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ls_CritType = "Risk";
					break;
			}


			if (cboCat.SelectedIndex > -1 & !string.IsNullOrEmpty(txtGoToStep.Text)) {
				Interaction.MsgBox("Either category or the destination step has to be defined, but not both.");
				return;
			}

			object MeasureStepID = null;

			modGlobal.gv_sql = " select MeasureStepID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID , MeasureCriteriaID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStep ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmMeasureCriteriaSetup.lstMeasureDef[Index],frmMeasureCriteriaSetup.lstMeasureDef[Index].SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
			modGlobal.gv_rs.Close();

			modGlobal.gv_sql = "Update tbl_Setup_MeasureStep set ";
			if (cboCat.SelectedIndex < 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Measure_CatID = null ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " Measure_CatID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboCat, cboCat.SelectedIndex);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ",  ";
			if (string.IsNullOrEmpty(txtGoToStep.Text)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " gotostep = null ";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " gotostep = " + txtGoToStep.Text;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object ls_CritType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (ls_CritType == "Risk") {
				modGlobal.gv_sql = modGlobal.gv_sql + ", IsRisk = 1";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + ", IsRisk = 0";
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStepID = " + MeasureStepID;

			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			this.Close();

		}

		private void frmMeasureModifyCategory_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));


			RefreshCatList();
		}

		public void RefreshCatList()
		{
			object CatID = null;
			object is_CritType = null;
			int li_SELcatID = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			string ls_CritType = null;

			switch (My.MyProject.Forms.frmMeasureCriteriaSetup.SSTabCriteria.SelectedIndex) {
				case 0:
					ls_CritType = "Reg";
					break;
				case 1:
					ls_CritType = "Filter";
					break;
				case 2:
					ls_CritType = "Risk";
					break;
			}

			li_SELcatID = -1;
			modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT ";

			//UPGRADE_WARNING: Couldn't resolve default property of object is_CritType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (is_CritType == "Reg") {
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE CAT_TYPE = 'CI'";
				//UPGRADE_WARNING: Couldn't resolve default property of object is_CritType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (is_CritType == "Risk") {
				//gv_sql = gv_sql & " WHERE CAT_TYPE = 'RA'"
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE (CAT_TYPE = 'RA' Or IsRisk = 1) ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY CAT";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboCat.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboCat.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["CAT"].Value, modGlobal.gv_rs.rdoColumns["measure_catid"].Value));
				//UPGRADE_WARNING: Couldn't resolve default property of object CatID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (!string.IsNullOrEmpty(CatID))
					if (modGlobal.gv_rs.rdoColumns["measure_catid"].Value == Convert.ToInt16(CatID)) {
						//UPGRADE_ISSUE: ComboBox property cboCat.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
						li_SELcatID = cboCat.NewIndex;
					}
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			cboCat.SelectedIndex = li_SELcatID;

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}
	}
}
