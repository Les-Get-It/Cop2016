using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using System.Drawing;
using static COP2001.RadDropBinder;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Diagnostics;

namespace COP2001
{
    public partial class frmImportCopyValidation : Telerik.WinControls.UI.RadForm
    {
        public frmImportCopyValidation()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            SqlCommand ps = new SqlCommand();
            DataSet thisim = new DataSet();
            DataSet thisimv = new DataSet();

            try
            {
                if (lstImportLayout.SelectedIndex < 0)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                //    gv_sql = " select ifd.importfieldid as destimportfieldid, ivm.* "
                //    gv_sql = gv_sql & " from "
                //    gv_sql = gv_sql & " (tbl_setup_Importfields as ifs "
                //    gv_sql = gv_sql & " inner join tbl_Setup_importvalidationmessage as ivm "
                //    gv_sql = gv_sql & " on ifs.importfieldid = ivm.importfieldid) "
                //    gv_sql = gv_sql & " inner join tbl_setup_Importfields as ifd "
                //    gv_sql = gv_sql & " on ifs.ddid = ifd.ddid "
                //    gv_sql = gv_sql & " where ifd.importsetupid = " & gv_importsetupid
                //    gv_sql = gv_sql & " and ifs.importsetupid = " & lstImportLayout.ItemData(lstImportLayout.ListIndex)
                //
                //    Set thisim = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //
                //    While Not thisim.EOF
                //        msgid = FindMaxRecID("tbl_Setup_importvalidationmessage", "msgid")
                //
                //        gv_sql = "insert into tbl_setup_ImportvalidationMessage "
                //        gv_sql = gv_sql & " (MSGID, "
                //        gv_sql = gv_sql & " Message, "
                //        gv_sql = gv_sql & " DDID, "
                //        gv_sql = gv_sql & " ImportFieldid, "
                //        gv_sql = gv_sql & " ValidationCount, "
                //        gv_sql = gv_sql & " ValidationType, "
                //        gv_sql = gv_sql & " Joinoperator) "
                //        gv_sql = gv_sql & " values( "
                //        gv_sql = gv_sql & " " & msgid & ", "
                //        gv_sql = gv_sql & " '" & thisim!Message & "', "
                //        gv_sql = gv_sql & " " & thisim!DDID & ", "
                //        gv_sql = gv_sql & " " & thisim!destimportfieldid & ", "
                //        If IsNull(thisim!ValidationCount) Then
                //            gv_sql = gv_sql & " Null, "
                //        Else
                //            gv_sql = gv_sql & " " & thisim!ValidationCount & ", "
                //        End If
                //        gv_sql = gv_sql & " '" & thisim!ValidationType & "', "
                //        If IsNull(thisim!JoinOperator) Then
                //            gv_sql = gv_sql & " Null "
                //        Else
                //            gv_sql = gv_sql & " '" & thisim!JoinOperator & "' "
                //        End If
                //        gv_sql = gv_sql & ") "
                //        gv_cn.Execute gv_sql
                //
                //        gv_sql = " select iv.* "
                //        gv_sql = gv_sql & " from "
                //        gv_sql = gv_sql & " (tbl_setup_Importfields as ifs "
                //        gv_sql = gv_sql & " inner join tbl_setup_importvalidationmessage as ivm "
                //        gv_sql = gv_sql & " on ifs.importfieldid = ivm.importfieldid) "
                //        gv_sql = gv_sql & " inner join tbl_setup_Importvalidation as iv "
                //        gv_sql = gv_sql & " on iv.msgid = ivm.msgid "
                //        gv_sql = gv_sql & " where "
                //        gv_sql = gv_sql & " iv.msgid = " & thisim!msgid
                //
                //        Set thisimv = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
                //
                //
                //        While Not thisimv.EOF
                //            newid = FindMaxRecID("tbl_Setup_importvalidation", "validid")
                //
                //            gv_sql = "insert into tbl_setup_Importvalidation "
                //            gv_sql = gv_sql & " (Validid, "
                //            gv_sql = gv_sql & " Msgid,"
                //            gv_sql = gv_sql & " ddid,"
                //            gv_sql = gv_sql & " validationtitle,"
                //            gv_sql = gv_sql & " lookuptableid,"
                //            gv_sql = gv_sql & " fieldtypeval,"
                //            gv_sql = gv_sql & " operator,"
                //            gv_sql = gv_sql & " fieldvalue,"
                //            gv_sql = gv_sql & " fieldtype)"
                //            gv_sql = gv_sql & " values ("
                //            gv_sql = gv_sql & " " & newid & ", "
                //            gv_sql = gv_sql & " " & msgid & ","
                //            gv_sql = gv_sql & " " & thisimv!DDID & ","
                //            gv_sql = gv_sql & " '" & thisimv!ValidationTitle & "',"
                //            If IsNull(thisimv!LookupTableID) Then
                //                gv_sql = gv_sql & " Null, "
                //            Else
                //                gv_sql = gv_sql & " " & thisimv!LookupTableID & ","
                //            End If
                //            If IsNull(thisimv!FieldTypeVal) Then
                //                gv_sql = gv_sql & " Null, "
                //            Else
                //                gv_sql = gv_sql & " '" & thisimv!FieldTypeVal & "',"
                //            End If
                //            If IsNull(thisimv!Operator) Then
                //                gv_sql = gv_sql & " Null, "
                //            Else
                //                gv_sql = gv_sql & " '" & thisimv!Operator & "',"
                //            End If
                //            If IsNull(thisimv!FIELDVALUE) Then
                //                gv_sql = gv_sql & " Null, "
                //            Else
                //                gv_sql = gv_sql & " '" & thisimv!FIELDVALUE & "',"
                //            End If
                //            If IsNull(thisimv!FieldType) Then
                //                gv_sql = gv_sql & " Null "
                //            Else
                //                gv_sql = gv_sql & " '" & thisimv!FieldType & "'"
                //            End If
                //            gv_sql = gv_sql & " )"
                //
                //            gv_cn.Execute gv_sql
                //            thisimv.MoveNext
                //        Wend
                //        thisimv.Close
                //
                //        thisim.MoveNext
                //    Wend
                //    thisim.Close

                /*LDW modGlobal.gv_sql = "{ ? = call CopyImportValidation(?,?) }";
                ps = modGlobal.gv_cn.CreatePreparedStatement("", modGlobal.gv_sql);
                ps(0).Direction = RDO.DirectionConstants.rdParamReturnValue;
                ps(1).Direction = RDO.DirectionConstants.rdParamInput;
                ps(2).Direction = RDO.DirectionConstants.rdParamInput;
                ps.rdoParameters(1) = Support.GetItemData(lstImportLayout, lstImportLayout.SelectedIndex);
                // to
                ps.rdoParameters(2) = modGlobal.gv_importsetupid;
                //from
                ps.Execute();
                ps.Close();*/

                ps.Connection = modGlobal.gv_cn;
                ps.CommandType = CommandType.StoredProcedure;
                ps.CommandText = "CopyImportValidation";
                var inParam1 = new SqlParameter("@TOImportSetupID", Support.GetItemData(lstImportLayout, lstImportLayout.SelectedIndex));
                inParam1.Direction = ParameterDirection.Input;
                inParam1.DbType = DbType.Int32;
                ps.Parameters.Add(inParam1);
                var inParam2 = new SqlParameter("@FROMImportSetupID", modGlobal.gv_importsetupid);
                inParam2.Direction = ParameterDirection.Input;
                inParam2.DbType = DbType.Int32;
                ps.Parameters.Add(inParam2);
                SqlParameter retParam1 = ps.Parameters.Add("return_value", SqlDbType.Int);
                retParam1.Direction = ParameterDirection.ReturnValue;
                try
                {
                    ps.Connection.Open();
                    ps.ExecuteNonQuery();
                }
                catch (Exception exx)
                {
                    RadMessageBox.Show("Error while opening connection: " + exx.Message);
                }
                finally
                {
                    ps.Dispose();
                }

                Cursor.Current = Cursors.Default;

                this.Close();
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

        private void frmImportCopyValidation_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            try
            {
                RefreshImportLayouts();
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

        public void RefreshImportLayouts()
        {
            List<Item> itemslstImportLayout = new List<Item>();

            try
            {
                modGlobal.gv_sql = "select * from tbl_setup_ImportSetup ";
                modGlobal.gv_sql = string.Format("{0} where importsetupid <> {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by methodnumber ";

                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_ImportSetup";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                lstImportLayout.Items.Clear();
                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName1].Rows)
                {
                    itemslstImportLayout.Add(new Item(myRow1.Field<int>("ImportSetupID"), myRow1.Field<string>("Description")));

                    //lstImportLayout.Items.Add(new ListBoxItem(myRow1.Field<string>("Description"), myRow1.Field<int>("ImportSetupID")).ToString());
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.lstImportLayout.DataSource = itemslstImportLayout;
                this.lstImportLayout.DisplayMember = "Description";
                this.lstImportLayout.ValueMember = "Id";
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
