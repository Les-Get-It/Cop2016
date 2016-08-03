using Microsoft.VisualBasic;
using System;
using Scripting;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Telerik.WinControls;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace COP2001
{
    static class modImportForCoreMeasVerify
    {
        [DllImport("comdlg32.dll", EntryPoint = "GetOpenFileNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

        public static extern bool GetOpenFileName(OPENFILENAME pOpenfilename);

        static string thisset;
        static int thisstep;
        static int thisindicatorid;
        static DateTime id_CoefPeriod;



        private struct DataDef
        {
            public string DDID;
            public string basetableid;
            public string FieldName;
            public string FieldType;
            public string FieldSize;
        }

        public struct MSA_OPENFILENAME
        {
            // Filter string used for the File Open dialog filters.
            // Use MSA_CreateFilterString() to create this.
            // Default = All Files, *.*
            public string strFilter;
            // Initial Filter to display.
            // Default = 1.
            public short lngFilterIndex;
            // Initial directory for the dialog to open in.
            // Default = Current working directory.
            public string strInitialDir;
            // Initial file name to populate the dialog with.
            // Default = "".
            public string strInitialFile;
            public string strDialogTitle;
            // Default extension to append to file if user didn't specify one.
            // Default = System Values (Open File, Save File).
            public string strDefaultExtension;
            // Flags (see constant list) to be used.
            // Default = no flags.
            public int lngFlags;
            // Full path of file picked.  On OpenFile, if the user picks a
            // nonexistent file, only the text in the "File Name" box is returned.
            public string strFullPathReturned;
            // File name of file picked.
            public string strFileNameReturned;
            // Offset in full path (strFullPathReturned) where the file name
            // (strFileNameReturned) begins.
            public int intFileOffset;
            // Offset in full path (strFullPathReturned) where the file extension begins.
            public int intFileExtension;
        }

        const string ALLFILES = "All Files";

        public struct OPENFILENAME
        {
            public int lStructSize;
            public int hWndOwner;
            public int hInstance;
            public string lpstrFilter;
            public int lpstrCustomFilter;
            public int nMaxCustrFilter;
            public short nFilterIndex;
            public string lpstrFile;
            public int nMaxFile;
            public string lpstrFileTitle;
            public int nMaxFileTitle;
            public string lpstrInitialDir;
            public string lpstrTitle;
            public int flags;
            public int nFileOffset;
            public int nFileExtension;
            public string lpstrDefExt;
            public int lCustrData;
            public int lpfnHook;
            public int lpTemplateName;
        }

        private struct CriteriaStep
        {
            public string SQL;
            public int PStep;
            public int GoToStep;
            // a, b, c, d, e, f, g
            public string CAT;
            // F, CI, RA
            public string CAT_TYPE;
            public bool HasGroupLogic;
        }

        private static object is_CaseIDName;
        private static object is_PMSIName;
        private static string is_BatchNoName;
        private static DataDef[] LinkedFields = new DataDef[] { };
        private static bool ib_CreateNewSavedGroupLogic;
        private static int li_VerifyID;



        public static void ImportMeasureRecs(int MeasureSetID, DateTime PeriodStart, DateTime PeriodEnd, string PeriodType, int NotImport)
        {
            //SH variables used
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            MSA_OPENFILENAME msaof = default(MSA_OPENFILENAME);
#pragma warning restore CS0219 // Variable is assigned but its value is never used
            int li_cnt = 0;
            FileSystemObject fileSystem_Renamed = new FileSystemObject();

            TextStream file = null;
            string[] ls_line = null;
            string ls_type = null;
            string[] ls_data = null;
            //LDW var li_field = 0;
            int li_field = 0;
            int li_VerifyID = 0;
            string ls_fields = null;
            int li_VRMID = 0;
            var rs_MeasureData = new DataSet();
            int li_MaxFields = 0;
            bool lb_move = false;
            string ls_values = null;
            string ls_insert = null;
            string destdrive = null;
            string FileName = null;
            string[] OtherFieldNm = null;
            var rs_Temp = new DataSet();
            string ls_Period = null;
            //var ps = (SqlCommand)null;
            SqlCommand ps = new SqlCommand();
            int li_IndicatorID = 0;
            string ls_CreateTable = null;
            string sqlTablename = "tbl_Setup_Indicator";
            string sqlTablename1 = "tbl_Setup_DataDef";
            frmImportMeasureSetFile frmImportMeasureSetFileCopy = new frmImportMeasureSetFile();



            try
            {
                //-search for the text filename
                //-import into a temp table
                //-validate data
                //-define the measure period for each record
                //-create a master record for each one
                //-add all of the field values for each master record

                //clear errors for correct error display
                modGlobal.ClearErrors();

                //determine if the measure set selected contains risk adjusted measures
                modGlobal.gv_sql = string.Format("SELECT SUM(ISNULL(RiskAdjusted,0)) as Risk FROM tbl_Setup_Indicator I, tbl_Setup_MeasureSet mS, " +
                    "tbl_Setup_MeasureSetMapMeas MMS  Where ms.MeasureSetID = mms.MeasureSetID And mms.IndicatorID = i.IndicatorID And ms.MeasureSetID = {0}", MeasureSetID);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTablename, modGlobal.gv_rs);

                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow in modGlobal.gv_rs.Tables[sqlTablename].Rows)
                {
                    //LDW if (modGlobal.gv_rs.rdoColumns["Risk"].Value > 0)
                    if (Convert.ToInt32(myRow.Field<string>("Risk")) > 0)
                    {
                        if (RadMessageBox.Show(string.Format("Please choose Yes to Accept the Default Coefficents to use as {0}.", PeriodStart),
                            "Risk Coefficient Start Date", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                        {
                            id_CoefPeriod = PeriodStart;
                        }
                        else
                        {
                            ls_Period = RadInputBox.Show("Please enter the risk adjusted period start date (MM/YYYY).", "Enter Risk Adjusted Coefficient Start Date");
                            if (Information.IsDate(ls_Period))
                            {
                                if (DateAndTime.Month(Convert.ToDateTime(ls_Period)) == 1 | DateAndTime.Month(Convert.ToDateTime(ls_Period)) == 4 |
                                    DateAndTime.Month(Convert.ToDateTime(ls_Period)) == 7 | DateAndTime.Month(Convert.ToDateTime(ls_Period)) == 10)
                                {
                                    id_CoefPeriod = Convert.ToDateTime(string.Format("{0}/1/{1}", DateAndTime.Month(Convert.ToDateTime(ls_Period)), DateAndTime.Year(Convert.ToDateTime(ls_Period))));
                                }
                            }
                            else
                            {
                                RadMessageBox.Show("Coefficient Period Start is not a valid date");
                                return;
                            }
                        }
                    }
                }
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();

                if (NotImport == 0)
                {
                    // Set options for the dialog box.
                    //msaof.strDialogTitle = "File Name To Import?"
                    //msaof.strInitialDir = destdrive
                    //msaof.strFilter = MSA_CreateFilterString("Csv (*.csv)", "*.csv")

                    // Call the Open File dialog routine.
                    //MSA_GetOpenFileName msaof

                    // Return the path and file name.
                    //filename = Trim(msaof.strFullPathReturned)

                    //If IsNull(filename) Or filename = "" Then

                    //     MsgBox "No File Selected. No Records Was Imported."
                    //     Exit Sub

                    /*LDW frmFindAFile.SetPath(ref "F:\\COP\\Verify\\");
                    frmFindAFile.SetPath(ref path);
                    frmFindAFile.Text = "Specify the source file";
                    frmFindAFile.ShowDialog();*/
                    string path = @"F:\COP\Verify\";
                    var dialog1 = new OpenFileDialog();
                    dialog1.InitialDirectory = path;
                    dialog1.Title = "Specify the source file";
                    dialog1.RestoreDirectory = true;
                    dialog1.DefaultExt = "txt";
                    dialog1.CheckFileExists = true;
                    dialog1.CheckPathExists = true;
                    dialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    dialog1.FilterIndex = 2;
                    dialog1.ShowReadOnly = true;
                    dialog1.ShowDialog();

                    if (string.IsNullOrEmpty(modGlobal.gv_SelectedFileName))
                    {
                        //strError = "Sorry, you must locate the sample file to run the process."
                        RadMessageBox.Show("Verification Process Will Not Continue, Because the Sample File Was Not Located Correctly.");
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    FileName = string.Format("{0}\\{1}", modGlobal.gv_SelectedDirectory, modGlobal.gv_SelectedFileName);
                }

                //GET ALL THE FIELDS LINKED TO THIS MEASURE SET
                modGlobal.gv_sql = string.Format("SELECT dd.DDID, BaseTableID, FieldName, FieldType, FieldSize  FROM tbl_Setup_FieldMeasureSet fm," +
                    "tbl_Setup_DataDef dd  WHERE dd.DDID = fm.DDID and fm.MeasureSetID = {0} ORDER BY OrderID ASC", MeasureSetID);

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTablename1, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTablename1].Rows)
                {
                    RadMessageBox.Show("No Fields have been linked to this measure set!", "No Fields for Measure Set", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }

                frmImportMeasureSetFileCopy.lblStatus.Text = "Importing the Cases into the Database";
                //LDW li_MaxFields = modGlobal.gv_rs.RowCount;
                li_MaxFields = modGlobal.gv_rs.Tables[sqlTablename1].Rows.Count;
                OtherFieldNm = new string[1];
                LinkedFields = new DataDef[1];

                if (NotImport == 0)
                {
                    //LDW modGlobal.gv_cn.Execute("if exists (select * from dbo.sysobjects where id = object_id(N'[tbl_MeasureData]')" + " and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [tbl_MeasureData]");
                    var command = new SqlCommand("if exists (select * from dbo.sysobjects where id = object_id(N'[tbl_MeasureData]')" + " and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [tbl_MeasureData]", modGlobal.gv_cn);
                    try
                    {
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Dispose();
                        modGlobal.gv_cn.Close();
                    }
                    catch (Exception ex)
                    {
                        RadMessageBox.Show("Error while opening connection: " + ex.Message);
                    }

                    //LDW modGlobal.gv_cn.Execute("if exists (select * from dbo.sysobjects where id = object_id(N'[tmp_MeasureData]')" + " and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [tmp_MeasureData]");
                    var command1 = new SqlCommand("if exists (select * from dbo.sysobjects where id = object_id(N'[tmp_MeasureData]')" +
                        " and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [tmp_MeasureData]", modGlobal.gv_cn);
                    try
                    {
                        command1.Connection.Open();
                        command1.ExecuteNonQuery();
                        command1.Dispose();
                        modGlobal.gv_cn.Close();
                    }
                    catch (Exception ex)
                    {
                        RadMessageBox.Show("Error while opening connection: " + ex.Message);
                    }

                    modGlobal.gv_sql = "DELETE FROM tbl_VerifyRecs";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }

                //CREATE TEMP TABLE BASED ON LINKEDFIELDS
                ls_CreateTable = "CREATE TABLE dbo.tbl_MeasureData ([VRMID] [int] , ";

                modGlobal.gv_sql = " tmp_MeasureData";

                ls_fields = "";

                ls_fields = "";
                for (li_cnt = 0; li_cnt <= li_MaxFields + 3; li_cnt++)
                {
                    Array.Resize(ref LinkedFields, li_cnt + 1);

                    //apply static fields as well as defined fields
                    if (li_cnt == 0)
                    {
                        LinkedFields[li_cnt].DDID = "HCOID";
                        LinkedFields[li_cnt].FieldName = "HCOID";
                        LinkedFields[li_cnt].FieldType = "Number";
                        lb_move = false;
                    }
                    else if (li_cnt == 1)
                    {
                        LinkedFields[li_cnt].DDID = "CaseID";
                        LinkedFields[li_cnt].FieldName = "CaseID";
                        LinkedFields[li_cnt].FieldType = "Number";
                        lb_move = false;
                    }
                    else if (li_cnt == li_MaxFields + 2)
                    {
                        LinkedFields[li_cnt].DDID = "PMSI";
                        LinkedFields[li_cnt].FieldName = "PMSI";
                        LinkedFields[li_cnt].FieldType = "Text";
                        LinkedFields[li_cnt].FieldSize = 7.ToString();
                        lb_move = false;
                    }
                    else if (li_cnt == li_MaxFields + 3)
                    {
                        LinkedFields[li_cnt].DDID = "BatchNo";
                        LinkedFields[li_cnt].FieldName = "BatchNo";
                        LinkedFields[li_cnt].FieldType = "Number";
                        lb_move = false;
                    }
                    else
                    {
                        //LDW LinkedFields[li_cnt].DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
                        LinkedFields[li_cnt].DDID = modGlobal.gv_rs.Tables[sqlTablename1].Rows[0]["DDID"].ToString();
                        //LDW LinkedFields[li_cnt].basetableid = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
                        LinkedFields[li_cnt].basetableid = modGlobal.gv_rs.Tables[sqlTablename1].Rows[0]["basetableid"].ToString();
                        //LDW LinkedFields[li_cnt].FieldName = modGlobal.gv_rs.rdoColumns["FieldName"].Value;
                        LinkedFields[li_cnt].FieldName = modGlobal.gv_rs.Tables[sqlTablename1].Rows[0]["FieldName"].ToString();
                        //LDW LinkedFields[li_cnt].FieldType = modGlobal.gv_rs.rdoColumns["FieldType"].Value;
                        LinkedFields[li_cnt].FieldType = modGlobal.gv_rs.Tables[sqlTablename1].Rows[0]["FieldType"].ToString();
                        //LDW LinkedFields[li_cnt].FieldSize = (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldSize"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FieldSize"].Value);
                        LinkedFields[li_cnt].FieldSize = (Information.IsDBNull(modGlobal.gv_rs.Tables[sqlTablename1].Rows[0]["FieldSize"].ToString()) ?
                            "" : modGlobal.gv_rs.Tables[sqlTablename1].Rows[0]["FieldSize"].ToString());
                        lb_move = true;
                    }
                    Array.Resize(ref OtherFieldNm, li_cnt + 1);
                    OtherFieldNm[li_cnt] = "F" + li_cnt + 1;

                    switch (LinkedFields[li_cnt].FieldType)
                    {
                        case "Date":
                        case "Time":
                            ls_type = "datetime";
                            break;
                        case "Number":
                            ls_type = "float";
                            break;
                        case "Text":
                            ls_type = string.Format("varchar ({0})", LinkedFields[li_cnt].FieldSize);
                            break;
                    }

                    if (li_cnt == 0)
                    {
                        //use static field name
                        modGlobal.gv_sql = string.Format("{0} {1}", OtherFieldNm[li_cnt], ls_type);
                    }
                    else
                    {
                        modGlobal.gv_sql = string.Format("{0}, {1} {2}", modGlobal.gv_sql, OtherFieldNm[li_cnt], ls_type);
                    }

                    //if (lb_move)
                    //LDW modGlobal.gv_rs.MoveNext();
                    //for (int index = 0; index < modGlobal.gv_rs.Tables[sqlTablename1].Rows.Count; index++)
                    //{
                    //    DataRow myRow3 = modGlobal.gv_rs.Tables[sqlTablename1].Rows[index];
                    //}
                }
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();


                string[] ls_StoredVTE = null;
                int li_Order = 0;
                int li_storedVTE = 0;

                if (NotImport == 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + ")";

                    //LDW modGlobal.gv_cn.Execute(ls_CreateTable + modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, ls_CreateTable + modGlobal.gv_sql);

                    ls_CreateTable = "CREATE TABLE tmp_MeasureData ([VRMID] [int] NOT NULL , ";
                    //LDW modGlobal.gv_cn.Execute(ls_CreateTable + modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, ls_CreateTable + modGlobal.gv_sql);

                    ls_values = Strings.Join(OtherFieldNm, ",");
                    file = fileSystem_Renamed.OpenTextFile(FileName, IOMode.ForReading, false, Tristate.TristateUseDefault);
                    li_cnt = 0;

                    //minimize the time the file is open, read one line at a time
                    while (!file.AtEndOfStream)
                    {
                        Array.Resize(ref ls_line, li_cnt + 1);
                        ls_line[li_cnt] = file.ReadLine();
                        li_cnt = li_cnt + 1;
                    }
                    file.Close();


                    if (string.IsNullOrEmpty(ls_line[Information.UBound(ls_line)]))
                    {
                        RadMessageBox.Show("No lines found in the file", "No records found in csv file", MessageBoxButtons.OK, RadMessageIcon.Error);
                        return;
                    }

                    frmImportMeasureSetFileCopy.pgStatus.Maximum = (Information.UBound(ls_line) + 1) * 5;

                    modGlobal.gv_sql = string.Format("SELECT VerifyID FROM tbl_VerifyRecs WHERE  PERIOD_START_DATE = convert(datetime, '{0} ',121) AND PERIOD_END_DATE = " +
                        "convert(datetime, '{1}',121) AND  MeasureSetID = {2}", PeriodStart, PeriodEnd, MeasureSetID);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                    const string sqlTableName2 = "tbl_VerifyRecs";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                    {
                        //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_VerifyRecMaster WHERE VerifyID = " + modGlobal.gv_rs.rdoColumns["VerifyID"].Value);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tbl_VerifyRecMaster WHERE VerifyID = " + myRow4.Field<string>("VerifyID"));

                        //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_VerifyRecDetail WHERE VerifyID = " + modGlobal.gv_rs.rdoColumns["VerifyID"].Value);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tbl_VerifyRecDetail WHERE VerifyID = " + myRow4.Field<string>("VerifyID"));

                        //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_EOCResults WHERE VerifyID = " + modGlobal.gv_rs.rdoColumns["VerifyID"].Value);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tbl_EOCResults WHERE VerifyID = " + myRow4.Field<string>("VerifyID"));


                        //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_HCOResults WHERE VerifyID = " + modGlobal.gv_rs.rdoColumns["VerifyID"].Value);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tbl_HCOResults WHERE VerifyID = " + myRow4.Field<string>("VerifyID"));

                        //LDW modGlobal.gv_rs.Delete();
                        modGlobal.gv_rs.Reset();
                    }
                    //LDW modGlobal.gv_rs.Close();
                    modGlobal.gv_rs.Dispose();

                    //DATA SHOULD BE PERMANENTLY STORED
                    //get verifyid
                    modGlobal.gv_sql = string.Format("INSERT INTO tbl_VerifyRecs (PERIOD_START_DATE, PERIOD_END_DATE, MeasureSetID)  VALUES (convert(datetime, '{0}',121), convert(datetime, '{1}',121),{2})"
                        , PeriodStart, PeriodEnd, MeasureSetID);

                    //modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    string table_ref1 = "tbl_VerifyRecs";
                    li_VerifyID = modGlobal.GetLastID(table_ref1);

                    //delete data for testing purposes
                    //gv_sql = "DELETE FROM tbl_VerifyRecMaster"
                    //gv_cn.Execute gv_sql
                    //gv_sql = "DELETE FROM tbl_VerifyRecDetail"
                    //gv_cn.Execute gv_sql

                    Application.DoEvents();

                    modGlobal.gv_sql = "DELETE FROM tbl_MeasureData";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    for (li_cnt = 0; li_cnt <= Information.UBound(ls_line); li_cnt++)
                    {
                        ls_data = Strings.Split(ls_line[li_cnt], ",");
                        frmImportMeasureSetFileCopy.lblStatus.Text = "Importing Case " + li_cnt + 1 + " of " + Information.UBound(ls_line) + 1;

                        if (Information.UBound(ls_data) != Information.UBound(LinkedFields))
                        {
                            //MsgBox "The file and the mapped fields do not match", vbCritical, "Number of Fields Discrepancy"
                            //Exit Sub

                            //just redim the array to match the number of values, the bottom code will replace values with nulls
                            Array.Resize(ref ls_data, Information.UBound(LinkedFields) + 1);
                        }


                        //we need to fix the VTE Timely Import Fields
                        if (MeasureSetID == 4)
                        {
                            //store the vte values for reassignment
                            li_storedVTE = 0;
                            for (li_Order = (368); li_Order <= (379); li_Order++)
                            {
                                Array.Resize(ref ls_StoredVTE, li_storedVTE + 1);
                                ls_StoredVTE[li_storedVTE] = ls_data[li_Order];

                                if (li_Order == 369 | li_Order == 371 | li_Order == 373 | li_Order == 375 | li_Order == 377 | li_Order == 379)
                                {
                                    ls_data[li_Order] = "";
                                }

                                li_storedVTE = li_storedVTE + 1;
                            }

                            li_Order = 366;
                            while ((li_Order + 2) <= 378)
                            {
                                if (!string.IsNullOrEmpty(ls_data[li_Order + 2]))
                                {
                                    const string one = "1";
                                    const string two = "2";
                                    const string three = "3";
                                    const string four = "4";
                                    const string five = "5";
                                    const string six = "6";

                                    switch (ls_data[li_Order + 2])
                                    {

                                        //LDUH
                                        //LDW case Convert.ToString(1):
                                        case one:
                                            ls_data[369] = ls_StoredVTE[(li_Order + 2) - 367];
                                            break;
                                        //LMWH
                                        case two:
                                            ls_data[371] = ls_StoredVTE[(li_Order + 2) - 367];
                                            break;
                                        //ls_data(li_Order + 3) = ""
                                        //IPC
                                        case three:
                                            ls_data[373] = ls_StoredVTE[(li_Order + 2) - 367];
                                            break;
                                        //ls_data(li_Order + 3) = ""
                                        //GCS
                                        case four:
                                            ls_data[375] = ls_StoredVTE[(li_Order + 2) - 367];
                                            break;
                                        //ls_data(li_Order + 3) = ""
                                        //Xa Inhibitor
                                        case five:
                                            ls_data[377] = ls_StoredVTE[(li_Order + 2) - 367];
                                            break;
                                        //ls_data(li_Order + 3) = ""
                                        //Warfarin
                                        case six:
                                            ls_data[379] = ls_StoredVTE[(li_Order + 2) - 367];
                                            break;
                                            //ls_data(li_Order + 3) = ""
                                            //Case "A"
                                            //ls_data(379) = ls_StoredVTE((li_Order + 2) - 367)
                                            //ls_data(li_Order + 3) = ""
                                    }
                                }
                                li_Order = li_Order + 2;
                            }
                        }

                        //create master verify record id
                        modGlobal.gv_sql = string.Format("INSERT INTO tbl_VerifyRecMaster (VERIFYRECNO, VERIFYID) VALUES ({0},{1})", li_cnt, li_VerifyID);
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                        const string table_ref2 = "tbl_VerifyRecMaster";
                        li_VRMID = modGlobal.GetLastID(table_ref2);

                        for (li_field = 0; li_field <= Information.UBound(ls_data); li_field++)
                        {
                            //SR TRIM 7.24.2006
                            ls_data[li_field] = Strings.Trim(ls_data[li_field]);
                            //check data type, length, if anything doesn't match make the value NULL (for invalid data)
                            if (LinkedFields[li_field].FieldType == "Text" & Strings.Len(Strings.Trim(ls_data[li_field])) > 0)
                            {
                                if (Convert.ToDouble(LinkedFields[li_field].FieldSize) < Strings.Len(ls_data[li_field]))
                                {
                                    //too big a text field
                                    ls_data[li_field] = "NULL";
                                }
                                else
                                {
                                    ls_data[li_field] = string.Format(" ltrim('{0}')", ls_data[li_field]);
                                }
                            }
                            else if ((LinkedFields[li_field].FieldType == "Date" | LinkedFields[li_field].FieldType == "Time") & Strings.Len(Strings.Trim(ls_data[li_field])) > 0)
                            {
                                if (Information.IsDate(ls_data[li_field]) | ls_data[li_field] == "UTD")
                                {
                                    ls_data[li_field] = string.Format("'{0}'", ls_data[li_field]);
                                }
                                else
                                {
                                    ls_data[li_field] = "NULL";
                                }
                            }
                            else if (LinkedFields[li_field].FieldType == "Number" & Strings.Len(Strings.Trim(ls_data[li_field])) > 0)
                            {
                                if (!Information.IsNumeric(ls_data[li_field]) & ls_data[li_field] != "UTD")
                                {
                                    ls_data[li_field] = "NULL";
                                }
                            }
                            else
                            {
                                if (Strings.Len(Strings.Trim(ls_data[li_field])) == 0)
                                    ls_data[li_field] = "NULL";
                            }

                            //6.22.05 - do not run this costly query
                            //gv_sql = "SELECT * FROM tbl_VerifyRecDetail  "
                            //gv_sql = gv_sql & " where VRMID = " & li_VRMID
                            //gv_sql = gv_sql & "  AND DDID = '" & LinkedFields(li_field).DDID & "'"
                            //gv_g = InputBox("", "", gv_sql)
                            //Set rs_Temp = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)

                            //If rs_Temp.RowCount = 0 Then
                            //insert the field into the detail table
                            modGlobal.gv_sql = "INSERT INTO tbl_VerifyRecDetail (DDID, VRMID, VERIFYID, FIELDVALUE) VALUES ";
                            modGlobal.gv_sql = string.Format("{0}('{1}',{2},{3},{4})", modGlobal.gv_sql, LinkedFields[li_field].DDID, li_VRMID, li_VerifyID, ls_data[li_field]);
                            //gv_g = InputBox("", "", gv_sql)
                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }

                        modGlobal.gv_sql = string.Format("INSERT INTO tbl_MeasureData (VRMID,{0}) VALUES ({1},{2})", ls_values, li_VRMID, Strings.Join(ls_data, ","));

                        //Open "C:\iha\test.sql" For Output As #1
                        //Print #1, gv_sql
                        //Close #1

                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                        frmImportMeasureSetFileCopy.pgStatus.Value1 = li_cnt;
                        Application.DoEvents();
                    }

                    //remove the leading spaces from the text fields
                    modGlobal.gv_sql = "update tbl_VerifyRecDetail ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " set fieldvalue = ltrim(fieldvalue) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_VerifyRecDetail inner join tbl_setup_datadef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on tbl_VerifyRecDetail.ddid = tbl_setup_datadef.ddid ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where upper(fieldtype) = 'TEXT' ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and isnumeric(tbl_VerifyRecDetail.ddid) = 1 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " and fieldvalue is not null ";
                    modGlobal.gv_sql = string.Format("{0} and verifyid = {1}", modGlobal.gv_sql, li_VerifyID);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                }
                else
                {
                    //LDW li_VerifyID = modGlobal.GetLastID(ref "tbl_VerifyRecs");
                    const string ref_table3 = "tbl_VerifyRecs";
                    li_VerifyID = modGlobal.GetLastID(ref_table3);
                }

                frmImportMeasureSetFileCopy.lblStatus.Text = "Starting Flowchart Logic";
                VerifyPatRecs(MeasureSetID, li_VerifyID);

                RadMessageBox.Show("Check the HCO_Answers and EOC_Answer files in the app directory", "Import and Process Successful!", MessageBoxButtons.OK, RadMessageIcon.Info);

                //LDW ErrHandler:

                Cursor.Current = Cursors.Default;
                //LDW modGlobal.CheckForErrors();
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
            return;
        }


        private static int LookupLocationOnDDID(string DDID)
        {
            int functionReturnValue = 0;
            int li_cnt = 0;
            var thisrs = new DataSet();
            string thisfieldname = null;
            string thisindicator = null;
            const string sqlTableName5 = "tbl_setup_datadef";
            const string sqlTableName6 = "tbl_setup_indicator";


            try
            {
                for (li_cnt = 0; li_cnt <= Information.UBound(LinkedFields); li_cnt++)
                {
                    if (LinkedFields[li_cnt].DDID == DDID)
                    {
                        functionReturnValue = li_cnt + 1;
                        return functionReturnValue;
                    }
                }

                modGlobal.gv_sql = "select * from tbl_setup_datadef where ddid = " + DDID;
                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, thisrs);

                //LDW thisfieldname = thisrs.rdoColumns["FieldName"].Value;
                thisfieldname = thisrs.Tables[sqlTableName5].Rows[0]["FieldName"].ToString();
                //LDW thisrs.Close();
                thisrs.Dispose();

                modGlobal.gv_sql = "select * from tbl_setup_indicator where indicatorid = " + thisindicatorid;
                //LDW thisrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                thisrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, thisrs);
                //LDW thisindicator = thisrs.rdoColumns["JCAHOID"].Value;
                thisindicator = thisrs.Tables[sqlTableName6].Rows[0]["JCAHOID"].ToString();
                //LDW thisrs.Close();
                thisrs.Dispose();

                RadMessageBox.Show(string.Format("Processing {0}, Step {1}, Set {2}: {3}{4} is not mapped to this measure set.{3} Please re-check your flowcharts",
                    thisindicator, thisstep, thisset, Constants.vbCrLf, thisfieldname));
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

            //MsgBox LinkedFields(li_cnt).FieldName & " is not mapped to this measure set." & vbCrLf & _
            //' " Please re-check your flowcharts"
        }

        public static string VerifyPatRecs(int MeasureSetID, int VerifyID)
        {
            string functionReturnValue = null;
            //LDW object rs_MeasureStep = null;
            var rs_MeasureStep = new DataSet();
            var rs_MeasureCriteria = new DataSet();
            var rs_Temp = new DataSet();
            var rs_Measures = new DataSet();
            var rs_MeasureSet = new DataSet();
            var rs_IHARS = new DataSet();
            string FieldType = null;
            string QCondition = null;
            string MainJOp = null;
            string AllConditions = null;
            int DateFieldDDID1 = 0;
            int DateFieldDDID2 = 0;
            string SetConditions = null;
            var li_StepCnt = 0;
            var li_MeasCnt = 1;
            int li_cnt = 0;
            CriteriaStep[] StepConditions = new CriteriaStep[] { };
            var rs_VerifyRecs = new DataSet();
            string StepCondition = null;
            //LDW var li_MaxMeas = 0;
            int li_MaxMeas = 0;
            int li_StartVal = 0;
            int li_FieldLoc = 0;
            int li_SetCnt = 0;
            string ls_LastJoin = null;
            string ls_PrevCatType = null;
            bool lb_FilterMeasure = false;
            var rs_MeasGroup = new DataSet();
            string ls_GroupJoin = null;
            int li_MaxGroup = 0;
            int li_MaxSetinGroup = 0;
            string GroupCondition = null;
            string GroupSubCondition = null;
            int li_LastGroupNo = 0;
            int CaseElseVal;
            int CritCount = 0;
            string CheckForNull = null;
            string setJoinOp = null;
            bool ExceptionMethod = false;
            int li_CritCount = 0;
            SqlCommand ps = new SqlCommand();
            DataSet rs_PatRecCrit = new DataSet();
            bool lb_MeasureHasGroup = false;
            DataSet rs_Impute = new DataSet();
            var rs_Impute2 = new DataSet();
            var rs_Impute3 = new DataSet();
            int ParentDDID = 0;
            int[] ChildDDID = null;
            int li_Children = 0;
            bool lb_RA = false;
            string ls_multSelAny = null;
            const string sqlTableName20 = "tbl_Setup_MeasureSetMapMeas";
            string sqlTableName21;
            string sqlTableName22;
            string sqlTableName23;
            string sqlTableName24;
            string sqlTableName25;
            string sqlTableName26;
            string sqlTableName27;
            string sqlTableName28;
            string sqlTableName29;
            string sqlTableName30;
            string sqlTableName31;
            string sqlTableName32 = "temp_VerifyResults";
            string sqltableName33;
            frmImportMeasureSetFile frmImportMeasureSetFileCopy = new frmImportMeasureSetFile();

            try
            {
                modGlobal.ClearErrors();

                //LDW modGlobal.gv_cn.Execute("delete FROM temp_VerifyResults");
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "delete FROM temp_VerifyResults");


                //LDW modGlobal.gv_cn.Execute("delete from tbl_EOCResults WHERE VerifyID = " + VerifyID);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "delete FROM temp_VerifyResults");


                modGlobal.gv_sql = "{ call UpdateSavedGroupCriteriaLogic }";
                //LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = modGlobal.gv_sql;
                SqlParameter retParam = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam.Direction = ParameterDirection.ReturnValue;

                //LDW ps.Execute();
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                    ps.Dispose();
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show("Error while opening connection: " + ex.Message);
                }
                //LDW ps.Close();

                modGlobal.gv_sql = "{ call UpdateMeasureCriteriaMultSelLogic }";
                //LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = modGlobal.gv_sql;
                SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam1.Direction = ParameterDirection.ReturnValue;
                //LDW ps.Execute();
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                    ps.Dispose();
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show("Error while opening connection: " + ex.Message);
                }
                //LDW ps.Close();

                //get measures (one at a time) and process each
                modGlobal.gv_sql = string.Format("SELECT i.IndicatorID, i.Description, i.RiskAdjusted, JCAHOID FROM  tbl_Setup_MeasureSetMapMeas mmm," +
                    "tbl_Setup_Indicator i WHERE mmm.IndicatorID = i.IndicatorID AND  mmm.MeasureSetID = {0}", MeasureSetID);
                if (frmImportMeasureSetFileCopy.lstIndicators.SelectedIndex > -1)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    modGlobal.gv_sql = string.Format("{0} AND i.IndicatorID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(frmImportMeasureSetFileCopy.lstIndicators, frmImportMeasureSetFileCopy.lstIndicators.SelectedIndex));
#pragma warning restore CS0618 // Type or member is obsolete
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY i.INDICATORID";
                //LDW rs_Measures = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                rs_Measures = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, rs_Measures);
                //LDW if (rs_Measures.EOF)
                int totalRec20 = rs_Measures.Tables[sqlTableName20].Rows.Count;
                for (int index20 = 0; index20 < totalRec20; index20++)
                {
                    var myRow = rs_Measures.Tables[sqlTableName20].Rows[index20];
                    int rowIndex = rs_Measures.Tables[sqlTableName20].Rows.IndexOf(myRow);

                    if (rowIndex == totalRec20 - 1)
                    {
                        return functionReturnValue;
                    }
                }

                //LDW li_MaxMeas = rs_Measures.RowCount;
                li_MaxMeas = rs_Measures.Tables[sqlTableName20].Rows.Count;
                li_StartVal = frmImportMeasureSetFileCopy.pgStatus.Value1;
                if (li_StartVal == 0)
                    li_StartVal = 1;
                li_MeasCnt = 0;

                string[] ls_FieldValue = null;
                var rs_Method6 = new DataSet();
                string[] ls_LookupLocs = null;
                string ls_Sql = null;
                string ls_SelField = null;
                string[] ls_sqlStmts = null;
                string ls_join = null;
                string[] Months = null;
                string ls_months = null;
                //LDW object ProcessGoToStep = null;
                bool ProcessGoToStep;
                string StartHere = null;
                string ls_FirstDate = null;
                string ls_SecondDate = null;
                var li_fieldCnt = 0;
                int li_TimeLoc = 0;

                //LDW while (!rs_Measures.EOF)
                foreach (DataRow myRow in rs_Measures.Tables[sqlTableName20].Rows)
                {
                    li_MeasCnt = li_MeasCnt + 1;
                    ls_PrevCatType = "";
                    lb_MeasureHasGroup = false;

                    //LDW thisindicatorid = rs_Measures.rdoColumns["IndicatorID"].Value;
                    thisindicatorid = myRow.Field<int>("IndicatorID");
                    //LDW frmImportMeasureSetFile.lblStatus.Text = "Processing " + rs_Measures.rdoColumns["JCAHOID"].Value;
                    frmImportMeasureSetFileCopy.lblStatus.Text = "Processing " + myRow.Field<string>("JCAHOID");

                    // Remove all the Related Group Logic for any previous measure
                    modGlobal.gv_sql = "DELETE FROM tbl_temp_tTempPatRecCriteria";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    modGlobal.gv_sql = "DELETE FROM tbl_temp_tTempPatRecs";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    modGlobal.gv_sql = "DELETE FROM tbl_temp_MeasureSetGroupResults";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    modGlobal.gv_sql = "DELETE FROM tbl_temp_MeasureStepGroupResults";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_Submit_OnlyProceedWithStep");
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tbl_Submit_OnlyProceedWithStep");

                    //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_Submit_OnlyProceedWithPatRecFields");
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tbl_Submit_OnlyProceedWithStep");

                    //LDW modGlobal.gv_cn.Execute("DELETE FROM tbl_temp_TempDetailData ");
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tbl_temp_TempDetailData");


                    modGlobal.gv_sql = string.Format("INSERT INTO tbl_Submit_OnlyProceedWithStep (Step, MeasureSet, MeasureFieldGroupLogicID) SELECT DISTINCT tbl_Setup_MEASURESTEP.MeasureStep, tbl_Setup_MeasureCriteriaSet.MeasureCriteriaSet, tbl_Setup_MEASURECRITERIA.MeasureFieldGroupLogicID FROM (tbl_Setup_MEASURECRITERIA INNER JOIN tbl_Setup_MEASURECRITERIASET ON tbl_Setup_MEASURECRITERIA.MeasureCriteriaSetID = tbl_Setup_MEASURECRITERIASET.MeasureCriteriaSetID) INNER JOIN tbl_Setup_MEASURESTEP ON tbl_Setup_MEASURECRITERIASET.MeasureStepID = tbl_Setup_MEASURESTEP.MeasureStepID  WHERE (((tbl_Setup_MEASURECRITERIA.MeasureFieldGroupLogicID) Is Not Null) AND ((tbl_Setup_MEASURESTEP.MeasureID)={0}))", thisindicatorid);
                    //  Debug.Print gv_sql

                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    modGlobal.gv_sql = "DELETE FROM tbl_Submit_OnlyProceedWithStep WHERE MeasureFieldGroupLogicID in (SELECT MeasureFieldGroupLogicID FROM tbl_Setup_MeasureFieldGroupLogic WHERE OnlyProceedWithRelatedFieldGroup = 0)";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                    //order by cat (assuming categories are NULL (for filter) a, b, c, d, e, f, g)
                    //Process one step at a time
                    modGlobal.gv_sql = "SELECT MeasureStepID, MeasureStep, CAT, CAT_TYPE, GoToStep, IsRisk ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureStep ms ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " left join tbl_Measure_Cat mc ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " on mc.Measure_CATID = ms.Measure_CATID ";
                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " WHERE MeasureID = " + rs_Measures.rdoColumns["IndicatorID"].Value;
                    modGlobal.gv_sql = string.Format("{0} WHERE MeasureID = {1}", modGlobal.gv_sql, myRow.Field<string>("IndicatorID"));
                    modGlobal.gv_sql = modGlobal.gv_sql + " AND MeasureStep > 0 ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY MeasureStep ASC ";

                    //LDW rs_MeasureStep = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    sqlTableName21 = "tbl_Setup_MeasureStep";
                    rs_MeasureStep = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, rs_MeasureStep);

                    //LDW if (!rs_MeasureStep.EOF)
                    for (int itr = 0; itr < rs_MeasureStep.Tables[sqlTableName21].Rows.Count; itr++)
                    {
                        var row1 = rs_MeasureStep.Tables[sqlTableName21].Rows[itr];
                        int rowIndex = rs_MeasureStep.Tables[sqlTableName21].Rows.IndexOf(row1);
                        if (rowIndex != rs_MeasureStep.Tables[sqlTableName21].Rows.Count - 1)
                        {
                            li_StepCnt = 0;
                            StepConditions = new CriteriaStep[li_StepCnt + 1];

                            //If this step has a gotostep field value, if the condition is true, the loop has to proceed to the defined step number
                            // without going over the middle steps

                            //LDW while (!rs_MeasureStep.EOF)
                            foreach (DataRow myRow1 in rs_MeasureStep.Tables[sqlTableName21].Rows)
                            {
                                Array.Resize(ref StepConditions, li_StepCnt + 1);
                                StepConditions[li_StepCnt].HasGroupLogic = false;
                                //LDW StepConditions[li_StepCnt].PStep = rs_MeasureStep["measurestep"];
                                StepConditions[li_StepCnt].PStep = myRow1.Field<int>("measurestep");
                                modGlobal.gv_sql = string.Format("SELECT mcs.*, msg.JoinOperator as GroupJoin, msg.MeasureStepGroup FROM tbl_Setup_MeasureStepGroup msg, " +
                                    "tbl_Setup_MeasureCriteriaSet mcs WHERE msg.MeasureStepID = {0} AND msg.MeasureStepID = mcs.MeasureStepID  AND msg.MeasureCriteriaSetID = " +
                                    "mcs.MeasureCriteriaSetID  ORDER BY msg.MeasureStepGroup, mcs.MeasureCriteriaSet ASC", myRow1.Field<int>("MeasureStepID"));

                                //LDW rs_MeasureSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                sqlTableName22 = "tbl_Setup_MeasureStepGroup";
                                rs_MeasureSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, rs_MeasureSet);
                                //LDW if (!rs_MeasureSet.EOF)
                                int totalRec22 = rs_MeasureStep.Tables[sqlTableName22].Rows.Count;

                                for (int index22 = 0; index22 < rs_MeasureSet.Tables[sqlTableName22].Rows.Count; index22++)
                                {
                                    var myRow2 = rs_MeasureSet.Tables[sqlTableName22].Rows[index22];
                                    int rowIndex1 = rs_MeasureSet.Tables[sqlTableName22].Rows.IndexOf(myRow2);

                                    if (rowIndex1 != totalRec22 - 1)
                                    {
                                        //LDW ls_GroupJoin = rs_MeasureSet.rdoColumns["GroupJoin"].Value;
                                        ls_GroupJoin = myRow2.Field<string>("GroupJoin");
                                    }
                                    else
                                    {
                                        //LDW rs_MeasureSet.Close();
                                        rs_MeasureSet.Dispose();
                                        ls_GroupJoin = "";
                                        //find and place them in a set of parenthesis
                                        //LDW modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE " + " MeasureStepID = " + rs_MeasureStep["MeasureStepID"] + " ORDER BY MeasureCriteriaSet ASC";
                                        modGlobal.gv_sql = string.Format("SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE  MeasureStepID = {0} ORDER BY MeasureCriteriaSet ASC",
                                            myRow2.Field<string>("MeasureSetID"));

                                        //LDW rs_MeasureSet = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                        sqlTableName23 = "tbl_Setup_MeasureCriteriaSet";
                                        rs_MeasureSet = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, rs_MeasureSet);
                                    }
                                }

                                StepCondition = "";
                                GroupCondition = "";
                                GroupSubCondition = "";
                                li_LastGroupNo = 0;

                                modGlobal.gv_sql = "DELETE FROM tbl_temp_MeasureSetGroupResults";
                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                //LDW if (rs_MeasureSet.EOF)
                                int totalRec23 = rs_MeasureSet.Tables[sqlTableName22].Rows.Count;
                                for (int index23 = 0; index23 < totalRec23; index23++)
                                {
                                    var row23 = rs_MeasureSet.Tables[sqlTableName22].Rows[index23];
                                    int rowIndex23 = rs_MeasureSet.Tables[sqlTableName22].Rows.IndexOf(row23);

                                    if (rowIndex23 == totalRec23 - 1)
                                    {
                                        //goto ErrHandler;
                                    }
                                }

                                //LDW if (Information.IsDBNull(rs_MeasureSet.rdoColumns["JoinOperator"].Value))
                                if (Information.IsDBNull(rs_MeasureSet.Tables[sqlTableName22].Rows[0]["JoinOperator"]))
                                {
                                    MainJOp = "AND   ";
                                }
                                else
                                {
                                    //LDW MainJOp = Strings.Trim(Strings.UCase(rs_MeasureSet.rdoColumns["JoinOperator"].Value)) + "   ";
                                    MainJOp = Strings.Trim(Strings.UCase(rs_MeasureSet.Tables[sqlTableName22].Rows[0]["JoinOperator"].ToString())) + "   ";
                                }

                                //LDW while (!rs_MeasureSet.EOF)
                                foreach (DataRow myRow5 in rs_MeasureSet.Tables[sqlTableName22].Rows)
                                {
                                    //LDW thisset = rs_MeasureSet.rdoColumns["MeasureCriteriaSet"].Value;
                                    thisset = myRow5.Field<string>("MeasureCriteriaSet");
                                    //LDW thisstep = rs_MeasureStep["measurestep"];
                                    thisstep = myRow1.Field<int>("measurestep");

                                    //It is important to select the proceed only with criteria before the regular criteria
                                    modGlobal.gv_sql = " SELECT tbl_Setup_MeasureCriteria.* ";
                                    modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_MeasureCriteria LEFT JOIN tbl_Setup_MeasureFieldGroupLogic " +
                                        "ON tbl_Setup_MeasureCriteria.MeasureFieldGroupLogicID = tbl_Setup_MeasureFieldGroupLogic.MeasureFieldGroupLogicID ";
                                    //LDW modGlobal.gv_sql = string.Format("{0} WHERE (((tbl_Setup_MeasureCriteria.MeasureCriteriaSetID) = {1})) ", modGlobal.gv_sql, rs_MeasureSet.rdoColumns["MeasureCriteriaSetID"].Value);

                                    modGlobal.gv_sql = string.Format("{0} WHERE (((tbl_Setup_MeasureCriteria.MeasureCriteriaSetID) = {1})) ",
                                        modGlobal.gv_sql, rs_MeasureSet.Tables[sqlTableName22].Rows[0]["MeasureCriteriaSetID"]);


                                    modGlobal.gv_sql = modGlobal.gv_sql + " ORDER BY tbl_Setup_MeasureFieldGroupLogic.OnlyProceedWithRelatedFieldGroup DESC, " +
                                        "tbl_Setup_MeasureFieldGroupLogic.MeasureFieldGroupLogicID DESC , tbl_Setup_MeasureCriteria.MeasureCriteriaID ASC";

                                    //LDW rs_MeasureCriteria = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                    sqlTableName24 = "tbl_Setup_MeasureCriteria";
                                    rs_MeasureCriteria = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, rs_MeasureCriteria);

                                    SetConditions = "";
                                    ls_LastJoin = "";

                                    //SH 2.23.2005 movelast for rdo recordset to get right row count & added trim
                                    //LDW rs_MeasureCriteria.MoveLast();
                                    //int rs_MeasureCriteriaIndexLast = rs_MeasureCriteria.Tables[sqlTableName24].Rows.Count - 1;

                                    //for (int index24 = 0; index24 <= rs_MeasureCriteriaIndexLast; index24++)

                                    //DataRow myRow6 = rs_MeasureCriteria.Tables[sqlTableName24].Rows[index24];

                                    //LDW if (rs_MeasureCriteria.RowCount > 0)
                                    if (rs_MeasureCriteria.Tables[sqlTableName24].Rows.Count > 0)
                                    {
                                        //LDW rs_MeasureCriteria.MoveFirst();
                                        //for (index24 = 0; index24 >= 0; index24++)
                                        //{
                                        //    myRow6 = rs_MeasureCriteria.Tables[sqlTableName24].Rows[index24];
                                        //}
                                        //LDW setJoinOp = Strings.Trim(rs_MeasureCriteria.rdoColumns["JoinOperator"].Value);
                                        setJoinOp = Strings.Trim(rs_MeasureCriteria.Tables[sqlTableName24].Rows[0]["JoinOperator"].ToString());
                                        //LDW CritCount = rs_MeasureCriteria.RowCount;
                                        CritCount = rs_MeasureCriteria.Tables[sqlTableName24].Rows.Count;
                                    }

                                    li_CritCount = 0;

                                    //LDW while (!rs_MeasureCriteria.EOF)
                                    foreach (DataRow myRow7 in rs_MeasureCriteria.Tables[sqlTableName24].Rows)
                                    {
                                        //METHOD 6 - to be handled differently than anything else
                                        ExceptionMethod = false;
                                        li_CritCount = li_CritCount + 1;

                                        //this means that there is saved group logic which needs to run
                                        //LDW if (!Information.IsDBNull(rs_MeasureCriteria.rdoColumns["measurefieldgrouplogicid"].Value) | StepConditions[li_StepCnt].HasGroupLogic)
                                        if (!Information.IsDBNull(myRow7.Field<string>("measurefieldgrouplogicid")) | StepConditions[li_StepCnt].HasGroupLogic)
                                        {
                                            StepConditions[li_StepCnt].HasGroupLogic = true;

                                            if (lb_MeasureHasGroup == false)
                                            {
                                                modGlobal.gv_sql = string.Format("INSERT INTO tbl_temp_TempDetailData (VRMID, DDID, FieldValue) SELECT DISTINCT VRMID, DDID, " +
                                                    "FieldValue FROM tbl_VerifyRecDetail WHERE VerifyID = {0} AND IsNumeric(DDID) = 1", VerifyID);
                                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                                modGlobal.gv_sql = "Update tbl_temp_TempDetailData SET FieldValue = '' WHERE fieldvalue is null";
                                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                                modGlobal.gv_sql = "Update tbl_temp_TempDetailData SET FieldValue = RTRIM(FieldValue)";
                                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                Application.DoEvents();

                                                //LDW if (rs_Measures.rdoColumns["JCAHOID"].Value == 14449 | rs_Measures.rdoColumns["JCAHOID"].Value == 14450)
                                                if (myRow.Field<int>("JCAHOID") == 14449 | myRow.Field<int>("JCAHOID") == 14450)
                                                {
                                                    modGlobal.gv_sql = " SELECT VRMID, COUNT(DDID) AS ValidNames From vuVerifyValidAntibioticNames GROUP BY VRMID";
                                                    //LDW rs_Impute = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                    sqlTableName25 = "vuVerifyValidAntibioticNames";
                                                    rs_Impute = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName25, rs_Impute);
                                                    //LDW while (!rs_Impute.EOF)
                                                    foreach (DataRow myRow8 in rs_Impute.Tables[sqlTableName25].Rows)
                                                    {
                                                        // only fill in the times where some of the times are missing from the valid names, but not all of them
                                                        //SR - changed 6.27.06 fill in even if they're all blank
                                                        modGlobal.gv_sql = " SELECT vu.VRMID, count(DISTINCT related.DDID ) as CntNullTimes ";
                                                        modGlobal.gv_sql = modGlobal.gv_sql + " FROM vuVerifyValidAntibioticNames vu, tbl_Setup_DDIDRelatedFieldGroup related, " +
                                                            "tbl_temp_tempDetailData dat, tbl_Setup_DDIDFieldGroup grp";
                                                        modGlobal.gv_sql = modGlobal.gv_sql + "  Where related.RelatedFieldGroupID = vu.RelatedFieldGroupID";
                                                        modGlobal.gv_sql = modGlobal.gv_sql + "  AND dat.DDID = related.DDID";
                                                        modGlobal.gv_sql = modGlobal.gv_sql + " AND FieldGroupID = 3";
                                                        modGlobal.gv_sql = modGlobal.gv_sql + " AND vu.VRMID = dat.VRMID";
                                                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + " AND vu.VRMID = " + rs_Impute.rdoColumns["VRMID"].Value;
                                                        modGlobal.gv_sql = string.Format("{0} AND vu.VRMID = {1}", modGlobal.gv_sql, myRow8.Field<string>("VRMID"));
                                                        modGlobal.gv_sql = modGlobal.gv_sql + " AND FieldValue = '' AND grp.DDID = dat.DDID";
                                                        modGlobal.gv_sql = modGlobal.gv_sql + "  GROUP BY vu.VRMID ";

                                                        //Debug.Print gv_sql
                                                        //LDW rs_Impute2 = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                        sqlTableName26 = "vuVerifyValidAntibioticNames1";
                                                        rs_Impute2 = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName26, rs_Impute2);

                                                        //LDW if (!rs_Impute2.EOF)
                                                        foreach (DataRow myRow9 in rs_Impute2.Tables[sqlTableName26].Rows)
                                                        {
                                                            //only fill in the time if the date is also filled in for these names and the date is the same as the arrival date

                                                            //where the valid antibiotic dates are = arrival date
                                                            modGlobal.gv_sql = " SELECT DISTINCT vu.VRMID, related.DDID, fieldvalue";
                                                            modGlobal.gv_sql = modGlobal.gv_sql + " FROM vuVerifyValidAntibioticNames vu, tbl_Setup_DDIDRelatedFieldGroup related, tbl_temp_tempDetailData dat, tbl_Setup_DDIDFieldGroup grp";
                                                            modGlobal.gv_sql = modGlobal.gv_sql + " Where related.RelatedFieldGroupID = vu.RelatedFieldGroupID";
                                                            modGlobal.gv_sql = modGlobal.gv_sql + " AND dat.DDID = related.DDID AND FieldGroupID = 4";
                                                            modGlobal.gv_sql = modGlobal.gv_sql + " AND vu.VRMID = dat.VRMID AND grp.DDID = dat.DDID";
                                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + " AND vu.VRMID = " + rs_Impute2.rdoColumns["VRMID"].Value;
                                                            modGlobal.gv_sql = string.Format("{0} AND vu.VRMID = {1}", modGlobal.gv_sql, myRow9.Field<string>("VRMID"));
                                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + " AND len(FieldValue) > 0 AND FieldValue = (SELECT FieldValue FROM tbl_temp_tempDetailData tmp WHERE DDID = 244 AND VRMID = " + rs_Impute2.rdoColumns["VRMID"].Value + ") ";
                                                            modGlobal.gv_sql = string.Format("{0} AND len(FieldValue) > 0 AND FieldValue = (SELECT FieldValue FROM tbl_temp_tempDetailData " +
                                                                "tmp WHERE DDID = 244 AND VRMID = {1}) ", modGlobal.gv_sql, myRow9.Field<string>("VRMID"));

                                                            //LDW rs_Impute3 = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                            sqlTableName27 = "vuVerifyValidAntibioticNames2";
                                                            rs_Impute3 = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, rs_Impute3);
                                                            //LDW while (!rs_Impute3.EOF)
                                                            foreach (DataRow myRow10 in rs_Impute3.Tables[sqlTableName27].Rows)
                                                            {
                                                                //set time where name and date are valid  '---- SR amended 6.27.06 *and all the times are NOT missing*
                                                                modGlobal.gv_sql = "UPDATE tbl_temp_tempDetailData Set FieldValue = (SELECT IsNull(FieldValue, '') ";
                                                                modGlobal.gv_sql = modGlobal.gv_sql + "   FROM tbl_temp_tempDetailData ARRIVAL where ARRIVAL.DDID = 289 AND " +
                                                                    "ARRIVAL.VRMID = tbl_temp_tempDetailData.VRMID) ";
                                                                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " WHERE VRMID = " + rs_Impute2.rdoColumns["VRMID"].Value + " AND EXISTS ";
                                                                modGlobal.gv_sql = string.Format("{0} WHERE VRMID = {1} AND EXISTS ", modGlobal.gv_sql, myRow10.Field<string>("VRMID"));
                                                                modGlobal.gv_sql = modGlobal.gv_sql + " (SELECT VRMID, dat.DDID, FieldValue from tbl_temp_TempDetailData dat, " +
                                                                    "tbl_Setup_DDIDRelatedFieldGroup rel, tbl_Setup_DDIDFieldGroup grp ";
                                                                modGlobal.gv_sql = modGlobal.gv_sql + " Where rel.DDID = dat.DDID And grp.DDID = dat.DDID";
                                                                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " AND RelatedFieldGroupID in (SELECT RelatedFieldGroupID FROM tbl_Setup_DDIDRelatedFieldGroup WHERE DDID = " + rs_Impute3.rdoColumns["DDID"].Value + ") ";
                                                                modGlobal.gv_sql = string.Format("{0} AND RelatedFieldGroupID in (SELECT RelatedFieldGroupID FROM " +
                                                                    "tbl_Setup_DDIDRelatedFieldGroup WHERE DDID = {1}) ", modGlobal.gv_sql, myRow10.Field<string>("DDID"));
                                                                modGlobal.gv_sql = modGlobal.gv_sql + " AND VRMID = tbl_temp_tempDetailData.VRMID ";
                                                                modGlobal.gv_sql = modGlobal.gv_sql + " and grp.FieldGroupID = 3";
                                                                modGlobal.gv_sql = modGlobal.gv_sql + " and fieldvalue = '' AND dat.DDID = tbl_temp_tempDetailData.DDID)";

                                                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                                                //LDW rs_Impute3.MoveNext();
                                                            }

                                                            //LDW rs_Impute3.Close();
                                                            rs_Impute3.Dispose();
                                                            rs_Impute3 = null;
                                                        }
                                                        //LDW rs_Impute2.Close();
                                                        rs_Impute2.Dispose();
                                                        rs_Impute2 = null;

                                                        //LDW rs_Impute.MoveNext();
                                                    }
                                                    //LDW rs_Impute.Close();
                                                    rs_Impute.Dispose();
                                                    rs_Impute = null;
                                                }
                                            }

                                            lb_MeasureHasGroup = true;

                                            //this is where the group logic is processed
                                            //modGlobal.gv_sql = "{ ? = call ProcessSavedGroupSQLCondition(?,?) }";
                                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                                            ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                                            ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                                            ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
                                            ps.rdoParameters[1].Value = rs_MeasureCriteria.rdoColumns["measureCriteriaID"].Value;
                                            ps.rdoParameters[2].Value = VerifyID;
                                            ps.Execute();
                                            ps.Close();*/

                                            ps.Connection = modGlobal.gv_cn;
                                            ps.CommandType = CommandType.StoredProcedure;
                                            ps.CommandText = "ProcessSavedGroupSQLCondition";
                                            new SqlParameter("@MeasureCriteriaID", myRow7.Field<int>("measureCriteriaID")).Direction = ParameterDirection.Input;
                                            new SqlParameter("@MeasureCriteriaID", myRow7.Field<int>("measureCriteriaID")).DbType = DbType.Int32;
                                            ps.Parameters.Add(new SqlParameter("@MeasureCriteriaID", myRow7.Field<int>("measureCriteriaID")));
                                            new SqlParameter("@VerifyID", VerifyID).Direction = ParameterDirection.Input;
                                            new SqlParameter("@VerifyID", VerifyID).DbType = DbType.Int32;
                                            ps.Parameters.Add(new SqlParameter("@VerifyID", VerifyID));
                                            SqlParameter retParam10 = ps.Parameters.Add("return_value", SqlDbType.Int);
                                            retParam10.Direction = ParameterDirection.ReturnValue;
                                            try
                                            {
                                                ps.Connection.Open();
                                                ps.ExecuteNonQuery();
                                            }
                                            catch (Exception ex)
                                            {
                                                RadMessageBox.Show("Error while opening connection: " + ex.Message);
                                            }
                                            finally
                                            {
                                                ps.Dispose();
                                            }
                                            Application.DoEvents();

                                            //LDW modGlobal.gv_sql = "INSERT INTO tbl_temp_tTempPatRecCriteria (VRMID, " + " MeasureCriteria, MeasureSet, Step) SELECT VRMID, " + li_CritCount + ", " + rs_MeasureSet.rdoColumns["MeasureCriteriaSet"].Value + ", " + StepConditions[li_StepCnt].PStep + " FROM tbl_temp_tTempPatRecs WHERE IsSaved = 1 GROUP BY VRMID";
                                            modGlobal.gv_sql = string.Format("INSERT INTO tbl_temp_tTempPatRecCriteria (VRMID,  MeasureCriteria, MeasureSet, Step) SELECT VRMID, {0}, {1}, {2} FROM tbl_temp_tTempPatRecs WHERE IsSaved = 1 GROUP BY VRMID", li_CritCount, myRow5.Field<string>("MeasureCriteriaSet"), StepConditions[li_StepCnt].PStep);

                                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                        }
                                        else
                                        {
                                            //LDW if (Information.IsDBNull(rs_MeasureCriteria.rdoColumns["DDID1"].Value))
                                            if (Information.IsDBNull(myRow7.Field<int>("DDID1")))
                                            {
                                                ExceptionMethod = true;

                                                ls_Sql = Strings.Replace(StepCondition, "AND   ", "OR   ");
                                                //Debug.Print StepCondition

                                                //LDW ls_FieldValue = Strings.Split(rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value, ",");
                                                ls_FieldValue = Strings.Split(myRow7.Field<string>("FIELDVALUE"), ",");
                                                ls_sqlStmts = Strings.Split(ls_Sql, "OR   ");

                                                //stores the date values to be grouped and selected
                                                ls_LookupLocs = new string[Information.UBound(ls_FieldValue) + 1];
                                                for (li_fieldCnt = 0; li_fieldCnt <= Information.UBound(ls_FieldValue); li_fieldCnt++)
                                                {
                                                    //get the locations of the fields in the measuredata table and store
                                                    ls_LookupLocs[li_fieldCnt] = string.Format("[F{0}]", LookupLocationOnDDID(ls_FieldValue[li_fieldCnt]));
                                                }

                                                modGlobal.gv_sql = "DELETE FROM tmp_ValidMeasureDates ";
                                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                                modGlobal.gv_sql = "INSERT INTO tmp_ValidMeasureDates (F2, ValidDate) ";
                                                for (li_fieldCnt = 0; li_fieldCnt <= Information.UBound(ls_sqlStmts); li_fieldCnt++)
                                                {
                                                    ls_SelField = Strings.Trim(Strings.Mid(ls_sqlStmts[li_fieldCnt], Strings.InStr(1, ls_sqlStmts[li_fieldCnt], "[F"), 6));

                                                    //check if selfield is in the list of ls_lookuplocs?errorchecking

                                                    modGlobal.gv_sql = string.Format("{0} SELECT [F2],{1} as ValidDate FROM tbl_MeasureData WHERE {2}",
                                                        modGlobal.gv_sql, ls_SelField, ls_sqlStmts[li_fieldCnt]);
                                                    if (li_fieldCnt < Information.UBound(ls_sqlStmts))
                                                    {
                                                        modGlobal.gv_sql = modGlobal.gv_sql + "UNION";
                                                    }
                                                }

                                                //Debug.Print gv_sql

                                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                                //remove maximum dates where there are more than one listed for the case id
                                                modGlobal.gv_sql = "delete From tmp_validmeasuredates " + " where F2 in (select F2 from tmp_ValidMeasureDates group by F2 having count(validdate) > 1)" + " and Validdate in (select max(validdate) from tmp_validmeasuredates t where tmp_validmeasuredates.F2 = t.F2)";

                                                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                                //OLD WAY
                                                //remove maximum dates where there are more than one listed for the caseid
                                                //gv_cn.Execute "delete from tmp_validmeasuredates where validdate = " & _
                                                //'    " (select max(validdate), f2 from tmp_validmeasuredates " & _
                                                //'    " where F2 in (select F2 from tmp_ValidMeasureDates group by F2 having count(validdate) > 1) GROUP BY F2)"

                                                ls_join = "";
                                                QCondition = "";
                                                StepCondition = "";


                                                //get the time value in the next criteria field and add to the early date with
                                                // convert(datetime, earlydate + 'time', 121)
                                                //LDW rs_MeasureCriteria.MoveNext();
                                                for (int index26 = 0; index26 < rs_MeasureCriteria.Tables[sqlTableName24].Rows.Count; index26++)
                                                {
                                                    var myRow8a = rs_MeasureCriteria.Tables[sqlTableName24].Rows[index26];
                                                    int rowIndex26 = rs_MeasureCriteria.Tables[sqlTableName24].Rows.IndexOf(myRow8a);


                                                    //LDW if (!rs_MeasureCriteria.EOF)
                                                    if (rowIndex26 != rs_MeasureCriteria.Tables[sqlTableName24].Rows.Count - 1)
                                                    {
                                                        //LDW while (!rs_MeasureCriteria.EOF)
                                                        foreach (DataRow myRow8 in rs_MeasureCriteria.Tables[sqlTableName24].Rows)
                                                        {
                                                            if (string.IsNullOrEmpty(ls_join))
                                                                //LDW ls_join = rs_MeasureCriteria.rdoColumns["JoinOperator"].Value;
                                                                ls_join = myRow8.Field<string>("JoinOperator");

                                                            //find the related date field
                                                            modGlobal.gv_sql = "select Datefieldddid from tbl_setup_datadef ";
                                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + rs_MeasureCriteria.rdoColumns["DDID1"].Value;
                                                            modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow8.Field<string>("DDID1"));

                                                            //LDW rs_IHARS = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                            sqlTableName28 = "tbl_setup_datadef1";
                                                            rs_IHARS = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, rs_IHARS);
                                                            //location on date field related to time field
                                                            //LDW DateFieldDDID1 = LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_IHARS.rdoColumns["DateFieldDDID"].Value)));
                                                            string refDateFieldDDID = Strings.Trim(Convert.ToString(rs_IHARS.Tables[sqlTableName28].Rows[0]["DateFieldDDID"]));
                                                            DateFieldDDID1 = LookupLocationOnDDID(refDateFieldDDID);
                                                            //LDW rs_IHARS.Close();
                                                            rs_IHARS.Dispose();

                                                            //location of time field
                                                            //LDW li_FieldLoc = LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DDID1"].Value)));
                                                            string refDDID1 = Strings.Trim(Convert.ToString(myRow8.Field<int>("DDID1")));
                                                            li_FieldLoc = LookupLocationOnDDID(refDDID1);
                                                            ls_FirstDate = string.Format("convert(datetime, [F{0}] + ' ' + [F{1}], 121)", DateFieldDDID1, li_FieldLoc);

                                                            //LDW li_TimeLoc = LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["ddid2"].Value)));
                                                            string refddid2 = Strings.Trim(Convert.ToString(myRow8.Field<int>("ddid2")));
                                                            li_TimeLoc = LookupLocationOnDDID(refddid2);
                                                            ls_SecondDate = string.Format("convert(datetime, ValidDate + ' ' + [F{0}],121)", li_TimeLoc);

                                                            if (string.IsNullOrEmpty(QCondition))
                                                            {
                                                                QCondition = "[F2] in ";
                                                                QCondition = QCondition + " (Select d.F2 FROM tmp_MeasureData d, tmp_ValidMeasureDates vd ";
                                                                QCondition = QCondition + " WHERE (vd.F2 = d.F2) ";
                                                                QCondition = QCondition + " AND ";
                                                                QCondition = QCondition + " (";
                                                                //LDW QCondition = QCondition + "     (DateDiff(" + rs_MeasureCriteria.rdoColumns["DateUnit"].Value + "," + ls_FirstDate + ", " + ls_SecondDate + ") ";
                                                                QCondition = string.Format("{0}     (DateDiff({1},{2}, {3}) ", QCondition, myRow8.Field<string>("DateUnit"), ls_FirstDate, ls_SecondDate);
                                                                //LDW QCondition = QCondition + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value;
                                                                QCondition = QCondition + myRow8.Field<string>("ValueOperator");
                                                                //LDW QCondition = QCondition + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value + ")";
                                                                QCondition = string.Format("{0} {1})", QCondition, myRow8.Field<string>("FIELDVALUE"));
                                                            }
                                                            else
                                                            {
                                                                //LDW QCondition = QCondition + " " + ls_join + " (DateDiff(" + rs_MeasureCriteria.rdoColumns["DateUnit"].Value + "," + ls_FirstDate + ", " + ls_SecondDate;
                                                                QCondition = string.Format("{0} {1} (DateDiff({2},{3}, {4}", QCondition, ls_join, myRow8.Field<string>("DateUnit"), ls_FirstDate, ls_SecondDate);
                                                                //LDW QCondition = QCondition + ") " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value + ")";
                                                                QCondition = string.Format("{0}) {1} {2})", QCondition, myRow8.Field<string>("ValueOperator"), myRow8.Field<string>("FIELDVALUE"));
                                                            }
                                                            //LDW rs_MeasureCriteria.MoveNext();
                                                        }

                                                        QCondition = QCondition + "))";
                                                        //Debug.Print QCondition
                                                    }
                                                    else
                                                    {
                                                        RadMessageBox.Show("Earliest criteria is not followed by another field with time");
                                                        return functionReturnValue;
                                                    }
                                                }
                                                //regular method
                                            }
                                            //LDW else if (!Information.IsDBNull(rs_MeasureCriteria.rdoColumns["DDID1"].Value))
                                            else if (!Information.IsDBNull(myRow7.Field<string>("DDID1")))
                                            {
                                                //LDW if (Information.IsDBNull(rs_MeasureCriteria.rdoColumns["multselany"].Value))
                                                if (Information.IsDBNull(myRow7.Field<bool>("multselany")))
                                                {
                                                    ls_multSelAny = "";
                                                }
                                                else
                                                {
                                                    //LDW ls_multSelAny = (rs_MeasureCriteria.rdoColumns["multselany"].Value ? "1" : "0");
                                                    ls_multSelAny = (myRow7.Field<bool>("multselany") ? "1" : "0");
                                                }

                                                //LDW li_FieldLoc = LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DDID1"].Value)));
                                                string refDDID1_2 = Strings.Trim(Convert.ToString(myRow7.Field<int>("DDID1")));
                                                li_FieldLoc = LookupLocationOnDDID(refDDID1_2);

                                                //LDW if (Strings.Trim(Strings.UCase(rs_MeasureCriteria.rdoColumns["JoinOperator"].Value)) == "AND")
                                                if (Strings.Trim(Strings.UCase(myRow7.Field<string>("JoinOperator"))) == "AND")
                                                {
                                                    CaseElseVal = 0;
                                                }

                                                else
                                                {
                                                    //LDW same value used
                                                    //LDW CaseElseVal = 0;
                                                }

                                                //get the field type and adjust the query accordingly
                                                //LDW modGlobal.gv_sql = "Select FieldType, ParentDDID from tbl_Setup_DataDef where DDID = " + rs_MeasureCriteria.rdoColumns["DDID1"].Value;
                                                modGlobal.gv_sql = "Select FieldType, ParentDDID from tbl_Setup_DataDef where DDID = " + myRow7.Field<int>("DDID1");
                                                //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                sqlTableName28 = "rs_Temp_Table";
                                                rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, rs_Temp);
                                                //LDW FieldType = rs_Temp.rdoColumns["FieldType"].Value;
                                                FieldType = rs_Temp.Tables[sqlTableName28].Rows[0]["FieldType"].ToString();
                                                //LDW ParentDDID = (Information.IsDBNull(rs_Temp.rdoColumns["ParentDDID"].Value) ? 0 : rs_Temp.rdoColumns["ParentDDID"].Value);
                                                ParentDDID = ((Information.IsDBNull(rs_Temp.Tables[sqlTableName28].Rows[0]["ParentDDID"])) ? 0 :
                                                    Convert.ToInt32(rs_Temp.Tables[sqlTableName28].Rows[0]["ParentDDID"]));
                                                //LDW rs_Temp.Close();
                                                rs_Temp.Dispose();

                                                ChildDDID = new int[1];

                                                if (ParentDDID != 0)
                                                {
                                                    //LDW ChildDDID = GetMultipleSelectionDDID( rs_MeasureCriteria.rdoColumns["DDID1"].Value);
                                                    int refDDID1_3 = myRow7.Field<int>("DDID1");
                                                    ChildDDID = GetMultipleSelectionDDID(refDDID1_3);
                                                }

                                                //the field value has been compared to a fixed value, or another field
                                                //LDW if (Information.IsDBNull(rs_MeasureCriteria.rdoColumns["ddid2"].Value) | rs_MeasureCriteria.rdoColumns["ddid2"].Value <= 0)
                                                if (Information.IsDBNull(myRow7.Field<int>("ddid2")) | myRow7.Field<int>("ddid2") <= 0)
                                                {

                                                    //the field value has been compared to a blank
                                                    //LDW if (rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value == "Null")
                                                    if (myRow7.Field<string>("FIELDVALUE") == "Null")
                                                    {
                                                        QCondition = " case when (";

                                                        for (li_Children = 0; li_Children <= (Information.UBound(ChildDDID) | 0); li_Children++)
                                                        {
                                                            if (ParentDDID != 0)
                                                            {
                                                                // LDW li_FieldLoc = LookupLocationOnDDID( Convert.ToString(ChildDDID[li_Children]));
                                                                string refChildDDID = Convert.ToString(ChildDDID[li_Children]);
                                                                li_FieldLoc = LookupLocationOnDDID(refChildDDID);
                                                            }

                                                            if (QCondition != " case when (")
                                                                QCondition = QCondition + (string.IsNullOrEmpty(ls_multSelAny) ? "" : (ls_multSelAny == "0" ? " AND " : " OR "));

                                                            //LDW QCondition = QCondition + " ([F" + li_FieldLoc + "] " + (rs_MeasureCriteria.rdoColumns["ValueOperator"].Value == "=" ? " is Null" : " is not Null") + " )";
                                                            QCondition = string.Format("{0} ([F{1}] {2} )", QCondition, li_FieldLoc, myRow7.Field<string>("ValueOperator") == "=" ?
                                                                " is Null" : " is not Null");
                                                        }

                                                        QCondition = QCondition + ") then 1 ";

                                                        //the field value has been compared to a fixed value, or values of a lookup table
                                                    }
                                                    //LDW else if (Information.IsDBNull(rs_MeasureCriteria.rdoColumns["DestDDID"].Value) | rs_MeasureCriteria.rdoColumns["DestDDID"].Value <= 0)
                                                    else if (Information.IsDBNull(myRow7.Field<int>("DestDDID")) | myRow7.Field<int>("DestDDID") <= 0)
                                                    {
                                                        //LDW if (Information.IsDBNull(rs_MeasureCriteria.rdoColumns["LookupTableID"].Value) | rs_MeasureCriteria.rdoColumns["LookupTableID"].Value == 0)
                                                        if (Information.IsDBNull(myRow7.Field<int>("LookupTableID")) | myRow7.Field<int>("LookupTableID") == 0)
                                                        {
                                                            // the field value has been compared to a fixed value
                                                            QCondition = " case when (";
                                                            switch (Strings.Mid(FieldType, 1, 4))
                                                            {
                                                                case "Date":
                                                                    //LDW if (!Information.IsDBNull(rs_MeasureCriteria.rdoColumns["DateUnit"].Value))
                                                                    if (!Information.IsDBNull(myRow7.Field<string>("DateUnit")))
                                                                    {
                                                                        //range of months - Method 5
                                                                        //LDW if (rs_MeasureCriteria.rdoColumns["ValueOperator"].Value == "In" & rs_MeasureCriteria.rdoColumns["DateUnit"].Value == "m")
                                                                        if (myRow7.Field<string>("ValueOperator") == "In" & myRow7.Field<string>("DateUnit") == "m")
                                                                        {
                                                                            //LDW ls_months = rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value;
                                                                            ls_months = myRow7.Field<string>("FIELDVALUE");
                                                                            //trim () off
                                                                            ls_months = Strings.Mid(ls_months, 2, Strings.Len(ls_months) - 2);
                                                                            Months = Strings.Split(ls_months, ",");
                                                                            QCondition = string.Format("{0} [F{1}] is not null AND (", QCondition, li_FieldLoc);
                                                                            for (li_cnt = 0; li_cnt <= Information.UBound(Months); li_cnt++)
                                                                            {
                                                                                //LDW QCondition = QCondition + " datepart(" + rs_MeasureCriteria.rdoColumns["DateUnit"].Value + ",[F" + li_FieldLoc + "]) = " + Months[li_cnt];
                                                                                QCondition = string.Format("{0} datepart({1},[F{2}]) = {3}", QCondition, myRow7.Field<string>("DateUnit"),
                                                                                    li_FieldLoc, Months[li_cnt]);
                                                                                if (li_cnt < Information.UBound(Months))
                                                                                    QCondition = QCondition + " OR ";
                                                                            }
                                                                            QCondition = QCondition + ")";
                                                                        }
                                                                        else
                                                                        {
                                                                            QCondition = string.Format("{0} [F{1}] is not null AND ", QCondition, li_FieldLoc);
                                                                            //LDW QCondition = QCondition + " datepart(" + rs_MeasureCriteria.rdoColumns["DateUnit"].Value + ",[F" + li_FieldLoc + "]) " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value;
                                                                            QCondition = string.Format("{0} datepart({1},[F{2}]) {3} {4}", QCondition, myRow7.Field<string>("DateUnit"),
                                                                                li_FieldLoc, myRow7.Field<string>("ValueOperator"), myRow7.Field<string>("FIELDVALUE"));
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //LDW QCondition = QCondition + " [F" + li_FieldLoc + "] " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " '" + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value + "'";
                                                                        QCondition = string.Format("{0} [F{1}] {2} '{3}'", QCondition, li_FieldLoc, myRow7.Field<string>("ValueOperator"),
                                                                            myRow7.Field<string>("FIELDVALUE"));
                                                                    }
                                                                    break;
                                                                case "Numb":
                                                                    //for a numeric values

                                                                    for (li_Children = 0; li_Children <= (Information.UBound(ChildDDID) | 0); li_Children++)
                                                                    {
                                                                        if (ParentDDID != 0)
                                                                        {
                                                                            //LDW li_FieldLoc = LookupLocationOnDDID( Convert.ToString(ChildDDID[li_Children]));
                                                                            string refChildDDID = Convert.ToString(ChildDDID[li_Children]);
                                                                            li_FieldLoc = LookupLocationOnDDID(refChildDDID);
                                                                        }

                                                                        if (QCondition != " case when (")
                                                                            QCondition = QCondition + (string.IsNullOrEmpty(ls_multSelAny) ? "" : (ls_multSelAny == "0" ? " AND " : " OR "));

                                                                        QCondition = QCondition + "(";
                                                                        QCondition = string.Format("{0} [F{1}] is not null AND ", QCondition, li_FieldLoc);
                                                                        //LDW QCondition = QCondition + " convert(float, [F" + li_FieldLoc + "]) " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value;
                                                                        QCondition = string.Format("{0} convert(float, [F{1}]) {2} {3}", QCondition, li_FieldLoc,
                                                                            myRow7.Field<string>("ValueOperator"), myRow7.Field<string>("FIELDVALUE"));
                                                                        QCondition = QCondition + ")";
                                                                    }
                                                                    break;

                                                                default:
                                                                    //for a text, we need to use sigle quote around the value
                                                                    for (li_Children = 0; li_Children <= (Information.UBound(ChildDDID) | 0); li_Children++)
                                                                    {
                                                                        if (ParentDDID != 0)
                                                                        {
                                                                            //LDW li_FieldLoc = LookupLocationOnDDID( Convert.ToString(ChildDDID[li_Children]));
                                                                            string refChildDDID2 = Convert.ToString(ChildDDID[li_Children]);
                                                                            li_FieldLoc = LookupLocationOnDDID(refChildDDID2);
                                                                        }

                                                                        if (QCondition != " case when (")
                                                                            QCondition = QCondition + (string.IsNullOrEmpty(ls_multSelAny) ? "" : (ls_multSelAny == "0" ? " AND " : " OR "));

                                                                        QCondition = QCondition + "(";
                                                                        //LDW QCondition = QCondition + " [F" + li_FieldLoc + "] " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " '" + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value + "'";
                                                                        QCondition = string.Format("{0} [F{1}] {2} '{3}'", QCondition, li_FieldLoc, myRow7.Field<string>("ValueOperator"),
                                                                            myRow7.Field<string>("FIELDVALUE"));
                                                                        QCondition = QCondition + ")";
                                                                    }
                                                                    break;
                                                            }

                                                            //LDW if (rs_MeasureCriteria.rdoColumns["ValueOperator"].Value == "<>")
                                                            if (myRow7.Field<string>("ValueOperator") == "<>")
                                                            {
                                                                QCondition = string.Format("{0} or [F{1}] is null ", QCondition, li_FieldLoc);
                                                            }

                                                            QCondition = QCondition + ")";
                                                            QCondition = QCondition + " then 1 ";
                                                        }
                                                        else
                                                        {
                                                            //the field has been compared to a lookup table
                                                            CheckForNull = "";

                                                            if (ParentDDID > 0)
                                                            {
                                                                QCondition = " case when ";

                                                                for (li_Children = 0; li_Children <= (Information.UBound(ChildDDID) | 0); li_Children++)
                                                                {
                                                                    if (ParentDDID != 0)
                                                                    {
                                                                        //LDW li_FieldLoc = LookupLocationOnDDID( Convert.ToString(ChildDDID[li_Children]));
                                                                        string refChildDDID3 = Convert.ToString(ChildDDID[li_Children]);
                                                                        li_FieldLoc = LookupLocationOnDDID(refChildDDID3);
                                                                    }

                                                                    // If rs_MeasureCriteria!ValueOperator = "In" Then
                                                                    //     CheckForNull = " (Len([F" & li_FieldLoc & "]) > 0 And [F" & li_FieldLoc & "] Is Not Null) AND "
                                                                    // ElseIf rs_MeasureCriteria!ValueOperator = "Not In" Then
                                                                    //     CheckForNull = " (Len([F" & li_FieldLoc & "]) = 0 OR [F" & li_FieldLoc & "] Is Null) OR "
                                                                    // End If
                                                                    CheckForNull = "";

                                                                    if (QCondition != " case when ")
                                                                        QCondition = QCondition + (string.IsNullOrEmpty(ls_multSelAny) ? "" : (ls_multSelAny == "0" ? " AND " : " OR "));
                                                                    if (ls_multSelAny == "0")
                                                                    {
                                                                        CheckForNull = string.Format(" [F{0}] IS NOT NULL AND ", li_FieldLoc);
                                                                    }
                                                                    QCondition = QCondition + " (";
                                                                    QCondition = QCondition + CheckForNull;
                                                                    // LDW QCondition = QCondition + " [F" + li_FieldLoc + "] " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value;
                                                                    QCondition = string.Format("{0} [F{1}] {2}", QCondition, li_FieldLoc, myRow7.Field<string>("ValueOperator"));
                                                                    QCondition = QCondition + " (select lkvalue";
                                                                    QCondition = QCondition + " from vuLookupList ";
                                                                    //LDW QCondition = QCondition + " WHERE basetableid = " + rs_MeasureCriteria.rdoColumns["LookupTableID"].Value + ")";
                                                                    QCondition = string.Format("{0} WHERE basetableid = {1})", QCondition, myRow7.Field<string>("LookupTableID"));
                                                                    QCondition = QCondition + ")";
                                                                }
                                                                QCondition = QCondition + " then 1 ";

                                                            }
                                                            else
                                                            {
                                                                CheckForNull = "";
                                                                //LDW if (rs_MeasureCriteria.rdoColumns["ValueOperator"].Value == "In")
                                                                if (myRow7.Field<string>("ValueOperator") == "In")
                                                                {
                                                                    CheckForNull = string.Format("[F{0}] Is not Null and ", li_FieldLoc);
                                                                }
                                                                //LDW else if (rs_MeasureCriteria.rdoColumns["ValueOperator"].Value == "Not In")
                                                                else if (myRow7.Field<string>("ValueOperator") == "Not In")
                                                                {
                                                                    CheckForNull = string.Format("[F{0}] Is Null Or ", li_FieldLoc);
                                                                }
                                                                //LDW QCondition = " case when " + CheckForNull + " ([F" + li_FieldLoc + "] " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value;
                                                                QCondition = string.Format(" case when {0} ([F{1}] {2}", CheckForNull, li_FieldLoc, myRow7.Field<string>("ValueOperator"));
                                                                QCondition = QCondition + " (select lkvalue from vuLookupList ";
                                                                //LDW QCondition = QCondition + " where basetableid = " + rs_MeasureCriteria.rdoColumns["LookupTableID"].Value + "))";
                                                                QCondition = string.Format("{0} where basetableid = {1}))", QCondition, myRow7.Field<int>("LookupTableID"));
                                                                QCondition = QCondition + " then 1 ";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //the 2 fields have been compared to each other
                                                        switch (Strings.Mid(FieldType, 1, 4))
                                                        {
                                                            case "Date":
                                                                QCondition = " case when  ";
                                                                //LDW QCondition = QCondition + " isdate([F" + li_FieldLoc + "]) + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DestDDID"].Value))) + "]) = 2 then ";
                                                                string refDestDDID = Strings.Trim(Convert.ToString(myRow7.Field<int>("DestDDID")));
                                                                QCondition = string.Format("{0} isdate([F{1}]) + isdate([F{2}]) = 2 then ", QCondition, li_FieldLoc, LookupLocationOnDDID(refDestDDID));
                                                                QCondition = string.Format("{0} case when [F{1}] ", QCondition, li_FieldLoc);
                                                                //LDW QCondition = QCondition + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value;
                                                                QCondition = QCondition + myRow7.Field<int>("ValueOperator");
                                                                //LDW QCondition = QCondition + " [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DestDDID"].Value))) + "] ";
                                                                string refDestDDID2 = Strings.Trim(Convert.ToString(myRow7.Field<int>("DestDDID")));
                                                                QCondition = string.Format("{0} [F{1}] ", QCondition, LookupLocationOnDDID(refDestDDID2));
                                                                QCondition = QCondition + " then 1 else 0 end ";
                                                                break;
                                                            //QCondition = QCondition & " else " & CaseElseVal & " end  = 1 "  'if any field is not a valid date and time, this condition should be ineffective, so we set it to true

                                                            case "Numb":
                                                                QCondition = string.Format(" case when [F{0}] is not null AND ", li_FieldLoc);
                                                                QCondition = string.Format("{0} [F{1}] ", QCondition, li_FieldLoc);
                                                                //LDW QCondition = QCondition + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value;
                                                                QCondition = QCondition + myRow7.Field<int>("ValueOperator");
                                                                //LDW QCondition = QCondition + " [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DestDDID"].Value))) + "] ";
                                                                string refDestDDID3 = Strings.Trim(Convert.ToString(myRow7.Field<int>("DestDDID")));
                                                                QCondition = string.Format("{0} [F{1}] ", QCondition, LookupLocationOnDDID(refDestDDID3));
                                                                QCondition = QCondition + " then 1 ";
                                                                break;

                                                            case "Time":
                                                                //find the related date field
                                                                modGlobal.gv_sql = "select Datefieldddid from tbl_setup_datadef ";
                                                                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, li_FieldLoc);
                                                                //LDW rs_IHARS = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                                sqlTableName29 = "tbl_setup_datadef3";
                                                                rs_IHARS = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, rs_IHARS);
                                                                //LDW DateFieldDDID1 = rs_IHARS.rdoColumns["DateFieldDDID"].Value;
                                                                DateFieldDDID1 = Convert.ToInt32(rs_IHARS.Tables[sqlTableName29].Rows[0]["DateFieldDDID"]);
                                                                //LDW rs_IHARS.Close();
                                                                rs_IHARS.Dispose();

                                                                modGlobal.gv_sql = "select Datefieldddid from tbl_setup_datadef ";
                                                                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + rs_MeasureCriteria.rdoColumns["DestDDID"].Value;
                                                                modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow7.Field<int>("DestDDID"));
                                                                //LDW rs_IHARS = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                                rs_IHARS = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, rs_IHARS);
                                                                DateFieldDDID2 = Convert.ToInt32(rs_IHARS.Tables[sqlTableName29].Rows[0]["DateFieldDDID"]);
                                                                //LDW rs_IHARS.Close();
                                                                rs_IHARS.Dispose();

                                                                QCondition = " case when ";
                                                                QCondition = string.Format("{0} isdate([F{1}])  ", QCondition, li_FieldLoc);
                                                                //LDW QCondition = QCondition + "             + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DestDDID"].Value))) + "]) ";
                                                                string refDestDDID4 = Strings.Trim(myRow7.Field<int>("DestDDID").ToString());
                                                                QCondition = string.Format("{0}             + isdate([F{1}]) ", QCondition, LookupLocationOnDDID(refDestDDID4));
                                                                //LDW QCondition = QCondition + "             + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID1))) + "]) ";
                                                                string refDateFieldDDID1 = Strings.Trim(DateFieldDDID1.ToString());
                                                                QCondition = string.Format("{0}             + isdate([F{1}]) ", QCondition, LookupLocationOnDDID(refDateFieldDDID1));
                                                                //LDW QCondition = QCondition + "             + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID2))) + "]) = 4 then ";
                                                                string refDateFieldDDID2 = Strings.Trim(DateFieldDDID2.ToString());
                                                                QCondition = string.Format("{0}             + isdate([F{1}]) = 4 then ", QCondition, LookupLocationOnDDID(refDateFieldDDID2));
                                                                //LDW QCondition = QCondition + "     case when convert(datetime, [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID1))) + "] +  ' ' + [F" + li_FieldLoc + "],121) ";
                                                                QCondition = string.Format("{0}     case when convert(datetime, [F{1}] +  ' ' + [F{2}],121) ",
                                                                    QCondition, LookupLocationOnDDID(refDateFieldDDID1), li_FieldLoc);
                                                                //LDW QCondition = QCondition + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value;
                                                                QCondition = QCondition + myRow7.Field<int>("ValueOperator");
                                                                //LDW QCondition = QCondition + "     convert(datetime, [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID2))) + "] +  ' ' + [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DestDDID"].Value))) + "],121) ";
                                                                string refDestDDID5 = Strings.Trim(myRow7.Field<int>("DestDDID").ToString());
                                                                QCondition = string.Format("{0}     convert(datetime, [F{1}] +  ' ' + [F{2}],121) ", QCondition,
                                                                    LookupLocationOnDDID(refDateFieldDDID2), LookupLocationOnDDID(refDestDDID5));
                                                                QCondition = QCondition + "      then 1 else 0 end ";
                                                                break;
                                                            //QCondition = QCondition & " else " & CaseElseVal & " end = 1 "

                                                            default:
                                                                QCondition = string.Format(" case when [F{0}] ", li_FieldLoc);
                                                                //LDW QCondition = QCondition + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value;
                                                                QCondition = QCondition + myRow7.Field<int>("ValueOperator");
                                                                //LDW QCondition = QCondition + " [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DestDDID"].Value))) + "] ";
                                                                string refDestDDID6 = Strings.Trim(myRow7.Field<int>("DestDDID").ToString());
                                                                QCondition = string.Format("{0} [F{1}] ", QCondition, LookupLocationOnDDID(refDestDDID6));
                                                                QCondition = QCondition + " then 1 ";
                                                                break;
                                                        }
                                                    }
                                                    //an arithmetic operation has been applied to the 2 fields,
                                                }
                                                else
                                                {
                                                    //and the result is compared to a value

                                                    switch (Strings.Mid(FieldType, 1, 4))
                                                    {
                                                        case "Date":
                                                            QCondition = " case when  ";
                                                            //LDW QCondition = QCondition + " isdate([F" + li_FieldLoc + "]) + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["ddid2"].Value))) + "]) = 2 then ";
                                                            string refddid2 = Strings.Trim(myRow7.Field<int>("ddid2").ToString());
                                                            QCondition = string.Format("{0} isdate([F{1}]) + isdate([F{2}]) = 2 then ", QCondition, li_FieldLoc, LookupLocationOnDDID(refddid2));
                                                            //LDW QCondition = QCondition + " case when DateDiff(" + rs_MeasureCriteria.rdoColumns["DateUnit"].Value;
                                                            QCondition = string.Format("{0} case when DateDiff({1}", QCondition, myRow7.Field<string>("DateUnit"));
                                                            QCondition = string.Format("{0}, convert(datetime,[F{1}])  ", QCondition, li_FieldLoc);
                                                            //LDW QCondition = QCondition + ", convert(datetime,[F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["ddid2"].Value))) + "])) ";
                                                            QCondition = string.Format("{0}, convert(datetime,[F{1}])) ", QCondition, LookupLocationOnDDID(refddid2));
                                                            //LDW QCondition = QCondition + " " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value;
                                                            QCondition = string.Format("{0} {1} {2}", QCondition, myRow7.Field<string>("ValueOperator"), myRow7.Field<string>("FIELDVALUE"));
                                                            QCondition = QCondition + " then 1 else 0 end ";
                                                            break;
                                                        //QCondition = QCondition & " else " & CaseElseVal & " end  = 1 "  'if any field is not a valid date and time, this condition should be ineffective, so we set it to true

                                                        case "Time":
                                                            //find the related date field
                                                            modGlobal.gv_sql = "select Datefieldddid from tbl_setup_datadef ";
                                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + rs_MeasureCriteria.rdoColumns["DDID1"].Value;
                                                            modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow7.Field<string>("DDID1"));
                                                            //LDW rs_IHARS = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                            sqlTableName29 = "tbl_setup_datadef4";
                                                            rs_IHARS = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, rs_IHARS);
                                                            //LDW DateFieldDDID1 = rs_IHARS.rdoColumns["DateFieldDDID"].Value;
                                                            DateFieldDDID1 = Convert.ToInt32(rs_IHARS.Tables[sqlTableName29].Rows[0]["DateFieldDDID"]);
                                                            //LDW rs_IHARS.Close();
                                                            rs_IHARS.Dispose();
                                                            //LDW li_FieldLoc = LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["DDID1"].Value)));
                                                            string refDDID1 = Strings.Trim(Convert.ToString(myRow7.Field<int>("DDID1")));
                                                            li_FieldLoc = LookupLocationOnDDID(refDDID1);

                                                            modGlobal.gv_sql = "select Datefieldddid from tbl_setup_datadef ";
                                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + rs_MeasureCriteria.rdoColumns["ddid2"].Value;
                                                            modGlobal.gv_sql = string.Format("{0} where ddid = {1}", modGlobal.gv_sql, myRow7.Field<int>("ddid2"));
                                                            //LDW rs_IHARS = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                                            rs_IHARS = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, rs_IHARS);
                                                            //LDW DateFieldDDID2 = rs_IHARS.rdoColumns["DateFieldDDID"].Value;
                                                            DateFieldDDID2 = Convert.ToInt32(rs_IHARS.Tables[sqlTableName29].Rows[0]["DateFieldDDID"]);
                                                            //LDW rs_IHARS.Close();
                                                            rs_IHARS.Dispose();

                                                            QCondition = " case when  ";
                                                            QCondition = string.Format("{0} isdate([F{1}])  ", QCondition, li_FieldLoc);
                                                            //LDW QCondition = QCondition + "             + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["ddid2"].Value))) + "]) ";
                                                            string refDDID2 = Strings.Trim(myRow7.Field<int>("ddid2").ToString());
                                                            QCondition = string.Format("{0}             + isdate([F{1}]) ", QCondition, LookupLocationOnDDID(refDDID2));
                                                            //LDW QCondition = QCondition + "             + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID1))) + "]) ";
                                                            string refDateFieldDDID1 = Strings.Trim(DateFieldDDID1.ToString());
                                                            QCondition = string.Format("{0}             + isdate([F{1}]) ", QCondition, LookupLocationOnDDID(refDateFieldDDID1));
                                                            //LDW QCondition = QCondition + "             + isdate([F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID2))) + "]) = 4 then ";
                                                            string refDateFieldDDID2 = Strings.Trim(DateFieldDDID2.ToString());
                                                            QCondition = string.Format("{0}             + isdate([F{1}]) = 4 then ", QCondition, LookupLocationOnDDID(refDateFieldDDID2));
                                                            //LDW QCondition = QCondition + " case when DateDiff(" + rs_MeasureCriteria.rdoColumns["DateUnit"].Value + ",";
                                                            QCondition = string.Format("{0} case when DateDiff({1},", QCondition, myRow7.Field<int>("DateUnit"));
                                                            //LDW QCondition = QCondition + "         convert(datetime, [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID1))) + "] +  ' ' + [F" + li_FieldLoc + "],121), ";
                                                            QCondition = string.Format("{0}         convert(datetime, [F{1}] +  ' ' + [F{2}],121), ", QCondition, LookupLocationOnDDID(refDDID1), li_FieldLoc);
                                                            //LDW QCondition = QCondition + "         convert(datetime, [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(DateFieldDDID2))) + "] +  ' ' + [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["ddid2"].Value))) + "],121) ";
                                                            string refddid2_2 = Strings.Trim(myRow7.Field<int>("ddid2").ToString());
                                                            QCondition = string.Format("{0}         convert(datetime, [F{1}] +  ' ' + [F{2}],121) ",
                                                                QCondition, LookupLocationOnDDID(refDDID2), LookupLocationOnDDID(refddid2_2));
                                                            //LDW QCondition = QCondition + "                 ) " + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value;
                                                            QCondition = string.Format("{0}                 ) {1} {2}", QCondition, myRow7.Field<string>("ValueOperator"), myRow7.Field<string>("FIELDVALUE"));
                                                            QCondition = QCondition + "      then 1 else 0 end ";
                                                            break;
                                                        //QCondition = QCondition & " else " & CaseElseVal & " end = 1 "
                                                        //QCondition = QCondition & ") "


                                                        case "Numb":
                                                            QCondition = string.Format(" case when ([F{0}] is not null AND ", li_FieldLoc);
                                                            //LDW QCondition = QCondition + " [F" + li_FieldLoc + "] " + rs_MeasureCriteria.rdoColumns["FieldOperator"].Value;
                                                            QCondition = string.Format("{0} [F{1}] {2}", QCondition, li_FieldLoc, myRow7.Field<string>("FieldOperator"));
                                                            //LDW QCondition = QCondition + " [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["ddid2"].Value))) + "] ";
                                                            string refddid2_3 = Strings.Trim(myRow7.Field<int>("ddid2").ToString());
                                                            QCondition = string.Format("{0} [F{1}] ", QCondition, LookupLocationOnDDID(refddid2_3));
                                                            //LDW QCondition = QCondition + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value;
                                                            QCondition = string.Format("{0}{1} {2}", QCondition, myRow7.Field<string>("ValueOperator"), myRow7.Field<string>("FIELDVALUE"));
                                                            QCondition = QCondition + ") ";
                                                            QCondition = QCondition + " then 1 ";
                                                            break;
                                                        default:
                                                            //LDW QCondition = " case when [F" + li_FieldLoc + "] " + rs_MeasureCriteria.rdoColumns["FieldOperator"].Value;
                                                            QCondition = string.Format(" case when [F{0}] {1}", li_FieldLoc, myRow7.Field<string>("FieldOperator"));
                                                            //LDW QCondition = QCondition + " [F" + LookupLocationOnDDID( Strings.Trim(Convert.ToString(rs_MeasureCriteria.rdoColumns["ddid2"].Value))) + "] ";
                                                            string refddid2_4 = Strings.Trim(myRow7.Field<int>("ddid2").ToString());
                                                            QCondition = string.Format("{0} [F{1}] ", QCondition, LookupLocationOnDDID(refddid2_4));
                                                            //LDW QCondition = QCondition + rs_MeasureCriteria.rdoColumns["ValueOperator"].Value + " " + rs_MeasureCriteria.rdoColumns["FIELDVALUE"].Value;
                                                            QCondition = string.Format("{0}{1} {2}", QCondition, myRow7.Field<string>("ValueOperator"), myRow7.Field<string>("FIELDVALUE"));
                                                            QCondition = QCondition + " then 1 ";
                                                            break;
                                                    }
                                                }
                                            }
                                        }

                                        if (StepConditions[li_StepCnt].HasGroupLogic == false)
                                        {
                                            if (ExceptionMethod == false)
                                            {
                                                QCondition = QCondition + "    else 0 end ";
                                                if (string.IsNullOrEmpty(SetConditions))
                                                {
                                                    SetConditions = QCondition;
                                                }
                                                else
                                                {
                                                    SetConditions = string.Format("{0} + {1}", SetConditions, QCondition);
                                                }
                                            }
                                            else
                                            {
                                                SetConditions = string.Format("{0} {1} {2}", SetConditions, ls_LastJoin, QCondition);
                                            }
                                        }
                                        //LDW if (!rs_MeasureCriteria.EOF)
                                        foreach (DataRow myRow10 in rs_MeasureCriteria.Tables[sqlTableName24].Rows)
                                        {
                                            //LDW ls_LastJoin = Strings.Trim(Strings.UCase(rs_MeasureCriteria.rdoColumns["JoinOperator"].Value));
                                            ls_LastJoin = Strings.Trim(Strings.UCase(myRow10.Field<string>("JoinOperator")));
                                            //LDW rs_MeasureCriteria.MoveNext();
                                        }
                                    }
                                    //LDW rs_MeasureCriteria.Close();
                                    rs_MeasureCriteria.Dispose();

                                    switch (StepConditions[li_StepCnt].HasGroupLogic)
                                    {
                                        case true:

                                            if (Strings.Trim(ls_LastJoin) == "AND")
                                            {
                                                //LDW modGlobal.gv_sql = "INSERT INTO tbl_temp_MeasureSetGroupResults (VRMID, MeasureSet, Step) " + " SELECT DISTINCT VRMID, " + rs_MeasureSet.rdoColumns["MeasureCriteriaSet"].Value + ", " + StepConditions[li_StepCnt].PStep + " FROM tbl_temp_tTempPatRecCriteria WHERE Step = " + StepConditions[li_StepCnt].PStep + " AND EXISTS ( " + " SELECT VRMID, Count(MeasureCriteria) FROM tbl_temp_tTempPatRecCriteria temp" + " WHERE Step = " + StepConditions[li_StepCnt].PStep + " AND MeasureSet = " + thisset + " AND temp.VRMID = tbl_temp_tTempPatRecCriteria.VRMID " + " GROUP BY VRMID " + " HAVING Count(MeasureCriteria) = " + li_CritCount + ")";
                                                modGlobal.gv_sql = string.Format("INSERT INTO tbl_temp_MeasureSetGroupResults (VRMID, MeasureSet, Step) " +
                                                    "SELECT DISTINCT VRMID, {0}, {1} FROM tbl_temp_tTempPatRecCriteria WHERE Step = {2} AND EXISTS " +
                                                    "(  SELECT VRMID, Count(MeasureCriteria) FROM tbl_temp_tTempPatRecCriteria temp WHERE Step = {3} AND " +
                                                    "MeasureSet = {4} AND temp.VRMID = tbl_temp_tTempPatRecCriteria.VRMID  GROUP BY VRMID  HAVING Count(MeasureCriteria) = {5})",
                                                    myRow5.Field<string>("MeasureCriteriaSet"), StepConditions[li_StepCnt].PStep, StepConditions[li_StepCnt].PStep,
                                                    StepConditions[li_StepCnt].PStep, thisset, li_CritCount);
                                            }
                                            else if (Strings.Trim(ls_LastJoin) == "OR")
                                            {
                                                modGlobal.gv_sql = string.Format("INSERT INTO tbl_temp_MeasureSetGroupResults (VRMID, MeasureSet, Step) SELECT DISTINCT VRMID, " +
                                                    "MeasureSet, Step FROM tbl_temp_tTempPatRecCriteria WHERE Step = {0} AND MeasureSet = {1}", StepConditions[li_StepCnt].PStep, thisset);
                                            }

                                            // LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                            break;

                                        case false:
                                            if (ExceptionMethod == false)
                                            {
                                                if (setJoinOp == "AND")
                                                {
                                                    SetConditions = string.Format(" ( {0} ) = {1}", SetConditions, CritCount);
                                                }
                                                else if (setJoinOp == "OR")
                                                {
                                                    SetConditions = string.Format(" ( {0} ) >= 1 ", SetConditions);
                                                }
                                                else
                                                {
                                                    //LDW same condition
                                                    //SetConditions = string.Format(" ( {0} ) >= 1 ", SetConditions);
                                                }
                                            }

                                            if (string.IsNullOrEmpty(ls_GroupJoin))
                                            {
                                                if (string.IsNullOrEmpty(StepCondition))
                                                {
                                                    StepCondition = string.Format("( {0} )", SetConditions);
                                                }
                                                else
                                                {
                                                    StepCondition = string.Format("{0} {1} ( {2} )", StepCondition, MainJOp, SetConditions);
                                                }
                                            }
                                            else
                                            {
                                                //piece the groupconditions together
                                                if (string.IsNullOrEmpty(GroupSubCondition))
                                                {
                                                    GroupSubCondition = string.Format("({0})", SetConditions);
                                                }
                                                else
                                                {
                                                    //LDW if (li_LastGroupNo != rs_MeasureSet.rdoColumns["MeasureStepGroup"].Value)
                                                    if (li_LastGroupNo != myRow5.Field<int>("MeasureStepGroup"))
                                                    {
                                                        if (string.IsNullOrEmpty(GroupCondition))
                                                        {
                                                            GroupCondition = string.Format("( {0} )", GroupSubCondition);
                                                        }
                                                        else
                                                        {
                                                            GroupCondition = string.Format("{0} {1} ({2})", GroupCondition, ls_GroupJoin, GroupSubCondition);
                                                        }

                                                        GroupSubCondition = string.Format(" ({0})", SetConditions);
                                                    }
                                                    else
                                                    {
                                                        if (string.IsNullOrEmpty(GroupSubCondition))
                                                        {
                                                            GroupSubCondition = string.Format(" ({0})", SetConditions);
                                                        }
                                                        else
                                                        {
                                                            GroupSubCondition = string.Format("{0} {1} ( {2} )", GroupSubCondition, MainJOp, SetConditions);
                                                        }
                                                    }
                                                }
                                                //LDW li_LastGroupNo = rs_MeasureSet.rdoColumns["MeasureStepGroup"].Value;
                                                li_LastGroupNo = myRow5.Field<int>("MeasureStepGroup");
                                            }
                                            break;
                                    }
                                    //LDW rs_MeasureSet.MoveNext();
                                }
                                //LDW rs_MeasureSet.Close();
                                rs_MeasureSet.Dispose();

                                if (StepConditions[li_StepCnt].HasGroupLogic == false)
                                {
                                    if (string.IsNullOrEmpty(GroupCondition))
                                    {
                                        StepConditions[li_StepCnt].SQL = StepCondition;
                                    }
                                    else
                                    {
                                        StepConditions[li_StepCnt].SQL = string.Format("{0} {1} ( {2} )", GroupCondition, ls_GroupJoin, GroupSubCondition);
                                    }
                                }
                                else
                                {
                                    //Create a Result table for the STEP not based on groups
                                    if (Strings.Trim(MainJOp) == "AND")
                                    {
                                        modGlobal.gv_sql = string.Format("SELECT VRMID, Count(MeasureSet) FROM tbl_temp_MeasureSetGroupResults WHERE Step " +
                                            " = {0} GROUP BY VRMID  HAVING Count(MeasureSet) = {1}", StepConditions[li_StepCnt].PStep, thisset);
                                        //LDW rs_PatRecCrit = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                        sqlTableName31 = "tbl_temp_MeasureSetGroupResults";
                                        rs_PatRecCrit = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName31, rs_PatRecCrit);
                                        //LDW while (!rs_PatRecCrit.EOF)
                                        foreach (DataRow myRow11 in rs_PatRecCrit.Tables[sqlTableName31].Rows)
                                        {
                                            //LDW modGlobal.gv_sql = "INSERT INTO tbl_temp_MeasureStepGroupResults (VRMID, MeasureStep) " + " VALUES (" + rs_PatRecCrit.rdoColumns["VRMID"].Value + ", " + StepConditions[li_StepCnt].PStep + ") ";
                                            modGlobal.gv_sql = string.Format("INSERT INTO tbl_temp_MeasureStepGroupResults (VRMID, MeasureStep)  VALUES ({0}, {1}) ",
                                                myRow11.Field<int>("VRMID"), StepConditions[li_StepCnt].PStep);
                                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                            //LDW rs_PatRecCrit.MoveNext();
                                        }
                                        //LDW rs_PatRecCrit.Close();
                                        rs_PatRecCrit.Dispose();
                                    }
                                    else if (Strings.Trim(MainJOp) == "OR")
                                    {
                                        modGlobal.gv_sql = "INSERT INTO tbl_temp_MeasureStepGroupResults (VRMID, MeasureStep) SELECT DISTINCT VRMID, Step FROM tbl_temp_MeasureSetGroupResults WHERE Step = "
                                            + StepConditions[li_StepCnt].PStep;
                                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    }
                                }

                                //StepConditions(li_StepCnt).CAT = Nz(Trim(rs_MeasureStep!CAT), "X")
                                //LDW if (Information.IsDBNull(rs_MeasureStep["CAT"]))
                                if (Information.IsDBNull(myRow1.Field<string>("CAT")))
                                {
                                    StepConditions[li_StepCnt].CAT = "X";
                                }
                                else
                                {
                                    //LDW StepConditions[li_StepCnt].CAT = Strings.Trim(rs_MeasureStep["CAT"]);
                                    StepConditions[li_StepCnt].CAT = Strings.Trim(myRow1.Field<string>("CAT"));
                                }

                                //StepConditions(li_StepCnt).CAT_TYPE = Nz(Trim(rs_MeasureStep!CAT_TYPE), "F")
                                //LDW if (Information.IsDBNull(rs_MeasureStep["CAT_TYPE"]) & Information.IsDBNull(rs_MeasureStep["GoToStep"]))
                                if (Information.IsDBNull(myRow1.Field<string>("CAT_TYPE")) & Information.IsDBNull(myRow1.Field<string>("GoToStep")))
                                {
                                    StepConditions[li_StepCnt].CAT_TYPE = "F";
                                }
                                else
                                {
                                    //LDW if (Information.IsDBNull(rs_MeasureStep["CAT_TYPE"]) & rs_MeasureStep["isrisk"] == false)
                                    if (Information.IsDBNull(myRow1.Field<string>("CAT_TYPE")) & myRow1.Field<bool>("isrisk") == false)
                                    {
                                        StepConditions[li_StepCnt].CAT_TYPE = "CI";
                                    }
                                    //LDW else if (Information.IsDBNull(rs_MeasureStep["CAT_TYPE"]) & rs_MeasureStep["isrisk"] == true)
                                    else if (Information.IsDBNull(myRow1.Field<string>("CAT_TYPE")) & myRow1.Field<bool>("isrisk") == true)
                                    {
                                        StepConditions[li_StepCnt].CAT_TYPE = "RA";
                                    }
                                    else
                                    {
                                        //LDW StepConditions[li_StepCnt].CAT_TYPE = Strings.Trim(rs_MeasureStep["CAT_TYPE"]);
                                        StepConditions[li_StepCnt].CAT_TYPE = Strings.Trim(myRow1.Field<string>("CAT_TYPE"));
                                    }
                                }

                                //LDW if (Information.IsDBNull(rs_MeasureStep["GoToStep"]))
                                if (Information.IsDBNull(myRow1.Field<string>("GoToStep")))
                                {
                                    StepConditions[li_StepCnt].GoToStep = 0;
                                }
                                else
                                {
                                    //LDW StepConditions[li_StepCnt].GoToStep = Convert.ToInt32(Strings.Trim(rs_MeasureStep["GoToStep"]));
                                    StepConditions[li_StepCnt].GoToStep = Convert.ToInt32(Strings.Trim(myRow1.Field<string>("GoToStep")));
                                }

                                //LDW StepConditions[li_StepCnt].PStep = rs_MeasureStep["measurestep"];
                                StepConditions[li_StepCnt].PStep = myRow1.Field<int>("measurestep");

                                //Debug.Print StepConditions(li_StepCnt).SQL
                                li_StepCnt = li_StepCnt + 1;
                                //LDW rs_MeasureStep.MoveNext();
                            }

                            lb_FilterMeasure = false;

                            //Process the queries in the step array, 1 step at a time then remove from the measuredata table into the temp results table
                            for (li_cnt = 0; li_cnt <= Information.UBound(StepConditions); li_cnt++)
                            {
                                // sometimes blocks of ifs can be confusing to read - ie - this loop
                                // so i mixed it up with case statements to add some flava
                                switch (StepConditions[li_cnt].HasGroupLogic)
                                {
                                    case true:
                                        //LDW modGlobal.gv_cn.Execute("DELETE FROM tmp_MeasureData");
                                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tmp_MeasureData");


                                        //LDW modGlobal.gv_cn.Execute("INSERT INTO tmp_MeasureData SELECT * FROM tbl_MeasureData ");
                                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "INSERT INTO tmp_MeasureData SELECT * FROM tbl_MeasureData ");


                                        if (lb_FilterMeasure)
                                        {
                                            //LDW modGlobal.gv_sql = "DELETE FROM tmp_MeasureData WHERE VRMID in " + " (SELECT DISTINCT VRMID FROM temp_VerifyResults WHERE PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value + " AND CAT_TYPE = 'F' )";
                                            modGlobal.gv_sql = string.Format("DELETE FROM tmp_MeasureData WHERE VRMID in  (SELECT DISTINCT VRMID FROM temp_VerifyResults " +
                                                "WHERE PMI = {0} AND CAT_TYPE = 'F' )", myRow.Field<string>("JCAHOID"));
                                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                        }

                                        //the patient records matching this step have already been determined so use that table
                                        //If CheckNumberofPatientRecords(False, rs_Measures!IndicatorID, StepConditions(li_cnt).CAT_TYPE) > 0 Then
                                        modGlobal.gv_sql = "INSERT INTO temp_VerifyResults ";
                                        modGlobal.gv_sql = modGlobal.gv_sql + " (VRMID, Cat, Cat_Type, GoToStep, ProcessingStep, ";
                                        modGlobal.gv_sql = modGlobal.gv_sql + " PMI, CaseID, PMSI, BatchNo)";
                                        modGlobal.gv_sql = modGlobal.gv_sql + " SELECT VRMID, ";

                                        if (Information.IsDBNull(StepConditions[li_cnt].CAT))
                                        {
                                            modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                                        }
                                        else
                                        {
                                            modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, StepConditions[li_cnt].CAT);
                                        }
                                        modGlobal.gv_sql = string.Format("{0} AS CAT, '{1}' AS CAT_TYPE, ", modGlobal.gv_sql, StepConditions[li_cnt].CAT_TYPE);

                                        if (Information.IsDBNull(StepConditions[li_cnt].GoToStep) | StepConditions[li_cnt].GoToStep == 0)
                                        {
                                            modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                                        }
                                        else
                                        {
                                            modGlobal.gv_sql = modGlobal.gv_sql + StepConditions[li_cnt].GoToStep;
                                        }
                                        modGlobal.gv_sql = string.Format("{0} as GoToStep , {1} AS ProcessingStep ", modGlobal.gv_sql, StepConditions[li_cnt].PStep);
                                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + ", " + rs_Measures.rdoColumns["JCAHOID"].Value + ", [F" + LookupLocationOnDDID( "CaseID") + "], [F" + LookupLocationOnDDID( "PMSI") + "] ";
                                        const string refCaseID = "CaseID";
                                        const string refPMSI = "PMSI";
                                        modGlobal.gv_sql = string.Format("{0}, {1}, [F{2}], [F{3}] ", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"),
                                            LookupLocationOnDDID(refCaseID), LookupLocationOnDDID(refPMSI));
                                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + ", [F" + LookupLocationOnDDID( "BatchNo") + "] ";
                                        const string refBatchNo = "BatchNo";
                                        modGlobal.gv_sql = string.Format("{0}, [F{1}] ", modGlobal.gv_sql, LookupLocationOnDDID(refBatchNo));
                                        modGlobal.gv_sql = string.Format("{0} FROM tmp_MeasureData WHERE EXISTS (SELECT NULL FROM tbl_temp_MeasureStepGroupResults WHERE " +
                                            "VRMID = tmp_MeasureData.VRMID AND MeasureStep = {1}) ", modGlobal.gv_sql, StepConditions[li_cnt].PStep);
                                        modGlobal.gv_sql = modGlobal.gv_sql + "  AND NOT EXISTS ";
                                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + "  (SELECT NULL from temp_VerifyResults where PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                        modGlobal.gv_sql = string.Format("{0}  (SELECT NULL from temp_VerifyResults where PMI = {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                        modGlobal.gv_sql = string.Format("{0}   and CAT_TYPE = '{1}' AND  temp_VerifyResults.VRMID = tmp_MeasureData.VRMID)",
                                            modGlobal.gv_sql, StepConditions[li_cnt].CAT_TYPE);

                                        //Debug.Print gv_sql
                                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                        break;
                                    //Debug.Print gv_sql

                                    //End If

                                    case false:

                                        if (StepConditions[li_cnt].CAT_TYPE == "F" & StepConditions[li_cnt].GoToStep == 0)
                                        {
                                            lb_FilterMeasure = true;

                                            //only process the records matching the filter criteria
                                            modGlobal.gv_sql = "INSERT INTO temp_VerifyResults ";
                                            modGlobal.gv_sql = modGlobal.gv_sql + " (VRMID, GoToStep,  Cat, Cat_Type,  ";
                                            modGlobal.gv_sql = modGlobal.gv_sql + " PMI, CaseID, PMSI, BatchNo)";
                                            modGlobal.gv_sql = modGlobal.gv_sql + " SELECT VRMID, 0, '";
                                            modGlobal.gv_sql = string.Format("{0}{1}', '{2}", modGlobal.gv_sql, StepConditions[li_cnt].CAT, StepConditions[li_cnt].CAT_TYPE);
                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + "', " + rs_Measures.rdoColumns["JCAHOID"].Value + ", [F" + LookupLocationOnDDID( "CaseID") + "], [F" + LookupLocationOnDDID( "PMSI");
                                            string refCaseID1 = "CaseID";
                                            string refPMSI1 = "PMSI";
                                            modGlobal.gv_sql = string.Format("{0}', {1}, [F{2}], [F{3}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"),
                                                LookupLocationOnDDID(refCaseID1), LookupLocationOnDDID(refPMSI1));
                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + "], [F" + LookupLocationOnDDID( "BatchNo") + "] FROM ";
                                            string refBatchNo1 = "BatchNo";
                                            modGlobal.gv_sql = string.Format("{0}], [F{1}] FROM ", modGlobal.gv_sql, LookupLocationOnDDID(refBatchNo1));
                                            modGlobal.gv_sql = modGlobal.gv_sql + "  tmp_MeasureData WHERE VRMID not in (SELECT VRMID FROM ";
                                            modGlobal.gv_sql = string.Format("{0}  tmp_MeasureData WHERE ( {1}))", modGlobal.gv_sql, StepConditions[li_cnt].SQL);
                                            //Debug.Print gv_sql
                                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                        }
                                        else
                                        {

                                            if (ls_PrevCatType != StepConditions[li_cnt].CAT_TYPE)
                                            {
                                                //LDW modGlobal.gv_cn.Execute("DELETE FROM tmp_MeasureData");
                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tmp_MeasureData");

                                                //LDW modGlobal.gv_cn.Execute("INSERT INTO tmp_MeasureData SELECT * FROM tbl_MeasureData ");
                                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "INSERT INTO tmp_MeasureData SELECT * FROM tbl_MeasureData ");


                                                if (lb_FilterMeasure)
                                                {
                                                    //LDW modGlobal.gv_sql = "DELETE FROM tmp_MeasureData WHERE VRMID in " + " (SELECT DISTINCT VRMID FROM temp_VerifyResults WHERE PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value + " AND CAT_TYPE = 'F' )";
                                                    modGlobal.gv_sql = string.Format("DELETE FROM tmp_MeasureData WHERE VRMID in  (SELECT DISTINCT VRMID FROM temp_VerifyResults WHERE PMI = {0} AND CAT_TYPE = 'F' )", myRow.Field<string>("JCAHOID"));
                                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                                }
                                            }

                                            modGlobal.gv_sql = "INSERT INTO temp_VerifyResults ";
                                            modGlobal.gv_sql = modGlobal.gv_sql + " (VRMID, Cat, GoToStep, Cat_Type,  ProcessingStep, ";
                                            modGlobal.gv_sql = modGlobal.gv_sql + " PMI, CaseID, PMSI, BatchNo)";
                                            modGlobal.gv_sql = modGlobal.gv_sql + " SELECT VRMID, ";
                                            if (Information.IsDBNull(StepConditions[li_cnt].CAT))
                                            {
                                                modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                                            }
                                            else
                                            {
                                                modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, StepConditions[li_cnt].CAT);
                                            }
                                            modGlobal.gv_sql = modGlobal.gv_sql + ", ";
                                            if (Information.IsDBNull(StepConditions[li_cnt].GoToStep))
                                            {
                                                modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                                            }
                                            else
                                            {
                                                modGlobal.gv_sql = modGlobal.gv_sql + StepConditions[li_cnt].GoToStep;
                                            }
                                            modGlobal.gv_sql = string.Format("{0}, '{1}'", modGlobal.gv_sql, StepConditions[li_cnt].CAT_TYPE);
                                            modGlobal.gv_sql = string.Format("{0}, {1}", modGlobal.gv_sql, StepConditions[li_cnt].PStep);
                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + ", " + rs_Measures.rdoColumns["JCAHOID"].Value + ", [F" + LookupLocationOnDDID( "CaseID") + "], [F" + LookupLocationOnDDID( "PMSI") + "] ";
                                            const string refCaseID2 = "CaseID";
                                            const string refPMSI2 = "PMSI";
                                            modGlobal.gv_sql = string.Format("{0}, {1}, [F{2}], [F{3}] ", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"),
                                                LookupLocationOnDDID(refCaseID2), LookupLocationOnDDID(refPMSI2));
                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + ", [F" + LookupLocationOnDDID( "BatchNo") + "] ";
                                            const string refBatchNo2 = "BatchNo";
                                            modGlobal.gv_sql = string.Format("{0}, [F{1}] ", modGlobal.gv_sql, LookupLocationOnDDID(refBatchNo2));
                                            modGlobal.gv_sql = modGlobal.gv_sql + "  From tmp_MeasureData ";
                                            modGlobal.gv_sql = string.Format("{0}  WHERE ( {1})", modGlobal.gv_sql, StepConditions[li_cnt].SQL);
                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + "  and [F" + LookupLocationOnDDID( "CaseID") + "] not in ";
                                            modGlobal.gv_sql = string.Format("{0}  and [F{1}] not in ", modGlobal.gv_sql, LookupLocationOnDDID(refCaseID2));
                                            //LDW modGlobal.gv_sql = modGlobal.gv_sql + "  (select caseid from temp_VerifyResults where PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                            modGlobal.gv_sql = string.Format("{0}  (select caseid from temp_VerifyResults where PMI = {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                            modGlobal.gv_sql = string.Format("{0}   and Cat_Type = '{1}')", modGlobal.gv_sql, StepConditions[li_cnt].CAT_TYPE);
                                            //Debug.Print gv_sql

                                            //If thisindicatorid = 56 And (StepConditions(li_cnt).PStep = 11) Then
                                            //    gv_g = True
                                            //End If

                                            //Debug.Print gv_sql
                                            //gv_g = InputBox("", "", gv_sql)
                                            //Open "C:\iha\test.sql" For Output As #1
                                            //    Print #1, gv_sql
                                            //    Close #1
                                            //Debug.Print gv_sql

                                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                            //  Debug.Print gv_sql

                                            //If StepConditions(li_cnt).PStep = 28 And rs_Measures!JCAHOID = 14657 Then
                                            // Open "C:\iha\test.sql" For Output As #1
                                            //    Print #1, gv_sql
                                            //    Close #1
                                            //End If
                                            //gv_g = InputBox("", "", gv_sql)
                                            //Open "C:\iha\test.sql" For Output As #1
                                            //    Print #1, gv_sql
                                            //    Close #1
                                            //Debug.Print gv_sql
                                        }

                                        //if records with X were inserted, they are not done yet,
                                        //and we have to continue with the step that follows it
                                        //otherwise we remove it from the temp table
                                        modGlobal.gv_sql = "DELETE FROM tmp_MeasureData WHERE VRMID in ";
                                        modGlobal.gv_sql = modGlobal.gv_sql + " (SELECT DISTINCT VRMID FROM temp_VerifyResults ";
                                        //LDW modGlobal.gv_sql = modGlobal.gv_sql + " WHERE PMI =  " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                        modGlobal.gv_sql = string.Format("{0} WHERE PMI =  {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                        modGlobal.gv_sql = modGlobal.gv_sql + " And Cat <> 'X' ";
                                        modGlobal.gv_sql = string.Format("{0} AND CAT_TYPE = '{1}'  )", modGlobal.gv_sql, StepConditions[li_cnt].CAT_TYPE);
                                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                        //Debug.Print gv_sql
                                        ls_PrevCatType = StepConditions[li_cnt].CAT_TYPE;
                                        break;
                                }
                            }

                            //Now we process the records that match the GoTo step
                            ProcessGoToStep = true;
                            while (ProcessGoToStep)
                            {
                                //now we continue the process for the ones that have an X as category and need to be checked with the other steps
                                modGlobal.gv_sql = "SELECT distinct GoToStep, Cat_Type ";
                                modGlobal.gv_sql = modGlobal.gv_sql + " FROM temp_VerifyResults ";
                                //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where GoToStep is not null and GoToStep > 0 and PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                modGlobal.gv_sql = string.Format("{0} where GoToStep is not null and GoToStep > 0 and PMI = {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                                sqlTableName30 = "temp_VerifyResults";
                                rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName30, rs_Temp);

                                //LDW if (rs_Temp.RowCount == 0)
                                if (rs_Temp.Tables[sqlTableName30].Rows.Count == 0)
                                {
                                    ProcessGoToStep = false;
                                }
                                else
                                {
                                    //LDW modGlobal.gv_cn.Execute("DELETE FROM tmp_MeasureData");
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tmp_MeasureData");

                                    //LDW modGlobal.gv_cn.Execute("INSERT INTO tmp_MeasureData SELECT * FROM tbl_MeasureData ");
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "INSERT INTO tmp_MeasureData SELECT * FROM tbl_MeasureData ");


                                    if (lb_FilterMeasure)
                                    {
                                        //LDW modGlobal.gv_sql = "DELETE FROM tmp_MeasureData WHERE VRMID in " + " (SELECT DISTINCT VRMID FROM temp_VerifyResults WHERE PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value + " AND CAT_TYPE = 'F' )";
                                        modGlobal.gv_sql = string.Format("DELETE FROM tmp_MeasureData WHERE VRMID in  (SELECT DISTINCT VRMID FROM temp_VerifyResults WHERE PMI = {0} AND CAT_TYPE = 'F' )",
                                            myRow.Field<string>("JCAHOID"));
                                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    }
                                }

                                //LDW while (!rs_Temp.EOF)
                                foreach (DataRow myRow9 in rs_Temp.Tables[sqlTableName30].Rows)
                                {
                                    //Tag the records that have X with R (to remove at the end if they don't match any conditions
                                    modGlobal.gv_sql = "Update temp_VerifyResults set ";
                                    modGlobal.gv_sql = modGlobal.gv_sql + " Cat =  'R' ";
                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where temp_VerifyResults.PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                    modGlobal.gv_sql = string.Format("{0} where temp_VerifyResults.PMI = {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                    modGlobal.gv_sql = modGlobal.gv_sql + "  and Cat = 'X'";
                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + "  and GoToStep = " + rs_Temp.rdoColumns["GoToStep"].Value;
                                    modGlobal.gv_sql = string.Format("{0}  and GoToStep = {1}", modGlobal.gv_sql, myRow9.Field<int>("GoToStep"));
                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + "  and CAT_TYPE = '" + rs_Temp.rdoColumns["CAT_TYPE"].Value + "'";
                                    modGlobal.gv_sql = string.Format("{0}  and CAT_TYPE = '{1}'", modGlobal.gv_sql, myRow9.Field<string>("CAT_TYPE"));

                                    //gv_g = InputBox("", "", gv_sql)
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    StartHere = "N";
                                    for (li_cnt = 0; li_cnt <= Information.UBound(StepConditions); li_cnt++)
                                    {
                                        //LDW if (StepConditions[li_cnt].PStep == rs_Temp.rdoColumns["GoToStep"].Value & StepConditions[li_cnt].CAT_TYPE == rs_Temp.rdoColumns["CAT_TYPE"].Value)
                                        if (StepConditions[li_cnt].PStep == myRow9.Field<int>("GoToStep") & StepConditions[li_cnt].CAT_TYPE == myRow9.Field<string>("CAT_TYPE"))
                                        {
                                            StartHere = "Y";
                                        }
                                        //LDW if (StartHere == "Y" & StepConditions[li_cnt].CAT_TYPE == rs_Temp.rdoColumns["CAT_TYPE"].Value)
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                                        if (StartHere == "Y" & StepConditions[li_cnt].CAT_TYPE == myRow9.Field<string>("CAT_TYPE"))
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
                                        {
                                            // sometimes blocks of ifs can be confusing to read - ie - this loop
                                            // so i mixed it up with case statements to add some flava
                                            switch (StepConditions[li_cnt].HasGroupLogic)
                                            {
                                                case true:

                                                    //the patient records matching this step have already been determined so use that table
                                                    modGlobal.gv_sql = "Update temp_VerifyResults set ";
                                                    modGlobal.gv_sql = string.Format("{0} Cat =  '{1}', ", modGlobal.gv_sql, StepConditions[li_cnt].CAT);
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " GoToStep = ";
                                                    if (Information.IsDBNull(StepConditions[li_cnt].GoToStep))
                                                    {
                                                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                                                    }
                                                    else
                                                    {
                                                        modGlobal.gv_sql = modGlobal.gv_sql + StepConditions[li_cnt].GoToStep;
                                                    }
                                                    modGlobal.gv_sql = modGlobal.gv_sql + ", ";
                                                    modGlobal.gv_sql = string.Format("{0} ProcessingStep = {1}", modGlobal.gv_sql, StepConditions[li_cnt].PStep);
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " From temp_VerifyResults inner join tmp_MeasureData  ";
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " on temp_VerifyResults.VRMID = tmp_MeasureData.VRMID ";
                                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " and temp_VerifyResults.caseid = tmp_MeasureData.[F" + LookupLocationOnDDID( "CaseID") + "]  ";
                                                    const string refCaseID3 = "CaseID";
                                                    modGlobal.gv_sql = string.Format("{0} and temp_VerifyResults.caseid = tmp_MeasureData.[F{1}]  ", modGlobal.gv_sql, LookupLocationOnDDID(refCaseID3));
                                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where temp_VerifyResults.PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                                    modGlobal.gv_sql = string.Format("{0} where temp_VerifyResults.PMI = {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " and temp_VerifyResults.Cat = 'R' ";
                                                    modGlobal.gv_sql = string.Format("{0} AND EXISTS (SELECT NULL FROM tbl_temp_MeasureStepGroupResults WHERE VRMID " +
                                                        "= tmp_MeasureData.VRMID AND MeasureStep = {1}) ", modGlobal.gv_sql, StepConditions[li_cnt].PStep);

                                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                                    break;

                                                //Debug.Print gv_sql
                                                case false:
                                                    //continue the logic from this step
                                                    modGlobal.gv_sql = "Update temp_VerifyResults set ";
                                                    modGlobal.gv_sql = string.Format("{0} Cat =  '{1}', ", modGlobal.gv_sql, StepConditions[li_cnt].CAT);
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " GoToStep = ";
                                                    if (Information.IsDBNull(StepConditions[li_cnt].GoToStep))
                                                    {
                                                        modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                                                    }
                                                    else
                                                    {
                                                        modGlobal.gv_sql = modGlobal.gv_sql + StepConditions[li_cnt].GoToStep;
                                                    }
                                                    modGlobal.gv_sql = modGlobal.gv_sql + ", ";
                                                    modGlobal.gv_sql = string.Format("{0} ProcessingStep = {1}", modGlobal.gv_sql, StepConditions[li_cnt].PStep);
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " From temp_VerifyResults inner join tmp_MeasureData  ";
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " on temp_VerifyResults.VRMID = tmp_MeasureData.VRMID ";
                                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " and temp_VerifyResults.caseid = tmp_MeasureData.[F" + LookupLocationOnDDID( "CaseID") + "]  ";
                                                    string refCaseID4 = "CaseID";
                                                    modGlobal.gv_sql = string.Format("{0} and temp_VerifyResults.caseid = tmp_MeasureData.[F{1}]  ", modGlobal.gv_sql, LookupLocationOnDDID(refCaseID4));
                                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where temp_VerifyResults.PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                                    modGlobal.gv_sql = string.Format("{0} where temp_VerifyResults.PMI = {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                                    modGlobal.gv_sql = modGlobal.gv_sql + " and temp_VerifyResults.Cat = 'R' ";
                                                    modGlobal.gv_sql = string.Format("{0}  and ( {1})", modGlobal.gv_sql, StepConditions[li_cnt].SQL);

                                                    //  InputBox "", "", gv_sql

                                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                                    break;
                                            }
                                        }
                                    }

                                    modGlobal.gv_sql = "Delete temp_VerifyResults  ";
                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " where temp_VerifyResults.PMI = " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                    modGlobal.gv_sql = string.Format("{0} where temp_VerifyResults.PMI = {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                    modGlobal.gv_sql = modGlobal.gv_sql + "  and Cat = 'R'";
                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + "  and GoToStep = " + rs_Temp.rdoColumns["GoToStep"].Value;
                                    modGlobal.gv_sql = string.Format("{0}  and GoToStep = {1}", modGlobal.gv_sql, myRow.Field<string>("GoToStep"));
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);

                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                    modGlobal.gv_sql = "DELETE tmp_MeasureData WHERE VRMID in ";
                                    modGlobal.gv_sql = modGlobal.gv_sql + " (SELECT DISTINCT VRMID FROM temp_VerifyResults ";
                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + " WHERE PMI =  " + rs_Measures.rdoColumns["JCAHOID"].Value;
                                    modGlobal.gv_sql = string.Format("{0} WHERE PMI =  {1}", modGlobal.gv_sql, myRow.Field<string>("JCAHOID"));
                                    modGlobal.gv_sql = modGlobal.gv_sql + "  and Cat = 'R'";
                                    //LDW modGlobal.gv_sql = modGlobal.gv_sql + "  and GoToStep = " + rs_Temp.rdoColumns["GoToStep"].Value + ")";
                                    modGlobal.gv_sql = string.Format("{0}  and GoToStep = {1})", modGlobal.gv_sql, myRow.Field<string>("GoToStep"));
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);

                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    //LDW rs_Temp.MoveNext();
                                }
                            }

                            //gv_sql = "SELECT * FROM tmp_MeasureData"
                            //Set rs_temp = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                            //If Not rs_temp.EOF Then
                            //    MsgBox "Measure " & rs_Measures!JCAHOID & " has " & rs_temp.RowCount & _
                            //'    " rows that didn't fall into flowchart categories", vbCritical, "Double Check your Flowcharts!"
                            //End If

                            //LDW modGlobal.gv_cn.Execute("DELETE FROM tmp_MeasureData");
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "DELETE FROM tmp_MeasureData");

                        }
                    }

                    Application.DoEvents();

                    //LDW rs_Measures.MoveNext();
                    frmImportMeasureSetFileCopy.pgStatus.Value1 = (li_MeasCnt / (li_MaxMeas * (li_StartVal / frmImportMeasureSetFileCopy.pgStatus.Maximum))) * li_StartVal;
                }

                frmImportMeasureSetFileCopy.lblStatus.Text = "Formatting Results";

                //gv_cn.Execute "DELETE FROM tbl_MeasureData"

                //put the answers into the eoc result table
                modGlobal.gv_sql = string.Format("INSERT INTO tbl_EOCResults (VerifyID, PMI, CaseID, PMSI, BatchNo, CI_CAT, ProcessingStep)  " +
                    "SELECT {0},PMI,CaseId,PMSI,BatchNo,CAT, ProcessingStep  FROM temp_VerifyResults WHERE CAT in (SELECT CAT FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')", VerifyID);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                modGlobal.gv_sql = "SELECT * FROM temp_VerifyResults WHERE CAT in (SELECT CAT FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.LockTypeConstants.rdConcurLock);
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName32, modGlobal.gv_rs);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName32].Rows)
                {
                    //LDW modGlobal.gv_sql = "SELECT * FROM tbl_EOCResults WHERE CaseID = " + modGlobal.gv_rs.rdoColumns["CaseID"].Value + " AND PMI = " + modGlobal.gv_rs.rdoColumns["PMI"].Value + " AND VerifyID = " + VerifyID;
                    modGlobal.gv_sql = string.Format("SELECT * FROM tbl_EOCResults WHERE CaseID = {0} AND PMI = {1} AND VerifyID = {2}",
                        myRow11.Field<int>("CaseID"), myRow11.Field<string>("PMI"), VerifyID);
                    //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName33 = "tbl_EOCResults";
                    rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName33, rs_Temp);
                    /*LDW if (rs_Temp.EOF)
                    {
                        //gv_g = InputBox("", "", gv_sql)
                        //If Trim(rs_Temp!ci_cat) = "D" Or Trim(rs_Temp!ci_cat) = "E" Then
                        //    rs_Temp.AddNew
                        //    rs_Temp!VerifyID = VerifyID
                        //    rs_Temp!PMI = gv_rs!PMI
                        //    rs_Temp!CaseID = gv_rs!CaseID
                        //    rs_Temp!PMSI = gv_rs!PMSI
                        //    rs_Temp!BatchNo = gv_rs!BatchNo
                        //    rs_Temp!RA_CAT = gv_rs!CAT
                        //    rs_Temp.Update
                        //End If
                    }*/
                    if (Strings.Trim(rs_Temp.Tables[sqlTableName33].Rows[0]["ci_cat"].ToString()) == "D" | Strings.Trim(rs_Temp.Tables[sqlTableName33].Rows[0]["ci_cat"].ToString()) == "E")
                    {
                        //LDW if (Strings.Trim(rs_Temp.rdoColumns["ci_cat"].Value) == "D" | Strings.Trim(rs_Temp.rdoColumns["ci_cat"].Value) == "E")
                        {
                            //LDW rs_Temp.Edit();
                            //LDW rs_Temp.rdoColumns["RA_CAT"].Value = modGlobal.gv_rs.rdoColumns["CAT"].Value;
                            rs_Temp.Tables[sqlTableName33].Rows[0]["RA_CAT"] = myRow11.Field<string>("CAT");
                            //LDW rs_Temp.Update();
                            rs_Temp.AcceptChanges();
                        }
                    }
                    //LDW rs_Temp.Close();
                    rs_Temp.Dispose();
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();
                //LDW rs_Measures.Close();
                rs_Measures.Dispose();

                //determine if the measure set selected contains risk adjusted measures
                modGlobal.gv_sql = string.Format("SELECT I.IndicatorID FROM tbl_Setup_Indicator I, tbl_Setup_MeasureSet mS, tbl_Setup_MeasureSetMapMeas MMS  Where ms.MeasureSetID = mms.MeasureSetID And mms.IndicatorID = i.IndicatorID And ms.MeasureSetID = {0} AND I.RiskAdjusted = 1", MeasureSetID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName34 = "tbl_Setup_Indicator";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName34, modGlobal.gv_rs);
                //LDW if (!modGlobal.gv_rs.EOF)
                for (int index22 = 0; index22 < modGlobal.gv_rs.Tables[sqlTableName34].Rows.Count; index22++)
                {
                    var row = modGlobal.gv_rs.Tables[sqlTableName34].Rows[index22];
                    int rowIndexer = modGlobal.gv_rs.Tables[sqlTableName34].Rows.IndexOf(row);
                    int lastRow = modGlobal.gv_rs.Tables[sqlTableName34].Rows.Count - 1;

                    if (rowIndexer != lastRow)
                    {
                        frmImportMeasureSetFileCopy.lblStatus.Text = "Calculating Risk Adjusted Value(s)";
                        modGlobal.gv_sql = "{ ? = call RefreshRACoefficients(?) }";
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                        ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                        ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                        ps.rdoParameters[1].Value = id_CoefPeriod;
                        ps.Execute();
                        ps.Close(); */
                        ps.Connection = modGlobal.gv_cn;
                        ps.CommandType = CommandType.StoredProcedure;
                        ps.CommandText = "RefreshRACoefficients";
                        var inParam = new SqlParameter("@periodstart", id_CoefPeriod);
                        inParam.Direction = ParameterDirection.Input;
                        inParam.DbType = DbType.DateTime;
                        ps.Parameters.Add(inParam);
                        SqlParameter retParam11 = ps.Parameters.Add("return_value", SqlDbType.Int);
                        retParam11.Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            ps.Connection.Open();
                            ps.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            RadMessageBox.Show("Error while opening connection: " + ex.Message);
                        }
                        finally
                        {
                            ps.Dispose();
                        }

                        //LDW while (!modGlobal.gv_rs.EOF)
                        foreach (DataRow myRow22 in modGlobal.gv_rs.Tables[sqlTableName34].Rows)
                        {
                            modGlobal.gv_sql = "{ ? = call buildVerificationTableRiskAdjustedTotalInMeasure(?,?) }";
                            /*ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                            ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                            ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                            ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
                            ps.rdoParameters[1].Value = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
                            ps.rdoParameters[2].Value = VerifyID;
                            ps.Execute();
                            ps.Close();*/
                            ps.Connection = modGlobal.gv_cn;
                            ps.CommandType = CommandType.StoredProcedure;
                            ps.CommandText = "buildVerificationTableRiskAdjustedTotalInMeasure";
                            var inParam_1 = new SqlParameter("@IndID", myRow22.Field<int>("IndicatorID"));
                            inParam_1.Direction = ParameterDirection.Input;
                            inParam_1.DbType = DbType.Int32;
                            ps.Parameters.Add(inParam_1);
                            var inParam_2 = new SqlParameter("@VerifyID", VerifyID);
                            inParam_2.Direction = ParameterDirection.Input;
                            inParam_2.DbType = DbType.Int32;
                            ps.Parameters.Add(inParam_2);
                            SqlParameter retParam13 = ps.Parameters.Add("return_value", SqlDbType.Int);
                            retParam13.Direction = ParameterDirection.ReturnValue;
                            try
                            {
                                ps.Connection.Open();
                                ps.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                RadMessageBox.Show("Error while opening connection: " + ex.Message);
                            }
                            finally
                            {
                                ps.Dispose();
                            }

                            //LDW modGlobal.gv_rs.MoveNext();
                        }
                        lb_RA = true;
                    }
                }
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();

                frmImportMeasureSetFileCopy.lblStatus.Text = "Calculating EOC Measurement Values";
                modGlobal.gv_sql = "{ ? = call calculateEOCMeasurementValues(?,?) }";
                /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
                ps.rdoParameters[1].Value = VerifyID;
                ps.rdoParameters[2].Value = MeasureSetID;
                ps.Execute();
                ps.Close();*/
                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = "calculateEOCMeasurementValues";
                var inParam1 = new SqlParameter("@VerifyID", VerifyID);
                inParam1.Direction = ParameterDirection.Input;
                inParam1.DbType = DbType.Int32;
                ps.Parameters.Add(inParam1);
                var inParam2 = new SqlParameter("@MeasureSetID", MeasureSetID);
                inParam2.Direction = ParameterDirection.Input;
                inParam2.DbType = DbType.Int32;
                ps.Parameters.Add(inParam2);
                SqlParameter retParam_1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam_1.Direction = ParameterDirection.ReturnValue;
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show("Error while opening connection: " + ex.Message);
                }
                finally
                {
                    ps.Dispose();
                }

                modGlobal.gv_sql = string.Format("SELECT PMI, CaseID, RTRIM(CI_CAT) as CI_CAT, RTRIM(RA_CAT) as RA_CAT, MeasVal, RiskAdjRate, RiskAdjVal, " +
                    "IsNull(PMSI,'') AS PMSI, BatchNo FROM tbl_EOCResults WHERE VerifyID = {0} ORDER BY PMI, CaseID", VerifyID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName35 = "tbl_EOCResults";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName35, modGlobal.gv_rs);

                // ERROR: Not supported in C#: OnErrorStatement

                FileSystem.Kill(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\EOC_Answers.csv");
                // ERROR: Not supported in C#: OnErrorStatement


                string ls_line = null;
                int hFile = FileSystem.FreeFile();
                FileSystem.FileOpen(hFile, System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\EOC_Answers.csv", OpenMode.Output);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow13 in modGlobal.gv_rs.Tables[sqlTableName35].Rows)
                {
                    //LDW ls_line = Strings.Trim(modGlobal.gv_rs.rdoColumns["PMI"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["CaseID"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["ci_cat"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["RA_CAT"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["MeasVal"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["RiskAdjRate"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["RiskAdjVal"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns[7].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["BatchNo"].Value);
                    ls_line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Strings.Trim(myRow13.Field<string>("PMI")), Strings.Trim(myRow13.Field<string>("CaseID")),
                        Strings.Trim(myRow13.Field<string>("ci_cat")), Strings.Trim(myRow13.Field<string>("RA_CAT")), Strings.Trim(myRow13.Field<string>("MeasVal")),
                        Strings.Trim(myRow13.Field<string>("RiskAdjRate")), Strings.Trim(myRow13.Field<string>("RiskAdjVal")), Strings.Trim(myRow13.Field<string>(7)),
                        Strings.Trim(myRow13.Field<string>("BatchNo")));
                    FileSystem.PrintLine(hFile, ls_line);
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();
                FileSystem.FileClose(hFile);

                //put the answers into the hco results table
                modGlobal.gv_sql = string.Format("INSERT INTO tbl_HCOResults (PMI,VerifyID,PMSI,BatchNo) SELECT DISTINCT PMI, {0},PMSI,BatchNo  FROM temp_VerifyResults", VerifyID);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                frmImportMeasureSetFileCopy.lblStatus.Text = "Calculating HCO Values";

                modGlobal.gv_sql = "{ ? = call buildVerificationHCOFile(?) }";
                /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                ps.rdoParameters[1].Value = VerifyID;
                ps.Execute();
                ps.Close(); */
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = "buildVerificationHCOFile";
                var inParam01 = new SqlParameter("@verifyID", VerifyID);
                inParam01.Direction = ParameterDirection.Input;
                inParam01.DbType = DbType.Int32;
                ps.Parameters.Add(inParam01);
                SqlParameter retParam01 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam01.Direction = ParameterDirection.ReturnValue;
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show("Error while opening connection: " + ex.Message);
                }
                finally
                {
                    ps.Dispose();
                }

                modGlobal.gv_sql = string.Format("SELECT PMI,ObsRate,MeanObsVal,Denominator,NumCases,ICDPopulation,RiskAdjRate,MeanRiskAdjVal,PMSI,BatchNo FROM tbl_HCOResults WHERE VerifyID = {0} ORDER BY PMI", VerifyID);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                string sqlTableName36 = "tbl_HCOResults";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName36, modGlobal.gv_rs);
                FileSystem.Kill(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\HCO_Answers.csv");

                hFile = FileSystem.FreeFile();
                FileSystem.FileOpen(hFile, System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\HCO_Answers.csv", OpenMode.Output);
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow14 in modGlobal.gv_rs.Tables[sqlTableName36].Rows)
                {
                    //LDW ls_line = Strings.Trim(modGlobal.gv_rs.rdoColumns["PMI"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["ObsRate"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["MeanObsVal"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["Denominator"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["NumCases"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["ICDPopulation"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["RiskAdjRate"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["MeanRiskAdjVal"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["PMSI"].Value) + "," + Strings.Trim(modGlobal.gv_rs.rdoColumns["BatchNo"].Value);
                    ls_line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", Strings.Trim(myRow14.Field<string>("PMI")), Strings.Trim(myRow14.Field<string>("ObsRate")),
                        Strings.Trim(myRow14.Field<string>("MeanObsVal")), Strings.Trim(myRow14.Field<string>("Denominator")), Strings.Trim(myRow14.Field<string>("NumCases")),
                        Strings.Trim(myRow14.Field<string>("ICDPopulation")), Strings.Trim(myRow14.Field<string>("RiskAdjRate")), Strings.Trim(myRow14.Field<string>("MeanRiskAdjVal")),
                        Strings.Trim(myRow14.Field<string>("PMSI")), Strings.Trim(myRow14.Field<string>("BatchNo")));
                    FileSystem.PrintLine(hFile, ls_line);
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();
                FileSystem.FileClose(hFile);


                frmImportMeasureSetFileCopy.lblStatus.Text = "COMPLETE!";
                frmImportMeasureSetFileCopy.pgStatus.Value1 = 1;

                if (lb_RA)
                {
                    //frmImportMeasureSetFile.crReport.ReportFileName = "f:\cop\rptVerificationRiskAdjustment.rpt"
                    //frmImportMeasureSetFile.crReport.DiscardSavedData = 1         'dump any old data
                    //frmImportMeasureSetFile.crReport.Destination = 0            '0 to a window, 1 to a window
                    //frmImportMeasureSetFile.crReport.Connect = gv_strDBName
                    //frmImportMeasureSetFile.crReport.Action = 1
                    //dlgReport.Show vbModal
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
            //LDW ErrHandler:


            //LDW modGlobal.CheckForErrors();
            //return functionReturnValue;
        }

        private static int[] GetMultipleSelectionDDID(int DDID)
        {
            DataSet rs_Temp = new DataSet();
            int[] DDIDs = null;
            int li_cnt = 0;
            const string sqlTableName36 = "tbl_Setup_DataDef";

            modGlobal.gv_sql = "SELECT DDID FROM tbl_Setup_DataDef WHERE ParentDDID = " + DDID;
            //LDW rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            rs_Temp = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName36, rs_Temp);
            //LDW if (!rs_Temp.EOF)
            for (int index23 = 0; index23 < rs_Temp.Tables[sqlTableName36].Rows.Count; index23++)
            {
                var rowX = rs_Temp.Tables[sqlTableName36].Rows[index23];
                int rowX_Index = rs_Temp.Tables[sqlTableName36].Rows.IndexOf(rowX);

                if (rowX_Index != rs_Temp.Tables[sqlTableName36].Rows.Count - 1)
                {
                    li_cnt = 0;
                    DDIDs = new int[li_cnt + 1];
                    //LDW while (!rs_Temp.EOF)
                    foreach (DataRow row23 in rs_Temp.Tables[sqlTableName36].Rows)
                    {
                        Array.Resize(ref DDIDs, li_cnt + 1);
                        //LDW DDIDs[li_cnt] = Convert.ToInt32(Strings.Trim(rs_Temp.rdoColumns["DDID"].Value));
                        DDIDs[li_cnt] = Convert.ToInt32(Strings.Trim(row23.Field<string>("DDID")));
                        li_cnt = li_cnt + 1;
                        //LDW rs_Temp.MoveNext();
                    }
                }
            }

            //LDW rs_Temp.Close();
            rs_Temp.Dispose();

#pragma warning disable CS0618 // Type or member is obsolete
            //LDW return Support.CopyArray(DDIDs);
            return DDIDs;
#pragma warning restore CS0618 // Type or member is obsolete

        }


        //Function MSA_CreateFilterString(ParamArray varFilt() As Variant) As String
        //' Creates a filter string from the passed in arguments.
        //' Returns "" if no args are passed in.
        //' Expects an even number of args (filter name, extension), but
        //' if an odd number is passed in, it appends *.*
        //
        //    Dim strFilter As String
        //    Dim intRet As Long
        //    Dim intNum As Long
        //
        //    intNum = UBound(varFilt)
        //    If (intNum <> -1) Then
        //        For intRet = 0 To intNum
        //            strFilter = strFilter & varFilt(intRet) & vbNullChar
        //        Next
        //        If intNum Mod 2 = 0 Then
        //            strFilter = strFilter & "*.*" & vbNullChar
        //        End If
        //
        //        strFilter = strFilter & vbNullChar
        //    Else
        //        strFilter = ""
        //    End If
        //
        //    MSA_CreateFilterString = strFilter
        //End Function

        //Function MSA_ConvertFilterString(strFilterIn As String) As String
        //' Creates a filter string from a bar ("|") separated string.
        //' The string should pairs of filter|extension strings, i.e. "Access Databases|*.mdb|All Files|*.*"
        //' If no extensions exists for the last filter pair, *.* is added.
        //' This code will ignore any empty strings, i.e. "||" pairs.
        //' Returns "" if the strings passed in is empty.
        //
        //    Dim strFilter As String
        //    Dim intNum As Long, intPos As Long, intLastPos As Long
        //
        //    strFilter = ""
        //    intNum = 0
        //    intPos = 1
        //    intLastPos = 1
        //
        //    ' Add strings as long as we find bars.
        //    ' Ignore any empty strings (not allowed).
        //    Do
        //        intPos = InStr(intLastPos, strFilterIn, "|")
        //        If (intPos > intLastPos) Then
        //            strFilter = strFilter & mid$(strFilterIn, intLastPos, intPos - intLastPos) & vbNullChar
        //            intNum = intNum + 1
        //            intLastPos = intPos + 1
        //        ElseIf (intPos = intLastPos) Then
        //            intLastPos = intPos + 1
        //        End If
        //    Loop Until (intPos = 0)
        //
        //    ' Get last string if it exists (assuming strFilterIn was not bar terminated).
        //    intPos = Len(strFilterIn)
        //    If (intPos >= intLastPos) Then
        //        strFilter = strFilter & mid$(strFilterIn, intLastPos, intPos - intLastPos + 1) & vbNullChar
        //        intNum = intNum + 1
        //    End If
        //
        //    ' Add *.* if there's no extension for the last string.
        //    If intNum Mod 2 = 1 Then
        //        strFilter = strFilter & "*.*" & vbNullChar
        //    End If
        //
        //    ' Add terminating NULL if we have any filter.
        //    If strFilter <> "" Then
        //        strFilter = strFilter & vbNullChar
        //    End If
        //
        //    MSA_ConvertFilterString = strFilter
        //End Function
        //
        //
        //Public Function MSA_GetOpenFileName(msaof As MSA_OPENFILENAME) As Long
        //' Opens the file open dialog.
        //
        //    Dim of As OPENFILENAME
        //    Dim intRet As Long
        //
        //    MSAOF_to_OF msaof, of
        //    intRet = GetOpenFileName(of)
        //    If intRet Then
        //        OF_to_MSAOF of, msaof
        //    End If
        //    MSA_GetOpenFileName = intRet
        //End Function

        //Function MSA_SimpleGetOpenFileName() As String
        //' Opens the file open dialog with default values.
        //
        //    Dim msaof As MSA_OPENFILENAME
        //    Dim intRet As Long
        //    Dim strRet As String
        //
        //    intRet = MSA_GetOpenFileName(msaof)
        //    If intRet Then
        //        strRet = msaof.strFullPathReturned
        //    End If
        //
        //    MSA_SimpleGetOpenFileName = strRet
        //End Function

        //Private Sub OF_to_MSAOF(of As OPENFILENAME, msaof As MSA_OPENFILENAME)
        //' This sub converts from the win32 structure to the friendly MSAccess structure.
        //
        //    msaof.strFullPathReturned = Left$(of.lpstrFile, InStr(of.lpstrFile, vbNullChar) - 1)
        //    msaof.strFileNameReturned = of.lpstrFileTitle
        //    msaof.intFileOffset = of.nFileOffset
        //    msaof.intFileExtension = of.nFileExtension
        //End Sub


        //Private Sub MSAOF_to_OF(msaof As MSA_OPENFILENAME, of As OPENFILENAME)
        //' This sub converts from the friendly MSAccess structure to the win32 structure.
        //
        //    Dim strFile As String * 512
        //
        //    ' Initialize some parts of the structure.
        //    of.hWndOwner = Application.hWndAccessApp
        //    of.hInstance = 0
        //    of.lpstrCustomFilter = 0
        //    of.nMaxCustrFilter = 0
        //    of.lpfnHook = 0
        //    of.lpTemplateName = 0
        //    of.lCustrData = 0
        //
        //    If msaof.strFilter = "" Then
        //        of.lpstrFilter = MSA_CreateFilterString(ALLFILES)
        //    Else
        //        of.lpstrFilter = msaof.strFilter
        //    End If
        //    of.nFilterIndex = msaof.lngFilterIndex
        //
        //    of.lpstrFile = msaof.strInitialFile & String$(512 - Len(msaof.strInitialFile), 0)
        //    of.nMaxFile = 511
        //
        //    of.lpstrFileTitle = String$(512, 0)
        //    of.nMaxFileTitle = 511
        //
        //    of.lpstrTitle = msaof.strDialogTitle
        //
        //    of.lpstrInitialDir = msaof.strInitialDir
        //
        //    of.lpstrDefExt = msaof.strDefaultExtension
        //
        //    of.flags = msaof.lngFlags
        //
        //    of.lStructSize = Len(of)
        //End Sub
        //


        //
        //Public Sub ImportMeasureRecsTimingTest(MeasureSetID As Long, ByVal PeriodStart As Date, ByVal PeriodEnd As Date, ByVal PeriodType As String)
        //'SH variables used
        //    Dim msaof As MSA_OPENFILENAME
        //    Dim li_cnt As Long
        //    Dim fileSystem As New scripting.FileSystemObject
        //    Dim file As scripting.TextStream
        //    Dim ls_line() As String
        //    Dim ls_type As String
        //    Dim ls_data() As String
        //    Dim li_field, li_VerifyID As Long
        //    Dim ls_fields As String
        //    Dim li_VRMID As Long
        //    Dim rs_MeasureData As rdoResultset
        //    Dim li_MaxFields As Long
        //    Dim lb_move As Boolean
        //    Dim ls_values, ls_insert As String
        //    Dim destdrive, FileName As String
        //    Dim OtherFieldNm() As String
        //    Dim rs_Temp As rdoResultset
        //    Dim ls_Period As String
        //    Dim ps As rdoPreparedStatement
        //
        //'-search for the text filename
        //'-import into a temp table
        //'-validate data
        //'-define the measure period for each record
        //'-create a master record for each one
        //'-add all of the field values for each master record
        //
        //    On Error GoTo ErrHandler
        //
        //    'clear errors for correct error display
        //    ClearErrors
        //
        //
        //    'determine if the measure set selected contains risk adjusted measures
        //    gv_sql = "SELECT SUM(ISNULL(RiskAdjusted,0)) as Risk FROM tbl_Setup_Indicator I, tbl_Setup_MeasureSet mS, tbl_Setup_MeasureSetMapMeas MMS " & _
        //'        " Where ms.MeasureSetID = mms.MeasureSetID And mms.IndicatorID = i.IndicatorID And ms.MeasureSetID = " & MeasureSetID
        //
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //    If Not gv_rs.EOF Then
        //        If gv_rs!Risk > 0 Then
        //            If MsgBox("Please choose Yes to Accept the Default Coefficents to use as " & PeriodStart & ".", vbYesNo, "Risk Coefficient Start Date") = vbYes Then
        //                id_CoefPeriod = PeriodStart
        //            Else
        //                ls_Period = InputBox("Please enter the risk adjusted period start date (MM/YYYY).", "Enter Risk Adjusted Coefficient Start Date")
        //                If IsDate(ls_Period) Then
        //                    If Month(ls_Period) = 1 Or Month(ls_Period) = 4 Or Month(ls_Period) = 7 Or Month(ls_Period) = 10 Then
        //                        id_CoefPeriod = Month(ls_Period) & "/1/" & Year(ls_Period)
        //                    End If
        //                Else
        //                    MsgBox "Coefficient Period Start is not a valid date"
        //                    Exit Sub
        //                End If
        //            End If
        //
        //        End If
        //    End If
        //    gv_rs.Close
        //
        //    ' Set options for the dialog box.
        //    'msaof.strDialogTitle = "File Name To Import?"
        //    'msaof.strInitialDir = destdrive
        //    'msaof.strFilter = MSA_CreateFilterString("Csv (*.csv)", "*.csv")
        //
        //    ' Call the Open File dialog routine.
        //    'MSA_GetOpenFileName msaof
        //
        //    ' Return the path and file name.
        //    'filename = Trim(msaof.strFullPathReturned)
        //
        //    'If IsNull(filename) Or filename = "" Then
        //
        //   '     MsgBox "No File Selected. No Records Was Imported."
        //   '     Exit Sub
        //    frmFindAFile.Caption = "Specify the source file"
        //    frmFindAFile.Show 1
        //    If gv_SelectedFileName = "" Then
        //        'strError = "Sorry, you must locate the sample file to run the process."
        //       MsgBox "Verification Process Will Not Continue, Because the Sample File Was Not Located Correctly."
        //       Screen.MousePointer = 0
        //       Exit Sub
        //    Else
        //        FileName = gv_SelectedDirectory & "\" & gv_SelectedFileName
        //        'GET ALL THE FIELDS LINKED TO THIS MEASURE SET
        //        gv_sql = "SELECT dd.DDID, BaseTableID, FieldName, FieldType, FieldSize " & _
        //'                " FROM tbl_Setup_FieldMeasureSet fm, tbl_Setup_DataDef dd " & _
        //'                " WHERE dd.DDID = fm.DDID and fm.MeasureSetID = " & MeasureSetID & " ORDER BY OrderID ASC"
        //
        //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //        li_cnt = 0
        //        If gv_rs.EOF Then
        //            MsgBox "No Fields have been linked to this measure set!", vbCritical, "No Fields for Measure Set"
        //            Exit Sub
        //        End If
        //        gv_rs.MoveLast
        //        frmVerifyTimingTest.lblStatus = "Importing the Cases into the Database"
        //        li_MaxFields = gv_rs.RowCount
        //
        //        gv_rs.MoveFirst
        //
        //        ReDim OtherFieldNm(0)
        //        ReDim LinkedFields(0)
        //
        //        'gv_cn.Execute "if exists (select * from dbo.sysobjects where id = object_id(N'[tbl_MeasureData]')" & _
        //'        '    " and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [tbl_MeasureData]"
        //
        //        'gv_cn.Execute "if exists (select * from dbo.sysobjects where id = object_id(N'[tmp_MeasureData]')" & _
        //'        '    " and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [tmp_MeasureData]"
        //
        //        'Dim ls_CreateTable As String
        //
        //
        //        'CREATE TEMP TABLE BASED ON LINKEDFIELDS
        //        'ls_CreateTable = "CREATE TABLE dbo.tbl_MeasureData ([VRMID] [int] , "
        //
        //        'gv_sql = " tmp_MeasureData"
        //
        //        ls_fields = ""
        //
        //        ls_fields = ""
        //        For li_cnt = 0 To li_MaxFields + 3
        //            ReDim Preserve LinkedFields(li_cnt)
        //
        //            'apply static fields as well as defined fields
        //            If li_cnt = 0 Then
        //                LinkedFields(li_cnt).DDID = "HCOID"
        //                LinkedFields(li_cnt).FieldName = "HCOID"
        //                LinkedFields(li_cnt).FieldType = "Number"
        //                lb_move = False
        //            ElseIf li_cnt = 1 Then
        //                LinkedFields(li_cnt).DDID = "CaseID"
        //                LinkedFields(li_cnt).FieldName = "CaseID"
        //                LinkedFields(li_cnt).FieldType = "Number"
        //                lb_move = False
        //            ElseIf li_cnt = li_MaxFields + 2 Then
        //                LinkedFields(li_cnt).DDID = "PMSI"
        //                LinkedFields(li_cnt).FieldName = "PMSI"
        //                LinkedFields(li_cnt).FieldType = "Text"
        //                LinkedFields(li_cnt).FieldSize = 7
        //                lb_move = False
        //            ElseIf li_cnt = li_MaxFields + 3 Then
        //                LinkedFields(li_cnt).DDID = "BatchNo"
        //                LinkedFields(li_cnt).FieldName = "BatchNo"
        //                LinkedFields(li_cnt).FieldType = "Number"
        //                lb_move = False
        //            Else
        //                LinkedFields(li_cnt).DDID = gv_rs!DDID
        //                LinkedFields(li_cnt).basetableid = gv_rs!basetableid
        //                LinkedFields(li_cnt).FieldName = gv_rs!FieldName
        //                LinkedFields(li_cnt).FieldType = gv_rs!FieldType
        //                'nz(gv_rs!FieldSize)
        //                LinkedFields(li_cnt).FieldSize = IIf(IsNull(gv_rs!FieldSize), "", gv_rs!FieldSize)
        //                lb_move = True
        //            End If
        //            ReDim Preserve OtherFieldNm(li_cnt)
        //            OtherFieldNm(li_cnt) = "F" & li_cnt + 1
        //
        //            Select Case LinkedFields(li_cnt).FieldType
        //                Case "Date", "Time"
        //                    ls_type = "datetime"
        //                Case "Number"
        //                    ls_type = "int"
        //                Case "Text"
        //                    ls_type = "varchar (" & LinkedFields(li_cnt).FieldSize & ")"
        //            End Select
        //
        //            If li_cnt = 0 Then
        //                'use static field name
        //                gv_sql = OtherFieldNm(li_cnt) & " " & ls_type
        //            Else
        //                gv_sql = gv_sql & ", " & OtherFieldNm(li_cnt) & " " & ls_type
        //            End If
        //
        //            If lb_move Then gv_rs.MoveNext
        //        Next
        //
        //        gv_rs.Close
        //
        //        gv_sql = gv_sql & ")"
        //
        //
        //
        //        'gv_cn.Execute ls_CreateTable & gv_sql
        //
        //
        //        'ls_CreateTable = "CREATE TABLE tmp_MeasureData ([VRMID] [int] NOT NULL , "
        //        'gv_cn.Execute ls_CreateTable & gv_sql
        //
        //        ls_values = Join(OtherFieldNm, ",")
        //
        //
        //        Set file = fileSystem.OpenTextFile(FileName, _
        //'          scripting.IOMode.ForReading, False, _
        //'          scripting.Tristate.TristateUseDefault)
        //
        //        li_cnt = 0
        //        'minimize the time the file is open, read one line at a time
        //        Do While Not file.AtEndOfStream
        //            ReDim Preserve ls_line(li_cnt)
        //            ls_line(li_cnt) = file.ReadLine()
        //            li_cnt = li_cnt + 1
        //        Loop
        //        file.Close
        //
        //        If ls_line(UBound(ls_line)) = "" Then
        //            MsgBox "No lines found in the file", vbCritical, "No records found in csv file"
        //            Exit Sub
        //        End If
        //
        //        frmVerifyTimingTest.pgStatus.Max = (UBound(ls_line) + 1) * 5
        //
        //        gv_sql = "SELECT VerifyID FROM tbl_VerifyRecs WHERE " & _
        //'            " PERIOD_START_DATE = convert(datetime, '" & PeriodStart & " ',121)" & _
        //'            " AND PERIOD_END_DATE = convert(datetime, '" & PeriodEnd & "',121) AND " & _
        //'            " MeasureSetID = " & MeasureSetID
        //        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
        //        Do While Not gv_rs.EOF
        //            gv_cn.Execute "DELETE FROM tbl_VerifyRecMaster WHERE VerifyID = " & gv_rs!VerifyID
        //            gv_cn.Execute "DELETE FROM tbl_VerifyRecDetail WHERE VerifyID = " & gv_rs!VerifyID
        //            gv_cn.Execute "DELETE FROM tbl_EOCResults WHERE VerifyID = " & gv_rs!VerifyID
        //            gv_cn.Execute "DELETE FROM tbl_HCOResults WHERE VerifyID = " & gv_rs!VerifyID
        //            gv_rs.Delete
        //
        //            gv_rs.MoveNext
        //        Loop
        //        gv_rs.Close
        //
        //
        //        'DATA SHOULD BE PERMANENTLY STORED
        //        'get verifyid
        //        gv_sql = "INSERT INTO tbl_VerifyRecs (PERIOD_START_DATE, PERIOD_END_DATE, MeasureSetID) " & _
        //'            " VALUES (convert(datetime, '" & PeriodStart & "',121), convert(datetime, '" & PeriodEnd & "',121)," & MeasureSetID & ")"
        //
        //        gv_cn.Execute gv_sql
        //        li_VerifyID = GetLastID("tbl_VerifyRecs")
        //
        //        'delete data for testing purposes
        //        'gv_sql = "DELETE FROM tbl_VerifyRecMaster"
        //        'gv_cn.Execute gv_sql
        //        'gv_sql = "DELETE FROM tbl_VerifyRecDetail"
        //        'gv_cn.Execute gv_sql
        //
        //        DoEvents
        //
        //        'gv_sql = "DELETE FROM tbl_MeasureData"
        //        'gv_cn.Execute gv_sql
        //
        //
        //
        //        For li_cnt = 0 To UBound(ls_line)
        //            ls_data = Split(ls_line(li_cnt), ",")
        //            frmVerifyTimingTest.lblStatus = "Importing Case " & li_cnt + 1 & " of " & UBound(ls_line) + 1
        //
        //            If UBound(ls_data) <> UBound(LinkedFields) Then
        //                'MsgBox "The file and the mapped fields do not match", vbCritical, "Number of Fields Discrepancy"
        //                'Exit Sub
        //
        //                'just redim the array to match the number of values, the bottom code will replace values with nulls
        //                ReDim Preserve ls_data(UBound(LinkedFields))
        //            End If
        //
        //
        //            'create master verify record id
        //            gv_sql = "INSERT INTO tbl_VerifyRecMaster (VERIFYRECNO, VERIFYID) VALUES " & _
        //'                            "(" & li_cnt & "," & li_VerifyID & ")"
        //            gv_cn.Execute gv_sql
        //            li_VRMID = GetLastID("tbl_VerifyRecMaster")
        //
        //            For li_field = 0 To UBound(ls_data)
        //                'check data type, length, if anything doesn't match make the value NULL (for invalid data)
        //                If LinkedFields(li_field).FieldType = "Text" And Len(Trim(ls_data(li_field))) > 0 Then
        //                    If LinkedFields(li_field).FieldSize < Len(ls_data(li_field)) Then
        //                        'too big a text field
        //                        ls_data(li_field) = "NULL"
        //                    Else
        //                        ls_data(li_field) = " ltrim('" & ls_data(li_field) & "')"
        //                    End If
        //                ElseIf (LinkedFields(li_field).FieldType = "Date" Or LinkedFields(li_field).FieldType = "Time") And _
        //'                    Len(Trim(ls_data(li_field))) > 0 Then
        //                     If IsDate(ls_data(li_field)) Then
        //                        ls_data(li_field) = "'" & ls_data(li_field) & "'"
        //                     Else
        //                        ls_data(li_field) = "NULL"
        //
        //                     End If
        //                ElseIf LinkedFields(li_field).FieldType = "Number" And Len(Trim(ls_data(li_field))) > 0 Then
        //                    If Not IsNumeric(ls_data(li_field)) Then
        //                        ls_data(li_field) = "NULL"
        //                    End If
        //                Else
        //                    If Len(Trim(ls_data(li_field))) = 0 Then ls_data(li_field) = "NULL"
        //                End If
        //
        //                '6.22.05 - do not run this costly query
        //                'gv_sql = "SELECT * FROM tbl_VerifyRecDetail  "
        //                'gv_sql = gv_sql & " where VRMID = " & li_VRMID
        //                'gv_sql = gv_sql & "  AND DDID = '" & LinkedFields(li_field).DDID & "'"
        //                'gv_g = InputBox("", "", gv_sql)
        //                'Set rs_Temp = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
        //
        //                'If rs_Temp.RowCount = 0 Then
        //                    'insert the field into the detail table
        //                    gv_sql = "INSERT INTO tbl_VerifyRecDetail (DDID, VRMID, VERIFYID, FIELDVALUE) VALUES "
        //                    gv_sql = gv_sql & "('" & LinkedFields(li_field).DDID & "'," & li_VRMID & "," & li_VerifyID & "," & ls_data(li_field) & ")"
        //                    'gv_g = InputBox("", "", gv_sql)
        //                    gv_cn.Execute gv_sql
        //                'End If
        //                'rs_Temp.Close
        //
        //            Next
        //
        //
        //           ' gv_sql = "INSERT INTO tbl_MeasureData (VRMID," & ls_values & ") VALUES (" & li_VRMID & "," & Join(ls_data, ",") & ")"
        //
        //            'Open "C:\iha\test.sql" For Output As #1
        //            'Print #1, gv_sql
        //            'Close #1
        //
        //           ' gv_cn.Execute gv_sql
        //
        //            frmVerifyTimingTest.pgStatus.Value = li_cnt
        //            DoEvents
        //
        //        Next
        //
        //    End If
        //
        //    'remove the leading spaces from the text fields
        //    gv_sql = "update tbl_VerifyRecDetail "
        //    gv_sql = gv_sql & " set fieldvalue = ltrim(fieldvalue) "
        //    gv_sql = gv_sql & " from tbl_VerifyRecDetail inner join tbl_setup_datadef "
        //    gv_sql = gv_sql & " on tbl_VerifyRecDetail.ddid = tbl_setup_datadef.ddid "
        //    gv_sql = gv_sql & " where upper(fieldtype) = 'TEXT' "
        //    gv_sql = gv_sql & " and isnumeric(tbl_VerifyRecDetail.ddid) = 1 "
        //    gv_sql = gv_sql & " and fieldvalue is not null "
        //    gv_sql = gv_sql & " and verifyid = " & li_VerifyID
        //    gv_cn.Execute gv_sql
        //
        //Exit Sub
        //
        ////LDW ErrHandler:
        //    Screen.MousePointer = vbDefault
        //    CheckForErrors
        //End Sub
        //
        //
        //Public Function VerifyPatRecsTimingTest(ByVal MeasureSetID As Long, StartDate As Date, EndDate As Date, RandomNumber As Long) As String
        //
        //Dim VerifyID As Long
        //Dim ps As rdoPreparedStatement
        //Dim rs_Temp As rdoResultset
        //Dim ls_line As String
        //Dim hFile As Integer
        //Dim li_LastRandom As Long
        //Dim li_RoundCount As Long
        //Dim li_ROunds As Long
        //
        //ClearErrors
        //hFile% = FreeFile
        //
        //On Error Resume Next
        //Kill App.Path & "\Timings.txt"
        //On Error GoTo ErrHandler
        //li_LastRandom = 0
        //li_RoundCount = 1
        //Open App.Path & "\Timings.txt" For Output As hFile%
        //
        //'random 400, 800, 1000, 1400, 1600, 1800, 2000, 2200, 2400, 2600, 2800, 3000, 3200, 3400, 3600
        //'Do While RandomNumber <= 1148
        //
        //'RandomNumber = 400
        //
        //If RandomNumber = 0 Then RandomNumber = 3600
        //
        //Do While RandomNumber <= 3600
        //
        //
        //    'measuresetid = 999 is default for the imported patient records
        //    gv_sql = "SELECT VerifyID FROM tbl_VerifyRecs WHERE " & _
        //'        " PERIOD_START_DATE = convert(datetime, '" & StartDate & " ',121)" & _
        //'        " AND PERIOD_END_DATE = convert(datetime, '" & EndDate & "',121) AND " & _
        //'        " MeasureSetID = " & MeasureSetID
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
        //    If Not gv_rs.EOF Then
        //        VerifyID = gv_rs!VerifyID
        //    Else
        //        MsgBox "There are no records loaded for the selected period"
        //        Exit Function
        //    End If
        //    gv_rs.Close
        //
        //    If RandomNumber > 0 Then
        //        gv_sql = "{ ? = call GenerateRandomSample(?,?) }"
        //        Set ps = gv_cn.CreatePreparedStatement("", gv_sql)
        //        ps(0).Direction = rdParamReturnValue
        //        ps(1).Direction = rdParamInput
        //        ps(2).Direction = rdParamInput
        //        ps.rdoParameters(1) = RandomNumber
        //        ps.rdoParameters(2) = VerifyID
        //        ps.Execute
        //        ps.Close
        //
        //    End If
        //
        //    ls_line = "START " & RandomNumber & ", " & Now() & ", Round " & li_RoundCount
        //    Print #hFile, ls_line
        //
        //
        //    gv_sql = "{ ? = call ProcessSQLTimingTest(?,?,?) }"
        //    Set ps = gv_cn.CreatePreparedStatement("", gv_sql)
        //    ps(0).Direction = rdParamReturnValue
        //    ps(1).Direction = rdParamInput
        //    ps(2).Direction = rdParamInput
        //    ps(3).Direction = rdParamInput
        //    ps.rdoParameters(1) = MeasureSetID
        //    ps.rdoParameters(2) = VerifyID
        //    ps.rdoParameters(3) = RandomNumber
        //    ps.Execute
        //    ps.Close
        //
        //    ls_line = "END " & RandomNumber & ", " & Now() & ", Round " & li_RoundCount
        //    Print #hFile, ls_line
        //
        //    frmVerifyTimingTest.lblStatus = "Formatting Results"
        //
        //    'put the answers into the eoc result table
        //    gv_sql = "INSERT INTO tbl_EOCResults (VerifyID, PMI, CaseID, PMSI, BatchNo, CI_CAT, ProcessingStep) " & _
        //'        " SELECT " & VerifyID & ",PMI,CaseId,PMSI,BatchNo,CAT, ProcessingStep " & _
        //'        " FROM temp_VerifyResults WHERE CAT in (SELECT CAT FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'CI')"
        //    gv_cn.Execute gv_sql
        //
        //    gv_sql = "SELECT * FROM temp_VerifyResults WHERE CAT in (SELECT CAT FROM tbl_MEASURE_CAT WHERE CAT_TYPE = 'RA')"
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
        //    Do While Not gv_rs.EOF
        //        gv_sql = "SELECT * FROM tbl_EOCResults WHERE CaseID = " & gv_rs!CaseID & " AND PMI = " & gv_rs!PMI & _
        //'            " AND VerifyID = " & VerifyID
        //        Set rs_Temp = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdOpenStatic)
        //        If rs_Temp.EOF Then
        //            'gv_g = InputBox("", "", gv_sql)
        //            'If Trim(rs_Temp!ci_cat) = "D" Or Trim(rs_Temp!ci_cat) = "E" Then
        //            '    rs_Temp.AddNew
        //            '    rs_Temp!VerifyID = VerifyID
        //            '    rs_Temp!PMI = gv_rs!PMI
        //            '    rs_Temp!CaseID = gv_rs!CaseID
        //            '    rs_Temp!PMSI = gv_rs!PMSI
        //            '    rs_Temp!BatchNo = gv_rs!BatchNo
        //            '    rs_Temp!RA_CAT = gv_rs!CAT
        //            '    rs_Temp.Update
        //            'End If
        //        Else
        //            If Trim(rs_Temp!ci_cat) = "D" Or Trim(rs_Temp!ci_cat) = "E" Then
        //                rs_Temp.Edit
        //                rs_Temp!RA_CAT = gv_rs!CAT
        //                rs_Temp.Update
        //            End If
        //        End If
        //        rs_Temp.Close
        //        gv_rs.MoveNext
        //    Loop
        //    gv_rs.Close
        //
        //
        //
        //    gv_sql = "SELECT PMI, CaseID, RTRIM(CI_CAT) as CI_CAT, RTRIM(RA_CAT) as RA_CAT, MeasVal," & _
        //'    " RiskAdjRate, RiskAdjVal, IsNull(PMSI,'') AS PMSI, BatchNo" & _
        //'    " FROM tbl_EOCResults WHERE VerifyID = " & VerifyID & " ORDER BY CaseID, PMI"
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //
        //    On Error Resume Next
        //    Kill App.Path & "\EOC_Answers.csv"
        //    On Error GoTo ErrHandler
        //
        //    'Dim ls_line As String
        //    'Dim hFile As integer
        //    hFile% = FreeFile
        //    Open App.Path & "\EOC_Answers.csv" For Output As hFile%
        //    Do While Not gv_rs.EOF
        //        ls_line = Trim(gv_rs!PMI) & "," & Trim(gv_rs!CaseID) & "," & Trim(gv_rs!ci_cat) & "," & Trim(gv_rs!RA_CAT) & "," & _
        //'            Trim(gv_rs!MeasVal) & "," & Trim(gv_rs!RiskAdjRate) & "," & Trim(gv_rs!RiskAdjVal) & "," & Trim(gv_rs.rdoColumns(7)) & "," & Trim(gv_rs!BatchNo)
        //        Print #hFile, ls_line
        //    gv_rs.MoveNext
        //    Loop
        //    gv_rs.Close
        //    Close hFile%
        //
        //
        //
        //    'If RandomNumber < 587 Then
        //        li_ROunds = 1
        //    'End If
        //
        //    'If RandomNumber = li_LastRandom Then
        //    '    li_RoundCount = li_RoundCount + 1
        //    '
        //    '    If li_RoundCount >= li_ROunds Then
        //    '        RandomNumber = RandomNumber + 10
        //    '        li_RoundCount = 1
        //    '    End If
        //
        //        'li_LastRandom = RandomNumber
        //    'End If
        //
        //    'random 400, 800, 1000, 1400, 1600, 1800, 2000, 2200, 2400, 2600, 2800, 3000, 3200, 3400, 3600
        //    If RandomNumber = 400 Then
        //        RandomNumber = 800
        //    ElseIf RandomNumber = 800 Then
        //        RandomNumber = 1000
        //    ElseIf RandomNumber = 1000 Then
        //        RandomNumber = 1400
        //    ElseIf RandomNumber > 1000 Then
        //        RandomNumber = RandomNumber + 200
        //    End If
        //
        //Loop
        //
        //'
        //'    ' Remove all the Related Group Logic for any previous measure
        //'
        //'
        //'                    'this means that there is saved group logic which needs to run
        //'                    If Not IsNull(rs_MeasureCriteria!measurefieldgrouplogicid) Or StepConditions(li_StepCnt).HasGroupLogic Then
        //'
        //'                        StepConditions(li_StepCnt).HasGroupLogic = True
        //'
        //'                        If lb_MeasureHasGroup = False Then
        //'                                gv_sql = "INSERT INTO tbl_temp_TempDetailData (VRMID, DDID, FieldValue) SELECT DISTINCT VRMID, DDID, FieldValue FROM tbl_VerifyRecDetail WHERE VerifyID = " & VerifyID & " AND IsNumeric(DDID) = 1"
        //'                                gv_cn.Execute gv_sql
        //'
        //'                                gv_sql = "Update tbl_temp_TempDetailData SET FieldValue = '' WHERE fieldvalue is null"
        //'                                gv_cn.Execute gv_sql
        //'
        //'                                gv_sql = "Update tbl_temp_TempDetailData SET FieldValue = RTRIM(FieldValue)"
        //'                                gv_cn.Execute gv_sql
        //'                                DoEvents
        //'
        //'                                If rs_Measures!JCAHOID = 14449 Or rs_Measures!JCAHOID = 14450 Then
        //'
        //'                                    gv_sql = " SELECT VRMID, COUNT(DDID) AS ValidNames From vuVerifyValidAntibioticNames GROUP BY VRMID"
        //'
        //'
        //'                                    Set rs_Impute = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //'                                    Do While Not rs_Impute.EOF
        //'
        //'                                        ' only fill in the times where some of the times are missing from the valid names, but not all of them
        //'                                        gv_sql = " SELECT vu.VRMID, count(DISTINCT related.DDID ) as CntNullTimes "
        //'                                        gv_sql = gv_sql & " FROM vuVerifyValidAntibioticNames vu, tbl_Setup_DDIDRelatedFieldGroup related, tbl_temp_tempDetailData dat, tbl_Setup_DDIDFieldGroup grp"
        //'                                        gv_sql = gv_sql & "  Where related.RelatedFieldGroupID = vu.RelatedFieldGroupID"
        //'                                        gv_sql = gv_sql & "  AND dat.DDID = related.DDID"
        //'                                        gv_sql = gv_sql & " AND FieldGroupID = 3"
        //'                                        gv_sql = gv_sql & " AND vu.VRMID = dat.VRMID"
        //'                                        gv_sql = gv_sql & " AND vu.VRMID = " & rs_Impute!VRMID
        //'                                        gv_sql = gv_sql & " AND FieldValue = '' AND grp.DDID = dat.DDID"
        //'                                        gv_sql = gv_sql & "  GROUP BY vu.VRMID HAVING count(DISTINCT related.DDID ) <> " & rs_Impute!ValidNames
        //'
        //'                                        'Debug.Print gv_sql
        //'                                        Set rs_Impute2 = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //'                                        If Not rs_Impute2.EOF Then
        //'                                            'only fill in the time if the date is also filled in for these names and the date is the same as the arrival date
        //'
        //'                                            'where the valid antibiotic dates are = arrival date
        //'                                            gv_sql = " SELECT DISTINCT vu.VRMID, related.DDID, fieldvalue"
        //'                                            gv_sql = gv_sql & " FROM vuVerifyValidAntibioticNames vu, tbl_Setup_DDIDRelatedFieldGroup related, tbl_temp_tempDetailData dat, tbl_Setup_DDIDFieldGroup grp"
        //'                                            gv_sql = gv_sql & " Where related.RelatedFieldGroupID = vu.RelatedFieldGroupID"
        //'                                            gv_sql = gv_sql & " AND dat.DDID = related.DDID AND FieldGroupID = 4"
        //'                                            gv_sql = gv_sql & " AND vu.VRMID = dat.VRMID AND grp.DDID = dat.DDID"
        //'                                            gv_sql = gv_sql & " AND vu.VRMID = " & rs_Impute2!VRMID
        //'                                            gv_sql = gv_sql & " AND len(FieldValue) > 0 AND FieldValue = (SELECT FieldValue FROM tbl_temp_tempDetailData tmp WHERE DDID = 244 AND VRMID = " & rs_Impute2!VRMID & ") "
        //'
        //'
        //'                                            Set rs_Impute3 = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //'                                            Do While Not rs_Impute3.EOF
        //'
        //'                                                'set time where name and date are valid and all the times are NOT missing
        //'                                                gv_sql = "UPDATE tbl_temp_tempDetailData Set FieldValue = (SELECT IsNull(FieldValue, '') "
        //'                                                gv_sql = gv_sql & "   FROM tbl_temp_tempDetailData ARRIVAL where ARRIVAL.DDID = 289 AND ARRIVAL.VRMID = tbl_temp_tempDetailData.VRMID) "
        //'                                                gv_sql = gv_sql & " WHERE VRMID = " & rs_Impute2!VRMID & " AND EXISTS "
        //'                                                gv_sql = gv_sql & " (SELECT VRMID, dat.DDID, FieldValue from tbl_temp_TempDetailData dat, tbl_Setup_DDIDRelatedFieldGroup rel, tbl_Setup_DDIDFieldGroup grp "
        //'                                                gv_sql = gv_sql & " Where rel.DDID = dat.DDID And grp.DDID = dat.DDID"
        //'                                                gv_sql = gv_sql & " AND RelatedFieldGroupID in (SELECT RelatedFieldGroupID FROM tbl_Setup_DDIDRelatedFieldGroup WHERE DDID = " & rs_Impute3!DDID & ") "
        //'                                                gv_sql = gv_sql & " AND VRMID = tbl_temp_tempDetailData.VRMID "
        //'                                                gv_sql = gv_sql & " and grp.FieldGroupID = 3"
        //'                                                gv_sql = gv_sql & " and fieldvalue = '' AND dat.DDID = tbl_temp_tempDetailData.DDID)"
        //'
        //'                                                gv_cn.Execute gv_sql
        //'
        //'                                                rs_Impute3.MoveNext
        //'                                            Loop
        //'
        //'                                            rs_Impute3.Close
        //'                                            Set rs_Impute3 = Nothing
        //'
        //'
        //'                                        End If
        //'
        //'                                        rs_Impute2.Close
        //'                                        Set rs_Impute2 = Nothing
        //'
        //'                                        rs_Impute.MoveNext
        //'                                    Loop
        //'
        //'
        //'                                    rs_Impute.Close
        //'                                    Set rs_Impute = Nothing
        //'
        //'
        //'
        //'                                End If
        //'
        //'                        End If
        //'
        //'                        lb_MeasureHasGroup = True
        //'
        //'                        'this is where the group logic is processed
        ///                        gv_sql = "{ ? = call ProcessSavedGroupSQLCondition(?,?) }"
        ///                        Set ps = gv_cn.CreatePreparedStatement("", gv_sql)
        ///                        ps(0).Direction = rdParamReturnValue
        ///                        ps(1).Direction = rdParamInput
        ///                        ps(2).Direction = rdParamInput
        ///                        ps.rdoParameters(1) = rs_MeasureCriteria!MeasureCriteriaID
        ///                        ps.rdoParameters(2) = VerifyID
        ///                        ps.Execute
        ///                        ps.Close
        ///                        DoEvents
        //'
        //'                        gv_sql = "INSERT INTO tbl_temp_tTempPatRecCriteria (VRMID, " & _
        ///                            " MeasureCriteria, MeasureSet, Step) SELECT VRMID, " & _
        ///                            li_CritCount & ", " & rs_MeasureSet!MeasureCriteriaSet & ", " & _
        ///                            StepConditions(li_StepCnt).PStep & " FROM tbl_temp_tTempPatRecs WHERE IsSaved = 1 GROUP BY VRMID"
        //'                        gv_cn.Execute gv_sql
        //'
        //'                    Else
        //'
        //'            li_StepCnt = li_StepCnt + 1
        //'            rs_MeasureStep.MoveNext
        //'        Loop
        //'
        //'    End If
        //'
        //'    DoEvents
        //'
        //'
        //'    rs_Measures.MoveNext
        //'    frmVerifyTimingTest.pgStatus.Value = (li_MeasCnt / (li_MaxMeas * (li_StartVal / frmVerifyTimingTest.pgStatus.Max))) * li_StartVal
        //'
        //'Loop
        //
        //
        //Exit Function
        //
        ////LDW ErrHandler:
        //    CheckForErrors
        //
        //End Function
        //
        //
        //Public Function BuildSQLTimingTest(ByVal MeasureSetID As Long, StartDate As Date, EndDate As Date) As String
        //Dim rs_MeasureStep, rs_MeasureCriteria As rdoResultset
        //Dim rs_Measures As rdoResultset, rs_MeasureSet As rdoResultset, rs_Temp As rdoResultset, rs_IHARS As rdoResultset
        //Dim QCondition, FieldType, MainJOp, AllConditions As String
        //Dim DateFieldDDID1, DateFieldDDID2 As Long
        //Dim SetConditions As String
        //Dim li_StepCnt, li_MeasCnt, li_cnt As Long
        //Dim StepConditions() As CriteriaStep
        //Dim rs_VerifyRecs As rdoResultset
        //Dim StepCondition As String
        //Dim li_MaxMeas, li_StartVal As Long
        //Dim li_FieldLoc As Long
        //Dim li_SetCnt As Long
        //Dim ls_LastJoin As String
        //Dim ls_PrevCatType As String
        //Dim lb_FilterMeasure As Boolean
        //Dim rs_MeasGroup As rdoResultset
        //Dim ls_GroupJoin As String
        //Dim li_MaxGroup As Long, li_MaxSetinGroup As Long
        //Dim GroupCondition As String
        //Dim GroupSubCondition As String
        //Dim li_LastGroupNo As Long
        //Dim CaseElseVal
        //Dim CritCount As Long
        //Dim CheckForNull
        //Dim setJoinOp As String
        //Dim ExceptionMethod As Boolean
        //Dim li_CritCount As Long
        //Dim ps As rdoPreparedStatement
        //Dim rs_PatRecCrit As rdoResultset
        //Dim lb_MeasureHasGroup As Boolean
        //Dim rs_Impute As rdoResultset
        //Dim rs_Impute2 As rdoResultset
        //Dim rs_Impute3 As rdoResultset
        //Dim li_file As Long
        //Dim fso As FileSystemObject
        //Dim FileName As String
        //Dim hFile As Integer
        //Dim ls_line As String
        //Dim VerifyID As Long
        //Dim ls_FieldValue() As String
        //Dim rs_Method6 As rdoResultset
        //Dim li_fieldCnt, li_TimeLoc As Long
        //Dim ls_LookupLocs() As String
        //Dim ls_Sql As String, ls_SelField As String
        //Dim ls_sqlStmts() As String
        //Dim ls_join As String
        //Dim ls_FirstDate, ls_SecondDate As String
        //
        //ClearErrors
        //
        //On Error GoTo ErrHandler
        //
        //
        //gv_sql = "SELECT VerifyID FROM tbl_VerifyRecs WHERE " & _
        //'    " PERIOD_START_DATE = convert(datetime, '" & StartDate & " ',121)" & _
        //'    " AND PERIOD_END_DATE = convert(datetime, '" & EndDate & "',121) AND " & _
        //'    " MeasureSetID = " & MeasureSetID
        //Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenKeyset, rdConcurLock)
        //If Not gv_rs.EOF Then
        //    VerifyID = gv_rs!VerifyID
        //Else
        //    MsgBox "There are no records loaded for the selected period"
        //    Exit Function
        //End If
        //gv_rs.Close
        //
        //gv_sql = "{ ? = call CrosstabSampleRecordWithDDID(?,?) }"
        //Set ps = gv_cn.CreatePreparedStatement("", gv_sql)
        //ps(0).Direction = rdParamReturnValue
        //ps(1).Direction = rdParamInput
        //ps.rdoParameters(1) = VerifyID
        //ps.rdoParameters(2) = 0
        //ps.Execute
        //ps.Close
        //
        //
        //
        //'get measures (one at a time) and process each
        //gv_sql = "SELECT i.IndicatorID, i.Description, i.RiskAdjusted, JCAHOID FROM " & _
        //'    " tbl_Setup_MeasureSetMapMeas mmm, tbl_Setup_Indicator i WHERE mmm.IndicatorID = i.IndicatorID AND " & _
        //'    " mmm.MeasureSetID = " & MeasureSetID & " ORDER BY i.INDICATORID"
        //
        //Set rs_Measures = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //If rs_Measures.EOF Then Exit Function
        //
        //li_MaxMeas = rs_Measures.RowCount
        //li_StartVal = frmVerifyTimingTest.pgStatus.Value
        //If li_StartVal = 0 Then li_StartVal = 1
        //li_MeasCnt = 0
        //
        //Do While Not rs_Measures.EOF
        //    li_MeasCnt = li_MeasCnt + 1
        //    ls_PrevCatType = ""
        //    lb_MeasureHasGroup = False
        //
        //    thisindicatorid = rs_Measures!IndicatorID
        //    gv_cn.Execute "Delete from tbl_StepConditions WHERE IndicatorID = " & thisindicatorid & " AND VersionNumber = (SELECT VersionNumber FROM tbl_Setup_Version)"
        //
        //    frmVerifyTimingTest.lblStatus = "Building SQL FOR " & rs_Measures!JCAHOID
        //    DoEvents
        //
        //    'order by cat (assuming categories are NULL (for filter) a, b, c, d, e, f, g)
        //    'Process one step at a time
        //    gv_sql = "SELECT MeasureStepID, MeasureStep, CAT, CAT_TYPE, GoToStep, IsRisk "
        //    gv_sql = gv_sql & " FROM tbl_Setup_MeasureStep ms "
        //    gv_sql = gv_sql & " left join tbl_Measure_Cat mc "
        //    gv_sql = gv_sql & " on mc.Measure_CATID = ms.Measure_CATID "
        //    gv_sql = gv_sql & " WHERE MeasureID = " & rs_Measures!IndicatorID
        //    gv_sql = gv_sql & " AND MeasureStep > 0 "
        //    gv_sql = gv_sql & " ORDER BY MeasureStep ASC "
        //
        //    Set rs_MeasureStep = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //
        //    If Not rs_MeasureStep.EOF Then
        //        li_StepCnt = 0
        //        ReDim StepConditions(li_StepCnt)
        //
        //        'If this step has a gotostep field value, if the condition is true, the loop has to proceed to the defined step number
        //        ' without going over the middle steps
        //
        //        Do While Not rs_MeasureStep.EOF
        //            ReDim Preserve StepConditions(li_StepCnt)
        //            StepConditions(li_StepCnt).HasGroupLogic = False
        //            StepConditions(li_StepCnt).PStep = rs_MeasureStep!measurestep
        //
        //            gv_sql = "SELECT mcs.*, msg.JoinOperator as GroupJoin, msg.MeasureStepGroup FROM tbl_Setup_MeasureStepGroup msg, tbl_Setup_MeasureCriteriaSet mcs" & _
        //'                " WHERE msg.MeasureStepID = " & rs_MeasureStep!MeasureStepID & _
        //'                " AND msg.MeasureStepID = mcs.MeasureStepID " & _
        //'                " AND msg.MeasureCriteriaSetID = mcs.MeasureCriteriaSetID " & _
        //'                " ORDER BY msg.MeasureStepGroup, mcs.MeasureCriteriaSet ASC"
        //
        //            Set rs_MeasureSet = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //            If Not rs_MeasureSet.EOF Then
        //                'Set rs_MeasureSet = rs_MeasGroup
        //                'rs_MeasGroup.Close
        //                ls_GroupJoin = rs_MeasureSet!GroupJoin
        //
        //            Else
        //                rs_MeasureSet.Close
        //
        //                ls_GroupJoin = ""
        //             'find and place them in a set of parenthesis
        //                gv_sql = "SELECT * FROM tbl_Setup_MeasureCriteriaSet WHERE " & _
        //'                " MeasureStepID = " & rs_MeasureStep!MeasureStepID & " ORDER BY MeasureCriteriaSet ASC"
        //
        //                Set rs_MeasureSet = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //            End If
        //
        //            StepCondition = ""
        //            GroupCondition = ""
        //            GroupSubCondition = ""
        //            li_LastGroupNo = 0
        //
        //
        //            If rs_MeasureSet.EOF Then GoTo ErrHandler
        //
        //            'MainJOp = Nz(Trim(UCase(rs_MeasureSet!JoinOperator)) & "   ", "AND   ")
        //            If IsNull(rs_MeasureSet!JoinOperator) Then
        //                MainJOp = "AND   "
        //            Else
        //                MainJOp = Trim(UCase(rs_MeasureSet!JoinOperator)) & "   "
        //            End If
        //
        //            Do While Not rs_MeasureSet.EOF
        //
        //                thisset = rs_MeasureSet!MeasureCriteriaSet
        //                thisstep = rs_MeasureStep!measurestep
        //                'It is important to select the proceed only with criteria before the regular criteria
        //                gv_sql = " SELECT tbl_Setup_MeasureCriteria.* "
        //                gv_sql = gv_sql & " FROM tbl_Setup_MeasureCriteria LEFT JOIN tbl_Setup_MeasureFieldGroupLogic ON tbl_Setup_MeasureCriteria.MeasureFieldGroupLogicID = tbl_Setup_MeasureFieldGroupLogic.MeasureFieldGroupLogicID "
        //                gv_sql = gv_sql & " WHERE (((tbl_Setup_MeasureCriteria.MeasureCriteriaSetID) = " & rs_MeasureSet!MeasureCriteriaSetID & ")) "
        //                gv_sql = gv_sql & " ORDER BY tbl_Setup_MeasureFieldGroupLogic.OnlyProceedWithRelatedFieldGroup DESC, tbl_Setup_MeasureFieldGroupLogic.MeasureFieldGroupLogicID DESC , tbl_Setup_MeasureCriteria.MeasureCriteriaID ASC"
        //
        //                Set rs_MeasureCriteria = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //                SetConditions = ""
        //                ls_LastJoin = ""
        //
        //                'SH 2.23.2005 movelast for rdo recordset to get right row count & added trim
        //                rs_MeasureCriteria.MoveLast
        //                If rs_MeasureCriteria.RowCount > 0 Then
        //                    rs_MeasureCriteria.MoveFirst
        //                    setJoinOp = Trim(rs_MeasureCriteria!JoinOperator)
        //                    CritCount = rs_MeasureCriteria.RowCount
        //                End If
        //
        //                li_CritCount = 0
        //
        //                Do While Not rs_MeasureCriteria.EOF
        //                    'METHOD 6 - to be handled differently than anything else
        //                    ExceptionMethod = False
        //                    li_CritCount = li_CritCount + 1
        //
        //
        //                    'this means that there is saved group logic which needs to run
        //                    If Not IsNull(rs_MeasureCriteria!measurefieldgrouplogicid) Or StepConditions(li_StepCnt).HasGroupLogic Then
        //
        //                        StepConditions(li_StepCnt).HasGroupLogic = True
        //'
        //'                        If lb_MeasureHasGroup = False Then
        //'                                gv_sql = "INSERT INTO tbl_temp_TempDetailData (VRMID, DDID, FieldValue) SELECT DISTINCT VRMID, DDID, FieldValue FROM tbl_VerifyRecDetail WHERE VerifyID = " & VerifyID & " AND IsNumeric(DDID) = 1"
        //'                                gv_cn.Execute gv_sql
        //'
        //'                                gv_sql = "Update tbl_temp_TempDetailData SET FieldValue = '' WHERE fieldvalue is null"
        //'                                gv_cn.Execute gv_sql
        //'
        //'                                gv_sql = "Update tbl_temp_TempDetailData SET FieldValue = RTRIM(FieldValue)"
        //'                                gv_cn.Execute gv_sql
        //'                                DoEvents
        //'
        //'                                If rs_Measures!JCAHOID = 14449 Or rs_Measures!JCAHOID = 14450 Then
        //'
        //'                                    gv_sql = " SELECT VRMID, COUNT(DDID) AS ValidNames From vuVerifyValidAntibioticNames GROUP BY VRMID"
        //'
        //'
        //'                                    Set rs_Impute = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //'                                    Do While Not rs_Impute.EOF
        //'
        //'                                        ' only fill in the times where some of the times are missing from the valid names, but not all of them
        //'                                        gv_sql = " SELECT vu.VRMID, count(DISTINCT related.DDID ) as CntNullTimes "
        //'                                        gv_sql = gv_sql & " FROM vuVerifyValidAntibioticNames vu, tbl_Setup_DDIDRelatedFieldGroup related, tbl_temp_tempDetailData dat, tbl_Setup_DDIDFieldGroup grp"
        //'                                        gv_sql = gv_sql & "  Where related.RelatedFieldGroupID = vu.RelatedFieldGroupID"
        //'                                        gv_sql = gv_sql & "  AND dat.DDID = related.DDID"
        //'                                        gv_sql = gv_sql & " AND FieldGroupID = 3"
        //'                                        gv_sql = gv_sql & " AND vu.VRMID = dat.VRMID"
        //'                                        gv_sql = gv_sql & " AND vu.VRMID = " & rs_Impute!VRMID
        //'                                        gv_sql = gv_sql & " AND FieldValue = '' AND grp.DDID = dat.DDID"
        //'                                        gv_sql = gv_sql & "  GROUP BY vu.VRMID HAVING count(DISTINCT related.DDID ) <> " & rs_Impute!ValidNames
        //'
        //'                                        'Debug.Print gv_sql
        //'                                        Set rs_Impute2 = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //'                                        If Not rs_Impute2.EOF Then
        //'                                            'only fill in the time if the date is also filled in for these names and the date is the same as the arrival date
        //'
        //'                                            'where the valid antibiotic dates are = arrival date
        //'                                            gv_sql = " SELECT DISTINCT vu.VRMID, related.DDID, fieldvalue"
        //'                                            gv_sql = gv_sql & " FROM vuVerifyValidAntibioticNames vu, tbl_Setup_DDIDRelatedFieldGroup related, tbl_temp_tempDetailData dat, tbl_Setup_DDIDFieldGroup grp"
        //'                                            gv_sql = gv_sql & " Where related.RelatedFieldGroupID = vu.RelatedFieldGroupID"
        //'                                            gv_sql = gv_sql & " AND dat.DDID = related.DDID AND FieldGroupID = 4"
        //'                                            gv_sql = gv_sql & " AND vu.VRMID = dat.VRMID AND grp.DDID = dat.DDID"
        //'                                            gv_sql = gv_sql & " AND vu.VRMID = " & rs_Impute2!VRMID
        //'                                            gv_sql = gv_sql & " AND len(FieldValue) > 0 AND FieldValue = (SELECT FieldValue FROM tbl_temp_tempDetailData tmp WHERE DDID = 244 AND VRMID = " & rs_Impute2!VRMID & ") "
        //'
        //'
        //'                                            Set rs_Impute3 = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //'                                            Do While Not rs_Impute3.EOF
        //'
        //'                                                'set time where name and date are valid and all the times are NOT missing
        //'                                                gv_sql = "UPDATE tbl_temp_tempDetailData Set FieldValue = (SELECT IsNull(FieldValue, '') "
        //'                                                gv_sql = gv_sql & "   FROM tbl_temp_tempDetailData ARRIVAL where ARRIVAL.DDID = 289 AND ARRIVAL.VRMID = tbl_temp_tempDetailData.VRMID) "
        //'                                                gv_sql = gv_sql & " WHERE VRMID = " & rs_Impute2!VRMID & " AND EXISTS "
        //'                                                gv_sql = gv_sql & " (SELECT VRMID, dat.DDID, FieldValue from tbl_temp_TempDetailData dat, tbl_Setup_DDIDRelatedFieldGroup rel, tbl_Setup_DDIDFieldGroup grp "
        //'                                                gv_sql = gv_sql & " Where rel.DDID = dat.DDID And grp.DDID = dat.DDID"
        //'                                                gv_sql = gv_sql & " AND RelatedFieldGroupID in (SELECT RelatedFieldGroupID FROM tbl_Setup_DDIDRelatedFieldGroup WHERE DDID = " & rs_Impute3!DDID & ") "
        //'                                                gv_sql = gv_sql & " AND VRMID = tbl_temp_tempDetailData.VRMID "
        //'                                                gv_sql = gv_sql & " and grp.FieldGroupID = 3"
        //'                                                gv_sql = gv_sql & " and fieldvalue = '' AND dat.DDID = tbl_temp_tempDetailData.DDID)"
        //'
        //'                                                gv_cn.Execute gv_sql
        //'
        //'                                                rs_Impute3.MoveNext
        //'                                            Loop
        //'
        //'                                            rs_Impute3.Close
        //'                                            Set rs_Impute3 = Nothing
        //'
        //'
        //'                                        End If
        //'
        //'                                        rs_Impute2.Close
        //'                                        Set rs_Impute2 = Nothing
        //'
        //'                                        rs_Impute.MoveNext
        //'                                    Loop
        //'
        //'
        //'                                    rs_Impute.Close
        //'                                    Set rs_Impute = Nothing
        //'
        //'
        //'
        //'                                End If
        //'
        //'                        End If
        //
        //                        lb_MeasureHasGroup = True
        //
        //                        'this is where the group logic is processed
        //'                        gv_sql = "{ ? = call ProcessSavedGroupSQLCondition(?,?) }"
        //'                        Set ps = gv_cn.CreatePreparedStatement("", gv_sql)
        //'                        ps(0).Direction = rdParamReturnValue
        //'                        ps(1).Direction = rdParamInput
        //'                        ps(2).Direction = rdParamInput
        //'                        ps.rdoParameters(1) = rs_MeasureCriteria!MeasureCriteriaID
        //'                        ps.rdoParameters(2) = VerifyID
        //'                        ps.Execute
        //'                        ps.Close
        //'                        DoEvents
        //
        //'                        gv_sql = "INSERT INTO tbl_temp_tTempPatRecCriteria (VRMID, " & _
        ///                            " MeasureCriteria, MeasureSet, Step) SELECT VRMID, " & _
        ///                            li_CritCount & ", " & rs_MeasureSet!MeasureCriteriaSet & ", " & _
        ///                            StepConditions(li_StepCnt).PStep & " FROM tbl_temp_tTempPatRecs WHERE IsSaved = 1 GROUP BY VRMID"
        //'                        gv_cn.Execute gv_sql
        //
        //                    Else
        //
        //                        'firoozeh added these case statements just to try to slow down processing, i can't think of any other reason why...
        //                        If IsNull(rs_MeasureCriteria!DDID1) Then
        //
        //                            ExceptionMethod = True
        //
        //
        //'
        //'                            ls_Sql = Replace(StepCondition, "AND   ", "OR   ")
        //'                            'Debug.Print StepCondition
        //'
        //'                            ls_FieldValue = Split(rs_MeasureCriteria!FIELDVALUE, ",")
        //'                            ls_sqlStmts = Split(ls_Sql, "OR   ")
        //'
        //'                            'stores the date values to be grouped and selected
        //'                            ReDim ls_LookupLocs(UBound(ls_FieldValue))
        //'                            For li_fieldCnt = 0 To UBound(ls_FieldValue)
        //'                                'get the locations of the fields in the measuredata table and store
        //'                                ls_LookupLocs(li_fieldCnt) = "[F" & ls_FieldValue(li_fieldCnt) & "]"
        //'                            Next
        //'
        //'                            gv_sql = "DELETE FROM tmp_ValidMeasureDates "
        //'                            gv_cn.Execute gv_sql
        //'
        //'                            gv_sql = "INSERT INTO tmp_ValidMeasureDates (F2, ValidDate) "
        //'                            For li_fieldCnt = 0 To UBound(ls_sqlStmts)
        //'                                ls_SelField = Trim(mid(ls_sqlStmts(li_fieldCnt), InStr(1, ls_sqlStmts(li_fieldCnt), "[F"), 6))
        //'
        //'                                'check if selfield is in the list of ls_lookuplocs?errorchecking
        //'
        //'                                gv_sql = gv_sql & " SELECT [F2]," & ls_SelField & " as ValidDate FROM tbl_MeasureData WHERE " & ls_sqlStmts(li_fieldCnt)
        //'                                If li_fieldCnt < UBound(ls_sqlStmts) Then
        //'                                    gv_sql = gv_sql & "UNION"
        //'                                End If
        //'                            Next
        //'
        //'                            'Debug.Print gv_sql
        //'
        //'                            gv_cn.Execute gv_sql
        //'
        //'                            'remove maximum dates where there are more than one listed for the case id
        //'                            gv_sql = "delete From tmp_validmeasuredates " & _
        ///                                " where F2 in (select F2 from tmp_ValidMeasureDates group by F2 having count(validdate) > 1)" & _
        ///                                " and Validdate in (select max(validdate) from tmp_validmeasuredates t where tmp_validmeasuredates.F2 = t.F2)"
        //'
        //'                            gv_cn.Execute gv_sql
        //'
        //
        //                            ls_join = ""
        //                            QCondition = ""
        //                            StepCondition = ""
        //
        //                             'get the time value in the next criteria field and add to the early date with
        //                            ' convert(datetime, earlydate + 'time', 121)
        //                            rs_MeasureCriteria.MoveNext
        //                            If Not rs_MeasureCriteria.EOF Then
        //                                Do While Not rs_MeasureCriteria.EOF
        //                                   If ls_join = "" Then ls_join = rs_MeasureCriteria!JoinOperator
        //
        //                                    'find the related date field
        //                                   gv_sql = "select Datefieldddid from tbl_setup_datadef "
        //                                   gv_sql = gv_sql & " where ddid = " & rs_MeasureCriteria!DDID1
        //                                   Set rs_IHARS = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //                                   'location on date field related to time field
        //                                   DateFieldDDID1 = Trim(CStr(rs_IHARS!DateFieldDDID))
        //                                   rs_IHARS.Close
        //
        //                                   'location of time field
        //                                   li_FieldLoc = Trim(CStr(rs_MeasureCriteria!DDID1))
        //                                   ls_FirstDate = "convert(datetime, [F" & DateFieldDDID1 & "] + ' ' + [F" & li_FieldLoc & "], 121)"
        //
        //                                   li_TimeLoc = Trim(CStr(rs_MeasureCriteria!ddid2))
        //                                   ls_SecondDate = "convert(datetime, ValidDate + ' ' + [F" & li_TimeLoc & "],121)"
        //
        //                                    If QCondition = "" Then
        //                                        QCondition = "[F2] in "
        //                                        QCondition = QCondition & " (Select d.F2 FROM tmp_MeasureData d, tmp_ValidMeasureDates vd "
        //                                        QCondition = QCondition & " WHERE (vd.F2 = d.F2) "
        //                                        QCondition = QCondition & " AND "
        //                                        QCondition = QCondition & " ("
        //                                        QCondition = QCondition & "     (DateDiff(" & rs_MeasureCriteria!DateUnit & "," & ls_FirstDate & ", " & ls_SecondDate & ") "
        //                                        QCondition = QCondition & rs_MeasureCriteria!ValueOperator
        //                                        QCondition = QCondition & " " & rs_MeasureCriteria!FIELDVALUE & ")"
        //                                    Else
        //                                        QCondition = QCondition & " " & ls_join & " (DateDiff(" & rs_MeasureCriteria!DateUnit & "," & ls_FirstDate & ", " & ls_SecondDate
        //                                        QCondition = QCondition & ") " & rs_MeasureCriteria!ValueOperator & " " & rs_MeasureCriteria!FIELDVALUE & ")"
        //                                    End If
        //
        //                                    rs_MeasureCriteria.MoveNext
        //                                Loop
        //
        //                                QCondition = QCondition & "))"
        //                                'Debug.Print QCondition
        //                            Else
        //                                MsgBox "Earliest criteria is not followed by another field with time"
        //                                Exit Function
        //                            End If
        //
        //
        //                        'regular method
        //                        ElseIf Not IsNull(rs_MeasureCriteria!DDID1) Then
        //
        //
        //                            li_FieldLoc = Trim(CStr(rs_MeasureCriteria!DDID1))
        //
        //                            If Trim(UCase(rs_MeasureCriteria!JoinOperator)) = "AND" Then
        //                                CaseElseVal = 0
        //                            Else
        //                                CaseElseVal = 0
        //                            End If
        //
        //                            'get the field type and adjust the query accordingly
        //                            gv_sql = "Select FieldType from tbl_Setup_DataDef where DDID = " & rs_MeasureCriteria!DDID1
        //                            Set rs_Temp = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //                            FieldType = rs_Temp!FieldType
        //                            rs_Temp.Close
        //
        //                            If IsNull(rs_MeasureCriteria!ddid2) Or rs_MeasureCriteria!ddid2 <= 0 Then   'the field value has been compared to a fixed value, or another field
        //
        //                                'the field value has been compared to a blank
        //                                If rs_MeasureCriteria!FIELDVALUE = "Null" Then
        //                                    QCondition = " case when [F" & li_FieldLoc & "] " & IIf(rs_MeasureCriteria!ValueOperator = "=", " is Null", " is not Null")
        //                                    QCondition = QCondition & " then 1 "
        //
        //                                'the field value has been compared to a fixed value, or values of a lookup table
        //                                ElseIf IsNull(rs_MeasureCriteria!DestDDID) Or rs_MeasureCriteria!DestDDID <= 0 Then
        //
        //                                    If IsNull(rs_MeasureCriteria!LookupTableID) Or rs_MeasureCriteria!LookupTableID = 0 Then
        //                                        ' the field value has been compared to a fixed value
        //                                        QCondition = " case when ("
        //                                        Select Case mid(FieldType, 1, 4)
        //                                            Case "Date"
        //                                                If Not IsNull(rs_MeasureCriteria!DateUnit) Then
        //                                                    'range of months - Method 5
        //                                                    If rs_MeasureCriteria!ValueOperator = "In" And rs_MeasureCriteria!DateUnit = "m" Then
        //                                                        Dim Months() As String
        //                                                        Dim ls_months As String
        //                                                        ls_months = rs_MeasureCriteria!FIELDVALUE
        //                                                        'trim () off
        //                                                        ls_months = mid(ls_months, 2, Len(ls_months) - 2)
        //                                                        Months = Split(ls_months, ",")
        //                                                        QCondition = QCondition & " [F" & li_FieldLoc & "] is not null AND ("
        //                                                        For li_cnt = 0 To UBound(Months)
        //                                                            QCondition = QCondition & " datepart(" & rs_MeasureCriteria!DateUnit & ",[F" & li_FieldLoc & "]) = " & Months(li_cnt)
        //                                                            If li_cnt < UBound(Months) Then QCondition = QCondition & " OR "
        //                                                        Next
        //                                                        QCondition = QCondition & ")"
        //                                                    Else
        //                                                        QCondition = QCondition & " [F" & li_FieldLoc & "] is not null AND "
        //                                                        QCondition = QCondition & " datepart(" & rs_MeasureCriteria!DateUnit & ",[F" & li_FieldLoc & "]) " & rs_MeasureCriteria!ValueOperator & " " & rs_MeasureCriteria!FIELDVALUE
        //                                                    End If
        //                                                Else
        //                                                    QCondition = QCondition & " [F" & li_FieldLoc & "] " & rs_MeasureCriteria!ValueOperator & " '" & rs_MeasureCriteria!FIELDVALUE & "'"
        //                                                End If
        //                                            Case "Numb" 'for a numeric values
        //                                                QCondition = QCondition & " [F" & li_FieldLoc & "] is not null AND "
        //                                                QCondition = QCondition & " [F" & li_FieldLoc & "] " & rs_MeasureCriteria!ValueOperator & " " & rs_MeasureCriteria!FIELDVALUE
        //
        //                                            Case Else 'for a text, we need to use sigle quote around the value
        //                                                QCondition = QCondition & " [F" & li_FieldLoc & "] " & rs_MeasureCriteria!ValueOperator & " '" & rs_MeasureCriteria!FIELDVALUE & "'"
        //                                        End Select
        //                                        If rs_MeasureCriteria!ValueOperator = "<>" Then
        //                                            QCondition = QCondition & " or [F" & li_FieldLoc & "] is null "
        //                                        End If
        //                                        QCondition = QCondition & ")"
        //                                        QCondition = QCondition & " then 1 "
        //                                    Else
        //                                        'the field has been compared to a lookup table
        //                                        'SH - removed the null check for lookup table comparison
        //                                        CheckForNull = ""
        //                                        If rs_MeasureCriteria!ValueOperator = "In" Then
        //                                            CheckForNull = "[F" & li_FieldLoc & "] Is not Null and "
        //                                        ElseIf rs_MeasureCriteria!ValueOperator = "Not In" Then
        //                                            CheckForNull = "[F" & li_FieldLoc & "] Is Null Or "
        //                                        End If
        //                                        QCondition = " case when " & CheckForNull & " ([F" & li_FieldLoc & "] " & rs_MeasureCriteria!ValueOperator
        //                                        QCondition = QCondition & " (select lkvalue = CASE  "
        //                                        QCondition = QCondition & " WHEN td.CompareToDesc = 'Yes' THEN lk.FieldValue"
        //                                        QCondition = QCondition & " Else lk.Id"
        //                                        QCondition = QCondition & " End"
        //                                        QCondition = QCondition & " from tbl_Setup_MISCLOOKUPLIST as lk"
        //                                        QCondition = QCondition & " inner join tbl_Setup_TableDef as td  on lk.basetableid = td.basetableid"
        //                                        QCondition = QCondition & " where lk.basetableid = " & rs_MeasureCriteria!LookupTableID & "))"
        //                                        QCondition = QCondition & " then 1 "
        //
        //                                    End If
        //
        //                                Else
        //                                'the 2 fields have been compared to each other
        //
        //                                    Select Case mid(FieldType, 1, 4)
        //                                        Case "Date"
        //                                            QCondition = " case when  "
        //                                            QCondition = QCondition & " isdate([F" & li_FieldLoc & "]) + isdate([F" & Trim(CStr(rs_MeasureCriteria!DestDDID)) & "]) = 2 then "
        //                                                QCondition = QCondition & " case when [F" & li_FieldLoc & "] "
        //                                                QCondition = QCondition & rs_MeasureCriteria!ValueOperator
        //                                                QCondition = QCondition & " [F" & Trim(CStr(rs_MeasureCriteria!DestDDID)) & "] "
        //                                                QCondition = QCondition & " then 1 else 0 end "
        //                                            'QCondition = QCondition & " else " & CaseElseVal & " end  = 1 "  'if any field is not a valid date and time, this condition should be ineffective, so we set it to true
        //
        //                                        Case "Numb"
        //                                            QCondition = " case when [F" & li_FieldLoc & "] is not null AND "
        //                                            QCondition = QCondition & " [F" & li_FieldLoc & "] "
        //                                            QCondition = QCondition & rs_MeasureCriteria!ValueOperator
        //                                            QCondition = QCondition & " [F" & Trim(CStr(rs_MeasureCriteria!DestDDID)) & "] "
        //                                            QCondition = QCondition & " then 1 "
        //
        //                                        Case "Time"
        //                                            'find the related date field
        //                                            gv_sql = "select Datefieldddid from tbl_setup_datadef "
        //                                            gv_sql = gv_sql & " where ddid = " & li_FieldLoc
        //                                            Set rs_IHARS = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //                                            DateFieldDDID1 = rs_IHARS!DateFieldDDID
        //                                            rs_IHARS.Close
        //
        //                                            gv_sql = "select Datefieldddid from tbl_setup_datadef "
        //                                            gv_sql = gv_sql & " where ddid = " & rs_MeasureCriteria!DestDDID
        //                                            Set rs_IHARS = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //                                            DateFieldDDID2 = rs_IHARS!DateFieldDDID
        //                                            rs_IHARS.Close
        //
        //                                            QCondition = " case when "
        //                                            QCondition = QCondition & " isdate([F" & li_FieldLoc & "])  "
        //                                            QCondition = QCondition & "             + isdate([F" & Trim(CStr(rs_MeasureCriteria!DestDDID)) & "]) "
        //                                            QCondition = QCondition & "             + isdate([F" & Trim(CStr(DateFieldDDID1)) & "]) "
        //                                            QCondition = QCondition & "             + isdate([F" & Trim(CStr(DateFieldDDID2)) & "]) = 4 then "
        //                                            QCondition = QCondition & "     case when convert(datetime, [F" & Trim(CStr(DateFieldDDID1)) & "] +  ' ' + [F" & li_FieldLoc & "],121) "
        //                                            QCondition = QCondition & rs_MeasureCriteria!ValueOperator
        //                                            QCondition = QCondition & "     convert(datetime, [F" & Trim(CStr(DateFieldDDID2)) & "] +  ' ' + [F" & Trim(CStr(rs_MeasureCriteria!DestDDID)) & "],121) "
        //                                            QCondition = QCondition & "      then 1 else 0 end "
        //                                            'QCondition = QCondition & " else " & CaseElseVal & " end = 1 "
        //
        //                                        Case Else
        //                                            QCondition = " case when [F" & li_FieldLoc & "] "
        //                                            QCondition = QCondition & rs_MeasureCriteria!ValueOperator
        //                                            QCondition = QCondition & " [F" & Trim(CStr(rs_MeasureCriteria!DestDDID)) & "] "
        //                                            QCondition = QCondition & " then 1 "
        //                                    End Select
        //
        //                                End If
        //
        //                            Else 'an arithmetic operation has been applied to the 2 fields,
        //                                        'and the result is compared to a value
        //
        //                                    Select Case mid(FieldType, 1, 4)
        //                                    Case "Date"
        //                                        QCondition = " case when  "
        //                                        QCondition = QCondition & " isdate([F" & li_FieldLoc & "]) + isdate([F" & Trim(CStr(rs_MeasureCriteria!ddid2)) & "]) = 2 then "
        //                                            QCondition = QCondition & " case when DateDiff(" & rs_MeasureCriteria!DateUnit
        //                                            QCondition = QCondition & ", convert(datetime,[F" & li_FieldLoc & "])  "
        //                                            QCondition = QCondition & ", convert(datetime,[F" & Trim(CStr(rs_MeasureCriteria!ddid2)) & "])) "
        //                                            QCondition = QCondition & " " & rs_MeasureCriteria!ValueOperator & " " & rs_MeasureCriteria!FIELDVALUE
        //                                            QCondition = QCondition & " then 1 else 0 end "
        //                                        'QCondition = QCondition & " else " & CaseElseVal & " end  = 1 "  'if any field is not a valid date and time, this condition should be ineffective, so we set it to true
        //
        //
        //                                    Case "Time"
        //                                        'find the related date field
        //                                        gv_sql = "select Datefieldddid from tbl_setup_datadef "
        //                                        gv_sql = gv_sql & " where ddid = " & rs_MeasureCriteria!DDID1
        //                                        Set rs_IHARS = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //                                        DateFieldDDID1 = rs_IHARS!DateFieldDDID
        //                                        rs_IHARS.Close
        //                                        li_FieldLoc = Trim(CStr(rs_MeasureCriteria!DDID1))
        //
        //                                        gv_sql = "select Datefieldddid from tbl_setup_datadef "
        //                                        gv_sql = gv_sql & " where ddid = " & rs_MeasureCriteria!ddid2
        //                                        Set rs_IHARS = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //                                        DateFieldDDID2 = rs_IHARS!DateFieldDDID
        //                                        rs_IHARS.Close
        //
        //                                        QCondition = " case when  "
        //                                        QCondition = QCondition & " isdate([F" & li_FieldLoc & "])  "
        //                                        QCondition = QCondition & "             + isdate([F" & Trim(CStr(rs_MeasureCriteria!ddid2)) & "]) "
        //                                        QCondition = QCondition & "             + isdate([F" & Trim(CStr(DateFieldDDID1)) & "]) "
        //                                        QCondition = QCondition & "             + isdate([F" & Trim(CStr(DateFieldDDID2)) & "]) = 4 then "
        //                                        QCondition = QCondition & " case when DateDiff(" & rs_MeasureCriteria!DateUnit & ","
        //                                        QCondition = QCondition & "         convert(datetime, [F" & Trim(CStr(DateFieldDDID1)) & "] +  ' ' + [F" & li_FieldLoc & "],121), "
        //                                        QCondition = QCondition & "         convert(datetime, [F" & Trim(CStr(DateFieldDDID2)) & "] +  ' ' + [F" & Trim(CStr(rs_MeasureCriteria!ddid2)) & "],121) "
        //                                        QCondition = QCondition & "                 ) " & rs_MeasureCriteria!ValueOperator & " " & rs_MeasureCriteria!FIELDVALUE
        //                                        QCondition = QCondition & "      then 1 else 0 end "
        //                                        'QCondition = QCondition & " else " & CaseElseVal & " end = 1 "
        //                                        'QCondition = QCondition & ") "
        //
        //
        //                                    Case "Numb"
        //                                        QCondition = " case when ([F" & li_FieldLoc & "] is not null AND "
        //                                        QCondition = QCondition & " [F" & li_FieldLoc & "] " & rs_MeasureCriteria!FieldOperator
        //                                        QCondition = QCondition & " [F" & Trim(CStr(rs_MeasureCriteria!ddid2)) & "] "
        //                                        QCondition = QCondition & rs_MeasureCriteria!ValueOperator & " " & rs_MeasureCriteria!FIELDVALUE
        //                                        QCondition = QCondition & ") "
        //                                        QCondition = QCondition & " then 1 "
        //                                    Case Else
        //                                        QCondition = " case when [F" & li_FieldLoc & "] " & rs_MeasureCriteria!FieldOperator
        //                                        QCondition = QCondition & " [F" & Trim(CStr(rs_MeasureCriteria!ddid2)) & "] "
        //                                        QCondition = QCondition & rs_MeasureCriteria!ValueOperator & " " & rs_MeasureCriteria!FIELDVALUE
        //                                        QCondition = QCondition & " then 1 "
        //                                    End Select
        //
        //                            End If
        //
        //                        End If
        //                    End If
        //
        //                    If StepConditions(li_StepCnt).HasGroupLogic = False Then
        //                        If ExceptionMethod = False Then
        //                            QCondition = QCondition & "    else 0 end "
        //                            If SetConditions = "" Then
        //                                SetConditions = QCondition
        //                            Else
        //                                SetConditions = SetConditions & " + " & QCondition
        //                            End If
        //                        Else
        //                            SetConditions = SetConditions & " " & ls_LastJoin & " " & QCondition
        //                        End If
        //                    End If
        //
        //
        //
        //                    If Not rs_MeasureCriteria.EOF Then
        //                        ls_LastJoin = Trim(UCase(rs_MeasureCriteria!JoinOperator))
        //                        rs_MeasureCriteria.MoveNext
        //                    End If
        //                Loop
        //                rs_MeasureCriteria.Close
        //
        //                Select Case StepConditions(li_StepCnt).HasGroupLogic
        //'                Case True:
        //'
        //'                        If Trim(ls_LastJoin) = "AND" Then
        //'                            gv_sql = "INSERT INTO tbl_temp_MeasureSetGroupResults (VRMID, MeasureSet, Step) " & _
        ///                                " SELECT DISTINCT VRMID, " & rs_MeasureSet!MeasureCriteriaSet & ", " & StepConditions(li_StepCnt).PStep & " FROM tbl_temp_tTempPatRecCriteria WHERE Step = " & StepConditions(li_StepCnt).PStep & " AND EXISTS ( " & _
        ///                                " SELECT VRMID, Count(MeasureCriteria) FROM tbl_temp_tTempPatRecCriteria temp" & _
        ///                                " WHERE Step = " & StepConditions(li_StepCnt).PStep & " AND MeasureSet = " & thisset & _
        ///                                " AND temp.VRMID = tbl_temp_tTempPatRecCriteria.VRMID " & _
        ///                                " GROUP BY VRMID " & _
        ///                                " HAVING Count(MeasureCriteria) = " & li_CritCount & ")"
        //'
        //'
        //'                        ElseIf Trim(ls_LastJoin) = "OR" Then
        //'                            gv_sql = "INSERT INTO tbl_temp_MeasureSetGroupResults (VRMID, MeasureSet, Step) SELECT DISTINCT VRMID, MeasureSet, Step FROM tbl_temp_tTempPatRecCriteria WHERE Step = " & StepConditions(li_StepCnt).PStep & " AND MeasureSet = " & thisset
        //'
        //'                        End If
        //'
        //'                        gv_cn.Execute gv_sql
        //                Case False:
        //                    If ExceptionMethod = False Then
        //                        If setJoinOp = "AND" Then
        //                            SetConditions = " ( " & SetConditions & " ) = " & CritCount
        //                        ElseIf setJoinOp = "OR" Then
        //                            SetConditions = " ( " & SetConditions & " ) >= 1 "
        //                        Else
        //                            SetConditions = " ( " & SetConditions & " ) >= 1 "
        //                        End If
        //                    End If
        //
        //                    If ls_GroupJoin = "" Then
        //                        If StepCondition = "" Then
        //                            StepCondition = "( " & SetConditions & " )"
        //                        Else
        //                            StepCondition = StepCondition & " " & MainJOp & " ( " & SetConditions & " )"
        //                        End If
        //                    Else
        //                            'piece the groupconditions together
        //                            If GroupSubCondition = "" Then
        //                                GroupSubCondition = "(" & SetConditions & ")"
        //                            Else
        //
        //                                If li_LastGroupNo <> rs_MeasureSet!MeasureStepGroup Then
        //                                    If GroupCondition = "" Then
        //                                        GroupCondition = "( " & GroupSubCondition & " )"
        //                                    Else
        //                                        GroupCondition = GroupCondition & " " & ls_GroupJoin & " (" & GroupSubCondition & ")"
        //                                    End If
        //
        //                                    GroupSubCondition = " (" & SetConditions & ")"
        //                                Else
        //                                    If GroupSubCondition = "" Then
        //                                        GroupSubCondition = " (" & SetConditions & ")"
        //                                    Else
        //                                        GroupSubCondition = GroupSubCondition & " " & MainJOp & " ( " & SetConditions & " )"
        //                                    End If
        //                                End If
        //
        //                            End If
        //
        //                        li_LastGroupNo = rs_MeasureSet!MeasureStepGroup
        //                    End If
        //                End Select
        //
        //                rs_MeasureSet.MoveNext
        //            Loop
        //            rs_MeasureSet.Close
        //
        //            If StepConditions(li_StepCnt).HasGroupLogic = False Then
        //                If GroupCondition = "" Then
        //                    StepConditions(li_StepCnt).SQL = StepCondition
        //                Else
        //                    StepConditions(li_StepCnt).SQL = GroupCondition & " " & ls_GroupJoin & " ( " & GroupSubCondition & " )"
        //                    'Debug.Print StepConditions(li_StepCnt).SQL
        //                End If
        //            Else
        //
        //                'Create a Result table for the STEP not based on groups
        //                 If Trim(MainJOp) = "AND" Then
        //'                    gv_sql = "SELECT VRMID, Count(MeasureSet) FROM tbl_temp_MeasureSetGroupResults" & _
        ///                        " WHERE Step = " & StepConditions(li_StepCnt).PStep & _
        ///                        " GROUP BY VRMID " & _
        ///                        " HAVING Count(MeasureSet) = " & thisset
        //'                    Set rs_PatRecCrit = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //'
        //'                    If Not rs_PatRecCrit.EOF Then
        //'                        Do While Not rs_PatRecCrit.EOF
        //'                            gv_sql = "INSERT INTO tbl_temp_TimingMeasureStepGroupResults (VRMID, MeasureStep, IndicatorID) " & _
        ///                                " VALUES (" & rs_PatRecCrit!VRMID & ", " & StepConditions(li_StepCnt).PStep & ", " & rs_Measures!IndicatorID & ") "
        //'                            gv_cn.Execute gv_sql
        //'
        //'                            rs_PatRecCrit.MoveNext
        //'                        Loop
        //'
        //                        StepConditions(li_StepCnt).SQL = " EXISTS (SELECT NULL FROM tbl_temp_MeasureStepGroupResults WHERE VRMID = tmp_MeasureData.VRMID AND MeasureStep = " & StepConditions(li_StepCnt).PStep & ") "
        //'                    End If
        //'
        //'                    rs_PatRecCrit.Close
        //
        //                ElseIf Trim(MainJOp) = "OR" Then
        //'                    gv_sql = "INSERT INTO tbl_temp_TimingMeasureStepGroupResults (VRMID, MeasureStep, IndicatorID) SELECT DISTINCT VRMID, Step, " & rs_Measures!IndicatorID & " FROM tbl_temp_MeasureSetGroupResults WHERE Step = " & StepConditions(li_StepCnt).PStep
        //'                    gv_cn.Execute gv_sql
        //'
        //                    'If gv_cn.RowsAffected > 0 Then
        //                        StepConditions(li_StepCnt).SQL = " EXISTS (SELECT NULL FROM tbl_temp_MeasureStepGroupResults WHERE VRMID = tmp_MeasureData.VRMID AND MeasureStep = " & StepConditions(li_StepCnt).PStep & ") "
        //                    'End If
        //                End If
        //
        //            End If
        //
        //            'StepConditions(li_StepCnt).CAT = Nz(Trim(rs_MeasureStep!CAT), "X")
        //            If IsNull(rs_MeasureStep!CAT) Then
        //                StepConditions(li_StepCnt).CAT = "X"
        //            Else
        //                StepConditions(li_StepCnt).CAT = Trim(rs_MeasureStep!CAT)
        //            End If
        //
        //            'StepConditions(li_StepCnt).CAT_TYPE = Nz(Trim(rs_MeasureStep!CAT_TYPE), "F")
        //            If IsNull(rs_MeasureStep!CAT_TYPE) And IsNull(rs_MeasureStep!GoToStep) Then
        //                StepConditions(li_StepCnt).CAT_TYPE = "F"
        //            Else
        //                If IsNull(rs_MeasureStep!CAT_TYPE) And rs_MeasureStep!isrisk = False Then
        //                    StepConditions(li_StepCnt).CAT_TYPE = "CI"
        //                ElseIf IsNull(rs_MeasureStep!CAT_TYPE) And rs_MeasureStep!isrisk = True Then
        //                    StepConditions(li_StepCnt).CAT_TYPE = "RA"
        //                Else
        //                    StepConditions(li_StepCnt).CAT_TYPE = Trim(rs_MeasureStep!CAT_TYPE)
        //                End If
        //            End If
        //
        //
        //            If IsNull(rs_MeasureStep!GoToStep) Then
        //                StepConditions(li_StepCnt).GoToStep = 0
        //            Else
        //                StepConditions(li_StepCnt).GoToStep = Trim(rs_MeasureStep!GoToStep)
        //            End If
        //
        //            StepConditions(li_StepCnt).PStep = rs_MeasureStep!measurestep
        //
        //            gv_sql = " SELECT VRMID, "
        //            If IsNull(StepConditions(li_StepCnt).CAT) Then
        //                gv_sql = gv_sql & " null "
        //            Else
        //                gv_sql = gv_sql & " '" & StepConditions(li_StepCnt).CAT & "' "
        //            End If
        //            gv_sql = gv_sql & " AS Cat, "
        //            If IsNull(StepConditions(li_StepCnt).GoToStep) Then
        //                gv_sql = gv_sql & " null "
        //            Else
        //                gv_sql = gv_sql & StepConditions(li_StepCnt).GoToStep
        //            End If
        //            gv_sql = gv_sql & " AS GoToStep, '" & StepConditions(li_StepCnt).CAT_TYPE & "' as CatType"
        //            gv_sql = gv_sql & ", " & StepConditions(li_StepCnt).PStep
        //            gv_sql = gv_sql & " as PStep, " & rs_Measures!JCAHOID & " as JCAHOID "
        //            gv_sql = gv_sql & "  From tmp_MeasureData WHERE"
        //
        //            If StepConditions(li_StepCnt).SQL <> "" Then
        //                gv_sql = gv_sql & "  ( " & StepConditions(li_StepCnt).SQL & ") "
        //            End If
        //
        //            'gv_sql = gv_sql & "  [VRMID] not in "
        //            'gv_sql = gv_sql & "  (select VRMID from temp_VerifyResults where PMI = " & rs_Measures!JCAHOID
        //            'gv_sql = gv_sql & "   and Cat_Type = '" & StepConditions(li_StepCnt).CAT_TYPE & "')"
        //
        //            ls_line = gv_sql
        //
        //            gv_sql = "{ ? = call InsertStepCondition(?,?,?,?,?,?,?) }"
        //            Set ps = gv_cn.CreatePreparedStatement("", gv_sql)
        //            ps(0).Direction = rdParamReturnValue
        //            ps(1).Direction = rdParamInput
        //            ps(2).Direction = rdParamInput
        //            ps(3).Direction = rdParamInput
        //            ps(4).Direction = rdParamInput
        //            ps(5).Direction = rdParamInput
        //            ps(6).Direction = rdParamInput
        //            ps(7).Direction = rdParamInput
        //
        //            ps.rdoParameters(1) = StepConditions(li_StepCnt).PStep
        //            ps.rdoParameters(2) = StepConditions(li_StepCnt).GoToStep
        //            ps.rdoParameters(3) = StepConditions(li_StepCnt).CAT
        //            ps.rdoParameters(4) = StepConditions(li_StepCnt).CAT_TYPE
        //            ps.rdoParameters(5) = IIf(StepConditions(li_StepCnt).HasGroupLogic, "1", "0")
        //            ps.rdoParameters(6) = rs_Measures!IndicatorID
        //            ps.rdoParameters(7) = ls_line
        //
        //            'Debug.Print ls_line
        //
        //            ps.Execute
        //            ps.Close
        //
        //
        //
        //            'Debug.Print StepConditions(li_StepCnt).SQL
        //            li_StepCnt = li_StepCnt + 1
        //            rs_MeasureStep.MoveNext
        //        Loop
        //
        //        'gv_cn.Execute "DELETE FROM tmp_MeasureData"
        //    End If
        //
        //    DoEvents
        //
        //
        //    rs_Measures.MoveNext
        //    frmVerifyTimingTest.pgStatus.Value = (li_MeasCnt / (li_MaxMeas * (li_StartVal / frmVerifyTimingTest.pgStatus.Max))) * li_StartVal
        //
        //Loop
        //
        //
        //Exit Function
        //
        ////LDW ErrHandler:
        //    CheckForErrors
        //    Close hFile%
        //
        //End Function



        //LDW private static int[] GetMultipleSelectionDDID( int DDID)
    }
}
