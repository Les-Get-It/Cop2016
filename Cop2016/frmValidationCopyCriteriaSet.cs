using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmValidationCopyCriteriaSet : Telerik.WinControls.UI.RadForm
    {
        private int ii_TableValidationMessageID;
        private int ii_TableValidationID;
        private int ii_TableSet;

        public void SetTableValidationID(int tablevalidationid)
        {
            ii_TableValidationID = tablevalidationid;
        }


        public frmValidationCopyCriteriaSet()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cboCopyTo_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                RefreshValidationSet();
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

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            int li_CritCount = 0;
            int li_Cnt = 0;
            int li_MaxID = 0;
            int li_MinID = 0;


            try
            {
                if (cboSet.SelectedIndex > -1 & cboCopyTo.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = string.Format("select count(*) as CritCount, min(tableValidationID) as MinID FROM tbl_setup_tableValidation  Where TableValidationMessageID = {0} AND CriteriaSet = {1}",
                        ii_TableValidationMessageID, ii_TableSet);

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_setup_tableValidation";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                    {
                        li_CritCount = myRow1.Field<int>("CritCount");
                        li_MinID = myRow1.Field<int>("MinID");
                    }
                    modGlobal.gv_rs.Dispose();

                    modGlobal.gv_sql = "select max(TableValidationID) as MaxID FROM tbl_setup_tableValidation ";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_setup_tableValidation";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                    {
                        li_MaxID = myRow2.Field<int>("MaxID");
                    }
                    modGlobal.gv_rs.Dispose();

                    for (li_Cnt = 1; li_Cnt <= li_CritCount; li_Cnt++)
                    {

                        modGlobal.gv_sql = " Insert Into tbl_Setup_TableValidation " + " SELECT " + li_MaxID + li_Cnt + " ,  " + Support.GetItemData
                            (cboCopyTo, cboCopyTo.SelectedIndex) + " ,[ValidationType] " + " , " + cboSet.Text + " ,[CriteriaTitle] " + " ,[SourceDDID1] " + " ,[SourceDDID2] " +
                            " ,[FieldOperator] " + " ,[DestDDID] " + " ,[LookupID] " + " ,[LookupTableID] " + " ,[ValueOperator] " + " ,[Value] " + " ,[DateUnit] " +
                            " ,[JoinOperator] " + " From tbl_Setup_TableValidation " + " Where TableValidationMessageID = " + ii_TableValidationMessageID + " AND TableValidationID = " + li_MinID;

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        modGlobal.gv_sql = string.Format("SELECT min(tableValidationID) as MinID  FROM tbl_setup_tableValidation WHERE TableValidationMessageID = {0} AND TableValidationID > {1} AND CriteriaSet = {2}",
                            ii_TableValidationMessageID, li_MinID, ii_TableSet);

                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName3 = "tbl_Setup_TableValidation";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                        //LDW if (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                        {
                            li_MinID = (Information.IsDBNull(myRow3.Field<int>("MinID")) ? 0 : myRow3.Field<int>("MinID"));
                        }
                        modGlobal.gv_rs.Dispose();
                    }
                    //LDW RadMessageBox.Show("Save Success!");

                    DialogResult ds1 = RadMessageBox.Show(this, "Save Success!", "Copy", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    this.Text = ds1.ToString();
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

        private void frmValidationCopyCriteriaSet_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            try
            {
                modGlobal.gv_sql = "select msg.TableValidationMessageID, Message, CriteriaSet from tbl_setup_tablevalidationmessage msg, tbl_setup_tableValidation tv "
                    + " Where tv.TableValidationMessageID = msg.TableValidationMessageID AND TableValidationID = " + ii_TableValidationID;

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_tablevalidationmessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                lblCopyFrom.Text = "";

                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    ii_TableValidationMessageID = myRow4.Field<int>("TableValidationMessageID");
                    ii_TableSet = myRow4.Field<int>("Criteriaset");
                    lblCopyFrom.Text = myRow4.Field<string>("Message");
                }

                modGlobal.gv_rs.Dispose();
                RefreshValidationMessages();
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

        private void RefreshValidationMessages()
        {
            try
            {
                modGlobal.gv_sql = "select Message, TableValidationMessageID from tbl_setup_tablevalidationmessage ORDER BY convert(varchar(8000), MESSAGE)";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_tablevalidationmessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);
                cboCopyTo.Items.Clear();

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    cboCopyTo.Items.Add(new ListBoxItem(myRow5.Field<string>("Message"), myRow5.Field<int>("TableValidationMessageID")).ToString());
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

        private void RefreshValidationSet()
        {
            try
            {
                if (cboCopyTo.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "select max(criteriaset) as CritSet " + " From tbl_setup_TableValidation " + " Where TableValidationMessageID = " +
                        Support.GetItemData(cboCopyTo, cboCopyTo.SelectedIndex) + " Union " + " select max(criteriaset) + 1 as CritSet " +
                        " From tbl_setup_TableValidation " + " Where TableValidationMessageID = " + Support.GetItemData(cboCopyTo, cboCopyTo.SelectedIndex) +
                        " ORDER BY CRITSET";

                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName6 = "tbl_setup_TableValidation";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                    cboSet.Items.Clear();

                    //LDW while (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                    {
                        cboSet.Items.Add(myRow6.Field<string>("CritSet"));
                        //LDWmodGlobal.gv_rs.MoveNext();
                    }

                    modGlobal.gv_rs.Dispose();
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


        private void frmValidationCopyCriteriaSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ii_TableValidationMessageID = 0;
                ii_TableValidationID = 0;
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
