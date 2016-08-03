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
	internal partial class OldfrmIndicatorReportSetup : System.Windows.Forms.Form
	{

		private bool refreshingSection;



//UPGRADE_NOTE: dir was upgraded to dir_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		private void moveHeading(ref int dir_Renamed)
		{
			object ps = null;
			string SQL = null;

			//
			//
			//
			SQL = "{ ? = call swapIncludePositions(?,?,?) }";
			ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
			//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps(0).Direction = RDO.DirectionConstants.rdParamReturnValue;
			//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps(1).Direction = RDO.DirectionConstants.rdParamInput;
			//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps(2).Direction = RDO.DirectionConstants.rdParamInput;
			//UPGRADE_WARNING: Couldn't resolve default property of object ps().Direction. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps(3).Direction = RDO.DirectionConstants.rdParamInput;
			//
			// set up the parameters to be passed
			//
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.rdoParameters. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.rdoParameters(1) = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.rdoParameters. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.rdoParameters(2) = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.rdoParameters. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.rdoParameters(3) = dir_Renamed;
			//
			//
			//
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Execute();
			//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ps.Close();
			//
			//
			//
			RefreshSections();
			RefreshDenominatorGrid();

		}
		private void updatetReportIncludes()
		{
			object ps = null;
			string SQL = null;


			if (lstHeading.SelectedIndex > -1) {
				//
				// delete them first, keeps out dups...
				//
				SQL = "delete tbl_Setup_IndicatorReportIncludes where indicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + " and subgroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
				ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.Execute();
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.Close();
				//
				// add it back if necessary....
				//
				if (lstHeading.GetItemChecked(lstHeading.SelectedIndex) == true) {
					SQL = "insert into tbl_Setup_IndicatorReportIncludes (indicatorID, subgroupID) select " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + ", " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
					ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
					//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ps.Execute();
					//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ps.Close();

					SQL = "update tbl_Setup_IndicatorReportIncludes set sortorder = includeID where sortorder is null";
					ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
					//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ps.Execute();
					//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ps.Close();
				}
			}

		}


		private void RefreshNumeratorFields()
		{
			object cmbNumerator = null;
			//
			// retrieve the list of Indicators
			//
			modGlobal.gv_sql = "Select * from vuNumeratorFields where IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + " order by sortorder";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by title ";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object cmbNumerator.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cmbNumerator.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cmbNumerator.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Title"].Value + "(" + modGlobal.gv_rs.rdoColumns["SubGroupID"].Value + ")", modGlobal.gv_rs.rdoColumns["SubGroupID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}

//UPGRADE_WARNING: Event cmbIndicators.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cmbIndicators_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			// when selected, find the new headings...
			//
			RefreshSections();


		}



