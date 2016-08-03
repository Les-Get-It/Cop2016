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
	internal partial class OldfrmMeasureMoveStepTo : System.Windows.Forms.Form
	{
		object MeasureCategory;
		object IndicatorID;
		object MeasureCriteriaID;
		object SelectedStep;

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			MoveToSelectedStep();
			this.Close();
		}

		private void frmMeasureMoveStepTo_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			RefreshSteps();
			//txtDisplayOrder = frmSectionIndicator.rdcPatientFields.Resultset!DisplayOrder

		}

		public void SetMeasureCriteriaID(ref object IID, ref object mcid, ref object mcat)
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MeasureCriteriaID = mcid;
			//UPGRADE_WARNING: Couldn't resolve default property of object mcat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MeasureCategory = mcat;
			//UPGRADE_WARNING: Couldn't resolve default property of object IID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			IndicatorID = IID;

			modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, mc.Cat_Type ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureStep ms ";
			modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID   ";
			//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureID = " + IndicatorID;
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (MeasureCategory == "CI") {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and ((mc.CAT_TYPE is null or mc.CAT_TYPE = '" + MeasureCategory + "') And IsRisk = 0)";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.CAT_TYPE = '" + MeasureCategory + "')";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (MeasureCategory == "RA") {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (IsRisk = 1) ";
				}
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureStep <> -100 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and ms.MeasureStepID in  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select ms.MeasureStepID from tbl_setup_MeasureCriteriaSet as ms ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_MeasureCriteria as mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mc.measurecriteriasetid = ms.MeasurecriteriasetID  ";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE mc.MeasureCriteriaID = " + MeasureCriteriaID + ")";


			//gv_sql = "SELECT ms.MeasureStep, mcat.Cat_Type "
			//gv_sql = gv_sql & " FROM tbl_setup_MeasureStep ms "
			//gv_sql = gv_sql & " inner join tbl_Measure_Cat mcat "
			//gv_sql = gv_sql & " on ms.Measure_CATID = mcat.Measure_CATID "
			//gv_sql = gv_sql & " Where mcat.CAT_TYPE = '" & MeasureCategory & "'"
			//gv_sql = gv_sql & " and ms.MeasureStepID in  "
			//gv_sql = gv_sql & " (select ms.MeasureStepID from tbl_setup_MeasureCriteriaSet as ms "
			//gv_sql = gv_sql & " inner join tbl_setup_MeasureCriteria as mc "
			//gv_sql = gv_sql & " on mc.measurecriteriasetid = ms.MeasurecriteriasetID  "
			//gv_sql = gv_sql & " WHERE mc.MeasureCriteriaID = " & MeasureCriteriaID & ")"

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

			//UPGRADE_WARNING: Couldn't resolve default property of object SelectedStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SelectedStep = modGlobal.gv_rs.rdoColumns["MeasureStep"].Value;
			modGlobal.gv_rs.Dispose();

		}

		public void RefreshSteps()
		{

			//gv_sql = "SELECT ms.MeasureStep, ms.MeasureStepID  "
			//gv_sql = gv_sql & " FROM tbl_setup_MeasureStep ms "
			//gv_sql = gv_sql & " inner join tbl_Measure_Cat mcat "
			//gv_sql = gv_sql & " on ms.Measure_CATID = mcat.Measure_CATID "
			//gv_sql = gv_sql & " Where mcat.CAT_TYPE = '" & MeasureCategory & "'"
			//gv_sql = gv_sql & " and ms.MeasureID = " & IndicatorID
			//gv_sql = gv_sql & " order by ms.MeasureStep "
			//Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)

			modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureStep ms ";
			modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID   ";
			//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureID = " + IndicatorID;
			//gv_sql = gv_sql & " and (mc.CAT_TYPE is null or mc.CAT_TYPE = '" & MeasureCategory & "')"

			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (MeasureCategory == "CI") {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and ((mc.CAT_TYPE is null or mc.CAT_TYPE = '" + MeasureCategory + "') And IsRisk = 0)";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.CAT_TYPE = '" + MeasureCategory + "')";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (MeasureCategory == "RA") {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (IsRisk = 1) ";
				}
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureStep <> -100 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ms.MeasureStep ";
			//gv_g = InputBox("", "", gv_sql)
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

			//Display the list of fields
			cboSteps.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cboSteps.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["MeasureStep"].Value, modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

		}

		public void MoveToSelectedStep()
		{
			var i = 0;

			//On Error GoTo ErrHandler
			if (cboSteps.SelectedIndex < 0) {
				Interaction.MsgBox("Select a Step before updating the record.");
				return;
			}


			//gv_sql = "SELECT ms.MeasureStepID, ms.MeasureStep  "
			//gv_sql = gv_sql & " FROM tbl_setup_MeasureStep ms "
			//gv_sql = gv_sql & " inner join tbl_Measure_Cat mcat "
			//gv_sql = gv_sql & " on ms.Measure_CATID = mcat.Measure_CATID "
			//gv_sql = gv_sql & " Where mcat.CAT_TYPE = '" & MeasureCategory & "'"
			//gv_sql = gv_sql & " and ms.MeasureID = " & IndicatorID
			//gv_sql = gv_sql & " order by ms.MeasureStep "

			modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, ms.MeasureStepID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureStep ms ";
			modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_MEASURE_CAT mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mc.MEASURE_CATID = ms.MEASURE_CATID   ";
			//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where ms.MeasureID = " + IndicatorID;
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (MeasureCategory == "CI") {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and ((mc.CAT_TYPE is null or mc.CAT_TYPE = '" + MeasureCategory + "') And IsRisk = 0)";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.CAT_TYPE = '" + MeasureCategory + "')";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCategory. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (MeasureCategory == "RA") {
					modGlobal.gv_sql = modGlobal.gv_sql + " and (IsRisk = 1) ";
				}
			}
			//gv_sql = gv_sql & " and (mc.CAT_TYPE is null or mc.CAT_TYPE = '" & MeasureCategory & "')"
			modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureStep <> -100 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY ms.MeasureStep ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			i = 0;
			while (!modGlobal.gv_rs.EOF) {

				//If gv_rs!MeasureStep = cboSteps.Text Then
				//    i = gv_rs!MeasureStep
				//End If

				if (modGlobal.gv_rs.rdoColumns["MeasureStep"].Value == SelectedStep) {
					//update the selected step
					modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = " + cboSteps.Text + " Where MeasureStepID = " + modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
					//i = cboStep.Text
				} else {
					//update other steps
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					i = i + 1;
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (i == cboSteps.Text) {
						//skip this by one
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						i = i + 1;
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = "UPDATE tbl_Setup_MeasureStep " + " SET MeasureStep = " + i + " Where MeasureStepID = " + modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
				}
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				//LDW modGlobal.gv_rs.MoveNext();
			}


			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}
	}
}
