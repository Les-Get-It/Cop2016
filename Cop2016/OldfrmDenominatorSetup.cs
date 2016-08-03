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
	internal partial class OldfrmDenominatorSetup : System.Windows.Forms.Form
	{

		public int openning;



		public void RefreshSummaryFields()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			System.Data.DataSet  rsSelected = null;

			if (My.MyProject.Forms.frmIndicatorReportSetup.lstHeading.SelectedIndex == -1) {
				goto DoneRefreshSummaryFields;
			}

			//
			//retrieve the list of Indicators
			//
			modGlobal.gv_sql = "Select * from vuSummaryFieldNames order by fieldname";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//
			//
			//
			modGlobal.gv_sql = "select * from vuDenominatorSummaryFields where SubGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmIndicatorReportSetup.lstHeading, My.MyProject.Forms.frmIndicatorReportSetup.lstHeading.SelectedIndex);
			rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//
			//fill the list box
			//
			lstSummaryFields.Items.Clear();
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

				lstSummaryFields.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value + " (" + modGlobal.gv_rs.rdoColumns["SubGroupID"].Value + ")", modGlobal.gv_rs.rdoColumns["SubGroupID"].Value));
				if (rsSelected.RowCount > 0) {
					rsSelected.MoveFirst();
					while (!rsSelected.EOF) {
						if (Strings.Trim(rsSelected.rdoColumns["FieldName"].Value) == Strings.Trim(modGlobal.gv_rs.rdoColumns["FieldName"].Value)) {
							//UPGRADE_ISSUE: ListBox property lstSummaryFields.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
							lstSummaryFields.SetItemChecked(lstSummaryFields.NewIndex, true);
						}
						rsSelected.MoveNext();
					}
				}
				modGlobal.gv_rs.MoveNext();
			}

			rsSelected.Close();
		// 	DoneRefreshSummaryFields:


		}

		public void RefreshUtilizationFields()
		{
			var LIndex = 0;
			var Table_ListIndex = 0;
			System.Data.DataSet  rsSelected = null;

			//
			//retrieve the list of Indicators
			//
			modGlobal.gv_sql = "Select * from tbl_setup_DataDef where BaseTableID = 2 ORDER BY FieldName";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//
			//
			//
			modGlobal.gv_sql = "select * from vuDenominatorUtilizationStat where SubGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmIndicatorReportSetup.lstHeading, My.MyProject.Forms.frmIndicatorReportSetup.lstHeading.SelectedIndex) + " order by fieldName";
			rsSelected = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//
			//fill the list box
			//
			lstUtilizationFields.Items.Clear();
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

				lstUtilizationFields.Items.Add(modGlobal.gv_rs.rdoColumns["FieldName"].Value + " (" + modGlobal.gv_rs.rdoColumns["DDID"].Value + ")");

				//UPGRADE_ISSUE: ListBox property lstUtilizationFields.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(lstUtilizationFields, lstUtilizationFields.NewIndex, modGlobal.gv_rs.rdoColumns["DDID"].Value);
				if (rsSelected.RowCount > 0) {
					rsSelected.MoveFirst();
					while (!rsSelected.EOF) {
						if (Strings.Trim(rsSelected.rdoColumns["FieldName"].Value) == Strings.Trim(modGlobal.gv_rs.rdoColumns["FieldName"].Value)) {
							//UPGRADE_ISSUE: ListBox property lstUtilizationFields.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
							lstUtilizationFields.SetItemChecked(lstUtilizationFields.NewIndex, true);
						}
						rsSelected.MoveNext();
					}
				}
				modGlobal.gv_rs.MoveNext();
			}

			rsSelected.Close();
		//	RefreshUtilizationFieldsDone


		}

		private void frmDenominatorSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			//
			//
			openning = 1;
			//
			//
			//
			RefreshSummaryFields();
			//
			//
			//
			RefreshUtilizationFields();
			//
			//
			//
			//RefreshNumberCasesFields

			openning = 0;

		}


		private void frmDenominatorSetup_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			//
			//
			//
			My.MyProject.Forms.frmIndicatorReportSetup.refreshPage();

		}

//UPGRADE_WARNING: ListBox event lstSummaryFields.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		private void lstSummaryFields_ItemCheck(System.Object eventSender, System.Windows.Forms.ItemCheckEventArgs eventArgs)
		{
			object sid = null;
			int fid = 0;

			if (openning == 0) {
				fid = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSummaryFields, lstSummaryFields.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object sid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sid = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmIndicatorReportSetup.lstHeading, My.MyProject.Forms.frmIndicatorReportSetup.lstHeading.SelectedIndex);

				if (lstSummaryFields.GetItemChecked(eventArgs.Index) == true) {
					modGlobal.gv_sql = "INSERT into tbl_Setup_IndicatorReportDenominators (SubGroupID, tName, FieldID, OpChar)";
					//UPGRADE_WARNING: Couldn't resolve default property of object sid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " values (" + sid + ",'Summary'," + fid + " , 1)";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				} else {
					modGlobal.gv_sql = "delete from tbl_Setup_IndicatorReportDenominators ";
					//UPGRADE_WARNING: Couldn't resolve default property of object sid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + sid + " and  tName = 'Summary' and FieldID =" + fid;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}
			}

		}


//UPGRADE_WARNING: ListBox event lstUtilizationFields.ItemCheck has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		private void lstUtilizationFields_ItemCheck(System.Object eventSender, System.Windows.Forms.ItemCheckEventArgs eventArgs)
		{
			object sid = null;
			int fid = 0;

			if (openning == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object sid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sid = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(My.MyProject.Forms.frmIndicatorReportSetup.lstHeading, My.MyProject.Forms.frmIndicatorReportSetup.lstHeading.SelectedIndex);
				fid = Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstUtilizationFields, lstUtilizationFields.SelectedIndex);
				if (lstUtilizationFields.GetItemChecked(eventArgs.Index) == true) {
					modGlobal.gv_sql = "INSERT into tbl_Setup_IndicatorReportDenominators (SubGroupID, tName, FieldID, OpChar)";
					//UPGRADE_WARNING: Couldn't resolve default property of object sid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " values (" + sid + ",'Utilization'," + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstUtilizationFields, lstUtilizationFields.SelectedIndex) + " , 1)";
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				} else {
					modGlobal.gv_sql = "delete from tbl_Setup_IndicatorReportDenominators ";
					//UPGRADE_WARNING: Couldn't resolve default property of object sid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + sid + " and  tName = 'Utilization' and FieldID =" + fid;
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}
			}

		}
	}
}
