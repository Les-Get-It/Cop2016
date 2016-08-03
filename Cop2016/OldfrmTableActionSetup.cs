using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmTableActionSetup : System.Windows.Forms.Form
    {

        private void cmdAddAction_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            int NextID = modDBSetup.FindMaxRecID("tbl_setup_datadefactions", "datadefactionid");
            if (lstAvailableActions.SelectedIndex < 0)
            {
                return;
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object NextID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            modGlobal.gv_sql = "insert into tbl_setup_datadefactions (datadefactionid, dataentryactionid, ddid) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " values ( ";
            //UPGRADE_WARNING: Couldn't resolve default property of object NextID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + NextID + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstAvailableActions, lstAvailableActions.SelectedIndex) + ", ";
            modGlobal.gv_sql = modGlobal.gv_sql + frmTableSetupCopy.rdcFieldList.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " )";

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
            

            RefreshAvailableActions();
            RefreshAppliedActions();

        }

        private void cmdClose_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdRemoveAction_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (lstAppliedActions.SelectedIndex < 0)
            {
                return;
            }

            modGlobal.gv_sql = "Delete tbl_setup_datadefactions  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where datadefactionid = ";
            modGlobal.gv_sql = modGlobal.gv_sql + Support.GetItemData(lstAppliedActions, lstAppliedActions.SelectedIndex);

            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            RefreshAvailableActions();
            RefreshAppliedActions();

        }

        private void frmTableActionSetup_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Left = Support.TwipsToPixelsX((Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Support.TwipsToPixelsY((Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Support.PixelsToTwipsY(this.Height) / 2));
            RefreshAvailableActions();
            RefreshAppliedActions();
            lblFieldName.Text = frmTableSetupCopy.rdcFieldList.Resultset.rdoColumns["FieldName"].Value;

        }

        public void RefreshAvailableActions()
        {

            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " tbl_setup_Dataentryactions ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where dataentryactionid not in ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (Select dataentryactionid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Datadefactions  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + frmTableSetupCopy.rdcFieldList.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " )";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            lstAvailableActions.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstAvailableActions.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["ActionDesc"].Value, modGlobal.gv_rs.rdoColumns["Dataentryactionid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }

        public void RefreshAppliedActions()
        {

            modGlobal.gv_sql = "Select dda.*, dea.actiondesc ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Datadefactions as dda  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_Dataentryactions as dea  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on dea.Dataentryactionid = dda.Dataentryactionid  ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where dda.ddid = " + frmTableSetupCopy.rdcFieldList.Resultset.rdoColumns["DDID"].Value;

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            lstAppliedActions.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                lstAppliedActions.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["ActionDesc"].Value, modGlobal.gv_rs.rdoColumns["Datadefactionid"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }
            modGlobal.gv_rs.Dispose();

        }
    }
}
