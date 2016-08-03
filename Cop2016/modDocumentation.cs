using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Telerik.WinControls;

namespace COP2001
{
    static class modDocumentation
    {
        public static void PrintSummaryValidation()
        {
            string vmessage = null;
            int msgcount = 0;
            string valFile = null;
            var vrs = new DataSet();
            //LDW DataSet vcrs = new DataSet();
            var vsetrs = new DataSet();
            var vgrouprs = new DataSet();
            const string sqlTableName = "tbl_setup_SubmitValidation";
            const string sqlTableName2 = "tbl_Setup_SubmitValSetGroup1";
            const string sqlTableName3 = "tbl_setup_Datadef";
            const string sqlTableName4 = "temp_table";
            const string sqlTableName5 = "tbl_setup_Datadef1";
            const string sqlTableName6 = "temp_table1";

            try
            {
                modGlobal.gv_SelectedDirectory = "";
                /*LDW FileFind.Text = "Specify the destination directory for the document";
                FileFind.ShowDialog();*/
                var dialog1 = new OpenFileDialog();
                dialog1.Title = "Specify the destination directory for the document";
                dialog1.RestoreDirectory = true;
                dialog1.DefaultExt = "txt";
                dialog1.CheckFileExists = true;
                dialog1.CheckPathExists = true;
                dialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog1.FilterIndex = 2;
                dialog1.ShowReadOnly = true;
                dialog1.ShowDialog();


                if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory))
                {
                    valFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory, Strings.Len(modGlobal.gv_SelectedDirectory), 1) == "\\" ? "SummVal.txt" : "\\SummVal.txt");
                }
                else
                {
                    return;
                }

                //LDW added tostring to valFile
                FileSystem.FileOpen(1, valFile, OpenMode.Output);

                //retrieve the list of Summary Validation messages
                modGlobal.gv_sql = "Select tbl_setup_SubmitValidation.*";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitValidation ";
                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " (tbl_setup_SubmitValidation.state = '' or tbl_setup_SubmitValidation.state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} tbl_setup_SubmitValidation.state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (tbl_setup_SubmitValidation.RecordStatus = '' or tbl_setup_SubmitValidation.RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} and tbl_setup_SubmitValidation.RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_SubmitValidation.valType ";


                //LDW vrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                vrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName, vrs);

                FileSystem.PrintLine(1, " Summary Validation Messages ");
                FileSystem.PrintLine(1, "------------------------------");
                FileSystem.PrintLine(1, "------------------------------");
                FileSystem.PrintLine(1, " ");
                FileSystem.PrintLine(1, " ");

                //LDW while (!vrs.EOF) {
                foreach (DataRow myRow in vrs.Tables[sqlTableName].Rows)
                {
                    msgcount = msgcount + 1;
                    //LDW vmessage = vrs.rdoColumns["Message"].Value;
                    //vmessage = vrs.Tables[sqlTableName].Rows[0]["Message"].ToString();
                    vmessage = myRow.Field<string>("Message");

                    FileSystem.PrintLine(1, msgcount + "  ******************************************************************");
                    //LDW FileSystem.PrintLine(1, vrs.rdoColumns["ValType"].Value);
                    //FileSystem.PrintLine(1, vrs.Tables[sqlTableName].Rows[0]["ValType"].ToString());
                    FileSystem.PrintLine(1, myRow.Field<string>("ValType"));
                    FileSystem.PrintLine(1, "");
                    FileSystem.PrintLine(1, vmessage);
                    FileSystem.PrintLine(1, "");

                    modGlobal.gv_sql = "Select * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_SubmitValSet ";
                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " Where submitvalid = " + vrs.rdoColumns["submitvalid"].Value;
                    //modGlobal.gv_sql = string.Format("{0} Where submitvalid = {1}", modGlobal.gv_sql, vrs.Tables[sqlTableName1].Rows[0]["submitvalid"].ToString());
                    modGlobal.gv_sql = string.Format("{0} Where submitvalid = {1}", modGlobal.gv_sql, myRow.Field<string>("submitvalid"));
                    //LDW vsetrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    vsetrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, vsetrs);

                    //LDW while (!vsetrs.EOF)
                    foreach (DataRow myRow1 in vsetrs.Tables[sqlTableName2].Rows)
                    {
                        FileSystem.PrintLine(1, "----------------");
                        //FileSystem.PrintLine(1, vsetrs.rdoColumns["Description"].Value);
                        //FileSystem.PrintLine(1, vsetrs.Tables[sqlTableName2].Rows[0]["Description"].ToString());
                        FileSystem.PrintLine(1, myRow1.Field<string>("Description"));
                        FileSystem.PrintLine(1, "----------------");

                        modGlobal.gv_sql = " select svg.* ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitValSetGroup1 as svg ";
                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where svg.submitvalsetid = " + vsetrs.rdoColumns["submitvalsetid"].Value;
                        //modGlobal.gv_sql = string.Format("{0} where svg.submitvalsetid = {1}", modGlobal.gv_sql, vsetrs.Tables[sqlTableName2].Rows[0]["submitvalsetid"]);
                        modGlobal.gv_sql = string.Format("{0} where svg.submitvalsetid = {1}", modGlobal.gv_sql, myRow1.Field<string>("submitvalsetid"));

                        //LDW vgrouprs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        vgrouprs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, vgrouprs);

                        FileSystem.PrintLine(1, "   Group 1 Fields ***");

                        //LDW while (!vgrouprs.EOF)
                        foreach (DataRow myRow2 in vgrouprs.Tables[sqlTableName3].Rows)
                        {
                            //LDW if (vgrouprs.rdoColumns["SourceTable"].Value == "HOSPITAL STATISTICS")
                            //if (vgrouprs.Tables[sqlTableName3].Rows[0]["SourceTable"].ToString() == "HOSPITAL STATISTICS")
                            if (myRow2.Field<string>("SourceTable") == "HOSPITAL STATISTICS")
                            {
                                modGlobal.gv_sql = " SELECT Fieldname ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Datadef ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";

                                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " DDID = " + vgrouprs.rdoColumns["FieldID"].Value;
                                //modGlobal.gv_sql = string.Format("{0} DDID = {1}", modGlobal.gv_sql, vgrouprs.Tables[sqlTableName3].Rows[0]["FieldID"]);
                                modGlobal.gv_sql = string.Format("{0} DDID = {1}", modGlobal.gv_sql, myRow2.Field<string>("FieldID"));
                            }
                            else
                            {
                                modGlobal.gv_sql = " select g.groupname + ' / ' + gr.title + ' / ' + sg.title as fieldname ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " from ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  (tbl_Setup_submitsubgroup as sg ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join tbl_Setup_submitgrouprow as gr ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  on sg.grouprowid = gr.grouprowid) ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join tbl_Setup_submitgroup as g ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  on g.groupid = gr.groupid ";

                                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where sg.subgroupid = " + vgrouprs.rdoColumns["FieldID"].Value;
                                modGlobal.gv_sql = string.Format("{0} where sg.subgroupid = {1}", modGlobal.gv_sql, myRow2.Field<string>("FieldID"));
                            }

                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                            //LDW FileSystem.PrintLine(1, "   - " + vgrouprs.rdoColumns["SourceTable"].Value + ": " + modGlobal.gv_rs.rdoColumns["FieldName"].Value);
                            //FileSystem.PrintLine(1, string.Format("   - {0}: {1}", vgrouprs.Tables[sqlTableName3].Rows[0]["SourceTable"], modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["FieldName"]));
                            FileSystem.PrintLine(1, string.Format("   - {0}: {1}", myRow2.Field<string>("SourceTable"), modGlobal.gv_rs.Tables[sqlTableName4].Rows[0]["FieldName"]));
                            //LDW vgrouprs.MoveNext();
                        }

                        FileSystem.PrintLine(1, "   ");
                        modGlobal.gv_sql = " select svg.* ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_SubmitValSetGroup2 as svg ";
                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where svg.submitvalsetid = " + vsetrs.rdoColumns["submitvalsetid"].Value;
                        modGlobal.gv_sql = string.Format("{0} where svg.submitvalsetid = {1}", modGlobal.gv_sql, vsetrs.Tables[sqlTableName2].Rows[0]["submitvalsetid"]);
                        //LDW vgrouprs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        vgrouprs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, vgrouprs);
                        FileSystem.PrintLine(1, "   Group 2 Fields ***");

                        //LDW while (!vgrouprs.EOF)
                        foreach (DataRow myRow3 in vgrouprs.Tables[sqlTableName5].Rows)
                        {
                            //LDW if (vgrouprs.rdoColumns["SourceTable"].Value == "HOSPITAL STATISTICS")
                            if (myRow3.Field<string>("SourceTable") == "HOSPITAL STATISTICS")
                            {
                                modGlobal.gv_sql = " SELECT Fieldname ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Datadef ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " Where ";
                                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " DDID = " + vgrouprs.rdoColumns["FieldID"].Value;
                                modGlobal.gv_sql = string.Format("{0} DDID = {1}", modGlobal.gv_sql, myRow3.Field<string>("FieldID"));
                            }
                            else
                            {
                                modGlobal.gv_sql = " select g.groupname + ' / ' + gr.title + ' / ' + sg.title as fieldname ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " from ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  (tbl_Setup_submitsubgroup as sg ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join tbl_Setup_submitgrouprow as gr ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  on sg.grouprowid = gr.grouprowid) ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  inner join tbl_Setup_submitgroup as g ";
                                modGlobal.gv_sql = modGlobal.gv_sql + "  on g.groupid = gr.groupid ";
                                modGlobal.gv_sql = string.Format("{0} where sg.subgroupid = {1}", modGlobal.gv_sql, myRow3.Field<string>("FieldID"));
                            }
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);
                            //LDW FileSystem.PrintLine(1, "   - " + vgrouprs.rdoColumns["SourceTable"].Value + ": " + (modGlobal.gv_rs.RowCount > 0 ? modGlobal.gv_rs.rdoColumns["FieldName"].Value : ""));
                            FileSystem.PrintLine(1, string.Format("   - {0}: {1}", myRow3.Field<string>("SourceTable"),
                                modGlobal.gv_rs.Tables[0].Rows.Count > 0 ? modGlobal.gv_rs.Tables[sqlTableName6].Rows[0]["FieldName"].ToString() : ""));
                            //vgrouprs.MoveNext();
                        }
                        FileSystem.PrintLine(1, " ");
                        //LDW vsetrs.MoveNext();
                    }
                    //LDW vrs.MoveNext();
                }
                FileSystem.FileClose(1);

                RadMessageBox.Show("Summary validation was exported into " + valFile);
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
        public static void PrintTableValidation(int thisTableID)
        {
            string vmessage = null;
            string validatewhen = null;
            int thismessageid;
            int msgcount = 0;
            string valFile = null;
            var vrs = new DataSet();
            //LDW DataSet vcrs = new DataSet();
            const string sqlTableName7 = "temp_table2";


            try
            {
                modGlobal.gv_SelectedDirectory = "";
                /*FileFind.Text = "Specify the destination directory for the document";
                FileFind.ShowDialog();*/
                var dialog1 = new OpenFileDialog();
                dialog1.Title = "Specify the destination directory for the document";
                dialog1.RestoreDirectory = true;
                dialog1.DefaultExt = "txt";
                dialog1.CheckFileExists = true;
                dialog1.CheckPathExists = true;
                dialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog1.FilterIndex = 2;
                dialog1.ShowReadOnly = true;
                dialog1.ShowDialog();


                if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory))
                {
                    valFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory, Strings.Len(modGlobal.gv_SelectedDirectory), 1) == "\\" ? "TableVal.txt" : "\\TableVal.txt");
                }
                else
                {
                    return;
                }

                FileSystem.FileOpen(1, valFile, OpenMode.Output);

                //retrieve the list of Validation Error messages
                modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
                modGlobal.gv_sql = string.Format("{" + "0} Where BaseTableid = {1}", modGlobal.gv_sql, thisTableID);

                if (string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{" + "0} and state = '{1}'", modGlobal.gv_sql, modGlobal.gv_State);
                }
                if (string.IsNullOrEmpty(modGlobal.gv_status))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{" + "0} and RecordStatus = '{1}'", modGlobal.gv_sql, modGlobal.gv_status);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " order by MessageType, substring(Message, 1, 150)";

                //LDW vrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                vrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, vrs);

                Cursor.Current = Cursors.WaitCursor;

                FileSystem.PrintLine(1, " Table Validation Messages ");
                FileSystem.PrintLine(1, "------------------------------");
                FileSystem.PrintLine(1, "------------------------------");
                FileSystem.PrintLine(1, " ");
                FileSystem.PrintLine(1, " ");

                //LDW while (!vrs.EOF)
                foreach (DataRow myRow1 in vrs.Tables[sqlTableName7].Rows)
                {
                    msgcount = msgcount + 1;

                    //LDW thismessageid = vrs.rdoColumns["TableValidationMessageID"].Value;
                    thismessageid = myRow1.Field<int>("TableValidationMessageID");

                    FileSystem.PrintLine(1, msgcount + "  ******************************************************************");

                    //LDW validatewhen = vrs.rdoColumns["messagetype"].Value + ": " + vrs.rdoColumns["validatewhen"].Value;
                    validatewhen = string.Format("{0}: {1}", myRow1.Field<string>("messagetype"), myRow1.Field<string>("validatewhen"));
                    FileSystem.PrintLine(1, validatewhen);
                    FileSystem.PrintLine(1, "");
                    //LDW vmessage = vrs.rdoColumns["Message"].Value;
                    vmessage = myRow1.Field<string>("Message");
                    FileSystem.PrintLine(1, vmessage);
                    FileSystem.PrintLine(1, "");
                    PrintTableValCriteria(thismessageid);
                    FileSystem.PrintLine(1, "");
                    //LDW vrs.MoveNext();
                }
                FileSystem.FileClose(1);
                Cursor.Current = Cursors.Default;
                RadMessageBox.Show("Table validation was exported into " + valFile);
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

        public static void PrintTableValCriteria(int thismessageid)
        {
            string CPref = null;
            string CSuff = null;
            //LDW object Cindex = null;
            int Cindex = 0;
            //LDW object TotalRec = null;
            int TotalRec = 0;
            //LDW object SetCount = null;
            int SetCount = 0;
            //LDW object TotalSetRec = null;
            int TotalSetRec = 0;
            string mainjoinop = "";
            //LDW object rs_critSet = null;
            var rs_critSet = new DataSet();
            const string sqlTableName8 = "tbl_setup_TableValidation";
            const string sqlTableName9 = "temp_table3";
            const string sqlTableName10 = "temp_table4";

            try
            {
                int rs_critsetIndexLast = rs_critSet.Tables[sqlTableName8].Rows.Count - 1;
                const int rs_critset_IndexFirst = 0;
                int rs_critset_Count = modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count;
                int gv_rsIndexLast = modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count - 1;
                const int gv_rsIndexFirst = 0;
                int gv_rsCount = modGlobal.gv_rs.Tables[sqlTableName10].Rows.Count;
                modGlobal.gv_sql = "Select CriteriaSet from tbl_setup_TableValidation ";
                modGlobal.gv_sql = string.Format("{0" + "} where tablevalidationmessageid = {1}", modGlobal.gv_sql, thismessageid);
                modGlobal.gv_sql = modGlobal.gv_sql + " group by CriteriaSet ";
                modGlobal.gv_sql = modGlobal.gv_sql + " order by CriteriaSet ";

                //LDW rs_critSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rs_critSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, rs_critSet);
                //LDW rs_critSet.MoveLast();
                //for (int index = 0; index <= rs_critsetIndexLast; index++)
                //{
                //    DataRow myRow2 = rs_critSet.Tables[sqlTableName8].Rows[index];
                //}

                //LDW TotalSetRec = rs_critSet.RowCount;
                TotalSetRec = rs_critSet.Tables[sqlTableName8].Rows.Count;

                ////LDW rs_critSet.MoveFirst();
                //for (int index = 0; index >= rs_critset_IndexFirst; index++)
                //{
                //    DataRow myRow2 = rs_critSet.Tables[sqlTableName8].Rows[index];
                //}

                //LDW if (rs_critSet.RowCount > 0)
                if (rs_critset_Count > 0)
                {
                    SetCount = SetCount + 1;
                    modGlobal.gv_sql = "Select * from tbl_setup_tablevalidationmessage ";
                    modGlobal.gv_sql = string.Format("{0} " + "where tablevalidationmessageid = {1}", modGlobal.gv_sql, thismessageid);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                    //LDW if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value))
                    if (!Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"]))
                    {
                        //LDW mainjoinop = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                        mainjoinop = modGlobal.gv_rs.Tables[sqlTableName9].Rows[0]["JoinOperator"].ToString();
                    }

                    //LDW while (!rs_critSet.EOF)
                    foreach (DataRow myRow in rs_critSet.Tables[sqlTableName8].Rows)
                    {
                        modGlobal.gv_sql = "Select * from tbl_setup_tablevalidation ";
                        modGlobal.gv_sql = string.Format("{0} where tablevalidationmessageid = {1}", modGlobal.gv_sql, thismessageid);
                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + " and CriteriaSet = " + rs_critSet["CriteriaSet"];
                        modGlobal.gv_sql = string.Format("{0} and CriteriaSet = {1}", modGlobal.gv_sql, myRow.Field<string>("CriteriaSet"));
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                        ////LDW modGlobal.gv_rs.MoveLast();
                        //for (int index = 0; index <= gv_rsIndexLast; index++)
                        //{
                        //    DataRow myRow2 = modGlobal.gv_rs.Tables[sqlTableName10].Rows[index];
                        //}

                        //LDW TotalRec = modGlobal.gv_rs.RowCount;
                        TotalRec = gv_rsCount;

                        ////LDW modGlobal.gv_rs.MoveFirst();
                        //for (int index = 0; index >= gv_rsIndexFirst; index++)
                        //{
                        //    DataRow myRow2 = modGlobal.gv_rs.Tables[sqlTableName10].Rows[index];
                        //}

                        Cindex = 0;
                        CSuff = "";

                        //LDW CPref = "Set " + modGlobal.gv_rs.rdoColumns["CriteriaSet"].Value + ": (";
                        CPref = string.Format("Set {0}: (", modGlobal.gv_rs.Tables[sqlTableName10].Rows[0]["CriteriaSet"]);

                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                        {
                            Cindex = Cindex + 1;
                            if (Cindex == TotalRec)
                            {
                                if (TotalRec == 1)
                                {
                                    //LDW CSuff = " (" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + ") )";
                                    CSuff = " (" + myRow3.Field<string>("JoinOperator");
                                }
                                else
                                {
                                    CSuff = ")";
                                }
                            }
                            else
                            {
                                //LDW CSuff = " " + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;
                                CSuff = " " + myRow3.Field<string>("JoinOperator");
                            }
                            if (Cindex == 1)
                            {
                                //LDW FileSystem.PrintLine(1, CPref + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                                FileSystem.PrintLine(1, CPref + myRow3.Field<string>("CriteriaTitle") + CSuff);
                            }
                            else
                            {
                                //LDW FileSystem.PrintLine(1, "          " + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + CSuff);
                                FileSystem.PrintLine(1, string.Format("          {0}{1}", myRow3.Field<string>("CriteriaTitle"), CSuff));
                            }
                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                        if (SetCount < TotalSetRec)
                        {
                            FileSystem.PrintLine(1, Strings.Chr(13));
                            FileSystem.PrintLine(1, mainjoinop);
                        }
                        //LDW rs_critSet.MoveNext();
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
    }
}
