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
    public partial class frmMeasureAddCritGroup : Telerik.WinControls.UI.RadForm
    {
        private int ii_MeasureCriteriaID;
        private int ii_MeasureStepID;


        public frmMeasureAddCritGroup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void SetDescription(string Description)
        {
            lblColName.Text = string.Format("{0} {1}", lblColName.Text, Description);
        }

        public void SetMeasureCriteriaID(int MeasureCriteriaID)
        {
            try
            {
                ii_MeasureCriteriaID = MeasureCriteriaID;
                ii_MeasureStepID = 0;
                PopulateSetList();
                PopulateGroupList();
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

        private void PopulateSetList()
        {
            try
            {
                lstSetList.Items.Clear();

                if (ii_MeasureStepID == 0)
                {
                    setMeasureStepID();
                }

                modGlobal.gv_sql = "SELECT MeasureCriteriaSet, MeasureCriteriaSetID FROM tbl_Setup_MeasureCriteriaSet " + " WHERE MeasureStepID = " +
                    ii_MeasureStepID + " ORDER BY MeasureCriteriaSet";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    lstSetList.Items.Add(new ListBoxItem(myRow1.Field<string>("MeasureCriteriaSet"),
                        myRow1.Field<int>("measurecriteriasetid")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

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

        private void setMeasureStepID()
        {
            try
            {
                modGlobal.gv_sql = "SELECT ms.MeasureStepID  FROM " + " tbl_setup_measurecriteria mc, tbl_setup_measurecriteriaset mcs, tbl_setup_MeasureStep ms " +
                    " WHERE mc.measurecriteriasetid = mcs.measurecriteriasetid " + " AND ms.MeasureStepID = mcs.MeasureStepID " + " AND mc.MeasureCriteriaID = " + ii_MeasureCriteriaID;
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_measurecriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count; itr++)
                {
                    var myRow11 = modGlobal.gv_rs.Tables[sqlTableName2].Rows[itr];
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName2].Rows.IndexOf(myRow11);
                    int rowLast = modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count - 1;

                    if (rowIndex == rowLast)
                    {
                        RadMessageBox.Show("Could not determine step id from selected criteria", "Fatal Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        ii_MeasureStepID = (object.ReferenceEquals(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["MeasureStepID"], DBNull.Value) ?
                            0 : Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["MeasureStepID"]));
                    }
                }
                modGlobal.gv_rs.Dispose();
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


        private void cboGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                modGlobal.gv_sql = "SELECT msg.*, mcs.MeasureCriteriaSet " + " FROM tbl_Setup_MeasureStepGroup msg, tbl_Setup_MeasureCriteriaSet mcs " +
                    " WHERE msg.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID " + " AND msg.MeasureStepID = " + ii_MeasureStepID +
                    " AND msg.MeasureStepGroup = " + Convert.ToInt32(cboGroup.Text);

                lstSelectedSetList.Items.Clear();

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_MeasureStepGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName3].Rows.Count; itr++)
                {
                    var myRow3 = modGlobal.gv_rs.Tables[sqlTableName3].Rows[itr];
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName3].Rows.IndexOf(myRow3);
                    int rowLast = modGlobal.gv_rs.Tables[sqlTableName3].Rows.Count - 1;


                    if (rowIndex == rowLast)
                    {
                        modGlobal.gv_rs.Dispose();

                        modGlobal.gv_sql = string.Format("SELECT JoinOperator FROM tbl_Setup_MeasureStepGroup  WHERE MeasureStepID = {0}", ii_MeasureStepID);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName4 = "tbl_Setup_MeasureStepGroup";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);
                        //LDW if (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                        {
                            cboJoinOperator.Text = myRow4.Field<string>("JoinOperator");
                        }
                    }
                    else
                    {
                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRowA3 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                        {
                            cboJoinOperator.Text = myRowA3.Field<string>("JoinOperator");
                            lstSelectedSetList.Items.Add(new ListBoxItem(myRowA3.Field<string>("MeasureCriteriaSet"),
                                myRowA3.Field<int>("measurecriteriasetid")).ToString());
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                    }
                }

                modGlobal.gv_rs.Dispose();

                PopulateSetList();
                RemoveSelected();

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

        private void RemoveSelected()
        {
            int li_cnt = 0;

            try
            {

                modGlobal.gv_sql = "SELECT DISTINCT MeasureCriteriaSetID FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID;
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_MeasureStepGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    for (li_cnt = 0; li_cnt <= lstSetList.Items.Count - 1; li_cnt++)
                    {
                        if (Support.GetItemData(lstSetList, li_cnt) == Convert.ToInt32(myRow5.Field<int>("measurecriteriasetid")))
                        {
                            lstSetList.Items.RemoveAt((li_cnt));
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
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

        private void cmdAddSet_Click(object sender, EventArgs e)
        {
            int li_cnt ;
            int li_list = 0;
            int counter = 0;

            try
            {
                if (lstSetList.SelectedItems.Count > 0)
                {
                    li_list = lstSetList.Items.Count - 1;

                    counter = li_list;
                    for (li_cnt = counter; li_cnt >= 0; li_cnt += -1)
                    {
                        if (li_cnt > li_list)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }

                        //LDW if (lstSetList.GetSelected(li_cnt) == true)
                        if ((lstSetList.SelectedIndex == li_cnt) == true)
                        {
                            lstSelectedSetList.Items.Add(new ListBoxItem(Support.GetItemString(lstSetList, li_cnt), Support.GetItemData(lstSetList, li_cnt)).ToString());

                            lstSetList.Items.RemoveAt(li_cnt);
                            li_list = lstSetList.Items.Count - 1;
                        }
                    }

                    SaveChanges();
                }
                else
                {
                    RadMessageBox.Show("Please select a set");
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateGroupList()
        {
            int ll_LastGroup = 0;
            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                cboGroup.Items.Clear();

                modGlobal.gv_sql = string.Format("SELECT DISTINCT MeasureStepGroup FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = {0} ORDER BY MeasureStepGroup", ii_MeasureStepID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_Setup_MeasureStepGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                /*LDW if (!modGlobal.gv_rs.EOF)
                {
                    while (!modGlobal.gv_rs.EOF)
                    {
                        ll_LastGroup = newRow["MeasureStepGroup"];
                        cboGroup.Items.Add(Convert.ToString(ll_LastGroup));
                        //LDW modGlobal.gv_rs.MoveNext();
                    }
                } */
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    ll_LastGroup = myRow6.Field<int>("MeasureStepGroup");
                    cboGroup.Items.Add(Convert.ToString(ll_LastGroup));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                cboGroup.Items.Add(Convert.ToString(ll_LastGroup + 1));

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

        private void cmdRemoveSet_Click(object sender, EventArgs e)
        {
            int li_cnt;
            int li_list = 0;
            int counter = 0;

            try
            {
                if (lstSelectedSetList.SelectedItems.Count > 0)
                {
                    li_list = lstSelectedSetList.Items.Count - 1;

                    counter = li_list;
                    for (li_cnt = counter; li_cnt >= 0; li_cnt += -1)
                    {
                        if (li_cnt > li_list)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }

                        if ((lstSelectedSetList.SelectedIndex == li_cnt) == true)
                        {
                            lstSetList.Items.Add(new ListBoxItem(Support.GetItemString(lstSelectedSetList, li_cnt), Support.GetItemData(lstSelectedSetList, li_cnt)).ToString());
                            lstSelectedSetList.Items.RemoveAt(li_cnt);

                            li_list = lstSelectedSetList.Items.Count - 1;
                        }
                    }

                    SaveChanges();
                }
                else
                {
                    RadMessageBox.Show("Please select a field");
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

        private void SaveChanges()
        {
            int li_group = 0;
            string SQL = null;

            try
            {
                if (string.IsNullOrEmpty(Strings.Trim(cboGroup.Text)))
                {
                    RadMessageBox.Show("Please select a group to associate with this criteria");
                    return;
                }
                li_group = Convert.ToInt32(cboGroup.Text);

                if (lstSelectedSetList.Items.Count == 0)
                {
                    if (RadMessageBox.Show("Are you sure you want to remove this group?", "Confirm Delete", MessageBoxButtons.OKCancel, RadMessageIcon.Question) == DialogResult.OK)
                    {
                        modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = {0} AND MeasureStepGroup > {1}", ii_MeasureStepID, li_group);
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName7 = "tbl_Setup_MeasureStepGroup";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                        //LDW if (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                        {
                            RadMessageBox.Show("You must delete groups after this group first.", "Remove Other Groups First", MessageBoxButtons.OK, RadMessageIcon.Error);
                            return;
                        }

                        //delete the grouping
                        //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID + " AND MeasureStepGroup = " + li_group);
                        SQL = string.Format("DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = {0} AND MeasureStepGroup = {1}", ii_MeasureStepID, li_group);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                        goto Populate;
                    }
                    else
                    {
                        return;
                    }
                }

                if (string.IsNullOrEmpty(Strings.Trim(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Please select the Join Type; the option that defines how to add this group to the exisiting ones.");
                    return;
                }

                int li_cnt = 0;

                //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID + " AND MeasureStepGroup = " + li_group);
                SQL = string.Format("DELETE FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = {0} AND MeasureStepGroup = {1}", ii_MeasureStepID, li_group);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                for (li_cnt = 0; li_cnt <= lstSelectedSetList.Items.Count - 1; li_cnt++)
                {
                    //delete then insert in case any were removed from the selected list

                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStepGroup WHERE MeasureStepID = " + ii_MeasureStepID;
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                    const string sqlTableName8 = "tbl_Setup_MeasureStepGroup";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                    //LDW modGlobal.gv_rs.AddNew();
                    //LDW creat new datatable row
                    DataRow newRow = modGlobal.gv_rs.Tables[sqlTableName8].NewRow();

                    newRow["MeasureStepID"] = ii_MeasureStepID;
                    newRow["measurecriteriasetid"] = Convert.ToInt32(Support.GetItemData(lstSelectedSetList, li_cnt));
                    newRow["MeasureStepGroup"] = li_group;
                    newRow["JoinOperator"] = cboJoinOperator.Text;

                    //Add new datatable row
                    modGlobal.gv_rs.Tables[sqlTableName8].Rows.Add(newRow);

                    //LDW modglobal.gv_rs.Update();
                    modGlobal.gv_rs.AcceptChanges();
                }

                modGlobal.gv_rs.Dispose();
                Populate:

                PopulateGroupList();

                cboGroup.SelectedIndex = li_group - 1;
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

        /*LDW Not used
        private void cmdAdd_Click()
		{
			SaveChanges();
		}
        */
    }
}
