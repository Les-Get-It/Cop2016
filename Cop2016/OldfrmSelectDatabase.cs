using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
	internal partial class OldfrmSelectDatabase : System.Windows.Forms.Form
	{

			//Constant for a string variable type.
		private const short REG_SZ = 1;
		private const int HKEY_LOCAL_MACHINE = 0x80000002;
		[DllImport("advapi32.dll", EntryPoint = "RegCreateKeyA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int RegCreateKey(int hKey, string lpSubKey, ref int phkResult);
		[DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

//UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
		private static extern int RegSetValueEx(int hKey, string lpValueName, int Reserved, int dwType, ref Any lpData, int cbData);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int RegCloseKey(int hKey);


		private void cmdConnect_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (optIHHA.Checked == true) {
				modGlobal.gv_selecteddatabasename = "COP2001";
				modGlobal.gv_selecteddatabase = "IHHA";
			} else if (optCurrent.Checked == true) {
				modGlobal.gv_selecteddatabasename = "COP2001Current";
				modGlobal.gv_selecteddatabase = "Current";
			} else if (optArchive.Checked) {
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




			//UPGRADE_WARNING: Couldn't resolve default property of object gv_connectionstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_connectionstatus == "pass") {
				this.Close();
				My.MyProject.Forms.frmSetupSelection.Show();
			}

		}

		private void frmSelectDatabase_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));


		}

		private void CreateDSN()
		{

			string DataSourceName = null;
			string DatabaseName = null;
			string Description = null;
			string DriverPath = null;
			string DriverName = null;
			string LastUser = null;
			string Regional = null;
			string Server = null;

			int lResult = 0;
			int hKeyHandle = 0;

			//Specify the DSN parameters.

			DataSourceName = "COPWebSetup";
			DatabaseName = "CopWebSetup";
			Description = "Setup created this DSN";
			DriverPath = "C:WINNTSystem32SQLSRV32.DLL";
			LastUser = "cop";
			Server = "TANTRUM";
			DriverName = "SQL Server";

			//Create the new DSN key.

			 // ERROR: Not supported in C#: OnErrorStatement


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
	}
}