//Private Sub cmdAddReportSection_Click()
//    '
//    '  prompt for new heading
//    '
//    newHeading = InputBox("Enter Name Of Report Section")
//    If newHeading <> "" Then
//        '
//        ' make sure that this hasn't been used for this indicator
//        '
//        gv_sql = "Select * from tbl_Setup_IndicatorReportNumerators where IndicatorID = " & cmbIndicators.ItemData(cmbIndicators.ListIndex) & " and HeadingText = '" & newHeading & "'"
//        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
//        '
//        ' if new, add it to the list
//        '
//        If gv_rs.RowCount = 0 Then
//            gv_sql = "INSERT into tbl_Setup_IndicatorReportNumerators (IndicatorID, HeadingText)"
//            gv_sql = gv_sql & " values (" & cmbIndicators.ItemData(cmbIndicators.ListIndex) & ",'" & newHeading & "')"
//            gv_cn.Execute gv_sql
//            RefreshSections
//        Else
//            MsgBox "Heading Already Exists, Please Choose Another.", vbCritical, "Detail Error"
//        End If
//    End If
//
//End Sub
//
//
//Private Sub cmdRemoveReportSection_Click()
//    '
//    '
//    '
//    If MsgBox("Delete " & Trim(lstHeading.Text) & " from Report?", vbOKCancel, "Verify Removal") = vbOK Then
//            ' delete the numerator fields...
//            gv_sql = "delete from tbl_Setup_IndicatorReportNumerators where NumeratorID = " & lstHeading.ItemData(lstHeading.ListIndex)
//            gv_cn.Execute gv_sql
//            RefreshSections
//    End If
//End Sub





		private void cmdReportUpdateDenominatorField_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			//
			//
			frmDenominatorSetup.Show();

		}

		private void Command1_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			//
			//
			moveHeading(ref 1);

		}

		private void Command2_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			//
			//
			moveHeading(ref -1);

		}

		private void dbgDenominatorFields_DblClick(System.Object eventSender, System.EventArgs eventArgs)
		{
			object ps = null;
			string SQL = null;
			//
			//
			//
			if (rdcDenominatorFields.Resultset.RowCount > 0) {
				if (Interaction.MsgBox("Change Summary Operation?", MsgBoxStyle.YesNo, "Operation Update") == MsgBoxResult.Yes) {
					if (rdcDenominatorFields.Resultset.rdoColumns["OpChar"].Value == 1) {
						SQL = "update tbl_Setup_IndicatorReportDenominators set opchar = -1 where denomfieldID = " + rdcDenominatorFields.Resultset.rdoColumns["DenomFieldID"].Value;
					} else {
						SQL = "update tbl_Setup_IndicatorReportDenominators set opchar = 1 where denomfieldID = " + rdcDenominatorFields.Resultset.rdoColumns["DenomFieldID"].Value;
					}
					//
					//  run the update...
					//
					ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
					//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ps.Execute();
					//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ps.Close();
					//
					//  now update the display...
					//
					RefreshDenominatorGrid();
				}
			}

		}

		private void frmIndicatorReportSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));
			//
			//
			//
			RefreshIndicator();

		}

		public void refreshPage()
		{
			//
			//
			//
			RefreshDenominatorGrid();

		}

		public void RefreshDenominatorGrid()
		{
			object SubGroupID = null;
			//
			//
			//

			if (lstHeading.SelectedIndex > -1) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHeading, lstHeading.SelectedIndex);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SubGroupID = -1;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object SubGroupID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "select * from vuDenominatorUtilizationStat where SubGroupID =  " + SubGroupID + " union select * from vuDenominatorSummaryFields where SubGroupID =  " + SubGroupID;

			rdcDenominatorFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcDenominatorFields.CtlRefresh();

			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			dbgDenominatorFields.CtlRefresh();


		}


		public void RefreshSections()
		{
			int i = 0;
			//
			//
			//
			refreshingSection = true;
			//
			// retrieve the list of Grouped Fields
			//
			modGlobal.gv_sql = "Select * from vuNumeratorFields where IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex) + " order by sortOrder";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//
			// fill the list box
			//
			lstHeading.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				lstHeading.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Title"].Value + "  " + modGlobal.gv_rs.rdoColumns["SortOrder"].Value, modGlobal.gv_rs.rdoColumns["SubGroupID"].Value));
				modGlobal.gv_rs.MoveNext();
			}
			//
			// check the ones that are selected...
			//
			modGlobal.gv_sql = "Select * from tbl_Setup_IndicatorReportIncludes where IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cmbIndicators, cmbIndicators.SelectedIndex);
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//
			// fill the list box
			//
			if (!modGlobal.gv_rs.EOF)
            {
				for (i = 0; i <= lstHeading.Items.Count - 1; i++)
                {
					modGlobal.gv_rs.MoveFirst();
					while (!modGlobal.gv_rs.EOF)
                    {
						if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstHeading, i) == modGlobal.gv_rs.rdoColumns["SubGroupID"].Value)
                        {
							lstHeading.SetItemChecked(i, true);
						}
						modGlobal.gv_rs.MoveNext();
					}
				}
			}
			//
			//
			//

			lstHeading_SelectedIndexChanged(lstHeading, new System.EventArgs());

			refreshingSection = false;

		}

		public void RefreshIndicator()
		{

			//retrieve the list of Indicators
			modGlobal.gv_sql = "Select * from tbl_setup_Indicator";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " Where State = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cmbIndicators.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cmbIndicators.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

		}

//UPGRADE_WARNING: Event lstHeading.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstHeading_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			//
			//
			RefreshDenominatorGrid();

			//
			//
			//
			if (lstHeading.SelectedIndex == -1) {
				cmdReportUpdateDenominatorField.Enabled = false;
				dbgDenominatorFields.Enabled = false;
			} else {
				cmdReportUpdateDenominatorField.Enabled = true;
				dbgDenominatorFields.Enabled = true;
			}

		}

//UPGRADE_WARNING: ListBox event lstHeading.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		private void lstHeading_ItemCheck(System.Object eventSender, System.Windows.Forms.ItemCheckEventArgs eventArgs)
		{
			//
			//
			//
			if (refreshingSection == false) {
				updatetReportIncludes();
			}

		}
	}
}
