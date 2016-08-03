using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;

namespace COP2001
{
    public partial class dlgImportLookupValues : Telerik.WinControls.UI.RadForm
    {
        public dlgImportLookupValues()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private int il_BaseTableID;
        public void SetBaseTableID(int basetableid)
        {
            try
            {

                il_BaseTableID = basetableid;
                modGlobal.gv_sql = "SELECT BaseTable from tbl_Setup_tableDef WHERE BaseTableid = " + il_BaseTableID;
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_Setup_tableDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
                //LDW if (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    //LDW this.Text = "Import Lookup Values into " + modGlobal.gv_rs.rdoColumns["BaseTable"].Value;
                    this.Text = "Import Lookup Values into " + myRow1.Field<string>("BaseTable");
                }
                //LDW modGlobal.gv_rs.Close();
                modGlobal.gv_rs.Dispose();
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string ls_Filename = null;
            Scripting.TextStream file = null;
            //Dim fileSystem As New scripting.FileSystemObject
            int ll_cnt = 1;
            string ls_line = null;
            int ll_SortOrder = 0;

            try
            {


                if (!optID.IsChecked & !OptValue.IsChecked)
                {
                    //LDW RadMessageBox.Show("Please Choose the First Field in the Lookup File", MsgBoxStyle.Information);

                    DialogResult ds1 = RadMessageBox.Show(this, "Please Choose the First Field in the Lookup File",
                        "Import Lookup Values", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds1.ToString();
                    return;
                }

                if (!OptDelete.IsChecked & !OptInsert.IsChecked)
                {
                    //LDW RadMessageBox.Show("Please Choose whether to delete all the old values or just add the values", MsgBoxStyle.Information);

                    DialogResult ds2 = RadMessageBox.Show(this, "Please Choose whether to delete all the old values or just add the values",
                        "Import Lookup Values", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds2.ToString();
                    return;
                }

                //LDW My.MyProject.Forms.frmFindAFile.Text = "Specify the source file";
                //LDW My.MyProject.Forms.frmFindAFile.ShowDialog();
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Specify the source file";
                openFileDialog.DefaultExt = "txt";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.ShowDialog();



                if (string.IsNullOrEmpty(modGlobal.gv_SelectedFileName))
                {
                    //strError = "Sorry, you must locate the sample file to run the process."
                    //LDW RadMessageBox.Show("Import Will Not Continue Because the Import File Was Not Located Correctly.");

                    DialogResult ds3 = RadMessageBox.Show(this, "Import Will Not Continue Because the Import File Was Not Located Correctly.",
                        "Import Lookup Values", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.Text = ds3.ToString();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else
                {
                    ls_Filename = string.Format("{0}\\{1}", modGlobal.gv_SelectedDirectory, modGlobal.gv_SelectedFileName);
                }

                if (OptDelete.IsChecked)
                {
                    modGlobal.gv_sql = "DELETE FROM tbl_Setup_MiscLookupList WHERE BaseTableID = " + il_BaseTableID;
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                }
                // 8/4/2015 - SR removed filesystem.scripting component with input load. old method apparently does not work on win 8 machines
                //    Set file = fileSystem.OpenTextFile(ls_Filename, _
                //'          scripting.IOMode.ForReading, False, _
                //'          scripting.Tristate.TristateUseDefault)
                //LDW short FileNum = 0;
                int FileNum = FileSystem.FreeFile();

                //LDW FileNum = FreeFile();
                FileSystem.FileOpen(FileNum, ls_Filename, OpenMode.Input);
                //minimize the time the file is open, read one line at a time
                //Do While Not file.AtEndOfStream
                while (!FileSystem.EOF(FileNum))
                {
                    ls_line = FileSystem.LineInput(FileNum);
                    //ls_line = Trim(file.ReadLine())
                    if (Strings.Len(ls_line) > 0 & ls_line != ",")
                    {
                        if (Strings.InStr(1, ls_line, ",") > 0)
                        {
                            ls_line = Strings.Trim(Strings.Left(ls_line, Strings.InStr(1, ls_line, ",") - 1));
                        }

                        if (OptDelete.IsChecked)
                        {
                            ll_SortOrder = ll_cnt;
                        }
                        else
                        {
                            //LDW ll_SortOrder = modGlobal.GetMaxValue(ref "tbl_Setup_MiscLookupList", ref "SortOrder", ref "LookupID is not null and BaseTableID = " + il_BaseTableID) + 1;
                            const string ref1 = "tbl_Setup_MiscLookupList";
                            const string ref2 = "SortOrder";
                            string ref3 = "LookupID is not null and BaseTableID = " + il_BaseTableID;
                            ll_SortOrder = modGlobal.GetMaxValue(ref1, ref2, ref3) + 1;
                        }

                        //LDW  if (chkStripDecimal.CheckState)
                        if (Convert.ToBoolean(chkStripDecimal.CheckState))
                        {
                            ls_line = Strings.Replace(ls_line, ".", "");
                        }

                        if (OptValue.IsChecked)
                        {
                            //LDW modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" + modGlobal.GetMaxValue(ref "tbl_Setup_MiscLookupList", ref "LookupID", ref "LookupID is not null") + 1 + "," + il_BaseTableID + ",'" + ls_line + "','M'," + ll_SortOrder + ")";
                            const string ref1 = "tbl_Setup_MiscLookupList";
                            const string ref2 = "LookupID";
                            const string ref3 = "LookupID is not null";
                            modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" +
                                modGlobal.GetMaxValue(ref1, ref2, ref3) + 1 + "," + il_BaseTableID + ",'" + ls_line + "','M'," + ll_SortOrder + ")";
                        }
                        else
                        {
                            //LDW modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" + modGlobal.GetMaxValue(ref "tbl_Setup_MiscLookupList", ref "LookupID", ref "LookupID is not NULL") + 1 + "," + il_BaseTableID + ",'M','" + ls_line + "'," + ll_SortOrder + ")";
                            const string ref1 = "tbl_Setup_MiscLookupList";
                            const string ref2 = "LookupID";
                            const string ref3 = "LookupID is not null";
                            modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" +
                                modGlobal.GetMaxValue(ref1, ref2, ref3) + 1 + "," + il_BaseTableID + ",'M','" + ls_line + "'," + ll_SortOrder + ")";
                        }
                        //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    }
                    ll_cnt = ll_cnt + 1;
                }
                FileSystem.FileClose(FileNum);
                //file.Close

                //LDW RadMessageBox.Show(ll_cnt - 1 + " values were successfully imported.", MsgBoxStyle.Information);

                DialogResult ds4 = RadMessageBox.Show(this, ll_cnt - 1 + " values were successfully imported.",
                    "Import Lookup Values", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.Text = ds4.ToString();

                this.Close();
                return;
                ////LDW ErrHandler:
                //LDW modGlobal.CheckForErrors();
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
