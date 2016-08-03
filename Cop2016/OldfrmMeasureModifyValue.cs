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
	internal partial class OldfrmMeasureModifyValue : System.Windows.Forms.Form
	{
		object mcid;
		string selectedfieldtype;
		string selectedfieldname;
		object selectedcritfieldoperator;

//UPGRADE_WARNING: Event chkBlank.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void chkBlank_CheckStateChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (chkBlank.CheckState == CheckState.Checked) {

				txtTypeinValue.Text = "";
				cboDateUnit.Text = "";

			}

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			if (sstMethods0.Enabled == true) {
				if (string.IsNullOrEmpty(txtTypeinValue.Text) & chkBlank.CheckState == 0) {
					RadMessageBox.Show("Please define a value before updating the criteria");

				} else if (chkBlank.CheckState == CheckState.Checked) {

					modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " set fieldvalue = 'Null' ";
					modGlobal.gv_sql = modGlobal.gv_sql + ", dateunit = null ";
					//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				} else {
					//If (mid(selectedfieldtype, 1, 3) = "Num" Or selectedcritfieldoperator <> "") And Not IsNumeric(txtTypeinValue) Then
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedcritfieldoperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if ((Strings.Mid(selectedfieldtype, 1, 3) == "Num" | !string.IsNullOrEmpty(selectedcritfieldoperator)) & !Information.IsNumeric(txtTypeinValue.Text) & Strings.UCase(Strings.Trim(txtTypeinValue.Text)) != "UTD") {
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						RadMessageBox.Show(selectedfieldname + " is a numeric field, but the value is not a number. Please re-Specify...");
						return;
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if ((Strings.Mid(selectedfieldtype, 1, 3) == "Dat" | Strings.Mid(selectedfieldtype, 1, 3) == "Tim") & Strings.UCase(Strings.Trim(txtTypeinValue.Text)) == "UTD") {
						//this is OK
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedcritfieldoperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Strings.Mid(selectedfieldtype, 1, 3) == "Dat" & string.IsNullOrEmpty(selectedcritfieldoperator) & !Information.IsDate(txtTypeinValue.Text)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							RadMessageBox.Show(selectedfieldname + " is a date field, but the value is not a date. Please re-Specify...");
							return;
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedcritfieldoperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" & string.IsNullOrEmpty(selectedcritfieldoperator) & (Strings.Len(txtTypeinValue.Text) != 5)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							RadMessageBox.Show(selectedfieldname + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
							return;
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedcritfieldoperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" & string.IsNullOrEmpty(selectedcritfieldoperator) & ((!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 1, 1))) | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 2, 1))) | (Strings.Mid(txtTypeinValue.Text, 3, 1) != ":") | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 4, 1))) | (!Information.IsNumeric(Strings.Mid(txtTypeinValue.Text, 5, 1))))) {
							//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							RadMessageBox.Show(selectedfieldname + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
							return;
						}
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedcritfieldoperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" & string.IsNullOrEmpty(selectedcritfieldoperator) & (Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 1, 2)) > 23 | Convert.ToDouble(Strings.Mid(txtTypeinValue.Text, 4, 2)) > 59)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							RadMessageBox.Show(selectedfieldname + " is a Time field, but the value is not in the appropriate format (HH:MM military). Please re-Specify...");
							return;
						}
					}

					//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object selectedcritfieldoperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					if ((!Information.IsDBNull(selectedcritfieldoperator) & !string.IsNullOrEmpty(selectedcritfieldoperator)) & (Strings.Mid(selectedfieldtype, 1, 3) == "Tim" | Strings.Mid(selectedfieldtype, 1, 3) == "Dat")) {
						if (string.IsNullOrEmpty(cboDateUnit.Text)) {
							//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							RadMessageBox.Show(selectedfieldname + " is a Date/Time field. Please select a date unit");
							return;
						}
					} else {
						cboDateUnit.Text = "";
					}

					modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
					modGlobal.gv_sql = modGlobal.gv_sql + " set fieldvalue = '" + txtTypeinValue.Text + "' ";
					if (!string.IsNullOrEmpty(cboDateUnit.Text)) {
						modGlobal.gv_sql = modGlobal.gv_sql + ", dateunit = ";
						switch (cboDateUnit.Text) {
							case "Years":
								modGlobal.gv_sql = modGlobal.gv_sql + " 'YYYY' ";
								break;
							case "Months":
								modGlobal.gv_sql = modGlobal.gv_sql + " 'm' ";
								break;
							case "Days":
								modGlobal.gv_sql = modGlobal.gv_sql + " 'd' ";
								break;
							case "Hours":
								modGlobal.gv_sql = modGlobal.gv_sql + " 'h' ";
								break;
							case "Minutes":
								modGlobal.gv_sql = modGlobal.gv_sql + " 'n' ";
								break;
							case "Seconds":
								modGlobal.gv_sql = modGlobal.gv_sql + " 's' ";
								break;

						}
					}
					//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;
					DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

				}

			} else if (sstMethods1.Enabled == true) {

				modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set destddid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestField, cboDestField.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			} else if (sstMethods2.Enabled == true) {

				modGlobal.gv_sql = "Select thislookupid = ";
				modGlobal.gv_sql = modGlobal.gv_sql + " case when td.comparetodesc = 'Yes' ";
				modGlobal.gv_sql = modGlobal.gv_sql + " then  ml.fieldvalue ";
				modGlobal.gv_sql = modGlobal.gv_sql + " else ml.id ";
				modGlobal.gv_sql = modGlobal.gv_sql + " end ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_misclookuplist ml ";
				modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_tabledef td on td.basetableid = ml.basetableid ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where ml.lookupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set fieldvalue = '" + modGlobal.gv_rs.rdoColumns["thislookupid"].Value + "'";
				modGlobal.gv_sql = modGlobal.gv_sql + " , lookupid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupValues, cboLookupValues.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;

				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			} else if (sstMethods3.Enabled == true) {

				modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
				modGlobal.gv_sql = modGlobal.gv_sql + " set ";
				modGlobal.gv_sql = modGlobal.gv_sql + "  lookupTableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboLookupTables, cboLookupTables.SelectedIndex);
				//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;
				DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

			}

			modGlobal.UpdateVerificationCriteriaTitle(mcid);


			this.Close();
		}
		public void setMeasureCriteriaID(ref object measureCriteriaID)
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object measureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mcid = measureCriteriaID;

			SelectTab();

		}
		private void frmMeasureModifyValue_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

		}

		public void SelectTab()
		{
			object DestDDID = null;

			sstMethods0.Enabled = false;
			sstMethods1.Enabled = false;
			sstMethods2.Enabled = false;
			sstMethods3.Enabled = false;
			cboDateUnit.Enabled = false;

			modGlobal.gv_sql = "select mc.*, dd.fieldname, dd.fieldtype from tbl_Setup_MeasureCriteria mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef dd ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on mc.ddid1 = dd.ddid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where mc.MeasureCriteriaID  = " + mcid;
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedfieldtype = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldname. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedfieldname = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object selectedcritfieldoperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selectedcritfieldoperator = modGlobal.gv_rs.rdoColumns["FieldOperator"].Value;

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value) & Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value) & Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value) & Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {

				sstMethods0.Enabled = true;
				sstMethods.SelectedIndex = 0;

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			} else if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value)) {

				cboDateUnit.Enabled = true;
				sstMethods0.Enabled = true;
				sstMethods.SelectedIndex = 0;

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			} else if ((!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value) & (Information.IsDBNull(DestDDID)))) {

				RefreshFieldList();
				sstMethods1.Enabled = true;
				sstMethods.SelectedIndex = 1;

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			} else if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value)) {

				RefreshLookupList();
				sstMethods2.Enabled = true;
				sstMethods.SelectedIndex = 2;

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			} else if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value)) {

				RefreshLookupTableList();
				sstMethods3.Enabled = true;
				sstMethods.SelectedIndex = 3;

			}



		}

		public void RefreshFieldList()
		{

			modGlobal.gv_sql = "select dd.fieldtype from tbl_Setup_MeasureCriteria  mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef dd on mc.ddid1 = dd.ddid ";
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where mc.MeasureCriteriaID  = " + mcid;
			//UPGRADE_WARNING: Couldn't resolve default property of object selectedfieldtype. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and dd.fieldtype = '" + selectedfieldtype + "'";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);


			//retrieve the list of table fields

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef dd ";
			modGlobal.gv_sql = modGlobal.gv_sql + " WHERE fieldtype = '" + modGlobal.gv_rs.rdoColumns["FieldType"].Value + "'";
			modGlobal.gv_sql = modGlobal.gv_sql + " AND (ParentDDID IS NULL OR ParentDDID = DDID) ";
			modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			//Display the list of fields
			cboDestField.Items.Clear();
			while (!modGlobal.gv_rs.EOF) {
				cboDestField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
				//LDW modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Dispose();


		}

		public void RefreshLookupList()
		{
			string LookupTableID = null;


			cboLookupValues.Items.Clear();

			modGlobal.gv_sql = "Select dd.Lookuptableid from tbl_setup_DataDef dd ";
			modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureCriteria  mc ";
			modGlobal.gv_sql = modGlobal.gv_sql + " on dd.ddid = mc.ddid1 ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where dd.Lookuptableid is not null ";
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and mc.MeasureCriteriaID  = " + mcid;

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount > 0) {
				LookupTableID = modGlobal.gv_rs.rdoColumns["LookupTableID"].Value;

				modGlobal.gv_sql = "Select * from tbl_setup_misclookuplist ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where basetableid = " + LookupTableID;
				modGlobal.gv_sql = modGlobal.gv_sql + " order by sortorder ";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

				while (!modGlobal.gv_rs.EOF) {
					cboLookupValues.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem("(" + modGlobal.gv_rs.rdoColumns["Id"].Value + ") " + modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value, modGlobal.gv_rs.rdoColumns["LookupID"].Value));
					//LDW modGlobal.gv_rs.MoveNext();
				}
			}
			modGlobal.gv_rs.Dispose();

		}

		public void RefreshLookupTableList()
		{

			modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
			modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			cboLookupTables.Items.Clear();

			while (!modGlobal.gv_rs.EOF) {
				cboLookupTables.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["BaseTable"].Value, modGlobal.gv_rs.rdoColumns["basetableid"].Value));

				//LDW modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Dispose();

		}

//UPGRADE_WARNING: Event txtTypeinValue.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void txtTypeinValue_TextChanged(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(txtTypeinValue.Text)) {
				chkBlank.CheckState = System.Windows.Forms.CheckState.Unchecked;

			}

		}
	}
}
