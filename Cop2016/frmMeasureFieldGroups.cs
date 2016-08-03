using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmMeasureFieldGroups : Telerik.WinControls.UI.RadForm
    {
        public DataSet MSRDCGroups = new DataSet();
        public string MSRDCGroupsTable = null;

        public frmMeasureFieldGroups()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            Printer Printer = new Printer();
            int Index = 0;
            int li_cnt = 0;

            try
            {
                DataSet rsTemp = MSRDCGroups;
                string rsTempTable = MSRDCGroupsTable;


                //  Printer.Print MSRDCGroups.Resultset!CriteriaTitle

                //LDW rsTemp.MoveFirst();

                //LDW while (!rsTemp.EOF)
                foreach (DataRow myRow1 in rsTemp.Tables[rsTempTable].Rows)
                {
                    Printer.Print(FileSystem.TAB(15), myRow1.Field<string>("CriteriaTitle"));
                    //LDW rsTemp.MoveNext();
                }

                Printer.Print("End of Saved Logic List");
                Printer.EndDoc();
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

        private void dbgGroups_KeyDown(object sender, KeyEventArgs e)
        {
            bool Cancel;

            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dbgGroups.RowCount >= 0)
                    {
                        modGlobal.gv_sql = "SELECT Count(*) Used FROM tbl_Setup_MeasureCriteria WHERE MeasureFieldGroupLogicID = " + dbgGroups.Columns.GetColumnByFieldName("measurefieldgrouplogicid");
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName1 = "tbl_Setup_MeasureCriteria";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                        if (Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["Used"]) > 0)
                        {
                            RadMessageBox.Show("Can not delete this group it is used in criteria", "Can Not Delete", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        else
                        {
                            if (RadMessageBox.Show("Are you sure you want to delete this Measure Field Group Logic?", "Confirm Delete",
                                MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                            {
                                modGlobal.gv_sql = "DELETE FROM tbl_Setup_MeasureFieldGroupLogic WHERE MeasureFieldGroupLogicID = " +
                                    dbgGroups.Columns.GetColumnByFieldName("measurefieldgrouplogicid");

                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                RefreshMeasureFieldGroupLogic();
                            }
                            else
                            {
                                Cancel = true;
                            }
                        }
                    }
                }

                Application.DoEvents();
                dbgGroups.Refresh();
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

        private void frmMeasureFieldGroups_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshMeasureFieldGroupLogic();
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

        private void RefreshMeasureFieldGroupLogic()
        {
            DataSet rs_Temp = new DataSet();
            string ls_Sql = null;

            try
            {
                ls_Sql = "SELECT CriteriaTitle, MeasureFieldGroupLogicID  FROM tbl_Setup_MeasureFieldGroupLogic ORDER BY CriteriaTitle";
                //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(ls_Sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string MSRDCGroupsTable = "tbl_Setup_MeasureFieldGroupLogic";
                rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, MSRDCGroupsTable, rs_Temp);

                //LDW if (!rs_Temp.EOF)
                for (int itr = 0; itr < rs_Temp.Tables[MSRDCGroupsTable].Rows.Count; itr++)
                {
                    var myRow = (DataRow)rs_Temp.Tables[MSRDCGroupsTable].Rows[itr];
                    int rowIndex = rs_Temp.Tables[MSRDCGroupsTable].Rows.IndexOf(myRow);
                    if (rowIndex != rs_Temp.Tables[MSRDCGroupsTable].Rows.Count - 1)
                    {
                        MSRDCGroups = rs_Temp;
                    }
                    else
                    {
                        MSRDCGroups = null;
                    }
                }
                MSRDCGroups.AcceptChanges();
                dbgGroups.Refresh();
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
