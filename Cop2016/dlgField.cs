using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Drawing;
using static COP2001.RadDropBinder;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgField : Telerik.WinControls.UI.RadForm
    {
        int ii_MeasureCriteriaID;
        string is_PreviousDataType;
        string is_CriteriaTitle;

        public dlgField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void SetMeasureCriteriaID(int MeasureCriteriaID)
        {
            ii_MeasureCriteriaID = MeasureCriteriaID;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgField_Load(object sender, EventArgs e)
        {
            try
            {
                modGlobal.gv_sql = string.Format("SELECT dd.DDID, dd.FieldName, dd.FieldType, mc.CriteriaTitle FROM " +
                    "tbl_Setup_MeasureCriteria mc, tbl_Setup_DataDef dd WHERE  dd.DDID = mc.DDID1 AND mc.MeasureCriteriaID = {0}", ii_MeasureCriteriaID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    //LDW if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DDID"].Value))
                    if (!Information.IsDBNull(myRow1.Field<string>("DDID")))
                    {
                        /*LDW txtPreviousField.Text = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
                        is_PreviousDataType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                        is_CriteriaTitle = modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value; */
                        txtPreviousField.Text = myRow1.Field<string>("FieldName");
                        is_PreviousDataType = myRow1.Field<string>("FieldType");
                        is_CriteriaTitle = myRow1.Field<string>("CriteriaTitle");

                        RefreshFields();
                        OKButton.Enabled = true;
                    }
                    else
                    {
                        //LDW RadMessageBox.Show("This criteria can not be modified");

                        DialogResult ds1 = RadMessageBox.Show(this, "This criteria can not be modified", "Criteria Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds1.ToString();
                        OKButton.Enabled = false;
                    }
                    if (Information.IsDBNull(myRow1.Field<string>("DDID")))
                    {
                        //LDW RadMessageBox.Show("This criteria can not be modified");

                        DialogResult ds2 = RadMessageBox.Show(this, "This criteria can not be modified", "Criteria Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds2.ToString();
                        OKButton.Enabled = false;
                    }
                }
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

        private void OKButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (cboField.SelectedIndex > -1)
                {
                    if (!string.IsNullOrEmpty(txtPreviousField.Text))
                    {
                        is_CriteriaTitle = Strings.Replace(is_CriteriaTitle, txtPreviousField.Text, Strings.Trim(cboField.Text));

                        modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureCriteria SET DDID1 = {0}, CriteriaTitle = '{1}'  WHERE MeasureCriteriaID = {2}",
                            Support.GetItemData(cboField, cboField.SelectedIndex), is_CriteriaTitle, ii_MeasureCriteriaID);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    else
                    {
                        //LDW RadMessageBox.Show("This can not be saved");

                        DialogResult ds3 = RadMessageBox.Show(this, "This can not be saved", "Criteria Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds3.ToString();
                    }

                    this.Close();
                }
                else
                {
                    //LDW RadMessageBox.Show("Please select a field to modify to");

                    DialogResult ds4 = RadMessageBox.Show(this, "Please select a field to modify to", "Criteria Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds4.ToString();
                }
                return;
                ////LDW ErrHandler:
                //LDW modGlobal.CheckForErrors();
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

        private void RefreshFields()
        {
            List<Item> itemscboField = new List<Item>();

            try
            {

                modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_DataDef WHERE FieldType = '{0}' AND (ParentDDID IS NULL OR ParentDDID = DDID) ORDER BY FIELDNAME", is_PreviousDataType);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboField.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    //LDW cboField.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["FieldName"].Value, modGlobal.gv_rs.rdoColumns["DDID"].Value));
                    itemscboField.Add(new Item(myRow2.Field<int>("DDID"), myRow2.Field<string>("FieldName")));

                    //cboField.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("DDID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboField.DataSource = itemscboField;
                this.cboField.DisplayMember = "Description";
                this.cboField.ValueMember = "Id";
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

    }
}
