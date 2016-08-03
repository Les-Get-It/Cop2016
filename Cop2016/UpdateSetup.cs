using COP2001;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace COP2001
{
	static class UpdateSetup
	{
        public static void UpdateSystemSetup()
        {
            object state = null;
            string NewStateVer = null;
            object CurrentStateVer = null;
            var i = 0;
            var StartPos = 0;
            string NewVer = null;
            object CurrentVer = null;
            string TableName = null;
            string textline = null;
            int FileNum = FileSystem.FreeFile();
            string COPUpdatFile = modGlobal.gv_SelectedFileWithPath;
            string VersionStartDate = "";

            /*LDW frmFindAFile.Text = "Specify the source directory for COPUpdat.txt";
            frmFindAFile.ShowDialog();*/
            var dialog1 = new OpenFileDialog();
            dialog1.Title = "Specify the source directory for COPUpdat.txt";
            dialog1.RestoreDirectory = true;
            dialog1.DefaultExt = "txt";
            dialog1.CheckFileExists = true;
            dialog1.CheckPathExists = true;
            dialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog1.FilterIndex = 2;
            dialog1.ShowReadOnly = true;
            dialog1.ShowDialog();



            //OLD WHO KNOWS WHAT THEY WERE THINKING CODE - 10.1.2012
            //    If UCase(gv_SelectedFileName) <> "COPUPDAT.TXT" Then
            //        strError = "Sorry, you must locate COPUpdat.txt to update the system."
            //       MsgBox "Update Process Will Not Continue, Because the COPUpdat.txt Was Not Located Correctly."
            //       Screen.MousePointer = 0
            //       Exit Sub
            //    End If
            Cursor.Current = Cursors.WaitCursor;

            //first compare the update version with  the current version
            //LDW FileNum = FreeFile();
            FileSystem.FileOpen(FileNum, COPUpdatFile, OpenMode.Input);
            while (!FileSystem.EOF(FileNum))
            {
                textline = FileSystem.LineInput(FileNum);
                if (Strings.Mid(textline, 1, 1) == "[")
                {
                    TableName = Strings.Mid(textline, 2, Strings.Len(textline) - 2);
                }
                else
                {
                    switch (TableName)
                    {
                        case "VERSION":
                            modGlobal.gv_sql = "select * from tbl_Setup_Version ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " Order by VersionNumber desc ";
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName1 = "tbl_Setup_Version";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                            //LDW if (modGlobal.gv_rs.RowCount == 0)
                            if (modGlobal.gv_rs.Tables[sqlTableName1].Rows.Count == 0)
                            {
                                CurrentVer = 0;
                            }
                            else
                            {
                                //LDW CurrentVer = modGlobal.gv_rs.rdoColumns["VersionNumber"].Value;
                                CurrentVer = modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["VersionNumber"].ToString();
                            }
                            //LDW modGlobal.gv_rs.Close();
                            modGlobal.gv_rs.Dispose();

                            NewVer = "";
                            StartPos = 2;
                            for (i = StartPos; i <= Strings.Len(textline); i++)
                            {
                                if (Strings.Mid(textline, i, 1) != "\"")
                                {
                                    NewVer = NewVer + Strings.Mid(textline, i, 1);
                                }
                                else
                                {
                                    StartPos = i + 3;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                            break;

                        // commented out 12.14.2005
                        //                    If NewVer <> "" Then
                        //                        If CInt(NewVer) < CInt(CurrentVer) Then
                        //                            MsgBox "System update cannot get completed, because the update is older than the current system."
                        //                            Screen.MousePointer = vbDefault
                        //
                        //                            Exit Sub
                        //                        End If
                        //                    End If

                        case "VERSIONSTARTDATE":
                            StartPos = 2;
                            for (i = StartPos; i <= Strings.Len(textline); i++)
                            {
                                if (Strings.Mid(textline, i, 1) != "\"")
                                {
                                    VersionStartDate = VersionStartDate + Strings.Mid(textline, i, 1);
                                }
                                else
                                {
                                    StartPos = i + 3;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                            break;

                        case "STATEVERSION":
                            modGlobal.gv_sql = "select * from tbl_Setup_StateVersion ";
                            modGlobal.gv_sql = modGlobal.gv_sql + " Order by StateVersion desc ";
                            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                            const string sqlTableName2 = "tbl_Setup_StateVersion";
                            modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);
                            if (modGlobal.gv_rs.Tables[sqlTableName2].Rows.Count == 0)
                            {
                                CurrentStateVer = 0;
                            }
                            else
                            {
                                //LDW CurrentStateVer = modGlobal.gv_rs.rdoColumns["StateVersion"].Value;
                                CurrentStateVer = modGlobal.gv_rs.Tables[sqlTableName2].Rows[0]["StateVersion"].ToString();
                            }
                            //LDW modGlobal.gv_rs.Close();
                            modGlobal.gv_rs.Dispose();

                            NewStateVer = "";
                            state = "";
                            StartPos = 2;
                            for (i = StartPos; i <= Strings.Len(textline); i++)
                            {
                                if (Strings.Mid(textline, i, 1) != "\"")
                                {
                                    state = state + Strings.Mid(textline, i, 1);
                                }
                                else
                                {
                                    StartPos = i + 3;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }

                            for (i = StartPos; i <= Strings.Len(textline); i++)
                            {
                                if (Strings.Mid(textline, i, 1) != "\"")
                                {
                                    NewStateVer = NewStateVer + Strings.Mid(textline, i, 1);
                                }
                                else
                                {
                                    StartPos = i + 3;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }

                            if (!string.IsNullOrEmpty(NewStateVer))
                            {
                                if (Convert.ToInt16(NewStateVer) < Convert.ToInt16(CurrentStateVer))
                                {
                                    RadMessageBox.Show("System update cannot get completed, because the State update is older than the current system.");
                                    Cursor.Current = Cursors.Default;
                                    return;
                                }
                            }
                            break;
                    }
                }
            }
            FileSystem.FileClose(FileNum);

            //txtFileName = "F:\Dev\IHA\Hosp\Hosp00\COPUpdate.txt"
            //txtFileName = "A:\COPUpdate.txt"

            //LDW FileNum = FreeFile();
            FileNum = FileSystem.FreeFile();

            //On Error GoTo UpdateSysErr

            /*LDW modGlobal.gv_cn.Execute("EXEC BackupCMSFieldCodeFROMDataDef");
			modGlobal.gv_cn.Execute("EXEC DeleteSetupTables");
			modGlobal.gv_cn.Execute("EXEC AutoConstraints 0");  */
            var command1 = new SqlCommand("EXEC BackupCMSFieldCodeFROMDataDef", modGlobal.gv_cn);
            try
            {
                command1.Connection.Open();
                command1.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command1.Dispose();
                modGlobal.gv_cn.Close();
            }

            var command2 = new SqlCommand("EXEC DeleteSetupTables", modGlobal.gv_cn);
            try
            {
                command2.Connection.Open();
                command2.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command2.Dispose();
                modGlobal.gv_cn.Close();
            }

            var command3 = new SqlCommand("EXEC AutoConstraints 0", modGlobal.gv_cn);
            try
            {
                command3.Connection.Open();
                command3.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command3.Dispose();
                modGlobal.gv_cn.Close();
            }

            FileSystem.FileOpen(FileNum, COPUpdatFile, OpenMode.Input);

            //first loop through and delete all the data..
            while (!FileSystem.EOF(FileNum))
            {
                textline = FileSystem.LineInput(FileNum);
                if (Strings.Mid(textline, 1, 1) == "[")
                {
                    TableName = Strings.Mid(textline, 2, Strings.Len(textline) - 2);
                    modGlobal.gv_sql = "";
                    //            'delete exising setup for Disk Submission process
                    //            Select Case TableName
                    //                Case "DATADEF":
                    //                    gv_sql = "DELETE FROM tbl_Setup_DataDef  "
                    //                Case "DATADEFACTIONS":
                    //                    gv_sql = "DELETE FROM tbl_Setup_DataDefActions  "
                    //                Case "DATAENTRYACTIONS":
                    //                    gv_sql = "Delete FROM tbl_Setup_DataEntryActions  "
                    //                Case "DATAREQ":
                    //                    gv_sql = "Delete FROM tbl_Setup_DataReq  "
                    //                Case "HOSPSTATGROUP":
                    //                    gv_sql = "Delete FROM tbl_Setup_HospStatGroup  "
                    //                Case "HOSPSTATGROUPINDICATOR":
                    //                    gv_sql = "Delete FROM tbl_Setup_HospStatGroupIndicator  "
                    //                Case "HOSPSTATGROUPFIELDS":
                    //                    gv_sql = "Delete FROM tbl_Setup_HospStatGroupFields  "
                    //                Case "HOSPSTATVAL":
                    //                    gv_sql = "Delete FROM tbl_Setup_HospStatVal  "
                    //                Case "IMPORTALLSETUP":
                    //                    gv_sql = "Delete FROM tbl_Setup_ImportSetup "
                    //                Case "IMPORTALLFIELDS":
                    //                    gv_sql = "Delete FROM tbl_Setup_ImportFields "
                    //                Case "IMPORTALLVALIDATIONMESSAGE":
                    //                    gv_sql = "Delete FROM tbl_Setup_ImportValidationMessage "
                    //                Case "IMPORTALLVALIDATION":
                    //                    gv_sql = "Delete FROM tbl_Setup_ImportValidation "
                    //                Case "INDICATORGROUP":
                    //                    gv_sql = "Delete FROM tbl_Setup_IndicatorGroup  "
                    //                Case "INDICATOR":
                    //                    gv_sql = "Delete FROM tbl_Setup_Indicator  "
                    //                Case "INDICATORDEP":
                    //                    gv_sql = "Delete FROM tbl_Setup_IndicatorDep  "
                    //                Case "INDICATORGROUPSET":
                    //                    gv_sql = "Delete FROM tbl_Setup_IndicatorGroupSet  "
                    //                Case "INDICATORSET":
                    //                    gv_sql = "Delete FROM tbl_Setup_IndicatorSet  "
                    //                Case "INDICATORSETFIELD":
                    //                    gv_sql = "Delete FROM tbl_Setup_IndicatorSetField  "
                    //                Case "TABLEDEF":
                    //                    gv_sql = "Delete FROM tbl_setup_TableDef "
                    //                Case "TABLEVALIDATIONMESSAGE":
                    //                    gv_sql = "Delete FROM tbl_Setup_TABLEVALIDATIONMESSAGE  "
                    //                Case "TABLEVALIDATION":
                    //                    gv_sql = "Delete FROM tbl_Setup_TABLEVALIDATION  "
                    //                Case "TABLEVALIDATIONACTION":
                    //                    gv_sql = "Delete FROM tbl_Setup_TABLEVALIDATIONACTION  "
                    //                Case "TABLEVALIDATIONAFTERFIELDUPDATE":
                    //                    gv_sql = "Delete FROM tbl_setup_TableValidationAfterFieldUpdate "
                    //                Case "MISCLOOKUPLIST":
                    //                    gv_sql = "Delete FROM tbl_Setup_MiscLookupList  "
                    //                Case "SAVEDADHOCREPORTS":
                    //                    gv_sql = "Delete FROM tbl_Setup_SavedAdhocReports "
                    //                Case "SAVEDADHOCREPORTFIELDS":
                    //                    gv_sql = "Delete FROM tbl_Setup_SavedAdhocReportFields "
                    //                Case "SAVEDADHOCREPORTCRITERIA":
                    //                    gv_sql = "Delete FROM tbl_Setup_SavedAdhocReportCriteria "
                    //                Case "SUBMITGROUP":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitGroup "
                    //                Case "SUBMITGROUPROW":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitGroupRow "
                    //                Case "SUBMITSUBGROUP":
                    //                    gv_sql = "Delete tbl_Setup_SubmitSubGroup "
                    //                Case "SUBMITSUBGROUPFIELDS":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitSubGroupFields "
                    //                Case "SUBMITCRITERIA":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitCriteria "
                    //                Case "SUBMITVALIDATION":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitValidation "
                    //                Case "SUBMITVALSET":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitValSet "
                    //                Case "SUBMITVALSETGROUP1":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitValSetGroup1 "
                    //                Case "SUBMITVALSETGROUP2":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitValSetGroup2 "
                    //                Case "SUBMITCLEANUPITEMS":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitCleanupItems "
                    //                Case "SUBMITCLEANUPCRIT":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitCleanupCrit "
                    //                Case "SUBMITCLEANUPRECORD":
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitCleanupRecord "
                    //                 'uncommented out and added
                    //                'SH - 11.23.04
                    //                Case "INDICATORREPORTDENOMINATORS":
                    //                    gv_sql = "Delete FROM tbl_Setup_IndicatorReportDenominators  "
                    //                Case "INDICATORREPORTINCLUDES":
                    //                    gv_sql = "Delete FROM tbl_Setup_IndicatorReportIncludes  "
                    //                Case "SAVEDADHOCREPORTSUMCRITERIA"
                    //                    gv_sql = "Delete FROM tbl_Setup_SavedAdHocReportSumCriteria"
                    //                Case "SUBMITSUBGROUPCATEGORY"
                    //                    gv_sql = "Delete FROM tbl_Setup_SubmitSubGroupCategory"
                    //                Case "MEASURECAT"
                    //                    gv_sql = "Delete FROM tbl_Measure_Cat"
                    //                Case "MEASURESTEP"
                    //                    gv_sql = "Delete FROM tbl_Setup_MeasureStep"
                    //                Case "MEASURECRITERIASET"
                    //                    gv_sql = "Delete FROM tbl_Setup_MeasureCriteriaSet"
                    //                Case "MEASURECRITERIA"
                    //                    gv_sql = "Delete FROM tbl_Setup_MeasureCriteria"
                    //                Case "MEASURESTEPGROUP"
                    //                    gv_sql = "Delete FROM tbl_Setup_MeasureStepGroup"
                    //
                    //                Case "FIELDGROUP"
                    //                    gv_sql = "DELETE FROM tbl_Setup_FieldGroup"
                    //                Case "DDIDFIELDGROUP"
                    //                    gv_sql = "DELETE FROM tbl_Setup_DDIDFieldGroup"
                    //                Case "RELATEDFIELDGROUP"
                    //                    gv_sql = "DELETE FROM tbl_Setup_RelatedFieldGroup"
                    //                Case "DDIDRELATEDFIELDGROUP"
                    //                    gv_sql = "DELETE FROM tbl_Setup_DDIDRelatedFieldGroup"
                    //                Case "MEASUREFIELDGROUPLOGIC"
                    //                    gv_sql = "DELETE FROM tbl_Setup_MeasureFieldGroupLogic"
                    //                'SH end
                    //                Case "MEASUREFLOWCHARTLOGIC"
                    //                    gv_sql = "DELETE FROM tbl_Setup_MeasureFlowchartLogic"
                    //                Case "MEASUREFLOWCHARTACTION"
                    //                    gv_sql = "DELETE FROM tbl_Setup_MeasureFlowchartAction"
                    //                Case "INDICATORNUMBEROFCASES"
                    //                    gv_sql = "DELETE FROM tbl_Setup_IndicatorNumberofCases"
                    //                Case "INDICATORICDPOP"
                    //                    'ImportIndicatorICDPop textline
                    //                    gv_sql = "DELETE FROM tbl_Setup_IndicatorICDPop"
                    //                Case "MEASURESET"
                    //                    'ImportIndicatorICDPop textline
                    //                    gv_sql = "DELETE FROM tbl_Setup_MeasureSet"
                    //                Case "MEASURESETMAPMEAS"
                    //                    'ImportIndicatorICDPop textline
                    //                    gv_sql = "DELETE FROM tbl_Setup_MeasureSetMapMeas"
                    //            End Select
                    //
                    //            If gv_sql <> "" Then
                    //                gv_cn.Execute gv_sql
                    //                gv_sql = ""
                    //            End If
                    //          End If
                    //
                    //        DoEvents
                    //    Wend
                    //
                    //    'now loop through and insert
                    //    While Not EOF(FileNum)
                    //        Line Input #FileNum, textline
                    //        If mid(textline, 1, 1) = "[" Then
                    //            TableName = mid(textline, 2, Len(textline) - 2)
                    //            gv_sql = ""
                }
                else
                {
                    switch (TableName)
                    {

                        case "DATADEF":
                            UpdateDataDef(textline);
                            break;
                        case "DATADEFACTIONS":
                            UpdateDataDefActions(textline);
                            break;
                        case "DATAENTRYACTIONS":
                            UpdateDataEntryActions(textline);
                            break;
                        case "DATAREQ":
                            UpdateDataReq(textline);
                            break;
                        case "HOSPSTATGROUP":
                            UpdateHospStatGroup(textline);
                            break;
                        case "HOSPSTATGROUPINDICATOR":
                            UpdateHospStatGroupIndicator(textline);
                            break;
                        case "HOSPSTATGROUPFIELDS":
                            UpdateHospStatGroupFields(textline);
                            break;
                        case "HOSPSTATVAL":
                            UpdateHospStatVal(textline);
                            break;
                        case "IMPORTALLSETUP":
                            UpdateImportSetup(textline);
                            break;
                        case "IMPORTALLFIELDS":
                            UpdateImportFields(textline);
                            break;
                        case "IMPORTALLVALIDATIONMESSAGE":
                            UpdateImportValidationMessage(textline);
                            break;
                        case "IMPORTALLVALIDATION":
                            UpdateImportValidation(textline);
                            break;
                        case "INDICATOR":
                            UpdateIndicator(textline);
                            break;
                        case "INDICATORDEP":
                            UpdateIndicatorDep(textline);
                            break;
                        case "INDICATORSET":
                            UpdateIndicatorSet(textline);
                            break;
                        case "INDICATORSETFIELD":
                            UpdateIndicatorSetField(textline);
                            break;
                        case "INDICATORGROUP":
                            UpdateIndicatorGroup(textline);
                            break;
                        case "INDICATORGROUPSET":
                            UpdateIndicatorGroupSet(textline);
                            break;
                        //Case "INDICATORREPORTDENOMINATORS":
                        //UpdateIndicatorReportDenominators TextLine
                        //Case "INDICATORREPORTNUMERATORS":
                        //UpdateIndicatorReportNumerators TextLine
                        case "MISCLOOKUPLIST":
                            UpdateMiscLookupList(textline);
                            break;
                        case "TABLEDEF":
                            UpdateTableDef(textline);
                            break;
                        case "TABLEVALIDATIONMESSAGE":
                            UpdateTableValidationMessage(textline);
                            break;
                        case "TABLEVALIDATION":
                            UpdateTableValidation(textline);
                            break;
                        case "TABLEVALIDATIONACTION":
                            UpdateTableValidationAction(textline);
                            break;
                        case "TABLEVALIDATIONAFTERFIELDUPDATE":
                            UpdateTableValidationAfterFieldUpdate(textline);
                            break;
                        case "SAVEDADHOCREPORTS":
                            UpdateSavedAdhocReports(textline);
                            break;
                        case "SAVEDADHOCREPORTFIELDS":
                            UpdateSavedAdhocReportFields(textline);
                            break;
                        case "SAVEDADHOCREPORTCRITERIA":
                            UpdateSavedAdhocReportCriteria(textline);
                            break;
                        case "SUBMITGROUP":
                            UpdateSubmitGroup(textline);
                            break;
                        case "SUBMITGROUPROW":
                            UpdateSubmitGroupRow(textline);
                            break;
                        case "SUBMITSUBGROUP":
                            UpdateSubmitSubGroup(textline);
                            break;
                        case "SUBMITSUBGROUPFIELDS":
                            UpdateSubmitSubGroupFields(textline);
                            break;
                        case "SUBMITCRITERIA":
                            UpdateSubmitCriteria(textline);
                            break;
                        case "SUBMITVALIDATION":
                            UpdateSubmitValidation(textline);
                            break;
                        case "SUBMITVALSET":
                            UpdateSubmitValSet(textline);
                            break;
                        case "SUBMITVALSETGROUP1":
                            UpdateSubmitValSetGroup1(textline);
                            break;
                        case "SUBMITVALSETGROUP2":
                            UpdateSubmitValSetGroup2(textline);
                            break;
                        case "SUBMITCLEANUPITEMS":
                            UpdateSubmitCleanupItems(textline);
                            break;
                        case "SUBMITCLEANUPCRIT":
                            UpdateSubmitCleanupCrit(textline);
                            break;
                        case "SUBMITCLEANUPRECORD":
                            UpdateSubmitCleanupRecord(textline);
                            break;
                        //SH - added 11.23.2004
                        case "INDICATORREPORTINCLUDES":
                            ImportIndicatorReportIncludes(textline);
                            break;
                        case "INDICATORREPORTDENOMINATORS":
                            ImportIndicatorReportDenominators(textline);
                            break;
                        case "SAVEDADHOCREPORTSUMCRITERIA":
                            UpdateSavedAdHocReportSumCriteria(textline);
                            break;
                        case "SUBMITSUBGROUPCATEGORY":
                            UpdateSubmitSubGroupCategory(textline);
                            break;
                        case "MEASURECAT":
                            UpdateMeasureCat(textline);
                            break;
                        case "MEASURESTEP":
                            UpdateMeasureStep(textline);
                            break;
                        case "MEASURECRITERIASET":
                            UpdateMeasureCriteriaSet(textline);
                            break;
                        case "MEASURECRITERIA":
                            UpdateMeasureCriteria(textline);
                            break;
                        case "MEASURESTEPGROUP":
                            UpdateMeasureStepGroup(textline);
                            break;
                        case "FIELDGROUP":
                            UpdateFieldGroup(textline);
                            break;
                        case "DDIDFIELDGROUP":
                            UpdateDDIDFieldGroup(textline);
                            break;
                        case "RELATEDFIELDGROUP":
                            UpdateRelatedFieldGroup(textline);
                            break;
                        case "MEASUREFIELDGROUPLOGIC":
                            UpdateMeasureFieldGroupLogic(textline);
                            break;
                        case "DDIDRELATEDFIELDGROUP":
                            UpdateDDIDRelatedFieldGroup(textline);
                            break;
                        //SH end
                        case "MEASUREFLOWCHARTACTION":
                            UpdateMeasureFlowchartAction(textline);
                            break;
                        case "INDICATORNUMBEROFCASES":
                            UpdateIndicatorNumberOfCases(textline);
                            break;
                        case "INDICATORICDPOP":
                            ImportIndicatorICDPop(textline);
                            break;
                        case "MEASURESET":
                            ImportMeasureSet(textline);
                            break;
                        case "MEASURESETMAPMEAS":
                            ImportMeasureSetMapMeas(textline);
                            break;
                    }
                }
                Application.DoEvents();
            }

            FileSystem.FileClose(FileNum);
            //LDW modGlobal.gv_cn.Execute("EXEC AutoConstraints 1");
            var command4 = new SqlCommand("EXEC AutoConstraints 1", modGlobal.gv_cn);
            try
            {
                command4.Connection.Open();
                command4.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command4.Dispose();
                modGlobal.gv_cn.Close();
            }

            //update the version
            if (!string.IsNullOrEmpty(NewVer))
            {
                modGlobal.gv_sql = "Delete tbl_Setup_version ";
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                var command5 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
                try
                {
                    command5.Connection.Open();
                    command5.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while opening connection: " + ex.Message);
                }
                finally
                {
                    command5.Dispose();
                    modGlobal.gv_cn.Close();
                }

                modGlobal.gv_sql = "Insert into tbl_Setup_version (VersionNumber, VersionDate, VersionStartDate) ";
                modGlobal.gv_sql = string.Format("{0} values ({1},'{2}',", modGlobal.gv_sql, NewVer, DateAndTime.Now);
                if (string.IsNullOrEmpty(VersionStartDate))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
                }
                else
                {
                    modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, VersionStartDate);
                }
                modGlobal.gv_sql = modGlobal.gv_sql + " )";
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                var command6 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
                try
                {
                    command6.Connection.Open();
                    command6.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while opening connection: " + ex.Message);
                }
                finally
                {
                    command6.Dispose();
                    modGlobal.gv_cn.Close();
                }
            }

            if (!string.IsNullOrEmpty(NewStateVer))
            {
                //update the State version
                if (!string.IsNullOrEmpty(NewStateVer))
                {
                    modGlobal.gv_sql = "Delete tbl_Setup_Stateversion ";
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    var command7 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
                    try
                    {
                        command7.Connection.Open();
                        command7.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while opening connection: " + ex.Message);
                    }
                    finally
                    {
                        command7.Dispose();
                        modGlobal.gv_cn.Close();
                    }

                    modGlobal.gv_sql = "Insert into tbl_Setup_Stateversion (State, StateVersion, StateVersionDate) ";
                    modGlobal.gv_sql = string.Format("{0} values ('{1}',{2},'{3}')", modGlobal.gv_sql, state, NewVer, DateAndTime.Now);
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    var command8 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
                    try
                    {
                        command8.Connection.Open();
                        command8.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while opening connection: " + ex.Message);
                    }
                    finally
                    {
                        command8.Dispose();
                        modGlobal.gv_cn.Close();
                    }
                }
            }

            //gv_cn.Execute "update tbl_setup_datadef Set cmsfieldcode = calcparent From tbl_Setup_CMSFieldMeasures Where tbl_Setup_CMSFieldMeasures.DDID = tbl_Setup_DataDef.DDID "
            //LDW modGlobal.gv_cn.Execute("EXEC UpdateCMSFieldCodeFROMBackup");
            var command9 = new SqlCommand("EXEC UpdateCMSFieldCodeFROMBackup", modGlobal.gv_cn);
            try
            {
                command9.Connection.Open();
                command9.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command9.Dispose();
                modGlobal.gv_cn.Close();
            }

            Cursor.Current = Cursors.Default;
            RadMessageBox.Show("System Update was completed successfully.");

            return;
            UpdateSysErr:

            //LDW if (Err().Number == 71)
            if (Information.Err().Number == 71)
            {
                Cursor.Current = Cursors.Default;
                RadMessageBox.Show("Please insert a diskette and then try again.");
                return;
            }
            else
            {
                //Resume
                //msg = "The following error occured in the process of creating an update for Access database: " & Chr(13) & Chr(10)
                //msg = msg & Err.Number & ": " & Err.Description
                //On Error GoTo 0
                //Screen.MousePointer = 0
                //MsgBox "Please insert a diskette and then try again."
                //Exit Function
            }
        }

        //LDW public static void UpdateTableDef(string textline)
        public static void UpdateTableDef(string textline)
        {
			var i = 0;
			var StartPos = 2;
            string RecordStatus = "";
            string state = "";
            string CompareToDesc = "";
            string OldTableName = "";
            string TableType = "";
            string BaseTable = "";
            object basetableid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					basetableid = basetableid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					BaseTable = BaseTable + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableType = TableType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OldTableName = OldTableName + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CompareToDesc = CompareToDesc + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				} else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_TableDef (BaseTableID, BaseTable, TableType, OldTableName, CompareToDesc, State, RecordStatus)";
			modGlobal.gv_sql = string.Format("{0} values ({1},'{2}','{3}', ", modGlobal.gv_sql, basetableid, BaseTable, TableType);
			if (string.IsNullOrEmpty(OldTableName))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, OldTableName);
			}

			if (string.IsNullOrEmpty(CompareToDesc) | CompareToDesc == "0")
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, CompareToDesc);
			}

			if (string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, state);
			}
			if (string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, RecordStatus);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command10 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command10.Connection.Open();
                command10.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command10.Dispose();
                modGlobal.gv_cn.Close();
            }  
        }

        //LDW public static void UpdateMiscLookupList(string textline)
        public static void UpdateMiscLookupList(string textline)
        {
			var i = 0;
			var StartPos = 2;
            string SortOrder = "";
            string OldID = "";
            string Id = "";
            string basetableid = "";
            string LookupID = "";
            string FIELDVALUE = null;
			FIELDVALUE = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupID = LookupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					basetableid = basetableid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Id = Id + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OldID = OldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDVALUE = FIELDVALUE + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SortOrder = SortOrder + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_MiscLookupList (LookupID, BaseTableID, ID, oldid, FieldValue, SortOrder)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},'{3}',", modGlobal.gv_sql, LookupID, basetableid, Id);
			if (string.IsNullOrEmpty(OldID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, OldID);
			}
			modGlobal.gv_sql = string.Format("{0}'{1} ',", modGlobal.gv_sql, modGlobal.ConvertApastroph( FIELDVALUE));
			if (string.IsNullOrEmpty(SortOrder))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}", modGlobal.gv_sql, SortOrder);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command11 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command11.Connection.Open();
                command11.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command11.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		public static void UpdateIndicatorGroup(string textline)
		{
			var i = 0;
			var StartPos = 2;
            string RecordStatus = "";
            string state = "";
            string DisplayOrder = "";
            string basetableid = "";
            string GroupDescription = "";
            string indicatorgroupid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					indicatorgroupid = indicatorgroupid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					GroupDescription = GroupDescription + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					basetableid = basetableid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DisplayOrder = DisplayOrder + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//If GroupDescription = "Iowa" Then
			//    wait = True
			//End If
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it

			modGlobal.gv_sql = "Insert into tbl_setup_IndicatorGroup (IndicatorGroupID, GroupDescription, BaseTableID, DisplayOrder, State, RecordStatus)";
			modGlobal.gv_sql = string.Format("{0} values ({1},'{2}',{3},", modGlobal.gv_sql, indicatorgroupid, GroupDescription, basetableid);
			if (string.IsNullOrEmpty(DisplayOrder))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, DisplayOrder);
			}
			if (string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, state);
			}
			if (string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, RecordStatus);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command12 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command12.Connection.Open();
                command12.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command12.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateDataDef(string textline)
        public static void UpdateDataDef(string textline)
        {
			var i = 0;
			var StartPos = 2;
            string IsInActive = "";
            string IsPhysician = "";
            string AllowUTD = "";
            string ParentDDID = "";
            string RecordStatus = "";
            string state = "";
            string DateFieldDDID = "";
            string SortOrder = "";
            string OldFieldName = "";
            string Required_EffDate = "";
            string Required = "";
            string helpmsg = "";
            string LookupTableID = "";
            string FieldCategory = "";
            string FieldSize = "";
            string FieldType = "";
            string basetableid = "";
            string DDID = "";
            string FieldName = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					basetableid = basetableid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldName = FieldName + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			FieldName = modGlobal.ConvertApastroph( FieldName);

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldType = FieldType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldSize = FieldSize + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldCategory = FieldCategory + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					if (Strings.Mid(textline, i, 1) == "|")
                    {
						helpmsg = helpmsg + Strings.Chr(13);
					}
                    else
                    {
						helpmsg = helpmsg + Strings.Mid(textline, i, 1);
					}
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

            //helpmsg = Replace(helpmsg, "''", """")
            //LDW helpmsg = Strings.Replace(helpmsg, "|", Strings.Chr(13));
            helpmsg = Strings.Replace(helpmsg, "|", Convert.ToString(Strings.Chr(13)));
            //LDW helpmsg = Strings.Replace(helpmsg, "*", Strings.Chr(183));
            helpmsg = Strings.Replace(helpmsg, "*", Convert.ToString(Strings.Chr(183)));
            //LDW helpmsg = Strings.Replace(helpmsg, "-", Strings.Chr(150));
            helpmsg = Strings.Replace(helpmsg, "-", Convert.ToString(Strings.Chr(150)));

            //                For i = 1 To Len(help)
            //                If mid(help, i, 1) = Chr(13) Then
            //                    Mid(help, i, 1) = "|"
            //                ElseIf mid(help, i, 1) = Chr(183) Then
            //                    Mid(help, i, 1) = "*"
            //                ElseIf mid(help, i, 1) = Chr(146) Or mid(help, i, 1) = Chr(145) Then
            //                    Mid(help, i, 1) = "'"
            //                ElseIf mid(help, i, 1) = Chr(150) Then
            //                    Mid(help, i, 1) = "-"
            //                ElseIf mid(help, i, 1) = Chr(148) Or mid(help, i, 1) = Chr(147) Then
            //                    Mid(help, i, 1) = """"
            //                ElseIf Asc(mid(help, i, 1)) = 233 Then
            //                    Mid(help, i, 1) = mid(help, i, 1)
            //                ElseIf Asc(mid(help, i, 1)) > 126 Then
            //                    Mid(help, i, 1) = " "
            //                End If
            //            Next i


            helpmsg = modGlobal.ConvertApastroph( helpmsg);

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Required = Required + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Required_EffDate = Required_EffDate + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OldFieldName = OldFieldName + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SortOrder = SortOrder + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DateFieldDDID = DateFieldDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ParentDDID = ParentDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					AllowUTD = AllowUTD + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (AllowUTD == "False")
            {
                //LDW AllowUTD = 0;
                AllowUTD = Convert.ToString(0);
            }
            else if (AllowUTD == "True")
            {
                //LDW AllowUTD = 1;
                AllowUTD = Convert.ToString(1);
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IsPhysician = IsPhysician + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (string.IsNullOrEmpty(IsPhysician))
            {
                //LDW IsPhysician = 0;
                IsPhysician = Convert.ToString(0);
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IsInActive = IsInActive + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//If IsInActive = "" Then
			//    IsInActive = "null"
			//Else
			//    IsInActive = "'I'"
			//End If

			if (IsInActive == "0")
            {
				IsInActive = "Null";
			}
            else if (IsInActive == "1")
            {
				IsInActive = "'I'";
			}
            else
            {
				IsInActive = "Null";
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it


			modGlobal.gv_sql = "Insert into tbl_setup_DataDef (DDID, BaseTableID, FieldName, FieldType, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldSize, FieldCategory, LookuptableID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Help, Required, Required_EffDate, OldFieldName, SortOrder, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DateFieldDDID, State, RecordStatus, ParentDDID, AllowUTD, IsPhysician, Inactive )";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},'{3}','{4}',", modGlobal.gv_sql, DDID, basetableid, FieldName, FieldType);
			if (string.IsNullOrEmpty(FieldSize))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, FieldSize);
			}
			if (string.IsNullOrEmpty(FieldCategory))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, FieldCategory);
			}
			if (string.IsNullOrEmpty(LookupTableID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, LookupTableID);
			}
			if (string.IsNullOrEmpty(helpmsg))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, helpmsg);
			}
			if (string.IsNullOrEmpty(Required))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, Required);
			}
			if (string.IsNullOrEmpty(Required_EffDate))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}#{1}#,", modGlobal.gv_sql, Required_EffDate);
			}
			if (string.IsNullOrEmpty(OldFieldName))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, OldFieldName);
			}
			if (string.IsNullOrEmpty(SortOrder))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, SortOrder);
			}
			if (string.IsNullOrEmpty(DateFieldDDID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, DateFieldDDID);
			}
			if (string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, state);
			}
			if (string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, RecordStatus);
			}
			if (string.IsNullOrEmpty(ParentDDID))
            {
				modGlobal.gv_sql = string.Format("{0} Null,", modGlobal.gv_sql);
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, ParentDDID);
			}

			if (string.IsNullOrEmpty(AllowUTD))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, AllowUTD);
			}

			modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, IsPhysician);
			modGlobal.gv_sql = modGlobal.gv_sql + IsInActive;
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command13 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command13.Connection.Open();
                command13.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command13.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateDataDefActions(string textline)
        public static void UpdateDataDefActions(string textline)
        {
			var i = 0;
			var StartPos = 2;
            string Dataentryactionid = "";
            string ActionCode = "";
            string ActionDesc = "";
            string DDID = "";
            string Datadefactionid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Datadefactionid = Datadefactionid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ActionDesc = ActionDesc + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ActionCode = ActionCode + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Dataentryactionid = Dataentryactionid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_DataDefActions ";
			modGlobal.gv_sql = modGlobal.gv_sql + "( ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Datadefactionid, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DataEntryActionid) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, Datadefactionid);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, DDID);
			modGlobal.gv_sql = string.Format("{0} {1} ", modGlobal.gv_sql, Dataentryactionid);
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command14 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command14.Connection.Open();
                command14.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command14.Dispose();
                modGlobal.gv_cn.Close();
            }
        }
        //LDW public static void UpdateDataEntryActions(ref object textline)
        public static void UpdateDataEntryActions(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string ActionCode = "";
            string ActionDesc = "";
            string Dataentryactionid = "";

            
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Dataentryactionid = Dataentryactionid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ActionDesc = ActionDesc + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ActionCode = ActionCode + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_DataEntryActions ";
			modGlobal.gv_sql = modGlobal.gv_sql + "( ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DataEntryActionid, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ActionDesc, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ActionCode) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, Dataentryactionid);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, ActionDesc);
			modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, ActionCode);
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command15 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command15.Connection.Open();
                command15.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command15.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateDataReq(string textline)
        public static void UpdateDataReq(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string DDID = "";
            string IndicatorID = "";
            string IndicatorDDID = "";

            
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorDDID = IndicatorDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_DataReq (IndicatorDDID, IndicatorID, DDID)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},{3})", modGlobal.gv_sql, IndicatorDDID, IndicatorID, DDID);

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command16 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command16.Connection.Open();
                command16.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command16.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateIndicator(string textline)
        public static void UpdateIndicator(string textline)
        {
			var i = 0;
			var StartPos = 2;
            string AppCare = "";
            string JCCode = "";
            string MeasureSet = "";
            string EndDateTimeFieldID = "";
            string StartDateTimeFieldID = "";
            string PatientType = "";
            string CMSCode = "";
            string CMSSampleFieldDDID = "";
            string MeasureDataUsage = "";
            string BaseType = "";
            string StatewidePageOrientation = "";
            string RiskAdjustSGID = "";
            string ContinuousSGID = "";
            string IndScale = "";
            string BreakoutType = "";
            string BestPractice = "";
            string MeasureTimeBy = "";
            string EndTimeFieldID = "";
            string EndDateFieldID = "";
            string StartTimeFieldID = "";
            string StartDateFieldID = "";
            string RiskAdjusted = "";
            string CalcType = "";
            string IndicatorType = "";
            string JCAHOID = "";
            string lastupdatedate = "";
            string RecordStatus = "";
            string state = "";
            string OldFieldName = "";
            string Description = "";
            string IndicatorID = "";
			//===========================

			//1
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				} else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//2
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Description = Description + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//3
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OldFieldName = OldFieldName + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//4
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				} else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//5
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//6
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					lastupdatedate = lastupdatedate + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//7
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JCAHOID = JCAHOID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//8
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorType = IndicatorType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//9
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CalcType = CalcType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//10
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RiskAdjusted = RiskAdjusted + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//11
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					StartDateFieldID = StartDateFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//12
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					StartTimeFieldID = StartTimeFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//13
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					EndDateFieldID = EndDateFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//14
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					EndTimeFieldID = EndTimeFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//15
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					MeasureTimeBy = MeasureTimeBy + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//16
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					BestPractice = BestPractice + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//17
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					BreakoutType = BreakoutType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//18
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndScale = IndScale + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//19
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ContinuousSGID = ContinuousSGID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//20
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RiskAdjustSGID = RiskAdjustSGID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//21
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					StatewidePageOrientation = StatewidePageOrientation + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//22
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					BaseType = BaseType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//23
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					MeasureDataUsage = MeasureDataUsage + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//24
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CMSSampleFieldDDID = CMSSampleFieldDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//25
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CMSCode = CMSCode + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//26
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					MeasureSet = MeasureSet + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//27
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					PatientType = PatientType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//28
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					StartDateTimeFieldID = StartDateTimeFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//29
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					EndDateTimeFieldID = EndDateTimeFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//30
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JCCode = JCCode + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//31
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					AppCare = AppCare + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_Setup_Indicator (";
			modGlobal.gv_sql = modGlobal.gv_sql + " IndicatorID, Description, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " OldFieldName, State, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " RecordStatus, lastupdatedate, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JCAHOID, IndicatorType,";
			modGlobal.gv_sql = modGlobal.gv_sql + " CalcType, RiskAdjusted,";
			modGlobal.gv_sql = modGlobal.gv_sql + " StartDateFieldID, StartTimeFieldID ,";
			modGlobal.gv_sql = modGlobal.gv_sql + " EndDateFieldID, EndTimeFieldID,";
			modGlobal.gv_sql = modGlobal.gv_sql + " MeasureTimeBy, BestPractice,  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " BreakoutType, Scale, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ContinuousSGID, RiskAdjustSGID,";
			modGlobal.gv_sql = modGlobal.gv_sql + " BaseType, MeasureDataUsage,";
			modGlobal.gv_sql = modGlobal.gv_sql + " StatewidePageOrientation, CMSSampleFieldDDID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " CMSCode, PatientType, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " StartDateTimeFieldID, EndDateTimeFieldID, JCCode, AppCare)";
			modGlobal.gv_sql = string.Format("{0} values ({1},'{2}',", modGlobal.gv_sql, IndicatorID, Description);

			if (string.IsNullOrEmpty(OldFieldName))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, OldFieldName);
			}
			if (string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, state);
			}
			if (string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, RecordStatus);
			}
			if (string.IsNullOrEmpty(lastupdatedate))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, lastupdatedate);
			}
			if (string.IsNullOrEmpty(JCAHOID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 0, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, JCAHOID);
			}
			if (string.IsNullOrEmpty(IndicatorType))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, IndicatorType);
			}
			if (string.IsNullOrEmpty(CalcType))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, CalcType);
			}
			if (string.IsNullOrEmpty(RiskAdjusted))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 0, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, RiskAdjusted);
			}
			if (string.IsNullOrEmpty(StartDateFieldID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 0, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, StartDateFieldID);
			}
			if (string.IsNullOrEmpty(StartTimeFieldID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 0, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, StartTimeFieldID);
			}
			if (string.IsNullOrEmpty(EndDateFieldID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 0, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, EndDateFieldID);
			}
			if (string.IsNullOrEmpty(EndTimeFieldID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 0, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, EndTimeFieldID);
			}
			if (string.IsNullOrEmpty(MeasureTimeBy))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, MeasureTimeBy);
			}
			if (string.IsNullOrEmpty(BestPractice))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, BestPractice);
			}
			if (string.IsNullOrEmpty(BreakoutType))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, BreakoutType);
			}
			if (string.IsNullOrEmpty(IndScale))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, IndScale);
			}
			if (string.IsNullOrEmpty(ContinuousSGID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, ContinuousSGID);
			}
			if (string.IsNullOrEmpty(RiskAdjustSGID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, RiskAdjustSGID);
			}
			if (string.IsNullOrEmpty(BaseType))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, BaseType);
			}
			if (string.IsNullOrEmpty(MeasureDataUsage))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, MeasureDataUsage);
			}
			if (string.IsNullOrEmpty(StatewidePageOrientation))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'P', ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, StatewidePageOrientation);
			}

			if (string.IsNullOrEmpty(CMSSampleFieldDDID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, CMSSampleFieldDDID);
			}

			if (string.IsNullOrEmpty(CMSCode))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, CMSCode);
			}

			if (string.IsNullOrEmpty(PatientType))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 1, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, PatientType);
			}

			if (string.IsNullOrEmpty(StartDateTimeFieldID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, StartDateTimeFieldID);
			}

			if (string.IsNullOrEmpty(EndDateTimeFieldID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, EndDateTimeFieldID);
			}

			if (string.IsNullOrEmpty(JCCode))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " NULL, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, JCCode);
			}

			if (string.IsNullOrEmpty(AppCare))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 0 ";
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + AppCare;
			}

			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command17 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command17.Connection.Open();
                command17.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command17.Dispose();
                modGlobal.gv_cn.Close();
            }
        }
        //LDW public static void UpdateIndicatorGroupSet(ref object textline)
        public static void UpdateIndicatorGroupSet(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string fieldorder = "";
            string indicatorgroupid = "";
            string DDID = "";
            string IndicatorGroupsetID = "";
            

			
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorGroupsetID = IndicatorGroupsetID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					indicatorgroupid = indicatorgroupid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldorder = fieldorder + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it

			modGlobal.gv_sql = "Insert into tbl_setup_IndicatorGroupSet (IndicatorGroupSetID, DDID, IndicatorGroupID, FieldOrder)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2}, {3}, ", modGlobal.gv_sql, IndicatorGroupsetID, DDID, indicatorgroupid);
			if (string.IsNullOrEmpty(fieldorder))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + fieldorder;
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command18 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command18.Connection.Open();
                command18.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command18.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateIndicatorDep(string textline)
        public static void UpdateIndicatorDep(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string IndicatorID = "";
            string IndicatorParentID = "";
            string IndicatorDepID = "";
            
			
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorDepID = IndicatorDepID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorParentID = IndicatorParentID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_IndicatorDep (IndicatorDepID, IndicatorParentID, IndicatorID)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},{3})", modGlobal.gv_sql, IndicatorDepID, IndicatorParentID, IndicatorID);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command19 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command19.Connection.Open();
                command19.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command19.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateIndicatorSet(string textline)
        public static void UpdateIndicatorSet(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string RecordStatus = "";
            string state = "";
            string IndicatorSetDesc = "";
            string IndicatorSetID = "";
            

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorSetID = IndicatorSetID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorSetDesc = IndicatorSetDesc + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_IndicatorSet (IndicatorSetID, IndicatorSetDesc, State, RecordStatus)";
			modGlobal.gv_sql = string.Format("{0} values ({1},'{2}', ", modGlobal.gv_sql, IndicatorSetID, IndicatorSetDesc);
			if (string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, state);
			}
			if (string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, RecordStatus);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command20 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command20.Connection.Open();
                command20.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command20.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateIndicatorSetField(string textline)
        public static void UpdateIndicatorSetField(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string IndicatorSetID = "";
            string IndicatorID = "";
            string IndLinkID = "";


			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndLinkID = IndLinkID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorSetID = IndicatorSetID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_IndicatorSetField  (IndLinkID, IndicatorID, IndicatorSetID)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},{3})", modGlobal.gv_sql, IndLinkID, IndicatorID, IndicatorSetID);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command21 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command21.Connection.Open();
                command21.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command21.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateHospStatGroup(string textline)
        public static void UpdateHospStatGroup(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string GroupDescription = "";
            string indicatorgroupid = "";
            string HospStatGroupID = "";
           

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					HospStatGroupID = HospStatGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					indicatorgroupid = indicatorgroupid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					GroupDescription = GroupDescription + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroup (HospStatGroupID, IndicatorGroupID, GroupDescription)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},'{3}'", modGlobal.gv_sql, HospStatGroupID, indicatorgroupid, GroupDescription);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command22 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command22.Connection.Open();
                command22.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command22.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateHospStatGroupIndicator(string textline)
        public static void UpdateHospStatGroupIndicator(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string IndicatorID = "";
            string HospStatGroupID = "";
            


			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					HospStatGroupID = HospStatGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroupIndicator  (HospStatGroupID, IndicatorID)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2})", modGlobal.gv_sql, HospStatGroupID, IndicatorID);
			//LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command23 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command23.Connection.Open();
                command23.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command23.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateHospStatGroupFields(string textline)
        public static void UpdateHospStatGroupFields(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string fieldorder = "";
            string DDID = "";
            string HospStatGroupID = "";
            

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					HospStatGroupID = HospStatGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldorder = fieldorder + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_HospStatGroupFields (HospStatGroupID, DDID, FieldOrder)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},{3} )", modGlobal.gv_sql, HospStatGroupID, DDID, string.IsNullOrEmpty(fieldorder) ? " Null " : fieldorder);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command24 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command24.Connection.Open();
                command24.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command24.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSavedAdhocReports(string textline)
        public static void UpdateSavedAdhocReports(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string RecordStatus = "";
			string state = "";
			string SystemReport = "";
			string JoinOperator = "";
			string basetableid = "";
			string ReportName = "";
			string ReportID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ReportID = ReportID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ReportName = ReportName + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					basetableid = basetableid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SystemReport = SystemReport + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//add it
			modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReports (Report_ID, Report_Name, BaseTableID, State, RecordStatus, JoinOperator)";
			modGlobal.gv_sql = string.Format("{0} values ({1},'{2}',", modGlobal.gv_sql, ReportID, ReportName);
			if (string.IsNullOrEmpty(basetableid))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, basetableid);
			}
			if (string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, state);
			}
			if (string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, RecordStatus);
			}

			if (string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, JoinOperator);
			}

			modGlobal.gv_sql = modGlobal.gv_sql + ")";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command25 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command25.Connection.Open();
                command25.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command25.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSavedAdhocReportCriteria(string textline)
        public static void UpdateSavedAdhocReportCriteria(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string CriteriaSet = "";
            string JoinOperator = "";
            string DateUnit = "";
            string FieldOperator = "";
            string LookupTableID = "";
            string LookupID = "";
            string thisValue = "";
            string ValueOperator = "";
            string DestDDID = "";
            string SourceDDID2 = "";
            string SourceDDID1 = "";
            string CriteriaTitle = "";
            string ReportID = "";
            string criteriaID = "";


			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					criteriaID = criteriaID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ReportID = ReportID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaTitle = CriteriaTitle + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SourceDDID1 = SourceDDID1 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SourceDDID2 = SourceDDID2 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DestDDID = DestDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValueOperator = ValueOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					thisValue = thisValue + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupID = LookupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldOperator = FieldOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DateUnit = DateUnit + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaSet = CriteriaSet + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			modGlobal.gv_sql = "Insert into tbl_Setup_SavedAdhocReportCriteria ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (CriteriaID, Report_ID, CriteriaTitle, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, DestDDID, ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " [Value], Lookupid, LookupTableid, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, DateUnit, JoinOperator, CriteriaSet ) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2}, '{3}',", modGlobal.gv_sql, criteriaID, ReportID, CriteriaTitle);
			modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, SourceDDID1);

			if (string.IsNullOrEmpty(SourceDDID2))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, SourceDDID2);
			}
			if (string.IsNullOrEmpty(DestDDID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, DestDDID);
			}
			if (string.IsNullOrEmpty(ValueOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, ValueOperator);
			}
			if (string.IsNullOrEmpty(thisValue))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, thisValue);
			}
			if (string.IsNullOrEmpty(LookupID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupID);
			}
			if (string.IsNullOrEmpty(LookupTableID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupTableID);
			}
			if (string.IsNullOrEmpty(FieldOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, FieldOperator);
			}
			if (string.IsNullOrEmpty(DateUnit))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, DateUnit);
			}
			if (string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, JoinOperator);
			}
			if (string.IsNullOrEmpty(CriteriaSet))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, CriteriaSet);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command26 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command26.Connection.Open();
                command26.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command26.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSavedAdhocReportFields(string textline)
        public static void UpdateSavedAdhocReportFields(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string OrderID = "";
            string FieldCaption = "";
            string DDID = "";
            string ReportID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ReportID = ReportID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")

                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				} else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++) {
				if (Strings.Mid(textline, i, 1) != "\"") {
					FieldCaption = FieldCaption + Strings.Mid(textline, i, 1);
				} else {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OrderID = OrderID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//add it
			modGlobal.gv_sql = "Insert into tbl_setup_SavedAdhocReportFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (Report_ID, DDID, FieldCaption, OrderID ) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2}, '{3}',", modGlobal.gv_sql, ReportID, DDID, FieldCaption);
			if (string.IsNullOrEmpty(OrderID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1} ", modGlobal.gv_sql, OrderID);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command27 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command27.Connection.Open();
                command27.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command27.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateHospStatVal(string textline)
        public static void UpdateHospStatVal(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string EffDate = "";
            string Message = "";
            string ValType = "";
            string Operator_Renamed = "";
            string Display = "";
            string HospStatGroupID2 = "";
            string HospStatGroupID1 = "";
            string HospStatValidID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")

                {
					HospStatValidID = HospStatValidID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"") {
					HospStatGroupID1 = HospStatGroupID1 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					HospStatGroupID2 = HospStatGroupID2 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Display = Display + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Operator_Renamed = Operator_Renamed + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Message = Message + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			Message = Strings.Replace(Message, "''", "\"");
			Message = modGlobal.ConvertApastroph( Message);

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					EffDate = EffDate + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")

                {
					ValType = ValType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			//1. find the record
			//2. if not found, add it
			//3. if found, update it
			modGlobal.gv_sql = "Insert into tbl_setup_HospStatVal (HospStatValidID, HospStatGroupID1, HospStatGroupID2, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Display, Operator, Type, Message,  EffDate)";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2},{3},", modGlobal.gv_sql, HospStatValidID, HospStatGroupID1, HospStatGroupID2);
			modGlobal.gv_sql = string.Format("{0}'{1}','{2}','{3}',", modGlobal.gv_sql, Display, Operator_Renamed, ValType);
			if (string.IsNullOrEmpty(Message))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Message);
			}
			if (string.IsNullOrEmpty(EffDate))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " null";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, EffDate);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command28 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command28.Connection.Open();
                command28.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command28.Dispose();
                modGlobal.gv_cn.Close();
            }

            //gv = InputBox("", "", gv_sql)
            //terst = 1
        }
        //LDW public static void UpdateImportSetup(string textline)
        public static void UpdateImportSetup(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string RecordStatus = "";
            string state = "";
            string Description = "";
            string methodnumber = "";
            string ImportSetupID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ImportSetupID = ImportSetupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					methodnumber = methodnumber + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Description = Description + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_ImportSetup ";
			modGlobal.gv_sql = modGlobal.gv_sql + "( ";
			modGlobal.gv_sql = modGlobal.gv_sql + " ImportSetupID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " methodnumber, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Description, State, RecordStatus) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, ImportSetupID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, string.IsNullOrEmpty(methodnumber) ? " Null" : methodnumber);
			modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, Description);
			if (!string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, state);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " null, ";
			}
			if (!string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, RecordStatus);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " null ";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command29 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command29.Connection.Open();
                command29.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command29.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateImportFields(string textline)
        public static void UpdateImportFields(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string ImportFieldID = "";
            string OrderNumber = "";
            string DDID = "";
            string ImportSetupID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ImportSetupID = ImportSetupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OrderNumber = OrderNumber + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ImportFieldID = ImportFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//add it
			modGlobal.gv_sql = "Insert into tbl_Setup_ImportFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (importfieldid, ImportSetupID, DDID, OrderNumber) ";
			modGlobal.gv_sql = string.Format("{0} values ({1}, {2},{3}, ", modGlobal.gv_sql, ImportFieldID, ImportSetupID, DDID);
			if (string.IsNullOrEmpty(OrderNumber))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + OrderNumber;
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command30 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command30.Connection.Open();
                command30.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command30.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateImportValidationMessage(string textline)
        public static void UpdateImportValidationMessage(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string ImportFieldID = "";
            string JoinOperator = "";
            string ValidationType = "";
            string ValidationCount = "";
            string Message = "";
            string msgid = "";
            string DDID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					msgid = msgid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Message = Message + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			Message = Strings.Replace(Message, "''", "\"");
			Message = modGlobal.ConvertApastroph( Message);

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValidationCount = ValidationCount + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValidationType = ValidationType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ImportFieldID = ImportFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//add it
			modGlobal.gv_sql = "Insert into tbl_Setup_ImportValidationMessage ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (DDID, MsgID, Message, ValidationCount, ValidationType, JoinOperator, ImportFieldID) ";
			modGlobal.gv_sql = string.Format("{0} values ({1}, {2},", modGlobal.gv_sql, DDID, msgid);
			if (string.IsNullOrEmpty(Message))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, Message);
			}
			if (string.IsNullOrEmpty(ValidationCount))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, ValidationCount);
			}
			if (string.IsNullOrEmpty(ValidationType))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'Error', ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, ValidationType);
			}
			if (string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, JoinOperator);
			}
			modGlobal.gv_sql = string.Format("{0},{1})", modGlobal.gv_sql, ImportFieldID);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command31 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command31.Connection.Open();
                command31.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command31.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateImportValidation(string textline)
        public static void UpdateImportValidation(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string FieldType = "";
            string FIELDVALUE = "";
            string Operator_Renamed = "";
            string FieldTypeVal = "";
            string msgid = "";
            string ValidationTitle = "";
            string LookupTableID = "";
            string DDID = "";
            string ValidID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValidID = ValidID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValidationTitle = ValidationTitle + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					msgid = msgid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldTypeVal = FieldTypeVal + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Operator_Renamed = Operator_Renamed + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDVALUE = FIELDVALUE + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldType = FieldType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//add it

			modGlobal.gv_sql = "Insert into tbl_Setup_ImportValidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (ValidID, DDID, MsgID, LookupTableID, ValidationTitle, FieldTypeVal,";
			modGlobal.gv_sql = modGlobal.gv_sql + " Operator, FieldValue, FieldType) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2}, {3},", modGlobal.gv_sql, ValidID, DDID, msgid);
			if (string.IsNullOrEmpty(LookupTableID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, LookupTableID);
			}
			if (string.IsNullOrEmpty(ValidationTitle))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, ValidationTitle);
			}
			if (string.IsNullOrEmpty(FieldTypeVal))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, FieldTypeVal);
			}
			if (string.IsNullOrEmpty(Operator_Renamed))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Operator_Renamed);
			}
			if (string.IsNullOrEmpty(FIELDVALUE))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, FIELDVALUE);
			}
			if (string.IsNullOrEmpty(FieldType))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, FieldType);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command32 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command32.Connection.Open();
                command32.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command32.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitGroup(string textline)
        public static void UpdateSubmitGroup(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string ShowTotal = "";
            string RecordStatus = "";
            string state = "";
            string ShowOnReport = "";
            string OrderNumber = "";
            string ShowGroupHeader = "";
            string GroupName = "";
            string groupid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					groupid = groupid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					GroupName = GroupName + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ShowGroupHeader = ShowGroupHeader + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OrderNumber = OrderNumber + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ShowOnReport = ShowOnReport + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ShowTotal = ShowTotal + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record

			modGlobal.gv_sql = "Insert into tbl_setup_SubmitGroup (GroupID, GroupName, ShowGroupHeader, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Ordernumber, ShowOnReport, ShowTotal, State, RecordStatus)";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, groupid);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, GroupName);
			if (string.IsNullOrEmpty(ShowGroupHeader))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, ShowGroupHeader);
			}
			if (!string.IsNullOrEmpty(OrderNumber))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, OrderNumber);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (string.IsNullOrEmpty(ShowOnReport))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, ShowOnReport);
			}
			if (string.IsNullOrEmpty(ShowTotal))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, ShowTotal);
			}
			if (string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, state);
			}
			if (string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}' ", modGlobal.gv_sql, RecordStatus);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command33 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command33.Connection.Open();
                command33.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command33.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitGroupRow(string textline)
        public static void UpdateSubmitGroupRow(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string ShowOnReport = "";
            string OrderNumber = "";
            string Title = "";
            string groupid = "";
            string grouprowID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					grouprowID = grouprowID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					groupid = groupid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Title = Title + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OrderNumber = OrderNumber + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ShowOnReport = ShowOnReport + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitGroupRow (GroupRowID, GroupID, Title, Ordernumber, ShowOnReport)";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, grouprowID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, groupid);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Title);
			if (!string.IsNullOrEmpty(OrderNumber))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, OrderNumber);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (string.IsNullOrEmpty(ShowOnReport))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null)";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}')", modGlobal.gv_sql, ShowOnReport);
			}

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command34 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command34.Connection.Open();
                command34.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command34.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitSubGroup(string textline)
        public static void UpdateSubmitSubGroup(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string JoinOperator = "";
            string ShowOnReport = "";
            string OrderNumber = "";
            string AggregateFunction = "";
            string IndicatorID = "";
            string Title = "";
            string grouprowID = "";
            string SubGroupID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubGroupID = SubGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					grouprowID = grouprowID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Title = Title + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					AggregateFunction = AggregateFunction + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++) {
				if (Strings.Mid(textline, i, 1) != "\"") {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				} else {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					OrderNumber = OrderNumber + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ShowOnReport = ShowOnReport + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitSubGroup (SubGroupID, GroupRowID,  Title, IndicatorID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " AggregateFunction, JoinOperator, Ordernumber, ShowOnReport)";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, SubGroupID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, grouprowID);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Title);
			if (!string.IsNullOrEmpty(IndicatorID))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, IndicatorID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(AggregateFunction))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, AggregateFunction);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, JoinOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " 'And',";
			}
			if (!string.IsNullOrEmpty(OrderNumber))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, OrderNumber);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(ShowOnReport))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}' ", modGlobal.gv_sql, ShowOnReport);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command35 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command35.Connection.Open();
                command35.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command35.Dispose();
                modGlobal.gv_cn.Close();
            }
        }
        //LDW public static void UpdateSubmitSubGroupFields(string textline)
        public static void UpdateSubmitSubGroupFields(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string AggregateFieldID = "";
            string SubGroupID = "";
            string submitSubgroupFieldID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					submitSubgroupFieldID = submitSubgroupFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubGroupID = SubGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					AggregateFieldID = AggregateFieldID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitSubGroupFields ";
			modGlobal.gv_sql = modGlobal.gv_sql + "( ";
			modGlobal.gv_sql = modGlobal.gv_sql + " SubmitSubGroupFieldID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " SubGroupID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " AggregateFieldID) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, submitSubgroupFieldID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, SubGroupID);
			modGlobal.gv_sql = string.Format("{0} {1} ", modGlobal.gv_sql, AggregateFieldID);
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command36 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command36.Connection.Open();
                command36.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command36.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitCriteria(string textline)
        public static void UpdateSubmitCriteria(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string CriteriaSet = "";
            string JoinOperator = "";
            string DateUnit = "";
            string FieldOperator = "";
            string LookupTableID = "";
            string LookupID = "";
            string Value = "";
            string ValueOperator = "";
            string DestDDID = "";
            string ddid2 = "";
            string DDID1 = "";
            string CriteriaTitle = "";
            string SubGroupID = "";
            string SubmitCriteriaID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubmitCriteriaID = SubmitCriteriaID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubGroupID = SubGroupID + Strings.Mid(textline, i, 1);
				} else {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaTitle = CriteriaTitle + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID1 = DDID1 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ddid2 = ddid2 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DestDDID = DestDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValueOperator = ValueOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Value = Value + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupID = LookupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldOperator = FieldOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++) {
				if (Strings.Mid(textline, i, 1) != "\"") {
					DateUnit = DateUnit + Strings.Mid(textline, i, 1);
				} else {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaSet = CriteriaSet + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitCriteria (SubmitCriteriaID, SubGroupID,  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, DDID1, DDID2, DestDDID, ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " [Value], LookupID, LookupTableID, FieldOperator, DateUnit, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, criteriaset) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, SubmitCriteriaID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, SubGroupID);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, CriteriaTitle);
			if (!string.IsNullOrEmpty(DDID1))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, DDID1);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(ddid2))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, ddid2);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(DestDDID))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, DestDDID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(ValueOperator))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, ValueOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(Value))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, Value);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(LookupID))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(LookupTableID))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupTableID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(FieldOperator))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, FieldOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(DateUnit))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, DateUnit);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, JoinOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			modGlobal.gv_sql = string.Format("{0} {1})", modGlobal.gv_sql, CriteriaSet);

            //gv_IHADB.Execute gv_sql

            //Add the record

            //gv_sql = "Insert into tbl_setup_SubmitCriteria (SubmitCriteriaID, SubGroupID,  "
            //gv_sql = gv_sql & " CriteriaTitle, DDID1, DDID2, ValueOperator, "
            //gv_sql = gv_sql & " Value, LookupID, FieldOperator, DateUnit, JoinOperator, criteriaset) "
            //gv_sql = gv_sql & " values (" & SubmitCriteriaID & ","
            //gv_sql = gv_sql & " " & subGroupID & ","
            //gv_sql = gv_sql & " '" & CriteriaTitle & "',"
            //If DDID1 <> "" Then
            //    gv_sql = gv_sql & DDID1 & ", "
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //If DDID2 <> "" Then
            //    gv_sql = gv_sql & DDID2 & ", "
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //If ValueOperator <> "" Then
            //    gv_sql = gv_sql & "'" & ValueOperator & "', "
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //If Value <> "" Then
            //    gv_sql = gv_sql & " '" & Value & "', "
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //If LookupID <> "" Then
            //    gv_sql = gv_sql & LookupID & ", "
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //If Fieldoperator <> "" Then
            //    gv_sql = gv_sql & "'" & Fieldoperator & "', "
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //If dateunit <> "" Then
            //    gv_sql = gv_sql & "'" & dateunit & "', "
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //If JoinOperator <> "" Then
            //    gv_sql = gv_sql & "'" & JoinOperator & "',"
            //Else
            //    gv_sql = gv_sql & " Null,"
            //End If
            //gv_sql = gv_sql & criteriaset & ")"

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command37 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command37.Connection.Open();
                command37.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command37.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitValidation(string textline)
        public static void UpdateSubmitValidation(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string RecordStatus = "";
            string state = "";
            string JoinOperator = "";
            string ValType = "";
            string Message = "";
            string IndicatorID = "";
            string submitvalid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					submitvalid = submitvalid + Strings.Mid(textline, i, 1);
				} else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Message = Message + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			Message = Strings.Replace(Message, "''", "\"");
			Message = modGlobal.ConvertApastroph( Message);

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValType = ValType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitValidation (SubmitValID,IndicatorID,";
			modGlobal.gv_sql = modGlobal.gv_sql + " Message, ValType, JoinOperator, State, RecordStatus)";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, submitvalid);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, IndicatorID);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Message);

			if (!string.IsNullOrEmpty(ValType))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, ValType);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, JoinOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, state);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, RecordStatus);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command38 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command38.Connection.Open();
                command38.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command38.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitValSet(string textline)
        public static void UpdateSubmitValSet(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string ValueOperator = "";
            string Value = "";
            string GroupsOp = "";
            string Group2Op = "";
            string Group1Op = "";
            string Description = "";
            string submitvalid = "";
            string submitvalsetid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					submitvalsetid = submitvalsetid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					submitvalid = submitvalid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Description = Description + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Group1Op = Group1Op + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Group2Op = Group2Op + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					GroupsOp = GroupsOp + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Value = Value + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValueOperator = ValueOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitValset (SubmitValSetID, SubmitValID,";
			modGlobal.gv_sql = modGlobal.gv_sql + " Description, Group1Op, Group2Op, GroupsOp, Value, ValueOperator) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, submitvalsetid);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, submitvalid);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, modGlobal.ConvertApastroph( Description));

			if (!string.IsNullOrEmpty(Group1Op))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, Group1Op);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(Group2Op))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, Group2Op);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(GroupsOp))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, GroupsOp);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(Value))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, Value);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(ValueOperator))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}') ", modGlobal.gv_sql, ValueOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null)";
			}
            //resp = InputBox("", "", gv_sql)
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command39 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command39.Connection.Open();
                command39.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command39.Dispose();
                modGlobal.gv_cn.Close();
            }
        }
        //LDW public static void UpdateTableValidation(string textline)
        public static void UpdateTableValidation(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string CriteriaSet = "";
            string JoinOperator = "";
            string DateUnit = "";
            string FieldOperator = "";
            string LookupTableID = "";
            string LookupID = "";
            string thisValue = "";
            string ValueOperator = "";
            string DestDDID = "";
            string SourceDDID2 = "";
            string SourceDDID1 = "";
            string CriteriaTitle = "";
            string ValidationType = "";
            string TableValidationMessageID = "";
            string TableValidationID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableValidationID = TableValidationID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableValidationMessageID = TableValidationMessageID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValidationType = ValidationType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaTitle = CriteriaTitle + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SourceDDID1 = SourceDDID1 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SourceDDID2 = SourceDDID2 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DestDDID = DestDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValueOperator = ValueOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					thisValue = thisValue + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupID = LookupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldOperator = FieldOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DateUnit = DateUnit + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaSet = CriteriaSet + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//add it
			modGlobal.gv_sql = "Insert into tbl_Setup_TableValidation ";
			modGlobal.gv_sql = modGlobal.gv_sql + " (TableValidationID, TableValidationMessageID, ValidationType, CriteriaTitle, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " SourceDDID1, SourceDDID2, DestDDID, ValueOperator, [Value], Lookupid, LookupTableID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, DateUnit, JoinOperator, CriteriaSet ) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2}, ", modGlobal.gv_sql, TableValidationID, TableValidationMessageID);
			modGlobal.gv_sql = string.Format("{0} '{1}', '{2}',", modGlobal.gv_sql, ValidationType, CriteriaTitle);
			modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, SourceDDID1);

			if (string.IsNullOrEmpty(SourceDDID2))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, SourceDDID2);
			}
			if (string.IsNullOrEmpty(DestDDID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, DestDDID);
			}
			if (string.IsNullOrEmpty(ValueOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, ValueOperator);
			}
			if (string.IsNullOrEmpty(thisValue))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, thisValue);
			}
			if (string.IsNullOrEmpty(LookupID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupID);
			}
			if (string.IsNullOrEmpty(LookupTableID))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupTableID);
			}
			if (string.IsNullOrEmpty(FieldOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, FieldOperator);
			}
			if (string.IsNullOrEmpty(DateUnit))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, DateUnit);
			}
			if (string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, JoinOperator);
			}
			if (string.IsNullOrEmpty(CriteriaSet))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}
            else
            {
				modGlobal.gv_sql = string.Format("{0}'{1}'", modGlobal.gv_sql, CriteriaSet);
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command40 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command40.Connection.Open();
                command40.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command40.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateTableValidationMessage(string textline)
        public static void UpdateTableValidationMessage(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string RecordStatus = null;
            string mcriteria = null;
            string JoinOperator = null;
            string UserAction = null;
            string EffDate = null;
            string state = null;
            string MessageType = null;
            string Message = null;
            string basetableid = null;
            string TableValidationMessageID = null;

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableValidationMessageID = TableValidationMessageID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					basetableid = basetableid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Message = Message + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			Message = Strings.Replace(Message, "''", "\"");
			Message = Strings.Replace(Message, "'", "''");
			//Message = ConvertApastroph(Message)

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					MessageType = MessageType + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					EffDate = EffDate + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					UserAction = UserAction + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					mcriteria = mcriteria + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_TableValidationMessage (TableValidationMessageID, BaseTableID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " Message, MessageType, EffDate, UserAction, JoinOperator, State, RecordStatus)";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, TableValidationMessageID);
			modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, basetableid);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, Message);
			modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, MessageType);

			if (!string.IsNullOrEmpty(EffDate))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, EffDate);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(UserAction))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, UserAction);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, JoinOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, state);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, RecordStatus);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command41 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command41.Connection.Open();
                command41.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command41.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateTableValidationAction(string textline)
        public static void UpdateTableValidationAction(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string setvalue = "";
			string DDID = "";
            string TableValidationMessageID = "";
            string TableValidationActionID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableValidationActionID = TableValidationActionID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableValidationMessageID = TableValidationMessageID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					setvalue = setvalue + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_TableValidationAction (TableValidationActionID, TableValidationMessageID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID, SetValue) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, TableValidationActionID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, TableValidationMessageID);

			if (!string.IsNullOrEmpty(DDID))
            {
				modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, DDID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(setvalue))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, setvalue);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command42 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command42.Connection.Open();
                command42.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command42.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateTableValidationAfterFieldUpdate(string textline)
        public static void UpdateTableValidationAfterFieldUpdate(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string DDID = "";
            string TableValidationMessageID = "";
            string TableValidationAfterFieldUpdateID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableValidationAfterFieldUpdateID = TableValidationAfterFieldUpdateID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					TableValidationMessageID = TableValidationMessageID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_TableValidationAfterFieldUpdate ";
			modGlobal.gv_sql = modGlobal.gv_sql + "( ";
			modGlobal.gv_sql = modGlobal.gv_sql + " TableValidationAfterFieldUpdateID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " TableValidationMessageID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, TableValidationAfterFieldUpdateID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, TableValidationMessageID);
			if (!string.IsNullOrEmpty(DDID))
            {
				modGlobal.gv_sql = string.Format("{0} {1} ", modGlobal.gv_sql, DDID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command43 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command43.Connection.Open();
                command43.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command43.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitValSetGroup1(string textline)
        public static void UpdateSubmitValSetGroup1(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string SourceTable = "";
            string fieldid = "";
            string submitvalsetid = "";
            string SubmitValSetG1ID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubmitValSetG1ID = SubmitValSetG1ID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					submitvalsetid = submitvalsetid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldid = fieldid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SourceTable = SourceTable + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			//Add the record

			modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup1 (SubmitValSetG1ID, SubmitValSetID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, SubmitValSetG1ID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, submitvalsetid);

			if (!string.IsNullOrEmpty(fieldid))
            {
				modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, fieldid);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(SourceTable))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, SourceTable);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command44 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command44.Connection.Open();
                command44.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command44.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitValSetGroup2(string textline)
        public static void UpdateSubmitValSetGroup2(string textline)
        {
			var i = 0;
			var StartPos = 2;
			string SourceTable = "";
            string fieldid = "";
            string submitvalsetid = "";
            string SubmitValSetG2ID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubmitValSetG2ID = SubmitValSetG2ID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					submitvalsetid = submitvalsetid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldid = fieldid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SourceTable = SourceTable + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitValSetGroup2 (SubmitValSetG2ID, SubmitValSetID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " FieldID, SourceTable) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, SubmitValSetG2ID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, submitvalsetid);
			if (!string.IsNullOrEmpty(fieldid))
            {
				modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, fieldid);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(SourceTable))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, SourceTable);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + " )";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command45 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command45.Connection.Open();
                command45.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command45.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

        //LDW public static void UpdateSubmitCleanupItems(string textline)
        public static void UpdateSubmitCleanupItems(string textline)
        {
            string RecorStatus = "";
			var i = 0;
			var StartPos = 2;
			string RecordStatus = "";
            string state = "";
            string DDID = "";
            string CleanupDesc = "";
            string SubmitCleanupID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubmitCleanupID = SubmitCleanupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CleanupDesc = CleanupDesc + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecorStatus = RecorStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitCleanupItems (SubmitCleanupID, CleanupDesc, DDID, State, RecordStatus) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, SubmitCleanupID);
			if (!string.IsNullOrEmpty(CleanupDesc))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CleanupDesc);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, DDID);
			if (!string.IsNullOrEmpty(state))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, state);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(RecordStatus))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, RecordStatus);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null";
			}
			modGlobal.gv_sql = modGlobal.gv_sql + ") ";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command46 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command46.Connection.Open();
                command46.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command46.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		public static void UpdateSubmitCleanupCrit(string textline)
		{
			var i = 0;
			var StartPos = 2;
			string CriteriaDesc = "";
            string JoinOperator = "";
            string LookupTableID = "";
            string Operator_Renamed = "";
            string FIELDVALUE = "";
            string DDID = "";
            string SubmitCleanupID = "";
            string SubmitCleanupCritID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubmitCleanupCritID = SubmitCleanupCritID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SubmitCleanupID = SubmitCleanupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDVALUE = FIELDVALUE + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Operator_Renamed = Operator_Renamed + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaDesc = CriteriaDesc + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			CriteriaDesc = Strings.Replace(CriteriaDesc, "''", "\"");
			CriteriaDesc = modGlobal.ConvertApastroph( CriteriaDesc);

			//Add the record

			modGlobal.gv_sql = "Insert into tbl_setup_SubmitCleanupCrit (SubmitCleanupCritID, SubmitCleanupID, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID, FIELDVALUE, Operator, LookupTableID, JoinOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaDesc)";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, SubmitCleanupCritID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, SubmitCleanupID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, DDID);

			if (!string.IsNullOrEmpty(FIELDVALUE))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, FIELDVALUE);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(Operator_Renamed))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, Operator_Renamed);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(LookupTableID))
            {
				modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, LookupTableID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, JoinOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(CriteriaDesc))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}') ", modGlobal.gv_sql, CriteriaDesc);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null)";
			}
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command47 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command47.Connection.Open();
                command47.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command47.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		public static void UpdateSubmitCleanupRecord(string textline)
		{
			var i = 0;
			var StartPos = 2;
			string RecordStatus = "";
            string state = "";
            string CriteriaSet = "";
            string JoinOperator = "";
            string LookupID = "";
            string Value = "";
            string ValueOperator = "";
            string DDID = "";
            string CriteriaTitle = "";
            string SUBMITCLEANUPRECORDID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					SUBMITCLEANUPRECORDID = SUBMITCLEANUPRECORDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaTitle = CriteriaTitle + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValueOperator = ValueOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					Value = Value + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupID = LookupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaSet = CriteriaSet + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					state = state + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RecordStatus = RecordStatus + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_setup_SubmitCleanupRecord (SUBMITCLEANUPRECORDID, CriteriaTitle,  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " DDID, ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " [Value], LookupID, JoinOperator, criteriaset, State, RecordStatus) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, SUBMITCLEANUPRECORDID);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, CriteriaTitle);
			modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, DDID);
			modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, ValueOperator);
			modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, Value);
			modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, string.IsNullOrEmpty(LookupID) ? " Null" : LookupID);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, JoinOperator);
			modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, CriteriaSet);
			modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, string.IsNullOrEmpty(state) ? " Null" : string.Format("'{0}'", state));
			modGlobal.gv_sql = modGlobal.gv_sql + (string.IsNullOrEmpty(RecordStatus) ? " Null" : string.Format("'{0}'", RecordStatus));
			modGlobal.gv_sql = modGlobal.gv_sql + " )";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command48 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command48.Connection.Open();
                command48.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command48.Dispose();
                modGlobal.gv_cn.Close();
            }

        }

		private static void ImportIndicatorReportIncludes(string textline)
		{
			string InsertLine = "";
			InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());
			InsertLine = Strings.Replace(InsertLine, "''", "NULL");

			modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_IndicatorReportIncludes ON;Insert into tbl_Setup_IndicatorReportIncludes  (IncludeID, IndicatorID, SubGroupID, GroupRowID, SortOrder) VALUES  (  {0});SET IDENTITY_INSERT tbl_Setup_IndicatorReportIncludes OFF", InsertLine);

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command49 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command49.Connection.Open();
                command49.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command49.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		private static void ImportIndicatorReportDenominators(string textline)
		{
			string InsertLine = "";
			InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());
			InsertLine = Strings.Replace(InsertLine, "''", "NULL");

			modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_IndicatorReportDenominators ON;Insert into tbl_Setup_IndicatorReportDenominators  (DenomFieldID, SubGroupID, tName, OpChar, FieldID) VALUES  (  {0});SET IDENTITY_INSERT tbl_Setup_IndicatorReportDenominators OFF", InsertLine);

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command50 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command50.Connection.Open();
                command50.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command50.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		private static void UpdateSavedAdHocReportSumCriteria(string textline)
		{
			string InsertLine = null;
			InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());
			InsertLine = Strings.Replace(InsertLine, "''", "NULL");
			modGlobal.gv_sql = string.Format("Insert into tbl_Setup_SavedAdhocReportSumCriteria  (CriteriaID, Report_ID, CriteriaTitle, IndicatorID, Operator, MeasureID, JoinOperator, CriteriaSet) VALUES  (  {0} )", InsertLine);

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command51 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command51.Connection.Open();
                command51.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command51.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		private static void UpdateSubmitSubGroupCategory(string textline)
		{
			string InsertLine = null;

			InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());
			InsertLine = Strings.Replace(InsertLine, "''", "NULL");
			modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_SubmitSubGroupCategory ON;Insert into tbl_Setup_SubmitSubGroupCategory  (SubmitSubGroupCategoryID, SubgroupID, Measure_CATID) VALUES  (  {0} );SET IDENTITY_INSERT tbl_Setup_SubmitSubGroupCategory OFF", InsertLine);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command52 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command52.Connection.Open();
                command52.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command52.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		private static void UpdateMeasureCat(string textline)
		{
			string InsertLine = "";
			InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());
			InsertLine = Strings.Replace(InsertLine, "''", "NULL");
			modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Measure_Cat ON;Insert into tbl_Measure_Cat  (MEASURE_CATID, CAT, CAT_DESC, CAT_TYPE) VALUES  (  {0} );SET IDENTITY_INSERT tbl_Measure_Cat OFF;", InsertLine);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command53 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command53.Connection.Open();
                command53.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command53.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		private static void UpdateMeasureStep(string textline)
		{
			var i = 0;
			var StartPos = 2;
			string flowchartactionid = "";
            string isrisk = "";
            string GoToStep = "";
            string measure_catid = "";
            string measurestep = "";
            string MeasureID = "";
            string MeasureStepID = "";
			//insertline = Replace(TextLine, Chr(34), Chr(39))
			//insertline = Replace(insertline, "''", "NULL")

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					MeasureStepID = MeasureStepID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					MeasureID = MeasureID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					measurestep = measurestep + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

            //LDW short counter = 0;
            int counter = StartPos;
            for (i = counter; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					measure_catid = measure_catid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (string.IsNullOrEmpty(measure_catid))
				measure_catid = "NULL";

            //LDW short counter = 0;
            counter = 0;
            counter = StartPos;

            for (i = counter; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					GoToStep = GoToStep + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (string.IsNullOrEmpty(GoToStep))
            {
				GoToStep = "NULL";
			}

			counter = 0;
			counter = StartPos;

			for (i = counter; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					isrisk = isrisk + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

            //If isrisk = "" Then
            //    isrisk = "0"
            //End If

            //LDW isrisk = (isrisk == "False" ? 0 : (isrisk == "True" ? 1 : 0));
            isrisk = (isrisk == "False" ? 0.ToString() : (isrisk == "True" ? 1.ToString() : 0.ToString()));
            counter = 0;
			counter = StartPos;
			for (i = counter; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					flowchartactionid = flowchartactionid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (string.IsNullOrEmpty(flowchartactionid))
            {
				flowchartactionid = "NULL";
			}

			modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_MeasureStep ON;Insert into tbl_Setup_MeasureStep  (MeasureStepID, MeasureID, MeasureStep, Measure_CATID, GoToStep, IsRisk, FlowchartActionID) VALUES  (  {0}, {1}, {2},{3}, {4}, {5}, {6} );SET IDENTITY_INSERT tbl_Setup_MeasureStep OFF;", MeasureStepID, MeasureID, measurestep, measure_catid, GoToStep, isrisk, flowchartactionid);
            // Debug.Print gv_sql

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command54 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command54.Connection.Open();
                command54.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command54.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		private static void UpdateMeasureCriteriaSet(string textline)
		{
			string InsertLine = null;
            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());
            InsertLine = Strings.Replace(InsertLine, "''", "NULL");

			modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_MeasureCriteriaSet ON;Insert into tbl_Setup_MeasureCriteriaSet  (MeasureCriteriaSetID, MeasureCriteriaSet, MeasureStepID, JoinOperator) VALUES  (  {0} );SET IDENTITY_INSERT tbl_Setup_MeasureCriteriaSet OFF;", InsertLine);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command55 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command55.Connection.Open();
                command55.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command55.Dispose();
                modGlobal.gv_cn.Close();
            }
        }

		private static bool UpdateMeasureCriteria(string textline)
		{
			bool functionReturnValue = false;
			var i = 0;
			var StartPos = 2;
			string measurefieldgrouplogicid = "";
            string JoinOperator = "";
            string DateUnit = "";
            string FieldOperator = "";
            string LookupTableID = "";
            string LookupID = "";
            string FIELDVALUE = "";
            string ValueOperator = "";
            string DestDDID = "";
            string ddid2 = "";
            string DDID1 = "";
            string CriteriaTitle = "";
            string MeasureCriteriaSetID = "";
            string measureCriteriaID = "";
            string multselany = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					measureCriteriaID = measureCriteriaID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					MeasureCriteriaSetID = MeasureCriteriaSetID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaTitle = CriteriaTitle + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID1 = DDID1 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ddid2 = ddid2 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DestDDID = DestDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValueOperator = ValueOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDVALUE = FIELDVALUE + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupID = LookupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldOperator = FieldOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DateUnit = DateUnit + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					measurefieldgrouplogicid = measurefieldgrouplogicid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					multselany = multselany + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record


			modGlobal.gv_sql = "SET IDENTITY_INSERT tbl_Setup_MeasureCriteria ON;Insert into tbl_Setup_MeasureCriteria (MeasureCriteriaID, MeasureCriteriaSetID,  ";
			modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, DDID1, DDID2, DestDDID, ValueOperator, ";
			modGlobal.gv_sql = modGlobal.gv_sql + " [FieldValue], LookupID, LookupTableID, FieldOperator, DateUnit, JoinOperator, MeasureFieldGroupLogicID, MultSelAny) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, measureCriteriaID);
			modGlobal.gv_sql = string.Format("{0} {1},", modGlobal.gv_sql, MeasureCriteriaSetID);
			modGlobal.gv_sql = string.Format("{0} '{1}',", modGlobal.gv_sql, CriteriaTitle);
			if (!string.IsNullOrEmpty(DDID1))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, DDID1);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(ddid2))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, ddid2);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(DestDDID))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, DestDDID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(ValueOperator))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, ValueOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(FIELDVALUE))
            {
				modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, FIELDVALUE);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(LookupID))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(LookupTableID))
            {
				modGlobal.gv_sql = string.Format("{0}{1}, ", modGlobal.gv_sql, LookupTableID);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(FieldOperator))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, FieldOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(DateUnit))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}', ", modGlobal.gv_sql, DateUnit);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}
			if (!string.IsNullOrEmpty(JoinOperator))
            {
				modGlobal.gv_sql = string.Format("{0}'{1}',", modGlobal.gv_sql, JoinOperator);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null,";
			}

			if (!string.IsNullOrEmpty(measurefieldgrouplogicid))
            {
				modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, measurefieldgrouplogicid);
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null, ";
			}

			if (!string.IsNullOrEmpty(multselany))
            {
				modGlobal.gv_sql = modGlobal.gv_sql + multselany;
			}
            else
            {
				modGlobal.gv_sql = modGlobal.gv_sql + " Null ";
			}

			modGlobal.gv_sql = modGlobal.gv_sql + ");SET IDENTITY_INSERT tbl_Setup_MeasureCriteria OFF;";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command56 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command56.Connection.Open();
                command56.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command56.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}

		private static void UpdateMeasureStepGroup(string textline)
		{
			string InsertLine = null;
            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());
            InsertLine = Strings.Replace(InsertLine, "''", "NULL");

			modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_MeasureStepGroup ON;Insert into tbl_Setup_MeasureStepGroup  (MeasureStepGroupID, MeasureStepID, MeasureCriteriaSetID, MeasureStepGroup, JoinOperator) VALUES  (  {0} );SET IDENTITY_INSERT tbl_Setup_MeasureStepGroup OFF", InsertLine);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command57 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command57.Connection.Open();
                command57.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command57.Dispose();
                modGlobal.gv_cn.Close();
            }
        }



		private static bool UpdateFieldGroup(string textline)
		{
			bool functionReturnValue = false;
			var i = 0;
			var StartPos = 2;
			string FIELDGROUPNAME = "";
			string FIELDGroupID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDGroupID = FIELDGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDGROUPNAME = FIELDGROUPNAME + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record


			modGlobal.gv_sql = "SET IDENTITY_INSERT tbl_Setup_FieldGroup ON;Insert into tbl_Setup_FieldGroup (FieldGroupID, FieldGroupName) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, FIELDGroupID);
			modGlobal.gv_sql = string.Format("{0} '{1}' ", modGlobal.gv_sql, FIELDGROUPNAME);
			modGlobal.gv_sql = modGlobal.gv_sql + ");SET IDENTITY_INSERT tbl_Setup_FieldGroup OFF;";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command58 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command58.Connection.Open();
                command58.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command58.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}

		private static bool UpdateDDIDFieldGroup(string textline)
		{
			bool functionReturnValue = false;
			var i = 0;
			var StartPos = 2;
			string DDID = "";
			string FIELDGroupID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDGroupID = FIELDGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record

			modGlobal.gv_sql = "Insert into tbl_Setup_DDIDFieldGroup (FieldGroupID, DDID) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, FIELDGroupID);
			modGlobal.gv_sql = string.Format("{0} {1}", modGlobal.gv_sql, DDID);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command59 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command59.Connection.Open();
                command59.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command59.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}

		private static bool UpdateRelatedFieldGroup(string textline)
		{
			bool functionReturnValue = false;
			var i = 0;
			var StartPos = 2;
			string RelatedGroupName = "";
			string RelatedFieldGroupID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RelatedFieldGroupID = RelatedFieldGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RelatedGroupName = RelatedGroupName + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record

			modGlobal.gv_sql = "SET IDENTITY_INSERT tbl_Setup_RelatedFieldGroup ON;Insert into tbl_Setup_RelatedFieldGroup (RelatedFieldGroupID, RelatedGroupName) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, RelatedFieldGroupID);
			modGlobal.gv_sql = string.Format("{0} '{1}'", modGlobal.gv_sql, RelatedGroupName);
			modGlobal.gv_sql = modGlobal.gv_sql + ");SET IDENTITY_INSERT tbl_Setup_RelatedFieldGroup OFF;";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command60 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command60.Connection.Open();
                command60.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command60.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}

		private static bool UpdateDDIDRelatedFieldGroup(string textline)
		{
			bool functionReturnValue = false;
			var i = 0;
			var StartPos = 2;
			string RelatedFieldGroupID = "";
			string DDID = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DDID = DDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

            for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					RelatedFieldGroupID = RelatedFieldGroupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record

			modGlobal.gv_sql = "Insert into tbl_Setup_DDIDRelatedFieldGroup (RelatedFieldGroupID, DDID) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, RelatedFieldGroupID);
			modGlobal.gv_sql = string.Format("{0} {1}", modGlobal.gv_sql, DDID);
			modGlobal.gv_sql = modGlobal.gv_sql + ")";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command61 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command61.Connection.Open();
                command61.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command61.Dispose();
                modGlobal.gv_cn.Close();
            }


            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}

		private static bool UpdateMeasureFieldGroupLogic(string textline)
		{
			bool functionReturnValue = false;
			int i = 0;
			int StartPos = 2;
			string fieldvaluemax = "";
			string onlyproceedwithrelatedfieldgroup = "";
			string LookupTableID = "";
			string JoinOperator = "";
			string DateUnit = "";
			string FieldOperator = "";
			string LookupID = "";
			string destddidisgroup = "";
			string DestDDID = "";
			string FIELDVALUE = "";
			string ValueOperator = "";
			string fieldid2isgroup = "";
			string fieldid2 = "";
			string fieldid1isgroup = "";
			string fieldid1 = "";
			string CriteriaTitle = "";
			string measurefieldgrouplogicid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					measurefieldgrouplogicid = measurefieldgrouplogicid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					CriteriaTitle = CriteriaTitle + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldid1 = fieldid1 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(fieldid1)) == 0)
				fieldid1 = "Null";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldid1isgroup = fieldid1isgroup + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (fieldid1isgroup == "True")
            {
				fieldid1isgroup = "1";
			}
            else
            {
				fieldid1isgroup = "0";
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldid2 = fieldid2 + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(fieldid2)) == 0)
				fieldid2 = "Null";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldid2isgroup = fieldid2isgroup + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (fieldid2isgroup == "True")
            {
				fieldid2isgroup = "1";
			}
            else
            {
				fieldid2isgroup = "0";
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					ValueOperator = ValueOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(ValueOperator)) == 0)
            {
				ValueOperator = "Null";
			}
            else
            {
				ValueOperator = string.Format("'{0}'", ValueOperator);
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FIELDVALUE = FIELDVALUE + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(FIELDVALUE)) == 0)
            {
				FIELDVALUE = "Null";
			}
            else
            {
				FIELDVALUE = string.Format("'{0}'", FIELDVALUE);
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DestDDID = DestDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(DestDDID)) == 0)
				DestDDID = "Null";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					destddidisgroup = destddidisgroup + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (destddidisgroup == "True")
            {
				destddidisgroup = "1";
			}
            else
            {
				destddidisgroup = "0";
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupID = LookupID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(LookupID)) == 0)
				LookupID = "Null";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					FieldOperator = FieldOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(FieldOperator)) == 0)
            {
				FieldOperator = "Null";
			}
            else
            {
				FieldOperator = string.Format("'{0}'", FieldOperator);
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					DateUnit = DateUnit + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(DateUnit)) == 0)
            {
				DateUnit = "Null";
			}
            else
            {
				DateUnit = string.Format("'{0}'", DateUnit);
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					JoinOperator = JoinOperator + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			JoinOperator = string.Format("'{0}'", JoinOperator);

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					LookupTableID = LookupTableID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(LookupTableID)) == 0)
				LookupTableID = "Null";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					onlyproceedwithrelatedfieldgroup = onlyproceedwithrelatedfieldgroup + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (onlyproceedwithrelatedfieldgroup == "True")
            {
				onlyproceedwithrelatedfieldgroup = "1";
			}
            else
            {
				onlyproceedwithrelatedfieldgroup = "0";
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					fieldvaluemax = fieldvaluemax + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			if (Strings.Len(Strings.Trim(fieldvaluemax)) == 0)
            {
				fieldvaluemax = "NULL";
			}
            else
            {
				fieldvaluemax = string.Format("'{0}'", fieldvaluemax);
			}

			//Add the record

			modGlobal.gv_sql = "SET IDENTITY_INSERT tbl_Setup_MeasureFieldGroupLogic ON;Insert into tbl_Setup_MeasureFieldGroupLogic (MeasureFieldGroupLogicID, CriteriaTitle, " + " FieldID1, FieldID1IsGroup, FieldID2, FieldID2IsGroup, ValueOperator, FieldValue, DestDDID, " + " DestDDIDIsGroup,LookupID,FieldOperator, DateUnit, JoinOperator, LookupTableID, OnlyProceedWithRelatedFieldGroup, FieldValueMax) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},", modGlobal.gv_sql, measurefieldgrouplogicid);
			modGlobal.gv_sql = string.Format("{0} '{1}', ", modGlobal.gv_sql, CriteriaTitle);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, fieldid1);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, fieldid1isgroup);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, fieldid2);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, fieldid2isgroup);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, ValueOperator);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, FIELDVALUE);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, DestDDID);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, destddidisgroup);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, LookupID);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, FieldOperator);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, DateUnit);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, JoinOperator);
			modGlobal.gv_sql = string.Format("{0} {1}, ", modGlobal.gv_sql, LookupTableID);
			modGlobal.gv_sql = string.Format("{0} {1}, {2}", modGlobal.gv_sql, onlyproceedwithrelatedfieldgroup, fieldvaluemax);
			modGlobal.gv_sql = modGlobal.gv_sql + ");SET IDENTITY_INSERT tbl_Setup_MeasureFieldGroupLogic OFF;";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command62= new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command62.Connection.Open();
                command62.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command62.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}


		private static bool UpdateMeasureFlowchartAction(string textline)
		{
			bool functionReturnValue = false;
			var i = 0;
			var StartPos = 2;
			string actionDescription = "";
			string flowchartactionid = "";

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					flowchartactionid = flowchartactionid + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					actionDescription = actionDescription + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "SET IDENTITY_INSERT tbl_Setup_MeasureFlowchartAction ON;Insert into tbl_Setup_MeasureFlowchartAction (FlowchartActionID, ActionDescription) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},'{2}') ", modGlobal.gv_sql, flowchartactionid, actionDescription);
			modGlobal.gv_sql = modGlobal.gv_sql + ";SET IDENTITY_INSERT tbl_Setup_MeasureFlowchartAction OFF;";

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command62 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command62.Connection.Open();
                command62.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command62.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}

		private static bool UpdateIndicatorNumberOfCases(string textline)
		{
			bool functionReturnValue = false;
			string NumberOfCasesDDID = "";
			string IndicatorID = "";
			var i = 0;
			var StartPos = 2;

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					IndicatorID = IndicatorID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			for (i = StartPos; i <= Strings.Len(textline); i++)
            {
				if (Strings.Mid(textline, i, 1) != "\"")
                {
					NumberOfCasesDDID = NumberOfCasesDDID + Strings.Mid(textline, i, 1);
				}
                else
                {
					StartPos = i + 3;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			//Add the record
			modGlobal.gv_sql = "Insert into tbl_Setup_IndicatorNumberOfCases (IndicatorID, NumberOfCasesDDID) ";
			modGlobal.gv_sql = string.Format("{0} values ({1},{2}) ", modGlobal.gv_sql, IndicatorID, NumberOfCasesDDID);

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command63 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command63.Connection.Open();
                command63.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command63.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}


		private static bool ImportIndicatorICDPop(string textline)
		{
			bool functionReturnValue = false;
			string InsertLine = "";

            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

            modGlobal.gv_sql = string.Format("Insert into tbl_Setup_IndicatorICDPop  (IndicatorID, ICDPopDDID) VALUES  ({0})", InsertLine);

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command64 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command64.Connection.Open();
                command64.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command64.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}


		private static bool ImportMeasureSet(string textline)
		{
			bool functionReturnValue = false;
			string InsertLine = "";

            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

            modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_MeasureSet ON;Insert into tbl_Setup_MeasureSet  (MeasureSetID, MeasureSetDesc) VALUES  ({0});SET IDENTITY_INSERT tbl_Setup_MeasureSet OFF;", InsertLine);

            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command65 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command65.Connection.Open();
                command65.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command65.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}

		private static bool ImportMeasureSetMapMeas(string textline)
		{
			bool functionReturnValue = false;
			string InsertLine = "";

            //LDW InsertLine = Strings.Replace(textline, Strings.Chr(34), Strings.Chr(39));
            InsertLine = Strings.Replace(textline, Strings.Chr(34).ToString(), Strings.Chr(39).ToString());

            modGlobal.gv_sql = string.Format("SET IDENTITY_INSERT tbl_Setup_MeasureSetMapMeas ON;Insert into tbl_Setup_MeasureSetMapMeas  (MeasLinkID, IndicatorID, MeasureSetID) VALUES  ({0});SET IDENTITY_INSERT tbl_Setup_MeasureSetMapMeas OFF;", InsertLine);
            //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
            var command66 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
            try
            {
                command66.Connection.Open();
                command66.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening connection: " + ex.Message);
            }
            finally
            {
                command66.Dispose();
                modGlobal.gv_cn.Close();
            }

            functionReturnValue = true;
			return functionReturnValue;
			//LDW ErrHandler:

			//LDW modGlobal.CheckForErrors();
			functionReturnValue = false;
			return functionReturnValue;
		}
	}
}
