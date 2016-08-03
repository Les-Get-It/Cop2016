using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using Telerik.WinControls;



// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    static class modGlobal
    {
        public static string gv_sql;
        public static string gv_selecteddatabasename;
        public static string gv_selecteddatabase;
        public static string gv_Action;
        public static string gv_ANDOR;
        public static SqlConnection gv_cn = new SqlConnection();
        //public static DataSet gv_rs;
        //LDW public static RDO.rdoEnvironment gv_en;
        public static string gv_resp;
        public static string gv_SelectedDirectory;
        public static string gv_SelectedFileWithPath;
        public static string gv_SelectedFileName;
        public static string CurrentDB;
        public static string gv_SubmitGroupID;
        public static string gv_SubmitRowID;
        public static string gv_SubmitColID;
        public static string gv_State;
        public static string gv_importsetupid;
        public static string gv_status;
        public static string gv_Username;
        public static string gv_password;
        public static string gv_connectionstatus;
        public static string gv_g;
        public const string GLthisDrive = "C:\\";
        public const string GLThisPath = "\\\\hal9000\\IHANet\\Data\\Projects\\COP";
        public static string gv_strDBName;
        public static DataSet gv_rs = new DataSet();
        private static readonly log4net.ILog log = LogHelper.GetLogger();





        //used in the measure criteria form
        public struct SelectedMeasureField
        {
            public string Description;
            public int DDID;
            public string FieldType;
        }

        public static int GetLastID(string SQLTableName)
        {
            int functionReturnValue = 0;


            try
            {
                gv_sql = string.Format("SELECT IDENT_CURRENT ('{0}') as LastId", SQLTableName);


                //LDW gv_rs = gv_cn.OpenResultset(gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, SQLTableName, gv_rs);

                //LDW if (Information.IsDBNull(gv_rs.rdoColumns["lastid"].Value))
                if (Information.IsDBNull(gv_rs.Tables[SQLTableName].Rows[0]["lastid"]))
                {
                    functionReturnValue = 0;
                }
                else
                {
                    //LDW functionReturnValue = gv_rs.rdoColumns["lastid"].Value;
                    functionReturnValue = Convert.ToInt32(gv_rs.Tables[SQLTableName].Rows[0]["lastid"]);
                }

                //LDW gv_rs.Close();
                gv_rs.Dispose();
                return functionReturnValue;
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
            return functionReturnValue;
        }

        public static int GetMaxValue(string SQLTableName, string FieldName, string WhereClause)
        {
            int functionReturnValue = 0;

            try
            {
                gv_sql = string.Format("SELECT MAX({0}) as MaxVal FROM {1} WHERE {2}", FieldName, SQLTableName, WhereClause);

                //LDW gv_rs = gv_cn.OpenResultset(gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, SQLTableName, gv_rs);

                //LDW functionReturnValue = (Information.IsDBNull(gv_rs.rdoColumns["maxVal"].Value) ? 0 : gv_rs.rdoColumns["maxVal"].Value);
                functionReturnValue = (Information.IsDBNull(gv_rs.Tables[SQLTableName].Rows[0]["maxVal"])) ? 0 : Convert.ToInt32(gv_rs.Tables[SQLTableName].Rows[0]["maxVal"]);

                //LDW gv_rs.Close();
                gv_rs.Dispose();
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

        //LDW Method used to log errors with the log4Net API
        public static void LogErrors(Exception ex)
        {
            if (ex.Data.Count > 0)
            {
                log.Error("Method error: " + ex + ": " + ex.TargetSite + "- " + ex.Message, ex);
                RadMessageBox.Show("Opps somehting went wrong1: " + ex);
                ClearErrors();
            }
            else
            {
                return;
            }
        }

        //Old error handling method
        //public static void CheckForErrors()
        //{
        //    //Exception ex = null;

        //    //if (ex.Data.Count > 0)
        //    //{
        //    //    log.Error("Method error: " + ex + ": " + ex.TargetSite + "- " + ex.Message, ex);
        //    //    RadMessageBox.Show("Opps somehting went wrong: " + ex);
        //    //    ClearErrors();
        //    //}
        //    //else
        //    //{
        //    //    return;
        //    //}
            

        //    //LDW Old error handling code

        //    //string strErr = null;
        //    ////LDW RDO.rdoError objError = null;
        //    //SqlException objError = null;
        //    //SqlException ex = null;
        //    //string strError = null;



        //    //    //if (RDOrdoEngine_definst.rdoErrors.Count > 0)
        //    //    if (ex.Errors.Count > 0)
        //    //    {
        //    //        //LDW if (RDOrdoEngine_definst.rdoErrors.Item(0).Number == 8153 | RDOrdoEngine_definst.rdoErrors.Item(0).Number == 5701 | RDOrdoEngine_definst.rdoErrors.Item(0).Number == 5703)
        //    //        if (ex.ErrorCode == 8153 | ex.ErrorCode == 5701 | ex.ErrorCode == 5703)
        //    //        {
        //    //            goto vbError;
        //    //        }

        //    //        //RDO database errors
        //    //        //LDW foreach (RDO.rdoError objError_loopVariable in RDOrdoEngine_definst.rdoErrors)
        //    //        foreach (SqlException objError_loopVariable in ex.Errors)
        //    //        {
        //    //            objError = objError_loopVariable;
        //    //            //LDW strError = "Error #" + objError.Number + " " + objError.Description + Constants.vbCrLf + "SQLRetCode: " + objError.SQLRetcode + Constants.vbCrLf + "SQLState: " + objError.SQLState + Constants.vbCrLf + "Reported by: " + objError.Source + Constants.vbCrLf + "Help file: " + objError.HelpFile + Constants.vbCrLf + "Help Context ID: " + objError.HelpContext;
        //    //            strError = string.Format("Error #{0} {1}{2}SQLRetCode: {3}{2}SQLState: {4}{2}Reported by: {5}{2}Help file: {6}{2}Help Context ID: {7}",
        //    //                objError.Number, objError.Message, Constants.vbCrLf, objError.Data, objError.State, objError.Source, objError.HelpLink, objError.HResult);
        //    //            //LDW RadMessageBox.Show(strError);

        //    //            DialogResult ds1 = RadMessageBox.Show(strError, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
        //    //            ds1.ToString();
        //    //        }

        //    //        return;

        //    //    }

        //    //vbError:

        //    ////LDW strErr = "Error #" + Err().Number + ": " + Err().Description + Constants.vbCrLf + "Error reported by: " + Err().Source + Constants.vbCrLf + "Help File: " + Err().HelpFile + Constants.vbCrLf + "Topic ID: " + Err().HelpContext;
        //    //strErr = string.Format("Error #{0}: {1}{2}Error reported by: {3}{2}Help File: {4}{2}Topic ID: {5}", Information.Err().Number, Information.Err().Description, Constants.vbCrLf, Information.Err().Source, Information.Err().HelpFile, Information.Err().HelpContext);
        //    ////LDW RadMessageBox.Show(strErr);

        //    //DialogResult ds2 = RadMessageBox.Show(strError, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
        //    //ds2.ToString();
        //    //Debug.Print(strErr);
        //}

        public static void ClearErrors()
        {
            //in case any errors are in the collection objects,
            //clear them so proper messages will be displayed
            //LDW Err().Clear();
            Information.Err().Clear();
            //LDW RDOrdoEngine_definst.rdoErrors.Clear();
        }

        public static string ConvertApastroph(string VarName)
        {
            string functionReturnValue = null;
            int i = 0;
            string CumChar = null;

            try
            {
                //
                // Convert any apastroph to a double quote to prevent syntax error in SQL
                //LDW if (Strings.InStr(VarName, "'") > 0)
                if (Strings.InStr(VarName, "'") > 0)
                {
                    //initialize the variable
                    CumChar = "";
                    for (i = 1; i <= Strings.Len(VarName); i++)
                    {
                        // search for any apastroph
                        if (Strings.Mid(VarName, i, 1) != "'")
                        {
                            // if the character is not an apastroph add it to the previous characters
                            CumChar = CumChar + Strings.Mid(VarName, i, 1);
                        }
                        else
                        {
                            // if the character is was found, double it
                            CumChar = CumChar + "''";
                        }
                    }
                    functionReturnValue = CumChar;
                }
                else
                {
                    functionReturnValue = VarName;
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

        public static void ConnectToDatabase()
        {
            Login LoginCopy = new Login();
            frmSelectDatabase frmSelectDatabaseCopy = new frmSelectDatabase();
            //LDW object badtrycount = null;
            int badtrycount = 0;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //LDW goto TryAgain;
                //Establishes the path to the database location
                //gv_en = RDOrdoEngine_definst.rdoEnvironments(0);
                //LDW gv_strDBName = "DSN=" + gv_selecteddatabasename + ";uid=" + gv_Username + ";pwd=" + gv_password + ";database=" + gv_selecteddatabasename;
                //LDW updated connection string syntax 
                //LDW gv_strDBName = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}; Connection Timeout=30", @"LES-IDP\LESW29", gv_selecteddatabasename, gv_Username, gv_password);
                gv_strDBName = "Server=" + @"LES-IDP\LESW29;" +
                               "Initial Catalog=cop2001current;" +
                               "User id=" + gv_Username + ";" +
                               "Password=" + gv_password + ";";


                //LDW goto CnEh;

                //LDW gv_cn = gv_en.OpenConnection("", RDO.PromptConstants.rdDriverNoPrompt, false, gv_strDBName);
                //LDW gv_cn.QueryTimeout = 6000;
                gv_cn.ConnectionString = gv_strDBName;
                //gv_cn.Open();



                Cursor.Current = Cursors.Default;
                //CnEh:

                
                

                //LDW TryAgain:

                gv_connectionstatus = "fail";
                frmSelectDatabaseCopy.Hide();

                badtrycount = badtrycount + 1;

                if (badtrycount == 3)
                {
                    //LDW RadMessageBox.Show("Your username and password were not found.  Please contact your system administrator for assistance in logging in.", MsgBoxStyle.Critical, "Login Failed");

                    DialogResult ds3 = RadMessageBox.Show("Your username and password were not found.  Please contact your system administrator for assistance in logging in.", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    ds3.ToString();
                }
                else
                {
                    //LDW RadMessageBox.Show("Username or Password are Incorrect, Please Try Again!" + "Error Number: " + Err().Number + Err().Description + Err().Source, MsgBoxStyle.Exclamation, "Incorrect Login");
                    //LDW RadMessageBox.Show(string.Format("Username or Password are Incorrect, Please Try Again!Error Number: {0}{1}{2}", Information.Err().Number, Information.Err().Description, Information.Err().Source), MsgBoxStyle.Exclamation, "Incorrect Login");

                    DialogResult ds4 = RadMessageBox.Show(string.Format("Username or Password are Incorrect, Please Try Again!Error Number: {0}{1}{2}", Information.Err().Number, Information.Err().Description, Information.Err().Source), "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    ds4.ToString();
                    LoginCopy.Show();
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

        //LDW commented out unused method
        //public static void CenterMe(ref object L, ref object R, ref object W, ref object H)
        //{



        //}

        //LDW public static string ConvertDoubleQuote(ref object VarName)
        public static string ConvertDoubleQuote(string VarName)
        {
            string functionReturnValue = null;
            int i = 0;
            string CumChar = null;


            try
            {
                //
                // Convert any double quote to a 2 single quotes to prevent syntax error in SQL
                if (Strings.InStr(VarName, "\"") > 0)
                {
                    //initialize the variable
                    CumChar = "";
                    for (i = 1; i <= Strings.Len(VarName); i++)
                    {
                        // search for any apastroph
                        if (Strings.Mid(VarName, i, 1) != "\"")
                        {
                            // if the character is not an apastroph add it to the previous characters
                            CumChar = CumChar + Strings.Mid(VarName, i, 1);
                        }
                        else
                        {
                            // if the character is was found, double it
                            CumChar = CumChar + "''";
                        }
                    }
                    functionReturnValue = CumChar;
                }
                else
                {
                    functionReturnValue = VarName;
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

        public static string RemoveCrLfFromString(string VarName)
        {
            string functionReturnValue = null;


            try
            {
                //LDW if (InStrB(VarName, Constants.vbCrLf) > 0)
                if (Strings.InStrRev(VarName, Constants.vbCrLf) > 0)
                {
                    functionReturnValue = Strings.Replace(VarName, Constants.vbCrLf, "");
                }
                else
                {
                    functionReturnValue = VarName;
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

        public static void UpdateVerificationCriteriaTitle(int mcid)
        {
            //LDW object CritTitle = null;
            string CritTitle = null;
            bool Exception = false;
            var rs_Test = new DataSet();

            try
            {
                gv_sql = "select mc.*, dd1.fieldname as ddid1fieldname, dd2.fieldname as ddid2fieldname, ";
                gv_sql = gv_sql + " dd3.fieldname as destddidfieldname, ";
                gv_sql = gv_sql + " misclk.fieldvalue as lookupvalue, ";
                gv_sql = gv_sql + " tf.basetable as lookuptablename ";
                gv_sql = gv_sql + " from tbl_Setup_MeasureCriteria mc ";
                gv_sql = gv_sql + " left join tbl_setup_datadef as dd1 ";
                gv_sql = gv_sql + " on mc.ddid1 = dd1.ddid ";
                gv_sql = gv_sql + " left join tbl_setup_datadef as dd2 ";
                gv_sql = gv_sql + " on mc.ddid2 = dd2.ddid  ";
                gv_sql = gv_sql + " left join tbl_setup_datadef as dd3 ";
                gv_sql = gv_sql + " on mc.Destddid = dd3.ddid  ";
                gv_sql = gv_sql + " left join tbl_Setup_MiscLookupList as misclk ";
                gv_sql = gv_sql + " on mc.lookupid = misclk.lookupid ";
                gv_sql = gv_sql + " left join tbl_setup_tabledef as tf ";
                gv_sql = gv_sql + " on mc.LookupTableID = tf.basetableid  ";
                gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", gv_sql, mcid);
                const string sqlTableName1 = "tbl_Setup_MeasureCriteria";
                const string sqlTableName2 = "tbl_Setup_DataDef";


                //LDW gv_rs = gv_cn.OpenResultset(gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, gv_sql, sqlTableName1, gv_rs);

                //LDW CritTitle = gv_rs.rdoColumns["ddid1fieldname"].Value;
                CritTitle = gv_rs.Tables[sqlTableName1].Rows[0]["ddid1fieldname"].ToString();
                int li_group = 0;
                string[] GroupIDs = null;

                if (Information.IsDBNull(CritTitle))
                {
                    //exception / earliest method
                    CritTitle = "EARLIEST(";

                    //LDW GroupIDs = Strings.Split(Convert.ToString(gv_rs.rdoColumns["FIELDVALUE"].Value), ",");
                    GroupIDs = Strings.Split(gv_rs.Tables[sqlTableName1].Rows[0]["FIELDVALUE"].ToString(), ",");
                    for (li_group = 0; li_group <= Information.UBound(GroupIDs); li_group++)
                    {
                        //LDW rs_Test = gv_cn.OpenResultset("SELECT FieldName FROM tbl_Setup_DataDef WHERE DDID = " + GroupIDs[li_group], RDO.ResultsetTypeConstants.rdOpenStatic);
                        rs_Test = DALcop.DalConnectDataSet(gv_cn.ConnectionString, "SELECT FieldName FROM tbl_Setup_DataDef WHERE DDID = " + GroupIDs[li_group], sqlTableName2, rs_Test);

                        //LDW CritTitle = CritTitle + rs_Test.rdoColumns["FieldName"].Value + ",";
                        CritTitle = string.Format("{0}{1},", CritTitle, rs_Test.Tables[sqlTableName2].Rows[0]["FieldName"]);
                        //LDW rs_Test.Close();
                        rs_Test.Dispose();
                    }
                    rs_Test = null;
                    CritTitle = Strings.Mid(CritTitle, 1, Strings.Len(CritTitle) - 1) + ")";
                    Exception = true;
                }

                //LDW if (!Information.IsDBNull(gv_rs.rdoColumns["ddid2"].Value))
                if (!Information.IsDBNull(gv_rs.Tables[sqlTableName1].Rows[0]["ddid2"]))
                {
                    //LDW CritTitle = CritTitle + " " + gv_rs.rdoColumns["FieldOperator"].Value + " " + gv_rs.rdoColumns["ddid2fieldname"].Value;
                    CritTitle = string.Format("{0} {1} {2}", CritTitle, gv_rs.Tables[sqlTableName1].Rows[0]["FieldOperator"], gv_rs.Tables[sqlTableName1].Rows[0]["ddid2fieldname"]);
                }
                //LDW CritTitle = CritTitle + " " + gv_rs.rdoColumns["ValueOperator"].Value;
                CritTitle = string.Format("{0} {1}", CritTitle, gv_rs.Tables[sqlTableName1].Rows[0]["ValueOperator"]);

                //LDW if (!Information.IsDBNull(gv_rs.rdoColumns["LookupID"].Value))
                if (!Information.IsDBNull(gv_rs.Tables[sqlTableName1].Rows[0]["LookupID"]))
                {
                    //LDW CritTitle = CritTitle + " (" + gv_rs.rdoColumns["FIELDVALUE"].Value + ") " + gv_rs.rdoColumns["LookupValue"].Value;
                    CritTitle = string.Format("{0} ({1}) {2}", CritTitle, gv_rs.Tables[sqlTableName1].Rows[0]["FIELDVALUE"], gv_rs.Tables[sqlTableName1].Rows[0]["LookupValue"]);
                }
                //LDW else if (!Information.IsDBNull(gv_rs.rdoColumns["FIELDVALUE"].Value))
                else if (!Information.IsDBNull(gv_rs.Tables[sqlTableName1].Rows[0]["FIELDVALUE"]))
                {
                    //LDW if (gv_rs.rdoColumns["FIELDVALUE"].Value == "Null" | Exception)
                    if (gv_rs.Tables[sqlTableName1].Rows[0]["FIELDVALUE"].ToString() == "Null" | Exception)
                    {
                        CritTitle = CritTitle + " Blank ";
                    }
                    else
                    {
                        //LDW CritTitle = CritTitle + " " + gv_rs.rdoColumns["FIELDVALUE"].Value;
                        CritTitle = string.Format("{0} {1}", CritTitle, gv_rs.Tables[sqlTableName1].Rows[0]["FIELDVALUE"]);
                    }
                }
                //LDW else if (!Information.IsDBNull(gv_rs.rdoColumns["LookupTableID"].Value))
                else if (!Information.IsDBNull(gv_rs.Tables[sqlTableName1].Rows[0]["LookupTableID"]))
                {
                    //LDW CritTitle = CritTitle + " [" + gv_rs.rdoColumns["lookuptablename"].Value + "] lookup table";
                    CritTitle = string.Format("{0} [{1}] lookup table", CritTitle, gv_rs.Tables[sqlTableName1].Rows[0]["lookuptablename"]);
                }
                //LDW else if (!Information.IsDBNull(gv_rs.rdoColumns["destddidfieldname"].Value))
                else if (!Information.IsDBNull(gv_rs.Tables[sqlTableName1].Rows[0]["destddidfieldname"]))
                {
                    //LDW CritTitle = CritTitle + " " + gv_rs.rdoColumns["destddidfieldname"].Value;
                    CritTitle = string.Format("{0} {1}", CritTitle, gv_rs.Tables[sqlTableName1].Rows[0]["destddidfieldname"]);
                }
                //LDW if (!Information.IsDBNull(gv_rs.rdoColumns["DateUnit"].Value))
                if (!Information.IsDBNull(gv_rs.Tables[sqlTableName1].Rows[0]["DateUnit"]))
                {
                    //LDW switch (gv_rs.rdoColumns["DateUnit"].Value)
                    switch (gv_rs.Tables[sqlTableName1].Rows[0]["DateUnit"].ToString())
                    {
                        case "YYYY":
                            CritTitle = CritTitle + " Years";
                            break;
                        case "m":
                            CritTitle = CritTitle + " Months";
                            break;
                        case "d":
                            CritTitle = CritTitle + " Days";
                            break;
                        case "h":
                            CritTitle = CritTitle + " Hours";
                            break;
                        case "n":
                            CritTitle = CritTitle + " Minutes";
                            break;
                        case "s":
                            CritTitle = CritTitle + " Seconds";
                            break;
                        default:
                            //LDW CritTitle = CritTitle + " " + gv_rs.rdoColumns["DateUnit"].Value;
                            CritTitle = string.Format("{0} {1}", CritTitle, gv_rs.Tables[sqlTableName1].Rows[0]["DateUnit"]);
                            break;
                    }
                }
                //MsgBox CritTitle
                gv_sql = "update tbl_Setup_MeasureCriteria ";
                gv_sql = gv_sql + " set ";
                gv_sql = string.Format("{0} CriteriaTitle = '{1}'", gv_sql, CritTitle);
                gv_sql = string.Format("{0} where MeasureCriteriaID  = {1}", gv_sql, mcid);
                //LDW gv_cn.Execute(gv_sql);
                DALcop.ExecuteCommand(gv_cn.ConnectionString, gv_sql);
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

        public static void ImportCMSSetup()
        {
            //LDW object DefaultValue = null;
            string DefaultValue = null;
            //LDW object CalcParentValue = null;
            string CalcParentValue = null;
            //LDW object CalcParent = null;
            string CalcParent = null;
            //LDW object OutputFormat = null;
            string OutputFormat = null;
            //LDW object linkParent = null;
            string linkParent = null;
            //LDW object LinktoDDID = null;
            string LinktoDDID = null;
            //LDW object LookupTableID = null;
            string LookupTableID = null;
            //LDW object fieldedit = null;
            string fieldedit = null;
            //LDW object parentField = null;
            string parentField = null;
            string FieldName = null;
            string DDID = null;
            string IndicatorName = null;
            string IndicatorID = null;
            //LDW object TableName = null;
            string TableName = null;
            //LDW object resp = null;
            DialogResult resp;
            //LDW var i = 0;
            int StartPos = 2;
            //LDW object FileNum = null;
            int FileNum = FileSystem.FreeFile();
            string TodayDate = DateAndTime.Now.ToString();
            string CMSFile = null;
            string textline = null;
            string CMSPeriodStartDate = null;


            try
            {
                /*LDW frmFindAFile.Text = "Specify the source directory for CMSSetup.txt";
                frmFindAFile.ShowDialog();*/
                var dialog1 = new OpenFileDialog();
                dialog1.Title = "Specify the source directory for CMSSetup.txt";
                dialog1.RestoreDirectory = true;
                dialog1.DefaultExt = "txt";
                dialog1.CheckFileExists = true;
                dialog1.CheckPathExists = true;
                dialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog1.FilterIndex = 2;
                dialog1.ShowReadOnly = true;
                dialog1.ShowDialog();



                Cursor.Current = Cursors.WaitCursor;
                //LDW FileNum = FreeFile();
                CMSFile = gv_SelectedFileWithPath;
                FileSystem.FileOpen(FileNum, CMSFile, OpenMode.Input);
                textline = FileSystem.LineInput(FileNum);
                textline = FileSystem.LineInput(FileNum);

                for (var i = StartPos; i <= Strings.Len(textline); i++)
                {
                    if (Strings.Mid(textline, i, 1) != "\"")
                    {
                        CMSPeriodStartDate = CMSPeriodStartDate + Strings.Mid(textline, i, 1);
                    }
                    else
                    {
                        StartPos = i + 3;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                FileSystem.FileClose(FileNum);

                if (!Information.IsDate(CMSPeriodStartDate))
                {
                    //LDW RadMessageBox.Show("Not a valid file");

                    DialogResult ds6 = RadMessageBox.Show("Not a valid file", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    ds6.ToString();
                    Cursor.Current = Cursors.Default;
                }

                //LDW resp = RadMessageBox.Show(string.Format("This CMS setup is for {0}. Are you sure you want to upload it?", CMSPeriodStartDate), MsgBoxStyle.YesNo, "Import CMS Setup").ToString();

                resp = RadMessageBox.Show(string.Format("This CMS setup is for {0}. Are you sure you want to upload it?", CMSPeriodStartDate), "CMS Persiod Start Date", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                //LDW if (resp == MsgBoxResult.No.ToString())
                if (resp == DialogResult.No)
                {
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    gv_sql = "delete tbl_setup_CMSFieldMeasures ";
                    //LDW gv_cn.Execute(gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    gv_sql = "delete tbl_setup_CMSParentCd ";
                    //LDW gv_cn.Execute(gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    gv_sql = "delete tbl_setup_CMSParentFieldMeasures ";
                    //LDW gv_cn.Execute(gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    gv_sql = "delete tbl_setup_CMSParentAnswerCriteria ";
                    //LDW gv_cn.Execute(gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    gv_sql = "delete tbl_setup_CMSParentAnswerCriteriaSet ";
                    //LDW gv_cn.Execute(gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    gv_sql = "delete tbl_setup_CMSFieldMeasureCriteria ";
                    //LDW gv_cn.Execute(gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    gv_sql = "delete tbl_setup_CMSFieldMeasureCriteriaSet ";
                    //LDW gv_cn.Execute(gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    //first compare the update version with  the current version
                    //LDW FileNum = FreeFile();
                    FileNum = FileSystem.FreeFile();
                    FileSystem.FileOpen(FileNum, CMSFile, OpenMode.Input);

                    while (!FileSystem.EOF(FileNum))
                    {
                        textline = FileSystem.LineInput(FileNum);

                        if (Strings.Mid(textline, 1, 1) == "[")
                        {
                            TableName = Strings.Mid(textline, 2, Strings.Len(textline) - 2);
                        }
                        else
                        {
                            var startDateConverter = new DateTime();
                            startDateConverter = Convert.ToDateTime(CMSPeriodStartDate);
                            switch (TableName)
                            {
                                case "Quarter":
                                    CMSPeriodStartDate = "";
                                    StartPos = 2;
                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            CMSPeriodStartDate = CMSPeriodStartDate + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }
                                    break;

                                case "CMSMAPPINGS":
                                    //keep prior code until further notice
                                    IndicatorID = "";
                                    IndicatorName = "";
                                    DDID = "";
                                    FieldName = "";
                                    parentField = "";
                                    fieldedit = "";
                                    LookupTableID = "";
                                    LinktoDDID = "";
                                    linkParent = "";
                                    OutputFormat = "";
                                    CalcParent = "";
                                    CalcParentValue = "";
                                    DefaultValue = "";
                                    StartPos = 2;

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            IndicatorName = IndicatorName + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            DDID = DDID + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            FieldName = FieldName + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            parentField = parentField + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            fieldedit = fieldedit + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            LinktoDDID = LinktoDDID + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            linkParent = linkParent + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            OutputFormat = OutputFormat + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            CalcParent = CalcParent + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            CalcParentValue = CalcParentValue + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    //LDW for (i = StartPos; i <= Strings.Len(textline); i++)
                                    for (int i = StartPos; i <= Strings.Len(textline); i++)
                                    {
                                        if (Strings.Mid(textline, i, 1) != "\"")
                                        {
                                            DefaultValue = DefaultValue + Strings.Mid(textline, i, 1);
                                        }
                                        else
                                        {
                                            StartPos = i + 3;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }
                                    }

                                    gv_sql = "insert into tbl_setup_CMSMappings ";
                                    gv_sql = gv_sql + "(importdate, PeriodStartDate, indicatorID, ";
                                    gv_sql = gv_sql + " IndicatorName, ddid,FieldName, ";
                                    gv_sql = gv_sql + " parentField, fieldEdit, ";
                                    gv_sql = gv_sql + " LookupTableID, LinktoDDID, ";
                                    gv_sql = gv_sql + " LinkParent, outputFormat, ";
                                    gv_sql = gv_sql + " CalcParent, CalcParentValue, defaultvalue)";
                                    gv_sql = string.Format("{0} values ('{1}', '{2}',", gv_sql, TodayDate, CMSPeriodStartDate);
                                    gv_sql = string.Format("{0}{1},", gv_sql, IndicatorID);
                                    gv_sql = string.Format("{0} '{1}',", gv_sql, IndicatorName);
                                    gv_sql = string.Format("{0}{1},", gv_sql, DDID);
                                    gv_sql = string.Format("{0} '{1}',", gv_sql, FieldName);

                                    if (!string.IsNullOrEmpty(parentField))
                                    {
                                        gv_sql = string.Format("{0} '{1}',", gv_sql, parentField);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(fieldedit))
                                    {
                                        gv_sql = string.Format("{0} '{1}',", gv_sql, fieldedit);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(LookupTableID))
                                    {
                                        gv_sql = string.Format("{0}{1},", gv_sql, LookupTableID);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(LinktoDDID))
                                    {
                                        gv_sql = string.Format("{0}{1},", gv_sql, LinktoDDID);
                                    }

                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(linkParent))
                                    {
                                        gv_sql = string.Format("{0} '{1}',", gv_sql, linkParent);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(OutputFormat))
                                    {
                                        gv_sql = string.Format("{0} '{1}',", gv_sql, OutputFormat);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(CalcParent))
                                    {
                                        gv_sql = string.Format("{0} '{1}',", gv_sql, CalcParent);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(CalcParentValue))
                                    {
                                        gv_sql = string.Format("{0} '{1}',", gv_sql, CalcParentValue);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null,";
                                    }

                                    if (!string.IsNullOrEmpty(DefaultValue))
                                    {
                                        gv_sql = string.Format("{0} '{1}')", gv_sql, DefaultValue);
                                    }
                                    else
                                    {
                                        gv_sql = gv_sql + " null)";
                                    }

                                    //LDW gv_cn.Execute(gv_sql);
                                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                                    break;

                                case "CMSFIELDMEASURES":
                                    //LDW InsertCMSFieldMeasures(ref textline, ref Convert.ToDateTime(CMSPeriodStartDate));
                                    InsertCMSFieldMeasures(textline, startDateConverter);
                                    break;
                                case "CMSPARENTCD":
                                    //LDW InsertCMSParentCD(ref textline, ref Convert.ToDateTime(CMSPeriodStartDate));
                                    InsertCMSParentCD(textline, startDateConverter);
                                    break;
                                case "CMSPARENTFIELDMEASURES":
                                    //LDW InsertCMSParentFieldMeasures(ref textline, ref Convert.ToDateTime(CMSPeriodStartDate));
                                    InsertCMSParentFieldMeasures(textline, startDateConverter);
                                    break;
                                case "CMSPARENTANSWERCRITERIA":
                                    //LDW InsertCMSParentAnswerCriteria(ref textline, ref Convert.ToDateTime(CMSPeriodStartDate));
                                    InsertCMSParentAnswerCriteria(textline, startDateConverter);
                                    break;
                                case "CMSPARENTANSWERCRITERIASET":
                                    //LDW InsertCMSParentAnswerCriteriaSet(ref textline, ref Convert.ToDateTime(CMSPeriodStartDate));
                                    InsertCMSParentAnswerCriteriaSet(textline, startDateConverter);
                                    break;
                                case "CMSFIELDMEASURECRITERIA":
                                    //LDW InsertCMSFieldMeasureCriteria(ref textline, ref Convert.ToDateTime(CMSPeriodStartDate));
                                    InsertCMSFieldMeasureCriteria(textline, startDateConverter);
                                    break;
                                case "CMSFIELDMEASURECRITERIASET":
                                    //LDW InsertCMSFieldMeasureCriteriaSet(ref textline, ref Convert.ToDateTime(CMSPeriodStartDate));
                                    InsertCMSFieldMeasureCriteriaSet(textline, startDateConverter);
                                    break;
                            }
                        }
                    }

                    //LDW gv_cn.Execute("update tbl_setup_datadef Set cmsfieldcode = calcparent From tbl_Setup_CMSFieldMeasures Where tbl_Setup_CMSFieldMeasures.DDID = tbl_Setup_DataDef.DDID ");
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "update tbl_setup_datadef Set cmsfieldcode = calcparent From tbl_Setup_CMSFieldMeasures Where tbl_Setup_CMSFieldMeasures.DDID = tbl_Setup_DataDef.DDID ");

                    //LDW gv_cn.Execute("update  tbl_Setup_CMSFieldMeasures Set calcparent = Null ");
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, "update tbl_setup_datadef Set cmsfieldcode = calcparent From tbl_Setup_CMSFieldMeasures Where tbl_Setup_CMSFieldMeasures.DDID = tbl_Setup_DataDef.DDID ");
                    FileSystem.FileClose(FileNum);
                    Cursor.Current = Cursors.Default;
                    //LDW RadMessageBox.Show("CMS Setup Import Complete.");

                    DialogResult ds10 = RadMessageBox.Show("CMS Setup Import Complete.", "CMS Setup Import", MessageBoxButtons.OK, RadMessageIcon.Info);
                    ds10.ToString();
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

        private static void InsertCMSFieldMeasures( string textline, DateTime startDate)
        {
            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            string InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

            try
            {
                //0 = FieldMeasureID
                //1 = DDID
                //2 = IndicatorID
                //3 = MeasureCode / Indicator Name
                //4 = FieldEdit
                //5 = LookupTableID
                //6 = OutputFormat
                //7 = CMSFieldCode

                gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_CMSFieldMeasures ON;INSERT INTO tbl_setup_CMSFieldMeasures( FieldMeasureId, DDID, " +
                    "IndicatorID, MeasureCode, FieldEdit, LookupTableID, OutputFormat, CalcParent )  VALUES ({0});SET IDENTITY_INSERT tbl_Setup_CMSFieldMeasures OFF;", InsertLine);

                //LDW gv_cn.Execute(gv_sql);
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

        private static void InsertCMSParentCD(string textline, DateTime startDate)
        {
            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            string InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

            //0 = CMSParentCDID
            //1 = CMSParentCD
            //2 = AnswerCDDDID
            //3 = LookupTableID
            //4 = AnswerFormat
            //5 = DefaultValue
            try
            {
                gv_sql = string.Format("INSERT INTO tbl_setup_CMSParentCD (CMSParentCDID, CMSParentCD,  AnswerCDDDID, LookupTableID, AnswerFormat, DefaultValue) VALUES ({0})", InsertLine);

                //LDW gv_cn.Execute(gv_sql);
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

        private static void InsertCMSParentFieldMeasures( string textline, DateTime startDate)
        {
            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            string InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

            //0 = CMSParentCDID
            //1 = FieldMeasureID
            try
            {
                gv_sql = string.Format("INSERT INTO tbl_setup_CMSParentFieldMeasures (CMSParentCDID, FieldMeasureID)  VALUES ({0})", InsertLine);

                //LDW gv_cn.Execute(gv_sql);
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

        private static void InsertCMSParentAnswerCriteria(string textline, DateTime startDate)
        {
            try
            {
                //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
                string InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

                //0 = CMSParentAnswerCriteriaID
                //1 = CMSParentCDID
                //2 = CMSParentAnswerCriteriaSet
                //3 = CriteriaTitle
                //4 = DDID1
                //5 = DDID2
                //6 = ValueOperator
                //7 = FieldValue
                //8 = DestDDID
                //9 = LookupID
                //10 = FieldOperator
                //11 = DateUnit
                //12 = JoinOperator
                //13 = LookupTableID

                gv_sql = string.Format("INSERT INTO tbl_setup_CmsParentAnswerCriteria (CMSParentAnswerCriteriaID,   CMSParentCDID, CMSParentAnswerCriteriaSet, " + 
                    "CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, LookupID,  FieldOperator, DateUnit, JoinOperator, LookupTableID) VALUES ({0})", InsertLine);

                //LDW gv_cn.Execute(gv_sql);
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

        private static void InsertCMSParentAnswerCriteriaSet(string textline, DateTime startDate)
        {
            try
            {
                //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
                string InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());


                //0 = CMSParentCDID
                //1 = CMSParentAnswerCriteriaSet
                //2 = JoinOperator

                gv_sql = string.Format("INSERT INTO tbl_setup_CMSParentAnswerCriteriaSet (CMSParentCDID,  CMSParentAnswerCriteriaSet, JoinOperator) VALUES ({0})", InsertLine);

                //LDW gv_cn.Execute(gv_sql);
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

        private static void InsertCMSFieldMeasureCriteria(string textline, DateTime startDate)
        {
            try
            {
                //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
                string InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

                //0 = CMSFieldMeasureCriteriaID
                //1 = CMSFieldMeasureID
                //2 = CMSFieldMeasureCriteriaSet
                //3 = CriteriaTitle
                //4 = DDID1
                //5 = DDID2
                //6 = ValueOperator
                //7 = FieldValue
                //8 = DestDDID
                //9 = LookupID
                //10 = FieldOperator
                //11 = DateUnit
                //12 = JoinOperator
                //13 = LookupTableID

                gv_sql = string.Format("INSERT INTO tbl_setup_CmsFieldMeasureCriteria (CMSFieldMeasureCriteriaID,   CMSFieldMeasureID, CMSFieldMeasureCriteriaSet, CriteriaTitle, DDID1, DDID2, ValueOperator, FieldValue, DestDDID, LookupID,  FieldOperator, DateUnit, JoinOperator, LookupTableID) VALUES ({0})", InsertLine);

                //LDW gv_cn.Execute(gv_sql);
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

        private static void InsertCMSFieldMeasureCriteriaSet(string textline, DateTime startDate)
        {
            try
            {
                //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
                string InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

                //0 = CMSFieldMeasureID
                //1 = CMSFieldMeasureCriteriaSet
                //2 = JoinOperator

                gv_sql = string.Format("INSERT INTO tbl_setup_CMSFieldMeasureCriteriaSet (CMSFieldMeasureID,  CMSFieldMeasureCriteriaSet, JoinOperator) VALUES ({0})", InsertLine);

                //LDW gv_cn.Execute(gv_sql);
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

        //LDW public static short GetCurrentVersion()
        public static int GetCurrentVersion()
        {
            //LDW short functionReturnValue = 0;
            int functionReturnValue = 0;
            const string sqlTablename10 = "tbl_Setup_Version";

            try
            {
                gv_sql = "SELECT MAX(VersionNumber) as MaxVal FROM tbl_Setup_Version";

                //LDW gv_rs = gv_cn.OpenResultset(gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                gv_rs = DALcop.DalConnectDataSet(gv_cn.ConnectionString, gv_sql, sqlTablename10, gv_rs);

                //LDW functionReturnValue = (Information.IsDBNull(gv_rs.rdoColumns["maxVal"].Value) ? 0 : gv_rs.rdoColumns["maxVal"].Value);
                functionReturnValue = (Information.IsDBNull(Convert.ToInt32(gv_rs.Tables[sqlTablename10].Rows[0]["maxVal"])) ? 0 : Convert.ToInt32(gv_rs.Tables[sqlTablename10].Rows[0]["maxVal"]));

                //LDW gv_rs.Close();
                gv_rs.Dispose();
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
    }
}
