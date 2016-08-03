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
	internal partial class OldfrmMeasureModifySecondField : System.Windows.Forms.Form
	{
		object mcid;
		object selectedfieldtype;
		object selectedfieldname;
		object selectedcritfieldoperator;

		private void chkBlank_Click()
		{
			object chkBlank = null;
			object cboDateUnit = null;
			object txtTypeinValue = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object chkBlank.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (chkBlank.Value == 1) {

				//UPGRADE_WARNING: Couldn't resolve default property of object txtTypeinValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				txtTypeinValue = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object cboDateUnit.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cboDateUnit.Text = "";

			}

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
		{


			modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " set ddid2 = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboDestField, cboDestField.SelectedIndex);
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID  = " + mcid;
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);


			modGlobal.UpdateVerificationCriteriaTitle(ref mcid);


			this.Close();
		}
		public void SetMeasureCriteriaID(ref object MeasureCriteriaID)
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object MeasureCriteriaID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object mcid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			mcid = MeasureCriteriaID;

			SelectTab();

		}
		private void frmMeasureModifySecondField_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

		}

		public void SelectTab()
		{

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
			selectedcritfieldoperator = modGlobal.gv_rs.rdoColumns["fieldoperator"].Value;


			RefreshFieldList();



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
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();


		}


		private void txtTypeinValue_Change()
		{
			object txtTypeinValue = null;
			object chkBlank = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object txtTypeinValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(txtTypeinValue)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object chkBlank.Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				chkBlank.Value = 0;

			}

		}
	}
}
