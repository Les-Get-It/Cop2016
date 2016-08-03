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
	internal partial class OldfrmMeasureCriteriaSubmitSubs : System.Windows.Forms.Form
	{
		object MeasureID;
		object MeasureStepID;
		public void RefreshMeasureCriteria()
		{
			object lstMeasureDef = null;
			short Index = 0;
			object ls_Suffix = null;
			string ls_Prefix = null;
			object ls_MainOp = null;
			string ls_PrevSet = null;
			object li_TotCriteriaInSet = null;
			object li_StepCount = null;
			object li_CritCount = null;
			object li_SetCount = null;
			object li_TotStep = null;
			int li_TotSetInStep = 0;
			DataSet  rs_TotCrit = null;
			object rs_TotSetInStep = null;
			DataSet  rs_Crit = null;

			//On Error GoTo ErrHandler


			//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lstMeasureDef.Clear();

			DataSet  rs_MeasStep = null;

			modGlobal.gv_sql = "SELECT DISTINCT MeasureStep, MeasureStepID, CAT ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms, tbl_MEASURE_CAT m ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ms.Measure_CATID = m.MEASURE_CATID";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " AND ms.MeasureID = " + MeasureID;
			modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep <> -100 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " AND CAT_TYPE = 'CI'";
			modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC";

			//gv_g = InputBox("", "", gv_sql)
			rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (rs_MeasStep.EOF)
				return;

			rs_MeasStep.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_TotStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_TotStep = rs_MeasStep.RowCount;
			rs_MeasStep.MoveFirst();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_StepCount = 0;

			//STEP LOOP
			while (!rs_MeasStep.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_StepCount = li_StepCount + 1;

				//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ls_Suffix = "";

				if (Index == 0 | Index == 2) {
					lstMeasureDef.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Step " + rs_MeasStep.rdoColumns["measurestep"].Value + ": = " + rs_MeasStep.rdoColumns["CAT"].Value + " (", -1));
				}

				//SET QUERY
				modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet mcs, tbl_Setup_MeasureStep ms ";
				modGlobal.gv_sql = modGlobal.gv_sql + "  WHERE ms.MeasureStepID = mcs.MeasureStepID AND ms.MeasureStepID = ";
				modGlobal.gv_sql = modGlobal.gv_sql + rs_MeasStep.rdoColumns["MeasureStepID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY mcs.MeasureCriteriaSet ASC";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.EOF)
					return;

				modGlobal.gv_rs.MoveLast();
				li_TotSetInStep = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveFirst();
				//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_SetCount = 0;

				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_SetCount = li_SetCount + 1;

					//will display join operator for first measurecriteriaset
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ls_MainOp = "AND";
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ls_MainOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CritCount = 0;
					ls_PrevSet = "";

					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteria WHERE MeasureCriteriaSetID = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
					rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (rs_Crit.EOF)
						return;
					rs_Crit.MoveLast();
					//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_TotCriteriaInSet = rs_Crit.RowCount;
					rs_Crit.MoveFirst();

					//CRITERIA LOOP
					while (!rs_Crit.EOF) {
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_CritCount = li_CritCount + 1;

						ls_Prefix = "Set " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value + ": (";

						//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == li_TotCriteriaInSet) {
							//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (li_TotCriteriaInSet == 1) {
								//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								ls_Suffix = "     (" + rs_Crit.rdoColumns["JoinOperator"].Value + ") )";
							} else {
								//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								ls_Suffix = " )  ";
							}
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ls_Suffix = "   " + rs_Crit.rdoColumns["JoinOperator"].Value;
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == 1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef.AddItem("     " + ls_Prefix + rs_Crit.rdoColumns["CriteriaTitle"].Value + ls_Suffix);
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef.AddItem("          " + rs_Crit.rdoColumns["CriteriaTitle"].Value + ls_Suffix);
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.Items.Count-1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstMeasureDef.ItemData(lstMeasureDef.Items.Count-1) = rs_Crit.rdoColumns["MeasureCriteriaID"].Value;

						//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == li_TotCriteriaInSet & li_SetCount < li_TotSetInStep) {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef.AddItem("     " + ls_MainOp);
							//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.Items.Count-1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstMeasureDef.ItemData(lstMeasureDef.Items.Count-1) = -1;
						}

						rs_Crit.MoveNext();
					}

					//LDW modGlobal.gv_rs.MoveNext();
				}

				if (Index == 0 | Index == 2) {
					//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstMeasureDef.AddItem(") ");
					//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.Items.Count-1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object lstMeasureDef.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lstMeasureDef.ItemData(lstMeasureDef.Items.Count-1) = -1;
				}

				modGlobal.gv_rs.Dispose();
				rs_MeasStep.MoveNext();

			}

			rs_MeasStep.Close();


			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}
		public void RefreshMeasureCriteriaSubmitSubs()
		{
			short Index = 0;
			object ls_Suffix = null;
			string ls_Prefix = null;
			object ls_MainOp = null;
			string ls_PrevSet = null;
			object li_TotCriteriaInSet = null;
			object li_StepCount = null;
			object li_CritCount = null;
			object li_SetCount = null;
			object li_TotStep = null;
			int li_TotSetInStep = 0;
			DataSet  rs_TotCrit = null;
			object rs_TotSetInStep = null;
			DataSet  rs_Crit = null;

			//On Error GoTo ErrHandler

			//If lstMeasureDef.ListIndex < 0 Then
			//    MsgBox "Please select a step from verification process."
			//    Exit Sub
			//End If
			//If lstMeasureDef.ItemData(lstMeasureDef.ListIndex) = -1 Then
			//    Exit Sub
			//End If


			lstSubmissionDef.Items.Clear();

			DataSet  rs_MeasStep = null;

			modGlobal.gv_sql = "SELECT DISTINCT ms.MeasureStep, msss.MeasureStepSubmitSubsID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStepSubmitSubs msss inner join tbl_Setup_MeasureStep as ms ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on msss.measureStepID = ms.MeasureStepID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " ms.MeasureStepID =  " + MeasureStepID;


			rs_MeasStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (rs_MeasStep.EOF)
				return;

			rs_MeasStep.MoveLast();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_TotStep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_TotStep = rs_MeasStep.RowCount;
			rs_MeasStep.MoveFirst();
			//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			li_StepCount = 0;

			//STEP LOOP
			while (!rs_MeasStep.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object li_StepCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_StepCount = li_StepCount + 1;

				//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ls_Suffix = "";

				if (Index == 0 | Index == 2) {
					lstSubmissionDef.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Step " + rs_MeasStep.rdoColumns["measurestep"].Value + " (", -1));
				}

				//SET QUERY
				modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSetSubmitSubs mcs, tbl_Setup_MeasureStepSubmitSubs ms ";
				modGlobal.gv_sql = modGlobal.gv_sql + "  WHERE ms.MeasureStepSubmitSubsID = mcs.MeasureStepSubmitSubsID AND ms.MeasureStepSubmitSubsID = ";
				modGlobal.gv_sql = modGlobal.gv_sql + rs_MeasStep.rdoColumns["MeasureStepSubmitSubsID"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY mcs.MeasureCriteriaSet ASC";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.EOF)
					return;

				modGlobal.gv_rs.MoveLast();
				li_TotSetInStep = modGlobal.gv_rs.RowCount;
				modGlobal.gv_rs.MoveFirst();
				//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				li_SetCount = 0;

				while (!modGlobal.gv_rs.EOF) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_SetCount = li_SetCount + 1;

					//will display join operator for first measurecriteriaset
					//ls_MainOp = Nz(gv_rs!JoinOperator, "AND")
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) | string.IsNullOrEmpty(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) {
						//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ls_MainOp = "AND";
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ls_MainOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_CritCount = 0;
					ls_PrevSet = "";

					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSubmitSubs WHERE MeasureCriteriaSetSubmitSubsID = " + modGlobal.gv_rs.rdoColumns["measureCriteriaSetSubmitSubsID"].Value;
					rs_Crit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (rs_Crit.EOF)
						return;
					rs_Crit.MoveLast();
					//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					li_TotCriteriaInSet = rs_Crit.RowCount;
					rs_Crit.MoveFirst();

					//CRITERIA LOOP
					while (!rs_Crit.EOF) {
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						li_CritCount = li_CritCount + 1;

						ls_Prefix = "Set " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value + ": (";

						//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == li_TotCriteriaInSet) {
							//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							if (li_TotCriteriaInSet == 1) {
								//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								ls_Suffix = "     (" + rs_Crit.rdoColumns["JoinOperator"].Value + ") )";
							} else {
								//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								ls_Suffix = " )  ";
							}
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ls_Suffix = "   " + rs_Crit.rdoColumns["JoinOperator"].Value;
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == 1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstSubmissionDef.Items.Add("     " + ls_Prefix + rs_Crit.rdoColumns["CriteriaTitle"].Value + ls_Suffix);
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_Suffix. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstSubmissionDef.Items.Add("          " + rs_Crit.rdoColumns["CriteriaTitle"].Value + ls_Suffix);
						}
						//UPGRADE_ISSUE: ListBox property lstSubmissionDef.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
						Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstSubmissionDef, lstSubmissionDef.Items.Count-1, rs_Crit.rdoColumns["measureCriteriaSubmitSubsID"].Value);

						//UPGRADE_WARNING: Couldn't resolve default property of object li_SetCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_TotCriteriaInSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object li_CritCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (li_CritCount == li_TotCriteriaInSet & li_SetCount < li_TotSetInStep) {
							//UPGRADE_WARNING: Couldn't resolve default property of object ls_MainOp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							lstSubmissionDef.Items.Add("     " + ls_MainOp);
							//UPGRADE_ISSUE: ListBox property lstSubmissionDef.Items.Count-1 was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
							Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstSubmissionDef, lstSubmissionDef.Items.Count-1, -1);
						}

						rs_Crit.MoveNext();
					}
					rs_Crit.Close();
					//LDW modGlobal.gv_rs.MoveNext();
				}

				if (Index == 0 | Index == 2) {
					lstSubmissionDef.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(") ", -1));
				}

				modGlobal.gv_rs.Dispose();
				rs_MeasStep.MoveNext();

			}

			rs_MeasStep.Close();


			return;
			ErrHandler:
			modGlobal.CheckForErrors();
		}
