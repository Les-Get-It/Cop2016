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
	internal partial class OldfrmImportMeasureSetFile : System.Windows.Forms.Form
	{
		private string is_StartDatePart;
		private string is_EndDatePart;

//UPGRADE_WARNING: Event cboMeasureSet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cboMeasureSet_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			RefreshIndicatorList();
		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdProcess_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			pgStatus.Value = 0;

			if (string.IsNullOrEmpty(lstYear.Text) | string.IsNullOrEmpty(cboMeasureSet.Text)) {
				Interaction.MsgBox("Please choose the Measure or Year to Import", MsgBoxStyle.Critical, "Required Elements not Selected");
			} else {
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				//MsgBox "In Progress"
				modImportForCoreMeasVerify.ImportMeasureRecs(ref Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex), Convert.ToDateTime(is_StartDatePart + lstYear.Text), Convert.ToDateTime(is_EndDatePart + lstYear.Text), "Q", chkNotImport.CheckState);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

		}

		private void frmImportMeasureSetFile_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			var i = 0;
			int yr = 0;

			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

			is_StartDatePart = "1/1/";
			is_EndDatePart = "3/31/";

			//Adds 35 years to base year which is 1990
			yr = 1990;
			lstYear.Items.Clear();
			for (i = 1; i <= 36; i++) {
				//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (i != 36) {
					lstYear.Items.Add((Convert.ToString(yr)));
					yr = yr + 1;
				}
			}

			lstYear.Text = Convert.ToString(DateAndTime.Year(DateAndTime.Now));

			RefreshMeasureSet();
		}

		private void opt1st_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			lblMonths.Text = "January, February, March";
			is_StartDatePart = "1/1/";
			is_EndDatePart = "3/31/";
		}

		private void opt2nd_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			lblMonths.Text = "April, May, June";
			is_StartDatePart = "4/1/";
			is_EndDatePart = "6/30/";
		}

		private void opt3rd_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			lblMonths.Text = "July, August, September";
			is_StartDatePart = "7/1/";
			is_EndDatePart = "9/30/";
		}

		private void opt4th_Enter(System.Object eventSender, System.EventArgs eventArgs)
		{
			lblMonths.Text = "October, November, December";
			is_StartDatePart = "10/1/";
			is_EndDatePart = "12/31/";
		}

		private void RefreshMeasureSet()
		{
			object setdesc = null;
			modGlobal.gv_sql = "Select * from tbl_setup_measureset ";
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
			modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureSetDesc ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			cboMeasureSet.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["EffDate"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object setdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					setdesc = modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value;
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object setdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					setdesc = modGlobal.gv_rs.rdoColumns["MeasureSetDesc"].Value + " (" + modGlobal.gv_rs.rdoColumns["EffDate"].Value + ")";
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object setdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboMeasureSet.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(setdesc, modGlobal.gv_rs.rdoColumns["MeasureSetID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();
		}

		private void RefreshIndicatorList()
		{

			if (cboMeasureSet.SelectedIndex == -1) {
				Interaction.MsgBox("Invalid Measure Set");
				return;
			}

			modGlobal.gv_sql = "Select map.IndicatorID, Description from tbl_setup_MeasureSetMapMeas map, tbl_Setup_indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE map.IndicatorID = tbl_Setup_indicator.IndicatorID AND MeasureSetID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			lstIndicators.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				lstIndicators.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();
		}
	}
}
