using System;
using System.Diagnostics;
using Telerik.WinControls;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{

    static class modDBSetup
    {
        public static int FindMaxRecID(string sqlTableName, string sqlFieldName)
        {
            int functionReturnValue = 0;

            try
            {

                modGlobal.gv_sql = string.Format("Select Max({0}) as maxID from {1}", sqlFieldName, sqlTableName);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName, modGlobal.gv_rs);

                //LDW old code
                // if (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["MaxID"].Value)) {
                //	functionReturnValue = 1;
                //} else {
                //	functionReturnValue = modGlobal.gv_rs.rdoColumns["MaxID"].Value + 1;
                //}
                //modGlobal.gv_rs.Close();
                //return functionReturnValue;
                //Take MAXID column and convert to int to complete logic for the functionReturnValue

                //LDW updated code
                int o = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName].Rows[0]["MaxID"]);
                int maxColumn = o;

                if (modGlobal.gv_rs.Tables[sqlTableName].Rows[0]["MaxID"] == null)
                {
                    functionReturnValue = 1;
                }
                else
                {
                    functionReturnValue = maxColumn + 1;
                }
                //LDW modGlobal.gv_rs.Close();
                //LDW update the closing to the dataset
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
            return functionReturnValue;
        }
    }
}
