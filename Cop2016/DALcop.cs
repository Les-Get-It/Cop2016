/****************************************************************************************
Dev- Les Wafford
Date- 3/23/16
Purpose- Created reusable methods for data access.
*****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Telerik.WinControls;
using System.Diagnostics;

namespace COP2001
{
    public static class DALcop
    {

        private static string GetErrorMessage()
        {
            const string errorMessage = "Oops...Something went wrong... ";
            return errorMessage;
        }

        //private static void CreateSourceAndLogIfItDoesNotAlreadyExist()
        //{
        //    // Create the source and log, if it does not already exist.
        //    if (!EventLog.SourceExists("CopSetup"))
        //    {
        //        EventLog.CreateEventSource("CopSetup", "CopSetupLog");
        //    }
        //}


        public static DataSet DalConnectDataSet(string connectionString, string queryString, string sqlTable, DataSet dalDataSet)
        {
            string errorMessage = GetErrorMessage();
            DataSet sqlAdptReturn = new DataSet();


            using (SqlConnection dbConn = new SqlConnection(connectionString))

            using (SqlCommand command = new SqlCommand(queryString, dbConn))
            using (SqlDataAdapter sqlAdpt = new SqlDataAdapter(queryString, dbConn))
            {
                try
                {
                    //Open the db connection
                    //dbConn.Open();

                    //Create DataTable
                    dalDataSet.Tables.Add(sqlTable);

                    //Create SqlDataAdapter to load dataset


                    sqlAdpt.Fill(dalDataSet, sqlTable);
                    //dalDataSet.AcceptChanges();
                    sqlAdptReturn = dalDataSet;

                    //Close the db connection
                    sqlAdpt.Dispose();
                }

                //Handle database connection errors
                //catch (SqlException ex)
                //{
                //    RadMessageBox.Show(errorMessage + String.Format(format: "SqlException: {0}", arg0: ex.Message));
                //}

                catch (Exception ex)
                {
                    //CreateSourceAndLogIfItDoesNotAlreadyExist();

                    // Create an EventLog instance and assign its source.
                    EventLog appLog = new EventLog();
                    appLog.Source = "CopSetup";

                    appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                        ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1000);

                    RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
                }

                //Close database connection ***May not need this since SqlDataAdapter manages own connections***
                finally
                {
                    if (dbConn != null)
                    {
                        dbConn.Close();
                    }
                }
                return sqlAdptReturn;
            }
        }

        public static void ExecuteCommand(string connectionString, string queryString)
        {
            var errorMessage = GetErrorMessage();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                //Handle database connection errors
                catch (Exception ex)
                {
                    //CreateSourceAndLogIfItDoesNotAlreadyExist();

                    // Create an EventLog instance and assign its source.
                    EventLog appLog = new EventLog();
                    appLog.Source = "CopSetup";

                    appLog.WriteEntry(errorMessage + "Source: " + ex.Source + "=>" + "TargetSite: " + ex.TargetSite + "Exception #: " + ex.HResult + " => " + "Error Message: " +
                        ex.Message + " => " + "Inner Exception: " + ex.InnerException + " => " + "Stack Trace: " + ex.StackTrace, EventLogEntryType.Error, 1001);

                    RadMessageBox.Show(errorMessage + String.Format(format: "Exception: {0}  => Inner Exception: {1}", arg0: ex.Message, arg1: ex.InnerException));
                }
            }
        }
    }
}




