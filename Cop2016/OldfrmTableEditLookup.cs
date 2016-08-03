using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmTableEditLookup : System.Windows.Forms.Form
    {
        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string gv_Command = null;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (string.IsNullOrEmpty(txtID.Text) | Information.IsDBNull(txtID.Text))
            {
               RadMessageBox.Show("ID cannot be blank");
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gv_Command = "Update tbl_Setup_miscLookupList set ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gv_Command = gv_Command + " ID = '" + txtID.Text + "',";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gv_Command = gv_Command + " FieldValue = '" + txtLookupValue.Text + "'";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gv_Command = gv_Command + " Where lookupid = " +frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["LookupID"];
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Command. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, gv_Command);
            

            modGlobal.gv_sql = " update tbl_setup_savedadhocreportcriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " +frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["LookupID"];
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = " update tbl_setup_submitcleanuprecord ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " +frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["LookupID"];
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = " update tbl_setup_submitcriteria ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " +frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["LookupID"];
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            modGlobal.gv_sql = " update tbl_setup_tablevalidation ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set [value] = '" + txtID.Text + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where lookupid = " +frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["LookupID"];
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            this.Close();

        }

        private void frmTableEditLookup_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

            if (frmLookupSetupCopy.rdcLookupList.Resultset.RowCount > 0)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["Id"]))
                {
                    txtID.Text =frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["Id"];
                }

                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["FIELDVALUE"]))
                {
                    txtLookupValue.Text =frmLookupSetupCopy.rdcLookupList.Tables[rdcLookupListTable].Columns["FIELDVALUE"];
                }
            }

        }
    }
}
