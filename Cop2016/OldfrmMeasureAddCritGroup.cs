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
	internal partial class OldfrmMeasureAddCritGroup : System.Windows.Forms.Form
	{

		private int ii_MeasureCriteriaID;
		private int ii_MeasureStepID;

		public void SetDescription(ref string Description)
		{
			lblColName.Text = lblColName.Text + " " + Description;
		}

		public void SetMeasureCriteriaID(ref object MeasureCriteriaID)
		{
			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ii_MeasureCriteriaID = MeasureCriteriaID;
			ii_MeasureStepID = 0;
			PopulateSetList();
			PopulateGroupList();
		}

		private void PopulateSetList()
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			lstSetList.Items.Clear();

			if (ii_MeasureStepID == 0) {
				setMeasureStepID();
			}

			modGlobal.gv_sql = "SELECT MeasureCriteriaSet, MeasureCriteriaSetID FROM tbl_Setup_MeasureCriteriaSet " + " WHERE MeasureStepID = " + ii_MeasureStepID + " ORDER BY MeasureCriteriaSet";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				lstSetList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value, modGlobal.gv_rs.rdoColumns["measurecriteriasetid"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();

			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}

		private void setMeasureStepID()
		{

			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "SELECT ms.MeasureStepID  FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " + " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " + ii_MeasureCriteriaID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.EOF) {
				RadMessageBox.Show("Could not determine step id from selected criteria", MessageBoxButtons.Critical, "Fatal Error");
				this.Close();
			} else {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				ii_MeasureStepID = (object.ReferenceEquals(modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value, System.DBNull.Value) ? 0 : modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value);
			}
			modGlobal.gv_rs.Dispose();
			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

//UPGRADE_WARNING: Event cboGroup.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboGroup_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			modGlobal.gv_sql = "SELECT msg.*, mcs.MeasureCriteriaSet " + " FROM tbl_Setup_MeasureStepGroup msg, tbl_Setup_MeasureCriteriaSet mcs " + " WHERE msg.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID " + " AND msg.MeasureStepID = " + ii_MeasureStepID + " AND msg.MeasureStepGroup = " + Convert.ToInt32(cboGroup.Text);

			lstSelectedSetList.Items.Clear();

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.EOF) {
				modGlobal.gv_rs.Dispose();

				modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_MeasureStepGroup " + " WHERE MeasureStepID = " + ii_MeasureStepID;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (!modGlobal.gv_rs.EOF) {
					cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
				}

			} else {
				while (!modGlobal.gv_rs.EOF) {
					cboJoinOperator.Text = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
					lstSelectedSetList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["MeasureCriteriaSet"].Value, modGlobal.gv_rs.rdoColumns["measurecriteriasetid"].Value));
					//LDW modGlobal.gv_rs.MoveNext();
				}
			}

			modGlobal.gv_rs.Dispose();

			PopulateSetList();
			RemoveSelected();

			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void RemoveSelected()
		{
			int li_cnt = 0;

			modGlobal.gv_sql = "SELECT DISTINCT MeasureCriteriaSetID FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				for (li_cnt = 0; li_cnt <= lstSetList.Items.Count - 1; li_cnt++) {
					if (Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSetList, li_cnt) == Convert.ToInt32(modGlobal.gv_rs.rdoColumns["measurecriteriasetid"].Value)) {
						lstSetList.Items.RemoveAt((li_cnt));
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				//LDW modGlobal.gv_rs.MoveNext();
			}

		}

		private void cmdAdd_Click()
		{
			SaveChanges();
		}

		private void cmdAddSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object li_cnt = null;
			int li_list = 0;

			short counter = 0;
			if (lstSetList.SelectedItems.Count > 0) {

				li_list = lstSetList.Items.Count - 1;

				counter = li_list;
				for (li_cnt = counter; li_cnt >= 0; li_cnt += -1) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (li_cnt > li_list) {
						break; // TODO: might not be correct. Was : Exit For
					}

					if (lstSetList.GetSelected(li_cnt) == true) {
						lstSelectedSetList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstSetList, li_cnt), Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSetList, li_cnt)));

						//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstSetList.Items.RemoveAt(li_cnt);
						li_list = lstSetList.Items.Count - 1;
					}
				}

				SaveChanges();
			} else {
				RadMessageBox.Show("Please select a set");
			}

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void PopulateGroupList()
		{
			int ll_LastGroup = 0;
			 // ERROR: Not supported in C#: OnErrorStatement


			cboGroup.Items.Clear();

			modGlobal.gv_sql = "SELECT DISTINCT MeasureStepGroup FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID + " ORDER BY MeasureStepGroup";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (!modGlobal.gv_rs.EOF) {


				while (!modGlobal.gv_rs.EOF) {
					ll_LastGroup = modGlobal.gv_rs.rdoColumns["MeasureStepGroup"].Value;
					cboGroup.Items.Add(Convert.ToString(ll_LastGroup));
					//LDW modGlobal.gv_rs.MoveNext();
				}
			}
			modGlobal.gv_rs.Dispose();

			cboGroup.Items.Add(Convert.ToString(ll_LastGroup + 1));

			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}

		private void cmdRemoveSet_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object li_cnt = null;
			int li_list = 0;

			short counter = 0;
			if (lstSelectedSetList.SelectedItems.Count > 0) {
				li_list = lstSelectedSetList.Items.Count - 1;

				counter = li_list;
				for (li_cnt = counter; li_cnt >= 0; li_cnt += -1) {
					//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (li_cnt > li_list) {
						break; // TODO: might not be correct. Was : Exit For
					}

					if (lstSelectedSetList.GetSelected(li_cnt) == true) {

						lstSetList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemString(lstSelectedSetList, li_cnt), Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedSetList, li_cnt)));
						//UPGRADE_WARNING: Couldn't resolve default property of object li_cnt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						lstSelectedSetList.Items.RemoveAt(li_cnt);

						li_list = lstSelectedSetList.Items.Count - 1;
					}
				}

				SaveChanges();
			} else {
				RadMessageBox.Show("Please select a field");
			}

		}

		private void SaveChanges()
		{
			int li_group = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (string.IsNullOrEmpty(Strings.Trim(cboGroup.Text))) {
				RadMessageBox.Show("Please select a group to associate with this criteria");
				return;
			}
			li_group = Convert.ToInt32(cboGroup.Text);

			if (lstSelectedSetList.Items.Count == 0) {
				if (RadMessageBox.Show("Are you sure you want to remove this group?", MessageBoxButtons.OkCancel, "Confirm Delete") == DialogResult.Ok) {
					modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID + " AND MeasureStepGroup > " + li_group;
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (!modGlobal.gv_rs.EOF) {
						RadMessageBox.Show("You must delete groups after this group first.", MessageBoxButtons.Critical, "Remove Other Groups First");
						return;
					}

					//delete the grouping
					modGlobal.gv_cn.Execute("DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID + " AND MeasureStepGroup = " + li_group);

					goto Populate;
				} else {
					return;
				}
			}

			if (string.IsNullOrEmpty(Strings.Trim(cboJoinOperator.Text))) {
				RadMessageBox.Show("Please select the Join Type; the option that defines how to add this group to the exisiting ones.");
				return;
			}

			int li_cnt = 0;

			modGlobal.gv_cn.Execute("DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID + " AND MeasureStepGroup = " + li_group);

			for (li_cnt = 0; li_cnt <= lstSelectedSetList.Items.Count - 1; li_cnt++) {
				//delete then insert in case any were removed from the selected list

				modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID;
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
				modGlobal.gv_rs.AddNew();

				modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value = ii_MeasureStepID;
				modGlobal.gv_rs.rdoColumns["measurecriteriasetid"].Value = Convert.ToInt32(Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstSelectedSetList, li_cnt));
				modGlobal.gv_rs.rdoColumns["MeasureStepGroup"].Value = li_group;
				modGlobal.gv_rs.rdoColumns["JoinOperator"].Value = cboJoinOperator.Text;

				modGlobal.gv_rs.Update();

			}

			modGlobal.gv_rs.Dispose();
			Populate:

			PopulateGroupList();

			cboGroup.SelectedIndex = li_group - 1;
			return;
			ErrHandler:

			modGlobal.CheckForErrors();

		}
	}
}
