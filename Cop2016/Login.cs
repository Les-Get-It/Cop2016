using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using System.Drawing;

namespace COP2001
{
    public partial class Login : Telerik.WinControls.UI.RadForm
    {
        int badtrycount;


        public Login()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                modGlobal.gv_Username = txtUserName.Text.Trim();
                modGlobal.gv_password = txtPassword.Text.Trim();

                if ((string.IsNullOrEmpty(modGlobal.gv_Username) | string.IsNullOrEmpty(modGlobal.gv_password)))
                {
                    //LDW RadMessageBox.Show("Please enter username and password");
                    DialogResult ds = RadMessageBox.Show(this, "Please enter username and password", "Login", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    this.Text = ds.ToString();
                    //LDW Environment.Exit(0);
                    return;
                }

                if (modGlobal.gv_connectionstatus == "pass")
                {
                    frmSelectDatabase frmSelectDatabaseCopy = new frmSelectDatabase();
                    frmSelectDatabaseCopy.Show();
                    this.Hide();
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Shut her down...
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //center the form
            this.CenterToScreen();
            //if (App.PrevInstance)
            Process aProcess = Process.GetCurrentProcess();
            string aProcName = aProcess.ProcessName;

            try
            {

                if (Process.GetProcessesByName(aProcName).Length > 1)
                {
                    //LDW RadMessageBox.Show("This application is already running");

                    DialogResult ds = RadMessageBox.Show(this, "This application is already running", "Login", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    this.Text = ds.ToString();
                    this.Close();
                    Environment.Exit(0);
                }

                

                txtUserName.Text = "cop";
                //txtPassword.Text = "assoc"
                modGlobal.gv_connectionstatus = "pass";
                //This global variable is defined in Contacts.BAS
                badtrycount = 0;
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

        private void txtPassword_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            /*LDW short Keycode = eventArgs.KeyCode;
            short Shift = eventArgs.KeyData / 0x10000;*/

            Keys Keycode = eventArgs.KeyCode;
            short Shift = Convert.ToInt16(Convert.ToInt32(eventArgs.KeyData) / 0x10000);

            try
            {
                //if enter, go ahead and check the password
                switch (Keycode)
                {
                    case Keys.Return:
                        //LDW cmdOK_Click(cmdOk, new System.EventArgs());
                        cmdOk_Click(cmdOk, new EventArgs());
                        break;
                    case Keys.Escape:
                        this.Close();
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
        }
    }
}
