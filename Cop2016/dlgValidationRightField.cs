using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Drawing;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgValidationRightField : Telerik.WinControls.UI.RadForm
    {
        int ii_TableValidationID;
        int ii_BaseTableID;
        string is_CriteriaTitle;


        public dlgValidationRightField()
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

        private void dlgValidationRightField_Load(object sender, EventArgs e)
        {
            try
            {
                modGlobal.gv_sql = string.Format("select BaseTableID, CriteriaTitle, tbl_setup_miscLookupList.FieldValue," +
                    "tbl_setup_miscLookupList.ID from tbl_setup_TableValidation, tbl_setup_MiscLookupList  Where tbl_setup_misclookuplist.LookupID = tbl_setup_TableValidation.LookupID" +
                    "And TableValidationID = {0}", ii_TableValidationID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_TableValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    if (!Information.IsDBNull(myRow1.Field<int>("basetableid")))
                    {
                        txtPreviousField.Text = string.Format("({0}) {1}", myRow1.Field<int>("Id"), myRow1.Field<string>("FIELDVALUE"));
                        ii_BaseTableID = myRow1.Field<int>("basetableid");
                        is_CriteriaTitle = myRow1.Field<string>("CriteriaTitle");
                        RefreshFields();
                        OKButton.Enabled = true;
                    }

                    else if (Information.IsDBNull(myRow1.Field<int>("basetableid")))
                    {
                        //LDW RadMessageBox.Show("This criteria can not be modified");

                        DialogResult ds1 = RadMessageBox.Show(this, "This criteria can not be modified", "Validation Right Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds1.ToString();
                        OKButton.Enabled = false;
                    }

                    else
                    {
                        //LDW RadMessageBox.Show("This criteria can not be modified");

                        DialogResult ds2 = RadMessageBox.Show(this, "This criteria can not be modified", "Validation Right Field", MessageBoxButtons.OK, RadMessageIcon.Error);
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
                        is_CriteriaTitle = Strings.Replace(is_CriteriaTitle, Strings.Trim(txtPreviousField.Text), Strings.Trim(cboField.Text));

                        modGlobal.gv_sql = string.Format("UPDATE tbl_setup_TableValidation SET LookupID = {0}, CriteriaTitle = '{1}', Value = '{2}'  WHERE TableValidationID = {3}",
                            Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboField, cboField.SelectedIndex), is_CriteriaTitle, Strings.Trim(Strings.Mid(cboField.Text, 
                            Strings.InStr(1, cboField.Text, "(") + 1, Strings.InStr(1, cboField.Text, ")") - Strings.InStr(1, cboField.Text, "(") - 1)), ii_TableValidationID);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    else
                    {
                        //LDW RadMessageBox.Show("This can not be saved");
                        
                        DialogResult ds3 = RadMessageBox.Show(this, "This can not be saved", "Validation Right Field", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds3.ToString();
                    }
                    this.Close();
                }
                else
                {
                    //LDW RadMessageBox.Show("Please select a field to modify to");
                    
                    DialogResult ds4 = RadMessageBox.Show(this, "Please select a field to modify to.", "Validation Right Field", MessageBoxButtons.OK, RadMessageIcon.Error);
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
            //LDW //LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }

        private void RefreshFields()
        {
            List<Item> itemscboField = new List<Item>();

            try
            {
                modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MiscLookupList WHERE BaseTableID = {0} ORDER BY FieldValue", ii_BaseTableID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_Setup_MiscLookupList";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                cboField.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    itemscboField.Add(new Item(myRow2.Field<int>("LookupID"), (string.Format("({0}) {1}", myRow2.Field<int>("Id"), myRow2.Field<string>("FIELDVALUE")))));

                    //cboField.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(string.Format("({0}) {1}", myRow2.Field<int>("Id"), myRow2.Field<string>("FIELDVALUE")), myRow2.Field<int>("LookupID")).ToString());

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
