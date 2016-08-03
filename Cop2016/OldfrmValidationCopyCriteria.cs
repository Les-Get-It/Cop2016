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
    internal partial class OldfrmValidationCopyCriteria : System.Windows.Forms.Form
    {
        private short ii_TableValidationID;

        public void SetTableValidationMessageID()
        {
            object ii_TableValidationMessageID = null;
            //UPGRADE_WARNING: Couldn't resolve default property of object ii_TableValidationMessageID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ii_TableValidationMessageID = frmTableValidationSetupCopy.rdcValidationErrors.Resultset.rdoColumns["TableValidationMessageID"].Value;
        }

        private void frmValidationCopyCriteria_Load(System.Object eventSender, System.EventArgs eventArgs)
        {

            this.Left = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsX((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(frmMasterForm.Width) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsX(this.Width) / 2));
            this.Top = Microsoft.VisualBasic.Compatibility.VB6.Support.TwipsToPixelsY((Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(frmMasterForm.Height) / 2) - (Microsoft.VisualBasic.Compatibility.VB6.Support.PixelsToTwipsY(this.Height) / 2));

            SetTableValidationMessageID();

            //If frmTableValidationSetupCopy.rdcValidationErrors.Resultset!MessageType = "ERROR" Then
            RefreshErrorList();
            //Else
            RefreshWarningList();

            lblCopyFrom.Text = frmTableValidationSetupCopy.rdcValidationErrors.Resultset.rdoColumns["Message"].Value;

        }


        private void cmdCancel_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            this.Close();
        }


        private void CopyFromMeasureToMeasure()
        {
            int is_MeasureID ;
            object CopyStepandSetRecords = null;
            object cboMeasures = null;
            object cboSet = null;
            object cboStep = null;
            object is_MeasureCriteriaIDs = null;
            object cboJoinOperator = null;
            object InsertStepandSetRecords = null;
            int li_SetID = 0;

            //On Error GoTo ErrHandler

            if (string.IsNullOrEmpty(is_MeasureID))
            {

                if (cboStep.ListIndex < 0 | cboSet.ListIndex < 0 | cboMeasures.ListIndex < 0 | (cboJoinOperator.ListIndex < 0 & string.IsNullOrEmpty(cboJoinOperator.Text)))
                {
                    RadMessageBox.Show("Define the definition of the new criteria.");
                }
                else
                {
                    //copy the criteria
                    li_SetID = InsertStepandSetRecords;

                    if (li_SetID != -1)
                    {
                        modGlobal.gv_sql = " insert into tbl_Setup_MeasureCriteria (";
                        modGlobal.gv_sql = modGlobal.gv_sql + " MeasureCriteriaSetID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " JoinOperator, MeasureFieldGroupLogicID, MultSelAny ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ) ";

                        modGlobal.gv_sql = modGlobal.gv_sql + " select ";
                        modGlobal.gv_sql = modGlobal.gv_sql + li_SetID + ", ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " CriteriaTitle, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID1, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DDID2, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " ValueOperator, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " FieldValue, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " LookupTableID, ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " DateUnit, ";

                        modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboJoinOperator.Text + "', MeasureFieldGroupLogicID, MultSelAny ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_Setup_MeasureCriteria ";
                        modGlobal.gv_sql = modGlobal.gv_sql + " where MeasureCriteriaID in (" + Strings.Join(is_MeasureCriteriaIDs, ", ") + ")";

                        DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);
                        

                        this.Close();
                    }
                }
            }
            else
            {
                modGlobal.gv_sql = "SELECT * FROM tbl_Setup_MeasureStep WHERE  " + " MeasureID = " + cboMeasures.ItemData(cboMeasures.ListIndex);
                modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (modGlobal.gv_rs.RowCount > 0)
                {
                    RadMessageBox.Show("Cannot duplicate! The destination measure has some criteria in the flowchart that has to be removed first.");
                }
                else
                {
                    if (CopyStepandSetRecords)
                        this.Close();
                }
            }

            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }

        private void RefreshWarningList()
        {
            //retrieve the list of Validation Warning messages
            modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex);
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and state = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'WARNING' ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
            //3.17.2005 = order by message


            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboError.Items.Clear();

            while (!modGlobal.gv_rs.EOF)
            {
                cboError.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem((modGlobal.gv_rs.rdoColumns["Message"]).Value, modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();
        }

        private void RefreshErrorList()
        {


            //retrieve the list of Validation Error messages
            modGlobal.gv_sql = "Select *, ValidateWhen = case when useraction is null then 'Updating Field' else useraction end ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_TableValidationMessage ";
            modGlobal.gv_sql = modGlobal.gv_sql + " Where BaseTableid = " + Microsoft.VisualBasic.Compatibility.VB6.Support.GetItemData(frmTableValidationSetupCopy.cboTableList, frmTableValidationSetupCopy.cboTableList.SelectedIndex);

            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (state = '' or state is null) ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and state = '" + modGlobal.gv_State + "'";
            }

            if (string.IsNullOrEmpty(modGlobal.gv_status))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (RecordStatus = '' or RecordStatus is null) ";
            }
            else
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and RecordStatus = '" + modGlobal.gv_status + "'";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + " and MessageType = 'ERROR' ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by substring(Message, 1, 150) ";
            // 3.17.2005 - order by message

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);

            cboError.Items.Clear();

            while (!modGlobal.gv_rs.EOF)
            {
                cboError.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem((modGlobal.gv_rs.rdoColumns["Message"]).Value, modGlobal.gv_rs.rdoColumns["TableValidationMessageID"].Value));
                //LDW modGlobal.gv_rs.MoveNext();
            }

            modGlobal.gv_rs.Dispose();
        }
    }
}
