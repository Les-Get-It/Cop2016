using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace COP2001
{
    public partial class frmMainMenu : RadForm
    {
        string NewFieldName;


        public frmMainMenu()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            //ConnectToDatabase
            //Dim wrkODBC As Workspace
            //Dim conpubs As Connection
            //Set wrkODBC = CreateWorkspace("NewODBCWorkspace", "", "", dbUseODBC)
            //Set conpubs = wrkODBC.OpenConnection("Connection1", , , "ODBC;DATABASE=COP2001;UID=sa;PWD=;DSN=COP2001")
            //Set dtHelp.Recordset = conpubs.OpenRecordset(gv_sql, 2)

            try
            {
                if (modGlobal.gv_selecteddatabase == "IHHA")
                {
                    lblDatabase.Text = "IHHA - To accept new changes";
                    //mnuImportDataDef.Enabled = False

                    mnuUpdateSystemSetup.Enabled = false;
                }
                else if (modGlobal.gv_selecteddatabase == "Current")
                {
                    lblDatabase.Text = "Current - To process hospital data";
                    //mnuSubmitSetup.Enabled = False
                    //mnuUpdateExistingDB.Enabled = False
                }
                else if (modGlobal.gv_selecteddatabase == "Archive")
                {
                    lblDatabase.Text = modGlobal.gv_selecteddatabase;
                    //mnuUpdateSystemSetup.Enabled = False
                    //mnuSubmitSetup.Enabled = False
                    //mnuUpdateExistingDB.Enabled = False
                }
                else if (modGlobal.gv_selecteddatabase == "COPWebSetup")
                {
                    lblDatabase.Text = "COPWebSetup - To create test Web Setups";
                }

                lblDatabase.Width = this.Width;
                lblDatabase.Left = 0;

                modGlobal.gv_sql = "Select * from tbl_Setup_TableDef";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.RowCount == 0)
                if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count == 0)
                {
                    InitializeTableDef();
                }

                if (!string.IsNullOrEmpty(modGlobal.gv_State))
                {
                    mnuImport.Enabled = false;
                    //mnuSubmitSetup.Enabled = False
                    //mnuImportDataDef.Enabled = False
                }
                else
                {
                    //mnuStateSetup.Enabled = False
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
            //*** Warning: remove this before delivery
            //gv_sql = "delete tbl_setup_DataDef "
            //gv_cn.Execute gv_sql 
        }

        private void frmMainMenu_FormClosed(Object eventSender, FormClosedEventArgs eventArgs)
        {
            //RadForm frm = null;

            //foreach (RadForm frm_loopVariable in Application.OpenForms)
            //{
            //    frm = frm_loopVariable;
            //    frm.Close();
            //}
            //frm = null;
            //this.Close();
            //modGlobal.gv_cn.Close();
            try
            {
                Application.Exit();
                modGlobal.gv_cn = null;
                modGlobal.gv_rs = null;
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
            //LDW modGlobal.gv_en.Close();
            //LDW modGlobal.gv_en = null;
        }

        public void mnuClose_Click(Object eventSender, EventArgs eventArgs)
        {
            //RadForm frm = null;

            //foreach (RadForm frm_loopVariable in Application.OpenForms)
            //{
            //    frm = frm_loopVariable;
            //    frm.Close();
            //}

            //LDW modGlobal.gv_en = null;
            modGlobal.gv_cn = null;
            modGlobal.gv_rs = null;
            this.Close();
        }

        public void mnuCreateCMSSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            string multiple = null;
            string OutputFormat = null;
            string LookupTableID = null;
            string fieldedit = null;
            string cmsfieldcode = null;
            string DDID = null;
            string measurecode = null;
            string IndicatorID = null;
            int FileNum = FileSystem.FreeFile();
            string UpdateFile = null;
            string Quarter = null;
            string thisquarter = null;

            try
            {
                if (DateAndTime.Month(DateAndTime.Now) == 1 | DateAndTime.Month(DateAndTime.Now) == 2 | DateAndTime.Month(DateAndTime.Now) == 3)
                {
                    thisquarter = "1/1/" + DateAndTime.Year(DateAndTime.Now);
                }
                else if (DateAndTime.Month(DateAndTime.Now) == 4 | DateAndTime.Month(DateAndTime.Now) == 5 | DateAndTime.Month(DateAndTime.Now) == 6)
                {
                    thisquarter = "4/1/" + DateAndTime.Year(DateAndTime.Now);
                }
                else if (DateAndTime.Month(DateAndTime.Now) == 7 | DateAndTime.Month(DateAndTime.Now) == 8 | DateAndTime.Month(DateAndTime.Now) == 9)
                {
                    thisquarter = "7/1/" + DateAndTime.Year(DateAndTime.Now);
                }
                else if (DateAndTime.Month(DateAndTime.Now) == 10 | DateAndTime.Month(DateAndTime.Now) == 11 | DateAndTime.Month(DateAndTime.Now) == 12)
                {
                    thisquarter = "10/1/" + DateAndTime.Year(DateAndTime.Now);
                }

                Quarter = RadInputBox.Show("Type in the first day of the selected quarter.", "CMS Setup Export", thisquarter);

                if (string.IsNullOrEmpty(Quarter) | Information.IsDBNull(Quarter))
                {
                    return;
                }

                /*LDW My.MyProject.Forms.FileFind.Text = "Specify the destination directory for CMSSetup.txt";
                My.MyProject.Forms.FileFind.ShowDialog();  */
                var dialog1 = new OpenFileDialog() { Title = "Specify the destination directory for CMSSetup.txt" };
                dialog1.ShowDialog();

                if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory))
                {
                    UpdateFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory, Strings.Len(modGlobal.gv_SelectedDirectory), 1) == "\\" ? "CMSSetup.txt" : "\\CMSSetup.txt");
                }
                else
                {
                    return;
                }

                FileSystem.FileOpen(FileNum, UpdateFile, OpenMode.Output);
                Cursor.Current = Cursors.WaitCursor;

                FileSystem.PrintLine(FileNum, "[Quarter]");
                FileSystem.PrintLine(FileNum, string.Format("\"{0}\"", Quarter));
                FileSystem.PrintLine(FileNum, "[CMSFIELDMEASURES]");
                modGlobal.gv_sql = "select distinct * FROM (Select * from vuCMSMappings Union All SELECT * FROM vuJCmappings) map WHERE CMSFieldCode IS NOT NULL ORDER BY CMSFieldCode";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "vuCMSMappings";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    IndicatorID = "";
                    measurecode = "";
                    DDID = "";
                    cmsfieldcode = "";
                    //ParentField = ""
                    fieldedit = "";
                    LookupTableID = "";
                    //LinktoDDId = ""
                    //LinkParent = ""
                    OutputFormat = "";
                    //CalcParent = ""
                    //CalcParentVal = ""
                    //DefaultValue = ""
                    multiple = "";

                    //LDW IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
                    IndicatorID = myRow1.Field<string>("IndicatorID");
                    //LDW measurecode = modGlobal.gv_rs.rdoColumns["measurecode"].Value;
                    measurecode = myRow1.Field<string>("measurecode");
                    //LDW DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
                    DDID = myRow1.Field<string>("DDID");
                    //LDW cmsfieldcode = modGlobal.gv_rs.rdoColumns["cmsfieldcode"].Value;
                    cmsfieldcode = myRow1.Field<string>("cmsfieldcode");

                    //        If Not IsNull(gv_rs!ParentField) Then
                    //             ParentField = gv_rs!ParentField
                    //        End If

                    //LDW if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["fieldedit"].Value))
                    if (!Information.IsDBNull(myRow1.Field<string>("fieldedit")))
                    {
                        //LDW fieldedit = modGlobal.gv_rs.rdoColumns["fieldedit"].Value;
                        fieldedit = myRow1.Field<string>("fieldedit");
                    }

                    //LDW if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["fieldLookupTableID"].Value))
                    if (!Information.IsDBNull(myRow1.Field<string>("fieldLookupTableID")))
                    {
                        //LDW LookupTableID = modGlobal.gv_rs.rdoColumns["fieldLookupTableID"].Value;
                        LookupTableID = myRow1.Field<string>("fieldLookupTableID");
                    }

                    //        If Not IsNull(gv_rs!LinktoDDId) Then
                    //            LinktoDDId = gv_rs!LinktoDDId
                    //        End If
                    //        If Not IsNull(gv_rs!LinkParent) Then
                    //            LinkParent = gv_rs!LinkParent
                    //        End If

                    //LDW if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OutputFormat"].Value))
                    if (!Information.IsDBNull(myRow1.Field<string>("OutputFormat")))
                    {
                        //LDW OutputFormat = modGlobal.gv_rs.rdoColumns["OutputFormat"].Value;
                        OutputFormat = myRow1.Field<string>("OutputFormat");
                    }

                    //        If Not IsNull(gv_rs!CalcParent) Then
                    //            CalcParent = gv_rs!CalcParent
                    //        End If
                    //        If Not IsNull(gv_rs!CalcParentVal) Then
                    //            CalcParentVal = gv_rs!CalcParentVal
                    //        End If

                    //If Not IsNull(gv_rs!DefaultValue) Then
                    //    DefaultValue = gv_rs!DefaultValue
                    //End If


                    /*LDW FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["fieldmeasureid"].Value + "\"" + "," + "\"" + DDID + "\"" + "," +
                     "\"" + IndicatorID + "\"" + "," + "\"" + measurecode + "\"" + "," + "\"" + fieldedit + "\"" + "," + "\"" + LookupTableID + "\"" + "," 
                     + "\"" + OutputFormat + "\"" + "," + "\"" + cmsfieldcode + "\"");*/
                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"", myRow1.Field<string>("fieldmeasureid"),
                        DDID, IndicatorID, measurecode, fieldedit, LookupTableID, OutputFormat, cmsfieldcode));

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                FileSystem.PrintLine(FileNum, "[CMSPARENTCD]");

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentCD";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName3 = "tbl_Setup_CMSParentCD";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName3, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow2 in modGlobal.gv_rs.Tables[sqlTableName3].Rows)
                {
                    /*LDW FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCD"].Value +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["AnswerCDDDID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["AnswerCDDDID"].Value) +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) + 
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["AnswerFormat"].Value) ? "" : modGlobal.gv_rs.rdoColumns["AnswerFormat"].Value) + "\"" +
                     "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DefaultValue"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DefaultValue"].Value) + "\"");  */

                    FileSystem.PrintLine(FileNum, "\"" + myRow2.Field<string>("CMSParentCDID") + "\"" + "," + "\"" + myRow2.Field<string>("CMSParentCDID") + "\"" + "," + "\"" +
                    (Information.IsDBNull(myRow2.Field<string>("AnswerCDDDID")) ? "" : myRow2.Field<string>("AnswerCDDDID")) + "\"" + "," + "\"" +
                    (Information.IsDBNull(myRow2.Field<string>("LookupTableID")) ? "" : myRow2.Field<string>("LookupTableID")) + "\"" + "," + "\"" +
                    (Information.IsDBNull(myRow2.Field<string>("AnswerFormat")) ? "" : myRow2.Field<string>("AnswerFormat")) + "\"" + "," + "\"" +
                    (Information.IsDBNull(myRow2.Field<string>("DefaultValue")) ? "" : myRow2.Field<string>("DefaultValue")) + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();
                //
                FileSystem.PrintLine(FileNum, "[CMSPARENTFIELDMEASURES]");
                //
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentFieldMeasures";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName4 = "tbl_Setup_CMSParentFieldMeasures";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName4, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow3 in modGlobal.gv_rs.Tables[sqlTableName4].Rows)
                {
                    /*LDW FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value + "\"" + "," + "\"" + 
                     * modGlobal.gv_rs.rdoColumns["fieldmeasureid"].Value + "\"");*/
                    FileSystem.PrintLine(FileNum, string.Format("\"{0}\",\"{1}\"", myRow3.Field<string>("CMSParentCDID"), myRow3.Field<string>("fieldmeasureid")));
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();
                //
                FileSystem.PrintLine(FileNum, "[CMSPARENTANSWERCRITERIA]");
                //
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentAnswerCriteria";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName5 = "tbl_Setup_CMSParentAnswerCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName5, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow4 in modGlobal.gv_rs.Tables[sqlTableName5].Rows)
                {
                    /*LDW FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaID"].Value + "\"" + "," + "\"" + 
                     modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaSet"].Value +
                     "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["DDID1"].Value + 
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ddid2"].Value) +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DestDDID"].Value) +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupID"].Value) +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) +
                     "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DateUnit"].Value) + "\"" +
                     "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) + "\"" + 
                     "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) + "\"");*/
                    FileSystem.PrintLine(FileNum, "\"" + myRow4.Field<string>("CMSParentAnswerCriteriaID") + "\"" + "," + "\"" +
                    myRow4.Field<string>("CMSParentCDID") + "\"" + "," + "\"" + myRow4.Field<string>("CMSParentAnswerCriteriaSet") +
                     "\"" + "," + "\"" + myRow4.Field<string>("CriteriaTitle") + "\"" + "," + "\"" + myRow4.Field<string>("DDID1") +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("ddid2")) ? "" : myRow4.Field<string>("ddid2")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("ValueOperator")) ? "" : myRow4.Field<string>("ValueOperator")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("FIELDVALUE")) ? "" : myRow4.Field<string>("FIELDVALUE")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("DestDDID")) ? "" : myRow4.Field<string>("DestDDID")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("LookupID")) ? "" : myRow4.Field<string>("LookupID")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("FieldOperator")) ? "" : myRow4.Field<string>("FieldOperator")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("DateUnit")) ? "" : myRow4.Field<string>("DateUnit")) + "\"" +
                    "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("JoinOperator")) ? "" : myRow4.Field<string>("JoinOperator")) + "\"" +
                    "," + "\"" + (Information.IsDBNull(myRow4.Field<string>("LookupTableID")) ? "" : myRow4.Field<string>("LookupTableID")) + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                FileSystem.PrintLine(FileNum, "[CMSPARENTANSWERCRITERIASET]");

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentAnswerCriteriaSet";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName6 = "tbl_Setup_CMSParentAnswerCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName6, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow5 in modGlobal.gv_rs.Tables[sqlTableName6].Rows)
                {
                    FileSystem.PrintLine(FileNum, "\"" + myRow5.Field<string>("CMSParentCDID") + "\"" + "," + "\"" +
                        myRow5.Field<string>("CMSParentAnswerCriteriaSet") + "\"" + "," + "\"" + myRow5.Field<string>("JoinOperator") + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                FileSystem.PrintLine(FileNum, "[CMSFIELDMEASURECRITERIA]");

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSFieldMeasureCriteria";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName7 = "tbl_Setup_CMSFieldMeasureCriteria";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName7, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow6 in modGlobal.gv_rs.Tables[sqlTableName7].Rows)
                {
                    /*LDW FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaID"].Value + "\"" + "," +
                     *"\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaSet"].Value +
                     *"\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["DDID1"].Value + "\"" +
                     *"," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ddid2"].Value) + "\"" + "," +
                     *"\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) + 
                     *"\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) + 
                     *"\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DestDDID"].Value) +
                     *"\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupID"].Value) +
                     *"\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) +
                     *"\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DateUnit"].Value) + "\"" + 
                     *"," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) + "\"" +
                     *"," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) + "\"");*/
                    FileSystem.PrintLine(FileNum, "\"" + myRow6.Field<string>("CMSFieldMeasureCriteriaID") + "\"" + "," +
                    "\"" + myRow6.Field<string>("CMSFieldMeasureID") + "\"" + "," + "\"" + myRow6.Field<string>("CMSFieldMeasureCriteriaSet") +
                    "\"" + "," + "\"" + myRow6.Field<string>("CriteriaTitle") + "\"" + "," + "\"" + myRow6.Field<string>("DDID1") + "\"" +
                    "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("ddid2")) ? "" : myRow6.Field<string>("ddid2")) + "\"" + "," +
                    "\"" + (Information.IsDBNull(myRow6.Field<string>("ValueOperator")) ? "" : myRow6.Field<string>("ValueOperator")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("FIELDVALUE")) ? "" : myRow6.Field<string>("FIELDVALUE")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("DestDDID")) ? "" : myRow6.Field<string>("DestDDID")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("LookupID")) ? "" : myRow6.Field<string>("LookupID")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("FieldOperator")) ? "" : myRow6.Field<string>("FieldOperator")) +
                    "\"" + "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("DateUnit")) ? "" : myRow6.Field<string>("DateUnit")) + "\"" +
                    "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("JoinOperator")) ? "" : myRow6.Field<string>("JoinOperator")) + "\"" +
                    "," + "\"" + (Information.IsDBNull(myRow6.Field<string>("LookupTableID")) ? "" : myRow6.Field<string>("LookupTableID")) + "\"");

                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                FileSystem.PrintLine(FileNum, "[CMSFIELDMEASURECRITERIASET]");

                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSFieldMeasureCriteriaSet";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName8 = "tbl_Setup_CMSFieldMeasureCriteriaSet";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName8, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow7 in modGlobal.gv_rs.Tables[sqlTableName8].Rows)
                {
                    /*LDW FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureID"].Value + "\"" + "," + "\"" +
                     *modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaSet"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + "\""); */
                    FileSystem.PrintLine(FileNum, "\"" + myRow7.Field<string>("CMSFieldMeasureID") + "\"" + "," + "\"" +
                    myRow7.Field<string>("CMSFieldMeasureCriteriaSet") + "\"" + "," + "\"" + myRow7.Field<string>("JoinOperator") + "\"");
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                modGlobal.gv_rs.Dispose();

                FileSystem.FileClose(FileNum);

                //LDW RadMessageBox.Show("CMS Setup file was exported to " + UpdateFile);

                DialogResult ds9 = RadMessageBox.Show(this, "CMS Setup file was exported to " + UpdateFile, "Create CMS Setup", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.Text = ds9.ToString();

                Cursor.Current = Cursors.Default;
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

        public void mnuDefineFlowcharts_Click(Object eventSender, EventArgs eventArgs)
        {
            frmMeasureCriteriaSetup frmMeasureCriteriaSetupCopy = new frmMeasureCriteriaSetup();
            frmMeasureCriteriaSetupCopy.Show();
        }

        public void mnuExportRiskCoef_Click(Object eventSender, EventArgs eventArgs)
        {
            frmExportCoef frmExportCoefCopy = new frmExportCoef();
            frmExportCoefCopy.Show();
        }

        public void mnuHospStatSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmHospStatSetup frmHospStatSetupCopy = new frmHospStatSetup();
            frmHospStatSetupCopy.Show();
        }

        public void mnuImport_Click(Object eventSender, EventArgs eventArgs)
        {
            frmImportSelectLayout frmImportSelectLayoutCopy = new frmImportSelectLayout();
            frmImportSelectLayoutCopy.Show();
        }

        //Private Sub mnuImportDataDef_Click()
        //
        //    'Open "F:\dev\iha\hosp\hosp00\tempcode.txt" For Output As #1
        //   '
        //   ' gv_sql = "Select tbl_setup_DataDef.* from tbl_setup_DataDef, tbl_setup_TableDef "
        //   ' gv_sql = gv_sql & " where tbl_setup_DataDef.basetableid =  tbl_setup_TableDef.basetableid "
        //   ' gv_sql = gv_sql & " and upper(tbl_setup_TableDef.basetable) = 'HOSPITAL STATISTICS' "
        //   '
        //   ' 'gv_sql = "Select * from tbl_setup_Indicator "
        //   ' Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //   '
        //   '
        //   ' Do While Not gv_rs.EOF
        //   '
        //   '     If Not IsNull(gv_rs!OldFieldName) Then
        //   '
        //   '         msg = "'" & gv_rs!OldFieldName
        //   '         Print #1, msg
        //   '         msg = "DataConv_HospStatImportField " & """" & gv_rs!OldFieldName & """"
        //   '         Print #1, msg
        //   '         msg = ""
        //   '         Print #1, msg
        //   '
        //   '     End If
        //   '     gv_rs.MoveNext
        //   '
        //   ' Loop
        //
        //    'Do While Not gv_rs.EOF
        //    '    If Not IsNull(gv_rs!OldFieldName) Then
        //    '
        //    '        msg = gv_rs!OldFieldName & "_ID = 0 "
        //    '        Print #1, msg
        //    '
        //    '    End If
        //    '    gv_rs.MoveNext
        //    'Loop
        //
        //    'gv_rs.MoveFirst
        //    'Do While Not gv_rs.EOF
        //    '    If Not IsNull(gv_rs!OldFieldName) Then
        //    '
        //    '        msg = "'" & gv_rs!OldFieldName
        //    '        Print #1, msg
        //    '        msg = "SQL = " & """" & "Select * from tbl_sys_datadef" & """"
        //    '        Print #1, msg
        //    '        msg = "SQL = SQL & " & """" & " where OLDFieldName = '" & gv_rs!OldFieldName & "'" & """"
        //    '        Print #1, msg
        //    '        msg = "Set rs = MyDB.OpenRecordset(SQL, DB_OPEN_SNAPSHOT)"
        //    '        Print #1, msg
        //    '        msg = "if rs.recordcount > 0 then "
        //    '        Print #1, msg
        //    '        msg = "     " & gv_rs!OldFieldName & "_DDID = rs!DDID"
        //    '        Print #1, msg
        //    '        msg = "end if"
        //    '        Print #1, msg
        //    '        msg = "rs.Close"
        //    '        Print #1, msg
        //    '        msg = ""
        //    '        Print #1, msg
        //    '    End If
        //   '     gv_rs.MoveNext
        //   ' Loop
        //   ' gv_rs.MoveFirst
        //    'Do While Not gv_rs.EOF
        //    '
        //    '    If Not IsNull(gv_rs!OldFieldName) Then
        //    '
        //    '        msg = "         If (Not IsNull(myRecords!" & gv_rs!OldFieldName & ")) and " & gv_rs!OldFieldName & "_DDID > 0 Then"
        //    '        Print #1, msg
        //    '        msg = "             SQL = " & """" & "Insert into tbl_dat_detaildata (DDID, SUBMISSIONID, FieldValue) " & """"
        //    '        Print #1, msg
        //    '        msg = "             SQL = SQL & " & """" & " values ( " & """" & " & " _
        //'    '                            & gv_rs!OldFieldName & "_DDID & " & """" & "," & """" & " & SUBMISSIONID & " & _
        //'    '                            """" & ",'" & """" & " & " & "MyRecords!" & gv_rs!OldFieldName & " & " & """" & "')" & """"
        //    '        Print #1, msg
        //    '        msg = "             docmd.runsql SQL "
        //    '        Print #1, msg
        //    '        msg = "         End If "
        //    '        Print #1, msg
        //    '        msg = "         "
        //    '        Print #1, msg
        //    '
        //    '    End If
        //    '    gv_rs.MoveNext
        //    'Loop
        //
        //    'Close #1
        //    'End
        //
        //    msg = "This process will remove the current field settings, "
        //    msg = msg & "and import the fields from the previous version." & Chr(13) & Chr(10)
        //    msg = msg & "Are you sure you want to continue?"
        //
        //    resp = MsgBox(msg, vbOKCancel, "Import Database Definition From 99")
        //    If resp = vbOK Then
        //        Screen.MousePointer = 11
        //        On Error GoTo FindFile
        //        CurrentDB = CurDir() & "COPapp99.mdb"
        //        Set COPDB = OpenDatabase(CurrentDB)
        //        On Error GoTo 0
        //        ImportDatabaseDef
        //        Screen.MousePointer = 0
        //    End If
        //Exit Sub
        //FindFile:
        //    On Error GoTo 0
        //    Screen.MousePointer = 0
        //    FileFind.Caption = "Specify the location of COPApp99.mdb"
        //    FileFind.Show 1
        //    If gv_SelectedDirectory <> "" Then
        //        CurrentDB = gv_SelectedDirectory & "\COPapp99.mdb"
        //        Set COPDB = OpenDatabase(CurrentDB)
        //        Me.Refresh
        //        Screen.MousePointer = 11
        //        Resume Next
        //   Else
        //        Exit Sub
        //   End If
        //
        //End Sub


        public void mnuImportRiskCoefficients_Click(Object eventSender,EventArgs eventArgs)
        {
            string TriggerBy2 = null;
            string factorOperator = null;
            string TriggerBy = null;
            int prevCoefID = 0;
            string prevquarter = null;
            int prevreportingperiod = 0;
            double PrevReportingYear = 0;
            int newcoefID = 0;
            SqlCommand ps = new SqlCommand();
            int coefID = 0;
            int commapos = 0;
            string coefficient = null;
            string Description = null;
            string FactorType = null;
            string FactorStatus = null;
            int FactorID = 0;
            string EqType = null;
            int MeasureID = 0;
            int TotalRecs = 0;
            string ReportingQuarter = null;
            int ReportingYear = 0;
            int ReportingPeriod = 0;
            string SQL = null;
            DialogResult resp= 0;
            string Quarter = null;
            var i = 0;
            string textline = null;
            var StartPos = 0;
            string RACOfile = null;
            const string msgtitle = "Load Risk Adjusted Coefficient Data"; 
            int li_PrevQtr = 0;
            int PreviousQtr = 0;
            DataSet rs_CopyCoef = new DataSet();
            string at = null;


            try
            {
                modGlobal.gv_SelectedFileWithPath = "";
                //LDW frmFindAFile.ShowDialog();
                var dialog10 = new OpenFileDialog();
                dialog10.Title = "Specify the source file";
                dialog10.RestoreDirectory = true;
                //dialog1.DefaultExt = "txt";
                dialog10.CheckFileExists = true;
                dialog10.CheckPathExists = true;
                dialog10.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog10.FilterIndex = 2;
                dialog10.ShowReadOnly = true;
                dialog10.ShowDialog();

                if (string.IsNullOrEmpty(modGlobal.gv_SelectedFileWithPath))
                {
                    //LDW RadMessageBox.Show("The 'Coefficient File' was not specified.", , msgtitle);

                    DialogResult ds1 = RadMessageBox.Show(this, "The 'Coefficient File' was not specified.", msgtitle, MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }

                RACOfile = modGlobal.gv_SelectedFileWithPath;

                //get the period of the records, and confirm that user wants to import it
                FileSystem.FileOpen(1, RACOfile, OpenMode.Input);
                if (FileSystem.EOF(1))
                {
                    //LDW RadMessageBox.Show("The file does not contain any data.", , msgtitle);

                    DialogResult ds2 = RadMessageBox.Show(this, "The file does not contain any data.", "Import Risk Coefficients", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                }
                else
                {
                    StartPos = 1;
                    textline = FileSystem.LineInput(1);

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            Quarter = Quarter + Strings.Mid(textline, i, 1);
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    modGlobal.gv_sql = string.Format("select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '{0}'", Quarter);
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName9 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName9, modGlobal.gv_rs);

                    //LDW if (!modGlobal.gv_rs.EOF)
                    foreach (DataRow myRow8 in modGlobal.gv_rs.Tables[sqlTableName9].Rows)
                    {
                        FileSystem.FileClose(1);
                        //LDW resp = RadMessageBox.Show("This period already exists in the database. Are you sure you want to overwrite?", MsgBoxStyle.YesNo, "Import RA Coef.");

                        resp = RadMessageBox.Show(this, "This period already exists in the database. Are you sure you want to overwrite?", "Import Risk Coefficients", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation);
                        this.Text = resp.ToString();

                        if (resp == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            //LDW resp = RadMessageBox.Show("Would you like to remove the values from this period?  If you choose no, then your links will remain in effect but the coefficients will be updated.", MsgBoxStyle.YesNo, "Remove Field Links & Triggers for this period?");

                            resp = RadMessageBox.Show(this, "Would you like to remove the values from this period?  If you choose no, then your links will remain in " +
                                "effect but the coefficients will be updated.", "Import Risk Coefficients", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation);
                            this.Text = resp.ToString();

                            if (resp == DialogResult.Yes)
                            {
                                //tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
                                SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                                SQL = SQL + " where Coefid in ";
                                SQL = string.Format("{0} (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '{1}')", SQL, Quarter);
                                //LDW modGlobal.gv_cn.Execute(SQL);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                                //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                                SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                                SQL = SQL + " where Coefid in ";
                                SQL = string.Format("{0} (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '{1}')", SQL, Quarter);
                                //LDW modGlobal.gv_cn.Execute(SQL);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                                //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                                SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                                SQL = SQL + " where Coefid in ";
                                SQL = string.Format("{0} (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '{1}')", SQL, Quarter);
                                //LDW modGlobal.gv_cn.Execute(SQL);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                                SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                                SQL = string.Format("{0} where Quarter = '{1}'", SQL, Quarter);
                                //LDW modGlobal.gv_cn.Execute(SQL);
                                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            }
                        }
                    }

                    ReportingPeriod = Convert.ToInt32(Strings.Mid(Quarter, 5, 2));
                    ReportingYear = Convert.ToInt32(Strings.Mid(Quarter, 1, 4));
                    ReportingQuarter = string.Format("{0}, {1}", Strings.Mid(Quarter, 5, 2), Strings.Mid(Quarter, 1, 4));

                    //resp = MsgBox("The Coefficients will be imported for this period: " & ReportingQuarter & ". Do you wish to continue?", vbYesNo, msgtitle)
                    //If resp = vbNo Then
                    //    Close #1
                    //    Exit Sub
                    //End If
                }
                FileSystem.FileClose(1);

                Cursor.Current = Cursors.WaitCursor;

                //remove the previous records
                //sql = "delete tIndicatorRiskAdjustmentCoefficientImported where quarter = '" & Quarter & "'"
                //Set ps = gv_cn.CreatePreparedStatement("", sql)
                //ps.Execute
                //ps.Close

                FileSystem.FileOpen(1, RACOfile, OpenMode.Input);
                while (!FileSystem.EOF(1))
                {
                    TotalRecs = TotalRecs + 1;
                    StartPos = 1;
                    Quarter = "";
                    MeasureID = 0;
                    EqType = "";
                    FactorID = 0;
                    FactorStatus = "";
                    FactorType = "";
                    Description = "";
                    coefficient = "";


                    textline = FileSystem.LineInput(1);

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            Quarter = Quarter + Strings.Mid(textline, i, 1);
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            MeasureID = MeasureID + Convert.ToInt32(Strings.Mid(textline, i, 1));
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            EqType = EqType + Strings.Mid(textline, i, 1);
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            FactorID = FactorID + Convert.ToInt32(Strings.Mid(textline, i, 1));
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            FactorStatus = FactorStatus + Strings.Mid(textline, i, 1);
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            FactorType = FactorType + Strings.Mid(textline, i, 1);
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }


                    //if a doublequote exists that means that there is comma in the description
                    // that we have to replace with another character
                    if (Strings.Mid(textline, StartPos, 1) == "\"")
                    {
                        commapos = Strings.InStr(StartPos + 1, textline, ",");
                        //Test = Mid(TextLine, commapos, 1)
                        if (commapos > 0)
                        {
                            //LDW Strings.Mid(textline, commapos, 1) = "@";
                            at = Strings.Mid(textline, commapos, 1);
                        }
                    }
                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            Description = Description + Strings.Mid(textline, i, 1);
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                    Description = Strings.Replace(Description, at, ",");

                    for (i = StartPos; i <= Strings.Len(textline); i++)
                    {
                        if (Strings.Mid(textline, i, 1) != ",")
                        {
                            coefficient = coefficient + Strings.Mid(textline, i, 1);
                        }
                        else
                        {
                            StartPos = i + 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    if (resp == DialogResult.No)
                    {
                        modGlobal.gv_sql = "select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureID = " + MeasureID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and factorid = '" + FactorID + "'";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and Quarter = '" + Quarter + "'";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName10 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName10, modGlobal.gv_rs);

                        foreach (DataRow myRow9 in modGlobal.gv_rs.Tables[sqlTableName10].Rows)
                        {
                            if (myRow9 != null)
                            {
                                coefID = myRow9.Field<int>("coefID");
                            }
                            else
                            {
                                coefID = 0;
                            }
                        }
                        //save this value to copy the factors over for the new coefid
                    }

                    SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                    SQL = SQL + " (Quarter, MeasureID, EqType, FactorID, ";
                    SQL = SQL + " FactorStatus, FactorType, Description, Coefficient) ";
                    SQL = SQL + " values (";
                    SQL = SQL + "'" + Quarter + "', ";
                    SQL = SQL + MeasureID + ",";
                    SQL = SQL + EqType + ",";
                    SQL = SQL + "'" + FactorID + "', ";
                    SQL = SQL + FactorStatus + ",";
                    SQL = SQL + "'" + FactorType + "',";
                    SQL = SQL + "'" + Strings.Replace(Description, "'", "''") + "',";
                    SQL = SQL + coefficient;
                    SQL = SQL + ")";
                    /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                    //g = InputBox("", "", sql)
                    ps.Execute();
                    ps.Close();*/
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                    const string refTblSetup = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                    newcoefID = modGlobal.GetLastID(refTblSetup);

                    if (resp == DialogResult.No)
                    {
                        modGlobal.gv_sql = "select coefid, TriggerBy, TriggerBy2, FactorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where coefID = " + coefID;
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName11 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName11, modGlobal.gv_rs);

                        if (coefID != 0)
                        {
                            /*LDW modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = '" + modGlobal.gv_rs.rdoColumns["TriggerBy"].Value +
                             *  "'" + ", TriggerBy2 = '" + modGlobal.gv_rs.rdoColumns["TriggerBy2"].Value + "', FactorOperator = '" +
                             *   modGlobal.gv_rs.rdoColumns["factorOperator"].Value + "' WHERE CoefID = " + newcoefID;*/
                            modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = '" + modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["TriggerBy"] +
                             "'" + ", TriggerBy2 = '" + modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["TriggerBy2"] + "', FactorOperator = '" +
                             modGlobal.gv_rs.Tables[sqlTableName11].Rows[0]["factorOperator"] + "' WHERE CoefID = " + newcoefID;
                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                            //COPY THE LINKS TO THE NEW COEF VALUE
                            //tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
                            SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                            SQL = SQL + " (CoefID, DDID,tab) ";
                            SQL = SQL + " select " + newcoefID + ", ddid,tab";
                            SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                            SQL = SQL + " where Coefid = " + coefID;
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();*/
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            //
                            //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                            SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                            SQL = SQL + " (CoefID, TriggerValue, tab) ";
                            SQL = SQL + " select " + newcoefID + ", TriggerValue,tab";
                            SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                            SQL = SQL + " where Coefid = " + coefID;
                            /*ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close();*/
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            //
                            //tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks
                            SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                            SQL = SQL + " (CoefID, factorid,factortxt) ";
                            SQL = SQL + " select " + newcoefID + ", factorId, factortxt";
                            SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                            SQL = SQL + " where Coefid = " + coefID;
                            /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                            ps.Execute();
                            ps.Close();*/
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                            //
                            //NOW REMOVE THE OLD VALUES
                            //tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
                            SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                            SQL = SQL + " where Coefid = " + coefID;
                            //LDW modGlobal.gv_cn.Execute(SQL);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            //
                            //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                            SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                            SQL = SQL + " where Coefid = " + coefID;
                            //LDW modGlobal.gv_cn.Execute(SQL);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            //
                            //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                            SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                            SQL = SQL + " where Coefid = " + coefID;
                            //LDW modGlobal.gv_cn.Execute(SQL);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                            //
                            //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                            SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                            SQL = SQL + " where Coefid = " + coefID;
                            //LDW modGlobal.gv_cn.Execute(SQL);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        }
                    }
                }
                FileSystem.FileClose(1);
                //gv_rs.Close


                if (resp != DialogResult.No)
                {
                    modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where Quarter = '" + Quarter + "' AND FactorID <> 'N'";
                    //LDW rs_CopyCoef = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName12 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                    rs_CopyCoef = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName12, rs_CopyCoef);

                    foreach (DataRow myRow10 in rs_CopyCoef.Tables[sqlTableName12].Rows)
                    {
                        MeasureID = myRow10.Field<int>("MeasureID");
                        FactorID = myRow10.Field<int>("FactorID");
                        newcoefID = myRow10.Field<int>("coefID");

                        GetPrevQtr:

                        if (PreviousQtr == 0)
                        {
                            li_PrevQtr = 1;

                            //copy over the child records for existing factors from previous period
                            if (Convert.ToInt16(ReportingPeriod) - li_PrevQtr < 1)
                            {
                                PrevReportingYear = Convert.ToDouble(ReportingYear) - Convert.ToDouble(Convert.ToInt32((li_PrevQtr / 4) + 0.5));
                                prevreportingperiod = 4 - Math.Abs(ReportingPeriod - li_PrevQtr);
                            }
                            else
                            {
                                PrevReportingYear = Convert.ToDouble(ReportingYear);
                                prevreportingperiod = ReportingPeriod - li_PrevQtr;
                            }
                            prevquarter = PrevReportingYear + "0" + prevreportingperiod;
                        }

                        modGlobal.gv_sql = "select coefid, TriggerBy, TriggerBy2, FactorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureID = " + MeasureID;
                        modGlobal.gv_sql = modGlobal.gv_sql + " and factorid = '" + FactorID + "'";
                        modGlobal.gv_sql = modGlobal.gv_sql + " and Quarter = '" + prevquarter + "'";
                        //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName13 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                        modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName13, modGlobal.gv_rs);

                        //LDW if (modGlobal.gv_rs.EOF)
                        for (int itr = 0; itr < modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count; itr++)
                        {
                            var myRow = modGlobal.gv_rs.Tables[sqlTableName13].Rows[itr];
                            int rowIndex = modGlobal.gv_rs.Tables[sqlTableName13].Rows.IndexOf(myRow);
                            int rowLast = modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count - 1;

                            if (rowIndex == rowLast)
                            {
                                if (PreviousQtr == 0)
                                {
                                    li_PrevQtr = li_PrevQtr + 1;

                                    if (li_PrevQtr < 10)
                                        goto GetPrevQtr;
                                }
                            }
                            else
                            {
                                /*LDW modGlobal.gv_rs.MoveLast();
                                modGlobal.gv_rs.MoveFirst();*/
                                itr = modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count - 1;
                                itr = 0;

                                if (PreviousQtr == 0)
                                {
                                    PreviousQtr = li_PrevQtr;
                                }

                                if (modGlobal.gv_rs.Tables[sqlTableName13].Rows.Count > 0)
                                {
                                    foreach (DataRow myRow11 in modGlobal.gv_rs.Tables[sqlTableName13].Rows)
                                    {
                                        prevCoefID = myRow11.Field<int>("coefID");
                                        TriggerBy = myRow11.Field<string>("TriggerBy");
                                        factorOperator = myRow11.Field<string>("factorOperator");
                                        TriggerBy2 = myRow11.Field<string>("TriggerBy2");
                                    }

                                    //update TriggerBy in tbl_Setup_IndicatorRiskAdjustmentCoefficients for the new record
                                    SQL = "update tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                                    SQL = SQL + " set TriggerBy = '" + TriggerBy + "', TriggerBy2 = '" + TriggerBy2 + "', FactorOperator = '" + factorOperator + "'";
                                    SQL = SQL + " where Coefid = " + newcoefID;
                                    /*ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                                    ps.Execute();
                                    ps.Close();*/
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                                    //
                                    //tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
                                    SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                                    SQL = SQL + " (CoefID, DDID,tab) ";
                                    SQL = SQL + " select " + newcoefID + ", ddid,tab";
                                    SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                                    SQL = SQL + " where Coefid = " + prevCoefID;
                                    /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                                    ps.Execute();
                                    ps.Close();*/
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                                    //
                                    //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                                    SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                                    SQL = SQL + " (CoefID, TriggerValue, tab) ";
                                    SQL = SQL + " select " + newcoefID + ", TriggerValue,tab";
                                    SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                                    SQL = SQL + " where Coefid = " + prevCoefID;
                                    /*ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                                    ps.Execute();
                                    ps.Close();*/
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                                    //
                                    //tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks
                                    SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                                    SQL = SQL + " (CoefID, factorid,factortxt) ";
                                    SQL = SQL + " select " + newcoefID + ", factorID, factortxt";
                                    SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                                    SQL = SQL + " where Coefid = " + prevCoefID;
                                    /*ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
                                    ps.Execute();
                                    ps.Close();*/
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                                }
                            }
                        }
                        //LDW rs_CopyCoef.MoveNext();
                    }
                    rs_CopyCoef.Dispose();
                }

                //    SQL = "UPDATE tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks "
                //    SQL = SQL & " Set factorid = (SELECT coefID " & _
                //'            " FROM tbl_Setup_IndicatorRiskAdjustmentCoefficients " & _
                //'            " Where tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks.factortxt = tbl_Setup_IndicatorRiskAdjustmentCoefficients.FactorID " & _
                //'            " AND  tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks.coefID = tbl_Setup_IndicatorRiskAdjustmentCoefficients.coefID " & _
                //'            " AND Quarter = '" & quarter & "') "
                //    SQL = SQL & " Where coefID in (SELECT coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients " & _
                //'            " WHERE Quarter = '" & quarter & "')"
                //    Set ps = gv_cn.CreatePreparedStatement("", SQL)
                //    ps.Execute
                //    'Debug.Print SQL
                //
                //    ps.Close

                modGlobal.gv_sql = "DELETE FROM tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing WHERE Quarter = '" + Quarter + "'";
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing (factorid, Method, Quarter)";
                modGlobal.gv_sql = modGlobal.gv_sql + " SELECT factorid, Method, '" + Quarter + "' FROM tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing WHERE Quarter = '" + prevquarter + "'";
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                Cursor.Current = Cursors.Default;

                //LDW RadMessageBox.Show("Import Complete.");

                DialogResult ds30 = RadMessageBox.Show(this, "Import Complete.", "Import Risk Coefficients", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.Text = ds30.ToString();
                return;
                //LDW ErrHandler:
                //LDW modGlobal.CheckForErrors();

                FileSystem.FileClose(1);
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

        public void mnuImpVerifyRecords_Click(Object eventSender, EventArgs eventArgs)
        {
            frmImportMeasureSetFile frmImportMeasureSetFileCopy = new frmImportMeasureSetFile();
            frmImportMeasureSetFileCopy.Show();
        }

        public void mnuIndicatorReportSetup_Click(Object eventSender,EventArgs eventArgs)
        {
            frmIndicatorReportSetup frmIndicatorReportSetupCopy = new frmIndicatorReportSetup();
            frmIndicatorReportSetupCopy.Show();
        }

        public void mnuIndicatorSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmIndicatorSetup frmIndicatorSetupCopy = new frmIndicatorSetup();
            frmIndicatorSetupCopy.Show();
        }

        public void mnuLoadCMSSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                modGlobal.ImportCMSSetup();
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

        public void mnuLookupTableSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmLookupSetup frmLookupSetupCopy = new frmLookupSetup();
            frmLookupSetupCopy.Show();
        }

        //private void mnuMapMeasure_Click(Object eventSender, EventArgs eventArgs)
        //{
        //    frmMapMeasures.Show();
        //}

        public void mnuMeasureSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmMeasureSetup frmMeasureSetupCopy = new frmMeasureSetup();
            frmMeasureSetupCopy.Show();
        }

        public void mnuPatientfieldExportFormat_Click(Object eventSender, EventArgs eventArgs)
        {
            frmPatientFieldsExportFormat frmPatientFieldsExportFormatCopy = new frmPatientFieldsExportFormat();
            frmPatientFieldsExportFormatCopy.Show();
        }

        public void mnuPatientSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmPatientSetup frmPatientSetupCopy = new frmPatientSetup();
            frmPatientSetupCopy.Show();
        }

        /* Unused click event
        private void mnuSecIndFieldSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            
            DialogResult ds10 = RadMessageBox.Show(this, "This feature will be coming soon.  Stay tuned :)...", "Second Indicator Field Setup", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            this.Text = ds10.ToString();
        } */

        //Private Sub mnuSetupNewDB_Click()
        //
        //    msg = "This process will reset the current field settings, "
        //    msg = msg & "in the new version of COP Access database." & Chr(13) & Chr(10)
        //    msg = msg & "Are you sure you want to continue?"
        //
        //    resp = MsgBox(msg, vbOKCancel, "Setup New Access COP Database")
        //    If resp = vbOK Then
        //        Screen.MousePointer = 11
        //        SetupNewSystem
        //        Screen.MousePointer = 0
        //    End If
        //
        //End Sub

        public void mnuReportSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmReportSetup frmReportSetupCopy = new frmReportSetup();
            //MsgBox "Not Ready"
            //Exit Sub
            frmReportSetupCopy.Show();
        }

        public void mnuRiskFactorAssociation_Click(Object eventSender, EventArgs eventArgs)
        {
            frmRiskAdjustment frmRiskAdjustmentCopy = new frmRiskAdjustment();
            frmRiskAdjustmentCopy.Show();
        }

        public void mnuRiskSpecs_Click(Object eventSender, EventArgs eventArgs)
        {
            string Quarter = null;
            string msgtitle = null;
            DataSet rs_JCAHOID = new DataSet();
            string thisquarter = null;

            try
            {

                msgtitle = "Load Risk Factor Specs";

                //LDW Quarter = RadInputBox.Show("Enter the quarter effective for these risk specifications (i.e. 1Q2014).", "Risk Specs Import", thisquarter);

                Quarter = RadInputBox.Show("Enter the quarter effective for these risk specifications (i.e. 1Q2014).", "Risk Specs Import", thisquarter);
                Quarter = "0" + Quarter;
                Quarter = Strings.Mid(Quarter, 3, Strings.Len(Quarter)) + Strings.Left(Quarter, 2);
                Quarter = Strings.Replace(Quarter, "Q", "");

                modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '" + Quarter + "'";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName14 = "tbl_Setup_IndicatorRiskAdjustmentCoefficients";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName14, modGlobal.gv_rs);

                //LDW if (modGlobal.gv_rs.EOF)
                for (int itr1 = 0; itr1 < modGlobal.gv_rs.Tables[sqlTableName14].Rows.Count; itr1++)
                {
                    var myRow13 = modGlobal.gv_rs.Tables[sqlTableName14].Rows[itr1];
                    int rowIndex = modGlobal.gv_rs.Tables[sqlTableName14].Rows.IndexOf(myRow13);
                    int rowLast = modGlobal.gv_rs.Tables[sqlTableName14].Rows.Count - 1;

                    if (rowIndex == rowLast)
                    {
                        //LDW RadMessageBox.Show("The coeficients have not been entered for this quarter.");
                        DialogResult ds3 = RadMessageBox.Show(this, "The coeficients have not been entered for this quarter.", "Import Risk Factor Specifications", MessageBoxButtons.OK, RadMessageIcon.Error);
                        this.Text = ds3.ToString();
                    }
                    return;
                }

                modGlobal.gv_SelectedFileWithPath = "";
                /*LDW My.MyProject.Forms.frmFindAFile.cmbType.SelectedIndex = 2;
                My.MyProject.Forms.frmFindAFile.ShowDialog();*/
                var dialog2 = new OpenFileDialog();
                dialog2.ShowDialog();

                if (string.IsNullOrEmpty(modGlobal.gv_SelectedFileWithPath))
                {
                    //LDW RadMessageBox.Show("The 'Risk Specs' was not specified.", , msgtitle);

                    DialogResult dss = RadMessageBox.Show(this, "The 'Risk Specs' was not specified.", "Import Risk Factor Specifications", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = dss.ToString();
                    return;
                }

                FileSystem.FileCopy(modGlobal.gv_SelectedFileWithPath, "\\\\CREATIVE\\RiskFile\\RFS.xls");

                Cursor.Current = Cursors.WaitCursor;

                int TotalRecs = 0;
                //Dim dbtmp As DAO.Database
                //Dim tblObj As DAO.TableDef

                DataSet rsMeasures = new DataSet();
                DataSet rsData = new DataSet();
                int JCAHOID = 0;
                int X = 0;
                string[] Columns = null;
                string MeasureName = null;
                string SQL = null;
                DataSet rs_CoefID = new DataSet();
                string ls_RightCoef = null;
                string ls_LeftCoef = null;
                int li_UnderscorePos = 0;
                int li_CoefID = 0;
                SqlCommand ps = new SqlCommand();

                try
                {
                    modGlobal.gv_sql = "EXEC LoadRiskFile";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                catch (SqlException ex)
                {
                    if (ex.ErrorCode != 14243)
                    {
                        //goto ErrHandler;
                    }
                    else
                    {
                        ex.Data.Clear();
                    }
                }
                //Set dbtmp = OpenDatabase(gv_SelectedFileWithPath, False, True, "Excel 8.0;")

                Application.DoEvents();

                //Set rsMeasures = dbtmp.OpenRecordset("SELECT DISTINCT [Measure], [Model Application Date], [Risk Factor] FROM `Sheet1$`")
                //LDW rsMeasures = modGlobal.gv_cn.OpenResultset("SELECT DISTINCT Measure, RiskFactor FROM RiskFileSheet", RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName15 = "";
                const string tempSQL = "SELECT DISTINCT Measure, RiskFactor FROM RiskFileSheet";
                rsMeasures = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, tempSQL, sqlTableName15, rsMeasures);

                //Set rsMeasures = dbtmp.OpenRecordset("SELECT DISTINCT [Measure], [Model Application Date], [Risk Factor] FROM `Sheet1$`")
                //LDW while (!rsMeasures.EOF)
                foreach (DataRow myRow16 in rsMeasures.Tables[sqlTableName15].Rows)
                {
                    MeasureName = Strings.Mid(myRow16.Field<string>("Measure"), Strings.InStr(1, myRow16.Field<string>("Measure"), "(") + 1,
                        Strings.InStr(1, myRow16.Field<string>("Measure"), ")") - Strings.InStr(1, myRow16.Field<string>("Measure"), "(") - 1);
                    modGlobal.gv_sql = "select jcahoid from tbl_setup_indicator where jccode = '" + MeasureName + "' AND JCAHOID IS NOT NULL";
                    //LDW rs_JCAHOID = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName16 = "tbl_setup_indicator";
                    rs_JCAHOID = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName16, rs_JCAHOID);
                    //LDW if (!rs_JCAHOID.EOF)
                    foreach (DataRow myRow17 in rs_JCAHOID.Tables[sqlTableName16].Rows)
                    {
                        //If InStr(1, rsMeasures.Fields(2), "RF36") = 0 And InStr(1, rsMeasures.Fields(2), "NBW") = 0 Then
                        JCAHOID = myRow17.Field<int>("JCAHOID");
                        //quarter = rsMeasures.Fields(1)

                        //quarter = "0" & quarter
                        //quarter = mid(quarter, 3, Len(quarter)) & Left(quarter, 2)
                        //quarter = Replace(quarter, "Q", "")

                        //tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
                        SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
                        SQL = SQL + " where Coefid in ";
                        SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID + "    AND FACTORID NOT LIKE 'RF36%' AND FACTORID NOT LIKE 'NBW%')";
                        //LDW modGlobal.gv_cn.Execute(SQL);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                        //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                        SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
                        SQL = SQL + " where Coefid in ";
                        SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID + "    AND FACTORID NOT LIKE 'RF36%' AND FACTORID NOT LIKE 'NBW%')";
                        //LDW modGlobal.gv_cn.Execute(SQL);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                        //tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
                        SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
                        SQL = SQL + " where Coefid in ";
                        SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID + "    AND FACTORID NOT LIKE 'RF36%' AND FACTORID NOT LIKE 'NBW%')";
                        //LDW modGlobal.gv_cn.Execute(SQL);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);

                        //UPDATE ALL THE TriggerBys to CONTAINS for the appropriate risk factors
                        SQL = "UPDATE tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
                        SQL = SQL + " SET triggerBy = 'Contains' where Coefid in ";
                        SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID;
                        SQL = SQL + "  AND charindex('AGE', FactorID) = 0 ";
                        SQL = SQL + "   AND charindex('_', FactorID) = 0 ";
                        SQL = SQL + "   AND FactorID <> 'N' ";
                        SQL = SQL + "   AND FACTORID NOT LIKE 'RF36%' ";
                        SQL = SQL + "   AND FACTORID NOT LIKE 'NBW%')";
                        //LDW modGlobal.gv_cn.Execute(SQL);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, SQL);
                        //End If            'Debug.Print sql
                    }
                    rs_JCAHOID.Dispose();
                    //LDW rsMeasures.MoveNext();
                }
                rsMeasures.Dispose();

                //LDW rsData = modGlobal.gv_cn.OpenResultset("SELECT * FROM RiskFileSheet", RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName17 = "RiskFileSheet";
                const string tempSQL2 = "SELECT * FROM RiskFileSheet";
                rsData = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, tempSQL2, sqlTableName17, rsData);
                //dbtmp.OpenRecordset("select * from `Sheet1$`")

                //If rsData.Fields.Count <> 11 Then
                //    MsgBox "This is an invalid file"
                //Else
                //LDW while (!rsData.EOF)
                foreach (DataRow myRow18 in rsData.Tables[sqlTableName17].Rows)
                {
                    /*MeasureName = Strings.Mid(rsData.rdoColumns["Measure"].Value, Strings.InStr(1, rsData.rdoColumns["Measure"].Value, "(") +
                     *1, Strings.InStr(1, rsData.rdoColumns["Measure"].Value, ")") - Strings.InStr(1, rsData.rdoColumns["Measure"].Value, "(") - 1);*/
                    MeasureName = Strings.Mid(myRow18.Field<string>("Measure"), Strings.InStr(1, myRow18.Field<string>("Measure"), "(") + 1,
                    Strings.InStr(1, myRow18.Field<string>("Measure"), ")") - Strings.InStr(1, myRow18.Field<string>("Measure"), "(") - 1);

                    modGlobal.gv_sql = "select jcahoid from tbl_setup_indicator where jccode = '" + MeasureName + "' AND JCAHOID IS NOT NULL";
                    //LDW rs_JCAHOID = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName18 = "tbl_setup_indicator";
                    string tempSQL3 = "select jcahoid from tbl_setup_indicator where jccode = '" + MeasureName + "' AND JCAHOID IS NOT NULL";
                    rs_JCAHOID = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, tempSQL3, sqlTableName18, rs_JCAHOID);

                    //LDW if (!rs_JCAHOID.EOF)
                    foreach (DataRow myRow19 in rs_JCAHOID.Tables[sqlTableName18].Rows)
                    {
                        JCAHOID = myRow19.Field<int>("JCAHOID");
                        rs_JCAHOID.Dispose();

                        //quarter = rsData.Fields(6)

                        //quarter = "0" & quarter
                        //quarter = mid(quarter, 3, Len(quarter)) & Left(quarter, 2)
                        //quarter = Replace(quarter, "Q", "")


                        //gv_sql = "select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where "
                        //    " quarter = '" & quarter & "' and factorid = '" & rsData!RiskFactor & "' AND measureID = " & JCAHOID
                        //Set rs_CoefID = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                        //If Not rs_CoefID.EOF Then
                        //    li_CoefID = rs_CoefID!coefID
                        //    rs_CoefID.Close

                        // these are hardcoded triggers
                        if (string.IsNullOrEmpty(myRow18.Field<string>("CMCode")) | Information.IsDBNull(myRow18.Field<string>("CMCode")))
                        {
                            switch (Strings.Trim(Strings.UCase(myRow18.Field<string>("RiskFactor"))))
                            {
                                case "AGET1744":
                                    /*LDW modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Patient Age Is' WHERE coefID in " +
                                     *  " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                     *   myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID + ")";*/
                                    modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Patient Age Is' WHERE coefID in " +
                                   " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                   myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID + ")";

                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 17,1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 17,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;

                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 44, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 44,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 1, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 1,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 3, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 3,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;

                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                    break;
                                case "ADMSRC56":
                                    modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Contains' WHERE coefID  in " +
                                        " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID + ")";
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 5,1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 5,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 6, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 6,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 16, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 16,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                    break;

                                case "SEXR":
                                    modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Contains' WHERE coefID  in " +
                                        " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID + ")";
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 'F',1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 'F',1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 4, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 4,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;

                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                    break;

                                case "MAGE16L":
                                    modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Is Less Than' WHERE coefID   in " +
                                        " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID + ")";
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 17,1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 17,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 1, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 1,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 3, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 3,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                    break;

                                case "AGEINT":
                                    modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Patient Age Is' WHERE coefID  in " +
                                        " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID + ")";

                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
                                    //                            gv_sql = gv_sql & " Values (" & li_CoefID & ", 'Integer',1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 'Integer',1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 3, 1)"
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 3,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                                    modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
                                    modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 244,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" +
                                        myRow18.Field<string>("RiskFactor") + "' AND measureID = " + JCAHOID;
                                    //gv_sql = gv_sql & " Values (" & li_CoefID & ", 244, 1)"
                                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                    break;

                                default:
                                    li_UnderscorePos = Strings.InStr(1, myRow18.Field<string>("RiskFactor"), "_");
                                    //this is for the multiplers
                                    if (li_UnderscorePos > 0)
                                    {
                                        ls_LeftCoef = Strings.Mid(myRow18.Field<string>("RiskFactor"), 1, li_UnderscorePos - 1);
                                        ls_RightCoef = Strings.Mid(myRow18.Field<string>("RiskFactor"), li_UnderscorePos + 1, Strings.Len(myRow18.Field<string>("RiskFactor")));

                                        /*LDW modGlobal.gv_sql = "{ ? = call INSERTFactorLink(?,?,?) }";
                                        ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                                        ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                                        ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                                        ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
                                        ps.rdoParameters[3].Direction = RDO.DirectionConstants.rdParamInput;
                                        ps.rdoParameters[1].Value = myRow18.Field<string>("RiskFactor");
                                        //li_CoefID
                                        ps.rdoParameters[2].Value = ls_LeftCoef;
                                        ps.rdoParameters[3].Value = ls_RightCoef;
                                        ps.Execute();
                                        ps.Close(); */
                                        ps.Connection = modGlobal.gv_cn;
                                        ps.CommandType = CommandType.StoredProcedure;
                                        ps.CommandText = "INSERTFactorLink";
                                        var inParam1 = new SqlParameter("@FactorID", myRow18.Field<string>("RiskFactor"));
                                        inParam1.Direction = ParameterDirection.Input;
                                        inParam1.DbType = DbType.String;
                                        ps.Parameters.Add(inParam1);
                                        var inParam2 = new SqlParameter("@LeftFactor", ls_LeftCoef);
                                        inParam2.Direction = ParameterDirection.Input;
                                        inParam2.DbType = DbType.String;
                                        ps.Parameters.Add(inParam2);
                                        var inParam3 = new SqlParameter("@RightFactor", ls_RightCoef);
                                        inParam3.Direction = ParameterDirection.Input;
                                        inParam3.DbType = DbType.String;
                                        ps.Parameters.Add(inParam3);
                                        SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                                        retParam1.Direction = ParameterDirection.ReturnValue;
                                        try
                                        {
                                            ps.Connection.Open();
                                            ps.ExecuteNonQuery();
                                        }
                                        catch (Exception exx)
                                        {
                                            MessageBox.Show("Error while opening connection: " + exx.Message);
                                        }
                                        finally
                                        {
                                            ps.Dispose();
                                        }

                                        //Else
                                        //MsgBox rsData!RiskFactor & " does not have a type and is not part of the hardcoded triggers.  Please fix before loading!", vbCritical, "There is a NEW trigger"
                                        //Exit Sub
                                    }
                                    break;
                            }
                            // these are NOT hardcoded triggers, use definitions in file
                        }
                        else
                        {
                            /*LDW modGlobal.gv_sql = "{ ? = call INSERTTrigger(?,?,?) }";
                            ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                            ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                            ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                            ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
                            ps.rdoParameters[3].Direction = RDO.DirectionConstants.rdParamInput;
                            ps.rdoParameters[1].Value = myRow18.Field<string>("RiskFactor");
                            //li_CoefID
                            ps.rdoParameters[2].Value = rsData.rdoColumns["CMCode"].Value;
                            ps.rdoParameters[3].Value = rsData.rdoColumns["Type"].Value;
                            ps.Execute();
                            ps.Close();*/
                            ps.Connection = modGlobal.gv_cn;
                            ps.CommandType = CommandType.StoredProcedure;
                            ps.CommandText = "INSERTTrigger";
                            var inParam1 = new SqlParameter("@FactorID", myRow18.Field<string>("RiskFactor"));
                            inParam1.Direction = ParameterDirection.Input;
                            inParam1.DbType = DbType.String;
                            ps.Parameters.Add(inParam1);
                            var inParam2 = new SqlParameter("@TriggerValue", myRow18.Field<string>("CMCode"));
                            inParam2.Direction = ParameterDirection.Input;
                            inParam2.DbType = DbType.String;
                            ps.Parameters.Add(inParam2);
                            var inParam3 = new SqlParameter("@Type", myRow18.Field<string>("Type"));
                            inParam3.Direction = ParameterDirection.Input;
                            inParam3.DbType = DbType.String;
                            ps.Parameters.Add(inParam3);
                            SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                            retParam1.Direction = ParameterDirection.ReturnValue;
                            try
                            {
                                ps.Connection.Open();
                                ps.ExecuteNonQuery();
                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show("Error while opening connection: " + exx.Message);
                            }
                            finally
                            {
                                ps.Dispose();
                            }
                        }
                        //Else ' no matching coefficients
                        //    rs_CoefID.Close

                        //IGNORE JCAHO's stupidity of putting specs into a file for coefficients they don't even use
                        //MsgBox rsData!RiskFactor & " does not exist in coefficient list for " & JCAHOID & " and " & quarter & ".  Please check that the risk coefficients were loaded before loading specs!", vbCritical, "There is a NEW spec"
                        //Exit Sub
                        //End If
                    }
                    //LDW rsData.MoveNext();
                }
                //End If
                rsData.Dispose();

                Cursor.Current = Cursors.Default;

                //LDW RadMessageBox.Show("Load completed successfully");

                DialogResult ds31 = RadMessageBox.Show(this, "Load completed successfully", "Import Risk Factor Specifications", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.Text = ds31.ToString();

                return;
                //LDW ErrHandler:
                //LDW modGlobal.CheckForErrors();
                Cursor.Current = Cursors.Default;
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

        public void mnuSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmSetupVersion frmSetupVersionCopy = new frmSetupVersion();
            frmSetupVersionCopy.Show();
        }

        //private void mnuSetupVersion_Click()
        //{
        //}

        public void mnuSoftwareVer_Click(Object eventSender, EventArgs eventArgs)
        {
            frmAbout frmAboutCopy = new frmAbout();
            frmAboutCopy.Show();
        }

        public void mnuStateSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmSetupStateVersion frmSetupStateVersionCopy = new frmSetupStateVersion();
            frmSetupStateVersionCopy.Show();
        }

        public void mnuSubmitSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmSubmissionSetup frmSubmissionSetupCopy = new frmSubmissionSetup();
            frmSubmissionSetupCopy.Show();
        }

        public void mnuTabFieldValidSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmTableSetup frmTableSetupCopy = new frmTableSetup();
            frmTableSetupCopy.Show();
        }

        public void InitializeTableDef()
        {
            int NextNewID;
            string COPTableName = null;
            string SQLFieldName = null;
            string SQLTableName = null;


            try
            {
                SQLTableName = "tbl_setup_TableDef";
                SQLFieldName = "BaseTableID";
                COPTableName = "HOSPITAL DEMOGRAPHICS";

                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','DATA','Y','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "HOSPITAL STATISTICS";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','DATA','Y','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                //SH - commented out physical name 11.23.04
                COPTableName = "PATIENT";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                // , PhysicalTableName)"
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','DATA','Y','Y')", modGlobal.gv_sql, NextNewID, COPTableName);
                // ,'PatientRecordMaster')"
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "ADMISSION SOURCE LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "DISCHARGE DISPOSITION LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "ASA SCORE LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "READMISSION REASON LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "ADMISSION REFERRAL SOURCE LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "ADMISSION LEGAL STATUS LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "ADMISSION PAYOR LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "ADMISSION TRANSFER REASON LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "PREVIOUS ADMISSION REFERRAL SOURCE LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                //
                COPTableName = "PREVIOUS ADMISSION LEGAL STATUS LIST";
                NextNewID = modDBSetup.FindMaxRecID(SQLTableName, SQLFieldName);
                modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','LOOKUP','N','N')", modGlobal.gv_sql, NextNewID, COPTableName);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
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

        //Record_ID   Number (Long)   4
        //MEDICAL_RECORD_ID   Text    11
        //ADMISSION_DATE  Date/Time   8
        //DISCHARGE_DATE  Date/Time   8
        //BIRTH_DATE  Date/Time   8
        //SEX Text    1
        //ATTEND_PHYSICIAN_ID Text    6
        //DRG Text    3
        //PRINCIPAL_DIAGNOSIS Text    6
        //SEC_DIAGNOSIS_2 Text    6
        //SEC_DIAGNOSIS_3 Text    6
        //SEC_DIAGNOSIS_4 Text    6
        //SEC_DIAGNOSIS_5 Text    6
        //SEC_DIAGNOSIS_6 Text    6
        //SEC_DIAGNOSIS_7 Text    6
        //SEC_DIAGNOSIS_8 Text    6
        //SEC_DIAGNOSIS_9 Text    6
        //ADMISSION_SOURCE    Number (Integer)    2
        //DISCHARGE_DISPOSITION   Number (Integer)    2
        //NEONATAL_BIRTH_WEIGHT   Number (Integer)    2
        //BH_UNIT_INPAT   Text    1
        //HOSP_ACQUIRED_INFECTION Text    1
        //POST_OP_PNEUM   Number (Integer)    2
        //POST_OP_PNEUM_CABG  Number (Integer)    2
        //VENT_PNEUM_ADULT_ICU    Number (Integer)    2
        //VENT_PNEUM_ADULT_ICU_UNIT   Number (Integer)    2
        //VENT_PNEUM_ADULT_ICU_DAYS   Number (Long)   4
        //VENT_PNEUM_NEONATAL_ICU Number (Integer)    2
        //VENT_PNEUM_NEONATAL_ICU_DAYS    Number (Long)   4
        //INPAT_SURG_SITE_CLASS1  Number (Integer)    2
        //INPAT_SURG_SITE_CLASS2  Number (Integer)    2
        //INPAT_SURG_SITE_C1_RISK Number (Integer)    2
        //INPAT_SURG_SITE_C2_RISK Number (Integer)    2
        //SEL_INPAT_SURG_SITE Number (Integer)    2
        //SEL_INPAT_SURG_SITE_RISK    Number (Integer)    2
        //SEL_INPAT_SURG_SITE_PROC    Text    5
        //SEL_INPAT_SURG_SITE_ICD9    Text    10
        //SEL_OUTPAT_SURG_SITE    Number (Integer)    2
        //SEL_OUTPAT_SURG_SITE_RISK   Number (Integer)    2
        //SEL_OUTPAT_SURG_SITE_PROC   Text    5
        //SEL_OUTPAT_SURG_SITE_ICD9   Text    10
        //PRIM_BLOOD_INFECTION    Number (Integer)    2
        //CENT_LINE_BACT_ADULT_ICU    Number (Integer)    2
        //CENT_LINE_BACT_ADULT_UNIT   Number (Integer)    2
        //CENT_LINE_BACT_ADULT_DAYS   Number (Long)   4
        //CENT_LINE_BACT_NEO_ICU  Number (Integer)    2
        //CENT_LINE_BACT_NEO_DAYS Number (Long)   4
        //ENDOM_FOLLOW_C_SECTION  Number (Integer)    2
        //PRIOR_AMBUL_EXT_STAY    Text    1
        //PRIOR_AMBUL_EXT_STAY_REASON Number (Integer)    2
        //PRIOR_AMBUL_SURG_DATE   Date/Time   8
        //PRIOR_AMBUL_PRINC_PROC  Text    6
        //PRIOR_AMBUL_SECOND_PROC Text    6
        //PRIOR_AMBUL_ATTEND_PHYS_ID  Text    6
        //PRIOR_AMBUL_SURG_SURGEON    Text    6
        //PRIOR_AMBUL_SURG_ANESTHES   Text    6
        //PRIOR_AMBUL_ANESTHES_TYPE   Text    1
        //SURG_PERFORMED  Text    1
        //SURG_ASASCORE   Number (Integer)    2
        //SURG_LAST_INVASIVE_DATE Date/Time   8
        //SURG_ASA_SCORE_EMERGENT Text    1
        //SURG_PRINC_PROC Text    6
        //SURG_SECOND_PROC2   Text    6
        //SURG_SECOND_PROC3   Text    6
        //SURG_SECOND_PROC4   Text    6
        //SURG_SECOND_PROC5   Text    6
        //SURG_SECOND_PROC6   Text    6
        //SURG_SURGN_ID   Text    6
        //SURG_ANESTHES_ID    Text    6
        //SURG_ANESTHES_TYPE  Text    1
        //SURG_UNSCHED_RETURN_OR_OB   Text    1
        //SURG_UNSCHED_RETURN_REASON  Number (Integer)    2
        //SURG_RET_REASON_POSTOP_HEMOR    Number (Double) 8
        //SURG_RET_REASON_WOUND_DEHIS Number (Double) 8
        //SURG_RET_REASON_REV_ORIGPROC    Number (Double) 8
        //SURG_RET_REASON_UNDET_OTHER Number (Double) 8
        //RE_ADMISSION    Text    1
        //RE_ADMISSION_REASON Number (Integer)    2
        //RE_ADM_PRIOR_DISCHARGE_DATE Date/Time   8
        //RE_ADM_PRIOR_ATTEND_PHYS_ID Text    6
        //RE_ADM_PRIOR_SURG_ID    Text    6
        //RE_ADM_PRIOR_ANESTHES_ID    Text    6
        //RE_ADM_PRIOR_ADM_DRG    Text    3
        //RE_ADM_CSEC_VBAC    Number (Integer)    2
        //BH_ADM_REF_SOURCE   Number (Integer)    2
        //BH_ADM_LEGAL_STATUS Number (Integer)    2
        //BH_ADM_PAYOR    Number (Integer)    2
        //BH_ADM_DEPARTURE    Text    1
        //BH_ADM_TRANSFER Text    1
        //BH_ADM_TRANSFER_REASON  Number (Integer)    2
        //BH_ADM_POST_DISCH_OUTPAT_SESS   Text    1
        //BH_RE_ADM   Text    1
        //BH_RE_ADM_DATE  Date/Time   8
        //BH_RE_ADM_ATTEND_PHYS_ID    Text    6
        //BH_RE_ADM_SERVICE_USED  Number (Integer)    2
        //BH_RE_ADM_REF_SOURCE    Number (Integer)    2
        //BH_RE_ADM_LEGAL_STATUS  Number (Integer)    2
        //PRINC_DIAG_DX_PRESENT   Text    1
        //SEC_DIAG2_DX_PRESENT    Text    1
        //SEC_DIAG3_DX_PRESENT    Text    1
        //SEC_DIAG4_DX_PRESENT    Text    1
        //SEC_DIAG5_DX_PRESENT    Text    1
        //SEC_DIAG6_DX_PRESENT    Text    1
        //SEC_DIAG7_DX_PRESENT    Text    1
        //SEC_DIAG8_DX_PRESENT    Text    1
        //SEC_DIAG9_DX_PRESENT    Text    1
        //HOSP_ACQUIRED_INFECTION_DATE    Date/Time   8
        //HOSP_CUSTOM_FIELD1  Text    15
        //HOSP_CUSTOM_FIELD2  Text    15
        //HOSP_CUSTOM_FIELD3  Text    15
        //COP_CUSTOM_FIELD1   Text    15
        //COP_CUSTOM_FIELD2   Text    15
        //COP_CUSTOM_FIELD3   Text    15
        //Update_Date Text    50
        //Update_Method   Text    50

        //Public Sub UpdateFieldList(OldTableName, NewTableName)
        //    Dim COPDB As Database
        //    Dim coprs As Recordset
        //    Dim wrkODBC As Workspace
        //    Dim dbsNew As Database
        //    Dim prpLoop As Property
        //    Dim tbldef As TableDef
        //
        //
        //   ' Set wrkODBC = CreateWorkspace("", "admin", "", dbUseODBC)
        //   ' Set COPdb = wrkODBC.OpenConnection("Connection1", , , _
        //'   '   "ODBC;DATABASE=COPapp00;UID=Admin;PWD=;DSN=COPApp00")
        //
        //
        //    Set COPDB = OpenDatabase(CurrentDB)
        //
        //  '
        //  ' 'set tbldef = copdb.Connection.
        //  '
        //   Set coprs = COPDB.OpenRecordset("Select * from " & OldTableName)
        //  '
        //  '**** Warning: this needs to be removed before delivery"
        //   'gv_sql = "delete tbl_setup_FixFields "
        //   'gv_cn.Execute gv_sql
        //
        //   'if tablename doesn't exist in the list, add it
        //   gv_sql = "Select * from tbl_setup_TableDef "
        //   gv_sql = gv_sql & " where upper(BaseTable) = upper('" & NewTableName & "')"
        //   Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //
        //
        //   If gv_rs.RowCount = 0 Then
        //      'add the table name first
        //      NextNewID = FindMaxRecID("tbl_setup_tabledef", "BaseTableID")
        //      gv_sql = "Insert into tbl_setup_tabledef(BaseTableID, BaseTable, TableType, OldTableName, HasFixField )"
        //      gv_sql = gv_sql & " values (" & NextNewID & ",upper('" & NewTableName & "'),'DATA',upper('" & OldTableName & "'),'Y')"
        //      gv_cn.Execute gv_sql
        //      'get the id of the new table
        //      gv_sql = "Select * from tbl_setup_TableDef "
        //      gv_sql = gv_sql & " where upper(BaseTable) = upper('" & NewTableName & "')"
        //      Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //      TID = gv_rs!basetableid
        //   Else
        //      TID = gv_rs!basetableid
        //   End If
        //
        //
        //   'add the field names if they are Fix Fields in the new structure
        //   fieldorder = 1
        //   For i = 0 To coprs.Fields.Count - 1
        //        If UCase(coprs.Fields(i).Name) <> "MEDICAL_RECORD_ID" _
        //'            And UCase(coprs.Fields(i).Name) <> "RECORD_ID" _
        //'            And UCase(coprs.Fields(i).Name) <> "CENT_LINE_BACT_ADULT_UNIT" _
        //'            And UCase(coprs.Fields(i).Name) <> "CENT_LINE_BACT_ADULT_DAYS" _
        //'            And UCase(coprs.Fields(i).Name) <> "CENT_LINE_BACT_NEO_DAYS" _
        //'            And UCase(coprs.Fields(i).Name) <> "VENT_PNEUM_ADULT_UNIT" _
        //'            And UCase(coprs.Fields(i).Name) <> "VENT_PNEUM_ADULT_ICU_DAYS" _
        //'            And UCase(coprs.Fields(i).Name) <> "VENT_PNEUM_NEONATAL_ICU_DAYS" _
        //'            And UCase(coprs.Fields(i).Name) <> "SURG_UNSCHED_RETURN_REASON" _
        //'            And UCase(coprs.Fields(i).Name) <> "SEL_INPAT_SURG_SITE_ICD9" _
        //'            And UCase(coprs.Fields(i).Name) <> "SEL_OUTPAT_SURG_SITE_ICD9" _
        //'            And UCase(coprs.Fields(i).Name) <> "UPDATE_DATE" _
        //'            And UCase(coprs.Fields(i).Name) <> "UPDATE_METHOD" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_INPAT_SURG_RISK0" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_INPAT_SURG_RISK1" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_INPAT_SURG_RISK2" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_INPAT_SURG_RISK3" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_OUTPAT_SURG_RISK0" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_OUTPAT_SURG_RISK1" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_OUTPAT_SURG_RISK2" _
        //'            And UCase(coprs.Fields(i).Name) <> "TOT_SEL_OUTPAT_SURG_RISK3" _
        //'            And UCase(coprs.Fields(i).Name) <> "NEO_TRANSFER_OUT" Then
        //
        //
        //            'remove the old one
        //            gv_sql = "Select * from tbl_setup_DataDef "
        //            gv_sql = gv_sql & " where BaseTableID = " & TID
        //            gv_sql = gv_sql & " and OldFieldName = '" & coprs.Fields(i).Name & "'"
        //            Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //            If gv_rs.RowCount > 0 Then
        //                gv_sql = "delete tbl_setup_DataDef "
        //                gv_sql = gv_sql & " where BaseTableID = " & TID
        //                gv_sql = gv_sql & " and OldFieldName = '" & coprs.Fields(i).Name & "'"
        //                gv_cn.Execute gv_sql
        //            End If
        //
        //                FieldCategory = FindFieldCategory(coprs.Fields(i).Name)
        //                'add it
        //                Select Case coprs.Fields(i).Type
        //                    Case 3, 4:
        //                        FieldType = "Number"
        //                        FieldSize = "Null"
        //                    Case 10:
        //                        FieldType = "Text"
        //                        FieldSize = coprs.Fields(i).Size
        //                    Case 8:
        //                        FieldType = "Date"
        //                        FieldSize = "Null"
        //                End Select
        //
        //                'we have to insert 4 different fields (one for each unit) in place of CENT_LINE_BACT_ADULT_ICU
        //                If coprs.Fields(i).Name = "CENT_LINE_BACT_ADULT_ICU" Then
        //
        //                    ' insert Cent Line Bact. Adult (Med)
        //                    For j = 1 To 4
        //
        //                        Select Case j
        //                            Case 1:
        //                                NewFieldName = "Central Line Bact. Adult ICU (Med)"
        //                                OldFieldName = "CENT_LINE_BACT_ADULT_ICU_MED"
        //                            Case 2:
        //                                NewFieldName = "Central Line Bact. Adult ICU (Surg)"
        //                                OldFieldName = "CENT_LINE_BACT_ADULT_ICU_SURG"
        //                            Case 3:
        //                                NewFieldName = "Central Line Bact. Adult ICU (Med/Surg)"
        //                                OldFieldName = "CENT_LINE_BACT_ADULT_ICU_MEDSURG"
        //                            Case 4:
        //                                NewFieldName = "Central Line Bact. Adult ICU (Coron)"
        //                                OldFieldName = "CENT_LINE_BACT_ADULT_ICU_CORON"
        //                        End Select
        //                        NextNewID = FindMaxRecID("tbl_setup_DataDef", "DDID")
        //
        //                        gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldOrder,"
        //                        gv_sql = gv_sql & " FieldName, FieldType, FieldSize, OldFieldName, FieldCategory) "
        //                        gv_sql = gv_sql & " values (" & NextNewID & "," & TID & "," & fieldorder & ","
        //                        gv_sql = gv_sql & " upper('" & NewFieldName & "'),"
        //                        gv_sql = gv_sql & "'" & FieldType & "',"
        //                        If FieldSize = "Null" Then
        //                            gv_sql = gv_sql & " Null,"
        //                        Else
        //                            gv_sql = gv_sql & FieldSize & ","
        //                        End If
        //                        gv_sql = gv_sql & "'" & OldFieldName & "',"
        //                        gv_sql = gv_sql & "'" & FieldCategory & "')"
        //                        gv_cn.Execute gv_sql
        //                    Next j
        //
        //                ElseIf coprs.Fields(i).Name = "VENT_PNEUM_ADULT_ICU" Then
        //
        //                    ' insert Vent Pnumonia Adult ICU(Med)
        //                    For k = 1 To 4
        //
        //                        Select Case k
        //                            Case 1:
        //                                NewFieldName = "Vent. Pneumonia Adult ICU (Med)"
        //                                OldFieldName = "VENT_PNEUM_ADULT_ICU_MED"
        //                            Case 2:
        //                                NewFieldName = "Vent. Pneumonia Adult ICU (Surg)"
        //                                OldFieldName = "VENT_PNEUM_ADULT_ICU_SURG"
        //                            Case 3:
        //                                NewFieldName = "Vent. Pneumonia Adult ICU (Med/Surg)"
        //                                OldFieldName = "VENT_PNEUM_ADULT_ICU_MEDSURG"
        //                            Case 4:
        //                                NewFieldName = "Vent. Pneumonia Adult ICU (Coron)"
        //                                OldFieldName = "VENT_PNEUM_ADULT_ICU_CORON"
        //                        End Select
        //                        NextNewID = FindMaxRecID("tbl_setup_DataDef", "DDID")
        //
        //                        gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldOrder,"
        //                        gv_sql = gv_sql & " FieldName, FieldType, FieldSize, OldFieldName, FieldCategory) "
        //                        gv_sql = gv_sql & " values (" & NextNewID & "," & TID & "," & fieldorder & ","
        //                        gv_sql = gv_sql & " upper('" & NewFieldName & "'),"
        //                        gv_sql = gv_sql & "'" & FieldType & "',"
        //                        If FieldSize = "Null" Then
        //                            gv_sql = gv_sql & " Null,"
        //                        Else
        //                            gv_sql = gv_sql & FieldSize & ","
        //                        End If
        //                        gv_sql = gv_sql & "'" & OldFieldName & "',"
        //                        gv_sql = gv_sql & "'" & FieldCategory & "')"
        //                        gv_cn.Execute gv_sql
        //                    Next k
        //                Else 'if this is a regular field, just insert it
        //
        //                    NextNewID = FindMaxRecID("tbl_setup_DataDef", "DDID")
        //                    NewFieldName = GetNewFieldName(coprs.Fields(i).Name)
        //                    gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldOrder,"
        //                    gv_sql = gv_sql & " FieldName, FieldType, FieldSize, OldFieldName, FieldCategory) "
        //                    gv_sql = gv_sql & " values (" & NextNewID & "," & TID & "," & fieldorder & ","
        //                    gv_sql = gv_sql & " upper('" & NewFieldName & "'),"
        //                    gv_sql = gv_sql & "'" & FieldType & "',"
        //                    If FieldSize = "Null" Then
        //                        gv_sql = gv_sql & " Null,"
        //                    Else
        //                        gv_sql = gv_sql & FieldSize & ","
        //                    End If
        //                    gv_sql = gv_sql & "'" & coprs.Fields(i).Name & "',"
        //                    gv_sql = gv_sql & "'" & FieldCategory & "')"
        //                    gv_cn.Execute gv_sql
        //
        //                    fieldorder = fieldorder + 1
        //                End If
        //            End If
        //
        //    Next i
        //
        //    'if the table is patient table, add the fields for icu days
        //    'If UCase(NewTableName) = "PATIENT" Then
        //    '    FieldCategory = "Dynamic"
        //    '    FieldType = "Number"
        //    '    FieldSize = "Null"
        //    '    For i = 1 To 9
        //    '        Select Case i
        //    '            Case 1:
        //    '                NewFieldName = "Ventilator ICU (Med)"
        //    '                OldFieldName = "Vent_Med"
        //    '            Case 2:
        //    '                NewFieldName = "Ventilator ICU (Surg)"
        //    '                OldFieldName = "Vent_Surg"
        //    '            Case 3:
        //    '                NewFieldName = "Ventilator ICU (Med/Surg)"
        //    '                OldFieldName = "Vent_MedSurg"
        //    '            Case 4:
        //    '                NewFieldName = "Ventilator ICU (Coron)"
        //    '                OldFieldName = "Vent_Coron"
        //    '            Case 5:
        //    '                NewFieldName = "Central Line ICU (Med)"
        //    '                OldFieldName = "Cent_Med"
        //    '            Case 6:
        //    '                NewFieldName = "Central Line ICU (Surg)"
        //    '                OldFieldName = "Cent_Surg"
        //    '            Case 7:
        //    '                NewFieldName = "Central Line ICU (Med/Surg)"
        //    '                OldFieldName = "Cent_MedSurg"
        //    '            Case 8:
        //    '                NewFieldName = "Central Line ICU (Coron)"
        //    '                OldFieldName = "Cent_Coron"
        //    '            Case 9:
        //    '                NewFieldName = "Prim. Blood Infection"
        //    '                OldFieldName = "Prim_Blood"
        //    '        End Select
        //    '
        //    '        gv_sql = "Select * from tbl_setup_DataDef "
        //    '        gv_sql = gv_sql & " where BaseTableID = " & TID
        //    '        gv_sql = gv_sql & " and OldFieldName = '" & OldFieldName & "'"
        //    '        Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //    '        If gv_rs.RowCount = 0 Then
        //    '
        //    '            NextNewID = FindMaxRecID("tbl_setup_DataDef", "DDID")
        //   ''
        //    '            gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, "
        //    '            gv_sql = gv_sql & " FieldName, FieldType, FieldSize, OldFieldName, FieldCategory) "
        //    '            gv_sql = gv_sql & " values (" & NextNewID & "," & TID & ","
        //    '            gv_sql = gv_sql & " upper('" & NewFieldName & "'),"
        //    '            gv_sql = gv_sql & "'" & FieldType & "',"
        //    '            gv_sql = gv_sql & FieldSize & ","
        //    '            gv_sql = gv_sql & "'" & OldFieldName & "',"
        //    '            gv_sql = gv_sql & "'" & FieldCategory & "')"
        //    '            gv_cn.Execute gv_sql
        //    '
        //    '        End If
        //     '   Next i
        //    'End If
        //  '
        //
        //End Sub

        //Public Sub GetOldFields()
        //    Dim COPDB As Database
        //    Dim coprs As Recordset
        //    Dim wrkODBC As Workspace
        //    Dim dbsNew As Database
        //    Dim prpLoop As Property
        //    Dim tbldef As TableDef
        //
        //    'Set wrkODBC = CreateWorkspace("", "admin", "", dbUseJet)
        //
        //    Set COPDB = OpenDatabase(CurrentDB)
        //
        //    gv_sql = "Delete tbl_setup_OldFields "
        //    gv_cn.Execute gv_sql
        //
        //    gv_sql = "Select * from tbl_setup_TableDef "
        //    gv_sql = gv_sql & " where upper(BaseTable) = 'PATIENT'"
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //    BTID = gv_rs!basetableid
        //
        //    Set coprs = COPDB.OpenRecordset("Select * from tbl_db_Patrecs")
        //    For i = 0 To coprs.Fields.Count - 1
        //      Select Case coprs.Fields(i).Type
        //        Case 4:
        //            FType = "Number"
        //            FSize = "Null"
        //        Case 8:
        //            FType = "Datetime"
        //            FSize = "Null"
        //        Case 10:
        //            FType = "Text"
        //            FSize = coprs.Fields(i).Size
        //      End Select
        //      gv_sql = "insert into tbl_setup_OldFields (TableName, FieldName, FieldType, FieldSize, BaseTableID)"
        //      gv_sql = gv_sql & " values ('PATIENT','" & coprs.Fields(i).Name & "','" & FType & "'," & FSize & "," & BTID & ")"
        //      gv_cn.Execute gv_sql
        //    Next i
        //
        //
        //    gv_sql = "Select * from tbl_setup_TableDef "
        //    gv_sql = gv_sql & " where upper(BaseTable) = 'HOSPITAL STATISTICS'"
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //    BTID = gv_rs!basetableid
        //
        //    Set coprs = COPDB.OpenRecordset("Select * from tbl_db_UtilStat")
        //    For i = 0 To coprs.Fields.Count - 1
        //        Select Case coprs.Fields(i).Type
        //        Case 4:
        //            FType = "Number"
        //            FSize = "Null"
        //        Case 8:
        //            FType = "Datetime"
        //            FSize = "Null"
        //        Case 10:
        //            FType = "Text"
        //            FSize = coprs.Fields(i).Size
        //      End Select
        //      gv_sql = "insert into tbl_setup_OldFields (TableName,FieldName, FieldType, FieldSize, BaseTableID)"
        //      gv_sql = gv_sql & " values ('UTILSTAT','" & coprs.Fields(i).Name & "','" & FType & "'," & FSize & "," & BTID & ")"
        //      gv_cn.Execute gv_sql
        //
        //    Next i
        //
        //    gv_sql = "Select * from tbl_setup_TableDef "
        //    gv_sql = gv_sql & " where upper(BaseTable) = 'HOSPITAL DEMOGRAPHICS'"
        //    Set gv_rs = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //    BTID = gv_rs!basetableid
        //
        //    Set coprs = COPDB.OpenRecordset("Select * from tbl_db_HOSPDATA")
        //    For i = 0 To coprs.Fields.Count - 1
        //        Select Case coprs.Fields(i).Type
        //        Case 4:
        //            FType = "Number"
        //            FSize = "Null"
        //        Case 8:
        //            FType = "Datetime"
        //            FSize = "Null"
        //        Case 10:
        //            FType = "Text"
        //            FSize = coprs.Fields(i).Size
        //      End Select
        //
        //      gv_sql = "insert into tbl_setup_OldFields (TableName,FieldName, FieldType, FieldSize, BaseTableID)"
        //      gv_sql = gv_sql & " values ('HOSPDATA','" & coprs.Fields(i).Name & "','" & FType & "'," & FSize & "," & BTID & ")"
        //      gv_cn.Execute gv_sql
        //    Next i
        //
        //
        //    BTID = "NULL"
        //
        //    Set coprs = COPDB.OpenRecordset("Select * from tbl_db_INDICATs_LIST")
        //    For i = 0 To coprs.Fields.Count - 1
        //        Select Case coprs.Fields(i).Type
        //        Case 4:
        //            FType = "Number"
        //            FSize = "Null"
        //        Case 8:
        //            FType = "Datetime"
        //            FSize = "Null"
        //        Case 10:
        //            FType = "Text"
        //            FSize = coprs.Fields(i).Size
        //      End Select
        //
        //      gv_sql = "insert into tbl_setup_OldFields (TableName,FieldName, FieldType, FieldSize, BaseTableID)"
        //      gv_sql = gv_sql & " values ('INDICATS','" & coprs.Fields(i).Name & "','" & FType & "'," & FSize & "," & BTID & ")"
        //      gv_cn.Execute gv_sql
        //    Next i
        //
        //    COPDB.Close
        //End Sub

        public void SetupNewFieldsFromOld()
        {
            int NextNewID;
            DataSet drs = new DataSet();
            DataSet ors = new DataSet();
            DataSet fixrs = new DataSet();


            try
            {
                //only add the dynamic fields,
                //meaning that only the fields that don't exist in FixField table

                modGlobal.gv_sql = "Select * from tbl_setup_OldFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID is not null ";
                //LDW ors = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName20 = "tbl_setup_OldFields";
                ors = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName20, ors);

                //LDW while (!ors.EOF)
                foreach (DataRow myRow20 in ors.Tables[sqlTableName20].Rows)
                {
                    modGlobal.gv_sql = "Select * ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_FixFields ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID = " + myRow20.Field<int>("basetableid");
                    modGlobal.gv_sql = modGlobal.gv_sql + " and FixFieldName = '" + myRow20.Field<int>("FieldName") + "'";

                    //LDW fixrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName21 = "tbl_setup_FixFields";
                    fixrs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName21, fixrs);

                    if (fixrs.Tables[sqlTableName21].Rows.Count == 0)
                    {
                        //check to see if it doesn't already exist
                        modGlobal.gv_sql = "Select * ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID = " + myRow20.Field<int>("basetableid");
                        modGlobal.gv_sql = modGlobal.gv_sql + " and OldFieldName = '" + myRow20.Field<int>("FieldName") + "'";

                        //LDW drs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                        const string sqlTableName22 = "tbl_setup_DataDef";
                        drs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, drs);

                        if (drs.Tables[sqlTableName22].Rows.Count == 0)
                        {
                            const string refDataDef = "tbl_Setup_DataDef";
                            const string refDDID = "DDID";
                            NextNewID = modDBSetup.FindMaxRecID(refDataDef, refDDID);
                            modGlobal.gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldName, FieldSize, FieldType, OldFieldName)";
                            modGlobal.gv_sql = modGlobal.gv_sql + " Select " + NextNewID + "," + myRow20.Field<int>("basetableid") +
                                ", FieldName, FieldSize, FieldType, FieldName  ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_OldFields ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " where OldFieldID = " + myRow20.Field<int>("OldFieldID");
                            //g = InputBox("", "", gv_sql)
                            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        }
                    }
                    //LDW ors.MoveNext();
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

        public void AddFixField(int TableID, string FixFieldName, string FieldType, string FieldSize)
        {
            int NextNewID = 0;


            try
            {
                modGlobal.gv_sql = "Select * from tbl_setup_FixFields ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + TableID;
                modGlobal.gv_sql = modGlobal.gv_sql + " and FixFieldName = '" + FixFieldName + "'";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName22 = "tbl_setup_FixFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName22, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName22].Rows.Count == 0)
                {
                    NextNewID = modDBSetup.FindMaxRecID("tbl_setup_FixFields", "FixFieldID");
                    modGlobal.gv_sql = "Insert into tbl_setup_Fixfields (FixFieldID, BaseTableID, ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " FixFieldName, FixFieldType, FixFieldSize) ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + TableID + ",";
                    modGlobal.gv_sql = modGlobal.gv_sql + " upper('" + FixFieldName + "'),";
                    modGlobal.gv_sql = modGlobal.gv_sql + "'" + FieldType + "',";
                    if (FieldSize == "Null")
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + " Null)";
                    }
                    else
                    {
                        modGlobal.gv_sql = modGlobal.gv_sql + FieldSize + ")";
                    }
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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

        public void SetupDayFields()
        {
            string FieldName = null;
            string OldFieldName = null;
            string FieldSize = null;
            string FieldType = null;
            int TID = 0;


            try
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " BaseTable = 'PATIENT' ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName23 = "tbl_setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName23, modGlobal.gv_rs);
                TID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName23].Rows[0]["basetableid"]);
                FieldType = "Number";
                FieldSize = "Null";
                //
                OldFieldName = "CENT_MED";
                NewFieldName = "CENTRAL LINE DAYS (MEDICAL ICU)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "CENT_SURG";
                NewFieldName = "CENTRAL LINE DAYS (SURGICAL ICU)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "CENT_MEDSURG";
                NewFieldName = "CENTRAL LINE DAYS (MED/SURG ICU)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "CENT_CORON";
                NewFieldName = "CENTRAL LINE DAYS (CORONARY CARE)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "VENT_MED";
                NewFieldName = "VENTILATOR DAYS (MEDICAL ICU)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "VENT_SURG";
                NewFieldName = "VENTILATOR DAYS (SURGICAL ICU)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "VENT_MEDSURG";
                NewFieldName = "VENTILATOR DAYS (MED/SURG ICU)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "VENT_CORON";
                NewFieldName = "VENTILATOR DAYS (CORONARY CARE)";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
                //
                OldFieldName = "PRIM_BLOOD";
                NewFieldName = "PRIMARY BLOOD INFECTION DAYS";
                AddDayField(TID, FieldName, NewFieldName, FieldSize, FieldType);
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

        public void AddDayField(int TableID, string OldFieldName, string NewFieldName, string FieldSize, string FieldType)
        {
            int NextNewID = 0;

            try
            {
                modGlobal.gv_sql = "Select * ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID = " + TableID;
                modGlobal.gv_sql = modGlobal.gv_sql + " and OldFieldName = '" + OldFieldName + "'";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName24 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName24, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName24].Rows.Count == 0)
                {
                    NextNewID = modDBSetup.FindMaxRecID("tbl_Setup_DataDef", "DDID");
                    modGlobal.gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldName, FieldSize, FieldType, OldFieldName)";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + TableID + ",'" + NewFieldName + "',";
                    modGlobal.gv_sql = modGlobal.gv_sql + FieldSize + ",'" + FieldType + "','" + OldFieldName + "')";
                    //g = InputBox("", "", gv_sql)
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
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

        public string FindFieldCategory(string FixFieldName)
        {
            string functionReturnValue = null;

            try
            {
                NewFieldName = FixFieldName;
                functionReturnValue = "Fix";

                switch (FixFieldName)
                {
                    case "ADMISSION_DATE":
                        NewFieldName = "ADMISSIONDATE";
                        break;
                    case "DISCHARGE_DATE":
                        NewFieldName = "DISCHARGEDATE";
                        break;
                    case "BIRTH_DATE":
                        NewFieldName = "BIRTHDATE";
                        break;
                    case "SEX":
                        NewFieldName = "SEX";
                        break;
                    case "ATTEND_PHYSICIAN_ID":
                        NewFieldName = "ATTENDINGPHYSICIANNUMBER";
                        break;
                    case "DRG":
                        NewFieldName = "DRG";
                        break;
                    case "ADMISSION_SOURCE":
                        NewFieldName = "ADMISSIONSOURCE";
                        break;
                    case "DISCHARGE_DISPOSITION":
                        NewFieldName = "DISCHARGEDISPOSITION";
                        break;
                    case "NEONATAL_BIRTH_WEIGHT":
                        NewFieldName = "NEONATALBIRTHWEIGHT";
                        break;
                    case "PRINCIPAL_DIAGNOSIS":
                        NewFieldName = "PRINCIPALDIAG";
                        break;
                    case "SEC_DIAGNOSIS_2":
                        NewFieldName = "SECONDDIAG2";
                        break;
                    case "SEC_DIAGNOSIS_3":
                        NewFieldName = "SECONDDIAG3";
                        break;
                    case "SEC_DIAGNOSIS_4":
                        NewFieldName = "SECONDDIAG4";
                        break;
                    case "SEC_DIAGNOSIS_5":
                        NewFieldName = "SECONDDIAG5";
                        break;
                    case "SEC_DIAGNOSIS_6":
                        NewFieldName = "SECONDDIAG6";
                        break;
                    case "SEC_DIAGNOSIS_7":
                        NewFieldName = "SECONDDIAG7";
                        break;
                    case "SEC_DIAGNOSIS_8":
                        NewFieldName = "SECONDDIAG8";
                        break;
                    case "SEC_DIAGNOSIS_9":
                        NewFieldName = "SECONDDIAG9";
                        break;
                    case "PERIOD_START_Date":
                        NewFieldName = "PERIOD_START_Date";
                        break;
                    case "PERIOD_END_Date":
                        NewFieldName = "PERIOD_END_Date";
                        break;
                    default:
                        functionReturnValue = "Dynamic";
                        break;
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

        public void UpdateIndicatorFieldList(string OldTableName)
        {
            int NextNewID = 0;
            /*LDW DAO.Database COPDB = null;
            DAO.Recordset coprs = null;
            DAO.Workspace wrkODBC = null;
            DAO.Database dbsNew = null;
            DAO.Property prpLoop = null;
            DAO.TableDef tbldef = null; */
            DataSet coprs = new DataSet();
            //

            try
            {
                modGlobal.gv_sql = "Select * from " + OldTableName;
                modGlobal.gv_sql = modGlobal.gv_sql + " where Hidden = null or hidden = ''";

                //LDW coprs = COPDB.OpenRecordset("Select * from " + OldTableName);
                string sqlTableName34 = OldTableName;
                coprs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName34, coprs);

                //
                //add the field names
                //LDW while (!coprs.EOF)
                foreach (DataRow myRow22 in coprs.Tables[sqlTableName34].Rows)
                {
                    modGlobal.gv_sql = "Select * from tbl_setup_Indicator ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " OldFieldName = '" + myRow22.Field<string>("Indicator") + "'";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName35 = "tbl_setup_Indicator";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName35, modGlobal.gv_rs);

                    if (modGlobal.gv_rs.Tables[sqlTableName35].Rows.Count == 0)
                    {
                        NextNewID = modDBSetup.FindMaxRecID("tbl_setup_Indicator", "IndicatorID");

                        modGlobal.gv_sql = "Insert into tbl_setup_Indicator (IndicatorID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " Description, OldFieldName) ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + myRow22.Field<string>("Title") + "',";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + myRow22.Field<string>("Indicator") + "')";

                        //msg = InputBox("", "", gv_sql)
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    //LDW coprs.MoveNext();
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

        //Public Sub ImportDatabaseDef()
        // gv_sql = "Delete tbl_Setup_MiscLookupList"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_DataDefVal"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_DataDefReq"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_DataReq"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_IndicatorGroup"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_Indicator"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_HospStatGroupFields"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_HospStatGroupIndicator"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_HospStatGroup"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_DataDef"
        // gv_cn.Execute gv_sql
        // gv_sql = "Delete tbl_Setup_TableDef"
        // gv_cn.Execute gv_sql
        //
        // UpdateFieldList "tbl_DB_PatRecs", "Patient"
        // UpdateFieldList "tbl_db_UtilStat", "HOSPITAL STATISTICS"
        // UpdateFieldList "tbl_db_HOSPDATA", "HOSPITAL DEMOGRAPHICS"
        // UpdateIndicatorFieldList "tbl_db_INDICATS_LIST"
        //
        // UpdateLookupFieldList "tbl_App_Lkup_AdmissionSource", "Admission Source Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_AnesthesiaType", "Anesthesia Type Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_BHAdmTransferReason", "Beh. Adm. Transfer Reason Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_DischargeDisposition", "Discharge Disposition Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_ExtendedStayReason", "Extended Stay Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_IndicationForCSection", "Indication For C-Section Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_LegalStatus", "Legal Status Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_Payor", "Payor Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_ReadmissionReason", "Readmission Reason Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_ReferralSource", "Referral Source Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_ServicesUsed", "Service Used Lookup List"
        // UpdateLookupFieldList "tbl_App_Lkup_UnscheduledReturnReason", "Unscheduled Return Reason Lookup List"
        //
        //
        //End Sub

        public void UpdateLookupFieldList(string OldTableName, string NewTableName)
        {
            /*LDW object TID = null;
            object NextNewID = null;
            DAO.Database COPDB = null;
            DAO.Recordset coprs = null;
            DAO.Workspace wrkODBC = null;
            DAO.Database dbsNew = null;
            DAO.Property prpLoop = null;
            DAO.TableDef tbldef = null;
            COPDB = DAODBEngine_definst.OpenDatabase(modGlobal.CurrentDB);
            coprs = COPDB.OpenRecordset("Select * from " + OldTableName);*/
            int TID = 0;
            int NextNewID = 0;
            DataSet coprs = new DataSet();

            try
            {


                string tempSql4 = "Select * from " + OldTableName;
                string sqlTableName26 = OldTableName;
                coprs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, tempSql4, sqlTableName26, coprs);

                //if tablename doesn't exist in the list, add it
                modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where upper(BaseTable) = upper('" + NewTableName + "')";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName27 = "tbl_setup_TableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName27, modGlobal.gv_rs);

                if (modGlobal.gv_rs.Tables[sqlTableName27].Rows.Count == 0)
                {
                    //add the table name first
                    NextNewID = modDBSetup.FindMaxRecID("tbl_setup_tabledef", "BaseTableID");
                    modGlobal.gv_sql = "Insert into tbl_setup_tabledef(BaseTableID, BaseTable, TableType, OldTableName, HasFixField )";
                    modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",upper('" + NewTableName + "'),'LOOKUP',upper('" + OldTableName + "'),'Y')";
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //get the id of the new table
                    modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where upper(BaseTable) = upper('" + NewTableName + "')";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName28 = "tbl_setup_TableDef";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName28, modGlobal.gv_rs);
                    TID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName28].Rows[0]["basetableid"]);
                }
                else
                {
                    TID = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName27].Rows[0]["basetableid"]);
                }

                modGlobal.gv_sql = "Select * from " + OldTableName;
                modGlobal.gv_sql = modGlobal.gv_sql + " where Value is not null and Value <> ''";

                //LDW coprs = COPDB.OpenRecordset(modGlobal.gv_sql);
                string sqlTableName29 = OldTableName;
                coprs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName29, coprs);
                //
                //add the field names
                //LDW while (!coprs.EOF)
                foreach (DataRow myRow21 in coprs.Tables[sqlTableName29].Rows)
                {
                    modGlobal.gv_sql = "Select * from tbl_setup_MiscLookupList ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where ";
                    string refVal = myRow21.Field<string>("Value");
                    modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue = '" + modGlobal.ConvertApastroph(refVal) + "'";
                    //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                    const string sqlTableName30 = "tbl_setup_MiscLookupList";
                    modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName30, modGlobal.gv_rs);
                    if (modGlobal.gv_rs.Tables[sqlTableName30].Rows.Count == 0)
                    {
                        NextNewID = modDBSetup.FindMaxRecID("tbl_setup_MiscLookupList", "LookupID");

                        modGlobal.gv_sql = "Insert into tbl_setup_MiscLookUpList(LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID, ID, FieldValue) ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + TID + "," + myRow21.Field<string>("Id") + ",";
                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.ConvertApastroph(refVal) + "')";

                        //msg = InputBox("", "", gv_sql)
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    //LDW coprs.MoveNext();
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

        public void mnuTableValidationSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            frmTableValidationSetup frmTableValidationSetupCopy = new frmTableValidationSetup();
            frmTableValidationSetupCopy.Show();
        }

        public void mnuTiming_Click(Object eventSender, EventArgs eventArgs)
        {
            frmVerifyTimingTest frmVerifyTimingTestCopy = new frmVerifyTimingTest();
            frmVerifyTimingTestCopy.Show();
        }

        public void mnuUpdateExistingDB_Click(Object eventSender, EventArgs eventArgs)
        {
            frmExportSetup frmExportSetupCopy = new frmExportSetup();
            //every setup record in all of the tables will be imported to a text file
            //first line of each table will be tablename in [], followed by the records in the table
            // in a comma delimited format
            //resp = MsgBox("Please make sure that a diskette is inserted before creating an update. Continue?", vbOKCancel, "Create an update for Access database.")
            //If resp = vbNo Then
            //    Exit Sub
            //End If
            frmExportSetupCopy.Show();
            return;
        }

        public string GetNewFieldName(string OldFieldName)
        {
            string functionReturnValue = null;

            try
            {
                functionReturnValue = OldFieldName;

                switch (OldFieldName)
                {
                    //Case "ADMISSION_DATE":
                    //    GetNewFieldName = "Admission Date"
                    //Case "DISCHARGE_DATE":
                    //    GetNewFieldName = "Discharge Date"
                    //Case "BIRTH_DATE":
                    //    GetNewFieldName = "Birth Date"
                    //Case "SEX"
                    //    GetNewFieldName = "Sex"
                    //Case "ATTEND_PHYSICIAN_ID":
                    //    GetNewFieldName = "Attending Physician #"
                    //Case "DRG":
                    //    GetNewFieldName = "DRG"
                    //Case "PRINCIPAL_DIAGNOSIS":
                    //    GetNewFieldName = "Principal Diag."
                    //Case "SEC_DIAGNOSIS_2":
                    //    GetNewFieldName = "Sec. Diag #2"
                    //Case "SEC_DIAGNOSIS_3":
                    //    GetNewFieldName = "Sec. Diag #3"
                    //Case "SEC_DIAGNOSIS_4":
                    //    GetNewFieldName = "Sec. Diag #4"
                    //Case "SEC_DIAGNOSIS_5":
                    //    GetNewFieldName = "Sec. Diag #5"
                    //Case "SEC_DIAGNOSIS_6":
                    //    GetNewFieldName = "Sec. Diag #6"
                    //Case "SEC_DIAGNOSIS_7":
                    //    GetNewFieldName = "Sec. Diag #7"
                    //Case "SEC_DIAGNOSIS_8":
                    //    GetNewFieldName = "Sec. Diag #8"
                    //Case "SEC_DIAGNOSIS_9":
                    //    GetNewFieldName = "Sec. Diag #9"
                    //Case "ADMISSION_SOURCE":
                    //    GetNewFieldName = "Admission Source"
                    //Case "DISCHARGE_DISPOSITION":
                    //    GetNewFieldName = "Discharge Disposition"
                    //Case "NEONATAL_BIRTH_WEIGHT":
                    //GetNewFieldName = "Neonatal Birth Weight"
                    case "BH_UNIT_INPAT":
                        functionReturnValue = "Behavioral Health Unit Inpatient";
                        break;
                    case "HOSP_ACQUIRED_INFECTION":
                        functionReturnValue = "Hospital Acquired Infection";
                        break;
                    case "POST_OP_PNEUM":
                        functionReturnValue = "Post Op Pneumonia";
                        break;
                    case "POST_OP_PNEUM_CABG":
                        functionReturnValue = "Post Op Pneumonia CABG w/Valve Repair";
                        break;
                    case "VENT_PNEUM_NEONATAL_ICU":
                        functionReturnValue = "Ventilator Pneumonia Neonatal ICU";
                        break;
                    case "INPAT_SURG_SITE_CLASS1":
                        functionReturnValue = "Inpatient Surgical Site Class 1";
                        break;
                    case "INPAT_SURG_SITE_CLASS2":
                        functionReturnValue = "Inpatient Surgical Site Class 2";
                        break;
                    case "INPAT_SURG_SITE_C1_RISK":
                        functionReturnValue = "Inpatient Surgical Site Class 1 Risk";
                        break;
                    case "INPAT_SURG_SITE_C2_RISK":
                        functionReturnValue = "Inpatient Surgical Site Class 2 Risk";
                        break;
                    case "SEL_INPAT_SURG_SITE":
                        functionReturnValue = "Select Inpatient Surgical Site";
                        break;
                    case "SEL_INPAT_SURG_SITE_RISK":
                        functionReturnValue = "Select Inpatient Surgical Site Risk";
                        break;
                    case "SEL_INPAT_SURG_SITE_PROC":
                        functionReturnValue = "Select Inpatient Surgical Site Procedure";
                        break;
                    case "SEL_OUTPAT_SURG_SITE":
                        functionReturnValue = "Select Outpatient Surgical Site";
                        break;
                    case "SEL_OUTPAT_SURG_SITE_RISK":
                        functionReturnValue = "Select Outpatient Surgical Site Risk";
                        break;
                    case "SEL_OUTPAT_SURG_SITE_PROC":
                        functionReturnValue = "Select Outpatient Surgical Site Procedure";
                        break;
                    case "PRIM_BLOOD_INFECTION":
                        functionReturnValue = "Primary Bloodstream Infection";
                        break;
                    case "CENT_LINE_BACT_NEO_ICU":
                        functionReturnValue = "Central Line Bacteremia Neonatal ICU";
                        break;
                    case "ENDOM_FOLLOW_C_SECTION":
                        functionReturnValue = "Endometritis Following C-Section";
                        break;
                    case "PRIOR_AMBUL_EXT_STAY":
                        functionReturnValue = "Extended Stay Following Prior Ambulatory Surgery";
                        break;
                    case "PRIOR_AMBUL_EXT_STAY_REASON":
                        functionReturnValue = "Reason for Extended Stay";
                        break;
                    case "PRIOR_AMBUL_SURG_DATE":
                        functionReturnValue = "Ambulatory Surgery Date";
                        break;
                    case "PRIOR_AMBUL_PRINC_PROC":
                        functionReturnValue = "Ambulatory Surgery Principal Procedure";
                        break;
                    case "PRIOR_AMBUL_SECOND_PROC":
                        functionReturnValue = "Ambulatory Surgery Secondary Procedure";
                        break;
                    case "PRIOR_AMBUL_ATTEND_PHYS_ID":
                        functionReturnValue = "Ambulatory Surgery Attending Physician #";
                        break;
                    case "PRIOR_AMBUL_SURG_SURGEON":
                        functionReturnValue = "Ambulatory Surgery Surgeon#";
                        break;
                    case "PRIOR_AMBUL_SURG_ANESTHES":
                        functionReturnValue = "Ambulatory Surgery Anesthesiologist";
                        break;
                    case "PRIOR_AMBUL_ANESTHES_TYPE":
                        functionReturnValue = "Ambulatory Surgery Anesthesia Type";
                        break;
                    case "SURG_PERFORMED":
                        functionReturnValue = "Inpatient Invasive Surgery Performed";
                        break;
                    case "SURG_ASASCORE":
                        functionReturnValue = "ASA Score";
                        break;
                    case "SURG_LAST_INVASIVE_DATE":
                        functionReturnValue = "Last Invasive Surgery Date";
                        break;
                    case "SURG_ASA_SCORE_EMERGENT":
                        functionReturnValue = "Emergent";
                        break;
                    case "SURG_PRINC_PROC":
                        functionReturnValue = "Invasive Surgery Principal Procedure";
                        break;
                    case "SURG_SECOND_PROC2":
                        functionReturnValue = "Invasive Surgery Sec. Procedure #1";
                        break;
                    case "SURG_SECOND_PROC3":
                        functionReturnValue = "Invasive Surgery Sec. Procedure #2";
                        break;
                    case "SURG_SECOND_PROC4":
                        functionReturnValue = "Invasive Surgery Sec. Procedure #3";
                        break;
                    case "SURG_SECOND_PROC5":
                        functionReturnValue = "Invasive Surgery Sec. Procedure #4";
                        break;
                    case "SURG_SECOND_PROC6":
                        functionReturnValue = "Invasive Surgery Sec. Procedure #5";
                        break;
                    case "SURG_SURGN_ID":
                        functionReturnValue = "Invasive Surgery Surgeon #";
                        break;
                    case "SURG_ANESTHES_ID":
                        functionReturnValue = "Invasive Surgery Anesthesiologist #";
                        break;
                    case "SURG_ANESTHES_TYPE":
                        functionReturnValue = "Invasive Surgery Anesthesia Type";
                        break;
                    case "SURG_UNSCHED_RETURN_OR_OB":
                        functionReturnValue = "Unscheduled Return to OR/OB Suite";
                        break;
                    case "SURG_RET_REASON_POSTOP_HEMOR":
                        functionReturnValue = "Reason for Unscheduled Return - Post Op Bleeding";
                        break;
                    case "SURG_RET_REASON_WOUND_DEHIS":
                        functionReturnValue = "Reason for Unscheduled Return - Wound Dehiscence";
                        break;
                    case "SURG_RET_REASON_REV_ORIGPROC":
                        functionReturnValue = "Reason for Unscheduled Return - Revision of Original Procedure";
                        break;
                    case "SURG_RET_REASON_UNDET_OTHER":
                        functionReturnValue = "Reason for Unscheduled Return - Other/Undetermined";
                        break;
                    case "RE_ADMISSION":
                        functionReturnValue = "Readmission";
                        break;
                    case "RE_ADMISSION_REASON":
                        functionReturnValue = "Readmission Reason";
                        break;
                    case "RE_ADM_PRIOR_DISCHARGE_DATE":
                        functionReturnValue = "Prior Admission Discharge Date";
                        break;
                    case "RE_ADM_PRIOR_ATTEND_PHYS_ID":
                        functionReturnValue = "Prior Admission Attending Physician#";
                        break;
                    case "RE_ADM_PRIOR_SURG_ID":
                        functionReturnValue = "Prior Admission Prior Surgeon#";
                        break;
                    case "RE_ADM_PRIOR_ANESTHES_ID":
                        functionReturnValue = "Prior Admission Prior Anesthesiologist#";
                        break;
                    case "RE_ADM_PRIOR_ADM_DRG":
                        functionReturnValue = "Prior Admission Prior Admission DRG";
                        break;
                    case "RE_ADM_CSEC_VBAC":
                        functionReturnValue = "C-Section/VBAC";
                        break;
                    case "BH_ADM_REF_SOURCE":
                        functionReturnValue = "Beh. Health Admission Referral Source";
                        break;
                    case "BH_ADM_LEGAL_STATUS":
                        functionReturnValue = "Beh. Health Admission Legal Status";
                        break;
                    case "BH_ADM_PAYOR":
                        functionReturnValue = "Beh. Health Admission Payor";
                        break;
                    case "BH_ADM_DEPARTURE":
                        functionReturnValue = "Beh. Health Admission Unplanned Departure";
                        break;
                    case "BH_ADM_TRANSFER":
                        functionReturnValue = "Beh. Health Admission Transfer to Med Unit Within 24 Hours";
                        break;
                    case "BH_ADM_TRANSFER_REASON":
                        functionReturnValue = "Beh. Health Admission Reason for Transfer";
                        break;
                    case "BH_ADM_POST_DISCH_OUTPAT_SESS":
                        functionReturnValue = "Beh. Health Admission Inpat. Without Outpat. Session Within 30 Days";
                        break;
                    case "BH_RE_ADM":
                        functionReturnValue = "Beh. Health Unplanned Prev. Admission ";
                        break;
                    case "BH_RE_ADM_DATE":
                        functionReturnValue = "Beh. Health Previous Admission Date";
                        break;
                    case "BH_RE_ADM_ATTEND_PHYS_ID":
                        functionReturnValue = "Beh. Health Previous Admission Attending Physician ID";
                        break;
                    case "BH_RE_ADM_SERVICE_USED":
                        functionReturnValue = "Beh. Health Previous Admission Services Used";
                        break;
                    case "BH_RE_ADM_REF_SOURCE":
                        functionReturnValue = "Beh. Health Previous Admission Referral Source";
                        break;
                    case "BH_RE_ADM_LEGAL_STATUS":
                        functionReturnValue = "Beh. Health Previous Admission Legal Status";
                        break;
                    case "PRINC_DIAG_DX_PRESENT":
                        functionReturnValue = "DX Principal Diag.";
                        break;
                    case "SEC_DIAG2_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #2";
                        break;
                    case "SEC_DIAG3_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #3";
                        break;
                    case "SEC_DIAG4_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #4";
                        break;
                    case "SEC_DIAG5_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #5";
                        break;
                    case "SEC_DIAG6_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #6";
                        break;
                    case "SEC_DIAG7_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #7";
                        break;
                    case "SEC_DIAG8_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #8";
                        break;
                    case "SEC_DIAG9_DX_PRESENT":
                        functionReturnValue = "DX Sec. Diag. #9";
                        break;
                    case "HOSP_ACQUIRED_INFECTION_DATE":
                        functionReturnValue = "Hospital Acquired Infection Date";
                        break;
                    case "HOSP_CUSTOM_FIELD1":
                        functionReturnValue = "Hospital Custom Field 1";
                        break;
                    case "HOSP_CUSTOM_FIELD2":
                        functionReturnValue = "Hospital Custom Field 2";
                        break;
                    case "HOSP_CUSTOM_FIELD3":
                        functionReturnValue = "Hospital Custom Field 3";
                        break;
                    case "COP_CUSTOM_FIELD1":
                        functionReturnValue = "COP Custom Field 1";
                        break;
                    case "COP_CUSTOM_FIELD2":
                        functionReturnValue = "COP Custom Field 2";
                        break;
                    case "COP_CUSTOM_FIELD3":
                        functionReturnValue = "COP Custom Field 3";
                        break;

                    //**** Hosp Stat Fields
                    case "PERIOD_END_DATE":
                        functionReturnValue = "PERIOD_END_DATE";
                        break;
                    case "PERIOD_START_DATE":
                        functionReturnValue = "PERIOD_START_DATE";
                        break;
                    case "DISCHARGE_014":
                        functionReturnValue = "Total Discharges-Age 0-14";
                        break;
                    case "DISCHARGE_1564":
                        functionReturnValue = "Total Discharges-Age 15-64";
                        break;
                    case "DISCHARGE_ABOVE65":
                        functionReturnValue = "Total Discharges-Age 65+";
                        break;
                    case "DISCH_CARDIO_014":
                        functionReturnValue = "Cardiology Discharges-Age 0-14";
                        break;
                    case "DISCH_CARDIO_1564":
                        functionReturnValue = "Cardiology Discharges-Age 15-64";
                        break;
                    case "DISCH_CARDIO_ABOVE65":
                        functionReturnValue = "Cardiology Discharges-Age 65+";
                        break;
                    case "DISCH_RESP_014":
                        functionReturnValue = "Respiratory Discharges-Age 0-14";
                        break;
                    case "DISCH_RESP_1564":
                        functionReturnValue = "Respiratory Discharges-Age 15-64";
                        break;
                    case "DISCH_RESP_ABOVE65":
                        functionReturnValue = "Respiratory Discharges-Age 65+";
                        break;
                    case "DISCH_CARDIOVASC_014":
                        functionReturnValue = "Major CV Discharges-Age 0-14";
                        break;
                    case "DISCH_CARDIOVASC_1564":
                        functionReturnValue = "Major CV Discharges-Age 15-64";
                        break;
                    case "DISCH_CARDIOVASC_ABOVE65":
                        functionReturnValue = "Major CV Discharges-Age 65+";
                        break;
                    case "INPAT_DAYS_014":
                        functionReturnValue = "Inpatient Days-Age 0-14";
                        break;
                    case "INPAT_DAYS_1564":
                        functionReturnValue = "Inpatient Days-Age 15-64";
                        break;
                    case "INPAT_DAYS_ABOVE65":
                        functionReturnValue = "Inpatient Days-Age 65+";
                        break;
                    case "INPAT_SURG_014":
                        functionReturnValue = "Inpat Invasive Surg.-Age 0-14";
                        break;
                    case "INPAT_SURG_1564":
                        functionReturnValue = "Inpat Invasive Surg.-Age 15-64";
                        break;
                    case "INPAT_SURG_ABOVE65":
                        functionReturnValue = "Inpat Invasive Surg.-Age 65+";
                        break;
                    case "AMBUL_SURG_014":
                        functionReturnValue = "Ambulatory Surgery-Age 0-14";
                        break;
                    case "AMBUL_SURG_1564":
                        functionReturnValue = "Ambulatory Surgery-Age 15-64";
                        break;
                    case "AMBUL_SURG_ABOVE65":
                        functionReturnValue = "Ambulatory Surgery-Age 65+";
                        break;
                    case "CABGS_014":
                        functionReturnValue = "CABG-Age 0-14";
                        break;
                    case "CABGS_1564":
                        functionReturnValue = "CABG-Age 15-64";
                        break;
                    case "CABGS_ABOVE65":
                        functionReturnValue = "CABG-Age 65+";
                        break;
                    case "DELIVERIES_014":
                        functionReturnValue = "Deliveries-Age 0-14";
                        break;
                    case "DELIVERIES_1564":
                        functionReturnValue = "Deliveries-Age 15-64";
                        break;
                    case "NEO_TRANSFER_IN_00001500":
                        functionReturnValue = "Neo. Admits/Xfers In-Weight 0000-1500 grams";
                        break;
                    case "NEO_TRANSFER_IN_15012500":
                        functionReturnValue = "Neo. Admits/Xfers In-Weight 1501-2500 grams";
                        break;
                    case "NEO_TRANSFER_IN_ABOVE2500":
                        functionReturnValue = "Neo. Admits/Xfers In-Weight 2501+";
                        break;
                    case "NEO_TRANSFER_OUT_00001500":
                        functionReturnValue = "Neo. Admits/Xfers Out-Weight 0000-1500 grams";
                        break;
                    case "NEO_TRANSFER_OUT_15012500":
                        functionReturnValue = "Neo. Admits/Xfers Out-Weight 1501-2500 grams";
                        break;
                    case "NEO_TRANSFER_OUT_ABOVE2500":
                        functionReturnValue = "Neo. Admits/Xfers Out-Weight 2501+";
                        break;
                    //Case "NEO_TRANSFER_OUT"
                    case "BIRTH_00001500":
                        functionReturnValue = "Live Births-Weight 0000-1500 grams";
                        break;
                    case "BIRTH_15012500":
                        functionReturnValue = "Live Births-Weight 1501-2500 grams";
                        break;
                    case "BIRTH_ABOVE2501":
                        functionReturnValue = "Live Births-Weight 2501+";
                        break;
                    case "INPAT_SURG_CLASS1_RISK0":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 1-Risk0";
                        break;
                    case "INPAT_SURG_CLASS1_RISK1":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 1-Risk1";
                        break;
                    case "INPAT_SURG_CLASS1_RISK2":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 1-Risk2";
                        break;
                    case "INPAT_SURG_CLASS1_RISK3":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 1-Risk3";
                        break;
                    case "INPAT_SURG_CLASS2_RISK0":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 2-Risk0";
                        break;
                    case "INPAT_SURG_CLASS2_RISK1":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 2-Risk1";
                        break;
                    case "INPAT_SURG_CLASS2_RISK2":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 2-Risk2";
                        break;
                    case "INPAT_SURG_CLASS2_RISK3":
                        functionReturnValue = "Invasive Inpatient Surgeries Class 2-Risk3";
                        break;
                    case "VENT_DAYS_MEDICU":
                        functionReturnValue = "Ventilator Days - Medical ICU";
                        break;
                    case "VENT_DAYS_SURGICU":
                        functionReturnValue = "Ventilator Days - Surgical ICU";
                        break;
                    case "VENT_DAYS_MEDSURGICU":
                        functionReturnValue = "Ventilator Days - Med/Surg ICU";
                        break;
                    case "VENT_DAYS_CORCARE":
                        functionReturnValue = "Ventilator Days - Coronary Care";
                        break;
                    case "VENT_DAYS_NEOICU_00001500":
                        functionReturnValue = "Ventilator Days Neo. ICU-Weight 0000-1500 grams";
                        break;
                    case "VENT_DAYS_NEOICU_15012500":
                        functionReturnValue = "Ventilator Days Neo. ICU-Weight 1501-2500 grams";
                        break;
                    case "VENT_DAYS_NEOICU_ABOVE2500":
                        functionReturnValue = "Ventilator Days Neo. ICU-Weight 2500+ grams";
                        break;
                    case "CENTLINE_DAYS_MEDICU":
                        functionReturnValue = "Central Line Days - Medical ICU";
                        break;
                    case "CENTLINE_DAYS_SURGICU":
                        functionReturnValue = "Central Line Days - Surgical ICU";
                        break;
                    case "CENTLINE_DAYS_MEDSURGICU":
                        functionReturnValue = "Central Line Days - Med/Surg ICU";
                        break;
                    case "CENTLINE_DAYS_CORCARE":
                        functionReturnValue = "Central Line Days - Coronary Care";
                        break;
                    case "CENTLINE_DAYS_NEOICU_00001500":
                        functionReturnValue = "Central Line Neo. ICU-Weight 0000-1500 grams";
                        break;
                    case "CENTLINE_DAYS_NEOICU_15012500":
                        functionReturnValue = "Central Line Neo. ICU-Weight 1501-2500 grams";
                        break;
                    case "CENTLINE_DAYS_NEOICU_ABOVE2500":
                        functionReturnValue = "Central Line Neo. ICU-Weight 2500+ grams";
                        break;
                    case "ABD_HYST_RISK0":
                        functionReturnValue = "Abdominal Hysterectomy-Risk 0";
                        break;
                    case "ABD_HYST_RISK1":
                        functionReturnValue = "Abdominal Hysterectomy-Risk 1";
                        break;
                    case "ABD_HYST_RISK2":
                        functionReturnValue = "Abdominal Hysterectomy-Risk 2";
                        break;
                    case "ABD_HYST_RISK3":
                        functionReturnValue = "Abdominal Hysterectomy-Risk 3";
                        break;
                    case "COR_ARTERY_RISK0":
                        functionReturnValue = "Coronary Artery Bypass Graft-Risk 0";
                        break;
                    case "COR_ARTERY_RISK1":
                        functionReturnValue = "Coronary Artery Bypass Graft-Risk 1";
                        break;
                    case "COR_ARTERY_RISK2":
                        functionReturnValue = "Coronary Artery Bypass Graft-Risk 2";
                        break;
                    case "COR_ARTERY_RISK3":
                        functionReturnValue = "Coronary Artery Bypass Graft-Risk 3";
                        break;
                    case "OPEN_CHOLE_RISK0":
                        functionReturnValue = "Open Cholecystectomy-Risk 0";
                        break;
                    case "OPEN_CHOLE_RISK1":
                        functionReturnValue = "Open Cholecystectomy-Risk 1";
                        break;
                    case "OPEN_CHOLE_RISK2":
                        functionReturnValue = "Open Cholecystectomy-Risk 2";
                        break;
                    case "OPEN_CHOLE_RISK3":
                        functionReturnValue = "Open Cholecystectomy-Risk 3";
                        break;
                    case "DISC_LAMIN_RISK0":
                        functionReturnValue = "Discectomy/Laminectomy-Risk 0";
                        break;
                    case "DISC_LAMIN_RISK1":
                        functionReturnValue = "Discectomy/Laminectomy-Risk 1";
                        break;
                    case "DISC_LAMIN_RISK2":
                        functionReturnValue = "Discectomy/Laminectomy-Risk 2";
                        break;
                    case "DISC_LAMIN_RISK3":
                        functionReturnValue = "Discectomy/Laminectomy-Risk 3";
                        break;
                    case "LAPAR_CHOLE_RISK0":
                        functionReturnValue = "Laparoscopic Cholecystectomy-Risk 0";
                        break;
                    case "LAPAR_CHOLE_RISK1":
                        functionReturnValue = "Laparoscopic Cholecystectomy-Risk 1";
                        break;
                    case "LAPAR_CHOLE_RISK2":
                        functionReturnValue = "Laparoscopic Cholecystectomy-Risk 2";
                        break;
                    case "LAPAR_CHOLE_RISK3":
                        functionReturnValue = "Laparoscopic Cholecystectomy-Risk 3";
                        break;
                    case "ARTH_KNEE_RISK0":
                        functionReturnValue = "Arhroscopic Knee Procedure-Risk 0";
                        break;
                    case "ARTH_KNEE_RISK1":
                        functionReturnValue = "Arhroscopic Knee Procedure-Risk 1";
                        break;
                    case "ARTH_KNEE_RISK2":
                        functionReturnValue = "Arhroscopic Knee Procedure-Risk 2";
                        break;
                    case "ARTH_KNEE_RISK3":
                        functionReturnValue = "Arhroscopic Knee Procedure-Risk 3";
                        break;
                    case "INPAT_PSYCH_DISCH_017":
                        functionReturnValue = "Inpat Pscych Discharges-Age 0-17";
                        break;
                    case "INPAT_PSYCH_DISCH_1864":
                        functionReturnValue = "Inpat Pscych Discharges-Age 18-64";
                        break;
                    case "INPAT_PSYCH_DISCH_ABOVE65":
                        functionReturnValue = "Inpat Pscych Discharges-Age 65+";
                        break;
                    case "DISCH_FOLLOWUP_017":
                        functionReturnValue = "Disch excl/pts. w/o followup outpat. tx-Age 0-17";
                        break;
                    case "DISCH_FOLLOWUP_1864":
                        functionReturnValue = "Disch excl/pts. w/o followup outpat. tx-Age 18-64";
                        break;
                    case "DISCH_FOLLOWUP_ABOVE65":
                        functionReturnValue = "Disch excl/pts. w/o followup outpat. tx-Age 65+";
                        break;
                    case "INPAT_PSYCH_DAYS_017":
                        functionReturnValue = "Inpatient Psych Days-Age 0-17";
                        break;
                    case "INPAT_PSYCH_DAYS_1864":
                        functionReturnValue = "Inpatient Psych Days-Age 18-64";
                        break;
                    case "INPAT_PSYCH_DAYS_ABOVE65":
                        functionReturnValue = "Inpatient Psych Days-Age 65+";
                        break;
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

        public void mnuUpdateSystemSetup_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                UpdateSetup.UpdateSystemSetup();
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

        /*Unused click event
        private void mnuSetupVersion_Click(object sender, EventArgs e)
        {

        }*/
    }
}