//UPGRADE_NOTE: mid was upgraded to mid_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		public void SetupMeasureID(ref object mid_Renamed, ref object indicatordesc, ref object criteriaID)
		{
			object measurestep = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object mid_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MeasureID = mid_Renamed;
			//UPGRADE_WARNING: Couldn't resolve default property of object indicatordesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblIndicatorDesc.Text = indicatordesc;
			modGlobal.gv_sql = " select MeasureStepID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID , MeasureCriteriaID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStep ";
			//UPGRADE_WARNING: Couldn't resolve default property of object criteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureCriteriaID = " + criteriaID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MeasureStepID = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
			modGlobal.gv_rs.Dispose();

			modGlobal.gv_sql = " select MeasureStep  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureStep ";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + MeasureStepID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object measurestep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			measurestep = modGlobal.gv_rs.rdoColumns["measurestep"].Value;
			modGlobal.gv_rs.Dispose();

			//UPGRADE_WARNING: Couldn't resolve default property of object measurestep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblMeasureStep.Text = " Replacement for Verification Step: " + measurestep;

			RefreshMeasureCriteriaSubmitSubs();

		}

		private void cmdAddCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdAddCriteria.GetIndex(eventSender);

			string ls_CritType = null;

			//frmMeasureAddCritSetup.setCritType ls_CritType
			//frmMeasureAddCritSetup.setRowCount rdcMeasureList.Resultset.RowCount
			frmMeasureAddCritSubmitSubsSetup.setMeasureStepID(ref MeasureStepID);
			frmMeasureAddCritSubmitSubsSetup.ShowDialog();

			RefreshMeasureCriteriaSubmitSubs();



		}

		private void cmdChangeAddOrBetweenSets_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdChangeAddOrBetweenSets.GetIndex(eventSender);
			//On Error GoTo ErrHandler


			if (lstSubmissionDef.SelectedIndex == 0) {
				return;
			}

			if (RadMessageBox.Show("Are you sure you want to change the join operator between all sets in this step?", MsgBoxStyle.YesNo, "Change Join Operator Between All Sets") == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = "SELECT * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_setup_MeasureCriteriaSetSubmitSubs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepSubmitSubsID = (SELECT ms.MeasureStepSubmitSubsID FROM tbl_Setup_MeasureStepSubmitSubs ms, " + " tbl_Setup_MeasureCriteriaSetSubmitSubs mcs, tbl_Setup_MeasureCriteriaSubmitSubs mc " + " WHERE mc.MeasureCriteriaSetSubmitSubsID = mcs.MeasureCriteriaSetSubmitSubsID AND mcs.MeasureStepSubmitSubsID = ms.MeasureStepSubmitSubsID AND " + " mc.MeasureCriteriaSubmitSubsID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex) + ")";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);

			while (!modGlobal.gv_rs.EOF) {
				modGlobal.gv_rs.Edit();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) | Strings.Len(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == 0) {
					modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = "OR";
				} else {
					modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == "AND" ? "OR" : "AND");
				}
				modGlobal.gv_rs.Update();
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

			RefreshMeasureCriteriaSubmitSubs();

			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}

		private void cmdChangeAndOrCond_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdChangeAndOrCond.GetIndex(eventSender);
			int li_cnt = 0;

			//On Error GoTo ErrHandler


			if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex) < 0) {
				return;
			}

			for (li_cnt = 0; li_cnt <= lstSubmissionDef.Items.Count - 1; li_cnt++) {
				if (lstSubmissionDef.GetSelected(li_cnt)) {
					modGlobal.gv_sql = "Select * ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteriaSubmitSubs ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Where MeasureCriteriaSubmitSubsID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSubmissionDef, li_cnt);

					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
					while (!modGlobal.gv_rs.EOF) {
						modGlobal.gv_rs.Edit();
						modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = (Strings.UCase(Strings.Trim(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value)) == "AND" ? "OR" : "AND");
						modGlobal.gv_rs.Update();
						//LDW modGlobal.gv_rs.MoveNext();
					}
					modGlobal.gv_rs.Dispose();
				}
			}

			RefreshMeasureCriteriaSubmitSubs();
			return;
			ErrHandler:
			modGlobal.CheckForErrors();

		}

		private void cmdDelCriteria_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			short Index = cmdDelCriteria.GetIndex(eventSender);
			object li_cnt = null;

			if (lstSubmissionDef.SelectedIndex < 0) {
				return;
			}

			if (lstSubmissionDef.SelectedItems.Count > 0 & Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex) > -1) {
				if (RadMessageBox.Show("Are you sure you want to delete this criteria?", MsgBoxStyle.YesNo, "Delete Criteria") == DialogResult.No) {
					return;
				}

				//allow delete of multiple criteria
				for (li_cnt = 0; li_cnt <= lstSubmissionDef.Items.Count - 1; li_cnt++) {
					if (lstSubmissionDef.GetSelected(li_cnt) & Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSubmissionDef, li_cnt) > 0) {
						if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSubmissionDef, lstSubmissionDef.SelectedIndex) == 0)
							return;

						//gv_sql = "select mcs.MeasureCriteriaSetSubmitSubsID , mcs.MeasureStepSubmitSubsID, mcs.MeasureCriteriaSet from " & _
						//'        " tbl_setup_measurecriteriaSubmitSub mc, tbl_setup_measurecriteriasetSubmitSub mcs, tbl_Setup_MeasureStepSubmitSub ms where " & _
						//'        " mc.measurecriteriasetSubmitSubsid = mcs.measurecriteriasetSubmitSubsid " & _
						//'        " AND ms.MeasureStepSubmitSubsID = mcs.MeasureStepSubmitSubsID " & _
						//'        " AND mc.MeasureCriteriaSubmitSubsID  = " & lstMeasureDef(Index).ItemData(li_cnt)
						//
						//Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
						//li_MeasureCriteriaSetID = gv_rs!MeasureCriteriaSetSubmitSubsID
						//li_MeasureStepID = gv_rs!MeasureStepSubmitSubsID
						//li_MeasureSet = gv_rs!MeasureCriteriaSubmitSubsSet
						//gv_rs.Close

						modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteriaSubmitSubs ";
						modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSubmitSubsID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSubmissionDef, li_cnt);
						DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


						lstSubmissionDef.SetSelected(li_cnt, false);
					}
				}
			} else {
				RadMessageBox.Show("Select criteria to delete", MsgBoxStyle.Critical, "No Criteria Selected");
			}

			modGlobal.gv_sql = "Delete tbl_Setup_MeasureCriteriaSetSubmitSubs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetSubmitSubsID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCriteriaSetSubmitSubsID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs) ";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = " delete tbl_Setup_MeasureStepSubmitSubs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStepSubmitSubsID not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureStepSubmitSubsID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MeasureCriteriaSetSubmitSubs) ";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


			RefreshMeasureCriteriaSubmitSubs();

		}

		private void cmdRemoveSubmitSubsStep_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			DialogResult resp =;
			object vbyseno = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object vbyseno. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			resp = RadMessageBox.Show("Are you sure you want to remove this substitution for the Verification Step in Summarization process?", vbyseno, "Remove Substitution.");
			if (resp == DialogResult.No) {
				return;
			}

			modGlobal.gv_sql = " delete tbl_Setup_MeasureCriteriaSubmitSubs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetSubmitSubsID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCriteriaSetSubmitSubsID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + MeasureStepID + ")";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = " delete tbl_Setup_MeasureCriteriaSetSubmitSubs ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetSubmitSubsID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCriteriaSetSubmitSubsID  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + MeasureStepID + ")";
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			modGlobal.gv_sql = "delete tbl_Setup_MeasureStepSubmitSubs ";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + MeasureStepID;
			DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			RefreshMeasureCriteriaSubmitSubs();


		}

		private void cmdSubmitSubsStep_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object newCritSetID = null;
			object MeasureStepSubmitSubsID = null;


			modGlobal.gv_sql = " select MeasureStepID, MeasureStepSubmitSubsID,";
			modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetSubmitSubsID , MeasureCriteriaSubmitSubsID ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + MeasureStepID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//create a link to the step if it doesn't exist
			DataSet  rs_critSet = null;
			if (modGlobal.gv_rs.RowCount == 0) {
				modGlobal.gv_sql = "insert into tbl_Setup_MeasureStepSubmitSubs (MeasureStepID) ";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + MeasureStepID + ")";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				modGlobal.gv_sql = " select MeasureStepID, MeasureStepSubmitSubsID,";
				modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetSubmitSubsID , MeasureCriteriaSubmitSubsID ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureCriteriaSetStepSubmitSubs ";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + MeasureStepID;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//gv_g = InputBox("", "", gv_sql)
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepSubmitSubsID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureStepSubmitSubsID = modGlobal.gv_rs.rdoColumns["MeasureStepSubmitSubsID"].Value;

				//copy the sets and criteria for the subs step
				modGlobal.gv_sql = " select MeasureCriteriaSetID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
				modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureStepID = " + MeasureStepID;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				while (!modGlobal.gv_rs.EOF) {

					//add the set
					modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteriaSetSubmitSubs (";
					modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
					modGlobal.gv_sql = modGlobal.gv_sql + " MeasureStepSubmitSubsID,";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator) ";
					modGlobal.gv_sql = modGlobal.gv_sql + " select ";
					modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSet,";
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepSubmitSubsID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + MeasureStepSubmitSubsID + ",";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetID = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

					//find the new id
					modGlobal.gv_sql = " select max(MeasureCriteriaSetSubmitSubsID) as newcid ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSetSubmitSubs ";
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureStepSubmitSubsID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStepSubmitSubsID = " + MeasureStepSubmitSubsID;
					rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					//UPGRADE_WARNING: Couldn't resolve default property of object newCritSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					newCritSetID = rs_critSet.rdoColumns["newcid"].Value;

					//add criteria per set
					modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteriaSubmitSubs ( ";
					modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetSubmitSubsID ,";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle ,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2,";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator,";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID,";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID,";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit,";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID,";
					modGlobal.gv_sql = modGlobal.gv_sql + " State,";
					modGlobal.gv_sql = modGlobal.gv_sql + " RecordStatus) ";

					modGlobal.gv_sql = modGlobal.gv_sql + " select ";
					//UPGRADE_WARNING: Couldn't resolve default property of object newCritSetID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + newCritSetID + " ,";
					modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle ,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, DDID2,";
					modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator,";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DestDDID,";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupID,";
					modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator,";
					modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit,";
					modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator,";
					modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID,";
					modGlobal.gv_sql = modGlobal.gv_sql + " State,";
					modGlobal.gv_sql = modGlobal.gv_sql + " RecordStatus ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaSetID = " + modGlobal.gv_rs.rdoColumns["MeasureCriteriaSetID"].Value;

					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


					//LDW modGlobal.gv_rs.MoveNext();
				}
				modGlobal.gv_rs.Dispose();

				RefreshMeasureCriteriaSubmitSubs();

			} else {
				RadMessageBox.Show("Substitution Step for Submission already exists for the verification step");
			}
		}

		private void lstMeasureDef_Click()
		{

			RefreshMeasureCriteriaSubmitSubs();

		}

		private void frmMeasureCriteriaSubmitSubs_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			frmMeasureCriteriaSetup.Show();
		}
	}
}
