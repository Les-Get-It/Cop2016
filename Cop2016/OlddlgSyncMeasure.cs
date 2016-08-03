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
	internal partial class OlddlgSyncMeasure : System.Windows.Forms.Form
	{

		private int il_MeasureID;
		private string is_CurrentDB;

		public void SetMeasureID(ref int MeasureID)
		{
			il_MeasureID = MeasureID;
		}

		private void CancelButton_Renamed_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			this.Close();
		}

		private void dlgSyncMeasure_Load(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (Strings.InStr(modGlobal.gv_cn.Connect, "COP2001Current") > 0) {
				OptCurrent.Enabled = false;
				is_CurrentDB = "COP2001Current";
			} else if (Strings.InStr(modGlobal.gv_cn.Connect, "COP2001Archive") > 0) {
				OptArchive.Enabled = false;
				is_CurrentDB = "COP2001Archive";
			} else {
				OptIHHA.Enabled = false;
				is_CurrentDB = "COP2001";
			}

		}

		private void OKButton_Click(System.Object eventSender, System.EventArgs eventArgs)
		{
			string temp_strDBName = null;
			string ls_DB = null;
			System.Data.SqlClient.SqlCommand  ps = null;

			 // ERROR: Not supported in C#: OnErrorStatement


			if (OptCurrent.Checked | OptArchive.Checked | OptIHHA.Checked) {
				if (Interaction.MsgBox("Are you sure you want to overwrite this measure flowchart in the chosen database?", MsgBoxStyle.YesNo, "This can not be undone") == MsgBoxResult.Yes) {

					if (OptCurrent.Checked) {
						ls_DB = "COP2001Current";
					} else if (OptArchive.Checked) {
						ls_DB = "COP2001Archive";
					} else {
						ls_DB = "COP2001";
					}

					//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

					modGlobal.gv_sql = "{ ? = call SyncMeasure(?,?,?) }";
					ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
					ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
					ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
					ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
					ps.rdoParameters[3].Direction = RDO.DirectionConstants.rdParamInput;

					ps.rdoParameters[1].Value = il_MeasureID;
					ps.rdoParameters[2].Value = ls_DB;
					ps.rdoParameters[3].Value = is_CurrentDB;

					ps.Execute();
					ps.Close();

					//            '1.  first delete all the old flowchart data
					//
					//            'measurecriteriasubmitsubs
					//            gv_sql = "DELETE FROM [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSubmitSubs] WHERE MeasureCriteriaSetSubmitSubsID in " & _
					//'                "(SELECT MeasureCriteriaSetSubmitSubsID FROM tbl_Setup_MeasureCriteriaSetSubmitSubs mcss, tbl_Setup_MeasureStepSubmitSubs mess, tbl_Setup_MeasureStep ms " & _
					//'                " WHERE mess.MeasureStepSubmitSubsID = mcss.MeasureStepSubmitSubsID and ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " & il_MeasureID & ")"
					//            gv_cn.Execute gv_sql
					//
					//            'measurecriteria
					//            gv_sql = "DELETE FROM [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteria] WHERE MeasureCriteriaSetID in " & _
					//'                "(SELECT MeasureCriteriaSetID FROM tbl_Setup_MeasureCriteriaSet mcss, tbl_Setup_MeasureStep mess " & _
					//'                " WHERE mess.MeasureStepID = mcss.MeasureStepID and mess.MeasureID = " & il_MeasureID & ")"
					//            gv_cn.Execute gv_sql
					//
					//            'measurecriteriasetsubmitsub
					//            gv_sql = "DELETE FROM [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] WHERE MeasureStepSubmitSubsID in " & _
					//'                "(SELECT MeasureStepSubmitSubsID FROM tbl_Setup_MeasureStepSubmitSubs mess, tbl_Setup_MeasureStep ms " & _
					//'                " WHERE ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " & il_MeasureID & ")"
					//            gv_cn.Execute gv_sql
					//
					//            'measurecriteriaset
					//            gv_sql = "DELETE FROM [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSet] WHERE MeasureStepID in " & _
					//'                "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep mess " & _
					//'                " WHERE mess.MeasureID = " & il_MeasureID & ")"
					//            gv_cn.Execute gv_sql
					//
					//            'measurestepsubmitsubs
					//            gv_sql = "DELETE FROM [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] WHERE MeasureStepID in " & _
					//'                "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep ms " & _
					//'                " WHERE ms.MeasureID = " & il_MeasureID & ")"
					//            gv_cn.Execute gv_sql
					//
					//            'measurestepgroup
					//            gv_sql = "DELETE FROM [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepGroup] WHERE MeasureStepID in " & _
					//'                "(SELECT MeasureStepID FROM tbl_Setup_MeasureStep ms " & _
					//'                " WHERE ms.MeasureID = " & il_MeasureID & ")"
					//            gv_cn.Execute gv_sql
					//
					//            'measurestep
					//            gv_sql = "DELETE FROM [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStep] WHERE MeasureID = " & il_MeasureID
					//            gv_cn.Execute gv_sql
					//
					//            ' 2. Then select from this database into the selected database - in the opposite order
					//
					//            'measurestep
					//            gv_sql = "SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStep] ON;INSERT INTO [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStep] ([MeasureStepID], [MeasureID], [MeasureStep], [Measure_CATID], [GoToStep]) "
					//            gv_sql = gv_sql & "SELECT [MeasureStepID], [MeasureID], [MeasureStep], [Measure_CATID], [GoToStep] FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStep] WHERE MeasureID = " & il_MeasureID
					//            gv_sql = gv_sql & ";SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStep] OFF;"
					//            gv_cn.Execute gv_sql
					//
					//            'measurestepgroup
					//            gv_sql = "SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepGroup] ON;INSERT INTO [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepGroup] " & _
					//'                "([MeasureStepGroupID], [MeasureStepID], [MeasureCriteriaSetID], [MeasureStepGroup], [JoinOperator])" & _
					//'                " SELECT [MeasureStepGroupID], [MeasureStepID], [MeasureCriteriaSetID], [MeasureStepGroup], [JoinOperator] FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStepGroup] " & _
					//'                " WHERE MeasureStepID in (SELECT MeasureStepID FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStep] ms " & _
					//'                " WHERE ms.MeasureID = " & il_MeasureID & ");SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepGroup] OFF;"
					//            gv_cn.Execute gv_sql
					//
					//            'measurestepsubmitsubs
					//            gv_sql = "SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] ON;INSERT INTO [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] " & _
					//'                "([MeasureStepSubmitSubsID], [MeasureStepID]) SELECT [MeasureStepSubmitSubsID], [MeasureStepID] FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] WHERE MeasureStepID in " & _
					//'                "(SELECT MeasureStepID FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStep] ms " & _
					//'                " WHERE ms.MeasureID = " & il_MeasureID & ");SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] OFF;"
					//            gv_cn.Execute gv_sql
					//
					//            'measurecriteriaset
					//            gv_sql = "SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSet] ON;INSERT INTO [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSet] " & _
					//'                " ([MeasureCriteriaSetID], [MeasureCriteriaSet], [MeasureStepID], [JoinOperator]) " & _
					//'                " SELECT [MeasureCriteriaSetID], [MeasureCriteriaSet], [MeasureStepID], [JoinOperator] FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureCriteriaSet] WHERE MeasureStepID in " & _
					//'                "(SELECT MeasureStepID FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStep] " & _
					//'                " WHERE MeasureID = " & il_MeasureID & ");SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSet] OFF;"
					//            gv_cn.Execute gv_sql
					//
					//            'measurecriteriasetsubmitsubtup_MeasureStepSubmitSubs] ON;INSERT INTO  [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSub] " & _
					//'                " SELECT [MeasureCriteriaSetSubmitSubsID], [MeasureCriter
					//            gv_sql = "SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] ON;" & _
					//'                " INSERT INTO [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] " & _
					//'                " ([MeasureCriteriaSetSubmitSubsID], [MeasureCriteriaSet], [MeasureStepSubmitSubsID], [JoinOperator], [ExportSetID]) " & _
					//'                " SELECT [MeasureCriteriaSetSubmitSubsID], [MeasureCriteriaSet], [MeasureStepSubmitSubsID], [JoinOperator], [ExportSetID] FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] " & _
					//'                " WHERE MeasureStepSubmitSubsID in " & _
					//'                "(SELECT MeasureStepSubmitSubsID FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] mess, [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStep] ms " & _
					//'                " WHERE ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " & il_MeasureID & ");SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] OFF;"
					//            gv_cn.Execute gv_sql
					//
					//            'measurecriteria
					//            gv_sql = "SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteria] ON;INSERT INTO [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteria] " & _
					//'                " ([MeasureCriteriaID], [MeasureCriteriaSetID], [CriteriaTitle], [DDID1], [DDID2], [ValueOperator], [FieldValue], [DestDDID], [LookupID], [FieldOperator], [DateUnit], [JoinOperator], [LookupTableID], [State], [RecordStatus], [MeasureFieldGroupLogicID]) " & _
					//'                " SELECT [MeasureCriteriaID], [MeasureCriteriaSetID], [CriteriaTitle], [DDID1], [DDID2], [ValueOperator], [FieldValue], [DestDDID], [LookupID], [FieldOperator], [DateUnit], [JoinOperator], [LookupTableID], [State], [RecordStatus], [MeasureFieldGroupLogicID] " & _
					//'                " FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureCriteria]  WHERE MeasureCriteriaID in " & _
					//'                " (SELECT MeasureCriteriaID FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureCriteriaSet] mcss, [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStep] mess " & _
					//'                " WHERE mess.MeasureStepID = mcss.MeasureStepID and mess.MeasureID = " & il_MeasureID & ")" & _
					//'                " ;SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteria] OFF;"
					//            gv_cn.Execute gv_sql
					//            'Debug.Print gv_sql
					//
					//
					//            'measurecriteriasubmitsubs
					//            gv_sql = "SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSubmitSubs] ON;INSERT INTO [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSubmitSubs] " & _
					//'                " ([MeasureCriteriaSubmitSubsID], [MeasureCriteriaSetSubmitSubsID], [CriteriaTitle], [DDID1], [DDID2], [ValueOperator], [FieldValue], [DestDDID], [LookupID], [FieldOperator], [DateUnit], [JoinOperator], [LookupTableID], [State], [RecordStatus], [ExportSetID], [ExportCriteriaID]) " & _
					//'                " SELECT [MeasureCriteriaSubmitSubsID], [MeasureCriteriaSetSubmitSubsID], [CriteriaTitle], [DDID1], [DDID2], [ValueOperator], [FieldValue], [DestDDID], [LookupID], [FieldOperator], [DateUnit], [JoinOperator], [LookupTableID], [State], [RecordStatus], [ExportSetID], [ExportCriteriaID] " & _
					//'                " FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureCriteriaSubmitSubs] WHERE MeasureCriteriaSetSubmitSubsID in " & _
					//'                "(SELECT MeasureCriteriaSetSubmitSubsID FROM [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureCriteriaSetSubmitSubs] mcss, [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStepSubmitSubs] mess, [" & is_CurrentDB & "].[dbo].[tbl_Setup_MeasureStep] ms " & _
					//'                " WHERE mess.MeasureStepSubmitSubsID = mcss.MeasureStepSubmitSubsID and ms.MeasureStepID = mess.MeasureStepID AND ms.MeasureID = " & il_MeasureID & ");SET IDENTITY_INSERT [" & ls_DB & "].[dbo].[tbl_Setup_MeasureCriteriaSubmitSubs] OFF;"
					//            gv_cn.Execute gv_sql
					//            'Debug.Print gv_sql
					//
					Interaction.MsgBox("Successfully synchronized", MsgBoxStyle.Information, "Success!");
				}
			} else {
				Interaction.MsgBox("Please select the database to copy this measure information to", MsgBoxStyle.Critical, "Database Not Chosen");
			}
			//UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

			this.Close();
			return;
			ErrHandler:

			modGlobal.CheckForErrors();
		}
	}
}
