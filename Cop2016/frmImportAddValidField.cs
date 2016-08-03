using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static COP2001.RadDropBinder;

namespace COP2001
{
    public partial class frmImportAddValidField : RadForm
    {
        public string rdcImportValErrorTable = "tbl_setup_DataDef";
        public string rdcImportValWarningTable = "tbl_setup_DataDef";


        public frmImportAddValidField()
        {
            InitializeComponent();
            this.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = true;
            this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter;
            ThemeResolutionService.ApplicationThemeName = "Aqua";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmImportSetup frmImportSetupCopy = new frmImportSetup();
            int newmsgid;
            int thisimportfieldid;


            try
            {
                if (cboImportFields.SelectedIndex < 0 | string.IsNullOrEmpty(txtMessage.Text))
                {
                    RadMessageBox.Show("Field and Message are both required to complete this action.");
                    return;
                }

                modGlobal.gv_sql = "select importfieldid ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_ImportFields  ";
                modGlobal.gv_sql = string.Format("{0} where DDID = {1}", modGlobal.gv_sql,
                    Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex));
                modGlobal.gv_sql = string.Format("{0} and importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName1 = "tbl_setup_ImportFields";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName1, modGlobal.gv_rs);

                thisimportfieldid = Convert.ToInt32(modGlobal.gv_rs.Tables[sqlTableName1].Rows[0]["ImportFieldID"]);

                if (frmImportSetupCopy.txtAction.Text == "Add Error")
                {

                    newmsgid = modDBSetup.FindMaxRecID("tbl_setup_ImportValidationMessage", "MSGID");

                    modGlobal.gv_sql = "Insert into tbl_setup_ImportValidationMessage ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (importfieldid, MSGID, DDID, ValidationType, Message)";
                    modGlobal.gv_sql = string.Format("{0} values ({1},{2},", modGlobal.gv_sql, thisimportfieldid, newmsgid);
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} 'ERROR', '{1}')", modGlobal.gv_sql, modGlobal.ConvertApastroph(txtMessage.Text));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    this.Close();
                }
                else if (frmImportSetupCopy.txtAction.Text == "Edit Error")
                {
                    modGlobal.gv_sql = "update tbl_setup_ImportValidationMessage ";
                    modGlobal.gv_sql = string.Format("{0} set DDID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}, Message = '{1}", modGlobal.gv_sql, modGlobal.ConvertApastroph(txtMessage.Text)) + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " +
                        frmImportSetupCopy.rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    this.Close();
                }
                else if (frmImportSetupCopy.txtAction.Text == "Add Warning")
                {
                    newmsgid = modDBSetup.FindMaxRecID("tbl_setup_ImportValidationMessage", "MSGID");

                    modGlobal.gv_sql = "Insert into tbl_setup_ImportValidationMessage ";
                    modGlobal.gv_sql = modGlobal.gv_sql + " (importfieldid, MSGID, DDID, ValidationType, Message)";
                    modGlobal.gv_sql = string.Format("{0} values ({1},{2},", modGlobal.gv_sql, thisimportfieldid, newmsgid);
                    modGlobal.gv_sql = string.Format("{0}{1},", modGlobal.gv_sql, Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0} 'WARNING', '{1}')", modGlobal.gv_sql, modGlobal.ConvertApastroph(txtMessage.Text));
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    this.Close();
                }
                else if (frmImportSetupCopy.txtAction.Text == "Edit Warning")
                {
                    modGlobal.gv_sql = "update tbl_setup_ImportValidationMessage ";
                    modGlobal.gv_sql = string.Format("{0} set DDID = {1}", modGlobal.gv_sql,
                        Support.GetItemData(cboImportFields, cboImportFields.SelectedIndex));
                    modGlobal.gv_sql = string.Format("{0}, Message = '{1}", modGlobal.gv_sql, modGlobal.ConvertApastroph(txtMessage.Text)) + "'";
                    modGlobal.gv_sql = modGlobal.gv_sql + " where msgid = " + frmImportSetupCopy.rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["msgid"];
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                    this.Close();
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmImportAddValidField_Load(object sender, EventArgs e)
        {
            frmImportSetup frmImportSetupCopy = new frmImportSetup();
            int thisindex = 0;
            RadLabel dtText = new RadLabel();
            List<Item> itemscboImportFields = new List<Item>();


            try
            {
                cboImportFields.Items.Clear();

                modGlobal.gv_sql = "select tbl_setup_DataDef.* , tbl_setup_ImportFields.OrderNumber  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef, tbl_setup_ImportFields  ";
                modGlobal.gv_sql = modGlobal.gv_sql + " where tbl_setup_DataDef.DDID = tbl_setup_ImportFields.DDID ";
                modGlobal.gv_sql = string.Format("{0} and tbl_setup_ImportFields.importsetupid = {1}", modGlobal.gv_sql, modGlobal.gv_importsetupid);
                modGlobal.gv_sql = modGlobal.gv_sql + " order by tbl_setup_ImportFields.OrderNumber ";
                //LDW modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                const string sqlTableName2 = "tbl_setup_DataDef";
                modGlobal.gv_rs = DALcop.DalConnectDataSet(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql, sqlTableName2, modGlobal.gv_rs);

                //LDW while (!modGlobal.gv_rs.EOF)
                foreach (DataRow myRow1 in modGlobal.gv_rs.Tables[sqlTableName2].Rows)
                {
                    itemscboImportFields.Add(new Item(myRow1.Field<int>("DDID"), myRow1.Field<string>("FieldName")));

                    //cboImportFields.Items.Add(new ListBoxItem(myRow1.Field<string>("FieldName"),myRow1.Field<int>("DDID")).ToString());

                    if (frmImportSetupCopy.txtAction.Text == "Edit Error")
                    {
                        if (myRow1.Field<int>("DDID") == Convert.ToInt32(frmImportSetupCopy.rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["DDID"]))
                        {
                            cboImportFields.SelectedIndex = thisindex;
                        }
                    }
                    else if (frmImportSetupCopy.txtAction.Text == "Edit Warning")
                    {
                        if (myRow1.Field<int>("DDID") == Convert.ToInt32(frmImportSetupCopy.rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["DDID"]))
                        {
                            cboImportFields.SelectedIndex = thisindex;
                        }
                    }
                    thisindex = thisindex + 1;
                    //LDW modGlobal.gv_rs.MoveNext();
                }
                this.cboImportFields.DataSource = itemscboImportFields;
                this.cboImportFields.DisplayMember = "Description";
                this.cboImportFields.ValueMember = "Id";


                if (frmImportSetupCopy.txtAction.Text == "Add Error")
                {
                }
                else if (frmImportSetupCopy.txtAction.Text == "Edit Error")
                {
                    txtMessage.Text = frmImportSetupCopy.rdcImportValError.Tables[rdcImportValErrorTable].Rows[0]["Message"].ToString();
                    //gv_sql = "Select Message from tbl_setup_ImportValidationMessage  "
                    //gv_sql = gv_sql & " where msgID = " & frmImportSetupCopy.rdcImportValError.Resultset!msgid
                    //Set dtText.Recordset = gv_cn.OpenResultset(gv_sql, dbOpenSnapshot)
                    //txtMessage = dtText.Recordset!Message
                }
                else if (frmImportSetupCopy.txtAction.Text == "Add Warning")
                {
                }
                else if (frmImportSetupCopy.txtAction.Text == "Edit Warning")
                {
                    txtMessage.Text = frmImportSetupCopy.rdcImportValWarning.Tables[rdcImportValWarningTable].Rows[0]["Message"].ToString();
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
    }
}
