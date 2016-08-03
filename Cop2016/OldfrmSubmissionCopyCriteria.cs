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
	internal partial class OldfrmSubmissionCopyCriteria : System.Windows.Forms.Form
	{

//UPGRADE_WARNING: Event cboColumns.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboColumns_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshSetList();
		}

//UPGRADE_WARNING: Event cboSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshSetDef();
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdCopy_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			int NewCritID;
			if (cboSet.SelectedIndex < 0 | cboColumns.SelectedIndex < 0 | (cboJoinOperator.SelectedIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text))) {
				RadMessageBox.Show("Define the definition of the new criteria.");
			} else {
				//copy the criteria
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_Action = "Add";
				//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NewCritID = modDBSetup.FindMaxRecID("tbl_Setup_SubmitCriteria", "SubmitCriteriaID");
				modGlobal.gv_sql = " insert into tbl_Setup_SubmitCriteria (";
				modGlobal.gv_sql = modGlobal.gv_sql + " SubmitCriteriaID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " Criteriaset ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

				modGlobal.gv_sql = modGlobal.gv_sql + " select ";
				//UPGRADE_WARNING: Couldn't resolve default property of object NewCritID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + NewCritID + ", ";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboColumns, cboColumns.SelectedIndex) + ", ";
				modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " [Value], ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "', ";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitCriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCriteriaID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmSubmissionSetupCopy.lstSummaryDef, frmSubmissionSetupCopy.lstSummaryDef.SelectedIndex);

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
               

                this.Close();
			}
		}

		private void frmSubmissionCopyCriteria_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			RefreshColumnList();
			RefreshSetList();

			modGlobal.gv_sql = "Select CriteriaTitle from tbl_setup_SubmitCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where submitcriteriaid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmSubmissionSetupCopy.lstSummaryDef, frmSubmissionSetupCopy.lstSummaryDef.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lblCopyFrom.Text = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value;

		}
		public void RefreshSetDef()
		{
			modGlobal.gv_sql = "Select JoinOperator from tbl_setup_SubmitCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["subgroupid"].Value;
			modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboSet, cboSet.SelectedIndex);

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				cboJoinOperator.Text = "";
				cboJoinOperator.Enabled = true;
			} else {
				cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				cboJoinOperator.Enabled = false;
			}
			modGlobal.gv_rs.Dispose();

		}

		public void RefreshSetList()
		{
			int SetIndex;
			cboSet.Items.Clear();

			modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_SubmitCriteria ";
			if (cboColumns.SelectedIndex < 0) {
				modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = -1";
			} else {
				modGlobal.gv_sql = modGlobal.gv_sql + " where SubGroupID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboColumns, cboColumns.SelectedIndex);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " Group by CriteriaSet ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of criteria
			//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SetIndex = 1;
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboSet.Items.Add("Set " + SetIndex);
				//UPGRADE_ISSUE: ComboBox property cboSet.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Microsoft.VisualBasic.Compatibility.VB6.Support.SetItemData(cboSet, cboSet.NewIndex, SetIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SetIndex = SetIndex + 1;
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

			//always add a new one to the list in addition to the previous ones
			//UPGRADE_WARNING: Couldn't resolve default property of object SetIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("Set " + SetIndex, SetIndex));

		}

		public void RefreshColumnList()
		{
			int thisSubGroup;
			var i = 0;

			modGlobal.gv_sql = "Select g.*, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " r.GroupRowID, r.Title as GroupRow, r.ShowOnReport as ShowRowonReport, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " c.SubGroupID, c.Title as GroupCol, c.IndicatorID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " c.AggregateFunction, c.showonreport as showcolonreport ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_SubmitGroup as g inner join tbl_Setup_SubmitGroupRow as r";
			modGlobal.gv_sql = modGlobal.gv_sql + " on g.GroupID = r.GroupID)  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_SubmitSubGroup as c ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on r.GroupRowID = c.GroupRowID ";
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_State)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " Where (g.State = '' or g.State is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " Where g.state = '" + modGlobal.gv_State + "'";
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_status)) {
				modGlobal.gv_sql = modGlobal.gv_sql + " and (g.RecordStatus = '' or g.RecordStatus is null) ";
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " and g.RecordStatus = '" + modGlobal.gv_status + "'";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " order by g.ordernumber, r.ordernumber, c.ordernumber ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			i = -1;
			cboColumns.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				i = i + 1;
				cboColumns.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["GroupName"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupRow"].Value + " / " + modGlobal.gv_rs.rdoColumns["GroupCol"].Value, modGlobal.gv_rs.rdoColumns["subgroupid"].Value));
				if (modGlobal.gv_rs.rdoColumns["subgroupid"].Value == frmSubmissionSetupCopy.rdcSubmissionFieldList.Resultset.rdoColumns["subgroupid"].Value) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object thisSubGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					thisSubGroup = i;
				}
				//LDW modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Dispose();

			//UPGRADE_WARNING: Couldn't resolve default property of object thisSubGroup. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cboColumns.SelectedIndex = thisSubGroup;


		}
	}
}
