using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Compatibility.VB6;
// ERROR: Not supported in C#: OptionDeclaration
namespace COP2001
{
    internal partial class OldfrmPatientFieldsExportLinks : System.Windows.Forms.Form
    {

        private void cmdAddChildCrit_Click()
        {

        }

        private void cmdAddFIeldCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_Action. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            modGlobal.gv_Action = "FIELD";

            if (lstFieldsInMeasure.SelectedIndex > -1)
            {
                frmCMSParentAddCritCopy.SetCMSParentID(ref Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex));
                Support.ShowForm(frmCMSParentAddCritCopy, FormShowConstants.Modal, this);

                RefreshFieldMeasureCriteria();
            }
        }

        private void cmdChangeFieldJoin_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            string ls_JoinOp = null;
            int li_cnt = 0;
            DataSet rs_Temp = null;

            // ERROR: Not supported in C#: OnErrorStatement


            if (lstFieldsInMeasure.SelectedIndex > -1)
            {
                modGlobal.gv_sql = "SELECT JoinOperator FROM tbl_Setup_CMSFieldMeasureCriteriaSet WHERE CMSFieldMeasureID = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex);
                rs_Temp = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
                if (!rs_Temp.EOF)
                {
                    ls_JoinOp = rs_Temp.rdoColumns["JoinOperator"].Value;

                    modGlobal.gv_sql = "UPDATE tbl_Setup_CMSFieldMeasureCriteriaSet SET JoinOperator = " + (ls_JoinOp == "AND" ? "'OR'" : "'AND'") + " WHERE CMSFieldMeasureID = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshFieldMeasureCriteria();
                }
                rs_Temp.Dispose();

                //UPGRADE_NOTE: Object rs_Temp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                rs_Temp = null;
            }

            return;
            ErrHandler:
            modGlobal.CheckForErrors();

        }

        private void cmdChangeToHeaderField_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            object lstLinkedFields = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (lstLinkedFields.ListIndex > -1)
            {
                //change all the linked fields to link to this one instead
                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID =  " + lstLinkedFields.ItemData(lstLinkedFields.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " where LinkToDDID is not null ";
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and ddid <> " + lstLinkedFields.ItemData(lstLinkedFields.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureCode  = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "' ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //link the pervious header field to be a linked field
                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID =  " + lstLinkedFields.ItemData(lstLinkedFields.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " where fieldmeasureid = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex);
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //make this field the header field
                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID = null ";
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + lstLinkedFields.ItemData(lstLinkedFields.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureCode  = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "' ";
                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshLinkedFields();
                RefreshFieldsToLink();
            }

        }

        private void cmdRemoveFieldLink_Click()
        {
            object lstLinkedFields = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (lstLinkedFields.ListIndex > -1)
            {

                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID =  null ";
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + lstLinkedFields.ItemData(lstLinkedFields.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureCode  = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "' ";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshFieldsToLink();
                RefreshLinkedFields();

            }


        }

        private void cmdDelFieldCrit_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            // ERROR: Not supported in C#: OnErrorStatement


            if (lstFieldsInMeasure.SelectedIndex > -1)
            {
                if (lstFieldCriteria.SelectedIndex > -1)
                {

                    //there are triggers on these tables to keep the set numbers and everything in order
                    modGlobal.gv_sql = "DELETE FROM tbl_Setup_CMSFieldMeasureCriteria WHERE  CMSFieldMeasureCriteriaID = " + Support.GetItemData(lstFieldCriteria, lstFieldCriteria.SelectedIndex);
                    DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                    RefreshFieldMeasureCriteria();
                }
            }

            return;
            ErrHandler:

            modGlobal.CheckForErrors();
        }

        private void cmdUpdate_Click(System.Object eventSender, System.EventArgs eventArgs)
        {

            if (lstFieldsInMeasure.SelectedIndex > -1)
            {

                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                //        gv_sql = gv_sql & " set parentfield = "
                //        If IsNull(cboParentField.Text) Or cboParentField.Text = "" Then
                //            gv_sql = gv_sql & " null "
                //        Else
                //            gv_sql = gv_sql & " '" & cboParentField.Text & "'"
                //        End If
                modGlobal.gv_sql = modGlobal.gv_sql + "SET  FieldEdit = ";
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(cboFieldEdit.Text) | string.IsNullOrEmpty(cboFieldEdit.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboFieldEdit.Text + "'";
                }
                //        gv_sql = gv_sql & ", LinkParent = "
                //        If chkLinkToParent.Value = 0 Then
                //            gv_sql = gv_sql & " null "
                //        Else
                //            gv_sql = gv_sql & " 'Y'"
                //        End If
                modGlobal.gv_sql = modGlobal.gv_sql + ", OutputFormat = ";
                if (cboOutputFormat.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOutputFormat.Text + "'";
                }
                //       gv_sql = gv_sql & ", CalcParent = "
                //       If IsNull(txtCalcParent) Or txtCalcParent = "" Then
                //           gv_sql = gv_sql & " null "
                //       Else
                //           gv_sql = gv_sql & " '" & txtCalcParent & "'"
                //       End If
                //        gv_sql = gv_sql & ", CalcParentVal = "
                //        If chkCalcParent.Value = 0 Then
                //            gv_sql = gv_sql & " null "
                //        Else
                //            gv_sql = gv_sql & " 'Y'"
                //        End If
                //        gv_sql = gv_sql & ", DefaultValue = "
                //        If IsNull(txtDefaultValue) Or txtDefaultValue = "" Then
                //            gv_sql = gv_sql & " null "
                //        Else
                //            gv_sql = gv_sql & " '" & txtDefaultValue & "'"
                //        End If

                modGlobal.gv_sql = modGlobal.gv_sql + " where fieldmeasureid  = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex);

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                //' now updated all the related fields to the same outputformat and fieldedit

                modGlobal.gv_sql = " Update tbl_setup_cmsfieldmeasures ";
                modGlobal.gv_sql = modGlobal.gv_sql + "SET  FieldEdit = ";
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(cboFieldEdit.Text) | string.IsNullOrEmpty(cboFieldEdit.Text))
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboFieldEdit.Text + "'";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + ", OutputFormat = ";
                if (cboOutputFormat.SelectedIndex < 0)
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " null ";
                }
                else
                {
                    modGlobal.gv_sql = modGlobal.gv_sql + " '" + cboOutputFormat.Text + "'";
                }

                modGlobal.gv_sql = modGlobal.gv_sql + " WHERE ddid in (SELECT DDID  From vuCMSFieldMeasureGroups  WHERE fieldmeasureid  = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex) + ") ";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

            }

        }

        private void cmdVirtual_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            Support.ShowForm(dlgParentFieldsCopy, FormShowConstants.Modal, this);
        }

        private void cmsAddFieldLink_Click()
        {
            object lstFieldsToLink = null;

            //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldsToLink.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (lstFieldsToLink.ListIndex > -1)
            {

                modGlobal.gv_sql = "update tbl_setup_cmsfieldmeasures ";
                modGlobal.gv_sql = modGlobal.gv_sql + " set LinkToDDID = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
                //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldsToLink.ListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldsToLink.ItemData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " where ddid = " + lstFieldsToLink.ItemData(lstFieldsToLink.ListIndex);
                modGlobal.gv_sql = modGlobal.gv_sql + " and MeasureCode  = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "' ";

                DALcop.ExecuteCommand(modGlobal.gv_cn.ConnectionString, modGlobal.gv_sql);

                RefreshFieldsToLink();
                RefreshLinkedFields();

            }

        }

        private void frmPatientFieldsExportLinks_Load(System.Object eventSender, System.EventArgs eventArgs)
        {

            RefreshFieldsInMeasure();
            RefreshParentCDs();

        }

        //Public Sub RefreshParentFields()
        //
        //    gv_sql = "Select df.ddid, df.cmsfieldcode "
        //    gv_sql = gv_sql & " from tbl_setup_datadef as df  "
        //    gv_sql = gv_sql & " where cmsfieldcode is not null and df.ddid not in "
        //    gv_sql = gv_sql & " (select ddid from tbl_Setup_CMSFieldMeasures "
        //    gv_sql = gv_sql & " where fieldmeasureid = " & lstFieldsInMeasure.ItemData(lstFieldsInMeasure.ListIndex) & ")"
        //    gv_sql = gv_sql & " order by df.cmsfieldcode "
        //    Set rdcTemp.Resultset = gv_cn.OpenResultset(gv_sql, rdOpenStatic)
        //
        //    cboParentField.Clear
        //    cboCalcParentField.Clear
        //    thisListIndex = -1
        //    parentindex = -1
        //    calcparentindex = -1
        //    While Not rdcTemp.Resultset.EOF
        //        thisListIndex = thisListIndex + 1
        //        cboParentField.AddItem rdcTemp.Resultset!cmsfieldcode
        //        cboParentField.ItemData(cboParentField.NewIndex) = rdcTemp.Resultset!DDID
        //        If Not IsNull(rdcFieldList.Resultset!ParentField) Then
        //            If rdcFieldList.Resultset!ParentField = rdcTemp.Resultset!cmsfieldcode Then
        //                parentindex = thisListIndex
        //            End If
        //        End If
        //
        //        cboCalcParentField.AddItem rdcTemp.Resultset!cmsfieldcode
        //        cboCalcParentField.ItemData(cboParentField.NewIndex) = rdcTemp.Resultset!DDID
        //        If Not IsNull(rdcFieldList.Resultset!ParentField) Then
        //            If rdcFieldList.Resultset!CalcParent = rdcTemp.Resultset!cmsfieldcode Then
        //                calcparentindex = thisListIndex
        //            End If
        //        End If
        //
        //        rdcTemp.Resultset.MoveNext
        //    Wend
        //    If parentindex > -1 Then
        //        cboParentField.ListIndex = parentindex
        //    End If
        //    If calcparentindex > -1 Then
        //        cboCalcParentField.ListIndex = calcparentindex
        //    End If
        //
        //End Sub

        public void RefreshLookupTablesList()
        {
            object LookupIndex = null;
            object thisListIndex = null;

            modGlobal.gv_sql = "Select * From tbl_Setup_TableDef ";
            modGlobal.gv_sql = modGlobal.gv_sql + "Where TableType = 'LOOKUP' ";
            //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (string.IsNullOrEmpty(modGlobal.gv_State))
            {
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '' or State is null) ";
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object gv_State. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                modGlobal.gv_sql = modGlobal.gv_sql + " and (State = '" + modGlobal.gv_State + "' or State is null)";
            }
            modGlobal.gv_sql = modGlobal.gv_sql + "Order By BaseTable";

            rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcTemp.CtlRefresh();

            cboLookupTbls.Items.Clear();
            //UPGRADE_WARNING: Couldn't resolve default property of object thisListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            thisListIndex = -1;
            //UPGRADE_WARNING: Couldn't resolve default property of object LookupIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            LookupIndex = -1;
            while (!rdcTemp.Resultset.EOF)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object thisListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                thisListIndex = thisListIndex + 1;
                cboLookupTbls.Items.Add(new ListBoxItem(rdcTemp.Resultset.rdoColumns["BaseTable"].Value, rdcTemp.Resultset.rdoColumns["basetableid"].Value));
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (!Information.IsDBNull(rdcFieldList.Resultset.rdoColumns["fieldLookupTableID"].Value))
                {
                    if (rdcFieldList.Resultset.rdoColumns["fieldLookupTableID"].Value == rdcTemp.Resultset.rdoColumns["basetableid"].Value)
                    {
                        //UPGRADE_WARNING: Couldn't resolve default property of object thisListIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        //UPGRADE_WARNING: Couldn't resolve default property of object LookupIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        LookupIndex = thisListIndex;
                    }
                }

                rdcTemp.Resultset.MoveNext();
            }
            //UPGRADE_WARNING: Couldn't resolve default property of object LookupIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            if (LookupIndex > -1)
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object LookupIndex. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cboLookupTbls.SelectedIndex = LookupIndex;
            }

        }

        public void RefreshFieldsToLink()
        {
            object lstFieldsToLink = null;

            //retrieve the list of table fields only if they are already a part of the cmsfieldmeasures
            modGlobal.gv_sql = " Select * from tbl_setup_DataDef";
            modGlobal.gv_sql = modGlobal.gv_sql + " where ";
            modGlobal.gv_sql = modGlobal.gv_sql + " ddid <> " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " and BaseTableID in";
            modGlobal.gv_sql = modGlobal.gv_sql + " (select basetableid from tbl_setup_tableDef where BaseTable = 'PATIENT' )";
            modGlobal.gv_sql = modGlobal.gv_sql + " and ddid in ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (select ddid from tbl_setup_cmsFieldMeasures";
            modGlobal.gv_sql = modGlobal.gv_sql + "     where measurecode = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "' ";
            modGlobal.gv_sql = modGlobal.gv_sql + "     and linktoddid is null) ";
            modGlobal.gv_sql = modGlobal.gv_sql + " and ddid  not in ";
            modGlobal.gv_sql = modGlobal.gv_sql + " (select linktoddid from tbl_setup_cmsFieldMeasures";
            modGlobal.gv_sql = modGlobal.gv_sql + "     where measurecode = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + "     and linktoddid is not null)";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by FieldName ";
            //gv_sql = "Select * from tbl_setup_DataDef "
            //    gv_sql = gv_sql & " where BaseTableID in "
            //    gv_sql = gv_sql & " (select basetableid from tbl_setup_tableDef where BaseTable = 'PATIENT' )"
            //    gv_sql = gv_sql & " and ddid in "
            //    gv_sql = gv_sql & " (select ddid from tbl_setup_cmsFieldMeasures "
            //    gv_sql = gv_sql & " where measurecode = '" & rdcFieldList.Resultset!measurecode & "'"
            //    gv_sql = gv_sql & " and linktoddid is null "
            //    gv_sql = gv_sql & " and ddid not in "
            //    gv_sql = gv_sql & "     (select linktoddid from tbl_setup_cmsFieldMeasures "
            //    gv_sql = gv_sql & "         where linktoddid is not null and measurecode = '" & rdcFieldList.Resultset!measurecode & "')"
            //    gv_sql = gv_sql & " )"
            //    gv_sql = gv_sql & " and ddid <> " & rdcFieldList.Resultset!ddid
            //gv_sql = gv_sql & " order by FieldName "

            rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcTemp.CtlRefresh();

            //UPGRADE_WARNING: Couldn't resolve default property of object lstFieldsToLink.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lstFieldsToLink.Clear();
            while (!rdcTemp.Resultset.EOF)
            {
                lstFieldsToLink.Items.Add(new ListBoxItem(rdcTemp.Resultset.rdoColumns["FieldName"].Value, rdcTemp.Resultset.rdoColumns["DDID"].Value));
                rdcTemp.Resultset.MoveNext();
            }


        }

        public void RefreshLinkedFields()
        {
            object lstLinkedFields = null;

            //retrieve the list of table fields
            modGlobal.gv_sql = "Select df.fieldname, cms.ddid from tbl_setup_datadef as df ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_Setup_CMSFieldMeasures as cms ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where cms.linktoddid = " + rdcFieldList.Resultset.rdoColumns["DDID"].Value;
            modGlobal.gv_sql = modGlobal.gv_sql + " and cms.measurecode = '" + rdcFieldList.Resultset.rdoColumns["measurecode"].Value + "'";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by df.FieldName ";

            rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcTemp.CtlRefresh();

            //UPGRADE_WARNING: Couldn't resolve default property of object lstLinkedFields.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            lstLinkedFields.Clear();
            while (!rdcTemp.Resultset.EOF)
            {
                lstLinkedFields.Items.Add(new ListBoxItem(rdcTemp.Resultset.rdoColumns["FieldName"].Value, rdcTemp.Resultset.rdoColumns["DDID"].Value));
                rdcTemp.Resultset.MoveNext();
            }

        }

        private void Label10_Click()
        {

        }

        //UPGRADE_WARNING: Event lstFieldsInMeasure.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
        private void lstFieldsInMeasure_SelectedIndexChanged(System.Object eventSender, System.EventArgs eventArgs)
        {
            object txtCalcParent = null;
            object OptShowFirst = null;
            object OptShowEach = null;

            modGlobal.gv_sql = "Select cms.*, df.cmsfieldcode, df.jcfieldcode, df.lookuptableid as fieldlookuptableid, CMSParentCDID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " FROM tbl_Setup_CMSFieldMeasures cms INNER JOIN ";
            modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_DataDef df ON cms.DDID = df.DDID LEFT OUTER JOIN ";
            modGlobal.gv_sql = modGlobal.gv_sql + " tbl_Setup_CMSParentFieldMeasures ON cms.FieldMeasureID = tbl_Setup_CMSParentFieldMeasures.FieldMeasureID ";
            modGlobal.gv_sql = modGlobal.gv_sql + " where cms.FieldMeasureID = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex);

            rdcFieldList.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcFieldList.CtlRefresh();

            //RefreshFieldsToLink
            //RefreshLinkedFields
            RefreshLookupTablesList();
            //RefreshParentFields
            RefreshParentCDs();
            RefreshFieldMeasureCriteria();
            //UPGRADE_WARNING: Couldn't resolve default property of object OptShowEach. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OptShowEach = false;
            //UPGRADE_WARNING: Couldn't resolve default property of object OptShowFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            OptShowFirst = false;

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(rdcFieldList.Resultset.rdoColumns["fieldedit"].Value))
            {
                cboFieldEdit.Text = rdcFieldList.Resultset.rdoColumns["fieldedit"].Value;
            }
            else
            {
                cboFieldEdit.Text = "";
            }

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(rdcFieldList.Resultset.rdoColumns["OutputFormat"].Value))
            {
                cboOutputFormat.Text = rdcFieldList.Resultset.rdoColumns["OutputFormat"].Value;
            }
            else
            {
                cboOutputFormat.Text = "";
            }

            //    If Not IsNull(rdcFieldList.Resultset!LinkParent) Then
            //        chkLinkToParent.Value = 1
            //    Else
            //        chkLinkToParent.Value = 0
            //    End If

            //    If Not IsNull(rdcFieldList.Resultset!CalcParent) Then
            //        chkCalcParent.Value = 1
            //    Else
            //        chkCalcParent.Value = 0
            //    End If
            //    If Not IsNull(rdcFieldList.Resultset!ParentField) Then
            //        cboParentField = rdcFieldList.Resultset!ParentField
            //    Else
            //        cboParentField = ""
            //    End If

            //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            if (!Information.IsDBNull(rdcFieldList.Resultset.rdoColumns["CalcParent"].Value))
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object txtCalcParent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                txtCalcParent = rdcFieldList.Resultset.rdoColumns["CalcParent"].Value;
            }
            else
            {
                //UPGRADE_WARNING: Couldn't resolve default property of object txtCalcParent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                txtCalcParent = "";
            }

            //    If Not IsNull(rdcFieldList.Resultset!DefaultValue) Then
            //        txtDefaultValue = rdcFieldList.Resultset!DefaultValue
            //    Else
            //        txtDefaultValue = ""
            //    End If



        }

        private void RefreshParentCDs()
        {
            short li_ParentIndex = 0;

            //retrieve the list of Parent Fields
            modGlobal.gv_sql = "Select * ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_CMSParentCD ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by CMSParentCD ";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);

            li_ParentIndex = -1;

            cboParentField.Items.Clear();
            while (!modGlobal.gv_rs.EOF)
            {
                cboParentField.Items.Add(new ListBoxItem(modGlobal.gv_rs.rdoColumns["CMSParentCD"].Value, modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value));

                if ((rdcFieldList.Resultset != null))
                {
                    //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    if (!Information.IsDBNull(rdcFieldList.Resultset.rdoColumns["CMSParentCDID"].Value))
                    {
                        if (rdcFieldList.Resultset.rdoColumns["CMSParentCDID"].Value == modGlobal.gv_rs.rdoColumns["CMSParentCDID"].Value)
                        {
                            //UPGRADE_ISSUE: ComboBox property cboParentField.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                            li_ParentIndex = cboParentField.Items.Count-1;
                        }
                    }
                }

                //LDW modGlobal.gv_rs.MoveNext();
            }

            cboParentField.SelectedIndex = li_ParentIndex;

            modGlobal.gv_rs.Dispose();

        }

        public void RefreshFieldsInMeasure()
        {
            object FieldName = null;
            object cmsfieldcode = null;

            //retrieve the list of table fields only if they are already a part of the cmsfieldmeasures
            modGlobal.gv_sql = "Select cms.FieldMeasureID, cms.measurecode, df.ddid, df.fieldname, df.cmsfieldcode ";
            modGlobal.gv_sql = modGlobal.gv_sql + " from tbl_setup_DataDef as df ";
            modGlobal.gv_sql = modGlobal.gv_sql + " inner join tbl_setup_cmsFieldMeasures as cms ";
            modGlobal.gv_sql = modGlobal.gv_sql + " on df.ddid = cms.ddid ";
            modGlobal.gv_sql = modGlobal.gv_sql + " order by cms.measurecode, df.FieldName ";

            rdcTemp.Resultset = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenStatic);
            //UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            rdcTemp.CtlRefresh();

            lstFieldsInMeasure.Items.Clear();
            while (!rdcTemp.Resultset.EOF)
            {
                //UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                if (Information.IsDBNull(rdcTemp.Resultset.rdoColumns["cmsfieldcode"].Value))
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object cmsfieldcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cmsfieldcode = "";
                }
                else
                {
                    //UPGRADE_WARNING: Couldn't resolve default property of object cmsfieldcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    cmsfieldcode = " ***** " + rdcTemp.Resultset.rdoColumns["cmsfieldcode"].Value;
                }
                //UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FieldName = " - " + rdcTemp.Resultset.rdoColumns["FieldName"].Value;
                //UPGRADE_WARNING: Couldn't resolve default property of object cmsfieldcode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //UPGRADE_WARNING: Couldn't resolve default property of object FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lstFieldsInMeasure.Items.Add(new ListBoxItem(rdcTemp.Resultset.rdoColumns["measurecode"].Value + FieldName + cmsfieldcode, rdcTemp.Resultset.rdoColumns["fieldmeasureid"].Value));
                rdcTemp.Resultset.MoveNext();
            }


        }

        private void RefreshFieldMeasureCriteria()
        {
            string ls_display = null;
            DataSet rs_Criteria = null;
            int li_SetCnt = 0;
            short li_SetIndex = 0;
            string ls_SetJoinOp = null;
            int li_MaxSet = 0;

            lstFieldCriteria.Items.Clear();

            modGlobal.gv_sql = "SELECT CMSFieldMeasureCriteriaSet, JoinOperator FROM tbl_Setup_CMSFieldMeasureCriteriaSet  " + " WHERE CMSFieldMeasureID = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex) + " ORDER BY CMSFieldMeasureCriteriaSet";

            modGlobal.gv_rs = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);

            if (!modGlobal.gv_rs.EOF)
            {

                modGlobal.gv_rs.MoveLast();
                li_MaxSet = modGlobal.gv_rs.RowCount;
                modGlobal.gv_rs.MoveFirst();

                while (!modGlobal.gv_rs.EOF)
                {

                    ls_SetJoinOp = modGlobal.gv_rs.rdoColumns["JoinOperator"].Value;

                    modGlobal.gv_sql = "SELECT * FROM tbl_Setup_CMSFieldMeasureCriteria  " + " WHERE CMSFieldMeasureID = " + Support.GetItemData(lstFieldsInMeasure, lstFieldsInMeasure.SelectedIndex) + " AND  CMSFieldMeasureCriteriaSet =  " + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaSet"].Value + " ORDER BY CMSFieldMeasureCriteriaSet, CMSFieldMeasureCriteriaID";

                    rs_Criteria = modGlobal.gv_cn.OpenResultset(modGlobal.gv_sql, RDO.ResultsetTypeConstants.rdOpenKeyset);
                    rs_Criteria.MoveLast();
                    li_SetCnt = rs_Criteria.RowCount;
                    rs_Criteria.MoveFirst();

                    li_SetIndex = 0;

                    ls_display = "SET " + modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaSet"].Value + ": ( ";

                    while (!rs_Criteria.EOF)
                    {
                        li_SetIndex = li_SetIndex + 1;

                        ls_display = ls_display + "   " + rs_Criteria.rdoColumns["CriteriaTitle"].Value;

                        if (li_SetCnt == li_SetIndex)
                        {
                            if (li_SetCnt == 1)
                            {
                                ls_display = ls_display + " (" + rs_Criteria.rdoColumns["JoinOperator"].Value + ") )";
                            }
                            else
                            {
                                ls_display = ls_display + " )";
                            }
                        }
                        else
                        {
                            ls_display = ls_display + " " + rs_Criteria.rdoColumns["JoinOperator"].Value + " ";
                        }

                        lstFieldCriteria.Items.Add(new ListBoxItem(ls_display, rs_Criteria.rdoColumns["CMSFieldMeasureCriteriaID"].Value));
                        ls_display = "";

                        //LDW rs_Criteria.MoveNext();
                    }

                    rs_Criteria.Dispose();

                    if (modGlobal.gv_rs.rdoColumns["CMSFieldMeasureCriteriaSet"].Value < li_MaxSet)
                    {
                        lstFieldCriteria.Items.Add(ls_SetJoinOp);
                    }

                    //LDW modGlobal.gv_rs.MoveNext();

                }
            }

            modGlobal.gv_rs.Dispose();


        }
    }
}
