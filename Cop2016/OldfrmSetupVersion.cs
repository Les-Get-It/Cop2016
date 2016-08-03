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
    internal partial class OldfrmSetupVersion : System.Windows.Forms.Form
    {
        private void cmdDelete_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;

            if (rdcVersionHistory.Resultset.AbsolutePosition == 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp =RadMessageBox.Show("Are you sure you want to delete the log for this version?", MsgBoxStyle.YesNo, "Delete Log");
            if (resp == DialogResult.Yes)
            {
                modGlobal.gv_sql = "Delete tbl_setup_Version where versionid = " + rdcVersionHistory.Resultset.rdoColumns["versionid"].Value;
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                refreshVersionHistory();
            }
        }

        private void cmdEdit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            bool FoundIt;
            int thisversion;
            if (rdcVersionHistory.Resultset.AbsolutePosition == 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "";

           frmSetupVersionEditCopy.ShowDialog();

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "update")
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object thisversion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisversion = rdcVersionHistory.Resultset.rdoColumns["versionid"].Value;
                refreshVersionHistory();
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FoundIt = false;
                //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                while ((!rdcVersionHistory.Resultset.RowCount) & FoundIt == false)
                {
                    if (rdcVersionHistory.Resultset.rdoColumns["versionid"].Value == thisversion)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object FoundIt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        FoundIt = true;
                    }
                    else
                    {
                        rdcVersionHistory.Resultset.MoveNext();
                    }
                }
            }

        }

        private void cmdReset_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            DialogResult resp;
            //UPGRADE_WARNING: Couldn't resolve default property of object resp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            resp = RadMessageBox.Show("This feature will remove the version history from the system. Are you sure you want to continue?", MessageBoxButtons.YesNo, "Reset Version");
            if (resp == DialogResult.Yes)
            {
                modGlobal.gv_sql = "Delete tbl_setup_version ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                refreshVersionHistory();
            }

        }

        private void frmSetupVersion_Load(System.Object eventSender, System.EventArgs eventArgs)
        {

            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(My.MyProject.Forms.frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(My.MyProject.Forms.frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

            refreshVersionHistory();
        }

        public void refreshVersionHistory()
        {
            modGlobal.gv_sql = "Select  *  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_Version ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by VersionNumber desc ";

            rdcVersionHistory.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcVersionHistory.CtlRefresh();
            //resp = InputBox("", "", gv_sql) 'rdcPatientFields.Resultset.RowCount
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dbgVersionHistory.CtlRefresh();

        }
    }
}
