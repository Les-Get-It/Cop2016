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
	internal partial class OldfrmMainMenu : System.Windows.Forms.Form
	{
		object NewFieldName;
		private void frmMainMenu_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			//ConnectToDatabase
			//Dim wrkODBC As Workspace
			//Dim conpubs As Connection
			//Set wrkODBC = CreateWorkspace("NewODBCWorkspace", "", "", dbUseODBC)
			//Set conpubs = wrkODBC.OpenConnection("Connection1", , , "ODBC;DATABASE=COP2001;UID=sa;PWD=;DSN=COP2001")
			//Set dtHelp.Recordset = conpubs.OpenRecordset(gv_sql, 2)

			if (modGlobal.gv_selecteddatabase == "IHHA") {
				lblDatabase.Text = "IHHA - To accept new changes";
				//mnuImportDataDef.Enabled = False

				mnuUpdateSystemSetup.Enabled = false;
			} else if (modGlobal.gv_selecteddatabase == "Current") {
				lblDatabase.Text = "Current - To process hospital data";
				//mnuSubmitSetup.Enabled = False
				//mnuUpdateExistingDB.Enabled = False
			} else if (modGlobal.gv_selecteddatabase == "Archive") {
				lblDatabase.Text = modGlobal.gv_selecteddatabase;
				//mnuUpdateSystemSetup.Enabled = False
				//mnuSubmitSetup.Enabled = False
				//mnuUpdateExistingDB.Enabled = False
			} else if (modGlobal.gv_selecteddatabase == "COPWebSetup") {
				lblDatabase.Text = "COPWebSetup - To create test Web Setups";
			}

			lblDatabase.Width = this.Width;
			lblDatabase.Left = 0;

			modGlobal.gv_sql = "Select * from tbl_Setup_TableDef";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			if (modGlobal.gv_rs.RowCount == 0) {
				InitializeTableDef();
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (!string.IsNullOrEmpty(modGlobal.gv_State)) {
				mnuImport.Enabled = false;
				//mnuSubmitSetup.Enabled = False
				//mnuImportDataDef.Enabled = False
			} else {
				//mnuStateSetup.Enabled = False
			}

			//*** Warning: remove this before delivery
			//gv_sql = "delete tbl_setup_DataDef "
			//gv_cn.Execute gv_sql


		}

		private void frmMainMenu_FormClosed(System.Object eventSender, System.Windows.Forms.FormClosedEventArgs eventArgs)
		{
			System.Windows.Forms.Form frm = null;

			foreach (Form frm_loopVariable in COP2001.My.MyProject.Application.OpenForms) {
				frm = frm_loopVariable;
				frm.Close();
			}
			//UPGRADE_NOTE: Object frm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			frm = null;

			modGlobal.gv_cn.Close();
			//UPGRADE_NOTE: Object gv_cn may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_cn = null;

			//UPGRADE_NOTE: Object gv_rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_rs = null;

			modGlobal.gv_en.Close();
			//UPGRADE_NOTE: Object gv_en may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_en = null;
		}

		public void mnuClose_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			System.Windows.Forms.Form frm = null;

			foreach (Form frm_loopVariable in COP2001.My.MyProject.Application.OpenForms) {
				frm = frm_loopVariable;
				frm.Close();
			}

			//UPGRADE_NOTE: Object gv_en may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_en = null;
			//UPGRADE_NOTE: Object gv_cn may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_cn = null;
			//UPGRADE_NOTE: Object gv_rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			modGlobal.gv_rs = null;

			this.Close();
		}

		public void mnuCreateCMSSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object multiple = null;
			object OutputFormat = null;
			object LookupTableID = null;
			object fieldedit = null;
			object cmsfieldcode = null;
			object DDID = null;
			object measurecode = null;
			object IndicatorID = null;
			object FileNum = null;
			object UpdateFile = null;
			object Quarter = null;
			string thisquarter = null;

			if (DateAndTime.Month(DateAndTime.Now) == 1 | DateAndTime.Month(DateAndTime.Now) == 2 | DateAndTime.Month(DateAndTime.Now) == 3) {
				thisquarter = "1/1/" + DateAndTime.Year(DateAndTime.Now);
			} else if (DateAndTime.Month(DateAndTime.Now) == 4 | DateAndTime.Month(DateAndTime.Now) == 5 | DateAndTime.Month(DateAndTime.Now) == 6) {
				thisquarter = "4/1/" + DateAndTime.Year(DateAndTime.Now);
			} else if (DateAndTime.Month(DateAndTime.Now) == 7 | DateAndTime.Month(DateAndTime.Now) == 8 | DateAndTime.Month(DateAndTime.Now) == 9) {
				thisquarter = "7/1/" + DateAndTime.Year(DateAndTime.Now);
			} else if (DateAndTime.Month(DateAndTime.Now) == 10 | DateAndTime.Month(DateAndTime.Now) == 11 | DateAndTime.Month(DateAndTime.Now) == 12) {
				thisquarter = "10/1/" + DateAndTime.Year(DateAndTime.Now);
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Quarter = Interaction.InputBox("Type in the first day of the selected quarter.", "CMS Setup Export", thisquarter);

			//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(Quarter) | Information.IsDBNull(Quarter)) {
				return;
			}

			My.MyProject.Forms.FileFind.Text = "Specify the destination directory for CMSSetup.txt";
			My.MyProject.Forms.FileFind.ShowDialog();
			if (!string.IsNullOrEmpty(modGlobal.gv_SelectedDirectory)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				UpdateFile = modGlobal.gv_SelectedDirectory + (Strings.Mid(modGlobal.gv_SelectedDirectory, Strings.Len(modGlobal.gv_SelectedDirectory), 1) == "\\" ? "CMSSetup.txt" : "\\CMSSetup.txt");
			} else {
				return;
			}

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileNum = FreeFile();
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileOpen(FileNum, UpdateFile, OpenMode.Output);

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[Quarter]");
			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "\"" + Quarter + "\"");

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[CMSFIELDMEASURES]");
			modGlobal.gv_sql = "select distinct * FROM (Select * from vuCMSMappings Union All SELECT * FROM vuJCmappings) map WHERE CMSFieldCode IS NOT NULL ORDER BY CMSFieldCode";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object measurecode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurecode = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object cmsfieldcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cmsfieldcode = "";
				//ParentField = ""
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldedit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fieldedit = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				LookupTableID = "";
				//LinktoDDId = ""
				//LinkParent = ""
				//UPGRADE_WARNING: Couldn't resolve default property of object OutputFormat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				OutputFormat = "";
				//CalcParent = ""
				//CalcParentVal = ""
				//DefaultValue = ""
				//UPGRADE_WARNING: Couldn't resolve default property of object multiple. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				multiple = "";

				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				IndicatorID = modGlobal.gv_rs.rdoColumns["IndicatorID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object measurecode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				measurecode = modGlobal.gv_rs.rdoColumns["measurecode"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				DDID = modGlobal.gv_rs.rdoColumns["DDID"].Value;
				//UPGRADE_WARNING: Couldn't resolve default property of object cmsfieldcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cmsfieldcode = modGlobal.gv_rs.rdoColumns["cmsfieldcode"].Value;

				//        If Not IsNull(gv_rs!ParentField) Then
				//             ParentField = gv_rs!ParentField
				//        End If

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["fieldedit"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object fieldedit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					fieldedit = modGlobal.gv_rs.rdoColumns["fieldedit"].Value;
				}
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["fieldLookupTableID"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					LookupTableID = modGlobal.gv_rs.rdoColumns["fieldLookupTableID"].Value;
				}

				//        If Not IsNull(gv_rs!LinktoDDId) Then
				//            LinktoDDId = gv_rs!LinktoDDId
				//        End If
				//        If Not IsNull(gv_rs!LinkParent) Then
				//            LinkParent = gv_rs!LinkParent
				//        End If

				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				if (!Information.IsDBNull(modGlobal.gv_rs.rdoColumns["OutputFormat"].Value)) {
					//UPGRADE_WARNING: Couldn't resolve default property of object OutputFormat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					OutputFormat = modGlobal.gv_rs.rdoColumns["OutputFormat"].Value;
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


				//UPGRADE_WARNING: Couldn't resolve default property of object cmsfieldcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object OutputFormat. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object LookupTableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object fieldedit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object measurecode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object IndicatorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object DDID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["fieldmeasureid"].Value + "\"" + "," + "\"" + DDID + "\"" + "," + "\"" + IndicatorID + "\"" + "," + "\"" + measurecode + "\"" + "," + "\"" + fieldedit + "\"" + "," + "\"" + LookupTableID + "\"" + "," + "\"" + OutputFormat + "\"" + "," + "\"" + cmsfieldcode + "\"");

				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[CMSPARENTCD]");

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentCD";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCD"].Value + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["AnswerCDDDID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["AnswerCDDDID"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["AnswerFormat"].Value) ? "" : modGlobal.gv_rs.rdoColumns["AnswerFormat"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DefaultValue"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DefaultValue"].Value) + "\"");

				modGlobal.gv_rs.MoveNext();
			}

			modGlobal.gv_rs.Close();


			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[CMSPARENTFIELDMEASURES]");

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentFieldMeasures";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["fieldmeasureid"].Value + "\"");
				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[CMSPARENTANSWERCRITERIA]");

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentAnswerCriteria";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaSet"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["DDID1"].Value + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ddid2"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DestDDID"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupID"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DateUnit"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) + "\"");

				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[CMSPARENTANSWERCRITERIASET]");

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSParentAnswerCriteriaSet";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSParentAnswerCriteriaSet"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + "\"");

				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[CMSFIELDMEASURECRITERIA]");

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSFieldMeasureCriteria";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaSet"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CriteriaTitle"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["DDID1"].Value + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ddid2"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ddid2"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["ValueOperator"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FIELDVALUE"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DestDDID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DestDDID"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupID"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["FieldOperator"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["DateUnit"].Value) ? "" : modGlobal.gv_rs.rdoColumns["DateUnit"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) ? "" : modGlobal.gv_rs.rdoColumns["JoinOperator"].Value) + "\"" + "," + "\"" + (Information.IsDBNull(modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) ? "" : modGlobal.gv_rs.rdoColumns["LookupTableID"].Value) + "\"");

				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.PrintLine(FileNum, "[CMSFIELDMEASURECRITERIASET]");

			modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSFieldMeasureCriteriaSet";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			while (!modGlobal.gv_rs.EOF) {
				//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FileSystem.PrintLine(FileNum, "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureID"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaSet"].Value + "\"" + "," + "\"" + modGlobal.gv_rs.rdoColumns["JoinOperator"].Value + "\"");

				modGlobal.gv_rs.MoveNext();
			}
			modGlobal.gv_rs.Close();

			//UPGRADE_WARNING: Couldn't resolve default property of object FileNum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileClose(FileNum);

			//UPGRADE_WARNING: Couldn't resolve default property of object UpdateFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Interaction.MsgBox("CMS Setup file was exported to " + UpdateFile);

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

		}

		public void mnuDefineFlowcharts_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmMeasureCriteriaSetup.Show();
		}

		public void mnuExportRiskCoef_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmExportCoef.Show();
		}

		public void mnuHospStatSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmHospStatSetup.Show();
		}

		public void mnuImport_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmImportSelectLayout.Show();
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


		public void mnuImportRiskCoefficients_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object TriggerBy2 = null;
			object factorOperator = null;
			object TriggerBy = null;
			object prevCoefID = null;
			object prevquarter = null;
			object prevreportingperiod = null;
			object PrevReportingYear = null;
			object newcoefID = null;
			object ps = null;
			object coefID = null;
			object commapos = null;
			object coefficient = null;
			object Description = null;
			object FactorType = null;
			object FactorStatus = null;
			object FactorID = null;
			object EqType = null;
			object MeasureID = null;
			object TotalRecs = null;
			object ReportingQuarter = null;
			object ReportingYear = null;
			object ReportingPeriod = null;
			object SQL = null;
			object resp = null;
			object Quarter = null;
			var i = 0;
			object textline = null;
			var StartPos = 0;
			object RACOfile = null;
			object msgtitle = null;
			int li_PrevQtr = 0;
			int PreviousQtr = 0;
			System.Data.DataSet  rs_CopyCoef = null;

			PreviousQtr = 0;

			 // ERROR: Not supported in C#: OnErrorStatement


			//UPGRADE_WARNING: Couldn't resolve default property of object msgtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msgtitle = "Load Risk Adjusted Coefficient Data";

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_SelectedFileWithPath = "";
			My.MyProject.Forms.frmFindAFile.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_SelectedFileWithPath)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Interaction.MsgBox("The 'Coefficient File' was not specified.", , msgtitle);
				return;
			}
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object RACOfile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RACOfile = modGlobal.gv_SelectedFileWithPath;

			//get the period of the records, and confirm that user wants to import it
			//UPGRADE_WARNING: Couldn't resolve default property of object RACOfile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileOpen(1, RACOfile, OpenMode.Input);
			if (FileSystem.EOF(1)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Interaction.MsgBox("The file does not contain any data.", , msgtitle);
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StartPos = 1;
				textline = FileSystem.LineInput(1);

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Quarter = Quarter + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '" + Quarter + "'";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (!modGlobal.gv_rs.EOF) {
					FileSystem.FileClose(1);
					//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					resp = Interaction.MsgBox("This period already exists in the database. Are you sure you want to overwrite?", MsgBoxStyle.YesNo, "Import RA Coef.");

					if (resp == MsgBoxResult.No) {
						return;
					} else {

						//UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						resp = Interaction.MsgBox("Would you like to remove the values from this period?  If you choose no, then your links will remain in effect but the coefficients will be updated.", MsgBoxStyle.YesNo, "Remove Field Links & Triggers for this period?");

						if (resp == MsgBoxResult.Yes) {
							//tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Coefid in ";
							//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '" + Quarter + "')";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							modGlobal.gv_cn.Execute(SQL);


							//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Coefid in ";
							//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '" + Quarter + "')";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							modGlobal.gv_cn.Execute(SQL);

							//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Coefid in ";
							//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '" + Quarter + "')";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							modGlobal.gv_cn.Execute(SQL);

							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
							//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Quarter = '" + Quarter + "'";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							modGlobal.gv_cn.Execute(SQL);
						}

					}

				}

				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportingPeriod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportingPeriod = Strings.Mid(Quarter, 5, 2);
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportingYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportingYear = Strings.Mid(Quarter, 1, 4);
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object ReportingQuarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ReportingQuarter = Strings.Mid(Quarter, 5, 2) + ", " + Strings.Mid(Quarter, 1, 4);

				//resp = MsgBox("The Coefficients will be imported for this period: " & ReportingQuarter & ". Do you wish to continue?", vbYesNo, msgtitle)
				//If resp = vbNo Then
				//    Close #1
				//    Exit Sub
				//End If
			}
			FileSystem.FileClose(1);


			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			//remove the previous records
			//sql = "delete tIndicatorRiskAdjustmentCoefficientImported where quarter = '" & Quarter & "'"
			//Set ps = gv_cn.CreatePreparedStatement("", sql)
			//ps.Execute
			//ps.Close

			//UPGRADE_WARNING: Couldn't resolve default property of object TotalRecs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TotalRecs = 0;
			//UPGRADE_WARNING: Couldn't resolve default property of object RACOfile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileOpen(1, RACOfile, OpenMode.Input);
			while (!FileSystem.EOF(1)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object TotalRecs. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TotalRecs = TotalRecs + 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				StartPos = 1;
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Quarter = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				MeasureID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object EqType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				EqType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorID = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorStatus = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				FactorType = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = "";
				//UPGRADE_WARNING: Couldn't resolve default property of object coefficient. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				coefficient = "";

				textline = FileSystem.LineInput(1);

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Quarter = Quarter + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						MeasureID = MeasureID + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object EqType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						EqType = EqType + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						FactorID = FactorID + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object FactorStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						FactorStatus = FactorStatus + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object FactorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						FactorType = FactorType + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}


				//if a doublequote exists that means that there is comma in the description
				// that we have to replace with another character
				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (Strings.Mid(textline, StartPos, 1) == "\"") {
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object commapos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					commapos = Strings.InStr(StartPos + 1, textline, ",");
					//Test = Mid(TextLine, commapos, 1)
					//UPGRADE_WARNING: Couldn't resolve default property of object commapos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (commapos > 0) {
						//UPGRADE_WARNING: Couldn't resolve default property of object commapos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Strings.Mid(textline, commapos, 1) = "@";
					}
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Description = Description + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Description = Strings.Replace(Description, "@", ",");

				//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				for (i = StartPos; i <= Strings.Len(textline); i++) {
					//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (Strings.Mid(textline, i, 1) != ",") {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object textline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object coefficient. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						coefficient = coefficient + Strings.Mid(textline, i, 1);
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object StartPos. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						StartPos = i + 1;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				if (resp == MsgBoxResult.No) {
					modGlobal.gv_sql = "select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureID = " + MeasureID;
					//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and factorid = '" + FactorID + "'";
					//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and Quarter = '" + Quarter + "'";
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (!modGlobal.gv_rs.EOF) {
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						coefID = modGlobal.gv_rs.rdoColumns["coefID"].Value;
					} else {
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						coefID = 0;
					}

					//save this value to copy the factors over for the new coefid
				}

				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + " (Quarter, MeasureID, EqType, FactorID, ";
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + " FactorStatus, FactorType, Description, Coefficient) ";
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + " values (";
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + "'" + Quarter + "', ";
				//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + MeasureID + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object EqType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + EqType + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + "'" + FactorID + "', ";
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorStatus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + FactorStatus + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object FactorType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + "'" + FactorType + "',";
				//UPGRADE_WARNING: Couldn't resolve default property of object Description. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + "'" + Strings.Replace(Description, "'", "''") + "',";
				//UPGRADE_WARNING: Couldn't resolve default property of object coefficient. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + coefficient;
				//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SQL = SQL + ")";
				ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
				//g = InputBox("", "", sql)
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.Execute();
				//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ps.Close();

				//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				newcoefID = modGlobal.GetLastID(ref "tbl_Setup_IndicatorRiskAdjustmentCoefficients");

				if (resp == MsgBoxResult.No) {

					modGlobal.gv_sql = "select coefid, TriggerBy, TriggerBy2, FactorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
					//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where coefID = " + coefID;
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					if (coefID != 0) {
						//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = '" + modGlobal.gv_rs.rdoColumns["TriggerBy"].Value + "'" + ", TriggerBy2 = '" + modGlobal.gv_rs.rdoColumns["TriggerBy2"].Value + "', FactorOperator = '" + modGlobal.gv_rs.rdoColumns["factorOperator"].Value + "' WHERE CoefID = " + newcoefID;
						modGlobal.gv_cn.Execute(modGlobal.gv_sql);

						//COPY THE LINKS TO THE NEW COEF VALUE
						//tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " (CoefID, DDID,tab) ";
						//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " select " + newcoefID + ", ddid,tab";
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " where Coefid = " + coefID;
						ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
						//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ps.Execute();

						//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " (CoefID, TriggerValue, tab) ";
						//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " select " + newcoefID + ", TriggerValue,tab";
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " where Coefid = " + coefID;
						ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
						//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ps.Execute();
						//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ps.Close();

						//tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " (CoefID, factorid,factortxt) ";
						//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " select " + newcoefID + ", factorId, factortxt";
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " where Coefid = " + coefID;
						ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
						//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ps.Execute();
						//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ps.Close();


						//NOW REMOVE THE OLD VALUES
						//tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " where Coefid = " + coefID;
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_cn.Execute(SQL);


						//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " where Coefid = " + coefID;
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_cn.Execute(SQL);

						//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " where Coefid = " + coefID;
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_cn.Execute(SQL);

						//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
						//UPGRADE_WARNING: Couldn't resolve default property of object coefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						SQL = SQL + " where Coefid = " + coefID;
						//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_cn.Execute(SQL);
					}

				}
			}
			FileSystem.FileClose(1);
			//gv_rs.Close


			if (resp != MsgBoxResult.No) {

				modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
				//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where Quarter = '" + Quarter + "' AND FactorID <> 'N'";
				rs_CopyCoef = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				while (!rs_CopyCoef.EOF)
                {
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					MeasureID = rs_CopyCoef.rdoColumns["MeasureID"].Value;
					//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					FactorID = rs_CopyCoef.rdoColumns["FactorID"].Value;
					//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					newcoefID = rs_CopyCoef.rdoColumns["coefID"].Value;

					if (PreviousQtr == 0)
                    {
						li_PrevQtr = 1;
						GetPrevQtr:


						//copy over the child records for existing factors from previous period
						//UPGRADE_WARNING: Couldn't resolve default property of object ReportingPeriod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						if (Convert.ToInt16(ReportingPeriod) - li_PrevQtr < 1) {
							//UPGRADE_WARNING: Couldn't resolve default property of object ReportingYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object PrevReportingYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							PrevReportingYear = Convert.ToInt16(ReportingYear) - Convert.ToDouble(Convert.ToInt32((li_PrevQtr / 4) + 0.5));
							//UPGRADE_WARNING: Couldn't resolve default property of object ReportingPeriod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object prevreportingperiod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							prevreportingperiod = 4 - System.Math.Abs(Convert.ToInt16(ReportingPeriod) - li_PrevQtr);
						} else {
							//UPGRADE_WARNING: Couldn't resolve default property of object ReportingYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object PrevReportingYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							PrevReportingYear = Convert.ToInt16(ReportingYear);
							//UPGRADE_WARNING: Couldn't resolve default property of object ReportingPeriod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object prevreportingperiod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							prevreportingperiod = Convert.ToInt16(ReportingPeriod) - li_PrevQtr;
						}

						//UPGRADE_WARNING: Couldn't resolve default property of object prevreportingperiod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object PrevReportingYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						//UPGRADE_WARNING: Couldn't resolve default property of object prevquarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						prevquarter = PrevReportingYear + "0" + prevreportingperiod;
					}

					modGlobal.gv_sql = "select coefid, TriggerBy, TriggerBy2, FactorOperator from tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
					//UPGRADE_WARNING: Couldn't resolve default property of object MeasureID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureID = " + MeasureID;
					//UPGRADE_WARNING: Couldn't resolve default property of object FactorID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and factorid = '" + FactorID + "'";
					//UPGRADE_WARNING: Couldn't resolve default property of object prevquarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " and Quarter = '" + prevquarter + "'";
					modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

					if (modGlobal.gv_rs.EOF)
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
						modGlobal.gv_rs.MoveLast();
						modGlobal.gv_rs.MoveFirst();

						if (PreviousQtr == 0)
                        {
							PreviousQtr = li_PrevQtr;
						}

						if (modGlobal.gv_rs.RowCount > 0) {
							//UPGRADE_WARNING: Couldn't resolve default property of object prevCoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							prevCoefID = modGlobal.gv_rs.rdoColumns["coefID"].Value;
							//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							TriggerBy = modGlobal.gv_rs.rdoColumns["TriggerBy"].Value;
							//UPGRADE_WARNING: Couldn't resolve default property of object factorOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							factorOperator = modGlobal.gv_rs.rdoColumns["factorOperator"].Value;
							//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							TriggerBy2 = modGlobal.gv_rs.rdoColumns["TriggerBy2"].Value;


							//update TriggerBy in tbl_Setup_IndicatorRiskAdjustmentCoefficients for the new record
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "update tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
							//UPGRADE_WARNING: Couldn't resolve default property of object factorOperator. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object TriggerBy. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " set TriggerBy = '" + TriggerBy + "', TriggerBy2 = '" + TriggerBy2 + "', FactorOperator = '" + factorOperator + "'";
							//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Coefid = " + newcoefID;
							ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Execute();
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Close();

							//tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " (CoefID, DDID,tab) ";
							//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " select " + newcoefID + ", ddid,tab";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
							//UPGRADE_WARNING: Couldn't resolve default property of object prevCoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Coefid = " + prevCoefID;
							ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Execute();
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Close();

							//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " (CoefID, TriggerValue, tab) ";
							//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " select " + newcoefID + ", TriggerValue,tab";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
							//UPGRADE_WARNING: Couldn't resolve default property of object prevCoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Coefid = " + prevCoefID;
							ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Execute();
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Close();

							//tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = "insert into tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " (CoefID, factorid,factortxt) ";
							//UPGRADE_WARNING: Couldn't resolve default property of object newcoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " select " + newcoefID + ", factorID, factortxt";
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " from tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
							//UPGRADE_WARNING: Couldn't resolve default property of object prevCoefID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							//UPGRADE_WARNING: Couldn't resolve default property of object SQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							SQL = SQL + " where Coefid = " + prevCoefID;
							ps = modGlobal.gv_cn.CreatePreparedStatement("", SQL);
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Execute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Execute();
							//UPGRADE_WARNING: Couldn't resolve default property of object ps.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							ps.Close();
						}
					}
					rs_CopyCoef.MoveNext();
				}

				rs_CopyCoef.Close();

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


			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "DELETE FROM tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing WHERE Quarter = '" + Quarter + "'";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing (factorid, Method, Quarter)";
			//UPGRADE_WARNING: Couldn't resolve default property of object prevquarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " SELECT factorid, Method, '" + Quarter + "' FROM tbl_Setup_IndicatorRiskAdjustmentCoefficientsMissing WHERE Quarter = '" + prevquarter + "'";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);


			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			Interaction.MsgBox("Import Complete.");
			return;
			ErrHandler:

			modGlobal.CheckForErrors();

			 // ERROR: Not supported in C#: OnErrorStatement

			FileSystem.FileClose(1);
		}

		public void mnuImpVerifyRecords_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmImportMeasureSetFile.Show();
		}

		public void mnuIndicatorReportSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmIndicatorReportSetup.Show();
		}

		public void mnuIndicatorSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmIndicatorSetup.Show();
		}

		public void mnuLoadCMSSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.ImportCMSSetup();
		}

		public void mnuLookupTableSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmLookupSetup.Show();
		}

		private void mnuMapMeasure_Click()
		{
			object frmMapMeasures = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object frmMapMeasures.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frmMapMeasures.Show();
		}

		public void mnuMeasureSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmMeasureSetup.Show();
		}

		public void mnuPatientfieldExportFormat_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPatientFieldsExportFormat.Show();
		}

		public void mnuPatientSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmPatientSetup.Show();

		}

		private void mnuSecIndFieldSetup_Click()
		{
		}

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

		public void mnuReportSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//MsgBox "Not Ready"
			//Exit Sub
			My.MyProject.Forms.frmReportSetup.Show();
		}

		public void mnuRiskFactorAssociation_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmRiskAdjustment.Show();
		}

		public void mnuRiskSpecs_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object Quarter = null;
			object msgtitle = null;
			 // ERROR: Not supported in C#: OnErrorStatement

			System.Data.DataSet  rs_JCAHOID = null;
			string thisquarter = null;
			//Dim quarter As Integer

			//UPGRADE_WARNING: Couldn't resolve default property of object msgtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			msgtitle = "Load Risk Factor Specs";

			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Quarter = Interaction.InputBox("Enter the quarter effective for these risk specifications (i.e. 1Q2014).", "Risk Specs Import", thisquarter);

			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Quarter = "0" + Quarter;
			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Quarter = Strings.Mid(Quarter, 3, Strings.Len(Quarter)) + Strings.Left(Quarter, 2);
			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Quarter = Strings.Replace(Quarter, "Q", "");

			//UPGRADE_WARNING: Couldn't resolve default property of object Quarter. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "select * from tbl_Setup_IndicatorRiskAdjustmentCoefficients where quarter = '" + Quarter + "'";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.EOF) {
				Interaction.MsgBox("The coeficients have not been entered for this quarter.");
				return;
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_SelectedFileWithPath = "";
			My.MyProject.Forms.frmFindAFile.cmbType.SelectedIndex = 2;
			My.MyProject.Forms.frmFindAFile.ShowDialog();
			//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			if (string.IsNullOrEmpty(modGlobal.gv_SelectedFileWithPath)) {
				//UPGRADE_WARNING: Couldn't resolve default property of object msgtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Interaction.MsgBox("The 'Risk Specs' was not specified.", , msgtitle);
				return;
			}

			 // ERROR: Not supported in C#: OnErrorStatement

			//UPGRADE_WARNING: Couldn't resolve default property of object gv_SelectedFileWithPath. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileSystem.FileCopy(modGlobal.gv_SelectedFileWithPath, "\\\\CREATIVE\\RiskFile\\RFS.xls");

			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

			short TotalRecs = 0;

			TotalRecs = 0;
			//Dim dbtmp As DAO.Database
			//Dim tblObj As DAO.TableDef

			System.Data.DataSet  rsMeasures = null;
			System.Data.DataSet  rsData = null;
			short JCAHOID = 0;


			short X = 0;

			string[] Columns = null;
			string MeasureName = null;
			string SQL = null;
			System.Data.DataSet  rs_CoefID = null;

			string ls_RightCoef = null;
			string ls_LeftCoef = null;
			short li_UnderscorePos = 0;
			object li_CoefID = null;
			System.Data.SqlClient.SqlCommand  ps = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			modGlobal.gv_sql = "EXEC LoadRiskFile";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			if (RDOrdoEngine_definst.rdoErrors(0).Number != 14243) {
				goto ErrHandler;
			} else {
				RDOrdoEngine_definst.rdoErrors.Clear();
			}
			//Set dbtmp = OpenDatabase(gv_SelectedFileWithPath, False, True, "Excel 8.0;")

			System.Windows.Forms.Application.DoEvents();

			 // ERROR: Not supported in C#: OnErrorStatement

			//Set rsMeasures = dbtmp.OpenRecordset("SELECT DISTINCT [Measure], [Model Application Date], [Risk Factor] FROM `Sheet1$`")
			rsMeasures = modGlobal.gv_cn.OpenResultset("SELECT DISTINCT Measure, RiskFactor FROM RiskFileSheet", RDO.ResultsetTypeConstants.rdOpenStatic);

			//Set rsMeasures = dbtmp.OpenRecordset("SELECT DISTINCT [Measure], [Model Application Date], [Risk Factor] FROM `Sheet1$`")
			while (!rsMeasures.EOF) {

				MeasureName = Strings.Mid(rsMeasures.rdoColumns["Measure"].Value, Strings.InStr(1, rsMeasures.rdoColumns["Measure"].Value, "(") + 1, Strings.InStr(1, rsMeasures.rdoColumns["Measure"].Value, ")") - Strings.InStr(1, rsMeasures.rdoColumns["Measure"].Value, "(") - 1);
				modGlobal.gv_sql = "select jcahoid from tbl_setup_indicator where jccode = '" + MeasureName + "' AND JCAHOID IS NOT NULL";
				rs_JCAHOID = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (!rs_JCAHOID.EOF) {
					//If InStr(1, rsMeasures.Fields(2), "RF36") = 0 And InStr(1, rsMeasures.Fields(2), "NBW") = 0 Then
					JCAHOID = rs_JCAHOID.rdoColumns["JCAHOID"].Value;
					//quarter = rsMeasures.Fields(1)

					//quarter = "0" & quarter
					//quarter = mid(quarter, 3, Len(quarter)) & Left(quarter, 2)
					//quarter = Replace(quarter, "Q", "")

					//tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks
					SQL = "delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks ";
					SQL = SQL + " where Coefid in ";
					SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID + "    AND FACTORID NOT LIKE 'RF36%' AND FACTORID NOT LIKE 'NBW%')";
					modGlobal.gv_cn.Execute(SQL);

					//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
					SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers ";
					SQL = SQL + " where Coefid in ";
					SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID + "    AND FACTORID NOT LIKE 'RF36%' AND FACTORID NOT LIKE 'NBW%')";
					modGlobal.gv_cn.Execute(SQL);

					//tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers
					SQL = "Delete tbl_Setup_IndicatorRiskAdjustmentCoefficientFactorLinks ";
					SQL = SQL + " where Coefid in ";
					SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID + "    AND FACTORID NOT LIKE 'RF36%' AND FACTORID NOT LIKE 'NBW%')";
					modGlobal.gv_cn.Execute(SQL);

					//UPDATE ALL THE TriggerBys to CONTAINS for the appropriate risk factors
					SQL = "UPDATE tbl_Setup_IndicatorRiskAdjustmentCoefficients ";
					SQL = SQL + " SET triggerBy = 'Contains' where Coefid in ";
					SQL = SQL + " (select coefid from tbl_Setup_IndicatorRiskAdjustmentCoefficients where measureid = " + JCAHOID;
					SQL = SQL + "  AND charindex('AGE', FactorID) = 0 ";
					SQL = SQL + "   AND charindex('_', FactorID) = 0 ";
					SQL = SQL + "   AND FactorID <> 'N' ";
					SQL = SQL + "   AND FACTORID NOT LIKE 'RF36%' ";
					SQL = SQL + "   AND FACTORID NOT LIKE 'NBW%')";

					modGlobal.gv_cn.Execute(SQL);
					//End If            'Debug.Print sql

				}
				rs_JCAHOID.Close();

				rsMeasures.MoveNext();
			}

			rsMeasures.Close();

			rsData = modGlobal.gv_cn.OpenResultset("SELECT * FROM RiskFileSheet", RDO.ResultsetTypeConstants.rdOpenStatic);
			//dbtmp.OpenRecordset("select * from `Sheet1$`")

			//If rsData.Fields.Count <> 11 Then
			//    MsgBox "This is an invalid file"
			//Else
			while (!rsData.EOF) {
				MeasureName = Strings.Mid(rsData.rdoColumns["Measure"].Value, Strings.InStr(1, rsData.rdoColumns["Measure"].Value, "(") + 1, Strings.InStr(1, rsData.rdoColumns["Measure"].Value, ")") - Strings.InStr(1, rsData.rdoColumns["Measure"].Value, "(") - 1);
				modGlobal.gv_sql = "select jcahoid from tbl_setup_indicator where jccode = '" + MeasureName + "' AND JCAHOID IS NOT NULL";
				rs_JCAHOID = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (!rs_JCAHOID.EOF) {
					JCAHOID = rs_JCAHOID.rdoColumns["JCAHOID"].Value;
					rs_JCAHOID.Close();

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

					//UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					// these are hardcoded triggers
					if (string.IsNullOrEmpty(rsData.rdoColumns["CMCode"].Value) | Information.IsDBNull(rsData.rdoColumns["CMCode"].Value)) {
						switch (Strings.Trim(Strings.UCase(rsData.rdoColumns["RiskFactor"].Value))) {
							case "AGET1744":
								modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Patient Age Is' WHERE coefID in " + " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID + ")";

								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 17,1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 17,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;

								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 44, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 44,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);


								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 1, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 1,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 3, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 3,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;

								modGlobal.gv_cn.Execute(modGlobal.gv_sql);
								break;
							case "ADMSRC56":
								modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Contains' WHERE coefID  in " + " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID + ")";
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 5,1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 5,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 6, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 6,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);


								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 16, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 16,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);
								break;

							case "SEXR":
								modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Contains' WHERE coefID  in " + " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID + ")";
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 'F',1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 'F',1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 4, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 4,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;

								modGlobal.gv_cn.Execute(modGlobal.gv_sql);
								break;

							case "MAGE16L":
								modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Is Less Than' WHERE coefID   in " + " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID + ")";
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 17,1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 17,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 1, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 1,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 3, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 3,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);
								break;

							case "AGEINT":
								modGlobal.gv_sql = "UPDATE tbl_Setup_indicatorRiskAdjustmentCoefficients SET TriggerBy = 'Patient Age Is' WHERE coefID  in " + " (select coefID from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID + ")";

								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientTriggers (coefID, TriggerValue, tab) ";
								//                            gv_sql = gv_sql & " Values (" & li_CoefID & ", 'Integer',1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 'Integer',1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 3, 1)"
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 3,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);

								modGlobal.gv_sql = "INSERT INTO tbl_Setup_IndicatorRiskAdjustmentCoefficientFieldLinks (coefID, DDID, tab) ";
								modGlobal.gv_sql = modGlobal.gv_sql + " select coefID, 244,1 from tbl_Setup_IndicatorRiskAdjustmentCoefficients where factorid = '" + rsData.rdoColumns["RiskFactor"].Value + "' AND measureID = " + JCAHOID;
								//gv_sql = gv_sql & " Values (" & li_CoefID & ", 244, 1)"
								modGlobal.gv_cn.Execute(modGlobal.gv_sql);
								break;

							default:
								li_UnderscorePos = Strings.InStr(1, rsData.rdoColumns["RiskFactor"].Value, "_");
								//this is for the multiplers
								if (li_UnderscorePos > 0) {
									ls_LeftCoef = Strings.Mid(rsData.rdoColumns["RiskFactor"].Value, 1, li_UnderscorePos - 1);
									ls_RightCoef = Strings.Mid(rsData.rdoColumns["RiskFactor"].Value, li_UnderscorePos + 1, Strings.Len(rsData.rdoColumns["RiskFactor"].Value));

									modGlobal.gv_sql = "{ ? = call INSERTFactorLink(?,?,?) }";
									ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
									ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
									ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
									ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
									ps.rdoParameters[3].Direction = RDO.DirectionConstants.rdParamInput;
									ps.rdoParameters[1].Value = rsData.rdoColumns["RiskFactor"].Value;
									//li_CoefID
									ps.rdoParameters[2].Value = ls_LeftCoef;
									ps.rdoParameters[3].Value = ls_RightCoef;
									ps.Execute();
									ps.Close();

									//Else
									//MsgBox rsData!RiskFactor & " does not have a type and is not part of the hardcoded triggers.  Please fix before loading!", vbCritical, "There is a NEW trigger"
									//Exit Sub
								}
								break;

						}

					// these are NOT hardcoded triggers, use definitions in file
					} else {

						modGlobal.gv_sql = "{ ? = call INSERTTrigger(?,?,?) }";
						ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
						ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
						ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
						ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
						ps.rdoParameters[3].Direction = RDO.DirectionConstants.rdParamInput;
						ps.rdoParameters[1].Value = rsData.rdoColumns["RiskFactor"].Value;
						//li_CoefID
						ps.rdoParameters[2].Value = rsData.rdoColumns["CMCode"].Value;
						ps.rdoParameters[3].Value = rsData.rdoColumns["Type"].Value;
						ps.Execute();
						ps.Close();

					}
					//Else ' no matching coefficients
					//    rs_CoefID.Close

					//IGNORE JCAHO's stupidity of putting specs into a file for coefficients they don't even use
					//MsgBox rsData!RiskFactor & " does not exist in coefficient list for " & JCAHOID & " and " & quarter & ".  Please check that the risk coefficients were loaded before loading specs!", vbCritical, "There is a NEW spec"
					//Exit Sub
					//End If


				}
				rsData.MoveNext();
			}
			//End If

			rsData.Close();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			Interaction.MsgBox("Load completed successfully");

			return;
			ErrHandler:
			modGlobal.CheckForErrors();
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		public void mnuSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmSetupVersion.Show();
		}

		private void mnuSetupVersion_Click()
		{
		}

		public void mnuSoftwareVer_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmAbout.Show();
		}

		public void mnuStateSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmSetupStateVersion.Show();
		}

		public void mnuSubmitSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmSubmissionSetup.Show();
		}

		public void mnuTabFieldValidSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmTableSetup.Show();
		}

		public void InitializeTableDef()
		{
			object NextNewID = null;
			object COPTableName = null;
			object SQLFieldName = null;
			object SQLTableName = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object SQLTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SQLTableName = "tbl_setup_TableDef";
			//UPGRADE_WARNING: Couldn't resolve default property of object SQLFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SQLFieldName = "BaseTableID";

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "HOSPITAL DEMOGRAPHICS";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','DATA','Y','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "HOSPITAL STATISTICS";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','DATA','Y','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//SH - commented out physical name 11.23.04
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "PATIENT";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			// , PhysicalTableName)"
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','DATA','Y','Y')";
			// ,'PatientRecordMaster')"
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "ADMISSION SOURCE LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "DISCHARGE DISPOSITION LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "ASA SCORE LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "READMISSION REASON LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "ADMISSION REFERRAL SOURCE LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "ADMISSION LEGAL STATUS LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "ADMISSION PAYOR LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "ADMISSION TRANSFER REASON LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "PREVIOUS ADMISSION REFERRAL SOURCE LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);

			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPTableName = "PREVIOUS ADMISSION LEGAL STATUS LIST";
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NextNewID = modDBSetup.FindMaxRecID(ref SQLTableName, ref SQLFieldName);
			modGlobal.gv_sql = "INSERT into tbl_Setup_TableDef (BaseTableID, BaseTable, TableType, HASDynamicField, HasFixField)";
			//UPGRADE_WARNING: Couldn't resolve default property of object COPTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + COPTableName + "','LOOKUP','N','N')";
			modGlobal.gv_cn.Execute(modGlobal.gv_sql);



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
			object NextNewID = null;
			System.Data.DataSet  drs = null;
			System.Data.DataSet  ors = null;
			System.Data.DataSet  fixrs = null;

			//only add the dynamic fields,
			//meaning that only the fields that don't exist in FixField table


			modGlobal.gv_sql = "Select * from tbl_setup_OldFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID is not null ";
			ors = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

			while (!ors.EOF) {
				modGlobal.gv_sql = "Select * ";
				modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_FixFields ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where ";
				modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID = " + ors.rdoColumns["basetableid"].Value;
				modGlobal.gv_sql = modGlobal.gv_sql + " and FixFieldName = '" + ors.rdoColumns["FieldName"].Value + "'";

				fixrs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (fixrs.RowCount == 0) {
					//check to see if it doesn't already exist
					modGlobal.gv_sql = "Select * ";
					modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
					modGlobal.gv_sql = modGlobal.gv_sql + " where ";
					modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID = " + ors.rdoColumns["basetableid"].Value;
					modGlobal.gv_sql = modGlobal.gv_sql + " and OldFieldName = '" + ors.rdoColumns["FieldName"].Value + "'";

					drs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
					if (drs.RowCount == 0) {
						//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						NextNewID = modDBSetup.FindMaxRecID(ref "tbl_Setup_DataDef", ref "DDID");
						modGlobal.gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldName, FieldSize, FieldType, OldFieldName)";
						//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						modGlobal.gv_sql = modGlobal.gv_sql + " Select " + NextNewID + "," + ors.rdoColumns["basetableid"].Value + ", FieldName, FieldSize, FieldType, FieldName  ";
						modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_OldFields ";
						modGlobal.gv_sql = modGlobal.gv_sql + " where OldFieldID = " + ors.rdoColumns["OldFieldID"].Value;
						//g = InputBox("", "", gv_sql)
						modGlobal.gv_cn.Execute(modGlobal.gv_sql);
					}
				}
				ors.MoveNext();
			}

		}

		public void AddFixField(ref object TableID, ref object FixFieldName, ref object FieldType, ref object FieldSize)
		{
			object NextNewID = null;


			modGlobal.gv_sql = "Select * from tbl_setup_FixFields ";
			//UPGRADE_WARNING: Couldn't resolve default property of object TableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where BaseTableID = " + TableID;
			//UPGRADE_WARNING: Couldn't resolve default property of object FixFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and FixFieldName = '" + FixFieldName + "'";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NextNewID = modDBSetup.FindMaxRecID(ref "tbl_setup_FixFields", ref "FixFieldID");
				modGlobal.gv_sql = "Insert into tbl_setup_Fixfields (FixFieldID, BaseTableID, ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FixFieldName, FixFieldType, FixFieldSize) ";
				//UPGRADE_WARNING: Couldn't resolve default property of object TableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + TableID + ",";
				//UPGRADE_WARNING: Couldn't resolve default property of object FixFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " upper('" + FixFieldName + "'),";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + "'" + FieldType + "',";
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				if (FieldSize == "Null") {
					modGlobal.gv_sql = modGlobal.gv_sql + " Null)";
				} else {
					//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + FieldSize + ")";
				}
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
			}

		}

		public void SetupDayFields()
		{
			object FieldName = null;
			object OldFieldName = null;
			object FieldSize = null;
			object FieldType = null;
			object TID = null;

			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ";
			modGlobal.gv_sql = modGlobal.gv_sql + " BaseTable = 'PATIENT' ";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			//UPGRADE_WARNING: Couldn't resolve default property of object TID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TID = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
			//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FieldType = "Number";
			//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FieldSize = "Null";

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "CENT_MED";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "CENTRAL LINE DAYS (MEDICAL ICU)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "CENT_SURG";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "CENTRAL LINE DAYS (SURGICAL ICU)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "CENT_MEDSURG";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "CENTRAL LINE DAYS (MED/SURG ICU)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "CENT_CORON";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "CENTRAL LINE DAYS (CORONARY CARE)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "VENT_MED";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "VENTILATOR DAYS (MEDICAL ICU)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "VENT_SURG";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "VENTILATOR DAYS (SURGICAL ICU)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "VENT_MEDSURG";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "VENTILATOR DAYS (MED/SURG ICU)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "VENT_CORON";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "VENTILATOR DAYS (CORONARY CARE)";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			OldFieldName = "PRIM_BLOOD";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = "PRIMARY BLOOD INFECTION DAYS";
			AddDayField(ref TID, ref FieldName, ref NewFieldName, ref FieldSize, ref FieldType);


		}

		public void AddDayField(ref object TableID, ref object OldFieldName, ref object NewFieldName, ref object FieldSize, ref object FieldType)
		{
			object NextNewID = null;
			modGlobal.gv_sql = "Select * ";
			modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef ";
			modGlobal.gv_sql = modGlobal.gv_sql + " where ";
			//UPGRADE_WARNING: Couldn't resolve default property of object TableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID = " + TableID;
			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " and OldFieldName = '" + OldFieldName + "'";

			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
			if (modGlobal.gv_rs.RowCount == 0) {
				//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NextNewID = modDBSetup.FindMaxRecID(ref "tbl_Setup_DataDef", ref "DDID");
				modGlobal.gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldName, FieldSize, FieldType, OldFieldName)";
				//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object TableID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + TableID + ",'" + NewFieldName + "',";
				//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object FieldSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + FieldSize + ",'" + FieldType + "','" + OldFieldName + "')";
				//g = InputBox("", "", gv_sql)
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
			}


		}

		public string FindFieldCategory(ref object FixFieldName)
		{
			string functionReturnValue = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object FixFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			NewFieldName = FixFieldName;
			functionReturnValue = "Fix";
			switch (FixFieldName) {
				case "ADMISSION_DATE":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "ADMISSIONDATE";
					break;
				case "DISCHARGE_DATE":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "DISCHARGEDATE";
					break;
				case "BIRTH_DATE":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "BIRTHDATE";
					break;
				case "SEX":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SEX";
					break;
				case "ATTEND_PHYSICIAN_ID":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "ATTENDINGPHYSICIANNUMBER";
					break;
				case "DRG":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "DRG";
					break;
				case "ADMISSION_SOURCE":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "ADMISSIONSOURCE";
					break;
				case "DISCHARGE_DISPOSITION":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "DISCHARGEDISPOSITION";
					break;
				case "NEONATAL_BIRTH_WEIGHT":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "NEONATALBIRTHWEIGHT";
					break;
				case "PRINCIPAL_DIAGNOSIS":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "PRINCIPALDIAG";
					break;
				case "SEC_DIAGNOSIS_2":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG2";
					break;
				case "SEC_DIAGNOSIS_3":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG3";
					break;
				case "SEC_DIAGNOSIS_4":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG4";
					break;
				case "SEC_DIAGNOSIS_5":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG5";
					break;
				case "SEC_DIAGNOSIS_6":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG6";
					break;
				case "SEC_DIAGNOSIS_7":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG7";
					break;
				case "SEC_DIAGNOSIS_8":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG8";
					break;
				case "SEC_DIAGNOSIS_9":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "SECONDDIAG9";
					break;
				case "PERIOD_START_Date":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "PERIOD_START_Date";
					break;
				case "PERIOD_END_Date":
					//UPGRADE_WARNING: Couldn't resolve default property of object NewFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NewFieldName = "PERIOD_END_Date";
					break;
				default:
					functionReturnValue = "Dynamic";
					break;
			}
			return functionReturnValue;


		}

		public void UpdateIndicatorFieldList(ref object OldTableName)
		{
			object NextNewID = null;
			DAO.Database COPDB = null;
			//UPGRADE_WARNING: Arrays in structure coprs may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			DAO.Recordset coprs = null;
			DAO.Workspace wrkODBC = null;
			DAO.Database dbsNew = null;
			DAO.Property prpLoop = null;
			DAO.TableDef tbldef = null;


			//UPGRADE_WARNING: Couldn't resolve default property of object CurrentDB. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPDB = DAODBEngine_definst.OpenDatabase(modGlobal.CurrentDB);

			//
			//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "Select * from " + OldTableName;
			modGlobal.gv_sql = modGlobal.gv_sql + " where Hidden = null or hidden = ''";

			//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			coprs = COPDB.OpenRecordset("Select * from " + OldTableName);
			//
			//add the field names
			while (!coprs.EOF) {

				modGlobal.gv_sql = "Select * from tbl_setup_Indicator ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where ";
				modGlobal.gv_sql = modGlobal.gv_sql + " OldFieldName = '" + coprs.Fields["Indicator"].Value + "'";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.RowCount == 0) {

					//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NextNewID = modDBSetup.FindMaxRecID(ref "tbl_setup_Indicator", ref "IndicatorID");

					modGlobal.gv_sql = "Insert into tbl_setup_Indicator (IndicatorID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " Description, OldFieldName) ";
					//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",'" + coprs.Fields["Title"].Value + "',";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + coprs.Fields["Indicator"].Value + "')";

					//msg = InputBox("", "", gv_sql)
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}
				coprs.MoveNext();
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

		public void UpdateLookupFieldList(ref object OldTableName, ref object NewTableName)
		{
			object TID = null;
			object NextNewID = null;
			DAO.Database COPDB = null;
			//UPGRADE_WARNING: Arrays in structure coprs may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
			DAO.Recordset coprs = null;
			DAO.Workspace wrkODBC = null;
			DAO.Database dbsNew = null;
			DAO.Property prpLoop = null;
			DAO.TableDef tbldef = null;


			//UPGRADE_WARNING: Couldn't resolve default property of object CurrentDB. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			COPDB = DAODBEngine_definst.OpenDatabase(modGlobal.CurrentDB);

			//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			coprs = COPDB.OpenRecordset("Select * from " + OldTableName);
			//

			//if tablename doesn't exist in the list, add it
			modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
			//UPGRADE_WARNING: Couldn't resolve default property of object NewTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = modGlobal.gv_sql + " where upper(BaseTable) = upper('" + NewTableName + "')";
			modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);


			if (modGlobal.gv_rs.RowCount == 0) {
				//add the table name first
				//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				NextNewID = modDBSetup.FindMaxRecID(ref "tbl_setup_tabledef", ref "BaseTableID");
				modGlobal.gv_sql = "Insert into tbl_setup_tabledef(BaseTableID, BaseTable, TableType, OldTableName, HasFixField )";
				//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object NewTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + ",upper('" + NewTableName + "'),'LOOKUP',upper('" + OldTableName + "'),'Y')";
				modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				//get the id of the new table
				modGlobal.gv_sql = "Select * from tbl_setup_TableDef ";
				//UPGRADE_WARNING: Couldn't resolve default property of object NewTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				modGlobal.gv_sql = modGlobal.gv_sql + " where upper(BaseTable) = upper('" + NewTableName + "')";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				//UPGRADE_WARNING: Couldn't resolve default property of object TID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TID = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
			} else {
				//UPGRADE_WARNING: Couldn't resolve default property of object TID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				TID = modGlobal.gv_rs.rdoColumns["basetableid"].Value;
			}


			//UPGRADE_WARNING: Couldn't resolve default property of object OldTableName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			modGlobal.gv_sql = "Select * from " + OldTableName;
			modGlobal.gv_sql = modGlobal.gv_sql + " where Value is not null and Value <> ''";

			coprs = COPDB.OpenRecordset(modGlobal.gv_sql);
			//
			//add the field names
			while (!coprs.EOF) {


				modGlobal.gv_sql = "Select * from tbl_setup_MiscLookupList ";
				modGlobal.gv_sql = modGlobal.gv_sql + " where ";
				modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue = '" + modGlobal.ConvertApastroph(ref coprs.Fields["Value"]) + "'";
				modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
				if (modGlobal.gv_rs.RowCount == 0) {

					//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					NextNewID = modDBSetup.FindMaxRecID(ref "tbl_setup_MiscLookupList", ref "LookupID");

					modGlobal.gv_sql = "Insert into tbl_setup_MiscLookUpList(LookupID, ";
					modGlobal.gv_sql = modGlobal.gv_sql + " BaseTableID, ID, FieldValue) ";
					//UPGRADE_WARNING: Couldn't resolve default property of object TID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					//UPGRADE_WARNING: Couldn't resolve default property of object NextNewID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					modGlobal.gv_sql = modGlobal.gv_sql + " values (" + NextNewID + "," + TID + "," + coprs.Fields["Id"].Value + ",";
					modGlobal.gv_sql = modGlobal.gv_sql + " '" + modGlobal.ConvertApastroph(ref coprs.Fields["Value"]) + "')";

					//msg = InputBox("", "", gv_sql)
					modGlobal.gv_cn.Execute(modGlobal.gv_sql);
				}
				coprs.MoveNext();
			}

		}

		public void mnuTableValidationSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			My.MyProject.Forms.frmTableValidationSetup.Show();
		}

		public void mnuTiming_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			object frmVerifyTimingTest = null;
			//UPGRADE_WARNING: Couldn't resolve default property of object frmVerifyTimingTest.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			frmVerifyTimingTest.Show();
		}

		public void mnuUpdateExistingDB_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			//every setup record in all of the tables will be imported to a text file
			//first line of each table will be tablename in [], followed by the records in the table
			// in a comma delimited format
			//resp = MsgBox("Please make sure that a diskette is inserted before creating an update. Continue?", vbOKCancel, "Create an update for Access database.")
			//If resp = vbNo Then
			//    Exit Sub
			//End If
			My.MyProject.Forms.frmExportSetup.Show();
			return;

		}

		public string GetNewFieldName(ref object OldFieldName)
		{
			string functionReturnValue = null;

			//UPGRADE_WARNING: Couldn't resolve default property of object OldFieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			functionReturnValue = OldFieldName;

			switch (OldFieldName) {
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
			return functionReturnValue;

		}

		public void mnuUpdateSystemSetup_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			UpdateSetup.UpdateSystemSetup();
		}
	}
}
