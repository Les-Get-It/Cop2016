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
	internal partial class FileFind : System.Windows.Forms.Form
	{

		private void cmbType_Click()
		{
			object cmbType = null;
			object fileList = null;
			object lblFile = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object cmbType.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (Strings.Mid(cmbType.Text, 1, 3) == "Dat") {
				//UPGRADE_WARNING: Couldn't resolve default property of object lblFile.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblFile.Caption = "*.dat";
				//UPGRADE_WARNING: Couldn't resolve default property of object fileList.Pattern. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fileList.Pattern = "*.dat";
				//UPGRADE_WARNING: Couldn't resolve default property of object cmbType.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (Strings.Mid(cmbType.Text, 1, 3) == "Tex") {
				//UPGRADE_WARNING: Couldn't resolve default property of object lblFile.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblFile.Caption = "*.txt";
				//UPGRADE_WARNING: Couldn't resolve default property of object fileList.Pattern. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fileList.Pattern = "*.txt";
				//UPGRADE_WARNING: Couldn't resolve default property of object cmbType.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			} else if (Strings.Mid(cmbType.Text, 1, 3) == "All") {
				//UPGRADE_WARNING: Couldn't resolve default property of object lblFile.Caption. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lblFile.Caption = "*.*";
				//UPGRADE_WARNING: Couldn't resolve default property of object fileList.Pattern. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fileList.Pattern = "*.*";
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
			//GlobalSelectedFileName = dirList.Path & "\" & lblFile
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
			//fileList.Path = dirList.Path
			// show the path
			//UPGRADE_WARNING: Couldn't resolve default property of object lblDirPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblDirPath = dirList.Path;

		}

		private void DrvList_Change()
		{
			object drvList = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			//UPGRADE_WARNING: Couldn't resolve default property of object drvList.Drive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dirList.Path = drvList.Drive;
			return;
			DriveHandler:

			//UPGRADE_WARNING: Couldn't resolve default property of object drvList.Drive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			drvList.Drive = dirList.Path;
			return;

		}


		private void fileList_Click()
		{
			object lblFile = null;
			object fileList = null;

			//
			//UPGRADE_WARNING: Couldn't resolve default property of object fileList.FileName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object lblFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lblFile = fileList.FileName;

		}

		private void FileFind_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
			this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));
			 // ERROR: Not supported in C#: OnErrorStatement

			//drvList.Drive = "\\hal9000\IHANet\Data\Projects\COP" 'GLthisDrive

			if (!string.IsNullOrEmpty(modGlobal.GLThisPath)) {
				 // ERROR: Not supported in C#: OnErrorStatement

				dirList.Path = modGlobal.GLThisPath;
			}
			//cmbType.ListIndex = 0

			return;
			FindPath_Error:

			 // ERROR: Not supported in C#: OnErrorStatement

			//drvList.Drive = "C:\"
			dirList.Path = "C:\\";
			 // ERROR: Not supported in C#: ResumeStatement


		}
	}
}
