using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
 // ERROR: Not supported in C#: OptionDeclaration
using VB = Microsoft.VisualBasic;
namespace COP2001
{
	internal partial class frmFindAFile : System.Windows.Forms.Form
	{
		private string is_DefaultPath;

//UPGRADE_WARNING: Event cmbType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
		private void cmbType_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{


			if (Strings.Mid(cmbType.Text, 1, 3) == "All") {
				lblFile.Text = "*.*";
				fileList.Pattern = "*.*";
			} else if (Strings.Mid(cmbType.Text, 1, 3) == "Tex") {
				lblFile.Text = "*.txt;*.csv";
				fileList.Pattern = "*.txt;*.csv";
			} else {
				lblFile.Text = "*.xls;*.xlsx";
				fileList.Pattern = "*.xls;*.xlsx";
			}

			//

		}

		private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object GlobalSelectedFileName = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object GlobalSelectedFileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			GlobalSelectedFileName = "";
			//
			// just quit the form
			//
			this.Close();

		}

		private void cmdOK_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//
			// Save the selected file name
			//
			if (Strings.Mid(dirList.Path, Strings.Len(dirList.Path), 1) == "\\") {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_SelectedFileWithPath = dirList.Path + lblFile.Text;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_SelectedFileWithPath = dirList.Path + "\\" + lblFile.Text;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_SelectedFileName = lblFile.Text;
			modGlobal.gv_SelectedDirectory = dirList.Path;
			//
			// now close the form
			//
			this.Close();

		}


		private void dirList_Change(System.Object eventSender, System.EventArgs eventArgs)
		{
			object lblDirPath = null;

			// Update the file list box to synchronize with the directory list box.
			fileList.Path = dirList.Path;
			// show the path
			//UPGRADE_WARNING: Couldn't resolve default property of object lblDirPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblDirPath = dirList.Path;
			//fileList.Pattern = "*.txt;*.csv;"
			fileList.Pattern = lblFile.Text;

		}

		private void DrvList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			 // ERROR: Not supported in C#: OnErrorStatement

			dirList.Path = drvList.Drive;
			return;
			DriveHandler:

			drvList.Drive = dirList.Path;
			return;

		}


		private void fileList_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
		{

			//
			lblFile.Text = fileList.FileName;

		}

		private void frmFindAFile_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			 // ERROR: Not supported in C#: OnErrorStatement


			if (!string.IsNullOrEmpty(is_DefaultPath)) {
				drvList.Drive = Strings.Left(is_DefaultPath, 3);
				dirList.Path = is_DefaultPath;
			} else {
				drvList.Drive = modGlobal.GLthisDrive;
			}

			if (!string.IsNullOrEmpty(modGlobal.GLThisPath)) {
				 // ERROR: Not supported in C#: OnErrorStatement


				dirList.Path = modGlobal.GLThisPath;

			}

			cmbType.SelectedIndex = 0;

			return;
			FindPath_Error:

			 // ERROR: Not supported in C#: OnErrorStatement

			drvList.Drive = "C:\\";
			dirList.Path = "C:\\";
			 // ERROR: Not supported in C#: ResumeStatement


		}


		public object SetPath(ref string defaultPath)
		{
			is_DefaultPath = defaultPath;
		}
	}
}
