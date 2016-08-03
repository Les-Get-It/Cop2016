using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmImportMeasureSetFile : Telerik.WinControls.UI.RadForm
    {
        private string is_StartDatePart;
        private string is_EndDatePart;

        public frmImportMeasureSetFile()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboMeasureSet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshIndicatorList();
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            try
            {
                pgStatus.Value1 = 0;

                if (string.IsNullOrEmpty(lstYear.Text) | string.IsNullOrEmpty(cboMeasureSet.Text))
                {
                    RadMessageBox.Show("Please choose the Measure or Year to Import", "Required Elements not Selected", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    //MsgBox "In Progress"
                    modImportForCoreMeasVerify.ImportMeasureRecs(Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex), Convert.ToDateTime(is_StartDatePart + lstYear.Text),
                        Convert.ToDateTime(is_EndDatePart + lstYear.Text), "Q", Convert.ToInt32(chkNotImport.CheckState));
                    this.Cursor = Cursors.Default;
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

        private void frmImportMeasureSetFile_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            var i = 0;
            int yr = 1990;

            try
            {
                is_StartDatePart = "1/1/";
                is_EndDatePart = "3/31/";

                //Adds 35 years to base year which is 1990
                lstYear.Items.Clear();
                for (i = 1; i <= 36; i++)
                {
                    if (i != 36)
                    {
                        lstYear.Items.Add((Convert.ToString(yr)));
                        yr = yr + 1;
                    }
                }

                lstYear.Text = Convert.ToString(DateAndTime.Year(DateAndTime.Now));

                RefreshMeasureSet();
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

        private void Opt1st_Enter(object sender, EventArgs e)
        {
            try
            {
                lblMonths.Text = "January, February, March";
                is_StartDatePart = "1/1/";
                is_EndDatePart = "3/31/";
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

        private void Opt2nd_Enter(object sender, EventArgs e)
        {
            try
            {
                lblMonths.Text = "April, May, June";
                is_StartDatePart = "4/1/";
                is_EndDatePart = "6/30/";
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

        private void Opt3rd_Enter(object sender, EventArgs e)
        {
            try
            {
                lblMonths.Text = "July, August, September";
                is_StartDatePart = "7/1/";
                is_EndDatePart = "9/30/";
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

        private void Opt4th_Enter(object sender, EventArgs e)
        {
            try
            {
                lblMonths.Text = "October, November, December";
                is_StartDatePart = "10/1/";
                is_EndDatePart = "12/31/";
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

        private void RefreshMeasureSet()
        {
            string setdesc = null;
            List<Item> itemscboMeasureSet = new List<Item>();


            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_measureset ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Where (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} Where State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by MeasureSetDesc ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_measureset";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                cboMeasureSet.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    if (Information.IsDBNull(myRow1.Field<string>("EffDate")))
                    {
                        setdesc = myRow1.Field<string>("MeasureSetDesc");
                    }
                    else
                    {
                        setdesc = string.Format("{0} ({1})", myRow1.Field<string>("MeasureSetDesc"), myRow1.Field<string>("EffDate"));
                    }

                    itemscboMeasureSet.Add(new Item(myRow1.Field<int>("MeasureSetID"), setdesc));

                    //cboMeasureSet.Items.Add(new ListBoxItem(setdesc, myRow1.Field<int>("MeasureSetID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboMeasureSet.DataSource = itemscboMeasureSet;
                this.cboMeasureSet.DisplayMember = "Description";
                this.cboMeasureSet.ValueMember = "Id";

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

        private void RefreshIndicatorList()
        {
            List<Item> itemslstIndicators = new List<Item>();

            try
            {
                if (cboMeasureSet.SelectedIndex == -1)
                {
                    RadMessageBox.Show("Invalid Measure Set");
                    return;
                }

                modGlobal.gv_sql = "Select map.IndicatorID, Description from tbl_setup_MeasureSetMapMeas map, tbl_Setup_indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE map.IndicatorID = tbl_Setup_indicator.IndicatorID AND MeasureSetID = " +
                    Support.GetItemData(cboMeasureSet, cboMeasureSet.SelectedIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_MeasureSetMapMeas";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                lstIndicators.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    itemslstIndicators.Add(new Item(myRow2.Field<int>("IndicatorID"), myRow2.Field<string>("Description")));

                    //lstIndicators.Items.Add(new ListBoxItem(myRow2.Field<string>("Description"), myRow2.Field<int>("IndicatorID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstIndicators.DataSource = itemslstIndicators;
                this.lstIndicators.DisplayMember = "Description";
                this.lstIndicators.ValueMember = "Id";

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
    }
}
