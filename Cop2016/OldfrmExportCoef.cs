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
	internal partial class OldfrmExportCoef : System.Windows.Forms.Form
	{
		object JCVersion;
		object FileNum;

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdExport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object msg = null;
			object UpdateFile = null;
			//first line of each table will be tablename in [], followed by the records in the table


			My.MyProject.Forms.FileFind.Text = "Specify the destination directory for RiskModel.txt";
			My.MyProject.Forms.FileFind.ShowDialog();
			if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				UpdateFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory, Strings.Len(modGlobal.gv_SelectedDirectory), 1) == "\\" ? "RiskModel.txt" : "\\RiskModel.txt");
			} else {
				return;
			}
			 // ERROR: Not supported in C#: OnErrorStatement


			//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.Kill(UpdateFile);
			 // ERROR: Not supported in C#: OnErrorStatement


			this.Refresh();
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileNum = FreeFile();
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileOpen(FileNum, UpdateFile, OpenMode.Output);

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			int li_cnt = 0;
			string ls_quarters = null;


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[PERIODS]");
			var _with1 = lstPeriods;

			for (li_cnt = 0; li_cnt <= _with1.Items.Count - 1; li_cnt++) {
				if (_with1.GetSelected(li_cnt)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FileSystem.PrintLine(FileNum, Strings.Trim(Convert.ToString(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstPeriods, li_cnt))));
					ls_quarters = ls_quarters + "'" + Strings.Trim(Convert.ToString(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstPeriods, li_cnt))) + "',";
				}
			}


			//take off the last comma
			ls_quarters = Strings.Mid(ls_quarters, 1, Strings.Len(ls_quarters) - 1);

			//    For li_cnt = 0 To lstPeriods.ListCount - 1
			//        Print #FileNum, Trim(lstPeriods.ItemData(li_cnt))
			//    Next


			OutputIndicatorRiskCoefficientTables(ref ls_quarters);

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileClose(FileNum);

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Interaction.MsgBox("The update file '" + UpdateFile + "' was successfully created.");

			return;
			UpdateErr:

			if (Err().Number == 71) {
				 // ERROR: Not supported in C#: OnErrorStatement

				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				Interaction.MsgBox("The Destination directory does not exist. Please Check Again.");
				return;
			} else {

				//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msg = "The following error occured in the process of creating an update for Access database: " + Strings.Chr(13) + Strings.Chr(10);
				//UPGRADE_WARNING: Couldn't resolve default property of object msg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msg = msg + Err().Number + ": " + Err().Description;
				 // ERROR: Not supported in C#: OnErrorStatement

				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.FileClose(FileNum);
				//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
				Interaction.MsgBox(msg);
				return;
			}

		}

		private void frmExportCoef_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			RefreshPeriods();

		}

		private void OutputIndicatorRiskCoefficientTables(ref string Quarters)
		{
			object Method = null;
			object factortxt = null;
			object TriggerValue = null;
			object triggerID = null;
			object strtab = null;
			object DDID = null;
			object factorOperator = null;
			object TriggerBy2 = null;
			object TriggerBy = null;
			object coefficient = null;
			object Description = null;
			object FactorType = null;
			object FactorStatus = null;
			object FactorID = null;
			object EqType = null;
			object MeasureID = null;
			object Quarter = null;
			object coefID = null;


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTS]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE Quarter in (" + Quarters + ") ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				coefID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["coefID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["coefID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Quarter = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Quarter"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["Quarter"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MeasureID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["MeasureID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object EqType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				EqType = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EqType"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["EqType"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FactorID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["FactorID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorStatus = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FactorStatus"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["FactorStatus"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorType = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FactorType"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["FactorType"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Description"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["Description"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefficient. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				coefficient = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["coefficient"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["coefficient"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["TriggerBy"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					TriggerBy = Strings.Trim(Convert.ToString(modGlobal.gv_rs.rdoColumns["TriggerBy"].Value));
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					TriggerBy = "";
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["TriggerBy2"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					TriggerBy2 = Strings.Trim(Convert.ToString(modGlobal.gv_rs.rdoColumns["TriggerBy2"].Value));
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					TriggerBy2 = "";
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["factorOperator"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object factorOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					factorOperator = Strings.Trim(Convert.ToString(modGlobal.gv_rs.rdoColumns["factorOperator"].Value));
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object factorOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					factorOperator = "";
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object factorOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefficient. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object EqType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, coefID + "," + Quarter + "," + MeasureID + "," + EqType + "," + FactorID + "," + FactorStatus + "," + FactorType + "," + Description + "," + coefficient + "," + TriggerBy + "," + TriggerBy2 + "," + factorOperator);

				modGlobal.gv_rs.MoveNext();

			}

			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTFIELDLINKS]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks WHERE CoefID IN " + " (SELECT CoefID FROM tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
			// WHERE Quarter = '" & quarter & "')"
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE Quarter in (" + Quarters + ") )";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				coefID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["coefID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["coefID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DDID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["DDID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object strtab. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strtab = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Tab"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["Tab"].Value)));

				//UPGRADE_WARNING: Couldn't resolve default property of object strtab. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, coefID + "," + DDID + "," + strtab);

				modGlobal.gv_rs.MoveNext();

			}

			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTTRIGGERS]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers WHERE COefID in " + " (SELECT CoefID FROM tbl_Setup_IndicatorRiskAdjustmentCoefficients  ";
			// WHERE Quarter = '" & quarter & "')"
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE Quarter in (" + Quarters + ")) ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object triggerID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				triggerID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["triggerID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["triggerID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				coefID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["coefID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["coefID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TriggerValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TriggerValue = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["TriggerValue"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["TriggerValue"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object strtab. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strtab = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Tab"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["Tab"].Value)));


				//UPGRADE_WARNING: Couldn't resolve default property of object strtab. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TriggerValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object triggerID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, triggerID + "," + coefID + "," + TriggerValue + "," + strtab);

				modGlobal.gv_rs.MoveNext();

			}

			modGlobal.gv_rs.Close();


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTFACTORLINKS]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks WHERE COefID in " + " (SELECT CoefID FROM tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
			// WHERE Quarter = '" & quarter & "')"
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE Quarter in (" + Quarters + " )) ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				coefID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["coefID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["coefID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FactorID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["FactorID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object factortxt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				factortxt = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["factortxt"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["factortxt"].Value)));

				//UPGRADE_WARNING: Couldn't resolve default property of object factortxt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, coefID + "," + FactorID + "," + factortxt);

				modGlobal.gv_rs.MoveNext();

			}

			modGlobal.gv_rs.Close();


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[INDICATORRISKADJUSTMENTCOEFFICIENTSMISSING]");
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE Quarter in (" + Quarters + ") ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorID = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FactorID"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["FactorID"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Method. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Method = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Method"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["Method"].Value)));
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Quarter = Strings.Trim((Information.IsDBNull(modGlobal.gv_rs.rdoColumns["Quarter"].Value) ? "" : Convert.ToString(modGlobal.gv_rs.rdoColumns["Quarter"].Value)));

				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object Method. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, FactorID + "," + Method + "," + Quarter);

				modGlobal.gv_rs.MoveNext();

			}

			modGlobal.gv_rs.Close();

		}

		public void RefreshPeriods()
		{
			//retrieve the list of periods
			modGlobal.gv_sql = "Select Quarter from tbl_Setup_IndicatorRiskAdjustmentCoefficients GROUP BY quarter order by quarter desc";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstPeriods.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				lstPeriods.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(Strings.Mid(modGlobal.gv_rs.rdoColumns["Quarter"].Value, 5, 2) + " - " + Strings.Mid(modGlobal.gv_rs.rdoColumns["Quarter"].Value, 1, 4), modGlobal.gv_rs.rdoColumns["Quarter"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			lstPeriods.SetSelected(0, true);


		}
	}
}
