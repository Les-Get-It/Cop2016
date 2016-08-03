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
    public partial class dlgValidationField : Telerik.WinControls.UI.RadForm
    {
        int ii_TableValidationID;
        string is_PreviousDataType;
        string is_CriteriaTitle;

        public dlgValidationField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void SetTableValidationID(int TableValidationID)
        {
            ii_TableValidationID = TableValidationID;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgValidationField_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                modGlobal.gv_sql = string.Format("select SourceDDID1, FieldName, FieldType, CriteriaTitle from tbl_setup_TableValidation, tbl_setup_DataDef" +
                    " Where tbl_setup_DataDef.DDID = tbl_setup_TableValidation.SourceDDID1 AND TableValidationID = {0}", ii_TableValidationID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_TableValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                int totalRec = modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count;
                for (int i = 0; i < totalRec; i++)
                {
                    DataRow row = modGlobal.gv_rs.Tables[sqlTableName1].Rows[i];
                    if (i != totalRec - 1)
                    {
                        if (!Information.IsDBNull(row.Field<int>("SourceDDID1")))
                        {
                            txtPreviousField.Text = row.Field<string>("FieldName");
                            is_PreviousDataType = row.Field<string>("FieldType");
                            is_CriteriaTitle = row.Field<string>("CriteriaTitle");
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
                    }
                    else
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

                        modGlobal.gv_sql = string.Format("UPDATE tbl_setup_TableValidation SET SourceDDID1 = {0}, CriteriaTitle = '{1}'  WHERE TableValidationID = {2}",
                            Support.GetItemData(cboField, cboField.SelectedIndex), is_CriteriaTitle, ii_TableValidationID);
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
            //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
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
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    itemscboField.Add(new Item(myRow1.Field<int>("DDID"), myRow1.Field<string>("FieldName")));

                    //cboField.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"), myRow1.Field<int>("DDID")).ToString());
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
