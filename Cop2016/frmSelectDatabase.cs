using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Telerik.WinControls;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    
    internal partial class frmSelectDatabase : Telerik.WinControls.UI.RadForm
    {
        private const short REG_SZ = 1;
        //LDW private const int HKEY_LOCAL_MACHINE = Convert.ToInt32(0x80000002);
        private uint HKEY_LOCAL_MACHINE = 0x80000002;
        [DllImport("advapi32.dll", EntryPoint = "RegCreateKeyA", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int RegCreateKey(uint hKey, string lpSubKey, ref int phkResult);
        [DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int RegSetValueEx(int hKey, string lpValueName, int Reserved, int dwType, ref string lpData, int cbData);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int RegCloseKey(int hKey);

        

        public frmSelectDatabase()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            frmSetupSelection frmSetupSelectionCopy = new frmSetupSelection();

            try
            {
                if (optIHHA.IsChecked == true)
                {
                    modGlobal.gv_selecteddatabasename = "COP2001";
                    modGlobal.gv_selecteddatabase = "IHHA";
                }
                else if (optCurrent.IsChecked == true)
                {
                    modGlobal.gv_selecteddatabasename = "COP2001Current";
                    modGlobal.gv_selecteddatabase = "Current";
                }
                else if (optArchive.IsChecked == true)
                {
                    modGlobal.gv_selecteddatabasename = "COP2001Archive";
                    modGlobal.gv_selecteddatabase = "Archive";
                    //    ElseIf OptCOPWeb Then
                    //
                    //        gv_selecteddatabasename = "COPWebSetup"
                    //        gv_selecteddatabase = "COPWebSetup"
                    //        CreateDSN
                    //
                    //        On Error GoTo 0
                }
                modGlobal.ConnectToDatabase();

                if (modGlobal.gv_connectionstatus == "pass")
                {
                    this.Close();
                    frmSetupSelectionCopy.Show();
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

        private void CreateDSN()
        {
            //Specify the DSN parameters.
            const string DataSourceName = "COPWebSetup";
            string DatabaseName = "CopWebSetup";
            string Description = "Setup created this DSN";
            string DriverPath = "C:WINNTSystem32SQLSRV32.DLL";
            string DriverName = "SQL Server";
            string LastUser = "cop";
            string Regional = null;
            string Server = "TANTRUM";
            int lResult = 0;
            int hKeyHandle = 0;

            try
            {
                //Create the new DSN key.
                lResult = RegCreateKey(HKEY_LOCAL_MACHINE, "SOFTWARE\\ODBC\\ODBC.INI\\" + DataSourceName, ref hKeyHandle);

                //Set the values of the new DSN key.
                lResult = RegSetValueEx(hKeyHandle, "Database", 0, REG_SZ, ref DatabaseName, Strings.Len(DatabaseName));
                lResult = RegSetValueEx(hKeyHandle, "Description", 0, REG_SZ, ref Description, Strings.Len(Description));
                lResult = RegSetValueEx(hKeyHandle, "Driver", 0, REG_SZ, ref DriverPath, Strings.Len(DriverPath));
                lResult = RegSetValueEx(hKeyHandle, "LastUser", 0, REG_SZ, ref LastUser, Strings.Len(LastUser));
                lResult = RegSetValueEx(hKeyHandle, "Server", 0, REG_SZ, ref Server, Strings.Len(Server));

                //Close the new DSN key.
                lResult = RegCloseKey(hKeyHandle);

                //Open ODBC Data Sources key to list the new DSN in the ODBC Manager.
                //Specify the new value.
                //Close the key.

                lResult = RegCreateKey(HKEY_LOCAL_MACHINE, "SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", ref hKeyHandle);
                lResult = RegSetValueEx(hKeyHandle, DataSourceName, 0, REG_SZ, ref DriverName, Strings.Len(DriverName));
                lResult = RegCloseKey(hKeyHandle);
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

        private void frmSelectDatabase_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
