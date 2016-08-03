using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgCreateCat : Telerik.WinControls.UI.RadForm
    {
        string is_CatID;

        public void Setii_CatID(string val_Renamed)
        {
            is_CatID = val_Renamed;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public dlgCreateCat()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void dlgCreateCat_Load(object sender, EventArgs e)
        {
            try
            {
                if (Information.IsNumeric(is_CatID))
                {
                    modGlobal.gv_sql = "SELECT * FROM tbl_MEASURE_CAT WHERE MEASURE_CATID = " + is_CatID;
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_MEASURE_CAT";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                    //LDW txtCatID.Text = modGlobal.gv_rs.rdoColumns["CAT"].Value;
                    txtCatID.Text = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["CAT"].ToString();
                    //LDW txtCatDesc.Text = modGlobal.gv_rs.rdoColumns["CAT_DESC"].Value;
                    txtCatDesc.Text = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["CAT_DESC"].ToString();
                    //LDW cboType.Text = modGlobal.gv_rs.rdoColumns["CAT_TYPE"].Value;
                    cboType.Text = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["CAT_TYPE"].ToString();
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
                if (!string.IsNullOrEmpty(cboType.Text) & !string.IsNullOrEmpty(txtCatID.Text) & !string.IsNullOrEmpty(txtCatDesc.Text))
                {
                    if (Information.IsNumeric(is_CatID))
                    {
                        modGlobal.gv_sql = string.Format("UPDATE tbl_MEASURE_CAT SET CAT = '{0}', CAT_DESC = '{1}', CAT_TYPE = '{2}' WHERE MEASURE_CATID = {3}",
                            txtCatID.Text, txtCatDesc.Text, cboType.Text, is_CatID);
                    }
                    else
                    {
                        //table has unique constraint setup on CAT field so duplicates will not be allowed
                        modGlobal.gv_sql = string.Format("INSERT INTO tbl_MEASURE_CAT (CAT, CAT_DESC, CAT_TYPE) VALUES ('{0}', '{1}', '{2}')",
                            txtCatID.Text, txtCatDesc.Text, cboType.Text);
                    }

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    this.Close();
                }
                else
                {
                    //LDW RadMessageBox.Show("Please fill in all the Information", MsgBoxStyle.Critical, "Information Incomplete");

                    DialogResult ds1 = RadMessageBox.Show(this, "Please fill in all the Information.", "Create Category", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
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
            ////LDW ErrHandler:
            //LDW modGlobal.CheckForErrors();
        }
    }
}
