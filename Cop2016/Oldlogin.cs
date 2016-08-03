using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
 // ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
	internal partial class OldLogin : System.Windows.Forms.Form
	{
		object badtrycount;
		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			//just quit now...
			this.Close();

		}

		private void cmdOK_Click(System.Object eventSender, System.EventArgs eventArgs)
		{

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Username. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_Username = txtUserName.Text;
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_password. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_password = txtPassword.Text;

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_password. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_Username. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if ((string.IsNullOrEmpty(modGlobal.gv_Username) | string.IsNullOrEmpty(modGlobal.gv_password))) {
				Interaction.MsgBox("Please enter username and password");
				System.Environment.Exit(0);
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_connectionstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (modGlobal.gv_connectionstatus == "pass") {
				this.Close();
				frmSelectDatabase.ShowDialog();
			}


		}


		private void Login_Load(System.Object eventSender, System.EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: App property App.PrevInstance was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			if (App.PrevInstance) {
				Interaction.MsgBox("This application is already running");
				this.Close();
				System.Environment.Exit(0);
			}

			//center the form
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width)) / 2);
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height)) / 2);

			txtUserName.Text = "cop";
			//txtPassword.Text = "assoc"
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_connectionstatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_connectionstatus = "pass";
			//This global variable is defined in Contacts.BAS
			//UPGRADE_WARNING: Couldn't resolve default property of object badtrycount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			badtrycount = 0;

		}

		private void txtPassword_KeyDown(System.Object eventSender, System.Windows.Forms.KeyEventArgs eventArgs)
		{
			short Keycode = eventArgs.KeyCode;
			short Shift = eventArgs.KeyData / 0x10000;

			//if enter, go ahead and check the password
			switch (Keycode) {
				case System.Windows.Forms.Keys.Return:
					cmdOK_Click(cmdOk, new System.EventArgs());
					break;
				case System.Windows.Forms.Keys.Escape:
					this.Close();
					break;
			}

		}
	}
}
