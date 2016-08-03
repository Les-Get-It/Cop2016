using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;

namespace COP2001
{
    public partial class frmMeasureModifySecondField : Telerik.WinControls.UI.RadForm
    {

        int mcid = 0;
        string selectedfieldtype;
        string selectedfieldname;
        string selectedcritfieldoperator;


        public frmMeasureModifySecondField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                modGlobal.gv_sql = "update tbl_Setup_MeasureCriteria ";
                modGlobal.gv_sql = string.Format("{0} set ddid2 = {1}", modGlobal.gv_sql, Support.GetItemData(cboDestField, cboDestField.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.UpdateVerificationCriteriaTitle(mcid);


                this.Close();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void SetMeasureCriteriaID(int MeasureCriteriaID)
        {
            mcid = MeasureCriteriaID;
            try
            {
                SelectTab();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void SelectTab()
        {
            try
            {
                modGlobal.gv_sql = "select mc.*, dd.fieldname, dd.fieldtype from tbl_Setup_MeasureCriteria mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mc.ddid1 = dd.ddid ";
                modGlobal.gv_sql = string.Format("{0} where mc.MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                selectedfieldtype = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["FieldType"].ToString();
                selectedfieldname = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["FieldName"].ToString();
                selectedcritfieldoperator = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["fieldoperator"].ToString();


                RefreshFieldList();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        public void RefreshFieldList()
        {
            try
            {
                modGlobal.gv_sql = "select dd.fieldtype from tbl_Setup_MeasureCriteria  mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef dd on mc.ddid1 = dd.ddid ";
                modGlobal.gv_sql = string.Format("{0} where mc.MeasureCriteriaID  = {1}", modGlobal.gv_sql, mcid);
                modGlobal.gv_sql = string.Format("{0} and dd.fieldtype = '{1}'", modGlobal.gv_sql, selectedfieldtype);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);


                //retrieve the list of table fields

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_DataDef dd ";
                modGlobal.gv_sql = string.Format("{0} WHERE fieldtype = '{1}'", modGlobal.gv_sql, modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["FieldType"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " AND (ParentDDID IS NULL OR ParentDDID = DDID) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by dd.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                //Display the list of fields
                cboDestField.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    cboDestField.Items.Add(new ListBoxItem(myRow3.Field<string>("FieldName"), myRow3.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Oops...Something went wrong... ";

                // Create an EventLog instance and assign its source.
                EventLog appLog = new EventLog();
                appLog.Source = "CopSetup";

                appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                    ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1002);

                RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
            }
        }

        private void frmMeasureModifySecondField_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        /*LDW Not used
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

         */
    }
}
