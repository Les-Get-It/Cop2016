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
    public partial class frmHospStatEditGroupField : Telerik.WinControls.UI.RadForm
    {
        public frmHospStatEditGroupField()
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
            int newfieldorder;
            var i = 0;

            try
            {

                for (i = 0; i <= lstHospStatFields.Items.Count - 1; i++)
                {
                    if (lstHospStatFields.SelectedIndex == i)
                    {
                        //NewID = FindMaxRecID("tbl_Setup_DataReq", "IndicatorDDID")

                        modGlobal.gv_sql = "select max(fieldorder) as maxorder from tbl_setup_HospStatGroupFields ";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName1 = "tbl_setup_HospStatGroupFields";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                        newfieldorder = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["maxorder"]) + 1;

                        modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroupFields (HospStatGroupID, DDID, fieldorder )";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Values (";
                        modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(frmHospStatSetupCopy.lstHospStatGroup,
                            frmHospStatSetupCopy.lstHospStatGroup.SelectedIndex);
                        modGlobal.gv_sql = string.Format("{0},{1}, {2}", modGlobal.gv_sql, Support.GetItemData(lstHospStatFields, i), newfieldorder);
                        modGlobal.gv_sql = modGlobal.gv_sql + ")";

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

        private void frmHospStatEditGroupField_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            try
            {
                RefreshHospStatFields();
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

        public void RefreshHospStatFields()
        {
            frmHospStatSetup frmHospStatSetupCopy = new frmHospStatSetup();
            var LIndex = 0;
            var Table_ListIndex = 0;
            List<Item> itemslstHospStatFields = new List<Item>();

            try
            {
                //retrieve the list of Fields
                modGlobal.gv_sql = "Select tbl_setup_DataDef.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_DataDef.BaseTableID = tbl_setup_TableDef.BaseTableID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and upper(substring(tbl_setup_TableDef.BaseTable,1,13)) = 'HOSPITAL STAT'  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and tbl_setup_DataDef.ddid not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select DDID from tbl_setup_HospStatGroupFields  ";
                modGlobal.gv_sql = string.Format("{0} where hospstatgroupid = {1})", modGlobal.gv_sql,
                    Support.GetItemData(frmHospStatSetupCopy.lstHospStatGroup, frmHospStatSetupCopy.lstHospStatGroup.SelectedIndex));

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_Setup_DataDef.State = '' or tbl_Setup_DataDef.State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_Setup_DataDef.State = '' or tbl_Setup_DataDef.State is null or  tbl_Setup_DataDef.State = '{1}') ",
                        modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_DataDef.FieldName ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                lstHospStatFields.Items.Clear();

                Table_ListIndex = -1;

                LIndex = -1;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    LIndex = LIndex + 1;
                    Table_ListIndex = LIndex;
                    itemslstHospStatFields.Add(new Item(myRow2.Field<int>("ddid"), myRow2.Field<string>("FieldName")));

                    //lstHospStatFields.Items.Add(new ListBoxItem(myRow2.Field<string>("FieldName"), myRow2.Field<int>("ddid")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
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
