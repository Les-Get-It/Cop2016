using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgSyncMeasure : Telerik.WinControls.UI.RadForm
    {
        private int il_MeasureID;
        private string is_CurrentDB;


        public dlgSyncMeasure()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        public void SetMeasureID( int MeasureID)
        {
            il_MeasureID = MeasureID;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Close
            this.Close();
        }

        private void dlgSyncMeasure_Load(object sender, EventArgs e)
        {
            try
            {
                //LDW if (Strings.InStr(modGlobal.gv_cn.Connect, "COP2001Current") > 0)
                if (Strings.InStr(modGlobal.gv_cn.ConnectionString, "COP2001Current") > 0)
                {
                    OptCurrent.Enabled = false;
                    is_CurrentDB = "COP2001Current";
                }
                //LDW else if (Strings.InStr(modGlobal.gv_cn.Connect, "COP2001Archive") > 0)
                else if (Strings.InStr(modGlobal.gv_cn.ConnectionString, "COP2001Archive") > 0)
                {
                    OptArchive.Enabled = false;
                    is_CurrentDB = "COP2001Archive";
                }
                else
                {
                    OptIHHA.Enabled = false;
                    is_CurrentDB = "COP2001";
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

        private void OKButton_Click(object sender, EventArgs e)
        {
            string temp_strDBName = null;
            string ls_DB = null;
            SqlCommand ps = new SqlCommand();


            try
            {
                // ERROR: Not supported in C#: OnErrorStatement
                DialogResult resp = RadMessageBox.Show(this, "Are you sure you want to overwrite this measure flowchart in the chosen database?", "This can not be undone",
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);

                if (OptCurrent.IsChecked | OptArchive.IsChecked | OptIHHA.IsChecked)
                {
                    //LDW if (RadMessageBox.Show("Are you sure you want to overwrite this measure flowchart in the chosen database?", MsgBoxStyle.YesNo, "This can not be undone") == DialogResult.Yes)
                    if (resp == DialogResult.Yes)
                    {
                        if (OptCurrent.IsChecked)
                        {
                            ls_DB = "COP2001Current";
                        }
                        else if (OptArchive.IsChecked)
                        {
                            ls_DB = "COP2001Archive";
                        }
                        else
                        {
                            ls_DB = "COP2001";
                        }

                        Cursor.Current = Cursors.WaitCursor;

                        modGlobal.gv_sql = "{ ? = call SyncMeasure(?,?,?) }";
                        /*LDW ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                        ps.rdoParameters[0].Direction = RDO.DirectionConstants.rdParamReturnValue;
                        ps.rdoParameters[1].Direction = RDO.DirectionConstants.rdParamInput;
                        ps.rdoParameters[2].Direction = RDO.DirectionConstants.rdParamInput;
                        ps.rdoParameters[3].Direction = RDO.DirectionConstants.rdParamInput;

                        ps.rdoParameters[1].Value = il_MeasureID;
                        ps.rdoParameters[2].Value = ls_DB;
                        ps.rdoParameters[3].Value = is_CurrentDB;

                        ps.Execute();
                        ps.Close();*/

                        ps.Connection = modGlobal.gv_cn;
                        ps.CommandType = CommandType.StoredProcedure;
                        ps.CommandText = "SyncMeasure";
                        var inParam1 = new SqlParameter("@MeasureID", il_MeasureID);
                        inParam1.Direction = ParameterDirection.Input;
                        inParam1.DbType = DbType.String;
                        ps.Parameters.Add(inParam1);
                        var inParam2 = new SqlParameter("@DBName", ls_DB);
                        inParam2.Direction = ParameterDirection.Input;
                        inParam2.DbType = DbType.String;
                        ps.Parameters.Add(inParam2);
                        var inParam3 = new SqlParameter("@CurrentDB", is_CurrentDB);
                        inParam3.Direction = ParameterDirection.Input;
                        inParam3.DbType = DbType.String;
                        ps.Parameters.Add(inParam3);
                        SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                        retParam1.Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            ps.Connection.Open();
                            ps.ExecuteNonQuery();
                        }
                        catch (Exception exx)
                        {

                            DialogResult dse = RadMessageBox.Show(this, "Error while opening connection: " + exx.Message, "Database Connection Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                            this.Text = dse.ToString();
                        }
                        finally
                        {
                            ps.Dispose();
                        }


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
                        //LDW RadMessageBox.Show("Successfully synchronized", MsgBoxStyle.Information, "Success!");

                        DialogResult ds1 = RadMessageBox.Show(this, "Successfully synchronized.", "Success", MessageBoxButtons.OK, RadMessageIcon.Info);
                        this.Text = ds1.ToString();
                    }
                }
                else
                {
                    //LDW RadMessageBox.Show("Please select the database to copy this measure information to", MsgBoxStyle.Critical, "Database Not Chosen");

                    DialogResult ds2 = RadMessageBox.Show(this, "Please select the database to copy this measure information to.", "Database Not Chosen", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                }
                Cursor.Current = Cursors.Default;

                this.Close();
                return;
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
            //LDW ErrHandler:

            //LDW modGlobal.CheckForErrors();
        }
    }
}
