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
    internal partial class OldfrmSubmissionUpdateValidation : System.Windows.Forms.Form
    {

        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            if (cboIndicators.SelectedIndex < 0)
            {
                RadMessageBox.Show("Please select an indicator.");
                return;
            }
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                RadMessageBox.Show("Please define a validation message for the report.");
                return;
            }

            modGlobal.gv_sql = "Update tbl_setup_SubmitValidation ";
            modGlobal.gv_sql = modGlobal.gv_sql + " set IndicatorID = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(cboIndicators, cboIndicators.SelectedIndex) + ",";
            modGlobal.gv_sql = modGlobal.gv_sql + " Message = '" + modGlobal.ConvertApastroph(txtMessage.Text) + "',";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_sql = modGlobal.gv_sql + " ValType = '" + modGlobal.gv_Action + "' ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "ERROR")
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID  = " + frmSubmissionSetupCopy.rdcValidationErrors.Resultset.rdoColumns["SubmitValID"].Value;
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " Where SubmitValID  = " + frmSubmissionSetupCopy.rdcValidationWarnings.Resultset.rdoColumns["SubmitValID"].Value;
            }
            DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);


            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "Update";
            this.Close();

        }

        private void frmSubmissionUpdateValidation_Load(System.Object eventSender, System.EventArgs eventArgs)
        {
            int IndicatorListIndex;
            var i = 0;
            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

            //populate the indicator drop down box
            cboIndicators.Items.Clear();

            modGlobal.gv_sql = "select tbl_setup_Indicator.* ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_Indicator  ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " where (state = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_status. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " Where (state = '' or State is null or state = '" + modGlobal.gv_status + "')";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " order by Description ";
            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            i = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            //UPGRADE_WARNING: Couldn't resolve default property of object IndicatorListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            IndicatorListIndex = i;

            while (!modGlobal.gv_rs.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                i = i + 1;
                cboIndicators.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(modGlobal.gv_rs.rdoColumns["Description"].Value, modGlobal.gv_rs.rdoColumns["IndicatorID"].Value));
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                if (modGlobal.gv_Action == "ERROR")
                {
                    if (modGlobal.gv_rs.rdoColumns["IndicatorID"].Value == frmSubmissionSetupCopy.rdcValidationErrors.Resultset.rdoColumns["IndicatorID"].Value)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object IndicatorListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        IndicatorListIndex = i;
                    }
                    //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                }
                else if (modGlobal.gv_Action == "WARNING")
                {
                    if (modGlobal.gv_rs.rdoColumns["IndicatorID"].Value == frmSubmissionSetupCopy.rdcValidationWarnings.Resultset.rdoColumns["IndicatorID"].Value)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object IndicatorListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        IndicatorListIndex = i;
                    }
                }
                //LDW modGlobal.gv_rs.MoveNext();
            }

            //UPGRADE_WARNING: Couldn't resolve default property of object IndicatorListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cboIndicators.SelectedIndex = IndicatorListIndex;

            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (modGlobal.gv_Action == "ERROR")
            {
                txtMessage.Text = frmSubmissionSetupCopy.rdcValidationErrors.Resultset.rdoColumns["Message"].Value;
            }
            else
            {
                txtMessage.Text = frmSubmissionSetupCopy.rdcValidationWarnings.Resultset.rdoColumns["Message"].Value;
            }

        }
    }
}
