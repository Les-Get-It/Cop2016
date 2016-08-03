using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Drawing;
using static COP2001.RadDropBinder;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmExportSetup : Telerik.WinControls.UI.RadForm
    {
        int JCVersion;
        int FileNum;
        public DataSet rdcMemoField = new DataSet();
        public string rdcMemoFieldTable = null;

        public frmExportSetup()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAddImportLayout_Click(object sender, EventArgs e)
        {
            List<Item> itemslstSelectedImportLayouts = new List<Item>();

            try
            {
                if (lstAvailableImportLayouts.SelectedIndex < 0)
                {
                    return;
                }

                itemslstSelectedImportLayouts.Add(new Item(lstAvailableImportLayouts.SelectedIndex, lstAvailableImportLayouts.Text));
                this.lstSelectedImportLayouts.DataSource = itemslstSelectedImportLayouts;
                this.lstSelectedImportLayouts.DisplayMember = "Description";
                this.lstSelectedImportLayouts.ValueMember = "Id";

                //lstSelectedImportLayouts.Items.Add(new ListBoxItem(lstAvailableImportLayouts.Text, Support.GetItemData(lstAvailableImportLayouts, lstAvailableImportLayouts.SelectedIndex)).ToString());
                RefreshImportLayout();
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

        public string TableValidationCriteria(string mainJoinOperator, string TableValidationMessageID)
        {
            string functionReturnValue = null;
            int DateFieldDDID2;
            int DateFieldDDID1;
            bool stophere;
            string thiscriteria = null;
            string DataType = null;
            string thissetcriteria = null;
            string SetJoinOperator = null;
            string thisfieldname = null;
            string msgCriteria = null;
            DataSet critrs = new DataSet();
            DataSet setrs = new DataSet();
            DataSet thisrs = new DataSet();

            try
            {
                //-build the criteria
                //-group criteria by set and then join them by the main operator
                modGlobal.gv_sql = "Select criteriaset, joinoperator  From tbl_Setup_TableValidation ";
                modGlobal.gv_sql = string.Format("{0} where TableValidationMessageID = {1}", modGlobal.gv_sql, TableValidationMessageID);
                modGlobal.gv_sql = modGlobal.gv_sql + " Group by criteriaset, joinoperator ";
                //LDW setrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_TableValidation";
                setrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, setrs);

                msgCriteria = "";

                //get the fieldname from the first validation
                thisfieldname = "";

                //LDW while (!setrs.EOF)
                foreach (DataRow myRow1 in setrs.Tables[sqlTableName1].Rows)
                {
                    modGlobal.gv_sql = "Select  tv.* ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " From tbl_Setup_TableValidation as tv ";
                    modGlobal.gv_sql = string.Format("{0} where tv.TableValidationMessageID = {1}", modGlobal.gv_sql, TableValidationMessageID);
                    modGlobal.gv_sql = string.Format("{0} and tv.criteriaset = {1}", modGlobal.gv_sql, myRow1.Field<string>("CriteriaSet"));

                    //LDW critrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName2 = "tbl_Setup_TableValidation";
                    critrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, critrs);

                    if (critrs.Tables[sqlTableName2].Rows.Count > 0)
                    {
                        SetJoinOperator = critrs.Tables[sqlTableName2].Rows[0]["JoinOperator"].ToString();
                    }

                    thissetcriteria = "";

                    //for each set find the criteria, and build this section
                    //LDW while (!critrs.EOF)
                    foreach (DataRow myRow2 in critrs.Tables[sqlTableName2].Rows)
                    {
                        modGlobal.gv_sql = "Select * From tbl_Setup_DataDef ";
                        modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, myRow2.Field<int>("SourceDDID1"));
                        //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName3 = "tbl_Setup_DataDef";
                        thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, thisrs);
                        DataType = thisrs.Tables[sqlTableName3].Rows[0]["FieldType"].ToString();

                        //A field can be compared to:
                        // blank
                        // a value
                        // another field
                        // a lookup value
                        // a value after added or subtracted from another field

                        //compare to blank
                        if (Information.IsDBNull(myRow2.Field<int>("SourceDDID2")) & Information.IsDBNull(myRow2.Field<int>("LookupID")) & myRow2.Field<string>("Value") == "Null")
                        {
                            thiscriteria = " (";
                            thiscriteria = string.Format("{0}([{1}] {2} null) ", thiscriteria, myRow2.Field<int>("SourceDDID1"),
                                myRow2.Field<string>("ValueOperator") == "=" ? " is " : " is not ");
                            thiscriteria = thiscriteria + (myRow2.Field<string>("ValueOperator") == "=" ? " Or " : " And ");
                            thiscriteria = string.Format("{0} [{1}] {2} ''", thiscriteria, myRow2.Field<int>("SourceDDID1"), myRow2.Field<string>("ValueOperator"));
                            thiscriteria = thiscriteria + " )";

                            //compare to a value, (or a lookup value), or a lookup table
                        }
                        else if (Information.IsDBNull(myRow2.Field<int>("SourceDDID2")) & Information.IsDBNull(myRow2.Field<int>("DestDDID")))
                        {
                            if (Information.IsDBNull(myRow2.Field<int>("LookupTableID")))
                            {
                                //the field has been compared to a value
                                thiscriteria = " (";
                                if (DataType == "Date")
                                {
                                    if (Strings.UCase(myRow2.Field<string>("ValueOperator")) == "IN" & Strings.UCase(myRow2.Field<string>("DateUnit")) == "M")
                                    {
                                        //4.22.05 - check that date falls within range of months
                                        thiscriteria = thiscriteria + " iif(isnull([" + myRow2.Field<int>("SourceDDID1") + "]) or [" + myRow2.Field<int>("SourceDDID1") + "] = '', false, Month( Cdate([" +
                                            myRow2.Field<int>("SourceDDID1") + "])) " + myRow2.Field<string>("ValueOperator") + " " + myRow2.Field<string>("Value") + ")";
                                    }
                                    else
                                    {
                                        thiscriteria = string.Format("{0} iif(isnull([{1}]) or [{2}] = '', false, Cdate([{3}]) {4} #{5}#)", thiscriteria, myRow2.Field<int>("SourceDDID1"),
                                            myRow2.Field<int>("SourceDDID1"), myRow2.Field<int>("SourceDDID1"), myRow2.Field<string>("ValueOperator"), myRow2.Field<string>("Value"));
                                    }
                                }
                                else if (DataType == "Number")
                                {
                                    thiscriteria = string.Format("{0} iif(isnull([{1}]) or [{2}] = '', false, cdbl([{3}]) {4} cdbl({5}))", thiscriteria, myRow2.Field<int>("SourceDDID1"),
                                        myRow2.Field<int>("SourceDDID1"), myRow2.Field<int>("SourceDDID1"), myRow2.Field<string>("ValueOperator"), myRow2.Field<string>("Value"));
                                }
                                else
                                {
                                    thiscriteria = thiscriteria + " [" + myRow2.Field<int>("SourceDDID1") + "] " + myRow2.Field<string>("ValueOperator") +
                                        " '" + myRow2.Field<string>("Value") + "'";
                                }
                                if (myRow2.Field<string>("ValueOperator") == "<>")
                                {
                                    thiscriteria = string.Format("{0} or [{1}] is null ", thiscriteria, myRow2.Field<int>("SourceDDID1"));
                                }
                                thiscriteria = thiscriteria + " )";
                            }
                            else
                            {
                                //the field has been compared to a lookup table
                                thiscriteria = string.Format("iif ([{0}] is not null and [{1}] <> '',", myRow2.Field<int>("SourceDDID1"), myRow2.Field<int>("SourceDDID1"));
                                thiscriteria = string.Format("{0} [{1}] {2}", thiscriteria, myRow2.Field<int>("SourceDDID1"), myRow2.Field<string>("ValueOperator"));
                                thiscriteria = thiscriteria + " (select iif(td.CompareToDesc = Yes, [lk.FieldValue], [lk.ID]) as lkvalue";
                                thiscriteria = thiscriteria + " from tbl_Sys_MISCLOOKUPLIST as lk ";
                                thiscriteria = thiscriteria + " inner join tbl_Sys_TableDef as td ";
                                thiscriteria = thiscriteria + " on lk.basetableid = td.basetableid ";
                                thiscriteria = string.Format("{0} where lk.basetableid = {1})", thiscriteria, myRow2.Field<int>("LookupTableID"));
                                thiscriteria = thiscriteria + ", false) ";
                            }

                            //compare to another field
                        }
                        else if (!Information.IsDBNull(myRow2.Field<int>("DestDDID")))
                        {
                            thiscriteria = " (";
                            if (DataType == "Date")
                            {
                                thiscriteria = thiscriteria + " iif(isnull([" + myRow2.Field<int>("SourceDDID1") + "]), Null, Cdate([" + myRow2.Field<int>("SourceDDID1") + "]) " +
                                    myRow2.Field<string>("ValueOperator") + " iif(isnull([" + myRow2.Field<int>("DestDDID") + "]), Null, Cdate([" + myRow2.Field<int>("DestDDID") + "])))";
                            }
                            else if (DataType == "Number")
                            {
                                thiscriteria = thiscriteria + " iif(isnull([" + myRow2.Field<int>("SourceDDID1") + "]), Null, cdbl([" + myRow2.Field<int>("SourceDDID1") + "]) " +
                                    myRow2.Field<string>("ValueOperator") + " iif(isnull([" + myRow2.Field<int>("DestDDID") + "]), Null, cdbl([" + myRow2.Field<int>("DestDDID") + "])))";
                            }
                            else if (DataType == "Time")
                            {
                                if (myRow2.Field<int>("SourceDDID1") == 289)
                                {
                                    stophere = true;
                                }
                                //find the related date field
                                modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
                                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow2.Field<int>("SourceDDID1"));
                                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName4 = "tbl_Setup_datadef";
                                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, thisrs);

                                DateFieldDDID1 = Convert.ToInt32(thisrs.Tables[sqlTableName4].Rows[0]["DateFieldDDID"]);
                                thisrs.Dispose();

                                modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
                                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow2.Field<int>("DestDDID"));
                                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName5 = "tbl_Setup_datadef";
                                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, thisrs);
                                DateFieldDDID2 = Convert.ToInt32(thisrs.Tables[sqlTableName5].Rows[0]["DateFieldDDID"]);
                                thisrs.Dispose();

                                thiscriteria = thiscriteria + "  iif ([" + myRow2.Field<int>("SourceDDID1") + "] is not null and [" + myRow2.Field<int>("SourceDDID1") + "] <> '' and [" +
                                    myRow2.Field<int>("DestDDID") + "] is not null and [" + myRow2.Field<int>("DestDDID") + "] <> '' and [" + DateFieldDDID1 + "] is not null and [" +
                                    DateFieldDDID1 + "] <> '' and [" + DateFieldDDID2 + "] is not null and [" + DateFieldDDID2 + "] <> '' , ";
                                thiscriteria = string.Format("{0} cdate([{1}] &  ' ' & [{2}]) ", thiscriteria, DateFieldDDID1, myRow2.Field<int>("SourceDDID1"));
                                thiscriteria = thiscriteria + myRow2.Field<string>("ValueOperator");
                                thiscriteria = string.Format("{0} cdate([{1}] &  ' ' & [{2}]) ", thiscriteria, DateFieldDDID2, myRow2.Field<int>("DestDDID"));
                                thiscriteria = thiscriteria + ", false) ";
                            }
                            else
                            {
                                thiscriteria = thiscriteria + " iif(isnull([" + myRow2.Field<int>("SourceDDID1") + "]), Null, [" + myRow2.Field<int>("SourceDDID1") + "] " +
                                    myRow2.Field<string>("ValueOperator") + " iif(isnull([" + myRow2.Field<int>("DestDDID") + "]), Null, [" + myRow2.Field<int>("DestDDID") + "]))";
                            }
                            thiscriteria = thiscriteria + " )";

                            //resp = InputBox("", "", thiscriteria)
                            // a value after added or subtracted from another field
                        }
                        else
                        {
                            thiscriteria = " (";
                            if (DataType == "Date")
                            {
                                thiscriteria = thiscriteria + " iif(isnull([" + myRow2.Field<int>("SourceDDID1") + "]) or isnull([" + myRow2.Field<int>("SourceDDID2") + "]), false, datediff('" +
                                    myRow2.Field<string>("DateUnit") + "', Cdate([" + myRow2.Field<int>("SourceDDID1") + "]), Cdate([" + myRow2.Field<int>("SourceDDID2") + "])) " +
                                    myRow2.Field<string>("ValueOperator") + " " + myRow2.Field<string>("Value") + ")";
                            }
                            else if (DataType == "Time")
                            {
                                //find the related date field
                                modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
                                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow2.Field<int>("SourceDDID1"));
                                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName6 = "tbl_Setup_datadef";
                                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, thisrs);

                                DateFieldDDID1 = Convert.ToInt32(thisrs.Tables[sqlTableName6].Rows[0]["DateFieldDDID"]);
                                thisrs.Dispose();

                                modGlobal.gv_sql = "select Datefieldddid from tbl_Setup_datadef ";
                                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow2.Field<int>("SourceDDID2"));
                                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                const string sqlTableName7 = "tbl_Setup_datadef";
                                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, thisrs);
                                DateFieldDDID2 = Convert.ToInt32(thisrs.Tables[sqlTableName7].Rows[0]["DateFieldDDID"]);
                                thisrs.Dispose();

                                thiscriteria = " (";
                                thiscriteria = string.Format("{0} iif ([{1}] is not null and [{2}] <> '' and [{3}] is not null and [{4}] <> '' and [{5}] is not null and [{5}] <> '' and" +
                                    "[{6}] is not null and [{6}] <> '' , ", thiscriteria, myRow2.Field<int>("SourceDDID1"), myRow2.Field<int>("SourceDDID1"),
                                    myRow2.Field<int>("SourceDDID2"), myRow2.Field<int>("SourceDDID2"), DateFieldDDID1, DateFieldDDID2);
                                thiscriteria = thiscriteria + " DateDiff('n', ";
                                thiscriteria = string.Format("{0} cdate([{1}] &  ' ' & [{2}]), ", thiscriteria, DateFieldDDID1, myRow2.Field<int>("SourceDDID1"));
                                thiscriteria = string.Format("{0} cdate([{1}] &  ' ' & [{2}]) ", thiscriteria, DateFieldDDID2, myRow2.Field<int>("SourceDDID2"));
                                thiscriteria = thiscriteria + " )";
                                thiscriteria = string.Format("{0}{1} {2}", thiscriteria, myRow2.Field<string>("ValueOperator"), myRow2.Field<string>("Value"));
                                thiscriteria = thiscriteria + ", false) ";
                                thiscriteria = thiscriteria + ") ";
                            }
                            else if (DataType == "Number")
                            {
                                thiscriteria = string.Format("{0} iif(isnull([{1}]) or isnull([{2}]), false, cdbl([{3}]) {4} cdbl([{5}]) {6} {7}", thiscriteria,
                                    myRow2.Field<int>("SourceDDID1"), myRow2.Field<int>("SourceDDID2"), myRow2.Field<int>("SourceDDID1"), myRow2.Field<string>("FieldOperator"),
                                    myRow2.Field<int>("SourceDDID2"), myRow2.Field<string>("ValueOperator"), myRow2.Field<string>("Value"));
                            }
                            thiscriteria = thiscriteria + " )";
                        }
                        if (!string.IsNullOrEmpty(thissetcriteria))
                        {
                            thissetcriteria = string.Format("{0} {1} {2}", thissetcriteria, SetJoinOperator, thiscriteria);
                        }
                        else
                        {
                            thissetcriteria = thiscriteria;
                        }
                        //LDW critrs.MoveNext();
                    }
                    critrs.Dispose();

                    if (!string.IsNullOrEmpty(msgCriteria))
                    {
                        msgCriteria = string.Format("{0} {1} ({2})", msgCriteria, mainJoinOperator, thissetcriteria);
                    }
                    else
                    {
                        msgCriteria = string.Format(" ({0}) ", thissetcriteria);
                    }

                    //LDW setrs.MoveNext();
                }
                setrs.Dispose();

                if (!string.IsNullOrEmpty(msgCriteria))
                {
                    functionReturnValue = msgCriteria;
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
            return functionReturnValue;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            string msg = null;
            string MeasLinkID;
            string MeasureSetDesc = null;
            string MeasureSetID;
            string ICDPopDDID;
            string NumberOfCasesDDID;
            string measure_catid;
            string submitSubgroupCategoryID;
            string SUBMITCLEANUPRECORDID;
            string CriteriaDesc = null;
            string SubmitCleanupCritID;
            string CleanupDesc = null;
            string SubmitCleanupID;
            string SubmitValSetG2ID;
            string SourceTable = null;
            string fieldid;
            string SubmitValSetG1ID;
            string GroupsOp = null;
            string Group2Op = null;
            string Group1Op = null;
            string submitvalsetid;
            string submitvalid = null;
            string ddid2;
            string DDID1;
            string SubmitCriteriaID;
            string AggregateFieldID;
            string submitSubgroupFieldID;
            string CalcValue = null;
            string AggregateFunction = null;
            string SubGroupID;
            string Title = null;
            string grouprowID;
            string ShowTotal = null;
            string ShowOnReport = null;
            string ShowGroupHeader = null;
            string GroupName = null;
            string FieldTypeVal = null;
            string ValidationTitle = null;
            string ValidID;
            string ValidationCount;
            string msgid;
            string OrderNumber = null;
            string ImportFieldID;
            string methodnumber = null;
            string ImportSetupID = null;
            string ImportListID = null;
            string MeasureID = null;
            string criteriaID = null;
            string OrderID = null;
            string FieldCaption = null;
            string ReportName = null;
            string ReportID = null;
            string ValType = null;
            string Operator_Renamed = null;
            string Display = null;
            string HospStatGroupID2 = null;
            string HospStatGroupID1 = null;
            string HospStatValidID = null;
            string GroupOrder = null;
            string groupid = null;
            string IndLinkID = null;
            string IndicatorSetDesc = null;
            string IndicatorSetID = null;
            string IndicatorParentID = null;
            string IndicatorDepID = null;
            string IndicatorDDID = null;
            string IndicatorGroupsetID = null;
            string AppCare = null;
            string JCCode = null;
            string EndDateTimeFieldID = null;
            string StartDateTimeFieldID = null;
            string PatientType = null;
            string MeasureSet = null;
            string CMSCode = null;
            string CMSSampleFieldDDID = null;
            string MeasureDataUsage = null;
            string BaseType = null;
            string StatewidePageOrientation = null;
            string RiskAdjustSGID = null;
            string ContinuousSGID = null;
            string IndScale = null;
            string BreakoutType = null;
            string BestPractice = null;
            string MeasureTimeBy = null;
            string EndTimeFieldID = null;
            string EndDateFieldID = null;
            string StartTimeFieldID = null;
            string StartDateFieldID = null;
            string RiskAdjusted = null;
            string CalcType = null;
            string IndicatorType = null;
            string JCAHOID = null;
            string lastupdatedate = null;
            string Description = null;
            string IndicatorID = null;
            string TableValidationAfterFieldUpdateID = null;
            string setvalue = null;
            string TableValidationActionID = null;
            string CriteriaSet = null;
            string DateUnit = null;
            string FieldOperator = null;
            string Value = null;
            string ValueOperator = null;
            string DestDDID = null;
            string SourceDDID2 = null;
            string SourceDDID1 = null;
            string CriteriaTitle = null;
            string ValidationType = null;
            string TableValidationID = null;
            string msgCriteria = null;
            string UserAction = null;
            string EffDate = null;
            string JoinOperator = null;
            string MessageType = null;
            string message = null;
            string TableValidationMessageID = null;
            string Datadefactionid = null;
            string ActionCode = null;
            string ActionDesc = null;
            string Dataentryactionid = null;
            var i = 0;
            int InActive;
            string IsPhysician = null;
            string AllowUTD = null;
            string ParentDDID = null;
            string DateFieldDDID = null;
            string OldFieldName = null;
            string Required_EffDate = null;
            string Required = null;
            string help = null;
            string LookupTableID = null;
            string FieldCategory = null;
            string fieldorder = null;
            string FieldSize = null;
            string FieldType = null;
            string FieldName = null;
            string DDID = null;
            string DisplayOrder = null;
            string GroupDescription = null;
            string indicatorgroupid = null;
            string SortOrder = null;
            string FIELDVALUE = null;
            string OldID = null;
            string Id = null;
            string LookupID = null;
            string RecordStatus = null;
            string state = null;
            int CompareToDesc;
            string OldTableName = null;
            string TableType = null;
            string BaseTable = null;
            string basetableid = null;
            string StateVersion = null;
            SqlCommand ps = new SqlCommand();
            string UpdateFile = null;
            string VersionStartDate = null;


            //every setup record in all of the tables will be imported to a text file
            //first line of each table will be tablename in [], followed by the records in the table
            // in a comma delimited format
            //resp = MsgBox("Please make sure that a diskette is inserted before creating an update. Continue?", vbOKCancel, "Create an update for Access database.")
            //If resp = vbNo Then
            //    Exit Sub
            //End If

            try
            {
                VersionStartDate = "";
                if (OptForHospitals.IsChecked == true & modGlobal.gv_selecteddatabase != "Current")
                {
                    if (string.IsNullOrEmpty(cboStartQuarter.Text) | string.IsNullOrEmpty(cboStartYear.Text))
                    {
                        RadMessageBox.Show("The Setup start date has to be defined.");
                        return;
                    }
                    else
                    {
                        if (cboStartQuarter.Text == "1")
                        {
                            VersionStartDate = "1/1/" + cboStartYear.Text;
                        }
                        else if (cboStartQuarter.Text == "2")
                        {
                            VersionStartDate = "4/1/" + cboStartYear.Text;
                        }
                        else if (cboStartQuarter.Text == "3")
                        {
                            VersionStartDate = "7/1/" + cboStartYear.Text;
                        }
                        else if (cboStartQuarter.Text == "4")
                        {
                            VersionStartDate = "10/1/" + cboStartYear.Text;
                        }
                    }
                }

                //UpdateFile = "F:\Dev\IHA\Hosp\Hosp00\COPUpdate.txt"
                if (lstSelectedImportLayouts.Items.Count == 0)
                {
                    RadMessageBox.Show("Please select at least one import layout, before exporting the setup.");
                    return;
                }

                //LDW FileFind.Text = "Specify the destination directory for COPUpdat.txt";
                //LDW FileFind.ShowDialog();
                if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory))
                {
                    UpdateFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory, Strings.Len(modGlobal.gv_SelectedDirectory), 1)
                        == "\\" ? "COPUpdat.txt" : "\\COPUpdat.txt");
                }
                else
                {
                    return;
                }

                //On Error GoTo UpdateErr
                //UpdateFile = "A:\COPUpdat.txt"

                this.Refresh();

                modGlobal.gv_sql = "{ call UpdateSavedGroupCriteriaLogic }";
                /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.Execute();
                ps.Close();*/
                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = "UpdateSavedGroupCriteriaLogic";
                SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam1.Direction = ParameterDirection.ReturnValue;
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                }
                catch (Exception exx)
                {
                    RadMessageBox.Show("Error while opening connection: " + exx.Message);
                }
                finally
                {
                    ps.Dispose();
                }

                modGlobal.gv_sql = "{ call UpdateMeasureCriteriaMultSelLogic }";
                /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.Execute();
                ps.Close();*/
                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = "UpdateMeasureCriteriaMultSelLogic";
                SqlParameter retParam2 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam2.Direction = ParameterDirection.ReturnValue;
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                }
                catch (Exception exx)
                {
                    RadMessageBox.Show("Error while opening connection: " + exx.Message);
                }
                finally
                {
                    ps.Dispose();
                }


                FileNum = FileSystem.FreeFile();
                FileSystem.FileOpen(FileNum, UpdateFile, OpenMode.Output);

                Cursor.Current = Cursors.WaitCursor;

                //if the setup is created for a specific State, the JC Version does not change
                // but the state version changes.
                //If gv_State <> "" Then
                //
                //     gv_sql = "Select max(versionNumber) as JCVersion from tbl_setup_Version"
                //     Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //     JCVersion = gv_rs!JCVersion
                //End If

                FileSystem.PrintLine(FileNum, "[VERSION]");
                if (OptForHospitals.IsChecked == true)
                {
                    if (modGlobal.gv_selecteddatabase == "Current" | modGlobal.gv_selecteddatabase == "COPWebSetup")
                    {
                        FileSystem.PrintLine(FileNum, string.Format("\"{0}\"", txtNextVersionNumber.Text));
                    }
                    else
                    {
                        FileSystem.PrintLine(FileNum, string.Format("\"{0}\"", JCVersion));
                    }
                }
                else
                {
                    FileSystem.PrintLine(FileNum, "\"" + "" + "\"");
                }

                if (!string.IsNullOrEmpty(cboStartQuarter.Text))
                {
                    FileSystem.PrintLine(FileNum, "[VERSIONSTARTDATE]");
                    if (Convert.ToDouble(cboStartQuarter.Text) == 1)
                    {
                        FileSystem.PrintLine(FileNum, string.Format("\"1/1/{0}\"", cboStartYear.Text));
                    }
                    else if (Convert.ToDouble(cboStartQuarter.Text) == 2)
                    {
                        FileSystem.PrintLine(FileNum, string.Format("\"4/1/{0}\"", cboStartYear.Text));
                    }
                    else if (Convert.ToDouble(cboStartQuarter.Text) == 3)
                    {
                        FileSystem.PrintLine(FileNum, string.Format("\"7/1/{0}\"", cboStartYear.Text));
                    }
                    else if (Convert.ToDouble(cboStartQuarter.Text) == 4)
                    {
                        FileSystem.PrintLine(FileNum, string.Format("\"10/1/{0}\"", cboStartYear.Text));
                    }
                }

                FileSystem.PrintLine(FileNum, "[STATEVERSION]");
                if (!string.IsNullOrEmpty(StateVersion))
                {
                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\"", modGlobal.gv_State, StateVersion));
                }


                //8 - 3 - 06 SR Un-necessary
                //Print #FileNum, "[TABLESTRUCTURE]"

                //OutputTableStructure

                //
                FileSystem.PrintLine(FileNum, "[TABLEDEF]");
                modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY BASETABLE";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                {
                    basetableid = "";
                    BaseTable = "";
                    TableType = "";
                    OldTableName = "";
                    CompareToDesc = 0;
                    state = "";
                    RecordStatus = "";

                    basetableid = myRow4.Field<string>("basetableid");
                    BaseTable = myRow4.Field<string>("BaseTable");

                    if (!Information.IsDBNull(myRow4.Field<string>("TableType")))
                    {
                        TableType = myRow4.Field<string>("TableType");
                    }
                    if (!Information.IsDBNull(myRow4.Field<string>("OldTableName")))
                    {
                        OldTableName = myRow4.Field<string>("OldTableName");
                    }
                    if (!Information.IsDBNull(myRow4.Field<string>("CompareToDesc")))
                    {
                        CompareToDesc = myRow4.Field<int>("CompareToDesc");
                    }
                    else
                    {
                        CompareToDesc = 0;
                    }
                    if (myRow4.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow4.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow4.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow4.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + basetableid + "\"" + "," + "\"" + BaseTable + "\"" + "," + "\"" + TableType + "\"" + "," + "\"" + OldTableName +
                        "\"" + "," + "\"" + CompareToDesc + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[MISCLOOKUPLIST]");
                modGlobal.gv_sql = "Select tbl_setup_MISCLOOKUPLIST.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_MISCLOOKUPLIST, tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where tbl_setup_MISCLOOKUPLIST.BaseTableID = tbl_setup_TableDef.BaseTableID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_TableDef.State is null or rtrim(tbl_setup_TableDef.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (tbl_setup_TableDef.State is null or tbl_setup_TableDef.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY tbl_setup_TableDef.basetableid";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_setup_MISCLOOKUPLIST";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    LookupID = "";
                    basetableid = "";
                    Id = "";
                    OldID = "";
                    FIELDVALUE = "";
                    SortOrder = "";

                    LookupID = myRow5.Field<string>("LookupID");
                    basetableid = myRow5.Field<string>("basetableid");
                    if (!Information.IsDBNull(myRow5.Field<string>("Id")))
                    {
                        Id = myRow5.Field<string>("Id");
                    }
                    if (!Information.IsDBNull(myRow5.Field<string>("OldID")))
                    {
                        OldID = myRow5.Field<string>("OldID");
                    }
                    if (!Information.IsDBNull(myRow5.Field<string>("FIELDVALUE")))
                    {
                        FIELDVALUE = myRow5.Field<string>("FIELDVALUE");
                    }
                    if (!Information.IsDBNull(myRow5.Field<string>("SortOrder")))
                    {
                        SortOrder = myRow5.Field<string>("SortOrder");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + LookupID + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + Id + "\"" + "," + "\"" + OldID + "\"" +
                        "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + SortOrder + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[INDICATORGROUP]");
                modGlobal.gv_sql = "Select * from tbl_setup_INDICATORGROUP";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY indicatorgroupid";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName9 = "tbl_setup_INDICATORGROUP";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                {
                    indicatorgroupid = "";
                    GroupDescription = "";
                    basetableid = "";
                    DisplayOrder = "";
                    state = "";
                    RecordStatus = "";

                    indicatorgroupid = myRow7.Field<string>("indicatorgroupid");
                    GroupDescription = myRow7.Field<string>("GroupDescription");
                    basetableid = myRow7.Field<string>("basetableid");
                    if (!Information.IsDBNull(myRow7.Field<string>("DisplayOrder")))
                    {
                        DisplayOrder = myRow7.Field<string>("DisplayOrder");
                    }
                    if (myRow7.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow7.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow7.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow7.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + indicatorgroupid + "\"" + "," + "\"" + GroupDescription + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" +
                        DisplayOrder + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[DATADEF]");
                //txtMemoField.Expression = "Help"
                //LDW dbgMemoField.get_Columns(0).DataField = "Message";
                dbgMemoField.Columns[0].Expression = "Message";
                modGlobal.gv_sql = "Select * from tbl_setup_DataDef";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where State is null or State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY FieldName";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName10 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                {
                    DDID = "";
                    basetableid = "";
                    FieldName = "";
                    FieldType = "";
                    FieldSize = "";
                    fieldorder = "";
                    FieldCategory = "";
                    indicatorgroupid = "";
                    LookupTableID = "";
                    help = "";
                    Required = "";
                    //
                    Required_EffDate = "";
                    OldFieldName = "";
                    SortOrder = "";
                    DateFieldDDID = "";
                    state = "";
                    RecordStatus = "";
                    ParentDDID = "";
                    AllowUTD = "";
                    IsPhysician = "";
                    InActive = 0;

                    DDID = myRow8.Field<string>("DDID");
                    basetableid = myRow8.Field<string>("basetableid");
                    FieldName = myRow8.Field<string>("FieldName");
                    if (!Information.IsDBNull(myRow8.Field<string>("FieldType")))
                    {
                        FieldType = myRow8.Field<string>("FieldType");
                    }
                    if (!Information.IsDBNull(myRow8.Field<string>("FieldSize")))
                    {
                        FieldSize = myRow8.Field<string>("FieldSize");
                    }
                    if (!Information.IsDBNull(myRow8.Field<string>("FieldCategory")))
                    {
                        FieldCategory = myRow8.Field<string>("FieldCategory");
                    }
                    if (myRow8.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow8.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow8.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow8.Field<string>("RecordStatus");
                    }
                    if (!Information.IsDBNull(myRow8.Field<string>("ParentDDID")))
                    {
                        ParentDDID = myRow8.Field<string>("ParentDDID");
                    }
                    if (!Information.IsDBNull(myRow8.Field<string>("AllowUTD")))
                    {
                        AllowUTD = myRow8.Field<string>("AllowUTD");
                    }
                    if (!Information.IsDBNull(myRow8.Field<bool>("IsPhysician")))
                    {
                        IsPhysician = (myRow8.Field<bool>("IsPhysician") ? 1 : 0).ToString();
                    }

                    //If DDID = 57 Then
                    //    test = 2
                    //End If

                    modGlobal.gv_sql = "Select Help as Message from tbl_setup_DataDef";
                    modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql, DDID);
                    //LDW rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "tbl_setup_DataDef";
                    rdcMemoField = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMemoFieldTable, rdcMemoField);
                    rdcMemoField.AcceptChanges();
                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        help = dbgMemoField.Columns[0].ToString();
                        for (i = 1; i <= Strings.Len(help); i++)
                        {
                            if (Strings.Mid(help, i, 1) == Strings.Chr(13).ToString())
                            {
                                Strings.Mid(help, i, 1).Replace(Strings.Mid(help, i, 1), "|");
                            }
                            else if (Strings.Mid(help, i, 1) == Strings.Chr(183).ToString())
                            {
                                //LDW Strings.Mid(help, i, 1) = "*";
                                Strings.Mid(help, i, 1).Replace(Strings.Mid(help, i, 1), "*");
                            }
                            else if (Strings.Mid(help, i, 1) == Strings.Chr(146).ToString() | Strings.Mid(help, i, 1) == Strings.Chr(145).ToString())
                            {
                                Strings.Mid(help, i, 1).Replace(Strings.Mid(help, i, 1), "'");
                            }
                            else if (Strings.Mid(help, i, 1) == Strings.Chr(150).ToString())
                            {
                                Strings.Mid(help, i, 1).Replace(Strings.Mid(help, i, 1), "-");
                            }
                            else if (Strings.Mid(help, i, 1) == Strings.Chr(148).ToString() | Strings.Mid(help, i, 1) == Strings.Chr(147).ToString())
                            {
                                Strings.Mid(help, i, 1).Replace(Strings.Mid(help, i, 1), "\\");
                            }
                            else if (Strings.Asc(Strings.Mid(help, i, 1)) == 233)
                            {
                                Strings.Mid(help, i, 1).Replace(Strings.Mid(help, i, 1), Strings.Mid(help, i, 1));
                            }
                            else if (Strings.Asc(Strings.Mid(help, i, 1)) > 126)
                            {
                                Strings.Mid(help, i, 1).Replace(Strings.Mid(help, i, 1), " ");
                            }
                        }
                    }
                    help = modGlobal.ConvertDoubleQuote(help);
                    //If Not IsNull(gv_rs!Help) Then
                    //    Help = gv_rs!Help
                    //End If
                    if (!Information.IsDBNull(myRow8.Field<string>("LookupTableID")))
                    {
                        LookupTableID = myRow8.Field<string>("LookupTableID");
                    }
                    if (!Information.IsDBNull(myRow8.Field<string>("OldFieldName")))
                    {
                        OldFieldName = myRow8.Field<string>("OldFieldName");
                    }

                    if (!Information.IsDBNull(myRow8.Field<string>("SortOrder")))
                    {
                        SortOrder = myRow8.Field<string>("SortOrder");
                    }

                    if (!Information.IsDBNull(myRow8.Field<string>("DateFieldDDID")))
                    {
                        DateFieldDDID = myRow8.Field<string>("DateFieldDDID");
                    }

                    if (!Information.IsDBNull(myRow8.Field<string>("Required")))
                    {
                        Required = myRow8.Field<string>("Required");
                    }
                    if (!Information.IsDBNull(myRow8.Field<string>("Required_EffDate")))
                    {
                        Required_EffDate = myRow8.Field<string>("Required_EffDate");
                    }

                    if (Information.IsDBNull(myRow8.Field<int>("InActive")))
                    {
                        InActive = 0;
                    }
                    else if (myRow8.Field<string>("InActive") == "I")
                    {
                        InActive = 1;
                    }
                    else
                    {
                        InActive = 0;
                    }

                    FileSystem.PrintLine(FileNum, "\"" + DDID + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + FieldName + "\"" + "," + "\"" + FieldType + "\"" + "," +
                        "\"" + FieldSize + "\"" + "," + "\"" + FieldCategory + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + help + "\"" + "," + "\"" + Required + "\"" +
                        "," + "\"" + Required_EffDate + "\"" + "," + "\"" + OldFieldName + "\"" + "," + "\"" + SortOrder + "\"" + "," + "\"" + DateFieldDDID + "\"" + "," + "\"" +
                        state + "\"" + "," + "\"" + RecordStatus + "\"" + "," + "\"" + ParentDDID + "\"" + "," + "\"" + AllowUTD + "\"" + "," + "\"" + IsPhysician + "\"" + "," +
                        "\"" + InActive + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //not used for Member
                FileSystem.PrintLine(FileNum, "[DATAENTRYACTIONS]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_dataentryactions  ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName12 = "tbl_setup_dataentryactions";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName12].Rows)
                {
                    Dataentryactionid = "";
                    ActionDesc = "";
                    ActionCode = "";

                    Dataentryactionid = myRow9.Field<string>("Dataentryactionid");
                    ActionDesc = myRow9.Field<string>("ActionDesc");
                    ActionCode = myRow9.Field<string>("ActionCode");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\"", Dataentryactionid, ActionDesc, ActionCode));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[DATADEFACTIONS]");
                modGlobal.gv_sql = "Select dda.*, dea.ActionDesc, dea.ActionCode ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_DataDefactions as dda ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_datadef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dda.ddid = dd.ddid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_dataentryactions as dea ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dda.dataentryactionid = dea.dataentryactionid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (dd.State is null or rtrim(dd.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where dd.State is null or dd.State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.RecordStatus = '' or dd.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY dd.DDID";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName13 = "tbl_setup_DataDefactions";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow10 in modGlobal.gv_rs.Tables[sqlTableName13].Rows)
                {
                    Datadefactionid = "";
                    Dataentryactionid = "";
                    DDID = "";
                    ActionDesc = "";
                    ActionCode = "";

                    Datadefactionid = myRow10.Field<string>("Datadefactionid");
                    Dataentryactionid = myRow10.Field<string>("Dataentryactionid");
                    DDID = myRow10.Field<string>("DDID");
                    ActionDesc = myRow10.Field<string>("ActionDesc");
                    ActionCode = myRow10.Field<string>("ActionCode");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", Datadefactionid, DDID, ActionDesc, ActionCode, Dataentryactionid));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[TABLEVALIDATIONMESSAGE]");
                dbgMemoField.Columns[0].Expression = "Message";
                modGlobal.gv_sql = "Select * from TBL_SETUP_TableValidationMessage";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " and TableValidationMessageid not in  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select tv.TableValidationMessageid  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  from TBL_SETUP_TableValidation as tv ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  where tv.Sourceddid1 not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + "  or (tv.SourceDDID2 is not null and tv.SourceDDID2 not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  or (tv.DestDDID is not null and tv.DestDDID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ORDER BY basetableid";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "TBL_SETUP_TableValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName14].Rows)
                {
                    TableValidationMessageID = "";
                    basetableid = "";
                    message = "";
                    MessageType = "";
                    JoinOperator = "";
                    state = "";
                    RecordStatus = "";
                    EffDate = "";
                    UserAction = "";


                    TableValidationMessageID = myRow11.Field<string>("TableValidationMessageID");
                    basetableid = myRow11.Field<string>("basetableid");

                    modGlobal.gv_sql = "Select Message from TBL_SETUP_TableValidationMessage";
                    modGlobal.gv_sql = string.Format("{0} where TableValidationMessageID = {1}", modGlobal.gv_sql, TableValidationMessageID);

                    //rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "TBL_SETUP_TableValidationMessage";
                    rdcMemoField.AcceptChanges();
                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        message = dbgMemoField.Columns[0].ToString();
                    }
                    message = modGlobal.ConvertDoubleQuote(message);
                    message = modGlobal.RemoveCrLfFromString(message);

                    if (!Information.IsDBNull(myRow11.Field<string>("MessageType")))
                    {
                        MessageType = myRow11.Field<string>("MessageType");
                    }
                    if (!Information.IsDBNull(myRow11.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow11.Field<string>("JoinOperator");
                    }
                    if (!Information.IsDBNull(myRow11.Field<string>("state")))
                    {
                        state = myRow11.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow11.Field<string>("EffDate")))
                    {
                        EffDate = myRow11.Field<string>("EffDate");
                    }
                    if (!Information.IsDBNull(myRow11.Field<string>("UserAction")))
                    {
                        UserAction = myRow11.Field<string>("UserAction");
                    }
                    if (myRow11.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow11.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow11.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow11.Field<string>("RecordStatus");
                    }

                    msgCriteria = TableValidationCriteria(JoinOperator, TableValidationMessageID);
                    msgCriteria = Strings.Replace(msgCriteria, "'", "|");
                    msgCriteria = modGlobal.ConvertDoubleQuote(msgCriteria);

                    FileSystem.PrintLine(FileNum, "\"" + TableValidationMessageID + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" + message + "\"" + "," + "\"" + MessageType +
                        "\"" + "," + "\"" + state + "\"" + "," + "\"" + EffDate + "\"" + "," + "\"" + UserAction + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + msgCriteria +
                        "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[TABLEVALIDATION]");
                modGlobal.gv_sql = "Select tv.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  TBL_SETUP_TableValidation as tv ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join TBL_SETUP_TableValidationMessage as tvm ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  on tv.TableValidationMessageid = tvm.TableValidationMessageid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or rtrim(tvm.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (tvm.State is null or tvm.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tvm.RecordStatus = '' or tvm.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and tv.Sourceddid1 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and (tv.SourceDDID2 is null or tv.SourceDDID2 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and (tv.DestDDID is null or tv.DestDDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY tablevalidationid";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName15 = "TBL_SETUP_TableValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName15, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow12 in modGlobal.gv_rs.Tables[sqlTableName15].Rows)
                {
                    TableValidationID = "";
                    TableValidationMessageID = "";
                    ValidationType = "";
                    CriteriaTitle = "";
                    SourceDDID1 = "";
                    SourceDDID2 = "";
                    DestDDID = "";
                    ValueOperator = "";
                    Value = "";
                    LookupID = "";
                    LookupTableID = "";
                    FieldOperator = "";
                    DateUnit = "";
                    JoinOperator = "";
                    CriteriaSet = "";

                    TableValidationID = myRow12.Field<string>("TableValidationID");
                    TableValidationMessageID = myRow12.Field<string>("TableValidationMessageID");
                    ValidationType = myRow12.Field<string>("ValidationType");
                    CriteriaTitle = myRow12.Field<string>("CriteriaTitle");
                    SourceDDID1 = myRow12.Field<string>("SourceDDID1");
                    if (!Information.IsDBNull(myRow12.Field<string>("SourceDDID2")))
                    {
                        SourceDDID2 = myRow12.Field<string>("SourceDDID2");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("DestDDID")))
                    {
                        DestDDID = myRow12.Field<string>("DestDDID");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("ValueOperator")))
                    {
                        ValueOperator = myRow12.Field<string>("ValueOperator");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("Value")))
                    {
                        Value = myRow12.Field<string>("Value");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("LookupID")))
                    {
                        LookupID = myRow12.Field<string>("LookupID");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("LookupTableID")))
                    {
                        LookupTableID = myRow12.Field<string>("LookupTableID");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("FieldOperator")))
                    {
                        FieldOperator = myRow12.Field<string>("FieldOperator");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("DateUnit")))
                    {
                        DateUnit = myRow12.Field<string>("DateUnit");
                    }
                    if (!Information.IsDBNull(myRow12.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow12.Field<string>("JoinOperator");
                    }
                    CriteriaSet = myRow12.Field<string>("CriteriaSet");

                    FileSystem.PrintLine(FileNum, "\"" + TableValidationID + "\"" + "," + "\"" + TableValidationMessageID + "\"" + "," + "\"" + ValidationType + "\"" + "," +
                        "\"" + CriteriaTitle + "\"" + "," + "\"" + SourceDDID1 + "\"" + "," + "\"" + SourceDDID2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" +
                        ValueOperator + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator +
                        "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[TABLEVALIDATIONACTION]");
                modGlobal.gv_sql = "Select tva.* from TBL_SETUP_TableValidationAction as tva ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join TBL_SETUP_TableValidationMessage as tvm ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  on tva.TableValidationMessageid = tvm.TableValidationMessageid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or rtrim(tvm.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (tvm.State is null or tvm.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tvm.RecordStatus = '' or tvm.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and tva.ddid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY DDID";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName16 = "TBL_SETUP_TableValidationAction";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow13 in modGlobal.gv_rs.Tables[sqlTableName16].Rows)
                {
                    TableValidationActionID = "";
                    TableValidationMessageID = "";
                    DDID = "";
                    setvalue = "";

                    TableValidationActionID = myRow13.Field<string>("TableValidationActionID");
                    TableValidationMessageID = myRow13.Field<string>("TableValidationMessageID");
                    DDID = myRow13.Field<string>("DDID");
                    setvalue = myRow13.Field<string>("setvalue");

                    FileSystem.PrintLine(FileNum, "\"" + TableValidationActionID + "\"" + "," + "\"" + TableValidationMessageID + "\"" + "," + "\"" + DDID + "\"" +
                        "," + "\"" + setvalue + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[TABLEVALIDATIONAFTERFIELDUPDATE]");
                modGlobal.gv_sql = "Select tvafu.* from TBL_SETUP_TableValidationAfterfieldupdate as tvafu ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join TBL_SETUP_TableValidationMessage as tvm ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  on tvafu.TableValidationMessageid = tvm.TableValidationMessageid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (tvm.State is null or rtrim(tvm.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (tvm.State is null or tvm.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tvm.RecordStatus = '' or tvm.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY DDID";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "TBL_SETUP_TableValidationAfterfieldupdate";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName17, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow14 in modGlobal.gv_rs.Tables[sqlTableName17].Rows)
                {
                    TableValidationAfterFieldUpdateID = "";
                    TableValidationMessageID = "";
                    DDID = "";

                    TableValidationAfterFieldUpdateID = myRow14.Field<string>("TableValidationAfterFieldUpdateID");
                    TableValidationMessageID = myRow14.Field<string>("TableValidationMessageID");
                    DDID = myRow14.Field<string>("DDID");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\"", TableValidationAfterFieldUpdateID, TableValidationMessageID, DDID));
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                FileSystem.PrintLine(FileNum, "[INDICATOR]");
                modGlobal.gv_sql = "Select i.*, MeasureSetDesc  = (SELECT TOP 1 ms.MeasureSetDesc " + " FROM tbl_setup_MeasureSet ms, tbl_setup_measureSetMapmeas mm " +
                    " Where ms.MeasureSetID = mm.MeasureSetID " + " and mm.IndicatorID = i.IndicatorID ) " + " from tbl_setup_INDICATOR i WHERE 1=1 ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (i.State is null or rtrim(i.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and i.State is null or i.State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY i.Description";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName18 = "tbl_setup_INDICATOR";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName18, modGlobal.gv_rs);

                string line = null;
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow15 in modGlobal.gv_rs.Tables[sqlTableName18].Rows)
                {
                    IndicatorID = "";
                    Description = "";
                    OldFieldName = "";
                    state = "";
                    RecordStatus = "";
                    lastupdatedate = "";
                    JCAHOID = "";
                    IndicatorType = "";
                    CalcType = "";
                    RiskAdjusted = "";
                    StartDateFieldID = "";
                    StartTimeFieldID = "";
                    EndDateFieldID = "";
                    EndTimeFieldID = "";
                    MeasureTimeBy = "";
                    BestPractice = "";
                    BreakoutType = "";
                    IndScale = "";
                    ContinuousSGID = "";
                    RiskAdjustSGID = "";
                    StatewidePageOrientation = "";
                    BaseType = "";
                    MeasureDataUsage = "";
                    //1.19.2005 - SampleFieldDDID
                    CMSSampleFieldDDID = "";
                    CMSCode = "";
                    MeasureSet = "";
                    PatientType = "";
                    StartDateTimeFieldID = "";
                    EndDateTimeFieldID = "";
                    JCCode = "";
                    AppCare = "";

                    IndicatorID = myRow15.Field<string>("IndicatorID");
                    Description = myRow15.Field<string>("Description");
                    OldFieldName = myRow15.Field<string>("OldFieldName");


                    if (myRow15.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow15.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow15.Field<string>("RecordStatus");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("lastupdatedate")))
                    {
                        lastupdatedate = myRow15.Field<string>("lastupdatedate");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("JCAHOID")))
                    {
                        JCAHOID = myRow15.Field<string>("JCAHOID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("IndicatorType")))
                    {
                        IndicatorType = myRow15.Field<string>("IndicatorType");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("CalcType")))
                    {
                        CalcType = myRow15.Field<string>("CalcType");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("RiskAdjusted")))
                    {
                        RiskAdjusted = myRow15.Field<string>("RiskAdjusted");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("StartDateFieldID")))
                    {
                        StartDateFieldID = myRow15.Field<string>("StartDateFieldID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("StartTimeFieldID")))
                    {
                        StartTimeFieldID = myRow15.Field<string>("StartTimeFieldID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("EndDateFieldID")))
                    {
                        EndDateFieldID = myRow15.Field<string>("EndDateFieldID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("EndTimeFieldID")))
                    {
                        EndTimeFieldID = myRow15.Field<string>("EndTimeFieldID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("EndTimeFieldID")))
                    {
                        EndTimeFieldID = myRow15.Field<string>("EndTimeFieldID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("MeasureTimeBy")))
                    {
                        MeasureTimeBy = myRow15.Field<string>("MeasureTimeBy");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("BestPractice")))
                    {
                        BestPractice = myRow15.Field<string>("BestPractice");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("BreakoutType")))
                    {
                        BreakoutType = myRow15.Field<string>("BreakoutType");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("Scale")))
                    {
                        IndScale = myRow15.Field<string>("Scale");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("ContinuousSGID")))
                    {
                        ContinuousSGID = myRow15.Field<string>("ContinuousSGID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("RiskAdjustSGID")))
                    {
                        RiskAdjustSGID = myRow15.Field<string>("RiskAdjustSGID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("StatewidePageOrientation")))
                    {
                        StatewidePageOrientation = myRow15.Field<string>("StatewidePageOrientation");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("BaseType")))
                    {
                        BaseType = myRow15.Field<string>("BaseType");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("MeasureDataUsage")))
                    {
                        MeasureDataUsage = myRow15.Field<string>("MeasureDataUsage");
                    }

                    //1.20.05 - added cmscode
                    if (!Information.IsDBNull(myRow15.Field<string>("CMSSampleFieldDDID")))
                    {
                        CMSSampleFieldDDID = myRow15.Field<string>("CMSSampleFieldDDID");
                    }
                    if (!Information.IsDBNull(myRow15.Field<string>("CMSCode")))
                    {
                        CMSCode = myRow15.Field<string>("CMSCode");
                    }

                    if (!Information.IsDBNull(myRow15.Field<string>("MeasureSetDesc")))
                    {
                        MeasureSet = myRow15.Field<string>("MeasureSetDesc");

                        if (Strings.InStr(MeasureSet, "Non-Core") > 0)
                        {
                            MeasureSet = "Non-Core";
                        }

                    }

                    if (!Information.IsDBNull(myRow15.Field<string>("PatientType")))
                    {
                        PatientType = myRow15.Field<string>("PatientType");
                    }

                    if (!Information.IsDBNull(myRow15.Field<string>("StartDateTimeFieldID")))
                    {
                        StartDateTimeFieldID = myRow15.Field<string>("StartDateTimeFieldID");
                    }

                    if (!Information.IsDBNull(myRow15.Field<string>("EndDateTimeFieldID")))
                    {
                        EndDateTimeFieldID = myRow15.Field<string>("EndDateTimeFieldID");
                    }

                    if (!Information.IsDBNull(myRow15.Field<string>("JCCode")))
                    {
                        JCCode = myRow15.Field<string>("JCCode");
                    }

                    if (!Information.IsDBNull(myRow15.Field<bool>("AppCare")))
                    {
                        AppCare = (myRow15.Field<bool>("AppCare") ? 1 : 0).ToString();
                    }

                    line = "\"" + IndicatorID + "\"" + "," + "\"" + Description + "\"" + "," + "\"" + OldFieldName + "\"" + "," + "\"" + state + "\"" + "," + "\"" +
                        RecordStatus + "\"" + "," + "\"" + lastupdatedate + "\"" + "," + "\"" + JCAHOID + "\"" + "," + "\"" + IndicatorType + "\"" + "," + "\"" +
                        CalcType + "\"" + "," + "\"" + RiskAdjusted + "\"" + "," + "\"" + StartDateFieldID + "\"" + "," + "\"" + StartTimeFieldID + "\"" + "," +
                        "\"" + EndDateFieldID + "\"" + "," + "\"" + EndTimeFieldID + "\"" + "," + "\"" + MeasureTimeBy + "\"" + "," + "\"" + BestPractice + "\"" +
                        "," + "\"" + BreakoutType + "\"" + "," + "\"" + IndScale + "\"" + "," + "\"" + ContinuousSGID + "\"" + "," + "\"" + RiskAdjustSGID + "\"" +
                        "," + "\"" + StatewidePageOrientation + "\"" + "," + "\"" + BaseType + "\"" + "," + "\"" + MeasureDataUsage + "\"" + "," + "\"" +
                        CMSSampleFieldDDID + "\"" + "," + "\"" + CMSCode + "\"" + "," + "\"" + MeasureSet + "\"";

                    line = string.Format("{0},\"{1}\"", line, PatientType);
                    line = string.Format("{0},\"{1}\"", line, StartDateTimeFieldID);
                    line = string.Format("{0},\"{1}\"", line, EndDateTimeFieldID);
                    line = string.Format("{0},\"{1}\"", line, JCCode);
                    line = string.Format("{0},\"{1}\"", line, AppCare);

                    FileSystem.PrintLine(FileNum, line);


                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[INDICATORGROUPSET]");
                modGlobal.gv_sql = "Select igs.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_INDICATORGroupSet as igs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_indicatorgroup as ig ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on igs.indicatorgroupid = ig.indicatorgroupid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on igs.DDID = dd.DDID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State is null or rtrim(dd.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ig.State is null or ig.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                    modGlobal.gv_sql = string.Format("{0} and (dd.State is null or dd.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.RecordStatus = '' or dd.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName19 = "tbl_setup_INDICATORGroupSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName19, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow16 in modGlobal.gv_rs.Tables[sqlTableName19].Rows)
                {
                    IndicatorGroupsetID = "";
                    indicatorgroupid = "";
                    DDID = "";
                    fieldorder = "";

                    IndicatorGroupsetID = myRow16.Field<string>("IndicatorGroupsetID");
                    indicatorgroupid = myRow16.Field<string>("indicatorgroupid");
                    DDID = myRow16.Field<string>("DDID");
                    fieldorder = myRow16.Field<string>("fieldorder");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", IndicatorGroupsetID, indicatorgroupid, DDID, fieldorder));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[DATAREQ]");
                modGlobal.gv_sql = "Select dr.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_DataReq as dr ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Indicator as i ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dr.IndicatorID = i.IndicatorID) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_DataDef as dd ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on dr.DDID = dd.DDID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or rtrim(i.state) = '') ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State is null or rtrim(dd.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or i.State = '" + modGlobal.gv_State + "')";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.State is null or dd.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.Recordstatus is null) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (dd.RecordStatus = '' or dd.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY dd.DDID";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_DataReq";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow17 in modGlobal.gv_rs.Tables[sqlTableName20].Rows)
                {
                    IndicatorDDID = "";
                    IndicatorID = "";
                    DDID = "";

                    IndicatorDDID = myRow17.Field<string>("IndicatorDDID");
                    IndicatorID = myRow17.Field<string>("IndicatorID");
                    DDID = myRow17.Field<string>("DDID");
                    FileSystem.PrintLine(FileNum, "\"" + IndicatorDDID + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + DDID + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[INDICATORDEP]");
                modGlobal.gv_sql = "Select idep.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_IndicatorDep as idep ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Indicator as i ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on idep.IndicatorParentID =  i.IndicatorID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or rtrim(i.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (i.State is null or i.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (i.RecordStatus = '' or i.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName21 = "tbl_setup_IndicatorDep";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow18 in modGlobal.gv_rs.Tables[sqlTableName21].Rows)
                {
                    IndicatorDepID = "";
                    IndicatorParentID = "";
                    IndicatorID = "";

                    IndicatorDepID = myRow18.Field<string>("IndicatorDepID");
                    IndicatorParentID = myRow18.Field<string>("IndicatorParentID");
                    IndicatorID = myRow18.Field<string>("IndicatorID");
                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\"", IndicatorDepID, IndicatorParentID, IndicatorID));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[INDICATORSET]");
                modGlobal.gv_sql = "Select * from tbl_setup_IndicatorSet";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where State is null or State = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_setup_IndicatorSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow20 in modGlobal.gv_rs.Tables[sqlTableName22].Rows)
                {
                    IndicatorSetID = "";
                    IndicatorSetDesc = "";
                    state = "";
                    RecordStatus = "";

                    IndicatorSetID = myRow20.Field<string>("IndicatorSetID");
                    IndicatorSetDesc = myRow20.Field<string>("IndicatorSetDesc");
                    if (myRow20.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow20.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow20.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow20.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", IndicatorSetID, IndicatorSetDesc, state, RecordStatus));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[INDICATORSETFIELD]");
                modGlobal.gv_sql = "Select indsf.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_IndicatorSetFIELD as indsf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorSet as inds ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on indsf.indicatorsetid = inds.indicatorsetid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Indicator as ind ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on indsf.indicatorid = ind.indicatorid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (inds.State is null or rtrim(inds.state) = '') ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ind.State is null or rtrim(ind.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (inds.State is null or inds.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                    modGlobal.gv_sql = string.Format("{0} and (ind.State is null or ind.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (inds.RecordStatus = '' or inds.Recordstatus is null) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ind.RecordStatus = '' or ind.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName23 = "tbl_setup_IndicatorSetFIELD";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow21 in modGlobal.gv_rs.Tables[sqlTableName23].Rows)
                {
                    IndLinkID = "";
                    IndicatorID = "";
                    IndicatorSetID = "";

                    IndLinkID = myRow21.Field<string>("IndLinkID");
                    IndicatorID = myRow21.Field<string>("IndicatorID");
                    IndicatorSetID = myRow21.Field<string>("IndicatorSetID");
                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\"", IndLinkID, IndicatorID, IndicatorSetID));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[HOSPSTATGROUP]");
                modGlobal.gv_sql = "Select hsp.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup hsp ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorGroup as ig ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsp.indicatorgroupid = ig.indicatorgroupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ig.State is null or ig.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName24 = "tbl_setup_HospStatGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow22 in modGlobal.gv_rs.Tables[sqlTableName24].Rows)
                {
                    groupid = "";
                    indicatorgroupid = "";
                    GroupDescription = "";
                    GroupOrder = "";

                    groupid = myRow22.Field<string>("HospStatGroupID");
                    indicatorgroupid = myRow22.Field<string>("indicatorgroupid");
                    GroupDescription = myRow22.Field<string>("GroupDescription");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\"", groupid, indicatorgroupid, GroupDescription));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[HOSPSTATGROUPINDICATOR]");
                modGlobal.gv_sql = "Select hgi.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_HospStatGroupIndicator as hgi";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_HospStatGroup as hsg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hgi.HospStatGroupID = hsg.HospStatGroupID) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_IndicatorGroup as ig ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ig.State is null or ig.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName25 = "tbl_setup_HospStatGroupIndicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow23 in modGlobal.gv_rs.Tables[sqlTableName25].Rows)
                {
                    groupid = "";
                    IndicatorID = "";

                    groupid = myRow23.Field<string>("HospStatGroupID");
                    IndicatorID = myRow23.Field<string>("IndicatorID");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\"", groupid, IndicatorID));
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                //hosp stat group validation
                FileSystem.PrintLine(FileNum, "[HOSPSTATVAL]");
                dbgMemoField.Columns[0].Expression = "Message";

                modGlobal.gv_sql = " Select hsv.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatVal as hsv";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where";
                modGlobal.gv_sql = modGlobal.gv_sql + " hsv.HospStatGroupID1 in";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select hsg.HospStatGroupID";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup as hsg";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorGroup as ig";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ig.State is null or ig.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                modGlobal.gv_sql = modGlobal.gv_sql + " and hsv.HospStatGroupID2 in";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select hsg.HospStatGroupID";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_HospStatGroup as hsg";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_IndicatorGroup as ig";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ig.State is null or ig.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName26 = "tbl_setup_HospStatVal";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow24 in modGlobal.gv_rs.Tables[sqlTableName26].Rows)
                {
                    HospStatValidID = "";
                    HospStatGroupID1 = "";
                    HospStatGroupID2 = "";
                    Display = "";
                    Operator_Renamed = "";
                    message = "";
                    ValType = "";
                    EffDate = "";

                    HospStatValidID = myRow24.Field<string>("HospStatValidID");
                    HospStatGroupID1 = myRow24.Field<string>("HospStatGroupID1");
                    HospStatGroupID2 = myRow24.Field<string>("HospStatGroupID2");
                    ValType = myRow24.Field<string>("Type");
                    Display = myRow24.Field<string>("Display");
                    Operator_Renamed = myRow24.Field<string>("Operator");

                    modGlobal.gv_sql = "Select Message from tbl_setup_HospStatVal";
                    modGlobal.gv_sql = string.Format("{0} where HospStatValidID = {1}", modGlobal.gv_sql, HospStatValidID);
                    //LDW rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "tbl_setup_HospStatVal";
                    rdcMemoField = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMemoFieldTable, rdcMemoField);
                    rdcMemoField.AcceptChanges();
                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        message = dbgMemoField.Columns[0].ToString();
                    }
                    message = modGlobal.ConvertDoubleQuote(message);

                    if (!Information.IsDBNull(myRow24.Field<string>("EffDate")))
                    {
                        EffDate = myRow24.Field<string>("EffDate");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + HospStatValidID + "\"" + "," + "\"" + HospStatGroupID1 + "\"" + "," + "\"" + HospStatGroupID2 + "\"" + "," + "\"" +
                        Display + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + message + "\"" + "," + "\"" + EffDate + "\"" + "," + "\"" + ValType + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[HOSPSTATGROUPFIELDS]");
                modGlobal.gv_sql = "Select hsgf.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (tbl_setup_HospStatGroupFields as hsgf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_HospStatGroup as hsg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsgf.HospStatGroupID = hsg.HospStatGroupID) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join  tbl_setup_IndicatorGroup as ig ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on hsg.indicatorgroupid = ig.indicatorgroupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ig.State is null or rtrim(ig.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ig.State is null or ig.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ig.RecordStatus = '' or ig.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName27 = "tbl_setup_HospStatGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow25 in modGlobal.gv_rs.Tables[sqlTableName27].Rows)
                {
                    groupid = "";
                    DDID = "";
                    fieldorder = "";

                    groupid = myRow25.Field<string>("HospStatGroupID");
                    DDID = myRow25.Field<string>("DDID");
                    fieldorder = myRow25.Field<string>("fieldorder");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\"", groupid, DDID, fieldorder));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTS]");
                modGlobal.gv_sql = "Select * from tbl_setup_SavedAdhocReports";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "ORDER BY Report_Name";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName28 = "tbl_setup_SavedAdhocReports";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow26 in modGlobal.gv_rs.Tables[sqlTableName28].Rows)
                {
                    ReportID = "";
                    ReportName = "";
                    basetableid = "";
                    JoinOperator = "";
                    state = "";
                    RecordStatus = "";

                    ReportID = myRow26.Field<string>("Report_ID");
                    ReportName = myRow26.Field<string>("Report_name");
                    basetableid = myRow26.Field<string>("basetableid");
                    JoinOperator = myRow26.Field<string>("JoinOperator");
                    if (myRow26.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow26.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow26.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow26.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + ReportID + "\"" + "," + "\"" + ReportName + "\"" + "," + "\"" + basetableid + "\"" + "," + "\"" +
                        JoinOperator + "\"" + "," + "\"" + "Y" + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTFIELDS]");
                modGlobal.gv_sql = "Select arf.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportFields as arf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SavedAdhocReports as ar ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on arf.Report_ID = ar.Report_ID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or rtrim(ar.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ar.State is null or ar.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ar.RecordStatus = '' or ar.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and arf.ddid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName29 = "tbl_setup_SavedAdhocReportFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow27 in modGlobal.gv_rs.Tables[sqlTableName29].Rows)
                {
                    ReportID = "";
                    DDID = "";
                    FieldCaption = "";
                    OrderID = "";

                    ReportID = myRow27.Field<string>("Report_ID");
                    DDID = myRow27.Field<string>("DDID");
                    FieldCaption = myRow27.Field<string>("FieldCaption");
                    OrderID = myRow27.Field<string>("OrderID");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", ReportID, DDID, FieldCaption, OrderID));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTCRITERIA]");
                modGlobal.gv_sql = "Select arc.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportCriteria as arc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SavedAdhocReports as ar ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on arc.Report_ID = ar.Report_ID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or rtrim(ar.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ar.State is null or ar.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ar.RecordStatus = '' or ar.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and arc.Sourceddid1 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and (arc.SourceDDID2 is null or arc.SourceDDID2 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and (arc.DestDDID is null or arc.DestDDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName30 = "tbl_setup_SavedAdhocReportCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName30, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow28 in modGlobal.gv_rs.Tables[sqlTableName30].Rows)
                {
                    criteriaID = "";
                    ReportID = "";
                    CriteriaTitle = "";
                    SourceDDID1 = "";
                    SourceDDID2 = "";
                    DestDDID = "";
                    ValueOperator = "";
                    Value = "";
                    LookupID = "";
                    LookupTableID = "";
                    FieldOperator = "";
                    DateUnit = "";
                    JoinOperator = "";
                    CriteriaSet = "";

                    criteriaID = myRow28.Field<string>("criteriaID");
                    ReportID = myRow28.Field<string>("Report_ID");
                    CriteriaTitle = myRow28.Field<string>("CriteriaTitle");
                    SourceDDID1 = myRow28.Field<string>("SourceDDID1");
                    if (!Information.IsDBNull(myRow28.Field<string>("SourceDDID2")))
                    {
                        SourceDDID2 = myRow28.Field<string>("SourceDDID2");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("DestDDID")))
                    {
                        DestDDID = myRow28.Field<string>("DestDDID");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("ValueOperator")))
                    {
                        ValueOperator = myRow28.Field<string>("ValueOperator");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("Value")))
                    {
                        Value = myRow28.Field<string>("Value");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("LookupID")))
                    {
                        LookupID = myRow28.Field<string>("LookupID");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("LookupTableID")))
                    {
                        LookupTableID = myRow28.Field<string>("LookupTableID");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("FieldOperator")))
                    {
                        FieldOperator = myRow28.Field<string>("FieldOperator");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("DateUnit")))
                    {
                        DateUnit = myRow28.Field<string>("DateUnit");
                    }
                    if (!Information.IsDBNull(myRow28.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow28.Field<string>("JoinOperator");
                    }
                    CriteriaSet = myRow28.Field<string>("CriteriaSet");

                    FileSystem.PrintLine(FileNum, "\"" + criteriaID + "\"" + "," + "\"" + ReportID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" +
                        SourceDDID1 + "\"" + "," + "\"" + SourceDDID2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" +
                        Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" +
                        DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SAVEDADHOCREPORTSUMCRITERIA]");
                modGlobal.gv_sql = "Select arc.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SavedAdhocReportSumCriteria as arc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_SavedAdhocReports as ar ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on arc.Report_ID = ar.Report_ID ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ar.State is null or rtrim(ar.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ar.State is null or ar.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (ar.RecordStatus = '' or ar.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName31 = "tbl_setup_SavedAdhocReportSumCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName31, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow29 in modGlobal.gv_rs.Tables[sqlTableName31].Rows)
                {
                    criteriaID = "";
                    ReportID = "";
                    CriteriaTitle = "";
                    IndicatorID = "";
                    Operator_Renamed = "";
                    MeasureID = "";
                    JoinOperator = "";
                    CriteriaSet = "";

                    criteriaID = myRow29.Field<string>("criteriaID");
                    ReportID = myRow29.Field<string>("Report_ID");
                    CriteriaTitle = myRow29.Field<string>("CriteriaTitle");
                    IndicatorID = myRow29.Field<string>("IndicatorID");
                    if (!Information.IsDBNull(myRow29.Field<string>("Operator")))
                    {
                        Operator_Renamed = myRow29.Field<string>("Operator");
                    }
                    if (!Information.IsDBNull(myRow29.Field<string>("MeasureID")))
                    {
                        MeasureID = myRow29.Field<string>("MeasureID");
                    }
                    if (!Information.IsDBNull(myRow29.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow29.Field<string>("JoinOperator");
                    }
                    CriteriaSet = myRow29.Field<string>("CriteriaSet");

                    FileSystem.PrintLine(FileNum, "\"" + criteriaID + "\"" + "," + "\"" + ReportID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" +
                        IndicatorID + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + MeasureID + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                ImportListID = "";
                for (i = 0; i <= lstSelectedImportLayouts.Items.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(ImportListID))
                    {
                        ImportListID = Support.GetItemData(lstSelectedImportLayouts, i).ToString();
                    }
                    else
                    {
                        ImportListID = string.Format("{0},{1}", ImportListID, Support.GetItemData(lstSelectedImportLayouts, i));
                    }
                }
                ImportListID = string.Format("({0})", ImportListID);


                //Not for Member
                FileSystem.PrintLine(FileNum, "[IMPORTALLSETUP]");
                modGlobal.gv_sql = "Select * from TBL_SETUP_IMPORTSetup ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName32 = "TBL_SETUP_IMPORTSetup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName32, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow31 in modGlobal.gv_rs.Tables[sqlTableName32].Rows)
                {
                    ImportSetupID = "";
                    methodnumber = "";
                    Description = "";
                    state = "";
                    RecordStatus = "";

                    ImportSetupID = myRow31.Field<string>("ImportSetupID");
                    methodnumber = myRow31.Field<string>("methodnumber");
                    Description = myRow31.Field<string>("Description");
                    if (myRow31.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow31.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow31.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow31.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + ImportSetupID + "\"" + "," + "\"" + methodnumber + "\"" + "," + "\"" + Description + "\"" + "," +
                        "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //Not for member
                FileSystem.PrintLine(FileNum, "[IMPORTALLFIELDS]");
                modGlobal.gv_sql = "Select imf.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_IMPORTFIELDS as imf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ims.State is null or ims.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and imf.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName34 = "TBL_SETUP_IMPORTFIELDS";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName34, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow32 in modGlobal.gv_rs.Tables[sqlTableName34].Rows)
                {
                    ImportFieldID = "";
                    ImportSetupID = "";
                    DDID = "";
                    OrderNumber = "";

                    ImportSetupID = myRow32.Field<string>("ImportSetupID");
                    DDID = myRow32.Field<string>("DDID");
                    OrderNumber = myRow32.Field<string>("OrderNumber");
                    ImportFieldID = myRow32.Field<string>("ImportFieldID");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", ImportSetupID, DDID, OrderNumber, ImportFieldID));

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //Not for Member
                FileSystem.PrintLine(FileNum, "[IMPORTALLVALIDATIONMESSAGE]");
                dbgMemoField.Columns[0].Expression = "Message";
                modGlobal.gv_sql = "Select imvm.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_IMPORTValidationMessage as imvm ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ims.State is null or ims.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and imvm.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName35 = "TBL_SETUP_IMPORTValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName35, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow33 in modGlobal.gv_rs.Tables[sqlTableName35].Rows)
                {
                    DDID = "";
                    msgid = "";
                    message = "";
                    ValidationCount = "";
                    ValidationType = "";
                    JoinOperator = "";
                    ImportFieldID = "";

                    DDID = myRow33.Field<string>("DDID");
                    msgid = myRow33.Field<string>("msgid");
                    ImportFieldID = myRow33.Field<string>("ImportFieldID");
                    if (!Information.IsDBNull(myRow33.Field<string>("ValidationCount")))
                    {
                        ValidationCount = myRow33.Field<string>("ValidationCount");
                    }
                    ValidationType = myRow33.Field<string>("ValidationType");
                    if (!Information.IsDBNull(myRow33.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow33.Field<string>("JoinOperator");
                    }

                    modGlobal.gv_sql = "Select Message from tbl_setup_ImportValidationMessage";
                    modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, msgid);

                    //LDW rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "tbl_setup_ImportValidationMessage";
                    rdcMemoField = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMemoFieldTable, rdcMemoField);
                    rdcMemoField.AcceptChanges();
                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        message = dbgMemoField.Columns[0].ToString();
                    }
                    message = modGlobal.ConvertDoubleQuote(message);

                    FileSystem.PrintLine(FileNum, "\"" + DDID + "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + message + "\"" + "," + "\"" + ValidationCount + "\"" +
                        "," + "\"" + ValidationType + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + ImportFieldID + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //Not for Member
                FileSystem.PrintLine(FileNum, "[IMPORTALLVALIDATION]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_IMPORTValidation as imv ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTValidationMessage as imvm ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imv.msgid = imvm.msgid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ims.State is null or ims.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and imv.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName36 = "TBL_SETUP_IMPORTValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName36, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow34 in modGlobal.gv_rs.Tables[sqlTableName36].Rows)
                {
                    ValidID = "";
                    DDID = "";
                    LookupTableID = "";
                    ValidationTitle = "";
                    msgid = "";
                    FieldTypeVal = "";
                    Operator_Renamed = "";
                    FIELDVALUE = "";
                    FieldType = "";

                    ValidID = myRow34.Field<string>("ValidID");
                    DDID = myRow34.Field<string>("DDID");
                    LookupTableID = myRow34.Field<string>("LookupTableID");
                    ValidationTitle = myRow34.Field<string>("ValidationTitle");
                    msgid = myRow34.Field<string>("msgid");
                    FieldTypeVal = myRow34.Field<string>("FieldTypeVal");
                    Operator_Renamed = myRow34.Field<string>("Operator");
                    FIELDVALUE = myRow34.Field<string>("FIELDVALUE");
                    FieldType = myRow34.Field<string>("FieldType");

                    FileSystem.PrintLine(FileNum, "\"" + ValidID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" +
                        ValidationTitle + "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + FieldTypeVal + "\"" + "," + "\"" + Operator_Renamed + "\"" +
                        "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + FieldType + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }


                //Patient Import Specs
                FileSystem.PrintLine(FileNum, "[IMPORTSETUP]");
                modGlobal.gv_sql = "Select * from TBL_SETUP_IMPORTSetup ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and importsetupid in {1}", modGlobal.gv_sql, ImportListID);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName37 = "TBL_SETUP_IMPORTSetup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName37, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow35 in modGlobal.gv_rs.Tables[sqlTableName37].Rows)
                {
                    ImportSetupID = "";
                    methodnumber = "";
                    Description = "";
                    state = "";
                    RecordStatus = "";

                    ImportSetupID = myRow35.Field<string>("ImportSetupID");
                    methodnumber = myRow35.Field<string>("methodnumber");
                    Description = myRow35.Field<string>("Description");
                    if (myRow35.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow35.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow35.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow35.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + ImportSetupID + "\"" + "," + "\"" + methodnumber + "\"" + "," + "\"" + Description + "\"" +
                        "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[IMPORTFIELDS]");
                modGlobal.gv_sql = "Select imf.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_IMPORTFIELDS as imf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ims.State is null or ims.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and ims.importsetupid in {1}", modGlobal.gv_sql, ImportListID);
                modGlobal.gv_sql = modGlobal.gv_sql + "  and imf.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName38 = "TBL_SETUP_IMPORTFIELDS";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName38, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow36 in modGlobal.gv_rs.Tables[sqlTableName38].Rows)
                {
                    ImportFieldID = "";
                    ImportSetupID = "";
                    DDID = "";
                    OrderNumber = "";

                    ImportSetupID = myRow36.Field<string>("ImportSetupID");
                    DDID = myRow36.Field<string>("DDID");
                    OrderNumber = myRow36.Field<string>("OrderNumber");
                    ImportFieldID = myRow36.Field<string>("ImportFieldID");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", ImportSetupID, DDID, OrderNumber, ImportFieldID));
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[IMPORTVALIDATIONMESSAGE]");
                dbgMemoField.Columns[0].Expression = "Message";
                modGlobal.gv_sql = "Select imvm.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_IMPORTValidationMessage as imvm ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ims.State is null or ims.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and ims.importsetupid in {1}", modGlobal.gv_sql, ImportListID);
                modGlobal.gv_sql = modGlobal.gv_sql + " and imvm.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";

                //g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName39 = "TBL_SETUP_IMPORTValidationMessage";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName39, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow37 in modGlobal.gv_rs.Tables[sqlTableName39].Rows)
                {
                    DDID = "";
                    msgid = "";
                    message = "";
                    ValidationCount = "";
                    ValidationType = "";
                    JoinOperator = "";
                    ImportFieldID = "";

                    DDID = myRow37.Field<string>("DDID");
                    msgid = myRow37.Field<string>("msgid");
                    ImportFieldID = myRow37.Field<string>("ImportFieldID");
                    if (!Information.IsDBNull(myRow37.Field<string>("ValidationCount")))
                    {
                        ValidationCount = myRow37.Field<string>("ValidationCount");
                    }
                    ValidationType = myRow37.Field<string>("ValidationType");
                    if (!Information.IsDBNull(myRow37.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow37.Field<string>("JoinOperator");
                    }

                    modGlobal.gv_sql = "Select Message from tbl_setup_ImportValidationMessage";
                    modGlobal.gv_sql = string.Format("{0} where MSGID = {1}", modGlobal.gv_sql, msgid);

                    //LDW rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "tbl_setup_ImportValidationMessage";
                    rdcMemoField = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMemoFieldTable, rdcMemoField);
                    rdcMemoField.AcceptChanges();
                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        message = dbgMemoField.Columns[0].ToString();
                    }
                    message = modGlobal.ConvertDoubleQuote(message);

                    FileSystem.PrintLine(FileNum, "\"" + DDID + "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + message + "\"" + "," + "\"" + ValidationCount +
                        "\"" + "," + "\"" + ValidationType + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + ImportFieldID + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[IMPORTVALIDATION]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_IMPORTValidation as imv ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTValidationMessage as imvm ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imv.msgid = imvm.msgid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTFIELDS as imf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imvm.importfieldid = imf.importfieldid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_IMPORTSetup as ims ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on imf.importsetupid = ims.importsetupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (ims.State is null or rtrim(ims.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (ims.State is null or ims.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = string.Format("{0} and ims.importsetupid in {1}", modGlobal.gv_sql, ImportListID);
                modGlobal.gv_sql = modGlobal.gv_sql + "  and imv.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName40 = "TBL_SETUP_IMPORTValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName40, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow38 in modGlobal.gv_rs.Tables[sqlTableName40].Rows)
                {
                    ValidID = "";
                    DDID = "";
                    LookupTableID = "";
                    ValidationTitle = "";
                    msgid = "";
                    FieldTypeVal = "";
                    Operator_Renamed = "";
                    FIELDVALUE = "";
                    FieldType = "";

                    ValidID = myRow38.Field<string>("ValidID");
                    DDID = myRow38.Field<string>("DDID");
                    LookupTableID = myRow38.Field<string>("LookupTableID");
                    ValidationTitle = myRow38.Field<string>("ValidationTitle");
                    msgid = myRow38.Field<string>("msgid");
                    FieldTypeVal = myRow38.Field<string>("FieldTypeVal");
                    Operator_Renamed = myRow38.Field<string>("Operator");
                    FIELDVALUE = myRow38.Field<string>("FIELDVALUE");
                    FieldType = myRow38.Field<string>("FieldType");

                    FileSystem.PrintLine(FileNum, "\"" + ValidID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + ValidationTitle +
                        "\"" + "," + "\"" + msgid + "\"" + "," + "\"" + FieldTypeVal + "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + FIELDVALUE + "\"" +
                        "," + "\"" + FieldType + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }


                FileSystem.PrintLine(FileNum, "[SUBMITGROUP]");
                modGlobal.gv_sql = "Select * from TBL_SETUP_SubmitGroup";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName41 = "TBL_SETUP_SubmitGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName41, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow39 in modGlobal.gv_rs.Tables[sqlTableName41].Rows)
                {
                    groupid = "";
                    GroupName = "";
                    ShowGroupHeader = "";
                    OrderNumber = "";
                    ShowOnReport = "";
                    state = "";
                    RecordStatus = "";
                    ShowTotal = "";

                    groupid = myRow39.Field<string>("groupid");
                    GroupName = myRow39.Field<string>("GroupName");
                    if (!Information.IsDBNull(myRow39.Field<string>("ShowGroupHeader")))
                    {
                        ShowGroupHeader = myRow39.Field<string>("ShowGroupHeader");
                    }
                    if (!Information.IsDBNull(myRow39.Field<string>("OrderNumber")))
                    {
                        OrderNumber = myRow39.Field<string>("OrderNumber");
                    }
                    if (!Information.IsDBNull(myRow39.Field<string>("ShowOnReport")))
                    {
                        ShowOnReport = myRow39.Field<string>("ShowOnReport");
                    }
                    if (myRow39.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow39.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow39.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow39.Field<string>("RecordStatus");
                    }
                    if (!Information.IsDBNull(myRow39.Field<string>("ShowTotal")))
                    {
                        ShowTotal = myRow39.Field<string>("ShowTotal");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + groupid + "\"" + "," + "\"" + GroupName + "\"" + "," + "\"" + ShowGroupHeader + "\"" + "," + "\"" + OrderNumber + "\"" +
                        "," + "\"" + ShowOnReport + "\"" + "," + "\"" + ShowTotal + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITGROUPROW]");
                modGlobal.gv_sql = "Select sgr.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitGroupRow as sgr ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (sg.State is null or sg.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName42 = "TBL_SETUP_SubmitGroupRow";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName42, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow40 in modGlobal.gv_rs.Tables[sqlTableName42].Rows)
                {
                    grouprowID = "";
                    groupid = "";
                    Title = "";
                    OrderNumber = "";
                    ShowOnReport = "";

                    grouprowID = myRow40.Field<string>("grouprowID");
                    groupid = myRow40.Field<string>("groupid");
                    Title = myRow40.Field<string>("Title");

                    if (!Information.IsDBNull(myRow40.Field<string>("OrderNumber")))
                    {
                        OrderNumber = myRow40.Field<string>("OrderNumber");
                    }
                    if (!Information.IsDBNull(myRow40.Field<string>("ShowOnReport")))
                    {
                        ShowOnReport = myRow40.Field<string>("ShowOnReport");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + grouprowID + "\"" + "," + "\"" + groupid + "\"" + "," + "\"" + Title + "\"" + "," + "\"" + OrderNumber + "\"" +
                        "," + "\"" + ShowOnReport + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITSUBGROUP]");
                modGlobal.gv_sql = "Select ssg.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_SubmitSubGroup as ssg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitGroupRow as sgr ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ssg.grouprowid = sgr.grouprowid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (sg.State is null or sg.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName43 = "TBL_SETUP_SubmitSubGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName43, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow41 in modGlobal.gv_rs.Tables[sqlTableName43].Rows)
                {
                    SubGroupID = "";
                    grouprowID = "";
                    Title = "";
                    IndicatorID = "";
                    AggregateFunction = "";
                    CalcValue = "";
                    OrderNumber = "";
                    ShowOnReport = "";
                    JoinOperator = "";

                    SubGroupID = myRow41.Field<string>("SubGroupID");
                    grouprowID = myRow41.Field<string>("grouprowID");
                    Title = myRow41.Field<string>("Title");
                    IndicatorID = myRow41.Field<string>("IndicatorID");
                    AggregateFunction = myRow41.Field<string>("AggregateFunction");
                    CalcValue = myRow41.Field<string>("CalcValue");
                    if (!Information.IsDBNull(myRow41.Field<string>("OrderNumber")))
                    {
                        OrderNumber = myRow41.Field<string>("OrderNumber");
                    }
                    if (!Information.IsDBNull(myRow41.Field<string>("ShowOnReport")))
                    {
                        ShowOnReport = myRow41.Field<string>("ShowOnReport");
                    }
                    if (!Information.IsDBNull(myRow41.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow41.Field<string>("JoinOperator");
                    }
                    else
                    {
                        JoinOperator = "And";
                    }


                    FileSystem.PrintLine(FileNum, "\"" + SubGroupID + "\"" + "," + "\"" + grouprowID + "\"" + "," + "\"" + Title + "\"" + "," + "\"" + IndicatorID +
                        "\"" + "," + "\"" + AggregateFunction + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + OrderNumber + "\"" + "," + "\"" + ShowOnReport + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITSUBGROUPFIELDS]");
                modGlobal.gv_sql = "Select ssgf.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_SubmitSubGroupFields as ssgf ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitSubGroup as ssg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ssgf.subgroupid = ssg.subgroupid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitGroupRow as sgr ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ssg.grouprowid = sgr.grouprowid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (sg.State is null or sg.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and ssgf.AggregateFieldID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName44 = "TBL_SETUP_SubmitSubGroupFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName44, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow42 in modGlobal.gv_rs.Tables[sqlTableName44].Rows)
                {
                    submitSubgroupFieldID = "";
                    SubGroupID = "";
                    AggregateFieldID = "";

                    submitSubgroupFieldID = myRow42.Field<string>("submitSubgroupFieldID");
                    SubGroupID = myRow42.Field<string>("SubGroupID");
                    AggregateFieldID = myRow42.Field<string>("AggregateFieldID");

                    FileSystem.PrintLine(FileNum, "\"" + submitSubgroupFieldID + "\"" + "," + "\"" + SubGroupID + "\"" + "," + "\"" + AggregateFieldID + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITCRITERIA]");
                modGlobal.gv_sql = "Select sc.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from ((TBL_SETUP_SubmitCriteria as sc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitSubGroup as ssg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sc.subgroupid = ssg.subgroupid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitGroupRow as sgr ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on ssg.grouprowid = sgr.grouprowid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_submitgroup as sg ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on sgr.groupid  = sg.groupid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or rtrim(sg.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sg.State is null or sg.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sg.RecordStatus = '' or sg.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(sc.DDID1 is null or sc.DDID1 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and";
                modGlobal.gv_sql = modGlobal.gv_sql + "(sc.DDID2 is null or sc.DDID2 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(sc.DestDDID is null or sc.DestDDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName45 = "TBL_SETUP_SubmitCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName45, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow43 in modGlobal.gv_rs.Tables[sqlTableName45].Rows)
                {
                    SubmitCriteriaID = "";
                    SubGroupID = "";
                    CriteriaTitle = "";
                    DDID1 = "";
                    ddid2 = "";
                    DestDDID = "";
                    ValueOperator = "";
                    Value = "";
                    LookupID = "";
                    LookupTableID = "";
                    FieldOperator = "";
                    DateUnit = "";
                    JoinOperator = "";
                    CriteriaSet = "";

                    SubmitCriteriaID = myRow43.Field<string>("SubmitCriteriaID");
                    SubGroupID = myRow43.Field<string>("SubGroupID");
                    CriteriaTitle = myRow43.Field<string>("CriteriaTitle");
                    DDID1 = myRow43.Field<string>("DDID1");
                    if (!Information.IsDBNull(myRow43.Field<string>("ddid2")))
                    {
                        ddid2 = myRow43.Field<string>("ddid2");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("DestDDID")))
                    {
                        DestDDID = myRow43.Field<string>("DestDDID");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("ValueOperator")))
                    {
                        ValueOperator = myRow43.Field<string>("ValueOperator");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("Value")))
                    {
                        Value = myRow43.Field<string>("Value");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("LookupID")))
                    {
                        LookupID = myRow43.Field<string>("LookupID");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("LookupTableID")))
                    {
                        LookupTableID = myRow43.Field<string>("LookupTableID");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("FieldOperator")))
                    {
                        FieldOperator = myRow43.Field<string>("FieldOperator");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("DateUnit")))
                    {
                        DateUnit = myRow43.Field<string>("DateUnit");
                    }
                    if (!Information.IsDBNull(myRow43.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow43.Field<string>("JoinOperator");
                    }
                    CriteriaSet = myRow43.Field<string>("CriteriaSet");

                    FileSystem.PrintLine(FileNum, "\"" + SubmitCriteriaID + "\"" + "," + "\"" + SubGroupID + "\"" + "," + "\"" + CriteriaTitle + "\"" +
                        "," + "\"" + DDID1 + "\"" + "," + "\"" + ddid2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," +
                        "\"" + Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," +
                        "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //remove any validation that is defined for a non-existing indicator
                modGlobal.gv_sql = " Delete from TBL_SETUP_SubmitValSetGroup1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalsetid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select svs.submitvalsetid ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     from  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     TBL_SETUP_SubmitValSet as svs ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     inner join TBL_SETUP_SubmitValidation as sv ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     on svs.submitvalid = sv.submitvalid ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " Delete from TBL_SETUP_SubmitValSetGroup2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalsetid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select svs.submitvalsetid ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     from  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     TBL_SETUP_SubmitValSet as svs ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     inner join TBL_SETUP_SubmitValidation as sv ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     on svs.submitvalid = sv.submitvalid ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                modGlobal.gv_sql = " Delete from TBL_SETUP_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where submitvalid in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (Select submitvalid ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     from  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     TBL_SETUP_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ) ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //corrective action
                //Value and ValueOperator were switched when all the fields where
                // in the same group (from the same table), and compared to a value
                modGlobal.gv_sql = " Update TBL_SETUP_SubmitValSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set [Value] = ValueOperator, ";
                modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator = [Value]  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where [Value] is not null  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " and isnumeric([Value]) = 0 ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = " Delete TBL_SETUP_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     where indicatorid not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "     (select indicatorid from tbl_setup_indicator) ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                FileSystem.PrintLine(FileNum, "[SUBMITVALIDATION]");

                dbgMemoField.Columns[0].Expression = "Message";
                modGlobal.gv_sql = "Select * from TBL_SETUP_SubmitValidation";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName46 = "TBL_SETUP_SubmitValidation";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName46, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow44 in modGlobal.gv_rs.Tables[sqlTableName46].Rows)
                {
                    submitvalid = "";
                    IndicatorID = "";
                    message = "";
                    ValType = "";
                    JoinOperator = "";
                    state = "";
                    RecordStatus = "";

                    submitvalid = myRow44.Field<string>("submitvalid");
                    IndicatorID = myRow44.Field<string>("IndicatorID");

                    modGlobal.gv_sql = "Select Message from TBL_SETUP_SubmitValidation";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValID = " + submitvalid;
                    //LDW rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "TBL_SETUP_SubmitValidation";
                    rdcMemoField = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMemoFieldTable, rdcMemoField);
                    rdcMemoField.AcceptChanges();

                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        message = dbgMemoField.Columns[0].ToString();
                    }
                    message = modGlobal.ConvertDoubleQuote(message);

                    if (!Information.IsDBNull(myRow44.Field<string>("ValType")))
                    {
                        ValType = myRow44.Field<string>("ValType");
                    }
                    if (!Information.IsDBNull(myRow44.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow44.Field<string>("JoinOperator");
                    }
                    if (myRow44.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow44.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow44.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow44.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + submitvalid + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + message + "\"" + "," + "\"" + ValType + "\"" +
                        "," + "\"" + JoinOperator + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITVALSET]");
                dbgMemoField.Columns[0].Expression = "Message";
                modGlobal.gv_sql = "Select svs.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitValSet as svs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join  TBL_SETUP_SubmitValidation as sv ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on svs.submitvalid = sv.submitvalid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or rtrim(sv.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or sv.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sv.RecordStatus = '' or sv.Recordstatus is null) ";
                }

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName47 = "TBL_SETUP_SubmitValSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName47, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow45 in modGlobal.gv_rs.Tables[sqlTableName47].Rows)
                {
                    submitvalsetid = "";
                    submitvalid = "";
                    Description = "";
                    Group1Op = "";
                    Group2Op = "";
                    GroupsOp = "";
                    Value = "";
                    ValueOperator = "";

                    submitvalsetid = myRow45.Field<string>("submitvalsetid");
                    submitvalid = myRow45.Field<string>("submitvalid");

                    modGlobal.gv_sql = "Select Description as Message from TBL_SETUP_SubmitValSet ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitValSetID = " + submitvalsetid;
                    //LDW rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "TBL_SETUP_SubmitValSet";
                    rdcMemoField = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, rdcMemoFieldTable, rdcMemoField);
                    rdcMemoField.AcceptChanges();
                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        Description = dbgMemoField.Columns[0].ToString();
                    }

                    if (!Information.IsDBNull(myRow45.Field<string>("Group1Op")))
                    {
                        Group1Op = myRow45.Field<string>("Group1Op");
                    }
                    if (!Information.IsDBNull(myRow45.Field<string>("Group2Op")))
                    {
                        Group2Op = myRow45.Field<string>("Group2Op");
                    }
                    if (!Information.IsDBNull(myRow45.Field<string>("GroupsOp")))
                    {
                        GroupsOp = myRow45.Field<string>("GroupsOp");
                    }
                    if (!Information.IsDBNull(myRow45.Field<string>("Value")))
                    {
                        Value = myRow45.Field<string>("Value");
                    }
                    if (!Information.IsDBNull(myRow45.Field<string>("ValueOperator")))
                    {
                        ValueOperator = myRow45.Field<string>("ValueOperator");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + submitvalsetid + "\"" + "," + "\"" + submitvalid + "\"" + "," + "\"" + Description + "\"" +
                        "," + "\"" + Group1Op + "\"" + "," + "\"" + Group2Op + "\"" + "," + "\"" + GroupsOp + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + ValueOperator + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITVALSETGROUP1]");
                modGlobal.gv_sql = "Select svsg1.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_SubmitValSetGroup1 as svsg1 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitValSet as svs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on svsg1.submitvalsetid = svs.submitvalsetid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join  TBL_SETUP_SubmitValidation as sv ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on svs.submitvalid = sv.submitvalid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or rtrim(sv.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or sv.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sv.RecordStatus = '' or sv.Recordstatus is null) ";
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName49 = "TBL_SETUP_SubmitValSetGroup1";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName49, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow47 in modGlobal.gv_rs.Tables[sqlTableName49].Rows)
                {
                    SubmitValSetG1ID = "";
                    submitvalsetid = "";
                    fieldid = "";
                    SourceTable = "";

                    SubmitValSetG1ID = myRow47.Field<string>("SubmitValSetG1ID");
                    submitvalsetid = myRow47.Field<string>("submitvalsetid");
                    fieldid = myRow47.Field<string>("fieldid");
                    SourceTable = myRow47.Field<string>("SourceTable");

                    FileSystem.PrintLine(FileNum, "\"" + SubmitValSetG1ID + "\"" + "," + "\"" + submitvalsetid + "\"" + "," + "\"" + fieldid + "\"" + "," + "\"" + SourceTable + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITVALSETGROUP2]");
                modGlobal.gv_sql = "Select svsg2.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from (TBL_SETUP_SubmitValSetGroup2 as svsg2 ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitValSet as svs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on svsg2.submitvalsetid = svs.submitvalsetid) ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join  TBL_SETUP_SubmitValidation as sv ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on svs.submitvalid = sv.submitvalid ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or rtrim(sv.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sv.State is null or sv.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sv.RecordStatus = '' or sv.Recordstatus is null) ";
                }
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName48 = "TBL_SETUP_SubmitValSetGroup2";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName48, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow48 in modGlobal.gv_rs.Tables[sqlTableName48].Rows)
                {
                    SubmitValSetG2ID = "";
                    submitvalsetid = "";
                    fieldid = "";
                    SourceTable = "";

                    SubmitValSetG2ID = myRow48.Field<string>("SubmitValSetG2ID");
                    submitvalsetid = myRow48.Field<string>("submitvalsetid");
                    fieldid = myRow48.Field<string>("fieldid");
                    SourceTable = myRow48.Field<string>("SourceTable");

                    FileSystem.PrintLine(FileNum, "\"" + SubmitValSetG2ID + "\"" + "," + "\"" + submitvalsetid + "\"" + "," + "\"" + fieldid + "\"" + "," + "\"" + SourceTable + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITCLEANUPITEMS]");
                modGlobal.gv_sql = " select sci.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitCleanupItems as sci ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or rtrim(sci.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or sci.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sci.RecordStatus = '' or sci.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and sci.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName51 = "TBL_SETUP_SubmitCleanupItems";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName51, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow49 in modGlobal.gv_rs.Tables[sqlTableName51].Rows)
                {
                    SubmitCleanupID = "";
                    CleanupDesc = "";
                    DDID = "";
                    state = "";
                    RecordStatus = "";

                    SubmitCleanupID = myRow49.Field<string>("SubmitCleanupID");
                    if (!Information.IsDBNull(myRow49.Field<string>("CleanupDesc")))
                    {
                        CleanupDesc = myRow49.Field<string>("CleanupDesc");
                    }
                    DDID = myRow49.Field<string>("DDID");
                    if (myRow49.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow49.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow49.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow49.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + SubmitCleanupID + "\"" + "," + "\"" + CleanupDesc + "\"" + "," + "\"" + DDID + "\"" + ", " + "\"" +
                        state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITCLEANUPCRIT]");
                dbgMemoField.Columns[0].Expression = "Message";
                modGlobal.gv_sql = " select scc.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_SubmitCleanupcrit as scc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join TBL_SETUP_SubmitCleanupItems as sci ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on scc.submitcleanupid = sci.submitcleanupid";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or rtrim(sci.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (sci.State is null or sci.State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (sci.RecordStatus = '' or sci.Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and scc.DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName52 = "TBL_SETUP_SubmitCleanupcrit";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName52, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow50 in modGlobal.gv_rs.Tables[sqlTableName52].Rows)
                {
                    SubmitCleanupCritID = "";
                    SubmitCleanupID = "";
                    DDID = "";
                    FIELDVALUE = "";
                    Operator_Renamed = "";
                    LookupTableID = "";
                    JoinOperator = "";
                    CriteriaDesc = "";

                    SubmitCleanupCritID = myRow50.Field<string>("SubmitCleanupCritID");
                    SubmitCleanupID = myRow50.Field<string>("SubmitCleanupID");
                    DDID = myRow50.Field<string>("DDID");
                    FIELDVALUE = myRow50.Field<string>("FIELDVALUE");
                    Operator_Renamed = myRow50.Field<string>("Operator");
                    if (!Information.IsDBNull(myRow50.Field<string>("LookupTableID")))
                    {
                        LookupTableID = myRow50.Field<string>("LookupTableID");
                    }
                    if (!Information.IsDBNull(myRow50.Field<string>("JoinOperator")))
                    {
                        JoinOperator = myRow50.Field<string>("JoinOperator");
                    }

                    modGlobal.gv_sql = "Select CriteriaDesc as Message from TBL_SETUP_SubmitCleanupCrit";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where SubmitCleanupCritID = " + SubmitCleanupCritID;
                    //LDW rdcMemoField.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    rdcMemoFieldTable = "TBL_SETUP_SubmitCleanupCrit";
                    rdcMemoField = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName52, rdcMemoField);
                    rdcMemoField.AcceptChanges();
                    dbgMemoField.Refresh();
                    if (!Information.IsDBNull(dbgMemoField.Columns[0]))
                    {
                        CriteriaDesc = dbgMemoField.Columns[0].ToString();
                    }
                    CriteriaDesc = modGlobal.ConvertDoubleQuote(CriteriaDesc);

                    FileSystem.PrintLine(FileNum, "\"" + SubmitCleanupCritID + "\"" + "," + "\"" + SubmitCleanupID + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + FIELDVALUE +
                        "\"" + "," + "\"" + Operator_Renamed + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaDesc + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[SUBMITCLEANUPRECORD]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from TBL_SETUP_Submitcleanuprecord ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = ''  or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and DDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or State = '" + modGlobal.gv_State + "')";
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName53 = "TBL_SETUP_Submitcleanuprecord";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName53, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow51 in modGlobal.gv_rs.Tables[sqlTableName53].Rows)
                {
                    SUBMITCLEANUPRECORDID = "";
                    CriteriaTitle = "";
                    DDID = "";
                    ValueOperator = "";
                    Value = "";
                    LookupID = "";
                    JoinOperator = "";
                    CriteriaSet = "";
                    state = "";
                    RecordStatus = "";

                    SUBMITCLEANUPRECORDID = myRow51.Field<string>("SUBMITCLEANUPRECORDID");
                    CriteriaTitle = myRow51.Field<string>("CriteriaTitle");
                    DDID = myRow51.Field<string>("DDID");
                    ValueOperator = myRow51.Field<string>("ValueOperator");
                    Value = myRow51.Field<string>("Value");
                    if (!Information.IsDBNull(myRow51.Field<string>("LookupID")))
                    {
                        LookupID = myRow51.Field<string>("LookupID");
                    }
                    JoinOperator = myRow51.Field<string>("JoinOperator");
                    CriteriaSet = myRow51.Field<string>("CriteriaSet");
                    if (myRow51.Field<string>("state") == modGlobal.gv_State)
                    {
                        state = myRow51.Field<string>("state");
                    }
                    if (!Information.IsDBNull(myRow51.Field<string>("RecordStatus")))
                    {
                        RecordStatus = myRow51.Field<string>("RecordStatus");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + SUBMITCLEANUPRECORDID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + Value + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + CriteriaSet + "\"" + "," + "\"" + state + "\"" + "," + "\"" + RecordStatus + "\"");
                    //LDW  modGlobal.gv_rs.MoveNext();
                }

                //data from tbl_Setup_SubmitSubGroupCategory
                FileSystem.PrintLine(FileNum, "[SUBMITSUBGROUPCATEGORY]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitSubGroupCategory ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName54 = "tbl_Setup_SubmitSubGroupCategory";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName54, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow52 in modGlobal.gv_rs.Tables[sqlTableName54].Rows)
                {
                    submitSubgroupCategoryID = "";
                    SubGroupID = "";
                    measure_catid = "";

                    submitSubgroupCategoryID = myRow52.Field<string>("submitSubgroupCategoryID");
                    SubGroupID = myRow52.Field<string>("SubGroupID");
                    measure_catid = myRow52.Field<string>("measure_catid");

                    FileSystem.PrintLine(FileNum, "\"" + submitSubgroupCategoryID + "\"" + "," + "\"" + SubGroupID + "\"" + "," + "\"" + measure_catid + "\"");

                    //LDW  modGlobal.gv_rs.MoveNext();
                }


                OutputMeasureVerificationTables();

                OutputIndicatorReportSetup();

                //data for Number of Cases (Used only in HOME)
                FileSystem.PrintLine(FileNum, "[INDICATORNUMBEROFCASES]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorNumberOfCases ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName55 = "tbl_Setup_IndicatorNumberOfCases";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName55, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow53 in modGlobal.gv_rs.Tables[sqlTableName55].Rows)
                {
                    IndicatorID = "";
                    NumberOfCasesDDID = "";

                    IndicatorID = myRow53.Field<string>("IndicatorID");
                    NumberOfCasesDDID = myRow53.Field<string>("NumberOfCasesDDID");

                    FileSystem.PrintLine(FileNum, "\"" + IndicatorID + "\"" + "," + "\"" + NumberOfCasesDDID + "\"");

                    //LDW  modGlobal.gv_rs.MoveNext();
                }

                OutputRelatedGroupLogic();

                //data for ICD Population (Used only in HOME)
                FileSystem.PrintLine(FileNum, "[INDICATORICDPOP]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorICDPOP ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName56 = "tbl_Setup_IndicatorICDPOP";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName56, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow54 in modGlobal.gv_rs.Tables[sqlTableName56].Rows)
                {
                    IndicatorID = "";
                    ICDPopDDID = "";

                    IndicatorID = myRow54.Field<string>("IndicatorID");
                    ICDPopDDID = myRow54.Field<string>("ICDPopDDID");

                    FileSystem.PrintLine(FileNum, "\"" + IndicatorID + "\"" + "," + "\"" + ICDPopDDID + "\"");

                    //LDW  modGlobal.gv_rs.MoveNext();
                }

                //data for Measure Set Linkagge 4.9.2009
                FileSystem.PrintLine(FileNum, "[MEASURESET]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureSet ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName57 = "tbl_Setup_MeasureSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName57, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow55 in modGlobal.gv_rs.Tables[sqlTableName57].Rows)
                {
                    MeasureSetID = "";
                    MeasureSetDesc = "";

                    MeasureSetID = myRow55.Field<string>("MeasureSetID");
                    MeasureSetDesc = myRow55.Field<string>("MeasureSetDesc");

                    FileSystem.PrintLine(FileNum, "\"" + MeasureSetID + "\"" + "," + "\"" + MeasureSetDesc + "\"");

                    //LDW  modGlobal.gv_rs.MoveNext();
                }

                FileSystem.PrintLine(FileNum, "[MEASURESETMAPMEAS]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureSetMapMeas ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName58 = "tbl_Setup_MeasureSetMapMeas";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName58, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow56 in modGlobal.gv_rs.Tables[sqlTableName58].Rows)
                {
                    MeasLinkID = "";
                    IndicatorID = "";
                    MeasureSetID = "";

                    MeasLinkID = myRow56.Field<string>("MeasLinkID");
                    IndicatorID = myRow56.Field<string>("IndicatorID");
                    MeasureSetID = myRow56.Field<string>("MeasureSetID");


                    FileSystem.PrintLine(FileNum, "\"" + MeasLinkID + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + MeasureSetID + "\"");

                    //LDW  modGlobal.gv_rs.MoveNext();
                }


                FileSystem.FileClose(FileNum);

                //insert the new version number in the version history
                if (optForTesting.IsChecked == false)
                {
                    if (string.IsNullOrEmpty(modGlobal.gv_State))
                    {
                        modGlobal.gv_sql = "Insert into tbl_setup_version (VersionNumber, VersionDate, VersionStartDate, Notes)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (";
                        if (modGlobal.gv_selecteddatabase == "Current")
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + txtNextVersionNumber.Text + ",";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + JCVersion + ",";
                        }
                        modGlobal.gv_sql = modGlobal.gv_sql + "'" + DateAndTime.Now + "',";
                        if (string.IsNullOrEmpty(VersionStartDate))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " '" + VersionStartDate + "',";
                        }
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + Strings.Replace(txtUserNotes.Text, "'", "''") + "')";
                    }
                    else
                    {
                        modGlobal.gv_sql = "Insert into tbl_setup_Stateversion (State, StateVersion, StateVersionDate, VersionStartDate, Notes)";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values ('" + modGlobal.gv_State + "',";
                        if (modGlobal.gv_selecteddatabase == "Current")
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + txtNextVersionNumber.Text + ",";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + StateVersion + ",";
                        }
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + DateAndTime.Now + "',";
                        if (string.IsNullOrEmpty(VersionStartDate))
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
                        }
                        else
                        {
                            modGlobal.gv_sql = modGlobal.gv_sql + " '" + VersionStartDate + "',";
                        }
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + Strings.Replace(txtUserNotes.Text, "'", "''") + "')";
                    }

                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }

                Cursor.Current = Cursors.Default;

                RadMessageBox.Show("The update file '" + UpdateFile + "' was successfully created.");

                return;
                //UpdateErr:

                if (Information.Err().Number == 71)
                {
                    // ERROR: Not supported in C#: OnErrorStatement

                    Cursor.Current = Cursors.Default;
                    RadMessageBox.Show("The Destination directory does not exist. Please Check Again.");
                    return;
                }
                else
                {
                    msg = "The following error occured in the process of creating an update for Access database: " + Strings.Chr(13) + Strings.Chr(10);
                    msg = msg + Information.Err().Number + ": " + Information.Err().Description;
                    // ERROR: Not supported in C#: OnErrorStatement

                    FileSystem.FileClose(FileNum);
                    Cursor.Current = Cursors.Default;
                    RadMessageBox.Show(msg);
                    return;
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

        public void RefreshImportLayout()
        {
            var i = 0;
            string selectedlist = null;
            List<Item> itemslstAvailableImportLayouts = new List<Item>();

            try
            {
                selectedlist = "";
                for (i = 1; i <= lstSelectedImportLayouts.Items.Count; i++)
                {
                    if (string.IsNullOrEmpty(selectedlist))
                    {
                        selectedlist = Support.GetItemData(lstSelectedImportLayouts, i - 1).ToString();
                    }
                    else
                    {
                        selectedlist = string.Format("{0},{1}", selectedlist, Support.GetItemData(lstSelectedImportLayouts, i - 1));
                    }
                }

                lstAvailableImportLayouts.Items.Clear();

                modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
                if (!string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = string.Format("{0} where (State = '{1}' or State is null) ", modGlobal.gv_sql, modGlobal.gv_State);
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null)";
                }
                if (!string.IsNullOrEmpty(selectedlist))
                {
                    modGlobal.gv_sql = string.Format("{0} and ImportSetupID not in ({1}) ", modGlobal.gv_sql, selectedlist);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by recordstatus, description ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName59 = "tbl_setup_ImportSetup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName59, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow57 in modGlobal.gv_rs.Tables[sqlTableName59].Rows)
                {
                    itemslstAvailableImportLayouts.Add(new Item(myRow57.Field<int>("ImportSetupID"), string.Format("{0} - {1}",
                        Information.IsDBNull(myRow57.Field<string>("RecordStatus")) | string.IsNullOrEmpty(myRow57.Field<string>("RecordStatus"))
                        ? "Active" : "Test   ", myRow57.Field<string>("Description"))));


                    //lstAvailableImportLayouts.Items.Add(new ListBoxItem(string.Format("{0} - {1}", 
                    //    Information.IsDBNull(myRow57.Field<string>("RecordStatus")) | string.IsNullOrEmpty(myRow57.Field<string>("RecordStatus")) 
                    //    ? "Active" : "Test   ", myRow57.Field<string>("Description")), myRow57.Field<int>("ImportSetupID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstAvailableImportLayouts.DataSource = itemslstAvailableImportLayouts;
                this.lstAvailableImportLayouts.DisplayMember = "Description";
                this.lstAvailableImportLayouts.ValueMember = "Id";

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

        private void cmdRemoveImportLayout_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelectedImportLayouts.SelectedIndex < 0)
                {
                    return;
                }

                lstSelectedImportLayouts.Items.RemoveAt(lstSelectedImportLayouts.SelectedIndex);

                RefreshImportLayout();
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

        private void frmExportSetup_Load(object sender, EventArgs e)
        {
            int StateVersion = 0;

            try
            {
                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    JCVersion = modDBSetup.FindMaxRecID("tbl_setup_Version", "VersionNumber");
                    txtNextVersionNumber.Text = JCVersion.ToString();
                    txtUserNotes.Text = JCVersion.ToString();
                    //If txtUserNotes = "" Then
                    //    Screen.MousePointer = 0
                    //    MsgBox "Update file was not created."
                    //    Exit Sub
                    //End If
                    StateVersion = 0;
                    lblCurrentVersionNumber.Text = "JC Version#: " + (JCVersion - 1);
                    lblNextVersionNumber.Text = "JC Version#: " + JCVersion;
                }
                else
                {
                    RadMessageBox.Show("This setup will not change the JC setup version, but will increment the State version number." +
                        " The text file will include both the JC and the State specific setup definition.");
                    StateVersion = modDBSetup.FindMaxRecID("tbl_setup_StateVersion", "StateVersion");
                    txtNextVersionNumber.Text = StateVersion.ToString();
                    //UserNotes = InputBox("Please enter your notes for version " & NewVersion & " (for this State).", "New Setup Version", "No Notes.")
                    //If UserNotes = "" Then
                    //    Screen.MousePointer = 0
                    //    MsgBox "Update file was not created."
                    //    Exit Sub
                    //End If
                    modGlobal.gv_sql = "Select max(versionNumber) as JCVersion from tbl_setup_Version";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName60 = "tbl_setup_Version";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName60, modGlobal.gv_rs);

                    JCVersion = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName60].Rows[0]["JCVersion"]);
                    lblCurrentVersionNumber.Text = "State Version#: " + (StateVersion - 1);
                    lblNextVersionNumber.Text = "State Version#: " + StateVersion;
                }
                if (modGlobal.gv_selecteddatabase == "Current")
                {
                    txtNextVersionNumber.Top = lblNextVersionNumber.Top;
                    lblNextVersionNumber.Visible = false;
                    txtNextVersionNumber.Visible = true;
                }
                else
                {
                    lblNextVersionNumber.Visible = true;
                    txtNextVersionNumber.Visible = false;
                }

                RefreshImportLayout();
                RefreshSetupDateList();
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

        public void RefreshSetupDateList()
        {
            var i = 0;
            int thisyear = DateAndTime.Year(DateAndTime.Now) - 2;
            List<Item> itemscboStartQuarter = new List<Item>();
            List<Item> itemscboStartYear = new List<Item>();

            try
            {
                cboStartQuarter.Items.Clear();
                itemscboStartQuarter.Add(new Item(1, "1"));
                itemscboStartQuarter.Add(new Item(2, "2"));
                itemscboStartQuarter.Add(new Item(3, "3"));
                itemscboStartQuarter.Add(new Item(4, "4"));
                this.cboStartQuarter.DataSource = itemscboStartQuarter;
                this.cboStartQuarter.DisplayMember = "Description";
                this.cboStartQuarter.ValueMember = "Id";


                //cboStartQuarter.Items.Add(new ListBoxItem("1", 1).ToString());
                //cboStartQuarter.Items.Add(new ListBoxItem("2", 2).ToString());
                //cboStartQuarter.Items.Add(new ListBoxItem("3", 3).ToString());
                //cboStartQuarter.Items.Add(new ListBoxItem("4", 4).ToString());

                cboStartYear.Items.Clear();
                for (i = 1; i <= 5; i++)
                {
                    itemscboStartYear.Add(new Item(thisyear, thisyear.ToString()));


                    //cboStartYear.Items.Add(thisyear.ToString());
                    //Support.SetItemData(cboStartYear, cboStartYear.Items.Count-1, thisyear);
                    thisyear = thisyear + 1;
                    i++;
                }
                this.cboStartYear.DataSource = itemscboStartYear;
                this.cboStartYear.DisplayMember = "Description";
                this.cboStartYear.ValueMember = "Id";
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

        public void OutputTableStructure()
        {
            //Dim ll_cnt As Long
            //Dim oTable As rdoTable
            //Dim li_fields AS Long
            //Dim ls_TableName As String
            //
            //    For ll_cnt = 1 To gv_cn.rdoTables.Count
            //        Set oTable = gv_cn.rdoTables(ll_cnt)
            //        If Left(oTable.Name, 9) = "tbl_Setup" Then
            //        ls_TableName = mid(oTable.Name, 10, Len(oTable.Name))
            //
            //        'export the definition
            //            For li_fields = 1 To oTable.rdoColumns.Count
            //                Print #FileNum,"""" & ls_tablename & """" & "," & _
            //'                    iif(otable.rdoColumns(li_fields).Type
            //
            //            Next
            //        End If
            //    Next

            //fields for this table: tbl_Sys_SubmitSubGroupCategory

            try
            {
                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroupCategory" + "\"" + "," + "\"" + "SubmitSubGroupCategoryID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroupCategory" + "\"" + "," + "\"" + "SubGroupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroupCategory" + "\"" + "," + "\"" + "Measure_CATID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");

                //Print #FileNum, """" & "tbl_Sys_SubmitSubGroupCategory" & """" & "," & _
                //'                """" & "VersionNumber" & """" & "," & _
                //'                """" & "Integer" & """" & "," & _
                //'                """" & "0" & """"

                //PTP - added on 9/9/04

                FileSystem.PrintLine(FileNum, "\"" + "Tbl_Dat_IndicatorSubmit" + "\"" + "," + "\"" + "HFAP" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "Tbl_Dat_IndicatorSubmit" + "\"" + "," + "\"" + "QIO" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");
                //PTP - End of added on 9/9/04




                //fields for this table: tbl_Sys_MeasureCat

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "MEASURE_CATID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "Cat" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "1" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "CAT_DESC" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCat" + "\"" + "," + "\"" + "CAT_Type" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "2" + "\"");

                //Print #FileNum, """" & "tbl_Sys_MeasureCat" & """" & "," & _
                //'                """" & "VersionNumber" & """" & "," & _
                //'                """" & "Integer" & """" & "," & _
                //'                """" & "0" & """"

                //fields for this table: tbl_Sys_MeasureCriteria

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "MeasureCriteriaID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "MeasureCriteriaSetID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "CriteriaTitle" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "200" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DDID1" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DDID2" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "ValueOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

                //5.16.2005 - changed to 300 instead of 50

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "FieldValue" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "300" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DestDDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

                //3.11.2005 - changed to long integer

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "LookupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "FieldOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "DateUnit" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "State" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "20" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "RecordStatus" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "20" + "\"");

                //Print #FileNum, """" & "tbl_Sys_MeasureCriteria" & """" & "," & _
                //'                """" & "VersionNumber" & """" & "," & _
                //'                """" & "Integer" & """" & "," & _
                //'                """" & "0" & """"


                //fields for this table: tbl_sys_MeasureCriteriaSet

                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "MeasureCriteriaSetID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "MeasureCriteriaSet" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "MeasureStepID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureCriteriaSet" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "5" + "\"");

                //Print #FileNum, """" & "tbl_sys_MeasureCriteriaSet" & """" & "," & _
                //'                """" & "VersionNumber" & """" & "," & _
                //'                """" & "Integer" & """" & "," & _
                //'                """" & "0" & """"


                //fields for this table: tbl_sys_MeasureStepGroup

                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "MeasureStepGroupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "MeasureStepID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "MeasureStepGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStepGroup" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "5" + "\"");

                //fields for this table: tbl_sys_MeasureCriteriaSet

                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "MeasureStepID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "MeasureID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "MeasureStep" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "Measure_CATID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                //-SH modified 8.31.04 to include gotostep

                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "GoToStep" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

                // - sh 6.14.05 to include isrisk field

                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_MeasureStep" + "\"" + "," + "\"" + "IsRisk" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

                //

                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_Indicator" + "\"" + "," + "\"" + "LastUpdateDate" + "\"" + "," + "\"" + "Date" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_submitgroup" + "\"" + "," + "\"" + "ShowTotal" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_submitcriteria" + "\"" + "," + "\"" + "DestDDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_sys_submitcriteria" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Dat_savedAdhocReportCriteria" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_TableValidationMessage" + "\"" + "," + "\"" + "mcriteria" + "\"" + "," + "\"" + "memo" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_TableValidation" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_TableDef" + "\"" + "," + "\"" + "CompareToDesc" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_SubmitSubGroup" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "10" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Dat_INDICATORSUBMIT" + "\"" + "," + "\"" + "CMS" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Dat_INDICATORSUBMIT" + "\"" + "," + "\"" + "PR" + "\"" + "," + "\"" + "YesNo" + "\"" + "," + "\"" + "0" + "\"");

                //    Print #FileNum, """" & "tbl_Sys_DATADEF" & """" & "," & _
                //'                    """" & "NumberFormat" & """" & "," & _
                //'                    """" & "Text" & """" & "," & _
                //'                    """" & "20" & """"
                //

                //AUTONUMBER SHOULD BE IMPLEMENTED IN MEMBER!
                //print #filenum, """" & "tbl_Sys_SAVEDADHOCREPORTSUMCRITERIA" & """" & "," & _
                //'                """" & "CRITERIAID" & """"" & "," & _
                //
                // 5.10.2005 - added new field & Setup tables for processing related & similar field groups

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureCriteria" + "\"" + "," + "\"" + "MeasureFieldGroupLogicID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_FieldGroup" + "\"" + "," + "\"" + "FieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_FieldGroup" + "\"" + "," + "\"" + "FieldGroupName" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_FieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDFieldGroup" + "\"" + "," + "\"" + "DDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDFieldGroup" + "\"" + "," + "\"" + "FieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDFieldGroup" + "\"" + "," + "\"" + "FieldGroupID" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_RelatedFieldGroup" + "\"" + "," + "\"" + "RelatedFieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_RelatedFieldGroup" + "\"" + "," + "\"" + "RelatedFieldGroupName" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_RelatedFieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDRelatedFieldGroup" + "\"" + "," + "\"" + "DDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDRelatedFieldGroup" + "\"" + "," + "\"" + "RelatedFieldGroupID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_DDIDRelatedFieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "MeasureFieldGroupLogicID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");



                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "CriteriaTitle" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "200" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID1" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID1IsGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID2" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldID2IsGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "ValueOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldValue" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "DestDDID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "DestDDIDIsGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "LookupID" + "\"" + "," + "\"" + "Long Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "DateUnit" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "JoinOperator" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "LookupTableID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "OnlyProceedWithRelatedFieldGroup" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "OnlyProceedWithRelatedFieldGroup" + "\"" + "," + "\"" + "VersionNumber" + "\"" + "," + "\"" + "0" + "\"");

                //5.19.2005 - added for Is Between logic

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFieldGroupLogic" + "\"" + "," + "\"" + "FieldValueMax" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "50" + "\"");

                //8.2.2005 - added for flowchart action table

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureStep" + "\"" + "," + "\"" + "FlowchartActionID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");

                //8.2.2005 - added for flowchart action table

                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFlowchartAction" + "\"" + "," + "\"" + "FlowchartActionID" + "\"" + "," + "\"" + "Integer" + "\"" + "," + "\"" + "0" + "\"");


                FileSystem.PrintLine(FileNum, "\"" + "tbl_Sys_MeasureFlowchartAction" + "\"" + "," + "\"" + "ActionDescription" + "\"" + "," + "\"" + "Text" + "\"" + "," + "\"" + "255" + "\"");
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

        public void OutputMeasureVerificationTables()
        {
            string actionDescription = null;
            string MeasureStepGroup = null;
            string MeasureStepGroupID = null;
            string multselany = null;
            string measurefieldgrouplogicid = null;
            string DateUnit = null;
            string FieldOperator = null;
            string LookupTableID = null;
            string LookupID = null;
            string FIELDVALUE = null;
            string ValueOperator = null;
            string DestDDID = null;
            string ddid2 = null;
            string DDID1 = null;
            string CriteriaTitle = null;
            string measureCriteriaID = null;
            int newid;
            string JoinOperator = null;
            string MeasureCriteriaSet = null;
            string MeasureCriteriaSetID = null;
            string flowchartactionid = null;
            string isrisk = null;
            string GoToStep = null;
            string measurestep = null;
            string MeasureID = null;
            string MeasureStepID = null;
            string CAT_TYPE = null;
            string CAT_DESC = null;
            string CAT = null;
            string measure_catid = null;


            try
            {
                //data from tbl_MeasureCat
                FileSystem.PrintLine(FileNum, "[MEASURECAT]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Measure_Cat ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName61 = "tbl_Measure_Cat";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName61, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow59 in modGlobal.gv_rs.Tables[sqlTableName61].Rows)
                {

                    measure_catid = "";

                    CAT = "";

                    CAT_DESC = "";

                    CAT_TYPE = "";


                    measure_catid = myRow59.Field<string>("measure_catid");

                    CAT = myRow59.Field<string>("CAT");

                    if (!Information.IsDBNull(myRow59.Field<string>("CAT_DESC")))
                    {

                        CAT_DESC = myRow59.Field<string>("CAT_DESC");
                    }

                    if (!Information.IsDBNull(myRow59.Field<string>("CAT_TYPE")))
                    {

                        CAT_TYPE = myRow59.Field<string>("CAT_TYPE");
                    }

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", measure_catid, CAT, CAT_DESC, CAT_TYPE));

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //data from MeasureStep

                FileSystem.PrintLine(FileNum, "[MEASURESTEP]");
                modGlobal.gv_sql = "(Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureStepNonReplacement)";

                //add the replacement steps for summarization
                modGlobal.gv_sql = modGlobal.gv_sql + "UNION ALL (Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from vuMeasureStepReplacement)";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName62 = "vuMeasureStepNonReplacement";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName62, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow60 in modGlobal.gv_rs.Tables[sqlTableName62].Rows)
                {
                    MeasureStepID = "";

                    MeasureID = "";

                    measurestep = "";

                    measure_catid = "";

                    GoToStep = "";

                    isrisk = "";


                    MeasureStepID = myRow60.Field<string>("MeasureStepID");

                    MeasureID = myRow60.Field<string>("MeasureID");

                    measurestep = myRow60.Field<string>("measurestep");

                    measure_catid = myRow60.Field<string>("measure_catid");

                    GoToStep = myRow60.Field<string>("GoToStep");

                    isrisk = myRow60.Field<string>("isrisk");

                    flowchartactionid = myRow60.Field<string>("flowchartactionid");


                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"",
                        MeasureStepID, MeasureID, measurestep, measure_catid, GoToStep, isrisk, flowchartactionid));

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //    'add the replacement steps for summarization
                //    gv_sql = "Select * "
                //    gv_sql = gv_sql & " from tbl_Setup_MeasureStep "
                //    gv_sql = gv_sql & " where measureStepid in "
                //    gv_sql = gv_sql & " (select MeasureStepID from tbl_Setup_MeasureStepSubmitSubs)"
                //    gv_sql = gv_sql & "  AND measureid in (select indicatorid from tbl_Setup_indicator)"
                //
                //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //    While Not gv_rs.EOF
                //        MeasureStepID = ""
                //        MeasureID = ""
                //        MeasureStep = ""
                //        Measure_CATID = ""
                //        GoToStep = ""
                //        IsRisk = ""
                //
                //        MeasureStepID = gv_rs!MeasureStepID
                //        MeasureID = gv_rs!MeasureID
                //        MeasureStep = gv_rs!MeasureStep
                //        Measure_CATID = gv_rs!Measure_CATID
                //        GoToStep = gv_rs!GoToStep
                //        IsRisk = gv_rs!IsRisk
                //
                //        Print #FileNum, """" & MeasureStepID & """" & "," & _
                //'                        """" & MeasureID & """" & "," & """" & MeasureStep & """" & "," & _
                //'                        """" & Measure_CATID & """" & "," & """" & GoToStep & """" & "," & """" & IsRisk & """" & "," & """" & flowchartactionid & """"
                //
                //        gv_rs.MoveNext
                //
                //     Wend
                //
                //data from MeasureCriteriaSet

                FileSystem.PrintLine(FileNum, "[MEASURECRITERIASET]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureStepID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select MeasureStepID from tbl_Setup_MeasureStepSubmitSubs)";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName63 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName63, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow61 in modGlobal.gv_rs.Tables[sqlTableName63].Rows)
                {

                    MeasureCriteriaSetID = "";

                    MeasureCriteriaSet = "";

                    MeasureStepID = "";

                    JoinOperator = "";


                    MeasureCriteriaSetID = myRow61.Field<string>("MeasureCriteriaSetID");

                    MeasureCriteriaSet = myRow61.Field<string>("MeasureCriteriaSet");

                    MeasureStepID = myRow61.Field<string>("MeasureStepID");

                    JoinOperator = myRow61.Field<string>("JoinOperator");


                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", MeasureCriteriaSetID, MeasureCriteriaSet, MeasureStepID, JoinOperator));

                    //LDW modGlobal.gv_rs.MoveNext();
                }


                //add the replacement sets for summarization
                //first create a unique id as compared to the ID's in tbl_Setup_MeasureCriteriaSet table
                modGlobal.gv_sql = "Select max(measureCriteriaSetID) as maxSetID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSet ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName64 = "tbl_Setup_MeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName64, modGlobal.gv_rs);
                newid = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName64].Rows[0]["MaxSetID"]);
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSetSubmitSubs  ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName65 = "tbl_Setup_MeasureCriteriaSetSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName65, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow63 in modGlobal.gv_rs.Tables[sqlTableName65].Rows)
                {
                    newid = newid + 1;

                    modGlobal.gv_sql = "update tbl_Setup_MeasureCriteriaSetSubmitSubs set ExportSetID = " + newid;
                    modGlobal.gv_sql = string.Format("{0} where measureCriteriaSetSubmitSubsID =  {1}", modGlobal.gv_sql, myRow63.Field<string>("measureCriteriaSetSubmitSubsID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "Select mcsss.*, msss.MeasureStepID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSetSubmitSubs as mcsss ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureStepSubmitSubs as msss";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mcsss.MeasureStepSubmitSubsID = msss.MeasureStepSubmitSubsID ";
                //g = InputBox("", "", gv_sql)
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTalbeName66 = "tbl_Setup_MeasureCriteriaSetSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTalbeName66, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow64 in modGlobal.gv_rs.Tables[sqlTalbeName66].Rows)
                {
                    MeasureCriteriaSetID = "";

                    MeasureCriteriaSet = "";

                    MeasureStepID = "";

                    JoinOperator = "";


                    MeasureCriteriaSetID = myRow64.Field<string>("ExportSetID");

                    MeasureCriteriaSet = myRow64.Field<string>("MeasureCriteriaSet");

                    MeasureStepID = myRow64.Field<string>("MeasureStepID");

                    JoinOperator = myRow64.Field<string>("JoinOperator");


                    FileSystem.PrintLine(FileNum, "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + MeasureCriteriaSet + "\"" + "," + "\"" +
                        MeasureStepID + "\"" + "," + "\"" + JoinOperator + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //data from MeasureCriteria

                FileSystem.PrintLine(FileNum, "[MEASURECRITERIA]");
                modGlobal.gv_sql = "Select mc.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria  as mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where mc.measureCriteriaSetID not in ";
                modGlobal.gv_sql = modGlobal.gv_sql + " (select measureCriteriaSetID from ";
                modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_MeasureCriteriaSet as mcSets ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureStepSubmitSubs as ms ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on mcSets.MeasureStepID = ms.MeasureStepID";
                modGlobal.gv_sql = modGlobal.gv_sql + " )";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.State is null or rtrim(mc.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (mc.State is null or mc.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID1 is null or mc.DDID1 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {

                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and";
                modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID2 is null or mc.DDID2 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DestDDID is null or mc.DestDDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")";

                //Debug.Print gv_sql

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName67 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName67, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow65 in modGlobal.gv_rs.Tables[sqlTableName67].Rows)
                {
                    measureCriteriaID = "";

                    MeasureCriteriaSetID = "";

                    CriteriaTitle = "";

                    DDID1 = "";

                    ddid2 = "";

                    DestDDID = "";

                    ValueOperator = "";

                    FIELDVALUE = "";

                    LookupID = "";

                    LookupTableID = "";

                    FieldOperator = "";

                    DateUnit = "";

                    JoinOperator = "";

                    measurefieldgrouplogicid = "";

                    multselany = "";

                    measureCriteriaID = myRow65.Field<string>("measureCriteriaID");

                    MeasureCriteriaSetID = myRow65.Field<string>("MeasureCriteriaSetID");

                    CriteriaTitle = myRow65.Field<string>("CriteriaTitle");

                    DDID1 = myRow65.Field<string>("DDID1");

                    if (!Information.IsDBNull(myRow65.Field<string>("ddid2")))
                    {

                        ddid2 = myRow65.Field<string>("ddid2");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("DestDDID")))
                    {

                        DestDDID = myRow65.Field<string>("DestDDID");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("ValueOperator")))
                    {

                        ValueOperator = myRow65.Field<string>("ValueOperator");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("FIELDVALUE")))
                    {

                        FIELDVALUE = myRow65.Field<string>("FIELDVALUE");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("LookupID")))
                    {

                        LookupID = myRow65.Field<string>("LookupID");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("LookupTableID")))
                    {

                        LookupTableID = myRow65.Field<string>("LookupTableID");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("FieldOperator")))
                    {

                        FieldOperator = myRow65.Field<string>("FieldOperator");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("DateUnit")))
                    {

                        DateUnit = myRow65.Field<string>("DateUnit");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("JoinOperator")))
                    {

                        JoinOperator = myRow65.Field<string>("JoinOperator");
                    }

                    if (!Information.IsDBNull(myRow65.Field<string>("measurefieldgrouplogicid")))
                    {

                        measurefieldgrouplogicid = myRow65.Field<string>("measurefieldgrouplogicid");
                    }

                    if (!Information.IsDBNull(myRow65.Field<bool>("multselany")))
                    {

                        multselany = (myRow65.Field<bool>("multselany") ? "1" : "0");
                    }

                    FileSystem.PrintLine(FileNum, "\"" + measureCriteriaID + "\"" + "," + "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + CriteriaTitle +
                        "\"" + "," + "\"" + DDID1 + "\"" + "," + "\"" + ddid2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator +
                        "\"" + "," + "\"" + FIELDVALUE + "\"" + "," + "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator +
                        "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator + "\"" + "," + "\"" + measurefieldgrouplogicid + "\"" + "," + "\"" + multselany + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }

                //add the replacement criteria for submission
                //first create a unique id as compared to the ID's in tbl_Setup_MeasureCriteriaSet table
                modGlobal.gv_sql = "Select max(measureCriteriaID) as maxCriteriaID  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName68 = "tbl_Setup_MeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName68, modGlobal.gv_rs);

                newid = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName68].Rows[0]["MaxCriteriaID"]);
                modGlobal.gv_rs.Dispose();

                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs  ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName69 = "tbl_Setup_MeasureCriteriaSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName69, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow67 in modGlobal.gv_rs.Tables[sqlTableName69].Rows)
                {
                    newid = newid + 1;


                    modGlobal.gv_sql = "update tbl_Setup_MeasureCriteriaSubmitSubs set ExportCriteriaID = " + newid;
                    modGlobal.gv_sql = string.Format("{0} where measureCriteriaSubmitSubsID =  {1}", modGlobal.gv_sql, myRow67.Field<string>("measureCriteriaSubmitSubsID"));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                //update the exportsetid in the criteriatable
                modGlobal.gv_sql = "update tbl_Setup_MeasureCriteriaSubmitSubs  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set tbl_Setup_MeasureCriteriaSubmitSubs.ExportSetID = tbl_Setup_MeasureCriteriaSetSubmitSubs.ExportSetID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_MeasureCriteriaSetSubmitSubs ";
                modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_Setup_MeasureCriteriaSubmitSubs.MeasureCriteriaSetSubmitSubsID ";
                modGlobal.gv_sql = modGlobal.gv_sql + " = tbl_Setup_MeasureCriteriaSetSubmitSubs.MeasureCriteriaSetSubmitSubsID ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = "Select mc.* ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteriaSubmitSubs as mc ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where 0 = 0 ";
                //mc.measureCriteriaSetID in "
                //gv_sql = gv_sql & " (select measureCriteriaSetID from "
                //gv_sql = gv_sql & " tbl_Setup_MeasureCriteriaSet as mcSets "
                //gv_sql = gv_sql & " inner join tbl_Setup_MeasureStepSubmitSubs as ms "
                //gv_sql = gv_sql & " on mcSets.MeasureStepID = ms.MeasureStepID"
                //gv_sql = gv_sql & " )"

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (mc.State is null or rtrim(mc.state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and (mc.State is null or mc.State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID1 is null or mc.DDID1 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and";
                modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DDID2 is null or mc.DDID2 in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")  ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  and ";
                modGlobal.gv_sql = modGlobal.gv_sql + "(mc.DestDDID is null or mc.DestDDID in ";
                modGlobal.gv_sql = modGlobal.gv_sql + "  (select ddid from tbl_setup_datadef ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " where (State is null or rtrim(state) = '') ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} where (State is null or State = '{1}')", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (optActive.IsChecked == true)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or Recordstatus is null) ";
                }
                modGlobal.gv_sql = modGlobal.gv_sql + "  )";
                modGlobal.gv_sql = modGlobal.gv_sql + ")";


                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName70 = "tbl_Setup_MeasureCriteriaSubmitSubs";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName70, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow68 in modGlobal.gv_rs.Tables[sqlTableName70].Rows)
                {
                    measureCriteriaID = "";

                    MeasureCriteriaSetID = "";

                    CriteriaTitle = "";

                    DDID1 = "";

                    ddid2 = "";

                    DestDDID = "";

                    ValueOperator = "";

                    FIELDVALUE = "";

                    LookupID = "";

                    LookupTableID = "";

                    FieldOperator = "";

                    DateUnit = "";

                    JoinOperator = "";

                    measurefieldgrouplogicid = "";

                    multselany = "";


                    measureCriteriaID = myRow68.Field<string>("ExportCriteriaID");

                    MeasureCriteriaSetID = myRow68.Field<string>("ExportSetID");

                    CriteriaTitle = myRow68.Field<string>("CriteriaTitle");

                    DDID1 = myRow68.Field<string>("DDID1");

                    if (!Information.IsDBNull(myRow68.Field<string>("ddid2")))
                    {

                        ddid2 = myRow68.Field<string>("ddid2");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("DestDDID")))
                    {

                        DestDDID = myRow68.Field<string>("DestDDID");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("ValueOperator")))
                    {

                        ValueOperator = myRow68.Field<string>("ValueOperator");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("FIELDVALUE")))
                    {

                        FIELDVALUE = myRow68.Field<string>("FIELDVALUE");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("LookupID")))
                    {

                        LookupID = myRow68.Field<string>("LookupID");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("LookupTableID")))
                    {

                        LookupTableID = myRow68.Field<string>("LookupTableID");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("FieldOperator")))
                    {

                        FieldOperator = myRow68.Field<string>("FieldOperator");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("DateUnit")))
                    {

                        DateUnit = myRow68.Field<string>("DateUnit");
                    }

                    if (!Information.IsDBNull(myRow68.Field<string>("JoinOperator")))
                    {

                        JoinOperator = myRow68.Field<string>("JoinOperator");
                    }


                    FileSystem.PrintLine(FileNum, "\"" + measureCriteriaID + "\"" + "," + "\"" + MeasureCriteriaSetID + "\"" + "," + "\"" + CriteriaTitle + "\"" + "," + "\"" +
                        DDID1 + "\"" + "," + "\"" + ddid2 + "\"" + "," + "\"" + DestDDID + "\"" + "," + "\"" + ValueOperator + "\"" + "," + "\"" + FIELDVALUE + "\"" + "," +
                        "\"" + LookupID + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + FieldOperator + "\"" + "," + "\"" + DateUnit + "\"" + "," + "\"" + JoinOperator +
                        "\"" + "," + "\"" + measurefieldgrouplogicid + "\"" + "," + "\"" + multselany + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }


                FileSystem.PrintLine(FileNum, "[MEASURESTEPGROUP]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureStepGroup ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName71 = "tbl_Setup_MeasureStepGroup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName71, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow69 in modGlobal.gv_rs.Tables[sqlTableName71].Rows)
                {
                    MeasureStepGroupID = "";

                    MeasureStepID = "";

                    MeasureCriteriaSetID = "";

                    MeasureStepGroup = "";

                    JoinOperator = "";

                    MeasureStepGroupID = myRow69.Field<string>("MeasureStepGroupID");

                    MeasureStepID = myRow69.Field<string>("MeasureStepID");

                    MeasureCriteriaSetID = myRow69.Field<string>("MeasureCriteriaSetID");

                    MeasureStepGroup = myRow69.Field<string>("MeasureStepGroup");

                    JoinOperator = myRow69.Field<string>("JoinOperator");

                    FileSystem.PrintLine(FileNum, "\"" + MeasureStepGroupID + "\"" + "," + "\"" + MeasureStepID + "\"" + "," + "\"" + MeasureCriteriaSetID +
                        "\"" + "," + "\"" + MeasureStepGroup + "\"" + "," + "\"" + JoinOperator + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }


                FileSystem.PrintLine(FileNum, "[MEASUREFLOWCHARTACTION]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureFlowchartAction ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName72 = "tbl_Setup_MeasureFlowchartAction";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName72, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow70 in modGlobal.gv_rs.Tables[sqlTableName72].Rows)
                {
                    flowchartactionid = "";

                    actionDescription = "";


                    flowchartactionid = myRow70.Field<string>("flowchartactionid");

                    actionDescription = myRow70.Field<string>("actionDescription");

                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\"", flowchartactionid, actionDescription));

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

        //LDW Not used
        private void ConvertTypeToAccessType()
        {

        }

        private void OutputIndicatorReportSetup()
        {
            try
            {
                FileSystem.PrintLine(FileNum, "[INDICATORREPORTINCLUDES]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorReportIncludes ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName73 = "tbl_Setup_IndicatorReportIncludes";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName73, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow71 in modGlobal.gv_rs.Tables[sqlTableName73].Rows)
                {
                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", myRow71.Field<string>("IncludeID"),
                        myRow71.Field<string>("IndicatorID"), myRow71.Field<string>("SubGroupID"), Information.IsDBNull(myRow71.Field<string>("grouprowID"))
                        ? "" : myRow71.Field<string>("grouprowID"), Information.IsDBNull(myRow71.Field<string>("SortOrder")) ? "" :
                        myRow71.Field<string>("SortOrder")));

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();


                //    Print #FileNum, "[INDICATORREPORTNUMERATORS]"
                //    gv_sql = "Select * "
                //    gv_sql = gv_sql & " from tbl_Setup_IndicatorReportNumerators "
                //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //    Do While Not gv_rs.EOF
                //
                //        Print #FileNum, """" & gv_rs!NumeratorID & """" & "," & _
                //'                        """" & gv_rs!IndicatorID & """" & "," & """" & gv_rs!HeadingText & """" & "," & _
                //'                        """" & gv_rs!FieldID & """"
                //
                //        gv_rs.MoveNext
                //
                //    Loop
                //    gv_rs.Close


                FileSystem.PrintLine(FileNum, "[INDICATORREPORTDENOMINATORS]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_IndicatorReportDenominators ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName74 = "tbl_Setup_IndicatorReportDenominators";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName74, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow72 in modGlobal.gv_rs.Tables[sqlTableName74].Rows)
                {
                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", myRow72.Field<string>("DenomFieldID"),
                        myRow72.Field<string>("SubGroupID"), Strings.Trim(myRow72.Field<string>("tName")),
                        myRow72.Field<string>("OpChar"), myRow72.Field<string>("fieldid")));

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

        private void OutputRelatedGroupLogic()
        {
            string CriteriaTitle = null;
            string fieldvaluemax = null;
            string onlyproceedwithrelatedfieldgroup = null;
            string LookupTableID = null;
            string JoinOperator = null;
            string DateUnit = null;
            string FieldOperator = null;
            string LookupID = null;
            string destddidisgroup = null;
            string DestDDID = null;
            string FIELDVALUE = null;
            string ValueOperator = null;
            string fieldid2isgroup = null;
            string fieldid2 = null;
            string fieldid1isgroup = null;
            string fieldid1 = null;
            string CRITERIATITILE = null;
            string measurefieldgrouplogicid = null;


            try
            {
                FileSystem.PrintLine(FileNum, "[FIELDGROUP]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_FIELDGROUP ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName75 = "tbl_Setup_FIELDGROUP";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName75, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow73 in modGlobal.gv_rs.Tables[sqlTableName75].Rows)
                {
                    FileSystem.PrintLine(FileNum, "\"" + myRow73.Field<string>("FIELDGroupID") + "\"" + "," + "\"" + myRow73.Field<string>("FIELDGROUPNAME") + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();


                FileSystem.PrintLine(FileNum, "[DDIDFIELDGROUP]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DDIDFIELDGROUP ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName76 = "tbl_Setup_DDIDFIELDGROUP";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName76, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow74 in modGlobal.gv_rs.Tables[sqlTableName76].Rows)
                {
                    FileSystem.PrintLine(FileNum, "\"" + myRow74.Field<string>("DDID") + "\"" + "," + "\"" + myRow74.Field<string>("FIELDGroupID") + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();


                FileSystem.PrintLine(FileNum, "[RELATEDFIELDGROUP]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_RELATEDFIELDGROUP ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName77 = "tbl_Setup_RELATEDFIELDGROUP";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName77, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow75 in modGlobal.gv_rs.Tables[sqlTableName77].Rows)
                {
                    FileSystem.PrintLine(FileNum, "\"" + myRow75.Field<string>("RelatedFieldGroupID") + "\"" + "," + "\"" + myRow75.Field<string>("RelatedGroupName") + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();


                FileSystem.PrintLine(FileNum, "[DDIDRELATEDFIELDGROUP]");
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_DDIDRELATEDFIELDGROUP ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName78 = "tbl_Setup_DDIDRELATEDFIELDGROUP";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName78, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow76 in modGlobal.gv_rs.Tables[sqlTableName78].Rows)
                {
                    FileSystem.PrintLine(FileNum, "\"" + myRow76.Field<string>("DDID") + "\"" + "," + "\"" + myRow76.Field<string>("RelatedFieldGroupID") + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();

                }
                modGlobal.gv_rs.Dispose();


                FileSystem.PrintLine(FileNum, "[MEASUREFIELDGROUPLOGIC]");
                modGlobal.gv_sql = "SELECT * FROM TBL_SETUP_MEASUREFIELDGROUPLOGIC";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName79 = "TBL_SETUP_MEASUREFIELDGROUPLOGIC";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName79, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow77 in modGlobal.gv_rs.Tables[sqlTableName79].Rows)
                {
                    measurefieldgrouplogicid = "";

                    CRITERIATITILE = "";

                    fieldid1 = "";

                    fieldid1isgroup = "";

                    fieldid2 = "";

                    fieldid2isgroup = "";

                    ValueOperator = "";

                    FIELDVALUE = "";

                    DestDDID = "";

                    destddidisgroup = "";

                    LookupID = "";

                    FieldOperator = "";

                    DateUnit = "";

                    JoinOperator = "";

                    LookupTableID = "";

                    onlyproceedwithrelatedfieldgroup = "";

                    fieldvaluemax = "";


                    measurefieldgrouplogicid = myRow77.Field<string>("measurefieldgrouplogicid");

                    CriteriaTitle = myRow77.Field<string>("CriteriaTitle");


                    if (!Information.IsDBNull(myRow77.Field<string>("fieldid1")))
                        fieldid1 = myRow77.Field<string>("fieldid1");

                    fieldid1isgroup = myRow77.Field<string>("fieldid1isgroup");

                    if (!Information.IsDBNull(myRow77.Field<string>("fieldid2")))
                    {

                        fieldid2 = myRow77.Field<string>("fieldid2");
                    }

                    fieldid2isgroup = myRow77.Field<string>("fieldid2isgroup");

                    if (!Information.IsDBNull(myRow77.Field<string>("ValueOperator")))
                    {

                        ValueOperator = myRow77.Field<string>("ValueOperator");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("FIELDVALUE")))
                    {

                        FIELDVALUE = myRow77.Field<string>("FIELDVALUE");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("DestDDID")))
                    {

                        DestDDID = myRow77.Field<string>("DestDDID");
                    }

                    destddidisgroup = myRow77.Field<string>("destddidisgroup");

                    if (!Information.IsDBNull(myRow77.Field<string>("LookupID")))
                    {

                        LookupID = myRow77.Field<string>("LookupID");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("FieldOperator")))
                    {

                        FieldOperator = myRow77.Field<string>("FieldOperator");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("DateUnit")))
                    {

                        DateUnit = myRow77.Field<string>("DateUnit");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("JoinOperator")))
                    {

                        JoinOperator = myRow77.Field<string>("JoinOperator");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("LookupTableID")))
                    {

                        LookupTableID = myRow77.Field<string>("LookupTableID");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("onlyproceedwithrelatedfieldgroup")))
                    {

                        onlyproceedwithrelatedfieldgroup = myRow77.Field<string>("onlyproceedwithrelatedfieldgroup");
                    }

                    if (!Information.IsDBNull(myRow77.Field<string>("fieldvaluemax")))
                    {

                        fieldvaluemax = myRow77.Field<string>("fieldvaluemax");
                    }


                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\"," +
                        "\"{13}\",\"{14}\",\"{15}\",\"{16}\"", measurefieldgrouplogicid, CriteriaTitle, fieldid1, fieldid1isgroup, fieldid2, fieldid2isgroup, ValueOperator,
                        FIELDVALUE, DestDDID, destddidisgroup, LookupID, FieldOperator, DateUnit, JoinOperator, LookupTableID, onlyproceedwithrelatedfieldgroup, fieldvaluemax));

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
