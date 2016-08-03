using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;
using static COP2001.RadDropBinder;

namespace COP2001
{
    public partial class frmHospStatEditIndicator : Telerik.WinControls.UI.RadForm
    {
        public frmHospStatEditIndicator()
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

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            frmHospStatSetup frmHospStatSetupCopy = new frmHospStatSetup();
            var i = 0;

            try
            {
                for (i = 0; i <= lstIndicators.Items.Count - 1; i++)
                {
                    if (lstIndicators.SelectedIndex == i)
                    {
                        //NewID = FindMaxRecID("tbl_Setup_DataReq", "IndicatorDDID")
                        //give it a field order number

                        modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroupIndicator (HospStatGroupID, IndicatorID)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Values (";
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(
                            frmHospStatSetupCopy.lstHospStatGroup, frmHospStatSetupCopy.lstHospStatGroup.SelectedIndex);
                        modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, Support.GetItemData(lstIndicators, i));

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                }
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

        private void frmHospStatEditIndicator_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshIndicators();
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
            //txtDisplayOrder = frmSectionIndicator.rdcPatientFields.Resultset!DisplayOrder
        }

        public void RefreshIndicators()
        {
            frmHospStatSetup frmHospStatSetupCopy = new frmHospStatSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemslstIndicators = new List<Item>();


            try
            {
                //retrieve the list of indicators
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where IndicatorID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select IndicatorID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_HospStatGroupIndicator ";
                modGlobal.gv_sql = string.Format("{0} where HospStatGroupID = {1})", modGlobal.gv_sql,
                    Support.GetItemData(frmHospStatSetupCopy.lstHospStatGroup, frmHospStatSetupCopy.lstHospStatGroup.SelectedIndex));
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (State = '' or State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lstIndicators.Items.Clear();
                Table_ListIndex = -1;
                LIndex = -1;

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;

                    itemslstIndicators.Add(new Item(myRow1.Field<int>("IndicatorID"), myRow1.Field<string>("Description")));

                    //lstIndicators.Items.Add(new ListBoxItem(myRow1.Field<string>("Description"), myRow1.Field<int>("IndicatorID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstIndicators.DataSource = itemslstIndicators;
                this.lstIndicators.DisplayMember = "Description";
                this.lstIndicators.ValueMember = "Id";
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
