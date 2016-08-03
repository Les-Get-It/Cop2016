using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace COP2001
{
	internal partial class OlddlgImportLookupValues : Form
	{
        const string sqlTableName1 = "tbl_Setup_tableDef";
		private int il_BaseTableID;
		public void SetBaseTableID(ref int basetableid)
		{
            var dalAccess = new DALcop();
            il_BaseTableID = basetableid;
			modGlobal.gv_sql = "SELECT BaseTable from tbl_Setup_tableDef WHERE BaseTableid = " + il_BaseTableID;
            //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            modGlobal.gv_rs = dalAccess.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);
			//LDW if (!modGlobal.gv_rs.EOF)
            foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
            {
                //LDW this.Text = "Import Lookup Values into " + modGlobal.gv_rs.rdoColumns["BaseTable"].Value;
                this.Text = "Import Lookup Values into " + myRow1.Field<string>("BaseTable");
            }
            //LDW modGlobal.gv_rs.Close();
            modGlobal.gv_rs.Dispose();
		}

        private void CancelButton_Renamed_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void OKButton_Click(Object eventSender, EventArgs eventArgs)
        {
            string ls_Filename = null;
            Scripting.TextStream file = null;
            //Dim fileSystem As New scripting.FileSystemObject
            int ll_cnt = 1;
            string ls_line = null;
            int ll_SortOrder = 0;


            if (!optID.Checked & !OptValue.Checked)
            {
                Interaction.MsgBox("Please Choose the First Field in the Lookup File", MsgBoxStyle.Information);
                return;
            }

            if (!OptDelete.Checked & !OptInsert.Checked)
            {
                Interaction.MsgBox("Please Choose whether to delete all the old values or just add the values", MsgBoxStyle.Information);
                return;
            }

            //LDW My.MyProject.Forms.frmFindAFile.Text = "Specify the source file";
            //LDW My.MyProject.Forms.frmFindAFile.ShowDialog();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Specify the source file";
            openFileDialog.ShowDialog();

            if (string.IsNullOrEmpty(modGlobal.gv_SelectedFileName))
            {
                //strError = "Sorry, you must locate the sample file to run the process."
                Interaction.MsgBox("Import Will Not Continue Because the Import File Was Not Located Correctly.");
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                return;
            }
            else
            {
                ls_Filename = string.Format("{0}\\{1}", modGlobal.gv_SelectedDirectory, modGlobal.gv_SelectedFileName);
            }

            if (OptDelete.Checked)
            {
                modGlobal.gv_sql = "DELETE FROM tbl_Setup_MiscLookupList WHERE BaseTableID = " + il_BaseTableID;
                //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                var command1 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
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

                    if (OptDelete.Checked)
                    {
                        ll_SortOrder = ll_cnt;
                    }
                    else
                    {
                        //LDW ll_SortOrder = modGlobal.GetMaxValue(ref "tbl_Setup_MiscLookupList", ref "SortOrder", ref "LookupID is not null and BaseTableID = " + il_BaseTableID) + 1;
                        string ref1 = "tbl_Setup_MiscLookupList";
                        string ref2 = "SortOrder";
                        string ref3 = "LookupID is not null and BaseTableID = " + il_BaseTableID;
                        ll_SortOrder = modGlobal.GetMaxValue(ref ref1, ref ref2, ref ref3) + 1;
                    }

                    //LDW  if (chkStripDecimal.CheckState)
                    if (Convert.ToBoolean(chkStripDecimal.CheckState))
                    {
                        ls_line = Strings.Replace(ls_line, ".", "");
                    }

                    if (OptValue.Checked)
                    {
                        //LDW modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" + modGlobal.GetMaxValue(ref "tbl_Setup_MiscLookupList", ref "LookupID", ref "LookupID is not null") + 1 + "," + il_BaseTableID + ",'" + ls_line + "','M'," + ll_SortOrder + ")";
                        string ref1 = "tbl_Setup_MiscLookupList";
                        string ref2 = "LookupID";
                        string ref3 = "LookupID is not null";
                        modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" + modGlobal.GetMaxValue(ref ref1, ref ref2, ref ref3) + 1 + "," + il_BaseTableID + ",'" + ls_line + "','M'," + ll_SortOrder + ")";
                    }
                    else
                    {
                        //LDW modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" + modGlobal.GetMaxValue(ref "tbl_Setup_MiscLookupList", ref "LookupID", ref "LookupID is not NULL") + 1 + "," + il_BaseTableID + ",'M','" + ls_line + "'," + ll_SortOrder + ")";
                        string ref1 = "tbl_Setup_MiscLookupList";
                        string ref2 = "LookupID";
                        string ref3 = "LookupID is not null";
                        modGlobal.gv_sql = "INSERT INTO tbl_Setup_MiscLookupList (LookupID, BaseTableID, FieldValue, ID, SortOrder) " + " VALUES (" + modGlobal.GetMaxValue(ref ref1, ref ref2, ref ref3) + 1 + "," + il_BaseTableID + ",'M','" + ls_line + "'," + ll_SortOrder + ")";
                    }
                    //LDW modGlobal.gv_cn.Execute(modGlobal.gv_sql);
                    var command2 = new SqlCommand(modGlobal.gv_sql, modGlobal.gv_cn);
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
                }
                ll_cnt = ll_cnt + 1;
            }
            FileSystem.FileClose(FileNum);
            //file.Close

            Interaction.MsgBox(ll_cnt - 1 + " values were successfully imported.", MsgBoxStyle.Information);
            this.Close();
            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }
    }
}
