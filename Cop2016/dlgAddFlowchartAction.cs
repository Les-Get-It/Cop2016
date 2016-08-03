using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using static COP2001.RadDropBinder;

namespace COP2001
{
    public partial class dlgAddFlowchartAction : Telerik.WinControls.UI.RadForm
    {
        private int il_MeasureCriteriaID;

        public dlgAddFlowchartAction()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgAddFlowchartAction_Load(object sender, EventArgs e)
        {
            List<Item> itemscboAction = new List<Item>();

            try
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureFlowchartAction";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_MeasureFlowchartAction";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                cboAction.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF) {
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    //LDW cboAction.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["ActionDescription"].Value, modGlobal.gv_rs.rdoColumns["FlowchartActionID"].Value));
                    itemscboAction.Add(new Item(myRow1.Field<int>("FlowchartActionID"), myRow1.Field<string>("ActionDescription")));

                    //cboAction.Items.Add(new ListBoxItem(myRow1.Field<string>("ActionDescription"), myRow1.Field<int>("FlowchartActionID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboAction.DataSource = itemscboAction;
                this.cboAction.DisplayMember = "Description";
                this.cboAction.ValueMember = "Id";

                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "select * from vuMeasureFlowchartLogic WHERE MeasureCriteriaID = " + il_MeasureCriteriaID;
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "vuMeasureFlowchartLogic";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //LDW txtStep.Text = modGlobal.gv_rs.rdoColumns["MeasureStep"].Value;
                txtStep.Text = modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["MeasureStep"].ToString();
                //LDW txtStep.Tag = modGlobal.gv_rs.rdoColumns["MeasureStepID"].Value;
                txtStep.Tag = modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["MeasureStepID"].ToString();
                //LDW modGlobal.gv_rs.Close();
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

        public void SetMeasureCriteriaID(int MeasureCriteriaID)
        {
            il_MeasureCriteriaID = MeasureCriteriaID;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboAction.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_MeasureStep SET FlowchartActionID = {0} WHERE MeasureStepID = {1}",
                        Support.GetItemData(cboAction, cboAction.SelectedIndex), txtStep.Tag);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //LDW RadMessageBox.Show("Successfully Saved!");

                    DialogResult ds1 = RadMessageBox.Show(this, "Successfully Saved!", "Save", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    this.Close();
                }
                else
                {
                    //LDW RadMessageBox.Show("Please choose an action to perform");

                    DialogResult ds2 = RadMessageBox.Show(this, "Please choose an action to perform", "Save", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
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
    }
}
