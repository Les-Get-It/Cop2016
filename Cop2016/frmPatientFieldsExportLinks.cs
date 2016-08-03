using System;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmPatientFieldsExportLinks : RadForm
    {
        public DataSet rdcFieldList = new DataSet();
        public string rdcFieldListTable = null;
        public DataSet rdcTemp = new DataSet();
        public string rdcTempTable = null;


        public frmPatientFieldsExportLinks()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAddFIeldCrit_Click(object sender, EventArgs e)
        {
            frmCMSParentAddCrit frmCMSParentAddCritCopy = new frmCMSParentAddCrit();

            try
            {
                modGlobal.gv_Action = "FIELD";

                if (lstFieldsInMeasure.SelectedIndex > -1)
                {
                    frmCMSParentAddCritCopy.SetCMSParentID(Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));
                    frmCMSParentAddCritCopy.Show();
                    RefreshFieldMeasureCriteria();
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

        private void cmdChangeFieldJoin_Click(object sender, EventArgs e)
        {
            string ls_JoinOp = null;
            int li_cnt = 0;
            DataSet rs_Temp = new DataSet();

            // ERROR: Not supported in C#: OnErrorStatement

            try
            {
                if (lstFieldsInMeasure.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_CMSFieldMeasureCriteriaSet WHERE CMSFieldMeasureID = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex);
                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName1 = "tbl_Setup_CMSFieldMeasureCriteriaSet";
                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, rs_Temp);

                    //LDW if (!rs_Temp.EOF)
                    foreach (DataRow myRow1 in rs_Temp.Tables[sqlTableName1].Rows)
                    {
                        ls_JoinOp = myRow1.Field<string>("JoinOperator");

                        modGlobal.gv_sql = string.Format("UPDATE tbl_Setup_CMSFieldMeasureCriteriaSet SET JoinOperator = {0} WHERE CMSFieldMeasureID = {1}",
                            ls_JoinOp == "AND" ? "'OR'" : "'AND'", Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshFieldMeasureCriteria();
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

        private void cmdChangeToHeaderField_Click(object sender, EventArgs e)
        {
            RadListControl lstLinkedFields = new RadListControl();

            try
            {
                //LDW if (lstLinkedFields.ListIndex > -1)
                if (lstLinkedFields.SelectedItem.Index > -1)
                {
                    //change all the linked fields to link to this one instead
                    modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID =  " + lstLinkedFields.ItemData(lstLinkedFields.ListIndex);
                    modGlobal.gv_sql = string.Format("{0} set LinkToDDID =  {1}", modGlobal.gv_sql, Support.GetItemData(lstLinkedFields, lstLinkedFields.SelectedItem.Index));
                    modGlobal.gv_sql = modGlobal.gv_sql + " where LinkToDDID is not null ";
                    modGlobal.gv_sql = string.Format("{0} and ddid <> {1}", modGlobal.gv_sql, Support.GetItemData(lstLinkedFields, lstLinkedFields.SelectedItem.Index));
                    modGlobal.gv_sql = string.Format("{0} and MeasureCode  = '{1}' ", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["measurecode"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //link the pervious header field to be a linked field
                    modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                    modGlobal.gv_sql = string.Format("{0} set LinkToDDID =  {1}", modGlobal.gv_sql, Support.GetItemData(lstLinkedFields, lstLinkedFields.SelectedItem.Index));
                    modGlobal.gv_sql = string.Format("{0} where fieldmeasureid = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //make this field the header field
                    modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID = null ";
                    modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, Support.GetItemData(lstLinkedFields, lstLinkedFields.SelectedItem.Index));
                    modGlobal.gv_sql = string.Format("{0} and MeasureCode  = '{1}' ", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["measurecode"]);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshLinkedFields();
                    RefreshFieldsToLink();
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

        private void cmdDelFieldCrit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFieldsInMeasure.SelectedIndex > -1)
                {
                    if (lstFieldCriteria.SelectedIndex > -1)
                    {
                        //there are triggers on these tables to keep the set numbers and everything in order
                        modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSFieldMeasureCriteria WHERE  CMSFieldMeasureCriteriaID = " + Support.GetItemData(lstFieldCriteria, lstFieldCriteria.SelectedIndex);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                        RefreshFieldMeasureCriteria();
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFieldsInMeasure.SelectedIndex > -1)
                {
                    modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                    //        gv_sql = gv_sql & " set parentfield = "
                    //        If IsNull(cboParentField.Text) Or cboParentField.Text = "" Then
                    //            gv_sql = gv_sql & " null "
                    //        Else
                    //            gv_sql = gv_sql & " '" & cboParentField.Text & "'"
                    //        End If
                    modGlobal.gv_sql = modGlobal.gv_sql + "SET  FieldEdit = ";

                    if (Information.IsDBNull(cboFieldEdit.Text) | string.IsNullOrEmpty(cboFieldEdit.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, cboFieldEdit.Text);
                    }
                    //        gv_sql = gv_sql & ", LinkParent = "
                    //        If chkLinkToParent = 0 Then
                    //            gv_sql = gv_sql & " null "
                    //        Else
                    //            gv_sql = gv_sql & " 'Y'"
                    //        End If
                    modGlobal.gv_sql = modGlobal.gv_sql + ", OutputFormat = ";
                    if (cboOutputFormat.SelectedIndex < 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, cboOutputFormat.Text);
                    }
                    //       gv_sql = gv_sql & ", CalcParent = "
                    //       If IsNull(txtCalcParent) Or txtCalcParent = "" Then
                    //           gv_sql = gv_sql & " null "
                    //       Else
                    //           gv_sql = gv_sql & " '" & txtCalcParent & "'"
                    //       End If
                    //        gv_sql = gv_sql & ", CalcParentVal = "
                    //        If chkCalcParent = 0 Then
                    //            gv_sql = gv_sql & " null "
                    //        Else
                    //            gv_sql = gv_sql & " 'Y'"
                    //        End If
                    //        gv_sql = gv_sql & ", DefaultValue = "
                    //        If IsNull(txtDefaultValue) Or txtDefaultValue = "" Then
                    //            gv_sql = gv_sql & " null "
                    //        Else
                    //            gv_sql = gv_sql & " '" & txtDefaultValue & "'"
                    //        End If

                    modGlobal.gv_sql = string.Format("{0} where fieldmeasureid  = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //' now updated all the related fields to the same outputformat and fieldedit

                    modGlobal.gv_sql = " Update tbl_setup_cmsfieldmeasures ";
                    modGlobal.gv_sql = modGlobal.gv_sql + "SET  FieldEdit = ";
                    if (Information.IsDBNull(cboFieldEdit.Text) | string.IsNullOrEmpty(cboFieldEdit.Text))
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, cboFieldEdit.Text);
                    }

                    modGlobal.gv_sql = modGlobal.gv_sql + ", OutputFormat = ";
                    if (cboOutputFormat.SelectedIndex < 0)
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, cboOutputFormat.Text);
                    }

                    modGlobal.gv_sql = string.Format("{0} WHERE ddid in (SELECT DDID  From vuCMSFieldMeasureGroups  WHERE fieldmeasureid  = {1}) ",
                        modGlobal.gv_sql, Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        private void cmdVirtual_Click(object sender, EventArgs e)
        {
            dlgParentFields dlgParentFieldsCopy = new dlgParentFields();
            dlgParentFieldsCopy.Show();
        }

        private void frmPatientFieldsExportLinks_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshFieldsInMeasure();
                RefreshParentCDs();
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

        public void RefreshLookupTablesList()
        {
            int LookupIndex = -1;
            int thisListIndex = -1;


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
                    modGlobal.gv_sql = string.Format("{0} and (State = '{1}' or State is null)", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

                //LDW rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcTempTable = "tbl_Setup_TableDef";
                rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTempTable, rdcTemp);
                rdcTemp.AcceptChanges();

                cboLookupTbls.Items.Clear();

                //LDW while (!rdcTemp.Resultset.EOF)
                foreach (DataRow myRow2 in rdcTemp.Tables[rdcTempTable].Rows)
                {
                    thisListIndex = thisListIndex + 1;
                    cboLookupTbls.Items.Add(new ListBoxItem(myRow2.Field<string>("BaseTable"), myRow2.Field<int>("basetableid")).ToString());
                    if (!Information.IsDBNull(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["fieldLookupTableID"]))
                    {
                        if (rdcFieldList.Tables[rdcFieldListTable].Rows[0]["fieldLookupTableID"].ToString() == myRow2.Field<string>("basetableid"))
                        {
                            LookupIndex = thisListIndex;
                        }
                    }

                    //LDW rdcTemp.Resultset.MoveNext();
                }
                if (LookupIndex > -1)
                {
                    cboLookupTbls.SelectedIndex = LookupIndex;
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

        public void RefreshFieldsToLink()
        {
            RadListControl lstFieldsToLink = new RadListControl();


            try
            {
                //retrieve the list of table fields only if they are already a part of the cmsfieldmeasures
                modGlobal.gv_sql = " Select * from tbl_setup_DataDef";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = string.Format("{0} ddid <> {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID in";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select basetableid from tbl_setup_tableDef where BaseTable = 'PATIENT' )";
                modGlobal.gv_sql = modGlobal.gv_sql + " and ddid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select ddid from tbl_setup_cmsFieldMeasures";
                modGlobal.gv_sql = string.Format("{0}     where measurecode = '{1}' ", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["measurecode"]);
                modGlobal.gv_sql = modGlobal.gv_sql + "     and linktoddid is null) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and ddid  not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select linktoddid from tbl_setup_cmsFieldMeasures";
                modGlobal.gv_sql = string.Format("{0}     where measurecode = '{1}'", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["measurecode"]);
                modGlobal.gv_sql = modGlobal.gv_sql + "     and linktoddid is not null)";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";
                //gv_sql = "Select * from tbl_setup_DataDef "
                //    gv_sql = gv_sql & " where BaseTableID in "
                //    gv_sql = gv_sql & " (select basetableid from tbl_setup_tableDef where BaseTable = 'PATIENT' )"
                //    gv_sql = gv_sql & " and ddid in "
                //    gv_sql = gv_sql & " (select ddid from tbl_setup_cmsFieldMeasures "
                //    gv_sql = gv_sql & " where measurecode = '" & rdcFieldList.Resultset!measurecode & "'"
                //    gv_sql = gv_sql & " and linktoddid is null "
                //    gv_sql = gv_sql & " and ddid not in "
                //    gv_sql = gv_sql & "     (select linktoddid from tbl_setup_cmsFieldMeasures "
                //    gv_sql = gv_sql & "         where linktoddid is not null and measurecode = '" & rdcFieldList.Resultset!measurecode & "')"
                //    gv_sql = gv_sql & " )"
                //    gv_sql = gv_sql & " and ddid <> " & rdcFieldList.Resultset!ddid
                //gv_sql = gv_sql & " order by FieldName "

                //LDW rdcTemp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_setup_DataDef";
                rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, rdcTemp);
                rdcTemp.AcceptChanges();

                lstFieldsToLink.Items.Clear();
                //LDW while (!rdcTemp.Resultset.EOF)
                foreach (DataRow myRow4 in rdcTemp.Tables[rdcTempTable].Rows)
                {
                    lstFieldsToLink.Items.Add(new ListBoxItem(myRow4.Field<string>("FieldName"), myRow4.Field<int>("DDID")).ToString());
                    //LDW rdcTemp.Resultset.MoveNext();
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

        public void RefreshLinkedFields()
        {
            RadListControl lstLinkedFields = new RadListControl();


            try
            {
                //retrieve the list of table fields
                modGlobal.gv_sql = "Select df.fieldname, cms.ddid from tbl_setup_datadef as df ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_CMSFieldMeasures as cms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";
                modGlobal.gv_sql = string.Format("{0} where cms.linktoddid = {1}", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["DDID"]);
                modGlobal.gv_sql = string.Format("{0} and cms.measurecode = '{1}'", modGlobal.gv_sql, rdcFieldList.Tables[rdcFieldListTable].Rows[0]["measurecode"]);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by df.FieldName ";

                rdcTempTable = "tbl_setup_datadef";
                rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTempTable, rdcTemp);
                rdcTemp.AcceptChanges();

                lstLinkedFields.Items.Clear();
                //LDW while (!rdcTemp.Resultset.EOF)
                foreach (DataRow myRow5 in rdcTemp.Tables[rdcTempTable].Rows)
                {
                    lstLinkedFields.Items.Add(new ListBoxItem(myRow5.Field<string>("FieldName"), myRow5.Field<int>("DDID")).ToString());
                    //LDW rdcTemp.Resultset.MoveNext();
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

        private void lstFieldsInMeasure_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RadTextBox txtCalcParent = new RadTextBox();
            RadRadioButton OptShowFirst = new RadRadioButton();
            RadRadioButton OptShowEach = new RadRadioButton();


            try
            {
                modGlobal.gv_sql = "Select cms.*, df.cmsfieldcode, df.jcfieldcode, df.lookuptableid as fieldlookuptableid, CMSParentCDID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_CMSFieldMeasures cms INNER JOIN ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_DataDef df ON cms.DDID = df.DDID LEFT OUTER JOIN ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_CMSParentFieldMeasures ON cms.FieldMeasureID = tbl_Setup_CMSParentFieldMeasures.FieldMeasureID ";
                modGlobal.gv_sql = string.Format("{0} where cms.FieldMeasureID = {1}", modGlobal.gv_sql, Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));

                //LDW rdcFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcFieldListTable = "tbl_Setup_CMSFieldMeasures";
                rdcFieldList = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcFieldListTable, rdcFieldList);
                rdcFieldList.AcceptChanges();

                //RefreshFieldsToLink
                //RefreshLinkedFields
                RefreshLookupTablesList();
                //RefreshParentFields
                RefreshParentCDs();
                RefreshFieldMeasureCriteria();
                OptShowEach.IsChecked = false;
                OptShowFirst.IsChecked = false;

                if (!Information.IsDBNull(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["fieldedit"]))
                {
                    cboFieldEdit.Text = rdcFieldList.Tables[rdcFieldListTable].Rows[0]["fieldedit"].ToString();
                }
                else
                {
                    cboFieldEdit.Text = "";
                }

                if (!Information.IsDBNull(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["OutputFormat"]))
                {
                    cboOutputFormat.Text = rdcFieldList.Tables[rdcFieldListTable].Rows[0]["OutputFormat"].ToString();
                }
                else
                {
                    cboOutputFormat.Text = "";
                }

                //    If Not IsNull(rdcFieldList.Resultset!LinkParent) Then
                //        chkLinkToParent = 1
                //    Else
                //        chkLinkToParent = 0
                //    End If

                //    If Not IsNull(rdcFieldList.Resultset!CalcParent) Then
                //        chkCalcParent = 1
                //    Else
                //        chkCalcParent = 0
                //    End If
                //    If Not IsNull(rdcFieldList.Resultset!ParentField) Then
                //        cboParentField = rdcFieldList.Resultset!ParentField
                //    Else
                //        cboParentField = ""
                //    End If

                if (!Information.IsDBNull(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["CalcParent"]))
                {
                    txtCalcParent.Text = rdcFieldList.Tables[rdcFieldListTable].Rows[0]["CalcParent"].ToString();
                }
                else
                {
                    txtCalcParent.Text = "";
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

            //    If Not IsNull(rdcFieldList.Resultset!DefaultValue) Then
            //        txtDefaultValue = rdcFieldList.Resultset!DefaultValue
            //    Else
            //        txtDefaultValue = ""
            //    End If
        }

        private void RefreshParentCDs()
        {
            int li_ParentIndex = -1;

            try
            {
                //retrieve the list of Parent Fields
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_CMSParentCD ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CMSParentCD ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                const string sqlTableName6 = "tbl_setup_CMSParentCD";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                cboParentField.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    cboParentField.Items.Add(new ListBoxItem(myRow6.Field<string>("CMSParentCD"), myRow6.Field<int>("CMSParentCDID")).ToString());

                    if ((rdcFieldList != null))
                    {
                        if (!Information.IsDBNull(rdcFieldList.Tables[rdcFieldListTable].Rows[0]["CMSParentCDID"]))
                        {
                            if (rdcFieldList.Tables[rdcFieldListTable].Rows[0]["CMSParentCDID"].ToString() == myRow6.Field<string>("CMSParentCDID"))
                            {
                                li_ParentIndex = cboParentField.Items.Count - 1;
                            }
                        }
                    }

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                cboParentField.SelectedIndex = li_ParentIndex;

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

        public void RefreshFieldsInMeasure()
        {
            string FieldName = null;
            string cmsfieldcode = null;


            try
            {
                //retrieve the list of table fields only if they are already a part of the cmsfieldmeasures
                modGlobal.gv_sql = "Select cms.FieldMeasureID, cms.measurecode, df.ddid, df.fieldname, df.cmsfieldcode ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as df ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_cmsFieldMeasures as cms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by cms.measurecode, df.FieldName ";

                //LDW rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rdcTempTable = "tbl_setup_DataDef";
                rdcTemp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcTempTable, rdcTemp);
                rdcTemp.AcceptChanges();

                lstFieldsInMeasure.Items.Clear();

                //LDW while (!rdcTemp.Resultset.EOF)
                foreach (DataRow myRow7 in rdcTemp.Tables[rdcTempTable].Rows)
                {
                    if (Information.IsDBNull(myRow7.Field<string>("cmsfieldcode")))
                    {
                        cmsfieldcode = "";
                    }
                    else
                    {
                        cmsfieldcode = " ***** " + myRow7.Field<string>("cmsfieldcode");
                    }
                    FieldName = " - " + myRow7.Field<string>("FieldName");
                    lstFieldsInMeasure.Items.Add(new ListBoxItem(myRow7.Field<string>("measurecode") + FieldName + cmsfieldcode, myRow7.Field<int>("fieldmeasureid")).ToString());
                    //LDW rdcTemp.Resultset.MoveNext();
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

        private void RefreshFieldMeasureCriteria()
        {
            string ls_display = null;
            DataSet rs_Criteria = new DataSet();
            int li_SetCnt = 0;
            int li_SetIndex = 0;
            string ls_SetJoinOp = null;
            int li_MaxSet = 0;


            try
            {
                lstFieldCriteria.Items.Clear();

                modGlobal.gv_sql = string.Format("SELECT CMSFieldMeasureCriteriaSet, JoinOperator FROM tbl_Setup_CMSFieldMeasureCriteriaSet   WHERE CMSFieldMeasureID = {0} ORDER BY CMSFieldMeasureCriteriaSet",
                    Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                const string sqlTableName8 = "tbl_Setup_CMSFieldMeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count; itr++)
                {
                    var myRow8 = (DataRow)modGlobal.gv_rs.Tables[sqlTableName8].Rows[itr];
                    int rowIndex8 = modGlobal.gv_rs.Tables[sqlTableName8].Rows.IndexOf(myRow8);
                    if (rowIndex8 != modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count - 1)
                    {

                        //LDW modGlobal.gv_rs.MoveLast();
                        li_MaxSet = modGlobal.gv_rs.Tables[sqlTableName8].Rows.Count;
                        //LDW modGlobal.gv_rs.MoveFirst();

                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                        {
                            ls_SetJoinOp = myRow9.Field<string>("JoinOperator");

                            modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_CMSFieldMeasureCriteria   WHERE CMSFieldMeasureID = {0} AND  CMSFieldMeasureCriteriaSet =  {1} ORDER BY " +
                            "CMSFieldMeasureCriteriaSet, CMSFieldMeasureCriteriaID", Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex), myRow9.Field<string>("CMSFieldMeasureCriteriaSet"));

                            //LDW rs_Criteria = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                            const string sqlTableName10 = "tbl_Setup_CMSFieldMeasureCriteria";
                            rs_Criteria = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, rs_Criteria);

                            //LDW rs_Criteria.MoveLast();
                            li_SetCnt = rs_Criteria.Tables[sqlTableName10].Rows.Count;
                            //LDW rs_Criteria.MoveFirst();

                            li_SetIndex = 0;

                            ls_display = string.Format("SET {0}: ( ", myRow9.Field<int>("CMSFieldMeasureCriteriaSet"));

                            //LDW while (!rs_Criteria.EOF)
                            foreach (DataRow myRow10 in rs_Criteria.Tables[sqlTableName10].Rows)
                            {
                                li_SetIndex = li_SetIndex + 1;

                                ls_display = string.Format("{0}   {1}", ls_display, myRow10.Field<string>("CriteriaTitle"));

                                if (li_SetCnt == li_SetIndex)
                                {
                                    if (li_SetCnt == 1)
                                    {
                                        ls_display = string.Format("{0} ({1}) )", ls_display, myRow10.Field<string>("JoinOperator"));
                                    }
                                    else
                                    {
                                        ls_display = ls_display + " )";
                                    }
                                }
                                else
                                {
                                    ls_display = string.Format("{0} {1} ", ls_display, myRow10.Field<string>("JoinOperator"));
                                }

                                lstFieldCriteria.Items.Add(new ListBoxItem(ls_display, myRow10.Field<int>("CMSFieldMeasureCriteriaID")).ToString());
                                ls_display = "";

                                //LDW rs_Criteria.MoveNext();
                            }

                            rs_Criteria.Dispose();

                            if (myRow9.Field<int>("CMSFieldMeasureCriteriaSet") < li_MaxSet)
                            {
                                lstFieldCriteria.Items.Add(ls_SetJoinOp);
                            }

                            //LDW modGlobal.gv_rs.MoveNext();
                        }
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

        /*LDW Not used
         
                //Public Sub RefreshParentFields()
        //
        //    gv_sql = "Select df.ddid, df.cmsfieldcode "
        //    gv_sql = gv_sql & " from tbl_setup_datadef as df  "
        //    gv_sql = gv_sql & " where cmsfieldcode is not null and df.ddid not in "
        //    gv_sql = gv_sql & " (select ddid from tbl_Setup_CMSFieldMeasures "
        //    gv_sql = gv_sql & " where fieldmeasureid = " & lstFieldsInMeasure.ItemData(lstFieldsInMeasure.ListIndex) & ")"
        //    gv_sql = gv_sql & " order by df.cmsfieldcode "
        //    Set rdcTemp.Resultset = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //
        //    cboParentField.Clear
        //    cboCalcParentField.Clear
        //    thisListIndex = -1
        //    parentindex = -1
        //    calcparentindex = -1
        //    While Not rdcTemp.Resultset.EOF
        //        thisListIndex = thisListIndex + 1
        //        cboParentField.AddItem rdcTemp.Resultset!cmsfieldcode
        //        cboParentField.ItemData(cboParentField.NewIndex) = rdcTemp.Resultset!DDID
        //        If Not IsNull(rdcFieldList.Resultset!ParentField) Then
        //            If rdcFieldList.Resultset!ParentField = rdcTemp.Resultset!cmsfieldcode Then
        //                parentindex = thisListIndex
        //            End If
        //        End If
        //
        //        cboCalcParentField.AddItem rdcTemp.Resultset!cmsfieldcode
        //        cboCalcParentField.ItemData(cboParentField.NewIndex) = rdcTemp.Resultset!DDID
        //        If Not IsNull(rdcFieldList.Resultset!ParentField) Then
        //            If rdcFieldList.Resultset!CalcParent = rdcTemp.Resultset!cmsfieldcode Then
        //                calcparentindex = thisListIndex
        //            End If
        //        End If
        //
        //        rdcTemp.Resultset.MoveNext
        //    Wend
        //    If parentindex > -1 Then
        //        cboParentField.ListIndex = parentindex
        //    End If
        //    If calcparentindex > -1 Then
        //        cboCalcParentField.ListIndex = calcparentindex
        //    End If
        //
        //End Sub

        private void cmsAddFieldLink_Click()
        {
            object lstFieldsToLink = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldsToLink.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (lstFieldsToLink.ListIndex > -1)
            {

                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
                //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldsToLink.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldsToLink.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + lstFieldsToLink.ItemData(lstFieldsToLink.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureCode  = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "' ";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshFieldsToLink();
                RefreshLinkedFields();

            }

        }

        private void cmdRemoveFieldLink_Click()
        {
            object lstLinkedFields = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (lstLinkedFields.ListIndex > -1)
            {

                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID =  null ";
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + lstLinkedFields.ItemData(lstLinkedFields.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureCode  = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "' ";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshFieldsToLink();
                RefreshLinkedFields();

            }


        }

         
         */

    }
}
