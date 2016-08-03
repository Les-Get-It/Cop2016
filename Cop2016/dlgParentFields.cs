using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgParentFields : Telerik.WinControls.UI.RadForm
    {
        public DataSet rdcParentFields = new DataSet();
        public const string rdcParentFieldsTable = "tbl_setup_CMSParentCD";


        public dlgParentFields()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void RefreshParentCDs()
        {
            List<Item> itemslstParents = new List<Item>();

            try
            {
                //retrieve the list of Parent Fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_CMSParentCD ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CMSParentCD ";

                //LDW rdcParentFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                rdcParentFields = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcParentFieldsTable, rdcParentFields);
                rdcParentFields.AcceptChanges();

                lstParents.Items.Clear();
                //LDW while (!rdcParentFields.Resultset.EOF)
                foreach (DataRow myRow1 in rdcParentFields.Tables[rdcParentFieldsTable].Rows)
                {
                    itemslstParents.Add(new Item(myRow1.Field<int>("CMSParentCDID"), myRow1.Field<string>("CMSParentCD")));

                    //lstParents.Items.Add(new ListBoxItem(myRow1.Field<string>("CMSParentCD"), myRow1.Field<int>("CMSParentCDID")).ToString());
                    //LDW rdcParentFields.Resultset.MoveNext();
                }
                this.lstParents.DataSource = itemslstParents;
                this.lstParents.DisplayMember = "Description";
                this.lstParents.ValueMember = "Id";
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFieldsToLink_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (cboFieldsToLink.SelectedIndex > -1)
                {
                    SelectLookupTableForField(Support.GetItemData(cboFieldsToLink, cboFieldsToLink.SelectedIndex));
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

        private void CmdAddParentCrit_Click(object sender, EventArgs e)
        {
            frmCMSParentAddCrit frmCMSParentAddCritCopy = new frmCMSParentAddCrit();
            frmPatientFieldsExportLinks frmPatientFieldsExportLinksCopy = new frmPatientFieldsExportLinks();

            try
            {
                modGlobal.gv_Action = "ANSWER";

                if (lstParents.SelectedIndex > -1)
                {
                    frmCMSParentAddCritCopy.SetCMSParentID(Support.GetItemData(lstParents, lstParents.SelectedIndex));
                    frmCMSParentAddCritCopy.Show();

                    RefreshParentCriteria();
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

        private void cmdChangeParentJoin_Click(object sender, EventArgs e)
        {
            string ls_JoinOp = null;
            int li_cnt = 0;
            DataSet rs_Temp = new DataSet();

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (lstParents.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_CMSParentAnswerCriteriaSet WHERE CMSParentCDID = " +
                        Support.GetItemData(lstParents, lstParents.SelectedIndex);
                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_CMSParentAnswerCriteriaSet";
                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, rs_Temp);

                    //LDW if (!rs_Temp.EOF)
                    foreach (DataRow myRow2 in rs_Temp.Tables[sqlTableName1].Rows)
                    {
                        ls_JoinOp = myRow2.Field<string>("JoinOperator");

                        modGlobal.gv_sql = "UPDATE tbl_Setup_CMSParentAnswerCriteriaSet SET JoinOperator = " + (ls_JoinOp == "AND" ? "'OR'" : "'AND'") + " WHERE CMSParentCDID = " +
                            Support.GetItemData(lstParents, lstParents.SelectedIndex);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshParentCriteria();
                    }
                    rs_Temp.Dispose();

                    rs_Temp = null;
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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstParents.SelectedIndex >= 0)
                {

                    DialogResult resp = RadMessageBox.Show(this, "This can not be undone.", "Delete", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    //LDW if (RadMessageBox.Show("This can not be undone.", MsgBoxStyle.YesNo, "Are You Sure you want to Delete?") == MsgBoxResult.Yes)
                    if (resp == DialogResult.Yes)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSParentCD WHERE CMSParentCDID = " + Support.GetItemData(lstParents, lstParents.SelectedIndex);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        //delete from criteria and sets are handled in the delete trigger

                        RefreshParentCDs();
                        lstParents.SelectedIndex = -1;
                        OptAnswerCriteria.IsChecked = false;
                        OptAnswerCD.IsChecked = false;

                        //LDW RadMessageBox.Show("This parent was successfully deleted");

                        DialogResult ds1 = RadMessageBox.Show(this, "This parent was successfully deleted", "Delete", MessageBoxButtons.OK, RadMessageIcon.Info);
                        this.Text = ds1.ToString();
                    }
                }
                else
                {
                    //LDW RadMessageBox.Show("Please select a parent to delete", MsgBoxStyle.Critical, "No parent selected");

                    DialogResult ds2 = RadMessageBox.Show(this, "Please select a parent to delete", "No parent selected", MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void cmdDelParentCrit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstParents.SelectedIndex > -1)
                {
                    if (lstAnswerCriteria.SelectedIndex > -1)
                    {
                        //there are triggers on these tables to keep the set numbers and everything in order
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSParentAnswerCriteria WHERE  CMSParentAnswerCriteriaID = " + Support.GetItemData(lstAnswerCriteria, lstAnswerCriteria.SelectedIndex);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        RefreshParentCriteria();
                    }
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

        private void cmdLink_Click(object sender, EventArgs e)
        {
            int ll_curIndex = 0;

            try
            {
                if (lstParents.SelectedIndex > -1)
                {
                    if (lstAvailable.SelectedIndex > -1)
                    {
                        ll_curIndex = lstAvailable.SelectedIndex;

                        // ERROR: Not supported in C#: OnErrorStatement
                        modGlobal.gv_sql = "INSERT INTO tbl_Setup_CMSParentFieldMeasures (CMSParentCDID, FieldMeasureID) ";
                        modGlobal.gv_sql = string.Format("{0} VALUES ({1}, {2})", modGlobal.gv_sql, Support.GetItemData(lstParents, lstParents.SelectedIndex),
                            Support.GetItemData(lstAvailable, lstAvailable.SelectedIndex));

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshLinkedChildren();

                        lstAvailable.SelectedIndex = ll_curIndex - 1;
                    }
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

        private void cmdNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstParents.SelectedIndex > -1)

                    //LDW lstParents.SetSelected(lstParents.SelectedIndex, false);
                    lstParents.SelectedIndex = lstParents.SelectedIndex;
                lstParents.SelectedItem.Active = false;
                lstParents.SelectedIndex = -1;
                RefreshLookupTablesList();
                OptAnswerCriteria.IsChecked = false;
                OptAnswerCD.IsChecked = false;
                lstChildren.Items.Clear();
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

        private void cmdUnlink_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstParents.SelectedIndex > -1)
                {
                    if (lstChildren.SelectedIndex > -1)
                    {
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSParentFieldMeasures WHERE FieldMeasureID = " + Support.GetItemData(lstChildren, lstChildren.SelectedIndex);

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        RefreshLinkedChildren();
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

        private void dlgParentFields_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshParentCDs();
                RefreshAnswerCodes();
                RefreshLookupTablesList();
                lstParents.SelectedIndex = -1;
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

        private void lstParents_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                //LDW DataSet rsTemp = new DataSet();
                if (lstParents.SelectedIndex > -1 & lstParents.SelectedItems.Count > 0)
                {
                    modGlobal.gv_sql = "Select * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_CMSParentCD ";
                    modGlobal.gv_sql = string.Format("{0} WHERE CMSParentCDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstParents, lstParents.SelectedIndex));

                    //LDW rdcParentFields.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                    rdcParentFields = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcParentFieldsTable, rdcParentFields);
                    rdcParentFields.AcceptChanges();

                    //LDW if (!rdcParentFields.Resultset.EOF)
                    foreach (DataRow myRow3 in rdcParentFields.Tables[rdcParentFieldsTable].Rows)
                    {
                        txtParentField.Text = myRow3.Field<string>("CMSParentCD");
                        cboAnswerFormat.Text = (!Information.IsDBNull(myRow3.Field<string>("AnswerFormat")) ? myRow3.Field<string>("AnswerFormat") : "");
                        txtDefaultValue.Text = (!Information.IsDBNull(myRow3.Field<string>("DefaultValue")) ? myRow3.Field<string>("DefaultValue") : "");
                        if ((Information.IsDBNull(myRow3.Field<int>("AnswerCDDDID")) ? false : true))
                        {
                            OptAnswerCD.IsChecked = true;
                            SelectAnswerCD(myRow3.Field<int>("AnswerCDDDID"));
                        }
                        else
                        {
                            OptAnswerCriteria.IsChecked = true;
                        }
                    }

                    RefreshLookupTablesList();
                    RefreshLinkedChildren();
                    //RefreshAnswerCodes
                    cboLookup.Enabled = true;
                    RefreshParentCriteria();
                }
                else
                {
                    ClearForm();
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

        private void RefreshLinkedChildren()
        {
            List<Item> itemslstChildren = new List<Item>();
            lstChildren.Items.Clear();
            DataSet rsTemp = new DataSet();

            try
            {
                if (lstParents.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "SELECT MeasureCode, FieldName, CMSFieldCode, cms.FieldMeasureID FROM tbl_Setup_CMSParentFieldMeasures pf, tbl_Setup_dataDef df, tbl_Setup_CMSFieldMeasures cms";
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE df.ddid = cms.ddid AND cms.FieldMeasureID = pf.FieldMeasureID ";
                    modGlobal.gv_sql = string.Format("{0} AND CMSParentCDID = {1}", modGlobal.gv_sql, Support.GetItemData(lstParents, lstParents.SelectedIndex));
                    modGlobal.gv_sql = modGlobal.gv_sql + " order by cmsfieldcode, df.FieldName, MeasureCode ";

                    //LDW rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_Setup_CMSParentFieldMeasures";
                    rsTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, rsTemp);
                    //LDW while (!rsTemp.EOF)
                    foreach (DataRow myRow3 in rsTemp.Tables[sqlTableName2].Rows)
                    {
                        itemslstChildren.Add(new Item(myRow3.Field<int>("fieldmeasureid"), myRow3.Field<string>("measurecode") + " - " +
                            myRow3.Field<string>("FieldName") + " **** " + myRow3.Field<string>("cmsfieldcode")));

                        //lstChildren.Items.Add(new ListBoxItem(myRow3.Field<string>("measurecode") + " - " +  myRow3.Field<string>("FieldName") + " **** " + myRow3.Field<string>("cmsfieldcode"), myRow3.Field<int>("fieldmeasureid")).ToString());

                        //LDW rsTemp.MoveNext();
                    }
                    this.lstChildren.DataSource = itemslstChildren;
                    this.lstChildren.DisplayMember = "Description";
                    this.lstChildren.ValueMember = "Id";

                    rsTemp.Dispose();
                    rsTemp = null;

                    RefreshAnswerCodes();
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

        private void ClearForm()
        {
            try
            {
                txtParentField.Text = "";
                cboLookup.Text = "";
                cboAnswerFormat.Text = "";
                cboFieldsToLink.Items.Clear();
                lstAnswerCriteria.Items.Clear();
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

        private void SelectLookupTableForField(int DDID)
        {
            DataSet rsTemp = new DataSet();
            int li_cnt = 0;

            try
            {
                cboLookup.Enabled = true;

                modGlobal.gv_sql = "Select LookupTableID From tbl_Setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where DDID = " + DDID;
                //LDW rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_DataDef";
                rsTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, rsTemp);

                //LDW if (!rsTemp.EOF)
                foreach (DataRow myRow4 in rsTemp.Tables[sqlTableName3].Rows)
                {
                    for (li_cnt = 0; li_cnt <= cboLookup.Items.Count - 1; li_cnt++)
                    {
                        if (Support.GetItemData(cboLookup, li_cnt) == myRow4.Field<int>("LookupTableID"))
                        {
                            cboLookup.SelectedIndex = li_cnt;
                            cboLookup.Enabled = false;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }

                rsTemp.Dispose();
                rsTemp = null;
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

        private void RefreshLookupTablesList()
        {
            DataSet rsTemp = new DataSet();
            int LookupIndex = -1;
            int thisListIndex = -1;
            List<Item> itemscboLookup = new List<Item>();

            try
            {
                modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "' or State is null)";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_TableDef";
                rsTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, rsTemp);

                cboLookup.Items.Clear();
                //LDW while (!rsTemp.EOF)
                foreach (DataRow myRow4 in rsTemp.Tables[sqlTableName4].Rows)
                {
                    thisListIndex = thisListIndex + 1;

                    itemscboLookup.Add(new Item(myRow4.Field<int>("basetableid"), myRow4.Field<string>("BaseTable")));

                    //cboLookup.Items.Add(new ListBoxItem(myRow4.Field<string>("BaseTable"), myRow4.Field<int>("basetableid")).ToString());

                    //LDW if (!rdcParentFields.Resultset.EOF)
                    foreach (DataRow myRow5 in rdcParentFields.Tables[rdcParentFieldsTable].Rows)
                    {
                        if (!Information.IsDBNull(myRow5.Field<int>("LookupTableID")))
                        {
                            if (myRow5.Field<int>("LookupTableID") == myRow4.Field<int>("basetableid"))
                            {
                                LookupIndex = thisListIndex;
                            }
                        }
                        else
                        {
                            return;
                            //YES/NO Answer CD is DEFAULT for the CMS Output file
                            //If rsTemp!BaseTable = "YES/NO" Then
                            //    LookupIndex = thisListIndex
                            //End If
                        }
                    }

                    //LDW rsTemp.MoveNext();
                }
                this.cboLookup.DataSource = itemscboLookup;
                this.cboLookup.DisplayMember = "Description";
                this.cboLookup.ValueMember = "Id";

                rsTemp.Dispose();
                rsTemp = null;

                if (LookupIndex > -1)
                {
                    cboLookup.SelectedIndex = LookupIndex;
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

        private void RefreshAnswerCodes()
        {
            DataSet rsAnswerCD = new DataSet();
            int li_cnt = 0;
            List<Item> itemslstAvailable = new List<Item>();


            try
            {
                modGlobal.gv_sql = "Select cms.FieldMeasureID, cms.measurecode, df.ddid, df.fieldname, df.cmsfieldcode ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as df ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_cmsFieldMeasures as cms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";

                if (lstChildren.Items.Count > 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " WHERE cms.FieldMeasureID NOT IN (";

                    for (li_cnt = 0; li_cnt <= lstChildren.Items.Count - 1; li_cnt++)
                    {
                        modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, Support.GetItemData(lstChildren, li_cnt));
                    }

                    modGlobal.gv_sql = Strings.Mid(modGlobal.gv_sql, 1, Strings.Len(modGlobal.gv_sql) - 1) + ")";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " order by cmsfieldcode, df.FieldName, MeasureCode ";

                //LDW rsAnswerCD = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_setup_DataDef";
                rsAnswerCD = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, rsAnswerCD);

                lstAvailable.Items.Clear();

                //LDW while (!rsAnswerCD.EOF)
                foreach (DataRow myRow5 in rsAnswerCD.Tables[sqlTableName5].Rows)
                {
                    itemslstAvailable.Add(new Item(myRow5.Field<int>("fieldmeasureid"), myRow5.Field<string>("measurecode") + " - " + myRow5.Field<string>("FieldName") +
                        " **** " + myRow5.Field<string>("cmsfieldcode")));

                    //lstAvailable.Items.Add(new ListBoxItem(myRow5.Field<string>("measurecode") + " - " + myRow5.Field<string>("FieldName") +
                    //    " **** " + myRow5.Field<string>("cmsfieldcode"), myRow5.Field<int>("fieldmeasureid")).ToString());

                    //LDW rsAnswerCD.MoveNext();
                }
                this.lstAvailable.DataSource = itemslstAvailable;
                this.lstAvailable.DisplayMember = "Description";
                this.lstAvailable.ValueMember = "Id";

                rsAnswerCD.Dispose();
                rsAnswerCD = null;
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

        public void RefreshFieldsToLink()
        {
            DataSet rsTemp = new DataSet();
            List<Item> itemscboFieldsToLink = new List<Item>();


            try
            {
                //retrieve the list of table fields only if they are already a part of the cmsfieldmeasures
                modGlobal.gv_sql = " Select * from tbl_setup_DataDef, tbl_setup_tableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.BaseTableID = tbl_setup_tableDef.BaseTableID AND BaseTable = 'PATIENT' ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";

                //LDW rsTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_setup_DataDef";
                rsTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, rsTemp);

                cboFieldsToLink.Items.Clear();

                //LDW while (!rsTemp.EOF)
                foreach (DataRow myRow7 in rsTemp.Tables[sqlTableName6].Rows)
                {
                    itemscboFieldsToLink.Add(new Item(myRow7.Field<int>("DDID"), myRow7.Field<string>("FieldName")));

                    //cboFieldsToLink.Items.Add(new ListBoxItem(myRow7.Field<string>("FieldName"), myRow7.Field<int>("DDID")).ToString());
                    //LDW rsTemp.MoveNext();
                }
                this.cboFieldsToLink.DataSource = itemscboFieldsToLink;
                this.cboFieldsToLink.DisplayMember = "Description";
                this.cboFieldsToLink.ValueMember = "Id";

                rsTemp.Dispose();
                rsTemp = null;
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
            //If cboLookup.ListIndex = -1 Then
            //    MsgBox "Please choose the lookup table.", vbCritical, "Lookup Table not Chosen"
            //    Exit Sub
            //End If
            try
            {
                if (Strings.Len(txtParentField.Text) == 0 | Information.IsDBNull(txtParentField.Text))
                {
                    //LDW RadMessageBox.Show("Please enter the parent code name.", MsgBoxStyle.Critical, "Parent Code not entered");

                    DialogResult ds3 = RadMessageBox.Show(this, "Please enter the parent code name.", "Parent Code Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                    return;
                }

                string ls_ParentCD = null;

                if (lstParents.SelectedIndex > -1)
                {

                    modGlobal.gv_sql = "UPDATE tbl_Setup_CMSParentCD ";
                    modGlobal.gv_sql = string.Format("{0} SET CMSParentCD = '{1}'", modGlobal.gv_sql, txtParentField.Text);
                    if (OptAnswerCD.IsChecked & cboFieldsToLink.SelectedIndex > -1)
                    {
                        modGlobal.gv_sql = string.Format("{0} , AnswerCDDDID = {1}", modGlobal.gv_sql,
                            Support.GetItemData(cboFieldsToLink, cboFieldsToLink.SelectedIndex));
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " , AnswerCDDDID = NULL ";
                    }

                    if (string.IsNullOrEmpty(cboLookup.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " , LookupTableID = NULL ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} , LookupTableID = {1}", modGlobal.gv_sql,
                            Support.GetItemData(cboLookup, cboLookup.SelectedIndex));
                    }

                    modGlobal.gv_sql = string.Format("{0} , AnswerFormat = '{1}'", modGlobal.gv_sql, cboAnswerFormat.Text);
                    modGlobal.gv_sql = string.Format("{0} , DefaultValue = '{1}'", modGlobal.gv_sql, txtDefaultValue.Text);
                    modGlobal.gv_sql = string.Format("{0} WHERE CMSParentCDID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(lstParents, lstParents.SelectedIndex));

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    ls_ParentCD = txtParentField.Text;

                    RefreshParentCDs();

                    //LDW RadMessageBox.Show("This parent field was sucessfully Updated", MsgBoxStyle.Information, "Successfully Updated Existing Field");

                    DialogResult ds4 = RadMessageBox.Show(this, "This parent field was sucessfully Updated.", "Successfully Updated Existing Field", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Text = ds4.ToString();
                }
                else
                {

                    modGlobal.gv_sql = string.Format("INSERT INTO tbl_Setup_CMSParentCD  ([CMSParentCD], [AnswerCDDDID], [LookupTableID], [AnswerFormat], [DefaultValue])  VALUES ('{0}', ",
                        txtParentField.Text);
                    if (OptAnswerCD.IsChecked & cboFieldsToLink.SelectedIndex > -1)
                    {
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboFieldsToLink, cboFieldsToLink.SelectedIndex));
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
                    }

                    if (!string.IsNullOrEmpty(cboLookup.Text))
                    {
                        modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, Support.GetItemData(cboLookup, cboLookup.SelectedIndex));
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
                    }

                    modGlobal.gv_sql = string.Format("{0} '{1}', '{2}')", modGlobal.gv_sql, cboAnswerFormat.Text, txtDefaultValue.Text);

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    ls_ParentCD = txtParentField.Text;

                    RefreshParentCDs();

                    //LDW RadMessageBox.Show("This parent field was sucessfully Added", MsgBoxStyle.Information, "Successfully Added New Field");

                    DialogResult ds5 = RadMessageBox.Show(this, "This parent field was sucessfully Added.", "Successfully Added New Field", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Text = ds5.ToString();
                }

                //LDW rdcParentFields.Resultset.MoveFirst();
                int li_cnt = -1;

                //LDW while (!rdcParentFields.Resultset.EOF)
                foreach (DataRow myRow7 in rdcParentFields.Tables[rdcParentFieldsTable].Rows)
                {
                    li_cnt = li_cnt + 1;
                    if (myRow7.Field<string>("CMSParentCD") == ls_ParentCD)
                    {
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                    //LDW rdcParentFields.Resultset.MoveNext();
                }

                //LDW lstParents.SetSelected(li_cnt, true);
                lstParents.SelectedIndex = li_cnt;
                lstParents.SelectedItem.Active = true;

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

        private void OptAnswerCriteria_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(OptAnswerCriteria.IsChecked))
                {
                    if (OptAnswerCriteria.IsChecked)
                    {
                        lstAnswerCriteria.Enabled = true;
                        cboFieldsToLink.Enabled = false;
                        cboFieldsToLink.Items.Clear();
                    }
                    else
                    {
                        lstAnswerCriteria.Items.Clear();
                        lstAnswerCriteria.Enabled = false;
                    }

                    CmdAddParentCrit.Enabled = OptAnswerCriteria.IsChecked;
                    cmdDelParentCrit.Enabled = OptAnswerCriteria.IsChecked;
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

        private void OptAnswerCD_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(OptAnswerCD.IsChecked))
                {
                    if (OptAnswerCD.IsChecked)
                    {
                        cboFieldsToLink.Enabled = true;
                        lstAnswerCriteria.Items.Clear();
                        RefreshFieldsToLink();
                    }
                    else
                    {
                        cboFieldsToLink.Enabled = false;
                        cboFieldsToLink.Items.Clear();
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

        private void SelectAnswerCD(int DDID)
        {
            int li_cnt = 0;

            try
            {
                for (li_cnt = 0; li_cnt <= cboFieldsToLink.Items.Count - 1; li_cnt++)
                {
                    if (Support.GetItemData(cboFieldsToLink, li_cnt) == DDID)
                    {
                        cboFieldsToLink.SelectedIndex = li_cnt;
                        break; // TODO: might not be correct. Was : Exit For
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

        private void RefreshParentCriteria()
        {
            string ls_display = null;
            DataSet rs_Criteria = new DataSet();
            int li_SetCnt = 0;
            int li_SetIndex = 0;
            string ls_SetJoinOp = null;
            int li_MaxSet = 0;
            List<Item> itemslstAnswerCriteria = new List<Item>();

            try
            {
                lstAnswerCriteria.Items.Clear();

                modGlobal.gv_sql = string.Format("SELECT CMSParentAnswerCriteriaSet, JoinOperator FROM tbl_Setup_CMSParentAnswerCriteriaSet   WHERE CMSParentCDID = {0} ORDER BY CMSParentAnswerCriteriaSet",
                    Support.GetItemData(lstParents, lstParents.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                const string sqlTableName7 = "tbl_Setup_CMSParentAnswerCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                for (int i = 0; i < modGlobal.gv_rs.Tables[sqlTableName7].Rows.Count; i++)
                {
                    var myRow = (DataRow)modGlobal.gv_rs.Tables[sqlTableName7].Rows[i];
                    if (i == modGlobal.gv_rs.Tables[sqlTableName7].Rows.Count - 1)
                    {

                        //LDW modGlobal.gv_rs.MoveLast();
                        li_MaxSet = modGlobal.gv_rs.Tables[sqlTableName7].Rows.Count;
                        //LDW modGlobal.gv_rs.MoveFirst();

                        while (i != modGlobal.gv_rs.Tables[sqlTableName7].Rows.Count - 1)
                        {

                            ls_SetJoinOp = myRow.Field<string>("JoinOperator");

                            modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentAnswerCriteria  " + " WHERE CMSParentCDID = " +
                                Support.GetItemData(lstParents, lstParents.SelectedIndex) +
                                " AND  CMSParentAnswerCriteriaSet =  " + myRow.Field<int>("CMSParentAnswerCriteriaSet") + " ORDER BY CMSParentAnswerCriteriaSet, CMSParentAnswerCriteriaID";

                            //LDW rs_Criteria = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                            const string sqlTableName8 = "tbl_Setup_CMSParentAnswerCriteria";
                            rs_Criteria = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, rs_Criteria);

                            //LDW rs_Criteria.MoveLast();
                            li_SetCnt = rs_Criteria.Tables[sqlTableName8].Rows.Count;
                            //LDW rs_Criteria.MoveFirst();

                            li_SetIndex = 0;

                            ls_display = "SET " + myRow.Field<int>("CMSParentAnswerCriteriaSet") + ": ( ";

                            //LDW while (!rs_Criteria.EOF)
                            foreach (DataRow myRow9 in rs_Criteria.Tables[sqlTableName8].Rows)
                            {
                                li_SetIndex = li_SetIndex + 1;

                                ls_display = ls_display + "   " + myRow9.Field<string>("CriteriaTitle");

                                if (li_SetCnt == li_SetIndex)
                                {
                                    if (li_SetCnt == 1)
                                    {
                                        ls_display = ls_display + " (" + myRow9.Field<string>("JoinOperator") + ") )";
                                    }
                                    else
                                    {
                                        ls_display = ls_display + " )";
                                    }
                                }
                                else
                                {
                                    ls_display = ls_display + " " + myRow9.Field<string>("JoinOperator") + " ";
                                }

                                itemslstAnswerCriteria.Add(new Item(myRow9.Field<int>("CMSParentAnswerCriteriaID"), ls_display));

                                //lstAnswerCriteria.Items.Add(new ListBoxItem(ls_display, myRow9.Field<int>("CMSParentAnswerCriteriaID")).ToString());
                                ls_display = "";

                                //LDW rs_Criteria.MoveNext();
                            }
                            this.lstAnswerCriteria.DataSource = itemslstAnswerCriteria;
                            this.lstAnswerCriteria.DisplayMember = "Description";
                            this.lstAnswerCriteria.ValueMember = "Id";

                            rs_Criteria.Dispose();

                            if (myRow.Field<int>("CMSParentAnswerCriteriaSet") < li_MaxSet)
                            {
                                lstAnswerCriteria.Items.Add(ls_SetJoinOp);
                            }

                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                    }
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
    }
}
