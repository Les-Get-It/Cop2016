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
	internal partial class OldfrmPatientFieldsExportFormat : System.Windows.Forms.Form
	{

		private void cmdLinkedFields_Click()
		{

		}

		private void cmdLinkToMeasure_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstMeasureList.SelectedIndex > -1) {

				modGlobal.gv_sql = "Insert into tbl_setup_CMSfieldmeasures (ddid, indicatorid, MeasureCode) ";
				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex) + ", ";
				modGlobal.gv_sql = modGlobal.gv_sql + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstMeasureList, lstMeasureList.SelectedIndex) + ", ";
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + lstMeasureList.Text + "')";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshMeasureList();

			}

		}

		private void cmdMeasureFieldDetails_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (lstFieldList.SelectedIndex > -1) {
				modGlobal.gv_sql = "update tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set CMSFieldCode =  ";
				if (string.IsNullOrEmpty(txtCMSFieldCode.Text)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtCMSFieldCode.Text + "'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + ", ";
				modGlobal.gv_sql = modGlobal.gv_sql + " JCFieldCode =  ";
				if (string.IsNullOrEmpty(txtJCFieldCode.Text)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtJCFieldCode.Text + "'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			}

			frmPatientFieldsExportLinks.ShowDialog();
		}

		private void cmdRemoveFromMeasure_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstSelectedMeasures.SelectedIndex > -1) {

				modGlobal.gv_sql = "delete tbl_setup_CMSfieldmeasures ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
				modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureCode = '" + lstSelectedMeasures.Text + "'";
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
				RefreshMeasureList();

			}

		}


		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (lstFieldList.SelectedIndex > -1) {
				modGlobal.gv_sql = "update tbl_setup_DataDef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set CMSFieldCode =  ";
				if (string.IsNullOrEmpty(txtCMSFieldCode.Text)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtCMSFieldCode.Text + "'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + ", ";
				modGlobal.gv_sql = modGlobal.gv_sql + " JCFieldCode =  ";
				if (string.IsNullOrEmpty(txtJCFieldCode.Text)) {
					modGlobal.gv_sql = modGlobal.gv_sql + " null  ";
				} else {
					modGlobal.gv_sql = modGlobal.gv_sql + "'" + txtJCFieldCode.Text + "'";
				}
				modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
			}

		}

		private void frmPatientFieldsExportFormat_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			txtJCFieldCode.Enabled = false;
			txtCMSFieldCode.Enabled = false;
			lstMeasureList.Enabled = false;
			lstSelectedMeasures.Enabled = false;
			cmdLinkToMeasure.Enabled = false;
			cmdRemoveFromMeasure.Enabled = false;

			//retrieve the list of table fields
			modGlobal.gv_sql = "Select * from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select basetableid from tbl_setup_tableDef where BaseTable = 'PATIENT' )";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

			rdcFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcFieldList.CtlRefresh();

			lstFieldList.Items.Clear();
			while (!rdcFieldList.Resultset.EOF) {
				lstFieldList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcFieldList.Resultset.rdoColumns["FieldName"].Value, rdcFieldList.Resultset.rdoColumns["DDID"].Value));
				rdcFieldList.Resultset.MoveNext();
			}



		}


		public void RefreshMeasureList()
		{

			lstMeasureList.Items.Clear();

			//get the list of jccodes
			modGlobal.gv_sql = "Select indicatorid, jccode from tbl_setup_Indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where JCCode is not null ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and JCCode not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCode from tbl_setup_CMSfieldmeasures ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex) + ")";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by JCCode ";
			rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcTemp.CtlRefresh();
			while (!rdcTemp.Resultset.EOF) {
				lstMeasureList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcTemp.Resultset.rdoColumns["JCCode"].Value, rdcTemp.Resultset.rdoColumns["IndicatorID"].Value));
				rdcTemp.Resultset.MoveNext();
			}
			rdcTemp.Resultset.Close();

			//add the list of CMScodes
			modGlobal.gv_sql = "Select indicatorid, CMScode from tbl_setup_Indicator ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where CMSCode is not null and IsNull(JCCode,'') <> CMSCode ";
			modGlobal.gv_sql = modGlobal.gv_sql + " and CMSCode not in ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureCode from tbl_setup_CMSfieldmeasures ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex) + ")";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by CMSCode ";
			rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcTemp.CtlRefresh();
			while (!rdcTemp.Resultset.EOF) {
				lstMeasureList.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcTemp.Resultset.rdoColumns["CMSCode"].Value, rdcTemp.Resultset.rdoColumns["IndicatorID"].Value));
				rdcTemp.Resultset.MoveNext();
			}
			rdcTemp.Resultset.Close();

			lstSelectedMeasures.Items.Clear();

			modGlobal.gv_sql = "Select ddid, MeasureCode from tbl_setup_CMSfieldmeasures ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
			modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureCode ";
			rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			rdcTemp.CtlRefresh();
			while (!rdcTemp.Resultset.EOF) {
				lstSelectedMeasures.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(rdcTemp.Resultset.rdoColumns["measurecode"].Value, rdcTemp.Resultset.rdoColumns["DDID"].Value));
				rdcTemp.Resultset.MoveNext();
			}
			rdcTemp.Resultset.Close();


		}

//UPGRADE_WARNING: Event lstFieldList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void lstFieldList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			txtJCFieldCode.Text = "";
			txtCMSFieldCode.Text = "";

			if (lstFieldList.SelectedIndex > -1) {

				txtJCFieldCode.Enabled = true;
				txtCMSFieldCode.Enabled = true;
				lstMeasureList.Enabled = true;
				lstSelectedMeasures.Enabled = true;
				cmdLinkToMeasure.Enabled = true;
				cmdRemoveFromMeasure.Enabled = true;

				modGlobal.gv_sql = "Select * from tbl_setup_datadef ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(lstFieldList, lstFieldList.SelectedIndex);
				rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				rdcTemp.CtlRefresh();
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(rdcTemp.Resultset.rdoColumns["JCFieldCode"].Value)) {
					txtJCFieldCode.Text = rdcTemp.Resultset.rdoColumns["JCFieldCode"].Value;
				}

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(rdcTemp.Resultset.rdoColumns["cmsfieldcode"].Value)) {
					txtCMSFieldCode.Text = rdcTemp.Resultset.rdoColumns["cmsfieldcode"].Value;
				}
				rdcTemp.Resultset.Close();
			}

			RefreshMeasureList();



		}
	}
}
